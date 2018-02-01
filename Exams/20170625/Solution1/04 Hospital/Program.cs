using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;




class Program
{
    private const int maxBedsDepartment = 60;

    static void Main()
    {
        var departmentPatients = new Dictionary<string, HashSet<string>>();
        var doctorsPatients = new Dictionary<string, HashSet<string>>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Output")
                break;

            string[] data = input
                .Split(" \t\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            string departmentName = data[0].Trim();
            string doctorName = data[1].Trim() + " " + data[2].Trim();
            string patientsName = data[3];

            if (!departmentPatients.ContainsKey(departmentName))
            {
                departmentPatients[departmentName] = new HashSet<string>();
            }

            if (!doctorsPatients.ContainsKey(doctorName))
            {
                doctorsPatients[doctorName] = new HashSet<string>();
            }

            if (departmentPatients[departmentName].Count >= maxBedsDepartment)
            {
                continue;
            }

            departmentPatients[departmentName].Add(patientsName);
            doctorsPatients[doctorName].Add(patientsName);
        }

        while (true)
        {
            string[] input = Console.ReadLine()
                .Split(" \t\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            if (input[0] == "End")
                break;
            int coutOfSearchElements = input.Length;
            switch (coutOfSearchElements)
            {
                case 1:
                    string seachedDepartment = input[0];
                    if (departmentPatients.ContainsKey(seachedDepartment))
                    {
                        departmentPatients[seachedDepartment].ToList()
                            .ForEach(p=>Console.WriteLine(p));
                    }
                    break;
                case 2:
                    string searchedDoctor = input[0] + " " + input[1];
                    if (doctorsPatients.ContainsKey(searchedDoctor))
                    {
                        doctorsPatients[searchedDoctor].OrderBy(x=>x)
                            .ToList()
                            .ForEach(p=>Console.WriteLine(p));
                    }
                    else
                    {
                        string currentDepartmen = input[0];
                        int searchedRoom = int.Parse(input[1]);
                        departmentPatients[currentDepartmen]
                            .Skip((searchedRoom*3)-3)
                            .Take(3)
                            .OrderBy(x=>x)
                            .ToList()
                            .ForEach(p=>Console.WriteLine(p));
                    }
                    break;
            }
        }
    }
}




