// Decompiled with JetBrains decompiler
// Type: Opc.Ua.TargetVariablesDataType
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
public class TargetVariablesDataType : SubscribedDataSetDataType
{
  private FieldTargetDataTypeCollection m_targetVariables;

  public TargetVariablesDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_targetVariables = new FieldTargetDataTypeCollection();

  [DataMember(Name = "TargetVariables", IsRequired = false, Order = 1)]
  public FieldTargetDataTypeCollection TargetVariables
  {
    get => this.m_targetVariables;
    set
    {
      this.m_targetVariables = value;
      if (value != null)
        return;
      this.m_targetVariables = new FieldTargetDataTypeCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.TargetVariablesDataType;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TargetVariablesDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TargetVariablesDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.TargetVariablesDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("TargetVariables", (IList<IEncodeable>) this.TargetVariables.ToArray(), typeof (FieldTargetDataType));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.TargetVariables = (FieldTargetDataTypeCollection) (FieldTargetDataType[]) decoder.ReadEncodeableArray("TargetVariables", typeof (FieldTargetDataType));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is TargetVariablesDataType variablesDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_targetVariables, (object) variablesDataType.m_targetVariables) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (TargetVariablesDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    TargetVariablesDataType variablesDataType = (TargetVariablesDataType) base.MemberwiseClone();
    variablesDataType.m_targetVariables = (FieldTargetDataTypeCollection) Utils.Clone((object) this.m_targetVariables);
    return (object) variablesDataType;
  }
}
