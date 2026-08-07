// Decompiled with JetBrains decompiler
// Type: Opc.Ua.Client.DataDictionary
// Assembly: buOpcDlls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 560E3953-6FA5-4F4F-B03A-B91ECF3CFE07
// Assembly location: C:\Users\ERCAN\Downloads\de4dot-net48\testTemiz\buOpcDlls.dll

using Opc.Ua.Schema;
using Opc.Ua.Schema.Binary;
using Opc.Ua.Schema.Xml;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;

#nullable disable
namespace Opc.Ua.Client;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataDictionary
{
  private ISession m_session;
  private SchemaValidator m_validator;

  public DataDictionary(ISession session)
  {
    this.Initialize();
    this.m_session = session;
  }

  private void Initialize()
  {
    this.m_session = (ISession) null;
    this.DataTypes = new Dictionary<NodeId, QualifiedName>();
    this.m_validator = (SchemaValidator) null;
    this.TypeSystemId = (NodeId) null;
    this.TypeSystemName = (string) null;
    this.DictionaryId = (NodeId) null;
    this.Name = (string) null;
  }

  public NodeId DictionaryId { get; private set; }

  public string Name { get; private set; }

  public NodeId TypeSystemId { get; private set; }

  public string TypeSystemName { get; private set; }

  public TypeDictionary TypeDictionary { get; private set; }

  public Dictionary<NodeId, QualifiedName> DataTypes { get; private set; }

  public void Load(INode dictionary)
  {
    if (dictionary == null)
      throw new ArgumentNullException(nameof (dictionary));
    this.Load(ExpandedNodeId.ToNodeId(dictionary.NodeId, this.m_session.NamespaceUris), dictionary.ToString());
  }

  public void Load(
    NodeId dictionaryId,
    string name,
    byte[] schema = null,
    IDictionary<string, byte[]> imports = null)
  {
    if (dictionaryId == (object) null)
      throw new ArgumentNullException(nameof (dictionaryId));
    this.GetTypeSystem(dictionaryId);
    if (schema == null || schema.Length == 0)
      schema = this.ReadDictionary(dictionaryId);
    int newSize = schema != null && schema.Length != 0 ? Array.IndexOf<byte>(schema, (byte) 0) : throw ServiceResultException.Create(2147549184U /*0x80010000*/, "Cannot parse empty data dictionary.");
    if (newSize >= 0)
      Array.Resize<byte>(ref schema, newSize);
    this.Validate(schema, imports);
    this.ReadDataTypes(dictionaryId);
    this.DictionaryId = dictionaryId;
    this.Name = name;
  }

  public bool Contains(NodeId descriptionId) => this.DataTypes.ContainsKey(descriptionId);

  public string GetSchema(NodeId descriptionId)
  {
    if (!(descriptionId != (object) null))
      return this.m_validator.GetSchema((string) null);
    QualifiedName qualifiedName;
    return !this.DataTypes.TryGetValue(descriptionId, out qualifiedName) ? (string) null : this.m_validator.GetSchema(qualifiedName.Name);
  }

  private void GetTypeSystem(NodeId dictionaryId)
  {
    IList<INode> references = this.m_session.NodeCache.FindReferences((ExpandedNodeId) dictionaryId, ReferenceTypeIds.HasComponent, true, false);
    if (references.Count <= 0)
      return;
    this.TypeSystemId = ExpandedNodeId.ToNodeId(references[0].NodeId, this.m_session.NamespaceUris);
    this.TypeSystemName = references[0].ToString();
  }

  private void ReadDataTypes(NodeId dictionaryId)
  {
    IList<INode> references = this.m_session.NodeCache.FindReferences((ExpandedNodeId) dictionaryId, ReferenceTypeIds.HasComponent, false, false);
    DataValueCollection values;
    IList<ServiceResult> errors;
    this.m_session.ReadValues((IList<NodeId>) references.Select<INode, NodeId>((Func<INode, NodeId>) (node => ExpandedNodeId.ToNodeId(node.NodeId, this.m_session.NamespaceUris))).ToList<NodeId>(), out values, out errors);
    int index = 0;
    foreach (INode node in (IEnumerable<INode>) references)
    {
      NodeId nodeId = ExpandedNodeId.ToNodeId(node.NodeId, this.m_session.NamespaceUris);
      if (nodeId != (object) null)
      {
        if (ServiceResult.IsGood(errors[index]))
        {
          string name = (string) values[index].Value;
          this.DataTypes[nodeId] = new QualifiedName(name, nodeId.NamespaceIndex);
        }
        ++index;
      }
    }
  }

