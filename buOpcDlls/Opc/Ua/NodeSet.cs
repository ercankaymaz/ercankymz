// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeSet
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[KnownType(typeof (ObjectNode))]
[KnownType(typeof (ObjectTypeNode))]
[KnownType(typeof (VariableNode))]
[KnownType(typeof (VariableTypeNode))]
[KnownType(typeof (MethodNode))]
[KnownType(typeof (DataTypeNode))]
[KnownType(typeof (ReferenceTypeNode))]
[KnownType(typeof (ViewNode))]
[ComVisible(true)]
public class NodeSet : IEnumerable<Node>, IEnumerable
{
  private NamespaceTable m_namespaceUris;
  private StringTable m_serverUris;
  private Dictionary<NodeId, Node> m_nodes;

  public NodeSet()
  {
    this.m_namespaceUris = new NamespaceTable();
    this.m_serverUris = new StringTable();
    this.m_nodes = new Dictionary<NodeId, Node>();
  }

  public static NodeSet Read(Stream istrm)
  {
    using (XmlReader reader = XmlReader.Create(istrm, Utils.DefaultXmlReaderSettings()))
      return new DataContractSerializer(typeof (NodeSet)).ReadObject(reader) as NodeSet;
  }

  public void Write(Stream istrm)
  {
    XmlWriter writer = XmlWriter.Create(istrm, Utils.DefaultXmlWriterSettings());
    try
    {
      new DataContractSerializer(typeof (NodeSet)).WriteObject(writer, (object) this);
    }
    finally
    {
      writer.Flush();
      writer.Dispose();
    }
  }

  public IEnumerator<Node> GetEnumerator()
  {
    return (IEnumerator<Node>) new List<Node>((IEnumerable<Node>) this.m_nodes.Values).GetEnumerator();
  }

  IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();

  public void Add(Node node)
  {
    if (node == null)
      throw new ArgumentNullException(nameof (node));
    if (NodeId.IsNull(node.NodeId))
      throw new ArgumentException("A non-null NodeId must be specified.");
    if (this.m_nodes.ContainsKey(node.NodeId))
      throw new ArgumentException(Utils.Format("NodeID {0} already exists for node: {1}", (object) node.NodeId, (object) node));
    this.m_nodes.Add(node.NodeId, node);
  }

  private void TranslateArrayValue(
    Array array,
    BuiltInType elementType,
    NamespaceTable namespaceUris,
    StringTable serverUris)
  {
    if (array == null)
      return;
    int[] numArray1 = new int[array.Rank];
    for (int dimension = 0; dimension < numArray1.Length; ++dimension)
      numArray1[dimension] = array.GetLength(dimension);
    int length = array.Length;
    int[] numArray2 = new int[numArray1.Length];
    for (int index1 = 0; index1 < length; ++index1)
    {
      int num = length;
      for (int index2 = 0; index2 < numArray2.Length; ++index2)
      {
        num /= numArray1[index2];
        numArray2[index2] = index1 / num % numArray1[index2];
      }
      object obj1 = array.GetValue(numArray2);
      if (obj1 != null)
      {
        if (elementType == BuiltInType.Variant)
          obj1 = ((Variant) obj1).Value;
        object obj2 = this.TranslateValue(obj1, namespaceUris, serverUris);
        if (elementType == BuiltInType.Variant)
          obj2 = (object) new Variant(obj2);
        array.SetValue(obj2, numArray2);
      }
    }
  }

  private object TranslateValue(object value, NamespaceTable namespaceUris, StringTable serverUris)
  {
    TypeInfo typeInfo = TypeInfo.Construct(value);
    if (typeInfo == null)
      return value;
    if (typeInfo.ValueRank > 0)
    {
      this.TranslateArrayValue((Array) value, typeInfo.BuiltInType, namespaceUris, serverUris);
      return value;
    }
    switch (typeInfo.BuiltInType)
    {
      case BuiltInType.NodeId:
        return (object) NodeSet.Translate((NodeId) value, this.m_namespaceUris, namespaceUris);
      case BuiltInType.ExpandedNodeId:
        return (object) NodeSet.Translate((ExpandedNodeId) value, this.m_namespaceUris, this.m_serverUris, namespaceUris, serverUris);
      case BuiltInType.QualifiedName:
        return (object) NodeSet.Translate((QualifiedName) value, this.m_namespaceUris, namespaceUris);
      case BuiltInType.ExtensionObject:
        if (ExtensionObject.ToEncodeable((ExtensionObject) value) is Argument encodeable)
          encodeable.DataType = NodeSet.Translate(encodeable.DataType, this.m_namespaceUris, namespaceUris);
        return value;
      default:
        return value;
    }
  }

