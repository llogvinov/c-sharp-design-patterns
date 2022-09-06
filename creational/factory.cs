/* Фабричный метод (Factory Method) - это паттерн, который 
определяет интерфейс для создания объектов некоторого класса, 
но непосредственное решение о том, объект какого класса 
создавать происходит в подклассах. То есть паттерн предполагает, 
что базовый класс делегирует создание объектов классам-наследникам. */

class Program
{
    static void Main(string[] args)
    {
        Developer dev = new PanelDeveloper("ООО КирпичСтрой");
        House house2 = dev.Create();
        
        dev = new WoodDeveloper("Частный застройщик");
        House house = dev.Create();
 
        Console.ReadLine();
    }
}

abstract class Developer
{
    public string Name { get; set; }
 
    public Developer (string n)
    { 
        Name = n; 
    }

    abstract public House Create();
}

class PanelDeveloper : Developer
{
    public PanelDeveloper(string n) : base(n)
    { }
 
    public override House Create() => new PanelHouse();
}

class WoodDeveloper : Developer
{ 
    public WoodDeveloper(string n) : base(n)
    { }
 
    public override House Create() => new WoodHouse();
}
 
abstract class House
{ }
 
class PanelHouse : House 
{ 
    public PanelHouse() => Console.WriteLine("Панельный дом построен");
}

class WoodHouse : House
{ 
    public WoodHouse() => Console.WriteLine("Деревянный дом построен");
}