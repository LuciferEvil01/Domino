# Proyecto de Programacion
>Breve Recuento de la Creacion del Trabajo

Con el objetivo de completar nuestro proyecto de domino nos propusimos como paso inical,la creacion de un programa funcional y simple que simulara un partido de domino, una vez creado el programa se utilizo como estructura principal  para nuestro proyecto. Durante el proceso de creacion fuimos notando que existian partes del programa que representaban simillitudes en sus objetivos por lo que podian se agrupadas en un mismo cojunto que representara estas similitud diferenciandolos nada mas por sus peculiaridades. Uno de nuestro primero cambios al primer programa fue la creacion de una de nuestra clases principales del proyecto principal "Game Rules" con esta case tuvimos el objetivos de lograr un punto de control de todo el desarrollo de las futuras interfaces que implementarios al tener todo este proceso de implementacion por solo una entidad excluyendo asi futuros problemas a la hora de modificacion y adaptacion del proyecto. Dentro de esta clase se fue implementando paulativamnete diversas interfaces que describian un comportamiento en particular de nuestro simulador de domino el cual podia ser variado , modificado o alterado en fechas posteriores. Entre ellos podemos mencionar "IValidateMove"  como su nombre lo indica se encarga de definir cuando se puede considerar validada una jugada, al inicio pensabamos en mantener variable esta informacion pero despues de dialogar entre nosotros y consultar la opnion de otros companeros pensamos que no siempre podemos tener nuestra perspectiva en lo que es comunmente conocido a cambiar pues al igual que nuestro actual condicion de vida que nos da sorpresas en cada  momento debemos poder adaptarnos y reaccionar estos cambios constantes por ellos decimos incluir esta variacion ademas de otras mas peculiares como la posiblidad de definir la caras de las ficas con las que se jugara pues aunque se concoe que el domino se juega con numeros quien dice que alguien no desea probar jugar uno con los nombres de su familia como caras jejejje.
Aunque debo de aclarar que el  proyecto final aun si acepta la ediccion de la cara de las fichas este seguira trabajando bajo un sistema de numero por lo que se le asignaria valor 0, esto como muchos se darian cuenta provocaria problemas pero solo, dando un informe de aviso al informa de la situaccion, claro esta que aunque actualmente no acepta un sistema para definir un valor particular a palabras puede ser incluido en caso que fuera deseado. Continuando con la historia de nuestro proyecto se incluyeron ademas interfaces que permiten variar detalles como el resultado fial de la simulacion al defnir  diversas maneras en el que este puede ser declarado , dando como ejemplo el modo normal de suma de puntos de cada equipo.  Tambien esta el metodo para declarar la finalizacion del  partido , el metodo que define el orden en que juegan los participantes y el que declara el valor de cada ficha. Estos fueron los diversos comportamiento que definimos  como posibles informacion mutable. Tambien esta la creacion de nuestros jugadores estos lo hicimos de tal modo  que funcionen si la necesidad de saber nada sobre el funcionamiento de las reglas del juego. Siendo la unica informacion que los reaciona con la mismas la cantidad de jugadores que existen. Entre otras de las clases  importantes esta "EstadoBase" que rige el desarrollo de la simulacion al cambiar las diferentes acciones de cada jugar o ficha en dependencia de la circunstancias, actualiza el tablero y cambia las fichas que tiene cada jugador. regulando constantemente el juego y guardando cada jugada o suceso en un registro el cual puede ser usado poteriormente en cualquier necesidad. Tenemos nuestra clase encargada de regular todo el comportamiento de  las fichas esta en un principio se creo como una interface de la cual heredaban tres clases que definian una jugada , un pase o la jugada incial. pero despues de ver que existian incogruencia en este metodo, pues su implementacion era ineficiente . se decidio la creacion de una clase con tres constructores que regulan los cambios antes mencionados. Ademas del desarrollo de la parte logica o backend, tambien estuvo el desarrolo del frontEnd o interfaz grafica, aqui se debe hacer enfasis que se paso mucho rabajo en un principio para lograr el solo hecho de seleccionar una plataforma visual que permitiera desarrollar lo deseado pues  en un pricipio solo teniamos conocimiento de windowForm pero al trabajar en un sistema operativo incompatible con la app tuvimos que indagar en diferen soluciones. se nos recomendo platafomas de paginas web pero para poder aprender de las misma solo podiamos descargar videos instructivos de internet detalle el cual no imposibilito usar dicha via. Al final se uso una plataforma llamada Raylib.Csl. la cual aunque no es de las mejores era relativamente mas facil de aprender u obtener que otras opciones. Para la parte visual al tener pocas herramientas en nuestra manos en este nuevo campo de desarrolllo inexplorado, creamos una simple app para visualizar el proyecto. Aqui usamos una maquina de stack el cual en el apoyo de una clase abstracta que definia al accion que puede realizarse en pantallla se creo varias clases interconectadas las cuales cada una agrupaba un tipo de accion con la que se podia interactuar, ejemplo de esto es "Setting" en el cual esta definidos los diversos aspectos generales que se podian cambiar, en este caso los players y las GameRules. estos dos antes mencionados tambien definian clases  que permitian definir las especificaciones de cada jugador o regla del juego. se uso cuadros interactivos donde se podia escribir informacion especificada o botones predefinidos para interacturar con algunas opciones. se creo una clase encargada de controlar las opciones elegidas  y  permitir la inicializacion de la simulacion y visua al enviar todos los datos a un metodo que comprobaba que se pudiera iniciar el juego con las opciones elegidas despues de todo es imposoble declarar un total de 50 fichas y 6 jugadores  e iniciar cada jugador con 10 fichas cada uno. Por ultimo esta la clase "Game" esta es la que recibe el registro de la simulacion y la visualiza en pantalla , se debe especificar  nuavamente que la parte visual fue el aspecto mas desafiante por la falta de herramientas de aprendizaje y la dificulta de comprension de la usada para aprender. al tener datos predefinidos para el uso online , obligando a dedicar buen tiempo a redefinirlos en offline para su comprension.

