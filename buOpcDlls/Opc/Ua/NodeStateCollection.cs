// Decompiled with JetBrains decompiler
// Type: Opc.Ua.NodeStateCollection
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Export;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml;

#nullable disable
namespace Opc.Ua;

[ComVisible(true)]
public class NodeStateCollection : List<NodeState>
{
  private NodeStateCollection.AliasToUse[] s_AliasesToUse = new NodeStateCollection.AliasToUse[46]
  {
    new NodeStateCollection.AliasToUse("Boolean", DataTypeIds.Boolean),
    new NodeStateCollection.AliasToUse("SByte", DataTypeIds.SByte),
    new NodeStateCollection.AliasToUse("Byte", DataTypeIds.Byte),
    new NodeStateCollection.AliasToUse("Int16", DataTypeIds.Int16),
    new NodeStateCollection.AliasToUse("UInt16", DataTypeIds.UInt16),
    new NodeStateCollection.AliasToUse("Int32", DataTypeIds.Int32),
    new NodeStateCollection.AliasToUse("UInt32", DataTypeIds.UInt32),
    new NodeStateCollection.AliasToUse("Int64", DataTypeIds.Int64),
    new NodeStateCollection.AliasToUse("UInt64", DataTypeIds.UInt64),
    new NodeStateCollection.AliasToUse("Float", DataTypeIds.Float),
    new NodeStateCollection.AliasToUse("Double", DataTypeIds.Double),
    new NodeStateCollection.AliasToUse("DateTime", DataTypeIds.DateTime),
    new NodeStateCollection.AliasToUse("String", DataTypeIds.String),
    new NodeStateCollection.AliasToUse("ByteString", DataTypeIds.ByteString),
    new NodeStateCollection.AliasToUse("Guid", DataTypeIds.Guid),
    new NodeStateCollection.AliasToUse("XmlElement", DataTypeIds.XmlElement),
    new NodeStateCollection.AliasToUse("NodeId", DataTypeIds.NodeId),
    new NodeStateCollection.AliasToUse("ExpandedNodeId", DataTypeIds.ExpandedNodeId),
    new NodeStateCollection.AliasToUse("QualifiedName", DataTypeIds.QualifiedName),
    new NodeStateCollection.AliasToUse("LocalizedText", DataTypeIds.LocalizedText),
    new NodeStateCollection.AliasToUse("StatusCode", DataTypeIds.StatusCode),
    new NodeStateCollection.AliasToUse("Structure", DataTypeIds.Structure),
    new NodeStateCollection.AliasToUse("Number", DataTypeIds.Number),
    new NodeStateCollection.AliasToUse("Integer", DataTypeIds.Integer),
    new NodeStateCollection.AliasToUse("UInteger", DataTypeIds.UInteger),
    new NodeStateCollection.AliasToUse("HasComponent", ReferenceTypeIds.HasComponent),
    new NodeStateCollection.AliasToUse("HasProperty", ReferenceTypeIds.HasProperty),
    new NodeStateCollection.AliasToUse("Organizes", ReferenceTypeIds.Organizes),
    new NodeStateCollection.AliasToUse("HasEventSource", ReferenceTypeIds.HasEventSource),
    new NodeStateCollection.AliasToUse("HasNotifier", ReferenceTypeIds.HasNotifier),
    new NodeStateCollection.AliasToUse("HasSubtype", ReferenceTypeIds.HasSubtype),
    new NodeStateCollection.AliasToUse("HasTypeDefinition", ReferenceTypeIds.HasTypeDefinition),
    new NodeStateCollection.AliasToUse("HasModellingRule", ReferenceTypeIds.HasModellingRule),
    new NodeStateCollection.AliasToUse("HasEncoding", ReferenceTypeIds.HasEncoding),
    new NodeStateCollection.AliasToUse("HasDescription", ReferenceTypeIds.HasDescription),
    new NodeStateCollection.AliasToUse("HasCause", ReferenceTypeIds.HasCause),
    new NodeStateCollection.AliasToUse("ToState", ReferenceTypeIds.ToState),
    new NodeStateCollection.AliasToUse("FromState", ReferenceTypeIds.FromState),
    new NodeStateCollection.AliasToUse("HasEffect", ReferenceTypeIds.HasEffect),
    new NodeStateCollection.AliasToUse("HasTrueSubState", ReferenceTypeIds.HasTrueSubState),
    new NodeStateCollection.AliasToUse("HasFalseSubState", ReferenceTypeIds.HasFalseSubState),
    new NodeStateCollection.AliasToUse("HasDictionaryEntry", ReferenceTypeIds.HasDictionaryEntry),
    new NodeStateCollection.AliasToUse("HasCondition", ReferenceTypeIds.HasCondition),
    new NodeStateCollection.AliasToUse("HasGuard", ReferenceTypeIds.HasGuard),
    new NodeStateCollection.AliasToUse("HasAddIn", ReferenceTypeIds.HasAddIn),
    new NodeStateCollection.AliasToUse("HasInterface", ReferenceTypeIds.HasInterface)
  };

