using UnityEngine;

public class CropBehaviour : MonoBehaviour
{
    public CropData cropData; // StrawberryData buraya gelecek
    private SpriteRenderer spriteRenderer;

    private float growthTimer = 0f;
    private int currentStage = 0;
    public bool isHarvestable = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Baþlangýç sprite'ýný (Tohum aþamasýný) ayarla
        if (cropData != null && cropData.growthStages.Length > 0)
        {
            spriteRenderer.sprite = cropData.growthStages[0];
        }
    }

    void Update()
    {
        // Eðer zaten hasat edilebilir durumdaysa veya veri yoksa zamanlayýcýyý durdur
        if (isHarvestable || cropData == null) return;

        // Büyüme süresini artýr
        growthTimer += Time.deltaTime;

        // Raporundaki büyüme oraný formülü: (Geçen Süre / Toplam Süre)
        float growthPercentage = growthTimer / cropData.totalGrowthTime;

        // Hangi aþamada olduðumuzu bul (Örn: %50 büyüdüyse dizideki ortadaki görseli seç)
        int stageCount = cropData.growthStages.Length;
        int newStage = Mathf.FloorToInt(growthPercentage * stageCount);

        // Büyüme tamamlandýysa sýnýrý aþmasýný engelle ve hasat moduna al
        if (newStage >= stageCount - 1)
        {
            newStage = stageCount - 1;
            isHarvestable = true;
        }

        // Eðer aþama deðiþtiyse (tohumdan filize geçtiyse) görseli güncelle
        if (newStage != currentStage)
        {
            currentStage = newStage;
            spriteRenderer.sprite = cropData.growthStages[currentStage];
        }
    }
}