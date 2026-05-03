using Player;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ManagerDialogoCielo : MonoBehaviour
{
    public bool dialogoTerminado = false;
    [System.Serializable]
    public class DialogueLine
    {

        [TextArea(3, 10)]
        public string textoAMostrar;

        public float duration = 2f;
    }

    [Header("UI References")]
    public GameObject panel;
    public TextMeshProUGUI textoUI;

    [Header("Configuración Máquina")]
    public float velocidadEscritura = 0.05f;

    [Header("Líneas de diálogo")]
    public DialogueLine[] dialogueLines;

    private PlayerController player;

    public void IniciarDialogo(PlayerController p)
    {
        player = p;

        dialogoTerminado = false; // 🔥 reset

        if (player != null)
            player.canControl = false;

        panel.SetActive(false);
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()

    {
        if (player != null)
        {
            player.canControl = false;
        }

        if (AudioManager.Instance != null)
            AudioManager.Instance.SetBGMParameter("activar_ambiente", 1f);

        foreach (DialogueLine line in dialogueLines)
        {
            yield return StartCoroutine(ShowText(line));
        }

        if (player != null)
        {
            player.canControl = true;
        }

        // 🔥 AQUÍ VA
        dialogoTerminado = true;
    }

           IEnumerator ShowText(DialogueLine line)
        {
        panel.SetActive(true);
       

        textoUI.text = "";


        foreach (char letra in line.textoAMostrar.ToCharArray())
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidadEscritura);
        }

        yield return new WaitForSeconds(line.duration);

        panel.SetActive(false);
    }
    
    public void TerminarDialogo()
    {
        if (player != null)
        {
            player.canControl = true;
            dialogoTerminado = true;
        }
    }
}
