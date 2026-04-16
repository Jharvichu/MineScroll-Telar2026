using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public sealed class HUDSlotManager : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] private float updateInterval = 5f;


    private List<Image> slotImages = new List<Image>();
    private float timer;

    private void Awake()
    {
        InitializeSlots();
    }

    private void InitializeSlots()
    {
        slotImages.Clear();

        foreach (Transform child in transform)
        {
            if (child.name.ToLower().Contains("camera")) continue;

            Image img = child.GetComponent<Image>();
            if (img != null)
            {
                slotImages.Add(img);
            }
        }
        
        Debug.Log($"<color=green>HUD Initialized:</color> {slotImages.Count} slots detectados.");
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer >= updateInterval)
        {
            UpdateSlotsAlpha();
            timer = 0f;
        }
    }

    private void UpdateSlotsAlpha()
    {
        if (PhotoManager.Instance == null) 
        {
            return;
        }

        // Accedemos directamente a la instancia persistente
        int currentPhotos = PhotoManager.Instance.GetPhotoCount();

        for (int i = 0; i < slotImages.Count; i++)
        {
            if (slotImages[i] == null) continue;
            float targetAlpha = (i < currentPhotos) ? 1f : 0f; 
            ApplyAlpha(slotImages[i], targetAlpha);
        }
    }

    private void ApplyAlpha(Image img, float alpha)
    {
        Color color = img.color;
        color.a = alpha;
        img.color = color;
    }
}