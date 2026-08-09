using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Graphics;

namespace devDept.Eyeshot;

public class DrawForSelectionParams(IViewport viewport, BlockKeyedCollection blocks, ShaderParameters shaderParams = null) : DrawParams(viewport, blocks, shaderParams)
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzCMjX_0024Hg3o5qDSqtGU7p_9G0_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz3GUjd8j_0024WaswZCiw65hIcDg_003D;

	public Dictionary<int, SelectedItem> IdItemsMap = new Dictionary<int, SelectedItem>();

	public int FalseColorIndex;

	public bool UiElementSelection;

	public bool LeafSelection
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzCMjX_0024Hg3o5qDSqtGU7p_9G0_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzCMjX_0024Hg3o5qDSqtGU7p_9G0_003D = value;
		}
	}

	public bool InternalSelection
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz3GUjd8j_0024WaswZCiw65hIcDg_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz3GUjd8j_0024WaswZCiw65hIcDg_003D = value;
		}
	}
}
