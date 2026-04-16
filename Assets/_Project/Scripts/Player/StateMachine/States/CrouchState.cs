using UnityEngine;
using StateMachine;

namespace Player.States 
{
    public class CrouchState : AState {

        private readonly SO_CrouchState _crouchData;
        private PlayerController _player;
        private MovementSubSM _movementSM;
        private Rigidbody2D _rb;

        public CrouchState(SO_State data) : base(data) {
            _crouchData = _stateData as SO_CrouchState;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _player = controller as PlayerController;
            _movementSM = parent as MovementSubSM;
            _rb = _player.Rigidbody2D;
        }

        public override void EnterState() {
            base.EnterState();
            Debug.Log("Enter To Crouch State");
        }

        public override void UpdateState() {
            base.UpdateState();
        }

        public override void FixedUpdateState() {
            base.FixedUpdateState();
            Move();
        }

        public override void ExitState() {
            base.ExitState();
        }
        
        private void Move()
        {
            Vector2 targetVelocity = new Vector2(
                _player.InputHandler.MoveInput.x * _crouchData.Speed,
                _player.InputHandler.MoveInput.y * _crouchData.Speed * _crouchData.VerticalSpeedMultiplier
            );
            
            _rb.linearVelocity = Vector2.Lerp(
                _rb.linearVelocity,
                targetVelocity,
                _crouchData.Acceleration * Time.deltaTime
            );

            _player.FlipSprite(_player.InputHandler.MoveInput.x);
        }

    }
}