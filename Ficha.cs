


public class Token<T>
{
    public T[] Caras{get;private set;}
    public Token(T[] Caras)
    {
        this.Caras = Caras;
    }
    public override string ToString()  
    {
        string Name = "";
        for (int i = 0; i < Caras.Length; i++)
        {
            Name += Convert.ToString(Caras[i]);
            Name += "/";
        }
        return Name;
    }  
}
