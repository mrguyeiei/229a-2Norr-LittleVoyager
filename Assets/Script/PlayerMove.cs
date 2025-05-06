using System;
using UnityEngine;
using TMPro;

public class PlayerMove : MonoBehaviour
{
    public int Cherry => cherry;
    int cherry = 0;

    Vector2 moveInput;
    Rigidbody2D rb2d;

    [SerializeField] float speed = 5f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] bool isJumping = false;
    [SerializeField] private Animator animator;
    [SerializeField] TextMeshProUGUI CherryTxt;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        UpdateCherryText(); // แสดงค่า coin ตั้งแต่เริ่มเกม
    }

    void Update()
    {
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
        rb2d.linearVelocity = new Vector2(moveInput.x * speed, rb2d.linearVelocity.y);

        // ตั้งค่าการวิ่ง
        animator.SetBool("Run", moveInput.x != 0);

        // หันหน้าตามการเคลื่อนไหว
        if (moveInput.x != 0)
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(moveInput.x) * Mathf.Abs(scale.x);
            transform.localScale = scale;
        }

        // กระโดด
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, jumpForce);
            animator.SetTrigger("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isJumping = true;
        }
    }

    void UpdateCherryText()
    {
        CherryTxt.text = $"Cherry: {cherry}";
    }

    public void CherryUp(int CherryIncrease)
    {
        cherry += CherryIncrease;
        Debug.Log($"Cherry increased by {CherryIncrease}. New Cherry: {cherry}");
        UpdateCherryText();
    }
}
