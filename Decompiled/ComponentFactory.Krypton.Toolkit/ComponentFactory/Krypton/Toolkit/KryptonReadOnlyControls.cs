using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class KryptonReadOnlyControls : KryptonControlCollection
{
	private bool _allowRemove;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public bool AllowRemoveInternal
	{
		get
		{
			return _allowRemove;
		}
		set
		{
			_allowRemove = value;
		}
	}

	public KryptonReadOnlyControls(Control owner)
		: base(owner)
	{
		_allowRemove = false;
	}

	public override void Add(Control value)
	{
		if (AllowRemoveInternal)
		{
			base.Add(value);
			return;
		}
		throw new NotSupportedException("ReadOnly controls collection");
	}

	public override void AddRange(Control[] controls)
	{
		if (AllowRemoveInternal)
		{
			base.AddRange(controls);
			return;
		}
		throw new NotSupportedException("ReadOnly controls collection");
	}

	public override void Remove(Control value)
	{
		if (AllowRemoveInternal)
		{
			base.Remove(value);
		}
		else if (Contains(value))
		{
			throw new NotSupportedException("ReadOnly controls collection");
		}
	}

	public override void RemoveByKey(string key)
	{
		if (AllowRemoveInternal)
		{
			base.RemoveByKey(key);
		}
		else if (ContainsKey(key))
		{
			throw new NotSupportedException("ReadOnly controls collection");
		}
	}

	public override void Clear()
	{
		if (AllowRemoveInternal)
		{
			base.Clear();
		}
		else if (Count > 0)
		{
			throw new NotSupportedException("ReadOnly controls collection");
		}
	}
}
