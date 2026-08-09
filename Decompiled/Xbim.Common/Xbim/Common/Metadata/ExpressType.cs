using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Xbim.Common.Metadata;

public class ExpressType
{
	private readonly SortedList<int, ExpressMetaProperty> _properties = new SortedList<int, ExpressMetaProperty>();

	private readonly List<ExpressMetaProperty> _inverses = new List<ExpressMetaProperty>();

	private readonly List<ExpressMetaProperty> _derives = new List<ExpressMetaProperty>();

	private readonly List<ExpressType> _subTypes = new List<ExpressType>();

	private List<ExpressType> _nonAbstractSubTypes;

	private readonly List<ExpressMetaProperty> _expressEnumerableProperties = new List<ExpressMetaProperty>();

	private readonly string _expressName;

	private readonly short _typeId;

	private readonly List<PropertyInfo> _indexedProperties;

	private readonly List<int> _indexedValues;

	private readonly string _expressNameUpper;

	private readonly Type _underlyingType;

	private readonly Type _underlyingComplexType;

	public ExpressType SuperType { get; internal set; }

	public bool IndexedClass { get; private set; }

	public string ExpressName => _expressName;

	public string ExpressNameUpper => _expressNameUpper;

	public short TypeId => _typeId;

	public IEnumerable<ExpressMetaProperty> Inverses => _inverses;

	public IEnumerable<ExpressMetaProperty> Derives => _derives;

	public SortedList<int, ExpressMetaProperty> Properties => _properties;

	public Type Type { get; private set; }

	public IEnumerable<ExpressMetaProperty> ExpressEnumerableProperties => _expressEnumerableProperties;

	public IEnumerable<ExpressType> NonAbstractSubTypes
	{
		get
		{
			lock (this)
			{
				if (_nonAbstractSubTypes != null)
				{
					return _nonAbstractSubTypes;
				}
				_nonAbstractSubTypes = new List<ExpressType>();
				AddNonAbstractTypes(this, _nonAbstractSubTypes);
			}
			return _nonAbstractSubTypes;
		}
	}

	public IEnumerable<PropertyInfo> IndexedProperties
	{
		get
		{
			IEnumerable<PropertyInfo> indexedProperties = _indexedProperties;
			return indexedProperties ?? Enumerable.Empty<PropertyInfo>();
		}
	}

	public IList<int> IndexedValues => _indexedValues;

	public bool HasIndexedAttribute
	{
		get
		{
			if (IndexedValues != null)
			{
				return _indexedValues.Count > 0;
			}
			return false;
		}
	}

	public string Name => Type.Name;

	public List<ExpressType> SubTypes => _subTypes;

	public IEnumerable<ExpressType> AllSubTypes
	{
		get
		{
			if (_subTypes == null)
			{
				yield break;
			}
			foreach (ExpressType type in _subTypes)
			{
				yield return type;
				foreach (ExpressType allSubType in type.AllSubTypes)
				{
					yield return allSubType;
				}
			}
		}
	}

	public Type UnderlyingType => _underlyingType;

	public Type UnderlyingComplexType => _underlyingComplexType;

