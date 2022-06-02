﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace Typingcom2
{
    class thingsorwhatever
    {
        public static int typingSpeed { get; set; } = 5;
        public static bool godMode { get; set; } = false;
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (!thingsorwhatever.godMode && !App.isCheatRunning)
            {
                int change = Convert.ToInt32(e.NewValue);
                int total = Convert.ToInt32(cheatTypeSpeedSlider.Maximum + cheatTypeSpeedSlider.Minimum);
                thingsorwhatever.typingSpeed = total - change;
            }
            webview2.Focus();
        }

        async private void Button_Click(object sender, RoutedEventArgs e)
        {
            await webview2.ExecuteScriptAsync("if(document.getElementsByClassName('raceChat').length?false:true){z=document.getElementsByClassName('letter');m='';for(let i=0;i<z.length;i++){m=m+z[i].innerText};window.chrome.webview.postMessage(''+m);}else{window.chrome.webview.postMessage('GAME_NOT_STARTED_ERROR');}");
            webview2.Focus();
        }

        private void Webview2_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            webview2.Focus();
            if (!App.isCheatRunning)
            {
                string browserData = e.TryGetWebMessageAsString();
                if (browserData == "GAME_NOT_STARTED_ERROR")
                {
                    MessageBox.Show("No Letters Detected.", "NitroType AutoTyper", MessageBoxButton.OK);
                }
                else
                {
                    App.simulateTypingText(browserData, thingsorwhatever.typingSpeed);
                }
            }
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (App.isCheatRunning)
            {
                webview2.Focus();
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (!App.isCheatRunning)
            {
                thingsorwhatever.typingSpeed = 0;
                thingsorwhatever.godMode = true;
            }
            webview2.Focus();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (!App.isCheatRunning)
            {
                thingsorwhatever.typingSpeed = Convert.ToInt32(cheatTypeSpeedSlider.Value);
                thingsorwhatever.godMode = false;
            }
            webview2.Focus();
        }

        private void Button_Click_stop(object sender, RoutedEventArgs e)
        {
            App.cheatFinished = true;
            webview2.Focus();
        }
    }
}
