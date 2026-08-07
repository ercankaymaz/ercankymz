// Decompiled with JetBrains decompiler
// Type: Opc.Ua.RelativePath
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
public class RelativePath : IEncodeable, ICloneable, IJsonEncodeable
{
  private RelativePathElementCollection m_elements;

  public RelativePath() => this.Initialize();

  [OnDeserializing]
  private void Initialize(StreamingContext context) => this.Initialize();

  private void Initialize() => this.m_elements = new RelativePathElementCollection();

  [DataMember(Name = "Elements", IsRequired = false, Order = 1)]
  public RelativePathElementCollection Elements
  {
    get => this.m_elements;
    set
    {
      this.m_elements = value;
      if (value != null)
        return;
      this.m_elements = new RelativePathElementCollection();
    }
  }

  public virtual ExpandedNodeId TypeId => (ExpandedNodeId) DataTypeIds.RelativePath;

  public virtual ExpandedNodeId BinaryEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RelativePath_Encoding_DefaultBinary;
  }

  public virtual ExpandedNodeId XmlEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RelativePath_Encoding_DefaultXml;
  }

  public virtual ExpandedNodeId JsonEncodingId
  {
    get => (ExpandedNodeId) ObjectIds.RelativePath_Encoding_DefaultJson;
  }

  public virtual void Encode(IEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEncodeableArray("Elements", (IList<IEncodeable>) this.Elements.ToArray(), typeof (RelativePathElement));
    encoder.PopNamespace();
  }

  public virtual void Decode(IDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    this.Elements = (RelativePathElementCollection) (RelativePathElement[]) decoder.ReadEncodeableArray("Elements", typeof (RelativePathElement));
    decoder.PopNamespace();
  }

  public virtual bool IsEqual(IEncodeable encodeable)
  {
    return this == encodeable || encodeable is RelativePath relativePath && Utils.IsEqual((object) this.m_elements, (object) relativePath.m_elements);
  }

  public virtual object Clone() => (object) (RelativePath) this.MemberwiseClone();

  public new object MemberwiseClone()
  {
    RelativePath relativePath = (RelativePath) base.MemberwiseClone();
    relativePath.m_elements = (RelativePathElementCollection) Utils.Clone((object) this.m_elements);
    return (object) relativePath;
  }

  public RelativePath(QualifiedName browseName)
    : this(ReferenceTypeIds.HierarchicalReferences, false, true, browseName)
  {
  }

  public RelativePath(NodeId referenceTypeId, QualifiedName browseName)
    : this(referenceTypeId, false, true, browseName)
  {
  }

  public RelativePath(
    NodeId referenceTypeId,
    bool isInverse,
    bool includeSubtypes,
    QualifiedName browseName)
  {
    this.Initialize();
    this.m_elements.Add(new RelativePathElement()
    {
      ReferenceTypeId = referenceTypeId,
      IsInverse = isInverse,
      IncludeSubtypes = includeSubtypes,
      TargetName = browseName
    });
  }

  public string Format(ITypeTable typeTree) => new RelativePathFormatter(this, typeTree).ToString();

  public static bool IsEmpty(RelativePath relativePath)
  {
    return relativePath == null || relativePath.Elements.Count == 0;
  }

  public static RelativePath Parse(string browsePath, ITypeTable typeTree)
  {
    if (typeTree == null)
      throw new ArgumentNullException(nameof (typeTree));
    RelativePathFormatter relativePathFormatter = RelativePathFormatter.Parse(browsePath);
    RelativePath relativePath = new RelativePath();
    foreach (RelativePathFormatter.Element element in relativePathFormatter.Elements)
    {
      RelativePathElement relativePathElement = new RelativePathElement();
      relativePathElement.ReferenceTypeId = (NodeId) null;
      relativePathElement.IsInverse = false;
      relativePathElement.IncludeSubtypes = element.IncludeSubtypes;
      relativePathElement.TargetName = element.TargetName;
      switch (element.ElementType)
      {
        case RelativePathFormatter.ElementType.AnyHierarchical:
          relativePathElement.ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences;
          break;
        case RelativePathFormatter.ElementType.AnyComponent:
          relativePathElement.ReferenceTypeId = ReferenceTypeIds.Aggregates;
          break;
        case RelativePathFormatter.ElementType.ForwardReference:
          relativePathElement.ReferenceTypeId = typeTree.FindReferenceType(element.ReferenceTypeName);
          break;
        case RelativePathFormatter.ElementType.InverseReference:
          relativePathElement.ReferenceTypeId = typeTree.FindReferenceType(element.ReferenceTypeName);
          relativePathElement.IsInverse = true;
          break;
      }
      if (!NodeId.IsNull(relativePathElement.ReferenceTypeId))
        relativePath.Elements.Add(relativePathElement);
      else
        throw ServiceResultException.Create(2159411200U /*0x80B60000*/, "Could not convert BrowseName to a ReferenceTypeId: {0}", (object) element.ReferenceTypeName);
    }
    return relativePath;
  }

  public static RelativePath Parse(
    string browsePath,
    ITypeTable typeTree,
    NamespaceTable currentTable,
    NamespaceTable targetTable)
  {
    RelativePathFormatter relativePathFormatter = RelativePathFormatter.Parse(browsePath, currentTable, targetTable);
    RelativePath relativePath = new RelativePath();
    foreach (RelativePathFormatter.Element element in relativePathFormatter.Elements)
    {
      RelativePathElement relativePathElement = new RelativePathElement();
      relativePathElement.ReferenceTypeId = (NodeId) null;
      relativePathElement.IsInverse = false;
      relativePathElement.IncludeSubtypes = element.IncludeSubtypes;
      relativePathElement.TargetName = element.TargetName;
      switch (element.ElementType)
      {
        case RelativePathFormatter.ElementType.AnyHierarchical:
          relativePathElement.ReferenceTypeId = ReferenceTypeIds.HierarchicalReferences;
          break;
        case RelativePathFormatter.ElementType.AnyComponent:
          relativePathElement.ReferenceTypeId = ReferenceTypeIds.Aggregates;
          break;
        case RelativePathFormatter.ElementType.ForwardReference:
        case RelativePathFormatter.ElementType.InverseReference:
          if (typeTree == null)
            throw new InvalidOperationException("Cannot parse path with reference names without a type table.");
          relativePathElement.ReferenceTypeId = typeTree.FindReferenceType(element.ReferenceTypeName);
          relativePathElement.IsInverse = element.ElementType == RelativePathFormatter.ElementType.InverseReference;
          break;
      }
      if (!NodeId.IsNull(relativePathElement.ReferenceTypeId))
        relativePath.Elements.Add(relativePathElement);
      else
        throw ServiceResultException.Create(2159411200U /*0x80B60000*/, "Could not convert BrowseName to a ReferenceTypeId: {0}", (object) element.ReferenceTypeName);
    }
    return relativePath;
  }
}
