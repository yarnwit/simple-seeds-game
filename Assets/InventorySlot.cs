using UnityEngine;
using UnityEngine.UI; // สำคัญมาก ต้องมีบรรทัดนี้เพื่อคุยกับ UI

public class InventorySlot : MonoBehaviour
{
    public Image iconDisplay; // ลาก Image (Icon) มาใส่ตรงนี้
    public ItemData item;     // ข้อมูลไอเทมที่ช่องนี้ถืออยู่

    // ฟังก์ชันสำหรับอัปเดตหน้าตาช่อง
    public void SetItem(ItemData newItem)
    {
        item = newItem;
        iconDisplay.sprite = item.icon;
        iconDisplay.enabled = true; // เปิดการมองเห็นรูป
    }

    // ฟังก์ชันสำหรับเคลียร์ช่องให้ว่าง
    public void ClearSlot()
    {
        item = null;
        iconDisplay.sprite = null;
        iconDisplay.enabled = false;
    }
}