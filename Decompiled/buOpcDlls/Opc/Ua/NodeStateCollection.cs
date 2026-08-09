using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;
using Opc.Ua.Export;

namespace Opc.Ua;

[ComVisible(true)]
public class NodeStateCollection : List<NodeState>
{
	private struct AliasToUse(string alias, NodeId nodeId)
	{
		public string Alias = alias;

		public NodeId NodeId = nodeId;
	}

	private AliasToUse[] s_AliasesToUse = new AliasToUse[46]
	{
		new AliasToUse("Boolean", DataTypeIds.Boolean),
		new AliasToUse("SByte", DataTypeIds.SByte),
		new AliasToUse("Byte", DataTypeIds.Byte),
		new AliasToUse("Int16", DataTypeIds.Int16),
		new AliasToUse("UInt16", DataTypeIds.UInt16),
		new AliasToUse("Int32", DataTypeIds.Int32),
		new AliasToUse("UInt32", DataTypeIds.UInt32),
		new AliasToUse("Int64", DataTypeIds.Int64),
		new AliasToUse("UInt64", DataTypeIds.UInt64),
		new AliasToUse("Float", DataTypeIds.Float),
		new AliasToUse("Double", DataTypeIds.Double),
		new AliasToUse("DateTime", DataTypeIds.DateTime),
		new AliasToUse("String", DataTypeIds.String),
		new AliasToUse("ByteString", DataTypeIds.ByteString),
		new AliasToUse("Guid", DataTypeIds.Guid),
		new AliasToUse("XmlElement", DataTypeIds.XmlElement),
		new AliasToUse("NodeId", DataTypeIds.NodeId),
		new AliasToUse("ExpandedNodeId", DataTypeIds.ExpandedNodeId),
		new AliasToUse("QualifiedName", DataTypeIds.QualifiedName),
		new AliasToUse("LocalizedText", DataTypeIds.LocalizedText),
		new AliasToUse("StatusCode", DataTypeIds.StatusCode),
		new AliasToUse("Structure", DataTypeIds.Structure),
		new AliasToUse("Number", DataTypeIds.Number),
		new AliasToUse("Integer", DataTypeIds.Integer),
		new AliasToUse("UInteger", DataTypeIds.UInteger),
		new AliasToUse("HasComponent", ReferenceTypeIds.HasComponent),
		new AliasToUse("HasProperty", ReferenceTypeIds.HasProperty),
		new AliasToUse("Organizes", ReferenceTypeIds.Organizes),
		new AliasToUse("HasEventSource", ReferenceTypeIds.HasEventSource),
		new AliasToUse("HasNotifier", ReferenceTypeIds.HasNotifier),
		new AliasToUse("HasSubtype", ReferenceTypeIds.HasSubtype),
		new AliasToUse("HasTypeDefinition", ReferenceTypeIds.HasTypeDefinition),
		new AliasToUse("HasModellingRule", ReferenceTypeIds.HasModellingRule),
		new AliasToUse("HasEncoding", ReferenceTypeIds.HasEncoding),
		new AliasToUse("HasDescription", ReferenceTypeIds.HasDescription),
		new AliasToUse("HasCause", ReferenceTypeIds.HasCause),
		new AliasToUse("ToState", ReferenceTypeIds.ToState),
		new AliasToUse("FromState", ReferenceTypeIds.FromState),
		new AliasToUse("HasEffect", ReferenceTypeIds.HasEffect),
		new AliasToUse("HasTrueSubState", ReferenceTypeIds.HasTrueSubState),
		new AliasToUse("HasFalseSubState", ReferenceTypeIds.HasFalseSubState),
		new AliasToUse("HasDictionaryEntry", ReferenceTypeIds.HasDictionaryEntry),
		new AliasToUse("HasCondition", ReferenceTypeIds.HasCondition),
		new AliasToUse("HasGuard", ReferenceTypeIds.HasGuard),
		new AliasToUse("HasAddIn", ReferenceTypeIds.HasAddIn),
		new AliasToUse("HasInterface", ReferenceTypeIds.HasInterface)
	};

