using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc.Fluent;

public interface IModelInstanceBuilder
{
	IEntityCollection Instances { get; }

	IModel Model { get; }

	EntityCreator Factory { get; }
}
