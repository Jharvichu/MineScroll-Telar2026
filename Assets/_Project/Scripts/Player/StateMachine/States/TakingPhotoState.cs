using UnityEngine;
using StateMachine;

namespace Player.States {

    public class TakingPhotoState : AState {

        private readonly SO_TakingPhotoState _takingPhotoData;
        private PlayerController _player;
        private PhotoModeSubSM _photoModeSM;
        private Rigidbody2D _rb;

        public TakingPhotoState(SO_State data) : base(data) {
            _takingPhotoData = _stateData as SO_TakingPhotoState;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _player = controller as PlayerController;
            _photoModeSM = parent as PhotoModeSubSM;
            _rb = _player.Rigidbody2D;
        }

        public override void EnterState() {
            base.EnterState();
            Debug.Log("Enter To Taking photo State");
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