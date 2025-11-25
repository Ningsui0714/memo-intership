using UnityEngine;

/// <summary>
/// 发射箭矢脚本
/// 处理玩家射击输入和箭矢发射逻辑
/// </summary>
[RequireComponent(typeof(Flip))]
public class FireArrow : MonoBehaviour
{
    [Header("箭矢配置")]
    [Tooltip("向右发射的箭矢预制体")]
    public GameObject rightArrowPrefab;

    [Tooltip("向左发射的箭矢预制体")]
    public GameObject leftArrowPrefab;

    [Tooltip("发射点位置")]
    public Transform firePoint;

    [Tooltip("箭矢飞行速度")]
    [Range(5f, 30f)]
    public float arrowSpeed = 10f;

    [Tooltip("发射间隔（秒）")]
    [Range(0.1f, 2f)]
    public float fireRate = 0.5f;

    private float nextFireTime = 0f;
    private Flip flipComponent;

    private void Start()
    {
        flipComponent = GetComponent<Flip>();
    }

    private void Update()
    {
        // 空格键发射箭矢，检查冷却时间
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            ShootArrow();
            nextFireTime = Time.time + fireRate;
        }
    }

    /// <summary>
    /// 发射箭矢
    /// </summary>
    private void ShootArrow()
    {
        int facingDirection = flipComponent.GetFacingDirection();

        // 根据朝向选择对应的箭矢预制体
        GameObject arrowPrefab = facingDirection == 1 ? rightArrowPrefab : leftArrowPrefab;

        if (arrowPrefab == null)
        {
            Debug.LogError("请设置箭矢预制体！", this);
            return;
        }

        // 在发射点生成箭矢
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        // 设置箭矢速度
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * facingDirection * arrowSpeed;
        }
    }
}
