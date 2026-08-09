using System;

namespace Opaline2Cs;

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
		}
		finally
		{
			global::_0006._0007(this);
		}
	}
}
