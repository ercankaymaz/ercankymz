using System.Drawing;
using devDept.Eyeshot.Control.Labels;

namespace devDept.Serialization;

public class ImageOnlySurrogate : LabelSurrogate
{
	public Point HotSpot;

	public Bitmap ImageForSelection;

	public ImageOnlySurrogate(ImageOnly imageOnly)
		: base(imageOnly)
	{
	}

	protected override Label ConvertToObject()
	{
		ImageOnly imageOnly = new ImageOnly(AnchorPoint, Image, HotSpot.X, HotSpot.Y);
		CopyDataToObject(imageOnly);
		return imageOnly;
	}

	protected override void CopyDataToObject(Label label)
	{
		ImageOnly obj = (ImageOnly)label;
		obj.HotSpot = new Point(HotSpot.X, HotSpot.Y);
		obj.ImageForSelection = ImageForSelection;
		base.CopyDataToObject(label);
	}

	protected override void CopyDataFromObject(Label label)
	{
		ImageOnly imageOnly = (ImageOnly)label;
		HotSpot = new Point(imageOnly.HotSpot.X, imageOnly.HotSpot.Y);
		ImageForSelection = imageOnly.ImageForSelection;
		base.CopyDataFromObject(label);
	}
}
