using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Collections;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.QuantityResource;

[ExpressType("IfcPhysicalComplexQuantity", 604)]
public class IfcPhysicalComplexQuantity : IfcPhysicalQuantity, IIfcPhysicalComplexQuantity, IIfcPhysicalQuantity, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IContainsIndexedReferences, IEquatable<IfcPhysicalComplexQuantity>
{
	private readonly ItemSet<IfcPhysicalQuantity> _hasQuantities;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel _discrimination;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _quality;

	private Xbim.Ifc4x3.MeasureResource.IfcLabel? _usage;

	[CrossSchemaAttribute(typeof(IIfcPhysicalComplexQuantity), 3)]
	IItemSet<IIfcPhysicalQuantity> IIfcPhysicalComplexQuantity.HasQuantities => new ProxyItemSet<IfcPhysicalQuantity, IIfcPhysicalQuantity>(HasQuantities);

	[CrossSchemaAttribute(typeof(IIfcPhysicalComplexQuantity), 4)]
	Xbim.Ifc4.MeasureResource.IfcLabel IIfcPhysicalComplexQuantity.Discrimination
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Discrimination);
		}
		set
		{
			Discrimination = new Xbim.Ifc4x3.MeasureResource.IfcLabel(value);
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPhysicalComplexQuantity), 5)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcPhysicalComplexQuantity.Quality
	{
		get
		{
			if (!Quality.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Quality.Value);
		}
		set
		{
			Quality = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[CrossSchemaAttribute(typeof(IIfcPhysicalComplexQuantity), 6)]
	Xbim.Ifc4.MeasureResource.IfcLabel? IIfcPhysicalComplexQuantity.Usage
	{
		get
		{
			if (!Usage.HasValue)
			{
				return null;
			}
			return new Xbim.Ifc4.MeasureResource.IfcLabel(Usage.Value);
		}
		set
		{
			Usage = (value.HasValue ? new Xbim.Ifc4x3.MeasureResource.IfcLabel?(new Xbim.Ifc4x3.MeasureResource.IfcLabel(value.Value)) : ((Xbim.Ifc4x3.MeasureResource.IfcLabel?)null));
		}
	}

	[IndexedProperty]
	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { -1 }, 5)]
	public IItemSet<IfcPhysicalQuantity> HasQuantities
	{
		get
		{
			if (_activated)
			{
				return _hasQuantities;
			}
			Activate();
			return _hasQuantities;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel Discrimination
	{
		get
		{
			if (_activated)
			{
				return _discrimination;
			}
			Activate();
			return _discrimination;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel v)
			{
				_discrimination = v;
			}, _discrimination, value, "Discrimination", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Quality
	{
		get
		{
			if (_activated)
			{
				return _quality;
			}
			Activate();
			return _quality;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_quality = v;
			}, _quality, value, "Quality", 5);
		}
	}

	[EntityAttribute(6, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 8)]
	public Xbim.Ifc4x3.MeasureResource.IfcLabel? Usage
	{
		get
		{
			if (_activated)
			{
				return _usage;
			}
			Activate();
			return _usage;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcLabel? v)
			{
				_usage = v;
			}, _usage, value, "Usage", 6);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcPhysicalQuantity hasQuantity in HasQuantities)
			{
				yield return hasQuantity;
			}
		}
	}

	IEnumerable<IPersistEntity> IContainsIndexedReferences.IndexedReferences
	{
		get
		{
			foreach (IfcPhysicalQuantity hasQuantity in HasQuantities)
			{
				yield return hasQuantity;
			}
		}
	}

	internal IfcPhysicalComplexQuantity(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
		_hasQuantities = new ItemSet<IfcPhysicalQuantity>(this, 0, 3);
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 2:
			_hasQuantities.InternalAdd((IfcPhysicalQuantity)value.EntityVal);
			break;
		case 3:
			_discrimination = value.StringVal;
			break;
		case 4:
			_quality = value.StringVal;
			break;
		case 5:
			_usage = value.StringVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcPhysicalComplexQuantity other)
	{
		return this == other;
	}
}
