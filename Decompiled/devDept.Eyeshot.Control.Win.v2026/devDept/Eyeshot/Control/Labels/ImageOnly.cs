using System;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Control.Labels;

[Serializable]
public class ImageOnly : Label
{
	private System.Drawing.Point _hotSpot;

	public System.Drawing.Point HotSpot
	{
		get
		{
			return _hotSpot;
		}
		set
		{
			_hotSpot = value;
		}
	}

	public new Bitmap Image
	{
		get
		{
			return bitmapImage;
		}
		set
		{
			SetImage(value);
			base.RegenMode = regenType.RegenAndCompile;
		}
	}

	public Bitmap ImageForSelection
	{
		get
		{
			return userImageForSelection;
		}
		set
		{
			userImageForSelection = value;
			base.RegenMode = regenType.RegenAndCompile;
		}
	}

	public ImageOnly(Point3D anchorPoint, Bitmap bitmap)
		: this(anchorPoint, bitmap, 0, 0)
	{
	}

	public ImageOnly(Point3D anchorPoint, Bitmap bitmap, int hotspotX, int hotspotY)
		: this(anchorPoint.X, anchorPoint.Y, anchorPoint.Z, bitmap, hotspotX, hotspotY)
	{
	}

	public ImageOnly(double x, double y, double z, Bitmap bitmap)
		: this(x, y, z, bitmap, 0, 0)
	{
	}

	public ImageOnly(double x, double y, double z, Bitmap bitmap, int hotspotX, int hotspotY)
		: base(x, y, z, Color.White)
	{
		SetImage(bitmap);
		HotSpot = new System.Drawing.Point(hotspotX, hotspotY);
	}

	protected ImageOnly(ImageOnly another)
		: base(another)
	{
		Image = another.Image;
		ImageForSelection = another.ImageForSelection;
		HotSpot = another.HotSpot;
	}

	protected ImageOnly(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		HotSpot = (System.Drawing.Point)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589326), typeof(System.Drawing.Point));
		ImageForSelection = (Bitmap)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589312), typeof(Bitmap));
	}

	public override object Clone()
	{
		return new ImageOnly(this);
	}

	public override void Dispose()
	{
		if (selectedBitmap != null)
		{
			selectedBitmap.Dispose();
			selectedBitmap = null;
		}
		_0023_003DzPY_0024ulDyKjEOA();
		base.RegenMode = regenType.RegenAndCompile;
	}

	public override void Draw(RenderContextBase renderContext, float drawScale)
	{
		Point2D point2D = DrawPosition(drawScale);
		Point2D point2D2 = ComputePositions((float)point2D.X, (float)point2D.Y, drawScale);
		TextureBase textureBase = GetTexture(renderContext);
		RectangleF rect = new RectangleF((int)point2D2.X, (int)point2D2.Y, (float)textureBase.BitmapSize.Width * drawScale, (float)textureBase.BitmapSize.Height * drawScale);
		if (rect.Width > 0f && rect.Height > 0f)
		{
			renderContext.SetShader(shaderType.Texture2DNoLights);
			DrawTexture(renderContext, textureBase, rect, flipY: true);
		}
	}

	protected override Point2D ComputePositions(float x, float y, float drawScale)
	{
		return base.Alignment switch
		{
			ContentAlignment.BottomLeft => new Point2D(x, y), 
			ContentAlignment.BottomCenter => new Point2D(x - drawScale * (float)Image.Width / 2f, y), 
			ContentAlignment.BottomRight => new Point2D(x - drawScale * (float)Image.Width, y), 
			ContentAlignment.MiddleLeft => new Point2D(x, y - drawScale * (float)Image.Height / 2f), 
			ContentAlignment.MiddleCenter => new Point2D(x - drawScale * (float)Image.Width / 2f, y - drawScale * (float)Image.Height / 2f), 
			ContentAlignment.MiddleRight => new Point2D(x - drawScale * (float)Image.Width, y - drawScale * (float)Image.Height / 2f), 
			ContentAlignment.TopLeft => new Point2D(x, y - drawScale * (float)Image.Height), 
			ContentAlignment.TopCenter => new Point2D(x - drawScale * (float)Image.Width / 2f, y - drawScale * (float)Image.Height), 
			ContentAlignment.TopRight => new Point2D(x - drawScale * (float)Image.Width, y - drawScale * (float)Image.Height), 
			_ => new Point2D(0.0, 0.0), 
		};
	}

	protected virtual Point2D DrawPosition(double drawScale)
	{
		return new Point2D(xPos - (float)HotSpot.X, yPos - (float)HotSpot.Y);
	}

	protected internal override void DrawForSelection(RenderContextBase renderContext)
	{
		Point2D point2D = DrawPosition(1.0);
		Point2D point2D2 = ComputePositions((float)point2D.X, (float)point2D.Y, 1f);
		renderContext.DrawQuad(new RectangleF((float)point2D2.X, (float)point2D2.Y, Image.Width, Image.Height));
		base.DrawForSelection(renderContext);
	}

	public override LabelSurrogate ConvertToSurrogate()
	{
		return new ImageOnlySurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589326), HotSpot);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589312), ImageForSelection);
	}
}
