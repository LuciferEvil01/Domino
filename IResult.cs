public interface IResult<T>
{
    public string Winner(Player<T>[] players,GameRules<T> rules);
} 
public class IndividualPuntuation<T> : IResult<T>
{
    public string Winner(Player<T>[] players,GameRules<T> rules)
    {
        Player<T>[] temp = (Player<T>[])players.Clone();

        int[] keys = new int[players.Length];
        
        for (int i = 0; i < players.Length; i++)
        {
            keys[i] = Auxiliares<T>.ValoratePlayer(players[i],rules.Valorator);
        }
        
        Array.Sort(keys,temp);

        Player<T> win = temp[0];
        string result = ("Player " + win.Name +" team " + win.Team + " winns");
        return result;
    }
   
}
public class TeamPuntuation<T> : IResult<T>
{
    public string Winner(Player<T>[] players,GameRules<T> rules)
    {
        Dictionary<int,int> Puntuations = new Dictionary<int, int>();
        foreach (Player<T> item in players)
        {
            int points = Auxiliares<T>.ValoratePlayer(item,rules.Valorator);
            if(Puntuations.Keys.Contains(item.Team))
            {
                Puntuations[item.Team] += points;
            }
            else
            {
                Puntuations.Add(item.Team,points);
            }
        }
        int[] teams = (int[])Puntuations.Keys.ToArray().Clone();
        Array.Sort(Puntuations.Values.ToArray(),teams);
        string result = ("Team " + teams[0] + " winns");
        return result;
    }
}
