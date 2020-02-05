using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.ComponentModel;

namespace MaterialDesignTemplate
{
    class AppSetting
    {
        public static string GetCommPort() => ConfigurationManager.AppSettings["CommPort"];



        //private string _OutputTextFile;
        //public string OutputTextFile
        //{
        //    get => this._OutputTextFile = (ConfigurationManager.AppSettings[nameof(OutputTextFile)]);
        //    set
        //    {
        //        _OutputTextFile = value;
        //        AddUpdateAppSettings(nameof(OutputTextFile), _OutputTextFile);
        //        this.OnPropertyChanged(nameof(OutputTextFile));
        //    }
        //}


        //private string _InputTextFile;
        //public string InputTextFile
        //{
        //    get => this._InputTextFile = (ConfigurationManager.AppSettings[nameof(InputTextFile)]);
        //    set
        //    {
        //        _InputTextFile = value;
        //        AddUpdateAppSettings(nameof(InputTextFile), _InputTextFile);
        //        this.OnPropertyChanged(nameof(InputTextFile));
        //    }
        //}


        private double _Opaticy;
        public double Opaticy
        {
            get => this._Opaticy = double.Parse(ConfigurationManager.AppSettings[nameof(Opaticy)].ToString());
            set
            {
                _Opaticy = value;
                AddUpdateAppSettings(nameof(Opaticy), _Opaticy.ToString());
                this.OnPropertyChanged(nameof(Opaticy));
            }
        }


        /// <summary>
        /// 修改配置文件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        void AddUpdateAppSettings(string key, string value)
        {
            try
            {
                var configFile = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var settings = configFile.AppSettings.Settings;
                if (settings[key] == null)
                {
                    settings.Add(key, value);
                }
                else
                {
                    settings[key].Value = value;
                }
                configFile.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection(configFile.AppSettings.SectionInformation.Name);
            }
            catch (ConfigurationErrorsException)
            {
                //Console.WriteLine("Error writing app settings");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
