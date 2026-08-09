using System;

namespace Microsoft.Windows.Design.Interaction;

public class MenuActionEventArgs : EventArgs
{
	private EditingContext _context;

	private Selection _selection;

	public EditingContext Context => _context;

	public Selection Selection => _selection;

	public MenuActionEventArgs(EditingContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		_context = context;
		_selection = _context.Items.GetValue<Selection>();
	}
}
