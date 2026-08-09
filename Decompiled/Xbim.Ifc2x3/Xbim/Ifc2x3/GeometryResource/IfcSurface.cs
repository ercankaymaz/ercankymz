using System;
using Xbim.Common;
using Xbim.Ifc2x3.GeometricConstraintResource;
using Xbim.Ifc2x3.GeometricModelResource;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometryResource;

[ExpressType("IfcSurface", 111)]
public abstract class IfcSurface : IfcGeometricRepresentationItem, Xbim.Ifc2x3.GeometricModelResource.IfcGeometricSetSelect, IExpressSelectType, IPersist, IPersistEntity, IIfcGeometricSetSelect, Xbim.Ifc2x3.GeometricConstraintResource.IfcSurfaceOrFaceSurface, IIfcSurfaceOrFaceSurface, IEquatable<IfcSurface>, IIfcSurface, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometricModelResource.IfcGeometricSetSelect, Xbim.Ifc4.GeometricConstraintResource.IfcSurfaceOrFaceSurface
{
	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public virtual IfcDimensionCount Dim
	{
		get
		{
			IfcElementarySurface ifcElementarySurface = this as IfcElementarySurface;
			if (ifcElementarySurface != null)
			{
				return ifcElementarySurface.Dim;
			}
			IfcSweptSurface ifcSweptSurface = this as IfcSweptSurface;
			if (ifcSweptSurface != null)
			{
				return ifcSweptSurface.Dim;
			}
			IfcCurveBoundedPlane ifcCurveBoundedPlane = this as IfcCurveBoundedPlane;
			if (ifcCurveBoundedPlane != null)
			{
				return ifcCurveBoundedPlane.Dim;
			}
			IfcRectangularTrimmedSurface ifcRectangularTrimmedSurface = this as IfcRectangularTrimmedSurface;
			if (ifcRectangularTrimmedSurface != null)
			{
				return ifcRectangularTrimmedSurface.Dim;
			}
			return 0L;
		}
	}

	Xbim.Ifc4.GeometryResource.IfcDimensionCount Xbim.Ifc4.GeometricModelResource.IfcGeometricSetSelect.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcSurface(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcSurface other)
	{
		return this == other;
	}
}
