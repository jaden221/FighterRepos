using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core
{
    // Looks at VirtualInputManager and sets character control variables accordingly/ only for player/ exists so that original player input can be swapped between KBM and joystick
    public class ManualInput : MonoBehaviour
    {

        private CharacterControl characterControl;

        void Awake()
        {
            characterControl = GetComponent<CharacterControl>();
        }

        void Update()
        {
            if (VirtualInputManager.Instance.moveRight)
            {
                characterControl.moveRight = true;
            }
            else
            {
                characterControl.moveRight = false;
            }

            if (VirtualInputManager.Instance.moveLeft)
            {
                characterControl.moveLeft = true;
            }
            else
            {
                characterControl.moveLeft = false;
            }

            if (VirtualInputManager.Instance.jump)
            {
                characterControl.jump = true;
            }
            else
            {
                characterControl.jump = false;
            }

            if (VirtualInputManager.Instance.attack)
            {
                characterControl.attack = true;
            }
            else
            {
                characterControl.attack = false;
            }

            if (VirtualInputManager.Instance.strafe)
            {
                characterControl.strafe = true;
            }
            else
            {
                characterControl.strafe = false;
            }

            if (VirtualInputManager.Instance.run)
            {
                characterControl.run = true;
            }
            else
            {
                characterControl.run = false;
            }

            if (VirtualInputManager.Instance.beam)
            {
                characterControl.beam = true;
            }
            else
            {
                characterControl.beam = false;
            }
        }
    }

}

