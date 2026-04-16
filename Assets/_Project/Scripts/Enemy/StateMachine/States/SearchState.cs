using UnityEngine;
using StateMachine;

namespace Enemy.States 
{
    public class SearchState : AState {

        private readonly SO_SearchState _searchData;
        private EnemyController _enemy;
        private NormalSubSM _normalSM;
        private Rigidbody2D _rb;

        private RaycastHit2D _playerDetectionHit;
        
        public SearchState(SO_State data) : base(data) {
            _searchData = _stateData as SO_SearchState;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _enemy = controller as EnemyController;
            _normalSM = parent as NormalSubSM;
            _rb = _enemy.Rigidbody2D;
        }

        public override void EnterState() {
            base.EnterState();
            Debug.Log("Enter To Search State");
            CheckPlayerDetection();
        }

        public override void UpdateState() {
            base.UpdateState();
        }

        public override void FixedUpdateState() {
            base.FixedUpdateState();
            HandleMovementToTarget();
        }

        public override void ExitState() {
            base.ExitState();
        }
        
        private void CheckPlayerDetection()
        {
            _playerDetectionHit = Physics2D.BoxCast(
                (Vector2)_enemy.transform.position + Vector2.up * _searchData.BoxOffset,
                _searchData.BoxSize, 0f,
                Vector2.right * _enemy.FacingDirection,
                _searchData.BoxDistance,
                _searchData.PlayerLayer
            );
        }

        private void HandleMovementToTarget()
        {
            Debug.Log(Vector2.Distance(_playerDetectionHit.point, _enemy.transform.position));
            if (Vector2.Distance(_playerDetectionHit.point, _enemy.transform.position) < 1.0f)
            {
                StopMovement();
                _normalSM.ChangeState(NormalState.Identify);
                return;
            }

            MoveToPlayer();
        }
        
        private void MoveToPlayer()
        {
            if (_playerDetectionHit.collider == null) return;
            
            Vector2 direction = (_playerDetectionHit.point - (Vector2)_enemy.transform.position).normalized;
            _rb.linearVelocity = new Vector2(direction.x * _searchData.Speed, _rb.linearVelocity.y);
            _enemy.FlipSprite(direction.x);
        }

        private void StopMovement()
        {
            _rb.linearVelocity = Vector2.zero;
        }
    }
}