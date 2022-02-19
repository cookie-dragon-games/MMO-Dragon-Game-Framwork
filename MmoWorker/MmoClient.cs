﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Google.Protobuf;
using Lidgren.Network;
using MessageProtocols;
using MessageProtocols.Core;
using MessageProtocols.Server;

namespace MmoWorker
{
    public class MmoClient
    {
        public long ClientId { get; private set; }

        private NetClient s_client;

        public bool Connected => s_client.ConnectionStatus == NetConnectionStatus.Connected;
        public NetConnectionStatus Status => s_client.ConnectionStatus;

        public event Action<EntityInfo> OnEntityCreation;
        public event Action<EntityUpdate> OnEntityUpdate; 
        public event Action OnConnect;

        public event Action<string> OnLog;

        public MmoClient()
        {
            NetPeerConfiguration config = new NetPeerConfiguration("dragon-bingus");
            config.AutoFlushSendQueue = false;
            s_client = new NetClient(config);
            //_sync = new SynchronizationContext();
            //s_client.RegisterReceivedCallback(new SendOrPostCallback(GotMessage), _sync);

        }

        public void Connect(string host, short port)
        {
            s_client.Start();
            NetOutgoingMessage hail = s_client.CreateMessage("This is the hail message");
            s_client.Connect(host, port, hail);
        }

        public void Stop()
        {
            s_client.Disconnect("Requested by user");
        }

        public void Update()
        {
            GotMessage(s_client);
        }

        public void GotMessage(object peer)
        {
            NetIncomingMessage im;
            while ((im = s_client.ReadMessage()) != null)
            {
                // handle incoming message
                switch (im.MessageType)
                {
                    case NetIncomingMessageType.DebugMessage:
                    case NetIncomingMessageType.ErrorMessage:
                    case NetIncomingMessageType.WarningMessage:
                    case NetIncomingMessageType.VerboseDebugMessage:
                        string text = im.ReadString();
                        OnLog?.Invoke(text);
                        break;
                    case NetIncomingMessageType.StatusChanged:
                        NetConnectionStatus status = (NetConnectionStatus)im.ReadByte();

                        if (status == NetConnectionStatus.Connected)
                        {
                            OnLog?.Invoke("Client connected");
                            //if self
                            OnConnect?.Invoke();
                        }
                        else if (status == NetConnectionStatus.Disconnected)
                        {

                        }

                        string reason = im.ReadString();
                        OnLog(status.ToString() + ": " + reason);

                        break;
                    case NetIncomingMessageType.Data:
                        OnLog?.Invoke("Client " + s_client.UniqueIdentifier + " Data: " + BitConverter.ToString(im.Data));
                        var simpleData = SimpleMessage.Parser.ParseFrom(im.Data);
                        switch ((ServerCodes)simpleData.MessageId)
                        {
                            case ServerCodes.ClientConnect:
                                //ClientId = ClientConnect.Parser.ParseFrom(simpleData.Info).ClientId;w
                                //OnLog?.Invoke("My Client Id is " + ClientId);
                                OnLog?.Invoke("Client connected msg");
                                //OnConnect?.Invoke();
                                break;
                            case ServerCodes.GameData:
                                var gameData = GameData.Parser.ParseFrom(simpleData.Info);
                                OnLog?.Invoke($"Client Game Data: {BitConverter.ToString(gameData.Info.ToByteArray())}");

                                break;
                            case ServerCodes.EntityInfo:
                                var entityInfo = EntityInfo.Parser.ParseFrom(simpleData.Info);
                                OnLog?.Invoke($"Client Entity Info: {entityInfo.EntityId}");
                                foreach (var pair in entityInfo.EntityData)
                                {
                                    OnLog?.Invoke($"{pair.Key} {BitConverter.ToString(pair.Value.ToByteArray())}");
                                }

                                OnEntityCreation?.Invoke(entityInfo);
                                break;
                            case ServerCodes.EntityUpdate:
                                var entityUpdate = EntityUpdate.Parser.ParseFrom(simpleData.Info);

                                OnEntityUpdate?.Invoke(entityUpdate);

                                break;
                            default:
                                break;
                        }
                        break;
                    default:
                        OnLog?.Invoke("Unhandled type: " + im.MessageType + " " + im.LengthBytes + " bytes");
                        break;
                }
                s_client.Recycle(im);
            }
        }

        internal void Send(IMessage message)
        {
            NetOutgoingMessage om = s_client.CreateMessage();
            om.Write(message.ToByteArray());
            s_client.SendMessage(om, NetDeliveryMethod.UnreliableSequenced);
            s_client.FlushSendQueue();
        }

    }
}
