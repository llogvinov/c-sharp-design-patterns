/* Строитель (Builder) - шаблон проектирования, который инкапсулирует 
создание объекта и позволяет разделить его на различные этапы. */

class Program
{
    static void Main(string[] args)
    {
        Baker baker = new Baker();
        
        BreadBuilder builder = new RyeBreadBuilder();
        Bread ryeBread = baker.Bake(builder);
        Console.WriteLine(ryeBread.ToString());
        
        builder = new WheatBreadBuilder();
        Bread wheatBread = baker.Bake(builder);
        Console.WriteLine(wheatBread.ToString());
 
        Console.ReadLine();
    }
}

class Baker
{
    public Bread Bake(BreadBuilder breadBuilder)
    {
        breadBuilder.CreateBread();
        breadBuilder.SetFlour();
        breadBuilder.SetSalt();
        breadBuilder.SetAdditives();
        
        return breadBuilder.Bread;
    }
}
 
class Bread
{
    public Flour Flour { get; set; }
    public Salt Salt { get; set; }
    public Additives Additives { get; set; }
    
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
 
        if (Flour != null) sb.Append(Flour.Sort + "\n");
        if (Salt != null) sb.Append("Соль \n");
        if (Additives != null) sb.Append("Добавки: "+Additives.Name+" \n");
        
        return sb.ToString();
    }
}

abstract class BreadBuilder
{
    public Bread Bread { get; private set; }
    
    public void CreateBread()
    {
        Bread = new Bread();
    }

    public abstract void SetFlour();
    public abstract void SetSalt();
    public abstract void SetAdditives();
}

class RyeBreadBuilder : BreadBuilder
{
    public override void SetFlour()
        => this.Bread.Flour = new Flour { Sort = "Ржаная мука 1 сорт" };
 
    public override void SetSalt()
        => this.Bread.Salt = new Salt();
 
    public override void SetAdditives()
    { }
}

class WheatBreadBuilder : BreadBuilder
{
    public override void SetFlour()
        => this.Bread.Flour = new Flour { Sort = "Пшеничная мука высший сорт" };
 
    public override void SetSalt()
        => this.Bread.Salt = new Salt();
 
    public override void SetAdditives()
        => this.Bread.Additives = new Additives { Name = "улучшитель хлебопекарный" };
}

class Flour
{
    public string Sort { get; set; }
}

class Salt
{ }

class Additives
{
    public string Name { get; set; }
}