using System.Runtime.Serialization;
namespace Mmogf.Core.Contracts
{
    [DataContract]
    public struct NothingInternal
    {
    }

    [DataContract]
    public struct PlayerHeartbeatClient : IEntityComponent
    {

        public const short ComponentId = 6;
        public short GetComponentId() => ComponentId;

        [DataContract]
        public struct RequestHeartbeat : ICommandBase<NothingInternal, NothingInternal>
        {
            public const short CommandId = 102;
            public short GetCommandId() => CommandId;


            [DataMember(Order = 1)]
            public NothingInternal? Request { get; set; }
            [DataMember(Order = 2)]
            public NothingInternal? Response { get; set; }

        }
    }
}