using UnityEngine;
using StateMachine;

namespace Player.States 
{
    public class GroundState : AState {

        private readonly SO_GroundState _groundData;
        private PlayerController _player;
        private MovementSubSM _movementSM;
        private Rigidbody2D _rb;

        public GroundState(SO_State data) : base(data) {
            _groundData = _stateData as SO_GroundState;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _player = controller as PlayerController;
            _movementSM = parent as MovementSubSM;
            _rb = _player.Rigidbody2D;
        }

        public override void EnterState() {
            base.EnterState();
            Debug.Log("Enter To Ground State");
        }

        public override void UpdateState() {
            base.UpdateState();
        }

        public override void FixedUpdateState() {
            Move();
            base.FixedUpdateState();
        }

        public override void ExitState() {
            base.ExitState();
        }

        private void Move()
        {
            Vector2 targetVelocity = new Vector2(
                _player.InputHandler.MoveInput.x * _groundData.Speed,
                _player.InputHandler.MoveInput.y * _groundData.Speed * _groundData.VerticalSpeedMultiplier
            );
            
            _rb.linearVelocity = Vector2.Lerp(
                _rb.linearVelocity,
                targetVelocity,
                _groundData.Acceleration
            );

            _player.FlipSprite(_player.InputHandler.MoveInput.x);
        }

    }
}