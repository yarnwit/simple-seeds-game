using UnityEngine;

// บรรทัดนี้จะทำให้เราคลิกขวา Create เมนูใหม่ใน Unity ได้
[CreateAssetMenu(fileName = "New Crop", menuName = "Farming/Crop Data")]
public class CropData : ScriptableObject
{
    [Header("ข้อมูลทั่วไป")]
    public string cropName; // ชื่อผัก เช่น "Radish"
    
    [Header("การตั้งค่าการเติบโต")]
    public float timeToGrow; // เวลาที่ใช้ในการโตทั้งหมด (วินาที)
    
    [Header("รูปภาพในแต่ละระยะ")]
    // อาร์เรย์เก็บรูปภาพตั้งแต่เป็นเมล็ด จนถึงเกือบโต
    public Sprite[] growthStages; 
    
    // รูปตอนโตเต็มที่พร้อมเก็บเกี่ยว
    public Sprite readyToHarvestSprite; 
}