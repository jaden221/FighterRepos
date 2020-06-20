using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.State
{
    [CreateAssetMenu(fileName = "New State", menuName = "States/AbilityData/AttackBeam")]
    public class AttackBeam : StateData
    {
        public GameObject projectile;
        GameObject beamObj;

        public Vector3 spawnPoint;

        public float totalWindows;
        float totalWindowsSaved;

        float timePerWindow;
        float timePerWindowSaved;

        public float totalBeamDamage;
        float damage;

        public float stunTime;

        public override void OnEnter(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            animator.SetBool(TransitionParameter.Beam.ToString(), false);

            totalWindowsSaved = 0;
            timePerWindow = 0;
            timePerWindowSaved = 0;

            totalWindowsSaved = totalWindows;
            timePerWindow = 1 / totalWindowsSaved;
            timePerWindowSaved = timePerWindow;
            damage = totalBeamDamage / totalWindowsSaved;

            characterState.characterControl.beamAttackInfo.ResetInfo();
            characterState.characterControl.beamAttackInfo.SetValues(damage, stunTime);
            
            beamObj = Instantiate(projectile, ShootRightOrLeft(characterState), Quaternion.Euler(0, 90, 0)) as GameObject;

            //Tells the beam that it's basically owned by this obj so BeamTriggerDetector knows not to hit itself
            beamObj.GetComponent<BeamTriggerDetector>().characterControl = characterState.characterControl;
        }

        public override void UpdateAbility(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            if (stateInfo.normalizedTime >= timePerWindow)
            {

                timePerWindow += timePerWindowSaved;

                characterState.characterControl.beamAttackInfo.IncrementCurrentWindow();
            }
        }

        public override void OnExit(CharacterState characterState, Animator animator, AnimatorStateInfo stateInfo)
        {
            characterState.characterControl.beamAttackInfo.IncrementCurrentWindow();
            Destroy(beamObj);
        }

        private Vector3 ShootRightOrLeft(CharacterState characterState)
        {
            Vector3 beamSpawnPoint;
            if (characterState.characterControl.IsFacingForward())
            {
                beamSpawnPoint = new Vector3(
                characterState.characterControl.transform.position.x + spawnPoint.x,
                characterState.characterControl.transform.position.y + spawnPoint.y,
                characterState.characterControl.transform.position.z + spawnPoint.z);
            }
            else
            {
                beamSpawnPoint = new Vector3(
                characterState.characterControl.transform.position.x + spawnPoint.x,
                characterState.characterControl.transform.position.y + spawnPoint.y,
                characterState.characterControl.transform.position.z + (spawnPoint.z * -1));
            }

            return beamSpawnPoint;
        }

        //private void OldTickMethod(CharacterState characterState)
        //{
        //    if (currentTimeBetweenTicks < timeBetweenTicks)
        //    {
        //        currentTimeBetweenTicks += Time.deltaTime;
        //        characterState.characterControl.beamAttackInfo.canDmg = false;
        //        return;
        //    }

        //    if (currentTimeBetweenTicks > timeBetweenTicks)
        //    {
        //        if (currentTimeTicking < timeTicking)
        //        {
        //            currentTimeTicking += Time.deltaTime;
        //            characterState.characterControl.beamAttackInfo.canDmg = true;
        //            return;
        //        }
        //        else
        //        {
        //            currentTimeBetweenTicks = 0;
        //            currentTimeTicking = 0;
        //            characterState.characterControl.beamAttackInfo.canDmg = false;
        //            return;
        //        }
        //    }
        //}
    }
}