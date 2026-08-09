using System;
using MS.Internal.Properties;

namespace Microsoft.Windows.Design.Interaction;

public sealed class CurrentDesignerView : ContextItem
{
	private DesignerView _view;

	private bool _allowNullView;

	public DesignerView View => _view;

	public override Type ItemType => typeof(CurrentDesignerView);

	public CurrentDesignerView()
	{
	}

	internal CurrentDesignerView(DesignerView view)
	{
		_view = view;
		_allowNullView = view == null;
	}

	protected override void OnItemChanged(EditingContext context, ContextItem previousItem)
	{
		if (!_allowNullView && ((CurrentDesignerView)previousItem)._view != null && _view == null)
		{
			throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_ContextHasView);
		}
		base.OnItemChanged(context, previousItem);
	}
}
