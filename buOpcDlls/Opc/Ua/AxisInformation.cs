// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AxisInformation
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class AxisInformation : IEncodeable, ICloneable, IJsonEncodeable
{
  private EUInformation m_engineeringUnits;
  private Range m_eURange;
  private LocalizedText m_title;
  private AxisScaleEnumeration m_axisScaleType;
  private DoubleCollection m_axisSteps;

  public AxisInformation() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_engineeringUnits = new EUInformation();
    this.m_eURange = new Range();
    this.m_title = (LocalizedText) null;
    this.m_axisScaleType = AxisScaleEnumeration.Linear;
    this.m_axisSteps = new DoubleCollection();
  }

  [DataMember(Name = "EngineeringUnits", IsRequired = false, Order = 1)]
  public EUInformation EngineeringUnits
  {
    get => this.m_engineeringUnits;
    set
    {
      this.m_engineeringUnits = value;
      if (value != null)
        return;
      this.m_engineeringUnits = new EUInformation();
    }
  }

  [DataMember(Name = "EURange", IsRequired = false, Order = 2)]
  public Range EURange
  {
    get => this.m_eURange;
    set
    {
      this.m_eURange = value;
      if (value != null)
        return;
      this.m_eURange = new Range();
    }
  }

  [DataMember(Name = "Title", IsRequired = false, Order = 3)]
  public LocalizedText Title
  {
    get => this.m_title;
    set => this.m_title = value;
  }

  [DataMember(Name = "AxisScaleType", IsRequired = false, Order = 4)]
  public AxisScaleEnumeration AxisScaleType
  {
    get => this.m_axisScaleType;
    set => this.m_axisScaleType = value;
  }

  [DataMember(Name = "AxisSteps", IsRequired = false, Order = 5)]
  public DoubleCollection AxisSteps
  {
    get => this.m_axisSteps;
    set
    {
      this.m_axisSteps = value;
      if (value != null)
        return;
      this.m_axisSteps = new DoubleCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AxisInformation;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AxisInformation_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AxisInformation_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AxisInformation_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeable("EngineeringUnits", (IEncodeable) this.EngineeringUnits, typeof (EUInformation));
    encoder.WriteEncodeable("EURange", (IEncodeable) this.EURange, typeof (Range));
    encoder.WriteLocalizedText("Title", this.Title);
    encoder.WriteEnumerated("AxisScaleType", (Enum) this.AxisScaleType);
    encoder.WriteDoubleArray("AxisSteps", (IList<double>) this.AxisSteps);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.EngineeringUnits = (EUInformation) decoder.ReadEncodeable("EngineeringUnits", typeof (EUInformation));
    this.EURange = (Range) decoder.ReadEncodeable("EURange", typeof (Range));
    this.Title = decoder.ReadLocalizedText("Title");
    this.AxisScaleType = (AxisScaleEnumeration) decoder.ReadEnumerated("AxisScaleType", typeof (AxisScaleEnumeration));
    this.AxisSteps = decoder.ReadDoubleArray("AxisSteps");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is AxisInformation axisInformation && Utils.IsEqual((object) this.m_engineeringUnits, (object) axisInformation.m_engineeringUnits) && Utils.IsEqual((object) this.m_eURange, (object) axisInformation.m_eURange) && Utils.IsEqual((object) this.m_title, (object) axisInformation.m_title) && Utils.IsEqual((object) this.m_axisScaleType, (object) axisInformation.m_axisScaleType) && Utils.IsEqual((object) this.m_axisSteps, (object) axisInformation.m_axisSteps);
  }

  public virtual object Clone() => (object) (AxisInformation) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AxisInformation axisInformation = (AxisInformation) base.MemberwiseClone();
    axisInformation.m_engineeringUnits = (EUInformation) Utils.Clone((object) this.m_engineeringUnits);
    axisInformation.m_eURange = (Range) Utils.Clone((object) this.m_eURange);
    axisInformation.m_title = (LocalizedText) Utils.Clone((object) this.m_title);
    axisInformation.m_axisScaleType = (AxisScaleEnumeration) Utils.Clone((object) this.m_axisScaleType);
    axisInformation.m_axisSteps = (DoubleCollection) Utils.Clone((object) this.m_axisSteps);
    return (object) axisInformation;
  }
}
