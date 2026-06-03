using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxNyawa = 3;
    public int nyawaSekarang;
    public Image[] hati; // Pastikan di Inspector urutannya: Full, Setengah, Kosong

    void Start()
    {
        nyawaSekarang = maxNyawa;
    }

    public void TerkenaDamaged()
    {
        // 1. Cek dulu apakah masih ada hati yang bisa dimatikan
        // Kita pakai (maxNyawa - nyawaSekarang) biar yang mati mulai dari indeks 0, 1, lalu 2
        int indexHatiYangMati = maxNyawa - nyawaSekarang;

        if (indexHatiYangMati >= 0 && indexHatiYangMati < hati.Length)
        {
            hati[indexHatiYangMati].enabled = false;
        }

        // 2. Baru kurangi hitungan nyawanya
        nyawaSekarang--;

        // 3. Cek kalau sudah habis
        if (nyawaSekarang <= 0)
        {
            Mati();
        }
    }

    void Mati()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}