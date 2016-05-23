using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace WebDriverFramework.WebPage
{
    public class TableElement
    {
        private IWebElement element;
        private IList<IWebElement> rows;

        private By header_Xpath = By.XPath(".//th");

        public TableElement(IWebElement e)
        {
            this.element = e;
            rows = e.FindElements(By.XPath(".//tr"));
        }

        public IList<string> GetHeaders()
        {
            IList<IWebElement> headers = rows[0].FindElements(header_Xpath);
            List<String> list = new List<String>(headers.Count);
            for (int i = 0; i < headers.Count; i++)
            {
                list.Add(headers[i].Text);
            }
            return list;
        }

        public string GetText(int row, int column)
        {
            IList<IWebElement> columns = GetColumns(row);
            return columns[column - 1].Text;
        }

        /// <summary>
        /// Returns a list of Web Elements of row passed as argument
        /// This method should not be used in Functional Tests
        /// </summary>
        /// <param name="row">The first element of the table is 1x1 and is not the first header</param>
        /// <returns></returns>
        public IList<IWebElement> GetColumns(int row)
        {
            IList<IWebElement> columns = rows[row].FindElements(By.TagName("td"));
            return columns;
        }

        public IWebElement GetElement(int row, int column)
        {
            if (row <= 0) throw new Exception("To check headers you must use getHeaders Method");

            string xpath = String.Format(".//tr[{0}]//td[{1}]", row, column);
            return element.FindElement(By.XPath(xpath));
        }


        public ReadOnlyCollection<IWebElement> GetElements(int row, int column)
        {
            if (row <= 0) throw new Exception("To check headers you must use getHeaders Method");

            string xpath = String.Format(".//tr[{0}]//td[{1}]", row, column);
            return element.FindElements(By.XPath(xpath));
        }

        public Dictionary<int, IWebElement> SearchInColumn(int column, string keyword)
        {
            Dictionary<int, IWebElement> dict = new Dictionary<int, IWebElement>();
            int nmbrRows = rows.Count;
            IWebElement cell;
            for (int i = 1; i < nmbrRows; i++)
            {
                string xpath = String.Format(".//td[{0}]", column);
                cell = rows[i].FindElement(By.XPath(xpath));

                if (cell.Text.Equals(keyword))
                {
                    dict.Add(i, cell);
                }
            }

            return dict;
        }

        public int IndexOfColumn(string header)
        {

            IList<IWebElement> headers = rows[0].FindElements(header_Xpath);
            int i = 0;
            while (i < headers.Count && !header.Equals(headers[i].Text))
            {
                i++;
            }
            return i == header.Length ? -1 : i + 1;
        }


        public int GetRowCount { get { return rows.Count; } }
    }
}
