#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public class PaletteTrackBarPositionStates : Storage
{
	private PaletteElementColor _positionState;

	[Browsable(false)]
	public override bool IsDefault => Position.IsDefault;

	[KryptonPersist]
	[Category("Visuals")]
	[Description("Overrides for defining position appearance.")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public PaletteElementColor Position => _positionState;

	public PaletteTrackBarPositionStates(PaletteTrackBarRedirect redirect, NeedPaintHandler needPaint)
		: this(redirect.Position, needPaint)
	{
	}

	public PaletteTrackBarPositionStates(IPaletteElementColor inheritPosition, NeedPaintHandler needPaint)
	{
		Debug.Assert(inheritPosition != null);
		NeedPaint = needPaint;
		_positionState = new PaletteElementColor(inheritPosition, needPaint);
	}

	public void SetInherit(IPaletteElementColor inheritPosition)
	{
		_positionState.SetInherit(inheritPosition);
	}

	public void PopulateFromBase(PaletteState state)
	{
		_positionState.PopulateFromBase(state);
	}

	private bool ShouldSerializePosition()
	{
		return !_positionState.IsDefault;
	}
}
