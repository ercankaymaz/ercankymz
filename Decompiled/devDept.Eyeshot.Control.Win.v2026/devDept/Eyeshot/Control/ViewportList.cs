using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing.Design;

namespace devDept.Eyeshot.Control;

[Editor("devDept.Eyeshot.Control.Designer.Client.DesignEditor", typeof(UITypeEditor))]
public class ViewportList : CollectionBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Workspace _0023_003Dz0TvaYNo_003D;

	[NotifyParentProperty(true)]
	public Viewport this[int index]
	{
		get
		{
			return (Viewport)base.List[index];
		}
		set
		{
			base.List[index] = value;
			_0023_003DzHqqvNbsad_LE(value);
			_0023_003Dz0TvaYNo_003D._0023_003DzaZN_GzT00MrX(value);
		}
	}

	public ViewportList(Workspace parent)
	{
		_0023_003Dz0TvaYNo_003D = parent;
	}

	internal void _0023_003DzHqqvNbsad_LE(Workspace _0023_003Dz0TvaYNo_003D)
	{
		this._0023_003Dz0TvaYNo_003D = _0023_003Dz0TvaYNo_003D;
		foreach (Viewport item in base.List)
		{
			_0023_003DzHqqvNbsad_LE(item);
		}
	}

	private void _0023_003DzHqqvNbsad_LE(Viewport _0023_003Dz3kjjQlQ_003D)
	{
		_0023_003Dz3kjjQlQ_003D._0023_003DzHqqvNbsad_LE(_0023_003Dz0TvaYNo_003D);
	}

	public int Add(Viewport value)
	{
		int result = base.List.Add(value);
		_0023_003Dz0TvaYNo_003D._0023_003Dzx_fjDklLVB1Z();
		return result;
	}

	public int AddRange(IList value)
	{
		int result = 0;
		foreach (object item in value)
		{
			result = base.List.Add(item);
		}
		_0023_003Dz0TvaYNo_003D._0023_003Dzx_fjDklLVB1Z();
		return result;
	}

	public int IndexOf(Viewport value)
	{
		return base.List.IndexOf(value);
	}

	public void Insert(int index, Viewport value)
	{
		base.List.Insert(index, value);
		_0023_003Dz0TvaYNo_003D._0023_003Dzx_fjDklLVB1Z();
	}

	public void Remove(Viewport value)
	{
		base.List.Remove(value);
		_0023_003Dz0TvaYNo_003D._0023_003Dzx_fjDklLVB1Z();
	}

	public new void RemoveAt(int index)
	{
		base.List.RemoveAt(index);
		_0023_003Dz0TvaYNo_003D._0023_003Dzx_fjDklLVB1Z();
	}

	public bool Contains(Viewport value)
	{
		return base.List.Contains(value);
	}

	protected override void OnInsert(int index, object value)
	{
		base.OnInsert(index, value);
		_0023_003DzHqqvNbsad_LE((Viewport)value);
		_0023_003Dz0TvaYNo_003D._0023_003DzOWfUZLjOSimJ();
		_0023_003Dz0TvaYNo_003D._0023_003DzaZN_GzT00MrX((Viewport)value);
	}

	protected override void OnRemove(int index, object value)
	{
	}

	protected override void OnSet(int index, object oldValue, object newValue)
	{
		base.OnSet(index, oldValue, newValue);
		((Viewport)newValue)._0023_003DzzgjrOMU_003D(_0023_003Dz0TvaYNo_003D);
	}

	protected override void OnValidate(object value)
	{
		if (!(value is Viewport))
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591833), _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348591859));
		}
	}
}
