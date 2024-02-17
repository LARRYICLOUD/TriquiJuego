using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriquiJuego
{
    internal class Program
    {

        //CREAMOS UN ARREGLO BIDIMENSIONAL
       static int[,] tablero = new int[3, 3];  //3 filas y 3 columnas
        //Creamos un arreglo para los simbolos del tablero: espacio en blanco, jug.1 , jug.2
        static char[] simbolo = { ' ', '0', 'X' };






        static void Main(string[] args)
        {
            bool terminado = false;

            Console.WriteLine("YO SOY UN PROGRAMADOR Y EXPERTO EN REDES EXCELENTE Y RECONOCIDO");

            Console.WriteLine();
            Console.WriteLine("TRIQUI O TRES EN LINEA");


            //Dibujar el tablero inicial
            DibujarTablero();
            Console.WriteLine("Jugador 1 = O\nJugador 2 = X");

            do
            {

                //Turno jugador
                PreguntarPosicion(1); //Envia el valor de "1" a la funcion PreguntarPosicion

                //Dibujar la casilla del jugador 1
                DibujarTablero();
                //Comprobar si ha ganado la partida el jugador 1
                terminado = ComprobarGanador();

                if(terminado== true)
                {
                    Console.WriteLine("¡El jugador 1 hA ganado!");

                }
                else // delo contrario comprobamos si hubo empate
                {
                    terminado = ComprobarEmpate();
                    if(terminado == true)
                    {
                        Console.WriteLine("¡Esto es un empate!");
                    }

                    //Si jugador 1 no gano, ni hubo empate, entonces es turno del gujador 2
                    else
                    {
                        //Turnop del jugador 2
                        PreguntarPosicion(2);
                        //Dibujar la casilla del jugador 
                        DibujarTablero();
                        //Comprobar si ha ganado la pártida el jugador2
                        terminado = ComprobarGanador();

                        if(terminado == true)
                        {
                            Console.WriteLine("¡El jugador 2 hA ganado!");

                        }
                        
                    }
                }

            } while (terminado == false);  /*Mientras el juego no haya terminado, es decir, mientras la variable sea igual a false, se seguira repitiendop el ciclo*/
            

        }//Cierre de Main

        static void DibujarTablero()

        {
            //Variable de conteo del ciclo
            int fila = 0;
            int columna = 0;

            Console.WriteLine(); //espacio antes de dibujar el tablero
            Console.WriteLine("-------------"); //Dibujar la primera linea horizontal
            for(fila = 0; fila <3; fila++)
            {
                Console.Write("|"); //Dibujar la segunda linea vertical
                for(columna = 0; columna < 3; columna++)
                {   //Asigna un: Espacio, O, X; segun corresponda
                    Console.Write(" {0} |", simbolo[tablero[fila, columna]]);
                }

                Console.WriteLine();
                Console.WriteLine("-------------");// Se encarga de dibujar las lineas horizontales

            }



        }
    
        //Preguntar donde escribir y lo dibuja en el tablero
        static void PreguntarPosicion(int jugador) // 1= jugador1, 2= jugador2

           

        {
            int fila, columna;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador: {0}", jugador);
                //Pedimos el numero de fila
                do
                {
                    Console.Write("Selecciona la fila (1 a 3): ");
                    fila = Convert.ToInt32(Console.ReadLine());


                } while ((fila < 1 || (fila > 3)));
                //Pedimos el numero de columna

                do
                {
                    Console.Write("Selecciona la columna (1 a 3): ");
                    columna = Convert.ToInt32(Console.ReadLine());
                } while ((columna < 1 || (columna > 3)));
                if (tablero[fila -1, columna -1] != 0)
                {
                    Console.WriteLine("Casilla ocupada");
                }


            } while(tablero[fila - 1, columna - 1] != 0);


            //si todo es correcto, se le asigna al jugador correspondiente ********         
            tablero[fila - 1, columna - 1] = jugador;    //jugador       

        }

        //Devuelve un "true" si hay tres en linea
        static bool ComprobarGanador()
        {
            int fila = 0;
            int columna = 0;
            bool ticTacToe = false;
            for(fila=0; fila<3; fila++)
            {
                if ((tablero[fila,0]== tablero[fila,1]) && (tablero[fila,0] == tablero[fila,2] && (tablero[fila,0] != 0)))
                {
                    ticTacToe = true;
                }
            }

            //Si en alguna columna todas las casillas son iguales y vacias
            for(columna = 0; columna <  3; columna++)
            {
                if ((tablero[0, columna] == tablero[1, columna])
                    && (tablero[0, columna] == tablero[2, columna])
                    && (tablero[0, columna] != 0) )


                {
                    ticTacToe = true;
                }
            }

            // Si en alguna diagonal todas las casillas son iguales y no estan vacias
            if ((tablero[0,0]== tablero[1,1])
                && (tablero[0,0]== tablero[2,2])
                && (tablero[0,0] != 0))
            {
                ticTacToe = true;
            }

            if ((tablero[0,2]== tablero[1,1])
                && (tablero[0,2] == tablero[2,0])
                && (tablero[0,2] != 0))
            {
                ticTacToe = true;
            }
            return ticTacToe;
        }

        //devuelv el valor de "true" si hay empate
        static bool ComprobarEmpate()
        {
            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for(fila= 0; fila <3; fila++)
            {
                for(columna=0; columna< 3; columna++)
                {
                    if (tablero[fila,columna] ==0) // si encuentra una sola casilla vacia quiere decir que aun se puede seguir jugando 
                    {
                        hayEspacio = true;                    
                    
                    }
                }
            }
            return !hayEspacio; //Si el ciclo anterior nos regresa un "true" indicandonos que si hay espacio, entonces tiene que regresar una negacion de true para que la condicion de empate no se cumpla en la funcion de Main()


        }
    }
}
