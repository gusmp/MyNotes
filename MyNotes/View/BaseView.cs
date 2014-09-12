using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyNotes.View
{
    public class BaseView : PhoneApplicationPage
    {
        protected void GoBack()
        {
            NavigationService.Navigate(new Uri("/View/NoteListView.xaml", UriKind.Relative));
        }
    }
}
