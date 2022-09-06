/* Декоратор (Decorator) представляет структурный шаблон 
проектирования, который позволяет динамически подключать 
к объекту дополнительную функциональность. Для определения 
нового функционала в классах нередко используется наследование. 
Декораторы же предоставляет наследованию более гибкую альтернативу, 
поскольку позволяют динамически в процессе выполнения определять 
новые возможности у объектов. */

class Program
{
    static void Main(string[] args)
    {
        Pizza pizza1 = new ItalianPizza();
        pizza1 = new TomatoPizza(pizza1); // итальянская пицца с томатами
        Console.WriteLine("Название: {0}", pizza1.Name);
        Console.WriteLine("Цена: {0}", pizza1.GetCost());
 
        Pizza pizza2 = new ItalianPizza();
        pizza2 = new CheesePizza(pizza2);// итальянская пиццы с сыром
        Console.WriteLine("Название: {0}", pizza2.Name);
        Console.WriteLine("Цена: {0}", pizza2.GetCost());
 
        Pizza pizza3 = new BulgerianPizza();
        pizza3 = new TomatoPizza(pizza3);
        pizza3 = new CheesePizza(pizza3);// болгарская пиццы с томатами и сыром
        Console.WriteLine("Название: {0}", pizza3.Name);
        Console.WriteLine("Цена: {0}", pizza3.GetCost());
 
        Console.ReadLine();
    }
}
 
abstract class Pizza
{
    public string Name {get; protected set;}

    public Pizza(string n)
    {
        this.Name = n;
    }
    
    public abstract int GetCost();
}
 
class ItalianPizza : Pizza
{
    public ItalianPizza() : base("Итальянская пицца")
    { }

    public override int GetCost() => 10;
}

class BulgerianPizza : Pizza
{
    public BulgerianPizza()
        : base("Болгарская пицца")
    { }
    
    public override int GetCost() => 8;
}
 
abstract class PizzaDecorator : Pizza
{
    protected Pizza pizza;
    
    public PizzaDecorator(string n, Pizza pizza) : base(n)
    {
        this.pizza = pizza;
    }
}
 
class TomatoPizza : PizzaDecorator
{
    public TomatoPizza(Pizza p) 
        : base(p.Name + ", с томатами", p)
    { }
 
    public override int GetCost() => pizza.GetCost() + 3;
}
 
class CheesePizza : PizzaDecorator
{
    public CheesePizza(Pizza p)
        : base(p.Name + ", с сыром", p)
    { }
 
    public override int GetCost() => pizza.GetCost() + 5;
}