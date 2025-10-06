using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("组件引用")]
    [SerializeField] private SpriteRenderer characterRenderer; // 角色图标渲染器

    [Header("设置")]
    [SerializeField] private float inputThreshold = 0.1f; // 输入阈值

    private int facingDirection = 1; // 1 = 右, -1 = 左

    void Start()
    {
        // 自动获取组件（如果未手动指定）
        if (characterRenderer == null)
        {
            characterRenderer = GetComponent<SpriteRenderer>();
        }

        // 记录初始朝向
        facingDirection = characterRenderer.flipX ? -1 : 1;
    }

    void Update()
    {
        CheckMovementInput();
    }

    private void CheckMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // 检测向右移动
        if (horizontalInput > inputThreshold)
        {
            SetFacingDirection(1);
        }
        // 检测向左移动
        else if (horizontalInput < -inputThreshold)
        {
            SetFacingDirection(-1);
        }
    }

    // 设置角色朝向
    public void SetFacingDirection(int direction)
    {
        // 只有方向改变时才执行翻转
        if (direction != facingDirection)
        {
            facingDirection = direction;

            // 应用翻转
            characterRenderer.flipX = (facingDirection == -1);

            // 调试信息，帮助确认问题
            Debug.Log($"角色朝向已更新: {facingDirection}, flipX: {characterRenderer.flipX}");
        }
    }

    // 提供获取当前朝向的方法（箭矢可能需要这个）
    public int GetFacingDirection()
    {
        return facingDirection;
    }
}
