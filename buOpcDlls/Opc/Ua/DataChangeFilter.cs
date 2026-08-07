// Decompiled with JetBrains decompiler
// Type: Opc.Ua.DataChangeFilter
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataChangeFilter : MonitoringFilter
{
  private DataChangeTrigger m_trigger;
  private uint m_deadbandType;
  private double m_deadbandValue;

  public DataChangeFilter() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_trigger = DataChangeTrigger.Status;
    this.m_deadbandType = 0U;
    this.m_deadbandValue = 0.0;
  }

  [DataMember(Name = "Trigger", IsRequired = false, Order = 1)]
  public DataChangeTrigger Trigger
  {
    get => this.m_trigger;
    set => this.m_trigger = value;
  }

  [DataMember(Name = "DeadbandType", IsRequired = false, Order = 2)]
  public uint DeadbandType
  {
    get => this.m_deadbandType;
    set => this.m_deadbandType = value;
  }

  [DataMember(Name = "DeadbandValue", IsRequired = false, Order = 3)]
  public double DeadbandValue
  {
    get => this.m_deadbandValue;
    set => this.m_deadbandValue = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.DataChangeFilter;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataChangeFilter_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataChangeFilter_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.DataChangeFilter_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEnumerated("Trigger", (Enum) this.Trigger);
    encoder.WriteUInt32("DeadbandType", this.DeadbandType);
    encoder.WriteDouble("DeadbandValue", this.DeadbandValue);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Trigger = (DataChangeTrigger) decoder.ReadEnumerated("Trigger", typeof (DataChangeTrigger));
    this.DeadbandType = decoder.ReadUInt32("DeadbandType");
    this.DeadbandValue = decoder.ReadDouble("DeadbandValue");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is DataChangeFilter dataChangeFilter && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_trigger, (object) dataChangeFilter.m_trigger) && Utils.IsEqual((object) this.m_deadbandType, (object) dataChangeFilter.m_deadbandType) && Utils.IsEqual((object) this.m_deadbandValue, (object) dataChangeFilter.m_deadbandValue) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (DataChangeFilter) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    DataChangeFilter dataChangeFilter = (DataChangeFilter) base.MemberwiseClone();
    dataChangeFilter.m_trigger = (DataChangeTrigger) Utils.Clone((object) this.m_trigger);
    dataChangeFilter.m_deadbandType = (uint) Utils.Clone((object) this.m_deadbandType);
    dataChangeFilter.m_deadbandValue = (double) Utils.Clone((object) this.m_deadbandValue);
    return (object) dataChangeFilter;
  }

  public ServiceResult Validate()
  {
    if ((int) this.DeadbandType >= 0 && (int) this.DeadbandType <= 2)
    {
      if (this.Trigger >= DataChangeTrigger.Status && this.Trigger <= DataChangeTrigger.StatusValueTimestamp)
      {
        if (this.DeadbandValue < 0.0)
          return ServiceResult.Create(2156789760U /*0x808E0000*/, "Deadband value '{0}' cannot be less than zero.", (object) this.DeadbandValue);
        if (this.DeadbandType != 2U || this.DeadbandValue <= 100.0)
          return ServiceResult.Good;
        return ServiceResult.Create(2156789760U /*0x808E0000*/, "Percentage deadband value '{0}' cannot be greater than 100.", (object) this.DeadbandValue);
      }
      return ServiceResult.Create(2156789760U /*0x808E0000*/, "Deadband trigger '{0}' is not recognized.", (object) this.Trigger);
    }
    return ServiceResult.Create(2156789760U /*0x808E0000*/, "Deadband type '{0}' is not recognized.", (object) this.DeadbandType);
  }

  public static double GetAbsoluteDeadband(MonitoringFilter filter)
  {
    return !(filter is DataChangeFilter dataChangeFilter) || dataChangeFilter.DeadbandType != 1U ? 0.0 : dataChangeFilter.DeadbandValue;
  }

  public static double GetPercentageDeadband(MonitoringFilter filter)
  {
    return !(filter is DataChangeFilter dataChangeFilter) || dataChangeFilter.DeadbandType != 2U ? 0.0 : dataChangeFilter.DeadbandValue;
  }
}
