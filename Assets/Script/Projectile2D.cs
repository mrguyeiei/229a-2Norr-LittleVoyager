using UnityEngine;

public class Projectile2D : MonoBehaviour
{
    // จุดที่กระสุนจะถูกยิงออกไปจาก (เช่น ปากกระบอกปืน)
    [SerializeField] Transform shootPoint;

    // พรีแฟบของกระสุน (ต้องเป็น Rigidbody2D)
    [SerializeField] Rigidbody2D bulletPerfab;

    void Update()
    {
        // ตรวจสอบว่าผู้เล่นคลิกเมาส์ซ้ายในแต่ละเฟรมหรือไม่
        if (Input.GetMouseButtonDown(0))
        {
            // สร้างเรย์จากตำแหน่งเมาส์ไปในฉาก
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // วาดเส้นดีบัคใน Scene View (ช่วยตรวจสอบทิศทางเรย์)
            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 5f);

            // ตรวจสอบว่ามีอะไรในฉาก 2D ที่โดนเรย์หรือไม่
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);

            // ถ้ามีวัตถุที่ถูกยิง (เรย์ชนกับอะไรบางอย่าง)
            if (hit.collider != null)
            {
                // คำนวณความเร็วที่กระสุนต้องการ เพื่อไปถึงเป้าหมายภายใน 1 วินาที
                Vector2 projectileVelocity = CalculateProjectileVelocity(shootPoint.position, hit.point, 1f);

                // สร้างกระสุนใหม่ที่ตำแหน่ง shootPoint โดยไม่มีการหมุน
                Rigidbody2D shootBullet = Instantiate(bulletPerfab, shootPoint.position, Quaternion.identity);

                // ตั้งค่าความเร็วให้กระสุนที่ยิงออกไป
                shootBullet.linearVelocity = projectileVelocity;
            }

            // ฟังก์ชันช่วยคำนวณความเร็วของกระสุนให้ไปถึงเป้าหมายภายในเวลาที่กำหนด
            Vector2 CalculateProjectileVelocity(Vector2 origin, Vector2 target, float time)
            {
                Vector2 distance = target - origin;

                float velocityX = distance.x / time;
                float velocityY = distance.y / time + 0.5f * Mathf.Abs(Physics2D.gravity.y) * time;

                return new Vector2(velocityX, velocityY);
            }
        }
    }
}
