using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using MS.Internal.Properties;
using Microsoft.Windows.Design;
using Microsoft.Windows.Design.Interaction;
using Microsoft.Windows.Design.Model;
using Microsoft.Windows.Design.Services;

namespace MS.Internal.Automation;

internal class DesignerViewAutomationPeer : UIElementAutomationPeer, ISelectionProvider, IDisposable
{
	private DesignerView _owner;

	private ModelService _modelService;

	private Hashtable _dataChildren;

	private List<DesignerItemAutomationPeer> _oldSelectionList;

	private bool _fromContext;

	private ModelItem _root;

	private bool _disposed;

	private EditingContext _context;

	public DesignerView View => _owner;

	public EditingContext Context
	{
		get
		{
			return _context;
		}
		set
		{
			if (_context != null)
			{
				_context.Items.Unsubscribe<Selection>(OnSelectionChanged);
				if (ModelService != null)
				{
					ModelService.ModelChanged -= OnModelChanged;
				}
				_context.Disposing -= OnContextDisposing;
			}
			_context = value;
			if (_context != null)
			{
				_context.Disposing += OnContextDisposing;
				if (_dataChildren == null)
				{
					PopulateDataChildren();
				}
				try
				{
					_fromContext = true;
					_context.Items.Subscribe<Selection>(OnSelectionChanged);
				}
				finally
				{
					_fromContext = false;
				}
				_oldSelectionList = new List<DesignerItemAutomationPeer>(GetSelectedAutomationPeers(_context.Items.GetValue<Selection>()));
				if (ModelService != null)
				{
					_root = ModelService.Root;
					ModelService.ModelChanged += OnModelChanged;
				}
			}
		}
	}

	private ModelService ModelService
	{
		get
		{
			if (_modelService == null && Context != null)
			{
				_modelService = Context.Services.GetService<ModelService>();
			}
			return _modelService;
		}
	}

	public bool CanSelectMultiple => true;

	public bool IsSelectionRequired => false;

	public DesignerViewAutomationPeer(DesignerView view)
		: base((UIElement)(object)view)
	{
		if (view != null)
		{
			_owner = view;
			Context = _owner.Context;
		}
	}

	private void OnModelChanged(object sender, ModelChangedEventArgs e)
	{
		ModelItem root = ModelService.Root;
		if (root != _root)
		{
			_root = root;
			PopulateDataChildren();
		}
	}

	private void OnContextDisposing(object sender, EventArgs e)
	{
		Dispose();
	}

	protected override List<AutomationPeer> GetChildrenCore()
	{
		if (!_disposed)
		{
			List<AutomationPeer> list = new List<AutomationPeer>();
			if (_dataChildren == null)
			{
				PopulateDataChildren();
			}
			{
				foreach (DictionaryEntry dataChild in _dataChildren)
				{
					object value = dataChild.Value;
					list.Add((AutomationPeer)((value is AutomationPeer) ? value : null));
				}
				return list;
			}
		}
		return null;
	}

	protected override string GetAutomationIdCore()
	{
		return "WPFDesignerView";
	}

	protected override string GetNameCore()
	{
		return MS.Internal.Properties.Resources.DesignerViewAutomationPeer_Name;
	}

	protected override string GetHelpTextCore()
	{
		return MS.Internal.Properties.Resources.DesignerViewAutomationPeer_HelpText;
	}

	protected override string GetItemTypeCore()
	{
		return MS.Internal.Properties.Resources.DesignerViewAutomationPeer_ItemType;
	}

	protected override string GetClassNameCore()
	{
		return ((object)_owner).GetType().Name;
	}

