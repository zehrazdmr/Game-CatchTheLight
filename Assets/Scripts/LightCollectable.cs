using UnityEngine;


public class LightCollectable : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Işık toplandı!");
            GameManager.Instance.CollectLight();
            Destroy(gameObject); // Işığı sahneden kaldır
        }
    }
}
