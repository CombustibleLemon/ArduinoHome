using System;
using System.IO;
using System.IO.Ports;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_Interfacing
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = "COM4";
            SerialPort port = new SerialPort(name, 9600);
            port.Open();
            byte[] buffer = new byte[1];

            while(true)
            {
                Console.Write(name + "> ");
                String str = Console.ReadLine();

                if (str.Equals("exit"))
                    break;

                port.WriteLine(str);

                Console.WriteLine("  Got this: " + port.ReadLine());
            }

            MySerialReader reader = new MySerialReader();
        }
    }

    public class MySerialReader : IDisposable
    {   
        private SerialPort serialPort;
        private Queue<byte> recievedData = new Queue<byte>();

        public MySerialReader()
        {
            serialPort = new SerialPort("COM4", 9600);
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

            /*
            // Determine if we have a "packet" in the queue
            if (recievedData.Count > 50)
            {
                var packet = Enumerable.Range(0, 50).Select(i => recievedData.Dequeue());
            }*/
        }

        public void Dispose()
        {
            if (serialPort != null)
                serialPort.Dispose();
        }
    }
}
