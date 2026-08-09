using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc4.GeometricConstraintResource;

[ExpressType("IfcAlignment2DHorizontalSegment", 1333)]
public class IfcAlignment2DHorizontalSegment : IfcAlignment2DSegment, IInstantiableEntity, IPersistEntity, IPersist, IIfcAlignment2DHorizontalSegment, IIfcAlignment2DSegment, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, IContainsEntityReferences, IEquatable<IfcAlignment2DHorizontalSegment>
{
	private IfcCurveSegment2D _curveGeometry;

	IIfcCurveSegment2D IIfcAlignment2DHorizontalSegment.CurveGeometry
	{
		get
		{
			return CurveGeometry;
		}
		set
		{
			CurveGeometry = value as IfcCurveSegment2D;
		}
	}

	IEnumerable<IIfcAlignment2DHorizontal> IIfcAlignment2DHorizontalSegment.ToHorizontal => ToHorizontal;

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 6)]
	public IfcCurveSegment2D CurveGeometry
	{
		get
		{
			if (_activated)
			{
				return _curveGeometry;
			}
			Activate();
			return _curveGeometry;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurveSegment2D v)
			{
				_curveGeometry = v;
			}, _curveGeometry, value, "CurveGeometry", 4);
		}
	}

	[InverseProperty("Segments")]
	[EntityAttribute(-1, EntityAttributeState.Mandatory, EntityAttributeType.Set, EntityAttributeType.Class, new int[] { 1 }, new int[] { 1 }, 7)]
	public IEnumerable<IfcAlignment2DHorizontal> ToHorizontal => base.Model.Instances.Where((IfcAlignment2DHorizontal e) => e.Segments != null && e.Segments.Contains(this), "Segments", this);

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (CurveGeometry != null)
			{
				yield return CurveGeometry;
			}
		}
	}

	internal IfcAlignment2DHorizontalSegment(IModel model, int label, bool activated)
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
			_curveGeometry = (IfcCurveSegment2D)value.EntityVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcAlignment2DHorizontalSegment other)
	{
		return this == other;
	}
}
