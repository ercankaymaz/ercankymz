using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using MS.Internal.Properties;
using MS.Internal.Transforms;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Metadata;
using Microsoft.Windows.Design.Model;
using Microsoft.Windows.Design.Services;

namespace MS.Internal.Automation;

internal class DesignerItemAutomationPeer : AutomationPeer, ISelectionItemProvider, IDisposable
{
	private const int MAX_CLICK_POINTS_TESTS = 1000;

	private const string _xmlns = "http://schemas.microsoft.com/winfx/2006/xaml/presentation";

	private ModelItem _item;

	private DesignerView _view;

	private ModelService _modelService;

	private Hashtable _dataChildren;

	private DesignerViewAutomationPeer _viewPeer;

	private bool _disposed;

	private static readonly TypeIdentifier Type = new TypeIdentifier("http://schemas.microsoft.com/winfx/2006/xaml/presentation", "AutomationProperties");

	private static readonly PropertyIdentifier AutomationIdProperty = new PropertyIdentifier(Type, "AutomationId");

	private static readonly PropertyIdentifier HelpTextProperty = new PropertyIdentifier(Type, "HelpText");

	private static readonly PropertyIdentifier NameProperty = new PropertyIdentifier(Type, "Name");

	private ModelService ModelService
	{
		get
		{
			if (_modelService == null && _view.Context != null)
			{
				_modelService = _view.Context.Services.GetService<ModelService>();
			}
			return _modelService;
		}
	}

	private ViewItem ViewItem => _item.View;

	public bool IsSelected
	{
		get
		{
			Selection value = _view.Context.Items.GetValue<Selection>();
			foreach (ModelItem selectedObject in value.SelectedObjects)
			{
				if (_item == selectedObject)
				{
					return true;
				}
			}
			return false;
		}
	}

	public IRawElementProviderSimple SelectionContainer => _viewPeer.GetProviderFromPeer((AutomationPeer)(object)_viewPeer);

	public DesignerItemAutomationPeer(ModelItem item, DesignerViewAutomationPeer peer)
	{
		_item = item;
		_view = peer.View;
		_viewPeer = peer;
	}

	private string GetModelProperty(PropertyIdentifier property)
	{
		ModelProperty modelProperty = _item.Properties.Find(property);
		if (modelProperty != null)
		{
			return modelProperty.ComputedValue as string;
		}
		return null;
	}

	protected override List<AutomationPeer> GetChildrenCore()
	{
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Expected O, but got Unknown
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Expected O, but got Unknown
		List<AutomationPeer> list = new List<AutomationPeer>();
		List<UIElement> list2 = new List<UIElement>();
		ICollection<UIElement> adorners = _view.Adorners;
		if (adorners != null)
		{
			List<UIElement> list3 = new List<UIElement>(adorners);
			foreach (UIElement item2 in list3)
			{
				ModelItem model = AdornerProperties.GetModel((DependencyObject)(object)item2);
				if (model == _item)
				{
					Panel val = (Panel)(object)((item2 is Panel) ? item2 : null);
					if (val != null)
					{
						foreach (UIElement child in val.Children)
						{
							UIElement item = child;
							list2.Add(item);
						}
					}
					else
					{
						list2.Add(item2);
					}
				}
				else
				{
					if (model != null)
					{
						continue;
					}
					Panel val2 = (Panel)(object)((item2 is Panel) ? item2 : null);
					if (val2 == null)
					{
						continue;
					}
					foreach (UIElement child2 in val2.Children)
					{
						UIElement val3 = child2;
						model = AdornerProperties.GetModel((DependencyObject)(object)val3);
						if (model == _item)
						{
							list2.Add(val3);
						}
					}
				}
			}
		}
		if (list2.Count > 0)
		{
			list.Add((AutomationPeer)(object)new AdornerNodeAutomationPeer(list2));
		}
		PopulateDataChildren(list);
		return list;
	}

	private IEnumerable<ModelItem> GetChildren(ModelItem parent)
	{
		if (parent.ItemType.IsSubclassOf(typeof(UserControl)))
		{
			yield break;
		}
		ModelProperty content = parent.Content;
		if (content == null)
		{
			yield break;
		}
		if (content.IsCollection)
		{
			foreach (ModelItem child in content.Collection)
			{
				if (child.View != null)
				{
					yield return child;
				}
			}
			yield break;
		}
		if (content.Value != null && content.Value.View != null && content.IsSet)
		{
			yield return content.Value;
		}
	}

