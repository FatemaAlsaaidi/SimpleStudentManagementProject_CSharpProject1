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
                    case 7: break;
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

                int Mark;
                do
                {
                    Console.WriteLine($"Enter the Mark of student {StudentCounter+1} (0-100): ");
                } 
                while (!int.TryParse(Console.ReadLine(), out Mark) || Mark < 0 || Mark > 100);
                Marks[StudentCounter] = Mark;

                int Age;
                do
                {
                    Console.WriteLine($"Enter the age of student {StudentCounter+1}: (>21): ");
                     
                } while (!int.TryParse(Console.ReadLine(), out Age) || Age <= 21);
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
            Console.WriteLine("Students sorted by marks in descending order.");
            for (int i = 0; i < StudentCounter; i++)
            {
                for (int j = i + 1; j < StudentCounter; j++)
                {
                    if (Marks[i] < Marks[j])
                    {
                        (Marks[i], Marks[j]) = (Marks[j], Marks[i]);
                        (Names[i], Names[j]) = (Names[j], Names[i]);
                        (Ages[i], Ages[j]) = (Ages[j], Ages[i]);
                        (Dates[i], Dates[j]) = (Dates[j], Dates[i]);
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
    }
}
