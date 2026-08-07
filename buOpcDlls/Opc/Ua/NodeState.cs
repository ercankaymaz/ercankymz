// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeState
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Export;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public abstract class NodeState : IDisposable, IFormattable, ICloneable
{
  public NodeStateValidateHandler OnValidate;
  public NodeStateChangedHandler OnStateChanged;
  public NodeStateReferenceAdded OnReferenceAdded;
  public NodeStateReferenceRemoved OnReferenceRemoved;
  public NodeStateReportEventHandler OnReportEvent;
  public NodeStateConditionRefreshEventHandler OnConditionRefresh;
  public NodeStateCreateBrowserEventHandler OnCreateBrowser;
  public NodeStatePopulateBrowserEventHandler OnPopulateBrowser;
  public NodeAttributeEventHandler<NodeId> OnReadNodeId;
  public NodeAttributeEventHandler<NodeId> OnWriteNodeId;
  public NodeAttributeEventHandler<NodeClass> OnReadNodeClass;
  public NodeAttributeEventHandler<NodeClass> OnWriteNodeClass;
  public NodeAttributeEventHandler<QualifiedName> OnReadBrowseName;
  public NodeAttributeEventHandler<QualifiedName> OnWriteBrowseName;
  public NodeAttributeEventHandler<LocalizedText> OnReadDisplayName;
  public NodeAttributeEventHandler<LocalizedText> OnWriteDisplayName;
  public NodeAttributeEventHandler<LocalizedText> OnReadDescription;
  public NodeAttributeEventHandler<LocalizedText> OnWriteDescription;
  public NodeAttributeEventHandler<AttributeWriteMask> OnReadWriteMask;
  public NodeAttributeEventHandler<AttributeWriteMask> OnWriteWriteMask;
  public NodeAttributeEventHandler<AttributeWriteMask> OnReadUserWriteMask;
  public NodeAttributeEventHandler<AttributeWriteMask> OnWriteUserWriteMask;
  public NodeAttributeEventHandler<RolePermissionTypeCollection> OnReadRolePermissions;
  public NodeAttributeEventHandler<RolePermissionTypeCollection> OnWriteRolePermissions;
  public NodeAttributeEventHandler<RolePermissionTypeCollection> OnReadUserRolePermissions;
  public NodeAttributeEventHandler<RolePermissionTypeCollection> OnWriteUserRolePermissions;
  public NodeAttributeEventHandler<AccessRestrictionType> OnReadAccessRestrictions;
  public NodeAttributeEventHandler<AccessRestrictionType> OnWriteAccessRestrictions;
  protected List<BaseInstanceState> m_children;
  protected NodeStateChangeMasks m_changeMasks;
  private object m_handle;
  private string m_symbolicName;
  private NodeId m_nodeId;
  private NodeClass m_nodeClass;
  private QualifiedName m_browseName;
  private LocalizedText m_displayName;
  private LocalizedText m_description;
  private AttributeWriteMask m_writeMask;
  private AttributeWriteMask m_userWriteMask;
  private RolePermissionTypeCollection m_rolePermissions;
  private RolePermissionTypeCollection m_userRolePermissions;
  private AccessRestrictionType m_accessRestrictions;
  private IReferenceDictionary<object> m_references;
  private int m_areEventsMonitored;
  private bool m_initialized;
  private List<NodeState.Notifier> m_notifiers;
  private XmlElement[] m_extensions;

  public string Specification { get; set; }

  public string NodeSetDocumentation { get; set; }

  protected NodeState(NodeClass nodeClass) => this.m_nodeClass = nodeClass;

  public virtual void Dispose() => this.Dispose(true);

  protected virtual void Dispose(bool disposing)
  {
  }

  public virtual object Clone() => throw new NotImplementedException();

  protected object CloneChildren(NodeState clone)
  {
    if (this.m_children != null)
    {
      clone.m_children = new List<BaseInstanceState>(this.m_children.Count);
      for (int index = 0; index < this.m_children.Count; ++index)
      {
        BaseInstanceState baseInstanceState = (BaseInstanceState) this.m_children[index].Clone();
        clone.m_children.Add(baseInstanceState);
      }
    }
    clone.m_changeMasks = NodeStateChangeMasks.None;
    return (object) clone;
  }

  protected virtual void Initialize(ISystemContext context)
  {
  }

  protected virtual void InitializeOptionalChildren(ISystemContext context)
  {
  }

  public virtual void Initialize(ISystemContext context, string initializationString)
  {
    if (initializationString.StartsWith("<"))
    {
      using (StringReader input = new StringReader(initializationString))
        this.LoadFromXml(context, (TextReader) input);
    }
    else
    {
      using (MemoryStream istrm = new MemoryStream(Convert.FromBase64String(initializationString)))
        this.LoadAsBinary(context, (Stream) istrm);
    }
  }

  protected virtual void Initialize(ISystemContext context, NodeState source)
  {
    this.m_handle = source.m_handle;
    this.m_symbolicName = source.m_symbolicName;
    this.m_nodeId = source.m_nodeId;
    this.m_nodeClass = source.m_nodeClass;
    this.m_browseName = source.m_browseName;
    this.m_displayName = source.m_displayName;
    this.m_description = source.m_description;
    this.m_writeMask = source.m_writeMask;
    this.m_children = (List<BaseInstanceState>) null;
    this.m_references = (IReferenceDictionary<object>) null;
    this.m_changeMasks = NodeStateChangeMasks.None;
    this.m_initialized = true;
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    source.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
    {
      BaseInstanceState source1 = children[index];
      BaseInstanceState child = this.CreateChild(context, source1.BrowseName);
      if (child == null)
      {
        child = (BaseInstanceState) source1.Clone();
        this.AddChild(child);
      }
      child.Initialize(context, (NodeState) source1);
    }
    List<IReference> references = new List<IReference>();
    source.GetReferences(context, (IList<IReference>) references);
    for (int index = 0; index < references.Count; ++index)
    {
      IReference reference = references[index];
      this.AddReference(reference.ReferenceTypeId, reference.IsInverse, reference.TargetId);
    }
  }

  public override string ToString() => this.ToString((string) null, (IFormatProvider) null);

  public string ToString(string format, IFormatProvider formatProvider)
  {
    if (format != null)
      throw new FormatException(Utils.Format("Invalid format string: '{0}'.", (object) format));
    return !QualifiedName.IsNull(this.m_browseName) ? Utils.Format("[{0}]{1}", (object) this.m_nodeClass, (object) this.m_displayName) : Utils.Format("[{0}]{1}", (object) this.m_nodeClass, (object) this.m_nodeId);
  }

  public object Handle
  {
    get => this.m_handle;
    set => this.m_handle = value;
  }

  public NodeStateChangeMasks ChangeMasks
  {
    get => this.m_changeMasks;
    protected set => this.m_changeMasks = value;
  }

  public string SymbolicName
  {
    get => this.m_symbolicName;
    set => this.m_symbolicName = value;
  }

  public NodeId NodeId
  {
    get => this.m_nodeId;
    set
    {
      if ((object) this.m_nodeId != (object) value)
        this.m_changeMasks |= NodeStateChangeMasks.NonValue;
      this.m_nodeId = value;
    }
  }

  public NodeClass NodeClass => this.m_nodeClass;

  public QualifiedName BrowseName
  {
    get => this.m_browseName;
    set
    {
      if ((object) this.m_browseName != (object) value)
        this.m_changeMasks |= NodeStateChangeMasks.NonValue;
      this.m_browseName = value;
    }
  }

  public LocalizedText DisplayName
  {
    get => this.m_displayName;
    set
    {
      if ((object) this.m_displayName != (object) value)
        this.m_changeMasks |= NodeStateChangeMasks.NonValue;
      this.m_displayName = value;
    }
  }

  public LocalizedText Description
  {
    get => this.m_description;
    set
    {
      if ((object) this.m_description != (object) value)
        this.m_changeMasks |= NodeStateChangeMasks.NonValue;
      this.m_description = value;
    }
  }

  public AttributeWriteMask WriteMask
  {
    get => this.m_writeMask;
    set
    {
      if (this.m_writeMask != value)
        this.m_changeMasks |= NodeStateChangeMasks.NonValue;
      this.m_writeMask = value;
    }
  }

  public AttributeWriteMask UserWriteMask
  {
    get => this.m_userWriteMask;
    set
    {
      if (this.m_userWriteMask != value)
        this.m_changeMasks |= NodeStateChangeMasks.NonValue;
      this.m_userWriteMask = value;
    }
  }

  public RolePermissionTypeCollection RolePermissions
  {
    get => this.m_rolePermissions;
    set
    {
      if (this.m_rolePermissions != value)
        this.m_changeMasks |= NodeStateChangeMasks.NonValue;
      this.m_rolePermissions = value;
    }
  }

  public RolePermissionTypeCollection UserRolePermissions
  {
    get => this.m_userRolePermissions;
    set
    {
      if (this.m_userRolePermissions != value)
        this.m_changeMasks |= NodeStateChangeMasks.NonValue;
      this.m_userRolePermissions = value;
    }
  }

  public AccessRestrictionType AccessRestrictions
  {
    get => this.m_accessRestrictions;
    set
    {
      if (this.m_accessRestrictions != value)
        this.m_changeMasks |= NodeStateChangeMasks.NonValue;
      this.m_accessRestrictions = value;
    }
  }

  public XmlElement[] Extensions
  {
    get => this.m_extensions;
    set => this.m_extensions = value;
  }

  public IList<string> Categories { get; set; }

  public ReleaseStatus ReleaseStatus { get; set; }

  public void Export(ISystemContext context, NodeTable table)
  {
    Node node;
    switch (this.NodeClass)
    {
      case NodeClass.Object:
        node = (Node) new ObjectNode();
        break;
      case NodeClass.Variable:
        node = (Node) new VariableNode();
        break;
      case NodeClass.Method:
        node = (Node) new MethodNode();
        break;
      case NodeClass.ObjectType:
        node = (Node) new ObjectTypeNode();
        break;
      case NodeClass.VariableType:
        node = (Node) new VariableTypeNode();
        break;
      case NodeClass.ReferenceType:
        node = (Node) new ReferenceTypeNode();
        break;
      case NodeClass.DataType:
        node = (Node) new DataTypeNode();
        break;
      case NodeClass.View:
        node = (Node) new ViewNode();
        break;
      default:
        node = new Node();
        break;
    }
    this.Export(context, node);
    List<IReference> references = new List<IReference>();
    this.GetReferences(context, (IList<IReference>) references);
    for (int index = 0; index < references.Count; ++index)
      node.ReferenceTable.Add(references[index]);
    table.Attach((ILocalNode) node);
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
      children[index].Export(context, table);
  }

  protected virtual void Export(ISystemContext context, Node node)
  {
    node.NodeId = this.NodeId;
    node.NodeClass = this.NodeClass;
    node.BrowseName = this.BrowseName;
    node.DisplayName = this.DisplayName;
    node.Description = this.Description;
    node.WriteMask = (uint) this.WriteMask;
    node.UserWriteMask = (uint) this.UserWriteMask;
  }

  public void SaveAsXml(ISystemContext context, Stream ostrm)
  {
    ServiceMessageContext context1 = new ServiceMessageContext()
    {
      NamespaceUris = context.NamespaceUris,
      ServerUris = context.ServerUris,
      Factory = context.EncodeableFactory
    };
    XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
    settings.CloseOutput = true;
    using (XmlWriter writer = XmlWriter.Create(ostrm, settings))
    {
      using (XmlEncoder encoder = new XmlEncoder(new XmlQualifiedName(this.SymbolicName, context.NamespaceUris.GetString((uint) this.BrowseName.NamespaceIndex)), writer, (IServiceMessageContext) context1))
      {
        encoder.SaveStringTable("NamespaceUris", "NamespaceUri", (StringTable) context.NamespaceUris);
        encoder.SaveStringTable("ServerUris", "ServerUri", context.ServerUris);
        this.Save(context, encoder);
        this.SaveReferences(context, encoder);
        this.SaveChildren(context, encoder);
        encoder.Close();
      }
    }
  }

  public void SaveAsBinary(ISystemContext context, Stream ostrm)
  {
    using (BinaryEncoder encoder = new BinaryEncoder(ostrm, (IServiceMessageContext) new ServiceMessageContext()
    {
      NamespaceUris = context.NamespaceUris,
      ServerUris = context.ServerUris,
      Factory = context.EncodeableFactory
    }, true))
    {
      encoder.SaveStringTable((StringTable) context.NamespaceUris);
      encoder.SaveStringTable(context.ServerUris);
      NodeState.AttributesToSave attributesToSave = this.GetAttributesToSave(context);
      encoder.WriteUInt32((string) null, (uint) attributesToSave);
      this.Save(context, encoder, attributesToSave);
      this.SaveReferences(context, encoder);
      this.SaveChildren(context, encoder);
      encoder.Close();
    }
  }

  public void SaveAsBinary(ISystemContext context, BinaryEncoder encoder)
  {
    NodeState.AttributesToSave attributesToSave = this.GetAttributesToSave(context);
    encoder.WriteUInt32((string) null, (uint) attributesToSave);
    this.Save(context, encoder, attributesToSave);
    this.SaveReferences(context, encoder);
    this.SaveChildren(context, encoder);
  }

  public void LoadAsBinary(ISystemContext context, Stream istrm)
  {
    BinaryDecoder decoder = new BinaryDecoder(istrm, (IServiceMessageContext) new ServiceMessageContext()
    {
      NamespaceUris = context.NamespaceUris,
      ServerUris = context.ServerUris,
      Factory = context.EncodeableFactory
    });
    NamespaceTable namespaceUris = new NamespaceTable();
    if (!decoder.LoadStringTable((StringTable) namespaceUris))
      namespaceUris = (NamespaceTable) null;
    StringTable stringTable = new StringTable();
    if (namespaceUris != null && namespaceUris.Count > 1)
      stringTable.Append(namespaceUris.GetString(1U));
    if (!decoder.LoadStringTable(stringTable))
      stringTable = (StringTable) null;
    decoder.SetMappingTables(namespaceUris, stringTable);
    NodeState.AttributesToSave attributesToLoad = (NodeState.AttributesToSave) decoder.ReadUInt32((string) null);
    this.Update(context, decoder, attributesToLoad);
    this.UpdateReferences(context, decoder);
    this.UpdateChildren(context, decoder);
  }

  public virtual NodeState.AttributesToSave GetAttributesToSave(ISystemContext context)
  {
    NodeState.AttributesToSave attributesToSave1 = NodeState.AttributesToSave.None;
    if (!string.IsNullOrEmpty(this.m_symbolicName) && (this.m_browseName == (QualifiedName) null || this.m_symbolicName != this.m_browseName.Name))
      attributesToSave1 |= NodeState.AttributesToSave.SymbolicName;
    NodeState.AttributesToSave attributesToSave2 = attributesToSave1 | NodeState.AttributesToSave.NodeClass;
    if (!NodeId.IsNull(this.m_nodeId))
      attributesToSave2 |= NodeState.AttributesToSave.NodeId;
    if (!QualifiedName.IsNull(this.m_browseName))
      attributesToSave2 |= NodeState.AttributesToSave.BrowseName;
    if (!LocalizedText.IsNullOrEmpty(this.m_displayName) && (this.m_browseName == (QualifiedName) null || !string.IsNullOrEmpty(this.m_displayName.Locale) || this.m_displayName.Text != this.m_browseName.Name))
      attributesToSave2 |= NodeState.AttributesToSave.DisplayName;
    if (!LocalizedText.IsNullOrEmpty(this.m_description))
      attributesToSave2 |= NodeState.AttributesToSave.Description;
    if (this.m_writeMask != AttributeWriteMask.None)
      attributesToSave2 |= NodeState.AttributesToSave.WriteMask;
    if (this.m_userWriteMask != AttributeWriteMask.None)
      attributesToSave2 |= NodeState.AttributesToSave.UserWriteMask;
    return attributesToSave2;
  }

  public virtual void Save(
    ISystemContext context,
    BinaryEncoder encoder,
    NodeState.AttributesToSave attributesToSave)
  {
    encoder.WriteEnumerated((string) null, (Enum) this.m_nodeClass);
    if ((attributesToSave & NodeState.AttributesToSave.SymbolicName) != NodeState.AttributesToSave.None)
      encoder.WriteString((string) null, this.m_symbolicName);
    if ((attributesToSave & NodeState.AttributesToSave.BrowseName) != NodeState.AttributesToSave.None)
      encoder.WriteQualifiedName((string) null, this.m_browseName);
    if ((attributesToSave & NodeState.AttributesToSave.NodeId) != NodeState.AttributesToSave.None)
      encoder.WriteNodeId((string) null, this.m_nodeId);
    if ((attributesToSave & NodeState.AttributesToSave.DisplayName) != NodeState.AttributesToSave.None)
      encoder.WriteLocalizedText((string) null, this.m_displayName);
    if ((attributesToSave & NodeState.AttributesToSave.Description) != NodeState.AttributesToSave.None)
      encoder.WriteLocalizedText((string) null, this.m_description);
    if ((attributesToSave & NodeState.AttributesToSave.WriteMask) != NodeState.AttributesToSave.None)
      encoder.WriteEnumerated((string) null, (Enum) this.m_writeMask);
    if ((attributesToSave & NodeState.AttributesToSave.UserWriteMask) == NodeState.AttributesToSave.None)
      return;
    encoder.WriteEnumerated((string) null, (Enum) this.m_userWriteMask);
  }

  public virtual void Update(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState.AttributesToSave attributesToLoad)
  {
    if ((attributesToLoad & NodeState.AttributesToSave.NodeClass) != NodeState.AttributesToSave.None)
      this.m_nodeClass = (NodeClass) decoder.ReadEnumerated((string) null, typeof (NodeClass));
    if ((attributesToLoad & NodeState.AttributesToSave.SymbolicName) != NodeState.AttributesToSave.None)
      this.m_symbolicName = decoder.ReadString((string) null);
    if ((attributesToLoad & NodeState.AttributesToSave.BrowseName) != NodeState.AttributesToSave.None)
      this.m_browseName = decoder.ReadQualifiedName((string) null);
    if (string.IsNullOrEmpty(this.m_symbolicName) && this.m_browseName != (QualifiedName) null)
      this.m_symbolicName = this.m_browseName.Name;
    if ((attributesToLoad & NodeState.AttributesToSave.NodeId) != NodeState.AttributesToSave.None)
      this.m_nodeId = decoder.ReadNodeId((string) null);
    if ((attributesToLoad & NodeState.AttributesToSave.DisplayName) != NodeState.AttributesToSave.None)
      this.m_displayName = decoder.ReadLocalizedText((string) null);
    if (LocalizedText.IsNullOrEmpty(this.m_displayName) && this.m_browseName != (QualifiedName) null)
      this.m_displayName = (LocalizedText) this.m_browseName.Name;
    if ((attributesToLoad & NodeState.AttributesToSave.Description) != NodeState.AttributesToSave.None)
      this.m_description = decoder.ReadLocalizedText((string) null);
    if ((attributesToLoad & NodeState.AttributesToSave.WriteMask) != NodeState.AttributesToSave.None)
      this.m_writeMask = (AttributeWriteMask) decoder.ReadEnumerated((string) null, typeof (AttributeWriteMask));
    if ((attributesToLoad & NodeState.AttributesToSave.UserWriteMask) == NodeState.AttributesToSave.None)
      return;
    this.m_userWriteMask = (AttributeWriteMask) decoder.ReadEnumerated((string) null, typeof (AttributeWriteMask));
  }

  public virtual void SaveChildren(ISystemContext context, BinaryEncoder encoder)
  {
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    encoder.WriteInt32((string) null, children.Count);
    for (int index = 0; index < children.Count; ++index)
    {
      BaseInstanceState baseInstanceState = children[index];
      NodeState.AttributesToSave attributesToSave = baseInstanceState.GetAttributesToSave(context);
      encoder.WriteUInt32((string) null, (uint) attributesToSave);
      baseInstanceState.Save(context, encoder, attributesToSave);
      baseInstanceState.SaveReferences(context, encoder);
      baseInstanceState.SaveChildren(context, encoder);
    }
  }

  public virtual void UpdateChildren(ISystemContext context, BinaryDecoder decoder)
  {
    int num = decoder.ReadInt32((string) null);
    for (int index = 0; index < num; ++index)
    {
      try
      {
        this.UpdateChild(context, decoder);
      }
      catch (Exception ex)
      {
        throw;
      }
    }
  }

  protected BaseInstanceState UpdateChild(ISystemContext context, BinaryDecoder decoder)
  {
    NodeState.AttributesToSave attributesToSave = (NodeState.AttributesToSave) decoder.ReadUInt32((string) null);
    string symbolicName = (string) null;
    QualifiedName browseName = (QualifiedName) null;
    NodeClass nodeClass = (NodeClass) decoder.ReadEnumerated((string) null, typeof (NodeClass));
    NodeState.AttributesToSave attributesToLoad = attributesToSave & ~NodeState.AttributesToSave.NodeClass;
    if ((attributesToLoad & NodeState.AttributesToSave.SymbolicName) != NodeState.AttributesToSave.None)
    {
      symbolicName = decoder.ReadString((string) null);
      attributesToLoad &= ~NodeState.AttributesToSave.SymbolicName;
    }
    if ((attributesToLoad & NodeState.AttributesToSave.BrowseName) != NodeState.AttributesToSave.None)
    {
      browseName = decoder.ReadQualifiedName((string) null);
      attributesToLoad &= ~NodeState.AttributesToSave.BrowseName;
    }
    if (string.IsNullOrEmpty(symbolicName) && browseName != (QualifiedName) null)
      symbolicName = browseName.Name;
    BaseInstanceState child1 = this.CreateChild(context, browseName);
    if (child1 != null)
    {
      child1.SymbolicName = symbolicName;
      child1.BrowseName = browseName;
      child1.Update(context, decoder, attributesToLoad);
      child1.UpdateReferences(context, decoder);
      child1.UpdateChildren(context, decoder);
      return child1;
    }
    BaseInstanceState child2 = NodeState.UpdateUnknownChild(context, decoder, this, attributesToLoad, nodeClass, symbolicName, browseName);
    if (child2 != null)
    {
      child2.BrowseName = browseName;
      this.AddChild(child2);
    }
    return child2;
  }

  public static NodeState LoadNode(ISystemContext context, BinaryDecoder decoder)
  {
    NodeState.AttributesToSave attributesToSave = (NodeState.AttributesToSave) decoder.ReadUInt32((string) null);
    string symbolicName = (string) null;
    QualifiedName browseName = (QualifiedName) null;
    NodeClass nodeClass = (NodeClass) decoder.ReadEnumerated((string) null, typeof (NodeClass));
    NodeState.AttributesToSave attributesToLoad = attributesToSave & ~NodeState.AttributesToSave.NodeClass;
    if ((attributesToLoad & NodeState.AttributesToSave.SymbolicName) != NodeState.AttributesToSave.None)
    {
      symbolicName = decoder.ReadString((string) null);
      attributesToLoad &= ~NodeState.AttributesToSave.SymbolicName;
    }
    if ((attributesToLoad & NodeState.AttributesToSave.BrowseName) != NodeState.AttributesToSave.None)
    {
      browseName = decoder.ReadQualifiedName((string) null);
      attributesToLoad &= ~NodeState.AttributesToSave.BrowseName;
    }
    if (string.IsNullOrEmpty(symbolicName) && browseName != (QualifiedName) null)
      symbolicName = browseName.Name;
    return NodeState.LoadUnknownNode(context, decoder, attributesToLoad, nodeClass, symbolicName, browseName);
  }

  public void SaveReferences(ISystemContext context, BinaryEncoder encoder)
  {
    if (this.m_references != null && this.m_references.Count > 0)
    {
      encoder.WriteInt32((string) null, this.m_references.Count);
      foreach (IReference key in (IEnumerable<IReference>) this.m_references.Keys)
      {
        encoder.WriteNodeId((string) null, key.ReferenceTypeId);
        encoder.WriteBoolean((string) null, key.IsInverse);
        encoder.WriteExpandedNodeId((string) null, key.TargetId);
      }
    }
    else
      encoder.WriteInt32((string) null, -1);
  }

  public void UpdateReferences(ISystemContext context, BinaryDecoder decoder)
  {
    int num = decoder.ReadInt32((string) null);
    for (int index = 0; index < num; ++index)
    {
      NodeId referenceTypeId = decoder.ReadNodeId((string) null);
      bool isInverse = decoder.ReadBoolean((string) null);
      ExpandedNodeId targetId = decoder.ReadExpandedNodeId((string) null);
      if (this.m_references == null)
        this.m_references = new IReferenceDictionary<object>();
      this.m_references[(IReference) new NodeStateReference(referenceTypeId, isInverse, targetId)] = (object) null;
    }
  }

  public void SaveAsXml(ISystemContext context, XmlEncoder encoder)
  {
    encoder.Push(this.SymbolicName, context.NamespaceUris.GetString((uint) this.BrowseName.NamespaceIndex));
    this.Save(context, encoder);
    this.SaveReferences(context, encoder);
    this.SaveChildren(context, encoder);
    encoder.Pop();
  }

  public void LoadFromXml(ISystemContext context, TextReader input)
  {
    using (XmlReader reader = XmlReader.Create(input, Utils.DefaultXmlReaderSettings()))
      this.LoadFromXml(context, reader);
  }

  public void LoadFromXml(ISystemContext context, Stream input)
  {
    using (XmlReader reader = XmlReader.Create(input, Utils.DefaultXmlReaderSettings()))
      this.LoadFromXml(context, reader);
  }

  public void LoadFromXml(ISystemContext context, XmlReader reader)
  {
    ServiceMessageContext context1 = new ServiceMessageContext();
    context1.NamespaceUris = context.NamespaceUris;
    context1.ServerUris = context.ServerUris;
    context1.Factory = context.EncodeableFactory;
    int content = (int) reader.MoveToContent();
    XmlQualifiedName xmlQualifiedName = new XmlQualifiedName(reader.LocalName, reader.NamespaceURI);
    int index = context.NamespaceUris.GetIndex(xmlQualifiedName.Namespace);
    if (index < 0)
      throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Could not resolve namespace uri: {0}", (object) xmlQualifiedName.Namespace);
    this.SymbolicName = xmlQualifiedName.Name;
    this.BrowseName = new QualifiedName(xmlQualifiedName.Name, (ushort) index);
    XmlDecoder decoder = new XmlDecoder((Type) null, reader, (IServiceMessageContext) context1);
    NamespaceTable namespaceUris = new NamespaceTable();
    if (!decoder.LoadStringTable("NamespaceUris", "NamespaceUri", (StringTable) namespaceUris))
      namespaceUris = (NamespaceTable) null;
    StringTable stringTable = new StringTable();
    if (!decoder.LoadStringTable("ServerUris", "ServerUri", stringTable))
      stringTable = (StringTable) null;
    decoder.SetMappingTables(namespaceUris, stringTable);
    this.Update(context, decoder);
    this.UpdateReferences(context, decoder);
    this.UpdateChildren(context, decoder);
  }

  public void LoadFromXml(ISystemContext context, XmlDecoder decoder)
  {
    XmlQualifiedName qname = decoder.Peek(XmlNodeType.Element);
    if (qname == (XmlQualifiedName) null)
      throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Expecting an XML start element in stream.");
    int index = context.NamespaceUris.GetIndex(qname.Namespace);
    if (index < 0)
      throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Could not resolve namespace uri: {0}", (object) qname.Namespace);
    this.SymbolicName = qname.Name;
    this.BrowseName = new QualifiedName(qname.Name, (ushort) index);
    decoder.ReadStartElement();
    this.Update(context, decoder);
    this.UpdateReferences(context, decoder);
    this.UpdateChildren(context, decoder);
    decoder.Skip(qname);
  }

  public virtual void Save(ISystemContext context, XmlEncoder encoder)
  {
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    encoder.WriteEnumerated("NodeClass", (Enum) this.m_nodeClass);
    if (!NodeId.IsNull(this.m_nodeId))
      encoder.WriteNodeId("NodeId", this.m_nodeId);
    if (!QualifiedName.IsNull(this.m_browseName))
      encoder.WriteQualifiedName("BrowseName", this.m_browseName);
    if (!LocalizedText.IsNullOrEmpty(this.m_displayName) && (this.m_browseName == (QualifiedName) null || !string.IsNullOrEmpty(this.m_displayName.Locale) || this.m_browseName.Name != this.m_displayName.Text))
      encoder.WriteLocalizedText("DisplayName", this.m_displayName);
    if (!LocalizedText.IsNullOrEmpty(this.m_description))
      encoder.WriteLocalizedText("Description", this.m_description);
    if (this.m_writeMask != AttributeWriteMask.None)
      encoder.WriteEnumerated("WriteMask", (Enum) this.m_writeMask);
    if (this.m_userWriteMask != AttributeWriteMask.None)
      encoder.WriteEnumerated("UserWriteMask", (Enum) this.m_userWriteMask);
    encoder.PopNamespace();
  }

  public virtual void Update(ISystemContext context, XmlDecoder decoder)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (decoder.Peek("NodeClass"))
    {
      NodeClass nodeClass = (NodeClass) decoder.ReadEnumerated("NodeClass", typeof (NodeClass));
      if (this.NodeClass != NodeClass.Unspecified && nodeClass != this.NodeClass)
        throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Unexpected NodeClass in input stream. {0} != {1}", (object) this.NodeClass, (object) nodeClass);
    }
    if (decoder.Peek("NodeId"))
    {
      NodeId nodeId = decoder.ReadNodeId("NodeId");
      if (!NodeId.IsNull(nodeId))
        this.NodeId = nodeId;
    }
    if (decoder.Peek("BrowseName"))
    {
      QualifiedName qualifiedName = decoder.ReadQualifiedName("BrowseName");
      if (!QualifiedName.IsNull(qualifiedName))
        this.BrowseName = qualifiedName;
    }
    if (decoder.Peek("DisplayName"))
      this.DisplayName = decoder.ReadLocalizedText("DisplayName");
    if (LocalizedText.IsNullOrEmpty(this.m_displayName) && this.m_browseName != (QualifiedName) null)
      this.DisplayName = (LocalizedText) this.m_browseName.Name;
    if (decoder.Peek("Description"))
      this.Description = decoder.ReadLocalizedText("Description");
    if (decoder.Peek("WriteMask"))
      this.WriteMask = (AttributeWriteMask) decoder.ReadEnumerated("WriteMask", typeof (AttributeWriteMask));
    if (decoder.Peek("UserWriteMask"))
      this.UserWriteMask = (AttributeWriteMask) decoder.ReadEnumerated("UserWriteMask", typeof (AttributeWriteMask));
    decoder.PopNamespace();
    this.m_initialized = true;
  }

  public virtual void SaveChildren(ISystemContext context, XmlEncoder encoder)
  {
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
    {
      BaseInstanceState baseInstanceState = children[index];
      encoder.Push(baseInstanceState.SymbolicName, context.NamespaceUris.GetString((uint) baseInstanceState.BrowseName.NamespaceIndex));
      baseInstanceState.Save(context, encoder);
      baseInstanceState.SaveReferences(context, encoder);
      baseInstanceState.SaveChildren(context, encoder);
      encoder.Pop();
    }
  }

  public void SaveReferences(ISystemContext context, XmlEncoder encoder)
  {
    if (this.m_references == null || this.m_references.Count <= 0)
      return;
    encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    try
    {
      encoder.Push("References", "http://opcfoundation.org/UA/2008/02/Types.xsd");
      foreach (IReference key in (IEnumerable<IReference>) this.m_references.Keys)
      {
        encoder.Push("Reference", "http://opcfoundation.org/UA/2008/02/Types.xsd");
        if (!NodeId.IsNull(key.ReferenceTypeId))
          encoder.WriteNodeId("ReferenceTypeId", key.ReferenceTypeId);
        if (key.IsInverse)
          encoder.WriteBoolean("IsInverse", key.IsInverse);
        if (!NodeId.IsNull(key.TargetId))
          encoder.WriteExpandedNodeId("TargetId", key.TargetId);
        encoder.Pop();
      }
      encoder.Pop();
    }
    finally
    {
      encoder.PopNamespace();
    }
  }

  public virtual void UpdateChildren(ISystemContext context, XmlDecoder decoder)
  {
    BaseInstanceState baseInstanceState = this.UpdateChild(context, decoder);
    while (baseInstanceState != null)
      baseInstanceState = this.UpdateChild(context, decoder);
  }

  public virtual void UpdateReferences(ISystemContext context, XmlDecoder decoder)
  {
    if (this.m_references != null)
    {
      this.m_references.Clear();
      this.m_changeMasks |= NodeStateChangeMasks.References;
    }
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    if (!decoder.Peek("References"))
    {
      decoder.PopNamespace();
    }
    else
    {
      decoder.ReadStartElement();
      while (decoder.Peek("Reference"))
      {
        decoder.ReadStartElement();
        NodeId referenceTypeId = (NodeId) null;
        bool isInverse = false;
        ExpandedNodeId targetId = (ExpandedNodeId) null;
        if (decoder.Peek("ReferenceTypeId"))
          referenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
        if (decoder.Peek("IsInverse"))
          isInverse = decoder.ReadBoolean("IsInverse");
        if (decoder.Peek("TargetId"))
          targetId = decoder.ReadExpandedNodeId("TargetId");
        if (this.m_references == null)
          this.m_references = new IReferenceDictionary<object>();
        this.m_references[(IReference) new NodeStateReference(referenceTypeId, isInverse, targetId)] = (object) null;
        this.m_changeMasks |= NodeStateChangeMasks.References;
        decoder.Skip(new XmlQualifiedName("Reference", "http://opcfoundation.org/UA/2008/02/Types.xsd"));
      }
      decoder.Skip(new XmlQualifiedName("References", "http://opcfoundation.org/UA/2008/02/Types.xsd"));
      decoder.PopNamespace();
    }
  }

  protected BaseInstanceState UpdateChild(ISystemContext context, XmlDecoder decoder)
  {
    XmlQualifiedName xmlQualifiedName = decoder.Peek(XmlNodeType.Element);
    if (xmlQualifiedName == (XmlQualifiedName) null)
      return (BaseInstanceState) null;
    int index = context.NamespaceUris.GetIndex(xmlQualifiedName.Namespace);
    if (index < 0)
      throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Could not resolve namespace uri: {0}", (object) xmlQualifiedName.Namespace);
    decoder.ReadStartElement();
    QualifiedName qualifiedName = new QualifiedName(xmlQualifiedName.Name, (ushort) index);
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    NodeClass nodeClass = (NodeClass) decoder.ReadEnumerated("NodeClass", typeof (NodeClass));
    NodeId nodeId = decoder.ReadNodeId("NodeId");
    QualifiedName browseName = decoder.ReadQualifiedName("BrowseName");
    decoder.PopNamespace();
    BaseInstanceState child1 = this.CreateChild(context, browseName);
    if (child1 != null)
    {
      child1.SymbolicName = xmlQualifiedName.Name;
      child1.NodeId = nodeId;
      child1.BrowseName = browseName;
      child1.Update(context, decoder);
      child1.UpdateReferences(context, decoder);
      child1.UpdateChildren(context, decoder);
      decoder.Skip(xmlQualifiedName);
      return child1;
    }
    BaseInstanceState child2 = NodeState.UpdateUnknownChild(context, decoder, this, xmlQualifiedName, nodeClass, browseName);
    if (child2 != null)
    {
      child2.NodeId = nodeId;
      this.AddChild(child2);
    }
    return child2;
  }

  public static NodeState LoadNode(ISystemContext context, XmlDecoder decoder)
  {
    XmlQualifiedName childName = decoder.Peek(XmlNodeType.Element);
    if (childName == (XmlQualifiedName) null)
      return (NodeState) null;
    int index = context.NamespaceUris.GetIndex(childName.Namespace);
    if (index < 0)
      throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Could not resolve namespace uri: {0}", (object) childName.Namespace);
    decoder.ReadStartElement();
    QualifiedName browseName = new QualifiedName(childName.Name, (ushort) index);
    return NodeState.LoadUnknownNode(context, decoder, childName, browseName);
  }

  private static BaseInstanceState UpdateUnknownChild(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState parent,
    NodeState.AttributesToSave attributesToLoad,
    NodeClass nodeClass,
    string symbolicName,
    QualifiedName browseName)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    NodeId nodeId = (NodeId) null;
    LocalizedText localizedText1 = (LocalizedText) null;
    LocalizedText localizedText2 = (LocalizedText) null;
    AttributeWriteMask attributeWriteMask1 = AttributeWriteMask.None;
    AttributeWriteMask attributeWriteMask2 = AttributeWriteMask.None;
    NodeId referenceTypeId = (NodeId) null;
    NodeId typeDefinitionId = (NodeId) null;
    if ((attributesToLoad & NodeState.AttributesToSave.NodeId) != NodeState.AttributesToSave.None)
    {
      nodeId = decoder.ReadNodeId((string) null);
      attributesToLoad &= ~NodeState.AttributesToSave.NodeId;
    }
    if ((attributesToLoad & NodeState.AttributesToSave.DisplayName) != NodeState.AttributesToSave.None)
    {
      localizedText1 = decoder.ReadLocalizedText((string) null);
      attributesToLoad &= ~NodeState.AttributesToSave.DisplayName;
    }
    if (LocalizedText.IsNullOrEmpty(localizedText1) && browseName != (QualifiedName) null)
      localizedText1 = (LocalizedText) browseName.Name;
    if ((attributesToLoad & NodeState.AttributesToSave.Description) != NodeState.AttributesToSave.None)
    {
      localizedText2 = decoder.ReadLocalizedText((string) null);
      attributesToLoad &= ~NodeState.AttributesToSave.Description;
    }
    if ((attributesToLoad & NodeState.AttributesToSave.WriteMask) != NodeState.AttributesToSave.None)
    {
      attributeWriteMask1 = (AttributeWriteMask) decoder.ReadEnumerated((string) null, typeof (AttributeWriteMask));
      attributesToLoad &= ~NodeState.AttributesToSave.WriteMask;
    }
    if ((attributesToLoad & NodeState.AttributesToSave.UserWriteMask) != NodeState.AttributesToSave.None)
    {
      attributeWriteMask1 = (AttributeWriteMask) decoder.ReadEnumerated((string) null, typeof (AttributeWriteMask));
      attributesToLoad &= ~NodeState.AttributesToSave.UserWriteMask;
    }
    if ((attributesToLoad & NodeState.AttributesToSave.ReferenceTypeId) != NodeState.AttributesToSave.None)
    {
      referenceTypeId = decoder.ReadNodeId((string) null);
      attributesToLoad &= ~NodeState.AttributesToSave.ReferenceTypeId;
    }
    if ((attributesToLoad & NodeState.AttributesToSave.TypeDefinitionId) != NodeState.AttributesToSave.None)
    {
      typeDefinitionId = decoder.ReadNodeId((string) null);
      attributesToLoad &= ~NodeState.AttributesToSave.TypeDefinitionId;
    }
    if (!((context.NodeStateFactory ?? new NodeStateFactory()).CreateInstance(context, parent, nodeClass, browseName, referenceTypeId, typeDefinitionId) is BaseInstanceState instance))
      throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Could not load child '{0}', with NodeClass {1}", (object) browseName, (object) nodeClass);
    instance.SymbolicName = symbolicName;
    instance.NodeId = nodeId;
    instance.BrowseName = browseName;
    instance.DisplayName = localizedText1;
    instance.Description = localizedText2;
    instance.WriteMask = attributeWriteMask1;
    instance.UserWriteMask = attributeWriteMask2;
    instance.ReferenceTypeId = referenceTypeId;
    instance.TypeDefinitionId = typeDefinitionId;
    instance.Update(context, decoder, attributesToLoad);
    instance.UpdateReferences(context, decoder);
    instance.UpdateChildren(context, decoder);
    return instance;
  }

  private static NodeState LoadUnknownNode(
    ISystemContext context,
    BinaryDecoder decoder,
    NodeState.AttributesToSave attributesToLoad,
    NodeClass nodeClass,
    string symbolicName,
    QualifiedName browseName)
  {
    switch (nodeClass)
    {
      case NodeClass.Object:
      case NodeClass.Variable:
      case NodeClass.Method:
        return (NodeState) NodeState.UpdateUnknownChild(context, decoder, (NodeState) null, attributesToLoad, nodeClass, symbolicName, browseName);
      default:
        NodeState instance = (context.NodeStateFactory ?? new NodeStateFactory()).CreateInstance(context, (NodeState) null, nodeClass, browseName, (NodeId) null, (NodeId) null);
        if (instance == null)
          throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Could not load node '{0}', with NodeClass {1}", (object) browseName, (object) nodeClass);
        instance.SymbolicName = symbolicName;
        instance.BrowseName = browseName;
        instance.Update(context, decoder, attributesToLoad);
        instance.UpdateReferences(context, decoder);
        instance.UpdateChildren(context, decoder);
        return instance;
    }
  }

  private static NodeState LoadUnknownNode(
    ISystemContext context,
    XmlDecoder decoder,
    XmlQualifiedName childName,
    QualifiedName browseName)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    NodeClass nodeClass = (NodeClass) decoder.ReadEnumerated("NodeClass", typeof (NodeClass));
    decoder.PopNamespace();
    switch (nodeClass)
    {
      case NodeClass.Object:
      case NodeClass.Variable:
      case NodeClass.Method:
        return (NodeState) NodeState.UpdateUnknownChild(context, decoder, (NodeState) null, childName, nodeClass, browseName);
      default:
        NodeState instance = (context.NodeStateFactory ?? new NodeStateFactory()).CreateInstance(context, (NodeState) null, nodeClass, browseName, (NodeId) null, (NodeId) null);
        if (instance == null)
          throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Could not load node '{0}', with NodeClass {1}", (object) browseName, (object) nodeClass);
        instance.SymbolicName = childName.Name;
        instance.Update(context, decoder);
        instance.UpdateReferences(context, decoder);
        instance.UpdateChildren(context, decoder);
        decoder.Skip(childName);
        return instance;
    }
  }

  private static BaseInstanceState UpdateUnknownChild(
    ISystemContext context,
    XmlDecoder decoder,
    NodeState parent,
    XmlQualifiedName childName,
    NodeClass nodeClass,
    QualifiedName browseName)
  {
    decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
    NodeId nodeId = decoder.ReadNodeId("NodeId");
    if (decoder.Peek("BrowseName"))
      browseName = decoder.ReadQualifiedName("BrowseName");
    LocalizedText localizedText1 = (LocalizedText) null;
    if (decoder.Peek("DisplayName"))
      localizedText1 = decoder.ReadLocalizedText("DisplayName");
    if (LocalizedText.IsNullOrEmpty(localizedText1) && browseName != (QualifiedName) null)
      localizedText1 = (LocalizedText) browseName.Name;
    LocalizedText localizedText2 = (LocalizedText) null;
    if (decoder.Peek("Description"))
      localizedText2 = decoder.ReadLocalizedText("Description");
    AttributeWriteMask attributeWriteMask1 = (AttributeWriteMask) decoder.ReadEnumerated("WriteMask", typeof (AttributeWriteMask));
    AttributeWriteMask attributeWriteMask2 = (AttributeWriteMask) decoder.ReadEnumerated("UserWriteMask", typeof (AttributeWriteMask));
    NodeId referenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
    NodeId typeDefinitionId = decoder.ReadNodeId("TypeDefinitionId");
    decoder.PopNamespace();
    if (!((context.NodeStateFactory ?? new NodeStateFactory()).CreateInstance(context, parent, nodeClass, browseName, referenceTypeId, typeDefinitionId) is BaseInstanceState instance))
      throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Could not load child '{0}', with NodeClass {1}", (object) browseName, (object) nodeClass);
    instance.SymbolicName = childName.Name;
    instance.NodeId = nodeId;
    instance.BrowseName = browseName;
    instance.DisplayName = localizedText1;
    instance.Description = localizedText2;
    instance.WriteMask = attributeWriteMask1;
    instance.UserWriteMask = attributeWriteMask2;
    instance.ReferenceTypeId = referenceTypeId;
    instance.TypeDefinitionId = typeDefinitionId;
    instance.Update(context, decoder);
    instance.UpdateReferences(context, decoder);
    instance.UpdateChildren(context, decoder);
    decoder.Skip(childName);
    return instance;
  }

  public event NodeStateChangedHandler StateChanged;

  public NodeState GetHierarchyRoot()
  {
    if (!(this is BaseInstanceState baseInstanceState1) || baseInstanceState1.Parent == null)
      return this;
    NodeState parent = baseInstanceState1.Parent;
    while (parent != null && parent is BaseInstanceState baseInstanceState2 && baseInstanceState2.Parent != null)
      parent = baseInstanceState2.Parent;
    return parent;
  }

  public bool AreEventsMonitored => this.m_areEventsMonitored > 0;

  public bool Initialized
  {
    get => this.m_initialized;
    set => this.m_initialized = value;
  }

  public bool ValidationRequired => this.OnValidate != null;

  public void SetAreEventsMonitored(
    ISystemContext context,
    bool areEventsMonitored,
    bool includeChildren)
  {
    if (areEventsMonitored)
      ++this.m_areEventsMonitored;
    else if (this.m_areEventsMonitored > 0)
      --this.m_areEventsMonitored;
    if (!includeChildren)
      return;
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
      children[index].SetAreEventsMonitored(context, areEventsMonitored, true);
    if (this.m_notifiers == null)
      return;
    for (int index = 0; index < this.m_notifiers.Count; ++index)
    {
      if (!this.m_notifiers[index].IsInverse)
        this.m_notifiers[index].Node.SetAreEventsMonitored(context, areEventsMonitored, includeChildren);
    }
  }

  public virtual void ReportEvent(ISystemContext context, IFilterTarget e)
  {
    NodeStateReportEventHandler onReportEvent = this.OnReportEvent;
    if (onReportEvent != null)
      onReportEvent(context, this, e);
    if (this.m_notifiers == null)
      return;
    for (int index = 0; index < this.m_notifiers.Count; ++index)
    {
      if (this.m_notifiers[index].IsInverse)
        this.m_notifiers[index].Node.ReportEvent(context, e);
    }
  }

  public virtual void AddNotifier(
    ISystemContext context,
    NodeId referenceTypeId,
    bool isInverse,
    NodeState target)
  {
    if (this.m_notifiers == null)
      this.m_notifiers = new List<NodeState.Notifier>();
    if (NodeId.IsNull(referenceTypeId))
      referenceTypeId = ReferenceTypeIds.HasEventSource;
    NodeState.Notifier notifier = (NodeState.Notifier) null;
    for (int index = 0; index < this.m_notifiers.Count; ++index)
    {
      if (this.m_notifiers[index].Node == target)
      {
        notifier = this.m_notifiers[index];
        break;
      }
    }
    if (!NodeId.IsNull(target.NodeId))
      this.RemoveReference(referenceTypeId, isInverse, (ExpandedNodeId) target.NodeId);
    if (notifier == null)
    {
      notifier = new NodeState.Notifier();
      this.m_notifiers.Add(notifier);
    }
    notifier.ReferenceTypeId = referenceTypeId;
    notifier.IsInverse = isInverse;
    notifier.Node = target;
  }

  public virtual void RemoveNotifier(ISystemContext context, NodeState target, bool bidirectional)
  {
    if (this.m_notifiers == null)
      return;
    for (int index = 0; index < this.m_notifiers.Count; ++index)
    {
      NodeState.Notifier notifier = this.m_notifiers[index];
      if (notifier.Node == target)
      {
        if (bidirectional)
          notifier.Node.RemoveNotifier(context, this, false);
        this.m_notifiers.RemoveAt(index);
        break;
      }
    }
    if (this.m_notifiers.Count != 0)
      return;
    this.m_notifiers = (List<NodeState.Notifier>) null;
  }

  public virtual void GetNotifiers(ISystemContext context, IList<NodeState.Notifier> notifiers)
  {
    if (this.m_notifiers == null)
      return;
    foreach (NodeState.Notifier notifier in this.m_notifiers)
      notifiers.Add(notifier);
  }

  public virtual void GetNotifiers(
    ISystemContext context,
    IList<NodeState.Notifier> notifiers,
    NodeId notifierTypeId,
    bool isInverse)
  {
    if (this.m_notifiers == null)
      return;
    foreach (NodeState.Notifier notifier in this.m_notifiers)
    {
      if (isInverse == notifier.IsInverse && notifier.ReferenceTypeId == (object) notifierTypeId)
        notifiers.Add(notifier);
    }
  }

  public virtual void ConditionRefresh(
    ISystemContext context,
    List<IFilterTarget> events,
    bool includeChildren)
  {
    NodeStateConditionRefreshEventHandler conditionRefresh = this.OnConditionRefresh;
    if (conditionRefresh != null)
      conditionRefresh(context, this, events);
    if (!includeChildren)
      return;
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
      children[index].ConditionRefresh(context, events, true);
    if (this.m_notifiers == null)
      return;
    for (int index = 0; index < this.m_notifiers.Count; ++index)
    {
      if (!this.m_notifiers[index].IsInverse)
        this.m_notifiers[index].Node.ConditionRefresh(context, events, true);
    }
  }

  public virtual MethodState FindMethod(ISystemContext context, NodeId methodId)
  {
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
    {
      if (children[index] is MethodState method && (method.NodeId == (object) methodId || method.MethodDeclarationId == (object) methodId))
        return method;
    }
    return (MethodState) null;
  }

  public void UpdateChangeMasks(NodeStateChangeMasks changeMasks)
  {
    this.m_changeMasks |= changeMasks;
  }

  public void ClearChangeMasks(ISystemContext context, bool includeChildren)
  {
    if (includeChildren)
    {
      List<BaseInstanceState> children = new List<BaseInstanceState>();
      this.GetChildren(context, (IList<BaseInstanceState>) children);
      for (int index = 0; index < children.Count; ++index)
        children[index].ClearChangeMasks(context, true);
    }
    if (this.m_changeMasks == NodeStateChangeMasks.None)
      return;
    NodeStateChangedHandler onStateChanged = this.OnStateChanged;
    if (onStateChanged != null)
      onStateChanged(context, this, this.m_changeMasks);
    NodeStateChangedHandler stateChanged = this.StateChanged;
    if (stateChanged != null)
      stateChanged(context, this, this.m_changeMasks);
    this.m_changeMasks = NodeStateChangeMasks.None;
  }

  public virtual void SetStatusCode(
    ISystemContext context,
    StatusCode statusCode,
    DateTime timestamp)
  {
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
      children[index].SetStatusCode(context, statusCode, timestamp);
  }

  protected virtual void OnBeforeCreate(ISystemContext context, NodeState node)
  {
  }

  protected virtual void OnBeforeAssignNodeIds(ISystemContext context)
  {
  }

  protected virtual void OnAfterCreate(ISystemContext context, NodeState node)
  {
  }

  protected virtual void OnBeforeDelete(ISystemContext context)
  {
  }

  protected virtual void OnAfterDelete(ISystemContext context)
  {
  }

  public virtual void Create(
    ISystemContext context,
    NodeId nodeId,
    QualifiedName browseName,
    LocalizedText displayName,
    bool assignNodeIds)
  {
    this.Initialize(context);
    this.CallOnBeforeCreate(context);
    if (nodeId != (object) null)
      this.NodeId = nodeId;
    if (!QualifiedName.IsNull(browseName))
    {
      this.SymbolicName = browseName.Name;
      this.BrowseName = browseName;
      this.DisplayName = (LocalizedText) browseName.Name;
    }
    if (displayName != (LocalizedText) null)
      this.DisplayName = displayName;
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    if (assignNodeIds)
    {
      this.CallOnBeforeAssignNodeIds(context, children);
      Dictionary<NodeId, NodeId> mappingTable = new Dictionary<NodeId, NodeId>();
      this.AssignNodeIds(context, children, mappingTable);
      this.UpdateReferenceTargets(context, children, mappingTable);
    }
    this.CallOnAfterCreate(context, children);
    this.ClearChangeMasks(context, true);
  }

  private void CallOnBeforeCreate(ISystemContext context)
  {
    this.OnBeforeCreate(context, this);
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
      children[index].CallOnBeforeCreate(context);
  }

  private void CallOnBeforeAssignNodeIds(ISystemContext context, List<BaseInstanceState> children)
  {
    this.OnBeforeAssignNodeIds(context);
    if (children == null)
    {
      children = new List<BaseInstanceState>();
      this.GetChildren(context, (IList<BaseInstanceState>) children);
    }
    for (int index = 0; index < children.Count; ++index)
      children[index].CallOnBeforeAssignNodeIds(context, (List<BaseInstanceState>) null);
  }

  private void CallOnAfterCreate(ISystemContext context, List<BaseInstanceState> children)
  {
    if (children == null)
    {
      children = new List<BaseInstanceState>();
      this.GetChildren(context, (IList<BaseInstanceState>) children);
    }
    for (int index = 0; index < children.Count; ++index)
      children[index].CallOnAfterCreate(context, (List<BaseInstanceState>) null);
    this.OnAfterCreate(context, this);
  }

  public virtual void Create(ISystemContext context, NodeState source)
  {
    this.Initialize(context, source);
    this.CallOnBeforeCreate(context);
    this.CallOnAfterCreate(context, (List<BaseInstanceState>) null);
    this.ClearChangeMasks(context, true);
  }

  public virtual void Delete(ISystemContext context)
  {
    this.OnBeforeDelete(context);
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
      children[index].Delete(context);
    this.OnAfterDelete(context);
    this.ChangeMasks = NodeStateChangeMasks.Deleted;
    this.ClearChangeMasks(context, false);
  }

  public virtual void AssignNodeIds(ISystemContext context, Dictionary<NodeId, NodeId> mappingTable)
  {
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    this.AssignNodeIds(context, children, mappingTable);
  }

  private void AssignNodeIds(
    ISystemContext context,
    List<BaseInstanceState> children,
    Dictionary<NodeId, NodeId> mappingTable)
  {
    if (context.NodeIdFactory == null)
      return;
    NodeId nodeId1 = this.NodeId;
    NodeId nodeId2 = context.NodeIdFactory.New(context, this);
    if (!NodeId.IsNull(nodeId1))
      mappingTable[nodeId1] = nodeId2;
    this.NodeId = nodeId2;
    for (int index = 0; index < children.Count; ++index)
      children[index].AssignNodeIds(context, mappingTable);
  }

  public virtual bool Validate(ISystemContext context)
  {
    return this.OnValidate == null || this.OnValidate(context, this);
  }

  public virtual INodeBrowser CreateBrowser(
    ISystemContext context,
    ViewDescription view,
    NodeId referenceType,
    bool includeSubtypes,
    BrowseDirection browseDirection,
    QualifiedName browseName,
    IEnumerable<IReference> additionalReferences,
    bool internalOnly)
  {
    NodeBrowser browser = (NodeBrowser) null;
    if (this.OnCreateBrowser != null)
      browser = this.OnCreateBrowser(context, this, view, referenceType, includeSubtypes, browseDirection, browseName, additionalReferences, internalOnly);
    if (browser == null)
      browser = new NodeBrowser(context, view, referenceType, includeSubtypes, browseDirection, browseName, additionalReferences, internalOnly);
    this.PopulateBrowser(context, browser);
    NodeStatePopulateBrowserEventHandler onPopulateBrowser = this.OnPopulateBrowser;
    if (onPopulateBrowser != null)
      onPopulateBrowser(context, this, browser);
    return (INodeBrowser) browser;
  }

  public void GetInstanceHierarchy(
    ISystemContext context,
    string browsePath,
    Dictionary<NodeId, string> hierarchy)
  {
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
    {
      BaseInstanceState baseInstanceState = children[index];
      string browsePath1 = Utils.Format("{0}/{1}", (object) browsePath, (object) baseInstanceState.SymbolicName);
      hierarchy[baseInstanceState.NodeId] = browsePath1;
      baseInstanceState.GetInstanceHierarchy(context, browsePath1, hierarchy);
    }
  }

  public void GetHierarchyReferences(
    ISystemContext context,
    string browsePath,
    Dictionary<NodeId, string> hierarchy,
    List<NodeStateHierarchyReference> references)
  {
    if (this.m_references != null)
    {
      foreach (IReference key in (IEnumerable<IReference>) this.m_references.Keys)
      {
        NodeId nodeId = ExpandedNodeId.ToNodeId(key.TargetId, context.NamespaceUris);
        if (nodeId == (object) null)
        {
          references.Add(new NodeStateHierarchyReference(browsePath, key));
        }
        else
        {
          string targetPath = (string) null;
          if (!hierarchy.TryGetValue(nodeId, out targetPath))
            references.Add(new NodeStateHierarchyReference(browsePath, key));
          else
            references.Add(new NodeStateHierarchyReference(browsePath, targetPath, key));
        }
      }
    }
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
    {
      string browsePath1 = Utils.Format("{0}/{1}", (object) browsePath, (object) children[index].SymbolicName);
      children[index].GetHierarchyReferences(context, browsePath1, hierarchy, references);
    }
  }

  public virtual void UpdateReferenceTargets(
    ISystemContext context,
    Dictionary<NodeId, NodeId> mappingTable)
  {
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    this.UpdateReferenceTargets(context, children, mappingTable);
  }

  private void UpdateReferenceTargets(
    ISystemContext context,
    List<BaseInstanceState> children,
    Dictionary<NodeId, NodeId> mappingTable)
  {
    if (this.m_references != null)
    {
      List<IReference> referenceList1 = new List<IReference>();
      List<IReference> referenceList2 = new List<IReference>();
      foreach (IReference key in (IEnumerable<IReference>) this.m_references.Keys)
      {
        NodeId nodeId = ExpandedNodeId.ToNodeId(key.TargetId, context.NamespaceUris);
        if (!(nodeId == (object) null))
        {
          NodeId targetId = (NodeId) null;
          if (mappingTable.TryGetValue(nodeId, out targetId))
          {
            referenceList2.Add(key);
            referenceList1.Add((IReference) new NodeStateReference(key.ReferenceTypeId, key.IsInverse, (ExpandedNodeId) targetId));
          }
        }
      }
      for (int index = 0; index < referenceList2.Count; ++index)
      {
        if (this.m_references.Remove(referenceList2[index]))
          this.m_changeMasks |= NodeStateChangeMasks.References;
      }
      for (int index = 0; index < referenceList1.Count; ++index)
      {
        this.m_references[referenceList1[index]] = (object) null;
        this.m_changeMasks |= NodeStateChangeMasks.References;
      }
    }
    for (int index = 0; index < children.Count; ++index)
      children[index].UpdateReferenceTargets(context, mappingTable);
  }

  protected virtual void PopulateBrowser(ISystemContext context, NodeBrowser browser)
  {
    NodeId nodeId = browser.ReferenceType;
    if (NodeId.IsNull(nodeId) || browser.ReferenceType == (object) ReferenceTypeIds.References)
      nodeId = (NodeId) null;
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    bool flag;
    if (!(flag = nodeId == (object) null) && context.TypeTable != null && context.TypeTable.IsTypeOf(browser.ReferenceType, ReferenceTypeIds.HierarchicalReferences) && browser.BrowseDirection != BrowseDirection.Inverse)
      flag = true;
    if (flag)
      this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
    {
      BaseInstanceState target = children[index];
      if (browser.IsRequired((NodeState) target) && browser.IsRequired(target.ReferenceTypeId, false))
        browser.Add(target.ReferenceTypeId, false, (NodeState) target);
    }
    if (this.m_notifiers != null)
    {
      for (int index = 0; index < this.m_notifiers.Count; ++index)
      {
        NodeState.Notifier notifier = this.m_notifiers[index];
        if (browser.IsRequired(notifier.ReferenceTypeId, notifier.IsInverse))
          browser.Add(notifier.ReferenceTypeId, notifier.IsInverse, this.m_notifiers[index].Node);
      }
    }
    if (this.m_references == null)
      return;
    if (nodeId == (object) null)
    {
      foreach (IReference key in (IEnumerable<IReference>) this.m_references.Keys)
      {
        if (key.IsInverse)
        {
          if (browser.BrowseDirection == BrowseDirection.Forward)
            continue;
        }
        else if (browser.BrowseDirection == BrowseDirection.Inverse)
          continue;
        browser.Add(key);
      }
    }
    else
    {
      if (browser.BrowseDirection != BrowseDirection.Inverse)
      {
        IList<IReference> referenceList = !browser.IncludeSubtypes ? this.m_references.Find(browser.ReferenceType, false) : this.m_references.Find(browser.ReferenceType, false, context.TypeTable);
        for (int index = 0; index < referenceList.Count; ++index)
          browser.Add(referenceList[index]);
      }
      if (browser.BrowseDirection == BrowseDirection.Forward)
        return;
      IList<IReference> referenceList1 = !browser.IncludeSubtypes ? this.m_references.Find(browser.ReferenceType, true) : this.m_references.Find(browser.ReferenceType, true, context.TypeTable);
      for (int index = 0; index < referenceList1.Count; ++index)
        browser.Add(referenceList1[index]);
    }
  }

  public virtual void UpdateValues(
    ISystemContext context,
    SimpleAttributeOperandCollection attributes,
    EventFieldList values)
  {
    for (int index = 0; index < attributes.Count; ++index)
    {
      NodeState child = (NodeState) this.FindChild(context, (IList<QualifiedName>) attributes[index].BrowsePath, 0);
      if (child != null && values.EventFields.Count < index)
      {
        switch (child)
        {
          case BaseVariableState baseVariableState:
            object obj = values.EventFields[index].Value;
            baseVariableState.Value = obj;
            continue;
          case BaseObjectState baseObjectState:
            NodeId nodeId = values.EventFields[index].Value as NodeId;
            if (nodeId != (object) null)
            {
              baseObjectState.NodeId = nodeId;
              continue;
            }
            continue;
          default:
            continue;
        }
      }
    }
  }

  public virtual List<object> ReadAttributes(ISystemContext context, params uint[] attributeIds)
  {
    List<object> objectList = new List<object>();
    if (attributeIds != null)
    {
      for (int index = 0; index < attributeIds.Length; ++index)
      {
        DataValue dataValue = new DataValue();
        if (ServiceResult.IsBad(this.ReadAttribute(context, attributeIds[index], NumericRange.Empty, (QualifiedName) null, dataValue)))
          objectList.Add((object) null);
        else
          objectList.Add(dataValue.Value);
      }
    }
    return objectList;
  }

  public virtual ServiceResult ReadAttribute(
    ISystemContext context,
    uint attributeId,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    DataValue value)
  {
    if (value == null)
      return (ServiceResult) 2152071168U /*0x80460000*/;
    object obj = value.Value;
    ServiceResult serviceResult;
    if (attributeId == 13U)
    {
      DateTime sourceTimestamp = value.SourceTimestamp;
      try
      {
        serviceResult = this.ReadValueAttribute(context, indexRange, dataEncoding, ref obj, ref sourceTimestamp);
        value.SourceTimestamp = sourceTimestamp;
        value.SourcePicoseconds = (ushort) 0;
      }
      catch (Exception ex)
      {
        serviceResult = new ServiceResult(ex, 2147549184U /*0x80010000*/);
      }
    }
    else
    {
      try
      {
        serviceResult = this.ReadNonValueAttribute(context, attributeId, ref obj);
      }
      catch (Exception ex)
      {
        serviceResult = new ServiceResult(ex, 2147549184U /*0x80010000*/);
      }
    }
    value.StatusCode = serviceResult == null || serviceResult == ServiceResult.Good ? (StatusCode) 0U : serviceResult.StatusCode;
    value.Value = !StatusCode.IsBad(value.StatusCode) ? obj : (object) null;
    return serviceResult;
  }

  protected virtual ServiceResult ReadNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    ref object value)
  {
    ServiceResult status = (ServiceResult) null;
    switch (attributeId)
    {
      case 1:
        NodeId nodeId = this.m_nodeId;
        if (this.OnReadNodeId != null)
          status = this.OnReadNodeId(context, this, ref nodeId);
        if (ServiceResult.IsGood(status))
          value = (object) nodeId;
        return status;
      case 2:
        NodeClass nodeClass = this.m_nodeClass;
        if (this.OnReadNodeClass != null)
          status = this.OnReadNodeClass(context, this, ref nodeClass);
        if (ServiceResult.IsGood(status))
          value = (object) nodeClass;
        return status;
      case 3:
        QualifiedName browseName = this.m_browseName;
        if (this.OnReadBrowseName != null)
          status = this.OnReadBrowseName(context, this, ref browseName);
        if (ServiceResult.IsGood(status))
          value = (object) browseName;
        return status;
      case 4:
        LocalizedText displayName = this.m_displayName;
        if (this.OnReadDisplayName != null)
          status = this.OnReadDisplayName(context, this, ref displayName);
        if (ServiceResult.IsGood(status))
          value = (object) displayName;
        if (value != null || status != null)
          return status;
        break;
      case 5:
        LocalizedText description = this.m_description;
        if (this.OnReadDescription != null)
          status = this.OnReadDescription(context, this, ref description);
        if (ServiceResult.IsGood(status))
          value = (object) description;
        if (value != null || status != null)
          return status;
        break;
      case 6:
        AttributeWriteMask writeMask = this.m_writeMask;
        if (this.OnReadWriteMask != null)
          status = this.OnReadWriteMask(context, this, ref writeMask);
        if (ServiceResult.IsGood(status))
          value = (object) (uint) writeMask;
        return status;
      case 7:
        AttributeWriteMask userWriteMask = this.m_userWriteMask;
        if (this.OnReadUserWriteMask != null)
          status = this.OnReadUserWriteMask(context, this, ref userWriteMask);
        if (ServiceResult.IsGood(status))
          value = (object) (uint) userWriteMask;
        return status;
      case 24:
        RolePermissionTypeCollection rolePermissions = this.m_rolePermissions;
        if (this.OnReadRolePermissions != null)
          status = this.OnReadRolePermissions(context, this, ref rolePermissions);
        if (ServiceResult.IsGood(status))
          value = (object) rolePermissions;
        if (value != null || status != null)
          return status;
        break;
      case 25:
        RolePermissionTypeCollection userRolePermissions = this.m_userRolePermissions;
        if (this.OnReadUserRolePermissions != null)
          status = this.OnReadUserRolePermissions(context, this, ref userRolePermissions);
        if (ServiceResult.IsGood(status))
          value = (object) userRolePermissions;
        if (value != null || status != null)
          return status;
        break;
      case 26:
        AccessRestrictionType accessRestrictions = this.m_accessRestrictions;
        if (this.OnReadAccessRestrictions != null)
          status = this.OnReadAccessRestrictions(context, this, ref accessRestrictions);
        if (ServiceResult.IsGood(status))
          value = (object) (ushort) this.m_accessRestrictions;
        if (value != null || status != null)
          return status;
        break;
    }
    return (ServiceResult) 2150957056U /*0x80350000*/;
  }

  protected virtual ServiceResult ReadValueAttribute(
    ISystemContext context,
    NumericRange indexRange,
    QualifiedName dataEncoding,
    ref object value,
    ref DateTime sourceTimestamp)
  {
    value = (object) null;
    sourceTimestamp = DateTime.MinValue;
    return (ServiceResult) 2150957056U /*0x80350000*/;
  }

  public ServiceResult WriteAttribute(
    ISystemContext context,
    uint attributeId,
    NumericRange indexRange,
    DataValue value)
  {
    if (value == null)
      return (ServiceResult) 2152071168U /*0x80460000*/;
    object obj = value.Value;
    if (attributeId == 13U)
    {
      if (value.ServerTimestamp != DateTime.MinValue)
        return (ServiceResult) 2155020288U /*0x80730000*/;
      try
      {
        return this.WriteValueAttribute(context, indexRange, obj, value.StatusCode, value.SourceTimestamp);
      }
      catch (Exception ex)
      {
        return new ServiceResult(ex, 2147549184U /*0x80010000*/);
      }
    }
    else
    {
      if (value.StatusCode != 0U || value.ServerTimestamp != DateTime.MinValue || value.SourceTimestamp != DateTime.MinValue)
        return (ServiceResult) 2155020288U /*0x80730000*/;
      if (indexRange != NumericRange.Empty)
        return (ServiceResult) 2151022592U /*0x80360000*/;
      try
      {
        return this.WriteNonValueAttribute(context, attributeId, value.Value);
      }
      catch (Exception ex)
      {
        return new ServiceResult(ex, 2147549184U /*0x80010000*/);
      }
    }
  }

  protected virtual ServiceResult WriteNonValueAttribute(
    ISystemContext context,
    uint attributeId,
    object value)
  {
    ServiceResult status = (ServiceResult) null;
    switch (attributeId)
    {
      case 1:
        NodeId nodeId = value as NodeId;
        if (nodeId == (object) null)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.NodeId) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        if (this.OnWriteNodeId != null)
          status = this.OnWriteNodeId(context, this, ref nodeId);
        if (ServiceResult.IsGood(status))
          this.m_nodeId = nodeId;
        return status;
      case 2:
        int? nullable1 = value as int?;
        if (!nullable1.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.NodeClass) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        NodeClass nodeClass = (NodeClass) nullable1.Value;
        if (this.OnWriteNodeClass != null)
          status = this.OnWriteNodeClass(context, this, ref nodeClass);
        if (ServiceResult.IsGood(status))
          this.m_nodeClass = nodeClass;
        return status;
      case 3:
        QualifiedName qualifiedName = value as QualifiedName;
        if (qualifiedName == (QualifiedName) null)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.BrowseName) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        if (this.OnWriteBrowseName != null)
          status = this.OnWriteBrowseName(context, this, ref qualifiedName);
        if (ServiceResult.IsGood(status))
          this.m_browseName = qualifiedName;
        return status;
      case 4:
        LocalizedText localizedText1 = value as LocalizedText;
        if (localizedText1 == (LocalizedText) null)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.DisplayName) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        if (this.OnWriteDisplayName != null)
          status = this.OnWriteDisplayName(context, this, ref localizedText1);
        if (ServiceResult.IsGood(status))
          this.m_displayName = localizedText1;
        return status;
      case 5:
        LocalizedText localizedText2 = value as LocalizedText;
        if (localizedText2 == (LocalizedText) null && value != null)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.Description) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        if (this.OnWriteDescription != null)
          status = this.OnWriteDescription(context, this, ref localizedText2);
        if (ServiceResult.IsGood(status))
          this.m_description = localizedText2;
        return status;
      case 6:
        uint? nullable2 = value as uint?;
        if (!nullable2.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.WriteMask) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        AttributeWriteMask attributeWriteMask1 = (AttributeWriteMask) nullable2.Value;
        if (this.OnWriteWriteMask != null)
          status = this.OnWriteWriteMask(context, this, ref attributeWriteMask1);
        if (ServiceResult.IsGood(status))
          this.WriteMask = attributeWriteMask1;
        return status;
      case 7:
        uint? nullable3 = value as uint?;
        if (!nullable3.HasValue)
          return (ServiceResult) 2155085824U /*0x80740000*/;
        if ((this.WriteMask & AttributeWriteMask.UserWriteMask) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        AttributeWriteMask attributeWriteMask2 = (AttributeWriteMask) nullable3.Value;
        if (this.OnWriteUserWriteMask != null)
          status = this.OnWriteUserWriteMask(context, this, ref attributeWriteMask2);
        if (ServiceResult.IsGood(status))
          this.m_userWriteMask = attributeWriteMask2;
        return status;
      case 24:
        if (!(value is ExtensionObject[] extensionObjectArray))
          return (ServiceResult) 2155085824U /*0x80740000*/;
        RolePermissionTypeCollection permissionTypeCollection = new RolePermissionTypeCollection();
        for (int index = 0; index < extensionObjectArray.Length; ++index)
        {
          if (!(extensionObjectArray[index].Body is RolePermissionType body))
            return (ServiceResult) 2155085824U /*0x80740000*/;
          permissionTypeCollection.Add(body);
        }
        if ((this.WriteMask & AttributeWriteMask.RolePermissions) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        if (this.OnWriteRolePermissions != null)
          status = this.OnWriteRolePermissions(context, this, ref permissionTypeCollection);
        if (ServiceResult.IsGood(status))
          this.m_rolePermissions = permissionTypeCollection;
        return status;
      case 26:
        ushort? nullable4 = value as ushort?;
        if (!nullable4.HasValue && value != null)
        {
          if (!(value.GetType() == typeof (uint)))
            return (ServiceResult) 2155085824U /*0x80740000*/;
          nullable4 = new ushort?(Convert.ToUInt16(value));
        }
        if ((this.WriteMask & AttributeWriteMask.AccessRestrictions) == AttributeWriteMask.None)
          return (ServiceResult) 2151350272U /*0x803B0000*/;
        AccessRestrictionType accessRestrictionType = (AccessRestrictionType) nullable4.Value;
        if (this.OnWriteAccessRestrictions != null)
          status = this.OnWriteAccessRestrictions(context, this, ref accessRestrictionType);
        if (ServiceResult.IsGood(status))
          this.m_accessRestrictions = accessRestrictionType;
        return status;
      default:
        return (ServiceResult) 2150957056U /*0x80350000*/;
    }
  }

  protected virtual ServiceResult WriteValueAttribute(
    ISystemContext context,
    NumericRange indexRange,
    object value,
    StatusCode statusCode,
    DateTime sourceTimestamp)
  {
    return (ServiceResult) 2150957056U /*0x80350000*/;
  }

  public virtual BaseInstanceState FindChildBySymbolicName(
    ISystemContext context,
    string symbolicPath)
  {
    if (string.IsNullOrEmpty(symbolicPath))
      return (BaseInstanceState) null;
    int num = 0;
    while (num < symbolicPath.Length && symbolicPath[num] == '/')
      ++num;
    if (num >= symbolicPath.Length)
      return (BaseInstanceState) null;
    int index1 = num + 1;
    while (index1 < symbolicPath.Length && symbolicPath[index1] != '/')
      ++index1;
    string str = symbolicPath;
    if (num > 0 || index1 < symbolicPath.Length)
      str = symbolicPath.Substring(num, index1 - num);
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    this.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index2 = 0; index2 < children.Count; ++index2)
    {
      BaseInstanceState baseInstanceState = children[index2];
      if (baseInstanceState.SymbolicName == str)
        return index1 < symbolicPath.Length - 1 ? baseInstanceState.FindChildBySymbolicName(context, symbolicPath.Substring(index1 + 1)) : baseInstanceState;
    }
    return (BaseInstanceState) null;
  }

  public virtual BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName)
  {
    return this.FindChild(context, browseName, false, (BaseInstanceState) null);
  }

  public virtual BaseInstanceState FindChild(
    ISystemContext context,
    IList<QualifiedName> browsePath,
    int index)
  {
    if (index < 0 || index >= int.MaxValue)
      throw new ArgumentOutOfRangeException(nameof (index));
    BaseInstanceState child = this.FindChild(context, browsePath[index], false, (BaseInstanceState) null);
    if (child == null)
      return (BaseInstanceState) null;
    return browsePath.Count == index + 1 ? child : child.FindChild(context, browsePath, index + 1);
  }

  public virtual BaseInstanceState CreateChild(ISystemContext context, QualifiedName browseName)
  {
    return QualifiedName.IsNull(browseName) ? (BaseInstanceState) null : this.FindChild(context, browseName, true, (BaseInstanceState) null);
  }

  public virtual void ReplaceChild(ISystemContext context, BaseInstanceState child)
  {
    if (child == null || QualifiedName.IsNull(child.BrowseName))
      throw new ArgumentException("Cannot replace child without a browse name.");
    this.FindChild(context, child.BrowseName, true, child);
  }

  public void AddChild(BaseInstanceState child)
  {
    if (child.Parent != this)
    {
      child.Parent = this;
      if (NodeId.IsNull(child.ReferenceTypeId))
        child.ReferenceTypeId = ReferenceTypeIds.HasComponent;
    }
    if (this.m_children == null)
      this.m_children = new List<BaseInstanceState>();
    this.m_children.Add(child);
    this.m_changeMasks |= NodeStateChangeMasks.Children;
  }

  public PropertyState AddProperty<T>(string propertyName, NodeId dataTypeId, int valueRank)
  {
    PropertyState child = (PropertyState) new PropertyState<T>(this);
    child.ReferenceTypeId = (NodeId) 46U;
    child.ModellingRuleId = (NodeId) null;
    child.TypeDefinitionId = VariableTypeIds.PropertyType;
    child.SymbolicName = propertyName;
    child.NodeId = (NodeId) null;
    child.BrowseName = (QualifiedName) propertyName;
    child.DisplayName = (LocalizedText) propertyName;
    child.Description = (LocalizedText) null;
    child.WriteMask = AttributeWriteMask.None;
    child.UserWriteMask = AttributeWriteMask.None;
    child.Value = (object) default (T);
    child.DataType = dataTypeId;
    child.ValueRank = valueRank;
    child.ArrayDimensions = (ReadOnlyList<uint>) null;
    child.AccessLevel = (byte) 1;
    child.UserAccessLevel = (byte) 1;
    child.MinimumSamplingInterval = -1.0;
    child.Historizing = false;
    this.AddChild((BaseInstanceState) child);
    return child;
  }

  public void RemoveChild(BaseInstanceState child)
  {
    if (this.m_children == null)
      return;
    for (int index = 0; index < this.m_children.Count; ++index)
    {
      if (this.m_children[index] == child)
      {
        child.Parent = (NodeState) null;
        this.m_children.RemoveAt(index);
        this.m_changeMasks |= NodeStateChangeMasks.Children;
        break;
      }
    }
  }

  public bool SetChildValue(
    ISystemContext context,
    QualifiedName browseName,
    BaseInstanceState source,
    bool copy)
  {
    if (source == null)
      return false;
    BaseInstanceState child = this.CreateChild(context, browseName);
    if (child == null)
      return false;
    if (child is BaseVariableState baseVariableState1 && source is BaseVariableState baseVariableState2)
      baseVariableState1.Value = !copy ? baseVariableState2.Value : Utils.Clone(baseVariableState2.Value);
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    source.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
      child.SetChildValue(context, children[index].BrowseName, children[index], copy);
    return true;
  }

  public bool SetChildValue(
    ISystemContext context,
    QualifiedName browseName,
    object value,
    bool copy)
  {
    if (!(this.CreateChild(context, browseName) is BaseVariableState child))
      return false;
    child.Value = !copy ? value : Utils.Clone(value);
    return true;
  }

  public virtual ServiceResult ReadChildAttribute(
    ISystemContext context,
    IList<QualifiedName> relativePath,
    int index,
    uint attributeId,
    DataValue dataValue)
  {
    if (index >= relativePath.Count)
      return this.ReadAttribute(context, attributeId, NumericRange.Empty, (QualifiedName) null, dataValue);
    BaseInstanceState child = this.FindChild(context, relativePath[index], false, (BaseInstanceState) null);
    if (child == null)
      return (ServiceResult) 2150891520U /*0x80340000*/;
    ServiceResult status = child.ReadChildAttribute(context, relativePath, index + 1, attributeId, dataValue);
    return ServiceResult.IsBad(status) ? status : (ServiceResult) 0U;
  }

  public ServiceResult WriteChildAttribute(
    ISystemContext context,
    IList<QualifiedName> componentPath,
    int index,
    uint attributeId,
    DataValue value)
  {
    if (componentPath.Count >= index)
      return this.WriteAttribute(context, attributeId, NumericRange.Empty, value);
    if (this.m_children != null)
    {
      for (int index1 = 0; index1 < this.m_children.Count; ++index1)
      {
        if (!(componentPath[index] != this.m_children[index1].BrowseName))
          return this.m_children[index1].WriteChildAttribute(context, componentPath, index + 1, attributeId, value);
      }
    }
    return (ServiceResult) 2150891520U /*0x80340000*/;
  }

  public bool ReferenceExists(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
  {
    return this.m_references != null && !(referenceTypeId == (object) null) && !(targetId == (object) null) && this.m_references.ContainsKey((IReference) new NodeStateReference(referenceTypeId, isInverse, targetId));
  }

  public void AddReference(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
  {
    if (NodeId.IsNull(referenceTypeId))
      throw new ArgumentNullException(nameof (referenceTypeId));
    if (NodeId.IsNull(targetId))
      throw new ArgumentNullException(nameof (targetId));
    if (this.m_references == null)
      this.m_references = new IReferenceDictionary<object>();
    this.m_references.Add((IReference) new NodeStateReference(referenceTypeId, isInverse, targetId), (object) null);
    this.m_changeMasks |= NodeStateChangeMasks.References;
    NodeStateReferenceAdded onReferenceAdded = this.OnReferenceAdded;
    if (onReferenceAdded == null)
      return;
    onReferenceAdded(this, referenceTypeId, isInverse, targetId);
  }

  public bool RemoveReference(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
  {
    if (NodeId.IsNull(referenceTypeId))
      throw new ArgumentNullException(nameof (referenceTypeId));
    if (NodeId.IsNull(targetId))
      throw new ArgumentNullException(nameof (targetId));
    if (this.m_references == null || !this.m_references.Remove((IReference) new NodeStateReference(referenceTypeId, isInverse, targetId)))
      return false;
    this.m_changeMasks |= NodeStateChangeMasks.References;
    NodeStateReferenceRemoved referenceRemoved = this.OnReferenceRemoved;
    if (referenceRemoved != null)
      referenceRemoved(this, referenceTypeId, isInverse, targetId);
    return true;
  }

  public void AddReferences(IList<IReference> references)
  {
    if (references == null)
      throw new ArgumentNullException(nameof (references));
    if (this.m_references == null)
      this.m_references = new IReferenceDictionary<object>();
    for (int index = 0; index < references.Count; ++index)
    {
      if (!this.m_references.ContainsKey(references[index]))
      {
        this.m_references.Add(references[index], (object) null);
        NodeStateReferenceAdded onReferenceAdded = this.OnReferenceAdded;
        if (onReferenceAdded != null)
          onReferenceAdded(this, references[index].ReferenceTypeId, references[index].IsInverse, references[index].TargetId);
      }
    }
    this.m_changeMasks |= NodeStateChangeMasks.References;
  }

  public bool RemoveReferences(NodeId referenceTypeId, bool isInverse)
  {
    if (NodeId.IsNull(referenceTypeId))
      throw new ArgumentNullException(nameof (referenceTypeId));
    if (this.m_references == null)
      return false;
    List<IReference> list = this.m_references.Select<KeyValuePair<IReference, object>, IReference>((Func<KeyValuePair<IReference, object>, IReference>) (r => r.Key)).Where<IReference>((Func<IReference, bool>) (r => r.ReferenceTypeId == (object) referenceTypeId && r.IsInverse == isInverse)).ToList<IReference>();
    list.ForEach((Action<IReference>) (r => this.RemoveReference(r.ReferenceTypeId, r.IsInverse, r.TargetId)));
    return list.Count != 0;
  }

  public virtual void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
  {
    if (this.m_children == null)
      return;
    for (int index = 0; index < this.m_children.Count; ++index)
      children.Add(this.m_children[index]);
  }

  public virtual void GetReferences(ISystemContext context, IList<IReference> references)
  {
    if (this.m_references == null)
      return;
    foreach (IReference key in (IEnumerable<IReference>) this.m_references.Keys)
      references.Add(key);
  }

  public virtual void GetReferences(
    ISystemContext context,
    IList<IReference> references,
    NodeId referenceTypeId,
    bool isInverse)
  {
    if (this.m_references == null)
      return;
    foreach (IReference key in (IEnumerable<IReference>) this.m_references.Keys)
    {
      if (isInverse == key.IsInverse && key.ReferenceTypeId == (object) referenceTypeId)
        references.Add(key);
    }
  }

  protected virtual BaseInstanceState FindChild(
    ISystemContext context,
    QualifiedName browseName,
    bool createOrReplace,
    BaseInstanceState replacement)
  {
    if (QualifiedName.IsNull(browseName))
      return (BaseInstanceState) null;
    if (this.m_children != null)
    {
      for (int index = 0; index < this.m_children.Count; ++index)
      {
        BaseInstanceState child = this.m_children[index];
        if (browseName == child.BrowseName)
        {
          if (createOrReplace && replacement != null)
            this.m_children[index] = child = replacement;
          return child;
        }
      }
    }
    if (createOrReplace && replacement != null)
      this.AddChild(replacement);
    return (BaseInstanceState) null;
  }

  [Flags]
  public enum AttributesToSave : uint
  {
    None = 0,
    AccessLevel = 1,
    ArrayDimensions = 2,
    BrowseName = 4,
    ContainsNoLoops = 8,
    DataType = 16, // 0x00000010
    Description = 32, // 0x00000020
    DisplayName = 64, // 0x00000040
    EventNotifier = 128, // 0x00000080
    Executable = 256, // 0x00000100
    Historizing = 512, // 0x00000200
    InverseName = 1024, // 0x00000400
    IsAbstract = 2048, // 0x00000800
    MinimumSamplingInterval = 4096, // 0x00001000
    NodeClass = 8192, // 0x00002000
    NodeId = 16384, // 0x00004000
    Symmetric = 32768, // 0x00008000
    UserAccessLevel = 65536, // 0x00010000
    UserExecutable = 131072, // 0x00020000
    UserWriteMask = 262144, // 0x00040000
    ValueRank = 524288, // 0x00080000
    WriteMask = 1048576, // 0x00100000
    Value = 2097152, // 0x00200000
    SymbolicName = 4194304, // 0x00400000
    TypeDefinitionId = 8388608, // 0x00800000
    ModellingRuleId = 16777216, // 0x01000000
    NumericId = 33554432, // 0x02000000
    ReferenceTypeId = 134217728, // 0x08000000
    SuperTypeId = 268435456, // 0x10000000
    StatusCode = 536870912, // 0x20000000
    DataTypeDefinition = 1073741824, // 0x40000000
  }

  public class Notifier
  {
    public NodeState Node;
    public NodeId ReferenceTypeId;
    public bool IsInverse;
  }
}
