using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnitySaveDataManager;

public class SaveDataManager : MonoBehaviour
{
    public string SaveDataFileName = "Game";
    
    private static string _SaveDataFileName = "Game";
    private static DataValues dataValues;

    private void Awake()
    {
        _SaveDataFileName = SaveDataFileName;
        if (!File.Exists(Application.persistentDataPath + "/" + _SaveDataFileName + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath + "/" + _SaveDataFileName + ".dat");
            dataValues = new DataValues();
            bf.Serialize(file, dataValues);
            file.Close();
        }
        load();
    }

    public static void SaveData(string key, object data)
    {
        dataValues.AddValue(key, data);
        save();
    }

    public static bool Contains(string Key)
    {
        return dataValues.ContainsKey(Key);
    }

    public static T GetData<T>(string key)
    {
        return (T)dataValues.GetValue(key);
    }

    static void save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/" + _SaveDataFileName + ".dat");
        bf.Serialize(file, dataValues);
        file.Close();
    }

    static void load()
    {
        if (File.Exists(Application.persistentDataPath + "/" + _SaveDataFileName + ".dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/" + _SaveDataFileName + ".dat", FileMode.Open);
            dataValues = (DataValues)bf.Deserialize(file);
            file.Close();
        }
    }

}

namespace UnitySaveDataManager
{
    [Serializable]
    class DataValues
    {
        Dictionary<string, object> Datas;

        public DataValues()
        {
            Datas = new Dictionary<string, object>();
        }

        public void AddValue(string key, object value)
        {
            if (Datas.ContainsKey(key))
            {
                Datas[key] = value;
            }
            else
            {
                Datas.Add(key, value);
            }
        }

        public bool ContainsKey(string key)
        {
            return Datas.ContainsKey(key);
        }

        public object GetValue(string key)
        {
            if (Datas.ContainsKey(key))
            {
                return Datas[key];
            }
            Debug.LogError("Key doesn't exist");
            return null;
        }
    }
}

