using System.Diagnostics;
using System.Runtime.CompilerServices;
using devDept.Graphics;

internal sealed class _0023_003DzFzcMdiXh0E2oBkC6o7lJH9t6kgLOf8_00246pw_003D_003D : IShaderTechnique, IShader
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IShader _0023_003Dz_qfVKVEldUHmZbh4aQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private IShader _0023_003DzOsCIt2zRI6D9T6_e9I7SCos_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzz6IVLLaEGg1CTuN8rj_seLg_003D;

	public IShader Shader
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_qfVKVEldUHmZbh4aQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_qfVKVEldUHmZbh4aQ_003D_003D = value;
		}
	}

	public IShader GeometryShader
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzOsCIt2zRI6D9T6_e9I7SCos_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzOsCIt2zRI6D9T6_e9I7SCos_003D = value;
		}
	}

	public bool UpdatedInFrame
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dzz6IVLLaEGg1CTuN8rj_seLg_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dzz6IVLLaEGg1CTuN8rj_seLg_003D = value;
		}
	}

	public bool IsCompiled => Shader.IsCompiled;

	public void Dispose()
	{
		Shader.Dispose();
		if (GeometryShader != null)
		{
			GeometryShader.Dispose();
		}
	}

	public bool Compile(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		return Shader.Compile(_0023_003DzmNZD0Zs_003D);
	}

	public void SetParameters(object _0023_003DzgcK4Z11iT1YA)
	{
		Shader.SetParameters(_0023_003DzgcK4Z11iT1YA);
	}

	public void SetEnvironmentIntensity(float _0023_003DzHw7Dl0k_003D)
	{
		Shader.SetEnvironmentIntensity(_0023_003DzHw7Dl0k_003D);
	}

	public void Validate()
	{
		Shader.Validate();
	}

	public void Disable(RenderContextBase _0023_003DzoC62DbA_003D)
	{
		Shader.Disable(_0023_003DzoC62DbA_003D);
	}

	public void SetParametersForShadow(object _0023_003DzgcK4Z11iT1YA)
	{
		Shader.SetParametersForShadow(_0023_003DzgcK4Z11iT1YA);
	}
}
