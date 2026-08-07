// Decompiled with JetBrains decompiler
// Type: Opc.Ua.ElementOperand
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
public class ElementOperand : FilterOperand, IFormattable
{
  private uint m_index;

  public ElementOperand() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_index = 0U;

  [DataMember(Name = "Index", IsRequired = false, Order = 1)]
  public uint Index
  {
    get => this.m_index;
    set => this.m_index = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.ElementOperand;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ElementOperand_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ElementOperand_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.ElementOperand_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteUInt32("Index", this.Index);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Index = decoder.ReadUInt32("Index");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is ElementOperand elementOperand && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_index, (object) elementOperand.m_index) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (ElementOperand) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    ElementOperand elementOperand = (ElementOperand) base.MemberwiseClone();
    elementOperand.m_index = (uint) Utils.Clone((object) this.m_index);
    return (object) elementOperand;
  }

  public ElementOperand(uint index) => this.m_index = index;

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    return $"[{this.m_index}]";
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public override ServiceResult Validate(FilterContext context, int index)
  {
    if (index < 0)
      return ServiceResult.Create(2152267776U /*0x80490000*/, "ElementOperand specifies an Index that is less than zero ({0}).", (object) index);
    if ((long) this.m_index <= (long) index)
      return ServiceResult.Create(2152267776U /*0x80490000*/, "ElementOperand references an element that precedes it in the ContentFilter.", (object) this.m_index);
    if ((long) this.m_index < (long) this.Parent.Parent.Elements.Count)
      return ServiceResult.Good;
    return ServiceResult.Create(2152267776U /*0x80490000*/, "ElementOperand references an element that does not exist.", (object) this.m_index);
  }

  public override string ToString(INodeTable nodeTable)
  {
    return Utils.Format("Element[{0}]", (object) this.Index);
  }
}
