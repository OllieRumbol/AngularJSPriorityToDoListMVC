using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;

namespace PriorityToDoList.UI.BDD
{
    public class PriorityToDoListTests
    {
        [Fact]
        public void LoadingPage()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");

                //Assert
                Assert.Equal("Priority To-Do List", driver.Title);
            }
        }

        [Fact]
        public void AddText()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");
                driver.FindElement(By.Id("text")).SendKeys("Hello World");

                //Assert
                Assert.Equal("Hello World", driver.FindElement(By.Id("text")).GetAttribute("value"));
            }
        }

        [Fact]
        public void addTextToHighPriorityTable()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");
                driver.FindElement(By.Id("reset")).Click();
                driver.FindElement(By.Id("text")).SendKeys("Hello World");
                driver.FindElement(By.Id("addToHighList")).Click();

                //Assert
                Assert.Equal("Hello World", driver.FindElement(By.Name("highTasks")).GetAttribute("value"));

                //Clean up
                driver.FindElement(By.Id("reset")).Click();
            }
        }

        [Fact]
        public void addTextToMedPriorityTable()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");
                driver.FindElement(By.Id("reset")).Click();
                driver.FindElement(By.Id("text")).SendKeys("Hello World");
                driver.FindElement(By.Id("addToMedList")).Click();

                //Assert
                Assert.Equal("Hello World", driver.FindElement(By.Name("medTasks")).GetAttribute("value"));

                //Clean up
                driver.FindElement(By.Id("reset")).Click();
            }
        }

        [Fact]
        public void addTextToLowPriorityTable()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");
                driver.FindElement(By.Id("reset")).Click();
                driver.FindElement(By.Id("text")).SendKeys("Hello World");
                driver.FindElement(By.Id("addToLowList")).Click();

                //Assert
                Assert.Equal("Hello World", driver.FindElement(By.Name("lowTasks")).GetAttribute("value"));

                //Clean up
                driver.FindElement(By.Id("reset")).Click();
            }
        }

        [Fact]
        public void addToCompletedFromHighTable()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");
                driver.FindElement(By.Id("reset")).Click();
                driver.FindElement(By.Id("text")).SendKeys("Hello World");
                driver.FindElement(By.Id("addToHighList")).Click();
                driver.FindElement(By.Name("highDone")).Click();

                //Assert
                Assert.Equal("Hello World", driver.FindElement(By.Name("completedHighTasks")).GetAttribute("value"));

                //Clean up
                driver.FindElement(By.Id("reset")).Click();
            }
        }

        [Fact]
        public void addToCompletedFromMedTable()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");
                driver.FindElement(By.Id("reset")).Click();
                driver.FindElement(By.Id("text")).SendKeys("Hello World");
                driver.FindElement(By.Id("addToMedList")).Click();
                driver.FindElement(By.Name("medDone")).Click();

                //Assert
                Assert.Equal("Hello World", driver.FindElement(By.Name("completedMedTasks")).GetAttribute("value"));

                //Clean up
                driver.FindElement(By.Id("reset")).Click();
            }
        }

        [Fact]
        public void addToCompletedFromLowTable()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");
                driver.FindElement(By.Id("reset")).Click();
                driver.FindElement(By.Id("text")).SendKeys("Hello World");
                driver.FindElement(By.Id("addToLowList")).Click();
                driver.FindElement(By.Name("lowDone")).Click();

                //Assert
                Assert.Equal("Hello World", driver.FindElement(By.Name("completedLowTasks")).GetAttribute("value"));

                //Clean up
                driver.FindElement(By.Id("reset")).Click();
            }
        }

        [Fact]
        public void removeFromHighTable()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");
                driver.FindElement(By.Id("reset")).Click();
                driver.FindElement(By.Id("text")).SendKeys("Hello World");
                driver.FindElement(By.Id("addToHighList")).Click();
                driver.FindElement(By.Name("highRemove")).Click();

                //Assert
                IWebElement highTableBody = driver.FindElement(By.Id("highTable"));
                bool isPresent = highTableBody.FindElements(By.TagName("td")).Count == 0;
                Assert.True(isPresent);

                //Clean up
                driver.FindElement(By.Id("reset")).Click();
            }
        }

        [Fact]
        public void removeFromMedTable()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");
                driver.FindElement(By.Id("reset")).Click();
                driver.FindElement(By.Id("text")).SendKeys("Hello World");
                driver.FindElement(By.Id("addToMedList")).Click();
                driver.FindElement(By.Name("medRemove")).Click();

                //Assert
                IWebElement medTableBody = driver.FindElement(By.Id("medTable"));
                bool isPresent = medTableBody.FindElements(By.TagName("td")).Count == 0;
                Assert.True(isPresent);

                //Clean up
                driver.FindElement(By.Id("reset")).Click();
            }
        }

        [Fact]
        public void removeFromLowTable()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");
                driver.FindElement(By.Id("reset")).Click();
                driver.FindElement(By.Id("text")).SendKeys("Hello World");
                driver.FindElement(By.Id("addToLowList")).Click();
                driver.FindElement(By.Name("lowRemove")).Click();

                //Assert
                IWebElement lowTableBody = driver.FindElement(By.Id("lowTable"));
                bool isPresent = lowTableBody.FindElements(By.TagName("td")).Count == 0;
                Assert.True(isPresent);

                //Clean up
                driver.FindElement(By.Id("reset")).Click();
            }
        }

        [Fact]
        public void AlertBoxesTest()
        {
            //Assert
            using (IWebDriver driver = new ChromeDriver())
            {
                //Act
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost:6758/ToDoList/PriorityToDoList");
                driver.FindElement(By.Id("reset")).Click();
                driver.FindElement(By.Id("addToHighList")).Click();
                string alertMessage = driver.SwitchTo().Alert().Text;
                driver.SwitchTo().Alert().Accept();

                //Assert
                Assert.Equal("No text in input field. Please add text before adding the task.", alertMessage);

                //Clean up
                driver.FindElement(By.Id("reset")).Click();
            }
        }
    }
}
