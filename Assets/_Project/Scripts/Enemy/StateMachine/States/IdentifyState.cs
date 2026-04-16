using UnityEngine;
using StateMachine;

namespace Enemy.States 
{
    public class IdentifyState : AState {

        private readonly SO_IdentifyState _identifyData;
        private EnemyController _enemy;
        private NormalSubSM _normalSM;
        private Rigidbody2D _rb;

        private float _stateTimer, _switchTimer;
        
        public IdentifyState(SO_State data) : base(data) {
            _identifyData = _stateData as SO_IdentifyState;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _enemy = controller as EnemyController;
            _normalSM = parent as NormalSubSM;
            _rb = _enemy.Rigidbody2D;
        }

        public override void EnterState() {
            base.EnterState();
            Debug.Log("Enter To Identity State");
        }

        public override void UpdateState() {
            base.UpdateState();
            
            _stateTimer += Time.deltaTime;
            _switchTimer += Time.deltaTime;
            
            HandleLookAround();
        }

        public override void FixedUpdateState() {
            base.FixedUpdateState();
        }

        public override void ExitState() {
            base.ExitState();
        }

        private void HandleLookAround()
        {
            if (_switchTimer < _identifyData.SwitchDirectionTime) return;
            
            _switchTimer = 0f;
            _enemy.FlipSprite(_rb.transform.localScale.x * -1);

            if (_stateTimer >= _identifyData.TotalIdentifyTime)
            {
                _stateTimer = 0.0f;
                _normalSM.ChangeState(NormalState.Patrol);
            }
        }
    }
}