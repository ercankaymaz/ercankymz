using System;
using System.Drawing;
using ProtoBuf;
using devDept.Eyeshot.Control.Labels;
using devDept.Geometry;

namespace devDept.Serialization;

public class LabelSurrogate : SurrogateWithReferenceId<Label>
{
	public Color Color;

	public Point3D AnchorPoint;

	public Bitmap Image;

	public bool Visible;

	public ProtoObject LabelData;

	public bool Selectable;

	public int Alignment;

	public bool AutoHide;

	public string Type;

	public LabelSurrogate(Label label)
		: base(label)
	{
	}

	private LabelSurrogate(int _0023_003DzbelEfsY_003D)
		: base(_0023_003DzbelEfsY_003D)
	{
	}

	protected override Label ConvertToObject()
	{
		WriteLog(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348614161) + Type + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620810));
		return null;
	}

	protected override void CopyDataToObject(Label label)
	{
		label.labelColor = Color;
		label.AnchorPoint = AnchorPoint;
		label.SetImage(Image);
		label.Visible = Visible;
		label.Selectable = Selectable;
		label.Alignment = (ContentAlignment)Alignment;
		label.AutoHide = AutoHide;
		if (LabelData != null)
		{
			label.LabelData = LabelData.Object;
		}
	}

	protected override void CopyDataFromObject(Label label)
	{
		Color = label.labelColor;
		AnchorPoint = label.AnchorPoint;
		Image = label.Image;
		Visible = label.Visible;
		Selectable = label.Selectable;
		Alignment = (int)label.Alignment;
		AutoHide = label.AutoHide;
		Type = label.GetType().FullName;
		if (label.LabelData != null)
		{
			LabelData = new ProtoObject(label.LabelData);
		}
	}

	protected virtual bool CheckSurrogateData(string logMessage = null)
	{
		return true;
	}

	public static implicit operator Label(LabelSurrogate surrogate)
	{
		Label label = Serializer.GetCachedObject(surrogate) as Label;
		if (label != null)
		{
			return label;
		}
		if (surrogate != null)
		{
			label = surrogate.ConvertToObject();
			Serializer.AddToCache(surrogate, label);
			if (label == null)
			{
				if (string.IsNullOrEmpty(surrogate.Log))
				{
					surrogate.WriteLog(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348614218) + surrogate.GetType().Name + _0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348620810));
				}
				return null;
			}
		}
		return label;
	}

	public static implicit operator LabelSurrogate(Label source)
	{
		if (source == null)
		{
			return null;
		}
		LabelSurrogate labelSurrogate2;
		if (Serializer.GetCachedObjectWithReferenceId(source) is LabelSurrogate labelSurrogate)
		{
			labelSurrogate2 = new LabelSurrogate(labelSurrogate.ReferenceId);
		}
		else
		{
			labelSurrogate2 = source.ConvertToSurrogate();
			Serializer.AddToCache(source, labelSurrogate2);
		}
		if (labelSurrogate2 == null)
		{
			Type type = source.GetType();
			throw new EyeshotException(string.Format(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348614229), type, type));
		}
		return labelSurrogate2;
	}

	[CLSCompliant(false)]
	protected override void BeforeDeserialize(SerializationContext serializationContext)
	{
		base.BeforeDeserialize(serializationContext);
		if (!(serializationContext.Context is FileSerializer))
		{
			throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348614576));
		}
	}

	[CLSCompliant(false)]
	protected override void BeforeSerialize(SerializationContext serializationContext)
	{
		base.BeforeSerialize(serializationContext);
		FileSerializer obj = (serializationContext.Context as FileSerializer) ?? throw new ArgumentException(_0023_003Dz_0024SkdLWSMgmT4iXdAgakTAp3wstK4._0023_003DzDw__wI8_003D(348614404));
		CheckSurrogateData();
		obj.WriteLog(base.Log);
	}
}
