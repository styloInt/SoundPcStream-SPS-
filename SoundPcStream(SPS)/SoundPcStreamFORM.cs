using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NAudio;
using NAudio.Wave;
using SoundPcStream_SPS_.Connection;

namespace SoundPcStream_SPS_
{
    public partial class MainWindow : Form
    {

        private WaveIn recorder;
        private BufferedWaveProvider bufferedWaveProvider;
        private LoopBack savingWaveProvider;
        private WaveOut player;
        private bool isWriterDisposed = false;
        private WaveFileWriter writer;

        Serveur serv;

        private void startServeur_Click(object sender, EventArgs e)
        {
            try
            {
                errorPortL.Hide();
                serv.StartListening(Convert.ToInt32(portTB.Text));
            }
            catch(ArgumentException)
            {
                errorPortL.Show();
            }
            
        }

        public MainWindow()
        {
            InitializeComponent();
        }


        private void MainWindow_Load(object sender, EventArgs e)
        {
            serv = new Serveur();
            refresh_Click(null, null);

            ipAdressTB.Text = serv.getIpAdress();
            portTB.Text = serv.getPortValide() + "";
            errorPortL.Hide();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            List<WaveInCapabilities> sources = new List<WaveInCapabilities>();

            for (int i = 0; i < WaveIn.DeviceCount; i++)
                sources.Add(NAudio.Wave.WaveIn.GetCapabilities(i));

            sourceList.Items.Clear();

            foreach (var source in sources)
            {
                ListViewItem item = new ListViewItem(source.ProductName);
                item.SubItems.Add(new ListViewItem.ListViewSubItem(item, source.Channels.ToString()));
                sourceList.Items.Add(item);
            }
        }

        private void record_Click(object sender, EventArgs e)
        {
            int deviceNumber = sourceList.SelectedItems[0].Index;
            if (sourceList.SelectedItems.Count == 0) return;
            // set up the recorder
            recorder = new WaveIn();
            recorder.DataAvailable += RecorderOnDataAvailable;
            recorder.DeviceNumber = deviceNumber;
            recorder.WaveFormat = new WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

            // set up our signal chain
            bufferedWaveProvider = new BufferedWaveProvider(recorder.WaveFormat);
            writer = new WaveFileWriter("temp.wav", bufferedWaveProvider.WaveFormat);
            //savingWaveProvider = new LoopBack(bufferedWaveProvider, "temp.wav");

            recorder.StartRecording();
        
        }

        private void RecorderOnDataAvailable(object sender, WaveInEventArgs waveInEventArgs)
        {
            byte[] buffer = new byte[10000];
            if (waveInEventArgs.BytesRecorded > 0 && !isWriterDisposed)
                writer.Write(waveInEventArgs.Buffer, 0, waveInEventArgs.BytesRecorded);
            if (waveInEventArgs.BytesRecorded == 0)
                Dispose(); // auto-dispose in case users forget
        }

        private void stopRecord_Click(object sender, EventArgs e)
        {
            // stop recording
            recorder.StopRecording();
        }

        private void Dispose()
        {
            if (!isWriterDisposed)
            {
                isWriterDisposed = true;
                writer.Dispose();
            }
        }

    }
}
