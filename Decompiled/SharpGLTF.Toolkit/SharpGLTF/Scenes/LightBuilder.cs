using System;
using System.Diagnostics;
using System.Numerics;
using SharpGLTF.Schema2;

namespace SharpGLTF.Scenes;

public abstract class LightBuilder : BaseBuilder
{
	[DebuggerDisplay("LightBuilder.Directional")]
	public sealed class Directional : LightBuilder
	{
		public Directional()
		{
		}

		internal Directional(PunctualLight light)
			: base(light)
		{
		}

		public override LightBuilder Clone()
		{
			return new Directional(this);
		}

		private Directional(Directional other)
			: base(other)
		{
		}
	}

	[DebuggerDisplay("LightBuilder.Point")]
	public sealed class Point : LightBuilder
	{
		public float Range { get; set; }

		public Point()
		{
			Range = float.PositiveInfinity;
		}

		internal Point(PunctualLight light)
			: base(light)
		{
			Range = light.Range;
		}

		public override LightBuilder Clone()
		{
			return new Point(this);
		}

		private Point(Point other)
			: base(other)
		{
			Range = other.Range;
		}
	}

	[DebuggerDisplay("LightBuilder.Spot")]
	public sealed class Spot : LightBuilder
	{
		public float Range { get; set; }

		public float InnerConeAngle { get; set; }

		public float OuterConeAngle { get; set; }

		public Spot()
		{
			Range = float.PositiveInfinity;
			InnerConeAngle = 0f;
			OuterConeAngle = MathF.PI / 4f;
		}

		internal Spot(PunctualLight light)
			: base(light)
		{
			Range = light.Range;
			InnerConeAngle = light.InnerConeAngle;
			OuterConeAngle = light.OuterConeAngle;
		}

		public override LightBuilder Clone()
		{
			return new Spot(this);
		}

		private Spot(Spot other)
			: base(other)
		{
			Range = other.Range;
			InnerConeAngle = other.InnerConeAngle;
			OuterConeAngle = other.OuterConeAngle;
		}
	}

	public static Vector3 LocalDirection => -Vector3.UnitZ;

	public Vector3 Color { get; set; }

	public float Intensity { get; set; }

	protected LightBuilder()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		Color = Vector3.One;
		Intensity = 1f;
	}

	protected LightBuilder(PunctualLight light)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(light, "light");
		SetNameAndExtrasFrom(light);
		Color = light.Color;
		Intensity = light.Intensity;
	}

	public abstract LightBuilder Clone();

	protected LightBuilder(LightBuilder other)
		: base(other)
	{
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		SharpGLTF.Guard.NotNull(other, "other");
		Color = other.Color;
		Intensity = other.Intensity;
	}
}
