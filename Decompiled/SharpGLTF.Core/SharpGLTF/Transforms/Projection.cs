using System;
using System.Numerics;

namespace SharpGLTF.Transforms;

public static class Projection
{
	public static Matrix4x4 CreateOrthographicMatrix(float xmag, float ymag, float znear, float zfar)
	{
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		Guard.MustBeGreaterThanOrEqualTo(znear, 0f, "znear");
		Guard.MustBeGreaterThanOrEqualTo(zfar, 0f, "zfar");
		Guard.MustBeGreaterThan(zfar, znear, "zfar");
		Guard.MustBeLessThan(zfar, float.PositiveInfinity, "zfar");
		float num = znear - zfar;
		float num2 = 1f / xmag;
		float num3 = 1f / ymag;
		float num4 = 2f / num;
		float num5 = (zfar + znear) / num;
		return new Matrix4x4(num2, 0f, 0f, 0f, 0f, num3, 0f, 0f, 0f, 0f, num4, num5, 0f, 0f, 0f, 1f);
	}

	public static Matrix4x4 CreatePerspectiveMatrix(float aspectRatio, float yfov, float znear, float zfar = float.PositiveInfinity)
	{
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		Guard.MustBeGreaterThan(aspectRatio, 0f, "aspectRatio");
		Guard.MustBeGreaterThan(yfov, 0f, "yfov");
		Guard.MustBeLessThan(yfov, MathF.PI, "yfov");
		Guard.MustBeGreaterThanOrEqualTo(znear, 0f, "znear");
		Guard.MustBeGreaterThanOrEqualTo(zfar, 0f, "zfar");
		Guard.MustBeGreaterThan(zfar, znear, "zfar");
		float num = (float)Math.Tan(0.5 * (double)yfov);
		float num2 = aspectRatio * num;
		float num3 = 1f / num2;
		float num4 = 1f / num;
		float num5 = -1f;
		float num6 = -2f * znear;
		if (!float.IsPositiveInfinity(zfar))
		{
			float num7 = znear - zfar;
			num5 = (zfar + znear) / num7;
			num6 = 2f * zfar * znear / num7;
		}
		return new Matrix4x4(num3, 0f, 0f, 0f, 0f, num4, 0f, 0f, 0f, 0f, num5, num6, 0f, 0f, -1f, 0f);
	}
}
