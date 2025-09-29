using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiableTest.Steps;
using Microsoft.Playwright;
namespace FiableTest.Pages
{
    public class SearchABNPage
    {
     //Locators
     private Locator txtSearchABNField = Page.getByRole('textbox', { name: 'Search by ABN, ACN or name:' });
     private Locator btnSearchABN = Page.getByRole('button', { name: 'Search' });

        public async Task GoToABNPage()
        {
            await Page.Goto("https://abr.business.gov.au/");
            await Page.WaitForLoadStateAsync();
        }

        public async Task SearchABN(string ABNName) {
            await txtSearchABNField.fill(ABNName);
            await btnSearchABN.click();
        }

        public async Task CheckABNResult(string ABNName)
        {
            await Assertions.expect(Page.getByRole('cell', { name: ABNName })).toBeVisibleAsync();

}
    }
}
