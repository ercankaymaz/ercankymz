using System.Collections.Generic;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal class VisibilityInfo : InstanceInfo
{
	internal bool Visible = true;

	public VisibilityInfo()
	{
	}

	public VisibilityInfo(Stack<BlockReference> parents)
		: base(parents)
	{
	}
}
