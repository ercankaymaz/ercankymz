using System.Collections.Generic;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Policies;

public class PrimarySelectionPolicy : SelectionPolicy
{
	protected override IEnumerable<ModelItem> GetPolicyItems(Selection selection)
	{
		ModelItem primarySelection = selection.PrimarySelection;
		if (primarySelection != null)
		{
			return new ModelItem[1] { primarySelection };
		}
		return new ModelItem[0];
	}
}
