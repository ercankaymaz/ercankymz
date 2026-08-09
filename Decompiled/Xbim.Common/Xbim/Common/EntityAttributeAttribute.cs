using System;

namespace Xbim.Common;

[AttributeUsage(AttributeTargets.Property)]
public sealed class EntityAttributeAttribute : Attribute
{
	private readonly EntityAttributeState _state;

	private readonly EntityAttributeType _entityType;

	private readonly int _order;

	private readonly int _globalOrder;

	private readonly int[] _maxCardinality;

	private readonly int[] _minCardinality;

	private readonly EntityAttributeType _memberType;

	public EntityAttributeState State => _state;

	public EntityAttributeType EntityType => _entityType;

	public int Order => _order;

	public int[] MinCardinality => _minCardinality;

	public int[] MaxCardinality => _maxCardinality;

	public EntityAttributeType MemberType => _memberType;

	public bool IsEnumerable
	{
		get
		{
			if (_entityType != EntityAttributeType.Array && _entityType != EntityAttributeType.ArrayUnique && _entityType != EntityAttributeType.Bag && _entityType != EntityAttributeType.List && _entityType != EntityAttributeType.ListUnique)
			{
				return _entityType == EntityAttributeType.Set;
			}
			return true;
		}
	}

	public string ListType => _entityType switch
	{
		EntityAttributeType.Set => "set", 
		EntityAttributeType.List => "list", 
		EntityAttributeType.ListUnique => "list-unique", 
		_ => "", 
	};

	public bool IsSet => _entityType == EntityAttributeType.Set;

	public bool IsList
	{
		get
		{
			if (_entityType != EntityAttributeType.List)
			{
				return _entityType == EntityAttributeType.ListUnique;
			}
			return true;
		}
	}

	public bool IsClass => _entityType == EntityAttributeType.Class;

	public bool IsDerivedOverride => _state == EntityAttributeState.DerivedOverride;

	public bool IsDerived
	{
		get
		{
			if (_state != EntityAttributeState.DerivedOverride)
			{
				return _state == EntityAttributeState.Derived;
			}
			return true;
		}
	}

	public bool IsValueType => _entityType > EntityAttributeType.List;

	public bool IsMemberValueType => _memberType > EntityAttributeType.List;

	public bool IsMemberClass => _memberType == EntityAttributeType.Class;

	public bool IsOptional => _state == EntityAttributeState.Optional;

	public bool IsMandatory => _state == EntityAttributeState.Mandatory;

	public int GlobalOrder => _globalOrder;

	public EntityAttributeAttribute(int order, EntityAttributeState state, EntityAttributeType entityType, EntityAttributeType memberType, int[] minCardinality, int[] maxCardinality, int globalOrder)
	{
		_state = state;
		_order = order;
		_entityType = entityType;
		_memberType = memberType;
		_minCardinality = minCardinality;
		_maxCardinality = maxCardinality;
		_globalOrder = globalOrder;
	}
}
