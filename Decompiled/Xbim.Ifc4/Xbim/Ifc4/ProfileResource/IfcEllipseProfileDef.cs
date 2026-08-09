using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcEllipseProfileDef", 285)]
public class IfcEllipseProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcEllipseProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcEllipseProfileDef>
{
	private IfcPositiveLengthMeasure _semiAxis1;

	private IfcPositiveLengthMeasure _semiAxis2;

	IfcPositiveLengthMeasure IIfcEllipseProfileDef.SemiAxis1
	{
		get
		{
			return SemiAxis1;
		}
		set
		{
			SemiAxis1 = value;
		}
	}

	IfcPositiveLengthMeasure IIfcEllipseProfileDef.SemiAxis2
	{
		get
		{
			return SemiAxis2;
		}
		set
		{
			SemiAxis2 = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure SemiAxis1
	{
		get
		{
			if (_activated)
			{
				return _semiAxis1;
			}
			Activate();
			return _semiAxis1;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_semiAxis1 = v;
			}, _semiAxis1, value, "SemiAxis1", 4);
		}
	}

	[EntityAttribute(5, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public IfcPositiveLengthMeasure SemiAxis2
	{
		get
		{
			if (_activated)
			{
				return _semiAxis2;
			}
			Activate();
			return _semiAxis2;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_semiAxis2 = v;
			}, _semiAxis2, value, "SemiAxis2", 5);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Position != null)
			{
				yield return base.Position;
			}
		}
	}

	internal IfcEllipseProfileDef(IModel model, int label, bool activated)
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
			_semiAxis1 = value.RealVal;
			break;
		case 4:
			_semiAxis2 = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEllipseProfileDef other)
	{
		return this == other;
	}
}
