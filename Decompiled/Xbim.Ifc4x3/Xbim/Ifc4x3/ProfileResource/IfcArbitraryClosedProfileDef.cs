using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4x3.GeometryResource;

namespace Xbim.Ifc4x3.ProfileResource;

[ExpressType("IfcArbitraryClosedProfileDef", 115)]
public class IfcArbitraryClosedProfileDef : IfcProfileDef, IIfcArbitraryClosedProfileDef, IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType, IInstantiableEntity, IContainsEntityReferences, IEquatable<IfcArbitraryClosedProfileDef>
{
	private IfcCurve _outerCurve;

	[CrossSchemaAttribute(typeof(IIfcArbitraryClosedProfileDef), 3)]
	IIfcCurve IIfcArbitraryClosedProfileDef.OuterCurve
	{
		get
		{
			return OuterCurve;
		}
		set
		{
			OuterCurve = value as IfcCurve;
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcCurve OuterCurve
	{
		get
		{
			if (_activated)
			{
				return _outerCurve;
			}
			Activate();
			return _outerCurve;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_outerCurve = v;
			}, _outerCurve, value, "OuterCurve", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (OuterCurve != null)
			{
				yield return OuterCurve;
			}
		}
	}

	internal IfcArbitraryClosedProfileDef(IModel model, int label, bool activated)
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
			_outerCurve = (IfcCurve)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcArbitraryClosedProfileDef other)
	{
		return this == other;
	}
}
