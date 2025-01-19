namespace SoftwareDevelopmentProcess
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SoftwareDevelopmentProcess webDevProcess = new WebApplicationDevelopmentProcess();
            webDevProcess.DevelopSowftware();

            Console.WriteLine("\n\n");

            SoftwareDevelopmentProcess mobileDevProcess = new MobileAppDevelopmentProcess();
            mobileDevProcess.DevelopSowftware();
        }
    }

    abstract class SoftwareDevelopmentProcess
    {
        // Шаблонный метод
        public void DevelopSowftware()
        {
            GatherRequirments();
            DesignArchitecture();
            ImplementCode();
            TestAndDeploy();
        }

        // Шаги алгоритма
        protected abstract void GatherRequirments();
        protected abstract void DesignArchitecture();
        protected abstract void ImplementCode();
        protected abstract void TestAndDeploy();
    }

    class WebApplicationDevelopmentProcess : SoftwareDevelopmentProcess
    {
        protected override void DesignArchitecture()
        {
            Console.WriteLine("Design architecture for web application");
        }

        protected override void GatherRequirments()
        {
            Console.WriteLine("Gather requirements for web application");
        }

        protected override void ImplementCode()
        {
            Console.WriteLine("Coding web application");
        }

        protected override void TestAndDeploy()
        {
            Console.WriteLine("Test and deploy web application");
        }
    }

    class MobileAppDevelopmentProcess : SoftwareDevelopmentProcess
    {
        protected override void DesignArchitecture()
        {
            Console.WriteLine("Design architecture for mobile application");
        }

        protected override void GatherRequirments()
        {
            Console.WriteLine("Gather requirements for mobile application");
        }

        protected override void ImplementCode()
        {
            Console.WriteLine("Coding mobile application");
        }

        protected override void TestAndDeploy()
        {
            Console.WriteLine("Test and deploy mobile application");
        }
    }
}
