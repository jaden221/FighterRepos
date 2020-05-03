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

        // Update is called once per frame
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

        }
    }

}

