using System;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class DataGridViewButtonSpecClickEventArgs : EventArgs
{
	private DataGridViewColumn _column;

	private DataGridViewCell _cell;

	private ButtonSpecAny _buttonSpec;

	public DataGridViewColumn Column => _column;

	public DataGridViewCell Cell => _cell;

	public ButtonSpecAny ButtonSpec => _buttonSpec;

	public DataGridViewButtonSpecClickEventArgs(DataGridViewColumn column, DataGridViewCell cell, ButtonSpecAny buttonSpec)
	{
		_column = column;
		_cell = cell;
		_buttonSpec = buttonSpec;
	}
}
