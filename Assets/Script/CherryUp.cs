using UnityEngine;

public abstract class CherryUp : MonoBehaviour
{
    // เมธอด abstract สำหรับใช้กำหนดผลของเชอร์รี่เมื่อตัวละครเก็บได้
    // คลาสลูกต้อง override เมธอดนี้ เพื่อกำหนดพฤติกรรมของเชอร์รี่แต่ละแบบ
    public abstract void ApplyCherryUp(PlayerMove playermove);
}
