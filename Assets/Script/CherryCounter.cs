using UnityEngine;
using TMPro;
using System.Xml.Serialization;

public class CherryCounter : MonoBehaviour
{
    // ใช้ Singleton Pattern เพื่อให้สามารถเข้าถึงคลาสนี้ได้จากที่อื่นในเกม
    public static CherryCounter Instance;

    // อ้างอิงถึง TextMeshPro UI ที่ใช้แสดงจำนวนเชอร์รี่
    [SerializeField] public TMP_Text CherryText;

    // ตัวแปรเก็บจำนวนเชอร์รี่ปัจจุบัน
    public int currentCherry = 0;

    // เรียกเมื่อออบเจกต์นี้ถูกสร้างขึ้นในเกม (ก่อน Start)
    private void Awake()
    {
        // ตั้ง Instance ให้สามารถเข้าถึงจากคลาสอื่นได้ผ่าน CherryCounter.Instance
        Instance = this;
    }

    // เรียกเมื่อเริ่มเกม (หลัง Awake)
    private void Start()
    {
        // ตั้งค่าเริ่มต้นของข้อความ UI ให้แสดงจำนวนเชอร์รี่
        CherryText.text = "Cherry: " + currentCherry.ToString();
    }

    // ฟังก์ชันสำหรับเพิ่มจำนวนเชอร์รี่และอัปเดต UI
    public void IncreaseCherry(int v)
    {
        currentCherry += v; // เพิ่มค่าที่รับมา
        CherryText.text = "Cherry: " + currentCherry.ToString(); // อัปเดตข้อความ UI
    }
}
