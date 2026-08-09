using System.Diagnostics;

namespace SharpGLTF.Runtime;

[DebuggerDisplay("{Name} {Duration}s")]
public class AnimationTrackInfo
{
	public string Name { get; private set; }

	public object Extras { get; private set; }

	public float Duration { get; private set; }

	internal AnimationTrackInfo(string name, object extras, float duration)
	{
		Name = name;
		Extras = extras;
		Duration = duration;
	}
}
