using System.Net;

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
                Console.WriteLine("6. View All Students By Marks");
                Console.WriteLine("7. Delete A Student Record");
                Console.WriteLine("0. Exit ");
                Console.Write("Enter your choice: ");
                choiceNum = int.Parse(Console.ReadLine());



                switch (choiceNum)
                {
                    case 1: AddNewStudentRecord(); break;
                    case 2: ViewingAllStudents(); break;
                    case 3: break;
                    case 4: break;
                    case 5: break;
                    case 6: break;
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
            for (int i = 0; i < StudentCounter; i++)
            {
                Console.WriteLine($"Student {i + 1}:");
                Console.WriteLine($"Name: {Names[i]}");
                Console.WriteLine($"Mark: {Marks[i]}");
                Console.WriteLine($"Age: {Ages[i]}");
                Console.WriteLine($"Date of Enrollment: {Dates[i]:yyyy-MM-dd HH:mm:ss}\n");
            }
        }






    }
}
