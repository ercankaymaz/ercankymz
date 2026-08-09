using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc4.MaterialResource;

[ExpressType("IfcMaterialProfileSetUsageTapering", 1208)]
public class IfcMaterialProfileSetUsageTapering : IfcMaterialProfileSetUsage, IInstantiableEntity, IPersistEntity, IPersist, IIfcMaterialProfileSetUsageTapering, IIfcMaterialProfileSetUsage, IIfcMaterialUsageDefinition, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcMaterialProfileSetUsageTapering>
{
	private IfcMaterialProfileSet _forProfileEndSet;

	private IfcCardinalPointReference? _cardinalEndPoint;

	IIfcMaterialProfileSet IIfcMaterialProfileSetUsageTapering.ForProfileEndSet
	{
		get
		{
			return ForProfileEndSet;
		}
		set
		{
			ForProfileEndSet = value as IfcMaterialProfileSet;
		}
	}

	IfcCardinalPointReference? IIfcMaterialProfileSetUsageTapering.CardinalEndPoint
	{
		get
		{
			return CardinalEndPoint;
		}
		set
		{
			CardinalEndPoint = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcMaterialProfileSet ForProfileEndSet
	{
		get
		{
			if (_activated)
			{
				return _forProfileEndSet;
			}
			Activate();
			return _forProfileEndSet;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcMaterialProfileSet v)
			{
				_forProfileEndSet = v;
			}, _forProfileEndSet, value, "ForProfileEndSet", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Optional, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcCardinalPointReference? CardinalEndPoint
	{
		get
		{
			if (_activated)
			{
				return _cardinalEndPoint;
			}
			Activate();
			return _cardinalEndPoint;
		}
		set
		{
			SetValue(delegate(IfcCardinalPointReference? v)
			{
				_cardinalEndPoint = v;
			}, _cardinalEndPoint, value, "CardinalEndPoint", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.ForProfileSet != null)
			{
				yield return base.ForProfileSet;
			}
			if (ForProfileEndSet != null)
			{
				yield return ForProfileEndSet;
			}
		}
	}

	internal IfcMaterialProfileSetUsageTapering(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
		case 1:
		case 2:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 3:
			_forProfileEndSet = (IfcMaterialProfileSet)value.EntityVal;
			break;
		case 4:
			_cardinalEndPoint = value.IntegerVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcMaterialProfileSetUsageTapering other)
	{
		return this == other;
	}
}
