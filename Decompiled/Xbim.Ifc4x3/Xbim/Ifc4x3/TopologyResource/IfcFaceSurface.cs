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

[ExpressType("IfcFaceSurface", 85)]
public class IfcFaceSurface : IfcFace, IIfcFaceSurface, IIfcFace, IIfcTopologicalRepresentationItem, IIfcRepresentationItem, IPersistEntity, IPersist, IfcLayeredItem, IIfcLayeredItem, IExpressSelectType, Xbim.Ifc4.GeometricConstraintResource.IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IInstantiableEntity, Xbim.Ifc4x3.GeometricConstraintResource.IfcSurfaceOrFaceSurface, IContainsEntityReferences, IEquatable<IfcFaceSurface>
{
	private IfcSurface _faceSurface;

	private Xbim.Ifc4x3.MeasureResource.IfcBoolean _sameSense;

	[CrossSchemaAttribute(typeof(IIfcFaceSurface), 2)]
	IIfcSurface IIfcFaceSurface.FaceSurface
	{
		get
		{
			return FaceSurface;
		}
		set
		{
			FaceSurface = value as IfcSurface;
		}
	}

	[CrossSchemaAttribute(typeof(IIfcFaceSurface), 3)]
	Xbim.Ifc4.MeasureResource.IfcBoolean IIfcFaceSurface.SameSense
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

	[EntityAttribute(2, EntityAttributeState.Mandatory, EntityAttributeType.Class, EntityAttributeType.None, null, null, 5)]
	public IfcSurface FaceSurface
	{
		get
		{
			if (_activated)
			{
				return _faceSurface;
			}
			Activate();
			return _faceSurface;
		}
		set
		{
			if (value != null && base.Model != value.Model)
			{
				throw new XbimException("Cross model entity assignment.");
			}
			SetValue(delegate(IfcSurface v)
			{
				_faceSurface = v;
			}, _faceSurface, value, "FaceSurface", 2);
		}
	}

	[EntityAttribute(3, EntityAttributeState.Mandatory, EntityAttributeType.None, EntityAttributeType.None, null, null, 6)]
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
			}, _sameSense, value, "SameSense", 3);
		}
	}

	IEnumerable<IPersistEntity> IContainsEntityReferences.References
	{
		get
		{
			foreach (IfcFaceBound bound in base.Bounds)
			{
				yield return bound;
			}
			if (FaceSurface != null)
			{
				yield return FaceSurface;
			}
		}
	}

	internal IfcFaceSurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		switch (propIndex)
		{
		case 0:
			base.Parse(propIndex, value, nestedIndex);
			break;
		case 1:
			_faceSurface = (IfcSurface)value.EntityVal;
			break;
		case 2:
			_sameSense = value.BooleanVal;
			break;
		default:
			throw new XbimParserException($"Attribute index {propIndex + 1} is out of range for {GetType().Name.ToUpper()}");
		}
	}

	public bool Equals(IfcFaceSurface other)
	{
		return this == other;
	}
}
