using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Enumeration;
using Windows.Devices.SerialCommunication;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Serial_Test_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        //SerialPort writer, reader;
        [DllImport("Serial_Test_CPP.dll")]
        public static extern int writer_connected();
        [DllImport("Serial_Test_CPP.dll")]
        public static extern int reader_connected();
        [DllImport("Serial_Test_CPP.dll")]
        public static extern int file_exists();
        int line = 1;
        public MainPage()
        {
            this.InitializeComponent();
            connect();
        }
        private void connect()
        {
            //writer = new SerialPort("COM1");
            //writer.Open();
            //reader = new SerialPort("COM2");
            //reader.Open();

        }

        private async void check_system_access()
        {
            bool result = await Windows.System.Launcher.LaunchUriAsync(new Uri("ms-settings:privacy-broadfilesystemaccess"));
            text_block.Text += result.ToString() + "\n";
        }
        private void btn_send_Click(object sender, RoutedEventArgs e)
        {
            text_block.Text += line.ToString() + ": " + "Writer Status: " + writer_connected().ToString() + " Reader Status: " + reader_connected().ToString() + "\n";
            text_block.Text += "File Exists: " + file_exists().ToString() + "\n";
            line += 1;
            //check_system_access();
        }
    }
}
