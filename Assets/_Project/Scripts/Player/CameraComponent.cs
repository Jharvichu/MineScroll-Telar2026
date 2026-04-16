using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    [Header("Configuración de Cámara")]
    [SerializeField] private float cooldownTime = 1.5f;
    private float nextPhotoTime = 0f;
    
    public Animator animator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && Time.time >= nextPhotoTime)
        {
            TomarFoto();

            nextPhotoTime = Time.time + cooldownTime;
        }
    }

    private void TomarFoto()
    {
        //PhotoManager.Instance.AddPhoto();
        animator.SetTrigger("TakePhoto");
        Debug.Log("¡Foto capturada!");
    }
}