> Jerarquia de clase

GameRuler: Clase que contiene todas las propiedades necesarias para hacer funcionar el programas cuyo valor se asigna en su constructor dichas propiedades son de los tipos siguientes:

* IvalitateMove: Interface que contiene un metodo denominado Valitate el cual recibe una jugada y el estado actual del juego y regresa un bool si la jugada realizada es valida o no.
* BaseState: Clase que cotiene las caras activas en la mesa , un registro de jugada y un metodo actualizar que recibe una jugada y al jugador que la realizo y actualiza las dos propiedades anteriores
* List(Token): Una lista de fichas 
* IOrder: Interface que contiene un metodo Next que recibe una lista de jugadores y devuelve un int indicando el indice del proximo jugador.\
* controladorDeDesarrollo: Clase que controla los jugadores que se pasan y las caras que no poseen.El metodo no lleva detectado, es el unico usado activamente en el programa , tiene otro metodo que actuan sobre sus propiedades de quien no lleva y que es lo que no llevan que podrian ser utiles en el futuro.
* IvalorateToken: Interface que  contiene un metodo que recibe una ficha y regresa su valor.
* IgameFinisher: Interface cuyo metodo recibe informacion del estado actual del juego y regresa un bool indicando si este ya termino o no.
* Iresult: Interface cuyo metodo indica el ganador del juego.

Player: Clase abstracta que contiene dos propiedades un entero que actua como nombre del jugador y una lista de fichas. Ademas posee un metodo asignar que le da valor a la lista de fichas y otro metodo abstracto MoveActual en el que se regresan una jugada de entre una lista de jugada validas segun la estrategia de cada jugador implementado.

Token: Clase que contiene un array generico que indica las caras, si bien no fue posible crear un juego con mas de dos caras mantiene esa posibilidad futura.

GetGameRules: Clase que contiene un metodo publico que regresa un objeto game ruler en dependencia de una serie de  numeros actualmente entre 0 y 1 que son los proporcionados por la interface grafica , tiene ademas una serie de metodos privados que consisten en switch case que asignan a las interfaces el valor de algunas de las clases que la implementan para poder construir el objeto gamerules.

TokenCreator: Clase que usa Un metodo recursivo para generar una listas de fichas en dependencia de las posibles caras introducidas previamente en la interface grafica, se usa dentro de getgamerule,

Playercreator: Clase que devuelve una lista de jugadores en dependencia de la lista que indica las ia usada y el equipo seleccionado. Tambien permite la creacion de jugadore de IA Random.

Auxiliares: Clase que se dividio en dos devido a su funciones tan diferentes
* la primera parte como su nommbre indica contiene metodos auxiliares que se usan en diferentes partes del programa, el mas importante de estos es el metodo mezclar que permiten alterar el orden de una ista de fichas de forma random el resto son en su mayoria metodos para imprimir en consola que si bien no son utiles para el funcionamiento del progrma si lo son para el mantenimiento y deteccion de errores. 
* la segunda parte contiene el metodo validate setting que indica si la configuracion introducida en la interface grafica es valida de serlo llama a los metodos de las clases getgamerules y players creators. esto se realizo para evitar ejecutar el metodo recursivo dos veces y es posible trasladarla a una clase particular en el futuro.

