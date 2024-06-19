namespace DAL.Mementos;

public class Memento<T>
{
    public T State { get; }
    public Memento(T state)
    {
        State = state;
    }
}

public class Origiantor<T>
{
    private T _state;
    
    public Origiantor(T state)
    {
        _state = state;
    }
    
    public T GetState() => _state;
    
    public Memento<T> Save() => new Memento<T>(_state);
    
    public void Restore(Memento<T> memento)
    {
        _state = memento.State;
    }
}