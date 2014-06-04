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
        public SerialPort serialPort;
        private Queue<byte> recievedData = new Queue<byte>();
        private int lastSent;

        public MySerial(int portNum)
        {
            if (portNum <= 0)
            {
                throw new ArgumentOutOfRangeException("portNum", "Port number was 0 or below. FIX IT, DAMNIT!");
            }

            serialPort = new SerialPort("COM" + portNum, 9600);

            serialPort.Open();

            serialPort.DataReceived += serialPort_DataReceived;
        }

        private void serialPort_DataReceived(object s, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[serialPort.BytesToRead];
            serialPort.Read(data, 0, data.Length);

            data.ToList().ForEach(b => recievedData.Enqueue(b));

            foreach (byte com in data) Console.WriteLine(com);
            // processData();
        }

        public void send(byte[] i)
        {
            serialPort.Write(System.Text.Encoding.ASCII.GetString(i));
        }

        private void processData()
        {
            
        }

        public void Dispose()
        {
            if (serialPort != null)
                serialPort.Dispose();
        }
    }
}
