/* Паттерн Стратегия (Strategy) представляет шаблон 
проектирования, который определяет набор алгоритмов, 
инкапсулирует каждый из них и обеспечивает их взаимозаменяемость. 
В зависимости от ситуации мы можем легко заменить один 
используемый алгоритм другим. При этом замена алгоритма 
происходит независимо от объекта, который использует данный алгоритм. */

class Program
{
    static void Main(string[] args)
    {
        Car auto = new Car(4, "Volvo", new PetrolMove());
        auto.Move();
        
        auto.Movable = new ElectricMove();
        auto.Move();
 
        Console.ReadLine();
    }
}

interface IMovable
{
    void Move();
}
 
class PetrolMove : IMovable
{
    public void Move() => Console.WriteLine("Перемещение на бензине");
}
 
class ElectricMove : IMovable
{
    public void Move() => Console.WriteLine("Перемещение на электричестве");
}

class Car
{
    protected int passengers;
    protected string model;
    public IMovable Movable { private get; set; }
 
    public Car(int num, string model, IMovable mov)
    {
        this.passengers = num;
        this.model = model;
        Movable = mov;
    }

    public void Move() => Movable.Move();
}