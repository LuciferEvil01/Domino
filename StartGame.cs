
public class Game<T>
{
    public void Single(GameRules<T> rules,Player<T>[] gamers)
    {
        
        rules.Tokens = Auxiliares<T>.Mezclar(rules.Tokens);
        
        Auxiliares<T>.PrintTokens(rules.Tokens);
        
        Auxiliares<T>.PrepararJugadores(rules.TokensByPlayer,gamers,rules.Tokens,rules.Valorator);

        Auxiliares<T>.PrintAll(gamers);
        
        while(true)
        {
            int InTurn = rules.Ordenador.Next(gamers);
            
            
            Move<T>[] validas = MovesValidas<T>.GetAll(gamers[InTurn],rules.State,rules.validador);
            
            Move<T> actual = gamers[InTurn].MoveActual(validas,rules);

            rules.State.Actualizar(gamers[InTurn],actual,rules);
            Auxiliares<T>.PrintNumTokens(gamers[InTurn]);
            System.Console.WriteLine("No can play {0} players",Auxiliares<T>.NoCanPlayNum(rules.contoler.Dates));
            System.Console.WriteLine("------------------------");
            bool end = rules.Finisher.Condition(gamers[InTurn],rules);
                        
            if(end)
            {
                App.Game.Text.Add(rules.result.Winner(gamers,rules));
                break;
            }
            
        }
    }
}
