using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Graphics;

namespace devDept.Eyeshot;

public class RenderParams : DrawParams
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private MaterialKeyedCollection _0023_003DzfreQN5kwpmlTCo5IZP9xhGlo2Dd_0024;

	public HqrData hqrData = new HqrData();

	public Size TextureSize;

	public MaterialKeyedCollection materials
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzfreQN5kwpmlTCo5IZP9xhGlo2Dd_0024;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzfreQN5kwpmlTCo5IZP9xhGlo2Dd_0024 = value;
		}
	}

	public RenderParams(IViewport viewport, BlockKeyedCollection blocks, ShaderParameters shaderParams = null)
		: this((IViewportInternal)viewport, blocks, shaderParams)
	{
	}

	internal RenderParams(IViewportInternal _0023_003DzqkfbPc0_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D, ShaderParameters _0023_003Dzfhte6waclh6c = null)
		: base(_0023_003DzqkfbPc0_003D, _0023_003DzJO1FWlQ_003D, _0023_003Dzfhte6waclh6c)
	{
		IWorkspaceInternal parent = _0023_003DzqkfbPc0_003D.parent;
		materials = parent.Materials;
		_0023_003Dz4M7aapi8f26U(parent);
		hqrData = new HqrData(parent.RenderContext, parent.EnvironmentMap, parent.Rendered.EnvironmentMapping);
	}
}
