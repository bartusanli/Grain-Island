using System.Collections.Generic; // Dictionary kullanmak için gerekli kütüphane
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

    // YENÝ: Hangi koordinata ekin ektiðimizi hafýzada tutacak sözlük (Dictionary)
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
            // Týkladýðýmýz hücredeki GÜNCEL görseli (Tile) alýyoruz
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

                    // Ektiðimiz tohumu, koordinatýyla birlikte hafýzaya (Dictionary) kaydediyoruz
                    plantedCrops.Add(cellPosition, newCrop);

                    Debug.Log("Tarlaya tohum ekildi: " + cellPosition);
                }
            }
            // DURUM 3: Toprak tarla yapýlmýþ ve zaten tohum ekilmiþse (Üst üste binmeyi engeller)
            else
            {
                Debug.Log("DÝKKAT: Burada zaten büyümekte olan bir ekin var!");

                // Ýpucu: Bir sonraki aþamada "Hasat Mekaniðini" tam olarak bu bloðun içine yazacaðýz!
            }
        }
    }
}