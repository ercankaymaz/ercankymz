using System.Runtime.CompilerServices;
using System.Windows.Forms;
using buMutliTextbox;

namespace ns22;

internal sealed class Class59
{
	internal bool bool_0;

	internal bool bool_1;

	internal bool bool_2;

	[CompilerGenerated]
	private Keys keys_0;

	[CompilerGenerated]
	private FCTBAction fctbaction_0;

	public Class59(Keys keys_1, FCTBAction fctbaction_1)
	{
		KeyEventArgs e = new KeyEventArgs(keys_1);
		bool_0 = e.Control;
		bool_1 = e.Shift;
		bool_2 = e.Alt;
		method_1(e.KeyCode);
		method_3(fctbaction_1);
	}

	[SpecialName]
	[CompilerGenerated]
	public Keys method_0()
	{
		return keys_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public void method_1(Keys keys_1)
	{
		keys_0 = keys_1;
	}

	[SpecialName]
	[CompilerGenerated]
	public FCTBAction method_2()
	{
		return fctbaction_0;
	}

	[SpecialName]
	[CompilerGenerated]
	public void method_3(FCTBAction fctbaction_1)
	{
		fctbaction_0 = fctbaction_1;
	}
}
