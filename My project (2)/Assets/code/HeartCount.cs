using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 重命名类以匹配文件名，避免冲突
public class HeartCount : MonoBehaviour
{
    [Header("心数图片")]
    public Sprite heart3;
    public Sprite heart2;
    public Sprite heart1;
    public Sprite heart0;

    [Header("显示设置")]
    // 重命名变量，避免与Component.renderer冲突
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