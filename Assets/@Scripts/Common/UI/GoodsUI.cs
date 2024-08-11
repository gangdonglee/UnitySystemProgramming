using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GoodsUI : MonoBehaviour
{
    public TextMeshProUGUI GoldAmountTxt;
    public TextMeshProUGUI GemAmountTxt;

    public void SetValues()
    {
        var userGoodsData = UserDataManager.Instance.GetUserData<UserGoodsData>();

        if(userGoodsData == null )
        {
            Logger.LogError("No user goods data");
        }
        else
        {
            GoldAmountTxt.text = userGoodsData.Gold.ToString("N0"); // N0´Â 1000´ÜÀ§ºÎÅÍ ½°Ç¥ Âï¾îÁÜ
            GemAmountTxt.text = userGoodsData.Gem.ToString("N0");

        }
    }
}
