using Xbim.Common;
using Xbim.Ifc4.Interfaces;

namespace Xbim.Ifc.Fluent;

internal class ModelInstanceBuilder : IModelInstanceBuilder
{
	public IModel Model => FileBuilder.Model;

	public EntityCreator Factory => FileBuilder.Factory;

	public IEntityCollection Instances => Model.Instances;

	protected IModelFileBuilder FileBuilder { get; }

	public ModelInstanceBuilder(IModelFileBuilder fileBuilder)
	{
		FileBuilder = fileBuilder;
	}
}
