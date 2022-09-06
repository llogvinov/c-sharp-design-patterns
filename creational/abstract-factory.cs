/* Паттерн Абстрактная фабрика (Abstract Factory) 
предоставляет интерфейс для создания семейств 
взаимосвязанных объектов с определенными интерфейсами 
без указания конкретных типов данных объектов. */

class Program
{
    static void Main(string[] args)
    {
        Hero elf = new Hero(new ElfFactory());
        elf.Hit();
        elf.Run();
 
        Hero voin = new Hero(new VoinFactory());
        voin.Hit();
        voin.Run();
 
        Console.ReadLine();
    }
}

abstract class Weapon
{
    public abstract void Hit();
}

class Arbalet : Weapon
{
    public override void Hit() => Console.WriteLine("Стреляем из арбалета");
}

class Sword : Weapon
{
    public override void Hit() => Console.WriteLine("Бьем мечом");
}

abstract class Movement
{
    public abstract void Move();
}

class FlyMovement : Movement
{
    public override void Move() => Console.WriteLine("Летим");
}

class RunMovement : Movement
{
    public override void Move() => Console.WriteLine("Бежим");
}

// abstract factory
abstract class HeroFactory
{
    public abstract Movement CreateMovement();
    public abstract Weapon CreateWeapon();
}

class ElfFactory : HeroFactory
{
    public override Movement CreateMovement() => new FlyMovement();
    public override Weapon CreateWeapon() => new Arbalet();
}

class VoinFactory : HeroFactory
{
    public override Movement CreateMovement() => new RunMovement();
    public override Weapon CreateWeapon() => new Sword();
}

class Hero
{
    private Weapon weapon;
    private Movement movement;
    
    public Hero(HeroFactory factory)
    {
        weapon = factory.CreateWeapon();
        movement = factory.CreateMovement();
    }
    
    public void Run() => movement.Move();
    
    public void Hit() => weapon.Hit();
}