using System;
using System.Collections.Generic;
using Microsoft.Windows.Design.Policies;

namespace Microsoft.Windows.Design.Services;

internal abstract class ItemPolicyService
{
	public abstract IEnumerable<ItemPolicy> Policies { get; }

	public abstract event EventHandler<PolicyAddedEventArgs> PolicyAdded;
}
