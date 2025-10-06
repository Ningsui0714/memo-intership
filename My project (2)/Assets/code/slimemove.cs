using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 确保组件完整性
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class MonsterMovement : MonoBehaviour
{
    [Header("移动设置")]
    [Range(0.5f, 10f)] public float moveSpeed = 2f;
    [Range(0.1f, 2f)] public float checkDistance = 0.6f;
    public LayerMask wallLayer;
    [Tooltip("射线检测起点，不设置则使用物体中心")]
    public Transform rayOrigin;

    private int direction = 1; // 1向右，-1向左
    private float originalScaleX;
    private Rigidbody2D rb;
    private PolygonCollider2D col;

    void Awake()
    {
        // 在Start之前初始化关键组件
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<PolygonCollider2D>();
    }

    void Start()
    {
        if (rb != null)
        {
            // 配置刚体属性
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 0;
            rb.freezeRotation = true;
            //rb.linearDrag = 0;
        }

        // 记录初始缩放
        originalScaleX = Mathf.Abs(transform.localScale.x);

        // 确保初始方向正确应用
        UpdateFacingDirection();
    }

    void FixedUpdate()
    {
        if (rb == null) return; // 安全检查

        // 使用刚体移动，避免变换冲突
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        // 检测墙壁
        CheckWallCollision();
    }

    void CheckWallCollision()
    {
        if (wallLayer == 0)
        {
            Debug.LogWarning("MonsterMovement: 未设置墙壁图层！", this);
            return;
        }

        // 计算射线起点
        Vector2 origin = rayOrigin != null ?
            (Vector2)rayOrigin.position :
            (Vector2)transform.position + (Vector2.right * direction * (col.bounds.extents.x * 0.9f));

        // 射线检测
        RaycastHit2D hit = Physics2D.Raycast(
            origin,
            Vector2.right * direction,
            checkDistance,
            wallLayer
        );

        if (hit)
        {
            // 转向
            direction *= -1;
            UpdateFacingDirection();
        }
    }

    // 更新朝向
    void UpdateFacingDirection()
    {
        Vector3 newScale = transform.localScale;
        newScale.x = originalScaleX * direction;
        transform.localScale = newScale;
    }

    // 绘制射线 gizmo
    void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Vector2 origin = rayOrigin != null ?
                (Vector2)rayOrigin.position :
                (Vector2)transform.position + (Vector2.right * direction * (col ? col.bounds.extents.x * 0.9f : 0.1f));

            Gizmos.DrawRay(origin, Vector2.right * direction * checkDistance);
        }
    }
}
