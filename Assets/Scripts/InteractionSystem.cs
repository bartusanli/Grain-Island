using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem;

public class InteractionSystem : MonoBehaviour
{
    [Header("Sistem Referanslarý")]
    public Camera mainCamera;
    public Grid mapGrid;
    public Tilemap interactableTilemap;

    [Header("Görsel Geri Bildirim")]
    public TileBase tilledSoilTile;

    [Header("Tarým Sistemi")]
    public GameObject cropPrefab;
    public CropData selectedCropData;

    // Hangi koordinata ekin ektiðimizi hafýzada tutacak sözlük
    private Dictionary<Vector3Int, GameObject> plantedCrops = new Dictionary<Vector3Int, GameObject>();

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleClickInteraction();
        }
    }

    private void HandleClickInteraction()
    {
        Vector2 screenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(screenPosition);
        mouseWorldPos.z = 0f;

        Vector3Int cellPosition = mapGrid.WorldToCell(mouseWorldPos);

        if (interactableTilemap.HasTile(cellPosition))
        {
            TileBase currentTile = interactableTilemap.GetTile(cellPosition);

            // DURUM 1: Týklanan yer henüz TARLA yapýlmamýþsa
            if (currentTile != tilledSoilTile)
            {
                interactableTilemap.SetTile(cellPosition, tilledSoilTile);
                Debug.Log("Toprak sürüldü ve tarlaya dönüþtü: " + cellPosition);
            }
            // DURUM 2: Týklanan yer zaten TARLA ise VE üzerinde henüz bir ekin YOKSA
            else if (!plantedCrops.ContainsKey(cellPosition))
            {
                Vector3 spawnPosition = mapGrid.GetCellCenterWorld(cellPosition);

                if (cropPrefab != null && selectedCropData != null)
                {
                    GameObject newCrop = Instantiate(cropPrefab, spawnPosition, Quaternion.identity);

                    CropBehaviour cropBehaviour = newCrop.GetComponent<CropBehaviour>();
                    if (cropBehaviour != null)
                    {
                        cropBehaviour.cropData = selectedCropData;
                    }

                    plantedCrops.Add(cellPosition, newCrop);

                    Debug.Log("Tarlaya tohum ekildi: " + cellPosition);
                }
            }
            // DURUM 3: HASAT MEKANÝÐÝ
            else
            {
                // Sözlük üzerinden o koordinattaki objeyi anýnda buluyoruz
                GameObject existingCrop = plantedCrops[cellPosition];
                CropBehaviour cropBehaviour = existingCrop.GetComponent<CropBehaviour>();

                if (cropBehaviour != null)
                {
                    // Bitki hasat edilebilir duruma gelmiþ mi?
                    if (cropBehaviour.isHarvestable)
                    {
                        // ScriptableObject içindeki min-max deðerlerine göre rastgele ürün miktarý hesapla
                        int harvestAmount = Random.Range(cropBehaviour.cropData.minHarvestAmount, cropBehaviour.cropData.maxHarvestAmount + 1);

                        // Singleton üzerinden InventoryManager'a ulaþ ve ürünü ekle
                        InventoryManager.Instance.AddItem(cropBehaviour.cropData.cropName, harvestAmount);

                        // 1. Objeyi sahneden (bellekten) sil
                        Destroy(existingCrop);

                        // 2. Sözlükten o koordinatýn kaydýný sil ki ileride tekrar tohum ekilebilsin
                        plantedCrops.Remove(cellPosition);

                        Debug.Log("HASAT BAÞARILI! Ürün toplandý: " + cellPosition);
                    }
                    else
                    {
                        Debug.Log("DÝKKAT: Ekin henüz büyüme aþamasýnda, hasat edilemez!");
                    }
                }
            }
        }
    }
}