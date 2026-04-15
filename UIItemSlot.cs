using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class UIItemSlot : MonoBehaviour,IPointerDownHandler//接口
{
    [SerializeField]private Image itemimage;
    [SerializeField]private TextMeshProUGUI itemtext;

    public InventoryItem item;

    public void UpdateSlot(InventoryItem newitem)
    {
        item = newitem;

        itemimage.color = Color.white;

        if (itemimage != null)
        {
            itemimage.sprite = newitem.data.icon;

            if (newitem.stackSize > 1)
            {
                itemtext.text = newitem.stackSize.ToString();
            }
            else
            {
                itemtext.text = "";
            }
        }//设置物品数量和图形
    }

    public void CleanUpSlot()
    {
        item =null;
        itemimage.sprite = null;
        itemimage.color = Color.clear;
        itemtext.text = "";
    }

    public virtual void OnPointerDown(PointerEventData eventData)
    {
        if (item == null)
            return;

        if (Input.GetKey(KeyCode.LeftControl))
        {
            Inventory.instance.RemoveItem(item.data);
            return;
        }

        if(item.data.itemtype == ItemType.Equipment)
            Inventory.instance.EquipItem(item.data);
        
    }
}
