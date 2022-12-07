using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    internal class Instructions
    {
        public int Qty { get; set; }
        public int Start { get; set; }
        public int End { get; set; }

        public Instructions(int qty, int start, int end)
        {
            Qty = qty;
            Start = start - 1;
            End = end - 1;
        }
    }
    internal class SupplyStacks
    {
        static void Main(string[] args)
        {
            /*
             *  --- Day 5: Supply Stacks ---

                The expedition can depart as soon as the final supplies have been unloaded from the ships. Supplies 
                are stored in stacks of marked crates, but because the needed supplies are buried under many other 
                crates, the crates need to be rearranged.

                The ship has a giant cargo crane capable of moving crates between stacks. To ensure none of the crates 
                get crushed or fall over, the crane operator will rearrange them in a series of carefully-planned steps. 
                After the crates are rearranged, the desired crates will be at the top of each stack.

                The Elves don't want to interrupt the crane operator during this delicate procedure, but they forgot to 
                ask her which crate will end up where, and they want to be ready to unload them as soon as possible so 
                they can embark.

                They do, however, have a drawing of the starting stacks of crates and the rearrangement procedure (your 
                puzzle input). For example:

                    [D]    
                [N] [C]    
                [Z] [M] [P]
                 1   2   3 
                
                move 1 from 2 to 1
                move 3 from 1 to 3
                move 2 from 2 to 1
                move 1 from 1 to 2
                
                In this example, there are three stacks of crates. Stack 1 contains two crates: crate Z is on the bottom, 
                and crate N is on top. Stack 2 contains three crates; from bottom to top, they are crates M, C, and D. 
                Finally, stack 3 contains a single crate, P.

                Then, the rearrangement procedure is given. In each step of the procedure, a quantity of crates is moved 
                from one stack to a different stack. In the first step of the above rearrangement procedure, one crate is 
                moved from stack 2 to stack 1, resulting in this configuration:

                [D]        
                [N] [C]    
                [Z] [M] [P]
                 1   2   3 
                
                In the second step, three crates are moved from stack 1 to stack 3. Crates are moved one at a time, so the 
                first crate to be moved (D) ends up below the second and third crates:
                
                        [Z]
                        [N]
                    [C] [D]
                    [M] [P]
                 1   2   3
                
                Then, both crates are moved from stack 2 to stack 1. Again, because crates are moved one at a time, crate C 
                ends up below crate M:
                
                        [Z]
                        [N]
                [M]     [D]
                [C]     [P]
                 1   2   3
                
                Finally, one crate is moved from stack 1 to stack 2:
                
                        [Z]
                        [N]
                        [D]
                [C] [M] [P]
                 1   2   3
                
                The Elves just need to know which crate will end up on top of each stack; in this example, the top crates are C 
                in stack 1, M in stack 2, and Z in stack 3, so you should combine these together and give the Elves the message CMZ.

                After the rearrangement procedure completes, what crate ends up on top of each stack?

             */

            #region DataEntry
            /*
                                    [L]     [H] [W] 
                                [J] [Z] [J] [Q] [Q]
                [S]             [M] [C] [T] [F] [B]
                [P]     [H]     [B] [D] [G] [B] [P]
                [W]     [L] [D] [D] [J] [W] [T] [C]
                [N] [T] [R] [T] [T] [T] [M] [M] [G]
                [J] [S] [Q] [S] [Z] [W] [P] [G] [D]
                [Z] [G] [V] [V] [Q] [M] [L] [N] [R]
                 1   2   3   4   5   6   7   8   9
            */
            #region Crate Setup

            List<Stack<string>> crates = new List<Stack<string>>();
            crates.Add(new Stack<string>());
            crates.Add(new Stack<string>());
            crates.Add(new Stack<string>());
            crates.Add(new Stack<string>());
            crates.Add(new Stack<string>());
            crates.Add(new Stack<string>());
            crates.Add(new Stack<string>());
            crates.Add(new Stack<string>());
            crates.Add(new Stack<string>());
            crates[0].Push("Z");
            crates[0].Push("J");
            crates[0].Push("N");
            crates[0].Push("W");
            crates[0].Push("P");
            crates[0].Push("S");
            crates[1].Push("G");
            crates[1].Push("S");
            crates[1].Push("T");
            crates[2].Push("V");
            crates[2].Push("Q");
            crates[2].Push("R");
            crates[2].Push("L");
            crates[2].Push("H");
            crates[3].Push("V");
            crates[3].Push("S");
            crates[3].Push("T");
            crates[3].Push("D");
            crates[4].Push("Q");
            crates[4].Push("Z");
            crates[4].Push("T");
            crates[4].Push("D");
            crates[4].Push("B");
            crates[4].Push("M");
            crates[4].Push("J");
            crates[5].Push("M");
            crates[5].Push("W");
            crates[5].Push("T");
            crates[5].Push("J");
            crates[5].Push("D");
            crates[5].Push("C");
            crates[5].Push("Z");
            crates[5].Push("L");
            crates[6].Push("L");
            crates[6].Push("P");
            crates[6].Push("M");
            crates[6].Push("W");
            crates[6].Push("G");
            crates[6].Push("T");
            crates[6].Push("J");
            crates[7].Push("N");
            crates[7].Push("G");
            crates[7].Push("M");
            crates[7].Push("T");
            crates[7].Push("B");
            crates[7].Push("F");
            crates[7].Push("Q");
            crates[7].Push("H");
            crates[8].Push("R");
            crates[8].Push("D");
            crates[8].Push("G");
            crates[8].Push("C");
            crates[8].Push("P");
            crates[8].Push("B");
            crates[8].Push("Q");
            crates[8].Push("W");
            #endregion

            //Qty Start End
            Instructions[] instructions =
            {
                new Instructions(1, 3, 5),
                new Instructions(2, 2 , 8  ),
                new Instructions(4, 1 , 3  ),
                new Instructions(2, 1 , 4  ),
                new Instructions(1, 7 , 1  ),
                new Instructions(2, 9 , 7  ),
                new Instructions(4, 5 , 9  ),
                new Instructions(7, 8 , 9  ),
                new Instructions(2, 5 , 2  ),
                new Instructions(1, 2 , 9  ),
                new Instructions(1, 1 , 8  ),
                new Instructions(1, 2 , 7  ),
                new Instructions(3, 8 , 2  ),
                new Instructions(6, 9 , 7  ),
                new Instructions(5, 4 , 1  ),
                new Instructions(7, 9 , 5  ),
                new Instructions(1, 4 , 5  ),
                new Instructions(4, 1 , 7  ),
                new Instructions(1, 8 , 1  ),
                new Instructions(4, 7 , 9  ),
                new Instructions(1, 5 , 8  ),
                new Instructions(9, 9 , 3  ),
                new Instructions(1, 8 , 9  ),
                new Instructions(1, 1 , 5  ),
                new Instructions(4, 3 , 2  ),
                new Instructions(10, 5 , 3 ),
                new Instructions(8, 2 , 8  ),
                new Instructions(7, 8 , 3  ),
                new Instructions(9, 7 , 5  ),
                new Instructions(1, 9 , 3  ),
                new Instructions(3, 6 , 4  ),
                new Instructions(3, 7 , 6  ),
                new Instructions(1, 8 , 7  ),
                new Instructions(1, 1 , 8  ),
                new Instructions(1, 4 , 7  ),
                new Instructions(5, 7 , 6  ),
                new Instructions(14, 3 , 7 ),
                new Instructions(16, 3 , 9 ),
                new Instructions(1, 8 , 4  ),
                new Instructions(2, 4 , 9  ),
                new Instructions(1, 3 , 7  ),
                new Instructions(1, 6 , 8  ),
                new Instructions(15, 7 , 2 ),
                new Instructions(10, 9 , 7 ),
                new Instructions(7, 2 , 4  ),
                new Instructions(1, 2 , 7  ),
                new Instructions(11, 6 , 7 ),
                new Instructions(5, 5 , 9  ),
                new Instructions(15 , 7 , 8 ),
                new Instructions(1 , 7 , 2  ),
                new Instructions(2 , 9 , 7  ),
                new Instructions(4 , 5 , 1  ),
                new Instructions(5 , 4 , 9  ),
                new Instructions(6 , 2 , 4  ),
                new Instructions(2 , 2 , 5  ),
                new Instructions(2 , 1 , 4  ),
                new Instructions(1 , 1 , 5  ),
                new Instructions(3 , 5 , 6  ),
                new Instructions(8 , 7 , 9  ),
                new Instructions(9 , 4 , 9  ),
                new Instructions(1 , 4 , 8  ),
                new Instructions(11 , 9 , 7 ),
                new Instructions(4 , 6 , 1  ),
                new Instructions(17 , 8 , 7 ),
                new Instructions(26 , 7 , 1 ),
                new Instructions(1 , 4 , 8  ),
                new Instructions(24 , 1 , 7 ),
                new Instructions(22 , 9 , 3 ),
                new Instructions(1 , 8 , 2  ),
                new Instructions(6 , 3 , 4  ),
                new Instructions(2 , 1 , 2  ),
                new Instructions(1 , 7 , 9  ),
                new Instructions(16 , 7 , 3 ),
                new Instructions(1 , 9 , 5  ),
                new Instructions(6 , 4 , 1  ),
                new Instructions(1 , 2 , 7  ),
                new Instructions(6 , 3 , 2  ),
                new Instructions(1 , 5 , 4  ),
                new Instructions(6 , 3 , 5  ),
                new Instructions(1 , 4 , 1  ),
                new Instructions(3 , 1 , 4  ),
                new Instructions(4 , 5 , 4  ),
                new Instructions(7 , 1 , 7  ),
                new Instructions(6 , 4 , 3  ),
                new Instructions(1 , 1 , 6  ),
                new Instructions(1 , 2 , 5  ),
                new Instructions(1 , 1 , 7  ),
                new Instructions(15 , 3 , 1 ),
                new Instructions(2 , 2 , 7  ),
                new Instructions(3 , 5 , 8  ),
                new Instructions(9 , 7 , 5  ),
                new Instructions(8 , 5 , 7  ),
                new Instructions(3 , 8 , 5  ),
                new Instructions(1 , 6 , 9  ),
                new Instructions(5 , 7 , 8  ),
                new Instructions(3 , 2 , 4  ),
                new Instructions(2 , 2 , 5  ),
                new Instructions(4 , 3 , 7  ),
                new Instructions(5 , 8 , 3  ),
                new Instructions(1 , 5 , 8  ),
                new Instructions(5 , 3 , 1  ),
                new Instructions(2 , 5 , 7  ),
                new Instructions(1 , 9 , 8  ),
                new Instructions(1 , 5 , 8  ),
                new Instructions(19 , 1 , 4 ),
                new Instructions(19 , 7 , 1 ),
                new Instructions(7 , 1 , 4  ),
                new Instructions(1 , 7 , 4  ),
                new Instructions(3 , 3 , 5  ),
                new Instructions(22 , 4 , 5 ),
                new Instructions(3 , 8 , 3  ),
                new Instructions(7 , 1 , 8  ),
                new Instructions(3 , 3 , 5  ),
                new Instructions(3 , 3 , 6  ),
                new Instructions(3 , 6 , 9  ),
                new Instructions(3 , 9 , 1  ),
                new Instructions(1 , 3 , 4  ),
                new Instructions(2 , 8 , 9  ),
                new Instructions(25 , 5 , 6 ),
                new Instructions(4 , 1 , 5  ),
                new Instructions(5 , 5 , 4  ),
                new Instructions(2 , 8 , 2  ),
                new Instructions(1 , 9 , 2  ),
                new Instructions(3 , 5 , 7  ),
                new Instructions(12 , 6 , 8 ),
                new Instructions(1 , 7 , 3  ),
                new Instructions(7 , 8 , 1  ),
                new Instructions(1 , 5 , 7  ),
                new Instructions(1 , 3 , 8  ),
                new Instructions(2 , 7 , 4  ),
                new Instructions(6 , 8 , 5  ),
                new Instructions(10 , 6 , 3 ),
                new Instructions(2 , 6 , 2  ),
                new Instructions(1 , 6 , 3  ),
                new Instructions(17 , 4 , 6 ),
                new Instructions(3 , 3 , 9  ),
                new Instructions(3 , 8 , 4  ),
                new Instructions(1 , 7 , 5  ),
                new Instructions(1 , 3 , 8  ),
                new Instructions(1 , 2 , 5  ),
                new Instructions(10 , 1 , 7 ),
                new Instructions(3 , 2 , 7  ),
                new Instructions(2 , 1 , 8  ),
                new Instructions(15 , 6 , 3 ),
                new Instructions(7 , 5 , 9  ),
                new Instructions(9 , 9 , 5  ),
                new Instructions(1 , 9 , 3  ),
                new Instructions(2 , 3 , 5  ),
                new Instructions(3 , 8 , 6  ),
                new Instructions(1 , 9 , 3  ),
                new Instructions(11 , 5 , 8 ),
                new Instructions(9 , 3 , 8  ),
                new Instructions(1 , 5 , 6  ),
                new Instructions(9 , 8 , 5  ),
                new Instructions(10 , 7 , 5 ),
                new Instructions(5 , 5 , 3  ),
                new Instructions(4 , 6 , 8  ),
                new Instructions(2 , 6 , 8  ),
                new Instructions(2 , 5 , 6  ),
                new Instructions(1 , 2 , 1  ),
                new Instructions(9 , 5 , 3  ),
                new Instructions(2 , 7 , 5  ),
                new Instructions(3 , 5 , 4  ),
                new Instructions(1 , 4 , 1  ),
                new Instructions(2 , 4 , 3  ),
                new Instructions(1 , 7 , 1  ),
                new Instructions(2 , 1 , 7  ),
                new Instructions(3 , 4 , 5  ),
                new Instructions(2 , 7 , 3  ),
                new Instructions(14 , 3 , 9 ),
                new Instructions(13 , 3 , 1 ),
                new Instructions(8 , 1 , 4  ),
                new Instructions(6 , 1 , 2  ),
                new Instructions(11 , 8 , 6 ),
                new Instructions(4 , 3 , 9  ),
                new Instructions(2 , 9 , 2  ),
                new Instructions(1 , 5 , 2  ),
                new Instructions(6 , 4 , 9  ),
                new Instructions(6 , 8 , 9  ),
                new Instructions(6 , 9 , 4  ),
                new Instructions(2 , 4 , 7  ),
                new Instructions(4 , 4 , 6  ),
                new Instructions(4 , 2 , 9  ),
                new Instructions(2 , 7 , 9  ),
                new Instructions(2 , 2 , 1  ),
                new Instructions(3 , 5 , 3  ),
                new Instructions(2 , 1 , 7  ),
                new Instructions(1 , 5 , 2  ),
                new Instructions(7 , 9 , 7  ),
                new Instructions(2 , 2 , 8  ),
                new Instructions(10 , 6 , 5 ),
                new Instructions(5 , 5 , 6  ),
                new Instructions(9 , 7 , 8  ),
                new Instructions(3 , 3 , 9  ),
                new Instructions(4 , 5 , 1  ),
                new Instructions(10 , 9 , 3 ),
                new Instructions(7 , 6 , 2  ),
                new Instructions(5 , 3 , 9  ),
                new Instructions(3 , 1 , 7  ),
                new Instructions(1 , 4 , 7  ),
                new Instructions(1 , 4 , 9  ),
                new Instructions(1 , 3 , 7  ),
                new Instructions(1 , 2 , 1  ),
                new Instructions(1 , 5 , 1  ),
                new Instructions(1 , 1 , 7  ),
                new Instructions(3 , 6 , 3  ),
                new Instructions(3 , 3 , 4  ),
                new Instructions(6 , 7 , 4  ),
                new Instructions(3 , 9 , 8  ),
                new Instructions(9 , 8 , 1  ),
                new Instructions(3 , 8 , 1  ),
                new Instructions(13 , 9 , 5 ),
                new Instructions(2 , 2 , 8  ),
                new Instructions(4 , 8 , 3  ),
                new Instructions(11 , 1 , 2 ),
                new Instructions(14 , 2 , 6 ),
                new Instructions(6 , 3 , 8  ),
                new Instructions(4 , 9 , 7  ),
                new Instructions(10 , 5 , 3 ),
                new Instructions(2 , 7 , 3  ),
                new Instructions(1 , 1 , 8  ),
                new Instructions(1 , 1 , 7  ),
                new Instructions(1 , 7 , 8  ),
                new Instructions(1 , 1 , 4  ),
                new Instructions(8 , 4 , 2  ),
                new Instructions(2 , 5 , 1  ),
                new Instructions(1 , 1 , 9  ),
                new Instructions(1 , 7 , 3  ),
                new Instructions(1 , 9 , 5  ),
                new Instructions(1 , 4 , 2  ),
                new Instructions(1 , 4 , 6  ),
                new Instructions(1 , 7 , 3  ),
                new Instructions(11 , 6 , 9 ),
                new Instructions(4 , 2 , 5  ),
                new Instructions(4 , 2 , 5  ),
                new Instructions(10 , 5 , 6 ),
                new Instructions(9 , 9 , 5  ),
                new Instructions(1 , 9 , 2  ),
                new Instructions(2 , 8 , 4  ),
                new Instructions(1 , 9 , 6  ),
                new Instructions(5 , 2 , 1  ),
                new Instructions(5 , 8 , 6  ),
                new Instructions(4 , 1 , 9  ),
                new Instructions(1 , 8 , 1  ),
                new Instructions(3 , 9 , 4  ),
                new Instructions(5 , 5 , 1  ),
                new Instructions(1 , 9 , 7  ),
                new Instructions(11 , 6 , 3 ),
                new Instructions(4 , 4 , 9  ),
                new Instructions(9 , 6 , 5  ),
                new Instructions(2 , 6 , 5  ),
                new Instructions(3 , 9 , 1  ),
                new Instructions(1 , 4 , 8  ),
                new Instructions(4 , 1 , 3  ),
                new Instructions(3 , 5 , 4  ),
                new Instructions(2 , 4 , 9  ),
                new Instructions(2 , 9 , 4  ),
                new Instructions(1 , 9 , 8  ),
                new Instructions(6 , 5 , 4  ),
                new Instructions(1 , 7 , 8  ),
                new Instructions(3 , 5 , 2  ),
                new Instructions(3 , 8 , 5  ),
                new Instructions(1 , 2 , 1  ),
                new Instructions(24 , 3 , 9 ),
                new Instructions(2 , 2 , 1  ),
                new Instructions(10 , 1 , 7 ),
                new Instructions(18 , 9 , 8 ),
                new Instructions(5 , 3 , 7  ),
                new Instructions(5 , 9 , 5  ),
                new Instructions(12 , 7 , 2 ),
                new Instructions(1 , 7 , 6  ),
                new Instructions(8 , 4 , 7  ),
                new Instructions(1 , 4 , 5  ),
                new Instructions(12 , 5 , 9 ),
                new Instructions(1 , 6 , 9  ),
                new Instructions(3 , 2 , 8  ),
                new Instructions(5 , 7 , 3  ),
                new Instructions(21 , 8 , 7 ),
                new Instructions(3 , 3 , 8  ),
                new Instructions(11 , 9 , 5 ),
                new Instructions(10 , 5 , 6 ),
                new Instructions(3 , 7 , 2  ),
                new Instructions(3 , 6 , 4  ),
                new Instructions(2 , 3 , 1  ),
                new Instructions(2 , 3 , 5  ),
                new Instructions(1 , 1 , 7  ),
                new Instructions(1 , 1 , 4  ),
                new Instructions(3 , 4 , 1  ),
                new Instructions(1 , 9 , 1  ),
                new Instructions(1 , 4 , 3  ),
                new Instructions(3 , 5 , 8  ),
                new Instructions(1 , 9 , 6  ),
                new Instructions(4 , 2 , 3  ),
                new Instructions(6 , 8 , 6  ),
                new Instructions(1 , 9 , 3  ),
                new Instructions(7 , 2 , 4  ),
                new Instructions(5 , 4 , 5  ),
                new Instructions(1 , 2 , 6  ),
                new Instructions(3 , 1 , 9  ),
                new Instructions(3 , 9 , 4  ),
                new Instructions(1 , 1 , 9  ),
                new Instructions(2 , 5 , 3  ),
                new Instructions(3 , 5 , 2  ),
                new Instructions(4 , 7 , 2  ),
                new Instructions(2 , 4 , 3  ),
                new Instructions(2 , 2 , 3  ),
                new Instructions(2 , 4 , 8  ),
                new Instructions(5 , 2 , 3  ),
                new Instructions(6 , 6 , 4  ),
                new Instructions(8 , 7 , 3  ),
                new Instructions(4 , 4 , 5  ),
                new Instructions(1 , 3 , 1  ),
                new Instructions(2 , 8 , 6  ),
                new Instructions(7 , 7 , 5  ),
                new Instructions(1 , 9 , 1  ),
                new Instructions(14 , 3 , 6 ),
                new Instructions(4 , 7 , 1  ),
                new Instructions(6 , 5 , 3  ),
                new Instructions(4 , 1 , 2  ),
                new Instructions(9 , 3 , 5  ),
                new Instructions(1 , 7 , 2  ),
                new Instructions(2 , 3 , 7  ),
                new Instructions(1 , 4 , 8  ),
                new Instructions(1 , 4 , 9  ),
                new Instructions(3 , 3 , 6  ),
                new Instructions(9 , 5 , 2  ),
                new Instructions(1 , 8 , 9  ),
                new Instructions(1 , 1 , 7  ),
                new Instructions(1 , 9 , 3  ),
                new Instructions(1 , 4 , 8  ),
                new Instructions(1 , 9 , 4  ),
                new Instructions(3 , 5 , 1  ),
                new Instructions(2 , 1 , 9  ),
                new Instructions(1 , 4 , 9  ),
                new Instructions(15 , 6 , 9 ),
                new Instructions(3 , 3 , 5  ),
                new Instructions(2 , 1 , 3  ),
                new Instructions(2 , 7 , 4  ),
                new Instructions(5 , 6 , 5  ),
                new Instructions(6 , 2 , 9  ),
                new Instructions(1 , 7 , 2  ),
                new Instructions(2 , 4 , 6  ),
                new Instructions(2 , 3 , 1  ),
                new Instructions(1 , 1 , 6  ),
                new Instructions(1 , 8 , 3  ),
                new Instructions(1 , 3 , 9  ),
                new Instructions(3 , 5 , 1  ),
                new Instructions(3 , 6 , 2  ),
                new Instructions(6 , 5 , 3  ),
                new Instructions(6 , 6 , 8  ),
                new Instructions(4 , 1 , 6  ),
                new Instructions(12 , 9 , 7 ),
                new Instructions(4 , 6 , 8  ),
                new Instructions(1 , 5 , 1  ),
                new Instructions(2 , 8 , 2  ),
                new Instructions(2 , 2 , 1  ),
                new Instructions(5 , 3 , 6  ),
                new Instructions(3 , 1 , 6  ),
                new Instructions(5 , 8 , 6  ),
                new Instructions(1 , 3 , 6  ),
                new Instructions(5 , 2 , 7  ),
                new Instructions(8 , 9 , 4  ),
                new Instructions(15 , 7 , 8 ),
                new Instructions(5 , 6 , 3  ),
                new Instructions(1 , 3 , 8  ),
                new Instructions(15 , 8 , 3 ),
                new Instructions(7 , 2 , 9  ),
                new Instructions(1 , 7 , 4  ),
                new Instructions(10 , 9 , 5 ),
                new Instructions(4 , 6 , 4  ),
                new Instructions(3 , 8 , 6  ),
                new Instructions(1 , 8 , 6  ),
                new Instructions(1 , 7 , 3  ),
                new Instructions(10 , 6 , 9 ),
                new Instructions(7 , 3 , 2  ),
                new Instructions(10 , 9 , 7 ),
                new Instructions(8 , 5 , 7  ),
                new Instructions(8 , 3 , 7  ),
                new Instructions(1 , 5 , 9  ),
                new Instructions(1 , 6 , 8  ),
                new Instructions(1 , 5 , 4  ),
                new Instructions(1 , 8 , 6  ),
                new Instructions(5 , 3 , 8  ),
                new Instructions(9 , 4 , 2  ),
                new Instructions(1 , 9 , 2  ),
                new Instructions(4 , 2 , 3  ),
                new Instructions(2 , 2 , 9  ),
                new Instructions(2 , 4 , 8  ),
                new Instructions(4 , 9 , 1  ),
                new Instructions(1 , 4 , 9  ),
                new Instructions(1 , 7 , 8  ),
                new Instructions(9 , 2 , 1  ),
                new Instructions(1 , 2 , 5  ),
                new Instructions(1 , 5 , 3  ),
                new Instructions(1 , 9 , 3  ),
                new Instructions(4 , 3 , 6  ),
                new Instructions(4 , 8 , 9  ),
                new Instructions(2 , 3 , 6  ),
                new Instructions(2 , 6 , 9  ),
                new Instructions(1 , 4 , 8  ),
                new Instructions(3 , 6 , 3  ),
                new Instructions(2 , 6 , 5  ),
                new Instructions(1 , 5 , 2  ),
                new Instructions(2 , 2 , 1  ),
                new Instructions(9 , 7 , 3  ),
                new Instructions(7 , 3 , 9  ),
                new Instructions(9 , 9 , 8  ),
                new Instructions(10 , 7 , 1 ),
                new Instructions(3 , 9 , 3  ),
                new Instructions(3 , 3 , 1  ),
                new Instructions(5 , 8 , 3  ),
                new Instructions(1 , 9 , 3  ),
                new Instructions(1 , 5 , 6  ),
                new Instructions(3 , 8 , 4  ),
                new Instructions(1 , 8 , 4  ),
                new Instructions(2 , 8 , 2  ),
                new Instructions(7 , 3 , 8  ),
                new Instructions(4 , 4 , 2  ),
                new Instructions(1 , 4 , 6  ),
                new Instructions(1 , 8 , 1  ),
                new Instructions(5 , 7 , 5  ),
                new Instructions(2 , 6 , 7  ),
                new Instructions(3 , 8 , 7  ),
                new Instructions(2 , 2 , 1  ),
                new Instructions(23 , 1 , 6 ),
                new Instructions(2 , 3 , 5  ),
                new Instructions(1 , 3 , 6  ),
                new Instructions(1 , 7 , 2  ),
                new Instructions(22 , 6 , 4 ),
                new Instructions(5 , 2 , 7  ),
                new Instructions(6 , 5 , 3  ),
                new Instructions(17 , 4 , 1 ),
                new Instructions(5 , 8 , 2  ),
                new Instructions(23 , 1 , 7 ),
                new Instructions(5 , 3 , 1  ),
                new Instructions(15 , 7 , 2 ),
                new Instructions(2 , 3 , 4  ),
                new Instructions(1 , 8 , 4  ),
                new Instructions(5 , 1 , 9  ),
                new Instructions(6 , 7 , 1  ),
                new Instructions(8 , 4 , 6  ),
                new Instructions(4 , 9 , 5  ),
                new Instructions(3 , 5 , 7  ),
                new Instructions(1 , 9 , 1  ),
                new Instructions(7 , 7 , 4  ),
                new Instructions(7 , 1 , 5  ),
                new Instructions(10 , 2 , 3 ),
                new Instructions(4 , 2 , 4  ),
                new Instructions(6 , 2 , 8  ),
                new Instructions(7 , 6 , 7  ),
                new Instructions(7 , 3 , 1  ),
                new Instructions(3 , 6 , 2  ),
                new Instructions(5 , 8 , 7  ),
                new Instructions(7 , 5 , 7  ),
                new Instructions(1 , 5 , 6  ),
                new Instructions(1 , 6 , 2  ),
                new Instructions(2 , 3 , 4  ),
                new Instructions(1 , 3 , 7  ),
                new Instructions(1 , 2 , 6  ),
                new Instructions(3 , 7 , 6  ),
                new Instructions(1 , 8 , 3  ),
                new Instructions(4 , 4 , 2  ),
                new Instructions(2 , 4 , 9  ),
                new Instructions(2 , 1 , 7  ),
                new Instructions(1 , 4 , 9  ),
                new Instructions(1 , 3 , 5  ),
                new Instructions(4 , 6 , 1  ),
                new Instructions(3 , 4 , 5  ),
                new Instructions(2 , 4 , 1  ),
                new Instructions(8 , 7 , 1  ),
                new Instructions(1 , 4 , 1  ),
                new Instructions(6 , 2 , 3  ),
                new Instructions(1 , 2 , 4  ),
                new Instructions(4 , 3 , 2  ),
                new Instructions(1 , 4 , 5  ),
                new Instructions(3 , 2 , 5  ),
                new Instructions(11 , 7 , 5 ),
                new Instructions(2 , 9 , 1  ),
                new Instructions(8 , 7 , 4  ),
                new Instructions(2 , 3 , 5  ),
                new Instructions(1 , 2 , 1  ),
                new Instructions(8 , 4 , 1  ),
                new Instructions(1 , 9 , 4  ),
                new Instructions(7 , 5 , 4  ),
                new Instructions(22 , 1 , 5 ),
                new Instructions(5 , 4 , 2  ),
                new Instructions(6 , 1 , 7  ),
                new Instructions(4 , 2 , 7  ),
                new Instructions(19 , 5 , 4 ),
                new Instructions(1 , 7 , 6  ),
                new Instructions(3 , 1 , 6  ),
                new Instructions(3 , 7 , 9  ),
                new Instructions(1 , 2 , 4  ),
                new Instructions(20 , 4 , 6 ),
                new Instructions(13 , 5 , 9 ),
                new Instructions(2 , 1 , 3  ),
                new Instructions(10 , 9 , 8 ),
                new Instructions(3 , 9 , 4  ),
                new Instructions(1 , 8 , 1  ),
                new Instructions(1 , 1 , 8  ),
                new Instructions(1 , 3 , 1  ),
                new Instructions(2 , 9 , 2  )
            };
            #endregion

            #region Part 1

            //int stepCounter = 0;
            //foreach (var step in instructions)
            //{
            //    for (int i = 0; i < step.Qty; i++)
            //    {
            //        if (crates[step.Start].Count != 0)
            //        {                                        
            //        crates[step.End].Push(crates[step.Start].Pop());
            //        }
            //    }
            //    stepCounter++;
            //    Console.WriteLine(stepCounter);
            //}
            //int count = 1;
            //foreach (var stack in crates)
            //{
            //    if (stack.Count != 0)
            //    {
            //    Console.WriteLine($"{count++} {stack.Peek()}");                    
            //    }
            //    else
            //    {
            //        Console.WriteLine(count++);
            //    }
            //}

            #endregion

            #region Part 2
            /*
             *  --- Part Two ---

                As you watch the crane operator expertly rearrange the crates, you notice the process isn't following 
                your prediction.
                
                Some mud was covering the writing on the side of the crane, and you quickly wipe it away. The crane 
                isn't a CrateMover 9000 - it's a CrateMover 9001.
                
                The CrateMover 9001 is notable for many new and exciting features: air conditioning, leather seats, an 
                extra cup holder, and the ability to pick up and move multiple crates at once.
                
                Again considering the example above, the crates begin in the same configuration:
                
                    [D]    
                [N] [C]    
                [Z] [M] [P]
                 1   2   3 
                
                Moving a single crate from stack 2 to stack 1 behaves the same as before:
                
                [D]        
                [N] [C]    
                [Z] [M] [P]
                 1   2   3 
                
                However, the action of moving three crates from stack 1 to stack 3 means that those three moved crates 
                stay in the same order, resulting in this new configuration:
                
                        [D]
                        [N]
                    [C] [Z]
                    [M] [P]
                 1   2   3
                
                Next, as both crates are moved from stack 2 to stack 1, they retain their order as well:
                
                        [D]
                        [N]
                [C]     [Z]
                [M]     [P]
                 1   2   3
                
                Finally, a single crate is still moved from stack 1 to stack 2, but now it's crate C that gets moved:
                
                        [D]
                        [N]
                        [Z]
                [M] [C] [P]
                 1   2   3
                
                In this example, the CrateMover 9001 has put the crates in a totally different order: MCD.
                
                Before the rearrangement process finishes, update your simulation so that the Elves know where they 
                should stand to be ready to unload the final supplies. After the rearrangement procedure completes, 
                what crate ends up on top of each stack?

             */

            int stepCounter2 = 0;
            foreach (var step in instructions)
            {
                List<string> crateStack = new List<string>();

                for (int i = 0; i < step.Qty; i++)
                {
                    if (crates[step.Start].Count != 0)
                    {
                        crateStack.Add(crates[step.Start].Pop());
                    }
                }

                crateStack.Reverse();

                foreach (var item in crateStack)
                {
                    crates[step.End].Push(item);
                }
                stepCounter2++;
                Console.WriteLine(stepCounter2);

            }
            int count2 = 1;
            foreach (var stack in crates)
            {
                if (stack.Count != 0)
                {
                    Console.WriteLine($"{count2++} {stack.Peek()}");
                }
                else
                {
                    Console.WriteLine(count2++);
                }
            }
            #endregion
        }
    }
}
