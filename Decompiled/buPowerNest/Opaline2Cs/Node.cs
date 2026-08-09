using System;

namespace Opaline2Cs;

public class Node : Wrappable
{
	internal Node()
	{
	}

	~Node()
	{
		try
		{
		}
		finally
		{
			global::_0006._0007(this);
		}
	}

	public Node(IntPtr ptr)
	{
		__Ptr = ptr;
	}
}
