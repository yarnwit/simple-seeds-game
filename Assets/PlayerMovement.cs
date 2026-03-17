using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator; // เพิ่มตัวแปร Animator

    Vector2 movement;

    void Update()
    {
        // รับค่าปุ่มกด
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        // ส่งค่าเข้า Animator เพื่อให้ตัวละครหันหน้า
        animator.SetFloat("Speed", movement.sqrMagnitude);

        // ถ้ามีการกดเดิน (Movement ไม่เป็น 0) ให้จำทิศทางล่าสุดไว้
        // (เพื่อให้ตอนหยุดเดิน ตัวละครยังหันหน้าทางเดิม ไม่ดีดกลับ)
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}