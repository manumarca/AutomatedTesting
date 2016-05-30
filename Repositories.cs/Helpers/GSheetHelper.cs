using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.GData.Client;
using Google.GData.Extensions;
using Google.GData.Spreadsheets;

namespace Repositories.cs.Helpers
{
    class GSheetHelper
    {
        SpreadsheetsService sheetService ;

        public void Authenticate()
        {
            sheetService = new SpreadsheetsService("");
            sheetService.setUserCredentials("manuel.marcatili@fdvsolutions.com", "Lagger12");
        }

        private SpreadsheetFeed GetSpreadsheets()
        {
            SpreadsheetQuery query = new SpreadsheetQuery();
            SpreadsheetFeed feed = sheetService.Query(query);

            Console.WriteLine("Your spreadsheets: ");
            foreach (SpreadsheetEntry entry in feed.Entries)
            {
                Console.WriteLine(entry.Title.Text);
            }

            return feed;
        }

        public SpreadsheetEntry SelectSpreadSheet(string title)
        {
            foreach (SpreadsheetEntry entry in GetSpreadsheets().Entries)
            {
                if (entry.Title.Text.Equals(title)) return entry;
            }
           throw new Exception("Sheet Wasn´t founded with title: " + title );
        }

    }
}
