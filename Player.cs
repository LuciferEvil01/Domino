public abstract class Player<T>
{
    public int Name{get;protected set;}
    public List<Token<T>> Mano{get;protected set;}
//    public bool Disponible{get;protected set;}
    public int Team{get;protected set;}
  //  public IValorateToken<T> Valorator{get;set;}
    //necesario para independizar al jugador de las regrlas del juego
    public Player(int Name,int Team)
    {
        this.Name = Name;
        Mano = new List<Token<T>>();
        this.Team = Team;
    }
    public virtual void Asigar(List<Token<T>> disponibles,int asign,IValorateToken<T> Valorator)
    {
        for (int i = 0; i < asign; i++)
        {
            Mano.Add(Auxiliares<T>.Take(disponibles));
        }
    }
    public abstract Move<T> MoveActual(Move<T>[] PosiblesMoves,GameRules<T> rules);
}
public class PlayerRandom<T> : Player<T>
{
    public PlayerRandom(int Name,int Team):base(Name,Team){}
    public override Move<T> MoveActual(Move<T>[] PosiblesMoves,GameRules<T> rules)
    {
        
        if(PosiblesMoves.Length == 0)
            return new Move<T>();
        
        Random r = new Random();
        return PosiblesMoves[r.Next(0,PosiblesMoves.Length-1)];
    }
}
public class PlayerGreedy<T> : Player<T>
{
    public PlayerGreedy(int Name,int Team):base(Name,Team){}
    public override Move<T> MoveActual(Move<T>[] PosiblesMoves,GameRules<T> rules)
    {        
        if(PosiblesMoves.Length == 0)
            return new Move<T>();
        

        return PosiblesMoves.Max(new Comp(rules.Valorator));
    }
    class Comp : IComparer<Move<T>>
    {
        IValorateToken<T> valorator{get;set;}
        public Comp(IValorateToken<T> valorator)
        {
            this.valorator = valorator;
        }
        public int Compare(Move<T> J1,Move<T> J2)
        {
            double val = J1.MoveValue(valorator) - J2.MoveValue(valorator);
            return (int)val;
        }
    }
}

public class PlayerCounter<T> : Player<T>
{
    public PlayerCounter(int Name,int Team):base(Name,Team){}
    public override Move<T> MoveActual(Move<T>[] PosiblesMoves,GameRules<T> rules)
    {
        
        if(PosiblesMoves.Length == 0)
            return new Move<T>();
        if(PosiblesMoves.Any(x=>x.Type == PosiblesMoves[0].Open))
        {
            return (new PlayerGreedy<T>(0,0)).MoveActual(PosiblesMoves,rules);
        }

        Array.Sort(MovesValues(PosiblesMoves,rules),PosiblesMoves);

        return PosiblesMoves[PosiblesMoves.Length-1];
        
    }
    private int[] MovesValues(Move<T>[] PosiblesMoves,GameRules<T> rules)
    {
        int[] keys = new int[PosiblesMoves.Length];
        
        for (int i = 0; i < PosiblesMoves.Length; i++)
        {
            int val = 0;
            Move<T> Move = PosiblesMoves[i];
            
            for (int j = 0; j < Move.InHand.Caras.Length; j++)
            {
                for (int k = 0;k <  rules.contoler.Dates.Length; k++)
                {
                    if(rules.contoler.Dates[k].NoHaveFaces.Contains(Move.InHand.Caras[j]))
                        val+=1;
                }
            }
            for (int k = 0; k < rules.contoler.Dates.Length; k++)
            {
                if(rules.contoler.Dates[k].NoHaveFaces.Contains(Move.OnTable))
                    val-=2;
            }
            keys[i] = val;    
        }
        return keys;
    }
}
