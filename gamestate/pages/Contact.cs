using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace gamestate.pages
{
    public class Contact
    {
        public string Title { get; set; }
        public string Cover { get; set; }
        public string Source { get; set; }
        public string DisplayTitle { get { return Title; } }
    }

    public static class ContactSampleDataSource
    {
        private static List<Contact> _contacts = new List<Contact>();

        public static async Task CreateContactSampleDataAsync()
        {
            // Don't need to do this more than once.
            if (_contacts.Count > 0)
            {
                return;
            }

            StorageFile file = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///Assets/title.txt"));
            //title请使用utf-8编码格式
            IList<string> lines = await FileIO.ReadLinesAsync(file, Windows.Storage.Streams.UnicodeEncoding.Utf8);

            // Verify that it hasn't been done by someone else in the meantime.
            if (_contacts.Count == 0)
            {
                for (int i = 0; i < lines.Count; i++)
                {
                    _contacts.Add(new Contact() { Title = lines[i], Cover = lines[i + 1], Source = lines[i + 2] });
                }
            }
            _contacts = _contacts.OrderBy(c => c.DisplayTitle).ToList();
        }

        /// <summary>
        /// Do a fuzzy search on all contacts and order results based on a pre-defined rule set
        /// </summary>
        /// <param name="query">The part of the name or company to look for</param>
        /// <returns>An ordered list of contacts that matches the query</returns>
        public static IEnumerable<Contact> GetMatchingContacts(string query)
        {
            return ContactSampleDataSource._contacts
                .Where(c => c.Title.IndexOf(query, StringComparison.CurrentCultureIgnoreCase) > -1)
                .OrderByDescending(c => c.Title.StartsWith(query, StringComparison.CurrentCultureIgnoreCase));
        }
    }
}
