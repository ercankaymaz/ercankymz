using System;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoDouble : MementoDisposable
{
	public IDisposable first;

	public IDisposable second;

	public override void Dispose(bool disposing)
	{
		if (first != null)
		{
			first.Dispose();
			first = null;
		}
		if (second != null)
		{
			second.Dispose();
			second = null;
		}
		base.Dispose(disposing);
	}
}
