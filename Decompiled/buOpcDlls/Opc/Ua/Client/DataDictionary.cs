using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Opc.Ua.Schema;
using Opc.Ua.Schema.Binary;
using Opc.Ua.Schema.Xml;

namespace Opc.Ua.Client;

[DataContract(Namespace = "http://opcfoundation.org/UA/2008/02/Types.xsd")]
[ComVisible(true)]
public class DataDictionary
{
	private ISession m_session;

	private SchemaValidator m_validator;

	public NodeId DictionaryId { get; private set; }

	public string Name { get; private set; }

	public NodeId TypeSystemId { get; private set; }

	public string TypeSystemName { get; private set; }

	public TypeDictionary TypeDictionary { get; private set; }

	public Dictionary<NodeId, QualifiedName> DataTypes { get; private set; }

	public DataDictionary(ISession session)
	{
		Initialize();
		m_session = session;
	}

	private void Initialize()
	{
		m_session = null;
		DataTypes = new Dictionary<NodeId, QualifiedName>();
		m_validator = null;
		TypeSystemId = null;
		TypeSystemName = null;
		DictionaryId = null;
		Name = null;
	}

	public void Load(INode dictionary)
	{
		if (dictionary == null)
		{
			throw new ArgumentNullException("dictionary");
		}
		NodeId dictionaryId = ExpandedNodeId.ToNodeId(dictionary.NodeId, m_session.NamespaceUris);
		Load(dictionaryId, dictionary.ToString());
	}

	public void Load(NodeId dictionaryId, string name, byte[] schema = null, IDictionary<string, byte[]> imports = null)
	{
		if (dictionaryId == null)
		{
			throw new ArgumentNullException("dictionaryId");
		}
		GetTypeSystem(dictionaryId);
		if (schema == null || schema.Length == 0)
		{
			schema = ReadDictionary(dictionaryId);
		}
		if (schema == null || schema.Length == 0)
		{
			throw ServiceResultException.Create(2147549184u, "Cannot parse empty data dictionary.");
		}
		int num = Array.IndexOf(schema, (byte)0);
		if (num >= 0)
		{
			Array.Resize(ref schema, num);
		}
		Validate(schema, imports);
		ReadDataTypes(dictionaryId);
		DictionaryId = dictionaryId;
		Name = name;
	}

	public bool Contains(NodeId descriptionId)
	{
		return DataTypes.ContainsKey(descriptionId);
	}

	public string GetSchema(NodeId descriptionId)
	{
		if (descriptionId != null)
		{
			if (!DataTypes.TryGetValue(descriptionId, out var value))
			{
				return null;
			}
			return m_validator.GetSchema(value.Name);
		}
		return m_validator.GetSchema(null);
	}

	private void GetTypeSystem(NodeId dictionaryId)
	{
		IList<INode> list = m_session.NodeCache.FindReferences(dictionaryId, ReferenceTypeIds.HasComponent, isInverse: true, includeSubtypes: false);
		if (list.Count > 0)
		{
			TypeSystemId = ExpandedNodeId.ToNodeId(list[0].NodeId, m_session.NamespaceUris);
			TypeSystemName = list[0].ToString();
		}
	}

	private void ReadDataTypes(NodeId dictionaryId)
	{
		IList<INode> list = m_session.NodeCache.FindReferences(dictionaryId, ReferenceTypeIds.HasComponent, isInverse: false, includeSubtypes: false);
		IList<NodeId> nodeIds = list.Select((INode node) => ExpandedNodeId.ToNodeId(node.NodeId, m_session.NamespaceUris)).ToList();
		m_session.ReadValues(nodeIds, out var values, out var errors);
		int num = 0;
		foreach (INode item in list)
		{
			NodeId nodeId = ExpandedNodeId.ToNodeId(item.NodeId, m_session.NamespaceUris);
			if (nodeId != null)
			{
				if (ServiceResult.IsGood(errors[num]))
				{
					string name = (string)values[num].Value;
					DataTypes[nodeId] = new QualifiedName(name, nodeId.NamespaceIndex);
				}
				num++;
			}
		}
	}

