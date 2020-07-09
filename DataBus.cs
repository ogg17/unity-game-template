using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class DataBus : MonoBehaviour
    {
        public static readonly Dictionary<string, LocalData> Data = new Dictionary<string, LocalData>();

        public static T GetData<T>() where T : LocalData => Data[typeof(T).Name] as T;
        

        private void Start()
        {
            foreach (var data in Data)
            {
                data.Value.OnStart();
            }
        }

        public static void Save()
        {
            foreach (var data in Data)
            {
                data.Value.Save();
            }
        }

        public static void Load()
        {
            foreach (var data in Data)
            {
                data.Value.Load();
            }
        }
    }

    public abstract class LocalData: ScriptableObject
    {
        protected void Init() => DataBus.Data.Add(GetType().Name, this);
        public virtual void OnStart() { }
        public virtual void Save() { }
        public virtual void Load() { }
    }
}