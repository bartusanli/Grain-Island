using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HotbarManager : MonoBehaviour
{
    public static HotbarManager Instance;

    [Header("Görsel Ayarlar")]
    public RectTransform highlightFrame;

    [Header("Hotbar Hücreleri")]
    public List<HotbarCell> hotbarCells;

    [Header("Seçilen Ürün Verisi")]
    public CropData selectedCropData;

    private int selectedCellIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnInventoryChanged += UpdateHotbar;
            UpdateHotbar();
        }

        UpdateHighlightPosition();
    }

    private void OnDestroy()
    {
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnInventoryChanged -= UpdateHotbar;
        }
    }

    void Update()
    {
        if (Keyboard.current != null)
        {
            if (Keyboard.current.digit1Key.wasPressedThisFrame) selectedCellIndex = 0;
            else if (Keyboard.current.digit2Key.wasPressedThisFrame) selectedCellIndex = 1;
            else if (Keyboard.current.digit3Key.wasPressedThisFrame) selectedCellIndex = 2;
            else if (Keyboard.current.digit4Key.wasPressedThisFrame) selectedCellIndex = 3;
            else if (Keyboard.current.digit5Key.wasPressedThisFrame) selectedCellIndex = 4;
            else if (Keyboard.current.digit6Key.wasPressedThisFrame) selectedCellIndex = 5;
            else if (Keyboard.current.digit7Key.wasPressedThisFrame) selectedCellIndex = 6;
            else if (Keyboard.current.digit8Key.wasPressedThisFrame) selectedCellIndex = 7;
            else if (Keyboard.current.digit9Key.wasPressedThisFrame) selectedCellIndex = 8;
            else if (Keyboard.current.digit0Key.wasPressedThisFrame) selectedCellIndex = 9;

            UpdateHighlightPosition();
        }
    }

    private void UpdateHighlightPosition()
    {
        if (highlightFrame != null && hotbarCells.Count > selectedCellIndex)
        {
            highlightFrame.anchoredPosition = hotbarCells[selectedCellIndex].GetComponent<RectTransform>().anchoredPosition;
        }
    }

    private void UpdateHotbar(string itemName = "", int amount = 0)
    {
        foreach (HotbarCell cell in hotbarCells)
        {
            cell.Clear();
        }

        if (selectedCropData != null && selectedCropData.cropIcon != null)
        {
            hotbarCells[0].Setup(selectedCropData.cropIcon, amount); // Þimdilik sadece ilk hücreye çileði koyuyoruz
        }
    }
}