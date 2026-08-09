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

internal class KryptonRibbonGroupLinesDesigner : ComponentDesigner
{
	private IDesignerHost _designerHost;

	private IComponentChangeService _changeService;

	private KryptonRibbonGroupLines _ribbonLines;

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

	private DesignerVerb _addClusterVerb;

	private DesignerVerb _addTextBoxVerb;

	private DesignerVerb _addMaskedTextBoxVerb;

	private DesignerVerb _addRichTextBoxVerb;

	private DesignerVerb _addComboBoxVerb;

	private DesignerVerb _addNumericUpDownVerb;

	private DesignerVerb _addDomainUpDownVerb;

	private DesignerVerb _addDateTimePickerVerb;

	private DesignerVerb _addTrackBarVerb;

	private DesignerVerb _clearItemsVerb;

	private DesignerVerb _deleteLinesVerb;

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

	private ToolStripMenuItem _addClusterMenu;

	private ToolStripMenuItem _addTextBoxMenu;

	private ToolStripMenuItem _addMaskedTextBoxMenu;

	private ToolStripMenuItem _addRichTextBoxMenu;

	private ToolStripMenuItem _addComboBoxMenu;

	private ToolStripMenuItem _addNumericUpDownMenu;

	private ToolStripMenuItem _addDomainUpDownMenu;

	private ToolStripMenuItem _addDateTimePickerMenu;

	private ToolStripMenuItem _addTrackBarMenu;

	private ToolStripMenuItem _clearItemsMenu;

	private ToolStripMenuItem _deleteLinesMenu;

