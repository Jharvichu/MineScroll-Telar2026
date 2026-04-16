using UnityEngine;
using StateMachine;
using UnityEditor;

namespace Enemy.States 
{
    public class PatrolState : AState {

        private readonly SO_PatrolState _patrolData;
        private EnemyController _enemy;
        private NormalSubSM _normalSM;
        private Rigidbody2D _rb;
        
        private Transform _currentTarget;
        private bool _isWaiting;
        private float _waitCountdown;

        public PatrolState(SO_State data) : base(data) {
            _patrolData = _stateData as SO_PatrolState;
        }

        public override void Init(StateMachineController controller, AStateMachine parent = null) {
            base.Init(controller, parent);
            _enemy = controller as EnemyController;
            _normalSM = parent as NormalSubSM;
            _rb = _enemy.Rigidbody2D;
        }

        public override void EnterState()
        {
            base.EnterState();
            Debug.Log("Enter To Patrol State");
            _currentTarget = _enemy.PointA;
        }

        public override void UpdateState() {
            base.UpdateState();
            
            if (_isWaiting) 
                UpdateWaitingTimer();
            else 
                CheckDestinationReached();
        }

        public override void FixedUpdateState() {
            base.FixedUpdateState();
            
            if (!_isWaiting)
                Movement();
            else
                StopMovement();
        }

        public override void ExitState() {
            base.ExitState();
        }

        private void Movement()
        {
            Vector3 direction = (_currentTarget.position - _rb.transform.position).normalized;
            
            Vector2 targetVelocity = new Vector2(
                direction.x * _patrolData.Speed,
                direction.y * _patrolData.Speed
            );
            
            _rb.linearVelocity = Vector2.Lerp(
                _rb.linearVelocity,
                targetVelocity,
                _patrolData.Acceleration
            );

            _enemy.FlipSprite(direction.x);
        }
        
        private void StopMovement()
        {
            _rb.linearVelocity = Vector2.zero;
        }
        
        private void UpdateWaitingTimer() 
        {
            _waitCountdown -= Time.deltaTime;
            if (_waitCountdown < 0) 
            {
                _isWaiting = false;
                bool wasHeadingToB = _currentTarget.position == _enemy.PointB.position;
                _currentTarget = wasHeadingToB ? _enemy.PointA : _enemy.PointB;
            }
        }

        private void CheckDestinationReached()
        {
            float distance = Vector2.Distance(_rb.position, (Vector2)_currentTarget.position);
            
            if (distance < _patrolData.ArrivalThreshold) 
            {
                _isWaiting = true;
                _waitCountdown = _patrolData.WaitTime;
                _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);
            }
        }
    }
}