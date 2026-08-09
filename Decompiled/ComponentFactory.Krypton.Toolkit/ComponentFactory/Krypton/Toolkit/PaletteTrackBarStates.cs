#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTrackBarStates : Storage
{
	private PaletteElementColor _tickState;

	private PaletteElementColor _trackState;

	private PaletteElementColor _positionState;

	[Browsable(false)]
	public override bool IsDefault => Tick.IsDefault && Track.IsDefault && Position.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining tick appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteElementColor Tick => _tickState;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining track appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteElementColor Track => _trackState;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining position appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteElementColor Position => _positionState;

	public PaletteTrackBarStates(PaletteTrackBarRedirect redirect, NeedPaintHandler needPaint)
		: this(redirect.Tick, redirect.Track, redirect.Position, needPaint)
	{
	}

	public PaletteTrackBarStates(IPaletteElementColor inheritTick, IPaletteElementColor inheritTrack, IPaletteElementColor inheritPosition, NeedPaintHandler needPaint)
	{
		Debug.Assert(inheritTick != null);
		Debug.Assert(inheritTrack != null);
		Debug.Assert(inheritPosition != null);
		NeedPaint = needPaint;
		_tickState = new PaletteElementColor(inheritTick, needPaint);
		_trackState = new PaletteElementColor(inheritTrack, needPaint);
		_positionState = new PaletteElementColor(inheritPosition, needPaint);
	}

	public void SetInherit(IPaletteElementColor inheritTick, IPaletteElementColor inheritTrack, IPaletteElementColor inheritPosition)
	{
		_tickState.SetInherit(inheritTick);
		_trackState.SetInherit(inheritTrack);
		_positionState.SetInherit(inheritPosition);
	}

	public void PopulateFromBase(PaletteState state)
	{
		_tickState.PopulateFromBase(state);
		_trackState.PopulateFromBase(state);
		_positionState.PopulateFromBase(state);
	}

	private bool ShouldSerializeTick()
	{
		return !_tickState.IsDefault;
	}

	private bool ShouldSerializeTrack()
	{
		return !_trackState.IsDefault;
	}

	private bool ShouldSerializePosition()
	{
		return !_positionState.IsDefault;
	}
}
