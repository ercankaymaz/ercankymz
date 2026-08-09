using System.Diagnostics;
using System.Runtime.CompilerServices;
using SharpDX.Direct3D11;
using devDept.Graphics;

internal sealed class _0023_003Dzjq2Cc9Eot5Pduw2fxRZDNLy6_0024w5UsoI95LFbZ9Q_003D : IShaderTechnique, IShader
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

	public bool IsCompiled
	{
		get
		{
			bool isCompiled = Shader.IsCompiled;
			if (GeometryShader != null)
			{
				if (isCompiled)
				{
					return GeometryShader.IsCompiled;
				}
				return false;
			}
			return isCompiled;
		}
	}

	public void _0023_003DzCCBca0k_003D(DeviceContext _0023_003DzoC62DbA_003D, bool _0023_003DzSSU_OrNwA8uS)
	{
		((_0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D)Shader)._0023_003DzCCBca0k_003D(_0023_003DzoC62DbA_003D, _0023_003DzSSU_OrNwA8uS);
		if (GeometryShader == null)
		{
			_0023_003DzoC62DbA_003D.GeometryShader.Set(null);
		}
		else
		{
			((_0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D)GeometryShader)._0023_003DzCCBca0k_003D(_0023_003DzoC62DbA_003D, _0023_003DzSSU_OrNwA8uS);
		}
	}

	public void Dispose()
	{
		Shader.Dispose();
		if (GeometryShader != null)
		{
			GeometryShader.Dispose();
		}
	}

	public void _0023_003DzBA5OJQegAhUvIN1YjA_003D_003D(DeviceContext _0023_003DzoC62DbA_003D, _0023_003DzIIjZpH_kq1FIi9sU4NDjTUmSj7Ht _0023_003Dzt5jpbHs_003D)
	{
		((_0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D)Shader)._0023_003DzBA5OJQegAhUvIN1YjA_003D_003D(_0023_003DzoC62DbA_003D, _0023_003Dzt5jpbHs_003D);
		if (GeometryShader != null)
		{
			((_0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D)GeometryShader)._0023_003DzBA5OJQegAhUvIN1YjA_003D_003D(_0023_003DzoC62DbA_003D, _0023_003Dzt5jpbHs_003D);
		}
	}

	public void _0023_003DzudrHn6AUig2kpFOdgw_003D_003D(DeviceContext _0023_003DzoC62DbA_003D, _0023_003DzgqtAaJ3PR7fqIQf4Y9MBhJQ3Betg _0023_003Dzt5jpbHs_003D)
	{
		((_0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D)Shader)._0023_003DzudrHn6AUig2kpFOdgw_003D_003D(_0023_003DzoC62DbA_003D, _0023_003Dzt5jpbHs_003D);
		if (GeometryShader != null)
		{
			((_0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D)GeometryShader)._0023_003DzudrHn6AUig2kpFOdgw_003D_003D(_0023_003DzoC62DbA_003D, _0023_003Dzt5jpbHs_003D);
		}
		UpdatedInFrame = true;
	}

	public bool Compile(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		if (Shader != null && !Shader.IsCompiled)
		{
			Shader.Compile(_0023_003DzmNZD0Zs_003D);
		}
		if (GeometryShader != null && !GeometryShader.IsCompiled)
		{
			GeometryShader.Compile(_0023_003DzmNZD0Zs_003D);
		}
		return true;
	}

	public void SetParameters(object _0023_003DzgcK4Z11iT1YA)
	{
	}

	public void SetEnvironmentIntensity(float _0023_003DzHw7Dl0k_003D)
	{
	}

	public void Validate()
	{
	}

	public void Disable(RenderContextBase _0023_003DzoC62DbA_003D)
	{
	}

	public void SetParametersForShadow(object _0023_003DzgcK4Z11iT1YA)
	{
	}

	public void _0023_003DzgOc25ejirOw4eWjVEG3qu2A_003D(EntityGraphicsData _0023_003DzqOwbKcs_003D)
	{
	}

	public void _0023_003Dzf8zGa0dVYhH8OaN7O4PtgQk_003D(EntityGraphicsData _0023_003DzqOwbKcs_003D)
	{
	}
}
