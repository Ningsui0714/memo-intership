using System.Collections;
using UnityEngine;

/// <summary>
/// 箭矢行为控制脚本
/// 处理箭矢碰撞后的延迟销毁逻辑
/// </summary>
public class Arrow : MonoBehaviour
{
    [Header("碰撞设置")]
    [Tooltip("碰撞后是否销毁箭矢")]
    public bool destroyOnHit = true;

    [Tooltip("碰撞后延迟销毁时间（秒）")]
    public float destroyDelay = 8f;

    private bool hasCollided = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasCollided) return;

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground"))
        {
            if (destroyOnHit)
            {
                hasCollided = true;
                StartCoroutine(DestroyAfterDelay(destroyDelay));
            }
        }
    }

    private IEnumerator DestroyAfterDelay(float delay)
    {
        // 等待指定时间
        yield return new WaitForSeconds(delay);
        // 执行销毁
        Destroy(gameObject);
    }
}