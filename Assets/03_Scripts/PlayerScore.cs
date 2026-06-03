using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreText;
    private Vector3 currentCheckpoint;

    void Start()
    {
        currentCheckpoint = transform.position; // Set posisi awal sebagai checkpoint pertama
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        score += value;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
    }

    // UNTUK CHECKPOINT & ITEM
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Item"))
        {
            AddScore(10);
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform.position;
            Debug.Log("Checkpoint tersimpan!");
        }
    }

    // UNTUK MATI KENA BADAN MUSUH
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        transform.position = currentCheckpoint;
        // Reset kecepatan biar pas muncul gak meluncur
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;
    }
}