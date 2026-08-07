// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ReaderGroupDataType
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
public class ReaderGroupDataType : PubSubGroupDataType
{
  private ExtensionObject m_transportSettings;
  private ExtensionObject m_messageSettings;
  private DataSetReaderDataTypeCollection m_dataSetReaders;

  public ReaderGroupDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_transportSettings = (ExtensionObject) null;
    this.m_messageSettings = (ExtensionObject) null;
    this.m_dataSetReaders = new DataSetReaderDataTypeCollection();
  }

  [DataMember(Name = "TransportSettings", IsRequired = false, Order = 1)]
  public ExtensionObject TransportSettings
  {
    get => this.m_transportSettings;
    set => this.m_transportSettings = value;
  }

  [DataMember(Name = "MessageSettings", IsRequired = false, Order = 2)]
  public ExtensionObject MessageSettings
  {
    get => this.m_messageSettings;
    set => this.m_messageSettings = value;
  }

  [DataMember(Name = "DataSetReaders", IsRequired = false, Order = 3)]
  public DataSetReaderDataTypeCollection DataSetReaders
  {
    get => this.m_dataSetReaders;
    set
    {
      this.m_dataSetReaders = value;
      if (value != null)
        return;
      this.m_dataSetReaders = new DataSetReaderDataTypeCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ReaderGroupDataType;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReaderGroupDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReaderGroupDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ReaderGroupDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteExtensionObject("TransportSettings", this.TransportSettings);
    encoder.WriteExtensionObject("MessageSettings", this.MessageSettings);
    encoder.WriteEncodeableArray("DataSetReaders", (IList<IEncodeable>) this.DataSetReaders.ToArray(), typeof (DataSetReaderDataType));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.TransportSettings = decoder.ReadExtensionObject("TransportSettings");
    this.MessageSettings = decoder.ReadExtensionObject("MessageSettings");
    this.DataSetReaders = (DataSetReaderDataTypeCollection) (DataSetReaderDataType[]) decoder.ReadEncodeableArray("DataSetReaders", typeof (DataSetReaderDataType));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ReaderGroupDataType readerGroupDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_transportSettings, (object) readerGroupDataType.m_transportSettings) && Utils.IsEqual((object) this.m_messageSettings, (object) readerGroupDataType.m_messageSettings) && Utils.IsEqual((object) this.m_dataSetReaders, (object) readerGroupDataType.m_dataSetReaders) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ReaderGroupDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ReaderGroupDataType readerGroupDataType = (ReaderGroupDataType) base.MemberwiseClone();
    readerGroupDataType.m_transportSettings = (ExtensionObject) Utils.Clone((object) this.m_transportSettings);
    readerGroupDataType.m_messageSettings = (ExtensionObject) Utils.Clone((object) this.m_messageSettings);
    readerGroupDataType.m_dataSetReaders = (DataSetReaderDataTypeCollection) Utils.Clone((object) this.m_dataSetReaders);
    return (object) readerGroupDataType;
  }
}
