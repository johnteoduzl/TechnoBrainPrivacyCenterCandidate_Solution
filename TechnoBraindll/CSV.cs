using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechnoBrainPrivacyCenterCandidate
{
    public class CSV
    {
        static List<String> managers = new List<string>();
        static List<String> managers2 = new List<string>();
        static List<String> employees = new List<string>();
        SortedDictionary<String, String> myList = new SortedDictionary<string, string>();

        ////public CSV(List<CSVData> data)
        ////{
        ////    listA = data;
        ////}

        public String Validate(List<CSVData> listA)
        {
            String ans = "Success";
            try
            {
                

                foreach (var employee in listA)
                {
                    managers2.Add(employee.Manager);//cREATING A LIST  OF THE MANAGERS
                    employees.Add(employee.employee);//Created a list of all the employees
                    if (employee.Manager.Trim().Equals(""))
                    {
                        managers.Add(employee.employee);
                    }
                }

                //Check the count of the list of CEO's
                if (managers.Count > 1)
                {
                    ans="There is more than one CEO, kinldy recheck the CSV";
                    return ans;
                }
                else
                {
                    //Check that Manger is an employee

                    foreach (var manager_Employee in managers2)
                    {
                        //Looping through check the current manager against list of Employees
                        if (!employees.Contains(manager_Employee) && !manager_Employee.Trim().Equals(""))
                        {
                            ans="The Manager " + manager_Employee + " is not an employee. Kindly check CSV";
                            return ans;
                        }

                    }

                    //Check that the employees do not report to more than one manager
                    //Loop through the list of the data being sent
                    foreach (var data in listA)
                    {

                        //data.employee //Gets me the employee I need
                        //So i need to check the count of that employee in Managers
                        //The managers under that employee are
                        List<CSVData> duplicates = listA.FindAll(x => x.employee == data.Manager);
                        if (duplicates.Count > 1)
                        {
                            ans="Duplicates found are " + duplicates.ElementAt(1).employee + " Manager " + duplicates.ElementAt(1).Manager + " Salary " + duplicates.ElementAt(1).salary;
                            return ans;
                        }

                    }

                    
                    //Display the list of the items in the CSV.
                    foreach (var item in listA)
                    {

                        Console.WriteLine("Employee: " + item.employee + " Manager: " + item.Manager + " Salary: " + item.salary);
                    }
                }
                
                return ans;
            }
            catch (Exception ex)
            {
                ans="Exception occureed: " + ex.Message ;
                return ans;
            }
        }

        public String helloWorld()
        {
            return "Hello World";
        }

        
    }
}
