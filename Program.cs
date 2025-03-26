using System.Net;
using System.Security.Claims;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace SimpleStudentManagementProject_CSharpProject1
{
    internal class Program
    {
        static double[] Marks = new double[4];
        static int[] Ages = new int[4];
        static string[] Names = new string[4];
        static DateTime[] Dates = new DateTime[4];
        static int StudentCounter = 0;
        static double Mark;
        static int Age;
        static string Name;
        static DateTime Date;
        static int triesEnterCorrectValue =0;

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

        static void AddNewStudentRecord()
        {
            // Iniationlize the ChoiceChar variable to ask user if want add more stunent information
            //char ChoiceChar ='y';
            //while (StudentCounter < 4)
            //{
            //    //-----------------------------------------------------------------Name

            //    bool FlagName = true;
            //    do
            //    {
            //        try
            //        {
            //            Console.WriteLine($"Enter the name of student {StudentCounter + 1}:");
            //            Name = Console.ReadLine();

            //            // Check if the name contains special characters
            //            if (!Regex.IsMatch(Name, @"^[a-zA-Z\s]+$"))
            //            {
            //                Console.WriteLine("Invalid name! Special characters and numbers are not allowed.");
            //            }

            //            // If the name is empty or just spaces, also throw an error
            //            if (string.IsNullOrWhiteSpace(Name))
            //            {
            //                Console.WriteLine("Name cannot be empty or spaces only.");
            //            }

            //            else
            //            {
            //                FlagName = false;
            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            // Display error message to user
            //            Console.WriteLine($"Error: {e.Message}");
            //            Console.WriteLine("Press enter to continue...");
            //            Console.ReadKey();  // Wait for user input before clearing the screen
            //        }
            //    } while (FlagName);
            //    Names[StudentCounter] = Name;


            //    //--------------------------------------------------------------------------Mark

            //    bool FlagMark = true;

            //    do
            //    {
            //        try
            //        {
            //            Console.WriteLine($"Enter the Mark of student {StudentCounter + 1} (0-100): ");
            //            Mark = double.Parse(Console.ReadLine());

            //            if (Mark < 0 || Mark > 100)
            //            {
            //                Console.WriteLine("Incorrect Mark format or it not in rang (0-100), please try again.");

            //            }
            //            else
            //            {
            //                FlagMark = false;
            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            Console.WriteLine($"Error: {e.Message}");
            //            Console.WriteLine("Press enter to continue...");
            //        }
            //    }
            //    while (FlagMark);
            //    Console.WriteLine("Mark Entered Successfully!");
            //    Marks[StudentCounter] = Mark;

            //    //------------------------------------------------------------------------------Age
            //    bool FlagAge = true;
            //    do
            //    {
            //        try
            //        {
            //            Console.WriteLine($"Enter the age of student {StudentCounter + 1}: (>21): ");
            //            Age = int.Parse(Console.ReadLine());
            //            if (Age <= 21)
            //            {
            //                Console.WriteLine("Invalid Age Number format ot it less than 21, please try again.");
            //            }
            //            else
            //            {
            //                FlagAge = false;
            //            }
            //        }
            //        catch (Exception e)
            //        {
            //            Console.WriteLine($"Error: {e.Message}");
            //            Console.WriteLine("Press enter to continue...");
            //        }

            //    } while (FlagAge);
            //    Console.WriteLine("Age Entered Successfully!");
            //    Ages[StudentCounter] = Age;



            //    //-----------------------------------------------------------------------------------Date

            //    Dates[StudentCounter] = DateTime.Now;
            //    Console.WriteLine("Student Add Successfully");
            //    StudentCounter++;

            //    Console.WriteLine("Do you want add another student information ? y / n");
            //    ChoiceChar = Console.ReadKey().KeyChar;
            //    Console.ReadKey();
            //    Console.WriteLine();
            //    if (ChoiceChar != 'y' && ChoiceChar != 'Y')
            //        break;
            //}
            //if (StudentCounter >= 4)
            //    Console.WriteLine("Cannot add more students. Maximum limit reached.");


            //---------------------------------------------------------------------------------------------
            char ChoiceChar = 'y';
            bool IsSave = true;
            bool AddMore = true;
            while (AddMore && StudentCounter < 4)
            {
                
                Console.WriteLine($"Enter the name of student {StudentCounter + 1}:");
                Name = Console.ReadLine();

                do
                {
                    Console.WriteLine($"Enter the Mark of student {StudentCounter + 1} (0-100): ");
                    Mark = double.Parse(Console.ReadLine());
                    triesEnterCorrectValue++;
                    if (triesEnterCorrectValue >= 5)
                    {
                        Console.WriteLine("You exceeded tries limited");
                        IsSave = false;
                        break;
                    }
                } while (Mark < 0 || Mark > 100);

                if (triesEnterCorrectValue >= 5)
                {
                    Console.WriteLine("You exceeded tries limited");
                    IsSave = false;
                    break;
                }

                do
                {
                    Console.WriteLine($"Enter the age of student {StudentCounter + 1}: (must be > 21): ");
                    Age = int.Parse(Console.ReadLine());
                    triesEnterCorrectValue++;
                    if (triesEnterCorrectValue >= 5)
                    {
                        Console.WriteLine("You exceeded tries limited");
                        IsSave = false;
                        break;
                    }
                } while (Age < 21);

                if (triesEnterCorrectValue >= 5)
                {
                    Console.WriteLine("You exceeded tries limited");
                    IsSave = false;
                    break;
                }

                Date = DateTime.Now;

                if (IsSave = false)
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
                    triesEnterCorrectValue = 0;
                    Console.WriteLine("Do you want add another student information ? y / n");
                    ChoiceChar = Console.ReadKey().KeyChar;
                    Console.ReadKey();
                    Console.WriteLine();
                    StudentCounter ++;
                }
                if (StudentCounter > 4)
                {
                    Console.WriteLine("Cannot add more students. Maximum limit reached.");
                    break;
                }

                
                //if (StudentCounter > 4)
                //{
                //    Console.WriteLine("Cannot add more students. Maximum limit reached.");
                //    break;
                //}

                //Console.WriteLine("Do you want add another student information ? y / n");
                //ChoiceChar = Console.ReadKey().KeyChar;
                //Console.ReadKey();
                Console.WriteLine();
                if (ChoiceChar != 'y' && ChoiceChar != 'Y')
                {
                    AddMore = false;
                   
                }
                //else
                //{
                //    if (StudentCounter > 4)
                //    {
                //        Console.WriteLine("Cannot add more students. Maximum limit reached.");
                //        AddMore = false;
                //    }
                    
                //}
            }
            
        }

        static void ViewingAllStudents()
        {
            if (StudentCounter == 0)
            {
                Console.WriteLine("No students available.");
                return;
            }
            for (int i = 0; i < StudentCounter; i++)
            {
                Console.WriteLine($"Student {i + 1}:");
                Console.WriteLine($"Name: {Names[i]}");
                Console.WriteLine($"Mark: {Marks[i]}");
                Console.WriteLine($"Age: {Ages[i]}");
                Console.WriteLine($"Date of Enrollment: {Dates[i]:yyyy-MM-dd HH:mm:ss}\n");
            }
        }


        static void FindStudent()
        {
            Console.WriteLine("Enter the neme of student: ");
            string SearchName= Console.ReadLine().ToLower();
            for (int i = 0; i < StudentCounter; i++) 
            {
                if (Names[i].ToLower() == SearchName)
                {
                    Console.WriteLine($"Mark: {Marks[i]}");
                    Console.WriteLine($"Age: {Ages[i]}");
                    Console.WriteLine($"Date of Enrollment: {Dates[i]:yyyy-MM-dd HH:mm:ss}\n");
                    return;
                }    
            }
            Console.WriteLine("Student not found.");
        }

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

        static void TopPerformingStudent()
        {
            int IndexTopPerformance = 0;
            double MaxMark = 0;
            for (int i = 0; i < StudentCounter; i++)
            {
                if (Marks[i] > MaxMark)
                {
                    IndexTopPerformance = i;
                    MaxMark = Marks[i];

                }
            }

            Console.WriteLine($"Top Student: {Names[IndexTopPerformance]}, Marks: {Marks[IndexTopPerformance]}, Age: {Ages[IndexTopPerformance]}");
        }

        static void SortingStudents()
        {
            double HoldMark;
            string HoldName;
            int HoldAge;
            DateTime HoldDate;

            Console.WriteLine("Students sorted by marks in descending order.");
            for (int i = 0; i < StudentCounter; i++)
            {
                for (int j = i+1; j < StudentCounter; j++)
                {
                    if (Marks[i] < Marks[j])
                    {
                        HoldMark = Marks[i];
                        Marks[i] = Marks[j];
                        Marks[j] = HoldMark;

                        HoldName = Names[i];
                        Names[i] = Names[j];
                        Names[j] = HoldName;

                        HoldAge = Ages[i];
                        Ages[i] = Ages[j];
                        Ages[j] = HoldAge;

                        HoldDate = Dates[i];
                        Dates[i] = Dates[j];
                        Dates[j] = HoldDate;
                        
                    }
                }
            }

            for (int i = 0;i < StudentCounter; i++)
            {
                Console.WriteLine($"Name: {Names[i]}");
                Console.WriteLine($"Mark: {Marks[i]}");
                Console.WriteLine($"Age: {Ages[i]}");
                Console.WriteLine($"Date of Enrollment: {Dates[i]:yyyy-MM-dd HH:mm:ss}\n");
            }


        }

        static void DeleteStudentRecord()
        {
            bool DeleteFlag = true;
            int IndexName=0;
            Console.WriteLine("Enter the name of student tou want to delete it: ");
            string DeleteName = Console.ReadLine().ToLower();
            for (int i = 0; i < StudentCounter; i++) 
            { 
                if (Names[i].ToLower() == DeleteName)
                {
                    IndexName = i;
                    for (int j = IndexName; j < StudentCounter; j++) 
                    {
                        Names[j] = Names[j+1];
                        Marks[j] = Marks[j + 1];
                        Ages[j]= Ages[j+1];
                        Dates[j] = Dates[j+1];
                    }
                    StudentCounter--;
                    DeleteFlag = true;

                }
                else
                {
                    DeleteFlag = false;
                }
            }

            if (DeleteFlag != false)
            {
                Console.WriteLine("Student record deleted successfully.");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }

            
                
            
        }

        

    }

    
}
