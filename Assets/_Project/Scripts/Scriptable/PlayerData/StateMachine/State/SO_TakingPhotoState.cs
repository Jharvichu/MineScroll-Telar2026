using UnityEngine;
using StateMachine;

namespace Player.States{
    [CreateAssetMenu(
        fileName = "SO_TakingPhotoState", 
        menuName = "Player/States/Taking Photo State",
        order = 0)]
    public class SO_TakingPhotoState : SO_State {

        public SO_TakingPhotoState()
        {
            State = new TakingPhotoState(this);
            NodeType = PhotoState.TakingPhoto;
        }

    }
}