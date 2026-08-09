#define DEBUG
using System.Diagnostics;

namespace ComponentFactory.Krypton.Toolkit;

public abstract class KryptonPaletteTMSBase : Storage
{
	private KryptonInternalKCT _internalKCT;

	internal KryptonInternalKCT InternalKCT => _internalKCT;

	internal KryptonPaletteTMSBase(KryptonInternalKCT internalKCT, NeedPaintHandler needPaint)
	{
		Debug.Assert(internalKCT != null);
		_internalKCT = internalKCT;
		NeedPaint = needPaint;
	}
}
