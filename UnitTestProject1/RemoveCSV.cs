using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityToDoListMVC.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class RemoveCSV
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange 
            string filepath = "~/../../../RemoveCSV/TestCSV.csv";
            EditCSVFile ECF = new EditCSVFile();

            //Act
            ECF.remove(filepath, "hello2");
            string[] lines = File.ReadAllLines(filepath);
            bool isNotInFile = true;
            foreach (string line in lines)
            {
                if (line == "hello2")
                {
                    isNotInFile = false;
                }
            }

            //Assert
            Assert.AreEqual(true, isNotInFile);

            //Reset
            ECF.add(filepath, "hello2");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveValueFromCSVFile_BlankFilePath_throwExeception()
        {
            //Arrange
            string filepath = "";
            EditCSVFile ECF = new EditCSVFile();

            //Act
            ECF.remove(filepath, "hello2");

            //Assert
        }
    }
}
