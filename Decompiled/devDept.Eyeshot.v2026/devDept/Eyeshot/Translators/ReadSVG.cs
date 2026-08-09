using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using Svg;
using Svg.Pathing;
using Svg.Transforms;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot.Translators;

public class ReadSVG : ReadFileAsync
{
	private struct _0023_003Dzx8YZKPmLAeYF
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzNDS6jIw_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzOhdXIPc_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzE_ndlS0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzIF7r58xFqhSE;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dz9XMxeHE_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzCf2ipjo_003D;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Transformation _0023_003DzgrdBZwSxLcb6;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<Entity> _0023_003DzL8I2gwbuUxst = new List<Entity>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003Dz0oWF3nmeTYsu;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DzJ02lS936CkU0;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private PointF _0023_003DzbgFSTv8HRsq_;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly PointF _0023_003DzH5c4Uv8_003D = new PointF(0f, 0f);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Dictionary<string, Color> _0023_003DzbsM7Ih2x1AsgAnSbnA_003D_003D = new Dictionary<string, Color>();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzTSzZIbz0wrQLe7FfVFkZTO6CAsO4;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private int _0023_003DziFY829JRTpWBtDZkIg_003D_003D;

	public override supportedLinearUnitsType SupportedLinearUnitsType => supportedLinearUnitsType.All;

