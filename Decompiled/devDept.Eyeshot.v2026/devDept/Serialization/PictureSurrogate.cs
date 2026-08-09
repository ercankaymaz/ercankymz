using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;

namespace devDept.Serialization;

public class PictureSurrogate : EntitySurrogate
{
	public Plane Plane;

	public Point3D[] Vertices;

	public double Width;

	public double Height;

	public ProtoImage Image;

	public bool Lighted;

	public bool DrawEdge;

	public byte MagnifyingFunction;

	public byte MinifyingFunction;

	public bool Tiling;

	public bool AnisotropicFiltering;

	public bool ShowClipped;

	public Polygon2D ClippingBoundary;

	internal IndexTriangle[] indexTriangleMesh;

	public string FilePath;

	public PictureSurrogate(Picture picture)
		: base(picture)
	{
	}

	protected override Entity ConvertToObject()
	{
		Picture picture = new Picture(this);
		CopyDataToObject(picture);
		return picture;
	}

	protected override void CopyDataToObject(Entity entity)
	{
		Picture obj = (Picture)entity;
		obj.Vertices = Vertices;
		obj.Lighted = Lighted;
		obj.DrawEdge = DrawEdge;
		obj.MagnifyingFunction = (textureFilteringFunctionType)MagnifyingFunction;
		obj.MinifyingFunction = (textureFilteringFunctionType)MinifyingFunction;
		obj.Tiling = Tiling;
		obj.AnisotropicFiltering = AnisotropicFiltering;
		obj.ShowClipped = ShowClipped;
		obj.ClippingBoundary = ClippingBoundary;
		obj.indexTriangleMesh = indexTriangleMesh;
		obj.FilePath = FilePath;
		base.CopyDataToObject(entity);
	}

	protected override void CopyDataFromObject(Entity entity)
	{
		Picture picture = (Picture)entity;
		Plane = picture.Plane;
		Vertices = picture.Vertices;
		Width = picture.Width;
		Height = picture.Height;
		Image = new ProtoImage(picture.Image);
		Lighted = picture.Lighted;
		DrawEdge = picture.DrawEdge;
		MagnifyingFunction = (byte)picture.MagnifyingFunction;
		MinifyingFunction = (byte)picture.MinifyingFunction;
		Tiling = picture.Tiling;
		AnisotropicFiltering = picture.AnisotropicFiltering;
		ShowClipped = picture.ShowClipped;
		ClippingBoundary = picture.ClippingBoundary;
		indexTriangleMesh = picture.indexTriangleMesh;
		FilePath = picture.FilePath;
		base.CopyDataFromObject(entity);
	}
}
