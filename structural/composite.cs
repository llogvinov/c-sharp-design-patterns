/* Паттерн Компоновщик (Composite) объединяет группы объектов 
в древовидную структуру по принципу "часть-целое и позволяет 
клиенту одинаково работать как с отдельными объектами, так и с 
группой объектов. Образно реализацию паттерна можно представить 
в виде меню, которое имеет различные пункты. Эти пункты могут 
содержать подменю, в которых, в свою очередь, также имеются пункты. 
То есть пункт меню служит с одной стороны частью меню, а с другой 
стороны еще одним меню. В итоге мы однообразно можем работать как с 
пунктом меню, так и со всем меню в целом. */

class Program
{
    static void Main(string[] args)
    {
        Component fileSystem = new Directory("Файловая система");
        Component diskC = new Directory("Диск С");
        Component pngFile = new File("12345.png");
        Component docxFile = new File("Document.docx");
        diskC.Add(pngFile);
        diskC.Add(docxFile);
        fileSystem.Add(diskC);
        fileSystem.Print();
        Console.WriteLine();
        diskC.Remove(pngFile);

        Component docsFolder = new Directory("Мои Документы");
        Component txtFile = new File("readme.txt");
        Component csFile = new File("Program.cs");
        docsFolder.Add(txtFile);
        docsFolder.Add(csFile);
        diskC.Add(docsFolder);
        fileSystem.Print();
 
        Console.Read();
    }
}
 
abstract class Component
{
    protected string name;
 
    public Component(string name)
    {
        this.name = name;
    }
 
    public virtual void Add(Component component) { }
 
    public virtual void Remove(Component component) { }
 
    public virtual void Print() => Console.WriteLine(name);
}

class Directory : Component
{
    private List<Component> components = new List<Component>();
 
    public Directory(string name) : base(name)
    { }
 
    public override void Add(Component component)
        => components.Add(component);
 
    public override void Remove(Component component)
        => components.Remove(component);
 
    public override void Print()
    {
        Console.WriteLine("Узел " + name);
        Console.WriteLine("Подузлы: ");
        for(int i = 0; i < components.Count; i++)
        {
            components[i].Print();
        }
    }
}

class File : Component
{
    public File(string name) : base(name)
    { }
}