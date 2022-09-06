/* Паттерн Наблюдатель (Observer) представляет поведенческий 
шаблон проектирования, который использует отношение "один ко многим". 
В этом отношении есть один наблюдаемый объект и множество наблюдателей. 
И при изменении наблюдаемого объекта автоматически происходит 
оповещение всех наблюдателей. */

class Program
{
    static void Main(string[] args)
    {
        Stock stock = new Stock();
        Bank bank = new Bank("ЮнитБанк", stock);
        Broker broker = new Broker("Иван Иваныч", stock);

        stock.Market();
        broker.StopTrade();
        stock.Market();
 
        Console.ReadLine();
    }
}
 
interface IObservable
{
    void RegisterObserver(IObserver o);
    void RemoveObserver(IObserver o);
    void NotifyObservers();
}
 
class Stock : IObservable
{
    StockInfo sInfo;
    List<IObserver> observers;
    
    public Stock()
    {
        observers = new List<IObserver>();
        sInfo= new StockInfo();
    }

    public void RegisterObserver(IObserver o) => observers.Add(o);
    public void RemoveObserver(IObserver o) => observers.Remove(o);
 
    public void NotifyObservers()
    {
        foreach(IObserver o in observers)
        {
            o.Update(sInfo);
        }
    }
 
    public void Market()
    {
        Random rnd = new Random();
        sInfo.USD = rnd.Next(20, 40);
        sInfo.Euro = rnd.Next(30, 50);
        NotifyObservers();
    }
}

class StockInfo
{
    public int USD { get; set; }
    public int Euro { get; set; }
}

interface IObserver
{
    void Update(Object ob);
}

class Broker : IObserver
{
    public string Name { get; set; }
    IObservable stock;
    
    public Broker(string name, IObservable obs)
    {
        this.Name = name;
        stock = obs;
        stock.RegisterObserver(this);
    }
    
    public void Update(object ob)
    {
        StockInfo sInfo = (StockInfo)ob;
 
        if (sInfo.USD > 30)
            Console.WriteLine("Брокер {0} продает доллары; Курс доллара: {1}", this.Name, sInfo.USD);
        else
            Console.WriteLine("Брокер {0} покупает доллары; Курс доллара: {1}", this.Name, sInfo.USD);
    }
    
    public void StopTrade()
    {
        stock.RemoveObserver(this);
        stock = null;
    }
}
 
class Bank : IObserver
{
    public string Name { get; set; }
    IObservable stock;
    
    public Bank(string name, IObservable obs)
    {
        this.Name = name;
        stock = obs;
        stock.RegisterObserver(this);
    }
    
    public void Update(object ob)
    {
        StockInfo sInfo = (StockInfo)ob;
 
        if (sInfo.Euro > 40)
            Console.WriteLine("Банк {0} продает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
        else
            Console.WriteLine("Банк {0} покупает евро;  Курс евро: {1}", this.Name, sInfo.Euro);
    }
}