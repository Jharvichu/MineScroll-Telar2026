using UnityEngine;
using StateMachine;

namespace Enemy.States{
    [CreateAssetMenu(
        fileName = "SO_PatrolState", 
        menuName = "Enemy/States/Patrol State",
        order = 0)]
    public class SO_PatrolState : SO_State {

        public float Speed;
        public float Acceleration;
        public float WaitTime;
        public float ArrivalThreshold;
        
        public SO_PatrolState()
        {
            State = new PatrolState(this);
            NodeType = NormalState.Patrol;
        }

    }
}