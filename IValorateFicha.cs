//completado (casi)
public interface IValorateToken<T>
{
    public int Valorate(Token<T> Token);
}

public class NormalValorator<T> : IValorateToken<T>
{
    public int Valorate(Token<T> Token)
    {
        int val = 0;
        for (int i = 0; i < Token.Caras.Length; i++)
        {
            try
            {
                val += Convert.ToInt32(Token.Caras[i]);
            }
            catch{}
        }
        return val;
    }
}
//hay que probar esto
public class MCDValorator<T> : IValorateToken<T>
{
    public int Valorate(Token<T> Token)
    {
        int[] values = Auxiliares<T>.ConvertToInt(Token.Caras);
        if(values.Contains(0))
            return 0;
        return values.Aggregate(MCD);
    }   
    
    private int MCD(int x,int y)
    {
        if(x % y == 0)
            return y;
        return MCD(y,x%y);
    } 
}