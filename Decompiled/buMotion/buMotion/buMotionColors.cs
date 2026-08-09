using System;
using System.Drawing;
using buClass;

namespace buMotion;

[Serializable]
public class buMotionColors : buSerilization
{
	public static Color clrWarning;

	public static Color clrAlarm;

	public static Color clralarmSoft;

	public static Color clrInfo;

	public static Color clrMessage;

	static buMotionColors()
	{
		while (true)
		{
			clrWarning = global::_001F_0002._0001_0003();
			clrAlarm = global::_001F_0002._0002_0003();
			clralarmSoft = global::_001F_0002._0003_0003();
			while (true)
			{
				clrInfo = global::_001F_0002._0004_0003();
				while (0 == 0)
				{
					clrMessage = global::_001F_0002._0005_0003();
					if (false)
					{
						continue;
					}
					goto IL_0042;
				}
				break;
				IL_0042:
				if (false)
				{
					break;
				}
				if (5u != 0)
				{
					return;
				}
			}
		}
	}
}
