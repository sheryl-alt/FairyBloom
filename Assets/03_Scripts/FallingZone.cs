using UnityEngine;

public class FallingZone : MonoBehaviour
{
    // Titik awal banget kalau belum kena checkpoint apa-apa
    public Transform defaultSpawnPoint;

    // Variabel statis biar posisinya tersimpan meski jatuh berkali-kali
    private static Vector3 lastCheckpointPos;

    void Start()
    {
        // Saat level dimulai, kita reset ke posisi awal map tersebut
        if (defaultSpawnPoint != null)
        {
            lastCheckpointPos = defaultSpawnPoint.position;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Jika yang jatuh adalah Player
        if (collision.CompareTag("Player"))
        {
            // Balikin posisi si Peri ke checkpoint terakhir
            collision.transform.position = lastCheckpointPos;

            // Tambahan biar Peri gak "meluncur" pas muncul lagi (reset gravitasi)
            Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
            }
        }
    }

    // Fungsi ini yang dipanggil oleh script CheckpointControl
    public static void UpdateCheckpoint(Vector3 newPos)
    {
        lastCheckpointPos = newPos;
    }
}