using System.IO;
using System.Text;
using ACadSharp.Header;
using ACadSharp.Tables;
using ACadSharp.Types.Units;
using CSUtilities.IO;

namespace ACadSharp.IO.DWG;

internal class DwgHeaderWriter : DwgSectionIO
{
	private MemoryStream _msmain;

	private IDwgStreamWriter _startWriter;

	private IDwgStreamWriter _writer;

	private CadDocument _document;

	private CadHeader _header;

	private Encoding _encoding;

	public override string SectionName => "AcDb:Header";

	public DwgHeaderWriter(Stream stream, CadDocument document, Encoding encoding)
		: base(document.Header.Version)
	{
		_document = document;
		_header = document.Header;
		_encoding = encoding;
		_startWriter = DwgStreamWriterBase.GetStreamWriter(_version, stream, _encoding);
		_msmain = new MemoryStream();
		_writer = DwgStreamWriterBase.GetStreamWriter(_version, _msmain, _encoding);
	}

	public void Write()
	{
		if (R2007Plus)
		{
			_writer = DwgStreamWriterBase.GetMergedWriter(_version, _msmain, _encoding);
			_writer.SavePositonForSize();
		}
		if (R2013Plus)
		{
			_writer.WriteBitLongLong(0L);
		}
		_writer.WriteBitDouble(412148564080.0);
		_writer.WriteBitDouble(1.0);
		_writer.WriteBitDouble(1.0);
		_writer.WriteBitDouble(1.0);
		_writer.WriteVariableText("m");
		_writer.WriteVariableText(string.Empty);
		_writer.WriteVariableText(string.Empty);
		_writer.WriteVariableText(string.Empty);
		_writer.WriteBitLong(24);
		_writer.WriteBitLong(0);
		if (R13_14Only)
		{
			_writer.WriteBitShort(0);
		}
		if (R2004Pre)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
		}
		_writer.WriteBit(_header.AssociatedDimensions);
		_writer.WriteBit(_header.UpdateDimensionsWhileDragging);
		if (R13_14Only)
		{
			_writer.WriteBit(_header.DIMSAV);
		}
		_writer.WriteBit(_header.PolylineLineTypeGeneration);
		_writer.WriteBit(_header.OrthoMode);
		_writer.WriteBit(_header.RegenerationMode);
		_writer.WriteBit(_header.FillMode);
		_writer.WriteBit(_header.QuickTextMode);
		_writer.WriteBit(_header.PaperSpaceLineTypeScaling == SpaceLineTypeScaling.Normal);
		_writer.WriteBit(_header.LimitCheckingOn);
		if (R13_14Only)
		{
			_writer.WriteBit(_header.BlipMode);
		}
		if (R2004Plus)
		{
			_writer.WriteBit(value: false);
		}
		_writer.WriteBit(_header.UserTimer);
		_writer.WriteBit(_header.SketchPolylines);
		_writer.WriteBit(_header.AngularDirection != AngularDirection.CounterClockWise);
		_writer.WriteBit(_header.ShowSplineControlPoints);
		if (R13_14Only)
		{
			_writer.WriteBit(value: false);
			_writer.WriteBit(value: false);
		}
		_writer.WriteBit(_header.MirrorText);
		_writer.WriteBit(_header.WorldView);
		if (R13_14Only)
		{
			_writer.WriteBit(value: false);
		}
		_writer.WriteBit(_header.ShowModelSpace);
		_writer.WriteBit(_header.PaperSpaceLimitsChecking);
		_writer.WriteBit(_header.RetainXRefDependentVisibilitySettings);
		if (R13_14Only)
		{
			_writer.WriteBit(value: false);
		}
		_writer.WriteBit(_header.DisplaySilhouetteCurves);
		_writer.WriteBit(_header.CreateEllipseAsPolyline);
		_writer.WriteBitShort(_header.ProxyGraphics ? ((short)1) : ((short)0));
		if (R13_14Only)
		{
			_writer.WriteBitShort(0);
		}
		_writer.WriteBitShort(_header.SpatialIndexMaxTreeDepth);
		_writer.WriteBitShort((short)_header.LinearUnitFormat);
		_writer.WriteBitShort(_header.LinearUnitPrecision);
		_writer.WriteBitShort((short)_header.AngularUnit);
		_writer.WriteBitShort(_header.AngularUnitPrecision);
		if (R13_14Only)
		{
			_writer.WriteBitShort((short)_header.ObjectSnapMode);
		}
		_writer.WriteBitShort((short)_header.AttributeVisibility);
		if (R13_14Only)
		{
			_writer.WriteBitShort(0);
		}
		_writer.WriteBitShort(_header.PointDisplayMode);
		if (R13_14Only)
		{
			_writer.WriteBitShort(0);
		}
		if (R2004Plus)
		{
			_writer.WriteBitLong(0);
			_writer.WriteBitLong(0);
			_writer.WriteBitLong(0);
		}
		_writer.WriteBitShort(_header.UserShort1);
		_writer.WriteBitShort(_header.UserShort2);
		_writer.WriteBitShort(_header.UserShort3);
		_writer.WriteBitShort(_header.UserShort4);
		_writer.WriteBitShort(_header.UserShort5);
		_writer.WriteBitShort(_header.NumberOfSplineSegments);
		_writer.WriteBitShort(_header.SurfaceDensityU);
		_writer.WriteBitShort(_header.SurfaceDensityV);
		_writer.WriteBitShort(_header.SurfaceType);
		_writer.WriteBitShort(_header.SurfaceMeshTabulationCount1);
		_writer.WriteBitShort(_header.SurfaceMeshTabulationCount2);
		_writer.WriteBitShort((short)_header.SplineType);
		_writer.WriteBitShort((short)_header.ShadeEdge);
		_writer.WriteBitShort(_header.ShadeDiffuseToAmbientPercentage);
		_writer.WriteBitShort(_header.UnitMode);
		_writer.WriteBitShort(_header.MaxViewportCount);
		_writer.WriteBitShort(_header.SurfaceIsolineCount);
		_writer.WriteBitShort((short)_header.CurrentMultiLineJustification);
		_writer.WriteBitShort(_header.TextQuality);
		_writer.WriteBitDouble(_header.LineTypeScale);
		_writer.WriteBitDouble(_header.TextHeightDefault);
		_writer.WriteBitDouble(_header.TraceWidthDefault);
		_writer.WriteBitDouble(_header.SketchIncrement);
		_writer.WriteBitDouble(_header.FilletRadius);
		_writer.WriteBitDouble(_header.ThicknessDefault);
		_writer.WriteBitDouble(_header.AngleBase);
		_writer.WriteBitDouble(_header.PointDisplaySize);
		_writer.WriteBitDouble(_header.PolylineWidthDefault);
		_writer.WriteBitDouble(_header.UserDouble1);
		_writer.WriteBitDouble(_header.UserDouble2);
		_writer.WriteBitDouble(_header.UserDouble3);
		_writer.WriteBitDouble(_header.UserDouble4);
		_writer.WriteBitDouble(_header.UserDouble5);
		_writer.WriteBitDouble(_header.ChamferDistance1);
		_writer.WriteBitDouble(_header.ChamferDistance2);
		_writer.WriteBitDouble(_header.ChamferLength);
		_writer.WriteBitDouble(_header.ChamferAngle);
		_writer.WriteBitDouble(_header.FacetResolution);
		_writer.WriteBitDouble(_header.CurrentMultilineScale);
		_writer.WriteBitDouble(_header.CurrentEntityLinetypeScale);
		_writer.WriteVariableText(_header.MenuFileName);
		_writer.WriteDateTime(_header.CreateDateTime);
		_writer.WriteDateTime(_header.UpdateDateTime);
		if (R2004Plus)
		{
			_writer.WriteBitLong(0);
			_writer.WriteBitLong(0);
			_writer.WriteBitLong(0);
		}
		_writer.WriteTimeSpan(_header.TotalEditingTime);
		_writer.WriteTimeSpan(_header.UserElapsedTimeSpan);
		_writer.WriteCmColor(_header.CurrentEntityColor);
		_writer.Main.HandleReference(_header.HandleSeed);
		_writer.HandleReference(DwgReferenceType.HardPointer, _header.CurrentLayer);
		_writer.HandleReference(DwgReferenceType.HardPointer, _header.CurrentTextStyle);
		_writer.HandleReference(DwgReferenceType.HardPointer, _header.CurrentLineType);
		if (R2007Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, _header.CurrentDimensionStyle);
		_writer.HandleReference(DwgReferenceType.HardPointer, _header.CurrentMLineStyle);
		if (R2000Plus)
		{
			_writer.WriteBitDouble(_header.ViewportDefaultViewScaleFactor);
		}
		_writer.Write3BitDouble(_header.PaperSpaceInsertionBase);
		_writer.Write3BitDouble(_header.PaperSpaceExtMin);
		_writer.Write3BitDouble(_header.PaperSpaceExtMax);
		_writer.Write2RawDouble(_header.PaperSpaceLimitsMin);
		_writer.Write2RawDouble(_header.PaperSpaceLimitsMax);
		_writer.WriteBitDouble(_header.PaperSpaceElevation);
		_writer.Write3BitDouble(_header.PaperSpaceUcsOrigin);
		_writer.Write3BitDouble(_header.PaperSpaceUcsXAxis);
		_writer.Write3BitDouble(_header.PaperSpaceUcsYAxis);
		_writer.HandleReference(DwgReferenceType.HardPointer, _header.PaperSpaceUcs);
		if (R2000Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.WriteBitShort(0);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.Write3BitDouble(_header.PaperSpaceOrthographicTopDOrigin);
			_writer.Write3BitDouble(_header.PaperSpaceOrthographicBottomDOrigin);
			_writer.Write3BitDouble(_header.PaperSpaceOrthographicLeftDOrigin);
			_writer.Write3BitDouble(_header.PaperSpaceOrthographicRightDOrigin);
			_writer.Write3BitDouble(_header.PaperSpaceOrthographicFrontDOrigin);
			_writer.Write3BitDouble(_header.PaperSpaceOrthographicBackDOrigin);
		}
		_writer.Write3BitDouble(_header.ModelSpaceInsertionBase);
		_writer.Write3BitDouble(_header.ModelSpaceExtMin);
		_writer.Write3BitDouble(_header.ModelSpaceExtMax);
		_writer.Write2RawDouble(_header.ModelSpaceLimitsMin);
		_writer.Write2RawDouble(_header.ModelSpaceLimitsMax);
		_writer.WriteBitDouble(_header.Elevation);
		_writer.Write3BitDouble(_header.ModelSpaceOrigin);
		_writer.Write3BitDouble(_header.ModelSpaceXAxis);
		_writer.Write3BitDouble(_header.ModelSpaceYAxis);
		_writer.HandleReference(DwgReferenceType.HardPointer, _header.ModelSpaceUcs);
		if (R2000Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.WriteBitShort(0);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.Write3BitDouble(_header.ModelSpaceOrthographicTopDOrigin);
			_writer.Write3BitDouble(_header.ModelSpaceOrthographicBottomDOrigin);
			_writer.Write3BitDouble(_header.ModelSpaceOrthographicLeftDOrigin);
			_writer.Write3BitDouble(_header.ModelSpaceOrthographicRightDOrigin);
			_writer.Write3BitDouble(_header.ModelSpaceOrthographicFrontDOrigin);
			_writer.Write3BitDouble(_header.ModelSpaceOrthographicBackDOrigin);
			_writer.WriteVariableText(_header.DimensionPostFix);
			_writer.WriteVariableText(_header.DimensionAlternateDimensioningSuffix);
		}
		if (R13_14Only)
		{
			_writer.WriteBit(_header.DimensionGenerateTolerances);
			_writer.WriteBit(_header.DimensionLimitsGeneration);
			_writer.WriteBit(_header.DimensionTextInsideHorizontal);
			_writer.WriteBit(_header.DimensionTextOutsideHorizontal);
			_writer.WriteBit(_header.DimensionSuppressFirstExtensionLine);
			_writer.WriteBit(_header.DimensionSuppressSecondExtensionLine);
			_writer.WriteBit(_header.DimensionAlternateUnitDimensioning);
			_writer.WriteBit(_header.DimensionTextOutsideExtensions);
			_writer.WriteBit(_header.DimensionSeparateArrowBlocks);
			_writer.WriteBit(_header.DimensionTextInsideExtensions);
			_writer.WriteBit(_header.DimensionSuppressOutsideExtensions);
			_writer.WriteByte((byte)_header.DimensionAlternateUnitDecimalPlaces);
			_writer.WriteByte((byte)_header.DimensionZeroHandling);
			_writer.WriteBit(_header.DimensionSuppressFirstDimensionLine);
			_writer.WriteBit(_header.DimensionSuppressSecondDimensionLine);
			_writer.WriteByte((byte)_header.DimensionToleranceAlignment);
			_writer.WriteByte((byte)_header.DimensionTextHorizontalAlignment);
			_writer.WriteByte((byte)_header.DimensionFit);
			_writer.WriteBit(_header.DimensionCursorUpdate);
			_writer.WriteByte((byte)_header.DimensionToleranceZeroHandling);
			_writer.WriteByte((byte)_header.DimensionAlternateUnitZeroHandling);
			_writer.WriteByte((byte)_header.DimensionAlternateUnitToleranceZeroHandling);
			_writer.WriteByte((byte)_header.DimensionTextVerticalAlignment);
			_writer.WriteBitShort(_header.DimensionUnit);
			_writer.WriteBitShort(_header.DimensionAngularDimensionDecimalPlaces);
			_writer.WriteBitShort(_header.DimensionDecimalPlaces);
			_writer.WriteBitShort(_header.DimensionToleranceDecimalPlaces);
			_writer.WriteBitShort((short)_header.DimensionAlternateUnitFormat);
			_writer.WriteBitShort(_header.DimensionAlternateUnitToleranceDecimalPlaces);
			_writer.HandleReference(DwgReferenceType.HardPointer, _header.DimensionTextStyle);
		}
		_writer.WriteBitDouble(_header.DimensionScaleFactor);
		_writer.WriteBitDouble(_header.DimensionArrowSize);
		_writer.WriteBitDouble(_header.DimensionExtensionLineOffset);
		_writer.WriteBitDouble(_header.DimensionLineIncrement);
		_writer.WriteBitDouble(_header.DimensionExtensionLineExtension);
		_writer.WriteBitDouble(_header.DimensionRounding);
		_writer.WriteBitDouble(_header.DimensionLineExtension);
		_writer.WriteBitDouble(_header.DimensionPlusTolerance);
		_writer.WriteBitDouble(_header.DimensionMinusTolerance);
		if (R2007Plus)
		{
			_writer.WriteBitDouble(_header.DimensionFixedExtensionLineLength);
			_writer.WriteBitDouble(_header.DimensionJoggedRadiusDimensionTransverseSegmentAngle);
			_writer.WriteBitShort((short)_header.DimensionTextBackgroundFillMode);
			_writer.WriteCmColor(_header.DimensionTextBackgroundColor);
		}
		if (R2000Plus)
		{
			_writer.WriteBit(_header.DimensionGenerateTolerances);
			_writer.WriteBit(_header.DimensionLimitsGeneration);
			_writer.WriteBit(_header.DimensionTextInsideHorizontal);
			_writer.WriteBit(_header.DimensionTextOutsideHorizontal);
			_writer.WriteBit(_header.DimensionSuppressFirstExtensionLine);
			_writer.WriteBit(_header.DimensionSuppressSecondExtensionLine);
			_writer.WriteBitShort((short)_header.DimensionTextVerticalAlignment);
			_writer.WriteBitShort((short)_header.DimensionZeroHandling);
			_writer.WriteBitShort((short)_header.DimensionAngularZeroHandling);
		}
		if (R2007Plus)
		{
			_writer.WriteBitShort((short)_header.DimensionArcLengthSymbolPosition);
		}
		_writer.WriteBitDouble(_header.DimensionTextHeight);
		_writer.WriteBitDouble(_header.DimensionCenterMarkSize);
		_writer.WriteBitDouble(_header.DimensionTickSize);
		_writer.WriteBitDouble(_header.DimensionAlternateUnitScaleFactor);
		_writer.WriteBitDouble(_header.DimensionLinearScaleFactor);
		_writer.WriteBitDouble(_header.DimensionTextVerticalPosition);
		_writer.WriteBitDouble(_header.DimensionToleranceScaleFactor);
		_writer.WriteBitDouble(_header.DimensionLineGap);
		if (R13_14Only)
		{
			_writer.WriteVariableText(_header.DimensionPostFix);
			_writer.WriteVariableText(_header.DimensionAlternateDimensioningSuffix);
			_writer.WriteVariableText(_header.DimensionBlockName);
			_writer.WriteVariableText(_header.DimensionBlockNameFirst);
			_writer.WriteVariableText(_header.DimensionBlockNameSecond);
		}
		if (R2000Plus)
		{
			_writer.WriteBitDouble(_header.DimensionAlternateUnitRounding);
			_writer.WriteBit(_header.DimensionAlternateUnitDimensioning);
			_writer.WriteBitShort(_header.DimensionAlternateUnitDecimalPlaces);
			_writer.WriteBit(_header.DimensionTextOutsideExtensions);
			_writer.WriteBit(_header.DimensionSeparateArrowBlocks);
			_writer.WriteBit(_header.DimensionTextInsideExtensions);
			_writer.WriteBit(_header.DimensionSuppressOutsideExtensions);
		}
		_writer.WriteCmColor(_header.DimensionLineColor);
		_writer.WriteCmColor(_header.DimensionExtensionLineColor);
		_writer.WriteCmColor(_header.DimensionTextColor);
		if (R2000Plus)
		{
			_writer.WriteBitShort(_header.DimensionAngularDimensionDecimalPlaces);
			_writer.WriteBitShort(_header.DimensionDecimalPlaces);
			_writer.WriteBitShort(_header.DimensionToleranceDecimalPlaces);
			_writer.WriteBitShort((short)_header.DimensionAlternateUnitFormat);
			_writer.WriteBitShort(_header.DimensionAlternateUnitToleranceDecimalPlaces);
			_writer.WriteBitShort((short)_header.DimensionAngularUnit);
			_writer.WriteBitShort((short)_header.DimensionFractionFormat);
			_writer.WriteBitShort((short)_header.DimensionLinearUnitFormat);
			_writer.WriteBitShort((short)_header.DimensionDecimalSeparator);
			_writer.WriteBitShort((short)_header.DimensionTextMovement);
			_writer.WriteBitShort((short)_header.DimensionTextHorizontalAlignment);
			_writer.WriteBit(_header.DimensionSuppressFirstExtensionLine);
			_writer.WriteBit(_header.DimensionSuppressSecondExtensionLine);
			_writer.WriteBitShort((short)_header.DimensionToleranceAlignment);
			_writer.WriteBitShort((short)_header.DimensionToleranceZeroHandling);
			_writer.WriteBitShort((short)_header.DimensionAlternateUnitZeroHandling);
			_writer.WriteBitShort((short)_header.DimensionAlternateUnitToleranceZeroHandling);
			_writer.WriteBit(_header.DimensionCursorUpdate);
			_writer.WriteBitShort((short)_header.DimensionDimensionTextArrowFit);
		}
		if (R2007Plus)
		{
			_writer.WriteBit(_header.DimensionIsExtensionLineLengthFixed);
		}
		if (R2010Plus)
		{
			_writer.WriteBit(_header.DimensionTextDirection == TextDirection.RightToLeft);
			_writer.WriteBitDouble(_header.DimensionAltMzf);
			_writer.WriteVariableText(_header.DimensionAltMzs);
			_writer.WriteBitDouble(_header.DimensionMzf);
			_writer.WriteVariableText(_header.DimensionMzs);
		}
		if (R2000Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, _header.DimensionTextStyle);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
		}
		if (R2007Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
		}
		if (R2000Plus)
		{
			_writer.WriteBitShort((short)_header.DimensionLineWeight);
			_writer.WriteBitShort((short)_header.ExtensionLineWeight);
		}
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.BlockRecords);
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.Layers);
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.TextStyles);
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.LineTypes);
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.Views);
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.UCSs);
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.VPorts);
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.AppIds);
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.DimensionStyles);
		if (R13_15Only)
		{
			_writer.HandleReference(DwgReferenceType.HardOwnership, _document.VEntityControl);
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, _document.Groups);
		_writer.HandleReference(DwgReferenceType.HardPointer, _document.MLineStyles);
		_writer.HandleReference(DwgReferenceType.HardOwnership, _document.RootDictionary);
		if (R2000Plus)
		{
			_writer.WriteBitShort(_header.StackedTextAlignment);
			_writer.WriteBitShort(_header.StackedTextSizePercentage);
			_writer.WriteVariableText(_header.HyperLinkBase);
			_writer.WriteVariableText(_header.StyleSheetName);
			_writer.HandleReference(DwgReferenceType.HardPointer, _document.Layouts);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
		}
		if (R2004Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, _document.Materials);
			_writer.HandleReference(DwgReferenceType.HardPointer, _document.Colors);
		}
		if (R2007Plus)
		{
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			if (R2013Plus)
			{
				_writer.HandleReference(DwgReferenceType.HardPointer, null);
			}
		}
		if (R2000Plus)
		{
			int num = (int)((uint)(_header.CurrentEntityLineWeight & (LineWeightType)31) | (uint)(_header.EndCaps << 5)) | (_header.JoinStyle << 7);
			if (!_header.DisplayLineWeight)
			{
				num |= 0x200;
			}
			if (!_header.XEdit)
			{
				num |= 0x400;
			}
			if (_header.ExtendedNames)
			{
				num |= 0x800;
			}
			if (_header.PlotStyleMode == 1)
			{
				num |= 0x2000;
			}
			if (_header.LoadOLEObject)
			{
				num |= 0x4000;
			}
			_writer.WriteBitLong(num);
			_writer.WriteBitShort((short)_header.InsUnits);
			_writer.WriteBitShort((short)_header.CurrentEntityPlotStyle);
			if (_header.CurrentEntityPlotStyle == EntityPlotStyleType.ByObjectId)
			{
				_writer.HandleReference(DwgReferenceType.HardPointer, null);
			}
			_writer.WriteVariableText(_header.FingerPrintGuid);
			_writer.WriteVariableText(_header.VersionGuid);
		}
		if (R2004Plus)
		{
			_writer.WriteByte((byte)_header.EntitySortingFlags);
			_writer.WriteByte((byte)_header.IndexCreationFlags);
			_writer.WriteByte(_header.HideText);
			_writer.WriteByte((byte)_header.ExternalReferenceClippingBoundaryType);
			_writer.WriteByte((byte)_header.DimensionAssociativity);
			_writer.WriteByte(_header.HaloGapPercentage);
			_writer.WriteBitShort(_header.ObscuredColor.Index);
			_writer.WriteBitShort(_header.InterfereColor.Index);
			_writer.WriteByte(_header.ObscuredType);
			_writer.WriteByte(_header.IntersectionDisplay);
			_writer.WriteVariableText(_header.ProjectName);
		}
		_writer.HandleReference(DwgReferenceType.HardPointer, _document.PaperSpace);
		_writer.HandleReference(DwgReferenceType.HardPointer, _document.ModelSpace);
		_writer.HandleReference(DwgReferenceType.HardPointer, _document.LineTypes["ByLayer"]);
		_writer.HandleReference(DwgReferenceType.HardPointer, _document.LineTypes["ByBlock"]);
		_writer.HandleReference(DwgReferenceType.HardPointer, _document.LineTypes["Continuous"]);
		if (R2007Plus)
		{
			_writer.WriteBit(_header.CameraDisplayObjects);
			_writer.WriteBitLong(0);
			_writer.WriteBitLong(0);
			_writer.WriteBitDouble(0.0);
			_writer.WriteBitDouble(_header.StepsPerSecond);
			_writer.WriteBitDouble(_header.StepSize);
			_writer.WriteBitDouble(_header.Dw3DPrecision);
			_writer.WriteBitDouble(_header.LensLength);
			_writer.WriteBitDouble(_header.CameraHeight);
			_writer.WriteByte((byte)_header.SolidsRetainHistory);
			_writer.WriteByte((byte)_header.ShowSolidsHistory);
			_writer.WriteBitDouble(_header.SweptSolidWidth);
			_writer.WriteBitDouble(_header.SweptSolidHeight);
			_writer.WriteBitDouble(_header.DraftAngleFirstCrossSection);
			_writer.WriteBitDouble(_header.DraftAngleSecondCrossSection);
			_writer.WriteBitDouble(_header.DraftMagnitudeFirstCrossSection);
			_writer.WriteBitDouble(_header.DraftMagnitudeSecondCrossSection);
			_writer.WriteBitShort(_header.SolidLoftedShape);
			_writer.WriteByte((byte)_header.LoftedObjectNormals);
			_writer.WriteBitDouble(_header.Latitude);
			_writer.WriteBitDouble(_header.Longitude);
			_writer.WriteBitDouble(_header.NorthDirection);
			_writer.WriteBitLong(_header.TimeZone);
			_writer.WriteByte((byte)_header.DisplayLightGlyphs);
			_writer.WriteByte(48);
			_writer.WriteByte((byte)_header.DwgUnderlayFramesVisibility);
			_writer.WriteByte((byte)_header.DgnUnderlayFramesVisibility);
			_writer.WriteBit(value: false);
			_writer.WriteCmColor(_header.InterfereColor);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.HandleReference(DwgReferenceType.HardPointer, null);
			_writer.WriteByte((byte)_header.ShadowMode);
			_writer.WriteBitDouble(_header.ShadowPlaneLocation);
		}
		if (_header.Version >= ACadVersion.AC1014)
		{
			_writer.WriteBitShort(-1);
			_writer.WriteBitShort(-1);
			_writer.WriteBitShort(-1);
			_writer.WriteBitShort(-1);
			if (R2004Plus)
			{
				_writer.WriteBitLong(0);
				_writer.WriteBitLong(0);
				_writer.WriteBit(value: false);
			}
		}
		_writer.WriteSpearShift();
		writeSizeAndCrc();
	}

	private void writeSizeAndCrc()
	{
		_startWriter.WriteBytes(DwgSectionDefinition.StartSentinels[SectionName]);
		CRC8StreamHandler cRC8StreamHandler = new CRC8StreamHandler(_startWriter.Stream, 49345);
		StreamIO streamIO = new StreamIO(cRC8StreamHandler);
		streamIO.Write((int)_msmain.Length);
		if ((R2010Plus && _header.MaintenanceVersion > 3) || R2018Plus)
		{
			streamIO.Write(0);
		}
		cRC8StreamHandler.Write(_msmain.GetBuffer(), 0, (int)_msmain.Length);
		streamIO.Write(cRC8StreamHandler.Seed);
		_startWriter.WriteBytes(DwgSectionDefinition.EndSentinels[SectionName]);
	}
}
