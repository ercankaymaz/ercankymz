// Decompiled with JetBrains decompiler
// Type: Opc.Ua.UABinaryFileDataType
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
public class UABinaryFileDataType : DataTypeSchemaHeader
{
  private string m_schemaLocation;
  private KeyValuePairCollection m_fileHeader;
  private Variant m_body;

  public UABinaryFileDataType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_schemaLocation = (string) null;
    this.m_fileHeader = new KeyValuePairCollection();
    this.m_body = Variant.Null;
  }

  [DataMember(Name = "SchemaLocation", IsRequired = false, Order = 1)]
  public string SchemaLocation
  {
    get => this.m_schemaLocation;
    set => this.m_schemaLocation = value;
  }

  [DataMember(Name = "FileHeader", IsRequired = false, Order = 2)]
  public KeyValuePairCollection FileHeader
  {
    get => this.m_fileHeader;
    set
    {
      this.m_fileHeader = value;
      if (value != null)
        return;
      this.m_fileHeader = new KeyValuePairCollection();
    }
  }

  [DataMember(Name = "Body", IsRequired = false, Order = 3)]
  public Variant Body
  {
    get => this.m_body;
    set => this.m_body = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.UABinaryFileDataType;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UABinaryFileDataType_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UABinaryFileDataType_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.UABinaryFileDataType_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("SchemaLocation", this.SchemaLocation);
    encoder.WriteEncodeableArray("FileHeader", (IList<IEncodeable>) this.FileHeader.ToArray(), typeof (KeyValuePair));
    encoder.WriteVariant("Body", this.Body);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.SchemaLocation = decoder.ReadString("SchemaLocation");
    this.FileHeader = (KeyValuePairCollection) (KeyValuePair[]) decoder.ReadEncodeableArray("FileHeader", typeof (KeyValuePair));
    this.Body = decoder.ReadVariant("Body");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is UABinaryFileDataType binaryFileDataType && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_schemaLocation, (object) binaryFileDataType.m_schemaLocation) && Utils.IsEqual((object) this.m_fileHeader, (object) binaryFileDataType.m_fileHeader) && Utils.IsEqual((object) this.m_body, (object) binaryFileDataType.m_body) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (UABinaryFileDataType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    UABinaryFileDataType binaryFileDataType = (UABinaryFileDataType) base.MemberwiseClone();
    binaryFileDataType.m_schemaLocation = (string) Utils.Clone((object) this.m_schemaLocation);
    binaryFileDataType.m_fileHeader = (KeyValuePairCollection) Utils.Clone((object) this.m_fileHeader);
    binaryFileDataType.m_body = (Variant) Utils.Clone((object) this.m_body);
    return (object) binaryFileDataType;
  }
}
