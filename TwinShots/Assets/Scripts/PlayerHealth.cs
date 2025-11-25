using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("无敌设置")]
    public float invincibilityTime = 2f; // 无敌持续时间（秒）
    public float blinkInterval = 0.2f; // 闪烁间隔（秒）

    [Header("心数显示引用")]
    public HeartDisplay heartDisplay; // 拖入场景中的HeartDisplay对象

    private bool isInvincible = false;
    private float invincibilityTimer = 0f;
    private float blinkTimer = 0f;
    private SpriteRenderer playerSprite; // 玩家的精灵渲染器

    void Start()
    {
        // 获取玩家自身的SpriteRenderer（用于闪烁）
        playerSprite = GetComponent<SpriteRenderer>();

        // 自动查找心数显示组件（如果未手动指定）
        if (heartDisplay == null)
        {
            heartDisplay = FindObjectOfType<HeartDisplay>();
            if (heartDisplay == null)
            {
                Debug.LogError("未找到HeartDisplay组件！请在Inspector中指定");
            }
        }
    }

    void Update()
    {
        // 处理无敌状态计时
        if (isInvincible)
        {
            invincibilityTimer += Time.deltaTime;
            blinkTimer += Time.deltaTime;

            // 无敌时间结束，恢复正常状态
            if (invincibilityTimer >= invincibilityTime)
            {
                isInvincible = false;
                invincibilityTimer = 0f;
                playerSprite.enabled = true; // 确保最后是显示状态
            }
            // 处理闪烁效果
            else if (blinkTimer >= blinkInterval)
            {
                playerSprite.enabled = !playerSprite.enabled; // 切换显示/隐藏
                blinkTimer = 0f;
            }
        }
    }

    // 扣血方法（供怪物碰撞时调用）
    public void TakeDamage()
    {
        // 如果处于无敌状态，不扣血
        if (isInvincible)
        {
            Debug.Log("处于无敌状态，不扣血");
            return;
        }

        // 扣血逻辑
        if (heartDisplay != null)
        {
            Debug.Log("扣血！");
            heartDisplay.LoseHeart(); // 调用心数显示组件扣血
            StartInvincibility(); // 进入无敌状态
        }
        else
        {
            Debug.LogError("HeartDisplay组件未找到，无法扣血！");
        }
    }

    // 开始无敌状态
    private void StartInvincibility()
    {
        isInvincible = true;
        invincibilityTimer = 0f;
        blinkTimer = 0f;
    }
}