	public void SaveAsNodeSet2(ISystemContext context, Stream ostrm, ModelTableEntry model, DateTime lastModified, bool outputRedundantNames)
	{
		UANodeSet uANodeSet = new UANodeSet();
		if (lastModified != DateTime.MinValue)
		{
			uANodeSet.LastModified = lastModified;
			uANodeSet.LastModifiedSpecified = true;
		}
		uANodeSet.NamespaceUris = ((context.NamespaceUris != null) ? (from x in context.NamespaceUris.ToArray()
			where x != "http://opcfoundation.org/UA/"
			select x).ToArray() : null);
		uANodeSet.ServerUris = ((context.ServerUris != null) ? context.ServerUris.ToArray() : null);
		if (uANodeSet.NamespaceUris != null && uANodeSet.NamespaceUris.Length == 0)
		{
			uANodeSet.NamespaceUris = null;
		}
		if (uANodeSet.ServerUris != null && uANodeSet.ServerUris.Length == 0)
		{
			uANodeSet.ServerUris = null;
		}
		if (model != null)
		{
			uANodeSet.Models = new ModelTableEntry[1] { model };
		}
		for (int num = 0; num < s_AliasesToUse.Length; num++)
		{
			uANodeSet.AddAlias(context, s_AliasesToUse[num].Alias, s_AliasesToUse[num].NodeId);
		}
		for (int num2 = 0; num2 < base.Count; num2++)
		{
			uANodeSet.Export(context, base[num2], outputRedundantNames);
		}
		uANodeSet.Write(ostrm);
	}

	public NodeStateCollection()
	{
	}

	public NodeStateCollection(int capacity)
		: base(capacity)
	{
	}

	public NodeStateCollection(IEnumerable<NodeState> collection)
		: base(collection)
	{
	}

	public void SaveAsNodeSet(ISystemContext context, Stream ostrm)
	{
		NodeTable nodeTable = new NodeTable(context.NamespaceUris, context.ServerUris, null);
		for (int i = 0; i < base.Count; i++)
		{
			base[i].Export(context, nodeTable);
		}
		NodeSet nodeSet = new NodeSet();
		foreach (ILocalNode item in nodeTable)
		{
			nodeSet.Add(item, nodeTable.NamespaceUris, nodeTable.ServerUris);
		}
		XmlWriterSettings xmlWriterSettings = Utils.DefaultXmlWriterSettings();
		xmlWriterSettings.CloseOutput = true;
		using XmlWriter writer = XmlWriter.Create(ostrm, xmlWriterSettings);
		new DataContractSerializer(typeof(NodeSet)).WriteObject(writer, nodeSet);
	}

	public void SaveAsNodeSet2(ISystemContext context, Stream ostrm)
	{
		SaveAsNodeSet2(context, ostrm, null);
	}

	public void SaveAsNodeSet2(ISystemContext context, Stream ostrm, string version)
	{
		UANodeSet uANodeSet = new UANodeSet();
		uANodeSet.LastModified = DateTime.UtcNow;
		uANodeSet.LastModifiedSpecified = true;
		for (int i = 0; i < s_AliasesToUse.Length; i++)
		{
			uANodeSet.AddAlias(context, s_AliasesToUse[i].Alias, s_AliasesToUse[i].NodeId);
		}
		for (int j = 0; j < base.Count; j++)
		{
			uANodeSet.Export(context, base[j]);
		}
		uANodeSet.Write(ostrm);
	}

	public void SaveAsXml(ISystemContext context, Stream ostrm)
	{
		SaveAsXml(context, ostrm, keepStreamOpen: false);
	}

	public void SaveAsXml(ISystemContext context, Stream ostrm, bool keepStreamOpen)
	{
		XmlWriterSettings xmlWriterSettings = Utils.DefaultXmlWriterSettings();
		xmlWriterSettings.CloseOutput = !keepStreamOpen;
		ServiceMessageContext context2 = new ServiceMessageContext
		{
			NamespaceUris = context.NamespaceUris,
			ServerUris = context.ServerUris,
			Factory = context.EncodeableFactory
		};
		using XmlWriter writer = XmlWriter.Create(ostrm, xmlWriterSettings);
		using XmlEncoder xmlEncoder = new XmlEncoder(new XmlQualifiedName("ListOfNodeState", "http://opcfoundation.org/UA/2008/02/Types.xsd"), writer, context2);
		xmlEncoder.SaveStringTable("NamespaceUris", "NamespaceUri", context.NamespaceUris);
		xmlEncoder.SaveStringTable("ServerUris", "ServerUri", context.ServerUris);
		for (int i = 0; i < base.Count; i++)
		{
			base[i]?.SaveAsXml(context, xmlEncoder);
		}
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
		binaryEncoder.WriteInt32(null, base.Count);
		for (int i = 0; i < base.Count; i++)
		{
			base[i].SaveAsBinary(context, binaryEncoder);
		}
		binaryEncoder.Close();
	}

