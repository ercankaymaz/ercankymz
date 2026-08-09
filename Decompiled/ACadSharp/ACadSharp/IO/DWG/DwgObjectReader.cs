using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using ACadSharp.Blocks;
using ACadSharp.Classes;
using ACadSharp.Entities;
using ACadSharp.IO.Templates;
using ACadSharp.Objects;
using ACadSharp.Objects.Evaluations;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;
using ACadSharp.Types.Units;
using ACadSharp.XData;
using CSMath;
using CSUtilities.Converters;

namespace ACadSharp.IO.DWG;

internal class DwgObjectReader : DwgSectionIO
{
	private long _objectInitialPos;

	private uint _size;

	private Queue<ulong> _handles;

	private readonly Dictionary<ulong, ObjectType> _readedObjects = new Dictionary<ulong, ObjectType>();

	private readonly Dictionary<ulong, long> _map;

	private readonly Dictionary<short, DxfClass> _classes;

	private DwgDocumentBuilder _builder;

	private readonly IDwgStreamReader _reader;

	private IDwgStreamReader _mergedReaders;

	private IDwgStreamReader _objectReader;

	private IDwgStreamReader _handlesReader;

	private IDwgStreamReader _textReader;

	private readonly IDwgStreamReader _crcReader;

	private readonly MemoryStream _memoryStream;

	public override string SectionName => "AcDb:AcDbObjects";

	public DwgObjectReader(ACadVersion version, DwgDocumentBuilder builder, IDwgStreamReader reader, Queue<ulong> handles, Dictionary<ulong, long> handleMap, DxfClassCollection classes)
		: base(version)
	{
		_builder = builder;
		_reader = reader;
		_handles = new Queue<ulong>(handles);
		_map = new Dictionary<ulong, long>(handleMap);
		_classes = classes.ToDictionary((DxfClass x) => x.ClassNumber, (DxfClass x) => x);
		if (_reader.Stream is MemoryStream memoryStream)
		{
			try
			{
				memoryStream.GetBuffer();
				_memoryStream = memoryStream;
			}
			catch
			{
			}
		}
		if (_memoryStream == null)
		{
			_memoryStream = HugeMemoryStream.Create(_reader.Stream.Length);
			_reader.Stream.Position = 0L;
			_reader.Stream.CopyTo(_memoryStream);
			_memoryStream.Position = 0L;
		}
		_crcReader = DwgStreamReaderBase.GetStreamHandler(_version, _memoryStream);
	}

	public void Read()
	{
		while (_handles.Any())
		{
			ulong num = _handles.Dequeue();
			if (!_map.TryGetValue(num, out var value) || _builder.TryGetObjectTemplate<CadTemplate>(num, out var _) || _readedObjects.ContainsKey(num))
			{
				continue;
			}
			ObjectType entityType = getEntityType(value);
			_readedObjects.Add(num, entityType);
			CadTemplate cadTemplate = null;
			try
			{
				cadTemplate = readObject(entityType);
			}
			catch (Exception exception)
			{
				if (!_builder.Configuration.Failsafe)
				{
					throw;
				}
				if (_classes.TryGetValue((short)entityType, out var value3))
				{
					_builder.Notify($"Could not read {value3.DxfName} number {value3.ClassNumber} with handle: {num}", NotificationType.Error, exception);
				}
				else
				{
					_builder.Notify($"Could not read {entityType} with handle: {num}", NotificationType.Error, exception);
				}
				continue;
			}
			if (cadTemplate != null)
			{
				_builder.AddTemplate(cadTemplate);
			}
		}
	}

	private ObjectType getEntityType(long offset)
	{
		ObjectType result = ObjectType.INVALID;
		_crcReader.Position = offset;
		_size = (uint)_crcReader.ReadModularShort();
		if (_size == 0)
		{
			return result;
		}
		uint num = _size << 3;
		if (R2010Plus)
		{
			ulong num2 = _crcReader.ReadModularChar();
			ulong num3 = (ulong)(_crcReader.PositionInBits() + num) - num2;
			_objectReader = DwgStreamReaderBase.GetStreamHandler(_version, HugeMemoryStream.Clone(_memoryStream), _reader.Encoding);
			_objectReader.SetPositionInBits(_crcReader.PositionInBits());
			_objectInitialPos = _objectReader.PositionInBits();
			result = _objectReader.ReadObjectType();
			_handlesReader = DwgStreamReaderBase.GetStreamHandler(_version, HugeMemoryStream.Clone(_memoryStream), _reader.Encoding);
			_handlesReader.SetPositionInBits((long)num3);
			_textReader = DwgStreamReaderBase.GetStreamHandler(_version, HugeMemoryStream.Clone(_memoryStream), _reader.Encoding);
			_textReader.SetPositionByFlag((long)(num3 - 1));
			_mergedReaders = new DwgMergedReader(_objectReader, _textReader, _handlesReader);
		}
		else
		{
			_objectReader = DwgStreamReaderBase.GetStreamHandler(_version, HugeMemoryStream.Clone(_memoryStream), _reader.Encoding);
			_objectReader.SetPositionInBits(_crcReader.PositionInBits());
			_handlesReader = DwgStreamReaderBase.GetStreamHandler(_version, HugeMemoryStream.Clone(_memoryStream), _reader.Encoding);
			_textReader = _objectReader;
			_objectInitialPos = _objectReader.PositionInBits();
			result = _objectReader.ReadObjectType();
		}
		return result;
	}

	private ulong handleReference()
	{
		return handleReference(0uL);
	}

	private ulong handleReference(ulong handle)
	{
		ulong num = _handlesReader.HandleReference(handle);
		if (num != 0L && !_builder.TryGetObjectTemplate<CadTemplate>(num, out var _) && !_readedObjects.ContainsKey(num))
		{
			_handles.Enqueue(num);
		}
		return num;
	}

	private void readCommonData(CadTemplate template)
	{
		if (_version >= ACadVersion.AC1015 && _version < ACadVersion.AC1024)
		{
			updateHandleReader();
		}
		template.CadObject.Handle = _objectReader.HandleReference();
		readExtendedData(template);
	}

