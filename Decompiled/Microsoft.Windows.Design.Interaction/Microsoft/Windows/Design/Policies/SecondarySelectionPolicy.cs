using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Policies;

public class SecondarySelectionPolicy : SelectionPolicy
{
	protected override bool IsInPolicy(Selection selection, ModelItem item)
	{
		return item != selection.PrimarySelection;
	}
}
