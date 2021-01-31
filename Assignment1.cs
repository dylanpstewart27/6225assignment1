using System;
using System.Collections.Generic;
using System.Linq;


namespace Assignment1_Spring2021
{
    class Program
    {
        private static void Main(string[] args)
        {

            //Question 1
            Console.WriteLine("Q1 : Enter the number of rows for the traingle:");
            int n = Convert.ToInt32(Console.ReadLine());
            printTriangle(n);
            Console.WriteLine();

            //Question 2:
            Console.WriteLine("Q2 : Enter the number of terms in the Pell Series:");
            int n2 = Convert.ToInt32(Console.ReadLine());
            printPellSeries(n2);
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Q3 : Enter the number to check if squareSums exist:");
            int n3 = Convert.ToInt32(Console.ReadLine());
            bool flag = squareSums(n3);
            if (flag)
            {
                Console.WriteLine("Yes, the number can be expressed as a sum of squares of 2 integers");
            }
            else
            {
                Console.WriteLine("No, the number cannot be expressed as a sum of squares of 2 integers");
            }

            //Question 4:
            int[] arr = { 3, 1, 4, 1, 5 };
            Console.WriteLine("Q4: Enter the absolute difference to check");
            int k = Convert.ToInt32(Console.ReadLine());
            int n4 = diffPairs(arr, k);
            Console.WriteLine("There exists {0} pairs with the given difference", n4);

            //Question 5:
            List<string> emails = new List<string>();
            emails.Add("dis.email + bull@usf.com");
            emails.Add("dis.e.mail+bob.cathy@usf.com");
            emails.Add("disemail+david@us.f.com");
            int ans5 = UniqueEmails(emails);
            Console.WriteLine("Q5");
            Console.WriteLine("The number of unique emails is " + ans5);

            //Quesiton 6:
            string[,] paths = new string[,] { { "London", "New York" }, { "New York", "Tampa" },
                                        { "Delhi", "London" } };
            string destination = DestCity(paths);
            Console.WriteLine("Q6");
            Console.WriteLine("Destination city is " + destination);

        }

