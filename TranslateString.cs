using UnityEngine;

namespace Main
{
    public enum Languages
    {
        Russian,
        English
    }
    
    [System.Serializable]
    public class TranslateString
    {
        [SerializeField] private string english;
        [SerializeField] private string russian;
        [SerializeField] private int rusFontSize = 8;
        [SerializeField] private int engFontSize = 8;

        public TranslateString(string english, string russian)
        {
            this.english = english;
            this.russian = russian;
        }

        public int GetFontSize()
        {
            switch (GameSettings.language.Value)
            {
                case Languages.English:
                    return engFontSize;
                case Languages.Russian:
                    return rusFontSize;
            }
            return engFontSize;
        }

        public static implicit operator string(TranslateString value)
        {
            switch (GameSettings.language.Value)
            {
                case Languages.English:
                    return value.english;
                case Languages.Russian:
                    return value.russian;
                default:
                    return value.english;
            }
        }
    }
}