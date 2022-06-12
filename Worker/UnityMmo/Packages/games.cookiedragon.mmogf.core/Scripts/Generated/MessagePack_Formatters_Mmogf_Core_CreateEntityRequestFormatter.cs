// <auto-generated>
// THIS (.cs) FILE IS GENERATED BY MPC(MessagePack-CSharp). DO NOT CHANGE IT.
// </auto-generated>

#pragma warning disable 618
#pragma warning disable 612
#pragma warning disable 414
#pragma warning disable 168

#pragma warning disable SA1129 // Do not use default value type constructor
#pragma warning disable SA1200 // Using directives should be placed correctly
#pragma warning disable SA1309 // Field names should not begin with underscore
#pragma warning disable SA1312 // Variable names should begin with lower-case letter
#pragma warning disable SA1403 // File may only contain a single namespace
#pragma warning disable SA1649 // File name should match first type name

namespace MessagePack.Formatters.Mmogf.Core
{
    using global::System.Buffers;
    using global::MessagePack;

    public sealed class CreateEntityRequestFormatter : global::MessagePack.Formatters.IMessagePackFormatter<global::Mmogf.Core.CreateEntityRequest>
    {

        public void Serialize(ref global::MessagePack.MessagePackWriter writer, global::Mmogf.Core.CreateEntityRequest value, global::MessagePack.MessagePackSerializerOptions options)
        {
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            writer.WriteArrayHeader(5);
            formatterResolver.GetFormatterWithVerify<string>().Serialize(ref writer, value.EntityType, options);
            formatterResolver.GetFormatterWithVerify<global::Mmogf.Core.Position>().Serialize(ref writer, value.Position, options);
            formatterResolver.GetFormatterWithVerify<global::Mmogf.Core.Rotation>().Serialize(ref writer, value.Rotation, options);
            formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.Dictionary<int, byte[]>>().Serialize(ref writer, value.Components, options);
            formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.List<global::Mmogf.Core.Acl>>().Serialize(ref writer, value.Acls, options);
        }

        public global::Mmogf.Core.CreateEntityRequest Deserialize(ref global::MessagePack.MessagePackReader reader, global::MessagePack.MessagePackSerializerOptions options)
        {
            if (reader.TryReadNil())
            {
                throw new global::System.InvalidOperationException("typecode is null, struct not supported");
            }

            options.Security.DepthStep(ref reader);
            global::MessagePack.IFormatterResolver formatterResolver = options.Resolver;
            var length = reader.ReadArrayHeader();
            var __EntityType__ = default(string);
            var __Position__ = default(global::Mmogf.Core.Position);
            var __Rotation__ = default(global::Mmogf.Core.Rotation);
            var __Components__ = default(global::System.Collections.Generic.Dictionary<int, byte[]>);
            var __Acls__ = default(global::System.Collections.Generic.List<global::Mmogf.Core.Acl>);

            for (int i = 0; i < length; i++)
            {
                switch (i)
                {
                    case 0:
                        __EntityType__ = formatterResolver.GetFormatterWithVerify<string>().Deserialize(ref reader, options);
                        break;
                    case 1:
                        __Position__ = formatterResolver.GetFormatterWithVerify<global::Mmogf.Core.Position>().Deserialize(ref reader, options);
                        break;
                    case 2:
                        __Rotation__ = formatterResolver.GetFormatterWithVerify<global::Mmogf.Core.Rotation>().Deserialize(ref reader, options);
                        break;
                    case 3:
                        __Components__ = formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.Dictionary<int, byte[]>>().Deserialize(ref reader, options);
                        break;
                    case 4:
                        __Acls__ = formatterResolver.GetFormatterWithVerify<global::System.Collections.Generic.List<global::Mmogf.Core.Acl>>().Deserialize(ref reader, options);
                        break;
                    default:
                        reader.Skip();
                        break;
                }
            }

            var ____result = new global::Mmogf.Core.CreateEntityRequest(__EntityType__, __Position__, __Rotation__, __Components__, __Acls__);
            reader.Depth--;
            return ____result;
        }
    }
}

#pragma warning restore 168
#pragma warning restore 414
#pragma warning restore 618
#pragma warning restore 612

#pragma warning restore SA1129 // Do not use default value type constructor
#pragma warning restore SA1200 // Using directives should be placed correctly
#pragma warning restore SA1309 // Field names should not begin with underscore
#pragma warning restore SA1312 // Variable names should begin with lower-case letter
#pragma warning restore SA1403 // File may only contain a single namespace
#pragma warning restore SA1649 // File name should match first type name
