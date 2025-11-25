using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ���ص���Һ͹�����
public class CollisionDebug : MonoBehaviour
{
    void Start()
    {
        // ����Ƿ�����ײ��
        Collider2D col = GetComponent<Collider2D>();
        if (col == null)
        {
            Debug.LogError($"{gameObject.name} û��2D��ײ�壡������BoxCollider2D");
        }
        else if (col.isTrigger)
        {
            Debug.LogWarning($"{gameObject.name} ����ײ���Ǵ�����ģʽ");
        }

        // ����Ƿ���Rigidbody2D������һ����Ҫ��
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogWarning($"{gameObject.name} û��Rigidbody2D�����ܵ�����ײ������");
        }
        else if (rb.bodyType == RigidbodyType2D.Static)
        {
            Debug.LogWarning($"{gameObject.name} ��Rigidbody2D��Static�����ܵ�����ײ������");
        }
    }

    // ��ͨ��ײ���
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"��{gameObject.name}��������ײ �� �Է���{collision.gameObject.name}");
    }

    // ��������ײ��⣨���ã�
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log($"��{gameObject.name}��������ײ �� �Է���{other.gameObject.name}");
    }
}
