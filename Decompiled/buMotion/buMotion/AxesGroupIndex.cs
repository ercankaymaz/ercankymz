using System;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public class AxesGroupIndex : buSerilization
{
	public int AxX = -1;

	public int AxY = -1;

	public int AxZ = -1;

	public int AxA = -1;

	public int AxB = -1;

	public int AxC = -1;

	public int AxX1 = -1;

	public int AxX2 = -1;

	public int AxY1 = -1;

	public int AxY2 = -1;

	public int AxZ1 = -1;

	public int AxZ2 = -1;

	public int AxZ3 = -1;

	[NonSerialized]
	internal static GetString _009A;

	public unsafe override string ToString()
	{
		byte* num = stackalloc byte[24];
		void* ptr = default(void*);
		if (0 == 0)
		{
			ptr = num;
		}
		string text = _009A(107397240);
		*(bool*)ptr = AxX >= 0;
		if (*(bool*)ptr)
		{
			((sbyte*)ptr)[1] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[1])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = global::_0002._0003(text, _009A(107389901), AxX.ToString());
		}
		((sbyte*)ptr)[2] = ((AxY >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[2])
		{
			((sbyte*)ptr)[3] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[3])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = global::_0002._0003(text, _009A(107389864), AxY.ToString());
		}
		((sbyte*)ptr)[4] = ((AxZ >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[4])
		{
			((sbyte*)ptr)[5] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[5])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = global::_0002._0003(text, _009A(107389859), AxZ.ToString());
		}
		((sbyte*)ptr)[6] = ((AxA >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[6])
		{
			((sbyte*)ptr)[7] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[7])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = (text = global::_0003._0005(_009A(107389854), AxA.ToString()));
		}
		((sbyte*)ptr)[8] = ((AxC >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[8])
		{
			((sbyte*)ptr)[9] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[9])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = global::_0002._0003(text, _009A(107389881), AxC.ToString());
		}
		((sbyte*)ptr)[10] = ((AxX1 >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[10])
		{
			((sbyte*)ptr)[11] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[11])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = global::_0002._0003(text, _009A(107389876), AxX1.ToString());
		}
		((sbyte*)ptr)[12] = ((AxX2 >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[12])
		{
			((sbyte*)ptr)[13] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[13])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = global::_0002._0003(text, _009A(107389835), AxX2.ToString());
		}
		((sbyte*)ptr)[14] = ((AxY1 >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[14])
		{
			((sbyte*)ptr)[15] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[15])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = global::_0002._0003(text, _009A(107389826), AxY1.ToString());
		}
		((sbyte*)ptr)[16] = ((AxY2 >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[16])
		{
			((sbyte*)ptr)[17] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[17])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = global::_0002._0003(text, _009A(107389849), AxY2.ToString());
		}
		((sbyte*)ptr)[18] = ((AxZ1 >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[18])
		{
			((sbyte*)ptr)[19] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[19])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = global::_0002._0003(text, _009A(107389840), AxZ1.ToString());
		}
		((sbyte*)ptr)[20] = ((AxZ2 >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[20])
		{
			((sbyte*)ptr)[21] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[21])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = global::_0002._0003(text, _009A(107389799), AxZ2.ToString());
		}
		((sbyte*)ptr)[22] = ((AxZ3 >= 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[22])
		{
			((sbyte*)ptr)[23] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[23])
			{
				text = global::_0003._0005(text, _009A(107397300));
			}
			text = global::_0002._0003(text, _009A(107389790), AxZ3.ToString());
		}
		return text;
	}

	static AxesGroupIndex()
	{
		Strings.CreateGetStringDelegate(typeof(AxesGroupIndex));
	}
}
