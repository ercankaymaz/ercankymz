using System.ComponentModel;

namespace ComponentFactory.Krypton.Toolkit;

public class DateTimePickerDropArgs : CancelEventArgs
{
	private KryptonContextMenu _kcm;

	private KryptonContextMenuPositionH _positionH;

	private KryptonContextMenuPositionV _positionV;

	public KryptonContextMenu KryptonContextMenu => _kcm;

	public KryptonContextMenuPositionH PositionH
	{
		get
		{
			return _positionH;
		}
		set
		{
			_positionH = value;
		}
	}

	public KryptonContextMenuPositionV PositionV
	{
		get
		{
			return _positionV;
		}
		set
		{
			_positionV = value;
		}
	}

	public DateTimePickerDropArgs(KryptonContextMenu kcm, KryptonContextMenuPositionH positionH, KryptonContextMenuPositionV positionV)
	{
		_kcm = kcm;
		_positionH = positionH;
		_positionV = positionV;
	}
}
