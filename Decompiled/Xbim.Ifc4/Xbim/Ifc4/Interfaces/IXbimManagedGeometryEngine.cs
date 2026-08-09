using Xbim.Common;

namespace Xbim.Ifc4.Interfaces;

public interface IXbimManagedGeometryEngine : IXbimGeometryEngine
{
	void RegisterModel(IModel model);

	void UnregisterModel(IModel model);
}
