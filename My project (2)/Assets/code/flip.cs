using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [Header("�������")]
    [SerializeField] private SpriteRenderer characterRenderer; // ��ɫͼ����Ⱦ��

    [Header("����")]
    [SerializeField] private float inputThreshold = 0.1f; // ������ֵ

    private int facingDirection = 1; // 1 = ��, -1 = ��

    void Start()
    {
        // �Զ���ȡ��������δ�ֶ�ָ����
        if (characterRenderer == null)
        {
            characterRenderer = GetComponent<SpriteRenderer>();
        }

        // ��¼��ʼ����
        facingDirection = characterRenderer.flipX ? -1 : 1;
    }

    void Update()
    {
        CheckMovementInput();
    }

    private void CheckMovementInput()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // ��������ƶ�
        if (horizontalInput > inputThreshold)
        {
            SetFacingDirection(1);
        }
        // ��������ƶ�
        else if (horizontalInput < -inputThreshold)
        {
            SetFacingDirection(-1);
        }
    }

    // ���ý�ɫ����
    public void SetFacingDirection(int direction)
    {
        // ֻ�з���ı�ʱ��ִ�з�ת
        if (direction != facingDirection)
        {
            facingDirection = direction;

            // Ӧ�÷�ת
            characterRenderer.flipX = (facingDirection == -1);

            // ������Ϣ������ȷ������
            Debug.Log($"��ɫ�����Ѹ���: {facingDirection}, flipX: {characterRenderer.flipX}");
        }
    }

    // �ṩ��ȡ��ǰ����ķ�������ʸ������Ҫ�����
    public int GetFacingDirection()
    {
        return facingDirection;
    }
}
