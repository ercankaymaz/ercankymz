using System;
using System.Collections.Generic;
using ACadSharp.Exceptions;
using ACadSharp.IO.Templates;
using ACadSharp.Tables;
using ACadSharp.Tables.Collections;
using ACadSharp.Types.Units;
using ACadSharp.XData;
using CSMath;
using CSUtilities.Extensions;

namespace ACadSharp.IO.DXF;

internal class DxfTablesSectionReader : DxfSectionReaderBase
{
	public delegate bool ReadEntryDelegate<T>(CadTableEntryTemplate<T> template, DxfClassMap map) where T : TableEntry;

	public DxfTablesSectionReader(IDxfStreamReader reader, DxfDocumentBuilder builder)
		: base(reader, builder)
	{
	}

	public override void Read()
	{
		_reader.ReadNext();
		while (_reader.ValueAsString != "ENDSEC")
		{
			if (_reader.ValueAsString == "TABLE")
			{
				readTable();
				if (_reader.ValueAsString == "ENDTAB")
				{
					_reader.ReadNext();
					continue;
				}
				throw new DxfException("Unexpected token at the end of a table: " + _reader.ValueAsString, _reader.Position);
			}
			throw new DxfException("Unexpected token at the beginning of a table: " + _reader.ValueAsString, _reader.Position);
		}
	}

	private void readTable()
	{
		_reader.ReadNext();
		CadTemplate cadTemplate = null;
		Dictionary<string, List<ExtendedDataRecord>> dictionary = new Dictionary<string, List<ExtendedDataRecord>>();
		readCommonObjectData(out var name, out var handle, out var ownerHandle, out var xdictHandle, out var reactors);
		if (_reader.DxfCode == DxfCode.Subclass)
		{
			while (_reader.DxfCode != DxfCode.Start)
			{
				switch (_reader.Code)
				{
				case 70:
					_ = _reader.ValueAsInt;
					break;
				case 100:
					if (_reader.ValueAsString == "AcDbDimStyleTable")
					{
						while (_reader.DxfCode != DxfCode.Start)
						{
							_reader.ReadNext();
						}
					}
					break;
				case 1001:
					readExtendedData(dictionary);
					break;
				default:
					_builder.Notify($"[AcDbSymbolTable] Unhandeled dxf code {_reader.Code} at line {_reader.Position}.");
					break;
				}
				if (_reader.DxfCode == DxfCode.Start)
				{
					break;
				}
				_reader.ReadNext();
			}
		}
		else
		{
			if (_reader.ValueAsString == "ENDTAB")
			{
				return;
			}
			_reader.ReadNext();
		}
		switch (name)
		{
		case "APPID":
			cadTemplate = new CadTableTemplate<AppId>(new AppIdsTable());
			readEntries((CadTableTemplate<AppId>)cadTemplate);
			cadTemplate.CadObject.Handle = handle;
			_builder.AppIds = (AppIdsTable)cadTemplate.CadObject;
			break;
		case "BLOCK_RECORD":
			cadTemplate = new CadBlockCtrlObjectTemplate(new BlockRecordsTable());
			readEntries((CadBlockCtrlObjectTemplate)cadTemplate);
			cadTemplate.CadObject.Handle = handle;
			_builder.BlockRecords = (BlockRecordsTable)cadTemplate.CadObject;
			break;
		case "VPORT":
			cadTemplate = new CadTableTemplate<VPort>(new VPortsTable());
			readEntries((CadTableTemplate<VPort>)cadTemplate);
			cadTemplate.CadObject.Handle = handle;
			_builder.VPorts = (VPortsTable)cadTemplate.CadObject;
			break;
		case "LTYPE":
			cadTemplate = new CadTableTemplate<LineType>(new LineTypesTable());
			readEntries((CadTableTemplate<LineType>)cadTemplate);
			cadTemplate.CadObject.Handle = handle;
			_builder.LineTypesTable = (LineTypesTable)cadTemplate.CadObject;
			break;
		case "LAYER":
			cadTemplate = new CadTableTemplate<Layer>(new LayersTable());
			readEntries((CadTableTemplate<Layer>)cadTemplate);
			cadTemplate.CadObject.Handle = handle;
			_builder.Layers = (LayersTable)cadTemplate.CadObject;
			break;
		case "STYLE":
			cadTemplate = new CadTableTemplate<TextStyle>(new TextStylesTable());
			readEntries((CadTableTemplate<TextStyle>)cadTemplate);
			cadTemplate.CadObject.Handle = handle;
			_builder.TextStyles = (TextStylesTable)cadTemplate.CadObject;
			break;
		case "VIEW":
			cadTemplate = new CadTableTemplate<View>(new ViewsTable());
			readEntries((CadTableTemplate<View>)cadTemplate);
			cadTemplate.CadObject.Handle = handle;
			_builder.Views = (ViewsTable)cadTemplate.CadObject;
			break;
		case "UCS":
			cadTemplate = new CadTableTemplate<UCS>(new UCSTable());
			readEntries((CadTableTemplate<UCS>)cadTemplate);
			cadTemplate.CadObject.Handle = handle;
			_builder.UCSs = (UCSTable)cadTemplate.CadObject;
			break;
		case "DIMSTYLE":
			cadTemplate = new CadTableTemplate<DimensionStyle>(new DimensionStylesTable());
			readEntries((CadTableTemplate<DimensionStyle>)cadTemplate);
			cadTemplate.CadObject.Handle = handle;
			_builder.DimensionStyles = (DimensionStylesTable)cadTemplate.CadObject;
			break;
		default:
			throw new DxfException("Unknown table name " + name);
		}
		cadTemplate.OwnerHandle = ownerHandle;
		cadTemplate.XDictHandle = xdictHandle;
		cadTemplate.ReactorsHandles = reactors;
		cadTemplate.EDataTemplateByAppName = dictionary;
		_builder.AddTemplate(cadTemplate);
	}

