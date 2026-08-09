using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Schema2;
using SharpGLTF.Transforms;

namespace SharpGLTF.Scenes;

public abstract class CameraBuilder : BaseBuilder
{
	[DebuggerDisplay("CameraBuilder.Orthographic ({XMag},{YMag})  {ZNear} < {ZFar}")]
	public sealed class Orthographic : CameraBuilder
	{
		public float XMag { get; set; }

		public float YMag { get; set; }

		public Orthographic(float xmag, float ymag, float znear, float zfar)
			: base(znear, zfar)
		{
			XMag = xmag;
			YMag = ymag;
		}

		internal Orthographic(CameraOrthographic ortho)
			: base(ortho.ZFar, ortho.ZFar)
		{
			XMag = ortho.XMag;
			YMag = ortho.YMag;
		}

		public override CameraBuilder Clone()
		{
			return new Orthographic(this);
		}

		private Orthographic(Orthographic ortho)
			: base(ortho)
		{
			XMag = ortho.XMag;
			YMag = ortho.YMag;
		}

		protected override Matrix4x4 GetMatrix()
		{
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			return Projection.CreateOrthographicMatrix(XMag, YMag, base.ZNear, base.ZFar);
		}
	}

	[DebuggerDisplay("CameraBuilder.Perspective {AspectRatio} {VerticalFOV}   {ZNear} < {ZFar}")]
	public sealed class Perspective : CameraBuilder
	{
		public float? AspectRatio { get; set; }

		public float VerticalFOV { get; set; }

		public Perspective(float? aspectRatio, float fovy, float znear, float zfar = float.PositiveInfinity)
			: base(znear, zfar)
		{
			AspectRatio = aspectRatio;
			VerticalFOV = fovy;
		}

		internal Perspective(CameraPerspective persp)
			: base(persp.ZNear, persp.ZFar)
		{
			AspectRatio = persp.AspectRatio;
			VerticalFOV = persp.VerticalFOV;
		}

		public override CameraBuilder Clone()
		{
			return new Perspective(this);
		}

		private Perspective(Perspective persp)
			: base(persp)
		{
			AspectRatio = persp.AspectRatio;
			VerticalFOV = persp.VerticalFOV;
		}

		protected override Matrix4x4 GetMatrix()
		{
			//IL_0030: Unknown result type (might be due to invalid IL or missing references)
			return Projection.CreateOrthographicMatrix(AspectRatio ?? 1f, VerticalFOV, base.ZNear, base.ZFar);
		}
	}

	public static Vector3 LocalDirection => -Vector3.UnitZ;

	public float ZNear { get; set; }

	public float ZFar { get; set; }

	public bool IsValid
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			try
			{
				GetMatrix();
				return true;
			}
			catch
			{
				return false;
			}
		}
	}

	public Matrix4x4 Matrix => GetMatrix();

	public abstract CameraBuilder Clone();

	protected CameraBuilder(float znear, float zfar)
	{
		ZNear = znear;
		ZFar = zfar;
	}

	protected CameraBuilder(CameraBuilder other)
		: base(other)
	{
		SharpGLTF.Guard.NotNull(other, "other");
		ZNear = other.ZNear;
		ZFar = other.ZFar;
	}

	protected abstract Matrix4x4 GetMatrix();
}
