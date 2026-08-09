#define DEBUG
using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ComponentFactory.Krypton.Ribbon.Properties;
using ComponentFactory.Krypton.Toolkit;

namespace ComponentFactory.Krypton.Ribbon;

internal class KryptonRibbonGroupClusterDesigner : ComponentDesigner
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroupCluster _ribbonCluster;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _addButtonVerb;

	private DesignerVerb _addColorButtonVerb;

	private DesignerVerb _clearItemsVerb;

	private DesignerVerb _deleteClusterVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _visibleMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _addButtonMenu;

	private ToolStripMenuItem _addColorButtonMenu;

	private ToolStripMenuItem _clearItemsMenu;

	private ToolStripMenuItem _deleteClusterMenu;

	public override ICollection AssociatedComponents
	{
		get
		{
			ArrayList arrayList = new ArrayList(base.AssociatedComponents);
			arrayList.AddRange(_ribbonCluster.Items);
			return arrayList;
		}
	}

	public override DesignerVerbCollection Verbs
	{
		get
		{
			UpdateVerbStatus();
			return _verbs;
		}
	}

	public override void Initialize(IComponent component)
	{
		Debug.Assert(component != null);
		if (component == null)
		{
			throw new ArgumentNullException("component");
		}
		base.Initialize(component);
		_ribbonCluster = (KryptonRibbonGroupCluster)component;
		_ribbonCluster.DesignTimeAddButton += OnAddButton;
		_ribbonCluster.DesignTimeAddColorButton += OnAddColorButton;
		_ribbonCluster.DesignTimeContextMenu += OnContextMenu;
		_designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		_changeService = (IComponentChangeService)GetService(typeof(IComponentChangeService));
		_changeService.ComponentRemoving += OnComponentRemoving;
		_changeService.ComponentChanged += OnComponentChanged;
	}

	protected override void Dispose(bool disposing)
	{
		try
		{
			if (disposing)
			{
				_ribbonCluster.DesignTimeAddButton -= OnAddButton;
				_ribbonCluster.DesignTimeContextMenu -= OnContextMenu;
				_changeService.ComponentRemoving -= OnComponentRemoving;
				_changeService.ComponentChanged -= OnComponentChanged;
			}
		}
		finally
		{
			base.Dispose(disposing);
		}
	}

	private void UpdateVerbStatus()
	{
		if (_verbs == null)
		{
			_verbs = new DesignerVerbCollection();
			_toggleHelpersVerb = new DesignerVerb("Toggle Helpers", OnToggleHelpers);
			_moveFirstVerb = new DesignerVerb("Move Cluster First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move Cluster Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move Cluster Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move Cluster Last", OnMoveLast);
			_addButtonVerb = new DesignerVerb("Add Button", OnAddButton);
			_addColorButtonVerb = new DesignerVerb("Add Color Button", OnAddColorButton);
			_clearItemsVerb = new DesignerVerb("Clear Items", OnClearItems);
			_deleteClusterVerb = new DesignerVerb("Delete Cluster", OnDeleteCluster);
			_verbs.AddRange(new DesignerVerb[9] { _toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _addButtonVerb, _addColorButtonVerb, _clearItemsVerb, _deleteClusterVerb });
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		bool enabled5 = false;
		if (_ribbonCluster != null && _ribbonCluster.Ribbon != null)
		{
			KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonCluster.RibbonContainer;
			enabled = kryptonRibbonGroupLines.Items.IndexOf(_ribbonCluster) > 0;
			enabled2 = kryptonRibbonGroupLines.Items.IndexOf(_ribbonCluster) > 0;
			enabled3 = kryptonRibbonGroupLines.Items.IndexOf(_ribbonCluster) < kryptonRibbonGroupLines.Items.Count - 1;
			enabled4 = kryptonRibbonGroupLines.Items.IndexOf(_ribbonCluster) < kryptonRibbonGroupLines.Items.Count - 1;
			enabled5 = _ribbonCluster.Items.Count > 0;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
		_clearItemsVerb.Enabled = enabled5;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonCluster != null && _ribbonCluster.Ribbon != null)
		{
			_ribbonCluster.Ribbon.InDesignHelperMode = !_ribbonCluster.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonCluster != null && _ribbonCluster.Ribbon != null)
		{
			KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonCluster.RibbonContainer;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCluster MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(kryptonRibbonGroupLines)["Items"];
				RaiseComponentChanging(member);
				kryptonRibbonGroupLines.Items.Remove(_ribbonCluster);
				kryptonRibbonGroupLines.Items.Insert(0, _ribbonCluster);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnMovePrevious(object sender, EventArgs e)
	{
		if (_ribbonCluster != null && _ribbonCluster.Ribbon != null)
		{
			KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonCluster.RibbonContainer;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCluster MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(kryptonRibbonGroupLines)["Items"];
				RaiseComponentChanging(member);
				int val = kryptonRibbonGroupLines.Items.IndexOf(_ribbonCluster) - 1;
				val = Math.Max(val, 0);
				kryptonRibbonGroupLines.Items.Remove(_ribbonCluster);
				kryptonRibbonGroupLines.Items.Insert(val, _ribbonCluster);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnMoveNext(object sender, EventArgs e)
	{
		if (_ribbonCluster != null && _ribbonCluster.Ribbon != null)
		{
			KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonCluster.RibbonContainer;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCluster MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(kryptonRibbonGroupLines)["Items"];
				RaiseComponentChanging(member);
				int val = kryptonRibbonGroupLines.Items.IndexOf(_ribbonCluster) + 1;
				val = Math.Min(val, kryptonRibbonGroupLines.Items.Count - 1);
				kryptonRibbonGroupLines.Items.Remove(_ribbonCluster);
				kryptonRibbonGroupLines.Items.Insert(val, _ribbonCluster);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnMoveLast(object sender, EventArgs e)
	{
		if (_ribbonCluster != null && _ribbonCluster.Ribbon != null)
		{
			KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonCluster.RibbonContainer;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCluster MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(kryptonRibbonGroupLines)["Items"];
				RaiseComponentChanging(member);
				kryptonRibbonGroupLines.Items.Remove(_ribbonCluster);
				kryptonRibbonGroupLines.Items.Insert(kryptonRibbonGroupLines.Items.Count, _ribbonCluster);
				UpdateVerbStatus();
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddButton(object sender, EventArgs e)
	{
		if (_ribbonCluster != null && _ribbonCluster.Ribbon != null)
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCluster AddButton");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonCluster)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupClusterButton item = (KryptonRibbonGroupClusterButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupClusterButton));
				_ribbonCluster.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddColorButton(object sender, EventArgs e)
	{
		if (_ribbonCluster != null && _ribbonCluster.Ribbon != null)
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCluster AddColorButton");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonCluster)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupClusterColorButton item = (KryptonRibbonGroupClusterColorButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupClusterColorButton));
				_ribbonCluster.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnClearItems(object sender, EventArgs e)
	{
		if (_ribbonCluster == null || _ribbonCluster.Ribbon == null)
		{
			return;
		}
		DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupCluster ClearItems");
		try
		{
			MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonCluster)["Items"];
			RaiseComponentChanging(member);
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _ribbonCluster.Items.Count - 1; num >= 0; num--)
			{
				KryptonRibbonGroupItem item = _ribbonCluster.Items[num];
				_ribbonCluster.Items.Remove(item);
				designerHost.DestroyComponent(item);
			}
			RaiseComponentChanged(member, null, null);
		}
		finally
		{
			designerTransaction?.Commit();
		}
	}

	private void OnDeleteCluster(object sender, EventArgs e)
	{
		if (_ribbonCluster != null && _ribbonCluster.Ribbon != null)
		{
			KryptonRibbonGroupLines kryptonRibbonGroupLines = (KryptonRibbonGroupLines)_ribbonCluster.RibbonContainer;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple DeleteTriple");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(kryptonRibbonGroupLines)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				kryptonRibbonGroupLines.Items.Remove(_ribbonCluster);
				_designerHost.DestroyComponent(_ribbonCluster);
				RaiseComponentChanged(member, null, null);
				RaiseComponentChanged(null, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnVisible(object sender, EventArgs e)
	{
		if (_ribbonCluster != null && _ribbonCluster.Ribbon != null)
		{
			_changeService.OnComponentChanged(_ribbonCluster, null, _ribbonCluster.Visible, !_ribbonCluster.Visible);
			_ribbonCluster.Visible = !_ribbonCluster.Visible;
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component != _ribbonCluster)
		{
			return;
		}
		IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
		for (int num = _ribbonCluster.Items.Count - 1; num >= 0; num--)
		{
			IRibbonGroupItem ribbonGroupItem = _ribbonCluster.Items[num];
			if (ribbonGroupItem != null)
			{
				_ribbonCluster.Items.Remove(ribbonGroupItem);
				designerHost.DestroyComponent(ribbonGroupItem as Component);
			}
			else
			{
				IRibbonGroupContainer ribbonGroupContainer = _ribbonCluster.Items[num] as IRibbonGroupContainer;
				_ribbonCluster.Items.Remove(ribbonGroupContainer);
				designerHost.DestroyComponent(ribbonGroupContainer as Component);
			}
		}
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonCluster != null && _ribbonCluster.Ribbon != null)
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_visibleMenu = new ToolStripMenuItem("Visible", null, OnVisible);
				_moveFirstMenu = new ToolStripMenuItem("Move Cluster First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move Cluster Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move Cluster Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move Cluster Last", Resources.MoveLast, OnMoveLast);
				_addButtonMenu = new ToolStripMenuItem("Add Button", Resources.KryptonRibbonGroupClusterButton, OnAddButton);
				_addColorButtonMenu = new ToolStripMenuItem("Add Color Button", Resources.KryptonRibbonGroupClusterColorButton, OnAddColorButton);
				_clearItemsMenu = new ToolStripMenuItem("Clear Items", null, OnClearItems);
				_deleteClusterMenu = new ToolStripMenuItem("Delete Cluster", Resources.delete2, OnDeleteCluster);
				_cms.Items.AddRange(new ToolStripItem[15]
				{
					_toggleHelpersMenu,
					new ToolStripSeparator(),
					_visibleMenu,
					new ToolStripSeparator(),
					_moveFirstMenu,
					_movePreviousMenu,
					_moveNextMenu,
					_moveLastMenu,
					new ToolStripSeparator(),
					_addButtonMenu,
					_addColorButtonMenu,
					new ToolStripSeparator(),
					_clearItemsMenu,
					new ToolStripSeparator(),
					_deleteClusterMenu
				});
				_addButtonMenu.ImageTransparentColor = Color.Magenta;
				_addColorButtonMenu.ImageTransparentColor = Color.Magenta;
			}
			UpdateVerbStatus();
			_toggleHelpersMenu.Checked = _ribbonCluster.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = _ribbonCluster.Visible;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			_clearItemsMenu.Enabled = _clearItemsVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonCluster.Ribbon.ViewRectangleToPoint(_ribbonCluster.ClusterView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}
}
