using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialCommands
{
    public class MySerialReader : IDisposable
    {
        private SerialPort serialPort;
        private Queue<byte> recievedData = new Queue<byte>();

        public MySerialReader(int portNum)
        {
            if (portNum <= 0)
            {
                throw new ArgumentOutOfRangeException("portNum", "Port number was 0 or below. FIX IT, DAMNIT!");
            }

            serialPort = new SerialPort("COM" + portNum.ToString(), 9600);
            serialPort.Open();

            serialPort.DataReceived += serialPort_DataReceived;
        }

        void serialPort_DataReceived(object s, SerialDataReceivedEventArgs e)
        {
            byte[] data = new byte[serialPort.BytesToRead];
            serialPort.Read(data, 0, data.Length);

            data.ToList().ForEach(b => recievedData.Enqueue(b));

            foreach (byte com in data) Console.WriteLine(com);
            // processData();
        }

        void processData()
        {
            // Determine if we have a "packet" in the queue
            if (recievedData.Count > 50)
            {
                var packet = Enumerable.Range(0, 50).Select(i => recievedData.Dequeue());
            }
        }

        public void Dispose()
        {
            if (serialPort != null)
                serialPort.Dispose();
        }
    }
}
