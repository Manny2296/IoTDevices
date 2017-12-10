using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Devices.Enumeration;
using Windows.Devices.Gpio;
using Windows.Devices.I2c;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPIoTDevice
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        CancellationTokenSource cts;
        private GpioPin _inGpioPin;
        int stop = 0;

        private I2cDevice _converter;

        public MainPage()
        {
            this.InitializeComponent();


        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            await InitializeAsync();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            stop = 0;
            int i = 0;
            cts = new CancellationTokenSource();
            //while (i < 10)
            //{
                sendMessage();
            textBlock1_Copy.Visibility = Visibility.Visible;
              i++;
            //}
           
           
        
        }
        private async void sendMessage()
        {
            var number = int.Parse(textBox.Text);
            await SendDeviceToCloudMessageAsync(number);
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            stop = 1;
        }

        public async Task SendDeviceToCloudMessageAsync(int number)
        {
            var deviceClient = DeviceClient.CreateFromConnectionString("HostName=IOTprufinl.azure-devices.net;DeviceId=RPI;SharedAccessKey=lAgoMWfbhYuRQTmGM1gzQO2KTPmMOVua0cJEihqhycE=",TransportType.Amqp);
            int i = 0;

           while (i < number)
            {
                var participant = new Participant
                {
                    Position = new Random().Next(1, 10),
                    Count = new Random().Next(0, 1000)
                };

                var message = new Message(
                    Encoding.UTF8.GetBytes(
                        JsonConvert.SerializeObject(participant)
                    ));

                await deviceClient.SendEventAsync(message);

                textBlock1_Copy.Visibility = Visibility.Collapsed;

               i++;
           }
        }
        private async Task InitializeAsync()
        {
            var i2CSettings = new I2cConnectionSettings(0x48)
            {
                BusSpeed = I2cBusSpeed.FastMode,
                SharingMode = I2cSharingMode.Shared
            };
            var i2C1 = I2cDevice.GetDeviceSelector("I2C1");
            var devices = await DeviceInformation.FindAllAsync(i2C1);
            _converter = await I2cDevice.FromIdAsync(devices[0].Id, i2CSettings);
            //_converter.Write(new byte[] { 0x01, 0xc4, 0xe0 });
            //_converter.Write(new byte[] { 0x02, 0x00, 0x00 });
            //_converter.Write(new byte[] { 0x03, 0xff, 0xff });
            var gpio = GpioController.GetDefault();
            _inGpioPin = gpio.OpenPin(27);
            _inGpioPin.ValueChanged += InGpioPinOnValueChanged;
        }
        private async void InGpioPinOnValueChanged(GpioPin sender, GpioPinValueChangedEventArgs args)
        {
            var number = int.Parse(textBox.Text);
            await SendDeviceToCloudMessageAsync(number);


        }
    }
}
