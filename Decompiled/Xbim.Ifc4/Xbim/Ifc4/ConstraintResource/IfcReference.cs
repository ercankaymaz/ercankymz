using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ConstraintResource;

[ExpressType("IfcReference", 1244)]
public class IfcReference : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, IIfcReference, IfcAppliedValueSelect, IIfcAppliedValueSelect, IExpressSelectType, IfcMetricValueSelect, IIfcMetricValueSelect, IContainsEntityReferences, IEquatable<IfcReference>
{
	private IfcIdentifier? _typeIdentifier;

	private IfcIdentifier? _attributeIdentifier;

	private IfcLabel? _instanceName;

	private readonly OptionalItemSet<IfcInteger> _listPositions;

	private IfcReference _innerReference;

	IfcIdentifier? IIfcReference.TypeIdentifier
	{
		get
		{
			return TypeIdentifier;
		}
		set
		{
			TypeIdentifier = value;
		}
	}

	IfcIdentifier? IIfcReference.AttributeIdentifier
	{
		get
		{
			return AttributeIdentifier;
		}
		set
		{
			AttributeIdentifier = value;
		}
	}

	IfcLabel? IIfcReference.InstanceName
	{
		get
		{
			return InstanceName;
		}
		set
		{
			InstanceName = value;
		}
	}

	IItemSet<IfcInteger> IIfcReference.ListPositions => ListPositions;

	IIfcReference IIfcReference.InnerReference
	{
		get
		{
			return InnerReference;
		}
		set
		{
			InnerReference = value as IfcReference;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public IfcIdentifier? TypeIdentifier
	{
		get
		{
			if (_activated)
			{
				return _typeIdentifier;
			}
			Activate();
			return _typeIdentifier;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_typeIdentifier = v;
			}, _typeIdentifier, value, "TypeIdentifier", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public IfcIdentifier? AttributeIdentifier
	{
		get
		{
			if (_activated)
			{
				return _attributeIdentifier;
			}
			Activate();
			return _attributeIdentifier;
		}
		set
		{
			SetValue(delegate(IfcIdentifier? v)
			{
				_attributeIdentifier = v;
			}, _attributeIdentifier, value, "AttributeIdentifier", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcLabel? InstanceName
	{
		get
		{
			if (_activated)
			{
				return _instanceName;
			}
			Activate();
			return _instanceName;
		}
		set
		{
			SetValue(delegate(IfcLabel? v)
			{
				_instanceName = v;
			}, _instanceName, value, "InstanceName", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 4)]
	public IOptionalItemSet<IfcInteger> ListPositions
	{
		get
		{
			if (_activated)
			{
				return _listPositions;
			}
			Activate();
			return _listPositions;
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcReference InnerReference
	{
		get
		{
			if (_activated)
			{
				return _innerReference;
			}
			Activate();
			return _innerReference;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcReference v)
			{
				_innerReference = v;
			}, _innerReference, value, "InnerReference", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (InnerReference != null)
			{
				yield return InnerReference;
			}
		}
	}

	internal IfcReference(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_listPositions = new OptionalItemSet<IfcInteger>(this, 0, 4);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_typeIdentifier = value.StringVal;
			break;
		case 1:
			_attributeIdentifier = value.StringVal;
			break;
		case 2:
			_instanceName = value.StringVal;
			break;
		case 3:
			_listPositions.InternalAdd(value.IntegerVal);
			break;
		case 4:
			_innerReference = (IfcReference)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReference other)
	{
		return this == other;
	}
}
