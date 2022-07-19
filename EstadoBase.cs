public class BaseState<T>
{
    public List<T> TokensActivas = new List<T>();
    public List<(Player<T>,Move<T>)> Registro = new List<(Player<T>, Move<T>)>();

    public virtual void Actualizar(Player<T> player,Move<T> Move,GameRules<T> rules)
    {
        Registro.Add((player,Move));        
        rules.Ordenador.Actualizar(Move,player);
        
        if(Move.Type == Move.Pass)
        {
            rules.contoler.NoLLevaDetectado(player.Name,this);
           App.Game.Text.Add("Player "+player.Name+" se pasa");         
        }
        if(Move.Type== Move.Open)
        {
            List<T> NuevasCaras = ((T[])(Move.InHand.Caras).Clone()).ToList();
             App.Game.Text.Add("Player " + player.Name + " empieza con " + Move.InHand);

            player.Mano.Remove(Move.InHand);
            TokensActivas.AddRange(NuevasCaras);
        }
        if(Move.Type == Move.NormalMove)
        {
            
            TokensActivas.Remove(Move.OnTable);

            rules.contoler.RestablecerNoLLeva(Convert.ToInt32(player.Name));                
            
            List<T> NuevasCaras = ((T[])(Move.InHand.Caras).Clone()).ToList();
            NuevasCaras.RemoveAt(Move.index);

            player.Mano.Remove(Move.InHand);
            TokensActivas.AddRange(NuevasCaras);

            App.Game.Text.Add("Player "+ player.Name+ " juega " +Move.InHand+" en "+Move.OnTable);
        }
      
       
        try
        {
             App.Game.Token.Add(Convert.ToString(rules.State.TokensActivas[0]));
            App.Game.Token.Add(Convert.ToString(rules.State.TokensActivas[1]));
        }
        catch
        {
            throw new Exception("Error en convercion de string a generico o en acceso a lista TokensAcyivos");
        }
       
       
    } 
}