using UnityEngine;
using StateMachine;

namespace Enemy.States 
{
    public class AttackState : AState {

        private readonly SO_AttackState _attackData;
        private EnemyController _enemy;
        private CombatSubSM _combatSM;
        private Rigidbody2D _rb;

        public AttackState(SO_State data) : base(data) {
            _attackData = _stateData as SO_AttackState;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _enemy = controller as EnemyController;
            _combatSM = parent as CombatSubSM;
            _rb = _enemy.Rigidbody2D;
        }

        public override void EnterState() {
            base.EnterState();
            Debug.Log("Enter To Attack State");
            Attack();
        }

        public override void UpdateState() {
            base.UpdateState();
        }

        public override void FixedUpdateState() {
            base.FixedUpdateState();
            StopMovement();
        }

        public override void ExitState() {
            base.ExitState();
        }

        private void Attack()
        {
            _enemy.AttackComponent.Attack();
        }
        
        private void StopMovement()
        {
            _rb.linearVelocity = Vector2.Lerp(
                _rb.linearVelocity,
                Vector2.zero,
                _attackData.Acceleration
            );
        }
    }
}