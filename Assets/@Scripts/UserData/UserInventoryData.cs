using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class UserItemData
{
    public long SerialNumber; // unique value
    public int ItemId;

    public UserItemData(long serialNumber, int itemId)
    {
        SerialNumber = serialNumber; 
        ItemId = itemId;
    }
}

//wrapper class to parse data to JSON using JSONUtility
[Serializable]
public class UserInventoryItemDataListWrapper
{
    public List<UserItemData> InventoryItemDataList;
}

public class UserInventoryData : IUserData  
{
    public List<UserItemData> InventoryItemDataList { get; set; } = new List<UserItemData>();

    public bool LoadData()
    {
        Logger.Log($"{GetType()}::LoadData");

        bool result = false;

        try
        {
            string inventoryItemDataListJson = PlayerPrefs.GetString("InventoryItemDataList");

            if(!string.IsNullOrEmpty(inventoryItemDataListJson))
            {
                UserInventoryItemDataListWrapper itemDataListWrapper = JsonUtility.FromJson<UserInventoryItemDataListWrapper>(inventoryItemDataListJson);
                InventoryItemDataList = itemDataListWrapper.InventoryItemDataList;
            }

            Logger.Log("InventoryItemDataList");
            foreach (var item in InventoryItemDataList)
            {
                Logger.Log($"SerialNumber:{item.SerialNumber} ItemId:{item.ItemId}");
            }

            result = true;
        }
        catch (System.Exception e)
        {
            Logger.Log("Load failed + (" + e.Message + ")");
        }

        return result;
    }

    public bool SaveData()
    {
        Logger.Log($"{GetType()}::SaveData");
        bool result = false;

        try
        {
            UserInventoryItemDataListWrapper inventoryItemDataListWrapper = new UserInventoryItemDataListWrapper();
            inventoryItemDataListWrapper.InventoryItemDataList = InventoryItemDataList;
            string inventoryItemDataListJson = JsonUtility.ToJson(inventoryItemDataListWrapper);
            PlayerPrefs.SetString("InventoryItemDataList", inventoryItemDataListJson);

            Logger.Log("InventoryItemDataList");
            
            foreach(var item in InventoryItemDataList)
            {
                Logger.Log($"SerialNumber:{item.SerialNumber} ItemId:{item.ItemId}");
            }

            result= true;
        }
        catch (System.Exception e)
        {
            Logger.Log("Load failed + (" + e.Message + ")");
        }

        return result;
    }
      
    public void SetDefaultData()
    {
        Logger.Log($"{GetType()}::SetDefaultData");

        // serial number => DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 11001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 11002));

        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 21001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 21002));

        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 31001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 31002));

        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 41001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 41002));

        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 51001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 51002));

        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 61001));
        InventoryItemDataList.Add(new UserItemData(long.Parse(DateTime.Now.ToString("yyyyMMddHHmmss") + UnityEngine.Random.Range(0, 9999).ToString("D4")), 61002));
    }
}
