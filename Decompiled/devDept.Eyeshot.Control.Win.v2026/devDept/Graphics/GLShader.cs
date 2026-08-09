using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using OpenGL;

namespace devDept.Graphics;

public abstract class GLShader : IShader
{
	protected internal string vertexCode;

	protected internal string fragmentCode;

	protected internal string geometryCode;

	[CLSCompliant(false)]
	protected uint programObj;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzQVsx1WI_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dzz6IVLLaEGg1CTuN8rj_seLg_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003Dz2WEszK_0024uPdjGuRGIzQ_003D_003D = -1;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzJmJcceb3Jx1zTAeXcu67ovk_003D = -1;

	protected float lastEnvironmentIntensity = -1f;

	public bool Enabled => _0023_003DzQVsx1WI_003D;

	public bool IsCompiled => programObj != 0;

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

	public GLShader()
	{
	}

	protected GLShader(string vertexCode, string fragmentCode)
		: this()
	{
		this.vertexCode = vertexCode;
		this.fragmentCode = fragmentCode;
	}

	public bool Compile(RenderContextBase renderContext)
	{
		Dispose();
		uint num = uint.MaxValue;
		uint num2 = _0023_003Dz8WTvZ9I_003D(35633, vertexCode);
		uint num3 = _0023_003Dz8WTvZ9I_003D(35632, fragmentCode);
		programObj = 0u;
		programObj = gl.CreateProgram();
		bool flag = _0023_003Dz4S6W5cBJdy_u(vertexCode, num2);
		flag &= _0023_003Dz4S6W5cBJdy_u(fragmentCode, num3);
		if (!string.IsNullOrEmpty(geometryCode))
		{
			num = _0023_003Dz8WTvZ9I_003D(36313, geometryCode);
			flag &= _0023_003Dz4S6W5cBJdy_u(geometryCode, num);
		}
		gl.LinkProgram(programObj);
		int parameters = 0;
		gl.GetProgramiv(programObj, 35714, ref parameters);
		gl.DeleteShader(num2);
		gl.DeleteShader(num3);
		if (num != uint.MaxValue)
		{
			gl.DeleteShader(num);
		}
		if (parameters != 1 || !flag)
		{
			_0023_003DzXCYgWZJbF8B9();
			int parameters2 = 0;
			gl.GetProgramiv(programObj, 35718, ref parameters2);
			int integerv = gl.GetIntegerv(35658);
			int integerv2 = gl.GetIntegerv(35657);
			int integerv3 = gl.GetIntegerv(36319);
			RenderContextBase.GraphicalIssues.AppendLine(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603347));
			RenderContextBase.GraphicalIssues.AppendLine(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603360) + parameters2 + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603136) + integerv + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603193) + integerv2 + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348603216) + integerv3);
			int integerv4 = gl.GetIntegerv(34930);
			int integerv5 = gl.GetIntegerv(35660);
			RenderContextBase.GraphicalIssues.AppendLine(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602503) + integerv4 + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602536) + integerv5);
			int integerv6 = gl.GetIntegerv(35659);
			RenderContextBase.GraphicalIssues.AppendLine(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602560) + integerv6);
			RenderContextBase.GraphicalIssues.AppendLine(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602598) + gl.GetString(35724));
			Dispose();
			return false;
		}
		return true;
	}

	private bool _0023_003Dz4S6W5cBJdy_u(string _0023_003DzGLZ7VmE_003D, uint _0023_003DzqP_0024Pj_0_003D)
	{
		bool result = true;
		if (!string.IsNullOrEmpty(_0023_003DzGLZ7VmE_003D))
		{
			if (_0023_003DzqP_0024Pj_0_003D != 0)
			{
				gl.AttachShader(programObj, _0023_003DzqP_0024Pj_0_003D);
			}
			else
			{
				result = false;
			}
		}
		return result;
	}

	public void Validate()
	{
		gl.ValidateProgramARB(programObj);
		int parameters = 1;
		gl.GetProgramiv(programObj, 35715, ref parameters);
		if (parameters == 0)
		{
			_0023_003DzXCYgWZJbF8B9();
		}
	}

	private uint _0023_003Dz8WTvZ9I_003D(int _0023_003DzhklmJFQ_003D, string _0023_003DzGLZ7VmE_003D)
	{
		if (_0023_003DzGLZ7VmE_003D == null)
		{
			return 0u;
		}
		uint num = gl.CreateShader(_0023_003DzhklmJFQ_003D);
		gl.ShaderSource(num, 1, new string[1] { _0023_003DzGLZ7VmE_003D }, null);
		gl.CompileShader(num);
		int parameters = 0;
		gl.GetShaderiv(num, 35713, ref parameters);
		if (parameters != 1)
		{
			_0023_003DzJEt4tCHDinZp(num, _0023_003DzGLZ7VmE_003D);
			return 0u;
		}
		return num;
	}

	private void _0023_003DzXCYgWZJbF8B9()
	{
		int parameters = 0;
		int length = 0;
		gl.GetProgramiv(programObj, 35716, ref parameters);
		if (parameters > 0)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(parameters);
			gl.GetProgramInfoLog(programObj, parameters, ref length, intPtr);
			string value = Marshal.PtrToStringAnsi(intPtr);
			Marshal.FreeHGlobal(intPtr);
			RenderContextBase.GraphicalIssues.Append(value);
		}
	}

	private void _0023_003DzJEt4tCHDinZp(uint _0023_003DzqP_0024Pj_0_003D, string _0023_003DzGLZ7VmE_003D)
	{
		int parameters = 0;
		int length = 0;
		gl.GetShaderiv(_0023_003DzqP_0024Pj_0_003D, 35716, ref parameters);
		if (parameters > 0)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(parameters);
			gl.GetShaderInfoLog(_0023_003DzqP_0024Pj_0_003D, parameters, ref length, intPtr);
			string value = Marshal.PtrToStringAnsi(intPtr);
			Marshal.FreeHGlobal(intPtr);
			RenderContextBase.GraphicalIssues.Append(value);
		}
	}

	public void Dispose()
	{
		if (programObj != 0)
		{
			gl.DeleteProgram(programObj);
			programObj = 0u;
		}
		_0023_003Dz2WEszK_0024uPdjGuRGIzQ_003D_003D = -1;
		_0023_003DzJmJcceb3Jx1zTAeXcu67ovk_003D = -1;
	}

	internal static void _0023_003DzUgMk_IApQLO4(uint _0023_003DzyZJOjtp28niH)
	{
		gl.UseProgram(_0023_003DzyZJOjtp28niH);
	}

	public virtual bool Enable(RenderContextBase renderContext)
	{
		_0023_003DzQVsx1WI_003D = true;
		_0023_003DzUgMk_IApQLO4(programObj);
		return true;
	}

	public virtual void Disable(RenderContextBase context)
	{
		_0023_003DzQVsx1WI_003D = false;
	}

	public int GetAttribLocation(string name)
	{
		return GetAttribLocation(programObj, name);
	}

	[CLSCompliant(false)]
	public static int GetAttribLocation(uint shaderProgram, string name)
	{
		return gl.GetAttribLocationARB(shaderProgram, name);
	}

	public int GetUniformLocation(string uniformName)
	{
		return GetUniformLocation(programObj, uniformName);
	}

	[CLSCompliant(false)]
	public static int GetUniformLocation(uint shaderProgram, string uniformName)
	{
		return gl.GetUniformLocation(shaderProgram, uniformName);
	}

	public abstract void SetParameters(object shaderParams);

	public virtual void SetParametersForShadow(object shaderParams)
	{
	}

	internal virtual bool _0023_003DzT5lT1YFdRDAvUzE2Bg_003D_003D()
	{
		return false;
	}

	public void SetBlockRefTransform(float[] blockRefMatrix)
	{
		if (_0023_003Dz2WEszK_0024uPdjGuRGIzQ_003D_003D >= 0 && blockRefMatrix != null)
		{
			gl.UniformMatrix4fvARB(_0023_003Dz2WEszK_0024uPdjGuRGIzQ_003D_003D, 1, transpose: false, blockRefMatrix);
		}
	}

	public virtual void SetEnvironmentIntensity(float intensity)
	{
	}

	internal void _0023_003DzHC_00247E8Iff85gVpS2Sg_003D_003D()
	{
		if (_0023_003Dz2WEszK_0024uPdjGuRGIzQ_003D_003D == -1)
		{
			_0023_003Dz2WEszK_0024uPdjGuRGIzQ_003D_003D = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602374));
		}
	}

	internal void _0023_003DzzbfSoE7FWZwd8nNyL5G3f5U_003D()
	{
		if (_0023_003DzJmJcceb3Jx1zTAeXcu67ovk_003D == -1)
		{
			_0023_003DzJmJcceb3Jx1zTAeXcu67ovk_003D = GetUniformLocation(programObj, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348602385));
		}
	}
}