	private void PopulateDataChildren(List<AutomationPeer> list)
	{
		Hashtable dataChildren = _dataChildren;
		List<ModelItem> list2 = new List<ModelItem>(GetChildren(_item));
		_dataChildren = new Hashtable();
		foreach (ModelItem item in list2)
		{
			DesignerItemAutomationPeer designerItemAutomationPeer = ((dataChildren == null) ? null : ((DesignerItemAutomationPeer)dataChildren[item]));
			if (designerItemAutomationPeer == null)
			{
				designerItemAutomationPeer = new DesignerItemAutomationPeer(item, _viewPeer);
			}
			if (_dataChildren[item] == null)
			{
				_dataChildren.Add(item, designerItemAutomationPeer);
			}
		}
		if (list2 != null)
		{
			for (int num = list2.Count - 1; num >= 0; num--)
			{
				object key = list2[num];
				object obj = _dataChildren[key];
				list.Add((AutomationPeer)((obj is AutomationPeer) ? obj : null));
			}
		}
	}

	public IRawElementProviderSimple GetProviderFromPeer(AutomationPeer peer)
	{
		return ((AutomationPeer)this).ProviderFromPeer(peer);
	}

	public List<IRawElementProviderSimple> GetSelection(object selectedObj)
	{
		if (_dataChildren == null)
		{
			((AutomationPeer)this).GetChildren();
		}
		List<IRawElementProviderSimple> list = new List<IRawElementProviderSimple>();
		if (_dataChildren.ContainsKey(selectedObj))
		{
			if (_dataChildren[selectedObj] is DesignerItemAutomationPeer designerItemAutomationPeer)
			{
				list.Add(((AutomationPeer)designerItemAutomationPeer).ProviderFromPeer((AutomationPeer)(object)designerItemAutomationPeer));
			}
		}
		else
		{
			foreach (DictionaryEntry dataChild in _dataChildren)
			{
				if (dataChild.Value is DesignerItemAutomationPeer designerItemAutomationPeer2)
				{
					list.AddRange(designerItemAutomationPeer2.GetSelection(selectedObj));
				}
			}
		}
		return list;
	}

	protected override AutomationControlType GetAutomationControlTypeCore()
	{
		return (AutomationControlType)25;
	}

	protected override string GetLocalizedControlTypeCore()
	{
		return MS.Internal.Properties.Resources.DesignerItemAutomationPeer_LocalizedControlType;
	}

	protected override string GetAutomationIdCore()
	{
		string text = _item.Name;
		if (string.IsNullOrEmpty(text))
		{
			text = GetModelProperty(AutomationIdProperty);
		}
		return text ?? string.Empty;
	}

	protected override Rect GetBoundingRectangleCore()
	{
		//IL_0141: Unknown result type (might be due to invalid IL or missing references)
		//IL_0147: Unknown result type (might be due to invalid IL or missing references)
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		//IL_011a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0126: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0132: Unknown result type (might be due to invalid IL or missing references)
		//IL_013c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		if (_item.Parent == null && _item != _item.Root && _item.Name != null)
		{
			ModelItem root = ModelService.Root;
			ModelItem modelItem = ModelService.FromName(root, _item.Name, StringComparison.OrdinalIgnoreCase);
			if (modelItem != null)
			{
				_item = modelItem;
			}
		}
		PresentationSource val = PresentationSource.FromVisual((Visual)(object)DesignerView.FromContext(_item.Context));
		if (val != null && val.RootVisual != null && ViewItem.IsVisible)
		{
			Rect selectionFrameBounds = ElementUtilities.GetSelectionFrameBounds(ViewItem);
			if (((Rect)(ref selectionFrameBounds)).Location == new Point(0.0, 0.0) && ((Rect)(ref selectionFrameBounds)).Size == new Size(0.0, 0.0))
			{
				return default(Rect);
			}
			Rect val2 = default(Rect);
			((Rect)(ref val2))._002Ector(((Rect)(ref selectionFrameBounds)).Size);
			Rect val3 = ((GeneralTransform)TransformUtil.GetSelectionFrameTransformToParentVisual(ViewItem, val.RootVisual)).TransformBounds(val2);
			Rect result = default(Rect);
			((Rect)(ref result))._002Ector(val.RootVisual.PointToScreen(((Rect)(ref val3)).Location), ((Rect)(ref val3)).Size);
			return result;
		}
		return default(Rect);
	}

