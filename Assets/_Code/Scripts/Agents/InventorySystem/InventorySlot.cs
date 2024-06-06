using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventorySlot : MonoBehaviour
{
    public ItenDataSO inventoryItem;
    public Button button;

    [SerializeField]
    private Color defaultColor;

    public void RestoreSlotDefaultSettings()
    {
        inventoryItem = null;
        button.image.sprite = null;
        button.image.color = defaultColor;
    }
}
