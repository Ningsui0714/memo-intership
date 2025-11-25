using UnityEngine;

/// <summary>
/// 单向平台脚本 - 挂载在箭矢上使角色可以从下往上穿越，但从上往下不能穿越（可以站在上面）
/// One-way platform script - Attach to arrows to allow characters to pass through from below
/// but block them from above (allowing them to stand on the arrow)
/// 
/// 使用方法：
/// 1. 将此脚本挂载到箭矢预制体上
/// 2. 确保箭矢有 Collider2D 组件
/// 3. 脚本会自动添加并配置 PlatformEffector2D 组件
/// </summary>
public class OneWayPlatform : MonoBehaviour
{
    [Header("平台设置")]
    [Tooltip("表面弧度（决定可站立的角度范围）")]
    [Range(0f, 180f)]
    public float surfaceArc = 180f;

    [Tooltip("是否使用单向碰撞")]
    public bool useOneWay = true;

    private Collider2D platformCollider;
    private PlatformEffector2D platformEffector;

    void Awake()
    {
        SetupPlatformEffector();
    }

    /// <summary>
    /// 设置 PlatformEffector2D 组件以实现单向平台效果
    /// </summary>
    private void SetupPlatformEffector()
    {
        // 获取碰撞体组件
        platformCollider = GetComponent<Collider2D>();
        if (platformCollider == null)
        {
            Debug.LogWarning("OneWayPlatform: 未找到 Collider2D 组件！", this);
            return;
        }

        // 添加或获取 PlatformEffector2D 组件
        platformEffector = GetComponent<PlatformEffector2D>();
        if (platformEffector == null)
        {
            platformEffector = gameObject.AddComponent<PlatformEffector2D>();
        }

        // 配置 PlatformEffector2D
        platformEffector.useOneWay = useOneWay;
        platformEffector.surfaceArc = surfaceArc;
        platformEffector.useColliderMask = true;

        // 设置碰撞体使用效果器
        platformCollider.usedByEffector = true;
    }

    /// <summary>
    /// 编辑器中更新设置
    /// </summary>
    void OnValidate()
    {
        // 在编辑器中尝试获取已有的 PlatformEffector2D 组件
        if (platformEffector == null)
        {
            platformEffector = GetComponent<PlatformEffector2D>();
        }
        
        if (platformEffector != null)
        {
            platformEffector.useOneWay = useOneWay;
            platformEffector.surfaceArc = surfaceArc;
        }
    }
}
