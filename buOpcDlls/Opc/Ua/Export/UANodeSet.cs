// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Export.UANodeSet
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

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

#nullable disable
namespace Opc.Ua.Export;

[GeneratedCode("xsd", "4.8.3928.0")]
[DebuggerStepThrough]
[DesignerCategory("code")]
[XmlType(AnonymousType = true, Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd")]
[XmlRoot(Namespace = "http://opcfoundation.org/UA/2011/03/UANodeSet.xsd", IsNullable = false)]
[ComVisible(true)]
[Serializable]
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
    get => this.namespaceUrisField;
    set => this.namespaceUrisField = value;
  }

  [XmlArrayItem("Uri", IsNullable = false)]
  public string[] ServerUris
  {
    get => this.serverUrisField;
    set => this.serverUrisField = value;
  }

  [XmlArrayItem("Model", IsNullable = false)]
  public ModelTableEntry[] Models
  {
    get => this.modelsField;
    set => this.modelsField = value;
  }

  [XmlArrayItem("Alias", IsNullable = false)]
  public NodeIdAlias[] Aliases
  {
    get => this.aliasesField;
    set => this.aliasesField = value;
  }

  [XmlArrayItem("Extension", IsNullable = false)]
  public XmlElement[] Extensions
  {
    get => this.extensionsField;
    set => this.extensionsField = value;
  }

  [XmlElement("UADataType", typeof (UADataType))]
  [XmlElement("UAMethod", typeof (UAMethod))]
  [XmlElement("UAObject", typeof (UAObject))]
  [XmlElement("UAObjectType", typeof (UAObjectType))]
  [XmlElement("UAReferenceType", typeof (UAReferenceType))]
  [XmlElement("UAVariable", typeof (UAVariable))]
  [XmlElement("UAVariableType", typeof (UAVariableType))]
  [XmlElement("UAView", typeof (UAView))]
  public UANode[] Items
  {
    get => this.itemsField;
    set => this.itemsField = value;
  }

  [XmlAttribute]
  public DateTime LastModified
  {
    get => this.lastModifiedField;
    set => this.lastModifiedField = value;
  }

  [XmlIgnore]
  public bool LastModifiedSpecified
  {
    get => this.lastModifiedFieldSpecified;
    set => this.lastModifiedFieldSpecified = value;
  }

  public static UANodeSet Read(Stream istrm)
  {
    using (StreamReader input = new StreamReader(istrm))
    {
      using (XmlReader xmlReader = XmlReader.Create((TextReader) input, Utils.DefaultXmlReaderSettings()))
        return new XmlSerializer(typeof (UANodeSet)).Deserialize(xmlReader) as UANodeSet;
    }
  }

  public void Write(Stream istrm)
  {
    XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
    XmlWriter xmlWriter = XmlWriter.Create(istrm, settings);
    try
    {
      new XmlSerializer(typeof (UANodeSet)).Serialize(xmlWriter, (object) this, (XmlSerializerNamespaces) null);
    }
    finally
    {
      xmlWriter.Flush();
      xmlWriter.Dispose();
    }
  }

  public void AddAlias(ISystemContext context, string alias, NodeId nodeId)
  {
    int length = 1;
    if (this.Aliases != null)
    {
      for (int index = 0; index < this.Aliases.Length; ++index)
      {
        if (this.Aliases[index].Alias == alias)
        {
          this.Aliases[index].Value = this.Export(nodeId, context.NamespaceUris);
          return;
        }
      }
      length += this.Aliases.Length;
    }
    NodeIdAlias[] destinationArray = new NodeIdAlias[length];
    if (this.Aliases != null)
      Array.Copy((Array) this.Aliases, (Array) destinationArray, this.Aliases.Length);
    destinationArray[length - 1] = new NodeIdAlias()
    {
      Alias = alias,
      Value = this.Export(nodeId, context.NamespaceUris)
    };
    this.Aliases = destinationArray;
  }

  public void Import(ISystemContext context, NodeStateCollection nodes)
  {
    for (int index = 0; index < this.Items.Length; ++index)
    {
      UANode node = this.Items[index];
      NodeState nodeState = this.Import(context, node);
      nodes.Add(nodeState);
    }
  }

  public void Export(ISystemContext context, NodeState node, bool outputRedundantNames = true)
  {
    if (node == null)
      throw new ArgumentNullException(nameof (node));
    if (NodeId.IsNull(node.NodeId))
      throw new ArgumentException("A non-null NodeId must be specified.");
    UANode uaNode = (UANode) null;
    switch (node.NodeClass)
    {
      case NodeClass.Object:
        BaseObjectState baseObjectState = (BaseObjectState) node;
        UAObject uaObject = new UAObject();
        uaObject.EventNotifier = baseObjectState.EventNotifier;
        if (baseObjectState.Parent != null)
          uaObject.ParentNodeId = this.ExportAlias(baseObjectState.Parent.NodeId, context.NamespaceUris);
        uaNode = (UANode) uaObject;
        break;
      case NodeClass.Variable:
        BaseVariableState baseVariableState = (BaseVariableState) node;
        UAVariable uaVariable = new UAVariable();
        uaVariable.DataType = this.ExportAlias(baseVariableState.DataType, context.NamespaceUris);
        uaVariable.ValueRank = baseVariableState.ValueRank;
        uaVariable.ArrayDimensions = this.Export((IList<uint>) baseVariableState.ArrayDimensions);
        uaVariable.AccessLevel = baseVariableState.AccessLevelEx;
        uaVariable.MinimumSamplingInterval = baseVariableState.MinimumSamplingInterval;
        uaVariable.Historizing = baseVariableState.Historizing;
        if (baseVariableState.Parent != null)
          uaVariable.ParentNodeId = this.ExportAlias(baseVariableState.Parent.NodeId, context.NamespaceUris);
        if (baseVariableState.Value != null)
        {
          using (XmlEncoder encoder = this.CreateEncoder(context))
          {
            Opc.Ua.Variant variant = new Opc.Ua.Variant(baseVariableState.Value);
            encoder.WriteVariantContents(variant.Value, variant.TypeInfo);
            XmlDocument doc = new XmlDocument();
            doc.LoadInnerXml(encoder.CloseAndReturnText());
            uaVariable.Value = doc.DocumentElement;
          }
        }
        uaNode = (UANode) uaVariable;
        break;
      case NodeClass.Method:
        MethodState methodState = (MethodState) node;
        UAMethod uaMethod = new UAMethod();
        uaMethod.Executable = methodState.Executable;
        if (methodState.MethodDeclarationId != (object) null && !methodState.MethodDeclarationId.IsNullNodeId && methodState.MethodDeclarationId != (object) methodState.NodeId)
          uaMethod.MethodDeclarationId = this.Export(methodState.MethodDeclarationId, context.NamespaceUris);
        if (methodState.Parent != null)
          uaMethod.ParentNodeId = this.ExportAlias(methodState.Parent.NodeId, context.NamespaceUris);
        uaNode = (UANode) uaMethod;
        break;
      case NodeClass.ObjectType:
        BaseObjectTypeState baseObjectTypeState = (BaseObjectTypeState) node;
        UAObjectType uaObjectType = new UAObjectType();
        uaObjectType.IsAbstract = baseObjectTypeState.IsAbstract;
        uaNode = (UANode) uaObjectType;
        break;
      case NodeClass.VariableType:
        BaseVariableTypeState variableTypeState = (BaseVariableTypeState) node;
        UAVariableType uaVariableType = new UAVariableType();
        uaVariableType.IsAbstract = variableTypeState.IsAbstract;
        uaVariableType.DataType = this.ExportAlias(variableTypeState.DataType, context.NamespaceUris);
        uaVariableType.ValueRank = variableTypeState.ValueRank;
        uaVariableType.ArrayDimensions = this.Export((IList<uint>) variableTypeState.ArrayDimensions);
        if (variableTypeState.Value != null)
        {
          using (XmlEncoder encoder = this.CreateEncoder(context))
          {
            Opc.Ua.Variant variant = new Opc.Ua.Variant(variableTypeState.Value);
            encoder.WriteVariantContents(variant.Value, variant.TypeInfo);
            XmlDocument doc = new XmlDocument();
            doc.LoadInnerXml(encoder.CloseAndReturnText());
            uaVariableType.Value = doc.DocumentElement;
          }
        }
        uaNode = (UANode) uaVariableType;
        break;
      case NodeClass.ReferenceType:
        ReferenceTypeState referenceTypeState = (ReferenceTypeState) node;
        UAReferenceType uaReferenceType = new UAReferenceType();
        uaReferenceType.IsAbstract = referenceTypeState.IsAbstract;
        if (!Opc.Ua.LocalizedText.IsNullOrEmpty(referenceTypeState.InverseName))
          uaReferenceType.InverseName = this.Export(new Opc.Ua.LocalizedText[1]
          {
            referenceTypeState.InverseName
          });
        uaReferenceType.Symmetric = referenceTypeState.Symmetric;
        uaNode = (UANode) uaReferenceType;
        break;
      case NodeClass.DataType:
        DataTypeState dataType = (DataTypeState) node;
        UADataType uaDataType = new UADataType();
        uaDataType.IsAbstract = dataType.IsAbstract;
        uaDataType.Definition = this.Export(dataType, dataType.DataTypeDefinition, context.NamespaceUris, outputRedundantNames);
        uaDataType.Purpose = dataType.Purpose;
        uaNode = (UANode) uaDataType;
        break;
      case NodeClass.View:
        ViewState viewState = (ViewState) node;
        uaNode = (UANode) new UAView()
        {
          ContainsNoLoops = viewState.ContainsNoLoops
        };
        break;
    }
    uaNode.NodeId = this.Export(node.NodeId, context.NamespaceUris);
    uaNode.BrowseName = this.Export(node.BrowseName, context.NamespaceUris);
    if (!outputRedundantNames && !(node.DisplayName.Text != node.BrowseName.Name))
      uaNode.DisplayName = (LocalizedText[]) null;
    else
      uaNode.DisplayName = this.Export(new Opc.Ua.LocalizedText[1]
      {
        node.DisplayName
      });
    if (node.Description != (Opc.Ua.LocalizedText) null && !string.IsNullOrEmpty(node.Description.Text))
      uaNode.Description = this.Export(new Opc.Ua.LocalizedText[1]
      {
        node.Description
      });
    else
      uaNode.Description = Array.Empty<LocalizedText>();
    uaNode.Documentation = node.NodeSetDocumentation;
    uaNode.Category = node.Categories == null || node.Categories.Count <= 0 ? (string[]) null : new List<string>((IEnumerable<string>) node.Categories).ToArray();
    uaNode.ReleaseStatus = node.ReleaseStatus;
    uaNode.WriteMask = (uint) node.WriteMask;
    uaNode.UserWriteMask = (uint) node.UserWriteMask;
    uaNode.Extensions = node.Extensions;
    if (!string.IsNullOrEmpty(node.SymbolicName) && node.SymbolicName != node.BrowseName.Name)
      uaNode.SymbolicName = node.SymbolicName;
    INodeBrowser browser = node.CreateBrowser(context, (ViewDescription) null, (NodeId) null, true, BrowseDirection.Both, (QualifiedName) null, (IEnumerable<IReference>) null, true);
    List<Reference> referenceList = new List<Reference>();
    IReference reference = browser.Next();
    while (reference != null)
    {
      if (node.NodeClass == NodeClass.Method && !reference.IsInverse && reference.ReferenceTypeId == (object) ReferenceTypeIds.HasTypeDefinition)
      {
        reference = browser.Next();
      }
      else
      {
        referenceList.Add(new Reference()
        {
          ReferenceType = this.ExportAlias(reference.ReferenceTypeId, context.NamespaceUris),
          IsForward = !reference.IsInverse,
          Value = this.Export(reference.TargetId, context.NamespaceUris, context.ServerUris)
        });
        reference = browser.Next();
      }
    }
    uaNode.References = referenceList.ToArray();
    int length = 1;
    UANode[] destinationArray;
    if (this.Items == null)
    {
      destinationArray = new UANode[length];
    }
    else
    {
      length += this.Items.Length;
      destinationArray = new UANode[length];
      Array.Copy((Array) this.Items, (Array) destinationArray, this.Items.Length);
    }
    destinationArray[length - 1] = uaNode;
    this.Items = destinationArray;
    List<BaseInstanceState> children = new List<BaseInstanceState>();
    node.GetChildren(context, (IList<BaseInstanceState>) children);
    for (int index = 0; index < children.Count; ++index)
      this.Export(context, (NodeState) children[index], outputRedundantNames);
  }

  private XmlEncoder CreateEncoder(ISystemContext context)
  {
    XmlEncoder encoder = new XmlEncoder((IServiceMessageContext) new ServiceMessageContext()
    {
      NamespaceUris = context.NamespaceUris,
      ServerUris = context.ServerUris,
      Factory = context.EncodeableFactory
    });
    NamespaceTable namespaceUris = new NamespaceTable();
    if (this.NamespaceUris != null)
    {
      for (int index = 0; index < this.NamespaceUris.Length; ++index)
      {
        int indexOrAppend = (int) namespaceUris.GetIndexOrAppend(this.NamespaceUris[index]);
      }
    }
    StringTable serverUris = new StringTable();
    if (this.ServerUris != null)
    {
      for (int index = 0; index < this.ServerUris.Length; ++index)
      {
        int indexOrAppend = (int) serverUris.GetIndexOrAppend(this.ServerUris[index]);
      }
    }
    encoder.SetMappingTables(namespaceUris, serverUris);
    return encoder;
  }

  private XmlDecoder CreateDecoder(ISystemContext context, XmlElement source)
  {
    IServiceMessageContext context1 = (IServiceMessageContext) new ServiceMessageContext()
    {
      NamespaceUris = context.NamespaceUris,
      ServerUris = context.ServerUris,
      Factory = context.EncodeableFactory
    };
    XmlDecoder decoder = new XmlDecoder(source, context1);
    NamespaceTable namespaceUris = new NamespaceTable();
    if (this.NamespaceUris != null)
    {
      for (int index = 0; index < this.NamespaceUris.Length; ++index)
      {
        int indexOrAppend = (int) namespaceUris.GetIndexOrAppend(this.NamespaceUris[index]);
      }
    }
    StringTable serverUris = new StringTable();
    if (this.ServerUris != null)
    {
      for (int index = 0; index < this.ServerUris.Length; ++index)
      {
        int indexOrAppend = (int) serverUris.GetIndexOrAppend(this.ServerUris[index]);
      }
    }
    decoder.SetMappingTables(namespaceUris, serverUris);
    return decoder;
  }

  private NodeState Import(ISystemContext context, UANode node)
  {
    NodeState nodeState = (NodeState) null;
    NodeClass nodeClass = NodeClass.Unspecified;
    switch (node)
    {
      case UAObject _:
        nodeClass = NodeClass.Object;
        break;
      case UAVariable _:
        nodeClass = NodeClass.Variable;
        break;
      case UAMethod _:
        nodeClass = NodeClass.Method;
        break;
      case UAObjectType _:
        nodeClass = NodeClass.ObjectType;
        break;
      case UAVariableType _:
        nodeClass = NodeClass.VariableType;
        break;
      case UADataType _:
        nodeClass = NodeClass.DataType;
        break;
      case UAReferenceType _:
        nodeClass = NodeClass.ReferenceType;
        break;
      case UAView _:
        nodeClass = NodeClass.View;
        break;
    }
    switch (nodeClass)
    {
      case NodeClass.Object:
        UAObject uaObject = (UAObject) node;
        nodeState = (NodeState) new BaseObjectState((NodeState) null)
        {
          EventNotifier = uaObject.EventNotifier
        };
        break;
      case NodeClass.Variable:
        UAVariable uaVariable = (UAVariable) node;
        NodeId nodeId1 = (NodeId) null;
        if (node.References != null)
        {
          for (int index = 0; index < node.References.Length; ++index)
          {
            NodeId nodeId2 = this.ImportNodeId(node.References[index].ReferenceType, context.NamespaceUris, true);
            bool flag = !node.References[index].IsForward;
            ExpandedNodeId nodeId3 = this.ImportExpandedNodeId(node.References[index].Value, context.NamespaceUris, context.ServerUris);
            NodeId hasTypeDefinition = ReferenceTypeIds.HasTypeDefinition;
            if (nodeId2 == (object) hasTypeDefinition && !flag)
            {
              nodeId1 = ExpandedNodeId.ToNodeId(nodeId3, context.NamespaceUris);
              break;
            }
          }
        }
        BaseVariableState baseVariableState = !(nodeId1 == (object) VariableTypeIds.PropertyType) ? (BaseVariableState) new BaseDataVariableState((NodeState) null) : (BaseVariableState) new PropertyState((NodeState) null);
        baseVariableState.DataType = this.ImportNodeId(uaVariable.DataType, context.NamespaceUris, true);
        baseVariableState.ValueRank = uaVariable.ValueRank;
        baseVariableState.ArrayDimensions = (ReadOnlyList<uint>) this.ImportArrayDimensions(uaVariable.ArrayDimensions);
        baseVariableState.AccessLevelEx = uaVariable.AccessLevel;
        baseVariableState.UserAccessLevel = (byte) (uaVariable.AccessLevel & (uint) byte.MaxValue);
        baseVariableState.MinimumSamplingInterval = uaVariable.MinimumSamplingInterval;
        baseVariableState.Historizing = uaVariable.Historizing;
        if (uaVariable.Value != null)
        {
          XmlDecoder decoder = this.CreateDecoder(context, uaVariable.Value);
          TypeInfo typeInfo = (TypeInfo) null;
          baseVariableState.Value = decoder.ReadVariantContents(out typeInfo);
          decoder.Close();
        }
        nodeState = (NodeState) baseVariableState;
        break;
      case NodeClass.Method:
        UAMethod uaMethod = (UAMethod) node;
        nodeState = (NodeState) new MethodState((NodeState) null)
        {
          Executable = uaMethod.Executable,
          UserExecutable = uaMethod.Executable,
          MethodDeclarationId = this.ImportNodeId(uaMethod.MethodDeclarationId, context.NamespaceUris, true)
        };
        break;
      case NodeClass.ObjectType:
        UAObjectType uaObjectType = (UAObjectType) node;
        BaseObjectTypeState baseObjectTypeState = new BaseObjectTypeState();
        baseObjectTypeState.IsAbstract = uaObjectType.IsAbstract;
        nodeState = (NodeState) baseObjectTypeState;
        break;
      case NodeClass.VariableType:
        UAVariableType uaVariableType = (UAVariableType) node;
        BaseVariableTypeState variableTypeState = (BaseVariableTypeState) new BaseDataVariableTypeState();
        variableTypeState.IsAbstract = uaVariableType.IsAbstract;
        variableTypeState.DataType = this.ImportNodeId(uaVariableType.DataType, context.NamespaceUris, true);
        variableTypeState.ValueRank = uaVariableType.ValueRank;
        variableTypeState.ArrayDimensions = (ReadOnlyList<uint>) this.ImportArrayDimensions(uaVariableType.ArrayDimensions);
        if (uaVariableType.Value != null)
        {
          XmlDecoder decoder = this.CreateDecoder(context, uaVariableType.Value);
          TypeInfo typeInfo = (TypeInfo) null;
          variableTypeState.Value = decoder.ReadVariantContents(out typeInfo);
          decoder.Close();
        }
        nodeState = (NodeState) variableTypeState;
        break;
      case NodeClass.ReferenceType:
        UAReferenceType uaReferenceType = (UAReferenceType) node;
        ReferenceTypeState referenceTypeState = new ReferenceTypeState();
        referenceTypeState.IsAbstract = uaReferenceType.IsAbstract;
        referenceTypeState.InverseName = this.Import(uaReferenceType.InverseName);
        referenceTypeState.Symmetric = uaReferenceType.Symmetric;
        nodeState = (NodeState) referenceTypeState;
        break;
      case NodeClass.DataType:
        UADataType dataType = (UADataType) node;
        DataTypeState dataTypeState = new DataTypeState();
        dataTypeState.IsAbstract = dataType.IsAbstract;
        dataTypeState.DataTypeDefinition = new ExtensionObject((object) this.Import(dataType, dataType.Definition, context.NamespaceUris));
        dataTypeState.Purpose = dataType.Purpose;
        nodeState = (NodeState) dataTypeState;
        break;
      case NodeClass.View:
        UAView uaView = (UAView) node;
        nodeState = (NodeState) new ViewState()
        {
          ContainsNoLoops = uaView.ContainsNoLoops
        };
        break;
    }
    nodeState.NodeId = this.ImportNodeId(node.NodeId, context.NamespaceUris, false);
    nodeState.BrowseName = this.ImportQualifiedName(node.BrowseName, context.NamespaceUris);
    nodeState.DisplayName = this.Import(node.DisplayName);
    if (nodeState.DisplayName == (Opc.Ua.LocalizedText) null)
      nodeState.DisplayName = new Opc.Ua.LocalizedText(nodeState.BrowseName.Name);
    nodeState.Description = this.Import(node.Description);
    nodeState.NodeSetDocumentation = node.Documentation;
    nodeState.Categories = node.Category == null || node.Category.Length == 0 ? (IList<string>) (string[]) null : (IList<string>) node.Category;
    nodeState.ReleaseStatus = node.ReleaseStatus;
    nodeState.WriteMask = (AttributeWriteMask) node.WriteMask;
    nodeState.UserWriteMask = (AttributeWriteMask) node.UserWriteMask;
    nodeState.Extensions = node.Extensions;
    if (!string.IsNullOrEmpty(node.SymbolicName))
      nodeState.SymbolicName = node.SymbolicName;
    if (node.References != null)
    {
      for (int index = 0; index < node.References.Length; ++index)
      {
        NodeId referenceTypeId = this.ImportNodeId(node.References[index].ReferenceType, context.NamespaceUris, true);
        bool isInverse = !node.References[index].IsForward;
        ExpandedNodeId expandedNodeId = this.ImportExpandedNodeId(node.References[index].Value, context.NamespaceUris, context.ServerUris);
        if (nodeState is BaseInstanceState baseInstanceState)
        {
          if (referenceTypeId == (object) ReferenceTypeIds.HasModellingRule && !isInverse)
          {
            baseInstanceState.ModellingRuleId = ExpandedNodeId.ToNodeId(expandedNodeId, context.NamespaceUris);
            continue;
          }
          if (referenceTypeId == (object) ReferenceTypeIds.HasTypeDefinition && !isInverse)
          {
            baseInstanceState.TypeDefinitionId = ExpandedNodeId.ToNodeId(expandedNodeId, context.NamespaceUris);
            continue;
          }
        }
        if (nodeState is BaseTypeState baseTypeState && referenceTypeId == (object) ReferenceTypeIds.HasSubtype & isInverse)
          baseTypeState.SuperTypeId = ExpandedNodeId.ToNodeId(expandedNodeId, context.NamespaceUris);
        else
          nodeState.AddReference(referenceTypeId, isInverse, expandedNodeId);
      }
    }
    string parentNodeId = node is UAInstance uaInstance ? uaInstance.ParentNodeId : (string) null;
    if (!string.IsNullOrEmpty(parentNodeId))
      nodeState.Handle = (object) this.ImportNodeId(parentNodeId, context.NamespaceUris, true);
    return nodeState;
  }

  private string ExportAlias(NodeId source, NamespaceTable namespaceUris)
  {
    string str = this.Export(source, namespaceUris);
    if (!string.IsNullOrEmpty(str) && this.Aliases != null)
    {
      for (int index = 0; index < this.Aliases.Length; ++index)
      {
        if (this.Aliases[index].Value == str)
          return this.Aliases[index].Alias;
      }
    }
    return str;
  }

  private string Export(NodeId source, NamespaceTable namespaceUris)
  {
    if (NodeId.IsNull(source))
      return string.Empty;
    if (source.NamespaceIndex > (ushort) 0)
    {
      ushort namespaceIndex = this.ExportNamespaceIndex(source.NamespaceIndex, namespaceUris);
      source = new NodeId(source.Identifier, namespaceIndex);
    }
    return source.ToString();
  }

  private NodeId ImportNodeId(string source, NamespaceTable namespaceUris, bool lookupAlias)
  {
    if (string.IsNullOrEmpty(source))
      return NodeId.Null;
    if (lookupAlias && this.Aliases != null)
    {
      for (int index = 0; index < this.Aliases.Length; ++index)
      {
        if (this.Aliases[index].Alias == source)
        {
          source = this.Aliases[index].Value;
          break;
        }
      }
    }
    NodeId nodeId = NodeId.Parse(source);
    if (nodeId.NamespaceIndex > (ushort) 0)
    {
      ushort namespaceIndex = this.ImportNamespaceIndex(nodeId.NamespaceIndex, namespaceUris);
      nodeId = new NodeId(nodeId.Identifier, namespaceIndex);
    }
    return nodeId;
  }

  private string Export(
    ExpandedNodeId source,
    NamespaceTable namespaceUris,
    StringTable serverUris)
  {
    if (NodeId.IsNull(source))
      return string.Empty;
    if (source.ServerIndex <= 0U && source.NamespaceIndex <= (ushort) 0 && string.IsNullOrEmpty(source.NamespaceUri))
      return source.ToString();
    ushort namespaceIndex = !string.IsNullOrEmpty(source.NamespaceUri) ? this.ExportNamespaceUri(source.NamespaceUri, namespaceUris) : this.ExportNamespaceIndex(source.NamespaceIndex, namespaceUris);
    uint serverIndex = this.ExportServerIndex(source.ServerIndex, serverUris);
    source = new ExpandedNodeId(source.Identifier, namespaceIndex, (string) null, serverIndex);
    return source.ToString();
  }

  private ExpandedNodeId ImportExpandedNodeId(
    string source,
    NamespaceTable namespaceUris,
    StringTable serverUris)
  {
    if (string.IsNullOrEmpty(source))
      return ExpandedNodeId.Null;
    if (this.Aliases != null)
    {
      for (int index = 0; index < this.Aliases.Length; ++index)
      {
        if (this.Aliases[index].Alias == source)
        {
          source = this.Aliases[index].Value;
          break;
        }
      }
    }
    ExpandedNodeId expandedNodeId = ExpandedNodeId.Parse(source);
    if (expandedNodeId.ServerIndex <= 0U && expandedNodeId.NamespaceIndex <= (ushort) 0 && string.IsNullOrEmpty(expandedNodeId.NamespaceUri))
      return expandedNodeId;
    uint serverIndex = this.ImportServerIndex(expandedNodeId.ServerIndex, serverUris);
    ushort num = this.ImportNamespaceIndex(expandedNodeId.NamespaceIndex, namespaceUris);
    if (serverIndex <= 0U)
      return new ExpandedNodeId(expandedNodeId.Identifier, num, (string) null, 0U);
    string namespaceUri = expandedNodeId.NamespaceUri;
    if (string.IsNullOrEmpty(expandedNodeId.NamespaceUri))
      namespaceUri = namespaceUris.GetString((uint) num);
    return new ExpandedNodeId(expandedNodeId.Identifier, (ushort) 0, namespaceUri, serverIndex);
  }

  private string Export(QualifiedName source, NamespaceTable namespaceUris)
  {
    if (QualifiedName.IsNull(source))
      return string.Empty;
    if (source.NamespaceIndex > (ushort) 0)
    {
      ushort namespaceIndex = this.ExportNamespaceIndex(source.NamespaceIndex, namespaceUris);
      source = new QualifiedName(source.Name, namespaceIndex);
    }
    return source.ToString();
  }

  private DataTypeDefinition Export(
    DataTypeState dataType,
    ExtensionObject source,
    NamespaceTable namespaceUris,
    bool outputRedundantNames)
  {
    if (source == null || source.Body == null)
      return (DataTypeDefinition) null;
    DataTypeDefinition dataTypeDefinition = new DataTypeDefinition();
    if (outputRedundantNames || dataType.BrowseName != (QualifiedName) null)
      dataTypeDefinition.Name = this.Export(dataType.BrowseName, namespaceUris);
    if (dataType.BrowseName.Name != dataType.SymbolicName)
      dataTypeDefinition.SymbolicName = dataType.SymbolicName;
    if (source.Body is StructureDefinition body1)
    {
      if (body1.StructureType == StructureType.Union || body1.StructureType == StructureType.UnionWithSubtypedValues)
        dataTypeDefinition.IsUnion = true;
      if (body1.Fields != null)
      {
        List<DataTypeField> dataTypeFieldList = new List<DataTypeField>();
        for (int explicitFieldIndex = body1.FirstExplicitFieldIndex; explicitFieldIndex < body1.Fields.Count; ++explicitFieldIndex)
        {
          StructureField field = body1.Fields[explicitFieldIndex];
          DataTypeField dataTypeField = new DataTypeField();
          dataTypeField.Name = field.Name;
          dataTypeField.Description = this.Export(new Opc.Ua.LocalizedText[1]
          {
            field.Description
          });
          if (body1.StructureType == StructureType.StructureWithOptionalFields)
          {
            dataTypeField.IsOptional = field.IsOptional;
            dataTypeField.AllowSubTypes = false;
          }
          else if (body1.StructureType != StructureType.StructureWithSubtypedValues && body1.StructureType != StructureType.UnionWithSubtypedValues)
          {
            dataTypeField.IsOptional = false;
            dataTypeField.AllowSubTypes = false;
          }
          else
          {
            dataTypeField.IsOptional = false;
            dataTypeField.AllowSubTypes = field.IsOptional;
          }
          dataTypeField.DataType = !NodeId.IsNull(field.DataType) ? this.Export(field.DataType, namespaceUris) : this.Export(DataTypeIds.BaseDataType, namespaceUris);
          dataTypeField.ValueRank = field.ValueRank;
          if (field.ArrayDimensions != null && field.ArrayDimensions.Count != 0 && (dataTypeField.ValueRank > 1 || field.ArrayDimensions[0] > 0U))
            dataTypeField.ArrayDimensions = BaseVariableState.ArrayDimensionsToXml((IList<uint>) field.ArrayDimensions);
          dataTypeField.MaxStringLength = field.MaxStringLength;
          dataTypeFieldList.Add(dataTypeField);
        }
        dataTypeDefinition.Field = dataTypeFieldList.ToArray();
      }
    }
    if (source.Body is EnumDefinition body2)
    {
      dataTypeDefinition.IsOptionSet = body2.IsOptionSet;
      if (body2.Fields != null)
      {
        List<DataTypeField> dataTypeFieldList = new List<DataTypeField>();
        foreach (EnumField field in (List<EnumField>) body2.Fields)
        {
          DataTypeField dataTypeField = new DataTypeField();
          dataTypeField.Name = field.Name;
          if (field.DisplayName != (Opc.Ua.LocalizedText) null && dataTypeField.Name != field.DisplayName.Text)
            dataTypeField.DisplayName = this.Export(new Opc.Ua.LocalizedText[1]
            {
              field.DisplayName
            });
          else
            dataTypeField.DisplayName = Array.Empty<LocalizedText>();
          dataTypeField.Description = this.Export(new Opc.Ua.LocalizedText[1]
          {
            field.Description
          });
          dataTypeField.ValueRank = -1;
          dataTypeField.Value = (int) field.Value;
          dataTypeFieldList.Add(dataTypeField);
        }
        dataTypeDefinition.Field = dataTypeFieldList.ToArray();
      }
    }
    return dataTypeDefinition;
  }

  private Opc.Ua.DataTypeDefinition Import(
    UADataType dataType,
    DataTypeDefinition source,
    NamespaceTable namespaceUris)
  {
    if (source == null)
      return (Opc.Ua.DataTypeDefinition) null;
    Opc.Ua.DataTypeDefinition dataTypeDefinition = (Opc.Ua.DataTypeDefinition) null;
    if (source.Field != null)
    {
      if (!Array.Exists<DataTypeField>(source.Field, (Predicate<DataTypeField>) (fieldLookup => fieldLookup.Value != -1)))
      {
        StructureDefinition structureDefinition = new StructureDefinition();
        structureDefinition.BaseDataType = this.ImportNodeId(source.BaseType, namespaceUris, true);
        if (source.IsUnion)
          structureDefinition.StructureType = StructureType.Union;
        if (source.Field != null)
        {
          List<StructureField> structureFieldList = new List<StructureField>();
          foreach (DataTypeField dataTypeField in source.Field)
          {
            if (structureDefinition.StructureType == StructureType.Structure || structureDefinition.StructureType == StructureType.Union)
            {
              if (dataTypeField.IsOptional)
                structureDefinition.StructureType = StructureType.StructureWithOptionalFields;
              else if (dataTypeField.AllowSubTypes)
                structureDefinition.StructureType = !source.IsUnion ? StructureType.StructureWithSubtypedValues : StructureType.UnionWithSubtypedValues;
            }
            StructureField structureField = new StructureField();
            structureField.Name = dataTypeField.Name;
            structureField.Description = this.Import(dataTypeField.Description);
            structureField.DataType = this.ImportNodeId(dataTypeField.DataType, namespaceUris, true);
            structureField.ValueRank = dataTypeField.ValueRank;
            if (!string.IsNullOrWhiteSpace(dataTypeField.ArrayDimensions) && (structureField.ValueRank > 1 || dataTypeField.ArrayDimensions[0] > char.MinValue))
              structureField.ArrayDimensions = new UInt32Collection((IEnumerable<uint>) BaseVariableState.ArrayDimensionsFromXml(dataTypeField.ArrayDimensions));
            structureField.MaxStringLength = dataTypeField.MaxStringLength;
            structureField.IsOptional = structureDefinition.StructureType != StructureType.Structure && structureDefinition.StructureType != StructureType.Union && (structureDefinition.StructureType == StructureType.StructureWithSubtypedValues || structureDefinition.StructureType == StructureType.UnionWithSubtypedValues ? dataTypeField.AllowSubTypes : dataTypeField.IsOptional);
            structureFieldList.Add(structureField);
          }
          structureDefinition.Fields = (StructureFieldCollection) structureFieldList.ToArray();
        }
        dataTypeDefinition = (Opc.Ua.DataTypeDefinition) structureDefinition;
      }
      else
      {
        EnumDefinition enumDefinition = new EnumDefinition();
        enumDefinition.IsOptionSet = source.IsOptionSet;
        if (source.Field != null)
        {
          List<EnumField> enumFieldList = new List<EnumField>();
          foreach (DataTypeField dataTypeField in source.Field)
          {
            EnumField enumField = new EnumField();
            enumField.Name = dataTypeField.Name;
            enumField.DisplayName = this.Import(dataTypeField.DisplayName);
            enumField.Description = this.Import(dataTypeField.Description);
            enumField.Value = (long) dataTypeField.Value;
            enumFieldList.Add(enumField);
          }
          enumDefinition.Fields = (EnumFieldCollection) enumFieldList.ToArray();
        }
        dataTypeDefinition = (Opc.Ua.DataTypeDefinition) enumDefinition;
      }
    }
    return dataTypeDefinition;
  }

  private QualifiedName ImportQualifiedName(string source, NamespaceTable namespaceUris)
  {
    if (string.IsNullOrEmpty(source))
      return QualifiedName.Null;
    QualifiedName qualifiedName = QualifiedName.Parse(source);
    if (qualifiedName.NamespaceIndex > (ushort) 0)
    {
      ushort namespaceIndex = this.ImportNamespaceIndex(qualifiedName.NamespaceIndex, namespaceUris);
      qualifiedName = new QualifiedName(qualifiedName.Name, namespaceIndex);
    }
    return qualifiedName;
  }

  private string Export(IList<uint> arrayDimensions)
  {
    if (arrayDimensions == null)
      return string.Empty;
    StringBuilder stringBuilder = new StringBuilder();
    for (int index = 0; index < arrayDimensions.Count; ++index)
    {
      if (stringBuilder.Length > 0)
        stringBuilder.Append(',');
      stringBuilder.Append(arrayDimensions[index]);
    }
    return stringBuilder.ToString();
  }

  private uint[] ImportArrayDimensions(string arrayDimensions)
  {
    if (string.IsNullOrEmpty(arrayDimensions))
      return (uint[]) null;
    string[] strArray = arrayDimensions.Split(',');
    uint[] numArray = new uint[strArray.Length];
    for (int index = 0; index < strArray.Length; ++index)
    {
      try
      {
        numArray[index] = Convert.ToUInt32(strArray[index]);
      }
      catch
      {
        numArray[index] = 0U;
      }
    }
    return numArray;
  }

  private LocalizedText[] Export(Opc.Ua.LocalizedText[] input)
  {
    if (input == null)
      return (LocalizedText[]) null;
    List<LocalizedText> localizedTextList = new List<LocalizedText>();
    for (int index = 0; index < input.Length; ++index)
    {
      if (input[index] != (Opc.Ua.LocalizedText) null)
        localizedTextList.Add(new LocalizedText()
        {
          Locale = input[index].Locale,
          Value = input[index].Text
        });
    }
    return localizedTextList.ToArray();
  }

  private LocalizedText Export(Opc.Ua.LocalizedText input)
  {
    if (input == (Opc.Ua.LocalizedText) null)
      return (LocalizedText) null;
    return new LocalizedText()
    {
      Locale = input.Locale,
      Value = input.Text
    };
  }

  private Opc.Ua.LocalizedText Import(params LocalizedText[] input)
  {
    if (input == null)
      return (Opc.Ua.LocalizedText) null;
    for (int index = 0; index < input.Length; ++index)
    {
      if (input[index] != null)
        return new Opc.Ua.LocalizedText(input[index].Locale, input[index].Value);
    }
    return (Opc.Ua.LocalizedText) null;
  }

  private ushort ExportNamespaceIndex(ushort namespaceIndex, NamespaceTable namespaceUris)
  {
    if (namespaceIndex < (ushort) 1)
      return namespaceIndex;
    if (namespaceUris == null || namespaceUris.Count <= (int) namespaceIndex)
      return ushort.MaxValue;
    int length = 1;
    string str = namespaceUris.GetString((uint) namespaceIndex);
    if (this.NamespaceUris != null)
    {
      for (int index = 0; index < this.NamespaceUris.Length; ++index)
      {
        if (this.NamespaceUris[index] == str)
          return (ushort) (index + 1);
      }
      length += this.NamespaceUris.Length;
    }
    string[] destinationArray = new string[length];
    if (this.NamespaceUris != null)
      Array.Copy((Array) this.NamespaceUris, (Array) destinationArray, length - 1);
    destinationArray[length - 1] = str;
    this.NamespaceUris = destinationArray;
    return (ushort) length;
  }

  private ushort ImportNamespaceIndex(ushort namespaceIndex, NamespaceTable namespaceUris)
  {
    if (namespaceIndex < (ushort) 1)
      return namespaceIndex;
    return namespaceUris != null && this.NamespaceUris != null && this.NamespaceUris.Length > (int) namespaceIndex - 1 ? namespaceUris.GetIndexOrAppend(this.NamespaceUris[(int) namespaceIndex - 1]) : ushort.MaxValue;
  }

  private ushort ExportNamespaceUri(string namespaceUri, NamespaceTable namespaceUris)
  {
    if (namespaceUris == null)
      return ushort.MaxValue;
    int index1 = namespaceUris.GetIndex(namespaceUri);
    if (index1 == 0)
      return (ushort) index1;
    int length = 1;
    if (this.NamespaceUris != null)
    {
      for (int index2 = 0; index2 < this.NamespaceUris.Length; ++index2)
      {
        if (this.NamespaceUris[index2] == namespaceUri)
          return (ushort) (index2 + 1);
      }
      length += this.NamespaceUris.Length;
    }
    string[] destinationArray = new string[length];
    if (this.NamespaceUris != null)
      Array.Copy((Array) this.NamespaceUris, (Array) destinationArray, length - 1);
    destinationArray[length - 1] = namespaceUri;
    this.NamespaceUris = destinationArray;
    return (ushort) length;
  }

  private uint ExportServerIndex(uint serverIndex, StringTable serverUris)
  {
    if (serverIndex <= 0U)
      return serverIndex;
    if (serverUris == null || (long) serverUris.Count < (long) serverIndex)
      return (uint) ushort.MaxValue;
    int length = 1;
    string str = serverUris.GetString(serverIndex);
    if (this.ServerUris != null)
    {
      for (int index = 0; index < this.ServerUris.Length; ++index)
      {
        if (this.ServerUris[index] == str)
          return (uint) (ushort) (index + 1);
      }
      length += this.ServerUris.Length;
    }
    string[] destinationArray = new string[length];
    if (this.ServerUris != null)
      Array.Copy((Array) this.ServerUris, (Array) destinationArray, length - 1);
    destinationArray[length - 1] = str;
    this.ServerUris = destinationArray;
    return (uint) (ushort) length;
  }

  private uint ImportServerIndex(uint serverIndex, StringTable serverUris)
  {
    if (serverIndex <= 0U)
      return serverIndex;
    return serverUris != null && this.ServerUris != null && (long) this.ServerUris.Length > (long) (serverIndex - 1U) ? (uint) serverUris.GetIndexOrAppend(this.ServerUris[(int) serverIndex - 1]) : (uint) ushort.MaxValue;
  }
}
