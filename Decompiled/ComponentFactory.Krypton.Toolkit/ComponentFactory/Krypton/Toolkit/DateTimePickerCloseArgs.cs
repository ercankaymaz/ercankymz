using System;

namespace ComponentFactory.Krypton.Toolkit;

public class DateTimePickerCloseArgs : EventArgs
{
	private KryptonContextMenu _kcm;

	public KryptonContextMenu KryptonContextMenu => _kcm;

	public DateTimePickerCloseArgs(KryptonContextMenu kcm)
	{
		_kcm = kcm;
	}
}
