using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock.Themes;

namespace Xceed.Wpf.AvalonDock.Controls;

public class OverlayWindow : Window, IOverlayWindow
{
	private ResourceDictionary currentThemeResourceDictionary;

	private Canvas _mainCanvasPanel;

	private Grid _gridDockingManagerDropTargets;

	private Grid _gridAnchorablePaneDropTargets;

	private Grid _gridDocumentPaneDropTargets;

	private Grid _gridDocumentPaneFullDropTargets;

	private FrameworkElement _dockingManagerDropTargetBottom;

	private FrameworkElement _dockingManagerDropTargetTop;

	private FrameworkElement _dockingManagerDropTargetLeft;

	private FrameworkElement _dockingManagerDropTargetRight;

	private FrameworkElement _anchorablePaneDropTargetBottom;

	private FrameworkElement _anchorablePaneDropTargetTop;

	private FrameworkElement _anchorablePaneDropTargetLeft;

	private FrameworkElement _anchorablePaneDropTargetRight;

	private FrameworkElement _anchorablePaneDropTargetInto;

	private FrameworkElement _documentPaneDropTargetBottom;

	private FrameworkElement _documentPaneDropTargetTop;

	private FrameworkElement _documentPaneDropTargetLeft;

	private FrameworkElement _documentPaneDropTargetRight;

	private FrameworkElement _documentPaneDropTargetInto;

	private FrameworkElement _documentPaneDropTargetBottomAsAnchorablePane;

	private FrameworkElement _documentPaneDropTargetTopAsAnchorablePane;

	private FrameworkElement _documentPaneDropTargetLeftAsAnchorablePane;

	private FrameworkElement _documentPaneDropTargetRightAsAnchorablePane;

	private FrameworkElement _documentPaneFullDropTargetBottom;

	private FrameworkElement _documentPaneFullDropTargetTop;

	private FrameworkElement _documentPaneFullDropTargetLeft;

	private FrameworkElement _documentPaneFullDropTargetRight;

	private FrameworkElement _documentPaneFullDropTargetInto;

	private Path _previewBox;

	private IOverlayWindowHost _host;

	private LayoutFloatingWindowControl _floatingWindow;

	private List<IDropArea> _visibleAreas = new List<IDropArea>();

