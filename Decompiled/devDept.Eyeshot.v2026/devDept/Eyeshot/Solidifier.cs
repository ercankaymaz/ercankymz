using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class Solidifier : WorkUnit
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Brep _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzEDmV6Dbdr_0024xRRunFCQ_003D_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998357);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzUG2UTOGW0BcG;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dzcm94zpflZ77MNwUnmw_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Surface[] _0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D;

	public Brep Result
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzhunUpMU3pDJqcavGrA_003D_003D;
		}
	}

	public string WorkingText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzEDmV6Dbdr_0024xRRunFCQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzEDmV6Dbdr_0024xRRunFCQ_003D_003D = value;
		}
	}

	public string BlockName
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003Dz_1gaLS4aWaYai9lcLQ_003D_003D = value;
		}
	}

	public Solidifier(IList<Surface> surfaces, double tol = 0.0)
	{
		if (tol == 0.0)
		{
			List<Point3D> list = new List<Point3D>();
			foreach (Surface surface in surfaces)
			{
				if (surface.IsValid())
				{
					Point3D[] collection = ((!(surface.BoxMin != null)) ? surface.EstimateBoundingBox(null, null) : new Point3D[2] { surface.BoxMin, surface.BoxMax });
					list.AddRange(collection);
				}
			}
			Utility.ComputeBoundingBox(list, out var boxMin, out var boxMax);
			_0023_003DzUG2UTOGW0BcG = new Size3D(boxMin, boxMax).Diagonal / 10000.0;
		}
		else
		{
			_0023_003DzUG2UTOGW0BcG = tol;
		}
		_0023_003Dzcm94zpflZ77MNwUnmw_003D_003D = _0023_003DzUG2UTOGW0BcG * _0023_003DzUG2UTOGW0BcG;
		_0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D = Utility.DeepCopy(surfaces.ToArray());
	}

	private void _0023_003DzijhYAd8_003D(Brep _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003DzhunUpMU3pDJqcavGrA_003D_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		bool flag = true;
		byte b = 3;
		object[] array = null;
		array = new object[3] { b, this, flag };
		_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzV8Qoap2BA2e7ihDorf63UrBqJsHfxy8392Oay0RbYfZ4Z2b43A_003D_003D()._0023_003DzNXHD1f5m4vUdaYpGv25IefO5Nwsu(_0023_003DzWt6eyPOE44Jm1kt8t7xd_1OQVV5oXNkh39_0024rNGXvPLnSb0yR5w_003D_003D._0023_003DzBbbipLzVnuz3UMTaQrsmBHEULT9zYjvZXH2nU2CHpMurqdPqXQ_003D_003D(), "$N9u(q\"acA", array);
		if (_0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D.Length == 0)
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998352));
			return;
		}
		List<Brep> list = new List<Brep>(_0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D.Length);
		Point3D point3D = _0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D[0].ControlPoints[0, 0];
		Vector3D vector3D = new Vector3D(point3D.X, point3D.Y, point3D.Z);
		Vector3D v = -1.0 * vector3D;
		for (int i = 0; i < _0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D.Length; i++)
		{
			if (!_0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D[i].IsValid())
			{
				log.AppendLine(string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998295), i));
				continue;
			}
			_0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D[i].Translate(v);
			Brep item = _0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D[i].ConvertToBrep();
			list.Add(item);
		}
		List<Brep.Vertex> list2 = new List<Brep.Vertex>();
		List<Brep.Edge> list3 = new List<Brep.Edge>();
		List<Brep.Face> list4 = new List<Brep.Face>();
		Dictionary<Point3D, int> dictionary = new Dictionary<Point3D, int>();
		Dictionary<int, int>[] array2 = new Dictionary<int, int>[list.Count];
		Point3D[][] array3 = new Point3D[list.Count][];
		Dictionary<(int, int, int), List<Point3D>> dictionary2 = new Dictionary<(int, int, int), List<Point3D>>();
		for (int j = 0; j < list.Count; j++)
		{
			Brep brep = list[j];
			array2[j] = new Dictionary<int, int>();
			array3[j] = new Point3D[brep._vertices.Length];
			for (int k = 0; k < brep._vertices.Length; k++)
			{
				Brep.Vertex vertex = (Brep.Vertex)brep._vertices[k];
				(Point3D, int)? tuple = _0023_003DzAEmsloOmWi0D(vertex, dictionary2, dictionary);
				int value;
				if (tuple.HasValue)
				{
					var (point3D2, num) = tuple.Value;
					array3[j][k] = point3D2;
					value = num;
				}
				else
				{
					array3[j][k] = vertex;
					vertex.Parents = null;
					list2.Add(vertex);
					value = (dictionary[vertex] = list2.Count - 1);
					(int, int, int) key = (_0023_003DzmRDRobofPXgJ(vertex.X), _0023_003DzmRDRobofPXgJ(vertex.Y), _0023_003DzmRDRobofPXgJ(vertex.Z));
					if (!dictionary2.TryGetValue(key, out var value2))
					{
						value2 = (dictionary2[key] = new List<Point3D>());
					}
					value2.Add(vertex);
				}
				array2[j][k] = value;
			}
		}
		Dictionary<(int, int), List<(Brep.Edge, int, int)>> dictionary3 = new Dictionary<(int, int), List<(Brep.Edge, int, int)>>();
		Dictionary<int, int>[] array4 = new Dictionary<int, int>[list.Count];
		HashSet<int>[] array5 = new HashSet<int>[list.Count];
		for (int l = 0; l < list.Count; l++)
		{
			Brep brep2 = list[l];
			array4[l] = new Dictionary<int, int>();
			array5[l] = new HashSet<int>();
			for (int m = 0; m < brep2.Edges.Length; m++)
			{
				Brep.Edge edge = brep2.Edges[m];
				Point3D key2 = array3[l][edge.StartPointIndex];
				Point3D key3 = array3[l][edge.EndPointIndex];
				int num3 = dictionary[key2];
				int num4 = dictionary[key3];
				(int, int) key4 = (num3, num4);
				(int, int) key5 = (num4, num3);
				bool flag2 = false;
				bool flag3 = false;
				int num5 = -1;
				if (dictionary3.ContainsKey(key4))
				{
					flag2 = true;
				}
				if (dictionary3.ContainsKey(key5))
				{
					flag3 = true;
				}
				if (flag2 || flag3)
				{
					bool flag4 = false;
					if (flag2)
					{
						foreach (var item2 in dictionary3[key4])
						{
							var (edge2, _, _) = item2;
							if (!_0023_003DzBx1PWh8AvXtj(edge, edge2, array3, l, item2.Item3, out var _0023_003Dz9lul62LmuNJW1H805w_003D_003D, out var _0023_003DzyuRfLvVIECjZcpmij381JbA_003D))
							{
								continue;
							}
							if (_0023_003DzyuRfLvVIECjZcpmij381JbA_003D)
							{
								if (_0023_003DzWEhek9BNc0F2(edge.Curve, edge2.Curve, out _0023_003Dz9lul62LmuNJW1H805w_003D_003D, _0023_003DzUG2UTOGW0BcG))
								{
									num5 = item2.Item2;
									flag4 = true;
									if (_0023_003Dz9lul62LmuNJW1H805w_003D_003D)
									{
										array5[l].Add(m);
									}
								}
							}
							else if (_0023_003Dz8LqH6jK8MVt_Akq_m_0024d9pSY_003D(edge, edge2, array3, l, item2.Item3, _0023_003DzUG2UTOGW0BcG))
							{
								num5 = item2.Item2;
								flag4 = true;
								if (_0023_003Dz9lul62LmuNJW1H805w_003D_003D)
								{
									array5[l].Add(m);
								}
							}
							if (flag4)
							{
								break;
							}
						}
					}
					if (flag3 && !flag4)
					{
						foreach (var item3 in dictionary3[key5])
						{
							var (edge3, _, _) = item3;
							if (!_0023_003DzBx1PWh8AvXtj(edge, edge3, array3, l, item3.Item3, out var _0023_003Dz9lul62LmuNJW1H805w_003D_003D2, out var _0023_003DzyuRfLvVIECjZcpmij381JbA_003D2))
							{
								continue;
							}
							if (_0023_003DzyuRfLvVIECjZcpmij381JbA_003D2)
							{
								if (_0023_003DzWEhek9BNc0F2(edge.Curve, edge3.Curve, out _0023_003Dz9lul62LmuNJW1H805w_003D_003D2, _0023_003DzUG2UTOGW0BcG))
								{
									num5 = item3.Item2;
									flag4 = true;
									if (_0023_003Dz9lul62LmuNJW1H805w_003D_003D2)
									{
										array5[l].Add(m);
									}
								}
							}
							else if (_0023_003Dz8LqH6jK8MVt_Akq_m_0024d9pSY_003D(edge, edge3, array3, l, item3.Item3, _0023_003DzUG2UTOGW0BcG))
							{
								num5 = item3.Item2;
								flag4 = true;
								if (_0023_003Dz9lul62LmuNJW1H805w_003D_003D2)
								{
									array5[l].Add(m);
								}
							}
							if (flag4)
							{
								break;
							}
						}
					}
					if (!flag4)
					{
						edge.Parents = null;
						num5 = list3.Count;
						list3.Add(edge);
						edge.Curve.EdgeIndex = num5;
						if (!dictionary3.ContainsKey(key4))
						{
							dictionary3[key4] = new List<(Brep.Edge, int, int)>();
						}
						dictionary3[key4].Add((edge, num5, l));
					}
				}
				else
				{
					edge.Parents = null;
					num5 = list3.Count;
					list3.Add(edge);
					edge.Curve.EdgeIndex = num5;
					if (!dictionary3.ContainsKey(key4))
					{
						dictionary3[key4] = new List<(Brep.Edge, int, int)>();
					}
					dictionary3[key4].Add((edge, num5, l));
				}
				array4[l][m] = num5;
			}
		}
		for (int n = 0; n < list.Count; n++)
		{
			Brep brep3 = list[n];
			for (int num6 = 0; num6 < brep3.Faces.Length; num6++)
			{
				Brep.Face face = brep3.Faces[num6];
				for (int num7 = 0; num7 < brep3.Edges.Length; num7++)
				{
					Brep.Edge edge4 = brep3.Edges[num7];
					edge4.StartPointIndex = array2[n][edge4.StartPointIndex];
					edge4.EndPointIndex = array2[n][edge4.EndPointIndex];
				}
				for (int num8 = 0; num8 < face.Loops.Length; num8++)
				{
					Brep.Loop loop = face.Loops[num8];
					for (int num9 = 0; num9 < loop.Segments.Length; num9++)
					{
						if (array5[n].Contains(loop.Segments[num9].CurveIndex))
						{
							loop.Segments[num9].Sense = !loop.Segments[num9].Sense;
						}
						loop.Segments[num9].CurveIndex = array4[n][loop.Segments[num9].CurveIndex];
					}
				}
				Surface[] parametric = face.Parametric;
				for (int num10 = 0; num10 < parametric.Length; num10++)
				{
					foreach (ICurve contour in parametric[num10].Trimming.contourList)
					{
						ICurve[] individualCurves = contour.GetIndividualCurves();
						for (int num11 = 0; num11 < individualCurves.Length; num11++)
						{
							TrimCurve trimCurve = (TrimCurve)individualCurves[num11];
							if (array4[n].TryGetValue(trimCurve.EdgeIndex, out var value3))
							{
								trimCurve.EdgeIndex = value3;
								trimCurve.Edge.EdgeIndex = value3;
							}
						}
					}
				}
				list4.Add(face);
				if (!UpdateProgressAndCheckCancelled(list4.Count, list.Count, WorkingText, progress, ct))
				{
					return;
				}
			}
		}
		Point3D[] vertices = list2.ToArray();
		Brep brep4 = new Brep(vertices, list3.ToArray(), list4.ToArray());
		brep4.CopyAttributes(_0023_003DzQM3Rs_00248Pql9Gr7wV6w_003D_003D[0]);
		brep4.FixNormals();
		brep4.Translate(vector3D);
		UpdateProgressTo100(WorkingText, progress);
		_0023_003DzijhYAd8_003D(brep4);
	}

	private int _0023_003DzmRDRobofPXgJ(double _0023_003Dzt_m8zV0_003D)
	{
		return (int)Math.Floor(_0023_003Dzt_m8zV0_003D / _0023_003DzUG2UTOGW0BcG);
	}

	private (Point3D, int)? _0023_003DzAEmsloOmWi0D(Point3D _0023_003Dz77g161c_003D, Dictionary<(int, int, int), List<Point3D>> _0023_003Dz38O0SCk69Nfz, Dictionary<Point3D, int> _0023_003DzFEBbkrN764AeVqB0tGM3Bro_003D)
	{
		int num = _0023_003DzmRDRobofPXgJ(_0023_003Dz77g161c_003D.X);
		int num2 = _0023_003DzmRDRobofPXgJ(_0023_003Dz77g161c_003D.Y);
		int num3 = _0023_003DzmRDRobofPXgJ(_0023_003Dz77g161c_003D.Z);
		for (int i = -1; i <= 1; i++)
		{
			for (int j = -1; j <= 1; j++)
			{
				for (int k = -1; k <= 1; k++)
				{
					(int, int, int) key = (num + i, num2 + j, num3 + k);
					if (!_0023_003Dz38O0SCk69Nfz.TryGetValue(key, out var value))
					{
						continue;
					}
					foreach (Point3D item in value)
					{
						if (Point3D.DistanceSquared(item, _0023_003Dz77g161c_003D) < _0023_003Dzcm94zpflZ77MNwUnmw_003D_003D)
						{
							return (item, _0023_003DzFEBbkrN764AeVqB0tGM3Bro_003D[item]);
						}
					}
				}
			}
		}
		return null;
	}

	private bool _0023_003DzBx1PWh8AvXtj(Brep.Edge _0023_003DzRVoDPs0_003D, Brep.Edge _0023_003Dz_0024ozI2Ww_003D, Point3D[][] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzaX0ZjLs_003D, int _0023_003DzY2jgrPVCRPgE, out bool _0023_003Dz9lul62LmuNJW1H805w_003D_003D, out bool _0023_003DzyuRfLvVIECjZcpmij381JbA_003D)
	{
		Point3D point3D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzaX0ZjLs_003D][_0023_003DzRVoDPs0_003D.StartPointIndex];
		Point3D point3D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzaX0ZjLs_003D][_0023_003DzRVoDPs0_003D.EndPointIndex];
		Point3D point3D3 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzY2jgrPVCRPgE][_0023_003Dz_0024ozI2Ww_003D.StartPointIndex];
		Point3D other = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzY2jgrPVCRPgE][_0023_003Dz_0024ozI2Ww_003D.EndPointIndex];
		_0023_003Dz9lul62LmuNJW1H805w_003D_003D = false;
		_0023_003DzyuRfLvVIECjZcpmij381JbA_003D = false;
		if (point3D.Equals(point3D2) || point3D3.Equals(other))
		{
			_0023_003DzyuRfLvVIECjZcpmij381JbA_003D = true;
		}
		if (point3D.Equals(point3D3) && point3D2.Equals(other))
		{
			return true;
		}
		if (point3D.Equals(other) && point3D2.Equals(point3D3))
		{
			_0023_003Dz9lul62LmuNJW1H805w_003D_003D = true;
			return true;
		}
		return false;
	}

	internal bool _0023_003Dz8LqH6jK8MVt_Akq_m_0024d9pSY_003D(Brep.Edge _0023_003DzRVoDPs0_003D, Brep.Edge _0023_003Dz_0024ozI2Ww_003D, Point3D[][] _0023_003Dzk98RESByZO6KwZuGTA_003D_003D, int _0023_003DzaX0ZjLs_003D, int _0023_003DzY2jgrPVCRPgE, double _0023_003Dzm0CYiiE_003D)
	{
		Point3D point3D = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzaX0ZjLs_003D][_0023_003DzRVoDPs0_003D.StartPointIndex];
		Point3D point3D2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzaX0ZjLs_003D][_0023_003DzRVoDPs0_003D.EndPointIndex];
		Point3D other = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzY2jgrPVCRPgE][_0023_003Dz_0024ozI2Ww_003D.StartPointIndex];
		Point3D other2 = _0023_003Dzk98RESByZO6KwZuGTA_003D_003D[_0023_003DzY2jgrPVCRPgE][_0023_003Dz_0024ozI2Ww_003D.EndPointIndex];
		ICurve curve = _0023_003DzRVoDPs0_003D.Curve;
		ICurve curve2 = _0023_003Dz_0024ozI2Ww_003D.Curve;
		if (curve is Curve && !(curve2 is Curve))
		{
			curve2 = curve2.GetNurbsForm();
		}
		else if (!(curve is Curve) && curve2 is Curve)
		{
			curve = curve.GetNurbsForm();
		}
		if (curve is Curve _0023_003Dzfm4oGj8_003D && curve2 is Curve _0023_003DzCVdPoWM_003D)
		{
			Point3D _0023_003DzDVubtvo_003D;
			Point3D _0023_003DzFj_0024IqDQ_003D;
			bool _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
			Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D = Curve._0023_003DzRGcO5v1wS2S_(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, out _0023_003DzDVubtvo_003D, out _0023_003DzFj_0024IqDQ_003D, out _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, Math.Max(_0023_003Dzm0CYiiE_003D * 1000.0, 1.0));
			if (_0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)3 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)5 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)4 || _0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D == (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6)
			{
				return true;
			}
		}
		else
		{
			if (curve is Line && curve2 is Line)
			{
				return true;
			}
			if (curve is PlanarEntity planarEntity && curve2 is PlanarEntity planarEntity2)
			{
				if (!Vector3D.AreParallel(planarEntity.Plane.AxisZ, planarEntity2.Plane.AxisZ, 0.01))
				{
					return false;
				}
				if (curve is Arc arc && curve2 is Arc arc2)
				{
					if (_0023_003DzMAxShrbxTEQp(arc.Center, arc2.Center, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(arc.Radius, arc2.Radius, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(Math.Abs(arc.Domain.Length), Math.Abs(arc2.Domain.Length), _0023_003Dzm0CYiiE_003D))
					{
						if (point3D.Equals(other) && point3D2.Equals(other2) && Vector3D.AreCoincident(planarEntity.Plane.AxisZ, planarEntity2.Plane.AxisZ, 0.01))
						{
							return true;
						}
						if (point3D.Equals(other2) && point3D2.Equals(other) && Vector3D.AreOpposite(planarEntity.Plane.AxisZ, planarEntity2.Plane.AxisZ, 0.01))
						{
							return true;
						}
					}
				}
				else if (curve is EllipticalArc ellipticalArc && curve2 is EllipticalArc ellipticalArc2)
				{
					if (_0023_003DzMAxShrbxTEQp(ellipticalArc.Center, ellipticalArc2.Center, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(ellipticalArc.RadiusX, ellipticalArc2.RadiusX, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(ellipticalArc.RadiusY, ellipticalArc2.RadiusY, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(Math.Abs(ellipticalArc.Domain.Length), Math.Abs(ellipticalArc2.Domain.Length), _0023_003Dzm0CYiiE_003D))
					{
						if (point3D.Equals(other) && point3D2.Equals(other2) && Vector3D.AreCoincident(planarEntity.Plane.AxisZ, planarEntity2.Plane.AxisZ, 0.01))
						{
							return true;
						}
						if (point3D.Equals(other2) && point3D2.Equals(other) && Vector3D.AreOpposite(planarEntity.Plane.AxisZ, planarEntity2.Plane.AxisZ, 0.01))
						{
							return true;
						}
					}
				}
				else if (curve is Circle circle && curve2 is Circle circle2)
				{
					if (_0023_003DzMAxShrbxTEQp(circle.Center, circle2.Center, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(circle.Radius, circle2.Radius, _0023_003Dzm0CYiiE_003D))
					{
						return true;
					}
				}
				else if (curve is Ellipse ellipse && curve2 is Ellipse ellipse2 && _0023_003DzMAxShrbxTEQp(ellipse.Center, ellipse2.Center, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(ellipse.RadiusX, ellipse2.RadiusX, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(ellipse.RadiusY, ellipse2.RadiusY, _0023_003Dzm0CYiiE_003D))
				{
					return true;
				}
			}
		}
		return false;
	}

	internal static bool _0023_003DzWEhek9BNc0F2(ICurve _0023_003Dz8EhW_0024omtFk2M, ICurve _0023_003DzWB5w2Msi2ASb, out bool _0023_003Dz_JmCbrVMHM1y7ViXpw_003D_003D, double _0023_003Dzm0CYiiE_003D)
	{
		_0023_003Dz_JmCbrVMHM1y7ViXpw_003D_003D = false;
		double tol = 0.01;
		if (_0023_003Dz8EhW_0024omtFk2M is Curve && !(_0023_003DzWB5w2Msi2ASb is Curve))
		{
			_0023_003DzWB5w2Msi2ASb = _0023_003DzWB5w2Msi2ASb.GetNurbsForm();
		}
		else if (!(_0023_003Dz8EhW_0024omtFk2M is Curve) && _0023_003DzWB5w2Msi2ASb is Curve)
		{
			_0023_003Dz8EhW_0024omtFk2M = _0023_003Dz8EhW_0024omtFk2M.GetNurbsForm();
		}
		if (_0023_003Dz8EhW_0024omtFk2M is Curve _0023_003Dzfm4oGj8_003D && _0023_003DzWB5w2Msi2ASb is Curve _0023_003DzCVdPoWM_003D)
		{
			Point3D _0023_003DzDVubtvo_003D;
			Point3D _0023_003DzFj_0024IqDQ_003D;
			bool _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D;
			switch (Curve._0023_003DzRGcO5v1wS2S_(_0023_003Dzfm4oGj8_003D, _0023_003DzCVdPoWM_003D, out _0023_003DzDVubtvo_003D, out _0023_003DzFj_0024IqDQ_003D, out _0023_003DzuO0mIAMFuew7r9vXjQ_003D_003D, Math.Max(_0023_003Dzm0CYiiE_003D * 1000.0, 1.0)))
			{
			case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)3:
			case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)5:
				return true;
			case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)4:
			case (Curve._0023_003DzU5GDup48_0024KmFRM33SQ_003D_003D)6:
				_0023_003Dz_JmCbrVMHM1y7ViXpw_003D_003D = true;
				return true;
			}
		}
		else if (_0023_003Dz8EhW_0024omtFk2M is PlanarEntity planarEntity && _0023_003DzWB5w2Msi2ASb is PlanarEntity planarEntity2)
		{
			if (!Vector3D.AreParallel(planarEntity.Plane.AxisZ, planarEntity2.Plane.AxisZ, tol))
			{
				return false;
			}
			if (_0023_003Dz8EhW_0024omtFk2M is Arc arc && _0023_003DzWB5w2Msi2ASb is Arc arc2)
			{
				if (_0023_003DzMAxShrbxTEQp(arc2.Center, arc.Center, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(arc.Radius, arc2.Radius, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(Math.Abs(arc.Domain.Length), Math.Abs(arc2.Domain.Length), _0023_003Dzm0CYiiE_003D))
				{
					if (_0023_003DzMAxShrbxTEQp(arc.StartPoint, arc2.StartPoint, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(arc.EndPoint, arc2.EndPoint, _0023_003Dzm0CYiiE_003D) && Vector3D.AreCoincident(arc.Plane.AxisZ, arc2.Plane.AxisZ, tol))
					{
						return true;
					}
					if (_0023_003DzMAxShrbxTEQp(arc.StartPoint, arc2.EndPoint, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(arc.EndPoint, arc2.StartPoint, _0023_003Dzm0CYiiE_003D) && Vector3D.AreOpposite(arc.Plane.AxisZ, arc2.Plane.AxisZ, tol))
					{
						_0023_003Dz_JmCbrVMHM1y7ViXpw_003D_003D = true;
						return true;
					}
				}
			}
			else if (_0023_003Dz8EhW_0024omtFk2M is EllipticalArc ellipticalArc && _0023_003DzWB5w2Msi2ASb is EllipticalArc ellipticalArc2)
			{
				if (_0023_003DzMAxShrbxTEQp(ellipticalArc.Center, ellipticalArc2.Center, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(ellipticalArc.RadiusX, ellipticalArc2.RadiusX, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(ellipticalArc.RadiusY, ellipticalArc2.RadiusY, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(Math.Abs(ellipticalArc.Domain.Length), Math.Abs(ellipticalArc2.Domain.Length), _0023_003Dzm0CYiiE_003D))
				{
					if (_0023_003DzMAxShrbxTEQp(ellipticalArc.StartPoint, ellipticalArc2.StartPoint, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(ellipticalArc.EndPoint, ellipticalArc2.EndPoint, _0023_003Dzm0CYiiE_003D) && Vector3D.AreCoincident(ellipticalArc.Plane.AxisZ, ellipticalArc2.Plane.AxisZ, tol))
					{
						return true;
					}
					if (_0023_003DzMAxShrbxTEQp(ellipticalArc.StartPoint, ellipticalArc2.EndPoint, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(ellipticalArc.EndPoint, ellipticalArc2.StartPoint, _0023_003Dzm0CYiiE_003D) && Vector3D.AreOpposite(ellipticalArc.Plane.AxisZ, ellipticalArc2.Plane.AxisZ, tol))
					{
						_0023_003Dz_JmCbrVMHM1y7ViXpw_003D_003D = true;
						return true;
					}
				}
			}
			else if (_0023_003Dz8EhW_0024omtFk2M is Circle circle && _0023_003DzWB5w2Msi2ASb is Circle circle2)
			{
				if (_0023_003DzMAxShrbxTEQp(circle.Center, circle2.Center, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(circle.Radius, circle2.Radius, _0023_003Dzm0CYiiE_003D))
				{
					if (Vector3D.AreOpposite(circle.Plane.AxisZ, circle2.Plane.AxisZ, tol))
					{
						_0023_003Dz_JmCbrVMHM1y7ViXpw_003D_003D = true;
					}
					return true;
				}
			}
			else if (_0023_003Dz8EhW_0024omtFk2M is Ellipse ellipse && _0023_003DzWB5w2Msi2ASb is Ellipse ellipse2 && _0023_003DzMAxShrbxTEQp(ellipse.Center, ellipse2.Center, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(ellipse.RadiusX, ellipse2.RadiusX, _0023_003Dzm0CYiiE_003D) && _0023_003DzMAxShrbxTEQp(ellipse.RadiusY, ellipse2.RadiusY, _0023_003Dzm0CYiiE_003D))
			{
				if (Vector3D.AreOpposite(ellipse.Plane.AxisZ, ellipse2.Plane.AxisZ))
				{
					_0023_003Dz_JmCbrVMHM1y7ViXpw_003D_003D = true;
				}
				return true;
			}
		}
		return false;
	}

	private static bool _0023_003DzMAxShrbxTEQp(Point3D _0023_003DzjbqS1qE_003D, Point3D _0023_003Dz1v6oPQk_003D, double _0023_003Dzm0CYiiE_003D)
	{
		if (Utility.Compare(_0023_003Dzm0CYiiE_003D, _0023_003DzjbqS1qE_003D.X, _0023_003Dz1v6oPQk_003D.X) == 0 && Utility.Compare(_0023_003Dzm0CYiiE_003D, _0023_003DzjbqS1qE_003D.Y, _0023_003Dz1v6oPQk_003D.Y) == 0)
		{
			return Utility.Compare(_0023_003Dzm0CYiiE_003D, _0023_003DzjbqS1qE_003D.Z, _0023_003Dz1v6oPQk_003D.Z) == 0;
		}
		return false;
	}

	private static bool _0023_003DzMAxShrbxTEQp(double _0023_003DzjbqS1qE_003D, double _0023_003Dz1v6oPQk_003D, double _0023_003Dzm0CYiiE_003D)
	{
		return Utility.Compare(_0023_003Dzm0CYiiE_003D, _0023_003DzjbqS1qE_003D, _0023_003Dz1v6oPQk_003D) == 0;
	}
}
