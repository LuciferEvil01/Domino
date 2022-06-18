public class Jugada<T>
{
    public Ficha<T> InHand{get;private set;}
    public T OnTable{get;private set;}
    public bool first{get;private set;}
    public Jugada(Ficha<T> InHand,T OnTable)
    {
        this.InHand = InHand;
        this.OnTable = OnTable;
        first = false;
    }
    public Jugada(Ficha<T> InHand)
    {
        this.InHand = InHand;
        first = true;
    }
}
