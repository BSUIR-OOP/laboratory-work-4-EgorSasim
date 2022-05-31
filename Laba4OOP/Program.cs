using DILibrary;

namespace Laba4OOP // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var service = new ServiceCollection();

                service.AddSingleton<IMessageWriter, MessageWriter>();

                var container = service.GenerateContainer();

                var a = container.GetService<IMessageWriter>();
                var b = container.GetService<IMessageWriter>();

                var service2 = new ServiceCollection();

                service2.AddTransient<IMessageWriter, MessageWriter>();

                var container2 = service2.GenerateContainer();

                var c = container2.GetService<IMessageWriter>();
                var d = container2.GetService<IMessageWriter>();
                service.AddTransient<IMessageWriter, MessageWriter>();


                a.Write();
                b.Write();
                c.Write();
                d.Write();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            
        }
    }
}