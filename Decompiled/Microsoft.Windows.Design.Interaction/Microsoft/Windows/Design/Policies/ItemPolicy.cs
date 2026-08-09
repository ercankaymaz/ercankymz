using System;
using System.Collections.Generic;
using System.Globalization;
using MS.Internal.Properties;
using Microsoft.Windows.Design.Model;

namespace Microsoft.Windows.Design.Policies;

public abstract class ItemPolicy
{
	private EditingContext _context;

	private static ModelItem[] _emptyItems = new ModelItem[0];

	protected EditingContext Context
	{
		get
		{
			if (_context == null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, MS.Internal.Properties.Resources.Error_ObjectNotActive, new object[1] { GetType().Name }));
			}
			return _context;
		}
	}

	public virtual bool IsSurrogate => false;

	public abstract IEnumerable<ModelItem> PolicyItems { get; }

	public event EventHandler<PolicyItemsChangedEventArgs> PolicyItemsChanged;

	public virtual IEnumerable<ModelItem> GetSurrogateItems(ModelItem item)
	{
		return _emptyItems;
	}

	internal void Activate(EditingContext context)
	{
		if (context == null)
		{
			throw new ArgumentNullException("context");
		}
		if (_context != null)
		{
			throw new InvalidOperationException(MS.Internal.Properties.Resources.Error_ObjectAlreadyActive);
		}
		_context = context;
		OnActivated();
	}

	protected abstract void OnActivated();

	internal void Deactivate()
	{
		OnDeactivated();
	}

	protected virtual void OnDeactivated()
	{
	}

	protected virtual void OnPolicyItemsChanged(PolicyItemsChangedEventArgs e)
	{
		if (this.PolicyItemsChanged != null)
		{
			this.PolicyItemsChanged(this, e);
		}
	}
}
