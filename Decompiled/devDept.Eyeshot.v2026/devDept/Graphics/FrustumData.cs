using System;
using devDept.Eyeshot;
using devDept.Geometry;

namespace devDept.Graphics;

public class FrustumData
{
	public bool SpotLight;

	public Point3D[][] SplitCorners;

	public double[] SplitPositions;

	public double[] DepthRanges;

	public Point3D Min;

	public Point3D Max;

	public int NumberOfSplits;

	public FrustumData(int numberOfSplits)
	{
		NumberOfSplits = numberOfSplits;
	}

	public void ComputeParallelSplitData(RenderContextBase renderContext, Camera camera, Transformation sceneTransformation, int[] viewFrame)
	{
		if (Camera._0023_003DzY48JWScgTllAem1s3A_003D_003D(camera.ModelViewMatrix, camera.ProjectionMatrix, out var _0023_003DzjuqjeCoj92PE))
		{
			ComputeSplitCorners(renderContext, camera, _0023_003DzjuqjeCoj92PE, viewFrame);
			int num = viewFrame[0];
			int num2 = viewFrame[0] + viewFrame[2];
			int num3 = viewFrame[1];
			int num4 = viewFrame[1] + viewFrame[3];
			Point3D[] points = new Point3D[8]
			{
				Camera.UnProject(renderContext, viewFrame, _0023_003DzjuqjeCoj92PE, num, num3, 0.0),
				Camera.UnProject(renderContext, viewFrame, _0023_003DzjuqjeCoj92PE, num2, num3, 0.0),
				Camera.UnProject(renderContext, viewFrame, _0023_003DzjuqjeCoj92PE, num, num4, 0.0),
				Camera.UnProject(renderContext, viewFrame, _0023_003DzjuqjeCoj92PE, num2, num4, 0.0),
				Camera.UnProject(renderContext, viewFrame, _0023_003DzjuqjeCoj92PE, num, num3, 1.0),
				Camera.UnProject(renderContext, viewFrame, _0023_003DzjuqjeCoj92PE, num2, num3, 1.0),
				Camera.UnProject(renderContext, viewFrame, _0023_003DzjuqjeCoj92PE, num, num4, 1.0),
				Camera.UnProject(renderContext, viewFrame, _0023_003DzjuqjeCoj92PE, num2, num4, 1.0)
			};
			Min = Point3D.MaxValue;
			Max = Point3D.MinValue;
			Utility.UpdateMinMax(null, points, 8, Min, Max);
		}
	}

	private void _0023_003DzpChtRPoDzp8k(RenderContextBase _0023_003DzQdnFby4_003D, Camera _0023_003Dz10qtbIGWAWjL, int[] _0023_003DzqDFBISpCePlj)
	{
		SplitPositions = new double[4];
		double num = 0.5;
		double num2 = NumberOfSplits;
		DepthRanges = new double[NumberOfSplits + 1];
		DepthRanges[0] = 0.0;
		if (_0023_003Dz10qtbIGWAWjL.cameraProjection == projectionType.Orthographic)
		{
			for (int i = 0; i < NumberOfSplits; i++)
			{
				double num3 = (double)(i + 1) / num2;
				double num4 = _0023_003Dz10qtbIGWAWjL.cameraNear + (_0023_003Dz10qtbIGWAWjL.cameraFar - _0023_003Dz10qtbIGWAWjL.cameraNear) * num3;
				SplitPositions[i] = (float)num4;
			}
		}
		else
		{
			double num5 = _0023_003Dz10qtbIGWAWjL.cameraFar - _0023_003Dz10qtbIGWAWjL.cameraNear;
			double x = _0023_003Dz10qtbIGWAWjL.cameraFar / _0023_003Dz10qtbIGWAWjL.cameraNear;
			for (int j = 0; j < NumberOfSplits; j++)
			{
				double num6 = (double)(j + 1) / num2;
				double num7 = _0023_003Dz10qtbIGWAWjL.cameraNear + num5 * num6;
				double num8 = _0023_003Dz10qtbIGWAWjL.cameraNear * Math.Pow(x, num6);
				SplitPositions[j] = num * num7 + (1.0 - num) * num8;
			}
		}
		SplitPositions[NumberOfSplits - 1] = _0023_003Dz10qtbIGWAWjL.cameraFar;
		double num9 = 0.999;
		Vector3D viewNormal = _0023_003Dz10qtbIGWAWjL.ViewNormal;
		for (int k = 0; k < DepthRanges.Length; k++)
		{
			double _0023_003Dz_00246VsdVC_0024uVkn;
			if (k == 0)
			{
				_0023_003Dz_00246VsdVC_0024uVkn = 0.0;
			}
			else
			{
				Point3D point3D = _0023_003Dz10qtbIGWAWjL.cameraLocation - viewNormal * SplitPositions[k - 1];
				_0023_003Dz10qtbIGWAWjL._0023_003DzKWdaQi8_003D(_0023_003DzQdnFby4_003D, _0023_003DzqDFBISpCePlj, point3D.X, point3D.Y, point3D.Z, out var _, out var _, out _0023_003Dz_00246VsdVC_0024uVkn);
			}
			DepthRanges[k] = 0.001 + _0023_003Dz_00246VsdVC_0024uVkn * num9;
		}
		DepthRanges[DepthRanges.Length - 1] = 1.0;
	}

	public void ComputeSplitCorners(RenderContextBase renderContext, Camera camera, double[] modelViewProjInverse, int[] viewFrame)
	{
		_0023_003DzpChtRPoDzp8k(renderContext, camera, viewFrame);
		int num = viewFrame[0];
		int num2 = viewFrame[0] + viewFrame[2];
		int num3 = viewFrame[1];
		int num4 = viewFrame[1] + viewFrame[3];
		SplitCorners = new Point3D[NumberOfSplits + 1][];
		for (int i = 0; i < NumberOfSplits + 1; i++)
		{
			double winz = DepthRanges[i];
			SplitCorners[i] = new Point3D[4];
			SplitCorners[i][0] = Camera.UnProject(renderContext, viewFrame, modelViewProjInverse, num, num3, winz);
			SplitCorners[i][1] = Camera.UnProject(renderContext, viewFrame, modelViewProjInverse, num2, num3, winz);
			SplitCorners[i][2] = Camera.UnProject(renderContext, viewFrame, modelViewProjInverse, num, num4, winz);
			SplitCorners[i][3] = Camera.UnProject(renderContext, viewFrame, modelViewProjInverse, num2, num4, winz);
		}
	}
}
