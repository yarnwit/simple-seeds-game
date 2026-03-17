using UnityEngine;
using System.Collections; // จำเป็นต้องมีบรรทัดนี้เพื่อใช้ Coroutine

public class CropBehavior : MonoBehaviour
{
    [Header("ข้อมูลพืชที่จะปลูก")]
    public CropData cropData; // ลากไฟล์ RadishData มาใส่ที่นี่ใน Inspector

    private SpriteRenderer sr;
    private int currentStage = 0; // เก็บสถานะว่าตอนนี้อยู่ระยะที่เท่าไหร่

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
        // ถ้าเราใส่ข้อมูลพืชไว้แล้ว ให้เริ่มปลูกทันที (ไว้สำหรับทดสอบ)
        if (cropData != null)
        {
            Plant(cropData);
        }
    }

    // ฟังก์ชันเริ่มปลูก (เรียกใช้จาก Start หรือจากตัวละครก็ได้)
    public void Plant(CropData data)
    {
        StopAllCoroutines();

        cropData = data;
        currentStage = 0; // รีเซ็ตกลับไปเริ่มที่ 0
        UpdateSprite();   // อัปเดตภาพแรก
        
        // เริ่มนับเวลาโต (Start Coroutine)
        StartCoroutine(GrowRoutine());
    }

    // Coroutine: ฟังก์ชันพิเศษที่สามารถ "หยุดรอ" (Yield) ได้
    IEnumerator GrowRoutine()
    {
        // คำนวณว่าแต่ละระยะต้องรอกี่วินาที
        // สูตร: เวลาทั้งหมด / จำนวนระยะที่มี
        // เช่น โต 5 วิ มี 3 ระยะ = รอยะระละ 1.6 วิ
        float timeBetweenStages = (float)cropData.timeToGrow / (float)cropData.growthStages.Length;

        // วนลูปจนกว่าจะครบทุกระยะในอาเรย์
        while (currentStage < cropData.growthStages.Length)
        {
            // รอเวลา...
            yield return new WaitForSeconds(timeBetweenStages);
            
            // ขยับไปขั้นถัดไป
            currentStage++;
            UpdateSprite();
        }
    }

    // ฟังก์ชันสำหรับเปลี่ยนรูปภาพตามระยะ currentStage
    void UpdateSprite()
    {
        // ป้องกัน Error กรณีลืมใส่รูป
        if (cropData == null || sr == null) return;

        if (currentStage < cropData.growthStages.Length)
        {
            // เอารูปจากในอาเรย์มาแสดง (เมล็ด -> ต้นอ่อน -> กำลังโต)
            sr.sprite = cropData.growthStages[currentStage];
        }
        else
        {
            // ถ้า index เกินอาเรย์ แสดงว่าโตเต็มวัยแล้ว ให้ใช้รูป readyToHarvest
            sr.sprite = cropData.readyToHarvestSprite;
            Debug.Log(cropData.cropName + " โตเต็มวัยแล้ว! เก็บเกี่ยวได้เลย");
        }
    }
}