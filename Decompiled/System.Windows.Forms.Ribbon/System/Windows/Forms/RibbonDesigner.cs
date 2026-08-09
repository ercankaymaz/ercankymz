using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Permissions;
using System.Windows.Forms.Design;
using System.Windows.Forms.Design.Behavior;
using System.Windows.Forms.RibbonHelpers;

namespace System.Windows.Forms;

[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
public class RibbonDesigner : ControlDesigner
{
	internal static RibbonDesigner Current;

	private IRibbonElement _selectedElement;

	private Adorner _quickAccessAdorner;

	private Adorner _orbAdorner;

	private Adorner _tabAdorner;

	public IRibbonElement SelectedElement
	{
		get
		{
			return _selectedElement;
		}
		set
		{
			if (Ribbon != null)
			{
				_selectedElement = value;
				if (GetService(typeof(ISelectionService)) is ISelectionService selectionService && value != null)
				{
					selectionService.SetSelectedComponents(new Component[1] { value as Component }, SelectionTypes.Click);
				}
				if (value is RibbonButton ribbonButton)
				{
					ribbonButton.ShowDropDown();
				}
				Ribbon.Refresh();
			}
		}
	}

	public Ribbon Ribbon => Control as Ribbon;

	public override DesignerVerbCollection Verbs => new DesignerVerbCollection
	{
		new DesignerVerb("Add Tab", AddTabVerb),
		new DesignerVerb("Add Context", AddContextVerb)
	};

	public RibbonDesigner()
	{
		Current = this;
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (Current == this)
		{
			Current = null;
		}
	}

	public virtual void CreateItem(Ribbon ribbon, RibbonItemCollection collection, Type t)
	{
		if (GetService(typeof(IDesignerHost)) is IDesignerHost designerHost && collection != null && ribbon != null)
		{
			DesignerTransaction designerTransaction = designerHost.CreateTransaction("AddRibbonItem_" + base.Component.Site.Name);
			MemberDescriptor member = TypeDescriptor.GetProperties(base.Component)["Items"];
			RaiseComponentChanging(member);
			RibbonItem ribbonItem = designerHost.CreateComponent(t) as RibbonItem;
			if (!(ribbonItem is RibbonSeparator))
			{
				ribbonItem.Text = ribbonItem.Site.Name;
			}
			collection.Add(ribbonItem);
			ribbon.OnRegionsChanged();
			RaiseComponentChanged(member, null, null);
			designerTransaction.Commit();
		}
	}

	private void CreateOrbItem(string collectionName, RibbonItemCollection collection, Type t)
	{
		if (Ribbon != null)
		{
			IDesignerHost obj = GetService(typeof(IDesignerHost)) as IDesignerHost;
			DesignerTransaction designerTransaction = obj.CreateTransaction("AddRibbonOrbItem_" + base.Component.Site.Name);
			MemberDescriptor member = TypeDescriptor.GetProperties(Ribbon.OrbDropDown)[collectionName];
			RaiseComponentChanging(member);
			RibbonItem ribbonItem = obj.CreateComponent(t) as RibbonItem;
			if (!(ribbonItem is RibbonSeparator))
			{
				ribbonItem.Text = ribbonItem.Site.Name;
			}
			collection.Add(ribbonItem);
			Ribbon.OrbDropDown.OnRegionsChanged();
			RaiseComponentChanged(member, null, null);
			designerTransaction.Commit();
			Ribbon.OrbDropDown.SelectOnDesigner(ribbonItem);
			Ribbon.OrbDropDown.WrappedDropDown.Size = Ribbon.OrbDropDown.Size;
		}
	}

	public void CreateOrbMenuItem(Type t)
	{
		CreateOrbItem("MenuItems", Ribbon.OrbDropDown.MenuItems, t);
	}

	public void CreateOrbRecentItem(Type t)
	{
		CreateOrbItem("RecentItems", Ribbon.OrbDropDown.RecentItems, t);
	}

	public void CreateOrbOptionItem(Type t)
	{
		CreateOrbItem("OptionItems", Ribbon.OrbDropDown.OptionItems, t);
	}

	private void AssignEventHandler()
	{
	}

	private void SelectRibbon()
	{
		if (GetService(typeof(ISelectionService)) is ISelectionService selectionService)
		{
			selectionService.SetSelectedComponents(new Component[1] { Ribbon }, SelectionTypes.Click);
		}
	}

	public void AddTabVerb(object sender, EventArgs e)
	{
		if (Control is Ribbon ribbon && (GetService(typeof(IDesignerHost)) as IDesignerHost)?.CreateComponent(typeof(RibbonTab)) is RibbonTab ribbonTab)
		{
			ribbonTab.Text = ribbonTab.Site.Name;
			Ribbon.Tabs.Add(ribbonTab);
			ribbon.Refresh();
		}
	}

	public void AddContextVerb(object sender, EventArgs e)
	{
		if (Control is Ribbon ribbon && (GetService(typeof(IDesignerHost)) as IDesignerHost)?.CreateComponent(typeof(RibbonContext)) is RibbonContext ribbonContext)
		{
			ribbonContext.Text = ribbonContext.Site.Name;
			Random random = new Random();
			ribbonContext.GlowColor = Color.FromArgb(random.Next(155, 255), random.Next(155, 255), random.Next(155, 255));
			Ribbon.Contexts.Add(ribbonContext);
			ribbon.Refresh();
		}
	}

	protected override void WndProc(ref Message m)
	{
		if (m.HWnd == Control.Handle)
		{
			switch (m.Msg)
			{
			case 515:
				AssignEventHandler();
				break;
			case 513:
			case 516:
				return;
			case 514:
			case 517:
				HitOn(WinApi.LoWord((int)m.LParam), WinApi.HiWord((int)m.LParam));
				return;
			}
		}
		base.WndProc(ref m);
	}

	private void HitOn(int x, int y)
	{
		if (Ribbon.Tabs.Count == 0 || Ribbon.ActiveTab == null)
		{
			SelectRibbon();
		}
		else
		{
			if (Ribbon == null)
			{
				return;
			}
			if (Ribbon.TabHitTest(x, y))
			{
				SelectedElement = Ribbon.ActiveTab;
				return;
			}
			if (Ribbon.ContextHitTest(x, y))
			{
				foreach (RibbonContext context in Ribbon.Contexts)
				{
					if (context.Bounds.Contains(x, y))
					{
						SelectedElement = context;
						break;
					}
				}
				return;
			}
			if (Ribbon.ActiveTab.TabContentBounds.Contains(x, y))
			{
				if (Ribbon.ActiveTab.ScrollLeftBounds.Contains(x, y) && Ribbon.ActiveTab.ScrollLeftVisible)
				{
					Ribbon.ActiveTab.ScrollLeft();
					SelectedElement = Ribbon.ActiveTab;
					return;
				}
				if (Ribbon.ActiveTab.ScrollRightBounds.Contains(x, y) && Ribbon.ActiveTab.ScrollRightVisible)
				{
					Ribbon.ActiveTab.ScrollRight();
					SelectedElement = Ribbon.ActiveTab;
					return;
				}
			}
			if (Ribbon.ActiveTab.TabContentBounds.Contains(x, y))
			{
				RibbonPanel ribbonPanel = null;
				foreach (RibbonPanel panel in Ribbon.ActiveTab.Panels)
				{
					if (panel.Bounds.Contains(x, y))
					{
						ribbonPanel = panel;
						break;
					}
				}
				if (ribbonPanel != null)
				{
					RibbonItem ribbonItem = null;
					foreach (RibbonItem item in ribbonPanel.Items)
					{
						if (item.Bounds.Contains(x, y))
						{
							ribbonItem = item;
							break;
						}
					}
					if (ribbonItem != null && ribbonItem is IContainsSelectableRibbonItems)
					{
						RibbonItem ribbonItem2 = null;
						foreach (RibbonItem item2 in (ribbonItem as IContainsSelectableRibbonItems).GetItems())
						{
							if (item2.Bounds.Contains(x, y))
							{
								ribbonItem2 = item2;
								break;
							}
						}
						if (ribbonItem2 != null)
						{
							SelectedElement = ribbonItem2;
						}
						else
						{
							SelectedElement = ribbonItem;
						}
					}
					else if (ribbonItem != null)
					{
						SelectedElement = ribbonItem;
					}
					else
					{
						SelectedElement = ribbonPanel;
					}
				}
				else
				{
					SelectedElement = Ribbon.ActiveTab;
				}
			}
			else if (Ribbon.QuickAccessToolbar.SuperBounds.Contains(x, y))
			{
				bool flag = false;
				foreach (RibbonItem item3 in Ribbon.QuickAccessToolbar.Items)
				{
					if (item3.Bounds.Contains(x, y))
					{
						flag = true;
						SelectedElement = item3;
						break;
					}
				}
				if (!flag)
				{
					SelectedElement = Ribbon.QuickAccessToolbar;
				}
			}
			else if (Ribbon.OrbBounds.Contains(x, y))
			{
				Ribbon.OrbMouseDown();
			}
			else
			{
				SelectRibbon();
				Ribbon.ForceOrbMenu = false;
				if (Ribbon.OrbDropDown.Visible)
				{
					Ribbon.OrbDropDown.Close();
				}
			}
		}
	}

	protected override void OnPaintAdornments(PaintEventArgs pe)
	{
		base.OnPaintAdornments(pe);
		using Pen pen = new Pen(Color.Black);
		pen.DashStyle = DashStyle.Dot;
		if (!(GetService(typeof(ISelectionService)) is ISelectionService selectionService))
		{
			return;
		}
		foreach (IComponent selectedComponent in selectionService.GetSelectedComponents())
		{
			if (selectedComponent is RibbonContext)
			{
				if (selectedComponent is RibbonContext ribbonContext)
				{
					Rectangle rect = ((ribbonContext.ContextualTabsCount > 0) ? ribbonContext.HeaderBounds : ribbonContext.Bounds);
					rect.Inflate(-1, -1);
					pe.Graphics.DrawRectangle(pen, rect);
				}
			}
			else if (selectedComponent is RibbonTab)
			{
				if (selectedComponent is RibbonTab { Bounds: var bounds })
				{
					bounds.Inflate(-1, -1);
					pe.Graphics.DrawRectangle(pen, bounds);
				}
			}
			else if (selectedComponent is RibbonPanel)
			{
				if (selectedComponent is RibbonPanel { Bounds: var bounds2 })
				{
					bounds2.Inflate(-1, -1);
					pe.Graphics.DrawRectangle(pen, bounds2);
				}
			}
			else if (selectedComponent is RibbonItem && selectedComponent is RibbonItem ribbonItem && !Ribbon.OrbDropDown.AllItems.Contains(ribbonItem))
			{
				Rectangle bounds3 = ribbonItem.Bounds;
				bounds3.Inflate(1, 1);
				pe.Graphics.DrawRectangle(pen, bounds3);
			}
		}
	}

	public BehaviorService GetBehaviorService()
	{
		return base.BehaviorService;
	}

	public override void Initialize(IComponent component)
	{
		base.Initialize(component);
		IComponentChangeService componentChangeService = GetService(typeof(IComponentChangeService)) as IComponentChangeService;
		GetService(typeof(IDesignerEventService));
		if (componentChangeService != null)
		{
			componentChangeService.ComponentRemoved += changeService_ComponentRemoved;
		}
		_orbAdorner = new Adorner();
		_tabAdorner = new Adorner();
		if (base.BehaviorService != null)
		{
			base.BehaviorService.Adorners.AddRange(new Adorner[2] { _orbAdorner, _tabAdorner });
			if (Ribbon.QuickAccessToolbar.Visible)
			{
				_quickAccessAdorner = new Adorner();
				base.BehaviorService.Adorners.Add(_quickAccessAdorner);
				_quickAccessAdorner.Glyphs.Add(new RibbonQuickAccessToolbarGlyph(base.BehaviorService, this, Ribbon));
			}
			else
			{
				_quickAccessAdorner = null;
			}
			_tabAdorner.Glyphs.Add(new RibbonTabGlyph(base.BehaviorService, this, Ribbon));
		}
	}

	public void changeService_ComponentRemoved(object sender, ComponentEventArgs e)
	{
		RibbonTab ribbonTab = e.Component as RibbonTab;
		RibbonContext ribbonContext = e.Component as RibbonContext;
		RibbonPanel ribbonPanel = e.Component as RibbonPanel;
		RibbonItem ribbonItem = e.Component as RibbonItem;
		IDesignerHost service = GetService(typeof(IDesignerHost)) as IDesignerHost;
		RemoveRecursive(e.Component as IContainsRibbonComponents, service);
		if (ribbonTab != null && Ribbon != null)
		{
			Ribbon.Tabs.Remove(ribbonTab);
		}
		else if (ribbonContext != null)
		{
			Ribbon.Contexts.Remove(ribbonContext);
		}
		else if (ribbonPanel != null)
		{
			ribbonPanel.OwnerTab.Panels.Remove(ribbonPanel);
		}
		else if (ribbonItem != null)
		{
			if (ribbonItem.Canvas is RibbonOrbDropDown)
			{
				Ribbon.OrbDropDown.HandleDesignerItemRemoved(ribbonItem);
			}
			else if (ribbonItem.OwnerItem is RibbonItemGroup ribbonItemGroup)
			{
				ribbonItemGroup.Items.Remove(ribbonItem);
			}
			else if (ribbonItem.OwnerPanel != null)
			{
				ribbonItem.OwnerPanel.Items.Remove(ribbonItem);
			}
			else if (Ribbon != null && Ribbon.QuickAccessToolbar.Items.Contains(ribbonItem))
			{
				Ribbon.QuickAccessToolbar.Items.Remove(ribbonItem);
			}
		}
		SelectedElement = null;
		Ribbon?.OnRegionsChanged();
	}

	public void RemoveRecursive(IContainsRibbonComponents item, IDesignerHost service)
	{
		if (item == null || service == null)
		{
			return;
		}
		foreach (Component allChildComponent in item.GetAllChildComponents())
		{
			if (allChildComponent is IContainsRibbonComponents item2)
			{
				RemoveRecursive(item2, service);
			}
			service.DestroyComponent(allChildComponent);
		}
	}
}
