using System.Diagnostics;
using System.Numerics;

namespace SharpGLTF.Materials;

[DebuggerDisplay("Transform \ud835\udc12:{Scale} \ud835\udc11:{Rotation} \ud835\udebb:{Offset}")]
public class TextureTransformBuilder
{
	public Vector2 Offset { get; set; }

	public Vector2 Scale { get; set; } = Vector2.One;

	public float Rotation { get; set; }

	public int? CoordinateSetOverride { get; set; }

	internal bool IsDefault
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			if (Offset != Vector2.Zero)
			{
				return false;
			}
			if (Scale != Vector2.One)
			{
				return false;
			}
			if (Rotation != 0f)
			{
				return false;
			}
			if (CoordinateSetOverride.HasValue)
			{
				return false;
			}
			return true;
		}
	}

	internal TextureTransformBuilder(Vector2 offset, Vector2 scale, float rotation = 0f, int? coordSetOverride = null)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		Offset = offset;
		Scale = scale;
		Rotation = rotation;
		CoordinateSetOverride = coordSetOverride;
	}

	internal TextureTransformBuilder(TextureTransformBuilder other)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		Offset = other?.Offset ?? Vector2.Zero;
		Scale = other?.Scale ?? Vector2.One;
		Rotation = other?.Rotation ?? 0f;
		CoordinateSetOverride = other?.CoordinateSetOverride;
	}

	public static bool AreEqualByContent(TextureTransformBuilder a, TextureTransformBuilder b)
	{
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		if (a != null && a.IsDefault)
		{
			a = null;
		}
		if (b != null && b.IsDefault)
		{
			b = null;
		}
		if (a == b)
		{
			return true;
		}
		if (a == null)
		{
			return false;
		}
		if (b == null)
		{
			return false;
		}
		if (a.Offset != b.Offset)
		{
			return false;
		}
		if (a.Scale != b.Scale)
		{
			return false;
		}
		if (a.Rotation != b.Rotation)
		{
			return false;
		}
		if (a.CoordinateSetOverride != b.CoordinateSetOverride)
		{
			return false;
		}
		return true;
	}
}
