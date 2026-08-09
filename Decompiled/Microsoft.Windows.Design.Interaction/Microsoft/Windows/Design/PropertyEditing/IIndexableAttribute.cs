using System;

namespace Microsoft.Windows.Design.PropertyEditing;

public interface IIndexableAttribute
{
	Attribute this[string key] { get; }
}
