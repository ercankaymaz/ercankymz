using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialProfileSetUsage", 1207)]
public class IfcMaterialProfileSetUsage : IfcMaterialUsageDefinition, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialProfileSetUsage, IIfcMaterialUsageDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcMaterialProfileSetUsage>
{
	private IfcMaterialProfileSet _forProfileSet;

	private IfcCardinalPointReference? _cardinalPoint;

	private IfcPositiveLengthMeasure? _referenceExtent;

	IIfcMaterialProfileSet IIfcMaterialProfileSetUsage.ForProfileSet
	{
		get
		{
			return ForProfileSet;
		}
		set
		{
			ForProfileSet = value as IfcMaterialProfileSet;
		}
	}

	IfcCardinalPointReference? IIfcMaterialProfileSetUsage.CardinalPoint
	{
		get
		{
			return CardinalPoint;
		}
		set
		{
			CardinalPoint = value;
		}
	}

	IfcPositiveLengthMeasure? IIfcMaterialProfileSetUsage.ReferenceExtent
	{
		get
		{
			return ReferenceExtent;
		}
		set
		{
			ReferenceExtent = value;
		}
	}

	[EntityAttribute(1, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 2)]
	public IfcMaterialProfileSet ForProfileSet
	{
		get
		{
			if (_activated)
			{
				return _forProfileSet;
			}
			Activate();
			return _forProfileSet;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMaterialProfileSet v)
			{
				_forProfileSet = v;
			}, _forProfileSet, value, "ForProfileSet", 1);
		}
	}

	[EntityAttribute(2, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 3)]
	public IfcCardinalPointReference? CardinalPoint
	{
		get
		{
			if (_activated)
			{
				return _cardinalPoint;
			}
			Activate();
			return _cardinalPoint;
		}
		set
		{
			SetValue(delegate(IfcCardinalPointReference? v)
			{
				_cardinalPoint = v;
			}, _cardinalPoint, value, "CardinalPoint", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 4)]
	public IfcPositiveLengthMeasure? ReferenceExtent
	{
		get
		{
			if (_activated)
			{
				return _referenceExtent;
			}
			Activate();
			return _referenceExtent;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure? v)
			{
				_referenceExtent = v;
			}, _referenceExtent, value, "ReferenceExtent", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (ForProfileSet != null)
			{
				yield return ForProfileSet;
			}
		}
	}

	internal IfcMaterialProfileSetUsage(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			_forProfileSet = (IfcMaterialProfileSet)value.EntityVal;
			break;
		case 1:
			_cardinalPoint = value.IntegerVal;
			break;
		case 2:
			_referenceExtent = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialProfileSetUsage other)
	{
		return this == other;
	}
}
