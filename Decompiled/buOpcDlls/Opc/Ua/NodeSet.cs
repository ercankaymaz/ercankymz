using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[KnownType(typeof(ObjectNode))]
[KnownType(typeof(ObjectTypeNode))]
[KnownType(typeof(VariableNode))]
[KnownType(typeof(VariableTypeNode))]
[KnownType(typeof(MethodNode))]
[KnownType(typeof(DataTypeNode))]
[KnownType(typeof(ReferenceTypeNode))]
[KnownType(typeof(ViewNode))]
[ComVisible(true)]
public class NodeSet : IEnumerable<Node>, IEnumerable
{
	private NamespaceTable m_namespaceUris;

	private StringTable m_serverUris;

	private Dictionary<NodeId, Node> m_nodes;

	[DataMember(Name = "NamespaceUris", Order = 1)]
	internal StringCollection NamespaceUris
	{
		get
		{
			return new StringCollection(m_namespaceUris.ToArray());
		}
		set
		{
			if (value == null)
			{
				m_namespaceUris = new NamespaceTable();
			}
			else
			{
				m_namespaceUris = new NamespaceTable(value);
			}
		}
	}

	[DataMember(Name = "ServerUris", Order = 2)]
	internal StringCollection ServerUris
	{
		get
		{
			return new StringCollection(m_serverUris.ToArray());
		}
		set
		{
			if (value == null)
			{
				m_serverUris = new StringTable();
			}
			else
			{
				m_serverUris = new StringTable(value);
			}
		}
	}

	[DataMember(Name = "Nodes", Order = 3)]
	internal NodeCollection Nodes
	{
		get
		{
			return new NodeCollection(m_nodes.Values);
		}
		set
		{
			m_nodes = new Dictionary<NodeId, Node>();
			if (value == null)
			{
				return;
			}
			foreach (Node item in value)
			{
				m_nodes[item.NodeId] = item;
			}
		}
	}

	public NodeSet()
	{
		m_namespaceUris = new NamespaceTable();
		m_serverUris = new StringTable();
		m_nodes = new Dictionary<NodeId, Node>();
	}

	public static NodeSet Read(Stream istrm)
	{
		using XmlReader reader = XmlReader.Create(istrm, Utils.DefaultXmlReaderSettings());
		return new DataContractSerializer(typeof(NodeSet)).ReadObject(reader) as NodeSet;
	}

	public void Write(Stream istrm)
	{
		XmlWriter xmlWriter = XmlWriter.Create(istrm, Utils.DefaultXmlWriterSettings());
		try
		{
			new DataContractSerializer(typeof(NodeSet)).WriteObject(xmlWriter, this);
		}
		finally
		{
			xmlWriter.Flush();
			xmlWriter.Dispose();
		}
	}

