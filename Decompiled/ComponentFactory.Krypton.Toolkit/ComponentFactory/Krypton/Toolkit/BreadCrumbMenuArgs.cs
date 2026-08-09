namespace ComponentFactory.Krypton.Toolkit;

public class BreadCrumbMenuArgs : ContextPositionMenuArgs
{
	private KryptonBreadCrumbItem _crumb;

	public KryptonBreadCrumbItem Crumb
	{
		get
		{
			return _crumb;
		}
		set
		{
			_crumb = value;
		}
	}

	public BreadCrumbMenuArgs(KryptonBreadCrumbItem crumb, KryptonContextMenu kcm, KryptonContextMenuPositionH positionH, KryptonContextMenuPositionV positionV)
		: base(null, kcm, positionH, positionV)
	{
		_crumb = crumb;
	}
}
