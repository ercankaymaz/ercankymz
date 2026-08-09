using System;

namespace Microsoft.Windows.Design.PropertyEditing;

public interface IPropertyFilterTarget
{
	bool MatchesFilter { get; }

	event EventHandler<PropertyFilterAppliedEventArgs> FilterApplied;

	void ApplyFilter(PropertyFilter filter);

	bool MatchesPredicate(PropertyFilterPredicate predicate);
}
