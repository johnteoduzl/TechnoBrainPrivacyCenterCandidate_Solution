using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TechnoBrainPrivacyCenterCandidate;

namespace TechnoBrainTests
{
    [TestClass]
    public class TechnoBrain
    {
        [TestMethod]
        public void TestMethod1()
        {
            string expected = "Hello World";

            CSV n = new CSV();
            string actual = n.helloWorld();

            Assert.AreEqual(expected, actual);
        }


        //Test for invalid numbers in the salary
        [TestMethod]
        public void Return_Success_If_The_CSV_file_is_well_formatted()
        {

            string expected = "Success";

            CSV n = new CSV();
            List<CSVData> d = new List<CSVData>();
            d.Add(new CSVData("Employee4", "Employee2", 500));
            d.Add(new CSVData("Employee3", "Employee1", 500));
            d.Add(new CSVData("Employee1", "", 500));
            d.Add(new CSVData("Employee5", "Employee1", 500));
            d.Add(new CSVData("Employee2", "Employee1", 500));



            string actual = n.Validate(d);

            Assert.AreEqual(expected, actual);

            
        }

        [TestMethod]
        public void Return_Error_For_More_Than_One_CEO()
        {
            string expected = "Success";

            CSV n = new CSV();
            List<CSVData> d = new List<CSVData>();
            d.Add(new CSVData("Employee4", "Employee2", 500));
            d.Add(new CSVData("Employee3", "", 500));
            d.Add(new CSVData("Employee1", "", 500));
            d.Add(new CSVData("Employee5", "Employee1", 500));
            d.Add(new CSVData("Employee2", "Employee1", 500));



            string actual = n.Validate(d);

            Assert.AreEqual(expected, actual);

        }
        [TestMethod]
        public void Test_For_Invalid_CEO_Case()
        {
            string expected = "There is more than one CEO, kinldy recheck the CSV";
            CSV n = new CSV();
            List<CSVData> d = new List<CSVData>();
            d.Add(new CSVData("Employee4", "Employee2", 500));
            d.Add(new CSVData("Employee3", "", 500));
            d.Add(new CSVData("Employee1", "", 500));
            d.Add(new CSVData("Employee5", "Employee1", 500));
            d.Add(new CSVData("Employee2", "Employee1", 500));



            string actual = n.Validate(d);

            Assert.AreEqual(expected, actual);
        }


    }


}
