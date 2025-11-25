using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flip : MonoBehaviour
{
    [Header("设置")]
    [SerializeField] private float inputThreshold = 0.1f; // 输入阈值

    private int facingDirection = 1; // 1 = 右, -1 = 左

    void Start()
    {
        // 根据 localScale.x 确定初始朝向
        // 使用 Mathf.Sign 与 SetFacingDirection 保持一致
        facingDirection = (int)Mathf.Sign(transform.localScale.x);
        if (facingDirection == 0) facingDirection = 1; // 如果缩放为0，默认朝右
    }

    void Update()
    {
        CheckMovementInput();
    }

    private void CheckMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // 向右移动
        if (horizontalInput > inputThreshold)
        {
            SetFacingDirection(1);
        }
        // 向左移动
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

            // 使用 localScale.x 进行翻转（与 firearrow.cs 保持一致）
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * facingDirection;
            transform.localScale = scale;

            // 调试输出
            Debug.Log($"角色方向已更新: {facingDirection}, localScale.x: {transform.localScale.x}");
        }
    }

    // 获取当前朝向（供其他脚本使用）
    public int GetFacingDirection()
    {
        return facingDirection;
    }
}
