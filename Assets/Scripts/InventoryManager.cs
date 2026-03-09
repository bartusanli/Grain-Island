using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    // Olay (Event): Ürün adý ve yeni miktarýný dinleyenlere iletir
    public event Action<string, int> OnInventoryChanged;

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

    public void AddItem(string itemName, int amount)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName] += amount;
        }
        else
        {
            inventory.Add(itemName, amount);
        }

        Debug.Log($"Envantere Eklendi: {amount} adet {itemName}. Toplam: {inventory[itemName]}");

        // UI veya diðer sistemleri haberdar etmek için olayý tetikle
        OnInventoryChanged?.Invoke(itemName, inventory[itemName]);
    }
}