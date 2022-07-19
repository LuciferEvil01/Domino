using Raylib_CsLo;
using System.Diagnostics;
namespace App
{
    public static class Domino
    {
        public static  void Main ()
        {
            Stack<Scene> stack = new Stack<Scene> ();
            Scene scene;
            stack.Push (new MainMenu ());
            
            Raylib.InitWindow (800, 600, "Domino Arcade Game 1.0");

            while (!Raylib.WindowShouldClose ()
                && stack.Count > 0)
                {
                    Raylib.BeginDrawing ();
                    scene = stack.Peek ();
                    scene.Draw (stack);
                    Raylib.EndDrawing ();
                    
                }
              
            Raylib.CloseWindow ();
        }
    }
}