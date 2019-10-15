        using System; // It allows you to type the method names of members of the System namespace without typing the word System every time.
        using System.Data; // The System.Data namespace provides access to classes that represent the ADO.NET architecture. ADO.NET lets you build components that efficiently manage data from multiple data sources.

        namespace equationSolver //specifies the namespace for a class which is equationSolver and will be same as the name of a file.
        {


        class Check
        {
            public bool CheckRight(string right)  // Boolean method which checks the right side of an equation has a valid range of a numbers.
            {
                bool flag = true; // setting a boolean flag to true.

                for (int i = 0; i < right.Length; i++) //using a for loop until the length of a right is greater than i.
                {
                    if (Char.IsDigit(right[i])) //checks if the right[i] is digit or not. 
                    {
                        int a = Convert.ToInt32(right[i]); // If the condition match, then convert the number to a integer.
                        if (a > int.MaxValue) //checks whether the number is greater than the maximum value.
                        {
                            Console.WriteLine("The number should be smaller than the maximum value."); //if the number is greater than maximum value then error message is thrown. 
                            flag = false; //change flag to false. 
                        }
                    }
                }
                return flag; //flag is returned. 
            }

            public bool CheckLeft(string left) // Boolean method which checks the left side of an equation has a valid range of a numbers.
            {
                bool flag = true; // setting a boolean flag to true.

                for (int i = 0; i < left.Length; i++) //using a for loop until the length of a left is greater than i.
                {
                    if (Char.IsDigit(left[i])) //checks if the left[i] is digit or not. 
                    {
                        int a = Convert.ToInt32(left[i]); // If the condition match, then convert the number to a integer.
                        if (a > int.MaxValue) //checks whether the number is greater than the maximum value.
                        {
                            Console.WriteLine("The number should be smaller than the maximum value."); //if the number is greater than maximum value then error message is thrown. 
                            flag = false; //change flag to false. 
                        }
                    }
                }
                return flag; //flag is returned. 
            }


        }

            class equation // specifies the name of a class called program. 
            {
                static void Main(string[] args) // Main argument of a class.
                {
                    Check checker = new Check(); //creates the object of a class Check. 

                    // if 1st argument is calc
                    if (args[0].Equals("equation"))
                    {
                        bool isTrue = false;    //Seting a flag.
                        int count = 0;
                        // to find either it is equation
                        foreach (string word in args)   //foreach loop where all the arguments of args are stored in word.
                        {
                            if (word.Equals("="))//if the equation has "=" sign then the count of value will be increased by 1.
                            {
                                count++;    //if the equation has "=" sign, increase the count by 1.
                            }
                        }
                        if (count == 1) //when the value of a count is equal to zero.
                        {
                            isTrue = true;     // if the value of a count is "1" then set the flag value to true where it was false.
                        }
                        // display message if input is invalid
                        if (!isTrue) //if the condition is opposite of a isTrue.
                        {
                            Console.WriteLine("Please have a valid linear equation. The valid equation looks like 2x+3=5 ");  // the error message is displayed when the entered equation is not valid.
                        }
                        else
                        {
                            double value_x = 0; //creating a double value type.
                            string equation = "";   //creating a string vlaue type. 
                            string left, right; //creating a string value type.
                            for (int i = 1; i < args.Length; i++)       //using for loop because for loop is faster and reads the data faster than foreach loop.
                            {
                                equation += args[i] + ""; //adding the equation with the empty string and the argument length.
                            }
                    Console.WriteLine("equation {0}",equation); //prints the equation to the console.
                            string[] word = equation.Split('='); //Splitting the code after "=" sign and place left hand side equation to left and right hand side code to right.
                            left = word[0]; //putting the first equation into left.
                            right = word[1];    // putting second equation into right.
                            if (left.Trim().EndsWith("+++++++++++++")) //Trimming the left equation which has "+" sign.
                            {
                        left +="0";    //adding the left equation with 0.
                            }
                            

                            if (right.Trim().EndsWith("+++++++++")) //Trimming the right equation which has "+" sign.
                            {
                                right += "0"; // adding the left equation with 0.
                            }


                            double value = -10;     //creating a double value type and defining its vlaue to -10 so that the equation can be iterated for certain amount of time and the equation can be solved.
                            bool square = false;    // creating a flag and initalizing it's vlaue to false.
                            bool err = false;       // creating a flag and initalizing it's value to false.
                            DataTable dtable = new DataTable(); // Creating a new DataTable object.
                            // if both sides are valid then perform calculation
                            if (checker.CheckLeft(left) && checker.CheckRight(right))   //checks weather the left equation and right equation are valid or not.
                            {
                                while (value <= int.MaxValue)   //Performing a while loop untill the vlaue is less than or equal to the maxValue. The value of MaxValue is the maximum value and is automatically identified by the computer. 
                                {
                                    string l = "", r = ""; //initalizing strings l and r to empty string.
                                    for (int i = 0; i < left.Length; i++)      // Using for loop until the length of a left is less than the vlaue of i.
                                    {
                                        if (left[i] == 'X' || left[i] == 'x')   // Checking weather the left hand has "X" or "x".
                                        {
                                            if (i - 1 >= 0) // If the above condition matches then again matches when "(i-1) is greater or equal to 0".
                                            {
                                                if (Char.IsDigit(left[i - 1]))  //if matches then check weather the left[i-1] is digit or not.
                                                {
                                                    l += "*" + value;   // if so then increase the value of l.
                                                }
                                                else
                                                {
                                                    l += value; //otherwise increase the vlaue of l by adding l to the vlaue. 
                                                }
                                            }
                                            else //if the condition "i-1" is less than 0 then add the vlaue of l to l + value.
                                            {
                                                l += value;
                                            }

                                            if (left[i + 1] == '^') // if the certain position of left is equal to "^".
                                            {
                                                l += "*" + value;   // if above condition matches then add the l.
                                                i = i + 2;
                                                square = true;  // when above conditions is true then change the flag value of square to true. 
                                            }
                                        }
                                        else  // if the left equation does not have the character "X" or "x" then do the below command.
                                        {
                                            l += left[i];   // add l. 
                                        }
                                    }

                                    for (int i = 0; i < right.Length; i++) // using for loop until the length of a right equation is greater than i.
                                    {
                                        if (right[i] == 'X' || right[i] == 'x') //checks whether the right side of equation has the character of "X" or "x".
                                        {
                                            if (i - 1 >= 0) // checks if the vlaue of "i-1" is greater than or equal to 0.
                                            {
                                                if (Char.IsDigit(right[i - 1])) //if the position of "right[i-1]" is digit or not.
                                                {
                                                    r += "*" + value;   // if the condition matches then add the value of r.
                                                }
                                                else
                                                {
                                                    r += value; //if the conditions fails then add the value of r with r and value.
                                                }
                                            }
                                            else // if "i-1" is less than 0 then do the following case.
                                            {
                                                r += value; // add the value of r to r and the vlaue. 
                                            }

                                            if (right[i + 1] == '^') //checks whether right[i=1] is equals to "^"
                                            {
                                                r += "*" + value;   // add the value of r.
                                                i = i + 2;
                                                square = true;  //change flag value to true.
                                            }
                                        }
                                        else // if right side does not contain "X" or ""x then do the below case.
                                        {
                                            r += right[i];  // add the value of r to the right. 
                                        }
                                    }

                                    double v1 = 0, v2 = 0;  // declaring double value v1 and v2.
                                    try  // implementing try and catch statement. 
                                    {
                                        v1 = Convert.ToDouble(dtable.Compute(l, ""));
                                        v2 = Convert.ToDouble(dtable.Compute(r, ""));
                                    }
                                    catch (OverflowException) // if the vlaue of a integer is larger than maximum value then do the following case.
                                    {
                                        Console.WriteLine("Out of Integer Range"); //printing the "out of integer range" so that the vlaue is greater than maximum range of a value.
                                        err = true; //change a flag to true.
                                        break; // break the loop. 
                                    }
                                    v1 = Math.Round(v1, 1); //rounds a vlaue to the nearest integer and putting into v1.
                                    v2 = Math.Round(v2, 1); //rounds a vlaue to the nearest integer and putting into v2.
                                    if (Double.IsInfinity(v2) || Double.IsInfinity(v1)) //checks whether the v2 or v1 is infinity. Because any number equals to zero cannot be divided which results error. 
                                    {
                                        Console.WriteLine("This number cannot be divisibile by zero. Please have a number greater than zero."); // Printing the message that the number is not divisible by zero.
                                        err = true; //change flag to true.
                                        break; // break the loop. 
                                    }
                                    if (v1.Equals(v2)) //checks whether v1 is equal to v1.
                                    {
                                        value_x = value; // the answers is put into the value_x.
                                        break; //break the loop.
                                    }
                                    value = Math.Round(value + 0.1, 1); //Computes the answer by using the Round function. 
                                }
                            }

                            if (square && !err) //checks the value of square is false and err is true.
                            {
                        Console.WriteLine("X = " + value_x + ", " + (-1 * value_x)); //printing the final answer on the console.
                            }
                            else if (!err) //checks whether the value of err is just opposite.
                            {
                        Console.WriteLine("X = " + value_x); //printing the final answer to the console.
                            }

                            Console.WriteLine(); //Prints the line. 
                        }
                        Console.ReadKey(); //Waits for the user to press any key and the session terminates.
                    }
                }


            }
        }