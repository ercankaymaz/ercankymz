// Decompiled with JetBrains decompiler
// Type: Opc.Ua.SimpleAttributeOperand
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text;

#nullable disable
namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class SimpleAttributeOperand : FilterOperand, IFormattable
{
  private NodeId m_typeDefinitionId;
  private QualifiedNameCollection m_browsePath;
  private uint m_attributeId;
  private string m_indexRange;
  private bool m_validated;
  private NumericRange m_parsedIndexRange;

  public SimpleAttributeOperand() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_typeDefinitionId = (NodeId) null;
    this.m_browsePath = new QualifiedNameCollection();
    this.m_attributeId = 0U;
    this.m_indexRange = (string) null;
  }

  [DataMember(Name = "TypeDefinitionId", IsRequired = false, Order = 1)]
  public NodeId TypeDefinitionId
  {
    get => this.m_typeDefinitionId;
    set => this.m_typeDefinitionId = value;
  }

  [DataMember(Name = "BrowsePath", IsRequired = false, Order = 2)]
  public QualifiedNameCollection BrowsePath
  {
    get => this.m_browsePath;
    set
    {
      this.m_browsePath = value;
      if (value != null)
        return;
      this.m_browsePath = new QualifiedNameCollection();
    }
  }

  [DataMember(Name = "AttributeId", IsRequired = false, Order = 3)]
  public uint AttributeId
  {
    get => this.m_attributeId;
    set => this.m_attributeId = value;
  }

  [DataMember(Name = "IndexRange", IsRequired = false, Order = 4)]
  public string IndexRange
  {
    get => this.m_indexRange;
    set => this.m_indexRange = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.SimpleAttributeOperand;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SimpleAttributeOperand_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SimpleAttributeOperand_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.SimpleAttributeOperand_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("TypeDefinitionId", this.TypeDefinitionId);
    encoder.WriteQualifiedNameArray("BrowsePath", (IList<QualifiedName>) this.BrowsePath);
    encoder.WriteUInt32("AttributeId", this.AttributeId);
    encoder.WriteString("IndexRange", this.IndexRange);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.TypeDefinitionId = decoder.ReadNodeId("TypeDefinitionId");
    this.BrowsePath = decoder.ReadQualifiedNameArray("BrowsePath");
    this.AttributeId = decoder.ReadUInt32("AttributeId");
    this.IndexRange = decoder.ReadString("IndexRange");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is SimpleAttributeOperand attributeOperand && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_typeDefinitionId, (object) attributeOperand.m_typeDefinitionId) && Utils.IsEqual((object) this.m_browsePath, (object) attributeOperand.m_browsePath) && Utils.IsEqual((object) this.m_attributeId, (object) attributeOperand.m_attributeId) && Utils.IsEqual((object) this.m_indexRange, (object) attributeOperand.m_indexRange) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (SimpleAttributeOperand) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    SimpleAttributeOperand attributeOperand = (SimpleAttributeOperand) base.MemberwiseClone();
    attributeOperand.m_typeDefinitionId = (NodeId) Utils.Clone((object) this.m_typeDefinitionId);
    attributeOperand.m_browsePath = (QualifiedNameCollection) Utils.Clone((object) this.m_browsePath);
    attributeOperand.m_attributeId = (uint) Utils.Clone((object) this.m_attributeId);
    attributeOperand.m_indexRange = (string) Utils.Clone((object) this.m_indexRange);
    return (object) attributeOperand;
  }

  public SimpleAttributeOperand(NodeId typeId, QualifiedName browsePath)
  {
    this.m_typeDefinitionId = typeId;
    this.m_browsePath = new QualifiedNameCollection();
    this.m_attributeId = 13U;
    this.m_indexRange = (string) null;
    this.m_browsePath.Add(browsePath);
  }

  public SimpleAttributeOperand(NodeId typeId, IList<QualifiedName> browsePath)
  {
    this.m_typeDefinitionId = typeId;
    this.m_browsePath = new QualifiedNameCollection((IEnumerable<QualifiedName>) browsePath);
    this.m_attributeId = 13U;
    this.m_indexRange = (string) null;
  }

  public SimpleAttributeOperand(
    FilterContext context,
    ExpandedNodeId typeId,
    IList<QualifiedName> browsePath)
  {
    this.m_typeDefinitionId = ExpandedNodeId.ToNodeId(typeId, context.NamespaceUris);
    this.m_browsePath = new QualifiedNameCollection((IEnumerable<QualifiedName>) browsePath);
    this.m_attributeId = 13U;
    this.m_indexRange = (string) null;
  }

  public SimpleAttributeOperand(
    FilterContext context,
    ExpandedNodeId typeDefinitionId,
    string browsePath,
    uint attributeId,
    string indexRange)
  {
    this.m_typeDefinitionId = ExpandedNodeId.ToNodeId(typeDefinitionId, context.NamespaceUris);
    this.m_browsePath = SimpleAttributeOperand.Parse(browsePath);
    this.m_attributeId = attributeId;
    this.m_indexRange = indexRange;
  }

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < this.m_browsePath.Count; ++index)
        stringBuilder.AppendFormat(formatProvider, "/{0}", (object) this.m_browsePath[index]);
      return stringBuilder.ToString();
    }
    throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public bool Validated => this.m_validated;

  public NumericRange ParsedIndexRange => this.m_parsedIndexRange;

  public override ServiceResult Validate(FilterContext context, int index)
  {
    this.m_validated = false;
    if (!Attributes.IsValid(this.m_attributeId))
      return ServiceResult.Create(2150957056U /*0x80350000*/, "SimpleAttributeOperand does not specify a valid AttributeId ({0}).", (object) this.m_attributeId);
    this.m_parsedIndexRange = NumericRange.Empty;
    if (!string.IsNullOrEmpty(this.m_indexRange))
    {
      try
      {
        this.m_parsedIndexRange = NumericRange.Parse(this.m_indexRange);
      }
      catch (Exception ex)
      {
        object[] objArray = new object[1]
        {
          (object) this.m_indexRange
        };
        return ServiceResult.Create(ex, 2151022592U /*0x80360000*/, "SimpleAttributeOperand does not specify a valid BrowsePath ({0}).", objArray);
      }
      if (this.m_attributeId != 13U)
        return ServiceResult.Create(2151022592U /*0x80360000*/, "SimpleAttributeOperand specifies an IndexRange for an Attribute other than Value ({0}).", (object) this.m_attributeId);
    }
    this.m_validated = true;
    return ServiceResult.Good;
  }

  public override string ToString(INodeTable nodeTable)
  {
    StringBuilder stringBuilder = new StringBuilder();
    if (nodeTable.Find((ExpandedNodeId) this.TypeDefinitionId) != null)
      stringBuilder.AppendFormat("{0}", (object) this.TypeDefinitionId);
    else
      stringBuilder.AppendFormat("{0}", (object) this.TypeDefinitionId);
    if (this.BrowsePath != null && this.BrowsePath.Count > 0)
      stringBuilder.AppendFormat("{0}", (object) SimpleAttributeOperand.Format((IList<QualifiedName>) this.BrowsePath));
    if (!string.IsNullOrEmpty(this.IndexRange))
      stringBuilder.AppendFormat("[{0}]", (object) NumericRange.Parse(this.IndexRange));
    return stringBuilder.ToString();
  }

  public static string Format(IList<QualifiedName> browsePath)
  {
    if (browsePath == null || browsePath.Count == 0)
      return string.Empty;
    StringBuilder stringBuilder = new StringBuilder();
    for (int index1 = 0; index1 < browsePath.Count; ++index1)
    {
      QualifiedName qualifiedName = browsePath[index1];
      if (QualifiedName.IsNull(qualifiedName))
        throw ServiceResultException.Create(2153775104U /*0x80600000*/, "BrowseName cannot be null");
      stringBuilder.Append('/');
      if (qualifiedName.NamespaceIndex != (ushort) 0)
        stringBuilder.AppendFormat("{0}:", (object) qualifiedName.NamespaceIndex);
      for (int index2 = 0; index2 < qualifiedName.Name.Length; ++index2)
      {
        char ch = qualifiedName.Name[index2];
        switch (ch)
        {
          case '&':
          case '/':
            stringBuilder.Append('&');
            break;
        }
        stringBuilder.Append(ch);
      }
    }
    return stringBuilder.ToString();
  }

  public static QualifiedNameCollection Parse(string browsePath)
  {
    QualifiedNameCollection qualifiedNameCollection = new QualifiedNameCollection();
    if (string.IsNullOrEmpty(browsePath))
      return qualifiedNameCollection;
    StringBuilder stringBuilder = new StringBuilder();
    bool flag = false;
    for (int index = 0; index < browsePath.Length; ++index)
    {
      char ch = browsePath[index];
      if (flag)
      {
        stringBuilder.Append(ch);
        flag = false;
      }
      else
      {
        switch (ch)
        {
          case '&':
            flag = true;
            continue;
          case '/':
            if (stringBuilder.Length > 0)
            {
              QualifiedName qualifiedName = QualifiedName.Parse(stringBuilder.ToString());
              qualifiedNameCollection.Add(qualifiedName);
            }
            stringBuilder.Length = 0;
            continue;
          default:
            stringBuilder.Append(ch);
            continue;
        }
      }
    }
    if (stringBuilder.Length > 0)
    {
      QualifiedName qualifiedName = QualifiedName.Parse(stringBuilder.ToString());
      qualifiedNameCollection.Add(qualifiedName);
    }
    return qualifiedNameCollection;
  }
}
