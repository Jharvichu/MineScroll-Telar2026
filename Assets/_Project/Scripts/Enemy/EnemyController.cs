using UnityEngine;
using StateMachine;

namespace Enemy
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class EnemyController : StateMachineController {

        public Rigidbody2D Rigidbody2D { private set; get; }

        public IAttackComponent AttackComponent { get; private set; }
        
        public Transform PointA;
        public Transform PointB;
        
        public float FacingDirection => transform.localScale.x > 0 ? 1f : -1f;

        protected override void Awake() {
            Rigidbody2D = GetComponent<Rigidbody2D>();
            AttackComponent = GetComponent<IAttackComponent>();
            base.Awake();
        }

        public void FlipSprite(float directionX) {
            Vector3 scale = transform.localScale;

            if (directionX < 0 && scale.x > 0 || directionX > 0 && scale.x < 0) {
                scale.x *= -1f;
                transform.localScale = scale;
            }
        }

        void OnTriggerEnter2D(Collider2D collision) {

        }

        public void Restart() {
            base.Awake();
            ResetMachine();
        }

    }

}