	protected override string GetClassNameCore()
	{
		return _item.ItemType.Name;
	}

	protected override string GetAcceleratorKeyCore()
	{
		return string.Empty;
	}

	protected override string GetAccessKeyCore()
	{
		return string.Empty;
	}

	protected override Point GetClickablePointCore()
	{
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0293: Unknown result type (might be due to invalid IL or missing references)
		//IL_0169: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0176: Unknown result type (might be due to invalid IL or missing references)
		//IL_015a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_019f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01af: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bb: Expected O, but got Unknown
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		if (_item.Parent == null && _item != _item.Root && ModelService != null && _item.Name != null)
		{
			ModelItem root = ModelService.Root;
			if (root != null)
			{
				ModelItem modelItem = ModelService.FromName(root, _item.Name, StringComparison.OrdinalIgnoreCase);
				if (modelItem != null)
				{
					_item = modelItem;
				}
			}
		}
		ViewItem viewItem = ViewItem;
		UIElement view = (UIElement)(object)_view;
		ViewItem viewItem2 = ((ModelService != null && ModelService.Root != null) ? ModelService.Root.View : null);
		if (view == null || viewItem == null || PresentationSource.FromVisual((Visual)(object)view) == null)
		{
			return new Point(0.0, 0.0);
		}
		Rect selectionFrameBounds = viewItem.SelectionFrameBounds;
		double width = ((Rect)(ref selectionFrameBounds)).Width;
		double height = ((Rect)(ref selectionFrameBounds)).Height;
		double num = 2.0;
		int num2 = 0;
		Point result = default(Point);
		Transform selectionFrameTransformToDesignerView = TransformUtil.GetSelectionFrameTransformToDesignerView(_item.Context, viewItem);
		Transform selectionFrameTransformToParentView = TransformUtil.GetSelectionFrameTransformToParentView(viewItem, viewItem2);
		while (num <= width || num <= height)
		{
			int i = 1;
			double num3 = width / num;
			for (; (double)i < num; i++)
			{
				int j = 1;
				double num4 = height / num;
				for (; (double)j < num; j++)
				{
					if (i % 2 != 0 || j % 2 != 0)
					{
						if (++num2 > 1000)
						{
							return default(Point);
						}
						Point point = ((GeneralTransform)selectionFrameTransformToDesignerView).Transform(new Point(num3, num4));
						HitTestResult val = HitTestHelper.HitTest((Visual)(object)view, point, ignoreDisabled: false, null);
						if (val != null && val.VisualHit is DesignerView.OpaqueElement)
						{
							point = ((GeneralTransform)selectionFrameTransformToParentView).Transform(new Point(num3, num4));
							ViewHitTestResult viewHitTestResult = viewItem2.HitTest(null, null, (HitTestParameters)new PointHitTestParameters(point));
							if (viewHitTestResult != null && viewHitTestResult.ViewHit != null)
							{
								ViewItem viewHit = viewHitTestResult.ViewHit;
								bool flag = false;
								if (viewItem != viewHit)
								{
									flag = IsPartOfTemplate(viewItem, viewHitTestResult.ViewHit);
								}
								bool flag2 = false;
								if (viewItem.ItemType.IsSubclassOf(typeof(UserControl)))
								{
									flag2 = viewHitTestResult.ViewHit.IsDescendantOf(viewItem);
								}
								if (viewItem == viewHitTestResult.ViewHit || flag || flag2)
								{
									return viewItem2.PointToScreen(point);
								}
							}
						}
					}
					num4 += height / num;
				}
				num3 += width / num;
			}
			num *= 2.0;
		}
		return result;
	}

	protected override string GetHelpTextCore()
	{
		string text = GetModelProperty(HelpTextProperty);
		if (string.IsNullOrEmpty(text) && TypeDescriptor.GetAttributes(_item)[typeof(DescriptionAttribute)] is DescriptionAttribute descriptionAttribute)
		{
			text = descriptionAttribute.Description;
		}
		return text;
	}

	protected override string GetItemStatusCore()
	{
		return string.Empty;
	}

	protected override string GetItemTypeCore()
	{
		return _item.ItemType.Name;
	}

	protected override AutomationPeer GetLabeledByCore()
	{
		return null;
	}

