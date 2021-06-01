using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment1_Summer2021
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1 : Enter the Moves of Robot:");   
            string moves = Console.ReadLine(); //storing the input in moves
            var p = new Program(); 
            
            bool pos = p.JudgeCircle(moves); //Calling the function
            if (pos)
            {
                Console.WriteLine("The Robot return’s to initial Position (0,0)");
            }
            else
            {
                Console.WriteLine("The Robot doesn’t return to the Initial Postion (0,0)");
            }

            Console.WriteLine();

            //Question 2:
            Console.WriteLine(" Q2 : Enter the string to check for pangram:");
            string s = Console.ReadLine(); //reading the string for input
            bool flag = p.CheckIfPangram(s); //Calling the function
            if (flag) //checking both conditions 
            {
                Console.WriteLine("Yes, the given string is a pangram");
            }
            else
            {
                Console.WriteLine("No, the given string is not a pangram");
            }
            Console.WriteLine();

            //Question 3:

            int[] arr = { 1, 2, 3, 1, 1, 3 }; // using pre-defined input 
            int gp = p.NumIdenticalPairs(arr); //Calling the function
            Console.WriteLine("Q3:");
            Console.WriteLine("The number of IdenticalPairs in the array are {0}:", gp); //displaying the output 

            //Question 4:
            int[] arr1 = { 3, 1, 4, 1, 5 }; // using pre-defined input 
            Console.WriteLine("Q4:");
            int pivot = p.PivotIndex(arr1); //Calling the function

            if (pivot > 0) //checking both conditions for pivot index
            {
                Console.WriteLine("The Pivot index for the given array is {0}", pivot);
            }
            else
            {
                Console.WriteLine("The given array has no Pivot index");
            }
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            Console.WriteLine("Enter the First Word:");
            String word1 = Console.ReadLine();
            Console.WriteLine("Enter the Second Word:");
            String word2 = Console.ReadLine();
            String merged = MergeAlternately(word1, word2);
            Console.WriteLine("The Merged Sentence fromed by both words is {0}", merged);

            //Quesiton 6:
            Console.WriteLine("Q6: Enter the sentence to convert:");
            string sentence = Console.ReadLine();
            string goatLatin = ToGoatLatin(sentence);
            Console.WriteLine("Goat Latin for the Given Sentence is {0}", goatLatin);
            Console.WriteLine();
        }

        public bool JudgeCircle(string moves)
        {
            try
            {
                int count_R = 0;
                int count_L = 0;
                int count_U = 0;
                int count_D = 0;

                for (int i = 0; i < moves.Length; i++)//counting total L,R,U,D moves
                {
                    if (moves[i] == ('L'))
                        count_L = count_L + 1;
                    if (moves[i] == 'U')
                        count_U = count_U + 1;
                    if (moves[i] == 'D')
                        count_D = count_D + 1;
                    if (moves[i] == 'R')
                        count_R = count_R + 1;
                }

                if ((count_L == count_R) && (count_U == count_D))//checking for equal L,R & U,D moves 
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            } 

        }

        public bool CheckIfPangram(string s)
        {
            try
            {
                for (char character = 'a'; character <= 'z'; character++)
                    if (!s.Contains(character))
                        return false;
                return true;
            }
            catch (Exception)
            {

                throw;
            }

        }     

        public int NumIdenticalPairs(int[] nums)
        {
            int counter = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = 0; j < nums.Length; j++)
                {
                    if ((nums[i] == nums[j]) && (i < j))
                        counter += 1;
                 }
                    
            }
            return counter;
        }

        public int PivotIndex(int[] nums) 
        {
            try
            {
                int[] right_sum = new int[nums.Length]; //storing the right sum 
                int[] left_sum = new int[nums.Length];

                for (int i = 1; i < nums.Length; i++)
                {
                    left_sum[i] = nums[i - 1] + left_sum[i - 1];
                    right_sum[nums.Length - i - 1] = nums[nums.Length - i] + right_sum[nums.Length - i];
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    if (left_sum[i] == right_sum[i])
                    {
                        return i;
                    }
                }
                return -1;

            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }
        }

        private static string MergeAlternately(string word1, string word2)
        {
            try
            {
                string newLength = "" ;
                int difference = word1.Length - word2.Length;
                int max_length = Math.Max((word1.Length), (word2.Length));

                for (int i = 0; i < (max_length - Math.Abs(difference)); i++) 
                {
                    newLength += word1[i];
                    newLength += word2[i];
                }

                if (difference < 0)
                {
                    for (int j = 0; j < (Math.Abs(difference)); j++)
                    {
                        newLength += word2[max_length - Math.Abs(difference) + j];
                           
                    }

                }
                if (difference > 0)
                {
                    for (int j = 0; j < Math.Abs(difference); j++)
                    {
                        newLength += word1[max_length - Math.Abs(difference) + j];
                    }
                }

                return newLength;
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }


        private static string ToGoatLatin(string sentence)
        {
            try
            {
                var new_string = new System.Text.StringBuilder();
                var each_word = sentence.Split();
               
                for (int j = 0; j < each_word.Length; j++)
                {
                    var w = each_word[j];
                    if (j > 0)
                    {
                        new_string.Append(' ');
                    }
                    
                    if (w[0] == 'a' || w[0] == 'e' || w[0] == 'i' || w[0] == 'o' || w[0] == 'u' ||
                        w[0] == 'A' || w[0] == 'E' || w[0] == 'I' || w[0] == 'O' || w[0] == 'U')
                    {
                        new_string.Append(w);
                    }

                    else
                    {
                        new_string.Append(w.Substring(1));
                        new_string.Append(w[0]);
                    }
                    new_string.Append("maa");
                    new_string.Append('a', j);
                }
                return new_string.ToString();
            }
            catch (Exception)
            {

                throw;
            }
        }



    }
}


            
                
    
