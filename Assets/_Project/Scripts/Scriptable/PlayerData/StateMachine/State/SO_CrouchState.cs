using UnityEngine;
using StateMachine;

namespace Player.States{
    [CreateAssetMenu(
        fileName = "SO_CrouchState", 
        menuName = "Player/States/Crouch State",
        order = 0)]
    public class SO_CrouchState : SO_State {

        public float Speed;
        public float VerticalSpeedMultiplier;
        public float Acceleration;
        
        public SO_CrouchState()
        {
            State = new CrouchState(this);
            NodeType = MovementState.Crouch;
        }

    }
}