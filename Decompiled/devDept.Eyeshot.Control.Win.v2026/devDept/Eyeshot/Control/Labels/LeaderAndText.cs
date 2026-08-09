using System;
using System.Drawing;
using System.Runtime.Serialization;
using devDept.Geometry;
using devDept.Graphics;
using devDept.Serialization;

namespace devDept.Eyeshot.Control.Labels;

[Serializable]
public class LeaderAndText : TextOnly
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

	public LeaderAndText(double x, double y, double z, string text, Font textFont, Color textColor, Vector2D offset)
		: this(new Point3D(x, y, z), text, textFont, textColor, offset)
	{
	}

	public LeaderAndText(Point3D p, string text, Font textFont, Color textColor, Vector2D offset)
		: base(p, text, textFont, textColor)
	{
		Offset = offset;
	}

	public LeaderAndText(Point3D p, string text, Font textFont, Color textColor, int offsetX, int offsetY)
		: this(p, text, textFont, textColor, new Vector2D(offsetX, offsetY))
	{
	}

	protected LeaderAndText(LeaderAndText another)
		: base(another)
	{
		Offset = (Vector2D)another.Offset.Clone();
	}

	protected LeaderAndText(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		Offset = (Vector2D)info.GetValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649421), typeof(Vector2D));
	}

	public override object Clone()
	{
		return new LeaderAndText(this);
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
		if (labelFillColor != Color.Empty)
		{
			renderContext.SetColorWireframe(labelFillColor);
		}
		else
		{
			renderContext.SetColorWireframe(labelColor);
		}
		_0023_003DzCr91__0024HyQlKJ(renderContext, drawScale);
	}

	private void _0023_003DzCr91__0024HyQlKJ(RenderContextBase _0023_003DzmNZD0Zs_003D, float _0023_003DzCzsr4CTVr_Ea)
	{
		_0023_003DzmNZD0Zs_003D.PushShader();
		_0023_003DzmNZD0Zs_003D.SetShader(shaderType.NoLights);
		DrawLeaderLine(_0023_003DzmNZD0Zs_003D, Offset, _0023_003DzCzsr4CTVr_Ea);
		_0023_003DzmNZD0Zs_003D.PopShader();
		base._0023_003DzRzuCrPw_003D(_0023_003DzmNZD0Zs_003D, (float)((double)xPos + Offset.X * (double)_0023_003DzCzsr4CTVr_Ea), (float)((double)yPos + Offset.Y * (double)_0023_003DzCzsr4CTVr_Ea), _0023_003DzCzsr4CTVr_Ea);
	}

	protected internal override void DrawForSelection(RenderContextBase context)
	{
		DrawLeaderLine(context, Offset, 1f);
		DrawForSelection(context, (float)((double)xPos + Offset.X), (float)((double)yPos + Offset.Y));
	}

	public override LabelSurrogate ConvertToSurrogate()
	{
		return new LeaderAndTextSurrogate(this);
	}

	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348649421), Offset);
	}
}
