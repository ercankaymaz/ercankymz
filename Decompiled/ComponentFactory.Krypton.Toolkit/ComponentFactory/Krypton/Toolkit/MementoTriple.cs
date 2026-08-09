using System;

namespace ComponentFactory.Krypton.Toolkit;

public class MementoTriple : MementoDouble
{
	public IDisposable third;

	public override void Dispose(bool disposing)
	{
		if (third != null)
		{
			third.Dispose();
			third = null;
		}
		base.Dispose(disposing);
	}
}
