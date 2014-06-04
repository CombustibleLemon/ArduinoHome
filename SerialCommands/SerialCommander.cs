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
        private SerialPort serialPort;
        private Queue<byte> recievedData = new Queue<byte>();

        public MySerial(int portNum)
        {
            if (portNum <= 0)
            {
                throw new ArgumentOutOfRangeException("portNum", "Port number was 0 or below. FIX IT, DAMNIT!");
            }

            serialPort = new SerialPort("COM" + portNum, 9600);
            serialPort.ReadTimeout = 10000;

            serialPort.Open();
        }

        public void Send(byte[] i)
        {
            serialPort.Write(Encoding.ASCII.GetString(i));
        }

        public string ProcessData()
        {
            string ascii = serialPort.ReadLine();
            return ascii;
        }

        public void Dispose()
        {
            if (serialPort != null)
                serialPort.Dispose();
        }
    }
}
