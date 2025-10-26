using UnityEngine;


public class LightMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hızı
    public float changeDirectionInterval = 2f; // Yön değiştirme aralığı (saniye)
    private Rigidbody rb;
    private Vector3 randomDirection;

    void Start()
    {
        // Rigidbody bileşenini al
        rb = GetComponent<Rigidbody>();

        // İlk rastgele yönü belirle
        ChangeDirection();

        // Düzenli aralıklarla yön değiştir
        InvokeRepeating("ChangeDirection", 0, changeDirectionInterval);
    }

    void FixedUpdate()
    {
        // Rastgele yöne doğru hareket et
        rb.MovePosition(transform.position + randomDirection * moveSpeed * Time.fixedDeltaTime);
    }

    void ChangeDirection()
    {
        // Rastgele bir yön belirle
        randomDirection = new Vector3(
            Random.Range(-1f, 1f),
            0, // Y ekseninde hareket etmesin
            Random.Range(-1f, 1f)
        ).normalized; // Yönü normalize et
    }

    void OnCollisionEnter(Collision collision)
    {
        // Duvarlarla çarpışırsa yön değiştir
        if (collision.gameObject.CompareTag("Wall"))
        {
            ChangeDirection();
        }
    }
}
