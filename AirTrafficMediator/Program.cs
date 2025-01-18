namespace AirTrafficMediator
{
    /*
    Представьте систему управления воздушным движением,
    где самолеты должны координировать свои действия через диспетчерскую вышку. 
    */
    internal class Program
    {
        static void Main(string[] args)
        {
            Tower tower = new Tower();

            Boeing747 boeing = new Boeing747(tower);
            AirbusA320 airbus = new AirbusA320(tower);

            tower.Register(boeing);
            tower.Register(airbus);

            boeing.SendMessage("Requesting permission to take off");
            airbus.SendMessage("I have problems with the engine");
        }
    }

    // Коллега
    abstract class Aircraft
    {
        protected AirTrafficControlMediator mediator;

        protected Aircraft(AirTrafficControlMediator mediator)
        {
            this.mediator = mediator;
        }

        public abstract void SendMessage(string message);
        public abstract void ReceiveMessage(string message);
    }

    // Конкретный коллега
    class Boeing747 : Aircraft
    {
        public Boeing747(AirTrafficControlMediator mediator) : base(mediator)
        {
        }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine($"Boeing 747: Received message - {message}");
        }

        public override void SendMessage(string message)
        {
            mediator.Send(message, this);
        }
    }

    // Конкретный коллега
    class AirbusA320 : Aircraft
    {
        public AirbusA320(AirTrafficControlMediator mediator) : base(mediator)
        {
        }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine($"Airbus A320: Received message - {message}");
        }

        public override void SendMessage(string message)
        {
            mediator.Send(message, this);
        }
    }

    // Посредник
    interface AirTrafficControlMediator
    {
        void Register(Aircraft aircraft);
        void Send(string message, Aircraft sender);
    }

    // Конкретный посредник
    class Tower : AirTrafficControlMediator
    {
        private Dictionary<string, Aircraft> aircrafts = new Dictionary<string, Aircraft>();

        public void Register(Aircraft aircraft)
        {
            aircrafts[aircraft.GetType().Name] = aircraft;
        }

        public void Send(string message, Aircraft sender)
        {
            foreach (KeyValuePair<string, Aircraft> pair in aircrafts)
            {
                if (pair.Value != sender)
                {
                    pair.Value.ReceiveMessage(message);
                }
            }
        }
    }
}
