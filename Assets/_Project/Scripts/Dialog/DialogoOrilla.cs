using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogoOrilla : MonoBehaviour
{
    [System.Serializable]
    public class DialogueImage
    {
        public Sprite image;
        [TextArea(3, 10)] // Esto crea un cuadro grande en el Inspector
        public string textoAMostrar;
        public float duration = 2f;
        public bool isCharacterA;
    }

    public OrillaaTuto cambioEscena;

    [Header("UI References")]
    public GameObject panelA;
    public GameObject panelB;
    public Image imageA;
    public Image imageB;
    // Nuevas referencias para el texto
    public TextMeshProUGUI tmpA;
    public TextMeshProUGUI tmpB;

    [Header("Configuración Máquina")]
    public float velocidadEscritura = 0.05f;

    [Header("Diálogos en imágenes")]
    public DialogueImage[] dialogueLines;

    public void IniciarDialogoOrilla()
    {
        panelA.SetActive(false);
        panelB.SetActive(false);
        StartCoroutine(PlayDialogue());
    }

    IEnumerator PlayDialogue()
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.SetBGMParameter("activar_ambiente", 1f);

        foreach (DialogueImage line in dialogueLines)
        {
            if (line.isCharacterA)
                yield return StartCoroutine(ShowImage(panelA, imageA, tmpA, line));
            else
                yield return StartCoroutine(ShowImage(panelB, imageB, tmpB, line));
        }

        cambioEscena.IrATutorial();
    }

    IEnumerator ShowImage(GameObject panel, Image imageUI, TextMeshProUGUI textoUI, DialogueImage line)
    {
        panelA.SetActive(false);
        panelB.SetActive(false);

        panel.SetActive(true);
        imageUI.sprite = line.image;

        // Lógica de máquina de escribir
        textoUI.text = "";
        foreach (char letra in line.textoAMostrar.ToCharArray())
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidadEscritura);
        }

        yield return new WaitForSeconds(line.duration);
        panel.SetActive(false);
    }
}