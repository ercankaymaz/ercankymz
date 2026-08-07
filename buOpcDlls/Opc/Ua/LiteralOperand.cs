// Decompiled with JetBrains decompiler
// Type: Opc.Ua.LiteralOperand
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
public class LiteralOperand : FilterOperand, IFormattable
{
  private Variant m_value;

  public LiteralOperand() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_value = Variant.Null;

  [DataMember(Name = "Value", IsRequired = false, Order = 1)]
  public Variant Value
  {
    get => this.m_value;
    set => this.m_value = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.LiteralOperand;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.LiteralOperand_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.LiteralOperand_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.LiteralOperand_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteVariant("Value", this.Value);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Value = decoder.ReadVariant("Value");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is LiteralOperand literalOperand && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_value, (object) literalOperand.m_value) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (LiteralOperand) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    LiteralOperand literalOperand = (LiteralOperand) base.MemberwiseClone();
    literalOperand.m_value = (Variant) Utils.Clone((object) this.m_value);
    return (object) literalOperand;
  }

  public LiteralOperand(object value) => this.m_value = new Variant(value);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    return $"{this.m_value}";
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public override ServiceResult Validate(FilterContext context, int index)
  {
    return this.m_value.Value == null ? ServiceResult.Create(2152136704U /*0x80470000*/, "LiteralOperand specifies a null Value.") : ServiceResult.Good;
  }

  public override string ToString(INodeTable nodeTable)
  {
    ExpandedNodeId nodeId = this.Value.Value as ExpandedNodeId;
    if (nodeId == (object) null)
      nodeId = (ExpandedNodeId) (this.Value.Value as NodeId);
    if (nodeId != (object) null)
    {
      INode node = nodeTable.Find(nodeId);
      if (node != null)
        return Utils.Format("{0} ({1})", (object) node, (object) nodeId);
    }
    return Utils.Format("{0}", (object) this.Value);
  }
}
