using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class DataBus : MonoBehaviour
    {
        public static readonly Dictionary<string, LocalData> Data = new Dictionary<string, LocalData>();
        public static T GetData<T>() where T: LocalData => Data[nameof(T)] as T;

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

    public abstract class LocalData: MonoBehaviour
    {
        protected void Init(string key) => DataBus.Data.Add(key, this);
        public virtual void OnStart() { }
        public virtual void Save() { }
        public virtual void Load() { }
    }
}