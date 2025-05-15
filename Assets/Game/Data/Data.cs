namespace YG
{
    public partial class SavesYG
    {
        // Ваши данные для сохранения
        public int coins = 5; // Пример
        public GameData gameData;
    }
}

[System.Serializable]
public struct GameData
{
    public int money;
}