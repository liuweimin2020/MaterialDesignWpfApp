using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialDesignTemplate
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        string[] LoadFormName = { "MainWindow.xaml", "TestWindow.xaml" };

        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            ReportUnhandledException(e.Exception);
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            this.DispatcherUnhandledException += new System.Windows.Threading.DispatcherUnhandledExceptionEventHandler(Application_DispatcherUnhandledException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            System.Diagnostics.Process[] myProcesses = System.Diagnostics.Process.GetProcessesByName("MaterialDesignTemplate");//获取指定的进程名   
            if (myProcesses.Length > 1) //如果可以获取到知道的进程名则说明已经启动
            {
                //MessageBox.Show("程序已经启动,不能重复运行！");
                Application.Current.Shutdown();             //关闭系统
            }
            else
            {
                string loadForm = ConfigurationManager.AppSettings["StartupForm"].ToString();
                if (LoadFormName.Contains(loadForm))
                {
                    Application.Current.StartupUri = new Uri(loadForm, UriKind.Relative);
                }
                else
                {
                    MessageBox.Show("系统配置文件错误，无法启动程序！", "警告", MessageBoxButton.OK, MessageBoxImage.Warning);
                    Application.Current.Shutdown();             //关闭系统
                }
            }
        }

        private void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ReportUnhandledException(e.ExceptionObject as Exception);
        }

        private void ReportUnhandledException(Exception ex)
        {
            EventLog.WriteEntry("UnhandledWPFException Application", ex.ToString(), EventLogEntryType.Error);
            MessageBox.Show("Unhandled Exception: " + ex.ToString());
            this.Shutdown();
        }


    }
}
