using Player;
using System.Collections;
using UnityEngine;

public class DIalog1Tuto21 : MonoBehaviour
{
    public ManagerDialogoTuto21 dialogo;
    private bool activado = false;

    public bool DialogoTerminado { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Character") && !activado)
        {
            Activar(other.GetComponent<PlayerController>());
        }
    }

    // 🔥 NUEVO: activación manual desde cinemática
    public void Activar(PlayerController player)
    {
        if (activado) return;

        activado = true;
        DialogoTerminado = false;

        if (player != null)
        {
            player.canControl = false;
        }

        if (dialogo != null)
        {
            dialogo.IniciarDialogo(player);
        }

        StartCoroutine(EsperarFinDialogo());
    }

    private IEnumerator EsperarFinDialogo()
    {
        yield return new WaitUntil(() => dialogo.dialogoTerminado == true);

        // 🔓 devolver control al jugador
        PlayerController player = Object.FindFirstObjectByType<PlayerController>();
        if (player != null)
        {
            player.canControl = true;
        }

        DialogoTerminado = true;
    }
}