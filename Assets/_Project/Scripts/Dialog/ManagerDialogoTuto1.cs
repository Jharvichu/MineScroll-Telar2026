using Player;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ManagerDialogoTuto1 : MonoBehaviour
{
    [System.Serializable]
    public class DialogueImage
    {
        public Sprite image;

        [TextArea(3, 10)]
        public string textoAMostrar;

        public float duration = 2f;
    }

    [Header("UI References")]
    public GameObject panel;
    public Image imageUI;
    public TextMeshProUGUI textoUI;

    [Header("Configuración Máquina")]
    public float velocidadEscritura = 0.05f;

    [Header("Diálogos en imágenes")]
    public DialogueImage[] dialogueLines;
    private PlayerController player;

    public void IniciarDialogo(PlayerController p)
    {
        player = p;
        panel.SetActive(false);
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.SetBGMParameter("activar_ambiente", 1f);

        foreach (DialogueImage line in dialogueLines)
        {
            yield return StartCoroutine(ShowImage(line));
        }
        if (player != null)
        {
            player.canControl = true;
        }
    }

    IEnumerator ShowImage(DialogueImage line)
    {
        panel.SetActive(true);
        imageUI.sprite = line.image;

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
        }
    }
}