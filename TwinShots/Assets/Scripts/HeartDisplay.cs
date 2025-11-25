using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartDisplay : MonoBehaviour
{
    public Sprite heart3, heart2, heart1, heart0;
    public SpriteRenderer displayRenderer;
    public Vector3 heartScale = new Vector3(2, 2, 1);

    private int currentHearts = 3;

    void Start()
    {
        if (displayRenderer == null)
        {
            displayRenderer = GetComponent<SpriteRenderer>();
            if (displayRenderer == null)
            {
                displayRenderer = gameObject.AddComponent<SpriteRenderer>();
            }
        }
        displayRenderer.transform.localScale = heartScale;
        UpdateHeartImage();
    }

    // 扣血方法（供PlayerHealth调用）
    public void LoseHeart()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            UpdateHeartImage();
            Debug.Log("当前心数: " + currentHearts);
        }
    }

    private void UpdateHeartImage()
    {
        switch (currentHearts)
        {
            case 3: displayRenderer.sprite = heart3; break;
            case 2: displayRenderer.sprite = heart2; break;
            case 1: displayRenderer.sprite = heart1; break;
            case 0:
                displayRenderer.sprite = heart0;
                Time.timeScale = 0; // 游戏结束
                break;
        }
    }
}


