#define DEBUG
using System.ComponentModel;
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

[TypeConverter(typeof(ButtonSpecFormFixedConverter))]
public abstract class ButtonSpecFormFixed : ButtonSpec
{
	private KryptonForm _form;

	public override bool AllowComponent => false;

	protected KryptonForm KryptonForm => _form;

	public virtual PaletteButtonSpecStyle ButtonSpecType
	{
		get
		{
			return base.ProtectedType;
		}
		set
		{
			base.ProtectedType = value;
		}
	}

	public ButtonSpecFormFixed(KryptonForm form, PaletteButtonSpecStyle fixedStyle)
	{
		Debug.Assert(form != null);
		_form = form;
		base.ProtectedType = fixedStyle;
	}
}
