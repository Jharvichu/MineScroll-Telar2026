using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hipervinculo : MonoBehaviour, IPointerClickHandler
{
    public TMP_Text text;

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(text, eventData.position, null);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = text.textInfo.linkInfo[linkIndex];
            Application.OpenURL(linkInfo.GetLinkID());
        }
    }
}