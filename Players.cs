using Raylib_CsLo;
using System.Buffers;

namespace App
{
   public class  Players: Scene
   {   
      
      
      static public int[] IAselect= new int[1];
      static public int[] Teamselect= new int[1];
      public string PMG = "Single";

      Tool Support = new Tool();

      public Players()
      {
      }
     

       public override void Draw(Stack<Scene> stack)
       {
            
           
            Raylib.DrawText("Settings",150,50,100,Raylib.BLUE); 
            Raylib.ClearBackground (Raylib.BLACK );
            Raylib.DrawText("Player Mode",10,200,30,Raylib.BLUE);
            Tool.Continue(stack,Support);
            
            PlayerMG();
            TotalPlayers();
            IA_Team();      
              
       }
      public void PlayerMG()
       {
          Raylib.DrawText(PMG,10,250,25,Raylib.BLUE);
         
          var k=RayGui.GuiButton(new Rectangle(100,250,50,30),"Single");
          var j=RayGui.GuiButton(new Rectangle(160,250,50,30),"Co-op");
          if(k) {Support.Bool[2]=false; PMG="Single";}
          if(j) {Support.Bool[2]= true;  PMG="Co-op";}
          if(PMG=="Co-op")
          {
           Raylib.DrawText("Equipos",10,300,25,Raylib.BLUE);
         
          
           unsafe
            {
               var x=RayGui.GuiTextBox(new Rectangle (120, 300, 80, 25), (sbyte*) Support.buff[1].Pointer, Support.Size, Support.Bool[1]);
              
               if(x) { Support.Bool[1]= true;}
               var y= Tool.Test(new string((sbyte*) Support.buff[1]. Pointer));
              
               if(Support.Bool[1] && y)
               {  
                  Support.Number[1]= Tool.Convert(new string((sbyte*) Support.buff[1].Pointer)); 
               }
               if(!y && new string((sbyte*)  Support.buff[1].Pointer).Length!=0){ Raylib.DrawText("Escriba solo Numero",10,400,25,Raylib.BLUE );}
               if(Raylib.IsKeyPressed(Raylib_CsLo.KeyboardKey.KEY_ENTER)){ Support.Bool[1]=false;}
               
              
            }
          }  

         
          
       }
      private void TotalPlayers()
      {
         Raylib.DrawText("TotalPlayers:",10,350,25,Raylib.BLUE);
         
         unsafe
            {
               var x=RayGui.GuiTextBox(new Rectangle (180, 350, 80, 25), (sbyte*) Support.buff[0].Pointer, Support.Size, Support.Bool[0]);
              
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
      private void IA_Team()
      {  

         var s =Support.Token[0]+1;
         var t =Support.Token[1]+1;
         Raylib.DrawText(" IA ",500,200,50,Raylib.BLUE);
         Raylib.DrawText("Jugador "+s+":",500,250,25,Raylib.BLUE);
         Raylib.DrawText("Equipo "+t+":",500,350,25,Raylib.BLUE);
         var x1=RayGui.GuiButton(new Rectangle(570,280,60,30),"Next");
         var x2=RayGui.GuiButton(new Rectangle(500,280,60,30),"Return");
         var x3=RayGui.GuiButton(new Rectangle(570,380,60,30),"Next");
         var x4=RayGui.GuiButton(new Rectangle(500,380,60,30),"Return");
         var x5=RayGui.GuiButton(new Rectangle(650,250,60,30),"Random");
         var x6=RayGui.GuiButton(new Rectangle(650,280,60,30),"Bota Gorda");
         var x7=RayGui.GuiButton(new Rectangle(650,310,60,30),"Especial");
         
      
          unsafe
            {
               var x=RayGui.GuiTextBox(new Rectangle (630, 350, 80, 25), (sbyte*) Support.buff[2].Pointer, Support.Size, Support.Bool[2]);
              
               if(x) { Support.Bool[2]= true;}
               var y= Tool.Test(new string((sbyte*) Support.buff[2]. Pointer));
              
               if(Support.Bool[2] && y)
               {  
               if(Tool.Convert(new string((sbyte*) Support.buff[2].Pointer))<=Support.Number[1])
                  {
                     Support.Number[2]= Tool.Convert(new string((sbyte*) Support.buff[2].Pointer)); 
                  }
                  else Raylib.DrawText("El Equipo no Existe",500,450,25,Raylib.BLUE );
               }
               if(!y && new string((sbyte*)  Support.buff[2].Pointer).Length!=0){ Raylib.DrawText("Escriba solo Numero",500,450,25,Raylib.BLUE );}
               
               if(Raylib.IsKeyPressed(Raylib_CsLo.KeyboardKey.KEY_ENTER)){ Support.Bool[2]=false;}
               
              
            }
      
         if(x1 && Support.Number[0]-1!=Support.Token[0]){Support.Token[0]++;}
         if(x2 && Support.Token[0]!=0){Support.Token[0]--;}
         if(x3 && Support.Number[0]-1!=Support.Token[1]){Support.Token[1]++;}
         if(x4 && Support.Token[1]!=0){Support.Token[1]--;}


         if(Support.Bool[0])
         {
            Support.Token[0]=0;
            Support.Token[1]=0;
            IAselect= new int[Support.Number[0]];
            Teamselect= new int[IAselect.Length];
            Tool.Jugador_Equipo(Teamselect);
         }
         if(Support.Bool[1])
         {
            Support.Token[1]=0;
            Teamselect= new int[IAselect.Length];
            Tool.Jugador_Equipo(Teamselect);
         }
         var x10= Support.Number[2]!=0;
         if(IAselect.Length!=0 || Teamselect.Length!=0)
         {
            if(x5) {IAselect[Support.Token[0]]=0;}
            if(x6) {IAselect[Support.Token[0]]=1;}
            if(x7) {IAselect[Support.Token[0]]=2;}
            if(Support.Number[2]<=Support.Number[1] ) {Teamselect[Support.Token[1]]= Support.Number[2];}
            
         }   
         

        
      }
      
   }
}
