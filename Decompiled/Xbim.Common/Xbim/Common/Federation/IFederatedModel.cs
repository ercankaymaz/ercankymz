using System.Collections.Generic;

namespace Xbim.Common.Federation;

public interface IFederatedModel
{
	IModel ReferencingModel { get; }

	IEnumerable<IReferencedModel> ReferencedModels { get; }

	IReadOnlyEntityCollection FederatedInstances { get; }

	IList<XbimInstanceHandle> FederatedInstanceHandles { get; }

	void AddModelReference(IReferencedModel model);
}
