using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 检测是否碰撞到玩家
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("怪物碰撞到玩家");
            // 获取玩家的健康组件并扣血
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(); // 调用扣血方法
            }
            else
            {
                Debug.LogError("玩家对象上没有PlayerHealth组件！");
            }
        }
    }

    // 如果使用触发器
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("怪物触发到玩家");
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }
            else
            {
                Debug.LogError("玩家对象上没有PlayerHealth组件！");
            }
        }
    }
}
