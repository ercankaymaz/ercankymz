#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTrackBarRedirect : Storage
{
	private PaletteDoubleRedirect _backRedirect;

	private PaletteElementColorRedirect _tickRedirect;

	private PaletteElementColorRedirect _trackRedirect;

	private PaletteElementColorRedirect _positionRedirect;

	[Browsable(false)]
	public override bool IsDefault => Back.IsDefault && Tick.IsDefault && Track.IsDefault && Position.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tick appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteElementColorRedirect Tick => _tickRedirect;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining track appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteElementColorRedirect Track => _trackRedirect;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining position marker appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteElementColorRedirect Position => _positionRedirect;

	internal PaletteBack Back => _backRedirect.Back;

	internal PaletteBackStyle BackStyle
	{
		get
		{
			return _backRedirect.BackStyle;
		}
		set
		{
			_backRedirect.BackStyle = value;
		}
	}

	public PaletteTrackBarRedirect(PaletteRedirect redirect, NeedPaintHandler needPaint)
	{
		Debug.Assert(redirect != null);
		NeedPaint = needPaint;
		_backRedirect = new PaletteDoubleRedirect(redirect, PaletteBackStyle.PanelClient, PaletteBorderStyle.ControlClient, NeedPaint);
		_tickRedirect = new PaletteElementColorRedirect(redirect, PaletteElement.TrackBarTick, NeedPaint);
		_trackRedirect = new PaletteElementColorRedirect(redirect, PaletteElement.TrackBarTrack, NeedPaint);
		_positionRedirect = new PaletteElementColorRedirect(redirect, PaletteElement.TrackBarPosition, NeedPaint);
	}

	public virtual void SetRedirector(PaletteRedirect redirect)
	{
		_backRedirect.SetRedirector(redirect);
		_tickRedirect.SetRedirector(redirect);
		_trackRedirect.SetRedirector(redirect);
		_positionRedirect.SetRedirector(redirect);
	}

	public void PopulateFromBase(PaletteState state)
	{
		_backRedirect.PopulateFromBase(state);
		_tickRedirect.PopulateFromBase(state);
		_trackRedirect.PopulateFromBase(state);
		_positionRedirect.PopulateFromBase(state);
	}

	private bool ShouldSerializeTick()
	{
		return !_tickRedirect.IsDefault;
	}

	private bool ShouldSerializeTrack()
	{
		return !_trackRedirect.IsDefault;
	}

	private bool ShouldSerializePosition()
	{
		return !_positionRedirect.IsDefault;
	}

	protected void OnNeedPaint(object sender, bool needLayout)
	{
		PerformNeedPaint(needLayout);
	}
}
