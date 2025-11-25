using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ȷ�����������
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class SlimeMove : MonoBehaviour
{
    [Header("�ƶ�����")]
    [Range(0.5f, 10f)] public float moveSpeed = 2f;
    [Range(0.1f, 2f)] public float checkDistance = 0.6f;
    public LayerMask wallLayer;
    [Tooltip("���߼����㣬��������ʹ����������")]
    public Transform rayOrigin;

    private int direction = 1; // 1���ң�-1����
    private float originalScaleX;
    private Rigidbody2D rb;
    private PolygonCollider2D col;

    void Awake()
    {
        // ��Start֮ǰ��ʼ���ؼ����
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<PolygonCollider2D>();
    }

    void Start()
    {
        if (rb != null)
        {
            // ���ø�������
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 0;
            rb.freezeRotation = true;
            //rb.linearDrag = 0;
        }

        // ��¼��ʼ����
        originalScaleX = Mathf.Abs(transform.localScale.x);

        // ȷ����ʼ������ȷӦ��
        UpdateFacingDirection();
    }

    void FixedUpdate()
    {
        if (rb == null) return; // ��ȫ���

        // ʹ�ø����ƶ�������任��ͻ
        rb.velocity = new Vector2(direction * moveSpeed, rb.velocity.y);

        // ���ǽ��
        CheckWallCollision();
    }

    void CheckWallCollision()
    {
        if (wallLayer == 0)
        {
            Debug.LogWarning("MonsterMovement: δ����ǽ��ͼ�㣡", this);
            return;
        }

        // �����������
        Vector2 origin = rayOrigin != null ?
            (Vector2)rayOrigin.position :
            (Vector2)transform.position + (Vector2.right * direction * (col.bounds.extents.x * 0.9f));

        // ���߼��
        RaycastHit2D hit = Physics2D.Raycast(
            origin,
            Vector2.right * direction,
            checkDistance,
            wallLayer
        );

        if (hit)
        {
            // ת��
            direction *= -1;
            UpdateFacingDirection();
        }
    }

    // ���³���
    void UpdateFacingDirection()
    {
        Vector3 newScale = transform.localScale;
        newScale.x = originalScaleX * direction;
        transform.localScale = newScale;
    }

    // �������� gizmo
    void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            Gizmos.color = Color.red;
            Vector2 origin = rayOrigin != null ?
                (Vector2)rayOrigin.position :
                (Vector2)transform.position + (Vector2.right * direction * (col ? col.bounds.extents.x * 0.9f : 0.1f));

            Gizmos.DrawRay(origin, Vector2.right * direction * checkDistance);
        }
    }
}
