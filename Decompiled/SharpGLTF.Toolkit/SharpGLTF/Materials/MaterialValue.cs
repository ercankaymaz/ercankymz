using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace SharpGLTF.Materials;

[DebuggerDisplay("{ToString(),nq}")]
public readonly struct MaterialValue : IEquatable<MaterialValue>
{
	[DebuggerDisplay("{ToString(),nq}")]
	internal sealed class _Property : IEquatable<_Property>
	{
		private readonly MaterialValue _Default;

		private MaterialValue _Value;

		public KnownProperty Key { get; }

		public string Name => Key.ToString();

		public MaterialValue Value
		{
			get
			{
				return _Value;
			}
			set
			{
				if (value._Length != _Default._Length)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_Value = value;
			}
		}

		internal _Property(KnownProperty key, float value)
		{
			Key = key;
			_Default = value;
			Value = _Default;
		}

		internal _Property(KnownProperty key, Vector2 value)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Key = key;
			_Default = value;
			Value = _Default;
		}

		internal _Property(KnownProperty key, Vector3 value)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Key = key;
			_Default = value;
			Value = _Default;
		}

		internal _Property(KnownProperty key, Vector4 value)
		{
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			Key = key;
			_Default = value;
			Value = _Default;
		}

		public override int GetHashCode()
		{
			return Key.GetHashCode() ^ _Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is _Property other)
			{
				return Equals(other);
			}
			return false;
		}

		public bool Equals(_Property other)
		{
			return AreEqual(this, other);
		}

		public static bool operator ==(_Property a, _Property b)
		{
			return a.Equals(b);
		}

		public static bool operator !=(_Property a, _Property b)
		{
			return !a.Equals(b);
		}

		public static bool AreEqual(_Property a, _Property b)
		{
			if (a.Key != b.Key)
			{
				return false;
			}
			if (!a._Default.Equals(b._Default))
			{
				return false;
			}
			if (!a._Value.Equals(b._Value))
			{
				return false;
			}
			return true;
		}

		public void SetDefault()
		{
			_Value = _Default;
		}

		public override string ToString()
		{
			return new KeyValuePair<string, MaterialValue>(Name, Value).ToString();
		}
	}

	[DebuggerDisplay("{_GetDebuggerDisplay(),nq}")]
	public sealed class Collection : IReadOnlyDictionary<KnownProperty, MaterialValue>, IEnumerable<KeyValuePair<KnownProperty, MaterialValue>>, IEnumerable, IReadOnlyCollection<KeyValuePair<KnownProperty, MaterialValue>>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		private readonly _Property[] _Properties;

		public MaterialValue this[KnownProperty key]
		{
			get
			{
				return _Properties.First((_Property item) => item.Key == key).Value;
			}
			set
			{
				int num = Array.FindIndex(_Properties, (_Property item) => item.Key == key);
				if (num < 0)
				{
					throw new KeyNotFoundException(key.ToString());
				}
				_Properties[num].Value = value;
			}
		}

		public MaterialValue this[string keyName]
		{
			get
			{
				if (!Enum.TryParse<KnownProperty>(keyName, out var result))
				{
					throw new KeyNotFoundException(keyName);
				}
				return this[result];
			}
			set
			{
				if (!Enum.TryParse<KnownProperty>(keyName, out var result))
				{
					throw new KeyNotFoundException(keyName);
				}
				this[result] = value;
			}
		}

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IEnumerable<KnownProperty> Keys => _Properties.Select((_Property item) => item.Key);

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public IEnumerable<MaterialValue> Values => _Properties.Select((_Property item) => item.Value);

		public int Count => _Properties.Length;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Vector4 CombinedVector
		{
			get
			{
				//IL_006e: Unknown result type (might be due to invalid IL or missing references)
				Span<float> span = stackalloc float[4];
				int num = 0;
				_Property[] properties = _Properties;
				foreach (_Property property in properties)
				{
					num += property.Value._CopyTo(span.Slice(num));
				}
				return new Vector4(span[0], span[1], span[2], span[3]);
			}
			set
			{
				//IL_0016: Unknown result type (might be due to invalid IL or missing references)
				//IL_0025: Unknown result type (might be due to invalid IL or missing references)
				//IL_0034: Unknown result type (might be due to invalid IL or missing references)
				//IL_0043: Unknown result type (might be due to invalid IL or missing references)
				//IL_00c8: Unknown result type (might be due to invalid IL or missing references)
				//IL_010f: Unknown result type (might be due to invalid IL or missing references)
				//IL_0161: Unknown result type (might be due to invalid IL or missing references)
				Span<float> span = stackalloc float[4];
				span[0] = value.X;
				span[1] = value.Y;
				span[2] = value.Z;
				span[3] = value.W;
				int num = 0;
				_Property[] properties = _Properties;
				foreach (_Property property in properties)
				{
					Type valueType = property.Value.ValueType;
					if (valueType == typeof(float))
					{
						property.Value = span[num++];
					}
					if (valueType == typeof(Vector2))
					{
						property.Value = (MaterialValue)new Vector2(span[num], span[num + 1]);
						num += 2;
					}
					if (valueType == typeof(Vector3))
					{
						property.Value = (MaterialValue)new Vector3(span[num], span[num + 1], span[num + 2]);
						num += 3;
					}
					if (valueType == typeof(Vector4))
					{
						property.Value = (MaterialValue)new Vector4(span[num], span[num + 1], span[num + 2], span[num + 3]);
						num += 4;
					}
				}
			}
		}

		private string _GetDebuggerDisplay()
		{
			return string.Join(", ", _Properties.Select((_Property item) => item.ToString()));
		}

		internal Collection(_Property[] properties)
		{
			_Properties = properties;
		}

		public override int GetHashCode()
		{
			int num = 0;
			_Property[] properties = _Properties;
			foreach (_Property property in properties)
			{
				num ^= property.GetHashCode();
			}
			return num;
		}

		public static bool AreEqual(Collection x, Collection y)
		{
			SharpGLTF.Guard.NotNull(x, "x");
			SharpGLTF.Guard.NotNull(y, "y");
			if (x._Properties.Length != y._Properties.Length)
			{
				return false;
			}
			for (int i = 0; i < x._Properties.Length; i++)
			{
				_Property property = x._Properties[i];
				_Property property2 = y._Properties[i];
				if (property.Name != property2.Name)
				{
					return false;
				}
				if (property.Value != property2.Value)
				{
					return false;
				}
			}
			return true;
		}

		public bool ContainsKey(KnownProperty key)
		{
			return _Properties.Any((_Property item) => item.Key == key);
		}

		public bool TryGetValue(KnownProperty key, out MaterialValue value)
		{
			int num = Array.FindIndex(_Properties, (_Property item) => item.Key == key);
			if (num < 0)
			{
				value = default(MaterialValue);
				return false;
			}
			value = _Properties[num].Value;
			return true;
		}

		public IEnumerator<KeyValuePair<KnownProperty, MaterialValue>> GetEnumerator()
		{
			return _Properties.Select((_Property item) => new KeyValuePair<KnownProperty, MaterialValue>(item.Key, item.Value)).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _Properties.Select((_Property item) => new KeyValuePair<KnownProperty, MaterialValue>(item.Key, item.Value)).GetEnumerator();
		}

		public void Reset()
		{
			_Property[] properties = _Properties;
			foreach (_Property property in properties)
			{
				property.SetDefault();
			}
		}

		public void CopyTo(Collection other)
		{
			SharpGLTF.Guard.NotNull(other, "other");
			for (int i = 0; i < _Properties.Length; i++)
			{
				_Property property = _Properties[i];
				_Property property2 = other._Properties[i];
				if (property.Name != property2.Name)
				{
					throw new ArgumentException("Naming mismatch.", "other");
				}
				property2.Value = property.Value;
			}
		}
	}

	private readonly int _Length;

	private readonly float _X;

	private readonly float _Y;

	private readonly float _Z;

	private readonly float _W;

	public Type ValueType => _Length switch
	{
		1 => typeof(float), 
		2 => typeof(Vector2), 
		3 => typeof(Vector3), 
		4 => typeof(Vector4), 
		_ => throw new InvalidOperationException($"{_Length} not supported."), 
	};

	internal static Collection CreateDefaultProperties(KnownChannel key)
	{
		_Property[] properties = _CreateDefaultProperties(key).ToArray();
		Collection collection = new Collection(properties);
		collection.Reset();
		return collection;
	}

	private static IEnumerable<_Property> _CreateDefaultProperties(KnownChannel key)
	{
		switch (key)
		{
		case KnownChannel.Emissive:
			yield return new _Property(KnownProperty.RGB, Vector3.Zero);
			yield return new _Property(KnownProperty.EmissiveStrength, 1f);
			break;
		case KnownChannel.Normal:
			yield return new _Property(KnownProperty.NormalScale, 1f);
			break;
		case KnownChannel.Occlusion:
			yield return new _Property(KnownProperty.OcclusionStrength, 1f);
			break;
		case KnownChannel.Diffuse:
			yield return new _Property(KnownProperty.RGBA, Vector4.One);
			break;
		case KnownChannel.SpecularGlossiness:
			yield return new _Property(KnownProperty.SpecularFactor, Vector3.One);
			yield return new _Property(KnownProperty.GlossinessFactor, 1f);
			break;
		case KnownChannel.BaseColor:
			yield return new _Property(KnownProperty.RGBA, Vector4.One);
			break;
		case KnownChannel.MetallicRoughness:
			yield return new _Property(KnownProperty.MetallicFactor, 1f);
			yield return new _Property(KnownProperty.RoughnessFactor, 1f);
			break;
		case KnownChannel.ClearCoat:
			yield return new _Property(KnownProperty.ClearCoatFactor, 0f);
			break;
		case KnownChannel.ClearCoatNormal:
			yield return new _Property(KnownProperty.NormalScale, 1f);
			break;
		case KnownChannel.ClearCoatRoughness:
			yield return new _Property(KnownProperty.RoughnessFactor, 0f);
			break;
		case KnownChannel.Transmission:
			yield return new _Property(KnownProperty.TransmissionFactor, 0f);
			break;
		case KnownChannel.SheenColor:
			yield return new _Property(KnownProperty.RGB, Vector3.Zero);
			break;
		case KnownChannel.SheenRoughness:
			yield return new _Property(KnownProperty.RoughnessFactor, 0f);
			break;
		case KnownChannel.SpecularColor:
			yield return new _Property(KnownProperty.RGB, Vector3.One);
			break;
		case KnownChannel.SpecularFactor:
			yield return new _Property(KnownProperty.SpecularFactor, 1f);
			break;
		case KnownChannel.VolumeThickness:
			yield return new _Property(KnownProperty.ThicknessFactor, 0f);
			break;
		case KnownChannel.VolumeAttenuation:
			yield return new _Property(KnownProperty.RGB, Vector3.One);
			yield return new _Property(KnownProperty.AttenuationDistance, float.PositiveInfinity);
			break;
		case KnownChannel.Iridescence:
			yield return new _Property(KnownProperty.IridescenceFactor, 0f);
			yield return new _Property(KnownProperty.IndexOfRefraction, 1.3f);
			break;
		case KnownChannel.IridescenceThickness:
			yield return new _Property(KnownProperty.Minimum, 100f);
			yield return new _Property(KnownProperty.Maximum, 400f);
			break;
		case KnownChannel.Anisotropy:
			yield return new _Property(KnownProperty.AnisotropyStrength, 0f);
			yield return new _Property(KnownProperty.AnisotropyRotation, 0f);
			break;
		case KnownChannel.DiffuseTransmissionFactor:
			yield return new _Property(KnownProperty.DiffuseTransmissionFactor, 20f);
			break;
		case KnownChannel.DiffuseTransmissionColor:
			yield return new _Property(KnownProperty.RGB, Vector3.One);
			break;
		default:
			throw new NotImplementedException();
		}
	}

	public static implicit operator MaterialValue(float value)
	{
		return new MaterialValue(value);
	}

	public static implicit operator MaterialValue(Vector2 value)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return new MaterialValue(value.X, value.Y);
	}

	public static implicit operator MaterialValue(Vector3 value)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		return new MaterialValue(value.X, value.Y, value.Z);
	}

	public static implicit operator MaterialValue(Vector4 value)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		return new MaterialValue(value.X, value.Y, value.Z, value.W);
	}

	public static MaterialValue CreateFrom(object value)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		if (value is float num)
		{
			return num;
		}
		if (value is Vector2 val)
		{
			return val;
		}
		if (value is Vector3 val2)
		{
			return val2;
		}
		if (value is Vector4 val3)
		{
			return val3;
		}
		throw new ArgumentException("Value type not supported.", "value");
	}

	private MaterialValue(float x)
	{
		_Length = 1;
		_X = x;
		_Y = 0f;
		_Z = 0f;
		_W = 0f;
	}

	private MaterialValue(float x, float y)
	{
		_Length = 2;
		_X = x;
		_Y = y;
		_Z = 0f;
		_W = 0f;
	}

	private MaterialValue(float x, float y, float z)
	{
		_Length = 3;
		_X = x;
		_Y = y;
		_Z = z;
		_W = 0f;
	}

	private MaterialValue(float x, float y, float z, float w)
	{
		_Length = 4;
		_X = x;
		_Y = y;
		_Z = z;
		_W = w;
	}

	public override int GetHashCode()
	{
		if (_Length == 0)
		{
			return 0;
		}
		float x = _X;
		int hashCode = x.GetHashCode();
		if (_Length == 1)
		{
			return hashCode;
		}
		int num = hashCode;
		x = _Y;
		hashCode = num ^ x.GetHashCode();
		if (_Length == 2)
		{
			return hashCode;
		}
		int num2 = hashCode;
		x = _Z;
		hashCode = num2 ^ x.GetHashCode();
		if (_Length == 3)
		{
			return hashCode;
		}
		int num3 = hashCode;
		x = _W;
		return num3 ^ x.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is MaterialValue other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(MaterialValue other)
	{
		return AreEqual(this, in other);
	}

	public static bool operator ==(in MaterialValue a, in MaterialValue b)
	{
		return AreEqual(in a, in b);
	}

	public static bool operator !=(in MaterialValue a, in MaterialValue b)
	{
		return !AreEqual(in a, in b);
	}

	public static bool AreEqual(in MaterialValue a, in MaterialValue b)
	{
		if (a._Length != b._Length)
		{
			return false;
		}
		if (a._Length == 0)
		{
			return true;
		}
		if (a._X != b._X)
		{
			return false;
		}
		if (a._Length == 1)
		{
			return true;
		}
		if (a._Y != b._Y)
		{
			return false;
		}
		if (a._Length == 2)
		{
			return true;
		}
		if (a._Z != b._Z)
		{
			return false;
		}
		if (a._Length == 3)
		{
			return true;
		}
		if (a._W != b._W)
		{
			return false;
		}
		return true;
	}

	public static explicit operator float(MaterialValue value)
	{
		if (value._Length != 1)
		{
			throw new InvalidOperationException();
		}
		return value._X;
	}

	public static explicit operator Vector2(MaterialValue value)
	{
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		if (value._Length != 2)
		{
			throw new InvalidOperationException();
		}
		return new Vector2(value._X, value._Y);
	}

	public static explicit operator Vector3(MaterialValue value)
	{
		//IL_0021: Unknown result type (might be due to invalid IL or missing references)
		if (value._Length != 3)
		{
			throw new InvalidOperationException();
		}
		return new Vector3(value._X, value._Y, value._Z);
	}

	public static explicit operator Vector4(MaterialValue value)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		if (value._Length != 4)
		{
			throw new InvalidOperationException();
		}
		return new Vector4(value._X, value._Y, value._Z, value._W);
	}

	public object ToTypeless()
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		return _Length switch
		{
			1 => (float)this, 
			2 => (Vector2)this, 
			3 => (Vector3)this, 
			4 => (Vector4)this, 
			_ => throw new NotImplementedException(), 
		};
	}

	public override string ToString()
	{
		return ToTypeless().ToString();
	}

	internal int _CopyTo(Span<float> dst)
	{
		if (_Length > 0)
		{
			dst[0] = _X;
		}
		if (_Length > 1)
		{
			dst[1] = _Y;
		}
		if (_Length > 2)
		{
			dst[2] = _Z;
		}
		if (_Length > 3)
		{
			dst[3] = _W;
		}
		return _Length;
	}
}
