using UnityEngine;

public class PhotoManager : MonoBehaviour
{
    public static PhotoManager Instance { get; private set; }

    [Header("Datos de la Cámara")]
    [SerializeField] private int photoCount = 0;

    private int photoCountTemporary;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        
        transform.SetParent(null); 
        DontDestroyOnLoad(gameObject);
        
        Debug.Log("<color=cyan>PhotoManager:</color> Instancia persistente inicializada.");
    }
    
    public void AddPhotoTemporary(int photoNum)
    {
        photoCountTemporary += photoNum;
        Debug.Log($"<color=green>Foto capturada!</color> Total: {photoCount}");
    }

    public void AddPhoto()
    {
        photoCount = photoCountTemporary;
        ResetPhoto();
    }

    public void ResetPhoto()
    {
        photoCountTemporary = 0;
    }
    
    public int GetPhotoCountTemporary()
    {
        return photoCountTemporary;
    }
    
    public int GetPhotoCount()
    {
        return photoCount;
    }
}