  public Node Add(ILocalNode nodeToExport, NamespaceTable namespaceUris, StringTable serverUris)
  {
    Node node = Node.Copy(nodeToExport);
    node.NodeId = NodeSet.Translate(nodeToExport.NodeId, this.m_namespaceUris, namespaceUris);
    node.BrowseName = NodeSet.Translate(nodeToExport.BrowseName, this.m_namespaceUris, namespaceUris);
    if (nodeToExport is VariableNode variableNode1)
    {
      VariableNode variableNode = (VariableNode) node;
      object obj = this.TranslateValue(variableNode.Value.Value, namespaceUris, serverUris);
      variableNode.Value = new Variant(obj);
      variableNode.DataType = NodeSet.Translate(variableNode1.DataType, this.m_namespaceUris, namespaceUris);
    }
    if (nodeToExport is VariableTypeNode variableTypeNode1)
    {
      VariableTypeNode variableTypeNode = (VariableTypeNode) node;
      object obj = this.TranslateValue(variableTypeNode.Value.Value, namespaceUris, serverUris);
      variableTypeNode.Value = new Variant(obj);
      variableTypeNode.DataType = NodeSet.Translate(variableTypeNode1.DataType, this.m_namespaceUris, namespaceUris);
    }
    foreach (IReference reference in (IEnumerable<IReference>) nodeToExport.References)
      node.References.Add(new ReferenceNode()
      {
        ReferenceTypeId = NodeSet.Translate(reference.ReferenceTypeId, this.m_namespaceUris, namespaceUris),
        IsInverse = reference.IsInverse,
        TargetId = NodeSet.Translate(reference.TargetId, this.m_namespaceUris, this.m_serverUris, namespaceUris, serverUris)
      });
    this.Add(node);
    return node;
  }

  public void AddReference(
    Node node,
    ReferenceNode referenceToExport,
    NamespaceTable namespaceUris,
    StringTable serverUris)
  {
    node.References.Add(new ReferenceNode()
    {
      ReferenceTypeId = NodeSet.Translate(referenceToExport.ReferenceTypeId, this.m_namespaceUris, namespaceUris),
      IsInverse = referenceToExport.IsInverse,
      TargetId = NodeSet.Translate(referenceToExport.TargetId, this.m_namespaceUris, this.m_serverUris, namespaceUris, serverUris)
    });
  }

  public bool Remove(NodeId nodeId) => this.m_nodes.Remove(nodeId);

  public bool Contains(NodeId nodeId) => this.m_nodes.ContainsKey(nodeId);

  public Node Find(NodeId nodeId)
  {
    Node node = (Node) null;
    return this.m_nodes.TryGetValue(nodeId, out node) ? node : (Node) null;
  }

  public Node Find(NodeId nodeId, NamespaceTable namespaceUris)
  {
    if (nodeId == (object) null)
      throw new ArgumentNullException(nameof (nodeId));
    if (namespaceUris == null)
      throw new ArgumentNullException(nameof (namespaceUris));
    string str = namespaceUris.GetString((uint) nodeId.NamespaceIndex);
    if (str == null)
      return (Node) null;
    int index = this.m_namespaceUris.GetIndex(str);
    if (index < 0)
      return (Node) null;
    NodeId key = new NodeId(nodeId.Identifier, (ushort) index);
    Node node = (Node) null;
    return this.m_nodes.TryGetValue(key, out node) ? node : (Node) null;
  }

