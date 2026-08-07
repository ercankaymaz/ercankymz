// Decompiled with JetBrains decompiler
// Type: Opc.Ua.AttributeOperand
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
public class AttributeOperand : FilterOperand, IFormattable
{
  private NodeId m_nodeId;
  private string m_alias;
  private RelativePath m_browsePath;
  private uint m_attributeId;
  private string m_indexRange;
  private bool m_validated;
  private NumericRange m_parsedIndexRange;

  public AttributeOperand() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize()
  {
    this.m_nodeId = (NodeId) null;
    this.m_alias = (string) null;
    this.m_browsePath = new RelativePath();
    this.m_attributeId = 0U;
    this.m_indexRange = (string) null;
  }

  [DataMember(Name = "NodeId", IsRequired = false, Order = 1)]
  public NodeId NodeId
  {
    get => this.m_nodeId;
    set => this.m_nodeId = value;
  }

  [DataMember(Name = "Alias", IsRequired = false, Order = 2)]
  public string Alias
  {
    get => this.m_alias;
    set => this.m_alias = value;
  }

  [DataMember(Name = "BrowsePath", IsRequired = false, Order = 3)]
  public RelativePath BrowsePath
  {
    get => this.m_browsePath;
    set
    {
      this.m_browsePath = value;
      if (value != null)
        return;
      this.m_browsePath = new RelativePath();
    }
  }

  [DataMember(Name = "AttributeId", IsRequired = false, Order = 4)]
  public uint AttributeId
  {
    get => this.m_attributeId;
    set => this.m_attributeId = value;
  }

  [DataMember(Name = "IndexRange", IsRequired = false, Order = 5)]
  public string IndexRange
  {
    get => this.m_indexRange;
    set => this.m_indexRange = value;
  }

  public override ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.AttributeOperand;

