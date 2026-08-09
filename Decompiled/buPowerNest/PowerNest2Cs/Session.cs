using System;
using _0005;

namespace PowerNest2Cs;

public class Session : Wrappable
{
	public IntPtr Ptr => __Ptr;

	internal Session()
	{
	}

	~Session()
	{
		try
		{
			if (4 == 0 || !_000E._0010(__Ptr, IntPtr.Zero))
			{
				return;
			}
			try
			{
				do
				{
					_0005._0003._0001(__Ptr);
					__Ptr = IntPtr.Zero;
				}
				while (false);
			}
			catch
			{
				if (false)
				{
				}
			}
		}
		finally
		{
			global::_0006._0007(this);
			while (5 == 0 || 8 == 0)
			{
			}
		}
	}
}
