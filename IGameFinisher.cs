public interface IGameFinisher<T>
{
    public bool Condition(Player<T> player,GameRules<T> rules);
}
public class NormalFinisher<T> : IGameFinisher<T>
{
    public bool Condition(Player<T> player,GameRules<T> rules)
    {
        if(player.Mano.Count == 0)
        {
            System.Console.WriteLine("None tokens in hand");
            return true;
        }
        if(rules.contoler.NoOneHas())
        {
            System.Console.WriteLine("None any player can play");
            return true;
        }
        return false;
    }
}
public class OneTimePassFinisher<T> : IGameFinisher<T>
{
    bool[] Mask = null; 
    public bool Condition(Player<T> player,GameRules<T> rules)
    {
        if(Mask == null)
            Mask = new bool[rules.contoler.Dates.Length];
        
        for (int i = 0; i < rules.contoler.Dates.Length; i++)
        {
             if(rules.contoler.Dates[i].NoCanPlay)
                Mask[i] = true;      
        }

        if(Mask.All(x => x))
            return true;
        
        return new NormalFinisher<T>().Condition(player,rules);
             
    }
    
}