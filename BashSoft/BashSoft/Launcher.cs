namespace BashSoft
{
    public class Launcher
    {
        public static void Main()
        {
            // Test 1
            // IOManager.TraverseDirectory(@"F:\temp");

            // Test 2
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetAllStudentsFromCourse("Unity");

            // Test 3
            //StudentsRepository.InitializeData();
            //StudentsRepository.GetStudentScoresFromCourse("Ivan", "Unity");

            // Test 4 - Judge
            // SimpleJudge.Tester.CompareContent(@"C:\temp\test2.txt", @"C:\temp\test3.txt");

            // Test 5
            //IOManager.CreateDirectoryInCurrentFolder("pesho");

            // Test 6
            // IOManager.TraverseDirectory(1);

            // Test 7
            //IOManager.ChangeCurrentDirectoryAbsolute(@"C:\Windows");
            //IOManager.TraverseDirectory(20);

            // Test 8
            // Tester.CompareContent(@"greshka.gre", @"C:\temp\test2.txt");

            // Test 9
            //IOManager.CreateDirectoryInCurrentFolder("*2");

            // Test 10
            //for (int i = 0; i < 7; i++)
            //{
            //    IOManager.ChangeCurrentDirectoryRelative("..");
            //}

            // Test 11
            IO.InputReader.StartReadingCommands();

        }
    }
}