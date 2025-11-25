using UnityEngine;

/// <summary>
/// 生命值计数与显示脚本
/// 管理生命值并更新对应的精灵图显示
/// </summary>
public class HeartCount : MonoBehaviour
{
    [Header("生命值图片")]
    [Tooltip("3颗心的图片")]
    public Sprite heart3;

    [Tooltip("2颗心的图片")]
    public Sprite heart2;

    [Tooltip("1颗心的图片")]
    public Sprite heart1;

    [Tooltip("0颗心的图片")]
    public Sprite heart0;

    [Header("显示设置")]
    [Tooltip("用于显示生命值的精灵渲染器")]
    public SpriteRenderer heartRenderer;

    [Tooltip("生命值图片缩放")]
    public Vector3 heartScale = new Vector3(2f, 2f, 1f);

    private int currentHearts = 3;

    private void Start()
    {
        InitializeRenderer();
        UpdateHeartDisplay();
    }

    /// <summary>
    /// 初始化精灵渲染器
    /// </summary>
    private void InitializeRenderer()
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
    }

    /// <summary>
    /// 减少一颗心
    /// </summary>
    public void LoseHeart()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            UpdateHeartDisplay();
        }
    }

    /// <summary>
    /// 更新生命值显示
    /// </summary>
    private void UpdateHeartDisplay()
    {
        switch (currentHearts)
        {
            case 3:
                heartRenderer.sprite = heart3;
                break;
            case 2:
                heartRenderer.sprite = heart2;
                break;
            case 1:
                heartRenderer.sprite = heart1;
                break;
            case 0:
                heartRenderer.sprite = heart0;
                Time.timeScale = 0f; // 游戏暂停
                break;
        }
    }
}