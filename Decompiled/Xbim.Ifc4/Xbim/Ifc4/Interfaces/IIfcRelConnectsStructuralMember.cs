using Xbim.Common;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcRelConnectsStructuralMember : IIfcRelConnects, IIfcRelationship, IIfcRoot, IPersistEntity, IPersist
{
	IIfcStructuralMember RelatingStructuralMember { get; set; }

	IIfcStructuralConnection RelatedStructuralConnection { get; set; }

	IIfcBoundaryCondition AppliedCondition { get; set; }

	IIfcStructuralConnectionCondition AdditionalConditions { get; set; }

	IfcLengthMeasure? SupportedLength { get; set; }

	IIfcAxis2Placement3D ConditionCoordinateSystem { get; set; }
}
