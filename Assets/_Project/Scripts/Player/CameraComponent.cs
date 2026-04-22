using System;
using Player;
using UnityEngine;

public class CameraComponent : MonoBehaviour
{
    [Header("Configuración de Cámara")]
    [SerializeField] private float cooldownTime = 1.5f;
    private float nextPhotoTime = 0f;
    
    int photoCount = 1;
    
    public Animator animator;
    
    PlayerController playerController;

    public void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

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
        if (playerController.isPlayerInside)
        {
            PhotoManager.Instance.AddPhoto(photoCount);
            photoCount = 0;
            Debug.Log(PhotoManager.Instance.GetPhotoCount());
        }
        animator.SetTrigger("TakePhoto");
        Debug.Log("¡Foto capturada!");
    }
}