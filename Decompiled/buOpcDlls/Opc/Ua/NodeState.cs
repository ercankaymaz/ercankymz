using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;
using Opc.Ua.Export;

namespace Opc.Ua;

[ComVisible(true)]
public abstract class NodeState : IDisposable, IFormattable, ICloneable
{
	[Flags]
	public enum AttributesToSave : uint
	{
		None = 0u,
		AccessLevel = 1u,
		ArrayDimensions = 2u,
		BrowseName = 4u,
		ContainsNoLoops = 8u,
		DataType = 0x10u,
		Description = 0x20u,
		DisplayName = 0x40u,
		EventNotifier = 0x80u,
		Executable = 0x100u,
		Historizing = 0x200u,
		InverseName = 0x400u,
		IsAbstract = 0x800u,
		MinimumSamplingInterval = 0x1000u,
		NodeClass = 0x2000u,
		NodeId = 0x4000u,
		Symmetric = 0x8000u,
		UserAccessLevel = 0x10000u,
		UserExecutable = 0x20000u,
		UserWriteMask = 0x40000u,
		ValueRank = 0x80000u,
		WriteMask = 0x100000u,
		Value = 0x200000u,
		SymbolicName = 0x400000u,
		TypeDefinitionId = 0x800000u,
		ModellingRuleId = 0x1000000u,
		NumericId = 0x2000000u,
		ReferenceTypeId = 0x8000000u,
		SuperTypeId = 0x10000000u,
		StatusCode = 0x20000000u,
		DataTypeDefinition = 0x40000000u
	}

	public class Notifier
	{
		public NodeState Node;

		public NodeId ReferenceTypeId;

		public bool IsInverse;
	}

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

	private List<Notifier> m_notifiers;

	private XmlElement[] m_extensions;

	public string Specification { get; set; }

	public string NodeSetDocumentation { get; set; }

	public object Handle
	{
		get
		{
			return m_handle;
		}
		set
		{
			m_handle = value;
		}
	}

	public NodeStateChangeMasks ChangeMasks
	{
		get
		{
			return m_changeMasks;
		}
		protected set
		{
			m_changeMasks = value;
		}
	}

	public string SymbolicName
	{
		get
		{
			return m_symbolicName;
		}
		set
		{
			m_symbolicName = value;
		}
	}

