using UnityEngine;

/// <summary>
/// 史莱姆移动脚本
/// 控制史莱姆的水平移动和墙壁检测
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class SlimeMove : MonoBehaviour
{
    [Header("移动设置")]
    [Tooltip("移动速度")]
    [Range(0.5f, 10f)]
    public float moveSpeed = 2f;

    [Tooltip("墙壁检测距离")]
    [Range(0.1f, 2f)]
    public float checkDistance = 0.6f;

    [Tooltip("墙壁图层")]
    public LayerMask wallLayer;

    [Tooltip("射线检测起点（可选）")]
    public Transform rayOrigin;

    private int direction = 1; // 1=右, -1=左
    private float originalScaleX;
    private Rigidbody2D rb;
    private Collider2D col;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
    }

    private void Start()
    {
        ConfigureRigidbody();
        originalScaleX = Mathf.Abs(transform.localScale.x);
        UpdateFacingDirection();
    }

    /// <summary>
    /// 配置刚体参数
    /// </summary>
    private void ConfigureRigidbody()
    {
        if (rb == null) return;

        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = 0f;
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        if (rb == null) return;

        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        CheckWallCollision();
    }

    /// <summary>
    /// 检测墙壁碰撞
    /// </summary>
    private void CheckWallCollision()
    {
        if (wallLayer == 0)
        {
            Debug.LogWarning("SlimeMove: 未设置墙壁图层！", this);
            return;
        }

        Vector2 origin = GetRayOrigin();
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.right * direction, checkDistance, wallLayer);

        if (hit)
        {
            direction *= -1;
            UpdateFacingDirection();
        }
    }

    /// <summary>
    /// 获取射线起点
    /// </summary>
    private Vector2 GetRayOrigin()
    {
        if (rayOrigin != null)
        {
            return rayOrigin.position;
        }

        float offsetX = col != null ? col.bounds.extents.x * 0.9f : 0.1f;
        return (Vector2)transform.position + Vector2.right * direction * offsetX;
    }

    /// <summary>
    /// 更新朝向
    /// </summary>
    private void UpdateFacingDirection()
    {
        Vector3 newScale = transform.localScale;
        newScale.x = originalScaleX * direction;
        transform.localScale = newScale;
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying) return;

        Gizmos.color = Color.red;
        Vector2 origin = GetRayOrigin();
        Gizmos.DrawRay(origin, Vector2.right * direction * checkDistance);
    }
}
