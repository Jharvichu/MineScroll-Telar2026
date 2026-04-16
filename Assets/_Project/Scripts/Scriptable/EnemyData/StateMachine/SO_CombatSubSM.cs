using UnityEngine;
using StateMachine;

namespace Enemy {
	
    [CreateAssetMenu(
        fileName = "SO_CombatSubSM", 
        menuName = "Enemy/Combat Sub-State Machine")]
    public class SO_CombatSubSM : SO_StateMachine {
        
        public LayerMask PlayerLayer;
        
        [Header("Vision")]
        public Vector2 VisionBoxSize;
        public float VisionOffset;
        public float VisionDistance;

        [Header("Attack")]
        public Vector2 AttackBoxSize;
        public float AttackOffset;
        public float AttackDistance;
        
        public SO_CombatSubSM(){
            State = new CombatSubSM(this);
            NodeType = EnemyState.Combat;
        }
    }

}