using ACadSharp.Attributes;
using CSMath;

namespace ACadSharp.Objects;

[DxfName("SCALE")]
[DxfSubClass("AcDbScale")]
public class Scale : NonGraphicalObject
{
	public const string DefaultName = "1:1";

	public static Scale Default => new Scale
	{
		Name = "1:1",
		PaperUnits = 1.0,
		DrawingUnits = 1.0,
		IsUnitScale = true
	};

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string ObjectName => "SCALE";

	public override string SubclassMarker => "AcDbScale";

	[DxfCodeValue(new int[] { 300 })]
	public override string Name
	{
		get
		{
			return base.Name;
		}
		set
		{
			base.Name = value;
		}
	}

	[DxfCodeValue(new int[] { 140 })]
	public double PaperUnits { get; set; }

	[DxfCodeValue(new int[] { 141 })]
	public double DrawingUnits { get; set; }

	[DxfCodeValue(new int[] { 290 })]
	public bool IsUnitScale { get; set; }

	public double ScaleFactor => PaperUnits / DrawingUnits;

	public Scale()
	{
	}

	public Scale(string name)
		: base(name)
	{
	}

	public double ApplyTo(double value)
	{
		return value * ScaleFactor;
	}

	public T ApplyTo<T>(T value) where T : IVector, new()
	{
		T result = new T();
		for (int i = 0; i < value.Dimension; i++)
		{
			result[i] = ApplyTo(value[i]);
		}
		return result;
	}
}
