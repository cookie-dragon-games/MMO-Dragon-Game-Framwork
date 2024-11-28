using Mmogf.Core;
using Mmogf.Core.Contracts;
using Mmogf.Core.Contracts.Commands;
using Mmogf.Servers.Serializers;
using Mmogf.Servers.Shared;
using ProtoBuf;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using UnityEngine;

namespace Mmogf
{
    public static class MmogfStartup
    {
        [DataContract]
        class MessagePacket
        {
            [DataMember(Order = 1)]
            public int Header { get; set; }
            [DataMember(Order = 2)]
            public byte[] Payload { get; set; }
        }

        [DataContract]
        class Person
        {
            [DataMember(Order = 1)]
            public int Id { get; set; }
            [DataMember(Order = 2)]
            public string Name { get; set; }
        }

        static bool serializerRegistered = false;
        static bool setupRun = false;
        public static void RegisterSerializers()
        {
            if (serializerRegistered)
                return;

            serializerRegistered = true;

            var person1 = new Person()
            {
                Id = 2,
                Name = "Test",
            };

            var messagePacket = new MessagePacket()
            {
                Header = 5,
                Payload = Serialize(person1),
            };

            var serializedPacket = Serialize(messagePacket);
            var deserializedPacket = Deserialize<MessagePacket>(serializedPacket);

            var deserializedPerson = Deserialize<Person>(deserializedPacket.Payload);

            Debug.Log($"Packet: {deserializedPacket.Header}, Person:{deserializedPerson.Name}, {deserializedPerson.Id}");
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, person1);
                ms.Seek(0, SeekOrigin.Begin);
                var personD = Serializer.Deserialize<Person>(ms);

                Debug.Log($"Person:{personD.Name}, {personD.Id}");
            }
        }

        private static byte[] Serialize<T>(T obj)
        {
            using (var ms = new MemoryStream())
            {
                Serializer.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        private static T Deserialize<T>(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                return Serializer.Deserialize<T>(ms);
            }
        }

#if UNITY_EDITOR

        [UnityEditor.InitializeOnLoadMethod]
        static void EditorInitialize()
        {
            RegisterSerializers();
        }

#endif

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        public static void Initialize()
        {
            RegisterSerializers();
            if (!setupRun)
            {
                setupRun = true;

                PlayerCreatorHandler.CreatePlayer += CreatePlayer;

                LoadEntityComponentTypesList();
            }
        }

        static void LoadEntityComponentTypesList()
        {
            Dictionary<int, System.Type> types = new Dictionary<int, System.Type>();
            Dictionary<int, System.Type> commands = new Dictionary<int, System.Type>();
            Dictionary<int, System.Type> events = new Dictionary<int, System.Type>();
            //map components to ids
            //yay reflection!
            var type = typeof(IEntityComponent);
            var eventType = typeof(IEvent);
            var commandType = typeof(ICommand);
            var assemblies = System.AppDomain.CurrentDomain.GetAssemblies();
            for (int cnt = 0; cnt < assemblies.Length; cnt++)
            {
                var assembly = assemblies[cnt];
                var typesList = assembly.GetTypes();
                for (int i = 0; i < typesList.Length; i++)
                {
                    var t = typesList[i];
                    if (t.IsInterface)
                        continue;
                    if (type.IsAssignableFrom(t))
                    {
                        var component = (IEntityComponent)System.Activator.CreateInstance(t);
                        types.Add(component.GetComponentId(), t);
                    }
                    if (commandType.IsAssignableFrom(t))
                    {
                        var command = (ICommand)System.Activator.CreateInstance(t);
                        commands.Add(command.GetCommandId(), t);
                    }
                    if (eventType.IsAssignableFrom(t))
                    {
                        var evn = (IEvent)System.Activator.CreateInstance(t);
                        events.Add(evn.GetEventId(), t);
                    }
                }
            }

            ComponentMappings.Init(types, commands, events);
        }

        private static CreateEntityRequest CreatePlayer(ISerializer serializer, PlayerCreator.ConnectPlayer connect, CommandRequest request)
        {
            var clientId = request.Header.RequesterId;

            //pass in player id and load data at some point
            //connect.PlayerId;

            Debug.Log($"Creating Player {clientId}");

            var createEntity = new CreateEntityRequest("Player", new Position() { Y = 0, }.ToFixedVector3(), Rotation.Zero,
                new Dictionary<short, byte[]>()
                {
                    { Cannon.ComponentId, serializer.Serialize(new Cannon()) },
                    { Health.ComponentId, serializer.Serialize(new Health() { Current = 100, Max = 100, }) },
                    { ClientAuthCheck.ComponentId, serializer.Serialize(new ClientAuthCheck() {  WorkerId = clientId, }) },
                    { MovementState.ComponentId, serializer.Serialize(new MovementState() {  Forward = 0, Heading = 0, DesiredPosition = new Vector3d() { Y = 0, } }) },
                    { PlayerHeartbeatServer.ComponentId, serializer.Serialize(new PlayerHeartbeatServer() { MissedHeartbeats = 0 }) },
                    { PlayerHeartbeatClient.ComponentId, serializer.Serialize(new PlayerHeartbeatClient() { }) },
                },
                new List<Acl>()
                {
                    new Acl() { ComponentId = FixedVector3.ComponentId, WorkerType = "Dragon-Worker" },
                    new Acl() { ComponentId = Rotation.ComponentId, WorkerType = "Dragon-Worker" },
                    new Acl() { ComponentId = Acls.ComponentId, WorkerType = "Dragon-Worker" },
                    new Acl() { ComponentId = Cannon.ComponentId, WorkerType = "Dragon-Worker" },
                    new Acl() { ComponentId = Health.ComponentId, WorkerType = "Dragon-Worker" },
                    new Acl() { ComponentId = ClientAuthCheck.ComponentId, WorkerType = $"Dragon-Client", WorkerId = clientId, },
                    new Acl() { ComponentId = MovementState.ComponentId, WorkerType = $"Dragon-Client", WorkerId = clientId, },
                    new Acl() { ComponentId = PlayerHeartbeatServer.ComponentId, WorkerType = "Dragon-Worker" },
                    new Acl() { ComponentId = PlayerHeartbeatClient.ComponentId, WorkerType = $"Dragon-Client", WorkerId = clientId, },

                });

            return createEntity;
        }

        //#if UNITY_EDITOR


        //    [UnityEditor.InitializeOnLoadMethod]
        //    static void EditorInitialize()
        //    {
        //        Initialize();
        //    }

        //#endif
    }
}