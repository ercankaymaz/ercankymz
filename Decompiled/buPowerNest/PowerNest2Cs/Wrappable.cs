using System;

namespace PowerNest2Cs;

public abstract class Wrappable
{
	public IntPtr __Ptr;

	public static T Create<T>(IntPtr ptr, T t) where T : Wrappable
	{
		bool num = ptr != IntPtr.Zero;
		do
		{
			if (0 == 0)
			{
				bool flag = num;
				num = flag;
			}
		}
		while (2 == 0);
		if (num)
		{
			goto IL_0016;
		}
		T val;
		do
		{
			val = null;
		}
		while (false);
		T result = val;
		goto IL_003e;
		IL_003e:
		if (uint.MaxValue != 0)
		{
			return result;
		}
		goto IL_0016;
		IL_0016:
		if (6u != 0)
		{
			t.__Ptr = ptr;
		}
		result = t;
		goto IL_003e;
	}

	public override bool Equals(object Obj)
	{
		bool result = default(bool);
		while (4u != 0)
		{
			Wrappable wrappable = (Wrappable)Obj;
			result = _000E._000F(__Ptr, wrappable.__Ptr);
			if (0 == 0)
			{
				break;
			}
		}
		return result;
	}

	public static bool operator ==(Wrappable obj1, Wrappable obj2)
	{
		return _0011._007E_0015(obj1, obj2);
	}

	public static bool operator !=(Wrappable obj1, Wrappable obj2)
	{
		while (true)
		{
			if (0 == 0)
			{
			}
			while (8u != 0)
			{
				bool num = _0011._007E_0015(obj1, obj2);
				if (0 == 0)
				{
					num = !num;
				}
				bool result = num;
				if (8u != 0)
				{
					return result;
				}
			}
		}
	}

	public override int GetHashCode()
	{
		return __Ptr.GetHashCode();
	}
}
