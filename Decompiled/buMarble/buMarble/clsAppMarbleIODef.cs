using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buEyeBaseVer5;

namespace buMarble;

[Serializable]
public class clsAppMarbleIODef : buSerilization5
{
	public bool Value = false;

	public int SourceIndex = -1;

	public string Address = _001B(107397155);

	public string Caption = _001B(107397155);

	public bool Invert = false;

	[NonSerialized]
	internal static GetString _001B;

	public clsAppMarbleIODef()
	{
	}

	public clsAppMarbleIODef(string address)
	{
		Address = address;
		Caption = address;
	}

	public override string ToString()
	{
		return global::_0014._009F_0003(Address, _001B(107396761), Value.ToString());
	}

	static clsAppMarbleIODef()
	{
		Strings.CreateGetStringDelegate(typeof(clsAppMarbleIODef));
	}
}
