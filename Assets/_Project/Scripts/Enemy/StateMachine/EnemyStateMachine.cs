using Enemy.States;
using UnityEngine;
using StateMachine;

namespace Enemy {

    public enum EnemyState {
        Normal,
        Combat,
        Death,
    }

    public enum NormalState {
        Patrol,
        Search,
        Identify
    }

    public enum CombatState
    {
        Chase,
        Attack
    }

    public class EnemyStateMachine : AStateMachine {
        private EnemyController _enemy;
        private SO_EnemySM _enemySMData;
        private RaycastHit2D _playerDetectionHit;

        public EnemyStateMachine(SO_StateMachine data) : base(data)
        {
            _enemySMData = _stateMachineData as SO_EnemySM;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _enemy = controller as EnemyController;
        }

        public override void UpdateState() {
            base.UpdateState();
            CheckPlayerDetection();
            DrawDebug();
        }
        
        private void CheckPlayerDetection()
        {
            _playerDetectionHit = Physics2D.BoxCast(
                (Vector2)_enemy.transform.position + Vector2.up * _enemySMData.BoxOffset,
                _enemySMData.BoxSize, 0f,
                Vector2.right * _enemy.FacingDirection,
                _enemySMData.BoxDistance,
                _enemySMData.PlayerLayer
            );
            
            if (_playerDetectionHit) ChangeState(EnemyState.Combat);
        }

        private void DrawDebug()
        {
            DrawBoxCastDebug(_enemySMData.BoxSize, _enemySMData.BoxOffset, _enemySMData.BoxDistance, Color.yellow);
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