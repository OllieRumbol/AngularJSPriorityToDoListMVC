using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using Xunit;

namespace PriorityToDoList.UI.BDD
{
    [Binding]
    public class PriorityToDoListSteps
    {
        private IWebDriver driver;
        private PriorityToDoListPage _priorityToDoListPage;

        [Given(@"I am on the priority to do list screen")]
        public void GivenIAmOnThePriorityToDoListScreen()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            _priorityToDoListPage = PriorityToDoListPage.NavigateTo(driver);

            _priorityToDoListPage.SelectReset();
        }

        [Then(@"the title should be Priority To-Do List")]
        public void ThenTheTitleShouldBePriorityTo_DoList()
        {
            Assert.Equal("Priority To-Do List", _priorityToDoListPage.PageTitle());
        }

        [Then(@"the text area is displayed")]
        public void ThenTheTextAreaIsDisplayed()
        {
            Assert.True(_priorityToDoListPage.TextAreaDisplayed());
        }

        [Then(@"the high button is displayed")]
        public void ThenTheHighButtonIsDisplayed()
        {
            Assert.True(_priorityToDoListPage.HighButtonDisplayed()); 
        }

        [Then(@"the medium button is displayed")]
        public void ThenTheMediumButtonIsDisplayed()
        {
            Assert.True(_priorityToDoListPage.MedButtonDisplayed());
        }

        [Then(@"the low button is displayed")]
        public void ThenTheLowButtonIsDisplayed()
        {
            Assert.True(_priorityToDoListPage.LowButtonDisplayed());
        }

        [Then(@"the clear text button is displayed")]
        public void ThenTheClearTextButtonIsDisplayed()
        {
            Assert.True(_priorityToDoListPage.ClearTextButtonDisplayed());
        }

        [Then(@"the high priority table is displayed")]
        public void ThenTheHighPriorityTableIsDisplayed()
        {
            Assert.True(_priorityToDoListPage.HighTableDisplayed());
        }

        [Then(@"the medium priority table is displayed")]
        public void ThenTheMediumPriorityTableIsDisplayed()
        {
            Assert.True(_priorityToDoListPage.MedTableDisplayed());
        }

        [Then(@"the low priority table is displayed")]
        public void ThenTheLowPriorityTableIsDisplayed()
        {
            Assert.True(_priorityToDoListPage.LowTableDisplayed());
        }

        [Then(@"the reset button is displayed")]
        public void ThenTheResetButtonIsDisplayed()
        {
            Assert.True(_priorityToDoListPage.ResetButtonDisplayed());
        }

        [Given(@"I enter a tasks of (.*)")]
        public void GivenIEnterATasksOf(string task)
        {
            _priorityToDoListPage.TaskText = task;
        }
        
        [Given(@"I select the high button")]
        public void GivenISelectTheHighButton()
        {
            _priorityToDoListPage.SelectAddToHigh();
        }
        
        [When(@"I select the high button")]
        public void WhenISelectTheHighButton()
        {
            _priorityToDoListPage.SelectAddToHigh();
        }
        
        [When(@"I select the done button in the high table")]
        public void WhenISelectTheDoneButton()
        {
            _priorityToDoListPage.SelectHighDone();
        }
        
        [Then(@"the task should appear in the high priority table")]
        public void ThenTheTaskShouldAppearInTheHighPriorityTable()
        {
            Assert.Equal("write code", _priorityToDoListPage.HighTableValue());
        }
        
        [Then(@"the high priority task should appear in the complete table")]
        public void ThenTheTaskShouldAppearInTheCompleteTable()
        {
            Assert.Equal("write code", _priorityToDoListPage.CompletedTableHighValue());
        }

        [When(@"I select the remove button from the high priority table")]
        public void WhenISelectTheRemoveButtonFromTheHighPriorityTable()
        {
            _priorityToDoListPage.SelectHighRemove();
        }

        [Then(@"the task should be removed from the high table")]
        public void ThenTheTaskShouldBeRemovedFromTheHighTable()
        {
            Assert.True(_priorityToDoListPage.RemoveHighValue());
        }

        [When(@"I select the med button")]
        public void WhenISelectTheMedButton()
        {
            _priorityToDoListPage.SelectAddToMed();
        }

