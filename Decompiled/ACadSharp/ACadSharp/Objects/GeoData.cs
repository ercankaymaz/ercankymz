using System;
using System.Collections.Generic;
using System.Globalization;
using ACadSharp.Attributes;
using ACadSharp.Tables;
using ACadSharp.Types.Units;
using CSMath;

namespace ACadSharp.Objects;

[DxfName("GEODATA")]
[DxfSubClass("AcDbGeoData")]
public class GeoData : NonGraphicalObject
{
	public class GeoMeshFace
	{
		[DxfCodeValue(new int[] { 97 })]
		public int Index1 { get; set; }

		[DxfCodeValue(new int[] { 98 })]
		public int Index2 { get; set; }

		[DxfCodeValue(new int[] { 99 })]
		public int Index3 { get; set; }
	}

	public class GeoMeshPoint
	{
		[DxfCodeValue(new int[] { 13, 23 })]
		public XY Source { get; set; }

		[DxfCodeValue(new int[] { 14, 24 })]
		public XY Destination { get; set; }

		public override string ToString()
		{
			return "src:" + Source.ToString(CultureInfo.InvariantCulture) + " dest:" + Destination.ToString(CultureInfo.InvariantCulture);
		}
	}

	private BlockRecord _hostBlock;

	public override ObjectType ObjectType => ObjectType.UNLISTED;

	public override string ObjectName => "GEODATA";

	public override string SubclassMarker => "AcDbGeoData";

	[DxfCodeValue(new int[] { 90 })]
	public GeoDataVersion Version { get; set; } = GeoDataVersion.R2013;

	[DxfCodeValue(new int[] { 70 })]
	public DesignCoordinatesType CoordinatesType { get; set; } = DesignCoordinatesType.LocalGrid;

	public BlockRecord HostBlock
	{
		get
		{
			return _hostBlock;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			if (base.Document != null)
			{
				_hostBlock = CadObject.updateCollection(value, base.Document.BlockRecords);
			}
			else
			{
				_hostBlock = value;
			}
		}
	}

	[DxfCodeValue(new int[] { 10, 20, 30 })]
	public XYZ DesignPoint { get; set; }

	[DxfCodeValue(new int[] { 11, 21, 31 })]
	public XYZ ReferencePoint { get; set; }

	[DxfCodeValue(new int[] { 12, 22 })]
	public XY NorthDirection { get; set; } = XY.AxisY;

	[DxfCodeValue(new int[] { 41 })]
	public double HorizontalUnitScale { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 40 })]
	public double VerticalUnitScale { get; set; } = 1.0;

	[DxfCodeValue(new int[] { 91 })]
	public UnitsType HorizontalUnits { get; set; } = UnitsType.Meters;

	[DxfCodeValue(new int[] { 92 })]
	public UnitsType VerticalUnits { get; set; } = UnitsType.Meters;

	[DxfCodeValue(new int[] { 210, 220, 230 })]
	public XYZ UpDirection { get; set; } = XYZ.AxisZ;

	[DxfCodeValue(new int[] { 95 })]
	public ScaleEstimationType ScaleEstimationMethod { get; set; } = ScaleEstimationType.None;

	[DxfCodeValue(new int[] { 294 })]
	public bool EnableSeaLevelCorrection { get; set; }

	[DxfCodeValue(new int[] { 141 })]
	public double UserSpecifiedScaleFactor { get; set; }

	[DxfCodeValue(new int[] { 142 })]
	public double SeaLevelElevation { get; set; }

	[DxfCodeValue(new int[] { 143 })]
	public double CoordinateProjectionRadius { get; set; }

	[DxfCodeValue(new int[] { 301 })]
	public string CoordinateSystemDefinition { get; set; } = string.Empty;

	[DxfCodeValue(new int[] { 302 })]
	public string GeoRssTag { get; set; } = string.Empty;

	[DxfCodeValue(new int[] { 305 })]
	public string ObservationFromTag { get; set; } = string.Empty;

	[DxfCodeValue(new int[] { 306 })]
	public string ObservationToTag { get; set; } = string.Empty;

	[DxfCodeValue(new int[] { 307 })]
	public string ObservationCoverageTag { get; set; } = string.Empty;

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 93 })]
	public List<GeoMeshPoint> Points { get; } = new List<GeoMeshPoint>();

	[DxfCodeValue(DxfReferenceType.Count, new int[] { 96 })]
	public List<GeoMeshFace> Faces { get; } = new List<GeoMeshFace>();

	internal override void AssignDocument(CadDocument doc)
	{
		base.AssignDocument(doc);
	}

	internal override void UnassignDocument()
	{
		base.UnassignDocument();
	}
}
