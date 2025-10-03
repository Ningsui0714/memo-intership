using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����������ƥ���ļ����������ͻ
public class HeartCount : MonoBehaviour
{
    [Header("����ͼƬ")]
    public Sprite heart3;
    public Sprite heart2;
    public Sprite heart1;
    public Sprite heart0;

    [Header("��ʾ����")]
    // ������������������Component.renderer��ͻ
    public SpriteRenderer heartRenderer;
    public Vector3 heartScale = new Vector3(2, 2, 1);

    private int currentHearts = 3;

    void Start()
    {
        if (heartRenderer == null)
        {
            heartRenderer = GetComponent<SpriteRenderer>();
            if (heartRenderer == null)
            {
                heartRenderer = gameObject.AddComponent<SpriteRenderer>();
            }
        }

        heartRenderer.transform.localScale = heartScale;
        UpdateHeartDisplay();
    }

    public void LoseHeart()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            UpdateHeartDisplay();
        }
    }

    private void UpdateHeartDisplay()
    {
        switch (currentHearts)
        {
            case 3: heartRenderer.sprite = heart3; break;
            case 2: heartRenderer.sprite = heart2; break;
            case 1: heartRenderer.sprite = heart1; break;
            case 0:
                heartRenderer.sprite = heart0;
                Time.timeScale = 0;
                break;
        }
    }
}