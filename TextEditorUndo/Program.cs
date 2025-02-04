using System.Text;

namespace TextEditorUndo
{
    /*
    Поведенческий шаблон проектирования Хранитель (Memento) предназначен для сохранения состояния объекта
    таким образом, чтобы оно могло быть восстановлено позже, не нарушая инкапсуляцию.
    Это полезно, когда нужно сохранять состояние объекта, а затем возвращаться к нему,
    но при этом не раскрывать внутреннее устройство самого объекта.
    Основные компоненты шаблона Memento:
    1.	Originator – класс, состояние которого необходимо сохранить.
    2.	Caretaker – класс, который отвечает за сохранение и восстановление состояний Originator.
    3.	Memento – объект, содержащий сохраненное состояние Originator. Важно, что сам Memento предоставляет ограниченный доступ к своему содержимому, обеспечивая тем самым инкапсуляцию.
     */
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder text = new StringBuilder("Initial Text");
            Editor editor = new Editor(text);
            History history = new History();

            // Изменяем текст
            editor.SetText(new StringBuilder("New Text"));
            Console.WriteLine("Current Text: " + editor.GetText().ToString()); // New Text

            // Сохраняем текущее состояние
            history.SaveState(editor);

            // Еще одно изменение
            editor.SetText(new StringBuilder("Another Text"));
            Console.WriteLine("Current Text: " + editor.GetText().ToString()); // Another Text

            // Откатываемся назад
            history.Undo(editor);
            Console.WriteLine("Restored Text: " + editor.GetText().ToString()); // New Text
        }
    }

    // Класс Originator
    class Editor
    {
        private StringBuilder text;

        public Editor(StringBuilder text)
        {
            this.text = text;
        }

        public void SetText(StringBuilder text)
        {
            this.text = text;
        }

        public StringBuilder GetText()
        {
            return text;
        }

        // Метод для создания хранителя (memento)
        public EditorMemento CreateMemento()
        {
            return new EditorMemento(text.ToString());
        }

        // Метод для восстановления состояния из хранителя
        public void RestoreFromMemento(EditorMemento memento)
        {
            text.Clear();
            text.Append(memento.GetState());
        }
    }

    // Класс Memento
    class EditorMemento
    {
        private readonly string state;

        public EditorMemento(string state)
        {
            this.state = state;
        }

        public string GetState()
        {
            return state;
        }
    }

    // Класс Caretaker
    class History
    {
        private Stack<EditorMemento> history = new Stack<EditorMemento>();

        public void SaveState(Editor editor)
        {
            history.Push(editor.CreateMemento());
        }

        public void Undo(Editor editor)
        {
            if (history.Count > 0)
            {
                EditorMemento memento = history.Pop();
                editor.RestoreFromMemento(memento);
            }
        }
    }
}
