using Raylib_CsLo;

namespace App
{
    public class Settings : Scene
    {
        public static int Posx = 10;
        public  override void Draw (Stack<Scene> stack)
        {
            Raylib.DrawText("Settings",150,50,100,Raylib.BLUE); 
            Raylib.ClearBackground (Raylib.BLACK);
            var bmode = RayGui.GuiButton (new Rectangle (Posx, 200, 100, 50), "Game Rules");
            var BPlayers = RayGui.GuiButton (new Rectangle (Posx, 300, 100, 50), "Players");
             var BContinue = RayGui.GuiButton (new Rectangle (Posx, 500, 100, 50), "Continue");
            var BReturn = RayGui.GuiButton (new Rectangle (Posx, 400, 100, 50), "Return");

            if (BReturn)
                stack.Pop();
            if (BContinue)
                stack.Push( new Status());    
            if (bmode)
                stack.Push ( new GameRules ());
            if (BPlayers)
                stack.Push ( new Players ());            
        }
    }    
}