using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace PriorityToDoList.UI.BDD
{
    public class PriorityToDoListPage
    {
        private readonly IWebDriver _driver;
        private const string PageUri = @"http://localhost:6758/ToDoList/PriorityToDoList";

        public By resetButton => By.Id("reset");

        public By inputText => By.Id("text");

        private By highButton => By.Id("addToHighList");

        private By medButton => By.Id("addToMedList");

        private By lowButton => By.Id("addToLowList");

        private By clearTextButton => By.Id("clearTextButton");

        private By doneHighButton => By.Name("highDone");

        private By doneMedButton => By.Name("medDone");

        private By doneLowButton => By.Name("lowDone");

        private By removeHighButton => By.Name("highRemove");

        private By removeMedButton => By.Name("medRemove");

        private By removeLowButton => By.Name("lowRemove");

        private By highTableBody => By.Id("highTable");

        private By medTableBody => By.Id("medTable");

        private By lowTableBody => By.Id("lowTable");

        private By incompleteTasks => By.Id("incompleteTasks");

        private By completeTasks => By.Id("completeTasks");

        public PriorityToDoListPage(IWebDriver driver)
        {
            _driver = driver;

            PageFactory.InitElements(_driver, this);
        }

        public static PriorityToDoListPage NavigateTo(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUri);

            return new PriorityToDoListPage(driver);
        }

        public string TaskText 
        {
            set => WaitForElement(inputText).SendKeys(value);
        }

        public IWebElement WaitForElement(By element)
        {
            //waits for element to appear (timeout at 60 seconds)
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(element));
        }

        public string PageTitle() => _driver.Title;

        public bool TextAreaDisplayed() => WaitForElement(inputText).Displayed;

        public bool HighButtonDisplayed() => WaitForElement(highButton).Displayed;

        public bool MedButtonDisplayed() => WaitForElement(medButton).Displayed;

        public bool LowButtonDisplayed() => WaitForElement(lowButton).Displayed;

        public bool HighTableDisplayed() => WaitForElement(highTableBody).Displayed;

        public bool MedTableDisplayed() => WaitForElement(medTableBody).Displayed;

        public bool LowTableDisplayed() => WaitForElement(lowTableBody).Displayed;

        public int TextLength() => WaitForElement(inputText).GetAttribute("value").Length;

        public bool ClearTextButtonDisplayed() => WaitForElement(clearTextButton).Displayed;

        public bool ResetButtonDisplayed() => WaitForElement(resetButton).Displayed;

        public void SelectReset() => WaitForElement(resetButton).Click();

        public void SelectAddToHigh() => WaitForElement(highButton).Click();

        public void SelectAddToMed() => WaitForElement(medButton).Click();

        public void SelectAddToLow() => WaitForElement(lowButton).Click();

        public void SelectClearText() => WaitForElement(clearTextButton).Click();

        public void SelectHighDone() => WaitForElement(doneHighButton).Click();

        public void SelectMedDone() => WaitForElement(doneMedButton).Click();

        public void SelectLowDone() => WaitForElement(doneLowButton).Click();

        public void SelectHighRemove() => WaitForElement(removeHighButton).Click();

        public void SelectMedRemove() => WaitForElement(removeMedButton).Click();

        public void SelectLowRemove() => WaitForElement(removeLowButton).Click();

        private string ValueHelper(string element)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var rows = wait.Until(ExpectedConditions.ElementIsVisible(By.Name(element)));
            return rows.GetAttribute("value").ToString();
        }

        public string HighTableValue() => ValueHelper("highTasks");

        public string MedTableValue() => ValueHelper("medTasks");

        public string LowTableValue() => ValueHelper("lowTasks");

        public string CompletedTableHighValue() => ValueHelper("completedHighTasks");

        public string CompletedTableMedValue() => ValueHelper("completedMedTasks");

        public string CompletedTableLowValue() => ValueHelper("completedLowTasks");

        public bool RemoveHighValue() => WaitForElement(highTableBody).FindElements(By.TagName("td")).Count == 0;
        
        public bool RemoveMedValue() => WaitForElement(medTableBody).FindElements(By.TagName("td")).Count == 0;
        
        public bool RemoveLowValue() => WaitForElement(lowTableBody).FindElements(By.TagName("td")).Count == 0;

        public int IncompleteTasks() => int.Parse(WaitForElement(incompleteTasks).GetAttribute("value"));

        public int CompleteTasks() => int.Parse(WaitForElement(completeTasks).GetAttribute("value"));

        public string NoTextAlertMessage()
        {
            string alertMessage = _driver.SwitchTo().Alert().Text;
            _driver.SwitchTo().Alert().Accept(); 
            return alertMessage;
        }
    }
}
