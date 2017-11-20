using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachine
{
    public class TuringTape //user
    {
        /// <summary>
        /// maxLimit is kept(hardcoded) at 100 for the infinite tape. This can be increased by changing value of maxLimit here
        /// </summary>
        public const int maxLimit = 1000;


        private bool _stack_overflow;


        List<char> input;


        int index;
        int _input_position;




        /// <summary>
        /// Return current state (List) of turing machine tape with all updated tape data
        /// </summary>
        public List<char> getTuringMachineTape
        {
            get { return input; }
        }

        /// <summary>
        /// This propery store the state of whether turing machine is going beyond tape limits.. Unlike theoretical turing machine which 
        /// infinite tape, this machine has finite tape and hence need to take care of limits.
        /// </summary>
        public bool Tape_overflow
        {
            get { return _stack_overflow; }
            set { _stack_overflow = value; }
        }

        /// <summary>
        /// This store the 
        /// </summary>
        private int Input_position
        {
            get { return _input_position; }
            set { _input_position = value; }

        }
        /// <summary>
        /// Constructor
        /// </summary>
        public TuringTape()
        {
            index = 10;
            _input_position = 10;
            _stack_overflow = false;
            input = new List<char>(maxLimit + 10);
            for (int i = 0; i < maxLimit; i++)
                input.Add('b');
        }

        /// <summary>
        /// Set the character at current input position
        /// </summary>
        /// <param name="inp"></param>
        public void get_data(char inp)
        {
            input[Input_position] = inp;
            Input_position++;
        }

        /// <summary>
        /// Set the string as array of characters at current input position
        /// </summary>
        /// <param name="inp"></param>
        public void setData(string inputArray)
        {
            foreach (char ch in inputArray.Trim().ToCharArray())
            {
                input[Input_position] = ch;
                Input_position++;
            }
        }

        /// <summary>
        /// Return symbol at current index
        /// </summary>
        /// <returns></returns>
        public char get_symbol() //at current index
        {
            return input[index];
        }


        /// <summary>
        /// Set Tape symbol at current index
        /// </summary>
        /// <param name="inp"></param>
        public void set_symbol(char symbol)
        {
            input[index] = symbol;
        }

        void show_input() { }//not used  

        void display_input() { }//Not used

        /// <summary>
        /// This method will write the symbol to current index on the tape and the tape to left or right depending upon move parameter.
        /// </summary>
        /// <param name="symbol"></param>
        /// <param name="move"></param>
        public void apply_transition(char symbol, char move)
        {
            //current_state = state; TO BE coded later
            set_symbol(symbol);
            if (move == 'l' || move == 'L')
                move_left();
            else
                move_right();
        }

        /// <summary>
        /// move turing machine to the left on tape/ decreament the index by 1
        /// </summary>
        public void move_left()
        {
            index--;
            if (index < 0)
            {
                Tape_overflow = true;
            }

        }

        /// <summary>
        /// move turing machine to the right on tape/ increament the index by 1
        /// </summary>
        public void move_right()
        {
            index++;
            if (index > maxLimit - 1)//Checking the max limit
            {
                Tape_overflow = true;
            }
        }

        /// <summary>
        /// Returns current index
        /// </summary>
        /// <returns></returns>
        public int get_index()
        {
            return index;
        }

        /// <summary>
        /// set current index
        /// </summary>
        /// <param name="inp"></param>
        public void set_index(int inp)
        {
            index = inp;
        }
    }

    /// <summary>
    /// This class inherit TuringTape class and provide functionality of turing machine to remember the state. This also provide check to
    /// stop the machine when state is in predefined accepted state.
    /// </summary>
    public class TuringMachine : TuringTape   //start
    {



        int current_state;

        /// <summary>
        /// Constructor
        /// </summary>
        public TuringMachine()
        {
            current_state = 1;
        }

        /// <summary>
        /// return current state
        /// </summary>
        /// <returns></returns>
        public int get_current_state()
        {
            return current_state;
        }

        /// <summary>
        /// set current state
        /// </summary>
        /// <param name="state"></param>
        public void set_current_state(int state)
        {
            current_state = state;
        }

        /// <summary>
        /// Return true if state is in accepted state. else it returns false
        /// </summary>
        /// <returns></returns>
        public bool is_accepted()
        {
            if ((current_state >= 80) && (current_state <= 99))
                return true;
            else
                return false;
        }
    };


}
