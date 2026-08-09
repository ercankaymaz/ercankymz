using System;

namespace Microsoft.Windows.Design.Model;

public class ModelItemEventArgs : EventArgs
{
	private ModelItem _item;

	public ModelItem ModelItem => _item;

	public ModelItemEventArgs(ModelItem item)
	{
		if (item == null)
		{
			throw new ArgumentNullException("item");
		}
		_item = item;
	}
}
