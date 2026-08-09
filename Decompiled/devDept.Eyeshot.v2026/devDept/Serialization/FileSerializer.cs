using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Runtime.CompilerServices;
using ProtoBuf;
using ProtoBuf.Meta;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Eyeshot.Fem;
using devDept.Eyeshot.Milling;
using devDept.Eyeshot.Translators;
using devDept.Geometry;
using devDept.Geometry.ConstraintSolver;
using devDept.Graphics;
using devDept.Serialization.ODA;

namespace devDept.Serialization;

public class FileSerializer : Serializer
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly Dictionary<int, FileSerializer> _0023_003DzRmmwuVHciwk_0024 = new Dictionary<int, FileSerializer>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private contentType _0023_003DzZafoINA_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FileBody _0023_003DztsQZkUHVnsf6cgurXQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private FileHeader _0023_003Dz7Qy7DSdFKkvzGd2oiw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal bool _0023_003DzGCOeuIuJS_gt;

	public contentType Content
	{
		get
		{
			return _0023_003DzZafoINA_003D;
		}
		set
		{
			if (_0023_003DzZafoINA_003D != value)
			{
				ResetModel();
			}
			_0023_003DzZafoINA_003D = value;
		}
	}

	public FileBody FileBody
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DztsQZkUHVnsf6cgurXQ_003D_003D;
		}
	}

	public FileHeader FileHeader
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz7Qy7DSdFKkvzGd2oiw_003D_003D;
		}
	}

	public FileSerializer()
	{
		_0023_003DzZafoINA_003D = contentType.GeometryAndTessellation;
	}

	public FileSerializer(contentType contentType)
	{
		if (contentType == contentType.None)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671352));
		}
		_0023_003DzZafoINA_003D = contentType;
	}

	internal void _0023_003Dz29IIb3Mk_i5NEhByLA_003D_003D()
	{
		_0023_003DzRmmwuVHciwk_0024.Clear();
	}

	internal static FileSerializer _0023_003Dzh8CFbARXgKhypdBv6g_003D_003D(FileSerializer _0023_003Dzb7SPTpc_003D, int _0023_003Dzhv_0024RATI_003D)
	{
		FileSerializer fileSerializer = (FileSerializer)Activator.CreateInstance(_0023_003Dzb7SPTpc_003D.GetType());
		if (fileSerializer == null)
		{
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671325), _0023_003Dzb7SPTpc_003D.GetType()));
		}
		if (_0023_003Dzb7SPTpc_003D.Content == contentType.None)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671352));
		}
		fileSerializer._0023_003DzZafoINA_003D = _0023_003Dzb7SPTpc_003D.Content;
		FileSerializer value;
		if (_0023_003Dzhv_0024RATI_003D.Equals(_0023_003Dzb7SPTpc_003D.HeaderVersion))
		{
			fileSerializer.SetProtobufModel(_0023_003Dzb7SPTpc_003D.Model);
		}
		else if (_0023_003Dzb7SPTpc_003D._0023_003DzRmmwuVHciwk_0024.TryGetValue(_0023_003Dzhv_0024RATI_003D, out value))
		{
			fileSerializer.SetProtobufModel(value.Model);
		}
		else
		{
			fileSerializer._0023_003DzPiptok69u2x3(_0023_003Dzb7SPTpc_003D.Content, _0023_003Dzb7SPTpc_003D.HeaderTag, _0023_003Dzhv_0024RATI_003D);
			_0023_003Dzb7SPTpc_003D._0023_003DzRmmwuVHciwk_0024.Add(_0023_003Dzhv_0024RATI_003D, fileSerializer);
		}
		return fileSerializer;
	}

	private void _0023_003DzaC8OGtIKpswL(FileBody _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DztsQZkUHVnsf6cgurXQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	private void _0023_003Dzxyb5j_7Y47ro(FileHeader _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz7Qy7DSdFKkvzGd2oiw_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	internal void _0023_003DzPiptok69u2x3(contentType _0023_003DzB5M5dYA_003D, string _0023_003Dzo4ntpKk_003D, int _0023_003DzQ3hPewo_003D)
	{
		_0023_003DzZafoINA_003D = _0023_003DzB5M5dYA_003D;
		base.HeaderTag = _0023_003Dzo4ntpKk_003D;
		base.HeaderVersion = _0023_003DzQ3hPewo_003D;
		if (!ModelIsCompiled())
		{
			InitializeModel();
			CompileModel();
		}
	}

	internal static FileSerializer _0023_003DzXUqKaIQ_003D(Type _0023_003DzflYIIMycQjkG)
	{
		if (!(_0023_003DzflYIIMycQjkG != null))
		{
			return new FileSerializer();
		}
		return (FileSerializer)Activator.CreateInstance(_0023_003DzflYIIMycQjkG);
	}

	private void _0023_003DzGkunnSI_003D(FileHeader _0023_003Dz8Vwa6Pc_003D, FileBody _0023_003Dzk347ngQ_003D)
	{
		if (_0023_003Dz8Vwa6Pc_003D == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671250));
		}
		if (_0023_003Dzk347ngQ_003D == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670968));
		}
		_0023_003DzNHShqHtUfjy7(_0023_003Dz8Vwa6Pc_003D);
		_0023_003DzaC8OGtIKpswL(_0023_003Dzk347ngQ_003D);
	}

	private void _0023_003DzNHShqHtUfjy7(FileHeader _0023_003Dz7yVgmfHOaIMi)
	{
		_0023_003Dzxyb5j_7Y47ro(_0023_003Dz7yVgmfHOaIMi);
		Content = FileHeader.Content;
	}

	protected override void FillHeaderModel()
	{
		if (Content == contentType.None)
		{
			throw new InvalidOperationException("Content cannot be none.");
		}
		if (!ModelIsCompiled())
		{
			base.FillHeaderModel();
			base.Model.Add(typeof(ProtoImage), applyDefaultBehaviour: false).SetSurrogate(typeof(ProtoImageSurrogate));
			base.Model[typeof(ProtoImageSurrogate)].Add(1, "Data").SetCallbacks(null, null, "BeforeDeserialize", null).UseConstructor = false;
			base.Model.Add(typeof(ProtoBitmap), applyDefaultBehaviour: false).SetSurrogate(typeof(ProtoBitmapSurrogate));
			base.Model[typeof(ProtoBitmapSurrogate)].Add(1, "Data").SetCallbacks(null, null, "BeforeDeserialize", null).UseConstructor = false;
			base.Model[typeof(FileHeader)].SetSurrogate(typeof(FileHeaderSurrogate));
			base.Model[typeof(FileHeaderSurrogate)].Add(1, "Version").Add(2, "SerializationMode").Add(3, "Units")
				.Add(4, "Author")
				.Add(5, "Organization")
				.Add(6, "OriginatingSystem")
				.Add(7, "ContentType")
				.Add(8, "EyeshotBuild")
				.Add(9, "Timestamp")
				.Add(10, "Tag")
				.Add(11, "Thumbnail")
				.Add(12, "FileName")
				.Add(13, "FileMode")
				.UseConstructor = false;
		}
	}

	protected override void FillModel()
	{
		if (Content == contentType.None)
		{
			throw new EyeshotException("Content cannot be none.");
		}
		if (ModelIsCompiled())
		{
			return;
		}
		base.FillModel();
		base.Model[typeof(FileBody)].SetSurrogate(typeof(FileBodySurrogate));
		MetaType metaType = base.Model[typeof(FileBodySurrogate)];
		metaType.UseConstructor = false;
		metaType.SetCallbacks(null, null, "BeforeDeserialize", "AfterDeserialize");
		metaType.Add(1, "Entities");
		metaType.Add(2, "Blocks");
		metaType.Add(3, "Materials");
		metaType.Add(4, "Layers");
		if (Content != contentType.Tessellation)
		{
			metaType.Add(5, "LineTypes");
			metaType.Add(6, "TextStyles");
		}
		metaType.Add(7, "Camera");
		metaType.Add(8, "RootBlockName");
		metaType.Add(9, "RootBlockEntities");
		metaType.Add(10, "Paths");
		metaType.Add(11, "Types");
		metaType.Add(12, "LineTypeScale");
		metaType.Add(101, "DrawingSilhouettesLayerName");
		metaType.Add(102, "DrawingEdgesLayerName");
		metaType.Add(103, "DrawingWiresLayerName");
		metaType.Add(104, "DrawingHiddenSilhouettesLayerName");
		metaType.Add(105, "DrawingHiddenEdgesLayerName");
		metaType.Add(106, "DrawingHiddenWiresLayerName");
		metaType.Add(107, "DrawingHiddenSegmentsLineTypeName");
		metaType.Add(108, "DrawingSheets");
		metaType.Add(109, "DrawingBlocks");
		metaType.Add(110, "DrawingLayers");
		if (Content != contentType.Tessellation)
		{
			metaType.Add(111, "DrawingLineTypes");
			metaType.Add(112, "DrawingTextStyles");
		}
		metaType.Add(113, "DrawingRootBlockName");
		metaType.Add(114, "DrawingRootBlockEntities");
		metaType.Add(115, "DrawingGhostCirclesLayerName");
		metaType.Add(116, "DrawingCenterlinesLayerName");
		metaType.Add(117, "DrawingCenterlinesLineTypeName");
		if (Content != contentType.Tessellation)
		{
			metaType.Add(118, "HatchPatterns");
			metaType.Add(119, "DrawingHatchPatterns");
		}
		if (base.HeaderVersion >= 19)
		{
			metaType.Add(120, "DrawingSectionsLayerName");
		}
		base.Model.Add(typeof(Camera), applyDefaultBehaviour: false).SetSurrogate(typeof(CameraSurrogate));
		base.Model[typeof(CameraSurrogate)].Add(1, "Target").Add(2, "Distance").Add(3, "Rotation")
			.Add(4, "ProjectionMode")
			.Add(5, "FocalLength")
			.Add(6, "ZoomFactor")
			.SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model.Add(typeof(Material), applyDefaultBehaviour: false).SetSurrogate(typeof(MaterialSurrogate));
		metaType = base.Model[typeof(MaterialSurrogate)];
		metaType.Add(1, "Name");
		metaType.Add(2, "Description");
		metaType.Add(3, "AlphaMapImage");
		metaType.Add(4, "Ambient");
		metaType.Add(5, "Diffuse");
		metaType.Add(6, "Specular");
		metaType.Add(7, "Shininess");
		metaType.Add(8, "Environment");
		metaType.Add(9, "TextureImage");
		metaType.Add(10, "EnvironmentMappingImage");
		metaType.Add(11, "CoeffOfThermalExp");
		metaType.Add(12, "Density");
		metaType.Add(13, "ElementThickness");
		metaType.Add(14, "ElementType");
		metaType.Add(15, "MagnifyingFunction");
		metaType.Add(16, "MinifyingFunction");
		metaType.Add(17, "Poisson");
		metaType.Add(18, "RepeatX");
		metaType.Add(19, "RepeatY");
		metaType.Add(20, "YieldStrength");
		metaType.Add(21, "Young");
		metaType.Add(22, "LinearUnits");
		metaType.Add(23, "MassUnits");
		metaType.Add(24, "TextureLength");
		metaType.SetCallbacks(null, null, "BeforeDeserialize", null);
		metaType.UseConstructor = false;
		base.Model.Add(typeof(Layer), applyDefaultBehaviour: false).AddSubType(202, typeof(IfcLayer)).SetSurrogate(typeof(LayerSurrogate));
		metaType = base.Model[typeof(LayerSurrogate)];
		metaType.AddSubType(202, typeof(IfcLayerSurrogate));
		metaType.Add(1, "Name");
		metaType.Add(2, "Color");
		metaType.Add(3, "MaterialName");
		if (Content != contentType.Tessellation)
		{
			metaType.Add(4, "LineTypeName");
		}
		metaType.Add(5, "LineWeight");
		metaType.Add(6, "Visible");
		metaType.Add(7, "Locked");
		metaType.Add(8, "Exportable");
		metaType.Add(9, "XRefName");
		metaType.Add(10, "XData");
		metaType.Add(11, "Description");
		metaType.Add(12, "Identifier");
		metaType.SetCallbacks(null, null, "BeforeDeserialize", null);
		metaType.UseConstructor = false;
		base.Model[typeof(IfcLayerSurrogate)].Add(1, "Description_V15").Add(2, "Identifier_V15").UseConstructor = false;
		if (Content != contentType.Tessellation)
		{
			base.Model.Add(typeof(LineType), applyDefaultBehaviour: false).SetSurrogate(typeof(LineTypeSurrogate));
			base.Model[typeof(LineTypeSurrogate)].Add(1, "Name").Add(2, "Pattern").Add(3, "Description")
				.Add(4, "Length")
				.Add(5, "XRefName")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			base.Model.Add(typeof(HatchPattern), applyDefaultBehaviour: false).SetSurrogate(typeof(HatchPatternSurrogate));
			base.Model[typeof(HatchPatternSurrogate)].Add(1, "Name").Add(2, "Lines").Add(3, "Description")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			base.Model.Add(typeof(HatchPatternLine), applyDefaultBehaviour: false).SetSurrogate(typeof(HatchPatternLineSurrogate));
			base.Model[typeof(HatchPatternLineSurrogate)].Add(1, "Angle").Add(2, "Origin").Add(3, "DeltaX")
				.Add(4, "DeltaY")
				.Add(5, "Pattern")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			base.Model.Add(typeof(TextStyle), applyDefaultBehaviour: false).SetSurrogate(typeof(TextStyleSurrogate));
			base.Model[typeof(TextStyleSurrogate)].Add(1, "Name").Add(2, "FontFamilyName").Add(3, "Style")
				.Add(4, "WidthFactor")
				.Add(5, "FileName")
				.Add(6, "shapeFile")
				.Add(7, "XRefName")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			base.Model.Add(typeof(ShapeFile), applyDefaultBehaviour: false).SetSurrogate(typeof(ShapeFileSurrogate));
			base.Model[typeof(ShapeFileSurrogate)].Add(1, "FileName").Add(2, "Shapes").Add(3, "ShapeFileType")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			base.Model.Add(typeof(ShapeSymbol), applyDefaultBehaviour: false).SetSurrogate(typeof(ShapeSymbolSurrogate));
			base.Model[typeof(ShapeSymbolSurrogate)].Add(1, "Symbol").Add(2, "LengthInStream").Add(3, "Name")
				.Add(4, "Items")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			base.Model.Add(typeof(ShapeSymbolComponent), applyDefaultBehaviour: false).SetSurrogate(typeof(ShapeSymbolComponentSurrogate));
			base.Model[typeof(ShapeSymbolComponentSurrogate)].AddSubType(201, typeof(ShapeSymbolRegularLineSurrogate)).AddSubType(202, typeof(ShapeSymbolComponentWithParamsSurrogate)).Add(1, "Command")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			base.Model[typeof(ShapeSymbolComponent)].AddSubType(201, typeof(ShapeSymbolRegularLine)).AddSubType(202, typeof(ShapeSymbolComponentWithParams));
			base.Model[typeof(ShapeSymbolRegularLineSurrogate)].Add(1, "Direction").Add(2, "Length").UseConstructor = false;
			base.Model[typeof(ShapeSymbolComponentWithParamsSurrogate)].Add(1, "Params").UseConstructor = false;
		}
		base.Model.Add(typeof(Block), applyDefaultBehaviour: false).SetSurrogate(typeof(BlockSurrogate));
		metaType = base.Model[typeof(BlockSurrogate)];
		metaType.Add(1, "Name");
		metaType.Add(2, "BasePoint");
		metaType.Add(3, "Units");
		metaType.Add(4, "Entities");
		metaType.Add(5, "Description");
		metaType.Add(6, "IsResolved");
		metaType.Add(7, "MassUnits");
		metaType.Add(8, "FilePath");
		metaType.Add(9, "CustomData");
		metaType.Add(10, "XRefName");
		if (base.HeaderVersion < 16)
		{
			metaType.Add(11, "xRefPath");
		}
		metaType.Add(12, "BlockSource");
		metaType.Add(13, "ExportMode");
		if (!_0023_003DzGCOeuIuJS_gt && Content != contentType.Tessellation)
		{
			metaType.Add(14, "MatesList");
		}
		metaType.SetCallbacks(null, null, "BeforeDeserialize", null);
		metaType.UseConstructor = false;
		base.Model.Add(typeof(TextureMappingData), applyDefaultBehaviour: false).SetSurrogate(typeof(TextureMappingDataSurrogate));
		base.Model[typeof(TextureMappingDataSurrogate)].Add(1, "MappingMode").Add(2, "ScaleX").Add(3, "ScaleY")
			.Add(4, "Min")
			.Add(5, "Max")
			.Add(6, "Transformation")
			.SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model.Add(typeof(Solid.EdgeData), applyDefaultBehaviour: false).SetSurrogate(typeof(EdgeDataSurrogate));
		base.Model[typeof(EdgeDataSurrogate)].Add(1, "BeginVertex").Add(2, "EndVertex").Add(3, "Type")
			.Add(4, "NextFace")
			.Add(5, "NextEdge")
			.Add(6, "PreviousFace")
			.Add(7, "PreviousEdge")
			.Add(8, "Angle")
			.SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model.Add(typeof(Solid.Face), applyDefaultBehaviour: false).SetSurrogate(typeof(FaceSurrogate));
		base.Model[typeof(FaceSurrogate)].Add(1, "FirstContour").Add(2, "FaceLabel").SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model.Add(typeof(Solid.Cycle), applyDefaultBehaviour: false).SetSurrogate(typeof(CycleSurrogate));
		base.Model[typeof(CycleSurrogate)].Add(1, "FirstEdge").Add(2, "NextContour").SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model.Add(typeof(IfcContainer), applyDefaultBehaviour: false).SetSurrogate(typeof(IfcContainerSurrogate));
		base.Model[typeof(IfcContainerSurrogate)].Add(1, "GUID").Add(2, "Identification").Add(3, "Properties")
			.Add(4, "Parent")
			.Add(5, "LocalTransformation")
			.Add(6, "GlobalTransformation")
			.Add(7, "Childs")
			.Add(8, "ContainedElements")
			.Add(9, "Systems")
			.SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model.Add(typeof(Sheet), applyDefaultBehaviour: false).SetSurrogate(typeof(SheetSurrogate));
		metaType = base.Model[typeof(SheetSurrogate)];
		metaType.Add(1, "Units");
		metaType.Add(2, "Width");
		metaType.Add(3, "Height");
		metaType.Add(4, "Name");
		metaType.Add(6, "Camera");
		metaType.Add(7, "Entities");
		metaType.Add(8, "AngleProjectionMode");
		metaType.SetCallbacks(null, null, "BeforeDeserialize", null);
		metaType.UseConstructor = false;
		metaType = base.Model.Add(typeof(Entity), applyDefaultBehaviour: false);
		metaType.AddSubType(201, typeof(PlanarEntity));
		metaType.AddSubType(202, typeof(Point));
		metaType.AddSubType(203, typeof(Line));
		metaType.AddSubType(204, typeof(Triangle));
		metaType.AddSubType(205, typeof(Quad));
		metaType.AddSubType(206, typeof(LinearPath));
		metaType.AddSubType(207, typeof(CompositeCurve));
		metaType.AddSubType(208, typeof(Joint));
		metaType.AddSubType(209, typeof(Bar));
		metaType.AddSubType(210, typeof(PointCloud));
		metaType.AddSubType(211, typeof(FastPointCloud));
		metaType.AddSubType(212, typeof(Mesh));
		metaType.AddSubType(213, typeof(BlockReference));
		metaType.AddSubType(214, typeof(Solid));
		metaType.AddSubType(215, typeof(NurbsBase));
		metaType.AddSubType(216, typeof(Brep));
		metaType.AddSubType(217, typeof(FemMesh));
		metaType.AddSubType(218, typeof(Ghost));
		metaType.AddSubType(219, typeof(Toolpath));
		metaType.AddSubType(220, typeof(FastMesh));
		metaType.AddSubType(221, typeof(LinearEntity));
		metaType.SetSurrogate(typeof(EntitySurrogate));
		metaType = base.Model[typeof(EntitySurrogate)];
		metaType.UseConstructor = false;
		metaType.Add(1, "LayerName");
		metaType.Add(2, "ColorMethod");
		metaType.Add(3, "Color");
		metaType.Add(4, "MaterialName");
		metaType.Add(5, "LineWeightMethod");
		metaType.Add(6, "LineWeight");
		metaType.Add(7, "LineTypeMethod");
		if (Content != contentType.Tessellation)
		{
			metaType.Add(8, "LineTypeName");
			metaType.Add(9, "LineTypeScale");
		}
		metaType.Add(10, "EntityData");
		metaType.Add(11, "Visible");
		metaType.Add(12, "Selectable");
		metaType.Add(13, "Type");
		metaType.Add(14, "BoxMin");
		metaType.Add(15, "BoxMax");
		metaType.Add(16, "PrintOrder");
		if (Content != contentType.Tessellation)
		{
			metaType.Add(17, "IfcProperties");
		}
		AddReferenceIdField(metaType);
		metaType.Add(18, "Clippable");
		metaType.SetCallbacks("BeforeSerialize", null, "BeforeDeserialize", "AfterDeserialize").UseConstructor = false;
		metaType.AddSubType(201, typeof(PlanarEntitySurrogate));
		metaType.AddSubType(202, typeof(CircleSurrogate));
		metaType.AddSubType(203, typeof(EllipseSurrogate));
		metaType.AddSubType(204, typeof(TextSurrogate));
		metaType.AddSubType(205, typeof(PictureSurrogate));
		metaType.AddSubType(206, typeof(LeaderSurrogate));
		metaType.AddSubType(207, typeof(RegionSurrogate));
		metaType.AddSubType(208, typeof(PointSurrogate));
		metaType.AddSubType(209, typeof(LineSurrogate));
		metaType.AddSubType(210, typeof(TriangleSurrogate));
		metaType.AddSubType(211, typeof(QuadSurrogate));
		metaType.AddSubType(212, typeof(LinearPathSurrogate));
		metaType.AddSubType(213, typeof(CompositeCurveSurrogate));
		metaType.AddSubType(214, typeof(JointSurrogate));
		metaType.AddSubType(215, typeof(BarSurrogate));
		metaType.AddSubType(216, typeof(PointCloudSurrogate));
		metaType.AddSubType(217, typeof(FastPointCloudSurrogate));
		metaType.AddSubType(218, typeof(MeshSurrogate));
		metaType.AddSubType(219, typeof(BlockReferenceSurrogate));
		metaType.AddSubType(220, typeof(SolidSurrogate));
		metaType.AddSubType(221, typeof(PortionSurrogate));
		metaType.AddSubType(222, typeof(NurbsBaseSurrogate));
		metaType.AddSubType(223, typeof(BrepSurrogate));
		metaType.AddSubType(224, typeof(BrepTessellationMeshSurrogate));
		metaType.AddSubType(225, typeof(FemMeshSurrogate));
		metaType.AddSubType(226, typeof(GhostSurrogate));
		metaType.AddSubType(227, typeof(ToolpathSurrogate));
		metaType.AddSubType(228, typeof(HatchSurrogate));
		metaType.AddSubType(229, typeof(FastMeshSurrogate));
		metaType.AddSubType(230, typeof(SketchEntitySurrogate));
		metaType.AddSubType(231, typeof(LinearEntitySurrogate));
		metaType = base.Model[typeof(PlanarEntity)];
		metaType.AddSubType(201, typeof(Circle));
		metaType.AddSubType(202, typeof(Ellipse));
		metaType.AddSubType(203, typeof(Text));
		metaType.AddSubType(204, typeof(Picture));
		metaType.AddSubType(205, typeof(Leader));
		metaType.AddSubType(206, typeof(Region));
		metaType.AddSubType(207, typeof(Table));
		metaType.AddSubType(208, typeof(Hatch));
		metaType.AddSubType(209, typeof(SketchEntity));
		metaType = base.Model[typeof(PlanarEntitySurrogate)];
		metaType.UseConstructor = false;
		metaType.AddSubType(201, typeof(TableSurrogate));
		metaType.Add(1, "SymbolSize");
		_0023_003DzM6fU__0024hmcD5K(metaType);
		AddPlaneField(metaType);
		if (Content != contentType.Geometry)
		{
			AddVerticesField(metaType);
		}
		metaType = base.Model[typeof(TableSurrogate)];
		metaType.UseConstructor = false;
		metaType.Add(1, "RowsNum");
		metaType.Add(2, "ColumnsNum");
		metaType.Add(3, "RowsHeights");
		metaType.Add(4, "ColumnsWidths");
		metaType.Add(5, "Direction");
		metaType.Add(6, "HorzCellMargin");
		metaType.Add(7, "VertCellMargin");
		metaType.Add(8, "Cells");
		metaType = base.Model[typeof(TableSurrogate.CellSurrogate)];
		metaType.UseConstructor = false;
		metaType.Add(3, "Corners");
		metaType.Add(4, "IsFirst");
		metaType.Add(5, "IsMerged");
		metaType.Add(6, "MergeRange");
		base.Model.Add(typeof(Table.CellRange), applyDefaultBehaviour: false).SetSurrogate(typeof(TableSurrogate.CellRangeSurrogate));
		metaType = base.Model[typeof(TableSurrogate.CellRangeSurrogate)];
		metaType.Add(1, "MinRow");
		metaType.Add(2, "MaxRow");
		metaType.Add(3, "MinColumn");
		metaType.Add(4, "MaxColumn");
		metaType.SetCallbacks(null, null, "BeforeDeserialize", null);
		metaType.UseConstructor = false;
		base.Model[typeof(Circle)].AddSubType(201, typeof(Arc));
		metaType = base.Model[typeof(CircleSurrogate)].AddSubType(201, typeof(ArcSurrogate));
		metaType.UseConstructor = false;
		if (Content != contentType.Geometry)
		{
			AddVerticesField(metaType);
		}
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "Radius");
			AddPlaneField(metaType);
		}
		_0023_003DzM6fU__0024hmcD5K(metaType);
		metaType = base.Model[typeof(ArcSurrogate)];
		metaType.UseConstructor = false;
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "Domain");
		}
		base.Model[typeof(Ellipse)].AddSubType(201, typeof(EllipticalArc));
		metaType = base.Model[typeof(EllipseSurrogate)].AddSubType(201, typeof(EllipticalArcSurrogate));
		metaType.UseConstructor = false;
		if (Content != contentType.Geometry)
		{
			AddVerticesField(metaType);
		}
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "RadiusX");
			metaType.Add(2, "RadiusY");
			AddPlaneField(metaType);
		}
		_0023_003DzM6fU__0024hmcD5K(metaType);
		metaType = base.Model[typeof(EllipticalArcSurrogate)];
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "Domain");
		}
		metaType.UseConstructor = false;
		base.Model[typeof(Text)].AddSubType(201, typeof(MultilineText)).AddSubType(202, typeof(Dimension)).AddSubType(203, typeof(AttributeBase))
			.AddSubType(204, typeof(Balloon))
			.AddSubType(205, typeof(SectionLine));
		metaType = base.Model[typeof(TextSurrogate)];
		metaType.UseConstructor = false;
		metaType.AddSubType(201, typeof(MultilineTextSurrogate));
		metaType.AddSubType(202, typeof(DimensionSurrogate));
		metaType.AddSubType(203, typeof(AttributeBaseSurrogate));
		metaType.AddSubType(204, typeof(BalloonSurrogate));
		metaType.AddSubType(205, typeof(SectionLineSurrogate));
		metaType.Add(1, "TextString");
		metaType.Add(2, "Height");
		metaType.Add(3, "Alignment");
		metaType.Add(4, "StyleName");
		metaType.Add(5, "Simplify");
		metaType.Add(6, "WidthFactor");
		metaType.Add(7, "Backward");
		metaType.Add(8, "UpsideDown");
		metaType.Add(9, "Billboard");
		AddPlaneField(metaType);
		base.Model[typeof(MultilineText)].AddSubType(201, typeof(Table.Cell));
		metaType = base.Model[typeof(MultilineTextSurrogate)];
		metaType.UseConstructor = false;
		metaType.AddSubType(201, typeof(TableSurrogate.CellSurrogate));
		metaType.Add(1, "RectWidth");
		metaType.Add(2, "LineSpaceDistance");
		metaType.Add(3, "WidthFactors");
		metaType.Add(4, "Wrap");
		metaType.Add(5, "Contents");
		metaType.Add(6, "RectHeight");
		base.Model[typeof(Dimension)].AddSubType(201, typeof(LinearDim)).AddSubType(202, typeof(RadialDim)).AddSubType(203, typeof(AngularDim))
			.AddSubType(204, typeof(OrdinateDim));
		base.Model[typeof(RadialDim)].AddSubType(201, typeof(DiametricDim));
		metaType = base.Model[typeof(DimensionSurrogate)];
		metaType.AddSubType(201, typeof(LinearDimSurrogate));
		metaType.AddSubType(202, typeof(RadialDimSurrogate));
		metaType.AddSubType(203, typeof(AngularDimSurrogate));
		metaType.AddSubType(204, typeof(OrdinateDimSurrogate));
		metaType.Add(1, "ArrowheadSize");
		metaType.Add(2, "ArrowsLocation");
		metaType.Add(3, "DimLinePosition");
		metaType.Add(4, "Precision");
		metaType.Add(5, "SuppressLeadingZeros");
		metaType.Add(6, "SuppressTrailingZeros");
		metaType.Add(7, "TextGap");
		metaType.Add(8, "TextLocation");
		metaType.Add(9, "TextPrefix");
		metaType.Add(10, "TextOverride");
		metaType.Add(11, "TextSuffix");
		metaType.Add(12, "LinearScale");
		metaType.Add(13, "ScaleOverall");
		metaType.Add(14, "LinearDimensionUnits");
		metaType.Add(15, "DimStyle");
		metaType.Add(16, "Distance");
		metaType.Add(17, "ToleranceMode");
		metaType.Add(18, "UpperValue");
		metaType.Add(19, "LowerValue");
		metaType.Add(20, "ScalingForHeight");
		metaType.Add(21, "ToleranceSuppressLeadingZeros");
		metaType.Add(22, "ToleranceSuppressTralingZeros");
		metaType.Add(23, "TolerancePrecision");
		metaType.Add(25, "TextColor");
		metaType.Add(26, "TextColorMethod");
		metaType.Add(27, "ToleranceAlignment");
		metaType.Add(28, "TextHorizontalPosition");
		metaType.Add(29, "TextVerticalPosition");
		metaType.Add(30, "UseDefaultTextPosition");
		metaType.UseConstructor = false;
		base.Model[typeof(LinearDimSurrogate)].Add(1, "ExtLine1").Add(2, "ExtLine2").Add(3, "ExtLineExt")
			.Add(4, "ExtLineOffset")
			.Add(5, "LeftArrowhead")
			.Add(6, "RightArrowhead")
			.Add(7, "ShowExtLine1")
			.Add(8, "ShowExtLine2")
			.UseConstructor = false;
		metaType = base.Model[typeof(RadialDimSurrogate)];
		metaType.AddSubType(201, typeof(DiametricDimSurrogate));
		metaType.Add(1, "Radius");
		metaType.Add(2, "Arrowhead");
		metaType.Add(3, "CenterMarkSize");
		metaType.Add(5, "TrimLeader");
		metaType.UseConstructor = false;
		base.Model[typeof(DiametricDimSurrogate)].Add(1, "LeftArrowhead").Add(2, "RightArrowhead").UseConstructor = false;
		base.Model[typeof(AngularDimSurrogate)].Add(1, "ExtLine1").Add(2, "ExtLine2").Add(3, "ExtLineExt")
			.Add(4, "ExtLineOffset")
			.Add(5, "LeftArrowhead")
			.Add(6, "RightArrowhead")
			.Add(7, "AngleFormat")
			.Add(8, "ShowExtLine1")
			.Add(9, "ShowExtLine2")
			.UseConstructor = false;
		base.Model[typeof(OrdinateDimSurrogate)].Add(1, "DefiningPoint").Add(2, "IsVertical").Add(3, "ExtLineOffset")
			.UseConstructor = false;
		base.Model.Add(typeof(AttributeReference), applyDefaultBehaviour: false).SetSurrogate(typeof(AttributeReferenceSurrogate));
		metaType = base.Model[typeof(AttributeReferenceSurrogate)];
		metaType.SetCallbacks(null, null, "BeforeDeserialize", null);
		metaType.UseConstructor = false;
		metaType.Add(1, "Data");
		base.Model[typeof(AttributeBase)].AddSubType(201, typeof(devDept.Eyeshot.Entities.Attribute)).AddSubType(202, typeof(AttributeReferenceData));
		metaType = base.Model[typeof(AttributeBaseSurrogate)];
		metaType.UseConstructor = false;
		metaType.AddSubType(201, typeof(AttributeSurrogate));
		metaType.AddSubType(202, typeof(AttributeReferenceDataSurrogate));
		metaType.Add(1, "Invisible");
		metaType.Add(2, "Constant");
		metaType.Add(3, "Verify");
		metaType.Add(4, "Preset");
		metaType = base.Model[typeof(AttributeSurrogate)];
		metaType.UseConstructor = false;
		metaType.Add(1, "Value");
		metaType.Add(2, "Prompt");
		metaType = base.Model[typeof(AttributeReferenceDataSurrogate)];
		metaType.UseConstructor = false;
		metaType = base.Model[typeof(BalloonSurrogate)];
		metaType.UseConstructor = false;
		metaType.Add(1, "AnchorPoint");
		metaType.Add(2, "ArrowHead");
		metaType.Add(3, "ArrowHeadSize");
		metaType.Add(4, "ShowArrowHead");
		metaType.Add(5, "Scale");
		metaType.Add(6, "Style");
		metaType.Add(7, "Size");
		metaType = base.Model[typeof(SectionLineSurrogate)];
		metaType.UseConstructor = false;
		metaType.Add(1, "ShowArrowHead");
		metaType.Add(2, "ArrowHeadSize");
		metaType.Add(3, "EndPoint");
		metaType = base.Model[typeof(PictureSurrogate)].Add(1, "Width").Add(2, "Height").Add(3, "Image")
			.Add(4, "Lighted")
			.Add(5, "DrawEdge")
			.Add(7, "MagnifyingFunction")
			.Add(8, "MinifyingFunction")
			.Add(9, "Tiling")
			.Add(10, "AnisotropicFiltering")
			.Add(11, "ClippingBoundary")
			.Add(12, "ShowClipped")
			.Add(13, "FilePath");
		if (Content != contentType.Geometry)
		{
			metaType.Add(14, "indexTriangleMesh");
		}
		AddPlaneField(metaType);
		AddVerticesField(metaType);
		metaType.UseConstructor = false;
		metaType = base.Model[typeof(LeaderSurrogate)];
		metaType.UseConstructor = false;
		metaType.Add(1, "Arrowhead");
		metaType.Add(2, "ArrowheadSize");
		metaType.Add(3, "Scale");
		metaType.Add(4, "ShowArrowHead");
		metaType.Add(5, "Start2D");
		metaType.Add(6, "Angle");
		AddPlaneField(metaType);
		AddVerticesField(metaType);
		base.Model[typeof(Region)].AddSubType(202, typeof(Stock));
		metaType = base.Model[typeof(RegionSurrogate)];
		if (base.HeaderVersion < 8)
		{
			metaType.AddSubType(201, typeof(HatchRegionSurrogate));
		}
		metaType.AddSubType(202, typeof(StockSurrogate));
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "ContourList");
			AddPlaneField(metaType);
		}
		AddVerticesField(metaType);
		AddTrianglesField(metaType);
		AddEdgesField(metaType);
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion))
		{
			_0023_003DzM6fU__0024hmcD5K(metaType);
			metaType.Add(58, "GraphicalContours");
		}
		metaType.UseConstructor = false;
		if (base.HeaderVersion < 8)
		{
			base.Model[typeof(HatchRegionSurrogate)].Add(1, "HatchName").Add(2, "HatchScale").Add(3, "HatchAngle")
				.UseConstructor = false;
		}
		metaType = base.Model[typeof(HatchSurrogate)];
		metaType.UseConstructor = false;
		metaType.Add(1, "PatternName");
		if (Content != contentType.Tessellation)
		{
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion))
			{
				metaType.Add(11, "ContourList_2022");
			}
			else
			{
				metaType.Add(2, "ContourList");
			}
			AddPlaneField(metaType);
			metaType.Add(3, "PatternScale");
			metaType.Add(4, "PatternAngle");
			metaType.Add(5, "PatternOrigin");
			metaType.Add(8, "PatternSpacing");
			metaType.Add(9, "PatternDouble");
			metaType.Add(10, "IsUserDefinedPattern");
		}
		if (Content != contentType.Geometry)
		{
			metaType.Add(6, "PatternLines");
			metaType.Add(7, "PatternPoints");
			AddVerticesField(metaType);
			AddTrianglesField(metaType);
		}
		if (Content == contentType.GeometryAndTessellation && Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion))
		{
			metaType.Add(12, "ContourVertices");
		}
		metaType = base.Model[typeof(PointSurrogate)];
		AddVerticesField(metaType);
		_0023_003DzM6fU__0024hmcD5K(metaType);
		metaType.UseConstructor = false;
		base.Model[typeof(GhostSurrogate)].Add(1, "Description").UseConstructor = false;
		metaType = base.Model[typeof(TriangleSurrogate)];
		metaType.Add(1, "VisibleEdgeFlag");
		AddVerticesField(metaType);
		if (Content != contentType.Geometry)
		{
			AddNormalField(metaType);
		}
		_0023_003DzM6fU__0024hmcD5K(metaType);
		metaType.UseConstructor = false;
		metaType = base.Model[typeof(QuadSurrogate)].Add(1, "VisibleEdgeFlag");
		AddVerticesField(metaType);
		if (Content != contentType.Geometry)
		{
			AddNormalField(metaType);
		}
		_0023_003DzM6fU__0024hmcD5K(metaType);
		metaType.UseConstructor = false;
		metaType = base.Model[typeof(LineSurrogate)];
		AddVerticesField(metaType);
		_0023_003DzM6fU__0024hmcD5K(metaType);
		metaType.UseConstructor = false;
		metaType = base.Model[typeof(MeshSurrogate)].Add(1, "MeshNature").Add(2, "EdgeStyle").Add(3, "SmoothingAngle")
			.Add(4, "LightWeight");
		AddVerticesField(metaType);
		AddTrianglesField(metaType);
		AddTextureCoordsField(metaType);
		AddNormalsField(metaType);
		AddEdgesField(metaType);
		_0023_003DzM6fU__0024hmcD5K(metaType);
		metaType.UseConstructor = false;
		base.Model[typeof(Mesh)].AddSubType(201, typeof(Solid.Portion)).AddSubType(203, typeof(IfcMesh));
		base.Model[typeof(MeshSurrogate)].AddSubType(203, typeof(IfcMeshSurrogate));
		metaType = base.Model[typeof(PortionSurrogate)];
		metaType.UseConstructor = false;
		metaType.Add(1, "MeshNature");
		metaType.Add(2, "EdgeStyle");
		metaType.Add(3, "SmoothingAngle");
		metaType.Add(4, "LightWeight");
		AddVerticesField(metaType);
		if (Content != contentType.Geometry)
		{
			AddTrianglesField(metaType);
			AddTextureCoordsField(metaType);
			AddNormalsField(metaType);
			AddEdgesField(metaType);
		}
		metaType.Add(11, "Id");
		metaType.Add(12, "EdgeDatas");
		metaType.Add(13, "Faces");
		metaType.Add(14, "Cycles");
		metaType.Add(15, "vertexCount");
		metaType.Add(16, "edgeCount");
		metaType.Add(17, "faceCount");
		metaType.Add(18, "contourCount");
		metaType.Add(19, "MaxNov");
		metaType.Add(20, "MaxNoe");
		metaType.Add(21, "MaxNof");
		metaType.Add(22, "MaxNoc");
		metaType.Add(23, "novTemp");
		metaType.Add(24, "isoCurves");
		_0023_003DzM6fU__0024hmcD5K(metaType);
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion) && Content != contentType.Geometry)
		{
			metaType = base.Model[typeof(GPortionSurrogate)];
			AddTrianglesField(metaType);
			AddTextureCoordsField(metaType);
			AddNormalsField(metaType);
			AddEdgesField(metaType);
		}
		base.Model[typeof(IfcMeshSurrogate)].Add(1, "GUID").Add(2, "Identification").Add(3, "Properties")
			.Add(4, "Materials")
			.Add(5, "Parent")
			.Add(6, "LocalTransformation")
			.Add(7, "GlobalTransformation")
			.Add(8, "Axes")
			.Add(9, "Openings")
			.Add(10, "Systems")
			.UseConstructor = false;
		base.Model[typeof(Mesh)].AddSubType(202, typeof(Brep.TessellationMesh));
		metaType = base.Model[typeof(BrepTessellationMeshSurrogate)];
		AddVerticesField(metaType);
		AddTrianglesField(metaType);
		metaType.Add(11, "TextureScaleU");
		metaType.Add(12, "TextureScaleV");
		metaType.Add(13, "TextureOffsetU");
		metaType.Add(14, "TextureOffsetV");
		metaType.UseConstructor = false;
		metaType = base.Model[typeof(SolidSurrogate)];
		metaType.Add(1, "Portions");
		if (Content != contentType.Tessellation)
		{
			metaType.Add(2, "BRepMode");
			metaType.Add(3, "TextureMapping");
			metaType.Add(4, "SmoothingAngle");
			metaType.Add(5, "UseInnerColors");
		}
		_0023_003DzM6fU__0024hmcD5K(metaType);
		metaType.UseConstructor = false;
		metaType = base.Model[typeof(LinearPathSurrogate)];
		metaType.Add(1, "GlobalWidth");
		if (Content == contentType.GeometryAndTessellation)
		{
			metaType.Add(2, "GlobalWidthVertices");
		}
		AddVerticesField(metaType);
		_0023_003DzM6fU__0024hmcD5K(metaType);
		metaType.UseConstructor = false;
		base.Model[typeof(LinearPath)].AddSubType(202, typeof(IfcLinearPath)).AddSubType(203, typeof(WireBox));
		base.Model[typeof(LinearPathSurrogate)].AddSubType(202, typeof(IfcLinearPathSurrogate)).AddSubType(203, typeof(WireBoxSurrogate));
		base.Model[typeof(IfcLinearPathSurrogate)].Add(1, "GUID").Add(2, "Identification").Add(3, "Properties")
			.Add(4, "Materials")
			.Add(5, "Parent")
			.Add(6, "LocalTransformation")
			.Add(7, "GlobalTransformation")
			.Add(8, "Axes")
			.Add(9, "Openings")
			.Add(10, "Systems")
			.UseConstructor = false;
		metaType = base.Model[typeof(WireBoxSurrogate)];
		metaType.UseConstructor = false;
		metaType = base.Model[typeof(ToolpathSurrogate)];
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "Tool");
			metaType.Add(2, "MotionList");
			metaType.Add(3, "RapidColor");
			metaType.Add(4, "RapidPattern");
			metaType.Add(6, "Transformation");
			metaType.Add(7, "LeadColor");
			metaType.Add(8, "RampColor");
		}
		if (Content != contentType.Geometry)
		{
			metaType.Add(5, "AllVertices");
			AddVerticesField(metaType);
		}
		metaType.UseConstructor = false;
		base.Model.Add(typeof(Toolpath.Motion), applyDefaultBehaviour: false).AddSubType(201, typeof(Toolpath.LinearMotion)).AddSubType(202, typeof(Toolpath.CircularMotion))
			.SetSurrogate(typeof(MotionSurrogate));
		metaType = base.Model[typeof(MotionSurrogate)];
		metaType.AddSubType(201, typeof(LinearMotionSurrogate));
		metaType.AddSubType(202, typeof(CircularMotionSurrogate));
		metaType.Add(1, "Speed");
		metaType.Add(2, "Feed");
		metaType.Add(3, "Code");
		metaType.Add(4, "CodeLine");
		metaType.Add(5, "Approach");
		metaType.Add(6, "PrintLayer");
		metaType.Add(7, "PrintExtrusionRadius");
		metaType.Add(8, "PrintExtrusionRadiusX");
		metaType.Add(9, "PrintExtrusionRadiusY");
		if (Content != contentType.Geometry)
		{
			metaType.Add(10, "Points");
		}
		metaType.SetCallbacks(null, null, "BeforeDeserialize", null);
		metaType.UseConstructor = false;
		base.Model[typeof(LinearMotionSurrogate)].Add(1, "From").Add(2, "To").UseConstructor = false;
		metaType = base.Model[typeof(CircularMotionSurrogate)];
		metaType.Add(1, "Radius");
		metaType.Add(2, "Angle");
		if (base.HeaderVersion < 22)
		{
			metaType.Add(3, "Points_V21");
		}
		metaType.Add(4, "Depth");
		metaType.Add(5, "StartNormal");
		metaType.Add(6, "EndNormal");
		metaType.UseConstructor = false;
		AddPlaneField(metaType);
		if (base.HeaderVersion < 22)
		{
			base.Model[typeof(Point3D)].AddSubType(209, typeof(PointCL));
			base.Model[typeof(Point3DSurrogate)].AddSubType(209, typeof(PointCLSurrogate_V21Surrogate));
			metaType = base.Model[typeof(PointCLSurrogate_V21Surrogate)];
		}
		else
		{
			base.Model[typeof(PointNormal)].AddSubType(201, typeof(PointCL));
			base.Model[typeof(PointNormalSurrogate)].AddSubType(201, typeof(PointCLSurrogate));
			metaType = base.Model[typeof(PointCLSurrogate)];
		}
		metaType.Add(1, "Tool");
		metaType.Add(2, "Speed");
		metaType.Add(3, "Feed");
		metaType.Add(4, "Code");
		metaType.Add(5, "MotionIndex");
		metaType.UseConstructor = false;
		metaType = base.Model[typeof(CompositeCurveSurrogate)];
		metaType.UseConstructor = false;
		metaType.Add(1, "CurveList");
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion))
		{
			_0023_003DzM6fU__0024hmcD5K(metaType);
			metaType.Add(101, "GraphicalCurves");
		}
		metaType = base.Model[typeof(JointSurrogate)].Add(1, "Position").Add(2, "Radius").Add(3, "SubdivisionLevel");
		if (Content != contentType.Geometry)
		{
			AddVerticesField(metaType);
			AddTrianglesField(metaType);
		}
		metaType.UseConstructor = false;
		base.Model[typeof(Bar)].AddSubType(201, typeof(ConicalBar));
		base.Model[typeof(BarSurrogate)].AddSubType(201, typeof(ConicalBarSurrogate));
		metaType = base.Model[typeof(BarSurrogate)].Add(1, "StartPoint").Add(2, "EndPoint").Add(3, "Radius")
			.Add(4, "Slices");
		if (Content != contentType.Geometry)
		{
			AddVerticesField(metaType);
			AddTrianglesField(metaType);
		}
		metaType.UseConstructor = false;
		metaType = base.Model[typeof(ConicalBarSurrogate)].Add(1, "TopRadius");
		if (Content != contentType.Geometry)
		{
			AddNormalsField(metaType);
		}
		metaType.UseConstructor = false;
		metaType = base.Model[typeof(PointCloudSurrogate)];
		metaType.UseConstructor = false;
		if (Content != contentType.Geometry)
		{
			metaType.Add(1, "Nature");
		}
		metaType.Add(2, "DrawingStyle");
		AddVerticesField(metaType);
		_0023_003DzM6fU__0024hmcD5K(metaType);
		metaType = base.Model[typeof(FastPointCloudSurrogate)];
		metaType.UseConstructor = false;
		if (Content != contentType.Geometry)
		{
			metaType.Add(1, "Nature");
		}
		metaType.Add(2, "DrawingStyle");
		metaType.AddField(3, "PointArray").IsPacked = true;
		metaType.AddField(4, "ColorArray").IsPacked = true;
		metaType.Add(5, "ZoomFitSpeed");
		base.Model[typeof(BlockReference)].AddSubType(201, typeof(IfcBlockReference)).AddSubType(203, typeof(View));
		base.Model[typeof(BlockReferenceSurrogate)].AddSubType(201, typeof(IfcBlockReferenceSurrogate)).AddSubType(203, typeof(ViewSurrogate));
		metaType = base.Model[typeof(BlockReferenceSurrogate)];
		metaType.Add(1, "BlockName");
		metaType.Add(2, "Transformation");
		if (Content != contentType.Tessellation)
		{
			metaType.Add(3, "Attributes");
		}
		metaType.Add(4, "IsFixed");
		metaType.UseConstructor = false;
		base.Model[typeof(IfcBlockReferenceSurrogate)].Add(1, "GUID").Add(2, "Identification").Add(3, "Properties")
			.Add(4, "Materials")
			.Add(5, "Parent")
			.Add(6, "LocalTransformation")
			.Add(7, "GlobalTransformation")
			.Add(8, "Axes")
			.Add(9, "Openings")
			.Add(10, "Systems")
			.UseConstructor = false;
		base.Model[typeof(View)].AddSubType(201, typeof(VectorView)).AddSubType(202, typeof(RasterView));
		base.Model[typeof(VectorView)].AddSubType(201, typeof(SectionView));
		base.Model[typeof(ViewSurrogate)].AddSubType(201, typeof(VectorViewSurrogate)).AddSubType(202, typeof(RasterViewSurrogate));
		base.Model[typeof(VectorViewSurrogate)].AddSubType(201, typeof(SectionViewSurrogate));
		if (Content != contentType.Tessellation)
		{
			base.Model[typeof(ViewSurrogate)].Add(1, "X").Add(2, "Y").Add(3, "Camera")
				.Add(4, "ViewType")
				.Add(5, "Scale")
				.Add(6, "Width")
				.Add(7, "Height")
				.Add(8, "Window")
				.Add(9, "WindowCenter")
				.Add(10, "HasChanged")
				.Add(11, "EntitiesToHide")
				.Add(12, "viewportSize")
				.Add(13, "Dpi")
				.Add(14, "Shadow")
				.Add(15, "FreezeAlpha")
				.UseConstructor = false;
			metaType = base.Model[typeof(VectorViewSurrogate)];
			metaType.Add(1, "HiddenSegments");
			metaType.Add(2, "IgnoreTransparency");
			metaType.Add(3, "FillTexts");
			metaType.Add(4, "FontAccuracy");
			metaType.Add(5, "FillRegions");
			metaType.Add(6, "KeepEntityColor");
			metaType.Add(7, "TreatWhiteAsBlack");
			metaType.Add(8, "CenterlinesExtensionAmount");
			metaType.Add(10, "originTranslation");
			metaType.Add(11, "segmentsScaleFactor");
			metaType.Add(12, "Shaded");
			metaType.UseConstructor = false;
			base.Model[typeof(RasterViewSurrogate)].Add(1, "dpiOld").Add(2, "DisplayMode").Add(3, "shadowOld")
				.Add(4, "freezeAlphaOld")
				.UseConstructor = false;
			metaType = base.Model[typeof(SectionViewSurrogate)];
			metaType.Add(1, "SectionPlane");
			metaType.Add(2, "ParentView");
			metaType.Add(3, "SectionLine");
			metaType.UseConstructor = false;
		}
		else
		{
			base.Model[typeof(ViewSurrogate)].UseConstructor = false;
			base.Model[typeof(VectorViewSurrogate)].UseConstructor = false;
			base.Model[typeof(RasterViewSurrogate)].UseConstructor = false;
			base.Model[typeof(SectionViewSurrogate)].UseConstructor = false;
		}
		base.Model[typeof(NurbsBase)].AddSubType(201, typeof(Curve)).AddSubType(202, typeof(Surface));
		metaType = base.Model[typeof(NurbsBaseSurrogate)].AddSubType(201, typeof(CurveSurrogate)).AddSubType(202, typeof(SurfaceSurrogate));
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "p");
			metaType.Add(2, "U");
		}
		if (Content != contentType.Geometry)
		{
			AddVerticesField(metaType);
		}
		metaType.UseConstructor = false;
		base.Model[typeof(Curve)].AddSubType(201, typeof(TrimCurve));
		metaType = base.Model[typeof(CurveSurrogate)].AddSubType(201, typeof(TrimCurveSurrogate));
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "Pw");
		}
		_0023_003DzM6fU__0024hmcD5K(metaType);
		metaType.UseConstructor = false;
		base.Model[typeof(TrimCurveSurrogate)].Add(1, "Edge").UseConstructor = false;
		base.Model[typeof(Surface)].AddSubType(201, typeof(PlanarSurface)).AddSubType(202, typeof(TabulatedSurface)).AddSubType(203, typeof(RevolvedSurface));
		metaType = base.Model[typeof(SurfaceSurrogate)].AddSubType(201, typeof(PlanarSurfaceSurrogate)).AddSubType(202, typeof(TabulatedSurfaceSurrogate)).AddSubType(203, typeof(RevolvedSurfaceSurrogate));
		metaType.UseConstructor = false;
		metaType.Add(1, "TextureScaleU");
		metaType.Add(2, "TextureScaleV");
		metaType.Add(3, "TextureOffsetU");
		metaType.Add(4, "TextureOffsetV");
		if (Content != contentType.Tessellation)
		{
			metaType.Add(5, "Pw");
			metaType.Add(6, "q");
			metaType.Add(7, "V");
			metaType.Add(8, "Trimming");
		}
		_0023_003DzM6fU__0024hmcD5K(metaType);
		if (Content == contentType.GeometryAndTessellation)
		{
			metaType.Add(9, "geomIsocurves");
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion))
			{
				metaType.Add(10, "graphicalEdge");
			}
		}
		if (Content != contentType.Geometry)
		{
			AddTrianglesField(metaType);
		}
		metaType.Add(11, "TextureRotationAngle");
		metaType = base.Model[typeof(PlanarSurfaceSurrogate)];
		metaType.UseConstructor = false;
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "Plane");
		}
		metaType = base.Model[typeof(TabulatedSurfaceSurrogate)];
		metaType.UseConstructor = false;
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "Generatrix");
			metaType.Add(2, "Directrix");
		}
		base.Model[typeof(RevolvedSurface)].AddSubType(201, typeof(CylindricalSurface)).AddSubType(202, typeof(SphericalSurface));
		metaType = base.Model[typeof(RevolvedSurfaceSurrogate)].AddSubType(201, typeof(CylindricalSurfaceSurrogate)).AddSubType(202, typeof(SphericalSurfaceSurrogate));
		metaType.UseConstructor = false;
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "Generatrix");
			metaType.Add(2, "SeamPlane");
		}
		base.Model[typeof(CylindricalSurface)].AddSubType(201, typeof(ConicalSurface));
		metaType = base.Model[typeof(CylindricalSurfaceSurrogate)].AddSubType(201, typeof(ConicalSurfaceSurrogate));
		metaType.UseConstructor = false;
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "Radius");
		}
		base.Model[typeof(SphericalSurface)].AddSubType(201, typeof(ToroidalSurface));
		metaType = base.Model[typeof(SphericalSurfaceSurrogate)].AddSubType(201, typeof(ToroidalSurfaceSurrogate));
		metaType.UseConstructor = false;
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "Radius");
		}
		metaType = base.Model[typeof(ConicalSurfaceSurrogate)];
		metaType.UseConstructor = false;
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "HalfAngle");
			metaType.Add(2, "Tip");
		}
		metaType = base.Model[typeof(ToroidalSurfaceSurrogate)];
		metaType.UseConstructor = false;
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "MajorRadius");
		}
		base.Model[typeof(Point3D)].AddSubType(207, typeof(Brep.Vertex));
		base.Model[typeof(Point3DSurrogate)].AddSubType(207, typeof(BrepVertexSurrogate));
		base.Model[typeof(BrepVertexSurrogate)].Add(1, "Parents").UseConstructor = false;
		base.Model.Add(typeof(Brep.Edge), applyDefaultBehaviour: false).SetSurrogate(typeof(BrepEdgeSurrogate));
		metaType = base.Model[typeof(BrepEdgeSurrogate)];
		metaType.Add(1, "StartPointIndex");
		metaType.Add(2, "EndPointIndex");
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion))
		{
			metaType.Add(3, "curve_2022");
		}
		else
		{
			metaType.Add(3, "Curve");
		}
		metaType.Add(4, "ShellIndex");
		metaType.Add(5, "Parents");
		metaType.Add(6, "EdgeData");
		metaType.SetCallbacks(null, null, "BeforeDeserialize", null);
		metaType.UseConstructor = false;
		base.Model.Add(typeof(Brep.OrientedEdge), applyDefaultBehaviour: false).SetSurrogate(typeof(BrepOrientedEdgeSurrogate));
		base.Model[typeof(BrepOrientedEdgeSurrogate)].Add(1, "Sense").Add(2, "CurveIndex").SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model.Add(typeof(Brep.Loop), applyDefaultBehaviour: false).SetSurrogate(typeof(BrepLoopSurrogate));
		base.Model[typeof(BrepLoopSurrogate)].Add(1, "Segments").Add(2, "Sense").SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model.Add(typeof(Brep.Face), applyDefaultBehaviour: false).SetSurrogate(typeof(BrepFaceSurrogate));
		metaType = base.Model[typeof(BrepFaceSurrogate)];
		metaType.SetCallbacks(null, null, "BeforeDeserialize", null);
		metaType.UseConstructor = false;
		if (Content != contentType.Tessellation)
		{
			metaType.Add(1, "Loops");
			metaType.Add(2, "Sense");
			if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion))
			{
				metaType.Add(3, "ARGB");
			}
			else
			{
				metaType.Add(3, "Color");
			}
			metaType.Add(4, "Surface");
		}
		if (Content != contentType.Geometry)
		{
			metaType.Add(5, "Tessellation");
		}
		metaType.Add(6, "TextureOffsetU");
		metaType.Add(7, "TextureScaleU");
		metaType.Add(8, "TextureOffsetV");
		metaType.Add(9, "TextureScaleV");
		metaType.Add(10, "FaceData");
		metaType.Add(11, "MaterialName");
		metaType.Add(12, "TextureRotationAngle");
		metaType = base.Model[typeof(BrepSurrogate)];
		metaType.UseConstructor = false;
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion))
		{
			_0023_003DzM6fU__0024hmcD5K(metaType);
			if (Content == contentType.Tessellation)
			{
				metaType.Add(5, "Faces");
				metaType.Add(6, "Inners");
			}
			if (Content != contentType.Geometry)
			{
				if (Content != contentType.Tessellation)
				{
					metaType.Add(7, "GraphicalEdges");
				}
				metaType.Add(8, "TessellationFaces");
				metaType.Add(9, "TessellationInners");
			}
		}
		else
		{
			metaType.Add(1, "Faces");
			metaType.Add(2, "Inners");
			if (Content != contentType.Tessellation)
			{
				metaType.Add(3, "Edges");
				metaType.Add(4, "RebuildTolerance");
				AddVerticesField(metaType);
			}
		}
		base.Model.Add(typeof(AnalyticSurf), applyDefaultBehaviour: false).AddSubType(201, typeof(NurbsSurf)).AddSubType(202, typeof(TabulatedSurf))
			.AddSubType(203, typeof(PlanarSurf))
			.SetSurrogate(typeof(AnalyticSurfSurrogate));
		base.Model[typeof(AnalyticSurfSurrogate)].AddSubType(201, typeof(NurbsSurfSurrogate)).AddSubType(202, typeof(TabulatedSurfSurrogate)).AddSubType(203, typeof(PlanarSurfSurrogate))
			.SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model[typeof(NurbsSurfSurrogate)].Add(1, "DegreeU").Add(2, "KnotVectorU").Add(3, "DegreeV")
			.Add(4, "KnotVectorV")
			.Add(5, "ControlPoints")
			.UseConstructor = false;
		metaType = base.Model[typeof(TabulatedSurfSurrogate)];
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion))
		{
			metaType.Add(1, "directrix_2022");
		}
		else
		{
			metaType.Add(1, "Directrix");
		}
		metaType.Add(2, "Generatrix");
		metaType.UseConstructor = false;
		base.Model[typeof(PlanarSurf)].AddSubType(201, typeof(RevolvedSurf)).AddSubType(202, typeof(ToroidalSurf)).AddSubType(203, typeof(CylindricalSurf));
		metaType = base.Model[typeof(PlanarSurfSurrogate)].AddSubType(201, typeof(RevolvedSurfSurrogate)).AddSubType(202, typeof(ToroidalSurfSurrogate)).AddSubType(203, typeof(CylindricalSurfSurrogate));
		metaType.UseConstructor = false;
		AddPlaneField(metaType);
		metaType = base.Model[typeof(RevolvedSurfSurrogate)];
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion))
		{
			metaType.Add(1, "generatrix_2022");
		}
		else
		{
			metaType.Add(1, "Generatrix");
		}
		metaType.UseConstructor = false;
		base.Model[typeof(ToroidalSurfSurrogate)].Add(1, "MajorRadius").Add(2, "MinorRadius").UseConstructor = false;
		base.Model[typeof(CylindricalSurf)].AddSubType(201, typeof(ConicalSurf)).AddSubType(202, typeof(SphericalSurf));
		base.Model[typeof(CylindricalSurfSurrogate)].AddSubType(201, typeof(ConicalSurfSurrogate)).AddSubType(202, typeof(SphericalSurfSurrogate)).Add(1, "Radius")
			.UseConstructor = false;
		base.Model[typeof(ConicalSurfSurrogate)].Add(1, "HalfAngle").UseConstructor = false;
		base.Model[typeof(SphericalSurfSurrogate)].UseConstructor = false;
		metaType = base.Model[typeof(FemMeshSurrogate)];
		metaType.Add(1, "Elements");
		if (base.HeaderVersion < 10)
		{
			metaType.Add(2, "ElementEdgeColor");
		}
		if (base.HeaderVersion < 13)
		{
			metaType.Add(3, "BoundaryMeshTriangles").Add(4, "BoundaryMeshEdges");
		}
		if (Content != contentType.Geometry)
		{
			metaType.Add(5, "IsoEdges").Add(6, "BoundaryMesh").Add(7, "skinMinEdgeLen")
				.Add(8, "boundaryNodes");
		}
		AddVerticesField(metaType);
		metaType.UseConstructor = false;
		base.Model[typeof(IndexLine)].AddSubType(202, typeof(_0023_003Dzq82xW_psNYNgS0eYJnooIbBbm12QYw0YrA_003D_003D));
		base.Model[typeof(IndexLineSurrogate)].AddSubType(202, typeof(FemIndexLineExSurrogate)).UseConstructor = false;
		base.Model[typeof(FemIndexLineExSurrogate)].Add(1, "ElementIndex").UseConstructor = false;
		base.Model[typeof(IndexTriangle)].AddSubType(204, typeof(_0023_003DzdbCY_Ol_2RiGerZYwGcKL3V5U09dFmFFez1WZYE_003D));
		base.Model[typeof(IndexTriangleSurrogate)].AddSubType(204, typeof(FemIndexTriangleExSurrogate)).UseConstructor = false;
		base.Model[typeof(FemIndexTriangleExSurrogate)].Add(1, "ElementIndex").UseConstructor = false;
		base.Model[typeof(PointWithDisplacement)].AddSubType(201, typeof(Node));
		base.Model[typeof(Node)].AddSubType(201, typeof(NodeBeam));
		base.Model[typeof(PointWithDisplacementSurrogate)].AddSubType(201, typeof(FemNodeSurrogate));
		metaType = base.Model[typeof(FemNodeSurrogate)];
		metaType.AddSubType(201, typeof(FemNodeBeamSurrogate));
		metaType.Add(1, "Load");
		metaType.Add(2, "Restraints");
		metaType.Add(3, "Displacement");
		metaType.Add(4, "Temperature");
		if (base.HeaderVersion < 13)
		{
			metaType.Add(5, "rotation_V12");
		}
		metaType.Add(6, "Transformation");
		metaType.UseConstructor = false;
		base.Model[typeof(FemNodeBeamSurrogate)].Add(1, "MomentLoad").Add(2, "RotationRestraints").Add(3, "RotationDisplacement")
			.UseConstructor = false;
		base.Model.Add(typeof(Element), applyDefaultBehaviour: false).AddSubType(201, typeof(Element2D)).AddSubType(202, typeof(Element3D))
			.AddSubType(203, typeof(Joint2D))
			.SetSurrogate(typeof(FemElementSurrogate));
		base.Model[typeof(FemElementSurrogate)].AddSubType(201, typeof(FemElement2DSurrogate)).AddSubType(202, typeof(FemElement3DSurrogate)).AddSubType(203, typeof(FemJoint2DSurrogate))
			.Add(1, "Connection")
			.Add(2, "Material")
			.Add(3, "DistLoad")
			.Add(4, "Faces")
			.SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model[typeof(Joint2D)].AddSubType(201, typeof(Joint3D));
		base.Model[typeof(FemJoint2DSurrogate)].AddSubType(201, typeof(FemJoint3DSurrogate)).Add(1, "Rotation").Add(2, "Stiffness")
			.UseConstructor = false;
		base.Model[typeof(FemJoint3DSurrogate)].UseConstructor = false;
		base.Model[typeof(Element2D)].AddSubType(201, typeof(Tria3)).AddSubType(202, typeof(Tria6)).AddSubType(203, typeof(Quad4))
			.AddSubType(204, typeof(Quad8))
			.AddSubType(205, typeof(Truss2D))
			.AddSubType(206, typeof(Beam2D));
		base.Model[typeof(FemElement2DSurrogate)].AddSubType(201, typeof(FemTria3Surrogate)).AddSubType(202, typeof(FemTria6Surrogate)).AddSubType(203, typeof(FemQuad4Surrogate))
			.AddSubType(204, typeof(FemQuad8Surrogate))
			.AddSubType(205, typeof(FemTruss2DSurrogate))
			.AddSubType(206, typeof(FemBeam2DSurrogate))
			.Add(1, "Edges")
			.UseConstructor = false;
		base.Model[typeof(FemTria3Surrogate)].UseConstructor = false;
		base.Model[typeof(FemTria6Surrogate)].UseConstructor = false;
		base.Model[typeof(FemQuad4Surrogate)].UseConstructor = false;
		base.Model[typeof(FemQuad8Surrogate)].UseConstructor = false;
		base.Model[typeof(FemTruss2DSurrogate)].Add(1, "SecArea").UseConstructor = false;
		metaType = base.Model[typeof(FemBeam2DSurrogate)];
		metaType.Add(1, "Temperature").Add(2, "HingeStart").Add(3, "HingeEnd")
			.Add(4, "SubdivisionNumber");
		if (Content != contentType.Geometry)
		{
			metaType.Add(5, "BeamVerts");
		}
		metaType.UseConstructor = false;
		base.Model[typeof(Element3D)].AddSubType(201, typeof(Tetra4)).AddSubType(202, typeof(Tetra10)).AddSubType(203, typeof(Penta6))
			.AddSubType(204, typeof(Penta15))
			.AddSubType(205, typeof(Hexa8))
			.AddSubType(206, typeof(Hexa20))
			.AddSubType(207, typeof(Truss))
			.AddSubType(208, typeof(Beam));
		base.Model[typeof(FemElement3DSurrogate)].AddSubType(201, typeof(FemTetra4Surrogate)).AddSubType(202, typeof(FemTetra10Surrogate)).AddSubType(203, typeof(FemPenta6Surrogate))
			.AddSubType(204, typeof(FemPenta15Surrogate))
			.AddSubType(205, typeof(FemHexa8Surrogate))
			.AddSubType(206, typeof(FemHexa20Surrogate))
			.AddSubType(207, typeof(FemTrussSurrogate))
			.AddSubType(208, typeof(FemBeamSurrogate))
			.UseConstructor = false;
		base.Model[typeof(FemTetra4Surrogate)].UseConstructor = false;
		base.Model[typeof(FemTetra10Surrogate)].UseConstructor = false;
		base.Model[typeof(FemPenta6Surrogate)].UseConstructor = false;
		base.Model[typeof(FemPenta15Surrogate)].UseConstructor = false;
		base.Model[typeof(FemHexa8Surrogate)].UseConstructor = false;
		base.Model[typeof(FemHexa20Surrogate)].UseConstructor = false;
		base.Model[typeof(FemTrussSurrogate)].Add(1, "SecArea").Add(2, "Temperature").UseConstructor = false;
		metaType = base.Model[typeof(FemBeamSurrogate)];
		metaType.Add(1, "Temperature").Add(2, "HingeStart").Add(3, "HingeEnd")
			.Add(4, "SubdivisionNumber");
		if (Content != contentType.Geometry)
		{
			metaType.Add(5, "BeamVerts");
		}
		metaType.Add(6, "V");
		metaType.UseConstructor = false;
		base.Model.Add(typeof(Element.Face), applyDefaultBehaviour: false).SetSurrogate(typeof(FemFaceSurrogate));
		base.Model[typeof(FemFaceSurrogate)].Add(1, "Indices").Add(2, "Visible").Add(3, "Centroid")
			.Add(4, "CornerNormals")
			.Add(5, "Triangles")
			.Add(6, "NormalPressure")
			.Add(7, "Pressure")
			.SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model.Add(typeof(Element2D.Edge), applyDefaultBehaviour: false).SetSurrogate(typeof(FemEdgeSurrogate));
		base.Model[typeof(FemEdgeSurrogate)].Add(1, "Indices").Add(2, "NormalPressure").Add(3, "Pressure")
			.SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		if (base.HeaderVersion < 13)
		{
			base.Model.Add(typeof(devDept.Eyeshot.Fem.Rotation), applyDefaultBehaviour: false).SetSurrogate(typeof(FemRotationSurrogate));
			base.Model[typeof(FemRotationSurrogate)].Add(1, "Matrix").SetCallbacks(null, null, "BeforeDeserialize", null).UseConstructor = false;
		}
		base.Model[typeof(Material)].AddSubType(201, typeof(MaterialBeam));
		base.Model[typeof(MaterialSurrogate)].AddSubType(201, typeof(FemMaterialBeamSurrogate)).UseConstructor = false;
		base.Model[typeof(MaterialBeam)].AddSubType(201, typeof(MaterialBeamSquare)).AddSubType(202, typeof(MaterialBeamRect)).AddSubType(203, typeof(MaterialBeamCircle));
		base.Model[typeof(FemMaterialBeamSurrogate)].AddSubType(201, typeof(FemMaterialBeamSquareSurrogate)).AddSubType(202, typeof(FemMaterialBeamRectSurrogate)).AddSubType(203, typeof(FemMaterialBeamCircleSurrogate))
			.Add(1, "SectionArea")
			.Add(2, "Iw")
			.Add(3, "Iv")
			.Add(4, "TorsionK")
			.Add(5, "MaxHalfSection")
			.UseConstructor = false;
		base.Model[typeof(FemMaterialBeamSquareSurrogate)].Add(1, "Side").UseConstructor = false;
		base.Model[typeof(MaterialBeamRect)].AddSubType(201, typeof(MaterialBeamHollowRect)).AddSubType(202, typeof(MaterialBeamI));
		base.Model[typeof(FemMaterialBeamRectSurrogate)].AddSubType(201, typeof(FemMaterialBeamHollowRectSurrogate)).AddSubType(202, typeof(FemMaterialBeamISurrogate)).Add(1, "Width")
			.Add(2, "Height")
			.UseConstructor = false;
		base.Model[typeof(FemMaterialBeamHollowRectSurrogate)].Add(1, "Thickness").UseConstructor = false;
		base.Model[typeof(MaterialBeamI)].AddSubType(201, typeof(MaterialBeamT)).AddSubType(202, typeof(MaterialBeamC));
		base.Model[typeof(FemMaterialBeamISurrogate)].AddSubType(201, typeof(FemMaterialBeamTSurrogate)).AddSubType(202, typeof(FemMaterialBeamCSurrogate)).Add(1, "Flange")
			.Add(2, "Web")
			.UseConstructor = false;
		base.Model[typeof(FemMaterialBeamTSurrogate)].UseConstructor = false;
		base.Model[typeof(FemMaterialBeamCSurrogate)].UseConstructor = false;
		base.Model[typeof(MaterialBeamCircle)].AddSubType(201, typeof(MaterialBeamHollowCircle));
		base.Model[typeof(FemMaterialBeamCircleSurrogate)].AddSubType(201, typeof(FemMaterialBeamHollowCircleSurrogate)).Add(1, "Radius").UseConstructor = false;
		base.Model[typeof(FemMaterialBeamHollowCircleSurrogate)].Add(1, "InnerRadius").UseConstructor = false;
		base.Model[typeof(FastMesh)].AddSubType(201, typeof(SimulationStock));
		base.Model[typeof(FastMesh)].AddSubType(202, typeof(MultiFastMesh));
		metaType = base.Model[typeof(FastMeshSurrogate)];
		metaType.AddSubType(201, typeof(SimulationStockSurrogate));
		metaType.AddSubType(202, typeof(MultiFastMeshSurrogate));
		metaType.UseConstructor = false;
		metaType.AddField(1, "PointArray").IsPacked = true;
		metaType.AddField(2, "TriangleArray").IsPacked = true;
		metaType.AddField(3, "NormalArray").IsPacked = true;
		metaType.AddField(4, "ColorArray").IsPacked = true;
		metaType.AddField(5, "TextureCoordsArray").IsPacked = true;
		metaType.AddField(6, "Dynamic").IsPacked = true;
		metaType = base.Model[typeof(StockSurrogate)];
		metaType.UseConstructor = false;
		AddNormalsField(metaType);
		if (Content != contentType.Tessellation)
		{
			metaType.AddField(2, "RangeZ");
		}
		metaType = base.Model[typeof(SimulationStockSurrogate)];
		metaType.UseConstructor = false;
		metaType.AddField(1, "RowCount");
		metaType.AddField(2, "ColumnCount");
		metaType.AddField(3, "PlanarFaces");
		metaType.AddField(4, "Transformation");
		metaType.AddField(5, "GridStep");
		metaType.AddField(6, "WorkMin");
		metaType.AddField(7, "WorkMax");
		metaType = base.Model[typeof(SketchEntitySurrogate)];
		metaType.UseConstructor = false;
		if (base.HeaderVersion < 16 || Content != contentType.Tessellation)
		{
			metaType.Add(1, "Sketch");
		}
		if (base.HeaderVersion >= 16 || Content != contentType.Geometry)
		{
			metaType.Add(2, "CurveList");
			if (base.HeaderVersion >= 11 && base.HeaderVersion <= 15)
			{
				metaType.Add(5, "PointList");
			}
		}
		metaType.Add(3, "parentBrep");
		metaType.Add(4, "faceIndex");
		if (base.HeaderVersion < 16)
		{
			AddVerticesField(metaType);
		}
		base.Model[typeof(MultiFastMesh)].AddSubType(201, typeof(PrintSimulationMesh));
		metaType = base.Model[typeof(MultiFastMeshSurrogate)];
		metaType.AddSubType(201, typeof(PrintSimulationMeshSurrogate));
		metaType.UseConstructor = false;
		metaType.AddField(1, "SubMeshColors");
		metaType.AddField(2, "subMeshRanges");
		metaType = base.Model[typeof(PrintSimulationMeshSurrogate)];
		metaType.UseConstructor = false;
		metaType.AddField(1, "motionsByLevel");
		metaType.AddField(2, "styleColors");
		metaType.AddField(3, "styleRanges");
		metaType.AddField(4, "styleRangesToDraw");
		base.Model.Add(typeof(PrintSimulationMesh.MotionRange), applyDefaultBehaviour: false).SetSurrogate(typeof(MotionRangeSurrogate));
		base.Model[typeof(MotionRangeSurrogate)].Add(1, "Start").Add(2, "End").SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model.Add(typeof(PrintSimulationMesh.MotionRangeStyle), applyDefaultBehaviour: false).SetSurrogate(typeof(MotionRangeStyleSurrogate));
		base.Model[typeof(MotionRangeStyleSurrogate)].Add(1, "Range").Add(2, "ColorName").SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		base.Model[typeof(LinearEntitySurrogate)].Add(1, "SymbolSize").Add(2, "Position").Add(3, "Direction")
			.UseConstructor = false;
		if (base.HeaderVersion < 13)
		{
			base.Model[typeof(Block)].AddSubType(201, typeof(BlockEx));
			base.Model[typeof(BlockSurrogate)].AddSubType(201, typeof(BlockExSurrogate));
			base.Model[typeof(BlockExSurrogate)].Add(1, "XRefName_V12").Add(2, "BlockSource_V12").UseConstructor = false;
			base.Model[typeof(Layer)].AddSubType(201, typeof(LayerEx));
			base.Model[typeof(LayerSurrogate)].AddSubType(201, typeof(LayerExSurrogate));
			base.Model[typeof(LayerExSurrogate)].Add(1, "XRefName_V12").Add(2, "XData_V12").UseConstructor = false;
			base.Model[typeof(TextStyle)].AddSubType(201, typeof(TextStyleEx));
			base.Model[typeof(TextStyleSurrogate)].AddSubType(201, typeof(TextStyleExSurrogate));
			base.Model[typeof(TextStyleExSurrogate)].Add(1, "XRefName_V12").UseConstructor = false;
			base.Model[typeof(LineType)].AddSubType(201, typeof(LineTypeEx));
			base.Model[typeof(LineTypeSurrogate)].AddSubType(201, typeof(LineTypeExSurrogate));
			base.Model[typeof(LineTypeExSurrogate)].Add(1, "XRefName_V12").UseConstructor = false;
			base.Model[typeof(Sheet)].AddSubType(201, typeof(SheetEx));
			base.Model[typeof(SheetSurrogate)].AddSubType(201, typeof(SheetExSurrogate));
			base.Model[typeof(SheetExSurrogate)].Add(1, "Rotation").Add(2, "CanonicalMediaName").UseConstructor = false;
		}
		base.Model[typeof(LinearPath)].AddSubType(201, typeof(LinearPathEx));
		base.Model[typeof(LinearPathSurrogate)].AddSubType(201, typeof(LinearPathExSurrogate));
		base.Model[typeof(LinearPathExSurrogate)].UseConstructor = false;
		base.Model[typeof(Picture)].AddSubType(201, typeof(Ole2Frame));
		base.Model[typeof(PictureSurrogate)].AddSubType(201, typeof(Ole2FrameSurrogate));
		base.Model[typeof(Ole2FrameSurrogate)].UseConstructor = false;
		if (base.HeaderVersion < 22)
		{
			base.Model[typeof(PointSurrogate)].AddSubType(201, typeof(XlineSurrogate));
			base.Model[typeof(XlineSurrogate)].Add(1, "Direction").UseConstructor = false;
		}
		base.Model[typeof(Curve)].AddSubType(202, typeof(CurveEx));
		base.Model[typeof(CurveSurrogate)].AddSubType(202, typeof(CurveExSurrogate));
		base.Model[typeof(CurveExSurrogate)].UseConstructor = false;
		base.Model[typeof(BlockReference)].AddSubType(202, typeof(BlockReferenceEx));
		base.Model[typeof(BlockReferenceSurrogate)].AddSubType(202, typeof(BlockReferenceExSurrogate));
		base.Model[typeof(BlockReferenceExSurrogate)].Add(1, "CustomProperties").UseConstructor = false;
		base.Model[typeof(EntitySurrogate)].Add(49, "XData").Add(60, "AutodeskProperties");
		if (base.HeaderVersion < 7)
		{
			base.Model.Add(typeof(_0023_003Dztq44kFAgJ0opQGtZaex6wAI_003D), applyDefaultBehaviour: false).SetSurrogate(typeof(HandleSurrogate));
			base.Model[typeof(HandleSurrogate)].Add(1, "Value").SetCallbacks(null, null, "BeforeDeserialize", null).UseConstructor = false;
			base.Model.Add(typeof(_0023_003DzW6hL6bTkwK95EYu4adlJ5IGajobP), applyDefaultBehaviour: false).SetSurrogate(typeof(OdDbHandleSurrogate));
			base.Model[typeof(OdDbHandleSurrogate)].Add(1, "Value").SetCallbacks(null, null, "BeforeDeserialize", null).UseConstructor = false;
			base.Model.Add(typeof(_0023_003DzZWmLAWEIPGVg_NmmkN6VaQI_003D), applyDefaultBehaviour: false).SetSurrogate(typeof(Point3dSurrogate));
			base.Model[typeof(Point3dSurrogate)].Add(1, "X").Add(2, "Y").Add(3, "Z")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
		}
		base.Model.Add(typeof(AutodeskProperties), applyDefaultBehaviour: false).SetSurrogate(typeof(AutodeskPropertiesSurrogate));
		base.Model[typeof(AutodeskPropertiesSurrogate)].Add(1, "XData").Add(2, "Thickness").Add(3, "ExtrusionDir")
			.Add(4, "UnparsedDimensionText")
			.Add(5, "VisualStyleMode")
			.Add(6, "XClip")
			.SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
		if (Content != contentType.Tessellation)
		{
			base.Model.Add(typeof(IfcProperties), applyDefaultBehaviour: false).SetSurrogate(typeof(IfcPropertiesSurrogate));
			base.Model[typeof(IfcPropertiesSurrogate)].Add(1, "GUID").Add(2, "Identification").Add(3, "Properties")
				.Add(4, "Materials")
				.Add(5, "Parent")
				.Add(6, "LocalTransformation")
				.Add(7, "GlobalTransformation")
				.Add(8, "Axes")
				.Add(9, "Openings")
				.Add(10, "Systems")
				.Add(11, "ProfileDef")
				.Add(12, "ExtrusionAmount")
				.Add(13, "ElementType")
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
		}
		if (Content != contentType.Tessellation)
		{
			base.Model.Add(typeof(Mate), applyDefaultBehaviour: false).SetSurrogate(typeof(MateSurrogate));
			base.Model[typeof(Mate)].AddSubType(201, typeof(ConcentricMate)).AddSubType(202, typeof(DistanceMate)).AddSubType(203, typeof(AngleMate))
				.AddSubType(204, typeof(CoincidentMate))
				.AddSubType(205, typeof(TangentMate))
				.AddSubType(206, typeof(ParallelMate))
				.AddSubType(207, typeof(PerpendicularMate));
			metaType = base.Model[typeof(MateSurrogate)];
			metaType.Add(1, "constraintData1").Add(2, "constraintData2").Add(3, "Flipped")
				.AddSubType(201, typeof(ConcentricMateSurrogate))
				.AddSubType(202, typeof(DistanceMateSurrogate))
				.AddSubType(203, typeof(AngleMateSurrogate))
				.AddSubType(204, typeof(CoincidentMateSurrogate))
				.AddSubType(205, typeof(TangentMateSurrogate))
				.AddSubType(206, typeof(ParallelMateSurrogate))
				.AddSubType(207, typeof(PerpendicularMateSurrogate))
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			base.Model[typeof(ConcentricMateSurrogate)].UseConstructor = false;
			base.Model[typeof(DistanceMateSurrogate)].Add(1, "Distance").UseConstructor = false;
			base.Model[typeof(AngleMateSurrogate)].Add(1, "Angle").UseConstructor = false;
			base.Model[typeof(CoincidentMateSurrogate)].UseConstructor = false;
			base.Model[typeof(TangentMateSurrogate)].UseConstructor = false;
			base.Model[typeof(ParallelMateSurrogate)].UseConstructor = false;
			base.Model[typeof(PerpendicularMateSurrogate)].UseConstructor = false;
			base.Model.Add(typeof(ConstraintData), applyDefaultBehaviour: false).SetSurrogate(typeof(ConstraintDataSurrogate));
			base.Model[typeof(ConstraintData)].AddSubType(201, typeof(SphericalConstraintData)).AddSubType(202, typeof(PlanarConstraintData)).AddSubType(203, typeof(LinearConstraintData))
				.AddSubType(204, typeof(CircleConstraintData))
				.AddSubType(205, typeof(PointConstraintData));
			base.Model[typeof(PlanarConstraintData)].AddSubType(201, typeof(RevolvedConstraintData));
			base.Model[typeof(SphericalConstraintData)].AddSubType(201, typeof(CylindricalConstraintData));
			base.Model[typeof(CylindricalConstraintData)].AddSubType(201, typeof(ConicalConstraintData)).AddSubType(202, typeof(ToroidalConstraintData));
			base.Model[typeof(ConstraintDataSurrogate)].Add(1, "Component").Add(2, "AccTrans").AddSubType(201, typeof(SphericalConstraintDataSurrogate))
				.AddSubType(202, typeof(PlanarConstraintDataSurrogate))
				.AddSubType(203, typeof(LinearConstraintDataSurrogate))
				.AddSubType(204, typeof(CircleConstraintDataSurrogate))
				.AddSubType(205, typeof(PointConstraintDataSurrogate))
				.SetCallbacks(null, null, "BeforeDeserialize", null)
				.UseConstructor = false;
			base.Model[typeof(PlanarConstraintDataSurrogate)].Add(1, "Origin").Add(2, "AxisX").Add(3, "AxisY")
				.Add(4, "AxisZ")
				.AddSubType(201, typeof(RevolvedConstraintDataSurrogate))
				.UseConstructor = false;
			base.Model[typeof(RevolvedConstraintDataSurrogate)].Add(1, "Generatrix").UseConstructor = false;
			base.Model[typeof(SphericalConstraintDataSurrogate)].Add(1, "Center").Add(2, "Radius").AddSubType(201, typeof(CylindricalConstraintDataSurrogate))
				.UseConstructor = false;
			base.Model[typeof(CylindricalConstraintDataSurrogate)].Add(1, "AxisX").Add(2, "AxisY").Add(3, "AxisZ")
				.AddSubType(201, typeof(ConicalConstraintDataSurrogate))
				.AddSubType(202, typeof(ToroidalConstraintDataSurrogate))
				.UseConstructor = false;
			base.Model[typeof(ConicalConstraintDataSurrogate)].Add(1, "HalfAngle").Add(2, "Tip").UseConstructor = false;
			base.Model[typeof(ToroidalConstraintDataSurrogate)].Add(1, "MinorRadius").UseConstructor = false;
			base.Model[typeof(LinearConstraintDataSurrogate)].Add(1, "Start").Add(2, "End").UseConstructor = false;
			base.Model[typeof(CircleConstraintDataSurrogate)].Add(1, "Center").Add(2, "AxisX").Add(3, "AxisY")
				.Add(4, "AxisZ")
				.Add(5, "Radius")
				.UseConstructor = false;
			base.Model[typeof(PointConstraintDataSurrogate)].Add(1, "Position").UseConstructor = false;
		}
		base.Model.Add(typeof(AssemblyLeaf), applyDefaultBehaviour: false).SetSurrogate(typeof(AssemblyLeafSurrogate));
		base.Model[typeof(AssemblyLeafSurrogate)].Add(1, "Entity").Add(2, "Parents").SetCallbacks(null, null, "BeforeDeserialize", null)
			.UseConstructor = false;
	}

	protected override Type GetTypeForObject(string typeName)
	{
		Type type = Type.GetType(typeName, throwOnError: false, ignoreCase: true);
		if (type != null)
		{
			return type;
		}
		return base.GetTypeForObject(typeName);
	}

	private void _0023_003DzM6fU__0024hmcD5K(MetaType _0023_003DzaV_0z_A_003D)
	{
		if (Serializer._0023_003DzY80rnyP1aLmmGJuDx7wOx6g_003D(base.HeaderVersion))
		{
			_0023_003DzaV_0z_A_003D.Add(57, "Primitive");
		}
	}

	protected void Serialize(Stream stream)
	{
		if (FileHeader == null || FileBody == null)
		{
			throw new NullReferenceException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670933));
		}
		if (!FileHeader.Version.Equals(Serializer.LastVersion))
		{
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670882), FileHeader.Version, Serializer.LastVersion));
		}
		_0023_003DzD4s61YTMJkVY(stream);
		SerializationContext context = new SerializationContext
		{
			Context = this
		};
		try
		{
			if (FileHeader.SerializationMode == serializationType.Compressed)
			{
				GZipStream gZipStream = new GZipStream(stream, CompressionMode.Compress, leaveOpen: true);
				try
				{
					BufferedStream bufferedStream = new BufferedStream(gZipStream, 65536);
					try
					{
						base.Model.Serialize(bufferedStream, FileBody, context);
						return;
					}
					finally
					{
						((IDisposable)bufferedStream).Dispose();
					}
				}
				finally
				{
					((IDisposable)gZipStream).Dispose();
				}
			}
			base.Model.Serialize(stream, FileBody, context);
		}
		finally
		{
			Serializer.ResetCache();
		}
	}

	private void _0023_003DzD4s61YTMJkVY(Stream _0023_003DzdLqTRfo_003D)
	{
		_0023_003DzaUdPS0OQBtT4();
		FileHeader._0023_003DzrqzVY_0024yjCIPY(DateTime.Now);
		if (!ModelIsCompiled())
		{
			InitializeModel();
			CompileModel();
		}
		_0023_003DzIWkxaBcMUUs2(_0023_003DzdLqTRfo_003D, FileHeader);
	}

	internal void _0023_003DzIWkxaBcMUUs2(Stream _0023_003DzdLqTRfo_003D, FileHeader _0023_003Dz7yVgmfHOaIMi)
	{
		base.Model.SerializeWithLengthPrefix(_0023_003DzdLqTRfo_003D, _0023_003Dz7yVgmfHOaIMi, typeof(FileHeader), PrefixStyle.Base128, 1);
	}

	private void _0023_003DzaUdPS0OQBtT4()
	{
		base.HeaderVersion = FileHeader.Version;
		base.HeaderTag = FileHeader.Tag;
	}

	private contentType _0023_003DzcqkNi7kAZsSp(Stream _0023_003DzdLqTRfo_003D)
	{
		_0023_003DzXNfmF6NWSjv_0024(_0023_003DzdLqTRfo_003D);
		contentType contentType2 = _0023_003DziAPNcdKE4fVX(FileHeader.Content, Content);
		if (contentType2 != Content)
		{
			WriteLog(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671058), Content, contentType2));
			Content = contentType2;
			InitializeModel();
		}
		else if (!ModelIsCompiled())
		{
			FillModel();
		}
		CompileModel();
		return contentType2;
	}

	internal void _0023_003DzXNfmF6NWSjv_0024(Stream _0023_003DzdLqTRfo_003D)
	{
		InitializeModel(headerOnly: true);
		_0023_003Dzxyb5j_7Y47ro(base.Model.DeserializeWithLengthPrefix(_0023_003DzdLqTRfo_003D, null, typeof(FileHeader), PrefixStyle.Base128, 1) as FileHeader);
		if (FileHeader == null)
		{
			throw new InvalidOperationException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671731));
		}
		_0023_003DzaUdPS0OQBtT4();
		if (!Serializer.IsValidVersion(base.HeaderVersion))
		{
			_0023_003Dzxyb5j_7Y47ro(null);
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671124), base.HeaderVersion));
		}
	}

	[CLSCompliant(false)]
	protected void DeserializeBody(Stream source, SerializationContext serializationContext)
	{
		if (FileHeader == null || source.Position == 0L)
		{
			_0023_003DzXNfmF6NWSjv_0024(source);
		}
		if (!Serializer.IsValidVersion(base.HeaderVersion))
		{
			throw new EyeshotException(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671124), base.HeaderVersion));
		}
		if (FileHeader.SerializationMode == serializationType.Compressed)
		{
			GZipStream gZipStream = new GZipStream(source, CompressionMode.Decompress, leaveOpen: true);
			try
			{
				BufferedStream bufferedStream = new BufferedStream(gZipStream, 65536);
				try
				{
					_0023_003DzaC8OGtIKpswL((FileBody)base.Model.Deserialize(bufferedStream, null, typeof(FileBody), serializationContext));
					return;
				}
				finally
				{
					((IDisposable)bufferedStream).Dispose();
				}
			}
			finally
			{
				((IDisposable)gZipStream).Dispose();
			}
		}
		_0023_003DzaC8OGtIKpswL((FileBody)base.Model.Deserialize(source, null, typeof(FileBody), serializationContext));
	}

	public void SerializeFile(FileHeader header, FileBody body, Stream stream)
	{
		_0023_003DzGkunnSI_003D(header, body);
		SerializeFile(stream);
	}

	public void SerializeFile(Stream stream)
	{
		if (FileHeader == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671250));
		}
		if (FileBody == null)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302670968));
		}
		Content = FileHeader.Content;
		FileBody._0023_003DzjxMrVLP5c_wq(Content, _0023_003DzSGOANnwavSFDNqyIWLedlKk_003D: false, _0023_003DzZ9xh1dFMrWh_0024);
		Serialize(stream);
	}

	public void Deserialize(Stream stream)
	{
		contentType _0023_003DzB5M5dYA_003D = _0023_003DzcqkNi7kAZsSp(stream);
		try
		{
			DeserializeBody(stream, new SerializationContext
			{
				Context = this
			});
			FileBody._0023_003DzjxMrVLP5c_wq(_0023_003DzB5M5dYA_003D, _0023_003DzSGOANnwavSFDNqyIWLedlKk_003D: true, _0023_003DzZ9xh1dFMrWh_0024);
			if (base.HeaderVersion < 8)
			{
				FileBody._0023_003DzIOhKPiQEryDf();
			}
			if (base.HeaderVersion <= 16)
			{
				_0023_003DzcCn3mRfeJU0lVOqm_0024g73Uds_003D();
			}
		}
		finally
		{
			Serializer.ResetCache();
		}
	}

	private void _0023_003DzcCn3mRfeJU0lVOqm_0024g73Uds_003D()
	{
		if (FileBody.Entities != null)
		{
			foreach (Entity entity in FileBody.Entities)
			{
				_0023_003Dzzt74D_vwiqIf(entity);
			}
		}
		if (FileBody.Blocks == null)
		{
			return;
		}
		foreach (Block block in FileBody.Blocks)
		{
			foreach (Entity entity2 in block.Entities)
			{
				_0023_003Dzzt74D_vwiqIf(entity2);
			}
		}
	}

	private void _0023_003Dzzt74D_vwiqIf(Entity _0023_003Dz9j7EUB0_003D)
	{
		if (!string.IsNullOrEmpty(_0023_003Dz9j7EUB0_003D.MaterialName) && !FileBody.Materials.Contains(_0023_003Dz9j7EUB0_003D.MaterialName))
		{
			Material defaultMaterialShaded = ControlData.DefaultMaterialShaded;
			defaultMaterialShaded.Name = _0023_003Dz9j7EUB0_003D.MaterialName;
			defaultMaterialShaded.Diffuse = _0023_003Dz9j7EUB0_003D.Color;
			FileBody.Materials.Add(defaultMaterialShaded);
		}
	}

	protected void SerializeHeaderWithLengthPrefix(FileHeader fileHeader, Stream stream)
	{
		_0023_003DzNHShqHtUfjy7(fileHeader);
		_0023_003DzD4s61YTMJkVY(stream);
	}

	protected FileHeader DeserializeHeaderWithLengthPrefix(Stream stream)
	{
		_0023_003DzcqkNi7kAZsSp(stream);
		return FileHeader;
	}

	protected void SerializeWithLengthPrefix(Stream stream, object obj, int fieldNumber = 1)
	{
		if (base.HeaderVersion < 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671686));
		}
		SerializationContext context = new SerializationContext
		{
			Context = this
		};
		base.Model.SerializeWithLengthPrefix(stream, obj, obj.GetType(), PrefixStyle.Base128, fieldNumber, context);
	}

	protected T DeserializeWithLengthPrefix<T>(Stream stream, out long bytesRead, int expectedField = 1)
	{
		if (base.HeaderVersion < 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671686));
		}
		SerializationContext context = new SerializationContext
		{
			Context = this
		};
		return (T)base.Model.DeserializeWithLengthPrefix(stream, null, typeof(T), PrefixStyle.Base128, expectedField, null, out bytesRead, context);
	}

	protected object DeserializeWithLengthPrefix(Stream stream, Type objectType, out long bytesRead, int expectedField = 1)
	{
		if (base.HeaderVersion < 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671686));
		}
		SerializationContext context = new SerializationContext
		{
			Context = this
		};
		return base.Model.DeserializeWithLengthPrefix(stream, null, objectType, PrefixStyle.Base128, expectedField, null, out bytesRead, context);
	}

	protected T[] DeserializeAllItemsWithLengthPrefix<T>(Stream stream, int expectedField)
	{
		if (base.HeaderVersion < 0)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302671686));
		}
		SerializationContext context = new SerializationContext
		{
			Context = this
		};
		return base.Model.DeserializeItems<T>(stream, PrefixStyle.Base128, expectedField, context).ToArray();
	}

	internal void WriteHeader(FileHeader _0023_003Dz8Vwa6Pc_003D, Stream _0023_003DzdLqTRfo_003D)
	{
		SerializeHeaderWithLengthPrefix(_0023_003Dz8Vwa6Pc_003D, _0023_003DzdLqTRfo_003D);
	}

	internal FileHeader ReadHeader(Stream _0023_003DzdLqTRfo_003D)
	{
		DeserializeHeaderWithLengthPrefix(_0023_003DzdLqTRfo_003D);
		return FileHeader;
	}

	internal void WriteSingleObject<T>(Stream _0023_003DzdLqTRfo_003D, T _0023_003DzCX9Hbao_003D, int _0023_003DzfOwdbYDOgk2J = 1)
	{
		SerializeWithLengthPrefix(_0023_003DzdLqTRfo_003D, _0023_003DzCX9Hbao_003D, _0023_003DzfOwdbYDOgk2J);
	}

	internal object ReadSingleObject(Stream _0023_003DzdLqTRfo_003D, Type _0023_003Dzp23JzZM_003D, out long _0023_003DzVRsIQq4_003D, int _0023_003DzfOwdbYDOgk2J = 1)
	{
		return DeserializeWithLengthPrefix(_0023_003DzdLqTRfo_003D, _0023_003Dzp23JzZM_003D, out _0023_003DzVRsIQq4_003D, _0023_003DzfOwdbYDOgk2J);
	}

	internal T ReadSingleObject<T>(Stream _0023_003DzdLqTRfo_003D, out long _0023_003DzVRsIQq4_003D, int _0023_003DzfOwdbYDOgk2J = 1)
	{
		return DeserializeWithLengthPrefix<T>(_0023_003DzdLqTRfo_003D, out _0023_003DzVRsIQq4_003D, _0023_003DzfOwdbYDOgk2J);
	}

	internal T[] ReadAllObjects<T>(Stream _0023_003DzdLqTRfo_003D, int _0023_003DzfOwdbYDOgk2J = 1)
	{
		return DeserializeAllItemsWithLengthPrefix<T>(_0023_003DzdLqTRfo_003D, _0023_003DzfOwdbYDOgk2J);
	}

	internal void ResetCacheForLengthPrefix()
	{
		Serializer.ResetCache();
	}

	private void _0023_003DzLOHkBgBliNlDkoHDbk8mH10_003D()
	{
		base.HeaderVersion = Serializer.LastVersion;
		if (!ModelIsCompiled())
		{
			InitializeModel();
			CompileModel();
		}
	}

	internal Stream _0023_003DzotZ8WhHPfkb3UzUxtg_003D_003D(SketchEntity _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D)
	{
		_0023_003DzLOHkBgBliNlDkoHDbk8mH10_003D();
		Stream stream = new MemoryStream();
		try
		{
			SerializeWithLengthPrefix(stream, _0023_003Dzf6Dnw0TLItjk7UMC0g_003D_003D);
			return stream;
		}
		finally
		{
			Serializer.ResetCache();
		}
	}

	internal SketchEntity _0023_003DzIoWZ54SLqVMfg3dU_Q_003D_003D(Stream _0023_003DzdLqTRfo_003D)
	{
		_0023_003DzLOHkBgBliNlDkoHDbk8mH10_003D();
		_0023_003DzdLqTRfo_003D.Seek(0L, SeekOrigin.Begin);
		try
		{
			long bytesRead;
			return DeserializeWithLengthPrefix<SketchEntity>(_0023_003DzdLqTRfo_003D, out bytesRead);
		}
		finally
		{
			Serializer.ResetCache();
		}
	}

	internal static contentType _0023_003DziAPNcdKE4fVX(contentType _0023_003DzLunEVqUwkE2o, contentType _0023_003DznDO3kS8GZE3c)
	{
		return _0023_003DzLunEVqUwkE2o switch
		{
			contentType.Geometry => contentType.Geometry, 
			contentType.Tessellation => contentType.Tessellation, 
			contentType.GeometryAndTessellation => _0023_003DznDO3kS8GZE3c, 
			_ => throw new ArgumentOutOfRangeException(), 
		};
	}
}
