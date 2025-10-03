using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("�޵�����")]
    public float invincibilityTime = 2f; // �޵г���ʱ�䣨�룩
    public float blinkInterval = 0.2f; // ��˸������룩

    [Header("������ʾ����")]
    public HeartDisplay heartDisplay; // ���볡���е�HeartDisplay����

    private bool isInvincible = false;
    private float invincibilityTimer = 0f;
    private float blinkTimer = 0f;
    private SpriteRenderer playerSprite; // ��ҵľ�����Ⱦ��

    void Start()
    {
        // ��ȡ��������SpriteRenderer��������˸��
        playerSprite = GetComponent<SpriteRenderer>();

        // �Զ�����������ʾ��������δ�ֶ�ָ����
        if (heartDisplay == null)
        {
            heartDisplay = FindObjectOfType<HeartDisplay>();
            if (heartDisplay == null)
            {
                Debug.LogError("δ�ҵ�HeartDisplay���������Inspector��ָ��");
            }
        }
    }

    void Update()
    {
        // �����޵�״̬��ʱ
        if (isInvincible)
        {
            invincibilityTimer += Time.deltaTime;
            blinkTimer += Time.deltaTime;

            // �޵�ʱ��������ָ�����״̬
            if (invincibilityTimer >= invincibilityTime)
            {
                isInvincible = false;
                invincibilityTimer = 0f;
                playerSprite.enabled = true; // ȷ���������ʾ״̬
            }
            // ������˸Ч��
            else if (blinkTimer >= blinkInterval)
            {
                playerSprite.enabled = !playerSprite.enabled; // �л���ʾ/����
                blinkTimer = 0f;
            }
        }
    }

    // ��Ѫ��������������ײʱ���ã�
    public void TakeDamage()
    {
        // ��������޵�״̬������Ѫ
        if (isInvincible)
        {
            Debug.Log("�����޵�״̬������Ѫ");
            return;
        }

        // ��Ѫ�߼�
        if (heartDisplay != null)
        {
            Debug.Log("��Ѫ��");
            heartDisplay.LoseHeart(); // ����������ʾ�����Ѫ
            StartInvincibility(); // �����޵�״̬
        }
        else
        {
            Debug.LogError("HeartDisplay���δ�ҵ����޷���Ѫ��");
        }
    }

    // ��ʼ�޵�״̬
    private void StartInvincibility()
    {
        isInvincible = true;
        invincibilityTimer = 0f;
        blinkTimer = 0f;
    }
}

