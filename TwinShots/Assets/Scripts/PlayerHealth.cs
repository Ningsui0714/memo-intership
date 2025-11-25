using UnityEngine;

/// <summary>
/// 玩家生命值脚本
/// 管理玩家受伤、无敌状态和闪烁效果
/// </summary>
public class PlayerHealth : MonoBehaviour
{
    [Header("无敌设置")]
    [Tooltip("无敌持续时间（秒）")]
    [Range(0.5f, 5f)]
    public float invincibilityTime = 2f;

    [Tooltip("闪烁间隔（秒）")]
    [Range(0.05f, 0.5f)]
    public float blinkInterval = 0.2f;

    [Header("生命显示组件")]
    [Tooltip("拖入场景中的HeartDisplay对象")]
    public HeartDisplay heartDisplay;

    private bool isInvincible = false;
    private float invincibilityTimer = 0f;
    private float blinkTimer = 0f;
    private SpriteRenderer playerSprite;

    private void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();

        // 自动查找生命显示组件（如果未手动指定）
        if (heartDisplay == null)
        {
            heartDisplay = FindObjectOfType<HeartDisplay>();
            if (heartDisplay == null)
            {
                Debug.LogError("未找到HeartDisplay组件，请在Inspector中指定");
            }
        }
    }

    private void Update()
    {
        if (!isInvincible) return;

        UpdateInvincibility();
    }

    /// <summary>
    /// 更新无敌状态
    /// </summary>
    private void UpdateInvincibility()
    {
        invincibilityTimer += Time.deltaTime;
        blinkTimer += Time.deltaTime;

        // 无敌时间结束
        if (invincibilityTimer >= invincibilityTime)
        {
            EndInvincibility();
            return;
        }

        // 处理闪烁效果
        if (blinkTimer >= blinkInterval)
        {
            playerSprite.enabled = !playerSprite.enabled;
            blinkTimer = 0f;
        }
    }

    /// <summary>
    /// 结束无敌状态
    /// </summary>
    private void EndInvincibility()
    {
        isInvincible = false;
        invincibilityTimer = 0f;
        blinkTimer = 0f;
        playerSprite.enabled = true;
    }

    /// <summary>
    /// 受到伤害（供怪物碰撞时调用）
    /// </summary>
    public void TakeDamage()
    {
        if (isInvincible)
        {
            Debug.Log("处于无敌状态，无法受伤");
            return;
        }

        if (heartDisplay != null)
        {
            Debug.Log("玩家受伤！");
            heartDisplay.LoseHeart();
            StartInvincibility();
        }
        else
        {
            Debug.LogError("HeartDisplay组件未找到，无法扣血！");
        }
    }

    /// <summary>
    /// 开始无敌状态
    /// </summary>
    private void StartInvincibility()
    {
        isInvincible = true;
        invincibilityTimer = 0f;
        blinkTimer = 0f;
    }
}
