using UnityEngine;

public class CherryUpController : MonoBehaviour
{
    // เมื่อมีวัตถุเข้ามาในพื้นที่ Trigger นี้ (เช่น Player ชนกับ Cherry)
    private void OnTriggerEnter2D(Collider2D other)
    {
        // ตรวจสอบว่าเป็นวัตถุที่มี Tag เป็น "Player" หรือไม่
        if (other.CompareTag("Player"))
        {
            // ดึงสคริปต์ PlayerMove จากวัตถุที่ชน
            PlayerMove playerMove = other.GetComponent<PlayerMove>();

            // ดึงสคริปต์ CherryUp (ที่เป็นคลาสแม่) จากเชอร์รี่ที่ถูกชน
            CherryUp CherryUp = GetComponent<CherryUp>();

            // ถ้าทั้ง PlayerMove และ CherryUp ไม่เป็น null
            if (CherryUp != null && playerMove != null)
            {
                // เรียกใช้ความสามารถของเชอร์รี่กับ Player
                CherryUp.ApplyCherryUp(playerMove);

                // ลบวัตถุเชอร์รี่ออกจากฉาก (ถือว่าเก็บแล้ว)
                Destroy(gameObject);
            }
        }
    }
}
