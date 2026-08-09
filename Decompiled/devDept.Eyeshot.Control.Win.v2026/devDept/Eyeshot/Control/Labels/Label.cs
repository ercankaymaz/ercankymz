using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Control.Labels;

[Serializable]
public abstract class Label : ILabel, ISerializable, IDisposable, ICloneable, ISelectableItem
{
	protected internal Color labelColor;

	private Point3D _anchorPoint;

	internal float xPos;

	internal float yPos;

	internal double zPos;

	protected Bitmap bitmapImage;

	protected Bitmap userImageForSelection;

	protected TextureBase texture;

	protected TextureBase selectedTexture;

	private regenType _regenMode = regenType.RegenAndCompile;

	private ContentAlignment _alignment = ContentAlignment.BottomLeft;

	internal Bitmap selectedBitmap;

	private bool _visible = true;

	internal bool hidden;

	internal SelectionInfoItem _selectionInfo = new SelectionInfoItem(null, null);

	private int _frameHeight;

	public virtual Size Size => bitmapImage.Size;

	protected internal Bitmap Image => bitmapImage;

	public regenType RegenMode
	{
		get
		{
			return _regenMode;
		}
		set
		{
			_regenMode = value;
		}
	}

	public ContentAlignment Alignment
	{
		get
		{
			return _alignment;
		}
		set
		{
			_alignment = value;
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public bool AutoHide { get; set; }

	public virtual bool Selected
	{
		get
		{
			return _selectionInfo.SelectionInfo.IsSelected();
		}
		set
		{
			_selectionInfo.SelectionInfo.SetSelection(value);
			if (Selected)
			{
				CreateSelectedBitmap(1f);
			}
		}
	}

	public virtual bool Selectable { get; set; }

	public Color Color
	{
		get
		{
			return RenderContextUtility.ConvertColor(labelColor);
		}
		set
		{
			labelColor = RenderContextUtility.ConvertColor(value);
			RegenMode = regenType.RegenAndCompile;
		}
	}

	public virtual object LabelData { get; set; }

	public virtual Point2D OnScreenPosition => new Point2D(xPos, yPos);

	public Point3D AnchorPoint
	{
		get
		{
			return _anchorPoint;
		}
		set
		{
			_anchorPoint = value;
		}
	}

	public virtual bool Visible
	{
		get
		{
			return _visible;
		}
		set
		{
			_visible = value;
		}
	}

	protected Label(Label another)
	{
		Color = another.Color;
		_anchorPoint = (Point3D)another._anchorPoint.Clone();
		Selectable = another.Selectable;
		_selectionInfo = new SelectionInfoItem(another);
		Visible = another.Visible;
		Alignment = another.Alignment;
		AutoHide = another.AutoHide;
		if (another.LabelData is ICloneable)
		{
			LabelData = ((ICloneable)another.LabelData).Clone();
		}
		else if (another.LabelData is ValueType)
		{
			LabelData = another.LabelData;
		}
	}

	protected Label(Color color)
	{
		labelColor = color;
		LabelData = null;
		Selectable = true;
	}

	protected Label(double x, double y, double z, Color color)
		: this(new Point3D(x, y, z), color)
	{
	}

	protected Label(Point3D anchorPoint, Color color)
		: this(color)
	{
		_anchorPoint = anchorPoint;
	}

	protected Label(Point3D anchorPoint, Color color, bool selectable)
		: this(anchorPoint, color)
	{
		Selectable = selectable;
	}

	protected Label(SerializationInfo info, StreamingContext context)
	{
		labelColor = (Color)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650533), typeof(Color));
		_anchorPoint = (Point3D)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589352), typeof(Point3D));
		SetImage((Bitmap)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650751), typeof(Bitmap)));
		_visible = info.GetBoolean(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566));
		LabelData = info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589365), typeof(object));
		Selectable = info.GetBoolean(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588978));
		_alignment = (ContentAlignment)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589379), typeof(ContentAlignment));
		AutoHide = info.GetBoolean(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589395));
	}

	public virtual void ScaleForDPI()
	{
	}

	protected internal void SetImage(Bitmap image)
	{
		bitmapImage = image;
		if (selectedBitmap != null)
		{
			selectedBitmap.Dispose();
			selectedBitmap = null;
		}
		if (Selected && bitmapImage != null)
		{
			CreateSelectedBitmap(1f);
		}
		else
		{
			selectedBitmap = null;
		}
	}

	internal void _0023_003DzKUR_0024H20_003D(selectionStatusType _0023_003DzjPUaqyA_003D, Stack<BlockReference> _0023_003Dzbq3BJR0_003D)
	{
		_selectionInfo.SelectionInfo.SetFlag(_0023_003DzjPUaqyA_003D);
	}

	internal void _0023_003Dz6hAGbQNtz6rX(selectionStatusType _0023_003DzjPUaqyA_003D, Stack<BlockReference> _0023_003Dzbq3BJR0_003D)
	{
		_selectionInfo.SelectionInfo.InvertFlag(_0023_003DzjPUaqyA_003D);
	}

	internal bool _0023_003DzCYzQeCJcqySV(selectionStatusType _0023_003DzjPUaqyA_003D, Stack<BlockReference> _0023_003Dzbq3BJR0_003D)
	{
		return _selectionInfo.SelectionInfo.IsFlagSet(_0023_003DzjPUaqyA_003D);
	}

	internal void _0023_003Dz_00244Tzms_00244tvZL(selectionStatusType _0023_003DzjPUaqyA_003D, Stack<BlockReference> _0023_003Dzbq3BJR0_003D)
	{
		_selectionInfo.SelectionInfo.UnsetFlag(_0023_003DzjPUaqyA_003D);
	}

	public bool IsAnyInstanceSelected()
	{
		return Selected;
	}

	public void ClearSelectionForAllInstances()
	{
		Selected = false;
	}

	public bool GetSelection(Stack<BlockReference> parents = null)
	{
		return Selected;
	}

	[Obsolete("Use GetSelection(parents) instead")]
	public bool IsSelected(Stack<BlockReference> parents = null)
	{
		return Selected;
	}

	protected virtual void CreateSelectedBitmap(float drawScale)
	{
		if (selectedBitmap == null && Image != null && userImageForSelection == null)
		{
			byte[] array = new byte[4 * Image.Width * Image.Height];
			BitmapData bitmapData = Image.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			Marshal.Copy(bitmapData.Scan0, array, 0, array.Length);
			Image.UnlockBits(bitmapData);
			int num;
			for (num = 0; num < array.Length; num++)
			{
				array[num] = (byte)(255 - array[num]);
				num++;
				array[num] = (byte)(255 - array[num]);
				num++;
				array[num] = (byte)(255 - array[num]);
				num++;
				array[num] = array[num];
			}
			selectedBitmap = new Bitmap(Image.Width, Image.Height);
			BitmapData bitmapData2 = selectedBitmap.LockBits(new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
			Marshal.Copy(array, 0, bitmapData2.Scan0, array.Length);
			selectedBitmap.UnlockBits(bitmapData2);
		}
	}

	protected virtual void DrawLeaderLine(RenderContextBase renderContext, Vector2D offset, float drawScale)
	{
		if (offset.X != 0.0 || offset.Y != 0.0)
		{
			renderContext.DrawLines(new float[6]
			{
				xPos,
				yPos,
				0f,
				(float)((double)xPos + offset.X * (double)drawScale),
				(float)((double)yPos + offset.Y * (double)drawScale),
				0f
			});
		}
	}

	public virtual void Dispose()
	{
		if (Image != null)
		{
			Image.Dispose();
			SetImage(null);
		}
		if (selectedBitmap != null)
		{
			selectedBitmap.Dispose();
			selectedBitmap = null;
		}
		_0023_003DzPY_0024ulDyKjEOA();
		RegenMode = regenType.RegenAndCompile;
	}

	internal virtual void _0023_003DzPY_0024ulDyKjEOA()
	{
		if (texture != null)
		{
			texture.Dispose();
		}
		texture = null;
		if (selectedTexture != null)
		{
			selectedTexture.Dispose();
			selectedTexture = null;
		}
	}

	public void UpdatePos(RenderContextBase renderContext, double[] modelViewProj, int[] viewFrame)
	{
		Camera.ComputeScreenPosition(renderContext, modelViewProj, viewFrame, _anchorPoint, out xPos, out yPos, out zPos);
		_frameHeight = viewFrame[3];
	}

	public virtual void Regen(RenderContextBase renderContext, float drawScale)
	{
		if (renderContext == null)
		{
			RegenMode = regenType.RegenAndCompile;
		}
		else
		{
			_0023_003Dz8WTvZ9I_003D(renderContext);
		}
	}

	private void _0023_003Dz8WTvZ9I_003D(RenderContextBase _0023_003DzmNZD0Zs_003D)
	{
		if (texture != null)
		{
			texture.Dispose();
		}
		texture = _0023_003DzmNZD0Zs_003D.CreateTexture2D(Image, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, enlargeIfSizeNotSupported: true);
		if (selectedTexture != null)
		{
			selectedTexture.Dispose();
			selectedTexture = null;
		}
		RegenMode = regenType.NotNeeded;
	}

	public virtual bool IsClipped(ClippingPlaneBase[] planes)
	{
		foreach (ClippingPlaneBase clippingPlaneBase in planes)
		{
			if (clippingPlaneBase.Active && clippingPlaneBase.Plane.DistanceTo(AnchorPoint) > 0.0)
			{
				return true;
			}
		}
		return false;
	}

	public virtual void Draw(RenderContextBase renderContext, float drawScale)
	{
	}

	public virtual void DrawSelected(RenderContextBase renderContext)
	{
		Draw(renderContext, 1f);
	}

	protected TextureBase GetTexture(RenderContextBase renderContext)
	{
		if (Selected)
		{
			if (selectedTexture == null)
			{
				selectedTexture = renderContext.CreateTexture2D(userImageForSelection ?? selectedBitmap, textureFilteringFunctionType.Nearest, textureFilteringFunctionType.Nearest, anisotropicFiltering: false, enlargeIfSizeNotSupported: true);
			}
			return selectedTexture;
		}
		return texture;
	}

	protected Bitmap GetBitmap()
	{
		if (!Selected)
		{
			return Image;
		}
		return selectedBitmap;
	}

	protected internal virtual void DrawForSelection(RenderContextBase renderContext)
	{
	}

	public virtual void DrawWithOffset(RenderContextBase renderContext, int dx, int dy, float drawScale)
	{
	}

	public abstract LabelSurrogate ConvertToSurrogate();

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650533), labelColor);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589352), _anchorPoint);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650751), Image);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348650566), _visible);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589365), LabelData);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348588978), Selectable);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589379), Alignment);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348589395), AutoHide);
	}

	protected virtual Point2D ComputePositions(float x, float y, float drawScale)
	{
		return _alignment switch
		{
			ContentAlignment.BottomLeft => new Point2D(x, y), 
			ContentAlignment.BottomCenter => new Point2D(x - (float)(Image.Width / 2), y), 
			ContentAlignment.BottomRight => new Point2D(x - (float)Image.Width, y), 
			ContentAlignment.MiddleLeft => new Point2D(x, y - (float)(Image.Height / 2)), 
			ContentAlignment.MiddleCenter => new Point2D(x - (float)(Image.Width / 2), y - (float)(Image.Height / 2)), 
			ContentAlignment.MiddleRight => new Point2D(x - (float)Image.Width, y - (float)(Image.Height / 2)), 
			ContentAlignment.TopLeft => new Point2D(x, y - (float)Image.Height), 
			ContentAlignment.TopCenter => new Point2D(x - (float)(Image.Width / 2), y - (float)Image.Height), 
			ContentAlignment.TopRight => new Point2D(x - (float)Image.Width, y - (float)Image.Height), 
			_ => new Point2D(0.0, 0.0), 
		};
	}

	protected void DrawTexture(RenderContextBase renderContext, TextureBase labelTexture, RectangleF rect, bool flipY)
	{
		float num = (float)labelTexture.BitmapSize.Width / (float)labelTexture.Size.Width;
		float num2 = (float)labelTexture.BitmapSize.Height / (float)labelTexture.Size.Height;
		float num3 = (flipY ? num2 : 0f);
		renderContext.DrawQuadWithTextures(labelTexture, new float[8]
		{
			0f,
			num3,
			num,
			num3,
			num,
			num2 - num3,
			0f,
			num2 - num3
		}, byte.MaxValue, rect, 0f, buffered: false);
	}

	internal virtual Vector2D _0023_003DzNifTp9RWbw8l()
	{
		return new Vector2D();
	}

	internal Point3D[] _0023_003DzNOeClJy06sCB(Camera _0023_003DzZ_0024IejP0R_0024_Cw, int[] _0023_003DzBppTnBIbeUl7, int _0023_003DzatgWgTMc3NTm)
	{
		Point3D intPoint = _0023_003DzZ_0024IejP0R_0024_Cw.WorldToScreen(_anchorPoint, _0023_003DzBppTnBIbeUl7);
		Vector2D vector2D = _0023_003DzNifTp9RWbw8l();
		intPoint.X += vector2D.X;
		intPoint.Y += vector2D.Y;
		Point3D intPoint2 = new Point3D(intPoint.X + (double)Size.Width, intPoint.Y + (double)Size.Height);
		Plane plane = new Plane(AnchorPoint, _0023_003DzZ_0024IejP0R_0024_Cw.ViewNormal);
		Point2D point2D = ComputePositions((float)intPoint.X, (float)intPoint.Y, 1f);
		Point2D point2D2 = ComputePositions((float)intPoint2.X, (float)intPoint2.Y, 1f);
		_0023_003DzZ_0024IejP0R_0024_Cw.ScreenToPlane(new System.Drawing.Point((int)point2D.X, _0023_003DzatgWgTMc3NTm - (int)point2D.Y), plane, _0023_003DzatgWgTMc3NTm, _0023_003DzBppTnBIbeUl7, out intPoint);
		_0023_003DzZ_0024IejP0R_0024_Cw.ScreenToPlane(new System.Drawing.Point((int)point2D2.X, _0023_003DzatgWgTMc3NTm - (int)point2D2.Y), plane, _0023_003DzatgWgTMc3NTm, _0023_003DzBppTnBIbeUl7, out intPoint2);
		return new Point3D[2] { intPoint, intPoint2 };
	}

	public abstract object Clone();
}