	private void readCommonEntityData(CadEntityTemplate template)
	{
		_ = template.CadObject;
		readCommonData(template);
		if (_objectReader.ReadBit())
		{
			long num = ((_version >= ACadVersion.AC1024) ? _objectReader.ReadBitLongLong() : _objectReader.ReadRawLong());
			_objectReader.Advance((int)num);
		}
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1014)
		{
			updateHandleReader();
		}
		readEntityMode(template);
	}

	private void readEntityMode(CadEntityTemplate template)
	{
		Entity cadObject = template.CadObject;
		template.EntityMode = _objectReader.Read2Bits();
		if (template.EntityMode == 0)
		{
			template.OwnerHandle = _handlesReader.HandleReference(cadObject.Handle);
		}
		else if (template.EntityMode == 1)
		{
			_builder.PaperSpaceEntities.Add(cadObject);
		}
		else if (template.EntityMode == 2)
		{
			_builder.ModelSpaceEntities.Add(cadObject);
		}
		readReactorsAndDictionaryHandle(template);
		if (R13_14Only)
		{
			template.LayerHandle = handleReference();
			if (!_objectReader.ReadBit())
			{
				template.LineTypeHandle = handleReference();
			}
		}
		if (!R2004Plus && !_objectReader.ReadBit())
		{
			template.PrevEntity = handleReference(cadObject.Handle);
			template.NextEntity = handleReference(cadObject.Handle);
		}
		else if (!R2004Plus)
		{
			if (!_readedObjects.ContainsKey(cadObject.Handle - 1))
			{
				_handles.Enqueue(cadObject.Handle - 1);
			}
			if (!_readedObjects.ContainsKey(cadObject.Handle + 1))
			{
				_handles.Enqueue(cadObject.Handle + 1);
			}
		}
		cadObject.Color = _objectReader.ReadEnColor(out var transparency, out var flag);
		cadObject.Transparency = transparency;
		if (_version >= ACadVersion.AC1018 && flag)
		{
			template.ColorHandle = handleReference();
		}
		cadObject.LineTypeScale = _objectReader.ReadBitDouble();
		if (_version < ACadVersion.AC1015)
		{
			cadObject.IsInvisible = (_objectReader.ReadBitShort() & 1) == 0;
			return;
		}
		template.LayerHandle = handleReference();
		template.LtypeFlags = _objectReader.Read2Bits();
		if (template.LtypeFlags == 3)
		{
			template.LineTypeHandle = handleReference();
		}
		if (R2007Plus)
		{
			if (_objectReader.Read2Bits() == 3)
			{
				template.MaterialHandle = handleReference();
			}
			_objectReader.ReadByte();
		}
		if (_objectReader.Read2Bits() == 3)
		{
			handleReference();
		}
		if (R2010Plus)
		{
			if (_objectReader.ReadBit())
			{
				handleReference();
			}
			if (_objectReader.ReadBit())
			{
				handleReference();
			}
			if (_objectReader.ReadBit())
			{
				handleReference();
			}
		}
		cadObject.IsInvisible = (_objectReader.ReadBitShort() & 1) == 1;
		cadObject.LineWeight = CadUtils.ToValue(_objectReader.ReadByte());
	}

	private void readCommonNonEntityData(CadTemplate template)
	{
		readCommonData(template);
		if (R13_14Only)
		{
			updateHandleReader();
		}
		template.OwnerHandle = handleReference(template.CadObject.Handle);
		readReactorsAndDictionaryHandle(template);
	}

	private void readXrefDependantBit(TableEntry entry)
	{
		if (R2007Plus)
		{
			if ((_objectReader.ReadBitShort() & 0x100) != 0)
			{
				entry.Flags |= StandardFlags.XrefDependent;
			}
			return;
		}
		if (_objectReader.ReadBit())
		{
			entry.Flags |= StandardFlags.Referenced;
		}
		_objectReader.ReadBitShort();
		if (_objectReader.ReadBit())
		{
			entry.Flags |= StandardFlags.XrefDependent;
		}
	}

	private void readExtendedData(CadTemplate template)
	{
		for (short num = _objectReader.ReadBitShort(); num != 0; num = _objectReader.ReadBitShort())
		{
			ulong key = _objectReader.HandleReference();
			long endPos = _objectReader.Position + num;
			List<ExtendedDataRecord> value = readExtendedDataRecords(endPos);
			template.EDataTemplate.Add(key, value);
		}
	}

	private List<ExtendedDataRecord> readExtendedDataRecords(long endPos)
	{
		List<ExtendedDataRecord> list = new List<ExtendedDataRecord>();
		while (_objectReader.Position < endPos)
		{
			DxfCode dxfCode = (DxfCode)(1000 + _objectReader.ReadByte());
			ExtendedDataRecord extendedDataRecord = null;
			switch (dxfCode)
			{
			case DxfCode.ExtendedDataAsciiString:
			case DxfCode.ExtendedDataRegAppName:
				extendedDataRecord = new ExtendedDataString(_objectReader.ReadTextUnicode());
				break;
			case DxfCode.ExtendedDataControlString:
				extendedDataRecord = new ExtendedDataControlString(_objectReader.ReadByte() == 1);
				break;
			case DxfCode.ExtendedDataLayerName:
			{
				byte[] bytes = _objectReader.ReadBytes(8);
				extendedDataRecord = new ExtendedDataLayer(BigEndianConverter.Instance.ToUInt64(bytes));
				break;
			}
			case DxfCode.ExtendedDataBinaryChunk:
				extendedDataRecord = new ExtendedDataBinaryChunk(_objectReader.ReadBytes(_objectReader.ReadByte()));
				break;
			case DxfCode.ExtendedDataHandle:
			{
				byte[] bytes = _objectReader.ReadBytes(8);
				extendedDataRecord = new ExtendedDataHandle(BigEndianConverter.Instance.ToUInt64(bytes));
				break;
			}
			case DxfCode.ExtendedDataXCoordinate:
				extendedDataRecord = new ExtendedDataCoordinate(new XYZ(_objectReader.ReadDouble(), _objectReader.ReadDouble(), _objectReader.ReadDouble()));
				break;
			case DxfCode.ExtendedDataWorldXCoordinate:
				extendedDataRecord = new ExtendedDataWorldCoordinate(new XYZ(_objectReader.ReadDouble(), _objectReader.ReadDouble(), _objectReader.ReadDouble()));
				break;
			case DxfCode.ExtendedDataWorldXDisp:
				extendedDataRecord = new ExtendedDataDisplacement(new XYZ(_objectReader.ReadDouble(), _objectReader.ReadDouble(), _objectReader.ReadDouble()));
				break;
			case DxfCode.ExtendedDataWorldXDir:
				extendedDataRecord = new ExtendedDataDirection(new XYZ(_objectReader.ReadDouble(), _objectReader.ReadDouble(), _objectReader.ReadDouble()));
				break;
			case DxfCode.ExtendedDataReal:
				extendedDataRecord = new ExtendedDataReal(_objectReader.ReadDouble());
				break;
			case DxfCode.ExtendedDataDist:
				extendedDataRecord = new ExtendedDataDistance(_objectReader.ReadDouble());
				break;
			case DxfCode.ExtendedDataScale:
				extendedDataRecord = new ExtendedDataScale(_objectReader.ReadDouble());
				break;
			case DxfCode.ExtendedDataInteger16:
				extendedDataRecord = new ExtendedDataInteger16(_objectReader.ReadShort());
				break;
			case DxfCode.ExtendedDataInteger32:
				extendedDataRecord = new ExtendedDataInteger32((int)_objectReader.ReadRawLong());
				break;
			default:
				_objectReader.ReadBytes((int)(endPos - _objectReader.Position));
				_builder.Notify($"Unknown code for extended data: {dxfCode}", NotificationType.Warning);
				return list;
			}
			list.Add(extendedDataRecord);
		}
		return list;
	}

	private void readReactorsAndDictionaryHandle(CadTemplate template)
	{
		int num = _objectReader.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			template.ReactorsHandles.Add(handleReference());
		}
		bool flag = false;
		if (R2004Plus)
		{
			flag = _objectReader.ReadBit();
		}
		if (!flag)
		{
			template.XDictHandle = handleReference();
		}
		if (R2013Plus)
		{
			_objectReader.ReadBit();
		}
	}

	private void updateHandleReader()
	{
		long num = _objectReader.ReadRawLong();
		_handlesReader.SetPositionInBits(num + _objectInitialPos);
		if (_version == ACadVersion.AC1021)
		{
			_textReader = DwgStreamReaderBase.GetStreamHandler(_version, HugeMemoryStream.Clone(_memoryStream), _reader.Encoding);
			_textReader.SetPositionByFlag(num + _objectInitialPos - 1);
		}
		_mergedReaders = new DwgMergedReader(_objectReader, _textReader, _handlesReader);
	}

	private CadTemplate readObject(ObjectType type)
	{
		CadTemplate cadTemplate = null;
		switch (type)
		{
		case ObjectType.TEXT:
			cadTemplate = readText();
			break;
		case ObjectType.ATTRIB:
			cadTemplate = readAttribute();
			break;
		case ObjectType.ATTDEF:
			cadTemplate = readAttributeDefinition();
			break;
		case ObjectType.BLOCK:
			cadTemplate = readBlock();
			break;
		case ObjectType.ENDBLK:
			cadTemplate = readEndBlock();
			break;
		case ObjectType.SEQEND:
			cadTemplate = readSeqend();
			break;
		case ObjectType.INSERT:
			cadTemplate = readInsert();
			break;
		case ObjectType.MINSERT:
			cadTemplate = readMInsert();
			break;
		case ObjectType.VERTEX_2D:
			cadTemplate = readVertex2D();
			break;
		case ObjectType.VERTEX_3D:
			cadTemplate = readVertex3D(new Vertex3D());
			break;
		case ObjectType.VERTEX_PFACE:
			cadTemplate = readVertex3D(new VertexFaceMesh());
			break;
		case ObjectType.VERTEX_PFACE_FACE:
			cadTemplate = readPfaceVertex();
			break;
		case ObjectType.POLYLINE_2D:
			cadTemplate = readPolyline2D();
			break;
		case ObjectType.POLYLINE_3D:
			cadTemplate = readPolyline3D();
			break;
		case ObjectType.ARC:
			cadTemplate = readArc();
			break;
		case ObjectType.CIRCLE:
			cadTemplate = readCircle();
			break;
		case ObjectType.LINE:
			cadTemplate = readLine();
			break;
		case ObjectType.DIMENSION_ORDINATE:
			cadTemplate = readDimOrdinate();
			break;
		case ObjectType.DIMENSION_LINEAR:
			cadTemplate = readDimLinear();
			break;
		case ObjectType.DIMENSION_ALIGNED:
			cadTemplate = readDimAligned();
			break;
		case ObjectType.DIMENSION_ANG_3_Pt:
			cadTemplate = readDimAngular3pt();
			break;
		case ObjectType.DIMENSION_ANG_2_Ln:
			cadTemplate = readDimLine2pt();
			break;
		case ObjectType.DIMENSION_RADIUS:
			cadTemplate = readDimRadius();
			break;
		case ObjectType.DIMENSION_DIAMETER:
			cadTemplate = readDimDiameter();
			break;
		case ObjectType.POINT:
			cadTemplate = readPoint();
			break;
		case ObjectType.FACE3D:
			cadTemplate = read3dFace();
			break;
		case ObjectType.POLYLINE_PFACE:
			cadTemplate = readPolyfaceMesh();
			break;
		case ObjectType.POLYLINE_MESH:
			cadTemplate = readPolylineMesh();
			break;
		case ObjectType.SOLID:
		case ObjectType.TRACE:
			cadTemplate = readSolid();
			break;
		case ObjectType.SHAPE:
			cadTemplate = readShape();
			break;
		case ObjectType.VIEWPORT:
			cadTemplate = readViewport();
			break;
		case ObjectType.ELLIPSE:
			cadTemplate = readEllipse();
			break;
		case ObjectType.SPLINE:
			cadTemplate = readSpline();
			break;
		case ObjectType.REGION:
			cadTemplate = readModelerGeometry(new CadEntityTemplate<Region>());
			break;
		case ObjectType.SOLID3D:
			cadTemplate = readSolid3D();
			break;
		case ObjectType.BODY:
			cadTemplate = readModelerGeometry(new CadEntityTemplate<CadBody>());
			break;
		case ObjectType.RAY:
			cadTemplate = readRay();
			break;
		case ObjectType.XLINE:
			cadTemplate = readXLine();
			break;
		case ObjectType.DICTIONARY:
			cadTemplate = readDictionary();
			break;
		case ObjectType.MTEXT:
			cadTemplate = readMText();
			break;
		case ObjectType.LEADER:
			cadTemplate = readLeader();
			break;
		case ObjectType.TOLERANCE:
			cadTemplate = readTolerance();
			break;
		case ObjectType.MLINE:
			cadTemplate = readMLine();
			break;
		case ObjectType.BLOCK_CONTROL_OBJ:
			cadTemplate = readBlockControlObject();
			_builder.BlockRecords = (BlockRecordsTable)cadTemplate.CadObject;
			break;
		case ObjectType.BLOCK_HEADER:
			cadTemplate = readBlockHeader();
			break;
		case ObjectType.LAYER_CONTROL_OBJ:
			cadTemplate = readDocumentTable(new LayersTable());
			_builder.Layers = (LayersTable)cadTemplate.CadObject;
			break;
		case ObjectType.LAYER:
			cadTemplate = readLayer();
			break;
		case ObjectType.STYLE_CONTROL_OBJ:
			cadTemplate = readDocumentTable(new TextStylesTable());
			_builder.TextStyles = (TextStylesTable)cadTemplate.CadObject;
			break;
		case ObjectType.STYLE:
			cadTemplate = readTextStyle();
			break;
		case ObjectType.LTYPE_CONTROL_OBJ:
			cadTemplate = readLTypeControlObject();
			_builder.LineTypesTable = (LineTypesTable)cadTemplate.CadObject;
			break;
		case ObjectType.LTYPE:
			cadTemplate = readLType();
			break;
		case ObjectType.VIEW_CONTROL_OBJ:
			cadTemplate = readDocumentTable(new ViewsTable());
			_builder.Views = (ViewsTable)cadTemplate.CadObject;
			break;
		case ObjectType.VIEW:
			cadTemplate = readView();
			break;
		case ObjectType.UCS_CONTROL_OBJ:
			cadTemplate = readDocumentTable(new UCSTable());
			_builder.UCSs = (UCSTable)cadTemplate.CadObject;
			break;
		case ObjectType.UCS:
			cadTemplate = readUcs();
			break;
		case ObjectType.VPORT_CONTROL_OBJ:
			cadTemplate = readDocumentTable(new VPortsTable());
			_builder.VPorts = (VPortsTable)cadTemplate.CadObject;
			break;
		case ObjectType.VPORT:
			cadTemplate = readVPort();
			break;
		case ObjectType.APPID_CONTROL_OBJ:
			cadTemplate = readDocumentTable(new AppIdsTable());
			_builder.AppIds = (AppIdsTable)cadTemplate.CadObject;
			break;
		case ObjectType.APPID:
			cadTemplate = readAppId();
			break;
		case ObjectType.DIMSTYLE_CONTROL_OBJ:
			cadTemplate = readDocumentTable(new DimensionStylesTable());
			_builder.DimensionStyles = (DimensionStylesTable)cadTemplate.CadObject;
			break;
		case ObjectType.DIMSTYLE:
			cadTemplate = readDimStyle();
			break;
		case ObjectType.VP_ENT_HDR_CTRL_OBJ:
			cadTemplate = readViewportEntityControl();
			break;
		case ObjectType.VP_ENT_HDR:
			cadTemplate = readViewportEntityHeader();
			break;
		case ObjectType.GROUP:
			cadTemplate = readGroup();
			break;
		case ObjectType.MLINESTYLE:
			cadTemplate = readMLineStyle();
			break;
		case ObjectType.LWPOLYLINE:
			cadTemplate = readLWPolyline();
			break;
		case ObjectType.HATCH:
			cadTemplate = readHatch();
			break;
		case ObjectType.XRECORD:
			cadTemplate = readXRecord();
			break;
		case ObjectType.ACDBPLACEHOLDER:
			cadTemplate = readPlaceHolder();
			break;
		case ObjectType.LAYOUT:
			cadTemplate = readLayout();
			break;
		case ObjectType.ACAD_PROXY_ENTITY:
			cadTemplate = readProxyEntity();
			break;
		case ObjectType.ACAD_PROXY_OBJECT:
			cadTemplate = readProxyObject();
			break;
		case ObjectType.OLE2FRAME:
			cadTemplate = readOle2Frame();
			break;
		case ObjectType.VERTEX_MESH:
		case ObjectType.OLEFRAME:
		case ObjectType.DUMMY:
			cadTemplate = readUnknownEntity(null);
			_builder.Notify($"Unlisted object with DXF name {type} has been read as an UnknownEntity", NotificationType.Warning);
			return cadTemplate;
		case ObjectType.LONG_TRANSACTION:
		case ObjectType.VBA_PROJECT:
			cadTemplate = readUnknownNonGraphicalObject(null);
			_builder.Notify($"Unlisted object with DXF name {type} has been read as an UnknownNonGraphicalObject", NotificationType.Warning);
			return cadTemplate;
		default:
			return readUnlistedType((short)type);
		case ObjectType.UNDEFINED:
		case ObjectType.UNKNOW_9:
		case ObjectType.UNKNOW_36:
		case ObjectType.UNKNOW_37:
		case ObjectType.UNKNOW_3A:
		case ObjectType.UNKNOW_3B:
			break;
		}
		if (cadTemplate == null)
		{
			_builder.Notify($"Object type not implemented: {type}", NotificationType.NotImplemented);
		}
		return cadTemplate;
	}

	private CadTemplate readUnlistedType(short classNumber)
	{
		if (!_classes.TryGetValue(classNumber, out var value))
		{
			return null;
		}
		CadTemplate cadTemplate = null;
		switch (value.DxfName)
		{
		case "ACDBDICTIONARYWDFLT":
			cadTemplate = readDictionaryWithDefault();
			break;
		case "ACDBPLACEHOLDER":
			cadTemplate = readPlaceHolder();
			break;
		case "ACAD_TABLE":
			cadTemplate = readTableEntity();
			break;
		case "DBCOLOR":
			cadTemplate = readDbColor();
			break;
		case "DICTIONARYVAR":
			cadTemplate = readDictionaryVar();
			break;
		case "DICTIONARYWDFLT":
			cadTemplate = readDictionaryWithDefault();
			break;
		case "GEODATA":
			cadTemplate = readGeoData();
			break;
		case "GROUP":
			cadTemplate = readGroup();
			break;
		case "HATCH":
			cadTemplate = readHatch();
			break;
		case "IMAGE":
			cadTemplate = readCadImage(new RasterImage());
			break;
		case "IMAGEDEF":
			cadTemplate = readImageDefinition();
			break;
		case "IMAGEDEF_REACTOR":
			cadTemplate = readImageDefinitionReactor();
			break;
		case "LAYOUT":
			cadTemplate = readLayout();
			break;
		case "LWPOLYLINE":
		case "LWPLINE":
			cadTemplate = readLWPolyline();
			break;
		case "MATERIAL":
			cadTemplate = readMaterial();
			break;
		case "MESH":
			cadTemplate = readMesh();
			break;
		case "MULTILEADER":
			cadTemplate = readMultiLeader();
			break;
		case "ACDB_MLEADEROBJECTCONTEXTDATA_CLASS":
			cadTemplate = readMultiLeaderAnnotContext();
			break;
		case "MLEADERSTYLE":
			cadTemplate = readMultiLeaderStyle();
			break;
		case "PDFDEFINITION":
			cadTemplate = readPdfDefinition();
			break;
		case "PDFUNDERLAY":
		case "PDFREFERENCE":
			cadTemplate = readPdfUnderlay();
			break;
		case "SCALE":
			cadTemplate = readScale();
			break;
		case "SORTENTSTABLE":
			cadTemplate = readSortentsTable();
			break;
		case "RASTERVARIABLES":
			cadTemplate = readRasterVariables();
			break;
		case "WIPEOUT":
			cadTemplate = readCadImage(new Wipeout());
			break;
		case "XRECORD":
			cadTemplate = readXRecord();
			break;
		case "ACAD_EVALUATION_GRAPH":
			cadTemplate = readEvaluationGraph();
			break;
		case "BLOCKVISIBILITYPARAMETER":
			cadTemplate = readBlockVisibilityParameter();
			break;
		case "BLOCKFLIPPARAMETER":
			cadTemplate = readBlockFlipParameter();
			break;
		case "BLOCKFLIPACTION":
			cadTemplate = readBlockFlipAction();
			break;
		case "SPATIAL_FILTER":
			cadTemplate = readSpatialFilter();
			break;
		case "ACAD_PROXY_ENTITY":
			cadTemplate = readProxyEntity();
			break;
		case "ACAD_PROXY_OBJECT":
			cadTemplate = readProxyObject();
			break;
		case "VISUALSTYLE":
			cadTemplate = readVisualStyle();
			break;
		case "PLOTSETTINGS":
			cadTemplate = readPlotSettings();
			break;
		}
		if (cadTemplate == null && value.IsAnEntity)
		{
			cadTemplate = readUnknownEntity(value);
			_builder.Notify("Unlisted object with DXF name " + value.DxfName + " has been read as an UnknownEntity", NotificationType.Warning);
		}
		else if (cadTemplate == null && !value.IsAnEntity)
		{
			cadTemplate = readUnknownNonGraphicalObject(value);
			_builder.Notify("Unlisted object with DXF name " + value.DxfName + " has been read as an UnknownNonGraphicalObject", NotificationType.Warning);
		}
		return cadTemplate;
	}

	private CadTemplate readEvaluationGraph()
	{
		EvaluationGraph evaluationGraph = new EvaluationGraph();
		CadEvaluationGraphTemplate cadEvaluationGraphTemplate = new CadEvaluationGraphTemplate(evaluationGraph);
		readCommonNonEntityData(cadEvaluationGraphTemplate);
		evaluationGraph.Value96 = _objectReader.ReadBitLong();
		evaluationGraph.Value97 = _objectReader.ReadBitLong();
		int num = _objectReader.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			CadEvaluationGraphTemplate.GraphNodeTemplate graphNodeTemplate = new CadEvaluationGraphTemplate.GraphNodeTemplate();
			EvaluationGraph.Node node = new EvaluationGraph.Node();
			cadEvaluationGraphTemplate.NodeTemplates.Add(graphNodeTemplate);
			node.Index = _objectReader.ReadBitLong();
			node.Flags = _objectReader.ReadBitLong();
			node.NextNodeIndex = _objectReader.ReadBitLong();
			graphNodeTemplate.ExpressionHandle = handleReference();
			node.Data1 = _objectReader.ReadBitLong();
			node.Data2 = _objectReader.ReadBitLong();
			node.Data3 = _objectReader.ReadBitLong();
			node.Data4 = _objectReader.ReadBitLong();
		}
		int num2 = _objectReader.ReadBitLong();
		for (int j = 0; j < num2; j++)
		{
			_objectReader.ReadBitLong();
			_objectReader.ReadBitLong();
			_objectReader.ReadBitLong();
			_objectReader.ReadBitLong();
			_objectReader.ReadBitLong();
			_objectReader.ReadBitLong();
			_objectReader.ReadBitLong();
			_objectReader.ReadBitLong();
			_objectReader.ReadBitLong();
			_objectReader.ReadBitLong();
		}
		return cadEvaluationGraphTemplate;
	}

	private void readEvaluationExpression(CadEvaluationExpressionTemplate template)
	{
		readCommonNonEntityData(template);
		_objectReader.ReadBitLong();
		template.CadObject.Value98 = _objectReader.ReadBitLong();
		template.CadObject.Value99 = _objectReader.ReadBitLong();
		_mergedReaders.ReadBitShort();
		template.CadObject.Value90 = _objectReader.ReadBitLong();
	}

	private void readBlockElement(CadBlockElementTemplate template)
	{
		readEvaluationExpression(template);
		template.BlockElement.ElementName = _mergedReaders.ReadVariableText();
		template.BlockElement.Value98 = _mergedReaders.ReadBitLong();
		template.BlockElement.Value99 = _mergedReaders.ReadBitLong();
		template.BlockElement.Value1071 = _mergedReaders.ReadBitLong();
	}

	private void readBlockParameter(CadBlockParameterTemplate template)
	{
		readBlockElement(template);
		template.BlockParameter.Value280 = _mergedReaders.ReadBit();
		template.BlockParameter.Value281 = _mergedReaders.ReadBit();
	}

	private void readBlock1PtParameter(CadBlock1PtParameterTemplate template)
	{
		readBlockParameter(template);
		template.Block1PtParameter.Location = _mergedReaders.Read3BitDouble();
		template.Block1PtParameter.Value170 = _mergedReaders.ReadBitShort();
		template.Block1PtParameter.Value171 = _mergedReaders.ReadBitShort();
		template.Block1PtParameter.Value93 = _mergedReaders.ReadBitLong();
	}

	private CadTemplate readBlockVisibilityParameter()
	{
		BlockVisibilityParameter blockVisibilityParameter = new BlockVisibilityParameter();
		CadBlockVisibilityParameterTemplate cadBlockVisibilityParameterTemplate = new CadBlockVisibilityParameterTemplate(blockVisibilityParameter);
		readBlock1PtParameter(cadBlockVisibilityParameterTemplate);
		blockVisibilityParameter.Value281 = _mergedReaders.ReadBit();
		blockVisibilityParameter.Name = _mergedReaders.ReadVariableText();
		blockVisibilityParameter.Description = _mergedReaders.ReadVariableText();
		blockVisibilityParameter.Value91 = _mergedReaders.ReadBit();
		int num = _objectReader.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			cadBlockVisibilityParameterTemplate.EntityHandles.Add(handleReference());
		}
		int num2 = _objectReader.ReadBitLong();
		for (int j = 0; j < num2; j++)
		{
			cadBlockVisibilityParameterTemplate.StateTemplates.Add(readState());
		}
		return cadBlockVisibilityParameterTemplate;
	}

	private CadBlockVisibilityParameterTemplate.StateTemplate readState()
	{
		CadBlockVisibilityParameterTemplate.StateTemplate stateTemplate = new CadBlockVisibilityParameterTemplate.StateTemplate();
		stateTemplate.State.Name = _textReader.ReadVariableText();
		int num = _objectReader.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			stateTemplate.SubSet1.Add(handleReference());
		}
		int num2 = _objectReader.ReadBitLong();
		for (int j = 0; j < num2; j++)
		{
			stateTemplate.SubSet2.Add(handleReference());
		}
		return stateTemplate;
	}

	private CadBlockActionTemplate readBlockAction(CadBlockActionTemplate template)
	{
		readBlockElement(template);
		BlockAction blockAction = template.BlockAction;
		blockAction.ActionPoint = _mergedReaders.Read3BitDouble();
		short num = _objectReader.ReadBitShort();
		for (int i = 0; i < num; i++)
		{
			ulong item = handleReference();
			template.EntityHandles.Add(item);
		}
		blockAction.Value70 = _mergedReaders.ReadBitShort();
		return template;
	}

	private CadTemplate readSpatialFilter()
	{
		SpatialFilter spatialFilter = new SpatialFilter();
		CadNonGraphicalObjectTemplate cadNonGraphicalObjectTemplate = new CadNonGraphicalObjectTemplate(spatialFilter);
		readCommonNonEntityData(cadNonGraphicalObjectTemplate);
		int num = _mergedReaders.ReadBitShort();
		for (int i = 0; i < num; i++)
		{
			spatialFilter.BoundaryPoints.Add(_mergedReaders.Read2RawDouble());
		}
		spatialFilter.Normal = _mergedReaders.Read3BitDouble();
		spatialFilter.Origin = _mergedReaders.Read3BitDouble();
		spatialFilter.DisplayBoundary = _mergedReaders.ReadBitShort() != 0;
		spatialFilter.ClipFrontPlane = _mergedReaders.ReadBitShort() != 0;
		if (spatialFilter.ClipFrontPlane)
		{
			spatialFilter.FrontDistance = _mergedReaders.ReadBitDouble();
		}
		spatialFilter.ClipBackPlane = _mergedReaders.ReadBitShort() != 0;
		if (spatialFilter.ClipBackPlane)
		{
			spatialFilter.BackDistance = _mergedReaders.ReadBitDouble();
		}
		spatialFilter.InverseInsertTransform = read4x3Matrix();
		spatialFilter.InsertTransform = read4x3Matrix();
		return cadNonGraphicalObjectTemplate;
	}

	private Matrix4 read4x3Matrix()
	{
		Matrix4 identity = Matrix4.Identity;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				identity[i, j] = _mergedReaders.ReadBitDouble();
			}
		}
		return identity;
	}

	private CadBlockFlipActionTemplate readBlockFlipAction()
	{
		BlockFlipAction blockFlipAction = new BlockFlipAction();
		CadBlockFlipActionTemplate cadBlockFlipActionTemplate = new CadBlockFlipActionTemplate(blockFlipAction);
		readBlockAction(cadBlockFlipActionTemplate);
		blockFlipAction.Value92 = _mergedReaders.ReadBitLong();
		blockFlipAction.Value93 = _mergedReaders.ReadBitLong();
		blockFlipAction.Value94 = _mergedReaders.ReadBitLong();
		blockFlipAction.Value95 = _mergedReaders.ReadBitLong();
		blockFlipAction.Caption301 = _mergedReaders.ReadVariableText();
		blockFlipAction.Caption302 = _mergedReaders.ReadVariableText();
		blockFlipAction.Caption303 = _mergedReaders.ReadVariableText();
		blockFlipAction.Caption304 = _mergedReaders.ReadVariableText();
		return cadBlockFlipActionTemplate;
	}

	private CadBlock2PtParameterTemplate readBlock2PtParameter(CadBlockFlipParameterTemplate template)
	{
		readBlockParameter(template);
		Block2PtParameter block2PtParameter = template.Block2PtParameter;
		block2PtParameter.FirstPoint = _mergedReaders.Read3BitDouble();
		block2PtParameter.SecondPoint = _mergedReaders.Read3BitDouble();
		_mergedReaders.ReadBitShort();
		_mergedReaders.ReadBitShort();
		_mergedReaders.ReadBitShort();
		_mergedReaders.ReadBitShort();
		_mergedReaders.ReadBitLong();
		_mergedReaders.ReadBitLong();
		_mergedReaders.ReadBitLong();
		_mergedReaders.ReadBitLong();
		_mergedReaders.ReadBitShort();
		return template;
	}

	private CadBlockFlipParameterTemplate readBlockFlipParameter()
	{
		BlockFlipParameter blockFlipParameter = new BlockFlipParameter();
		CadBlockFlipParameterTemplate cadBlockFlipParameterTemplate = new CadBlockFlipParameterTemplate(blockFlipParameter);
		readBlock2PtParameter(cadBlockFlipParameterTemplate);
		blockFlipParameter.Caption = _mergedReaders.ReadVariableText();
		blockFlipParameter.Description = _mergedReaders.ReadVariableText();
		blockFlipParameter.BaseStateName = _mergedReaders.ReadVariableText();
		blockFlipParameter.FlippedStateName = _mergedReaders.ReadVariableText();
		blockFlipParameter.CaptionLocation = _mergedReaders.Read3BitDouble();
		blockFlipParameter.Caption309 = _mergedReaders.ReadVariableText();
		blockFlipParameter.Value96 = _mergedReaders.ReadBitLong();
		return cadBlockFlipParameterTemplate;
	}

	private CadTemplate readUnknownEntity(DxfClass dxfClass)
	{
		CadUnknownEntityTemplate cadUnknownEntityTemplate = new CadUnknownEntityTemplate(new UnknownEntity(dxfClass));
		readCommonEntityData(cadUnknownEntityTemplate);
		return cadUnknownEntityTemplate;
	}

	private CadTemplate readUnknownNonGraphicalObject(DxfClass dxfClass)
	{
		CadUnknownNonGraphicalObjectTemplate cadUnknownNonGraphicalObjectTemplate = new CadUnknownNonGraphicalObjectTemplate(new UnknownNonGraphicalObject(dxfClass));
		readCommonNonEntityData(cadUnknownNonGraphicalObjectTemplate);
		return cadUnknownNonGraphicalObjectTemplate;
	}

	private CadTemplate readText()
	{
		CadTextEntityTemplate cadTextEntityTemplate = new CadTextEntityTemplate(new TextEntity());
		readCommonTextData(cadTextEntityTemplate);
		return cadTextEntityTemplate;
	}

	private CadTemplate readAttribute()
	{
		CadAttributeTemplate cadAttributeTemplate = new CadAttributeTemplate(new AttributeEntity());
		readCommonTextData(cadAttributeTemplate);
		readCommonAttData(cadAttributeTemplate);
		return cadAttributeTemplate;
	}

	private CadTemplate readAttributeDefinition()
	{
		AttributeDefinition attributeDefinition = new AttributeDefinition();
		CadAttributeTemplate cadAttributeTemplate = new CadAttributeTemplate(attributeDefinition);
		readCommonTextData(cadAttributeTemplate);
		readCommonAttData(cadAttributeTemplate);
		if (R2010Plus)
		{
			attributeDefinition.Version = _objectReader.ReadByte();
		}
		attributeDefinition.Prompt = _textReader.ReadVariableText();
		return cadAttributeTemplate;
	}

	private void readCommonTextData(CadTextEntityTemplate template)
	{
		readCommonEntityData(template);
		TextEntity textEntity = (TextEntity)template.CadObject;
		double z = 0.0;
		XY xY = default(XY);
		if (R13_14Only)
		{
			z = _objectReader.ReadBitDouble();
			xY = _objectReader.Read2RawDouble();
			textEntity.InsertPoint = new XYZ(xY.X, xY.Y, z);
			xY = _objectReader.Read2RawDouble();
			textEntity.AlignmentPoint = new XYZ(xY.X, xY.Y, z);
			textEntity.Normal = _objectReader.Read3BitDouble();
			textEntity.Thickness = _objectReader.ReadBitDouble();
			textEntity.ObliqueAngle = _objectReader.ReadBitDouble();
			textEntity.Rotation = _objectReader.ReadBitDouble();
			textEntity.Height = _objectReader.ReadBitDouble();
			textEntity.WidthFactor = _objectReader.ReadBitDouble();
			textEntity.Value = _textReader.ReadVariableText();
			textEntity.Mirror = (TextMirrorFlag)_objectReader.ReadBitShort();
			textEntity.HorizontalAlignment = (TextHorizontalAlignment)_objectReader.ReadBitShort();
			textEntity.VerticalAlignment = (TextVerticalAlignmentType)_objectReader.ReadBitShort();
			template.StyleHandle = handleReference();
			return;
		}
		byte num = _objectReader.ReadByte();
		if ((num & 1) == 0)
		{
			z = _objectReader.ReadDouble();
		}
		xY = _objectReader.Read2RawDouble();
		textEntity.InsertPoint = new XYZ(xY.X, xY.Y, z);
		if ((num & 2) == 0)
		{
			double x = _objectReader.ReadBitDoubleWithDefault(textEntity.InsertPoint.X);
			double y = _objectReader.ReadBitDoubleWithDefault(textEntity.InsertPoint.Y);
			textEntity.AlignmentPoint = new XYZ(x, y, z);
		}
		textEntity.Normal = _objectReader.ReadBitExtrusion();
		textEntity.Thickness = _objectReader.ReadBitThickness();
		if ((num & 4) == 0)
		{
			textEntity.ObliqueAngle = _objectReader.ReadDouble();
		}
		if ((num & 8) == 0)
		{
			textEntity.Rotation = _objectReader.ReadDouble();
		}
		textEntity.Height = _objectReader.ReadDouble();
		if ((num & 0x10) == 0)
		{
			textEntity.WidthFactor = _objectReader.ReadDouble();
		}
		textEntity.Value = _textReader.ReadVariableText();
		if ((num & 0x20) == 0)
		{
			textEntity.Mirror = (TextMirrorFlag)_objectReader.ReadBitShort();
		}
		if ((num & 0x40) == 0)
		{
			textEntity.HorizontalAlignment = (TextHorizontalAlignment)_objectReader.ReadBitShort();
		}
		if ((num & 0x80) == 0)
		{
			textEntity.VerticalAlignment = (TextVerticalAlignmentType)_objectReader.ReadBitShort();
		}
		template.StyleHandle = handleReference();
	}

	private void readCommonAttData(CadAttributeTemplate template)
	{
		AttributeBase attributeBase = template.CadObject as AttributeBase;
		if (R2010Plus)
		{
			attributeBase.Version = _objectReader.ReadByte();
		}
		if (R2018Plus)
		{
			attributeBase.AttributeType = (AttributeType)_objectReader.ReadByte();
		}
		AttributeType attributeType = attributeBase.AttributeType;
		if (attributeType == AttributeType.MultiLine || attributeType == AttributeType.ConstantMultiLine)
		{
			attributeBase.MText = new MText();
			CadTextEntityTemplate template2 = (template.MTextTemplate = new CadTextEntityTemplate(attributeBase.MText));
			readEntityMode(template2);
			readMText(template2, readCommonData: false);
			short num = _objectReader.ReadBitShort();
			if (num > 0)
			{
				_objectReader.ReadBytes(num);
				handleReference();
				_objectReader.ReadBitShort();
			}
		}
		attributeBase.Tag = _textReader.ReadVariableText();
		_objectReader.ReadBitShort();
		attributeBase.Flags = (AttributeFlags)_objectReader.ReadByte();
		if (R2007Plus)
		{
			attributeBase.IsReallyLocked = _objectReader.ReadBit();
		}
	}

	private CadTemplate readDocumentTable<T>(Table<T> table) where T : TableEntry
	{
		CadTableTemplate<T> template = new CadTableTemplate<T>(table);
		return readDocumentTable(template);
	}

	private CadTemplate readDocumentTable<T>(CadTableTemplate<T> template) where T : TableEntry
	{
		readCommonNonEntityData(template);
		int num = _objectReader.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			template.EntryHandles.Add(handleReference());
		}
		return template;
	}

	private CadTemplate readBlock()
	{
		Block block = new Block(new BlockRecord());
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(block);
		readCommonEntityData(cadEntityTemplate);
		string text = _textReader.ReadVariableText();
		if (!string.IsNullOrWhiteSpace(text))
		{
			block.Name = text;
		}
		return cadEntityTemplate;
	}

	private CadTemplate readEndBlock()
	{
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(new BlockEnd(new BlockRecord()));
		readCommonEntityData(cadEntityTemplate);
		return cadEntityTemplate;
	}

	private CadTemplate readSeqend()
	{
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(new Seqend());
		readCommonEntityData(cadEntityTemplate);
		return cadEntityTemplate;
	}

	private CadTemplate readInsert()
	{
		CadInsertTemplate cadInsertTemplate = new CadInsertTemplate(new Insert());
		readInsertCommonData(cadInsertTemplate);
		readInsertCommonHandles(cadInsertTemplate);
		return cadInsertTemplate;
	}

	private CadTemplate readMInsert()
	{
		Insert insert = new Insert();
		CadInsertTemplate cadInsertTemplate = new CadInsertTemplate(insert);
		readInsertCommonData(cadInsertTemplate);
		insert.ColumnCount = (ushort)_objectReader.ReadBitShort();
		insert.RowCount = (ushort)_objectReader.ReadBitShort();
		insert.ColumnSpacing = _objectReader.ReadBitDouble();
		insert.RowSpacing = _objectReader.ReadBitDouble();
		readInsertCommonHandles(cadInsertTemplate);
		return cadInsertTemplate;
	}

	private void readInsertCommonData(CadInsertTemplate template)
	{
		Insert insert = template.CadObject as Insert;
		readCommonEntityData(template);
		insert.InsertPoint = _objectReader.Read3BitDouble();
		if (R13_14Only)
		{
			XYZ xYZ = _objectReader.Read3BitDouble();
			insert.XScale = xYZ.X;
			insert.YScale = xYZ.Y;
			insert.ZScale = xYZ.Z;
		}
		if (R2000Plus)
		{
			switch (_objectReader.Read2Bits())
			{
			case 0:
				insert.XScale = _objectReader.ReadDouble();
				insert.YScale = _objectReader.ReadBitDoubleWithDefault(insert.XScale);
				insert.ZScale = _objectReader.ReadBitDoubleWithDefault(insert.XScale);
				break;
			case 1:
				insert.YScale = _objectReader.ReadBitDoubleWithDefault(insert.XScale);
				insert.ZScale = _objectReader.ReadBitDoubleWithDefault(insert.XScale);
				break;
			case 2:
			{
				double zScale = (insert.YScale = (insert.XScale = _objectReader.ReadDouble()));
				insert.ZScale = zScale;
				break;
			}
			case 3:
				insert.XScale = 1.0;
				insert.YScale = 1.0;
				insert.ZScale = 1.0;
				break;
			}
		}
		insert.Rotation = _objectReader.ReadBitDouble();
		insert.Normal = _objectReader.Read3BitDouble();
		template.HasAtts = _objectReader.ReadBit();
		template.OwnedObjectsCount = 0;
		if (R2004Plus && template.HasAtts)
		{
			template.OwnedObjectsCount = _objectReader.ReadBitLong();
		}
	}

	private void readInsertCommonHandles(CadInsertTemplate template)
	{
		template.BlockHeaderHandle = handleReference();
		if (!template.HasAtts)
		{
			return;
		}
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1015)
		{
			template.FirstAttributeHandle = handleReference();
			template.EndAttributeHandle = handleReference();
		}
		else if (R2004Plus)
		{
			for (int i = 0; i < template.OwnedObjectsCount; i++)
			{
				template.OwnedObjectsHandlers.Add(handleReference());
			}
		}
		template.SeqendHandle = handleReference();
	}

	private CadTemplate readVertex2D()
	{
		Vertex2D vertex2D = new Vertex2D();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(vertex2D);
		readCommonEntityData(cadEntityTemplate);
		vertex2D.Flags = (VertexFlags)_objectReader.ReadByte();
		vertex2D.Location = _objectReader.Read3BitDouble();
		double num = _objectReader.ReadBitDouble();
		if (num < 0.0)
		{
			vertex2D.StartWidth = 0.0 - num;
			vertex2D.EndWidth = 0.0 - num;
		}
		else
		{
			vertex2D.StartWidth = num;
			vertex2D.EndWidth = _objectReader.ReadBitDouble();
		}
		vertex2D.Bulge = _objectReader.ReadBitDouble();
		if (R2010Plus)
		{
			vertex2D.Id = _objectReader.ReadBitLong();
		}
		vertex2D.CurveTangent = _objectReader.ReadBitDouble();
		return cadEntityTemplate;
	}

	private CadTemplate readVertex3D(Vertex vertex)
	{
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(vertex);
		readCommonEntityData(cadEntityTemplate);
		vertex.Flags = (VertexFlags)_objectReader.ReadByte();
		vertex.Location = _objectReader.Read3BitDouble();
		return cadEntityTemplate;
	}

	private CadTemplate readPfaceVertex()
	{
		VertexFaceRecord vertexFaceRecord = new VertexFaceRecord();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(vertexFaceRecord);
		readCommonEntityData(cadEntityTemplate);
		vertexFaceRecord.Index1 = _objectReader.ReadBitShort();
		vertexFaceRecord.Index2 = _objectReader.ReadBitShort();
		vertexFaceRecord.Index3 = _objectReader.ReadBitShort();
		vertexFaceRecord.Index4 = _objectReader.ReadBitShort();
		return cadEntityTemplate;
	}

	private CadTemplate readPolyline2D()
	{
		Polyline2D polyline2D = new Polyline2D();
		CadPolyLineTemplate cadPolyLineTemplate = new CadPolyLineTemplate(polyline2D);
		readCommonEntityData(cadPolyLineTemplate);
		polyline2D.Flags = (PolylineFlags)_objectReader.ReadBitShort();
		polyline2D.SmoothSurface = (SmoothSurfaceType)_objectReader.ReadBitShort();
		polyline2D.StartWidth = _objectReader.ReadBitDouble();
		polyline2D.EndWidth = _objectReader.ReadBitDouble();
		polyline2D.Thickness = _objectReader.ReadBitThickness();
		polyline2D.Elevation = _objectReader.ReadBitDouble();
		polyline2D.Normal = _objectReader.ReadBitExtrusion();
		if (R2004Plus)
		{
			int num = _objectReader.ReadBitLong();
			for (int i = 0; i < num; i++)
			{
				cadPolyLineTemplate.OwnedObjectsHandlers.Add(handleReference());
			}
		}
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1015)
		{
			cadPolyLineTemplate.FirstVertexHandle = handleReference();
			cadPolyLineTemplate.LastVertexHandle = handleReference();
		}
		cadPolyLineTemplate.SeqendHandle = handleReference();
		return cadPolyLineTemplate;
	}

	private CadTemplate readPolyline3D()
	{
		Polyline3D polyline3D = new Polyline3D();
		CadPolyLineTemplate cadPolyLineTemplate = new CadPolyLineTemplate(polyline3D);
		readCommonEntityData(cadPolyLineTemplate);
		byte num = _objectReader.ReadByte();
		bool flag = (num & 1) != 0;
		bool flag2 = (num & 2) != 0;
		if (flag || flag2)
		{
			polyline3D.Flags |= PolylineFlags.SplineFit;
		}
		polyline3D.Flags |= PolylineFlags.Polyline3D;
		if ((_objectReader.ReadByte() & 1) != 0)
		{
			polyline3D.Flags |= PolylineFlags.ClosedPolylineOrClosedPolygonMeshInM;
		}
		if (R2004Plus)
		{
			int num2 = _objectReader.ReadBitLong();
			for (int i = 0; i < num2; i++)
			{
				cadPolyLineTemplate.OwnedObjectsHandlers.Add(handleReference());
			}
		}
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1015)
		{
			cadPolyLineTemplate.FirstVertexHandle = handleReference();
			cadPolyLineTemplate.LastVertexHandle = handleReference();
		}
		cadPolyLineTemplate.SeqendHandle = handleReference();
		return cadPolyLineTemplate;
	}

	private CadTemplate readArc()
	{
		Arc arc = new Arc();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(arc);
		readCommonEntityData(cadEntityTemplate);
		arc.Center = _objectReader.Read3BitDouble();
		double num = _objectReader.ReadBitDouble();
		if (num <= 0.0)
		{
			arc.Radius = 1E-12;
		}
		else
		{
			arc.Radius = num;
		}
		arc.Thickness = _objectReader.ReadBitThickness();
		arc.Normal = _objectReader.ReadBitExtrusion();
		arc.StartAngle = _objectReader.ReadBitDouble();
		arc.EndAngle = _objectReader.ReadBitDouble();
		return cadEntityTemplate;
	}

	private CadTemplate readCircle()
	{
		Circle circle = new Circle();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(circle);
		readCommonEntityData(cadEntityTemplate);
		circle.Center = _objectReader.Read3BitDouble();
		double num = _objectReader.ReadBitDouble();
		if (num <= 0.0)
		{
			circle.Radius = 1E-12;
		}
		else
		{
			circle.Radius = num;
		}
		circle.Thickness = _objectReader.ReadBitThickness();
		circle.Normal = _objectReader.ReadBitExtrusion();
		return cadEntityTemplate;
	}

	private CadTemplate readLine()
	{
		Line line = new Line();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(line);
		readCommonEntityData(cadEntityTemplate);
		if (R13_14Only)
		{
			line.StartPoint = _objectReader.Read3BitDouble();
			line.EndPoint = _objectReader.Read3BitDouble();
		}
		if (R2000Plus)
		{
			bool num = _objectReader.ReadBit();
			double num2 = _objectReader.ReadDouble();
			double x = _objectReader.ReadBitDoubleWithDefault(num2);
			double num3 = _objectReader.ReadDouble();
			double y = _objectReader.ReadBitDoubleWithDefault(num3);
			double num4 = 0.0;
			double z = 0.0;
			if (!num)
			{
				num4 = _objectReader.ReadDouble();
				z = _objectReader.ReadBitDoubleWithDefault(num4);
			}
			line.StartPoint = new XYZ(num2, num3, num4);
			line.EndPoint = new XYZ(x, y, z);
		}
		line.Thickness = _objectReader.ReadBitThickness();
		line.Normal = _objectReader.ReadBitExtrusion();
		return cadEntityTemplate;
	}

	private CadTemplate readDimOrdinate()
	{
		DimensionOrdinate dimensionOrdinate = new DimensionOrdinate();
		CadDimensionTemplate cadDimensionTemplate = new CadDimensionTemplate(dimensionOrdinate);
		readCommonDimensionData(cadDimensionTemplate);
		dimensionOrdinate.DefinitionPoint = _objectReader.Read3BitDouble();
		dimensionOrdinate.FeatureLocation = _objectReader.Read3BitDouble();
		dimensionOrdinate.LeaderEndpoint = _objectReader.Read3BitDouble();
		byte b = _objectReader.ReadByte();
		dimensionOrdinate.IsOrdinateTypeX = (b & 1) != 0;
		readCommonDimensionHandles(cadDimensionTemplate);
		return cadDimensionTemplate;
	}

	private CadTemplate readDimLinear()
	{
		DimensionLinear dimensionLinear = new DimensionLinear();
		CadDimensionTemplate cadDimensionTemplate = new CadDimensionTemplate(dimensionLinear);
		readCommonDimensionData(cadDimensionTemplate);
		readCommonDimensionAlignedData(cadDimensionTemplate);
		dimensionLinear.Rotation = _objectReader.ReadBitDouble();
		readCommonDimensionHandles(cadDimensionTemplate);
		return cadDimensionTemplate;
	}

	private CadTemplate readDimAligned()
	{
		CadDimensionTemplate cadDimensionTemplate = new CadDimensionTemplate(new DimensionAligned());
		readCommonDimensionData(cadDimensionTemplate);
		readCommonDimensionAlignedData(cadDimensionTemplate);
		readCommonDimensionHandles(cadDimensionTemplate);
		return cadDimensionTemplate;
	}

	private CadTemplate readDimAngular3pt()
	{
		DimensionAngular3Pt dimensionAngular3Pt = new DimensionAngular3Pt();
		CadDimensionTemplate cadDimensionTemplate = new CadDimensionTemplate(dimensionAngular3Pt);
		readCommonDimensionData(cadDimensionTemplate);
		dimensionAngular3Pt.DefinitionPoint = _objectReader.Read3BitDouble();
		dimensionAngular3Pt.FirstPoint = _objectReader.Read3BitDouble();
		dimensionAngular3Pt.SecondPoint = _objectReader.Read3BitDouble();
		dimensionAngular3Pt.AngleVertex = _objectReader.Read3BitDouble();
		readCommonDimensionHandles(cadDimensionTemplate);
		return cadDimensionTemplate;
	}

	private CadTemplate readDimLine2pt()
	{
		DimensionAngular2Line dimensionAngular2Line = new DimensionAngular2Line();
		CadDimensionTemplate cadDimensionTemplate = new CadDimensionTemplate(dimensionAngular2Line);
		readCommonDimensionData(cadDimensionTemplate);
		XY xY = _objectReader.Read2RawDouble();
		dimensionAngular2Line.DimensionArc = new XYZ(xY.X, xY.Y, dimensionAngular2Line.TextMiddlePoint.Z);
		dimensionAngular2Line.FirstPoint = _objectReader.Read3BitDouble();
		dimensionAngular2Line.SecondPoint = _objectReader.Read3BitDouble();
		dimensionAngular2Line.AngleVertex = _objectReader.Read3BitDouble();
		dimensionAngular2Line.DefinitionPoint = _objectReader.Read3BitDouble();
		readCommonDimensionHandles(cadDimensionTemplate);
		return cadDimensionTemplate;
	}

	private CadTemplate readDimRadius()
	{
		DimensionRadius dimensionRadius = new DimensionRadius();
		CadDimensionTemplate cadDimensionTemplate = new CadDimensionTemplate(dimensionRadius);
		readCommonDimensionData(cadDimensionTemplate);
		dimensionRadius.DefinitionPoint = _objectReader.Read3BitDouble();
		dimensionRadius.AngleVertex = _objectReader.Read3BitDouble();
		dimensionRadius.LeaderLength = _objectReader.ReadBitDouble();
		readCommonDimensionHandles(cadDimensionTemplate);
		return cadDimensionTemplate;
	}

	private CadTemplate readDimDiameter()
	{
		DimensionDiameter dimensionDiameter = new DimensionDiameter();
		CadDimensionTemplate cadDimensionTemplate = new CadDimensionTemplate(dimensionDiameter);
		readCommonDimensionData(cadDimensionTemplate);
		dimensionDiameter.DefinitionPoint = _objectReader.Read3BitDouble();
		dimensionDiameter.AngleVertex = _objectReader.Read3BitDouble();
		dimensionDiameter.LeaderLength = _objectReader.ReadBitDouble();
		readCommonDimensionHandles(cadDimensionTemplate);
		return cadDimensionTemplate;
	}

	private void readCommonDimensionData(CadDimensionTemplate template)
	{
		readCommonEntityData(template);
		Dimension dimension = template.CadObject as Dimension;
		if (R2010Plus)
		{
			dimension.Version = _objectReader.ReadByte();
		}
		dimension.Normal = _objectReader.Read3BitDouble();
		XY xY = _objectReader.Read2RawDouble();
		double z = _objectReader.ReadBitDouble();
		dimension.TextMiddlePoint = new XYZ(xY.X, xY.Y, z);
		byte b = _objectReader.ReadByte();
		dimension.IsTextUserDefinedLocation = (b & 1) == 0;
		dimension.Text = _textReader.ReadVariableText();
		dimension.TextRotation = _objectReader.ReadBitDouble();
		dimension.HorizontalDirection = _objectReader.ReadBitDouble();
		new XYZ(_objectReader.ReadBitDouble(), _objectReader.ReadBitDouble(), _objectReader.ReadBitDouble());
		_objectReader.ReadBitDouble();
		if (R2000Plus)
		{
			dimension.AttachmentPoint = (AttachmentPointType)_objectReader.ReadBitShort();
			dimension.LineSpacingStyle = (LineSpacingStyleType)_objectReader.ReadBitShort();
			dimension.LineSpacingFactor = _objectReader.ReadBitDouble();
			_objectReader.ReadBitDouble();
		}
		if (R2007Plus)
		{
			_objectReader.ReadBit();
			dimension.FlipArrow1 = _objectReader.ReadBit();
			dimension.FlipArrow2 = _objectReader.ReadBit();
		}
		XY xY2 = _objectReader.Read2RawDouble();
		dimension.InsertionPoint = new XYZ(xY2.X, xY2.Y, z);
	}

	private void readCommonDimensionAlignedData(CadDimensionTemplate template)
	{
		DimensionAligned obj = (DimensionAligned)template.CadObject;
		obj.FirstPoint = _objectReader.Read3BitDouble();
		obj.SecondPoint = _objectReader.Read3BitDouble();
		obj.DefinitionPoint = _objectReader.Read3BitDouble();
		obj.ExtLineRotation = _objectReader.ReadBitDouble();
	}

	[Obsolete("Can be moved to the common dimension data")]
	private void readCommonDimensionHandles(CadDimensionTemplate template)
	{
		template.StyleHandle = handleReference();
		template.BlockHandle = handleReference();
	}

	private CadTemplate readPoint()
	{
		Point point = new Point();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(point);
		readCommonEntityData(cadEntityTemplate);
		point.Location = _objectReader.Read3BitDouble();
		point.Thickness = _objectReader.ReadBitThickness();
		point.Normal = _objectReader.ReadBitExtrusion();
		point.Rotation = _objectReader.ReadBitDouble();
		return cadEntityTemplate;
	}

	private CadTemplate read3dFace()
	{
		Face3D face3D = new Face3D();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(face3D);
		readCommonEntityData(cadEntityTemplate);
		if (R13_14Only)
		{
			face3D.FirstCorner = _objectReader.Read3BitDouble();
			face3D.SecondCorner = _objectReader.Read3BitDouble();
			face3D.ThirdCorner = _objectReader.Read3BitDouble();
			face3D.FourthCorner = _objectReader.Read3BitDouble();
			face3D.Flags = (InvisibleEdgeFlags)_objectReader.ReadBitShort();
		}
		if (R2000Plus)
		{
			bool num = _objectReader.ReadBit();
			bool num2 = _objectReader.ReadBit();
			double x = _objectReader.ReadDouble();
			double y = _objectReader.ReadDouble();
			double z = 0.0;
			if (!num2)
			{
				z = _objectReader.ReadDouble();
			}
			face3D.FirstCorner = new XYZ(x, y, z);
			face3D.SecondCorner = _objectReader.Read3BitDoubleWithDefault(face3D.FirstCorner);
			face3D.ThirdCorner = _objectReader.Read3BitDoubleWithDefault(face3D.SecondCorner);
			face3D.FourthCorner = _objectReader.Read3BitDoubleWithDefault(face3D.ThirdCorner);
			if (!num)
			{
				face3D.Flags = (InvisibleEdgeFlags)_objectReader.ReadBitShort();
			}
		}
		return cadEntityTemplate;
	}

	private CadTemplate readPolyfaceMesh()
	{
		CadPolyfaceMeshTemplate cadPolyfaceMeshTemplate = new CadPolyfaceMeshTemplate(new PolyfaceMesh());
		readCommonEntityData(cadPolyfaceMeshTemplate);
		_objectReader.ReadBitShort();
		_objectReader.ReadBitShort();
		if (R2004Plus)
		{
			int num = _objectReader.ReadBitLong();
			for (int i = 0; i < num; i++)
			{
				cadPolyfaceMeshTemplate.VerticesHandles.Add(handleReference());
			}
		}
		if (R13_15Only)
		{
			cadPolyfaceMeshTemplate.FirstVerticeHandle = handleReference();
			cadPolyfaceMeshTemplate.LastVerticeHandle = handleReference();
		}
		cadPolyfaceMeshTemplate.SeqendHandle = handleReference();
		return cadPolyfaceMeshTemplate;
	}

	private CadTemplate readPolylineMesh()
	{
		return null;
	}

	private CadTemplate readSolid()
	{
		Solid solid = new Solid();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(solid);
		readCommonEntityData(cadEntityTemplate);
		solid.Thickness = _objectReader.ReadBitThickness();
		double z = _objectReader.ReadBitDouble();
		XY xY = _objectReader.Read2RawDouble();
		solid.FirstCorner = new XYZ(xY.X, xY.Y, z);
		XY xY2 = _objectReader.Read2RawDouble();
		solid.SecondCorner = new XYZ(xY2.X, xY2.Y, z);
		XY xY3 = _objectReader.Read2RawDouble();
		solid.ThirdCorner = new XYZ(xY3.X, xY3.Y, z);
		XY xY4 = _objectReader.Read2RawDouble();
		solid.FourthCorner = new XYZ(xY4.X, xY4.Y, z);
		solid.Normal = _objectReader.ReadBitExtrusion();
		return cadEntityTemplate;
	}

	private CadTemplate readShape()
	{
		Shape shape = new Shape();
		CadShapeTemplate cadShapeTemplate = new CadShapeTemplate(shape);
		readCommonEntityData(cadShapeTemplate);
		shape.InsertionPoint = _objectReader.Read3BitDouble();
		shape.Size = _objectReader.ReadBitDouble();
		shape.Rotation = _objectReader.ReadBitDouble();
		shape.RelativeXScale = _objectReader.ReadBitDouble();
		shape.ObliqueAngle = _objectReader.ReadBitDouble();
		shape.Thickness = _objectReader.ReadBitDouble();
		shape.ShapeIndex = (ushort)_objectReader.ReadBitShort();
		shape.Normal = _objectReader.Read3BitDouble();
		cadShapeTemplate.ShapeFileHandle = handleReference();
		return cadShapeTemplate;
	}

	private CadTemplate readViewport()
	{
		Viewport viewport = new Viewport();
		CadViewportTemplate cadViewportTemplate = new CadViewportTemplate(viewport);
		readCommonEntityData(cadViewportTemplate);
		viewport.Center = _objectReader.Read3BitDouble();
		viewport.Width = _objectReader.ReadBitDouble();
		viewport.Height = _objectReader.ReadBitDouble();
		if (R2000Plus)
		{
			viewport.ViewTarget = _objectReader.Read3BitDouble();
			viewport.ViewDirection = _objectReader.Read3BitDouble();
			viewport.TwistAngle = _objectReader.ReadBitDouble();
			viewport.ViewHeight = _objectReader.ReadBitDouble();
			viewport.LensLength = _objectReader.ReadBitDouble();
			viewport.FrontClipPlane = _objectReader.ReadBitDouble();
			viewport.BackClipPlane = _objectReader.ReadBitDouble();
			viewport.SnapAngle = _objectReader.ReadBitDouble();
			viewport.ViewCenter = _objectReader.Read2RawDouble();
			viewport.SnapBase = _objectReader.Read2RawDouble();
			viewport.SnapSpacing = _objectReader.Read2RawDouble();
			viewport.GridSpacing = _objectReader.Read2RawDouble();
			viewport.CircleZoomPercent = _objectReader.ReadBitShort();
		}
		if (R2007Plus)
		{
			viewport.MajorGridLineFrequency = _objectReader.ReadBitShort();
		}
		int num = 0;
		if (R2000Plus)
		{
			num = _objectReader.ReadBitLong();
			viewport.Status = (ViewportStatusFlags)_objectReader.ReadBitLong();
			viewport.StyleSheetName = _textReader.ReadVariableText();
			viewport.RenderMode = (RenderMode)_objectReader.ReadByte();
			viewport.DisplayUcsIcon = _objectReader.ReadBit();
			viewport.UcsPerViewport = _objectReader.ReadBit();
			viewport.UcsOrigin = _objectReader.Read3BitDouble();
			viewport.UcsXAxis = _objectReader.Read3BitDouble();
			viewport.UcsYAxis = _objectReader.Read3BitDouble();
			viewport.Elevation = _objectReader.ReadBitDouble();
			viewport.UcsOrthographicType = (OrthographicType)_objectReader.ReadBitShort();
		}
		if (R2004Plus)
		{
			viewport.ShadePlotMode = (ShadePlotMode)_objectReader.ReadBitShort();
		}
		if (R2007Plus)
		{
			viewport.UseDefaultLighting = _objectReader.ReadBit();
			viewport.DefaultLightingType = (LightingType)_objectReader.ReadByte();
			viewport.Brightness = _objectReader.ReadBitDouble();
			viewport.Contrast = _objectReader.ReadBitDouble();
			viewport.AmbientLightColor = _objectReader.ReadCmColor();
		}
		if (R13_14Only)
		{
			cadViewportTemplate.ViewportHeaderHandle = handleReference();
		}
		if (R2000Plus)
		{
			for (int i = 0; i < num; i++)
			{
				cadViewportTemplate.FrozenLayerHandles.Add(handleReference());
			}
			cadViewportTemplate.BoundaryHandle = handleReference();
		}
		if (_version == ACadVersion.AC1015)
		{
			cadViewportTemplate.ViewportHeaderHandle = handleReference();
		}
		if (R2000Plus)
		{
			cadViewportTemplate.NamedUcsHandle = handleReference();
			cadViewportTemplate.BaseUcsHandle = handleReference();
		}
		if (R2007Plus)
		{
			handleReference();
			handleReference();
			handleReference();
			handleReference();
		}
		return cadViewportTemplate;
	}

	private CadTemplate readEllipse()
	{
		Ellipse ellipse = new Ellipse();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(ellipse);
		readCommonEntityData(cadEntityTemplate);
		ellipse.Center = _objectReader.Read3BitDouble();
		ellipse.MajorAxisEndPoint = _objectReader.Read3BitDouble();
		ellipse.Normal = _objectReader.Read3BitDouble();
		ellipse.RadiusRatio = _objectReader.ReadBitDouble();
		ellipse.StartParameter = _objectReader.ReadBitDouble();
		ellipse.EndParameter = _objectReader.ReadBitDouble();
		return cadEntityTemplate;
	}

	private CadTemplate readSpline()
	{
		Spline spline = new Spline();
		CadSplineTemplate cadSplineTemplate = new CadSplineTemplate(spline);
		readCommonEntityData(cadSplineTemplate);
		int num = _objectReader.ReadBitLong();
		if (R2013Plus)
		{
			spline.Flags1 = (SplineFlags1)_mergedReaders.ReadBitLong();
			spline.IsClosed = spline.Flags1.HasFlag(SplineFlags1.Closed);
			spline.KnotParametrization = (KnotParametrization)_mergedReaders.ReadBitLong();
			num = ((spline.KnotParametrization == KnotParametrization.Custom || (spline.Flags1 & SplineFlags1.UseKnotParameter) == 0) ? 1 : 2);
		}
		else if (num == 2)
		{
			spline.Flags1 |= SplineFlags1.MethodFitPoints;
		}
		else
		{
			spline.KnotParametrization = KnotParametrization.Custom;
		}
		spline.Degree = _objectReader.ReadBitLong();
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		bool flag = false;
		switch (num)
		{
		case 1:
			if (_objectReader.ReadBit())
			{
				spline.Flags |= SplineFlags.Rational;
			}
			if (_objectReader.ReadBit())
			{
				spline.Flags |= SplineFlags.Closed;
			}
			if (_objectReader.ReadBit())
			{
				spline.Flags |= SplineFlags.Periodic;
			}
			spline.KnotTolerance = _objectReader.ReadBitDouble();
			spline.ControlPointTolerance = _objectReader.ReadBitDouble();
			num3 = _objectReader.ReadBitLong();
			num4 = _objectReader.ReadBitLong();
			flag = _objectReader.ReadBit();
			break;
		case 2:
			spline.FitTolerance = _objectReader.ReadBitDouble();
			spline.StartTangent = _objectReader.Read3BitDouble();
			spline.EndTangent = _objectReader.Read3BitDouble();
			num2 = _objectReader.ReadBitLong();
			break;
		}
		for (int i = 0; i < num3; i++)
		{
			spline.Knots.Add(_objectReader.ReadBitDouble());
		}
		for (int j = 0; j < num4; j++)
		{
			spline.ControlPoints.Add(_objectReader.Read3BitDouble());
			if (flag)
			{
				spline.Weights.Add(_objectReader.ReadBitDouble());
			}
		}
		for (int k = 0; k < num2; k++)
		{
			spline.FitPoints.Add(_objectReader.Read3BitDouble());
		}
		return cadSplineTemplate;
	}

	private CadTemplate readSolid3D()
	{
		CadSolid3DTemplate cadSolid3DTemplate = new CadSolid3DTemplate(new Solid3D());
		readModelerGeometry(cadSolid3DTemplate);
		if (R2007Plus)
		{
			cadSolid3DTemplate.HistoryHandle = _mergedReaders.HandleReference();
		}
		return cadSolid3DTemplate;
	}

	private CadEntityTemplate<T> readModelerGeometry<T>(CadEntityTemplate<T> template) where T : ModelerGeometry, new()
	{
		ModelerGeometry cadObject = template.CadObject;
		readCommonEntityData(template);
		if (!R2013Plus && !_mergedReaders.ReadBit())
		{
			readModelerGeometryData(template);
			return template;
		}
		if (_mergedReaders.ReadBit())
		{
			if (_mergedReaders.ReadBit())
			{
				cadObject.Point = _objectReader.Read3BitDouble();
			}
			_mergedReaders.ReadBitLong();
			if (_mergedReaders.ReadBit())
			{
				int num = _mergedReaders.ReadBitLong();
				for (int i = 0; i < num; i++)
				{
					ModelerGeometry.Wire wire = new ModelerGeometry.Wire();
					readWire(wire);
					cadObject.Wires.Add(wire);
				}
			}
			int num2 = _mergedReaders.ReadBitLong();
			for (int j = 0; j < num2; j++)
			{
				ModelerGeometry.Silhouette silhouette = new ModelerGeometry.Silhouette();
				silhouette.ViewportId = _mergedReaders.ReadBitLongLong();
				silhouette.ViewportTarget = _mergedReaders.Read3BitDouble();
				silhouette.ViewportDirectionFromTarget = _mergedReaders.Read3BitDouble();
				silhouette.ViewportUpDirection = _mergedReaders.Read3BitDouble();
				silhouette.ViewportPerspective = _mergedReaders.ReadBit();
				if (_mergedReaders.ReadBit())
				{
					int num3 = _mergedReaders.ReadBitLong();
					for (int k = 0; k < num3; k++)
					{
						ModelerGeometry.Wire wire2 = new ModelerGeometry.Wire();
						readWire(wire2);
						silhouette.Wires.Add(wire2);
					}
				}
				cadObject.Silhouettes.Add(silhouette);
			}
			if (!_mergedReaders.ReadBit())
			{
				readModelerGeometryData(template);
				return template;
			}
		}
		if (R2007Plus)
		{
			_mergedReaders.ReadBitLong();
		}
		return template;
	}

	private void readWire(ModelerGeometry.Wire wire)
	{
		wire.Type = _mergedReaders.ReadByte();
		wire.SelectionMarker = _mergedReaders.ReadBitLong();
		short num = _mergedReaders.ReadBitShort();
		num = (short)((num > 256) ? 256 : num);
		wire.Color = new Color(num);
		wire.AcisIndex = _mergedReaders.ReadBitLong();
		uint num2 = (uint)_mergedReaders.ReadBitLong();
		for (int i = 0; i < num2; i++)
		{
			wire.Points.Add(_mergedReaders.Read3BitDouble());
		}
		wire.ApplyTransformPresent = _mergedReaders.ReadBit();
		if (wire.ApplyTransformPresent)
		{
			wire.XAxis = _mergedReaders.Read3BitDouble();
			wire.YAxis = _mergedReaders.Read3BitDouble();
			wire.ZAxis = _mergedReaders.Read3BitDouble();
			wire.Translation = _mergedReaders.Read3BitDouble();
			wire.Scale = _mergedReaders.ReadBitDouble();
			wire.HasRotation = _mergedReaders.ReadBit();
			wire.HasReflection = _mergedReaders.ReadBit();
			wire.HasShear = _mergedReaders.ReadBit();
		}
	}

	private void readModelerGeometryData<T>(CadEntityTemplate<T> template) where T : ModelerGeometry, new()
	{
		_mergedReaders.ReadBit();
		short num = _mergedReaders.ReadBitShort();
		if (num != 1)
		{
			_ = 2;
		}
		notify("Stream data reader hasn't been implemented for " + template.CadObject.ObjectName, NotificationType.NotImplemented);
	}

	private CadTemplate readRay()
	{
		Ray ray = new Ray();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(ray);
		readCommonEntityData(cadEntityTemplate);
		ray.StartPoint = _objectReader.Read3BitDouble();
		ray.Direction = _objectReader.Read3BitDouble();
		return cadEntityTemplate;
	}

	private CadTemplate readXLine()
	{
		XLine xLine = new XLine();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(xLine);
		readCommonEntityData(cadEntityTemplate);
		xLine.FirstPoint = _objectReader.Read3BitDouble();
		xLine.Direction = _objectReader.Read3BitDouble();
		return cadEntityTemplate;
	}

	private CadTemplate readDictionaryWithDefault()
	{
		CadDictionaryWithDefaultTemplate cadDictionaryWithDefaultTemplate = new CadDictionaryWithDefaultTemplate(new CadDictionaryWithDefault());
		readCommonDictionary(cadDictionaryWithDefaultTemplate);
		cadDictionaryWithDefaultTemplate.DefaultEntryHandle = handleReference();
		return cadDictionaryWithDefaultTemplate;
	}

	private CadTemplate readDictionary()
	{
		CadDictionaryTemplate cadDictionaryTemplate = new CadDictionaryTemplate(new CadDictionary());
		readCommonDictionary(cadDictionaryTemplate);
		return cadDictionaryTemplate;
	}

	private void readCommonDictionary(CadDictionaryTemplate template)
	{
		readCommonNonEntityData(template);
		int num = _objectReader.ReadBitLong();
		if (_version == ACadVersion.AC1014)
		{
			_objectReader.ReadByte();
		}
		if (R2000Plus)
		{
			template.CadObject.ClonningFlags = (DictionaryCloningFlags)_objectReader.ReadBitShort();
			template.CadObject.HardOwnerFlag = _objectReader.ReadByte() > 0;
		}
		for (int i = 0; i < num; i++)
		{
			string text = _textReader.ReadVariableText();
			ulong num2 = handleReference();
			if (num2 != 0L && !string.IsNullOrEmpty(text))
			{
				template.Entries.Add(text, num2);
			}
		}
	}

	private CadTemplate readDictionaryVar()
	{
		DictionaryVariable dictionaryVariable = new DictionaryVariable();
		CadTemplate<DictionaryVariable> cadTemplate = new CadTemplate<DictionaryVariable>(dictionaryVariable);
		readCommonNonEntityData(cadTemplate);
		_objectReader.ReadByte();
		dictionaryVariable.Value = _textReader.ReadVariableText();
		return cadTemplate;
	}

	private CadTemplate readMText()
	{
		CadTextEntityTemplate template = new CadTextEntityTemplate(new MText());
		return readMText(template, readCommonData: true);
	}

	private CadTemplate readMText(CadTextEntityTemplate template, bool readCommonData)
	{
		MText mText = template.CadObject as MText;
		if (readCommonData)
		{
			readCommonEntityData(template);
		}
		mText.InsertPoint = _objectReader.Read3BitDouble();
		mText.Normal = _objectReader.Read3BitDouble();
		mText.AlignmentPoint = _objectReader.Read3BitDouble();
		mText.RectangleWidth = _objectReader.ReadBitDouble();
		if (R2007Plus)
		{
			mText.RectangleHeight = _objectReader.ReadBitDouble();
		}
		mText.Height = _objectReader.ReadBitDouble();
		mText.AttachmentPoint = (AttachmentPointType)_objectReader.ReadBitShort();
		mText.DrawingDirection = (DrawingDirectionType)_objectReader.ReadBitShort();
		_objectReader.ReadBitDouble();
		_objectReader.ReadBitDouble();
		mText.Value = _textReader.ReadVariableText();
		template.StyleHandle = handleReference();
		if (R2000Plus)
		{
			mText.LineSpacingStyle = (LineSpacingStyleType)_objectReader.ReadBitShort();
			mText.LineSpacing = _objectReader.ReadBitDouble();
			_objectReader.ReadBit();
		}
		if (R2004Plus)
		{
			mText.BackgroundFillFlags = (BackgroundFillFlags)_objectReader.ReadBitLong();
			if ((mText.BackgroundFillFlags & BackgroundFillFlags.UseBackgroundFillColor) != BackgroundFillFlags.None || (_version > ACadVersion.AC1027 && (int)(mText.BackgroundFillFlags & BackgroundFillFlags.TextFrame) > 0))
			{
				mText.BackgroundScale = _objectReader.ReadBitDouble();
				mText.BackgroundColor = _mergedReaders.ReadCmColor();
				mText.BackgroundTransparency = new Transparency((short)_objectReader.ReadBitLong());
			}
		}
		if (!R2018Plus)
		{
			return template;
		}
		mText.IsAnnotative = !_objectReader.ReadBit();
		if (!mText.IsAnnotative)
		{
			_objectReader.ReadBitShort();
			_objectReader.ReadBit();
			handleReference();
			_ = (short)_objectReader.ReadBitLong();
			_objectReader.Read3BitDouble();
			_objectReader.Read3BitDouble();
			_objectReader.ReadBitDouble();
			_objectReader.ReadBitDouble();
			_objectReader.ReadBitDouble();
			_objectReader.ReadBitDouble();
			mText.Column.ColumnType = (ColumnType)_objectReader.ReadBitShort();
			if (mText.Column.ColumnType != ColumnType.NoColumns)
			{
				int num = _objectReader.ReadBitLong();
				mText.Column.ColumnWidth = _objectReader.ReadBitDouble();
				mText.Column.ColumnGutter = _objectReader.ReadBitDouble();
				mText.Column.ColumnAutoHeight = _objectReader.ReadBit();
				mText.Column.ColumnFlowReversed = _objectReader.ReadBit();
				if (!mText.Column.ColumnAutoHeight && mText.Column.ColumnType == ColumnType.DynamicColumns && num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						mText.Column.ColumnHeights.Add(_objectReader.ReadBitDouble());
					}
				}
			}
		}
		return template;
	}

	private CadTemplate readLeader()
	{
		Leader leader = new Leader();
		CadLeaderTemplate cadLeaderTemplate = new CadLeaderTemplate(leader);
		readCommonEntityData(cadLeaderTemplate);
		_objectReader.ReadBit();
		leader.CreationType = (LeaderCreationType)_objectReader.ReadBitShort();
		leader.PathType = (LeaderPathType)_objectReader.ReadBitShort();
		int num = _objectReader.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			leader.Vertices.Add(_objectReader.Read3BitDouble());
		}
		_objectReader.Read3BitDouble();
		leader.Normal = _objectReader.Read3BitDouble();
		leader.HorizontalDirection = _objectReader.Read3BitDouble();
		leader.BlockOffset = _objectReader.Read3BitDouble();
		if (_version >= ACadVersion.AC1014)
		{
			leader.AnnotationOffset = _objectReader.Read3BitDouble();
		}
		if (R13_14Only)
		{
			leader.Style.DimensionLineGap = _objectReader.ReadBitDouble();
		}
		if (_version <= ACadVersion.AC1021)
		{
			leader.TextHeight = _objectReader.ReadBitDouble();
			leader.TextWidth = _objectReader.ReadBitDouble();
		}
		leader.HookLineDirection = (_objectReader.ReadBit() ? HookLineDirection.Same : HookLineDirection.Opposite);
		leader.ArrowHeadEnabled = _objectReader.ReadBit();
		if (R13_14Only)
		{
			_objectReader.ReadBitShort();
			cadLeaderTemplate.Dimasz = _objectReader.ReadBitDouble();
			_objectReader.ReadBit();
			_objectReader.ReadBit();
			_objectReader.ReadBitShort();
			_objectReader.ReadBitShort();
			_objectReader.ReadBit();
			_objectReader.ReadBit();
		}
		if (R2000Plus)
		{
			_objectReader.ReadBitShort();
			_objectReader.ReadBit();
			_objectReader.ReadBit();
		}
		cadLeaderTemplate.AnnotationHandle = handleReference();
		cadLeaderTemplate.DIMSTYLEHandle = handleReference();
		return cadLeaderTemplate;
	}

	private CadTemplate readMultiLeader()
	{
		MultiLeader multiLeader = new MultiLeader();
		CadMLeaderTemplate cadMLeaderTemplate = new CadMLeaderTemplate(multiLeader);
		readCommonEntityData(cadMLeaderTemplate);
		if (R2010Plus)
		{
			_objectReader.ReadBitShort();
		}
		readMultiLeaderAnnotContext(multiLeader.ContextData, cadMLeaderTemplate.CadMLeaderAnnotContextTemplate);
		cadMLeaderTemplate.LeaderStyleHandle = handleReference();
		multiLeader.PropertyOverrideFlags = (MultiLeaderPropertyOverrideFlags)_objectReader.ReadBitLong();
		multiLeader.PathType = (MultiLeaderPathType)_objectReader.ReadBitShort();
		multiLeader.LineColor = _mergedReaders.ReadCmColor();
		cadMLeaderTemplate.LeaderLineTypeHandle = handleReference();
		multiLeader.LeaderLineWeight = (LineWeightType)_objectReader.ReadBitLong();
		multiLeader.EnableLanding = _objectReader.ReadBit();
		multiLeader.EnableDogleg = _objectReader.ReadBit();
		multiLeader.LandingDistance = _objectReader.ReadBitDouble();
		cadMLeaderTemplate.ArrowheadHandle = handleReference();
		multiLeader.ArrowheadSize = _objectReader.ReadBitDouble();
		multiLeader.ContentType = (LeaderContentType)_objectReader.ReadBitShort();
		cadMLeaderTemplate.MTextStyleHandle = handleReference();
		multiLeader.TextLeftAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
		multiLeader.TextRightAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
		multiLeader.TextAngle = (TextAngleType)_objectReader.ReadBitShort();
		multiLeader.TextAlignment = (TextAlignmentType)_objectReader.ReadBitShort();
		multiLeader.TextColor = _mergedReaders.ReadCmColor();
		multiLeader.TextFrame = _objectReader.ReadBit();
		cadMLeaderTemplate.BlockContentHandle = handleReference();
		multiLeader.BlockContentColor = _mergedReaders.ReadCmColor();
		multiLeader.BlockContentScale = _objectReader.Read3BitDouble();
		multiLeader.BlockContentRotation = _objectReader.ReadBitDouble();
		multiLeader.BlockContentConnection = (BlockContentConnectionType)_objectReader.ReadBitShort();
		multiLeader.EnableAnnotationScale = _objectReader.ReadBit();
		if (R2007Pre)
		{
			int num = _objectReader.ReadBitLong();
			for (int i = 0; i < num; i++)
			{
				bool value = _objectReader.ReadBit();
				cadMLeaderTemplate.ArrowheadHandles.Add(handleReference(), value);
			}
		}
		int num2 = _objectReader.ReadBitLong();
		for (int j = 0; j < num2; j++)
		{
			ulong value2 = handleReference();
			MultiLeader.BlockAttribute blockAttribute = new MultiLeader.BlockAttribute
			{
				Text = _textReader.ReadVariableText(),
				Index = _objectReader.ReadBitShort(),
				Width = _objectReader.ReadBitDouble()
			};
			multiLeader.BlockAttributes.Add(blockAttribute);
			cadMLeaderTemplate.BlockAttributeHandles.Add(blockAttribute, value2);
		}
		multiLeader.TextDirectionNegative = _objectReader.ReadBit();
		multiLeader.TextAligninIPE = _objectReader.ReadBitShort();
		multiLeader.TextAttachmentPoint = (TextAttachmentPointType)_objectReader.ReadBitShort();
		multiLeader.ScaleFactor = _objectReader.ReadBitDouble();
		if (R2010Plus)
		{
			multiLeader.TextAttachmentDirection = (TextAttachmentDirectionType)_objectReader.ReadBitShort();
			multiLeader.TextBottomAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
			multiLeader.TextTopAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
		}
		if (R2013Plus)
		{
			multiLeader.ExtendedToText = _objectReader.ReadBit();
		}
		return cadMLeaderTemplate;
	}

	private CadTemplate readObjectContextData(CadTemplate template)
	{
		readCommonNonEntityData(template);
		ObjectContextData obj = (ObjectContextData)template.CadObject;
		obj.Version = _objectReader.ReadBitShort();
		obj.HasFileToExtensionDictionary = _objectReader.ReadBit();
		obj.Default = _objectReader.ReadBit();
		return template;
	}

	private CadTemplate readAnnotScaleObjectContextData(CadAnnotScaleObjectContextDataTemplate template)
	{
		readObjectContextData(template);
		template.ScaleHandle = handleReference();
		return template;
	}

	private CadTemplate readMultiLeaderAnnotContext()
	{
		MultiLeaderObjectContextData multiLeaderObjectContextData = new MultiLeaderObjectContextData();
		CadMLeaderAnnotContextTemplate cadMLeaderAnnotContextTemplate = new CadMLeaderAnnotContextTemplate(multiLeaderObjectContextData);
		readAnnotScaleObjectContextData(cadMLeaderAnnotContextTemplate);
		readMultiLeaderAnnotContext(multiLeaderObjectContextData, cadMLeaderAnnotContextTemplate);
		return cadMLeaderAnnotContextTemplate;
	}

	private MultiLeaderObjectContextData readMultiLeaderAnnotContext(MultiLeaderObjectContextData annotContext, CadMLeaderAnnotContextTemplate template)
	{
		int num = _objectReader.ReadBitLong();
		if (num == 0)
		{
			_objectReader.ReadBit();
			_objectReader.ReadBit();
			_objectReader.ReadBit();
			_objectReader.ReadBit();
			_objectReader.ReadBit();
			bool num2 = _objectReader.ReadBit();
			_objectReader.ReadBit();
			num = ((!num2) ? 1 : 2);
		}
		for (int i = 0; i < num; i++)
		{
			annotContext.LeaderRoots.Add(readLeaderRoot(template));
		}
		annotContext.ScaleFactor = _objectReader.ReadBitDouble();
		annotContext.ContentBasePoint = _objectReader.Read3BitDouble();
		annotContext.TextHeight = _objectReader.ReadBitDouble();
		annotContext.ArrowheadSize = _objectReader.ReadBitDouble();
		annotContext.LandingGap = _objectReader.ReadBitDouble();
		annotContext.TextLeftAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
		annotContext.TextRightAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
		annotContext.TextAlignment = (TextAlignmentType)_objectReader.ReadBitShort();
		annotContext.BlockContentConnection = (BlockContentConnectionType)_objectReader.ReadBitShort();
		annotContext.HasTextContents = _objectReader.ReadBit();
		if (annotContext.HasTextContents)
		{
			annotContext.TextLabel = _textReader.ReadVariableText();
			annotContext.TextNormal = _objectReader.Read3BitDouble();
			template.TextStyleHandle = handleReference();
			annotContext.TextLocation = _objectReader.Read3BitDouble();
			annotContext.Direction = _objectReader.Read3BitDouble();
			annotContext.TextRotation = _objectReader.ReadBitDouble();
			annotContext.BoundaryWidth = _objectReader.ReadBitDouble();
			annotContext.BoundaryHeight = _objectReader.ReadBitDouble();
			annotContext.LineSpacingFactor = _objectReader.ReadBitDouble();
			annotContext.LineSpacing = (LineSpacingStyle)_objectReader.ReadBitShort();
			annotContext.TextColor = _objectReader.ReadCmColor();
			annotContext.TextAttachmentPoint = (TextAttachmentPointType)_objectReader.ReadBitShort();
			annotContext.FlowDirection = (FlowDirectionType)_objectReader.ReadBitShort();
			annotContext.BackgroundFillColor = _objectReader.ReadCmColor();
			annotContext.BackgroundScaleFactor = _objectReader.ReadBitDouble();
			annotContext.BackgroundTransparency = _objectReader.ReadBitLong();
			annotContext.BackgroundFillEnabled = _objectReader.ReadBit();
			annotContext.BackgroundMaskFillOn = _objectReader.ReadBit();
			annotContext.ColumnType = _objectReader.ReadBitShort();
			annotContext.TextHeightAutomatic = _objectReader.ReadBit();
			annotContext.ColumnWidth = _objectReader.ReadBitDouble();
			annotContext.ColumnGutter = _objectReader.ReadBitDouble();
			annotContext.ColumnFlowReversed = _objectReader.ReadBit();
			int num3 = _objectReader.ReadBitLong();
			for (int j = 0; j < num3; j++)
			{
				annotContext.ColumnSizes.Add(_objectReader.ReadBitDouble());
			}
			annotContext.WordBreak = _objectReader.ReadBit();
			_objectReader.ReadBit();
		}
		else if (annotContext.HasContentsBlock = _objectReader.ReadBit())
		{
			template.BlockRecordHandle = handleReference();
			annotContext.BlockContentNormal = _objectReader.Read3BitDouble();
			annotContext.BlockContentLocation = _objectReader.Read3BitDouble();
			annotContext.BlockContentScale = _objectReader.Read3BitDouble();
			annotContext.BlockContentRotation = _objectReader.ReadBitDouble();
			annotContext.BlockContentColor = _objectReader.ReadCmColor();
			double m = _objectReader.ReadBitDouble();
			double m2 = _objectReader.ReadBitDouble();
			double m3 = _objectReader.ReadBitDouble();
			double m4 = _objectReader.ReadBitDouble();
			double m5 = _objectReader.ReadBitDouble();
			double m6 = _objectReader.ReadBitDouble();
			double m7 = _objectReader.ReadBitDouble();
			double m8 = _objectReader.ReadBitDouble();
			double m9 = _objectReader.ReadBitDouble();
			double m10 = _objectReader.ReadBitDouble();
			double m11 = _objectReader.ReadBitDouble();
			double m12 = _objectReader.ReadBitDouble();
			double m13 = _objectReader.ReadBitDouble();
			double m14 = _objectReader.ReadBitDouble();
			double m15 = _objectReader.ReadBitDouble();
			double m16 = _objectReader.ReadBitDouble();
			annotContext.TransformationMatrix = new Matrix4(m, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16);
		}
		annotContext.BasePoint = _objectReader.Read3BitDouble();
		annotContext.BaseDirection = _objectReader.Read3BitDouble();
		annotContext.BaseVertical = _objectReader.Read3BitDouble();
		annotContext.NormalReversed = _objectReader.ReadBit();
		if (R2010Plus)
		{
			annotContext.TextTopAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
			annotContext.TextBottomAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
		}
		return annotContext;
	}

	private MultiLeaderObjectContextData.LeaderRoot readLeaderRoot(CadMLeaderAnnotContextTemplate template)
	{
		MultiLeaderObjectContextData.LeaderRoot leaderRoot = new MultiLeaderObjectContextData.LeaderRoot();
		leaderRoot.ContentValid = _objectReader.ReadBit();
		leaderRoot.Unknown = _objectReader.ReadBit();
		leaderRoot.ConnectionPoint = _objectReader.Read3BitDouble();
		leaderRoot.Direction = _objectReader.Read3BitDouble();
		int num = _objectReader.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			leaderRoot.BreakStartEndPointsPairs.Add(new MultiLeaderObjectContextData.StartEndPointPair(_objectReader.Read3BitDouble(), _objectReader.Read3BitDouble()));
		}
		leaderRoot.LeaderIndex = _objectReader.ReadBitLong();
		leaderRoot.LandingDistance = _objectReader.ReadBitDouble();
		int num2 = _objectReader.ReadBitLong();
		for (int j = 0; j < num2; j++)
		{
			leaderRoot.Lines.Add(readLeaderLine(template));
		}
		if (R2010Plus)
		{
			leaderRoot.TextAttachmentDirection = (TextAttachmentDirectionType)_objectReader.ReadBitShort();
		}
		return leaderRoot;
	}

	private MultiLeaderObjectContextData.LeaderLine readLeaderLine(CadMLeaderAnnotContextTemplate template)
	{
		MultiLeaderObjectContextData.LeaderLine leaderLine = new MultiLeaderObjectContextData.LeaderLine();
		CadMLeaderAnnotContextTemplate.LeaderLineTemplate leaderLineTemplate = new CadMLeaderAnnotContextTemplate.LeaderLineTemplate(leaderLine);
		template.LeaderLineTemplates.Add(leaderLineTemplate);
		int num = _objectReader.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			leaderLine.Points.Add(_objectReader.Read3BitDouble());
		}
		leaderLine.BreakInfoCount = _objectReader.ReadBitLong();
		if (leaderLine.BreakInfoCount > 0)
		{
			leaderLine.SegmentIndex = _objectReader.ReadBitLong();
			int num2 = _objectReader.ReadBitLong();
			for (int j = 0; j < num2; j++)
			{
				leaderLine.StartEndPoints.Add(new MultiLeaderObjectContextData.StartEndPointPair(_objectReader.Read3BitDouble(), _objectReader.Read3BitDouble()));
			}
		}
		leaderLine.Index = _objectReader.ReadBitLong();
		if (R2010Plus)
		{
			leaderLine.PathType = (MultiLeaderPathType)_objectReader.ReadBitShort();
			leaderLine.LineColor = _objectReader.ReadCmColor();
			leaderLineTemplate.LineTypeHandle = handleReference();
			leaderLine.LineWeight = (LineWeightType)_objectReader.ReadBitLong();
			leaderLine.ArrowheadSize = _objectReader.ReadBitDouble();
			leaderLineTemplate.ArrowSymbolHandle = handleReference();
			leaderLine.OverrideFlags = (LeaderLinePropertOverrideFlags)_objectReader.ReadBitLong();
		}
		return leaderLine;
	}

	private CadTemplate readMultiLeaderStyle()
	{
		MultiLeaderStyle multiLeaderStyle = new MultiLeaderStyle();
		CadMLeaderStyleTemplate cadMLeaderStyleTemplate = new CadMLeaderStyleTemplate(multiLeaderStyle);
		readCommonNonEntityData(cadMLeaderStyleTemplate);
		if (R2010Plus)
		{
			_objectReader.ReadBitShort();
		}
		multiLeaderStyle.ContentType = (LeaderContentType)_objectReader.ReadBitShort();
		multiLeaderStyle.MultiLeaderDrawOrder = (MultiLeaderDrawOrderType)_objectReader.ReadBitShort();
		multiLeaderStyle.LeaderDrawOrder = (LeaderDrawOrderType)_objectReader.ReadBitShort();
		multiLeaderStyle.MaxLeaderSegmentsPoints = _objectReader.ReadBitLong();
		multiLeaderStyle.FirstSegmentAngleConstraint = _objectReader.ReadBitDouble();
		multiLeaderStyle.SecondSegmentAngleConstraint = _objectReader.ReadBitDouble();
		multiLeaderStyle.PathType = (MultiLeaderPathType)_objectReader.ReadBitShort();
		multiLeaderStyle.LineColor = _mergedReaders.ReadCmColor();
		cadMLeaderStyleTemplate.LeaderLineTypeHandle = handleReference();
		multiLeaderStyle.LeaderLineWeight = (LineWeightType)_objectReader.ReadBitLong();
		multiLeaderStyle.EnableLanding = _objectReader.ReadBit();
		multiLeaderStyle.LandingGap = _objectReader.ReadBitDouble();
		multiLeaderStyle.EnableDogleg = _objectReader.ReadBit();
		multiLeaderStyle.LandingDistance = _objectReader.ReadBitDouble();
		multiLeaderStyle.Description = _mergedReaders.ReadVariableText();
		cadMLeaderStyleTemplate.ArrowheadHandle = handleReference();
		multiLeaderStyle.ArrowheadSize = _objectReader.ReadBitDouble();
		multiLeaderStyle.DefaultTextContents = _mergedReaders.ReadVariableText();
		cadMLeaderStyleTemplate.MTextStyleHandle = handleReference();
		multiLeaderStyle.TextLeftAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
		multiLeaderStyle.TextRightAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
		multiLeaderStyle.TextAngle = (TextAngleType)_objectReader.ReadBitShort();
		multiLeaderStyle.TextAlignment = (TextAlignmentType)_objectReader.ReadBitShort();
		multiLeaderStyle.TextColor = _mergedReaders.ReadCmColor();
		multiLeaderStyle.TextHeight = _objectReader.ReadBitDouble();
		multiLeaderStyle.TextFrame = _objectReader.ReadBit();
		multiLeaderStyle.TextAlignAlwaysLeft = _objectReader.ReadBit();
		multiLeaderStyle.AlignSpace = _objectReader.ReadBitDouble();
		cadMLeaderStyleTemplate.BlockContentHandle = handleReference();
		multiLeaderStyle.BlockContentColor = _mergedReaders.ReadCmColor();
		multiLeaderStyle.BlockContentScale = _objectReader.Read3BitDouble();
		multiLeaderStyle.EnableBlockContentScale = _objectReader.ReadBit();
		multiLeaderStyle.BlockContentRotation = _objectReader.ReadBitDouble();
		multiLeaderStyle.EnableBlockContentRotation = _objectReader.ReadBit();
		multiLeaderStyle.BlockContentConnection = (BlockContentConnectionType)_objectReader.ReadBitShort();
		multiLeaderStyle.ScaleFactor = _objectReader.ReadBitDouble();
		multiLeaderStyle.OverwritePropertyValue = _objectReader.ReadBit();
		multiLeaderStyle.IsAnnotative = _objectReader.ReadBit();
		multiLeaderStyle.BreakGapSize = _objectReader.ReadBitDouble();
		if (R2010Plus)
		{
			multiLeaderStyle.TextAttachmentDirection = (TextAttachmentDirectionType)_objectReader.ReadBitShort();
			multiLeaderStyle.TextBottomAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
			multiLeaderStyle.TextTopAttachment = (TextAttachmentType)_objectReader.ReadBitShort();
		}
		if (R2013Plus)
		{
			multiLeaderStyle.UnknownFlag298 = _objectReader.ReadBit();
		}
		return cadMLeaderStyleTemplate;
	}

	private CadTemplate readTolerance()
	{
		Tolerance tolerance = new Tolerance();
		CadToleranceTemplate cadToleranceTemplate = new CadToleranceTemplate(tolerance);
		readCommonEntityData(cadToleranceTemplate);
		if (R13_14Only)
		{
			_objectReader.ReadBitShort();
			_objectReader.ReadBitDouble();
			_objectReader.ReadBitDouble();
		}
		tolerance.InsertionPoint = _objectReader.Read3BitDouble();
		tolerance.Direction = _objectReader.Read3BitDouble();
		tolerance.Normal = _objectReader.Read3BitDouble();
		tolerance.Text = _textReader.ReadVariableText();
		cadToleranceTemplate.DimensionStyleHandle = handleReference();
		return cadToleranceTemplate;
	}

	private CadTemplate readMLine()
	{
		MLine mLine = new MLine();
		CadMLineTemplate cadMLineTemplate = new CadMLineTemplate(mLine);
		readCommonEntityData(cadMLineTemplate);
		mLine.ScaleFactor = _objectReader.ReadBitDouble();
		mLine.Justification = (MLineJustification)_objectReader.ReadByte();
		mLine.StartPoint = _objectReader.Read3BitDouble();
		mLine.Normal = _objectReader.Read3BitDouble();
		mLine.Flags |= (MLineFlags)((_objectReader.ReadBitShort() != 3) ? 1 : 2);
		int num = _objectReader.ReadByte();
		int num2 = _objectReader.ReadBitShort();
		for (int i = 0; i < num2; i++)
		{
			MLine.Vertex vertex = new MLine.Vertex();
			vertex.Position = _objectReader.Read3BitDouble();
			vertex.Direction = _objectReader.Read3BitDouble();
			vertex.Miter = _objectReader.Read3BitDouble();
			for (int j = 0; j < num; j++)
			{
				MLine.Vertex.Segment segment = new MLine.Vertex.Segment();
				int num3 = _objectReader.ReadBitShort();
				for (int k = 0; k < num3; k++)
				{
					segment.Parameters.Add(_objectReader.ReadBitDouble());
				}
				int num4 = _objectReader.ReadBitShort();
				for (int l = 0; l < num4; l++)
				{
					segment.AreaFillParameters.Add(_objectReader.ReadBitDouble());
				}
				vertex.Segments.Add(segment);
			}
			mLine.Vertices.Add(vertex);
		}
		cadMLineTemplate.MLineStyleHandle = handleReference();
		return cadMLineTemplate;
	}

	private CadTemplate readBlockControlObject()
	{
		CadBlockCtrlObjectTemplate cadBlockCtrlObjectTemplate = new CadBlockCtrlObjectTemplate(new BlockRecordsTable());
		readDocumentTable(cadBlockCtrlObjectTemplate);
		cadBlockCtrlObjectTemplate.ModelSpaceHandle = handleReference();
		cadBlockCtrlObjectTemplate.PaperSpaceHandle = handleReference();
		return cadBlockCtrlObjectTemplate;
	}

	private CadTemplate readBlockHeader()
	{
		BlockRecord blockRecord = new BlockRecord();
		Block blockEntity = blockRecord.BlockEntity;
		CadBlockRecordTemplate cadBlockRecordTemplate = new CadBlockRecordTemplate(blockRecord);
		_builder.BlockRecordTemplates.Add(cadBlockRecordTemplate);
		readCommonNonEntityData(cadBlockRecordTemplate);
		string text = _textReader.ReadVariableText();
		if (text.Equals("*Model_Space", StringComparison.CurrentCultureIgnoreCase) || text.Equals("*Paper_Space", StringComparison.CurrentCultureIgnoreCase))
		{
			blockRecord.Name = text;
		}
		readXrefDependantBit(cadBlockRecordTemplate.CadObject);
		if (_objectReader.ReadBit())
		{
			blockEntity.Flags |= BlockTypeFlags.Anonymous;
		}
		_objectReader.ReadBit();
		if (_objectReader.ReadBit())
		{
			blockEntity.Flags |= BlockTypeFlags.XRef;
		}
		if (_objectReader.ReadBit())
		{
			blockEntity.Flags |= BlockTypeFlags.XRefOverlay;
		}
		if (R2000Plus)
		{
			blockEntity.IsUnloaded = _objectReader.ReadBit();
		}
		int num = 0;
		if (R2004Plus && !blockEntity.Flags.HasFlag(BlockTypeFlags.XRef) && !blockEntity.Flags.HasFlag(BlockTypeFlags.XRefOverlay))
		{
			num = _objectReader.ReadBitLong();
		}
		blockEntity.BasePoint = _objectReader.Read3BitDouble();
		blockEntity.XRefPath = _textReader.ReadVariableText();
		int num2 = 0;
		if (R2000Plus)
		{
			for (byte b = _objectReader.ReadByte(); b != 0; b = _objectReader.ReadByte())
			{
				num2++;
			}
			blockEntity.Comments = _textReader.ReadVariableText();
			int num3 = _objectReader.ReadBitLong();
			List<byte> list = new List<byte>();
			for (int i = 0; i < num3; i++)
			{
				list.Add(_objectReader.ReadByte());
			}
			blockRecord.Preview = list.ToArray();
		}
		if (R2007Plus)
		{
			blockRecord.Units = (UnitsType)_objectReader.ReadBitShort();
			blockRecord.IsExplodable = _objectReader.ReadBit();
			blockRecord.CanScale = _objectReader.ReadByte() > 0;
		}
		handleReference();
		cadBlockRecordTemplate.BeginBlockHandle = handleReference();
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1015 && !blockEntity.Flags.HasFlag(BlockTypeFlags.XRef) && !blockEntity.Flags.HasFlag(BlockTypeFlags.XRefOverlay))
		{
			cadBlockRecordTemplate.FirstEntityHandle = handleReference();
			cadBlockRecordTemplate.LastEntityHandle = handleReference();
		}
		if (R2004Plus)
		{
			for (int j = 0; j < num; j++)
			{
				cadBlockRecordTemplate.OwnedObjectsHandlers.Add(handleReference());
			}
		}
		cadBlockRecordTemplate.EndBlockHandle = handleReference();
		if (R2000Plus)
		{
			for (int k = 0; k < num2; k++)
			{
				cadBlockRecordTemplate.InsertHandles.Add(handleReference());
			}
			cadBlockRecordTemplate.LayoutHandle = handleReference();
		}
		return cadBlockRecordTemplate;
	}

	private CadTemplate readLayer()
	{
		Layer layer = new Layer();
		CadLayerTemplate cadLayerTemplate = new CadLayerTemplate(layer);
		readCommonNonEntityData(cadLayerTemplate);
		string text = _textReader.ReadVariableText();
		if (!string.IsNullOrWhiteSpace(text))
		{
			layer.Name = text;
		}
		readXrefDependantBit(cadLayerTemplate.CadObject);
		if (R13_14Only)
		{
			if (_objectReader.ReadBit())
			{
				layer.Flags |= LayerFlags.Frozen;
			}
			layer.IsOn = _objectReader.ReadBit();
			if (_objectReader.ReadBit())
			{
				layer.Flags |= LayerFlags.FrozenNewViewports;
			}
			if (_objectReader.ReadBit())
			{
				layer.Flags |= LayerFlags.Locked;
			}
		}
		if (R2000Plus)
		{
			short num = _objectReader.ReadBitShort();
			if ((num & 1) != 0)
			{
				layer.Flags |= LayerFlags.Frozen;
			}
			layer.IsOn = (num & 2) == 0;
			if ((num & 4) != 0)
			{
				layer.Flags |= LayerFlags.FrozenNewViewports;
			}
			if ((num & 8) != 0)
			{
				layer.Flags |= LayerFlags.Locked;
			}
			layer.PlotFlag = (num & 0x10) != 0;
			byte b = (byte)((num & 0x3E0) >> 5);
			layer.LineWeight = CadUtils.ToValue(b);
		}
		Color color = _mergedReaders.ReadCmColor();
		layer.Color = ((color.IsByBlock || color.IsByLayer) ? new Color(30) : color);
		cadLayerTemplate.LayerControlHandle = handleReference();
		if (R2000Plus)
		{
			cadLayerTemplate.PlotStyleHandle = handleReference();
		}
		if (R2007Plus)
		{
			cadLayerTemplate.MaterialHandle = handleReference();
		}
		cadLayerTemplate.LineTypeHandle = handleReference();
		if (R2013Plus)
		{
			handleReference();
		}
		return cadLayerTemplate;
	}

	private CadTemplate readTextStyle()
	{
		TextStyle textStyle = new TextStyle();
		CadTableEntryTemplate<TextStyle> cadTableEntryTemplate = new CadTableEntryTemplate<TextStyle>(textStyle);
		readCommonNonEntityData(cadTableEntryTemplate);
		string text = _textReader.ReadVariableText();
		if (!string.IsNullOrWhiteSpace(text))
		{
			textStyle.Name = text;
		}
		readXrefDependantBit(cadTableEntryTemplate.CadObject);
		if (_objectReader.ReadBit())
		{
			textStyle.Flags |= StyleFlags.IsShape;
		}
		if (_objectReader.ReadBit())
		{
			textStyle.Flags |= StyleFlags.VerticalText;
		}
		textStyle.Height = _objectReader.ReadBitDouble();
		textStyle.Width = _objectReader.ReadBitDouble();
		textStyle.ObliqueAngle = _objectReader.ReadBitDouble();
		textStyle.MirrorFlag = (TextMirrorFlag)_objectReader.ReadByte();
		textStyle.LastHeight = _objectReader.ReadBitDouble();
		textStyle.Filename = _textReader.ReadVariableText();
		textStyle.BigFontFilename = _textReader.ReadVariableText();
		handleReference();
		return cadTableEntryTemplate;
	}

	private CadTemplate readLTypeControlObject()
	{
		CadTableTemplate<LineType> cadTableTemplate = new CadTableTemplate<LineType>(new LineTypesTable());
		readDocumentTable(cadTableTemplate);
		cadTableTemplate.EntryHandles.Add(handleReference());
		cadTableTemplate.EntryHandles.Add(handleReference());
		return cadTableTemplate;
	}

	private CadTemplate readLType()
	{
		LineType lineType = new LineType();
		CadLineTypeTemplate cadLineTypeTemplate = new CadLineTypeTemplate(lineType);
		readCommonNonEntityData(cadLineTypeTemplate);
		string text = _textReader.ReadVariableText();
		if (!string.IsNullOrWhiteSpace(text))
		{
			lineType.Name = text;
		}
		readXrefDependantBit(cadLineTypeTemplate.CadObject);
		lineType.Description = _textReader.ReadVariableText();
		cadLineTypeTemplate.TotalLen = _objectReader.ReadBitDouble();
		lineType.Alignment = _objectReader.ReadRawChar();
		int num = _objectReader.ReadByte();
		bool flag = false;
		for (int i = 0; i < num; i++)
		{
			CadLineTypeTemplate.SegmentTemplate segmentTemplate = new CadLineTypeTemplate.SegmentTemplate();
			segmentTemplate.Segment.Length = _objectReader.ReadBitDouble();
			segmentTemplate.Segment.ShapeNumber = _objectReader.ReadBitShort();
			XY offset = new XY(_objectReader.ReadDouble(), _objectReader.ReadDouble());
			segmentTemplate.Segment.Offset = offset;
			segmentTemplate.Segment.Scale = _objectReader.ReadBitDouble();
			segmentTemplate.Segment.Rotation = _objectReader.ReadBitDouble();
			segmentTemplate.Segment.Flags = (LineTypeShapeFlags)_objectReader.ReadBitShort();
			if (segmentTemplate.Segment.Flags.HasFlag(LineTypeShapeFlags.Text))
			{
				flag = true;
			}
			cadLineTypeTemplate.SegmentTemplates.Add(segmentTemplate);
		}
		byte[] textArea = null;
		if (_version <= ACadVersion.AC1018)
		{
			textArea = _objectReader.ReadBytes(256);
		}
		if (R2007Plus && flag)
		{
			textArea = _objectReader.ReadBytes(512);
		}
		if (flag)
		{
			readLineTypeSegmentTexts(cadLineTypeTemplate.SegmentTemplates, textArea);
		}
		cadLineTypeTemplate.LtypeControlHandle = handleReference();
		for (int j = 0; j < num; j++)
		{
			cadLineTypeTemplate.SegmentTemplates[j].StyleHandle = handleReference();
		}
		return cadLineTypeTemplate;
	}

	private CadTemplate readView()
	{
		View view = new View();
		CadViewTemplate cadViewTemplate = new CadViewTemplate(view);
		readCommonNonEntityData(cadViewTemplate);
		view.Name = _textReader.ReadVariableText();
		readXrefDependantBit(view);
		view.Height = _objectReader.ReadBitDouble();
		view.Width = _objectReader.ReadBitDouble();
		view.Center = _objectReader.Read2RawDouble();
		view.Target = _objectReader.Read3BitDouble();
		view.Direction = _objectReader.Read3BitDouble();
		view.Angle = _objectReader.ReadBitDouble();
		view.LensLength = _objectReader.ReadBitDouble();
		view.FrontClipping = _objectReader.ReadBitDouble();
		view.BackClipping = _objectReader.ReadBitDouble();
		if (_objectReader.ReadBit())
		{
			view.ViewMode |= ViewModeType.PerspectiveView;
		}
		if (_objectReader.ReadBit())
		{
			view.ViewMode |= ViewModeType.FrontClipping;
		}
		if (_objectReader.ReadBit())
		{
			view.ViewMode |= ViewModeType.BackClipping;
		}
		if (_objectReader.ReadBit())
		{
			view.ViewMode |= ViewModeType.FrontClippingZ;
		}
		if (R2000Plus)
		{
			view.RenderMode = (RenderMode)_objectReader.ReadByte();
		}
		if (R2007Plus)
		{
			_mergedReaders.ReadBit();
			_mergedReaders.ReadByte();
			_mergedReaders.ReadBitDouble();
			_mergedReaders.ReadBitDouble();
			_mergedReaders.ReadCmColor();
		}
		if (_objectReader.ReadBit())
		{
			view.Flags |= (StandardFlags)1;
		}
		if (R2000Plus)
		{
			view.IsUcsAssociated = _objectReader.ReadBit();
			if (view.IsUcsAssociated)
			{
				view.UcsOrigin = _objectReader.Read3BitDouble();
				view.UcsXAxis = _objectReader.Read3BitDouble();
				view.UcsYAxis = _objectReader.Read3BitDouble();
				view.UcsElevation = _objectReader.ReadBitDouble();
				view.UcsOrthographicType = (OrthographicType)_objectReader.ReadBitShort();
			}
		}
		handleReference();
		if (R2007Plus)
		{
			view.IsPlottable = _objectReader.ReadBit();
			handleReference();
			handleReference();
			handleReference();
		}
		if (R2000Plus && view.IsUcsAssociated)
		{
			cadViewTemplate.UcsHandle = handleReference();
			cadViewTemplate.NamedUcsHandle = handleReference();
		}
		if (R2007Plus)
		{
			handleReference();
		}
		return cadViewTemplate;
	}

	private CadTemplate readUcs()
	{
		UCS uCS = new UCS();
		CadTemplate<UCS> cadTemplate = new CadTemplate<UCS>(uCS);
		readCommonNonEntityData(cadTemplate);
		uCS.Name = _textReader.ReadVariableText();
		readXrefDependantBit(uCS);
		uCS.Origin = _objectReader.Read3BitDouble();
		uCS.XAxis = _objectReader.Read3BitDouble();
		uCS.YAxis = _objectReader.Read3BitDouble();
		if (R2000Plus)
		{
			uCS.Elevation = _objectReader.ReadBitDouble();
			uCS.OrthographicViewType = (OrthographicType)_objectReader.ReadBitShort();
			uCS.OrthographicType = (OrthographicType)_objectReader.ReadBitShort();
		}
		handleReference();
		if (R2000Plus)
		{
			handleReference();
			handleReference();
		}
		return cadTemplate;
	}

	private CadTemplate readVPort()
	{
		VPort vPort = new VPort();
		CadVPortTemplate cadVPortTemplate = new CadVPortTemplate(vPort);
		readCommonNonEntityData(cadVPortTemplate);
		vPort.Name = _textReader.ReadVariableText();
		readXrefDependantBit(vPort);
		vPort.ViewHeight = _objectReader.ReadBitDouble();
		vPort.AspectRatio = _objectReader.ReadBitDouble() / vPort.ViewHeight;
		vPort.Center = _objectReader.Read2RawDouble();
		vPort.Target = _objectReader.Read3BitDouble();
		vPort.Direction = _objectReader.Read3BitDouble();
		vPort.TwistAngle = _objectReader.ReadBitDouble();
		vPort.LensLength = _objectReader.ReadBitDouble();
		vPort.FrontClippingPlane = _objectReader.ReadBitDouble();
		vPort.BackClippingPlane = _objectReader.ReadBitDouble();
		if (_objectReader.ReadBit())
		{
			vPort.ViewMode |= ViewModeType.PerspectiveView;
		}
		if (_objectReader.ReadBit())
		{
			vPort.ViewMode |= ViewModeType.FrontClipping;
		}
		if (_objectReader.ReadBit())
		{
			vPort.ViewMode |= ViewModeType.BackClipping;
		}
		if (_objectReader.ReadBit())
		{
			vPort.ViewMode |= ViewModeType.FrontClippingZ;
		}
		if (R2000Plus)
		{
			vPort.RenderMode = (RenderMode)_objectReader.ReadByte();
		}
		if (R2007Plus)
		{
			vPort.UseDefaultLighting = _objectReader.ReadBit();
			vPort.DefaultLighting = (DefaultLightingType)_objectReader.ReadByte();
			vPort.Brightness = _objectReader.ReadBitDouble();
			vPort.Contrast = _objectReader.ReadBitDouble();
			vPort.AmbientColor = _mergedReaders.ReadCmColor();
		}
		vPort.BottomLeft = _objectReader.Read2RawDouble();
		vPort.TopRight = _objectReader.Read2RawDouble();
		if (_objectReader.ReadBit())
		{
			vPort.ViewMode |= ViewModeType.Follow;
		}
		vPort.CircleZoomPercent = _objectReader.ReadBitShort();
		_objectReader.ReadBit();
		if (_objectReader.ReadBit())
		{
			vPort.UcsIconDisplay = UscIconType.OnLower;
		}
		if (_objectReader.ReadBit())
		{
			vPort.UcsIconDisplay = UscIconType.OnOrigin;
		}
		vPort.ShowGrid = _objectReader.ReadBit();
		vPort.GridSpacing = _objectReader.Read2RawDouble();
		vPort.SnapOn = _objectReader.ReadBit();
		vPort.IsometricSnap = _objectReader.ReadBit();
		vPort.SnapIsoPair = _objectReader.ReadBitShort();
		vPort.SnapRotation = _objectReader.ReadBitDouble();
		vPort.SnapBasePoint = _objectReader.Read2RawDouble();
		vPort.SnapSpacing = _objectReader.Read2RawDouble();
		if (R2000Plus)
		{
			_objectReader.ReadBit();
			_objectReader.ReadBit();
			vPort.Origin = _objectReader.Read3BitDouble();
			vPort.XAxis = _objectReader.Read3BitDouble();
			vPort.YAxis = _objectReader.Read3BitDouble();
			vPort.Elevation = _objectReader.ReadBitDouble();
			vPort.OrthographicType = (OrthographicType)_objectReader.ReadBitShort();
		}
		if (R2007Plus)
		{
			vPort.GridFlags = (GridFlags)_objectReader.ReadBitShort();
			vPort.MinorGridLinesPerMajorGridLine = _objectReader.ReadBitShort();
		}
		cadVPortTemplate.VportControlHandle = handleReference();
		if (R2007Plus)
		{
			cadVPortTemplate.BackgroundHandle = handleReference();
			cadVPortTemplate.StyleHandle = handleReference();
			cadVPortTemplate.SunHandle = handleReference();
		}
		if (R2000Plus)
		{
			cadVPortTemplate.NamedUcsHandle = handleReference();
			cadVPortTemplate.BaseUcsHandle = handleReference();
		}
		return cadVPortTemplate;
	}

	private CadTemplate readAppId()
	{
		AppId appId = new AppId();
		CadTemplate cadTemplate = new CadTemplate<AppId>(appId);
		readCommonNonEntityData(cadTemplate);
		string text = _textReader.ReadVariableText();
		if (!string.IsNullOrWhiteSpace(text))
		{
			appId.Name = text;
		}
		readXrefDependantBit(appId);
		_objectReader.ReadByte();
		handleReference();
		return cadTemplate;
	}

	private CadTemplate readDimStyle()
	{
		DimensionStyle dimensionStyle = new DimensionStyle();
		CadDimensionStyleTemplate cadDimensionStyleTemplate = new CadDimensionStyleTemplate(dimensionStyle);
		readCommonNonEntityData(cadDimensionStyleTemplate);
		string text = _textReader.ReadVariableText();
		if (!string.IsNullOrWhiteSpace(text))
		{
			dimensionStyle.Name = text;
		}
		readXrefDependantBit(dimensionStyle);
		if (R13_14Only)
		{
			dimensionStyle.GenerateTolerances = _objectReader.ReadBit();
			dimensionStyle.LimitsGeneration = _objectReader.ReadBit();
			dimensionStyle.TextOutsideHorizontal = _objectReader.ReadBit();
			dimensionStyle.SuppressFirstExtensionLine = _objectReader.ReadBit();
			dimensionStyle.SuppressSecondExtensionLine = _objectReader.ReadBit();
			dimensionStyle.TextInsideHorizontal = _objectReader.ReadBit();
			dimensionStyle.AlternateUnitDimensioning = _objectReader.ReadBit();
			dimensionStyle.TextOutsideExtensions = _objectReader.ReadBit();
			dimensionStyle.SeparateArrowBlocks = _objectReader.ReadBit();
			dimensionStyle.TextInsideExtensions = _objectReader.ReadBit();
			dimensionStyle.SuppressOutsideExtensions = _objectReader.ReadBit();
			dimensionStyle.AlternateUnitDecimalPlaces = _objectReader.ReadByte();
			dimensionStyle.ZeroHandling = (ZeroHandling)_objectReader.ReadRawChar();
			dimensionStyle.SuppressFirstDimensionLine = _objectReader.ReadBit();
			dimensionStyle.SuppressSecondDimensionLine = _objectReader.ReadBit();
			dimensionStyle.ToleranceAlignment = (ToleranceAlignment)_objectReader.ReadRawChar();
			dimensionStyle.TextHorizontalAlignment = (DimensionTextHorizontalAlignment)_objectReader.ReadByte();
			dimensionStyle.DimensionFit = (short)_objectReader.ReadRawChar();
			dimensionStyle.CursorUpdate = _objectReader.ReadBit();
			dimensionStyle.ToleranceZeroHandling = (ZeroHandling)_objectReader.ReadByte();
			dimensionStyle.AlternateUnitZeroHandling = (ZeroHandling)_objectReader.ReadByte();
			dimensionStyle.AlternateUnitToleranceZeroHandling = (ZeroHandling)_objectReader.ReadByte();
			dimensionStyle.TextVerticalAlignment = (DimensionTextVerticalAlignment)_objectReader.ReadByte();
			dimensionStyle.DimensionUnit = _objectReader.ReadBitShort();
			dimensionStyle.AngularUnit = (AngularUnitFormat)_objectReader.ReadBitShort();
			dimensionStyle.DecimalPlaces = _objectReader.ReadBitShort();
			dimensionStyle.ToleranceDecimalPlaces = _objectReader.ReadBitShort();
			dimensionStyle.AlternateUnitFormat = (LinearUnitFormat)_objectReader.ReadBitShort();
			dimensionStyle.AlternateUnitToleranceDecimalPlaces = _objectReader.ReadBitShort();
			dimensionStyle.ScaleFactor = _objectReader.ReadBitDouble();
			dimensionStyle.ArrowSize = _objectReader.ReadBitDouble();
			dimensionStyle.ExtensionLineOffset = _objectReader.ReadBitDouble();
			dimensionStyle.DimensionLineIncrement = _objectReader.ReadBitDouble();
			dimensionStyle.ExtensionLineExtension = _objectReader.ReadBitDouble();
			dimensionStyle.Rounding = _objectReader.ReadBitDouble();
			dimensionStyle.DimensionLineExtension = _objectReader.ReadBitDouble();
			dimensionStyle.PlusTolerance = _objectReader.ReadBitDouble();
			dimensionStyle.MinusTolerance = _objectReader.ReadBitDouble();
			dimensionStyle.TextHeight = _objectReader.ReadBitDouble();
			dimensionStyle.CenterMarkSize = _objectReader.ReadBitDouble();
			dimensionStyle.TickSize = _objectReader.ReadBitDouble();
			dimensionStyle.AlternateUnitScaleFactor = _objectReader.ReadBitDouble();
			dimensionStyle.LinearScaleFactor = _objectReader.ReadBitDouble();
			dimensionStyle.TextVerticalPosition = _objectReader.ReadBitDouble();
			dimensionStyle.ToleranceScaleFactor = _objectReader.ReadBitDouble();
			dimensionStyle.DimensionLineGap = _objectReader.ReadBitDouble();
			dimensionStyle.PostFix = _textReader.ReadVariableText();
			dimensionStyle.AlternateDimensioningSuffix = _textReader.ReadVariableText();
			cadDimensionStyleTemplate.DIMBL_Name = _textReader.ReadVariableText();
			cadDimensionStyleTemplate.DIMBLK1_Name = _textReader.ReadVariableText();
			cadDimensionStyleTemplate.DIMBLK2_Name = _textReader.ReadVariableText();
			dimensionStyle.DimensionLineColor = _objectReader.ReadColorByIndex();
			dimensionStyle.ExtensionLineColor = _objectReader.ReadColorByIndex();
			dimensionStyle.TextColor = _objectReader.ReadColorByIndex();
		}
		if (R2000Plus)
		{
			dimensionStyle.PostFix = _textReader.ReadVariableText();
			dimensionStyle.AlternateDimensioningSuffix = _textReader.ReadVariableText();
			dimensionStyle.ScaleFactor = _objectReader.ReadBitDouble();
			dimensionStyle.ArrowSize = _objectReader.ReadBitDouble();
			dimensionStyle.ExtensionLineOffset = _objectReader.ReadBitDouble();
			dimensionStyle.DimensionLineIncrement = _objectReader.ReadBitDouble();
			dimensionStyle.ExtensionLineExtension = _objectReader.ReadBitDouble();
			dimensionStyle.Rounding = _objectReader.ReadBitDouble();
			dimensionStyle.DimensionLineExtension = _objectReader.ReadBitDouble();
			dimensionStyle.PlusTolerance = _objectReader.ReadBitDouble();
			dimensionStyle.MinusTolerance = _objectReader.ReadBitDouble();
		}
		if (R2007Plus)
		{
			dimensionStyle.FixedExtensionLineLength = _objectReader.ReadBitDouble();
			dimensionStyle.JoggedRadiusDimensionTransverseSegmentAngle = _objectReader.ReadBitDouble();
			dimensionStyle.TextBackgroundFillMode = (DimensionTextBackgroundFillMode)_objectReader.ReadBitShort();
			dimensionStyle.TextBackgroundColor = _mergedReaders.ReadCmColor();
		}
		if (R2000Plus)
		{
			dimensionStyle.GenerateTolerances = _objectReader.ReadBit();
			dimensionStyle.LimitsGeneration = _objectReader.ReadBit();
			dimensionStyle.TextInsideHorizontal = _objectReader.ReadBit();
			dimensionStyle.TextOutsideHorizontal = _objectReader.ReadBit();
			dimensionStyle.SuppressFirstExtensionLine = _objectReader.ReadBit();
			dimensionStyle.SuppressSecondExtensionLine = _objectReader.ReadBit();
			dimensionStyle.TextVerticalAlignment = (DimensionTextVerticalAlignment)_objectReader.ReadBitShort();
			dimensionStyle.ZeroHandling = (ZeroHandling)_objectReader.ReadBitShort();
			dimensionStyle.AngularZeroHandling = (ZeroHandling)_objectReader.ReadBitShort();
		}
		if (R2007Plus)
		{
			dimensionStyle.ArcLengthSymbolPosition = (ArcLengthSymbolPosition)_objectReader.ReadBitShort();
		}
		if (R2000Plus)
		{
			dimensionStyle.TextHeight = _objectReader.ReadBitDouble();
			dimensionStyle.CenterMarkSize = _objectReader.ReadBitDouble();
			dimensionStyle.TickSize = _objectReader.ReadBitDouble();
			dimensionStyle.AlternateUnitScaleFactor = _objectReader.ReadBitDouble();
			dimensionStyle.LinearScaleFactor = _objectReader.ReadBitDouble();
			dimensionStyle.TextVerticalPosition = _objectReader.ReadBitDouble();
			dimensionStyle.ToleranceScaleFactor = _objectReader.ReadBitDouble();
			dimensionStyle.DimensionLineGap = _objectReader.ReadBitDouble();
			dimensionStyle.AlternateUnitRounding = _objectReader.ReadBitDouble();
			dimensionStyle.AlternateUnitDimensioning = _objectReader.ReadBit();
			dimensionStyle.AlternateUnitDecimalPlaces = _objectReader.ReadBitShort();
			dimensionStyle.TextOutsideExtensions = _objectReader.ReadBit();
			dimensionStyle.SeparateArrowBlocks = _objectReader.ReadBit();
			dimensionStyle.TextInsideExtensions = _objectReader.ReadBit();
			dimensionStyle.SuppressOutsideExtensions = _objectReader.ReadBit();
			dimensionStyle.DimensionLineColor = _mergedReaders.ReadCmColor();
			dimensionStyle.ExtensionLineColor = _mergedReaders.ReadCmColor();
			dimensionStyle.TextColor = _mergedReaders.ReadCmColor();
			dimensionStyle.AngularDecimalPlaces = _objectReader.ReadBitShort();
			dimensionStyle.DecimalPlaces = _objectReader.ReadBitShort();
			dimensionStyle.ToleranceDecimalPlaces = _objectReader.ReadBitShort();
			dimensionStyle.AlternateUnitFormat = (LinearUnitFormat)_objectReader.ReadBitShort();
			dimensionStyle.AlternateUnitToleranceDecimalPlaces = _objectReader.ReadBitShort();
			dimensionStyle.AngularUnit = (AngularUnitFormat)_objectReader.ReadBitShort();
			dimensionStyle.FractionFormat = (FractionFormat)_objectReader.ReadBitShort();
			dimensionStyle.LinearUnitFormat = (LinearUnitFormat)_objectReader.ReadBitShort();
			dimensionStyle.DecimalSeparator = (char)_objectReader.ReadBitShort();
			dimensionStyle.TextMovement = (TextMovement)_objectReader.ReadBitShort();
			dimensionStyle.TextHorizontalAlignment = (DimensionTextHorizontalAlignment)_objectReader.ReadBitShort();
			dimensionStyle.SuppressFirstDimensionLine = _objectReader.ReadBit();
			dimensionStyle.SuppressSecondDimensionLine = _objectReader.ReadBit();
			dimensionStyle.ToleranceAlignment = (ToleranceAlignment)_objectReader.ReadBitShort();
			dimensionStyle.ToleranceZeroHandling = (ZeroHandling)_objectReader.ReadBitShort();
			dimensionStyle.AlternateUnitZeroHandling = (ZeroHandling)_objectReader.ReadBitShort();
			dimensionStyle.AlternateUnitToleranceZeroHandling = (ZeroHandling)_objectReader.ReadBitShort();
			dimensionStyle.CursorUpdate = _objectReader.ReadBit();
			dimensionStyle.DimensionFit = _objectReader.ReadBitShort();
		}
		if (R2007Plus)
		{
			dimensionStyle.IsExtensionLineLengthFixed = _objectReader.ReadBit();
		}
		if (R2010Plus)
		{
			dimensionStyle.TextDirection = (_objectReader.ReadBit() ? TextDirection.RightToLeft : TextDirection.LeftToRight);
			dimensionStyle.AltMzf = _objectReader.ReadBitDouble();
			dimensionStyle.AltMzs = _textReader.ReadVariableText();
			dimensionStyle.Mzf = _objectReader.ReadBitDouble();
			dimensionStyle.Mzs = _textReader.ReadVariableText();
		}
		if (R2000Plus)
		{
			dimensionStyle.DimensionLineWeight = (LineWeightType)_objectReader.ReadBitShort();
			dimensionStyle.ExtensionLineWeight = (LineWeightType)_objectReader.ReadBitShort();
		}
		_objectReader.ReadBit();
		cadDimensionStyleTemplate.BlockHandle = handleReference();
		cadDimensionStyleTemplate.TextStyleHandle = handleReference();
		if (R2000Plus)
		{
			cadDimensionStyleTemplate.DIMLDRBLK = handleReference();
			cadDimensionStyleTemplate.DIMBLK = handleReference();
			cadDimensionStyleTemplate.DIMBLK1 = handleReference();
			cadDimensionStyleTemplate.DIMBLK2 = handleReference();
		}
		if (R2007Plus)
		{
			cadDimensionStyleTemplate.Dimltype = handleReference();
			cadDimensionStyleTemplate.Dimltex1 = handleReference();
			cadDimensionStyleTemplate.Dimltex2 = handleReference();
		}
		return cadDimensionStyleTemplate;
	}

	private CadTemplate readViewportEntityControl()
	{
		CadViewportEntityControlTemplate cadViewportEntityControlTemplate = new CadViewportEntityControlTemplate();
		readCommonNonEntityData(cadViewportEntityControlTemplate);
		int num = _objectReader.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			cadViewportEntityControlTemplate.EntryHandles.Add(handleReference());
		}
		return cadViewportEntityControlTemplate;
	}

	private CadTemplate readViewportEntityHeader()
	{
		ViewportEntityHeader viewportEntityHeader = new ViewportEntityHeader();
		CadViewportEntityHeaderTemplate cadViewportEntityHeaderTemplate = new CadViewportEntityHeaderTemplate(viewportEntityHeader);
		readCommonNonEntityData(cadViewportEntityHeaderTemplate);
		viewportEntityHeader.Name = _textReader.ReadVariableText();
		readXrefDependantBit(cadViewportEntityHeaderTemplate.CadObject);
		_objectReader.ReadBit();
		handleReference();
		handleReference();
		cadViewportEntityHeaderTemplate.BlockHandle = handleReference();
		return cadViewportEntityHeaderTemplate;
	}

	private CadTemplate readGeoData()
	{
		GeoData geoData = new GeoData();
		CadGeoDataTemplate cadGeoDataTemplate = new CadGeoDataTemplate(geoData);
		readCommonNonEntityData(cadGeoDataTemplate);
		geoData.Version = (GeoDataVersion)_mergedReaders.ReadBitLong();
		cadGeoDataTemplate.HostBlockHandle = handleReference();
		geoData.CoordinatesType = (DesignCoordinatesType)_mergedReaders.ReadBitShort();
		switch (geoData.Version)
		{
		case GeoDataVersion.R2009:
		{
			geoData.ReferencePoint = _mergedReaders.Read3BitDouble();
			geoData.HorizontalUnits = (UnitsType)_mergedReaders.ReadBitLong();
			geoData.VerticalUnits = geoData.HorizontalUnits;
			geoData.DesignPoint = _mergedReaders.Read3BitDouble();
			_mergedReaders.Read3BitDouble();
			geoData.UpDirection = _mergedReaders.Read3BitDouble();
			double num = Math.PI / 2.0 - _mergedReaders.ReadBitDouble();
			geoData.NorthDirection = new XY(Math.Cos(num), Math.Sin(num));
			_mergedReaders.Read3BitDouble();
			geoData.CoordinateSystemDefinition = _mergedReaders.ReadVariableText();
			geoData.GeoRssTag = _mergedReaders.ReadVariableText();
			geoData.HorizontalUnitScale = _mergedReaders.ReadBitDouble();
			geoData.VerticalUnitScale = geoData.HorizontalUnitScale;
			_mergedReaders.ReadVariableText();
			_mergedReaders.ReadVariableText();
			break;
		}
		case GeoDataVersion.R2010:
		case GeoDataVersion.R2013:
			geoData.DesignPoint = _mergedReaders.Read3BitDouble();
			geoData.ReferencePoint = _mergedReaders.Read3BitDouble();
			geoData.HorizontalUnitScale = _mergedReaders.ReadBitDouble();
			geoData.HorizontalUnits = (UnitsType)_mergedReaders.ReadBitLong();
			geoData.VerticalUnitScale = _mergedReaders.ReadBitDouble();
			geoData.HorizontalUnits = (UnitsType)_mergedReaders.ReadBitLong();
			geoData.UpDirection = _mergedReaders.Read3BitDouble();
			geoData.NorthDirection = _mergedReaders.Read2RawDouble();
			geoData.ScaleEstimationMethod = (ScaleEstimationType)_mergedReaders.ReadBitLong();
			geoData.UserSpecifiedScaleFactor = _mergedReaders.ReadBitDouble();
			geoData.EnableSeaLevelCorrection = _mergedReaders.ReadBit();
			geoData.SeaLevelElevation = _mergedReaders.ReadBitDouble();
			geoData.CoordinateProjectionRadius = _mergedReaders.ReadBitDouble();
			geoData.CoordinateSystemDefinition = _mergedReaders.ReadVariableText();
			geoData.GeoRssTag = _mergedReaders.ReadVariableText();
			break;
		}
		geoData.ObservationFromTag = _mergedReaders.ReadVariableText();
		geoData.ObservationToTag = _mergedReaders.ReadVariableText();
		geoData.ObservationCoverageTag = _mergedReaders.ReadVariableText();
		int num2 = _mergedReaders.ReadBitLong();
		for (int i = 0; i < num2; i++)
		{
			GeoData.GeoMeshPoint geoMeshPoint = new GeoData.GeoMeshPoint();
			geoMeshPoint.Source = _mergedReaders.Read2RawDouble();
			geoMeshPoint.Destination = _mergedReaders.Read2RawDouble();
			geoData.Points.Add(geoMeshPoint);
		}
		int num3 = _mergedReaders.ReadBitLong();
		for (int j = 0; j < num3; j++)
		{
			GeoData.GeoMeshFace geoMeshFace = new GeoData.GeoMeshFace();
			geoMeshFace.Index1 = _mergedReaders.ReadBitLong();
			geoMeshFace.Index2 = _mergedReaders.ReadBitLong();
			geoMeshFace.Index3 = _mergedReaders.ReadBitLong();
			geoData.Faces.Add(geoMeshFace);
		}
		return cadGeoDataTemplate;
	}

	private CadTemplate readGroup()
	{
		Group obj = new Group();
		CadGroupTemplate cadGroupTemplate = new CadGroupTemplate(obj);
		readCommonNonEntityData(cadGroupTemplate);
		obj.Description = _textReader.ReadVariableText();
		_objectReader.ReadBitShort();
		obj.Selectable = _objectReader.ReadBitShort() > 0;
		int num = _objectReader.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			cadGroupTemplate.Handles.Add(handleReference());
		}
		return cadGroupTemplate;
	}

	private CadTemplate readOle2Frame()
	{
		Ole2Frame ole2Frame = new Ole2Frame();
		CadOle2FrameTemplate cadOle2FrameTemplate = new CadOle2FrameTemplate(ole2Frame);
		readCommonEntityData(cadOle2FrameTemplate);
		ole2Frame.Version = _mergedReaders.ReadBitShort();
		if (R2000Plus)
		{
			_mergedReaders.ReadBitShort();
		}
		int length = _mergedReaders.ReadBitLong();
		cadOle2FrameTemplate.CadObject.BinaryData = _mergedReaders.ReadBytes(length);
		if (R2000Plus)
		{
			_mergedReaders.ReadByte();
		}
		return cadOle2FrameTemplate;
	}

	private CadTemplate readMLineStyle()
	{
		MLineStyle mLineStyle = new MLineStyle();
		CadMLineStyleTemplate cadMLineStyleTemplate = new CadMLineStyleTemplate(mLineStyle);
		readCommonNonEntityData(cadMLineStyleTemplate);
		mLineStyle.Name = _textReader.ReadVariableText();
		mLineStyle.Description = _textReader.ReadVariableText();
		short num = _objectReader.ReadBitShort();
		if ((num & 1) != 0)
		{
			mLineStyle.Flags |= MLineStyleFlags.DisplayJoints;
		}
		if ((num & 2) != 0)
		{
			mLineStyle.Flags |= MLineStyleFlags.FillOn;
		}
		if ((num & 0x10) != 0)
		{
			mLineStyle.Flags |= MLineStyleFlags.StartSquareCap;
		}
		if ((num & 0x20) != 0)
		{
			mLineStyle.Flags |= MLineStyleFlags.StartRoundCap;
		}
		if ((num & 0x40) != 0)
		{
			mLineStyle.Flags |= MLineStyleFlags.StartInnerArcsCap;
		}
		if ((num & 0x100) != 0)
		{
			mLineStyle.Flags |= MLineStyleFlags.EndSquareCap;
		}
		if ((num & 0x200) != 0)
		{
			mLineStyle.Flags |= MLineStyleFlags.EndRoundCap;
		}
		if ((num & 0x400) != 0)
		{
			mLineStyle.Flags |= MLineStyleFlags.EndInnerArcsCap;
		}
		mLineStyle.FillColor = _mergedReaders.ReadCmColor();
		mLineStyle.StartAngle = _objectReader.ReadBitDouble();
		mLineStyle.EndAngle = _objectReader.ReadBitDouble();
		int num2 = _objectReader.ReadByte();
		for (int i = 0; i < num2; i++)
		{
			MLineStyle.Element element = new MLineStyle.Element();
			CadMLineStyleTemplate.ElementTemplate elementTemplate = new CadMLineStyleTemplate.ElementTemplate(element);
			element.Offset = _objectReader.ReadBitDouble();
			element.Color = _mergedReaders.ReadCmColor();
			if (R2018Plus)
			{
				elementTemplate.LineTypeHandle = handleReference();
			}
			else
			{
				elementTemplate.LinetypeIndex = _objectReader.ReadBitShort();
			}
			cadMLineStyleTemplate.ElementTemplates.Add(elementTemplate);
			mLineStyle.AddElement(element);
		}
		return cadMLineStyleTemplate;
	}

	private CadTemplate readLWPolyline()
	{
		LwPolyline lwPolyline = new LwPolyline();
		CadEntityTemplate cadEntityTemplate = new CadEntityTemplate(lwPolyline);
		try
		{
			readCommonEntityData(cadEntityTemplate);
			short num = _objectReader.ReadBitShort();
			if ((num & 0x100) != 0)
			{
				lwPolyline.Flags |= LwPolylineFlags.Plinegen;
			}
			if ((num & 0x200) != 0)
			{
				lwPolyline.Flags |= LwPolylineFlags.Closed;
			}
			if (((ulong)num & 4uL) != 0L)
			{
				lwPolyline.ConstantWidth = _objectReader.ReadBitDouble();
			}
			if (((ulong)num & 8uL) != 0L)
			{
				lwPolyline.Elevation = _objectReader.ReadBitDouble();
			}
			if (((ulong)num & 2uL) != 0L)
			{
				lwPolyline.Thickness = _objectReader.ReadBitDouble();
			}
			if (((ulong)num & 1uL) != 0L)
			{
				lwPolyline.Normal = _objectReader.Read3BitDouble();
			}
			int num2 = _objectReader.ReadBitLong();
			int num3 = 0;
			if ((num & 0x10) != 0)
			{
				num3 = _objectReader.ReadBitLong();
			}
			int num4 = 0;
			if ((num & 0x400) != 0)
			{
				num4 = _objectReader.ReadBitLong();
			}
			int num5 = 0;
			if ((num & 0x20) != 0)
			{
				num5 = _objectReader.ReadBitLong();
			}
			if (R13_14Only)
			{
				for (int i = 0; i < num2; i++)
				{
					new Vertex2D();
					XY location = _objectReader.Read2RawDouble();
					lwPolyline.Vertices.Add(new LwPolyline.Vertex(location));
				}
			}
			if (R2000Plus && num2 > 0)
			{
				XY xY = _objectReader.Read2RawDouble();
				lwPolyline.Vertices.Add(new LwPolyline.Vertex(xY));
				for (int j = 1; j < num2; j++)
				{
					xY = _objectReader.Read2BitDoubleWithDefault(xY);
					lwPolyline.Vertices.Add(new LwPolyline.Vertex(xY));
				}
			}
			for (int k = 0; k < num3; k++)
			{
				lwPolyline.Vertices[k].Bulge = _objectReader.ReadBitDouble();
			}
			for (int l = 0; l < num4; l++)
			{
				lwPolyline.Vertices[l].Id = _objectReader.ReadBitLong();
			}
			for (int m = 0; m < num5; m++)
			{
				LwPolyline.Vertex vertex = lwPolyline.Vertices[m];
				vertex.StartWidth = _objectReader.ReadBitDouble();
				vertex.EndWidth = _objectReader.ReadBitDouble();
			}
			return cadEntityTemplate;
		}
		catch (Exception ex)
		{
			_builder.Notify("Exception while reading LwPolyline: " + ex.GetType().FullName, NotificationType.Error, ex);
			return cadEntityTemplate;
		}
	}

	private CadTemplate readMaterial()
	{
		Material material = new Material();
		CadMaterialTemplate cadMaterialTemplate = new CadMaterialTemplate(material);
		readCommonNonEntityData(cadMaterialTemplate);
		material.Name = _mergedReaders.ReadVariableText();
		material.Description = _mergedReaders.ReadVariableText();
		material.AmbientColorMethod = (ColorMethod)_mergedReaders.ReadByte();
		material.AmbientColorFactor = _mergedReaders.ReadBitDouble();
		if (material.AmbientColorMethod == ColorMethod.Override)
		{
			uint value = (uint)_mergedReaders.ReadBitLong();
			byte[] bytes = LittleEndianConverter.Instance.GetBytes(value);
			material.AmbientColor = new Color(bytes[2], bytes[1], bytes[0]);
		}
		material.DiffuseColorMethod = (ColorMethod)_mergedReaders.ReadByte();
		material.DiffuseColorFactor = _mergedReaders.ReadBitDouble();
		if (material.DiffuseColorMethod == ColorMethod.Override)
		{
			uint value2 = (uint)_mergedReaders.ReadBitLong();
			byte[] bytes2 = LittleEndianConverter.Instance.GetBytes(value2);
			material.DiffuseColor = new Color(bytes2[2], bytes2[1], bytes2[0]);
		}
		material.DiffuseMapBlendFactor = _mergedReaders.ReadBitDouble();
		material.DiffuseProjectionMethod = (ProjectionMethod)_mergedReaders.ReadByte();
		material.DiffuseTilingMethod = (TilingMethod)_mergedReaders.ReadByte();
		material.DiffuseAutoTransform = (AutoTransformMethodFlags)_mergedReaders.ReadByte();
		material.DiffuseMatrix = readMatrix4();
		material.DiffuseMapSource = (MapSource)_mergedReaders.ReadByte();
		switch (material.DiffuseMapSource)
		{
		case MapSource.UseImageFile:
			material.DiffuseMapFileName = _mergedReaders.ReadVariableText();
			break;
		case MapSource.Procedural:
			throw new NotImplementedException();
		}
		material.SpecularColorMethod = (ColorMethod)_mergedReaders.ReadByte();
		material.SpecularColorFactor = _mergedReaders.ReadBitDouble();
		if (material.SpecularColorMethod == ColorMethod.Override)
		{
			uint value3 = (uint)_mergedReaders.ReadBitLong();
			byte[] bytes3 = LittleEndianConverter.Instance.GetBytes(value3);
			material.SpecularColor = new Color(bytes3[2], bytes3[1], bytes3[0]);
		}
		material.SpecularMapBlendFactor = _mergedReaders.ReadBitDouble();
		material.SpecularProjectionMethod = (ProjectionMethod)_mergedReaders.ReadByte();
		material.SpecularTilingMethod = (TilingMethod)_mergedReaders.ReadByte();
		material.SpecularAutoTransform = (AutoTransformMethodFlags)_mergedReaders.ReadByte();
		material.SpecularMatrix = readMatrix4();
		material.SpecularMapSource = (MapSource)_mergedReaders.ReadByte();
		switch (material.SpecularMapSource)
		{
		case MapSource.UseImageFile:
			material.SpecularMapFileName = _mergedReaders.ReadVariableText();
			break;
		case MapSource.Procedural:
			throw new NotImplementedException();
		}
		material.SpecularGlossFactor = _mergedReaders.ReadBitDouble();
		material.ReflectionMapBlendFactor = _mergedReaders.ReadBitDouble();
		material.ReflectionProjectionMethod = (ProjectionMethod)_mergedReaders.ReadByte();
		material.ReflectionTilingMethod = (TilingMethod)_mergedReaders.ReadByte();
		material.ReflectionAutoTransform = (AutoTransformMethodFlags)_mergedReaders.ReadByte();
		material.ReflectionMatrix = readMatrix4();
		material.ReflectionMapSource = (MapSource)_mergedReaders.ReadByte();
		switch (material.ReflectionMapSource)
		{
		case MapSource.UseImageFile:
			material.ReflectionMapFileName = _mergedReaders.ReadVariableText();
			break;
		case MapSource.Procedural:
			throw new NotImplementedException();
		}
		material.Opacity = _mergedReaders.ReadBitDouble();
		material.OpacityMapBlendFactor = _mergedReaders.ReadBitDouble();
		material.OpacityProjectionMethod = (ProjectionMethod)_mergedReaders.ReadByte();
		material.OpacityTilingMethod = (TilingMethod)_mergedReaders.ReadByte();
		material.OpacityAutoTransform = (AutoTransformMethodFlags)_mergedReaders.ReadByte();
		material.OpacityMatrix = readMatrix4();
		material.OpacityMapSource = (MapSource)_mergedReaders.ReadByte();
		switch (material.OpacityMapSource)
		{
		case MapSource.UseImageFile:
			material.OpacityMapFileName = _mergedReaders.ReadVariableText();
			break;
		case MapSource.Procedural:
			throw new NotImplementedException();
		}
		material.BumpMapBlendFactor = _mergedReaders.ReadBitDouble();
		material.BumpProjectionMethod = (ProjectionMethod)_mergedReaders.ReadByte();
		material.BumpTilingMethod = (TilingMethod)_mergedReaders.ReadByte();
		material.BumpAutoTransform = (AutoTransformMethodFlags)_mergedReaders.ReadByte();
		material.BumpMatrix = readMatrix4();
		material.BumpMapSource = (MapSource)_mergedReaders.ReadByte();
		switch (material.BumpMapSource)
		{
		case MapSource.UseImageFile:
			material.BumpMapFileName = _mergedReaders.ReadVariableText();
			break;
		case MapSource.Procedural:
			throw new NotImplementedException();
		}
		material.RefractionIndex = _mergedReaders.ReadBitDouble();
		material.RefractionMapBlendFactor = _mergedReaders.ReadBitDouble();
		material.RefractionProjectionMethod = (ProjectionMethod)_mergedReaders.ReadByte();
		material.RefractionTilingMethod = (TilingMethod)_mergedReaders.ReadByte();
		material.RefractionAutoTransform = (AutoTransformMethodFlags)_mergedReaders.ReadByte();
		material.RefractionMatrix = readMatrix4();
		material.RefractionMapSource = (MapSource)_mergedReaders.ReadByte();
		switch (material.RefractionMapSource)
		{
		case MapSource.UseImageFile:
			material.RefractionMapFileName = _mergedReaders.ReadVariableText();
			break;
		case MapSource.Procedural:
			throw new NotImplementedException();
		}
		return cadMaterialTemplate;
	}

	private Matrix4 readMatrix4()
	{
		Matrix4 identity = Matrix4.Identity;
		identity.M00 = _mergedReaders.ReadBitDouble();
		identity.M01 = _mergedReaders.ReadBitDouble();
		identity.M02 = _mergedReaders.ReadBitDouble();
		identity.M03 = _mergedReaders.ReadBitDouble();
		identity.M10 = _mergedReaders.ReadBitDouble();
		identity.M11 = _mergedReaders.ReadBitDouble();
		identity.M12 = _mergedReaders.ReadBitDouble();
		identity.M13 = _mergedReaders.ReadBitDouble();
		identity.M20 = _mergedReaders.ReadBitDouble();
		identity.M21 = _mergedReaders.ReadBitDouble();
		identity.M22 = _mergedReaders.ReadBitDouble();
		identity.M23 = _mergedReaders.ReadBitDouble();
		identity.M30 = _mergedReaders.ReadBitDouble();
		identity.M31 = _mergedReaders.ReadBitDouble();
		identity.M32 = _mergedReaders.ReadBitDouble();
		identity.M33 = _mergedReaders.ReadBitDouble();
		return Matrix4.Identity;
	}

	private CadTemplate readHatch()
	{
		Hatch hatch = new Hatch();
		CadHatchTemplate cadHatchTemplate = new CadHatchTemplate(hatch);
		readCommonEntityData(cadHatchTemplate);
		if (R2004Plus)
		{
			hatch.GradientColor.Enabled = _objectReader.ReadBitLong() != 0;
			hatch.GradientColor.Reserved = _objectReader.ReadBitLong();
			hatch.GradientColor.Angle = _objectReader.ReadBitDouble();
			hatch.GradientColor.Shift = _objectReader.ReadBitDouble();
			hatch.GradientColor.IsSingleColorGradient = _objectReader.ReadBitLong() != 0;
			hatch.GradientColor.ColorTint = _objectReader.ReadBitDouble();
			int num = _objectReader.ReadBitLong();
			for (int i = 0; i < num; i++)
			{
				GradientColor gradientColor = new GradientColor();
				gradientColor.Value = _objectReader.ReadBitDouble();
				gradientColor.Color = _mergedReaders.ReadCmColor();
				hatch.GradientColor.Colors.Add(gradientColor);
			}
			hatch.GradientColor.Name = _textReader.ReadVariableText();
		}
		hatch.Elevation = _objectReader.ReadBitDouble();
		hatch.Normal = _objectReader.Read3BitDouble();
		hatch.Pattern = new HatchPattern(_textReader.ReadVariableText());
		hatch.IsSolid = _objectReader.ReadBit();
		hatch.IsAssociative = _objectReader.ReadBit();
		int num2 = _objectReader.ReadBitLong();
		bool flag = false;
		for (int j = 0; j < num2; j++)
		{
			CadHatchTemplate.CadBoundaryPathTemplate cadBoundaryPathTemplate = new CadHatchTemplate.CadBoundaryPathTemplate();
			BoundaryPathFlags boundaryPathFlags = (BoundaryPathFlags)_objectReader.ReadBitLong();
			cadBoundaryPathTemplate.Path.Flags = boundaryPathFlags;
			if (cadBoundaryPathTemplate.Path.Flags.HasFlag(BoundaryPathFlags.Derived))
			{
				flag = true;
			}
			if (!boundaryPathFlags.HasFlag(BoundaryPathFlags.Polyline))
			{
				int num3 = _objectReader.ReadBitLong();
				for (int k = 0; k < num3; k++)
				{
					switch ((Hatch.BoundaryPath.EdgeType)_objectReader.ReadByte())
					{
					case Hatch.BoundaryPath.EdgeType.Line:
						cadBoundaryPathTemplate.Path.Edges.Add(new Hatch.BoundaryPath.Line
						{
							Start = _objectReader.Read2RawDouble(),
							End = _objectReader.Read2RawDouble()
						});
						break;
					case Hatch.BoundaryPath.EdgeType.CircularArc:
						cadBoundaryPathTemplate.Path.Edges.Add(new Hatch.BoundaryPath.Arc
						{
							Center = _objectReader.Read2RawDouble(),
							Radius = _objectReader.ReadBitDouble(),
							StartAngle = _objectReader.ReadBitDouble(),
							EndAngle = _objectReader.ReadBitDouble(),
							CounterClockWise = _objectReader.ReadBit()
						});
						break;
					case Hatch.BoundaryPath.EdgeType.EllipticArc:
						cadBoundaryPathTemplate.Path.Edges.Add(new Hatch.BoundaryPath.Ellipse
						{
							Center = _objectReader.Read2RawDouble(),
							MajorAxisEndPoint = _objectReader.Read2RawDouble(),
							MinorToMajorRatio = _objectReader.ReadBitDouble(),
							StartAngle = _objectReader.ReadBitDouble(),
							EndAngle = _objectReader.ReadBitDouble(),
							CounterClockWise = _objectReader.ReadBit()
						});
						break;
					case Hatch.BoundaryPath.EdgeType.Spline:
					{
						Hatch.BoundaryPath.Spline spline = new Hatch.BoundaryPath.Spline();
						spline.Degree = _objectReader.ReadBitLong();
						spline.Rational = _objectReader.ReadBit();
						spline.Periodic = _objectReader.ReadBit();
						int num4 = _objectReader.ReadBitLong();
						int num5 = _objectReader.ReadBitLong();
						for (int l = 0; l < num4; l++)
						{
							spline.Knots.Add(_objectReader.ReadBitDouble());
						}
						for (int m = 0; m < num5; m++)
						{
							XY xY = _objectReader.Read2RawDouble();
							double z = 0.0;
							if (spline.Rational)
							{
								z = _objectReader.ReadBitDouble();
							}
							spline.ControlPoints.Add(new XYZ(xY.X, xY.Y, z));
						}
						if (R2010Plus)
						{
							int num6 = _objectReader.ReadBitLong();
							if (num6 > 0)
							{
								for (int n = 0; n < num6; n++)
								{
									spline.FitPoints.Add(_objectReader.Read2RawDouble());
								}
								spline.StartTangent = _objectReader.Read2RawDouble();
								spline.EndTangent = _objectReader.Read2RawDouble();
							}
						}
						cadBoundaryPathTemplate.Path.Edges.Add(spline);
						break;
					}
					}
				}
			}
			else
			{
				Hatch.BoundaryPath.Polyline polyline = new Hatch.BoundaryPath.Polyline();
				bool flag2 = _objectReader.ReadBit();
				polyline.IsClosed = _objectReader.ReadBit();
				int num7 = _objectReader.ReadBitLong();
				for (int num8 = 0; num8 < num7; num8++)
				{
					XY xY2 = _objectReader.Read2RawDouble();
					double z2 = 0.0;
					if (flag2)
					{
						z2 = _objectReader.ReadBitDouble();
					}
					polyline.Vertices.Add(new XYZ(xY2.X, xY2.Y, z2));
				}
				cadBoundaryPathTemplate.Path.Edges.Add(polyline);
			}
			int num9 = _objectReader.ReadBitLong();
			for (int num10 = 0; num10 < num9; num10++)
			{
				cadBoundaryPathTemplate.Handles.Add(handleReference());
			}
			cadHatchTemplate.PathTemplates.Add(cadBoundaryPathTemplate);
		}
		hatch.Style = (HatchStyleType)_objectReader.ReadBitShort();
		hatch.PatternType = (HatchPatternType)_objectReader.ReadBitShort();
		if (!hatch.IsSolid)
		{
			hatch.PatternAngle = _objectReader.ReadBitDouble();
			hatch.PatternScale = _objectReader.ReadBitDouble();
			hatch.IsDouble = _objectReader.ReadBit();
			int num11 = _objectReader.ReadBitShort();
			for (int num12 = 0; num12 < num11; num12++)
			{
				HatchPattern.Line line = new HatchPattern.Line();
				line.Angle = _objectReader.ReadBitDouble();
				line.BasePoint = _objectReader.Read2BitDouble();
				line.Offset = _objectReader.Read2BitDouble();
				int num13 = _objectReader.ReadBitShort();
				for (int num14 = 0; num14 < num13; num14++)
				{
					line.DashLengths.Add(_objectReader.ReadBitDouble());
				}
				hatch.Pattern.Lines.Add(line);
			}
		}
		if (flag)
		{
			hatch.PixelSize = _objectReader.ReadBitDouble();
		}
		int num15 = _objectReader.ReadBitLong();
		for (int num16 = 0; num16 < num15; num16++)
		{
			XY item = _objectReader.Read2RawDouble();
			hatch.SeedPoints.Add(item);
		}
		return cadHatchTemplate;
	}

	private CadTemplate readSortentsTable()
	{
		CadSortensTableTemplate cadSortensTableTemplate = new CadSortensTableTemplate(new SortEntitiesTable());
		readCommonNonEntityData(cadSortensTableTemplate);
		cadSortensTableTemplate.BlockOwnerHandle = handleReference();
		int num = _mergedReaders.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			ulong value = _objectReader.HandleReference();
			ulong value2 = handleReference();
			cadSortensTableTemplate.Values.Add((value, value2));
		}
		return cadSortensTableTemplate;
	}

	private CadTemplate readRasterVariables()
	{
		RasterVariables rasterVariables = new RasterVariables();
		CadNonGraphicalObjectTemplate cadNonGraphicalObjectTemplate = new CadNonGraphicalObjectTemplate(rasterVariables);
		readCommonNonEntityData(cadNonGraphicalObjectTemplate);
		rasterVariables.ClassVersion = _mergedReaders.ReadBitLong();
		rasterVariables.IsDisplayFrameShown = _mergedReaders.ReadBitShort() != 0;
		rasterVariables.DisplayQuality = (ImageDisplayQuality)_mergedReaders.ReadBitShort();
		rasterVariables.Units = (ImageUnits)_mergedReaders.ReadBitShort();
		return cadNonGraphicalObjectTemplate;
	}

	private CadTemplate readVisualStyle()
	{
		VisualStyle visualStyle = new VisualStyle();
		CadTemplate<VisualStyle> cadTemplate = new CadTemplate<VisualStyle>(visualStyle);
		readCommonNonEntityData(cadTemplate);
		visualStyle.Name = _textReader.ReadVariableText();
		visualStyle.Type = _objectReader.ReadBitLong();
		_objectReader.ReadBitShort();
		_objectReader.ReadBit();
		_objectReader.ReadBitLong();
		return cadTemplate;
	}

	private CadTemplate readCadImage(CadWipeoutBase image)
	{
		CadWipeoutBaseTemplate cadWipeoutBaseTemplate = new CadWipeoutBaseTemplate(image);
		readCommonEntityData(cadWipeoutBaseTemplate);
		image.ClassVersion = _objectReader.ReadBitLong();
		image.InsertPoint = _objectReader.Read3BitDouble();
		image.UVector = _objectReader.Read3BitDouble();
		image.VVector = _objectReader.Read3BitDouble();
		image.Size = _objectReader.Read2RawDouble();
		image.Flags = (ImageDisplayFlags)_objectReader.ReadBitShort();
		image.ClippingState = _objectReader.ReadBit();
		image.Brightness = _objectReader.ReadByte();
		image.Contrast = _objectReader.ReadByte();
		image.Fade = _objectReader.ReadByte();
		if (R2010Plus)
		{
			image.ClipMode = (_objectReader.ReadBit() ? ClipMode.Inside : ClipMode.Outside);
		}
		image.ClipType = (ClipType)_objectReader.ReadBitShort();
		switch (image.ClipType)
		{
		case ClipType.Rectangular:
			image.ClipBoundaryVertices.Add(_objectReader.Read2RawDouble());
			image.ClipBoundaryVertices.Add(_objectReader.Read2RawDouble());
			break;
		case ClipType.Polygonal:
		{
			int num = _objectReader.ReadBitLong();
			for (int i = 0; i < num; i++)
			{
				image.ClipBoundaryVertices.Add(_objectReader.Read2RawDouble());
			}
			break;
		}
		}
		cadWipeoutBaseTemplate.ImgDefHandle = handleReference();
		cadWipeoutBaseTemplate.ImgReactorHandle = handleReference();
		return cadWipeoutBaseTemplate;
	}

	private CadTemplate readImageDefinition()
	{
		ImageDefinition imageDefinition = new ImageDefinition();
		CadNonGraphicalObjectTemplate cadNonGraphicalObjectTemplate = new CadNonGraphicalObjectTemplate(imageDefinition);
		readCommonNonEntityData(cadNonGraphicalObjectTemplate);
		imageDefinition.ClassVersion = _mergedReaders.ReadBitLong();
		imageDefinition.Size = _mergedReaders.Read2RawDouble();
		imageDefinition.FileName = _mergedReaders.ReadVariableText();
		imageDefinition.IsLoaded = _mergedReaders.ReadBit();
		imageDefinition.Units = (ResolutionUnit)_mergedReaders.ReadByte();
		imageDefinition.DefaultSize = _mergedReaders.Read2RawDouble();
		return cadNonGraphicalObjectTemplate;
	}

	private CadTemplate readImageDefinitionReactor()
	{
		ImageDefinitionReactor imageDefinitionReactor = new ImageDefinitionReactor();
		CadNonGraphicalObjectTemplate cadNonGraphicalObjectTemplate = new CadNonGraphicalObjectTemplate(imageDefinitionReactor);
		readCommonNonEntityData(cadNonGraphicalObjectTemplate);
		imageDefinitionReactor.ClassVersion = _objectReader.ReadBitLong();
		return cadNonGraphicalObjectTemplate;
	}

	private CadTemplate readXRecord()
	{
		XRecord xRecord = new XRecord();
		CadXRecordTemplate cadXRecordTemplate = new CadXRecordTemplate(xRecord);
		readCommonNonEntityData(cadXRecordTemplate);
		long num = _objectReader.ReadBitLong() + _objectReader.Position;
		while (_objectReader.Position < num)
		{
			short num2 = _objectReader.ReadShort();
			switch (GroupCodeValue.TransformValue(num2))
			{
			case GroupCodeValueType.String:
			case GroupCodeValueType.ExtendedDataString:
				xRecord.CreateEntry(num2, _objectReader.ReadTextUnicode());
				break;
			case GroupCodeValueType.Point3D:
				xRecord.CreateEntry(num2, new XYZ(_objectReader.ReadDouble(), _objectReader.ReadDouble(), _objectReader.ReadDouble()));
				break;
			case GroupCodeValueType.Double:
			case GroupCodeValueType.ExtendedDataDouble:
				xRecord.CreateEntry(num2, _objectReader.ReadDouble());
				break;
			case GroupCodeValueType.Byte:
				xRecord.CreateEntry(num2, _objectReader.ReadByte());
				break;
			case GroupCodeValueType.Int16:
			case GroupCodeValueType.ExtendedDataInt16:
				xRecord.CreateEntry(num2, _objectReader.ReadShort());
				break;
			case GroupCodeValueType.Int32:
			case GroupCodeValueType.ExtendedDataInt32:
				xRecord.CreateEntry(num2, _objectReader.ReadRawLong());
				break;
			case GroupCodeValueType.Int64:
				xRecord.CreateEntry(num2, _objectReader.ReadRawULong());
				break;
			case GroupCodeValueType.Handle:
			{
				string text = _objectReader.ReadTextUnicode();
				if (ulong.TryParse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out var result))
				{
					cadXRecordTemplate.AddHandleReference(num2, result);
				}
				else
				{
					notify("Failed to parse " + text + " to handle", NotificationType.Warning);
				}
				break;
			}
			case GroupCodeValueType.Bool:
				xRecord.CreateEntry(num2, _objectReader.ReadByte() > 0);
				break;
			case GroupCodeValueType.Chunk:
			case GroupCodeValueType.ExtendedDataChunk:
				xRecord.CreateEntry(num2, _objectReader.ReadBytes(_objectReader.ReadByte()));
				break;
			case GroupCodeValueType.ObjectId:
			case GroupCodeValueType.ExtendedDataHandle:
				cadXRecordTemplate.AddHandleReference(num2, _objectReader.ReadRawULong());
				break;
			default:
				notify($"Unidentified GroupCodeValueType {num2} for XRecord [{xRecord.Handle}]", NotificationType.Warning);
				break;
			}
		}
		if (R2000Plus)
		{
			xRecord.CloningFlags = (DictionaryCloningFlags)_objectReader.ReadBitShort();
		}
		long num3 = _objectInitialPos + _size * 8 - 7;
		while (_handlesReader.PositionInBits() < num3)
		{
			handleReference();
		}
		return cadXRecordTemplate;
	}

	private CadTemplate readMesh()
	{
		Mesh mesh = new Mesh();
		CadMeshTemplate cadMeshTemplate = new CadMeshTemplate(mesh);
		readCommonEntityData(cadMeshTemplate);
		mesh.Version = _objectReader.ReadBitShort();
		mesh.BlendCrease = _objectReader.ReadBit();
		mesh.SubdivisionLevel = _objectReader.ReadBitLong();
		int num = _objectReader.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			XYZ item = _objectReader.Read3BitDouble();
			mesh.Vertices.Add(item);
		}
		int num2 = _objectReader.ReadBitLong();
		int num3;
		for (num3 = 0; num3 < num2; num3++)
		{
			int num4 = _objectReader.ReadBitLong();
			int[] array = new int[num4];
			for (int j = 0; j < num4; j++)
			{
				array[j] = _objectReader.ReadBitLong();
			}
			num3 += num4;
			mesh.Faces.Add(array.ToArray());
		}
		int num5 = _objectReader.ReadBitLong();
		for (int k = 0; k < num5; k++)
		{
			int start = _objectReader.ReadBitLong();
			int end = _objectReader.ReadBitLong();
			mesh.Edges.Add(new Mesh.Edge(start, end));
		}
		int num6 = _objectReader.ReadBitLong();
		for (int l = 0; l < num6; l++)
		{
			Mesh.Edge value = mesh.Edges[l];
			value.Crease = _objectReader.ReadBitDouble();
			mesh.Edges[l] = value;
		}
		_objectReader.ReadBitLong();
		return cadMeshTemplate;
	}

	private CadTemplate readPlaceHolder()
	{
		CadTemplate<AcdbPlaceHolder> cadTemplate = new CadTemplate<AcdbPlaceHolder>(new AcdbPlaceHolder());
		readCommonNonEntityData(cadTemplate);
		return cadTemplate;
	}

	private CadTemplate readPdfDefinition()
	{
		PdfUnderlayDefinition pdfUnderlayDefinition = new PdfUnderlayDefinition();
		CadNonGraphicalObjectTemplate cadNonGraphicalObjectTemplate = new CadNonGraphicalObjectTemplate(pdfUnderlayDefinition);
		readCommonNonEntityData(cadNonGraphicalObjectTemplate);
		pdfUnderlayDefinition.File = _objectReader.ReadVariableText();
		pdfUnderlayDefinition.Page = _objectReader.ReadVariableText();
		return cadNonGraphicalObjectTemplate;
	}

	private CadTemplate readPdfUnderlay()
	{
		PdfUnderlay pdfUnderlay = new PdfUnderlay();
		CadUnderlayTemplate<PdfUnderlayDefinition> cadUnderlayTemplate = new CadUnderlayTemplate<PdfUnderlayDefinition>(pdfUnderlay);
		readCommonEntityData(cadUnderlayTemplate);
		pdfUnderlay.Normal = _objectReader.Read3BitDouble();
		pdfUnderlay.InsertPoint = _objectReader.Read3BitDouble();
		pdfUnderlay.Rotation = _objectReader.ReadBitDouble();
		pdfUnderlay.XScale = _objectReader.ReadBitDouble();
		pdfUnderlay.YScale = _objectReader.ReadBitDouble();
		pdfUnderlay.ZScale = _objectReader.ReadBitDouble();
		pdfUnderlay.Flags = (UnderlayDisplayFlags)_objectReader.ReadByte();
		pdfUnderlay.Contrast = _objectReader.ReadByte();
		pdfUnderlay.Fade = _objectReader.ReadByte();
		cadUnderlayTemplate.DefinitionHandle = handleReference();
		int num = _mergedReaders.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			pdfUnderlay.ClipBoundaryVertices.Add(_mergedReaders.Read2RawDouble());
		}
		return cadUnderlayTemplate;
	}

	private CadTemplate readScale()
	{
		Scale scale = new Scale();
		CadTemplate<Scale> cadTemplate = new CadTemplate<Scale>(scale);
		readCommonNonEntityData(cadTemplate);
		_mergedReaders.ReadBitShort();
		scale.Name = _mergedReaders.ReadVariableText();
		scale.PaperUnits = _mergedReaders.ReadBitDouble();
		scale.DrawingUnits = _mergedReaders.ReadBitDouble();
		scale.IsUnitScale = _mergedReaders.ReadBit();
		return cadTemplate;
	}

	private CadTemplate readProxyObject()
	{
		ProxyObject proxyObject = new ProxyObject();
		CadNonGraphicalObjectTemplate cadNonGraphicalObjectTemplate = new CadNonGraphicalObjectTemplate(proxyObject);
		readCommonNonEntityData(cadNonGraphicalObjectTemplate);
		readCommonProxyData(proxyObject);
		return cadNonGraphicalObjectTemplate;
	}

	private CadTemplate readProxyEntity()
	{
		ProxyEntity proxyEntity = new ProxyEntity();
		CadEntityTemplate<ProxyEntity> cadEntityTemplate = new CadEntityTemplate<ProxyEntity>(proxyEntity);
		readCommonEntityData(cadEntityTemplate);
		readCommonProxyData(proxyEntity);
		return cadEntityTemplate;
	}

	private void readCommonProxyData(IProxy proxy)
	{
		int num = _mergedReaders.ReadBitLong();
		if (_classes.TryGetValue((short)num, out var value))
		{
			proxy.DxfClass = value;
		}
		if (R2000Plus)
		{
			if (_version > ACadVersion.AC1015)
			{
				_mergedReaders.ReadVariableText();
			}
			if (!R2018Plus)
			{
				int num2 = _mergedReaders.ReadBitLong();
				proxy.Version = (ACadVersion)(num2 & 0xFFFF);
				proxy.MaintenanceVersion = (short)(num2 >> 16);
			}
			else
			{
				proxy.Version = (ACadVersion)_mergedReaders.ReadBitLong();
				proxy.MaintenanceVersion = _mergedReaders.ReadBitLong();
			}
			proxy.OriginalDataFormatDxf = _mergedReaders.ReadBit();
		}
	}

	private CadTemplate readPlotSettings()
	{
		PlotSettings plotSettings = new PlotSettings();
		CadPlotSettingsTemplate cadPlotSettingsTemplate = new CadPlotSettingsTemplate(plotSettings);
		readCommonNonEntityData(cadPlotSettingsTemplate);
		readPlotSettings(plotSettings);
		return cadPlotSettingsTemplate;
	}

	private CadTemplate readLayout()
	{
		Layout layout = new Layout();
		CadLayoutTemplate cadLayoutTemplate = new CadLayoutTemplate(layout);
		readCommonNonEntityData(cadLayoutTemplate);
		readPlotSettings(layout);
		layout.Name = _textReader.ReadVariableText();
		layout.TabOrder = _objectReader.ReadBitLong();
		layout.LayoutFlags = (LayoutFlags)_objectReader.ReadBitShort();
		layout.Origin = _objectReader.Read3BitDouble();
		layout.MinLimits = _objectReader.Read2RawDouble();
		layout.MaxLimits = _objectReader.Read2RawDouble();
		layout.InsertionBasePoint = _objectReader.Read3BitDouble();
		layout.XAxis = _objectReader.Read3BitDouble();
		layout.YAxis = _objectReader.Read3BitDouble();
		layout.Elevation = _objectReader.ReadBitDouble();
		layout.UcsOrthographicType = (OrthographicType)_objectReader.ReadBitShort();
		layout.MinExtents = _objectReader.Read3BitDouble();
		layout.MaxExtents = _objectReader.Read3BitDouble();
		int num = 0;
		if (R2004Plus)
		{
			num = _objectReader.ReadBitLong();
		}
		cadLayoutTemplate.PaperSpaceBlockHandle = handleReference();
		cadLayoutTemplate.ActiveViewportHandle = handleReference();
		cadLayoutTemplate.BaseUcsHandle = handleReference();
		cadLayoutTemplate.NamesUcsHandle = handleReference();
		if (R2004Plus)
		{
			for (int i = 0; i < num; i++)
			{
				cadLayoutTemplate.ViewportHandles.Add(handleReference());
			}
		}
		return cadLayoutTemplate;
	}

	private void readPlotSettings(PlotSettings plot)
	{
		plot.PageName = _textReader.ReadVariableText();
		plot.SystemPrinterName = _textReader.ReadVariableText();
		plot.Flags = (PlotFlags)_objectReader.ReadBitShort();
		PaperMargin unprintableMargin = new PaperMargin
		{
			Left = _objectReader.ReadBitDouble(),
			Bottom = _objectReader.ReadBitDouble(),
			Right = _objectReader.ReadBitDouble(),
			Top = _objectReader.ReadBitDouble()
		};
		plot.UnprintableMargin = unprintableMargin;
		plot.PaperWidth = _objectReader.ReadBitDouble();
		plot.PaperHeight = _objectReader.ReadBitDouble();
		plot.PaperSize = _textReader.ReadVariableText();
		plot.PlotOriginX = _objectReader.ReadBitDouble();
		plot.PlotOriginY = _objectReader.ReadBitDouble();
		plot.PaperUnits = (PlotPaperUnits)_objectReader.ReadBitShort();
		plot.PaperRotation = (PlotRotation)_objectReader.ReadBitShort();
		plot.PlotType = (PlotType)_objectReader.ReadBitShort();
		plot.WindowLowerLeftX = _objectReader.ReadBitDouble();
		plot.WindowLowerLeftY = _objectReader.ReadBitDouble();
		plot.WindowUpperLeftX = _objectReader.ReadBitDouble();
		plot.WindowUpperLeftY = _objectReader.ReadBitDouble();
		if (_version >= ACadVersion.AC1012 && _version <= ACadVersion.AC1015)
		{
			plot.PlotViewName = _textReader.ReadVariableText();
		}
		plot.NumeratorScale = _objectReader.ReadBitDouble();
		plot.DenominatorScale = _objectReader.ReadBitDouble();
		plot.StyleSheet = _textReader.ReadVariableText();
		plot.ScaledFit = (ScaledType)_objectReader.ReadBitShort();
		plot.StandardScale = _objectReader.ReadBitDouble();
		plot.PaperImageOrigin = _objectReader.Read2BitDouble();
		if (R2004Plus)
		{
			plot.ShadePlotMode = (ShadePlotMode)_objectReader.ReadBitShort();
			plot.ShadePlotResolutionMode = (ShadePlotResolutionMode)_objectReader.ReadBitShort();
			plot.ShadePlotDPI = _objectReader.ReadBitShort();
			handleReference();
		}
		if (R2007Plus)
		{
			handleReference();
		}
	}

	private void readLineTypeSegmentTexts(IList<CadLineTypeTemplate.SegmentTemplate> segments, byte[] textArea)
	{
		if (segments == null || textArea == null || textArea.Length == 0)
		{
			return;
		}
		Encoding encoding = _reader?.Encoding ?? Encoding.ASCII;
		foreach (CadLineTypeTemplate.SegmentTemplate segment in segments)
		{
			if (segment.Segment.Flags.HasFlag(LineTypeShapeFlags.Text))
			{
				int num = (ushort)segment.Segment.ShapeNumber;
				if (num >= textArea.Length)
				{
					_builder.Notify($"Unable to read linetype text segment; offset {num} is outside the available buffer ({textArea.Length} bytes).", NotificationType.Warning);
					segment.Segment.Text = string.Empty;
					segment.Segment.ShapeNumber = 0;
				}
				else
				{
					segment.Segment.Text = readLineTypeTextString(textArea, num, encoding);
					segment.Segment.ShapeNumber = 0;
				}
			}
		}
	}

	private string readLineTypeTextString(byte[] buffer, int offset, Encoding encoding)
	{
		if (buffer == null || encoding == null || offset < 0 || offset >= buffer.Length)
		{
			return string.Empty;
		}
		if (encoding.IsSingleByte && looksLikeUtf16Le(buffer, offset))
		{
			int i;
			for (i = offset; i + 1 < buffer.Length && (buffer[i] != 0 || buffer[i + 1] != 0); i += 2)
			{
			}
			return Encoding.Unicode.GetString(buffer, offset, i - offset);
		}
		int j;
		for (j = offset; j < buffer.Length && buffer[j] != 0; j++)
		{
		}
		if (j == offset)
		{
			return string.Empty;
		}
		return encoding.GetString(buffer, offset, j - offset);
	}

	private static bool looksLikeUtf16Le(byte[] buffer, int offset)
	{
		if (buffer == null || offset < 0 || offset + 1 >= buffer.Length)
		{
			return false;
		}
		bool result = false;
		for (int i = offset; i + 1 < buffer.Length; i += 2)
		{
			byte b = buffer[i];
			byte b2 = buffer[i + 1];
			if (b == 0 && b2 == 0)
			{
				return result;
			}
			if (b2 != 0)
			{
				return false;
			}
			if (b != 0)
			{
				result = true;
			}
		}
		return false;
	}

	private CadTemplate readDbColor()
	{
		BookColor bookColor = new BookColor();
		CadNonGraphicalObjectTemplate cadNonGraphicalObjectTemplate = new CadNonGraphicalObjectTemplate(bookColor);
		readCommonNonEntityData(cadNonGraphicalObjectTemplate);
		short index = _objectReader.ReadBitShort();
		if (R2004Plus)
		{
			uint value = (uint)_objectReader.ReadBitLong();
			byte num = _objectReader.ReadByte();
			if ((num & 1) != 0)
			{
				bookColor.ColorName = _textReader.ReadVariableText();
			}
			if ((num & 2) != 0)
			{
				bookColor.BookName = _textReader.ReadVariableText();
			}
			byte[] bytes = LittleEndianConverter.Instance.GetBytes(value);
			bookColor.Color = new Color(bytes[2], bytes[1], bytes[0]);
		}
		else
		{
			bookColor.Color = new Color(index);
		}
		return cadNonGraphicalObjectTemplate;
	}

	private CadTemplate readTableEntity()
	{
		TableEntity tableEntity = new TableEntity();
		CadTableEntityTemplate cadTableEntityTemplate = new CadTableEntityTemplate(tableEntity);
		readInsertCommonData(cadTableEntityTemplate);
		readInsertCommonHandles(cadTableEntityTemplate);
		if (R2010Plus)
		{
			_mergedReaders.ReadByte();
			cadTableEntityTemplate.NullHandle = handleReference();
			_mergedReaders.ReadBitLong();
			if (R2013Plus)
			{
				_mergedReaders.ReadBitLong();
			}
			else
			{
				_mergedReaders.ReadBit();
			}
			readTableContent(tableEntity.Content, cadTableEntityTemplate);
			_mergedReaders.ReadBitShort();
			tableEntity.HorizontalDirection = _mergedReaders.Read3BitDouble();
			if (_mergedReaders.ReadBitLong() == 1)
			{
				TableEntity.BreakData tableBreakData = tableEntity.TableBreakData;
				tableBreakData.Flags = (TableEntity.BreakOptionFlags)_mergedReaders.ReadBitLong();
				tableBreakData.FlowDirection = (TableEntity.BreakFlowDirection)_mergedReaders.ReadBitLong();
				tableBreakData.BreakSpacing = _mergedReaders.ReadBitDouble();
				_mergedReaders.ReadBitLong();
				_mergedReaders.ReadBitLong();
				int num = _mergedReaders.ReadBitLong();
				for (int i = 0; i < num; i++)
				{
					TableEntity.BreakData.BreakHeight item = new TableEntity.BreakData.BreakHeight
					{
						Position = _mergedReaders.Read3BitDouble(),
						Height = _mergedReaders.ReadBitDouble()
					};
					_mergedReaders.ReadBitLong();
					tableBreakData.Heights.Add(item);
				}
			}
			int num2 = _mergedReaders.ReadBitLong();
			for (int j = 0; j < num2; j++)
			{
				TableEntity.BreakRowRange breakRowRange = new TableEntity.BreakRowRange();
				breakRowRange.Position = _mergedReaders.Read3BitDouble();
				breakRowRange.StartRowIndex = _mergedReaders.ReadBitLong();
				breakRowRange.EndRowIndex = _mergedReaders.ReadBitLong();
				tableEntity.BreakRowRanges.Add(breakRowRange);
			}
			return cadTableEntityTemplate;
		}
		tableEntity.ValueFlag = _mergedReaders.ReadBitShort();
		tableEntity.HorizontalDirection = _mergedReaders.Read3BitDouble();
		int num3 = _mergedReaders.ReadBitLong();
		int num4 = _mergedReaders.ReadBitLong();
		for (int k = 0; k < num3; k++)
		{
			TableEntity.Column column = new TableEntity.Column();
			column.Width = _mergedReaders.ReadBitDouble();
			tableEntity.Columns.Add(column);
		}
		for (int l = 0; l < num4; l++)
		{
			TableEntity.Row row = new TableEntity.Row();
			row.Height = _mergedReaders.ReadBitDouble();
			tableEntity.Rows.Add(row);
		}
		cadTableEntityTemplate.StyleHandle = handleReference();
		for (int m = 0; m < tableEntity.Rows.Count; m++)
		{
			for (int n = 0; n < tableEntity.Columns.Count; n++)
			{
				TableEntity.Cell cell = new TableEntity.Cell();
				tableEntity.Rows[m].Cells.Add(cell);
				CadTableEntityTemplate.CadTableCellTemplate cadTableCellTemplate = new CadTableEntityTemplate.CadTableCellTemplate(cell);
				cadTableEntityTemplate.CadTableCellTemplates.Add(cadTableCellTemplate);
				readTableCellData(cadTableCellTemplate);
			}
		}
		if (_mergedReaders.ReadBit())
		{
			TableStyle tableStyle = new TableStyle();
			tableEntity.Content.StyleOverride = tableStyle;
			TableEntity.TableOverrideFlags tableOverrideFlags = (TableEntity.TableOverrideFlags)_mergedReaders.ReadBitLong();
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.TitleSuppressed))
			{
				tableStyle.SuppressTitle = _mergedReaders.ReadBit();
			}
			tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.TitleSuppressed);
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.FlowDirection))
			{
				_mergedReaders.ReadBitShort();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.HorizontalCellMargin))
			{
				_mergedReaders.ReadBitDouble();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.VerticalCellMargin))
			{
				_mergedReaders.ReadBitDouble();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.TitleRowColor))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.HeaderRowColor))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.DataRowColor))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.TitleRowFillNone))
			{
				_mergedReaders.ReadBit();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.HeaderRowFillNone))
			{
				_mergedReaders.ReadBit();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.DataRowFillNone))
			{
				_mergedReaders.ReadBit();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.TitleRowFillColor))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.HeaderRowFillColor))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.DataRowFillColor))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.TitleRowAlign))
			{
				_mergedReaders.ReadBitShort();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.HeaderRowAlign))
			{
				_mergedReaders.ReadBitShort();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.DataRowAlign))
			{
				_mergedReaders.ReadBitShort();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.TitleTextStyle))
			{
				handleReference();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.HeaderTextStyle))
			{
				handleReference();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.DataTextStyle))
			{
				handleReference();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.TitleRowHeight))
			{
				_mergedReaders.ReadBitDouble();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.HeaderRowHeight))
			{
				_mergedReaders.ReadBitDouble();
			}
			if (tableOverrideFlags.HasFlag(TableEntity.TableOverrideFlags.DataRowHeight))
			{
				_mergedReaders.ReadBitDouble();
			}
		}
		if (_mergedReaders.ReadBit())
		{
			TableEntity.BorderOverrideFlags borderOverrideFlags = (TableEntity.BorderOverrideFlags)_mergedReaders.ReadBitLong();
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.TitleHorizontalTop))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.TitleHorizontalInsert))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.TitleHorizontalBottom))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.TitleVerticalLeft))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.TitleVerticalInsert))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.TitleVerticalRight))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.HeaderHorizontalTop))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.HeaderHorizontalInsert))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.HeaderHorizontalBottom))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.HeaderVerticalLeft))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.HeaderVerticalInsert))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.HeaderVerticalRight))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.DataHorizontalTop))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.DataHorizontalInsert))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.DataHorizontalBottom))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.DataVerticalLeft))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.DataVerticalInsert))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
			if (borderOverrideFlags.HasFlag(TableEntity.BorderOverrideFlags.DataVerticalRight))
			{
				_mergedReaders.ReadCmColor(R2004Pre);
			}
		}
		if (_mergedReaders.ReadBit())
		{
			TableEntity.BorderOverrideFlags borderOverrideFlags2 = (TableEntity.BorderOverrideFlags)_mergedReaders.ReadBitLong();
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.TitleHorizontalTop))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.TitleHorizontalInsert))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.TitleHorizontalBottom))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.TitleVerticalLeft))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.TitleVerticalInsert))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.TitleVerticalRight))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.HeaderHorizontalTop))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.HeaderHorizontalInsert))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.HeaderHorizontalBottom))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.HeaderVerticalLeft))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.HeaderVerticalInsert))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.HeaderVerticalRight))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.DataHorizontalTop))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.DataHorizontalInsert))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.DataHorizontalBottom))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.DataVerticalLeft))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.DataVerticalInsert))
			{
				_mergedReaders.ReadBitShort();
			}
			if (borderOverrideFlags2.HasFlag(TableEntity.BorderOverrideFlags.DataVerticalRight))
			{
				_mergedReaders.ReadBitShort();
			}
		}
		if (_mergedReaders.ReadBit())
		{
			TableEntity.BorderOverrideFlags borderOverrideFlags3 = (TableEntity.BorderOverrideFlags)_mergedReaders.ReadBitLong();
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.TitleHorizontalTop))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.TitleHorizontalInsert))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.TitleHorizontalBottom))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.TitleVerticalLeft))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.TitleVerticalInsert))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.TitleVerticalRight))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.HeaderHorizontalTop))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.HeaderHorizontalInsert))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.HeaderHorizontalBottom))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.HeaderVerticalLeft))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.HeaderVerticalInsert))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.HeaderVerticalRight))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.DataHorizontalTop))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.DataHorizontalInsert))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.DataHorizontalBottom))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.DataVerticalLeft))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.DataVerticalInsert))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
			if (borderOverrideFlags3.HasFlag(TableEntity.BorderOverrideFlags.DataVerticalRight))
			{
				_mergedReaders.ReadBitShortAsBool();
			}
		}
		return cadTableEntityTemplate;
	}

	private void readTableCellData(CadTableEntityTemplate.CadTableCellTemplate template)
	{
		TableEntity.Cell cell = template.Cell;
		cell.Type = (TableEntity.CellType)_mergedReaders.ReadBitShort();
		cell.EdgeFlags = _mergedReaders.ReadByte();
		cell.MergedValue = (_mergedReaders.ReadBit() ? ((short)1) : ((short)0));
		cell.AutoFit = _mergedReaders.ReadBit();
		cell.BorderWidth = _mergedReaders.ReadBitLong();
		cell.BorderHeight = _mergedReaders.ReadBitLong();
		cell.Rotation = _mergedReaders.ReadBitDouble();
		template.ValueHandle = handleReference();
		switch (cell.Type)
		{
		case TableEntity.CellType.Text:
			if (template.ValueHandle == 0 && _version < ACadVersion.AC1021)
			{
				TableEntity.CellContent cellContent = new TableEntity.CellContent();
				cellContent.Value.ValueType = TableEntity.CellValueType.String;
				cellContent.Value.Value = _mergedReaders.ReadVariableText();
				cell.Contents.Add(cellContent);
			}
			break;
		case TableEntity.CellType.Block:
			cell.BlockScale = _mergedReaders.ReadBitDouble();
			if (_mergedReaders.ReadBit())
			{
				int num = _mergedReaders.ReadBitShort();
				for (int i = 0; i < num; i++)
				{
					ulong item = handleReference();
					_mergedReaders.ReadBitShort();
					string item2 = _mergedReaders.ReadVariableText();
					template.AttributeHandles.Add((item, item2));
				}
			}
			break;
		}
		if (_mergedReaders.ReadBit())
		{
			TableEntity.Cell.OverrideFlags overrideFlags = (TableEntity.Cell.OverrideFlags)_mergedReaders.ReadBitLong();
			cell.VirtualEdgeFlag = _mergedReaders.ReadByte();
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.CellAlignment))
			{
				cell.StyleOverride.CellAlignment = (TableEntity.Cell.CellAlignment)_mergedReaders.ReadBitShort();
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.BackgroundFillNone))
			{
				cell.StyleOverride.IsFillColorOn = _mergedReaders.ReadBit();
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.BackgroundColor))
			{
				cell.StyleOverride.BackgroundColor = _mergedReaders.ReadCmColor(R2004Pre);
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.ContentColor))
			{
				cell.StyleOverride.ContentColor = _mergedReaders.ReadCmColor(R2004Pre);
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.TextStyle))
			{
				template.TextStyleOverrideHandle = handleReference();
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.TextHeight))
			{
				cell.StyleOverride.TextHeight = _mergedReaders.ReadBitDouble();
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.TopGridColor))
			{
				cell.StyleOverride.TopBorder.Color = _mergedReaders.ReadCmColor(R2004Pre);
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.TopGridLineWeight))
			{
				cell.StyleOverride.TopBorder.LineWeight = (LineWeightType)_mergedReaders.ReadBitShort();
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.TopGridLineWeight))
			{
				cell.StyleOverride.TopBorder.IsInvisible = !_mergedReaders.ReadBitShortAsBool();
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.RightGridColor))
			{
				cell.StyleOverride.RightBorder.Color = _mergedReaders.ReadCmColor(R2004Pre);
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.RightGridLineWeight))
			{
				cell.StyleOverride.RightBorder.LineWeight = (LineWeightType)_mergedReaders.ReadBitShort();
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.RightGridLineWeight))
			{
				cell.StyleOverride.RightBorder.IsInvisible = !_mergedReaders.ReadBitShortAsBool();
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.BottomGridColor))
			{
				cell.StyleOverride.BottomBorder.Color = _mergedReaders.ReadCmColor(R2004Pre);
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.BottomGridLineWeight))
			{
				cell.StyleOverride.BottomBorder.LineWeight = (LineWeightType)_mergedReaders.ReadBitShort();
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.BottomGridLineWeight))
			{
				cell.StyleOverride.BottomBorder.IsInvisible = !_mergedReaders.ReadBitShortAsBool();
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.LeftGridColor))
			{
				cell.StyleOverride.LeftBorder.Color = _mergedReaders.ReadCmColor(R2004Pre);
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.LeftGridLineWeight))
			{
				cell.StyleOverride.LeftBorder.LineWeight = (LineWeightType)_mergedReaders.ReadBitShort();
			}
			if (overrideFlags.HasFlag(TableEntity.Cell.OverrideFlags.LeftGridLineWeight))
			{
				cell.StyleOverride.LeftBorder.IsInvisible = !_mergedReaders.ReadBitShortAsBool();
			}
		}
		if (R2007Plus)
		{
			_mergedReaders.ReadBitLong();
			cell.Contents.Add(new TableEntity.CellContent());
			readCustomTableDataValue(cell.Content.Value);
		}
	}

	private void readTableContent(TableContent content, CadTableEntityTemplate template)
	{
		TableEntity tableEntity = template.TableEntity;
		content.Name = _mergedReaders.ReadVariableText();
		content.Description = _mergedReaders.ReadVariableText();
		int num = _mergedReaders.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			TableEntity.Column column = new TableEntity.Column();
			tableEntity.Columns.Add(column);
			column.Name = _mergedReaders.ReadVariableText();
			column.CustomData = _mergedReaders.ReadBitLong();
			int num2 = _mergedReaders.ReadBitLong();
			for (int j = 0; j < num2; j++)
			{
				TableEntity.CustomDataEntry customDataEntry = new TableEntity.CustomDataEntry();
				readCustomTableData(customDataEntry);
				column.CustomDataCollection.Add(customDataEntry);
			}
			CadTableEntityTemplate.CadCellStyleTemplate template2 = new CadTableEntityTemplate.CadCellStyleTemplate(column.CellStyleOverride);
			readCellStyle(template2);
			_mergedReaders.ReadBitLong();
			column.Width = _mergedReaders.ReadBitDouble();
		}
		int num3 = _mergedReaders.ReadBitLong();
		for (int k = 0; k < num3; k++)
		{
			TableEntity.Row row = new TableEntity.Row();
			tableEntity.Rows.Add(row);
			int num4 = _mergedReaders.ReadBitLong();
			for (int l = 0; l < num4; l++)
			{
				TableEntity.Cell cell = new TableEntity.Cell();
				CadTableEntityTemplate.CadTableCellTemplate template3 = new CadTableEntityTemplate.CadTableCellTemplate(cell);
				readTableCell(template3);
				row.Cells.Add(cell);
			}
			row.CustomData = _mergedReaders.ReadBitLong();
			int num5 = _mergedReaders.ReadBitLong();
			for (int m = 0; m < num5; m++)
			{
				TableEntity.CustomDataEntry customDataEntry2 = new TableEntity.CustomDataEntry();
				readCustomTableData(customDataEntry2);
				row.CustomDataCollection.Add(customDataEntry2);
			}
			CadTableEntityTemplate.CadCellStyleTemplate template4 = new CadTableEntityTemplate.CadCellStyleTemplate(row.CellStyleOverride);
			readCellStyle(template4);
			_mergedReaders.ReadBitLong();
			row.Height = _mergedReaders.ReadBitDouble();
		}
		int num6 = _mergedReaders.ReadBitLong();
		for (int n = 0; n < num6; n++)
		{
			_mergedReaders.HandleReference();
		}
		readCellStyle(new CadTableEntityTemplate.CadCellStyleTemplate(content.CellStyleOverride));
		int num7 = _mergedReaders.ReadBitLong();
		for (int num8 = 0; num8 < num7; num8++)
		{
			TableEntity.CellRange cellRange = new TableEntity.CellRange();
			cellRange.TopRowIndex = _mergedReaders.ReadBitLong();
			cellRange.LeftColumnIndex = _mergedReaders.ReadBitLong();
			cellRange.BottomRowIndex = _mergedReaders.ReadBitLong();
			cellRange.RightColumnIndex = _mergedReaders.ReadBitLong();
			content.MergedCellRanges.Add(cellRange);
		}
		template.StyleHandle = handleReference();
	}

	private void readCustomTableData(TableEntity.CustomDataEntry entry)
	{
		entry.Name = _mergedReaders.ReadVariableText();
		readCustomTableDataValue(entry.Value);
	}

	private void readCustomTableDataValue(TableEntity.CellValue value)
	{
		if (R2007Plus)
		{
			value.Flags = _mergedReaders.ReadBitLong();
		}
		value.ValueType = (TableEntity.CellValueType)_mergedReaders.ReadBitLong();
		if (!R2007Plus || !value.IsEmpty)
		{
			switch (value.ValueType)
			{
			case TableEntity.CellValueType.Unknown:
			case TableEntity.CellValueType.Long:
				value.Value = _mergedReaders.ReadBitLong();
				break;
			case TableEntity.CellValueType.Double:
				value.Value = _mergedReaders.ReadBitDouble();
				break;
			case TableEntity.CellValueType.String:
			case TableEntity.CellValueType.General:
				value.Value = readStringCellValue();
				break;
			case TableEntity.CellValueType.Date:
			{
				DateTime? dateTime = readDateCellValue();
				if (dateTime.HasValue)
				{
					value.Value = dateTime.Value;
				}
				break;
			}
			case TableEntity.CellValueType.Point2D:
				value.Value = readCellValueXY();
				break;
			case TableEntity.CellValueType.Point3D:
				value.Value = readCellValueXYZ();
				break;
			case TableEntity.CellValueType.Handle:
				value.Value = handleReference();
				break;
			default:
				throw new NotImplementedException();
			}
		}
		if (R2007Plus)
		{
			value.Units = (TableEntity.ValueUnitType)_mergedReaders.ReadBitLong();
			value.Format = _mergedReaders.ReadVariableText();
			value.FormattedValue = _mergedReaders.ReadVariableText();
		}
	}

	private string readStringCellValue()
	{
		int num = _mergedReaders.ReadBitLong();
		byte[] bytes = _mergedReaders.ReadBytes(num);
		if (R2007Plus)
		{
			return Encoding.Unicode.GetString(bytes, 0, num - 2);
		}
		return _mergedReaders.Encoding.GetString(bytes, 0, num);
	}

	private DateTime? readDateCellValue()
	{
		int num = _mergedReaders.ReadBitLong();
		if (num > 0)
		{
			_mergedReaders.ReadBytes(num);
		}
		return null;
	}

	private XY? readCellValueXY()
	{
		XY? result = null;
		if (_mergedReaders.ReadBitLong() > 0)
		{
			result = _mergedReaders.Read2RawDouble();
		}
		return result;
	}

	private XYZ? readCellValueXYZ()
	{
		XYZ? result = null;
		if (_mergedReaders.ReadBitLong() > 0)
		{
			result = _mergedReaders.Read3RawDouble();
		}
		return result;
	}

	private void readCellStyle(CadTableEntityTemplate.CadCellStyleTemplate template)
	{
		TableEntity.CellStyle cellStyle = (TableEntity.CellStyle)template.Format;
		cellStyle.Type = (TableEntity.CellStyleTypeType)_mergedReaders.ReadBitLong();
		cellStyle.HasData = _mergedReaders.ReadBitShortAsBool();
		if (!cellStyle.HasData)
		{
			return;
		}
		cellStyle.PropertyOverrideFlags = (TableEntity.TableCellStylePropertyFlags)_mergedReaders.ReadBitLong();
		cellStyle.TableCellStylePropertyFlags = (TableEntity.TableCellStylePropertyFlags)_mergedReaders.ReadBitLong();
		cellStyle.BackgroundColor = _mergedReaders.ReadCmColor(R2004Pre);
		cellStyle.ContentLayoutFlags = (TableEntity.TableCellContentLayoutFlags)_mergedReaders.ReadBitLong();
		readCellContentFormat(template, cellStyle);
		cellStyle.MarginOverrideFlags = (TableEntity.MarginFlags)_mergedReaders.ReadBitShort();
		if (cellStyle.MarginOverrideFlags.HasFlag(TableEntity.MarginFlags.Override))
		{
			cellStyle.VerticalMargin = _mergedReaders.ReadBitDouble();
			cellStyle.HorizontalMargin = _mergedReaders.ReadBitDouble();
			cellStyle.BottomMargin = _mergedReaders.ReadBitDouble();
			cellStyle.RightMargin = _mergedReaders.ReadBitDouble();
			cellStyle.MarginHorizontalSpacing = _mergedReaders.ReadBitDouble();
			cellStyle.MarginVerticalSpacing = _mergedReaders.ReadBitDouble();
		}
		int num = _mergedReaders.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			TableEntity.CellEdgeFlags cellEdgeFlags = (TableEntity.CellEdgeFlags)_mergedReaders.ReadBitLong();
			if (cellEdgeFlags != TableEntity.CellEdgeFlags.Unknown)
			{
				TableEntity.CellBorder cellBorder = new TableEntity.CellBorder(cellEdgeFlags);
				cellStyle.Borders.Add(cellBorder);
				readBorder(template, cellBorder);
			}
		}
	}

	private void readBorder(CadTableEntityTemplate.CadCellStyleTemplate template, TableEntity.CellBorder border)
	{
		border.PropertyOverrideFlags = (TableEntity.TableBorderPropertyFlags)_mergedReaders.ReadBitLong();
		border.Type = (TableEntity.BorderType)_mergedReaders.ReadBitLong();
		border.Color = _mergedReaders.ReadCmColor(R2004Pre);
		border.LineWeight = (LineWeightType)_mergedReaders.ReadBitLong();
		template.BorderLinetypePairs.Add(new Tuple<TableEntity.CellBorder, ulong>(border, handleReference()));
		border.IsInvisible = _mergedReaders.ReadBitLong() == 1;
		border.DoubleLineSpacing = _mergedReaders.ReadBitDouble();
	}

	private void readTableCell(CadTableEntityTemplate.CadTableCellTemplate template)
	{
		TableEntity.Cell cell = template.Cell;
		cell.StateFlags = (TableEntity.TableCellStateFlags)_mergedReaders.ReadBitLong();
		cell.ToolTip = _mergedReaders.ReadVariableText();
		cell.CustomData = _mergedReaders.ReadBitLong();
		int num = _mergedReaders.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			TableEntity.CustomDataEntry customDataEntry = new TableEntity.CustomDataEntry();
			readCustomTableData(customDataEntry);
			cell.CustomDataCollection.Add(customDataEntry);
		}
		cell.HasLinkedData = _mergedReaders.ReadBitLong() == 1;
		if (cell.HasLinkedData)
		{
			template.ValueHandle = _mergedReaders.HandleReference();
			_mergedReaders.ReadBitLong();
			_mergedReaders.ReadBitLong();
			_mergedReaders.ReadBitLong();
		}
		int num2 = _mergedReaders.ReadBitLong();
		for (int j = 0; j < num2; j++)
		{
			TableEntity.CellContent cellContent = new TableEntity.CellContent();
			cell.Contents.Add(cellContent);
			CadTableEntityTemplate.CadTableCellContentTemplate cadTableCellContentTemplate = new CadTableEntityTemplate.CadTableCellContentTemplate(cellContent);
			template.ContentTemplates.Add(cadTableCellContentTemplate);
			readTableCellContent(cadTableCellContentTemplate);
		}
		CadTableEntityTemplate.CadCellStyleTemplate template2 = new CadTableEntityTemplate.CadCellStyleTemplate(cell.StyleOverride);
		readCellStyle(template2);
		template.StyleId = _mergedReaders.ReadBitLong();
		if (_mergedReaders.ReadBitLong() != 0)
		{
			_mergedReaders.ReadBitLong();
			_mergedReaders.ReadBitDouble();
			_mergedReaders.ReadBitDouble();
			int num3 = _mergedReaders.ReadBitLong();
			template.UnknownHandle = handleReference();
			if (num3 != 0)
			{
				cell.Geometry = new TableEntity.CellContentGeometry();
				readCellContentGeometry(cell.Geometry);
			}
		}
	}

	private void readCellContentGeometry(TableEntity.CellContentGeometry geometry)
	{
		geometry.DistanceTopLeft = _mergedReaders.Read3BitDouble();
		geometry.DistanceCenter = _mergedReaders.Read3BitDouble();
		geometry.ContentWidth = _mergedReaders.ReadBitDouble();
		geometry.ContentHeight = _mergedReaders.ReadBitDouble();
		geometry.Width = _mergedReaders.ReadBitDouble();
		geometry.Height = _mergedReaders.ReadBitDouble();
		geometry.Flags = _mergedReaders.ReadBitLong();
	}

	private void readTableCellContent(CadTableEntityTemplate.CadTableCellContentTemplate template)
	{
		template.Content.ContentType = (TableEntity.TableCellContentType)_mergedReaders.ReadBitLong();
		switch (template.Content.ContentType)
		{
		case TableEntity.TableCellContentType.Value:
			readCustomTableDataValue(template.Content.Value);
			break;
		case TableEntity.TableCellContentType.Field:
			template.FieldHandle = handleReference();
			break;
		case TableEntity.TableCellContentType.Block:
			template.BlockRecordHandle = handleReference();
			break;
		}
		int num = _mergedReaders.ReadBitLong();
		for (int i = 0; i < num; i++)
		{
			TableEntity.TableAttribute tableAttribute = new TableEntity.TableAttribute();
			new CadTableEntityTemplate.CadTableAttributeTemplate(tableAttribute).AttDefHandle = handleReference();
			tableAttribute.Value = _mergedReaders.ReadVariableText();
			_mergedReaders.ReadBitLong();
		}
		template.Content.Format.HasData = _mergedReaders.ReadBitShortAsBool();
		if (template.Content.Format.HasData)
		{
			CadTableEntityTemplate.CadTableCellContentFormatTemplate template2 = new CadTableEntityTemplate.CadTableCellContentFormatTemplate(template.Content.Format);
			readCellContentFormat(template2, template.Content.Format);
		}
	}

	private void readCellContentFormat(CadTableEntityTemplate.CadTableCellContentFormatTemplate template, TableEntity.ContentFormat format)
	{
		format.PropertyOverrideFlags = (TableEntity.TableCellStylePropertyFlags)_mergedReaders.ReadBitLong();
		format.PropertyFlags = _mergedReaders.ReadBitLong();
		format.ValueDataType = _mergedReaders.ReadBitLong();
		format.ValueUnitType = _mergedReaders.ReadBitLong();
		format.ValueFormatString = _mergedReaders.ReadVariableText();
		format.Rotation = _mergedReaders.ReadBitDouble();
		format.Scale = _mergedReaders.ReadBitDouble();
		format.Alignment = _mergedReaders.ReadBitLong();
		format.Color = _mergedReaders.ReadCmColor(R2004Pre);
		template.TextStyleHandle = handleReference();
		format.TextHeight = _mergedReaders.ReadBitDouble();
	}
}
