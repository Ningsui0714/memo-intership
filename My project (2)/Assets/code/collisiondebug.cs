using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 挂载到玩家和怪物上
public class CollisionDebugger : MonoBehaviour
{
    void Start()
    {
        // 检查是否有碰撞体
        Collider2D col = GetComponent<Collider2D>();
        if (col == null)
        {
            Debug.LogError($"{gameObject.name} 没有2D碰撞体！请添加BoxCollider2D");
        }
        else if (col.isTrigger)
        {
            Debug.LogWarning($"{gameObject.name} 的碰撞体是触发器模式");
        }

        // 检查是否有Rigidbody2D（至少一方需要）
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning($"{gameObject.name} 没有Rigidbody2D，可能导致碰撞不触发");
        }
        else if (rb.bodyType == RigidbodyType2D.Static)
        {
            Debug.LogWarning($"{gameObject.name} 的Rigidbody2D是Static，可能导致碰撞不触发");
        }
    }

    // 普通碰撞检测
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"【{gameObject.name}】发生碰撞 → 对方：{collision.gameObject.name}");
    }

    // 触发器碰撞检测（备用）
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"【{gameObject.name}】触发碰撞 → 对方：{other.gameObject.name}");
    }
}
