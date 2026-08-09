using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;
using ns27;

namespace buControls.Controls;

public class buThemeControl : Component
{
	private ThemeType themeType_0 = ThemeType.Standart;

	private bool bool_0 = false;

	private ContainerControl containerControl_0 = null;

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue(false)]
	[NotifyParentProperty(true)]
	[Browsable(true)]
	public bool Enable
	{
		get
		{
			return bool_0;
		}
		set
		{
			bool_0 = value;
		}
	}

	[DefaultValue(ThemeType.Standart)]
	[Browsable(true)]
	public ThemeType Theme
	{
		get
		{
			return themeType_0;
		}
		set
		{
			themeType_0 = value;
			Class76.smethod_164(ContainerControl.Controls, this);
		}
	}

	public ContainerControl ContainerControl
	{
		get
		{
			return containerControl_0;
		}
		set
		{
			containerControl_0 = value;
			Class76.smethod_164(ContainerControl.Controls, this);
		}
	}

	public override ISite Site
	{
		get
		{
			return base.Site;
		}
		set
		{
			base.Site = value;
			if (value != null && value.GetService(typeof(IDesignerHost)) is IDesignerHost { RootComponent: var rootComponent } && rootComponent is ContainerControl)
			{
				ContainerControl = rootComponent as ContainerControl;
			}
		}
	}
}
