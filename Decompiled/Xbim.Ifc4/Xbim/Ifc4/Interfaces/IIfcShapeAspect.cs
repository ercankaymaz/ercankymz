using Xbim.Common;
using Xbim.Ifc4.ExternalReferenceResource;
using Xbim.Ifc4.MeasureResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcShapeAspect : IPersistEntity, IPersist, IfcResourceObjectSelect, IIfcResourceObjectSelect, IExpressSelectType
{
	IItemSet<IIfcShapeModel> ShapeRepresentations { get; }

	IfcLabel? Name { get; set; }

	IfcText? Description { get; set; }

	IfcLogical ProductDefinitional { get; set; }

	IIfcProductRepresentationSelect PartOfProductDefinitionShape { get; set; }
}
