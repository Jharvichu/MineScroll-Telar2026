using UnityEngine;

public class PhotoManager : MonoBehaviour
{
    public static PhotoManager Instance { get; private set; }

    [Header("Datos de la Cámara")]
    [SerializeField] private int photoCount = 0;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    public void AddPhoto()
    {
        photoCount++;
        Debug.Log("Total de fotos capturadas: " + photoCount);
    }
    
    public int GetPhotoCount()
    {
        return photoCount;
    }
}
