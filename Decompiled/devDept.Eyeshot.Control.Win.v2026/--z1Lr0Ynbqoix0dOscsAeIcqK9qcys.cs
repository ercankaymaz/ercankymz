using System;
using System.Collections.Generic;
using System.Drawing;
using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

internal sealed class _0023_003Dz1Lr0Ynbqoix0dOscsAeIcqK9qcys : PlanarShadowBase
{
	public void _0023_003DzshPEPAc_003D(Version _0023_003DzueDenUipdTdt, IList<Entity> _0023_003DzY_0024ABPwh9wryC, Point3D _0023_003Dze4TpmVqI26AF, Point3D _0023_003DzD4HjvLi8HsVr, Workspace _0023_003DzU0f5_qE_003D)
	{
		if (!(_0023_003DzD4HjvLi8HsVr.X < _0023_003Dze4TpmVqI26AF.X) && (_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.IsDirect3D || (!(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.RenderingContext() == IntPtr.Zero) && (_0023_003DzueDenUipdTdt.Major != 1 || _0023_003DzueDenUipdTdt.Minor != 1))))
		{
			RenderContextBase _0023_003DzmNZD0Zs_003D = _0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D;
			_0023_003DzmNZD0Zs_003D.MakeCurrent();
			hwAccPresent = true;
			fastEnough = hwAccPresent;
			Plane plane = _0023_003DzU0f5_qE_003D._0023_003DzrnMI_SiQDx8_0024QFSmZA3zGE6q_QjC4hO9xRf6Hz8_003D();
			Point3D[] boundingBoxCorners = Utility.GetBoundingBoxCorners(_0023_003Dze4TpmVqI26AF, _0023_003DzD4HjvLi8HsVr);
			Point2D[] array = new Point2D[8];
			for (int i = 0; i < boundingBoxCorners.Length; i++)
			{
				array[i] = plane.Project(boundingBoxCorners[i]);
			}
			Point2D maxValue = Point2D.MaxValue;
			Point2D minValue = Point2D.MinValue;
			Utility.UpdateMinMax(null, array, 8, maxValue, minValue);
			plane.DistanceTo(_0023_003Dze4TpmVqI26AF);
			plane.DistanceTo(_0023_003DzD4HjvLi8HsVr);
			Vector2D _0023_003DzBzaz7mI_003D = Vector2D.Subtract(minValue, maxValue);
			if (fastEnough && hwAccPresent)
			{
				PreCreatePlanarShadows(_0023_003DzmNZD0Zs_003D);
				_0023_003DzlzNCDS83UuoISgtecQ_003D_003D(_0023_003DzY_0024ABPwh9wryC, _0023_003Dze4TpmVqI26AF, _0023_003DzD4HjvLi8HsVr, _0023_003DzU0f5_qE_003D, plane, _0023_003DzBzaz7mI_003D);
				PostCreatePlanarShadows(_0023_003DzmNZD0Zs_003D, _0023_003DzU0f5_qE_003D._0023_003Dz0fqXN00AlqdN);
			}
			EndDraw(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D);
		}
	}