	public ExpressType(Type type)
	{
		Type = type;
		TypeInfo typeInfo = Type.GetTypeInfo();
		object obj = typeInfo.GetCustomAttributes(typeof(ExpressTypeAttribute), inherit: false).FirstOrDefault();
		if (obj == null)
		{
			throw new Exception("Express Type is not defined for " + Type.Name);
		}
		_typeId = (short)((ExpressTypeAttribute)obj).EntityTypeId;
		_expressName = ((ExpressTypeAttribute)obj).Name;
		_expressNameUpper = _expressName.ToUpperInvariant();
		IndexedClass = false;
		if (typeInfo.GetCustomAttributes(typeof(DefinedTypeAttribute), inherit: false).FirstOrDefault() is DefinedTypeAttribute definedTypeAttribute)
		{
			_underlyingType = definedTypeAttribute.UnderlyingType;
			if (UnderlyingType.GetTypeInfo().IsGenericType && typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(UnderlyingType))
			{
				Type type2 = UnderlyingType.GetTypeInfo().GetGenericArguments()[0];
				if (type2 != null)
				{
					_underlyingComplexType = type2;
				}
			}
		}
		PropertyInfo[] properties = typeInfo.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy);
		foreach (PropertyInfo propertyInfo in properties)
		{
			EntityAttributeAttribute entityAttributeAttribute = ((EntityAttributeAttribute[])propertyInfo.GetCustomAttributes(typeof(EntityAttributeAttribute), inherit: false)).FirstOrDefault();
			if (entityAttributeAttribute == null)
			{
				continue;
			}
			ExpressMetaProperty expressMetaProperty = new ExpressMetaProperty
			{
				PropertyInfo = propertyInfo,
				EntityAttribute = entityAttributeAttribute
			};
			if (entityAttributeAttribute.Order > 0)
			{
				_properties.Add(entityAttributeAttribute.Order, expressMetaProperty);
			}
			else if (entityAttributeAttribute.State == EntityAttributeState.Derived)
			{
				_derives.Add(expressMetaProperty);
			}
			else
			{
				InverseProperty inverseAttributeProperty = propertyInfo.GetCustomAttributes(typeof(InverseProperty), inherit: false).First() as InverseProperty;
				expressMetaProperty.InverseAttributeProperty = inverseAttributeProperty;
				_inverses.Add(expressMetaProperty);
			}
			if (propertyInfo.PropertyType.GetTypeInfo().IsGenericType && typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(propertyInfo.PropertyType))
			{
				Type type3 = propertyInfo.PropertyType;
				while (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(type3))
				{
					Type[] genericArguments = type3.GetTypeInfo().GetGenericArguments();
					if (!genericArguments.Any())
					{
						break;
					}
					type3 = genericArguments[0];
				}
				expressMetaProperty.EnumerableType = type3;
			}
			if (expressMetaProperty.IsIndexed = propertyInfo.GetCustomAttributes(typeof(IndexedProperty), inherit: false).Any())
			{
				if (_indexedProperties == null)
				{
					_indexedProperties = new List<PropertyInfo>();
				}
				if (_indexedValues == null)
				{
					_indexedValues = new List<int>();
				}
				_indexedProperties.Add(propertyInfo);
				_indexedValues.Add(entityAttributeAttribute.Order);
				IndexedClass = true;
			}
		}
		foreach (ExpressMetaProperty item in _properties.Values.Where((ExpressMetaProperty prop) => typeof(IExpressEnumerable).GetTypeInfo().IsAssignableFrom(prop.PropertyInfo.PropertyType)))
		{
			_expressEnumerableProperties.Add(item);
		}
	}

	public override string ToString()
	{
		return Type.Name;
	}

	public IEnumerable<int> GetIndexedValues(IPersistEntity ent)
	{
		if (IndexedProperties == null)
		{
			return Enumerable.Empty<int>();
		}
		HashSet<int> hashSet = new HashSet<int>();
		foreach (PropertyInfo indexedProperty in IndexedProperties)
		{
			object value = indexedProperty.GetValue(ent, null);
			if (value == null || value is IOptionalItemSet { Initialized: false })
			{
				continue;
			}
			if (value is IPersistEntity { EntityLabel: var entityLabel })
			{
				hashSet.Add(entityLabel);
			}
			else
			{
				if (!(value is IExpressEnumerable) || value == null)
				{
					continue;
				}
				foreach (object item in (IExpressEnumerable)value)
				{
					if (item != null)
					{
						int entityLabel2 = ((IPersistEntity)item).EntityLabel;
						hashSet.Add(entityLabel2);
					}
				}
			}
		}
		return hashSet;
	}

	private static void AddNonAbstractTypes(ExpressType expressType, ICollection<ExpressType> nonAbstractTypes)
	{
		if (!expressType.Type.GetTypeInfo().IsAbstract)
		{
			nonAbstractTypes.Add(expressType);
		}
		foreach (ExpressType subType in expressType._subTypes)
		{
			AddNonAbstractTypes(subType, nonAbstractTypes);
		}
	}

	public bool IsIndexedAttribute(int attributeIndex)
	{
		if (IndexedValues != null)
		{
			return IndexedValues.Contains(attributeIndex);
		}
		return false;
	}
}
