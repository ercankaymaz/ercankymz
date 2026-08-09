using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ContextPositionMenuArgs : ContextMenuArgs
{
	private KryptonContextMenuPositionH _positionH;

	private KryptonContextMenuPositionV _positionV;

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

	public ContextPositionMenuArgs()
		: this(null, null, KryptonContextMenuPositionH.Left, KryptonContextMenuPositionV.Below)
	{
	}

	public ContextPositionMenuArgs(ContextMenuStrip cms)
		: this(cms, null, KryptonContextMenuPositionH.Left, KryptonContextMenuPositionV.Below)
	{
	}

	public ContextPositionMenuArgs(KryptonContextMenu kcm, KryptonContextMenuPositionH positionH, KryptonContextMenuPositionV positionV)
		: this(null, kcm, positionH, positionV)
	{
	}

	public ContextPositionMenuArgs(ContextMenuStrip cms, KryptonContextMenu kcm, KryptonContextMenuPositionH positionH, KryptonContextMenuPositionV positionV)
		: base(cms, kcm)
	{
		_positionH = positionH;
		_positionV = positionV;
	}
}
