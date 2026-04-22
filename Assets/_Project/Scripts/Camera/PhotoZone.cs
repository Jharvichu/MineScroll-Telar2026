using System;
using Player;
using UnityEngine;

public class PhotoZone : MonoBehaviour
{
    [Header("Configuración de Animación")]
    [SerializeField] private Animator uiAnimator;
    [SerializeField] private string boolParameterName = "TakePhoto";

    [SerializeField] private PlayerController playerController;
    private bool isPlayerInside = false;

    private void Awake()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerController.isPlayerInside = true;
            if (uiAnimator != null)
            {
                uiAnimator.SetBool(boolParameterName, true);
            }
            Debug.Log("Entraste a la zona: Animación Activada");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            playerController.isPlayerInside = false;
            if (uiAnimator != null)
            {
                uiAnimator.SetBool(boolParameterName, false);
            }
            Debug.Log("Saliste de la zona: Animación Desactivada");
        }
    }

    public bool CanTakeStillPhoto()
    {
        return isPlayerInside;
    }
}