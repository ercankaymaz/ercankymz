using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;

namespace SharpGLTF.Schema2;

[DebuggerDisplay("{_Key} = {Value}")]
internal readonly struct _MaterialParameter<T> : IMaterialParameter where T : unmanaged, IEquatable<T>
{
	private readonly _MaterialParameterKey _Key;

	private readonly T _ValueDefault;

	private readonly Func<T> _ValueGetter;

	private readonly Action<T> _ValueSetter;

	public string Name => _Key.ToString();

	public bool IsDefault => Value.Equals(_ValueDefault);

	public Type ValueType => _ValueDefault.GetType();

	public T Value
	{
		get
		{
			return _ValueGetter();
		}
		set
		{
			_ValueSetter(value);
		}
	}

	object IMaterialParameter.Value
	{
		get
		{
			return _ValueGetter();
		}
		set
		{
			_ValueSetter((T)value);
		}
	}

	internal _MaterialParameter(_MaterialParameterKey key, T defval, Func<T> getter, Action<T> setter)
	{
		_Key = key;
		_ValueDefault = defval;
		_ValueGetter = () => getter();
		_ValueSetter = delegate(T value)
		{
			setter(value);
		};
	}

	internal static Vector4 Combine(IReadOnlyList<IMaterialParameter> parameters)
	{
		//IL_019c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0083: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e0: Unknown result type (might be due to invalid IL or missing references)
		//IL_010b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0124: Unknown result type (might be due to invalid IL or missing references)
		//IL_013d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		Span<float> span = stackalloc float[4];
		int num = 0;
		foreach (IMaterialParameter parameter in parameters)
		{
			if (parameter is _MaterialParameter<float> materialParameter)
			{
				span[num++] = materialParameter.Value;
			}
			if (parameter is _MaterialParameter<Vector2> materialParameter2)
			{
				span[num++] = materialParameter2.Value.X;
				span[num++] = materialParameter2.Value.Y;
			}
			if (parameter is _MaterialParameter<Vector3> materialParameter3)
			{
				span[num++] = materialParameter3.Value.X;
				span[num++] = materialParameter3.Value.Y;
				span[num++] = materialParameter3.Value.Z;
			}
			if (parameter is _MaterialParameter<Vector4> materialParameter4)
			{
				span[num++] = materialParameter4.Value.X;
				span[num++] = materialParameter4.Value.Y;
				span[num++] = materialParameter4.Value.Z;
				span[num++] = materialParameter4.Value.W;
			}
		}
		return new Vector4(span[0], span[1], span[2], span[3]);
	}

	internal static void Apply(IReadOnlyList<IMaterialParameter> parameters, Vector4 value)
	{
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0034: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ef: Unknown result type (might be due to invalid IL or missing references)
		//IL_013b: Unknown result type (might be due to invalid IL or missing references)
		Span<float> span = stackalloc float[4];
		span[0] = value.X;
		span[1] = value.Y;
		span[2] = value.Z;
		span[3] = value.W;
		int num = 0;
		foreach (IMaterialParameter parameter in parameters)
		{
			if (parameter is _MaterialParameter<float> materialParameter)
			{
				materialParameter.Value = span[num++];
			}
			if (parameter is _MaterialParameter<Vector2> materialParameter2)
			{
				materialParameter2.Value = new Vector2(span[num], span[num + 1]);
				num += 2;
			}
			if (parameter is _MaterialParameter<Vector3> materialParameter3)
			{
				materialParameter3.Value = new Vector3(span[num], span[num + 1], span[num + 2]);
				num += 3;
			}
			if (parameter is _MaterialParameter<Vector4> materialParameter4)
			{
				materialParameter4.Value = new Vector4(span[num], span[num + 1], span[num + 2], span[num + 3]);
				num += 4;
			}
		}
	}
}
