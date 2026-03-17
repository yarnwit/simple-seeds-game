using UnityEngine;
using UnityEngine.Tilemaps; // จำเป็นต้องมีบรรทัดนี้ เพื่อคุยกับระบบ Grid

public class PlayerPlanter : MonoBehaviour
{
    [Header("เชื่อมต่ออุปกรณ์")]
    public Tilemap groundTilemap; // พื้นดินที่เราจะปลูก (เอาไว้อ้างอิงพิกัด)
    public GameObject cropPrefab; // แม่แบบต้นไม้ (Prefab) ที่เราทำไว้
    public CropData seedToPlant;  // ข้อมูลเมล็ดพันธุ์ (RadishData)

    void Update()
    {
        // ตรวจจับการคลิกเมาส์ซ้าย (0 = ซ้าย, 1 = ขวา, 2 = กลาง)
        if (Input.GetMouseButtonDown(0))
        {
            PlantCrop();
        }
    }

    void PlantCrop()
    {
        // 1. หาตำแหน่งเมาส์ในจอ -> แปลงเป็นตำแหน่งในโลกเกม (World Point)
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0; // เกม 2D แกน Z ต้องเป็น 0 เสมอ

        // 2. ถาม Tilemap ว่า "เมาส์จิ้มอยู่ที่ช่อง (Cell) ไหน?"
        Vector3Int cellPosition = groundTilemap.WorldToCell(mousePos);

        // 3. ถามต่อว่า "จุดกึ่งกลางของช่องนั้น อยู่ตรงไหน?" (Snap to Grid)
        // เพื่อให้ต้นไม้วางตรงกลางช่องเป๊ะๆ สวยงาม
        Vector3 spawnPosition = groundTilemap.GetCellCenterWorld(cellPosition);

        // 4. เสกต้นไม้ออกมา (Instantiate) ที่ตำแหน่งนั้น
        GameObject newCropObject = Instantiate(cropPrefab, spawnPosition, Quaternion.identity);

        // 5. ส่งข้อมูลเมล็ดพันธุ์ (RadishData) เข้าไปในต้นไม้ เพื่อให้มันเริ่มโต
        CropBehavior cropScript = newCropObject.GetComponent<CropBehavior>();
        if (cropScript != null)
        {
            cropScript.Plant(seedToPlant);
        }
    }
}