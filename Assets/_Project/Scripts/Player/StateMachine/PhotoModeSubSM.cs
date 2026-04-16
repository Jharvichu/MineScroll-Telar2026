using StateMachine;
using UnityEngine;

namespace Player
{
    public class PhotoModeSubSM : AStateMachine
    {
        private SO_PhotoModeSubSM _photoModeData;
        private PlayerController _player;

        public PhotoModeSubSM(SO_StateMachine data) : base(data) {
            _photoModeData = data as SO_PhotoModeSubSM;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _player = controller as PlayerController;
        }

        public override void EnterState() {
            ChangeState(PhotoState.TakingPhoto);
            base.EnterState();
        }

        public override void UpdateState() {
            base.UpdateState();
        }

        public override void FixedUpdateState() {
            base.FixedUpdateState();
        }

        public override void ExitState() {
            base.ExitState();
        }
    }
}