	private void readEntries<T>(CadTableTemplate<T> tableTemplate) where T : TableEntry
	{
		while (_reader.ValueAsString != "ENDTAB")
		{
			_reader.ReadNext();
			ICadTableEntryTemplate cadTableEntryTemplate = null;
			switch (tableTemplate.CadObject.ObjectName)
			{
			case "APPID":
				cadTableEntryTemplate = readTableEntry(new CadTableEntryTemplate<AppId>(new AppId()), readAppId);
				break;
			case "BLOCK_RECORD":
			{
				CadBlockRecordTemplate cadBlockRecordTemplate = new CadBlockRecordTemplate();
				cadTableEntryTemplate = readTableEntry(cadBlockRecordTemplate, readBlockRecord);
				if (cadBlockRecordTemplate.CadObject.Name.Equals("*Model_Space", StringComparison.OrdinalIgnoreCase))
				{
					_builder.ModelSpaceTemplate = cadBlockRecordTemplate;
				}
				break;
			}
			case "DIMSTYLE":
				cadTableEntryTemplate = readTableEntry(new CadDimensionStyleTemplate(), readDimensionStyle);
				break;
			case "LAYER":
				cadTableEntryTemplate = readTableEntry(new CadLayerTemplate(), readLayer);
				break;
			case "LTYPE":
				cadTableEntryTemplate = readTableEntry(new CadLineTypeTemplate(), readLineType);
				break;
			case "STYLE":
				cadTableEntryTemplate = readTableEntry(new CadTableEntryTemplate<TextStyle>(new TextStyle()), readTextStyle);
				break;
			case "UCS":
				cadTableEntryTemplate = readTableEntry(new CadUcsTemplate(), readUcs);
				break;
			case "VIEW":
				cadTableEntryTemplate = readTableEntry(new CadViewTemplate(), readView);
				break;
			case "VPORT":
				cadTableEntryTemplate = readTableEntry(new CadVPortTemplate(), readVPort);
				break;
			}
			if (tableTemplate.CadObject.Contains(cadTableEntryTemplate.Name) && _builder.Configuration.Failsafe)
			{
				_builder.Notify("Duplicated entry with name " + cadTableEntryTemplate.Name + " found in " + cadTableEntryTemplate.CadObject.ObjectName, NotificationType.Warning);
				tableTemplate.CadObject.Remove(cadTableEntryTemplate.Name);
				tableTemplate.CadObject.Add((T)cadTableEntryTemplate.CadObject);
			}
			else
			{
				tableTemplate.CadObject.Add((T)cadTableEntryTemplate.CadObject);
			}
			_builder.AddTemplate(cadTableEntryTemplate);
		}
	}

