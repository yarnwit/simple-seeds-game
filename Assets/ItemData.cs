using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class ItemData : ScriptableObject
{
    public string itemName; // ชื่อไอเทม
    public Sprite icon;     // รูปไอคอนที่จะโชว์ในกระเป๋า
    public bool isStackable; // ซ้อนทับกันได้ไหม (เช่น เมล็ดวางซ้อนได้ 99 ชิ้น)
    
    // คุณอาจเพิ่มประเภทไอเทมตรงนี้ได้ เช่น Tool, Seed, Consumable
}