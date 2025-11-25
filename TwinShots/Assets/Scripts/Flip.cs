using UnityEngine;

/// <summary>
/// 角色翻转脚本
/// 根据玩家输入控制角色的朝向翻转
/// </summary>
public class Flip : MonoBehaviour
{
    [Header("设置")]
    [SerializeField]
    [Tooltip("输入阈值，小于此值的输入将被忽略")]
    private float inputThreshold = 0.1f;

    private int facingDirection = 1; // 1 = 右, -1 = 左

    private void Start()
    {
        // 根据 localScale.x 确定初始朝向
        facingDirection = (int)Mathf.Sign(transform.localScale.x);
        if (facingDirection == 0) facingDirection = 1; // 如果缩放为0，默认朝右
    }

    private void Update()
    {
        CheckMovementInput();
    }

    /// <summary>
    /// 检测移动输入并更新朝向
    /// </summary>
    private void CheckMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput > inputThreshold)
        {
            SetFacingDirection(1);
        }
        else if (horizontalInput < -inputThreshold)
        {
            SetFacingDirection(-1);
        }
    }

    /// <summary>
    /// 设置角色朝向
    /// </summary>
    /// <param name="direction">朝向方向：1为右，-1为左</param>
    public void SetFacingDirection(int direction)
    {
        if (direction == facingDirection) return;

        facingDirection = direction;
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * facingDirection;
        transform.localScale = scale;
    }

    /// <summary>
    /// 获取当前朝向
    /// </summary>
    /// <returns>朝向方向：1为右，-1为左</returns>
    public int GetFacingDirection()
    {
        return facingDirection;
    }
}
