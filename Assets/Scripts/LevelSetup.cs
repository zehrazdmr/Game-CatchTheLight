using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSetup : MonoBehaviour
{
    public GameObject[] lights; // Sahnedeki tüm ışıklar

    void Start()
    {
        // Sahne yüklendiğinde bu scriptin tetiklenmesi için olayı bağla
        SceneManager.sceneLoaded += OnSceneLoaded;
        SetupLights();
    }

    void SetupLights()
    {

        lights = GameObject.FindGameObjectsWithTag("Light");
        GameManager.Instance.SetTotalLights(lights.Length);
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yeni sahne yüklendiğinde tekrar çalış
        // Işıkları sıfırla ve yenilerini bul
        GameManager.Instance.SetTotalLights(0);
        SetupLights();
    }

    void OnDestroy()
    {
        // SceneManager'dan olay dinlemesini kaldır
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
