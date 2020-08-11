using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityToDoListMVC.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class ClearCSV
    {
        [TestMethod]
        public void ClearACSVFile_PassValidPath_ReturnAnEmptyCSVFile()
        {
            //Arrange 
            string filepath = "~/../../../ClearCSV/TestCSV.csv";
            EditCSVFile ECF = new EditCSVFile();

            //Act
            ECF.clear(filepath);
            string[] lines = File.ReadAllLines(filepath);

            //Assert
            Assert.AreEqual(1, lines.Length);

            //Reset
            ResetCSV(filepath, ECF);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ClearCSVFile_BlankFilePath_throwExeception()
        {
            //Arrange
            string filepath = "";
            EditCSVFile ECF = new EditCSVFile();

            //Act
            ECF.clear(filepath);

            //Assert
        }

        private static void ResetCSV(string filepath, EditCSVFile ECF)
        {
            ECF.add(filepath, "hello1");
            ECF.add(filepath, "hello2");
            ECF.add(filepath, "hello3");
            ECF.add(filepath, "hello4");
        }
    }
}
