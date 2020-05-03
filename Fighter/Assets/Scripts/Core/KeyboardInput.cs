using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core
{
    //Takes keyboard input and changes VirtualInputManager bools accordingly, can be swapped to use something like joystick instead
    public class KeyboardInput : MonoBehaviour
    {
       // Need to turn keycodes into something player can change
        void Update()
        {

            if (Input.GetKey(KeyCode.D))
            {
                VirtualInputManager.Instance.moveRight = true;
            }
            else
            {
                VirtualInputManager.Instance.moveRight = false;
            }

            if (Input.GetKey(KeyCode.A))
            {
                VirtualInputManager.Instance.moveLeft = true;
            }
            else
            {
                VirtualInputManager.Instance.moveLeft = false;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                VirtualInputManager.Instance.jump = true;
            }
            else
            {
                VirtualInputManager.Instance.jump = false;
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                VirtualInputManager.Instance.attack = true;
            }
            else
            {
                VirtualInputManager.Instance.attack = false;
            }
        }
    }
}


