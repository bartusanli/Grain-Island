using UnityEngine;

[CreateAssetMenu(fileName = "New Crop Data", menuName = "Grain Island/Crop Data")]
public class CropData : ScriptableObject
{
    [Header("Temel Bilgiler")]
    public string cropName;
    public int sellPrice;

    [Header("Büyüme Ayarlarý")]
    [Tooltip("Bitkinin tohumdan hasat edilebilir hale gelmesi için gereken toplam saniye")]
    public float totalGrowthTime;

    [Header("Görsel Evreler")]
    [Tooltip("Sýrasýyla: Tohum, Filiz, Büyüme Evresi ve Hasat Evresi görselleri")]
    public Sprite[] growthStages;

    [Header("Hasat Ayarlarý")]
    public int minHarvestAmount = 1;
    public int maxHarvestAmount = 3;
}