using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public GameObject imagePrefab;
    public int maxImage = 20;
    public int minImage = 5;
    public Transform parentPanel;

    private RectTransform panelRectTransform;
    private int remainingImages;
    private MiniGameManager5 miniGameManager;

    void Start()
    {
        panelRectTransform = parentPanel.GetComponent<RectTransform>();
        miniGameManager = FindAnyObjectByType<MiniGameManager5>();

        int imageCount = Random.Range(minImage, maxImage + 1);
        remainingImages = imageCount;
        SpawnImages(imageCount);
    }

    private void SpawnImages(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newImage = Instantiate(imagePrefab, parentPanel);
            newImage.GetComponent<RectTransform>().anchoredPosition = GetRandomPosition();

            Button closeButton = newImage.GetComponentInChildren<Button>();
            if (closeButton != null)
            {
                closeButton.onClick.AddListener(() => RemoveImage(newImage));
            }
        }
    }

    private Vector2 GetRandomPosition()
    {
        float panelWidth = panelRectTransform.rect.width;
        float panelHeight = panelRectTransform.rect.height;

        // Tentukan posisi acak di dalam panel
        float randomX = Random.Range(-panelWidth / 2, panelWidth / 2);
        float randomY = Random.Range(-panelHeight / 2, panelHeight / 2);

        return new Vector2(randomX, randomY);
    }

    public void RemoveImage(GameObject image)
    {
        Destroy(image);
        remainingImages--;
        ChekWinCondition();
    }

    private void ChekWinCondition()
    {
        if (remainingImages <= 0)
        {
            miniGameManager.Win();
        }
    }
}
