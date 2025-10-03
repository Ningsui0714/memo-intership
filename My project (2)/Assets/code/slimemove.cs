using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // ȷ����Rigidbody2D���
public class MonsterMovement : MonoBehaviour
{
    [Header("�ƶ�����")]
    public float moveSpeed = 2f;
    public float checkDistance = 0.6f;
    public LayerMask wallLayer;
    public Transform rayOrigin; // ��ѡ���ֶ�ָ���������

    private int direction = 1; // 1���ң�-1����
    private float originalScaleX;
    private Rigidbody2D rb;

    void Start()
    {
        // ��ȡRigidbody2D���
        rb = GetComponent<Rigidbody2D>();

        // ��¼��ʼX�����ŵľ���ֵ
        originalScaleX = Mathf.Abs(transform.localScale.x);

        // ȷ��Rigidbody2D������ȷ
        if (rb != null)
        {
            rb.gravityScale = 0; // �������Ҫ����
            rb.freezeRotation = true;
        }
    }

    void FixedUpdate() // ������ظ��·���FixedUpdate
    {
        // ����ǰ�����ƶ���ʹ��Rigidbody2D��������
        if (rb != null)
        {
            rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);
        }
        else
        {
            // ��ѡ���������û��Rigidbody2D��ֱ���ƶ�
            transform.Translate(Vector2.right * direction * moveSpeed * Time.fixedDeltaTime);
        }

        // ���ǽ�ڲ�ת��
        CheckWall();
    }

    void CheckWall()
    {
        // ȷ���������
        Vector2 origin = rayOrigin != null ?
            (Vector2)rayOrigin.position :
            (Vector2)transform.position + new Vector2(direction * 0.1f, 0);

        // ���߷����浱ǰ�����Զ��仯
        Vector2 directionVector = Vector2.right * direction;

        // �������߼��ǽ��
        RaycastHit2D hit = Physics2D.Raycast(origin, directionVector, checkDistance, wallLayer);
        if (hit)
        {
            // ����ǽ����ת��
            direction *= -1;
            // ���ִ�С���䣬���³���
            transform.localScale = new Vector3(originalScaleX * direction, transform.localScale.y, 1);
        }
    }

    // ��Scene��ͼ��ʾ���ߣ��༭��������
    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector2 origin = rayOrigin != null ?
            (Vector2)rayOrigin.position :
            (Vector2)transform.position + new Vector2(direction * 0.1f, 0);
        Gizmos.DrawRay(origin, Vector2.right * direction * checkDistance);
    }
}