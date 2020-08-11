using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityToDoListMVC.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class AddCSV
    {
        [TestMethod]
        public void AddToCSVFile_UsingValidPath_CSVFileContainsNewTask()
        {
            //Arrange 
            string filepath = "~/../../../AddCSV/TestCSV.csv";
            EditCSVFile ECF = new EditCSVFile();

            //Act
            ECF.add(filepath, "Hello World");
            string[] lines = File.ReadAllLines(filepath);

            //Assert
            Assert.AreEqual("Hello World", lines[lines.Length-1]);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddCSVFile_BlankFilePath_throwExeception()
        {
            //Arrange
            string filepath = "";
            EditCSVFile ECF = new EditCSVFile();

            //Act
            ECF.add(filepath, "hello2");

            //Assert
        }
    }
}
