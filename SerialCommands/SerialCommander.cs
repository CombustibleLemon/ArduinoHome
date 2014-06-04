using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommands
{
    public class MySerial : IDisposable
    {
        private SerialPort serialPort = new SerialPort("COM3", 9600);
        string portName;
        private Queue<byte> recievedData = new Queue<byte>();

        public MySerial(int portNum)
        {
            if (portNum <= 0)
            {
                throw new ArgumentOutOfRangeException("portNum", "Port number was 0 or below. FIX IT, DAMNIT!");
            }

            portName = "COM" + portNum;
        }

        public void Send(byte[] i)
        {
            //serialPort = new SerialPort(portName, 9600);
            //serialPort.ReadTimeout = 10000;

            if (!serialPort.IsOpen)
            {
                serialPort.Open();
            }
            serialPort.Write(Encoding.ASCII.GetString(i));
        }

        public string ProcessData()
        {
            string ascii = serialPort.ReadLine();
            serialPort.Close();
            return ascii;
        }

        public void Dispose()
        {
            if (serialPort != null)
                serialPort.Dispose();
        }
    }
}
