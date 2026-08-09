using System.Collections.Generic;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;

namespace devDept.Serialization;

public class SheetSurrogate : Surrogate<Sheet>
{
	public byte Units;

	public double Width;

	public double Height;

	public string Name;

	public Camera Camera;

	public List<Entity> Entities;

	public byte AngleProjectionMode;

	public SheetSurrogate(Sheet sheet)
		: base(sheet)
	{
	}

	protected override Sheet ConvertToObject()
	{
		Sheet sheet = new Sheet(this);
		CopyDataToObject(sheet);
		return sheet;
	}

	protected override void CopyDataToObject(Sheet sheet)
	{
		sheet.Camera = Camera;
		if (Entities != null)
		{
			sheet.Entities = Entities;
		}
	}

	protected override void CopyDataFromObject(Sheet sheet)
	{
		Units = (byte)sheet.Units;
		Width = sheet.Width;
		Height = sheet.Height;
		Name = sheet.Name;
		Camera = sheet.Camera;
		AngleProjectionMode = (byte)sheet.AngleProjectionMode;
		Entities = sheet.Entities ?? new List<Entity>();
	}

	public static implicit operator Sheet(SheetSurrogate surrogate)
	{
		return surrogate?.ConvertToObject();
	}

	public static implicit operator SheetSurrogate(Sheet source)
	{
		return source?.ConvertToSurrogate();
	}
}
