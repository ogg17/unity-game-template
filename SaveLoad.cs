using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    private void Start()
    {
        Load();
    }
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus) Save();
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private static void Save() => DataBus.Save();
    private static void Load() => DataBus.Load();

}