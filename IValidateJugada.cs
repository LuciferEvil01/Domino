
public interface IValidateMove<T>
{
    public int Validate(Token<T> Token,BaseState<T> State,out int index);
}

public class ValidadorNormal<T> : IValidateMove<T>
{
    public int Validate(Token<T> Token, BaseState<T> State,out int index)
    {
        for (int i = 0; i < Token.Caras.Length; i++)
        {
             if(State.TokensActivas.Contains(Token.Caras[i]))
             {
                index = i;
                return State.TokensActivas.IndexOf(Token.Caras[i]);
             }   
        }
        index = -1;
        return -1;       
    }    
}
public class ValidadorEscalera<T> : IValidateMove<T>
{
    public int Validate(Token<T> Token, BaseState<T> State,out int index)
    {
        int[] TokenNum = Auxiliares<T>.ConvertToInt(Token.Caras);
        int[] TableNum = Auxiliares<T>.ConvertToInt((T[])State.TokensActivas.ToArray());

        if(TokenNum.Contains(0))
        {   
            index = TokenNum.ToList().IndexOf(0);
            return TableNum.ToList().IndexOf(TableNum.Max());
        }   
        for (int i = 0; i < TokenNum.Length; i++)
        {
             if(TableNum.Contains(TokenNum[i] - 1))
             {
                index = i;
                return TableNum.ToList().IndexOf(TokenNum[i] - 1);
             }   
        }
        index = -1;
        return -1;

    }   
}