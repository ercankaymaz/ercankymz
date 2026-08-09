using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteDataGridViewContentCommon : PaletteDataGridViewContentStates
{
	private Padding _padding;

	private Font _font;

	private PaletteRelativeAlign _textH;

	private PaletteRelativeAlign _textV;

	[Browsable(false)]
	public override bool IsDefault => base.IsDefault && Padding.Equals(CommonHelper.InheritPadding) && Font == null && TextH == PaletteRelativeAlign.Inherit && TextV == PaletteRelativeAlign.Inherit;

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Font for drawing the content text.")]
	[DefaultValue(null)]
	[RefreshProperties(RefreshProperties.All)]
	public virtual Font Font
	{
		get
		{
			return _font;
		}
		set
		{
			if (value != _font)
			{
				_font = value;
				OnSyncPropertyChanged(EventArgs.Empty);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Relative horizontal alignment of content text.")]
	[DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteRelativeAlign TextH
	{
		get
		{
			return _textH;
		}
		set
		{
			if (value != _textH)
			{
				_textH = value;
				OnSyncPropertyChanged(EventArgs.Empty);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Relative vertical alignment of content text.")]
	[DefaultValue(typeof(PaletteRelativeAlign), "Inherit")]
	[RefreshProperties(RefreshProperties.All)]
	public virtual PaletteRelativeAlign TextV
	{
		get
		{
			return _textV;
		}
		set
		{
			if (value != _textV)
			{
				_textV = value;
				OnSyncPropertyChanged(EventArgs.Empty);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	[KryptonPersist(false)]
	[Category("Visuals")]
	[Description("Padding between the border and content drawing.")]
	[DefaultValue(typeof(Padding), "-1,-1,-1,-1")]
	[RefreshProperties(RefreshProperties.All)]
	public Padding Padding
	{
		get
		{
			return _padding;
		}
		set
		{
			if (!value.Equals(_padding))
			{
				_padding = value;
				OnSyncPropertyChanged(EventArgs.Empty);
				PerformNeedPaint(needLayout: true);
			}
		}
	}

	public PaletteDataGridViewContentCommon(IPaletteContent inherit, NeedPaintHandler needPaint)
		: base(inherit, needPaint)
	{
		_padding = CommonHelper.InheritPadding;
		_textH = PaletteRelativeAlign.Inherit;
		_textV = PaletteRelativeAlign.Inherit;
	}

	public override void PopulateFromBase(PaletteState state)
	{
		base.PopulateFromBase(state);
		Font = GetContentShortTextFont(state);
		TextH = GetContentShortTextH(state);
		TextV = GetContentShortTextV(state);
		Padding = GetContentPadding(state);
	}

	public override Font GetContentShortTextFont(PaletteState state)
	{
		if (_font != null)
		{
			return _font;
		}
		return base.Inherit.GetContentShortTextFont(state);
	}

	public override PaletteRelativeAlign GetContentShortTextH(PaletteState state)
	{
		if (_textH != PaletteRelativeAlign.Inherit)
		{
			return _textH;
		}
		return base.Inherit.GetContentShortTextH(state);
	}

	public override PaletteRelativeAlign GetContentShortTextV(PaletteState state)
	{
		if (_textV != PaletteRelativeAlign.Inherit)
		{
			return _textV;
		}
		return base.Inherit.GetContentShortTextV(state);
	}

	public void ResetPadding()
	{
		Padding = CommonHelper.InheritPadding;
	}

	public override Padding GetContentPadding(PaletteState state)
	{
		Padding contentPadding = base.Inherit.GetContentPadding(state);
		Padding padding = Padding;
		if (padding.Left != -1)
		{
			contentPadding.Left = padding.Left;
		}
		if (padding.Right != -1)
		{
			contentPadding.Right = padding.Right;
		}
		if (padding.Top != -1)
		{
			contentPadding.Top = padding.Top;
		}
		if (padding.Bottom != -1)
		{
			contentPadding.Bottom = padding.Bottom;
		}
		return contentPadding;
	}
}
