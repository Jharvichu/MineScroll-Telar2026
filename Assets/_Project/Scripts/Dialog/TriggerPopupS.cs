using Player;
using UnityEngine;

public class TriggerPopupS : MonoBehaviour
{
    public GameObject popupS;
    public KeyCode tecla = KeyCode.S;

    private bool activo = false;
    private PlayerController controller;

    void Update()
    {
        if (!activo) return;

        if (Input.GetKeyDown(tecla))
        {
            if (popupS != null)
            popupS.SetActive(false);

            activo = false;

            if (controller != null)
                controller.canControl = true;

            Destroy(gameObject);
        }
    }

    // 🔥 LO LLAMAS DESDE FUERA
    public void Activar(PlayerController player)
    {
        controller = player;

        if (controller != null)
            controller.canControl = false;

        popupS.SetActive(true);
        activo = true;
    }

}
