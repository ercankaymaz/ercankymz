using System.Collections.Generic;

namespace Microsoft.Windows.Design;

public interface IToolboxExampleFactory
{
	IEnumerable<IToolboxExample> Examples { get; }
}
