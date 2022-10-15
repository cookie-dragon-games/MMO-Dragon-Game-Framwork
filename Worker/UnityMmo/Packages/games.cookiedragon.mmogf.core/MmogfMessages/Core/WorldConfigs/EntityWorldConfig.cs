using MessagePack;
using Mmogf.Core;
using System.Collections.Generic;
namespace Mmogf.Core
{
    [MessagePackObject]
    public struct EntityWorldConfig : IMessage
    {
        [Key(0)]
        public string Name { get; set; }

        [Key(1)]
        public int EntityId { get; set; }
        [Key(2)]
        public Dictionary<short, byte[]> EntityData { get; set; }


        /* 
        _entityStore.Create("PlayerCreator", new Position() { X = 0, Z = 0 }, new List<Acl>()
            {
                new Acl() { ComponentId = Position.ComponentId, WorkerType = "Dragon-Worker" },
                new Acl() { ComponentId = Rotation.ComponentId, WorkerType = "Dragon-Worker" },
                new Acl() { ComponentId = PlayerCreator.ComponentId, WorkerType = "Dragon-Worker" },
                new Acl() { ComponentId = Acls.ComponentId, WorkerType = "Dragon-Worker" },
            }, additionalData: new Dictionary<int, byte[]>()
            {
                { PlayerCreator.ComponentId, MessagePack.MessagePackSerializer.Serialize(new PlayerCreator() { }) },
            });
         */

        public static EntityWorldConfig Create(string name, int entityId, Position position, Rotation rotation, List<Acl> acls, Dictionary<short, IEntityComponent> additionalData)
        {

            var data = new Dictionary<short, byte[]>();

            data[FixedVector3.ComponentId] = MessagePack.MessagePackSerializer.Serialize(position.ToFixedVector3());
            data[Rotation.ComponentId] = MessagePack.MessagePackSerializer.Serialize(rotation);
            data[Acls.ComponentId] = MessagePack.MessagePackSerializer.Serialize(new Acls() { AclList = acls });

            if(additionalData != null)
            {
                foreach(var dat in additionalData)
                {
                    data[dat.Key] = MessagePack.MessagePackSerializer.Serialize(dat.Value.GetType(), dat.Value);
                }
            }

            var entityData = new EntityWorldConfig()
            {
                Name = name,
                EntityId = entityId,
                EntityData = data,
            };

            return entityData;
        }

    }
}