// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AdditionalParametersType
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
public class AdditionalParametersType : IEncodeable, ICloneable, IJsonEncodeable
{
  private KeyValuePairCollection m_parameters;

  public AdditionalParametersType() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_parameters = new KeyValuePairCollection();

  [DataMember(Name = "Parameters", IsRequired = false, Order = 1)]
  public KeyValuePairCollection Parameters
  {
    get => this.m_parameters;
    set
    {
      this.m_parameters = value;
      if (value != null)
        return;
      this.m_parameters = new KeyValuePairCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AdditionalParametersType;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AdditionalParametersType_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AdditionalParametersType_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AdditionalParametersType_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("Parameters", (IList<IEncodeable>) this.Parameters.ToArray(), typeof (KeyValuePair));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Parameters = (KeyValuePairCollection) (KeyValuePair[]) decoder.ReadEncodeableArray("Parameters", typeof (KeyValuePair));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is AdditionalParametersType additionalParametersType && Utils.IsEqual((object) this.m_parameters, (object) additionalParametersType.m_parameters);
  }

  public virtual object Clone() => (object) (AdditionalParametersType) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AdditionalParametersType additionalParametersType = (AdditionalParametersType) base.MemberwiseClone();
    additionalParametersType.m_parameters = (KeyValuePairCollection) Utils.Clone((object) this.m_parameters);
    return (object) additionalParametersType;
  }
}
