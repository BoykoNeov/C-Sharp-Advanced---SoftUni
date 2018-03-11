namespace BashSoft
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public static class StudentsRepository
    {
        public static bool isDataInitialized = false;
        internal static Dictionary<string, Dictionary<string, List<int>>> studentsByCourse;

        public static void OrderAndTake(string courseName, string comparison, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositorySorters.OrderAndTake(studentsByCourse[courseName], comparison, studentsToTake.Value);
            }
        }

        public static void FilterAndTake(string courseName, string givenFilter, int? studentsToTake = null)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                if (studentsToTake == null)
                {
                    studentsToTake = studentsByCourse[courseName].Count;
                }

                RepositoryFilters.FilterAndTake(studentsByCourse[courseName], givenFilter, studentsToTake.Value);
            }
        }

        public static void InitializeData()
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData();
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        public static void InitializeData(string fileName)
        {
            if (!isDataInitialized)
            {
                OutputWriter.WriteMessageOnNewLine("Reading data...");
                studentsByCourse = new Dictionary<string, Dictionary<string, List<int>>>();
                ReadData(fileName);
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataAlreadyInitializedException);
            }
        }

        private static void ReadData()
        {
            string input = Console.ReadLine();

            while (!string.IsNullOrWhiteSpace(input))
            {
                InputEntryIntoDB(input);
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read");
        }

        private static void ReadData(string fileName)
        {
            string path = SessionData.GetCurrentDirectoryPath() + "\\" + fileName;

            if (File.Exists(path))
            {
                string[] allInputLines = File.ReadAllLines(path);

                for (int line = 0; line < allInputLines.Length; line++)
                {
                    InputEntryIntoDB(allInputLines[line]);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidPath);
                return;
            }

            isDataInitialized = true;
            OutputWriter.WriteMessageOnNewLine("Data read");
        }

        private static void InputEntryIntoDB(string inputLine)
        {
            string pattern = @"([A-Z][a-zA-Z#+]*_[A-Z][a-z]{2}_\d{4})\s+([A-Z][a-z]{0,3}\d{2}_\d{2,4})\s+(\d+)";
            Regex rgx = new Regex(pattern);

            if (!string.IsNullOrWhiteSpace(inputLine) && rgx.IsMatch(inputLine))
            {
                Match currentMatch = rgx.Match(inputLine);

                string courseName = currentMatch.Groups[1].Value;
                string student = currentMatch.Groups[2].Value;


                bool hasParsedScore = int.TryParse(currentMatch.Groups[3].Value, out int studentScoreOnTask);

                if (hasParsedScore && studentScoreOnTask >= 0 && studentScoreOnTask <= 100)
                {
                    if (!studentsByCourse.ContainsKey(courseName))
                    {
                        studentsByCourse.Add(courseName, new Dictionary<string, List<int>>());
                    }

                    if (!studentsByCourse[courseName].ContainsKey(student))
                    {
                        studentsByCourse[courseName].Add(student, new List<int>());
                    }

                    studentsByCourse[courseName][student].Add(studentScoreOnTask);
                }
            }
        }

        private static bool IsQueryForCoursePossible(string courseName)
        {
            if (isDataInitialized)
            {
                if (studentsByCourse.ContainsKey(courseName))
                {
                    return true;
                }
                else
                {
                    OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
                }
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.DataNotInitializedExceptionMessage);
            }

            return false;
        }

        private static bool IsQueryForStudentPossible(string courseName, string studentName)
        {
            if (IsQueryForCoursePossible(courseName) && studentsByCourse[courseName].ContainsKey(studentName))
            {
                return true;
            }
            else
            {
                OutputWriter.DisplayException(ExceptionMessages.InexistingCourseInDataBase);
            }

            return false;
        }

        public static void GetStudentScoresFromCourse(string coursename, string username)
        {
            if (IsQueryForStudentPossible(coursename, username))
            {
                OutputWriter.PrintStudent(new KeyValuePair<string, List<int>>(username, studentsByCourse[coursename][username]));
            }
        }

        public static void GetAllStudentsFromCourse(string courseName)
        {
            if (IsQueryForCoursePossible(courseName))
            {
                OutputWriter.WriteMessageOnNewLine($"{courseName}:");
                foreach (KeyValuePair<string, List<int>> studentMarkEntry in studentsByCourse[courseName])
                {
                    OutputWriter.PrintStudent(studentMarkEntry);
                }
            }
        }
    }
}