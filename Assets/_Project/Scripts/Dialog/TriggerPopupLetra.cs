using UnityEngine;

public class TriggerPopupLetra : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject triggerSalidaPrefab;
    private bool isActive;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isActive = true;
            Debug.Log(isActive);
            triggerSalidaPrefab.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            isActive = false;
            Debug.Log(isActive);
            triggerSalidaPrefab.SetActive(false);
        }
    }
}
