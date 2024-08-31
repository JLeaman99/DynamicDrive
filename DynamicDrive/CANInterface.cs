using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using OBD.NET;
using OBD.NET.Communication;
using OBD.NET.Devices;
using OBD.NET.Logging;
using OBD.NET.OBDData;

namespace DynamicDrive
{
    internal class CANInterface
    {
        String comPort;
        SerialConnection connection;
        ELM327 car;

        public CarData carData;
        public int engineRPM, engineRPMRaw, Speed, SpeedRaw;
        public byte IOBData;
        public CANInterface() 
        {
            comPort = "COM5"; //COM5 Left USB 3, COM6 RIGHT BOTTOM USB, COM7 RIGHT TOP USB
            connection = new SerialConnection(comPort);
            car  = new ELM327(connection, new OBDConsoleLogger(OBDLogLevel.Debug));
            car.Initialize();
            carData = new CarData();
        }   


        public void CANRead()
        {

            car.SubscribeDataReceived<EngineRPM>((sender, data) => carData.EngineRPM = data.Data);
            car.SubscribeDataReceived<VehicleSpeed>((sender, data) => carData.VehicleSpeed = data.Data);
            car.SubscribeDataReceived<IOBDData>((sender, data) => carData.data = data.Data);

          
        }

        public void CANWrite(String entry)
        {

        }

        public async Task CANReadAsync()
        {

            while (true)
            {
                EngineRPM engineRpm = await car.RequestDataAsync<EngineRPM>();

                VehicleSpeed vehicleSpeed = await car.RequestDataAsync<VehicleSpeed>();

                carData.EngineRPM = engineRpm;
                carData.VehicleSpeed = vehicleSpeed;    
                Thread.Sleep(100);
            }

        }
   


        public async void CANMonitor()
        {
            /**
             * This Will be the Main thread to monitor CAN Network for changes in Speed, Steering, Gearing, Other Telemetry to cause changes in Music
             */
            await Task.Run(async () => await this.CANReadAsync());
        }

        public int ChangeTune()
        {
            int Param = 0;
            //TODO Interface w CANMonitor to check if dynamic sounds should be changed due to thresholds. EG going from 1st to 2nd, <50kph to >50kph, etc
            
            return Param;
        }


    }


    public class CarData
    {
       public EngineRPM EngineRPM;
        public VehicleSpeed VehicleSpeed;
        public IOBDData data = null;
        //ADD Other data Types as needed

        public override string ToString()
        {

            if(data != null)
                return String.Format("Engine RPM: {0}, Vehicle Speed {1}, OBD2 Raw Data {2}", EngineRPM.ToString(), VehicleSpeed.ToString(), data.ToString());

            return String.Format("Engine RPM: {0}, Vehicle Speed {1}", EngineRPM.ToString(), VehicleSpeed.ToString());

        }
    }
}
