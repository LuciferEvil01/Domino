//completado
public interface IOrder<T>
{
    public int Next(Player<T>[] jugadores);
    public void Actualizar(Move<T> Move,Player<T> player);
}
public class VariableOrder<T> : IOrder<T>
{
    private int count = 0;
    private int Cicle{get;set;}      
    private int last = -1;
    public bool sentido = true;
    public int Next(Player<T>[] players)
    {
        if(Cicle == 0)
            Cicle = players.Length;
        if(sentido)
        {
            last++;
            if(last == players.Length)
                last = 0;
        }
        else
        {
            last--;
            if(last < 0)
                last = players.Length-1;
        }
        
        return last;
    }
    public void Actualizar(Move<T> Move,Player<T> player)
    {
        
        if(Move.Type == Move.Pass)
        {
            if(count >= Cicle)
            {
                count = 0;
                sentido = !sentido;
            }
        }
        count++;
    }
}
public class NormalOrder<T> : IOrder<T>
    {
        private int last = -1;
        public int Next(Player<T>[] jugadores)
        {
            if(last < 0 || last >= jugadores.Length-1)
            {
                last = 0;
            }
            else
            {
                last++;
            }
        
            return last;
        }
        public void Actualizar(Move<T> Move,Player<T> player){}
    }