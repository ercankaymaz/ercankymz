using System;
using System.ComponentModel;
using System.Windows.Forms;
using _0005;
using ModuleWorks;
using ModuleWorks.ToolpathParameters;
using buClass;

namespace buMW.Forms;

public class F_MwTriMParalelCutLink : Form
{
	public FormProperties Properties = new FormProperties();

	public MachiningParams Par = new MachiningParams(Unit.Metric);

	internal IContainer _0001 = null;

	internal Panel _0001;

	internal Label _0001;

	internal NumericUpDown _0001;

	internal Label _0002;

	internal Label _0003;

	internal Button _0001;

	internal CheckBox _0001;

	internal CheckBox _0002;

	internal CheckBox _0003;

	internal CheckBox _0004;

	internal Panel _0002;

	internal RadioButton _0001;

	internal Label _0004;

	internal Label _0005;

	internal Label _0006;

	internal RadioButton _0002;

	public ComboBox comboBox1;

	internal Button _0002;

	public ComboBox comboBox4;

	public ComboBox comboBox3;

	public ComboBox comboBox2;

	internal Label _0007;

	internal NumericUpDown _0002;

	public ComboBox comboBox7;

	public ComboBox comboBox8;

	internal Button _0003;

	public ComboBox comboBox5;

	public ComboBox comboBox6;

	internal Button _0004;

	internal Panel _0003;

	internal Label _0008;

	internal NumericUpDown _0003;

	public ComboBox comboBox9;

	internal RadioButton _0003;

	public ComboBox comboBox10;

	internal RadioButton _0004;

	internal Button _0005;

	internal NumericUpDown _0004;

	public ComboBox comboBox11;

	public ComboBox comboBox12;

	internal Button _0006;

	internal Label _000E;

	internal Label _000F;

	internal Label _0010;

	internal Panel _0004;

	internal Label _0011;

	public ComboBox comboBox13;

	public ComboBox comboBox14;

	internal Button _0007;

	internal NumericUpDown _0005;

	public ComboBox comboBox15;

	public ComboBox comboBox16;

	internal Button _0008;

	internal Label _0012;

	internal Label _0013;

	internal Label _0014;

	internal Button _000E;

	internal Button _000F;

	internal Label _0015;

	internal PictureBox _0001;

	public Button btn_cancel;

	internal ImageList _0001;

	public Button btn_ok;

	public F_MwTriMParalelCutLink()
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Expected O, but got Unknown
		global::_0005._0002._0001(this);
	}

	public void Init()
	{
		if (0 == 0)
		{
			Properties.Inited = false;
		}
		bool flag = Properties.Height > 10;
		if (0 == 0)
		{
			if (!flag)
			{
				goto IL_0113;
			}
			if (3 == 0)
			{
				goto IL_007c;
			}
		}
		_0097._008C_0011(this, Properties.Height);
		if (4 == 0)
		{
			goto IL_00cb;
		}
		goto IL_0113;
		IL_0113:
		bool flag2 = Properties.Width > 10;
		if (false || flag2)
		{
			goto IL_007c;
		}
		goto IL_0097;
		IL_0097:
		_0095._0092_000F(this, Properties.TopMost);
		_0086_0003._0018_0014(this, Properties.FormPosition);
		UpdateControlFromType();
		goto IL_00cb;
		IL_007c:
		if (0 == 0)
		{
			_0097._008D_0011(this, Properties.Width);
		}
		goto IL_0097;
		IL_00cb:
		Properties.Result = DialogResult.None;
		Properties.Inited = true;
	}

	public void UpdateControlFromType()
	{
	}

	public void Apply()
	{
	}

	internal void _0001(object P_0, EventArgs P_1)
	{
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
