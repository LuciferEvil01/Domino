public class ControladorDeDesarrollo<T>
{
    public PlayerDates<T>[] Dates{get;set;}
    public ControladorDeDesarrollo(int CantJugadores)
    {
        Dates = new PlayerDates<T>[CantJugadores];
        for (int i = 0; i < Dates.Length; i++)
        {
            Dates[i] = new PlayerDates<T>();
        } 
    }
    public virtual void NoLLevaDetectado(int Jugador, BaseState<T> State)
    {
        Dates[Jugador].NoCanPlay = true;
        Dates[Jugador].NoHaveFaces.AddRange(State.TokensActivas);
    }
    public virtual void RestablecerNoLLeva(params int[] Jugadores)
    {
        for (int i = 0; i < Jugadores.Length; i++)
        {
            Dates[Jugadores[i]].NoCanPlay = false;
        }
    }
    public virtual void RestablecerNoLLevaCompleto()
    {
        for (int i = 0; i < Dates.Length; i++)
        {
            Dates[i].NoCanPlay = false;
        }
    }
    public bool NoOneHas()
    {
        if(Dates.All(x=>x.NoCanPlay))
            return true;
        else
            return false;
    }
}
public class PlayerDates<T>
{
    public bool NoCanPlay;
    public List<T> NoHaveFaces = new List<T>();
    public void ReseatNoHaveFaces()
    {NoHaveFaces.Clear();}
}