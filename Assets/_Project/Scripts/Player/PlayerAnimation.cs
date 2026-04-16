using UnityEngine;

namespace Player
{
    public class PlayerAnimation : MonoBehaviour
    {
        public Animator Animation;

        private PlayerController Player;

        private void Awake()
        {
            Player = GetComponent<PlayerController>();
        }
        
        private void Update()
        {
            SetVelocity();
            SetCrouching();
        }

        public void SetVelocity()
        {
            float velocity = Player.Rigidbody2D.linearVelocity.magnitude;
            Animation.SetFloat("Magnitude", velocity);
        }
        
        public void SetCrouching()
        {
            Animation.SetBool("IsCrouching", (MovementState)Player.GetCurrentState() == MovementState.Crouch? true : false);
        }
        
    }
}