using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace buImages;

[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
[DebuggerNonUserCode]
[CompilerGenerated]
public class ResourceIcon
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
				ResourceManager resourceManager = new ResourceManager("buImages.ResourceIcon", typeof(ResourceIcon).Assembly);
				resourceMan = resourceManager;
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

	public static Icon CamContourCenter2
	{
		get
		{
			object obj = ResourceManager.GetObject("CamContourCenter2", resourceCulture);
			return (Icon)obj;
		}
	}

	public static Icon CamContourOpenCenter2
	{
		get
		{
			object obj = ResourceManager.GetObject("CamContourOpenCenter2", resourceCulture);
			return (Icon)obj;
		}
	}

	internal ResourceIcon()
	{
	}
}