	protected override AutomationOrientation GetOrientationCore()
	{
		return (AutomationOrientation)0;
	}

	protected override bool HasKeyboardFocusCore()
	{
		return true;
	}

	protected override bool IsEnabledCore()
	{
		return ((AutomationPeer)_viewPeer).IsEnabled();
	}

	protected override bool IsKeyboardFocusableCore()
	{
		return true;
	}

	protected override bool IsOffscreenCore()
	{
		if (ViewItem != null)
		{
			return ViewItem.IsOffscreen;
		}
		return false;
	}

	protected override bool IsPasswordCore()
	{
		return false;
	}

	protected override bool IsRequiredForFormCore()
	{
		return false;
	}

	protected override void SetFocusCore()
	{
		SelectionOperations.SelectOnly(_view.Context, _item);
	}

	protected override string GetNameCore()
	{
		string text = GetModelProperty(NameProperty);
		if (string.IsNullOrEmpty(text))
		{
			text = _item.ItemType.Name;
		}
		return text;
	}

	public override object GetPattern(PatternInterface patternInterface)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0003: Invalid comparison between Unknown and I4
		if ((int)patternInterface == 11)
		{
			return this;
		}
		return null;
	}

	protected override bool IsContentElementCore()
	{
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		using (IEnumerator<object> enumerator = _item.GetAttributes(typeof(ContentPropertyAttribute)).GetEnumerator())
		{
			if (enumerator.MoveNext())
			{
				_ = (ContentPropertyAttribute)enumerator.Current;
				return true;
			}
		}
		return false;
	}

	protected override bool IsControlElementCore()
	{
		return true;
	}

	private static bool IsPartOfTemplate(ViewItem parent, ViewItem childToCheck)
	{
		if (parent == null || childToCheck == null)
		{
			return false;
		}
		if (!childToCheck.IsDescendantOf(parent))
		{
			return false;
		}
		foreach (ViewItem logicalChild in parent.LogicalChildren)
		{
			if (logicalChild == childToCheck)
			{
				return false;
			}
			if (childToCheck.IsDescendantOf(logicalChild))
			{
				return false;
			}
		}
		return true;
	}

	public List<DesignerItemAutomationPeer> GetSelectedAutomationPeers(object selectedObj)
	{
		if (_dataChildren == null)
		{
			((AutomationPeer)this).GetChildren();
		}
		List<DesignerItemAutomationPeer> list = new List<DesignerItemAutomationPeer>();
		if (_dataChildren.ContainsKey(selectedObj))
		{
			if (_dataChildren[selectedObj] is DesignerItemAutomationPeer item)
			{
				list.Add(item);
			}
		}
		else
		{
			foreach (DictionaryEntry dataChild in _dataChildren)
			{
				if (dataChild.Value is DesignerItemAutomationPeer designerItemAutomationPeer)
				{
					list.AddRange(designerItemAutomationPeer.GetSelectedAutomationPeers(selectedObj));
				}
			}
		}
		return list;
	}

	public void AddToSelection()
	{
		SelectionOperations.Union(_view.Context, _item);
		((AutomationPeer)this).RaiseAutomationEvent((AutomationEvents)6);
		((AutomationPeer)this).RaiseAutomationEvent((AutomationEvents)4);
	}

	public void RemoveFromSelection()
	{
		if (IsSelected)
		{
			SelectionOperations.Toggle(_view.Context, _item);
			((AutomationPeer)this).RaiseAutomationEvent((AutomationEvents)7);
			((AutomationPeer)this).RaiseAutomationEvent((AutomationEvents)4);
		}
	}

	public void Select()
	{
		SelectionOperations.SelectOnly(_view.Context, _item);
		((AutomationPeer)this).RaiseAutomationEvent((AutomationEvents)8);
		((AutomationPeer)this).RaiseAutomationEvent((AutomationEvents)4);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	protected virtual void Dispose(bool disposing)
	{
		if (_disposed)
		{
			return;
		}
		if (disposing && _dataChildren != null)
		{
			foreach (DictionaryEntry dataChild in _dataChildren)
			{
				if (dataChild.Value is DesignerItemAutomationPeer designerItemAutomationPeer)
				{
					designerItemAutomationPeer.Dispose();
				}
			}
		}
		_item = null;
		_view = null;
		_dataChildren = null;
		_viewPeer = null;
		_modelService = null;
		_disposed = true;
	}
}
