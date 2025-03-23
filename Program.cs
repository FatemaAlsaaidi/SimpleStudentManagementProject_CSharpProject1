using System.Net;
using System.Security.Claims;

namespace SimpleStudentManagementProject_CSharpProject1
{
    internal class Program
    {
        static double[] Marks = new double[10];
        static int[] Ages = new int[10];
        static string[] Names = new string[10];
        static DateTime[] Dates = new DateTime[10];
        static int StudentCounter = 0;
        
        static void Main(string[] args)
        {
            int choiceNum;
            while (true)
            {
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
                Console.Write("Enter your choice: ");
                choiceNum = int.Parse(Console.ReadLine());



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
        }

        static void AddNewStudentRecord()
        {
            char ChoiceChar='y';
            while (StudentCounter < 10)
            {
                Console.WriteLine($"Enter the name of student {StudentCounter+1}:");
                Names[StudentCounter] = Console.ReadLine();

                double Mark;
                do
                {
                    Console.WriteLine($"Enter the Mark of student {StudentCounter+1} (0-100): ");
                    Mark = double.Parse(Console.ReadLine());

                    if (Mark < 0 || Mark > 100)
                    {
                        Console.WriteLine("Incorrect Mark format or it not in rang (0-100), please try again.");
                        
                    }
                } 
                while (Mark < 0 || Mark > 100);
                Console.WriteLine("Mark Entered Successfully!");
                Marks[StudentCounter] = Mark;

                int Age;
                do
                {
                    Console.WriteLine($"Enter the age of student {StudentCounter+1}: (>21): ");
                    Age = int.Parse(Console.ReadLine());
                    if (Age <= 21)
                    {
                        Console.WriteLine("Invalid Age Number format ot it less than 21, please try again.");
                    }

                } while (Age <= 21);
                Console.WriteLine("Age Entered Successfully!");
                Ages[StudentCounter] = Age;

                Dates[StudentCounter] = DateTime.Now;
                Console.WriteLine("Student Add Successfully");
                StudentCounter++;

                Console.WriteLine("Do you want add another student information ? y / n");
                ChoiceChar = Console.ReadKey().KeyChar;
                Console.WriteLine();
                if (ChoiceChar != 'y' && ChoiceChar != 'Y')
                    break;
            }
            if (StudentCounter == 11)
                Console.WriteLine("Cannot add more students. Maximum limit reached.");

            
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
                Console.WriteLine("Student not found.");
            }
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
            for (int i = 0; i < StudentCounter; i++)
            {
                if (Marks[i] > IndexTopPerformance)
                {
                    IndexTopPerformance = i;
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
                for (int j = i + 1; j < StudentCounter; j++)
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
            int IndexName = 0;
            Console.WriteLine("Enter the name of student tou want to delete it: ");
            string DeleteName = Console.ReadLine().ToLower();
            for (int i = 0; i < StudentCounter; i++) 
            { 
                if (Names[i].ToLower() == DeleteName)
                {
                    IndexName = i;
                    for (int j = IndexName + 1; j < StudentCounter-1; j++) 
                    {
                        Names[j] = Names[j-1];
                        Marks[j] = Marks[j - 1];
                        Ages[j]= Ages[j-1];
                        Dates[j] = Dates[j-1];
                    }
                    StudentCounter--;

                    Console.WriteLine("Student record deleted successfully.");
                }
            }

            for (int i = 0; i < StudentCounter; i++)
            {
                Console.WriteLine($"Name: {Names[i]}");
                Console.WriteLine($"Mark: {Marks[i]}");
                Console.WriteLine($"Age: {Ages[i]}");
                Console.WriteLine($"Date of Enrollment: {Dates[i]:yyyy-MM-dd HH:mm:ss}\n");
            }
            Console.WriteLine("Student not found.");
        }

    }
}
