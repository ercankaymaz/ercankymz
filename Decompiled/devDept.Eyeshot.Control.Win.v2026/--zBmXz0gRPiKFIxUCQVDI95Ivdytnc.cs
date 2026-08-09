using System.Diagnostics;
using System.IO;
using System.Resources;
using System.Runtime.CompilerServices;
using D3DShaders;
using SharpDX.D3DCompiler;
using SharpDX.Direct3D11;
using devDept;
using devDept.Graphics;

internal abstract class _0023_003DzBmXz0gRPiKFIxUCQVDI95Ivdytnc<_0023_003DzWoS2eJk_003D, _0023_003DzjYYAPCA_003D> : IShader, _0023_003DzHbYgUd8w8ocmwuEOm2Hppf8_003D where _0023_003DzWoS2eJk_003D : struct, _0023_003DzrMGZTYmugtUvk4_0024f3rFUC49cbnhp where _0023_003DzjYYAPCA_003D : struct, _0023_003DzxlkUGOHLNznjaogT7e4XpG7_0024jwSH
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private ResourceManager _0023_003Dz5J5lHfc_003D = new ResourceManager(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605671), typeof(MainClass).Assembly);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Buffer _0023_003Dz60LpY2nNKkEZkOOLI5NroKc_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Buffer _0023_003DzKenCyNjgO0PcbXGITWJV7ZugVwVJ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private InputLayout _0023_003Dzz3oY6QnXJFAECLm2xA_003D_003D;

	public abstract bool IsCompiled { get; }

	public _0023_003DzBmXz0gRPiKFIxUCQVDI95Ivdytnc(Device _0023_003DzJ_0024CASPE_003D)
	{
		_0023_003DzWoS2eJk_003D val = new _0023_003DzWoS2eJk_003D();
		if (val._0023_003DzL2jAKGI_003D() % 16 != 0)
		{
			throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605692));
		}
		_0023_003DzjHzrbeI4YbFEpFKb1A_003D_003D(new Buffer(_0023_003DzJ_0024CASPE_003D, val._0023_003DzL2jAKGI_003D(), ResourceUsage.Default, BindFlags.ConstantBuffer, CpuAccessFlags.None, ResourceOptionFlags.None, 0));
		_0023_003DzjYYAPCA_003D val2 = new _0023_003DzjYYAPCA_003D();
		if (val2._0023_003DzL2jAKGI_003D() % 16 != 0)
		{
			throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348605692));
		}
		_0023_003DzRCxHN2BQpQn4cIghpw_003D_003D(new Buffer(_0023_003DzJ_0024CASPE_003D, val2._0023_003DzL2jAKGI_003D(), ResourceUsage.Default, BindFlags.ConstantBuffer, CpuAccessFlags.None, ResourceOptionFlags.None, 0));
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	protected ShaderBytecode _0023_003DzX5I0kYMZ27nVKvNSAA_003D_003D(string _0023_003DzZLWXAps_003D, string _0023_003Dz74uzifI_003D)
	{
		string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(_0023_003DzZLWXAps_003D + _0023_003Dz74uzifI_003D);
		return ShaderBytecode.FromStream(new MemoryStream((byte[])_0023_003Dz5J5lHfc_003D.GetObject(fileNameWithoutExtension)));
	}

	public Buffer _0023_003DzLzovILT5Pg1SO1lXjw_003D_003D()
	{
		return _0023_003Dz60LpY2nNKkEZkOOLI5NroKc_003D;
	}

	private void _0023_003DzjHzrbeI4YbFEpFKb1A_003D_003D(Buffer _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dz60LpY2nNKkEZkOOLI5NroKc_003D = _0023_003DzsLHxXyo_003D;
	}

	public Buffer _0023_003DzbnCF7h7ukra_0024pIXzuA_003D_003D()
	{
		return _0023_003DzKenCyNjgO0PcbXGITWJV7ZugVwVJ;
	}

	private void _0023_003DzRCxHN2BQpQn4cIghpw_003D_003D(Buffer _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzKenCyNjgO0PcbXGITWJV7ZugVwVJ = _0023_003DzsLHxXyo_003D;
	}

	public void _0023_003DzBA5OJQegAhUvIN1YjA_003D_003D(DeviceContext _0023_003DzoC62DbA_003D, _0023_003DzIIjZpH_kq1FIi9sU4NDjTUmSj7Ht _0023_003DzcHHD1CU_003D)
	{
		_0023_003DzWoS2eJk_003D data = new _0023_003DzWoS2eJk_003D();
		data._0023_003DzshPEPAc_003D(_0023_003DzcHHD1CU_003D);
		_0023_003DzoC62DbA_003D.UpdateSubresource(ref data, _0023_003DzLzovILT5Pg1SO1lXjw_003D_003D());
	}

	public void _0023_003DzudrHn6AUig2kpFOdgw_003D_003D(DeviceContext _0023_003DzoC62DbA_003D, _0023_003DzgqtAaJ3PR7fqIQf4Y9MBhJQ3Betg _0023_003Dzt5jpbHs_003D)
	{
		if (_0023_003DzbnCF7h7ukra_0024pIXzuA_003D_003D() != null)
		{
			_0023_003DzjYYAPCA_003D data = new _0023_003DzjYYAPCA_003D();
			data._0023_003DzshPEPAc_003D(_0023_003Dzt5jpbHs_003D);
			_0023_003DzoC62DbA_003D.UpdateSubresource(ref data, _0023_003DzbnCF7h7ukra_0024pIXzuA_003D_003D());
		}
	}

	public virtual void _0023_003DzY5NLG7xn1HVsQF5W_0024w_003D_003D(DeviceContext _0023_003DzoC62DbA_003D, bool _0023_003DzWtFDQr8_003D)
	{
	}

	public virtual void Dispose()
	{
		if (_0023_003DzLzovILT5Pg1SO1lXjw_003D_003D() != null)
		{
			_0023_003DzLzovILT5Pg1SO1lXjw_003D_003D().Dispose();
			_0023_003DzjHzrbeI4YbFEpFKb1A_003D_003D(null);
		}
		if (_0023_003DzbnCF7h7ukra_0024pIXzuA_003D_003D() != null)
		{
			_0023_003DzbnCF7h7ukra_0024pIXzuA_003D_003D().Dispose();
			_0023_003DzRCxHN2BQpQn4cIghpw_003D_003D(null);
		}
	}

	public abstract bool Compile(RenderContextBase _0023_003DzmNZD0Zs_003D);

	public void SetParameters(object _0023_003DzgcK4Z11iT1YA)
	{
	}

	public void SetEnvironmentIntensity(float _0023_003DzHw7Dl0k_003D)
	{
	}

	public void Disable(RenderContextBase _0023_003DzoC62DbA_003D)
	{
	}

	public void SetParametersForShadow(object _0023_003DzgcK4Z11iT1YA)
	{
	}

	[SpecialName]
	[CompilerGenerated]
	public InputLayout _0023_003Dzqa6FU0IQlA38()
	{
		return _0023_003Dzz3oY6QnXJFAECLm2xA_003D_003D;
	}

	public abstract void _0023_003DzCCBca0k_003D(DeviceContext _0023_003DzoC62DbA_003D, bool _0023_003DzSSU_OrNwA8uS);

	public void Validate()
	{
	}
}
