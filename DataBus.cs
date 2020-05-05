using System.Collections.Generic;
using UnityEngine;

public class DataBus : MonoBehaviour
{
    public static Dictionary<string, LocalData> Datas = new Dictionary<string, LocalData>();
    public static T GetData<T>() where T: LocalData => Datas[LocalData.Key] as T;

    private void Start()
    {
        foreach (var data in Datas)
        {
            data.Value.OnStart();
        }
    }

    public static void Save()
    {
        foreach (var data in Datas)
        {
            data.Value.Save();
        }
    }

    public static void Load()
    {
        foreach (var data in Datas)
        {
            data.Value.Load();
        }
    }
}

public abstract class LocalData
{
    public static string Key { get; private set; }
    public void Init(string key)
    {
        Key = key;
        DataBus.Datas.Add(Key, this);
    }
        
    public virtual void OnStart() { }
    public virtual void Save() { }
    public virtual void Load() { }
}