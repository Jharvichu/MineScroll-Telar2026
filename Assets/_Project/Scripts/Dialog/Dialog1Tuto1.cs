using Player;
using UnityEngine;

public class DIalog1Tuto1 : MonoBehaviour
{
    public ManagerDialogoTuto1 dialogo;
    private bool activado = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character") && !activado)
        {
            activado = true;

            PlayerController player = other.GetComponent<PlayerController>();

            if (player != null)
            {
                player.canControl = false;
            }

            if (dialogo != null)
            {
                dialogo.IniciarDialogo(player); 
            }

            Destroy(gameObject);
        }
    }
}