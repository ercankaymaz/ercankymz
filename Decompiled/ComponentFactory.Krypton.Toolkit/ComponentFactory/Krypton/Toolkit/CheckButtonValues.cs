using System.Drawing;

namespace ComponentFactory.Krypton.Toolkit;

public class CheckButtonValues : ButtonValues
{
	private CheckButtonImageStates _imageStates;

	public CheckButtonValues(NeedPaintHandler needPaint)
		: base(needPaint)
	{
	}

	protected override ButtonImageStates CreateImageStates()
	{
		_imageStates = new CheckButtonImageStates();
		return _imageStates;
	}

	public override Image GetImage(PaletteState state)
	{
		Image image = null;
		switch (state)
		{
		case PaletteState.CheckedNormal:
			image = _imageStates.ImageCheckedNormal;
			break;
		case PaletteState.CheckedPressed:
			image = _imageStates.ImageCheckedPressed;
			break;
		case PaletteState.CheckedTracking:
			image = _imageStates.ImageCheckedTracking;
			break;
		}
		if (image == null)
		{
			image = base.GetImage(state);
		}
		return image;
	}
}
