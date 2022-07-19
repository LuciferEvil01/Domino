using Raylib_CsLo;

namespace App
{
    public class MainMenu : Scene
    {
        public override void Draw (Stack<Scene> stack)
        { 
           var BExit =RayGui.GuiButton (new Rectangle (350, 400, 100, 50), "Exit"); 
           var BNewGame= RayGui.GuiButton (new Rectangle (350, 300, 100, 50), "Simulate Game");
            Raylib.ClearBackground (Raylib.BLACK);
            Raylib.DrawText("Domino",200,100,150,Raylib.BLUE);
            if(BNewGame)
                stack.Push(new Settings ());
            if (BExit)
                stack.Pop ();
        }
    }
}