using Xbim.Common;
using Xbim.Ifc4.MaterialResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialProfileSetUsageTapering : IIfcMaterialProfileSetUsage, IIfcMaterialUsageDefinition, IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType
{
	IIfcMaterialProfileSet ForProfileEndSet { get; set; }

	IfcCardinalPointReference? CardinalEndPoint { get; set; }
}
