using UnityEngine;

/// <summary>
/// 单向平台脚本
/// 挂载在箭矢上使角色可以从下往上穿越，但从上往下不能穿越（可以站在上面）
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

    private void Awake()
    {
        SetupPlatformEffector();
    }

    /// <summary>
    /// 设置 PlatformEffector2D 组件以实现单向平台效果
    /// </summary>
    private void SetupPlatformEffector()
    {
        platformCollider = GetComponent<Collider2D>();
        if (platformCollider == null)
        {
            Debug.LogWarning("OneWayPlatform: 未找到 Collider2D 组件！", this);
            return;
        }

        platformEffector = GetComponent<PlatformEffector2D>();
        if (platformEffector == null)
        {
            platformEffector = gameObject.AddComponent<PlatformEffector2D>();
        }

        ConfigureEffector();
    }

    /// <summary>
    /// 配置平台效果器
    /// </summary>
    private void ConfigureEffector()
    {
        platformEffector.useOneWay = useOneWay;
        platformEffector.surfaceArc = surfaceArc;
        platformEffector.useColliderMask = true;
        platformCollider.usedByEffector = true;
    }

    private void OnValidate()
    {
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
