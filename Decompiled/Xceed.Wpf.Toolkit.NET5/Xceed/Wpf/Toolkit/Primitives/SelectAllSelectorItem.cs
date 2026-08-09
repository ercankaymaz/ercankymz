namespace Xceed.Wpf.Toolkit.Primitives;

public class SelectAllSelectorItem : SelectorItem
{
	private bool _ignoreSelectorChanges;

	protected override void OnIsSelectedChanged(bool? oldValue, bool? newValue)
	{
		if (!_ignoreSelectorChanges && base.TemplatedParent is SelectAllSelector selectAllSelector && newValue.HasValue)
		{
			if (newValue.Value)
			{
				selectAllSelector.SelectAll();
			}
			else
			{
				selectAllSelector.UnSelectAll();
			}
		}
	}

	internal void ModifyCurrentSelection(bool? newSelection)
	{
		_ignoreSelectorChanges = true;
		base.IsSelected = newSelection;
		_ignoreSelectorChanges = false;
	}
}
