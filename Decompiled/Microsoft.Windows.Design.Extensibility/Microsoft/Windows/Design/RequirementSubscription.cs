using System;

namespace Microsoft.Windows.Design;

public abstract class RequirementSubscription
{
	private EventHandler _requirementChanged;

	private RequirementAttribute _requirement;

	public RequirementAttribute Requirement => _requirement;

	public event EventHandler RequirementChanged
	{
		add
		{
			if (value != null)
			{
				bool flag = _requirementChanged == null;
				_requirementChanged = (EventHandler)Delegate.Combine(_requirementChanged, value);
				if (flag)
				{
					Subscribe();
				}
			}
		}
		remove
		{
			bool flag = _requirementChanged != null;
			_requirementChanged = (EventHandler)Delegate.Remove(_requirementChanged, value);
			if (_requirementChanged == null && flag)
			{
				Unsubscribe();
			}
		}
	}

	protected RequirementSubscription(RequirementAttribute requirement)
	{
		if (requirement == null)
		{
			throw new ArgumentNullException("requirement");
		}
		_requirement = requirement;
	}

	protected void OnRequirementChanged()
	{
		if (_requirementChanged != null)
		{
			_requirementChanged(this, EventArgs.Empty);
		}
	}

	protected abstract void Subscribe();

	protected abstract void Unsubscribe();
}
