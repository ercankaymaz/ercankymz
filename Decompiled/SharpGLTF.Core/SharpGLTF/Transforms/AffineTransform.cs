using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace SharpGLTF.Transforms;

[DebuggerDisplay("AffineTransform {ToDebuggerDisplayString(),nq}")]
public readonly struct AffineTransform : IEquatable<AffineTransform>
{
	private const string _CannotDecomposeError = "Matrix is invalid or skewed.";

	private const string _RequiresSRTError = "Needs to be in SRT representation. Call GetDecomposed() first.";

	public static readonly AffineTransform Identity = new AffineTransform((Vector3?)null, (Quaternion?)null, (Vector3?)null);

	private const int DATA_UNDEFINED = 0;

	private const int DATA_SRT = 1;

	private const int DATA_MAT = 2;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _Representation;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _M11;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _M12;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _M13;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _M21;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _M22;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _M23;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _M31;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _M32;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly float _M33;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Vector3 _Translation;

	public bool IsValid
	{
		get
		{
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			if (_Representation == 0)
			{
				return false;
			}
			if (!Translation._IsFinite())
			{
				return false;
			}
			if (!_M11._IsFinite())
			{
				return false;
			}
			if (!_M12._IsFinite())
			{
				return false;
			}
			if (!_M13._IsFinite())
			{
				return false;
			}
			if (!_M21._IsFinite())
			{
				return false;
			}
			if (!_M22._IsFinite())
			{
				return false;
			}
			if (!_M23._IsFinite())
			{
				return false;
			}
			if (!_M31._IsFinite())
			{
				return false;
			}
			if (!_M32._IsFinite())
			{
				return false;
			}
			if (!_M33._IsFinite())
			{
				return false;
			}
			return true;
		}
	}

	public bool IsMatrix => _Representation == 2;

	public bool IsSRT => _Representation == 1;

	public Vector3 Scale => _GetScale();

	public Quaternion Rotation => _GetRotation();

	public Vector3 Translation => _Translation;

	public Matrix4x4 Matrix => _GetMatrix();

	public bool IsLosslessDecomposable
	{
		get
		{
			_VerifyDefined();
			if (IsSRT)
			{
				return true;
			}
			if (_M11 != 0f)
			{
				return false;
			}
			if (_M12 == 0f)
			{
				return false;
			}
			if (_M13 == 0f)
			{
				return false;
			}
			if (_M21 == 0f)
			{
				return false;
			}
			if (_M22 != 0f)
			{
				return false;
			}
			if (_M23 == 0f)
			{
				return false;
			}
			if (_M31 == 0f)
			{
				return false;
			}
			if (_M32 == 0f)
			{
				return false;
			}
			if (_M33 != 0f)
			{
				return false;
			}
			return true;
		}
	}

	public bool IsIdentity
	{
		get
		{
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0011: Unknown result type (might be due to invalid IL or missing references)
			//IL_0097: Unknown result type (might be due to invalid IL or missing references)
			//IL_009c: Unknown result type (might be due to invalid IL or missing references)
			if (IsSRT)
			{
				if (Translation != Vector3.Zero)
				{
					return false;
				}
				if (_M11 != 1f)
				{
					return false;
				}
				if (_M12 != 1f)
				{
					return false;
				}
				if (_M13 != 1f)
				{
					return false;
				}
				if (_M21 != 0f)
				{
					return false;
				}
				if (_M22 != 0f)
				{
					return false;
				}
				if (_M23 != 0f)
				{
					return false;
				}
				if (_M31 != 1f)
				{
					return false;
				}
			}
			else if (IsMatrix)
			{
				if (Translation != Vector3.Zero)
				{
					return false;
				}
				if (_M11 != 1f)
				{
					return false;
				}
				if (_M12 != 0f)
				{
					return false;
				}
				if (_M13 != 0f)
				{
					return false;
				}
				if (_M21 != 0f)
				{
					return false;
				}
				if (_M22 != 1f)
				{
					return false;
				}
				if (_M23 != 0f)
				{
					return false;
				}
				if (_M31 != 0f)
				{
					return false;
				}
				if (_M32 != 0f)
				{
					return false;
				}
				if (_M33 != 1f)
				{
					return false;
				}
			}
			else
			{
				_VerifyDefined();
			}
			return true;
		}
	}

	internal string ToDebuggerDisplayString()
	{
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00df: Unknown result type (might be due to invalid IL or missing references)
		if (!IsValid)
		{
			return "INVALID";
		}
		if (IsIdentity)
		{
			return "IDENTITY";
		}
		if (TryDecompose(out var transform))
		{
			Vector3 val = transform._GetScale();
			Quaternion val2 = transform._GetRotation();
			string text = string.Empty;
			Vector3 val3 = Vector3.Max(Vector3.Zero, val - Vector3.One);
			if (val3.X > 1E-06f || val3.Y > 1E-06f || val3.Z > 1E-06f)
			{
				text += $"\ud835\udc12:{val} ";
			}
			if (val2 != Quaternion.Identity)
			{
				text += $"\ud835\udc11:{val2} ";
			}
			if (transform.Translation != Vector3.Zero)
			{
				text += $"\ud835\udebb:{transform.Translation} ";
			}
			return text;
		}
		return "Skewed Matrix ";
	}

	public static implicit operator AffineTransform((Quaternion r, Vector3 t) xform)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		return new AffineTransform((Vector3?)null, (Quaternion?)xform.r, (Vector3?)xform.t);
	}

	public static implicit operator AffineTransform(Matrix4x4 matrix)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new AffineTransform(matrix);
	}

	public static implicit operator AffineTransform(Quaternion rotation)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		return new AffineTransform(rotation);
	}

	public static AffineTransform CreateDecomposed(Matrix4x4 matrix)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		Vector3 scale = default(Vector3);
		Quaternion rotation = default(Quaternion);
		Vector3 translation = default(Vector3);
		if (!Matrix4x4.Decompose(matrix, ref scale, ref rotation, ref translation))
		{
			throw new ArgumentException("Can't decompose", "matrix");
		}
		return new AffineTransform(scale, rotation, translation);
	}

	public static AffineTransform CreateFromAny(Matrix4x4? matrix, Vector3? scale, Quaternion? rotation, Vector3? translation)
	{
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		if (matrix.HasValue)
		{
			Guard.MustBeNull(scale, "scale");
			Guard.MustBeNull(scale, "rotation");
			Guard.MustBeNull(scale, "translation");
			return new AffineTransform(matrix.Value);
		}
		return new AffineTransform(scale, rotation, translation);
	}

	public AffineTransform WithScale(Vector3 scale)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		if (_Representation == 0)
		{
			return new AffineTransform((Vector3?)scale, (Quaternion?)null, (Vector3?)null);
		}
		AffineTransform affineTransform = this;
		if (affineTransform.IsMatrix)
		{
			affineTransform = affineTransform.GetDecomposed();
		}
		return new AffineTransform(scale, affineTransform.Rotation, affineTransform.Translation);
	}

	public AffineTransform WithRotation(Quaternion rotation)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		if (_Representation == 0)
		{
			return new AffineTransform((Vector3?)null, (Quaternion?)rotation, (Vector3?)null);
		}
		AffineTransform affineTransform = this;
		if (affineTransform.IsMatrix)
		{
			affineTransform = affineTransform.GetDecomposed();
		}
		return new AffineTransform(affineTransform.Scale, rotation, affineTransform.Translation);
	}

	public AffineTransform WithTranslation(Vector3 translation)
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		if (_Representation == 0)
		{
			return new AffineTransform((Vector3?)null, (Quaternion?)null, (Vector3?)translation);
		}
		if (IsSRT)
		{
			return new AffineTransform(Scale, Rotation, translation);
		}
		Matrix4x4 matrix = Matrix;
		((Matrix4x4)(ref matrix)).Translation = translation;
		return matrix;
	}

	public AffineTransform(Vector3? scale, Quaternion? rotation, Vector3? translation)
		: this((Vector3)(((_003F?)scale) ?? Vector3.One), (Quaternion)(((_003F?)rotation) ?? Quaternion.Identity), (Vector3)(((_003F?)translation) ?? Vector3.Zero))
	{
	}//IL_0015: Unknown result type (might be due to invalid IL or missing references)
	//IL_000c: Unknown result type (might be due to invalid IL or missing references)
	//IL_002e: Unknown result type (might be due to invalid IL or missing references)
	//IL_0025: Unknown result type (might be due to invalid IL or missing references)
	//IL_0047: Unknown result type (might be due to invalid IL or missing references)
	//IL_003e: Unknown result type (might be due to invalid IL or missing references)


	public AffineTransform(Quaternion rotation)
		: this(Vector3.One, rotation, Vector3.Zero)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)
	//IL_0006: Unknown result type (might be due to invalid IL or missing references)
	//IL_0007: Unknown result type (might be due to invalid IL or missing references)


	public AffineTransform(Quaternion rotation, Vector3 translation)
		: this(Vector3.One, rotation, translation)
	{
	}//IL_0001: Unknown result type (might be due to invalid IL or missing references)
	//IL_0006: Unknown result type (might be due to invalid IL or missing references)
	//IL_0007: Unknown result type (might be due to invalid IL or missing references)


	public AffineTransform(Vector3 scale, Quaternion rotation, Vector3 translation)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_008b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		rotation = rotation.Sanitized();
		Guard.IsTrue(scale._IsFinite(), "scale");
		Guard.IsTrue(rotation._IsFinite(), "rotation");
		Guard.IsTrue(translation._IsFinite(), "translation");
		_Representation = 1;
		_M11 = scale.X;
		_M12 = scale.Y;
		_M13 = scale.Z;
		_M21 = rotation.X;
		_M22 = rotation.Y;
		_M23 = rotation.Z;
		_M31 = rotation.W;
		_M32 = 0f;
		_M33 = 0f;
		_Translation = translation;
	}

	public AffineTransform(Matrix4x4 matrix)
	{
		//IL_0005: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		Matrix4x4Factory.GuardMatrix("matrix", matrix, Matrix4x4Factory.MatrixCheck.WorldTransform);
		_Representation = 2;
		_M11 = matrix.M11;
		_M12 = matrix.M12;
		_M13 = matrix.M13;
		_M21 = matrix.M21;
		_M22 = matrix.M22;
		_M23 = matrix.M23;
		_M31 = matrix.M31;
		_M32 = matrix.M32;
		_M33 = matrix.M33;
		_Translation = ((Matrix4x4)(ref matrix)).Translation;
	}

	public override int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		return ((object)_Translation/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override bool Equals(object obj)
	{
		if (obj is AffineTransform other)
		{
			return Equals(other);
		}
		return false;
	}

	public bool Equals(AffineTransform other)
	{
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (_Representation != other._Representation)
		{
			return false;
		}
		if (_Translation != other._Translation)
		{
			return false;
		}
		if (_M11 != other._M11)
		{
			return false;
		}
		if (_M12 != other._M12)
		{
			return false;
		}
		if (_M13 != other._M13)
		{
			return false;
		}
		if (_M21 != other._M21)
		{
			return false;
		}
		if (_M22 != other._M22)
		{
			return false;
		}
		if (_M23 != other._M23)
		{
			return false;
		}
		if (_M31 != other._M31)
		{
			return false;
		}
		if (IsMatrix && other.IsMatrix)
		{
			if (_M32 != other._M32)
			{
				return false;
			}
			if (_M33 != other._M33)
			{
				return false;
			}
		}
		return true;
	}

	public static bool operator ==(in AffineTransform a, in AffineTransform b)
	{
		return a.Equals(b);
	}

	public static bool operator !=(in AffineTransform a, in AffineTransform b)
	{
		return !a.Equals(b);
	}

	public static bool AreGeometricallyEquivalent(in AffineTransform a, in AffineTransform b, float tolerance = 1E-05f)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_004a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0056: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = Transform(Vector3.UnitX, in a);
		Vector3 val2 = Transform(Vector3.UnitY, in a);
		Vector3 val3 = Transform(Vector3.UnitZ, in a);
		Vector3 val4 = Transform(Vector3.UnitX, in b);
		Vector3 val5 = Transform(Vector3.UnitY, in b);
		Vector3 val6 = Transform(Vector3.UnitZ, in b);
		if (Vector3.Distance(val, val4) > tolerance)
		{
			return false;
		}
		if (Vector3.Distance(val2, val5) > tolerance)
		{
			return false;
		}
		if (Vector3.Distance(val3, val6) > tolerance)
		{
			return false;
		}
		return true;
	}

	public AffineTransform GetDecomposed()
	{
		if (!TryDecompose(out var transform))
		{
			throw new InvalidOperationException("Matrix is invalid or skewed.");
		}
		return transform;
	}

	public bool TryDecompose(out AffineTransform transform)
	{
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006b: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		if (IsSRT)
		{
			transform = this;
			return true;
		}
		if (IsLosslessDecomposable)
		{
			transform = new AffineTransform(new Vector3(_M11, _M22, _M33), Quaternion.Identity, Translation);
			return true;
		}
		Vector3 scale = default(Vector3);
		Quaternion rotation = default(Quaternion);
		Vector3 translation = default(Vector3);
		bool flag = Matrix4x4.Decompose(Matrix, ref scale, ref rotation, ref translation);
		transform = (flag ? new AffineTransform(scale, rotation, translation) : this);
		return flag;
	}

	public bool TryDecompose(out Vector3 scale, out Quaternion rotation, out Vector3 translation)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		if (IsSRT)
		{
			scale = _GetScale();
			rotation = _GetRotation();
			translation = _Translation;
			return true;
		}
		if (IsLosslessDecomposable)
		{
			scale = new Vector3(_M11, _M22, _M33);
			rotation = Quaternion.Identity;
			translation = _Translation;
			return true;
		}
		return Matrix4x4.Decompose(Matrix, ref scale, ref rotation, ref translation);
	}

	public static AffineTransform Blend(ReadOnlySpan<AffineTransform> transforms, ReadOnlySpan<float> weights)
	{
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cc: Unknown result type (might be due to invalid IL or missing references)
		if (transforms.Length == 0)
		{
			return Identity;
		}
		if (transforms.Length == 1)
		{
			return transforms[0];
		}
		Vector3 val = Vector3.Zero;
		Quaternion val2 = default(Quaternion);
		Vector3 val3 = Vector3.Zero;
		float num = 0f;
		for (int i = 0; i < transforms.Length; i++)
		{
			Guard.IsTrue(transforms[i].IsValid, "transforms");
			Guard.IsTrue(transforms[i].TryDecompose(out var scale, out var rotation, out var translation), $"Can't decompose [{i}]");
			float num2 = weights[i];
			val += scale * num2;
			val3 += translation * num2;
			num += num2;
			val2 = ((i != 0) ? Quaternion.Slerp(rotation, val2, num2 / num) : rotation);
		}
		val2 = Quaternion.Normalize(val2);
		return new AffineTransform(val, val2, val3);
	}

	public static AffineTransform operator *(in AffineTransform a, in AffineTransform b)
	{
		return Multiply(in a, in b);
	}

	public static AffineTransform Multiply(in AffineTransform a, in AffineTransform b)
	{
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005d: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0091: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		//IL_0098: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00be: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_00cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		Guard.IsFalse(a._Representation == 0, "a");
		Guard.IsFalse(b._Representation == 0, "b");
		if (a.IsMatrix || b.IsMatrix)
		{
			return new AffineTransform(a.Matrix * b.Matrix);
		}
		Vector3 scale = b.Scale;
		if (scale.X != scale.Y || scale.X != scale.Z)
		{
			return new AffineTransform(a.Matrix * b.Matrix);
		}
		Vector3 scale2 = scale * a.Scale;
		Quaternion rotation = b.Rotation;
		Quaternion rotation2 = Quaternion.Multiply(rotation, a.Rotation);
		Vector3 translation = b.Translation + _Vector3Transform(a.Translation * scale, rotation);
		return new AffineTransform(scale2, rotation2, translation);
	}

	public static bool TryInvert(in AffineTransform xform, out AffineTransform inverse)
	{
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_0046: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_0066: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ee: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_010f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_011b: Unknown result type (might be due to invalid IL or missing references)
		if (xform.IsMatrix)
		{
			Matrix4x4 val = default(Matrix4x4);
			if (Matrix4x4.Invert(xform.Matrix, ref val))
			{
				val.M44 = 1f;
				inverse = val;
				return true;
			}
			inverse = default(AffineTransform);
			return false;
		}
		if (xform.IsSRT)
		{
			Quaternion rotation = xform.Rotation;
			if (((Quaternion)(ref rotation)).IsIdentity)
			{
				Vector3 val2 = Vector3.One / xform.Scale;
				Vector3 translation = -val2 * xform.Translation;
				inverse = new AffineTransform(val2, Quaternion.Identity, translation);
			}
			else
			{
				if (xform.Scale.X != xform.Scale.Y || xform.Scale.Y != xform.Scale.Z)
				{
					return TryInvert((AffineTransform)xform.Matrix, out inverse);
				}
				float num = 1f / xform.Scale.X;
				Quaternion val3 = Quaternion.Normalize(Quaternion.Conjugate(xform.Rotation));
				Vector3 translation2 = (0f - num) * _Vector3Transform(xform.Translation, val3);
				inverse = new AffineTransform(new Vector3(num), val3, translation2);
			}
			return true;
		}
		inverse = default(AffineTransform);
		return false;
	}

	private static Vector3 Transform(Vector3 vector, in AffineTransform xform)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0040: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0047: Unknown result type (might be due to invalid IL or missing references)
		if (xform.IsMatrix)
		{
			return Vector3.Transform(vector, xform.Matrix);
		}
		if (xform.IsSRT)
		{
			vector *= xform.Scale;
			vector = _Vector3Transform(vector, xform.Rotation);
			vector += xform.Translation;
			return vector;
		}
		throw new ArgumentException("Undefined transform", "xform");
	}

	public static Vector3 TransformNormal(Vector3 vector, in AffineTransform xform)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0029: Unknown result type (might be due to invalid IL or missing references)
		//IL_002b: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		if (xform.IsMatrix)
		{
			return Vector3.TransformNormal(vector, xform.Matrix);
		}
		if (xform.IsSRT)
		{
			vector *= xform.Scale;
			vector = _Vector3Transform(vector, xform.Rotation);
			return vector;
		}
		throw new ArgumentException("Undefined transform", "xform");
	}

	private void _VerifyDefined()
	{
		if (_Representation == 0)
		{
			throw new InvalidOperationException("Undefined");
		}
	}

	private Matrix4x4 _GetMatrix()
	{
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_0097: Unknown result type (might be due to invalid IL or missing references)
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00aa: Unknown result type (might be due to invalid IL or missing references)
		if (IsMatrix)
		{
			return new Matrix4x4(_M11, _M12, _M13, 0f, _M21, _M22, _M23, 0f, _M31, _M32, _M33, 0f, _Translation.X, _Translation.Y, _Translation.Z, 1f);
		}
		if (IsSRT)
		{
			Matrix4x4 result = Matrix4x4.CreateScale(Scale) * Matrix4x4.CreateFromQuaternion(Rotation);
			((Matrix4x4)(ref result)).Translation = Translation;
			return result;
		}
		_VerifyDefined();
		return default(Matrix4x4);
	}

	private Vector3 _GetScale()
	{
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		if (IsSRT)
		{
			return new Vector3(_M11, _M12, _M13);
		}
		throw new InvalidOperationException("Needs to be in SRT representation. Call GetDecomposed() first.");
	}

	private Quaternion _GetRotation()
	{
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		if (IsSRT)
		{
			return new Quaternion(_M21, _M22, _M23, _M31);
		}
		throw new InvalidOperationException("Needs to be in SRT representation. Call GetDecomposed() first.");
	}

	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	private static Vector3 _Vector3Transform(Vector3 v, Quaternion q)
	{
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_0026: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Unknown result type (might be due to invalid IL or missing references)
		//IL_003e: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0051: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		Vector3 val = default(Vector3);
		((Vector3)(ref val))._002Ector(q.X, q.Y, q.Z);
		float w = q.W;
		return 2f * Vector3.Dot(val, v) * val + (w * w - Vector3.Dot(val, val)) * v + 2f * w * Vector3.Cross(val, v);
	}
}
