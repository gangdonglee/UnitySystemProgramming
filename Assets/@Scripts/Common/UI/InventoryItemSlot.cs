using Gpm.Ui;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class InventoryItemSlotData : InfiniteScrollData 
{
    public long SerialNumber;
    public int ItemId;
}

public class InventoryItemSlot : InfiniteScrollItem
{
    public Image ItemGradeBg;
    public Image ItemIcon;

    private InventoryItemSlotData m_InventoryItemSlotData;

    public override void UpdateData(InfiniteScrollData scrollData)
    {
        base.UpdateData(scrollData);

        m_InventoryItemSlotData = scrollData as InventoryItemSlotData;
        if(m_InventoryItemSlotData == null )
        {
            Logger.Log("m_InventoryItemSlotData is invalid.");
            return;
        }

        var itemGrade = (ItemGrade)((m_InventoryItemSlotData.ItemId / 1000) % 10);
        var gradeBgTexture = Resources.Load<Texture2D>($"Textures/{itemGrade}");
        if(gradeBgTexture != null )
        {
            ItemGradeBg.sprite = Sprite.Create(gradeBgTexture, new Rect(0, 0, gradeBgTexture.width, gradeBgTexture.height), new Vector2(1, 1));
        }
        
        StringBuilder sb = new StringBuilder(m_InventoryItemSlotData.ItemId.ToString());
        sb[1] = '1';
        var itemIconName = sb.ToString();

        var itemIconTexture = Resources.Load<Texture2D>($"Textures/{itemIconName}");
        if (itemIconTexture != null)
        {
            ItemIcon.sprite = Sprite.Create(itemIconTexture, new Rect(0, 0, itemIconTexture.width, itemIconTexture.height), new Vector2(1, 1));
        }
    }
}