	public static async Task<IDictionary<NodeId, byte[]>> ReadDictionaries(ISessionClientMethods session, IList<NodeId> dictionaryIds, CancellationToken ct = default(CancellationToken))
	{
		ReadValueIdCollection itemsToRead = new ReadValueIdCollection();
		foreach (NodeId dictionaryId in dictionaryIds)
		{
			ReadValueId item = new ReadValueId
			{
				NodeId = dictionaryId,
				AttributeId = 13u,
				IndexRange = null,
				DataEncoding = null
			};
			itemsToRead.Add(item);
		}
		ReadResponse obj = await session.ReadAsync(null, 0.0, TimestampsToReturn.Neither, itemsToRead, ct).ConfigureAwait(continueOnCapturedContext: false);
		DataValueCollection results = obj.Results;
		DiagnosticInfoCollection diagnosticInfos = obj.DiagnosticInfos;
		ResponseHeader responseHeader = obj.ResponseHeader;
		ClientBase.ValidateResponse(results, itemsToRead);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, itemsToRead);
		Dictionary<NodeId, byte[]> dictionary = new Dictionary<NodeId, byte[]>();
		int num = 0;
		foreach (NodeId dictionaryId2 in dictionaryIds)
		{
			if (StatusCode.IsBad(results[num].StatusCode))
			{
				throw new ServiceResultException(ClientBase.GetResult(results[num].StatusCode, 0, diagnosticInfos, responseHeader));
			}
			dictionary[dictionaryId2] = results[num].Value as byte[];
			num++;
		}
		return dictionary;
	}

	public byte[] ReadDictionary(NodeId dictionaryId)
	{
		ReadValueId item = new ReadValueId
		{
			NodeId = dictionaryId,
			AttributeId = 13u,
			IndexRange = null,
			DataEncoding = null
		};
		ReadValueIdCollection readValueIdCollection = new ReadValueIdCollection { item };
		DataValueCollection results;
		DiagnosticInfoCollection diagnosticInfos;
		ResponseHeader responseHeader = m_session.Read(null, 0.0, TimestampsToReturn.Neither, readValueIdCollection, out results, out diagnosticInfos);
		ClientBase.ValidateResponse(results, readValueIdCollection);
		ClientBase.ValidateDiagnosticInfos(diagnosticInfos, readValueIdCollection);
		if (StatusCode.IsBad(results[0].StatusCode))
		{
			throw new ServiceResultException(ClientBase.GetResult(results[0].StatusCode, 0, diagnosticInfos, responseHeader));
		}
		return results[0].Value as byte[];
	}

	internal void Validate(byte[] dictionary, bool throwOnError)
	{
		Validate(dictionary, null, throwOnError);
	}

	internal void Validate(byte[] dictionary, IDictionary<string, byte[]> imports = null, bool throwOnError = false)
	{
		MemoryStream stream = new MemoryStream(dictionary);
		if (TypeSystemId == 92u)
		{
			XmlSchemaValidator xmlSchemaValidator = new XmlSchemaValidator(imports);
			try
			{
				xmlSchemaValidator.Validate(stream);
			}
			catch (Exception exception)
			{
				if (throwOnError)
				{
					throw;
				}
				Utils.LogWarning(exception, "Could not validate XML schema, error is ignored.");
			}
			m_validator = xmlSchemaValidator;
		}
		if (!(TypeSystemId == 93u))
		{
			return;
		}
		BinarySchemaValidator binarySchemaValidator = new BinarySchemaValidator(imports);
		try
		{
			binarySchemaValidator.Validate(stream);
		}
		catch (Exception exception2)
		{
			if (throwOnError)
			{
				throw;
			}
			Utils.LogWarning(exception2, "Could not validate binary schema, error is ignored.");
		}
		m_validator = binarySchemaValidator;
		TypeDictionary = binarySchemaValidator.Dictionary;
	}
}
