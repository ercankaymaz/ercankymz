using System;
using ACadSharp.Entities;
using ACadSharp.Header;
using ACadSharp.Tables;
using ACadSharp.Types.Units;
using CSMath;
using CSUtilities.IO;

namespace ACadSharp.IO.DWG;

internal class DwgHeaderReader : DwgSectionIO
{
	private IDwgStreamReader _reader;

	private CadHeader _header;

	public override string SectionName => "AcDb:Header";

	public DwgHeaderReader(ACadVersion version, IDwgStreamReader reader, CadHeader header)
		: base(version)
	{
		_reader = reader;
		_header = header;
		_header.Version = version;
	}

	public void Read(int acadMaintenanceVersion, out DwgHeaderHandlesCollection objectPointers)
	{
		IDwgStreamReader reader = _reader;
		objectPointers = new DwgHeaderHandlesCollection();
		checkSentinel(_reader, DwgSectionDefinition.StartSentinels[SectionName]);
		long num = _reader.ReadRawLong();
		if ((R2010Plus && acadMaintenanceVersion > 3) || R2018Plus)
		{
			_reader.ReadRawLong();
		}
		long num2 = _reader.PositionInBits();
		if (R2007Plus)
		{
			long num3 = _reader.ReadRawLong();
			long num4 = num2 + num3 - 1;
			IDwgStreamReader streamHandler = DwgStreamReaderBase.GetStreamHandler(_version, new StreamIO(_reader.Stream, createCopy: true).Stream);
			streamHandler.SetPositionByFlag(num4);
			IDwgStreamReader streamHandler2 = DwgStreamReaderBase.GetStreamHandler(_version, new StreamIO(_reader.Stream, createCopy: true).Stream);
			streamHandler2.SetPositionInBits(num4 + 1);
			_reader = new DwgMergedReader(_reader, streamHandler, streamHandler2);
		}
		if (R2013Plus)
		{
			_header.RequiredVersions = _reader.ReadBitLongLong();
		}
		_reader.ReadBitDouble();
		_reader.ReadBitDouble();
		_reader.ReadBitDouble();
		_reader.ReadBitDouble();
		_reader.ReadVariableText();
		_reader.ReadVariableText();
		_reader.ReadVariableText();
		_reader.ReadVariableText();
		_reader.ReadBitLong();
		_reader.ReadBitLong();
		if (R13_14Only)
		{
			_reader.ReadBitShort();
		}
		if (R2004Pre)
		{
			_reader.HandleReference();
		}
		_header.AssociatedDimensions = _reader.ReadBit();
		_header.UpdateDimensionsWhileDragging = _reader.ReadBit();
		if (R13_14Only)
		{
			_header.DIMSAV = _reader.ReadBit();
		}
		_header.PolylineLineTypeGeneration = _reader.ReadBit();
		_header.OrthoMode = _reader.ReadBit();
		_header.RegenerationMode = _reader.ReadBit();
		_header.FillMode = _reader.ReadBit();
		_header.QuickTextMode = _reader.ReadBit();
		_header.PaperSpaceLineTypeScaling = (_reader.ReadBit() ? SpaceLineTypeScaling.Normal : SpaceLineTypeScaling.Viewport);
		_header.LimitCheckingOn = _reader.ReadBit();
		if (R13_14Only)
		{
			_header.BlipMode = _reader.ReadBit();
		}
		if (R2004Plus)
		{
			_reader.ReadBit();
		}
		_header.UserTimer = _reader.ReadBit();
		_header.SketchPolylines = _reader.ReadBit();
		_header.AngularDirection = (AngularDirection)_reader.ReadBitAsShort();
		_header.ShowSplineControlPoints = _reader.ReadBit();
		if (R13_14Only)
		{
			_reader.ReadBit();
			_reader.ReadBit();
		}
		_header.MirrorText = _reader.ReadBit();
		_header.WorldView = _reader.ReadBit();
		if (R13_14Only)
		{
			_reader.ReadBit();
		}
		_header.ShowModelSpace = _reader.ReadBit();
		_header.PaperSpaceLimitsChecking = _reader.ReadBit();
		_header.RetainXRefDependentVisibilitySettings = _reader.ReadBit();
		if (R13_14Only)
		{
			_reader.ReadBit();
		}
		_header.DisplaySilhouetteCurves = _reader.ReadBit();
		_header.CreateEllipseAsPolyline = _reader.ReadBit();
		_header.ProxyGraphics = _reader.ReadBitShortAsBool();
		if (R13_14Only)
		{
			_reader.ReadBitShort();
		}
		_header.SpatialIndexMaxTreeDepth = _reader.ReadBitShort();
		_header.LinearUnitFormat = (LinearUnitFormat)_reader.ReadBitShort();
		short num5 = _reader.ReadBitShort();
		if (num5 >= 0 && num5 <= 8)
		{
			_header.LinearUnitPrecision = num5;
		}
		_header.AngularUnit = (AngularUnitFormat)_reader.ReadBitShort();
		short num6 = _reader.ReadBitShort();
		if (num6 >= 0 && num6 <= 8)
		{
			_header.AngularUnitPrecision = num6;
		}
		if (R13_14Only)
		{
			_header.ObjectSnapMode = (ObjectSnapMode)_reader.ReadBitShort();
		}
		_header.AttributeVisibility = (AttributeVisibilityMode)_reader.ReadBitShort();
		if (R13_14Only)
		{
			_reader.ReadBitShort();
		}
		_header.PointDisplayMode = _reader.ReadBitShort();
		if (R13_14Only)
		{
			_reader.ReadBitShort();
		}
		if (R2004Plus)
		{
			_reader.ReadBitLong();
			_reader.ReadBitLong();
			_reader.ReadBitLong();
		}
		_header.UserShort1 = _reader.ReadBitShort();
		_header.UserShort2 = _reader.ReadBitShort();
		_header.UserShort3 = _reader.ReadBitShort();
		_header.UserShort4 = _reader.ReadBitShort();
		_header.UserShort5 = _reader.ReadBitShort();
		_header.NumberOfSplineSegments = _reader.ReadBitShort();
		_header.SurfaceDensityU = _reader.ReadBitShort();
		_header.SurfaceDensityV = _reader.ReadBitShort();
		_header.SurfaceType = _reader.ReadBitShort();
		_header.SurfaceMeshTabulationCount1 = _reader.ReadBitShort();
		_header.SurfaceMeshTabulationCount2 = _reader.ReadBitShort();
		_header.SplineType = (SplineType)_reader.ReadBitShort();
		_header.ShadeEdge = (ShadeEdgeType)_reader.ReadBitShort();
		_header.ShadeDiffuseToAmbientPercentage = _reader.ReadBitShort();
		_header.UnitMode = _reader.ReadBitShort();
		_header.MaxViewportCount = _reader.ReadBitShort();
		short num7 = _reader.ReadBitShort();
		if (num7 >= 0 && num7 <= 2047)
		{
			_header.SurfaceIsolineCount = num7;
		}
		_header.CurrentMultiLineJustification = (VerticalAlignmentType)_reader.ReadBitShort();
		short num8 = _reader.ReadBitShort();
		if (num8 >= 0 && num8 <= 100)
		{
			_header.TextQuality = num8;
		}
		_header.LineTypeScale = _reader.ReadBitDouble();
		_header.TextHeightDefault = _reader.ReadBitDouble();
		_header.TraceWidthDefault = _reader.ReadBitDouble();
		_header.SketchIncrement = _reader.ReadBitDouble();
		_header.FilletRadius = _reader.ReadBitDouble();
		_header.ThicknessDefault = _reader.ReadBitDouble();
		_header.AngleBase = _reader.ReadBitDouble();
		_header.PointDisplaySize = _reader.ReadBitDouble();
		_header.PolylineWidthDefault = _reader.ReadBitDouble();
		_header.UserDouble1 = _reader.ReadBitDouble();
		_header.UserDouble2 = _reader.ReadBitDouble();
		_header.UserDouble3 = _reader.ReadBitDouble();
		_header.UserDouble4 = _reader.ReadBitDouble();
		_header.UserDouble5 = _reader.ReadBitDouble();
		_header.ChamferDistance1 = _reader.ReadBitDouble();
		_header.ChamferDistance2 = _reader.ReadBitDouble();
		_header.ChamferLength = _reader.ReadBitDouble();
		_header.ChamferAngle = _reader.ReadBitDouble();
		double num9 = _reader.ReadBitDouble();
		if (num9 > 0.0 && num9 <= 10.0)
		{
			_header.FacetResolution = num9;
		}
		_header.CurrentMultilineScale = _reader.ReadBitDouble();
		_header.CurrentEntityLinetypeScale = _reader.ReadBitDouble();
		_header.MenuFileName = _reader.ReadVariableText();
		_header.CreateDateTime = _reader.ReadDateTime();
		_header.UpdateDateTime = _reader.ReadDateTime();
		if (R2004Plus)
		{
			_reader.ReadBitLong();
			_reader.ReadBitLong();
			_reader.ReadBitLong();
		}
		_header.TotalEditingTime = _reader.ReadTimeSpan();
		_header.UserElapsedTimeSpan = _reader.ReadTimeSpan();
		_header.CurrentEntityColor = _reader.ReadCmColor();
		_header.HandleSeed = reader.HandleReference();
		objectPointers.CLAYER = _reader.HandleReference();
		objectPointers.TEXTSTYLE = _reader.HandleReference();
		objectPointers.CELTYPE = _reader.HandleReference();
		if (R2007Plus)
		{
			objectPointers.CMATERIAL = _reader.HandleReference();
		}
		objectPointers.DIMSTYLE = _reader.HandleReference();
		objectPointers.CMLSTYLE = _reader.HandleReference();
		if (R2000Plus)
		{
			_header.ViewportDefaultViewScaleFactor = _reader.ReadBitDouble();
		}
		_header.PaperSpaceInsertionBase = _reader.Read3BitDouble();
		_header.PaperSpaceExtMin = _reader.Read3BitDouble();
		_header.PaperSpaceExtMax = _reader.Read3BitDouble();
		_header.PaperSpaceLimitsMin = _reader.Read2RawDouble();
		_header.PaperSpaceLimitsMax = _reader.Read2RawDouble();
		_header.PaperSpaceElevation = _reader.ReadBitDouble();
		_header.PaperSpaceUcsOrigin = _reader.Read3BitDouble();
		_header.PaperSpaceUcsXAxis = _reader.Read3BitDouble();
		_header.PaperSpaceUcsYAxis = _reader.Read3BitDouble();
		objectPointers.UCSNAME_PSPACE = _reader.HandleReference();
		if (R2000Plus)
		{
			objectPointers.PUCSORTHOREF = _reader.HandleReference();
			_reader.ReadBitShort();
			objectPointers.PUCSBASE = _reader.HandleReference();
			_header.PaperSpaceOrthographicTopDOrigin = _reader.Read3BitDouble();
			_header.PaperSpaceOrthographicBottomDOrigin = _reader.Read3BitDouble();
			_header.PaperSpaceOrthographicLeftDOrigin = _reader.Read3BitDouble();
			_header.PaperSpaceOrthographicRightDOrigin = _reader.Read3BitDouble();
			_header.PaperSpaceOrthographicFrontDOrigin = _reader.Read3BitDouble();
			_header.PaperSpaceOrthographicBackDOrigin = _reader.Read3BitDouble();
		}
		_header.ModelSpaceInsertionBase = _reader.Read3BitDouble();
		_header.ModelSpaceExtMin = _reader.Read3BitDouble();
		_header.ModelSpaceExtMax = _reader.Read3BitDouble();
		_header.ModelSpaceLimitsMin = _reader.Read2RawDouble();
		_header.ModelSpaceLimitsMax = _reader.Read2RawDouble();
		_header.Elevation = _reader.ReadBitDouble();
		_header.ModelSpaceOrigin = _reader.Read3BitDouble();
		_header.ModelSpaceXAxis = _reader.Read3BitDouble();
		_header.ModelSpaceYAxis = _reader.Read3BitDouble();
		objectPointers.UCSNAME_MSPACE = _reader.HandleReference();
		if (R2000Plus)
		{
			objectPointers.UCSORTHOREF = _reader.HandleReference();
			_reader.ReadBitShort();
			objectPointers.UCSBASE = _reader.HandleReference();
			_header.ModelSpaceOrthographicTopDOrigin = _reader.Read3BitDouble();
			_header.ModelSpaceOrthographicBottomDOrigin = _reader.Read3BitDouble();
			_header.ModelSpaceOrthographicLeftDOrigin = _reader.Read3BitDouble();
			_header.ModelSpaceOrthographicRightDOrigin = _reader.Read3BitDouble();
			_header.ModelSpaceOrthographicFrontDOrigin = _reader.Read3BitDouble();
			_header.ModelSpaceOrthographicBackDOrigin = _reader.Read3BitDouble();
			_header.DimensionPostFix = _reader.ReadVariableText();
			_header.DimensionAlternateDimensioningSuffix = _reader.ReadVariableText();
		}
		if (R13_14Only)
		{
			_header.DimensionGenerateTolerances = _reader.ReadBit();
			_header.DimensionLimitsGeneration = _reader.ReadBit();
			_header.DimensionTextInsideHorizontal = _reader.ReadBit();
			_header.DimensionTextOutsideHorizontal = _reader.ReadBit();
			_header.DimensionSuppressFirstExtensionLine = _reader.ReadBit();
			_header.DimensionSuppressSecondExtensionLine = _reader.ReadBit();
			_header.DimensionAlternateUnitDimensioning = _reader.ReadBit();
			_header.DimensionTextOutsideExtensions = _reader.ReadBit();
			_header.DimensionSeparateArrowBlocks = _reader.ReadBit();
			_header.DimensionTextInsideExtensions = _reader.ReadBit();
			_header.DimensionSuppressOutsideExtensions = _reader.ReadBit();
			_header.DimensionAlternateUnitDecimalPlaces = (short)_reader.ReadRawChar();
			_header.DimensionZeroHandling = (ZeroHandling)_reader.ReadRawChar();
			_header.DimensionSuppressFirstDimensionLine = _reader.ReadBit();
			_header.DimensionSuppressSecondDimensionLine = _reader.ReadBit();
			_header.DimensionToleranceAlignment = (ToleranceAlignment)_reader.ReadRawChar();
			_header.DimensionTextHorizontalAlignment = (DimensionTextHorizontalAlignment)_reader.ReadRawChar();
			_header.DimensionFit = (short)_reader.ReadRawChar();
			_header.DimensionCursorUpdate = _reader.ReadBit();
			_header.DimensionToleranceZeroHandling = (ZeroHandling)_reader.ReadRawChar();
			_header.DimensionAlternateUnitZeroHandling = (ZeroHandling)_reader.ReadRawChar();
			_header.DimensionAlternateUnitToleranceZeroHandling = (ZeroHandling)_reader.ReadRawChar();
			_header.DimensionTextVerticalAlignment = (DimensionTextVerticalAlignment)_reader.ReadRawChar();
			_header.DimensionUnit = _reader.ReadBitShort();
			_header.DimensionAngularDimensionDecimalPlaces = _reader.ReadBitShort();
			_header.DimensionDecimalPlaces = _reader.ReadBitShort();
			_header.DimensionToleranceDecimalPlaces = _reader.ReadBitShort();
			_header.DimensionAlternateUnitFormat = (LinearUnitFormat)_reader.ReadBitShort();
			_header.DimensionAlternateUnitToleranceDecimalPlaces = _reader.ReadBitShort();
			objectPointers.DIMTXSTY = _reader.HandleReference();
		}
		_header.DimensionScaleFactor = _reader.ReadBitDouble();
		_header.DimensionArrowSize = _reader.ReadBitDouble();
		_header.DimensionExtensionLineOffset = _reader.ReadBitDouble();
		_header.DimensionLineIncrement = _reader.ReadBitDouble();
		_header.DimensionExtensionLineExtension = _reader.ReadBitDouble();
		_header.DimensionRounding = _reader.ReadBitDouble();
		_header.DimensionLineExtension = _reader.ReadBitDouble();
		_header.DimensionPlusTolerance = _reader.ReadBitDouble();
		_header.DimensionMinusTolerance = _reader.ReadBitDouble();
		if (R2007Plus)
		{
			_header.DimensionFixedExtensionLineLength = _reader.ReadBitDouble();
			double num10 = _reader.ReadBitDouble();
			double num11 = Math.Round(num10, 6);
			if (num11 > MathHelper.DegToRad(5.0) && num11 < Math.PI / 2.0)
			{
				_header.DimensionJoggedRadiusDimensionTransverseSegmentAngle = num10;
			}
			_header.DimensionTextBackgroundFillMode = (DimensionTextBackgroundFillMode)_reader.ReadBitShort();
			_header.DimensionTextBackgroundColor = _reader.ReadCmColor();
		}
		if (R2000Plus)
		{
			_header.DimensionGenerateTolerances = _reader.ReadBit();
			_header.DimensionLimitsGeneration = _reader.ReadBit();
			_header.DimensionTextInsideHorizontal = _reader.ReadBit();
			_header.DimensionTextOutsideHorizontal = _reader.ReadBit();
			_header.DimensionSuppressFirstExtensionLine = _reader.ReadBit();
			_header.DimensionSuppressSecondExtensionLine = _reader.ReadBit();
			_header.DimensionTextVerticalAlignment = (DimensionTextVerticalAlignment)(ushort)_reader.ReadBitShort();
			_header.DimensionZeroHandling = (ZeroHandling)(ushort)_reader.ReadBitShort();
			_header.DimensionAngularZeroHandling = (ZeroHandling)_reader.ReadBitShort();
		}
		if (R2007Plus)
		{
			_header.DimensionArcLengthSymbolPosition = (ArcLengthSymbolPosition)_reader.ReadBitShort();
		}
		_header.DimensionTextHeight = _reader.ReadBitDouble();
		_header.DimensionCenterMarkSize = _reader.ReadBitDouble();
		_header.DimensionTickSize = _reader.ReadBitDouble();
		_header.DimensionAlternateUnitScaleFactor = _reader.ReadBitDouble();
		_header.DimensionLinearScaleFactor = _reader.ReadBitDouble();
		_header.DimensionTextVerticalPosition = _reader.ReadBitDouble();
		_header.DimensionToleranceScaleFactor = _reader.ReadBitDouble();
		_header.DimensionLineGap = _reader.ReadBitDouble();
		if (R13_14Only)
		{
			_header.DimensionPostFix = _reader.ReadVariableText();
			_header.DimensionAlternateDimensioningSuffix = _reader.ReadVariableText();
			_header.DimensionBlockName = _reader.ReadVariableText();
			_header.DimensionBlockNameFirst = _reader.ReadVariableText();
			_header.DimensionBlockNameSecond = _reader.ReadVariableText();
		}
		if (R2000Plus)
		{
			_header.DimensionAlternateUnitRounding = _reader.ReadBitDouble();
			_header.DimensionAlternateUnitDimensioning = _reader.ReadBit();
			_header.DimensionAlternateUnitDecimalPlaces = (short)(ushort)_reader.ReadBitShort();
			_header.DimensionTextOutsideExtensions = _reader.ReadBit();
			_header.DimensionSeparateArrowBlocks = _reader.ReadBit();
			_header.DimensionTextInsideExtensions = _reader.ReadBit();
			_header.DimensionSuppressOutsideExtensions = _reader.ReadBit();
		}
		_header.DimensionLineColor = _reader.ReadCmColor();
		_header.DimensionExtensionLineColor = _reader.ReadCmColor();
		_header.DimensionTextColor = _reader.ReadCmColor();
		if (R2000Plus)
		{
			_header.DimensionAngularDimensionDecimalPlaces = _reader.ReadBitShort();
			_header.DimensionDecimalPlaces = _reader.ReadBitShort();
			_header.DimensionToleranceDecimalPlaces = _reader.ReadBitShort();
			_header.DimensionAlternateUnitFormat = (LinearUnitFormat)_reader.ReadBitShort();
			_header.DimensionAlternateUnitToleranceDecimalPlaces = _reader.ReadBitShort();
			_header.DimensionAngularUnit = (AngularUnitFormat)_reader.ReadBitShort();
			_header.DimensionFractionFormat = (FractionFormat)_reader.ReadBitShort();
			_header.DimensionLinearUnitFormat = (LinearUnitFormat)_reader.ReadBitShort();
			_header.DimensionDecimalSeparator = (char)_reader.ReadBitShort();
			_header.DimensionTextMovement = (TextMovement)_reader.ReadBitShort();
			_header.DimensionTextHorizontalAlignment = (DimensionTextHorizontalAlignment)(ushort)_reader.ReadBitShort();
			_header.DimensionSuppressFirstExtensionLine = _reader.ReadBit();
			_header.DimensionSuppressSecondExtensionLine = _reader.ReadBit();
			_header.DimensionToleranceAlignment = (ToleranceAlignment)(ushort)_reader.ReadBitShort();
			_header.DimensionToleranceZeroHandling = (ZeroHandling)(ushort)_reader.ReadBitShort();
			_header.DimensionAlternateUnitZeroHandling = (ZeroHandling)(ushort)_reader.ReadBitShort();
			_header.DimensionAlternateUnitToleranceZeroHandling = (ZeroHandling)(ushort)_reader.ReadBitShort();
			_header.DimensionCursorUpdate = _reader.ReadBit();
			_header.DimensionDimensionTextArrowFit = (TextArrowFitType)_reader.ReadBitShort();
		}
		if (R2007Plus)
		{
			_header.DimensionIsExtensionLineLengthFixed = _reader.ReadBit();
		}
		if (R2010Plus)
		{
			_header.DimensionTextDirection = (_reader.ReadBit() ? TextDirection.RightToLeft : TextDirection.LeftToRight);
			_header.DimensionAltMzf = _reader.ReadBitDouble();
			_header.DimensionAltMzs = _reader.ReadVariableText();
			_header.DimensionMzf = _reader.ReadBitDouble();
			_header.DimensionMzs = _reader.ReadVariableText();
		}
		if (R2000Plus)
		{
			objectPointers.DIMTXSTY = _reader.HandleReference();
			objectPointers.DIMLDRBLK = _reader.HandleReference();
			objectPointers.DIMBLK = _reader.HandleReference();
			objectPointers.DIMBLK1 = _reader.HandleReference();
			objectPointers.DIMBLK2 = _reader.HandleReference();
		}
		if (R2007Plus)
		{
			objectPointers.DIMLTYPE = _reader.HandleReference();
			objectPointers.DIMLTEX1 = _reader.HandleReference();
			objectPointers.DIMLTEX2 = _reader.HandleReference();
		}
		if (R2000Plus)
		{
			_header.DimensionLineWeight = (LineWeightType)_reader.ReadBitShort();
			_header.ExtensionLineWeight = (LineWeightType)_reader.ReadBitShort();
		}
		objectPointers.BLOCK_CONTROL_OBJECT = _reader.HandleReference();
		objectPointers.LAYER_CONTROL_OBJECT = _reader.HandleReference();
		objectPointers.STYLE_CONTROL_OBJECT = _reader.HandleReference();
		objectPointers.LINETYPE_CONTROL_OBJECT = _reader.HandleReference();
		objectPointers.VIEW_CONTROL_OBJECT = _reader.HandleReference();
		objectPointers.UCS_CONTROL_OBJECT = _reader.HandleReference();
		objectPointers.VPORT_CONTROL_OBJECT = _reader.HandleReference();
		objectPointers.APPID_CONTROL_OBJECT = _reader.HandleReference();
		objectPointers.DIMSTYLE_CONTROL_OBJECT = _reader.HandleReference();
		if (R13_15Only)
		{
			objectPointers.VIEWPORT_ENTITY_HEADER_CONTROL_OBJECT = _reader.HandleReference();
		}
		objectPointers.DICTIONARY_ACAD_GROUP = _reader.HandleReference();
		objectPointers.DICTIONARY_ACAD_MLINESTYLE = _reader.HandleReference();
		objectPointers.DICTIONARY_NAMED_OBJECTS = _reader.HandleReference();
		if (R2000Plus)
		{
			_header.StackedTextAlignment = _reader.ReadBitShort();
			_header.StackedTextSizePercentage = _reader.ReadBitShort();
			_header.HyperLinkBase = _reader.ReadVariableText();
			_header.StyleSheetName = _reader.ReadVariableText();
			objectPointers.DICTIONARY_LAYOUTS = _reader.HandleReference();
			objectPointers.DICTIONARY_PLOTSETTINGS = _reader.HandleReference();
			objectPointers.DICTIONARY_PLOTSTYLES = _reader.HandleReference();
		}
		if (R2004Plus)
		{
			objectPointers.DICTIONARY_MATERIALS = _reader.HandleReference();
			objectPointers.DICTIONARY_COLORS = _reader.HandleReference();
		}
		if (R2007Plus)
		{
			objectPointers.DICTIONARY_VISUALSTYLE = _reader.HandleReference();
			if (R2013Plus)
			{
				objectPointers.DICTIONARY_VISUALSTYLE = _reader.HandleReference();
			}
		}
		if (R2000Plus)
		{
			int num12 = _reader.ReadBitLong();
			_header.CurrentEntityLineWeight = (LineWeightType)(num12 & 0x1F);
			_header.EndCaps = (short)(num12 & 0x60);
			_header.JoinStyle = (short)(num12 & 0x180);
			_header.DisplayLineWeight = (num12 & 0x200) == 1;
			_header.XEdit = (short)(num12 & 0x400) == 1;
			_header.ExtendedNames = (num12 & 0x800) == 1;
			_header.PlotStyleMode = (short)(num12 & 0x2000);
			_header.LoadOLEObject = (num12 & 0x4000) == 1;
			_header.InsUnits = (UnitsType)_reader.ReadBitShort();
			_header.CurrentEntityPlotStyle = (EntityPlotStyleType)_reader.ReadBitShort();
			if (_header.CurrentEntityPlotStyle == EntityPlotStyleType.ByObjectId)
			{
				objectPointers.CPSNID = _reader.HandleReference();
			}
			_header.FingerPrintGuid = _reader.ReadVariableText();
			_header.VersionGuid = _reader.ReadVariableText();
		}
		if (R2004Plus)
		{
			_header.EntitySortingFlags = (ObjectSortingFlags)_reader.ReadByte();
			_header.IndexCreationFlags = (IndexCreationFlags)_reader.ReadByte();
			_header.HideText = _reader.ReadByte();
			_header.ExternalReferenceClippingBoundaryType = (XClipFrameType)_reader.ReadByte();
			_header.DimensionAssociativity = (DimensionAssociation)_reader.ReadByte();
			_header.HaloGapPercentage = _reader.ReadByte();
			_header.ObscuredColor = new Color(_reader.ReadBitShort());
			_header.InterfereColor = new Color(_reader.ReadBitShort());
			_header.ObscuredType = _reader.ReadByte();
			_header.IntersectionDisplay = _reader.ReadByte();
			_header.ProjectName = _reader.ReadVariableText();
		}
		objectPointers.PAPER_SPACE = _reader.HandleReference();
		objectPointers.MODEL_SPACE = _reader.HandleReference();
		objectPointers.BYLAYER = _reader.HandleReference();
		objectPointers.BYBLOCK = _reader.HandleReference();
		objectPointers.CONTINUOUS = _reader.HandleReference();
		if (R2007Plus)
		{
			_header.CameraDisplayObjects = _reader.ReadBit();
			_reader.ReadBitLong();
			_reader.ReadBitLong();
			_reader.ReadBitDouble();
			double num13 = _reader.ReadBitDouble();
			if (num13 >= 1.0 && num13 <= 30.0)
			{
				_header.StepsPerSecond = num13;
			}
			_header.StepSize = _reader.ReadBitDouble();
			_header.Dw3DPrecision = _reader.ReadBitDouble();
			_header.LensLength = _reader.ReadBitDouble();
			_header.CameraHeight = _reader.ReadBitDouble();
			_header.SolidsRetainHistory = _reader.ReadRawChar();
			_header.ShowSolidsHistory = _reader.ReadRawChar();
			_header.SweptSolidWidth = _reader.ReadBitDouble();
			_header.SweptSolidHeight = _reader.ReadBitDouble();
			_header.DraftAngleFirstCrossSection = _reader.ReadBitDouble();
			_header.DraftAngleSecondCrossSection = _reader.ReadBitDouble();
			_header.DraftMagnitudeFirstCrossSection = _reader.ReadBitDouble();
			_header.DraftMagnitudeSecondCrossSection = _reader.ReadBitDouble();
			_header.SolidLoftedShape = _reader.ReadBitShort();
			_header.LoftedObjectNormals = _reader.ReadRawChar();
			_header.Latitude = _reader.ReadBitDouble();
			_header.Longitude = _reader.ReadBitDouble();
			_header.NorthDirection = _reader.ReadBitDouble();
			_header.TimeZone = _reader.ReadBitLong();
			_header.DisplayLightGlyphs = _reader.ReadRawChar();
			_reader.ReadRawChar();
			_header.DwgUnderlayFramesVisibility = _reader.ReadRawChar();
			_header.DgnUnderlayFramesVisibility = _reader.ReadRawChar();
			_reader.ReadBit();
			_header.InterfereColor = _reader.ReadCmColor();
			objectPointers.INTERFEREOBJVS = _reader.HandleReference();
			objectPointers.INTERFEREVPVS = _reader.HandleReference();
			objectPointers.DRAGVS = _reader.HandleReference();
			_header.ShadowMode = (ACadSharp.Header.ShadowMode)_reader.ReadByte();
			_header.ShadowPlaneLocation = _reader.ReadBitDouble();
		}
		try
		{
			reader.SetPositionInBits(num2 + num * 8);
			reader.ResetShift();
			checkSentinel(_reader, DwgSectionDefinition.EndSentinels[SectionName]);
		}
		catch (Exception ex)
		{
			notify("An error ocurred at the end of the Header reading", NotificationType.Error, ex);
		}
	}
}
