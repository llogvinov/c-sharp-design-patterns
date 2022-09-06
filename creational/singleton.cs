/* Одиночка (Singleton, Синглтон) - порождающий паттерн, который 
гарантирует, что для определенного класса будет создан только 
один объект, а также предоставит к этому объекту точку доступа. */

class Program
{
    static void Main(string[] args)
    {
        Computer comp = new Computer();
        comp.Launch("Windows 8.1");
        Console.WriteLine(comp.OS.Name);

        comp.OS = OS.GetInstance("Windows 10");
        Console.WriteLine(comp.OS.Name);
         
        Console.ReadLine();
    }
}

class Computer
{
    public OS OS { get; set; }
    
    public void Launch(string osName) => OS = OS.GetInstance(osName);
}

class OS
{
    private static OS instance;
    public string Name { get; private set; }
 
    protected OS(string name)
    {
        this.Name = name;
    }
 
    public static OS GetInstance(string name)
    {
        if (instance == null) 
            instance = new OS(name);
        
        return instance;
    }
}