  public Node Copy(Node nodeToImport, NamespaceTable namespaceUris, StringTable serverUris)
  {
    Node node = Node.Copy((ILocalNode) nodeToImport);
    node.NodeId = NodeSet.Translate(nodeToImport.NodeId, namespaceUris, this.m_namespaceUris);
    node.BrowseName = NodeSet.Translate(nodeToImport.BrowseName, namespaceUris, this.m_namespaceUris);
    Variant variant1;
    if (nodeToImport is VariableNode variableNode)
    {
      VariableNode variableNode1 = (VariableNode) node;
      variableNode1.DataType = NodeSet.Translate(variableNode.DataType, namespaceUris, this.m_namespaceUris);
      variant1 = variableNode.Value;
      if (variant1.Value != null)
      {
        VariableNode variableNode2 = variableNode1;
        variant1 = variableNode.Value;
        Variant variant2 = new Variant(this.ImportValue(variant1.Value, namespaceUris, serverUris));
        variableNode2.Value = variant2;
      }
    }
    if (nodeToImport is VariableTypeNode variableTypeNode)
    {
      VariableTypeNode variableTypeNode1 = (VariableTypeNode) node;
      variableTypeNode1.DataType = NodeSet.Translate(variableTypeNode.DataType, namespaceUris, this.m_namespaceUris);
      variant1 = variableTypeNode.Value;
      if (variant1.Value != null)
      {
        VariableTypeNode variableTypeNode2 = variableTypeNode1;
        variant1 = variableTypeNode.Value;
        Variant variant3 = new Variant(this.ImportValue(variant1.Value, namespaceUris, serverUris));
        variableTypeNode2.Value = variant3;
      }
    }
    foreach (ReferenceNode reference in (List<ReferenceNode>) nodeToImport.References)
      node.References.Add(new ReferenceNode()
      {
        ReferenceTypeId = NodeSet.Translate(reference.ReferenceTypeId, namespaceUris, this.m_namespaceUris),
        IsInverse = reference.IsInverse,
        TargetId = NodeSet.Translate(reference.TargetId, namespaceUris, serverUris, this.m_namespaceUris, this.m_serverUris)
      });
    return node;
  }

  private object ImportValue(object value, NamespaceTable namespaceUris, StringTable serverUris)
  {
    if (value is Array array)
    {
      Type elementType = array.GetType().GetElementType();
      if (elementType != typeof (NodeId) && elementType != typeof (ExpandedNodeId) && elementType != typeof (object) && elementType != typeof (ExtensionObject))
        return (object) array;
      Array instance = Array.CreateInstance(elementType, array.Length);
      for (int index = 0; index < array.Length; ++index)
        instance.SetValue(this.ImportValue(array.GetValue(index), namespaceUris, serverUris), index);
      return (object) instance;
    }
    NodeId nodeId1 = value as NodeId;
    if (nodeId1 != (object) null)
      return (object) this.Import(nodeId1, namespaceUris);
    ExpandedNodeId nodeId2 = value as ExpandedNodeId;
    if (nodeId2 != (object) null)
      return (object) this.Import(nodeId2, namespaceUris, serverUris);
    if (value is ExtensionObject extension && ExtensionObject.ToEncodeable(extension) is Argument encodeable)
      encodeable.DataType = this.Import(encodeable.DataType, namespaceUris);
    return value;
  }

  public NodeId Export(NodeId nodeId, NamespaceTable namespaceUris)
  {
    return NodeSet.Translate(nodeId, this.m_namespaceUris, namespaceUris);
  }

  public NodeId Import(NodeId nodeId, NamespaceTable namespaceUris)
  {
    return NodeSet.Translate(nodeId, namespaceUris, this.m_namespaceUris);
  }

  public ExpandedNodeId Export(
    ExpandedNodeId nodeId,
    NamespaceTable namespaceUris,
    StringTable serverUris)
  {
    return NodeSet.Translate(nodeId, this.m_namespaceUris, this.m_serverUris, namespaceUris, serverUris);
  }

  public ExpandedNodeId Import(
    ExpandedNodeId nodeId,
    NamespaceTable namespaceUris,
    StringTable serverUris)
  {
    return NodeSet.Translate(nodeId, namespaceUris, serverUris, this.m_namespaceUris, this.m_serverUris);
  }

  [DataMember(Name = "NamespaceUris", Order = 1)]
  internal StringCollection NamespaceUris
  {
    get => new StringCollection((IEnumerable<string>) this.m_namespaceUris.ToArray());
    set
    {
      if (value == null)
        this.m_namespaceUris = new NamespaceTable();
      else
        this.m_namespaceUris = new NamespaceTable((IEnumerable<string>) value);
    }
  }

  [DataMember(Name = "ServerUris", Order = 2)]
  internal StringCollection ServerUris
  {
    get => new StringCollection((IEnumerable<string>) this.m_serverUris.ToArray());
    set
    {
      if (value == null)
        this.m_serverUris = new StringTable();
      else
        this.m_serverUris = new StringTable((IEnumerable<string>) value);
    }
  }

