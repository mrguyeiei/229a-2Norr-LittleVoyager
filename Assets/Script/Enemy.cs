using UnityEngine;

public class Enemy : MonoBehaviour
{
    // ความเร็วในการเคลื่อนที่ของวัตถุ (แนวแกน X, Y)
    [SerializeField] Vector2 velocity;

    // จุดที่ใช้กำหนดขอบเขตการเคลื่อนที่ (เช่น ซ้ายสุดและขวาสุด)
    [SerializeField] Transform[] movePoints;

    // ตัวแปรเก็บ Rigidbody2D ของวัตถุนี้
    private Rigidbody2D rb;

    // เรียกใช้งานครั้งแรกเมื่อเริ่มเกม
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // ดึง Rigidbody2D มาเก็บไว้ในตัวแปร
        Behavior(); // เรียกฟังก์ชัน Behavior ทันที
    }

    // ทำงานทุกๆ FixedUpdate (เหมาะสำหรับการเคลื่อนที่ที่ใช้ฟิสิกส์)
    private void FixedUpdate()
    {
        Behavior(); // เรียกฟังก์ชัน Behavior ซ้ำๆ เพื่ออัปเดตตำแหน่ง
    }

    // ฟังก์ชันที่ควบคุมพฤติกรรมการเคลื่อนที่
    private void Behavior()
    {
        // เคลื่อนที่วัตถุตามความเร็วที่กำหนด
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);

        // ถ้าตำแหน่งปัจจุบันน้อยกว่าหรือเท่าจุดซ้ายสุด และกำลังเคลื่อนที่ไปทางซ้าย
        if (rb.position.x <= movePoints[0].position.x && velocity.x < 0)
        {
            FlipCharacter(); // กลับทิศทาง
        }
        // ถ้าตำแหน่งปัจจุบันมากกว่าหรือเท่าจุดขวาสุด และกำลังเคลื่อนที่ไปทางขวา
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            FlipCharacter(); // กลับทิศทาง
        }
    }

    // ฟังก์ชันสำหรับกลับทิศทางของตัวละคร
    private void FlipCharacter()
    {
        velocity *= -1; // สลับทิศของความเร็ว (เช่น จากซ้ายเป็นขวา)

        // สลับทิศของกราฟิกด้วยการกลับสเกลแกน X
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

    // ฟังก์ชันที่ทำงานเมื่อวัตถุชนกับ Collider ที่ตั้งค่าไว้เป็น Trigger
    void OnTriggerEnter2D(Collider2D collision)
    {
        // ถ้าชนกับวัตถุที่มี Tag เป็น "Apple"
        if (collision.CompareTag("Apple"))
        {
            Destroy(gameObject); // ทำลายตัวเอง
            Destroy(collision.gameObject); // ทำลายวัตถุที่ชนด้วย
        }
    }
}
