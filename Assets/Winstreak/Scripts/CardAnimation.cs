using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;
using DG.Tweening;

public class CardAnimation : MonoBehaviour
{
    public GameObject starBg;
    public RectTransform cardTransform; // Referensi ke RectTransform kartu
    public Image cardImage; // Referensi ke Image kartu
    public float animationDuration = 0.5f; // Durasi animasi
    public float waitDuration = 0.1f; // Durasi tunggu
    public float shakeDuration = 0.3f; // Durasi getar
    public Color revealColor = Color.white; // Warna setelah reveal
    public TextMeshProUGUI clickText; // Referensi ke teks "click to next"
    public GameObject rewardPanel;
    public CanvasGroup rewardPanelCanvasGroup; // Referensi ke CanvasGroup dari rewardPanel
    private AchievementManager achievementManager;
    private Color originalColor;
    private bool isAnimating;
    private bool isrevealed;

    void Start()
    {
        originalColor = cardImage.color; // Simpan warna asli
        isrevealed = false;
        achievementManager = FindObjectOfType<AchievementManager>();
        StartCoroutine(AnimateStarBg()); // Animasi StarBg berjalan terus-menerus
        // 0. RewardPanel dari Opacity 0 ke 220 secara smooth
        
    }

    public IEnumerator AnimateCard(Achievement badge)
    {
        AudioManager.instance.SetMusic(AudioManager.instance.sfxClips[1]);
        AudioManager.instance.sfxSource.loop = true;
        cardImage.color = Color.black; // Ubah warna kartu menjadi hitam
        isAnimating = true;
        rewardPanel.SetActive(true);
        
        if(!isrevealed) {
            rewardPanelCanvasGroup.alpha = 0f; // Set awal ke 0 (invisible)
            rewardPanelCanvasGroup.DOFade(1f, 0.5f); // 220/255 = 0.86, transisi selama 0.5 detik
            isrevealed = true;
        }
        

        // 1. Kartu muncul dari bawah ke tengah
        cardTransform.localPosition = new Vector3(cardTransform.localPosition.x, -200, cardTransform.localPosition.z);
        float elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            cardTransform.localPosition = new Vector3(cardTransform.localPosition.x, Mathf.Lerp(-200, 0, elapsedTime / animationDuration), cardTransform.localPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }



        // Tunggu 0.1 detik
        yield return new WaitForSeconds(waitDuration);

        elapsedTime = 0f;
        float shakeSpeed = 100f; // Kecepatan getar
        float shakeAmount = 5f; // Jarak getar

        while (!Input.GetMouseButtonDown(0))
        {
            float xOffset = Mathf.Sin(elapsedTime * shakeSpeed) * shakeAmount; // Menghitung offset x
            cardTransform.localPosition = new Vector3(xOffset, 0, cardTransform.localPosition.z);
            elapsedTime += Time.deltaTime;
            clickText.gameObject.SetActive(true);
            clickText.text = "Click to reveal";
            yield return null;
        }

        clickText.gameObject.SetActive(false);

        // Kembali ke posisi semula
        cardTransform.localPosition = new Vector3(0, 0, cardTransform.localPosition.z);

        // 4. Ubah warna kartu
        // stop the sfxClips[1]
        AudioManager.StopMusic();
        AudioManager.instance.sfxSource.loop = false;
        AudioManager.instance.SetSFX(AudioManager.instance.sfxClips[2]);
        cardImage.sprite = badge.card;
        elapsedTime = 0f;
        while (elapsedTime < animationDuration)
        {
            cardImage.color = Color.Lerp(originalColor, revealColor, elapsedTime / animationDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Tampilkan teks "click to next"
        clickText.gameObject.SetActive(true);
        clickText.text = "Click to next";

        // Tunggu input klik
        yield return new WaitUntil(() => Input.GetMouseButtonDown(0));

        // Sembunyikan teks
        clickText.gameObject.SetActive(false);

        // Cek apakah ada kartu lain untuk di-reveal
        if (HasNextCard())
        {
            StartCoroutine(AnimateCard(achievementManager.rewardQueue.Dequeue())); // Jalankan animasi lagi jika ada kartu lain
        }
        else
        {
            isAnimating = false; // Selesai animasi
            rewardPanel.SetActive(false);
            GameManager.instance.QuitGame(); // Kembali ke menu utama
        }
    }

    private IEnumerator AnimateStarBg()
    {
        float rotationSpeed = 90f; // Kecepatan rotasi konstan
        float scaleSpeed = 0.7f;   // Kecepatan scaling konstan
        float scaleAmount = 0.3f;  // Jumlah scaling

        float t = 0f;  // Ini akan melacak waktu untuk keperluan scaling

        while (true) // Loop berjalan terus-menerus
        {
            // Rotasi konstan
            starBg.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);

            // Smooth scaling menggunakan PingPong
            t += Time.deltaTime * scaleSpeed;
            float scaleFactor = Mathf.PingPong(t, 1); // Oscillates between 0 and 1

            // Terapkan perubahan skala jika diperlukan
            yield return null;
        }
    }


    private bool HasNextCard()
    {
        if(achievementManager.rewardQueue.Count >= 1) {
            return true;
        }
        else {
            return false;
        }
        // Logika untuk memeriksa apakah ada kartu lain yang perlu di-reveal
        // Contoh, kembalikan true jika ada kartu lain, false jika tidak
        // Ganti dengan logika yang sesuai
    }
}
