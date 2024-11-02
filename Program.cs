// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

#region Client

Document document = new Document();
ICommand openCommand = new OpenCommand(document);
ICommand saveCommand = new SaveCommand(document);
ICommand closeCommand = new CloseCommand(document);

Menutions menu = new Menutions(openCommand, saveCommand, closeCommand);

menu.ClickOpen();
menu.ClickSave();
menu.ClickClose();
Console.ReadLine();

#endregion


#region Receiver

public class Document
{
    public void Open()
    {
        Console.WriteLine("Document Opened");
    }

    public void Save()
    {
        Console.WriteLine("Document Saved");
    }

    public void Close()
    {
        Console.WriteLine("Document Closed");
    }
}

#endregion

#region Command

public interface ICommand
{
    void Execute();
}

#endregion

#region ConcreteCommand A

public class OpenCommand : ICommand
{
    private Document document;
    public OpenCommand(Document doc)
    {
        document = doc;
    }

    public void Execute() 
    { 
        document.Open();
    }
}

#endregion

#region ConcreteCommand B

public class SaveCommand : ICommand
{
    private Document document;
    public SaveCommand(Document doc)
    {
        document = doc;
    }

    public void Execute()
    {
        document.Save();
    }
}

#endregion

#region ConcreteCommand C

public class CloseCommand : ICommand
{
    private Document document;
    public CloseCommand(Document doc)
    {
        document = doc;
    }

    public void Execute()
    {
        document.Close();
    }
}

#endregion

#region Invoker

public class Menutions
{
    private ICommand openCommand;
    private ICommand closeCommand;
    private ICommand saveCommand;

    public Menutions(ICommand open, ICommand save, ICommand close)
    {
        openCommand = open;
        closeCommand = close;
        saveCommand = save;
    }
    public void ClickOpen()
    {
        openCommand.Execute();
    }
    public void ClickSave()
    {
        saveCommand.Execute();
    }
    public void ClickClose()
    {
        closeCommand.Execute();
    }
}

#endregion