using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ACadSharp.Entities;
using ACadSharp.IO.Templates;
using ACadSharp.Objects;
using ACadSharp.Objects.Evaluations;
using CSMath;

namespace ACadSharp.IO.DXF;

internal class DxfObjectsSectionReader : DxfSectionReaderBase
{
	public delegate bool ReadObjectDelegate<T>(CadTemplate template, DxfMap map) where T : CadObject;

	public DxfObjectsSectionReader(IDxfStreamReader reader, DxfDocumentBuilder builder)
		: base(reader, builder)
	{
	}

	public override void Read()
	{
		_reader.ReadNext();
		while (_reader.ValueAsString != "ENDSEC")
		{
			CadTemplate cadTemplate = null;
			try
			{
				cadTemplate = readObject();
			}
			catch (Exception exception)
			{
				if (!_builder.Configuration.Failsafe)
				{
					throw;
				}
				_builder.Notify($"Error while reading an object at line {_reader.Position}", NotificationType.Error, exception);
				while (_reader.DxfCode != DxfCode.Start)
				{
					_reader.ReadNext();
				}
			}
			if (cadTemplate != null)
			{
				_builder.AddTemplate(cadTemplate);
			}
		}
	}

	private CadTemplate readObject()
	{
		switch (_reader.ValueAsString)
		{
		case "ACDBPLACEHOLDER":
			return readObjectCodes<AcdbPlaceHolder>(new CadNonGraphicalObjectTemplate(new AcdbPlaceHolder()), readObjectSubclassMap);
		case "DBCOLOR":
			return readObjectCodes<BookColor>(new CadNonGraphicalObjectTemplate(new BookColor()), readBookColor);
		case "DICTIONARY":
			return readObjectCodes<CadDictionary>(new CadDictionaryTemplate(), readDictionary);
		case "ACDBDICTIONARYWDFLT":
			return readObjectCodes<CadDictionaryWithDefault>(new CadDictionaryWithDefaultTemplate(), readDictionaryWithDefault);
		case "LAYOUT":
			return readObjectCodes<Layout>(new CadLayoutTemplate(), readLayout);
		case "PLOTSETTINGS":
			return readObjectCodes<PlotSettings>(new CadNonGraphicalObjectTemplate(new PlotSettings()), readPlotSettings);
		case "ACAD_EVALUATION_GRAPH":
			return readObjectCodes<EvaluationGraph>(new CadEvaluationGraphTemplate(), readEvaluationGraph);
		case "IMAGEDEF":
			return readObjectCodes<ImageDefinition>(new CadNonGraphicalObjectTemplate(new ImageDefinition()), readObjectSubclassMap);
		case "DICTIONARYVAR":
			return readObjectCodes<DictionaryVariable>(new CadTemplate<DictionaryVariable>(new DictionaryVariable()), readObjectSubclassMap);
		case "PDFDEFINITION":
			return readObjectCodes<PdfUnderlayDefinition>(new CadNonGraphicalObjectTemplate(new PdfUnderlayDefinition()), readObjectSubclassMap);
		case "SORTENTSTABLE":
			return readSortentsTable();
		case "IMAGEDEF_REACTOR":
			return readObjectCodes<ImageDefinitionReactor>(new CadNonGraphicalObjectTemplate(new ImageDefinitionReactor()), readObjectSubclassMap);
		case "ACAD_PROXY_OBJECT":
			return readObjectCodes<ProxyObject>(new CadNonGraphicalObjectTemplate(new ProxyObject()), readProxyObject);
		case "RASTERVARIABLES":
			return readObjectCodes<RasterVariables>(new CadNonGraphicalObjectTemplate(new RasterVariables()), readObjectSubclassMap);
		case "GROUP":
			return readObjectCodes<Group>(new CadGroupTemplate(), readGroup);
		case "GEODATA":
			return readObjectCodes<GeoData>(new CadGeoDataTemplate(), readGeoData);
		case "MATERIAL":
			return readObjectCodes<Material>(new CadMaterialTemplate(), readMaterial);
		case "SCALE":
			return readObjectCodes<Scale>(new CadTemplate<Scale>(new Scale()), readScale);
		case "TABLECONTENT":
			return readObjectCodes<TableContent>(new CadTableContentTemplate(), readTableContent);
		case "VISUALSTYLE":
			return readObjectCodes<VisualStyle>(new CadTemplate<VisualStyle>(new VisualStyle()), readVisualStyle);
		case "SPATIAL_FILTER":
			return readObjectCodes<SpatialFilter>(new CadSpatialFilterTemplate(), readSpatialFilter);
		case "MLINESTYLE":
			return readObjectCodes<MLineStyle>(new CadMLineStyleTemplate(), readMLineStyle);
		case "MLEADERSTYLE":
			return readObjectCodes<MultiLeaderStyle>(new CadMLeaderStyleTemplate(), readMLeaderStyle);
		case "XRECORD":
			return readObjectCodes<XRecord>(new CadXRecordTemplate(), readXRecord);
		default:
		{
			DxfMap map = DxfMap.Create<CadObject>();
			CadUnknownNonGraphicalObjectTemplate cadUnknownNonGraphicalObjectTemplate = null;
			if (_builder.DocumentToBuild.Classes.TryGetByName(_reader.ValueAsString, out var result))
			{
				_builder.Notify("NonGraphicalObject not supported read as an UnknownNonGraphicalObject: " + _reader.ValueAsString, NotificationType.NotImplemented);
				cadUnknownNonGraphicalObjectTemplate = new CadUnknownNonGraphicalObjectTemplate(new UnknownNonGraphicalObject(result));
			}
			else
			{
				_builder.Notify("UnknownNonGraphicalObject not supported: " + _reader.ValueAsString, NotificationType.NotImplemented);
			}
			_reader.ReadNext();
			do
			{
				if (cadUnknownNonGraphicalObjectTemplate != null && _builder.KeepUnknownEntities)
				{
					readCommonCodes(cadUnknownNonGraphicalObjectTemplate, out var isExtendedData, map);
					if (isExtendedData)
					{
						continue;
					}
				}
				_reader.ReadNext();
			}
			while (_reader.DxfCode != DxfCode.Start);
			return cadUnknownNonGraphicalObjectTemplate;
		}
		}
	}

