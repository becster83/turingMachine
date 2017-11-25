using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TuringMachine
{
    public class TuringTape //user
    {
        /// maxLimit is kept(hardcoded) at 100 for the infinite tape. This can be increased by changing value of maxLimit here
        public const int maxLimit = 100;
        
        private bool _stack_overflow;
        int  _index;  ///index of slot on tape
        
        /// This propery store the state of whether turing machine is going beyond tape limits.. Unlike theoretical turing machine which 
        /// infinite tape, this machine has finite tape and hence need to take care of limits.
        public bool Tape_overflow
        {
            get { return _stack_overflow; }
            set { _stack_overflow = value; }
        }

        public int tapeSlot
        {
            get { return _index; }
            set { _index = value; }
        }

        /// Constructor
        public TuringTape()
        {
            _index = 0;
            _stack_overflow = false;
         }
   
        /// move turing machine to the left on tape/ decreament the index by 1
        public void move_left()
        {
            _index--;
            if (_index < 0)
            {
                _index = 0; //reset it if any transitions after tape has ended.
                Tape_overflow = true;
            }
        }

        /// move turing machine to the right on tape/ increament the index by 1
        public void move_right()
        {
            _index++;
            if (_index > maxLimit - 1)   //Checking the max limit
            {
                Tape_overflow = true;
            }
        }

    }

    /// This class inherit TuringTape class and provide functionality of turing machine to remember the state. This also provide check to
    /// stop the machine when state is in predefined accepted state.
    public class TuringMachine : TuringTape   //start
    {
              
        int current_state;

        /// Constructor
        public TuringMachine()
        {
            current_state = 0;
        }

        /// return current state
        public int get_current_state()
        {
            return current_state;
        }

        /// set current state
        /// <param name="state"></param>
        public void set_current_state(int state)
        {
            current_state = state;
        }

        /// Return true if state is in accepted state. else it returns false
        public bool is_accepted()
        {
            if ((current_state >= 80) && (current_state <= 99))
                return true;
            else
                return false;
        }
    };


}
