using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Threading;
using System.Xml;

namespace Opc.Ua;

[ComVisible(true)]
public class EncodeableFactory : IEncodeableFactory, ICloneable
{
	private readonly ReaderWriterLockSlim m_readerWriterLockSlim = new ReaderWriterLockSlim();

	private Dictionary<ExpandedNodeId, Type> m_encodeableTypes;

	private static EncodeableFactory s_globalFactory = new EncodeableFactory();

	public static EncodeableFactory GlobalFactory => s_globalFactory;

	public int InstanceId => 0;

	public IReadOnlyDictionary<ExpandedNodeId, Type> EncodeableTypes => m_encodeableTypes;

	public EncodeableFactory()
	{
		m_encodeableTypes = new Dictionary<ExpandedNodeId, Type>();
		AddEncodeableTypes(GetType().GetTypeInfo().Assembly);
	}

	public EncodeableFactory(bool shared)
	{
		m_encodeableTypes = new Dictionary<ExpandedNodeId, Type>();
		AddEncodeableTypes(Utils.DefaultOpcUaCoreAssemblyFullName);
	}

	public EncodeableFactory(IEncodeableFactory factory)
	{
		m_encodeableTypes = new Dictionary<ExpandedNodeId, Type>();
		if (factory != null)
		{
			m_encodeableTypes = ((EncodeableFactory)factory.Clone()).m_encodeableTypes;
		}
	}

