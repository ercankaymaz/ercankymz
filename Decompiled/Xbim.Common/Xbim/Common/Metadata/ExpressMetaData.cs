using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Xbim.Common.Exceptions;
using Xbim.Common.Step21;

namespace Xbim.Common.Metadata;

public class ExpressMetaData
{
	public readonly Module Module;

	private readonly Dictionary<short, ExpressType> _typeIdToExpressTypeLookup;

	private readonly ExpressTypeDictionary _typeToExpressTypeLookup;

	private readonly Dictionary<string, ExpressType> _typeNameToExpressTypeLookup;

	private readonly Dictionary<string, ExpressType> _persistNameToExpressTypeLookup;

	private readonly Dictionary<Type, List<ExpressType>> _interfaceToExpressTypesLookup;

	private static readonly ConcurrentDictionary<Module, ExpressMetaData> ModuleCache = new ConcurrentDictionary<Module, ExpressMetaData>();

	private static readonly ConcurrentDictionary<XbimSchemaVersion, ExpressMetaData> SchemaCache = new ConcurrentDictionary<XbimSchemaVersion, ExpressMetaData>();

	[Obsolete("Prefer ExpressMetaData GetMetadata(IEntityFactory) overload")]
	public static ExpressMetaData GetMetadata(Module module)
	{
		return ModuleCache.GetOrAdd(module, (Module m) => new ExpressMetaData(m));
	}

	public static ExpressMetaData GetMetadata(IEntityFactory entityFactory)
	{
		if (entityFactory == null)
		{
			throw new ArgumentNullException("entityFactory");
		}
		return SchemaCache.GetOrAdd(entityFactory.SchemaVersion, (XbimSchemaVersion f) => new ExpressMetaData(entityFactory));
	}

	private ExpressMetaData(Module module)
	{
		Module = module;
		List<Type> list = (from t in module.GetTypes()
			where IsExpressTypeForSchema(t)
			select t).ToList();
		_typeIdToExpressTypeLookup = new Dictionary<short, ExpressType>(list.Count);
		_typeNameToExpressTypeLookup = new Dictionary<string, ExpressType>(list.Count);
		_persistNameToExpressTypeLookup = new Dictionary<string, ExpressType>(list.Count);
		_typeToExpressTypeLookup = new ExpressTypeDictionary();
		_interfaceToExpressTypesLookup = new Dictionary<Type, List<ExpressType>>();
		RegisterTypes(list);
	}

	private ExpressMetaData(IEntityFactory factory)
	{
		Module = factory.GetType().Module;
		string schemaNamespace = factory.GetType().Namespace;
		List<Type> list = (from t in Module.GetTypes()
			where IsExpressTypeForSchema(t, schemaNamespace)
			select t).ToList();
		_typeIdToExpressTypeLookup = new Dictionary<short, ExpressType>(list.Count);
		_typeNameToExpressTypeLookup = new Dictionary<string, ExpressType>(list.Count);
		_persistNameToExpressTypeLookup = new Dictionary<string, ExpressType>(list.Count);
		_typeToExpressTypeLookup = new ExpressTypeDictionary();
		_interfaceToExpressTypesLookup = new Dictionary<Type, List<ExpressType>>();
		RegisterTypes(list);
	}

	internal static bool IsExpressTypeForSchema(Type type, string schemaNamespace = "")
	{
		if (type == null || type.Namespace == null)
		{
			return false;
		}
		if (string.IsNullOrWhiteSpace(schemaNamespace))
		{
			return IsExpressType(type);
		}
		string text = type.Namespace;
		if (!text.StartsWith(schemaNamespace, StringComparison.Ordinal))
		{
			return false;
		}
		if (text.Length == schemaNamespace.Length)
		{
			return IsExpressType(type);
		}
		if (text.Length > schemaNamespace.Length && text[schemaNamespace.Length] == '.')
		{
			return IsExpressType(type);
		}
		return false;
	}

	private static bool IsExpressType(Type type)
	{
		if (!typeof(IPersist).IsAssignableFrom(type))
		{
			return false;
		}
		if (!type.IsPublic || type.IsEnum || type.IsInterface)
		{
			return false;
		}
		if (!Attribute.IsDefined(type, typeof(ExpressTypeAttribute), inherit: false))
		{
			return false;
		}
		if (typeof(IExpressHeaderType).IsAssignableFrom(type))
		{
			return false;
		}
		return true;
	}

