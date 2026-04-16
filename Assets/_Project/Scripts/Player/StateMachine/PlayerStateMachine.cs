using StateMachine;

namespace Player {

    public enum PlayerState {
        Movement,
        PhotoMode,
        Death,
    }

    public enum MovementState {
        Ground,
        Crouch
    }

    public enum PhotoState
    {
        TakingPhoto
    }

    public class PlayerStateMachine : AStateMachine {
        private PlayerController _player;

        public PlayerStateMachine(SO_StateMachine data) : base(data) { }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _player = controller as PlayerController;
        }

        public override void UpdateState() {
            base.UpdateState();
            HandleInput();
        }

        private void HandleInput()
        {
            if(_player.InputHandler.TakePhotoPressed) ChangeState(PlayerState.PhotoMode);
        }
        
    }
}