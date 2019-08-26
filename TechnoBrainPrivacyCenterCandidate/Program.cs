using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBrainPrivacyCenterCandidate
{
    class Program
    {
        public static List<CSVData> listA = new List<CSVData>();
        public static int lineError = 0;


        public static List<CSVData> getData(String path)
        {
            List<CSVData> n = new List<CSVData>();

            try
            {
                using (var reader = new StreamReader(path))
                {


                    while (!reader.EndOfStream)
                    {
                        lineError++;
                        var line = reader.ReadLine();
                        var values = line.Split(',');
                        String Employee1 = values[0];
                        String Employee2 = values[1];
                        Int32 Salary = Int32.Parse(values[2]);

                        Type a = Salary.GetType();
                        Type b = typeof(System.Int32);
                        //Before any addition happens there is need for validation
                        if (a.Equals(b))
                        {

                            n.Add(new CSVData(Employee1, Employee2, Salary));
                        }
                        else
                        {
                            //There is an error stop the loop
                            Console.WriteLine("Salary is not Integer on line: " + lineError);
                            
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Occurred while reading data at line " + lineError);
            }
            return n;
        }
        static void Main(string[] args)
        {

            CSV cs = new CSV();
            List<CSVData> data = getData(@"C:\Users\kpcdesktop\Documents\Office Documents\Excel\Technobrain\TechnoBrain.csv");
            Console.WriteLine(cs.Validate(data));
            Console.ReadKey();


        }


        int getSalary(String employeeId)
        {
            int xy = 0;
            List<int> salary = new List<int>();
            //I want to get the salary of the Employees under Employee3
            List<CSVData> employed = listA.FindAll(sal => sal.Manager == employeeId);
            if (employed.Count > 0)
            {
                

                //Loop through and find out if there are more being managed
                foreach (var data in employed)
                {
                    salary.Add(employed.ElementAt(0).salary);
                    //UNder this list I now want to get all the other managers
                    Console.WriteLine("Data is : " + data.Manager + " Employee is: " + data.employee);
                    List<CSVData> emp = listA.FindAll(dat => dat.Manager == data.employee);
                    if (emp.Count > 0)
                    {
                        foreach (var item in emp)
                        {
                            salary.Add(item.salary);
                            Console.WriteLine("iTEMS ARE: " + item.employee);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The node ends at this point");
                    }

                }
            }
            else
            {
                Console.WriteLine("There is no Salary data");
            }
            foreach (var item in salary)
            {
                xy += item;
            }
            
            return xy;
        }
        public static String message()
        {
            return "Hello World";
        }
    }
}
