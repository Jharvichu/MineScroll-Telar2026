using UnityEngine;
using StateMachine;

namespace Enemy {

    [CreateAssetMenu(
        fileName = "SO_EnemyStateMachine", 
        menuName = "Enemy/Enemy State Machine")]
    public class SO_EnemySM : SO_StateMachine {

        [Header("Player BoxCast")]
        public LayerMask PlayerLayer;
        public Vector2 BoxSize;
        public float BoxOffset;
        public float BoxDistance;
        
        public SO_EnemySM(){
            State = new EnemyStateMachine(this);
        }
    }

}