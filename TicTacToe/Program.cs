using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {

            int play = 1;

            while (play == 1)
            {


                BLUE();

                Console.WriteLine("TIC TAC TOE" + "\n\n");


                //Tic Tac Toe Box is a 3 x 3 matrix
                string[,] XOBox = new string[3, 3];

                //Keeps track of current player
                string current_player;

                //Used to determine whether Player 1 or Player 2 has won in order to stop the while loop
                bool Win = false;

                //Used to determine whether Player 1 and Player 2 have a draw
                bool Draw = false;

                //Keeps track of number of moves made in the game so far
                int moves_made = 0;


                //Initialize Box with numbers 1 to 9
                DrawBox(XOBox);


                Console.WriteLine();



                while (Win == false || Draw == false)
                {



                    //PLAYER 1: X's
                    Console.WriteLine("\n\n\n" + "YOUR MOVE, PLAYER 1 [X]!");
                    current_player = "X";
                    int P1_position = EnterOption();



                    bool available = CheckBoxAvailability(XOBox, P1_position);

                    if (available == true)
                    {

                        RedrawBox(XOBox, current_player, P1_position);

                        //if (moves_made < 9)  moves_made++;
                        //if moves == 9 no more moves can be made: check for draw

                    }

                    else
                        Retry(XOBox, current_player);



                    if (moves_made < 9) moves_made++;
                    Console.WriteLine("Moves made so far: {0} out of 9", moves_made);


                    //Check for a Draw
                    Draw = DrawGame(Win, moves_made);

                    if (Draw == true)
                    {

                        Console.WriteLine("\n\nNO WINNERS. GAME ENDS IN A TIE.\n\n");

                        break;

                    }


                    //Check for a Win
                    Win = IsWinner(XOBox, current_player);

                    if (Win == true)
                    {

                        Console.WriteLine("CONGRATULATIONS! PLAYER 1, {0}, WINS!", current_player);

                        break;

                    }

                    ////////////////////////////////////////////////////////////////////////////


                    //PLAYER 2: O's
                    Console.WriteLine("\n\n\n" + "YOUR MOVE, PLAYER 2 [O]!");
                    current_player = "O";
                    int P2_position = EnterOption();


                    available = CheckBoxAvailability(XOBox, P2_position);

                    if (available == true)
                    {

                        RedrawBox(XOBox, current_player, P2_position);

                        //if (moves_made < 9)  moves_made++;
                        //if moves == 9 no more moves can be made: check for draw

                    }

                    else
                        Retry(XOBox, current_player);



                    if (moves_made < 9) moves_made++;
                    Console.WriteLine("Moves made so far: {0} out of 9", moves_made);


                    //Check for a Draw
                    Draw = DrawGame(Win, moves_made);

                    if (Draw == true)
                    {

                        Console.WriteLine("\n\nNO WINNERS. GAME DRAWN.\n\n");

                        break;

                    }


                    //Check for a Win
                    Win = IsWinner(XOBox, current_player);

                    if (Win == true)
                    {

                        Console.WriteLine("CONGRATULATIONS! PLAYER 2, {0}, WINS!", current_player);

                        break;

                    }




                }



                END();

                Console.WriteLine("\n\nPLAY AGAIN? Press 1 (FOR YES) or 2 (IF NO) and then press ENTER:\n\n");
                string replay = Console.ReadLine();

                play = Convert.ToInt32(replay);

                //End continuous play (if option is 2)
                if (play != 1) return;


            }




        }



        public static void BLUE()
        {

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();

        }



        public static void END()
        {

            Console.WriteLine("\n\n" + "<< GAME OVER >>");
            Console.WriteLine("Press any key for more info");
            Console.ReadKey();

        }

        //Used to initially prepare Box with pre-select, numerical options 1-9
        public static void DrawBox(string[,] XOBox)
        {

            int x = 1;
            int i, j;



            //i represents row, XOBox[ROW,]
            for (i = 0; i <= 2; i++)
            {

                //j represents each column, XOBox[,COLUMN]
                for (j = 0; j <= 2; j++)
                {

                    //row 0's columns
                    if (i == 0 && j <= 2)
                    {

                        string converted_no = Convert.ToString(x++);
                        XOBox[i, j] = converted_no;

                        Console.Write("  {0}    || ", XOBox[i, j]);

                    }

                    //Start row on new line
                    //if (i != 0) Console.WriteLine();

                    //row 1's columns
                    if (i == 1 && j <= 2)
                    {

                        string converted_no = Convert.ToString(x++);
                        XOBox[i, j] = converted_no;

                        Console.Write("  {0}    || ", XOBox[i, j]);

                    }

                    //Start row on new line
                    //if (i != 1) Console.WriteLine();

                    //row 2's columns
                    if (i == 2 && j <= 2)
                    {

                        string converted_no = Convert.ToString(x++);
                        XOBox[i, j] = converted_no;

                        Console.Write("  {0}    || ", XOBox[i, j]);

                    }




                }

                //Skip a line for each new row, i
                Console.WriteLine();

            }

        }



        public static void RedrawBox(string[,] XOBox, string current_player, int block)
        {

            //Clear everything that was  previously on the screen for new fresh content coming below:
            Console.Clear();




            int i, j;

            //This will help to identify block number while traversing
            int x = 1;


            //INEFFICIENT WAY USED FOR INITIAL TESTING
            //if (block == 1) XOBox[0,0] = current_player;
            //if (block == 2) XOBox[0,1] = current_player;
            //if (block == 3) XOBox[0,2] = current_player;


            //string block_1 = XOBox[0, 0];
            //string block_2 = XOBox[0, 1];
            //string block_3 = XOBox[0, 2];
            //string block_4 = XOBox[1, 0];
            //string block_5 = XOBox[1, 1];
            //string block_6 = XOBox[1, 2];
            //string block_7 = XOBox[2, 0];
            //string block_8 = XOBox[2, 1];
            //string block_9 = XOBox[2, 2];


            //Traverse array, find position, and insert X or O depending on player
            //if (block == x) XOBox[i, j] = current_player;


            for (i = 0; i <= 2; i++)
            {

                //Console.WriteLine("Current Row is {0}", i);

                for (j = 0; j <= 2; j++)
                {

                    //DRAW ROW 0 (1st Row)
                    if (i == 0 && j <= 2)
                    {


                        if (block == x) XOBox[i, j] = current_player;

                        x++;

                        Console.Write("  {0}  ||", XOBox[i, j]);

                    }



                    //DRAW ROW 1 (2nd Row)
                    if (i == 1 && j <= 2)
                    {

                        if (block == x) XOBox[i, j] = current_player;

                        x++;

                        Console.Write("  {0}  ||", XOBox[i, j]);

                    }



                    //DRAW ROW 2 (3rd Row)
                    if (i == 2 && j <= 2)
                    {

                        if (block == x) XOBox[i, j] = current_player;

                        x++;

                        Console.Write("  {0}  ||", XOBox[i, j]);

                    }


                }

                //New Row, New Line
                Console.WriteLine();


            }



        }


        public static int EnterOption()
        {

            Console.WriteLine("Enter option between 1 to 9 (based on available space): ");
            string str = Console.ReadLine();

            int position = ValidateOption(str);

            return position;

        }


        public static int ValidateOption(string str)
        {

            int loc;

            bool IsNumber = false;


            IsNumber = Int32.TryParse(str, out loc);


            while (loc < 1 || loc > 9 || !IsNumber)
            {

                Console.WriteLine("Invalid Block Selected. Please select a block between 1 to 9.");
                Console.WriteLine("Enter block: ");
                str = Console.ReadLine();

                //loc = Convert.ToInt32(str);
                IsNumber = Int32.TryParse(str, out loc);

            }



            return loc;

        }


        public static void Retry(string[,] XOBox, string current_player)
        {

            bool Available = false;

            int block = 0;

            while (Available == false)
            {

                Console.WriteLine("INVALID: THAT POSITION IS OCCUPIED! TRY AGAIN!");
                Console.WriteLine("\n\nTry entering a space not occupied by an X or an O:\n");
                string str = Console.ReadLine();

                block = Convert.ToInt32(str);

                Available = CheckBoxAvailability(XOBox, block);

            }


            RedrawBox(XOBox, current_player, block);


        }



        public static bool CheckBoxAvailability(string[,] XOBox, int block)
        {

            //Used to determine whether Tic Tac Toe block is empty or occupied
            bool IsAvailable = false;


            //Used for tracking position in Tic Tac Toe box
            int x = 1;


            //We need to convert from numerical position to string, since the array box is string
            string loc = Convert.ToString(block);



            //Traverse array
            //if (    loc.Equals("X") || loc.Equals("O")      )
            //{

            //    IsAvailable = false;

            //}

            //else IsAvailable = true;

            //Implement a while loop for allowing player to choose another block that isn't occupied


            //Search through Tic Tac Toe 3x3 String array for
            int i, j;

            for (i = 0; i <= 2; i++)
            {


                for (j = 0; j <= 2; j++)
                {


                    //ROW 0: Checking 1ST Row
                    if (i == 0 && j <= 2)
                    {

                        //if target position is found, see if it has an X or an O
                        //if it has an X or an O, it is occupied already,
                        //implement option to try another block

                        if (block == x)
                        {

                            if (XOBox[i, j].Equals("X") || XOBox[i, j].Equals("O"))
                                IsAvailable = false;

                            else
                                IsAvailable = true;

                        }

                        x++;

                    }


                    //ROW 1: Checking 2ND Row
                    if (i == 1 && j <= 2)
                    {

                        if (block == x)
                        {

                            if (XOBox[i, j].Equals("X") || XOBox[i, j].Equals("O"))
                                IsAvailable = false;

                            else
                                IsAvailable = true;

                        }

                        x++;

                    }


                    //ROW 2: Checking 3RD Row
                    if (i == 2 && j <= 2)
                    {

                        if (block == x)
                        {

                            if (XOBox[i, j].Equals("X") || XOBox[i, j].Equals("O"))
                                IsAvailable = false;

                            else
                                IsAvailable = true;

                        }

                        x++;

                    }





                }







            }









            return IsAvailable;

        }



        public static bool IsWinner(string[,] XOBox, string current_player)
        {

            bool Win = false;



            string block_1 = XOBox[0, 0];
            string block_2 = XOBox[0, 1];
            string block_3 = XOBox[0, 2];
            string block_4 = XOBox[1, 0];
            string block_5 = XOBox[1, 1];
            string block_6 = XOBox[1, 2];
            string block_7 = XOBox[2, 0];
            string block_8 = XOBox[2, 1];
            string block_9 = XOBox[2, 2];


            //All Possible Win Conditions on a Tic Tac Toe Box
            if (


             //1 2 3
             (block_1.Equals(current_player) && block_2.Equals(current_player) && block_3.Equals(current_player))

                ||

             //4 5 6
             (block_4.Equals(current_player) && block_5.Equals(current_player) && block_6.Equals(current_player))

                ||

             //7 8 9
             (block_7.Equals(current_player) && block_8.Equals(current_player) && block_9.Equals(current_player))

                ||

             //1 4 7
             (block_1.Equals(current_player) && block_4.Equals(current_player) && block_7.Equals(current_player))

                ||

             //1 5 9
             (block_1.Equals(current_player) && block_5.Equals(current_player) && block_9.Equals(current_player))

                ||

             //2 5 8
             (block_2.Equals(current_player) && block_5.Equals(current_player) && block_8.Equals(current_player))

                ||

             //3 6 9
             (block_3.Equals(current_player) && block_6.Equals(current_player) && block_9.Equals(current_player))

                ||

             //3 5 7
             (block_3.Equals(current_player) && block_5.Equals(current_player) && block_7.Equals(current_player))




                ) Win = true;




            return Win;

        }

        public static bool DrawGame(bool Win, int moves_made)
        {

            bool Draw = false;

            //NO WINNERS YET AND ALL 9 MOVES ARE MADE FOR EACH BOX
            if (Win == false && moves_made == 9) Draw = true;



            return Draw;

        }








    }
}