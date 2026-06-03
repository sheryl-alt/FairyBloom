using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    // Fungsi untuk tombol START
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    // Fungsi untuk tombol di Level Select
    public void KeLevel1() { SceneManager.LoadScene("Level1"); }
    public void KeLevel2() { SceneManager.LoadScene("Level2"); }
    public void KeLevel3() { SceneManager.LoadScene("Level3"); }

    // --- TAMBAHKAN INI UNTUK VICTORY PANEL ---

    // Fungsi untuk tombol REPLAY
    public void ReplayLevel()
    {
        Time.timeScale = 1f; // Pastikan waktu kembali normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Fungsi untuk tombol NEXT LEVEL
    public void NextLevel()
    {
        Time.timeScale = 1f; // Pastikan waktu kembali normal
        // Ini akan otomatis pindah ke urutan scene berikutnya di Build Settings
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // --- SELESAI TAMBAHAN ---

    // Fungsi untuk tombol Back (Panah)
    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    // Fungsi untuk tombol QUIT
    public void QuitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}