	protected virtual void Dispose(bool disposing)
	{
		if (disposing)
		{
			m_readerWriterLockSlim?.Dispose();
		}
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private void AddEncodeableTypes(string assemblyName)
	{
		try
		{
			Assembly assembly = Assembly.Load(new AssemblyName(assemblyName));
			AddEncodeableTypes(assembly);
		}
		catch (Exception)
		{
			Utils.LogError("Could not load encodeable types from assembly: {0}", assemblyName);
		}
	}

	private void AddEncodeableType(Type systemType, Dictionary<string, ExpandedNodeId> unboundTypeIds)
	{
		if (systemType == null || !typeof(IEncodeable).GetTypeInfo().IsAssignableFrom(systemType.GetTypeInfo()) || !(Activator.CreateInstance(systemType) is IEncodeable { TypeId: var expandedNodeId } encodeable))
		{
			return;
		}
		if (!NodeId.IsNull(expandedNodeId))
		{
			if (expandedNodeId.NamespaceUri == "http://opcfoundation.org/UA/")
			{
				expandedNodeId = new ExpandedNodeId(expandedNodeId.InnerNodeId);
			}
			m_encodeableTypes[expandedNodeId] = systemType;
		}
		ExpandedNodeId expandedNodeId2 = encodeable.BinaryEncodingId;
		if (!NodeId.IsNull(expandedNodeId2))
		{
			if (expandedNodeId2.NamespaceUri == "http://opcfoundation.org/UA/")
			{
				expandedNodeId2 = new ExpandedNodeId(expandedNodeId2.InnerNodeId);
			}
			m_encodeableTypes[expandedNodeId2] = systemType;
		}
		try
		{
			expandedNodeId2 = encodeable.XmlEncodingId;
		}
		catch (NotSupportedException)
		{
			expandedNodeId2 = NodeId.Null;
		}
		if (!NodeId.IsNull(expandedNodeId2))
		{
			if (expandedNodeId2.NamespaceUri == "http://opcfoundation.org/UA/")
			{
				expandedNodeId2 = new ExpandedNodeId(expandedNodeId2.InnerNodeId);
			}
			m_encodeableTypes[expandedNodeId2] = systemType;
		}
		ExpandedNodeId value;
		if (encodeable is IJsonEncodeable jsonEncodeable)
		{
			try
			{
				expandedNodeId2 = jsonEncodeable.JsonEncodingId;
			}
			catch (NotSupportedException)
			{
				expandedNodeId2 = NodeId.Null;
			}
			if (!NodeId.IsNull(expandedNodeId2))
			{
				if (expandedNodeId2.NamespaceUri == "http://opcfoundation.org/UA/")
				{
					expandedNodeId2 = new ExpandedNodeId(expandedNodeId2.InnerNodeId);
				}
				m_encodeableTypes[expandedNodeId2] = systemType;
			}
		}
		else if (unboundTypeIds != null && unboundTypeIds.TryGetValue(systemType.Name, out value))
		{
			m_encodeableTypes[value] = systemType;
		}
	}

	public static XmlQualifiedName GetXmlName(Type systemType)
	{
		if (systemType == null)
		{
			return null;
		}
		object[] array = systemType.GetTypeInfo().GetCustomAttributes(typeof(DataContractAttribute), inherit: true).ToArray();
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (array[i] is DataContractAttribute dataContractAttribute)
				{
					if (string.IsNullOrEmpty(dataContractAttribute.Name))
					{
						return new XmlQualifiedName(systemType.Name, dataContractAttribute.Namespace);
					}
					return new XmlQualifiedName(dataContractAttribute.Name, dataContractAttribute.Namespace);
				}
			}
		}
		array = systemType.GetTypeInfo().GetCustomAttributes(typeof(CollectionDataContractAttribute), inherit: true).ToArray();
		if (array != null)
		{
			for (int j = 0; j < array.Length; j++)
			{
				if (array[j] is CollectionDataContractAttribute collectionDataContractAttribute)
				{
					if (string.IsNullOrEmpty(collectionDataContractAttribute.Name))
					{
						return new XmlQualifiedName(systemType.Name, collectionDataContractAttribute.Namespace);
					}
					return new XmlQualifiedName(collectionDataContractAttribute.Name, collectionDataContractAttribute.Namespace);
				}
			}
		}
		if (systemType == typeof(byte[]))
		{
			return new XmlQualifiedName("ByteString");
		}
		return new XmlQualifiedName(systemType.FullName);
	}

	public static XmlQualifiedName GetXmlName(object value, IServiceMessageContext context)
	{
		if (value is IDynamicComplexTypeInstance dynamicComplexTypeInstance)
		{
			XmlQualifiedName xmlName = dynamicComplexTypeInstance.GetXmlName(context);
			if (xmlName != null)
			{
				return xmlName;
			}
		}
		return GetXmlName(value?.GetType());
	}

	public void AddEncodeableType(Type systemType)
	{
		try
		{
			m_readerWriterLockSlim.EnterWriteLock();
			AddEncodeableType(systemType, null);
		}
		finally
		{
			m_readerWriterLockSlim.ExitWriteLock();
		}
	}

	public void AddEncodeableType(ExpandedNodeId encodingId, Type systemType)
	{
		if (systemType != null && !NodeId.IsNull(encodingId))
		{
			try
			{
				m_readerWriterLockSlim.EnterWriteLock();
				m_encodeableTypes[encodingId] = systemType;
			}
			finally
			{
				m_readerWriterLockSlim.ExitWriteLock();
			}
		}
	}

	public void AddEncodeableTypes(Assembly assembly)
	{
		if (!(assembly != null))
		{
			return;
		}
		try
		{
			m_readerWriterLockSlim.EnterWriteLock();
			Type[] exportedTypes = assembly.GetExportedTypes();
			Dictionary<string, ExpandedNodeId> dictionary = new Dictionary<string, ExpandedNodeId>();
			for (int i = 0; i < exportedTypes.Length; i++)
			{
				if (exportedTypes[i].Name != "ObjectIds")
				{
					continue;
				}
				FieldInfo[] fields = exportedTypes[i].GetFields(BindingFlags.Static | BindingFlags.Public);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (!fieldInfo.Name.EndsWith("_Encoding_DefaultJson", StringComparison.Ordinal))
					{
						continue;
					}
					try
					{
						string key = fieldInfo.Name.Substring(0, fieldInfo.Name.Length - "_Encoding_DefaultJson".Length);
						object value = fieldInfo.GetValue(null);
						if (value is NodeId)
						{
							dictionary[key] = new ExpandedNodeId((NodeId)value);
						}
						else
						{
							dictionary[key] = (ExpandedNodeId)value;
						}
					}
					catch (Exception)
					{
					}
				}
			}
			for (int k = 0; k < exportedTypes.Length; k++)
			{
				if (!exportedTypes[k].GetTypeInfo().IsAbstract)
				{
					AddEncodeableType(exportedTypes[k], dictionary);
				}
			}
			dictionary.Clear();
		}
		finally
		{
			m_readerWriterLockSlim.ExitWriteLock();
		}
	}

	public void AddEncodeableTypes(IEnumerable<Type> systemTypes)
	{
		try
		{
			m_readerWriterLockSlim.EnterWriteLock();
			foreach (Type systemType in systemTypes)
			{
				if (!systemType.GetTypeInfo().IsAbstract)
				{
					AddEncodeableType(systemType, null);
				}
			}
		}
		finally
		{
			m_readerWriterLockSlim.ExitWriteLock();
		}
	}

	public Type GetSystemType(ExpandedNodeId typeId)
	{
		try
		{
			m_readerWriterLockSlim.EnterReadLock();
			Type value = null;
			if (NodeId.IsNull(typeId) || !m_encodeableTypes.TryGetValue(typeId, out value))
			{
				return null;
			}
			return value;
		}
		finally
		{
			m_readerWriterLockSlim.ExitReadLock();
		}
	}

	public object Clone()
	{
		return MemberwiseClone();
	}

	public new object MemberwiseClone()
	{
		EncodeableFactory encodeableFactory = new EncodeableFactory(null);
		try
		{
			m_readerWriterLockSlim.EnterReadLock();
			foreach (KeyValuePair<ExpandedNodeId, Type> encodeableType in m_encodeableTypes)
			{
				encodeableFactory.m_encodeableTypes.Add(encodeableType.Key, encodeableType.Value);
			}
			return encodeableFactory;
		}
		finally
		{
			m_readerWriterLockSlim.ExitReadLock();
		}
	}
}
