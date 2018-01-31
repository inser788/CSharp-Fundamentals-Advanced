using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    class Department
    {
        public Dictionary<string,Patient> Doctors { get; set; }
    }

    class Patient
    {
        public Dictionary<string,int> NameAndRoomNumber { get; set; }

    }

class Program
{
    static void Main(string[] args)
    {
        var hostipalData = new Dictionary<string, Department>();

        while (true)
        {
            string input = Console.ReadLine();
            if (input == "Output")
                break;

            string[] data = input
                .Split(" \t\n".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToArray();
            string departmentName = data[0].Trim();
            string doctorName = data[1].Trim() + " " + data[2].Trim();
            string patientsName = data[3].Trim();

            var departmentInfo = new Department();
            var patientInfo = new Patient();
            patientInfo.NameAndRoomNumber= new Dictionary<string, int>();
            patientInfo.NameAndRoomNumber.Add(patientsName,0);
            departmentInfo.Doctors = new Dictionary<string, Patient>();
            departmentInfo.Doctors.Add(doctorName, patientInfo);
            int counter;
            if (!hostipalData.ContainsKey(departmentName))
            {
                hostipalData[departmentName] = departmentInfo;
                hostipalData[departmentName].Doctors[doctorName].NameAndRoomNumber[patientsName] = 1;
            }
            else
            {
                counter = hostipalData[departmentName].Doctors.Values.Sum(x => x.NameAndRoomNumber.Keys.Count);

                if (counter>=60)
                {
                    continue;
                }
                if (!hostipalData[departmentName].Doctors.ContainsKey(doctorName))
                {
                    hostipalData[departmentName].Doctors[doctorName] = patientInfo;
                    counter = hostipalData[departmentName].Doctors.Values.Sum(x => x.NameAndRoomNumber.Keys.Count);

                    if (counter%3==0)
                    {
                    hostipalData[departmentName].Doctors[doctorName].NameAndRoomNumber[patientsName] = (counter / 3);
                    }
                    else
                    {
                    hostipalData[departmentName].Doctors[doctorName].NameAndRoomNumber[patientsName] = (counter / 3)+1;
                    }
                }
                else
                {
                    hostipalData[departmentName].Doctors[doctorName].NameAndRoomNumber.Add(patientsName,0);
                    counter = hostipalData[departmentName].Doctors.Values.Sum(x => x.NameAndRoomNumber.Keys.Count);
                    if (counter % 3 == 0)
                    {
                        hostipalData[departmentName].Doctors[doctorName].NameAndRoomNumber[patientsName] = (counter / 3);
                    }
                    else
                    {
                        hostipalData[departmentName].Doctors[doctorName].NameAndRoomNumber[patientsName] = (counter / 3)+1;
                    }
                }
            }
        }

        while (true)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();
            string nameForPrint = input[0];
            if (nameForPrint=="End")
                break;
            
            if (hostipalData.ContainsKey(nameForPrint)&&input.Length==1)
            {
                foreach (var doctor in hostipalData.Where(x=>x.Key== nameForPrint))
                {
                    foreach (var name in doctor.Value.Doctors.Values)
                    {
                        foreach (var patient in name.NameAndRoomNumber.Keys)
                        {
                            Console.WriteLine(patient);
                        }
                    }
                }
            }
            else if (hostipalData.ContainsKey(nameForPrint)&&input.Length==2)
            {
                
            }
            else
            {
                
                foreach (var doctor in hostipalData.Where(x=>x.Value.Doctors.ContainsKey(nameForPrint)))
                {
                    foreach (var patient in doctor.Value.Doctors.Values)
                    {
                        foreach (var name in patient.NameAndRoomNumber.Keys)
                        {
                            Console.WriteLine(name);
                        }
                    }
                }
            }
        }

    }
}

