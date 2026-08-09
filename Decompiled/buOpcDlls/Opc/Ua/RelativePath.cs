using System;
using System.CodeDom.Compiler;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;

namespace Opc.Ua;

[GeneratedCode("Opc.Ua.ModelCompiler", "1.0.0.0")]
[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class RelativePath : IEncodeable, ICloneable, IJsonEncodeable
{
	private RelativePathElementCollection m_elements;

	[DataMember(Name = "Elements", IsRequired = false, Order = 1)]
	public RelativePathElementCollection Elements
	{
		get
		{
			return m_elements;
		}
		set
		{
			m_elements = value;
			if (value == null)
			{
				m_elements = new RelativePathElementCollection();
			}
		}
	}

	public virtual ExpandedNodeId TypeId => DataTypeIds.RelativePath;

	public virtual ExpandedNodeId BinaryEncodingId => ObjectIds.RelativePath_Encoding_DefaultBinary;

	public virtual ExpandedNodeId XmlEncodingId => ObjectIds.RelativePath_Encoding_DefaultXml;

	public virtual ExpandedNodeId JsonEncodingId => ObjectIds.RelativePath_Encoding_DefaultJson;

	public RelativePath()
	{
		Initialize();
	}

	[OnDeserializing]
	private void Initialize(StreamingContext context)
	{
		Initialize();
	}

	private void Initialize()
	{
		m_elements = new RelativePathElementCollection();
	}

	public virtual void Encode(IEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEncodeableArray("Elements", Elements.ToArray(), typeof(RelativePathElement));
		encoder.PopNamespace();
	}

	public virtual void Decode(IDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		Elements = (RelativePathElement[])decoder.ReadEncodeableArray("Elements", typeof(RelativePathElement));
		decoder.PopNamespace();
	}

	public virtual bool IsEqual(IEncodeable encodeable)
	{
		if (this == encodeable)
		{
			return true;
		}
		if (!(encodeable is RelativePath relativePath))
		{
			return false;
		}
		if (!Utils.IsEqual(m_elements, relativePath.m_elements))
		{
			return false;
		}
		return true;
	}

	public virtual object Clone()
	{
		return (RelativePath)MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		RelativePath obj = (RelativePath)base.MemberwiseClone();
		obj.m_elements = (RelativePathElementCollection)Utils.Clone(m_elements);
		return obj;
	}

	public RelativePath(QualifiedName browseName)
		: this(ReferenceTypeIds.HierarchicalReferences, isInverse: false, includeSubtypes: true, browseName)
	{
	}

	public RelativePath(NodeId referenceTypeId, QualifiedName browseName)
		: this(referenceTypeId, isInverse: false, includeSubtypes: true, browseName)
	{
	}

	public RelativePath(NodeId referenceTypeId, bool isInverse, bool includeSubtypes, QualifiedName browseName)
	{
		Initialize();
		RelativePathElement item = new RelativePathElement
		{
			ReferenceTypeId = referenceTypeId,
			IsInverse = isInverse,
			IncludeSubtypes = includeSubtypes,
			TargetName = browseName
		};
		m_elements.Add(item);
	}

	public string Format(ITypeTable typeTree)
	{
		return new RelativePathFormatter(this, typeTree).ToString();
	}

	public static bool IsEmpty(RelativePath relativePath)
	{
		if (relativePath != null)
		{
			return relativePath.Elements.Count == 0;
		}
		return true;
	}

	public static RelativePath Parse(string browsePath, ITypeTable typeTree)
	{
		if (typeTree == null)
		{
			throw new ArgumentNullException("typeTree");
		}
		RelativePathFormatter relativePathFormatter = RelativePathFormatter.Parse(browsePath);
		RelativePath relativePath = new RelativePath();
		foreach (RelativePathFormatter.Element element in relativePathFormatter.Elements)
		{
			RelativePathElement relativePathElement = new RelativePathElement();
			relativePathElement.ReferenceTypeId = null;
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
			if (NodeId.IsNull(relativePathElement.ReferenceTypeId))
			{
				throw ServiceResultException.Create(2159411200u, "Could not convert BrowseName to a ReferenceTypeId: {0}", element.ReferenceTypeName);
			}
			relativePath.Elements.Add(relativePathElement);
		}
		return relativePath;
	}

	public static RelativePath Parse(string browsePath, ITypeTable typeTree, NamespaceTable currentTable, NamespaceTable targetTable)
	{
		RelativePathFormatter relativePathFormatter = RelativePathFormatter.Parse(browsePath, currentTable, targetTable);
		RelativePath relativePath = new RelativePath();
		foreach (RelativePathFormatter.Element element in relativePathFormatter.Elements)
		{
			RelativePathElement relativePathElement = new RelativePathElement();
			relativePathElement.ReferenceTypeId = null;
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
				{
					throw new InvalidOperationException("Cannot parse path with reference names without a type table.");
				}
				relativePathElement.ReferenceTypeId = typeTree.FindReferenceType(element.ReferenceTypeName);
				relativePathElement.IsInverse = element.ElementType == RelativePathFormatter.ElementType.InverseReference;
				break;
			}
			if (NodeId.IsNull(relativePathElement.ReferenceTypeId))
			{
				throw ServiceResultException.Create(2159411200u, "Could not convert BrowseName to a ReferenceTypeId: {0}", element.ReferenceTypeName);
			}
			relativePath.Elements.Add(relativePathElement);
		}
		return relativePath;
	}
}