        /// <summary>
        ///Print a pattern with n rows given n as input
        ///n – number of rows for the pattern, integer (int)
        ///This method prints a triangle pattern.
        ///For example n = 5 will display the output as: 
        ///     *
        ///    ***
        ///   *****
        ///   *******
        ///  *********
        ///returns      : N/A
        ///return type  : void
        /// </summary>
        /// <param name="n"></param>
        private static void printTriangle(int n)
        {
            try
            {
                int y;
                int z;
                int count = n -1;
                
                for (z = 1; z <= n; z++)
                {
                    //Figures out how many blank spaces should be put in each row to organize the pyramid. 
                    for (y = 1; y <= count; y++)
                        Console.Write(" ");
                    count--;
                    //Puts the correct amount of asterisks in each row 
                    for (y = 1; y <= 2 * z - 1; y++)
                        Console.Write("*");
                    Console.WriteLine();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

      
        private static void printPellSeries(int n2)
        {
            try
            {
                int a = 1, b = 0, c;
                c = 0;
                Console.WriteLine("");
                Console.WriteLine("0");
                //loop to calculate the amount of numbers specified by the input 
                for (int i = 1; i < n2; i++)
                {
                    //The formula is two times the previous number plus the number before that one 
                    c = a + 2 * b;

                    Console.WriteLine(c);
                    //This changes the variables used to calculate each subsequent number 
                    a = b;
                    b = c;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }


        /// <summary>
        ///Given a non-negative integer c, decide whether there're two integers a and b such that a^2 + b^2 = c.
        ///For example:
        ///Input: C = 5 will return the output: true (1*1 + 2*2 = 5)
        ///Input: A = 3 will return the output : false
        ///Input: A = 4 will return the output: true
        ///Input: A = 1 will return the output : true
        ///Note: You cannot use inbuilt Math Class functions.
        /// </summary>
        /// <param name="n3"></param>
        /// <returns>True or False</returns>


        private static bool squareSums(int n3)

        {
            try
            {
                for (int x = 1; x * x <= n3; x++)
                    for (int y = 1; y * y <= n3; y++)
                        if (x * x + y * y == n3)
                        {
                            return true;
                        }
                return false;
            
            }
            catch (Exception)
            {

                throw;
            }
        }

       
        private static int diffPairs(int[] nums, int k)
        {
            try
            {
                //Sorts the array descending
                Array.Sort(nums);
                int pair = 0;
                //Loops through each element of the array
                for (int x = 0; x < nums.Length; x++)
                {
                    //Since the array is sorted, skips duplicated
                    if (x > 0 && nums[x - 1] == nums[x])
                    {
                        continue;
                    }
                    //since the list is in descending order 
                    //A number - the next number will result
                    //In the difference being checked again, k
                    for (int y = x + 1; y < nums.Length; y++)
                        if (Math.Abs(nums[x] - nums[y]) == k)
                            pair++;
                }
                return pair;
            
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /// <summary>
        /// An Email has two parts, local name and domain name. 
        /// Eg: rocky @usf.edu – local name : rocky, domain name : usf.edu
        /// Besides lowercase letters, these emails may contain '.'s or '+'s.
        /// If you add periods ('.') between some characters in the local name part of an email address, mail sent there will be forwarded to the same address without dots in the local name.
        /// For example, "bulls.z@usf.com" and "bullsz@leetcode.com" forward to the same email address.  (Note that this rule does not apply for domain names.)
        /// If you add a plus('+') in the local name, everything after the first plus sign will be ignored.This allows certain emails to be filtered, for example ro.cky+bulls @usf.com will be forwarded to rocky@email.com.  (Again, this rule does not apply for domain names.)
        /// It is possible to use both of these rules at the same time.
        /// Given a list of emails, we send one email to each address in the list.Return, how many different addresses actually receive mails?
        /// Eg:
        /// Input: ["dis.email+bull@usf.com","dis.e.mail+bob.cathy@usf.com","disemail+david@us.f.com"]
        /// Output: 2
        /// Explanation: "disemail@usf.com" and "disemail@us.f.com" actually receive mails
        /// </summary>
        /// <param name="emails"></param>
        /// <returns>The number of unique emails in the given list</returns>

        private static int UniqueEmails(List<string> emails)
        {
            try
            {
                string local = "";
                string domain = "";
                string editedEmails = "";
                //Converting the List to a more manageable structure
                string[] emailArray = emails.ToArray();

                //Loop to iterate through each entry in the array/list
                for (int i = 0; i < emailArray.Length; i++)
                {
                    //Split the email so as to isolate the domains and local halves 
                    string[] emailSplit = emails[i].Split('@');
                    local = emailSplit[0];
                    domain = emailSplit[1];
                    //Replace the dots in the local half as they can be ignored
                    if (local.Contains("."))
                    {
                        local = local.Replace(".", "");
                    }
                    //Isolate the "+" and then remove the characters after it as they can be ignored
                    int plusLocation = local.IndexOf("+");
                    local = local.Substring(0, plusLocation).Trim();

                    //Skips over an email if its edited components already exist in the array
                    if (editedEmails.Contains(local + "@" + domain))
                    {
                        continue;
                    }
                    editedEmails += local + "@" + domain + " ";
                }
                //re attaches the email components and counts the unique emails
                editedEmails = editedEmails.Substring(0, editedEmails.Length - 1);
                return editedEmails.Split(" ").Count();

                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        /// <summary>
        /// You are given the array paths, where paths[i] = [cityAi, cityBi] means there exists a direct path going from cityAi to cityBi. Return the destination city, that is, the city without any path outgoing to another city.
        /// It is guaranteed that the graph of paths forms a line without any loop, therefore, there will be exactly one destination city.
        /// Example 1:
        /// Input: paths = [["London", "New York"], ["New York","Tampa"], ["Delhi","London"]]
        /// Output: "Tampa" 
        /// Explanation: Starting at "Delhi" city you will reach "Tampa" city which is the destination city.Your trip consist of: "Delhi" -> "London" -> "New York" -> "Tampa".
        /// Input: paths = [["B","C"],["D","B"],["C","A"]]
        /// Output: "A"
        /// Explanation: All possible trips are: 
        /// "D" -> "B" -> "C" -> "A". 
        /// "B" -> "C" -> "A". 
        /// "C" -> "A". 
        /// "A". 
        /// Clearly the destination city is "A".
        /// </summary>
        /// <param name="paths"></param>
        /// <returns>The destination city string</returns>
        private static string DestCity(string[,] paths)
        {
            try
            {
                
                List<string> endCity = new List<string>();
                List<string> startCity = new List<string>();

                //Convert the multidimensional array into 2 more manageable lists
                for (int i = 0; i < paths.Length / 2; i++)
                {
                    endCity.Add(paths[i, 1]);
                }

                for (int i = 0; i < paths.Length / 2; i++)
                {
                    startCity.Add(paths[i, 0]);
                }



                


                string end= "";
                //The end city logically must exist in the [1] indeix of the array
                //thus since the [0] and [1] are split into two lists
                //The end city must exist only in the list containing the elements
                //of the [1] index, and must only be in that list
                //Since the cities do not loop
                var result = endCity.Except(startCity);
                foreach (var element in result)
                {
                     end =element.ToString();
                }
                return end;


            }
            catch (Exception)
            {

                throw;
            }


        }


    }
}

