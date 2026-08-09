using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class AxesGroupChar : buSerilization
{
	public string AxX = _0092(107397254);

	public string AxY = _0092(107397254);

	public string AxZ = _0092(107397254);

	public string AxA = _0092(107397254);

	public string AxB = _0092(107397254);

	public string AxC = _0092(107397254);

	public string AxX1 = _0092(107397254);

	public string AxX2 = _0092(107397254);

	public string AxY1 = _0092(107397254);

	public string AxY2 = _0092(107397254);

	public string AxZ1 = _0092(107397254);

	public string AxZ2 = _0092(107397254);

	public string AxZ3 = _0092(107397254);

	[NonSerialized]
	internal static GetString _0092;

	public unsafe override string ToString()
	{
		void* ptr = stackalloc byte[24];
		string text = _0092(107397254);
		*(bool*)ptr = global::_0013._007E_001D(AxX) >= 0;
		if (*(bool*)ptr)
		{
			((sbyte*)ptr)[1] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[1])
			{
				text = global::_0003._0005(text, _0092(107397314));
			}
			text = global::_0003._0005(text, global::_0010._007E_0012(AxX));
		}
		((sbyte*)ptr)[2] = ((global::_0013._007E_001D(AxY) >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[2])
		{
			((sbyte*)ptr)[3] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[3])
			{
				text = global::_0003._0005(text, _0092(107397314));
			}
			text = global::_0003._0005(text, global::_0010._007E_0012(AxY));
		}
		((sbyte*)ptr)[4] = ((global::_0013._007E_001D(AxZ) >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[4])
		{
			((sbyte*)ptr)[5] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[5])
			{
				text = global::_0003._0005(text, _0092(107397314));
			}
			text = global::_0003._0005(text, global::_0010._007E_0012(AxZ));
		}
		((sbyte*)ptr)[6] = ((global::_0013._007E_001D(AxA) >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[6])
		{
			((sbyte*)ptr)[7] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[7])
			{
				text = global::_0003._0005(text, _0092(107397314));
			}
			text = (text = global::_0010._007E_0012(AxA));
		}
		((sbyte*)ptr)[8] = ((global::_0013._007E_001D(AxC) >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[8])
		{
			if (1 == 0)
			{
				goto IL_0503;
			}
			((sbyte*)ptr)[9] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[9])
			{
				text = global::_0003._0005(text, _0092(107397314));
			}
			text = global::_0003._0005(text, global::_0010._007E_0012(AxC));
		}
		((sbyte*)ptr)[10] = ((global::_0013._007E_001D(AxX1) >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[10])
		{
			((sbyte*)ptr)[11] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[11])
			{
				text = global::_0003._0005(text, _0092(107397314));
			}
			text = global::_0003._0005(text, global::_0010._007E_0012(AxX1));
		}
		goto IL_02e4;
		IL_02e4:
		((sbyte*)ptr)[12] = ((global::_0013._007E_001D(AxX2) >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[12])
		{
			((sbyte*)ptr)[13] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[13])
			{
				text = global::_0003._0005(text, _0092(107397314));
			}
			text = global::_0003._0005(text, global::_0010._007E_0012(AxX2));
		}
		((sbyte*)ptr)[14] = ((global::_0013._007E_001D(AxY1) >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[14])
		{
			((sbyte*)ptr)[15] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[15])
			{
				text = global::_0003._0005(text, _0092(107397314));
			}
			text = global::_0003._0005(text, global::_0010._007E_0012(AxY1));
		}
		((sbyte*)ptr)[16] = ((global::_0013._007E_001D(AxY2) >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[16])
		{
			((sbyte*)ptr)[17] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[17])
			{
				text = global::_0003._0005(text, _0092(107397314));
			}
			text = global::_0003._0005(text, global::_0010._007E_0012(AxY2));
		}
		((sbyte*)ptr)[18] = ((global::_0013._007E_001D(AxZ1) >= 0) ? ((sbyte)1) : ((sbyte)0));
		sbyte num = ((sbyte*)ptr)[18];
		if (0 == 0)
		{
			if (num != 0)
			{
				((sbyte*)ptr)[19] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[19])
				{
					text = global::_0003._0005(text, _0092(107397314));
				}
				text = global::_0003._0005(text, global::_0010._007E_0012(AxZ1));
			}
			((sbyte*)ptr)[20] = ((global::_0013._007E_001D(AxZ2) >= 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[20])
			{
				((sbyte*)ptr)[21] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
				num = ((sbyte*)ptr)[21];
				goto IL_0501;
			}
			goto IL_0543;
		}
		goto IL_057e;
		IL_0503:
		if (false)
		{
			goto IL_02e4;
		}
		text = global::_0003._0005(text, _0092(107397314));
		goto IL_0526;
		IL_0526:
		text = global::_0003._0005(text, global::_0010._007E_0012(AxZ2));
		goto IL_0543;
		IL_05c0:
		return text;
		IL_0543:
		((sbyte*)ptr)[22] = ((global::_0013._007E_001D(AxZ3) >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[22])
		{
			((sbyte*)ptr)[23] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			num = ((sbyte*)ptr)[23];
			goto IL_057e;
		}
		goto IL_05c0;
		IL_0501:
		if (num != 0)
		{
			goto IL_0503;
		}
		goto IL_0526;
		IL_057e:
		if (false)
		{
			goto IL_0501;
		}
		if (num != 0)
		{
			text = global::_0003._0005(text, _0092(107397314));
		}
		text = global::_0003._0005(text, global::_0010._007E_0012(AxZ3));
		goto IL_05c0;
	}

	static AxesGroupChar()
	{
		Strings.CreateGetStringDelegate(typeof(AxesGroupChar));
	}
}