	protected CadTemplate readObjectCodes<T>(CadTemplate template, ReadObjectDelegate<T> readObject) where T : CadObject
	{
		_reader.ReadNext();
		DxfMap map = DxfMap.Create<T>();
		while (_reader.DxfCode != DxfCode.Start)
		{
			if (!readObject(template, map))
			{
				readCommonCodes(template, out var isExtendedData, map);
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

	private bool readProxyObject(CadTemplate template, DxfMap map)
	{
		ProxyObject proxyObject = template.CadObject as ProxyObject;
		switch (_reader.Code)
		{
		case 71:
		case 90:
		case 94:
		case 97:
			return true;
		case 95:
		{
			int valueAsInt = _reader.ValueAsInt;
			proxyObject.Version = (ACadVersion)(valueAsInt & 0xFFFF);
			proxyObject.MaintenanceVersion = (short)(valueAsInt >> 16);
			return true;
		}
		case 91:
		{
			short valueAsShort = _reader.ValueAsShort;
			if (_builder.DocumentToBuild.Classes.TryGetByClassNumber(valueAsShort, out var result))
			{
				proxyObject.DxfClass = result;
			}
			return true;
		}
		case 161:
			return true;
		case 162:
			return true;
		case 310:
			if (proxyObject.BinaryData == null)
			{
				proxyObject.BinaryData = new MemoryStream();
			}
			proxyObject.BinaryData.Write(_reader.ValueAsBinaryChunk, 0, _reader.ValueAsBinaryChunk.Length);
			return true;
		case 311:
			if (proxyObject.Data == null)
			{
				proxyObject.Data = new MemoryStream();
			}
			proxyObject.Data.Write(_reader.ValueAsBinaryChunk, 0, _reader.ValueAsBinaryChunk.Length);
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbProxyObject"]);
		}
	}

	private bool readObjectSubclassMap(CadTemplate template, DxfMap map)
	{
		_ = _reader.Code;
		return tryAssignCurrentValue(template.CadObject, map.SubClasses[template.CadObject.SubclassMarker]);
	}

	private bool readPlotSettings(CadTemplate template, DxfMap map)
	{
		_ = _reader.Code;
		return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbPlotSettings"]);
	}

	private bool readEvaluationGraph(CadTemplate template, DxfMap map)
	{
		CadEvaluationGraphTemplate cadEvaluationGraphTemplate = template as CadEvaluationGraphTemplate;
		_ = cadEvaluationGraphTemplate.CadObject;
		int code = _reader.Code;
		if (code != 91)
		{
			if (code == 92)
			{
				while (_reader.Code == 92)
				{
					_reader.ExpectedCode(93);
					_reader.ExpectedCode(94);
					_reader.ExpectedCode(91);
					_reader.ExpectedCode(91);
					_reader.ExpectedCode(92);
					_reader.ExpectedCode(92);
					_reader.ExpectedCode(92);
					_reader.ExpectedCode(92);
					_reader.ExpectedCode(92);
					_reader.ReadNext();
				}
				return checkObjectEnd(template, map, readEvaluationGraph);
			}
			return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbEvalGraph"]);
		}
		while (_reader.Code == 91)
		{
			CadEvaluationGraphTemplate.GraphNodeTemplate graphNodeTemplate = new CadEvaluationGraphTemplate.GraphNodeTemplate();
			EvaluationGraph.Node node = graphNodeTemplate.Node;
			node.Index = _reader.ValueAsInt;
			_reader.ExpectedCode(93);
			node.Flags = _reader.ValueAsInt;
			_reader.ExpectedCode(95);
			node.NextNodeIndex = _reader.ValueAsInt;
			_reader.ExpectedCode(360);
			graphNodeTemplate.ExpressionHandle = _reader.ValueAsHandle;
			_reader.ExpectedCode(92);
			node.Data1 = _reader.ValueAsInt;
			_reader.ExpectedCode(92);
			node.Data2 = _reader.ValueAsInt;
			_reader.ExpectedCode(92);
			node.Data3 = _reader.ValueAsInt;
			_reader.ExpectedCode(92);
			node.Data4 = _reader.ValueAsInt;
			_reader.ReadNext();
			cadEvaluationGraphTemplate.NodeTemplates.Add(graphNodeTemplate);
		}
		return checkObjectEnd(template, map, readEvaluationGraph);
	}

	private bool readLayout(CadTemplate template, DxfMap map)
	{
		CadLayoutTemplate cadLayoutTemplate = template as CadLayoutTemplate;
		switch (_reader.Code)
		{
		case 330:
			cadLayoutTemplate.PaperSpaceBlockHandle = _reader.ValueAsHandle;
			return true;
		case 331:
			cadLayoutTemplate.LasActiveViewportHandle = _reader.ValueAsHandle;
			return true;
		default:
			if (!tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbLayout"]))
			{
				return readPlotSettings(template, map);
			}
			return true;
		}
	}

	private bool readGroup(CadTemplate template, DxfMap map)
	{
		CadGroupTemplate cadGroupTemplate = template as CadGroupTemplate;
		switch (_reader.Code)
		{
		case 70:
			return true;
		case 340:
			cadGroupTemplate.Handles.Add(_reader.ValueAsHandle);
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[template.CadObject.SubclassMarker]);
		}
	}

	private bool readGeoData(CadTemplate template, DxfMap map)
	{
		CadGeoDataTemplate cadGeoDataTemplate = template as CadGeoDataTemplate;
		switch (_reader.Code)
		{
		case 40:
			if (cadGeoDataTemplate.CadObject.Version == GeoDataVersion.R2009)
			{
				cadGeoDataTemplate.CadObject.ReferencePoint = new XYZ(cadGeoDataTemplate.CadObject.ReferencePoint.X, _reader.ValueAsDouble, cadGeoDataTemplate.CadObject.ReferencePoint.Z);
				return true;
			}
			break;
		case 41:
			if (cadGeoDataTemplate.CadObject.Version == GeoDataVersion.R2009)
			{
				cadGeoDataTemplate.CadObject.ReferencePoint = new XYZ(_reader.ValueAsDouble, cadGeoDataTemplate.CadObject.ReferencePoint.Y, cadGeoDataTemplate.CadObject.ReferencePoint.Z);
				return true;
			}
			break;
		case 42:
			if (cadGeoDataTemplate.CadObject.Version == GeoDataVersion.R2009)
			{
				cadGeoDataTemplate.CadObject.ReferencePoint = new XYZ(cadGeoDataTemplate.CadObject.ReferencePoint.X, cadGeoDataTemplate.CadObject.ReferencePoint.Y, _reader.ValueAsDouble);
				return true;
			}
			break;
		case 46:
			if (cadGeoDataTemplate.CadObject.Version == GeoDataVersion.R2009)
			{
				cadGeoDataTemplate.CadObject.HorizontalUnitScale = _reader.ValueAsDouble;
				return true;
			}
			break;
		case 52:
			if (cadGeoDataTemplate.CadObject.Version == GeoDataVersion.R2009)
			{
				double num = Math.PI / 2.0 - _reader.ValueAsAngle;
				cadGeoDataTemplate.CadObject.NorthDirection = new XY(Math.Cos(num), Math.Sin(num));
				return true;
			}
			break;
		case 93:
		{
			int valueAsInt5 = _reader.ValueAsInt;
			for (int j = 0; j < valueAsInt5; j++)
			{
				_reader.ReadNext();
				double valueAsDouble = _reader.ValueAsDouble;
				_reader.ReadNext();
				double valueAsDouble2 = _reader.ValueAsDouble;
				_reader.ReadNext();
				double valueAsDouble3 = _reader.ValueAsDouble;
				_reader.ReadNext();
				double valueAsDouble4 = _reader.ValueAsDouble;
				cadGeoDataTemplate.CadObject.Points.Add(new GeoData.GeoMeshPoint
				{
					Source = new XY(valueAsDouble, valueAsDouble2),
					Destination = new XY(valueAsDouble3, valueAsDouble4)
				});
			}
			return true;
		}
		case 96:
		{
			int valueAsInt = _reader.ValueAsInt;
			for (int i = 0; i < valueAsInt; i++)
			{
				_reader.ReadNext();
				int valueAsInt2 = _reader.ValueAsInt;
				_reader.ReadNext();
				int valueAsInt3 = _reader.ValueAsInt;
				_reader.ReadNext();
				int valueAsInt4 = _reader.ValueAsInt;
				cadGeoDataTemplate.CadObject.Faces.Add(new GeoData.GeoMeshFace
				{
					Index1 = valueAsInt2,
					Index2 = valueAsInt3,
					Index3 = valueAsInt4
				});
			}
			return true;
		}
		case 303:
			cadGeoDataTemplate.CadObject.CoordinateSystemDefinition += _reader.ValueAsString;
			return true;
		case 3:
		case 4:
		case 14:
		case 15:
		case 16:
		case 17:
		case 24:
		case 25:
		case 26:
		case 27:
		case 43:
		case 44:
		case 45:
		case 54:
		case 94:
		case 140:
		case 292:
		case 293:
		case 304:
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadGeoDataTemplate.CadObject.SubclassMarker]);
	}

	private bool readMaterial(CadTemplate template, DxfMap map)
	{
		CadMaterialTemplate cadMaterialTemplate = template as CadMaterialTemplate;
		List<double> list = null;
		switch (_reader.Code)
		{
		case 43:
		{
			list = new List<double>();
			for (int m = 0; m < 16; m++)
			{
				list.Add(_reader.ValueAsDouble);
				_reader.ReadNext();
			}
			cadMaterialTemplate.CadObject.DiffuseMatrix = new Matrix4(list.ToArray());
			return checkObjectEnd(template, map, readMaterial);
		}
		case 47:
		{
			list = new List<double>();
			for (int k = 0; k < 16; k++)
			{
				list.Add(_reader.ValueAsDouble);
				_reader.ReadNext();
			}
			cadMaterialTemplate.CadObject.SpecularMatrix = new Matrix4(list.ToArray());
			return checkObjectEnd(template, map, readMaterial);
		}
		case 49:
		{
			list = new List<double>();
			for (int n = 0; n < 16; n++)
			{
				list.Add(_reader.ValueAsDouble);
				_reader.ReadNext();
			}
			cadMaterialTemplate.CadObject.ReflectionMatrix = new Matrix4(list.ToArray());
			return checkObjectEnd(template, map, readMaterial);
		}
		case 142:
		{
			list = new List<double>();
			for (int j = 0; j < 16; j++)
			{
				list.Add(_reader.ValueAsDouble);
				_reader.ReadNext();
			}
			cadMaterialTemplate.CadObject.OpacityMatrix = new Matrix4(list.ToArray());
			return checkObjectEnd(template, map, readMaterial);
		}
		case 144:
		{
			list = new List<double>();
			for (int l = 0; l < 16; l++)
			{
				list.Add(_reader.ValueAsDouble);
				_reader.ReadNext();
			}
			cadMaterialTemplate.CadObject.BumpMatrix = new Matrix4(list.ToArray());
			return checkObjectEnd(template, map, readMaterial);
		}
		case 147:
		{
			list = new List<double>();
			for (int i = 0; i < 16; i++)
			{
				list.Add(_reader.ValueAsDouble);
				_reader.ReadNext();
			}
			cadMaterialTemplate.CadObject.RefractionMatrix = new Matrix4(list.ToArray());
			return checkObjectEnd(template, map, readMaterial);
		}
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadMaterialTemplate.CadObject.SubclassMarker]);
		}
	}

