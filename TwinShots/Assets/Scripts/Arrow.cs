using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
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
        // �ȴ�ָ��ʱ��
        yield return new WaitForSeconds(delay);

        // ִ�����٣������ټ��϶�����ӳ٣�
        Destroy(gameObject);
    }
}