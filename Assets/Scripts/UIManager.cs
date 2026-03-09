using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Metinleri")]
    public TMP_Text strawberryText;
    public TMP_Text goldText;

    private void Start()
    {
        // Oyundaki olay kanalýna (Event Channel) abone ol
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnInventoryChanged += UpdateUI;

            // Oyun baþladýðýnda metinleri sýfýrla
            UpdateUI("Çilek", 0);
            UpdateUI("Altýn", 0);
        }
    }

    private void OnDestroy()
    {
        // Obje yok olursa aboneliði iptal et (Bellek sýzýntýsýný önler)
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.OnInventoryChanged -= UpdateUI;
        }
    }

    // Olay tetiklendiðinde otomatik çalýþan metot
    private void UpdateUI(string itemName, int amount)
    {
        // Not: Buradaki "Çilek" ismi, StrawberryData objendeki 'Crop Name' ile birebir ayný olmalýdýr.
        if (itemName == "Çilek")
        {
            if (strawberryText != null)
            {
                strawberryText.text = "Çilek: " + amount;
            }
        }
        else if (itemName == "Altýn")
        {
            if (goldText != null)
            {
                goldText.text = "Altýn: " + amount;
            }
        }
    }
}