using System.ComponentModel;
using System.Windows.Forms;
using _0005;

namespace buMW.Forms;

public class F_MwTriMProjectCurves : Form
{
	internal IContainer _0001 = null;

	internal Panel _0001;

	internal Button _0001;

	internal RadioButton _0001;

	internal RadioButton _0002;

	internal Label _0001;

	internal RadioButton _0003;

	internal RadioButton _0004;

	internal Label _0002;

	internal NumericUpDown _0001;

	internal CheckBox _0001;

	internal Button _0002;

	internal Panel _0002;

	internal Label _0003;

	internal NumericUpDown _0002;

	internal Label _0004;

	internal Label _0005;

	internal PictureBox _0001;

	internal Button _0003;

	internal Label _0006;

	public Button btn_cancel;

	internal ImageList _0001;

	internal Label _0007;

	internal Label _0008;

	internal NumericUpDown _0003;

	internal CheckBox _0002;

	internal NumericUpDown _0004;

	internal Label _000E;

	internal NumericUpDown _0005;

	internal Label _000F;

	internal NumericUpDown _0006;

	internal Label _0010;

	internal NumericUpDown _0007;

	internal Label _0011;

	public Button btn_ok;

	internal Panel _0003;

	internal Button _0004;

	internal Panel _0004;

	internal Button _0005;

	internal Button _0006;

	internal Label _0012;

	internal TabPage _0001;

	internal Button _0007;

	internal Panel _0005;

	internal CheckBox _0003;

	internal Button _0008;

	internal CheckBox _0004;

	internal Button _000E;

	internal CheckBox _0005;

	internal Button _000F;

	internal CheckBox _0006;

	internal Button _0010;

	internal CheckBox _0007;

	internal Label _0013;

	internal Button _0011;

	internal Panel _0006;

	internal Panel _0007;

	internal Label _0014;

	internal Button _0012;

	internal NumericUpDown _0008;

	internal Label _0015;

	internal Panel _0008;

	internal Label _0016;

	internal TabControl _0001;

	internal RadioButton _0005;

	internal RadioButton _0006;

	internal RadioButton _0007;

	internal Label _0017;

	internal NumericUpDown _000E;

	internal CheckBox _0008;

	internal CheckBox _000E;

	internal Button _0013;

	internal Panel _000E;

	internal Label _0018;

	internal RadioButton _0008;

	internal RadioButton _000E;

	internal Panel _000F;

	internal RadioButton _000F;

	internal Label _0019;

	internal RadioButton _0010;

	internal RadioButton _0011;

	internal Button _0014;

	internal CheckBox _000F;

	internal Panel _0010;

	public ComboBox combo_stepdirection;

	internal Label _001A;

	public F_MwTriMProjectCurves()
	{
		global::_0005._0002._0001(this);
	}

	protected override void Dispose(bool disposing)
	{
		do
		{
			if (8 == 0)
			{
				goto IL_0025;
			}
			if (!disposing)
			{
				goto IL_0014;
			}
			int num = ((this._0001 != null) ? 1 : 0);
			goto IL_004b;
			IL_0025:
			global::_0011._007E_0019_0006(this._0001);
			continue;
			IL_0014:
			num = 0;
			goto IL_004b;
			IL_004b:
			while (true)
			{
				bool flag = (byte)num != 0;
				while (true)
				{
					num = (flag ? 1 : 0);
					if (3 == 0)
					{
						break;
					}
					if (num == 0)
					{
						goto end_IL_004b;
					}
					if (false)
					{
						continue;
					}
					goto IL_0021;
				}
				continue;
				end_IL_004b:
				break;
			}
			continue;
			IL_0021:
			if (1 == 0)
			{
				goto IL_0014;
			}
			goto IL_0025;
		}
		while (false);
		_0095._0091_000F(this, disposing);
	}
}