	public IEnumerator<Node> GetEnumerator()
	{
		return new List<Node>(m_nodes.Values).GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator()
	{
		return GetEnumerator();
	}

	public void Add(Node node)
	{
		if (node == null)
		{
			throw new ArgumentNullException("node");
		}
		if (NodeId.IsNull(node.NodeId))
		{
			throw new ArgumentException("A non-null NodeId must be specified.");
		}
		if (m_nodes.ContainsKey(node.NodeId))
		{
			throw new ArgumentException(Utils.Format("NodeID {0} already exists for node: {1}", node.NodeId, node));
		}
		m_nodes.Add(node.NodeId, node);
	}

	private void TranslateArrayValue(Array array, BuiltInType elementType, NamespaceTable namespaceUris, StringTable serverUris)
	{
		if (array == null)
		{
			return;
		}
		int[] array2 = new int[array.Rank];
		for (int i = 0; i < array2.Length; i++)
		{
			array2[i] = array.GetLength(i);
		}
		int length = array.Length;
		int[] array3 = new int[array2.Length];
		for (int j = 0; j < length; j++)
		{
			int num = length;
			for (int k = 0; k < array3.Length; k++)
			{
				num /= array2[k];
				array3[k] = j / num % array2[k];
			}
			object value = array.GetValue(array3);
			if (value != null)
			{
				if (elementType == BuiltInType.Variant)
				{
					value = ((Variant)value).Value;
				}
				value = TranslateValue(value, namespaceUris, serverUris);
				if (elementType == BuiltInType.Variant)
				{
					value = new Variant(value);
				}
				array.SetValue(value, array3);
			}
		}
	}

	private object TranslateValue(object value, NamespaceTable namespaceUris, StringTable serverUris)
	{
		TypeInfo typeInfo = TypeInfo.Construct(value);
		if (typeInfo == null)
		{
			return value;
		}
		if (typeInfo.ValueRank > 0)
		{
			TranslateArrayValue((Array)value, typeInfo.BuiltInType, namespaceUris, serverUris);
			return value;
		}
		switch (typeInfo.BuiltInType)
		{
		case BuiltInType.NodeId:
			return Translate((NodeId)value, m_namespaceUris, namespaceUris);
		case BuiltInType.ExpandedNodeId:
			return Translate((ExpandedNodeId)value, m_namespaceUris, m_serverUris, namespaceUris, serverUris);
		case BuiltInType.QualifiedName:
			return Translate((QualifiedName)value, m_namespaceUris, namespaceUris);
		case BuiltInType.ExtensionObject:
			if (ExtensionObject.ToEncodeable((ExtensionObject)value) is Argument argument)
			{
				argument.DataType = Translate(argument.DataType, m_namespaceUris, namespaceUris);
			}
			return value;
		default:
			return value;
		}
	}

	public Node Add(ILocalNode nodeToExport, NamespaceTable namespaceUris, StringTable serverUris)
	{
		Node node = Node.Copy(nodeToExport);
		node.NodeId = Translate(nodeToExport.NodeId, m_namespaceUris, namespaceUris);
		node.BrowseName = Translate(nodeToExport.BrowseName, m_namespaceUris, namespaceUris);
		if (nodeToExport is VariableNode variableNode)
		{
			VariableNode variableNode2 = (VariableNode)node;
			object value = TranslateValue(variableNode2.Value.Value, namespaceUris, serverUris);
			variableNode2.Value = new Variant(value);
			variableNode2.DataType = Translate(variableNode.DataType, m_namespaceUris, namespaceUris);
		}
		if (nodeToExport is VariableTypeNode variableTypeNode)
		{
			VariableTypeNode variableTypeNode2 = (VariableTypeNode)node;
			object value2 = TranslateValue(variableTypeNode2.Value.Value, namespaceUris, serverUris);
			variableTypeNode2.Value = new Variant(value2);
			variableTypeNode2.DataType = Translate(variableTypeNode.DataType, m_namespaceUris, namespaceUris);
		}
		foreach (IReference reference in nodeToExport.References)
		{
			ReferenceNode referenceNode = new ReferenceNode();
			referenceNode.ReferenceTypeId = Translate(reference.ReferenceTypeId, m_namespaceUris, namespaceUris);
			referenceNode.IsInverse = reference.IsInverse;
			referenceNode.TargetId = Translate(reference.TargetId, m_namespaceUris, m_serverUris, namespaceUris, serverUris);
			node.References.Add(referenceNode);
		}
		Add(node);
		return node;
	}

	public void AddReference(Node node, ReferenceNode referenceToExport, NamespaceTable namespaceUris, StringTable serverUris)
	{
		ReferenceNode referenceNode = new ReferenceNode();
		referenceNode.ReferenceTypeId = Translate(referenceToExport.ReferenceTypeId, m_namespaceUris, namespaceUris);
		referenceNode.IsInverse = referenceToExport.IsInverse;
		referenceNode.TargetId = Translate(referenceToExport.TargetId, m_namespaceUris, m_serverUris, namespaceUris, serverUris);
		node.References.Add(referenceNode);
	}

	public bool Remove(NodeId nodeId)
	{
		return m_nodes.Remove(nodeId);
	}

	public bool Contains(NodeId nodeId)
	{
		return m_nodes.ContainsKey(nodeId);
	}

	public Node Find(NodeId nodeId)
	{
		Node value = null;
		if (m_nodes.TryGetValue(nodeId, out value))
		{
			return value;
		}
		return null;
	}

	public Node Find(NodeId nodeId, NamespaceTable namespaceUris)
	{
		if (nodeId == null)
		{
			throw new ArgumentNullException("nodeId");
		}
		if (namespaceUris == null)
		{
			throw new ArgumentNullException("namespaceUris");
		}
		string text = namespaceUris.GetString(nodeId.NamespaceIndex);
		if (text == null)
		{
			return null;
		}
		int index = m_namespaceUris.GetIndex(text);
		if (index < 0)
		{
			return null;
		}
		NodeId key = new NodeId(nodeId.Identifier, (ushort)index);
		Node value = null;
		if (m_nodes.TryGetValue(key, out value))
		{
			return value;
		}
		return null;
	}

	public Node Copy(Node nodeToImport, NamespaceTable namespaceUris, StringTable serverUris)
	{
		Node node = Node.Copy(nodeToImport);
		node.NodeId = Translate(nodeToImport.NodeId, namespaceUris, m_namespaceUris);
		node.BrowseName = Translate(nodeToImport.BrowseName, namespaceUris, m_namespaceUris);
		if (nodeToImport is VariableNode variableNode)
		{
			VariableNode variableNode2 = (VariableNode)node;
			variableNode2.DataType = Translate(variableNode.DataType, namespaceUris, m_namespaceUris);
			if (variableNode.Value.Value != null)
			{
				variableNode2.Value = new Variant(ImportValue(variableNode.Value.Value, namespaceUris, serverUris));
			}
		}
		if (nodeToImport is VariableTypeNode variableTypeNode)
		{
			VariableTypeNode variableTypeNode2 = (VariableTypeNode)node;
			variableTypeNode2.DataType = Translate(variableTypeNode.DataType, namespaceUris, m_namespaceUris);
			if (variableTypeNode.Value.Value != null)
			{
				variableTypeNode2.Value = new Variant(ImportValue(variableTypeNode.Value.Value, namespaceUris, serverUris));
			}
		}
		foreach (ReferenceNode reference in nodeToImport.References)
		{
			ReferenceNode referenceNode = new ReferenceNode();
			referenceNode.ReferenceTypeId = Translate(reference.ReferenceTypeId, namespaceUris, m_namespaceUris);
			referenceNode.IsInverse = reference.IsInverse;
			referenceNode.TargetId = Translate(reference.TargetId, namespaceUris, serverUris, m_namespaceUris, m_serverUris);
			node.References.Add(referenceNode);
		}
		return node;
	}

	private object ImportValue(object value, NamespaceTable namespaceUris, StringTable serverUris)
	{
		if (value is Array array)
		{
			Type elementType = array.GetType().GetElementType();
			if (elementType != typeof(NodeId) && elementType != typeof(ExpandedNodeId) && elementType != typeof(object) && elementType != typeof(ExtensionObject))
			{
				return array;
			}
			Array array2 = Array.CreateInstance(elementType, array.Length);
			for (int i = 0; i < array.Length; i++)
			{
				array2.SetValue(ImportValue(array.GetValue(i), namespaceUris, serverUris), i);
			}
			return array2;
		}
		NodeId nodeId = value as NodeId;
		if (nodeId != null)
		{
			return Import(nodeId, namespaceUris);
		}
		ExpandedNodeId expandedNodeId = value as ExpandedNodeId;
		if (expandedNodeId != null)
		{
			return Import(expandedNodeId, namespaceUris, serverUris);
		}
		if (value is ExtensionObject extension && ExtensionObject.ToEncodeable(extension) is Argument argument)
		{
			argument.DataType = Import(argument.DataType, namespaceUris);
		}
		return value;
	}

	public NodeId Export(NodeId nodeId, NamespaceTable namespaceUris)
	{
		return Translate(nodeId, m_namespaceUris, namespaceUris);
	}

	public NodeId Import(NodeId nodeId, NamespaceTable namespaceUris)
	{
		return Translate(nodeId, namespaceUris, m_namespaceUris);
	}

	public ExpandedNodeId Export(ExpandedNodeId nodeId, NamespaceTable namespaceUris, StringTable serverUris)
	{
		return Translate(nodeId, m_namespaceUris, m_serverUris, namespaceUris, serverUris);
	}

	public ExpandedNodeId Import(ExpandedNodeId nodeId, NamespaceTable namespaceUris, StringTable serverUris)
	{
		return Translate(nodeId, namespaceUris, serverUris, m_namespaceUris, m_serverUris);
	}

	private static NodeId Translate(NodeId nodeId, NamespaceTable targetNamespaceUris, NamespaceTable sourceNamespaceUris)
	{
		if (targetNamespaceUris == null)
		{
			throw new ArgumentNullException("targetNamespaceUris");
		}
		if (sourceNamespaceUris == null)
		{
			throw new ArgumentNullException("sourceNamespaceUris");
		}
		if (NodeId.IsNull(nodeId))
		{
			return nodeId;
		}
		ushort namespaceIndex = 0;
		if (nodeId.NamespaceIndex > 0)
		{
			string value = sourceNamespaceUris.GetString(nodeId.NamespaceIndex);
			int num = targetNamespaceUris.GetIndex(value);
			if (num == -1)
			{
				num = targetNamespaceUris.Append(value);
			}
			namespaceIndex = (ushort)num;
		}
		return new NodeId(nodeId.Identifier, namespaceIndex);
	}

	private static QualifiedName Translate(QualifiedName qname, NamespaceTable targetNamespaceUris, NamespaceTable sourceNamespaceUris)
	{
		if (targetNamespaceUris == null)
		{
			throw new ArgumentNullException("targetNamespaceUris");
		}
		if (sourceNamespaceUris == null)
		{
			throw new ArgumentNullException("sourceNamespaceUris");
		}
		if (QualifiedName.IsNull(qname))
		{
			return qname;
		}
		ushort namespaceIndex = 0;
		if (qname.NamespaceIndex > 0)
		{
			string text = sourceNamespaceUris.GetString(qname.NamespaceIndex);
			if (text == null)
			{
				return qname;
			}
			int num = targetNamespaceUris.GetIndex(text);
			if (num == -1)
			{
				num = targetNamespaceUris.Append(text);
			}
			namespaceIndex = (ushort)num;
		}
		return new QualifiedName(qname.Name, namespaceIndex);
	}

	private static ExpandedNodeId Translate(ExpandedNodeId nodeId, NamespaceTable targetNamespaceUris, StringTable targetServerUris, NamespaceTable sourceNamespaceUris, StringTable sourceServerUris)
	{
		if (targetNamespaceUris == null)
		{
			throw new ArgumentNullException("targetNamespaceUris");
		}
		if (sourceNamespaceUris == null)
		{
			throw new ArgumentNullException("sourceNamespaceUris");
		}
		if (nodeId.ServerIndex != 0)
		{
			if (targetServerUris == null)
			{
				throw new ArgumentNullException("targetServerUris");
			}
			if (sourceServerUris == null)
			{
				throw new ArgumentNullException("sourceServerUris");
			}
		}
		if (NodeId.IsNull(nodeId))
		{
			return nodeId;
		}
		if (!nodeId.IsAbsolute)
		{
			return Translate((NodeId)nodeId, targetNamespaceUris, sourceNamespaceUris);
		}
		string text = nodeId.NamespaceUri;
		if (nodeId.ServerIndex != 0)
		{
			if (string.IsNullOrEmpty(text))
			{
				text = sourceNamespaceUris.GetString(nodeId.NamespaceIndex);
			}
			string value = sourceServerUris.GetString(nodeId.ServerIndex);
			int num = targetServerUris.GetIndex(value);
			if (num == -1)
			{
				num = targetServerUris.Append(value);
			}
			return new ExpandedNodeId(new NodeId(nodeId.Identifier, 0), text, (uint)num);
		}
		ushort namespaceIndex = 0;
		if (!string.IsNullOrEmpty(text))
		{
			int num2 = targetNamespaceUris.GetIndex(text);
			if (num2 == -1)
			{
				num2 = targetNamespaceUris.Append(text);
			}
			namespaceIndex = (ushort)num2;
		}
		return new NodeId(nodeId.Identifier, namespaceIndex);
	}
}
