using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public class ChapterData
{
    public int ChapterNo;
    public int TotalStages;
    public int ChapterRewardGem;
    public int ChapterRewardGold;
}

public class ItemData
{
    public int ItemId;
    public string ItemName;
    public int AttackPower;
    public int Defense;
}

public enum ItemType
{
    Weapon = 1,
    Shield,
    ChestArmor,
    Gloves,
    Boots,
    Accessory
}

public enum ItemGrade
{
    Common = 1,
    Uncommon,
    Rare,
    Epic,
    Legendary
}

public class DataTableManager : SingletonBehaviour<DataTableManager>
{
    const string DATA_PATH = "DataTable";
    const string CHAPTER_DATA_TABLE = "ChapterDataTable";

    protected override void Init()
    {
        base.Init();

        LoadChapterDataTable();
        LoadItemDataTable();
    }
    #region CHAPTER_DATA
    private List<ChapterData> ChapterDataTable = new List<ChapterData>();

    private void LoadChapterDataTable()
    {
        var parsedDataTable = CSVReader.Read($"{DATA_PATH}/{CHAPTER_DATA_TABLE}");

        foreach (var data in parsedDataTable)
        {
            var chapterData = new ChapterData
            {
                ChapterNo = Convert.ToInt32(data["chapter_no"]),
                TotalStages = Convert.ToInt32(data["total_stages"]),
                ChapterRewardGem = Convert.ToInt32(data["chapter_reward_gem"]),
                ChapterRewardGold = Convert.ToInt32(data["chapter_reward_gold"]),
            };

            ChapterDataTable.Add(chapterData);
        }
    }
    public ChapterData GetChapterData(int chapterNo)
    {
        return ChapterDataTable.Where(item => item.ChapterNo == chapterNo).FirstOrDefault();
    }
    #endregion

    #region ITEM_DATA
    private const string ITEM_DATA_TABLE = "ItemDataTable";
    private List<ItemData> ItemDataTable = new List<ItemData>();

    private void LoadItemDataTable()
    {
        var parsedDataTable = CSVReader.Read($"{DATA_PATH}/{ITEM_DATA_TABLE}");

        foreach(var data in parsedDataTable)
        {
            var itemData = new ItemData
            {
                ItemId = Convert.ToInt32(data["item_id"]),
                ItemName = data["item_name"].ToString(),
                AttackPower = Convert.ToInt32(data["attack_power"]),
                Defense = Convert.ToInt32(data["defense"]),
            };

            ItemDataTable.Add(itemData);
        }

    }

    public ItemData GetItemData(int itemId)
    {
        return ItemDataTable.Where(item => item.ItemId == itemId).FirstOrDefault();
    }
    #endregion
}
