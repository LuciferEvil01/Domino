using Raylib_CsLo;
using System.Diagnostics;
namespace App
{
    public class Game:Scene
    {
        static  public List<string> Text = new List<string>(100);
        static  public List<string> Token = new List<string>(100);
        Tool Support = new Tool();
        public override void Draw(Stack<Scene> stack)
        {  
             Raylib.ClearBackground(Raylib.BLACK);
             var BPlayers = RayGui.GuiButton (new Rectangle (10, 10, 100, 50), "Exit");
             var BRetry = RayGui.GuiButton (new Rectangle (10, 80, 100, 50), "Simulate Again");;
             if(BRetry){Support=new Tool();}
             if(BPlayers)
              {
                Text = new List<string>(100);
                Token= new List<string>(100);
                Support=new Tool();
                stack.Clear();
              }

            if(Token.Count!=0 || Text.Count!=0)
            {
            if(Support.Token[0]< Text.Count-1)
              {
                 Tool.DrawText(Text[Support.Token[0]],250,500,25);  
                  Support.Token[0]++;
              }
            else{
                      Tool.DrawText(Text[Support.Token[0]],250,500,25);
                      }
            string N1;
            string N2;
            
            N1 = Token[Support.Token[1]];
            N2 = Token[Support.Token[1]+1];
            
            Tool.DrawText( N1,150,150,50);     
            Tool.DrawText( N2,550,150,50);
            if(Support.Token[1]< Token.Count-2)
            {
              Support.Token[1]+=2;
            }
            }

             if(Support.Token[0]<Text.Count-1)
             {
             Thread.Sleep(1000);
             }
        }
    }
}