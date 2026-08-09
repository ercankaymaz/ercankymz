using System;

namespace ModuleWorks.PPInterface;

public class PostingCancelledException : ApplicationException
{
	public PostingCancelledException(string message)
		: base(message)
	{
	}
}
