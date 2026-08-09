using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Transforms;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("Perspective {AspectRatio} {VerticalFOV}   {ZNear} < {ZFar}")]
public sealed class CameraPerspective : ExtraProperties, ICamera
{
	public new const string SCHEMANAME = "perspective";

	private const double _aspectRatioExclusiveMinimum = 0.0;

	private double? _aspectRatio;

	private const double _yfovExclusiveMinimum = 0.0;

	private double _yfov;

	private const double _zfarExclusiveMinimum = 0.0;

	private double? _zfar;

	private const double _znearExclusiveMinimum = 0.0;

	private double _znear;

	public bool IsOrthographic => false;

	public bool IsPerspective => true;

	public float? AspectRatio => (float?)(_aspectRatio ?? ((double?)null));

	public float VerticalFOV => (float)_yfov;

	public float ZNear => (float)_znear;

	public float ZFar
	{
		get
		{
			if (!_zfar.HasValue)
			{
				return float.PositiveInfinity;
			}
			return (float)_zfar.Value;
		}
	}

	public Matrix4x4 Matrix => Projection.CreateOrthographicMatrix(AspectRatio.AsValue(1f), VerticalFOV, ZNear, ZFar);

	protected override string GetSchemaName()
	{
		return "perspective";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "aspectRatio";
		yield return "yfov";
		yield return "zfar";
		yield return "znear";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "aspectRatio":
			value = FieldInfo.From("aspectRatio", this, (CameraPerspective instance) => instance._aspectRatio);
			return true;
		case "yfov":
			value = FieldInfo.From("yfov", this, (CameraPerspective instance) => instance._yfov);
			return true;
		case "zfar":
			value = FieldInfo.From("zfar", this, (CameraPerspective instance) => instance._zfar);
			return true;
		case "znear":
			value = FieldInfo.From("znear", this, (CameraPerspective instance) => instance._znear);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "aspectRatio", _aspectRatio);
		JsonSerializable.SerializeProperty(writer, "yfov", _yfov);
		JsonSerializable.SerializeProperty(writer, "zfar", _zfar);
		JsonSerializable.SerializeProperty(writer, "znear", _znear);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "aspectRatio":
			JsonSerializable.DeserializePropertyValue<CameraPerspective, double?>(ref reader, this, out _aspectRatio);
			break;
		case "yfov":
			JsonSerializable.DeserializePropertyValue<CameraPerspective, double>(ref reader, this, out _yfov);
			break;
		case "zfar":
			JsonSerializable.DeserializePropertyValue<CameraPerspective, double?>(ref reader, this, out _zfar);
			break;
		case "znear":
			JsonSerializable.DeserializePropertyValue<CameraPerspective, double>(ref reader, this, out _znear);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal CameraPerspective()
	{
	}

	internal CameraPerspective(float? aspectRatio, float yfov, float znear, float zfar)
	{
		VerifyParameters(aspectRatio, yfov, znear, zfar);
		_aspectRatio = aspectRatio ?? ((float?)null);
		_yfov = yfov;
		_znear = znear;
		_zfar = (float.IsPositiveInfinity(zfar) ? ((double?)null) : new double?(zfar));
	}

	public static void VerifyParameters(float? aspectRatio, float yfov, float znear, float zfar = float.PositiveInfinity)
	{
		Guard.MustBeGreaterThan(aspectRatio.AsValue(1f), 0f, "aspectRatio");
		Guard.MustBeGreaterThan(yfov, 0f, "yfov");
		Guard.MustBeGreaterThan(znear, 0f, "znear");
		Guard.MustBeGreaterThan(zfar, 0f, "zfar");
		Guard.MustBeGreaterThan(zfar, znear, "zfar");
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		validate.That(delegate
		{
			VerifyParameters(AspectRatio, VerticalFOV, ZNear, ZFar);
		});
		base.OnValidateContent(validate);
	}
}
