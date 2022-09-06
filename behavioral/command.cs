/* Паттерн Команда (Command) позволяет инкапсулировать 
запрос на выполнение определенного действия в виде 
отдельного объекта. Этот объект запроса на действие и 
называется командой. При этом объекты, инициирующие 
запросы на выполнение действия, отделяются от объектов, 
которые выполняют это действие. Команды могут использовать 
параметры, которые передают ассоциированную с командой 
информацию. Кроме того, команды могут ставиться в очередь 
и также могут быть отменены. */

class Program
{
    static void Main(string[] args)
    {
        Pult pult = new Pult();
        TV tv = new TV();
        
        pult.SetCommand(new TVOnCommand(tv));
        pult.PressButton();
        pult.PressUndo();
        
        Microwave microwave = new Microwave
        pult.SetCommand(new MicrowaveCommand(microwave, 5000));
        pult.PressButton();

        Console.Read();
    }
}

class Pult
{
    ICommand command;
 
    public void SetCommand(ICommand com) => command = com;
    public void PressButton() => command.Execute();
    public void PressUndo() => command.Undo();
}
 
interface ICommand
{
    void Execute();
    void Undo();
}

class TV
{ 
    public void On() => Console.WriteLine("Телевизор включен!");
    public void Off() => Console.WriteLine("Телевизор выключен...");
}
 
class TVOnCommand : ICommand
{
    TV tv;

    public TVOnCommand(TV tvSet)
    {
        tv = tvSet;
    }
    
    public void Execute() => tv.On();
    public void Undo() => tv.Off();
}

class Microwave
{
    public void StartCooking(int time)
    {
        Console.WriteLine("Подогреваем еду");
        Task.Delay(time).GetAwaiter().GetResult();
    }
 
    public void StopCooking() => Console.WriteLine("Еда подогрета!");
}

class MicrowaveCommand : ICommand
{
    Microwave microwave;
    int time;
    
    public MicrowaveCommand(Microwave m, int t)
    {
        microwave = m;
        time = t;
    }

    public void Execute()
    {
        microwave.StartCooking(time);
        microwave.StopCooking();
    }
 
    public void Undo() => microwave.StopCooking();
}