	public override object GetPattern(PatternInterface patternInterface)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Invalid comparison between Unknown and I4
		if ((int)patternInterface == 1)
		{
			return this;
		}
		return null;
	}

	protected override bool IsEnabledCore()
	{
		return ((UIElement)_owner).IsEnabled;
	}

	private void OnSelectionChanged(Selection newSelection)
	{
		if (_fromContext)
		{
			return;
		}
		List<DesignerItemAutomationPeer> list = new List<DesignerItemAutomationPeer>(GetSelectedAutomationPeers(newSelection));
		if (list.Count == 1)
		{
			DesignerItemAutomationPeer designerItemAutomationPeer = list[0];
			if (designerItemAutomationPeer != null)
			{
				((AutomationPeer)designerItemAutomationPeer).RaiseAutomationEvent((AutomationEvents)4);
				((AutomationPeer)designerItemAutomationPeer).RaiseAutomationEvent((AutomationEvents)8);
			}
		}
		else
		{
			foreach (DesignerItemAutomationPeer oldSelection in _oldSelectionList)
			{
				if (!list.Contains(oldSelection))
				{
					((AutomationPeer)oldSelection).RaiseAutomationEvent((AutomationEvents)4);
					((AutomationPeer)oldSelection).RaiseAutomationEvent((AutomationEvents)7);
				}
			}
			foreach (DesignerItemAutomationPeer item in list)
			{
				if (!_oldSelectionList.Contains(item))
				{
					((AutomationPeer)item).RaiseAutomationEvent((AutomationEvents)4);
					((AutomationPeer)item).RaiseAutomationEvent((AutomationEvents)6);
				}
			}
		}
		_oldSelectionList = list;
	}

	private void PopulateDataChildren()
	{
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Expected O, but got Unknown
		Hashtable dataChildren = _dataChildren;
		if (ModelService == null)
		{
			return;
		}
		ModelItem root = ModelService.Root;
		if (root == null)
		{
			return;
		}
		_dataChildren = new Hashtable();
		UIElement child = ((Decorator)_owner).Child;
		Canvas val = (Canvas)(object)((child is Canvas) ? child : null);
		if (val != null && ((Panel)val).Children != null)
		{
			foreach (object child2 in ((Panel)val).Children)
			{
				Image val2 = (Image)((child2 is Image) ? child2 : null);
				if (val2 != null)
				{
					_dataChildren.Add(child2, (object)new ImageAutomationPeer(val2));
				}
			}
		}
		DesignerItemAutomationPeer designerItemAutomationPeer = ((dataChildren == null) ? null : ((DesignerItemAutomationPeer)dataChildren[root]));
		if (designerItemAutomationPeer == null)
		{
			designerItemAutomationPeer = new DesignerItemAutomationPeer(root, this);
		}
		if (_dataChildren[root] == null)
		{
			_dataChildren.Add(root, designerItemAutomationPeer);
		}
	}

	public IRawElementProviderSimple GetProviderFromPeer(AutomationPeer peer)
	{
		return ((AutomationPeer)this).ProviderFromPeer(peer);
	}

	public IRawElementProviderSimple[] GetSelection()
	{
		List<IRawElementProviderSimple> list = null;
		if (Context != null)
		{
			Selection value = Context.Items.GetValue<Selection>();
			list = new List<IRawElementProviderSimple>(value.SelectionCount);
			if (value.SelectionCount == 0)
			{
				return list.ToArray();
			}
			if (_dataChildren == null)
			{
				PopulateDataChildren();
			}
			DesignerItemAutomationPeer designerItemAutomationPeer = null;
			ModelItem root = ModelService.Root;
			if (root != null)
			{
				designerItemAutomationPeer = (DesignerItemAutomationPeer)_dataChildren[root];
			}
			foreach (ModelItem selectedObject in value.SelectedObjects)
			{
				if (_dataChildren.ContainsKey(selectedObject) && designerItemAutomationPeer != null)
				{
					list.Add(designerItemAutomationPeer.GetProviderFromPeer((AutomationPeer)(object)designerItemAutomationPeer));
				}
				List<IRawElementProviderSimple> selection = designerItemAutomationPeer.GetSelection(selectedObject);
				list.AddRange(selection);
			}
			return list.ToArray();
		}
		return (IRawElementProviderSimple[])(object)new IRawElementProviderSimple[0];
	}

	public List<DesignerItemAutomationPeer> GetSelectedAutomationPeers(Selection newSel)
	{
		List<DesignerItemAutomationPeer> list = new List<DesignerItemAutomationPeer>(newSel.SelectionCount);
		if (newSel.SelectionCount == 0)
		{
			return list;
		}
		DesignerItemAutomationPeer designerItemAutomationPeer = null;
		ModelItem root = ModelService.Root;
		if (root != _root)
		{
			_root = root;
			PopulateDataChildren();
		}
		if (root != null)
		{
			designerItemAutomationPeer = (DesignerItemAutomationPeer)_dataChildren[root];
		}
		foreach (ModelItem selectedObject in newSel.SelectedObjects)
		{
			if (_dataChildren.ContainsKey(selectedObject) && designerItemAutomationPeer != null)
			{
				list.Add(designerItemAutomationPeer);
			}
			List<DesignerItemAutomationPeer> selectedAutomationPeers = designerItemAutomationPeer.GetSelectedAutomationPeers(selectedObject);
			list.AddRange(selectedAutomationPeers);
		}
		return list;
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
		if (disposing)
		{
			Context = null;
			if (_root != null)
			{
				DesignerItemAutomationPeer designerItemAutomationPeer = (DesignerItemAutomationPeer)_dataChildren[_root];
				designerItemAutomationPeer.Dispose();
			}
		}
		_owner = null;
		_modelService = null;
		_dataChildren = null;
		_oldSelectionList = null;
		_root = null;
		_disposed = true;
	}
}
