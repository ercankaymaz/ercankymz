using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot;
using devDept.Geometry;

namespace devDept.Graphics;

public abstract class ShadowMapData
{
	public class GfxShadowParams
	{
		public int[] viewFrame;

		public Camera camera;

		public RenderContextBase renderContext;

		public LightSettings[] activeLights;

		public Point3D entMin;

		public Point3D entMax;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DzMNHVHn8dkMbJU0SWHg_003D_003D;

	protected internal TextureBase[] _texture;

	public float[][] planeS;

	public float[][] planeT;

	public float[][] planeR;

	public float[][] planeQ;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private float[][] _0023_003DzPYz1fRNYXS6W9EZX6NAp3wU_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzGbMbd2EUXQd3;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static double _0023_003Dz4hF7GgQ_0024ujAu = 10.0;

	public bool Dirty;

	public Size Size
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzMNHVHn8dkMbJU0SWHg_003D_003D;
		}
	}

	protected abstract double[] biasMatrix { get; }

	public float[][] textureMatrix
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzPYz1fRNYXS6W9EZX6NAp3wU_003D;
		}
	}

	public ShadowMapData()
	{
		_0023_003DzRC9aqYK70PPR(out planeS);
		_0023_003DzRC9aqYK70PPR(out planeT);
		_0023_003DzRC9aqYK70PPR(out planeR);
		_0023_003DzRC9aqYK70PPR(out planeQ);
		_0023_003DzIc0UhYTHRJsC(new float[4][]);
	}

	internal void _0023_003DztZV3CZc_003D(Size _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzMNHVHn8dkMbJU0SWHg_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003DzRC9aqYK70PPR(out float[][] _0023_003Dzrgqz890sj_0024X9)
	{
		_0023_003Dzrgqz890sj_0024X9 = new float[4][];
		for (int i = 0; i < 4; i++)
		{
			_0023_003Dzrgqz890sj_0024X9[i] = new float[4];
		}
	}

	internal void _0023_003DzIc0UhYTHRJsC(float[][] _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzPYz1fRNYXS6W9EZX6NAp3wU_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003Dz6tZ_KVuOYiwXkURz_ZIrSPk_003D(int _0023_003DzarF6xJQ_003D, int _0023_003DzrDPdIjQ_003D, double[][] _0023_003DzpaKMExqVnxiUBFbP1w_003D_003D)
	{
		double[] array = Utility.MultMatrixd(_0023_003DzpaKMExqVnxiUBFbP1w_003D_003D[_0023_003DzrDPdIjQ_003D], biasMatrix);
		textureMatrix[_0023_003DzrDPdIjQ_003D] = new float[16];
		for (int i = 0; i < 16; i++)
		{
			textureMatrix[_0023_003DzrDPdIjQ_003D][i] = (float)array[i];
		}
	}

	protected internal virtual bool IsValidFBO()
	{
		return true;
	}

	public virtual void EnableForShaders(RenderContextBase context, int texNumber)
	{
		context.SetTexture(_texture[texNumber], TextureBase.textureUnitType.ShadowMap);
	}

	internal bool _0023_003DzVBC_IOZx_0024Eqi()
	{
		if (_texture != null)
		{
			return _texture[0].IsValid();
		}
		return false;
	}

	protected void EnableBlendingEqual(RenderContextBase renderContext)
	{
		renderContext.SetState(blendStateType.Blend_SrcOne_DstZero);
		renderContext.SetState(depthStencilStateType.DepthMaskFalse_DepthTestEqual);
	}

	public static void EnableAdditiveBlending(RenderContextBase renderContext)
	{
		renderContext.SetState(blendStateType.Blend_SrcOne_DstOne);
		renderContext.SetState(depthStencilStateType.DepthMaskFalse_DepthTestEqual);
	}

	public static void DisableBlending(RenderContextBase renderContext)
	{
		renderContext.SetState(blendStateType.NoBlend);
		renderContext.SetState(depthStencilStateType.DepthTestLess);
	}

	public abstract void Disable(RenderContextBase renderContext);

	internal bool _0023_003Dz1u4wmda3JTwv(RenderContextBase _0023_003DzB8iS0QA_003D, int _0023_003DzueB3iPdYaxVx, uint _0023_003Dz6tVBpdk_003D, uint _0023_003DzvAxV_0024Ic_003D)
	{
		if (_texture != null && _texture[0].IsValid())
		{
			return true;
		}
		_texture = new TextureBase[_0023_003DzueB3iPdYaxVx];
		try
		{
			for (int i = 0; i < _0023_003DzueB3iPdYaxVx; i++)
			{
				_texture[i] = _0023_003DzB8iS0QA_003D.CreateTexture2D(new Size((int)_0023_003Dz6tVBpdk_003D, (int)_0023_003DzvAxV_0024Ic_003D), depthTexture: true);
				if (_0023_003DzB8iS0QA_003D.IsGraphicsError())
				{
					return false;
				}
			}
		}
		catch
		{
			return false;
		}
		return true;
	}

	protected internal virtual bool InitFBO(RenderContextBase context, int nSplits, uint width, uint height)
	{
		return _0023_003Dz1u4wmda3JTwv(context, nSplits, width, height);
	}

	public void Dispose(RenderContextBase renderContext)
	{
		ClearTextures(renderContext);
	}

	protected virtual void ClearTextures(RenderContextBase renderContext)
	{
		if (_texture == null)
		{
			return;
		}
		for (int i = 0; i < _texture.Length; i++)
		{
			if (_texture[i] != null)
			{
				_texture[i].Dispose();
			}
		}
		_texture = null;
	}

	protected virtual void ReadTexture(RenderContextBase renderContext, TextureBase texture, uint x, uint y, uint mapWidth, uint mapHeight)
	{
	}

	protected internal virtual void Create(GfxShadowParams shadowParams, int lightIndex, uint x, uint y, FrustumData frustumData, ClippingPlaneBase[] clippingPlanes, DrawForShadowMapDelegate drawForShadowMapCallback, object drawForShadowParams)
	{
		RenderContextBase renderContext = shadowParams.renderContext;
		if (textureMatrix == null)
		{
			_0023_003DzIc0UhYTHRJsC(new float[frustumData.NumberOfSplits][]);
		}
		bool flag = UseFBO();
		PlaneEquation[][] _0023_003DzXPGWCkuOGueC;
		double[][] array = _0023_003Dz2qxwj7RBMQ_HKkD9NW53aQI_003D(renderContext, shadowParams.activeLights[lightIndex], shadowParams.camera, frustumData, shadowParams.entMin, shadowParams.entMax, out _0023_003DzXPGWCkuOGueC);
		if (array == null)
		{
			return;
		}
		renderContext.SetState(blendStateType.ColorMaskOff);
		renderContext.SetState(depthStencilStateType.DepthTestLess);
		if (renderContext.IsCullFace())
		{
			renderContext.SetState(rasterizerStateType.CCW_PolygonFill_CullFaceBack_PolygonOffset_Plus2Plus2);
		}
		else
		{
			renderContext.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_Plus2Plus2);
		}
		renderContext.SetViewport(shadowParams.viewFrame, 0f, 1f);
		uint _0023_003DzAeGRnVQ_003D = (uint)Size.Width;
		uint _0023_003Dz1u2fKoI_003D = (uint)Size.Height;
		_0023_003DzKdcsfJAO5bWnlN5RtA_003D_003D(frustumData.NumberOfSplits, (uint)Size.Width, (uint)Size.Height, out _0023_003DzAeGRnVQ_003D, out _0023_003Dz1u2fKoI_003D);
		double[] modelViewMatrix = shadowParams.camera.ModelViewMatrix;
		for (int i = 0; i < array.GetLength(0); i++)
		{
			_0023_003Dz6tZ_KVuOYiwXkURz_ZIrSPk_003D(lightIndex, i, array);
			if (_0023_003DzGbMbd2EUXQd3)
			{
				continue;
			}
			renderContext.SetMatrices(null, array[i]);
			shadowParams.camera.ModelViewMatrix = new double[16];
			Array.Copy(array[i], shadowParams.camera.ModelViewMatrix, 16);
			if (flag)
			{
				TextureBase texture = _texture[0];
				SetDepthFBO(renderContext, texture);
				if (i == 0)
				{
					renderContext.ClearDepthStencil(depthBuffer: true, stencilBuffer: false, 0);
				}
			}
			uint num = x;
			uint num2 = y;
			switch (i)
			{
			case 1:
				num += _0023_003DzAeGRnVQ_003D;
				break;
			case 2:
				num += _0023_003DzAeGRnVQ_003D;
				num2 += _0023_003Dz1u2fKoI_003D;
				break;
			case 3:
				num2 += _0023_003Dz1u2fKoI_003D;
				break;
			}
			if (flag && frustumData.SpotLight)
			{
				_0023_003Dz_BagdwpwdorYsxemr1mDpjT2Vtw6(renderContext.NumberOfSplits, ref _0023_003DzAeGRnVQ_003D, ref _0023_003Dz1u2fKoI_003D);
			}
			renderContext.SetViewport(new int[4]
			{
				(int)num,
				(int)num2,
				(int)_0023_003DzAeGRnVQ_003D,
				(int)_0023_003Dz1u2fKoI_003D
			});
			if (shadowParams.activeLights[lightIndex].Type != lightType.Point)
			{
				_0023_003DzGbMbd2EUXQd3 = !drawForShadowMapCallback(_0023_003DzXPGWCkuOGueC[i], drawForShadowParams);
			}
			if (!_0023_003DzGbMbd2EUXQd3 && !flag)
			{
				TextureBase texture2 = _texture[0];
				ReadTexture(renderContext, texture2, num, num2, _0023_003DzAeGRnVQ_003D, _0023_003Dz1u2fKoI_003D);
				renderContext.CloseTexture(force: true);
			}
		}
		renderContext.DisableClipPlanes();
		shadowParams.camera.ModelViewMatrix = modelViewMatrix;
		renderContext.SetViewport(shadowParams.viewFrame, 0.001f, 1f);
		renderContext.SetupPolygonOffset(enable: false);
		renderContext.SetState(depthStencilStateType.DepthTestOff);
		renderContext.SetState(blendStateType.NoBlend);
	}

	protected virtual bool UseFBO()
	{
		return true;
	}

	protected internal abstract void SetDepthFBO(RenderContextBase context, TextureBase texture);

	private static void _0023_003Dz_BagdwpwdorYsxemr1mDpjT2Vtw6(int _0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D, ref uint _0023_003Dz6tVBpdk_003D, ref uint _0023_003DzvAxV_0024Ic_003D)
	{
		switch (_0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D)
		{
		case 2:
			_0023_003Dz6tVBpdk_003D *= 2u;
			break;
		case 4:
			_0023_003Dz6tVBpdk_003D *= 2u;
			_0023_003DzvAxV_0024Ic_003D *= 2u;
			break;
		}
	}

	internal static double[][] _0023_003DzqUJlPWC8KzsWYTryYgUduwo_003D(int _0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D, double[] _0023_003Dzqd_0024SZDePtuz9, Point3D[][] _0023_003DzHcSWmthTFokoetCCvQ_003D_003D, out Point3D[][] _0023_003DzoStToS2a7nJUzQRpJQ_003D_003D)
	{
		double[][] array = new double[_0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D][];
		Point3D[][] array2 = new Point3D[_0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D + 1][];
		array2[0] = new Point3D[4];
		for (int i = 0; i < 4; i++)
		{
			Point3D point3D = _0023_003DzHcSWmthTFokoetCCvQ_003D_003D[0][i];
			array2[0][i] = new Point3D(Utility.MultMatrixVecd(_0023_003Dzqd_0024SZDePtuz9, new double[4] { point3D.X, point3D.Y, point3D.Z, 1.0 }));
		}
		_0023_003DzoStToS2a7nJUzQRpJQ_003D_003D = new Point3D[_0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D][];
		for (int j = 0; j < _0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D; j++)
		{
			int num = j + 1;
			array2[num] = new Point3D[4];
			for (int k = 0; k < 4; k++)
			{
				Point3D point3D2 = _0023_003DzHcSWmthTFokoetCCvQ_003D_003D[num][k];
				array2[num][k] = new Point3D(Utility.MultMatrixVecd(_0023_003Dzqd_0024SZDePtuz9, new double[4] { point3D2.X, point3D2.Y, point3D2.Z, 1.0 }));
			}
			Point3D[] array3 = new Point3D[8];
			for (int l = 0; l < 4; l++)
			{
				array3[l] = array2[j][l];
				array3[l + 4] = array2[num][l];
			}
			Point3D maxValue = Point3D.MaxValue;
			Point3D minValue = Point3D.MinValue;
			Utility.UpdateMinMax(null, array3, array3.Length, maxValue, minValue);
			maxValue.Z = -1.0;
			array[j] = _0023_003Dz1KNJY9qMNlj_dASDIQ_003D_003D(maxValue, minValue);
			_0023_003DzoStToS2a7nJUzQRpJQ_003D_003D[j] = new Point3D[2] { maxValue, minValue };
		}
		return array;
	}

	private static double[] _0023_003Dz1KNJY9qMNlj_dASDIQ_003D_003D(Point3D _0023_003DzgC_4KTGqff_0024c, Point3D _0023_003DzBUkUABtg_0024pn_0024)
	{
		double num = 2.0 / (_0023_003DzBUkUABtg_0024pn_0024.X - _0023_003DzgC_4KTGqff_0024c.X);
		double num2 = 2.0 / (_0023_003DzBUkUABtg_0024pn_0024.Y - _0023_003DzgC_4KTGqff_0024c.Y);
		double num3 = 1.0 / (_0023_003DzBUkUABtg_0024pn_0024.Z - _0023_003DzgC_4KTGqff_0024c.Z);
		double num4 = -0.5 * (_0023_003DzBUkUABtg_0024pn_0024.X + _0023_003DzgC_4KTGqff_0024c.X) * num;
		double num5 = -0.5 * (_0023_003DzBUkUABtg_0024pn_0024.Y + _0023_003DzgC_4KTGqff_0024c.Y) * num2;
		double num6 = (0.0 - _0023_003DzgC_4KTGqff_0024c.Z) * num3;
		return new double[16]
		{
			num, 0.0, 0.0, 0.0, 0.0, num2, 0.0, 0.0, 0.0, 0.0,
			num3, 0.0, num4, num5, num6, 1.0
		};
	}

	internal static double[][] _0023_003Dz2qxwj7RBMQ_HKkD9NW53aQI_003D(RenderContextBase _0023_003DzQdnFby4_003D, LightSettings _0023_003DzX_0024FBqNE_003D, Camera _0023_003DzztLIRQOxCyGw, FrustumData _0023_003DzCfh6nmesg_wItGssKg_003D_003D, Point3D _0023_003Dzw6MTIExa9FCQ, Point3D _0023_003Dzs_rNF1nafbip, out PlaneEquation[][] _0023_003DzXPGWCkuOGueC)
	{
		double[] modelViewMatrix = _0023_003DzztLIRQOxCyGw.ModelViewMatrix;
		_0023_003DzX_0024FBqNE_003D.GetLightDirection(modelViewMatrix, out var direction, out var position);
		Point3D point3D;
		if (_0023_003DzX_0024FBqNE_003D.Type == lightType.Spot)
		{
			point3D = new Point3D(position[0], position[1], position[2]);
		}
		else
		{
			point3D = Point3D.Origin;
			for (int i = 0; i < 3; i++)
			{
				direction[i] *= -1f;
			}
		}
		Vector3D vector3D = new Vector3D(new double[3]
		{
			direction[0],
			direction[1],
			direction[2]
		});
		Plane plane = new Plane(point3D, vector3D);
		_0023_003DzLDpDrZOdI0C7(_0023_003DzX_0024FBqNE_003D, plane, _0023_003DzCfh6nmesg_wItGssKg_003D_003D, _0023_003Dzw6MTIExa9FCQ, _0023_003Dzs_rNF1nafbip, out var _0023_003Dz2miLS1cOCKJj, out var _0023_003Dzjag_aPU_003D, out var _0023_003DzbArhmOxL9Wf, out var _0023_003Dz4l02SF1NNK3X);
		if (Math.Abs(_0023_003Dz2miLS1cOCKJj - _0023_003Dzjag_aPU_003D) < 1E-09)
		{
			_0023_003DzXPGWCkuOGueC = null;
			return null;
		}
		double[] b = ((_0023_003DzX_0024FBqNE_003D.Type != lightType.Spot) ? Camera.myOrtho(_0023_003DzQdnFby4_003D, 0.0 - _0023_003Dz4l02SF1NNK3X, _0023_003Dz4l02SF1NNK3X, 0.0 - _0023_003Dz4l02SF1NNK3X, _0023_003Dz4l02SF1NNK3X, _0023_003Dz2miLS1cOCKJj, _0023_003Dzjag_aPU_003D) : _0023_003DzztLIRQOxCyGw.myPerspective(_0023_003DzQdnFby4_003D, Utility.RadToDeg(_0023_003DzX_0024FBqNE_003D.SpotHalfAngle * 2.0), 1.0, _0023_003Dz2miLS1cOCKJj, _0023_003Dzjag_aPU_003D));
		Vector3D axisY = plane.AxisY;
		Vector3D axisX = plane.AxisX;
		double[] array = Utility.MultMatrixd(Camera.LookAtInternal(_0023_003DzbArhmOxL9Wf, new Point3D(_0023_003DzbArhmOxL9Wf.X + (double)direction[0], _0023_003DzbArhmOxL9Wf.Y + (double)direction[1], _0023_003DzbArhmOxL9Wf.Z + (double)direction[2]), axisY, axisX), b);
		double[][] array2 = null;
		_0023_003DzXPGWCkuOGueC = null;
		if (_0023_003DzX_0024FBqNE_003D.Type == lightType.Directional)
		{
			Point3D[][] _0023_003DzoStToS2a7nJUzQRpJQ_003D_003D;
			double[][] array3 = _0023_003DzqUJlPWC8KzsWYTryYgUduwo_003D(_0023_003DzCfh6nmesg_wItGssKg_003D_003D.NumberOfSplits, array, _0023_003DzCfh6nmesg_wItGssKg_003D_003D.SplitCorners, out _0023_003DzoStToS2a7nJUzQRpJQ_003D_003D);
			Vector3D _0023_003DzKceUiHs_003D = new Vector3D(0f - direction[0], 0f - direction[1], 0f - direction[2]);
			_0023_003DzXPGWCkuOGueC = _0023_003Dz4atztELyRXMbAjmF_0024A_003D_003D(array, _0023_003DzCfh6nmesg_wItGssKg_003D_003D.NumberOfSplits, _0023_003DzbArhmOxL9Wf, axisX, axisY, _0023_003DzKceUiHs_003D, _0023_003Dz4l02SF1NNK3X, _0023_003Dzjag_aPU_003D, _0023_003DzoStToS2a7nJUzQRpJQ_003D_003D);
			array2 = new double[_0023_003DzCfh6nmesg_wItGssKg_003D_003D.NumberOfSplits][];
			for (int j = 0; j < _0023_003DzCfh6nmesg_wItGssKg_003D_003D.NumberOfSplits; j++)
			{
				array2[j] = Utility.MultMatrixd(array, array3[j]);
			}
		}
		else
		{
			array2 = new double[1][] { array };
			_0023_003DzXPGWCkuOGueC = new PlaneEquation[1][];
			double num = Math.PI / 2.0;
			Vector3D n = new Rotation(0.0 - _0023_003DzX_0024FBqNE_003D.SpotHalfAngle + num, axisY) * vector3D;
			Vector3D n2 = new Rotation(_0023_003DzX_0024FBqNE_003D.SpotHalfAngle - num, axisY) * vector3D;
			Vector3D n3 = new Rotation(0.0 - _0023_003DzX_0024FBqNE_003D.SpotHalfAngle + num, axisX) * vector3D;
			Vector3D n4 = new Rotation(_0023_003DzX_0024FBqNE_003D.SpotHalfAngle - num, axisX) * vector3D;
			_0023_003DzXPGWCkuOGueC[0] = new PlaneEquation[6]
			{
				new PlaneEquation(point3D + vector3D * _0023_003Dz2miLS1cOCKJj, vector3D),
				new PlaneEquation(point3D + vector3D * _0023_003Dzjag_aPU_003D, -1.0 * vector3D),
				new PlaneEquation(point3D, n),
				new PlaneEquation(point3D, n2),
				new PlaneEquation(point3D, n3),
				new PlaneEquation(point3D, n4)
			};
		}
		return array2;
	}

	private static PlaneEquation[][] _0023_003Dz4atztELyRXMbAjmF_0024A_003D_003D(double[] _0023_003Dzqd_0024SZDePtuz9, int _0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D, Point3D _0023_003DzbArhmOxL9Wf3, Vector3D _0023_003DzhMQlKpM_003D, Vector3D _0023_003DzYgu590k_003D, Vector3D _0023_003DzKceUiHs_003D, double _0023_003DzZ1D2U3gqgn8t, double _0023_003DzmA8WJu0_003D, Point3D[][] _0023_003DzoStToS2a7nJUzQRpJQ_003D_003D)
	{
		double[] array = new double[16];
		Utility.InvertMatrixd(_0023_003Dzqd_0024SZDePtuz9, array);
		PlaneEquation[][] array2 = new PlaneEquation[_0023_003DzDpDUWL3qLTQhfI3oKg_003D_003D][];
		for (int i = 0; i < _0023_003DzoStToS2a7nJUzQRpJQ_003D_003D.Length; i++)
		{
			array2[i] = new PlaneEquation[6];
			Point3D point3D = _0023_003DzoStToS2a7nJUzQRpJQ_003D_003D[i][0];
			Point3D point3D2 = _0023_003DzoStToS2a7nJUzQRpJQ_003D_003D[i][1];
			Point3D p = new Point3D(Utility.MultMatrixVecd(array, new double[4] { point3D.X, point3D.Y, point3D.Z, 1.0 }));
			Point3D p2 = new Point3D(Utility.MultMatrixVecd(array, new double[4] { point3D2.X, point3D2.Y, point3D2.Z, 1.0 }));
			PlaneEquation[] array3 = new PlaneEquation[6]
			{
				new PlaneEquation(p, -1.0 * _0023_003DzKceUiHs_003D),
				new PlaneEquation(p2, _0023_003DzKceUiHs_003D),
				new PlaneEquation(p, _0023_003DzhMQlKpM_003D),
				new PlaneEquation(p2, -1.0 * _0023_003DzhMQlKpM_003D),
				new PlaneEquation(p2, _0023_003DzYgu590k_003D),
				new PlaneEquation(p, -1.0 * _0023_003DzYgu590k_003D)
			};
			for (int j = 0; j < 6; j++)
			{
				array2[i][j] = array3[j];
			}
		}
		return array2;
	}

	private static float[] _0023_003DzoTWw_0024hbb_ooJ(double[] _0023_003DzlTrXFNo_003D)
	{
		float[] array = new float[16];
		for (int i = 0; i < 16; i++)
		{
			array[i] = (float)_0023_003DzlTrXFNo_003D[i];
		}
		return array;
	}

	private static void _0023_003DzLDpDrZOdI0C7(LightSettings _0023_003DzX_0024FBqNE_003D, Plane _0023_003DzMqjDDM7wRdD0, FrustumData _0023_003DzCfh6nmesg_wItGssKg_003D_003D, Point3D _0023_003Dzw6MTIExa9FCQ, Point3D _0023_003Dzs_rNF1nafbip, out double _0023_003Dz2miLS1cOCKJj, out double _0023_003Dzjag_aPU_003D, out Point3D _0023_003DzbArhmOxL9Wf3, out double _0023_003Dz4l02SF1NNK3X)
	{
		_0023_003Dzyugm2cJOK5cMvZgg20v4eHs_003D(_0023_003DzMqjDDM7wRdD0, _0023_003DzCfh6nmesg_wItGssKg_003D_003D.Min, _0023_003DzCfh6nmesg_wItGssKg_003D_003D.Max, out var _0023_003DzdSyrM_zQJ2di, out var _0023_003Dzmxrn0iDQb1i_, out var _, out var _);
		double num = Math.Max(_0023_003Dzmxrn0iDQb1i_.X - _0023_003DzdSyrM_zQJ2di.X, _0023_003Dzmxrn0iDQb1i_.Y - _0023_003DzdSyrM_zQJ2di.Y);
		_0023_003Dz4l02SF1NNK3X = num / 2.0 * 1.01;
		Point2D pt = Point2D.MidPoint(_0023_003DzdSyrM_zQJ2di, _0023_003Dzmxrn0iDQb1i_);
		_0023_003Dzyugm2cJOK5cMvZgg20v4eHs_003D(_0023_003DzMqjDDM7wRdD0, _0023_003Dzw6MTIExa9FCQ, _0023_003Dzs_rNF1nafbip, out _0023_003DzdSyrM_zQJ2di, out _0023_003Dzmxrn0iDQb1i_, out var _0023_003DzsVw1i9LkTBtX2, out var _0023_003DzbdEewMMmMxDg2);
		if (_0023_003DzX_0024FBqNE_003D.Type == lightType.Spot)
		{
			_0023_003DzbArhmOxL9Wf3 = _0023_003DzX_0024FBqNE_003D.Position;
			if (_0023_003DzsVw1i9LkTBtX2 <= 0.0)
			{
				_0023_003DzsVw1i9LkTBtX2 = _0023_003DzbdEewMMmMxDg2 * 0.001 * _0023_003Dz4hF7GgQ_0024ujAu;
			}
			_0023_003Dz2miLS1cOCKJj = _0023_003DzsVw1i9LkTBtX2;
			_0023_003Dzjag_aPU_003D = _0023_003DzbdEewMMmMxDg2;
		}
		else
		{
			_0023_003DzbArhmOxL9Wf3 = _0023_003DzMqjDDM7wRdD0.PointAt(pt) + _0023_003DzMqjDDM7wRdD0.AxisZ * _0023_003DzsVw1i9LkTBtX2;
			_0023_003Dz2miLS1cOCKJj = 0.0;
			_0023_003Dzjag_aPU_003D = _0023_003DzbdEewMMmMxDg2 - _0023_003DzsVw1i9LkTBtX2;
		}
	}

	private static void _0023_003Dzyugm2cJOK5cMvZgg20v4eHs_003D(Plane _0023_003DzMqjDDM7wRdD0, Point3D _0023_003Dzv36bFFRl7HJ7_0024ne1rA_003D_003D, Point3D _0023_003Dz8bG26OZEm7gVm7mrqg_003D_003D, out Point2D _0023_003DzdSyrM_zQJ2di, out Point2D _0023_003Dzmxrn0iDQb1i_, out double _0023_003DzsVw1i9LkTBtX, out double _0023_003DzbdEewMMmMxDg)
	{
		Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(_0023_003Dzv36bFFRl7HJ7_0024ne1rA_003D_003D, _0023_003Dz8bG26OZEm7gVm7mrqg_003D_003D);
		Point2D[] array = new Point2D[boundingBoxCorners.Length];
		_0023_003DzbdEewMMmMxDg = double.MinValue;
		_0023_003DzsVw1i9LkTBtX = double.MaxValue;
		for (int i = 0; i < boundingBoxCorners.Length; i++)
		{
			array[i] = _0023_003DzMqjDDM7wRdD0.Project(boundingBoxCorners[i]);
			Utility.UpdateMinMax(_0023_003DzMqjDDM7wRdD0.DistanceTo(boundingBoxCorners[i]), ref _0023_003DzsVw1i9LkTBtX, ref _0023_003DzbdEewMMmMxDg);
		}
		_0023_003DzdSyrM_zQJ2di = Point2D.MaxValue;
		_0023_003Dzmxrn0iDQb1i_ = Point2D.MinValue;
		Utility.UpdateMinMax(null, array, array.Length, _0023_003DzdSyrM_zQJ2di, _0023_003Dzmxrn0iDQb1i_);
	}

	public static int GetNumberOfSplits(realisticShadowQualityType shadowQuality, LightSettings[] lights)
	{
		if (_0023_003DzKLswv47NcF_0024k0JURYA_003D_003D(lights))
		{
			return 1;
		}
		return shadowQuality switch
		{
			realisticShadowQualityType.Low => 1, 
			realisticShadowQualityType.Medium => 2, 
			_ => 4, 
		};
	}

	private static bool _0023_003DzKLswv47NcF_0024k0JURYA_003D_003D(LightSettings[] _0023_003DzAkC55sp_ZvsO)
	{
		bool result = false;
		for (int i = 0; i < _0023_003DzAkC55sp_ZvsO.Length; i++)
		{
			if (_0023_003DzAkC55sp_ZvsO[i].Active && _0023_003DzAkC55sp_ZvsO[i].YieldShadow)
			{
				if (_0023_003DzAkC55sp_ZvsO[i].Type == lightType.Spot)
				{
					result = true;
				}
				break;
			}
		}
		return result;
	}

	internal static void _0023_003DzKdcsfJAO5bWnlN5RtA_003D_003D(int _0023_003DzueB3iPdYaxVx, uint _0023_003Dz6tVBpdk_003D, uint _0023_003DzvAxV_0024Ic_003D, out uint _0023_003DzAeGRnVQ_003D, out uint _0023_003Dz1u2fKoI_003D)
	{
		switch (_0023_003DzueB3iPdYaxVx)
		{
		case 1:
			_0023_003DzAeGRnVQ_003D = _0023_003Dz6tVBpdk_003D;
			_0023_003Dz1u2fKoI_003D = _0023_003DzvAxV_0024Ic_003D;
			break;
		case 2:
			_0023_003DzAeGRnVQ_003D = _0023_003Dz6tVBpdk_003D / 2;
			_0023_003Dz1u2fKoI_003D = _0023_003DzvAxV_0024Ic_003D;
			break;
		default:
			_0023_003DzAeGRnVQ_003D = _0023_003Dz6tVBpdk_003D / 2;
			_0023_003Dz1u2fKoI_003D = _0023_003DzvAxV_0024Ic_003D / 2;
			break;
		}
	}

	public void Clear(RenderContextBase renderContext)
	{
		ClearTextures(renderContext);
		_0023_003DzIc0UhYTHRJsC(null);
		Dirty = true;
	}

	protected internal abstract bool EnableFBO(RenderContextBase context);
}
