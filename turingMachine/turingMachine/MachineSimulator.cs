using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TuringMachine
{
    class MachineSimulator
    {
        // Constructor
        public MachineSimulator() {
        }

        /// <summary>
        /// Simulate the turing machine
        /// </summary>
        /// <param name="tmloader">Turing machine program</param>
        /// <param name="tm">Turing machine</param>
        /// <param name="delay">delay in milli-seconds between two transition</param>
        /// <param name="surface">Graphics context on which turing machine need to be drawn</param>
        /// <returns>Summary of running turing machine on program</returns>
        private string Simulate(TuringProgramLoader tmloader, TuringMachine tm, int delay)
        {
            int iteration = 0;

            int i_state = 0;
            char input;
            int n_state;
            char output;
            char move;
            bool state_not_found = false;
            DrawTape(tm, surface, tm.get_current_state(), tm.get_symbol());
            Thread.Sleep(delay);

            while ((iteration < 100) && !tm.is_accepted() && !tm.Tape_overflow && !state_not_found)
            {

                input = tm.get_symbol();
                if (tmloader.findTransition(tm.get_current_state(), input, out n_state, out output, out move))
                {
                    i_state = tm.get_current_state();
                    tm.set_current_state(n_state);
                    tm.set_symbol(output);
                    if (move == 'l')
                        tm.move_left();
                    else
                        tm.move_right();

                }
                else
                {
                    state_not_found = true;
                }


                iteration++;
                DrawTape(tm, surface, i_state, input, n_state, output, move);
                if (TuringTransitionCompleted != null)
                    TuringTransitionCompleted(this, new EventArgs());
                Thread.Sleep(delay);

                //getch();



            }
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("");
            sb.AppendLine("********* STATISTICS **********");
            sb.AppendLine("Total Iterations performed are " + iteration);
            sb.AppendLine("current state is " + tm.get_current_state());

            if (iteration >= 100)
                sb.AppendLine("Iterations are infinite");
            if (tm.is_accepted())
                sb.AppendLine("Input String is accepted");
            if (tm.Tape_overflow)
                sb.AppendLine("Execution Tape Overflow");
            if (state_not_found)
                sb.AppendLine("State not found in Transition table :" + tm.get_current_state());
            //textTape.AppendText(sb.ToString());
            //MessageBox.Show("Done");
            return sb.ToString();
        }


        /*  
         *  Run turing machine program on a given input
         *  <param name="fileName">path of the file containing turing machine program</param>
         *  <param name="input">input to turing machine. e.g. 111b111</param>
         *  <param name="surface">Graphics object on which to draw turing machine</param>
         *  <param name="delay">delay in milli-second between two transaction</param> 
        */
        public string Run(string fileName, int delay)
        {
            //Load the program
            TuringProgramLoader tmloader = new TuringProgramLoader();
            tmloader.readTransitions(fileName);

            //Initialize the turing machine and load the input data to turing machine's tape
            //TuringMachine tm = new TuringMachine();
            //tm.setData(input);

            //Run the simulator
            
            return Simulate(tmloader, tm, delay);
        }

    }
}
