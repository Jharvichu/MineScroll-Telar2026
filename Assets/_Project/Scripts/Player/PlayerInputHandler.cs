using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInputHandler: MonoBehaviour
    {
        public Vector2 MoveInput { get; private set; }
        public bool TakePhotoPressed { get; private set; }
        public bool CrouchPressed { get; private set; }

        private void LateUpdate()
        {
            CrouchPressed = false;
            TakePhotoPressed = false;
        }
        
        public void OnMove(InputAction.CallbackContext context)
        {
            MoveInput = context.ReadValue<Vector2>();
        }

        public void OnTakePhoto(InputAction.CallbackContext context)
        {
            if (context.started)
                TakePhotoPressed = true;
        }

        public void OnCrouch(InputAction.CallbackContext context)
        {
            if (context.started)
                CrouchPressed = true;
        }
        
    }
}