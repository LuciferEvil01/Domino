class Program
{
    static void Main()
    {
        PlayerCreator<int> cre = new PlayerCreator<int>();
        CreadorDeFichas<int> fich = new CreadorDeFichas<int>(2,new int[]{0,1,2,3,4,5,6,7,8,9});
        Player<int>[] gamers = cre.Create(fich.Miset,4,10);

        Estado<int> estado = new Estado<int>();

        int i = 0;
        int pass = 0;
        while(true)
        {
            Jugada<int>[] validas = ValidateJugada<int>.ValidarTodo(gamers[i],estado);
            Jugada<int> actual = gamers[i].JugadaActual(validas);
            if(actual == null)
            {
                pass++;
                System.Console.WriteLine("J: " + gamers[i].Name + " se pasa");
                if(pass == 4)
                    break;
                i++;
                if(i == 4)
                    i = 0;
                continue;
            }
            else
            {
                pass = 0;
            }
            bool end = estado.Actualizar(gamers[i],actual);

            if(end)
                break;
            i++;
            if(i == 4)
                i = 0;
        }
        System.Console.WriteLine("Game Over");

    }
}

public static class ValidateJugada<T>
{
    public static Jugada<T>[] ValidarTodo(Player<T> jugador,Estado<T> estado)
    {
        if(estado.FichasActivas.Count == 0)
            return ValidarPrimeraJugada(jugador,estado);

        List<Jugada<T>> JugadasValidas = new List<Jugada<T>>();

        for (int i = 0; i < jugador.Mano.Count; i++)
        {
            int val = Validar(jugador.Mano[i],estado);
            if(val != -1)
                JugadasValidas.Add(new Jugada<T>(jugador.Mano[i],estado.FichasActivas[val]));
        }
        return JugadasValidas.ToArray();
    }
    private static int Validar(Ficha<T> ficha, Estado<T> estado)
    {
        for (int i = 0; i < ficha.Caras.Length; i++)
        {
             if(estado.FichasActivas.Contains(ficha.Caras[i]))
                return estado.FichasActivas.IndexOf(ficha.Caras[i]);   
        }
        return -1;       
    }
    private static Jugada<T>[] ValidarPrimeraJugada(Player<T> jugador,Estado<T> estado)
    {
        Jugada<T>[] JugadasValidas = new Jugada<T>[jugador.Mano.Count];

        for (int i = 0; i < JugadasValidas.Length; i++)
        {
            JugadasValidas[i] = new Jugada<T>(jugador.Mano[i]);
        }

        return JugadasValidas;
    }
}
public class Estado<T>
{
    public List<T> FichasActivas = new List<T>();
    List<(Player<T>,Jugada<T>)> Registro = new List<(Player<T>, Jugada<T>)>();

    public bool Actualizar(Player<T> player,Jugada<T> jugada)
    {

        //
        System.Console.WriteLine("J {0}: {1},{2} in {3}",player.Name,jugada.InHand.Caras[0],jugada.InHand.Caras[1],jugada.OnTable);
        //
        FichasActivas.Remove(jugada.OnTable);
        
        List<T> NuevasCaras = ((T[])(jugada.InHand.Caras).Clone()).ToList();
        
        if(!jugada.first)
            NuevasCaras.Remove(jugada.OnTable);

        player.Mano.Remove(jugada.InHand);
        FichasActivas.AddRange(NuevasCaras);
        Registro.Add((player,jugada));

        return GameEnded(player);
    }
    private bool GameEnded(Player<T> player)
    {
        if(player.Mano.Count == 0)
            return true;
        return false;
    }
}

public class Ficha<T>
{
    public T[] Caras{get;private set;}
    public Ficha(T[] Caras)
    {
        this.Caras = Caras;
    }
    public override string ToString()  
    {
        string Name = "";
        for (int i = 0; i < Caras.Length; i++)
        {
            Name += Convert.ToString(Caras[i]);
            Name += " ";
        }
        return Name;
    }  
}
public class CreadorDeFichas<T>
{
    public List<Ficha<T>> Miset = new List<Ficha<T>>();
    public CreadorDeFichas(int CantidaddeCaras,T[] PosiblesCaras)
    {
         SetDeFichas(new T[CantidaddeCaras],PosiblesCaras,0,0);       
    }
    private void SetDeFichas(T[] fichaactual,T[] PosiblesCaras,int indice, int menor)
    {
        if(indice == fichaactual.Length)
        {
            Ficha<T> FichaActual = new Ficha<T>(fichaactual);
            Miset.Add(FichaActual);
            return;
        }
        
        for (int i = menor; i < PosiblesCaras.Length; i++)
        {
            fichaactual[indice] = PosiblesCaras[i];
            SetDeFichas((T[])fichaactual.Clone(),PosiblesCaras,indice+1,i);
        }
    }
}

public class Player<T>
{
    public string Name{get;protected set;}
    public List<Ficha<T>> Mano{get;protected set;}
    public Player(string Name,List<Ficha<T>> Mano)
    {
        this.Name = Name;
        this.Mano = Mano;
    }
    public Jugada<T> JugadaActual(Jugada<T>[] PosiblesJugadas)
    {
        if(PosiblesJugadas.Length == 0)
            return null;
        return PosiblesJugadas[0];
    }
}
interface GetPlayers<T>
{
    public Player<T> GetOne(List<Ficha<T>> disponibles);
    public Player<T>[] GetAll(List<Ficha<T>> disponibles, int NumberOfPlayers);

}
public class PlayerCreator<T>
{
    public Player<T>[] Create(List<Ficha<T>> miset, int NumberOfPlayers,int NumberOfFichasByPlayer)
    {
        Player<T>[] players = new Player<T>[NumberOfPlayers];
        miset = Mezclar(miset);
        for (int i = 0; i < players.Length; i++)
        {
            Ficha<T>[] mano = new Ficha<T>[NumberOfFichasByPlayer];
            Array.Copy(miset.ToArray(),i*NumberOfFichasByPlayer,mano,0,NumberOfFichasByPlayer);
            Player<T> p = new Player<T>(Convert.ToString(i),mano.ToList());    
            players[i] = p;
        }
        return players;
    }
    public List<Ficha<T>> Mezclar(List<Ficha<T>> miset)
    {
        Random random = new Random();
        int[] guide = new int[miset.Count];
        Ficha<T>[] miset2 = miset.ToArray();
        for (int i = 0; i < guide.Length; i++)
        {
            int value = random.Next(0,guide.Length); 
            //aqui aun no se impide que se repitan valores
            guide[i] = value;
        }
        Array.Sort(guide,miset2);
        return miset2.ToList();
    }
}