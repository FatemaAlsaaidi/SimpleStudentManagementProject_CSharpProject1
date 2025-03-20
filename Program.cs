using System.Net;

namespace SimpleStudentManagementProject_CSharpProject1
{
    internal class Program
    {
        static double[] marks = new double[10];
        static int[] Ages = new int[10];
        static string[] names = new string[10];
        static DateTime[] dates = new DateTime[10];
        static int StudentCounter = 1;
        static void Main(string[] args)
        {
            char ChoiceChar;
            int choiceNum;
            while(true)
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
                    case 2: break;
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
            //char ChoiceChar='y';
            //do 
            //{
            //    for (int i = 1; i <= 10; i++)
            //    {
            //        if (StudentCounter <= 10)
            //        {
            //            Console.WriteLine($"Enter the name of student {StudentCounter}:");
            //            names[i] = Console.ReadLine();
            //            do
            //            {
            //                Console.WriteLine($"Enter the Mark of student {StudentCounter}:");
            //                marks[i] = int.Parse(Console.ReadLine());
            //            } while (marks[i] < 0 || marks[i] > 100);
            //            do
            //            {
            //                Console.WriteLine($"Enter the age of student {StudentCounter}:");
            //                Ages[i] = int.Parse(Console.ReadLine());

            //            } while (Ages[i] < 21);

            //            dates[i] = DateTime.Now;
            //            string formattedDate = dates[i].ToString("yyyy-MM-dd HH:mm:ss");

            //            Console.WriteLine("Do you want add another student information ? y / n");
            //            ChoiceChar = Console.ReadKey().KeyChar;
            //        }
            //        else
            //        {
            //            Console.WriteLine("Can Not Add More Student");
            //            ChoiceChar = 'n';
            //        }
            //    }
            //    StudentCounter++;
            //} 
            //while (ChoiceChar == 'n' || ChoiceChar == 'N');
            //Console.WriteLine("\n Information Students Add Successfully");   

            //for (int j = 1; j <= StudentCounter; j++)
            //{
            //    Console.WriteLine(names);
            //    Console.WriteLine(marks);
            //    Console.WriteLine(Ages);
            //    Console.WriteLine(dates);
            //}
            
        }






    }
}
