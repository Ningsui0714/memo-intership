using UnityEngine;

/// <summary>
/// 玩家移动脚本
/// 处理水平移动和跳跃输入
/// </summary>
public class PlayerMove : MonoBehaviour
{
    [Header("移动设置")]
    [Tooltip("移动速度")]
    [Range(1f, 20f)]
    public float moveSpeed = 10f;

    [Tooltip("跳跃力度")]
    [Range(1f, 20f)]
    public float jumpForce = 10f;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleMovement();
        HandleJump();
    }

    /// <summary>
    /// 处理水平移动
    /// </summary>
    private void HandleMovement()
    {
        float dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    /// <summary>
    /// 处理跳跃
    /// </summary>
    private void HandleJump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
