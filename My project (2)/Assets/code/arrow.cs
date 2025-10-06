using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrow : MonoBehaviour
{
    public bool destroyOnHit = true;
    public float blinkInterval = 0.2f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Ground"))
        {
            if (destroyOnHit)
            {
                StartCoroutine(DestroyAfterDelay(8f));
            }
        }
    }
    IEnumerator DestroyAfterDelay(float delay)
    {
        // 等待指定时间
        yield return new WaitForSeconds(delay);

        // 执行销毁（可以再加上额外的延迟）
        Destroy(gameObject);
    }
}