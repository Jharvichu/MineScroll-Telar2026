using UnityEngine;
using StateMachine;

namespace Player {
	
    [CreateAssetMenu(
        fileName = "SO_PhotoModeSubSM", 
        menuName = "Player/Photo Mode Sub-State Machine")]
    public class SO_PhotoModeSubSM : SO_StateMachine {
        
        public SO_PhotoModeSubSM(){
            State = new PhotoModeSubSM(this);
            NodeType = PlayerState.PhotoMode;
        }
    }

}