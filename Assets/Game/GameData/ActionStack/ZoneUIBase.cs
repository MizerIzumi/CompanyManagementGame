using System;
using UnityEngine;

namespace Game
{
    public class ZoneUIBase : ActionStack.ActionBehavior
    {
        [SerializeField]
        private GameObject _thisUI;
        [SerializeField]
        private ActionStack.ActionBehavior _worldAS;
        [SerializeField]
        private ActionStack.ActionBehavior _TownAS;
        [SerializeField]
        private ActionStack.ActionBehavior _companyAS;

        private bool _movingZones = true;
        private ActionStack.ActionBehavior _zoneToGoTo;
        private bool _testDoOnceBool;
        public bool isDone = false;

        public override void OnBegin(bool bFirstTime)
        {
            isDone = false;
            _movingZones = false;
            _testDoOnceBool = true;
            base.OnBegin(bFirstTime);
            _thisUI.SetActive(true);
        }
        
        

        public void MoveToCompany()
        {
            _zoneToGoTo = _companyAS;
            _movingZones = true;
            isDone = true;
        }
        
        public void MoveToTown()
        {
            _zoneToGoTo = _TownAS;
            _movingZones = true;
            isDone = true;
        }

        public void MoveToWorld()
        {
            _zoneToGoTo = _worldAS;
            _movingZones = true;
            isDone = true;
        }

        

        public override bool IsDone()
        {
            return isDone;
        }

        public override void OnEnd()
        {
            base.OnEnd();
            _thisUI.SetActive(false);
            if (_movingZones && _testDoOnceBool)
            {
                _testDoOnceBool = false;
                ActionStack.Main.PushAction(_zoneToGoTo);
            }
        }
    }
}
