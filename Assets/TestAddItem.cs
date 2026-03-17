using UnityEngine;

public class TestAddItem : MonoBehaviour
{
    // สร้างช่องว่างๆ ไว้ให้เราลากไฟล์ Item (ScriptableObject) มาใส่
    public ItemData itemToTest; 

    void Update()
    {
        // ถ้าเรากดปุ่ม T บนคีย์บอร์ด (เปลี่ยนปุ่มได้ตามใจชอบ)
        if (Input.GetKeyDown(KeyCode.T))
        {
            // เรียกใช้คำสั่งเพิ่มของ ไปที่ระบบ Inventory
            InventoryManager.instance.AddItem(itemToTest);
            
            // พิมพ์บอกเราหน่อยว่ากดติดแล้ว
            Debug.Log("เสกของเข้าตัวแล้ว!");
        }
    }
}