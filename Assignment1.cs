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
            //This was a very simple question that I had completed in an online course I took myself so I was able to reuse the code. 
            //Took me about 15 minutes for me to refind my work and make sure it was correct, a simple but effective question as 
            //printing the blank spaces is a strange thing to think of.
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
            //I really enjoyed this question, using algorithmic thinking to work through number series like this and fibonnac
            //is interesting because you will know immediately if it works. A somewhat but not very challenging question
            //but good warmup to programming, estimated time 30 minutes to complete.
        }


       


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

        //This question did not take me very long, maybe 1.5 hours but mostly because I was overcomplicating the logic
        //I think mathematic based questions like this are very good because they require analytical thinking and are 
        //not too complicated once you figure out the logic of what it should require.

       
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

        //This question gave me lots of trouble, I had to do several hours of googling and looking at online resources to figure it out
        //This was a question that googling more information about arrays prooved to be a good resource, as it reminded me about sorting the array
        //Once the array was sorted it made much more logical sense to me. Lots of trial and error to solve this, especially without the use of Hash Sets as
        // those would have made this very simple as you would not have to deal with duplicates . 

        
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
        //This question took me the longest out of all of them, about half of a day. The main problem was that I knew what steps I would need to take 
        //but I was unable to write code to make it work until I did more searching through stack overflow and various help pages to try and figure out what 
        //methods I could call to do things such as .Replace. Googling about Lists made it very helpful as it showed what I could do with lists and whether it would
        //be easier to work with the lists or turn it into arrays. Very solid question that tested my knowledge and ability to retrieve the proper knowledge.

        
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

            //This question I was stuck on for 4 hours or so with little to no progress about how I should attack it without the use of a dictionary. 
            //A key factor was realising that there was a comma in the array notation and having to lookup what that meant as I had never seen that before
            //Once I learned it was a multidimensional array it made it very easy to understand conceptually. Learning about the .Except method on 
            //Microsofts website made the problem a breeze, but I really liked how the problem used the multidimensional array and my experience on
            //searcing for information for the previous problems made this problem a breeze.
        }


    }
}

