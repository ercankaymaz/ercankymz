using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Opc.Ua.Export;

[Serializable]
[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[XmlRoot(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd", IsNullable = false)]
[ComVisible(true)]
public class UANodeSet
{
	private string[] namespaceUrisField;

	private string[] serverUrisField;

	private ModelTableEntry[] modelsField;

	private NodeIdAlias[] aliasesField;

	private XmlElement[] extensionsField;

	private UANode[] itemsField;

	private DateTime lastModifiedField;

	private bool lastModifiedFieldSpecified;

	[XmlArrayItem("Uri", IsNullable = false)]
	public string[] NamespaceUris
	{
		get
		{
			return namespaceUrisField;
		}
		set
		{
			namespaceUrisField = value;
		}
	}

	[XmlArrayItem("Uri", IsNullable = false)]
	public string[] ServerUris
	{
		get
		{
			return serverUrisField;
		}
		set
		{
			serverUrisField = value;
		}
	}

	[XmlArrayItem("Model", IsNullable = false)]
	public ModelTableEntry[] Models
	{
		get
		{
			return modelsField;
		}
		set
		{
			modelsField = value;
		}
	}

	[XmlArrayItem("Alias", IsNullable = false)]
	public NodeIdAlias[] Aliases
	{
		get
		{
			return aliasesField;
		}
		set
		{
			aliasesField = value;
		}
	}

	[XmlArrayItem("Extension", IsNullable = false)]
	public XmlElement[] Extensions
	{
		get
		{
			return extensionsField;
		}
		set
		{
			extensionsField = value;
		}
	}

	[XmlElement("UADataType", typeof(UADataType))]
	[XmlElement("UAMethod", typeof(UAMethod))]
	[XmlElement("UAObject", typeof(UAObject))]
	[XmlElement("UAObjectType", typeof(UAObjectType))]
	[XmlElement("UAReferenceType", typeof(UAReferenceType))]
	[XmlElement("UAVariable", typeof(UAVariable))]
	[XmlElement("UAVariableType", typeof(UAVariableType))]
	[XmlElement("UAView", typeof(UAView))]
	public UANode[] Items
	{
		get
		{
			return itemsField;
		}
		set
		{
			itemsField = value;
		}
	}

	[XmlAttribute]
	public DateTime LastModified
	{
		get
		{
			return lastModifiedField;
		}
		set
		{
			lastModifiedField = value;
		}
	}

	[XmlIgnore]
	public bool LastModifiedSpecified
	{
		get
		{
			return lastModifiedFieldSpecified;
		}
		set
		{
			lastModifiedFieldSpecified = value;
		}
	}

	public static UANodeSet Read(Stream istrm)
	{
		using StreamReader input = new StreamReader(istrm);
		using XmlReader xmlReader = XmlReader.Create(input, Utils.DefaultXmlReaderSettings());
		return new XmlSerializer(typeof(UANodeSet)).Deserialize(xmlReader) as UANodeSet;
	}

	public void Write(Stream istrm)
	{
		XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
		XmlWriter xmlWriter = XmlWriter.Create(istrm, settings);
		try
		{
			new XmlSerializer(typeof(UANodeSet)).Serialize(xmlWriter, this, null);
		}
		finally
		{
			xmlWriter.Flush();
			xmlWriter.Dispose();
		}
	}

	public void AddAlias(ISystemContext context, string alias, NodeId nodeId)
	{
		int num = 1;
		if (Aliases != null)
		{
			for (int i = 0; i < Aliases.Length; i++)
			{
				if (Aliases[i].Alias == alias)
				{
					Aliases[i].Value = Export(nodeId, context.NamespaceUris);
					return;
				}
			}
			num += Aliases.Length;
		}
		NodeIdAlias[] array = new NodeIdAlias[num];
		if (Aliases != null)
		{
			Array.Copy(Aliases, array, Aliases.Length);
		}
		array[num - 1] = new NodeIdAlias
		{
			Alias = alias,
			Value = Export(nodeId, context.NamespaceUris)
		};
		Aliases = array;
	}

	public void Import(ISystemContext context, NodeStateCollection nodes)
	{
		for (int i = 0; i < Items.Length; i++)
		{
			UANode node = Items[i];
			NodeState item = Import(context, node);
			nodes.Add(item);
		}
	}

	public void Export(ISystemContext context, NodeState node, bool outputRedundantNames = true)
	{
		if (node == null)
		{
			throw new ArgumentNullException("node");
		}
		if (NodeId.IsNull(node.NodeId))
		{
			throw new ArgumentException("A non-null NodeId must be specified.");
		}
		UANode uANode = null;
		switch (node.NodeClass)
		{
		case NodeClass.Object:
		{
			BaseObjectState baseObjectState = (BaseObjectState)node;
			UAObject uAObject = new UAObject();
			uAObject.EventNotifier = baseObjectState.EventNotifier;
			if (baseObjectState.Parent != null)
			{
				uAObject.ParentNodeId = ExportAlias(baseObjectState.Parent.NodeId, context.NamespaceUris);
			}
			uANode = uAObject;
			break;
		}
		case NodeClass.Variable:
		{
			BaseVariableState baseVariableState = (BaseVariableState)node;
			UAVariable uAVariable = new UAVariable();
			uAVariable.DataType = ExportAlias(baseVariableState.DataType, context.NamespaceUris);
			uAVariable.ValueRank = baseVariableState.ValueRank;
			uAVariable.ArrayDimensions = Export(baseVariableState.ArrayDimensions);
			uAVariable.AccessLevel = baseVariableState.AccessLevelEx;
			uAVariable.MinimumSamplingInterval = baseVariableState.MinimumSamplingInterval;
			uAVariable.Historizing = baseVariableState.Historizing;
			if (baseVariableState.Parent != null)
			{
				uAVariable.ParentNodeId = ExportAlias(baseVariableState.Parent.NodeId, context.NamespaceUris);
			}
			if (baseVariableState.Value != null)
			{
				using XmlEncoder xmlEncoder2 = CreateEncoder(context);
				Variant variant2 = new Variant(baseVariableState.Value);
				xmlEncoder2.WriteVariantContents(variant2.Value, variant2.TypeInfo);
				XmlDocument xmlDocument2 = new XmlDocument();
				xmlDocument2.LoadInnerXml(xmlEncoder2.CloseAndReturnText());
				uAVariable.Value = xmlDocument2.DocumentElement;
			}
			uANode = uAVariable;
			break;
		}
		case NodeClass.Method:
		{
			MethodState methodState = (MethodState)node;
			UAMethod uAMethod = new UAMethod();
			uAMethod.Executable = methodState.Executable;
			if (methodState.MethodDeclarationId != null && !methodState.MethodDeclarationId.IsNullNodeId && methodState.MethodDeclarationId != methodState.NodeId)
			{
				uAMethod.MethodDeclarationId = Export(methodState.MethodDeclarationId, context.NamespaceUris);
			}
			if (methodState.Parent != null)
			{
				uAMethod.ParentNodeId = ExportAlias(methodState.Parent.NodeId, context.NamespaceUris);
			}
			uANode = uAMethod;
			break;
		}
		case NodeClass.View:
		{
			ViewState viewState = (ViewState)node;
			uANode = new UAView
			{
				ContainsNoLoops = viewState.ContainsNoLoops
			};
			break;
		}
		case NodeClass.ObjectType:
		{
			BaseObjectTypeState baseObjectTypeState = (BaseObjectTypeState)node;
			uANode = new UAObjectType
			{
				IsAbstract = baseObjectTypeState.IsAbstract
			};
			break;
		}
		case NodeClass.VariableType:
		{
			BaseVariableTypeState baseVariableTypeState = (BaseVariableTypeState)node;
			UAVariableType uAVariableType = new UAVariableType();
			uAVariableType.IsAbstract = baseVariableTypeState.IsAbstract;
			uAVariableType.DataType = ExportAlias(baseVariableTypeState.DataType, context.NamespaceUris);
			uAVariableType.ValueRank = baseVariableTypeState.ValueRank;
			uAVariableType.ArrayDimensions = Export(baseVariableTypeState.ArrayDimensions);
			if (baseVariableTypeState.Value != null)
			{
				using XmlEncoder xmlEncoder = CreateEncoder(context);
				Variant variant = new Variant(baseVariableTypeState.Value);
				xmlEncoder.WriteVariantContents(variant.Value, variant.TypeInfo);
				XmlDocument xmlDocument = new XmlDocument();
				xmlDocument.LoadInnerXml(xmlEncoder.CloseAndReturnText());
				uAVariableType.Value = xmlDocument.DocumentElement;
			}
			uANode = uAVariableType;
			break;
		}
		case NodeClass.DataType:
		{
			DataTypeState dataTypeState = (DataTypeState)node;
			uANode = new UADataType
			{
				IsAbstract = dataTypeState.IsAbstract,
				Definition = Export(dataTypeState, dataTypeState.DataTypeDefinition, context.NamespaceUris, outputRedundantNames),
				Purpose = dataTypeState.Purpose
			};
			break;
		}
		case NodeClass.ReferenceType:
		{
			ReferenceTypeState referenceTypeState = (ReferenceTypeState)node;
			UAReferenceType uAReferenceType = new UAReferenceType();
			uAReferenceType.IsAbstract = referenceTypeState.IsAbstract;
			if (!Opc.Ua.LocalizedText.IsNullOrEmpty(referenceTypeState.InverseName))
			{
				uAReferenceType.InverseName = Export(new Opc.Ua.LocalizedText[1] { referenceTypeState.InverseName });
			}
			uAReferenceType.Symmetric = referenceTypeState.Symmetric;
			uANode = uAReferenceType;
			break;
		}
		}
		uANode.NodeId = Export(node.NodeId, context.NamespaceUris);
		uANode.BrowseName = Export(node.BrowseName, context.NamespaceUris);
		if (outputRedundantNames || node.DisplayName.Text != node.BrowseName.Name)
		{
			uANode.DisplayName = Export(new Opc.Ua.LocalizedText[1] { node.DisplayName });
		}
		else
		{
			uANode.DisplayName = null;
		}
		if (node.Description != null && !string.IsNullOrEmpty(node.Description.Text))
		{
			uANode.Description = Export(new Opc.Ua.LocalizedText[1] { node.Description });
		}
		else
		{
			uANode.Description = Array.Empty<LocalizedText>();
		}
		uANode.Documentation = node.NodeSetDocumentation;
		uANode.Category = ((node.Categories != null && node.Categories.Count > 0) ? new List<string>(node.Categories).ToArray() : null);
		uANode.ReleaseStatus = node.ReleaseStatus;
		uANode.WriteMask = (uint)node.WriteMask;
		uANode.UserWriteMask = (uint)node.UserWriteMask;
		uANode.Extensions = node.Extensions;
		if (!string.IsNullOrEmpty(node.SymbolicName) && node.SymbolicName != node.BrowseName.Name)
		{
			uANode.SymbolicName = node.SymbolicName;
		}
		INodeBrowser nodeBrowser = node.CreateBrowser(context, null, null, includeSubtypes: true, BrowseDirection.Both, null, null, internalOnly: true);
		List<Reference> list = new List<Reference>();
		IReference reference = nodeBrowser.Next();
		while (reference != null)
		{
			if (node.NodeClass == NodeClass.Method && !reference.IsInverse && reference.ReferenceTypeId == ReferenceTypeIds.HasTypeDefinition)
			{
				reference = nodeBrowser.Next();
				continue;
			}
			Reference reference2 = new Reference();
			reference2.ReferenceType = ExportAlias(reference.ReferenceTypeId, context.NamespaceUris);
			reference2.IsForward = !reference.IsInverse;
			reference2.Value = Export(reference.TargetId, context.NamespaceUris, context.ServerUris);
			list.Add(reference2);
			reference = nodeBrowser.Next();
		}
		uANode.References = list.ToArray();
		UANode[] array = null;
		int num = 1;
		if (Items == null)
		{
			array = new UANode[num];
		}
		else
		{
			num += Items.Length;
			array = new UANode[num];
			Array.Copy(Items, array, Items.Length);
		}
		array[num - 1] = uANode;
		Items = array;
		List<BaseInstanceState> list2 = new List<BaseInstanceState>();
		node.GetChildren(context, list2);
		for (int i = 0; i < list2.Count; i++)
		{
			Export(context, list2[i], outputRedundantNames);
		}
	}

	private XmlEncoder CreateEncoder(ISystemContext context)
	{
		XmlEncoder xmlEncoder = new XmlEncoder(new ServiceMessageContext
		{
			NamespaceUris = context.NamespaceUris,
			ServerUris = context.ServerUris,
			Factory = context.EncodeableFactory
		});
		NamespaceTable namespaceTable = new NamespaceTable();
		if (NamespaceUris != null)
		{
			for (int i = 0; i < NamespaceUris.Length; i++)
			{
				namespaceTable.GetIndexOrAppend(NamespaceUris[i]);
			}
		}
		StringTable stringTable = new StringTable();
		if (ServerUris != null)
		{
			for (int j = 0; j < ServerUris.Length; j++)
			{
				stringTable.GetIndexOrAppend(ServerUris[j]);
			}
		}
		xmlEncoder.SetMappingTables(namespaceTable, stringTable);
		return xmlEncoder;
	}

	private XmlDecoder CreateDecoder(ISystemContext context, XmlElement source)
	{
		IServiceMessageContext context2 = new ServiceMessageContext
		{
			NamespaceUris = context.NamespaceUris,
			ServerUris = context.ServerUris,
			Factory = context.EncodeableFactory
		};
		XmlDecoder xmlDecoder = new XmlDecoder(source, context2);
		NamespaceTable namespaceTable = new NamespaceTable();
		if (NamespaceUris != null)
		{
			for (int i = 0; i < NamespaceUris.Length; i++)
			{
				namespaceTable.GetIndexOrAppend(NamespaceUris[i]);
			}
		}
		StringTable stringTable = new StringTable();
		if (ServerUris != null)
		{
			for (int j = 0; j < ServerUris.Length; j++)
			{
				stringTable.GetIndexOrAppend(ServerUris[j]);
			}
		}
		xmlDecoder.SetMappingTables(namespaceTable, stringTable);
		return xmlDecoder;
	}

	private NodeState Import(ISystemContext context, UANode node)
	{
		NodeState nodeState = null;
		NodeClass nodeClass = NodeClass.Unspecified;
		if (node is UAObject)
		{
			nodeClass = NodeClass.Object;
		}
		else if (node is UAVariable)
		{
			nodeClass = NodeClass.Variable;
		}
		else if (node is UAMethod)
		{
			nodeClass = NodeClass.Method;
		}
		else if (node is UAObjectType)
		{
			nodeClass = NodeClass.ObjectType;
		}
		else if (node is UAVariableType)
		{
			nodeClass = NodeClass.VariableType;
		}
		else if (node is UADataType)
		{
			nodeClass = NodeClass.DataType;
		}
		else if (node is UAReferenceType)
		{
			nodeClass = NodeClass.ReferenceType;
		}
		else if (node is UAView)
		{
			nodeClass = NodeClass.View;
		}
		switch (nodeClass)
		{
		case NodeClass.Object:
		{
			UAObject uAObject = (UAObject)node;
			nodeState = new BaseObjectState(null)
			{
				EventNotifier = uAObject.EventNotifier
			};
			break;
		}
		case NodeClass.Variable:
		{
			UAVariable uAVariable = (UAVariable)node;
			NodeId nodeId = null;
			if (node.References != null)
			{
				for (int i = 0; i < node.References.Length; i++)
				{
					NodeId nodeId2 = ImportNodeId(node.References[i].ReferenceType, context.NamespaceUris, lookupAlias: true);
					bool flag = !node.References[i].IsForward;
					ExpandedNodeId nodeId3 = ImportExpandedNodeId(node.References[i].Value, context.NamespaceUris, context.ServerUris);
					if (nodeId2 == ReferenceTypeIds.HasTypeDefinition && !flag)
					{
						nodeId = ExpandedNodeId.ToNodeId(nodeId3, context.NamespaceUris);
						break;
					}
				}
			}
			BaseVariableState baseVariableState = null;
			baseVariableState = ((!(nodeId == VariableTypeIds.PropertyType)) ? ((BaseVariableState)new BaseDataVariableState(null)) : ((BaseVariableState)new PropertyState(null)));
			baseVariableState.DataType = ImportNodeId(uAVariable.DataType, context.NamespaceUris, lookupAlias: true);
			baseVariableState.ValueRank = uAVariable.ValueRank;
			baseVariableState.ArrayDimensions = ImportArrayDimensions(uAVariable.ArrayDimensions);
			baseVariableState.AccessLevelEx = uAVariable.AccessLevel;
			baseVariableState.UserAccessLevel = (byte)(uAVariable.AccessLevel & 0xFF);
			baseVariableState.MinimumSamplingInterval = uAVariable.MinimumSamplingInterval;
			baseVariableState.Historizing = uAVariable.Historizing;
			if (uAVariable.Value != null)
			{
				XmlDecoder xmlDecoder2 = CreateDecoder(context, uAVariable.Value);
				TypeInfo typeInfo2 = null;
				baseVariableState.Value = xmlDecoder2.ReadVariantContents(out typeInfo2);
				xmlDecoder2.Close();
			}
			nodeState = baseVariableState;
			break;
		}
		case NodeClass.Method:
		{
			UAMethod uAMethod = (UAMethod)node;
			nodeState = new MethodState(null)
			{
				Executable = uAMethod.Executable,
				UserExecutable = uAMethod.Executable,
				MethodDeclarationId = ImportNodeId(uAMethod.MethodDeclarationId, context.NamespaceUris, lookupAlias: true)
			};
			break;
		}
		case NodeClass.View:
		{
			UAView uAView = (UAView)node;
			nodeState = new ViewState
			{
				ContainsNoLoops = uAView.ContainsNoLoops
			};
			break;
		}
		case NodeClass.ObjectType:
		{
			UAObjectType uAObjectType = (UAObjectType)node;
			nodeState = new BaseObjectTypeState
			{
				IsAbstract = uAObjectType.IsAbstract
			};
			break;
		}
		case NodeClass.VariableType:
		{
			UAVariableType uAVariableType = (UAVariableType)node;
			BaseVariableTypeState baseVariableTypeState = new BaseDataVariableTypeState();
			baseVariableTypeState.IsAbstract = uAVariableType.IsAbstract;
			baseVariableTypeState.DataType = ImportNodeId(uAVariableType.DataType, context.NamespaceUris, lookupAlias: true);
			baseVariableTypeState.ValueRank = uAVariableType.ValueRank;
			baseVariableTypeState.ArrayDimensions = ImportArrayDimensions(uAVariableType.ArrayDimensions);
			if (uAVariableType.Value != null)
			{
				XmlDecoder xmlDecoder = CreateDecoder(context, uAVariableType.Value);
				TypeInfo typeInfo = null;
				baseVariableTypeState.Value = xmlDecoder.ReadVariantContents(out typeInfo);
				xmlDecoder.Close();
			}
			nodeState = baseVariableTypeState;
			break;
		}
		case NodeClass.DataType:
		{
			UADataType uADataType = (UADataType)node;
			DataTypeState obj = new DataTypeState
			{
				IsAbstract = uADataType.IsAbstract
			};
			Opc.Ua.DataTypeDefinition body = Import(uADataType, uADataType.Definition, context.NamespaceUris);
			obj.DataTypeDefinition = new ExtensionObject(body);
			obj.Purpose = uADataType.Purpose;
			nodeState = obj;
			break;
		}
		case NodeClass.ReferenceType:
		{
			UAReferenceType uAReferenceType = (UAReferenceType)node;
			nodeState = new ReferenceTypeState
			{
				IsAbstract = uAReferenceType.IsAbstract,
				InverseName = Import(uAReferenceType.InverseName),
				Symmetric = uAReferenceType.Symmetric
			};
			break;
		}
		}
		nodeState.NodeId = ImportNodeId(node.NodeId, context.NamespaceUris, lookupAlias: false);
		nodeState.BrowseName = ImportQualifiedName(node.BrowseName, context.NamespaceUris);
		nodeState.DisplayName = Import(node.DisplayName);
		if (nodeState.DisplayName == null)
		{
			nodeState.DisplayName = new Opc.Ua.LocalizedText(nodeState.BrowseName.Name);
		}
		nodeState.Description = Import(node.Description);
		nodeState.NodeSetDocumentation = node.Documentation;
		nodeState.Categories = ((node.Category != null && node.Category.Length != 0) ? node.Category : null);
		nodeState.ReleaseStatus = node.ReleaseStatus;
		nodeState.WriteMask = (AttributeWriteMask)node.WriteMask;
		nodeState.UserWriteMask = (AttributeWriteMask)node.UserWriteMask;
		nodeState.Extensions = node.Extensions;
		if (!string.IsNullOrEmpty(node.SymbolicName))
		{
			nodeState.SymbolicName = node.SymbolicName;
		}
		if (node.References != null)
		{
			for (int j = 0; j < node.References.Length; j++)
			{
				NodeId nodeId4 = ImportNodeId(node.References[j].ReferenceType, context.NamespaceUris, lookupAlias: true);
				bool flag2 = !node.References[j].IsForward;
				ExpandedNodeId expandedNodeId = ImportExpandedNodeId(node.References[j].Value, context.NamespaceUris, context.ServerUris);
				if (nodeState is BaseInstanceState baseInstanceState)
				{
					if (nodeId4 == ReferenceTypeIds.HasModellingRule && !flag2)
					{
						baseInstanceState.ModellingRuleId = ExpandedNodeId.ToNodeId(expandedNodeId, context.NamespaceUris);
						continue;
					}
					if (nodeId4 == ReferenceTypeIds.HasTypeDefinition && !flag2)
					{
						baseInstanceState.TypeDefinitionId = ExpandedNodeId.ToNodeId(expandedNodeId, context.NamespaceUris);
						continue;
					}
				}
				if (nodeState is BaseTypeState baseTypeState && nodeId4 == ReferenceTypeIds.HasSubtype && flag2)
				{
					baseTypeState.SuperTypeId = ExpandedNodeId.ToNodeId(expandedNodeId, context.NamespaceUris);
				}
				else
				{
					nodeState.AddReference(nodeId4, flag2, expandedNodeId);
				}
			}
		}
		string text = (node as UAInstance)?.ParentNodeId;
		if (!string.IsNullOrEmpty(text))
		{
			nodeState.Handle = ImportNodeId(text, context.NamespaceUris, lookupAlias: true);
		}
		return nodeState;
	}

	private string ExportAlias(NodeId source, NamespaceTable namespaceUris)
	{
		string text = Export(source, namespaceUris);
		if (!string.IsNullOrEmpty(text) && Aliases != null)
		{
			for (int i = 0; i < Aliases.Length; i++)
			{
				if (Aliases[i].Value == text)
				{
					return Aliases[i].Alias;
				}
			}
		}
		return text;
	}

	private string Export(NodeId source, NamespaceTable namespaceUris)
	{
		if (NodeId.IsNull(source))
		{
			return string.Empty;
		}
		if (source.NamespaceIndex > 0)
		{
			ushort namespaceIndex = ExportNamespaceIndex(source.NamespaceIndex, namespaceUris);
			source = new NodeId(source.Identifier, namespaceIndex);
		}
		return source.ToString();
	}

	private NodeId ImportNodeId(string source, NamespaceTable namespaceUris, bool lookupAlias)
	{
		if (string.IsNullOrEmpty(source))
		{
			return NodeId.Null;
		}
		if (lookupAlias && Aliases != null)
		{
			for (int i = 0; i < Aliases.Length; i++)
			{
				if (Aliases[i].Alias == source)
				{
					source = Aliases[i].Value;
					break;
				}
			}
		}
		NodeId nodeId = NodeId.Parse(source);
		if (nodeId.NamespaceIndex > 0)
		{
			ushort namespaceIndex = ImportNamespaceIndex(nodeId.NamespaceIndex, namespaceUris);
			nodeId = new NodeId(nodeId.Identifier, namespaceIndex);
		}
		return nodeId;
	}

	private string Export(ExpandedNodeId source, NamespaceTable namespaceUris, StringTable serverUris)
	{
		if (NodeId.IsNull(source))
		{
			return string.Empty;
		}
		if (source.ServerIndex == 0 && source.NamespaceIndex <= 0 && string.IsNullOrEmpty(source.NamespaceUri))
		{
			return source.ToString();
		}
		ushort num = 0;
		num = ((!string.IsNullOrEmpty(source.NamespaceUri)) ? ExportNamespaceUri(source.NamespaceUri, namespaceUris) : ExportNamespaceIndex(source.NamespaceIndex, namespaceUris));
		uint serverIndex = ExportServerIndex(source.ServerIndex, serverUris);
		source = new ExpandedNodeId(source.Identifier, num, null, serverIndex);
		return source.ToString();
	}

	private ExpandedNodeId ImportExpandedNodeId(string source, NamespaceTable namespaceUris, StringTable serverUris)
	{
		if (string.IsNullOrEmpty(source))
		{
			return ExpandedNodeId.Null;
		}
		if (Aliases != null)
		{
			for (int i = 0; i < Aliases.Length; i++)
			{
				if (Aliases[i].Alias == source)
				{
					source = Aliases[i].Value;
					break;
				}
			}
		}
		ExpandedNodeId expandedNodeId = ExpandedNodeId.Parse(source);
		if (expandedNodeId.ServerIndex == 0 && expandedNodeId.NamespaceIndex <= 0 && string.IsNullOrEmpty(expandedNodeId.NamespaceUri))
		{
			return expandedNodeId;
		}
		uint num = ImportServerIndex(expandedNodeId.ServerIndex, serverUris);
		ushort num2 = ImportNamespaceIndex(expandedNodeId.NamespaceIndex, namespaceUris);
		if (num != 0)
		{
			string namespaceUri = expandedNodeId.NamespaceUri;
			if (string.IsNullOrEmpty(expandedNodeId.NamespaceUri))
			{
				namespaceUri = namespaceUris.GetString(num2);
			}
			return new ExpandedNodeId(expandedNodeId.Identifier, 0, namespaceUri, num);
		}
		return new ExpandedNodeId(expandedNodeId.Identifier, num2, null, 0u);
	}

	private string Export(QualifiedName source, NamespaceTable namespaceUris)
	{
		if (QualifiedName.IsNull(source))
		{
			return string.Empty;
		}
		if (source.NamespaceIndex > 0)
		{
			ushort namespaceIndex = ExportNamespaceIndex(source.NamespaceIndex, namespaceUris);
			source = new QualifiedName(source.Name, namespaceIndex);
		}
		return source.ToString();
	}

	private DataTypeDefinition Export(DataTypeState dataType, ExtensionObject source, NamespaceTable namespaceUris, bool outputRedundantNames)
	{
		if (source == null || source.Body == null)
		{
			return null;
		}
		DataTypeDefinition dataTypeDefinition = new DataTypeDefinition();
		if (outputRedundantNames || dataType.BrowseName != null)
		{
			dataTypeDefinition.Name = Export(dataType.BrowseName, namespaceUris);
		}
		if (dataType.BrowseName.Name != dataType.SymbolicName)
		{
			dataTypeDefinition.SymbolicName = dataType.SymbolicName;
		}
		if (source.Body is StructureDefinition structureDefinition)
		{
			if (structureDefinition.StructureType == StructureType.Union || structureDefinition.StructureType == StructureType.UnionWithSubtypedValues)
			{
				dataTypeDefinition.IsUnion = true;
			}
			if (structureDefinition.Fields != null)
			{
				List<DataTypeField> list = new List<DataTypeField>();
				for (int i = structureDefinition.FirstExplicitFieldIndex; i < structureDefinition.Fields.Count; i++)
				{
					StructureField structureField = structureDefinition.Fields[i];
					DataTypeField dataTypeField = new DataTypeField();
					dataTypeField.Name = structureField.Name;
					dataTypeField.Description = Export(new Opc.Ua.LocalizedText[1] { structureField.Description });
					if (structureDefinition.StructureType == StructureType.StructureWithOptionalFields)
					{
						dataTypeField.IsOptional = structureField.IsOptional;
						dataTypeField.AllowSubTypes = false;
					}
					else if (structureDefinition.StructureType == StructureType.StructureWithSubtypedValues || structureDefinition.StructureType == StructureType.UnionWithSubtypedValues)
					{
						dataTypeField.IsOptional = false;
						dataTypeField.AllowSubTypes = structureField.IsOptional;
					}
					else
					{
						dataTypeField.IsOptional = false;
						dataTypeField.AllowSubTypes = false;
					}
					if (NodeId.IsNull(structureField.DataType))
					{
						dataTypeField.DataType = Export(DataTypeIds.BaseDataType, namespaceUris);
					}
					else
					{
						dataTypeField.DataType = Export(structureField.DataType, namespaceUris);
					}
					dataTypeField.ValueRank = structureField.ValueRank;
					if (structureField.ArrayDimensions != null && structureField.ArrayDimensions.Count != 0 && (dataTypeField.ValueRank > 1 || structureField.ArrayDimensions[0] != 0))
					{
						dataTypeField.ArrayDimensions = BaseVariableState.ArrayDimensionsToXml(structureField.ArrayDimensions);
					}
					dataTypeField.MaxStringLength = structureField.MaxStringLength;
					list.Add(dataTypeField);
				}
				dataTypeDefinition.Field = list.ToArray();
			}
		}
		if (source.Body is EnumDefinition enumDefinition)
		{
			dataTypeDefinition.IsOptionSet = enumDefinition.IsOptionSet;
			if (enumDefinition.Fields != null)
			{
				List<DataTypeField> list2 = new List<DataTypeField>();
				foreach (EnumField field in enumDefinition.Fields)
				{
					DataTypeField dataTypeField2 = new DataTypeField();
					dataTypeField2.Name = field.Name;
					if (field.DisplayName != null && dataTypeField2.Name != field.DisplayName.Text)
					{
						dataTypeField2.DisplayName = Export(new Opc.Ua.LocalizedText[1] { field.DisplayName });
					}
					else
					{
						dataTypeField2.DisplayName = Array.Empty<LocalizedText>();
					}
					dataTypeField2.Description = Export(new Opc.Ua.LocalizedText[1] { field.Description });
					dataTypeField2.ValueRank = -1;
					dataTypeField2.Value = (int)field.Value;
					list2.Add(dataTypeField2);
				}
				dataTypeDefinition.Field = list2.ToArray();
			}
		}
		return dataTypeDefinition;
	}

	private Opc.Ua.DataTypeDefinition Import(UADataType dataType, DataTypeDefinition source, NamespaceTable namespaceUris)
	{
		if (source == null)
		{
			return null;
		}
		Opc.Ua.DataTypeDefinition result = null;
		if (source.Field != null)
		{
			if (!Array.Exists(source.Field, (DataTypeField fieldLookup) => fieldLookup.Value != -1))
			{
				StructureDefinition structureDefinition = new StructureDefinition();
				structureDefinition.BaseDataType = ImportNodeId(source.BaseType, namespaceUris, lookupAlias: true);
				if (source.IsUnion)
				{
					structureDefinition.StructureType = StructureType.Union;
				}
				if (source.Field != null)
				{
					List<StructureField> list = new List<StructureField>();
					DataTypeField[] field = source.Field;
					foreach (DataTypeField dataTypeField in field)
					{
						if (structureDefinition.StructureType == StructureType.Structure || structureDefinition.StructureType == StructureType.Union)
						{
							if (dataTypeField.IsOptional)
							{
								structureDefinition.StructureType = StructureType.StructureWithOptionalFields;
							}
							else if (dataTypeField.AllowSubTypes)
							{
								if (source.IsUnion)
								{
									structureDefinition.StructureType = StructureType.UnionWithSubtypedValues;
								}
								else
								{
									structureDefinition.StructureType = StructureType.StructureWithSubtypedValues;
								}
							}
						}
						StructureField structureField = new StructureField();
						structureField.Name = dataTypeField.Name;
						structureField.Description = Import(dataTypeField.Description);
						structureField.DataType = ImportNodeId(dataTypeField.DataType, namespaceUris, lookupAlias: true);
						structureField.ValueRank = dataTypeField.ValueRank;
						if (!string.IsNullOrWhiteSpace(dataTypeField.ArrayDimensions) && (structureField.ValueRank > 1 || dataTypeField.ArrayDimensions[0] > '\0'))
						{
							structureField.ArrayDimensions = new UInt32Collection(BaseVariableState.ArrayDimensionsFromXml(dataTypeField.ArrayDimensions));
						}
						structureField.MaxStringLength = dataTypeField.MaxStringLength;
						if (structureDefinition.StructureType == StructureType.Structure || structureDefinition.StructureType == StructureType.Union)
						{
							structureField.IsOptional = false;
						}
						else if (structureDefinition.StructureType == StructureType.StructureWithSubtypedValues || structureDefinition.StructureType == StructureType.UnionWithSubtypedValues)
						{
							structureField.IsOptional = dataTypeField.AllowSubTypes;
						}
						else
						{
							structureField.IsOptional = dataTypeField.IsOptional;
						}
						list.Add(structureField);
					}
					structureDefinition.Fields = list.ToArray();
				}
				result = structureDefinition;
			}
			else
			{
				EnumDefinition enumDefinition = new EnumDefinition();
				enumDefinition.IsOptionSet = source.IsOptionSet;
				if (source.Field != null)
				{
					List<EnumField> list2 = new List<EnumField>();
					DataTypeField[] field = source.Field;
					foreach (DataTypeField dataTypeField2 in field)
					{
						EnumField enumField = new EnumField();
						enumField.Name = dataTypeField2.Name;
						enumField.DisplayName = Import(dataTypeField2.DisplayName);
						enumField.Description = Import(dataTypeField2.Description);
						enumField.Value = dataTypeField2.Value;
						list2.Add(enumField);
					}
					enumDefinition.Fields = list2.ToArray();
				}
				result = enumDefinition;
			}
		}
		return result;
	}

	private QualifiedName ImportQualifiedName(string source, NamespaceTable namespaceUris)
	{
		if (string.IsNullOrEmpty(source))
		{
			return QualifiedName.Null;
		}
		QualifiedName qualifiedName = QualifiedName.Parse(source);
		if (qualifiedName.NamespaceIndex > 0)
		{
			ushort namespaceIndex = ImportNamespaceIndex(qualifiedName.NamespaceIndex, namespaceUris);
			qualifiedName = new QualifiedName(qualifiedName.Name, namespaceIndex);
		}
		return qualifiedName;
	}

	private string Export(IList<uint> arrayDimensions)
	{
		if (arrayDimensions == null)
		{
			return string.Empty;
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int i = 0; i < arrayDimensions.Count; i++)
		{
			if (stringBuilder.Length > 0)
			{
				stringBuilder.Append(',');
			}
			stringBuilder.Append(arrayDimensions[i]);
		}
		return stringBuilder.ToString();
	}

	private uint[] ImportArrayDimensions(string arrayDimensions)
	{
		if (string.IsNullOrEmpty(arrayDimensions))
		{
			return null;
		}
		string[] array = arrayDimensions.Split(',');
		uint[] array2 = new uint[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			try
			{
				array2[i] = Convert.ToUInt32(array[i]);
			}
			catch
			{
				array2[i] = 0u;
			}
		}
		return array2;
	}

	private LocalizedText[] Export(Opc.Ua.LocalizedText[] input)
	{
		if (input == null)
		{
			return null;
		}
		List<LocalizedText> list = new List<LocalizedText>();
		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] != null)
			{
				LocalizedText localizedText = new LocalizedText();
				localizedText.Locale = input[i].Locale;
				localizedText.Value = input[i].Text;
				list.Add(localizedText);
			}
		}
		return list.ToArray();
	}

	private LocalizedText Export(Opc.Ua.LocalizedText input)
	{
		if (input == null)
		{
			return null;
		}
		return new LocalizedText
		{
			Locale = input.Locale,
			Value = input.Text
		};
	}

	private Opc.Ua.LocalizedText Import(params LocalizedText[] input)
	{
		if (input == null)
		{
			return null;
		}
		for (int i = 0; i < input.Length; i++)
		{
			if (input[i] != null)
			{
				return new Opc.Ua.LocalizedText(input[i].Locale, input[i].Value);
			}
		}
		return null;
	}

	private ushort ExportNamespaceIndex(ushort namespaceIndex, NamespaceTable namespaceUris)
	{
		if (namespaceIndex < 1)
		{
			return namespaceIndex;
		}
		if (namespaceUris == null || namespaceUris.Count <= namespaceIndex)
		{
			return ushort.MaxValue;
		}
		int num = 1;
		string text = namespaceUris.GetString(namespaceIndex);
		if (NamespaceUris != null)
		{
			for (int i = 0; i < NamespaceUris.Length; i++)
			{
				if (NamespaceUris[i] == text)
				{
					return (ushort)(i + 1);
				}
			}
			num += NamespaceUris.Length;
		}
		string[] array = new string[num];
		if (NamespaceUris != null)
		{
			Array.Copy(NamespaceUris, array, num - 1);
		}
		array[num - 1] = text;
		NamespaceUris = array;
		return (ushort)num;
	}

	private ushort ImportNamespaceIndex(ushort namespaceIndex, NamespaceTable namespaceUris)
	{
		if (namespaceIndex < 1)
		{
			return namespaceIndex;
		}
		if (namespaceUris == null || NamespaceUris == null || NamespaceUris.Length <= namespaceIndex - 1)
		{
			return ushort.MaxValue;
		}
		return namespaceUris.GetIndexOrAppend(NamespaceUris[namespaceIndex - 1]);
	}

	private ushort ExportNamespaceUri(string namespaceUri, NamespaceTable namespaceUris)
	{
		if (namespaceUris == null)
		{
			return ushort.MaxValue;
		}
		int index = namespaceUris.GetIndex(namespaceUri);
		if (index == 0)
		{
			return (ushort)index;
		}
		int num = 1;
		if (NamespaceUris != null)
		{
			for (int i = 0; i < NamespaceUris.Length; i++)
			{
				if (NamespaceUris[i] == namespaceUri)
				{
					return (ushort)(i + 1);
				}
			}
			num += NamespaceUris.Length;
		}
		string[] array = new string[num];
		if (NamespaceUris != null)
		{
			Array.Copy(NamespaceUris, array, num - 1);
		}
		array[num - 1] = namespaceUri;
		NamespaceUris = array;
		return (ushort)num;
	}

	private uint ExportServerIndex(uint serverIndex, StringTable serverUris)
	{
		if (serverIndex == 0)
		{
			return serverIndex;
		}
		if (serverUris == null || serverUris.Count < serverIndex)
		{
			return 65535u;
		}
		int num = 1;
		string text = serverUris.GetString(serverIndex);
		if (ServerUris != null)
		{
			for (int i = 0; i < ServerUris.Length; i++)
			{
				if (ServerUris[i] == text)
				{
					return (ushort)(i + 1);
				}
			}
			num += ServerUris.Length;
		}
		string[] array = new string[num];
		if (ServerUris != null)
		{
			Array.Copy(ServerUris, array, num - 1);
		}
		array[num - 1] = text;
		ServerUris = array;
		return (ushort)num;
	}

	private uint ImportServerIndex(uint serverIndex, StringTable serverUris)
	{
		if (serverIndex == 0)
		{
			return serverIndex;
		}
		if (serverUris == null || ServerUris == null || ServerUris.Length <= serverIndex - 1)
		{
			return 65535u;
		}
		return serverUris.GetIndexOrAppend(ServerUris[serverIndex - 1]);
	}
}
