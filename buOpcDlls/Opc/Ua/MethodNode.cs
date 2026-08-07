// Decompiled with JetBrains decompiler
// Type: Opc.Ua.MethodNode
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class MethodNode : InstanceNode, IMethod, ILocalNode, INode
{
  private bool m_executable;
  private bool m_userExecutable;

  public MethodNode() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_executable = true;
    this.m_userExecutable = true;
  }

  [DataMember(Name = "Executable", IsRequired = false, Order = 1)]
  public bool Executable
  {
    get => this.m_executable;
    set => this.m_executable = value;
  }

  [DataMember(Name = "UserExecutable", IsRequired = false, Order = 2)]
  public bool UserExecutable
  {
    get => this.m_userExecutable;
    set => this.m_userExecutable = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.MethodNode;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MethodNode_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MethodNode_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.MethodNode_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteBoolean("Executable", this.Executable);
    encoder.WriteBoolean("UserExecutable", this.UserExecutable);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Executable = decoder.ReadBoolean("Executable");
    this.UserExecutable = decoder.ReadBoolean("UserExecutable");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is MethodNode methodNode && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_executable, (object) methodNode.m_executable) && Utils.IsEqual((object) this.m_userExecutable, (object) methodNode.m_userExecutable) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (MethodNode) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    MethodNode methodNode = (MethodNode) base.MemberwiseClone();
    methodNode.m_executable = (bool) Utils.Clone((object) this.m_executable);
    methodNode.m_userExecutable = (bool) Utils.Clone((object) this.m_userExecutable);
    return (object) methodNode;
  }

  public MethodNode(ILocalNode source)
    : base(source)
  {
    this.NodeClass = NodeClass.Method;
    if (!(source is IMethod method))
      return;
    this.Executable = method.Executable;
    this.UserExecutable = method.UserExecutable;
  }

  public override bool SupportsAttribute(uint attributeId)
  {
    switch (attributeId)
    {
      case 21:
      case 22:
        return true;
      default:
        return base.SupportsAttribute(attributeId);
    }
  }

  protected override object Read(uint attributeId)
  {
    if (attributeId == 21U)
      return (object) this.m_executable;
    return attributeId != 22U ? base.Read(attributeId) : (object) this.m_userExecutable;
  }

  protected override ServiceResult Write(uint attributeId, object value)
  {
    if (attributeId != 21U)
    {
      if (attributeId != 22U)
        return base.Write(attributeId, value);
      this.m_userExecutable = (bool) value;
      return ServiceResult.Good;
    }
    this.m_executable = (bool) value;
    return ServiceResult.Good;
  }
}
