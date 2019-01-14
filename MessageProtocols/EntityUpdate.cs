// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: Server/EntityUpdate.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
namespace MessageProtocols.Server {

  /// <summary>Holder for reflection information generated from Server/EntityUpdate.proto</summary>
  public static partial class EntityUpdateReflection {

    #region Descriptor
    /// <summary>File descriptor for Server/EntityUpdate.proto</summary>
    public static pbr::FileDescriptor Descriptor {
      get { return descriptor; }
    }
    private static pbr::FileDescriptor descriptor;

    static EntityUpdateReflection() {
      byte[] descriptorData = global::System.Convert.FromBase64String(
          string.Concat(
            "ChlTZXJ2ZXIvRW50aXR5VXBkYXRlLnByb3RvEgZzZXJ2ZXIiRQoMRW50aXR5",
            "VXBkYXRlEhEKCWVudGl0eV9pZBgBIAEoBRIUCgxjb21wb25lbnRfaWQYAiAB",
            "KAUSDAoEaW5mbxgDIAEoDEIaqgIXTWVzc2FnZVByb3RvY29scy5TZXJ2ZXJi",
            "BnByb3RvMw=="));
      descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
          new pbr::FileDescriptor[] { },
          new pbr::GeneratedClrTypeInfo(null, new pbr::GeneratedClrTypeInfo[] {
            new pbr::GeneratedClrTypeInfo(typeof(global::MessageProtocols.Server.EntityUpdate), global::MessageProtocols.Server.EntityUpdate.Parser, new[]{ "EntityId", "ComponentId", "Info" }, null, null, null)
          }));
    }
    #endregion

  }
  #region Messages
  /// <summary>
  ///7
  /// </summary>
  public sealed partial class EntityUpdate : pb::IMessage<EntityUpdate> {
    private static readonly pb::MessageParser<EntityUpdate> _parser = new pb::MessageParser<EntityUpdate>(() => new EntityUpdate());
    private pb::UnknownFieldSet _unknownFields;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pb::MessageParser<EntityUpdate> Parser { get { return _parser; } }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public static pbr::MessageDescriptor Descriptor {
      get { return global::MessageProtocols.Server.EntityUpdateReflection.Descriptor.MessageTypes[0]; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    pbr::MessageDescriptor pb::IMessage.Descriptor {
      get { return Descriptor; }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EntityUpdate() {
      OnConstruction();
    }

    partial void OnConstruction();

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EntityUpdate(EntityUpdate other) : this() {
      entityId_ = other.entityId_;
      componentId_ = other.componentId_;
      info_ = other.info_;
      _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public EntityUpdate Clone() {
      return new EntityUpdate(this);
    }

    /// <summary>Field number for the "entity_id" field.</summary>
    public const int EntityIdFieldNumber = 1;
    private int entityId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int EntityId {
      get { return entityId_; }
      set {
        entityId_ = value;
      }
    }

    /// <summary>Field number for the "component_id" field.</summary>
    public const int ComponentIdFieldNumber = 2;
    private int componentId_;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int ComponentId {
      get { return componentId_; }
      set {
        componentId_ = value;
      }
    }

    /// <summary>Field number for the "info" field.</summary>
    public const int InfoFieldNumber = 3;
    private pb::ByteString info_ = pb::ByteString.Empty;
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public pb::ByteString Info {
      get { return info_; }
      set {
        info_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override bool Equals(object other) {
      return Equals(other as EntityUpdate);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public bool Equals(EntityUpdate other) {
      if (ReferenceEquals(other, null)) {
        return false;
      }
      if (ReferenceEquals(other, this)) {
        return true;
      }
      if (EntityId != other.EntityId) return false;
      if (ComponentId != other.ComponentId) return false;
      if (Info != other.Info) return false;
      return Equals(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override int GetHashCode() {
      int hash = 1;
      if (EntityId != 0) hash ^= EntityId.GetHashCode();
      if (ComponentId != 0) hash ^= ComponentId.GetHashCode();
      if (Info.Length != 0) hash ^= Info.GetHashCode();
      if (_unknownFields != null) {
        hash ^= _unknownFields.GetHashCode();
      }
      return hash;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public override string ToString() {
      return pb::JsonFormatter.ToDiagnosticString(this);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void WriteTo(pb::CodedOutputStream output) {
      if (EntityId != 0) {
        output.WriteRawTag(8);
        output.WriteInt32(EntityId);
      }
      if (ComponentId != 0) {
        output.WriteRawTag(16);
        output.WriteInt32(ComponentId);
      }
      if (Info.Length != 0) {
        output.WriteRawTag(26);
        output.WriteBytes(Info);
      }
      if (_unknownFields != null) {
        _unknownFields.WriteTo(output);
      }
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public int CalculateSize() {
      int size = 0;
      if (EntityId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(EntityId);
      }
      if (ComponentId != 0) {
        size += 1 + pb::CodedOutputStream.ComputeInt32Size(ComponentId);
      }
      if (Info.Length != 0) {
        size += 1 + pb::CodedOutputStream.ComputeBytesSize(Info);
      }
      if (_unknownFields != null) {
        size += _unknownFields.CalculateSize();
      }
      return size;
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(EntityUpdate other) {
      if (other == null) {
        return;
      }
      if (other.EntityId != 0) {
        EntityId = other.EntityId;
      }
      if (other.ComponentId != 0) {
        ComponentId = other.ComponentId;
      }
      if (other.Info.Length != 0) {
        Info = other.Info;
      }
      _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
    }

    [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
    public void MergeFrom(pb::CodedInputStream input) {
      uint tag;
      while ((tag = input.ReadTag()) != 0) {
        switch(tag) {
          default:
            _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
            break;
          case 8: {
            EntityId = input.ReadInt32();
            break;
          }
          case 16: {
            ComponentId = input.ReadInt32();
            break;
          }
          case 26: {
            Info = input.ReadBytes();
            break;
          }
        }
      }
    }

  }

  #endregion

}

#endregion Designer generated code
