
public static partial class Auxiliares<T>
{
    public static int ValoratePlayer(Player<T> P1,IValorateToken<T> valorator)
    {
        int v1 = 0;
        for (int i = 0; i < P1.Mano.Count; i++)
        {
            v1 += valorator.Valorate(P1.Mano[i]);
        }
        return v1;
    }
    public static int[] ConvertToInt(T[] caras)
    {
        int[] values = new int[caras.Length];
        for (int i = 0; i < caras.Length; i++)
        {
            int x;
            try{x = Convert.ToInt32(caras[i]);}
            catch{x = 0;}
            values[i] = x;
        }
        return values;
    }
    public static List<Token<T>> Mezclar(List<Token<T>> miset)
    {
        Random random = new Random();

        int[] guide = new int[miset.Count];
        
        Token<T>[] misetaux = new Token<T>[miset.Count];  
        
        for (int i = 0; i < guide.Length; i++)
        {
            int value = random.Next(0,guide.Length * 2);
            misetaux[i] = miset[i]; 
            guide[i] = value;
        }
        
        Array.Sort(guide,misetaux);
        return misetaux.ToList();
    }
    public static void PrepararJugadores(int n, Player<T>[] players, List<Token<T>> Tokens,IValorateToken<T> valorator)
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].Asigar(Tokens,n,valorator);    
        }
    }
    public static Token<T> Take(List<Token<T>> Tokens)
    {
        Token<T> Token = Tokens[0];
        Tokens.Remove(Token);
        return Token;
    }
    public static void PrintPlayerHand(Player<T> player)
    {
        System.Console.WriteLine("Player {0}:",player.Name);
        PrintTokens(player.Mano);
    }
    public static void PrintAll(Player<T>[] players)
    {
        foreach (var player in players)
        {
            PrintPlayerHand(player);   
        }
    }
    public static void PrintTokens(Token<T>[] Tokens)
    {
        foreach (var item in Tokens)
        {
            var x = item.Caras[0];
            var y = item.Caras[1];
            System.Console.Write("[{0},{1}] ",x,y);            
        }
        System.Console.WriteLine();
    }
    public static void PrintTokens(List<Token<T>> Tokens)
    {
        PrintTokens(Tokens.ToArray());
    }
    public static void PrintNumTokens(Player<T> player)
    {
        System.Console.WriteLine("Player {0}: {1} Tokens",player.Name,player.Mano.Count);
    }
    public static int NoCanPlayNum(PlayerDates<T>[] dates)
    {
        int total = 0;
        for (int i = 0; i < dates.Length; i++)
        {
            if(dates[i].NoCanPlay)
                total++;
        }
        return total;
    }
}
public static partial class Auxiliares<T>
{
    public static bool ValidateSttings(T[] PosiblesCaras,int[] IAs,int[] Teams,
                            int TokensByPlayer,int NumPlayers,int ValidateMoveIndicator,
                            int OrderIndicator,int ValorateTokenIndicator,
                            int GameFinisherIndicador,int ResultIndicator,
                            out string Error,out Player<T>[] gamers,
                            out GameRules<T> rules)
    {
        TokensCreator<T> creator = new TokensCreator<T>(2,PosiblesCaras);
        int NecessaryTokens = TokensByPlayer*NumPlayers;
        int NumTokens = creator.Miset.Count;
        if(NecessaryTokens <= NumTokens)
        {

            Error = "";
            gamers = PlayerCreator<T>.Create(IAs,Teams);
            rules = GetGameRules<T>.Get(creator.Miset,TokensByPlayer,NumPlayers,ValidateMoveIndicator,OrderIndicator,ValorateTokenIndicator,GameFinisherIndicador,ResultIndicator);
            return true;
        }
        else
        {
            
            Error = "La cantidad de fichas es insufiiente para asigarle a cada jugador su mano";
            gamers = null;
            rules = null;
            return false;
        }
    }

}
