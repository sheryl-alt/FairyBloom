using UnityEngine;

public class CheckpointControl : MonoBehaviour
{
    private bool isActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            isActivated = true;

            // Update posisi ke FallingZone
            FallingZone.UpdateCheckpoint(transform.position);

            Debug.Log("Checkpoint Berhasil!");

            // Ganti warna jadi hijau
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}