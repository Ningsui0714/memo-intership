using UnityEngine;

/// <summary>
/// 怪物触发器脚本
/// 处理怪物与玩家的碰撞检测并造成伤害
/// </summary>
public class MonsterTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        HandlePlayerContact(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        HandlePlayerContact(other.gameObject);
    }

    /// <summary>
    /// 处理玩家接触
    /// </summary>
    /// <param name="target">接触的目标对象</param>
    private void HandlePlayerContact(GameObject target)
    {
        if (!target.CompareTag("Player")) return;

        Debug.Log("怪物碰撞到玩家");

        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage();
        }
        else
        {
            Debug.LogError("玩家对象没有PlayerHealth组件！");
        }
    }
}
