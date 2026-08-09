using System;
using System.Collections.Generic;
using System.Linq;
using ACadSharp.Entities;
using ACadSharp.Exceptions;
using ACadSharp.IO.Templates;
using ACadSharp.Objects;
using ACadSharp.XData;
using CSMath;

namespace ACadSharp.IO.DXF;

internal abstract class DxfSectionReaderBase
{
	public delegate bool ReadEntityDelegate<T>(CadEntityTemplate template, DxfMap map, string subclass = null) where T : Entity;

	protected readonly IDxfStreamReader _reader;

	protected readonly DxfDocumentBuilder _builder;

	protected bool lockPointer;

	protected string currentSubclass;

	public DxfSectionReaderBase(IDxfStreamReader reader, DxfDocumentBuilder builder)
	{
		_reader = reader;
		_builder = builder;
	}

	public abstract void Read();

	protected void readCommonObjectData(out string name, out ulong handle, out ulong? ownerHandle, out ulong? xdictHandle, out HashSet<ulong> reactors)
	{
		name = null;
		handle = 0uL;
		ownerHandle = null;
		xdictHandle = null;
		reactors = new HashSet<ulong>();
		if (_reader.DxfCode == DxfCode.Start || _reader.DxfCode == DxfCode.Subclass)
		{
			_reader.ReadNext();
		}
		while (_reader.DxfCode != DxfCode.Start && _reader.DxfCode != DxfCode.Subclass)
		{
			switch (_reader.Code)
			{
			case 2:
				name = _reader.ValueAsString;
				break;
			case 5:
			case 105:
				handle = _reader.ValueAsHandle;
				break;
			case 102:
				readDefinedGroups(out xdictHandle, out reactors);
				break;
			case 330:
				ownerHandle = _reader.ValueAsHandle;
				break;
			default:
				_builder.Notify($"Unhandled dxf code {_reader.Code} at line {_reader.Position}.");
				break;
			}
			_reader.ReadNext();
		}
	}

	[Obsolete("Only needed for SortEntitiesTable but it should be removed")]
	protected void readCommonObjectData(CadTemplate template)
	{
		while (_reader.DxfCode != DxfCode.Subclass)
		{
			switch (_reader.Code)
			{
			case 5:
				template.CadObject.Handle = _reader.ValueAsHandle;
				break;
			case 102:
				readDefinedGroups(template);
				break;
			case 330:
				template.OwnerHandle = _reader.ValueAsHandle;
				break;
			default:
				_builder.Notify($"Unhandled dxf code {_reader.Code} at line {_reader.Position}.");
				break;
			case 0:
				break;
			}
			_reader.ReadNext();
		}
	}

	protected void readCommonCodes(CadTemplate template, out bool isExtendedData, DxfMap map = null)
	{
		isExtendedData = false;
		switch (_reader.Code)
		{
		case 5:
			template.CadObject.Handle = _reader.ValueAsHandle;
			break;
		case 100:
			currentSubclass = _reader.ValueAsString;
			if (map != null && !map.SubClasses.ContainsKey(_reader.ValueAsString))
			{
				_builder.Notify("[" + template.CadObject.ObjectName + "] Unidentified subclass " + _reader.ValueAsString, NotificationType.Warning);
			}
			break;
		case 102:
			readDefinedGroups(template);
			break;
		case 330:
			template.OwnerHandle = _reader.ValueAsHandle;
			break;
		case 1001:
			isExtendedData = true;
			readExtendedData(template.EDataTemplateByAppName);
			break;
		default:
			_builder.Notify($"[{template.CadObject.SubclassMarker}] Unhandled dxf code {_reader.Code} with value {_reader.ValueAsString}");
			break;
		}
	}

	protected CadEntityTemplate readEntity()
	{
		switch (_reader.ValueAsString)
		{
		case "ATTRIB":
			return readEntityCodes<AttributeEntity>(new CadAttributeTemplate(new AttributeEntity()), readAttributeDefinition);
		case "ATTDEF":
			return readEntityCodes<AttributeDefinition>(new CadAttributeTemplate(new AttributeDefinition()), readAttributeDefinition);
		case "ARC":
			return readEntityCodes<Arc>(new CadEntityTemplate<Arc>(), readArc);
		case "BODY":
			return readEntityCodes<CadBody>(new CadEntityTemplate<CadBody>(), readEntitySubclassMap);
		case "CIRCLE":
			return readEntityCodes<Circle>(new CadEntityTemplate<Circle>(), readCircle);
		case "DIMENSION":
			return readEntityCodes<Dimension>(new CadDimensionTemplate(), readDimension);
		case "3DFACE":
			return readEntityCodes<Face3D>(new CadEntityTemplate<Face3D>(), readEntitySubclassMap);
		case "ELLIPSE":
			return readEntityCodes<Ellipse>(new CadEntityTemplate<Ellipse>(), readEntitySubclassMap);
		case "LEADER":
			return readEntityCodes<Leader>(new CadLeaderTemplate(), readLeader);
		case "LINE":
			return readEntityCodes<Line>(new CadEntityTemplate<Line>(), readEntitySubclassMap);
		case "LWPOLYLINE":
			return readEntityCodes<LwPolyline>(new CadEntityTemplate<LwPolyline>(), readLwPolyline);
		case "MESH":
			return readEntityCodes<Mesh>(new CadMeshTemplate(), readMesh);
		case "HATCH":
			return readEntityCodes<Hatch>(new CadHatchTemplate(), readHatch);
		case "INSERT":
			return readEntityCodes<Insert>(new CadInsertTemplate(), readInsert);
		case "MTEXT":
			return readEntityCodes<MText>(new CadTextEntityTemplate(new MText()), readTextEntity);
		case "MLINE":
			return readEntityCodes<MLine>(new CadMLineTemplate(), readMLine);
		case "MULTILEADER":
			return readEntityCodes<MultiLeader>(new CadMLeaderTemplate(), readMLeader);
		case "PDFUNDERLAY":
			return readEntityCodes<PdfUnderlay>(new CadUnderlayTemplate<PdfUnderlayDefinition>(new PdfUnderlay()), readUnderlayEntity<PdfUnderlayDefinition>);
		case "POINT":
			return readEntityCodes<Point>(new CadEntityTemplate<Point>(), readEntitySubclassMap);
		case "POLYLINE":
			return readPolyline();
		case "OLE2FRAME":
			return readEntityCodes<Ole2Frame>(new CadOle2FrameTemplate(), readOle2Frame);
		case "RAY":
			return readEntityCodes<Ray>(new CadEntityTemplate<Ray>(), readEntitySubclassMap);
		case "SEQEND":
			return readEntityCodes<Seqend>(new CadEntityTemplate<Seqend>(), readEntitySubclassMap);
		case "TRACE":
		case "SOLID":
			return readEntityCodes<Solid>(new CadEntityTemplate<Solid>(), readModelerGeometry);
		case "ACAD_TABLE":
			return readEntityCodes<TableEntity>(new CadTableEntityTemplate(), readTableEntity);
		case "TEXT":
			return readEntityCodes<TextEntity>(new CadTextEntityTemplate(new TextEntity()), readTextEntity);
		case "TOLERANCE":
			return readEntityCodes<Tolerance>(new CadToleranceTemplate(new Tolerance()), readTolerance);
		case "VERTEX":
			return readEntityCodes<Entity>(new CadVertexTemplate(), readVertex);
		case "VIEWPORT":
			return readEntityCodes<Viewport>(new CadViewportTemplate(), readViewport);
		case "SHAPE":
			return readEntityCodes<Shape>(new CadShapeTemplate(new Shape()), readShape);
		case "SPLINE":
			return readEntityCodes<Spline>(new CadSplineTemplate(), readSpline);
		case "3DSOLID":
			return readEntityCodes<Solid3D>(new CadSolid3DTemplate(), readSolid3d);
		case "REGION":
			return readEntityCodes<Region>(new CadEntityTemplate<Region>(), readModelerGeometry);
		case "IMAGE":
			return readEntityCodes<RasterImage>(new CadWipeoutBaseTemplate(new RasterImage()), readWipeoutBase);
		case "WIPEOUT":
			return readEntityCodes<Wipeout>(new CadWipeoutBaseTemplate(new Wipeout()), readWipeoutBase);
		case "XLINE":
			return readEntityCodes<XLine>(new CadEntityTemplate<XLine>(), readEntitySubclassMap);
		default:
		{
			DxfMap map = DxfMap.Create<Entity>();
			CadUnknownEntityTemplate cadUnknownEntityTemplate = null;
			if (_builder.DocumentToBuild.Classes.TryGetByName(_reader.ValueAsString, out var result))
			{
				_builder.Notify("Entity not supported read as an UnknownEntity: " + _reader.ValueAsString, NotificationType.NotImplemented);
				cadUnknownEntityTemplate = new CadUnknownEntityTemplate(new UnknownEntity(result));
			}
			else
			{
				_builder.Notify("Entity not supported: " + _reader.ValueAsString, NotificationType.NotImplemented);
			}
			_reader.ReadNext();
			do
			{
				if (cadUnknownEntityTemplate != null && _builder.KeepUnknownEntities)
				{
					readCommonEntityCodes(cadUnknownEntityTemplate, out var isExtendedData, map);
					if (isExtendedData)
					{
						continue;
					}
				}
				_reader.ReadNext();
			}
			while (_reader.DxfCode != DxfCode.Start);
			return cadUnknownEntityTemplate;
		}
		}
	}

