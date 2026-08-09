using Xbim.Common;
using Xbim.Ifc4.MaterialResource;

namespace Xbim.Ifc4.Interfaces;

public interface IIfcMaterialList : IPersistEntity, IPersist, IfcMaterialSelect, IIfcMaterialSelect, IExpressSelectType
{
	IItemSet<IIfcMaterial> Materials { get; }
}
