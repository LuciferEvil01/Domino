public static class Probadores
{
    public static void Test1()
    {
        CreadorDeFichas<int> juego = new CreadorDeFichas<int>(2,new int[]{0,1,2});
        for (int i = 0; i < juego.Miset.Count; i++)
        {
            System.Console.WriteLine(juego.Miset[i]);           
        }
    }

    public static void TestPlayers()
    {
        PlayerCreator<int> cre = new PlayerCreator<int>();
        
        CreadorDeFichas<int> misfichas = new CreadorDeFichas<int>(2,new int[]{0,1,2,3,4,5,6,7,8,9});
        List<Ficha<int>> fich = misfichas.Miset;

        Player<int>[] personas = cre.Create(fich,4,10);

        for (int i = 0; i < personas.Length; i++)
        {
            System.Console.WriteLine(personas[i].Name + ": ");
            for (int j = 0; j < personas[i].Mano.Count; j++)
            {
               System.Console.Write(personas[i].Mano[j] + " ");
            }
            System.Console.WriteLine();
        }
    }
}