	public NodeId NodeId
	{
		get
		{
			return m_nodeId;
		}
		set
		{
			if ((object)m_nodeId != value)
			{
				m_changeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_nodeId = value;
		}
	}

	public NodeClass NodeClass => m_nodeClass;

	public QualifiedName BrowseName
	{
		get
		{
			return m_browseName;
		}
		set
		{
			if ((object)m_browseName != value)
			{
				m_changeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_browseName = value;
		}
	}

	public LocalizedText DisplayName
	{
		get
		{
			return m_displayName;
		}
		set
		{
			if ((object)m_displayName != value)
			{
				m_changeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_displayName = value;
		}
	}

	public LocalizedText Description
	{
		get
		{
			return m_description;
		}
		set
		{
			if ((object)m_description != value)
			{
				m_changeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_description = value;
		}
	}

	public AttributeWriteMask WriteMask
	{
		get
		{
			return m_writeMask;
		}
		set
		{
			if (m_writeMask != value)
			{
				m_changeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_writeMask = value;
		}
	}

	public AttributeWriteMask UserWriteMask
	{
		get
		{
			return m_userWriteMask;
		}
		set
		{
			if (m_userWriteMask != value)
			{
				m_changeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_userWriteMask = value;
		}
	}

	public RolePermissionTypeCollection RolePermissions
	{
		get
		{
			return m_rolePermissions;
		}
		set
		{
			if (m_rolePermissions != value)
			{
				m_changeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_rolePermissions = value;
		}
	}

	public RolePermissionTypeCollection UserRolePermissions
	{
		get
		{
			return m_userRolePermissions;
		}
		set
		{
			if (m_userRolePermissions != value)
			{
				m_changeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_userRolePermissions = value;
		}
	}

	public AccessRestrictionType AccessRestrictions
	{
		get
		{
			return m_accessRestrictions;
		}
		set
		{
			if (m_accessRestrictions != value)
			{
				m_changeMasks |= NodeStateChangeMasks.NonValue;
			}
			m_accessRestrictions = value;
		}
	}

	public XmlElement[] Extensions
	{
		get
		{
			return m_extensions;
		}
		set
		{
			m_extensions = value;
		}
	}

	public IList<string> Categories { get; set; }

	public ReleaseStatus ReleaseStatus { get; set; }

	public bool AreEventsMonitored => m_areEventsMonitored > 0;

	public bool Initialized
	{
		get
		{
			return m_initialized;
		}
		set
		{
			m_initialized = value;
		}
	}

	public bool ValidationRequired => OnValidate != null;

	public event NodeStateChangedHandler StateChanged;

	protected NodeState(NodeClass nodeClass)
	{
		m_nodeClass = nodeClass;
	}

	public virtual void Dispose()
	{
		Dispose(disposing: true);
	}

	protected virtual void Dispose(bool disposing)
	{
	}

	public virtual object Clone()
	{
		throw new NotImplementedException();
	}

	protected object CloneChildren(NodeState clone)
	{
		if (m_children != null)
		{
			clone.m_children = new List<BaseInstanceState>(m_children.Count);
			for (int i = 0; i < m_children.Count; i++)
			{
				BaseInstanceState item = (BaseInstanceState)m_children[i].Clone();
				clone.m_children.Add(item);
			}
		}
		clone.m_changeMasks = NodeStateChangeMasks.None;
		return clone;
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
			{
				LoadFromXml(context, input);
				return;
			}
		}
		using MemoryStream istrm = new MemoryStream(Convert.FromBase64String(initializationString));
		LoadAsBinary(context, istrm);
	}

	protected virtual void Initialize(ISystemContext context, NodeState source)
	{
		m_handle = source.m_handle;
		m_symbolicName = source.m_symbolicName;
		m_nodeId = source.m_nodeId;
		m_nodeClass = source.m_nodeClass;
		m_browseName = source.m_browseName;
		m_displayName = source.m_displayName;
		m_description = source.m_description;
		m_writeMask = source.m_writeMask;
		m_children = null;
		m_references = null;
		m_changeMasks = NodeStateChangeMasks.None;
		m_initialized = true;
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		source.GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			BaseInstanceState baseInstanceState = list[i];
			BaseInstanceState baseInstanceState2 = CreateChild(context, baseInstanceState.BrowseName);
			if (baseInstanceState2 == null)
			{
				baseInstanceState2 = (BaseInstanceState)baseInstanceState.Clone();
				AddChild(baseInstanceState2);
			}
			baseInstanceState2.Initialize(context, baseInstanceState);
		}
		List<IReference> list2 = new List<IReference>();
		source.GetReferences(context, list2);
		for (int j = 0; j < list2.Count; j++)
		{
			IReference reference = list2[j];
			AddReference(reference.ReferenceTypeId, reference.IsInverse, reference.TargetId);
		}
	}

	public override string ToString()
	{
		return ToString(null, null);
	}

	public string ToString(string format, IFormatProvider formatProvider)
	{
		if (format != null)
		{
			throw new FormatException(Utils.Format("Invalid format string: '{0}'.", format));
		}
		if (!QualifiedName.IsNull(m_browseName))
		{
			return Utils.Format("[{0}]{1}", m_nodeClass, m_displayName);
		}
		return Utils.Format("[{0}]{1}", m_nodeClass, m_nodeId);
	}

	public void Export(ISystemContext context, NodeTable table)
	{
		Node node = null;
		node = NodeClass switch
		{
			NodeClass.Object => new ObjectNode(), 
			NodeClass.ObjectType => new ObjectTypeNode(), 
			NodeClass.Variable => new VariableNode(), 
			NodeClass.VariableType => new VariableTypeNode(), 
			NodeClass.Method => new MethodNode(), 
			NodeClass.ReferenceType => new ReferenceTypeNode(), 
			NodeClass.DataType => new DataTypeNode(), 
			NodeClass.View => new ViewNode(), 
			_ => new Node(), 
		};
		Export(context, node);
		List<IReference> list = new List<IReference>();
		GetReferences(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			node.ReferenceTable.Add(list[i]);
		}
		table.Attach(node);
		List<BaseInstanceState> list2 = new List<BaseInstanceState>();
		GetChildren(context, list2);
		for (int j = 0; j < list2.Count; j++)
		{
			list2[j].Export(context, table);
		}
	}

	protected virtual void Export(ISystemContext context, Node node)
	{
		node.NodeId = NodeId;
		node.NodeClass = NodeClass;
		node.BrowseName = BrowseName;
		node.DisplayName = DisplayName;
		node.Description = Description;
		node.WriteMask = (uint)WriteMask;
		node.UserWriteMask = (uint)UserWriteMask;
	}

	public void SaveAsXml(ISystemContext context, Stream ostrm)
	{
		ServiceMessageContext context2 = new ServiceMessageContext
		{
			NamespaceUris = context.NamespaceUris,
			ServerUris = context.ServerUris,
			Factory = context.EncodeableFactory
		};
		XmlWriterSettings xmlWriterSettings = Utils.DefaultXmlWriterSettings();
		xmlWriterSettings.CloseOutput = true;
		using XmlWriter writer = XmlWriter.Create(ostrm, xmlWriterSettings);
		using XmlEncoder xmlEncoder = new XmlEncoder(new XmlQualifiedName(SymbolicName, context.NamespaceUris.GetString(BrowseName.NamespaceIndex)), writer, context2);
		xmlEncoder.SaveStringTable("NamespaceUris", "NamespaceUri", context.NamespaceUris);
		xmlEncoder.SaveStringTable("ServerUris", "ServerUri", context.ServerUris);
		Save(context, xmlEncoder);
		SaveReferences(context, xmlEncoder);
		SaveChildren(context, xmlEncoder);
		xmlEncoder.Close();
	}

	public void SaveAsBinary(ISystemContext context, Stream ostrm)
	{
		ServiceMessageContext serviceMessageContext = new ServiceMessageContext();
		serviceMessageContext.NamespaceUris = context.NamespaceUris;
		serviceMessageContext.ServerUris = context.ServerUris;
		serviceMessageContext.Factory = context.EncodeableFactory;
		using BinaryEncoder binaryEncoder = new BinaryEncoder(ostrm, serviceMessageContext, leaveOpen: true);
		binaryEncoder.SaveStringTable(context.NamespaceUris);
		binaryEncoder.SaveStringTable(context.ServerUris);
		AttributesToSave attributesToSave = GetAttributesToSave(context);
		binaryEncoder.WriteUInt32(null, (uint)attributesToSave);
		Save(context, binaryEncoder, attributesToSave);
		SaveReferences(context, binaryEncoder);
		SaveChildren(context, binaryEncoder);
		binaryEncoder.Close();
	}

	public void SaveAsBinary(ISystemContext context, BinaryEncoder encoder)
	{
		AttributesToSave attributesToSave = GetAttributesToSave(context);
		encoder.WriteUInt32(null, (uint)attributesToSave);
		Save(context, encoder, attributesToSave);
		SaveReferences(context, encoder);
		SaveChildren(context, encoder);
	}

	public void LoadAsBinary(ISystemContext context, Stream istrm)
	{
		ServiceMessageContext serviceMessageContext = new ServiceMessageContext();
		serviceMessageContext.NamespaceUris = context.NamespaceUris;
		serviceMessageContext.ServerUris = context.ServerUris;
		serviceMessageContext.Factory = context.EncodeableFactory;
		BinaryDecoder binaryDecoder = new BinaryDecoder(istrm, serviceMessageContext);
		NamespaceTable namespaceTable = new NamespaceTable();
		if (!binaryDecoder.LoadStringTable(namespaceTable))
		{
			namespaceTable = null;
		}
		StringTable stringTable = new StringTable();
		if (namespaceTable != null && namespaceTable.Count > 1)
		{
			stringTable.Append(namespaceTable.GetString(1u));
		}
		if (!binaryDecoder.LoadStringTable(stringTable))
		{
			stringTable = null;
		}
		binaryDecoder.SetMappingTables(namespaceTable, stringTable);
		AttributesToSave attributesToLoad = (AttributesToSave)binaryDecoder.ReadUInt32(null);
		Update(context, binaryDecoder, attributesToLoad);
		UpdateReferences(context, binaryDecoder);
		UpdateChildren(context, binaryDecoder);
	}

	public virtual AttributesToSave GetAttributesToSave(ISystemContext context)
	{
		AttributesToSave attributesToSave = AttributesToSave.None;
		if (!string.IsNullOrEmpty(m_symbolicName) && (m_browseName == null || m_symbolicName != m_browseName.Name))
		{
			attributesToSave |= AttributesToSave.SymbolicName;
		}
		attributesToSave |= AttributesToSave.NodeClass;
		if (!NodeId.IsNull(m_nodeId))
		{
			attributesToSave |= AttributesToSave.NodeId;
		}
		if (!QualifiedName.IsNull(m_browseName))
		{
			attributesToSave |= AttributesToSave.BrowseName;
		}
		if (!LocalizedText.IsNullOrEmpty(m_displayName) && (m_browseName == null || !string.IsNullOrEmpty(m_displayName.Locale) || m_displayName.Text != m_browseName.Name))
		{
			attributesToSave |= AttributesToSave.DisplayName;
		}
		if (!LocalizedText.IsNullOrEmpty(m_description))
		{
			attributesToSave |= AttributesToSave.Description;
		}
		if (m_writeMask != AttributeWriteMask.None)
		{
			attributesToSave |= AttributesToSave.WriteMask;
		}
		if (m_userWriteMask != AttributeWriteMask.None)
		{
			attributesToSave |= AttributesToSave.UserWriteMask;
		}
		return attributesToSave;
	}

	public virtual void Save(ISystemContext context, BinaryEncoder encoder, AttributesToSave attributesToSave)
	{
		encoder.WriteEnumerated(null, m_nodeClass);
		if ((attributesToSave & AttributesToSave.SymbolicName) != AttributesToSave.None)
		{
			encoder.WriteString(null, m_symbolicName);
		}
		if ((attributesToSave & AttributesToSave.BrowseName) != AttributesToSave.None)
		{
			encoder.WriteQualifiedName(null, m_browseName);
		}
		if ((attributesToSave & AttributesToSave.NodeId) != AttributesToSave.None)
		{
			encoder.WriteNodeId(null, m_nodeId);
		}
		if ((attributesToSave & AttributesToSave.DisplayName) != AttributesToSave.None)
		{
			encoder.WriteLocalizedText(null, m_displayName);
		}
		if ((attributesToSave & AttributesToSave.Description) != AttributesToSave.None)
		{
			encoder.WriteLocalizedText(null, m_description);
		}
		if ((attributesToSave & AttributesToSave.WriteMask) != AttributesToSave.None)
		{
			encoder.WriteEnumerated(null, m_writeMask);
		}
		if ((attributesToSave & AttributesToSave.UserWriteMask) != AttributesToSave.None)
		{
			encoder.WriteEnumerated(null, m_userWriteMask);
		}
	}

	public virtual void Update(ISystemContext context, BinaryDecoder decoder, AttributesToSave attributesToLoad)
	{
		if ((attributesToLoad & AttributesToSave.NodeClass) != AttributesToSave.None)
		{
			m_nodeClass = (NodeClass)(object)decoder.ReadEnumerated(null, typeof(NodeClass));
		}
		if ((attributesToLoad & AttributesToSave.SymbolicName) != AttributesToSave.None)
		{
			m_symbolicName = decoder.ReadString(null);
		}
		if ((attributesToLoad & AttributesToSave.BrowseName) != AttributesToSave.None)
		{
			m_browseName = decoder.ReadQualifiedName(null);
		}
		if (string.IsNullOrEmpty(m_symbolicName) && m_browseName != null)
		{
			m_symbolicName = m_browseName.Name;
		}
		if ((attributesToLoad & AttributesToSave.NodeId) != AttributesToSave.None)
		{
			m_nodeId = decoder.ReadNodeId(null);
		}
		if ((attributesToLoad & AttributesToSave.DisplayName) != AttributesToSave.None)
		{
			m_displayName = decoder.ReadLocalizedText(null);
		}
		if (LocalizedText.IsNullOrEmpty(m_displayName) && m_browseName != null)
		{
			m_displayName = m_browseName.Name;
		}
		if ((attributesToLoad & AttributesToSave.Description) != AttributesToSave.None)
		{
			m_description = decoder.ReadLocalizedText(null);
		}
		if ((attributesToLoad & AttributesToSave.WriteMask) != AttributesToSave.None)
		{
			m_writeMask = (AttributeWriteMask)(object)decoder.ReadEnumerated(null, typeof(AttributeWriteMask));
		}
		if ((attributesToLoad & AttributesToSave.UserWriteMask) != AttributesToSave.None)
		{
			m_userWriteMask = (AttributeWriteMask)(object)decoder.ReadEnumerated(null, typeof(AttributeWriteMask));
		}
	}

	public virtual void SaveChildren(ISystemContext context, BinaryEncoder encoder)
	{
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		encoder.WriteInt32(null, list.Count);
		for (int i = 0; i < list.Count; i++)
		{
			BaseInstanceState baseInstanceState = list[i];
			AttributesToSave attributesToSave = baseInstanceState.GetAttributesToSave(context);
			encoder.WriteUInt32(null, (uint)attributesToSave);
			baseInstanceState.Save(context, encoder, attributesToSave);
			baseInstanceState.SaveReferences(context, encoder);
			baseInstanceState.SaveChildren(context, encoder);
		}
	}

	public virtual void UpdateChildren(ISystemContext context, BinaryDecoder decoder)
	{
		int num = decoder.ReadInt32(null);
		for (int i = 0; i < num; i++)
		{
			try
			{
				UpdateChild(context, decoder);
			}
			catch (Exception)
			{
				throw;
			}
		}
	}

	protected BaseInstanceState UpdateChild(ISystemContext context, BinaryDecoder decoder)
	{
		AttributesToSave attributesToSave = (AttributesToSave)decoder.ReadUInt32(null);
		NodeClass nodeClass = NodeClass.Unspecified;
		string text = null;
		QualifiedName qualifiedName = null;
		nodeClass = (NodeClass)(object)decoder.ReadEnumerated(null, typeof(NodeClass));
		attributesToSave = (AttributesToSave)((uint)attributesToSave & 0xFFFFDFFFu);
		if ((attributesToSave & AttributesToSave.SymbolicName) != AttributesToSave.None)
		{
			text = decoder.ReadString(null);
			attributesToSave = (AttributesToSave)((uint)attributesToSave & 0xFFBFFFFFu);
		}
		if ((attributesToSave & AttributesToSave.BrowseName) != AttributesToSave.None)
		{
			qualifiedName = decoder.ReadQualifiedName(null);
			attributesToSave = (AttributesToSave)((uint)attributesToSave & 0xFFFFFFFBu);
		}
		if (string.IsNullOrEmpty(text) && qualifiedName != null)
		{
			text = qualifiedName.Name;
		}
		BaseInstanceState baseInstanceState = CreateChild(context, qualifiedName);
		if (baseInstanceState != null)
		{
			baseInstanceState.SymbolicName = text;
			baseInstanceState.BrowseName = qualifiedName;
			baseInstanceState.Update(context, decoder, attributesToSave);
			baseInstanceState.UpdateReferences(context, decoder);
			baseInstanceState.UpdateChildren(context, decoder);
			return baseInstanceState;
		}
		baseInstanceState = UpdateUnknownChild(context, decoder, this, attributesToSave, nodeClass, text, qualifiedName);
		if (baseInstanceState != null)
		{
			baseInstanceState.BrowseName = qualifiedName;
			AddChild(baseInstanceState);
		}
		return baseInstanceState;
	}

	public static NodeState LoadNode(ISystemContext context, BinaryDecoder decoder)
	{
		AttributesToSave attributesToSave = (AttributesToSave)decoder.ReadUInt32(null);
		NodeClass nodeClass = NodeClass.Unspecified;
		string text = null;
		QualifiedName qualifiedName = null;
		nodeClass = (NodeClass)(object)decoder.ReadEnumerated(null, typeof(NodeClass));
		attributesToSave = (AttributesToSave)((uint)attributesToSave & 0xFFFFDFFFu);
		if ((attributesToSave & AttributesToSave.SymbolicName) != AttributesToSave.None)
		{
			text = decoder.ReadString(null);
			attributesToSave = (AttributesToSave)((uint)attributesToSave & 0xFFBFFFFFu);
		}
		if ((attributesToSave & AttributesToSave.BrowseName) != AttributesToSave.None)
		{
			qualifiedName = decoder.ReadQualifiedName(null);
			attributesToSave = (AttributesToSave)((uint)attributesToSave & 0xFFFFFFFBu);
		}
		if (string.IsNullOrEmpty(text) && qualifiedName != null)
		{
			text = qualifiedName.Name;
		}
		return LoadUnknownNode(context, decoder, attributesToSave, nodeClass, text, qualifiedName);
	}

	public void SaveReferences(ISystemContext context, BinaryEncoder encoder)
	{
		if (m_references == null || m_references.Count <= 0)
		{
			encoder.WriteInt32(null, -1);
			return;
		}
		encoder.WriteInt32(null, m_references.Count);
		foreach (IReference key in m_references.Keys)
		{
			encoder.WriteNodeId(null, key.ReferenceTypeId);
			encoder.WriteBoolean(null, key.IsInverse);
			encoder.WriteExpandedNodeId(null, key.TargetId);
		}
	}

	public void UpdateReferences(ISystemContext context, BinaryDecoder decoder)
	{
		int num = decoder.ReadInt32(null);
		for (int i = 0; i < num; i++)
		{
			NodeId referenceTypeId = decoder.ReadNodeId(null);
			bool isInverse = decoder.ReadBoolean(null);
			ExpandedNodeId targetId = decoder.ReadExpandedNodeId(null);
			if (m_references == null)
			{
				m_references = new IReferenceDictionary<object>();
			}
			m_references[new NodeStateReference(referenceTypeId, isInverse, targetId)] = null;
		}
	}

	public void SaveAsXml(ISystemContext context, XmlEncoder encoder)
	{
		encoder.Push(SymbolicName, context.NamespaceUris.GetString(BrowseName.NamespaceIndex));
		Save(context, encoder);
		SaveReferences(context, encoder);
		SaveChildren(context, encoder);
		encoder.Pop();
	}

	public void LoadFromXml(ISystemContext context, TextReader input)
	{
		using XmlReader reader = XmlReader.Create(input, Utils.DefaultXmlReaderSettings());
		LoadFromXml(context, reader);
	}

	public void LoadFromXml(ISystemContext context, Stream input)
	{
		using XmlReader reader = XmlReader.Create(input, Utils.DefaultXmlReaderSettings());
		LoadFromXml(context, reader);
	}

	public void LoadFromXml(ISystemContext context, XmlReader reader)
	{
		ServiceMessageContext serviceMessageContext = new ServiceMessageContext();
		serviceMessageContext.NamespaceUris = context.NamespaceUris;
		serviceMessageContext.ServerUris = context.ServerUris;
		serviceMessageContext.Factory = context.EncodeableFactory;
		reader.MoveToContent();
		XmlQualifiedName xmlQualifiedName = new XmlQualifiedName(reader.LocalName, reader.NamespaceURI);
		int index = context.NamespaceUris.GetIndex(xmlQualifiedName.Namespace);
		if (index < 0)
		{
			throw ServiceResultException.Create(2147942400u, "Could not resolve namespace uri: {0}", xmlQualifiedName.Namespace);
		}
		SymbolicName = xmlQualifiedName.Name;
		BrowseName = new QualifiedName(xmlQualifiedName.Name, (ushort)index);
		XmlDecoder xmlDecoder = new XmlDecoder(null, reader, serviceMessageContext);
		NamespaceTable namespaceTable = new NamespaceTable();
		if (!xmlDecoder.LoadStringTable("NamespaceUris", "NamespaceUri", namespaceTable))
		{
			namespaceTable = null;
		}
		StringTable stringTable = new StringTable();
		if (!xmlDecoder.LoadStringTable("ServerUris", "ServerUri", stringTable))
		{
			stringTable = null;
		}
		xmlDecoder.SetMappingTables(namespaceTable, stringTable);
		Update(context, xmlDecoder);
		UpdateReferences(context, xmlDecoder);
		UpdateChildren(context, xmlDecoder);
	}

	public void LoadFromXml(ISystemContext context, XmlDecoder decoder)
	{
		XmlQualifiedName xmlQualifiedName = decoder.Peek(XmlNodeType.Element);
		if (xmlQualifiedName == null)
		{
			throw ServiceResultException.Create(2147942400u, "Expecting an XML start element in stream.");
		}
		int index = context.NamespaceUris.GetIndex(xmlQualifiedName.Namespace);
		if (index < 0)
		{
			throw ServiceResultException.Create(2147942400u, "Could not resolve namespace uri: {0}", xmlQualifiedName.Namespace);
		}
		SymbolicName = xmlQualifiedName.Name;
		BrowseName = new QualifiedName(xmlQualifiedName.Name, (ushort)index);
		decoder.ReadStartElement();
		Update(context, decoder);
		UpdateReferences(context, decoder);
		UpdateChildren(context, decoder);
		decoder.Skip(xmlQualifiedName);
	}

	public virtual void Save(ISystemContext context, XmlEncoder encoder)
	{
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		encoder.WriteEnumerated("NodeClass", m_nodeClass);
		if (!NodeId.IsNull(m_nodeId))
		{
			encoder.WriteNodeId("NodeId", m_nodeId);
		}
		if (!QualifiedName.IsNull(m_browseName))
		{
			encoder.WriteQualifiedName("BrowseName", m_browseName);
		}
		if (!LocalizedText.IsNullOrEmpty(m_displayName) && (m_browseName == null || !string.IsNullOrEmpty(m_displayName.Locale) || m_browseName.Name != m_displayName.Text))
		{
			encoder.WriteLocalizedText("DisplayName", m_displayName);
		}
		if (!LocalizedText.IsNullOrEmpty(m_description))
		{
			encoder.WriteLocalizedText("Description", m_description);
		}
		if (m_writeMask != AttributeWriteMask.None)
		{
			encoder.WriteEnumerated("WriteMask", m_writeMask);
		}
		if (m_userWriteMask != AttributeWriteMask.None)
		{
			encoder.WriteEnumerated("UserWriteMask", m_userWriteMask);
		}
		encoder.PopNamespace();
	}

	public virtual void Update(ISystemContext context, XmlDecoder decoder)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (decoder.Peek("NodeClass"))
		{
			NodeClass nodeClass = (NodeClass)(object)decoder.ReadEnumerated("NodeClass", typeof(NodeClass));
			if (NodeClass != NodeClass.Unspecified && nodeClass != NodeClass)
			{
				throw ServiceResultException.Create(2147942400u, "Unexpected NodeClass in input stream. {0} != {1}", NodeClass, nodeClass);
			}
		}
		if (decoder.Peek("NodeId"))
		{
			NodeId nodeId = decoder.ReadNodeId("NodeId");
			if (!NodeId.IsNull(nodeId))
			{
				NodeId = nodeId;
			}
		}
		if (decoder.Peek("BrowseName"))
		{
			QualifiedName qualifiedName = decoder.ReadQualifiedName("BrowseName");
			if (!QualifiedName.IsNull(qualifiedName))
			{
				BrowseName = qualifiedName;
			}
		}
		if (decoder.Peek("DisplayName"))
		{
			DisplayName = decoder.ReadLocalizedText("DisplayName");
		}
		if (LocalizedText.IsNullOrEmpty(m_displayName) && m_browseName != null)
		{
			DisplayName = m_browseName.Name;
		}
		if (decoder.Peek("Description"))
		{
			Description = decoder.ReadLocalizedText("Description");
		}
		if (decoder.Peek("WriteMask"))
		{
			WriteMask = (AttributeWriteMask)(object)decoder.ReadEnumerated("WriteMask", typeof(AttributeWriteMask));
		}
		if (decoder.Peek("UserWriteMask"))
		{
			UserWriteMask = (AttributeWriteMask)(object)decoder.ReadEnumerated("UserWriteMask", typeof(AttributeWriteMask));
		}
		decoder.PopNamespace();
		m_initialized = true;
	}

	public virtual void SaveChildren(ISystemContext context, XmlEncoder encoder)
	{
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			BaseInstanceState baseInstanceState = list[i];
			encoder.Push(baseInstanceState.SymbolicName, context.NamespaceUris.GetString(baseInstanceState.BrowseName.NamespaceIndex));
			baseInstanceState.Save(context, encoder);
			baseInstanceState.SaveReferences(context, encoder);
			baseInstanceState.SaveChildren(context, encoder);
			encoder.Pop();
		}
	}

	public void SaveReferences(ISystemContext context, XmlEncoder encoder)
	{
		if (m_references == null || m_references.Count <= 0)
		{
			return;
		}
		encoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		try
		{
			encoder.Push("References", "http://opcfoundation.org/UA/2008/02/Types.xsd");
			foreach (IReference key in m_references.Keys)
			{
				encoder.Push("Reference", "http://opcfoundation.org/UA/2008/02/Types.xsd");
				if (!NodeId.IsNull(key.ReferenceTypeId))
				{
					encoder.WriteNodeId("ReferenceTypeId", key.ReferenceTypeId);
				}
				if (key.IsInverse)
				{
					encoder.WriteBoolean("IsInverse", key.IsInverse);
				}
				if (!NodeId.IsNull(key.TargetId))
				{
					encoder.WriteExpandedNodeId("TargetId", key.TargetId);
				}
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
		for (BaseInstanceState baseInstanceState = UpdateChild(context, decoder); baseInstanceState != null; baseInstanceState = UpdateChild(context, decoder))
		{
		}
	}

	public virtual void UpdateReferences(ISystemContext context, XmlDecoder decoder)
	{
		if (m_references != null)
		{
			m_references.Clear();
			m_changeMasks |= NodeStateChangeMasks.References;
		}
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		if (!decoder.Peek("References"))
		{
			decoder.PopNamespace();
			return;
		}
		decoder.ReadStartElement();
		while (decoder.Peek("Reference"))
		{
			decoder.ReadStartElement();
			NodeId referenceTypeId = null;
			bool isInverse = false;
			ExpandedNodeId targetId = null;
			if (decoder.Peek("ReferenceTypeId"))
			{
				referenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
			}
			if (decoder.Peek("IsInverse"))
			{
				isInverse = decoder.ReadBoolean("IsInverse");
			}
			if (decoder.Peek("TargetId"))
			{
				targetId = decoder.ReadExpandedNodeId("TargetId");
			}
			if (m_references == null)
			{
				m_references = new IReferenceDictionary<object>();
			}
			m_references[new NodeStateReference(referenceTypeId, isInverse, targetId)] = null;
			m_changeMasks |= NodeStateChangeMasks.References;
			decoder.Skip(new XmlQualifiedName("Reference", "http://opcfoundation.org/UA/2008/02/Types.xsd"));
		}
		decoder.Skip(new XmlQualifiedName("References", "http://opcfoundation.org/UA/2008/02/Types.xsd"));
		decoder.PopNamespace();
	}

	protected BaseInstanceState UpdateChild(ISystemContext context, XmlDecoder decoder)
	{
		XmlQualifiedName xmlQualifiedName = decoder.Peek(XmlNodeType.Element);
		if (xmlQualifiedName == null)
		{
			return null;
		}
		int index = context.NamespaceUris.GetIndex(xmlQualifiedName.Namespace);
		if (index < 0)
		{
			throw ServiceResultException.Create(2147942400u, "Could not resolve namespace uri: {0}", xmlQualifiedName.Namespace);
		}
		decoder.ReadStartElement();
		new QualifiedName(xmlQualifiedName.Name, (ushort)index);
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeClass nodeClass = (NodeClass)(object)decoder.ReadEnumerated("NodeClass", typeof(NodeClass));
		NodeId nodeId = decoder.ReadNodeId("NodeId");
		QualifiedName browseName = decoder.ReadQualifiedName("BrowseName");
		decoder.PopNamespace();
		BaseInstanceState baseInstanceState = CreateChild(context, browseName);
		if (baseInstanceState != null)
		{
			baseInstanceState.SymbolicName = xmlQualifiedName.Name;
			baseInstanceState.NodeId = nodeId;
			baseInstanceState.BrowseName = browseName;
			baseInstanceState.Update(context, decoder);
			baseInstanceState.UpdateReferences(context, decoder);
			baseInstanceState.UpdateChildren(context, decoder);
			decoder.Skip(xmlQualifiedName);
			return baseInstanceState;
		}
		baseInstanceState = UpdateUnknownChild(context, decoder, this, xmlQualifiedName, nodeClass, browseName);
		if (baseInstanceState != null)
		{
			baseInstanceState.NodeId = nodeId;
			AddChild(baseInstanceState);
		}
		return baseInstanceState;
	}

	public static NodeState LoadNode(ISystemContext context, XmlDecoder decoder)
	{
		XmlQualifiedName xmlQualifiedName = decoder.Peek(XmlNodeType.Element);
		if (xmlQualifiedName == null)
		{
			return null;
		}
		int index = context.NamespaceUris.GetIndex(xmlQualifiedName.Namespace);
		if (index < 0)
		{
			throw ServiceResultException.Create(2147942400u, "Could not resolve namespace uri: {0}", xmlQualifiedName.Namespace);
		}
		decoder.ReadStartElement();
		QualifiedName browseName = new QualifiedName(xmlQualifiedName.Name, (ushort)index);
		return LoadUnknownNode(context, decoder, xmlQualifiedName, browseName);
	}

	private static BaseInstanceState UpdateUnknownChild(ISystemContext context, BinaryDecoder decoder, NodeState parent, AttributesToSave attributesToLoad, NodeClass nodeClass, string symbolicName, QualifiedName browseName)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId nodeId = null;
		LocalizedText localizedText = null;
		LocalizedText description = null;
		AttributeWriteMask writeMask = AttributeWriteMask.None;
		AttributeWriteMask userWriteMask = AttributeWriteMask.None;
		NodeId referenceTypeId = null;
		NodeId typeDefinitionId = null;
		if ((attributesToLoad & AttributesToSave.NodeId) != AttributesToSave.None)
		{
			nodeId = decoder.ReadNodeId(null);
			attributesToLoad = (AttributesToSave)((uint)attributesToLoad & 0xFFFFBFFFu);
		}
		if ((attributesToLoad & AttributesToSave.DisplayName) != AttributesToSave.None)
		{
			localizedText = decoder.ReadLocalizedText(null);
			attributesToLoad = (AttributesToSave)((uint)attributesToLoad & 0xFFFFFFBFu);
		}
		if (LocalizedText.IsNullOrEmpty(localizedText) && browseName != null)
		{
			localizedText = browseName.Name;
		}
		if ((attributesToLoad & AttributesToSave.Description) != AttributesToSave.None)
		{
			description = decoder.ReadLocalizedText(null);
			attributesToLoad = (AttributesToSave)((uint)attributesToLoad & 0xFFFFFFDFu);
		}
		if ((attributesToLoad & AttributesToSave.WriteMask) != AttributesToSave.None)
		{
			writeMask = (AttributeWriteMask)(object)decoder.ReadEnumerated(null, typeof(AttributeWriteMask));
			attributesToLoad = (AttributesToSave)((uint)attributesToLoad & 0xFFEFFFFFu);
		}
		if ((attributesToLoad & AttributesToSave.UserWriteMask) != AttributesToSave.None)
		{
			writeMask = (AttributeWriteMask)(object)decoder.ReadEnumerated(null, typeof(AttributeWriteMask));
			attributesToLoad = (AttributesToSave)((uint)attributesToLoad & 0xFFFBFFFFu);
		}
		if ((attributesToLoad & AttributesToSave.ReferenceTypeId) != AttributesToSave.None)
		{
			referenceTypeId = decoder.ReadNodeId(null);
			attributesToLoad = (AttributesToSave)((uint)attributesToLoad & 0xF7FFFFFFu);
		}
		if ((attributesToLoad & AttributesToSave.TypeDefinitionId) != AttributesToSave.None)
		{
			typeDefinitionId = decoder.ReadNodeId(null);
			attributesToLoad = (AttributesToSave)((uint)attributesToLoad & 0xFF7FFFFFu);
		}
		NodeStateFactory nodeStateFactory = context.NodeStateFactory;
		if (nodeStateFactory == null)
		{
			nodeStateFactory = new NodeStateFactory();
		}
		if (!(nodeStateFactory.CreateInstance(context, parent, nodeClass, browseName, referenceTypeId, typeDefinitionId) is BaseInstanceState baseInstanceState))
		{
			throw ServiceResultException.Create(2147942400u, "Could not load child '{0}', with NodeClass {1}", browseName, nodeClass);
		}
		baseInstanceState.SymbolicName = symbolicName;
		baseInstanceState.NodeId = nodeId;
		baseInstanceState.BrowseName = browseName;
		baseInstanceState.DisplayName = localizedText;
		baseInstanceState.Description = description;
		baseInstanceState.WriteMask = writeMask;
		baseInstanceState.UserWriteMask = userWriteMask;
		baseInstanceState.ReferenceTypeId = referenceTypeId;
		baseInstanceState.TypeDefinitionId = typeDefinitionId;
		baseInstanceState.Update(context, decoder, attributesToLoad);
		baseInstanceState.UpdateReferences(context, decoder);
		baseInstanceState.UpdateChildren(context, decoder);
		return baseInstanceState;
	}

	private static NodeState LoadUnknownNode(ISystemContext context, BinaryDecoder decoder, AttributesToSave attributesToLoad, NodeClass nodeClass, string symbolicName, QualifiedName browseName)
	{
		if ((uint)(nodeClass - 1) <= 1u || nodeClass == NodeClass.Method)
		{
			return UpdateUnknownChild(context, decoder, null, attributesToLoad, nodeClass, symbolicName, browseName);
		}
		NodeStateFactory nodeStateFactory = context.NodeStateFactory;
		if (nodeStateFactory == null)
		{
			nodeStateFactory = new NodeStateFactory();
		}
		NodeState nodeState = nodeStateFactory.CreateInstance(context, null, nodeClass, browseName, null, null);
		if (nodeState == null)
		{
			throw ServiceResultException.Create(2147942400u, "Could not load node '{0}', with NodeClass {1}", browseName, nodeClass);
		}
		nodeState.SymbolicName = symbolicName;
		nodeState.BrowseName = browseName;
		nodeState.Update(context, decoder, attributesToLoad);
		nodeState.UpdateReferences(context, decoder);
		nodeState.UpdateChildren(context, decoder);
		return nodeState;
	}

	private static NodeState LoadUnknownNode(ISystemContext context, XmlDecoder decoder, XmlQualifiedName childName, QualifiedName browseName)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeClass nodeClass = (NodeClass)(object)decoder.ReadEnumerated("NodeClass", typeof(NodeClass));
		decoder.PopNamespace();
		if ((uint)(nodeClass - 1) <= 1u || nodeClass == NodeClass.Method)
		{
			return UpdateUnknownChild(context, decoder, null, childName, nodeClass, browseName);
		}
		NodeStateFactory nodeStateFactory = context.NodeStateFactory;
		if (nodeStateFactory == null)
		{
			nodeStateFactory = new NodeStateFactory();
		}
		NodeState nodeState = nodeStateFactory.CreateInstance(context, null, nodeClass, browseName, null, null);
		if (nodeState == null)
		{
			throw ServiceResultException.Create(2147942400u, "Could not load node '{0}', with NodeClass {1}", browseName, nodeClass);
		}
		nodeState.SymbolicName = childName.Name;
		nodeState.Update(context, decoder);
		nodeState.UpdateReferences(context, decoder);
		nodeState.UpdateChildren(context, decoder);
		decoder.Skip(childName);
		return nodeState;
	}

	private static BaseInstanceState UpdateUnknownChild(ISystemContext context, XmlDecoder decoder, NodeState parent, XmlQualifiedName childName, NodeClass nodeClass, QualifiedName browseName)
	{
		decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		NodeId nodeId = decoder.ReadNodeId("NodeId");
		if (decoder.Peek("BrowseName"))
		{
			browseName = decoder.ReadQualifiedName("BrowseName");
		}
		LocalizedText localizedText = null;
		if (decoder.Peek("DisplayName"))
		{
			localizedText = decoder.ReadLocalizedText("DisplayName");
		}
		if (LocalizedText.IsNullOrEmpty(localizedText) && browseName != null)
		{
			localizedText = browseName.Name;
		}
		LocalizedText description = null;
		if (decoder.Peek("Description"))
		{
			description = decoder.ReadLocalizedText("Description");
		}
		AttributeWriteMask writeMask = (AttributeWriteMask)(object)decoder.ReadEnumerated("WriteMask", typeof(AttributeWriteMask));
		AttributeWriteMask userWriteMask = (AttributeWriteMask)(object)decoder.ReadEnumerated("UserWriteMask", typeof(AttributeWriteMask));
		NodeId referenceTypeId = decoder.ReadNodeId("ReferenceTypeId");
		NodeId typeDefinitionId = decoder.ReadNodeId("TypeDefinitionId");
		decoder.PopNamespace();
		NodeStateFactory nodeStateFactory = context.NodeStateFactory;
		if (nodeStateFactory == null)
		{
			nodeStateFactory = new NodeStateFactory();
		}
		if (!(nodeStateFactory.CreateInstance(context, parent, nodeClass, browseName, referenceTypeId, typeDefinitionId) is BaseInstanceState baseInstanceState))
		{
			throw ServiceResultException.Create(2147942400u, "Could not load child '{0}', with NodeClass {1}", browseName, nodeClass);
		}
		baseInstanceState.SymbolicName = childName.Name;
		baseInstanceState.NodeId = nodeId;
		baseInstanceState.BrowseName = browseName;
		baseInstanceState.DisplayName = localizedText;
		baseInstanceState.Description = description;
		baseInstanceState.WriteMask = writeMask;
		baseInstanceState.UserWriteMask = userWriteMask;
		baseInstanceState.ReferenceTypeId = referenceTypeId;
		baseInstanceState.TypeDefinitionId = typeDefinitionId;
		baseInstanceState.Update(context, decoder);
		baseInstanceState.UpdateReferences(context, decoder);
		baseInstanceState.UpdateChildren(context, decoder);
		decoder.Skip(childName);
		return baseInstanceState;
	}

	public NodeState GetHierarchyRoot()
	{
		if (!(this is BaseInstanceState { Parent: not null, Parent: var parent }))
		{
			return this;
		}
		while (parent != null)
		{
			if (!(parent is BaseInstanceState { Parent: not null } baseInstanceState2))
			{
				return parent;
			}
			parent = baseInstanceState2.Parent;
		}
		return parent;
	}

	public void SetAreEventsMonitored(ISystemContext context, bool areEventsMonitored, bool includeChildren)
	{
		if (areEventsMonitored)
		{
			m_areEventsMonitored++;
		}
		else if (m_areEventsMonitored > 0)
		{
			m_areEventsMonitored--;
		}
		if (!includeChildren)
		{
			return;
		}
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].SetAreEventsMonitored(context, areEventsMonitored, includeChildren: true);
		}
		if (m_notifiers == null)
		{
			return;
		}
		for (int j = 0; j < m_notifiers.Count; j++)
		{
			if (!m_notifiers[j].IsInverse)
			{
				m_notifiers[j].Node.SetAreEventsMonitored(context, areEventsMonitored, includeChildren);
			}
		}
	}

	public virtual void ReportEvent(ISystemContext context, IFilterTarget e)
	{
		OnReportEvent?.Invoke(context, this, e);
		if (m_notifiers == null)
		{
			return;
		}
		for (int i = 0; i < m_notifiers.Count; i++)
		{
			if (m_notifiers[i].IsInverse)
			{
				m_notifiers[i].Node.ReportEvent(context, e);
			}
		}
	}

	public virtual void AddNotifier(ISystemContext context, NodeId referenceTypeId, bool isInverse, NodeState target)
	{
		if (m_notifiers == null)
		{
			m_notifiers = new List<Notifier>();
		}
		if (NodeId.IsNull(referenceTypeId))
		{
			referenceTypeId = ReferenceTypeIds.HasEventSource;
		}
		Notifier notifier = null;
		for (int i = 0; i < m_notifiers.Count; i++)
		{
			if (m_notifiers[i].Node == target)
			{
				notifier = m_notifiers[i];
				break;
			}
		}
		if (!NodeId.IsNull(target.NodeId))
		{
			RemoveReference(referenceTypeId, isInverse, target.NodeId);
		}
		if (notifier == null)
		{
			notifier = new Notifier();
			m_notifiers.Add(notifier);
		}
		notifier.ReferenceTypeId = referenceTypeId;
		notifier.IsInverse = isInverse;
		notifier.Node = target;
	}

	public virtual void RemoveNotifier(ISystemContext context, NodeState target, bool bidirectional)
	{
		if (m_notifiers == null)
		{
			return;
		}
		for (int i = 0; i < m_notifiers.Count; i++)
		{
			Notifier notifier = m_notifiers[i];
			if (notifier.Node == target)
			{
				if (bidirectional)
				{
					notifier.Node.RemoveNotifier(context, this, bidirectional: false);
				}
				m_notifiers.RemoveAt(i);
				break;
			}
		}
		if (m_notifiers.Count == 0)
		{
			m_notifiers = null;
		}
	}

	public virtual void GetNotifiers(ISystemContext context, IList<Notifier> notifiers)
	{
		if (m_notifiers == null)
		{
			return;
		}
		foreach (Notifier notifier in m_notifiers)
		{
			notifiers.Add(notifier);
		}
	}

	public virtual void GetNotifiers(ISystemContext context, IList<Notifier> notifiers, NodeId notifierTypeId, bool isInverse)
	{
		if (m_notifiers == null)
		{
			return;
		}
		foreach (Notifier notifier in m_notifiers)
		{
			if (isInverse == notifier.IsInverse && notifier.ReferenceTypeId == notifierTypeId)
			{
				notifiers.Add(notifier);
			}
		}
	}

	public virtual void ConditionRefresh(ISystemContext context, List<IFilterTarget> events, bool includeChildren)
	{
		OnConditionRefresh?.Invoke(context, this, events);
		if (!includeChildren)
		{
			return;
		}
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].ConditionRefresh(context, events, includeChildren: true);
		}
		if (m_notifiers == null)
		{
			return;
		}
		for (int j = 0; j < m_notifiers.Count; j++)
		{
			if (!m_notifiers[j].IsInverse)
			{
				m_notifiers[j].Node.ConditionRefresh(context, events, includeChildren: true);
			}
		}
	}

