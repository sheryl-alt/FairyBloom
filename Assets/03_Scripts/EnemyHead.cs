using UnityEngine;

public class EnemyHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            
            PlayerScore ps = collision.GetComponent<PlayerScore>();
            if (ps != null) ps.AddScore(5);

            
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Reset jatuh
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, 5f); // Lompat
            }

            
            Destroy(transform.parent.gameObject);
        }
    }
}