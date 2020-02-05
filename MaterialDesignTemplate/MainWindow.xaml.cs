
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
using System.Windows.Controls.Primitives;
using MaterialDesignThemes.Wpf;
using System.Diagnostics;
using System.Threading;

namespace MaterialDesignTemplate
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static Snackbar Snackbar;
        //public static PaletteSelector2 palette;
        public MainWindow()
        {
            InitializeComponent();

            //ViewItem vi = new ViewItem("登录测试", new Uri("LoginWindow", UriKind.Relative));
            //ViewItemsListBox.DataContext = vi;

            Task.Factory.StartNew(() =>
            {
                Thread.Sleep(1500);
            }).ContinueWith(t =>
            {
                //note you can use the message queue from any thread, but just for the demo here we 
                //need to get the message queue from the snackbar, so need to be on the dispatcher
                MainSnackbar.MessageQueue.Enqueue("Welcome to Material Design In XAML Tookit");
            }, TaskScheduler.FromCurrentSynchronizationContext());

            DataContext = new MainWindowViewModel(MainSnackbar.MessageQueue);

            Snackbar = this.MainSnackbar;
            //DataContext = new MainWindowViewModel();
            //palette = new PaletteSelector2 { DataContext = new PaletteSelectorViewModel() };
            //tbTheme.DataContext = new PaletteSelectorViewModel();

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //sView.Content = new ViewItem("Palette", new PaletteSelector { DataContext = new PaletteSelectorViewModel() },
            //        new[]
            //        {
            //            DocumentationLink.WikiLink("Brush-Names", "Brushes"),
            //            DocumentationLink.WikiLink("Custom-Palette-Hues", "Custom Palettes"),
            //            DocumentationLink.WikiLink("Swatches-and-Recommended-Colors", "Swatches"),
            //            DocumentationLink.DemoPageLink<PaletteSelector>("Demo View"),
            //            DocumentationLink.DemoPageLink<PaletteSelectorViewModel>("Demo View Model"),
            //            DocumentationLink.ApiLink<PaletteHelper>()
            //        });
            


        }


        //private void showForm()
        //{
        //    TestWindow tw = new TestWindow();
        //    tw.Show();
        //}

        //private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    showForm();

        //}



        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            //until we had a StaysOpen glag to Drawer, this will help with scroll bars
            var dependencyObject = Mouse.Captured as DependencyObject;
            while (dependencyObject != null)
            {
                if (dependencyObject is ScrollBar) return;
                dependencyObject = VisualTreeHelper.GetParent(dependencyObject);
            }

            MenuToggleButton.IsChecked = false;
        }

        //private async void MenuPopupButton_OnClick(object sender, RoutedEventArgs e)
        //{
        //    var sampleMessageDialog = new SampleMessageDialog
        //    {
        //        Message = { Text = ((ButtonBase)sender).Content.ToString() }
        //    };

        //    await DialogHost.Show(sampleMessageDialog, "RootDialog");
        //}

        private void OnCopy(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter is string stringValue)
            {
                try
                {
                    Clipboard.SetDataObject(stringValue);
                }
                catch (Exception ex)
                {
                    Trace.WriteLine(ex.ToString());
                }
            }
        }

    }
}
