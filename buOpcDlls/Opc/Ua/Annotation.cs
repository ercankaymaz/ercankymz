// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Annotation
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
public class Annotation : IEncodeable, ICloneable, IJsonEncodeable
{
  private string m_message;
  private string m_userName;
  private DateTime m_annotationTime;

  public Annotation() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_message = (string) null;
    this.m_userName = (string) null;
    this.m_annotationTime = DateTime.MinValue;
  }

  [DataMember(Name = "Message", IsRequired = false, Order = 1)]
  public string Message
  {
    get => this.m_message;
    set => this.m_message = value;
  }

  [DataMember(Name = "UserName", IsRequired = false, Order = 2)]
  public string UserName
  {
    get => this.m_userName;
    set => this.m_userName = value;
  }

  [DataMember(Name = "AnnotationTime", IsRequired = false, Order = 3)]
  public DateTime AnnotationTime
  {
    get => this.m_annotationTime;
    set => this.m_annotationTime = value;
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.Annotation;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Annotation_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Annotation_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.Annotation_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteString("Message", this.Message);
    encoder.WriteString("UserName", this.UserName);
    encoder.WriteDateTime("AnnotationTime", this.AnnotationTime);
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Message = decoder.ReadString("Message");
    this.UserName = decoder.ReadString("UserName");
    this.AnnotationTime = decoder.ReadDateTime("AnnotationTime");
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is Annotation annotation && Utils.IsEqual((object) this.m_message, (object) annotation.m_message) && Utils.IsEqual((object) this.m_userName, (object) annotation.m_userName) && Utils.IsEqual(this.m_annotationTime, annotation.m_annotationTime);
  }

  public virtual object Clone() => (object) (Annotation) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    Annotation annotation = (Annotation) base.MemberwiseClone();
    annotation.m_message = (string) Utils.Clone((object) this.m_message);
    annotation.m_userName = (string) Utils.Clone((object) this.m_userName);
    annotation.m_annotationTime = (DateTime) Utils.Clone((object) this.m_annotationTime);
    return (object) annotation;
  }
}
