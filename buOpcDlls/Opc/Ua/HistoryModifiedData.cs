// Decompiled with JetBrains decompiler
// Type: Opc.Ua.HistoryModifiedData
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
public class HistoryModifiedData : HistoryData
{
  private ModificationInfoCollection m_modificationInfos;

  public HistoryModifiedData() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_modificationInfos = new ModificationInfoCollection();

  [DataMember(Name = "ModificationInfos", IsRequired = false, Order = 1)]
  public ModificationInfoCollection ModificationInfos
  {
    get => this.m_modificationInfos;
    set
    {
      this.m_modificationInfos = value;
      if (value != null)
        return;
      this.m_modificationInfos = new ModificationInfoCollection();
    }
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.HistoryModifiedData;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryModifiedData_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryModifiedData_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.HistoryModifiedData_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("ModificationInfos", (IList<IEncodeable>) this.ModificationInfos.ToArray(), typeof (ModificationInfo));
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.ModificationInfos = (ModificationInfoCollection) (ModificationInfo[]) decoder.ReadEncodeableArray("ModificationInfos", typeof (ModificationInfo));
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is HistoryModifiedData historyModifiedData && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_modificationInfos, (object) historyModifiedData.m_modificationInfos) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (HistoryModifiedData) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    HistoryModifiedData historyModifiedData = (HistoryModifiedData) base.MemberwiseClone();
    historyModifiedData.m_modificationInfos = (ModificationInfoCollection) Utils.Clone((object) this.m_modificationInfos);
    return (object) historyModifiedData;
  }
}
