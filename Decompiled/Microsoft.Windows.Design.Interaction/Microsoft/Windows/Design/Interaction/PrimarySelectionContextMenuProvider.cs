using Microsoft.Windows.Design.Policies;

namespace Microsoft.Windows.Design.Interaction;

[UsesItemPolicy(typeof(PrimarySelectionPolicy))]
public abstract class PrimarySelectionContextMenuProvider : ContextMenuProvider
{
}
