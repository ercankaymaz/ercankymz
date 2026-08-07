// Decompiled with JetBrains decompiler
// Type: Opc.Ua.PublishedDataItemsDataType
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
public class PublishedDataItemsDataType : PublishedDataSetSourceDataType
{
  private PublishedVariableDataTypeCollection m_publishedData;

  public PublishedDataItemsDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_publishedData = new PublishedVariableDataTypeCollection();

  [DataMember(Name = "PublishedData", IsRequired = false, Order = 1)]
  public PublishedVariableDataTypeCollection PublishedData
  {
    get => this.m_publishedData;
    set
    {
      this.m_publishedData = value;
      if (value != null)
        return;
      this.m_publishedData = new PublishedVariableDataTypeCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.PublishedDataItemsDataType;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedDataItemsDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedDataItemsDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.PublishedDataItemsDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("PublishedData", (IList<IEncodeable>) this.PublishedData.ToArray(), typeof (PublishedVariableDataType));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.PublishedData = (PublishedVariableDataTypeCollection) (PublishedVariableDataType[]) decoder.ReadEncodeableArray("PublishedData", typeof (PublishedVariableDataType));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is PublishedDataItemsDataType dataItemsDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_publishedData, (object) dataItemsDataType.m_publishedData) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (PublishedDataItemsDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    PublishedDataItemsDataType dataItemsDataType = (PublishedDataItemsDataType) base.MemberwiseClone();
    dataItemsDataType.m_publishedData = (PublishedVariableDataTypeCollection) Utils.Clone((object) this.m_publishedData);
    return (object) dataItemsDataType;
  }
}