  public static async Task<IDictionary<NodeId, byte[]>> ReadDictionaries(
    ISessionClientMethods session,
    IList<NodeId> dictionaryIds,
    CancellationToken ct = default (CancellationToken))
  {
    ReadValueIdCollection itemsToRead = new ReadValueIdCollection();
    foreach (NodeId dictionaryId in (IEnumerable<NodeId>) dictionaryIds)
      itemsToRead.Add(new ReadValueId()
      {
        NodeId = dictionaryId,
        AttributeId = 13U,
        IndexRange = (string) null,
        DataEncoding = (QualifiedName) null
      });
    ReadResponse readResponse = await session.ReadAsync((RequestHeader) null, 0.0, TimestampsToReturn.Neither, itemsToRead, ct).ConfigureAwait(false);
    DataValueCollection results = readResponse.Results;
    DiagnosticInfoCollection diagnosticInfos = readResponse.DiagnosticInfos;
    ResponseHeader responseHeader = readResponse.ResponseHeader;
    ClientBase.ValidateResponse((IList) results, (IList) itemsToRead);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) itemsToRead);
    Dictionary<NodeId, byte[]> dictionary1 = new Dictionary<NodeId, byte[]>();
    int index = 0;
    foreach (NodeId dictionaryId in (IEnumerable<NodeId>) dictionaryIds)
    {
      if (StatusCode.IsBad(results[index].StatusCode))
        throw new ServiceResultException(ClientBase.GetResult(results[index].StatusCode, 0, diagnosticInfos, responseHeader));
      dictionary1[dictionaryId] = results[index].Value as byte[];
      ++index;
    }
    IDictionary<NodeId, byte[]> dictionary2 = (IDictionary<NodeId, byte[]>) dictionary1;
    itemsToRead = (ReadValueIdCollection) null;
    return dictionary2;
  }

  public byte[] ReadDictionary(NodeId dictionaryId)
  {
    ReadValueId readValueId = new ReadValueId()
    {
      NodeId = dictionaryId,
      AttributeId = 13,
      IndexRange = (string) null,
      DataEncoding = (QualifiedName) null
    };
    ReadValueIdCollection valueIdCollection1 = new ReadValueIdCollection();
    valueIdCollection1.Add(readValueId);
    ReadValueIdCollection valueIdCollection2 = valueIdCollection1;
    DataValueCollection results;
    DiagnosticInfoCollection diagnosticInfos;
    ResponseHeader responseHeader = this.m_session.Read((RequestHeader) null, 0.0, TimestampsToReturn.Neither, valueIdCollection2, out results, out diagnosticInfos);
    ClientBase.ValidateResponse((IList) results, (IList) valueIdCollection2);
    ClientBase.ValidateDiagnosticInfos(diagnosticInfos, (IList) valueIdCollection2);
    return !StatusCode.IsBad(results[0].StatusCode) ? results[0].Value as byte[] : throw new ServiceResultException(ClientBase.GetResult(results[0].StatusCode, 0, diagnosticInfos, responseHeader));
  }

  internal void Validate(byte[] dictionary, bool throwOnError)
  {
    this.Validate(dictionary, (IDictionary<string, byte[]>) null, throwOnError);
  }

  internal void Validate(byte[] dictionary, IDictionary<string, byte[]> imports = null, bool throwOnError = false)
  {
    MemoryStream memoryStream = new MemoryStream(dictionary);
    if (this.TypeSystemId == (object) 92U)
    {
      XmlSchemaValidator xmlSchemaValidator = new XmlSchemaValidator(imports);
      try
      {
        xmlSchemaValidator.Validate((Stream) memoryStream);
      }
      catch (Exception ex)
      {
        if (throwOnError)
          throw;
        object[] objArray = Array.Empty<object>();
        Utils.LogWarning(ex, "Could not validate XML schema, error is ignored.", objArray);
      }
      this.m_validator = (SchemaValidator) xmlSchemaValidator;
    }
    if (!(this.TypeSystemId == (object) 93U))
      return;
    BinarySchemaValidator binarySchemaValidator = new BinarySchemaValidator(imports);
    try
    {
      binarySchemaValidator.Validate((Stream) memoryStream);
    }
    catch (Exception ex)
    {
      if (throwOnError)
        throw;
      object[] objArray = Array.Empty<object>();
      Utils.LogWarning(ex, "Could not validate binary schema, error is ignored.", objArray);
    }
    this.m_validator = (SchemaValidator) binarySchemaValidator;
    this.TypeDictionary = binarySchemaValidator.Dictionary;
  }
}
