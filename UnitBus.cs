using System.Collections.Generic;
using UnityEngine;

namespace Main
{
    public class UnitBus : MonoBehaviour
    {
        public static readonly Dictionary<string, BaseUnit> Units = new Dictionary<string, BaseUnit>();
        public static T GetUnit<T>() where T: BaseUnit => Units[typeof(T).Name] as T;
        public static T GetUnit<T>(string addKey) where T: BaseUnit => Units[typeof(T).Name + "_" + addKey] as T;

        private void Start()
        {
            foreach (var unit in Units)
            {
                unit.Value.OnStart();
            }
            InvokeRepeating(nameof(OneSecondUpdate), 1.0f, 1.0f);
        }

        private void Update()
        {
            foreach (var unit in Units)
            {
                unit.Value.OnUpdate();
            }
        }
        private void FixedUpdate()
        {
            foreach (var unit in Units)
            {
                unit.Value.OnFixedUpdate();
            }
        }

        private void OneSecondUpdate()
        {
            foreach (var unit in Units)
            {
                unit.Value.OnOneSecondUpdate();
            }
        }
    }
    
    [System.Serializable]
    public abstract class BaseUnit : MonoBehaviour
    {
        protected void Init() => UnitBus.Units.Add(this.GetType().Name, this);
        protected void Init(string addKey) => UnitBus.Units.Add(GetType().Name + "_" + addKey, this);
        public virtual void OnStart() { }
        public virtual void OnUpdate() { }
        public virtual void OnFixedUpdate() { }
        public virtual void OnOneSecondUpdate() { }
    }
}