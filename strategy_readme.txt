﻿Паттерн "Стратегия" (Strategy) — это поведенческий шаблон проектирования, который позволяет инкапсулировать различные алгоритмы внутри отдельных классов и делать их взаимозаменяемыми. Этот подход даёт возможность выбирать подходящий алгоритм во время выполнения программы без изменения клиентского кода.
Основные компоненты паттерна Стратегии:
1.	Контекст (Context) — класс, который содержит ссылку на стратегию и делегирует выполнение поведения выбранной стратегии.
2.	Интерфейс стратегии (Strategy Interface) — определяет общий интерфейс для всех конкретных стратегий.
3.	Конкретная стратегия (Concrete Strategy) — реализует определённый алгоритм в рамках интерфейса стратегии.

1.	Инкапсуляция алгоритма: Алгоритм отделяется от контекста, что делает код более гибким и поддерживает принцип единственной ответственности (Single Responsibility Principle).
2.	Поддержка открытых/закрытых принципов: Легко добавить новую стратегию без изменения существующего кода.
3.	Упрощение тестирования: Поскольку каждый алгоритм реализован отдельно, тестирование становится проще и понятнее.
4.	Легкость замены алгоритмов: Клиенты могут переключать стратегии во время выполнения программы, просто передавая нужный объект стратегии.
Использование паттерна Стратегия помогает сделать ваш код более модульным, расширяемым и поддерживаемым.

