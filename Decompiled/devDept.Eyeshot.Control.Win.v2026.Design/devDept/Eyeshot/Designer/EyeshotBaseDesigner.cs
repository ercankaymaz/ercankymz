using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer;

public abstract class EyeshotBaseDesigner<T> : ControlDesigner where T : Workspace
{
	protected internal T Workspace;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal IComponentChangeService _0023_003DzwIQfEZg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ISelectionService _0023_003DzQtRuhbs_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal BehaviorService _0023_003DzvVRIqXnU6BzU;

	protected List<Adorner> adorners = new List<Adorner>();

	protected override void OnCreateHandle()
	{
		base.OnCreateHandle();
		IntializeViewportAdorner();
	}

	protected void InitializeServices()
	{
		_0023_003DzwIQfEZg_003D = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
		_0023_003DzQtRuhbs_003D = GetService(typeof(ISelectionService)) as ISelectionService;
		_0023_003DzvVRIqXnU6BzU = GetService(typeof(BehaviorService)) as BehaviorService;
	}

	protected Adorner InitializeUIElementAdorner(Adorner adorner)
	{
		adorner.Glyphs.Add(new global::_0023_003DzCfaZvK_0024R7pFT2PDRVRaPoUgEyeDkYat5guflGdQ_003D<T, global::_0023_003Dz1pQv2xG5zAUyO0MXW1n8_0024KBPh9v5s3BVqULgqSE_003D<T>>(_0023_003DzvVRIqXnU6BzU, _0023_003DzwIQfEZg_003D, _0023_003DzQtRuhbs_003D, this, adorner));
		return adorner;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && _0023_003DzvVRIqXnU6BzU != null)
		{
			for (int i = 0; i < adorners.Count; i++)
			{
				_0023_003DzvVRIqXnU6BzU.Adorners.Remove(adorners[i]);
			}
			adorners = new List<Adorner>();
		}
		base.Dispose(disposing);
		Workspace = null;
	}

	public abstract void IntializeViewportAdorner();

	protected override void PostFilterProperties(IDictionary properties)
	{
		properties.Remove(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313035));
		properties.Remove(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312891));
		properties.Remove(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312863));
		properties.Remove(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312845));
		base.PostFilterProperties(properties);
	}
}