	public override ICollection AssociatedComponents
	{
		get
		{
			ArrayList arrayList = new ArrayList(base.AssociatedComponents);
			arrayList.AddRange(_ribbonLines.Items);
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
		_ribbonLines = (KryptonRibbonGroupLines)component;
		_ribbonLines.DesignTimeAddButton += OnAddButton;
		_ribbonLines.DesignTimeAddColorButton += OnAddColorButton;
		_ribbonLines.DesignTimeAddCheckBox += OnAddCheckBox;
		_ribbonLines.DesignTimeAddRadioButton += OnAddRadioButton;
		_ribbonLines.DesignTimeAddLabel += OnAddLabel;
		_ribbonLines.DesignTimeAddCustomControl += OnAddCustomControl;
		_ribbonLines.DesignTimeAddCluster += OnAddCluster;
		_ribbonLines.DesignTimeAddTextBox += OnAddTextBox;
		_ribbonLines.DesignTimeAddMaskedTextBox += OnAddMaskedTextBox;
		_ribbonLines.DesignTimeAddRichTextBox += OnAddRichTextBox;
		_ribbonLines.DesignTimeAddComboBox += OnAddComboBox;
		_ribbonLines.DesignTimeAddNumericUpDown += OnAddNumericUpDown;
		_ribbonLines.DesignTimeAddDomainUpDown += OnAddDomainUpDown;
		_ribbonLines.DesignTimeAddDateTimePicker += OnAddDateTimePicker;
		_ribbonLines.DesignTimeAddTrackBar += OnAddTrackBar;
		_ribbonLines.DesignTimeContextMenu += OnContextMenu;
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
				_ribbonLines.DesignTimeAddButton -= OnAddButton;
				_ribbonLines.DesignTimeAddColorButton -= OnAddColorButton;
				_ribbonLines.DesignTimeAddCheckBox -= OnAddCheckBox;
				_ribbonLines.DesignTimeAddRadioButton -= OnAddRadioButton;
				_ribbonLines.DesignTimeAddLabel -= OnAddLabel;
				_ribbonLines.DesignTimeAddCustomControl -= OnAddCustomControl;
				_ribbonLines.DesignTimeAddCluster -= OnAddCluster;
				_ribbonLines.DesignTimeAddTextBox -= OnAddTextBox;
				_ribbonLines.DesignTimeAddMaskedTextBox -= OnAddMaskedTextBox;
				_ribbonLines.DesignTimeAddRichTextBox -= OnAddRichTextBox;
				_ribbonLines.DesignTimeAddComboBox -= OnAddComboBox;
				_ribbonLines.DesignTimeAddNumericUpDown -= OnAddNumericUpDown;
				_ribbonLines.DesignTimeAddDomainUpDown -= OnAddDomainUpDown;
				_ribbonLines.DesignTimeAddDateTimePicker -= OnAddDateTimePicker;
				_ribbonLines.DesignTimeContextMenu -= OnContextMenu;
				_ribbonLines.DesignTimeAddTrackBar -= OnAddTrackBar;
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
			_moveFirstVerb = new DesignerVerb("Move Lines First", OnMoveFirst);
			_movePrevVerb = new DesignerVerb("Move Lines Previous", OnMovePrevious);
			_moveNextVerb = new DesignerVerb("Move Lines Next", OnMoveNext);
			_moveLastVerb = new DesignerVerb("Move Lines Last", OnMoveLast);
			_addButtonVerb = new DesignerVerb("Add Button", OnAddButton);
			_addColorButtonVerb = new DesignerVerb("Add Color Button", OnAddColorButton);
			_addCheckBoxVerb = new DesignerVerb("Add CheckBox", OnAddCheckBox);
			_addRadioButtonVerb = new DesignerVerb("Add RadioButton", OnAddRadioButton);
			_addLabelVerb = new DesignerVerb("Add Label", OnAddLabel);
			_addCustomControlVerb = new DesignerVerb("Add Custom Control", OnAddCustomControl);
			_addClusterVerb = new DesignerVerb("Add Cluster", OnAddCluster);
			_addRichTextBoxVerb = new DesignerVerb("Add RichTextBox", OnAddRichTextBox);
			_addTextBoxVerb = new DesignerVerb("Add TextBox", OnAddTextBox);
			_addMaskedTextBoxVerb = new DesignerVerb("Add MaskedTextBox", OnAddMaskedTextBox);
			_addComboBoxVerb = new DesignerVerb("Add ComboBox", OnAddComboBox);
			_addNumericUpDownVerb = new DesignerVerb("Add NumericUpDown", OnAddNumericUpDown);
			_addDomainUpDownVerb = new DesignerVerb("Add DomainUpDown", OnAddDomainUpDown);
			_addDateTimePickerVerb = new DesignerVerb("Add DateTimePicker", OnAddDateTimePicker);
			_addTrackBarVerb = new DesignerVerb("Add TrackBar", OnAddTrackBar);
			_clearItemsVerb = new DesignerVerb("Clear Items", OnClearItems);
			_deleteLinesVerb = new DesignerVerb("Delete Lines", OnDeleteLines);
			_verbs.AddRange(new DesignerVerb[22]
			{
				_toggleHelpersVerb, _moveFirstVerb, _movePrevVerb, _moveNextVerb, _moveLastVerb, _addButtonVerb, _addColorButtonVerb, _addCheckBoxVerb, _addClusterVerb, _addComboBoxVerb,
				_addCustomControlVerb, _addDateTimePickerVerb, _addDomainUpDownVerb, _addLabelVerb, _addNumericUpDownVerb, _addRadioButtonVerb, _addRichTextBoxVerb, _addTextBoxVerb, _addTrackBarVerb, _addMaskedTextBoxVerb,
				_clearItemsVerb, _deleteLinesVerb
			});
		}
		bool enabled = false;
		bool enabled2 = false;
		bool enabled3 = false;
		bool enabled4 = false;
		bool enabled5 = false;
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			enabled = _ribbonLines.RibbonGroup.Items.IndexOf(_ribbonLines) > 0;
			enabled2 = _ribbonLines.RibbonGroup.Items.IndexOf(_ribbonLines) > 0;
			enabled3 = _ribbonLines.RibbonGroup.Items.IndexOf(_ribbonLines) < _ribbonLines.RibbonGroup.Items.Count - 1;
			enabled4 = _ribbonLines.RibbonGroup.Items.IndexOf(_ribbonLines) < _ribbonLines.RibbonGroup.Items.Count - 1;
			enabled5 = _ribbonLines.Items.Count > 0;
		}
		_moveFirstVerb.Enabled = enabled;
		_movePrevVerb.Enabled = enabled2;
		_moveNextVerb.Enabled = enabled3;
		_moveLastVerb.Enabled = enabled4;
		_clearItemsVerb.Enabled = enabled5;
	}

	private void OnToggleHelpers(object sender, EventArgs e)
	{
		if (_ribbonLines != null && _ribbonLines.Ribbon != null)
		{
			_ribbonLines.Ribbon.InDesignHelperMode = !_ribbonLines.Ribbon.InDesignHelperMode;
		}
	}

	private void OnMoveFirst(object sender, EventArgs e)
	{
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines MoveFirst");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonLines.RibbonGroup;
				ribbonGroup.Items.Remove(_ribbonLines);
				ribbonGroup.Items.Insert(0, _ribbonLines);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines MovePrevious");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonLines.RibbonGroup;
				int val = ribbonGroup.Items.IndexOf(_ribbonLines) - 1;
				val = Math.Max(val, 0);
				ribbonGroup.Items.Remove(_ribbonLines);
				ribbonGroup.Items.Insert(val, _ribbonLines);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines MoveNext");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonLines.RibbonGroup;
				int val = ribbonGroup.Items.IndexOf(_ribbonLines) + 1;
				val = Math.Min(val, ribbonGroup.Items.Count - 1);
				ribbonGroup.Items.Remove(_ribbonLines);
				ribbonGroup.Items.Insert(val, _ribbonLines);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines MoveLast");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines.RibbonGroup)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroup ribbonGroup = _ribbonLines.RibbonGroup;
				ribbonGroup.Items.Remove(_ribbonLines);
				ribbonGroup.Items.Insert(ribbonGroup.Items.Count, _ribbonLines);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddButton");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupButton item = (KryptonRibbonGroupButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupButton));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddColorButton");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupColorButton item = (KryptonRibbonGroupColorButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupColorButton));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddCheckBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupCheckBox item = (KryptonRibbonGroupCheckBox)_designerHost.CreateComponent(typeof(KryptonRibbonGroupCheckBox));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddRadioButton");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupRadioButton item = (KryptonRibbonGroupRadioButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupRadioButton));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddLabel");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupLabel item = (KryptonRibbonGroupLabel)_designerHost.CreateComponent(typeof(KryptonRibbonGroupLabel));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddCustomControl");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupCustomControl item = (KryptonRibbonGroupCustomControl)_designerHost.CreateComponent(typeof(KryptonRibbonGroupCustomControl));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddTextBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupTextBox item = (KryptonRibbonGroupTextBox)_designerHost.CreateComponent(typeof(KryptonRibbonGroupTextBox));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddMaskedTextBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupMaskedTextBox item = (KryptonRibbonGroupMaskedTextBox)_designerHost.CreateComponent(typeof(KryptonRibbonGroupMaskedTextBox));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddRichTextBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupRichTextBox item = (KryptonRibbonGroupRichTextBox)_designerHost.CreateComponent(typeof(KryptonRibbonGroupRichTextBox));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddComboBox");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupComboBox item = (KryptonRibbonGroupComboBox)_designerHost.CreateComponent(typeof(KryptonRibbonGroupComboBox));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddNumericUpDown");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupNumericUpDown item = (KryptonRibbonGroupNumericUpDown)_designerHost.CreateComponent(typeof(KryptonRibbonGroupNumericUpDown));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddDomainUpDown");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupDomainUpDown item = (KryptonRibbonGroupDomainUpDown)_designerHost.CreateComponent(typeof(KryptonRibbonGroupDomainUpDown));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddDateTimePicker");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupDateTimePicker item = (KryptonRibbonGroupDateTimePicker)_designerHost.CreateComponent(typeof(KryptonRibbonGroupDateTimePicker));
				_ribbonLines.Items.Add(item);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddTrackBar");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupTrackBar item = (KryptonRibbonGroupTrackBar)_designerHost.CreateComponent(typeof(KryptonRibbonGroupTrackBar));
				_ribbonLines.Items.Add(item);
				RaiseComponentChanged(member, null, null);
			}
			finally
			{
				designerTransaction?.Commit();
			}
		}
	}

	private void OnAddCluster(object sender, EventArgs e)
	{
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines AddCluster");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
				RaiseComponentChanging(member);
				KryptonRibbonGroupCluster kryptonRibbonGroupCluster = (KryptonRibbonGroupCluster)_designerHost.CreateComponent(typeof(KryptonRibbonGroupCluster));
				_ribbonLines.Items.Add(kryptonRibbonGroupCluster);
				MemberDescriptor member2 = TypeDescriptor.GetProperties(kryptonRibbonGroupCluster)["Items"];
				RaiseComponentChanging(member2);
				KryptonRibbonGroupClusterButton item = (KryptonRibbonGroupClusterButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupClusterButton));
				KryptonRibbonGroupClusterButton item2 = (KryptonRibbonGroupClusterButton)_designerHost.CreateComponent(typeof(KryptonRibbonGroupClusterButton));
				kryptonRibbonGroupCluster.Items.Add(item);
				kryptonRibbonGroupCluster.Items.Add(item2);
				RaiseComponentChanged(member2, null, null);
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
		if (_ribbonLines == null || _ribbonLines.Ribbon == null || !_ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			return;
		}
		DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines ClearItems");
		try
		{
			MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines)["Items"];
			RaiseComponentChanging(member);
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _ribbonLines.Items.Count - 1; num >= 0; num--)
			{
				KryptonRibbonGroupItem item = _ribbonLines.Items[num];
				_ribbonLines.Items.Remove(item);
				designerHost.DestroyComponent(item);
			}
			RaiseComponentChanged(member, null, null);
		}
		finally
		{
			designerTransaction?.Commit();
		}
	}

	private void OnDeleteLines(object sender, EventArgs e)
	{
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines DeleteLines");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines.RibbonGroup)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				_ribbonLines.RibbonGroup.Items.Remove(_ribbonLines);
				_designerHost.DestroyComponent(_ribbonLines);
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			_changeService.OnComponentChanged(_ribbonLines, null, _ribbonLines.Visible, !_ribbonLines.Visible);
			_ribbonLines.Visible = !_ribbonLines.Visible;
		}
	}

	private void OnMaxLarge(object sender, EventArgs e)
	{
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			_changeService.OnComponentChanged(_ribbonLines, null, _ribbonLines.MaximumSize, GroupItemSize.Large);
			_ribbonLines.MaximumSize = GroupItemSize.Large;
		}
	}

	private void OnMaxMedium(object sender, EventArgs e)
	{
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			_changeService.OnComponentChanged(_ribbonLines, null, _ribbonLines.MaximumSize, GroupItemSize.Medium);
			_ribbonLines.MaximumSize = GroupItemSize.Medium;
		}
	}

	private void OnMaxSmall(object sender, EventArgs e)
	{
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			_changeService.OnComponentChanged(_ribbonLines, null, _ribbonLines.MaximumSize, GroupItemSize.Small);
			_ribbonLines.MaximumSize = GroupItemSize.Small;
		}
	}

	private void OnMinLarge(object sender, EventArgs e)
	{
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			_changeService.OnComponentChanged(_ribbonLines, null, _ribbonLines.MinimumSize, GroupItemSize.Large);
			_ribbonLines.MinimumSize = GroupItemSize.Large;
		}
	}

	private void OnMinMedium(object sender, EventArgs e)
	{
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			_changeService.OnComponentChanged(_ribbonLines, null, _ribbonLines.MinimumSize, GroupItemSize.Medium);
			_ribbonLines.MinimumSize = GroupItemSize.Medium;
		}
	}

	private void OnMinSmall(object sender, EventArgs e)
	{
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			_changeService.OnComponentChanged(_ribbonLines, null, _ribbonLines.MinimumSize, GroupItemSize.Small);
			_ribbonLines.MinimumSize = GroupItemSize.Small;
		}
	}

	private void OnComponentChanged(object sender, ComponentChangedEventArgs e)
	{
		UpdateVerbStatus();
	}

	private void OnComponentRemoving(object sender, ComponentEventArgs e)
	{
		if (e.Component == _ribbonLines)
		{
			IDesignerHost designerHost = (IDesignerHost)GetService(typeof(IDesignerHost));
			for (int num = _ribbonLines.Items.Count - 1; num >= 0; num--)
			{
				KryptonRibbonGroupItem item = _ribbonLines.Items[num];
				_ribbonLines.Items.Remove(item);
				designerHost.DestroyComponent(item);
			}
		}
	}

	private void OnContextMenu(object sender, MouseEventArgs e)
	{
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
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
				_moveFirstMenu = new ToolStripMenuItem("Move Lines First", Resources.MoveFirst, OnMoveFirst);
				_movePreviousMenu = new ToolStripMenuItem("Move Lines Previous", Resources.MovePrevious, OnMovePrevious);
				_moveNextMenu = new ToolStripMenuItem("Move Lines Next", Resources.MoveNext, OnMoveNext);
				_moveLastMenu = new ToolStripMenuItem("Move Lines Last", Resources.MoveLast, OnMoveLast);
				_moveToGroupMenu = new ToolStripMenuItem("Move Lines To Group");
				_addButtonMenu = new ToolStripMenuItem("Add Button", Resources.KryptonRibbonGroupButton, OnAddButton);
				_addColorButtonMenu = new ToolStripMenuItem("Add Color Button", Resources.KryptonRibbonGroupColorButton, OnAddColorButton);
				_addCheckBoxMenu = new ToolStripMenuItem("Add CheckBox", Resources.KryptonRibbonGroupCheckBox, OnAddCheckBox);
				_addRadioButtonMenu = new ToolStripMenuItem("Add RadioButton", Resources.KryptonRibbonGroupRadioButton, OnAddRadioButton);
				_addLabelMenu = new ToolStripMenuItem("Add Label", Resources.KryptonRibbonGroupLabel, OnAddLabel);
				_addCustomControlMenu = new ToolStripMenuItem("Add Custom Control", Resources.KryptonRibbonGroupCustomControl, OnAddCustomControl);
				_addClusterMenu = new ToolStripMenuItem("Add Cluster", Resources.KryptonRibbonGroupCluster, OnAddCluster);
				_addTextBoxMenu = new ToolStripMenuItem("Add TextBox", Resources.KryptonRibbonGroupTextBox, OnAddTextBox);
				_addMaskedTextBoxMenu = new ToolStripMenuItem("Add MaskedTextBox", Resources.KryptonRibbonGroupMaskedTextBox, OnAddMaskedTextBox);
				_addRichTextBoxMenu = new ToolStripMenuItem("Add RichTextBox", Resources.KryptonRibbonGroupRichTextBox, OnAddRichTextBox);
				_addComboBoxMenu = new ToolStripMenuItem("Add ComboBox", Resources.KryptonRibbonGroupComboBox, OnAddComboBox);
				_addNumericUpDownMenu = new ToolStripMenuItem("Add NumericUpDown", Resources.KryptonRibbonGroupNumericUpDown, OnAddNumericUpDown);
				_addDomainUpDownMenu = new ToolStripMenuItem("Add DomainUpDown", Resources.KryptonRibbonGroupDomainUpDown, OnAddDomainUpDown);
				_addDateTimePickerMenu = new ToolStripMenuItem("Add DateTimePicker", Resources.KryptonRibbonGroupDateTimePicker, OnAddDateTimePicker);
				_addTrackBarMenu = new ToolStripMenuItem("Add TrackBar", Resources.KryptonRibbonGroupTrackBar, OnAddTrackBar);
				_clearItemsMenu = new ToolStripMenuItem("Clear Items", null, OnClearItems);
				_deleteLinesMenu = new ToolStripMenuItem("Delete Lines", Resources.delete2, OnDeleteLines);
				_cms.Items.AddRange(new ToolStripItem[32]
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
					_addClusterMenu,
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
					_deleteLinesMenu
				});
				_addButtonMenu.ImageTransparentColor = Color.Magenta;
				_addColorButtonMenu.ImageTransparentColor = Color.Magenta;
				_addCheckBoxMenu.ImageTransparentColor = Color.Magenta;
				_addRadioButtonMenu.ImageTransparentColor = Color.Magenta;
				_addLabelMenu.ImageTransparentColor = Color.Magenta;
				_addCustomControlMenu.ImageTransparentColor = Color.Magenta;
				_addClusterMenu.ImageTransparentColor = Color.Magenta;
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
			_toggleHelpersMenu.Checked = _ribbonLines.Ribbon.InDesignHelperMode;
			_visibleMenu.Checked = _ribbonLines.Visible;
			_maximumLMenu.Checked = _ribbonLines.MaximumSize == GroupItemSize.Large;
			_maximumMMenu.Checked = _ribbonLines.MaximumSize == GroupItemSize.Medium;
			_maximumSMenu.Checked = _ribbonLines.MaximumSize == GroupItemSize.Small;
			_minimumLMenu.Checked = _ribbonLines.MinimumSize == GroupItemSize.Large;
			_minimumMMenu.Checked = _ribbonLines.MinimumSize == GroupItemSize.Medium;
			_minimumSMenu.Checked = _ribbonLines.MinimumSize == GroupItemSize.Small;
			_moveFirstMenu.Enabled = _moveFirstVerb.Enabled;
			_movePreviousMenu.Enabled = _movePrevVerb.Enabled;
			_moveNextMenu.Enabled = _moveNextVerb.Enabled;
			_moveLastMenu.Enabled = _moveLastVerb.Enabled;
			_moveToGroupMenu.Enabled = _moveToGroupMenu.DropDownItems.Count > 0;
			_clearItemsMenu.Enabled = _clearItemsVerb.Enabled;
			if (CommonHelper.ValidContextMenuStrip(_cms))
			{
				Point screenPt = _ribbonLines.Ribbon.ViewRectangleToPoint(_ribbonLines.LinesView);
				VisualPopupManager.Singleton.ShowContextMenuStrip(_cms, screenPt);
			}
		}
	}

	private void UpdateMoveToGroup()
	{
		_moveToGroupMenu.DropDownItems.Clear();
		if (_ribbonLines.Ribbon == null)
		{
			return;
		}
		foreach (KryptonRibbonGroup group in _ribbonLines.RibbonTab.Groups)
		{
			if (group != _ribbonLines.RibbonGroup)
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
		if (_ribbonLines != null && _ribbonLines.Ribbon != null && _ribbonLines.RibbonGroup.Items.Contains(_ribbonLines))
		{
			ToolStripMenuItem toolStripMenuItem = (ToolStripMenuItem)sender;
			KryptonRibbonGroup kryptonRibbonGroup = (KryptonRibbonGroup)toolStripMenuItem.Tag;
			DesignerTransaction designerTransaction = _designerHost.CreateTransaction("KryptonRibbonGroupLines MoveLinesToGroup");
			try
			{
				MemberDescriptor member = TypeDescriptor.GetProperties(_ribbonLines.RibbonGroup)["Items"];
				MemberDescriptor member2 = TypeDescriptor.GetProperties(kryptonRibbonGroup)["Items"];
				RaiseComponentChanging(null);
				RaiseComponentChanging(member);
				RaiseComponentChanging(member2);
				_ribbonLines.RibbonGroup.Items.Remove(_ribbonLines);
				kryptonRibbonGroup.Items.Add(_ribbonLines);
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
