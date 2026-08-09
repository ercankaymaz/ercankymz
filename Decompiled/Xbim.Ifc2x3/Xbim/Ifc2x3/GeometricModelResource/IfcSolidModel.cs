using System;
using Xbim.Common;
using Xbim.Ifc2x3.GeometryResource;
using Xbim.Ifc4.GeometricConstraintResource;
using Xbim.Ifc4.GeometricModelResource;
using Xbim.Ifc4.GeometryResource;
using Xbim.Ifc4.Interfaces;
using Xbim.Ifc4.PresentationOrganizationResource;

namespace Xbim.Ifc2x3.GeometricModelResource;

[ExpressType("IfcSolidModel", 150)]
public abstract class IfcSolidModel : Xbim.Ifc2x3.GeometryResource.IfcGeometricRepresentationItem, IfcBooleanOperand, IExpressSelectType, IPersist, IPersistEntity, IIfcBooleanOperand, IEquatable<IfcSolidModel>, IIfcSolidModel, IIfcGeometricRepresentationItem, IIfcRepresentationItem, IfcLayeredItem, IIfcLayeredItem, Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand, IfcSolidOrShell, IIfcSolidOrShell
{
	[EntityAttribute(0, EntityAttributeState.Derived, EntityAttributeType.None, EntityAttributeType.None, null, null, 0)]
	public Xbim.Ifc2x3.GeometryResource.IfcDimensionCount Dim => 3L;

	Xbim.Ifc4.GeometryResource.IfcDimensionCount Xbim.Ifc4.GeometricModelResource.IfcBooleanOperand.Dim => new Xbim.Ifc4.GeometryResource.IfcDimensionCount(Dim);

	internal IfcSolidModel(IModel model, int label, bool activated)
		: base(model, label, activated)
	{
	}

	public override void Parse(int propIndex, IPropertyValue value, int[] nestedIndex)
	{
		throw new IndexOutOfRangeException("There are no attributes defined for this entity");
	}

	public bool Equals(IfcSolidModel other)
	{
		return this == other;
	}
}
