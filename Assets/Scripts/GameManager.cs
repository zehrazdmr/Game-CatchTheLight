using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton

    private int totalLights; // Sahnedeki toplam ışık sayısı
    private int collectedLights; // Toplanan ışık sayısı
   

    void Awake()
    {
        // Singleton setup
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Oyun boyunca GameManager'ı korur
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetTotalLights(int count)
    {
        totalLights = count;
        collectedLights = 0; // Yeni sahne için sıfırla
        Debug.Log($"Yeni sahne yüklendi: {totalLights} ışık bulunuyor.");
        AndroidToast.ShowToast($"Bu aşamada toplamanız gereken ışık sayısı: {totalLights}" );

    }
       

    public void CollectLight()
    {
        collectedLights++;
        Debug.Log($"Toplanan ışık: {collectedLights}/{totalLights}");

        if (collectedLights >= totalLights && totalLights > 0) // Geçerli sahnede tüm ışıklar toplandı
        {
            Debug.Log("Tebrikler tüm ışıklar toplandı.");
            Debug.Log("Yeni levele geçiliyor");
            AndroidToast.ShowToast($"Tüm ışıklar toplandı.Yeni levele geçiliyor. " );


            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        // Mevcut sahne indeksini al
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Sıradaki sahne indeksini hesapla
        int nextSceneIndex = currentSceneIndex + 1;

        // Eğer sahne sırası son sahneyi aşmıyorsa, sıradaki sahneye geç
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.Log("Tüm sahneler tamamlandı. Oyun sona erdi.");
            AndroidToast.ShowToast("Tebrikler oyunu bitiridiniz." );

        
        }
    }
    
}




