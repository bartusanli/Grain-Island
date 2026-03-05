using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.InputSystem; // Yeni Giriþ Sistemi eklendi

public class InteractionSystem : MonoBehaviour
{
    [Header("Sistem Referanslarý")]
    public Camera mainCamera;
    public Grid mapGrid;
    public Tilemap interactableTilemap;

    [Header("Görsel Geri Bildirim")]
    public TileBase tilledSoilTile;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // Yeni sistemde farenin sol tuþuna basýlýp basýlmadýðýný kontrol et
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            HandleClickInteraction();
        }
    }

    private void HandleClickInteraction()
    {
        // Yeni sistemde farenin ekrandaki piksel pozisyonunu okuma
        Vector2 screenPosition = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(screenPosition);

        // 2D düzlemde çalýþtýðýmýz için Z eksenini sýfýrlýyoruz
        mouseWorldPos.z = 0f;

        Vector3Int cellPosition = mapGrid.WorldToCell(mouseWorldPos);

        Debug.Log("Týklanan Hücre Koordinatý: " + cellPosition);

        if (interactableTilemap.HasTile(cellPosition))
        {
            Debug.Log("BAÞARILI: Bu hücrede Interactable Tile var!");

            if (tilledSoilTile != null)
            {
                interactableTilemap.SetTile(cellPosition, tilledSoilTile);
            }
        }
        else
        {
            Debug.Log("HATA: Bu hücrede Interactable Tile YOK. (Belki boþluða ya da Ground'a týkladýn?)");
        }
    }
}