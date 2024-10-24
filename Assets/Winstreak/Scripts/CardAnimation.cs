using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

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
    private AchievementManager achievementManager;
    private Color originalColor;
    private bool isAnimating;

    void Start()
    {
        originalColor = cardImage.color; // Simpan warna asli
        achievementManager = FindObjectOfType<AchievementManager>();
    }

    public IEnumerator AnimateCard(Achievement badge)
    {
        AudioManager.instance.SetSFX(AudioManager.instance.sfxClips[1]);
        StartCoroutine(AnimateStarBg());
        cardImage.color = Color.black; // Ubah warna kartu menjadi hitam
        isAnimating = true;
        rewardPanel.SetActive(true);

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

        while (elapsedTime < shakeDuration)
        {
            float xOffset = Mathf.Sin(elapsedTime * shakeSpeed) * shakeAmount; // Menghitung offset x
            cardTransform.localPosition = new Vector3(xOffset, 0, cardTransform.localPosition.z);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Kembali ke posisi semula
        cardTransform.localPosition = new Vector3(0, 0, cardTransform.localPosition.z);

        // 4. Ubah warna kartu
        // stop the sfxClips[1]
        AudioManager.StopSfx();
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
        float rotationSpeed = 90f;
        float scaleSpeed = 0.7f;
        float scaleAmount = 0.3f;

        Vector3 originalScale = starBg.transform.localScale;
        Vector3 targetScale = new Vector3(originalScale.x - scaleAmount, originalScale.y - scaleAmount, originalScale.z);
        float t = 0f;

        while (true)
        {
            starBg.transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime);
            t = scaleSpeed * Time.deltaTime;
            float scaleFactor = Mathf.PingPong(t, 1);
            starBg.transform.localScale = Vector3.Lerp(originalScale, targetScale, scaleFactor);
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
