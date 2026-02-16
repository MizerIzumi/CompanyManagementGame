using System;
using Game;
using UnityEngine;

namespace Game
{
    public class AS_Game : ActionStack.ActionBehavior
    {
        private static AS_Game _sminstance;
        public static AS_Game Instance => _sminstance;
        
        [SerializeField]
        private ActionStack.ActionBehavior _startingAction;

        private void Start()
        {
            _sminstance = this;
            
            ActionStack.Main.PushAction(this);
        }

        public override void OnBegin(bool bFirstTime)
        {
            base.OnBegin(bFirstTime);
            ActionStack.Main.PushAction(_startingAction);
        }

        public override bool IsDone()
        {
            return false;
        }
    }
}

/*
     public class AS_Game : ActionStack
    {
        private static AS_Game _sminstance;
        public static AS_Game Instance => _sminstance;
        
        [SerializeField]
        private ActionBehavior _startingAction;

        private void Start()
        {
            _sminstance = this;
            
            PushAction(_startingAction);
        }
    }
 */
