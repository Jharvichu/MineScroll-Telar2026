using UnityEngine;
using StateMachine;

namespace Enemy {
	
    [CreateAssetMenu(
        fileName = "SO_NormalSubSM", 
        menuName = "Enemy/Normal Sub-State Machine")]
    public class SO_NormalSubSM : SO_StateMachine {
        
        [Header("Player BoxCast")]
        public LayerMask PlayerLayer;
        public Vector2 BoxSize;
        public float BoxOffset;
        public float BoxDistance;
        
        public SO_NormalSubSM(){
            State = new NormalSubSM(this);
            NodeType = EnemyState.Normal;
        }
    }

}