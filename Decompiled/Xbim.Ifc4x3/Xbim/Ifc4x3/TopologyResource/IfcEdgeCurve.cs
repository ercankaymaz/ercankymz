using System;
using System.Collections.Generic;
using Xbim.Common;
using Xbim.Common.Exceptions;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.MeasureResource;
using Xbim.Ifc4.PresentationOrganizationResource;
using Xbim.Ifc4x3.GeometricConstraintResource;
using Xbim.Ifc4x3.GeometryResource;
using Xbim.Ifc4x3.MeasureResource;

namespace Xbim.Ifc4x3.TopologyResource;

[ExpressType("IfcEdgeCurve", 203)]
public class IfcEdgeCurve : IfcEdge, IIfcEdgeCurve, IIfcEdge, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricConstraintResource.IfcCurveOrEdgeCurve, IIfcCurveOrEdgeCurve, IInstantiableEntity, Xbim.Ifc4x3.GeometricConstraintResource.IfcCurveOrEdgeCurve, IContainsEntityReferences, IEquatable<IfcEdgeCurve>
{
	private IfcCurve _edgeGeometry;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean _sameSense;

	[CrossSchemaAttribute(typeof(IIfcEdgeCurve), 3)]
	IIfcCurve IIfcEdgeCurve.EdgeGeometry
	{
		get
		{
			return EdgeGeometry;
		}
		set
		{
			EdgeGeometry = value as IfcCurve;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcEdgeCurve), 4)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcEdgeCurve.SameSense
	{
		get
		{
			return new Xbim.Ifc4.MeasureResource.IfcBoolean(SameSense);
		}
		set
		{
			SameSense = new Xbim.Ifc4x3.MeasureResource.IfcBoolean(value);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcCurve EdgeGeometry
	{
		get
		{
			if (_activated)
			{
				return _edgeGeometry;
			}
			Activate();
			return _edgeGeometry;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcCurve v)
			{
				_edgeGeometry = v;
			}, _edgeGeometry, value, "EdgeGeometry", 3);
		}
	}

	[EntityAttribute(4, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
	public Xbim.Ifc4x3.MeasureResource.IfcBoolean SameSense
	{
		get
		{
			if (_activated)
			{
				return _sameSense;
			}
			Activate();
			return _sameSense;
		}
		set
		{
			SetValue(delegate(Xbim.Ifc4x3.MeasureResource.IfcBoolean v)
			{
				_sameSense = v;
			}, _sameSense, value, "SameSense", 4);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			if (EdgeStart != null)
			{
				yield return EdgeStart;
			}
			if (EdgeEnd != null)
			{
				yield return EdgeEnd;
			}
			if (EdgeGeometry != null)
			{
				yield return EdgeGeometry;
			}
		}
	}

	internal IfcEdgeCurve(IModel model, int label, bool activated)
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
			_edgeGeometry = (IfcCurve)value.EntityVal;
			break;
		case 3:
			_sameSense = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcEdgeCurve other)
	{
		return this == other;
	}
}
