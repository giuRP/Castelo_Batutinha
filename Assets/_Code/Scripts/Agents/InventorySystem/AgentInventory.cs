using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class AgentInventory : MonoBehaviour
{
    [SerializeField]
    private List<InventorySlot> inventorySlots = new List<InventorySlot>();
    [SerializeField]
    private int slotIndex;
    [SerializeField]
    private Image ampViewItemImage;
    private Agent agent;

    public UnityEvent OnPickUpIten;
    public UnityEvent OnUseRightItem;
    public UnityEvent OnUseWrongItem;

    public int maxSlots = 0;
    
    private void Awake()
    {
        agent = GetComponentInParent<Agent>();
        slotIndex = 0;
        maxSlots = 5;
    }

    public void PickUpIten(ItenDataSO itemData)
    {
        OnPickUpIten?.Invoke();
        AddItem(itemData);
    }

    public void UseItem(InventorySlot clikedSlot)
    {
        if (clikedSlot.inventoryItem == null)
            return;

        if(agent.lockAndKeyPuzzleInteracted == false)
        {
            Debug.Log("Este item não pode ser usado aqui");
            //OnUseWrongItem?.Invoke();

            SetAmpViewItemImage(clikedSlot.inventoryItem.itenImage);
        }
        else
        {
            if (clikedSlot.inventoryItem.UseIten())
            {
                RemoveItem(clikedSlot);
                OnUseRightItem?.Invoke();
                Time.timeScale = 1.0f;
                //agent.TransitionToState(agent.stateFactory.GetState(PlayerStateType.Idle));
            }
            else
            {
                Debug.Log("Este item não pode ser usado aqui");
                OnUseWrongItem?.Invoke();

                SetAmpViewItemImage(clikedSlot.inventoryItem.itenImage);
            }
        }
    }

    private void SetAmpViewItemImage(Sprite itemSprite)
    {
        if (ampViewItemImage == null)
            return;
        ampViewItemImage.color = Color.white;
        ampViewItemImage.sprite = itemSprite;
    }

    public void ResetAmpViewItemImage()
    {
        ampViewItemImage.color = Color.black;
        ampViewItemImage.sprite = null;
    }

    public void AddItem(ItenDataSO itemData)
    {
        if(slotIndex >= maxSlots)
        {
            Debug.Log("Inventário está cheio");
            return;
        }

        if (inventorySlots[slotIndex].inventoryItem == itemData)
            return;

        inventorySlots[slotIndex].inventoryItem = itemData;
        inventorySlots[slotIndex].button.image.sprite = itemData.itenImage;
        inventorySlots[slotIndex].button.image.color = Color.white;
        slotIndex++;
    }

    private void RemoveItem(InventorySlot clickedSlot)
    {
        clickedSlot.RestoreSlotDefaultSettings();
        ResetAmpViewItemImage();

        slotIndex--;
    }

    public void ReorganizeInventory()
    {
        for (int i = 1; i < inventorySlots.Count - 1; i++)
        {
            if (inventorySlots[i].inventoryItem != null && inventorySlots[i - 1].inventoryItem == null)
            {
                inventorySlots[i - 1].inventoryItem = inventorySlots[i].inventoryItem;
                inventorySlots[i - 1].button.image.sprite = inventorySlots[i].inventoryItem.itenImage;
                inventorySlots[i - 1].button.image.color = Color.white;
                inventorySlots[i].RestoreSlotDefaultSettings();
            }
        }
    }

    //Para o sistema de save
    public List<string> GetItenNames()
    {
        return inventorySlots.Select(item => item.inventoryItem.itenName).ToList();
    }
}