	private ICadTableEntryTemplate readTableEntry<T>(CadTableEntryTemplate<T> template, ReadEntryDelegate<T> readEntry) where T : TableEntry
	{
		DxfMap dxfMap = DxfMap.Create<T>();
		while (_reader.DxfCode != DxfCode.Start)
		{
			if (!readEntry(template, dxfMap.SubClasses[template.CadObject.SubclassMarker]))
			{
				readCommonTableEntryCodes(template, out var isExtendedData, dxfMap);
				if (isExtendedData)
				{
					continue;
				}
			}
			if (_reader.DxfCode != DxfCode.Start)
			{
				_reader.ReadNext();
			}
		}
		return template;
	}

	private void readCommonTableEntryCodes<T>(CadTableEntryTemplate<T> template, out bool isExtendedData, DxfMap map = null) where T : TableEntry
	{
		isExtendedData = false;
		switch (_reader.Code)
		{
		case 2:
			template.CadObject.Name = _reader.ValueAsString;
			break;
		case 70:
			template.CadObject.Flags = (StandardFlags)_reader.ValueAsUShort;
			break;
		default:
			readCommonCodes(template, out isExtendedData, map);
			break;
		case 100:
			break;
		}
	}

	private bool readAppId(CadTableEntryTemplate<AppId> template, DxfClassMap map)
	{
		_ = _reader.Code;
		return tryAssignCurrentValue(template.CadObject, map);
	}

	private bool readBlockRecord(CadTableEntryTemplate<BlockRecord> template, DxfClassMap map)
	{
		CadBlockRecordTemplate cadBlockRecordTemplate = (CadBlockRecordTemplate)template;
		if (_reader.Code == 340)
		{
			cadBlockRecordTemplate.LayoutHandle = _reader.ValueAsHandle;
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map);
	}

