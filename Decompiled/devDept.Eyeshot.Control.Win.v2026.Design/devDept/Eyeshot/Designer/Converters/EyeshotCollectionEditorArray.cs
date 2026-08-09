using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer.Converters;

public class EyeshotCollectionEditorArray<T> : EyeshotCollectionEditor<T> where T : DisposableBase
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private object[] _0023_003DzggPceZ4_003D;

	public EyeshotCollectionEditorArray(Type type)
		: base(type)
	{
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		if (context.Instance is Viewport)
		{
			viewport = (Viewport)context.Instance;
		}
		_0023_003DzggPceZ4_003D = (object[])VisualControlDesigner._0023_003DzjKucw_SOIA1l._0023_003DzhL8JyLIuKkZd(value);
		object result = base.EditValue(context, provider, value);
		if (cancelled)
		{
			return _0023_003DzggPceZ4_003D;
		}
		return result;
	}

	protected override object SetItems(object editValue, object[] value)
	{
		List<T> list = new List<T>();
		for (int i = 0; i < value.Length; i++)
		{
			if (!((T)value[i]).Disposed)
			{
				list.Add((T)value[i]);
			}
		}
		return list.ToArray();
	}
}
