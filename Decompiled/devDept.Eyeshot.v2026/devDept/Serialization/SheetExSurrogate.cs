using devDept.Eyeshot;
using devDept.Eyeshot.Translators;
using devDept.Geometry;

namespace devDept.Serialization;

internal class SheetExSurrogate : SheetSurrogate
{
	internal byte Rotation;

	internal string CanonicalMediaName;

	public SheetExSurrogate(SheetEx sheetEx)
		: base(sheetEx)
	{
	}

	protected override Sheet ConvertToObject()
	{
		Sheet sheet = new Sheet((linearUnitsType)Units, Width, Height, Name, (angleProjectionType)AngleProjectionMode);
		CopyDataToObject(sheet);
		return sheet;
	}
}
