using System.Collections.Generic;
using System.Reflection;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Services;

public abstract class ExternalMarkupService
{
	public abstract ModelItem Load(string markup, IEnumerable<AssemblyName> additionalReferences);

	public abstract string Save(ModelItem root, out IEnumerable<AssemblyName> requiredAssemblies);
}
