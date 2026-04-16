using UnityEngine;
using StateMachine;

namespace Enemy.States 
{
    public class ChaseState : AState {

        private readonly SO_ChaseState _chaseData;
        private EnemyController _enemy;
        private CombatSubSM _combatSM;
        private Rigidbody2D _rb;
        
        private RaycastHit2D _playerDetectionHit;

        public ChaseState(SO_State data) : base(data) {
            _chaseData = _stateData as SO_ChaseState;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _enemy = controller as EnemyController;
            _combatSM = parent as CombatSubSM;
            _rb = _enemy.Rigidbody2D;
        }

        public override void EnterState() {
            base.EnterState();
            Debug.Log("Enter To Chase State");
        }

        public override void UpdateState() {
            base.UpdateState();
            CheckPlayerDetection();
            MoveToPlayer();
        }

        public override void FixedUpdateState() {
            base.FixedUpdateState();
        }

        public override void ExitState() {
            base.ExitState();
        }
        
        private void CheckPlayerDetection()
        {
            _playerDetectionHit = Physics2D.BoxCast(
                (Vector2)_enemy.transform.position + Vector2.up * _chaseData.BoxOffset,
                _chaseData.BoxSize, 0f,
                Vector2.right * _enemy.FacingDirection,
                _chaseData.BoxDistance,
                _chaseData.PlayerLayer
            );
        }

        private void MoveToPlayer()
        {
            if (_playerDetectionHit.collider == null) return;
            
            Vector2 direction = (_playerDetectionHit.point - (Vector2)_enemy.transform.position).normalized;
            _rb.linearVelocity = new Vector2(direction.x * _chaseData.Speed, _rb.linearVelocity.y);
            _enemy.FlipSprite(direction.x);
        }
    }
}