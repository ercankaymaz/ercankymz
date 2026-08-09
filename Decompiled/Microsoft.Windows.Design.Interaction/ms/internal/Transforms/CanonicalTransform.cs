using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace MS.Internal.Transforms;

internal class CanonicalTransform : ICloneable
{
	internal const int scaleIndex = 0;

	internal const int skewIndex = 1;

	internal const int rotateIndex = 2;

	internal const int translateIndex = 3;

	internal const int transformCount = 4;

	private TransformGroup transformGroup;

	private CanonicalDecomposition decomposition;

	internal CanonicalDecomposition Decomposition => decomposition;

	public Point Center
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return decomposition.Center;
		}
		set
		{
			//IL_00d2: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0048: Unknown result type (might be due to invalid IL or missing references)
			//IL_004d: Unknown result type (might be due to invalid IL or missing references)
			if (((Point)(ref value)).X == 0.0 && ((Point)(ref value)).Y == 0.0)
			{
				Point center = decomposition.Center;
				if (((Point)(ref center)).X == 0.0)
				{
					Point center2 = decomposition.Center;
					if (((Point)(ref center2)).Y == 0.0)
					{
						goto IL_00cc;
					}
				}
			}
			ScaleTransform.CenterX = ((Point)(ref value)).X;
			ScaleTransform.CenterY = ((Point)(ref value)).Y;
			SkewTransform.CenterX = ((Point)(ref value)).X;
			SkewTransform.CenterY = ((Point)(ref value)).Y;
			RotateTransform.CenterX = ((Point)(ref value)).X;
			RotateTransform.CenterY = ((Point)(ref value)).Y;
			goto IL_00cc;
			IL_00cc:
			decomposition.Center = value;
		}
	}

	public double CenterX
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			Point center = decomposition.Center;
			return ((Point)(ref center)).X;
		}
		set
		{
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			Point center = decomposition.Center;
			Center = new Point(value, ((Point)(ref center)).Y);
		}
	}

	public double CenterY
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000b: Unknown result type (might be due to invalid IL or missing references)
			Point center = decomposition.Center;
			return ((Point)(ref center)).Y;
		}
		set
		{
			//IL_0007: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0015: Unknown result type (might be due to invalid IL or missing references)
			Point center = decomposition.Center;
			Center = new Point(((Point)(ref center)).X, value);
		}
	}

	public Vector Scale
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return decomposition.Scale;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			decomposition.Scale = value;
			Transform obj = transformGroup.Children[0];
			ScaleTransform val = (ScaleTransform)(object)((obj is ScaleTransform) ? obj : null);
			val.ScaleX = decomposition.ScaleX;
			val.ScaleY = decomposition.ScaleY;
		}
	}

	public ScaleTransform ScaleTransform
	{
		get
		{
			Transform obj = transformGroup.Children[0];
			return (ScaleTransform)(object)((obj is ScaleTransform) ? obj : null);
		}
		set
		{
			transformGroup.Children[0] = (Transform)(object)value;
		}
	}

	public double ScaleX
	{
		get
		{
			return decomposition.ScaleX;
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			Scale = new Vector(value, decomposition.ScaleY);
		}
	}

	public double ScaleY
	{
		get
		{
			return decomposition.ScaleY;
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			Scale = new Vector(decomposition.ScaleX, value);
		}
	}

	public Vector Skew
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return decomposition.Skew;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			decomposition.Skew = value;
			Transform obj = transformGroup.Children[1];
			SkewTransform val = (SkewTransform)(object)((obj is SkewTransform) ? obj : null);
			val.AngleX = decomposition.SkewX;
			val.AngleY = decomposition.SkewY;
		}
	}

	public SkewTransform SkewTransform
	{
		get
		{
			Transform obj = transformGroup.Children[1];
			return (SkewTransform)(object)((obj is SkewTransform) ? obj : null);
		}
		set
		{
			transformGroup.Children[1] = (Transform)(object)value;
		}
	}

	public double SkewX
	{
		get
		{
			return decomposition.SkewX;
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			Skew = new Vector(value, decomposition.SkewY);
		}
	}

	public double SkewY
	{
		get
		{
			return decomposition.SkewY;
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			Skew = new Vector(decomposition.SkewX, value);
		}
	}

	public double RotationAngle
	{
		get
		{
			return decomposition.RotationAngle;
		}
		set
		{
			decomposition.RotationAngle = value;
			Transform obj = transformGroup.Children[2];
			RotateTransform val = (RotateTransform)(object)((obj is RotateTransform) ? obj : null);
			val.Angle = decomposition.RotationAngle;
		}
	}

	public RotateTransform RotateTransform
	{
		get
		{
			Transform obj = transformGroup.Children[2];
			return (RotateTransform)(object)((obj is RotateTransform) ? obj : null);
		}
		set
		{
			transformGroup.Children[2] = (Transform)(object)value;
		}
	}

	public Vector Translation
	{
		get
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			return decomposition.Translation;
		}
		set
		{
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			decomposition.Translation = value;
			Transform obj = transformGroup.Children[3];
			TranslateTransform val = (TranslateTransform)(object)((obj is TranslateTransform) ? obj : null);
			val.X = decomposition.TranslationX;
			val.Y = decomposition.TranslationY;
		}
	}

	public TranslateTransform TranslateTransform
	{
		get
		{
			Transform obj = transformGroup.Children[3];
			return (TranslateTransform)(object)((obj is TranslateTransform) ? obj : null);
		}
		set
		{
			transformGroup.Children[3] = (Transform)(object)value;
		}
	}

	public double TranslationX
	{
		get
		{
			return decomposition.TranslationX;
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			Translation = new Vector(value, decomposition.TranslationY);
		}
	}

	public double TranslationY
	{
		get
		{
			return decomposition.TranslationY;
		}
		set
		{
			//IL_000d: Unknown result type (might be due to invalid IL or missing references)
			Translation = new Vector(decomposition.TranslationX, value);
		}
	}

	public CanonicalTransform()
	{
		Initialize();
	}

	public CanonicalTransform(CanonicalTransform canonicalTransform)
	{
		if (canonicalTransform == null)
		{
			Initialize();
			return;
		}
		decomposition = (CanonicalDecomposition)canonicalTransform.decomposition.Clone();
		InitializeTransformGroup();
	}

	public CanonicalTransform(Transform transform)
	{
		if (transform == null)
		{
			Initialize();
			return;
		}
		decomposition = new CanonicalDecomposition();
		ReadTransform(transform, useIfChangeable: false);
	}

	public CanonicalTransform(Matrix transform)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		if (((Matrix)(ref transform)).IsIdentity)
		{
			Initialize();
			return;
		}
		decomposition = new CanonicalDecomposition(transform);
		InitializeTransformGroup();
	}

	private CanonicalTransform(Transform transform, bool useIfChangeable)
	{
		if (transform == null)
		{
			Initialize();
			return;
		}
		decomposition = new CanonicalDecomposition();
		ReadTransform(transform, useIfChangeable);
	}

	public static bool IsCanonical(Transform transform)
	{
		bool result = false;
		TransformGroup val = (TransformGroup)(object)((transform is TransformGroup) ? transform : null);
		if (val != null && val.Children.Count == 4)
		{
			Transform obj = val.Children[0];
			ScaleTransform val2 = (ScaleTransform)(object)((obj is ScaleTransform) ? obj : null);
			Transform obj2 = val.Children[1];
			SkewTransform val3 = (SkewTransform)(object)((obj2 is SkewTransform) ? obj2 : null);
			Transform obj3 = val.Children[2];
			RotateTransform val4 = (RotateTransform)(object)((obj3 is RotateTransform) ? obj3 : null);
			Transform obj4 = val.Children[3];
			TranslateTransform val5 = (TranslateTransform)(object)((obj4 is TranslateTransform) ? obj4 : null);
			if (val2 != null && val3 != null && val4 != null && val5 != null && val3.CenterX == val4.CenterX && val3.CenterY == val4.CenterY && val2.CenterX == val4.CenterX && val2.CenterY == val4.CenterY)
			{
				result = true;
			}
		}
		return result;
	}

	public static explicit operator Transform(CanonicalTransform value)
	{
		if (value != null)
		{
			return (Transform)(object)value.ToTransform();
		}
		return null;
	}

	public static explicit operator CanonicalTransform(Transform value)
	{
		return new CanonicalTransform(value, useIfChangeable: true);
	}

	public override string ToString()
	{
		return decomposition.ToString();
	}

	public override int GetHashCode()
	{
		return decomposition.GetHashCode();
	}

	public override bool Equals(object obj)
	{
		return this == obj as CanonicalTransform;
	}

	public static bool Compare(CanonicalTransform ct1, CanonicalTransform ct2)
	{
		return ct1 == ct2;
	}

	public static bool operator ==(CanonicalTransform ct1, CanonicalTransform ct2)
	{
		bool flag = (object)ct1 == null;
		bool flag2 = (object)ct2 == null;
		if (!flag || !flag2)
		{
			if (!flag && !flag2)
			{
				return ct1.decomposition == ct2.decomposition;
			}
			return false;
		}
		return true;
	}

	public static bool operator !=(CanonicalTransform ct1, CanonicalTransform ct2)
	{
		return !(ct1 == ct2);
	}

	public TransformGroup ToTransform()
	{
		return transformGroup;
	}

	public object Clone()
	{
		return new CanonicalTransform(this);
	}

	public void UpdateForNewOrigin(Point oldOrigin, Point newOrigin)
	{
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_0044: Unknown result type (might be due to invalid IL or missing references)
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0063: Unknown result type (might be due to invalid IL or missing references)
		//IL_006e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0082: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_0088: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		Point val = default(Point);
		((Point)(ref val))._002Ector(0.0, 0.0);
		Vector val2 = default(Vector);
		((Vector)(ref val2))._002Ector(((Point)(ref oldOrigin)).X, ((Point)(ref oldOrigin)).Y);
		Vector val3 = default(Vector);
		((Vector)(ref val3))._002Ector(((Point)(ref newOrigin)).X, ((Point)(ref newOrigin)).Y);
		Point val4 = (val - val2) * ((Transform)ToTransform()).Value + val2;
		Point val5 = (val - val3) * ((Transform)ToTransform()).Value + val3;
		Translation += val4 - val5;
	}

	public void UpdateCenter(Point center)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0032: Unknown result type (might be due to invalid IL or missing references)
		//IL_0035: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_005b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0060: Unknown result type (might be due to invalid IL or missing references)
		//IL_0061: Unknown result type (might be due to invalid IL or missing references)
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		if (Center != center)
		{
			Point val = default(Point);
			((Point)(ref val))._002Ector(0.0, 0.0);
			Matrix value = ((Transform)ToTransform()).Value;
			Point val2 = ((Matrix)(ref value)).Transform(val);
			Center = center;
			Matrix value2 = ((Transform)ToTransform()).Value;
			Point val3 = ((Matrix)(ref value2)).Transform(val);
			Translation += val2 - val3;
		}
	}

	public void ApplyScale(Vector scale, Point origin, Point fixedPoint)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		decomposition.ApplyScale(scale, origin, fixedPoint);
		UpdateTransformGroup();
	}

	public void ApplySkewScale(Vector basisX, Vector basisY, Point origin, Point fixedPoint, Vector newBasisX, Vector newBasisY)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		decomposition.ApplySkewScale(basisX, basisY, origin, fixedPoint, newBasisX, newBasisY);
		UpdateTransformGroup();
	}

	public void ApplySkewScale(Vector appliedSkew, Vector appliedScale, Point origin, Point fixedPoint)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0009: Unknown result type (might be due to invalid IL or missing references)
		decomposition.ApplySkewScale(appliedSkew, appliedScale, origin, fixedPoint);
		UpdateTransformGroup();
	}

	public void ApplyRotation(double angle, Point fixedPoint)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		decomposition.ApplyRotation(angle, fixedPoint);
		UpdateTransformGroup();
	}

	private void Initialize()
	{
		decomposition = new CanonicalDecomposition();
		InitializeTransformGroup();
	}

	private void UpdateTransformGroup()
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_003a: Unknown result type (might be due to invalid IL or missing references)
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		Skew = Decomposition.Skew;
		Scale = Decomposition.Scale;
		RotationAngle = Decomposition.RotationAngle;
		Translation = Decomposition.Translation;
		Center = Decomposition.Center;
	}

	private void InitializeTransformGroup()
	{
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0023: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Expected O, but got Unknown
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Expected O, but got Unknown
		//IL_0062: Unknown result type (might be due to invalid IL or missing references)
		//IL_0067: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_0081: Unknown result type (might be due to invalid IL or missing references)
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0113: Expected O, but got Unknown
		//IL_0114: Unknown result type (might be due to invalid IL or missing references)
		//IL_011e: Expected O, but got Unknown
		//IL_0125: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Expected O, but got Unknown
		Transform[] array = (Transform[])(object)new Transform[4];
		ScaleTransform val = (ScaleTransform)(object)(array[0] = (Transform)new ScaleTransform(decomposition.ScaleX, decomposition.ScaleY));
		SkewTransform val2 = (SkewTransform)(object)(array[1] = (Transform)new SkewTransform(decomposition.SkewX, decomposition.SkewY));
		RotateTransform val3 = (RotateTransform)(object)(array[2] = (Transform)new RotateTransform(decomposition.RotationAngle));
		Point center = decomposition.Center;
		if (((Point)(ref center)).X == 0.0)
		{
			Point center2 = decomposition.Center;
			if (((Point)(ref center2)).Y == 0.0)
			{
				goto IL_00f5;
			}
		}
		Point center3 = decomposition.Center;
		val.CenterX = ((Point)(ref center3)).X;
		val.CenterY = ((Point)(ref center3)).Y;
		val2.CenterX = ((Point)(ref center3)).X;
		val2.CenterY = ((Point)(ref center3)).Y;
		val3.CenterX = ((Point)(ref center3)).X;
		val3.CenterY = ((Point)(ref center3)).Y;
		goto IL_00f5;
		IL_00f5:
		array[3] = (Transform)new TranslateTransform(decomposition.TranslationX, decomposition.TranslationY);
		transformGroup = new TransformGroup();
		transformGroup.Children = new TransformCollection((IEnumerable<Transform>)array);
	}

	private void ReadTransform(Transform transform, bool useIfChangeable)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		if (!ReadCanonicalForm(transform, useIfChangeable))
		{
			decomposition = new CanonicalDecomposition(transform.Value);
			InitializeTransformGroup();
		}
	}

	private bool ReadCanonicalForm(Transform transform, bool useIfChangeable)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Expected O, but got Unknown
		//IL_0070: Unknown result type (might be due to invalid IL or missing references)
		//IL_008c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		bool result = false;
		if (IsCanonical(transform))
		{
			TransformGroup val = (TransformGroup)transform;
			Transform obj = val.Children[0];
			ScaleTransform val2 = (ScaleTransform)(object)((obj is ScaleTransform) ? obj : null);
			Transform obj2 = val.Children[1];
			SkewTransform val3 = (SkewTransform)(object)((obj2 is SkewTransform) ? obj2 : null);
			Transform obj3 = val.Children[2];
			RotateTransform val4 = (RotateTransform)(object)((obj3 is RotateTransform) ? obj3 : null);
			Transform obj4 = val.Children[3];
			TranslateTransform val5 = (TranslateTransform)(object)((obj4 is TranslateTransform) ? obj4 : null);
			decomposition.Center = new Point(val2.CenterX, val2.CenterY);
			decomposition.Scale = new Vector(val2.ScaleX, val2.ScaleY);
			decomposition.Skew = new Vector(val3.AngleX, val3.AngleY);
			decomposition.RotationAngle = val4.Angle;
			decomposition.Translation = new Vector(val5.X, val5.Y);
			if (useIfChangeable && !((Freezable)val).IsFrozen)
			{
				transformGroup = val;
			}
			else
			{
				InitializeTransformGroup();
			}
			result = true;
		}
		return result;
	}
}
