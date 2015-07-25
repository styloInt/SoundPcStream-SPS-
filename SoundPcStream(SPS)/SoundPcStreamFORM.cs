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
using System.Threading;

namespace SoundPcStream_SPS_
{
    public partial class MainWindow : Form
    {
        Thread myServeurThread;

        private WaveInEvent recorder;
        private BufferedWaveProvider bufferedWaveProvider;
        private LoopBack savingWaveProvider;
        private WaveOut player;
        private bool isWriterDisposed = false;
        private WaveFileWriter writer;

        Serveur serv;

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


        private void startServeur_Click(object sender, EventArgs e)
        {
            startServeur.Enabled = false;
            string data = null;
            myServeurThread = new Thread(new ThreadStart(() =>
            {
                try
                {
                    this.Invoke((MethodInvoker)delegate() { errorPortL.Hide(); });
                    serv.StartListening(Convert.ToInt32(portTB.Text));
                    data = serv.recieve();
                    sendSourceList();
                    int deviceNumber = Convert.ToInt32(serv.recieve());
                    sendSong(deviceNumber);

                }
                catch (ArgumentException)
                {
                    //TODO : Gérer mieux ce genre d'érreurs
                    this.Invoke((MethodInvoker)delegate() { errorPortL.Show(); });//si erreur de port
                }
            }));
            
            try
            {
                myServeurThread.Start();
                //myServeurThread.Join();
            }
            catch (ThreadAbortException) { }
            //if(data != null)

        }

        private void stopServeur_Click(object sender, EventArgs e)
        {
            if (myServeurThread != null)
            {
                myServeurThread.Abort();//fonctionne pas car startListner bloquant
                serv = new Serveur();
            }
            startServeur.Enabled = true;
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

        private void sendSong(int deviceNumber)
        {
            //if (sourceList.SelectedItems.Count == 0) return;
            // set up the recorder
            recorder = new WaveInEvent();
            recorder.DataAvailable += SendDataAvaible;
            recorder.DeviceNumber = deviceNumber;
            recorder.WaveFormat = new WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

            // set up our signal chain
            bufferedWaveProvider = new BufferedWaveProvider(recorder.WaveFormat);

            recorder.StartRecording();
        }

        private void record_Click(object sender, EventArgs e)
        {
            int deviceNumber = sourceList.SelectedItems[0].Index;
            if (sourceList.SelectedItems.Count == 0) return;
            // set up the recorder
            recorder = new WaveInEvent();
            //recorder.DataAvailable += RecorderOnDataAvailable;
            recorder.DataAvailable += SendDataAvaible;
            recorder.DeviceNumber = deviceNumber;
            recorder.WaveFormat = new WaveFormat(44100, NAudio.Wave.WaveIn.GetCapabilities(deviceNumber).Channels);

            // set up our signal chain
            bufferedWaveProvider = new BufferedWaveProvider(recorder.WaveFormat);
            //writer = new WaveFileWriter("temp.wav", bufferedWaveProvider.WaveFormat);
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

        private void SendDataAvaible(object sender, WaveInEventArgs waveInEventArgs)
        {
            byte[] buffer = new byte[10000];
            if (waveInEventArgs.BytesRecorded > 0 && !isWriterDisposed && !serv.isClose())
                serv.send(waveInEventArgs.Buffer, waveInEventArgs.BytesRecorded);
            if (serv.isClose())
            {
                Dispose();
                startServeur_Click(null, null);
            }
        }

        private void sendSourceList()
        {
            sourceList.Invoke((MethodInvoker)delegate
            {
                foreach (ListViewItem source in sourceList.Items)
                {
                    if (serv == null)
                        return;
                    byte[] dataToSend = Encoding.UTF8.GetBytes(source.Text + "\n");
                    serv.send(dataToSend, dataToSend.Length);
                }
            });

            
            byte[] fin = Encoding.ASCII.GetBytes("<EOF>");
            serv.send(fin, fin.Length);
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
                //writer.Dispose();
                this.Invoke((MethodInvoker)delegate()
                {
                    record.Dispose();
                });
                
            }
        }

    }
}
