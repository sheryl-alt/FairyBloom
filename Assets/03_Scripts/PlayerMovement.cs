using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody2D rb;
    private Animator anim;
    private float moveInput;

    // Variabel untuk menyimpan ukuran asli kamu
    private Vector3 initialScale;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        // Mencatat ukuran peri kamu pas pertama kali di-Run
        initialScale = transform.localScale;
    }

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y);

        if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.linearVelocity.y) < 0.01f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }

        if (anim != null)
        {
            anim.SetFloat("Speed", Mathf.Abs(moveInput));
        }

        // --- BAGIAN FLIP ---
        if (moveInput > 0)
        {
            transform.localScale = new Vector3(initialScale.x, initialScale.y, initialScale.z);
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-initialScale.x, initialScale.y, initialScale.z);
        }
    }

    // --- LOGIKA TABRAKAN (DIATUR BIAR PAS) ---
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 1. JIKA MENGINJAK KEPALA (Tag: Head)
        if (collision.gameObject.CompareTag("Head"))
        {
            // Musuh mati (menghapus induk si Head/si Siputnya)
            Destroy(collision.transform.parent.gameObject);

            // EFEK PANTUL: Angka 3f ini biar nggak ketinggian! 
            // (Kalau masih ketinggian, ganti ke 2f)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 2f);

            Debug.Log("Injek Kepala: Musuh Mati, Lompat Sedang.");
        }

        // 2. JIKA NABRAK BADAN (Tag: Enemy)
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            PlayerHealth health = GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TerkenaDamaged(); // Kurangi Nyawa
            }

            // EFEK MENTAL: Biar nggak nempel terus sama musuh
            if (rb != null)
            {
                float arahPantul = (transform.position.x - collision.transform.position.x > 0) ? 1 : -1;
                rb.linearVelocity = new Vector2(arahPantul * 4f, 2f);
            }

            Debug.Log("Nabrak Badan: Nyawa Berkurang!");
        }
    }
}