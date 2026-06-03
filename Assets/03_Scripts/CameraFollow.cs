using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float fixedY = 0.5f;
    public float smoothSpeed = 0.125f;

    [Header("Batas Kamera (Agar tidak biru)")]
    public float minX = 0f; // Batas paling kiri
    public float maxX = 100f; // Batas paling kanan (atur sesuka hati)

    void LateUpdate()
    {
        if (player != null)
        {
            // 1. Tentukan posisi X player
            float targetX = player.position.x;

            // 2. KUNCI posisi X agar tidak kurang dari minX dan tidak lebih dari maxX
            // Math.Clamp artinya: "Jangan biarkan angka keluar dari batas ini"
            targetX = Mathf.Clamp(targetX, minX, maxX);

            // 3. Buat posisi tujuan baru dengan X yang sudah dikunci
            Vector3 desiredPosition = new Vector3(targetX, fixedY, -10f);

            // 4. Gerakan kamera secara halus
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            transform.position = smoothedPosition;
        }
    }
}