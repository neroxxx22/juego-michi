using System;


namespace ConsoleApp11{
    class Program
    {
        static void Main()
        {
            char[,] tablero = new char[3, 3]; 
            InicializarTablero(tablero);

            Console.WriteLine("¡Bienvenido al juego del Michi!");
            Console.Write("Elija su símbolo (X/O): ");
            char jugador1 = ElegirSimbolo();
            char jugador2 = (jugador1 == 'X') ? 'O' : 'X';

            Console.WriteLine($"\nJugador 1: {jugador1}");
            Console.WriteLine($"Jugador 2: {jugador2}");

            bool juegoTerminado = false;
            char jugadorActual = jugador1;
            int turnos = 0;

            while (!juegoTerminado && turnos < 9) 
            {
                Console.Clear();
                MostrarTablero(tablero);
                Console.WriteLine($"\nTurno del jugador {jugadorActual}");

                int fila, columna;
                do
                {
                    Console.Write("Ingrese fila (0-2): ");
                    fila = LeerEntero(0, 2);
                    Console.Write("Ingrese columna (0-2): ");
                    columna = LeerEntero(0, 2);

                    if (tablero[fila, columna] != ' ')
                    {
                        Console.WriteLine("Esa posición ya está ocupada. Intente de nuevo.");
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                tablero[fila, columna] = jugadorActual;
                turnos++;

                
                if (HayGanador(tablero, jugadorActual))
                {
                    juegoTerminado = true;
                    Console.Clear();
                    MostrarTablero(tablero);
                    Console.WriteLine($"\n¡El jugador {jugadorActual} gana!");
                }
                else
                {
                  
                    jugadorActual = (jugadorActual == jugador1) ? jugador2 : jugador1;
                }
            }

            if (!juegoTerminado)
            {
                Console.Clear();
                MostrarTablero(tablero);
                Console.WriteLine("\nEl juego termina en empate.");
            }
        }

        static void InicializarTablero(char[,] tablero)
        {
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    tablero[i, j] = ' ';
                }
            }
        }

        static void MostrarTablero(char[,] tablero)
        {
            Console.WriteLine("  0   1   2");
            for (int i = 0; i < tablero.GetLength(0); i++)
            {
                Console.Write($"{i} ");
                for (int j = 0; j < tablero.GetLength(1); j++)
                {
                    MostrarSimbolo(tablero[i, j]);
                    if (j < 2) Console.Write(" | ");
                }
                Console.WriteLine();
                if (i < 2) Console.WriteLine(" ---+---+---");
            }
        }

        static void MostrarSimbolo(char simbolo)
        {
            switch (simbolo)
            {
                case 'X':
                    Console.ForegroundColor = ConsoleColor.Green; 
                    Console.Write(simbolo);
                    break;
                case 'O':
                    Console.ForegroundColor = ConsoleColor.Red; 
                    Console.Write(simbolo);
                    break;
               
            }
            Console.ResetColor(); 
        }

        static char ElegirSimbolo()
        {
            char simbolo;
            do
            {
                simbolo = Console.ReadLine().ToUpper()[0];
                if (simbolo != 'X' && simbolo != 'O')
                {
                    Console.Write("Entrada inválida. Por favor, elija 'X' o 'O': ");
                }
            } while (simbolo != 'X' && simbolo != 'O');

            return simbolo;
        }

        static int LeerEntero(int min, int max)
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor) || valor < min || valor > max)
            {
                Console.WriteLine($"Por favor, ingrese un número entre {min} y {max}.");
            }
            return valor;
        }

        static bool HayGanador(char[,] tablero, char jugador)
        {
         
            for (int i = 0; i < 3; i++)
            {
                if ((tablero[i, 0] == jugador && tablero[i, 1] == jugador && tablero[i, 2] == jugador) ||
                    (tablero[0, i] == jugador && tablero[1, i] == jugador && tablero[2, i] == jugador))
                {
                    return true;
                }
            }

           
            if ((tablero[0, 0] == jugador && tablero[1, 1] == jugador && tablero[2, 2] == jugador) ||
                (tablero[0, 2] == jugador && tablero[1, 1] == jugador && tablero[2, 0] == jugador))
            {
                return true;
            }

            return false;
        }
    }

}

