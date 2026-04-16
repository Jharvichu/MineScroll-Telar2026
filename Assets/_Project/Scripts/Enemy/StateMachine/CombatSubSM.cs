using StateMachine;
using UnityEngine;

namespace Enemy
{
    public class CombatSubSM : AStateMachine 
    {
        private SO_CombatSubSM _combatData;
        private EnemyStateMachine _enemySM;
        private EnemyController _enemy;
        
        private RaycastHit2D _visionPlayerHit, _attackPlayerHit;

        public CombatSubSM(SO_StateMachine data) : base(data) {
            _combatData = data as SO_CombatSubSM;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _enemy = controller as EnemyController;
            _enemySM = parent as EnemyStateMachine;
        }

        public override void EnterState() {
            ChangeState(CombatState.Chase);
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
            CheckVision();
            CheckAttackRange();
        }
        
        private void CheckVision()
        {
            _visionPlayerHit = Physics2D.BoxCast(
                (Vector2)_enemy.transform.position + Vector2.up * _combatData.VisionOffset,
                _combatData.VisionBoxSize, 0f,
                Vector2.right * _enemy.FacingDirection,
                _combatData.VisionDistance,
                _combatData.PlayerLayer
            );
            
            if (!_visionPlayerHit) _enemySM.ChangeState(EnemyState.Normal);
        }
        
        private void CheckAttackRange()
        {
            _attackPlayerHit = Physics2D.BoxCast(
                (Vector2)_enemy.transform.position + Vector2.up * _combatData.AttackOffset,
                _combatData.AttackBoxSize,
                0f,
                Vector2.right * _enemy.FacingDirection,
                _combatData.AttackDistance,
                _combatData.PlayerLayer
            );
            
            if(_attackPlayerHit) ChangeState(CombatState.Attack);
        }

        private void DrawDebug()
        {
            DrawBoxCastDebug(_combatData.VisionBoxSize, _combatData.VisionOffset, _combatData.VisionDistance, Color.green);
            DrawBoxCastDebug(_combatData.AttackBoxSize, _combatData.AttackOffset, _combatData.AttackDistance, Color.red);
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