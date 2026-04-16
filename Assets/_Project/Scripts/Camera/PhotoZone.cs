using UnityEngine;

public class PhotoZone : MonoBehaviour
{
    [Header("Configuración de Animación")]
    [SerializeField] private Animator uiAnimator;
    [SerializeField] private string boolParameterName = "isNear";

    private bool isPlayerInside = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isPlayerInside = true;
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
            isPlayerInside = false;
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