using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;

namespace ComponentFactory.Krypton.Toolkit;

[ToolboxItem(true)]
[ToolboxBitmap(typeof(KryptonCheckButton), "ToolboxBitmaps.KryptonCheckButton.bmp")]
[DefaultEvent("Click")]
[DefaultProperty("Text")]
[Designer("ComponentFactory.Krypton.Toolkit.KryptonCheckButtonDesigner, ComponentFactory.Krypton.Toolkit, Version=4.6.0.0, Culture=neutral, PublicKeyToken=a87e673e9ecb6e8e")]
[DesignerCategory("code")]
[Description("Toggles checked state when user clicks button.")]
[ClassInterface(ClassInterfaceType.AutoDispatch)]
[ComVisible(true)]
public class KryptonCheckButton : KryptonButton
{
	private PaletteTriple _stateCheckedNormal;

	private PaletteTriple _stateCheckedTracking;

	private PaletteTriple _stateCheckedPressed;

	private PaletteTripleOverride _overrideCheckedFocus;

	private PaletteTripleOverride _overrideCheckedNormal;

	private PaletteTripleOverride _overrideCheckedTracking;

	private PaletteTripleOverride _overrideCheckedPressed;

	private CheckButtonValues _checkedValues;

	private bool _wasChecked;

	[Category("Visuals")]
	[Description("Overrides for defining normal checked button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedNormal => _stateCheckedNormal;

	[Category("Visuals")]
	[Description("Overrides for defining hot tracking checked button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedTracking => _stateCheckedTracking;

	[Category("Visuals")]
	[Description("Overrides for defining pressed checked button appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteTriple StateCheckedPressed => _stateCheckedPressed;

	[Category("Appearance")]
	[Description("Indicates whether the control is in the checked state.")]
	[DefaultValue(false)]
	[Bindable(true)]
	public bool Checked
	{
		get
		{
			return ViewDrawButton.Checked;
		}
		set
		{
			if (value != ViewDrawButton.Checked)
			{
				CancelEventArgs e = new CancelEventArgs();
				OnCheckedChanging(e);
				if (!e.Cancel)
				{
					ViewDrawButton.Checked = value;
					OnCheckedChanged(EventArgs.Empty);
					PerformNeedPaint(needLayout: true);
				}
			}
		}
	}

	[Category("Behavior")]
	[Description("Indicates whether the user can uncheck the button when in the checked state.")]
	[DefaultValue(true)]
	public bool AllowUncheck
	{
		get
		{
			return ViewDrawButton.AllowUncheck;
		}
		set
		{
			ViewDrawButton.AllowUncheck = value;
		}
	}

	[Category("Behavior")]
	[Description("Command associated with the check button.")]
	[DefaultValue(null)]
	public override IKryptonCommand KryptonCommand
	{
		get
		{
			return base.KryptonCommand;
		}
		set
		{
			if (base.KryptonCommand != value)
			{
				if (base.KryptonCommand == null)
				{
					_wasChecked = Checked;
				}
				base.KryptonCommand = value;
				if (base.KryptonCommand == null)
				{
					Checked = _wasChecked;
				}
			}
		}
	}

	[Category("Property Changing")]
	[Description("Occurs whenever the Checked property is about to change.")]
	public event CancelEventHandler CheckedChanging;

	[Category("Property Changed")]
	[Description("Occurs whenever the Checked property has changed.")]
	public event EventHandler CheckedChanged;

	public KryptonCheckButton()
	{
		_stateCheckedNormal = new PaletteTriple(base.StateCommon, base.NeedPaintDelegate);
		_stateCheckedTracking = new PaletteTriple(base.StateCommon, base.NeedPaintDelegate);
		_stateCheckedPressed = new PaletteTriple(base.StateCommon, base.NeedPaintDelegate);
		_overrideCheckedFocus = new PaletteTripleOverride(base.OverrideFocus, _stateCheckedNormal, PaletteState.FocusOverride);
		_overrideCheckedNormal = new PaletteTripleOverride(base.OverrideDefault, _overrideCheckedFocus, PaletteState.NormalDefaultOverride);
		_overrideCheckedTracking = new PaletteTripleOverride(base.OverrideFocus, _stateCheckedTracking, PaletteState.FocusOverride);
		_overrideCheckedPressed = new PaletteTripleOverride(base.OverrideFocus, _stateCheckedPressed, PaletteState.FocusOverride);
		ViewDrawButton.SetCheckedPalettes(_overrideCheckedNormal, _overrideCheckedTracking, _overrideCheckedPressed);
	}

	private bool ShouldSerializeStateCheckedNormal()
	{
		return !_stateCheckedNormal.IsDefault;
	}

	private bool ShouldSerializeStateCheckedTracking()
	{
		return !_stateCheckedTracking.IsDefault;
	}

	private bool ShouldSerializeStateCheckedPressed()
	{
		return !_stateCheckedPressed.IsDefault;
	}

	protected override void OnGotFocus(EventArgs e)
	{
		if (!ViewDrawButton.IsFixed)
		{
			_overrideCheckedFocus.Apply = true;
			_overrideCheckedTracking.Apply = true;
			_overrideCheckedPressed.Apply = true;
		}
		base.OnGotFocus(e);
	}

	protected override void OnLostFocus(EventArgs e)
	{
		if (!ViewDrawButton.IsFixed)
		{
			_overrideCheckedFocus.Apply = false;
			_overrideCheckedTracking.Apply = false;
			_overrideCheckedPressed.Apply = false;
		}
		base.OnLostFocus(e);
	}

	protected override void OnClick(EventArgs e)
	{
		if (!Checked || AllowUncheck)
		{
			Checked = !Checked;
		}
		base.OnClick(e);
	}

	protected override void OnKryptonCommandChanged(EventArgs e)
	{
		base.OnKryptonCommandChanged(e);
		if (KryptonCommand != null)
		{
			Checked = KryptonCommand.Checked;
		}
	}

	protected override void OnCommandPropertyChanged(object sender, PropertyChangedEventArgs e)
	{
		string propertyName = e.PropertyName;
		string text = propertyName;
		if (text == "CheckState")
		{
			Checked = KryptonCommand.Checked;
		}
		base.OnCommandPropertyChanged(sender, e);
	}

	protected override ButtonValues CreateButtonValues(NeedPaintHandler needPaint)
	{
		_checkedValues = new CheckButtonValues(needPaint);
		return _checkedValues;
	}

	protected virtual void OnCheckedChanging(CancelEventArgs e)
	{
		if (this.CheckedChanging != null)
		{
			this.CheckedChanging(this, e);
		}
	}

	protected virtual void OnCheckedChanged(EventArgs e)
	{
		if (this.CheckedChanged != null)
		{
			this.CheckedChanged(this, e);
		}
		if (KryptonCommand != null)
		{
			KryptonCommand.Checked = Checked;
		}
	}
}
