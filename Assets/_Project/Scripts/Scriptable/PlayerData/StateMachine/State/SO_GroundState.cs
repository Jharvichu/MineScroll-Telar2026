using UnityEngine;
using StateMachine;

namespace Player.States{
    [CreateAssetMenu(
        fileName = "SO_GroundState", 
        menuName = "Player/States/Ground State",
        order = 0)]
    public class SO_GroundState : SO_State
    {
    
        public float Speed;
        public float VerticalSpeedMultiplier;
        public float Acceleration;
        
        public SO_GroundState()
        {
            State = new GroundState(this);
            NodeType = MovementState.Ground;
        }

    }
}