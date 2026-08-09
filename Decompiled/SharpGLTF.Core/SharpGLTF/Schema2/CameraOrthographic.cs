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
[DebuggerDisplay("Orthographic ({XMag},{YMag})  {ZNear} < {ZFar}")]
public sealed class CameraOrthographic : ExtraProperties, ICamera
{
	public new const string SCHEMANAME = "orthographic";

	private double _xmag;

	private double _ymag;

	private const double _zfarExclusiveMinimum = 0.0;

	private double _zfar;

	private const double _znearMinimum = 0.0;

	private double _znear;

	public bool IsPerspective => false;

	public bool IsOrthographic => true;

	public float XMag => (float)_xmag;

	public float YMag => (float)_ymag;

	public float ZNear => (float)_znear;

	public float ZFar => (float)_zfar;

	public Matrix4x4 Matrix => Projection.CreateOrthographicMatrix(XMag, YMag, ZNear, ZFar);

	protected override string GetSchemaName()
	{
		return "orthographic";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "xmag";
		yield return "ymag";
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
		case "xmag":
			value = FieldInfo.From("xmag", this, (CameraOrthographic instance) => instance._xmag);
			return true;
		case "ymag":
			value = FieldInfo.From("ymag", this, (CameraOrthographic instance) => instance._ymag);
			return true;
		case "zfar":
			value = FieldInfo.From("zfar", this, (CameraOrthographic instance) => instance._zfar);
			return true;
		case "znear":
			value = FieldInfo.From("znear", this, (CameraOrthographic instance) => instance._znear);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializeProperty(writer, "xmag", _xmag);
		JsonSerializable.SerializeProperty(writer, "ymag", _ymag);
		JsonSerializable.SerializeProperty(writer, "zfar", _zfar);
		JsonSerializable.SerializeProperty(writer, "znear", _znear);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "xmag":
			JsonSerializable.DeserializePropertyValue<CameraOrthographic, double>(ref reader, this, out _xmag);
			break;
		case "ymag":
			JsonSerializable.DeserializePropertyValue<CameraOrthographic, double>(ref reader, this, out _ymag);
			break;
		case "zfar":
			JsonSerializable.DeserializePropertyValue<CameraOrthographic, double>(ref reader, this, out _zfar);
			break;
		case "znear":
			JsonSerializable.DeserializePropertyValue<CameraOrthographic, double>(ref reader, this, out _znear);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal CameraOrthographic()
	{
	}

	internal CameraOrthographic(float xmag, float ymag, float znear, float zfar)
	{
		_xmag = xmag;
		_ymag = ymag;
		_znear = znear;
		_zfar = zfar;
	}

	public static void VerifyParameters(float xmag, float ymag, float znear, float zfar)
	{
		Guard.MustBeGreaterThanOrEqualTo(znear, 0f, "znear");
		Guard.MustBeGreaterThan(zfar, 0f, "zfar");
		Guard.MustBeGreaterThan(zfar, znear, "zfar");
		Guard.MustBeLessThan(zfar, float.PositiveInfinity, "zfar");
		Guard.MustBeGreaterThan(xmag, 0f, "xmag");
		Guard.MustBeGreaterThan(ymag, 0f, "ymag");
	}

	protected override void OnValidateContent(ValidationContext validate)
	{
		validate.That(delegate
		{
			VerifyParameters(XMag, YMag, ZNear, ZFar);
		});
		base.OnValidateContent(validate);
	}
}
