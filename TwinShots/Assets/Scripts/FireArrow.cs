using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : MonoBehaviour
{
    [Header("��ʸ����")]
    public GameObject rightArrowPrefab;  // ���ҷ���ļ�
    public GameObject leftArrowPrefab;   // ������ļ�
    public Transform firePoint;          // �����
    public float arrowSpeed = 10f;       // �����ٶ�
    public float fireRate = 0.5f;        // ������

    private float nextFireTime = 0f;
    private int facingDirection = 1;     // 1: ����, -1: ����

    void Update()
    {
        // ���½�ɫ���򣨸�����Ľ�ɫ�ƶ��߼�������
        UpdateFacingDirection();

        // �ո�����䣬������ȴʱ��֮��
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            ShootArrow();
            nextFireTime = Time.time + fireRate;  // ������һ�οɷ���ʱ��
        }
    }

    // ���½�ɫ���򣨸���ʵ���ƶ����Ʒ�ʽ�޸ģ�
    void UpdateFacingDirection()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        if (horizontalInput != 0)
        {
            facingDirection = (int)Mathf.Sign(horizontalInput);
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Abs(scale.x) * facingDirection;
            transform.localScale = scale;
        }
    }

    void ShootArrow()
    {
        // ���ݳ���ѡ��ͬ�ļ�Ԥ����
        GameObject arrowPrefab = facingDirection == 1 ? rightArrowPrefab : leftArrowPrefab;

        // ȷ��Ԥ�����Ѹ�ֵ
        if (arrowPrefab == null)
        {
            Debug.LogError("������ʸԤ���壡", this);
            return;
        }

        // �ڷ�������ɼ�
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        // ��ȡ���ĸ��������ʩ����
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // ���ݳ������÷��䷽��
            rb.velocity = firePoint.right * facingDirection * arrowSpeed;
        }


    }
}
