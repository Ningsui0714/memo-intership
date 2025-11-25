using UnityEngine;

/// <summary>
/// 生命值显示脚本
/// 管理生命值并更新对应的精灵图显示
/// </summary>
public class HeartDisplay : MonoBehaviour
{
    [Header("生命值图片")]
    public Sprite heart3;
    public Sprite heart2;
    public Sprite heart1;
    public Sprite heart0;

    [Header("显示设置")]
    public SpriteRenderer displayRenderer;
    public Vector3 heartScale = new Vector3(2f, 2f, 1f);

    private int currentHearts = 3;

    private void Start()
    {
        InitializeRenderer();
        UpdateHeartImage();
    }

    /// <summary>
    /// 初始化精灵渲染器
    /// </summary>
    private void InitializeRenderer()
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
    }

    /// <summary>
    /// 减少一颗心（供PlayerHealth调用）
    /// </summary>
    public void LoseHeart()
    {
        if (currentHearts > 0)
        {
            currentHearts--;
            UpdateHeartImage();
            Debug.Log($"当前生命: {currentHearts}");
        }
    }

    /// <summary>
    /// 更新生命值显示
    /// </summary>
    private void UpdateHeartImage()
    {
        switch (currentHearts)
        {
            case 3:
                displayRenderer.sprite = heart3;
                break;
            case 2:
                displayRenderer.sprite = heart2;
                break;
            case 1:
                displayRenderer.sprite = heart1;
                break;
            case 0:
                displayRenderer.sprite = heart0;
                Time.timeScale = 0f; // 游戏暂停
                break;
        }
    }
}