	public virtual MethodState FindMethod(ISystemContext context, NodeId methodId)
	{
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			if (list[i] is MethodState methodState && (methodState.NodeId == methodId || methodState.MethodDeclarationId == methodId))
			{
				return methodState;
			}
		}
		return null;
	}

	public void UpdateChangeMasks(NodeStateChangeMasks changeMasks)
	{
		m_changeMasks |= changeMasks;
	}

	public void ClearChangeMasks(ISystemContext context, bool includeChildren)
	{
		if (includeChildren)
		{
			List<BaseInstanceState> list = new List<BaseInstanceState>();
			GetChildren(context, list);
			for (int i = 0; i < list.Count; i++)
			{
				list[i].ClearChangeMasks(context, includeChildren: true);
			}
		}
		if (m_changeMasks != NodeStateChangeMasks.None)
		{
			OnStateChanged?.Invoke(context, this, m_changeMasks);
			this.StateChanged?.Invoke(context, this, m_changeMasks);
			m_changeMasks = NodeStateChangeMasks.None;
		}
	}

	public virtual void SetStatusCode(ISystemContext context, StatusCode statusCode, DateTime timestamp)
	{
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].SetStatusCode(context, statusCode, timestamp);
		}
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

	public virtual void Create(ISystemContext context, NodeId nodeId, QualifiedName browseName, LocalizedText displayName, bool assignNodeIds)
	{
		Initialize(context);
		CallOnBeforeCreate(context);
		if (nodeId != null)
		{
			NodeId = nodeId;
		}
		if (!QualifiedName.IsNull(browseName))
		{
			SymbolicName = browseName.Name;
			BrowseName = browseName;
			DisplayName = browseName.Name;
		}
		if (displayName != null)
		{
			DisplayName = displayName;
		}
		List<BaseInstanceState> children = new List<BaseInstanceState>();
		GetChildren(context, children);
		if (assignNodeIds)
		{
			CallOnBeforeAssignNodeIds(context, children);
			Dictionary<NodeId, NodeId> mappingTable = new Dictionary<NodeId, NodeId>();
			AssignNodeIds(context, children, mappingTable);
			UpdateReferenceTargets(context, children, mappingTable);
		}
		CallOnAfterCreate(context, children);
		ClearChangeMasks(context, includeChildren: true);
	}

	private void CallOnBeforeCreate(ISystemContext context)
	{
		OnBeforeCreate(context, this);
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].CallOnBeforeCreate(context);
		}
	}

	private void CallOnBeforeAssignNodeIds(ISystemContext context, List<BaseInstanceState> children)
	{
		OnBeforeAssignNodeIds(context);
		if (children == null)
		{
			children = new List<BaseInstanceState>();
			GetChildren(context, children);
		}
		for (int i = 0; i < children.Count; i++)
		{
			children[i].CallOnBeforeAssignNodeIds(context, null);
		}
	}

	private void CallOnAfterCreate(ISystemContext context, List<BaseInstanceState> children)
	{
		if (children == null)
		{
			children = new List<BaseInstanceState>();
			GetChildren(context, children);
		}
		for (int i = 0; i < children.Count; i++)
		{
			children[i].CallOnAfterCreate(context, null);
		}
		OnAfterCreate(context, this);
	}

	public virtual void Create(ISystemContext context, NodeState source)
	{
		Initialize(context, source);
		CallOnBeforeCreate(context);
		CallOnAfterCreate(context, null);
		ClearChangeMasks(context, includeChildren: true);
	}

	public virtual void Delete(ISystemContext context)
	{
		OnBeforeDelete(context);
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			list[i].Delete(context);
		}
		OnAfterDelete(context);
		ChangeMasks = NodeStateChangeMasks.Deleted;
		ClearChangeMasks(context, includeChildren: false);
	}

	public virtual void AssignNodeIds(ISystemContext context, Dictionary<NodeId, NodeId> mappingTable)
	{
		List<BaseInstanceState> children = new List<BaseInstanceState>();
		GetChildren(context, children);
		AssignNodeIds(context, children, mappingTable);
	}

	private void AssignNodeIds(ISystemContext context, List<BaseInstanceState> children, Dictionary<NodeId, NodeId> mappingTable)
	{
		if (context.NodeIdFactory != null)
		{
			NodeId nodeId = NodeId;
			NodeId nodeId2 = context.NodeIdFactory.New(context, this);
			if (!NodeId.IsNull(nodeId))
			{
				mappingTable[nodeId] = nodeId2;
			}
			NodeId = nodeId2;
			for (int i = 0; i < children.Count; i++)
			{
				children[i].AssignNodeIds(context, mappingTable);
			}
		}
	}

	public virtual bool Validate(ISystemContext context)
	{
		if (OnValidate != null)
		{
			return OnValidate(context, this);
		}
		return true;
	}

	public virtual INodeBrowser CreateBrowser(ISystemContext context, ViewDescription view, NodeId referenceType, bool includeSubtypes, BrowseDirection browseDirection, QualifiedName browseName, IEnumerable<IReference> additionalReferences, bool internalOnly)
	{
		NodeBrowser nodeBrowser = null;
		if (OnCreateBrowser != null)
		{
			nodeBrowser = OnCreateBrowser(context, this, view, referenceType, includeSubtypes, browseDirection, browseName, additionalReferences, internalOnly);
		}
		if (nodeBrowser == null)
		{
			nodeBrowser = new NodeBrowser(context, view, referenceType, includeSubtypes, browseDirection, browseName, additionalReferences, internalOnly);
		}
		PopulateBrowser(context, nodeBrowser);
		OnPopulateBrowser?.Invoke(context, this, nodeBrowser);
		return nodeBrowser;
	}

	public void GetInstanceHierarchy(ISystemContext context, string browsePath, Dictionary<NodeId, string> hierarchy)
	{
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			BaseInstanceState baseInstanceState = list[i];
			string text = Utils.Format("{0}/{1}", browsePath, baseInstanceState.SymbolicName);
			hierarchy[baseInstanceState.NodeId] = text;
			baseInstanceState.GetInstanceHierarchy(context, text, hierarchy);
		}
	}

	public void GetHierarchyReferences(ISystemContext context, string browsePath, Dictionary<NodeId, string> hierarchy, List<NodeStateHierarchyReference> references)
	{
		if (m_references != null)
		{
			foreach (IReference key in m_references.Keys)
			{
				NodeId nodeId = ExpandedNodeId.ToNodeId(key.TargetId, context.NamespaceUris);
				if (nodeId == null)
				{
					references.Add(new NodeStateHierarchyReference(browsePath, key));
					continue;
				}
				string value = null;
				if (!hierarchy.TryGetValue(nodeId, out value))
				{
					references.Add(new NodeStateHierarchyReference(browsePath, key));
				}
				else
				{
					references.Add(new NodeStateHierarchyReference(browsePath, value, key));
				}
			}
		}
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			string browsePath2 = Utils.Format("{0}/{1}", browsePath, list[i].SymbolicName);
			list[i].GetHierarchyReferences(context, browsePath2, hierarchy, references);
		}
	}

	public virtual void UpdateReferenceTargets(ISystemContext context, Dictionary<NodeId, NodeId> mappingTable)
	{
		List<BaseInstanceState> children = new List<BaseInstanceState>();
		GetChildren(context, children);
		UpdateReferenceTargets(context, children, mappingTable);
	}

	private void UpdateReferenceTargets(ISystemContext context, List<BaseInstanceState> children, Dictionary<NodeId, NodeId> mappingTable)
	{
		if (m_references != null)
		{
			List<IReference> list = new List<IReference>();
			List<IReference> list2 = new List<IReference>();
			foreach (IReference key in m_references.Keys)
			{
				NodeId nodeId = ExpandedNodeId.ToNodeId(key.TargetId, context.NamespaceUris);
				if (!(nodeId == null))
				{
					NodeId value = null;
					if (mappingTable.TryGetValue(nodeId, out value))
					{
						list2.Add(key);
						list.Add(new NodeStateReference(key.ReferenceTypeId, key.IsInverse, value));
					}
				}
			}
			for (int i = 0; i < list2.Count; i++)
			{
				if (m_references.Remove(list2[i]))
				{
					m_changeMasks |= NodeStateChangeMasks.References;
				}
			}
			for (int j = 0; j < list.Count; j++)
			{
				m_references[list[j]] = null;
				m_changeMasks |= NodeStateChangeMasks.References;
			}
		}
		for (int k = 0; k < children.Count; k++)
		{
			children[k].UpdateReferenceTargets(context, mappingTable);
		}
	}

	protected virtual void PopulateBrowser(ISystemContext context, NodeBrowser browser)
	{
		NodeId nodeId = browser.ReferenceType;
		if (NodeId.IsNull(nodeId) || browser.ReferenceType == ReferenceTypeIds.References)
		{
			nodeId = null;
		}
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		bool flag = nodeId == null;
		if (!flag && context.TypeTable != null && context.TypeTable.IsTypeOf(browser.ReferenceType, ReferenceTypeIds.HierarchicalReferences) && browser.BrowseDirection != BrowseDirection.Inverse)
		{
			flag = true;
		}
		if (flag)
		{
			GetChildren(context, list);
		}
		for (int i = 0; i < list.Count; i++)
		{
			BaseInstanceState baseInstanceState = list[i];
			if (browser.IsRequired(baseInstanceState) && browser.IsRequired(baseInstanceState.ReferenceTypeId, isInverse: false))
			{
				browser.Add(baseInstanceState.ReferenceTypeId, isInverse: false, baseInstanceState);
			}
		}
		if (m_notifiers != null)
		{
			for (int j = 0; j < m_notifiers.Count; j++)
			{
				Notifier notifier = m_notifiers[j];
				if (browser.IsRequired(notifier.ReferenceTypeId, notifier.IsInverse))
				{
					browser.Add(notifier.ReferenceTypeId, notifier.IsInverse, m_notifiers[j].Node);
				}
			}
		}
		if (m_references == null)
		{
			return;
		}
		if (nodeId == null)
		{
			foreach (IReference key in m_references.Keys)
			{
				if (key.IsInverse)
				{
					if (browser.BrowseDirection == BrowseDirection.Forward)
					{
						continue;
					}
				}
				else if (browser.BrowseDirection == BrowseDirection.Inverse)
				{
					continue;
				}
				browser.Add(key);
			}
			return;
		}
		IList<IReference> list2 = null;
		if (browser.BrowseDirection != BrowseDirection.Inverse)
		{
			list2 = ((!browser.IncludeSubtypes) ? m_references.Find(browser.ReferenceType, isInverse: false) : m_references.Find(browser.ReferenceType, isInverse: false, context.TypeTable));
			for (int k = 0; k < list2.Count; k++)
			{
				browser.Add(list2[k]);
			}
		}
		if (browser.BrowseDirection != BrowseDirection.Forward)
		{
			list2 = ((!browser.IncludeSubtypes) ? m_references.Find(browser.ReferenceType, isInverse: true) : m_references.Find(browser.ReferenceType, isInverse: true, context.TypeTable));
			for (int l = 0; l < list2.Count; l++)
			{
				browser.Add(list2[l]);
			}
		}
	}

	public virtual void UpdateValues(ISystemContext context, SimpleAttributeOperandCollection attributes, EventFieldList values)
	{
		for (int i = 0; i < attributes.Count; i++)
		{
			NodeState nodeState = FindChild(context, attributes[i].BrowsePath, 0);
			if (nodeState == null || values.EventFields.Count >= i)
			{
				continue;
			}
			if (nodeState is BaseVariableState baseVariableState)
			{
				baseVariableState.Value = values.EventFields[i].Value;
			}
			else if (nodeState is BaseObjectState baseObjectState)
			{
				NodeId nodeId = values.EventFields[i].Value as NodeId;
				if (nodeId != null)
				{
					baseObjectState.NodeId = nodeId;
				}
			}
		}
	}

	public virtual List<object> ReadAttributes(ISystemContext context, params uint[] attributeIds)
	{
		List<object> list = new List<object>();
		if (attributeIds != null)
		{
			for (int i = 0; i < attributeIds.Length; i++)
			{
				DataValue dataValue = new DataValue();
				if (ServiceResult.IsBad(ReadAttribute(context, attributeIds[i], NumericRange.Empty, null, dataValue)))
				{
					list.Add(null);
				}
				else
				{
					list.Add(dataValue.Value);
				}
			}
		}
		return list;
	}

	public virtual ServiceResult ReadAttribute(ISystemContext context, uint attributeId, NumericRange indexRange, QualifiedName dataEncoding, DataValue value)
	{
		if (value == null)
		{
			return 2152071168u;
		}
		ServiceResult serviceResult = null;
		object value2 = value.Value;
		if (attributeId == 13)
		{
			DateTime sourceTimestamp = value.SourceTimestamp;
			try
			{
				serviceResult = ReadValueAttribute(context, indexRange, dataEncoding, ref value2, ref sourceTimestamp);
				value.SourceTimestamp = sourceTimestamp;
				value.SourcePicoseconds = 0;
			}
			catch (Exception exception)
			{
				serviceResult = new ServiceResult(exception, 2147549184u);
			}
		}
		else
		{
			try
			{
				serviceResult = ReadNonValueAttribute(context, attributeId, ref value2);
			}
			catch (Exception exception2)
			{
				serviceResult = new ServiceResult(exception2, 2147549184u);
			}
		}
		if (serviceResult != null && serviceResult != ServiceResult.Good)
		{
			value.StatusCode = serviceResult.StatusCode;
		}
		else
		{
			value.StatusCode = 0u;
		}
		if (StatusCode.IsBad(value.StatusCode))
		{
			value.Value = null;
		}
		else
		{
			value.Value = value2;
		}
		return serviceResult;
	}

	protected virtual ServiceResult ReadNonValueAttribute(ISystemContext context, uint attributeId, ref object value)
	{
		ServiceResult serviceResult = null;
		switch (attributeId)
		{
		case 1u:
		{
			NodeId value10 = m_nodeId;
			if (OnReadNodeId != null)
			{
				serviceResult = OnReadNodeId(context, this, ref value10);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value10;
			}
			return serviceResult;
		}
		case 2u:
		{
			NodeClass value7 = m_nodeClass;
			if (OnReadNodeClass != null)
			{
				serviceResult = OnReadNodeClass(context, this, ref value7);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value7;
			}
			return serviceResult;
		}
		case 3u:
		{
			QualifiedName value4 = m_browseName;
			if (OnReadBrowseName != null)
			{
				serviceResult = OnReadBrowseName(context, this, ref value4);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value4;
			}
			return serviceResult;
		}
		case 4u:
		{
			LocalizedText value11 = m_displayName;
			if (OnReadDisplayName != null)
			{
				serviceResult = OnReadDisplayName(context, this, ref value11);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value11;
			}
			if (value != null || serviceResult != null)
			{
				return serviceResult;
			}
			break;
		}
		case 5u:
		{
			LocalizedText value3 = m_description;
			if (OnReadDescription != null)
			{
				serviceResult = OnReadDescription(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value3;
			}
			if (value != null || serviceResult != null)
			{
				return serviceResult;
			}
			break;
		}
		case 6u:
		{
			AttributeWriteMask value5 = m_writeMask;
			if (OnReadWriteMask != null)
			{
				serviceResult = OnReadWriteMask(context, this, ref value5);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = (uint)value5;
			}
			return serviceResult;
		}
		case 7u:
		{
			AttributeWriteMask value6 = m_userWriteMask;
			if (OnReadUserWriteMask != null)
			{
				serviceResult = OnReadUserWriteMask(context, this, ref value6);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = (uint)value6;
			}
			return serviceResult;
		}
		case 24u:
		{
			RolePermissionTypeCollection value8 = m_rolePermissions;
			if (OnReadRolePermissions != null)
			{
				serviceResult = OnReadRolePermissions(context, this, ref value8);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value8;
			}
			if (value != null || serviceResult != null)
			{
				return serviceResult;
			}
			break;
		}
		case 25u:
		{
			RolePermissionTypeCollection value9 = m_userRolePermissions;
			if (OnReadUserRolePermissions != null)
			{
				serviceResult = OnReadUserRolePermissions(context, this, ref value9);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = value9;
			}
			if (value != null || serviceResult != null)
			{
				return serviceResult;
			}
			break;
		}
		case 26u:
		{
			AccessRestrictionType value2 = m_accessRestrictions;
			if (OnReadAccessRestrictions != null)
			{
				serviceResult = OnReadAccessRestrictions(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				value = (ushort)m_accessRestrictions;
			}
			if (value != null || serviceResult != null)
			{
				return serviceResult;
			}
			break;
		}
		}
		return 2150957056u;
	}

	protected virtual ServiceResult ReadValueAttribute(ISystemContext context, NumericRange indexRange, QualifiedName dataEncoding, ref object value, ref DateTime sourceTimestamp)
	{
		value = null;
		sourceTimestamp = DateTime.MinValue;
		return 2150957056u;
	}

	public ServiceResult WriteAttribute(ISystemContext context, uint attributeId, NumericRange indexRange, DataValue value)
	{
		if (value == null)
		{
			return 2152071168u;
		}
		object value2 = value.Value;
		if (attributeId == 13)
		{
			if (value.ServerTimestamp != DateTime.MinValue)
			{
				return 2155020288u;
			}
			try
			{
				return WriteValueAttribute(context, indexRange, value2, value.StatusCode, value.SourceTimestamp);
			}
			catch (Exception exception)
			{
				return new ServiceResult(exception, 2147549184u);
			}
		}
		if (value.StatusCode != 0u || value.ServerTimestamp != DateTime.MinValue || value.SourceTimestamp != DateTime.MinValue)
		{
			return 2155020288u;
		}
		if (indexRange != NumericRange.Empty)
		{
			return 2151022592u;
		}
		try
		{
			return WriteNonValueAttribute(context, attributeId, value.Value);
		}
		catch (Exception exception2)
		{
			return new ServiceResult(exception2, 2147549184u);
		}
	}

	protected virtual ServiceResult WriteNonValueAttribute(ISystemContext context, uint attributeId, object value)
	{
		ServiceResult serviceResult = null;
		switch (attributeId)
		{
		case 1u:
		{
			NodeId value3 = value as NodeId;
			if (value3 == null)
			{
				return 2155085824u;
			}
			if ((WriteMask & AttributeWriteMask.NodeId) == 0)
			{
				return 2151350272u;
			}
			if (OnWriteNodeId != null)
			{
				serviceResult = OnWriteNodeId(context, this, ref value3);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				m_nodeId = value3;
			}
			return serviceResult;
		}
		case 2u:
		{
			int? num4 = value as int?;
			if (!num4.HasValue)
			{
				return 2155085824u;
			}
			if ((WriteMask & AttributeWriteMask.NodeClass) == 0)
			{
				return 2151350272u;
			}
			NodeClass value8 = (NodeClass)num4.Value;
			if (OnWriteNodeClass != null)
			{
				serviceResult = OnWriteNodeClass(context, this, ref value8);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				m_nodeClass = value8;
			}
			return serviceResult;
		}
		case 3u:
		{
			QualifiedName value9 = value as QualifiedName;
			if (value9 == null)
			{
				return 2155085824u;
			}
			if ((WriteMask & AttributeWriteMask.BrowseName) == 0)
			{
				return 2151350272u;
			}
			if (OnWriteBrowseName != null)
			{
				serviceResult = OnWriteBrowseName(context, this, ref value9);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				m_browseName = value9;
			}
			return serviceResult;
		}
		case 4u:
		{
			LocalizedText value10 = value as LocalizedText;
			if (value10 == null)
			{
				return 2155085824u;
			}
			if ((WriteMask & AttributeWriteMask.DisplayName) == 0)
			{
				return 2151350272u;
			}
			if (OnWriteDisplayName != null)
			{
				serviceResult = OnWriteDisplayName(context, this, ref value10);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				m_displayName = value10;
			}
			return serviceResult;
		}
		case 5u:
		{
			LocalizedText value4 = value as LocalizedText;
			if (value4 == null && value != null)
			{
				return 2155085824u;
			}
			if ((WriteMask & AttributeWriteMask.Description) == 0)
			{
				return 2151350272u;
			}
			if (OnWriteDescription != null)
			{
				serviceResult = OnWriteDescription(context, this, ref value4);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				m_description = value4;
			}
			return serviceResult;
		}
		case 6u:
		{
			uint? num2 = value as uint?;
			if (!num2.HasValue)
			{
				return 2155085824u;
			}
			if ((WriteMask & AttributeWriteMask.WriteMask) == 0)
			{
				return 2151350272u;
			}
			AttributeWriteMask value6 = (AttributeWriteMask)num2.Value;
			if (OnWriteWriteMask != null)
			{
				serviceResult = OnWriteWriteMask(context, this, ref value6);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				WriteMask = value6;
			}
			return serviceResult;
		}
		case 7u:
		{
			uint? num3 = value as uint?;
			if (!num3.HasValue)
			{
				return 2155085824u;
			}
			if ((WriteMask & AttributeWriteMask.UserWriteMask) == 0)
			{
				return 2151350272u;
			}
			AttributeWriteMask value7 = (AttributeWriteMask)num3.Value;
			if (OnWriteUserWriteMask != null)
			{
				serviceResult = OnWriteUserWriteMask(context, this, ref value7);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				m_userWriteMask = value7;
			}
			return serviceResult;
		}
		case 24u:
		{
			if (!(value is ExtensionObject[] array))
			{
				return 2155085824u;
			}
			RolePermissionTypeCollection value5 = new RolePermissionTypeCollection();
			ExtensionObject[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				if (!(array2[i].Body is RolePermissionType item))
				{
					return 2155085824u;
				}
				value5.Add(item);
			}
			if ((WriteMask & AttributeWriteMask.RolePermissions) == 0)
			{
				return 2151350272u;
			}
			if (OnWriteRolePermissions != null)
			{
				serviceResult = OnWriteRolePermissions(context, this, ref value5);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				m_rolePermissions = value5;
			}
			return serviceResult;
		}
		case 26u:
		{
			ushort? num = value as ushort?;
			if (!num.HasValue && value != null)
			{
				if (!(value.GetType() == typeof(uint)))
				{
					return 2155085824u;
				}
				num = Convert.ToUInt16(value);
			}
			if ((WriteMask & AttributeWriteMask.AccessRestrictions) == 0)
			{
				return 2151350272u;
			}
			AccessRestrictionType value2 = (AccessRestrictionType)num.Value;
			if (OnWriteAccessRestrictions != null)
			{
				serviceResult = OnWriteAccessRestrictions(context, this, ref value2);
			}
			if (ServiceResult.IsGood(serviceResult))
			{
				m_accessRestrictions = value2;
			}
			return serviceResult;
		}
		default:
			return 2150957056u;
		}
	}

	protected virtual ServiceResult WriteValueAttribute(ISystemContext context, NumericRange indexRange, object value, StatusCode statusCode, DateTime sourceTimestamp)
	{
		return 2150957056u;
	}

	public virtual BaseInstanceState FindChildBySymbolicName(ISystemContext context, string symbolicPath)
	{
		if (string.IsNullOrEmpty(symbolicPath))
		{
			return null;
		}
		int i;
		for (i = 0; i < symbolicPath.Length && symbolicPath[i] == '/'; i++)
		{
		}
		if (i >= symbolicPath.Length)
		{
			return null;
		}
		int j;
		for (j = i + 1; j < symbolicPath.Length && symbolicPath[j] != '/'; j++)
		{
		}
		string text = symbolicPath;
		if (i > 0 || j < symbolicPath.Length)
		{
			text = symbolicPath.Substring(i, j - i);
		}
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		GetChildren(context, list);
		for (int k = 0; k < list.Count; k++)
		{
			BaseInstanceState baseInstanceState = list[k];
			if (baseInstanceState.SymbolicName == text)
			{
				if (j < symbolicPath.Length - 1)
				{
					return baseInstanceState.FindChildBySymbolicName(context, symbolicPath.Substring(j + 1));
				}
				return baseInstanceState;
			}
		}
		return null;
	}

	public virtual BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName)
	{
		return FindChild(context, browseName, createOrReplace: false, null);
	}

	public virtual BaseInstanceState FindChild(ISystemContext context, IList<QualifiedName> browsePath, int index)
	{
		if (index < 0 || index >= int.MaxValue)
		{
			throw new ArgumentOutOfRangeException("index");
		}
		BaseInstanceState baseInstanceState = FindChild(context, browsePath[index], createOrReplace: false, null);
		if (baseInstanceState != null)
		{
			if (browsePath.Count == index + 1)
			{
				return baseInstanceState;
			}
			return baseInstanceState.FindChild(context, browsePath, index + 1);
		}
		return null;
	}

	public virtual BaseInstanceState CreateChild(ISystemContext context, QualifiedName browseName)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		return FindChild(context, browseName, createOrReplace: true, null);
	}

	public virtual void ReplaceChild(ISystemContext context, BaseInstanceState child)
	{
		if (child == null || QualifiedName.IsNull(child.BrowseName))
		{
			throw new ArgumentException("Cannot replace child without a browse name.");
		}
		FindChild(context, child.BrowseName, createOrReplace: true, child);
	}

	public void AddChild(BaseInstanceState child)
	{
		if (child.Parent != this)
		{
			child.Parent = this;
			if (NodeId.IsNull(child.ReferenceTypeId))
			{
				child.ReferenceTypeId = ReferenceTypeIds.HasComponent;
			}
		}
		if (m_children == null)
		{
			m_children = new List<BaseInstanceState>();
		}
		m_children.Add(child);
		m_changeMasks |= NodeStateChangeMasks.Children;
	}

	public PropertyState AddProperty<T>(string propertyName, NodeId dataTypeId, int valueRank)
	{
		PropertyState propertyState = new PropertyState<T>(this);
		propertyState.ReferenceTypeId = 46u;
		propertyState.ModellingRuleId = null;
		propertyState.TypeDefinitionId = VariableTypeIds.PropertyType;
		propertyState.SymbolicName = propertyName;
		propertyState.NodeId = null;
		propertyState.BrowseName = propertyName;
		propertyState.DisplayName = propertyName;
		propertyState.Description = null;
		propertyState.WriteMask = AttributeWriteMask.None;
		propertyState.UserWriteMask = AttributeWriteMask.None;
		propertyState.Value = default(T);
		propertyState.DataType = dataTypeId;
		propertyState.ValueRank = valueRank;
		propertyState.ArrayDimensions = null;
		propertyState.AccessLevel = 1;
		propertyState.UserAccessLevel = 1;
		propertyState.MinimumSamplingInterval = -1.0;
		propertyState.Historizing = false;
		AddChild(propertyState);
		return propertyState;
	}

	public void RemoveChild(BaseInstanceState child)
	{
		if (m_children == null)
		{
			return;
		}
		for (int i = 0; i < m_children.Count; i++)
		{
			if (m_children[i] == child)
			{
				child.Parent = null;
				m_children.RemoveAt(i);
				m_changeMasks |= NodeStateChangeMasks.Children;
				break;
			}
		}
	}

	public bool SetChildValue(ISystemContext context, QualifiedName browseName, BaseInstanceState source, bool copy)
	{
		if (source == null)
		{
			return false;
		}
		BaseInstanceState baseInstanceState = CreateChild(context, browseName);
		if (baseInstanceState == null)
		{
			return false;
		}
		if (baseInstanceState is BaseVariableState baseVariableState && source is BaseVariableState baseVariableState2)
		{
			if (copy)
			{
				baseVariableState.Value = Utils.Clone(baseVariableState2.Value);
			}
			else
			{
				baseVariableState.Value = baseVariableState2.Value;
			}
		}
		List<BaseInstanceState> list = new List<BaseInstanceState>();
		source.GetChildren(context, list);
		for (int i = 0; i < list.Count; i++)
		{
			baseInstanceState.SetChildValue(context, list[i].BrowseName, list[i], copy);
		}
		return true;
	}

	public bool SetChildValue(ISystemContext context, QualifiedName browseName, object value, bool copy)
	{
		if (!(CreateChild(context, browseName) is BaseVariableState baseVariableState))
		{
			return false;
		}
		if (copy)
		{
			baseVariableState.Value = Utils.Clone(value);
		}
		else
		{
			baseVariableState.Value = value;
		}
		return true;
	}

	public virtual ServiceResult ReadChildAttribute(ISystemContext context, IList<QualifiedName> relativePath, int index, uint attributeId, DataValue dataValue)
	{
		if (index >= relativePath.Count)
		{
			return ReadAttribute(context, attributeId, NumericRange.Empty, null, dataValue);
		}
		BaseInstanceState baseInstanceState = FindChild(context, relativePath[index], createOrReplace: false, null);
		if (baseInstanceState == null)
		{
			return 2150891520u;
		}
		ServiceResult serviceResult = baseInstanceState.ReadChildAttribute(context, relativePath, index + 1, attributeId, dataValue);
		if (ServiceResult.IsBad(serviceResult))
		{
			return serviceResult;
		}
		return 0u;
	}

	public ServiceResult WriteChildAttribute(ISystemContext context, IList<QualifiedName> componentPath, int index, uint attributeId, DataValue value)
	{
		if (componentPath.Count >= index)
		{
			return WriteAttribute(context, attributeId, NumericRange.Empty, value);
		}
		if (m_children != null)
		{
			for (int i = 0; i < m_children.Count; i++)
			{
				if (!(componentPath[index] != m_children[i].BrowseName))
				{
					return m_children[i].WriteChildAttribute(context, componentPath, index + 1, attributeId, value);
				}
			}
		}
		return 2150891520u;
	}

	public bool ReferenceExists(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
	{
		if (m_references == null || referenceTypeId == null || targetId == null)
		{
			return false;
		}
		return m_references.ContainsKey(new NodeStateReference(referenceTypeId, isInverse, targetId));
	}

	public void AddReference(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
	{
		if (NodeId.IsNull(referenceTypeId))
		{
			throw new ArgumentNullException("referenceTypeId");
		}
		if (NodeId.IsNull(targetId))
		{
			throw new ArgumentNullException("targetId");
		}
		if (m_references == null)
		{
			m_references = new IReferenceDictionary<object>();
		}
		m_references.Add(new NodeStateReference(referenceTypeId, isInverse, targetId), null);
		m_changeMasks |= NodeStateChangeMasks.References;
		OnReferenceAdded?.Invoke(this, referenceTypeId, isInverse, targetId);
	}

	public bool RemoveReference(NodeId referenceTypeId, bool isInverse, ExpandedNodeId targetId)
	{
		if (NodeId.IsNull(referenceTypeId))
		{
			throw new ArgumentNullException("referenceTypeId");
		}
		if (NodeId.IsNull(targetId))
		{
			throw new ArgumentNullException("targetId");
		}
		if (m_references == null)
		{
			return false;
		}
		if (m_references.Remove(new NodeStateReference(referenceTypeId, isInverse, targetId)))
		{
			m_changeMasks |= NodeStateChangeMasks.References;
			OnReferenceRemoved?.Invoke(this, referenceTypeId, isInverse, targetId);
			return true;
		}
		return false;
	}

	public void AddReferences(IList<IReference> references)
	{
		if (references == null)
		{
			throw new ArgumentNullException("references");
		}
		if (m_references == null)
		{
			m_references = new IReferenceDictionary<object>();
		}
		for (int i = 0; i < references.Count; i++)
		{
			if (!m_references.ContainsKey(references[i]))
			{
				m_references.Add(references[i], null);
				OnReferenceAdded?.Invoke(this, references[i].ReferenceTypeId, references[i].IsInverse, references[i].TargetId);
			}
		}
		m_changeMasks |= NodeStateChangeMasks.References;
	}

	public bool RemoveReferences(NodeId referenceTypeId, bool isInverse)
	{
		if (NodeId.IsNull(referenceTypeId))
		{
			throw new ArgumentNullException("referenceTypeId");
		}
		if (m_references == null)
		{
			return false;
		}
		List<IReference> list = (from r in m_references
			select r.Key into r
			where r.ReferenceTypeId == referenceTypeId && r.IsInverse == isInverse
			select r).ToList();
		list.ForEach(delegate(IReference r)
		{
			RemoveReference(r.ReferenceTypeId, r.IsInverse, r.TargetId);
		});
		return list.Count != 0;
	}

	public virtual void GetChildren(ISystemContext context, IList<BaseInstanceState> children)
	{
		if (m_children != null)
		{
			for (int i = 0; i < m_children.Count; i++)
			{
				children.Add(m_children[i]);
			}
		}
	}

	public virtual void GetReferences(ISystemContext context, IList<IReference> references)
	{
		if (m_references == null)
		{
			return;
		}
		foreach (IReference key in m_references.Keys)
		{
			references.Add(key);
		}
	}

	public virtual void GetReferences(ISystemContext context, IList<IReference> references, NodeId referenceTypeId, bool isInverse)
	{
		if (m_references == null)
		{
			return;
		}
		foreach (IReference key in m_references.Keys)
		{
			if (isInverse == key.IsInverse && key.ReferenceTypeId == referenceTypeId)
			{
				references.Add(key);
			}
		}
	}

	protected virtual BaseInstanceState FindChild(ISystemContext context, QualifiedName browseName, bool createOrReplace, BaseInstanceState replacement)
	{
		if (QualifiedName.IsNull(browseName))
		{
			return null;
		}
		if (m_children != null)
		{
			for (int i = 0; i < m_children.Count; i++)
			{
				BaseInstanceState baseInstanceState = m_children[i];
				if (browseName == baseInstanceState.BrowseName)
				{
					if (createOrReplace && replacement != null)
					{
						baseInstanceState = (m_children[i] = replacement);
					}
					return baseInstanceState;
				}
			}
		}
		if (createOrReplace && replacement != null)
		{
			AddChild(replacement);
		}
		return null;
	}
}
