using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcArbitraryOpenProfileDef", 219)]
public class IfcArbitraryOpenProfileDef : IfcProfileDef, IIfcArbitraryOpenProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcArbitraryOpenProfileDef>
{
	private IfcBoundedCurve _curve;

	[CrossSchemaAttribute(typeof(IIfcArbitraryOpenProfileDef), 3)]
	IIfcBoundedCurve IIfcArbitraryOpenProfileDef.Curve
	{
		get
		{
			return Curve;
		}
		set
		{
			Curve = value as IfcBoundedCurve;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcBoundedCurve Curve
	{
		get
		{
			if (_activated)
			{
				return _curve;
			}
			Activate();
			return _curve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcBoundedCurve v)
			{
				_curve = v;
			}, _curve, value, "Curve", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (Curve != null)
			{
				yield return Curve;
			}
		}
	}

	internal IfcArbitraryOpenProfileDef(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
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
			_curve = (IfcBoundedCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcArbitraryOpenProfileDef other)
	{
		return this == other;
	}
}
