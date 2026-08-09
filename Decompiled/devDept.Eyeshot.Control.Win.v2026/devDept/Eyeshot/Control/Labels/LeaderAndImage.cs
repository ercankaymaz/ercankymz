using System;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Control.Labels;

[Serializable]
public class LeaderAndImage : ImageOnly
{
	private Vector2D _offset;

	public Vector2D Offset
	{
		get
		{
			return _offset;
		}
		set
		{
			_offset = value;
		}
	}

	public override Point2D OnScreenPosition => new Point2D((double)xPos + Offset.X, (double)yPos + Offset.Y);

	public LeaderAndImage(Point3D anchorPoint, Bitmap bitmap, Color leaderColor, Vector2D offset)
		: this(anchorPoint, bitmap, leaderColor, 0, 0, offset)
	{
	}

	public LeaderAndImage(Point3D anchorPoint, Bitmap bitmap, Color leaderColor, int hotspotX, int hotspotY, Vector2D offset)
		: this(anchorPoint.X, anchorPoint.Y, anchorPoint.Z, bitmap, leaderColor, hotspotX, hotspotY, offset)
	{
	}

	public LeaderAndImage(double x, double y, double z, Bitmap bitmap, Color leaderColor, Vector2D offset)
		: this(x, y, z, bitmap, leaderColor, 0, 0, offset)
	{
	}

	public LeaderAndImage(double x, double y, double z, Bitmap bitmap, Color leaderColor, int hotspotX, int hotspotY, Vector2D offset)
		: base(x, y, z, bitmap, hotspotX, hotspotY)
	{
		Offset = offset;
		base.Color = RenderContextUtility.ConvertColor(leaderColor);
	}

	protected LeaderAndImage(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Offset = (Vector2D)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649421), typeof(Vector2D));
	}

	protected LeaderAndImage(LeaderAndImage another)
		: base(another)
	{
		Offset = (Vector2D)another.Offset.Clone();
	}

	protected override Point2D DrawPosition(double drawScale)
	{
		Point2D point2D = base.DrawPosition(drawScale);
		point2D.X += drawScale * Offset.X;
		point2D.Y += drawScale * Offset.Y;
		return point2D;
	}

	internal override Vector2D _0023_003DzNifTp9RWbw8l()
	{
		return Offset;
	}

	public override void DrawSelected(RenderContextBase renderContext)
	{
		_0023_003DzCr91__0024HyQlKJ(renderContext, 1f);
	}

	public override void Draw(RenderContextBase renderContext, float drawScale)
	{
		renderContext.SetColorWireframe(labelColor);
		_0023_003DzCr91__0024HyQlKJ(renderContext, drawScale);
	}

	private void _0023_003DzCr91__0024HyQlKJ(RenderContextBase _0023_003DzmNZD0Zs_003D, float _0023_003DzCzsr4CTVr_Ea)
	{
		_0023_003DzmNZD0Zs_003D.PushShader();
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		DrawLeaderLine(_0023_003DzmNZD0Zs_003D, Offset, _0023_003DzCzsr4CTVr_Ea);
		_0023_003DzmNZD0Zs_003D.PopShader();
		base.Draw(_0023_003DzmNZD0Zs_003D, _0023_003DzCzsr4CTVr_Ea);
	}

	protected internal override void DrawForSelection(RenderContextBase context)
	{
		DrawLeaderLine(context, Offset, 1f);
		base.DrawForSelection(context);
	}

	public override LabelSurrogate ConvertToSurrogate()
	{
		return new LeaderAndImageSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649421), Offset);
	}

	public override object Clone()
	{
		return new LeaderAndImage(this);
	}
}
