namespace Main
{
    public static class GameSettings
    {
        public static SaveLanguages language = new SaveLanguages("game_language", Languages.Russian);
        public static SaveBool isPause = new SaveBool("is_pause", false);
        public static SaveBool isSound = new SaveBool("is_sound", false);
        public static SaveBool isMusic = new SaveBool("is_music", false);
    }
}