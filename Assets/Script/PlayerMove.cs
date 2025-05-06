using System;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    // จำนวนเชอร์รี่ทั้งหมดที่ผู้เล่นเก็บได้ (ให้เรียกดูได้จากภายนอก แต่แก้ไม่ได้)
    public int Cherry => cherry;

    // ตัวแปรภายในเก็บค่าจริง
    int cherry = 0;

    // ตัวแปรรับค่าการกดปุ่มซ้าย/ขวา
    Vector2 moveInput;

    // อ้างอิง Rigidbody2D ของตัวละคร
    Rigidbody2D rb2d;

    // ปรับความเร็วการวิ่ง และแรงกระโดด
    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 10f;

    // ตรวจสอบว่ากำลังกระโดดอยู่หรือไม่
    [SerializeField] bool isJumping = false;

    // อ้างอิงตัวควบคุมอนิเมชัน
    [SerializeField] private Animator animator;

    // อ้างอิง Text ที่แสดงจำนวนเชอร์รี่ใน UI
    [SerializeField] TextMeshProUGUI CherryTxt;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); // โหลด Rigidbody2D ตอนเริ่มเกม
        UpdateCherryText();                 // แสดงค่าเชอร์รี่เริ่มต้นใน UI
    }

    void Update()
    {
        // รับค่าการกดปุ่มซ้าย/ขวา
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        // เคลื่อนที่ตามแกน X (แนวนอน)
        rb2d.linearVelocity = new Vector2(moveInput.x * speed, rb2d.linearVelocity.y);

        // สั่งให้ตัวละครเล่นอนิเมชันวิ่งหากมีการเคลื่อนไหว
        animator.SetBool("Run", moveInput.x != 0);

        // หันหน้าตัวละครตามทิศทางที่เดิน
        if (moveInput.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(moveInput.x) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        // กระโดดถ้าไม่อยู่กลางอากาศ
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }
    }

    // เมื่อชนกับพื้น ให้รู้ว่าไม่ได้ลอยอยู่
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    // เมื่อลอยออกจากพื้น ให้รู้ว่ากำลังกระโดด
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    // อัปเดตข้อความแสดงจำนวนเชอร์รี่บนหน้าจอ
    void UpdateCherryText()
    {
        CherryTxt.text = $"Cherry: {cherry}";
    }

    // เรียกใช้เมื่อเก็บเชอร์รี่ เพื่อเพิ่มจำนวนและอัปเดต UI
    public void CherryUp(int CherryIncrease)
    {
        cherry += CherryIncrease;
        Debug.Log($"Cherry increased by {CherryIncrease}. New Cherry: {cherry}");
        UpdateCherryText();
    }
}
