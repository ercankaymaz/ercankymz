using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace System.Windows.Forms;

[Designer(typeof(RibbonComboBoxDesigner))]
public class RibbonComboBox : RibbonTextBox, IContainsRibbonComponents, IDropDownRibbonItem
{
	public delegate void RibbonItemEventHandler(object sender, RibbonItemEventArgs e);

	private RibbonItem _selectedItem;

	private readonly Set<RibbonItem> _assignedHandlers = new Set<RibbonItem>();

	[DefaultValue(0)]
	[Category("Behavior")]
	[Description("Gets or sets the maximum height for the dropdown window.  0 = Autosize.  If the size is smaller than the contents then scrollbars will be shown.")]
	public int DropDownMaxHeight { get; set; }

	[Browsable(false)]
	[DefaultValue(false)]
	[Description("Indicates if the dropdown window is currently visible")]
	public bool DropDownVisible { get; private set; }

	[DefaultValue(false)]
	[Category("Drop Down")]
	[Description("Makes the DropDown resizable with a grip on the corner")]
	public bool DropDownResizable { get; set; }

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public override Rectangle TextBoxTextBounds
	{
		get
		{
			Rectangle textBoxTextBounds = base.TextBoxTextBounds;
			textBoxTextBounds.Width -= DropDownButtonBounds.Width;
			return textBoxTextBounds;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	[Category("Drop Down")]
	public RibbonItemCollection DropDownItems { get; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public RibbonItem SelectedItem
	{
		get
		{
			if (_selectedItem == null)
			{
				foreach (RibbonItem dropDownItem in DropDownItems)
				{
					if (dropDownItem.Text == base.TextBoxText)
					{
						_selectedItem = dropDownItem;
						return dropDownItem;
					}
				}
				return null;
			}
			if (DropDownItems.Contains(_selectedItem))
			{
				return _selectedItem;
			}
			_selectedItem = null;
			return null;
		}
		set
		{
			if (value == null)
			{
				_selectedItem = null;
				base.TextBoxText = string.Empty;
			}
			else if (value.GetType().BaseType == typeof(RibbonItem))
			{
				if (DropDownItems.Contains(value))
				{
					_selectedItem = value;
					base.TextBoxText = _selectedItem.Text;
				}
				else
				{
					_selectedItem = value;
					base.TextBoxText = _selectedItem.Text;
				}
			}
		}
	}

	[Browsable(true)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
	public int SelectedIndex
	{
		get
		{
			if (_selectedItem != null)
			{
				return DropDownItems.IndexOf(_selectedItem);
			}
			return -1;
		}
		set
		{
			if (value == -1)
			{
				SelectedItem = null;
				return;
			}
			if (DropDownItems.Count > 0 && value >= 0 && value < DropDownItems.Count)
			{
				SelectedItem = DropDownItems[value];
				return;
			}
			throw new ArgumentOutOfRangeException("SelectedIndex");
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string SelectedValue
	{
		get
		{
			if (_selectedItem == null)
			{
				return null;
			}
			return _selectedItem.Value;
		}
		set
		{
			foreach (RibbonItem dropDownItem in DropDownItems)
			{
				if (string.Compare(dropDownItem.Value, value, ignoreCase: false) == 0 && _selectedItem != dropDownItem)
				{
					_selectedItem = dropDownItem;
					base.TextBoxText = _selectedItem.Text;
					RibbonItemEventArgs e = new RibbonItemEventArgs(dropDownItem);
					OnDropDownItemClicked(ref e);
				}
			}
		}
	}

	internal RibbonDropDown DropDown { get; private set; }

	[Category("Drop Down")]
	[DisplayName("DrawDropDownIconsBar")]
	[DefaultValue(true)]
	public bool DrawIconsBar { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Rectangle DropDownButtonBounds { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool DropDownButtonVisible => DropDownVisible;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool DropDownButtonSelected { get; private set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public bool DropDownButtonPressed { get; private set; }

	public event EventHandler DropDownShowing;

	public event RibbonItemEventHandler DropDownItemClicked;

	public RibbonComboBox()
	{
		DropDownItems = new RibbonItemCollection();
		DropDownItems.SetOwnerItem(this);
		DropDownVisible = false;
		base.AllowTextEdit = true;
		DrawIconsBar = true;
		DropDownMaxHeight = 0;
		_disableTextboxCursor = true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			RemoveHandlers();
		}
		base.Dispose(disposing);
	}

	public void OnDropDownShowing(EventArgs e)
	{
		if (this.DropDownShowing != null)
		{
			this.DropDownShowing(this, e);
		}
	}

	protected virtual void CreateDropDown()
	{
		DropDown = new RibbonDropDown(this, DropDownItems, base.Owner);
	}

	public virtual void ShowDropDown()
	{
		if (DropDownVisible)
		{
			return;
		}
		AssignHandlers();
		OnDropDownShowing(EventArgs.Empty);
		foreach (RibbonItem dropDownItem in DropDownItems)
		{
			dropDownItem.SetSelected(dropDownItem == SelectedItem);
		}
		CreateDropDown();
		DropDown.DropDownMaxHeight = DropDownMaxHeight;
		DropDown.ShowSizingGrip = DropDownResizable;
		DropDown.DrawIconsBar = DrawIconsBar;
		DropDown.Closed += DropDown_Closed;
		Point screenLocation = OnGetDropDownMenuLocation();
		DropDown.Show(screenLocation);
		DropDownVisible = true;
	}

	private void DropDown_Closed(object sender, EventArgs e)
	{
		DropDownVisible = false;
		DropDownButtonPressed = false;
		DropDownButtonSelected = false;
		SetSelected(selected: false);
		RedrawItem();
	}

	private void AssignHandlers()
	{
		foreach (RibbonItem dropDownItem in DropDownItems)
		{
			if (!_assignedHandlers.Contains(dropDownItem))
			{
				dropDownItem.Click += DropDownItem_Click;
				_assignedHandlers.Add(dropDownItem);
			}
		}
	}

	private void RemoveHandlers()
	{
		foreach (RibbonItem assignedHandler in _assignedHandlers)
		{
			assignedHandler.Click -= DropDownItem_Click;
		}
		_assignedHandlers.Clear();
	}

	private void DropDownItem_Click(object sender, EventArgs e)
	{
		_selectedItem = sender as RibbonItem;
		base.TextBoxText = (sender as RibbonItem).Text;
		RibbonItemEventArgs e2 = new RibbonItemEventArgs(sender as RibbonItem);
		OnDropDownItemClicked(ref e2);
	}

	protected override bool ClosesDropDownAt(Point p)
	{
		return false;
	}

	protected override void InitTextBox(TextBox t)
	{
		base.InitTextBox(t);
		t.Width -= DropDownButtonBounds.Width;
	}

	public override void SetBounds(Rectangle bounds)
	{
		base.SetBounds(bounds);
		DropDownButtonBounds = Rectangle.FromLTRB(bounds.Right - 15, bounds.Top, bounds.Right + 1, bounds.Bottom + 1);
	}

	public virtual void OnDropDownItemClicked(ref RibbonItemEventArgs e)
	{
		if (this.DropDownItemClicked != null)
		{
			this.DropDownItemClicked(this, e);
		}
	}

	public override void OnMouseMove(MouseEventArgs e)
	{
		if (Enabled)
		{
			base.OnMouseMove(e);
			bool flag = false;
			if (DropDownButtonBounds.Contains(e.X, e.Y))
			{
				base.Owner.Cursor = Cursors.Default;
				flag = !DropDownButtonSelected;
				DropDownButtonSelected = true;
			}
			else if (TextBoxBounds.Contains(e.X, e.Y))
			{
				base.Owner.Cursor = (base.AllowTextEdit ? Cursors.IBeam : Cursors.Default);
				flag = DropDownButtonSelected;
				DropDownButtonSelected = false;
			}
			else
			{
				base.Owner.Cursor = Cursors.Default;
			}
			if (flag)
			{
				RedrawItem();
			}
		}
	}

	public override void OnMouseDown(MouseEventArgs e)
	{
		if (Enabled)
		{
			if (DropDownButtonBounds.Contains(e.X, e.Y) || TextBoxBounds.Contains(e.X, e.Y) != base.AllowTextEdit)
			{
				DropDownButtonPressed = true;
				ShowDropDown();
			}
			else if (TextBoxBounds.Contains(e.X, e.Y) && base.AllowTextEdit)
			{
				StartEdit();
			}
		}
	}

	public override void OnMouseUp(MouseEventArgs e)
	{
		if (Enabled)
		{
			base.OnMouseUp(e);
		}
	}

	public override void OnMouseLeave(MouseEventArgs e)
	{
		if (Enabled)
		{
			base.OnMouseLeave(e);
			DropDownButtonSelected = false;
		}
	}

	internal virtual Point OnGetDropDownMenuLocation()
	{
		Point empty = Point.Empty;
		if (base.Canvas is RibbonDropDown)
		{
			return base.Canvas.PointToScreen(new Point(TextBoxBounds.Left, base.Bounds.Bottom));
		}
		return base.Owner.PointToScreen(new Point(TextBoxBounds.Left, base.Bounds.Bottom));
	}

	public IEnumerable<Component> GetAllChildComponents()
	{
		return DropDownItems.ToArray();
	}

	internal override void SetOwner(Ribbon owner)
	{
		base.SetOwner(owner);
		DropDownItems.SetOwner(owner);
	}

	internal override void SetOwnerPanel(RibbonPanel ownerPanel)
	{
		base.SetOwnerPanel(ownerPanel);
		DropDownItems.SetOwnerPanel(ownerPanel);
	}

	internal override void SetOwnerTab(RibbonTab ownerTab)
	{
		base.SetOwnerTab(ownerTab);
		DropDownItems.SetOwnerTab(base.OwnerTab);
	}

	internal override void SetOwnerItem(RibbonItem ownerItem)
	{
		base.SetOwnerItem(ownerItem);
	}

	internal override void ClearOwner()
	{
		List<RibbonItem> list = new List<RibbonItem>(DropDownItems);
		base.ClearOwner();
		foreach (RibbonItem item in list)
		{
			item.ClearOwner();
		}
	}
}
