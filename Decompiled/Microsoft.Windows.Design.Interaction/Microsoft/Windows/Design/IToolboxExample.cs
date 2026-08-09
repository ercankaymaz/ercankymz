using System.IO;
using System.Windows;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design;

public interface IToolboxExample
{
	string DisplayName { get; }

	ModelItem CreateExample(EditingContext context);

	Stream GetImageStream(Size desiredSize);
}
