using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project.Core
{
    //Holds bools for actions and nothing else... can be used only for player
    public class VirtualInputManager : Singleton<VirtualInputManager>
    {
        public bool moveRight;
        public bool moveLeft;
        public bool jump;
        public bool attack;
        public bool strafe;
        public bool run;
    }
}