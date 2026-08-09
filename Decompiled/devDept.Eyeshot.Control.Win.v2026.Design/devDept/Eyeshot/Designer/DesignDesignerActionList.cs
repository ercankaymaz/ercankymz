#define WINFORMS
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Windows.Forms.Design;
using devDept.Eyeshot.Control;
using devDept.Graphics;

namespace devDept.Eyeshot.Designer;

public class DesignDesignerActionList<T> : WorkspaceDesignerActionList<T> where T : Design
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private DesignControlDesignerGeneric<T> _0023_003Dzduzcy84Qj6z8;

	public orientationType OrientationMode
	{
		get
		{
			return ((Design)base.Component).OrientationMode;
		}
		set
		{
			SetControlProperty(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313306), value);
			((Design)base.Component).UpdateDesignModeScene();
			RefreshAll();
		}
	}

	public DesignDesignerActionList(ControlDesigner designer)
		: base(designer)
	{
		try
		{
			_0023_003Dzduzcy84Qj6z8 = (DesignControlDesignerGeneric<T>)WorkspaceControlDesigner;
		}
		catch (Exception ex)
		{
			throw new Exception(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313419) + ex.StackTrace, ex);
		}
	}

	public void RunPreset()
	{
		_0023_003Dzduzcy84Qj6z8._0023_003DzhEmAtIyGka69();
		_designerActionUISvc.HideUI(base.Component);
	}

	public void Customize()
	{
		_0023_003Dzduzcy84Qj6z8._0023_003Dzi0rsks0_003D();
		_designerActionUISvc.HideUI(base.Component);
	}

	public override DesignerActionItemCollection GetSortedActionItems()
	{
		DesignerActionItemCollection designerActionItemCollection = new DesignerActionItemCollection();
		foreach (DesignerActionItem sortedActionItem in base.GetSortedActionItems())
		{
			designerActionItemCollection.Add(sortedActionItem);
		}
		DesignerActionPropertyItem value2 = new DesignerActionPropertyItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313306), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313140), string.Empty, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313122));
		designerActionItemCollection.Insert(0, value2);
		DesignerActionHeaderItem value3 = new DesignerActionHeaderItem(_0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313100), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313214));
		designerActionItemCollection.Insert(2, value3);
		designerActionItemCollection.Insert(3, new DesignerActionMethodItem(this, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313190), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313174), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313214), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313165)));
		designerActionItemCollection.Insert(4, new DesignerActionMethodItem(this, _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312984), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564312968), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313214), _0023_003Dz4HqHxpEtfiGGY8Lau7sfIdz9sFki._0023_003Dznx1EMIs_003D(-1564313081)));
		return designerActionItemCollection;
	}
}
