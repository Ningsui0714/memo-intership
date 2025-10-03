using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // 确保有Rigidbody2D组件
public class MonsterMovement : MonoBehaviour
{
    [Header("移动设置")]
    public float moveSpeed = 2f;
    public float checkDistance = 0.6f;
    public LayerMask wallLayer;
    public Transform rayOrigin; // 可选：手动指定射线起点

    private int direction = 1; // 1向右，-1向左
    private float originalScaleX;
    private Rigidbody2D rb;

    void Start()
    {
        // 获取Rigidbody2D组件
        rb = GetComponent<Rigidbody2D>();

        // 记录初始X轴缩放的绝对值
        originalScaleX = Mathf.Abs(transform.localScale.x);

        // 确保Rigidbody2D设置正确
        if (rb != null)
        {
            rb.gravityScale = 0; // 如果不需要重力
            rb.freezeRotation = true;
        }
    }

    void FixedUpdate() // 物理相关更新放在FixedUpdate
    {
        // 按当前方向移动（使用Rigidbody2D更物理化）
        if (rb != null)
        {
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }
        else
        {
            // 备选方案：如果没有Rigidbody2D则直接移动
            transform.Translate(Vector2.right * direction * moveSpeed * Time.fixedDeltaTime);
        }

        // 检测墙壁并转向
        CheckWall();
    }

    void CheckWall()
    {
        // 确定射线起点
        Vector2 origin = rayOrigin != null ?
            (Vector2)rayOrigin.position :
            (Vector2)transform.position + new Vector2(direction * 0.1f, 0);

        // 射线方向随当前方向自动变化
        Vector2 directionVector = Vector2.right * direction;

        // 发射射线检测墙壁
        RaycastHit2D hit = Physics2D.Raycast(origin, directionVector, checkDistance, wallLayer);
        if (hit)
        {
            // 碰到墙壁则转向
            direction *= -1;
            // 保持大小不变，更新朝向
            transform.localScale = new Vector3(originalScaleX * direction, transform.localScale.y, 1);
        }
    }

    // 在Scene视图显示射线（编辑器辅助）
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 origin = rayOrigin != null ?
            (Vector2)rayOrigin.position :
            (Vector2)transform.position + new Vector2(direction * 0.1f, 0);
        Gizmos.DrawRay(origin, Vector2.right * direction * checkDistance);
    }
}