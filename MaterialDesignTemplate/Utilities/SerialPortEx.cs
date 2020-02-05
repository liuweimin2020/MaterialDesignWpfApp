using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;


namespace MaterialDesignTemplate
{
    class SerialPortEx
    {
        SerialPort sp;
        public bool PortIsOpen { get => sp.IsOpen; }
        //public byte[] DataReciving;

        public SerialPortEx(string portName, int baudRate=9600, Parity parity=Parity.None, int dataBits=8, StopBits stopBits=StopBits.One)
        {
            sp = new SerialPort();
            sp.BaudRate = baudRate;
            sp.Parity = parity;
            sp.DataBits = dataBits;
            sp.StopBits = stopBits;
            sp.PortName = portName;
            sp.WriteBufferSize = 512;
            sp.ReadBufferSize = 1024;
            sp.DataReceived += Sp_DataReceived;
        }

        private void Sp_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void PortOpen()
        {
            if (!sp.IsOpen)
            {
                sp.Open();
            }

        }

        public void PortClose()
        {
            if(sp.IsOpen)
            {
                sp.Close();
            }
        }

        public void SendData(string data)
        {
            sp.Write(data);
            
        }

        public int ReadData(byte[] buffer,int offset, int count)
        {
            return sp.Read(buffer, offset, count);
        }


    }
}
