using System;

namespace Microsoft.Windows.Design;

public abstract class RequirementAttribute : Attribute
{
	public virtual bool AllRequired => true;

	public abstract bool MeetsRequirement(EditingContext context);

	public abstract RequirementSubscription CreateSubscription(EditingContext context);
}
