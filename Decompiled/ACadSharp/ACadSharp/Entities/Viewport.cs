using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Attributes;
using ACadSharp.Extensions;
using ACadSharp.Objects;
using ACadSharp.Tables;
using CSMath;

namespace ACadSharp.Entities;

[DxfName("VIEWPORT")]
[DxfSubClass("AcDbViewport")]
public class Viewport : Entity
{
	public const string ASDK_XREC_ANNOTATION_SCALE_INFO = "ASDK_XREC_ANNOTATION_SCALE_INFO";

	public const int PaperViewId = 1;

	private Scale _scale;

	[DxfCodeValue(new int[] { 63, 421, 431 })]
	public Color AmbientLightColor { get; set; }

	[DxfCodeValue(new int[] { 44 })]
	public double BackClipPlane { get; set; }

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 340 })]
	public Entity Boundary { get; set; }

	[DxfCodeValue(new int[] { 141 })]
	public double Brightness { get; set; }

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ Center { get; set; }

	[DxfCodeValue(new int[] { 72 })]
	public short CircleZoomPercent { get; set; }

	[DxfCodeValue(new int[] { 142 })]
	public double Contrast { get; set; }

	[DxfCodeValue(new int[] { 282 })]
	public LightingType DefaultLightingType { get; set; }

	[DxfCodeValue(new int[] { 74 })]
	public bool DisplayUcsIcon { get; set; }

	[DxfCodeValue(new int[] { 146 })]
	public double Elevation { get; set; }

	[DxfCodeValue(new int[] { 43 })]
	public double FrontClipPlane { get; set; }

	[DxfCodeValue(DxfReferenceType.Ignored, new int[] { 331 })]
	public List<Layer> FrozenLayers { get; private set; } = new List<Layer>();

	[DxfCodeValue(new int[] { 15, 25 })]
	public XY GridSpacing { get; set; }

	[DxfCodeValue(new int[] { 41 })]
	public double Height { get; set; }

	[DxfCodeValue(new int[] { 69 })]
	public short Id
	{
		get
		{
			if (base.Owner is BlockRecord blockRecord)
			{
				short num = 0;
				foreach (Viewport viewport in blockRecord.Viewports)
				{
					num++;
					if (viewport == this)
					{
						return num;
					}
				}
			}
			return 0;
		}
	}

	[DxfCodeValue(new int[] { 42 })]
	public double LensLength { get; set; }

	[DxfCodeValue(new int[] { 61 })]
	public short MajorGridLineFrequency { get; set; }

	public override string ObjectName => "VIEWPORT";

	public override ObjectType ObjectType => ObjectType.VIEWPORT;

	[DxfCodeValue(new int[] { 281 })]
	public RenderMode RenderMode { get; set; }

	public bool RepresentsPaper => Id == 1;

	public Scale Scale
	{
		get
		{
			if (base.Document != null)
			{
				if (base.XDictionary != null && base.XDictionary.TryGetEntry<XRecord>("ASDK_XREC_ANNOTATION_SCALE_INFO", out var value))
				{
					foreach (XRecord.Entry entry in value.Entries)
					{
						if (entry.Code == 340)
						{
							return entry.Value as Scale;
						}
					}
				}
				return null;
			}
			return _scale;
		}
		set
		{
			if (base.Document != null)
			{
				_scale = CadObject.updateCollection(value, base.Document.Scales);
			}
			else
			{
				_scale = value;
			}
			updateScaleXRecord();
		}
	}

	public double ScaleFactor => 1.0 / (ViewHeight / Height);

	[DxfCodeValue(new int[] { 170 })]
	public ShadePlotMode ShadePlotMode { get; set; }

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 50 })]
	public double SnapAngle { get; set; }

	[DxfCodeValue(new int[] { 13, 23 })]
	public XY SnapBase { get; set; }

	[DxfCodeValue(new int[] { 14, 24 })]
	public XY SnapSpacing { get; set; }

	[DxfCodeValue(new int[] { 90 })]
	public ViewportStatusFlags Status { get; set; }

	[DxfCodeValue(new int[] { 1 })]
	public string StyleSheetName { get; set; }

	public override string SubclassMarker => "AcDbViewport";

	[DxfCodeValue(DxfReferenceType.IsAngle, new int[] { 51 })]
	public double TwistAngle { get; set; }

	[DxfCodeValue(new int[] { 110, 120, 130 })]
	public XYZ UcsOrigin { get; set; }

	[DxfCodeValue(new int[] { 79 })]
	public OrthographicType UcsOrthographicType { get; set; }

	[DxfCodeValue(new int[] { 71 })]
	public bool UcsPerViewport { get; set; }

	[DxfCodeValue(new int[] { 111, 121, 131 })]
	public XYZ UcsXAxis { get; set; }

	[DxfCodeValue(new int[] { 112, 122, 132 })]
	public XYZ UcsYAxis { get; set; }

	[DxfCodeValue(new int[] { 292 })]
	public bool UseDefaultLighting { get; set; }

	[DxfCodeValue(new int[] { 12, 22 })]
	public XY ViewCenter { get; set; }

	[DxfCodeValue(new int[] { 16, 26, 36 })]
	public XYZ ViewDirection { get; set; }

	[DxfCodeValue(new int[] { 45 })]
	public double ViewHeight { get; set; }

	[DxfCodeValue(new int[] { 17, 27, 37 })]
	public XYZ ViewTarget { get; set; }

	public double ViewWidth => ViewHeight / Height * Width;

	[DxfCodeValue(DxfReferenceType.Handle, new int[] { 348 })]
	public VisualStyle VisualStyle { get; set; }

	[DxfCodeValue(new int[] { 40 })]
	public double Width { get; set; }

	public override void ApplyTransform(Transform transform)
	{
		if (Boundary != null)
		{
			Boundary.ApplyTransform(transform);
			return;
		}
		Center = transform.ApplyTransform(Center);
		XYZ xyz = new XYZ(Center.X + Width / 2.0, Center.Y + Height / 2.0, Center.Z);
		xyz = transform.ApplyTransform(xyz);
		Width = xyz.X - Center.X;
		Height = xyz.Y - Center.Y;
	}

	public override CadObject Clone()
	{
		Viewport viewport = (Viewport)base.Clone();
		viewport.Boundary = (Entity)(Boundary?.Clone());
		viewport.VisualStyle = (VisualStyle)(VisualStyle?.Clone());
		viewport._scale = (Scale)(Scale?.Clone());
		viewport.FrozenLayers = new List<Layer>();
		foreach (Layer frozenLayer in FrozenLayers)
		{
			viewport.FrozenLayers.Add(frozenLayer.CloneTyped());
		}
		return viewport;
	}

	public override BoundingBox GetBoundingBox()
	{
		XYZ min = new XYZ(Center.X - Width / 2.0, Center.Y - Height / 2.0, Center.Z);
		XYZ max = new XYZ(Center.X + Width / 2.0, Center.Y + Height / 2.0, Center.Z);
		return new BoundingBox(min, max);
	}

	public BoundingBox GetModelBoundingBox()
	{
		XYZ min = new XYZ(ViewCenter.X - ViewWidth / 2.0, ViewCenter.Y - ViewHeight / 2.0, 0.0);
		XYZ max = new XYZ(ViewCenter.X + ViewWidth / 2.0, ViewCenter.Y + ViewHeight / 2.0, 0.0);
		return new BoundingBox(min, max);
	}

	public List<Entity> SelectEntities(bool includePartial = true)
	{
		if (base.Document == null)
		{
			throw new InvalidOperationException("Viewport needs to be assigned to a document.");
		}
		List<Entity> list = new List<Entity>();
		BoundingBox modelBoundingBox = GetModelBoundingBox();
		foreach (Entity entity in base.Document.Entities)
		{
			if (modelBoundingBox.IsIn(entity.GetBoundingBox(), out var partialIn) || (partialIn && includePartial))
			{
				list.Add(entity);
			}
		}
		return list;
	}

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
		_scale = CadObject.updateCollection(_scale, doc.Scales);
		base.Document.Scales.OnRemove += scalesOnRemove;
	}

	internal override void UnassignDocument()
	{
		base.Document.Scales.OnRemove -= scalesOnRemove;
		base.UnassignDocument();
		_scale = (Scale)(Scale?.Clone());
	}

	private void scalesOnRemove(object sender, CollectionChangedEventArgs e)
	{
		if (e.Item.Equals(Scale))
		{
			Scale = base.Document.Scales.FirstOrDefault();
		}
	}

	private void updateScaleXRecord()
	{
		if (base.Document == null)
		{
			return;
		}
		if (base.XDictionary.TryGetEntry<XRecord>("ASDK_XREC_ANNOTATION_SCALE_INFO", out var value))
		{
			foreach (XRecord.Entry entry in value.Entries)
			{
				if (entry.Code == 340)
				{
					entry.Value = _scale;
				}
			}
			return;
		}
		value = new XRecord("ASDK_XREC_ANNOTATION_SCALE_INFO");
		base.XDictionary.Add(value);
		value.CreateEntry(340, _scale);
	}
}
