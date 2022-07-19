using Raylib_CsLo;
namespace App
{
    class Status:Scene
    {
        
        public override void Draw(Stack<Scene> stack)
        {
            Raylib.ClearBackground(Raylib.BLACK);
          var IAPlayer = Players.IAselect;
          var TeamPlayers = Players.Teamselect;
          var J_valida = GameRules.Jugadavalidada;
          var OrdenJuego=  GameRules.OrdenJuego;
          var  resultadoPartido= GameRules.resultadoPartido;
          var  valorFichas = GameRules.valorFichas;
          var  face= GameRules.Face;
          var  FinalizarJuego= GameRules.FinalizarJuego;
          var FichasInicales = GameRules.FichasInicales;
          var TotalJugadores = IAPlayer.Length;
          var BContinue = RayGui.GuiButton (new Rectangle (350, 500, 100, 50), "Continue");
          var BReturn = RayGui.GuiButton (new Rectangle (150, 500, 100, 50), "Return");
          string Error;
          Player<string>[] players;
          GameRules<string> rules; 
          var Valitate = Auxiliares<string>.ValidateSttings(face,IAPlayer,TeamPlayers,FichasInicales,TotalJugadores,J_valida,OrdenJuego,valorFichas,FinalizarJuego,resultadoPartido, out Error,out players,out rules);
          Game<string> MyGame = new Game<string>();
          
          
          Tool.DrawText("Jugada Valida: Opcion "+(J_valida+1),10,100,25);
          Tool.DrawText(" Orden  Juego: Opcion "+(OrdenJuego+1),10,150,25);
          Tool.DrawText(" Resultado Partido: Opcion "+(resultadoPartido+1),10,200,25);
          Tool.DrawText(" Valor de Fichas : Opcion "+(valorFichas+1),10,250,25);
          Tool.DrawText(" Finalizar juego : Opcion "+(FinalizarJuego+1),10,300,25);
          Tool.DrawText(" Fichas Iniciales: "+FichasInicales,10,350,25);
          Tool.DrawText("Total de Caras: "+face.Length,10,400,25);
          if(BContinue && Valitate){
              MyGame.Single(rules,players);
              stack.Push(new Game ());}
          if(!Valitate){Tool.DrawText(Error,500,250,10);}
          if (BReturn) {stack.Pop();}
          
         

        




            

        }
    }
    
}