	private bool readDimensionStyle(CadTableEntryTemplate<DimensionStyle> template, DxfClassMap map)
	{
		CadDimensionStyleTemplate cadDimensionStyleTemplate = (CadDimensionStyleTemplate)template;
		switch (_reader.Code)
		{
		case 3:
			template.CadObject.PostFix = _reader.ValueAsString;
			return true;
		case 4:
			template.CadObject.AlternateDimensioningSuffix = _reader.ValueAsString;
			return true;
		case 5:
			cadDimensionStyleTemplate.DIMBL_Name = _reader.ValueAsString;
			return true;
		case 6:
			cadDimensionStyleTemplate.DIMBLK1_Name = _reader.ValueAsString;
			return true;
		case 7:
			cadDimensionStyleTemplate.DIMBLK2_Name = _reader.ValueAsString;
			return true;
		case 40:
			template.CadObject.ScaleFactor = ((_reader.ValueAsDouble <= 0.0) ? 1.0 : _reader.ValueAsDouble);
			return true;
		case 41:
			template.CadObject.ArrowSize = _reader.ValueAsDouble;
			return true;
		case 42:
			template.CadObject.ExtensionLineOffset = _reader.ValueAsDouble;
			return true;
		case 43:
			template.CadObject.DimensionLineIncrement = _reader.ValueAsDouble;
			return true;
		case 44:
			template.CadObject.ExtensionLineExtension = _reader.ValueAsDouble;
			return true;
		case 45:
			template.CadObject.Rounding = _reader.ValueAsDouble;
			return true;
		case 46:
			template.CadObject.DimensionLineExtension = _reader.ValueAsDouble;
			return true;
		case 47:
			template.CadObject.PlusTolerance = _reader.ValueAsDouble;
			return true;
		case 48:
			template.CadObject.MinusTolerance = _reader.ValueAsDouble;
			return true;
		case 49:
			template.CadObject.FixedExtensionLineLength = _reader.ValueAsDouble;
			return true;
		case 50:
			template.CadObject.JoggedRadiusDimensionTransverseSegmentAngle = MathHelper.DegToRad(_reader.ValueAsDouble);
			return true;
		case 69:
			template.CadObject.TextBackgroundFillMode = (DimensionTextBackgroundFillMode)_reader.ValueAsShort;
			return true;
		case 70:
			if (!cadDimensionStyleTemplate.DxfFlagsAssigned)
			{
				cadDimensionStyleTemplate.DxfFlagsAssigned = true;
				return true;
			}
			if (_reader.ValueAsShort >= 0)
			{
				template.CadObject.TextBackgroundColor = new Color(_reader.ValueAsShort);
			}
			return true;
		case 71:
			template.CadObject.GenerateTolerances = _reader.ValueAsBool;
			return true;
		case 72:
			template.CadObject.LimitsGeneration = _reader.ValueAsBool;
			return true;
		case 73:
			template.CadObject.TextInsideHorizontal = _reader.ValueAsBool;
			return true;
		case 74:
			template.CadObject.TextOutsideHorizontal = _reader.ValueAsBool;
			return true;
		case 75:
			template.CadObject.SuppressFirstExtensionLine = _reader.ValueAsBool;
			return true;
		case 76:
			template.CadObject.SuppressSecondExtensionLine = _reader.ValueAsBool;
			return true;
		case 77:
			template.CadObject.TextVerticalAlignment = (DimensionTextVerticalAlignment)_reader.ValueAsShort;
			return true;
		case 78:
			template.CadObject.ZeroHandling = (ZeroHandling)_reader.ValueAsShort;
			return true;
		case 79:
			template.CadObject.AngularZeroHandling = (ZeroHandling)_reader.ValueAsShort;
			return true;
		case 90:
			template.CadObject.ArcLengthSymbolPosition = (ArcLengthSymbolPosition)_reader.ValueAsShort;
			return true;
		case 105:
			template.CadObject.Handle = _reader.ValueAsHandle;
			return true;
		case 140:
			template.CadObject.TextHeight = _reader.ValueAsDouble;
			return true;
		case 141:
			template.CadObject.CenterMarkSize = _reader.ValueAsDouble;
			return true;
		case 142:
			template.CadObject.TickSize = _reader.ValueAsDouble;
			return true;
		case 143:
			template.CadObject.AlternateUnitScaleFactor = _reader.ValueAsDouble;
			return true;
		case 144:
			template.CadObject.LinearScaleFactor = _reader.ValueAsDouble;
			return true;
		case 145:
			template.CadObject.TextVerticalPosition = _reader.ValueAsDouble;
			return true;
		case 146:
			template.CadObject.ToleranceScaleFactor = _reader.ValueAsDouble;
			return true;
		case 147:
			template.CadObject.DimensionLineGap = _reader.ValueAsDouble;
			return true;
		case 148:
			template.CadObject.AlternateUnitRounding = _reader.ValueAsDouble;
			return true;
		case 170:
			template.CadObject.AlternateUnitDimensioning = _reader.ValueAsBool;
			return true;
		case 171:
			template.CadObject.AlternateUnitDecimalPlaces = _reader.ValueAsShort;
			return true;
		case 172:
			template.CadObject.TextOutsideExtensions = _reader.ValueAsBool;
			return true;
		case 173:
			template.CadObject.SeparateArrowBlocks = _reader.ValueAsBool;
			return true;
		case 174:
			template.CadObject.TextInsideExtensions = _reader.ValueAsBool;
			return true;
		case 175:
			template.CadObject.SuppressOutsideExtensions = _reader.ValueAsBool;
			return true;
		case 176:
			template.CadObject.DimensionLineColor = new Color(_reader.ValueAsShort);
			return true;
		case 177:
			template.CadObject.ExtensionLineColor = new Color(_reader.ValueAsShort);
			return true;
		case 178:
			template.CadObject.TextColor = new Color(_reader.ValueAsShort);
			return true;
		case 179:
			template.CadObject.AngularDecimalPlaces = _reader.ValueAsShort;
			return true;
		case 270:
			template.CadObject.LinearUnitFormat = (LinearUnitFormat)_reader.ValueAsShort;
			return true;
		case 271:
			template.CadObject.DecimalPlaces = _reader.ValueAsShort;
			return true;
		case 272:
			template.CadObject.ToleranceDecimalPlaces = _reader.ValueAsShort;
			return true;
		case 273:
			template.CadObject.AlternateUnitFormat = (LinearUnitFormat)_reader.ValueAsShort;
			return true;
		case 274:
			template.CadObject.AlternateUnitToleranceDecimalPlaces = _reader.ValueAsShort;
			return true;
		case 275:
			template.CadObject.AngularUnit = (AngularUnitFormat)_reader.ValueAsShort;
			return true;
		case 276:
			template.CadObject.FractionFormat = (FractionFormat)_reader.ValueAsShort;
			return true;
		case 277:
			template.CadObject.LinearUnitFormat = (LinearUnitFormat)_reader.ValueAsShort;
			return true;
		case 278:
			template.CadObject.DecimalSeparator = (char)_reader.ValueAsShort;
			return true;
		case 279:
			template.CadObject.TextMovement = (TextMovement)_reader.ValueAsShort;
			return true;
		case 280:
			template.CadObject.TextHorizontalAlignment = (DimensionTextHorizontalAlignment)_reader.ValueAsShort;
			return true;
		case 281:
			template.CadObject.SuppressFirstDimensionLine = _reader.ValueAsBool;
			return true;
		case 282:
			template.CadObject.SuppressSecondDimensionLine = _reader.ValueAsBool;
			return true;
		case 283:
			template.CadObject.ToleranceAlignment = (ToleranceAlignment)_reader.ValueAsShort;
			return true;
		case 284:
			template.CadObject.ToleranceZeroHandling = (ZeroHandling)_reader.ValueAsShort;
			return true;
		case 285:
			template.CadObject.AlternateUnitZeroHandling = (ZeroHandling)_reader.ValueAsShort;
			return true;
		case 286:
			template.CadObject.AlternateUnitToleranceZeroHandling = (ZeroHandling)_reader.ValueAsShort;
			return true;
		case 287:
			template.CadObject.DimensionFit = _reader.ValueAsShort;
			return true;
		case 288:
			template.CadObject.CursorUpdate = _reader.ValueAsBool;
			return true;
		case 289:
			template.CadObject.DimensionTextArrowFit = (TextArrowFitType)_reader.ValueAsShort;
			return true;
		case 290:
			template.CadObject.IsExtensionLineLengthFixed = _reader.ValueAsBool;
			return true;
		case 340:
			cadDimensionStyleTemplate.TextStyleHandle = _reader.ValueAsHandle;
			return true;
		case 341:
			cadDimensionStyleTemplate.DIMLDRBLK = _reader.ValueAsHandle;
			return true;
		case 342:
			cadDimensionStyleTemplate.DIMBLK = _reader.ValueAsHandle;
			return true;
		case 343:
			cadDimensionStyleTemplate.DIMBLK1 = _reader.ValueAsHandle;
			return true;
		case 344:
			cadDimensionStyleTemplate.DIMBLK2 = _reader.ValueAsHandle;
			return true;
		case 345:
			cadDimensionStyleTemplate.Dimltype = _reader.ValueAsHandle;
			return true;
		case 346:
			cadDimensionStyleTemplate.Dimltex1 = _reader.ValueAsHandle;
			return true;
		case 347:
			cadDimensionStyleTemplate.Dimltex2 = _reader.ValueAsHandle;
			return true;
		case 371:
			template.CadObject.DimensionLineWeight = (LineWeightType)_reader.ValueAsShort;
			return true;
		case 372:
			template.CadObject.ExtensionLineWeight = (LineWeightType)_reader.ValueAsShort;
			return true;
		default:
			return false;
		}
	}

