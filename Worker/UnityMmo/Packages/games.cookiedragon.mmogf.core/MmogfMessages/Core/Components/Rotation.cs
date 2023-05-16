using MessagePack;
namespace Mmogf.Core
{
    [MessagePackObject]
    public struct Rotation : IEntityComponent
    {

        public static Rotation Zero => new Rotation()
        {
            Heading = 0,
        };

        public const short ComponentId = 3;
        public short GetComponentId() => ComponentId;

        [Key(0)]
        public short Heading { get; set; }
    }
}