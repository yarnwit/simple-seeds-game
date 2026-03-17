using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance; // ทำให้เรียกใช้ได้ง่ายจากที่อื่น (Singleton)

    public List<ItemData> items = new List<ItemData>(); // รายชื่อของในกระเป๋าเรา
    
    public InventorySlot[] slots; // อาเรย์เก็บช่อง UI ทั้งหมด
    public GameObject slotPrefab; // Prefab ช่องที่เราทำไว้
    public Transform slotPanel;   // ตัว InventoryPanel ที่มี Grid Layout

    void Awake()
    {
        if (instance == null) instance = this;
    }

    void Start()
    {
        // ตัวอย่าง: สร้างช่องว่างๆ รอไว้ 8 ช่อง
        slots = new InventorySlot[8];
        for (int i = 0; i < slots.Length; i++)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotPanel);
            slots[i] = newSlot.GetComponent<InventorySlot>();
        }
        
        RefreshUI(); // อัปเดตหน้าจอครั้งแรก
    }

    // ฟังก์ชันเพิ่มของเข้าตัว
    public void AddItem(ItemData newItem)
    {
        items.Add(newItem); // เพิ่มข้อมูลลง List
        RefreshUI();        // สั่งวาดหน้าจอใหม่
    }

    // ฟังก์ชันวาดหน้าจอ UI ให้ตรงกับข้อมูลที่มี
    void RefreshUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < items.Count)
            {
                slots[i].SetItem(items[i]); // ถ้ามีของ ให้โชว์ของ
            }
            else
            {
                slots[i].ClearSlot(); // ถ้าไม่มี ให้เคลียร์ช่อง
            }
        }
    }
}