	private bool readScale(CadTemplate template, DxfMap map)
	{
		if (_reader.Code == 70)
		{
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbScale"]);
	}

	private void readLinkedData(CadTemplate template, DxfMap map)
	{
		LinkedData cadObject = (template as CadTableContentTemplate).CadObject;
		_reader.ReadNext();
		while (_reader.DxfCode != DxfCode.Start && _reader.DxfCode != DxfCode.Subclass)
		{
			_ = _reader.Code;
			if (!tryAssignCurrentValue(cadObject, map.SubClasses["AcDbLinkedData"]))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} {3}.", _reader.Code, _reader.ValueAsString, "readLinkedData", _reader.Position));
			}
			_reader.ReadNext();
		}
	}

	private bool readTableContent(CadTemplate template, DxfMap map)
	{
		if (_reader.Code == 100)
		{
			if (_reader.ValueAsString.Equals("AcDbTableContent", StringComparison.InvariantCultureIgnoreCase))
			{
				readTableContentSubclass(template, map);
				lockPointer = true;
				return true;
			}
			if (_reader.ValueAsString.Equals("AcDbFormattedTableData", StringComparison.InvariantCultureIgnoreCase))
			{
				readFormattedTableDataSubclass(template, map);
				lockPointer = true;
				return true;
			}
			if (_reader.ValueAsString.Equals("AcDbLinkedTableData", StringComparison.InvariantCultureIgnoreCase))
			{
				readLinkedTableDataSubclass(template, map);
				lockPointer = true;
				return true;
			}
			if (_reader.ValueAsString.Equals("AcDbLinkedData", StringComparison.InvariantCultureIgnoreCase))
			{
				readLinkedData(template, map);
				lockPointer = true;
				return true;
			}
		}
		return false;
	}

	private void readTableContentSubclass(CadTemplate template, DxfMap map)
	{
		CadTableContentTemplate cadTableContentTemplate = template as CadTableContentTemplate;
		TableContent cadObject = cadTableContentTemplate.CadObject;
		_reader.ReadNext();
		while (_reader.DxfCode != DxfCode.Start && _reader.DxfCode != DxfCode.Subclass)
		{
			if (_reader.Code == 340)
			{
				cadTableContentTemplate.SytleHandle = _reader.ValueAsHandle;
			}
			else if (!tryAssignCurrentValue(cadObject, map.SubClasses["AcDbTableContent"]))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} {3}.", _reader.Code, _reader.ValueAsString, "readTableContentSubclass", _reader.Position));
			}
			_reader.ReadNext();
		}
	}

	private void readFormattedTableDataSubclass(CadTemplate template, DxfMap map)
	{
		FormattedTableData cadObject = (template as CadTableContentTemplate).CadObject;
		_reader.ReadNext();
		TableEntity.CellRange cellRange = null;
		for (; _reader.DxfCode != DxfCode.Start && _reader.DxfCode != DxfCode.Subclass; _reader.ReadNext())
		{
			switch (_reader.Code)
			{
			case 91:
				if (cellRange == null)
				{
					cellRange = new TableEntity.CellRange();
					cadObject.MergedCellRanges.Add(cellRange);
				}
				cellRange.TopRowIndex = _reader.ValueAsInt;
				continue;
			case 92:
				if (cellRange == null)
				{
					cellRange = new TableEntity.CellRange();
					cadObject.MergedCellRanges.Add(cellRange);
				}
				cellRange.LeftColumnIndex = _reader.ValueAsInt;
				continue;
			case 93:
				if (cellRange == null)
				{
					cellRange = new TableEntity.CellRange();
					cadObject.MergedCellRanges.Add(cellRange);
				}
				cellRange.BottomRowIndex = _reader.ValueAsInt;
				continue;
			case 94:
				if (cellRange == null)
				{
					cellRange = new TableEntity.CellRange();
					cadObject.MergedCellRanges.Add(cellRange);
				}
				cellRange.RightColumnIndex = _reader.ValueAsInt;
				cellRange = null;
				continue;
			case 300:
				if (_reader.ValueAsString.Equals("TABLEFORMAT", StringComparison.InvariantCultureIgnoreCase))
				{
					readStyleOverride(new CadTableEntityTemplate.CadCellStyleTemplate(cadObject.CellStyleOverride));
					continue;
				}
				break;
			case 90:
				continue;
			}
			if (!tryAssignCurrentValue(cadObject, map.SubClasses["AcDbFormattedTableData"]))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} {3}.", _reader.Code, _reader.ValueAsString, "readFormattedTableDataSubclass", _reader.Position));
			}
		}
	}

	private void readLinkedTableDataSubclass(CadTemplate template, DxfMap map)
	{
		TableContent cadObject = (template as CadTableContentTemplate).CadObject;
		_reader.ReadNext();
		for (; _reader.DxfCode != DxfCode.Start && _reader.DxfCode != DxfCode.Subclass; _reader.ReadNext())
		{
			switch (_reader.Code)
			{
			case 300:
				if (_reader.ValueAsString.Equals("COLUMN", StringComparison.InvariantCultureIgnoreCase))
				{
					readTableColumn();
					continue;
				}
				break;
			case 301:
				if (_reader.ValueAsString.Equals("ROW", StringComparison.InvariantCultureIgnoreCase))
				{
					readTableRow();
					continue;
				}
				break;
			case 90:
			case 91:
			case 92:
				continue;
			}
			if (!tryAssignCurrentValue(cadObject, map.SubClasses["AcDbLinkedTableData"]))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} {3}.", _reader.Code, _reader.ValueAsString, "readLinkedTableDataSubclass", _reader.Position));
			}
		}
	}

	private TableEntity.Column readTableColumn()
	{
		_reader.ReadNext();
		TableEntity.Column column = new TableEntity.Column();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			if (_reader.Code != 1)
			{
				goto IL_008b;
			}
			if (_reader.ValueAsString.Equals("LINKEDTABLEDATACOLUMN_BEGIN", StringComparison.InvariantCultureIgnoreCase))
			{
				readLinkedTableColumn(column);
			}
			else if (_reader.ValueAsString.Equals("FORMATTEDTABLEDATACOLUMN_BEGIN", StringComparison.InvariantCultureIgnoreCase))
			{
				readFormattedTableColumn(column);
			}
			else
			{
				if (!_reader.ValueAsString.Equals("TABLECOLUMN_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_008b;
				}
				readTableColumn(column);
				flag = true;
			}
			goto IL_00c2;
			IL_00c2:
			if (flag)
			{
				return column;
			}
			_reader.ReadNext();
			continue;
			IL_008b:
			_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readTableColumn"));
			goto IL_00c2;
		}
		return column;
	}

	private TableEntity.Row readTableRow()
	{
		_reader.ReadNext();
		TableEntity.Row row = new TableEntity.Row();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			if (_reader.Code != 1)
			{
				goto IL_008b;
			}
			if (_reader.ValueAsString.Equals("LINKEDTABLEDATAROW_BEGIN", StringComparison.InvariantCultureIgnoreCase))
			{
				readLinkedTableRow(row);
			}
			else if (_reader.ValueAsString.Equals("FORMATTEDTABLEDATAROW_BEGIN", StringComparison.InvariantCultureIgnoreCase))
			{
				readFormattedTableRow(row);
			}
			else
			{
				if (!_reader.ValueAsString.Equals("TABLEROW_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_008b;
				}
				readTableRow(row);
				flag = true;
			}
			goto IL_00c2;
			IL_00c2:
			if (flag)
			{
				return row;
			}
			_reader.ReadNext();
			continue;
			IL_008b:
			_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readTableRow"));
			goto IL_00c2;
		}
		return row;
	}

	private void readTableRow(TableEntity.Row row)
	{
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			switch (_reader.Code)
			{
			case 40:
				row.Height = _reader.ValueAsDouble;
				break;
			case 309:
				flag = _reader.ValueAsString.Equals("TABLEROW_END", StringComparison.InvariantCultureIgnoreCase);
				break;
			default:
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readTableRow"));
				break;
			case 90:
				break;
			}
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private void readFormattedTableRow(TableEntity.Row row)
	{
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code != 1)
			{
				if (code != 300)
				{
					if (code != 309)
					{
						goto IL_0092;
					}
					flag = _reader.ValueAsString.Equals("FORMATTEDTABLEDATAROW_END", StringComparison.InvariantCultureIgnoreCase);
				}
				else if (!_reader.ValueAsString.Equals("ROWTABLEFORMAT", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_0092;
				}
			}
			else
			{
				if (!_reader.ValueAsString.Equals("TABLEFORMAT_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_0092;
				}
				readStyleOverride(new CadTableEntityTemplate.CadCellStyleTemplate(row.CellStyleOverride));
			}
			goto IL_00c9;
			IL_00c9:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
			IL_0092:
			_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readFormattedTableRow"));
			goto IL_00c9;
		}
	}

	private void readTableColumn(TableEntity.Column column)
	{
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			switch (_reader.Code)
			{
			case 1:
				if (!_reader.ValueAsString.Equals("TABLECOLUMN_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					flag = true;
				}
				break;
			case 40:
				column.Width = _reader.ValueAsDouble;
				break;
			case 309:
				flag = _reader.ValueAsString.Equals("TABLECOLUMN_END", StringComparison.InvariantCultureIgnoreCase);
				break;
			default:
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readTableColumn"));
				break;
			case 90:
				break;
			}
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private void readLinkedTableColumn(TableEntity.Column column)
	{
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code <= 91)
			{
				if (code != 1)
				{
					if (code != 91)
					{
						goto IL_00d2;
					}
					column.CustomData = _reader.ValueAsInt;
				}
				else if (!_reader.ValueAsString.Equals("LINKEDTABLEDATACOLUMN_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					flag = true;
				}
			}
			else if (code != 300)
			{
				if (code != 301)
				{
					if (code != 309)
					{
						goto IL_00d2;
					}
					flag = _reader.ValueAsString.Equals("LINKEDTABLEDATACOLUMN_END", StringComparison.InvariantCultureIgnoreCase);
				}
				else
				{
					if (!_reader.ValueAsString.Equals("CUSTOMDATA", StringComparison.InvariantCultureIgnoreCase))
					{
						goto IL_00d2;
					}
					readCustomData();
				}
			}
			else
			{
				column.Name = _reader.ValueAsString;
			}
			goto IL_0109;
			IL_0109:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
			IL_00d2:
			_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readLinkedTableColumn"));
			goto IL_0109;
		}
	}

	private void readLinkedTableRow(TableEntity.Row row)
	{
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code <= 91)
			{
				if (code != 1)
				{
					if (code != 90)
					{
						if (code != 91)
						{
							goto IL_00e3;
						}
						row.CustomData = _reader.ValueAsInt;
					}
				}
				else if (!_reader.ValueAsString.Equals("LINKEDTABLEDATAROW_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_00e3;
				}
			}
			else if (code != 300)
			{
				if (code != 301)
				{
					if (code != 309)
					{
						goto IL_00e3;
					}
					flag = _reader.ValueAsString.Equals("LINKEDTABLEDATAROW_END", StringComparison.InvariantCultureIgnoreCase);
				}
				else
				{
					if (!_reader.ValueAsString.Equals("CUSTOMDATA", StringComparison.InvariantCultureIgnoreCase))
					{
						goto IL_00e3;
					}
					readCustomData();
				}
			}
			else
			{
				if (!_reader.ValueAsString.Equals("CELL", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_00e3;
				}
				readCell();
			}
			goto IL_011a;
			IL_00e3:
			_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readLinkedTableRow"));
			goto IL_011a;
			IL_011a:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private TableEntity.Cell readCell()
	{
		_reader.ReadNext();
		TableEntity.Cell cell = new TableEntity.Cell();
		new CadTableEntityTemplate.CadTableCellTemplate(cell);
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			if (_reader.Code != 1)
			{
				goto IL_0092;
			}
			if (_reader.ValueAsString.Equals("LINKEDTABLEDATACELL_BEGIN", StringComparison.InvariantCultureIgnoreCase))
			{
				readLinkedTableCell(cell);
			}
			else if (_reader.ValueAsString.Equals("FORMATTEDTABLEDATACELL_BEGIN", StringComparison.InvariantCultureIgnoreCase))
			{
				readFormattedTableCell(cell);
			}
			else
			{
				if (!_reader.ValueAsString.Equals("TABLECELL_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_0092;
				}
				readTableCell(cell);
				flag = true;
			}
			goto IL_00c9;
			IL_00c9:
			if (flag)
			{
				return cell;
			}
			_reader.ReadNext();
			continue;
			IL_0092:
			_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readCell"));
			goto IL_00c9;
		}
		return cell;
	}

	private void readTableCell(TableEntity.Cell cell)
	{
		DxfClassMap map = DxfClassMap.Create(cell.GetType(), "TABLECELL_BEGIN");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			switch (_reader.Code)
			{
			case 309:
				flag = _reader.ValueAsString.Equals("TABLECELL_END", StringComparison.InvariantCultureIgnoreCase);
				break;
			default:
				if (!tryAssignCurrentValue(cell, map))
				{
					_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} {3}.", _reader.Code, _reader.ValueAsString, "readTableCell", _reader.Position));
				}
				break;
			case 40:
			case 41:
			case 330:
				break;
			}
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private void readFormattedTableCell(TableEntity.Cell cell)
	{
		DxfClassMap map = DxfClassMap.Create(cell.GetType(), "FORMATTEDTABLEDATACELL_BEGIN");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code != 300)
			{
				if (code == 309)
				{
					flag = _reader.ValueAsString.Equals("FORMATTEDTABLEDATACELL_END", StringComparison.InvariantCultureIgnoreCase);
					goto IL_00e2;
				}
			}
			else if (_reader.ValueAsString.Equals("CELLTABLEFORMAT", StringComparison.InvariantCultureIgnoreCase))
			{
				readCellTableFormat(cell);
				continue;
			}
			if (!tryAssignCurrentValue(cell, map))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} {3}.", _reader.Code, _reader.ValueAsString, "readFormattedTableCell", _reader.Position));
			}
			goto IL_00e2;
			IL_00e2:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private void readCellTableFormat(TableEntity.Cell cell)
	{
		DxfClassMap map = DxfClassMap.Create(cell.GetType(), "CELLTABLEFORMAT");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.Code == 1)
		{
			if (_reader.Code != 1)
			{
				goto IL_0085;
			}
			if (_reader.ValueAsString.Equals("TABLEFORMAT_BEGIN", StringComparison.InvariantCultureIgnoreCase))
			{
				readStyleOverride(new CadTableEntityTemplate.CadCellStyleTemplate(cell.StyleOverride));
			}
			else
			{
				if (!_reader.ValueAsString.Equals("CELLSTYLE_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_0085;
				}
				readCellStyle(new CadTableEntityTemplate.CadCellStyleTemplate());
			}
			goto IL_00e8;
			IL_00e8:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
			IL_0085:
			if (!tryAssignCurrentValue(cell, map))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} {3}.", _reader.Code, _reader.ValueAsString, "readCellTableFormat", _reader.Position));
			}
			goto IL_00e8;
		}
	}

	private void readCellStyle(CadTableEntityTemplate.CadCellStyleTemplate template)
	{
		_reader.ReadNext();
		bool flag = false;
		while (_reader.Code != 1)
		{
			if (_reader.Code == 309)
			{
				flag = _reader.ValueAsString.Equals("CELLSTYLE_END", StringComparison.InvariantCultureIgnoreCase);
			}
			else
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} {3}.", _reader.Code, _reader.ValueAsString, "readCellStyle", _reader.Position));
			}
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private void readLinkedTableCell(TableEntity.Cell cell)
	{
		DxfClassMap map = DxfClassMap.Create(cell.GetType(), "LINKEDTABLEDATACELL_BEGIN");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code <= 301)
			{
				if (code != 95)
				{
					if (code != 301 || !_reader.ValueAsString.Equals("CUSTOMDATA", StringComparison.InvariantCultureIgnoreCase))
					{
						goto IL_00b9;
					}
					readCustomData();
				}
			}
			else if (code != 302)
			{
				if (code != 309)
				{
					goto IL_00b9;
				}
				flag = _reader.ValueAsString.Equals("LINKEDTABLEDATACELL_END", StringComparison.InvariantCultureIgnoreCase);
			}
			else
			{
				if (!_reader.ValueAsString.Equals("CONTENT", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_00b9;
				}
				readLinkedTableCellContent();
			}
			goto IL_011c;
			IL_00b9:
			if (!tryAssignCurrentValue(cell, map))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} {3}.", _reader.Code, _reader.ValueAsString, "readLinkedTableCell", _reader.Position));
			}
			goto IL_011c;
			IL_011c:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private CadTableEntityTemplate.CadTableCellContentTemplate readLinkedTableCellContent()
	{
		TableEntity.CellContent cellContent = new TableEntity.CellContent();
		CadTableEntityTemplate.CadTableCellContentTemplate cadTableCellContentTemplate = new CadTableEntityTemplate.CadTableCellContentTemplate(cellContent);
		DxfClassMap map = DxfClassMap.Create(cellContent.GetType(), "CONTENT");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			if (_reader.Code != 1)
			{
				goto IL_0085;
			}
			if (_reader.ValueAsString.Equals("FORMATTEDCELLCONTENT_BEGIN", StringComparison.InvariantCultureIgnoreCase))
			{
				readFormattedCellContent();
				flag = true;
			}
			else
			{
				if (!_reader.ValueAsString.Equals("CELLCONTENT_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_0085;
				}
				readCellContent(cadTableCellContentTemplate);
			}
			goto IL_00e8;
			IL_00e8:
			if (flag)
			{
				break;
			}
			_reader.ReadNext();
			continue;
			IL_0085:
			if (!tryAssignCurrentValue(cellContent, map))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} {3}.", _reader.Code, _reader.ValueAsString, "readLinkedTableCellContent", _reader.Position));
			}
			goto IL_00e8;
		}
		return cadTableCellContentTemplate;
	}

	private void readCellContent(CadTableEntityTemplate.CadTableCellContentTemplate template)
	{
		TableEntity.CellContent content = template.Content;
		DxfClassMap map = DxfClassMap.Create(content.GetType(), "CELLCONTENT_BEGIN");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code <= 300)
			{
				if (code != 91)
				{
					if (code != 300 || !_reader.ValueAsString.Equals("VALUE", StringComparison.InvariantCultureIgnoreCase))
					{
						goto IL_00b7;
					}
					readDataMapValue();
				}
			}
			else if (code != 309)
			{
				if (code != 340)
				{
					goto IL_00b7;
				}
				template.BlockRecordHandle = _reader.ValueAsHandle;
			}
			else
			{
				flag = _reader.ValueAsString.Equals("CELLCONTENT_END", StringComparison.InvariantCultureIgnoreCase);
			}
			goto IL_011a;
			IL_00b7:
			if (!tryAssignCurrentValue(content, map))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} {3}.", _reader.Code, _reader.ValueAsString, "readCellContent", _reader.Position));
			}
			goto IL_011a;
			IL_011a:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private void readFormattedCellContent()
	{
		TableEntity.ContentFormat contentFormat = new TableEntity.ContentFormat();
		CadTableEntityTemplate.CadTableCellContentFormatTemplate template = new CadTableEntityTemplate.CadTableCellContentFormatTemplate(contentFormat);
		DxfClassMap map = DxfClassMap.Create(contentFormat.GetType(), "FORMATTEDCELLCONTENT");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code != 300)
			{
				if (code != 309)
				{
					goto IL_008c;
				}
				flag = _reader.ValueAsString.Equals("FORMATTEDCELLCONTENT_END", StringComparison.InvariantCultureIgnoreCase);
			}
			else
			{
				if (!_reader.ValueAsString.Equals("CONTENTFORMAT", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_008c;
				}
				readContentFormat(template);
			}
			goto IL_00cd;
			IL_008c:
			if (!tryAssignCurrentValue(contentFormat, map))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readFormattedCellContent"));
			}
			goto IL_00cd;
			IL_00cd:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private void readContentFormat(CadTableEntityTemplate.CadTableCellContentFormatTemplate template)
	{
		TableEntity.ContentFormat format = template.Format;
		DxfClassMap map = DxfClassMap.Create(format.GetType(), "CONTENTFORMAT_BEGIN");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code != 1)
			{
				if (code != 309)
				{
					if (code != 340)
					{
						goto IL_0098;
					}
					template.TextStyleHandle = _reader.ValueAsHandle;
				}
				else
				{
					flag = _reader.ValueAsString.Equals("CONTENTFORMAT_END", StringComparison.InvariantCultureIgnoreCase);
				}
			}
			else if (!_reader.ValueAsString.Equals("CONTENTFORMAT_BEGIN", StringComparison.InvariantCultureIgnoreCase))
			{
				goto IL_0098;
			}
			goto IL_00d9;
			IL_0098:
			if (!tryAssignCurrentValue(format, map))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readContentFormat"));
			}
			goto IL_00d9;
			IL_00d9:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private void readFormattedTableColumn(TableEntity.Column column)
	{
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code != 1)
			{
				if (code != 300)
				{
					if (code != 309)
					{
						goto IL_0092;
					}
					flag = _reader.ValueAsString.Equals("FORMATTEDTABLEDATACOLUMN_END", StringComparison.InvariantCultureIgnoreCase);
				}
				else if (!_reader.ValueAsString.Equals("COLUMNTABLEFORMAT", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_0092;
				}
			}
			else
			{
				if (!_reader.ValueAsString.Equals("TABLEFORMAT_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_0092;
				}
				readStyleOverride(new CadTableEntityTemplate.CadCellStyleTemplate(column.CellStyleOverride));
			}
			goto IL_00c9;
			IL_00c9:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
			IL_0092:
			_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readFormattedTableColumn"));
			goto IL_00c9;
		}
	}

	private void readStyleOverride(CadTableEntityTemplate.CadCellStyleTemplate template)
	{
		TableEntity.CellStyle cellStyle = template.Format as TableEntity.CellStyle;
		DxfClassMap map = DxfClassMap.Create(cellStyle.GetType(), "TABLEFORMAT_STYLE");
		DxfClassMap map2 = DxfClassMap.Create(typeof(TableEntity.ContentFormat), "TABLEFORMAT_BEGIN");
		_reader.ReadNext();
		bool flag = false;
		TableEntity.CellEdgeFlags edgeFlags = TableEntity.CellEdgeFlags.Unknown;
		while (_reader.DxfCode != DxfCode.Start)
		{
			switch (_reader.Code)
			{
			case 95:
				edgeFlags = (TableEntity.CellEdgeFlags)_reader.ValueAsInt;
				break;
			case 1:
				if (_reader.ValueAsString.Equals("TABLEFORMAT_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					break;
				}
				goto default;
			case 300:
				if (_reader.ValueAsString.Equals("CONTENTFORMAT", StringComparison.InvariantCultureIgnoreCase))
				{
					readContentFormat(new CadTableEntityTemplate.CadTableCellContentFormatTemplate(new TableEntity.ContentFormat()));
					break;
				}
				goto default;
			case 301:
				if (_reader.ValueAsString.Equals("MARGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					readCellMargin(template);
					break;
				}
				goto default;
			case 302:
				if (_reader.ValueAsString.Equals("GRIDFORMAT", StringComparison.InvariantCultureIgnoreCase))
				{
					TableEntity.CellBorder border = new TableEntity.CellBorder(edgeFlags);
					readGridFormat(template, border);
					break;
				}
				goto default;
			case 309:
				flag = _reader.ValueAsString.Equals("TABLEFORMAT_END", StringComparison.InvariantCultureIgnoreCase);
				break;
			default:
				if (!tryAssignCurrentValue(cellStyle, map) && !tryAssignCurrentValue(cellStyle, map2))
				{
					_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readStyleOverride"));
				}
				break;
			}
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private void readGridFormat(CadTableEntityTemplate.CadCellStyleTemplate template, TableEntity.CellBorder border)
	{
		DxfClassMap map = DxfClassMap.Create(border.GetType(), "CellBorder");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code != 1)
			{
				if (code != 309)
				{
					if (code != 340)
					{
						goto IL_0097;
					}
					template.BorderLinetypePairs.Add(new Tuple<TableEntity.CellBorder, ulong>(border, _reader.ValueAsHandle));
				}
				else
				{
					flag = _reader.ValueAsString.Equals("GRIDFORMAT_END", StringComparison.InvariantCultureIgnoreCase);
				}
			}
			else if (!_reader.ValueAsString.Equals("GRIDFORMAT_BEGIN", StringComparison.InvariantCultureIgnoreCase))
			{
				goto IL_0097;
			}
			goto IL_00d8;
			IL_0097:
			if (!tryAssignCurrentValue(border, map))
			{
				_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readGridFormat"));
			}
			goto IL_00d8;
			IL_00d8:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private void readCellMargin(CadTableEntityTemplate.CadCellStyleTemplate template)
	{
		TableEntity.CellStyle cellStyle = template.Format as TableEntity.CellStyle;
		_reader.ReadNext();
		bool flag = false;
		int num = 0;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code != 1)
			{
				if (code != 40)
				{
					if (code != 309)
					{
						goto IL_0114;
					}
					flag = _reader.ValueAsString.Equals("CELLMARGIN_END", StringComparison.InvariantCultureIgnoreCase);
				}
				else
				{
					switch (num)
					{
					case 0:
						cellStyle.VerticalMargin = _reader.ValueAsDouble;
						break;
					case 1:
						cellStyle.HorizontalMargin = _reader.ValueAsDouble;
						break;
					case 2:
						cellStyle.BottomMargin = _reader.ValueAsDouble;
						break;
					case 3:
						cellStyle.RightMargin = _reader.ValueAsDouble;
						break;
					case 4:
						cellStyle.MarginHorizontalSpacing = _reader.ValueAsDouble;
						break;
					case 5:
						cellStyle.MarginVerticalSpacing = _reader.ValueAsDouble;
						break;
					}
					num++;
				}
			}
			else if (!_reader.ValueAsString.Equals("CELLMARGIN_BEGIN", StringComparison.InvariantCultureIgnoreCase))
			{
				goto IL_0114;
			}
			goto IL_014b;
			IL_014b:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
			IL_0114:
			_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readCellMargin"));
			goto IL_014b;
		}
	}

	private void readCustomData()
	{
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			int code = _reader.Code;
			if (code <= 90)
			{
				if (code != 1)
				{
					if (code != 90)
					{
						goto IL_00b2;
					}
					_ = _reader.ValueAsInt;
				}
				else if (!_reader.ValueAsString.Equals("DATAMAP_BEGIN", StringComparison.InvariantCultureIgnoreCase))
				{
					goto IL_00b2;
				}
			}
			else if (code != 300)
			{
				if (code != 301)
				{
					if (code != 309)
					{
						goto IL_00b2;
					}
					flag = _reader.ValueAsString.Equals("DATAMAP_END", StringComparison.InvariantCultureIgnoreCase);
				}
				else
				{
					if (!_reader.ValueAsString.Equals("DATAMAP_VALUE", StringComparison.InvariantCultureIgnoreCase))
					{
						goto IL_00b2;
					}
					readDataMapValue();
				}
			}
			goto IL_00e9;
			IL_00b2:
			_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readCustomData"));
			goto IL_00e9;
			IL_00e9:
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private void readDataMapValue()
	{
		TableEntity.CellValue cellValue = new TableEntity.CellValue();
		DxfClassMap map = DxfClassMap.Create(cellValue.GetType(), "DATAMAP_VALUE");
		_reader.ReadNext();
		bool flag = false;
		while (_reader.DxfCode != DxfCode.Start)
		{
			switch (_reader.Code)
			{
			case 304:
				flag = _reader.ValueAsString.Equals("ACVALUE_END", StringComparison.InvariantCultureIgnoreCase);
				break;
			default:
				if (!tryAssignCurrentValue(cellValue, map))
				{
					_builder.Notify(string.Format("Unhandled dxf code {0} value {1} at {2} method.", _reader.Code, _reader.ValueAsString, "readDataMapValue"));
				}
				break;
			case 11:
			case 21:
			case 31:
			case 91:
			case 92:
			case 140:
			case 310:
				break;
			}
			if (!flag)
			{
				_reader.ReadNext();
				continue;
			}
			break;
		}
	}

	private bool readVisualStyle(CadTemplate template, DxfMap map)
	{
		int code = _reader.Code;
		if ((uint)(code - 176) > 1u)
		{
			_ = 420;
		}
		return true;
	}

	private bool readSpatialFilter(CadTemplate template, DxfMap map)
	{
		CadSpatialFilterTemplate cadSpatialFilterTemplate = template as CadSpatialFilterTemplate;
		SpatialFilter spatialFilter = cadSpatialFilterTemplate.CadObject as SpatialFilter;
		switch (_reader.Code)
		{
		case 10:
			spatialFilter.BoundaryPoints.Add(new XY(_reader.ValueAsDouble, 0.0));
			return true;
		case 20:
		{
			XY xY = spatialFilter.BoundaryPoints.LastOrDefault();
			spatialFilter.BoundaryPoints.Add(new XY(xY.X, _reader.ValueAsDouble));
			return true;
		}
		case 40:
		{
			if (spatialFilter.ClipFrontPlane && !cadSpatialFilterTemplate.HasFrontPlane)
			{
				spatialFilter.FrontDistance = _reader.ValueAsDouble;
				cadSpatialFilterTemplate.HasFrontPlane = true;
			}
			double[] array = new double[16]
			{
				0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0,
				0.0, 0.0, 0.0, 0.0, 0.0, 1.0
			};
			for (int i = 0; i < 12; i++)
			{
				array[i] = _reader.ValueAsDouble;
				if (i < 11)
				{
					_reader.ReadNext();
				}
			}
			if (cadSpatialFilterTemplate.InsertTransformRead)
			{
				spatialFilter.InsertTransform = new Matrix4(array);
				cadSpatialFilterTemplate.InsertTransformRead = true;
			}
			else
			{
				spatialFilter.InverseInsertTransform = new Matrix4(array);
			}
			return true;
		}
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbSpatialFilter"]);
		}
	}

	private bool readMLineStyle(CadTemplate template, DxfMap map)
	{
		CadMLineStyleTemplate cadMLineStyleTemplate = template as CadMLineStyleTemplate;
		MLineStyle mLineStyle = template.CadObject as MLineStyle;
		switch (_reader.Code)
		{
		case 6:
		{
			CadMLineStyleTemplate.ElementTemplate elementTemplate = cadMLineStyleTemplate.ElementTemplates.LastOrDefault();
			if (elementTemplate == null)
			{
				return true;
			}
			elementTemplate.LineTypeName = _reader.ValueAsString;
			return true;
		}
		case 49:
		{
			MLineStyle.Element element = new MLineStyle.Element();
			CadMLineStyleTemplate.ElementTemplate item = new CadMLineStyleTemplate.ElementTemplate(element);
			element.Offset = _reader.ValueAsDouble;
			cadMLineStyleTemplate.ElementTemplates.Add(item);
			mLineStyle.AddElement(element);
			return true;
		}
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadMLineStyleTemplate.CadObject.SubclassMarker]);
		}
	}

	private bool readMLeaderStyle(CadTemplate template, DxfMap map)
	{
		CadMLeaderStyleTemplate cadMLeaderStyleTemplate = template as CadMLeaderStyleTemplate;
		switch (_reader.Code)
		{
		case 179:
			return true;
		case 340:
			cadMLeaderStyleTemplate.LeaderLineTypeHandle = _reader.ValueAsHandle;
			return true;
		case 342:
			cadMLeaderStyleTemplate.MTextStyleHandle = _reader.ValueAsHandle;
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses[cadMLeaderStyleTemplate.CadObject.SubclassMarker]);
		}
	}

	private bool readXRecord(CadTemplate template, DxfMap map)
	{
		CadXRecordTemplate template2 = template as CadXRecordTemplate;
		if (_reader.Code == 100 && _reader.ValueAsString == "AcDbXrecord")
		{
			readXRecordEntries(template2);
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbXrecord"]);
	}

	private void readXRecordEntries(CadXRecordTemplate template)
	{
		_reader.ReadNext();
		while (_reader.DxfCode != DxfCode.Start)
		{
			switch (_reader.GroupCodeValue)
			{
			case GroupCodeValueType.Point3D:
			{
				int code = _reader.Code;
				double valueAsDouble = _reader.ValueAsDouble;
				_reader.ReadNext();
				double valueAsDouble2 = _reader.ValueAsDouble;
				_reader.ReadNext();
				double valueAsDouble3 = _reader.ValueAsDouble;
				XYZ xYZ = new XYZ(valueAsDouble, valueAsDouble2, valueAsDouble3);
				template.CadObject.CreateEntry(code, xYZ);
				break;
			}
			case GroupCodeValueType.Handle:
			case GroupCodeValueType.ObjectId:
			case GroupCodeValueType.ExtendedDataHandle:
				template.AddHandleReference(_reader.Code, _reader.ValueAsHandle);
				break;
			default:
				template.CadObject.CreateEntry(_reader.Code, _reader.Value);
				break;
			}
			_reader.ReadNext();
		}
	}

	private bool readBookColor(CadTemplate template, DxfMap map)
	{
		BookColor bookColor = (template as CadNonGraphicalObjectTemplate).CadObject as BookColor;
		if (_reader.Code == 430)
		{
			bookColor.Name = _reader.ValueAsString;
			return true;
		}
		return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbColor"]);
	}

	private bool readDictionary(CadTemplate template, DxfMap map)
	{
		CadDictionaryTemplate cadDictionaryTemplate = template as CadDictionaryTemplate;
		CadDictionary cadObject = cadDictionaryTemplate.CadObject;
		switch (_reader.Code)
		{
		case 280:
			cadObject.HardOwnerFlag = _reader.ValueAsBool;
			return true;
		case 281:
			cadObject.ClonningFlags = (DictionaryCloningFlags)_reader.Value;
			return true;
		case 3:
			cadDictionaryTemplate.Entries.Add(_reader.ValueAsString, null);
			return true;
		case 350:
		case 360:
			cadDictionaryTemplate.Entries[cadDictionaryTemplate.Entries.LastOrDefault().Key] = _reader.ValueAsHandle;
			return true;
		default:
			return tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbDictionary"]);
		}
	}

	private bool readDictionaryWithDefault(CadTemplate template, DxfMap map)
	{
		CadDictionaryWithDefaultTemplate cadDictionaryWithDefaultTemplate = template as CadDictionaryWithDefaultTemplate;
		if (_reader.Code == 340)
		{
			cadDictionaryWithDefaultTemplate.DefaultEntryHandle = _reader.ValueAsHandle;
			return true;
		}
		if (!tryAssignCurrentValue(template.CadObject, map.SubClasses["AcDbDictionaryWithDefault"]))
		{
			return readDictionary(template, map);
		}
		return true;
	}

	private CadTemplate readSortentsTable()
	{
		CadSortensTableTemplate cadSortensTableTemplate = new CadSortensTableTemplate(new SortEntitiesTable());
		_reader.ReadNext();
		readCommonObjectData(cadSortensTableTemplate);
		_reader.ReadNext();
		(ulong?, ulong?) tuple = (null, null);
		while (_reader.DxfCode != DxfCode.Start)
		{
			switch (_reader.Code)
			{
			case 5:
				tuple.Item1 = _reader.ValueAsHandle;
				break;
			case 330:
				cadSortensTableTemplate.BlockOwnerHandle = _reader.ValueAsHandle;
				break;
			case 331:
				tuple.Item2 = _reader.ValueAsHandle;
				break;
			default:
				_builder.Notify($"Group Code not handled {_reader.GroupCodeValue} for {typeof(SortEntitiesTable)}, code : {_reader.Code} | value : {_reader.ValueAsString}");
				break;
			}
			if (tuple.Item1.HasValue && tuple.Item2.HasValue)
			{
				cadSortensTableTemplate.Values.Add((tuple.Item1.Value, tuple.Item2.Value));
				tuple = (null, null);
			}
			_reader.ReadNext();
		}
		return cadSortensTableTemplate;
	}
}
