using StateMachine;
using UnityEngine;

namespace Enemy
{
    public class NormalSubSM : AStateMachine 
    {
        private SO_NormalSubSM _normalData;
        private EnemyStateMachine _enemySM;
        private EnemyController _enemy;
        
        private RaycastHit2D _playerDetectionHit;

        public NormalSubSM(SO_StateMachine data) : base(data) {
            _normalData = data as SO_NormalSubSM;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _enemy = controller as EnemyController;
            _enemySM = parent as EnemyStateMachine;
        }

        public override void EnterState() {
            ChangeState(NormalState.Patrol);
            base.EnterState();
        }

        public override void UpdateState() {
            base.UpdateState();
            CheckPlayerDetection();
            DrawDebug();
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
                (Vector2)_enemy.transform.position + Vector2.up * _normalData.BoxOffset,
                _normalData.BoxSize, 0f,
                Vector2.right * _enemy.FacingDirection,
                _normalData.BoxDistance,
                _normalData.PlayerLayer
            );
            
            if (_playerDetectionHit) ChangeState(NormalState.Search);
        }

        private void DrawDebug()
        {
            DrawBoxCastDebug(_normalData.BoxSize, _normalData.BoxOffset, _normalData.BoxDistance, Color.green);
        }
        
        private void DrawBoxCastDebug(Vector2 boxSize, float boxOffset, float boxDistance, Color color)
        {
            Vector2 origin = (Vector2)_enemy.transform.position + Vector2.up * boxOffset;
            Vector2 end = origin + Vector2.right * _enemy.FacingDirection * boxDistance;
            Vector2 half = boxSize * 0.5f;

            Debug.DrawLine(end + new Vector2(-half.x, -half.y), end + new Vector2(half.x, -half.y), color);
            Debug.DrawLine(end + new Vector2(half.x, -half.y), end + new Vector2(half.x, half.y), color);
            Debug.DrawLine(end + new Vector2(half.x, half.y), end + new Vector2(-half.x, half.y), color);
            Debug.DrawLine(end + new Vector2(-half.x, half.y), end + new Vector2(-half.x, -half.y), color);
        }
        
    }
}