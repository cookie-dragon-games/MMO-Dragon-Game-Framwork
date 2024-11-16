using System.Runtime.Serialization;
namespace Mmogf.Servers.Contracts
{
    [DataContract]
    public struct PlayerHeartbeatServer : IEntityComponent
    {

        public const short ComponentId = 5;
        public short GetComponentId() => ComponentId;

        /// <summary>
        /// Once this has 3 missed we delete the player
        /// </summary>
        [DataMember(Order = 0)]
        public short MissedHeartbeats { get; set; }

    }
}