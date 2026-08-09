using System.Runtime.CompilerServices;

namespace Newtonsoft.Json.Linq;

public class JsonCloneSettings
{
	[Newtonsoft_002EJson_002ENullable(1)]
	internal static readonly JsonCloneSettings SkipCopyAnnotations = new JsonCloneSettings
	{
		CopyAnnotations = false
	};

	public bool CopyAnnotations { get; set; }

	public JsonCloneSettings()
	{
		CopyAnnotations = true;
	}
}
