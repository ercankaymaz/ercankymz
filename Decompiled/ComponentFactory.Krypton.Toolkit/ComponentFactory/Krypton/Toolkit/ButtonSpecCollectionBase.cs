#define DEBUG
using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

[ListBindable(false)]
public abstract class ButtonSpecCollectionBase : GlobalId
{
	private object _owner;

	public object Owner
	{
		get
		{
			return _owner;
		}
		set
		{
			_owner = value;
		}
	}

	public event EventHandler<ButtonSpecEventArgs> Inserting;

	public event EventHandler<ButtonSpecEventArgs> Inserted;

	public event EventHandler<ButtonSpecEventArgs> Removing;

	public event EventHandler<ButtonSpecEventArgs> Removed;

	public ButtonSpecCollectionBase(object owner)
	{
		Debug.Assert(owner != null);
		_owner = owner;
	}

	public abstract IEnumerable Enumerate();

	protected void OnInserting(ButtonSpecEventArgs e)
	{
		e.ButtonSpec.Owner = _owner;
		if (this.Inserting != null)
		{
			this.Inserting(this, e);
		}
	}

	protected void OnInserted(ButtonSpecEventArgs e)
	{
		if (this.Inserted != null)
		{
			this.Inserted(this, e);
		}
	}

	protected void OnRemoving(ButtonSpecEventArgs e)
	{
		e.ButtonSpec.Owner = null;
		if (this.Removing != null)
		{
			this.Removing(this, e);
		}
	}

	protected void OnRemoved(ButtonSpecEventArgs e)
	{
		if (this.Removed != null)
		{
			this.Removed(this, e);
		}
	}
}