	private void _0023_003DzlzNCDS83UuoISgtecQ_003D_003D(IList<Entity> _0023_003DzY_0024ABPwh9wryC, Point3D _0023_003Dz2peSzTCW3qpxgN7JlMFdDmM_003D, Point3D _0023_003DzOJSW9WfH6iipOUuXLMhJPFA_003D, Workspace _0023_003DzU0f5_qE_003D, Plane _0023_003DzOrtNSQnn48wG, Vector2D _0023_003DzBzaz7mI_003D)
	{
		Color color = ((!hwAccPresent) ? Color.FromArgb(255, 0, 255, 0) : Color.FromArgb(0, 0, 0, 0));
		_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.ClearColor(color);
		_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.SetProjectionMatrix(null);
		double num = _0023_003DzOrtNSQnn48wG.DistanceTo(_0023_003DzOJSW9WfH6iipOUuXLMhJPFA_003D);
		bestSize = Math.Max(_0023_003DzBzaz7mI_003D.X, _0023_003DzBzaz7mI_003D.Y);
		center2D = _0023_003DzOrtNSQnn48wG.Project(Point3D.MidPoint(_0023_003Dz2peSzTCW3qpxgN7JlMFdDmM_003D, _0023_003DzOJSW9WfH6iipOUuXLMhJPFA_003D));
		inflatedBestSize = 1.07 * bestSize;
		RenderContextBase _0023_003DzmNZD0Zs_003D = _0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D;
		if (inflatedBestSize > 0.0)
		{
			double[] proj = Camera.myOrtho(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, (0.0 - inflatedBestSize) / 2.0, inflatedBestSize / 2.0, (0.0 - inflatedBestSize) / 2.0, inflatedBestSize / 2.0, -1000000.0, 1000000.0);
			double[] array = null;
			Point3D point3D = _0023_003DzOrtNSQnn48wG.PointAt(center2D);
			array = Camera.LookAtInternal(point3D + num * _0023_003DzOrtNSQnn48wG.AxisZ, point3D, _0023_003DzOrtNSQnn48wG.AxisY);
			_0023_003DzmNZD0Zs_003D.PushDepthStencilState();
			_0023_003DzmNZD0Zs_003D.SetState(depthStencilStateType.DepthTestOff);
			_0023_003DzmNZD0Zs_003D.SetState(rasterizerStateType.CCW_PolygonFill_NoCullFace_PolygonOffset_1_1);
			_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.SetState(blendStateType.NoBlend);
			_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D.SetLighting(enable: false);
			_0023_003DzmNZD0Zs_003D.SetColorWireframe(Color.Black);
			_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
			Viewport viewport = _0023_003DzU0f5_qE_003D._0023_003DzipBYly6zFKAp();
			RenderParams renderParams = new RenderParams(viewport, _0023_003DzU0f5_qE_003D._0023_003DzoE3BE__0024RS_DJ())
			{
				ShaderParams = new ShaderParameters(_0023_003DzU0f5_qE_003D._0023_003DzmNZD0Zs_003D, viewport.GetViewFrame(), viewport.Camera, _0023_003DzU0f5_qE_003D._0023_003DznKkOfo8_003D.ShadowMode, _0023_003DzU0f5_qE_003D._0023_003DznKkOfo8_003D.RealisticShadowQuality, viewport.Background, _0023_003DzU0f5_qE_003D._0023_003DzAzve6tkKNr7t1F9Q_g_003D_003D, _0023_003DzU0f5_qE_003D._0023_003DznKkOfo8_003D.EnvironmentMapping, _0023_003DzU0f5_qE_003D.CurrentTransformation ?? new Identity())
			};
			_0023_003DzmNZD0Zs_003D.SetMatrices(proj, array);
			if (_0023_003DzU0f5_qE_003D.CurrentTransformation != null)
			{
				_0023_003DzmNZD0Zs_003D.MultMatrixModelView(_0023_003DzU0f5_qE_003D.CurrentTransformation);
			}
			ShadowHelper.DrawTrianglesForPlanarShadow(renderParams, _0023_003DzY_0024ABPwh9wryC);
			_0023_003DzmNZD0Zs_003D.PopDepthStencilState();
		}
	}

	internal void _0023_003Dz99kJFjE_003D(RenderContextBase _0023_003DzmNZD0Zs_003D, double _0023_003Dzz7RXpl_6eJqZ, Plane _0023_003Dz4EBhINiGH6w4, Transformation _0023_003Dzht9oJNBnTGWu, Point3D _0023_003Dze4TpmVqI26AF, Point3D _0023_003DzD4HjvLi8HsVr)
	{
		base.Draw(_0023_003DzmNZD0Zs_003D, _0023_003Dzz7RXpl_6eJqZ, _0023_003Dz4EBhINiGH6w4, _0023_003Dzht9oJNBnTGWu, _0023_003Dze4TpmVqI26AF, _0023_003DzD4HjvLi8HsVr);
	}
}
