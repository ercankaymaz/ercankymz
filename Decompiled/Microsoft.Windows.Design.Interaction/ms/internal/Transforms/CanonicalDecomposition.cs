using System;
using System.Windows;
using System.Windows.Media;

namespace MS.Internal.Transforms;

internal class CanonicalDecomposition : ICloneable
{
	private static readonly double tolerance = 2.220446049250313E-16;

	private Point center;

	private Vector scale;

	private Vector skew;

	private double rotationAngle;

	private Vector translation;

	private Matrix value;

	private bool needsUpdate;

	public Point Center
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return center;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			if (center != value)
			{
				center = value;
				needsUpdate = true;
			}
		}
	}

	public Vector Scale
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return scale;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			if (scale != value)
			{
				scale = value;
				needsUpdate = true;
			}
		}
	}

	public double ScaleX
	{
		get
		{
			return ((Vector)(ref scale)).X;
		}
		set
		{
			if (((Vector)(ref scale)).X != value)
			{
				((Vector)(ref scale)).X = value;
				needsUpdate = true;
			}
		}
	}

	public double ScaleY
	{
		get
		{
			return ((Vector)(ref scale)).Y;
		}
		set
		{
			if (((Vector)(ref scale)).Y != value)
			{
				((Vector)(ref scale)).Y = value;
				needsUpdate = true;
			}
		}
	}

	public Vector Skew
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return skew;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			if (skew != value)
			{
				skew = value;
				needsUpdate = true;
			}
		}
	}

	public double SkewX
	{
		get
		{
			return ((Vector)(ref skew)).X;
		}
		set
		{
			if (((Vector)(ref skew)).X != value)
			{
				((Vector)(ref skew)).X = value;
				needsUpdate = true;
			}
		}
	}

	public double SkewY
	{
		get
		{
			return ((Vector)(ref skew)).Y;
		}
		set
		{
			if (((Vector)(ref skew)).Y != value)
			{
				((Vector)(ref skew)).Y = value;
				needsUpdate = true;
			}
		}
	}

	public double RotationAngle
	{
		get
		{
			return rotationAngle;
		}
		set
		{
			if (rotationAngle != value)
			{
				rotationAngle = value;
				needsUpdate = true;
			}
		}
	}

	public Vector Translation
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return translation;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0006: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_0010: Unknown result type (might be due to invalid IL or missing references)
			if (translation != value)
			{
				translation = value;
				needsUpdate = true;
			}
		}
	}

	public double TranslationX
	{
		get
		{
			return ((Vector)(ref translation)).X;
		}
		set
		{
			if (((Vector)(ref translation)).X != value)
			{
				((Vector)(ref translation)).X = value;
				needsUpdate = true;
			}
		}
	}

	public double TranslationY
	{
		get
		{
			return ((Vector)(ref translation)).Y;
		}
		set
		{
			if (((Vector)(ref translation)).Y != value)
			{
				((Vector)(ref translation)).Y = value;
				needsUpdate = true;
			}
		}
	}

	public Matrix Value
	{
		get
		{
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			if (needsUpdate)
			{
				UpdateValue();
			}
			return value;
		}
		set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0008: Unknown result type (might be due to invalid IL or missing references)
			//IL_0009: Unknown result type (might be due to invalid IL or missing references)
			ConvertGenericTransform(value);
			this.value = value;
			needsUpdate = false;
		}
	}

	public CanonicalDecomposition()
	{
		//IL_0019: Unknown result type (might be due to invalid IL or missing references)
		//IL_001e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_003b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		//IL_0058: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0084: Unknown result type (might be due to invalid IL or missing references)
		//IL_008a: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		center = new Point(0.0, 0.0);
		scale = new Vector(1.0, 1.0);
		skew = new Vector(0.0, 0.0);
		rotationAngle = 0.0;
		translation = new Vector(0.0, 0.0);
		value = Matrix.Identity;
		needsUpdate = false;
	}

	public CanonicalDecomposition(CanonicalDecomposition sourceDecomposition)
	{
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0014: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		Center = sourceDecomposition.center;
		Scale = sourceDecomposition.scale;
		Skew = sourceDecomposition.skew;
		RotationAngle = sourceDecomposition.rotationAngle;
		Translation = sourceDecomposition.translation;
		UpdateValue();
	}

	public CanonicalDecomposition(Matrix sourceMatrix)
	{
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_000f: Unknown result type (might be due to invalid IL or missing references)
		ConvertGenericTransform(sourceMatrix);
		value = sourceMatrix;
	}

	public override string ToString()
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		//IL_004f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0054: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_008d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0092: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0108: Unknown result type (might be due to invalid IL or missing references)
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		object[] array = new object[19]
		{
			"center(", null, null, null, null, null, null, null, null, null,
			null, null, null, null, null, null, null, null, null
		};
		Point val = Center;
		array[1] = ((Point)(ref val)).X;
		array[2] = ", ";
		Point val2 = Center;
		array[3] = ((Point)(ref val2)).Y;
		array[4] = ") scale(";
		Vector val3 = Scale;
		array[5] = ((Vector)(ref val3)).X;
		array[6] = ", ";
		Vector val4 = Scale;
		array[7] = ((Vector)(ref val4)).Y;
		array[8] = ") skew(";
		Vector val5 = Skew;
		array[9] = ((Vector)(ref val5)).X;
		array[10] = ", ";
		Vector val6 = Skew;
		array[11] = ((Vector)(ref val6)).Y;
		array[12] = ") rotate(";
		array[13] = RotationAngle;
		array[14] = ") translate(";
		Vector val7 = Translation;
		array[15] = ((Vector)(ref val7)).X;
		array[16] = ", ";
		Vector val8 = Translation;
		array[17] = ((Vector)(ref val8)).Y;
		array[18] = ")";
		return string.Concat(array);
	}

	public override int GetHashCode()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_004e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Unknown result type (might be due to invalid IL or missing references)
		return ((object)Center/*cast due to constrained. prefix*/).GetHashCode() ^ ((object)Scale/*cast due to constrained. prefix*/).GetHashCode() ^ ((object)Skew/*cast due to constrained. prefix*/).GetHashCode() ^ RotationAngle.GetHashCode() ^ ((object)Translation/*cast due to constrained. prefix*/).GetHashCode();
	}

	public override bool Equals(object obj)
	{
		return this == obj as CanonicalDecomposition;
	}

	public static bool operator ==(CanonicalDecomposition cd1, CanonicalDecomposition cd2)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_005e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0064: Unknown result type (might be due to invalid IL or missing references)
		bool flag = (object)cd1 == null;
		bool flag2 = (object)cd2 == null;
		if (!flag || !flag2)
		{
			if (!flag && !flag2 && cd1.center == cd2.center && cd1.scale == cd2.scale && cd1.skew == cd2.skew && cd1.rotationAngle == cd2.rotationAngle)
			{
				return cd1.translation == cd2.translation;
			}
			return false;
		}
		return true;
	}

	public static bool operator !=(CanonicalDecomposition cd1, CanonicalDecomposition cd2)
	{
		return !(cd1 == cd2);
	}

	public void ApplyScale(Vector scale, Point origin, Point fixedPoint)
	{
		//IL_004b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0057: Unknown result type (might be due to invalid IL or missing references)
		//IL_005c: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		Vector val = default(Vector);
		((Vector)(ref val))._002Ector((1.0 - ((Vector)(ref scale)).X) * (((Point)(ref fixedPoint)).X - ((Point)(ref origin)).X), (1.0 - ((Vector)(ref scale)).Y) * (((Point)(ref fixedPoint)).Y - ((Point)(ref origin)).Y));
		Translation += val * Value;
		double num = (Tolerances.NearZero(ScaleX) ? 0.001 : ScaleX);
		double num2 = (Tolerances.NearZero(ScaleY) ? 0.001 : ScaleY);
		Scale = new Vector(num * ((Vector)(ref scale)).X, num2 * ((Vector)(ref scale)).Y);
	}

	public void ApplySkewScale(Vector basisX, Vector basisY, Point origin, Point fixedPoint, Vector newBasisX, Vector newBasisY)
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0078: Unknown result type (might be due to invalid IL or missing references)
		//IL_0079: Unknown result type (might be due to invalid IL or missing references)
		//IL_007a: Unknown result type (might be due to invalid IL or missing references)
		//IL_007f: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		//IL_014d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0154: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_015c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		//IL_0162: Unknown result type (might be due to invalid IL or missing references)
		//IL_0163: Unknown result type (might be due to invalid IL or missing references)
		//IL_0168: Unknown result type (might be due to invalid IL or missing references)
		//IL_016d: Unknown result type (might be due to invalid IL or missing references)
		//IL_016e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0173: Unknown result type (might be due to invalid IL or missing references)
		//IL_0177: Unknown result type (might be due to invalid IL or missing references)
		//IL_017c: Unknown result type (might be due to invalid IL or missing references)
		//IL_017e: Unknown result type (might be due to invalid IL or missing references)
		Matrix val = Value;
		Matrix val2 = default(Matrix);
		((Matrix)(ref val2))._002Ector(((Vector)(ref basisX)).X, ((Vector)(ref basisX)).Y, ((Vector)(ref basisY)).X, ((Vector)(ref basisY)).Y, 0.0, 0.0);
		((Matrix)(ref val2)).Invert();
		Matrix val3 = default(Matrix);
		((Matrix)(ref val3))._002Ector(((Vector)(ref newBasisX)).X, ((Vector)(ref newBasisX)).Y, ((Vector)(ref newBasisY)).X, ((Vector)(ref newBasisY)).Y, 0.0, 0.0);
		Matrix val4 = val2 * val3;
		if ((((Matrix)(ref val4)).M22 == 0.0 && ((Matrix)(ref val4)).M21 != 0.0) || (((Matrix)(ref val4)).M11 == 0.0 && ((Matrix)(ref val4)).M12 != 0.0))
		{
			throw new InvalidOperationException();
		}
		double num = 0.0;
		double num2 = 0.0;
		if (((Matrix)(ref val4)).M22 != 0.0)
		{
			num = ((Matrix)(ref val4)).M21 / ((Matrix)(ref val4)).M22;
		}
		if (((Matrix)(ref val4)).M11 != 0.0)
		{
			num2 = ((Matrix)(ref val4)).M12 / ((Matrix)(ref val4)).M11;
		}
		Vector appliedSkew = default(Vector);
		((Vector)(ref appliedSkew))._002Ector(num, num2);
		Vector appliedScale = default(Vector);
		((Vector)(ref appliedScale))._002Ector(((Matrix)(ref val4)).M11, ((Matrix)(ref val4)).M22);
		ApplySkewScaleInternal(appliedSkew, appliedScale);
		Vector val5 = fixedPoint - origin;
		Vector val6 = (val5 - val5 * val4) * val;
		Translation += val6;
	}

	public void ApplySkewScale(Vector appliedSkew, Vector appliedScale, Point origin, Point fixedPoint)
	{
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0049: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_009b: Unknown result type (might be due to invalid IL or missing references)
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ac: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		((Vector)(ref appliedSkew))._002Ector(Math.Tan(((Vector)(ref appliedSkew)).X * Math.PI / 180.0), Math.Tan(((Vector)(ref appliedSkew)).Y * Math.PI / 180.0));
		ApplySkewScaleInternal(appliedSkew, appliedScale);
		Matrix val = Value;
		Matrix val2 = default(Matrix);
		((Matrix)(ref val2))._002Ector(((Vector)(ref appliedScale)).X, ((Vector)(ref appliedSkew)).X * ((Vector)(ref appliedScale)).Y, ((Vector)(ref appliedSkew)).Y * ((Vector)(ref appliedScale)).X, ((Vector)(ref appliedScale)).Y, 0.0, 0.0);
		Vector val3 = fixedPoint - origin;
		Vector val4 = (val3 - val3 * val2) * val;
		Translation += val4;
	}

	private void ApplySkewScaleInternal(Vector appliedSkew, Vector appliedScale)
	{
		//IL_0003: Unknown result type (might be due to invalid IL or missing references)
		//IL_0008: Unknown result type (might be due to invalid IL or missing references)
		//IL_0011: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Unknown result type (might be due to invalid IL or missing references)
		//IL_0072: Unknown result type (might be due to invalid IL or missing references)
		//IL_0077: Unknown result type (might be due to invalid IL or missing references)
		Vector val = Skew;
		double x = ((Vector)(ref val)).X;
		Vector val2 = Skew;
		Vector val3 = default(Vector);
		((Vector)(ref val3))._002Ector(x, ((Vector)(ref val2)).Y);
		((Vector)(ref val3)).X = Math.Tan(((Vector)(ref val3)).X * Math.PI / 180.0);
		((Vector)(ref val3)).Y = Math.Tan(((Vector)(ref val3)).Y * Math.PI / 180.0);
		Vector val4 = Scale;
		if (((Vector)(ref val4)).X == 0.0)
		{
			((Vector)(ref appliedSkew)).Y = 0.0;
		}
		else
		{
			((Vector)(ref appliedSkew)).Y = ((Vector)(ref appliedSkew)).Y * (((Vector)(ref val4)).Y / ((Vector)(ref val4)).X);
		}
		if (((Vector)(ref val4)).Y == 0.0)
		{
			((Vector)(ref appliedSkew)).X = 0.0;
		}
		else
		{
			((Vector)(ref appliedSkew)).X = ((Vector)(ref appliedSkew)).X * (((Vector)(ref val4)).X / ((Vector)(ref val4)).Y);
		}
		SkewX = Math.Atan2(((Vector)(ref appliedSkew)).X + ((Vector)(ref val3)).X, 1.0 + ((Vector)(ref appliedSkew)).X * ((Vector)(ref val3)).Y) * 180.0 / Math.PI;
		SkewY = Math.Atan2(((Vector)(ref appliedSkew)).Y + ((Vector)(ref val3)).Y, 1.0 + ((Vector)(ref appliedSkew)).Y * ((Vector)(ref val3)).X) * 180.0 / Math.PI;
		ScaleX *= ((Vector)(ref appliedScale)).X * (1.0 + ((Vector)(ref appliedSkew)).Y * ((Vector)(ref val3)).X);
		ScaleY *= ((Vector)(ref appliedScale)).Y * (1.0 + ((Vector)(ref appliedSkew)).X * ((Vector)(ref val3)).Y);
	}

	public void ApplyRotation(double angle, Point fixedPoint)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0002: Unknown result type (might be due to invalid IL or missing references)
		//IL_0007: Unknown result type (might be due to invalid IL or missing references)
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Unknown result type (might be due to invalid IL or missing references)
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0036: Unknown result type (might be due to invalid IL or missing references)
		Point val = fixedPoint * Value;
		RotationAngle += angle;
		Point val2 = fixedPoint * Value;
		Translation += val - val2;
	}

	private void UpdateValue()
	{
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		//IL_002e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0041: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0065: Unknown result type (might be due to invalid IL or missing references)
		//IL_006a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		//IL_0085: Unknown result type (might be due to invalid IL or missing references)
		//IL_008f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ae: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_00dd: Unknown result type (might be due to invalid IL or missing references)
		//IL_00e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0101: Unknown result type (might be due to invalid IL or missing references)
		//IL_0106: Unknown result type (might be due to invalid IL or missing references)
		//IL_0110: Unknown result type (might be due to invalid IL or missing references)
		//IL_0115: Unknown result type (might be due to invalid IL or missing references)
		value = Matrix.Identity;
		ref Matrix reference = ref value;
		Vector val = Scale;
		double x = ((Vector)(ref val)).X;
		Vector val2 = Scale;
		double y = ((Vector)(ref val2)).Y;
		Point val3 = Center;
		double x2 = ((Point)(ref val3)).X;
		Point val4 = Center;
		((Matrix)(ref reference)).ScaleAt(x, y, x2, ((Point)(ref val4)).Y);
		ref Matrix reference2 = ref value;
		Point val5 = Center;
		double num = 0.0 - ((Point)(ref val5)).X;
		Point val6 = Center;
		((Matrix)(ref reference2)).Translate(num, 0.0 - ((Point)(ref val6)).Y);
		ref Matrix reference3 = ref value;
		Vector val7 = Skew;
		double x3 = ((Vector)(ref val7)).X;
		Vector val8 = Skew;
		((Matrix)(ref reference3)).Skew(x3, ((Vector)(ref val8)).Y);
		ref Matrix reference4 = ref value;
		Point val9 = Center;
		double x4 = ((Point)(ref val9)).X;
		Point val10 = Center;
		((Matrix)(ref reference4)).Translate(x4, ((Point)(ref val10)).Y);
		ref Matrix reference5 = ref value;
		double num2 = RotationAngle;
		Point val11 = Center;
		double x5 = ((Point)(ref val11)).X;
		Point val12 = Center;
		((Matrix)(ref reference5)).RotateAt(num2, x5, ((Point)(ref val12)).Y);
		ref Matrix reference6 = ref value;
		Vector val13 = Translation;
		double x6 = ((Vector)(ref val13)).X;
		Vector val14 = Translation;
		((Matrix)(ref reference6)).Translate(x6, ((Vector)(ref val14)).Y);
		needsUpdate = false;
	}

	private void ConvertGenericTransform(Matrix transform)
	{
		//IL_0013: Unknown result type (might be due to invalid IL or missing references)
		//IL_0030: Unknown result type (might be due to invalid IL or missing references)
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f5: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_0112: Unknown result type (might be due to invalid IL or missing references)
		//IL_012b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0180: Unknown result type (might be due to invalid IL or missing references)
		//IL_0185: Unknown result type (might be due to invalid IL or missing references)
		//IL_007c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0095: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a9: Unknown result type (might be due to invalid IL or missing references)
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02db: Unknown result type (might be due to invalid IL or missing references)
		//IL_02dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0302: Unknown result type (might be due to invalid IL or missing references)
		//IL_0307: Unknown result type (might be due to invalid IL or missing references)
		//IL_0325: Unknown result type (might be due to invalid IL or missing references)
		//IL_0326: Unknown result type (might be due to invalid IL or missing references)
		//IL_038b: Unknown result type (might be due to invalid IL or missing references)
		//IL_038d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0392: Unknown result type (might be due to invalid IL or missing references)
		//IL_039b: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a0: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a4: Unknown result type (might be due to invalid IL or missing references)
		//IL_03c5: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e7: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0380: Unknown result type (might be due to invalid IL or missing references)
		//IL_035f: Unknown result type (might be due to invalid IL or missing references)
		//IL_03e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_03ea: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01fd: Unknown result type (might be due to invalid IL or missing references)
		//IL_0247: Unknown result type (might be due to invalid IL or missing references)
		//IL_024c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0258: Unknown result type (might be due to invalid IL or missing references)
		//IL_0259: Unknown result type (might be due to invalid IL or missing references)
		//IL_0443: Unknown result type (might be due to invalid IL or missing references)
		//IL_0422: Unknown result type (might be due to invalid IL or missing references)
		//IL_0278: Unknown result type (might be due to invalid IL or missing references)
		//IL_0279: Unknown result type (might be due to invalid IL or missing references)
		Center = new Point(0.0, 0.0);
		Skew = new Vector(0.0, 0.0);
		RotationAngle = 0.0;
		if (((Matrix)(ref transform)).M21 == 0.0 && ((Matrix)(ref transform)).M12 == 0.0)
		{
			Translation = new Vector(((Matrix)(ref transform)).OffsetX, ((Matrix)(ref transform)).OffsetY);
			Scale = new Vector(((Matrix)(ref transform)).M11, ((Matrix)(ref transform)).M22);
			return;
		}
		Point val = default(Point);
		((Point)(ref val))._002Ector(0.0, 0.0);
		Vector val2 = default(Vector);
		((Vector)(ref val2))._002Ector(1.0, 0.0);
		Vector val3 = default(Vector);
		((Vector)(ref val3))._002Ector(0.0, 1.0);
		val2 *= transform;
		val3 *= transform;
		val *= transform;
		Translation = new Vector(((Point)(ref val)).X, ((Point)(ref val)).Y);
		Scale = new Vector(((Vector)(ref val2)).Length, ((Vector)(ref val3)).Length);
		bool flag = ((Vector)(ref val2)).LengthSquared > tolerance;
		bool flag2 = ((Vector)(ref val3)).LengthSquared > tolerance;
		double num = 0.0;
		double num2 = 0.0;
		if (flag)
		{
			num = GetAngle(new Vector(1.0, 0.0), val2);
		}
		if (flag2)
		{
			num2 = GetAngle(new Vector(0.0, 1.0), val3);
		}
		if (flag && flag2 && Math.Abs(Vector.CrossProduct(val2, val3)) <= tolerance)
		{
			Vector val4 = ((Math.Abs(num) <= Math.Abs(num2)) ? val2 : val3);
			Skew = new Vector(45.0, 45.0);
			ScaleX *= 0.7071067811865476;
			ScaleY *= 0.7071067811865476;
			RotationAngle = GetAngle(new Vector(1.0, 1.0), val4);
			if (val2 * val4 < 0.0)
			{
				ScaleX = 0.0 - ScaleX;
			}
			if (val3 * val4 < 0.0)
			{
				ScaleY = 0.0 - ScaleY;
			}
		}
		else
		{
			if (!flag && !flag2)
			{
				return;
			}
			if (!flag2 || (flag && Math.Abs(num) <= Math.Abs(num2)))
			{
				Vector val5 = val2;
				Vector val6 = Scale;
				Vector val7 = val5 / ((Vector)(ref val6)).X;
				Vector val8 = val3 - val7 * (((Vector)(ref val7)).X * ((Vector)(ref val3)).X + ((Vector)(ref val7)).Y * ((Vector)(ref val3)).Y);
				ScaleY = ((Vector)(ref val8)).Length;
				RotationAngle = num;
				if (flag2)
				{
					double angle = GetAngle(val2, val3);
					if (angle < 0.0)
					{
						ScaleY = 0.0 - ScaleY;
						Skew = new Vector(0.0 - angle - 90.0, 0.0);
					}
					else
					{
						Skew = new Vector(90.0 - angle, 0.0);
					}
				}
				return;
			}
			Vector val9 = val3;
			Vector val10 = Scale;
			Vector val11 = val9 / ((Vector)(ref val10)).Y;
			Vector val12 = val2 - val11 * (((Vector)(ref val11)).X * ((Vector)(ref val2)).X + ((Vector)(ref val11)).Y * ((Vector)(ref val2)).Y);
			ScaleX = ((Vector)(ref val12)).Length;
			RotationAngle = num2;
			if (flag)
			{
				double angle2 = GetAngle(val3, val2);
				if (angle2 > 0.0)
				{
					ScaleX = 0.0 - ScaleX;
					Skew = new Vector(0.0, angle2 - 90.0);
				}
				else
				{
					Skew = new Vector(0.0, angle2 + 90.0);
				}
			}
		}
	}

	private double GetAngle(Vector v1, Vector v2)
	{
		double num = Math.Atan2(((Vector)(ref v1)).X * ((Vector)(ref v2)).Y - ((Vector)(ref v1)).Y * ((Vector)(ref v2)).X, ((Vector)(ref v1)).X * ((Vector)(ref v2)).X + ((Vector)(ref v1)).Y * ((Vector)(ref v2)).Y);
		return num * 180.0 / Math.PI;
	}

	public object Clone()
	{
		return new CanonicalDecomposition(this);
	}
}