Game: Clase que contiene un metodo single con un bucle white donde todo el proceso del juego se corre siguiendo las regulaciones establecida por un objeto Gamerules y siguiendo las indicaciones de un arreglos de jugadores.

> Los 5 Puntos variables

* #1 Caras de las fichas: El programa completo se establece de tipo generico, si bien actualmente solo trabaja con string ofrece todo tipo de posibilidaddes futuras
* #2 Condicion para que una jugada sea valida: Se pueden establecer la condicion normal , la condicion de ser mayor en uno , mas otras variaciones
* #3 Orden variable: El jugador en turno se indica por un metodo que para nada esta obligado a seguir un orden predefinido.
* #4 Valor de las fichas : El valor de cada ficha inprenscindible en la actuacion de los jugadores y en la determinacion del ganador tambien se puede cambiar segun se desee
* #5 Condicion de finalizacion: Cada vez que un jugador termina su jugada se  analiza el estado dell juego para comprobar si ya termino, y su condicion para hacerlo es variable.
* #6 Forma de determinar el ganador: por ejemplo la puntuacion  se saca individualmente y la victoria de un jugador indica la victoria de su equipo o cada equipo tiene una puntuacion general.

> Descripcion de la interfaz grafica

 Main Menu: Pantalla inicial de la intefaz posee los las opciones:

 * Simulate Game: Para iniciar en la 
 congiguracion de la simulacion que se va hacer
 * Exit : Para salir de la app.
 
 Setting: Pantalla de configuracion de la simulacion posee las opciones:
 * GameRules: Donde puedes configurar la data del domino y definir las variacion deseada entre los 5 puntos.
 * Players: Donde se configura todo lo relacionado con los jugadores.
 * Continue: Para finalizar las configuraciones y revisar las valides de las misma para iniciar una simulacion.
 * Return: Vuelve a la pantalla anterior.
 
 GameRules: Pantalla de configuracion de varias opciones como:
 * TotalData= se debe definir el total de la data (ejemplo la data del domino normal es 10,{0,1,2,3,4,5,6,7,8,9})
 * DrawData= Debes definir cada una de la data con un string (ya sea que le de valor a cada uno como el domino o ponga palabras diferentes a cada una)
 * Fichas Inciales: El total de fichas con la que inicia un jugador.
 * Las 5 puntos variables de la simulacion(cada uno con dos opciones,la primera la prederterminada del domino)
 * Continuar: Vuelve a la pantalla anterior.
 
 Players: Pantalla donde se configura datos de los jugadores como:
 
 * Single: Definir los juegos como todos contra todos.  
 * CO-OP: Definir el juego por el equipo(si se hace puede definir el total de equipo que se quiere, tomando como maximo el total de jugadores).
 * Total de Jugadores: Definir el total de jugadores. 
 * IA: debes seleccionar para cada jugador el tipo de IA que va usar entre las 3 opciones( basta con tocar una vez en el tipo de IA, y sino sale todas random).
 * Equipo: Definir a cada jugador en un equipo existente.
 * Continuar: VUelve para la pantalla anterior.

 Status: Pantalla donde se informa todas las configuraciones escojidas y tiene como opcion:

 * continue: Empieza la simulacion si todas las opciones escojidas permiten crear una simulacion.
 * return: vuelve a la pantalla anterior.

 Game: Pantalla donde se desarrolla la simulacion tiene como opcion:

 * simulate again: permite repetir la simulacion hecha.
 * Exit: Termina el programa.

> Descripcion de las opciones de cada Interface

Ivalitator:

* Opcion #1: La usual en el domino
* Opcion #2(Solo funciona correctamente para data numericas):Una ficha se puede jugar por una cara si es mayor en uno que dicha cara, la cara 0 se juega sobre la ficha de mayor valor en la mesa.

Ivalorator:

* Opcion #1: EL valor de una ficha es la suma del valor de sus caras.
* Opcion #2: El Valor de una Ficha es el MCD de sus caras.

IOrder:
* Opcion #1: Los jugadores juegan en orden ascendente.
* Opcion #2: Cuando un jugador se pasa se invierte el orden, permanece asi un ciclo completo y cuando otro jugador se pasa se vuelve a invertir.

IFinisher:

* Opcion #1: El juego finaliza cuando un jugador se pegue o cuando ninguno lleve.
* Opcion #2: El juego finaliza cuando cada jugador se ha pasado al menos una vez o se cumpla la opcion #1.

IResult:

* Opcion #1: La puntuacion es individual.y la victoria de un jugador indica la victoria de su equipo.
* Opcion #2: La puntuacion es por equipo.(En caso de no haber equipo ambas opciones son equivalentes)