	public bool AsCurves
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzTSzZIbz0wrQLe7FfVFkZTO6CAsO4;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzTSzZIbz0wrQLe7FfVFkZTO6CAsO4 = value;
		}
	}

	public ReadSVG(string fileName)
		: base(fileName)
	{
	}

	public ReadSVG(Stream stream)
		: base(stream)
	{
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 2;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		_0023_003DzqAdY7jsbOuGN(progress, ct);
	}

	private void _0023_003DzqAdY7jsbOuGN(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		base.Result = false;
		_0023_003DzgrdBZwSxLcb6 = Transformation.CreateReflection(Plane.ZX);
		try
		{
			_0023_003DzqAdY7jsbOuGN(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, out var _0023_003DzWc9WmS8VMsuA);
			base.Entities.AddRange(_0023_003DzWc9WmS8VMsuA);
			UpdateProgressTo100(base.ParsingText, _0023_003DzmHS7frs_003D);
			base.Result = true;
		}
		catch (Exception ex)
		{
			log.AppendLine(ex.Message);
			log.AppendLine();
		}
		finally
		{
			CloseStream();
		}
	}

	private void _0023_003DzqAdY7jsbOuGN(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D, out Entity[] _0023_003DzWc9WmS8VMsuA)
	{
		StreamReader streamReader = new StreamReader(base.Stream, Encoding.UTF8);
		string svg;
		try
		{
			svg = streamReader.ReadToEnd();
		}
		finally
		{
			((IDisposable)streamReader).Dispose();
		}
		SvgDocument svgDocument = SvgDocument.FromSvg<SvgDocument>(svg);
		_0023_003DzWj6HNtM_003D(svgDocument);
		_0023_003DziBGiZoYivgSs(svgDocument, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		_0023_003DzL8I2gwbuUxst.Reverse();
		_0023_003DzWc9WmS8VMsuA = _0023_003DzL8I2gwbuUxst.ToArray();
	}

	private void _0023_003DzWj6HNtM_003D(SvgElement _0023_003DzbfrNXYE_003D)
	{
		if (_0023_003DzbfrNXYE_003D is SvgPath svgPath)
		{
			_0023_003Dz0oWF3nmeTYsu += svgPath.PathData.Count;
		}
		foreach (SvgElement child in _0023_003DzbfrNXYE_003D.Children)
		{
			_0023_003DzWj6HNtM_003D(child);
		}
	}

	private void _0023_003DziBGiZoYivgSs(SvgElement _0023_003Dz9j4kMjs_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		if (_0023_003Dz9j4kMjs_003D is SvgGradientServer svgGradientServer)
		{
			Color value = ((SvgColourServer)svgGradientServer.StopColor).Colour;
			if (svgGradientServer.Stops.Count > 0)
			{
				Color colour = ((SvgColourServer)svgGradientServer.Stops[0].StopColor).Colour;
				if (colour.ToArgb() != Color.White.ToArgb() && colour.ToArgb() != Color.Black.ToArgb())
				{
					value = colour;
					value = Color.FromArgb((int)svgGradientServer.Stops[0].StopOpacity * 255, value);
				}
				else
				{
					value = ((SvgColourServer)svgGradientServer.Stops[1].StopColor).Colour;
					value = Color.FromArgb((int)svgGradientServer.Stops[1].StopOpacity * 255, value);
				}
			}
			_0023_003DzbsM7Ih2x1AsgAnSbnA_003D_003D.Add(svgGradientServer.ID, value);
			return;
		}
		if (_0023_003Dz9j4kMjs_003D != null && !(_0023_003Dz9j4kMjs_003D is SvgGroup) && !(_0023_003Dz9j4kMjs_003D is SvgDocument) && !(_0023_003Dz9j4kMjs_003D is SvgDocumentMetadata) && !(_0023_003Dz9j4kMjs_003D is NonSvgElement))
		{
			Entity[] array = _0023_003DzdcBT_00249s_003D(_0023_003Dz9j4kMjs_003D);
			foreach (Entity entity in array)
			{
				if (!string.IsNullOrEmpty(_0023_003Dz9j4kMjs_003D.ID))
				{
					entity.TranslationID = new TranslationIdentifier(_0023_003Dz9j4kMjs_003D.ID);
				}
				entity.TransformBy(_0023_003DzgrdBZwSxLcb6);
				if (entity is Hatch hatch)
				{
					hatch.Plane.Flip();
					foreach (ICurve contour in hatch.ContourList)
					{
						contour.Reverse();
					}
				}
				_0023_003DzL8I2gwbuUxst.Add(entity);
				if (_0023_003DzmHS7frs_003D != null && !UpdateProgressAndCheckCancelled(Math.Min(_0023_003DzJ02lS936CkU0, _0023_003Dz0oWF3nmeTYsu), _0023_003Dz0oWF3nmeTYsu, base.ParsingText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					return;
				}
			}
		}
		if (_0023_003Dz9j4kMjs_003D == null)
		{
			return;
		}
		foreach (SvgElement child in _0023_003Dz9j4kMjs_003D.Children)
		{
			_0023_003DziBGiZoYivgSs(child, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		}
	}

	private Entity[] _0023_003DzdcBT_00249s_003D(SvgElement _0023_003Dz9j4kMjs_003D)
	{
		if (!(_0023_003Dz9j4kMjs_003D is SvgLine svgLine))
		{
			if (!(_0023_003Dz9j4kMjs_003D is SvgCircle svgCircle))
			{
				if (!(_0023_003Dz9j4kMjs_003D is SvgEllipse svgEllipse))
				{
					if (!(_0023_003Dz9j4kMjs_003D is SvgRectangle svgRectangle))
					{
						if (!(_0023_003Dz9j4kMjs_003D is SvgPolyline svgPolyline))
						{
							if (!(_0023_003Dz9j4kMjs_003D is SvgPolygon svgPolygon))
							{
								if (!(_0023_003Dz9j4kMjs_003D is SvgPath svgPath))
								{
									if (!(_0023_003Dz9j4kMjs_003D is SvgMarkerElement) && _0023_003Dz9j4kMjs_003D is SvgPathBasedElement)
									{
									}
								}
								else
								{
									List<ICurve> list = new List<ICurve>();
									List<ICurve> list2 = new List<ICurve>();
									SvgPathSegmentList pathData = svgPath.PathData;
									_0023_003DzbgFSTv8HRsq_ = _0023_003DzH5c4Uv8_003D;
									foreach (SvgPathSegment item in pathData)
									{
										_0023_003DzJ02lS936CkU0++;
										if (!(item is SvgArcSegment svgArcSegment))
										{
											if (!(item is SvgClosePathSegment))
											{
												if (!(item is SvgCubicCurveSegment svgCubicCurveSegment))
												{
													if (!(item is SvgLineSegment svgLineSegment))
													{
														if (!(item is SvgMoveToSegment svgMoveToSegment))
														{
															if (item is SvgQuadraticCurveSegment svgQuadraticCurveSegment)
															{
																PointF pointF = _0023_003DzbgFSTv8HRsq_;
																PointF pointF2 = _0023_003Dz2guaEgY_003D(svgQuadraticCurveSegment.End, svgQuadraticCurveSegment.IsRelative, _0023_003DzbgFSTv8HRsq_);
																PointF pointF3 = _0023_003Dz2guaEgY_003D(svgQuadraticCurveSegment.ControlPoint, svgQuadraticCurveSegment.IsRelative, _0023_003DzbgFSTv8HRsq_);
																_0023_003DzbgFSTv8HRsq_ = pointF2;
																Point4D point4D = new Point4D(pointF.X, pointF.Y, _0023_003DziFY829JRTpWBtDZkIg_003D_003D, 1.0);
																Point4D point4D2 = new Point4D(pointF2.X, pointF2.Y, _0023_003DziFY829JRTpWBtDZkIg_003D_003D, 1.0);
																Point4D point4D3 = new Point4D(pointF3.X, pointF3.Y, _0023_003DziFY829JRTpWBtDZkIg_003D_003D, 1.0);
																Curve curve = new Curve(2, point4D, point4D3, point4D2);
																_0023_003DzObiA4KxRU64y(curve, _0023_003Dz9j4kMjs_003D);
																list2.Add(curve);
															}
														}
														else
														{
															_0023_003DzbgFSTv8HRsq_ = _0023_003Dz2guaEgY_003D(svgMoveToSegment.End, svgMoveToSegment.IsRelative, _0023_003DzbgFSTv8HRsq_);
															if (list2.Count > 0)
															{
																list.Add(Utility.SmartAdd(list2));
																list2.Clear();
															}
														}
													}
													else
													{
														PointF pointF4 = _0023_003DzH5c4Uv8_003D;
														pointF4 = _0023_003DzbgFSTv8HRsq_;
														PointF end = svgLineSegment.End;
														if (float.IsNaN(end.Y))
														{
															end.Y = ((!svgLineSegment.IsRelative) ? _0023_003DzbgFSTv8HRsq_.Y : 0f);
														}
														else if (float.IsNaN(end.X))
														{
															end.X = ((!svgLineSegment.IsRelative) ? _0023_003DzbgFSTv8HRsq_.X : 0f);
														}
														end = (_0023_003DzbgFSTv8HRsq_ = _0023_003Dz2guaEgY_003D(end, svgLineSegment.IsRelative, _0023_003DzbgFSTv8HRsq_));
														Line line = new Line(new Point3D(pointF4.X, pointF4.Y, _0023_003DziFY829JRTpWBtDZkIg_003D_003D), new Point3D(end.X, end.Y, _0023_003DziFY829JRTpWBtDZkIg_003D_003D));
														_0023_003DzObiA4KxRU64y(line, _0023_003Dz9j4kMjs_003D);
														list2.Add(line);
													}
												}
												else
												{
													PointF pointF5 = _0023_003DzH5c4Uv8_003D;
													pointF5 = _0023_003DzbgFSTv8HRsq_;
													PointF pointF6 = _0023_003Dz2guaEgY_003D(svgCubicCurveSegment.End, svgCubicCurveSegment.IsRelative, _0023_003DzbgFSTv8HRsq_);
													PointF pointF7 = _0023_003Dz2guaEgY_003D(svgCubicCurveSegment.FirstControlPoint, svgCubicCurveSegment.IsRelative, _0023_003DzbgFSTv8HRsq_);
													PointF pointF8 = _0023_003Dz2guaEgY_003D(svgCubicCurveSegment.SecondControlPoint, svgCubicCurveSegment.IsRelative, _0023_003DzbgFSTv8HRsq_);
													_0023_003DzbgFSTv8HRsq_ = pointF6;
													Point4D point4D4 = new Point4D(pointF5.X, pointF5.Y, _0023_003DziFY829JRTpWBtDZkIg_003D_003D, 1.0);
													Point4D point4D5 = new Point4D(pointF6.X, pointF6.Y, _0023_003DziFY829JRTpWBtDZkIg_003D_003D, 1.0);
													Point4D point4D6 = new Point4D(pointF7.X, pointF7.Y, _0023_003DziFY829JRTpWBtDZkIg_003D_003D, 1.0);
													Point4D point4D7 = new Point4D(pointF8.X, pointF8.Y, _0023_003DziFY829JRTpWBtDZkIg_003D_003D, 1.0);
													Curve curve2 = new Curve(3, point4D4, point4D6, point4D7, point4D5);
													_0023_003DzObiA4KxRU64y(curve2, _0023_003Dz9j4kMjs_003D);
													list2.Add(curve2);
												}
											}
											else if (list2.Count > 1)
											{
												ICurve curve3 = Utility.SmartAdd(list2);
												if (!_0023_003DzySfSteI_003D(curve3) && curve3 is CompositeCurve compositeCurve)
												{
													compositeCurve.CurveList.Add(new Line((Point3D)compositeCurve.EndPoint.Clone(), (Point3D)compositeCurve.StartPoint.Clone()));
												}
												list.Add(curve3);
												list2.Clear();
											}
										}
										else
										{
											_0023_003Dzx8YZKPmLAeYF _0023_003Dzx8YZKPmLAeYF2 = _0023_003DzJ5wDyvaZ3OZJ(svgArcSegment);
											ICurve curve4 = new EllipticalArc(new Point3D(_0023_003Dzx8YZKPmLAeYF2._0023_003DzNDS6jIw_003D, _0023_003Dzx8YZKPmLAeYF2._0023_003DzOhdXIPc_003D, _0023_003DziFY829JRTpWBtDZkIg_003D_003D), svgArcSegment.RadiusX, svgArcSegment.RadiusY, _0023_003Dzx8YZKPmLAeYF2._0023_003DzE_ndlS0_003D, _0023_003Dzx8YZKPmLAeYF2._0023_003Dz9XMxeHE_003D);
											((Entity)curve4).Rotate(Utility.DegToRad(svgArcSegment.Angle), Vector3D.AxisZ, new Point3D(_0023_003Dzx8YZKPmLAeYF2._0023_003DzNDS6jIw_003D, _0023_003Dzx8YZKPmLAeYF2._0023_003DzOhdXIPc_003D));
											_0023_003DzObiA4KxRU64y(curve4, _0023_003Dz9j4kMjs_003D);
											list2.Add(curve4);
										}
									}
									if (list2.Count > 0 && list.Count == 0)
									{
										_0023_003DzP5CaOSO1MYbkMlg1bQ_003D_003D(list2, _0023_003Dz9j4kMjs_003D);
										Entity entity = (Entity)Utility.SmartAdd(list2);
										_0023_003Dz1vSOddiQA6e7(entity, svgPath);
										return new Entity[1] { entity };
									}
									if (list.Count > 0)
									{
										if (list2.Count > 0)
										{
											list.Add(Utility.SmartAdd(list2));
											list2.Clear();
										}
										return _0023_003DzdsVE0m1k6jgcFCogUA_003D_003D(list, svgPath, _0023_003Dz9j4kMjs_003D);
									}
								}
							}
							else
							{
								int count = svgPolygon.Points.Count;
								if (count > 3)
								{
									List<Point3D> list3 = new List<Point3D>(count);
									for (int i = 0; i < count; i += 2)
									{
										list3.Add(new Point3D((float)svgPolygon.Points[i], (float)svgPolygon.Points[i + 1], _0023_003DziFY829JRTpWBtDZkIg_003D_003D));
									}
									if (list3[0] != list3[list3.Count - 1])
									{
										list3.Add(list3[0].Clone() as Point3D);
									}
									LinearPath linearPath = new LinearPath(list3);
									_0023_003DzObiA4KxRU64y(linearPath, svgPolygon);
									if (linearPath.IsOrientedClockwise(Plane.XY))
									{
										linearPath.Reverse();
									}
									if (AsCurves || (svgPolygon.Fill != null && svgPolygon.Fill.ToString() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011738)))
									{
										_0023_003DzBENh13r1Rf6U(linearPath, svgPolygon);
										return new Entity[1] { linearPath };
									}
									Hatch hatch = new Hatch(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485), linearPath);
									_0023_003Dz1vSOddiQA6e7(hatch, svgPolygon);
									return new Entity[1] { hatch };
								}
							}
							return new Entity[0];
						}
						List<Point3D> list4 = new List<Point3D>();
						for (int j = 0; j < svgPolyline.Points.Count; j += 2)
						{
							list4.Add(new Point3D((float)svgPolyline.Points[j], (float)svgPolyline.Points[j + 1], _0023_003DziFY829JRTpWBtDZkIg_003D_003D));
						}
						LinearPath linearPath2 = new LinearPath(list4);
						_0023_003DzObiA4KxRU64y(linearPath2, _0023_003Dz9j4kMjs_003D);
						_0023_003DzBENh13r1Rf6U(linearPath2, svgPolyline);
						return new Entity[1] { linearPath2 };
					}
					CompositeCurve compositeCurve2 = ((svgRectangle.CornerRadiusX == 0f && svgRectangle.CornerRadiusY == 0f) ? CompositeCurve.CreateRectangle((float)svgRectangle.X, (float)svgRectangle.Y, (float)svgRectangle.Width, (float)svgRectangle.Height) : ((!(svgRectangle.CornerRadiusX == svgRectangle.CornerRadiusY)) ? CompositeCurve.CreateRectangle(svgRectangle.Bounds.X, svgRectangle.Bounds.Y, (float)svgRectangle.Width, (float)svgRectangle.Height) : CompositeCurve.CreateRoundedRectangle((float)svgRectangle.X, (float)svgRectangle.Y, (float)svgRectangle.Width, (float)svgRectangle.Height, (float)svgRectangle.CornerRadiusX)));
					_0023_003DzObiA4KxRU64y(compositeCurve2, _0023_003Dz9j4kMjs_003D);
					if (svgRectangle.Fill != null && svgRectangle.Fill.ToString() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011738))
					{
						_0023_003DzBENh13r1Rf6U(compositeCurve2, svgRectangle);
						return new Entity[1] { compositeCurve2 };
					}
					Hatch hatch2 = new Hatch(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485), compositeCurve2.CurveList);
					_0023_003Dz1vSOddiQA6e7(hatch2, svgRectangle);
					return new Entity[1] { hatch2 };
				}
				Ellipse ellipse = new Ellipse(new Point3D((float)svgEllipse.CenterX, (float)svgEllipse.CenterY, _0023_003DziFY829JRTpWBtDZkIg_003D_003D), (float)svgEllipse.RadiusX, (float)svgEllipse.RadiusY);
				_0023_003DzObiA4KxRU64y(ellipse, _0023_003Dz9j4kMjs_003D);
				if (svgEllipse.Fill != null && svgEllipse.Fill.ToString() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011738))
				{
					_0023_003DzBENh13r1Rf6U(ellipse, svgEllipse);
					return new Entity[1] { ellipse };
				}
				Hatch hatch3 = new Hatch(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485), ellipse);
				_0023_003Dz1vSOddiQA6e7(hatch3, svgEllipse);
				return new Entity[1] { hatch3 };
			}
			Circle circle = new Circle(new Point3D((float)svgCircle.CenterX, (float)svgCircle.CenterY, _0023_003DziFY829JRTpWBtDZkIg_003D_003D), (float)svgCircle.Radius);
			_0023_003DzObiA4KxRU64y(circle, _0023_003Dz9j4kMjs_003D);
			if (svgCircle.Fill != null && svgCircle.Fill.ToString() == _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011738))
			{
				_0023_003DzBENh13r1Rf6U(circle, svgCircle);
				return new Entity[1] { circle };
			}
			Hatch hatch4 = new Hatch(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485), circle, Plane.XY);
			_0023_003Dz1vSOddiQA6e7(hatch4, svgCircle);
			return new Entity[1] { hatch4 };
		}
		Line line2 = new Line(new Point3D((float)svgLine.StartX, (float)svgLine.StartY, _0023_003DziFY829JRTpWBtDZkIg_003D_003D), new Point3D((float)svgLine.EndX, (float)svgLine.EndY, _0023_003DziFY829JRTpWBtDZkIg_003D_003D));
		_0023_003DzObiA4KxRU64y(line2, _0023_003Dz9j4kMjs_003D);
		_0023_003DzBENh13r1Rf6U(line2, svgLine);
		return new Entity[1] { line2 };
	}

	private static void _0023_003DzBENh13r1Rf6U(Entity _0023_003Dzs_0024uS8LA_003D, SvgElement _0023_003Dzvkg7MYfZzEeF)
	{
		if (_0023_003Dzvkg7MYfZzEeF.Stroke != null && _0023_003Dzvkg7MYfZzEeF.Stroke.ToString() != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011738))
		{
			_0023_003Dzs_0024uS8LA_003D.ColorMethod = colorMethodType.byEntity;
			Color colour = ((SvgColourServer)_0023_003Dzvkg7MYfZzEeF.Stroke).Colour;
			colour = Color.FromArgb((int)((SvgColourServer)_0023_003Dzvkg7MYfZzEeF.Stroke).Opacity * 255, colour);
			_0023_003Dzs_0024uS8LA_003D.Color = colour;
			_0023_003Dzs_0024uS8LA_003D.LineWeightMethod = colorMethodType.byEntity;
			_0023_003Dzs_0024uS8LA_003D.LineWeight = _0023_003Dzvkg7MYfZzEeF.StrokeWidth;
		}
	}

	private void _0023_003Dz1vSOddiQA6e7(Entity _0023_003Dzs_0024uS8LA_003D, SvgElement _0023_003Dzvkg7MYfZzEeF)
	{
		if (_0023_003Dzvkg7MYfZzEeF.Fill != null && _0023_003Dzvkg7MYfZzEeF.Fill.ToString() != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011738))
		{
			_0023_003Dzs_0024uS8LA_003D.ColorMethod = colorMethodType.byEntity;
			_0023_003Dzs_0024uS8LA_003D.Color = _0023_003Dz_8C3BH8_003D(_0023_003Dzvkg7MYfZzEeF);
		}
	}

	private Color _0023_003Dz_8C3BH8_003D(SvgElement _0023_003Dzvkg7MYfZzEeF)
	{
		if (_0023_003Dzvkg7MYfZzEeF.Fill is SvgDeferredPaintServer svgDeferredPaintServer)
		{
			int num = svgDeferredPaintServer.DeferredId.IndexOf('#') + 1;
			int num2 = svgDeferredPaintServer.DeferredId.LastIndexOf('"');
			return _0023_003DzbsM7Ih2x1AsgAnSbnA_003D_003D[svgDeferredPaintServer.DeferredId.Substring(num, num2 - num)];
		}
		Color colour = ((SvgColourServer)_0023_003Dzvkg7MYfZzEeF.Fill).Colour;
		return Color.FromArgb((int)(_0023_003Dzvkg7MYfZzEeF.FillOpacity * 255f), colour);
	}

	private Entity[] _0023_003DzdsVE0m1k6jgcFCogUA_003D_003D(List<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, SvgPath _0023_003Dz_aJrdOozr7PQ, SvgElement _0023_003Dz9j4kMjs_003D)
	{
		_0023_003DzP5CaOSO1MYbkMlg1bQ_003D_003D(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, _0023_003Dz9j4kMjs_003D);
		if (!AsCurves && _0023_003Dz9j4kMjs_003D.Fill.ToString() != _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-303011738))
		{
			Hatch hatch = new Hatch(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485), _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, Plane.XY);
			_0023_003Dz1vSOddiQA6e7(hatch, _0023_003Dz_aJrdOozr7PQ);
			return new Entity[1] { hatch };
		}
		foreach (Entity item in _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
		{
			_0023_003Dz1vSOddiQA6e7(item, _0023_003Dz_aJrdOozr7PQ);
		}
		return _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Cast<Entity>().ToArray();
	}

	private void _0023_003DzP5CaOSO1MYbkMlg1bQ_003D_003D(List<ICurve> _0023_003DzTj1oJWREOpXS, SvgElement _0023_003Dz9j4kMjs_003D)
	{
		foreach (ICurve _0023_003DzTj1oJWREOpX in _0023_003DzTj1oJWREOpXS)
		{
			if (_0023_003Dz9j4kMjs_003D.Parent.Transforms != null)
			{
				_0023_003DzObiA4KxRU64y(_0023_003DzTj1oJWREOpX, _0023_003Dz9j4kMjs_003D.Parent);
			}
		}
	}

	private static bool _0023_003DzySfSteI_003D(ICurve _0023_003Dz06A5WivSSyUp)
	{
		Utility.ComputeBoundingBox(((Entity)_0023_003Dz06A5WivSSyUp).EstimateBoundingBox(null, null), out var boxMin, out var boxMax);
		double num = new Size2D(boxMin, boxMax).Diagonal / 1000.0;
		return _0023_003Dz06A5WivSSyUp.StartPoint.DistanceTo(_0023_003Dz06A5WivSSyUp.EndPoint) < num;
	}

	private static PointF _0023_003Dz2guaEgY_003D(PointF _0023_003DzlY77YgY_003D, bool _0023_003DzZIEWk9s_003D, PointF _0023_003DzAqOpw0w_003D)
	{
		if (_0023_003DzZIEWk9s_003D)
		{
			_0023_003DzlY77YgY_003D.X += _0023_003DzAqOpw0w_003D.X;
			_0023_003DzlY77YgY_003D.Y += _0023_003DzAqOpw0w_003D.Y;
		}
		return _0023_003DzlY77YgY_003D;
	}

	private void _0023_003DzObiA4KxRU64y(ICurve _0023_003Dz9j7EUB0_003D, SvgElement _0023_003Dzn0Ppjo8lZLFc)
	{
		if (_0023_003Dzn0Ppjo8lZLFc.Transforms == null || _0023_003Dzn0Ppjo8lZLFc.Transforms.Count == 0)
		{
			return;
		}
		Transformation xform = new Identity();
		foreach (SvgTransform transform in _0023_003Dzn0Ppjo8lZLFc.Transforms)
		{
			System.Drawing.Drawing2D.Matrix matrix = transform.Matrix;
			Transformation transformation = new Transformation();
			transformation.Diagonal(1.0);
			transformation[0, 0] = Convert.ToDouble(matrix.Elements[0]);
			transformation[1, 0] = Convert.ToDouble(matrix.Elements[1]);
			transformation[0, 1] = Convert.ToDouble(matrix.Elements[2]);
			transformation[1, 1] = Convert.ToDouble(matrix.Elements[3]);
			transformation[0, 3] = Convert.ToDouble(matrix.Elements[4]);
			transformation[1, 3] = Convert.ToDouble(matrix.Elements[5]);
			xform *= transformation;
		}
		((Entity)_0023_003Dz9j7EUB0_003D).TransformBy(xform);
	}

	private _0023_003Dzx8YZKPmLAeYF _0023_003DzJ5wDyvaZ3OZJ(SvgArcSegment _0023_003DzL_cOge_00248Ghnr)
	{
		PointF pointF = _0023_003DzH5c4Uv8_003D;
		pointF = _0023_003DzbgFSTv8HRsq_;
		PointF pointF2 = (_0023_003DzbgFSTv8HRsq_ = _0023_003Dz2guaEgY_003D(_0023_003DzL_cOge_00248Ghnr.End, _0023_003DzL_cOge_00248Ghnr.IsRelative, _0023_003DzbgFSTv8HRsq_));
		double num = pointF.X;
		double num2 = pointF.Y;
		double value = _0023_003DzL_cOge_00248Ghnr.RadiusX;
		double value2 = _0023_003DzL_cOge_00248Ghnr.RadiusY;
		double num3 = _0023_003DzL_cOge_00248Ghnr.Angle;
		bool flag = _0023_003DzL_cOge_00248Ghnr.Size == SvgArcSize.Large;
		bool flag2 = _0023_003DzL_cOge_00248Ghnr.Sweep == SvgArcSweep.Positive;
		double num4 = pointF2.X;
		double num5 = pointF2.Y;
		double num6 = (num - num4) / 2.0;
		double num7 = (num2 - num5) / 2.0;
		double num8 = num3 / 180.0 * Math.PI;
		double num9 = Math.Cos(num8);
		double num10 = Math.Sin(num8);
		double num11 = num9 * num6 + num10 * num7;
		double num12 = (0.0 - num10) * num6 + num9 * num7;
		value = Math.Abs(value);
		value2 = Math.Abs(value2);
		double num13 = value * value;
		double num14 = value2 * value2;
		double num15 = num11 * num11;
		double num16 = num12 * num12;
		double num17 = num15 / num13 + num16 / num14;
		if (num17 > 1.0)
		{
			value = Math.Sqrt(num17) * value;
			value2 = Math.Sqrt(num17) * value2;
			num13 = value * value;
			num14 = value2 * value2;
		}
		double num18 = ((flag != flag2) ? 1 : (-1));
		double num19 = (num13 * num14 - num13 * num16 - num14 * num15) / (num13 * num16 + num14 * num15);
		num19 = ((num19 < 0.0) ? 0.0 : num19);
		double num20 = num18 * Math.Sqrt(num19);
		double num21 = num20 * (value * num12 / value2);
		double num22 = num20 * (0.0 - value2 * num11 / value);
		double num23 = (num + num4) / 2.0;
		double num24 = (num2 + num5) / 2.0;
		double _0023_003DzNDS6jIw_003D = num23 + (num9 * num21 - num10 * num22);
		double _0023_003DzOhdXIPc_003D = num24 + (num10 * num21 + num9 * num22);
		double num25 = (num11 - num21) / value;
		double num26 = (num12 - num22) / value2;
		double num27 = (0.0 - num11 - num21) / value;
		double num28 = (0.0 - num12 - num22) / value2;
		double num29 = Math.Sqrt(num25 * num25 + num26 * num26);
		double num30 = num25;
		double num31 = ((num26 < 0.0) ? (-1.0) : 1.0) * Math.Acos(num30 / num29);
		num29 = Math.Sqrt((num25 * num25 + num26 * num26) * (num27 * num27 + num28 * num28));
		num30 = num25 * num27 + num26 * num28;
		double num32 = ((num25 * num28 - num26 * num27 < 0.0) ? (-1.0) : 1.0) * Math.Acos(num30 / num29);
		if (!flag2 && num32 > 0.0)
		{
			num32 -= Math.PI * 2.0;
		}
		else if (flag2 && num32 < 0.0)
		{
			num32 += Math.PI * 2.0;
		}
		num32 %= Math.PI * 2.0;
		num31 %= Math.PI * 2.0;
		return new _0023_003Dzx8YZKPmLAeYF
		{
			_0023_003DzNDS6jIw_003D = _0023_003DzNDS6jIw_003D,
			_0023_003DzOhdXIPc_003D = _0023_003DzOhdXIPc_003D,
			_0023_003DzE_ndlS0_003D = num31,
			_0023_003Dz9XMxeHE_003D = num31 + num32
		};
	}
}
