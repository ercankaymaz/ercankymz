namespace devDept.Geometry;

public static class FlagsHelper
{
	public static bool IsSet<T>(T flags, T flag) where T : struct
	{
		int num = (int)(object)flags;
		int num2 = (int)(object)flag;
		return (num & num2) != 0;
	}

	public static void Set<T>(ref T flags, T flag) where T : struct
	{
		int num = (int)(object)flags;
		int num2 = (int)(object)flag;
		flags = (T)(object)(num | num2);
	}

	public static void Unset<T>(ref T flags, T flag) where T : struct
	{
		int num = (int)(object)flags;
		int num2 = (int)(object)flag;
		flags = (T)(object)(num & ~num2);
	}

	public static void SetUnset<T>(ref T flags, T flag, bool set) where T : struct
	{
		int num = (int)(object)flags;
		int num2 = (int)(object)flag;
		if (set)
		{
			flags = (T)(object)(num | num2);
		}
		else
		{
			flags = (T)(object)(num & ~num2);
		}
	}

	public static void Invert<T>(ref T flags, T flag) where T : struct
	{
		int num = (int)(object)flags;
		int num2 = (int)(object)flag;
		flags = (T)(object)(((num & num2) != 0) ? (num & ~num2) : (num | num2));
	}
}
