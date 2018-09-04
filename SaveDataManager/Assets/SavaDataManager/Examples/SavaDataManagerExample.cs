using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SavaDataManagerExample : MonoBehaviour
{
    public Text KeyInputText;
    public Text ValueInputText;
    public Text KeyInputFindDataText;
    public Text DisplayValueText;

    public void SaveData()
    {
        SaveDataManager.SaveData(KeyInputText.text, ValueInputText.text);
    }

    public void GetData()
    {
        if (SaveDataManager.Contains(KeyInputFindDataText.text))
        {
            DisplayValueText.text = SaveDataManager.GetData<string>(KeyInputFindDataText.text);
        }
        else
        {
            DisplayValueText.text = "Data doesn't exist";
        }
    }
}
