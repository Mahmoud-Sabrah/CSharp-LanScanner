﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using PcapDotNet;
using PcapDotNet.Core;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

using System.Text.RegularExpressions;
using System.Threading;


using LibInterface;
using PcapDotNet.Base;
using PcapDotNet.Packets;
using PcapDotNet.Packets.Ethernet;
using PcapDotNet.Packets.Arp;




namespace LibLanScanner
{
    public class LanScanner
    {

        public class NetworkHost
        {
            public  string IP;
            public  string MAC;
        }


   
        Device outputDevice;
        PacketCommunicator communicator;
        Dictionary<string,NetworkHost> Users;



        public LanScanner(Device outputDevice )
        {
            this.outputDevice = outputDevice;
            this.Users = new Dictionary<string, NetworkHost>();

        }

        public void StartScanning(Action callBack)
        {
            Users.Clear();

            if (communicator == null)
                communicator = outputDevice.NetworkDevice.Open(65536, PacketDeviceOpenAttributes.Promiscuous, 1000);


          

            ReceiveResposnes();
            SendingRequests(callBack);
            

        }



        async void SendingRequests(Action callBack)
        {
            int[] fromAddress = outputDevice.networkAddress.ToString().Split('.').Select(x => Convert.ToInt32(x)).ToArray();
            int[] toAddress = outputDevice.broadcasatAddress.ToString().Split('.').Select(x => Convert.ToInt32(x)).ToArray();


            await Task.Run(() =>
            {
                for (int a = fromAddress[0]; a <= toAddress[0]; a++)
                    for (int b = fromAddress[1]; b <= toAddress[1]; b++)
                        for (int c = fromAddress[2]; c <= toAddress[2]; c++)
                            for (int d = fromAddress[3] + 1; d < toAddress[3]; d++)
                            {
                                Thread.Sleep(20);
                                communicator.SendPacket(ArpGenerator(outputDevice.MacAddress, "ffffffffffff", IPAddress.Parse(outputDevice.ip.ToString()), IPAddress.Parse(a.ToString() + "." + b.ToString() + "." + c.ToString() + "." + d.ToString()), true));
                            }

                Thread.Sleep(2000);
                callBack();
            });

        }

        async void ReceiveResposnes()
        {
            await Task.Run(()=>
            {
               Packet pck;

                do
                {
                    PacketCommunicatorReceiveResult result = communicator.ReceivePacket(out pck);

              

                    switch (result)
                    {

                        case PacketCommunicatorReceiveResult.Timeout:
                            continue;
                        case PacketCommunicatorReceiveResult.Ok:
                            {

                                if (pck.DataLink.Kind != DataLinkKind.Ethernet) continue;
                                EthernetDatagram ed = pck.Ethernet;

                                if (ed.EtherType != EthernetType.Arp) continue;
                                ArpDatagram arppck = ed.Arp;

                                if (arppck.Operation != ArpOperation.Reply) continue;


                                if(Users.ContainsKey(ed.Source.ToString()))
                                {
                                    NetworkHost host = Users[ed.Source.ToString()];
                                    host.IP = arppck.SenderProtocolIpV4Address.ToString();

                                }
                                else
                                {
                                    Users.Add(ed.Source.ToString(), new NetworkHost { IP = arppck.SenderProtocolIpV4Address.ToString(), MAC = ed.Source.ToString() });
                                }

                                continue;
                            }

                        default:
                            throw new InvalidOperationException("The result " + result + " shoudl never be reached here");
                    }
                } while (true);
            });
        }



        public Dictionary<string, NetworkHost> GetUsers()
        {
            return Users;
        }

        Packet ArpGenerator(string SenderMacAddress, string DestinatonMacAddress, IPAddress SenderIpAddress, IPAddress DestinationIpAddress, bool isRequest)
        {


            SenderMacAddress = ValidMac(SenderMacAddress);
            DestinatonMacAddress = ValidMac(DestinatonMacAddress);


            EthernetLayer ethernetLayer =
                    new EthernetLayer
                    {
                        Source = new MacAddress(SenderMacAddress),
                        Destination = new MacAddress(DestinatonMacAddress),
                        EtherType = EthernetType.None,
                    };

            ArpLayer arpLayer =
                new ArpLayer
                {
                    ProtocolType = EthernetType.IpV4,
                    Operation = isRequest ? ArpOperation.Request : ArpOperation.Reply,
                    SenderHardwareAddress = SenderMacAddress.Split(':').Select(x => Convert.ToByte(x, 16)).ToArray().AsReadOnly(),
                    SenderProtocolAddress = SenderIpAddress.GetAddressBytes().AsReadOnly(),
                    TargetHardwareAddress = DestinatonMacAddress.Split(':').Select(x => Convert.ToByte(x, 16)).ToArray().AsReadOnly(),
                    TargetProtocolAddress = DestinationIpAddress.GetAddressBytes().AsReadOnly(),
                };

            PacketBuilder builder = new PacketBuilder(ethernetLayer, arpLayer);

            return builder.Build(DateTime.Now);

        }

        string ValidMac(string mac)
        {

            if (mac.Contains(":"))           //if Mac Address with this Format XX:XX:XX:XX:XX:XX
                return mac;
            else if (mac.Contains("-"))      //if Mac Address with this Format XX-XX-XX-XX-XX-XX
                return mac.Replace("-", ":");
            else                              //if Mac Address with this Format XXXXXXXXXXXX
            {
                return Regex.Replace(mac, ".{2}", "$0:").Substring(0, 17);
            }
        }

    }






       
}