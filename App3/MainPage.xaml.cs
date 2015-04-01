using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;

using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Background;
using DojoLib;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace App3
{
        /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    
    public sealed partial class MainPage : Page
    {
        private int magicNumb;
        private bool processing;
        DojoLib.MagicNumberCreator dojoObj;
        public MainPage()
        {
            this.InitializeComponent();
            dojoObj = new DojoLib.MagicNumberCreator();
            processing = false;
        }

        private void toggleScreen()
        {
            if (processing)
            {
                processing = false;
                button1.Content = "New Number";
                pBar.Visibility = Windows.UI.Xaml.Visibility.Collapsed;
                return;
            }
            else
            {
                processing = true;
                button1.Content = "Cancel";
                pBar.Visibility = Windows.UI.Xaml.Visibility.Visible;
                return;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            Task<int> task_t;
            if (processing == true) //Se estiver processando o magicNumber:
            {
                toggleScreen();
                return;
            }
            if (processing == false) //Se nao...
            {
                toggleScreen();
                await Task<int>.Run(() => magicNumb = dojoObj.CreateMagicNumber());
                if (processing == true) //Se o usuário não cancelou...
                {
                    magicNumbText.Text = magicNumb.ToString();
                    toggleScreen();
                }
                processing = false;
            }
            
        }

      
       
    }
}
