namespace Hospital
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    public class Launcher
    {
        public static void Main()
        {
            Dictionary<string, List<string>> patientsByDepartment = new Dictionary<string, List<string>>();
            Dictionary<string, List<string>> patientsByDoctor = new Dictionary<string, List<string>>();

            string input = string.Empty;

            while((input = Console.ReadLine()) != "Output")
            {
                string[] splitInput = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string department = splitInput[0];
                string doctor = splitInput[1] + " " + splitInput[2];
                string patient = splitInput[3];

                if (!patientsByDepartment.ContainsKey(department))
                {
                    patientsByDepartment.Add(department, new List<string>());
                }

                if (!patientsByDoctor.ContainsKey(doctor))
                {
                    patientsByDoctor.Add(doctor, new List<string>());
                }

                if (patientsByDepartment[department].Count < 60)
                {
                    patientsByDepartment[department].Add(patient);
                }

                patientsByDoctor[doctor].Add(patient);
            }

            string outputInput = string.Empty;

            while ((outputInput = Console.ReadLine()) != "End")
            {
                string[] splitInputOutput = outputInput.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (splitInputOutput.Length == 1)
                {
                    string departmentName = splitInputOutput[0];

                    foreach (string patient in patientsByDepartment[departmentName])
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    if (int.TryParse(splitInputOutput[1], out int roomNumber))
                    {
                        string departmentName = splitInputOutput[0];

                        foreach (string patient in patientsByDepartment[departmentName].Skip((roomNumber - 1) * 3).Take(3).OrderBy(p => p))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        string doctorName = splitInputOutput[0] + " " + splitInputOutput[1];

                        foreach (string patient in patientsByDoctor[doctorName].OrderBy(p => p))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
            }
        }
    }
}