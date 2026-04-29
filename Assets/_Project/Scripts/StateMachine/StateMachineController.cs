using UnityEngine;

namespace StateMachine {
	public abstract class StateMachineController : MonoBehaviour {
		[SerializeField] SO_StateMachine _rootStateMachine;

		protected virtual void Awake() {
			var _ = _rootStateMachine.State as AStateMachine;
			_rootStateMachine.CurrentState = null;
			_.Init(this);
		}

		protected virtual void Start() {
			var _ = _rootStateMachine.State as AStateMachine;
			_.ChangeState(_rootStateMachine.InitialState.NodeType);
		}

		protected virtual void Update() {
            Player.PlayerController player = this as Player.PlayerController;

            // 🔥 BLOQUEO GLOBAL
            if (player != null && !player.canControl)
                return;

            _rootStateMachine.UpdateState();
        }

		protected virtual void FixedUpdate() {
            Player.PlayerController player = this as Player.PlayerController;

            // 🔥 BLOQUEO GLOBAL DE FÍSICA
            if (player != null && !player.canControl)
            {
                if (player.Rigidbody2D != null)
                    player.Rigidbody2D.linearVelocity = Vector2.zero;

                return;
            }

            _rootStateMachine.FixedUpdateState();
        }

		public System.Enum GetCurrentState() {
			var currentMachine = _rootStateMachine.State as AStateMachine;
			System.Enum currentState = null;

			while (currentMachine is not null) {
				currentState = currentMachine.GetCurrentState();
				currentMachine = currentMachine.GetState(currentState).State as AStateMachine;
			}

			return currentState;
		}

		protected void ResetMachine() {
			var _ = _rootStateMachine.State as AStateMachine;
			_.ChangeState(_rootStateMachine.InitialState.NodeType);
		}
	}

}