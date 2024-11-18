using MessagePack;
namespace Mmogf.Core.Contracts
{
    [MessagePackObject]
    public struct NothingInternal
    {
    }

    [MessagePackObject]
    public struct PlayerHeartbeatClient : IEntityComponent
    {

        public const short ComponentId = 6;
        public short GetComponentId() => ComponentId;

        [MessagePackObject]
        public struct RequestHeartbeat : ICommandBase<NothingInternal, NothingInternal>
        {
            public const short CommandId = 102;
            public short GetCommandId() => CommandId;


            [Key(0)]
            public NothingInternal? Request { get; set; }
            [Key(1)]
            public NothingInternal? Response { get; set; }

        }
    }
}