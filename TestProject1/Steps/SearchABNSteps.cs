using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using FiableTest.Pages;
using System.ComponentModel.DataAnnotations.Schema;
using TechTalk.SpecFlow;

namespace FiableTest.Steps
{
    [Binding]
    public class SearchABNSteps
    {
        private readonly SearchABN searchABN;
        public SearchABNSteps(SearchABNPage searchABNPage) {
            searchABN = searchABNPage.searchABNPage;
        }
        #region Given
        [Given(@"The user is in ABN search page")]
        public async Task GivenTheUserIsInAbnSearchPage()
        {
            await searchABN.GoToABNPage();
            
        }
        #endregion Given

        #region When
        [When (@"The user search for an ABN")]
        public async Task WhenTheUserSearchForABN(Table table)
        {
            var tableRow = table.CreateSet<(string ABNName)> ();
            for (var row in tableRow)
            {
                await searchABN.SearchABN(row.ABNName);
            }
           
        }
        #endregion When

        #region Then
        [Then(@"The ABN details should be displayed")]
        public async Task ThenTheABNDetailsShouldBeDisplayed(Table table)
        {
            var tableRow = table.CreateSet < (string ABNName)> ();
            for (var row in tableRow)
            {
                await searchABN.CheckABNResult(row.ABNName);
            }
        }
        #endregion Then
    }
}
