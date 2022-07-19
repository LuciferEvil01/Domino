using Raylib_CsLo;

namespace App
{
    public class GameRules:Scene
    {
        
        Tool Support =new Tool();
       static public string[] Face = new string[0];
        public bool[] Options;
      
       static public int Jugadavalidada =0;
       static public int OrdenJuego =0;
       static public int valorFichas =0;
       static public int FinalizarJuego =0;
       static public int resultadoPartido =0;
       static public int FichasInicales =0;
        public GameRules()
        {
           Options= new bool[0];    
        }

      

        public override void Draw(Stack<Scene> stack)
        {
          Raylib.DrawText("Settings",150,50,100,Raylib.BLUE); 
          Raylib.ClearBackground (Raylib.BLACK);
          Tool.Continue(stack,Support);
          FichasInicales= Support.Number[2]; 
          Total_Face();
          DrawFace();
          Fichas();
          Reglas_Extras();       
        }
         public void Total_Face()
         {
            Tool.DrawText("Total Data",10,200,25);
            unsafe
            {
               var x=RayGui.GuiTextBox(new Rectangle (150, 200, 80, 25), (sbyte*) Support.buff[0].Pointer, Support.Size, Support.Bool[0]);
              
               if(x) { Support.Bool[0]= true;}
               var y= Tool.Test(new string((sbyte*) Support.buff[0]. Pointer));
              
               if(Support.Bool[0] && y)
               {  
                  Support.Number[0]= Tool.Convert(new string((sbyte*) Support.buff[0].Pointer)); 
               }
               if(!y && new string((sbyte*)  Support.buff[0].Pointer).Length!=0){ Raylib.DrawText("Escriba solo Numero",10,400,25,Raylib.BLUE );}
               if(Raylib.IsKeyPressed(Raylib_CsLo.KeyboardKey.KEY_ENTER)){ Support.Bool[0]=false;}
               
              
            }

         }
         public void DrawFace()
         {
           var s= Support.Token[0]+1;
           Tool.DrawText("DrawData "+s+":",10,250,25);
           
           if(Support.Bool[0]){Face=new string[Support.Number[0]];}

           unsafe
            {
               var x=RayGui.GuiTextBox(new Rectangle (170, 250, 80, 25), (sbyte*) Support.buff[1].Pointer, Support.Size, Support.Bool[1]);  
               if(x) { Support.Bool[1]= true;}
               if(Face.Length!=0){Face[Support.Token[0]]= new string((sbyte*) Support.buff[1].Pointer);}              
               if(Raylib.IsKeyPressed(Raylib_CsLo.KeyboardKey.KEY_ENTER)){ Support.Bool[1]=false;}      
            }
           var x1=Tool.Botton(10,280,60,30,"Return");
           var x2=Raylib.IsKeyPressed(Raylib_CsLo.KeyboardKey.KEY_ENTER);
           var x3=Support.Token[0]!=Support.Number[0]-1;
           var x4=Support.Token[0]!=0;
           if(x1 && x4 ){ Support.Token[0]--;}
           if( x2 && x3){Support.Token[0]++;}
         }
         public void Fichas()
         {
           Tool.DrawText("Token By Players :",10,320,25);
            unsafe
            {
               var x=RayGui.GuiTextBox(new Rectangle (250, 320, 80, 25), (sbyte*) Support.buff[2].Pointer, Support.Size, Support.Bool[2]);
              
               if(x) { Support.Bool[2]= true;}
               var y= Tool.Test(new string((sbyte*) Support.buff[2]. Pointer));
              
               if(Support.Bool[2] && y)
               {  
                  Support.Number[2]= Tool.Convert(new string((sbyte*) Support.buff[2].Pointer)); 
               }
               if(!y && new string((sbyte*)  Support.buff[2].Pointer).Length!=0){ Raylib.DrawText("Escriba solo Numero",10,400,25,Raylib.BLUE );}
               if(Raylib.IsKeyPressed(Raylib_CsLo.KeyboardKey.KEY_ENTER)){ Support.Bool[2]=false;}
               
            }
           

         }
         public  void Reglas_Extras()
         {
          if(!Support.Bool[3] && !Support.Bool[4] && !Support.Bool[5] && !Support.Bool[6] && !Support.Bool[7] ){Options=new bool[2];}
          Support.Bool[3]^=Tool.Botton(10,380,120,40,"Jugada Valida");
          Support.Bool[4]^=Tool.Botton(140,380,120,40,"Orden de Jugada");
          Support.Bool[5]^=Tool.Botton(10,430,120,40,"Valor de las Fichas");
          Support.Bool[6]^=Tool.Botton(140,430,120,40,"Condicion de Finalizar");
          Support.Bool[7]^=Tool.Botton(10,480,120,40,"Resultado del Juego");
          
          if(Support.Bool[3]){DrawOption(2,ref Jugadavalidada,3);}
          if(Support.Bool[4]){DrawOption(2,ref OrdenJuego,4);}
          if(Support.Bool[5]){DrawOption(2,ref valorFichas,5);}
          if(Support.Bool[6]){DrawOption(2,ref FinalizarJuego,6);}
          if(Support.Bool[7]){DrawOption(2,ref resultadoPartido,7);}

          
         }
         public  void DrawOption(int TBotton,ref int Valor,int j)
         {
            int x= 380;
            int y= 170;

            Raylib.DrawRectangleLines(370,160,390,300,Raylib.BLUE);
           for(int i =0; i < TBotton;i++)
           {
            Options[i]=Tool.Botton(x,y,60,30,"Opcion "+(i+1));
            y+=40;
           }
            for(int i=0; i <Options.Length;i++)
             {
               if(Options[i]) {Valor=i; Support.Bool[j]=false;}
             }
         
         }
         
    }
}