	static OverlayWindow()
	{
		FrameworkElement.DefaultStyleKeyProperty.OverrideMetadata(typeof(OverlayWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)typeof(OverlayWindow)));
		Window.AllowsTransparencyProperty.OverrideMetadata(typeof(OverlayWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)true));
		Window.WindowStyleProperty.OverrideMetadata(typeof(OverlayWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)WindowStyle.None));
		Window.ShowInTaskbarProperty.OverrideMetadata(typeof(OverlayWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		Window.ShowActivatedProperty.OverrideMetadata(typeof(OverlayWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)false));
		UIElement.VisibilityProperty.OverrideMetadata(typeof(OverlayWindow), (PropertyMetadata)(object)new FrameworkPropertyMetadata((object)Visibility.Hidden));
	}

	internal OverlayWindow(IOverlayWindowHost host)
	{
		_host = host;
		UpdateThemeResources();
	}

	public override void OnApplyTemplate()
	{
		base.OnApplyTemplate();
		_mainCanvasPanel = GetTemplateChild("PART_DropTargetsContainer") as Canvas;
		_gridDockingManagerDropTargets = GetTemplateChild("PART_DockingManagerDropTargets") as Grid;
		_gridAnchorablePaneDropTargets = GetTemplateChild("PART_AnchorablePaneDropTargets") as Grid;
		_gridDocumentPaneDropTargets = GetTemplateChild("PART_DocumentPaneDropTargets") as Grid;
		_gridDocumentPaneFullDropTargets = GetTemplateChild("PART_DocumentPaneFullDropTargets") as Grid;
		_gridDockingManagerDropTargets.Visibility = Visibility.Hidden;
		_gridAnchorablePaneDropTargets.Visibility = Visibility.Hidden;
		_gridDocumentPaneDropTargets.Visibility = Visibility.Hidden;
		if (_gridDocumentPaneFullDropTargets != null)
		{
			_gridDocumentPaneFullDropTargets.Visibility = Visibility.Hidden;
		}
		_dockingManagerDropTargetBottom = GetTemplateChild("PART_DockingManagerDropTargetBottom") as FrameworkElement;
		_dockingManagerDropTargetTop = GetTemplateChild("PART_DockingManagerDropTargetTop") as FrameworkElement;
		_dockingManagerDropTargetLeft = GetTemplateChild("PART_DockingManagerDropTargetLeft") as FrameworkElement;
		_dockingManagerDropTargetRight = GetTemplateChild("PART_DockingManagerDropTargetRight") as FrameworkElement;
		_anchorablePaneDropTargetBottom = GetTemplateChild("PART_AnchorablePaneDropTargetBottom") as FrameworkElement;
		_anchorablePaneDropTargetTop = GetTemplateChild("PART_AnchorablePaneDropTargetTop") as FrameworkElement;
		_anchorablePaneDropTargetLeft = GetTemplateChild("PART_AnchorablePaneDropTargetLeft") as FrameworkElement;
		_anchorablePaneDropTargetRight = GetTemplateChild("PART_AnchorablePaneDropTargetRight") as FrameworkElement;
		_anchorablePaneDropTargetInto = GetTemplateChild("PART_AnchorablePaneDropTargetInto") as FrameworkElement;
		_documentPaneDropTargetBottom = GetTemplateChild("PART_DocumentPaneDropTargetBottom") as FrameworkElement;
		_documentPaneDropTargetTop = GetTemplateChild("PART_DocumentPaneDropTargetTop") as FrameworkElement;
		_documentPaneDropTargetLeft = GetTemplateChild("PART_DocumentPaneDropTargetLeft") as FrameworkElement;
		_documentPaneDropTargetRight = GetTemplateChild("PART_DocumentPaneDropTargetRight") as FrameworkElement;
		_documentPaneDropTargetInto = GetTemplateChild("PART_DocumentPaneDropTargetInto") as FrameworkElement;
		_documentPaneDropTargetBottomAsAnchorablePane = GetTemplateChild("PART_DocumentPaneDropTargetBottomAsAnchorablePane") as FrameworkElement;
		_documentPaneDropTargetTopAsAnchorablePane = GetTemplateChild("PART_DocumentPaneDropTargetTopAsAnchorablePane") as FrameworkElement;
		_documentPaneDropTargetLeftAsAnchorablePane = GetTemplateChild("PART_DocumentPaneDropTargetLeftAsAnchorablePane") as FrameworkElement;
		_documentPaneDropTargetRightAsAnchorablePane = GetTemplateChild("PART_DocumentPaneDropTargetRightAsAnchorablePane") as FrameworkElement;
		_documentPaneFullDropTargetBottom = GetTemplateChild("PART_DocumentPaneFullDropTargetBottom") as FrameworkElement;
		_documentPaneFullDropTargetTop = GetTemplateChild("PART_DocumentPaneFullDropTargetTop") as FrameworkElement;
		_documentPaneFullDropTargetLeft = GetTemplateChild("PART_DocumentPaneFullDropTargetLeft") as FrameworkElement;
		_documentPaneFullDropTargetRight = GetTemplateChild("PART_DocumentPaneFullDropTargetRight") as FrameworkElement;
		_documentPaneFullDropTargetInto = GetTemplateChild("PART_DocumentPaneFullDropTargetInto") as FrameworkElement;
		_previewBox = GetTemplateChild("PART_PreviewBox") as Path;
	}

	protected override void OnClosing(CancelEventArgs e)
	{
		base.OnClosing(e);
	}

	internal void UpdateThemeResources(Theme oldTheme = null)
	{
		if (oldTheme != null)
		{
			if (oldTheme is DictionaryTheme)
			{
				if (currentThemeResourceDictionary != null)
				{
					base.Resources.MergedDictionaries.Remove(currentThemeResourceDictionary);
					currentThemeResourceDictionary = null;
				}
			}
			else
			{
				ResourceDictionary resourceDictionary = base.Resources.MergedDictionaries.FirstOrDefault((ResourceDictionary r) => r.Source == oldTheme.GetResourceUri());
				if (resourceDictionary != null)
				{
					base.Resources.MergedDictionaries.Remove(resourceDictionary);
				}
			}
		}
		if (_host.Manager.Theme != null)
		{
			if (_host.Manager.Theme is DictionaryTheme)
			{
				currentThemeResourceDictionary = ((DictionaryTheme)_host.Manager.Theme).ThemeResourceDictionary;
				base.Resources.MergedDictionaries.Add(currentThemeResourceDictionary);
			}
			else
			{
				base.Resources.MergedDictionaries.Add(new ResourceDictionary
				{
					Source = _host.Manager.Theme.GetResourceUri()
				});
			}
		}
	}

	internal void EnableDropTargets()
	{
		if (_mainCanvasPanel != null)
		{
			_mainCanvasPanel.Visibility = Visibility.Visible;
		}
	}

	internal void HideDropTargets()
	{
		if (_mainCanvasPanel != null)
		{
			_mainCanvasPanel.Visibility = Visibility.Hidden;
		}
	}

	private void SetDropTargetIntoVisibility(ILayoutPositionableElement positionableElement)
	{
		if (positionableElement is LayoutAnchorablePane)
		{
			_anchorablePaneDropTargetInto.Visibility = Visibility.Visible;
		}
		else if (positionableElement is LayoutDocumentPane)
		{
			_documentPaneDropTargetInto.Visibility = Visibility.Visible;
		}
		if (positionableElement == null || _floatingWindow.Model == null || positionableElement.AllowDuplicateContent)
		{
			return;
		}
		List<LayoutContent> allLayoutContents = GetAllLayoutContents(positionableElement);
		foreach (LayoutContent content in GetAllLayoutContents(_floatingWindow.Model))
		{
			if (allLayoutContents.Any((LayoutContent item) => item.Title == content.Title && item.ContentId == content.ContentId))
			{
				if (positionableElement is LayoutAnchorablePane)
				{
					_anchorablePaneDropTargetInto.Visibility = Visibility.Hidden;
				}
				else if (positionableElement is LayoutDocumentPane)
				{
					_documentPaneDropTargetInto.Visibility = Visibility.Hidden;
				}
				break;
			}
		}
	}

	private List<LayoutContent> GetAllLayoutContents(object source)
	{
		List<LayoutContent> list = new List<LayoutContent>();
		if (source is LayoutDocumentFloatingWindow layoutDocumentFloatingWindow)
		{
			foreach (ILayoutElement child in layoutDocumentFloatingWindow.Children)
			{
				list.AddRange(GetAllLayoutContents(child));
			}
		}
		if (source is LayoutAnchorableFloatingWindow layoutAnchorableFloatingWindow)
		{
			foreach (ILayoutElement child2 in layoutAnchorableFloatingWindow.Children)
			{
				list.AddRange(GetAllLayoutContents(child2));
			}
		}
		if (source is LayoutDocumentPaneGroup layoutDocumentPaneGroup)
		{
			foreach (ILayoutDocumentPane child3 in layoutDocumentPaneGroup.Children)
			{
				list.AddRange(GetAllLayoutContents(child3));
			}
		}
		if (source is LayoutAnchorablePaneGroup layoutAnchorablePaneGroup)
		{
			foreach (ILayoutAnchorablePane child4 in layoutAnchorablePaneGroup.Children)
			{
				list.AddRange(GetAllLayoutContents(child4));
			}
		}
		if (source is LayoutDocumentPane layoutDocumentPane)
		{
			foreach (LayoutContent child5 in layoutDocumentPane.Children)
			{
				list.Add(child5);
			}
		}
		if (source is LayoutAnchorablePane layoutAnchorablePane)
		{
			foreach (LayoutAnchorable child6 in layoutAnchorablePane.Children)
			{
				list.Add(child6);
			}
		}
		if (source is LayoutDocument item)
		{
			list.Add(item);
		}
		if (source is LayoutAnchorable item2)
		{
			list.Add(item2);
		}
		return list;
	}

	IEnumerable<IDropTarget> IOverlayWindow.GetTargets()
	{
		Rect detectionRect = default(Rect);
		Rect detectionRect2 = default(Rect);
		Rect detectionRect3 = default(Rect);
		foreach (IDropArea visibleArea in _visibleAreas)
		{
			Rect screenArea;
			switch (visibleArea.Type)
			{
			case DropAreaType.DockingManager:
			{
				DropArea<DockingManager> dropAreaDockingManager = visibleArea as DropArea<DockingManager>;
				yield return new DockingManagerDropTarget(dropAreaDockingManager.AreaElement, _dockingManagerDropTargetLeft.GetScreenArea(), DropTargetType.DockingManagerDockLeft);
				yield return new DockingManagerDropTarget(dropAreaDockingManager.AreaElement, _dockingManagerDropTargetTop.GetScreenArea(), DropTargetType.DockingManagerDockTop);
				yield return new DockingManagerDropTarget(dropAreaDockingManager.AreaElement, _dockingManagerDropTargetBottom.GetScreenArea(), DropTargetType.DockingManagerDockBottom);
				yield return new DockingManagerDropTarget(dropAreaDockingManager.AreaElement, _dockingManagerDropTargetRight.GetScreenArea(), DropTargetType.DockingManagerDockRight);
				break;
			}
			case DropAreaType.AnchorablePane:
			{
				DropArea<LayoutAnchorablePaneControl> dropAreaAnchorablePane = visibleArea as DropArea<LayoutAnchorablePaneControl>;
				yield return new AnchorablePaneDropTarget(dropAreaAnchorablePane.AreaElement, _anchorablePaneDropTargetLeft.GetScreenArea(), DropTargetType.AnchorablePaneDockLeft);
				yield return new AnchorablePaneDropTarget(dropAreaAnchorablePane.AreaElement, _anchorablePaneDropTargetTop.GetScreenArea(), DropTargetType.AnchorablePaneDockTop);
				yield return new AnchorablePaneDropTarget(dropAreaAnchorablePane.AreaElement, _anchorablePaneDropTargetRight.GetScreenArea(), DropTargetType.AnchorablePaneDockRight);
				yield return new AnchorablePaneDropTarget(dropAreaAnchorablePane.AreaElement, _anchorablePaneDropTargetBottom.GetScreenArea(), DropTargetType.AnchorablePaneDockBottom);
				if (_anchorablePaneDropTargetInto.IsVisible)
				{
					yield return new AnchorablePaneDropTarget(dropAreaAnchorablePane.AreaElement, _anchorablePaneDropTargetInto.GetScreenArea(), DropTargetType.AnchorablePaneDockInside);
				}
				LayoutAnchorablePane parentPaneModel = dropAreaAnchorablePane.AreaElement.Model as LayoutAnchorablePane;
				LayoutAnchorableTabItem lastAreaTabItem = null;
				foreach (LayoutAnchorableTabItem item2 in ((DependencyObject)(object)dropAreaAnchorablePane.AreaElement).FindVisualChildren<LayoutAnchorableTabItem>())
				{
					LayoutAnchorable item = item2.Model as LayoutAnchorable;
					LayoutAnchorableTabItem layoutAnchorableTabItem;
					if (lastAreaTabItem != null)
					{
						screenArea = lastAreaTabItem.GetScreenArea();
						double right = ((Rect)(ref screenArea)).Right;
						screenArea = item2.GetScreenArea();
						if (!(right < ((Rect)(ref screenArea)).Right))
						{
							layoutAnchorableTabItem = lastAreaTabItem;
							goto IL_03bd;
						}
					}
					layoutAnchorableTabItem = item2;
					goto IL_03bd;
					IL_03bd:
					lastAreaTabItem = layoutAnchorableTabItem;
					int tabIndex = parentPaneModel.Children.IndexOf(item);
					yield return new AnchorablePaneDropTarget(dropAreaAnchorablePane.AreaElement, item2.GetScreenArea(), DropTargetType.AnchorablePaneDockInside, tabIndex);
				}
				if (lastAreaTabItem != null)
				{
					Rect screenArea2 = lastAreaTabItem.GetScreenArea();
					((Rect)(ref detectionRect))._002Ector(((Rect)(ref screenArea2)).TopRight, new Point(((Rect)(ref screenArea2)).Right + ((Rect)(ref screenArea2)).Width, ((Rect)(ref screenArea2)).Bottom));
					double right2 = ((Rect)(ref detectionRect)).Right;
					screenArea = dropAreaAnchorablePane.AreaElement.GetScreenArea();
					if (right2 < ((Rect)(ref screenArea)).Right)
					{
						yield return new AnchorablePaneDropTarget(dropAreaAnchorablePane.AreaElement, detectionRect, DropTargetType.AnchorablePaneDockInside, parentPaneModel.Children.Count);
					}
				}
				AnchorablePaneTitle anchorablePaneTitle = ((DependencyObject)(object)dropAreaAnchorablePane.AreaElement).FindVisualChildren<AnchorablePaneTitle>().FirstOrDefault();
				if (anchorablePaneTitle != null)
				{
					yield return new AnchorablePaneDropTarget(dropAreaAnchorablePane.AreaElement, anchorablePaneTitle.GetScreenArea(), DropTargetType.AnchorablePaneDockInside);
				}
				break;
			}
			case DropAreaType.DocumentPane:
			{
				DropArea<LayoutDocumentPaneControl> dropAreaDocumentPane;
				LayoutDocumentPane parentPaneModel2;
				LayoutDocumentTabItem lastAreaTabItem2;
				if (_floatingWindow.Model is LayoutAnchorableFloatingWindow && _gridDocumentPaneFullDropTargets != null)
				{
					dropAreaDocumentPane = visibleArea as DropArea<LayoutDocumentPaneControl>;
					if (_documentPaneFullDropTargetLeft.IsVisible)
					{
						yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, _documentPaneFullDropTargetLeft.GetScreenArea(), DropTargetType.DocumentPaneDockLeft);
					}
					if (_documentPaneFullDropTargetTop.IsVisible)
					{
						yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, _documentPaneFullDropTargetTop.GetScreenArea(), DropTargetType.DocumentPaneDockTop);
					}
					if (_documentPaneFullDropTargetRight.IsVisible)
					{
						yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, _documentPaneFullDropTargetRight.GetScreenArea(), DropTargetType.DocumentPaneDockRight);
					}
					if (_documentPaneFullDropTargetBottom.IsVisible)
					{
						yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, _documentPaneFullDropTargetBottom.GetScreenArea(), DropTargetType.DocumentPaneDockBottom);
					}
					if (_documentPaneFullDropTargetInto.IsVisible)
					{
						yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, _documentPaneFullDropTargetInto.GetScreenArea(), DropTargetType.DocumentPaneDockInside);
					}
					parentPaneModel2 = dropAreaDocumentPane.AreaElement.Model as LayoutDocumentPane;
					lastAreaTabItem2 = null;
					foreach (LayoutDocumentTabItem item3 in ((DependencyObject)(object)dropAreaDocumentPane.AreaElement).FindVisualChildren<LayoutDocumentTabItem>())
					{
						LayoutContent model = item3.Model;
						LayoutDocumentTabItem layoutDocumentTabItem;
						if (lastAreaTabItem2 != null)
						{
							screenArea = lastAreaTabItem2.GetScreenArea();
							double right3 = ((Rect)(ref screenArea)).Right;
							screenArea = item3.GetScreenArea();
							if (!(right3 < ((Rect)(ref screenArea)).Right))
							{
								layoutDocumentTabItem = lastAreaTabItem2;
								goto IL_0760;
							}
						}
						layoutDocumentTabItem = item3;
						goto IL_0760;
						IL_0760:
						lastAreaTabItem2 = layoutDocumentTabItem;
						int tabIndex2 = parentPaneModel2.Children.IndexOf(model);
						yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, item3.GetScreenArea(), DropTargetType.DocumentPaneDockInside, tabIndex2);
					}
					if (lastAreaTabItem2 != null)
					{
						Rect screenArea3 = lastAreaTabItem2.GetScreenArea();
						((Rect)(ref detectionRect2))._002Ector(((Rect)(ref screenArea3)).TopRight, new Point(((Rect)(ref screenArea3)).Right + ((Rect)(ref screenArea3)).Width, ((Rect)(ref screenArea3)).Bottom));
						double right4 = ((Rect)(ref detectionRect2)).Right;
						screenArea = dropAreaDocumentPane.AreaElement.GetScreenArea();
						if (right4 < ((Rect)(ref screenArea)).Right)
						{
							yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, detectionRect2, DropTargetType.DocumentPaneDockInside, parentPaneModel2.Children.Count);
						}
					}
					if (_documentPaneDropTargetLeftAsAnchorablePane.IsVisible)
					{
						yield return new DocumentPaneDropAsAnchorableTarget(dropAreaDocumentPane.AreaElement, _documentPaneDropTargetLeftAsAnchorablePane.GetScreenArea(), DropTargetType.DocumentPaneDockAsAnchorableLeft);
					}
					if (_documentPaneDropTargetTopAsAnchorablePane.IsVisible)
					{
						yield return new DocumentPaneDropAsAnchorableTarget(dropAreaDocumentPane.AreaElement, _documentPaneDropTargetTopAsAnchorablePane.GetScreenArea(), DropTargetType.DocumentPaneDockAsAnchorableTop);
					}
					if (_documentPaneDropTargetRightAsAnchorablePane.IsVisible)
					{
						yield return new DocumentPaneDropAsAnchorableTarget(dropAreaDocumentPane.AreaElement, _documentPaneDropTargetRightAsAnchorablePane.GetScreenArea(), DropTargetType.DocumentPaneDockAsAnchorableRight);
					}
					if (_documentPaneDropTargetBottomAsAnchorablePane.IsVisible)
					{
						yield return new DocumentPaneDropAsAnchorableTarget(dropAreaDocumentPane.AreaElement, _documentPaneDropTargetBottomAsAnchorablePane.GetScreenArea(), DropTargetType.DocumentPaneDockAsAnchorableBottom);
					}
					break;
				}
				dropAreaDocumentPane = visibleArea as DropArea<LayoutDocumentPaneControl>;
				if (_documentPaneDropTargetLeft.IsVisible)
				{
					yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, _documentPaneDropTargetLeft.GetScreenArea(), DropTargetType.DocumentPaneDockLeft);
				}
				if (_documentPaneDropTargetTop.IsVisible)
				{
					yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, _documentPaneDropTargetTop.GetScreenArea(), DropTargetType.DocumentPaneDockTop);
				}
				if (_documentPaneDropTargetRight.IsVisible)
				{
					yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, _documentPaneDropTargetRight.GetScreenArea(), DropTargetType.DocumentPaneDockRight);
				}
				if (_documentPaneDropTargetBottom.IsVisible)
				{
					yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, _documentPaneDropTargetBottom.GetScreenArea(), DropTargetType.DocumentPaneDockBottom);
				}
				if (_documentPaneDropTargetInto.IsVisible)
				{
					yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, _documentPaneDropTargetInto.GetScreenArea(), DropTargetType.DocumentPaneDockInside);
				}
				parentPaneModel2 = dropAreaDocumentPane.AreaElement.Model as LayoutDocumentPane;
				lastAreaTabItem2 = null;
				foreach (LayoutDocumentTabItem item4 in ((DependencyObject)(object)dropAreaDocumentPane.AreaElement).FindVisualChildren<LayoutDocumentTabItem>())
				{
					LayoutContent model2 = item4.Model;
					LayoutDocumentTabItem layoutDocumentTabItem2;
					if (lastAreaTabItem2 != null)
					{
						screenArea = lastAreaTabItem2.GetScreenArea();
						double right5 = ((Rect)(ref screenArea)).Right;
						screenArea = item4.GetScreenArea();
						if (!(right5 < ((Rect)(ref screenArea)).Right))
						{
							layoutDocumentTabItem2 = lastAreaTabItem2;
							goto IL_0ba9;
						}
					}
					layoutDocumentTabItem2 = item4;
					goto IL_0ba9;
					IL_0ba9:
					lastAreaTabItem2 = layoutDocumentTabItem2;
					int tabIndex3 = parentPaneModel2.Children.IndexOf(model2);
					yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, item4.GetScreenArea(), DropTargetType.DocumentPaneDockInside, tabIndex3);
				}
				if (lastAreaTabItem2 != null)
				{
					Rect screenArea4 = lastAreaTabItem2.GetScreenArea();
					((Rect)(ref detectionRect3))._002Ector(((Rect)(ref screenArea4)).TopRight, new Point(((Rect)(ref screenArea4)).Right + ((Rect)(ref screenArea4)).Width, ((Rect)(ref screenArea4)).Bottom));
					double right6 = ((Rect)(ref detectionRect3)).Right;
					screenArea = dropAreaDocumentPane.AreaElement.GetScreenArea();
					if (right6 < ((Rect)(ref screenArea)).Right)
					{
						yield return new DocumentPaneDropTarget(dropAreaDocumentPane.AreaElement, detectionRect3, DropTargetType.DocumentPaneDockInside, parentPaneModel2.Children.Count);
					}
				}
				break;
			}
			case DropAreaType.DocumentPaneGroup:
			{
				DropArea<LayoutDocumentPaneGroupControl> dropArea = visibleArea as DropArea<LayoutDocumentPaneGroupControl>;
				if (_documentPaneDropTargetInto.IsVisible)
				{
					yield return new DocumentPaneGroupDropTarget(dropArea.AreaElement, _documentPaneDropTargetInto.GetScreenArea(), DropTargetType.DocumentPaneGroupDockInside);
				}
				break;
			}
			}
		}
	}

	void IOverlayWindow.DragEnter(LayoutFloatingWindowControl floatingWindow)
	{
		_floatingWindow = floatingWindow;
		EnableDropTargets();
	}

	void IOverlayWindow.DragLeave(LayoutFloatingWindowControl floatingWindow)
	{
		base.Visibility = Visibility.Hidden;
		_floatingWindow = null;
	}

	void IOverlayWindow.DragEnter(IDropArea area)
	{
		//IL_063f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0644: Unknown result type (might be due to invalid IL or missing references)
		//IL_065b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0660: Unknown result type (might be due to invalid IL or missing references)
		//IL_0677: Unknown result type (might be due to invalid IL or missing references)
		//IL_067c: Unknown result type (might be due to invalid IL or missing references)
		//IL_068c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		DockingManager manager = _floatingWindow.Model.Root.Manager;
		_visibleAreas.Add(area);
		FrameworkElement frameworkElement;
		switch (area.Type)
		{
		case DropAreaType.DockingManager:
			if ((area as DropArea<DockingManager>).AreaElement != manager)
			{
				_visibleAreas.Remove(area);
				return;
			}
			frameworkElement = _gridDockingManagerDropTargets;
			break;
		case DropAreaType.AnchorablePane:
		{
			frameworkElement = _gridAnchorablePaneDropTargets;
			LayoutAnchorablePane layoutAnchorablePane = (area as DropArea<LayoutAnchorablePaneControl>).AreaElement.Model as LayoutAnchorablePane;
			if (layoutAnchorablePane.Root.Manager != manager)
			{
				_visibleAreas.Remove(area);
				return;
			}
			SetDropTargetIntoVisibility(layoutAnchorablePane);
			break;
		}
		case DropAreaType.DocumentPaneGroup:
			frameworkElement = _gridDocumentPaneDropTargets;
			if (((((area as DropArea<LayoutDocumentPaneGroupControl>).AreaElement.Model as LayoutDocumentPaneGroup).Children.First() as LayoutDocumentPane).Parent as LayoutDocumentPaneGroup).Root.Manager != manager)
			{
				_visibleAreas.Remove(area);
				return;
			}
			_documentPaneDropTargetLeft.Visibility = Visibility.Hidden;
			_documentPaneDropTargetRight.Visibility = Visibility.Hidden;
			_documentPaneDropTargetTop.Visibility = Visibility.Hidden;
			_documentPaneDropTargetBottom.Visibility = Visibility.Hidden;
			break;
		default:
		{
			if (_floatingWindow.Model is LayoutAnchorableFloatingWindow && _gridDocumentPaneFullDropTargets != null)
			{
				frameworkElement = _gridDocumentPaneFullDropTargets;
				LayoutDocumentPane layoutDocumentPane = (area as DropArea<LayoutDocumentPaneControl>).AreaElement.Model as LayoutDocumentPane;
				LayoutDocumentPaneGroup layoutDocumentPaneGroup = layoutDocumentPane.Parent as LayoutDocumentPaneGroup;
				if (layoutDocumentPane.Root.Manager != manager)
				{
					_visibleAreas.Remove(area);
					return;
				}
				SetDropTargetIntoVisibility(layoutDocumentPane);
				if (layoutDocumentPaneGroup != null && layoutDocumentPaneGroup.Children.Where((ILayoutDocumentPane c) => c.IsVisible).Count() > 1)
				{
					if (!layoutDocumentPaneGroup.Root.Manager.AllowMixedOrientation)
					{
						_documentPaneFullDropTargetLeft.Visibility = ((layoutDocumentPaneGroup.Orientation != Orientation.Horizontal) ? Visibility.Hidden : Visibility.Visible);
						_documentPaneFullDropTargetRight.Visibility = ((layoutDocumentPaneGroup.Orientation != Orientation.Horizontal) ? Visibility.Hidden : Visibility.Visible);
						_documentPaneFullDropTargetTop.Visibility = ((layoutDocumentPaneGroup.Orientation != Orientation.Vertical) ? Visibility.Hidden : Visibility.Visible);
						_documentPaneFullDropTargetBottom.Visibility = ((layoutDocumentPaneGroup.Orientation != Orientation.Vertical) ? Visibility.Hidden : Visibility.Visible);
					}
					else
					{
						_documentPaneFullDropTargetLeft.Visibility = Visibility.Visible;
						_documentPaneFullDropTargetRight.Visibility = Visibility.Visible;
						_documentPaneFullDropTargetTop.Visibility = Visibility.Visible;
						_documentPaneFullDropTargetBottom.Visibility = Visibility.Visible;
					}
				}
				else if (layoutDocumentPaneGroup == null && layoutDocumentPane != null && layoutDocumentPane.ChildrenCount == 0)
				{
					_documentPaneFullDropTargetLeft.Visibility = Visibility.Hidden;
					_documentPaneFullDropTargetRight.Visibility = Visibility.Hidden;
					_documentPaneFullDropTargetTop.Visibility = Visibility.Hidden;
					_documentPaneFullDropTargetBottom.Visibility = Visibility.Hidden;
				}
				else
				{
					_documentPaneFullDropTargetLeft.Visibility = Visibility.Visible;
					_documentPaneFullDropTargetRight.Visibility = Visibility.Visible;
					_documentPaneFullDropTargetTop.Visibility = Visibility.Visible;
					_documentPaneFullDropTargetBottom.Visibility = Visibility.Visible;
				}
				if (layoutDocumentPaneGroup != null && layoutDocumentPaneGroup.Children.Where((ILayoutDocumentPane c) => c.IsVisible).Count() > 1)
				{
					int num = layoutDocumentPaneGroup.Children.Where((ILayoutDocumentPane ch) => ch.IsVisible).ToList().IndexOf(layoutDocumentPane);
					bool flag = num == 0;
					bool flag2 = num == layoutDocumentPaneGroup.ChildrenCount - 1;
					if (!layoutDocumentPaneGroup.Root.Manager.AllowMixedOrientation)
					{
						_documentPaneDropTargetBottomAsAnchorablePane.Visibility = ((layoutDocumentPaneGroup.Orientation != Orientation.Vertical || !flag2) ? Visibility.Hidden : Visibility.Visible);
						_documentPaneDropTargetTopAsAnchorablePane.Visibility = ((layoutDocumentPaneGroup.Orientation != Orientation.Vertical || !flag) ? Visibility.Hidden : Visibility.Visible);
						_documentPaneDropTargetLeftAsAnchorablePane.Visibility = ((layoutDocumentPaneGroup.Orientation != Orientation.Horizontal || !flag) ? Visibility.Hidden : Visibility.Visible);
						_documentPaneDropTargetRightAsAnchorablePane.Visibility = ((layoutDocumentPaneGroup.Orientation != Orientation.Horizontal || !flag2) ? Visibility.Hidden : Visibility.Visible);
					}
					else
					{
						_documentPaneDropTargetBottomAsAnchorablePane.Visibility = Visibility.Visible;
						_documentPaneDropTargetLeftAsAnchorablePane.Visibility = Visibility.Visible;
						_documentPaneDropTargetRightAsAnchorablePane.Visibility = Visibility.Visible;
						_documentPaneDropTargetTopAsAnchorablePane.Visibility = Visibility.Visible;
					}
				}
				else
				{
					_documentPaneDropTargetBottomAsAnchorablePane.Visibility = Visibility.Visible;
					_documentPaneDropTargetLeftAsAnchorablePane.Visibility = Visibility.Visible;
					_documentPaneDropTargetRightAsAnchorablePane.Visibility = Visibility.Visible;
					_documentPaneDropTargetTopAsAnchorablePane.Visibility = Visibility.Visible;
				}
				break;
			}
			frameworkElement = _gridDocumentPaneDropTargets;
			LayoutDocumentPane layoutDocumentPane2 = (area as DropArea<LayoutDocumentPaneControl>).AreaElement.Model as LayoutDocumentPane;
			LayoutDocumentPaneGroup layoutDocumentPaneGroup2 = layoutDocumentPane2.Parent as LayoutDocumentPaneGroup;
			if (layoutDocumentPane2.Root.Manager != manager)
			{
				_visibleAreas.Remove(area);
				return;
			}
			SetDropTargetIntoVisibility(layoutDocumentPane2);
			if (layoutDocumentPaneGroup2 != null && layoutDocumentPaneGroup2.Children.Where((ILayoutDocumentPane c) => c.IsVisible).Count() > 1)
			{
				if (!layoutDocumentPaneGroup2.Root.Manager.AllowMixedOrientation)
				{
					_documentPaneDropTargetLeft.Visibility = ((layoutDocumentPaneGroup2.Orientation != Orientation.Horizontal) ? Visibility.Hidden : Visibility.Visible);
					_documentPaneDropTargetRight.Visibility = ((layoutDocumentPaneGroup2.Orientation != Orientation.Horizontal) ? Visibility.Hidden : Visibility.Visible);
					_documentPaneDropTargetTop.Visibility = ((layoutDocumentPaneGroup2.Orientation != Orientation.Vertical) ? Visibility.Hidden : Visibility.Visible);
					_documentPaneDropTargetBottom.Visibility = ((layoutDocumentPaneGroup2.Orientation != Orientation.Vertical) ? Visibility.Hidden : Visibility.Visible);
				}
				else
				{
					_documentPaneDropTargetLeft.Visibility = Visibility.Visible;
					_documentPaneDropTargetRight.Visibility = Visibility.Visible;
					_documentPaneDropTargetTop.Visibility = Visibility.Visible;
					_documentPaneDropTargetBottom.Visibility = Visibility.Visible;
				}
			}
			else if (layoutDocumentPaneGroup2 == null && layoutDocumentPane2 != null && layoutDocumentPane2.ChildrenCount == 0)
			{
				_documentPaneDropTargetLeft.Visibility = Visibility.Hidden;
				_documentPaneDropTargetRight.Visibility = Visibility.Hidden;
				_documentPaneDropTargetTop.Visibility = Visibility.Hidden;
				_documentPaneDropTargetBottom.Visibility = Visibility.Hidden;
			}
			else
			{
				_documentPaneDropTargetLeft.Visibility = Visibility.Visible;
				_documentPaneDropTargetRight.Visibility = Visibility.Visible;
				_documentPaneDropTargetTop.Visibility = Visibility.Visible;
				_documentPaneDropTargetBottom.Visibility = Visibility.Visible;
			}
			break;
		}
		}
		FrameworkElement element = frameworkElement;
		Rect detectionRect = area.DetectionRect;
		Canvas.SetLeft(element, ((Rect)(ref detectionRect)).Left - base.Left);
		FrameworkElement element2 = frameworkElement;
		detectionRect = area.DetectionRect;
		Canvas.SetTop(element2, ((Rect)(ref detectionRect)).Top - base.Top);
		FrameworkElement frameworkElement2 = frameworkElement;
		detectionRect = area.DetectionRect;
		frameworkElement2.Width = ((Rect)(ref detectionRect)).Width;
		FrameworkElement frameworkElement3 = frameworkElement;
		detectionRect = area.DetectionRect;
		frameworkElement3.Height = ((Rect)(ref detectionRect)).Height;
		frameworkElement.Visibility = Visibility.Visible;
	}

	void IOverlayWindow.DragLeave(IDropArea area)
	{
		_visibleAreas.Remove(area);
		(area.Type switch
		{
			DropAreaType.DockingManager => _gridDockingManagerDropTargets, 
			DropAreaType.AnchorablePane => _gridAnchorablePaneDropTargets, 
			DropAreaType.DocumentPaneGroup => _gridDocumentPaneDropTargets, 
			_ => (!(_floatingWindow.Model is LayoutAnchorableFloatingWindow) || _gridDocumentPaneFullDropTargets == null) ? _gridDocumentPaneDropTargets : _gridDocumentPaneFullDropTargets, 
		}).Visibility = Visibility.Hidden;
	}

	void IOverlayWindow.DragEnter(IDropTarget target)
	{
		Geometry previewPath = target.GetPreviewPath(this, _floatingWindow.Model as LayoutFloatingWindow);
		if (previewPath != null)
		{
			_previewBox.Data = previewPath;
			_previewBox.Visibility = Visibility.Visible;
		}
	}

	void IOverlayWindow.DragLeave(IDropTarget target)
	{
		_previewBox.Visibility = Visibility.Hidden;
	}

	void IOverlayWindow.DragDrop(IDropTarget target)
	{
		target.Drop(_floatingWindow.Model as LayoutFloatingWindow);
	}
}
