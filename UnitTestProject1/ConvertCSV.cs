using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PriorityToDoListMVC.Models;

namespace UnitTestProject1
{
    [TestClass]
    public class ConvertCSV
    {
        [TestMethod]
        public void ConvertCSVToModel_ValidFilePath_ReturnOneValue()
        {
            //Arrange
            string filepath = "~/../../../ConvertCSV/TestCSVSingleValue.csv";
            EditCSVFile ECF = new EditCSVFile();

            //Act
            List<TasksModel> resultModel = ECF.convert(filepath);

            //Assert
            Assert.AreEqual(1, resultModel.Count);
        }

        [TestMethod]
        public void ConvertCSVToModel_ValidFilePath_ReturnTask()
        {
            //Arrange
            string filepath = "~/../../../ConvertCSV/TestCSVSingleValue.csv";
            EditCSVFile ECF = new EditCSVFile();

            //Act
            List<TasksModel> resultModel = ECF.convert(filepath);

            //Assert
            Assert.AreEqual("hello1", resultModel[resultModel.Count-1].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ConvertCSVToModel_BlankFilePath_throwExeception()
        {
            //Arrange
            string filepath = "";
            EditCSVFile ECF = new EditCSVFile();

            //Act
            List<TasksModel> resultModel = ECF.convert(filepath);

            //Assert
        }

        [TestMethod]
        public void ConvertCSVToCompletedModel_ValidPath_ReturnOneResult()
        {
            //Arrange
            string filepath = "~/../../../ConvertCSV/TestCSVCompletedTaskSingleValue.csv";
            EditCSVFile ECF = new EditCSVFile();

            //Act
            List <CompletedModel> completedTaskModel = ECF.convertToCompletedMdoel(filepath);

            //Assert
            Assert.AreEqual(1, completedTaskModel.Count);
        }

        [TestMethod]
        public void ConvertCSVToCompletedModel_ValidPath_ReturnNameOfTask()
        {
            //Arrange
            string filepath = "~/../../../ConvertCSV/TestCSVCompletedTaskSingleValue.csv";
            EditCSVFile ECF = new EditCSVFile();

            //Act
            List<CompletedModel> completedTaskModel = ECF.convertToCompletedMdoel(filepath);

            //Assert
            Assert.AreEqual("Hello World", completedTaskModel[completedTaskModel.Count-1].Name);
        }
    }
}
