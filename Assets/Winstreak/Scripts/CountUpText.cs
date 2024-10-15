using System.Collections;
using UnityEngine;
using TMPro;

public class ScoreCounter : MonoBehaviour
{
    // Referensi ke komponen Text di Unity
    // public Text scoreText; // Jika menggunakan Text UI biasa

    // Jika menggunakan TextMeshPro, uncomment yang di bawah ini
    // public TMP_Text scoreText;
    public TextMeshProUGUI scoreText;

    // Skor awal
    private static int currentScore;

    // Waktu animasi (1.5 detik)
    private readonly float countUpDuration = 1f;
    public AudioManager audioManager;

    private void Start()
    {
        // Mulai coroutine untuk menambah 1 skor
        scoreText.text = currentScore.ToString();
        Debug.Log($"your score: {currentScore}");
        StartCoroutine(CountUpScore());
    }

    IEnumerator CountUpScore()
    {
        float elapsedTime = 0f;
        
        int targetScore = GameManager.instance != null ? GameManager.instance.playerScore : currentScore + 100;
        
        if(!GameManager.instance.isWin) {
            GameManager.instance.LoseMinigame();
            GameManager.instance.QuitGame();
        }else {
            audioManager.SetSFX(audioManager.sfxClips[0]);
            while (elapsedTime < countUpDuration)
            {
                elapsedTime += Time.deltaTime;
                

                // Interpolasi nilai score dari startScore ke targetScore
                int newScore = Mathf.FloorToInt(Mathf.Lerp(currentScore, targetScore, elapsedTime / countUpDuration));

                // Update teks score
                scoreText.text = newScore.ToString();
                

                // Tunggu frame berikutnya
                yield return null;
            }
            
            scoreText.text = targetScore.ToString();
            currentScore = targetScore;
            Debug.Log($"[CountUpScore] Updated currentScore: {currentScore}");

            yield return new WaitForSeconds(0.25f);
            GameManager.instance.GetMinigames();
        }
    }
}
