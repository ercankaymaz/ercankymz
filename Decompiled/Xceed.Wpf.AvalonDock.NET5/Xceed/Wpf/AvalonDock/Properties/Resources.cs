using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Xceed.Wpf.AvalonDock.Properties;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
public class Resources
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("Xceed.Wpf.AvalonDock.Properties.Resources", typeof(Resources).Assembly);
			}
			return resourceMan;
		}
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public static CultureInfo Culture
	{
		get
		{
			return resourceCulture;
		}
		set
		{
			resourceCulture = value;
		}
	}

	public static string Anchorable_AutoHide => ResourceManager.GetString("Anchorable_AutoHide", resourceCulture);

	public static string Anchorable_BtnAutoHide_Hint => ResourceManager.GetString("Anchorable_BtnAutoHide_Hint", resourceCulture);

	public static string Anchorable_BtnClose_Hint => ResourceManager.GetString("Anchorable_BtnClose_Hint", resourceCulture);

	public static string Anchorable_CxMenu_Hint => ResourceManager.GetString("Anchorable_CxMenu_Hint", resourceCulture);

	public static string Anchorable_Dock => ResourceManager.GetString("Anchorable_Dock", resourceCulture);

	public static string Anchorable_DockAsDocument => ResourceManager.GetString("Anchorable_DockAsDocument", resourceCulture);

	public static string Anchorable_Float => ResourceManager.GetString("Anchorable_Float", resourceCulture);

	public static string Anchorable_Hide => ResourceManager.GetString("Anchorable_Hide", resourceCulture);

	public static string Document_BtnPinned_Hint => ResourceManager.GetString("Document_BtnPinned_Hint", resourceCulture);

	public static string Document_Close => ResourceManager.GetString("Document_Close", resourceCulture);

	public static string Document_CloseAll => ResourceManager.GetString("Document_CloseAll", resourceCulture);

	public static string Document_CloseAllButThis => ResourceManager.GetString("Document_CloseAllButThis", resourceCulture);

	public static string Document_CxMenu_Hint => ResourceManager.GetString("Document_CxMenu_Hint", resourceCulture);

	public static string Document_DockAsDocument => ResourceManager.GetString("Document_DockAsDocument", resourceCulture);

	public static string Document_Float => ResourceManager.GetString("Document_Float", resourceCulture);

	public static string Document_MoveToNextTabGroup => ResourceManager.GetString("Document_MoveToNextTabGroup", resourceCulture);

	public static string Document_MoveToPreviousTabGroup => ResourceManager.GetString("Document_MoveToPreviousTabGroup", resourceCulture);

	public static string Document_NewHorizontalTabGroup => ResourceManager.GetString("Document_NewHorizontalTabGroup", resourceCulture);

	public static string Document_NewVerticalTabGroup => ResourceManager.GetString("Document_NewVerticalTabGroup", resourceCulture);

	public static string Window_Maximize => ResourceManager.GetString("Window_Maximize", resourceCulture);

	public static string Window_Restore => ResourceManager.GetString("Window_Restore", resourceCulture);

	internal Resources()
	{
	}
}
