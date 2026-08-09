using System.Drawing;

namespace SourceGrid.Cells.Models;

public class Image : IModel, IImage
{
	private System.Drawing.Image image;

	public System.Drawing.Image ImageValue
	{
		get
		{
			return image;
		}
		set
		{
			image = value;
		}
	}

	public Image()
	{
	}

	public Image(System.Drawing.Image image)
	{
		this.image = image;
	}

	public System.Drawing.Image GetImage(CellContext cellContext)
	{
		return image;
	}
}
