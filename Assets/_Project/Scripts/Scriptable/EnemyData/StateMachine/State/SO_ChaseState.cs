using UnityEngine;
using StateMachine;

namespace Enemy.States{
    [CreateAssetMenu(
        fileName = "SO_ChaseState", 
        menuName = "Enemy/States/Chase State",
        order = 0)]
    public class SO_ChaseState : SO_State {

        public float Speed;
        public float VerticalSpeedMultiplier;
        public float Acceleration;
        
        [Header("Player BoxCast")]
        public LayerMask PlayerLayer;
        public Vector2 BoxSize;
        public float BoxOffset;
        public float BoxDistance;
        
        public SO_ChaseState()
        {
            State = new ChaseState(this);
            NodeType = CombatState.Chase;
        }
        
    }
}