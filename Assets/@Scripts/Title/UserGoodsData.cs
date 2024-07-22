using Unity.VisualScripting;
using UnityEngine;

public class UserGoodsData : IUserData
{
    //º¸¼®
    public long Gem { get; set; }
    //°ñµå
    public long Gold { get; set; }

    public void SetDefaultData()
    {
        Logger.Log($"{GetType()}::SetDefaultData");

        Gem = 0;
        Gold = 0;
    }
    public bool LoadData()
    {
        Logger.Log($"{GetType()}::LoadData");

        bool result = false;

        try
        {
            Gem = long.Parse(PlayerPrefs.GetString("Gem"));
            Gold = long.Parse(PlayerPrefs.GetString("Gold"));
            result = true;

            Logger.Log($"Gem : {Gem} Gold : {Gold}");
        }
        catch (System.Exception e)
        {
            Logger.Log($"Load fail (" + e.Message + ")");
            throw;
        }
        return result;
    }

    public bool SaveData()
    {
        Logger.Log($"{GetType()}::SaveData");

        bool result = false;

        try
        {
            Gem = long.Parse(PlayerPrefs.GetString("Gem"));
            Gold = long.Parse(PlayerPrefs.GetString("Gold"));
            PlayerPrefs.Save();
            result = true;

            Logger.Log($"Gem : {Gem} Gold : {Gold}");
        }
        catch (System.Exception e)
        {
            Logger.Log($"Load fail (" + e.Message + ")");
        }
        return result;
    }
}