  [DataMember(Name = "Nodes", Order = 3)]
  internal NodeCollection Nodes
  {
    get => new NodeCollection((IEnumerable<Node>) this.m_nodes.Values);
    set
    {
      this.m_nodes = new Dictionary<NodeId, Node>();
      if (value == null)
        return;
      foreach (Node node in (List<Node>) value)
        this.m_nodes[node.NodeId] = node;
    }
  }

  private static NodeId Translate(
    NodeId nodeId,
    NamespaceTable targetNamespaceUris,
    NamespaceTable sourceNamespaceUris)
  {
    if (targetNamespaceUris == null)
      throw new ArgumentNullException(nameof (targetNamespaceUris));
    if (sourceNamespaceUris == null)
      throw new ArgumentNullException(nameof (sourceNamespaceUris));
    if (NodeId.IsNull(nodeId))
      return nodeId;
    ushort namespaceIndex = 0;
    if (nodeId.NamespaceIndex > (ushort) 0)
    {
      string str = sourceNamespaceUris.GetString((uint) nodeId.NamespaceIndex);
      int num = targetNamespaceUris.GetIndex(str);
      if (num == -1)
        num = targetNamespaceUris.Append(str);
      namespaceIndex = (ushort) num;
    }
    return new NodeId(nodeId.Identifier, namespaceIndex);
  }

  private static QualifiedName Translate(
    QualifiedName qname,
    NamespaceTable targetNamespaceUris,
    NamespaceTable sourceNamespaceUris)
  {
    if (targetNamespaceUris == null)
      throw new ArgumentNullException(nameof (targetNamespaceUris));
    if (sourceNamespaceUris == null)
      throw new ArgumentNullException(nameof (sourceNamespaceUris));
    if (QualifiedName.IsNull(qname))
      return qname;
    ushort namespaceIndex = 0;
    if (qname.NamespaceIndex > (ushort) 0)
    {
      string str = sourceNamespaceUris.GetString((uint) qname.NamespaceIndex);
      if (str == null)
        return qname;
      int num = targetNamespaceUris.GetIndex(str);
      if (num == -1)
        num = targetNamespaceUris.Append(str);
      namespaceIndex = (ushort) num;
    }
    return new QualifiedName(qname.Name, namespaceIndex);
  }

  private static ExpandedNodeId Translate(
    ExpandedNodeId nodeId,
    NamespaceTable targetNamespaceUris,
    StringTable targetServerUris,
    NamespaceTable sourceNamespaceUris,
    StringTable sourceServerUris)
  {
    if (targetNamespaceUris == null)
      throw new ArgumentNullException(nameof (targetNamespaceUris));
    if (sourceNamespaceUris == null)
      throw new ArgumentNullException(nameof (sourceNamespaceUris));
    if (nodeId.ServerIndex > 0U)
    {
      if (targetServerUris == null)
        throw new ArgumentNullException(nameof (targetServerUris));
      if (sourceServerUris == null)
        throw new ArgumentNullException(nameof (sourceServerUris));
    }
    if (NodeId.IsNull(nodeId))
      return nodeId;
    if (!nodeId.IsAbsolute)
      return (ExpandedNodeId) NodeSet.Translate((NodeId) nodeId, targetNamespaceUris, sourceNamespaceUris);
    string namespaceUri = nodeId.NamespaceUri;
    if (nodeId.ServerIndex > 0U)
    {
      if (string.IsNullOrEmpty(namespaceUri))
        namespaceUri = sourceNamespaceUris.GetString((uint) nodeId.NamespaceIndex);
      string str = sourceServerUris.GetString(nodeId.ServerIndex);
      int serverIndex = targetServerUris.GetIndex(str);
      if (serverIndex == -1)
        serverIndex = targetServerUris.Append(str);
      return new ExpandedNodeId(new NodeId(nodeId.Identifier, (ushort) 0), namespaceUri, (uint) serverIndex);
    }
    ushort namespaceIndex = 0;
    if (!string.IsNullOrEmpty(namespaceUri))
    {
      int num = targetNamespaceUris.GetIndex(namespaceUri);
      if (num == -1)
        num = targetNamespaceUris.Append(namespaceUri);
      namespaceIndex = (ushort) num;
    }
    return (ExpandedNodeId) new NodeId(nodeId.Identifier, namespaceIndex);
  }
}
