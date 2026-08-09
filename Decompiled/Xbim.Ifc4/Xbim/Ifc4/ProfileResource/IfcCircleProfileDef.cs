using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.ProfileResource;

[ExpressType("IfcCircleProfileDef", 113)]
public class IfcCircleProfileDef : IfcParameterizedProfileDef, IInstantiableEntity, IPersistEntity, IPersist, IIfcCircleProfileDef, IIfcParameterizedProfileDef, IIfcProfileDef, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcCircleProfileDef>
{
	private IfcPositiveLengthMeasure _radius;

	IfcPositiveLengthMeasure IIfcCircleProfileDef.Radius
	{
		get
		{
			return Radius;
		}
		set
		{
			Radius = value;
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public IfcPositiveLengthMeasure Radius
	{
		get
		{
			if (_activated)
			{
				return _radius;
			}
			Activate();
			return _radius;
		}
		set
		{
			SetValue(delegate(IfcPositiveLengthMeasure v)
			{
				_radius = v;
			}, _radius, value, "Radius", 4);
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

	internal IfcCircleProfileDef(IModel model, int label, bool activated)
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
			_radius = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcCircleProfileDef other)
	{
		return this == other;
	}
}
