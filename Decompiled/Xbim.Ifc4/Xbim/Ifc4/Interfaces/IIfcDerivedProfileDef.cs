using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcDerivedProfileDef : IIfcProfileDef, IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IIfcProfileDef ParentProfile { get; set; }

	IIfcCartesianTransformationOperator2D Operator { get; set; }

	IfcLabel? Label { get; set; }
}
