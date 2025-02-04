namespace GameStateRestore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(1, 50);
            GameSaver saver = new GameSaver();

            // Сохраняем текущую игру
            saver.SaveGame(game);

            // Обновляем уровень и очки
            game.SetLevel(2);
            game.SetScore(150);

            Console.WriteLine("Current Level: " + game.GetLevel()); // 2
            Console.WriteLine("Current Score: " + game.GetScore()); // 150

            // Загружаем ранее сохраненную игру
            saver.LoadGame(game);

            Console.WriteLine("Current Level: " + game.GetLevel()); // 2
            Console.WriteLine("Current Score: " + game.GetScore()); // 150
        }
    }

    // Класс Originator
    class Game
    {
        private int level;
        private int score;

        public Game(int level, int score)
        {
            this.level = level;
            this.score = score;
        }

        public void SetLevel(int level)
        {
            this.level = level;
        }

        public void SetScore(int score)
        {
            this.score = score;
        }

        public int GetLevel()
        {
            return level;
        }

        public int GetScore()
        {
            return score;
        }

        // Метод для создания хранителя (memento)
        public GameMemento CreateMemento()
        {
            return new GameMemento(level, score);
        }

        // Метод для восстановления состояния из хранителя
        public void RestoreFromMemento(GameMemento memento)
        {
            level = memento.Level;
            score = memento.Score;
        }
    }

    // Класс Memento
    class GameMemento
    {
        public readonly int Level;
        public readonly int Score;

        public GameMemento(int level, int score)
        {
            Level = level;
            Score = score;
        }
    }

    // Класс Caretaker
    class GameSaver
    {
        private GameMemento savedGame;

        public void SaveGame(Game game)
        {
            savedGame = game.CreateMemento();
        }

        public void LoadGame(Game game)
        {
            if (savedGame != null)
            {
                game.RestoreFromMemento(savedGame);
            }
        }
    }
}
