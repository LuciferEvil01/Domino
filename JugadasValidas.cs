
public static class MovesValidas<T>
{
    public static Move<T>[] GetAll(Player<T> jugador,BaseState<T> State,IValidateMove<T> Validator)
    {
        if(State.TokensActivas.Count == 0)
            return ValidarPrimeraMove(jugador,State);

        
        List<Move<T>> MovesValidas = new List<Move<T>>();

        for (int i = 0; i < jugador.Mano.Count; i++)
        {
            int index;
            int val =  Validator.Validate(jugador.Mano[i],State,out index);
            if(val != -1)
                MovesValidas.Add(new Move<T>(jugador.Mano[i],index,State.TokensActivas[val]));
        }
        return MovesValidas.ToArray();
    }
    private static Move<T>[] ValidarPrimeraMove(Player<T> jugador,BaseState<T> State)
    {
        Move<T>[] MovesValidas = new Move<T>[jugador.Mano.Count];

        for (int i = 0; i < MovesValidas.Length; i++)
        {
            MovesValidas[i] = new Move<T>(jugador.Mano[i]);
        }

        return MovesValidas;
    }    
}
