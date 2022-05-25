using ProgramNamespace.Abstracts;

namespace ProgramNamespace
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            Startup.Build();

            List<BaseCommand> _commands = new List<BaseCommand>();
            CommandFactory _commandFactory = new CommandFactory();
            FakeData _data = new FakeData();

            for (int i = 0; i < _data.PurchasingDocuments.Count; i++)
            {
                var cmd = _commandFactory.GenerateCommand(_data.PurchasingDocuments[i]);
                _commands.Add(cmd);

                try
                {
                    cmd.Execute();
                    //throw new Exception("Dupa");
                }
                catch (Exception ex)
                {
                    cmd.Revert();
                }

                _data.PurchasingDocuments[i] = cmd.DocumentAfterOperation;
            }
        }


    }
}