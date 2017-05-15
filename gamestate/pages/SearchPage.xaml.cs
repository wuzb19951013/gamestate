using gamestate.models;
using System;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上有介绍

namespace gamestate.pages
{

    public sealed partial class SearchPage : Page
    {

        static string GameUrl="",GameCover="";
        public SearchPage()
        {
            this.InitializeComponent();
            var task = ContactSampleDataSource.CreateContactSampleDataAsync();
        }
        private void asb_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // We only want to get results when it was a user typing, 
            // otherwise we assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {

                var matchingContacts = ContactSampleDataSource.GetMatchingContacts(sender.Text);
                sender.ItemsSource = matchingContacts.ToList();
            }
        }
        private void asb_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item, take an action on it here
                SelectContact((Contact)args.ChosenSuggestion);
            }
            else
            {
                // Do a fuzzy search on the query text

                var matchingContacts = ContactSampleDataSource.GetMatchingContacts(args.QueryText);

                // Choose the first match, or clear the selection if there are no matches.
                SelectContact(matchingContacts.FirstOrDefault());
            }
        }

        /// <summary>
        /// This event gets fired as the user keys through the list, or taps on a suggestion.
        /// This allows you to change the text in the TextBox to reflect the item in the list.
        /// Alternatively you can use TextMemberPath.
        /// </summary>
        /// <param name="sender">The AutoSuggestBox that fired the event.</param>
        /// <param name="args">The args contain SelectedItem, which contains the data item of the item that is currently highlighted.</param>
        private void asb_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            var contact = (Contact)args.SelectedItem;

            sender.Text = contact.Title;
        }

        /// <summary>
        /// Display details of the specified contact.
        /// </summary>
        /// <param name="contact"></param>
        private void SelectContact(Contact contact)
        {
            if (contact != null)
            {
                NoResults.Visibility = Visibility.Collapsed;
                //ContactDetails.Visibility = Visibility.Visible;
                ContactTitle.Text = contact.Title;
                Rating.Visibility = Visibility.Visible;
                Random rnd = new Random();

                ratingbar.RatingValue = rnd.Next(3,5);
                GameCover = contact.Cover;
                ContactCover.Source = new BitmapImage(new Uri(contact.Cover));
                GameUrl = contact.Source;
                asb.Visibility = Visibility.Collapsed;
            }
            else
            {
                NoResults.Visibility = Visibility.Visible;
                //ContactDetails.Visibility = Visibility.Collapsed;
            }
        }



        private void GameClick(object sender, RoutedEventArgs e)
        {
            //this.Frame.Navigate(typeof(About));
            this.Frame.Navigate(typeof(webgameview), GameUrl);
        }
        private void CleClick(object sender, RoutedEventArgs e)
        {
            if (App.UserData.CurrentInstance.Collections.Count > 0)
            {
                if (App.UserData.CurrentInstance.Collections[App.UserData.CurrentInstance.Collections.Count - 1].Title != ContactTitle.Text)
                {
                    App.UserData.CurrentInstance.Collections.Add(new Game { Title = ContactTitle.Text, Coverimage = GameCover, Sourse = GameUrl });
                }
            }
            else
            {
                App.UserData.CurrentInstance.Collections.Add(new Game { Title = ContactTitle.Text, Coverimage = GameCover, Sourse = GameUrl });
            }
        }
    }
}
