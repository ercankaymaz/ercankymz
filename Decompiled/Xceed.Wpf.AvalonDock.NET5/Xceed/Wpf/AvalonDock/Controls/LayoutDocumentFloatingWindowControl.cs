using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using Microsoft.Windows.Shell;
using Xceed.Wpf.AvalonDock.Layout;

namespace Xceed.Wpf.AvalonDock.Controls;

public class LayoutDocumentFloatingWindowControl : LayoutFloatingWindowControl
{
	private LayoutDocumentFloatingWindow _model;

	public LayoutItem RootDocumentLayoutItem
	{
		get
		{
			if (_model == null || _model.Root == null || _model.Root.Manager == null)
			{
				return null;
			}
			return _model.Root.Manager.GetLayoutItemFromModel(_model.RootDocument);
		}
	}

	public override ILayoutElement Model => _model;

	static LayoutDocumentFloatingWindowControl()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutDocumentFloatingWindowControl), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(LayoutDocumentFloatingWindowControl)));
	}

	internal LayoutDocumentFloatingWindowControl(LayoutDocumentFloatingWindow model, bool isContentImmutable)
		: base(model, isContentImmutable)
	{
		_model = model;
		UpdateThemeResources();
	}

	internal LayoutDocumentFloatingWindowControl(LayoutDocumentFloatingWindow model)
		: this(model, isContentImmutable: false)
	{
	}

	protected override void OnInitialized(EventArgs e)
	{
		base.OnInitialized(e);
		if (_model.RootDocument == null)
		{
			InternalClose();
			return;
		}
		DockingManager manager = _model.Root.Manager;
		base.Content = manager.CreateUIElementForModel(_model.RootDocument);
		_model.RootDocumentChanged += _model_RootDocumentChanged;
	}

	protected override IntPtr FilterMessage(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
	{
		switch (msg)
		{
		case 161:
			if (wParam.ToInt32() == 2 && _model.RootDocument != null)
			{
				_model.RootDocument.IsActive = true;
			}
			break;
		case 165:
			if (wParam.ToInt32() == 2)
			{
				if (OpenContextMenu())
				{
					handled = true;
				}
				if (_model.Root.Manager.ShowSystemMenu)
				{
					WindowChrome.GetWindowChrome(this).ShowSystemMenu = !handled;
				}
				else
				{
					WindowChrome.GetWindowChrome(this).ShowSystemMenu = false;
				}
			}
			break;
		}
		return base.FilterMessage(hwnd, msg, wParam, lParam, ref handled);
	}

	protected override void OnClosed(EventArgs e)
	{
		base.OnClosed(e);
		_model.RootDocumentChanged -= _model_RootDocumentChanged;
	}

	protected override bool CanClose(object parameter = null)
	{
		if (Model == null)
		{
			return false;
		}
		ILayoutRoot root = Model.Root;
		if (root == null)
		{
			return false;
		}
		DockingManager manager = root.Manager;
		if (manager == null)
		{
			return false;
		}
		LayoutDocument[] array = Model.Descendents().OfType<LayoutDocument>().ToArray();
		foreach (LayoutDocument layoutDocument in array)
		{
			if (!layoutDocument.CanClose)
			{
				return false;
			}
			if (!(manager.GetLayoutItemFromModel(layoutDocument) is LayoutDocumentItem { CloseCommand: not null } layoutDocumentItem) || !layoutDocumentItem.CloseCommand.CanExecute(parameter))
			{
				return false;
			}
		}
		return true;
	}

	private void _model_RootDocumentChanged(object sender, EventArgs e)
	{
		if (_model.RootDocument == null)
		{
			InternalClose();
		}
	}

	private bool OpenContextMenu()
	{
		ContextMenu documentContextMenu = _model.Root.Manager.DocumentContextMenu;
		if (documentContextMenu != null && RootDocumentLayoutItem != null)
		{
			documentContextMenu.PlacementTarget = null;
			documentContextMenu.Placement = PlacementMode.MousePoint;
			documentContextMenu.DataContext = RootDocumentLayoutItem;
			documentContextMenu.IsOpen = true;
			return true;
		}
		return false;
	}
}
