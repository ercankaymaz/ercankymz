using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace DevAge.Windows.Forms;

[ToolboxItem(false)]
public class DevAgeNumericUpDown : NumericUpDown
{
	internal IContainer icontainer_0 = null;

	public DevAgeNumericUpDown()
	{
		icontainer_0 = new Container();
		base.UserEdit = true;
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && icontainer_0 != null)
		{
			icontainer_0.Dispose();
		}
		base.Dispose(disposing);
	}

	protected override void OnValidated(EventArgs e)
	{
		base.OnValidated(e);
		ParseEditText();
	}
}
