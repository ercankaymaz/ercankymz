using System.ComponentModel;

namespace ComponentFactory.Krypton.Ribbon;

[ToolboxItem(false)]
[DesignerCategory("code")]
[DesignTimeVisible(false)]
public abstract class KryptonRibbonGroupContainer : KryptonRibbonGroupItem, IRibbonGroupContainer
{
	private KryptonRibbonGroup _ribbonGroup;

	[Browsable(false)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public virtual KryptonRibbonGroup RibbonGroup
	{
		get
		{
			return _ribbonGroup;
		}
		set
		{
			_ribbonGroup = value;
		}
	}

	public KryptonRibbonGroupContainer()
	{
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public virtual Component[] GetChildComponents()
	{
		return new Component[0];
	}
}
