using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using OpenGL;
using SharpDX;
using devDept.Diagnostic;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Graphics;

public class OglRenderContext(Size size, ControlData data, IWorkspace parentWorkspace) : RenderContext(size, data, parentWorkspace)
{
	internal abstract class _0023_003Dz4sTCQ2BYF7HT : _0023_003DzBeQqwZcYe4PHbbJBGg_003D_003D
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			base.SetParameters(_0023_003DzgcK4Z11iT1YA);
		}
	}

	internal sealed class _0023_003Dz7IX_0024OXXIcOkxv4DlCg_003D_003D : GLShader
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			if (_0023_003DzgcK4Z11iT1YA is _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2)
			{
				gl.UniformMatrix4fvARB(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610111)), 1, transpose: false, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2.WorldViewProj);
			}
			else if (_0023_003DzgcK4Z11iT1YA is ShaderParameters)
			{
				ShaderParameters shaderParameters = (ShaderParameters)_0023_003DzgcK4Z11iT1YA;
				Enable(shaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610496));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610516));
				int uniformLocation3 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610536));
				gl.Uniform1i(uniformLocation, 0);
				gl.Uniform1i(uniformLocation2, 1);
				gl.Uniform1i(uniformLocation3, shaderParameters.AlphaClip ? 1 : 0);
				Disable(shaderParameters.RenderContext);
			}
		}
	}

	internal sealed class _0023_003Dz917i1jTGR9yYZWtVlEN_002425m_NmnS : _0023_003Dz4sTCQ2BYF7HT
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			base.SetParameters(_0023_003DzgcK4Z11iT1YA);
			if (_0023_003DzgcK4Z11iT1YA is AoShaderParameters aoShaderParameters)
			{
				Enable(aoShaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608880));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610221));
				int uniformLocation3 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610246));
				int uniformLocation4 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610257));
				bool flag = aoShaderParameters.Projection[15] == 0f;
				gl.Uniform1i(uniformLocation, 0);
				gl.UniformMatrix4fvARB(uniformLocation2, 1, transpose: false, aoShaderParameters.Projection);
				gl.Uniform2f(uniformLocation3, 1f / aoShaderParameters.Projection[0], 1f / aoShaderParameters.Projection[5]);
				gl.Uniform2f(uniformLocation4, aoShaderParameters.Projection[flag ? 8 : 12] / aoShaderParameters.Projection[0], aoShaderParameters.Projection[flag ? 9 : 13] / aoShaderParameters.Projection[5]);
				Disable(aoShaderParameters.RenderContext);
			}
		}
	}

	internal sealed class _0023_003Dz9aoDYiaKYNaP744r_g_003D_003D : _0023_003Dz4sTCQ2BYF7HT
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			base.SetParameters(_0023_003DzgcK4Z11iT1YA);
			if (_0023_003DzgcK4Z11iT1YA is AoShaderParameters aoShaderParameters)
			{
				Enable(aoShaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608880));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610177));
				int uniformLocation3 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610221));
				int uniformLocation4 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610235));
				int uniformLocation5 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610246));
				int uniformLocation6 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610257));
				int uniformLocation7 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610301));
				int uniformLocation8 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608844));
				bool flag = aoShaderParameters.Projection[15] == 0f;
				gl.Uniform1i(uniformLocation, 0);
				gl.Uniform1i(uniformLocation2, 1);
				gl.UniformMatrix4fvARB(uniformLocation3, 1, transpose: false, aoShaderParameters.Projection);
				gl.UniformMatrix4fvARB(uniformLocation4, 1, transpose: false, aoShaderParameters.ProjectionInv);
				gl.Uniform2f(uniformLocation5, 1f / aoShaderParameters.Projection[0], 1f / aoShaderParameters.Projection[5]);
				gl.Uniform2f(uniformLocation6, aoShaderParameters.Projection[flag ? 8 : 12] / aoShaderParameters.Projection[0], aoShaderParameters.Projection[flag ? 9 : 13] / aoShaderParameters.Projection[5]);
				gl.Uniform2f(uniformLocation7, (float)aoShaderParameters.NearFar.X, (float)aoShaderParameters.NearFar.Y);
				gl.Uniform1f(uniformLocation8, aoShaderParameters.Radius);
				Disable(aoShaderParameters.RenderContext);
			}
		}
	}

	private enum _0023_003DzAtjnbS4_003D
	{

	}

	internal abstract class _0023_003DzBeQqwZcYe4PHbbJBGg_003D_003D : GLShader
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			if (!(_0023_003DzgcK4Z11iT1YA is PostProcessingShaderParameters postProcessingShaderParameters))
			{
				if (_0023_003DzgcK4Z11iT1YA is _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2)
				{
					gl.UniformMatrix4fvARB(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610111)), 1, transpose: false, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2.WorldViewProj);
				}
				return;
			}
			Enable(postProcessingShaderParameters.RenderContext);
			int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610552));
			gl.Uniform4fv(uniformLocation, 1, new float[4]
			{
				postProcessingShaderParameters.ViewFrame[0],
				postProcessingShaderParameters.ViewFrame[1],
				postProcessingShaderParameters.ViewFrame[2],
				postProcessingShaderParameters.ViewFrame[3]
			});
			Disable(postProcessingShaderParameters.RenderContext);
		}
	}

	internal sealed class _0023_003DzLYHQZgM8p_00246uR_lAHQ_003D_003D : _0023_003Dz4sTCQ2BYF7HT
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			base.SetParameters(_0023_003DzgcK4Z11iT1YA);
			if (_0023_003DzgcK4Z11iT1YA is AoShaderParameters aoShaderParameters)
			{
				Enable(aoShaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610062));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610079));
				int uniformLocation3 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610221));
				int uniformLocation4 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610065));
				int uniformLocation5 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610301));
				gl.Uniform1i(uniformLocation, 0);
				gl.Uniform1i(uniformLocation2, 1);
				gl.UniformMatrix4fvARB(uniformLocation3, 1, transpose: false, aoShaderParameters.Projection);
				gl.Uniform2f(uniformLocation4, (float)aoShaderParameters.DepthRange.X, (float)aoShaderParameters.DepthRange.Y);
				gl.Uniform2f(uniformLocation5, (float)aoShaderParameters.NearFar.X, (float)aoShaderParameters.NearFar.Y);
				Disable(aoShaderParameters.RenderContext);
			}
		}
	}

	internal sealed class _0023_003DzLpQwlGSo8zVN : GLShader
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			if (_0023_003DzgcK4Z11iT1YA is _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2)
			{
				gl.UniformMatrix4fvARB(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610111)), 1, transpose: false, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2.WorldViewProj);
			}
			else if (_0023_003DzgcK4Z11iT1YA is OutlineShaderParameters)
			{
				OutlineShaderParameters outlineShaderParameters = (OutlineShaderParameters)_0023_003DzgcK4Z11iT1YA;
				Enable(outlineShaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610407));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610420));
				int uniformLocation3 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609694));
				int uniformLocation4 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609709));
				int uniformLocation5 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609726));
				int uniformLocation6 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609737));
				int uniformLocation7 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609749));
				int uniformLocation8 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609789));
				int uniformLocation9 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609544));
				gl.Uniform2f(uniformLocation, (float)outlineShaderParameters.ViewportSize.X, (float)outlineShaderParameters.ViewportSize.Y);
				gl.Uniform2f(uniformLocation2, (float)outlineShaderParameters.ViewportSizeInv.X, (float)outlineShaderParameters.ViewportSizeInv.Y);
				gl.Uniform4f(uniformLocation3, (float)(int)outlineShaderParameters.StartColor.R / 255f, (float)(int)outlineShaderParameters.StartColor.G / 255f, (float)(int)outlineShaderParameters.StartColor.B / 255f, (float)(int)outlineShaderParameters.StartColor.A / 255f);
				gl.Uniform4f(uniformLocation4, (float)(int)outlineShaderParameters.EndColor.R / 255f, (float)(int)outlineShaderParameters.EndColor.G / 255f, (float)(int)outlineShaderParameters.EndColor.B / 255f, (float)(int)outlineShaderParameters.EndColor.A / 255f);
				gl.Uniform4f(uniformLocation5, (float)(int)outlineShaderParameters.FillColorFront.R / 255f, (float)(int)outlineShaderParameters.FillColorFront.G / 255f, (float)(int)outlineShaderParameters.FillColorFront.B / 255f, (float)(int)outlineShaderParameters.FillColorFront.A / 255f);
				gl.Uniform4f(uniformLocation6, (float)(int)outlineShaderParameters.FillColorBack.R / 255f, (float)(int)outlineShaderParameters.FillColorBack.G / 255f, (float)(int)outlineShaderParameters.FillColorBack.B / 255f, (float)(int)outlineShaderParameters.FillColorBack.A / 255f);
				gl.Uniform1i(uniformLocation7, outlineShaderParameters.ThicknessPolygons);
				gl.Uniform1i(uniformLocation8, outlineShaderParameters.ThicknessWires);
				gl.Uniform1i(uniformLocation9, 0);
				Disable(outlineShaderParameters.RenderContext);
			}
		}
	}

	[Serializable]
	private sealed class _0023_003DzP0sFNwY_003D
	{
		public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

		public static Func<_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D, bool> _0023_003Dz_0024vLlS6Xj58WYLYVktg_003D_003D;

		public static DrawEntityCallBack _0023_003DzB5bIkwWpmwQbZ1JcOA_003D_003D;

		internal bool _0023_003DzErPbLR3vwMDV3ROOumX7najmZXhcX_0024hhag_003D_003D(_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D _0023_003DzGMK4xyk_003D)
		{
			return _0023_003DzGMK4xyk_003D._0023_003DzbiPzcTk_003D == 1f;
		}

		internal void _0023_003DzPUoCIsDGVJN4zk0OSrY4KAxORrKeSN48c5FPivg_003D(RenderContextBase _0023_003DzD6Th82s_003D, object _0023_003DzCBM7XJK4_5H_0024)
		{
			_0023_003DzD6Th82s_003D.DrawIndexedTriangles((VBOParams)_0023_003DzCBM7XJK4_5H_0024);
		}
	}

	internal sealed class _0023_003DzT8CQzfXbBhZ3 : GLShader
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			if (_0023_003DzgcK4Z11iT1YA is ShaderParameters)
			{
				if (_0023_003DzgcK4Z11iT1YA is _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2)
				{
					gl.UniformMatrix4fvARB(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610111)), 1, transpose: false, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2.WorldViewProj);
					return;
				}
				ShaderParameters shaderParameters = (ShaderParameters)_0023_003DzgcK4Z11iT1YA;
				Enable(shaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610101));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610142));
				int uniformLocation3 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610151));
				int uniformLocation4 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610160));
				int uniformLocation5 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610457));
				gl.Uniform1i(uniformLocation, 0);
				gl.Uniform1i(uniformLocation2, 1);
				gl.Uniform1i(uniformLocation3, 2);
				gl.Uniform1i(uniformLocation4, 3);
				gl.Uniform1i(uniformLocation5, 4);
				Disable(shaderParameters.RenderContext);
			}
		}
	}

	private struct _0023_003DzVnoEAB7jWopr(int _0023_003DzOHZCD9EcR_Y_0024, int _0023_003DzCH_EN__bg2BX, string _0023_003Dz6s8ssWI_003D)
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzOHZCD9EcR_Y_0024 = _0023_003DzOHZCD9EcR_Y_0024;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzCH_EN__bg2BX = _0023_003DzCH_EN__bg2BX;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public string _0023_003Dz6s8ssWI_003D = _0023_003Dz6s8ssWI_003D;
	}

	internal sealed class _0023_003DzWEuOne_RGMegw6Q5bA_003D_003D : _0023_003DzBeQqwZcYe4PHbbJBGg_003D_003D
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			base.SetParameters(_0023_003DzgcK4Z11iT1YA);
			if (_0023_003DzgcK4Z11iT1YA is ShaderParametersBase shaderParametersBase)
			{
				Enable(shaderParametersBase.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609562));
				gl.Uniform1i(uniformLocation, 0);
				Disable(shaderParametersBase.RenderContext);
			}
		}
	}

	internal sealed class _0023_003DzWIagwyUsQtp0goFJegPhXEE_003D : _0023_003DzBeQqwZcYe4PHbbJBGg_003D_003D
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			base.SetParameters(_0023_003DzgcK4Z11iT1YA);
			if (_0023_003DzgcK4Z11iT1YA is SilhoShaderParameters silhoShaderParameters)
			{
				Enable(silhoShaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610312));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610065));
				gl.Uniform1i(uniformLocation, 0);
				gl.Uniform2f(uniformLocation2, (float)silhoShaderParameters.DepthRange.X, (float)silhoShaderParameters.DepthRange.Y);
				Disable(silhoShaderParameters.RenderContext);
			}
		}
	}

	internal sealed class _0023_003DzWx01gF2NSaJj : _0023_003DzBeQqwZcYe4PHbbJBGg_003D_003D
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			base.SetParameters(_0023_003DzgcK4Z11iT1YA);
			if (_0023_003DzgcK4Z11iT1YA is SilhoShaderParameters silhoShaderParameters)
			{
				Enable(silhoShaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610062));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610065));
				gl.Uniform1i(uniformLocation, 0);
				gl.Uniform2f(uniformLocation2, (float)silhoShaderParameters.DepthRange.X, (float)silhoShaderParameters.DepthRange.Y);
				Disable(silhoShaderParameters.RenderContext);
			}
		}
	}

	internal delegate bool _0023_003Dzby66m9UgwDKne1jXmA_003D_003D(IntPtr _0023_003Dz1Ms_o10_003D, int[] _0023_003Dza6KgwEt_00247Dbg, float[] _0023_003Dzmo3JSaWExAOi, uint _0023_003Dzqa3O4pi_xdSM, out int _0023_003DzRYyuN63nscjj, out uint _0023_003DzN8CG41Zh9hjX);

	private sealed class _0023_003DzcaoARosWGMzewm3T6w_003D_003D
	{
		[Serializable]
		private sealed class _0023_003DzP0sFNwY_003D
		{
			public static readonly _0023_003DzP0sFNwY_003D _0023_003Dz84eeg84_003D = new _0023_003DzP0sFNwY_003D();

			internal int _0023_003DzzbiUNhyvtWXI5z5_0024urdRfPE_003D(shaderType _0023_003Dz8GBMuoM_003D)
			{
				return (int)_0023_003Dz8GBMuoM_003D;
			}
		}

		private static readonly int _0023_003DzjrYgyQTQ_0024eFX;

		private OglRenderContext _0023_003DzMA4fqOpJrKds;

		private int _0023_003DzO9YCj5O_0024YYXX;

		private Dictionary<GLShader, int> _0023_003DzEbfoZ8c_003D;

		static _0023_003DzcaoARosWGMzewm3T6w_003D_003D()
		{
			_0023_003DzjrYgyQTQ_0024eFX = ((shaderType[])Enum.GetValues(typeof(shaderType))).Max((shaderType _0023_003Dz8GBMuoM_003D) => (int)_0023_003Dz8GBMuoM_003D);
		}

		public _0023_003DzcaoARosWGMzewm3T6w_003D_003D(OglRenderContext _0023_003DzmNZD0Zs_003D)
		{
			_0023_003DzMA4fqOpJrKds = _0023_003DzmNZD0Zs_003D;
			_0023_003DzO9YCj5O_0024YYXX = _0023_003DzjrYgyQTQ_0024eFX;
			_0023_003DzEbfoZ8c_003D = new Dictionary<GLShader, int>();
		}

		public int _0023_003DzQvFgXE6Nfls0(GLShader _0023_003DzqP_0024Pj_0_003D)
		{
			if (_0023_003DzqP_0024Pj_0_003D == null)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610378));
			}
			if (_0023_003DzEbfoZ8c_003D.ContainsKey(_0023_003DzqP_0024Pj_0_003D))
			{
				return _0023_003DzEbfoZ8c_003D[_0023_003DzqP_0024Pj_0_003D];
			}
			_0023_003DzO9YCj5O_0024YYXX++;
			_0023_003DzMA4fqOpJrKds.Shaders[(shaderType)_0023_003DzO9YCj5O_0024YYXX] = new _0023_003DzFzcMdiXh0E2oBkC6o7lJH9t6kgLOf8_00246pw_003D_003D
			{
				Shader = _0023_003DzqP_0024Pj_0_003D
			};
			_0023_003DzEbfoZ8c_003D[_0023_003DzqP_0024Pj_0_003D] = _0023_003DzO9YCj5O_0024YYXX;
			return _0023_003DzO9YCj5O_0024YYXX;
		}

		public bool _0023_003DzIfTRMjcdlbHS(GLShader _0023_003DzqP_0024Pj_0_003D, ShaderParameters _0023_003Dz54qDY2UMhbmA)
		{
			if (_0023_003DzqP_0024Pj_0_003D == null)
			{
				throw new EyeshotException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610378));
			}
			if (_0023_003DzEbfoZ8c_003D.ContainsKey(_0023_003DzqP_0024Pj_0_003D))
			{
				_0023_003DzMA4fqOpJrKds.SetShader((shaderType)_0023_003DzEbfoZ8c_003D[_0023_003DzqP_0024Pj_0_003D], _0023_003Dz54qDY2UMhbmA);
				return true;
			}
			return false;
		}

		public bool _0023_003DzqPe4SdK2glT8(GLShader _0023_003DzqP_0024Pj_0_003D)
		{
			if (_0023_003DzEbfoZ8c_003D.ContainsKey(_0023_003DzqP_0024Pj_0_003D))
			{
				_0023_003DzMA4fqOpJrKds.Shaders.Remove((shaderType)_0023_003DzEbfoZ8c_003D[_0023_003DzqP_0024Pj_0_003D]);
				_0023_003DzEbfoZ8c_003D.Remove(_0023_003DzqP_0024Pj_0_003D);
				return true;
			}
			return false;
		}

		public bool _0023_003Dzq4Aw_ksDOEK79KYO6A_003D_003D()
		{
			bool flag = false;
			foreach (int value in _0023_003DzEbfoZ8c_003D.Values)
			{
				flag |= _0023_003DzMA4fqOpJrKds.Shaders.Remove((shaderType)value);
			}
			_0023_003DzO9YCj5O_0024YYXX = _0023_003DzjrYgyQTQ_0024eFX;
			_0023_003DzEbfoZ8c_003D.Clear();
			return flag;
		}
	}

	private enum _0023_003Dzede4j5s_003D
	{

	}

	private enum _0023_003DzhQQ5Bmw_003D
	{

	}

	internal sealed class _0023_003DziIgK5JBbSZfOUCxxIg_003D_003D : GLShader
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			if (_0023_003DzgcK4Z11iT1YA is ShaderParameters)
			{
				ShaderParameters shaderParameters = (ShaderParameters)_0023_003DzgcK4Z11iT1YA;
				Enable(shaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610324));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610342));
				int uniformLocation3 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610360));
				gl.Uniform1i(uniformLocation, 0);
				gl.Uniform1i(uniformLocation2, 1);
				gl.Uniform1i(uniformLocation3, 2);
				Disable(shaderParameters.RenderContext);
			}
		}
	}

	internal sealed class _0023_003DzjLzDSxk_0024tAp_0024WRyD8w_003D_003D : GLShader
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			if (_0023_003DzgcK4Z11iT1YA is _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2)
			{
				gl.UniformMatrix4fvARB(GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610111)), 1, transpose: false, _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E2.WorldViewProj);
			}
			else if (_0023_003DzgcK4Z11iT1YA is BlurShaderParameters)
			{
				BlurShaderParameters blurShaderParameters = (BlurShaderParameters)_0023_003DzgcK4Z11iT1YA;
				Enable(blurShaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610466));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649421));
				int uniformLocation3 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610482));
				gl.Uniform1i(uniformLocation, 0);
				gl.Uniform1fv(uniformLocation2, 19, blurShaderParameters.offset);
				gl.Uniform1fv(uniformLocation3, 19, blurShaderParameters.kerValue);
				Disable(blurShaderParameters.RenderContext);
			}
		}
	}

	internal sealed class _0023_003Dzwq4PubB2nTecRBem6g_003D_003D : _0023_003Dz4sTCQ2BYF7HT
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			base.SetParameters(_0023_003DzgcK4Z11iT1YA);
			if (_0023_003DzgcK4Z11iT1YA is AoShaderParameters aoShaderParameters)
			{
				Enable(aoShaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608815));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608827));
				int uniformLocation3 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608844));
				int uniformLocation4 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608862));
				int uniformLocation5 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608876));
				int uniformLocation6 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608894));
				gl.Uniform1i(uniformLocation, 0);
				gl.Uniform1i(uniformLocation2, 1);
				gl.Uniform1ui(uniformLocation3, (uint)aoShaderParameters.FilterRadius);
				gl.Uniform1f(uniformLocation4, aoShaderParameters.FilterSmoothness);
				gl.Uniform2f(uniformLocation5, (float)aoShaderParameters.NearFar.X, (float)aoShaderParameters.NearFar.Y);
				gl.Uniform1f(uniformLocation6, aoShaderParameters.FilterFactor);
				Disable(aoShaderParameters.RenderContext);
			}
		}
	}

	internal sealed class _0023_003DzzYEEIaEZSc9QbsJGBQ_003D_003D : _0023_003DzBeQqwZcYe4PHbbJBGg_003D_003D
	{
		public override void SetParameters(object _0023_003DzgcK4Z11iT1YA)
		{
			base.SetParameters(_0023_003DzgcK4Z11iT1YA);
			if (_0023_003DzgcK4Z11iT1YA is SilhoShaderParameters silhoShaderParameters)
			{
				Enable(silhoShaderParameters.RenderContext);
				int uniformLocation = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610062));
				int uniformLocation2 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610079));
				int uniformLocation3 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610221));
				int uniformLocation4 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610065));
				int uniformLocation5 = GetUniformLocation(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348610301));
				gl.Uniform1i(uniformLocation, 0);
				gl.Uniform1i(uniformLocation2, 1);
				gl.UniformMatrix4fvARB(uniformLocation3, 1, transpose: false, silhoShaderParameters.Projection);
				gl.Uniform2f(uniformLocation4, (float)silhoShaderParameters.DepthRange.X, (float)silhoShaderParameters.DepthRange.Y);
				gl.Uniform2f(uniformLocation5, (float)silhoShaderParameters.NearFar.X, (float)silhoShaderParameters.NearFar.Y);
				Disable(silhoShaderParameters.RenderContext);
			}
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OGLTexture[] _0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003DzIKTctZObALSugqXE0sTnioM_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float _0023_003Dztb34IRDzkBAcKQHR4VrpeDk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private gl _0023_003Dzc11wwqc_003D = new gl();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E _0023_003Dz_BT7SDwEbLrP;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal static Version _0023_003DzdkLBX8sX9mQG = new Version(3, 3);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal PixelFormatDescriptor _0023_003Dz0ctbe6g_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzkFbaBdSENROmek0D_0024Q_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float _0023_003Dz3SvioPUuCfd863V5WA_003D_003D = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float _0023_003Dz8QxojClFXuom2svmIQ_003D_003D = 1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float _0023_003Dzu_0024_0024UqlQdtWiA8x2BFQ_003D_003D = 0.5f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float _0023_003DzPYLI8KOLTIENhgoLew_003D_003D = 0.5f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float _0023_003Dzcq6GZUW_0024R7CcgJpkqg_003D_003D = 0f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float _0023_003DzB47fgd5SFRKVseVZSw_003D_003D = 0f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float _0023_003DzcZYcod8lcyLct_STLw_003D_003D = -0.5f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static float _0023_003DzeK873CmRK9u6Vk6RjQ_003D_003D = -1f;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzU4qslIzzR7vFf7wOMHXtouY_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Bitmap _0023_003DzCKW_0024S_0024sr38Ji;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private BitmapData _0023_003DzhOAh7hEbv3BK;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz0aYfsxa60DMn;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzESauDJ_cJSGvlPERmyIX_0024joPOZg_u__oLw_003D_003D _0023_003DzxbCbL_0024mWtybX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzESauDJ_cJSGvlPERmyIX_0024joPOZg_u__oLw_003D_003D _0023_003DzBwwM1oE5VAZch0PqXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzESauDJ_cJSGvlPERmyIX_0024joPOZg_u__oLw_003D_003D _0023_003DzrHA4OiNdy_002485dlJi6g_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private OGLEntityBuffer _0023_003DzedrTcGwlfm64KpQe1A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzmxaFeOccxXUejIw_00249Q_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzQapBRGvgfbOm;

	protected bool samplesBuffersARB;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzUEv4S5BpAiMt;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal Stack<FrameBufferObjectBase> _0023_003Dz5OlB2TJNAVRx = new Stack<FrameBufferObjectBase>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private _0023_003DzcaoARosWGMzewm3T6w_003D_003D _0023_003DzuYX3TwfUt3k6;

	[CLSCompliant(false)]
	protected internal gl gl => _0023_003Dzc11wwqc_003D;

	public override string RendererName => gl.GetString(7937);

	[Browsable(false)]
	[Description("The company responsible for this GL implementation. This name does not change from release to release.")]
	public string OpenglVendor => gl.GetString(7936);

	[Browsable(false)]
	[Description("Graphics API version.")]
	public override Version RendererVersion => gl._0023_003DzQlU53AFjJmCgCfoa_0024Q_003D_003D;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Version ShadingLanguageVersion
	{
		get
		{
			Version rendererVersion = RendererVersion;
			Version result = new Version(0, 0);
			if (rendererVersion.Major == 1)
			{
				if (OpenglExtensions.Contains(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608075)))
				{
					result = new Version(1, 0);
				}
			}
			else if (rendererVersion.Major >= 2)
			{
				result = gl._0023_003DzEDLTT7s_003D(gl.GetString(35724));
			}
			return result;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public string OpenglExtensions
	{
		get
		{
			int[] integerv = gl.GetIntegerv(33309, 1);
			string text = string.Empty;
			for (int i = 0; i < integerv[0]; i++)
			{
				text = text + gl.GetStringi(7939, i) + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348651338);
			}
			return text;
		}
	}

	public override bool SupportShadows => gl.ARB_shadow;

	public override bool TextureNonPowerOfTwo => gl.ARB_texture_non_power_of_two;

	public override bool EnableAlphaClip(bool enable)
	{
		_0023_003Dz_BT7SDwEbLrP.AlphaClip = enable;
		return base.EnableAlphaClip(enable);
	}

	private void _0023_003Dz2CJ_0024wXE_003D(float[] _0023_003Dzt5jpbHs_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D, bool _0023_003DzKs6hunzjen4G)
	{
		if (CompilingEntity != null)
		{
			_0023_003Dzped9ZPq4ahes(_0023_003Dzt5jpbHs_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G);
			return;
		}
		_0023_003DzxbCbL_0024mWtybX._0023_003DzhzizObU_003D(_0023_003Dzt5jpbHs_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D);
		_0023_003DzxbCbL_0024mWtybX.Draw(this);
	}

	private void _0023_003Dz8UwOt6tpkImF(_0023_003DzxMfii5FvRHCf7KMoYW35TB7JQjEk _0023_003DzSVpkYxU_003D, float[] _0023_003Dzt5jpbHs_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D, bool _0023_003DzKs6hunzjen4G, bool _0023_003Dz9Yc_0024ROw_003D, shaderType _0023_003DzqP_0024Pj_0_003D)
	{
		if (CompilingEntity != null)
		{
			_0023_003Dzped9ZPq4ahes(_0023_003Dzt5jpbHs_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G);
			return;
		}
		if (!_0023_003DzSVpkYxU_003D._0023_003Dz_0024_DPFp19tOjE(_0023_003Dzt5jpbHs_003D.Length))
		{
			_0023_003DzW5PWAngs9S9h(_0023_003DzSVpkYxU_003D, _0023_003Dz9Yc_0024ROw_003D, _0023_003DzqP_0024Pj_0_003D);
		}
		_0023_003DzSVpkYxU_003D._0023_003DzgWaA5Nc_003D(_0023_003DzSVpkYxU_003D._0023_003DzpGRLDJ0OtMj0(), _0023_003Dzt5jpbHs_003D, null, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, 0, _0023_003Dzp_0024qFwgs_003D: false);
	}

	private void _0023_003Dz2CJ_0024wXE_003D(float[] _0023_003Dzt5jpbHs_003D, int[] _0023_003Dzdo7ctlc_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D, int _0023_003Dz4Im51Qk_003D)
	{
		if (CompilingEntity != null)
		{
			_0023_003Dzped9ZPq4ahes(_0023_003Dzt5jpbHs_003D, _0023_003Dzdo7ctlc_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, _0023_003Dz4Im51Qk_003D, _0023_003DzKs6hunzjen4G: false);
			return;
		}
		_0023_003DzxbCbL_0024mWtybX._0023_003DzhzizObU_003D(_0023_003Dzt5jpbHs_003D, 0, _0023_003Dzt5jpbHs_003D.Length, _0023_003DzRbrcOgQ_003D, _0023_003Dzdo7ctlc_003D, 0, _0023_003Dz4Im51Qk_003D, _0023_003DzQZ1JmC0_003D);
		_0023_003DzxbCbL_0024mWtybX.Draw(this);
	}

	public override void DrawLine(float[] linePoints)
	{
		_0023_003Dz2CJ_0024wXE_003D(linePoints, primitiveType.LineList, 2, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLine(float x0, float y0, float z0, float x1, float y1, float z1)
	{
		DrawLine(new float[6] { x0, y0, z0, x1, y1, z1 });
	}

	public override void DrawLine(Point2D p0, Point2D p1)
	{
		DrawLine((float)p0.X, (float)p0.Y, 0f, (float)p1.X, (float)p1.Y, 0f);
	}

	public override void DrawLine(Point3D p0, Point3D p1)
	{
		DrawLine((float)p0.X, (float)p0.Y, (float)p0.Z, (float)p1.X, (float)p1.Y, (float)p1.Z);
	}

	public override void DrawLine(PointRGB p0, PointRGB p1)
	{
		PushShader();
		SetShader(shaderType.MultiColorNoLights);
		float[] _0023_003Dzt5jpbHs_003D = new float[14]
		{
			(float)p0.X,
			(float)p0.Y,
			(float)p0.Z,
			(float)(int)p0.R / 256f,
			(float)(int)p0.G / 256f,
			(float)(int)p0.B / 256f,
			1f,
			(float)p1.X,
			(float)p1.Y,
			(float)p1.Z,
			(float)(int)p1.R / 256f,
			(float)(int)p1.G / 256f,
			(float)(int)p1.B / 256f,
			1f
		};
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineList, 2, _0023_003DzKs6hunzjen4G: false);
		PopShader();
	}

	public override void DrawLine(Point3D p0, Point3D p1, Point2D texCoords)
	{
		_0023_003Dz2CJ_0024wXE_003D(new float[14]
		{
			(float)p0.X,
			(float)p0.Y,
			(float)p0.Z,
			0f,
			0f,
			0f,
			(float)texCoords.X,
			(float)p1.X,
			(float)p1.Y,
			(float)p1.Z,
			0f,
			0f,
			0f,
			(float)(1.0 - texCoords.Y)
		}, primitiveType.LineList, 2, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLines(Point3D[] vertices, int first, int count)
	{
		DrawLines(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(vertices, first, count, _0023_003DzN_MOKU7jsa0t: false));
	}

	public override void DrawLines(Point3D[] vertices, System.Drawing.Color[] colors, int first, int count)
	{
		float[] array = new float[count * 7];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = first; i < count; i++)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, vertices[i], ref _0023_003DzPH_0024hvqk_003D);
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, colors[i], ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz0Bcc8cVsLrG4(array, 7, count);
	}

	public override void DrawLines(Point3D[] vertices, System.Drawing.Color[] colors, float[] lineWidths, int first, int count)
	{
		float[] array = new float[count * 8];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = first; i < count; i++)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, vertices[i], ref _0023_003DzPH_0024hvqk_003D);
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, colors[i], ref _0023_003DzPH_0024hvqk_003D);
			array[_0023_003DzPH_0024hvqk_003D++] = lineWidths[i / 2];
		}
		_0023_003Dz0Bcc8cVsLrG4(array, 8, count);
	}

	public override void DrawLines(float[] vertices, int first, int count)
	{
		PackData(ref vertices, 3, first, count);
		_0023_003Dz0Bcc8cVsLrG4(vertices, 3, count);
	}

	private void _0023_003Dz0Bcc8cVsLrG4(float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int _0023_003Dzk1qYfgmbcPgvVkTW_g_003D_003D, int _0023_003DzPH_0024hvqk_003D)
	{
		if (CompilingEntity != null)
		{
			_0023_003Dzped9ZPq4ahes(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, primitiveType.LineList, _0023_003DzPH_0024hvqk_003D, _0023_003DzKs6hunzjen4G: false);
			return;
		}
		_0023_003DzxbCbL_0024mWtybX._0023_003DzhzizObU_003D(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, 0, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length, primitiveType.LineList, _0023_003DzPH_0024hvqk_003D);
		_0023_003DzxbCbL_0024mWtybX.Draw(this);
	}

	public override void DrawLines(Point3D[] vertices, float[] texCoords, int first, int count)
	{
		float[] array = new float[count * 7];
		int _0023_003DzPH_0024hvqk_003D = 0;
		Vector3D _0023_003Dz3kjjQlQ_003D = new Vector3D();
		for (int i = first; i < count; i++)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, vertices[i], ref _0023_003DzPH_0024hvqk_003D);
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, _0023_003Dz3kjjQlQ_003D, ref _0023_003DzPH_0024hvqk_003D);
			array[_0023_003DzPH_0024hvqk_003D++] = texCoords[i];
		}
		_0023_003Dz0Bcc8cVsLrG4(array, 7, count);
	}

	protected internal override bool CreateHilbertLut(Bitmap bmp)
	{
		if (RendererVersion.Major < 2)
		{
			return false;
		}
		uint width = (uint)bmp.Width;
		uint height = (uint)bmp.Height;
		BitmapData bitmapData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, (int)width, (int)height), ImageLockMode.ReadOnly, PixelFormat.Format16bppGrayScale);
		aoNoiseTexture?.Dispose();
		aoNoiseTexture = new OGLTexture(this, width, height, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, _0023_003DzMOUqauw_003D: false, _0023_003Dz07HQcxg_003D: false, 33332, 36244, 5123, bitmapData.Scan0);
		bmp.UnlockBits(bitmapData);
		return true;
	}

	public override void DrawLineStrip(float[] vertices, int first, int count)
	{
		PackData(ref vertices, 3, first, count);
		_0023_003Dz2CJ_0024wXE_003D(vertices, primitiveType.LineStrip, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLineStripRGBA(float[] vertices, int first, int count)
	{
		PackData(ref vertices, 7, first, count);
		_0023_003Dz2CJ_0024wXE_003D(vertices, primitiveType.LineStrip, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLineStrip(Point3D[] vertices, float[] texCoords, int first, int count)
	{
		float[] array = new float[(count - first) * 7];
		int num = 0;
		for (int i = first; i < count; i++)
		{
			Point3D point3D = vertices[i];
			array[num++] = (float)point3D.X;
			array[num++] = (float)point3D.Y;
			array[num++] = (float)point3D.Z;
			array[num++] = 0f;
			array[num++] = 0f;
			array[num++] = 0f;
			array[num++] = texCoords[i];
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.LineStrip, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLineStrip(Point2D[] vertices, int first, int count)
	{
		DrawLineStrip(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzXjTP_YwBygkIQCv1bg_003D_003D(vertices), first, count);
	}

	public override void DrawLineStrip(Point3D[] vertices, int first, int count)
	{
		DrawLineStrip(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(vertices), first, count);
	}

	public override void DrawLineStrip(PointRGB[] vertices, int first, int count)
	{
		DrawLineStripRGBA(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzE8czomGZ4WksTGP5mw_003D_003D(vertices), first, count);
	}

	public override void DrawPoints(float[] points, int first, int count)
	{
		PackData(ref points, 3, first, count);
		_0023_003Dz2CJ_0024wXE_003D(points, primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPoints(Point3D[] points, int first, int count)
	{
		DrawPoints(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(points, 0, count, _0023_003DzN_MOKU7jsa0t: false), first, count);
	}

	public override void DrawPointsIndeterminate(Point3D[] points, int first, int count)
	{
		DrawPoints(points, first, count);
	}

	public override void DrawPointsWithNormalsIndeterminate(float[] points, float[] normals, int first, int count)
	{
		int num = count * 3;
		float[] array = new float[points.Length * 2];
		int num2 = first * 3;
		int num3 = first * 3;
		while (num2 < num)
		{
			array[num2] = points[num2++];
			array[num2] = points[num2++];
			array[num2] = points[num2++];
			array[num3] = normals[num3++];
			array[num3] = normals[num3++];
			array[num3] = normals[num3++];
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsIndeterminate(float[] points, int first, int count)
	{
		DrawPoints(points, first, count);
	}

	public override void DrawPointsRGB(Point3D[] points, int first, int count)
	{
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DztEk3ypKZZaD9(points, first, count), primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsRGBIndeterminate(Point3D[] points, int first, int count)
	{
		DrawPointsRGB(points, first, count);
	}

	public override void DrawPointsWithColorsRGBIndeterminate(float[] points, byte[] colors, int first, int count)
	{
		float[] array = new float[count * 7];
		int num = first * 3;
		int num2 = first * 3;
		int num3 = 0;
		for (int i = 0; i < count; i++)
		{
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = 1f;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsWithColorsRGBAIndeterminate(float[] points, byte[] colors, int first, int count)
	{
		float[] array = new float[count * 7];
		int num = first * 3;
		int num2 = first * 4;
		int num3 = 0;
		for (int i = 0; i < count; i++)
		{
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsWithColorIntensitiesIndeterminate(float[] points, byte[] colors, int first, int count)
	{
		float[] array = new float[count * 7];
		int num = first * 3;
		int num2 = first;
		int num3 = 0;
		for (int i = 0; i < count; i++)
		{
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = points[num++];
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = (float)(int)colors[num2++] / 255f;
			array[num3++] = 1f;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsWithNormals(Point3D[] points, Vector3D[] normals, int first, int count)
	{
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzt5OBdcRczGuHRDp_002432bsClw_003D(points, normals, first, count), primitiveType.PointList, count, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPointsWithNormalsIndeterminate(Point3D[] points, Vector3D[] normals, int first, int count)
	{
		DrawPointsWithNormals(points, normals, first, count);
	}

	public override void DrawIndeterminateAsPoints(EntityGraphicsData data)
	{
		OGLEntityBuffer _0023_003DzrGVDsYRQZJCT = ((OglEntityGraphicsData)data)._0023_003DzrGVDsYRQZJCT;
		if (_0023_003DzrGVDsYRQZJCT == null)
		{
			ThrowEntityNotCompiledError(data);
		}
		_0023_003DzrGVDsYRQZJCT._0023_003Dzz8j8G7g_003D[0]._0023_003Dz_002475wn_0024QGlEFt(primitiveType.PointList);
		_0023_003DzrGVDsYRQZJCT.Draw(this);
	}

	public override void DrawIndeterminateAsLineStrip(EntityGraphicsData data)
	{
		OGLEntityBuffer _0023_003DzrGVDsYRQZJCT = ((OglEntityGraphicsData)data)._0023_003DzrGVDsYRQZJCT;
		if (_0023_003DzrGVDsYRQZJCT == null)
		{
			ThrowEntityNotCompiledError(data);
		}
		_0023_003DzrGVDsYRQZJCT._0023_003Dzz8j8G7g_003D[0]._0023_003Dz_002475wn_0024QGlEFt(primitiveType.LineStrip);
		_0023_003DzrGVDsYRQZJCT.Draw(this);
	}

	public override void DrawIndeterminateAsLineList(EntityGraphicsData data)
	{
		OGLEntityBuffer _0023_003DzrGVDsYRQZJCT = ((OglEntityGraphicsData)data)._0023_003DzrGVDsYRQZJCT;
		if (_0023_003DzrGVDsYRQZJCT == null)
		{
			ThrowEntityNotCompiledError(data);
		}
		_0023_003DzrGVDsYRQZJCT._0023_003Dzz8j8G7g_003D[0]._0023_003Dz_002475wn_0024QGlEFt(primitiveType.LineList);
		_0023_003DzrGVDsYRQZJCT.Draw(this);
	}

	public override void DrawQuad(System.Drawing.RectangleF rect, float zCoord)
	{
		float[] _0023_003Dzt5jpbHs_003D = new float[12]
		{
			rect.Left, rect.Top, zCoord, rect.Right, rect.Top, zCoord, rect.Left, rect.Bottom, zCoord, rect.Right,
			rect.Bottom, zCoord
		};
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleStrip, 4, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawQuadsOutlines(Point3D[] vertices)
	{
		List<float> list = new List<float>(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(vertices));
		int num = 0;
		for (int i = 0; i < vertices.Length; i += 4)
		{
			List<float> range = list.GetRange(num, num + 12);
			range.Add(range[0]);
			range.Add(range[1]);
			range.Add(range[2]);
			_0023_003Dz2CJ_0024wXE_003D(range.ToArray(), primitiveType.LineStrip, 5, _0023_003DzKs6hunzjen4G: false);
			num += 12;
		}
	}

	protected override void DrawQuadWithColorRange(System.Drawing.RectangleF rect, System.Drawing.Color color1, System.Drawing.Color color2)
	{
		float[] array = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003Dzj1AuNDflFaBs(color1);
		float[] array2 = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003Dzj1AuNDflFaBs(color2);
		float[] _0023_003Dzt5jpbHs_003D = new float[28]
		{
			rect.Left,
			rect.Bottom,
			0f,
			array2[0],
			array2[1],
			array2[2],
			array2[3],
			rect.Left,
			rect.Top,
			0f,
			array[0],
			array[1],
			array[2],
			array[3],
			rect.Right,
			rect.Bottom,
			0f,
			array2[0],
			array2[1],
			array2[2],
			array2[3],
			rect.Right,
			rect.Top,
			0f,
			array[0],
			array[1],
			array[2],
			array[3]
		};
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleStrip, 4, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawQuadWithTextures(TextureBase texture, float[] texCoords, byte alpha, System.Drawing.RectangleF rect, float zCoord, bool buffered)
	{
		SetTexture(texture);
		float[] array = ((!(texture is OGLTexture)) ? new float[28]
		{
			rect.Left,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[4],
			rect.Left,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[0],
			rect.Right,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[6],
			rect.Right,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[2]
		} : new float[32]
		{
			rect.Left,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[0],
			texCoords[1],
			rect.Right,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[2],
			texCoords[3],
			rect.Left,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[6],
			texCoords[7],
			rect.Right,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[4],
			texCoords[5]
		});
		if (buffered)
		{
			int[] _0023_003Dzdo7ctlc_003D = new int[6]
			{
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 1,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 2,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 1,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 3,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 2
			};
			if (!_0023_003DzxbCbL_0024mWtybX._0023_003Dz_0024_DPFp19tOjE(array.Length))
			{
				DrawCurrentBuffer();
			}
			_0023_003DzxbCbL_0024mWtybX._0023_003DzgWaA5Nc_003D(_0023_003DzxbCbL_0024mWtybX._0023_003DzpGRLDJ0OtMj0(), array, _0023_003Dzdo7ctlc_003D, primitiveType.TriangleList, 4, 6, _0023_003Dzp_0024qFwgs_003D: false);
		}
		else
		{
			_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.TriangleStrip, 4, _0023_003DzKs6hunzjen4G: false);
		}
	}

	protected internal override void DrawQuadWithTextures(TextureBase[] textures, float[] texCoords, byte alpha, System.Drawing.RectangleF rect, float zCoord, bool buffered)
	{
		for (int i = 0; i < textures.Length; i++)
		{
			SetTexture(textures[i], (TextureBase.textureUnitType)i);
		}
		float[] array = ((textures[0] is OGLTexture1D) ? new float[28]
		{
			rect.Left,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[4],
			rect.Left,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[0],
			rect.Right,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[6],
			rect.Right,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[2]
		} : new float[32]
		{
			rect.Left,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[6],
			texCoords[7],
			rect.Left,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[0],
			texCoords[1],
			rect.Right,
			rect.Bottom,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[4],
			texCoords[5],
			rect.Right,
			rect.Top,
			zCoord,
			0f,
			0f,
			0f,
			texCoords[2],
			texCoords[3]
		});
		if (buffered)
		{
			int[] _0023_003Dzdo7ctlc_003D = new int[6]
			{
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 1,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 2,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 1,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 3,
				_0023_003DzxbCbL_0024mWtybX._0023_003DzMg_0024ToqfKdyW_x_N63g_003D_003D + 2
			};
			if (!_0023_003DzxbCbL_0024mWtybX._0023_003Dz_0024_DPFp19tOjE(array.Length))
			{
				DrawCurrentBuffer();
			}
			_0023_003DzxbCbL_0024mWtybX._0023_003DzgWaA5Nc_003D(_0023_003DzxbCbL_0024mWtybX._0023_003DzpGRLDJ0OtMj0(), array, _0023_003Dzdo7ctlc_003D, primitiveType.TriangleList, 4, 6, _0023_003Dzp_0024qFwgs_003D: false);
		}
		else
		{
			_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.TriangleStrip, 4, _0023_003DzKs6hunzjen4G: false);
		}
		for (int j = 0; j < textures.Length; j++)
		{
			CloseTexture((TextureBase.textureUnitType)j);
		}
	}

	public override bool InitProgDrawCompositing()
	{
		base.InitProgDrawCompositing();
		ProgDrawCompositingBase = new _0023_003DzD_B0zqx_uBZMOdOvq_00248IaR8HpcWdriRlc0CFxtdxyzgN();
		return ProgDrawCompositingBase.Init(this);
	}

	private protected override AOCompositingBase GetAoCompositingObj(bool _0023_003DzUOFKio2ucC4D)
	{
		return new _0023_003Dzo3dqyJV4YjlJH6p4_4AteZ_8U2I1eASYl0iGuTk_003D(_0023_003DzUOFKio2ucC4D);
	}

	private protected override SilhoCompositingBase GetSilhoCompositingObj()
	{
		return new _0023_003Dzp268D_GjO8ad1p6OoVpWT6BywmGlJnsGuHeUpWpLEFhx();
	}

	private protected override SmoothUICompositingBase GetSmoothUICompositingObj()
	{
		return new _0023_003Dzdq3hE64XQd2A6GDydy6o0X11tgvwcetkHs3ypHUTm1DNghjtvg_003D_003D();
	}

	private protected override HaloSelectionCompositingBase GetDynamicSelectionCompositingObj()
	{
		return new _0023_003DzjG5ElFdNCEjndiX_0024sKsH7sRxadA3rWNSMAOGV4liOtJd();
	}

	public override void DrawBorder(Dictionary<shaderType, IShaderTechnique> shaders, System.Drawing.Color borderColor, Size size, int radius, bool visible, object borderBitmap, object lowerLeftCorner, object lowerRightCorner, object topLeftCorner, object topRightCorner)
	{
		if (_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D == null)
		{
			if (radius > 0)
			{
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D = new OGLTexture[4];
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[0] = new OGLTexture();
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[1] = new OGLTexture();
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[2] = new OGLTexture();
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[3] = new OGLTexture();
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[0].Load(this, (Bitmap)lowerLeftCorner, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, repeatX: false, repeatY: false);
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[1].Load(this, (Bitmap)lowerRightCorner, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, repeatX: false, repeatY: false);
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[2].Load(this, (Bitmap)topRightCorner, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, repeatX: false, repeatY: false);
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[3].Load(this, (Bitmap)topLeftCorner, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, repeatX: false, repeatY: false);
			}
			else if (IsMultisample())
			{
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D = new OGLTexture[1];
				Bitmap bitmap = new Bitmap(1, 1);
				bitmap.SetPixel(0, 0, borderColor);
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[0] = new OGLTexture();
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[0].Load(this, bitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, repeatX: false, repeatY: false);
				bitmap.Dispose();
			}
		}
		SetState(depthStencilStateType.DepthTestOff);
		float x = size.Width - 1;
		float num = 0f;
		float y = size.Height - 1;
		float num2 = size.Width - 1;
		float num3 = size.Height - 1;
		if (visible)
		{
			float width = num2 + 1f - (float)(2 * radius);
			float height = num3 + 1f - (float)(2 * radius);
			System.Drawing.RectangleF rect = new System.Drawing.RectangleF(radius, num, width, 1f);
			System.Drawing.RectangleF rect2 = new System.Drawing.RectangleF(radius, y, width, 1f);
			System.Drawing.RectangleF rect3 = new System.Drawing.RectangleF(0f, num + (float)radius, 1f, height);
			System.Drawing.RectangleF rect4 = new System.Drawing.RectangleF(x, num + (float)radius, 1f, height);
			PushRasterizerState();
			SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
			if (IsMultisample())
			{
				SetShader(shaderType.Texture2DNoLights);
				TextureBase texture = _0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[(radius > 0) ? 3 : 0];
				SetMatrices();
				DrawQuadWithTextures(texture, new float[8], byte.MaxValue, rect, 0f, buffered: false);
				DrawQuadWithTextures(texture, new float[8], byte.MaxValue, rect2, 0f, buffered: false);
				DrawQuadWithTextures(texture, new float[8], byte.MaxValue, rect3, 0f, buffered: false);
				DrawQuadWithTextures(texture, new float[8], byte.MaxValue, rect4, 0f, buffered: false);
			}
			else
			{
				SetShader(shaderType.NoLights);
				SetColorWireframe(borderColor);
				DrawQuad(rect);
				DrawQuad(rect2);
				DrawQuad(rect3);
				DrawQuad(rect4);
			}
			PopRasterizerState();
		}
		if (radius > 0)
		{
			SetShader(shaderType.Texture2DNoLights);
			SetMatrices();
			SetState(blendStateType.Blend_Mask_RGB);
			DrawQuad(_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[3], byte.MaxValue, new System.Drawing.RectangleF(0f, 0f, radius, radius), 0f, flipY: false);
			DrawQuad(_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[2], byte.MaxValue, new System.Drawing.RectangleF(size.Width - radius, 0f, radius, radius), 0f, flipY: false);
			DrawQuad(_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[1], byte.MaxValue, new System.Drawing.RectangleF(size.Width - radius, size.Height - radius, radius, radius), 0f, flipY: false);
			DrawQuad(_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[0], byte.MaxValue, new System.Drawing.RectangleF(0f, size.Height - radius, radius, radius), 0f, flipY: false);
			SetState(blendStateType.NoBlend);
		}
		SetState(depthStencilStateType.DepthTestLess);
	}

	public override void DrawPixels(TextureBase texture, Bitmap bmp, Point2D rasterPos, Size destSize, bool flipY)
	{
		if (texture == null)
		{
			texture = new OGLTexture();
			texture.Load(this, bmp, textureFilteringFunctionType.Nearest);
		}
		DrawQuad(texture, byte.MaxValue, new System.Drawing.RectangleF((float)rasterPos.X, (float)rasterPos.Y, destSize.Width, destSize.Height), 0f, flipY);
	}

	public override void DrawSilhouettes(GfxSilhoData data)
	{
		if (data.VertexArrayData.indicesCount * 2 != 0)
		{
			int indicesCount = data.VertexArrayData.indicesCount;
			float[] array = new float[indicesCount * 6];
			int num = 0;
			for (int i = 0; i < indicesCount; i++)
			{
				int num2 = data.VertexArrayData.indices[i, 0];
				int num3 = data.VertexArrayData.indices[i, 1];
				array[num++] = data.Vertices[num2, 0];
				array[num++] = data.Vertices[num2, 1];
				array[num++] = data.Vertices[num2, 2];
				array[num++] = data.Vertices[num3, 0];
				array[num++] = data.Vertices[num3, 1];
				array[num++] = data.Vertices[num3, 2];
			}
			_0023_003DzxbCbL_0024mWtybX._0023_003DzhzizObU_003D(array, primitiveType.LineList, indicesCount * 2);
			_0023_003DzxbCbL_0024mWtybX.Draw(this);
		}
	}

	public override void DrawPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz00s0VfKm4rbq(vertices, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz00s0VfKm4rbq(vertices, normals, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz0Q4yEpOowz76zjKgBA_003D_003D(vertices, normals, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawSurfaceTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzenPR8YpYXpXc(vertices, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawSurfaceInvTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz8rsrSuGTOynFruGGAA_003D_003D(vertices, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawColorPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzVjE0QEIosCCL(vertices, normals, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawColorSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzjSykECD_00240nxKdnrJoQ_003D_003D(vertices, normals, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawMulticolorPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, byte alpha = byte.MaxValue)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzLPWIe7IHYgq5yd2CyOGX7R_JZmFj(vertices, normals, triangles, alpha);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawMulticolorSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, byte alpha = byte.MaxValue)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzQIPF1_0024r2FrrXS2Tvdhmj52YPkFxsfLU1Gg_003D_003D(vertices, normals, triangles, alpha);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawCurvatureMapTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, System.Drawing.Color[] colorMap)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz7CBoPWOPOsyP1uhgsxVj5tM_003D(vertices, triangles, colorMap);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawCurvatureMapInvTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, System.Drawing.Color[] colorMap)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzgibj4Xwc8qvk5GE2hjSt_FsO14Yk(vertices, triangles, colorMap);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawRichPlainQuads(Point3D[] vertices, Vector3D[] normals, PointF[] texCoords)
	{
		int num = vertices.Length / 4;
		IndexTriangle[] array = new IndexTriangle[num * 2];
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		while (num3 < num)
		{
			array[num2++] = new RichTriangle(num4, num4 + 1, num4 + 2, num4 + 3, num4 + 2, num4 + 1);
			array[num2++] = new RichTriangle(num4, num4 + 2, num4 + 3, num4 + 3, num4 + 1, num4);
			num3++;
			num4 += 4;
		}
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzMmiNe4P_GRNtsNvliw_003D_003D(vertices, normals, texCoords, array);
		int _0023_003DzRbrcOgQ_003D = array.Length * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawRichPlainTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, IList<PointF> texCoords)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzMmiNe4P_GRNtsNvliw_003D_003D(vertices, normals, texCoords, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawRichSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, IList<Vector3D> normals, IList<PointF> texCoords)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzyOwKSPX1g5Ayz8V7rYO_0024Q7o_003D(vertices, normals, texCoords, triangles);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawRichSmoothTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, float scaleU, float scaleV, float offsetU, float offsetV, float rotateUV)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzyOwKSPX1g5Ayz8V7rYO_0024Q7o_003D(vertices, triangles, scaleU, scaleV, offsetU, offsetV, rotateUV);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawRichSmoothInvTriangles(IList<IndexTriangle> triangles, IList<Point3D> vertices, float scaleU, float scaleV, float offsetU, float offsetV, float rotateUV)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzdWsA7GhCz2yheIwTcdcf_ik_003D(vertices, triangles, scaleU, scaleV, offsetU, offsetV, rotateUV);
		int _0023_003DzRbrcOgQ_003D = triangles.Count * 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawIndexLines(IList<IndexLine> lines, Point3D[] vertices)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzxt_0024C4mfsru6P(lines, vertices, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineList, _0023_003DzVKEHOoE_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawIndexLines(IList<IndexLine> lines, float[] vertices)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzxt_0024C4mfsru6P(lines, vertices, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineList, _0023_003DzVKEHOoE_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawIndexLinesWithDisplacement(IList<IndexLine> lines, Point3D[] vertices, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzJDIVJsRbg20OVXIybQ_003D_003D(lines, vertices, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	public override void DrawLinesWithDisplacement(Point3D[] vertices, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dz9AhjvKeUMMns(vertices, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	private float _0023_003DzkbuQnNdOf01i()
	{
		return _0023_003DzIKTctZObALSugqXE0sTnioM_003D;
	}

	private void _0023_003DzDIa0Z4Vh9bSF(float _0023_003DzsLHxXyo_003D)
	{
		_0023_003DzIKTctZObALSugqXE0sTnioM_003D = _0023_003DzsLHxXyo_003D;
	}

	private float _0023_003DzlFzrZFohVfYp()
	{
		return _0023_003Dztb34IRDzkBAcKQHR4VrpeDk_003D;
	}

	private void _0023_003DzRdx7gppcbW2N(float _0023_003DzsLHxXyo_003D)
	{
		_0023_003Dztb34IRDzkBAcKQHR4VrpeDk_003D = _0023_003DzsLHxXyo_003D;
	}

	public override void DrawBufferedLine(Point3D v0, Point3D v1)
	{
		Vector4 vector = _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D._0023_003DzLEClaYWZdDNJ(base.CurrentWireColor);
		float num = Math.Max(_0023_003DzkbuQnNdOf01i(), Math.Min(_0023_003DzlFzrZFohVfYp(), base.CurrentLineWidth));
		float[] _0023_003Dzt5jpbHs_003D = new float[16]
		{
			(float)v0.X,
			(float)v0.Y,
			(float)v0.Z,
			vector.X,
			vector.Y,
			vector.Z,
			vector.W,
			num,
			(float)v1.X,
			(float)v1.Y,
			(float)v1.Z,
			vector.X,
			vector.Y,
			vector.Z,
			vector.W,
			num
		};
		_0023_003Dz8UwOt6tpkImF(_0023_003DzBwwM1oE5VAZch0PqXQ_003D_003D, _0023_003Dzt5jpbHs_003D, primitiveType.LineList, 2, _0023_003DzKs6hunzjen4G: true, _0023_003Dz9Yc_0024ROw_003D: true, shaderType.MultiColorNoLightsThickLinesPerVertex);
	}

	public override void DrawBufferedPoint(Point3D v0)
	{
		Vector4 vector = _0023_003DztUbFd8P_0024feNJd_00246QgfEtvbU_003D._0023_003DzLEClaYWZdDNJ(base.CurrentWireColor);
		float[] _0023_003Dzt5jpbHs_003D = new float[8]
		{
			(float)v0.X,
			(float)v0.Y,
			(float)v0.Z,
			vector.X,
			vector.Y,
			vector.Z,
			vector.W,
			base.CurrentPointSize
		};
		_0023_003Dz8UwOt6tpkImF(_0023_003DzrHA4OiNdy_002485dlJi6g_003D_003D, _0023_003Dzt5jpbHs_003D, primitiveType.PointList, 1, _0023_003DzKs6hunzjen4G: true, _0023_003Dz9Yc_0024ROw_003D: true, shaderType.MultiColorNoLightsThickPointsPerVertex);
	}

	public override void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, System.Drawing.Color singleColor, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(vertices, normals, singleColor, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	public override void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, System.Drawing.Color[] colors, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(vertices, normals, colors, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	public override void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(vertices, normals, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	public override void DrawTrianglesWithDisplacement(PointWithDisplacement[] vertices, Vector3D[] normals, float[] tex1DCoords, double ampFactor, int mode, bool addToCurrentBufferPart = false)
	{
		int _0023_003DzVKEHOoE_003D;
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzpJVQKGIWgr1iYWJawEw8Ybg_003D(vertices, normals, tex1DCoords, ampFactor, mode, out _0023_003DzVKEHOoE_003D);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, _0023_003DzVKEHOoE_003D, addToCurrentBufferPart);
	}

	public override void Draw(EntityGraphicsData baseData, primitiveType primitiveType = primitiveType.Undefined, uint? indexOffset = null, uint? indexCount = null)
	{
		OglEntityGraphicsData oglEntityGraphicsData = (OglEntityGraphicsData)baseData;
		OGLEntityBuffer _0023_003DzrGVDsYRQZJCT = oglEntityGraphicsData._0023_003DzrGVDsYRQZJCT;
		if (_0023_003DzrGVDsYRQZJCT == null)
		{
			ThrowEntityNotCompiledError(oglEntityGraphicsData);
		}
		for (int i = 0; i < _0023_003DzrGVDsYRQZJCT._0023_003Dzz8j8G7g_003D.Count; i++)
		{
			vertexBufferData vertexBufferData2 = _0023_003DzrGVDsYRQZJCT._0023_003Dzz8j8G7g_003D[i];
			switch (primitiveType)
			{
			case primitiveType.PointList:
				vertexBufferData2._0023_003Dz_002475wn_0024QGlEFt(primitiveType.PointList);
				break;
			case primitiveType.LineStrip:
				vertexBufferData2._0023_003Dz_002475wn_0024QGlEFt(primitiveType.LineStrip);
				break;
			case primitiveType.LineList:
				vertexBufferData2._0023_003Dz_002475wn_0024QGlEFt(primitiveType.LineList);
				break;
			case primitiveType.TriangleList:
				vertexBufferData2._0023_003Dz_002475wn_0024QGlEFt(primitiveType.TriangleList);
				break;
			case primitiveType.TriangleStrip:
				vertexBufferData2._0023_003Dz_002475wn_0024QGlEFt(primitiveType.TriangleStrip);
				break;
			default:
				throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599011));
			case primitiveType.Undefined:
				break;
			}
			switch (vertexBufferData2._0023_003DzDX_IlROkgDgt())
			{
			case primitiveType.LineList:
				SetLinesShader((double)_0023_003Dz_BT7SDwEbLrP._0023_003DzUTdFkSI_003D > 1.0, base.CurrentShader);
				break;
			case primitiveType.PointList:
				SetPointsShader((double)_0023_003Dz_BT7SDwEbLrP._0023_003DzIt9jKuJG8ncE > 1.0, base.CurrentShader);
				break;
			}
			_0023_003DzrGVDsYRQZJCT.Draw(this, i, indexOffset, indexCount);
		}
	}

	protected override bool SetPointsShader(bool thick, shaderType shader, ShaderParameters shaderParams = null)
	{
		if (shader == shaderType.MultiColorNoLights || shader == shaderType.MultiColor)
		{
			return base.SetPointsShader(thick, shaderType.MultiColorNoLights, shaderParams);
		}
		return base.SetPointsShader(thick, shader, shaderParams);
	}

	protected internal override bool SetLinesShader(bool thick, shaderType shader, ShaderParameters shaderParams = null)
	{
		bool result;
		if (thick)
		{
			if (lineStipple)
			{
				result = SetShader(shaderType.NoLightsThickLinesStipple, shaderParams);
			}
			else
			{
				switch (shader)
				{
				case shaderType.Standard:
					result = SetShader(shaderType.StandardThickLines);
					break;
				case shaderType.MultiColorNoLights:
				case shaderType.MultiColor:
					result = SetShader(shaderType.MultiColorNoLightsThickLines, shaderParams);
					break;
				case shaderType.MultiColorNoLightsThickLines:
					result = SetShader(shader, shaderParams);
					break;
				case shaderType.MultiColorNoLightsThickLinesPerVertex:
					result = true;
					break;
				case shaderType.Texture1DNoLights:
					result = SetShader(shaderType.Texture1DNoLightsThickLines, shaderParams);
					break;
				case shaderType.SingleColorModulatedByIntensity:
				case shaderType.SingleColorModulatedByIntensityThickLines:
					result = SetShader(shaderType.SingleColorModulatedByIntensityThickLines, shaderParams);
					break;
				default:
					result = SetShader(shaderType.NoLightsThickLines, shaderParams);
					break;
				}
			}
			RemovePolygonOffset(ref prevPolygonOffset);
			SetPolygonDrawingMode(rasterizerPolygonDrawingType.Fill);
		}
		else
		{
			if (lineStipple)
			{
				result = SetShader(shaderType.NoLightsLinesStipple);
			}
			else
			{
				switch (shader)
				{
				case shaderType.MultiColorNoLightsThickLinesPerVertex:
					result = true;
					break;
				case shaderType.MultiColorNoLightsThickLines:
					result = SetShader(shaderType.MultiColorNoLights, shaderParams);
					break;
				case shaderType.MultiColorNoLights:
					result = SetShader(shader, shaderParams);
					break;
				case shaderType.Texture1DNoLightsThickLines:
					result = SetShader(shaderType.Texture1DNoLights, shaderParams);
					break;
				case shaderType.MultiColorNoLightsThickPoints:
					result = SetShader(shaderType.MultiColorNoLights, shaderParams);
					break;
				case shaderType.SingleColorModulatedByIntensity:
				case shaderType.SingleColorModulatedByIntensityThickLines:
					result = SetShader(shaderType.SingleColorModulatedByIntensity, shaderParams);
					break;
				default:
					result = SetShader(shaderType.NoLights, shaderParams);
					break;
				}
			}
			RestorePolygonOffset(ref prevPolygonOffset);
		}
		return result;
	}

	public override void DrawNormals(Point3D[] vertices, Vector3D diffVector)
	{
		Point3D[] array = new Point3D[12];
		int num = vertices.Length / 6;
		int num2 = vertices.Length % 6;
		int num3 = 0;
		int num4 = 0;
		while (num4 < num)
		{
			int num5 = 0;
			int num6 = 0;
			while (num6 < 6)
			{
				array[num5++] = vertices[num3];
				array[num5++] = vertices[num3] + diffVector;
				num6++;
				num3++;
			}
			DrawLines(array);
			num4++;
			num3++;
		}
		if (num2 > 0)
		{
			array = new Point3D[num2 * 2];
			int num7 = 0;
			int num8 = 0;
			while (num8 < num2)
			{
				array[num7++] = vertices[num3];
				array[num7++] = vertices[num3] + diffVector;
				num8++;
				num3++;
			}
			DrawLines(array);
		}
	}

	public override void DrawNormals(Point3D[] vertices, IndexTriangle[] triangles, Vector3D[] normals, double length)
	{
		for (int i = 0; i < triangles.Length; i++)
		{
			IndexTriangle indexTriangle = triangles[i];
			Point3D[] vertices2 = new Point3D[3]
			{
				vertices[indexTriangle.V1],
				vertices[indexTriangle.V2],
				vertices[indexTriangle.V3]
			};
			Vector3D diffVector = normals[i] * length;
			DrawNormals(vertices2, diffVector);
		}
	}

	public override void DrawSurfaceNormals(Point3D[] vertices, double length)
	{
		for (int i = 0; i < vertices.Length; i++)
		{
			PointNormalUv pointNormalUv = (PointNormalUv)vertices[i];
			DrawLine(pointNormalUv, pointNormalUv + pointNormalUv.Normal * length);
		}
	}

	private void _0023_003DzI0krhr3o0LGChFWi9Q_003D_003D(Point3D[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, Vector3D[] _0023_003DzQPpxw1Hu0Rft)
	{
		Point3D[] array = new Point3D[12];
		int num = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length / 6;
		int num2 = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D.Length % 6;
		int num3 = 0;
		for (int i = 0; i < num; i++)
		{
			int num4 = 0;
			int num5 = 0;
			while (num5 < 6)
			{
				array[num4++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3];
				array[num4++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3] + _0023_003DzQPpxw1Hu0Rft[num3];
				num5++;
				num3++;
			}
			DrawLines(array);
		}
		if (num2 > 0)
		{
			array = new Point3D[num2 * 2];
			int num6 = 0;
			int num7 = 0;
			while (num7 < num2)
			{
				array[num6++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3];
				array[num6++] = _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D[num3] + _0023_003DzQPpxw1Hu0Rft[num3];
				num7++;
				num3++;
			}
			DrawLines(array);
		}
	}

	public override void DrawNormalsPerVertex(Point3D[] vertices, IndexTriangle[] triangles, Vector3D[] normals, double length)
	{
		Point3D[] array = new Point3D[3];
		Vector3D[] array2 = new Vector3D[3];
		for (int i = 0; i < triangles.Length; i++)
		{
			SmoothTriangle smoothTriangle = (SmoothTriangle)triangles[i];
			array[0] = vertices[smoothTriangle.V1];
			array[1] = vertices[smoothTriangle.V2];
			array[2] = vertices[smoothTriangle.V3];
			array2[0] = normals[smoothTriangle.N1] * length;
			array2[1] = normals[smoothTriangle.N2] * length;
			array2[2] = normals[smoothTriangle.N3] * length;
			_0023_003DzI0krhr3o0LGChFWi9Q_003D_003D(array, array2);
		}
	}

	private void _0023_003Dz_0024ZebKH8Z4i0x1lh_0024RSMM0BDxj74i(float[] _0023_003DzdtK6iedptbUWR7yytg_003D_003D)
	{
		int _0023_003DzRbrcOgQ_003D = _0023_003DzdtK6iedptbUWR7yytg_003D_003D.Length / 3;
		_0023_003Dz2CJ_0024wXE_003D(_0023_003DzdtK6iedptbUWR7yytg_003D_003D, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTriangles2D(Point2D[] vertices)
	{
		_0023_003Dz_0024ZebKH8Z4i0x1lh_0024RSMM0BDxj74i(_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzXjTP_YwBygkIQCv1bg_003D_003D(vertices));
	}

	public override void DrawTriangles2D(float[] vertices)
	{
		float[] array = new float[3 * vertices.Length / 2];
		int num = 0;
		int num2 = 0;
		while (num2 < vertices.Length)
		{
			array[num++] = vertices[num2++];
			array[num++] = vertices[num2++];
			array[num++] = 0f;
		}
		_0023_003Dz_0024ZebKH8Z4i0x1lh_0024RSMM0BDxj74i(array);
	}

	public override void DrawTrianglesFan2D(float[] vertices)
	{
		int num = 3 * (vertices.Length / 2 - 2);
		float[] array = new float[3 * num];
		int num2 = 0;
		int num3 = 2;
		while (num3 < vertices.Length - 2)
		{
			array[num2++] = vertices[0];
			array[num2++] = vertices[1];
			array[num2++] = 0f;
			array[num2++] = vertices[num3++];
			array[num2++] = vertices[num3++];
			array[num2++] = 0f;
			array[num2++] = vertices[num3];
			array[num2++] = vertices[num3 + 1];
			array[num2++] = 0f;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.TriangleList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTrianglesFan(Point3D[] vertices, Vector3D normal)
	{
		int num = 3 * (vertices.Length - 2);
		float[] array = new float[3 * num];
		int num2 = 0;
		int num3 = 1;
		while (num3 < vertices.Length - 1)
		{
			array[num2++] = (float)vertices[0].X;
			array[num2++] = (float)vertices[0].Y;
			array[num2++] = (float)vertices[0].Z;
			array[num2++] = (float)vertices[num3].X;
			array[num2++] = (float)vertices[num3].Y;
			array[num2++] = (float)vertices[num3].Z;
			array[num2++] = (float)vertices[++num3].X;
			array[num2++] = (float)vertices[num3].Y;
			array[num2++] = (float)vertices[num3].Z;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.TriangleList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTriangles(Point3D[] vertices)
	{
		int num = vertices.Length;
		float[] _0023_003Dzt5jpbHs_003D = new float[3 * num];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < vertices.Length; i++)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, vertices[i], ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTriangles(Point3D[] vertices, Vector3D normal)
	{
		int num = vertices.Length;
		float[] _0023_003Dzt5jpbHs_003D = new float[6 * num];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < vertices.Length; i++)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, vertices[i], ref _0023_003DzPH_0024hvqk_003D);
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, normal, ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTrianglesPartialWithMaterialColor(Point3D[] vertices, Vector3D[] normals, bool addToCurrentBufferPart = false)
	{
		int num = vertices.Length;
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] _0023_003Dzt5jpbHs_003D = new float[10 * num];
		for (int i = 0; i < vertices.Length; i += 3)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[i], vertices[i + 1], vertices[i + 2], normals[i], normals[i + 1], normals[i + 2], base.CurrentMaterial.Diffuse, base.CurrentMaterial.Diffuse, base.CurrentMaterial.Diffuse, ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz8UwOt6tpkImF(_0023_003DzxbCbL_0024mWtybX, _0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, addToCurrentBufferPart, _0023_003Dz9Yc_0024ROw_003D: false, shaderType.None);
	}

	public override void DrawTrianglesPartialWithTexture(Point3D[] vertices, Vector3D[] normals, PointF[] texCoords, bool addToCurrentBufferPart = false)
	{
		int num = vertices.Length;
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] _0023_003Dzt5jpbHs_003D = new float[8 * num];
		for (int i = 0; i < vertices.Length; i += 3)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[i], vertices[i + 1], vertices[i + 2], normals[i], normals[i + 1], normals[i + 2], texCoords[i], texCoords[i + 1], texCoords[i + 2], ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz8UwOt6tpkImF(_0023_003DzxbCbL_0024mWtybX, _0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, addToCurrentBufferPart, _0023_003Dz9Yc_0024ROw_003D: false, shaderType.None);
	}

	public override void DrawTriangles(Point3D[] vertices, Vector3D[] normals, IndexTriangle[] triangles, PointF[] texCoords)
	{
		int num = triangles.Length * 3;
		float[] _0023_003Dzt5jpbHs_003D;
		if (texCoords != null)
		{
			_0023_003Dzt5jpbHs_003D = new float[num * 8];
			int _0023_003DzPH_0024hvqk_003D = 0;
			for (int i = 0; i < triangles.Length; i++)
			{
				SmoothTriangle smoothTriangle = (SmoothTriangle)triangles[i];
				_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[smoothTriangle.V1], vertices[smoothTriangle.V2], vertices[smoothTriangle.V3], normals[smoothTriangle.N1], normals[smoothTriangle.N2], normals[smoothTriangle.N3], texCoords[smoothTriangle.V1], texCoords[smoothTriangle.V2], texCoords[smoothTriangle.V3], ref _0023_003DzPH_0024hvqk_003D);
			}
		}
		else
		{
			_0023_003Dzt5jpbHs_003D = new float[triangles.Length * 18];
			int _0023_003DzPH_0024hvqk_003D2 = 0;
			for (int j = 0; j < triangles.Length; j++)
			{
				SmoothTriangle smoothTriangle2 = (SmoothTriangle)triangles[j];
				_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[smoothTriangle2.V1], vertices[smoothTriangle2.V2], vertices[smoothTriangle2.V3], normals[smoothTriangle2.N1], normals[smoothTriangle2.N2], normals[smoothTriangle2.N3], ref _0023_003DzPH_0024hvqk_003D2);
			}
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawTriangles(Point3D[] vertices, Vector3D[] normals, PointF[] texCoords = null, bool addToCurrentBufferPart = false)
	{
		int num = vertices.Length;
		int _0023_003DzPH_0024hvqk_003D = 0;
		float[] _0023_003Dzt5jpbHs_003D;
		if (texCoords == null)
		{
			_0023_003Dzt5jpbHs_003D = new float[6 * num];
			for (int i = 0; i < vertices.Length; i += 3)
			{
				_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[i], vertices[i + 1], vertices[i + 2], normals[i], normals[i + 1], normals[i + 2], ref _0023_003DzPH_0024hvqk_003D);
			}
		}
		else
		{
			_0023_003Dzt5jpbHs_003D = new float[10 * num];
			for (int j = 0; j < vertices.Length; j += 3)
			{
				_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[j], vertices[j + 1], vertices[j + 2], normals[j], normals[j + 1], normals[j + 2], texCoords[j], texCoords[j + 1], texCoords[j + 2], ref _0023_003DzPH_0024hvqk_003D);
			}
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, addToCurrentBufferPart);
	}

	public override void DrawTriangles(Point3D[] vertices, Vector3D[] normals, float[] texCoords, bool addToCurrentBufferPart = false)
	{
		int num = vertices.Length;
		float[] _0023_003Dzt5jpbHs_003D = new float[num * 7];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < vertices.Length; i += 3)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[i], vertices[i + 1], vertices[i + 2], normals[i], normals[i + 1], normals[i + 2], texCoords[i], texCoords[i + 1], texCoords[i + 2], ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, addToCurrentBufferPart);
	}

	public override void DrawTriangles(Point3D[] vertices, Vector3D[] normals, System.Drawing.Color[] colors, bool addToCurrentBufferPart = false)
	{
		int num = vertices.Length;
		float[] _0023_003Dzt5jpbHs_003D = new float[num * 10];
		int _0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i < vertices.Length; i += 3)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzlWsFipPY6pyL(_0023_003Dzt5jpbHs_003D, vertices[i], vertices[i + 1], vertices[i + 2], normals[i], normals[i + 1], normals[i + 2], colors[i], colors[i + 1], colors[i + 2], ref _0023_003DzPH_0024hvqk_003D);
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.TriangleList, num, addToCurrentBufferPart);
	}

	public override void DrawTrianglesPlanar(Point3D[] vertices, IndexTriangle[] triangles, Vector3D normal)
	{
		DrawTrianglesPlanar(vertices, RenderContextBase.GetIndicesFromTriangles(triangles), normal);
	}

	public override void DrawTrianglesPlanar(Point3D[] vertices, int[] trianglesIndices, Vector3D normal)
	{
		float[] array = new float[vertices.Length * 2 * 3];
		int _0023_003DzPH_0024hvqk_003D = 0;
		int num = 0;
		while (num < vertices.Length)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(array, vertices[num++], ref _0023_003DzPH_0024hvqk_003D);
			array[_0023_003DzPH_0024hvqk_003D++] = (float)normal.X;
			array[_0023_003DzPH_0024hvqk_003D++] = (float)normal.Y;
			array[_0023_003DzPH_0024hvqk_003D++] = (float)normal.Z;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, trianglesIndices, primitiveType.TriangleList, vertices.Length, (trianglesIndices != null) ? trianglesIndices.Length : 0);
	}

	public override void DrawQuads2D(float[] vertices)
	{
		int num = vertices.Length / 2;
		float[] array = new float[3 * num];
		int[] array2 = new int[num / 4 * 6];
		int num2 = 0;
		int num3 = 0;
		while (num2 < vertices.Length)
		{
			array[num3++] = vertices[num2++];
			array[num3++] = vertices[num2++];
			array[num3++] = 0f;
		}
		int i = 0;
		int num4 = 0;
		for (; i < num; i += 4)
		{
			array2[num4++] = i;
			array2[num4++] = i + 1;
			array2[num4++] = i + 3;
			array2[num4++] = i + 1;
			array2[num4++] = i + 2;
			array2[num4++] = i + 3;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, array2, primitiveType.TriangleList, num, array2.Length);
	}

	public override void DrawQuads(Point3D[] vertices, Vector3D[] normals, int first, int count)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzYD8zfIi355st(vertices, normals, first, count);
		int[] array = new int[count / 4 * 6];
		int num = 0;
		for (int i = 0; i < count; i += 4)
		{
			array[num++] = i;
			array[num++] = i + 1;
			array[num++] = i + 3;
			array[num++] = i + 1;
			array[num++] = i + 2;
			array[num++] = i + 3;
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, array, primitiveType.TriangleList, count, array.Length);
	}

	public override void DrawLines2D(float[] vertices)
	{
		int num = vertices.Length / 2;
		float[] array = new float[3 * num];
		int num2 = 0;
		int num3 = 0;
		while (num3 < vertices.Length)
		{
			array[num2++] = vertices[num3++];
			array[num2++] = vertices[num3++];
			array[num2++] = 0f;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.LineList, num, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLineLoop(Point3D[] vertices, int first, int count)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzWzNzXffH54xGqntNgQ_003D_003D(vertices, first, count, _0023_003DzN_MOKU7jsa0t: true);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineStrip, count + 1, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawLineLoop(Point2D[] vertices, int first, int count)
	{
		float[] _0023_003Dzt5jpbHs_003D = _0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003DzXjTP_YwBygkIQCv1bg_003D_003D(vertices, first, count, _0023_003DzN_MOKU7jsa0t: true);
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, primitiveType.LineStrip, count + 1, _0023_003DzKs6hunzjen4G: false);
	}

	public override void DrawQuadStrip(Point3D[] vertices, Vector3D[] normals, int first, int count)
	{
		int num = count - 2;
		float[] _0023_003Dzt5jpbHs_003D = new float[count * 6];
		int _0023_003DzPH_0024hvqk_003D = first;
		int num2 = first;
		int num3 = 0;
		while (num3 < count)
		{
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, vertices[num2], ref _0023_003DzPH_0024hvqk_003D);
			_0023_003Dzq1pu0EZUcgvUthvVifJ2Hy4_003D._0023_003DzS21u11g_003D()._0023_003Dzh9bwYgk_003D(_0023_003Dzt5jpbHs_003D, normals[num2], ref _0023_003DzPH_0024hvqk_003D);
			num3++;
			num2++;
		}
		int[] array = new int[num * 3];
		int num4 = count - 4;
		_0023_003DzPH_0024hvqk_003D = 0;
		for (int i = 0; i <= num4; i += 2)
		{
			array[_0023_003DzPH_0024hvqk_003D++] = i;
			array[_0023_003DzPH_0024hvqk_003D++] = i + 1;
			array[_0023_003DzPH_0024hvqk_003D++] = i + 2;
			array[_0023_003DzPH_0024hvqk_003D++] = i + 2;
			array[_0023_003DzPH_0024hvqk_003D++] = i + 1;
			array[_0023_003DzPH_0024hvqk_003D++] = i + 3;
		}
		_0023_003Dz2CJ_0024wXE_003D(_0023_003Dzt5jpbHs_003D, array, primitiveType.TriangleList, count, num * 3);
	}

	public override void DrawIndexedTriangles(VBOParamsBase myParams)
	{
		bool flag = myParams is VBOParamsTexture;
		int num = (flag ? 8 : 6);
		int num2 = 0;
		float[] array;
		int _0023_003DzRbrcOgQ_003D;
		if (myParams.indices != null)
		{
			array = new float[myParams.indices.Length * num];
			if (flag)
			{
				for (int i = 0; i < myParams.indices.Length; i++)
				{
					int num3 = myParams.indices[i] * 3;
					int num4 = myParams.indices[i] * 2;
					array[num2++] = myParams.vertices[num3];
					array[num2++] = myParams.vertices[num3 + 1];
					array[num2++] = myParams.vertices[num3 + 2];
					array[num2++] = myParams.normals[num3];
					array[num2++] = myParams.normals[num3 + 1];
					array[num2++] = myParams.normals[num3 + 2];
					VBOParamsTexture vBOParamsTexture = (VBOParamsTexture)myParams;
					array[num2++] = vBOParamsTexture.TextureCoordinates[num4];
					array[num2++] = 1f - vBOParamsTexture.TextureCoordinates[num4 + 1];
				}
			}
			else
			{
				for (int j = 0; j < myParams.indices.Length; j++)
				{
					int num5 = myParams.indices[j] * 3;
					array[num2++] = myParams.vertices[num5];
					array[num2++] = myParams.vertices[num5 + 1];
					array[num2++] = myParams.vertices[num5 + 2];
					array[num2++] = myParams.normals[num5];
					array[num2++] = myParams.normals[num5 + 1];
					array[num2++] = myParams.normals[num5 + 2];
				}
			}
			_0023_003DzRbrcOgQ_003D = myParams.indices.Length;
		}
		else
		{
			array = new float[myParams.vertices.Length * num];
			for (int k = 0; k < myParams.vertices.Length; k += 3)
			{
				array[num2++] = myParams.vertices[k];
				array[num2++] = myParams.vertices[k + 1];
				array[num2++] = myParams.vertices[k + 2];
				array[num2++] = myParams.normals[k];
				array[num2++] = myParams.normals[k + 1];
				array[num2++] = myParams.normals[k + 2];
			}
			_0023_003DzRbrcOgQ_003D = myParams.vertices.Length / 3;
		}
		_0023_003Dz2CJ_0024wXE_003D(array, primitiveType.TriangleList, _0023_003DzRbrcOgQ_003D, _0023_003DzKs6hunzjen4G: false);
	}

	private void _0023_003DzW5PWAngs9S9h(_0023_003DzxMfii5FvRHCf7KMoYW35TB7JQjEk _0023_003DzSVpkYxU_003D, bool _0023_003Dz9Yc_0024ROw_003D, shaderType _0023_003DzqP_0024Pj_0_003D)
	{
		if (_0023_003DzSVpkYxU_003D._0023_003Dz6ym_OKwKktrt.Count > 0 && _0023_003DzSVpkYxU_003D._0023_003Dz6ym_OKwKktrt[0].Count > 0)
		{
			if (_0023_003Dz9Yc_0024ROw_003D)
			{
				PushRasterizerState();
				PushShader();
				SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_NoPolygonOffset);
				SetShader(_0023_003DzqP_0024Pj_0_003D);
			}
			_0023_003DzSVpkYxU_003D._0023_003DzhzizObU_003D();
			_0023_003DzSVpkYxU_003D.Draw(this);
			if (_0023_003Dz9Yc_0024ROw_003D)
			{
				PopRasterizerState();
				PopShader();
			}
		}
	}

	public override void DrawCurrentBuffer()
	{
		_0023_003DzW5PWAngs9S9h(_0023_003DzxbCbL_0024mWtybX, _0023_003Dz9Yc_0024ROw_003D: false, shaderType.None);
	}

	public override void EndDrawBufferedLines()
	{
		gl.Enable(34370);
		_0023_003DzW5PWAngs9S9h(_0023_003DzrHA4OiNdy_002485dlJi6g_003D_003D, _0023_003Dz9Yc_0024ROw_003D: true, shaderType.MultiColorNoLightsThickPointsPerVertex);
		_0023_003DzW5PWAngs9S9h(_0023_003DzBwwM1oE5VAZch0PqXQ_003D_003D, !lineStipple, shaderType.MultiColorNoLightsThickLinesPerVertex);
		gl.Disable(34370);
	}

	protected override void evaluateShadersHqr()
	{
		base.ControlData.ShadersHqrMainSwitch &= RendererVersion.Major > _0023_003DzdkLBX8sX9mQG.Major || (RendererVersion.Major == _0023_003DzdkLBX8sX9mQG.Major && RendererVersion.Minor >= _0023_003DzdkLBX8sX9mQG.Minor);
	}

	protected internal override IEnvironment CreateEnvironment(byte[] image)
	{
		return new OGLEnvironment(image);
	}

	protected internal override IEnvironment CreateEnvironment(Image image)
	{
		return new OGLEnvironment(image);
	}

	public override void CheckErrorDEBUG(string s)
	{
		gl.GetError();
	}

	protected override void SetVendorName()
	{
		SetVendorName(OpenglVendor);
	}

	public override bool IsGraphicsError()
	{
		return gl.GetError() != 0;
	}

	public override bool CheckOutOfMemory()
	{
		int error = gl.GetError();
		if (error == 1285)
		{
			RenderContextBase.GraphicalIssues.Append(GetErrorString(error));
			return true;
		}
		return false;
	}

	public override string GetErrorString(int errorCode)
	{
		return errorCode switch
		{
			1280 => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609582), 
			1281 => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609656), 
			1282 => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609980), 
			1283 => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609795), 
			1284 => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348609886), 
			1285 => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607127), 
			1286 => _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607207), 
			_ => string.Empty, 
		};
	}

	public override bool IsValid()
	{
		if (hdc != IntPtr.Zero)
		{
			return hrc != IntPtr.Zero;
		}
		return false;
	}

	public override void EndDraw(bool swapBuffer)
	{
		if (swapBuffer)
		{
			SwapBuffers();
		}
		else
		{
			gl.Flush();
		}
	}

	public override void MakeCurrent()
	{
		if (wgl.GetCurrentContext() != hrc)
		{
			wgl.MakeCurrent(hdc, hrc);
		}
	}

	public override void SwapBuffers()
	{
		OpenGL.Windows.SwapBuffers(hdc);
	}

	public override void Dispose()
	{
		base.Dispose();
		if (_0023_003DzQapBRGvgfbOm != null)
		{
			_0023_003DzQapBRGvgfbOm._0023_003DzHF353qc_003D(this);
			_0023_003DzQapBRGvgfbOm = null;
		}
		_0023_003DzxbCbL_0024mWtybX.Dispose();
		_0023_003DzrHA4OiNdy_002485dlJi6g_003D_003D.Dispose();
		_0023_003DzBwwM1oE5VAZch0PqXQ_003D_003D.Dispose();
		_0023_003DzxbCbL_0024mWtybX = null;
		_0023_003DzrHA4OiNdy_002485dlJi6g_003D_003D = null;
		_0023_003DzBwwM1oE5VAZch0PqXQ_003D_003D = null;
		wgl.MakeCurrent(hdc, IntPtr.Zero);
		if (hrc != IntPtr.Zero)
		{
			wgl.DeleteContext(hrc);
		}
		if (hdc != IntPtr.Zero)
		{
			OpenGL.Windows.ReleaseDC(wnd, hdc);
		}
		hrc = IntPtr.Zero;
		hdc = IntPtr.Zero;
	}

	protected internal override void DisposeBorderTextures()
	{
		if (_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D != null)
		{
			for (int i = 0; i < _0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D.Length; i++)
			{
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[i].Dispose();
				_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D[i] = null;
			}
			_0023_003Dz2j3VnYY7PGgD8uSHUA_003D_003D = null;
		}
	}

	public virtual void OpenglSetup(ControlData data)
	{
		if (RendererVersion.Major == 1)
		{
			throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607008));
		}
		evaluateShadersHqr();
		gl.CullFace(1029);
		base.FrontFaceCW = false;
		gl.BlendFunc(770, 771);
		ProcessMaterial();
		SetupPolygonOffset(enable: true);
		shadowMapFBOSize = Math.Min((uint)MaxTextureSize() / 2u, 2048u);
		UpdateUseFBO();
		OGLEntityBuffer._0023_003DzvOg1ehyRaBmw value = new OGLEntityBuffer._0023_003DzvOg1ehyRaBmw(new OGLEntityBuffer._0023_003DzfWJA13KyF5kq(3), new OGLEntityBuffer._0023_003DzfWJA13KyF5kq(4), new OGLEntityBuffer._0023_003DzfWJA13KyF5kq(1));
		_0023_003DzxbCbL_0024mWtybX = new _0023_003DzESauDJ_cJSGvlPERmyIX_0024joPOZg_u__oLw_003D_003D(100000, 50000, null, _0023_003DzvwmFS1TFv_X5: true);
		_0023_003DzrHA4OiNdy_002485dlJi6g_003D_003D = new _0023_003DzESauDJ_cJSGvlPERmyIX_0024joPOZg_u__oLw_003D_003D(100000, 0, value, _0023_003DzvwmFS1TFv_X5: false);
		_0023_003DzBwwM1oE5VAZch0PqXQ_003D_003D = new _0023_003DzESauDJ_cJSGvlPERmyIX_0024joPOZg_u__oLw_003D_003D(100000, 0, value, _0023_003DzvwmFS1TFv_X5: false);
		float[] floatv = gl.GetFloatv(33902, 2);
		_0023_003DzDIa0Z4Vh9bSF(floatv[0]);
		_0023_003DzRdx7gppcbW2N(floatv[1]);
	}

	protected override void FreeCaptureTextures()
	{
		base.FreeCaptureTextures();
		if (_0023_003DzU4qslIzzR7vFf7wOMHXtouY_003D != null)
		{
			_0023_003DzU4qslIzzR7vFf7wOMHXtouY_003D._0023_003DzHF353qc_003D(this);
			_0023_003DzU4qslIzzR7vFf7wOMHXtouY_003D = null;
		}
	}

	private bool _0023_003DzRSp4R6tMjxxNtUwVDGlYprA_003D(int _0023_003Dz_oOsYygDA7pEHFbSc1Oong4_003D, bool _0023_003Dz1Vcd30fl9JNi)
	{
		try
		{
			if (_0023_003Dzl12F7uAI9TA2(hdc, _0023_003Dz_oOsYygDA7pEHFbSc1Oong4_003D, base.ControlData, out hrc))
			{
				base.ControlData.isHardwareAccelerated = true;
				if (base.ControlData.askForAntiAliasing && base.ControlData.antialiasingSamples != 0)
				{
					base.ControlData.isFsaaAvailable = true;
				}
				_0023_003DzS9sBW50_003D();
				Logger.Instance.Info(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607063));
				if (_0023_003Dz1Vcd30fl9JNi)
				{
					samplesBuffersARB = gl.GetIntegerv(32936) > 0;
					int integerv = gl.GetIntegerv(32937);
					if (integerv > 0)
					{
						SetRealAntialiasingSamples(integerv);
						base.ControlData.isFsaaAvailable = true;
					}
				}
				return true;
			}
		}
		catch (Exception ex)
		{
			Logger.Instance.Error(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607391) + ex.Message + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620810), null, Array.Empty<object>());
			return false;
		}
		return false;
	}

	private bool _0023_003DzOyNSznFw_00243ceNzEq33SNyLA_003D()
	{
		Logger.Instance.Warn(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607392), null);
		try
		{
			PixelFormatDescriptor pixelFormatDescriptor = new PixelFormatDescriptor();
			int num = OpenGL.Windows.DescribePixelFormat(hdc, 1, pixelFormatDescriptor.Size, pixelFormatDescriptor);
			if (num == 0 && ControlData.IsVirtualMachine())
			{
				num = 1000;
			}
			int num2 = 0;
			for (int i = 1; i <= num; i++)
			{
				OpenGL.Windows.DescribePixelFormat(hdc, i, pixelFormatDescriptor.Size, pixelFormatDescriptor);
				if (_0023_003Dzaad03n712Jsv(pixelFormatDescriptor) == (_0023_003DzAtjnbS4_003D)2 && _0023_003Dz8xgestnrdzQ2(pixelFormatDescriptor) == (_0023_003Dzede4j5s_003D)1 && _0023_003Dz1IyzIEIXed2e(pixelFormatDescriptor) == (_0023_003DzhQQ5Bmw_003D)0 && pixelFormatDescriptor.AlphaBits >= 8 && pixelFormatDescriptor.DepthBits >= 24)
				{
					if (pixelFormatDescriptor.ColorBits >= 24)
					{
						num2 = i;
						break;
					}
					if (pixelFormatDescriptor.ColorBits == 16)
					{
						num2 = i;
						_0023_003DzWPl9SPuPuHiK();
					}
				}
			}
			if (num2 == 0)
			{
				Logger.Instance.Error(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607234), null, Array.Empty<object>());
				return false;
			}
			if (OpenGL.Windows.SetPixelFormat(hdc, num2, pixelFormatDescriptor))
			{
				hrc = wgl.CreateContext(hdc);
				_0023_003DzS9sBW50_003D();
				return true;
			}
		}
		catch (Exception ex)
		{
			Logger.Instance.Error(ex.Message, null, Array.Empty<object>());
		}
		return false;
	}

	public override bool Create()
	{
		base.IsDirect3D = false;
		base.ControlData.isHardwareAccelerated = false;
		base.ControlData.isFsaaAvailable = false;
		if (gl.Handle == IntPtr.Zero)
		{
			gl.Handle = OpenGL.Windows.LoadLibrary(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606610));
		}
		int _0023_003Dz_oOsYygDA7pEHFbSc1Oong4_003D = 0;
		bool flag = false;
		Control control = new Control();
		try
		{
			control.CreateControl();
			IntPtr dC = OpenGL.Windows.GetDC(control.Handle);
			if (!_0023_003Dzl12F7uAI9TA2(dC, 0, base.ControlData, out hrc))
			{
				return false;
			}
			gl.GetString(7936);
			gl.GetString(7937);
			gl.LoadExtensions();
			string openglExtensions = OpenglExtensions;
			flag = _0023_003DzOXLy_002480Tg5GP(new string[3]
			{
				_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606655),
				_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606662),
				_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606700)
			}, openglExtensions);
			_0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650458) }, openglExtensions);
			if (base.ControlData.askForAntiAliasing)
			{
				Logger.Instance.Trace(base.ControlData.InstanceId, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348600257));
				_0023_003Dzby66m9UgwDKne1jXmA_003D_003D _0023_003DztzS0adHdtPmylDnRUA_003D_003D = (_0023_003Dzby66m9UgwDKne1jXmA_003D_003D)gl._0023_003Dzb3sZvEk_003D(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606706), typeof(_0023_003Dzby66m9UgwDKne1jXmA_003D_003D));
				if (flag)
				{
					_0023_003Dz_oOsYygDA7pEHFbSc1Oong4_003D = _0023_003DzGj_LJKTM4WtHs3RdbQ_003D_003D(dC, out var _0023_003Dzeujkxyxl7VBg, _0023_003DztzS0adHdtPmylDnRUA_003D_003D, (int)base.ControlData.antialiasingSamples);
					Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606484), _0023_003Dzeujkxyxl7VBg));
					SetRealAntialiasingSamples(_0023_003Dzeujkxyxl7VBg);
				}
				else if (_0023_003DzOXLy_002480Tg5GP(new string[1] { _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606524) }))
				{
					_0023_003Dz_oOsYygDA7pEHFbSc1Oong4_003D = _0023_003DzluxQCn_0024kGxviJYyfCg_003D_003D(dC, out var _0023_003Dzeujkxyxl7VBg2, _0023_003DztzS0adHdtPmylDnRUA_003D_003D);
					Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606484), _0023_003Dzeujkxyxl7VBg2));
					SetRealAntialiasingSamples(_0023_003Dzeujkxyxl7VBg2);
				}
			}
			wgl.MakeCurrent(dC, IntPtr.Zero);
			if (hrc != IntPtr.Zero)
			{
				wgl.DeleteContext(hrc);
			}
			if (hdc != IntPtr.Zero)
			{
				OpenGL.Windows.ReleaseDC(control.Handle, hdc);
			}
			hrc = IntPtr.Zero;
			hdc = IntPtr.Zero;
		}
		finally
		{
			((IDisposable)control).Dispose();
		}
		if (!base.Create())
		{
			return false;
		}
		if (!_0023_003DzRSp4R6tMjxxNtUwVDGlYprA_003D(_0023_003Dz_oOsYygDA7pEHFbSc1Oong4_003D, flag))
		{
			return _0023_003DzOyNSznFw_00243ceNzEq33SNyLA_003D();
		}
		return true;
	}

	public override void UpdateAntialiasing()
	{
		if (base.ControlData.askForAntiAliasing && base.ControlData.RealAntialiasingSamples > 0 && base.ControlData.AntiAliasing)
		{
			base.ControlData.isFsaaAvailable = true;
		}
		else
		{
			base.ControlData.isFsaaAvailable = false;
		}
		base.UpdateAntialiasing();
	}

	private void _0023_003DzWPl9SPuPuHiK()
	{
		if (ColorsBits16)
		{
			return;
		}
		ColorsBits16 = true;
		RedShift = 11;
		GreenShift = 5;
		BlueShift = 0;
		RedMaxVal = 32;
		BlueMaxVal = 32;
		GreenMaxVal = 64;
		MaxColorVal = 65535;
		if (redBlue16BitDictionary == null)
		{
			redBlue16BitDictionary = new Dictionary<byte, byte>();
			for (byte b = 0; b < redBlue16BppMap.Length; b++)
			{
				redBlue16BitDictionary.Add(redBlue16BppMap[b], b);
			}
			green16BitDictionary = new Dictionary<byte, byte>();
			for (byte b2 = 0; b2 < green16BppMap.Length; b2++)
			{
				green16BitDictionary.Add(green16BppMap[b2], b2);
			}
		}
	}

	private void _0023_003DzS9sBW50_003D()
	{
		MakeCurrent();
		_0023_003Dz_BT7SDwEbLrP = new _0023_003DzVJqNQ4OS99l36SLp1baxMZBCC46E(this);
		gl._0023_003Dz97vvoZugIxL1();
		gl.LoadExtensions();
		gl._0023_003DzQf1vAk0_003D(OpenglExtensions);
		gl._0023_003Dzs4SqNRf4FWbVcf1hLg_003D_003D = _0023_003Dz0ctbe6g_003D.StencilBits;
		SetVendorName();
		globalShadowMapData = new _0023_003Dz3XAtVbL8Q_0024fPexkeqipThta7RDPc();
	}

	internal int _0023_003Dzjdg_0024NvbNJYWQ()
	{
		if (HasFBMultisample())
		{
			return gl.GetIntegerv(36183);
		}
		return 0;
	}

	private bool _0023_003Dzl12F7uAI9TA2(IntPtr _0023_003DzpsiDm1auA8z_0024, int _0023_003Dz3_0024dMBz7RYvT9, ControlData _0023_003Dzt5jpbHs_003D, out IntPtr _0023_003DzBGnJYWewBHJt)
	{
		_0023_003Dz0ctbe6g_003D = new PixelFormatDescriptor();
		_0023_003DzBGnJYWewBHJt = IntPtr.Zero;
		OperatingSystem oSVersion = Environment.OSVersion;
		if (_0023_003Dz3_0024dMBz7RYvT9 == 0)
		{
			_0023_003Dz0ctbe6g_003D.dwFlags = 37;
			if (oSVersion.Version.Major >= 6)
			{
				_0023_003Dz0ctbe6g_003D.dwFlags |= 0x8000;
			}
			_0023_003Dz0ctbe6g_003D.PixelType = 0;
			_0023_003Dz0ctbe6g_003D.ColorBits = 24;
			_0023_003Dz0ctbe6g_003D.AlphaBits = 8;
			_0023_003Dz0ctbe6g_003D.DepthBits = 24;
			_0023_003Dz0ctbe6g_003D.StencilBits = 8;
			_0023_003Dz3_0024dMBz7RYvT9 = OpenGL.Windows.ChoosePixelFormat(_0023_003DzpsiDm1auA8z_0024, _0023_003Dz0ctbe6g_003D);
			if (_0023_003Dz3_0024dMBz7RYvT9 == 0)
			{
				Logger.Instance.Error(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606555), null, Array.Empty<object>());
				return false;
			}
		}
		_0023_003DzBGnJYWewBHJt = IntPtr.Zero;
		bool flag = OpenGL.Windows.SetPixelFormat(_0023_003DzpsiDm1auA8z_0024, _0023_003Dz3_0024dMBz7RYvT9, _0023_003Dz0ctbe6g_003D);
		OpenGL.Windows.DescribePixelFormat(_0023_003DzpsiDm1auA8z_0024, _0023_003Dz3_0024dMBz7RYvT9, _0023_003Dz0ctbe6g_003D.Size, _0023_003Dz0ctbe6g_003D);
		if (_0023_003Dz0ctbe6g_003D.ColorBits < 16)
		{
			Logger.Instance.Error(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348607234), null, Array.Empty<object>());
			return false;
		}
		if (_0023_003Dz0ctbe6g_003D.ColorBits == 16)
		{
			_0023_003DzWPl9SPuPuHiK();
		}
		if (flag)
		{
			try
			{
				IntPtr intPtr = wgl.CreateContext(_0023_003DzpsiDm1auA8z_0024);
				if (wgl.MakeCurrent(_0023_003DzpsiDm1auA8z_0024, intPtr) == 0)
				{
					Logger.Instance.Error(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606578), null, Array.Empty<object>());
					return false;
				}
				if (_0023_003DzuNAJKUl1vaZbZx8YTQ_003D_003D(_0023_003DzpsiDm1auA8z_0024, new string[2]
				{
					_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606884),
					_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606919)
				}))
				{
					int[] attribList = new int[5] { 8337, 3, 8338, 3, 0 };
					wgl.MakeCurrent(IntPtr.Zero, IntPtr.Zero);
					_0023_003DzBGnJYWewBHJt = wgl.CreateContextAttribsARB(_0023_003DzpsiDm1auA8z_0024, IntPtr.Zero, attribList);
					if (wgl.MakeCurrent(_0023_003DzpsiDm1auA8z_0024, _0023_003DzBGnJYWewBHJt) == 0)
					{
						Logger.Instance.Error(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606578), null, Array.Empty<object>());
						return false;
					}
					wgl.DeleteContext(intPtr);
				}
				else
				{
					_0023_003DzBGnJYWewBHJt = intPtr;
				}
			}
			catch (Exception)
			{
				return false;
			}
		}
		return flag;
	}

	private _0023_003DzAtjnbS4_003D _0023_003Dzaad03n712Jsv(PixelFormatDescriptor _0023_003Dz0ctbe6g_003D)
	{
		if ((_0023_003Dz0ctbe6g_003D.dwFlags & 0x40) == 0)
		{
			return (_0023_003DzAtjnbS4_003D)0;
		}
		if ((_0023_003Dz0ctbe6g_003D.dwFlags & 0x1000) == 1)
		{
			return (_0023_003DzAtjnbS4_003D)1;
		}
		return (_0023_003DzAtjnbS4_003D)2;
	}

	private _0023_003Dzede4j5s_003D _0023_003Dz8xgestnrdzQ2(PixelFormatDescriptor _0023_003Dz0ctbe6g_003D)
	{
		if ((_0023_003Dz0ctbe6g_003D.dwFlags & 1) == 1)
		{
			return (_0023_003Dzede4j5s_003D)1;
		}
		return (_0023_003Dzede4j5s_003D)0;
	}

	private _0023_003DzhQQ5Bmw_003D _0023_003Dz1IyzIEIXed2e(PixelFormatDescriptor _0023_003Dz0ctbe6g_003D)
	{
		if (_0023_003Dz0ctbe6g_003D.PixelType == 0)
		{
			return (_0023_003DzhQQ5Bmw_003D)0;
		}
		return (_0023_003DzhQQ5Bmw_003D)1;
	}

	internal bool _0023_003DzuNAJKUl1vaZbZx8YTQ_003D_003D(IntPtr _0023_003DzMUy2r_A_003D, string[] _0023_003DzAprROrfmdRra)
	{
		wgl._0023_003DzT0ja7F4mctzk();
		if (wgl.GetExtensionsStringARB == null)
		{
			return false;
		}
		return _0023_003DzOXLy_002480Tg5GP(_0023_003DzAprROrfmdRra, wgl._0023_003Dz_6Biob8_003D(_0023_003DzMUy2r_A_003D));
	}

	internal bool _0023_003DzOXLy_002480Tg5GP(string[] _0023_003DzAprROrfmdRra)
	{
		string openglExtensions = OpenglExtensions;
		return _0023_003DzOXLy_002480Tg5GP(_0023_003DzAprROrfmdRra, openglExtensions);
	}

	internal static bool _0023_003DzOXLy_002480Tg5GP(string[] _0023_003DzAprROrfmdRra, string _0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D)
	{
		bool flag = false;
		if (_0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D != null)
		{
			string[] array = _0023_003DzAprROrfmdRra;
			foreach (string value in array)
			{
				if (_0023_003Dz5R27O6tttaspwzm_0024bQ_003D_003D.Contains(value))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				StringBuilder stringBuilder = new StringBuilder(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606946));
				stringBuilder.Append(Environment.NewLine);
				array = _0023_003DzAprROrfmdRra;
				foreach (string value2 in array)
				{
					stringBuilder.Append(value2);
					stringBuilder.Append(Environment.NewLine);
				}
				RenderContextBase.graphicalIssues.AppendLine(stringBuilder.ToString());
			}
		}
		return flag;
	}

	private int _0023_003DzluxQCn_0024kGxviJYyfCg_003D_003D(IntPtr _0023_003DzXSc25xvMNAR3, out int _0023_003Dzeujkxyxl7VBg, _0023_003Dzby66m9UgwDKne1jXmA_003D_003D _0023_003DztzS0adHdtPmylDnRUA_003D_003D)
	{
		_0023_003Dzeujkxyxl7VBg = 0;
		_0023_003DzVnoEAB7jWopr[] array = new _0023_003DzVnoEAB7jWopr[4]
		{
			new _0023_003DzVnoEAB7jWopr(4, 8, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606760)),
			new _0023_003DzVnoEAB7jWopr(4, 16, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606778)),
			new _0023_003DzVnoEAB7jWopr(8, 8, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606795)),
			new _0023_003DzVnoEAB7jWopr(8, 16, _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606802))
		};
		int num = array.Length;
		int[] array2 = new int[10] { 8257, 1, 8377, 0, 8258, 0, 8209, 1, 0, 0 };
		for (int num2 = num - 1; num2 >= 0; num2--)
		{
			array2[3] = (_0023_003Dzeujkxyxl7VBg = array[num2]._0023_003DzOHZCD9EcR_Y_0024);
			array2[5] = array[num2]._0023_003DzCH_EN__bg2BX;
			if (_0023_003DztzS0adHdtPmylDnRUA_003D_003D(_0023_003DzXSc25xvMNAR3, array2, null, 1u, out var _0023_003DzRYyuN63nscjj, out var _0023_003DzN8CG41Zh9hjX) && _0023_003DzN8CG41Zh9hjX != 0)
			{
				Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348606840), _0023_003Dzeujkxyxl7VBg));
				return _0023_003DzRYyuN63nscjj;
			}
			Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608157), _0023_003Dzeujkxyxl7VBg));
		}
		return 0;
	}

	private int _0023_003DzGj_LJKTM4WtHs3RdbQ_003D_003D(IntPtr _0023_003DzXSc25xvMNAR3, out int _0023_003Dzeujkxyxl7VBg, _0023_003Dzby66m9UgwDKne1jXmA_003D_003D _0023_003DztzS0adHdtPmylDnRUA_003D_003D, int _0023_003Dz_0024QNZwRWqjkem)
	{
		_0023_003Dzeujkxyxl7VBg = 0;
		for (int i = 0; i < 2; i++)
		{
			int num = ((i == 0) ? 8 : 0);
			int[] obj = new int[20]
			{
				8193, 1, 8209, 1, 8195, 8231, 8212, 24, 8219, 8,
				8226, 24, 8227, 0, 8257, 1, 8258, 0, 0, 0
			};
			obj[13] = num;
			int[] array = obj;
			for (_0023_003Dzeujkxyxl7VBg = _0023_003Dz_0024QNZwRWqjkem; _0023_003Dzeujkxyxl7VBg > 0; _0023_003Dzeujkxyxl7VBg /= 2)
			{
				array[17] = _0023_003Dzeujkxyxl7VBg;
				float[] _0023_003Dzmo3JSaWExAOi = new float[2];
				if (_0023_003DztzS0adHdtPmylDnRUA_003D_003D(_0023_003DzXSc25xvMNAR3, array, _0023_003Dzmo3JSaWExAOi, 1u, out var _0023_003DzRYyuN63nscjj, out var _0023_003DzN8CG41Zh9hjX) && _0023_003DzN8CG41Zh9hjX != 0)
				{
					Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608190), _0023_003Dzeujkxyxl7VBg, (num > 0) ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608231) : _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608213)));
					return _0023_003DzRYyuN63nscjj;
				}
				Logger.Instance.Trace(base.ControlData.InstanceId, string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608252), _0023_003Dzeujkxyxl7VBg, (num > 0) ? _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608231) : _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608213)));
			}
		}
		return 0;
	}

	public override void SetViewport(int[] viewFrame, float depthMin, float depthMax)
	{
		base.SetViewport(viewFrame, depthMin, depthMax);
		_0023_003DzNT32oUkqGeGp._0023_003Dzqi43Drs_003D = new Size(viewFrame[2], viewFrame[3]);
		_0023_003DzLADmvpnYILj0(viewFrame[0], viewFrame[1], viewFrame[2], viewFrame[3], depthMin, depthMax);
	}

	internal override void _0023_003DzLADmvpnYILj0(int _0023_003Dz8GBMuoM_003D, int _0023_003DzJU0R6e0_003D, int _0023_003Dz7PIPnGI_003D, int _0023_003DzkQAiKLA_003D, float _0023_003DzNsXhzVoM2zWs, float _0023_003DztKWOcOeEKDUk)
	{
		gl.Viewport(_0023_003Dz8GBMuoM_003D, _0023_003DzJU0R6e0_003D, _0023_003Dz7PIPnGI_003D, _0023_003DzkQAiKLA_003D);
		gl.DepthRange(_0023_003DzNsXhzVoM2zWs, _0023_003DztKWOcOeEKDUk);
	}

	protected override void SetMatrices(double[] d3dProj, double[] d3dView, double[] d3dModel)
	{
		base.SetMatrices(d3dProj, d3dView, d3dModel);
		double[] array = Utility.MultMatrixd(d3dModel, d3dView);
		double[] _0023_003Dzb7SPTpc_003D = Utility.MultMatrixd(array, d3dProj);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzcU0HDYHnAnzt(Utility.ToFloatArray(_0023_003Dzb7SPTpc_003D));
		_0023_003Dz_BT7SDwEbLrP._0023_003DzhgwyyOSliKf6(Utility.ToFloatArray(array));
		_0023_003Dz_BT7SDwEbLrP._0023_003DzUXELlntdw96H(Utility.ToFloatArray(d3dModel));
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHpX8Tk0_003D(Utility.ToFloatArray(d3dModel));
		_0023_003Dz_BT7SDwEbLrP._0023_003Dzr99J8WM_003D(Utility.ToFloatArray(d3dView));
		_0023_003Dz_BT7SDwEbLrP._0023_003DzUi0j9guDILy7(Utility.ToFloatArray(d3dProj));
	}

	protected override void SetMaterial(float[] diffuseFront, float[] diffuseBack, float[] ambient, float[] specular, float shininess)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHPv8IbL56FXb._0023_003Dz0rG_3k0_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(ambient);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHPv8IbL56FXb._0023_003DzXN4q_0024zeq8iDq = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(diffuseBack);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHPv8IbL56FXb._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(specular);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHPv8IbL56FXb._0023_003DzclDaKJ_Ll_0024Vqb8AclA_003D_003D(shininess);
		_0023_003Dz_BT7SDwEbLrP._0023_003Dz9un3NC_M_JPo._0023_003Dz0rG_3k0_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(ambient);
		_0023_003Dz_BT7SDwEbLrP._0023_003Dz9un3NC_M_JPo._0023_003DzXN4q_0024zeq8iDq = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(diffuseFront);
		_0023_003Dz_BT7SDwEbLrP._0023_003Dz9un3NC_M_JPo._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(specular);
		_0023_003Dz_BT7SDwEbLrP._0023_003Dz9un3NC_M_JPo._0023_003DzclDaKJ_Ll_0024Vqb8AclA_003D_003D(shininess);
	}

	public override void ResetColorDiffuse(float[] diffuse, float[] wireColor)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003Dz9un3NC_M_JPo._0023_003DzXN4q_0024zeq8iDq = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(diffuse);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzAV10KJo_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(wireColor);
	}

	public override void SetLightPosition(int lightIndex, lightType lightType, float[] dir, float[] position)
	{
		double[] matrix = Utility.MultMatrixd(modelMatrices.Peek(), viewMatrices.Peek());
		double[] array = Utility.MultMatrixVecd(matrix, new double[4]
		{
			dir[0],
			dir[1],
			dir[2],
			0.0
		});
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003DzJuJanCE_003D = new Vector3((float)array[0], (float)array[1], (float)array[2]);
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003DzJuJanCE_003D.Normalize();
		if (lightType != lightType.Directional)
		{
			array = Utility.MultMatrixVecd(matrix, new double[4]
			{
				position[0],
				position[1],
				position[2],
				1.0
			});
			_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003DzEsu9Jcc_003D = new Vector3((float)array[0], (float)array[1], (float)array[2]);
		}
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[lightIndex]._0023_003Dz4r_0024mn64_003D = (float)lightType;
	}

	public override void CheckShadersAndLights(Dictionary<shaderType, IShaderTechnique> shaders, realisticShadowQualityType shadowQuality, IBackgroundSettings background)
	{
		_0023_003Dz2dBEwVyowF4OwYU6JxYnG3zEgDcK _0023_003Dz2dBEwVyowF4OwYU6JxYnG3zEgDcK2 = ((shaders == ReflectionShaders) ? ((_0023_003Dz2dBEwVyowF4OwYU6JxYnG3zEgDcK)new _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ(this, base.ActiveLights, shadowQuality, background)) : ((_0023_003Dz2dBEwVyowF4OwYU6JxYnG3zEgDcK)new _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF(this, base.ActiveLights, shadowQuality, background)));
		shaderType[] array = shaders.Keys.ToArray();
		foreach (shaderType shaderType2 in array)
		{
			if (shaders[shaderType2].Shader is _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d2 && _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d2._0023_003Dzu5MWXxPB2Fo8_0024sSweA_003D_003D() != base.ActiveLights.Length)
			{
				shaders[shaderType2] = _0023_003Dz2dBEwVyowF4OwYU6JxYnG3zEgDcK2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType2);
			}
		}
	}

	internal ShaderParameters.LightsData[] _0023_003DzdEhV3KOWoijDidJl_0024w_003D_003D(int[] _0023_003DzQVsx1WI_003D)
	{
		_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D[] _0023_003Dz85RDWW0DIFz = _0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1;
		ShaderParameters.LightsData[] array = new ShaderParameters.LightsData[_0023_003Dz85RDWW0DIFz.Count((_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D _0023_003DzGMK4xyk_003D) => _0023_003DzGMK4xyk_003D._0023_003DzbiPzcTk_003D == 1f)];
		for (int num = 0; num < array.Length; num++)
		{
			_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D _0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2 = _0023_003Dz85RDWW0DIFz[num];
			array[num] = new ShaderParameters.LightsData
			{
				Position = ((_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003Dz4r_0024mn64_003D == 0f) ? new float[4] : new float[4]
				{
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzEsu9Jcc_003D.X,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzEsu9Jcc_003D.Y,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzEsu9Jcc_003D.Z,
					1f
				}),
				Direction = ((_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003Dz4r_0024mn64_003D == 1f) ? new float[4] : new float[4]
				{
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzJuJanCE_003D.X,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzJuJanCE_003D.Y,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzJuJanCE_003D.Z,
					0f
				}),
				Ambient = new float[4]
				{
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003Dz0rG_3k0_003D.X,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003Dz0rG_3k0_003D.Y,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003Dz0rG_3k0_003D.Z,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003Dz0rG_3k0_003D.W
				},
				Diffuse = new float[4]
				{
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzXN4q_0024zeq8iDq.X,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzXN4q_0024zeq8iDq.Y,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzXN4q_0024zeq8iDq.Z,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzXN4q_0024zeq8iDq.W
				},
				Specular = new float[4]
				{
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D.X,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D.Y,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D.Z,
					_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D.W
				},
				ConstantAttenuation = _0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003Dzs91I1MdqldH0pe8iOA_003D_003D.X,
				LinearAttenuation = _0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003Dzs91I1MdqldH0pe8iOA_003D_003D.Y,
				QuadraticAttenuation = _0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003Dzs91I1MdqldH0pe8iOA_003D_003D.Z,
				SpotCosCutoff = ((_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003Dz4r_0024mn64_003D == 1f) ? (-1f) : _0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzGhupw8QIiPQeTSq64g_003D_003D),
				SpotExponent = _0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzObmXzlJIFTmL,
				YieldShadow = (int)Math.Floor(_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzBjT3PLCBXnbL),
				Type = (lightType)_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003Dz4r_0024mn64_003D
			};
			_0023_003DzQVsx1WI_003D[num] = (int)Math.Floor(_0023_003Dz6mzW_00241NZ3Cxm36hMHHBhR_0024w_003D2._0023_003DzbiPzcTk_003D);
		}
		return array;
	}

	internal void _0023_003DzOtaDtEeirNP0(ShaderParameters.ClipPlane[] _0023_003DzpFLDdDs7TwqB, bool[] _0023_003DzSSU_OrNwA8uS)
	{
		for (int i = 0; i < _0023_003DzNT32oUkqGeGp._0023_003Dz1fK2GcGGTTUi.Length; i++)
		{
			_0023_003DzpFLDdDs7TwqB[i] = new ShaderParameters.ClipPlane(_0023_003DzNT32oUkqGeGp._0023_003Dz1fK2GcGGTTUi[i].ToArray());
			_0023_003DzSSU_OrNwA8uS[i] = FlagsHelper.IsSet(_0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C, (ClipPlanesFlags)(1 << i));
		}
	}

	public override void UpdateConstantBufferPerFrame(ShaderParameters data = null)
	{
		if (base.CurrentShaderTechnique != null && data != null)
		{
			if (!(data is _0023_003Dz7yOiDQOqKH5qbW73eaKlOGASXbRj))
			{
				data.AlphaClip = _0023_003DzNT32oUkqGeGp._0023_003Dzemb5TmiWZnwc != 0f;
				data.Lights = _0023_003DzdEhV3KOWoijDidJl_0024w_003D_003D(data.LightsEnabled);
				data.SceneAmbient = new float[4]
				{
					_0023_003DzNT32oUkqGeGp._0023_003DzF97mX6ysdyON.X,
					_0023_003DzNT32oUkqGeGp._0023_003DzF97mX6ysdyON.Y,
					_0023_003DzNT32oUkqGeGp._0023_003DzF97mX6ysdyON.Z,
					_0023_003DzNT32oUkqGeGp._0023_003DzF97mX6ysdyON.W
				};
				_0023_003DzOtaDtEeirNP0(data.ClipPlanes, data.ClipPlanesEnabled);
				ComputeShaderShadowPasses(out var _, out var _);
			}
			base.CurrentShaderTechnique.SetParameters(data);
			data.Lights = null;
			data.SceneAmbient = null;
		}
	}

	public override void UpdateConstantBufferPerObject()
	{
		base.UpdateConstantBufferPerObject();
		base.CurrentShaderTechnique.SetParameters(_0023_003Dz_BT7SDwEbLrP);
	}

	protected override void SetStateInternal(blendStateType state, bool red, bool green, bool blue, bool alpha)
	{
		if (IsBlendEnabled(state))
		{
			gl.Enable(3042);
			gl.BlendFuncSeparate(_0023_003Dzvw1ypI7HcTDU(GetBlendStateSrcFactor(state)), _0023_003Dzvw1ypI7HcTDU(GetBlendStateDstFactor(state)), _0023_003Dzvw1ypI7HcTDU(GetBlendStateSrcAlphaFactor(state)), _0023_003Dzvw1ypI7HcTDU(GetBlendStateDstAlphaFactor(state)));
		}
		else
		{
			gl.Disable(3042);
		}
		gl.ColorMask(red, green, blue, alpha);
	}

	private int _0023_003Dzvw1ypI7HcTDU(blendStateBlendFactorType _0023_003Dz1CEjt3w_003D)
	{
		return _0023_003Dz1CEjt3w_003D switch
		{
			blendStateBlendFactorType.DstColor => 774, 
			blendStateBlendFactorType.One => 1, 
			blendStateBlendFactorType.OneMinusSrcAlpha => 771, 
			blendStateBlendFactorType.SrcAlpha => 770, 
			blendStateBlendFactorType.Zero => 0, 
			blendStateBlendFactorType.InverseDestinationColor => 775, 
			blendStateBlendFactorType.InverseSourceColor => 769, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599598)), 
		};
	}

	protected override void SetStateInternal(depthStencilStateType state)
	{
		if (IsDepthTestEnabled(state))
		{
			gl.Enable(2929);
			gl.DepthFunc(_0023_003Dz8A4Re6fMh9Dg(GetDepthFunc(state)));
		}
		else
		{
			gl.Disable(2929);
		}
		gl.DepthMask(GetDepthMask(state));
		if (IsStencilEnabled(state))
		{
			gl.Enable(2960);
			gl.StencilFunc(_0023_003DzESmT9NtN0NmL(GetStencilFunc(state)), GetStencilFuncRef(state), GetStencilFuncMask(state));
			gl.StencilOp(_0023_003DzuyYi9sNQK5jXAEw9_0024g_003D_003D(GetStencilOpStencilFailAction(state)), _0023_003DzuyYi9sNQK5jXAEw9_0024g_003D_003D(GetStencilOpDepthFailAction(state)), _0023_003DzuyYi9sNQK5jXAEw9_0024g_003D_003D(GetStencilOpStencilDepthPassAction(state)));
		}
		else
		{
			gl.Disable(2960);
		}
	}

	private int _0023_003Dz8A4Re6fMh9Dg(depthFuncType _0023_003DzIooYK_0024E_003D)
	{
		return _0023_003DzIooYK_0024E_003D switch
		{
			depthFuncType.Always => 519, 
			depthFuncType.Equal => 514, 
			depthFuncType.Greater => 516, 
			depthFuncType.Less => 513, 
			depthFuncType.LessEqual => 515, 
			depthFuncType.Never => 512, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599792)), 
		};
	}

	private int _0023_003DzESmT9NtN0NmL(stencilFuncType _0023_003DzIooYK_0024E_003D)
	{
		return _0023_003DzIooYK_0024E_003D switch
		{
			stencilFuncType.Always => 519, 
			stencilFuncType.Equal => 514, 
			stencilFuncType.Never => 512, 
			stencilFuncType.NotEqual => 517, 
			stencilFuncType.Greater => 516, 
			stencilFuncType.GreaterEqual => 518, 
			stencilFuncType.Less => 513, 
			stencilFuncType.LessEqual => 515, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348608047)), 
		};
	}

	private int _0023_003DzuyYi9sNQK5jXAEw9_0024g_003D_003D(stencilOpActionType _0023_003Dz7TNVVt4_003D)
	{
		return _0023_003Dz7TNVVt4_003D switch
		{
			stencilOpActionType.Replace => 7681, 
			stencilOpActionType.Keep => 7680, 
			stencilOpActionType.Invert => 5386, 
			stencilOpActionType.Zero => 0, 
			stencilOpActionType.Increment => 7682, 
			stencilOpActionType.Decrement => 7683, 
			_ => throw new GraphicsException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348599716)), 
		};
	}

	protected override void SetStateInternal(rasterizerStateType state)
	{
		gl.FrontFace(IsCw(state) ? 2304 : 2305);
		gl.PolygonMode(1032, (GetPolygonDrawingType(state) == rasterizerPolygonDrawingType.Fill) ? 6914 : 6913);
		rasterizerCullFaceType cullFace = GetCullFace(state);
		if (cullFace == rasterizerCullFaceType.None)
		{
			gl.Disable(2884);
		}
		else
		{
			gl.Enable(2884);
			gl.CullFace((cullFace == rasterizerCullFaceType.Front) ? 1028 : 1029);
		}
		GetPolygonOffsetValues(state, out var factor, out var units);
		if (factor == 0f && units == 0f)
		{
			gl.Disable(32823);
			return;
		}
		gl.Enable(32823);
		gl.PolygonOffset(units, factor);
	}

	public override void SetupPolygonOffsetForShadow(bool lightPass, bool withWires)
	{
		float factor;
		float units;
		if (withWires)
		{
			if (lightPass)
			{
				factor = _0023_003Dzu_0024_0024UqlQdtWiA8x2BFQ_003D_003D;
				units = _0023_003DzPYLI8KOLTIENhgoLew_003D_003D;
			}
			else
			{
				factor = _0023_003Dz3SvioPUuCfd863V5WA_003D_003D;
				units = _0023_003Dz8QxojClFXuom2svmIQ_003D_003D;
			}
		}
		else if (lightPass)
		{
			factor = _0023_003DzcZYcod8lcyLct_STLw_003D_003D;
			units = _0023_003DzeK873CmRK9u6Vk6RjQ_003D_003D;
		}
		else
		{
			factor = _0023_003Dzcq6GZUW_0024R7CcgJpkqg_003D_003D;
			units = _0023_003DzB47fgd5SFRKVseVZSw_003D_003D;
		}
		gl.PolygonOffset(factor, units);
	}

	public override void ClearDepthStencil(bool depthBuffer, bool stencilBuffer, byte stencilClearValue = 0)
	{
		int num = 0;
		if (depthBuffer)
		{
			num |= 0x100;
		}
		if (stencilBuffer)
		{
			gl.ClearStencil(stencilClearValue);
			num |= 0x400;
		}
		gl.Clear(num);
	}

	public override void ClearColor(System.Drawing.Color color)
	{
		gl.ClearColor((float)(int)color.R / 255f, (float)(int)color.G / 255f, (float)(int)color.B / 255f, (float)(int)color.A / 255f);
		gl.Clear(16384);
	}

	public override TextureBase CreateTexture2D(Image image, textureFilteringFunctionType minFunc = textureFilteringFunctionType.Linear, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool enlargeIfSizeNotSupported = false, bool repeatX = true, bool repeatY = true)
	{
		OGLTexture oGLTexture = null;
		if (image != null)
		{
			oGLTexture = new OGLTexture();
			if (image is Bitmap)
			{
				oGLTexture.Load(this, (Bitmap)image, minFunc, magFunc, anisotropicFiltering, repeatX, repeatY, checkPowerOfTwo: true, enlargeIfSizeNotSupported);
			}
			else
			{
				Bitmap bitmap = new Bitmap(image);
				oGLTexture.Load(this, bitmap, minFunc, magFunc, anisotropicFiltering, repeatX, repeatY, checkPowerOfTwo: true, enlargeIfSizeNotSupported);
				bitmap.Dispose();
			}
		}
		return oGLTexture;
	}

	public override TextureBase CreateTexture2D(Size size, bool depthTexture, textureFilteringFunctionType minFilterFunc = textureFilteringFunctionType.Nearest, textureFilteringFunctionType magFilterFunc = textureFilteringFunctionType.Nearest)
	{
		return new OGLTexture(this, (uint)size.Width, (uint)size.Height, depthTexture, minFilterFunc, magFilterFunc);
	}

	public override TextureBase CreateTexture1D(System.Drawing.Color[] colorTable, textureFilteringFunctionType minFunc = textureFilteringFunctionType.Linear, textureFilteringFunctionType magFunc = textureFilteringFunctionType.Linear, bool anisotropicFiltering = true, bool repeatX = true)
	{
		OGLTexture1D oGLTexture1D = new OGLTexture1D(colorTable);
		oGLTexture1D.Load(this, minFunc, magFunc, anisotropicFiltering, repeatX);
		return oGLTexture1D;
	}

	public override TextureBase CreateTexture2D()
	{
		return new OGLTexture();
	}

	public override int MaxTextureSize()
	{
		return gl.GetIntegerv(3379);
	}

	public override void ReadBuffer(int buffer)
	{
		if (_0023_003DzUEv4S5BpAiMt == null)
		{
			gl.ReadBuffer(buffer);
		}
	}

	public override void ReadSurface(Size controlSize, bool backBuffer, bool antialiasing)
	{
		base.ReadSurface(controlSize, backBuffer, antialiasing);
		ReadBuffer(backBuffer ? 1029 : 1028);
		if (antialiasing)
		{
			int width = Math.Min(_0023_003DzQWJNsDWuroSY.Width, controlSize.Width);
			int height = Math.Min(_0023_003DzQWJNsDWuroSY.Height, controlSize.Height);
			BitmapData bitmapData = _0023_003DzQWJNsDWuroSY.LockBits(new System.Drawing.Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
			gl.ReadPixels(0, 0, width, height, 32992, 5121, bitmapData.Scan0);
			_0023_003DzQWJNsDWuroSY.UnlockBits(bitmapData);
			_0023_003DzQWJNsDWuroSY.RotateFlip(RotateFlipType.Rotate180FlipX);
			return;
		}
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				uint name = ((OGLTexture)texturesForCapture[num++]).Name;
				gl.BindTexture(3553, name);
				gl.CopyTexSubImage2D(3553, 0, 0, 0, texSize.Width * j, texSize.Height * i, texSize.Width, texSize.Height);
			}
		}
	}

	protected internal override bool DepthForPostProcessingAvailable(Size size)
	{
		if (base.DepthForPostProcessingAvailable(size))
		{
			return _0023_003DzU4qslIzzR7vFf7wOMHXtouY_003D != null;
		}
		return false;
	}

	protected override bool DepthForPostProcessingAvailable()
	{
		if (base.DepthForPostProcessingAvailable())
		{
			return _0023_003DzU4qslIzzR7vFf7wOMHXtouY_003D != null;
		}
		return false;
	}

	protected override void InitDepthForPostProcessingInternal(Size size)
	{
		if (HasFBO())
		{
			DepthTextureForPostProcessing?.Dispose();
			DepthTextureForPostProcessing = new OGLTexture(this, (uint)size.Width, (uint)size.Height, _0023_003DzIgi4d_002476Dtqu: true, _0023_003Dz6mcnErFZlQyn: true, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest);
			MaskTextureForPostProcessing?.Dispose();
			MaskTextureForPostProcessing = new OGLTexture(this, (uint)size.Width, (uint)size.Height, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, _0023_003DzMOUqauw_003D: false, _0023_003Dz07HQcxg_003D: false, 33321, 6403, 5121, IntPtr.Zero);
			_0023_003DzU4qslIzzR7vFf7wOMHXtouY_003D = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(this, size.Width, size.Height, _0023_003Dzhpb8QNg_003D: false, _0023_003DzaNkZ4Os_003D: false, _0023_003DzMnQWOgMjrI_0024Z: false, ((OGLTexture)MaskTextureForPostProcessing).Name, ((OGLTexture)DepthTextureForPostProcessing).Name, _0023_003Dz6mcnErFZlQyn: true);
		}
	}

	protected override void DisposeDepthForPostProcessing()
	{
		base.DisposeDepthForPostProcessing();
		_0023_003DzU4qslIzzR7vFf7wOMHXtouY_003D?._0023_003DzHF353qc_003D(this);
		_0023_003DzU4qslIzzR7vFf7wOMHXtouY_003D = null;
		_0023_003DzUEv4S5BpAiMt?._0023_003Dzri_Jxos_003D(this);
	}

	protected internal override void SetDepthForPostProcessingAsCurrentTarget()
	{
		base.SetDepthForPostProcessingAsCurrentTarget();
		if (_0023_003DzU4qslIzzR7vFf7wOMHXtouY_003D != null)
		{
			_0023_003DzQXov33mauSKJ(_0023_003DzU4qslIzzR7vFf7wOMHXtouY_003D);
		}
	}

	public override void PaintBackBuffer(int controlHeight)
	{
		int num = 0;
		for (int i = 0; i < 3; i++)
		{
			int num2 = 0;
			while (num2 < 3)
			{
				DrawQuadWithTextures(texturesForCapture[num], new float[8] { 0f, 0f, 1f, 0f, 1f, 1f, 0f, 1f }, byte.MaxValue, new System.Drawing.RectangleF(num2 * texSize.Width, i * texSize.Height, texSize.Width, texSize.Height), 0f, buffered: false);
				num2++;
				num++;
			}
		}
	}

	protected internal override void CloseTextureInternal(TextureBase.textureUnitType textureUnit, bool force = false)
	{
		SetActiveTexture(textureUnit);
		gl.BindTexture(3552, 0u);
		gl.BindTexture(3553, 0u);
		SetActiveTexture(TextureBase.textureUnitType.Base);
	}

	internal void _0023_003Dz8g_0024GP0H9nWZu(TextureBase.textureUnitType _0023_003Dz6FK5Z_V8Q85h, OGLTextureBase._0023_003DzJAg2NQo_003D _0023_003DzbDYPPoI_003D)
	{
		int num = ((_0023_003DzbDYPPoI_003D == (OGLTextureBase._0023_003DzJAg2NQo_003D)0) ? 3552 : 3553);
		gl.BindTexture(num, 0u);
		gl.Disable(num);
	}

	public override Dictionary<shaderType, IShaderTechnique> CreateShaders(realisticShadowQualityType shadowQuality, LightSettings[] lights)
	{
		Dictionary<shaderType, IShaderTechnique> dictionary = new Dictionary<shaderType, IShaderTechnique>();
		_0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2 = new _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF(this, lights, shadowQuality, null);
		dictionary[shaderType.NoLights] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.NoLights);
		dictionary[shaderType.NoLightsLinesStipple] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.NoLightsLinesStipple);
		dictionary[shaderType.NoLightsThickLinesStipple] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.NoLightsThickLinesStipple);
		dictionary[shaderType.BlendFrozenOverOpaque] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.BlendFrozenOverOpaque);
		dictionary[shaderType.MinDepth] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.MinDepth);
		dictionary[shaderType.DrawActiveOpaque] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.DrawActiveOpaque);
		dictionary[shaderType.Texture2DNoLights] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DNoLights);
		dictionary[shaderType.Texture2DNoLightsWithAlphaMap] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DNoLightsWithAlphaMap);
		dictionary[shaderType.Texture2DNoLightsModulate] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DNoLightsModulate);
		dictionary[shaderType.Texture2DNoLightsModulateWithAlphaMap] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DNoLightsModulateWithAlphaMap);
		dictionary[shaderType.Texture2DNoLightsDecal] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DNoLightsDecal);
		dictionary[shaderType.Texture2DNoLightsDecalWithAlphaMap] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DNoLightsDecalWithAlphaMap);
		dictionary[shaderType.Texture1DNoLights] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture1DNoLights);
		dictionary[shaderType.SingleColorModulatedByIntensity] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.SingleColorModulatedByIntensity);
		dictionary[shaderType.Standard] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Standard);
		dictionary[shaderType.Environment] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Environment);
		dictionary[shaderType.EnvironmentTexture2D] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture2D);
		dictionary[shaderType.EnvironmentTexture2DWithAlphaMap] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture2DWithAlphaMap);
		dictionary[shaderType.Texture2D] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2D);
		dictionary[shaderType.Texture2DWithAlphaMap] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DWithAlphaMap);
		dictionary[shaderType.Texture2DDecal] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DDecal);
		dictionary[shaderType.Texture2DDecalWithAlphaMap] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DDecalWithAlphaMap);
		dictionary[shaderType.MultiColor] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.MultiColor);
		dictionary[shaderType.MultiColorNoLights] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.MultiColorNoLights);
		dictionary[shaderType.MultiColorNoLightsWithNormals] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.MultiColorNoLightsWithNormals);
		dictionary[shaderType.MultiColorNoLightsThickPointsPerVertex] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.MultiColorNoLightsThickPointsPerVertex);
		dictionary[shaderType.MultiColorNoLightsThickLinesPerVertex] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.MultiColorNoLightsThickLinesPerVertex);
		dictionary[shaderType.EnvironmentMulticolor] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentMulticolor);
		dictionary[shaderType.Texture1D] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture1D);
		dictionary[shaderType.EnvironmentTexture1D] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture1D);
		if (gl.ARB_shadow)
		{
			dictionary[shaderType.StandardShadow] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.StandardShadow);
			dictionary[shaderType.EnvironmentShadow] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentShadow);
			dictionary[shaderType.EnvironmentTexture2DShadow] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture2DShadow);
			dictionary[shaderType.EnvironmentTexture2DShadowWithAlphaMap] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture2DShadowWithAlphaMap);
			dictionary[shaderType.Texture2DShadow] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DShadow);
			dictionary[shaderType.Texture2DShadowWithAlphaMap] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DShadowWithAlphaMap);
			dictionary[shaderType.MultiColorShadow] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.MultiColorShadow);
			dictionary[shaderType.EnvironmentMulticolorShadow] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentMulticolorShadow);
			dictionary[shaderType.Texture1DShadow] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture1DShadow);
			dictionary[shaderType.EnvironmentTexture1DShadow] = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture1DShadow);
		}
		return dictionary;
	}

	public override Dictionary<shaderType, IShaderTechnique> CreateReflectionShaders(realisticShadowQualityType shadowQuality, orientationType orientationMode, IBackgroundSettings background, LightSettings[] lights)
	{
		Dictionary<shaderType, IShaderTechnique> dictionary = new Dictionary<shaderType, IShaderTechnique>();
		_0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2 = new _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ(this, lights, shadowQuality, background);
		dictionary[shaderType.NoLights] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.NoLights);
		dictionary[shaderType.Texture2DNoLights] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DNoLights);
		dictionary[shaderType.Texture2DNoLightsWithAlphaMap] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DNoLightsWithAlphaMap);
		dictionary[shaderType.BlendFrozenOverOpaque] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.BlendFrozenOverOpaque);
		dictionary[shaderType.MinDepth] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.MinDepth);
		dictionary[shaderType.DrawActiveOpaque] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.DrawActiveOpaque);
		dictionary[shaderType.Texture1DNoLights] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture1DNoLights);
		dictionary[shaderType.SingleColorModulatedByIntensity] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.SingleColorModulatedByIntensity);
		dictionary[shaderType.Standard] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Standard);
		dictionary[shaderType.Environment] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Environment);
		dictionary[shaderType.EnvironmentTexture2D] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture2D);
		dictionary[shaderType.EnvironmentTexture2DWithAlphaMap] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture2DWithAlphaMap);
		dictionary[shaderType.Texture2D] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2D);
		dictionary[shaderType.Texture2DWithAlphaMap] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DWithAlphaMap);
		dictionary[shaderType.MultiColor] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.MultiColor);
		dictionary[shaderType.EnvironmentMulticolor] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentMulticolor);
		dictionary[shaderType.Texture1D] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture1D);
		dictionary[shaderType.EnvironmentTexture1D] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture1D);
		if (gl.ARB_shadow)
		{
			dictionary[shaderType.StandardShadow] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.StandardShadow);
			dictionary[shaderType.EnvironmentShadow] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentShadow);
			dictionary[shaderType.EnvironmentTexture2DShadow] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture2DShadow);
			dictionary[shaderType.EnvironmentTexture2DShadowWithAlphaMap] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture2DShadowWithAlphaMap);
			dictionary[shaderType.Texture2DShadow] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DShadow);
			dictionary[shaderType.Texture2DShadowWithAlphaMap] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture2DShadowWithAlphaMap);
			dictionary[shaderType.MultiColorShadow] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.MultiColorShadow);
			dictionary[shaderType.EnvironmentMulticolorShadow] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentMulticolorShadow);
			dictionary[shaderType.Texture1DShadow] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.Texture1DShadow);
			dictionary[shaderType.EnvironmentTexture1DShadow] = _0023_003DzjY1J7ZUgxyQD2XS29lDO6QxV9uIJ2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.EnvironmentTexture1DShadow);
		}
		return dictionary;
	}

	public override byte[] ReadDepthBuffer(System.Drawing.Rectangle rect, out int stride, out int bpp)
	{
		Bitmap _0023_003Dza0pUM94_003D = null;
		_0023_003DzYDHFZIvmSA1e(rect.Size, ref _0023_003Dza0pUM94_003D, out var _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D);
		short[] array = ReadDepthValues(0, 0, rect.Size);
		bpp = 3;
		stride = _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D * bpp;
		byte[] array2 = new byte[stride * rect.Height];
		double num = 0.007782219916379284;
		for (int i = 0; i < rect.Height; i++)
		{
			int num2 = (rect.Y + i) * _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D + rect.X;
			int num3 = array2.Length - stride * (i + 1);
			for (int j = 0; j < _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D; j++)
			{
				double num4 = num * (double)array[num2];
				array2[num3++] = (byte)num4;
				array2[num3++] = (byte)num4;
				array2[num3++] = (byte)num4;
				num2++;
			}
		}
		EndReadDepthValues();
		_0023_003Dza0pUM94_003D.Dispose();
		return array2;
	}

	public override byte[] ReadColorBuffer(IViewport viewport, System.Drawing.Rectangle rect, out int stride, out int bpp)
	{
		PixelFormat format = PixelFormat.Format24bppRgb;
		devDept.Eyeshot.Control.Viewport obj = (devDept.Eyeshot.Control.Viewport)viewport;
		System.Drawing.Point leftBottomCameraScreen = obj.ViewportToCameraScreen(obj.ScreenToViewport(rect.Location));
		leftBottomCameraScreen.Y -= rect.Height;
		Bitmap bitmap = new Bitmap(rect.Width, rect.Height, format);
		BitmapData bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, rect.Width, rect.Height), ImageLockMode.ReadOnly, format);
		if (gl.EXT_framebuffer_object && _0023_003DzQapBRGvgfbOm != null)
		{
			_0023_003DzQapBRGvgfbOm._0023_003Dzri_Jxos_003D(this);
		}
		byte[] result = ReadRgbValues(leftBottomCameraScreen, rect.Size, bitmapData);
		if (gl.EXT_framebuffer_object)
		{
			_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003DzluJsUwU_003D(this);
		}
		stride = bitmapData.Stride;
		bpp = 3;
		bitmap.UnlockBits(bitmapData);
		bitmap.Dispose();
		return result;
	}

	public override byte[] ReadRgbValues(System.Drawing.Point leftBottomCameraScreen, Size size, BitmapData data)
	{
		int width = data.Stride / 3;
		ReadBuffer(1029);
		gl.ReadPixels(leftBottomCameraScreen.X, leftBottomCameraScreen.Y, width, size.Height, 6407, 5121, data.Scan0);
		IntPtr scan = data.Scan0;
		int num = data.Stride * data.Height;
		byte[] array = new byte[num];
		Marshal.Copy(scan, array, 0, num);
		return array;
	}

	protected override void SetRGB(byte r, byte g, byte b)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzAV10KJo_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D((float)(int)r / 255f, (float)(int)g / 255f, (float)(int)b / 255f);
	}

	protected override void SetRGBA(byte r, byte g, byte b, byte a)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzAV10KJo_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D((float)(int)r / 255f, (float)(int)g / 255f, (float)(int)b / 255f, (float)(int)a / 255f);
	}

	protected override void SetRGBA(float[] rgba)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzAV10KJo_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(rgba);
	}

	protected override void SetMaterialFrontDiffuse(float[] color)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003Dz9un3NC_M_JPo._0023_003DzXN4q_0024zeq8iDq = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(color);
	}

	protected override void SetMaterialBackDiffuse(float[] color)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHPv8IbL56FXb._0023_003DzXN4q_0024zeq8iDq = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(color);
	}

	protected override void SetMaterialFrontAmbient(float[] color)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003Dz9un3NC_M_JPo._0023_003Dz0rG_3k0_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(color);
	}

	protected override void SetMaterialBackAmbient(float[] color)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHPv8IbL56FXb._0023_003Dz0rG_3k0_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(color);
	}

	public override Bitmap GetBitmapFromTexture(TextureBase texture)
	{
		Bitmap bitmap = new Bitmap(texture.Size.Width, texture.Size.Height, PixelFormat.Format32bppArgb);
		BitmapData bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, texture.Size.Width, texture.Size.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
		SetTexture(texture);
		gl.GetTexImage(3553, 0, 6408, 5121, bitmapData.Scan0);
		CloseTexture();
		bitmap.UnlockBits(bitmapData);
		bitmap.RotateFlip(RotateFlipType.Rotate180FlipX);
		return bitmap;
	}

	protected override short[] ReadDepthValuesInternal(int[] layoutViewport)
	{
		return ReadDepthValues(size: new Size(layoutViewport[2], layoutViewport[3]), left: layoutViewport[0], bottom: layoutViewport[1]);
	}

	public override short[] ReadDepthValues(int left, int bottom, Size size)
	{
		return ReadDepthValues(left, bottom, size, _0023_003DzhOAh7hEbv3BK.Scan0, _0023_003DzhOAh7hEbv3BK.Stride);
	}

	protected internal short[] ReadDepthValues(int left, int bottom, Size size, IntPtr dest, int strideInByte = 0)
	{
		int num = 2;
		int num2 = strideInByte / num;
		gl.ReadPixels(left, bottom, num2, size.Height, 6402, 5122, dest);
		short[] array = new short[num2 * size.Height];
		Marshal.Copy(dest, array, 0, num2 * size.Height);
		short[] array2 = new short[array.Length];
		Buffer.BlockCopy(array, 0, array2, 0, array.Length * num);
		return array2;
	}

	public override void BeginReadDepthValues(Size size, out int strideInPixels)
	{
		base.BeginReadDepthValues(size, out strideInPixels);
		_0023_003Dz0aYfsxa60DMn = true;
	}

	public override void EndReadDepthValues()
	{
		_0023_003DzCKW_0024S_0024sr38Ji.UnlockBits(_0023_003DzhOAh7hEbv3BK);
		if (_0023_003Dz0aYfsxa60DMn)
		{
			_0023_003DzCKW_0024S_0024sr38Ji.Dispose();
			_0023_003Dz0aYfsxa60DMn = false;
		}
		_0023_003DzCKW_0024S_0024sr38Ji = null;
	}

	internal override void _0023_003DzYDHFZIvmSA1e(Size _0023_003Dz0ERMHbg_003D, ref Bitmap _0023_003Dza0pUM94_003D, out int _0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D)
	{
		if (_0023_003Dza0pUM94_003D == null || _0023_003Dza0pUM94_003D.Size != _0023_003Dz0ERMHbg_003D)
		{
			if (_0023_003Dza0pUM94_003D != null)
			{
				_0023_003Dza0pUM94_003D.Dispose();
			}
			_0023_003Dza0pUM94_003D = new Bitmap(_0023_003Dz0ERMHbg_003D.Width, _0023_003Dz0ERMHbg_003D.Height, PixelFormat.Format16bppGrayScale);
		}
		_0023_003DzCKW_0024S_0024sr38Ji = _0023_003Dza0pUM94_003D;
		_0023_003DzhOAh7hEbv3BK = _0023_003DzCKW_0024S_0024sr38Ji.LockBits(new System.Drawing.Rectangle(0, 0, _0023_003Dza0pUM94_003D.Width, _0023_003Dza0pUM94_003D.Height), ImageLockMode.ReadOnly, _0023_003Dza0pUM94_003D.PixelFormat);
		_0023_003Dzfe_rEc7ODhsk5Mp5hA_003D_003D = _0023_003DzhOAh7hEbv3BK.Stride / 2;
	}

	protected override void ResolveShaderType(ref shaderType type)
	{
		switch (type)
		{
		case shaderType.MultiColorSelected:
			type = shaderType.MultiColor;
			break;
		case shaderType.NoLightsThickLines:
			type = shaderType.NoLights;
			break;
		case shaderType.NoLightsThickPoints:
			type = shaderType.NoLights;
			break;
		case shaderType.SingleColorModulatedByIntensityThickLines:
		case shaderType.SingleColorModulatedByIntensityThickPoints:
			type = shaderType.SingleColorModulatedByIntensity;
			break;
		case shaderType.MultiColorNoLightsThickLines:
		case shaderType.MultiColorNoLightsThickPoints:
			type = shaderType.MultiColorNoLights;
			break;
		case shaderType.Texture2DNoLightsDepth:
			type = shaderType.Texture2DNoLights;
			break;
		}
	}

	public override void DisableClipPlanes()
	{
		gl.Disable(12288);
		gl.Disable(12289);
		gl.Disable(12290);
		gl.Disable(12291);
		gl.Disable(12292);
		gl.Disable(12293);
	}

	public override void ProcessClippingPlanes(ClippingPlaneBase[] clippingPlanes, bool updateGraphics = false)
	{
		base.ProcessClippingPlanes(clippingPlanes);
		double[] m = Utility.MultMatrixd(modelMatrices.Peek(), viewMatrices.Peek());
		Transformation transformation = new Transformation(m, byRow: false);
		transformation.Invert();
		transformation.Transpose();
		m = transformation.MatrixAsVectorByColumn;
		for (int i = 0; i < clippingPlanes.Length; i++)
		{
			FlagsHelper.SetUnset(ref _0023_003DzNT32oUkqGeGp._0023_003DzUqa5ZahBwV4C, (ClipPlanesFlags)(1 << i), clippingPlanes[i].Active);
			if (clippingPlanes[i].Active)
			{
				gl.Enable(12288 + i);
				double[] array = Utility.MultMatrixVecd(m, clippingPlanes[i].Coefficients());
				_0023_003DzNT32oUkqGeGp._0023_003Dz1fK2GcGGTTUi[i] = new Vector4((float)array[0], (float)array[1], (float)array[2], (float)array[3]);
			}
			else
			{
				gl.Disable(12288 + i);
			}
		}
		_0023_003DzgFZ7ZEQcfR_7(clippingPlanes);
	}

	public override void ProcessClippingPlanesVisibility(ClippingPlaneBase[] clippingPlanes, bool updateGraphics = false)
	{
		base.ProcessClippingPlanesVisibility(clippingPlanes, updateGraphics);
		for (int i = 0; i < clippingPlanes.Length; i++)
		{
			if (clippingPlanes[i].Active)
			{
				gl.Enable(12288 + i);
			}
			else
			{
				gl.Disable(12288 + i);
			}
		}
		_0023_003DzgFZ7ZEQcfR_7(clippingPlanes);
	}

	private void _0023_003DzgFZ7ZEQcfR_7(ClippingPlaneBase[] _0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D)
	{
		if (base.CurrentShaderTechnique.Shader is _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d _0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d2)
		{
			ShaderParameters.ClipPlane[] array = new ShaderParameters.ClipPlane[_0023_003Dz2q5LaPckGMuUYp5ugA_003D_003D.Length];
			bool[] _0023_003DzSSU_OrNwA8uS = new bool[array.Length];
			_0023_003DzOtaDtEeirNP0(array, _0023_003DzSSU_OrNwA8uS);
			_0023_003DzlX2BiP2hnu7v90DpkeqPMBHG_Y_d2._0023_003DzNRz1hLEBqYKA(_0023_003DzSSU_OrNwA8uS, array);
		}
	}

	public override void InitializePreviousColors()
	{
		base.InitializePreviousColors();
		_0023_003Dz_BT7SDwEbLrP._0023_003Dz9un3NC_M_JPo._0023_003DzXN4q_0024zeq8iDq = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(base.CurrentMaterial.Diffuse);
		_0023_003Dz_BT7SDwEbLrP._0023_003Dz9un3NC_M_JPo._0023_003Dz0rG_3k0_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(base.CurrentMaterial.Ambient);
		_0023_003Dz_BT7SDwEbLrP._0023_003Dz9un3NC_M_JPo._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(base.CurrentMaterial.Specular);
		_0023_003Dz_BT7SDwEbLrP._0023_003Dz9un3NC_M_JPo._0023_003DzclDaKJ_Ll_0024Vqb8AclA_003D_003D(base.CurrentMaterial.Shininess * 128f);
		base.CurrentBackMaterial.Ambient = base.CurrentMaterial.Ambient;
		base.CurrentBackMaterial.Diffuse = base.CurrentMaterial.Diffuse;
		base.CurrentBackMaterial.Specular = base.CurrentMaterial.Specular;
		base.CurrentBackMaterial.Shininess = base.CurrentMaterial.Shininess;
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHPv8IbL56FXb._0023_003Dz0rG_3k0_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(base.CurrentBackMaterial.Ambient);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHPv8IbL56FXb._0023_003DzXN4q_0024zeq8iDq = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(base.CurrentBackMaterial.Diffuse);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHPv8IbL56FXb._0023_003DzFExOpyHXYZdN17OpLQ_003D_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(base.CurrentMaterial.Specular);
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHPv8IbL56FXb._0023_003DzclDaKJ_Ll_0024Vqb8AclA_003D_003D(base.CurrentMaterial.Shininess * 128f);
	}

	public override void InitializeCurrentWireColor()
	{
		base.InitializeCurrentWireColor();
		_0023_003Dz_BT7SDwEbLrP._0023_003DzAV10KJo_003D = new _0023_003Dz_0024pADT51T_0024_1ufzbiQmClpZs_003D(base.CurrentWireColor);
	}

	protected override bool EnableShader(shaderType shader, Dictionary<shaderType, IShaderTechnique> shaders)
	{
		if (!base.EnableShader(shader, shaders))
		{
			return false;
		}
		bool num = ((GLShader)shaders[shader].Shader).Enable(this);
		if (num)
		{
			UpdateConstantBufferPerFrame(new _0023_003Dz7yOiDQOqKH5qbW73eaKlOGASXbRj(this));
		}
		return num;
	}

	protected override void CompileInternal(DrawEntityCallBack drawEntityCallBack, object myParams)
	{
		OglEntityGraphicsData oglEntityGraphicsData = (OglEntityGraphicsData)CompilingEntity;
		if (oglEntityGraphicsData._0023_003DzrGVDsYRQZJCT != null)
		{
			oglEntityGraphicsData._0023_003DzrGVDsYRQZJCT.Dispose();
		}
		oglEntityGraphicsData._0023_003DzrGVDsYRQZJCT = _0023_003DzW925NvY8XjsF(myParams);
		drawEntityCallBack(this, myParams);
		oglEntityGraphicsData._0023_003DzrGVDsYRQZJCT._0023_003DzrloDkpQ_003D();
	}

	private OGLEntityBuffer._0023_003DzvOg1ehyRaBmw? _0023_003DzvvIHZFEJAQNt(object _0023_003DzWdU0336Bq925)
	{
		if (_0023_003DzWdU0336Bq925 == null)
		{
			return null;
		}
		if (_0023_003DzWdU0336Bq925 is Mesh.DrawEdgesInternalParams drawEdgesInternalParams)
		{
			if (drawEdgesInternalParams.floatPerSingleVertex == null)
			{
				return null;
			}
			OGLEntityBuffer._0023_003DzfWJA13KyF5kq[] array = new OGLEntityBuffer._0023_003DzfWJA13KyF5kq[drawEdgesInternalParams.floatPerSingleVertex.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = new OGLEntityBuffer._0023_003DzfWJA13KyF5kq(drawEdgesInternalParams.floatPerSingleVertex[i]);
			}
			return new OGLEntityBuffer._0023_003DzvOg1ehyRaBmw(array);
		}
		return null;
	}

	private OGLEntityBuffer _0023_003DzW925NvY8XjsF(object _0023_003DzWdU0336Bq925)
	{
		_0023_003DzedrTcGwlfm64KpQe1A_003D_003D = new OGLEntityBuffer();
		_0023_003DzedrTcGwlfm64KpQe1A_003D_003D._0023_003Dz6ym_OKwKktrt = new List<List<float>>();
		_0023_003DzedrTcGwlfm64KpQe1A_003D_003D._0023_003DzVQdby4Uk73jo52ylew_003D_003D = null;
		_0023_003DzedrTcGwlfm64KpQe1A_003D_003D._0023_003Dz_0024AE2Y_s_003D = _0023_003DzvvIHZFEJAQNt(_0023_003DzWdU0336Bq925);
		return _0023_003DzedrTcGwlfm64KpQe1A_003D_003D;
	}

	private void _0023_003Dzped9ZPq4ahes(float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D, bool _0023_003DzKs6hunzjen4G)
	{
		_0023_003Dzped9ZPq4ahes(_0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, null, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, 0, _0023_003DzKs6hunzjen4G);
	}

	private void _0023_003Dzped9ZPq4ahes(float[] _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, int[] _0023_003Dzdo7ctlc_003D, primitiveType _0023_003DzQZ1JmC0_003D, int _0023_003DzRbrcOgQ_003D, int _0023_003Dz4Im51Qk_003D, bool _0023_003DzKs6hunzjen4G)
	{
		_0023_003DzedrTcGwlfm64KpQe1A_003D_003D._0023_003DzgWaA5Nc_003D(2000000, _0023_003DzBFonvOGXAXJFPBICgQ_003D_003D, _0023_003Dzdo7ctlc_003D, _0023_003DzQZ1JmC0_003D, _0023_003DzRbrcOgQ_003D, _0023_003Dz4Im51Qk_003D, !_0023_003DzKs6hunzjen4G);
	}

	public override void CompileVBO(EntityGraphicsData baseData, DrawEntityCallBack drawEntityCallBack, object vboParams, bool dynamic = false)
	{
		OglEntityGraphicsData oglEntityGraphicsData = (OglEntityGraphicsData)baseData;
		if (oglEntityGraphicsData._0023_003DzrGVDsYRQZJCT != null)
		{
			oglEntityGraphicsData._0023_003DzrGVDsYRQZJCT.Dispose();
		}
		VBOParamsBase vBOParamsBase = (VBOParamsBase)vboParams;
		int nVertices;
		primitiveType topology;
		float[] data = vBOParamsBase.GetData(out nVertices, out topology);
		if (dynamic)
		{
			oglEntityGraphicsData._0023_003DzrGVDsYRQZJCT = new _0023_003DzxMfii5FvRHCf7KMoYW35TB7JQjEk(data, vBOParamsBase.indices, topology, nVertices, null, _0023_003DzvwmFS1TFv_X5: true);
		}
		else
		{
			oglEntityGraphicsData._0023_003DzrGVDsYRQZJCT = new OGLEntityBuffer(2000000, data, vBOParamsBase.indices, topology, nVertices);
		}
	}

	public override void UpdateVBO(EntityGraphicsData baseData, DrawEntityCallBack drawEntityCallBack, object vboParams)
	{
		VBOParamsBase vBOParamsBase = (VBOParamsBase)vboParams;
		int nVertices;
		primitiveType topology;
		float[] data = vBOParamsBase.GetData(out nVertices, out topology);
		((_0023_003DzxMfii5FvRHCf7KMoYW35TB7JQjEk)((OglEntityGraphicsData)baseData)._0023_003DzrGVDsYRQZJCT)._0023_003DzhzizObU_003D(data, 0, data.Length, nVertices, vBOParamsBase.indices, 0, (vBOParamsBase.indices != null) ? vBOParamsBase.indices.Length : 0, topology);
	}

	public void DeleteVBO(int[] vbo)
	{
		if (gl.ARB_vertex_buffer_object)
		{
			gl.DeleteBuffersARB(vbo);
		}
	}

	public override void SetBlockRefTransform(float[] blockRefrenceMatrix)
	{
		if (base.CurrentShaderTechnique != null)
		{
			((GLShader)base.CurrentShaderTechnique.Shader).SetBlockRefTransform(blockRefrenceMatrix);
		}
	}

	protected override void UpdateUseFBO()
	{
		UsingShadowFBO = base.ControlData.useFrameBufferObject && gl.EXT_framebuffer_object;
	}

	[CLSCompliant(false)]
	public static void GenTextureName(ref uint texName, int target = 3553)
	{
		DelTexture(ref texName);
		uint[] array = new uint[1];
		gl.GenTextures(1, array);
		gl.BindTexture(target, array[0]);
		gl.BindTexture(target, 0u);
		texName = array[0];
	}

	[CLSCompliant(false)]
	public static void DelTexture(ref uint texName)
	{
		gl.DeleteTexture(texName);
		texName = 0u;
	}

	protected override void SetPointSizeInternal(float thickness)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzIt9jKuJG8ncE = thickness;
		gl.PointSize(thickness);
	}

	protected override void SetLineSizeInternal(float thickness)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzUTdFkSI_003D = thickness;
		gl.LineWidth(thickness);
	}

	protected override void InitBlurShader(float[] offset, float[] kernelValues, out IShaderTechnique blurHor, out IShaderTechnique blurVert)
	{
		blurHor = (blurVert = null);
		if (ShadingLanguageVersion.Major > 0)
		{
			_0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2 = new _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF(19);
			blurHor = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.BlurHor);
			blurVert = _0023_003DzQZ_5NCoylGygBYEI5ianoSy51sqF2._0023_003DzqZDlZv2vjk3yiaxV23LB_0024NE_003D(shaderType.BlurVert);
			if (blurHor.Compile(this) && blurVert.Compile(this))
			{
				BlurShaderParameters parameters = new BlurShaderParameters(this, offset, kernelValues);
				blurHor.SetParameters(parameters);
				blurVert.SetParameters(parameters);
			}
		}
	}

	public override bool SetShader(shaderType type, ShaderParameters shaderParams = null, bool force = false)
	{
		bool result = base.SetShader(type, shaderParams, force);
		if (type == shaderType.None && Shaders != null)
		{
			GLShader._0023_003DzUgMk_IApQLO4(0u);
			base.CurrentShader = shaderType.None;
		}
		return result;
	}

	public override bool HasStencil()
	{
		return gl._0023_003Dz_sIl5y0_003D();
	}

	protected internal override void BlurTexture(ref TextureBase sharpTexture, ref TextureBase blurredTexture)
	{
		Size size = sharpTexture.Size;
		ReadBuffer(1029);
		SetActiveTexture(TextureBase.textureUnitType.Base);
		SetTexture(sharpTexture);
		gl.CopyTexImage2D(3553u, 0, 32856, 0, 0, size.Width, size.Height, 0);
		PushShader();
		SetShader(shaderType.BlurHor);
		PushMatrices();
		SetMatrices(Camera.myOrtho(this, 0.0, size.Width, 0.0, size.Height, -1.0, 1.0), null);
		DrawQuadWithTextures(sharpTexture, new float[8] { 0f, 0f, 1f, 0f, 1f, 1f, 0f, 1f }, byte.MaxValue, new System.Drawing.RectangleF(0f, 0f, size.Width, size.Height), 0f, buffered: false);
		SetTexture(blurredTexture);
		gl.CopyTexImage2D(3553u, 0, 32856, 0, 0, size.Width, size.Height, 0);
		SetShader(shaderType.BlurVert);
		DrawQuadWithTextures(blurredTexture, new float[8] { 0f, 0f, 1f, 0f, 1f, 1f, 0f, 1f }, byte.MaxValue, new System.Drawing.RectangleF(0f, 0f, size.Width, size.Height), 0f, buffered: false);
		SetTexture(blurredTexture);
		gl.CopyTexImage2D(3553u, 0, 32856, 0, 0, size.Width, size.Height, 0);
		PopShader();
		PopMatrices();
		CloseTexture(force: true);
	}

	public override void DrawOnTextureOrBitmap(TextureBase texture, TextureBase depthTexture, BitmapData bitmapData, int strideInPixels, bool antialiasingAvailable, bool antiAliasing, int antialiasingSamples, int tileWidth, int tileHeight, drawSceneFuncDelegate drawSceneFunc, object drawSceneParams, bool hdwAcceleration, int bpp, bool buildMipmaps = false)
	{
		uint num = ((texture != null) ? ((OGLTexture)texture).Name : 0u);
		bool flag = false;
		int format = ((bpp == 4) ? 32993 : 32992);
		if (gl.EXT_framebuffer_object && hdwAcceleration)
		{
			_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2 = null;
			_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn3;
			int num2;
			if (antialiasingAvailable && antiAliasing)
			{
				_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn3 = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(this, tileWidth, tileHeight, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: false, _0023_003DzMnQWOgMjrI_0024Z: false, num, 0u);
				_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2 = new _0023_003DzHDBC1tj7WAflu_0024SEQGhofaFYE4c6DybLFyKJZUA_470d(this, tileWidth, tileHeight, antialiasingSamples);
				_0023_003DzEix95WtV2JIElmDGjw_003D_003D(_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2);
				num2 = _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2._0023_003Dz0hLnOJ4_003D() | _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn3._0023_003Dz0hLnOJ4_003D();
			}
			else
			{
				_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn3 = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(this, tileWidth, tileHeight, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: true, _0023_003DzMnQWOgMjrI_0024Z: true, num, 0u);
				_0023_003DzEix95WtV2JIElmDGjw_003D_003D(_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn3);
				num2 = _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn3._0023_003Dz0hLnOJ4_003D();
			}
			if (num2 == 36053)
			{
				gl.DrawBuffer(36064);
				drawSceneFunc(drawSceneParams);
				RestoreFBO();
				gl.BindTexture(3553, 0u);
				if (buildMipmaps && gl.GenerateMipmapEXT != null)
				{
					gl.BindTexture(3553, ((OGLTexture)texture).Name);
					gl.GenerateMipmapEXT(3553);
					gl.BindTexture(3553, 0u);
				}
				if (antialiasingAvailable && antiAliasing)
				{
					_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2._0023_003DzuThhmMw_2WYe_HEAnQ_003D_003D(this, 0, 0, tileWidth, tileHeight, 16384, _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn3);
				}
				_0023_003DzEix95WtV2JIElmDGjw_003D_003D(_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn3);
				if (num == 0)
				{
					ReadBuffer(36064);
					gl.ReadPixels(0, 0, strideInPixels, tileHeight, format, 5121, bitmapData.Scan0);
				}
				if (antialiasingAvailable && antiAliasing)
				{
					_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn2._0023_003DzHF353qc_003D(this);
				}
				_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn3._0023_003DzHF353qc_003D(this);
				flag = true;
			}
			RestoreFBO();
		}
		if (!flag)
		{
			drawSceneFunc(drawSceneParams);
			ReadBuffer(1029);
			if (num == 0)
			{
				gl.ReadPixels(0, 0, strideInPixels, tileHeight, format, 5121, bitmapData.Scan0);
			}
		}
	}

	internal void _0023_003DzQXov33mauSKJ(FrameBufferObjectBase _0023_003DzOY6IA54_003D)
	{
		_0023_003DzEix95WtV2JIElmDGjw_003D_003D(_0023_003DzOY6IA54_003D);
	}

	private void _0023_003DzEix95WtV2JIElmDGjw_003D_003D(FrameBufferObjectBase _0023_003DzOY6IA54_003D)
	{
		PushCurrentFBO();
		if (_0023_003DzOY6IA54_003D != null)
		{
			((_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn)_0023_003DzOY6IA54_003D)._0023_003Dzri_Jxos_003D(this);
		}
		else
		{
			_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003DzluJsUwU_003D(this);
		}
	}

	public override void SetColorMaterial(System.Drawing.Color color, bool force = false)
	{
		switch (ColorMaterialMode)
		{
		case colorMaterialType.FrontAndBackFaceDiffuse:
			SetMaterialFrontAndBackDiffuse(color, force);
			break;
		case colorMaterialType.Disabled:
		case colorMaterialType.FrontFaceDiffuse:
			if (force || color != base.CurrentMaterial.Diffuse)
			{
				base.CurrentMaterial.Diffuse = color;
				SetMaterialFrontDiffuse(Utility.ColorToFloatArray(color));
			}
			break;
		}
	}

	public override void SetSceneAmbient(float[] color)
	{
		_0023_003DzNT32oUkqGeGp._0023_003DzF97mX6ysdyON = new Vector4(color);
	}

	public override void SetTexture1DWrapMode(bool clamp)
	{
		gl.TexParameteri(3552, 10242, clamp ? gl.CLAMP_TO_EDGE : 10497);
	}

	public override void BeginDrawForSelection()
	{
		if (base.ControlData.isFsaaAvailable)
		{
			_0023_003DzmxaFeOccxXUejIw_00249Q_003D_003D = gl.IsEnabled(32925) > 0;
			EnableMultisample(enable: false);
		}
		else
		{
			_0023_003DzmxaFeOccxXUejIw_00249Q_003D_003D = false;
		}
		gl.Disable(3024);
		if (gl.EXT_framebuffer_object)
		{
			if (_0023_003DzQapBRGvgfbOm != null && (_0023_003DzQapBRGvgfbOm._0023_003Dzd3wwRAyZ0u7z() != base.ControlData.ControlSize.Width || _0023_003DzQapBRGvgfbOm._0023_003DzJndH3qzbRKM7() != base.ControlData.ControlSize.Height))
			{
				_0023_003DzQapBRGvgfbOm._0023_003DzHF353qc_003D(this);
				_0023_003DzQapBRGvgfbOm = null;
			}
			if (_0023_003DzQapBRGvgfbOm == null)
			{
				_0023_003DzQapBRGvgfbOm = new _0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn(this, base.ControlData.ControlSize.Width, base.ControlData.ControlSize.Height, _0023_003Dzhpb8QNg_003D: true, _0023_003DzaNkZ4Os_003D: true, _0023_003DzMnQWOgMjrI_0024Z: true);
			}
			_0023_003DzQapBRGvgfbOm._0023_003Dzri_Jxos_003D(this);
		}
	}

	public override void EndDrawForSelection()
	{
		if (_0023_003DzmxaFeOccxXUejIw_00249Q_003D_003D)
		{
			EnableMultisample(enable: true);
		}
		if (gl.EXT_framebuffer_object)
		{
			_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003DzluJsUwU_003D(this);
		}
	}

	public override void EnableMultisample(bool enable)
	{
		if (enable)
		{
			gl.Enable(32925);
		}
		else
		{
			gl.Disable(32925);
		}
	}

	public override bool HasFBO()
	{
		return gl.EXT_framebuffer_object;
	}

	public override bool HasFBBlit()
	{
		return gl.EXT_framebuffer_blit;
	}

	public override bool HasFBMultisample()
	{
		return gl._0023_003Dzk4W_3C9jG_0024EAZx0nEMCpDzB6m0Ds_9GeMrw2WYo_003D;
	}

	public override bool HasPackedDepthStencil()
	{
		return gl.EXT_packed_depth_stencil;
	}

	public override bool IsMultisample()
	{
		return samplesBuffersARB;
	}

	public override void EnableThickLines()
	{
		SetLinesShader(base.CurrentLineWidth > 1f, base.CurrentShader);
	}

	public override void EnableThickLinesInPolygonLineMode()
	{
		SetShader(shaderType.NoLights);
	}

	public override void EnableThickPointsInPolygonLineMode()
	{
		SetShader(shaderType.NoLights);
	}

	public override void EnableThickPoints()
	{
		SetShader(shaderType.NoLights);
	}

	[CLSCompliant(false)]
	public override void SetLineStipple(int factor, ushort pattern, Camera camera)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzRVNtcj0ilKIsW3W5qA_003D_003D = factor;
		_0023_003Dz_BT7SDwEbLrP._0023_003DzdM7iTrCiMP954JENCg_003D_003D = pattern;
	}

	public override void EnableLineStipple(bool enable)
	{
		if (!enable)
		{
			EndDrawBufferedLines();
		}
		base.EnableLineStipple(enable);
		SetLinesShader(base.CurrentLineWidth > 1f, base.CurrentShader);
	}

	public override bool HasShadow()
	{
		return gl.ARB_shadow;
	}

	public override bool HasMultiTexture()
	{
		return gl.ARB_multitexture;
	}

	public override void PushCurrentFBO()
	{
		if (_0023_003DzUEv4S5BpAiMt != null)
		{
			_0023_003Dz5OlB2TJNAVRx.Push(_0023_003DzUEv4S5BpAiMt);
		}
	}

	public override void RestoreFBO()
	{
		if (_0023_003Dz5OlB2TJNAVRx.Count > 0)
		{
			((_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn)_0023_003Dz5OlB2TJNAVRx.Pop())._0023_003Dzri_Jxos_003D(this);
		}
		else
		{
			_0023_003DzcH9sMXbLfkDEoFlm50kXxjKFzAXn._0023_003DzluJsUwU_003D(this);
		}
	}

	public override System.Drawing.Color GetPixel(int x, int y)
	{
		Bitmap bitmap = new Bitmap(1, 1);
		ReadBuffer(1028);
		BitmapData bitmapData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, 1, 1), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
		gl.ReadPixels(x, y, 1, 1, 32992, 5121, bitmapData.Scan0);
		bitmap.UnlockBits(bitmapData);
		System.Drawing.Color pixel = bitmap.GetPixel(0, 0);
		bitmap.Dispose();
		return pixel;
	}

	public override void SetActiveTexture(TextureBase.textureUnitType textureUnit)
	{
		gl.ActiveTexture((int)(33984 + textureUnit));
	}

	public override void SetEnvironment(IEnvironment environment, float intensity)
	{
		base.SetEnvironment(environment, intensity);
		_0023_003Dz_BT7SDwEbLrP._0023_003Dzyz_0024bfF2zwT8WPfon7g_003D_003D = intensity;
		_0023_003Dz_BT7SDwEbLrP.Environment = environment;
		_0023_003Dz_BT7SDwEbLrP.EnvironmentMapping = environment != null;
	}

	public override void SetTextureOverExposure(bool textureOverExposure)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzHtNbVaLv1tw6oApvlY6grW0_003D = textureOverExposure;
	}

	public override void SetTextureLength(float textureLength)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzOnHva6wpqpFv = textureLength;
	}

	public override void SetTextureGrayscale(bool grayscale, float grayscaleAlpha)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzcLeF_4uietaA = (grayscale ? grayscaleAlpha : 1f);
	}

	public override void SetClippable(bool clippable)
	{
		_0023_003Dz_BT7SDwEbLrP._0023_003DzYRbzTAwIoBjDBgji_0024g_003D_003D = (clippable ? 1 : 0);
	}

	protected override void UpdateShadersForShadow(Dictionary<shaderType, IShaderTechnique> shaders, ShaderParameters shaderParams)
	{
		base.UpdateShadersForShadow(shaders, shaderParams);
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzZNyBcAB5yV7hpeJ_8w_003D_003D = shaderParams.NumberOfSplits;
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzDlelRQHE9I5t = shaderParams.ShadowAmbientFactor;
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzqctDI1e5SJ_00246QRevoQ_003D_003D = new Vector4(0f, 0.5f, 0.5f, 0f);
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003Dzy3SXbagWg_F4Vm8sgQ_003D_003D = ((shaderParams.NumberOfSplits == 4) ? new Vector4(0.5f, 0.5f, 0f, 0f) : new Vector4(0f, 0f, 0f, 0f));
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzRg5NBWQCHAcK = new Vector2(shaderParams.ShadowTextureScale[0], shaderParams.ShadowTextureScale[1]);
		double[] splitPositions = shaderParams.RenderContext.frustumData.SplitPositions;
		_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzCKF3eIui6qW8llweCQ_003D_003D = new Vector4((float)(0.0 - splitPositions[0]), (float)(0.0 - splitPositions[1]), (float)(0.0 - splitPositions[2]), (float)(0.0 - splitPositions[3]));
		if (shaderParams.NumberOfSplits > 3)
		{
			_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzgDYNVpo_0024_00240O0 = new SharpDX.Matrix(shaderParams.ShadowMapData.textureMatrix[3]);
		}
		if (shaderParams.NumberOfSplits > 2)
		{
			_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzKdDMLY8BiGku = new SharpDX.Matrix(shaderParams.ShadowMapData.textureMatrix[2]);
		}
		if (shaderParams.NumberOfSplits > 1)
		{
			_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzB0ZfnHgXH6ki = new SharpDX.Matrix(shaderParams.ShadowMapData.textureMatrix[1]);
		}
		if (shaderParams.NumberOfSplits > 0)
		{
			_0023_003DzNT32oUkqGeGp._0023_003DzhAQ5JLY_003D._0023_003DzmPPAR95Y297N = new SharpDX.Matrix(shaderParams.ShadowMapData.textureMatrix[0]);
		}
		_0023_003DzNT32oUkqGeGp._0023_003Dz85RDWW0DIFz1[shaderParams.LightWithShadow]._0023_003DzBjT3PLCBXnbL = 1f;
	}

	protected internal override EntityGraphicsData CreateEntityGraphicsData()
	{
		return new OglEntityGraphicsData();
	}

	public override EntityGraphicsData CreateEntityGraphicsData(object parent)
	{
		return new OglEntityGraphicsData(parent);
	}

	internal override EntityGraphicsData InitCompositingData()
	{
		EntityGraphicsData entityGraphicsData = CreateEntityGraphicsData();
		CompileVBO(entityGraphicsData, _0023_003DzP0sFNwY_003D._0023_003Dz84eeg84_003D._0023_003DzPUoCIsDGVJN4zk0OSrY4KAxORrKeSN48c5FPivg_003D, new VBOParamsTexture
		{
			vertices = new float[12]
			{
				0f, 0f, 0f, 0f, 1f, 0f, 1f, 1f, 0f, 1f,
				0f, 0f
			},
			TextureCoordinates = new float[8] { 0f, 0f, 0f, 1f, 1f, 1f, 1f, 0f },
			indices = new int[6] { 0, 1, 2, 0, 2, 3 },
			primitiveMode = primitiveType.TriangleList
		});
		return entityGraphicsData;
	}

	private _0023_003DzcaoARosWGMzewm3T6w_003D_003D _0023_003DzQ5eoZbq4oqVL()
	{
		if (_0023_003DzuYX3TwfUt3k6 == null)
		{
			_0023_003DzuYX3TwfUt3k6 = new _0023_003DzcaoARosWGMzewm3T6w_003D_003D(this);
		}
		return _0023_003DzuYX3TwfUt3k6;
	}

	public override int RegisterCustomShader(IShader customShader)
	{
		return _0023_003DzQ5eoZbq4oqVL()._0023_003DzQvFgXE6Nfls0(customShader as GLShader);
	}

	public override bool SetCustomShader(IShader customShader, ShaderParameters shaderParameters = null)
	{
		return _0023_003DzQ5eoZbq4oqVL()._0023_003DzIfTRMjcdlbHS(customShader as GLShader, shaderParameters);
	}

	public override bool RemoveCustomShader(IShader customShader)
	{
		return _0023_003DzQ5eoZbq4oqVL()._0023_003DzqPe4SdK2glT8(customShader as GLShader);
	}

	public override bool RemoveAllCustomShaders()
	{
		return _0023_003DzQ5eoZbq4oqVL()._0023_003Dzq4Aw_ksDOEK79KYO6A_003D_003D();
	}
}
