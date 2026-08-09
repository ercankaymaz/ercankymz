using Microsoft.Windows.Design.Policies;

namespace Microsoft.Windows.Design.Interaction;

[UsesItemPolicy(typeof(PrimarySelectionPolicy))]
public class PrimarySelectionTaskProvider : TaskProvider
{
}
