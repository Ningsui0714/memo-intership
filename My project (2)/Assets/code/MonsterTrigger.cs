using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterTrigger : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ����Ƿ���ײ�����
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("������ײ�����");
            // ��ȡ��ҵĽ����������Ѫ
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(); // ���ÿ�Ѫ����
            }
            else
            {
                Debug.LogError("��Ҷ�����û��PlayerHealth�����");
            }
        }
    }

    // ���ʹ�ô�����
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("���ﴥ�������");
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage();
            }
            else
            {
                Debug.LogError("��Ҷ�����û��PlayerHealth�����");
            }
        }
    }
}
