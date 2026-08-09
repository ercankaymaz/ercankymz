using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("TextureTransform {Offset} {Scale} {Rotation} {TextureCoordinate}")]
public sealed class TextureTransform : ExtraProperties
{
	public new const string SCHEMANAME = "KHR_texture_transform";

	private static readonly Vector2 _offsetDefault = Vector2.Zero;

	private Vector2? _offset = _offsetDefault;

	private const double _rotationDefault = 0.0;

	private double? _rotation = 0.0;

	private static readonly Vector2 _scaleDefault = Vector2.One;

	private Vector2? _scale = _scaleDefault;

	private const int _texCoordMinimum = 0;

	private int? _texCoord;

	public Vector2 Offset
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return _offset.AsValue<Vector2>(_offsetDefault);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_offset = value.AsNullable<Vector2>(_offsetDefault);
		}
	}

	public Vector2 Scale
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			return _scale.AsValue<Vector2>(_scaleDefault);
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_scale = value.AsNullable<Vector2>(_scaleDefault);
		}
	}

	public float Rotation
	{
		get
		{
			return (float)_rotation.AsValue(0.0);
		}
		set
		{
			_rotation = _Schema2Extensions.AsNullable(value, 0.0);
		}
	}

	public int? TextureCoordinateOverride
	{
		get
		{
			return _texCoord;
		}
		set
		{
			_texCoord = value;
		}
	}

	internal bool IsDefault
	{
		get
		{
			if (_texCoord.HasValue)
			{
				return false;
			}
			if (_offset.HasValue)
			{
				return false;
			}
			if (_scale.HasValue)
			{
				return false;
			}
			if (_rotation.HasValue)
			{
				return false;
			}
			return true;
		}
	}

	public Matrix3x2 Matrix
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			//IL_0013: Unknown result type (might be due to invalid IL or missing references)
			//IL_0018: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0024: Unknown result type (might be due to invalid IL or missing references)
			//IL_0025: Unknown result type (might be due to invalid IL or missing references)
			//IL_0026: Unknown result type (might be due to invalid IL or missing references)
			//IL_0027: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_002d: Unknown result type (might be due to invalid IL or missing references)
			Matrix3x2 val = Matrix3x2.CreateScale(Scale);
			Matrix3x2 val2 = Matrix3x2.CreateRotation(0f - Rotation);
			Matrix3x2 val3 = Matrix3x2.CreateTranslation(Offset);
			return val * val2 * val3;
		}
	}

	protected override string GetSchemaName()
	{
		return "KHR_texture_transform";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "offset";
		yield return "rotation";
		yield return "scale";
		yield return "texCoord";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "offset":
			value = FieldInfo.From("offset", this, (TextureTransform instance) => (Vector2)(((_003F?)instance._offset) ?? Vector2.Zero));
			return true;
		case "rotation":
			value = FieldInfo.From("rotation", this, (TextureTransform instance) => instance._rotation.GetValueOrDefault());
			return true;
		case "scale":
			value = FieldInfo.From("scale", this, (TextureTransform instance) => (Vector2)(((_003F?)instance._scale) ?? Vector2.One));
			return true;
		case "texCoord":
			value = FieldInfo.From("texCoord", this, (TextureTransform instance) => instance._texCoord);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Unknown result type (might be due to invalid IL or missing references)
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "offset", _offset, _offsetDefault);
		JsonSerializable.SerializeProperty(writer, "rotation", _rotation, 0.0);
		JsonSerializable.SerializeProperty(writer, "scale", _scale, _scaleDefault);
		JsonSerializable.SerializeProperty(writer, "texCoord", _texCoord);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "offset":
			JsonSerializable.DeserializePropertyValue<TextureTransform, Vector2?>(ref reader, this, out _offset);
			break;
		case "rotation":
			JsonSerializable.DeserializePropertyValue<TextureTransform, double?>(ref reader, this, out _rotation);
			break;
		case "scale":
			JsonSerializable.DeserializePropertyValue<TextureTransform, Vector2?>(ref reader, this, out _scale);
			break;
		case "texCoord":
			JsonSerializable.DeserializePropertyValue<TextureTransform, int?>(ref reader, this, out _texCoord);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal TextureTransform(TextureInfo parent)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)
	//IL_0025: Unknown result type (might be due to invalid IL or missing references)

}
