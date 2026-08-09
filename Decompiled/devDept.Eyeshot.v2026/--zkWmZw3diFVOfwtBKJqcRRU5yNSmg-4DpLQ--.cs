using System;
using System.Collections.Generic;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

internal sealed class _0023_003DzkWmZw3diFVOfwtBKJqcRRU5yNSmg_00244DpLQ_003D_003D
{
	private readonly List<_0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D> _0023_003Dz1sjz__0024zu_mCM;

	public _0023_003DzkWmZw3diFVOfwtBKJqcRRU5yNSmg_00244DpLQ_003D_003D(List<_0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D> _0023_003DzpPOEJqcAh7Lr)
	{
		_0023_003Dz1sjz__0024zu_mCM = _0023_003DzpPOEJqcAh7Lr;
	}

	public void _0023_003DzmHTSerA_003D(RenderContextBase _0023_003DzB8iS0QA_003D, object _0023_003DzmPmPjCPqZ3T3)
	{
		VBOParamsBase myParams = _0023_003DzmHTSerA_003D();
		_0023_003DzB8iS0QA_003D.DrawIndexedTriangles(myParams);
	}

	public VBOParamsBase _0023_003DzmHTSerA_003D()
	{
		(int[], float[], float[], float[]) tuple = _0023_003DzpJQPsHlY4oQmipu6jA_003D_003D(_0023_003Dz1sjz__0024zu_mCM.ToArray());
		int[] item = tuple.Item1;
		float[] item2 = tuple.Item2;
		float[] item3 = tuple.Item3;
		float[] item4 = tuple.Item4;
		VBOParamsBase vBOParamsBase = null;
		if (item4 != null)
		{
			return new VBOParamsTexture
			{
				indices = item,
				vertices = item2,
				normals = item3,
				TextureCoordinates = item4,
				primitiveMode = primitiveType.TriangleList
			};
		}
		return new VBOParams
		{
			indices = item,
			vertices = item2,
			normals = item3,
			primitiveMode = primitiveType.TriangleList
		};
	}

	private (int[], float[], float[], float[]) _0023_003DzpJQPsHlY4oQmipu6jA_003D_003D(_0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D[] _0023_003Dzn6_2V_m6YPGJoNDgD6YmYY569gIG)
	{
		int num = _0023_003Dzn6_2V_m6YPGJoNDgD6YmYY569gIG.Length;
		int num2 = 0;
		int[] array = new int[num];
		int num3 = 0;
		int[] array2 = new int[num];
		int num4 = 0;
		int[] array3 = new int[num];
		int num5 = -1;
		int[] array4 = new int[num];
		for (int i = 0; i < num; i++)
		{
			FastMesh _0023_003DzRWfaTos_003D = _0023_003Dzn6_2V_m6YPGJoNDgD6YmYY569gIG[i]._0023_003DzRWfaTos_003D;
			array[i] = num2;
			array2[i] = num3;
			array3[i] = num4;
			num2 += _0023_003DzRWfaTos_003D.PointArray.Length;
			num3 += _0023_003DzRWfaTos_003D.TriangleArray.Length;
			num4 += ((_0023_003DzRWfaTos_003D.NormalArray != null) ? _0023_003DzRWfaTos_003D.NormalArray.Length : 0);
			if (_0023_003DzRWfaTos_003D.TextureCoordsArray != null)
			{
				if (num5 == -1)
				{
					num5 = 0;
				}
				array4[i] = num5;
				num5 += _0023_003DzRWfaTos_003D.TextureCoordsArray.Length;
			}
		}
		float[] array5 = new float[num2];
		float[] array6 = new float[num2];
		int[] array7 = new int[num3];
		float[] array8 = ((num5 != -1) ? new float[num5] : null);
		int num6 = 0;
		for (int j = 0; j < num; j++)
		{
			_0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D2 = _0023_003Dzn6_2V_m6YPGJoNDgD6YmYY569gIG[j];
			float[] pointArray = _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D2._0023_003DzRWfaTos_003D.PointArray;
			float[] array9 = _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D2._0023_003DzRWfaTos_003D.NormalArray ?? new float[0];
			int length = pointArray.Length;
			int num7 = array[j];
			int length2 = array9.Length;
			int destinationIndex = array3[j];
			Array.Copy(pointArray, 0, array5, num7, length);
			Array.Copy(array9, 0, array6, destinationIndex, length2);
			if (num5 != -1 && _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D2._0023_003DzRWfaTos_003D.TextureCoordsArray != null)
			{
				float[] textureCoordsArray = _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D2._0023_003DzRWfaTos_003D.TextureCoordsArray;
				float textureScaleU = _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D2._0023_003DzL2Ad0Sc_003D.TextureScaleU;
				float textureScaleV = _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D2._0023_003DzL2Ad0Sc_003D.TextureScaleV;
				float[,] transformationMatrix = Utility.GetTransformationMatrix(textureScaleU, textureScaleV, _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D2._0023_003DzL2Ad0Sc_003D.TextureOffsetU, _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D2._0023_003DzL2Ad0Sc_003D.TextureOffsetV, _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D2._0023_003DzL2Ad0Sc_003D.TextureRotationAngle);
				int num8 = 0;
				while (num8 < textureCoordsArray.Length)
				{
					float[] array10 = Matrix.Multiply(transformationMatrix, new float[3]
					{
						textureCoordsArray[num8++],
						textureCoordsArray[num8++],
						1f
					});
					array8[num6++] = array10[0];
					array8[num6++] = 1f - array10[1];
				}
			}
			int[] triangleArray = _0023_003Dzb2F0Dui7RGks4ARxJqE5972e5jaQ6yD35g_003D_003D2._0023_003DzRWfaTos_003D.TriangleArray;
			int num9 = triangleArray.Length;
			int num10 = num7 / 3;
			int num11 = 0;
			while (num11 < num9)
			{
				array7[array2[j] + num11] = triangleArray[num11++] + num10;
				array7[array2[j] + num11] = triangleArray[num11++] + num10;
				array7[array2[j] + num11] = triangleArray[num11++] + num10;
			}
		}
		return (array7, array5, array6, array8);
	}
}
