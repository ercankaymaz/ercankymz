using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using devDept.Eyeshot.Control;

namespace devDept.Eyeshot.Designer.Converters;

public class ToolBarButtonsCollectionEditor : EyeshotCollectionEditor<ToolBarButton>
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ToolBar _0023_003DzdKn1T20rqRfe;

	public ToolBarButtonsCollectionEditor(Type type)
		: base(type)
	{
	}

	protected override Type[] CreateNewItemTypes()
	{
		return new Type[8]
		{
			typeof(ToolBarButton),
			typeof(HomeToolBarButton),
			typeof(MagnifyingGlassToolBarButton),
			typeof(ZoomWindowToolBarButton),
			typeof(ZoomToolBarButton),
			typeof(PanToolBarButton),
			typeof(RotateToolBarButton),
			typeof(ZoomFitToolBarButton)
		};
	}

	public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
	{
		if (context.Instance is ToolBar)
		{
			_0023_003DzdKn1T20rqRfe = (ToolBar)context.Instance;
		}
		if (context.Instance is Viewport)
		{
			viewport = (Viewport)context.Instance;
		}
		ToolBarButtonList result = (ToolBarButtonList)VisualControlDesigner._0023_003DzjKucw_SOIA1l._0023_003DzhL8JyLIuKkZd(value);
		object result2 = base.EditValue(context, provider, value);
		if (cancelled)
		{
			return result;
		}
		return result2;
	}

	protected override object SetItems(object editValue, object[] value)
	{
		List<ToolBarButton> list = new List<ToolBarButton>();
		for (int i = 0; i < value.Length; i++)
		{
			if (!((ToolBarButton)value[i]).Disposed)
			{
				list.Add((ToolBarButton)value[i]);
			}
		}
		_0023_003DzdKn1T20rqRfe.Buttons = new ToolBarButtonList(_0023_003DzdKn1T20rqRfe, list.ToArray());
		UpdateGraphics();
		return _0023_003DzdKn1T20rqRfe.Buttons;
	}

	protected override void SelectionIndexChanged(object sender, EventArgs e)
	{
		base.SelectionIndexChanged(sender, e);
		List<ToolBarButton> itemsList = GetItemsList();
		if (_0023_003DzdKn1T20rqRfe.Buttons.Count != itemsList.Count)
		{
			_0023_003DzdKn1T20rqRfe.Buttons = new ToolBarButtonList(_0023_003DzdKn1T20rqRfe, itemsList.ToArray());
			UpdateGraphics();
		}
	}
}