	private bool readLayer(CadTableEntryTemplate<Layer> template, DxfClassMap map)
	{
		CadLayerTemplate cadLayerTemplate = (CadLayerTemplate)template;
		switch (_reader.Code)
		{
		case 6:
			cadLayerTemplate.LineTypeName = _reader.ValueAsString;
			return true;
		case 62:
		{
			short num = _reader.ValueAsShort;
			if (num < 0)
			{
				template.CadObject.IsOn = false;
				num = Math.Abs(num);
			}
			Color color = new Color(num);
			if (color.IsByBlock || color.IsByLayer)
			{
				_builder.Notify($"Wrong index {num} for layer {template.CadObject.Name}", NotificationType.Warning);
			}
			else
			{
				template.CadObject.Color = new Color(num);
			}
			return true;
		}
		case 347:
			cadLayerTemplate.MaterialHandle = _reader.ValueAsHandle;
			return true;
		case 348:
			return true;
		case 390:
			template.CadObject.PlotStyleName = _reader.ValueAsHandle;
			return true;
		case 430:
			cadLayerTemplate.TrueColorName = _reader.ValueAsString;
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map);
		}
	}

	private bool readLineType(CadTableEntryTemplate<LineType> template, DxfClassMap map)
	{
		CadLineTypeTemplate cadLineTypeTemplate = (CadLineTypeTemplate)template;
		switch (_reader.Code)
		{
		case 40:
			cadLineTypeTemplate.TotalLen = _reader.ValueAsDouble;
			return true;
		case 49:
			do
			{
				cadLineTypeTemplate.SegmentTemplates.Add(readLineTypeSegment());
			}
			while (_reader.Code == 49);
			return true;
		case 73:
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map);
		}
	}

	private CadLineTypeTemplate.SegmentTemplate readLineTypeSegment()
	{
		CadLineTypeTemplate.SegmentTemplate segmentTemplate = new CadLineTypeTemplate.SegmentTemplate();
		segmentTemplate.Segment.Length = _reader.ValueAsDouble;
		_reader.ReadNext();
		while (_reader.Code != 49 && _reader.Code != 0)
		{
			switch (_reader.Code)
			{
			case 9:
				segmentTemplate.Segment.Text = _reader.ValueAsString;
				break;
			case 44:
				segmentTemplate.Segment.Offset = new XY(_reader.ValueAsDouble, segmentTemplate.Segment.Offset.Y);
				break;
			case 45:
				segmentTemplate.Segment.Offset = new XY(segmentTemplate.Segment.Offset.X, _reader.ValueAsDouble);
				break;
			case 46:
				segmentTemplate.Segment.Scale = _reader.ValueAsDouble;
				break;
			case 50:
				segmentTemplate.Segment.Rotation = _reader.ValueAsAngle;
				break;
			case 74:
				segmentTemplate.Segment.Flags = (LineTypeShapeFlags)_reader.ValueAsUShort;
				break;
			case 75:
				segmentTemplate.Segment.ShapeNumber = (short)_reader.ValueAsInt;
				break;
			default:
				_builder.Notify($"[LineTypeSegment] Unhandeled dxf code {_reader.Code} with value {_reader.ValueAsString}, positon {_reader.Position}");
				break;
			case 340:
				break;
			}
			_reader.ReadNext();
		}
		return segmentTemplate;
	}

	private bool readTextStyle(CadTableEntryTemplate<TextStyle> template, DxfClassMap map)
	{
		if (_reader.Code == 2)
		{
			if (!_reader.ValueAsString.IsNullOrEmpty())
			{
				template.CadObject.Name = _reader.ValueAsString;
			}
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map);
	}

	private bool readUcs(CadTableEntryTemplate<UCS> template, DxfClassMap map)
	{
		_ = _reader.Code;
		return tryAssignCurrentValue(template.CadObject, map);
	}

	private bool readView(CadTableEntryTemplate<View> template, DxfClassMap map)
	{
		CadViewTemplate cadViewTemplate = template as CadViewTemplate;
		if (_reader.Code == 348)
		{
			cadViewTemplate.VisualStyleHandle = _reader.ValueAsHandle;
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map);
	}

	private bool readVPort(CadTableEntryTemplate<VPort> template, DxfClassMap map)
	{
		CadVPortTemplate cadVPortTemplate = template as CadVPortTemplate;
		switch (_reader.Code)
		{
		case 65:
		case 73:
			return true;
		case 348:
			cadVPortTemplate.StyleHandle = _reader.ValueAsHandle;
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map);
		}
	}
}
