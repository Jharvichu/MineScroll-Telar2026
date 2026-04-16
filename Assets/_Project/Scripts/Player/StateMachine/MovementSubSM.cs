using StateMachine;
using UnityEngine;

namespace Player 
{
	public class MovementSubSM : AStateMachine 
	{
		private SO_MovementSubSM _movementData;
		private PlayerController _player;
		
		private bool _isCrouching;

		public MovementSubSM(SO_StateMachine data) : base(data) {
			_movementData = data as SO_MovementSubSM;
		}

		public override void Init(StateMachineController controller, AStateMachine parent = null) {
			base.Init(controller, parent);
			_player = controller as PlayerController;
		}

		public override void EnterState() {
			ChangeState(MovementState.Ground);
			base.EnterState();
		}

		public override void UpdateState() {
			base.UpdateState();
			HandleInput();
		}

		public override void FixedUpdateState() {
			base.FixedUpdateState();
		}

        public override void ExitState() {
			base.ExitState();
		}
        
		private void HandleInput()
		{
			if (_player.InputHandler.CrouchPressed) ToggleCrouch();
		}

		private void ToggleCrouch()
		{
			_isCrouching = !_isCrouching;
			ChangeState(_isCrouching ? MovementState.Crouch : MovementState.Ground);
		}

		
		
		
	}
}