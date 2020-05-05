using System.Collections.Generic;
using UnityEngine;

public class UnitBus : MonoBehaviour
{
    public static readonly Dictionary<string, BaseUnit> Units = new Dictionary<string, BaseUnit>();
    public static T GetUnit<T>() where T: BaseUnit => Units[BaseUnit.Key] as T;

    private void Start()
    {
        foreach (var unit in Units)
        {
            unit.Value.OnStart();
        }
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
}
    
[System.Serializable]
public abstract class BaseUnit : MonoBehaviour
{
    public static string Key {get; private set; }
    protected void Init(string key)
    {
        Key = key;
        UnitBus.Units.Add(Key, this);
    }
    public virtual void OnStart() { }
    public virtual void OnUpdate() { }
    public virtual void OnFixedUpdate() { }
}