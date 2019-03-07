using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using LibLanScanner;
using LibInterface;


namespace SimpleGUI
{
    public partial class Form1 : Form
    {

        Device[] devices;

        public Form1()
        {
            InitializeComponent();
        }



        private void btn_devices_Click(object sender, EventArgs e)
        {

            progrBar_loading.Visible = true;

   
            devices = InterfaceInformation.GetDevices().ToArray();

            progrBar_loading.Visible = false;


            for (int i=0;i<devices.Length;i++)
            {
                ListViewItem item = new ListViewItem(
                    new string[] {
                        devices[i].DeviceName,
                        devices[i].ip.ToString(),
                        devices[i].MacAddress
                    });
                list_devices.Items.Add(item);
            }
        }

        private void btn_scan_Click(object sender, EventArgs e)
        {
            if (list_devices.FocusedItem == null)
            {
                MessageBox.Show("Choice an interface");
                return;
            }
            LanScanner scanner = new LanScanner(devices[list_devices.FocusedItem.Index]);
            list_hosts.Items.Clear();
            btn_scan.Enabled = false;
            btn_devices.Enabled = false;
            progrBar_loading.Visible = true;

            scanner.StartScanning( () =>
            {

                Invoke(new Action(() =>
                {
                    progrBar_loading.Visible = false;

                    foreach (LanScanner.NetworkHost x in scanner.GetUsers().Values)
                    {
                        ListViewItem item = new ListViewItem(new string[] { x.IP, x.MAC });
                        list_hosts.Items.Add(item);
                    }
                    btn_scan.Enabled = true ;
                    btn_devices.Enabled = true ;
                    progrBar_loading.Visible = false     ;
                }));
            });
        }

    


    }
}
