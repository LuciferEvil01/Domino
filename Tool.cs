using Raylib_CsLo;
using System.Buffers;
namespace App

{
    class Tool
    {
      public bool[] Bool;
     
      public  int[] Number;
      public int[] Token;
      public Memory<sbyte>[] buffer;
      public MemoryHandle[] buff;
      
      public const int buffSize = 1024;

       public int Size;
     
        public Tool ()
      {
         
         
         Size=buffSize;
           
         Token= new int[3];
         Token[0]=0;
         Token[1]=0;
         Token[2]=0;
        
         buffer= new Memory<sbyte>[3];
         buffer[0] = new Memory<sbyte> (new sbyte [buffSize]);
         buffer[1] = new Memory<sbyte> (new sbyte [buffSize]);
         buffer[2] = new Memory<sbyte> (new sbyte [buffSize]);
         
         
         buff = new  MemoryHandle[3];
         buff[0] = buffer[0].Pin (); 
         buff[1] = buffer[1].Pin ();
         buff[2] = buffer[2].Pin ();
         
         Bool = new bool[8];
         Bool[0]=false;
         Bool[1]=false;
         Bool[2]=false;
         Bool[3]=false;
         Bool[4]=false;
         Bool[5]=false;
         Bool[6]=false;
         Bool[7]=false;

         
         
         Number = new int[3];
         Number[0]=0;
         Number[1]=0;
         Number[2]=0;
      }

      public static bool Test(string Buff)
      {
          if(Buff.Length==0){return false;}         
          foreach(char Letters in Buff)
          {
              if(!char.IsNumber(Letters) ){return false;}
             

          }
         
           return true;
      }
      public static int Convert(string Buff)
      {
          int number = int.Parse(Buff);
          return number;
      }

      public static void Jugador_Equipo(int[] Equipo)
      {
          for(int i=0; i < Equipo.Length;i++ )
          {
              Equipo[i]=i;
          }
      }
      public static void DrawText(string text,int posX,int posY,int textsize)
      {
        Raylib.DrawText(text,posX,posY,textsize,Raylib.BLUE);
      }
      public static void Continue(Stack<Scene> stack, Tool support)
      {
         if(RayGui.GuiButton(new Rectangle(350,540,100,50),"Contine")) 
         {
         support = new Tool();
         stack.Pop();     
         }
      }
      public static bool Botton(int posx,int posy,int width, int height, string text)
      {
         return RayGui.GuiButton(new Rectangle(posx,posy,width,height),text);
      }
      public static void DrawLine(int posX,int posY, int width, int height)
      {
          Raylib.DrawRectangle(posX,posY,width,height,Raylib.BROWN);
      }
    }
     
}