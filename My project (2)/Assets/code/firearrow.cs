using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerArchery : MonoBehaviour
{
    [Header("箭矢设置")]
    public GameObject rightArrowPrefab;  // 向右发射的箭
    public GameObject leftArrowPrefab;   // 向左发射的箭
    public Transform firePoint;          // 发射点
    public float arrowSpeed = 10f;       // 箭的速度
    public float fireRate = 0.5f;        // 发射间隔

    private float nextFireTime = 0f;
    private int facingDirection = 1;     // 1: 向右, -1: 向左

    void Update()
    {
        // 更新角色朝向（根据你的角色移动逻辑调整）
        UpdateFacingDirection();

        // 空格键发射，且在冷却时间之后
        if (Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFireTime)
        {
            ShootArrow();
            nextFireTime = Time.time + fireRate;  // 设置下一次可发射时间
        }
    }

    // 更新角色朝向（根据实际移动控制方式修改）
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
        // 根据朝向选择不同的箭预制体
        GameObject arrowPrefab = facingDirection == 1 ? rightArrowPrefab : leftArrowPrefab;

        // 确保预制体已赋值
        if (arrowPrefab == null)
        {
            Debug.LogError("请分配箭矢预制体！", this);
            return;
        }

        // 在发射点生成箭
        GameObject arrow = Instantiate(arrowPrefab, firePoint.position, firePoint.rotation);

        // 获取箭的刚体组件并施加力
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // 根据朝向设置发射方向
            rb.velocity = firePoint.right * facingDirection * arrowSpeed;
        }


    }
}
