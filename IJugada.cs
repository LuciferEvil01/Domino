public class Move<T>
{
    public string Open{get{return "Open";}}
    public string NormalMove{get{return "NormalMove";}} 
    public string Pass {get{return "Pass";}}
    public string Type{get;private set;}
    public int index{get;private set;}
    public Move()
    {
        Type = Pass;
    }
    public Move(Token<T> InHand)
    {
        this.In_Hand = InHand;
        Type = Open;
    }
    public Move(Token<T> InHand,int index,T OnTable)
    {
        this.In_Hand = InHand;
        this.On_Table = OnTable;
        this.index = index;
        Type = NormalMove;   
    }

    private Token<T> In_Hand;
    public Token<T> InHand
    {
        get
        {
            if(Type != Pass)
                return In_Hand;
            else
                throw new Exception("La juagada es pass");
        }
    }   
    private T On_Table;
    public T OnTable
    {
        get
        {
            if(Type == NormalMove)
                return On_Table;
            else
                throw new Exception("La juagada es apertura");
        }
    }
    public double MoveValue(IValorateToken<T> valorator)
    {
        if(Type == Pass)
            return 0;
        return valorator.Valorate(this.InHand);
    }   

}