  public void SaveAsNodeSet2(
    ISystemContext context,
    Stream ostrm,
    ModelTableEntry model,
    DateTime lastModified,
    bool outputRedundantNames)
  {
    UANodeSet uaNodeSet = new UANodeSet();
    if (lastModified != DateTime.MinValue)
    {
      uaNodeSet.LastModified = lastModified;
      uaNodeSet.LastModifiedSpecified = true;
    }
    uaNodeSet.NamespaceUris = context.NamespaceUris != null ? ((IEnumerable<string>) context.NamespaceUris.ToArray()).Where<string>((Func<string, bool>) (x => x != "http://opcfoundation.org/UA/")).ToArray<string>() : (string[]) null;
    uaNodeSet.ServerUris = context.ServerUris != null ? context.ServerUris.ToArray() : (string[]) null;
    if (uaNodeSet.NamespaceUris != null && uaNodeSet.NamespaceUris.Length == 0)
      uaNodeSet.NamespaceUris = (string[]) null;
    if (uaNodeSet.ServerUris != null && uaNodeSet.ServerUris.Length == 0)
      uaNodeSet.ServerUris = (string[]) null;
    if (model != null)
      uaNodeSet.Models = new ModelTableEntry[1]{ model };
    for (int index = 0; index < this.s_AliasesToUse.Length; ++index)
      uaNodeSet.AddAlias(context, this.s_AliasesToUse[index].Alias, this.s_AliasesToUse[index].NodeId);
    for (int index = 0; index < this.Count; ++index)
      uaNodeSet.Export(context, this[index], outputRedundantNames);
    uaNodeSet.Write(ostrm);
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
    NodeTable table = new NodeTable(context.NamespaceUris, context.ServerUris, (TypeTable) null);
    for (int index = 0; index < this.Count; ++index)
      this[index].Export(context, table);
    NodeSet graph = new NodeSet();
    foreach (ILocalNode nodeToExport in table)
      graph.Add(nodeToExport, table.NamespaceUris, table.ServerUris);
    XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
    settings.CloseOutput = true;
    using (XmlWriter writer = XmlWriter.Create(ostrm, settings))
      new DataContractSerializer(typeof (NodeSet)).WriteObject(writer, (object) graph);
  }

  public void SaveAsNodeSet2(ISystemContext context, Stream ostrm)
  {
    this.SaveAsNodeSet2(context, ostrm, (string) null);
  }

  public void SaveAsNodeSet2(ISystemContext context, Stream ostrm, string version)
  {
    UANodeSet uaNodeSet = new UANodeSet();
    uaNodeSet.LastModified = DateTime.UtcNow;
    uaNodeSet.LastModifiedSpecified = true;
    for (int index = 0; index < this.s_AliasesToUse.Length; ++index)
      uaNodeSet.AddAlias(context, this.s_AliasesToUse[index].Alias, this.s_AliasesToUse[index].NodeId);
    for (int index = 0; index < this.Count; ++index)
      uaNodeSet.Export(context, this[index]);
    uaNodeSet.Write(ostrm);
  }

  public void SaveAsXml(ISystemContext context, Stream ostrm)
  {
    this.SaveAsXml(context, ostrm, false);
  }

