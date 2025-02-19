//Originator
class Originator
{
    private string _state;

    public void SetState(string state)
    {
        _state = state;
    }

    public string GetState()
    {
        return _state;
    }

    public Memento CreateMemento()
    {
        return new Memento(_state);
    }

    public void RestoreMemento(Memento memento)
    {
        _state = memento.GetState();
    }
}

//Memento
class Memento
{
    private readonly string _state;

    public Memento(string state)
    {
        _state = state;
    }

    public string GetState()
    {
        return _state;
    }
}

using System.Collections.Generic;

//Caretaker
class Caretaker
{
    private List<Memento> _mementos = new List<Memento>();

    public void AddMemento(Memento memento)
    {
        _mementos.Add(memento);
    }

    public Memento GetMemento(int index)
    {
        return _mementos[index];
    }
}


//Main Program
using System;

class Program
{
    static void Main()
    {
        Originator originator = new Originator();
        Caretaker caretaker = new Caretaker();

        originator.SetState("State1");
        caretaker.AddMemento(originator.CreateMemento());

        originator.SetState("State2");
        caretaker.AddMemento(originator.CreateMemento());

        originator.RestoreMemento(caretaker.GetMemento(0));
        Console.WriteLine("Restored State: " + originator.GetState());
    }
}
