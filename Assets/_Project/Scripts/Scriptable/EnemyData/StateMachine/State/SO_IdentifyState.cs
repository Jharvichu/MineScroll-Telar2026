using UnityEngine;
using StateMachine;

namespace Enemy.States{
    [CreateAssetMenu(
        fileName = "SO_IdentifyState", 
        menuName = "Enemy/States/Identify State",
        order = 0)]
    public class SO_IdentifyState : SO_State
    {
        public float SwitchDirectionTime;
        public float TotalIdentifyTime;
        
        public SO_IdentifyState()
        {
            State = new IdentifyState(this);
            NodeType = NormalState.Identify;
        }

    }
}