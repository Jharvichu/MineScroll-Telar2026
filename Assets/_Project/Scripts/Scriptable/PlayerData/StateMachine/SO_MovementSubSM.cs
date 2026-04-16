using UnityEngine;
using StateMachine;

namespace Player {
	
    [CreateAssetMenu(
        fileName = "SO_MovementSubSM", 
        menuName = "Player/Movement Sub-State Machine")]
    public class SO_MovementSubSM : SO_StateMachine {
        
        public SO_MovementSubSM(){
            State = new MovementSubSM(this);
            NodeType = PlayerState.Movement;
        }
    }

}