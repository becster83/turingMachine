using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TuringMachine
{

    public enum headDirection
    {
        Left = -1,
        NoMove = 0,
        Right = 1
    }

    class transition
    {
        int _initialState;
        char _read;
        char _write;
        char _headDirection;
        int _nextState;

        //Constructor
        public transition()
        {
            _initialState = 0;
            _read = '0';
            _write = '0';
            _headDirection = '0';
            _nextState = 0;

        }

        public int initialState
        {
            get { return _initialState; }
            set { _initialState = value; }
        }

        public char read
        {
            get { return _read; }
            set { _read = value; }
        }

   
        public char write
        {
            get { return _write; }
            set { _write = value; }
        }

        public char headDirection
        {
            get { return _headDirection; }
            set { _headDirection = value; }
        }

        public int nextState
        {
            get { return _nextState; }
            set { _nextState = value; }
        }

        public transition(int initialState, char read, char write, char headDirection, int nextState)
        {
            _initialState = initialState;
            _read = read;
            _write = write;
            _headDirection = headDirection;
            _nextState = nextState;
        }

        /// This method return true if state passes matches the inputState and input character matches the Input. Else it returns false.
        /// <param name="i_s"></param>
        /// <param name="i"></param>
        /// <returns></returns>
        public bool findTransition(int i_s, char r)
        {
            if (i_s == _initialState && r == _read)
                return true;
            else
                return false;
        }
    }

    public class TuringProgram
    {
        List<transition> turingProgram;

        /// Constructor
        public TuringProgram()
        {
            turingProgram = new List<transition>();
        }


        // This method takes the 5 values as input and insert them into turing machine program tuple
        public void insertTransition(int initialState, char read, char write, char headDirection, int nextState)
        {
            turingProgram.Add(new transition(initialState, read, write, headDirection, nextState ));
        }

        /// <summary>
        /// This method search through the turing machine program tuples to find a match for a given state and given input
        /// </summary>
        /// <param name="initialState">input parameter</param>
        /// <param name="read">input parameter</param>
        /// <param name="write">Output Parameter</param>
        /// <param name="headDirection">Output Parameter</param>
        /// <param name="nextState">Output Parameter</param>
        /// <returns></returns>
        /// 
        public bool findTransition(int initialState, char read, out char write, out char headDirection, out int nextState)
        {
       
            write = '0';
            headDirection = '0';
            nextState = 0;
            if (turingProgram != null)
            {
                foreach (transition transition in turingProgram)
                {
                    if (transition.findTransition(initialState, read))
                    {
                        write = transition.write;
                        headDirection = transition.headDirection;
                        nextState = transition.nextState;
                        return true;
                    }

                }
            }
            return false;

        }

    };


    /// Class TuringProgramLoader provides methods to load the transitions/turing machine program from file to TuringProgram object.
    /// This class extends the TuringProgram class
    public class TuringProgramLoader : TuringProgram
    {
        public TuringProgramLoader()
        {

        }

        /// Read turing machine program from the file. 
        /// <param name="fileName">Full path of the file which contains the turing machine program</param>
        public void readTransitions(string fileName)
        {
            if (fileName == null)
            {
                throw new MissingFieldException("fileName is empty");
            }

            int index = 0;
            try
            {

                FileStream fs1 = File.OpenRead(fileName);
                StreamReader reader;
                reader = new StreamReader(fs1);

                string str = string.Empty;
                str = reader.ReadLine();
                while (!reader.EndOfStream && str.Length < 1)
                {
                    str = reader.ReadLine();
                    //Console.WriteLine(str);
                    index++;
                }

                while (index++ < 100) //Putting an upper limit on number of transitions to be read
                {

                    if (!string.IsNullOrEmpty(str))
                    {
                        int initialState;
                        char read;
                        char write;
                        char headDirection;
                        int nextState;

                        //Console.WriteLine(str);

                        // transition format should be "1 1 2 r 0"
                        string[] temparr = str.Split(' ');
                        initialState = Int32.Parse(temparr[0]);
                        read = char.Parse(temparr[1]);
                        write = char.Parse(temparr[2]);
                        headDirection = char.Parse(temparr[3]);
                        nextState = Int32.Parse(temparr[4]);

                        /*
                        Console.WriteLine("initialState: " + initialState);
                        Console.WriteLine("read: " + read);
                        Console.WriteLine("write: " + write);
                        Console.WriteLine("headDirection: " + headDirection);
                        Console.WriteLine("nextState: " + nextState);
                        */
                        insertTransition(initialState, read, write, headDirection, nextState); // calling parent class method

                        if (reader.EndOfStream)
                        { break; }
                        str = reader.ReadLine();
                    }

                }
            }
            catch (Exception ex)
            {
                throw new FormatException(string.Format("Error reading values at index: %d in input transition file: %s. Exception is: %s. Inner exception: %s ", index, fileName, ex.Message, ex.InnerException));

            }
        }
    }
}
