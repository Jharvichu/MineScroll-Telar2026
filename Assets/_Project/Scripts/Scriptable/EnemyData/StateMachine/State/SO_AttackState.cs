using UnityEngine;
using StateMachine;

namespace Enemy.States{
    [CreateAssetMenu(
        fileName = "SO_AttackState", 
        menuName = "Enemy/States/Attack State",
        order = 0)]
    public class SO_AttackState : SO_State
    {
        public float Acceleration;
        
        public SO_AttackState()
        {
            State = new AttackState(this);
            NodeType = CombatState.Attack;
        }

    }
}