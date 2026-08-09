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

internal class KryptonRibbonGroupTripleDesigner : ComponentDesigner
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroupTriple _ribbonTriple;

	private DesignerVerbCollection _verbs;

	private DesignerVerb _toggleHelpersVerb;

	private DesignerVerb _moveFirstVerb;

	private DesignerVerb _movePrevVerb;

	private DesignerVerb _moveNextVerb;

	private DesignerVerb _moveLastVerb;

	private DesignerVerb _addButtonVerb;

	private DesignerVerb _addColorButtonVerb;

	private DesignerVerb _addCheckBoxVerb;

	private DesignerVerb _addRadioButtonVerb;

	private DesignerVerb _addLabelVerb;

	private DesignerVerb _addCustomControlVerb;

	private DesignerVerb _addTextBoxVerb;

	private DesignerVerb _addMaskedTextBoxVerb;

	private DesignerVerb _addRichTextBoxVerb;

	private DesignerVerb _addComboBoxVerb;

	private DesignerVerb _addNumericUpDownVerb;

	private DesignerVerb _addDomainUpDownVerb;

	private DesignerVerb _addDateTimePickerVerb;

	private DesignerVerb _addTrackBarVerb;

	private DesignerVerb _clearItemsVerb;

	private DesignerVerb _deleteTripleVerb;

	private ContextMenuStrip _cms;

	private ToolStripMenuItem _toggleHelpersMenu;

	private ToolStripMenuItem _visibleMenu;

	private ToolStripMenuItem _maximumSizeMenu;

	private ToolStripMenuItem _maximumLMenu;

	private ToolStripMenuItem _maximumMMenu;

	private ToolStripMenuItem _maximumSMenu;

	private ToolStripMenuItem _minimumSizeMenu;

	private ToolStripMenuItem _minimumLMenu;

	private ToolStripMenuItem _minimumMMenu;

	private ToolStripMenuItem _minimumSMenu;

	private ToolStripMenuItem _moveFirstMenu;

	private ToolStripMenuItem _movePreviousMenu;

	private ToolStripMenuItem _moveNextMenu;

	private ToolStripMenuItem _moveLastMenu;

	private ToolStripMenuItem _moveToGroupMenu;

	private ToolStripMenuItem _addButtonMenu;

	private ToolStripMenuItem _addColorButtonMenu;

	private ToolStripMenuItem _addCheckBoxMenu;

	private ToolStripMenuItem _addRadioButtonMenu;

	private ToolStripMenuItem _addLabelMenu;

	private ToolStripMenuItem _addCustomControlMenu;

	private ToolStripMenuItem _addTextBoxMenu;

	private ToolStripMenuItem _addMaskedTextBoxMenu;

	private ToolStripMenuItem _addRichTextBoxMenu;

	private ToolStripMenuItem _addComboBoxMenu;

	private ToolStripMenuItem _addNumericUpDownMenu;

	private ToolStripMenuItem _addDomainUpDownMenu;

	private ToolStripMenuItem _addDateTimePickerMenu;

	private ToolStripMenuItem _addTrackBarMenu;

	private ToolStripMenuItem _clearItemsMenu;

	private ToolStripMenuItem _deleteTripleMenu;

	public override ICollection AssociatedComponents
	{
		get
		{
			ArrayList arrayList = new ArrayList(base.AssociatedComponents);
			arrayList.AddRange(_ribbonTriple.Items);
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
		_ribbonTriple = (KryptonRibbonGroupTriple)component;
		_ribbonTriple.DesignTimeAddButton += OnAddButton;
		_ribbonTriple.DesignTimeAddColorButton += OnAddColorButton;
		_ribbonTriple.DesignTimeAddCheckBox += OnAddCheckBox;
		_ribbonTriple.DesignTimeAddRadioButton += OnAddRadioButton;
		_ribbonTriple.DesignTimeAddLabel += OnAddLabel;
		_ribbonTriple.DesignTimeAddCustomControl += OnAddCustomControl;
		_ribbonTriple.DesignTimeAddTextBox += OnAddTextBox;
		_ribbonTriple.DesignTimeAddMaskedTextBox += OnAddMaskedTextBox;
		_ribbonTriple.DesignTimeAddRichTextBox += OnAddRichTextBox;
		_ribbonTriple.DesignTimeAddComboBox += OnAddComboBox;
		_ribbonTriple.DesignTimeAddNumericUpDown += OnAddNumericUpDown;
		_ribbonTriple.DesignTimeAddDomainUpDown += OnAddDomainUpDown;
		_ribbonTriple.DesignTimeAddDateTimePicker += OnAddDateTimePicker;
		_ribbonTriple.DesignTimeAddTrackBar += OnAddTrackBar;
		_ribbonTriple.DesignTimeContextMenu += OnContextMenu;
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
				_ribbonTriple.DesignTimeAddButton -= OnAddButton;
				_ribbonTriple.DesignTimeAddColorButton -= OnAddColorButton;
				_ribbonTriple.DesignTimeAddCheckBox -= OnAddCheckBox;
				_ribbonTriple.DesignTimeAddRadioButton -= OnAddRadioButton;
				_ribbonTriple.DesignTimeAddLabel -= OnAddLabel;
				_ribbonTriple.DesignTimeAddCustomControl -= OnAddCustomControl;
				_ribbonTriple.DesignTimeAddTextBox -= OnAddTextBox;
				_ribbonTriple.DesignTimeAddMaskedTextBox -= OnAddMaskedTextBox;
				_ribbonTriple.DesignTimeAddRichTextBox -= OnAddRichTextBox;
				_ribbonTriple.DesignTimeAddComboBox -= OnAddComboBox;
				_ribbonTriple.DesignTimeAddNumericUpDown -= OnAddNumericUpDown;
				_ribbonTriple.DesignTimeAddDomainUpDown -= OnAddDomainUpDown;
				_ribbonTriple.DesignTimeAddDateTimePicker -= OnAddDateTimePicker;
				_ribbonTriple.DesignTimeAddTrackBar -= OnAddTrackBar;
				_ribbonTriple.DesignTimeContextMenu -= OnContextMenu;
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
			_moveFirstVerb = new DesignerVerb("Move Triple First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move Triple Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move Triple Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move Triple Last", OnMoveLast);
			_addButtonVerb = new DesignerVerb("Add Button", OnAddButton);
			_addColorButtonVerb = new DesignerVerb("Add Color Button", OnAddColorButton);
			_addCheckBoxVerb = new DesignerVerb("Add CheckBox", OnAddCheckBox);
			_addRadioButtonVerb = new DesignerVerb("Add RadioButton", OnAddRadioButton);
			_addLabelVerb = new DesignerVerb("Add Label", OnAddLabel);
			_addCustomControlVerb = new DesignerVerb("Add Custom Control", OnAddCustomControl);
			_addTextBoxVerb = new DesignerVerb("Add TextBox", OnAddTextBox);
			_addMaskedTextBoxVerb = new DesignerVerb("Add MaskedTextBox", OnAddMaskedTextBox);
			_addRichTextBoxVerb = new DesignerVerb("Add RichTextBox", OnAddRichTextBox);
			_addComboBoxVerb = new DesignerVerb("Add ComboBox", OnAddComboBox);
			_addNumericUpDownVerb = new DesignerVerb("Add NumericUpDown", OnAddNumericUpDown);
			_addDomainUpDownVerb = new DesignerVerb("Add DomainUpDown", OnAddDomainUpDown);
			_addDateTimePickerVerb = new DesignerVerb("Add DateTimePicker", OnAddDateTimePicker);
			_addTrackBarVerb = new DesignerVerb("Add TrackBar", OnAddTrackBar);
			_clearItemsVerb = new DesignerVerb("Clear Items", OnClearItems);
			_deleteTripleVerb = new DesignerVerb("Delete Triple", OnDeleteTriple);
			_verbs.AddRange(new DesignerVerb[21]
			{
				_toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _addButtonVerb, _addColorButtonVerb, _addCheckBoxVerb, _addComboBoxVerb, _addCustomControlVerb,
				_addDateTimePickerVerb, _addDomainUpDownVerb, _addLabelVerb, _addNumericUpDownVerb, _addRadioButtonVerb, _addRichTextBoxVerb, _addTextBoxVerb, _addTrackBarVerb, _addMaskedTextBoxVerb, _clearItemsVerb,
				_deleteTripleVerb
			});
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		bool enabled5 = false;
		bool enabled6 = false;
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			enabled = _ribbonTriple.RibbonGroup.Items.IndexOf(_ribbonTriple) > 0;
			enabled2 = _ribbonTriple.RibbonGroup.Items.IndexOf(_ribbonTriple) > 0;
			enabled3 = _ribbonTriple.RibbonGroup.Items.IndexOf(_ribbonTriple) < _ribbonTriple.RibbonGroup.Items.Count - 1;
			enabled4 = _ribbonTriple.RibbonGroup.Items.IndexOf(_ribbonTriple) < _ribbonTriple.RibbonGroup.Items.Count - 1;
			enabled5 = _ribbonTriple.Items.Count < 3;
			enabled6 = _ribbonTriple.Items.Count > 0;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
		_addButtonVerb.Enabled = enabled5;
		_addColorButtonVerb.Enabled = enabled5;
		_addCheckBoxVerb.Enabled = enabled5;
		_addRadioButtonVerb.Enabled = enabled5;
		_addLabelVerb.Enabled = enabled5;
		_addCustomControlVerb.Enabled = enabled5;
		_addTextBoxVerb.Enabled = enabled5;
		_addMaskedTextBoxVerb.Enabled = enabled5;
		_addRichTextBoxVerb.Enabled = enabled5;
		_addComboBoxVerb.Enabled = enabled5;
		_addNumericUpDownVerb.Enabled = enabled5;
		_addDomainUpDownVerb.Enabled = enabled5;
		_addDateTimePickerVerb.Enabled = enabled5;
		_addTrackBarVerb.Enabled = enabled5;
		_clearItemsVerb.Enabled = enabled6;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null)
		{
			_ribbonTriple.Ribbon.InDesignHelperMode = !_ribbonTriple.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonTriple.RibbonGroup;
				ribbonGroup.Items.Remove(_ribbonTriple);
				ribbonGroup.Items.Insert(0, _ribbonTriple);
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
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonTriple.RibbonGroup;
				int val = ribbonGroup.Items.IndexOf(_ribbonTriple) - 1;
				val = Math.Max(val, 0);
				ribbonGroup.Items.Remove(_ribbonTriple);
				ribbonGroup.Items.Insert(val, _ribbonTriple);
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
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonTriple.RibbonGroup;
				int val = ribbonGroup.Items.IndexOf(_ribbonTriple) + 1;
				val = Math.Min(val, ribbonGroup.Items.Count - 1);
				ribbonGroup.Items.Remove(_ribbonTriple);
				ribbonGroup.Items.Insert(val, _ribbonTriple);
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
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonTriple.RibbonGroup;
				ribbonGroup.Items.Remove(_ribbonTriple);
				ribbonGroup.Items.Insert(ribbonGroup.Items.Count, _ribbonTriple);
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
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddButton");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupButton item = (KryptonRibbonGroupButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupButton));
				_ribbonTriple.Items.Add(item);
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
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddColorButton");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupColorButton item = (KryptonRibbonGroupColorButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupColorButton));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddCheckBox(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddCheckBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupCheckBox item = (KryptonRibbonGroupCheckBox)_designerHost.CreateComponent(typeof(KryptonRibbonGroupCheckBox));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddRadioButton(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddRadioButton");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupRadioButton item = (KryptonRibbonGroupRadioButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupRadioButton));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddLabel(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddLabel");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupLabel item = (KryptonRibbonGroupLabel)_designerHost.CreateComponent(typeof(KryptonRibbonGroupLabel));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddCustomControl(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddCustomControl");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupCustomControl item = (KryptonRibbonGroupCustomControl)_designerHost.CreateComponent(typeof(KryptonRibbonGroupCustomControl));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddTextBox(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddTextBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupTextBox item = (KryptonRibbonGroupTextBox)_designerHost.CreateComponent(typeof(KryptonRibbonGroupTextBox));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddTrackBar(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddTrackBar");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupTrackBar item = (KryptonRibbonGroupTrackBar)_designerHost.CreateComponent(typeof(KryptonRibbonGroupTrackBar));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddMaskedTextBox(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddMaskedTextBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupMaskedTextBox item = (KryptonRibbonGroupMaskedTextBox)_designerHost.CreateComponent(typeof(KryptonRibbonGroupMaskedTextBox));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddRichTextBox(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddRichTextBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupRichTextBox item = (KryptonRibbonGroupRichTextBox)_designerHost.CreateComponent(typeof(KryptonRibbonGroupRichTextBox));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddComboBox(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddComboBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupComboBox item = (KryptonRibbonGroupComboBox)_designerHost.CreateComponent(typeof(KryptonRibbonGroupComboBox));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddNumericUpDown(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddNumericUpDown");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupNumericUpDown item = (KryptonRibbonGroupNumericUpDown)_designerHost.CreateComponent(typeof(KryptonRibbonGroupNumericUpDown));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddDomainUpDown(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddDomainUpDown");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupDomainUpDown item = (KryptonRibbonGroupDomainUpDown)_designerHost.CreateComponent(typeof(KryptonRibbonGroupDomainUpDown));
				_ribbonTriple.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddDateTimePicker(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple AddDateTimePicker");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupDateTimePicker item = (KryptonRibbonGroupDateTimePicker)_designerHost.CreateComponent(typeof(KryptonRibbonGroupDateTimePicker));
				_ribbonTriple.Items.Add(item);
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
		if (_ribbonTriple == null || _ribbonTriple.Ribbon == null || !_ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			return;
		}
		DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple ClearItems");
		try
		{
			MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple)["Items"];
			RaiseComponentChanging(member);
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _ribbonTriple.Items.Count - 1; num >= 0; num--)
			{
				KryptonRibbonGroupItem item = _ribbonTriple.Items[num];
				_ribbonTriple.Items.Remove(item);
				designerHost.DestroyComponent(item);
			}
			RaiseComponentChanged(member, null, null);
		}
		finally
		{
			designerTransaction?.Commit();
		}
	}

	private void OnDeleteTriple(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple DeleteTriple");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple.RibbonGroup)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				_ribbonTriple.RibbonGroup.Items.Remove(_ribbonTriple);
				_designerHost.DestroyComponent(_ribbonTriple);
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
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			_changeService.OnComponentChanged(_ribbonTriple, null, _ribbonTriple.Visible, !_ribbonTriple.Visible);
			_ribbonTriple.Visible = !_ribbonTriple.Visible;
		}
	}

	private void OnMaxLarge(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			_changeService.OnComponentChanged(_ribbonTriple, null, _ribbonTriple.MaximumSize, GroupItemSize.Large);
			_ribbonTriple.MaximumSize = GroupItemSize.Large;
		}
	}

	private void OnMaxMedium(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			_changeService.OnComponentChanged(_ribbonTriple, null, _ribbonTriple.MaximumSize, GroupItemSize.Medium);
			_ribbonTriple.MaximumSize = GroupItemSize.Medium;
		}
	}

	private void OnMaxSmall(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			_changeService.OnComponentChanged(_ribbonTriple, null, _ribbonTriple.MaximumSize, GroupItemSize.Small);
			_ribbonTriple.MaximumSize = GroupItemSize.Small;
		}
	}

	private void OnMinLarge(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			_changeService.OnComponentChanged(_ribbonTriple, null, _ribbonTriple.MinimumSize, GroupItemSize.Large);
			_ribbonTriple.MinimumSize = GroupItemSize.Large;
		}
	}

	private void OnMinMedium(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			_changeService.OnComponentChanged(_ribbonTriple, null, _ribbonTriple.MinimumSize, GroupItemSize.Medium);
			_ribbonTriple.MinimumSize = GroupItemSize.Medium;
		}
	}

	private void OnMinSmall(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			_changeService.OnComponentChanged(_ribbonTriple, null, _ribbonTriple.MinimumSize, GroupItemSize.Small);
			_ribbonTriple.MinimumSize = GroupItemSize.Small;
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component == _ribbonTriple)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _ribbonTriple.Items.Count - 1; num >= 0; num--)
			{
				KryptonRibbonGroupItem item = _ribbonTriple.Items[num];
				_ribbonTriple.Items.Remove(item);
				designerHost.DestroyComponent(item);
			}
		}
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			if (_cms == null)
			{
				_cms = new ContextMenuStrip();
				_toggleHelpersMenu = new ToolStripMenuItem("Design Helpers", null, OnToggleHelpers);
				_visibleMenu = new ToolStripMenuItem("Visible", null, OnVisible);
				_maximumLMenu = new ToolStripMenuItem("Large", null, OnMaxLarge);
				_maximumMMenu = new ToolStripMenuItem("Medium", null, OnMaxMedium);
				_maximumSMenu = new ToolStripMenuItem("Small", null, OnMaxSmall);
				_maximumSizeMenu = new ToolStripMenuItem("Maximum Size");
				_maximumSizeMenu.DropDownItems.AddRange(new ToolStripItem[3] { _maximumLMenu, _maximumMMenu, _maximumSMenu });
				_minimumLMenu = new ToolStripMenuItem("Large", null, OnMinLarge);
				_minimumMMenu = new ToolStripMenuItem("Medium", null, OnMinMedium);
				_minimumSMenu = new ToolStripMenuItem("Small", null, OnMinSmall);
				_minimumSizeMenu = new ToolStripMenuItem("Minimum Size");
				_minimumSizeMenu.DropDownItems.AddRange(new ToolStripItem[3] { _minimumLMenu, _minimumMMenu, _minimumSMenu });
				_moveFirstMenu = new ToolStripMenuItem("Move Triple First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move Triple Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move Triple Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move Triple Last", Resources.MoveLast, OnMoveLast);
				_moveToGroupMenu = new ToolStripMenuItem("Move Triple To Group");
				_addButtonMenu = new ToolStripMenuItem("Add Button", Resources.KryptonRibbonGroupButton, OnAddButton);
				_addColorButtonMenu = new ToolStripMenuItem("Add Color Button", Resources.KryptonRibbonGroupColorButton, OnAddColorButton);
				_addCheckBoxMenu = new ToolStripMenuItem("Add CheckBox", Resources.KryptonRibbonGroupCheckBox, OnAddCheckBox);
				_addRadioButtonMenu = new ToolStripMenuItem("Add RadioButton", Resources.KryptonRibbonGroupRadioButton, OnAddRadioButton);
				_addLabelMenu = new ToolStripMenuItem("Add Label", Resources.KryptonRibbonGroupLabel, OnAddLabel);
				_addCustomControlMenu = new ToolStripMenuItem("Add Custom Control", Resources.KryptonRibbonGroupCustomControl, OnAddCustomControl);
				_addTextBoxMenu = new ToolStripMenuItem("Add TextBox", Resources.KryptonRibbonGroupTextBox, OnAddTextBox);
				_addMaskedTextBoxMenu = new ToolStripMenuItem("Add MaskedTextBox", Resources.KryptonRibbonGroupMaskedTextBox, OnAddMaskedTextBox);
				_addRichTextBoxMenu = new ToolStripMenuItem("Add RichTextBox", Resources.KryptonRibbonGroupRichTextBox, OnAddRichTextBox);
				_addComboBoxMenu = new ToolStripMenuItem("Add ComboBox", Resources.KryptonRibbonGroupComboBox, OnAddComboBox);
				_addNumericUpDownMenu = new ToolStripMenuItem("Add NumericUpDown", Resources.KryptonRibbonGroupNumericUpDown, OnAddNumericUpDown);
				_addDomainUpDownMenu = new ToolStripMenuItem("Add DomainUpDown", Resources.KryptonRibbonGroupDomainUpDown, OnAddDomainUpDown);
				_addDateTimePickerMenu = new ToolStripMenuItem("Add DateTimePicker", Resources.KryptonRibbonGroupDateTimePicker, OnAddDateTimePicker);
				_addTrackBarMenu = new ToolStripMenuItem("Add TrackBar", Resources.KryptonRibbonGroupTrackBar, OnAddTrackBar);
				_clearItemsMenu = new ToolStripMenuItem("Clear Items", null, OnClearItems);
				_deleteTripleMenu = new ToolStripMenuItem("Delete Triple", Resources.delete2, OnDeleteTriple);
				_cms.Items.AddRange(new ToolStripItem[31]
				{
					_toggleHelpersMenu,
					new ToolStripSeparator(),
					_visibleMenu,
					_maximumSizeMenu,
					_minimumSizeMenu,
					new ToolStripSeparator(),
					_moveFirstMenu,
					_movePreviousMenu,
					_moveNextMenu,
					_moveLastMenu,
					new ToolStripSeparator(),
					_moveToGroupMenu,
					new ToolStripSeparator(),
					_addButtonMenu,
					_addColorButtonMenu,
					_addCheckBoxMenu,
					_addComboBoxMenu,
					_addCustomControlMenu,
					_addDateTimePickerMenu,
					_addDomainUpDownMenu,
					_addLabelMenu,
					_addNumericUpDownMenu,
					_addRadioButtonMenu,
					_addRichTextBoxMenu,
					_addTextBoxMenu,
					_addTrackBarMenu,
					_addMaskedTextBoxMenu,
					new ToolStripSeparator(),
					_clearItemsMenu,
					new ToolStripSeparator(),
					_deleteTripleMenu
				});
				_addButtonMenu.ImageTransparentColor = Color.Magenta;
				_addColorButtonMenu.ImageTransparentColor = Color.Magenta;
				_addCheckBoxMenu.ImageTransparentColor = Color.Magenta;
				_addRadioButtonMenu.ImageTransparentColor = Color.Magenta;
				_addLabelMenu.ImageTransparentColor = Color.Magenta;
				_addCustomControlMenu.ImageTransparentColor = Color.Magenta;
				_addTextBoxMenu.ImageTransparentColor = Color.Magenta;
				_addMaskedTextBoxMenu.ImageTransparentColor = Color.Magenta;
				_addRichTextBoxMenu.ImageTransparentColor = Color.Magenta;
				_addComboBoxMenu.ImageTransparentColor = Color.Magenta;
				_addNumericUpDownMenu.ImageTransparentColor = Color.Magenta;
				_addDomainUpDownMenu.ImageTransparentColor = Color.Magenta;
				_addDateTimePickerMenu.ImageTransparentColor = Color.Magenta;
				_addTrackBarMenu.ImageTransparentColor = Color.Magenta;
			}
			UpdateVerbStatus();
			UpdateMoveToGroup();
			_toggleHelpersMenu.Checked = _ribbonTriple.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = _ribbonTriple.Visible;
			_maximumLMenu.Checked = _ribbonTriple.MaximumSize == GroupItemSize.Large;
			_maximumMMenu.Checked = _ribbonTriple.MaximumSize == GroupItemSize.Medium;
			_maximumSMenu.Checked = _ribbonTriple.MaximumSize == GroupItemSize.Small;
			_minimumLMenu.Checked = _ribbonTriple.MinimumSize == GroupItemSize.Large;
			_minimumMMenu.Checked = _ribbonTriple.MinimumSize == GroupItemSize.Medium;
			_minimumSMenu.Checked = _ribbonTriple.MinimumSize == GroupItemSize.Small;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			_moveToGroupMenu.Enabled = _moveToGroupMenu.DropDownItems.Count > 0;
			_addButtonMenu.Enabled = _addButtonVerb.Enabled;
			_addColorButtonMenu.Enabled = _addColorButtonVerb.Enabled;
			_addCheckBoxMenu.Enabled = _addCheckBoxVerb.Enabled;
			_addRadioButtonMenu.Enabled = _addRadioButtonVerb.Enabled;
			_addLabelMenu.Enabled = _addLabelVerb.Enabled;
			_addCustomControlMenu.Enabled = _addCustomControlVerb.Enabled;
			_addTextBoxMenu.Enabled = _addTextBoxVerb.Enabled;
			_addMaskedTextBoxMenu.Enabled = _addMaskedTextBoxVerb.Enabled;
			_addRichTextBoxMenu.Enabled = _addRichTextBoxVerb.Enabled;
			_addComboBoxMenu.Enabled = _addComboBoxVerb.Enabled;
			_addNumericUpDownMenu.Enabled = _addNumericUpDownVerb.Enabled;
			_addDomainUpDownMenu.Enabled = _addDomainUpDownVerb.Enabled;
			_addDateTimePickerMenu.Enabled = _addDateTimePickerVerb.Enabled;
			_addTrackBarMenu.Enabled = _addTrackBarVerb.Enabled;
			_clearItemsMenu.Enabled = _clearItemsVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonTriple.Ribbon.ViewRectangleToPoint(_ribbonTriple.TripleView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}

	private void UpdateMoveToGroup()
	{
		_moveToGroupMenu.DropDownItems.Clear();
		if (_ribbonTriple.Ribbon == null)
		{
			return;
		}
		foreach (KryptonRibbonGroup group in _ribbonTriple.RibbonTab.Groups)
		{
			if (group != _ribbonTriple.RibbonGroup)
			{
				ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
				toolStripMenuItem.Text = group.TextLine1 + " " + group.TextLine2;
				toolStripMenuItem.Tag = group;
				toolStripMenuItem.Click += OnMoveToGroup;
				_moveToGroupMenu.DropDownItems.Add(toolStripMenuItem);
			}
		}
	}

	private void OnMoveToGroup(object sender, EventArgs e)
	{
		if (_ribbonTriple != null && _ribbonTriple.Ribbon != null && _ribbonTriple.RibbonGroup.Items.Contains(_ribbonTriple))
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			KryptonRibbonGroup kryptonRibbonGroup = (KryptonRibbonGroup)toolStripMenuItem.Tag;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupTriple MoveTripleToGroup");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonTriple.RibbonGroup)["Items"];
				MemberDescriptor member2 = TypeDescriptor.GetProperties(kryptonRibbonGroup)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				RaiseComponentChanging(member2);
				_ribbonTriple.RibbonGroup.Items.Remove(_ribbonTriple);
				kryptonRibbonGroup.Items.Add(_ribbonTriple);
				RaiseComponentChanged(member2, null, null);
				RaiseComponentChanged(member, null, null);
				RaiseComponentChanged(null, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}
}