        [Then(@"the task should appear in the medium priority table")]
        public void ThenTheTaskShouldAppearInTheMediumPriorityTable()
        {
            Assert.Equal("write code", _priorityToDoListPage.MedTableValue());
        }

        [Given(@"I select the med button")]
        public void GivenISelectTheMedButton()
        {
            _priorityToDoListPage.SelectAddToMed();
        }

        [When(@"I select the done button in the medium table")]
        public void WhenISelectTheDoneButtonInTheMediumTable()
        {
            _priorityToDoListPage.SelectMedDone();
        }

        [Then(@"the medium priority task should appear in the complete table")]
        public void ThenTheMediumTaskShouldAppearInTheCompleteTable()
        {
            Assert.Equal("write code", _priorityToDoListPage.CompletedTableMedValue());
        }

        [When(@"I select the remove button from the medium priority table")]
        public void WhenISelectTheRemoveButtonFromTheMediumPriorityTable()
        {
            _priorityToDoListPage.SelectMedRemove();
        }

        [Then(@"the task should be removed from the medium table")]
        public void ThenTheTaskShouldBeRemovedFromTheMediumTable()
        {
            Assert.True(_priorityToDoListPage.RemoveMedValue());
        }

        [When(@"I select the low button")]
        public void WhenISelectTheLowButton()
        {
            _priorityToDoListPage.SelectAddToLow();
        }

        [Then(@"the task should appear in the low priority table")]
        public void ThenTheTaskShouldAppearInTheLowPriorityTable()
        {
            Assert.Equal("write code", _priorityToDoListPage.LowTableValue());
        }

        [Given(@"I select the low button")]
        public void GivenISelectTheLowButton()
        {
            _priorityToDoListPage.SelectAddToLow();
        }

        [When(@"I select the done button in the low table")]
        public void WhenISelectTheDoneButtonInTheLowTable()
        {
            _priorityToDoListPage.SelectLowDone();
        }

        [Then(@"the low priority task should appear in the complete table")]
        public void ThenTheLowPriorityTaskShouldAppearInTheCompleteTable()
        {
            Assert.Equal("write code", _priorityToDoListPage.CompletedTableLowValue());
        }

        [When(@"I select the remove button from the low priority table")]
        public void WhenISelectTheRemoveButtonFromTheLowPriorityTable()
        {
            _priorityToDoListPage.SelectLowRemove();
        }

        [Then(@"the task should be removed from the low table")]
        public void ThenTheTaskShouldBeRemovedFromTheLowTable()
        {
            Assert.True(_priorityToDoListPage.RemoveLowValue());
        }

        [Given(@"I enter a tasks of")]
        public void GivenIEnterATasksOf()
        {
            _priorityToDoListPage.TaskText = "";
        }

        [Then(@"An alert box should be displayed with the message No text in input field\. Please add text before adding the task\.")]
        public void ThenAnAlertBoxShouldBeDisplayedWithTheMessageNoTextInInputField_PleaseAddTextBeforeAddingTheTask_()
        {
            Assert.Equal("No text in input field. Please add text before adding the task.", _priorityToDoListPage.NoTextAlertMessage());
        }

        [Then(@"An alert box should be displayed with the message That priority list already contains that task\.")]
        public void ThenAnAlertBoxShouldBeDisplayedWithTheMessageThatPriorityListAlreadyContainsThatTask_()
        {
            Assert.Equal("That priority list already contains that task.", _priorityToDoListPage.NoTextAlertMessage());
        }

        [Then(@"incomplete increases by (.*)")]
        public void ThenIncompleteIncreasesBy(int p0)
        {
            Assert.Equal(p0, _priorityToDoListPage.IncompleteTasks());
        }

        [Then(@"complete increases by (.*)")]
        public void ThenCompleteIncreasesBy(int p0)
        {
            Assert.Equal(p0, _priorityToDoListPage.CompleteTasks());
        }

        [When(@"I select the clear text button")]
        public void WhenISelectTheClearTextButton()
        {
            _priorityToDoListPage.SelectClearText();
        }

        [Then(@"the text area shoud be empty")]
        public void ThenTheTextAreaShoudBeEmpty()
        {
            Assert.Equal(0, _priorityToDoListPage.TextLength());
        }

        [When(@"I click the reset Button")]
        public void WhenIClickTheResetButton()
        {
            _priorityToDoListPage.SelectReset();
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            driver.Dispose();
        }
    }
}
