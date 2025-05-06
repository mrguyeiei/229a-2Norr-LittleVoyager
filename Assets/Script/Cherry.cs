using UnityEngine;

public class Cherry : CherryUp
{
    // จำนวนเชอร์รี่ที่จะเพิ่มให้ผู้เล่นเมื่อเก็บ
    public int CherryIncrease;

    // กำหนดค่าเริ่มต้นเมื่อเกมเริ่ม (หรือเมื่ออ็อบเจกต์นี้ถูกสร้าง)
    private void Start()
    {
        CherryIncrease = 1; // เพิ่มเชอร์รี่ 1 ลูก
    }

    // ฟังก์ชันที่ถูกเรียกเมื่อผู้เล่นชนกับ Cherry
    public override void ApplyCherryUp(PlayerMove playerMove)
    {
        // เรียกฟังก์ชันเพิ่มเชอร์รี่ใน PlayerMove โดยส่งค่าที่จะเพิ่มเข้าไป
        playerMove.CherryUp(CherryIncrease);
    }
}

