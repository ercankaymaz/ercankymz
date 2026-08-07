// Decompiled with JetBrains decompiler
// Type: Opc.Ua.GenericAttributes
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
public class GenericAttributes : NodeAttributes
{
  private GenericAttributeValueCollection m_attributeValues;

  public GenericAttributes() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_attributeValues = new GenericAttributeValueCollection();

  [DataMember(Name = "AttributeValues", IsRequired = false, Order = 1)]
  public GenericAttributeValueCollection AttributeValues
  {
    get => this.m_attributeValues;
    set
    {
      this.m_attributeValues = value;
      if (value != null)
        return;
      this.m_attributeValues = new GenericAttributeValueCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.GenericAttributes;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GenericAttributes_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GenericAttributes_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.GenericAttributes_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("AttributeValues", (IList<IEncodeable>) this.AttributeValues.ToArray(), typeof (GenericAttributeValue));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.AttributeValues = (GenericAttributeValueCollection) (GenericAttributeValue[]) decoder.ReadEncodeableArray("AttributeValues", typeof (GenericAttributeValue));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is GenericAttributes genericAttributes && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_attributeValues, (object) genericAttributes.m_attributeValues) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (GenericAttributes) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    GenericAttributes genericAttributes = (GenericAttributes) base.MemberwiseClone();
    genericAttributes.m_attributeValues = (GenericAttributeValueCollection) Utils.Clone((object) this.m_attributeValues);
    return (object) genericAttributes;
  }
}
