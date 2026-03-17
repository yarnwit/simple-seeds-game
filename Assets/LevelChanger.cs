using UnityEngine;
using UnityEngine.SceneManagement; // จำเป็นต้องมีบรรทัดนี้เพื่อให้ Unity รู้จักคำสั่งเปลี่ยนด่าน

public class LevelChanger : MonoBehaviour
{
    [Tooltip("พิมพ์ชื่อด่านที่ต้องการให้โหลดลงไปตรงนี้")]
    public string sceneToLoad; 

    // ฟังก์ชันนี้จะทำงานอัตโนมัติเมื่อมีบางอย่างเดินเข้ามาในโซน Trigger (กรอบสีเขียว)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ตรวจสอบว่าสิ่งที่เดินมาชน มี Tag ว่า "Player" ใช่หรือไม่
        if (collision.CompareTag("Player"))
        {
            Debug.Log("กำลังเปลี่ยนด่านไปที่: " + sceneToLoad); // พิมพ์ข้อความบอกใน Console ว่าทำงานแล้ว
            
            // สั่งโหลดด่านตามชื่อที่เราพิมพ์ไว้
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}