  public void SaveAsXml(ISystemContext context, Stream ostrm, bool keepStreamOpen)
  {
    XmlWriterSettings settings = Utils.DefaultXmlWriterSettings();
    settings.CloseOutput = !keepStreamOpen;
    ServiceMessageContext context1 = new ServiceMessageContext()
    {
      NamespaceUris = context.NamespaceUris,
      ServerUris = context.ServerUris,
      Factory = context.EncodeableFactory
    };
    using (XmlWriter writer = XmlWriter.Create(ostrm, settings))
    {
      using (XmlEncoder encoder = new XmlEncoder(new XmlQualifiedName("ListOfNodeState", "http://opcfoundation.org/UA/2008/02/Types.xsd"), writer, (IServiceMessageContext) context1))
      {
        encoder.SaveStringTable("NamespaceUris", "NamespaceUri", (StringTable) context.NamespaceUris);
        encoder.SaveStringTable("ServerUris", "ServerUri", context.ServerUris);
        for (int index = 0; index < this.Count; ++index)
          this[index]?.SaveAsXml(context, encoder);
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
      encoder.WriteInt32((string) null, this.Count);
      for (int index = 0; index < this.Count; ++index)
        this[index].SaveAsBinary(context, encoder);
      encoder.Close();
    }
  }

  public void LoadFromBinary(ISystemContext context, Stream istrm, bool updateTables)
  {
    using (BinaryDecoder decoder = new BinaryDecoder(istrm, (IServiceMessageContext) new ServiceMessageContext()
    {
      NamespaceUris = context.NamespaceUris,
      ServerUris = context.ServerUris,
      Factory = context.EncodeableFactory
    }))
    {
      NamespaceTable namespaceUris = new NamespaceTable();
      if (!decoder.LoadStringTable((StringTable) namespaceUris))
        namespaceUris = (NamespaceTable) null;
      if (updateTables && namespaceUris != null && context.NamespaceUris != null)
      {
        for (int index = 0; index < namespaceUris.Count; ++index)
        {
          int indexOrAppend = (int) context.NamespaceUris.GetIndexOrAppend(namespaceUris.GetString((uint) index));
        }
      }
      StringTable stringTable = new StringTable();
      if (namespaceUris != null && namespaceUris.Count > 1)
        stringTable.Append(namespaceUris.GetString(1U));
      if (!decoder.LoadStringTable(stringTable))
        stringTable = (StringTable) null;
      if (updateTables && stringTable != null && context.ServerUris != null)
      {
        for (int index = 0; index < stringTable.Count; ++index)
        {
          int indexOrAppend = (int) context.ServerUris.GetIndexOrAppend(stringTable.GetString((uint) index));
        }
      }
      decoder.SetMappingTables(namespaceUris, stringTable);
      int num = decoder.ReadInt32((string) null);
      for (int index = 0; index < num; ++index)
        this.Add(NodeState.LoadNode(context, decoder));
    }
  }

  public void LoadFromXml(ISystemContext context, Stream istrm, bool updateTables)
  {
    ServiceMessageContext context1 = new ServiceMessageContext();
    context1.NamespaceUris = context.NamespaceUris;
    context1.ServerUris = context.ServerUris;
    context1.Factory = context.EncodeableFactory;
    using (XmlReader reader = XmlReader.Create(istrm, Utils.DefaultXmlReaderSettings()))
    {
      XmlDecoder decoder = new XmlDecoder((Type) null, reader, (IServiceMessageContext) context1);
      NamespaceTable namespaceUris = new NamespaceTable();
      if (!decoder.LoadStringTable("NamespaceUris", "NamespaceUri", (StringTable) namespaceUris))
        namespaceUris = (NamespaceTable) null;
      if (updateTables && namespaceUris != null && context.NamespaceUris != null)
      {
        for (int index = 0; index < namespaceUris.Count; ++index)
        {
          int indexOrAppend = (int) context.NamespaceUris.GetIndexOrAppend(namespaceUris.GetString((uint) index));
        }
      }
      StringTable serverUris = new StringTable();
      if (!decoder.LoadStringTable("ServerUris", "ServerUri", context.ServerUris))
        serverUris = (StringTable) null;
      if (updateTables && serverUris != null && context.ServerUris != null)
      {
        for (int index = 0; index < serverUris.Count; ++index)
        {
          int indexOrAppend = (int) context.ServerUris.GetIndexOrAppend(serverUris.GetString((uint) index));
        }
      }
      decoder.SetMappingTables(namespaceUris, serverUris);
      decoder.PushNamespace("http://opcfoundation.org/UA/2008/02/Types.xsd");
      for (NodeState nodeState = NodeState.LoadNode(context, decoder); nodeState != null; nodeState = NodeState.LoadNode(context, decoder))
        this.Add(nodeState);
      decoder.Close();
    }
  }

  public void LoadFromResource(
    ISystemContext context,
    string resourcePath,
    Assembly assembly,
    bool updateTables)
  {
    if (resourcePath == null)
      throw new ArgumentNullException(nameof (resourcePath));
    Stream istrm = !(assembly == (Assembly) null) ? assembly.GetManifestResourceStream(resourcePath) : throw new ArgumentNullException(nameof (assembly));
    if (istrm == null)
    {
      istrm = (Stream) new FileInfo(resourcePath).OpenRead();
      if (istrm == null)
        throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Could not load nodes from resource: {0}", (object) resourcePath);
    }
    this.LoadFromXml(context, istrm, updateTables);
  }

  public void LoadFromBinaryResource(
    ISystemContext context,
    string resourcePath,
    Assembly assembly,
    bool updateTables)
  {
    if (resourcePath == null)
      throw new ArgumentNullException(nameof (resourcePath));
    Stream istrm = !(assembly == (Assembly) null) ? assembly.GetManifestResourceStream(resourcePath) : throw new ArgumentNullException(nameof (assembly));
    if (istrm == null)
    {
      istrm = (Stream) new FileInfo(resourcePath).OpenRead();
      if (istrm == null)
        throw ServiceResultException.Create(2147942400U /*0x80070000*/, "Could not load nodes from resource: {0}", (object) resourcePath);
    }
    this.LoadFromBinary(context, istrm, updateTables);
  }

  private struct AliasToUse(string alias, NodeId nodeId)
  {
    public string Alias = alias;
    public NodeId NodeId = nodeId;
  }
}