  public override ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AttributeOperand_Encoding_DefaultBinary;
  }

  public override ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AttributeOperand_Encoding_DefaultXml;
  }

  public override ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.AttributeOperand_Encoding_DefaultJson;
  }

  public override void Encode(IEncoder encoder)
  {
    base.Encode(encoder);
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteNodeId("NodeId", this.NodeId);
    encoder.WriteString("Alias", this.Alias);
    encoder.WriteEncodeable("BrowsePath", (IEncodeable) this.BrowsePath, typeof (RelativePath));
    encoder.WriteUInt32("AttributeId", this.AttributeId);
    encoder.WriteString("IndexRange", this.IndexRange);
    encoder.PopNamespace();
  }

  public override void Decode(IDecoder decoder)
  {
    base.Decode(decoder);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.NodeId = decoder.ReadNodeId("NodeId");
    this.Alias = decoder.ReadString("Alias");
    this.BrowsePath = (RelativePath) decoder.ReadEncodeable("BrowsePath", typeof (RelativePath));
    this.AttributeId = decoder.ReadUInt32("AttributeId");
    this.IndexRange = decoder.ReadString("IndexRange");
    decoder.PopNamespace();
  }

  public override bool IsEqual(IEncodeable encodeable)
  {
    if (this == encodeable)
      return true;
    return encodeable is AttributeOperand attributeOperand && base.IsEqual(encodeable) && Utils.IsEqual((object) this.m_nodeId, (object) attributeOperand.m_nodeId) && Utils.IsEqual((object) this.m_alias, (object) attributeOperand.m_alias) && Utils.IsEqual((object) this.m_browsePath, (object) attributeOperand.m_browsePath) && Utils.IsEqual((object) this.m_attributeId, (object) attributeOperand.m_attributeId) && Utils.IsEqual((object) this.m_indexRange, (object) attributeOperand.m_indexRange) && base.IsEqual(encodeable);
  }

  public override object Clone() => (object) (AttributeOperand) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    AttributeOperand attributeOperand = (AttributeOperand) base.MemberwiseClone();
    attributeOperand.m_nodeId = (NodeId) Utils.Clone((object) this.m_nodeId);
    attributeOperand.m_alias = (string) Utils.Clone((object) this.m_alias);
    attributeOperand.m_browsePath = (RelativePath) Utils.Clone((object) this.m_browsePath);
    attributeOperand.m_attributeId = (uint) Utils.Clone((object) this.m_attributeId);
    attributeOperand.m_indexRange = (string) Utils.Clone((object) this.m_indexRange);
    return (object) attributeOperand;
  }

  public AttributeOperand(NodeId nodeId, QualifiedName browsePath)
  {
    this.m_nodeId = nodeId;
    this.m_attributeId = 13U;
    this.m_browsePath = new RelativePath();
    this.m_browsePath.Elements.Add(new RelativePathElement()
    {
      ReferenceTypeId = ReferenceTypeIds.Aggregates,
      IsInverse = false,
      IncludeSubtypes = true,
      TargetName = browsePath
    });
  }

  public AttributeOperand(NodeId nodeId, IList<QualifiedName> browsePaths)
  {
    this.m_nodeId = nodeId;
    this.m_attributeId = 13U;
    this.m_browsePath = new RelativePath();
    for (int index = 0; index < browsePaths.Count; ++index)
      this.m_browsePath.Elements.Add(new RelativePathElement()
      {
        ReferenceTypeId = ReferenceTypeIds.Aggregates,
        IsInverse = false,
        IncludeSubtypes = true,
        TargetName = browsePaths[index]
      });
  }

  public AttributeOperand(FilterContext context, ExpandedNodeId nodeId, RelativePath relativePath)
  {
    this.m_nodeId = ExpandedNodeId.ToNodeId(nodeId, context.NamespaceUris);
    this.m_browsePath = relativePath;
    this.m_attributeId = 13U;
    this.m_indexRange = (string) null;
    this.m_alias = (string) null;
  }

  public AttributeOperand(
    FilterContext context,
    ExpandedNodeId typeDefinitionId,
    string browsePath,
    uint attributeId,
    string indexRange)
  {
    this.m_nodeId = ExpandedNodeId.ToNodeId(typeDefinitionId, context.NamespaceUris);
    this.m_browsePath = RelativePath.Parse(browsePath, context.TypeTree);
    this.m_attributeId = attributeId;
    this.m_indexRange = indexRange;
    this.m_alias = (string) null;
  }

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format == null)
    {
      StringBuilder stringBuilder = new StringBuilder();
      for (int index = 0; index < this.m_browsePath.Elements.Count; ++index)
        stringBuilder.AppendFormat(formatProvider, "/{0}", (object) this.m_browsePath.Elements[index].TargetName);
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
    if (!context.TypeTree.IsKnown(this.m_nodeId))
      return ServiceResult.Create(2153971712U /*0x80630000*/, "AttributeOperand does not have a known TypeDefinitionId ({0}).", (object) this.m_nodeId);
    if (!Attributes.IsValid(this.m_attributeId))
      return ServiceResult.Create(2150957056U /*0x80350000*/, "AttributeOperand does not specify a valid AttributeId ({0}).", (object) this.m_attributeId);
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
        return ServiceResult.Create(ex, 2151022592U /*0x80360000*/, "AttributeOperand does not specify a valid BrowsePath ({0}).", objArray);
      }
      if (this.m_attributeId != 13U)
        return ServiceResult.Create(2151022592U /*0x80360000*/, "AttributeOperand specifies an IndexRange for an Attribute other than Value ({0}).", (object) this.m_attributeId);
    }
    this.m_validated = true;
    return ServiceResult.Good;
  }

  public override string ToString(INodeTable nodeTable)
  {
    StringBuilder stringBuilder = new StringBuilder();
    if (nodeTable.Find((ExpandedNodeId) this.m_nodeId) != null)
      stringBuilder.AppendFormat("{0}", (object) this.NodeId);
    else
      stringBuilder.AppendFormat("{0}", (object) this.NodeId);
    if (!RelativePath.IsEmpty(this.BrowsePath))
      stringBuilder.AppendFormat("/{0}", (object) this.BrowsePath.Format(nodeTable.TypeTree));
    if (!string.IsNullOrEmpty(this.IndexRange))
      stringBuilder.AppendFormat("[{0}]", (object) NumericRange.Parse(this.IndexRange));
    if (!string.IsNullOrEmpty(this.Alias))
      stringBuilder.AppendFormat("- '{0}'", (object) this.Alias);
    return stringBuilder.ToString();
  }
}
