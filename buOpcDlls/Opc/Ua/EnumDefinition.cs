// Decompiled with JetBrains decompiler
// Type: Opc.Ua.EnumDefinition
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class EnumDefinition : DataTypeDefinition
{
  private EnumFieldCollection m_fields;

  public EnumDefinition() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_fields = new EnumFieldCollection();

  [DataMember(Name = "Fields", IsRequired = false, Order = 1)]
  public EnumFieldCollection Fields
  {
    get => this.m_fields;
    set
    {
      this.m_fields = value;
      if (value != null)
        return;
      this.m_fields = new EnumFieldCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.EnumDefinition;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EnumDefinition_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EnumDefinition_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.EnumDefinition_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("Fields", (IList<IEncodeable>) this.Fields.ToArray(), typeof (EnumField));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Fields = (EnumFieldCollection) (EnumField[]) decoder.ReadEncodeableArray("Fields", typeof (EnumField));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is EnumDefinition enumDefinition && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_fields, (object) enumDefinition.m_fields) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (EnumDefinition) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    EnumDefinition enumDefinition = (EnumDefinition) base.MemberwiseClone();
    enumDefinition.m_fields = (EnumFieldCollection) Utils.Clone((object) this.m_fields);
    return (object) enumDefinition;
  }

  public bool IsOptionSet { get; set; }
}