	protected CadEntityTemplate readEntityCodes<T>(CadEntityTemplate template, ReadEntityDelegate<T> readEntity) where T : Entity
	{
		_reader.ReadNext();
		DxfMap map = DxfMap.Create<T>();
		while (_reader.DxfCode != DxfCode.Start)
		{
			if (!readEntity(template, map))
			{
				readCommonEntityCodes(template, out var isExtendedData, map);
				if (isExtendedData)
				{
					continue;
				}
			}
			if (lockPointer)
			{
				lockPointer = false;
			}
			else if (_reader.DxfCode != DxfCode.Start)
			{
				_reader.ReadNext();
			}
		}
		return template;
	}

	protected void readCommonEntityCodes(CadEntityTemplate template, out bool isExtendedData, DxfMap map = null)
	{
		isExtendedData = false;
		switch (_reader.Code)
		{
		case 6:
			template.LineTypeName = _reader.ValueAsString;
			return;
		case 8:
			template.LayerName = _reader.ValueAsString;
			return;
		case 347:
			template.MaterialHandle = _reader.ValueAsHandle;
			return;
		case 430:
			template.BookColorName = _reader.ValueAsString;
			return;
		case 67:
		case 92:
		case 160:
		case 310:
			return;
		}
		if (!tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbEntity"]))
		{
			readCommonCodes(template, out isExtendedData, map);
		}
	}

	protected bool checkObjectEnd(CadTemplate template, DxfMap map, Func<CadTemplate, DxfMap, bool> func)
	{
		if (_reader.DxfCode == DxfCode.Start)
		{
			return true;
		}
		return func(template, map);
	}

	protected bool checkEntityEnd(CadEntityTemplate template, DxfMap map, string subclass, Func<CadEntityTemplate, DxfMap, string, bool> func)
	{
		if (_reader.DxfCode == DxfCode.Start)
		{
			return true;
		}
		return func(template, map, subclass);
	}

	private bool readCircle(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		Circle circle = template.CadObject as Circle;
		if (_reader.Code == 40)
		{
			double valueAsDouble = _reader.ValueAsDouble;
			if (valueAsDouble <= 0.0)
			{
				circle.Radius = 1E-12;
			}
			else
			{
				circle.Radius = valueAsDouble;
			}
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbCircle"]);
	}

	private bool readArc(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		_ = _reader.Code;
		if (!tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbArc"]))
		{
			return readCircle(template, map, "AcDbCircle");
		}
		return true;
	}

	private bool readAttributeDefinition(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		DxfClassMap map2 = map.SubClasses[template.CadObject.SubclassMarker];
		CadAttributeTemplate cadAttributeTemplate = template as CadAttributeTemplate;
		switch (_reader.Code)
		{
		case 44:
		case 46:
			return true;
		case 101:
		{
			AttributeBase obj = cadAttributeTemplate.CadObject as AttributeBase;
			obj.MText = new MText();
			CadTextEntityTemplate template2 = (cadAttributeTemplate.MTextTemplate = new CadTextEntityTemplate(obj.MText));
			readEntityCodes<MText>(template2, readTextEntity);
			return true;
		}
		default:
			if (!tryAssignCurrentValue(template.CadObject, map2))
			{
				return readTextEntity(template, map, "AcDbText");
			}
			return true;
		}
	}

	private bool readTableEntity(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		if (string.IsNullOrEmpty(subclass))
		{
			_ = template.CadObject.SubclassMarker;
		}
		CadTableEntityTemplate cadTableEntityTemplate = template as CadTableEntityTemplate;
		TableEntity tableEntity = cadTableEntityTemplate.CadObject as TableEntity;
		switch (_reader.Code)
		{
		case 1:
		{
			TableEntity.CellContent cellContent;
			if (cadTableEntityTemplate.CurrentCell.Content == null)
			{
				cellContent = new TableEntity.CellContent();
				cellContent.Value.ValueType = TableEntity.CellValueType.String;
				cadTableEntityTemplate.CurrentCell.Contents.Add(cellContent);
			}
			else
			{
				cellContent = cadTableEntityTemplate.CurrentCell.Content;
			}
			if (cellContent.Value.Value == null)
			{
				cellContent.Value.Value = _reader.ValueAsString;
			}
			else
			{
				string text = cellContent.Value.Value as string;
				text += _reader.ValueAsString;
				cellContent.Value.Value = text;
			}
			return true;
		}
		case 2:
			if (currentSubclass.Equals("AcDbTable", StringComparison.OrdinalIgnoreCase))
			{
				TableEntity.CellContent cellContent = cadTableEntityTemplate.CurrentCell.Content;
				if (cellContent.Value.Value == null)
				{
					cellContent.Value.Value = _reader.ValueAsString;
				}
				else
				{
					string text2 = cellContent.Value.Value as string;
					text2 += _reader.ValueAsString;
					cellContent.Value.Value = text2;
				}
			}
			else
			{
				cadTableEntityTemplate.BlockName = _reader.ValueAsString;
			}
			return true;
		case 177:
			return true;
		case 279:
			cadTableEntityTemplate.CurrentCell.StyleOverride.TopBorder.LineWeight = (LineWeightType)_reader.ValueAsShort;
			return true;
		case 275:
			cadTableEntityTemplate.CurrentCell.StyleOverride.RightBorder.LineWeight = (LineWeightType)_reader.ValueAsShort;
			return true;
		case 276:
			cadTableEntityTemplate.CurrentCell.StyleOverride.BottomBorder.LineWeight = (LineWeightType)_reader.ValueAsShort;
			return true;
		case 278:
			cadTableEntityTemplate.CurrentCell.StyleOverride.LeftBorder.LineWeight = (LineWeightType)_reader.ValueAsShort;
			return true;
		case 69:
			cadTableEntityTemplate.CurrentCell.StyleOverride.TopBorder.Color = new Color(_reader.ValueAsShort);
			return true;
		case 65:
			cadTableEntityTemplate.CurrentCell.StyleOverride.RightBorder.Color = new Color(_reader.ValueAsShort);
			return true;
		case 66:
			cadTableEntityTemplate.CurrentCell.StyleOverride.BottomBorder.Color = new Color(_reader.ValueAsShort);
			return true;
		case 68:
			cadTableEntityTemplate.CurrentCell.StyleOverride.LeftBorder.Color = new Color(_reader.ValueAsShort);
			return true;
		case 40:
			cadTableEntityTemplate.HorizontalMargin = _reader.ValueAsDouble;
			return true;
		case 63:
			cadTableEntityTemplate.CurrentCell.StyleOverride.BackgroundColor = new Color(_reader.ValueAsShort);
			return true;
		case 64:
			cadTableEntityTemplate.CurrentCell.StyleOverride.ContentColor = new Color(_reader.ValueAsShort);
			return true;
		case 140:
			if (cadTableEntityTemplate.CurrentCellTemplate != null)
			{
				cadTableEntityTemplate.CurrentCellTemplate.FormatTextHeight = _reader.ValueAsDouble;
			}
			return true;
		case 283:
			cadTableEntityTemplate.CurrentCell.StyleOverride.IsFillColorOn = _reader.ValueAsBool;
			return true;
		case 342:
			cadTableEntityTemplate.StyleHandle = _reader.ValueAsHandle;
			return true;
		case 343:
			cadTableEntityTemplate.BlockOwnerHandle = _reader.ValueAsHandle;
			return true;
		case 141:
		{
			TableEntity.Row row = new TableEntity.Row();
			row.Height = _reader.ValueAsDouble;
			tableEntity.Rows.Add(row);
			return true;
		}
		case 142:
		{
			TableEntity.Column column = new TableEntity.Column();
			column.Width = _reader.ValueAsDouble;
			tableEntity.Columns.Add(column);
			return true;
		}
		case 144:
			cadTableEntityTemplate.CurrentCellTemplate.FormatTextHeight = _reader.ValueAsDouble;
			return true;
		case 145:
			cadTableEntityTemplate.CurrentCell.Rotation = _reader.ValueAsDouble;
			return true;
		case 170:
			return true;
		case 171:
			cadTableEntityTemplate.CreateCell((TableEntity.CellType)_reader.ValueAsInt);
			return true;
		case 172:
			cadTableEntityTemplate.CurrentCell.EdgeFlags = _reader.ValueAsShort;
			return true;
		case 173:
			cadTableEntityTemplate.CurrentCell.MergedValue = _reader.ValueAsShort;
			return true;
		case 174:
			cadTableEntityTemplate.CurrentCell.AutoFit = _reader.ValueAsBool;
			return true;
		case 175:
			cadTableEntityTemplate.CurrentCell.BorderWidth = _reader.ValueAsInt;
			return true;
		case 176:
			cadTableEntityTemplate.CurrentCell.BorderHeight = _reader.ValueAsInt;
			return true;
		case 178:
			cadTableEntityTemplate.CurrentCell.VirtualEdgeFlag = _reader.ValueAsShort;
			return true;
		case 179:
			return true;
		case 301:
		{
			TableEntity.CellContent cellContent = new TableEntity.CellContent();
			cadTableEntityTemplate.CurrentCell.Contents.Add(cellContent);
			readCellValue(cellContent);
			return true;
		}
		case 340:
			cadTableEntityTemplate.CurrentCellTemplate.ValueHandle = _reader.ValueAsHandle;
			return true;
		default:
			if (!tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbBlockReference"]))
			{
				return readEntitySubclassMap(template, map, "AcDbTable");
			}
			return true;
		}
	}

	private void readCellValue(TableEntity.CellContent content)
	{
		if (_reader.ValueAsString.Equals("CELL_VALUE", StringComparison.OrdinalIgnoreCase))
		{
			_reader.ReadNext();
			while (_reader.Code != 304 && !_reader.ValueAsString.Equals("ACVALUE_END", StringComparison.OrdinalIgnoreCase))
			{
				switch (_reader.Code)
				{
				case 1:
					content.Value.Text = _reader.ValueAsString;
					break;
				case 2:
					content.Value.Text += _reader.ValueAsString;
					break;
				case 11:
					content.Value.Value = new XYZ(_reader.ValueAsDouble, 0.0, 0.0);
					break;
				case 21:
					content.Value.Value = new XYZ(0.0, _reader.ValueAsDouble, 0.0);
					break;
				case 31:
					content.Value.Value = new XYZ(0.0, 0.0, _reader.ValueAsDouble);
					break;
				case 302:
					content.Value.Value = _reader.ValueAsString;
					break;
				case 90:
					content.Value.ValueType = (TableEntity.CellValueType)_reader.ValueAsInt;
					break;
				case 91:
					content.Value.Value = _reader.ValueAsInt;
					break;
				case 93:
					content.Value.Flags = _reader.ValueAsInt;
					break;
				case 94:
					content.Value.Units = (TableEntity.ValueUnitType)_reader.ValueAsInt;
					break;
				case 140:
					content.Value.Value = _reader.ValueAsDouble;
					break;
				case 300:
					content.Value.Format = _reader.ValueAsString;
					break;
				default:
					_builder.Notify($"[CELL_VALUE] Unhandled dxf code {_reader.Code} with value {_reader.ValueAsString}");
					break;
				case 92:
				case 310:
					break;
				}
				_reader.ReadNext();
			}
			return;
		}
		throw new DxfException("Expected value not found CELL_VALUE", _reader.Position);
	}

	private bool readTextEntity(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		string key = (string.IsNullOrEmpty(subclass) ? template.CadObject.SubclassMarker : subclass);
		CadTextEntityTemplate cadTextEntityTemplate = template as CadTextEntityTemplate;
		switch (_reader.Code)
		{
		case 1:
		case 3:
			if (cadTextEntityTemplate.CadObject is MText mText2)
			{
				mText2.Value += _reader.ValueAsString;
				return true;
			}
			break;
		case 50:
			if (cadTextEntityTemplate.CadObject is MText mText)
			{
				double num = MathHelper.DegToRad(_reader.ValueAsDouble);
				mText.AlignmentPoint = new XYZ(Math.Cos(num), Math.Sin(num), 0.0);
				return true;
			}
			break;
		case 70:
		case 74:
		case 101:
			return true;
		case 7:
			cadTextEntityTemplate.StyleName = _reader.ValueAsString;
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map.SubClasses[key]);
	}

	private bool readTolerance(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadToleranceTemplate cadToleranceTemplate = template as CadToleranceTemplate;
		if (_reader.Code == 3)
		{
			cadToleranceTemplate.DimensionStyleName = _reader.ValueAsString;
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map.SubClasses[template.CadObject.SubclassMarker]);
	}

	private bool readDimension(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadDimensionTemplate cadDimensionTemplate = template as CadDimensionTemplate;
		switch (_reader.Code)
		{
		case 2:
			cadDimensionTemplate.BlockName = _reader.ValueAsString;
			return true;
		case 3:
			cadDimensionTemplate.StyleName = _reader.ValueAsString;
			return true;
		case 50:
		{
			DimensionLinear dimensionLinear = new DimensionLinear();
			cadDimensionTemplate.SetDimensionObject(dimensionLinear);
			dimensionLinear.Rotation = _reader.ValueAsAngle;
			map.SubClasses.Add("AcDbRotatedDimension", DxfClassMap.Create<DimensionLinear>());
			return true;
		}
		case 70:
			cadDimensionTemplate.SetDimensionFlags((DimensionType)_reader.ValueAsShort);
			return true;
		case 42:
			return true;
		case 73:
		case 74:
		case 75:
		case 90:
		case 361:
			return true;
		case 100:
			switch (_reader.ValueAsString)
			{
			case "AcDbDimension":
				return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbDimension"]);
			case "AcDbAlignedDimension":
				cadDimensionTemplate.SetDimensionObject(new DimensionAligned());
				map.SubClasses.Add(_reader.ValueAsString, DxfClassMap.Create<DimensionAligned>());
				return true;
			case "AcDbDiametricDimension":
				cadDimensionTemplate.SetDimensionObject(new DimensionDiameter());
				map.SubClasses.Add(_reader.ValueAsString, DxfClassMap.Create<DimensionDiameter>());
				return true;
			case "AcDb2LineAngularDimension":
				cadDimensionTemplate.SetDimensionObject(new DimensionAngular2Line());
				map.SubClasses.Add(_reader.ValueAsString, DxfClassMap.Create<DimensionAngular2Line>());
				return true;
			case "AcDb3PointAngularDimension":
				cadDimensionTemplate.SetDimensionObject(new DimensionAngular3Pt());
				map.SubClasses.Add(_reader.ValueAsString, DxfClassMap.Create<DimensionAngular3Pt>());
				return true;
			case "AcDbRadialDimension":
				cadDimensionTemplate.SetDimensionObject(new DimensionRadius());
				map.SubClasses.Add(_reader.ValueAsString, DxfClassMap.Create<DimensionRadius>());
				return true;
			case "AcDbOrdinateDimension":
				cadDimensionTemplate.SetDimensionObject(new DimensionOrdinate());
				map.SubClasses.Add(_reader.ValueAsString, DxfClassMap.Create<DimensionOrdinate>());
				return true;
			case "AcDbRotatedDimension":
				return true;
			default:
				return false;
			}
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadDimensionTemplate.CadObject.SubclassMarker]);
		}
	}

	protected bool readHatch(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadHatchTemplate cadHatchTemplate = template as CadHatchTemplate;
		Hatch cadObject = cadHatchTemplate.CadObject;
		XY item = default(XY);
		switch (_reader.Code)
		{
		case 2:
			cadObject.Pattern.Name = _reader.ValueAsString;
			return true;
		case 10:
			item.X = _reader.ValueAsDouble;
			cadObject.SeedPoints.Add(item);
			return true;
		case 20:
			item = cadObject.SeedPoints.LastOrDefault();
			item.Y = _reader.ValueAsDouble;
			cadObject.SeedPoints[cadObject.SeedPoints.Count - 1] = item;
			return true;
		case 30:
			cadObject.Elevation = _reader.ValueAsDouble;
			return true;
		case 53:
			cadObject.PatternAngle = _reader.ValueAsAngle;
			return true;
		case 90:
			return true;
		case 75:
			return true;
		case 78:
			readPattern(cadObject.Pattern, _reader.ValueAsInt);
			lockPointer = true;
			return true;
		case 91:
			readLoops(cadHatchTemplate, _reader.ValueAsInt);
			lockPointer = true;
			return true;
		case 98:
			return true;
		case 450:
			cadObject.GradientColor.Enabled = _reader.ValueAsBool;
			return true;
		case 451:
			cadObject.GradientColor.Reserved = _reader.ValueAsInt;
			return true;
		case 452:
			cadObject.GradientColor.IsSingleColorGradient = _reader.ValueAsBool;
			return true;
		case 453:
			return true;
		case 460:
			cadObject.GradientColor.Angle = _reader.ValueAsDouble;
			return true;
		case 461:
			cadObject.GradientColor.Shift = _reader.ValueAsDouble;
			return true;
		case 462:
			cadObject.GradientColor.ColorTint = _reader.ValueAsDouble;
			return true;
		case 463:
		{
			GradientColor gradientColor2 = new GradientColor();
			gradientColor2.Value = _reader.ValueAsDouble;
			cadObject.GradientColor.Colors.Add(gradientColor2);
			return true;
		}
		case 63:
		{
			GradientColor gradientColor = cadObject.GradientColor.Colors.LastOrDefault();
			if (gradientColor != null)
			{
				gradientColor.Color = new Color((short)_reader.ValueAsUShort);
			}
			return true;
		}
		case 421:
			cadObject.GradientColor.Colors.LastOrDefault();
			return true;
		case 470:
			cadObject.GradientColor.Name = _reader.ValueAsString;
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[template.CadObject.SubclassMarker]);
		}
	}

	private bool readInsert(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadInsertTemplate cadInsertTemplate = template as CadInsertTemplate;
		switch (_reader.Code)
		{
		case 2:
			cadInsertTemplate.BlockName = _reader.ValueAsString;
			return true;
		case 100:
			return true;
		case 66:
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbBlockReference"]);
		}
	}

	private CadEntityTemplate readPolyline()
	{
		CadPolyLineTemplate cadPolyLineTemplate = null;
		if (_builder.Version == ACadVersion.Unknown || _builder.Version == ACadVersion.AC1009)
		{
			Polyline2D polyline2D = new Polyline2D();
			cadPolyLineTemplate = new CadPolyLineTemplate(polyline2D);
			readEntityCodes<Polyline2D>(cadPolyLineTemplate, readPolyline);
			while (_reader.Code == 0 && _reader.ValueAsString == "VERTEX")
			{
				Vertex2D vertex2D = new Vertex2D();
				CadVertexTemplate cadVertexTemplate = new CadVertexTemplate(vertex2D);
				readEntityCodes<Vertex2D>(cadVertexTemplate, readVertex);
				if (cadVertexTemplate.Vertex.Handle == 0L)
				{
					polyline2D.Vertices.Add(vertex2D);
					continue;
				}
				cadPolyLineTemplate.OwnedObjectsHandlers.Add(cadVertexTemplate.Vertex.Handle);
				_builder.AddTemplate(cadVertexTemplate);
			}
			while (_reader.Code == 0 && _reader.ValueAsString == "SEQEND")
			{
				Seqend seqend = new Seqend();
				CadEntityTemplate<Seqend> template = new CadEntityTemplate<Seqend>(seqend);
				readEntityCodes<Seqend>(template, readEntitySubclassMap);
				polyline2D.Vertices.Seqend = seqend;
			}
		}
		else
		{
			cadPolyLineTemplate = new CadPolyLineTemplate();
			readEntityCodes<Entity>(cadPolyLineTemplate, readPolyline);
		}
		if (cadPolyLineTemplate.CadObject is CadPolyLineTemplate.PolyLinePlaceholder)
		{
			_builder.Notify("[POLYLINE] Subclass not found, entity discarded", NotificationType.Warning);
			return null;
		}
		return cadPolyLineTemplate;
	}

	private bool readPolyline(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadPolyLineTemplate cadPolyLineTemplate = template as CadPolyLineTemplate;
		switch (_reader.Code)
		{
		case 10:
		case 20:
		case 66:
		case 71:
		case 72:
		case 73:
		case 74:
			return true;
		case 100:
			switch (_reader.ValueAsString)
			{
			case "AcDb2dPolyline":
				cadPolyLineTemplate.SetPolyLineObject(new Polyline2D());
				map.SubClasses.Add("AcDb2dPolyline", DxfClassMap.Create<Polyline2D>());
				return true;
			case "AcDb3dPolyline":
				cadPolyLineTemplate.SetPolyLineObject(new Polyline3D());
				map.SubClasses.Add("AcDb3dPolyline", DxfClassMap.Create<Polyline3D>());
				return true;
			case "AcDbPolyFaceMesh":
				cadPolyLineTemplate.SetPolyLineObject(new PolyfaceMesh());
				map.SubClasses.Add("AcDbPolyFaceMesh", DxfClassMap.Create<PolyfaceMesh>());
				return true;
			default:
				return false;
			}
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadPolyLineTemplate.CadObject.SubclassMarker]);
		}
	}

	private bool readLeader(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadLeaderTemplate cadLeaderTemplate = template as CadLeaderTemplate;
		switch (_reader.Code)
		{
		case 3:
			cadLeaderTemplate.DIMSTYLEName = _reader.ValueAsString;
			return true;
		case 10:
			cadLeaderTemplate.CadObject.Vertices.Add(new XYZ(_reader.ValueAsDouble, 0.0, 0.0));
			return true;
		case 20:
		{
			XYZ value2 = cadLeaderTemplate.CadObject.Vertices[cadLeaderTemplate.CadObject.Vertices.Count - 1];
			value2.Y = _reader.ValueAsDouble;
			cadLeaderTemplate.CadObject.Vertices[cadLeaderTemplate.CadObject.Vertices.Count - 1] = value2;
			return true;
		}
		case 30:
		{
			XYZ value = cadLeaderTemplate.CadObject.Vertices[cadLeaderTemplate.CadObject.Vertices.Count - 1];
			value.Z = _reader.ValueAsDouble;
			cadLeaderTemplate.CadObject.Vertices[cadLeaderTemplate.CadObject.Vertices.Count - 1] = value;
			return true;
		}
		case 340:
			cadLeaderTemplate.AnnotationHandle = _reader.ValueAsHandle;
			return true;
		case 75:
		case 76:
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadLeaderTemplate.CadObject.SubclassMarker]);
		}
	}

	private bool readLwPolyline(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadEntityTemplate<LwPolyline> cadEntityTemplate = template as CadEntityTemplate<LwPolyline>;
		LwPolyline.Vertex vertex = cadEntityTemplate.CadObject.Vertices.LastOrDefault();
		switch (_reader.Code)
		{
		case 10:
			cadEntityTemplate.CadObject.Vertices.Add(new LwPolyline.Vertex(new XY(_reader.ValueAsDouble, 0.0)));
			return true;
		case 20:
			if (vertex != null)
			{
				vertex.Location = new XY(vertex.Location.X, _reader.ValueAsDouble);
			}
			return true;
		case 40:
			if (vertex != null)
			{
				vertex.StartWidth = _reader.ValueAsDouble;
			}
			return true;
		case 41:
			if (vertex != null)
			{
				vertex.EndWidth = _reader.ValueAsDouble;
			}
			return true;
		case 42:
			if (vertex != null)
			{
				vertex.Bulge = _reader.ValueAsDouble;
			}
			return true;
		case 50:
			if (vertex != null)
			{
				vertex.CurveTangent = _reader.ValueAsDouble;
			}
			return true;
		case 66:
		case 90:
			return true;
		case 91:
			if (vertex != null)
			{
				vertex.Id = _reader.ValueAsInt;
			}
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadEntityTemplate.CadObject.SubclassMarker]);
		}
	}

	private bool readMesh(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadMeshTemplate cadMeshTemplate = template as CadMeshTemplate;
		switch (_reader.Code)
		{
		case 100:
			if (_reader.ValueAsString.Equals("AcDbSubDMesh", StringComparison.OrdinalIgnoreCase))
			{
				cadMeshTemplate.SubclassMarker = true;
			}
			return true;
		case 90:
			return true;
		case 92:
		{
			if (!cadMeshTemplate.SubclassMarker)
			{
				return false;
			}
			int valueAsInt3 = _reader.ValueAsInt;
			for (int m = 0; m < valueAsInt3; m++)
			{
				_reader.ReadNext();
				double valueAsDouble = _reader.ValueAsDouble;
				_reader.ReadNext();
				double valueAsDouble2 = _reader.ValueAsDouble;
				_reader.ReadNext();
				double valueAsDouble3 = _reader.ValueAsDouble;
				cadMeshTemplate.CadObject.Vertices.Add(new XYZ(valueAsDouble, valueAsDouble2, valueAsDouble3));
			}
			return true;
		}
		case 93:
		{
			int valueAsInt = _reader.ValueAsInt;
			_reader.ReadNext();
			int num = 0;
			for (int j = 0; j < valueAsInt; j += num + 1)
			{
				num = _reader.ValueAsInt;
				_reader.ReadNext();
				int[] array = new int[num];
				for (int k = 0; k < num; k++)
				{
					array[k] = _reader.ValueAsInt;
					if (j + k + 2 < valueAsInt)
					{
						_reader.ReadNext();
					}
				}
				cadMeshTemplate.CadObject.Faces.Add(array);
			}
			return true;
		}
		case 94:
		{
			int valueAsInt2 = _reader.ValueAsInt;
			_reader.ReadNext();
			for (int l = 0; l < valueAsInt2; l++)
			{
				Mesh.Edge item = new Mesh.Edge
				{
					Start = _reader.ValueAsInt
				};
				_reader.ReadNext();
				item.End = _reader.ValueAsInt;
				if (l < valueAsInt2 - 1)
				{
					_reader.ReadNext();
				}
				cadMeshTemplate.CadObject.Edges.Add(item);
			}
			return true;
		}
		case 95:
		{
			_reader.ReadNext();
			for (int i = 0; i < cadMeshTemplate.CadObject.Edges.Count; i++)
			{
				Mesh.Edge value = cadMeshTemplate.CadObject.Edges[i];
				value.Crease = _reader.ValueAsDouble;
				cadMeshTemplate.CadObject.Edges[i] = value;
				if (i < cadMeshTemplate.CadObject.Edges.Count - 1)
				{
					_reader.ReadNext();
				}
			}
			return true;
		}
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadMeshTemplate.CadObject.SubclassMarker]);
		}
	}

	private bool readMLine(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadMLineTemplate cadMLineTemplate = template as CadMLineTemplate;
		switch (_reader.Code)
		{
		case 2:
			cadMLineTemplate.MLineStyleName = _reader.ValueAsString;
			return true;
		case 72:
			cadMLineTemplate.NVertex = _reader.ValueAsInt;
			return true;
		case 73:
			cadMLineTemplate.NElements = _reader.ValueAsInt;
			return true;
		case 340:
			cadMLineTemplate.MLineStyleHandle = _reader.ValueAsHandle;
			return true;
		default:
			if (!cadMLineTemplate.TryReadVertex(_reader.Code, _reader.Value))
			{
				return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadMLineTemplate.CadObject.SubclassMarker]);
			}
			return true;
		}
	}

	private bool readMLeader(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadMLeaderTemplate cadMLeaderTemplate = template as CadMLeaderTemplate;
		switch (_reader.Code)
		{
		case 270:
			return true;
		case 300:
			readMultiLeaderObjectContextData(cadMLeaderTemplate.CadMLeaderAnnotContextTemplate);
			return true;
		case 340:
			cadMLeaderTemplate.LeaderStyleHandle = _reader.ValueAsHandle;
			return true;
		case 341:
			cadMLeaderTemplate.LeaderLineTypeHandle = _reader.ValueAsHandle;
			return true;
		case 343:
			cadMLeaderTemplate.MTextStyleHandle = _reader.ValueAsHandle;
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadMLeaderTemplate.CadObject.SubclassMarker]);
		}
	}

	private void readMultiLeaderObjectContextData(CadMLeaderAnnotContextTemplate template)
	{
		_reader.ReadNext();
		DxfMap dxfMap = DxfMap.Create<MultiLeaderObjectContextData>();
		MultiLeaderObjectContextData multiLeaderObjectContextData = template.CadObject as MultiLeaderObjectContextData;
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code != 301)
			{
				if (code != 302)
				{
					if (code != 340)
					{
						goto IL_00a6;
					}
					template.TextStyleHandle = _reader.ValueAsHandle;
				}
				else
				{
					if (!_reader.ValueAsString.Equals("LEADER{"))
					{
						goto IL_00a6;
					}
					multiLeaderObjectContextData.LeaderRoots.Add(readMultiLeaderLeader(template));
				}
			}
			else
			{
				if (!_reader.ValueAsString.Equals("}"))
				{
					goto IL_00a6;
				}
				flag = true;
			}
			goto IL_00f2;
			IL_00a6:
			if (!tryAssignCurrentValue(multiLeaderObjectContextData, dxfMap.SubClasses[multiLeaderObjectContextData.SubclassMarker]))
			{
				_builder.Notify($"[AcDbMLeaderObjectContextData] Unhandled dxf code {_reader.Code} with value {_reader.ValueAsString}");
			}
			goto IL_00f2;
			IL_00f2:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private MultiLeaderObjectContextData.LeaderRoot readMultiLeaderLeader(CadMLeaderAnnotContextTemplate template)
	{
		MultiLeaderObjectContextData.LeaderRoot leaderRoot = new MultiLeaderObjectContextData.LeaderRoot();
		DxfClassMap map = DxfClassMap.Create(leaderRoot.GetType(), "LeaderRoot");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code != 303)
			{
				if (code != 304 || !_reader.ValueAsString.Equals("LEADER_LINE{"))
				{
					goto IL_00a3;
				}
				CadMLeaderAnnotContextTemplate.LeaderLineTemplate leaderLineTemplate = new CadMLeaderAnnotContextTemplate.LeaderLineTemplate();
				template.LeaderLineTemplates.Add(leaderLineTemplate);
				leaderRoot.Lines.Add(readMultiLeaderLine(leaderLineTemplate));
			}
			else
			{
				if (!_reader.ValueAsString.Equals("}"))
				{
					goto IL_00a3;
				}
				flag = true;
			}
			goto IL_00df;
			IL_00df:
			if (flag)
			{
				break;
			}
			_reader.ReadNext();
			continue;
			IL_00a3:
			if (!tryAssignCurrentValue(leaderRoot, map))
			{
				_builder.Notify($"[LeaderRoot] Unhandled dxf code {_reader.Code} with value {_reader.ValueAsString}");
			}
			goto IL_00df;
		}
		return leaderRoot;
	}

	private MultiLeaderObjectContextData.LeaderLine readMultiLeaderLine(CadMLeaderAnnotContextTemplate.LeaderLineTemplate template)
	{
		MultiLeaderObjectContextData.LeaderLine leaderLine = template.LeaderLine;
		DxfClassMap map = DxfClassMap.Create(leaderLine.GetType(), "LeaderLine");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code <= 20)
			{
				if (code != 10)
				{
					if (code != 20)
					{
						goto IL_0148;
					}
					XYZ value = leaderLine.Points[leaderLine.Points.Count - 1];
					value.Y = _reader.ValueAsDouble;
					leaderLine.Points[leaderLine.Points.Count - 1] = value;
				}
				else
				{
					XYZ value = new XYZ(_reader.ValueAsDouble, 0.0, 0.0);
					leaderLine.Points.Add(value);
				}
			}
			else if (code != 30)
			{
				if (code != 305 || !_reader.ValueAsString.Equals("}"))
				{
					goto IL_0148;
				}
				flag = true;
			}
			else
			{
				XYZ value = leaderLine.Points[leaderLine.Points.Count - 1];
				value.Z = _reader.ValueAsDouble;
				leaderLine.Points[leaderLine.Points.Count - 1] = value;
			}
			goto IL_0184;
			IL_0148:
			if (!tryAssignCurrentValue(leaderLine, map))
			{
				_builder.Notify($"[LeaderLine] Unhandled dxf code {_reader.Code} with value {_reader.ValueAsString}");
			}
			goto IL_0184;
			IL_0184:
			if (flag)
			{
				break;
			}
			_reader.ReadNext();
		}
		return leaderLine;
	}

	private bool readShape(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadShapeTemplate cadShapeTemplate = template as CadShapeTemplate;
		if (_reader.Code == 2)
		{
			cadShapeTemplate.ShapeFileName = _reader.ValueAsString;
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadShapeTemplate.CadObject.SubclassMarker]);
	}

	private bool readWipeoutBase(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadWipeoutBaseTemplate cadWipeoutBaseTemplate = template as CadWipeoutBaseTemplate;
		CadWipeoutBase cadWipeoutBase = cadWipeoutBaseTemplate.CadObject as CadWipeoutBase;
		switch (_reader.Code)
		{
		case 91:
		{
			int valueAsInt = _reader.ValueAsInt;
			for (int i = 0; i < valueAsInt; i++)
			{
				_reader.ReadNext();
				double valueAsDouble = _reader.ValueAsDouble;
				_reader.ReadNext();
				double valueAsDouble2 = _reader.ValueAsDouble;
				cadWipeoutBase.ClipBoundaryVertices.Add(new XY(valueAsDouble, valueAsDouble2));
			}
			_reader.ReadNext();
			return checkEntityEnd(template, map, subclass, readWipeoutBase);
		}
		case 340:
			cadWipeoutBaseTemplate.ImgDefHandle = _reader.ValueAsHandle;
			return true;
		case 360:
			cadWipeoutBaseTemplate.ImgReactorHandle = _reader.ValueAsHandle;
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadWipeoutBaseTemplate.CadObject.SubclassMarker]);
		}
	}

	private bool readOle2Frame(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadOle2FrameTemplate cadOle2FrameTemplate = template as CadOle2FrameTemplate;
		switch (_reader.Code)
		{
		case 1:
		case 73:
		case 90:
			return true;
		case 310:
			cadOle2FrameTemplate.Chunks.Add(_reader.ValueAsBinaryChunk);
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadOle2FrameTemplate.CadObject.SubclassMarker]);
		}
	}

	private bool readModelerGeometry(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		string key = (string.IsNullOrEmpty(subclass) ? template.CadObject.SubclassMarker : subclass);
		ModelerGeometry modelerGeometry = template.CadObject as ModelerGeometry;
		switch (_reader.Code)
		{
		case 1:
		case 3:
			modelerGeometry.ProprietaryData.AppendLine(_reader.ValueAsString);
			return true;
		case 2:
			modelerGeometry.Guid = new Guid(_reader.ValueAsString);
			return true;
		case 290:
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[key]);
		}
	}

	private bool readSolid3d(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadSolid3DTemplate cadSolid3DTemplate = template as CadSolid3DTemplate;
		if (_reader.Code == 350)
		{
			cadSolid3DTemplate.HistoryHandle = _reader.ValueAsHandle;
			return true;
		}
		return readModelerGeometry(template, map, "AcDbModelerGeometry");
	}

	private bool readSpline(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadSplineTemplate cadSplineTemplate = template as CadSplineTemplate;
		switch (_reader.Code)
		{
		case 10:
		{
			XYZ value2 = new XYZ(_reader.ValueAsDouble, 0.0, 0.0);
			cadSplineTemplate.CadObject.ControlPoints.Add(value2);
			return true;
		}
		case 20:
		{
			XYZ value2 = cadSplineTemplate.CadObject.ControlPoints.LastOrDefault();
			value2.Y = _reader.ValueAsDouble;
			cadSplineTemplate.CadObject.ControlPoints[cadSplineTemplate.CadObject.ControlPoints.Count - 1] = value2;
			return true;
		}
		case 30:
		{
			XYZ value2 = cadSplineTemplate.CadObject.ControlPoints.LastOrDefault();
			value2.Z = _reader.ValueAsDouble;
			cadSplineTemplate.CadObject.ControlPoints[cadSplineTemplate.CadObject.ControlPoints.Count - 1] = value2;
			return true;
		}
		case 11:
		{
			XYZ value = new XYZ(_reader.ValueAsDouble, 0.0, 0.0);
			cadSplineTemplate.CadObject.FitPoints.Add(value);
			return true;
		}
		case 21:
		{
			XYZ value = cadSplineTemplate.CadObject.FitPoints.LastOrDefault();
			value.Y = _reader.ValueAsDouble;
			cadSplineTemplate.CadObject.FitPoints[cadSplineTemplate.CadObject.FitPoints.Count - 1] = value;
			return true;
		}
		case 31:
		{
			XYZ value = cadSplineTemplate.CadObject.FitPoints.LastOrDefault();
			value.Z = _reader.ValueAsDouble;
			cadSplineTemplate.CadObject.FitPoints[cadSplineTemplate.CadObject.FitPoints.Count - 1] = value;
			return true;
		}
		case 40:
			cadSplineTemplate.CadObject.Knots.Add(_reader.ValueAsDouble);
			return true;
		case 41:
			cadSplineTemplate.CadObject.Weights.Add(_reader.ValueAsDouble);
			return true;
		case 72:
		case 73:
		case 74:
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadSplineTemplate.CadObject.SubclassMarker]);
		}
	}

	private bool readUnderlayEntity<T>(CadEntityTemplate template, DxfMap map, string subclass = null) where T : PdfUnderlayDefinition
	{
		CadUnderlayTemplate<T> cadUnderlayTemplate = template as CadUnderlayTemplate<T>;
		if (_reader.Code == 340)
		{
			cadUnderlayTemplate.DefinitionHandle = _reader.ValueAsHandle;
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadUnderlayTemplate.CadObject.SubclassMarker]);
	}

	private bool readVertex(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadVertexTemplate cadVertexTemplate = template as CadVertexTemplate;
		if (_reader.Code == 100)
		{
			switch (_reader.ValueAsString)
			{
			case "AcDbVertex":
				return true;
			case "AcDb2dVertex":
				cadVertexTemplate.SetVertexObject(new Vertex2D());
				map.SubClasses.Add("AcDb2dVertex", DxfClassMap.Create<Vertex2D>());
				return true;
			case "AcDb3dPolylineVertex":
				cadVertexTemplate.SetVertexObject(new Vertex3D());
				map.SubClasses.Add("AcDb3dPolylineVertex", DxfClassMap.Create<Vertex3D>());
				return true;
			case "AcDbPolyFaceMeshVertex":
				cadVertexTemplate.SetVertexObject(new VertexFaceMesh());
				map.SubClasses.Add("AcDbPolyFaceMeshVertex", DxfClassMap.Create<VertexFaceMesh>());
				return true;
			case "AcDbFaceRecord":
				cadVertexTemplate.SetVertexObject(new VertexFaceRecord());
				map.SubClasses.Add("AcDbFaceRecord", DxfClassMap.Create<VertexFaceRecord>());
				return true;
			default:
				return false;
			}
		}
		return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadVertexTemplate.CadObject.SubclassMarker]);
	}

	private bool readViewport(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		CadViewportTemplate cadViewportTemplate = template as CadViewportTemplate;
		switch (_reader.Code)
		{
		case 67:
		case 68:
			return true;
		case 69:
			cadViewportTemplate.ViewportId = _reader.ValueAsShort;
			return true;
		case 331:
			cadViewportTemplate.FrozenLayerHandles.Add(_reader.ValueAsHandle);
			return true;
		case 348:
			cadViewportTemplate.VisualStyleHandle = _reader.ValueAsHandle;
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbViewport"]);
		}
	}

	private bool readEntitySubclassMap(CadEntityTemplate template, DxfMap map, string subclass = null)
	{
		string key = (string.IsNullOrEmpty(subclass) ? template.CadObject.SubclassMarker : subclass);
		_ = _reader.Code;
		return tryAssignCurrentValue(template.CadObject, map.SubClasses[key]);
	}

	protected void readExtendedData(Dictionary<string, List<ExtendedDataRecord>> edata)
	{
		List<ExtendedDataRecord> list = new List<ExtendedDataRecord>();
		edata.Add(_reader.ValueAsString, list);
		_reader.ReadNext();
		while (_reader.DxfCode >= DxfCode.ExtendedDataAsciiString)
		{
			if (_reader.DxfCode == DxfCode.ExtendedDataRegAppName)
			{
				readExtendedData(edata);
				break;
			}
			ExtendedDataRecord extendedDataRecord = null;
			double num = 0.0;
			double num2 = 0.0;
			switch (_reader.DxfCode)
			{
			case DxfCode.ExtendedDataAsciiString:
			case DxfCode.ExtendedDataRegAppName:
				extendedDataRecord = new ExtendedDataString(_reader.ValueAsString);
				break;
			case DxfCode.ExtendedDataControlString:
				extendedDataRecord = new ExtendedDataControlString(_reader.ValueAsString == "}");
				break;
			case DxfCode.ExtendedDataLayerName:
			{
				if (_builder.Layers.TryGetValue(_reader.ValueAsString, out var item))
				{
					extendedDataRecord = new ExtendedDataLayer(item.Handle);
				}
				else
				{
					_builder.Notify("[XData] Could not found the linked Layer " + _reader.ValueAsString + ".", NotificationType.Warning);
				}
				break;
			}
			case DxfCode.ExtendedDataBinaryChunk:
				extendedDataRecord = new ExtendedDataBinaryChunk(_reader.ValueAsBinaryChunk);
				break;
			case DxfCode.ExtendedDataHandle:
				extendedDataRecord = new ExtendedDataHandle(_reader.ValueAsHandle);
				break;
			case DxfCode.ExtendedDataXCoordinate:
			{
				double valueAsDouble4 = _reader.ValueAsDouble;
				_reader.ReadNext();
				num = _reader.ValueAsDouble;
				_reader.ReadNext();
				num2 = _reader.ValueAsDouble;
				extendedDataRecord = new ExtendedDataCoordinate(new XYZ(valueAsDouble4, num, num2));
				break;
			}
			case DxfCode.ExtendedDataWorldXCoordinate:
			{
				double valueAsDouble3 = _reader.ValueAsDouble;
				_reader.ReadNext();
				num = _reader.ValueAsDouble;
				_reader.ReadNext();
				num2 = _reader.ValueAsDouble;
				extendedDataRecord = new ExtendedDataWorldCoordinate(new XYZ(valueAsDouble3, num, num2));
				break;
			}
			case DxfCode.ExtendedDataWorldXDisp:
			{
				double valueAsDouble2 = _reader.ValueAsDouble;
				_reader.ReadNext();
				num = _reader.ValueAsDouble;
				_reader.ReadNext();
				num2 = _reader.ValueAsDouble;
				extendedDataRecord = new ExtendedDataDisplacement(new XYZ(valueAsDouble2, num, num2));
				break;
			}
			case DxfCode.ExtendedDataWorldXDir:
			{
				double valueAsDouble = _reader.ValueAsDouble;
				_reader.ReadNext();
				num = _reader.ValueAsDouble;
				_reader.ReadNext();
				num2 = _reader.ValueAsDouble;
				extendedDataRecord = new ExtendedDataDirection(new XYZ(valueAsDouble, num, num2));
				break;
			}
			case DxfCode.ExtendedDataReal:
				extendedDataRecord = new ExtendedDataReal(_reader.ValueAsDouble);
				break;
			case DxfCode.ExtendedDataDist:
				extendedDataRecord = new ExtendedDataDistance(_reader.ValueAsDouble);
				break;
			case DxfCode.ExtendedDataScale:
				extendedDataRecord = new ExtendedDataScale(_reader.ValueAsDouble);
				break;
			case DxfCode.ExtendedDataInteger16:
				extendedDataRecord = new ExtendedDataInteger16(_reader.ValueAsShort);
				break;
			case DxfCode.ExtendedDataInteger32:
				extendedDataRecord = new ExtendedDataInteger32(_reader.ValueAsInt);
				break;
			default:
				_builder.Notify($"Unknown code for extended data: {_reader.DxfCode}", NotificationType.Warning);
				break;
			}
			if (extendedDataRecord != null)
			{
				list.Add(extendedDataRecord);
			}
			_reader.ReadNext();
		}
	}

	private void readPattern(HatchPattern pattern, int nlines)
	{
		_reader.ReadNext();
		for (int i = 0; i < nlines; i++)
		{
			HatchPattern.Line line = new HatchPattern.Line();
			XY basePoint = default(XY);
			XY offset = default(XY);
			bool flag = false;
			HashSet<int> hashSet = new HashSet<int>();
			while (!flag && !hashSet.Contains(_reader.Code))
			{
				hashSet.Add(_reader.Code);
				switch (_reader.Code)
				{
				case 53:
					line.Angle = _reader.ValueAsAngle;
					break;
				case 43:
					basePoint.X = _reader.ValueAsDouble;
					break;
				case 44:
					basePoint.Y = _reader.ValueAsDouble;
					line.BasePoint = basePoint;
					break;
				case 45:
					offset.X = _reader.ValueAsDouble;
					line.Offset = offset;
					break;
				case 46:
					offset.Y = _reader.ValueAsDouble;
					line.Offset = offset;
					break;
				case 79:
				{
					int valueAsInt = _reader.ValueAsInt;
					for (int j = 0; j < valueAsInt; j++)
					{
						_reader.ReadNext();
						line.DashLengths.Add(_reader.ValueAsDouble);
					}
					break;
				}
				case 49:
					line.DashLengths.Add(_reader.ValueAsDouble);
					break;
				default:
					flag = true;
					break;
				}
				_reader.ReadNext();
			}
			pattern.Lines.Add(line);
		}
	}

	private void readLoops(CadHatchTemplate template, int count)
	{
		if (_reader.Code == 91)
		{
			_reader.ReadNext();
		}
		for (int i = 0; i < count; i++)
		{
			if (_reader.Code != 92)
			{
				_builder.Notify($"Boundary path should start with code 92 but was {_reader.Code}");
				break;
			}
			CadHatchTemplate.CadBoundaryPathTemplate cadBoundaryPathTemplate = readLoop();
			if (cadBoundaryPathTemplate != null)
			{
				template.PathTemplates.Add(cadBoundaryPathTemplate);
			}
		}
	}

	private CadHatchTemplate.CadBoundaryPathTemplate readLoop()
	{
		CadHatchTemplate.CadBoundaryPathTemplate cadBoundaryPathTemplate = new CadHatchTemplate.CadBoundaryPathTemplate();
		BoundaryPathFlags valueAsInt = (BoundaryPathFlags)_reader.ValueAsInt;
		cadBoundaryPathTemplate.Path.Flags = valueAsInt;
		if (valueAsInt.HasFlag(BoundaryPathFlags.Polyline))
		{
			Hatch.BoundaryPath.Polyline item = readPolylineBoundary();
			cadBoundaryPathTemplate.Path.Edges.Add(item);
		}
		else
		{
			_reader.ReadNext();
			if (_reader.Code != 93)
			{
				_builder.Notify($"Edge Boundary path should start with code 93 but was {_reader.Code}");
				return null;
			}
			int valueAsInt2 = _reader.ValueAsInt;
			_reader.ReadNext();
			for (int i = 0; i < valueAsInt2; i++)
			{
				Hatch.BoundaryPath.Edge edge = readEdge();
				if (edge != null)
				{
					cadBoundaryPathTemplate.Path.Edges.Add(edge);
				}
			}
		}
		bool flag = false;
		while (!flag)
		{
			switch (_reader.Code)
			{
			case 330:
				cadBoundaryPathTemplate.Handles.Add(_reader.ValueAsHandle);
				break;
			default:
				flag = true;
				continue;
			case 97:
				break;
			}
			_reader.ReadNext();
		}
		return cadBoundaryPathTemplate;
	}

	private Hatch.BoundaryPath.Polyline readPolylineBoundary()
	{
		Hatch.BoundaryPath.Polyline polyline = new Hatch.BoundaryPath.Polyline();
		_reader.ReadNext();
		if (_reader.Code != 72)
		{
			_builder.Notify($"Polyline Boundary path should start with code 72 but was {_reader.Code}");
			return null;
		}
		bool valueAsBool = _reader.ValueAsBool;
		_reader.ReadNext();
		_ = _reader.ValueAsBool;
		_reader.ReadNext();
		int valueAsInt = _reader.ValueAsInt;
		_reader.ReadNext();
		for (int i = 0; i < valueAsInt; i++)
		{
			double z = 0.0;
			double valueAsDouble = _reader.ValueAsDouble;
			_reader.ReadNext();
			double valueAsDouble2 = _reader.ValueAsDouble;
			_reader.ReadNext();
			if (valueAsBool)
			{
				z = _reader.ValueAsDouble;
				_reader.ReadNext();
			}
			polyline.Vertices.Add(new XYZ(valueAsDouble, valueAsDouble2, z));
		}
		return polyline;
	}

	private Hatch.BoundaryPath.Edge readEdge()
	{
		if (_reader.Code != 72)
		{
			_builder.Notify($"Edge Boundary path should define the type with code 72 but was {_reader.Code}");
			return null;
		}
		Hatch.BoundaryPath.EdgeType valueAsInt = (Hatch.BoundaryPath.EdgeType)_reader.ValueAsInt;
		_reader.ReadNext();
		switch (valueAsInt)
		{
		case Hatch.BoundaryPath.EdgeType.Line:
		{
			Hatch.BoundaryPath.Line line = new Hatch.BoundaryPath.Line();
			while (true)
			{
				switch (_reader.Code)
				{
				case 10:
					line.Start = new XY(_reader.ValueAsDouble, line.Start.Y);
					break;
				case 20:
					line.Start = new XY(line.Start.X, _reader.ValueAsDouble);
					break;
				case 11:
					line.End = new XY(_reader.ValueAsDouble, line.End.Y);
					break;
				case 21:
					line.End = new XY(line.End.X, _reader.ValueAsDouble);
					break;
				default:
					return line;
				}
				_reader.ReadNext();
			}
		}
		case Hatch.BoundaryPath.EdgeType.CircularArc:
		{
			Hatch.BoundaryPath.Arc arc = new Hatch.BoundaryPath.Arc();
			while (true)
			{
				switch (_reader.Code)
				{
				case 10:
					arc.Center = new XY(_reader.ValueAsDouble, arc.Center.Y);
					break;
				case 20:
					arc.Center = new XY(arc.Center.X, _reader.ValueAsDouble);
					break;
				case 40:
					arc.Radius = _reader.ValueAsDouble;
					break;
				case 50:
					arc.StartAngle = _reader.ValueAsDouble;
					break;
				case 51:
					arc.EndAngle = _reader.ValueAsDouble;
					break;
				case 73:
					arc.CounterClockWise = _reader.ValueAsBool;
					break;
				default:
					return arc;
				}
				_reader.ReadNext();
			}
		}
		case Hatch.BoundaryPath.EdgeType.EllipticArc:
		{
			Hatch.BoundaryPath.Ellipse ellipse = new Hatch.BoundaryPath.Ellipse();
			while (true)
			{
				switch (_reader.Code)
				{
				case 10:
					ellipse.Center = new XY(_reader.ValueAsDouble, ellipse.Center.Y);
					break;
				case 20:
					ellipse.Center = new XY(ellipse.Center.X, _reader.ValueAsDouble);
					break;
				case 11:
					ellipse.MajorAxisEndPoint = new XY(_reader.ValueAsDouble, ellipse.Center.Y);
					break;
				case 21:
					ellipse.MajorAxisEndPoint = new XY(ellipse.Center.X, _reader.ValueAsDouble);
					break;
				case 40:
					ellipse.MinorToMajorRatio = _reader.ValueAsDouble;
					break;
				case 50:
					ellipse.StartAngle = _reader.ValueAsDouble;
					break;
				case 51:
					ellipse.EndAngle = _reader.ValueAsDouble;
					break;
				case 73:
					ellipse.CounterClockWise = _reader.ValueAsBool;
					break;
				default:
					return ellipse;
				}
				_reader.ReadNext();
			}
		}
		case Hatch.BoundaryPath.EdgeType.Spline:
		{
			Hatch.BoundaryPath.Spline spline = new Hatch.BoundaryPath.Spline();
			XYZ item = default(XYZ);
			XY item2 = default(XY);
			while (true)
			{
				switch (_reader.Code)
				{
				case 10:
					item = new XYZ(_reader.ValueAsDouble, 0.0, 1.0);
					break;
				case 20:
					item = new XYZ(item.X, _reader.ValueAsDouble, item.Z);
					spline.ControlPoints.Add(item);
					break;
				case 11:
					item2 = new XY(_reader.ValueAsDouble, 0.0);
					break;
				case 21:
					item2 = new XY(item2.X, _reader.ValueAsDouble);
					spline.FitPoints.Add(item2);
					break;
				case 42:
				{
					XYZ xYZ = spline.ControlPoints[spline.ControlPoints.Count - 1];
					spline.ControlPoints[spline.ControlPoints.Count - 1] = new XYZ(xYZ.X, xYZ.Y, _reader.ValueAsDouble);
					break;
				}
				case 12:
					spline.StartTangent = new XY(_reader.ValueAsDouble, spline.StartTangent.Y);
					break;
				case 22:
					spline.StartTangent = new XY(spline.StartTangent.X, _reader.ValueAsDouble);
					break;
				case 13:
					spline.EndTangent = new XY(_reader.ValueAsDouble, spline.EndTangent.Y);
					break;
				case 23:
					spline.EndTangent = new XY(spline.EndTangent.X, _reader.ValueAsDouble);
					break;
				case 94:
					spline.Degree = _reader.ValueAsInt;
					break;
				case 73:
					spline.Rational = _reader.ValueAsBool;
					break;
				case 74:
					spline.Periodic = _reader.ValueAsBool;
					break;
				case 95:
					_ = _reader.ValueAsInt;
					break;
				case 96:
					_ = _reader.ValueAsInt;
					break;
				case 97:
					_ = _reader.ValueAsInt;
					break;
				case 40:
					spline.Knots.Add(_reader.ValueAsDouble);
					break;
				default:
					return spline;
				}
				_reader.ReadNext();
			}
		}
		default:
			return null;
		}
	}

	private void readDefinedGroups(CadTemplate template)
	{
		readDefinedGroups(out var xdictHandle, out var reactors);
		template.XDictHandle = xdictHandle;
		template.ReactorsHandles.UnionWith(reactors);
	}

	private void readDefinedGroups(out ulong? xdictHandle, out HashSet<ulong> reactors)
	{
		xdictHandle = null;
		reactors = new HashSet<ulong>();
		switch (_reader.ValueAsString)
		{
		case "{ACAD_XDICTIONARY":
			_reader.ReadNext();
			xdictHandle = _reader.ValueAsHandle;
			_reader.ReadNext();
			return;
		case "{ACAD_REACTORS":
			reactors = readReactors();
			return;
		}
		do
		{
			_reader.ReadNext();
		}
		while (_reader.DxfCode != DxfCode.ControlString);
	}

	private HashSet<ulong> readReactors()
	{
		HashSet<ulong> hashSet = new HashSet<ulong>();
		_reader.ReadNext();
		while (_reader.DxfCode != DxfCode.ControlString)
		{
			hashSet.Add(_reader.ValueAsHandle);
			_reader.ReadNext();
		}
		return hashSet;
	}

	protected bool tryAssignCurrentValue(object cadObject, DxfClassMap map)
	{
		try
		{
			if (map.DxfProperties.TryGetValue(_reader.Code, out var value))
			{
				if (value.ReferenceType.HasFlag(DxfReferenceType.Count))
				{
					return true;
				}
				if (value.ReferenceType.HasFlag(DxfReferenceType.Handle) || value.ReferenceType.HasFlag(DxfReferenceType.Name))
				{
					return false;
				}
				object obj = _reader.Value;
				if (value.ReferenceType.HasFlag(DxfReferenceType.IsAngle))
				{
					obj = MathHelper.DegToRad((double)obj);
				}
				value.SetValue(_reader.Code, cadObject, obj);
				return true;
			}
		}
		catch (Exception ex)
		{
			if (!_builder.Configuration.Failsafe)
			{
				throw ex;
			}
			_builder.Notify("An error occurred while assigning a property using mapper", NotificationType.Error, ex);
		}
		return false;
	}
}
