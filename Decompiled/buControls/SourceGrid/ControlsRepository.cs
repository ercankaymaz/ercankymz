using System;
using System.Collections;
using System.Windows.Forms;

namespace SourceGrid;

public class ControlsRepository : DictionaryBase
{
	private Control p_ParentControl;

	public virtual Control this[Guid key] => (Control)base.Dictionary[key];

	public virtual ICollection Keys => base.Dictionary.Keys;

	public virtual ICollection Values => base.Dictionary.Values;

	public ControlsRepository(Control p_ParentControl)
	{
		this.p_ParentControl = p_ParentControl;
	}

	public virtual void Add(Guid key, Control value)
	{
		base.Dictionary.Add(key, value);
		p_ParentControl.Controls.Add(value);
	}

	public virtual bool Contains(Guid key)
	{
		return base.Dictionary.Contains(key);
	}

	public virtual bool ContainsKey(Guid key)
	{
		return base.Dictionary.Contains(key);
	}

	public virtual bool ContainsValue(Control value)
	{
		foreach (Control value2 in base.Dictionary.Values)
		{
			if (value2 == value)
			{
				return true;
			}
		}
		return false;
	}

	public virtual void Remove(Guid key)
	{
		if (ContainsKey(key))
		{
			p_ParentControl.Controls.Remove(this[key]);
			base.Dictionary.Remove(key);
		}
	}
}
