using System;
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
using System.IO;
using ByteBox.lib;

namespace ByteBox
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ManagedEncryptor encryptor;
        private string path { get => encryptor.path; set => encryptor.path = value; }
        private SampleText sampleText = new SampleText();

        public MainWindow()
        {
            InitializeComponent();
            encryptor = new ManagedEncryptor();
            DataContext = this;
            Binding pathBinding = new Binding( "Text" );
            pathBinding.Source = sampleText;
            tbPath.SetBinding( TextBlock.TextProperty, pathBinding );
            encryptor.path = "testencoding.ebb";
        }

        private void test(object sender, RoutedEventArgs e)
        {
            //encryptor
            Console.WriteLine( sampleText.Text );
        }

        private void load(object sender, RoutedEventArgs e)
        {
            Console.WriteLine("Loading...");

            if ( File.Exists( encryptor.path ) )
            {
                Console.WriteLine( "File exists" );
                var result = encryptor.decrypt();
                if ( result != EncryptionWrapper.VERIFICATION_ERROR )
                    Console.WriteLine( "Success!" );
                else
                    Console.WriteLine( "Verification Error" );
            }
            else
                Console.WriteLine( "File doesn't exist!" );
        }
    }
}
