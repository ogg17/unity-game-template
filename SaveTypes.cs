using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public abstract class SaveType<T> // base class for savable variables types
    {
        public T Value { get; set; }

        protected int intValue;
        protected string keyType; // unique key for type
    
        private readonly int index;
        private readonly string keySave; // unique key for instance 

        protected static List<string> keys = new List<string>();
        protected SaveType(string keySave, T value)
        {
            Value = value;
            var count = 0;
            foreach (var key in keys) if (key == keySave) count++;
            index = count;
            keys.Add(keySave);
            this.keySave = keySave;
        }

        public string GetKeySave() => keySave + "_" + keyType + "_" + index; // return completely key for save and load variable.
        public virtual void Save() { }
        public virtual void Load() { }
    }

    public class SaveLanguages : SaveType<Languages>
    {
        public SaveLanguages(string keySave, Languages value) : base(keySave, value)
        {
            keyType = "enum_languages"; 
            //Debug.Log("savelang constructor");
        }

        public override void Save()
        {
            intValue = (int)Value;
            PlayerPrefs.SetInt(GetKeySave(), intValue);
            //Debug.Log( "SAVE:" + GetKeySave() + "\n");
        }

        public override void Load()
        {
            intValue = PlayerPrefs.GetInt(GetKeySave());
            Value = (Languages)intValue;
            //Debug.Log( "LOAD:" + GetKeySave() + "\n");
        }
    }

    public class SaveInt : SaveType<int>
    {
        public SaveInt(string keySave, int value = 0) : base(keySave, value)
        {
            keyType = "int";
        }
    
        public override void Save()
        {
            PlayerPrefs.SetInt(GetKeySave(), Value);
            //Debug.Log( "SAVE:" + GetKeySave() + "\n");
        }

        public override void Load()
        {
            Value = PlayerPrefs.GetInt(GetKeySave());
            //Debug.Log( "LOAD:" + GetKeySave() + "\n");
        }
    }
    public class SaveBool : SaveType<bool>
    {
        public SaveBool(string keySave, bool value) : base(keySave, value)
        {
            keyType = "bool";
        }
    
        public override void Save()
        {
            intValue = Value ? 1 : 0;
            PlayerPrefs.SetInt(GetKeySave(), intValue);
            //Debug.Log( "SAVE:" + GetKeySave() + "\n");
        }

        public override void Load()
        {
            intValue = PlayerPrefs.GetInt(GetKeySave());
            Value = intValue != 0;
            //Debug.Log( "LOAD:" + GetKeySave() + "\n");
        }
    }
}