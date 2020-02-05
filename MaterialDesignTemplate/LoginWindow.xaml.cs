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
using System.Text.RegularExpressions;
using MaterialDesignTemplate.Utilities;

namespace MaterialDesignTemplate
{
    /// <summary>
    /// ucLogin.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : UserControl
    {
        public LoginWindow()
        {
            InitializeComponent();

            SerialPortEx spe = new SerialPortEx(AppSetting.GetCommPort());

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            #region test001
            //string s = "I have a red car.";
            //string re = Regex.Replace(s, "^", "开头：");
            //string re2 = Regex.Replace(s, "$", "结尾。");

            //MessageBox.Show($"{re},{re2}");
            #endregion



            #region 正则表达式test002 判断字符串是否为数字
            //string pattern;
            //string s = txtTest.Text;
            ////string pattern = @"^-?\d+(\.\d+)?$";
            //pattern = "^[-+.]?[0-9]*[.]?[0-9]*$";
            //bool b=Regex.IsMatch(s, pattern);
            //MessageBox.Show($"{b}");
            #endregion 



        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"UserName:{cobUserName.Text},Password:{PasswordBox.Password},MD5:{Md5Helper.GetMD5(PasswordBox.Password)}.");
        }
    }
}
