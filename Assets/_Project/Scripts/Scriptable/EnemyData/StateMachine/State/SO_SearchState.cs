using UnityEngine;
using StateMachine;

namespace Enemy.States{
    [CreateAssetMenu(
        fileName = "SO_SearchState", 
        menuName = "Enemy/States/Search State",
        order = 0)]
    public class SO_SearchState : SO_State {

        public float Speed;
        public float VerticalSpeedMultiplier;
        public float Acceleration;
        
        [Header("Player BoxCast")]
        public LayerMask PlayerLayer;
        public Vector2 BoxSize;
        public float BoxOffset;
        public float BoxDistance;
        
        public SO_SearchState()
        {
            State = new SearchState(this);
            NodeType = NormalState.Search;
        }

    }
}