	public void LoadFromBinary(ISystemContext context, Stream istrm, bool updateTables)
	{
		ServiceMessageContext serviceMessageContext = new ServiceMessageContext();
		serviceMessageContext.NamespaceUris = context.NamespaceUris;
		serviceMessageContext.ServerUris = context.ServerUris;
		serviceMessageContext.Factory = context.EncodeableFactory;
		using BinaryDecoder binaryDecoder = new BinaryDecoder(istrm, serviceMessageContext);
		NamespaceTable namespaceTable = new NamespaceTable();
		if (!binaryDecoder.LoadStringTable(namespaceTable))
		{
			namespaceTable = null;
		}
		if (updateTables && namespaceTable != null && context.NamespaceUris != null)
		{
			for (int i = 0; i < namespaceTable.Count; i++)
			{
				context.NamespaceUris.GetIndexOrAppend(namespaceTable.GetString((uint)i));
			}
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
		if (updateTables && stringTable != null && context.ServerUris != null)
		{
			for (int j = 0; j < stringTable.Count; j++)
			{
				context.ServerUris.GetIndexOrAppend(stringTable.GetString((uint)j));
			}
		}
		binaryDecoder.SetMappingTables(namespaceTable, stringTable);
		int num = binaryDecoder.ReadInt32(null);
		for (int k = 0; k < num; k++)
		{
			NodeState item = NodeState.LoadNode(context, binaryDecoder);
			Add(item);
		}
	}

	public void LoadFromXml(ISystemContext context, Stream istrm, bool updateTables)
	{
		ServiceMessageContext serviceMessageContext = new ServiceMessageContext();
		serviceMessageContext.NamespaceUris = context.NamespaceUris;
		serviceMessageContext.ServerUris = context.ServerUris;
		serviceMessageContext.Factory = context.EncodeableFactory;
		using XmlReader reader = XmlReader.Create(istrm, Utils.DefaultXmlReaderSettings());
		XmlDecoder xmlDecoder = new XmlDecoder(null, reader, serviceMessageContext);
		NamespaceTable namespaceTable = new NamespaceTable();
		if (!xmlDecoder.LoadStringTable("NamespaceUris", "NamespaceUri", namespaceTable))
		{
			namespaceTable = null;
		}
		if (updateTables && namespaceTable != null && context.NamespaceUris != null)
		{
			for (int i = 0; i < namespaceTable.Count; i++)
			{
				context.NamespaceUris.GetIndexOrAppend(namespaceTable.GetString((uint)i));
			}
		}
		StringTable stringTable = new StringTable();
		if (!xmlDecoder.LoadStringTable("ServerUris", "ServerUri", context.ServerUris))
		{
			stringTable = null;
		}
		if (updateTables && stringTable != null && context.ServerUris != null)
		{
			for (int j = 0; j < stringTable.Count; j++)
			{
				context.ServerUris.GetIndexOrAppend(stringTable.GetString((uint)j));
			}
		}
		xmlDecoder.SetMappingTables(namespaceTable, stringTable);
		xmlDecoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
		for (NodeState nodeState = NodeState.LoadNode(context, xmlDecoder); nodeState != null; nodeState = NodeState.LoadNode(context, xmlDecoder))
		{
			Add(nodeState);
		}
		xmlDecoder.Close();
	}

	public void LoadFromResource(ISystemContext context, string resourcePath, Assembly assembly, bool updateTables)
	{
		if (resourcePath == null)
		{
			throw new ArgumentNullException("resourcePath");
		}
		if (assembly == null)
		{
			throw new ArgumentNullException("assembly");
		}
		Stream stream = assembly.GetManifestResourceStream(resourcePath);
		if (stream == null)
		{
			stream = new FileInfo(resourcePath).OpenRead();
			if (stream == null)
			{
				throw ServiceResultException.Create(2147942400u, "Could not load nodes from resource: {0}", resourcePath);
			}
		}
		LoadFromXml(context, stream, updateTables);
	}

	public void LoadFromBinaryResource(ISystemContext context, string resourcePath, Assembly assembly, bool updateTables)
	{
		if (resourcePath == null)
		{
			throw new ArgumentNullException("resourcePath");
		}
		if (assembly == null)
		{
			throw new ArgumentNullException("assembly");
		}
		Stream stream = assembly.GetManifestResourceStream(resourcePath);
		if (stream == null)
		{
			stream = new FileInfo(resourcePath).OpenRead();
			if (stream == null)
			{
				throw ServiceResultException.Create(2147942400u, "Could not load nodes from resource: {0}", resourcePath);
			}
		}
		LoadFromBinary(context, stream, updateTables);
	}
}
