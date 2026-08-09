using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using System.Text.Json;
using SharpGLTF.IO;
using SharpGLTF.Reflection;
using SharpGLTF.Validation;

namespace SharpGLTF.Schema2;

[GeneratedCode("SharpGLTF.CodeGen", "1.0.0.0")]
[DebuggerDisplay("Camera[{LogicalIndex}] {Name} {_type}")]
public sealed class Camera : LogicalChildOfRoot
{
	public new const string SCHEMANAME = "camera";

	private CameraOrthographic _orthographic;

	private CameraPerspective _perspective;

	private CameraType _type;

	public ICamera Settings => GetCamera();

	public Matrix4x4 Matrix => GetCamera().Matrix;

	protected override string GetSchemaName()
	{
		return "camera";
	}

	protected override IEnumerable<string> ReflectFieldsNames()
	{
		yield return "orthographic";
		yield return "perspective";
		yield return "type";
		foreach (string item in base.ReflectFieldsNames())
		{
			yield return item;
		}
	}

	protected override bool TryReflectField(string name, out FieldInfo value)
	{
		switch (name)
		{
		case "orthographic":
			value = FieldInfo.From("orthographic", this, (Camera instance) => instance._orthographic);
			return true;
		case "perspective":
			value = FieldInfo.From("perspective", this, (Camera instance) => instance._perspective);
			return true;
		case "type":
			value = FieldInfo.From("type", this, (Camera instance) => instance._type);
			return true;
		default:
			return base.TryReflectField(name, out value);
		}
	}

	protected override void SerializeProperties(Utf8JsonWriter writer)
	{
		base.SerializeProperties(writer);
		JsonSerializable.SerializePropertyObject(writer, "orthographic", _orthographic);
		JsonSerializable.SerializePropertyObject(writer, "perspective", _perspective);
		JsonSerializable.SerializePropertyEnumSymbol<CameraType>(writer, "type", _type);
	}

	protected override void DeserializeProperty(string jsonPropertyName, ref Utf8JsonReader reader)
	{
		switch (jsonPropertyName)
		{
		case "orthographic":
			JsonSerializable.DeserializePropertyValue<Camera, CameraOrthographic>(ref reader, this, out _orthographic);
			break;
		case "perspective":
			JsonSerializable.DeserializePropertyValue<Camera, CameraPerspective>(ref reader, this, out _perspective);
			break;
		case "type":
			_type = JsonSerializable.DeserializePropertyValue<CameraType>(ref reader);
			break;
		default:
			base.DeserializeProperty(jsonPropertyName, ref reader);
			break;
		}
	}

	internal Camera()
	{
	}

	internal ICamera GetCamera()
	{
		if (_orthographic != null && _perspective != null)
		{
			return _type switch
			{
				CameraType.orthographic => _orthographic, 
				CameraType.perspective => _perspective, 
				_ => throw new NotImplementedException(), 
			};
		}
		if (_orthographic != null)
		{
			return _orthographic;
		}
		if (_perspective != null)
		{
			return _perspective;
		}
		return null;
	}

	public void SetOrthographicMode(float xmag, float ymag, float znear, float zfar)
	{
		CameraOrthographic.VerifyParameters(xmag, ymag, znear, zfar);
		_perspective = null;
		_orthographic = new CameraOrthographic(xmag, ymag, znear, zfar);
		_type = CameraType.orthographic;
	}

	public void SetPerspectiveMode(float? aspectRatio, float yfov, float znear, float zfar)
	{
		CameraPerspective.VerifyParameters(aspectRatio, yfov, znear, zfar);
		_orthographic = null;
		_perspective = new CameraPerspective(aspectRatio, yfov, znear, zfar);
		_type = CameraType.perspective;
	}

	protected override void OnValidateReferences(ValidationContext validate)
	{
		if (_type == CameraType.perspective)
		{
			validate.IsDefined("perspective", _perspective);
			validate.IsUndefined("orthographic", _orthographic);
		}
		if (_type == CameraType.orthographic)
		{
			validate.IsUndefined("perspective", _perspective);
			validate.IsDefined("orthographic", _orthographic);
		}
		base.OnValidateReferences(validate);
	}
}
