using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ConstraintResource;
using Xbim.Ifc4.CostResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.CostResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.ConstraintResource;

[ExpressType("IfcReference", 1244)]
public class IfcReference : PersistEntity, IInstantiableEntity, IPersistEntity, IPersist, Xbim.Ifc4x3.CostResource.IfcAppliedValueSelect, IExpressSelectType, IfcMetricValueSelect, IContainsEntityReferences, IEquatable<IfcReference>, IIfcReference, Xbim.Ifc4.CostResource.IfcAppliedValueSelect, IIfcAppliedValueSelect, Xbim.Ifc4.ConstraintResource.IfcMetricValueSelect, IIfcMetricValueSelect
{
	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _typeIdentifier;

	private Xbim.Ifc4x3.MeasureResource.IfcIdentifier? _attributeIdentifier;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _instanceName;

	private readonly OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> _listPositions;

	private IfcReference _innerReference;

	[EntityAttribute(1, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 1)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? TypeIdentifier
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_typeIdentifier = v;
			}, _typeIdentifier, value, "TypeIdentifier", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 2)]
	public Xbim.Ifc4x3.MeasureResource.IfcIdentifier? AttributeIdentifier
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcIdentifier? v)
			{
				_attributeIdentifier = v;
			}, _attributeIdentifier, value, "AttributeIdentifier", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? InstanceName
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
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_instanceName = v;
			}, _instanceName, value, "InstanceName", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Optional, EntityAttributeType.List, EntityAttributeType.None, new int[] { 1 }, new int[] { -1 }, 4)]
	public IOptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger> ListPositions
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

	[CrossSchemaAttribute(typeof(IIfcReference), 1)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcReference.TypeIdentifier
	{
		get
		{
			if (!TypeIdentifier.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(TypeIdentifier.Value);
		}
		set
		{
			TypeIdentifier = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReference), 2)]
	Xbim.Ifc4.MeasureResource.IfcIdentifier? IIfcReference.AttributeIdentifier
	{
		get
		{
			if (!AttributeIdentifier.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcIdentifier(AttributeIdentifier.Value);
		}
		set
		{
			AttributeIdentifier = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcIdentifier?(new Xbim.Ifc4x3.MeasureResource.IfcIdentifier(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcIdentifier?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReference), 3)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcReference.InstanceName
	{
		get
		{
			if (!InstanceName.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(InstanceName.Value);
		}
		set
		{
			InstanceName = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReference), 4)]
	IItemSet<Xbim.Ifc4.MeasureResource.IfcInteger> IIfcReference.ListPositions => new ProxyValueSet<Xbim.Ifc4x3.MeasureResource.IfcInteger, Xbim.Ifc4.MeasureResource.IfcInteger>(ListPositions, (Xbim.Ifc4x3.MeasureResource.IfcInteger s) => new Xbim.Ifc4.MeasureResource.IfcInteger(s), (Xbim.Ifc4.MeasureResource.IfcInteger t) => new Xbim.Ifc4x3.MeasureResource.IfcInteger(t));

	[CrossSchemaAttribute(typeof(IIfcReference), 5)]
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

	internal IfcReference(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_listPositions = new OptionalItemSet<Xbim.Ifc4x3.MeasureResource.IfcInteger>(this, 0, 4);
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
