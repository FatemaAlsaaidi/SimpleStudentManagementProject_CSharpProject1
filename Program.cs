using System.Net;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SimpleStudentManagementProject_CSharpProject1
{
    internal class Program
    {   // Declare all arries and variables needed ....
        static int MaxStudents = 4;
        static double[] Marks = new double[MaxStudents];
        static int[] Ages = new int[MaxStudents];
        static string[] Names = new string[MaxStudents];
        static DateTime[] Dates = new DateTime[MaxStudents];
        static int StudentCounter = 0;
        static double Mark;
        static int Age;
        static string Name;
        static DateTime Date;
        static int triesEnterCorrectValue =0;
        
        //-------- main method
        static void Main(string[] args)
        {
            int choiceNum;
            while (true)
            {
                
                try
                {
                    //Mnue of Tasks
                    Console.Clear();
                    Console.WriteLine("Simple Students Management");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. View All Students");
                    Console.WriteLine("3. Find Student");
                    Console.WriteLine("4. Class Average");
                    Console.WriteLine("5. Top-Performing Student");
                    Console.WriteLine("6. Sort Students By Marks");
                    Console.WriteLine("7. Delete A Student Record");
                    Console.WriteLine("0. Exit ");
                    Console.Write("Enter The Number Of Feature: ");
                    choiceNum = int.Parse(Console.ReadLine());

                    // Tasks Functons
                    switch (choiceNum)
                    {
                        case 1: AddNewStudentRecord(); break;
                        case 2: ViewingAllStudents(); break;
                        case 3: FindStudent(); break;
                        case 4: ClassAverage(); break;
                        case 5: TopPerformingStudent(); break;
                        case 6: SortingStudents(); break;
                        case 7: DeleteStudentRecord(); break;
                        case 0: return;
                        default: Console.WriteLine("Invalid choice! Try again."); break;
                    }
                    Console.ReadLine();
                }
                catch (Exception e)
                {
                    // Display error message to user
                    Console.WriteLine($"Error: {e.Message}");
                    Console.WriteLine("Press enter to continue...");
                    Console.ReadKey();  // Wait for user input before clearing the screen
                        
                }
            }
        }
        //--------1. Adding a New Student
        static void AddNewStudentRecord()
        {
            //---------------------------------------------------------------------------------------------
            //// Variable to store user choice for adding more students
            char ChoiceChar = 'y';
            bool AddMore = true; // Flag to control loop execution
            // // Loop runs as long as user wants to add students and max limit is not reached
            while (AddMore && StudentCounter < MaxStudents)
            {
                triesEnterCorrectValue = 0; // Reset try counter for validation attempts
                bool IsSave = true; // Flag to determine if student record is valid for saving


                //-----------------------------------------------------------------Name

                bool FlagName = true; // Controls the loop for name input validation
                do
                {

                    try
                    {
                        // to get the name from user
                        Console.WriteLine($"Enter the name of student {StudentCounter + 1}:");
                        // save input name in the name varible
                        Name = Console.ReadLine();
                        triesEnterCorrectValue++;
                        // If user exceeds max attempts, stop input and prevent saving
                        if (triesEnterCorrectValue >= 5)
                        {
                            Console.WriteLine("You exceeded tries limited");
                            IsSave = false;
                            FlagName = false; //// Exit loop after 5 invalid attempts
                            break;
                        }

                        //Check if the name contains special characters , use .IsMatch to Indicates whether the specified regular expression finds a match in the specified input string
                        if (!Regex.IsMatch(Name, @"^[a-zA-Z\s]+$"))
                        {
                            Console.WriteLine("Invalid name! Special characters and numbers are not allowed.");
                        }

                        // If the name is empty or just spaces, also throw an error, use function to check whether the specified string is null or contains only white-space characters
                        if (string.IsNullOrWhiteSpace(Name))
                        {
                            Console.WriteLine("Name cannot be empty or spaces only.");
                        }

                        else
                        {
                            FlagName = false; // Set to false once valid input is entered , exit loop
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                        Console.WriteLine("Press enter to continue...");
                    }

                } while (FlagName);
                Console.WriteLine("Name Entered Successfully!");


                //-----------------------------------------------------------------Mark

                bool FlagMark = true;  // Controls the loop for mark input validation
                do
                {
                    try
                    {
                        Console.WriteLine($"Enter the Mark of student {StudentCounter + 1} (0-100): ");
                        Mark = double.Parse(Console.ReadLine());
                        triesEnterCorrectValue++;
                        if (triesEnterCorrectValue >= 5)
                        {
                            Console.WriteLine("You exceeded tries limited");
                            IsSave = false;
                            FlagMark = false;
                            break;
                        }

                        // Validate mark range (should be between 0 and 100)
                        if (Mark < 0 || Mark > 100)
                        {
                            Console.WriteLine("Incorrect Mark format or it not in rang (0-100), please try again.");

                        }
                        else
                        {
                            FlagMark = false;
                        }


                    }
                    catch (Exception e) 
                    {
                        Console.WriteLine($"Error: {e.Message}");
                        Console.WriteLine("Press enter to continue...");
                    }
                } while (FlagMark);

                if (triesEnterCorrectValue >= 5)
                {
                    //Console.WriteLine("You exceeded tries limited");
                    IsSave = false; 
                    break;
                }

                Console.WriteLine("Mark Entered Successfully!");



                //-----------------------------------------------------------------Age
             
                bool FlagAge = true; // Controls the loop for age input validation
                do
                {
                    try
                    {
                        Console.WriteLine($"Enter the age of student {StudentCounter + 1}: (must be > 21): ");
                        Age = int.Parse(Console.ReadLine());
                        triesEnterCorrectValue++;
                        if (triesEnterCorrectValue >= 5)
                        {
                            Console.WriteLine("You exceeded tries limited");
                            IsSave = false;
                            FlagAge = false;
                            break;
                        }
                        // Validate age (must be greater than 21)
                        if (Age <= 21)
                        {
                            Console.WriteLine("Invalid Age Number format ot it less than 21, please try again.");
                            IsSave = false;
                        }
                        else
                        {
                            FlagAge = false;
                        }
                       
                    }
                    catch (Exception e)
                    { 
                        Console.WriteLine($"Error: {e.Message}");
                        Console.WriteLine("Press enter to continue...");
                    }
                } while (FlagAge);

                if (!IsSave) 
                {
                    Console.WriteLine("Age Did not Entered Successfully!"); 
                }
                else
                {
                    Console.WriteLine("Age Entered Successfully!");
                }

                if (triesEnterCorrectValue > 5)
                {
                    //Console.WriteLine("You exceeded tries limited");
                    IsSave = false;
                    break;
                }

                //-----------------------------------------------------------------------------------Date
                
                Date = DateTime.Now;

                //------------------------------------------------------------------------------Saved
                if (!IsSave)
                {
                    Console.WriteLine("Student did not save");
                    break;
                        
                }
                else
                {
                    Names[StudentCounter] = Name;
                    Ages[StudentCounter] = Age;
                    Marks[StudentCounter] = Mark;
                    Dates[StudentCounter] = Date;
                    Console.WriteLine("Student Add Successfully");
                    StudentCounter ++;
                }
                
                //--------------------------------------------------------------------------------------check if number of student is over
                if (StudentCounter > 4)
                {
                    Console.WriteLine("Cannot add more students. Maximum limit reached.");
                    break;
                }

                //-----------------------------------------------------------------ask user if want add more student and then check if it there is ability to add or not 
                Console.WriteLine("Do you want add another student information ? y / n");
                ChoiceChar = Console.ReadKey().KeyChar;
                Console.ReadKey();
                Console.WriteLine();
                if (ChoiceChar != 'y' && ChoiceChar != 'Y')
                {
                    AddMore = false; // Stops adding students

                }
                else
                {
                    if (StudentCounter >= MaxStudents)
                    {
                        Console.WriteLine("You chose to add another student, but the maximum limit has been reached.");
                        AddMore = false; // Stops adding students
                    }
                }

            }

        }
        //--------2.Viewing All Students
        static void ViewingAllStudents()
        {
            // Check if there are no students in the list
            if (StudentCounter == 0)
            {
                Console.WriteLine("No students available.");
                return; // Exit the function early
            }
            // Loop through all stored students and display their information
            for (int i = 0; i < StudentCounter; i++)
            {
                Console.WriteLine($"Student {i + 1}:");
                Console.WriteLine($"Name: {Names[i]}");
                Console.WriteLine($"Mark: {Marks[i]}");
                Console.WriteLine($"Age: {Ages[i]}");
                Console.WriteLine($"Date of Enrollment: {Dates[i]:yyyy-MM-dd HH:mm:ss}\n");
            }
        }
        //--------3. Searching for a Student by Name
        static void FindStudent()
        {
            Console.WriteLine("Enter the neme of student: ");
            string SearchName= Console.ReadLine().ToLower(); // Store the input name and convert it to lowercase for case insensitive comparison
            // Loop through the list of students to search for the entered name
            for (int i = 0; i < StudentCounter; i++) 
            {
                // Compare the current student's name (converted to lowercase) with the search query
                if (Names[i].ToLower() == SearchName)
                {
                    // If a match is found, display the student's details
                    Console.WriteLine($"Mark: {Marks[i]}");
                    Console.WriteLine($"Age: {Ages[i]}");
                    Console.WriteLine($"Date of Enrollment: {Dates[i]:yyyy-MM-dd HH:mm:ss}\n");
                    // Exit the function after finding the student, thus no need to check further if there more. 
                    return;
                }    
            }
            // If the loop completes without finding a match
            Console.WriteLine("Student not found.");
        }
        //--------4. Calculating the Class Average
        static void ClassAverage()
        {
            double sum = 0;
            for (int i = 0; i < StudentCounter; i++)
            {
                sum = sum + Marks[i];
            }

            double avg = sum / StudentCounter;
            Console.WriteLine($"The Class Average is : {Math.Round(avg,2)}");
        }
        //--------5. Find the top-performing student 
        static void TopPerformingStudent()
        {
            // Variable to store the index of the top-performing student
            int IndexTopPerformance = 0;
            // Variable to store the highest mark found
            double MaxMark = 0;
            // // Loop through all students to find the highest mark
            for (int i = 0; i < StudentCounter; i++)
            {
                // If the current student's mark is higher than the stored MaxMark, update  the value of MaxMark
                if (Marks[i] > MaxMark)
                {
                    IndexTopPerformance = i; // Store the index of the top-performing student
                    MaxMark = Marks[i]; // Update the highest mark found

                }
            }

            Console.WriteLine($"Top Student: {Names[IndexTopPerformance]}, Marks: {Marks[IndexTopPerformance]}, Age: {Ages[IndexTopPerformance]}");
        }
        //-------6. Sorting Students by Marks (Descending Order)
        static void SortingStudents()
        {
            //declare temporary variables to hold student data during swapping
            double HoldMark;
            string HoldName;
            int HoldAge;
            DateTime HoldDate;

            Console.WriteLine("Students sorted by marks in descending order.");
            // Outer loop to iterate through each student
            for (int i = 0; i < StudentCounter; i++)
            {
                //// Inner loop to compare the current student with the remaining students
                for (int j = i+1; j < StudentCounter; j++)
                {
                    //// If the current student's mark is lower than the next student's mark, swap them
                    if (Marks[i] < Marks[j])
                    {
                        // Swap marks
                        HoldMark = Marks[i];
                        Marks[i] = Marks[j];
                        Marks[j] = HoldMark;
                        // Swap names
                        HoldName = Names[i];
                        Names[i] = Names[j];
                        Names[j] = HoldName;
                        // Swap ages
                        HoldAge = Ages[i];
                        Ages[i] = Ages[j];
                        Ages[j] = HoldAge;
                        // Swap dates
                        HoldDate = Dates[i];
                        Dates[i] = Dates[j];
                        Dates[j] = HoldDate;
                        
                    }
                }
            }
            // Loop to display the sorted student list
            for (int i = 0;i < StudentCounter; i++)
            {
                Console.WriteLine($"Name: {Names[i]}");
                Console.WriteLine($"Mark: {Marks[i]}");
                Console.WriteLine($"Age: {Ages[i]}");
                Console.WriteLine($"Date of Enrollment: {Dates[i]:yyyy-MM-dd HH:mm:ss}\n");
            }


        }
        //-------7.  Deleting a Student
        static void DeleteStudentRecord()
        {
            char ChoiceChar;
            bool DeleteMore = true; // Allows deleting multiple students in one session

            while (DeleteMore)
            {
                bool FoundFlag = false; // Assume student is not found initially
                int IndexName = 0; // Variable to store index of student to delete
                int triesEnterCorrectValue = 0; // Track the number of attempts for valid input
                string DeleteName = "";

                // Input validation loop (allows max 5 attempts)
                do
                {
                    try
                    {
                        Console.WriteLine("Enter the name of the student you want to delete:");
                        DeleteName = Console.ReadLine()?.Trim();

                        triesEnterCorrectValue++;

                        // Check if user exceeded max tries
                        if (triesEnterCorrectValue >= 5)
                        {
                            Console.WriteLine("You exceeded the maximum number of attempts.");
                            return; // Stop the function
                        }

                        // Validate name (only letters and spaces allowed)
                        if (!Regex.IsMatch(DeleteName, @"^[a-zA-Z\s]+$"))
                        {
                            Console.WriteLine("Invalid name! Special characters and numbers are not allowed.");
                        }
                        else if (string.IsNullOrWhiteSpace(DeleteName))
                        {
                            Console.WriteLine("Name cannot be empty or contain only spaces.");
                        }
                        else
                        {
                            break; // Exit the loop if input is valid
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine($"Error: {e.Message}");
                        Console.WriteLine("Press Enter to try again...");
                        Console.ReadLine();
                    }
                } while (true); // Continue until a valid name is entered

                DeleteName = DeleteName.ToLower(); // Convert input to lowercase for case-insensitive comparison

                // Search for the student by name
                for (int i = 0; i < StudentCounter; i++)
                {
                    if (Names[i].ToLower() == DeleteName)
                    {
                        IndexName = i; // Store the index of the student to delete
                        FoundFlag = true;
                        break; // Stop searching after finding the student
                    }
                }

                if (FoundFlag)
                {
                    // Confirm deletion
                    Console.WriteLine($"Are you sure you want to delete {Names[IndexName]}? (y/n)");
                    char confirm = Console.ReadKey().KeyChar;
                    Console.WriteLine(); // Move to the next line

                    if (confirm == 'y' || confirm == 'Y')
                    {
                        // Shift all elements to the left to remove the student
                        for (int j = IndexName; j < StudentCounter - 1; j++)
                        {
                            Names[j] = Names[j + 1];
                            Marks[j] = Marks[j + 1];
                            Ages[j] = Ages[j + 1];
                            Dates[j] = Dates[j + 1];
                        }

                        StudentCounter--; // Reduce the total student count
                        Console.WriteLine("Student record deleted successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Deletion canceled.");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found.");
                }

                // Ask if the user wants to delete another student
                Console.WriteLine("Do you want to delete another student? (y/n)");
                ChoiceChar = Console.ReadKey().KeyChar;
                Console.WriteLine(); // Move to the next line

                if (ChoiceChar != 'y' && ChoiceChar != 'Y')
                {
                    DeleteMore = false; // Stop deleting students
                }

                // Check if there are still students left to delete
                if (StudentCounter == 0)
                {
                    Console.WriteLine("No more students left to delete.");
                    break;
                }
            }
        }



    }

    
}
