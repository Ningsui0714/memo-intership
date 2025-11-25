using UnityEngine;

/// <summary>
/// 碰撞调试脚本
/// 用于检测对象的碰撞器和刚体配置，并在碰撞时输出调试信息
/// </summary>
public class CollisionDebug : MonoBehaviour
{
    private void Start()
    {
        // 检查碰撞器配置
        Collider2D col = GetComponent<Collider2D>();
        if (col == null)
        {
            Debug.LogError($"{gameObject.name} 没有2D碰撞体！请添加BoxCollider2D");
        }
        else if (col.isTrigger)
        {
            Debug.LogWarning($"{gameObject.name} 的碰撞体是触发器模式");
        }

        // 检查刚体配置
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning($"{gameObject.name} 没有Rigidbody2D，可能导致碰撞问题");
        }
        else if (rb.bodyType == RigidbodyType2D.Static)
        {
            Debug.LogWarning($"{gameObject.name} 的Rigidbody2D是Static，可能导致碰撞问题");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"[{gameObject.name}] 普通碰撞 -> 对方：{collision.gameObject.name}");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"[{gameObject.name}] 触发碰撞 -> 对方：{other.gameObject.name}");
    }
}