	private void RegisterTypes(IList<Type> typesToProcess)
	{
		foreach (Type item in typesToProcess)
		{
			try
			{
				if (!_typeToExpressTypeLookup.TryGetValue(item, out var value))
				{
					value = new ExpressType(item);
				}
				string key = item.Name.ToUpperInvariant();
				if (!_typeNameToExpressTypeLookup.ContainsKey(key))
				{
					_typeNameToExpressTypeLookup.Add(key, value);
				}
				if (typeof(IPersistEntity).GetTypeInfo().IsAssignableFrom(item))
				{
					_persistNameToExpressTypeLookup.Add(value.ExpressNameUpper, value);
					_typeIdToExpressTypeLookup.Add(value.TypeId, value);
				}
				if (!_typeToExpressTypeLookup.ContainsKey(value.Type))
				{
					_typeToExpressTypeLookup.Add(value.Type, value);
					AddParent(value);
				}
				Type[] interfaces = item.GetTypeInfo().GetInterfaces();
				foreach (Type type in interfaces)
				{
					if (type.Namespace == null || type.Namespace.StartsWith("Xbim"))
					{
						if (!_interfaceToExpressTypesLookup.ContainsKey(type))
						{
							_interfaceToExpressTypesLookup.Add(type, new List<ExpressType>());
						}
						_interfaceToExpressTypesLookup[type].Add(value);
					}
				}
			}
			catch (Exception inner)
			{
				throw new XbimException("Error reading Entity Meta Data for entity " + item.FullName, inner);
			}
		}
	}

	internal void AddParent(ExpressType child)
	{
		Type baseType = child.Type.GetTypeInfo().BaseType;
		if (baseType == null || typeof(object) == baseType || typeof(ValueType) == baseType || typeof(PersistEntity) == baseType)
		{
			return;
		}
		if (!_typeToExpressTypeLookup.ContainsKey(baseType))
		{
			ExpressType expressType;
			_typeToExpressTypeLookup.Add(baseType, expressType = new ExpressType(baseType));
			string key = baseType.Name.ToUpperInvariant();
			if (!_typeNameToExpressTypeLookup.ContainsKey(key))
			{
				_typeNameToExpressTypeLookup.Add(key, expressType);
			}
			expressType.SubTypes.Add(child);
			child.SuperType = expressType;
			AddParent(expressType);
		}
		else
		{
			ExpressType expressType = (child.SuperType = _typeToExpressTypeLookup[baseType]);
			if (!expressType.SubTypes.Contains(child))
			{
				expressType.SubTypes.Add(child);
			}
		}
	}

	public IEnumerable<ExpressType> Types()
	{
		return _typeNameToExpressTypeLookup.Values;
	}

	public ExpressType ExpressType(string typeName)
	{
		if (_typeNameToExpressTypeLookup.TryGetValue(typeName, out var value))
		{
			return value;
		}
		if (_persistNameToExpressTypeLookup.TryGetValue(typeName, out value))
		{
			return value;
		}
		return null;
	}

	public IEnumerable<ExpressType> ExpressTypesImplementing(Type type)
	{
		if (_interfaceToExpressTypesLookup.TryGetValue(type, out var value))
		{
			return value;
		}
		return Enumerable.Empty<ExpressType>();
	}

	public IEnumerable<ExpressType> TypesImplementing(Type type)
	{
		if (!_interfaceToExpressTypesLookup.TryGetValue(type, out var value))
		{
			return Enumerable.Empty<ExpressType>();
		}
		return value;
	}

	public IEnumerable<ExpressType> TypesImplementing(string stringType)
	{
		ExpressType expressType = ExpressType(stringType);
		if (expressType == null)
		{
			return Enumerable.Empty<ExpressType>();
		}
		if (!_interfaceToExpressTypesLookup.TryGetValue(expressType.Type, out var value))
		{
			return Enumerable.Empty<ExpressType>();
		}
		return value;
	}

	public IEnumerable<short> NonAbstractSubTypes(Type type)
	{
		if (type.GetTypeInfo().IsInterface)
		{
			if (!_interfaceToExpressTypesLookup.TryGetValue(type, out var value))
			{
				return Enumerable.Empty<short>();
			}
			return from t in value
				where !t.Type.GetTypeInfo().IsAbstract
				select t.TypeId;
		}
		ExpressType expressType = ExpressType(type);
		if (expressType != null)
		{
			return expressType.NonAbstractSubTypes.Select((ExpressType t) => t.TypeId);
		}
		return Enumerable.Empty<short>();
	}

	public ExpressType ExpressType(Type type)
	{
		if (!_typeToExpressTypeLookup.TryGetValue(type, out var value))
		{
			return null;
		}
		return value;
	}

	public ExpressType ExpressType(short typeId)
	{
		return _typeIdToExpressTypeLookup[typeId];
	}

	public short ExpressTypeId(Type type)
	{
		return _typeToExpressTypeLookup[type].TypeId;
	}

	public short ExpressTypeId(string typeName)
	{
		return ExpressType(typeName).TypeId;
	}

	public short ExpressTypeId(IPersist entity)
	{
		return _typeToExpressTypeLookup[entity.GetType()].TypeId;
	}

	public Type GetType(short typeId)
	{
		return ExpressType(typeId).Type;
	}

	public ExpressType ExpressType(IPersist entity)
	{
		return ExpressType(entity.GetType());
	}

	public bool TryGetExpressType(string typeName, out ExpressType expressType)
	{
		if (!_typeNameToExpressTypeLookup.TryGetValue(typeName, out expressType))
		{
			return _persistNameToExpressTypeLookup.TryGetValue(typeName, out expressType);
		}
		return true;
	}

	public bool IsIndexedEntityAttribute(string entityTypeName, int attributeIndex)
	{
		return ExpressType(entityTypeName).IsIndexedAttribute(attributeIndex);
	}
}
