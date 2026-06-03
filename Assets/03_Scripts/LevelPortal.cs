using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPortal : MonoBehaviour
{
    public int minScoreToWin = 60; // Skor minimal sesuai maumu
    public string nextSceneName;   // Ketik "Level2" di Inspector

    // Tambahan untuk Victory Panel
    public GameObject victoryPanel;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Cek apakah yang nabrak itu Player
        if (other.CompareTag("Player"))
        {
            // Ambil komponen PlayerScore dari si Player
            PlayerScore scriptSkor = other.GetComponent<PlayerScore>();

            if (scriptSkor != null)
            {
                if (scriptSkor.score >= minScoreToWin)
                {
                    Debug.Log("Skor mantap! Munculkan Panel.");

                    // Logika baru: Munculkan panel dan pause game
                    if (victoryPanel != null)
                    {
                        victoryPanel.SetActive(true);
                        Time.timeScale = 0f;
                    }
                    else
                    {
                        // Kalau tidak ada panel, langsung pindah scene seperti biasa
                        SceneManager.LoadScene(nextSceneName);
                    }
                }
                else
                {
                    Debug.Log("Skor kurang! Kamu baru punya: " + scriptSkor.score);
                }
            }
        }
    }
}