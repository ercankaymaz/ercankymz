using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcCenterLineProfileDef", 353)]
public class IfcCenterLineProfileDef : IfcArbitraryOpenProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcCenterLineProfileDef, IIfcArbitraryOpenProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCenterLineProfileDef>
{
	private IfcPositiveLengthMeasure _thickness;

	IfcPositiveLengthMeasure IIfcCenterLineProfileDef.Thickness
	{
		get
		{
			return Thickness;
		}
		set
		{
			Thickness = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure Thickness
	{
		get
		{
			if (_activated)
			{
				return _thickness;
			}
			Activate();
			return _thickness;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_thickness = v;
			}, _thickness, value, "Thickness", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.Curve != null)
			{
				yield return base.Curve;
			}
		}
	}

	internal IfcCenterLineProfileDef(IModel model, int label, bool activated)
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
			_thickness = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCenterLineProfileDef other)
	{
		return this == other;
	}
}
