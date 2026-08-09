using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.GeometryResource;

[ExpressType("IfcReparametrisedCompositeCurveSegment", 1255)]
public class IfcReparametrisedCompositeCurveSegment : IfcCompositeCurveSegment, IInstantiableEntity, IPersistEntity, IPersist, IContainsEntityReferences, IEquatable<IfcReparametrisedCompositeCurveSegment>, IIfcReparametrisedCompositeCurveSegment, IIfcCompositeCurveSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType
{
	private Xbim.Ifc4x3.MeasureResource.IfcParameterValue _paramLength;

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 7)]
	public Xbim.Ifc4x3.MeasureResource.IfcParameterValue ParamLength
	{
		get
		{
			if (_activated)
			{
				return _paramLength;
			}
			Activate();
			return _paramLength;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcParameterValue v)
			{
				_paramLength = v;
			}, _paramLength, value, "ParamLength", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (base.ParentCurve != null)
			{
				yield return base.ParentCurve;
			}
		}
	}

	[CrossSchemaAttribute(typeof(IIfcReparametrisedCompositeCurveSegment), 4)]
	Xbim.Ifc4.MeasureResource.IfcParameterValue IIfcReparametrisedCompositeCurveSegment.ParamLength
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcParameterValue(ParamLength);
		}
		set
		{
			ParamLength = new Xbim.Ifc4x3.MeasureResource.IfcParameterValue(value);
		}
	}

	internal IfcReparametrisedCompositeCurveSegment(IModel model, int label, bool activated)
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
			_paramLength = value.RealVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcReparametrisedCompositeCurveSegment other)
	{
		return this == other;
	}
}
