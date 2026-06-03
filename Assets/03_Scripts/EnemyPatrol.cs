using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;
    public bool movingRight = true;
    public bool isFlying = false; // CENTANG ini di Inspector kalau buat Bat/Bee

    [Header("Detection Settings")]
    public Transform groundCheck;
    public float detectionDistance = 0.5f;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private float lastTurnTime;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // JURUS ANTI JATUH:
        // Jika isFlying dicentang, gravitasi jadi 0. Jika tidak, jadi 1.
        rb.gravityScale = isFlying ? 0f : 1f;

        rb.freezeRotation = true;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    void FixedUpdate()
    {
        float currentSpeed = movingRight ? speed : -speed;

        // Jika terbang, kita kunci posisi Y-nya supaya nggak turun-turun
        if (isFlying)
        {
            rb.linearVelocity = new Vector2(currentSpeed, 0);
        }
        else
        {
            rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);
        }

        // Atur Flip Arah
        if (movingRight)
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);
        else
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, 1);

        // Deteksi Jurang (Hanya untuk yang TIDAK terbang)
        if (!isFlying && groundCheck != null)
        {
            RaycastHit2D groundInfo = Physics2D.Raycast(groundCheck.position, Vector2.down, detectionDistance, groundLayer);
            if (groundInfo.collider == false && Time.time > lastTurnTime + 0.5f)
            {
                TurnAround();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("InvisibleWall") && Time.time > lastTurnTime + 0.2f)
        {
            TurnAround();
        }
    }

    void TurnAround()
    {
        movingRight = !movingRight;
        lastTurnTime = Time.time;
        Debug.Log(gameObject.name + " Balik arah!");
    }

    private void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(groundCheck.position, groundCheck.position + Vector3.down * detectionDistance);
        }
    }
}