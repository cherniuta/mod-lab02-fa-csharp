using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fans
{
    public class State
    {
        public string Name;
        public Dictionary<char, State> Transitions;
        public bool IsAcceptState;
    }


    public class FA1
    {
        public static State startState = new State()
        {
            Name = "start",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State zeroState = new State()
        {
            Name = "zero",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State oneWithZeroState = new State()
        {
            Name = "oneWithZero",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State tooManyZerosState = new State()
        {
            Name = "tooManyZeros",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State acceptState = new State()
        {
            Name = "accept",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        private State initialState = startState;

        public FA1()
        {
            startState.Transitions['0'] = zeroState;
            startState.Transitions['1'] = startState;

            zeroState.Transitions['0'] = tooManyZerosState;
            zeroState.Transitions['1'] = oneWithZeroState;

            oneWithZeroState.Transitions['0'] = tooManyZerosState;
            oneWithZeroState.Transitions['1'] = acceptState;

            tooManyZerosState.Transitions['0'] = tooManyZerosState;
            tooManyZerosState.Transitions['1'] = tooManyZerosState;

            acceptState.Transitions['0'] = tooManyZerosState;
            acceptState.Transitions['1'] = acceptState;
        }

        public bool? Run(IEnumerable<char> input)
        {
            State current = initialState;
            foreach (var symbol in input)
            {
                if (!current.Transitions.TryGetValue(symbol, out current))
                    return null;
            }
            return current.IsAcceptState;
        }
    }


    public class FA2
    {
        public static State evenZeroEvenOne = new State()
        {
            Name = "evenZeroEvenOne",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State evenZeroOddOne = new State()
        {
            Name = "evenZeroOddOne",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State oddZeroEvenOne = new State()
        {
            Name = "oddZeroEvenOne",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State oddZeroOddOne = new State()
        {
            Name = "oddZeroOddOne",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        private State initialState = evenZeroEvenOne;

        public FA2()
        {
            evenZeroEvenOne.Transitions['0'] = oddZeroEvenOne;
            evenZeroEvenOne.Transitions['1'] = evenZeroOddOne;

            evenZeroOddOne.Transitions['0'] = oddZeroOddOne;
            evenZeroOddOne.Transitions['1'] = evenZeroEvenOne;

            oddZeroEvenOne.Transitions['0'] = evenZeroEvenOne;
            oddZeroEvenOne.Transitions['1'] = oddZeroOddOne;

            oddZeroOddOne.Transitions['0'] = evenZeroOddOne;
            oddZeroOddOne.Transitions['1'] = oddZeroEvenOne;
        }

        public bool? Run(IEnumerable<char> input)
        {
            State current = initialState;
            foreach (var symbol in input)
            {
                if (!current.Transitions.TryGetValue(symbol, out current))
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    public class FA3
    {
        public static State startState = new State()
        {
            Name = "start",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State oneState = new State()
        {
            Name = "one",
            IsAcceptState = false,
            Transitions = new Dictionary<char, State>()
        };
        public State acceptState = new State()
        {
            Name = "accept",
            IsAcceptState = true,
            Transitions = new Dictionary<char, State>()
        };
        private State initialState = startState;

        public FA3()
        {
            startState.Transitions['0'] = startState;
            startState.Transitions['1'] = oneState;

            oneState.Transitions['0'] = startState;
            oneState.Transitions['1'] = acceptState;

            acceptState.Transitions['0'] = acceptState;
            acceptState.Transitions['1'] = acceptState;
        }

        public bool? Run(IEnumerable<char> input)
        {
            State current = initialState;
            foreach (var symbol in input)
            {
                if (!current.Transitions.TryGetValue(symbol, out current))
                    return null;
            }
            return current.IsAcceptState;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            String s = "01111";
            FA1 fa1 = new FA1();
            bool? result1 = fa1.Run(s);
            Console.WriteLine(result1);
            FA2 fa2 = new FA2();
            bool? result2 = fa2.Run(s);
            Console.WriteLine(result2);
            FA3 fa3 = new FA3();
            bool? result3 = fa3.Run(s);
            Console.WriteLine(result3);
        }
    }
}