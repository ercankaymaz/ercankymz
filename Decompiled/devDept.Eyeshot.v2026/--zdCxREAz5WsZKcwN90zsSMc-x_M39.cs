using System;
using System.Collections.Generic;
using devDept.Eyeshot;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DzdCxREAz5WsZKcwN90zsSMc_0024x_M39
{
	public delegate int _0023_003DzP5_hz_0024hPufDR(int _0023_003DzTx2aqr8_003D, Solid.Portion _0023_003Dzd9ZyL64_003D);

	private static class _0023_003DzQm9ltrs_003D
	{
		public static Comparison<_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc> _0023_003DzvWE1UEPZKvCv73KrJA3NxATkWtHz;
	}

	public static void _0023_003DzG037o6MQFwqV(Solid.Portion _0023_003Dzd9ZyL64_003D, Solid._0023_003Dz1IcEX2Y45sL1 _0023_003Dza_0024rPgw4_003D, bool _0023_003DzPrQP54igoJQK)
	{
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.edgeCount; i++)
		{
			int nextFace = _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace;
			_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace = _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace;
			_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace = nextFace;
			nextFace = -_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge;
			_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge = -_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge;
			_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge = nextFace;
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace < 0)
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge = -_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge;
			}
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace < 0)
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge = -_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge;
			}
		}
		if (_0023_003Dza_0024rPgw4_003D == (Solid._0023_003Dz1IcEX2Y45sL1)1 && _0023_003DzPrQP54igoJQK)
		{
			for (int j = 1; j <= _0023_003Dzd9ZyL64_003D.edgeCount; j++)
			{
				if (_0023_003Dzd9ZyL64_003D.edgeDatas[j].Angle != 0f)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[j].Angle = (float)Math.PI * 2f - _0023_003Dzd9ZyL64_003D.edgeDatas[j].Angle;
				}
			}
		}
		for (int k = 1; k <= _0023_003Dzd9ZyL64_003D.contourCount; k++)
		{
			if (_0023_003Dzd9ZyL64_003D.cycles[k].FirstEdge == 0)
			{
				continue;
			}
			_0023_003Dzd9ZyL64_003D.cycles[k].FirstEdge = -_0023_003Dzd9ZyL64_003D.cycles[k].FirstEdge;
			int num = _0023_003Dzd9ZyL64_003D.cycles[k].FirstEdge;
			int num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num, _0023_003Dzd9ZyL64_003D);
			do
			{
				int nextFace;
				if (num2 > 0)
				{
					nextFace = _0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(num2)].NextEdge;
					_0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(num2)].NextEdge = num;
				}
				else
				{
					nextFace = _0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(num2)].PreviousEdge;
					_0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(num2)].PreviousEdge = num;
				}
				num = num2;
				num2 = nextFace;
			}
			while (num != _0023_003Dzd9ZyL64_003D.cycles[k].FirstEdge);
		}
		for (int l = 1; l <= _0023_003Dzd9ZyL64_003D.faceCount; l++)
		{
			_0023_003Dzd9ZyL64_003D.planes[l].Negate();
		}
	}

	public static bool _0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, Solid _0023_003DzcDEsV8s_003D)
	{
		NpStr npStr = new NpStr();
		_0023_003Dzd9ZyL64_003D.UpdateBoundingBox(null);
		npStr.ident = _0023_003Dzd9ZyL64_003D.Id;
		_0023_003DzcDEsV8s_003D.portions.Add(_0023_003Dzd9ZyL64_003D);
		npStr.hnp = _0023_003DzcDEsV8s_003D.portions.Count;
		_0023_003DzcDEsV8s_003D.NpStrList.Add(npStr);
		_0023_003DzcDEsV8s_003D.NpStrDict.Add(npStr.ident, npStr);
		return true;
	}

	public static bool _0023_003Dz37UDgYerq6IE(out Solid.Portion _0023_003Dzd9ZyL64_003D, double _0023_003DzEGKj_0024SNUUihi, int _0023_003DzWggrFNRqDjRU, double _0023_003DzvAxV_0024Ic_003D, ref int _0023_003DzonfzEyGKx82P)
	{
		double num = Math.PI * 2.0 / (double)_0023_003DzWggrFNRqDjRU;
		if (_0023_003DzWggrFNRqDjRU > 250 || _0023_003DzWggrFNRqDjRU > 400)
		{
			_0023_003Dzd9ZyL64_003D = new Solid.Portion(_0023_003DzWggrFNRqDjRU + 1, _0023_003DzWggrFNRqDjRU + 1, 202, 222);
		}
		else
		{
			_0023_003Dzd9ZyL64_003D = new Solid.Portion();
		}
		_0023_003Dzd9ZyL64_003D.Id = _0023_003DzonfzEyGKx82P++;
		for (int i = 0; i < _0023_003DzWggrFNRqDjRU; i++)
		{
			double num2 = num * (double)(i + 1);
			_0023_003Dzd9ZyL64_003D._vertices[i] = new Point3D(_0023_003DzEGKj_0024SNUUihi * Math.Cos(num2), _0023_003DzEGKj_0024SNUUihi * Math.Sin(num2), _0023_003DzvAxV_0024Ic_003D);
		}
		_0023_003Dzd9ZyL64_003D.vertexCount = _0023_003DzWggrFNRqDjRU;
		for (int j = 1; j <= _0023_003DzWggrFNRqDjRU; j++)
		{
			_0023_003Dzd9ZyL64_003D.edgeDatas[j].BeginVertex = j - 1;
			_0023_003Dzd9ZyL64_003D.edgeDatas[j].EndVertex = j;
			_0023_003Dzd9ZyL64_003D.edgeDatas[j].NextEdge = j + 1;
			_0023_003Dzd9ZyL64_003D.edgeDatas[j].NextFace = 1;
			_0023_003Dzd9ZyL64_003D.edgeDatas[j].PreviousEdge = 0;
			_0023_003Dzd9ZyL64_003D.edgeDatas[j].PreviousFace = 0;
			_0023_003Dzd9ZyL64_003D.edgeDatas[j].Type = 1;
		}
		_0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzWggrFNRqDjRU].EndVertex = 0;
		_0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzWggrFNRqDjRU].NextEdge = 1;
		_0023_003Dzd9ZyL64_003D.edgeCount = _0023_003DzWggrFNRqDjRU;
		_0023_003Dzd9ZyL64_003D.faces[1].FirstContour = 1;
		_0023_003Dzd9ZyL64_003D.cycles[1].FirstEdge = 1;
		_0023_003Dzd9ZyL64_003D.cycles[1].NextContour = 0;
		_0023_003Dzd9ZyL64_003D.faceCount = (_0023_003Dzd9ZyL64_003D.contourCount = 1);
		if (!_0023_003Dzfn6hhMMnY_jS(_0023_003Dzd9ZyL64_003D))
		{
			return false;
		}
		return true;
	}

	public static bool _0023_003Dzfn6hhMMnY_jS(Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		if (_0023_003Dzd9ZyL64_003D.vertexCount <= 0 || _0023_003Dzd9ZyL64_003D.edgeCount <= 0 || _0023_003Dzd9ZyL64_003D.faceCount <= 0 || _0023_003Dzd9ZyL64_003D.contourCount <= 0)
		{
			return false;
		}
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
		{
			if (!_0023_003DzGgzJNaXch1svZajU9w_003D_003D(_0023_003Dzd9ZyL64_003D, i))
			{
				return false;
			}
		}
		return true;
	}

	public static bool _0023_003DzGgzJNaXch1svZajU9w_003D_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U)
	{
		_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2 = default(_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D);
		int num = _0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour;
		if (num <= 0 || num > _0023_003Dzd9ZyL64_003D.contourCount)
		{
			return false;
		}
		int endVertex = _0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(_0023_003Dzd9ZyL64_003D.cycles[num].FirstEdge)].EndVertex;
		if (endVertex < 0 || endVertex >= _0023_003Dzd9ZyL64_003D.vertexCount)
		{
			return false;
		}
		Point3D point3D = _0023_003Dzd9ZyL64_003D._vertices[endVertex];
		int num2 = 0;
		while (num > 0)
		{
			if (++num2 > _0023_003Dzd9ZyL64_003D.contourCount)
			{
				return false;
			}
			int firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num].FirstEdge;
			if (firstEdge == 0 || Math.Abs(firstEdge) > _0023_003Dzd9ZyL64_003D.edgeCount)
			{
				return false;
			}
			endVertex = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D);
			if (endVertex < 0 || endVertex >= _0023_003Dzd9ZyL64_003D.vertexCount)
			{
				return false;
			}
			double num3 = _0023_003Dzd9ZyL64_003D._vertices[endVertex].X - point3D.X;
			double num4 = _0023_003Dzd9ZyL64_003D._vertices[endVertex].Y - point3D.Y;
			double num5 = _0023_003Dzd9ZyL64_003D._vertices[endVertex].Z - point3D.Z;
			int num6 = firstEdge;
			int num7 = 0;
			do
			{
				if (++num7 > _0023_003Dzd9ZyL64_003D.edgeCount)
				{
					return false;
				}
				double num8 = num3;
				double num9 = num4;
				double num10 = num5;
				endVertex = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num6, _0023_003Dzd9ZyL64_003D);
				num6 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num6, _0023_003Dzd9ZyL64_003D);
				if (num6 == 0 || Math.Abs(num6) > _0023_003Dzd9ZyL64_003D.edgeCount || endVertex < 0 || endVertex >= _0023_003Dzd9ZyL64_003D.vertexCount)
				{
					return false;
				}
				Point3D point3D2 = _0023_003Dzd9ZyL64_003D._vertices[endVertex];
				num3 = point3D2.X - point3D.X;
				num4 = point3D2.Y - point3D.Y;
				num5 = point3D2.Z - point3D.Z;
				_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003Dzyk2fsPo_003D += num9 * num5 - num10 * num4;
				_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003DzvXOLtKg_003D += num10 * num3 - num8 * num5;
				_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003Dz8wjMonY_003D += num8 * num4 - num9 * num3;
			}
			while (num6 != firstEdge);
			num = _0023_003Dzd9ZyL64_003D.cycles[num].NextContour;
			if (num > _0023_003Dzd9ZyL64_003D.contourCount || num < 0)
			{
				return false;
			}
			if (num == 0)
			{
				break;
			}
		}
		bool num11 = _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003Dz4m952JDFwKpj() > 0.0;
		if (num11)
		{
			_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003DzbV1eOjg_003D();
		}
		else
		{
			_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003Dzyk2fsPo_003D = (_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003DzvXOLtKg_003D = (_0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003Dz8wjMonY_003D = 0.0));
		}
		_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U] = new PlaneEquation();
		_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].X = _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003Dzyk2fsPo_003D;
		_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].Y = _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003DzvXOLtKg_003D;
		_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].Z = _0023_003Dztkbgd_EySq_0024PAzwmu9GDMeo_003D2._0023_003Dz8wjMonY_003D;
		if (!num11)
		{
			return false;
		}
		_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].D = (0.0 - point3D.X) * _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].X - point3D.Y * _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].Y - point3D.Z * _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].Z;
		return true;
	}

	public static int _0023_003DzFipFikVW1CJj(Solid _0023_003DzcDEsV8s_003D, Solid._0023_003Dz1IcEX2Y45sL1 _0023_003Dza_0024rPgw4_003D, float _0023_003Dz6pajdGM_003D, List<Solid.brepType> _0023_003Dz0SpZWCCz_qrn, double _0023_003DzkRSfKls1SLfn)
	{
		int num = 0;
		int num2 = 0;
		Region3D region3D = new Region3D(Point3D.MaxValue, Point3D.MinValue);
		if (!_0023_003DzWOimfCEgaa7X(_0023_003DzcDEsV8s_003D, _0023_003DzcDEsV8s_003D))
		{
			return 0;
		}
		int num3 = 0;
		do
		{
			num3 = _0023_003DzcDEsV8s_003D.portions.Count;
			int num4 = 0;
			NpStr npStr;
			while (true)
			{
				npStr = _0023_003DzcDEsV8s_003D.NpStrList[num4];
				if (npStr.ort == 0)
				{
					break;
				}
				num4++;
			}
			npStr.ort = 1;
			num = 0;
			double _0023_003DzhKcriekaIolc = 0.0;
			Solid.brepType brepType = Solid.brepType.Body;
			int num5;
			do
			{
				num5 = num;
				num = 0;
				for (int i = num4; i < _0023_003DzcDEsV8s_003D.portions.Count; i++)
				{
					NpStr npStr2 = _0023_003DzcDEsV8s_003D.NpStrList[i];
					if (npStr2.lab == 2)
					{
						continue;
					}
					Solid.Portion portion;
					if (npStr2.ort == 0)
					{
						portion = _0023_003DzcDEsV8s_003D.portions[npStr2.hnp - 1];
						if (!_0023_003DzPzYRF_0024bpnBG9(_0023_003DzcDEsV8s_003D, portion, npStr2))
						{
							return 0;
						}
						if (npStr2.ort == 0)
						{
							continue;
						}
						num++;
					}
					else
					{
						num++;
						if (npStr2.lab == 1)
						{
							continue;
						}
						npStr2.lab = 1;
						portion = _0023_003DzcDEsV8s_003D.portions[npStr2.hnp - 1];
					}
					if (npStr2.len == 0)
					{
						for (int j = 1; j <= portion.edgeCount; j++)
						{
							if (portion.edgeDatas[j].NextFace == 0 || portion.edgeDatas[j].PreviousFace == 0)
							{
								brepType = Solid.brepType.Shell;
								portion.edgeDatas[j].Type = 1;
							}
						}
						if (_0023_003Dza_0024rPgw4_003D == (Solid._0023_003Dz1IcEX2Y45sL1)1)
						{
							if (brepType == Solid.brepType.Body)
							{
								_0023_003DzEQxK9Wi6z58v(portion, ref _0023_003DzhKcriekaIolc);
							}
							_0023_003DzgdSKwlxtRL1Q(region3D, new Region3D(portion.localMin, portion.localMax), region3D);
						}
						npStr2.lab = 1;
						_0023_003DzcDEsV8s_003D.NpStrList[i]._0023_003DzbByTzLTAlIM7(npStr2);
						continue;
					}
					int k = 1;
					int b = npStr2.b;
					int index;
					for (int l = 0; l < npStr2.len; l++)
					{
						index = _0023_003DzcDEsV8s_003D.NbList[b++];
						for (; k <= portion.edgeCount && portion.edgeDatas[k].PreviousFace != 0 && portion.edgeDatas[k].NextFace != 0; k++)
						{
						}
						if (k > portion.edgeCount)
						{
							break;
						}
						NpStr npStr3 = _0023_003DzcDEsV8s_003D.NpStrList[index];
						if (npStr3.lab == 1 || npStr3.lab == 2)
						{
							continue;
						}
						Solid.Portion portion2 = _0023_003DzcDEsV8s_003D.portions[npStr3.hnp - 1];
						int m;
						for (m = k; m <= portion.edgeCount; m++)
						{
							if (portion.edgeDatas[m].PreviousFace != 0 && portion.edgeDatas[m].NextFace != 0)
							{
								continue;
							}
							int num6 = portion.edgeDatas[m].BeginVertex;
							int endVertex = portion.edgeDatas[m].EndVertex;
							for (int n = 1; n <= portion2.edgeCount; n++)
							{
								if (portion2.edgeDatas[n].PreviousFace != 0 && portion2.edgeDatas[n].NextFace != 0)
								{
									continue;
								}
								int num7 = portion2.edgeDatas[n].BeginVertex;
								int endVertex2 = portion2.edgeDatas[n].EndVertex;
								if ((!_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion._vertices[num6], portion2._vertices[num7], _0023_003DzkRSfKls1SLfn) || !_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion._vertices[endVertex], portion2._vertices[endVertex2], _0023_003DzkRSfKls1SLfn)) && (!_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion._vertices[endVertex], portion2._vertices[num7], _0023_003DzkRSfKls1SLfn) || !_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion._vertices[num6], portion2._vertices[endVertex2], _0023_003DzkRSfKls1SLfn)))
								{
									continue;
								}
								int num8;
								if (portion2.edgeDatas[n].NextFace == 0)
								{
									num8 = portion2.edgeDatas[n].PreviousFace;
									num7 = endVertex2;
								}
								else
								{
									num8 = portion2.edgeDatas[n].NextFace;
								}
								int _0023_003DzRpXgovo_003D;
								int num9;
								if (portion.edgeDatas[m].NextFace == 0)
								{
									num6 = endVertex;
									_0023_003DzRpXgovo_003D = -m;
									num9 = portion.edgeDatas[m].PreviousFace;
								}
								else
								{
									_0023_003DzRpXgovo_003D = m;
									num9 = portion.edgeDatas[m].NextFace;
								}
								if (npStr3.ort == 0)
								{
									if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion._vertices[num6], portion2._vertices[num7], _0023_003DzkRSfKls1SLfn))
									{
										_0023_003DzG037o6MQFwqV(portion2, (Solid._0023_003Dz1IcEX2Y45sL1)1, _0023_003DzPrQP54igoJQK: true);
										npStr3.ort = -1;
									}
									else
									{
										npStr3.ort = 1;
									}
								}
								float num10;
								if ((num10 = _0023_003DzSLyKdRKkR7Vx(portion, _0023_003DzRpXgovo_003D, portion.planes[num9], portion2.planes[num8])) == 0f)
								{
									portion.edgeDatas[m].Type = 1;
									portion2.edgeDatas[n].Type = 1;
									if (portion.edgeDatas[m].NextFace == 0)
									{
										portion.edgeDatas[m].NextEdge = 0;
									}
									else
									{
										portion.edgeDatas[m].PreviousEdge = 0;
									}
									if (portion2.edgeDatas[n].NextFace == 0)
									{
										portion2.edgeDatas[n].NextEdge = 0;
									}
									else
									{
										portion2.edgeDatas[n].PreviousEdge = 0;
									}
									portion.edgeDatas[m].Angle = (portion2.edgeDatas[n].Angle = 0f);
									break;
								}
								if (portion.edgeDatas[m].NextFace == 0)
								{
									portion.edgeDatas[m].NextFace = -m;
									portion.edgeDatas[m].NextEdge = portion2.Id;
								}
								else
								{
									portion.edgeDatas[m].PreviousFace = -m;
									portion.edgeDatas[m].PreviousEdge = portion2.Id;
								}
								portion.edgeDatas[m].Angle = num10;
								if (portion2.edgeDatas[n].NextFace == 0)
								{
									portion2.edgeDatas[n].NextFace = -n;
									portion2.edgeDatas[n].NextEdge = portion.Id;
								}
								else
								{
									portion2.edgeDatas[n].PreviousFace = -n;
									portion2.edgeDatas[n].PreviousEdge = portion.Id;
								}
								portion2.edgeDatas[n].Angle = num10;
								if (portion.edgeDatas[m].Type == 0 || portion2.edgeDatas[n].Type == 0)
								{
									if (Math.PI - (double)_0023_003Dz6pajdGM_003D <= (double)num10 && (double)num10 <= Math.PI + (double)_0023_003Dz6pajdGM_003D)
									{
										portion.edgeDatas[m].Type &= -2;
										portion.edgeDatas[m].Type |= 4;
										portion2.edgeDatas[n].Type &= -2;
										portion2.edgeDatas[n].Type |= 4;
									}
									else
									{
										portion.edgeDatas[m].Type = 1;
										portion2.edgeDatas[n].Type = 1;
									}
								}
								break;
							}
						}
						for (m = 1; m <= portion2.edgeCount && portion2.edgeDatas[m].NextFace != 0 && portion2.edgeDatas[m].PreviousFace != 0; m++)
						{
						}
						if (m <= portion2.edgeCount || npStr3.ort == 0)
						{
							_0023_003DzcDEsV8s_003D.NpStrList[index]._0023_003DzbByTzLTAlIM7(npStr3);
							continue;
						}
						if (_0023_003Dza_0024rPgw4_003D == (Solid._0023_003Dz1IcEX2Y45sL1)1)
						{
							if (brepType == Solid.brepType.Body)
							{
								_0023_003DzEQxK9Wi6z58v(portion2, ref _0023_003DzhKcriekaIolc);
							}
							_0023_003DzgdSKwlxtRL1Q(region3D, new Region3D(portion2.localMin, portion2.localMax), region3D);
						}
						npStr3.lab = 1;
						_0023_003DzcDEsV8s_003D.NpStrList[index]._0023_003DzbByTzLTAlIM7(npStr3);
					}
					index = 0;
					for (int num11 = 1; num11 <= portion.edgeCount; num11++)
					{
						if (portion.edgeDatas[num11].NextFace == 0 || portion.edgeDatas[num11].PreviousFace == 0)
						{
							brepType = Solid.brepType.Shell;
							portion.edgeDatas[num11].Type = 1;
						}
					}
					if (_0023_003Dza_0024rPgw4_003D == (Solid._0023_003Dz1IcEX2Y45sL1)1)
					{
						if (brepType == Solid.brepType.Body)
						{
							_0023_003DzEQxK9Wi6z58v(portion, ref _0023_003DzhKcriekaIolc);
						}
						_0023_003DzgdSKwlxtRL1Q(region3D, new Region3D(portion.localMin, portion.localMax), region3D);
					}
					npStr2.lab = 1;
					_0023_003DzcDEsV8s_003D.NpStrList[i]._0023_003DzbByTzLTAlIM7(npStr2);
				}
			}
			while (num != num3 && num != num5);
			if (_0023_003Dza_0024rPgw4_003D == (Solid._0023_003Dz1IcEX2Y45sL1)0)
			{
				return num;
			}
			if (brepType == Solid.brepType.Body && _0023_003DzhKcriekaIolc < 0.0)
			{
				for (int num12 = 0; num12 < num; num12++)
				{
					_0023_003DzG037o6MQFwqV(_0023_003DzcDEsV8s_003D.portions[num12], (Solid._0023_003Dz1IcEX2Y45sL1)1, _0023_003DzPrQP54igoJQK: true);
				}
			}
			_0023_003Dz0SpZWCCz_qrn.Add(brepType);
			num2++;
			_0023_003DzXs6G6MrDHATE(_0023_003DzcDEsV8s_003D, ref num3);
		}
		while (num3 != 0);
		return num2;
	}

	public static float _0023_003DzSLyKdRKkR7Vx(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzRpXgovo_003D, Vector3D _0023_003DzLlLRwFw_003D, Vector3D _0023_003Dz2QNSBWU_003D)
	{
		double num = Vector3D.Dot(_0023_003DzLlLRwFw_003D, new Vector3D(_0023_003Dz2QNSBWU_003D.X, _0023_003Dz2QNSBWU_003D.Y, _0023_003Dz2QNSBWU_003D.Z));
		if (num <= -0.999999)
		{
			return 0f;
		}
		double num2;
		if (num >= 0.999999)
		{
			num2 = Math.PI;
		}
		else
		{
			num2 = Math.Acos(num);
			int num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(_0023_003DzRpXgovo_003D, _0023_003Dzd9ZyL64_003D);
			int num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(_0023_003DzRpXgovo_003D, _0023_003Dzd9ZyL64_003D);
			Vector3D vector3D = Vector3D.Subtract(_0023_003Dzd9ZyL64_003D._vertices[num4], _0023_003Dzd9ZyL64_003D._vertices[num3]);
			Vector3D vector3D2 = new Vector3D(vector3D.X, vector3D.Y, vector3D.Z);
			if (!vector3D2.Normalize())
			{
				return 0f;
			}
			Vector3D vector3D3 = Vector3D.Cross(_0023_003DzLlLRwFw_003D, _0023_003Dz2QNSBWU_003D);
			Vector3D vector3D4 = new Vector3D(vector3D3.X, vector3D3.Y, vector3D3.Z);
			if (!vector3D4.Normalize())
			{
				return 0f;
			}
			num2 = ((!(Vector3D.Dot(vector3D2, vector3D4) < 0.0)) ? (Math.PI + num2) : (Math.PI - num2));
		}
		return (float)num2;
	}

	internal static void _0023_003DzEQxK9Wi6z58v(Solid.Portion _0023_003Dzd9ZyL64_003D, ref double _0023_003DzhKcriekaIolc)
	{
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
		{
			for (int num = _0023_003Dzd9ZyL64_003D.faces[i].FirstContour; num != 0; num = _0023_003Dzd9ZyL64_003D.cycles[num].NextContour)
			{
				int firstEdge;
				int num2 = (firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num].FirstEdge);
				int num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D);
				Point3D a = _0023_003Dzd9ZyL64_003D._vertices[num3];
				firstEdge = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(firstEdge, _0023_003Dzd9ZyL64_003D);
				num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D);
				Point3D point3D = _0023_003Dzd9ZyL64_003D._vertices[num3];
				firstEdge = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(firstEdge, _0023_003Dzd9ZyL64_003D);
				do
				{
					Point3D b = new Point3D(point3D.X, point3D.Y, point3D.Z);
					num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dzd9ZyL64_003D);
					point3D = _0023_003Dzd9ZyL64_003D._vertices[num3];
					Vector3D v = Vector3D.Cross(a, b);
					_0023_003DzhKcriekaIolc += Vector3D.Dot(point3D, v);
					firstEdge = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(firstEdge, _0023_003Dzd9ZyL64_003D);
				}
				while (firstEdge != num2);
			}
		}
	}

	public static void _0023_003DzgdSKwlxtRL1Q(Region3D _0023_003Dzva8YATk_003D, Region3D _0023_003Dz6ED5_S8_003D, Region3D _0023_003Dz_XAFw2I_003D)
	{
		if (_0023_003Dzva8YATk_003D.min.X < _0023_003Dz6ED5_S8_003D.min.X)
		{
			_0023_003Dz_XAFw2I_003D.min.X = _0023_003Dzva8YATk_003D.min.X;
		}
		else
		{
			_0023_003Dz_XAFw2I_003D.min.X = _0023_003Dz6ED5_S8_003D.min.X;
		}
		if (_0023_003Dzva8YATk_003D.min.Y < _0023_003Dz6ED5_S8_003D.min.Y)
		{
			_0023_003Dz_XAFw2I_003D.min.Y = _0023_003Dzva8YATk_003D.min.Y;
		}
		else
		{
			_0023_003Dz_XAFw2I_003D.min.Y = _0023_003Dz6ED5_S8_003D.min.Y;
		}
		if (_0023_003Dzva8YATk_003D.min.Z < _0023_003Dz6ED5_S8_003D.min.Z)
		{
			_0023_003Dz_XAFw2I_003D.min.Z = _0023_003Dzva8YATk_003D.min.Z;
		}
		else
		{
			_0023_003Dz_XAFw2I_003D.min.Z = _0023_003Dz6ED5_S8_003D.min.Z;
		}
		if (_0023_003Dzva8YATk_003D.max.X > _0023_003Dz6ED5_S8_003D.max.X)
		{
			_0023_003Dz_XAFw2I_003D.max.X = _0023_003Dzva8YATk_003D.max.X;
		}
		else
		{
			_0023_003Dz_XAFw2I_003D.max.X = _0023_003Dz6ED5_S8_003D.max.X;
		}
		if (_0023_003Dzva8YATk_003D.max.Y > _0023_003Dz6ED5_S8_003D.max.Y)
		{
			_0023_003Dz_XAFw2I_003D.max.Y = _0023_003Dzva8YATk_003D.max.Y;
		}
		else
		{
			_0023_003Dz_XAFw2I_003D.max.Y = _0023_003Dz6ED5_S8_003D.max.Y;
		}
		if (_0023_003Dzva8YATk_003D.max.Z > _0023_003Dz6ED5_S8_003D.max.Z)
		{
			_0023_003Dz_XAFw2I_003D.max.Z = _0023_003Dzva8YATk_003D.max.Z;
		}
		else
		{
			_0023_003Dz_XAFw2I_003D.max.Z = _0023_003Dz6ED5_S8_003D.max.Z;
		}
	}

	private static void _0023_003DzXs6G6MrDHATE(Solid _0023_003DzcDEsV8s_003D, ref int _0023_003DzYEGhK9e_00243_0024EK)
	{
		_0023_003DzYEGhK9e_00243_0024EK = 0;
		for (int i = 0; i < _0023_003DzcDEsV8s_003D.portions.Count; i++)
		{
			NpStr npStr = _0023_003DzcDEsV8s_003D.NpStrList[i];
			if (npStr.lab == 0)
			{
				_0023_003DzYEGhK9e_00243_0024EK++;
			}
			else
			{
				npStr.lab = 2;
			}
		}
	}

	public static bool _0023_003DzWOimfCEgaa7X(Solid _0023_003Dz6vN0uH8kboDX, Solid _0023_003Dz_0024R2cLJE7DZsJ)
	{
		sbyte b = (sbyte)((_0023_003Dz6vN0uH8kboDX == _0023_003Dz_0024R2cLJE7DZsJ) ? 1 : 0);
		for (int i = 0; i < _0023_003Dz6vN0uH8kboDX.portions.Count; i++)
		{
			NpStr npStr = _0023_003Dz6vN0uH8kboDX.NpStrList[i];
			if (npStr.lab != 0)
			{
				continue;
			}
			npStr.b = _0023_003Dz6vN0uH8kboDX.NbList.Count;
			npStr.len = 0;
			Solid.Portion portion = _0023_003Dz6vN0uH8kboDX.portions[i];
			for (int j = 0; j < _0023_003Dz_0024R2cLJE7DZsJ.portions.Count; j++)
			{
				if (_0023_003Dz_0024R2cLJE7DZsJ.NpStrList[j].lab == 0 && (i != j || b == 0))
				{
					Solid.Portion portion2 = _0023_003Dz_0024R2cLJE7DZsJ.portions[j];
					if (Utility.DoOverlapOrTouch(portion.localMin, portion.localMax, portion2.localMin, portion2.localMax))
					{
						_0023_003Dz6vN0uH8kboDX.NbList.Add(j);
					}
				}
			}
			npStr.len = _0023_003Dz6vN0uH8kboDX.NbList.Count - npStr.b;
		}
		return true;
	}

	public static _0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[] _0023_003Dzwq_iPXTmH2y7(Solid _0023_003DzcDEsV8s_003D, Region3D _0023_003Dz3cp_HP8_003D)
	{
		NpStr npStr = new NpStr();
		_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[] array = new _0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[_0023_003DzcDEsV8s_003D.portions.Count];
		for (int i = 0; i < _0023_003DzcDEsV8s_003D.portions.Count; i++)
		{
			array[i] = default(_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc);
		}
		for (int j = 0; j < _0023_003DzcDEsV8s_003D.portions.Count; j++)
		{
			npStr = _0023_003DzcDEsV8s_003D.NpStrList[j];
			array[j]._0023_003DzSkUy_T8_003D = npStr.ident;
			array[j]._0023_003DzSfQie2M_003D = npStr.hnp;
			Solid.Portion portion = _0023_003DzcDEsV8s_003D.portions[j];
			if (!Utility.DoOverlapOrTouch(portion.localMin, portion.localMax, _0023_003Dz3cp_HP8_003D.min, _0023_003Dz3cp_HP8_003D.max))
			{
				npStr.lab = -2;
			}
		}
		Array.Sort(array, _0023_003Dzo_Frw0kSOq0743BRI13GI94_003D);
		return array;
	}

	private static int _0023_003Dzo_Frw0kSOq0743BRI13GI94_003D(_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc _0023_003DzCYlGuqc_003D, _0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc _0023_003DzM9DHoIE_003D)
	{
		if (_0023_003DzCYlGuqc_003D._0023_003DzSkUy_T8_003D < _0023_003DzM9DHoIE_003D._0023_003DzSkUy_T8_003D)
		{
			return 1;
		}
		if (_0023_003DzCYlGuqc_003D._0023_003DzSkUy_T8_003D == _0023_003DzM9DHoIE_003D._0023_003DzSkUy_T8_003D)
		{
			return 0;
		}
		return 1;
	}

	public static bool _0023_003Dzv7vrvDXssqtt(NpStr _0023_003DzZ55HjW0_003D, NpStr _0023_003DzQKgWl6w_003D, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		Solid.Portion _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D;
		Solid.Portion _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D;
		_0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O = new List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D>();
		_0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb = new List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D>();
		short num = 0;
		_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D = 1;
		while (_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D <= _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.faceCount)
		{
			_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = _0023_003DzQLKKCNRzQuXx(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.faces[_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D].FaceLabel);
			if (_0023_003Dzq9H_u3Dp5eSRXEAAxJLRmGA_003D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.localMin, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.localMax, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.planes[_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D], _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
			{
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003Dzy3xqLbo_003D = 1;
				num++;
			}
			else
			{
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003Dzy3xqLbo_003D = 0;
			}
			_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.faces[_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
			_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D++;
		}
		if (num == _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.faceCount)
		{
			return true;
		}
		_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D = 1;
		while (_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D <= _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.faceCount)
		{
			if (!_0023_003Dzq9H_u3Dp5eSRXEAAxJLRmGA_003D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.localMin, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.localMax, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D], _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
			{
				_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D = 1;
				while (_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D <= _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.faceCount)
				{
					if (_0023_003DzQLKKCNRzQuXx(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.faces[_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D].FaceLabel)._0023_003Dzy3xqLbo_003D != 1 && !_0023_003Dzjs2HjMFV_0024x7Uz9lL0yCE2Ls_003D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
					{
						_0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O.Clear();
						_0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb.Clear();
						_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.novTemp = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.MaxNov;
						_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.novTemp = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.MaxNov;
						if (!_0023_003DzvbTb47elbjLr(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D, _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.planes[_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D], _0023_003DzHC7AYP4_003D))
						{
							return false;
						}
						if (_0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O.Count != 0)
						{
							if (!_0023_003DzvbTb47elbjLr(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D, _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D], _0023_003DzHC7AYP4_003D))
							{
								return false;
							}
							if (_0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb.Count != 0)
							{
								_0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx = _0023_003Dz_0024LYVLiAhnEq9(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D], _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.planes[_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D]);
								_0023_003DzCgqNlbtmU44p(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D._vertices, _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
								_0023_003DzCgqNlbtmU44p(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D._vertices, _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
								double num2 = _0023_003Dz9EtWqTI_003D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O[0]._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
								double num3 = _0023_003Dz9EtWqTI_003D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb[_0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb.Count - 1]._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
								double num4 = _0023_003Dz9EtWqTI_003D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb[0]._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
								double num5 = _0023_003Dz9EtWqTI_003D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O[_0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O.Count - 1]._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
								if (!(num2 > num3) && !(num4 > num5) && !_0023_003Dzu4eOJLs_003D(_0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
								{
									return false;
								}
							}
						}
					}
					_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D++;
				}
			}
			_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D++;
		}
		if (_0023_003DzZ55HjW0_003D.lab != 2)
		{
			for (num = 1; num <= _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.edgeCount; num++)
			{
				if (_0023_003Dzqy1hGquKIlvn(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.edgeDatas[num].Type)._0023_003Dzy3xqLbo_003D != 0)
				{
					_0023_003DzZ55HjW0_003D.lab = 2;
					break;
				}
			}
		}
		if (_0023_003DzQKgWl6w_003D.lab != 2)
		{
			for (num = 1; num <= _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeCount; num++)
			{
				if (_0023_003Dzqy1hGquKIlvn(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[num].Type)._0023_003Dzy3xqLbo_003D != 0)
				{
					_0023_003DzQKgWl6w_003D.lab = 2;
					break;
				}
			}
		}
		return true;
	}

	private static bool _0023_003Dzu4eOJLs_003D(Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		int _0023_003DzB68dg9Q_003D = -1;
		int _0023_003DzB68dg9Q_003D2 = -1;
		int _0023_003DzCaPJP54_003D = -1;
		int _0023_003DzCaPJP54_003D2 = -1;
		int _0023_003DzMlCq3wk_003D = -1;
		int _0023_003DzMlCq3wk_003D2 = -1;
		int num = 0;
		int num2 = 0;
		bool _0023_003Dz44_0024ru0s_003D = false;
		bool _0023_003Dz44_0024ru0s_003D2 = false;
		Solid.Portion _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D;
		Solid.Portion _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D;
		int maxNov = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.MaxNov;
		int vertexCount = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.vertexCount;
		int maxNov2 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.MaxNov;
		int vertexCount2 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.vertexCount;
		do
		{
			if (maxNov < _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.MaxNov)
			{
				for (int i = num; i < _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O.Count; i++)
				{
					if (_0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O[i]._0023_003Dz77g161c_003D >= vertexCount)
					{
						_0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O[i]._0023_003Dz77g161c_003D += 62;
					}
				}
				maxNov = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.MaxNov;
				vertexCount = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.vertexCount;
			}
			if (maxNov2 < _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.MaxNov)
			{
				for (int j = num2; j < _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb.Count; j++)
				{
					if (_0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb[j]._0023_003Dz77g161c_003D >= vertexCount2)
					{
						_0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb[j]._0023_003Dz77g161c_003D += 62;
					}
				}
				maxNov2 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.MaxNov;
				vertexCount2 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.vertexCount;
			}
			double num3 = _0023_003Dz9EtWqTI_003D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O[num]._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
			double num4 = _0023_003Dz9EtWqTI_003D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb[num2]._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
			if (num3 < num4)
			{
				_0023_003Dz611qY1n3rRLa(_0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O[num]._0023_003DzkKfJheA_003D, ref _0023_003DzB68dg9Q_003D, ref _0023_003DzCaPJP54_003D, ref _0023_003DzMlCq3wk_003D, ref _0023_003Dz44_0024ru0s_003D);
				num++;
			}
			else
			{
				_0023_003Dz611qY1n3rRLa(_0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb[num2]._0023_003DzkKfJheA_003D, ref _0023_003DzB68dg9Q_003D2, ref _0023_003DzCaPJP54_003D2, ref _0023_003DzMlCq3wk_003D2, ref _0023_003Dz44_0024ru0s_003D2);
				num2++;
			}
			if (_0023_003DzB68dg9Q_003D + _0023_003DzB68dg9Q_003D2 == 2 && Math.Abs(_0023_003Dz9EtWqTI_003D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O[num]._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx) - _0023_003Dz9EtWqTI_003D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb[num2 - 1]._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx)) > _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn && Math.Abs(_0023_003Dz9EtWqTI_003D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O[num - 1]._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx) - _0023_003Dz9EtWqTI_003D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb[num2]._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx)) > _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn && !_0023_003Dz1sIf7rA_003D(num, num2, _0023_003Dz44_0024ru0s_003D, _0023_003Dz44_0024ru0s_003D2, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
			{
				return false;
			}
		}
		while (num < _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O.Count && num2 < _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb.Count);
		return true;
	}

	private static bool _0023_003Dz1sIf7rA_003D(int _0023_003DzaDJvRiA_003D, int _0023_003DzzNfcBS8_003D, bool _0023_003Dz_K6gdR4_003D, bool _0023_003DzT7A75ag_003D, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		Solid.Portion _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D;
		Solid.Portion _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D;
		_0023_003DzHC7AYP4_003D._0023_003DzO0cNqQQ_003D = _0023_003DzaDJvRiA_003D;
		_0023_003DzHC7AYP4_003D._0023_003Dz9CqrEH8_003D = _0023_003DzzNfcBS8_003D;
		_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2 = _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O[_0023_003DzHC7AYP4_003D._0023_003DzO0cNqQQ_003D - 1];
		_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D3 = _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb[_0023_003DzHC7AYP4_003D._0023_003Dz9CqrEH8_003D - 1];
		_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D4 = _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O[_0023_003DzHC7AYP4_003D._0023_003DzO0cNqQQ_003D];
		_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D5 = _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb[_0023_003DzHC7AYP4_003D._0023_003Dz9CqrEH8_003D];
		double num = _0023_003Dz9EtWqTI_003D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
		double num2 = _0023_003Dz9EtWqTI_003D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D3._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
		Point3D point3D = ((!(num < num2)) ? new Point3D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2._0023_003Dz77g161c_003D].X, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2._0023_003Dz77g161c_003D].Y, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2._0023_003Dz77g161c_003D].Z) : new Point3D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D3._0023_003Dz77g161c_003D].X, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D3._0023_003Dz77g161c_003D].Y, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D3._0023_003Dz77g161c_003D].Z));
		Point3D _0023_003DzM9YhqY8_003D = point3D;
		double num3 = _0023_003Dz9EtWqTI_003D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D4._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
		num2 = _0023_003Dz9EtWqTI_003D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D5._0023_003Dz77g161c_003D, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx);
		Point3D point3D2 = ((!(num3 < num2)) ? new Point3D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D5._0023_003Dz77g161c_003D].X, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D5._0023_003Dz77g161c_003D].Y, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D5._0023_003Dz77g161c_003D].Z) : new Point3D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D4._0023_003Dz77g161c_003D].X, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D4._0023_003Dz77g161c_003D].Y, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D._vertices[_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D4._0023_003Dz77g161c_003D].Z));
		Point3D _0023_003DzcFpS4tw_003D = point3D2;
		if (_0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D == (Solid._0023_003Dz6tkLYNg_003D)3)
		{
			_0023_003DzHC7AYP4_003D._0023_003Dz_00241Cm8Ev0duOTkgUXhA_003D_003D.Add(new Segment3D(new Point3D(_0023_003DzM9YhqY8_003D.X, _0023_003DzM9YhqY8_003D.Y, _0023_003DzM9YhqY8_003D.Z), new Point3D(_0023_003DzcFpS4tw_003D.X, _0023_003DzcFpS4tw_003D.Y, _0023_003DzcFpS4tw_003D.Z)));
			return true;
		}
		int num4 = 0;
		if (!_0023_003Dz_K6gdR4_003D && !_0023_003DzT7A75ag_003D)
		{
			num4 = 1;
			if (_0023_003DzebvCIRvgO6aU(ref _0023_003DzM9YhqY8_003D, ref _0023_003DzcFpS4tw_003D, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
			{
				return true;
			}
			return false;
		}
		if (!_0023_003Dz_K6gdR4_003D)
		{
			num4 = 1;
			_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 2;
		}
		if (!_0023_003DzT7A75ag_003D)
		{
			num4 = 2;
			_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 1;
		}
		if (num4 != 0)
		{
			if (_0023_003Dz6e7lS8Zk_4Au(num4, ref _0023_003DzM9YhqY8_003D, ref _0023_003DzcFpS4tw_003D, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
			{
				return true;
			}
			return false;
		}
		if (_0023_003Dzf8FsR0vRKrZd(_0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
		{
			return true;
		}
		return false;
	}

	public static List<Segment3D> _0023_003Dzdv4W6TqXsv_PKbpd6A_003D_003D(_0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		return _0023_003DzHC7AYP4_003D._0023_003Dz_00241Cm8Ev0duOTkgUXhA_003D_003D;
	}

	private static bool _0023_003Dzf8FsR0vRKrZd(Point3D _0023_003DzM9YhqY8_003D, Point3D _0023_003DzcFpS4tw_003D, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		Solid.Portion _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D;
		Solid.Portion _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D;
		BoolUser[] user = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.user;
		BoolUser[] user2 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.user;
		_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 1;
		int _0023_003DzRpXgovo_003D = _0023_003DzwfygHWXTZF7e(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O, _0023_003DzHC7AYP4_003D._0023_003DzO0cNqQQ_003D);
		if ((_0023_003DzRpXgovo_003D = _0023_003Dz1M6nQbjAWGoN(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O, _0023_003DzHC7AYP4_003D._0023_003DzO0cNqQQ_003D, _0023_003DzRpXgovo_003D, _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003DzvuKzWCk_003D)) == 0)
		{
			return false;
		}
		int num = Math.Abs(_0023_003DzRpXgovo_003D);
		_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 2;
		int _0023_003DzRpXgovo_003D2 = _0023_003DzwfygHWXTZF7e(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb, _0023_003DzHC7AYP4_003D._0023_003Dz9CqrEH8_003D);
		if ((_0023_003DzRpXgovo_003D2 = _0023_003Dz1M6nQbjAWGoN(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb, _0023_003DzHC7AYP4_003D._0023_003Dz9CqrEH8_003D, _0023_003DzRpXgovo_003D2, _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003DzvuKzWCk_003D)) == 0)
		{
			return false;
		}
		int num2 = Math.Abs(_0023_003DzRpXgovo_003D2);
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = default(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D);
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3 = default(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D);
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.edgeDatas[num].Type);
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3 = _0023_003Dzqy1hGquKIlvn(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[num2].Type);
		if (_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D == 1 && _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dzy3xqLbo_003D == 1)
		{
			return true;
		}
		int num3 = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.edgeDatas[num].NextFace;
		int num4 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[num2].NextFace;
		int num5 = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.edgeDatas[num].PreviousFace;
		int num6 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[num2].PreviousFace;
		int num7 = 0;
		int num8 = 0;
		if (num3 == 0 || num5 == 0)
		{
			if (!_0023_003DzvuKzWCk_003D._0023_003Dz4YMDud0EzJJX)
			{
				if (num3 == 0)
				{
					_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[0].D = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[num5].D;
					_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[0].X = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[num5].X;
					_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[0].Y = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[num5].Y;
					_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[0].Z = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[num5].Z;
				}
				else
				{
					_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[0].D = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[num3].D;
					_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[0].X = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[num3].X;
					_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[0].Y = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[num3].Y;
					_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[0].Z = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[num3].Z;
				}
			}
		}
		else if (num3 < 0 || num5 < 0)
		{
			if (num3 < 0)
			{
				num3 = _0023_003DzEMfkCa7_0024_Tbm(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, num);
				num7 = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.edgeDatas[num].NextEdge;
			}
			else
			{
				num5 = _0023_003DzEMfkCa7_0024_Tbm(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, num);
				num7 = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.edgeDatas[num].PreviousEdge;
			}
		}
		if (num4 < 0 || num6 < 0)
		{
			if (num4 < 0)
			{
				num4 = _0023_003DzEMfkCa7_0024_Tbm(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, num2);
				num8 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[num2].NextEdge;
			}
			else
			{
				num6 = _0023_003DzEMfkCa7_0024_Tbm(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, num2);
				num8 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[num2].PreviousEdge;
			}
		}
		int num9 = 0;
		if (_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D == 0)
		{
			short _0023_003Dz79R_0024VZY_003D = _0023_003DzRzqFnX8_003D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, num2, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.planes[num6]);
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = _0023_003DzAk3MKsZIF6SE(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, num, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, num4, num6, _0023_003Dz79R_0024VZY_003D);
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = _0023_003DzAk3MKsZIF6SE(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, -num, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, num4, num6, _0023_003Dz79R_0024VZY_003D);
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 1;
			_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.edgeDatas[num].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
		}
		else
		{
			num9 = 1;
		}
		int num10 = 0;
		if (_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dzy3xqLbo_003D == 0)
		{
			short _0023_003Dz79R_0024VZY_003D2 = _0023_003DzRzqFnX8_003D(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, num, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[num5]);
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dzi6QKiYM_003D = _0023_003DzAk3MKsZIF6SE(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, num2, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, num3, num5, _0023_003Dz79R_0024VZY_003D2);
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dz3u03JZA_003D = _0023_003DzAk3MKsZIF6SE(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, -num2, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, num3, num5, _0023_003Dz79R_0024VZY_003D2);
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dzy3xqLbo_003D = 1;
			_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[num2].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3);
		}
		else
		{
			num10 = 1;
		}
		if (!_0023_003DzvuKzWCk_003D._0023_003Dz4YMDud0EzJJX)
		{
			user = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.user;
			user[Math.Abs(_0023_003DzRpXgovo_003D)].bnd = 0f;
			user[Math.Abs(_0023_003DzRpXgovo_003D)].ind = 0;
			return true;
		}
		short num11 = 0;
		int num12 = 0;
		int _0023_003DzRpXgovo_003D3 = 0;
		_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 1;
		if (_0023_003Dzs_yBhgQ3xpKa(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D, _0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D, _0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D) == 1)
		{
			num12 = num3;
			_0023_003DzRpXgovo_003D3 = num;
			num11++;
		}
		if (_0023_003Dzs_yBhgQ3xpKa(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D, _0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D, _0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D) == 1)
		{
			num12 = num5;
			_0023_003DzRpXgovo_003D3 = -num;
			num11++;
		}
		int _0023_003Dzi6QKiYM_003D = _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dzi6QKiYM_003D;
		short num13 = 0;
		int num14 = 0;
		_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 2;
		if (_0023_003Dzs_yBhgQ3xpKa(_0023_003Dzi6QKiYM_003D, _0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D, _0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D) == 1)
		{
			num14 = num4;
			num13++;
		}
		if (_0023_003Dzs_yBhgQ3xpKa(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dz3u03JZA_003D, _0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D, _0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D) == 1)
		{
			num14 = num6;
			num13++;
		}
		if ((num11 == 2 && num13 == 0) || (num11 == 0 && num13 == 2) || (num11 == 0 && num13 == 0))
		{
			return true;
		}
		if (num11 == 1 && num13 == 1)
		{
			PlaneEquation planeEquation = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.planes[num12];
			PlaneEquation planeEquation2 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.planes[num14];
			Vector3D _0023_003DzLlLRwFw_003D = new Vector3D(planeEquation.X, planeEquation.Y, planeEquation.Z);
			Vector3D vector3D = new Vector3D(planeEquation2.X, planeEquation2.Y, planeEquation2.Z);
			if (_0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D == (Solid._0023_003Dz6tkLYNg_003D)2)
			{
				vector3D.X = 0.0 - vector3D.X;
				vector3D.Y = 0.0 - vector3D.Y;
				vector3D.Z = 0.0 - vector3D.Z;
			}
			float num15 = 0f;
			if ((num15 = _0023_003Dz1zs3WXHrvefg(_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzRpXgovo_003D3, _0023_003DzLlLRwFw_003D, vector3D)) == 0f)
			{
				return false;
			}
			int num16 = 0;
			if (num9 == 0)
			{
				user[num].bnd = num15;
				if (num14 == 0)
				{
					user[num].ind = num8;
				}
				else
				{
					user[num].ind = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.Id;
				}
				if (num12 == 0 && (_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D == 2 || _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D == 3 || _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D == 2 || _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D == 3))
				{
					if ((num16 = _0023_003Dz23oII3NiRA_s(_0023_003DzvuKzWCk_003D._0023_003Dz4aj0xv0_003D, _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count, num7)) == 0)
					{
						return false;
					}
					if (_0023_003DzaEu_fdIn8c6U(_0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions[num16 - 1], _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, num, _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D, _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D, _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn) == 0)
					{
						return false;
					}
				}
			}
			if (num10 == 0)
			{
				user2[num2].bnd = num15;
				if (num12 == 0)
				{
					user2[num2].ind = num7;
				}
				else
				{
					user2[num2].ind = _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.Id;
				}
				if (num14 == 0 && (_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dzi6QKiYM_003D == 2 || _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dzi6QKiYM_003D == 3 || _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dz3u03JZA_003D == 2 || _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dz3u03JZA_003D == 3))
				{
					if ((num16 = _0023_003Dz23oII3NiRA_s(_0023_003DzvuKzWCk_003D._0023_003DzLM7JUrs_003D, _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions.Count, num8)) == 0)
					{
						return false;
					}
					if (_0023_003DzaEu_fdIn8c6U(_0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions[num16 - 1], _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, num2, _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D, _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D, _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn) == 0)
					{
						return false;
					}
				}
			}
			return true;
		}
		return false;
	}

	private static int _0023_003DzaEu_fdIn8c6U(Solid.Portion _0023_003Dzd9ZyL64_003D, Point3D _0023_003DzM9YhqY8_003D, Point3D _0023_003DzcFpS4tw_003D, Solid.Portion _0023_003Dzlj3HQI8_003D, int _0023_003DzTx2aqr8_003D, Solid _0023_003DzBo2VLX0_003D, Solid _0023_003Dz9K_0024eZOY_003D, Solid.Portion _0023_003DzjaJkTOR_0024GKMNl0le3g_003D_003D, double _0023_003DzkRSfKls1SLfn)
	{
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = default(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D);
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3 = default(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D);
		Solid _0023_003DzcDEsV8s_003D = ((_0023_003Dzlj3HQI8_003D != _0023_003DzjaJkTOR_0024GKMNl0le3g_003D_003D) ? _0023_003Dz9K_0024eZOY_003D : _0023_003DzBo2VLX0_003D);
		int num = 0;
		if ((num = _0023_003Dzm5__9a3ldgcf(_0023_003Dzd9ZyL64_003D, _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003Dzlj3HQI8_003D.Id, _0023_003DzkRSfKls1SLfn)) == 0)
		{
			return 0;
		}
		_0023_003Dzd9ZyL64_003D.user[num].bnd = _0023_003Dzlj3HQI8_003D.user[_0023_003DzTx2aqr8_003D].bnd;
		_0023_003Dzd9ZyL64_003D.user[num].ind = _0023_003Dzlj3HQI8_003D.user[_0023_003DzTx2aqr8_003D].ind;
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3 = _0023_003Dzqy1hGquKIlvn(_0023_003Dzlj3HQI8_003D.edgeDatas[_0023_003DzTx2aqr8_003D].Type);
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(_0023_003Dzd9ZyL64_003D.edgeDatas[num].Type);
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 1;
		if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dzlj3HQI8_003D._vertices[_0023_003Dzlj3HQI8_003D.edgeDatas[_0023_003DzTx2aqr8_003D].BeginVertex], _0023_003Dzd9ZyL64_003D._vertices[_0023_003Dzd9ZyL64_003D.edgeDatas[num].BeginVertex], _0023_003DzkRSfKls1SLfn))
		{
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dz3u03JZA_003D;
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dzi6QKiYM_003D;
		}
		else
		{
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dzi6QKiYM_003D;
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D3._0023_003Dz3u03JZA_003D;
		}
		_0023_003Dzd9ZyL64_003D.edgeDatas[num].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
		NpStr npStr = new NpStr();
		if (!_0023_003DzqZtmF1Q1XoHn(_0023_003DzcDEsV8s_003D, _0023_003Dzd9ZyL64_003D.Id, npStr, out var _0023_003Dz_0024n2nrac_003D))
		{
			return 0;
		}
		npStr.lab = 2;
		_0023_003Dz_0024n2nrac_003D._0023_003DzbByTzLTAlIM7(npStr);
		return 1;
	}

	public static bool _0023_003DzqZtmF1Q1XoHn(Solid _0023_003DzcDEsV8s_003D, int _0023_003DzSkUy_T8_003D, NpStr _0023_003DzZ55HjW0_003D, out NpStr _0023_003Dz_0024n2nrac_003D)
	{
		if (_0023_003DzcDEsV8s_003D.NpStrDict.TryGetValue(_0023_003DzSkUy_T8_003D, out var value))
		{
			_0023_003DzZ55HjW0_003D._0023_003DzbByTzLTAlIM7(value);
			_0023_003Dz_0024n2nrac_003D = value;
			return true;
		}
		_0023_003Dz_0024n2nrac_003D = null;
		return false;
	}

	private static short _0023_003DzAk3MKsZIF6SE(Solid.Portion _0023_003Dz2JIjXEo_003D, int _0023_003DzRpXgovo_003D, Solid.Portion _0023_003DzShwwkvI_003D, int _0023_003DzLlLRwFw_003D, int _0023_003Dz2QNSBWU_003D, short _0023_003Dz79R_0024VZY_003D)
	{
		short[,] array = new short[3, 3]
		{
			{ 1, 3, 0 },
			{ 2, 2, 0 },
			{ 0, 0, 0 }
		};
		short[,] array2 = new short[3, 3]
		{
			{ 1, 1, 1 },
			{ 1, 2, 2 },
			{ 1, 3, 0 }
		};
		int num = ((_0023_003DzRpXgovo_003D <= 0) ? _0023_003Dz2JIjXEo_003D.edgeDatas[-_0023_003DzRpXgovo_003D].PreviousFace : _0023_003Dz2JIjXEo_003D.edgeDatas[_0023_003DzRpXgovo_003D].NextFace);
		if (num < 0)
		{
			num = 0;
		}
		short num2 = _0023_003DzRzqFnX8_003D(_0023_003Dz2JIjXEo_003D, _0023_003DzRpXgovo_003D, _0023_003DzShwwkvI_003D.planes[_0023_003DzLlLRwFw_003D]);
		num2++;
		short num3 = _0023_003DzRzqFnX8_003D(_0023_003Dz2JIjXEo_003D, _0023_003DzRpXgovo_003D, _0023_003DzShwwkvI_003D.planes[_0023_003Dz2QNSBWU_003D]);
		num3++;
		short num4 = ((_0023_003Dz79R_0024VZY_003D >= 0) ? array2[num2, num3] : array[num2, num3]);
		switch (num4)
		{
		case 2:
		{
			Vector3D vector3D3 = _0023_003Dz2JIjXEo_003D.planes[num];
			Vector3D vector3D4 = _0023_003DzShwwkvI_003D.planes[_0023_003DzLlLRwFw_003D];
			if (Math.Abs(vector3D3.X - vector3D4.X) < 1E-06 && Math.Abs(vector3D3.Y - vector3D4.Y) < 1E-06 && Math.Abs(vector3D3.Z - vector3D4.Z) < 1E-06)
			{
				return 3;
			}
			return 2;
		}
		case 3:
		{
			Vector3D vector3D = _0023_003Dz2JIjXEo_003D.planes[num];
			Vector3D vector3D2 = _0023_003DzShwwkvI_003D.planes[_0023_003Dz2QNSBWU_003D];
			if (Math.Abs(vector3D.X - vector3D2.X) < 1E-06 && Math.Abs(vector3D.Y - vector3D2.Y) < 1E-06 && Math.Abs(vector3D.Z - vector3D2.Z) < 1E-06)
			{
				return 3;
			}
			return 2;
		}
		default:
			return num4;
		}
	}

	private static int _0023_003DzwfygHWXTZF7e(Solid.Portion _0023_003Dzd9ZyL64_003D, List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzPo_ODtE_003D, int _0023_003Dzhr9krZQ_003D)
	{
		int _0023_003DzRpXgovo_003D = _0023_003DzPo_ODtE_003D[_0023_003Dzhr9krZQ_003D]._0023_003DzRpXgovo_003D;
		int _0023_003DzRpXgovo_003D2 = _0023_003DzPo_ODtE_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003DzRpXgovo_003D;
		int _0023_003Dz77g161c_003D = _0023_003DzPo_ODtE_003D[_0023_003Dzhr9krZQ_003D]._0023_003Dz77g161c_003D;
		int _0023_003Dz77g161c_003D2 = _0023_003DzPo_ODtE_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003Dz77g161c_003D;
		int beginVertex = _0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(_0023_003DzRpXgovo_003D)].BeginVertex;
		int endVertex = _0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(_0023_003DzRpXgovo_003D)].EndVertex;
		if ((_0023_003Dz77g161c_003D == beginVertex && _0023_003Dz77g161c_003D2 == endVertex) || (_0023_003Dz77g161c_003D == endVertex && _0023_003Dz77g161c_003D2 == beginVertex))
		{
			return _0023_003DzRpXgovo_003D;
		}
		return _0023_003DzRpXgovo_003D2;
	}

	private static bool _0023_003Dz6e7lS8Zk_4Au(int _0023_003DzTpPvwIU_003D, ref Point3D _0023_003DzM9YhqY8_003D, ref Point3D _0023_003DzcFpS4tw_003D, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		Solid.Portion portion;
		Solid.Portion _0023_003Dzd9ZyL64_003D;
		List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> list;
		int _0023_003Dzhr9krZQ_003D;
		List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzUs3eak4_003D;
		int _0023_003Dzhr9krZQ_003D2;
		int num;
		Solid solid;
		_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[] _0023_003Dzp5xMQUk_003D;
		int count;
		BoolUser[] user;
		BoolUser[] user2;
		if (_0023_003DzTpPvwIU_003D == 1)
		{
			portion = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D;
			_0023_003Dzd9ZyL64_003D = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D;
			list = _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb;
			_0023_003Dzhr9krZQ_003D = _0023_003DzHC7AYP4_003D._0023_003Dz9CqrEH8_003D;
			_0023_003DzUs3eak4_003D = _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O;
			_0023_003Dzhr9krZQ_003D2 = _0023_003DzHC7AYP4_003D._0023_003DzO0cNqQQ_003D;
			num = _0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D;
			solid = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D;
			_0023_003Dzp5xMQUk_003D = _0023_003DzvuKzWCk_003D._0023_003DzLM7JUrs_003D;
			count = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions.Count;
			user = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.user;
			user2 = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.user;
		}
		else
		{
			portion = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D;
			_0023_003Dzd9ZyL64_003D = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D;
			list = _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O;
			_0023_003Dzhr9krZQ_003D = _0023_003DzHC7AYP4_003D._0023_003DzO0cNqQQ_003D;
			_0023_003DzUs3eak4_003D = _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb;
			_0023_003Dzhr9krZQ_003D2 = _0023_003DzHC7AYP4_003D._0023_003Dz9CqrEH8_003D;
			num = _0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D;
			solid = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D;
			_0023_003Dzp5xMQUk_003D = _0023_003DzvuKzWCk_003D._0023_003Dz4aj0xv0_003D;
			count = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count;
			user = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.user;
			user2 = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.user;
		}
		int num2 = _0023_003Dzl3fpcQ0czKjt(portion, list, _0023_003Dzhr9krZQ_003D);
		int num3;
		int num4;
		int num5;
		if (num2 > 0)
		{
			num3 = portion.edgeDatas[num2].NextFace;
			num4 = portion.edgeDatas[num2].PreviousFace;
			num5 = portion.edgeDatas[num2].PreviousEdge;
		}
		else
		{
			num3 = portion.edgeDatas[-num2].PreviousFace;
			num4 = portion.edgeDatas[-num2].NextFace;
			num5 = portion.edgeDatas[-num2].NextEdge;
		}
		int _0023_003DzbfrNXYE_003D = Math.Abs(num2);
		if (num4 == 0)
		{
			if (_0023_003DzvuKzWCk_003D._0023_003Dz4YMDud0EzJJX || _0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D != 1)
			{
				return false;
			}
			portion.planes[0] = (PlaneEquation)portion.planes[num3].Clone();
		}
		else if (num4 < 0)
		{
			num4 = _0023_003DzEMfkCa7_0024_Tbm(portion, _0023_003DzbfrNXYE_003D);
		}
		if ((num2 = _0023_003Dz1M6nQbjAWGoN(portion, list, _0023_003Dzhr9krZQ_003D, num2, _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003DzvuKzWCk_003D)) == 0)
		{
			return false;
		}
		if (_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D == 1)
		{
			_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 2;
		}
		else
		{
			_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 1;
		}
		short num6 = _0023_003DzRzqFnX8_003D(portion, num2, _0023_003Dzd9ZyL64_003D.planes[num]);
		short num7 = _0023_003DzRzqFnX8_003D(portion, -num2, _0023_003Dzd9ZyL64_003D.planes[num]);
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = default(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D);
		if (num6 == num7)
		{
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(portion.edgeDatas[Math.Abs(num2)].Type);
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 1;
			short num8 = _0023_003DzRzqFnX8_003D(portion, num2, portion.planes[num4]);
			if (num6 == 1)
			{
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 0;
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 0;
				portion.edgeDatas[Math.Abs(num2)].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
				if (num8 == -1)
				{
					if (_0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D != 0)
					{
						return true;
					}
				}
				else if (_0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D != (Solid._0023_003Dz6tkLYNg_003D)2 || _0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D != 2)
				{
					return true;
				}
			}
			else
			{
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 1;
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 1;
				portion.edgeDatas[Math.Abs(num2)].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
				if (num8 == -1)
				{
					if (_0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D != (Solid._0023_003Dz6tkLYNg_003D)2 || _0023_003DzTpPvwIU_003D != 1)
					{
						return true;
					}
				}
				else if (_0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D != (Solid._0023_003Dz6tkLYNg_003D)1)
				{
					return true;
				}
			}
			return false;
		}
		int num9;
		if (num6 == -num7)
		{
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(portion.edgeDatas[Math.Abs(num2)].Type);
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 1;
			if ((num2 > 0 && num6 == -1) || (num2 < 0 && num6 == 1))
			{
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 1;
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 0;
			}
			else
			{
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 0;
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 1;
			}
			portion.edgeDatas[Math.Abs(num2)].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
			if (!_0023_003DzIMKWzdPmhXEx(ref _0023_003DzM9YhqY8_003D, ref _0023_003DzcFpS4tw_003D, _0023_003Dzd9ZyL64_003D.planes[num], portion.planes[num3], _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
			{
				return false;
			}
			num9 = Math.Abs(_0023_003DzmKlXCG4vT3tu(ref _0023_003Dzd9ZyL64_003D, _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003DzUs3eak4_003D, _0023_003Dzhr9krZQ_003D2, num, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D));
			if (num9 == 0)
			{
				return false;
			}
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(_0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(num9)].Type);
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 1;
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 0;
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 1;
			_0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(num9)].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
		}
		else
		{
			Vector3D vector3D = _0023_003Dzd9ZyL64_003D.planes[num];
			Vector3D vector3D2 = portion.planes[num4];
			if (Math.Abs(vector3D.X - vector3D2.X) < 1E-06 && Math.Abs(vector3D.Y - vector3D2.Y) < 1E-06 && Math.Abs(vector3D.Z - vector3D2.Z) < 1E-06)
			{
				if (!_0023_003Dz27FdJ7LZRyah(portion, -num2, ref _0023_003DzM9YhqY8_003D, ref _0023_003DzcFpS4tw_003D, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
				{
					return false;
				}
				num9 = Math.Abs(_0023_003DzmKlXCG4vT3tu(ref _0023_003Dzd9ZyL64_003D, _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003DzUs3eak4_003D, _0023_003Dzhr9krZQ_003D2, num, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D));
				if (num9 == 0)
				{
					return false;
				}
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(portion.edgeDatas[Math.Abs(num2)].Type);
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 1;
				if (num2 > 0)
				{
					_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 3;
					if (num6 > 0)
					{
						_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 0;
					}
					else
					{
						_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 1;
					}
				}
				else
				{
					_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 3;
					if (num6 > 0)
					{
						_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 0;
					}
					else
					{
						_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 1;
					}
				}
				portion.edgeDatas[Math.Abs(num2)].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(_0023_003Dzd9ZyL64_003D.edgeDatas[num9].Type);
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 1;
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 3;
				if (num6 > 0)
				{
					_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 1;
				}
				else
				{
					_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 0;
				}
				_0023_003Dzd9ZyL64_003D.edgeDatas[num9].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
			}
			else
			{
				if (!_0023_003Dz27FdJ7LZRyah(portion, num2, ref _0023_003DzM9YhqY8_003D, ref _0023_003DzcFpS4tw_003D, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
				{
					return false;
				}
				num9 = Math.Abs(_0023_003DzmKlXCG4vT3tu(ref _0023_003Dzd9ZyL64_003D, _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003DzUs3eak4_003D, _0023_003Dzhr9krZQ_003D2, num, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D));
				if (num9 == 0)
				{
					return false;
				}
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(portion.edgeDatas[Math.Abs(num2)].Type);
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 1;
				if (num2 > 0)
				{
					_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 2;
					if (num6 > 0)
					{
						_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 0;
					}
					else
					{
						_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 1;
					}
				}
				else
				{
					_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 2;
					if (num6 > 0)
					{
						_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 0;
					}
					else
					{
						_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 1;
					}
				}
				portion.edgeDatas[Math.Abs(num2)].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(_0023_003Dzd9ZyL64_003D.edgeDatas[num9].Type);
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 1;
				_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 2;
				if (num6 > 0)
				{
					_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 0;
				}
				else
				{
					_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 1;
				}
				_0023_003Dzd9ZyL64_003D.edgeDatas[num9].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
			}
		}
		if (!_0023_003DzvuKzWCk_003D._0023_003Dz4YMDud0EzJJX)
		{
			int value = ((_0023_003DzTpPvwIU_003D != 1) ? num9 : num2);
			BoolUser[] user3 = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.user;
			user3[Math.Abs(value)].bnd = 0f;
			user3[Math.Abs(value)].ind = 0;
			return true;
		}
		_0023_003DzbfrNXYE_003D = Math.Abs(num2);
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(portion.edgeDatas[_0023_003DzbfrNXYE_003D].Type);
		int _0023_003DzfUgV2P8_003D;
		int _0023_003DzfUgV2P8_003D2;
		if (num2 > 0)
		{
			_0023_003DzfUgV2P8_003D = _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D;
			_0023_003DzfUgV2P8_003D2 = _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D;
		}
		else
		{
			_0023_003DzfUgV2P8_003D = _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D;
			_0023_003DzfUgV2P8_003D2 = _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D;
		}
		if (_0023_003DzTpPvwIU_003D == 1)
		{
			_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 2;
		}
		else
		{
			_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 1;
		}
		int num10 = 0;
		int num11 = 0;
		if (_0023_003Dzs_yBhgQ3xpKa(_0023_003DzfUgV2P8_003D, _0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D, _0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D) == 1)
		{
			num11 = num3;
			num10++;
		}
		if (_0023_003Dzs_yBhgQ3xpKa(_0023_003DzfUgV2P8_003D2, _0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D, _0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D) == 1)
		{
			num11 = num4;
			num2 = -num2;
			num10++;
		}
		if (num10 == 0 || num10 == 2)
		{
			return true;
		}
		PlaneEquation planeEquation = portion.planes[num11];
		PlaneEquation planeEquation2 = _0023_003Dzd9ZyL64_003D.planes[num];
		Vector3D vector3D3 = new Vector3D(planeEquation.X, planeEquation.Y, planeEquation.Z);
		Vector3D vector3D4 = new Vector3D(planeEquation2.X, planeEquation2.Y, planeEquation2.Z);
		if (_0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D == (Solid._0023_003Dz6tkLYNg_003D)2)
		{
			if (_0023_003DzTpPvwIU_003D == 2)
			{
				vector3D4.X = 0.0 - vector3D4.X;
				vector3D4.Y = 0.0 - vector3D4.Y;
				vector3D4.Z = 0.0 - vector3D4.Z;
			}
			else
			{
				vector3D3.X = 0.0 - vector3D3.X;
				vector3D3.Y = 0.0 - vector3D3.Y;
				vector3D3.Z = 0.0 - vector3D3.Z;
				num2 = -num2;
			}
		}
		float bnd;
		if ((bnd = _0023_003Dz1zs3WXHrvefg(portion, num2, vector3D3, vector3D4)) == 0f)
		{
			return false;
		}
		if (_0023_003DzTpPvwIU_003D == 1)
		{
			user = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.user;
			user2 = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.user;
		}
		else
		{
			user = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.user;
			user2 = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.user;
		}
		user2[Math.Abs(num9)].bnd = bnd;
		if (num11 == 0)
		{
			user2[Math.Abs(num9)].ind = num5;
			user[_0023_003DzbfrNXYE_003D].bnd = bnd;
			user[_0023_003DzbfrNXYE_003D].ind = _0023_003Dzd9ZyL64_003D.Id;
			if (num6 == 0 || num7 == 0)
			{
				int num12;
				if ((num12 = _0023_003Dz23oII3NiRA_s(_0023_003Dzp5xMQUk_003D, count, num5)) == 0)
				{
					return false;
				}
				if (_0023_003DzaEu_fdIn8c6U(solid.portions[num12 - 1], _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, portion, _0023_003DzbfrNXYE_003D, _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D, _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D, _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn) == 0)
				{
					return false;
				}
			}
		}
		else
		{
			user2[Math.Abs(num9)].ind = portion.Id;
			user[_0023_003DzbfrNXYE_003D].bnd = bnd;
			user[_0023_003DzbfrNXYE_003D].ind = _0023_003Dzd9ZyL64_003D.Id;
		}
		return true;
	}

	private static _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D _0023_003Dzqy1hGquKIlvn(int _0023_003Dzx63Fsgc_003D)
	{
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D result = default(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D);
		result._0023_003Dz3u03JZA_003D = (_0023_003Dzx63Fsgc_003D & 0xC000) >> 14;
		result._0023_003Dzi6QKiYM_003D = (_0023_003Dzx63Fsgc_003D & 0x3000) >> 12;
		result._0023_003Dzy3xqLbo_003D = (_0023_003Dzx63Fsgc_003D & 0x800) >> 11;
		result._0023_003DzlKOndk0_003D = _0023_003Dzx63Fsgc_003D & 0x7FF;
		return result;
	}

	private static int _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D _0023_003Dz1v6oPQk_003D)
	{
		return (_0023_003Dz1v6oPQk_003D._0023_003Dz3u03JZA_003D << 14) | (_0023_003Dz1v6oPQk_003D._0023_003Dzi6QKiYM_003D << 12) | (_0023_003Dz1v6oPQk_003D._0023_003Dzy3xqLbo_003D << 11) | _0023_003Dz1v6oPQk_003D._0023_003DzlKOndk0_003D;
	}

	private static _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzQLKKCNRzQuXx(int _0023_003DztnI8CIs_003D)
	{
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D result = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		result._0023_003DzfUgV2P8_003D = (_0023_003DztnI8CIs_003D & 0x8000) >> 15;
		result._0023_003Dzy3xqLbo_003D = (_0023_003DztnI8CIs_003D & 0x4000) >> 14;
		result._0023_003DzlKOndk0_003D = _0023_003DztnI8CIs_003D & 0x3FFF;
		return result;
	}

	private static int _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003Dz1v6oPQk_003D)
	{
		return (_0023_003Dz1v6oPQk_003D._0023_003DzfUgV2P8_003D << 15) | (_0023_003Dz1v6oPQk_003D._0023_003Dzy3xqLbo_003D << 14) | _0023_003Dz1v6oPQk_003D._0023_003DzlKOndk0_003D;
	}

	private static short _0023_003Dzs_yBhgQ3xpKa(int _0023_003DzfUgV2P8_003D, Solid._0023_003Dz6tkLYNg_003D _0023_003DzGGUd1aw_003D, int _0023_003Dz7zWca9I_003D)
	{
		switch (_0023_003DzGGUd1aw_003D)
		{
		case (Solid._0023_003Dz6tkLYNg_003D)0:
			switch (_0023_003DzfUgV2P8_003D)
			{
			case 0:
				return 1;
			case 3:
				if (_0023_003Dz7zWca9I_003D == 1)
				{
					return 1;
				}
				return 0;
			default:
				return 0;
			}
		case (Solid._0023_003Dz6tkLYNg_003D)1:
			switch (_0023_003DzfUgV2P8_003D)
			{
			case 1:
				return 1;
			case 3:
				if (_0023_003Dz7zWca9I_003D == 1)
				{
					return 1;
				}
				return 0;
			default:
				return 0;
			}
		case (Solid._0023_003Dz6tkLYNg_003D)2:
			if (_0023_003Dz7zWca9I_003D == 1)
			{
				if (_0023_003DzfUgV2P8_003D == 0 || _0023_003DzfUgV2P8_003D == 2)
				{
					return 1;
				}
				return 0;
			}
			if (_0023_003DzfUgV2P8_003D == 1)
			{
				return 1;
			}
			return 0;
		default:
			return 0;
		}
	}

	private static bool _0023_003Dz27FdJ7LZRyah(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzRpXgovo_003D, ref Point3D _0023_003DzM9YhqY8_003D, ref Point3D _0023_003DzcFpS4tw_003D, double _0023_003DzkRSfKls1SLfn)
	{
		int num = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(_0023_003DzRpXgovo_003D, _0023_003Dzd9ZyL64_003D);
		int num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(_0023_003DzRpXgovo_003D, _0023_003Dzd9ZyL64_003D);
		Vector3D vector3D = Vector3D.Subtract(_0023_003DzcFpS4tw_003D, _0023_003DzM9YhqY8_003D);
		Vector3D vector3D2 = Vector3D.Subtract(_0023_003Dzd9ZyL64_003D._vertices[num2], _0023_003Dzd9ZyL64_003D._vertices[num]);
		if (!vector3D.Normalize())
		{
			return false;
		}
		if (!vector3D2.Normalize())
		{
			return false;
		}
		if (_0023_003DzMeLY8V4_003D(Vector3D.Dot(vector3D, vector3D2), _0023_003DzkRSfKls1SLfn) < 0)
		{
			Utility.Swap(ref _0023_003DzM9YhqY8_003D, ref _0023_003DzcFpS4tw_003D);
		}
		return true;
	}

	private static short _0023_003DzRzqFnX8_003D(Solid.Portion _0023_003Dz2JIjXEo_003D, int _0023_003DzRpXgovo_003D, PlaneEquation _0023_003Dzi4cdUYM_003D)
	{
		int num = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(_0023_003DzRpXgovo_003D, _0023_003Dz2JIjXEo_003D);
		int num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(_0023_003DzRpXgovo_003D, _0023_003Dz2JIjXEo_003D);
		int num3 = ((_0023_003DzRpXgovo_003D <= 0) ? _0023_003Dz2JIjXEo_003D.edgeDatas[-_0023_003DzRpXgovo_003D].PreviousFace : _0023_003Dz2JIjXEo_003D.edgeDatas[_0023_003DzRpXgovo_003D].NextFace);
		if (num3 < 0)
		{
			num3 = 0;
		}
		Vector3D vector3D = Vector3D.Subtract(_0023_003Dz2JIjXEo_003D._vertices[num2], _0023_003Dz2JIjXEo_003D._vertices[num]);
		if (!vector3D.Normalize())
		{
			vector3D.X = (vector3D.Y = (vector3D.Z = 0.0));
		}
		Vector3D vector3D2 = Vector3D.Cross(_0023_003Dz2JIjXEo_003D.planes[num3], vector3D);
		vector3D2.X += _0023_003Dz2JIjXEo_003D._vertices[num].X;
		vector3D2.Y += _0023_003Dz2JIjXEo_003D._vertices[num].Y;
		vector3D2.Z += _0023_003Dz2JIjXEo_003D._vertices[num].Z;
		return _0023_003DzMeLY8V4_003D(_0023_003Dzi4cdUYM_003D.X * vector3D2.X + _0023_003Dzi4cdUYM_003D.Y * vector3D2.Y + _0023_003Dzi4cdUYM_003D.Z * vector3D2.Z + _0023_003Dzi4cdUYM_003D.D, Utility._0023_003DzxhnLabVjXjPg);
	}

	private static int _0023_003Dz1M6nQbjAWGoN(Solid.Portion _0023_003Dzd9ZyL64_003D, List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzqQtwmz8_003D, int _0023_003Dzhr9krZQ_003D, int _0023_003DzRpXgovo_003D, Point3D _0023_003DzM9YhqY8_003D, Point3D _0023_003DzcFpS4tw_003D, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D)
	{
		int num;
		if ((num = _0023_003Dzmdel3ZTIgMDe(ref _0023_003Dzd9ZyL64_003D, _0023_003DzM9YhqY8_003D, _0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn)) == -1)
		{
			return 0;
		}
		int num2;
		if ((num2 = _0023_003Dzmdel3ZTIgMDe(ref _0023_003Dzd9ZyL64_003D, _0023_003DzcFpS4tw_003D, _0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn)) == -1)
		{
			return 0;
		}
		int num3 = _0023_003DzRpXgovo_003D;
		int _0023_003DzRpXgovo_003D2 = _0023_003DzqQtwmz8_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003DzRpXgovo_003D;
		int _0023_003DzRpXgovo_003D3 = _0023_003DzqQtwmz8_003D[_0023_003Dzhr9krZQ_003D]._0023_003DzRpXgovo_003D;
		int _0023_003Dz77g161c_003D = _0023_003DzqQtwmz8_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003Dz77g161c_003D;
		int _0023_003Dz77g161c_003D2 = _0023_003DzqQtwmz8_003D[_0023_003Dzhr9krZQ_003D]._0023_003Dz77g161c_003D;
		int num4 = Math.Abs(_0023_003DzRpXgovo_003D);
		int beginVertex = _0023_003Dzd9ZyL64_003D.edgeDatas[num4].BeginVertex;
		if (_0023_003Dz77g161c_003D == num && _0023_003Dz77g161c_003D2 == num2)
		{
			return _0023_003DzRpXgovo_003D;
		}
		if (num2 == _0023_003Dz77g161c_003D2)
		{
			int num5;
			if ((num5 = _0023_003DzqXOuYc9ThphL(_0023_003Dzd9ZyL64_003D, num4, num, _0023_003DzvuKzWCk_003D)) == 0)
			{
				return 0;
			}
			if (beginVertex == _0023_003Dz77g161c_003D)
			{
				_0023_003DzRpXgovo_003D = num5 * _0023_003Dz9o2rZNI_003D(_0023_003DzRpXgovo_003D);
			}
			return _0023_003DzRpXgovo_003D;
		}
		_0023_003DzqQtwmz8_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003Dz77g161c_003D = num2;
		if (num == _0023_003Dz77g161c_003D)
		{
			int num5;
			if ((num5 = _0023_003DzqXOuYc9ThphL(_0023_003Dzd9ZyL64_003D, num4, num2, _0023_003DzvuKzWCk_003D)) == 0)
			{
				return 0;
			}
			if (beginVertex == _0023_003Dz77g161c_003D2)
			{
				_0023_003DzRpXgovo_003D = num5 * _0023_003Dz9o2rZNI_003D(_0023_003DzRpXgovo_003D);
			}
		}
		else
		{
			if (beginVertex == _0023_003Dz77g161c_003D2)
			{
				int num6 = num2;
				num2 = num;
				num = num6;
			}
			if (_0023_003DzqXOuYc9ThphL(_0023_003Dzd9ZyL64_003D, num4, num2, _0023_003DzvuKzWCk_003D) == 0)
			{
				return 0;
			}
			int num5;
			if ((num5 = _0023_003DzqXOuYc9ThphL(_0023_003Dzd9ZyL64_003D, num4, num, _0023_003DzvuKzWCk_003D)) == 0)
			{
				return 0;
			}
			_0023_003DzRpXgovo_003D = num5 * _0023_003Dz9o2rZNI_003D(_0023_003DzRpXgovo_003D);
		}
		if (num3 == _0023_003DzRpXgovo_003D2)
		{
			_0023_003DzqQtwmz8_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003DzRpXgovo_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(_0023_003DzRpXgovo_003D3, _0023_003Dzd9ZyL64_003D);
		}
		else
		{
			_0023_003DzqQtwmz8_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003DzRpXgovo_003D = _0023_003DzRpXgovo_003D;
			_0023_003DzqQtwmz8_003D[_0023_003Dzhr9krZQ_003D]._0023_003DzRpXgovo_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(_0023_003DzRpXgovo_003D, _0023_003Dzd9ZyL64_003D);
		}
		return _0023_003DzRpXgovo_003D;
	}

	private static int _0023_003Dz9o2rZNI_003D(int _0023_003DzRpXgovo_003D)
	{
		if (_0023_003DzRpXgovo_003D < 0)
		{
			return -1;
		}
		if (_0023_003DzRpXgovo_003D > 0)
		{
			return 1;
		}
		return 0;
	}

	private static int _0023_003DzEMfkCa7_0024_Tbm(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzbfrNXYE_003D)
	{
		_0023_003DzbfrNXYE_003D = Math.Abs(_0023_003DzbfrNXYE_003D);
		int num;
		int num2;
		int num3;
		if (_0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzbfrNXYE_003D].NextFace < 0)
		{
			num = _0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzbfrNXYE_003D].BeginVertex;
			num2 = _0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzbfrNXYE_003D].EndVertex;
			num3 = _0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzbfrNXYE_003D].PreviousFace;
		}
		else
		{
			num2 = _0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzbfrNXYE_003D].BeginVertex;
			num = _0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzbfrNXYE_003D].EndVertex;
			num3 = _0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzbfrNXYE_003D].NextFace;
		}
		float num4 = _0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzbfrNXYE_003D].Angle - (float)Math.PI;
		Point3D _0023_003Dzt_m8zV0_003D = _0023_003Dzd9ZyL64_003D._vertices[num] - _0023_003Dzd9ZyL64_003D._vertices[num2];
		_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzM_00243BeHw_003D(_0023_003Dzd9ZyL64_003D.planes[num3], _0023_003Dzt_m8zV0_003D, num4, _0023_003Dzd9ZyL64_003D.planes[0]);
		_0023_003Dzd9ZyL64_003D.planes[0].D = 0.0 - (_0023_003Dzd9ZyL64_003D.planes[0].X * _0023_003Dzd9ZyL64_003D._vertices[num2].X + _0023_003Dzd9ZyL64_003D.planes[0].Y * _0023_003Dzd9ZyL64_003D._vertices[num2].Y + _0023_003Dzd9ZyL64_003D.planes[0].Z * _0023_003Dzd9ZyL64_003D._vertices[num2].Z);
		return 0;
	}

	private static int _0023_003Dzl3fpcQ0czKjt(Solid.Portion _0023_003Dzd9ZyL64_003D, List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzPo_ODtE_003D, int _0023_003Dzhr9krZQ_003D)
	{
		int _0023_003DzRpXgovo_003D = _0023_003DzPo_ODtE_003D[_0023_003Dzhr9krZQ_003D]._0023_003DzRpXgovo_003D;
		int _0023_003DzRpXgovo_003D2 = _0023_003DzPo_ODtE_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003DzRpXgovo_003D;
		int _0023_003Dz77g161c_003D = _0023_003DzPo_ODtE_003D[_0023_003Dzhr9krZQ_003D]._0023_003Dz77g161c_003D;
		int _0023_003Dz77g161c_003D2 = _0023_003DzPo_ODtE_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003Dz77g161c_003D;
		int beginVertex = _0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(_0023_003DzRpXgovo_003D)].BeginVertex;
		int endVertex = _0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(_0023_003DzRpXgovo_003D)].EndVertex;
		if ((_0023_003Dz77g161c_003D == beginVertex && _0023_003Dz77g161c_003D2 == endVertex) || (_0023_003Dz77g161c_003D == endVertex && _0023_003Dz77g161c_003D2 == beginVertex))
		{
			return _0023_003DzRpXgovo_003D;
		}
		return _0023_003DzRpXgovo_003D2;
	}

	private static bool _0023_003DzebvCIRvgO6aU(ref Point3D _0023_003DzM9YhqY8_003D, ref Point3D _0023_003DzcFpS4tw_003D, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		Vector3D vector3D = new Vector3D();
		Solid.Portion _0023_003Dzd9ZyL64_003D = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D;
		Solid.Portion _0023_003Dzd9ZyL64_003D2 = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D;
		_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 1;
		if (!_0023_003DzIMKWzdPmhXEx(ref _0023_003DzM9YhqY8_003D, ref _0023_003DzcFpS4tw_003D, _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D], _0023_003Dzd9ZyL64_003D2.planes[_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D], _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
		{
			return false;
		}
		int num;
		if ((num = _0023_003DzmKlXCG4vT3tu(ref _0023_003Dzd9ZyL64_003D, _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003DzHC7AYP4_003D._0023_003DzFmDp2cP8KC1O, _0023_003DzHC7AYP4_003D._0023_003DzO0cNqQQ_003D, _0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D)) == 0)
		{
			return false;
		}
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D _0023_003Dz1v6oPQk_003D = _0023_003Dzqy1hGquKIlvn(_0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(num)].Type);
		_0023_003Dz1v6oPQk_003D._0023_003Dzi6QKiYM_003D = 1;
		_0023_003Dz1v6oPQk_003D._0023_003Dz3u03JZA_003D = 0;
		_0023_003Dz1v6oPQk_003D._0023_003Dzy3xqLbo_003D = 1;
		_0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(num)].Type = _0023_003DzgSdDROLMnqqq(_0023_003Dz1v6oPQk_003D);
		_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D = 2;
		if (!_0023_003DzIMKWzdPmhXEx(ref _0023_003DzM9YhqY8_003D, ref _0023_003DzcFpS4tw_003D, _0023_003Dzd9ZyL64_003D2.planes[_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D], _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D], _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
		{
			return false;
		}
		int value;
		if ((value = _0023_003DzmKlXCG4vT3tu(ref _0023_003Dzd9ZyL64_003D2, _0023_003DzM9YhqY8_003D, _0023_003DzcFpS4tw_003D, _0023_003DzHC7AYP4_003D._0023_003Dzd4ZVhEfWmlyb, _0023_003DzHC7AYP4_003D._0023_003Dz9CqrEH8_003D, _0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D)) == 0)
		{
			return false;
		}
		_0023_003Dz1v6oPQk_003D = _0023_003Dzqy1hGquKIlvn(_0023_003Dzd9ZyL64_003D2.edgeDatas[Math.Abs(value)].Type);
		_0023_003Dz1v6oPQk_003D._0023_003Dzi6QKiYM_003D = 1;
		_0023_003Dz1v6oPQk_003D._0023_003Dz3u03JZA_003D = 0;
		_0023_003Dz1v6oPQk_003D._0023_003Dzy3xqLbo_003D = 1;
		_0023_003Dzd9ZyL64_003D2.edgeDatas[Math.Abs(value)].Type = _0023_003DzgSdDROLMnqqq(_0023_003Dz1v6oPQk_003D);
		if (!_0023_003DzvuKzWCk_003D._0023_003Dz4YMDud0EzJJX)
		{
			BoolUser[] user = _0023_003Dzd9ZyL64_003D.user;
			user[Math.Abs(num)].bnd = 0f;
			user[Math.Abs(num)].ind = 0;
			return true;
		}
		Vector3D vector3D2 = _0023_003Dzd9ZyL64_003D2.planes[_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D];
		vector3D.X = vector3D2.X;
		vector3D.Y = vector3D2.Y;
		vector3D.Z = vector3D2.Z;
		if (_0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D == (Solid._0023_003Dz6tkLYNg_003D)2)
		{
			num = -num;
			vector3D.X = 0.0 - vector3D.X;
			vector3D.Y = 0.0 - vector3D.Y;
			vector3D.Z = 0.0 - vector3D.Z;
		}
		if (_0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D == (Solid._0023_003Dz6tkLYNg_003D)0)
		{
			num = -num;
		}
		float bnd;
		if ((bnd = _0023_003Dz1zs3WXHrvefg(_0023_003Dzd9ZyL64_003D, num, _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D], vector3D)) == 0f)
		{
			return false;
		}
		BoolUser[] user2 = _0023_003Dzd9ZyL64_003D.user;
		BoolUser[] user3 = _0023_003Dzd9ZyL64_003D2.user;
		user2[Math.Abs(num)].bnd = bnd;
		user3[Math.Abs(value)].bnd = bnd;
		user2[Math.Abs(num)].ind = _0023_003Dzd9ZyL64_003D2.Id;
		user3[Math.Abs(value)].ind = _0023_003Dzd9ZyL64_003D.Id;
		return true;
	}

	private static float _0023_003Dz1zs3WXHrvefg(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzRpXgovo_003D, Vector3D _0023_003DzLlLRwFw_003D, Vector3D _0023_003Dz2QNSBWU_003D)
	{
		return _0023_003DzSLyKdRKkR7Vx(_0023_003Dzd9ZyL64_003D, _0023_003DzRpXgovo_003D, _0023_003DzLlLRwFw_003D, _0023_003Dz2QNSBWU_003D);
	}

	private static int _0023_003DzmKlXCG4vT3tu(ref Solid.Portion _0023_003Dzd9ZyL64_003D, Point3D _0023_003DzM9YhqY8_003D, Point3D _0023_003DzcFpS4tw_003D, List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzUs3eak4_003D, int _0023_003Dzhr9krZQ_003D, int _0023_003DzHEpjcdg2hk9U, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		int num = 0;
		double[] array = new double[3];
		double[] array2 = new double[3];
		array[0] = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzUs3eak4_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003Dz77g161c_003D].X;
		array[1] = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzUs3eak4_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003Dz77g161c_003D].Y;
		array[2] = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzUs3eak4_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003Dz77g161c_003D].Z;
		array2[0] = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzUs3eak4_003D[_0023_003Dzhr9krZQ_003D]._0023_003Dz77g161c_003D].X;
		array2[1] = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzUs3eak4_003D[_0023_003Dzhr9krZQ_003D]._0023_003Dz77g161c_003D].Y;
		array2[2] = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzUs3eak4_003D[_0023_003Dzhr9krZQ_003D]._0023_003Dz77g161c_003D].Z;
		int num2;
		if ((num2 = _0023_003Dzmdel3ZTIgMDe(ref _0023_003Dzd9ZyL64_003D, _0023_003DzM9YhqY8_003D, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn)) == -1)
		{
			return 0;
		}
		int num3;
		if ((num3 = _0023_003Dzmdel3ZTIgMDe(ref _0023_003Dzd9ZyL64_003D, _0023_003DzcFpS4tw_003D, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn)) == -1)
		{
			return 0;
		}
		int num4;
		if ((num4 = _0023_003Dz2bKtHInA2tx2(_0023_003Dzd9ZyL64_003D, num2, num3, _0023_003DzvuKzWCk_003D._0023_003DzjTwYx_xFB7Cw)) <= 0)
		{
			return num4;
		}
		_0023_003Dzd9ZyL64_003D.edgeDatas[num4].PreviousFace = (_0023_003Dzd9ZyL64_003D.edgeDatas[num4].NextFace = _0023_003DzHEpjcdg2hk9U);
		_0023_003Dzd9ZyL64_003D.edgeDatas[num4].Type = 1;
		if (_0023_003Dz9EtWqTI_003D(_0023_003Dzd9ZyL64_003D, num2, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx) > _0023_003Dz9EtWqTI_003D(_0023_003Dzd9ZyL64_003D, num3, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx))
		{
			int num5 = num2;
			num2 = num3;
			num3 = num5;
		}
		if (Math.Abs(_0023_003Dz9EtWqTI_003D(_0023_003Dzd9ZyL64_003D, num2, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx) - array[_0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx]) < _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn && _0023_003DzUs3eak4_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003DzkKfJheA_003D == 1 && _0023_003DzqXOuYc9ThphL(_0023_003Dzd9ZyL64_003D, _0023_003DzUs3eak4_003D[_0023_003Dzhr9krZQ_003D - 1]._0023_003DzRpXgovo_003D, num2, _0023_003DzvuKzWCk_003D) == 0)
		{
			return 0;
		}
		if (Math.Abs(_0023_003Dz9EtWqTI_003D(_0023_003Dzd9ZyL64_003D, num3, _0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx) - array2[_0023_003DzHC7AYP4_003D._0023_003DzBtKnIyCthpLx]) < _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn && _0023_003DzUs3eak4_003D[_0023_003Dzhr9krZQ_003D]._0023_003DzkKfJheA_003D == 1 && _0023_003DzqXOuYc9ThphL(_0023_003Dzd9ZyL64_003D, _0023_003DzUs3eak4_003D[_0023_003Dzhr9krZQ_003D]._0023_003DzRpXgovo_003D, num3, _0023_003DzvuKzWCk_003D) == 0)
		{
			return 0;
		}
		int num6;
		for (num6 = _0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour; num6 > 0; num6 = _0023_003Dzd9ZyL64_003D.cycles[num6].NextContour)
		{
			num = num6;
		}
		if (num6 != 0)
		{
			num6 = Math.Abs(num6);
			_0023_003Dzd9ZyL64_003D.edgeDatas[num4].NextEdge = _0023_003Dzd9ZyL64_003D.cycles[num6].FirstEdge;
			_0023_003Dzd9ZyL64_003D.cycles[num6].FirstEdge = num4;
		}
		else
		{
			num6 = _0023_003DzMr8LApT7rJZr(_0023_003Dzd9ZyL64_003D, num4);
			_0023_003Dzd9ZyL64_003D.cycles[num].NextContour = -num6;
		}
		return num4;
	}

	public static int _0023_003DzMr8LApT7rJZr(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzVSPj6J_0024qA8wK)
	{
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.contourCount; i++)
		{
			if (_0023_003Dzd9ZyL64_003D.cycles[i].FirstEdge == 0)
			{
				_0023_003Dzd9ZyL64_003D.cycles[i].FirstEdge = _0023_003DzVSPj6J_0024qA8wK;
				_0023_003Dzd9ZyL64_003D.cycles[i].NextContour = 0;
				return i;
			}
		}
		if (_0023_003Dzd9ZyL64_003D.contourCount == _0023_003Dzd9ZyL64_003D.MaxNoc && !_0023_003DzpJYyFPVkVs7b(_0023_003Dzd9ZyL64_003D, _0023_003Dzd9ZyL64_003D.MaxNov, _0023_003Dzd9ZyL64_003D.MaxNoe, _0023_003Dzd9ZyL64_003D.MaxNof, _0023_003Dzd9ZyL64_003D.MaxNoc + 55, 0))
		{
			return 0;
		}
		_0023_003Dzd9ZyL64_003D.contourCount++;
		_0023_003Dzd9ZyL64_003D.cycles[_0023_003Dzd9ZyL64_003D.contourCount].FirstEdge = _0023_003DzVSPj6J_0024qA8wK;
		_0023_003Dzd9ZyL64_003D.cycles[_0023_003Dzd9ZyL64_003D.contourCount].NextContour = 0;
		return _0023_003Dzd9ZyL64_003D.contourCount;
	}

	private static int _0023_003DzqXOuYc9ThphL(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzTx2aqr8_003D, int _0023_003Dz77g161c_003D, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D)
	{
		int num = Math.Abs(_0023_003DzTx2aqr8_003D);
		int beginVertex = _0023_003Dzd9ZyL64_003D.edgeDatas[num].BeginVertex;
		int endVertex = _0023_003Dzd9ZyL64_003D.edgeDatas[num].EndVertex;
		int _0023_003DzTx2aqr8_003D2;
		if (_0023_003Dzd9ZyL64_003D.edgeDatas[num].NextFace < 0 || _0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousFace < 0)
		{
			int _0023_003DzSkUy_T8_003D = ((_0023_003Dzd9ZyL64_003D.edgeDatas[num].NextFace >= 0) ? _0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousEdge : _0023_003Dzd9ZyL64_003D.edgeDatas[num].NextEdge);
			if (_0023_003Dzd9ZyL64_003D == _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D)
			{
				_ = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D;
			}
			else
			{
				_ = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D;
			}
			Solid solid;
			Solid solid2;
			_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[] _0023_003Dzp5xMQUk_003D;
			int count;
			_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[] _0023_003Dzp5xMQUk_003D2;
			int count2;
			if (_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D == 1)
			{
				solid = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D;
				solid2 = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D;
				_0023_003Dzp5xMQUk_003D = _0023_003DzvuKzWCk_003D._0023_003Dz4aj0xv0_003D;
				count = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count;
				_0023_003Dzp5xMQUk_003D2 = _0023_003DzvuKzWCk_003D._0023_003DzLM7JUrs_003D;
				count2 = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions.Count;
			}
			else
			{
				solid = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D;
				solid2 = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D;
				_0023_003Dzp5xMQUk_003D = _0023_003DzvuKzWCk_003D._0023_003DzLM7JUrs_003D;
				count = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions.Count;
				_0023_003Dzp5xMQUk_003D2 = _0023_003DzvuKzWCk_003D._0023_003Dz4aj0xv0_003D;
				count2 = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count;
			}
			int num2;
			if ((num2 = _0023_003Dz23oII3NiRA_s(_0023_003Dzp5xMQUk_003D, count, _0023_003DzSkUy_T8_003D)) == 0)
			{
				solid = solid2;
				if ((num2 = _0023_003Dz23oII3NiRA_s(_0023_003Dzp5xMQUk_003D2, count2, _0023_003DzSkUy_T8_003D)) == 0)
				{
					return 0;
				}
			}
			Solid.Portion _0023_003Dzd9ZyL64_003D2 = solid.portions[num2 - 1];
			if ((_0023_003DzTx2aqr8_003D2 = _0023_003Dzm5__9a3ldgcf(_0023_003Dzd9ZyL64_003D2, _0023_003Dzd9ZyL64_003D._vertices[beginVertex], _0023_003Dzd9ZyL64_003D._vertices[endVertex], _0023_003Dzd9ZyL64_003D.Id, _0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn)) == 0)
			{
				return 0;
			}
			_0023_003Dzd9ZyL64_003D2.novTemp = _0023_003Dzd9ZyL64_003D2.MaxNov;
			int _0023_003Dz77g161c_003D2;
			if ((_0023_003Dz77g161c_003D2 = _0023_003Dzmdel3ZTIgMDe(ref _0023_003Dzd9ZyL64_003D2, _0023_003Dzd9ZyL64_003D._vertices[_0023_003Dz77g161c_003D], _0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn)) == -1)
			{
				return 0;
			}
			if ((_0023_003DzTx2aqr8_003D2 = _0023_003DzrraITPpPUVmn(_0023_003Dzd9ZyL64_003D2, _0023_003DzTx2aqr8_003D2, _0023_003Dz77g161c_003D2, _0023_003DzvuKzWCk_003D._0023_003DzjTwYx_xFB7Cw)) == 0)
			{
				return 0;
			}
			BoolUser[] user = _0023_003Dzd9ZyL64_003D2.user;
			user[_0023_003DzTx2aqr8_003D2].bnd = 0f;
			user[_0023_003DzTx2aqr8_003D2].ind = 0;
		}
		if ((_0023_003DzTx2aqr8_003D2 = _0023_003DzrraITPpPUVmn(_0023_003Dzd9ZyL64_003D, _0023_003DzTx2aqr8_003D, _0023_003Dz77g161c_003D, _0023_003DzvuKzWCk_003D._0023_003DzjTwYx_xFB7Cw)) == 0)
		{
			return 0;
		}
		BoolUser[] user2 = _0023_003Dzd9ZyL64_003D.user;
		user2[_0023_003DzTx2aqr8_003D2].bnd = 0f;
		user2[_0023_003DzTx2aqr8_003D2].ind = 0;
		return _0023_003DzTx2aqr8_003D2;
	}

	private static int _0023_003DzrraITPpPUVmn(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzTx2aqr8_003D, int _0023_003Dz77g161c_003D, bool _0023_003DzjMikPdqXh_0024DX)
	{
		int num = Math.Abs(_0023_003DzTx2aqr8_003D);
		int num2 = _0023_003Dz2bKtHInA2tx2(_0023_003Dzd9ZyL64_003D, _0023_003Dz77g161c_003D, _0023_003Dzd9ZyL64_003D.edgeDatas[num].EndVertex, _0023_003DzjMikPdqXh_0024DX);
		if (num2 <= 0)
		{
			return Math.Abs(num2);
		}
		if (_0023_003Dzd9ZyL64_003D.edgeDatas[num].NextFace >= 0)
		{
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].NextFace = _0023_003Dzd9ZyL64_003D.edgeDatas[num].NextFace;
		}
		else
		{
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].NextFace = -num2;
		}
		if (_0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousFace >= 0)
		{
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].PreviousFace = _0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousFace;
		}
		else
		{
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].PreviousFace = -num2;
		}
		_0023_003Dzd9ZyL64_003D.edgeDatas[num2].Type = _0023_003Dzd9ZyL64_003D.edgeDatas[num].Type;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num2].Angle = _0023_003Dzd9ZyL64_003D.edgeDatas[num].Angle;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num].EndVertex = _0023_003Dz77g161c_003D;
		if (_0023_003Dzd9ZyL64_003D.edgeDatas[num].NextFace > 0)
		{
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].NextEdge = _0023_003Dzd9ZyL64_003D.edgeDatas[num].NextEdge;
			_0023_003Dzd9ZyL64_003D.edgeDatas[num].NextEdge = num2;
		}
		else
		{
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].NextEdge = _0023_003Dzd9ZyL64_003D.edgeDatas[num].NextEdge;
		}
		if (_0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousFace > 0)
		{
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].PreviousEdge = -num;
			int num3 = -num;
			_0023_003DzTx2aqr8_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dzd9ZyL64_003D);
			bool[] array = new bool[_0023_003Dzd9ZyL64_003D.edgeDatas.Length];
			bool[] array2 = new bool[_0023_003Dzd9ZyL64_003D.edgeDatas.Length];
			while (_0023_003DzTx2aqr8_003D != -num)
			{
				num3 = _0023_003DzTx2aqr8_003D;
				if (num3 > 0)
				{
					if (array[num3])
					{
						break;
					}
					array[num3] = true;
				}
				else
				{
					if (array2[-num3])
					{
						break;
					}
					array2[-num3] = true;
				}
				_0023_003DzTx2aqr8_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dzd9ZyL64_003D);
			}
			if (num3 > 0)
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[num3].NextEdge = -num2;
			}
			else
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[-num3].PreviousEdge = -num2;
			}
		}
		else
		{
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].PreviousEdge = _0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousEdge;
		}
		return num2;
	}

	private static int _0023_003Dzm5__9a3ldgcf(Solid.Portion _0023_003Dz5Tpjxj5wp_0024R8, Point3D _0023_003DzgYn_0024Ldc_003D, Point3D _0023_003Dzu1Fq9I8_003D, int _0023_003DzSkUy_T8_003D, double _0023_003DzkRSfKls1SLfn)
	{
		int i;
		for (i = 1; i <= _0023_003Dz5Tpjxj5wp_0024R8.edgeCount; i++)
		{
			if ((_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].NextFace <= 0 || _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].PreviousFace <= 0) && (_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].NextEdge == _0023_003DzSkUy_T8_003D || _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].PreviousEdge == _0023_003DzSkUy_T8_003D))
			{
				int beginVertex = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].BeginVertex;
				int endVertex = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].EndVertex;
				if ((_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dz5Tpjxj5wp_0024R8._vertices[beginVertex], _0023_003DzgYn_0024Ldc_003D, _0023_003DzkRSfKls1SLfn) || _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dz5Tpjxj5wp_0024R8._vertices[beginVertex], _0023_003Dzu1Fq9I8_003D, _0023_003DzkRSfKls1SLfn)) && (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dz5Tpjxj5wp_0024R8._vertices[endVertex], _0023_003DzgYn_0024Ldc_003D, _0023_003DzkRSfKls1SLfn) || _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dz5Tpjxj5wp_0024R8._vertices[endVertex], _0023_003Dzu1Fq9I8_003D, _0023_003DzkRSfKls1SLfn)))
				{
					break;
				}
			}
		}
		if (i > _0023_003Dz5Tpjxj5wp_0024R8.edgeCount)
		{
			return 0;
		}
		return i;
	}

	private static int _0023_003Dz23oII3NiRA_s(_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[] _0023_003Dzp5xMQUk_003D, int _0023_003Dz8lc6uO0_003D, int _0023_003DzSkUy_T8_003D)
	{
		for (int i = 0; i < _0023_003Dzp5xMQUk_003D.Length; i++)
		{
			_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc _0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc2 = _0023_003Dzp5xMQUk_003D[i];
			if (_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc2._0023_003DzSkUy_T8_003D == _0023_003DzSkUy_T8_003D)
			{
				return _0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc2._0023_003DzSfQie2M_003D;
			}
		}
		return 0;
	}

	private static int _0023_003DzZVQ2I2l1b1KQg0jLo7tYL6w_003D(_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc _0023_003DzjbqS1qE_003D, _0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc _0023_003Dz1v6oPQk_003D)
	{
		if (_0023_003DzjbqS1qE_003D._0023_003DzSkUy_T8_003D < _0023_003Dz1v6oPQk_003D._0023_003DzSkUy_T8_003D)
		{
			return -1;
		}
		if (_0023_003DzjbqS1qE_003D._0023_003DzSkUy_T8_003D == _0023_003Dz1v6oPQk_003D._0023_003DzSkUy_T8_003D)
		{
			return 0;
		}
		return 1;
	}

	private static int _0023_003Dz2bKtHInA2tx2(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, bool _0023_003DzjMikPdqXh_0024DX)
	{
		int num;
		if (_0023_003DzjMikPdqXh_0024DX)
		{
			num = _0023_003DzpD6vgHhK_mY6(_0023_003Dzd9ZyL64_003D, _0023_003DzffqPLNQ_003D, _0023_003Dz5Azd7L8_003D);
			if (num != 0)
			{
				return -Math.Abs(num);
			}
		}
		if (_0023_003Dzd9ZyL64_003D.edgeCount == _0023_003Dzd9ZyL64_003D.MaxNoe && !_0023_003DzpJYyFPVkVs7b(_0023_003Dzd9ZyL64_003D, _0023_003Dzd9ZyL64_003D.MaxNov, _0023_003Dzd9ZyL64_003D.MaxNoe + 100, _0023_003Dzd9ZyL64_003D.MaxNof, _0023_003Dzd9ZyL64_003D.MaxNoc, 0))
		{
			return 0;
		}
		num = ++_0023_003Dzd9ZyL64_003D.edgeCount;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num].BeginVertex = _0023_003DzffqPLNQ_003D;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num].EndVertex = _0023_003Dz5Azd7L8_003D;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num].Type = 0;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num].NextEdge = 0;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousEdge = 0;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousFace = 0;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num].NextFace = 0;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num].Angle = 0f;
		return num;
	}

	private static int _0023_003DzpD6vgHhK_mY6(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D)
	{
		Solid.EdgeData[] edgeDatas = _0023_003Dzd9ZyL64_003D.edgeDatas;
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.edgeCount; i++)
		{
			if (edgeDatas[i].BeginVertex == _0023_003DzffqPLNQ_003D && edgeDatas[i].EndVertex == _0023_003Dz5Azd7L8_003D)
			{
				return i;
			}
			if (edgeDatas[i].EndVertex == _0023_003DzffqPLNQ_003D && edgeDatas[i].BeginVertex == _0023_003Dz5Azd7L8_003D)
			{
				return -i;
			}
		}
		return 0;
	}

	private static int _0023_003Dzmdel3ZTIgMDe(ref Solid.Portion _0023_003Dzd9ZyL64_003D, Point3D _0023_003DzEHUS9qo_003D, double _0023_003DzkRSfKls1SLfn)
	{
		Point3D point3D = new Point3D(_0023_003DzEHUS9qo_003D.X, _0023_003DzEHUS9qo_003D.Y, _0023_003DzEHUS9qo_003D.Z);
		int i;
		for (i = 0; i < _0023_003Dzd9ZyL64_003D.vertexCount; i++)
		{
			if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(point3D, _0023_003Dzd9ZyL64_003D._vertices[i], _0023_003DzkRSfKls1SLfn))
			{
				return i;
			}
		}
		if (_0023_003Dzd9ZyL64_003D.vertexCount == _0023_003Dzd9ZyL64_003D.novTemp && !_0023_003DzpJYyFPVkVs7b(_0023_003Dzd9ZyL64_003D, _0023_003Dzd9ZyL64_003D.MaxNov + 62, _0023_003Dzd9ZyL64_003D.MaxNoe, _0023_003Dzd9ZyL64_003D.MaxNof, _0023_003Dzd9ZyL64_003D.MaxNoc, 62))
		{
			return -1;
		}
		i = _0023_003Dzd9ZyL64_003D.vertexCount;
		_0023_003Dzd9ZyL64_003D._vertices[i] = point3D;
		_0023_003Dzd9ZyL64_003D.vertexCount++;
		return i;
	}

	private static bool _0023_003DzIMKWzdPmhXEx(ref Point3D _0023_003DzM9YhqY8_003D, ref Point3D _0023_003DzcFpS4tw_003D, Vector3D _0023_003Dz0wAkCmM_003D, Vector3D _0023_003Dz_0024eRdUwQ_003D, double _0023_003DzkRSfKls1SLfn)
	{
		Vector3D vector3D = Vector3D.Cross(_0023_003Dz0wAkCmM_003D, _0023_003Dz_0024eRdUwQ_003D);
		Vector3D vector3D2 = Vector3D.Subtract(_0023_003DzcFpS4tw_003D, _0023_003DzM9YhqY8_003D);
		if (!vector3D.Normalize())
		{
			return false;
		}
		if (!vector3D2.Normalize())
		{
			return false;
		}
		if (_0023_003DzMeLY8V4_003D(Vector3D.Dot(vector3D, vector3D2), _0023_003DzkRSfKls1SLfn) < 0)
		{
			Utility.Swap(ref _0023_003DzM9YhqY8_003D, ref _0023_003DzcFpS4tw_003D);
		}
		return true;
	}

	private static void _0023_003Dz611qY1n3rRLa(int _0023_003Dznu8I_Qk_003D, ref int _0023_003DzB68dg9Q_003D, ref int _0023_003DzCaPJP54_003D, ref int _0023_003DzMlCq3wk_003D, ref bool _0023_003Dz44_0024ru0s_003D)
	{
		if (Math.Abs(_0023_003Dznu8I_Qk_003D) == 1)
		{
			_0023_003DzB68dg9Q_003D = -_0023_003DzB68dg9Q_003D;
		}
		else
		{
			if (Math.Abs(_0023_003Dznu8I_Qk_003D) == 4)
			{
				return;
			}
			if (_0023_003Dznu8I_Qk_003D == 2)
			{
				if (_0023_003DzCaPJP54_003D < 0)
				{
					_0023_003DzMlCq3wk_003D = _0023_003DzB68dg9Q_003D;
					_0023_003DzB68dg9Q_003D = 1;
					_0023_003DzCaPJP54_003D = 1;
					_0023_003Dz44_0024ru0s_003D = true;
				}
				else
				{
					_0023_003DzB68dg9Q_003D = _0023_003DzMlCq3wk_003D;
					_0023_003DzCaPJP54_003D = -1;
					_0023_003Dz44_0024ru0s_003D = false;
				}
			}
			else if (_0023_003DzCaPJP54_003D < 0)
			{
				_0023_003DzMlCq3wk_003D = _0023_003DzB68dg9Q_003D;
				_0023_003DzB68dg9Q_003D = 1;
				_0023_003DzCaPJP54_003D = 1;
				_0023_003Dz44_0024ru0s_003D = true;
			}
			else
			{
				_0023_003DzB68dg9Q_003D = -_0023_003DzMlCq3wk_003D;
				_0023_003DzCaPJP54_003D = -1;
				_0023_003Dz44_0024ru0s_003D = false;
			}
		}
	}

	public static void _0023_003DzCgqNlbtmU44p(Point3D[] _0023_003DzrH1N0x4_003D, List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003Dz7pqWuheV0uU_0024, int _0023_003DzvQElbssTl3_h)
	{
		if (_0023_003Dz7pqWuheV0uU_0024 == null)
		{
			throw new ArgumentNullException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302996537));
		}
		_0023_003DzmSHdS_00243gs_0024Jly_0024rVTGxd0nuBuSsBv_QXgEa851c_003D _0023_003DzmSHdS_00243gs_0024Jly_0024rVTGxd0nuBuSsBv_QXgEa851c_003D2 = new _0023_003DzmSHdS_00243gs_0024Jly_0024rVTGxd0nuBuSsBv_QXgEa851c_003D(_0023_003DzrH1N0x4_003D);
		switch (_0023_003DzvQElbssTl3_h)
		{
		case 0:
			_0023_003Dz7pqWuheV0uU_0024.Sort(_0023_003DzmSHdS_00243gs_0024Jly_0024rVTGxd0nuBuSsBv_QXgEa851c_003D2._0023_003DzjnVIgyA_003D);
			break;
		case 1:
			_0023_003Dz7pqWuheV0uU_0024.Sort(_0023_003DzmSHdS_00243gs_0024Jly_0024rVTGxd0nuBuSsBv_QXgEa851c_003D2._0023_003Dz_okInq4_003D);
			break;
		default:
			_0023_003Dz7pqWuheV0uU_0024.Sort(_0023_003DzmSHdS_00243gs_0024Jly_0024rVTGxd0nuBuSsBv_QXgEa851c_003D2._0023_003DzwX9vU5s_003D);
			break;
		}
	}

	public static int _0023_003Dz_0024LYVLiAhnEq9(Vector3D _0023_003DzFj_0024IqDQ_003D, Vector3D _0023_003DzjdeMMkk_003D)
	{
		Vector3D vector3D = Vector3D.Cross(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D);
		vector3D.X = Math.Abs(vector3D.X);
		vector3D.Y = Math.Abs(vector3D.Y);
		vector3D.Z = Math.Abs(vector3D.Z);
		if (vector3D.X <= vector3D.Y)
		{
			if (vector3D.Y <= vector3D.Z)
			{
				return 2;
			}
			return 1;
		}
		if (vector3D.X <= vector3D.Z)
		{
			return 2;
		}
		return 0;
	}

	public static bool _0023_003DzvbTb47elbjLr(Solid.Portion _0023_003Dz2JIjXEo_003D, int _0023_003DzxEr071xAssYe, List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzoMHQGDg_003D, PlaneEquation _0023_003Dzi4cdUYM_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		double _0023_003DzkRSfKls1SLfn = _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn;
		Vector3D _0023_003DznaWmM5WvJnngSL7PhA_003D_003D = new Vector3D();
		Point3D point3D = new Point3D();
		double value = Vector3D.Dot(_0023_003Dz2JIjXEo_003D.planes[_0023_003DzxEr071xAssYe], _0023_003Dzi4cdUYM_003D);
		double x;
		double y;
		double z;
		double _0023_003DzASowvPc_003D;
		if (Math.Abs(value) > 0.5)
		{
			_0023_003DzXbtSO4MDpdWe(_0023_003Dz2JIjXEo_003D.planes[_0023_003DzxEr071xAssYe], _0023_003Dzi4cdUYM_003D, ref _0023_003DznaWmM5WvJnngSL7PhA_003D_003D, point3D);
			Vector3D vector3D = Vector3D.Cross(_0023_003DznaWmM5WvJnngSL7PhA_003D_003D, _0023_003Dz2JIjXEo_003D.planes[_0023_003DzxEr071xAssYe]);
			if (!vector3D.Normalize())
			{
				vector3D.X = (vector3D.Y = (vector3D.Z = 0.0));
			}
			x = vector3D.X;
			y = vector3D.Y;
			z = vector3D.Z;
			_0023_003DzASowvPc_003D = _0023_003Dz9nb7r2oTZJfm(point3D, vector3D);
		}
		else
		{
			x = _0023_003Dzi4cdUYM_003D.X;
			y = _0023_003Dzi4cdUYM_003D.Y;
			z = _0023_003Dzi4cdUYM_003D.Z;
			_0023_003DzASowvPc_003D = _0023_003Dzi4cdUYM_003D.D;
		}
		int num = _0023_003Dz2JIjXEo_003D.faces[_0023_003DzxEr071xAssYe].FirstContour;
		do
		{
			int firstEdge = _0023_003Dz2JIjXEo_003D.cycles[num].FirstEdge;
			int num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(firstEdge, _0023_003Dz2JIjXEo_003D);
			int num3 = firstEdge;
			value = _0023_003Dz65_002455MtBkHuQ(_0023_003Dz2JIjXEo_003D._vertices[num2], x, y, z, _0023_003DzASowvPc_003D);
			while (!(Math.Abs(value) > _0023_003DzkRSfKls1SLfn))
			{
				num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dz2JIjXEo_003D);
				num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(num3, _0023_003Dz2JIjXEo_003D);
				value = _0023_003Dz65_002455MtBkHuQ(_0023_003Dz2JIjXEo_003D._vertices[num2], x, y, z, _0023_003DzASowvPc_003D);
				if (num3 == firstEdge)
				{
					return true;
				}
			}
			firstEdge = num3;
			int num4 = _0023_003DzMeLY8V4_003D(value, _0023_003DzkRSfKls1SLfn);
			do
			{
				int num5 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num3, _0023_003Dz2JIjXEo_003D);
				double num6 = _0023_003Dz65_002455MtBkHuQ(_0023_003Dz2JIjXEo_003D._vertices[num5], x, y, z, _0023_003DzASowvPc_003D);
				int num7 = _0023_003DzMeLY8V4_003D(num6, _0023_003DzkRSfKls1SLfn);
				if (num4 == num7)
				{
					num2 = num5;
					value = num6;
					num4 = num7;
					num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dz2JIjXEo_003D);
					continue;
				}
				int _0023_003DzBaLIZT8_003D;
				_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2;
				if (num4 == -num7)
				{
					if ((_0023_003DzBaLIZT8_003D = _0023_003DzRc14K6kDzPT6W9d5gw_003D_003D(num2, num5, value, num6, _0023_003Dz2JIjXEo_003D, _0023_003DzoMHQGDg_003D)) == -1)
					{
						return false;
					}
					_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2 = new _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D(1, _0023_003DzBaLIZT8_003D, num3);
					if (_0023_003DzNaOI7e6a8cfe(_0023_003DzoMHQGDg_003D, _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2))
					{
						break;
					}
					_0023_003DzoMHQGDg_003D.Add(_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2);
					num2 = num5;
					value = num6;
					num4 = num7;
					num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dz2JIjXEo_003D);
					continue;
				}
				if (_0023_003DzHC7AYP4_003D._0023_003DzG7CHMApDMKiS == null)
				{
					_0023_003DzHC7AYP4_003D._0023_003DzG7CHMApDMKiS = new Stack<int>();
				}
				do
				{
					_0023_003DzHC7AYP4_003D._0023_003DzG7CHMApDMKiS.Push(num3);
					num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dz2JIjXEo_003D);
					num5 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num3, _0023_003Dz2JIjXEo_003D);
					num6 = _0023_003Dz65_002455MtBkHuQ(_0023_003Dz2JIjXEo_003D._vertices[num5], x, y, z, _0023_003DzASowvPc_003D);
					num7 = _0023_003DzMeLY8V4_003D(num6, _0023_003DzkRSfKls1SLfn);
				}
				while (num7 == 0);
				int _0023_003Dz3HMcSpc_003D;
				int num8;
				if (_0023_003DzHC7AYP4_003D._0023_003DzG7CHMApDMKiS.Count == 1)
				{
					_0023_003Dz3HMcSpc_003D = ((num4 != num7) ? (-1) : (-4));
					num8 = _0023_003DzHC7AYP4_003D._0023_003DzG7CHMApDMKiS.Pop();
					_0023_003DzBaLIZT8_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num8, _0023_003Dz2JIjXEo_003D);
					_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2 = new _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D(_0023_003Dz3HMcSpc_003D, _0023_003DzBaLIZT8_003D, num8);
					if (_0023_003DzNaOI7e6a8cfe(_0023_003DzoMHQGDg_003D, _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2))
					{
						break;
					}
					_0023_003DzoMHQGDg_003D.Add(_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2);
					num2 = num5;
					num4 = num7;
					value = num6;
					num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dz2JIjXEo_003D);
					continue;
				}
				_0023_003Dz3HMcSpc_003D = ((num7 != num4) ? 3 : 2);
				num8 = ((_0023_003DzHC7AYP4_003D._0023_003DzG7CHMApDMKiS.Count > 0) ? _0023_003DzHC7AYP4_003D._0023_003DzG7CHMApDMKiS.Pop() : 0);
				_0023_003DzBaLIZT8_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num8, _0023_003Dz2JIjXEo_003D);
				_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2 = new _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D(_0023_003Dz3HMcSpc_003D, _0023_003DzBaLIZT8_003D, num8);
				if (_0023_003DzNaOI7e6a8cfe(_0023_003DzoMHQGDg_003D, _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2))
				{
					break;
				}
				_0023_003DzoMHQGDg_003D.Add(_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2);
				int num9 = ((_0023_003DzHC7AYP4_003D._0023_003DzG7CHMApDMKiS.Count > 0) ? _0023_003DzHC7AYP4_003D._0023_003DzG7CHMApDMKiS.Pop() : 0);
				while (_0023_003DzHC7AYP4_003D._0023_003DzG7CHMApDMKiS.Count > 0)
				{
					num8 = _0023_003DzHC7AYP4_003D._0023_003DzG7CHMApDMKiS.Pop();
					_0023_003DzBaLIZT8_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num9, _0023_003Dz2JIjXEo_003D);
					_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2 = new _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D(4, _0023_003DzBaLIZT8_003D, num9);
					if (_0023_003DzNaOI7e6a8cfe(_0023_003DzoMHQGDg_003D, _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2))
					{
						break;
					}
					_0023_003DzoMHQGDg_003D.Add(_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2);
					num9 = num8;
				}
				_0023_003DzBaLIZT8_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num9, _0023_003Dz2JIjXEo_003D);
				_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2 = new _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D(_0023_003Dz3HMcSpc_003D, _0023_003DzBaLIZT8_003D, num9);
				if (_0023_003DzNaOI7e6a8cfe(_0023_003DzoMHQGDg_003D, _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2))
				{
					break;
				}
				_0023_003DzoMHQGDg_003D.Add(_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D2);
				num2 = num5;
				value = num6;
				num4 = num7;
				num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dz2JIjXEo_003D);
			}
			while (num3 != firstEdge);
			num = _0023_003Dz2JIjXEo_003D.cycles[num].NextContour;
		}
		while (num > 0);
		return true;
	}

	private static bool _0023_003DzNaOI7e6a8cfe(List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzoMHQGDg_003D, _0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D _0023_003DzJs2WPVlNsiqa)
	{
		if ((_0023_003DzoMHQGDg_003D.Count > 1 && _0023_003DzJs2WPVlNsiqa._0023_003Dza0ku3fI_003D(_0023_003DzoMHQGDg_003D[_0023_003DzoMHQGDg_003D.Count - 1])) || (_0023_003DzoMHQGDg_003D.Count > 2 && _0023_003DzJs2WPVlNsiqa._0023_003Dza0ku3fI_003D(_0023_003DzoMHQGDg_003D[_0023_003DzoMHQGDg_003D.Count - 2])) || (_0023_003DzoMHQGDg_003D.Count > 3 && _0023_003DzJs2WPVlNsiqa._0023_003Dza0ku3fI_003D(_0023_003DzoMHQGDg_003D[_0023_003DzoMHQGDg_003D.Count - 3])) || (_0023_003DzoMHQGDg_003D.Count > 4 && _0023_003DzJs2WPVlNsiqa._0023_003Dza0ku3fI_003D(_0023_003DzoMHQGDg_003D[_0023_003DzoMHQGDg_003D.Count - 4])))
		{
			return true;
		}
		return false;
	}

	private static double _0023_003Dz65_002455MtBkHuQ(Point3D _0023_003Dz77g161c_003D, double _0023_003Dz94ji5Zg_003D, double _0023_003Dz2D6j0u4_003D, double _0023_003Dz74EK1pQ_003D, double _0023_003DzASowvPc_003D)
	{
		return _0023_003Dz77g161c_003D.X * _0023_003Dz94ji5Zg_003D + _0023_003Dz77g161c_003D.Y * _0023_003Dz2D6j0u4_003D + _0023_003Dz77g161c_003D.Z * _0023_003Dz74EK1pQ_003D + _0023_003DzASowvPc_003D;
	}

	private static int _0023_003DzRc14K6kDzPT6W9d5gw_003D_003D(int _0023_003DzffqPLNQ_003D, int _0023_003Dz5Azd7L8_003D, double _0023_003DzLlLRwFw_003D, double _0023_003Dz2QNSBWU_003D, Solid.Portion _0023_003Dzd9ZyL64_003D, List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzqQtwmz8_003D)
	{
		if (_0023_003Dzd9ZyL64_003D.vertexCount == _0023_003Dzd9ZyL64_003D.novTemp)
		{
			if (!_0023_003DzpJYyFPVkVs7b(_0023_003Dzd9ZyL64_003D, _0023_003Dzd9ZyL64_003D.MaxNov + 62, _0023_003Dzd9ZyL64_003D.MaxNoe, _0023_003Dzd9ZyL64_003D.MaxNof, _0023_003Dzd9ZyL64_003D.MaxNoc, 62))
			{
				return -1;
			}
			for (int i = 0; i < _0023_003DzqQtwmz8_003D.Count; i++)
			{
				if (_0023_003DzqQtwmz8_003D[i]._0023_003Dz77g161c_003D >= _0023_003Dzd9ZyL64_003D.vertexCount)
				{
					_0023_003DzqQtwmz8_003D[i]._0023_003Dz77g161c_003D += 62;
				}
			}
		}
		int num = _0023_003Dzd9ZyL64_003D.novTemp - 1;
		double num2 = _0023_003DzFykcPemvNI_0024T(_0023_003DzLlLRwFw_003D, _0023_003Dz2QNSBWU_003D);
		_0023_003Dzd9ZyL64_003D._vertices[num] = new Point3D(_0023_003Dzd9ZyL64_003D._vertices[_0023_003DzffqPLNQ_003D].X + (_0023_003Dzd9ZyL64_003D._vertices[_0023_003Dz5Azd7L8_003D].X - _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzffqPLNQ_003D].X) * num2, _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzffqPLNQ_003D].Y + (_0023_003Dzd9ZyL64_003D._vertices[_0023_003Dz5Azd7L8_003D].Y - _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzffqPLNQ_003D].Y) * num2, _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzffqPLNQ_003D].Z + (_0023_003Dzd9ZyL64_003D._vertices[_0023_003Dz5Azd7L8_003D].Z - _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzffqPLNQ_003D].Z) * num2);
		_0023_003Dzd9ZyL64_003D.novTemp--;
		return num;
	}

	private static double _0023_003DzFykcPemvNI_0024T(double _0023_003DzLlLRwFw_003D, double _0023_003Dz2QNSBWU_003D)
	{
		return Math.Abs(_0023_003DzLlLRwFw_003D) / (Math.Abs(_0023_003Dz2QNSBWU_003D) + Math.Abs(_0023_003DzLlLRwFw_003D));
	}

	private static double _0023_003Dz9nb7r2oTZJfm(Point3D _0023_003DzB68dg9Q_003D, Vector3D _0023_003DzoMNiNRw_003D)
	{
		return 0.0 - (_0023_003DzoMNiNRw_003D.X * _0023_003DzB68dg9Q_003D.X + _0023_003DzoMNiNRw_003D.Y * _0023_003DzB68dg9Q_003D.Y + _0023_003DzoMNiNRw_003D.Z * _0023_003DzB68dg9Q_003D.Z);
	}

	private static void _0023_003DzXbtSO4MDpdWe(PlaneEquation _0023_003DzFj_0024IqDQ_003D, PlaneEquation _0023_003DzjdeMMkk_003D, ref Vector3D _0023_003DznaWmM5WvJnngSL7PhA_003D_003D, Point3D _0023_003Dzifq_QG8_003D)
	{
		double[] array = new double[2];
		double[] array2 = new double[2];
		double[] _0023_003Dz40R7bAU_003D = new double[2];
		Vector3D vector3D = Vector3D.Cross(_0023_003DzFj_0024IqDQ_003D, _0023_003DzjdeMMkk_003D);
		if (!vector3D.Normalize())
		{
			_0023_003DznaWmM5WvJnngSL7PhA_003D_003D = new Vector3D();
		}
		else
		{
			_0023_003DznaWmM5WvJnngSL7PhA_003D_003D = vector3D;
		}
		short num;
		if (Math.Abs(_0023_003DznaWmM5WvJnngSL7PhA_003D_003D.X) > Math.Abs(_0023_003DznaWmM5WvJnngSL7PhA_003D_003D.Y))
		{
			if (Math.Abs(_0023_003DznaWmM5WvJnngSL7PhA_003D_003D.X) > Math.Abs(_0023_003DznaWmM5WvJnngSL7PhA_003D_003D.Z))
			{
				array[0] = _0023_003DzFj_0024IqDQ_003D.Y;
				array2[0] = _0023_003DzjdeMMkk_003D.Y;
				array[1] = _0023_003DzFj_0024IqDQ_003D.Z;
				array2[1] = _0023_003DzjdeMMkk_003D.Z;
				_0023_003Dz40R7bAU_003D[0] = 0.0 - _0023_003DzFj_0024IqDQ_003D.D;
				_0023_003Dz40R7bAU_003D[1] = 0.0 - _0023_003DzjdeMMkk_003D.D;
				num = 1;
			}
			else
			{
				array[0] = _0023_003DzFj_0024IqDQ_003D.X;
				array2[0] = _0023_003DzjdeMMkk_003D.X;
				array[1] = _0023_003DzFj_0024IqDQ_003D.Y;
				array2[1] = _0023_003DzjdeMMkk_003D.Y;
				_0023_003Dz40R7bAU_003D[0] = 0.0 - _0023_003DzFj_0024IqDQ_003D.D;
				_0023_003Dz40R7bAU_003D[1] = 0.0 - _0023_003DzjdeMMkk_003D.D;
				num = 3;
			}
		}
		else if (Math.Abs(_0023_003DznaWmM5WvJnngSL7PhA_003D_003D.Y) > Math.Abs(_0023_003DznaWmM5WvJnngSL7PhA_003D_003D.Z))
		{
			array[0] = _0023_003DzFj_0024IqDQ_003D.X;
			array2[0] = _0023_003DzjdeMMkk_003D.X;
			array[1] = _0023_003DzFj_0024IqDQ_003D.Z;
			array2[1] = _0023_003DzjdeMMkk_003D.Z;
			_0023_003Dz40R7bAU_003D[0] = 0.0 - _0023_003DzFj_0024IqDQ_003D.D;
			_0023_003Dz40R7bAU_003D[1] = 0.0 - _0023_003DzjdeMMkk_003D.D;
			num = 2;
		}
		else
		{
			array[0] = _0023_003DzFj_0024IqDQ_003D.X;
			array2[0] = _0023_003DzjdeMMkk_003D.X;
			array[1] = _0023_003DzFj_0024IqDQ_003D.Y;
			array2[1] = _0023_003DzjdeMMkk_003D.Y;
			_0023_003Dz40R7bAU_003D[0] = 0.0 - _0023_003DzFj_0024IqDQ_003D.D;
			_0023_003Dz40R7bAU_003D[1] = 0.0 - _0023_003DzjdeMMkk_003D.D;
			num = 3;
		}
		double[,] _0023_003DzE8QrneA_003D = new double[2, 2]
		{
			{
				array[0],
				array[1]
			},
			{
				array2[0],
				array2[1]
			}
		};
		_0023_003Dz9MQ8e6_T3fbP(ref _0023_003DzE8QrneA_003D, ref _0023_003Dz40R7bAU_003D, 2);
		switch (num)
		{
		case 1:
			_0023_003Dzifq_QG8_003D.X = 0.0;
			_0023_003Dzifq_QG8_003D.Y = _0023_003Dz40R7bAU_003D[0];
			_0023_003Dzifq_QG8_003D.Z = _0023_003Dz40R7bAU_003D[1];
			break;
		case 2:
			_0023_003Dzifq_QG8_003D.X = _0023_003Dz40R7bAU_003D[0];
			_0023_003Dzifq_QG8_003D.Y = 0.0;
			_0023_003Dzifq_QG8_003D.Z = _0023_003Dz40R7bAU_003D[1];
			break;
		case 3:
			_0023_003Dzifq_QG8_003D.X = _0023_003Dz40R7bAU_003D[0];
			_0023_003Dzifq_QG8_003D.Y = _0023_003Dz40R7bAU_003D[1];
			_0023_003Dzifq_QG8_003D.Z = 0.0;
			break;
		}
	}

	private static int _0023_003Dz9MQ8e6_T3fbP(ref double[,] _0023_003DzE8QrneA_003D, ref double[] _0023_003Dz40R7bAU_003D, int _0023_003Dz_eY3Y4c_003D)
	{
		_0023_003Dz_eY3Y4c_003D--;
		for (int i = 0; i <= _0023_003Dz_eY3Y4c_003D; i++)
		{
			int j = i;
			int num = -1;
			for (; j <= _0023_003Dz_eY3Y4c_003D; j++)
			{
				if (Math.Abs(_0023_003DzE8QrneA_003D[j, i]) > 1E-07)
				{
					num = j;
					break;
				}
			}
			if (num == -1)
			{
				return 0;
			}
			if (num != i)
			{
				for (int k = i; k <= _0023_003Dz_eY3Y4c_003D; k++)
				{
					_0023_003DzezVbaOHcAjXN(ref _0023_003DzE8QrneA_003D[i, k], ref _0023_003DzE8QrneA_003D[num, k]);
				}
				_0023_003DzezVbaOHcAjXN(ref _0023_003Dz40R7bAU_003D[i], ref _0023_003Dz40R7bAU_003D[num]);
			}
			double num2 = 1.0 / _0023_003DzE8QrneA_003D[i, i];
			for (int num3 = _0023_003Dz_eY3Y4c_003D; num3 >= i; num3--)
			{
				_0023_003DzE8QrneA_003D[i, num3] *= num2;
			}
			_0023_003Dz40R7bAU_003D[i] *= num2;
			for (int l = num + 1; l <= _0023_003Dz_eY3Y4c_003D; l++)
			{
				for (int num3 = i + 1; num3 <= _0023_003Dz_eY3Y4c_003D; num3++)
				{
					_0023_003DzE8QrneA_003D[l, num3] -= _0023_003DzE8QrneA_003D[l, i] * _0023_003DzE8QrneA_003D[i, num3];
				}
				_0023_003Dz40R7bAU_003D[l] -= _0023_003DzE8QrneA_003D[l, i] * _0023_003Dz40R7bAU_003D[i];
			}
		}
		for (int l = _0023_003Dz_eY3Y4c_003D; l >= 0; l--)
		{
			for (int num = l - 1; num >= 0; num--)
			{
				if (Math.Abs(_0023_003DzE8QrneA_003D[num, l]) > 1E-07)
				{
					_0023_003Dz40R7bAU_003D[num] -= _0023_003DzE8QrneA_003D[num, l] * _0023_003Dz40R7bAU_003D[l];
				}
			}
		}
		return 1;
	}

	private static void _0023_003DzezVbaOHcAjXN(ref double _0023_003Dz437_00244ak_003D, ref double _0023_003DzTSeNR8Q_003D)
	{
		double num = _0023_003Dz437_00244ak_003D;
		_0023_003Dz437_00244ak_003D = _0023_003DzTSeNR8Q_003D;
		_0023_003DzTSeNR8Q_003D = num;
	}

	public static bool _0023_003Dzq9H_u3Dp5eSRXEAAxJLRmGA_003D(Point3D _0023_003DzF7v9r2A_003D, Point3D _0023_003Dz8dK2uhU_003D, PlaneEquation _0023_003Dzrgqz890sj_0024X9, double _0023_003DzezTples_003D)
	{
		short num = _0023_003DzMeLY8V4_003D(_0023_003DzF7v9r2A_003D.X * _0023_003Dzrgqz890sj_0024X9.X + _0023_003DzF7v9r2A_003D.Y * _0023_003Dzrgqz890sj_0024X9.Y + _0023_003DzF7v9r2A_003D.Z * _0023_003Dzrgqz890sj_0024X9.Z + _0023_003Dzrgqz890sj_0024X9.D, _0023_003DzezTples_003D);
		if (_0023_003DzMeLY8V4_003D(_0023_003DzF7v9r2A_003D.X * _0023_003Dzrgqz890sj_0024X9.X + _0023_003DzF7v9r2A_003D.Y * _0023_003Dzrgqz890sj_0024X9.Y + _0023_003Dz8dK2uhU_003D.Z * _0023_003Dzrgqz890sj_0024X9.Z + _0023_003Dzrgqz890sj_0024X9.D, _0023_003DzezTples_003D) != num)
		{
			return false;
		}
		if (_0023_003DzMeLY8V4_003D(_0023_003DzF7v9r2A_003D.X * _0023_003Dzrgqz890sj_0024X9.X + _0023_003Dz8dK2uhU_003D.Y * _0023_003Dzrgqz890sj_0024X9.Y + _0023_003DzF7v9r2A_003D.Z * _0023_003Dzrgqz890sj_0024X9.Z + _0023_003Dzrgqz890sj_0024X9.D, _0023_003DzezTples_003D) != num)
		{
			return false;
		}
		if (_0023_003DzMeLY8V4_003D(_0023_003Dz8dK2uhU_003D.X * _0023_003Dzrgqz890sj_0024X9.X + _0023_003DzF7v9r2A_003D.Y * _0023_003Dzrgqz890sj_0024X9.Y + _0023_003DzF7v9r2A_003D.Z * _0023_003Dzrgqz890sj_0024X9.Z + _0023_003Dzrgqz890sj_0024X9.D, _0023_003DzezTples_003D) != num)
		{
			return false;
		}
		if (_0023_003DzMeLY8V4_003D(_0023_003DzF7v9r2A_003D.X * _0023_003Dzrgqz890sj_0024X9.X + _0023_003Dz8dK2uhU_003D.Y * _0023_003Dzrgqz890sj_0024X9.Y + _0023_003Dz8dK2uhU_003D.Z * _0023_003Dzrgqz890sj_0024X9.Z + _0023_003Dzrgqz890sj_0024X9.D, _0023_003DzezTples_003D) != num)
		{
			return false;
		}
		if (_0023_003DzMeLY8V4_003D(_0023_003Dz8dK2uhU_003D.X * _0023_003Dzrgqz890sj_0024X9.X + _0023_003DzF7v9r2A_003D.Y * _0023_003Dzrgqz890sj_0024X9.Y + _0023_003Dz8dK2uhU_003D.Z * _0023_003Dzrgqz890sj_0024X9.Z + _0023_003Dzrgqz890sj_0024X9.D, _0023_003DzezTples_003D) != num)
		{
			return false;
		}
		if (_0023_003DzMeLY8V4_003D(_0023_003Dz8dK2uhU_003D.X * _0023_003Dzrgqz890sj_0024X9.X + _0023_003Dz8dK2uhU_003D.Y * _0023_003Dzrgqz890sj_0024X9.Y + _0023_003DzF7v9r2A_003D.Z * _0023_003Dzrgqz890sj_0024X9.Z + _0023_003Dzrgqz890sj_0024X9.D, _0023_003DzezTples_003D) != num)
		{
			return false;
		}
		if (_0023_003DzMeLY8V4_003D(_0023_003Dz8dK2uhU_003D.X * _0023_003Dzrgqz890sj_0024X9.X + _0023_003Dz8dK2uhU_003D.Y * _0023_003Dzrgqz890sj_0024X9.Y + _0023_003Dz8dK2uhU_003D.Z * _0023_003Dzrgqz890sj_0024X9.Z + _0023_003Dzrgqz890sj_0024X9.D, _0023_003DzezTples_003D) != num)
		{
			return false;
		}
		return true;
	}

	private static short _0023_003DzMeLY8V4_003D(double _0023_003DzRpXgovo_003D, double _0023_003DzezTples_003D)
	{
		if (_0023_003DzRpXgovo_003D < 0.0 - _0023_003DzezTples_003D)
		{
			return -1;
		}
		if (_0023_003DzRpXgovo_003D > _0023_003DzezTples_003D)
		{
			return 1;
		}
		return 0;
	}

	private static bool _0023_003Dzjs2HjMFV_0024x7Uz9lL0yCE2Ls_003D(Solid.Portion _0023_003Dz2JIjXEo_003D, int _0023_003DzxEr071xAssYe, Solid.Portion _0023_003DzShwwkvI_003D, int _0023_003DzJefTJpnXqBD9, double _0023_003DzezTples_003D)
	{
		Vector3D vector3D = _0023_003Dz2JIjXEo_003D.planes[_0023_003DzxEr071xAssYe];
		Vector3D vector3D2 = _0023_003DzShwwkvI_003D.planes[_0023_003DzJefTJpnXqBD9];
		if (!(Math.Abs(vector3D.X - vector3D2.X) <= _0023_003DzezTples_003D) || !(Math.Abs(vector3D.Y - vector3D2.Y) <= _0023_003DzezTples_003D) || !(Math.Abs(vector3D.Z - vector3D2.Z) <= _0023_003DzezTples_003D))
		{
			if (Math.Abs(vector3D.X + vector3D2.X) <= _0023_003DzezTples_003D && Math.Abs(vector3D.Y + vector3D2.Y) <= _0023_003DzezTples_003D)
			{
				return Math.Abs(vector3D.Z + vector3D2.Z) <= _0023_003DzezTples_003D;
			}
			return false;
		}
		return true;
	}

	public static bool _0023_003DzSXX9agsLRhhl(Solid _0023_003DzcDEsV8s_003D, Solid _0023_003DzCX9Hbao_003D, Solid _0023_003DzP6tj1RkeCdlB, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		short num = 0;
		for (short num2 = 0; num2 < _0023_003DzcDEsV8s_003D.portions.Count; num2++)
		{
			NpStr npStr = _0023_003DzcDEsV8s_003D.NpStrList[num2];
			if (npStr.lab == 2)
			{
				_0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D = _0023_003DzcDEsV8s_003D.portions[npStr.hnp - 1];
				_0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.novTemp = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.MaxNov;
				Solid.Portion _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D = _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D;
				if (!_0023_003DzE4Wzm9I_003D(_0023_003DzcDEsV8s_003D, _0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, npStr, _0023_003DzCX9Hbao_003D.smoothingAngle, _0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D, ref _0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D, ref _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D, _0023_003DzHC7AYP4_003D))
				{
					return false;
				}
				if (_0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.faceCount == 0)
				{
					npStr.lab = -1;
				}
				else
				{
					npStr.lab = 1;
				}
			}
			else
			{
				num = 1;
			}
		}
		if (num == 0)
		{
			return true;
		}
		_0023_003Dz2xhS3s0NNk1u(_0023_003DzcDEsV8s_003D, _0023_003DzP6tj1RkeCdlB, _0023_003DzvuKzWCk_003D._0023_003Dzu2kDK40_003D, ref _0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D, ref _0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D);
		return true;
	}

	public static bool _0023_003Dz2xhS3s0NNk1u(Solid _0023_003DzcDEsV8s_003D, Solid _0023_003DzCX9Hbao_003D, Solid._0023_003Dz6tkLYNg_003D _0023_003DzwY9ClXw_003D, ref int _0023_003Dz_QUSpOe9HxGQ, ref Solid.Portion _0023_003DzjaJkTOR_0024GKMNl0le3g_003D_003D)
	{
		int num = 0;
		int num2;
		do
		{
			num2 = num;
			num = 0;
			for (int i = 0; i < _0023_003DzcDEsV8s_003D.portions.Count; i++)
			{
				NpStr npStr = _0023_003DzcDEsV8s_003D.NpStrList[i];
				if (Math.Abs(npStr.lab) == 1)
				{
					num++;
					continue;
				}
				npStr.lab = 0;
				_0023_003DzjaJkTOR_0024GKMNl0le3g_003D_003D = _0023_003DzcDEsV8s_003D.portions[npStr.hnp - 1];
				Solid.Portion _0023_003Dzd9ZyL64_003D = _0023_003DzjaJkTOR_0024GKMNl0le3g_003D_003D;
				if (!_0023_003Dz7Gxr5neAgGQt(_0023_003DzcDEsV8s_003D, npStr, _0023_003Dzd9ZyL64_003D, _0023_003DzwY9ClXw_003D, _0023_003Dz_QUSpOe9HxGQ))
				{
					return false;
				}
				if (npStr.lab != 0)
				{
					if (npStr.lab == 1)
					{
						_ = _0023_003Dz_QUSpOe9HxGQ;
					}
					num++;
				}
			}
		}
		while (num != _0023_003DzcDEsV8s_003D.portions.Count && num != num2);
		if (num != _0023_003DzcDEsV8s_003D.portions.Count)
		{
			Solid._0023_003DzZhsUDUz3mSgC _0023_003DzqunuPEk_003D = (Solid._0023_003DzZhsUDUz3mSgC)0;
			for (int j = 0; j < _0023_003DzcDEsV8s_003D.portions.Count; j++)
			{
				NpStr npStr = _0023_003DzcDEsV8s_003D.NpStrList[j];
				if (Math.Abs(npStr.lab) != 1)
				{
					Solid.Portion portion = _0023_003DzcDEsV8s_003D.portions[npStr.hnp - 1];
					if (_0023_003DzkdnrtE4uzPF8(portion.localMin, portion.localMax, _0023_003DzCX9Hbao_003D.localMin, _0023_003DzCX9Hbao_003D.localMax, ref _0023_003DzqunuPEk_003D))
					{
						return false;
					}
					npStr.lab = _0023_003DzWcFryM2f4oKo(_0023_003DzqunuPEk_003D, _0023_003DzwY9ClXw_003D, ref _0023_003Dz_QUSpOe9HxGQ);
					if (npStr.lab != 0 && npStr.lab == 1)
					{
						_ = _0023_003Dz_QUSpOe9HxGQ;
					}
				}
			}
		}
		return true;
	}

	private static int _0023_003DzWcFryM2f4oKo(Solid._0023_003DzZhsUDUz3mSgC _0023_003DzqunuPEk_003D, Solid._0023_003Dz6tkLYNg_003D _0023_003DzwY9ClXw_003D, ref int _0023_003Dz_QUSpOe9HxGQ)
	{
		switch (_0023_003DzwY9ClXw_003D)
		{
		case (Solid._0023_003Dz6tkLYNg_003D)0:
			return _0023_003DzqunuPEk_003D switch
			{
				(Solid._0023_003DzZhsUDUz3mSgC)2 => 1, 
				(Solid._0023_003DzZhsUDUz3mSgC)1 => -1, 
				_ => 0, 
			};
		case (Solid._0023_003Dz6tkLYNg_003D)1:
			return _0023_003DzqunuPEk_003D switch
			{
				(Solid._0023_003DzZhsUDUz3mSgC)2 => -1, 
				(Solid._0023_003DzZhsUDUz3mSgC)1 => 1, 
				_ => 0, 
			};
		case (Solid._0023_003Dz6tkLYNg_003D)2:
			if (_0023_003Dz_QUSpOe9HxGQ == 1)
			{
				if (_0023_003DzqunuPEk_003D == (Solid._0023_003DzZhsUDUz3mSgC)2)
				{
					return 1;
				}
				return -1;
			}
			if (_0023_003DzqunuPEk_003D == (Solid._0023_003DzZhsUDUz3mSgC)2)
			{
				return -1;
			}
			return 1;
		default:
			return 0;
		}
	}

	private static bool _0023_003Dz7Gxr5neAgGQt(Solid _0023_003Dz9TGtKzDrO7_0024b, NpStr _0023_003Dz_0024n2nrac_003D, Solid.Portion _0023_003Dzd9ZyL64_003D, Solid._0023_003Dz6tkLYNg_003D _0023_003DzGGUd1aw_003D, int _0023_003Dz7zWca9I_003D)
	{
		int num = 0;
		NpStr npStr = new NpStr();
		int[] array = new int[_0023_003Dzd9ZyL64_003D.edgeCount];
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.edgeCount; i++)
		{
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace >= 0 && _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace >= 0)
			{
				continue;
			}
			int num2 = ((_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace >= 0) ? _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge : _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge);
			int j;
			for (j = 0; j < num && array[j] != num2; j++)
			{
			}
			if (j < num)
			{
				continue;
			}
			array[num] = num2;
			num++;
			if (!_0023_003DzqZtmF1Q1XoHn(_0023_003Dz9TGtKzDrO7_0024b, num2, npStr, out var _))
			{
				return false;
			}
			if (Math.Abs(npStr.lab) == 1)
			{
				_0023_003Dz_0024n2nrac_003D.lab = npStr.lab;
				if (_0023_003Dz_0024n2nrac_003D.lab == 1 && _0023_003Dz7zWca9I_003D == 2 && _0023_003DzGGUd1aw_003D == (Solid._0023_003Dz6tkLYNg_003D)2)
				{
					_0023_003DzG037o6MQFwqV(_0023_003Dzd9ZyL64_003D, (Solid._0023_003Dz1IcEX2Y45sL1)1, _0023_003DzPrQP54igoJQK: true);
				}
				return true;
			}
		}
		return true;
	}

	public static bool _0023_003DzE4Wzm9I_003D(Solid _0023_003Dz9TGtKzDrO7_0024b, Solid.Portion _0023_003Dzd9ZyL64_003D, NpStr _0023_003Dz_0024n2nrac_003D, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, Solid._0023_003Dz6tkLYNg_003D _0023_003DzwY9ClXw_003D, ref int _0023_003Dz_QUSpOe9HxGQ, ref Solid.Portion _0023_003DzuTw1Lnq9N0DmAzCA9Q_003D_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		int num = 0;
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = default(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D);
		if (!_0023_003DzErgOa7Y_003D(_0023_003Dzd9ZyL64_003D, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
		{
			return false;
		}
		if (!_0023_003DzcCahah4_003D(_0023_003Dzd9ZyL64_003D, _0023_003DzwY9ClXw_003D, _0023_003Dz_QUSpOe9HxGQ))
		{
			return false;
		}
		int[] array = new int[_0023_003Dzd9ZyL64_003D.edgeCount];
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.edgeCount; i++)
		{
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace >= 0 && _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace >= 0)
			{
				continue;
			}
			int num2;
			int num3;
			int num4;
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace < 0)
			{
				num2 = _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge;
				num3 = _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace;
				num4 = i;
			}
			else
			{
				num2 = _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge;
				num3 = _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace;
				num4 = -i;
			}
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(_0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(i)].Type);
			int _0023_003DzfUgV2P8_003D;
			if (_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D != 0)
			{
				_0023_003DzfUgV2P8_003D = ((num4 <= 0) ? _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D : _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D);
				_0023_003DzfUgV2P8_003D = _0023_003Dzs_yBhgQ3xpKa(_0023_003DzfUgV2P8_003D, _0023_003DzwY9ClXw_003D, _0023_003Dz_QUSpOe9HxGQ);
			}
			else
			{
				_0023_003DzfUgV2P8_003D = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[num3].FaceLabel)._0023_003DzfUgV2P8_003D;
			}
			int j;
			for (j = 0; j < num && array[j] != num2; j++)
			{
			}
			if (j < num)
			{
				continue;
			}
			array[num] = num2;
			num++;
			if (_0023_003DzfUgV2P8_003D == 0)
			{
				_0023_003DzfUgV2P8_003D = -1;
			}
			NpStr npStr = new NpStr();
			if (!_0023_003DzqZtmF1Q1XoHn(_0023_003Dz9TGtKzDrO7_0024b, num2, npStr, out var _0023_003Dz_0024n2nrac_003D2))
			{
				return false;
			}
			if (npStr.lab == 0 || npStr.lab == -2)
			{
				npStr.lab = _0023_003DzfUgV2P8_003D;
				_0023_003Dz_0024n2nrac_003D2._0023_003DzbByTzLTAlIM7(npStr);
				if (_0023_003Dz_QUSpOe9HxGQ == 2 && _0023_003DzwY9ClXw_003D == (Solid._0023_003Dz6tkLYNg_003D)2)
				{
					_0023_003DzuTw1Lnq9N0DmAzCA9Q_003D_003D = _0023_003Dz9TGtKzDrO7_0024b.portions[npStr.hnp - 1];
					_0023_003DzG037o6MQFwqV(_0023_003DzuTw1Lnq9N0DmAzCA9Q_003D_003D, (Solid._0023_003Dz1IcEX2Y45sL1)1, _0023_003DzPrQP54igoJQK: true);
				}
			}
		}
		if (_0023_003Dz_QUSpOe9HxGQ == 2 && _0023_003DzwY9ClXw_003D == (Solid._0023_003Dz6tkLYNg_003D)2)
		{
			_0023_003DzG037o6MQFwqV(_0023_003Dzd9ZyL64_003D, (Solid._0023_003Dz1IcEX2Y45sL1)1, _0023_003DzPrQP54igoJQK: true);
		}
		if (!_0023_003Dz_0024EHl48jNZuTb(_0023_003Dzd9ZyL64_003D))
		{
			return false;
		}
		if (_0023_003Dzd9ZyL64_003D.faceCount == 0)
		{
			_0023_003Dz_0024n2nrac_003D.lab = -1;
			return true;
		}
		_0023_003DzRi71tdrYZ3fn(_0023_003Dzd9ZyL64_003D, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, _0023_003DzHC7AYP4_003D);
		if (!_0023_003DztDdwD3iU3oOP(_0023_003Dzd9ZyL64_003D))
		{
			return false;
		}
		_0023_003Dz_8JqadwXrdJr(_0023_003Dzd9ZyL64_003D);
		_0023_003DzBM2lV10uPp25(_0023_003Dzd9ZyL64_003D);
		for (int k = 1; k <= _0023_003Dzd9ZyL64_003D.edgeCount; k++)
		{
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(_0023_003Dzd9ZyL64_003D.edgeDatas[k].Type);
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 0;
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D = 0;
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D = 0;
			_0023_003Dzd9ZyL64_003D.edgeDatas[k].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
		}
		if (!_0023_003DzFxUmY8k_003D(_0023_003Dzd9ZyL64_003D, _0023_003DzHC7AYP4_003D))
		{
			_0023_003Dz_0024n2nrac_003D.ort |= 1;
		}
		else if (_0023_003Dzd9ZyL64_003D.vertexCount > 250 || _0023_003Dzd9ZyL64_003D.edgeCount > 400 || _0023_003Dzd9ZyL64_003D.faceCount > 202 || _0023_003Dzd9ZyL64_003D.contourCount > 222)
		{
			_0023_003Dz_0024n2nrac_003D.ort |= 2;
		}
		return true;
	}

	private static void _0023_003DzRi71tdrYZ3fn(Solid.Portion _0023_003Dzd9ZyL64_003D, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		BoolUser[] user = _0023_003Dzd9ZyL64_003D.user;
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.edgeCount; i++)
		{
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace > 0 && _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace <= 0 && user[i].bnd > 0f)
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[i].Angle = user[i].bnd;
				_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge = user[i].ind;
				_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace = -i;
				if (Math.Abs((double)user[i].bnd - Math.PI) < 1E-06)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].Type = 8;
				}
				else if (Math.Abs((double)user[i].bnd - Math.PI) < _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].Type = 4;
				}
			}
			else if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace > 0 && _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace <= 0 && user[i].bnd > 0f)
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[i].Angle = user[i].bnd;
				_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge = user[i].ind;
				_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace = -i;
				if (Math.Abs((double)user[i].bnd - Math.PI) < 1E-06)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].Type = 8;
				}
				else if (Math.Abs((double)user[i].bnd - Math.PI) < _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].Type = 4;
				}
			}
			else if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace > 0 && _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace > 0 && (_0023_003Dzd9ZyL64_003D.edgeDatas[i].Type & 4) <= 0)
			{
				_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D = _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace;
				_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D = _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace;
				Vector3D vector3D = _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D];
				Vector3D vector3D2 = _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHC7AYP4_003D._0023_003DzJFtUIyc_003D];
				if (Math.Abs(vector3D.X - vector3D2.X) <= 1E-06 && Math.Abs(vector3D.Y - vector3D2.Y) <= 1E-06 && Math.Abs(vector3D.Z - vector3D2.Z) <= 1E-06)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].Type = 8;
				}
			}
		}
	}

	private static bool _0023_003DzFxUmY8k_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[1].FaceLabel);
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D = 1;
		_0023_003Dzd9ZyL64_003D.faces[1].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
		int num = 1;
		int num2;
		do
		{
			num2 = num;
			num = 0;
			for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
			{
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel);
				if (_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D == 1)
				{
					num++;
					continue;
				}
				int num3 = _0023_003Dzd9ZyL64_003D.faces[i].FirstContour;
				do
				{
					int firstEdge;
					int num4 = (firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num3].FirstEdge);
					do
					{
						_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzikKjBI8_003D(num4, _0023_003Dzd9ZyL64_003D);
						if (_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D > 0 && _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[_0023_003DzHC7AYP4_003D._0023_003DztJBEo_00248_003D].FaceLabel)._0023_003DzfUgV2P8_003D == 1)
						{
							_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D = 1;
							_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
							num++;
							break;
						}
						num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num4, _0023_003Dzd9ZyL64_003D);
					}
					while (num4 != firstEdge);
					num3 = _0023_003Dzd9ZyL64_003D.cycles[num3].NextContour;
				}
				while (num3 != 0 && _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D == 0);
			}
		}
		while (num != num2 && num != _0023_003Dzd9ZyL64_003D.faceCount);
		if (num == _0023_003Dzd9ZyL64_003D.faceCount)
		{
			return true;
		}
		return false;
	}

	private static bool _0023_003DzBM2lV10uPp25(Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		int num = 1;
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.contourCount; i++)
		{
			if (_0023_003Dzd9ZyL64_003D.cycles[i].FirstEdge == 0)
			{
				continue;
			}
			if (i != num)
			{
				_0023_003Dzd9ZyL64_003D.cycles[num].NextContour = _0023_003Dzd9ZyL64_003D.cycles[i].NextContour;
				_0023_003Dzd9ZyL64_003D.cycles[num].FirstEdge = _0023_003Dzd9ZyL64_003D.cycles[i].FirstEdge;
				int num2 = 1;
				while (true)
				{
					if (num2 <= num - 1)
					{
						if (_0023_003Dzd9ZyL64_003D.cycles[num2].NextContour == i)
						{
							_0023_003Dzd9ZyL64_003D.cycles[num2].NextContour = num;
							break;
						}
						num2++;
						continue;
					}
					num2 = i + 1;
					while (true)
					{
						if (num2 <= _0023_003Dzd9ZyL64_003D.contourCount)
						{
							if (_0023_003Dzd9ZyL64_003D.cycles[num2].NextContour == i)
							{
								_0023_003Dzd9ZyL64_003D.cycles[num2].NextContour = num;
								break;
							}
							num2++;
							continue;
						}
						for (num2 = 1; num2 <= _0023_003Dzd9ZyL64_003D.faceCount; num2++)
						{
							if (_0023_003Dzd9ZyL64_003D.faces[num2].FirstContour == i)
							{
								_0023_003Dzd9ZyL64_003D.faces[num2].FirstContour = num;
								break;
							}
						}
						break;
					}
					break;
				}
			}
			num++;
		}
		num = (_0023_003Dzd9ZyL64_003D.contourCount = num - 1);
		return true;
	}

	internal static bool _0023_003Dz_8JqadwXrdJr(Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		int vertexCount = _0023_003Dzd9ZyL64_003D.vertexCount;
		int num = _0023_003Dzd9ZyL64_003D.edgeCount + 1;
		int num2 = 0;
		for (int i = 0; i < vertexCount; i++)
		{
			int num3 = -1;
			for (int j = 1; j < num; j++)
			{
				if (_0023_003Dzd9ZyL64_003D.edgeDatas[j].BeginVertex == i)
				{
					if (num3 == -1)
					{
						if (i != num2)
						{
							_0023_003Dzd9ZyL64_003D._vertices[num2].X = _0023_003Dzd9ZyL64_003D._vertices[i].X;
							_0023_003Dzd9ZyL64_003D._vertices[num2].Y = _0023_003Dzd9ZyL64_003D._vertices[i].Y;
							_0023_003Dzd9ZyL64_003D._vertices[num2].Z = _0023_003Dzd9ZyL64_003D._vertices[i].Z;
						}
						num3 = num2;
						num2++;
					}
					_0023_003Dzd9ZyL64_003D.edgeDatas[j].BeginVertex = num3;
				}
				else
				{
					if (_0023_003Dzd9ZyL64_003D.edgeDatas[j].EndVertex != i)
					{
						continue;
					}
					if (num3 == -1)
					{
						if (i != num2)
						{
							_0023_003Dzd9ZyL64_003D._vertices[num2].X = _0023_003Dzd9ZyL64_003D._vertices[i].X;
							_0023_003Dzd9ZyL64_003D._vertices[num2].Y = _0023_003Dzd9ZyL64_003D._vertices[i].Y;
							_0023_003Dzd9ZyL64_003D._vertices[num2].Z = _0023_003Dzd9ZyL64_003D._vertices[i].Z;
						}
						num3 = num2;
						num2++;
					}
					_0023_003Dzd9ZyL64_003D.edgeDatas[j].EndVertex = num3;
				}
			}
		}
		_0023_003Dzd9ZyL64_003D.vertexCount = num2;
		return true;
	}

	internal static bool _0023_003DztDdwD3iU3oOP(Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		int num = 1;
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.edgeCount; i++)
		{
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace <= 0 && _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace <= 0)
			{
				continue;
			}
			if (i != num)
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[num].BeginVertex = _0023_003Dzd9ZyL64_003D.edgeDatas[i].BeginVertex;
				_0023_003Dzd9ZyL64_003D.edgeDatas[num].Type = _0023_003Dzd9ZyL64_003D.edgeDatas[i].Type;
				_0023_003Dzd9ZyL64_003D.edgeDatas[num].EndVertex = _0023_003Dzd9ZyL64_003D.edgeDatas[i].EndVertex;
				_0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousEdge = _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge;
				_0023_003Dzd9ZyL64_003D.edgeDatas[num].NextEdge = _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge;
				_0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousFace = _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace;
				_0023_003Dzd9ZyL64_003D.edgeDatas[num].NextFace = _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace;
				_0023_003Dzd9ZyL64_003D.edgeDatas[num].Angle = _0023_003Dzd9ZyL64_003D.edgeDatas[i].Angle;
				if (_0023_003Dzd9ZyL64_003D.edgeDatas[num].NextFace < 0)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[num].NextFace = -num;
				}
				if (_0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousFace < 0)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[num].PreviousFace = -num;
				}
				int num2 = -1;
				for (int j = 1; j <= 2; j++)
				{
					num2 = -num2;
					int num3 = i * num2;
					int num4 = ((num3 <= 0) ? _0023_003Dzd9ZyL64_003D.edgeDatas[-num3].PreviousFace : _0023_003Dzd9ZyL64_003D.edgeDatas[num3].NextFace);
					if (num4 < 0)
					{
						continue;
					}
					int num5 = 0;
					while (true)
					{
						num5++;
						int num6 = num3;
						num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dzd9ZyL64_003D);
						if (num3 == 0)
						{
							break;
						}
						if (num3 > _0023_003Dzd9ZyL64_003D.edgeCount || num3 < -_0023_003Dzd9ZyL64_003D.edgeCount || num5 > _0023_003Dzd9ZyL64_003D.edgeCount)
						{
							return false;
						}
						if (num3 == i * num2)
						{
							if (num6 < 0)
							{
								_0023_003Dzd9ZyL64_003D.edgeDatas[-num6].PreviousEdge = num * num2;
							}
							else
							{
								_0023_003Dzd9ZyL64_003D.edgeDatas[num6].NextEdge = num * num2;
							}
							break;
						}
					}
				}
				int num7 = -i;
				for (int num5 = 1; num5 <= _0023_003Dzd9ZyL64_003D.contourCount; num5++)
				{
					if (_0023_003Dzd9ZyL64_003D.cycles[num5].FirstEdge == i)
					{
						_0023_003Dzd9ZyL64_003D.cycles[num5].FirstEdge = num;
					}
					else if (_0023_003Dzd9ZyL64_003D.cycles[num5].FirstEdge == num7)
					{
						_0023_003Dzd9ZyL64_003D.cycles[num5].FirstEdge = -num;
					}
				}
			}
			num++;
		}
		num = (_0023_003Dzd9ZyL64_003D.edgeCount = num - 1);
		return true;
	}

	private static bool _0023_003Dz_0024EHl48jNZuTb(Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		int num = 1;
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
		{
			_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel);
			int num2;
			if (_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D == 1)
			{
				if (i != num)
				{
					_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D = 0;
					_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003Dzy3xqLbo_003D = 0;
					_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
					_0023_003Dzd9ZyL64_003D.faces[num].FirstContour = _0023_003Dzd9ZyL64_003D.faces[i].FirstContour;
					Solid.Portion._0023_003Dz9HpVHgpIe5Kw(_0023_003Dzd9ZyL64_003D.faces, i, _0023_003Dzd9ZyL64_003D.faces, num);
					_0023_003Dzd9ZyL64_003D.planes[num].D = _0023_003Dzd9ZyL64_003D.planes[i].D;
					_0023_003Dzd9ZyL64_003D.planes[num].X = _0023_003Dzd9ZyL64_003D.planes[i].X;
					_0023_003Dzd9ZyL64_003D.planes[num].Y = _0023_003Dzd9ZyL64_003D.planes[i].Y;
					_0023_003Dzd9ZyL64_003D.planes[num].Z = _0023_003Dzd9ZyL64_003D.planes[i].Z;
					num2 = _0023_003Dzd9ZyL64_003D.faces[i].FirstContour;
					do
					{
						int num4;
						int num3 = (num4 = _0023_003Dzd9ZyL64_003D.cycles[num2].FirstEdge);
						int num5 = 0;
						do
						{
							num5++;
							if (num4 < 0)
							{
								_0023_003Dzd9ZyL64_003D.edgeDatas[-num4].PreviousFace = num;
								num4 = _0023_003Dzd9ZyL64_003D.edgeDatas[-num4].PreviousEdge;
							}
							else
							{
								_0023_003Dzd9ZyL64_003D.edgeDatas[num4].NextFace = num;
								num4 = _0023_003Dzd9ZyL64_003D.edgeDatas[num4].NextEdge;
							}
							if (num4 > _0023_003Dzd9ZyL64_003D.edgeCount || num4 < -_0023_003Dzd9ZyL64_003D.edgeCount || num5 > _0023_003Dzd9ZyL64_003D.edgeCount)
							{
								return false;
							}
						}
						while (num4 != num3);
						num2 = _0023_003Dzd9ZyL64_003D.cycles[num2].NextContour;
					}
					while (num2 > 0);
				}
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[num].FaceLabel);
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003Dzy3xqLbo_003D = 0;
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D = 0;
				_0023_003Dzd9ZyL64_003D.faces[num].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
				num++;
				continue;
			}
			num2 = _0023_003Dzd9ZyL64_003D.faces[i].FirstContour;
			do
			{
				int num4;
				int num3 = (num4 = _0023_003Dzd9ZyL64_003D.cycles[num2].FirstEdge);
				int num5 = 0;
				do
				{
					num5++;
					int num6;
					if (num4 < 0)
					{
						num6 = _0023_003Dzd9ZyL64_003D.edgeDatas[-num4].PreviousEdge;
						_0023_003Dzd9ZyL64_003D.edgeDatas[-num4].PreviousFace = 0;
						_0023_003Dzd9ZyL64_003D.edgeDatas[-num4].PreviousEdge = 0;
					}
					else
					{
						num6 = _0023_003Dzd9ZyL64_003D.edgeDatas[num4].NextEdge;
						_0023_003Dzd9ZyL64_003D.edgeDatas[num4].NextFace = 0;
						_0023_003Dzd9ZyL64_003D.edgeDatas[num4].NextEdge = 0;
					}
					num4 = num6;
					if (num4 > _0023_003Dzd9ZyL64_003D.edgeCount || num4 < -_0023_003Dzd9ZyL64_003D.edgeCount || num5 > _0023_003Dzd9ZyL64_003D.edgeCount)
					{
						return false;
					}
				}
				while (num4 != num3);
				_0023_003Dzd9ZyL64_003D.cycles[num2].FirstEdge = 0;
				num2 = _0023_003Dzd9ZyL64_003D.cycles[num2].NextContour;
			}
			while (num2 > 0);
		}
		num = (_0023_003Dzd9ZyL64_003D.faceCount = num - 1);
		return true;
	}

	private static bool _0023_003DzcCahah4_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, Solid._0023_003Dz6tkLYNg_003D _0023_003DzGGUd1aw_003D, int _0023_003Dz7zWca9I_003D)
	{
		bool _0023_003DzUxaV_00244M_003D = true;
		_0023_003DznTyE_0024ftDrz_0024SP3mSVbTii3X_coKK[] _0023_003DzJmi21tw1T_0024SM = _0023_003Dz0WPnITtCpPBSzKcmKg_003D_003D(null, 0);
		int faceCount = _0023_003Dzd9ZyL64_003D.faceCount;
		for (int i = 1; i <= faceCount; i++)
		{
			if (!_0023_003DzsdM1YTTecHHx(_0023_003Dzd9ZyL64_003D, i, _0023_003DzJmi21tw1T_0024SM, _0023_003DzUxaV_00244M_003D))
			{
				return false;
			}
		}
		if (_0023_003Dzd9ZyL64_003D.faceCount > faceCount)
		{
			_0023_003Dzhcy7qUH748_00246(_0023_003Dzd9ZyL64_003D, faceCount);
		}
		faceCount = _0023_003DzAd6wr8xrQAME(_0023_003Dzd9ZyL64_003D, _0023_003DzGGUd1aw_003D, _0023_003Dz7zWca9I_003D);
		if (faceCount == 0)
		{
			return false;
		}
		if (faceCount != _0023_003Dzd9ZyL64_003D.faceCount && !_0023_003DzwQpyi0rl9tk7(_0023_003Dzd9ZyL64_003D))
		{
			return false;
		}
		return true;
	}

	private static bool _0023_003DzwQpyi0rl9tk7(Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		int num = 0;
		int num2;
		do
		{
			num2 = 0;
			for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
			{
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel);
				if (_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003Dzy3xqLbo_003D == 1)
				{
					num2++;
					continue;
				}
				int num3 = _0023_003Dzd9ZyL64_003D.faces[i].FirstContour;
				do
				{
					int firstEdge;
					int num4 = (firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num3].FirstEdge);
					while (true)
					{
						int num5 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzikKjBI8_003D(num4, _0023_003Dzd9ZyL64_003D);
						if (num5 > 0)
						{
							_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[num5].FaceLabel);
							if (_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3._0023_003Dzy3xqLbo_003D == 1)
							{
								break;
							}
						}
						num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num4, _0023_003Dzd9ZyL64_003D);
						if (firstEdge != num4)
						{
							continue;
						}
						goto IL_00e0;
					}
					_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D = _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3._0023_003DzfUgV2P8_003D;
					_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003Dzy3xqLbo_003D = 1;
					_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
					num2++;
					break;
					IL_00e0:
					num3 = _0023_003Dzd9ZyL64_003D.cycles[num3].NextContour;
				}
				while (num3 > 0);
			}
			if (num == num2)
			{
				return false;
			}
			num = num2;
		}
		while (num2 != _0023_003Dzd9ZyL64_003D.faceCount);
		return true;
	}

	private static int _0023_003DzAd6wr8xrQAME(Solid.Portion _0023_003Dzd9ZyL64_003D, Solid._0023_003Dz6tkLYNg_003D _0023_003DzGGUd1aw_003D, int _0023_003Dz7zWca9I_003D)
	{
		int num = 0;
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = default(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D);
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
		{
			_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel);
			_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003Dzy3xqLbo_003D = 0;
			_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
			int num2 = 0;
			int num3 = _0023_003Dzd9ZyL64_003D.faces[i].FirstContour;
			do
			{
				int firstEdge;
				int num4 = (firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num3].FirstEdge);
				do
				{
					_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(_0023_003Dzd9ZyL64_003D.edgeDatas[Math.Abs(num4)].Type);
					if (_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D != 0)
					{
						int _0023_003DzfUgV2P8_003D = ((num4 <= 0) ? _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dz3u03JZA_003D : _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzi6QKiYM_003D);
						if (num2 == 0)
						{
							num2 = 1;
							_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D = _0023_003Dzs_yBhgQ3xpKa(_0023_003DzfUgV2P8_003D, _0023_003DzGGUd1aw_003D, _0023_003Dz7zWca9I_003D);
							_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003Dzy3xqLbo_003D = 1;
							_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
							num++;
						}
						else
						{
							_0023_003DzfUgV2P8_003D = _0023_003Dzs_yBhgQ3xpKa(_0023_003DzfUgV2P8_003D, _0023_003DzGGUd1aw_003D, _0023_003Dz7zWca9I_003D);
							if (_0023_003DzfUgV2P8_003D != _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D)
							{
								return 0;
							}
						}
					}
					num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num4, _0023_003Dzd9ZyL64_003D);
				}
				while (firstEdge != num4);
				num3 = _0023_003Dzd9ZyL64_003D.cycles[num3].NextContour;
			}
			while (num3 > 0);
		}
		return num;
	}

	private static void _0023_003Dzhcy7qUH748_00246(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzFIUUj4_lWyDX)
	{
		for (int i = _0023_003DzFIUUj4_lWyDX + 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
		{
			int num = _0023_003Dzd9ZyL64_003D.faces[i].FirstContour;
			do
			{
				int firstEdge;
				int num2 = (firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num].FirstEdge);
				do
				{
					if (num2 > 0)
					{
						_0023_003Dzd9ZyL64_003D.edgeDatas[num2].NextFace = i;
					}
					else
					{
						_0023_003Dzd9ZyL64_003D.edgeDatas[-num2].PreviousFace = i;
					}
					num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num2, _0023_003Dzd9ZyL64_003D);
				}
				while (num2 != firstEdge && num2 != 0);
				num = _0023_003Dzd9ZyL64_003D.cycles[num].NextContour;
			}
			while (num > 0);
		}
	}

	private static bool _0023_003DzsdM1YTTecHHx(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U, _0023_003DznTyE_0024ftDrz_0024SP3mSVbTii3X_coKK[] _0023_003DzJmi21tw1T_0024SM, bool _0023_003DzUxaV_00244M_003D)
	{
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		double _0023_003DznWP_EOA_003D = 0.0;
		int num5 = _0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour;
		do
		{
			if (!_0023_003Dzb5s_QVDKyNld(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, num5, ref _0023_003DznWP_EOA_003D) && _0023_003DzUxaV_00244M_003D)
			{
				return false;
			}
			if (_0023_003DznWP_EOA_003D < 0.0)
			{
				_0023_003DzJmi21tw1T_0024SM[num2]._0023_003Dz3HMcSpc_003D = _0023_003DznWP_EOA_003D;
				_0023_003DzJmi21tw1T_0024SM[num2]._0023_003Dzb1TYgY8_003D = num5;
				num2++;
				if (num2 == _0023_003DzJmi21tw1T_0024SM.Length && (_0023_003DzJmi21tw1T_0024SM = _0023_003Dz0WPnITtCpPBSzKcmKg_003D_003D(_0023_003DzJmi21tw1T_0024SM, _0023_003DzJmi21tw1T_0024SM.Length)) == null)
				{
					return false;
				}
			}
			else if (num3 == 0)
			{
				num = num5;
				_0023_003DzJmi21tw1T_0024SM[num2]._0023_003Dz3HMcSpc_003D = _0023_003DznWP_EOA_003D;
				_0023_003DzJmi21tw1T_0024SM[num2]._0023_003Dzb1TYgY8_003D = num5;
				num2++;
				num3++;
				if (num2 == _0023_003DzJmi21tw1T_0024SM.Length && (_0023_003DzJmi21tw1T_0024SM = _0023_003Dz0WPnITtCpPBSzKcmKg_003D_003D(_0023_003DzJmi21tw1T_0024SM, _0023_003DzJmi21tw1T_0024SM.Length)) == null)
				{
					return false;
				}
			}
			else
			{
				int num6;
				if ((num6 = _0023_003DzxYj_fVYB2uNJ(_0023_003Dzd9ZyL64_003D, num5)) == 0)
				{
					return false;
				}
				_0023_003DzJmi21tw1T_0024SM[num3]._0023_003Dz1cdkDps_003D = num6;
				PlaneEquation planeEquation = _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U];
				_0023_003Dzd9ZyL64_003D.planes[num6] = new PlaneEquation(planeEquation.X, planeEquation.Y, planeEquation.Z, planeEquation.D);
				Solid.Portion._0023_003Dz9HpVHgpIe5Kw(_0023_003Dzd9ZyL64_003D.faces, _0023_003DzHEpjcdg2hk9U, _0023_003Dzd9ZyL64_003D.faces, num6);
				_0023_003DzJmi21tw1T_0024SM[num3]._0023_003DzqYtIt_Y_003D = _0023_003DznWP_EOA_003D;
				num3++;
				if (num3 == _0023_003DzJmi21tw1T_0024SM.Length && (_0023_003DzJmi21tw1T_0024SM = _0023_003Dz0WPnITtCpPBSzKcmKg_003D_003D(_0023_003DzJmi21tw1T_0024SM, _0023_003DzJmi21tw1T_0024SM.Length)) == null)
				{
					return false;
				}
				_0023_003Dzd9ZyL64_003D.cycles[num4].NextContour = _0023_003Dzd9ZyL64_003D.cycles[num5].NextContour;
				_0023_003Dzd9ZyL64_003D.cycles[num5].NextContour = 0;
				num5 = num4;
			}
			num4 = num5;
			num5 = _0023_003Dzd9ZyL64_003D.cycles[num5].NextContour;
		}
		while (num5 != 0);
		if (num3 == 1)
		{
			return true;
		}
		num3--;
		int num7 = 0;
		int num8 = _0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour;
		num4 = 0;
		do
		{
			if (_0023_003DzJmi21tw1T_0024SM[num7]._0023_003Dz3HMcSpc_003D > 0.0)
			{
				num4 = num8;
				num8 = _0023_003Dzd9ZyL64_003D.cycles[num8].NextContour;
				num7++;
				continue;
			}
			int num9 = 0;
			for (num5 = 1; num5 <= num3; num5++)
			{
				int firstContour = _0023_003Dzd9ZyL64_003D.faces[_0023_003DzJmi21tw1T_0024SM[num5]._0023_003Dz1cdkDps_003D].FirstContour;
				if (!(0.0 - _0023_003DzJmi21tw1T_0024SM[num7]._0023_003Dz3HMcSpc_003D > _0023_003DzJmi21tw1T_0024SM[num5]._0023_003DzqYtIt_Y_003D) && _0023_003DzBGttKnhWUTvnEgOrsA_003D_003D(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, num8, firstContour))
				{
					_0023_003DzJmi21tw1T_0024SM[num9]._0023_003DzlKOndk0_003D = firstContour;
					num9++;
					if (num9 == _0023_003DzJmi21tw1T_0024SM.Length && (_0023_003DzJmi21tw1T_0024SM = _0023_003Dz0WPnITtCpPBSzKcmKg_003D_003D(_0023_003DzJmi21tw1T_0024SM, _0023_003DzJmi21tw1T_0024SM.Length)) == null)
					{
						return false;
					}
				}
			}
			if (num9 == 0)
			{
				num4 = num8;
				num8 = _0023_003Dzd9ZyL64_003D.cycles[num8].NextContour;
				num7++;
				continue;
			}
			if (_0023_003DzBGttKnhWUTvnEgOrsA_003D_003D(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, num8, num))
			{
				_0023_003DzJmi21tw1T_0024SM[num9]._0023_003DzlKOndk0_003D = num;
				num9++;
			}
			if (num9 == 1)
			{
				int firstContour = _0023_003DzJmi21tw1T_0024SM[0]._0023_003DzlKOndk0_003D;
				if (num4 == 0)
				{
					_0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour = _0023_003Dzd9ZyL64_003D.cycles[num8].NextContour;
				}
				else
				{
					_0023_003Dzd9ZyL64_003D.cycles[num4].NextContour = _0023_003Dzd9ZyL64_003D.cycles[num8].NextContour;
				}
				_0023_003Dzd9ZyL64_003D.cycles[num8].NextContour = _0023_003Dzd9ZyL64_003D.cycles[firstContour].NextContour;
				_0023_003Dzd9ZyL64_003D.cycles[firstContour].NextContour = num8;
				num8 = ((num4 != 0) ? _0023_003Dzd9ZyL64_003D.cycles[num4].NextContour : _0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour);
				num7++;
				continue;
			}
			num9--;
			int num10 = 0;
			int _0023_003DzlKOndk0_003D = _0023_003DzJmi21tw1T_0024SM[0]._0023_003DzlKOndk0_003D;
			for (int i = 0; i <= num9; i++)
			{
				int num11 = 0;
				for (int j = 0; j <= num9; j++)
				{
					if (_0023_003DzJmi21tw1T_0024SM[i]._0023_003DzlKOndk0_003D != _0023_003DzJmi21tw1T_0024SM[j]._0023_003DzlKOndk0_003D && _0023_003DzBGttKnhWUTvnEgOrsA_003D_003D(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, _0023_003DzJmi21tw1T_0024SM[i]._0023_003DzlKOndk0_003D, _0023_003DzJmi21tw1T_0024SM[j]._0023_003DzlKOndk0_003D))
					{
						num11++;
					}
				}
				if (num11 > num10)
				{
					num10 = num11;
					_0023_003DzlKOndk0_003D = _0023_003DzJmi21tw1T_0024SM[i]._0023_003DzlKOndk0_003D;
				}
			}
			if (_0023_003DzlKOndk0_003D != num)
			{
				if (num4 == 0)
				{
					_0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour = _0023_003Dzd9ZyL64_003D.cycles[num8].NextContour;
				}
				else
				{
					_0023_003Dzd9ZyL64_003D.cycles[num4].NextContour = _0023_003Dzd9ZyL64_003D.cycles[num8].NextContour;
				}
				_0023_003Dzd9ZyL64_003D.cycles[num8].NextContour = _0023_003Dzd9ZyL64_003D.cycles[_0023_003DzlKOndk0_003D].NextContour;
				_0023_003Dzd9ZyL64_003D.cycles[_0023_003DzlKOndk0_003D].NextContour = num8;
				num8 = _0023_003Dzd9ZyL64_003D.cycles[num4].NextContour;
				num7++;
			}
			else
			{
				num4 = num8;
				num8 = _0023_003Dzd9ZyL64_003D.cycles[num8].NextContour;
				num7++;
			}
		}
		while (num8 > 0);
		return true;
	}

	private static bool _0023_003DzBGttKnhWUTvnEgOrsA_003D_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U, int _0023_003DzRI5QzVc_003D, int _0023_003DztuiZ_54_003D)
	{
		int _0023_003Dz77g161c_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(_0023_003Dzd9ZyL64_003D.cycles[_0023_003DzRI5QzVc_003D].FirstEdge, _0023_003Dzd9ZyL64_003D);
		int _0023_003DzKgSfkP4_003D;
		int _0023_003DzYlO8iIU_003D;
		if (Math.Abs(_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].X) > Math.Abs(_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].Y))
		{
			if (Math.Abs(_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].X) > Math.Abs(_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].Z))
			{
				_0023_003DzKgSfkP4_003D = 1;
				_0023_003DzYlO8iIU_003D = 2;
			}
			else
			{
				_0023_003DzKgSfkP4_003D = 0;
				_0023_003DzYlO8iIU_003D = 1;
			}
		}
		else if (Math.Abs(_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].Y) > Math.Abs(_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].Z))
		{
			_0023_003DzKgSfkP4_003D = 0;
			_0023_003DzYlO8iIU_003D = 2;
		}
		else
		{
			_0023_003DzKgSfkP4_003D = 0;
			_0023_003DzYlO8iIU_003D = 1;
		}
		int num = _0023_003Dz7DFP_00247YFgSff(_0023_003Dzd9ZyL64_003D, _0023_003Dz77g161c_003D, _0023_003DztuiZ_54_003D, _0023_003DzKgSfkP4_003D, _0023_003DzYlO8iIU_003D);
		if (num / 2 * 2 == num)
		{
			return false;
		}
		return true;
	}

	private static int _0023_003Dz7DFP_00247YFgSff(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003Dz77g161c_003D, int _0023_003DzdEvMFOw_003D, int _0023_003DzKgSfkP4_003D, int _0023_003DzYlO8iIU_003D)
	{
		int num = _0023_003Dzd9ZyL64_003D.cycles[_0023_003DzdEvMFOw_003D].FirstEdge;
		int num2 = num;
		int num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(num, _0023_003Dzd9ZyL64_003D);
		int num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num, _0023_003Dzd9ZyL64_003D);
		int num5 = 0;
		double num6 = _0023_003Dz9EtWqTI_003D(_0023_003Dzd9ZyL64_003D, _0023_003Dz77g161c_003D, _0023_003DzYlO8iIU_003D);
		double num7 = _0023_003Dz9EtWqTI_003D(_0023_003Dzd9ZyL64_003D, _0023_003Dz77g161c_003D, _0023_003DzKgSfkP4_003D);
		do
		{
			if (_0023_003Dz77g161c_003D == num3 || _0023_003Dz77g161c_003D == num4)
			{
				return 2;
			}
			double num8 = _0023_003Dz9EtWqTI_003D(_0023_003Dzd9ZyL64_003D, num3, _0023_003DzYlO8iIU_003D);
			double num9 = _0023_003Dz9EtWqTI_003D(_0023_003Dzd9ZyL64_003D, num4, _0023_003DzYlO8iIU_003D);
			double num10 = _0023_003Dz9EtWqTI_003D(_0023_003Dzd9ZyL64_003D, num3, _0023_003DzKgSfkP4_003D);
			double num11 = _0023_003Dz9EtWqTI_003D(_0023_003Dzd9ZyL64_003D, num4, _0023_003DzKgSfkP4_003D);
			if ((!(num8 < num6) || !(num9 < num6)) && (!(num8 >= num6) || !(num9 >= num6)) && num10 + (num11 - num10) * (num8 - num6) / (num8 - num9) > num7)
			{
				num5++;
			}
			num = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num, _0023_003Dzd9ZyL64_003D);
			num3 = num4;
			num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num, _0023_003Dzd9ZyL64_003D);
		}
		while (num != num2);
		if (num5 == 0)
		{
			num5 = 2;
		}
		return num5;
	}

	private static double _0023_003Dz9EtWqTI_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzyzK8swU_003D, int _0023_003DzxuJqjrs_003D)
	{
		double result = 0.0;
		switch (_0023_003DzxuJqjrs_003D)
		{
		case 0:
			result = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzyzK8swU_003D].X;
			break;
		case 1:
			result = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzyzK8swU_003D].Y;
			break;
		case 2:
			result = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzyzK8swU_003D].Z;
			break;
		}
		return result;
	}

	private static int _0023_003DzxYj_fVYB2uNJ(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzMJ9Rv10_003D)
	{
		int num = 1;
		int num2;
		while (true)
		{
			if (num <= _0023_003Dzd9ZyL64_003D.faceCount)
			{
				if (_0023_003Dzd9ZyL64_003D.faces[num].FirstContour == 0)
				{
					num2 = num;
					break;
				}
				num++;
				continue;
			}
			if (_0023_003Dzd9ZyL64_003D.faceCount == _0023_003Dzd9ZyL64_003D.MaxNof && !_0023_003DzpJYyFPVkVs7b(_0023_003Dzd9ZyL64_003D, _0023_003Dzd9ZyL64_003D.MaxNov, _0023_003Dzd9ZyL64_003D.MaxNoe, _0023_003Dzd9ZyL64_003D.MaxNof + 50, _0023_003Dzd9ZyL64_003D.MaxNoc, 0))
			{
				return 0;
			}
			num2 = ++_0023_003Dzd9ZyL64_003D.faceCount;
			break;
		}
		_0023_003Dzd9ZyL64_003D.faces[num2].FirstContour = _0023_003DzMJ9Rv10_003D;
		if (_0023_003Dzd9ZyL64_003D.planes[num2] != null)
		{
			_0023_003Dzd9ZyL64_003D.planes[num2].X = 0.0;
			_0023_003Dzd9ZyL64_003D.planes[num2].Y = 0.0;
			_0023_003Dzd9ZyL64_003D.planes[num2].Z = 0.0;
			_0023_003Dzd9ZyL64_003D.planes[num2].D = 0.0;
		}
		_0023_003Dzd9ZyL64_003D.faces[num2].FaceLabel = 0;
		return num2;
	}

	private static bool _0023_003Dzb5s_QVDKyNld(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U, int _0023_003DzdEvMFOw_003D, ref double _0023_003DznWP_EOA_003D)
	{
		bool result = true;
		int firstEdge = _0023_003Dzd9ZyL64_003D.cycles[_0023_003DzdEvMFOw_003D].FirstEdge;
		int num = firstEdge;
		int num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(num, _0023_003Dzd9ZyL64_003D);
		int num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num, _0023_003Dzd9ZyL64_003D);
		num = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num, _0023_003Dzd9ZyL64_003D);
		int num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num, _0023_003Dzd9ZyL64_003D);
		if (num4 == num2)
		{
			result = false;
		}
		Point3D point3D = new Point3D();
		Point3D point3D2 = _0023_003Dzd9ZyL64_003D._vertices[num2] - _0023_003Dzd9ZyL64_003D._vertices[num3];
		int num5 = 0;
		do
		{
			num5++;
			if (num5 > _0023_003Dzd9ZyL64_003D.edgeCount)
			{
				return false;
			}
			Point3D point3D3 = _0023_003Dzd9ZyL64_003D._vertices[num2] - _0023_003Dzd9ZyL64_003D._vertices[num4];
			Vector3D vector3D = Vector3D.Cross(point3D2, point3D3);
			point3D.X += vector3D.X;
			point3D.Y += vector3D.Y;
			point3D.Z += vector3D.Z;
			num = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num, _0023_003Dzd9ZyL64_003D);
			num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num, _0023_003Dzd9ZyL64_003D);
			point3D2.X = point3D3.X;
			point3D2.Y = point3D3.Y;
			point3D2.Z = point3D3.Z;
			if (num4 == num3)
			{
				result = false;
			}
			num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(num, _0023_003Dzd9ZyL64_003D);
		}
		while (num != firstEdge);
		_0023_003DznWP_EOA_003D = _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].X * point3D.X + _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].Y * point3D.Y + _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U].Z * point3D.Z;
		return result;
	}

	private static _0023_003DznTyE_0024ftDrz_0024SP3mSVbTii3X_coKK[] _0023_003Dz0WPnITtCpPBSzKcmKg_003D_003D(_0023_003DznTyE_0024ftDrz_0024SP3mSVbTii3X_coKK[] _0023_003DzhDUC9Ao_003D, int _0023_003Dzcv8o5nO25OjS)
	{
		_0023_003Dzcv8o5nO25OjS += 20;
		_0023_003DznTyE_0024ftDrz_0024SP3mSVbTii3X_coKK[] array = new _0023_003DznTyE_0024ftDrz_0024SP3mSVbTii3X_coKK[_0023_003Dzcv8o5nO25OjS];
		if (_0023_003DzhDUC9Ao_003D == null)
		{
			return array;
		}
		Array.Copy(_0023_003DzhDUC9Ao_003D, array, _0023_003Dzcv8o5nO25OjS - 20);
		return array;
	}

	private static bool _0023_003DzErgOa7Y_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, double _0023_003DzkRSfKls1SLfn)
	{
		int _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D = 0;
		int _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D2 = 0;
		for (short num = 1; num <= _0023_003Dzd9ZyL64_003D.faceCount; num++)
		{
			int num2 = _0023_003Dzd9ZyL64_003D.faces[num].FirstContour;
			int num3;
			do
			{
				num3 = num2;
				num2 = _0023_003Dzd9ZyL64_003D.cycles[num2].NextContour;
			}
			while (num2 > 0);
			if (num2 != 0)
			{
				num2 = -num2;
				_0023_003Dzd9ZyL64_003D.cycles[num3].NextContour = 0;
				int num4 = _0023_003Dzd9ZyL64_003D.cycles[num2].FirstEdge;
				while (true)
				{
					int num5 = num4;
					if (num5 == 0)
					{
						break;
					}
					num4 = _0023_003Dzd9ZyL64_003D.edgeDatas[num4].NextEdge;
					_0023_003Dzd9ZyL64_003D.cycles[num2].FirstEdge = num4;
					_0023_003Dzd9ZyL64_003D.edgeDatas[num5].NextEdge = -num5;
					_0023_003Dzd9ZyL64_003D.edgeDatas[num5].PreviousEdge = num5;
					int num6 = 0;
					int num7 = _0023_003DzRt7BPC1zB38_0024(_0023_003Dzd9ZyL64_003D, num, num5, ref _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D, _0023_003DzkRSfKls1SLfn);
					int num8 = _0023_003DzRt7BPC1zB38_0024(_0023_003Dzd9ZyL64_003D, num, -num5, ref _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D2, _0023_003DzkRSfKls1SLfn);
					if (num7 != 0)
					{
						num6++;
						_0023_003Dzw_0024hK_0024hYFvRbk(_0023_003Dzd9ZyL64_003D, num5, _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D);
					}
					if (num8 != 0)
					{
						num6++;
						_0023_003Dzw_0024hK_0024hYFvRbk(_0023_003Dzd9ZyL64_003D, -num5, _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D2);
					}
					switch (num6)
					{
					case 1:
						break;
					case 0:
					{
						int num9;
						if ((num9 = _0023_003DzMr8LApT7rJZr(_0023_003Dzd9ZyL64_003D, num5)) == 0)
						{
							return false;
						}
						_0023_003Dzd9ZyL64_003D.cycles[num9].NextContour = _0023_003Dzd9ZyL64_003D.faces[num].FirstContour;
						_0023_003Dzd9ZyL64_003D.faces[num].FirstContour = num9;
						break;
					}
					default:
						_0023_003DzwYVAK8UGMSQE(_0023_003Dzd9ZyL64_003D, num, num7, num8, num5);
						break;
					}
				}
			}
		}
		return true;
	}

	private static bool _0023_003DzwYVAK8UGMSQE(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U, int _0023_003Dz3dwLiNI_003D, int _0023_003DzChmMY3s_003D, int _0023_003DzTx2aqr8_003D)
	{
		if (_0023_003Dz3dwLiNI_003D == _0023_003DzChmMY3s_003D)
		{
			int num;
			if ((num = _0023_003DzMr8LApT7rJZr(_0023_003Dzd9ZyL64_003D, -_0023_003DzTx2aqr8_003D)) == 0)
			{
				return false;
			}
			_0023_003Dzd9ZyL64_003D.cycles[_0023_003Dz3dwLiNI_003D].FirstEdge = _0023_003DzTx2aqr8_003D;
			_0023_003Dzd9ZyL64_003D.cycles[num].NextContour = _0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour;
			_0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour = num;
		}
		else
		{
			int num = _0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour;
			if (num != _0023_003Dz3dwLiNI_003D)
			{
				do
				{
					if (_0023_003Dzd9ZyL64_003D.cycles[num].NextContour == _0023_003Dz3dwLiNI_003D)
					{
						_0023_003Dzd9ZyL64_003D.cycles[num].NextContour = _0023_003Dzd9ZyL64_003D.cycles[_0023_003Dz3dwLiNI_003D].NextContour;
						_0023_003Dzd9ZyL64_003D.cycles[_0023_003Dz3dwLiNI_003D].FirstEdge = 0;
						_0023_003Dzd9ZyL64_003D.cycles[_0023_003Dz3dwLiNI_003D].NextContour = 0;
						return true;
					}
					num = _0023_003Dzd9ZyL64_003D.cycles[num].NextContour;
				}
				while (num != 0);
				return false;
			}
			_0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour = _0023_003Dzd9ZyL64_003D.cycles[num].NextContour;
			_0023_003Dzd9ZyL64_003D.cycles[num].FirstEdge = 0;
			_0023_003Dzd9ZyL64_003D.cycles[num].NextContour = 0;
		}
		return true;
	}

	private static void _0023_003Dzw_0024hK_0024hYFvRbk(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzTx2aqr8_003D, int _0023_003Dzp0yOMkXKgmGL)
	{
		if (_0023_003Dzp0yOMkXKgmGL > 0)
		{
			if (_0023_003DzTx2aqr8_003D > 0)
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzTx2aqr8_003D].PreviousEdge = _0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003Dzp0yOMkXKgmGL].NextEdge;
				_0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003Dzp0yOMkXKgmGL].NextEdge = _0023_003DzTx2aqr8_003D;
			}
			else
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[-_0023_003DzTx2aqr8_003D].NextEdge = _0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003Dzp0yOMkXKgmGL].NextEdge;
				_0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003Dzp0yOMkXKgmGL].NextEdge = _0023_003DzTx2aqr8_003D;
			}
		}
		else if (_0023_003DzTx2aqr8_003D > 0)
		{
			_0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzTx2aqr8_003D].PreviousEdge = _0023_003Dzd9ZyL64_003D.edgeDatas[-_0023_003Dzp0yOMkXKgmGL].PreviousEdge;
			_0023_003Dzd9ZyL64_003D.edgeDatas[-_0023_003Dzp0yOMkXKgmGL].PreviousEdge = _0023_003DzTx2aqr8_003D;
		}
		else
		{
			_0023_003Dzd9ZyL64_003D.edgeDatas[-_0023_003DzTx2aqr8_003D].NextEdge = _0023_003Dzd9ZyL64_003D.edgeDatas[-_0023_003Dzp0yOMkXKgmGL].PreviousEdge;
			_0023_003Dzd9ZyL64_003D.edgeDatas[-_0023_003Dzp0yOMkXKgmGL].PreviousEdge = _0023_003DzTx2aqr8_003D;
		}
	}

	private static int _0023_003DzRt7BPC1zB38_0024(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U, int _0023_003DzTx2aqr8_003D, ref int _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D, double _0023_003DzkRSfKls1SLfn)
	{
		int num = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(_0023_003DzTx2aqr8_003D, _0023_003Dzd9ZyL64_003D);
		int _0023_003DzZe6oCrQ_003D = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(_0023_003DzTx2aqr8_003D, _0023_003Dzd9ZyL64_003D);
		int num2 = _0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour;
		do
		{
			int firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num2].FirstEdge;
			int num3 = firstEdge;
			int num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num3, _0023_003Dzd9ZyL64_003D);
			do
			{
				if (num4 == num)
				{
					int num5 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dzd9ZyL64_003D);
					if (num5 == -num3)
					{
						_0023_003DzZl0D_wEGDeCsA_khxA_003D_003D = num3;
						return num2;
					}
					if (_0023_003DzgSkUXnHX5OpW(_0023_003Dzd9ZyL64_003D, _0023_003DzZe6oCrQ_003D, num3, num5, _0023_003DzHEpjcdg2hk9U, _0023_003DzkRSfKls1SLfn))
					{
						_0023_003DzZl0D_wEGDeCsA_khxA_003D_003D = num3;
						return num2;
					}
				}
				num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dzd9ZyL64_003D);
				num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num3, _0023_003Dzd9ZyL64_003D);
			}
			while (num3 != firstEdge);
			num2 = _0023_003Dzd9ZyL64_003D.cycles[num2].NextContour;
		}
		while (num2 != 0);
		return 0;
	}

	private static bool _0023_003DzgSkUXnHX5OpW(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzZe6oCrQ_003D, int _0023_003Dzkzf4gQ0_003D, int _0023_003DzKjjcAoU_003D, int _0023_003DzHEpjcdg2hk9U, double _0023_003DzkRSfKls1SLfn)
	{
		int num = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(_0023_003Dzkzf4gQ0_003D, _0023_003Dzd9ZyL64_003D);
		int num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(_0023_003DzKjjcAoU_003D, _0023_003Dzd9ZyL64_003D);
		int num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(_0023_003Dzkzf4gQ0_003D, _0023_003Dzd9ZyL64_003D);
		Point3D a = _0023_003Dzd9ZyL64_003D._vertices[num3] - _0023_003Dzd9ZyL64_003D._vertices[num];
		Point3D b = _0023_003Dzd9ZyL64_003D._vertices[num3] - _0023_003Dzd9ZyL64_003D._vertices[num2];
		Point3D point3D = _0023_003Dzd9ZyL64_003D._vertices[num3] - _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzZe6oCrQ_003D];
		Vector3D vector3D = Vector3D.Cross(a, b);
		Vector3D v = _0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U];
		double num4 = Vector3D.Dot(vector3D, v);
		if (Math.Abs(num4) <= _0023_003DzkRSfKls1SLfn)
		{
			vector3D = Vector3D.Cross(a, point3D);
			num4 = Vector3D.Dot(vector3D, v);
			if (num4 < 0.0)
			{
				return true;
			}
			return false;
		}
		Vector3D u = Vector3D.Cross(a, point3D);
		Vector3D u2 = Vector3D.Cross(point3D, b);
		double num5 = Vector3D.Dot(u, vector3D);
		double num6 = Vector3D.Dot(u2, vector3D);
		if (num4 < _0023_003DzkRSfKls1SLfn)
		{
			if (num5 > 0.0 && num6 > 0.0)
			{
				return true;
			}
			return false;
		}
		if (num5 > 0.0 && num6 > 0.0)
		{
			return false;
		}
		return true;
	}

	public static bool _0023_003Dz25b412zrrUM6(Solid.Portion _0023_003Dzd9ZyL64_003D, Solid _0023_003DzcDEsV8s_003D)
	{
		NpStr npStr = new NpStr();
		_0023_003Dzd9ZyL64_003D.UpdateBoundingBox(null);
		npStr.ident = _0023_003Dzd9ZyL64_003D.Id;
		npStr.b = _0023_003DzcDEsV8s_003D.NbList.Count;
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.edgeCount; i++)
		{
			int nextFace = _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace;
			if (nextFace >= 0 && _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace >= 0)
			{
				continue;
			}
			int num = ((nextFace >= 0) ? _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge : _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge);
			if (npStr.len > 0)
			{
				int b = npStr.b;
				int j;
				for (j = 0; j < npStr.len; j++)
				{
					if (_0023_003DzcDEsV8s_003D.NbList[b++] == num)
					{
						break;
					}
				}
				if (j < npStr.len)
				{
					continue;
				}
			}
			_0023_003DzcDEsV8s_003D.NbList.Add(num);
			npStr.len++;
		}
		_0023_003DzcDEsV8s_003D.portions.Add(_0023_003Dzd9ZyL64_003D);
		npStr.hnp = _0023_003DzcDEsV8s_003D.portions.Count;
		_0023_003DzcDEsV8s_003D.NpStrList.Add(npStr);
		_0023_003DzcDEsV8s_003D.NpStrDict.Add(npStr.ident, npStr);
		return true;
	}

	public static bool _0023_003DzpJYyFPVkVs7b(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzgD0ie9M_003D, int _0023_003DzS6uYNj8_003D, int _0023_003Dz5ZQzltw_003D, int _0023_003Dz_IEg3Es_003D, int _0023_003Dz314GyQ_qH22c)
	{
		Array.Resize(ref _0023_003Dzd9ZyL64_003D._vertices, _0023_003DzgD0ie9M_003D);
		Array.Resize(ref _0023_003Dzd9ZyL64_003D.edgeDatas, _0023_003DzS6uYNj8_003D + 1);
		Array.Resize(ref _0023_003Dzd9ZyL64_003D.user, _0023_003DzS6uYNj8_003D + 1);
		Array.Resize(ref _0023_003Dzd9ZyL64_003D.faces, _0023_003Dz5ZQzltw_003D + 1);
		Array.Resize(ref _0023_003Dzd9ZyL64_003D.cycles, _0023_003Dz_IEg3Es_003D + 1);
		Array.Resize(ref _0023_003Dzd9ZyL64_003D.planes, _0023_003Dz5ZQzltw_003D + 1);
		if (_0023_003Dz314GyQ_qH22c != 0)
		{
			if (_0023_003Dzd9ZyL64_003D.novTemp < _0023_003Dzd9ZyL64_003D.MaxNov)
			{
				int num = _0023_003Dzd9ZyL64_003D.novTemp + _0023_003Dz314GyQ_qH22c;
				int length = _0023_003Dzd9ZyL64_003D.MaxNov - _0023_003Dzd9ZyL64_003D.novTemp;
				Array.Copy(_0023_003Dzd9ZyL64_003D._vertices, _0023_003Dzd9ZyL64_003D.novTemp, _0023_003Dzd9ZyL64_003D._vertices, num, length);
				_0023_003Dzd9ZyL64_003D.novTemp = num;
			}
			else
			{
				_0023_003Dzd9ZyL64_003D.novTemp += _0023_003Dz314GyQ_qH22c;
			}
		}
		_0023_003Dzd9ZyL64_003D.MaxNov = _0023_003DzgD0ie9M_003D;
		_0023_003Dzd9ZyL64_003D.MaxNoe = _0023_003DzS6uYNj8_003D;
		_0023_003Dzd9ZyL64_003D.MaxNof = _0023_003Dz5ZQzltw_003D;
		_0023_003Dzd9ZyL64_003D.MaxNoc = _0023_003Dz_IEg3Es_003D;
		return true;
	}

	public static bool _0023_003DzLbivDhTyQLaA(Solid.Portion _0023_003DzTKYiqJDMa59O, List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzUs3eak4_003D, PlaneEquation _0023_003Dzrgqz890sj_0024X9, Solid.Portion _0023_003DzyZZx2zHPARUh, bool _0023_003DzjMikPdqXh_0024DX, double _0023_003DzkRSfKls1SLfn)
	{
		int _0023_003DzB68dg9Q_003D = -1;
		int _0023_003DzCaPJP54_003D = -1;
		int _0023_003DzMlCq3wk_003D = -1;
		bool _0023_003Dz44_0024ru0s_003D = false;
		float num = 0f;
		int num2 = 0;
		while (num2 < _0023_003DzUs3eak4_003D.Count)
		{
			_0023_003Dz611qY1n3rRLa(_0023_003DzUs3eak4_003D[num2]._0023_003DzkKfJheA_003D, ref _0023_003DzB68dg9Q_003D, ref _0023_003DzCaPJP54_003D, ref _0023_003DzMlCq3wk_003D, ref _0023_003Dz44_0024ru0s_003D);
			num2++;
			if (_0023_003DzB68dg9Q_003D != 1)
			{
				continue;
			}
			int num3 = _0023_003Dzl3fpcQ0czKjt(_0023_003DzTKYiqJDMa59O, _0023_003DzUs3eak4_003D, num2);
			int num4;
			if (_0023_003Dz44_0024ru0s_003D)
			{
				num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzmvS45b0roOxZ(num3, _0023_003DzTKYiqJDMa59O);
				int num5 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzmvS45b0roOxZ(-num3, _0023_003DzTKYiqJDMa59O);
				if (num5 < 0)
				{
					num5 = _0023_003DzEMfkCa7_0024_Tbm(_0023_003DzTKYiqJDMa59O, Math.Abs(num3));
				}
				int num6 = _0023_003DzRzqFnX8_003D(_0023_003DzTKYiqJDMa59O, num3, _0023_003Dzrgqz890sj_0024X9);
				int num7 = _0023_003DzRzqFnX8_003D(_0023_003DzTKYiqJDMa59O, -num3, _0023_003Dzrgqz890sj_0024X9);
				if (num6 == num7)
				{
					continue;
				}
				if (num6 == 0 || num7 == 0)
				{
					if (num5 == 0)
					{
						num = _0023_003DzTKYiqJDMa59O.edgeDatas[Math.Abs(num3)].Angle;
					}
					else if (num4 > 0 && num5 > 0 && (num = _0023_003Dz1zs3WXHrvefg(_0023_003DzTKYiqJDMa59O, num3, _0023_003DzTKYiqJDMa59O.planes[num4], _0023_003DzTKYiqJDMa59O.planes[num5])) == 0f)
					{
						return false;
					}
					if ((double)num > Math.PI)
					{
						continue;
					}
				}
			}
			num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzmvS45b0roOxZ(num3, _0023_003DzTKYiqJDMa59O);
			Point3D point3D = new Point3D(_0023_003DzTKYiqJDMa59O._vertices[_0023_003DzUs3eak4_003D[num2 - 1]._0023_003Dz77g161c_003D].X, _0023_003DzTKYiqJDMa59O._vertices[_0023_003DzUs3eak4_003D[num2 - 1]._0023_003Dz77g161c_003D].Y, _0023_003DzTKYiqJDMa59O._vertices[_0023_003DzUs3eak4_003D[num2 - 1]._0023_003Dz77g161c_003D].Z);
			Point3D point3D2 = new Point3D(_0023_003DzTKYiqJDMa59O._vertices[_0023_003DzUs3eak4_003D[num2]._0023_003Dz77g161c_003D].X, _0023_003DzTKYiqJDMa59O._vertices[_0023_003DzUs3eak4_003D[num2]._0023_003Dz77g161c_003D].Y, _0023_003DzTKYiqJDMa59O._vertices[_0023_003DzUs3eak4_003D[num2]._0023_003Dz77g161c_003D].Z);
			Point3D _0023_003DzM9YhqY8_003D = point3D;
			Point3D _0023_003DzcFpS4tw_003D = point3D2;
			if (!_0023_003DzIMKWzdPmhXEx(ref _0023_003DzM9YhqY8_003D, ref _0023_003DzcFpS4tw_003D, _0023_003DzTKYiqJDMa59O.planes[num4], _0023_003Dzrgqz890sj_0024X9, _0023_003DzkRSfKls1SLfn))
			{
				return false;
			}
			int num8;
			if ((num8 = _0023_003Dzmdel3ZTIgMDe(ref _0023_003DzyZZx2zHPARUh, _0023_003DzM9YhqY8_003D, _0023_003DzkRSfKls1SLfn)) == -1)
			{
				return false;
			}
			int num9;
			if ((num9 = _0023_003Dzmdel3ZTIgMDe(ref _0023_003DzyZZx2zHPARUh, _0023_003DzcFpS4tw_003D, _0023_003DzkRSfKls1SLfn)) == -1)
			{
				return false;
			}
			if (num8 != num9)
			{
				int num10;
				if ((num10 = _0023_003Dz2bKtHInA2tx2(_0023_003DzyZZx2zHPARUh, num8, num9, _0023_003DzjMikPdqXh_0024DX)) == 0)
				{
					return false;
				}
				if (num10 >= 0)
				{
					_0023_003DzyZZx2zHPARUh.edgeDatas[num10].NextFace = 1;
				}
			}
		}
		return true;
	}

	public static bool _0023_003DztWzwn4n4VFgh(Solid.Portion _0023_003DzyZZx2zHPARUh)
	{
		bool result = true;
		int num = 0;
		int num2 = 0;
		do
		{
			int i;
			for (i = 1; i <= _0023_003DzyZZx2zHPARUh.edgeCount && ((_0023_003DzyZZx2zHPARUh.edgeDatas[i].Type & 0x1000) > 0 || (_0023_003DzyZZx2zHPARUh.edgeDatas[i].Type & 0x1000) < 0); i++)
			{
			}
			if (i > _0023_003DzyZZx2zHPARUh.edgeCount)
			{
				break;
			}
			num++;
			int num3;
			if ((num3 = _0023_003DzMr8LApT7rJZr(_0023_003DzyZZx2zHPARUh, i)) == 0)
			{
				return false;
			}
			if (num2 != 0)
			{
				_0023_003DzyZZx2zHPARUh.cycles[num2].NextContour = num3;
			}
			num2 = num3;
			int num5;
			int num4 = (num5 = i);
			_0023_003DzyZZx2zHPARUh.edgeDatas[num5].Type |= 4096;
			while (true)
			{
				int endVertex = _0023_003DzyZZx2zHPARUh.edgeDatas[num5].EndVertex;
				for (i = 1; i <= _0023_003DzyZZx2zHPARUh.edgeCount; i++)
				{
					if (_0023_003DzyZZx2zHPARUh.edgeDatas[i].BeginVertex == endVertex && _0023_003DzyZZx2zHPARUh.edgeDatas[i].NextEdge <= 0 && _0023_003DzyZZx2zHPARUh.edgeDatas[i].NextEdge >= 0)
					{
						_0023_003DzyZZx2zHPARUh.edgeDatas[num5].NextEdge = i;
						_0023_003DzyZZx2zHPARUh.edgeDatas[i].Type |= 4096;
						num5 = i;
						num++;
						break;
					}
				}
				if (i > _0023_003DzyZZx2zHPARUh.edgeCount)
				{
					num5 = num4;
					do
					{
						endVertex = _0023_003DzyZZx2zHPARUh.edgeDatas[num5].BeginVertex;
						for (i = 1; i <= _0023_003DzyZZx2zHPARUh.edgeCount; i++)
						{
							if (_0023_003DzyZZx2zHPARUh.edgeDatas[i].EndVertex == endVertex && (_0023_003DzyZZx2zHPARUh.edgeDatas[i].Type & 0x1000) <= 0 && (_0023_003DzyZZx2zHPARUh.edgeDatas[i].Type & 0x1000) >= 0)
							{
								_0023_003DzyZZx2zHPARUh.edgeDatas[i].NextEdge = num5;
								num5 = i;
								_0023_003DzyZZx2zHPARUh.edgeDatas[i].Type |= 4096;
								num++;
								break;
							}
						}
					}
					while (i <= _0023_003DzyZZx2zHPARUh.edgeCount);
					_0023_003DzyZZx2zHPARUh.cycles[num3].FirstEdge = num5;
					break;
				}
				if (_0023_003DzyZZx2zHPARUh.edgeDatas[num5].EndVertex == _0023_003DzyZZx2zHPARUh.edgeDatas[num4].BeginVertex)
				{
					_0023_003DzyZZx2zHPARUh.edgeDatas[num5].NextEdge = num4;
					break;
				}
			}
		}
		while (num < _0023_003DzyZZx2zHPARUh.edgeCount);
		for (int i = 1; i <= _0023_003DzyZZx2zHPARUh.edgeCount; i++)
		{
			if ((_0023_003DzyZZx2zHPARUh.edgeDatas[i].Type & 0x1000) != 0)
			{
				_0023_003DzyZZx2zHPARUh.edgeDatas[i].Type &= -4097;
			}
		}
		return result;
	}

	internal static bool _0023_003DzXkTom4kvjiup(_0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj6 _0023_003Dzl99UmJtSeKGe, _0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D _0023_003DzTb8tNu0_003D, bool _0023_003DzdNNjInpyceHU, ref bool _0023_003DzgEJSOA0obF6h, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, double _0023_003DzkRSfKls1SLfn)
	{
		_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2 = new _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl();
		_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DzdxBLSMNBs0J_0024 = _0023_003DzTb8tNu0_003D._0023_003DzdxBLSMNBs0J_0024;
		if (_0023_003Dzl99UmJtSeKGe._0023_003Dzgm779SfRD_0024Ey >= 8189)
		{
			if (!_0023_003DzlhTzj_0024KIMgPX(_0023_003Dzl99UmJtSeKGe._0023_003DzNyH7pRAFnWHa, ref _0023_003Dzl99UmJtSeKGe._0023_003DzSkUy_T8_003D, _0023_003Dzl99UmJtSeKGe._0023_003DzD8LAV0UV_0024g_w, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, _0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V))
			{
				return false;
			}
			_0023_003Dzl99UmJtSeKGe._0023_003Dzgm779SfRD_0024Ey = 0;
			_0023_003Dzl99UmJtSeKGe._0023_003DzD8LAV0UV_0024g_w.Clear();
			_0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V.Clear();
		}
		for (int i = 0; i < 3; i++)
		{
			_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[i] = _0023_003DznjJIQy0slhls(_0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[i], _0023_003Dzl99UmJtSeKGe._0023_003DzIf_BcY7wetn_0024, ref _0023_003Dzl99UmJtSeKGe._0023_003Dzgm779SfRD_0024Ey, _0023_003Dzl99UmJtSeKGe._0023_003DzD8LAV0UV_0024g_w, _0023_003DzkRSfKls1SLfn);
		}
		if (_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] == _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] || _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] == _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] || _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] == _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2])
		{
			return true;
		}
		if (_0023_003DzgGTPgB0kblKC(_0023_003DzTb8tNu0_003D, _0023_003DzkRSfKls1SLfn))
		{
			return true;
		}
		if (_0023_003DzgEJSOA0obF6h || !_0023_003DzdNNjInpyceHU)
		{
			_0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V.Add(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2);
		}
		else
		{
			try
			{
				_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, _0023_003DzkRSfKls1SLfn);
			}
			catch (Exception)
			{
				_0023_003DzgEJSOA0obF6h = true;
			}
		}
		return true;
	}

	private static void _0023_003DzNw__Py5emmq0(_0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj6 _0023_003Dzl99UmJtSeKGe, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl _0023_003DzEzv5_0024vo_003D, double _0023_003DzkRSfKls1SLfn)
	{
		_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2 = new _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl();
		Point3D[] array = new Point3D[3];
		Point3D[] array2 = new Point3D[3]
		{
			_0023_003Dzl99UmJtSeKGe._0023_003DzD8LAV0UV_0024g_w[_0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[0]],
			_0023_003Dzl99UmJtSeKGe._0023_003DzD8LAV0UV_0024g_w[_0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[1]],
			_0023_003Dzl99UmJtSeKGe._0023_003DzD8LAV0UV_0024g_w[_0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[2]]
		};
		if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[0], array2[1], _0023_003DzkRSfKls1SLfn) || _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[1], array2[2], _0023_003DzkRSfKls1SLfn) || _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[2], array2[0], _0023_003DzkRSfKls1SLfn))
		{
			return;
		}
		for (int i = 0; i < _0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V.Count; i++)
		{
			_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3 = _0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V[i];
			array[0] = _0023_003Dzl99UmJtSeKGe._0023_003DzD8LAV0UV_0024g_w[_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[0]];
			array[1] = _0023_003Dzl99UmJtSeKGe._0023_003DzD8LAV0UV_0024g_w[_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[1]];
			array[2] = _0023_003Dzl99UmJtSeKGe._0023_003DzD8LAV0UV_0024g_w[_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[2]];
			if (!_0023_003DzJiVs4w6WsxfGAeWJLNsPmJM_003D(array[0], array[1], array[2], array2[0], array2[1], array2[2]))
			{
				continue;
			}
			int[] array3 = new int[3]
			{
				_0023_003DzCi3506_SqxFRoHR0tQ_003D_003D(array2[0], array2[1], array2[2], array[0], _0023_003DzkRSfKls1SLfn),
				_0023_003DzCi3506_SqxFRoHR0tQ_003D_003D(array2[0], array2[1], array2[2], array[1], _0023_003DzkRSfKls1SLfn),
				_0023_003DzCi3506_SqxFRoHR0tQ_003D_003D(array2[0], array2[1], array2[2], array[2], _0023_003DzkRSfKls1SLfn)
			};
			int[] array4 = new int[3]
			{
				_0023_003DzCi3506_SqxFRoHR0tQ_003D_003D(array[0], array[1], array[2], array2[0], _0023_003DzkRSfKls1SLfn),
				_0023_003DzCi3506_SqxFRoHR0tQ_003D_003D(array[0], array[1], array[2], array2[1], _0023_003DzkRSfKls1SLfn),
				_0023_003DzCi3506_SqxFRoHR0tQ_003D_003D(array[0], array[1], array[2], array2[2], _0023_003DzkRSfKls1SLfn)
			};
			bool[] array5 = new bool[9]
			{
				_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[0], array[0], _0023_003DzkRSfKls1SLfn),
				_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[0], array[1], _0023_003DzkRSfKls1SLfn),
				_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[0], array[2], _0023_003DzkRSfKls1SLfn),
				_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[1], array[0], _0023_003DzkRSfKls1SLfn),
				_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[1], array[1], _0023_003DzkRSfKls1SLfn),
				_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[1], array[2], _0023_003DzkRSfKls1SLfn),
				_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[2], array[0], _0023_003DzkRSfKls1SLfn),
				_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[2], array[1], _0023_003DzkRSfKls1SLfn),
				_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(array2[2], array[2], _0023_003DzkRSfKls1SLfn)
			};
			bool flag = _0023_003DzLuv35v_vCRTPbIFxRnhzgr_iVCKw(array[0], array[1], array[2], array2[0], array2[1], array2[2]);
			int num = 0;
			for (int j = 0; j < 9; j++)
			{
				if (array5[j])
				{
					num++;
				}
			}
			int num2 = 0;
			int num3 = 0;
			for (int k = 0; k < 3; k++)
			{
				if (array3[k] > 0)
				{
					num2++;
				}
				if (array4[k] > 0)
				{
					num3++;
				}
			}
			if (num > 2)
			{
				return;
			}
			if (num > 1 && !flag)
			{
				_0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V.Add(_0023_003DzEzv5_0024vo_003D);
				return;
			}
			if (num > 1 && flag)
			{
				if (num3 <= 0)
				{
					if (num2 > 0)
					{
						_0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V[i]._0023_003Dz4COs0RWAfHca(_0023_003DzEzv5_0024vo_003D);
					}
					else
					{
						_0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V.Add(_0023_003DzEzv5_0024vo_003D);
					}
				}
				return;
			}
			if (num == 1 && num3 > 1)
			{
				return;
			}
			if (num == 1 && num2 > 1)
			{
				_0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V[i]._0023_003Dz4COs0RWAfHca(_0023_003DzEzv5_0024vo_003D);
				return;
			}
			if (num2 == 0 && num3 == 0)
			{
				continue;
			}
			for (int l = 0; l < 3; l++)
			{
				if (num2 >= 1)
				{
					if (array3[l] == 1)
					{
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DztGdcVOA_003D();
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[0];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[l];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[2];
						if (_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] == 1193 && _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] == 1199)
						{
							_ = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2];
						}
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, _0023_003DzkRSfKls1SLfn);
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[l];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[1];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[2];
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, _0023_003DzkRSfKls1SLfn);
						return;
					}
					if (array3[l] == 2)
					{
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DztGdcVOA_003D();
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[0];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[1];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[l];
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, _0023_003DzkRSfKls1SLfn);
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[0];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[l];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[2];
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, _0023_003DzkRSfKls1SLfn);
						return;
					}
					if (array3[l] == 3)
					{
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DztGdcVOA_003D();
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[1];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[2];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[l];
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, _0023_003DzkRSfKls1SLfn);
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[1];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[l];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[0];
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, _0023_003DzkRSfKls1SLfn);
						return;
					}
				}
				if (num3 >= 1)
				{
					if (array4[l] == 1)
					{
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DztGdcVOA_003D();
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[0];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[l];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[2];
						_0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V[i]._0023_003Dz4COs0RWAfHca(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2);
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[l];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[1];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[2];
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, _0023_003DzkRSfKls1SLfn);
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzEzv5_0024vo_003D, _0023_003DzkRSfKls1SLfn);
						return;
					}
					if (array4[l] == 2)
					{
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DztGdcVOA_003D();
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[1];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[l];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[0];
						_0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V[i]._0023_003Dz4COs0RWAfHca(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2);
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[l];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[2];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[0];
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, _0023_003DzkRSfKls1SLfn);
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzEzv5_0024vo_003D, _0023_003DzkRSfKls1SLfn);
						return;
					}
					if (array4[l] == 3)
					{
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DztGdcVOA_003D();
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[2];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[l];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[1];
						_0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V[i]._0023_003Dz4COs0RWAfHca(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2);
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[0] = _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[l];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[1] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[0];
						_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[2] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl3._0023_003Dz77g161c_003D[1];
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, _0023_003DzkRSfKls1SLfn);
						_0023_003DzNw__Py5emmq0(_0023_003Dzl99UmJtSeKGe, _0023_003DzEzv5_0024vo_003D, _0023_003DzkRSfKls1SLfn);
						return;
					}
				}
			}
		}
		_0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V.Add(_0023_003DzEzv5_0024vo_003D);
	}

	private static bool _0023_003DzJiVs4w6WsxfGAeWJLNsPmJM_003D(Point3D _0023_003Dz16nFYT6Gf5wF, Point3D _0023_003DzWb48nUSonhj4, Point3D _0023_003DzNKHsind0GifS, Point3D _0023_003DzlVW5T3KaM6ZN, Point3D _0023_003Dzdt8MZ27xQpwK, Point3D _0023_003DzSyy9lOJM9i8l)
	{
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		Point3D point3D3 = new Point3D();
		Point3D point3D4 = new Point3D();
		point3D.X = Math.Min(_0023_003Dz16nFYT6Gf5wF.X, Math.Min(_0023_003DzWb48nUSonhj4.X, _0023_003DzNKHsind0GifS.X)) - 0.01;
		point3D.Y = Math.Min(_0023_003Dz16nFYT6Gf5wF.Y, Math.Min(_0023_003DzWb48nUSonhj4.Y, _0023_003DzNKHsind0GifS.Y)) - 0.01;
		point3D.Z = Math.Min(_0023_003Dz16nFYT6Gf5wF.Z, Math.Min(_0023_003DzWb48nUSonhj4.Z, _0023_003DzNKHsind0GifS.Z)) - 0.01;
		point3D2.X = Math.Max(_0023_003Dz16nFYT6Gf5wF.X, Math.Max(_0023_003DzWb48nUSonhj4.X, _0023_003DzNKHsind0GifS.X)) + 0.01;
		point3D2.Y = Math.Max(_0023_003Dz16nFYT6Gf5wF.Y, Math.Max(_0023_003DzWb48nUSonhj4.Y, _0023_003DzNKHsind0GifS.Y)) + 0.01;
		point3D2.Z = Math.Max(_0023_003Dz16nFYT6Gf5wF.Z, Math.Max(_0023_003DzWb48nUSonhj4.Z, _0023_003DzNKHsind0GifS.Z)) + 0.01;
		point3D3.X = Math.Min(_0023_003DzlVW5T3KaM6ZN.X, Math.Min(_0023_003Dzdt8MZ27xQpwK.X, _0023_003DzSyy9lOJM9i8l.X)) - 0.01;
		point3D3.Y = Math.Min(_0023_003DzlVW5T3KaM6ZN.Y, Math.Min(_0023_003Dzdt8MZ27xQpwK.Y, _0023_003DzSyy9lOJM9i8l.Y)) - 0.01;
		point3D3.Z = Math.Min(_0023_003DzlVW5T3KaM6ZN.Z, Math.Min(_0023_003Dzdt8MZ27xQpwK.Z, _0023_003DzSyy9lOJM9i8l.Z)) - 0.01;
		point3D4.X = Math.Max(_0023_003DzlVW5T3KaM6ZN.X, Math.Max(_0023_003Dzdt8MZ27xQpwK.X, _0023_003DzSyy9lOJM9i8l.X)) + 0.01;
		point3D4.Y = Math.Max(_0023_003DzlVW5T3KaM6ZN.Y, Math.Max(_0023_003Dzdt8MZ27xQpwK.Y, _0023_003DzSyy9lOJM9i8l.Y)) + 0.01;
		point3D4.Z = Math.Max(_0023_003DzlVW5T3KaM6ZN.Z, Math.Max(_0023_003Dzdt8MZ27xQpwK.Z, _0023_003DzSyy9lOJM9i8l.Z)) + 0.01;
		if (point3D2.X < point3D3.X)
		{
			return false;
		}
		if (point3D2.Y < point3D3.Y)
		{
			return false;
		}
		if (point3D2.Z < point3D3.Z)
		{
			return false;
		}
		if (point3D4.X < point3D.X)
		{
			return false;
		}
		if (point3D4.Y < point3D.Y)
		{
			return false;
		}
		if (point3D4.Z < point3D.Z)
		{
			return false;
		}
		return true;
	}

	public static int _0023_003DzCi3506_SqxFRoHR0tQ_003D_003D(Point3D _0023_003DzcjP0kR4_003D, Point3D _0023_003DzXVlW_0024y4_003D, Point3D _0023_003Dzx5OfFOc_003D, Point3D _0023_003DzcNU_0024mJM_003D, double _0023_003DzkRSfKls1SLfn)
	{
		Point3D point3D = new Point3D();
		double _0023_003DzCSRWkYc_003D = 0.0;
		if (!_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzbAQBFKkei0NN(_0023_003DzcjP0kR4_003D, _0023_003DzXVlW_0024y4_003D, _0023_003Dzx5OfFOc_003D, point3D, ref _0023_003DzCSRWkYc_003D))
		{
			return 0;
		}
		if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DznvriWn0uITSS(_0023_003DzcNU_0024mJM_003D, point3D, _0023_003DzCSRWkYc_003D) > 1E-05)
		{
			return 0;
		}
		if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003DzcjP0kR4_003D, _0023_003DzcNU_0024mJM_003D, _0023_003DzkRSfKls1SLfn) || _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003DzXVlW_0024y4_003D, _0023_003DzcNU_0024mJM_003D, _0023_003DzkRSfKls1SLfn) || _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dzx5OfFOc_003D, _0023_003DzcNU_0024mJM_003D, _0023_003DzkRSfKls1SLfn))
		{
			return 0;
		}
		Point3D[] array = new Point3D[3]
		{
			_0023_003DzcjP0kR4_003D - _0023_003DzcNU_0024mJM_003D,
			_0023_003DzXVlW_0024y4_003D - _0023_003DzcNU_0024mJM_003D,
			_0023_003Dzx5OfFOc_003D - _0023_003DzcNU_0024mJM_003D
		};
		if (!_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzY50dbZ5WG8m7(array[0], _0023_003DzkRSfKls1SLfn))
		{
			return 0;
		}
		if (!_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzY50dbZ5WG8m7(array[1], _0023_003DzkRSfKls1SLfn))
		{
			return 0;
		}
		if (!_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzY50dbZ5WG8m7(array[2], _0023_003DzkRSfKls1SLfn))
		{
			return 0;
		}
		if (Vector3D.Dot(array[0], new Vector3D(array[1].X, array[1].Y, array[1].Z)) <= -0.9999999)
		{
			return 1;
		}
		if (Vector3D.Dot(array[1], new Vector3D(array[2].X, array[2].Y, array[2].Z)) <= -0.9999999)
		{
			return 2;
		}
		if (Vector3D.Dot(array[2], new Vector3D(array[0].X, array[0].Y, array[0].Z)) <= -0.9999999)
		{
			return 3;
		}
		return 0;
	}

	public static bool _0023_003DzLuv35v_vCRTPbIFxRnhzgr_iVCKw(Point3D _0023_003Dz16nFYT6Gf5wF, Point3D _0023_003DzWb48nUSonhj4, Point3D _0023_003DzNKHsind0GifS, Point3D _0023_003DzlVW5T3KaM6ZN, Point3D _0023_003Dzdt8MZ27xQpwK, Point3D _0023_003DzSyy9lOJM9i8l)
	{
		Point3D point3D = new Point3D();
		double _0023_003DzCSRWkYc_003D = 0.0;
		if (!_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzbAQBFKkei0NN(_0023_003Dz16nFYT6Gf5wF, _0023_003DzWb48nUSonhj4, _0023_003DzNKHsind0GifS, point3D, ref _0023_003DzCSRWkYc_003D))
		{
			return false;
		}
		if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DznvriWn0uITSS(_0023_003DzlVW5T3KaM6ZN, point3D, _0023_003DzCSRWkYc_003D) > 1E-05)
		{
			return false;
		}
		if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DznvriWn0uITSS(_0023_003Dzdt8MZ27xQpwK, point3D, _0023_003DzCSRWkYc_003D) > 1E-05)
		{
			return false;
		}
		if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DznvriWn0uITSS(_0023_003DzSyy9lOJM9i8l, point3D, _0023_003DzCSRWkYc_003D) > 1E-05)
		{
			return false;
		}
		return true;
	}

	private static bool _0023_003DzgGTPgB0kblKC(_0023_003Dzww0ii_LVkncidBMpEtr00ggHQU_TqSWOBQ_003D_003D _0023_003DzTb8tNu0_003D, double _0023_003DzkRSfKls1SLfn)
	{
		double num = 1.0 / Math.Pow(10.0, 7.0);
		Point3D _0023_003Dzi4cdUYM_003D = new Point3D();
		Point3D point3D = _0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[1] - _0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[0];
		Vector3D asVector = point3D.AsVector;
		if (!asVector.Normalize())
		{
			return true;
		}
		point3D.X = asVector.X;
		point3D.Y = asVector.Y;
		point3D.Z = asVector.Z;
		if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz_wQ1vNtxSvPU(_0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[0], point3D, _0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[2], ref _0023_003Dzi4cdUYM_003D, _0023_003DzkRSfKls1SLfn) < num)
		{
			return true;
		}
		asVector = Vector3D.Subtract(_0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[2], _0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[1]);
		if (!asVector.Normalize())
		{
			return true;
		}
		point3D.X = asVector.X;
		point3D.Y = asVector.Y;
		point3D.Z = asVector.Z;
		if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz_wQ1vNtxSvPU(_0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[1], point3D, _0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[0], ref _0023_003Dzi4cdUYM_003D, _0023_003DzkRSfKls1SLfn) < num)
		{
			return true;
		}
		asVector = Vector3D.Subtract(_0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[0], _0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[2]);
		if (!asVector.Normalize())
		{
			return true;
		}
		point3D.X = asVector.X;
		point3D.Y = asVector.Y;
		point3D.Z = asVector.Z;
		if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz_wQ1vNtxSvPU(_0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[2], point3D, _0023_003DzTb8tNu0_003D._0023_003Dz77g161c_003D[1], ref _0023_003Dzi4cdUYM_003D, _0023_003DzkRSfKls1SLfn) < num)
		{
			return true;
		}
		return false;
	}

	private static int _0023_003DznjJIQy0slhls(Point3D _0023_003DzB68dg9Q_003D, int[] _0023_003DzhHqYL4M_003D, ref int _0023_003DzvIZDdds_003D, List<Point3D> _0023_003DzOIztqGKPNhlh, double _0023_003DzkRSfKls1SLfn)
	{
		int num = 1;
		int num2 = -1;
		int num3 = 0;
		int num4 = _0023_003DzvIZDdds_003D - 1;
		while (num3 <= num4)
		{
			num2 = num3 + num4 >> 1;
			int num5 = _0023_003DzhHqYL4M_003D[8192 - num2 - 1];
			Point3D point3D = _0023_003DzOIztqGKPNhlh[num5];
			if (!(Math.Abs(point3D.X - _0023_003DzB68dg9Q_003D.X) < _0023_003DzkRSfKls1SLfn))
			{
				num = ((!(_0023_003DzB68dg9Q_003D.X < point3D.X)) ? 1 : (-1));
			}
			else
			{
				_0023_003DzB68dg9Q_003D.X = point3D.X;
				if (!(Math.Abs(point3D.Y - _0023_003DzB68dg9Q_003D.Y) < _0023_003DzkRSfKls1SLfn))
				{
					num = ((!(_0023_003DzB68dg9Q_003D.Y < point3D.Y)) ? 1 : (-1));
				}
				else
				{
					_0023_003DzB68dg9Q_003D.Y = point3D.Y;
					if (Math.Abs(point3D.Z - _0023_003DzB68dg9Q_003D.Z) < _0023_003DzkRSfKls1SLfn)
					{
						_0023_003DzB68dg9Q_003D.Z = point3D.Z;
						return num5;
					}
					num = ((!(_0023_003DzB68dg9Q_003D.Z < point3D.Z)) ? 1 : (-1));
				}
			}
			if (num < 0)
			{
				num4 = num2 - 1;
			}
			else
			{
				num3 = num2 + 1;
			}
		}
		if (num > 0)
		{
			num2++;
		}
		Array.Copy(_0023_003DzhHqYL4M_003D, 8192 - _0023_003DzvIZDdds_003D, _0023_003DzhHqYL4M_003D, 8192 - _0023_003DzvIZDdds_003D - 1, _0023_003DzvIZDdds_003D - num2 + 1);
		_0023_003DzhHqYL4M_003D[8192 - num2 - 1] = _0023_003DzvIZDdds_003D;
		_0023_003DzOIztqGKPNhlh.Add(_0023_003DzB68dg9Q_003D);
		_0023_003DzvIZDdds_003D++;
		return _0023_003DzvIZDdds_003D - 1;
	}

	public static bool _0023_003DzaiGd92G_0024D4Zt(Solid _0023_003DzDjLwSI9_0024B3cG, List<Solid.brepType> _0023_003Dz0SpZWCCz_qrn, double _0023_003DzkRSfKls1SLfn)
	{
		if (_0023_003DzFipFikVW1CJj(_0023_003DzDjLwSI9_0024B3cG, (Solid._0023_003Dz1IcEX2Y45sL1)1, (float)Math.PI / 6f, _0023_003Dz0SpZWCCz_qrn, _0023_003DzkRSfKls1SLfn) > 0)
		{
			return true;
		}
		return false;
	}

	internal static bool _0023_003Dzn3HP6_BOu55X(_0023_003DznIxEYS4uE__0024ie2vUaKYuO9IycKj6 _0023_003Dzl99UmJtSeKGe, List<Solid.brepType> _0023_003Dz0SpZWCCz_qrn, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, double _0023_003DzkRSfKls1SLfn)
	{
		if (_0023_003Dzl99UmJtSeKGe._0023_003Dzgm779SfRD_0024Ey <= 0)
		{
			return true;
		}
		if (!_0023_003DzlhTzj_0024KIMgPX(_0023_003Dzl99UmJtSeKGe._0023_003DzNyH7pRAFnWHa, ref _0023_003Dzl99UmJtSeKGe._0023_003DzSkUy_T8_003D, _0023_003Dzl99UmJtSeKGe._0023_003DzD8LAV0UV_0024g_w, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, _0023_003Dzl99UmJtSeKGe._0023_003Dz6d_0024WMojXY76V))
		{
			return false;
		}
		return _0023_003DzaiGd92G_0024D4Zt(_0023_003Dzl99UmJtSeKGe._0023_003DzNyH7pRAFnWHa, _0023_003Dz0SpZWCCz_qrn, _0023_003DzkRSfKls1SLfn);
	}

	private static bool _0023_003DzlhTzj_0024KIMgPX(Solid _0023_003DzcDEsV8s_003D, ref int _0023_003DzSkUy_T8_003D, List<Point3D> _0023_003DzOIztqGKPNhlh, double _0023_003Dz6pajdGM_003D, List<_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl> _0023_003Dz6d_0024WMojXY76V)
	{
		int num = 0;
		int[] _0023_003Dzlj6dLk_0024z_act = new int[401];
		int[] array = new int[250];
		_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2 = new _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl();
		while (true)
		{
			num = 0;
			Solid.Portion portion = new Solid.Portion();
			portion.Id = _0023_003DzSkUy_T8_003D;
			_0023_003DzSkUy_T8_003D++;
			int num2 = _0023_003DzOeWfWdo2I6CL(_0023_003Dz6d_0024WMojXY76V, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2);
			if (num2 == _0023_003Dz6d_0024WMojXY76V.Count)
			{
				break;
			}
			_0023_003DzH9lKsakEaYr_(portion);
			portion.vertexCount = 3;
			portion.edgeCount = 3;
			for (num2 = 0; num2 < 3; num2++)
			{
				Point3D point3D = _0023_003DzOIztqGKPNhlh[_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[num2]];
				portion._vertices[num2] = point3D;
				array[num2] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[num2];
				_0023_003Dzlj6dLk_0024z_act[num2] = num2 + 1;
				portion.edgeDatas[num2 + 1].BeginVertex = num2;
				portion.edgeDatas[num2 + 1].EndVertex = num2 + 1;
				portion.edgeDatas[num2 + 1].NextEdge = num2 + 2;
				portion.edgeDatas[num2 + 1].PreviousEdge = 0;
				portion.edgeDatas[num2 + 1].NextFace = 1;
				portion.edgeDatas[num2 + 1].PreviousFace = 0;
				portion.edgeDatas[num2 + 1].Type = _0023_003DzonU2mZDfZFtx(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DzdxBLSMNBs0J_0024, num2);
			}
			portion.edgeDatas[3].EndVertex = 0;
			portion.edgeDatas[3].NextEdge = 1;
			portion.faces[1].FirstContour = 1;
			portion.faces[1].FaceLabel = 0;
			portion.cycles[1].NextContour = 0;
			portion.cycles[1].FirstEdge = 1;
			num = 3;
			while (true)
			{
				IL_01b4:
				if (portion.vertexCount > 125 || portion.edgeCount > 395 || portion.faceCount > 197)
				{
					if (!_0023_003Dzfn6hhMMnY_jS(portion))
					{
						return false;
					}
					_0023_003Dzc_hPR3n_0024hSonkqoHSg_003D_003D(portion, _0023_003Dz6pajdGM_003D);
					if (_0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(portion, _0023_003DzcDEsV8s_003D))
					{
						break;
					}
					return false;
				}
				while (num > 0)
				{
					int num3 = _0023_003Dzlj6dLk_0024z_act[0];
					num--;
					Array.Copy(_0023_003Dzlj6dLk_0024z_act, 1, _0023_003Dzlj6dLk_0024z_act, 0, num);
					int beginVertex = portion.edgeDatas[num3].BeginVertex;
					int endVertex = portion.edgeDatas[num3].EndVertex;
					int num4 = array[beginVertex];
					int num5 = array[endVertex];
					int num6 = Math.Abs(portion.edgeDatas[num3].NextEdge);
					int endVertex2 = portion.edgeDatas[num6].EndVertex;
					int index;
					if ((index = _0023_003Dz5S_0024M0V_00246KHsl(num4, num5, _0023_003Dz6d_0024WMojXY76V, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2)) == -1)
					{
						continue;
					}
					int num7 = _0023_003DzH9lKsakEaYr_(portion);
					portion.cycles[num7].FirstEdge = -num3;
					portion.edgeDatas[num3].PreviousFace = num7;
					for (int i = 0; i < 3; i++)
					{
						if (_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[i] == num4 || _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[i] == num5)
						{
							continue;
						}
						int num8;
						if ((num8 = _0023_003DzpUmNFC0Ui6P_(array, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[i], portion)) == -1)
						{
							Point3D point3D = _0023_003DzOIztqGKPNhlh[_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[i]];
							num8 = portion.vertexCount;
							portion.vertexCount++;
							portion._vertices[num8] = point3D;
							array[num8] = _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[i];
							int num9 = ++portion.edgeCount;
							portion.edgeDatas[num9].BeginVertex = beginVertex;
							portion.edgeDatas[num9].EndVertex = num8;
							portion.edgeDatas[num9].NextEdge = num9 + 1;
							portion.edgeDatas[num9].PreviousEdge = 0;
							portion.edgeDatas[num9].NextFace = num7;
							portion.edgeDatas[num9].PreviousFace = 0;
							portion.edgeDatas[num9].Type = _0023_003DzZI9oy1fdL8Wn(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, num4, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[i]);
							portion.edgeDatas[num3].PreviousEdge = num9;
							_0023_003Dzlj6dLk_0024z_act[num] = num9;
							num++;
							int num10 = ++portion.edgeCount;
							portion.edgeDatas[num10].BeginVertex = num8;
							portion.edgeDatas[num10].EndVertex = endVertex;
							portion.edgeDatas[num10].NextEdge = -num3;
							portion.edgeDatas[num10].PreviousEdge = 0;
							portion.edgeDatas[num10].NextFace = num7;
							portion.edgeDatas[num10].PreviousFace = 0;
							portion.edgeDatas[num10].Type = _0023_003DzZI9oy1fdL8Wn(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, num5, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[i]);
							_0023_003Dzlj6dLk_0024z_act[num] = num10;
							num++;
							continue;
						}
						if (num8 != endVertex2)
						{
							int num9 = _0023_003DzYpEq4Mp_AI8n(beginVertex, num8, portion);
							int num10 = _0023_003DzYpEq4Mp_AI8n(num8, endVertex, portion);
							if (num9 != 0)
							{
								int num11 = Math.Abs(num9);
								if (num9 > 0 || (portion.edgeDatas[num11].PreviousEdge != 0 && portion.edgeDatas[num11].NextEdge != 0))
								{
									goto IL_0583;
								}
							}
							if (num10 != 0)
							{
								int num11 = Math.Abs(num10);
								if (num10 > 0 || (portion.edgeDatas[num11].PreviousEdge != 0 && portion.edgeDatas[num11].NextEdge != 0))
								{
									goto IL_060b;
								}
							}
							if (num9 == 0)
							{
								num9 = ++portion.edgeCount;
								portion.edgeDatas[num9].BeginVertex = beginVertex;
								portion.edgeDatas[num9].EndVertex = num8;
								portion.edgeDatas[num9].PreviousEdge = 0;
								portion.edgeDatas[num9].NextFace = num7;
								portion.edgeDatas[num9].PreviousFace = 0;
								portion.edgeDatas[num9].Type = _0023_003DzZI9oy1fdL8Wn(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, num4, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[i]);
								portion.edgeDatas[num3].PreviousEdge = num9;
								_0023_003Dzlj6dLk_0024z_act[num] = num9;
								num++;
							}
							else
							{
								if (num9 >= 0)
								{
									return false;
								}
								portion.edgeDatas[-num9].PreviousFace = num7;
								portion.edgeDatas[num3].PreviousEdge = num9;
								_0023_003DzeJBS0dtRR4zt(ref _0023_003Dzlj6dLk_0024z_act, ref num, -num9);
							}
							if (num10 == 0)
							{
								num10 = ++portion.edgeCount;
								portion.edgeDatas[num10].BeginVertex = num8;
								portion.edgeDatas[num10].EndVertex = endVertex;
								portion.edgeDatas[num10].NextEdge = -num3;
								portion.edgeDatas[num10].PreviousEdge = 0;
								portion.edgeDatas[num10].NextFace = num7;
								portion.edgeDatas[num10].PreviousFace = 0;
								portion.edgeDatas[num10].Type = _0023_003DzZI9oy1fdL8Wn(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2, num5, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[i]);
								if (num9 < 0)
								{
									portion.edgeDatas[-num9].PreviousEdge = num10;
								}
								else
								{
									portion.edgeDatas[num9].NextEdge = num10;
								}
								_0023_003Dzlj6dLk_0024z_act[num] = num10;
								num++;
							}
							else
							{
								if (num10 >= 0)
								{
									return false;
								}
								portion.edgeDatas[-num10].PreviousEdge = -num3;
								portion.edgeDatas[-num10].PreviousFace = num7;
								if (num9 < 0)
								{
									portion.edgeDatas[-num9].PreviousEdge = num10;
								}
								else
								{
									portion.edgeDatas[num9].NextEdge = num10;
								}
								_0023_003DzeJBS0dtRR4zt(ref _0023_003Dzlj6dLk_0024z_act, ref num, -num10);
							}
							continue;
						}
						goto IL_04ff;
					}
					goto IL_01b4;
					IL_04ff:
					portion.edgeDatas[num3].PreviousFace = 0;
					portion.faceCount--;
					portion.contourCount--;
					continue;
					IL_0583:
					portion.edgeDatas[num3].PreviousFace = 0;
					portion.faceCount--;
					portion.contourCount--;
					_0023_003Dz6d_0024WMojXY76V[index]._0023_003DzdxBLSMNBs0J_0024 &= 127;
					num = 0;
					continue;
					IL_060b:
					portion.edgeDatas[num3].PreviousFace = 0;
					portion.faceCount--;
					portion.contourCount--;
					_0023_003Dz6d_0024WMojXY76V[index]._0023_003DzdxBLSMNBs0J_0024 &= 127;
					num = 0;
				}
				if (portion.vertexCount <= 0)
				{
					break;
				}
				if (!_0023_003Dzfn6hhMMnY_jS(portion))
				{
					return false;
				}
				_0023_003Dzc_hPR3n_0024hSonkqoHSg_003D_003D(portion, _0023_003Dz6pajdGM_003D);
				if (_0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D(portion, _0023_003DzcDEsV8s_003D))
				{
					break;
				}
				return false;
			}
		}
		return true;
	}

	private static void _0023_003DzeJBS0dtRR4zt(ref int[] _0023_003Dzlj6dLk_0024z_act, ref int _0023_003DzaWXBOMXtuTAK, int _0023_003DzOp3F2SaqccCd)
	{
		for (int i = 0; i < _0023_003DzaWXBOMXtuTAK; i++)
		{
			if (_0023_003Dzlj6dLk_0024z_act[i] == _0023_003DzOp3F2SaqccCd)
			{
				_0023_003DzaWXBOMXtuTAK--;
				Array.Copy(_0023_003Dzlj6dLk_0024z_act, i + 1, _0023_003Dzlj6dLk_0024z_act, i, _0023_003DzaWXBOMXtuTAK - i);
				break;
			}
		}
	}

	private static int _0023_003DzZI9oy1fdL8Wn(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl _0023_003DzEzv5_0024vo_003D, int _0023_003DzrtkXSi0_003D, int _0023_003DzkDSiwZg_003D)
	{
		return _0023_003DzonU2mZDfZFtx((_0023_003DzrtkXSi0_003D == _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[0]) ? ((_0023_003DzkDSiwZg_003D != _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[1]) ? 2 : 0) : ((_0023_003DzrtkXSi0_003D == _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[1]) ? ((_0023_003DzkDSiwZg_003D == _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[2]) ? 1 : 0) : ((_0023_003DzkDSiwZg_003D != _0023_003DzEzv5_0024vo_003D._0023_003Dz77g161c_003D[0]) ? 1 : 2)), _0023_003DzEzv5_0024vo_003D._0023_003DzdxBLSMNBs0J_0024);
	}

	private static int _0023_003DzpUmNFC0Ui6P_(int[] _0023_003DzIf_BcY7wetn_0024, int _0023_003Dz77g161c_003D, Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		for (int i = 0; i < _0023_003Dzd9ZyL64_003D.vertexCount; i++)
		{
			if (_0023_003DzIf_BcY7wetn_0024[i] == _0023_003Dz77g161c_003D)
			{
				return i;
			}
		}
		return -1;
	}

	private static int _0023_003DzYpEq4Mp_AI8n(int _0023_003DzgYn_0024Ldc_003D, int _0023_003Dzu1Fq9I8_003D, Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.edgeCount; i++)
		{
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].BeginVertex == _0023_003DzgYn_0024Ldc_003D && _0023_003Dzd9ZyL64_003D.edgeDatas[i].EndVertex == _0023_003Dzu1Fq9I8_003D)
			{
				return i;
			}
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].BeginVertex == _0023_003Dzu1Fq9I8_003D && _0023_003Dzd9ZyL64_003D.edgeDatas[i].EndVertex == _0023_003DzgYn_0024Ldc_003D)
			{
				return -i;
			}
		}
		return 0;
	}

	private static int _0023_003Dz5S_0024M0V_00246KHsl(int _0023_003DzrtkXSi0_003D, int _0023_003DzkDSiwZg_003D, List<_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl> _0023_003Dz6d_0024WMojXY76V, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl _0023_003Dz63vmKM0_003D)
	{
		int num = 0;
		int i;
		for (i = 0; i < _0023_003Dz6d_0024WMojXY76V.Count; i++)
		{
			num = 0;
			_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2 = _0023_003Dz6d_0024WMojXY76V[i];
			if ((_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DzdxBLSMNBs0J_0024 & 0x80) > 0 || (_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DzdxBLSMNBs0J_0024 & 0x80) < 0)
			{
				continue;
			}
			for (int j = 0; j < 3; j++)
			{
				if (_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[j] == _0023_003DzrtkXSi0_003D)
				{
					num |= 1;
				}
				if (_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003Dz77g161c_003D[j] == _0023_003DzkDSiwZg_003D)
				{
					num |= 2;
				}
			}
			if (num == 3)
			{
				_0023_003Dz63vmKM0_003D._0023_003Dz4COs0RWAfHca(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2);
				_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DzdxBLSMNBs0J_0024 |= 128;
				break;
			}
		}
		if (num == 3)
		{
			return i;
		}
		return -1;
	}

	private static int _0023_003DzonU2mZDfZFtx(int _0023_003DzdxBLSMNBs0J_0024, int _0023_003Dz437_00244ak_003D)
	{
		_0023_003DzdxBLSMNBs0J_0024 >>= _0023_003Dz437_00244ak_003D << 1;
		_0023_003DzdxBLSMNBs0J_0024 &= 3;
		return _0023_003DzdxBLSMNBs0J_0024 switch
		{
			1 => 1, 
			2 => 4, 
			3 => 8, 
			_ => 0, 
		};
	}

	private static void _0023_003Dzc_hPR3n_0024hSonkqoHSg_003D_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, double _0023_003Dz6pajdGM_003D)
	{
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.edgeCount; i++)
		{
			Solid.EdgeData edgeData = _0023_003Dzd9ZyL64_003D.edgeDatas[i];
			if (edgeData.Type <= 0 && edgeData.Type >= 0 && edgeData.NextFace != 0 && edgeData.PreviousFace != 0)
			{
				float num = 0f;
				if (edgeData.NextFace < 0)
				{
					num = _0023_003Dzd9ZyL64_003D.edgeDatas[-edgeData.NextFace].Angle;
				}
				if (edgeData.PreviousFace < 0)
				{
					num = _0023_003Dzd9ZyL64_003D.edgeDatas[-edgeData.PreviousFace].Angle;
				}
				if (num == 0f)
				{
					int previousFace = edgeData.PreviousFace;
					int nextFace = edgeData.NextFace;
					num = _0023_003DzSLyKdRKkR7Vx(_0023_003Dzd9ZyL64_003D, i, _0023_003Dzd9ZyL64_003D.planes[nextFace], _0023_003Dzd9ZyL64_003D.planes[previousFace]);
				}
				if (Math.Abs((double)num - Math.PI) < 1E-05)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].Type = 8;
				}
				else if ((double)num < Math.PI - _0023_003Dz6pajdGM_003D || (double)num > _0023_003Dz6pajdGM_003D + Math.PI)
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].Type = 1;
				}
				else
				{
					_0023_003Dzd9ZyL64_003D.edgeDatas[i].Type = 4;
				}
			}
		}
	}

	private static int _0023_003DzH9lKsakEaYr_(Solid.Portion _0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D)
	{
		_0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.contourCount++;
		_0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.faceCount++;
		_0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.faces[_0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.faceCount].FirstContour = _0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.contourCount;
		_0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.faces[_0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.faceCount].FaceLabel = 0;
		_0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.cycles[_0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.faceCount].NextContour = 0;
		_0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.cycles[_0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.faceCount].FirstEdge = 0;
		return _0023_003DzmZyA_0024jSktKl8Thm64g_003D_003D.faceCount;
	}

	private static int _0023_003DzOeWfWdo2I6CL(List<_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl> _0023_003Dz6d_0024WMojXY76V, _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl _0023_003Dz63vmKM0_003D)
	{
		int i;
		for (i = 0; i < _0023_003Dz6d_0024WMojXY76V.Count; i++)
		{
			_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl _0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2 = _0023_003Dz6d_0024WMojXY76V[i];
			if ((_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DzdxBLSMNBs0J_0024 & 0x80) <= 0 && (_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DzdxBLSMNBs0J_0024 & 0x80) >= 0)
			{
				_0023_003Dz63vmKM0_003D._0023_003Dz4COs0RWAfHca(_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2);
				_0023_003DzxCArsjO1cKXrhv6ho3QLApEgvewl2._0023_003DzdxBLSMNBs0J_0024 |= 128;
				break;
			}
		}
		return i;
	}

	public static bool _0023_003Dz1Z59Znx_0024wwab(Solid _0023_003Dz9TGtKzDrO7_0024b, NpStr _0023_003Dz_0024n2nrac_003D, double _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		bool result = true;
		_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[] _0023_003DzyzK8swU_003D;
		int _0023_003Dzfm85SNO6nZvJ;
		_0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[] _0023_003Dzp5xMQUk_003D;
		int count;
		Solid solid;
		Solid solid2;
		if (_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D == 1)
		{
			_0023_003DzyzK8swU_003D = _0023_003DzvuKzWCk_003D._0023_003Dz4aj0xv0_003D;
			_0023_003Dzfm85SNO6nZvJ = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count;
			_0023_003Dzp5xMQUk_003D = _0023_003DzvuKzWCk_003D._0023_003DzLM7JUrs_003D;
			count = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions.Count;
			solid = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D;
			solid2 = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D;
		}
		else
		{
			_0023_003DzyzK8swU_003D = _0023_003DzvuKzWCk_003D._0023_003DzLM7JUrs_003D;
			_0023_003Dzfm85SNO6nZvJ = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D.portions.Count;
			_0023_003Dzp5xMQUk_003D = _0023_003DzvuKzWCk_003D._0023_003Dz4aj0xv0_003D;
			count = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D.portions.Count;
			solid = _0023_003DzvuKzWCk_003D._0023_003Dz64auudc_003D;
			solid2 = _0023_003DzvuKzWCk_003D._0023_003DzKzgG76Y_003D;
		}
		if (_0023_003Dz9TGtKzDrO7_0024b.portions.Count < _0023_003Dz_0024n2nrac_003D.hnp - 1)
		{
			return false;
		}
		_0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D = _0023_003Dz9TGtKzDrO7_0024b.portions[_0023_003Dz_0024n2nrac_003D.hnp - 1];
		if (!_0023_003DzgQ6Mpwk6rfgy(_0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
		{
			return false;
		}
		int[] array = new int[_0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.edgeCount];
		NpStr _0023_003Dz_0024n2nrac_003D2 = new NpStr();
		_0023_003Dz_0024n2nrac_003D2._0023_003DzbByTzLTAlIM7(_0023_003Dz_0024n2nrac_003D);
		Solid.Portion portion = (Solid.Portion)_0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D.Clone();
		while (_0023_003Dz1XOZELaODJu7(portion) != portion.faceCount)
		{
			Solid.Portion portion2 = (Solid.Portion)portion.Clone();
			if (!_0023_003Dz_0024EHl48jNZuTb(portion))
			{
				result = false;
				break;
			}
			_0023_003DzRi71tdrYZ3fn(portion, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, _0023_003DzHC7AYP4_003D);
			if (!_0023_003DztDdwD3iU3oOP(portion))
			{
				result = false;
				break;
			}
			_0023_003Dz_8JqadwXrdJr(portion);
			_0023_003DzBM2lV10uPp25(portion);
			_0023_003Dz9TGtKzDrO7_0024b.portions[_0023_003Dz_0024n2nrac_003D2.hnp - 1]._0023_003DzDBrp9S8_003D(portion);
			_0023_003DzvuKzWCk_003D._0023_003DziL7i_d1iNnMuUoZ_CQ_003D_003D = portion;
			for (int i = 1; i <= portion2.faceCount; i++)
			{
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = _0023_003DzQLKKCNRzQuXx(portion2.faces[i].FaceLabel);
				if (_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D == 1)
				{
					_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D = 0;
				}
				else
				{
					_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D = 1;
				}
				portion2.faces[i].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
			}
			if (!_0023_003Dz_0024EHl48jNZuTb(portion2))
			{
				result = false;
				break;
			}
			_0023_003DzRi71tdrYZ3fn(portion2, _0023_003DznDeo9kRSCPBn8AZYIA_003D_003D, _0023_003DzHC7AYP4_003D);
			if (!_0023_003DztDdwD3iU3oOP(portion2))
			{
				result = false;
				break;
			}
			_0023_003Dz_8JqadwXrdJr(portion2);
			_0023_003DzBM2lV10uPp25(portion2);
			int id = portion2.Id;
			portion2.Id = _0023_003DzvuKzWCk_003D._0023_003DztptblV0_003D++;
			if (!_0023_003Dzn0El2fnkylrN(ref _0023_003DzyzK8swU_003D, ref _0023_003Dzfm85SNO6nZvJ, solid, portion2, ref _0023_003Dz_0024n2nrac_003D2))
			{
				result = false;
				break;
			}
			if (_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D == 1)
			{
				_0023_003DzvuKzWCk_003D._0023_003Dz4aj0xv0_003D = _0023_003DzyzK8swU_003D;
			}
			else
			{
				_0023_003DzvuKzWCk_003D._0023_003DzLM7JUrs_003D = _0023_003DzyzK8swU_003D;
			}
			int num = 0;
			for (int j = 1; j <= portion2.edgeCount; j++)
			{
				if (portion2.edgeDatas[j].NextFace >= 0 && portion2.edgeDatas[j].PreviousFace >= 0)
				{
					continue;
				}
				int num2 = ((portion2.edgeDatas[j].NextFace >= 0) ? portion2.edgeDatas[j].PreviousEdge : portion2.edgeDatas[j].NextEdge);
				int k;
				for (k = 0; k < num && array[k] != num2; k++)
				{
				}
				if (k < num)
				{
					continue;
				}
				array[num] = num2;
				num++;
				Solid solid3 = solid;
				int num3 = _0023_003Dz23oII3NiRA_s(_0023_003DzyzK8swU_003D, _0023_003Dzfm85SNO6nZvJ, num2);
				if (num3 == 0)
				{
					solid3 = solid2;
					if ((num3 = _0023_003Dz23oII3NiRA_s(_0023_003Dzp5xMQUk_003D, count, num2)) == 0)
					{
						goto IL_0347;
					}
				}
				_0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D = solid3.portions[num3 - 1];
				Solid.Portion _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D = _0023_003DzvuKzWCk_003D._0023_003DzoK6mMlGww0q7y37Rlw_003D_003D;
				for (int l = 1; l <= _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeCount; l++)
				{
					if (_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[l].NextEdge != id && _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[l].PreviousEdge != id)
					{
						continue;
					}
					for (int m = j; m <= portion2.edgeCount; m++)
					{
						if (portion2.edgeDatas[m].NextEdge != _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.Id && portion2.edgeDatas[m].PreviousEdge != _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.Id)
						{
							continue;
						}
						int beginVertex = portion2.edgeDatas[m].BeginVertex;
						int endVertex = portion2.edgeDatas[m].EndVertex;
						int beginVertex2 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[l].BeginVertex;
						int endVertex2 = _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[l].EndVertex;
						if ((_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion2._vertices[beginVertex], _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D._vertices[beginVertex2], _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn) || _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion2._vertices[beginVertex], _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D._vertices[endVertex2], _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn)) && (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion2._vertices[endVertex], _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D._vertices[beginVertex2], _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn) || _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(portion2._vertices[endVertex], _0023_003DzoK6mMlGww0q7y37Rlw_003D_003D._vertices[endVertex2], _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn)))
						{
							if (_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[l].NextEdge == id)
							{
								_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[l].NextEdge = portion2.Id;
								break;
							}
							if (_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[l].PreviousEdge == id)
							{
								_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D.edgeDatas[l].PreviousEdge = portion2.Id;
								break;
							}
						}
					}
				}
				solid3.portions[num3 - 1]._0023_003DzDBrp9S8_003D(_0023_003DzoK6mMlGww0q7y37Rlw_003D_003D);
			}
			_0023_003Dz9TGtKzDrO7_0024b.portions[_0023_003Dz_0024n2nrac_003D2.hnp - 1]._0023_003DzDBrp9S8_003D(portion2);
			portion._0023_003DzDBrp9S8_003D(portion2);
			continue;
			IL_0347:
			result = false;
			break;
		}
		if (_0023_003DzvuKzWCk_003D._0023_003DziEIjfZA_003D == 1)
		{
			_0023_003DzvuKzWCk_003D._0023_003Dz4aj0xv0_003D = _0023_003DzyzK8swU_003D;
		}
		else
		{
			_0023_003DzvuKzWCk_003D._0023_003DzLM7JUrs_003D = _0023_003DzyzK8swU_003D;
		}
		return result;
	}

	private static bool _0023_003Dzn0El2fnkylrN(ref _0023_003DzDw67G9vnP5Xk6_Ub3wgXJCYuRDAc[] _0023_003DzyzK8swU_003D, ref int _0023_003Dzfm85SNO6nZvJ, Solid _0023_003Dz9TGtKzDrO7_0024b, Solid.Portion _0023_003Dzd9ZyL64_003D, ref NpStr _0023_003Dz_0024n2nrac_003D)
	{
		_0023_003Dzd9ZyL64_003D.UpdateBoundingBox(null);
		_0023_003Dz_0024n2nrac_003D = new NpStr();
		_0023_003Dz_0024n2nrac_003D.ident = _0023_003Dzd9ZyL64_003D.Id;
		_0023_003Dz_0024n2nrac_003D.lab = 1;
		_0023_003Dz9TGtKzDrO7_0024b.portions.Add(_0023_003Dzd9ZyL64_003D);
		_0023_003Dz_0024n2nrac_003D.hnp = _0023_003Dz9TGtKzDrO7_0024b.portions.Count;
		_0023_003Dz9TGtKzDrO7_0024b.NpStrList.Add(_0023_003Dz_0024n2nrac_003D);
		_0023_003Dz9TGtKzDrO7_0024b.NpStrDict.Add(_0023_003Dz_0024n2nrac_003D.ident, _0023_003Dz_0024n2nrac_003D);
		int num = _0023_003Dz9TGtKzDrO7_0024b.portions.Count - 1;
		if (_0023_003Dzfm85SNO6nZvJ == num)
		{
			Array.Resize(ref _0023_003DzyzK8swU_003D, num + 10);
			for (int i = _0023_003Dzfm85SNO6nZvJ; i < _0023_003Dzfm85SNO6nZvJ + 10; i++)
			{
				_0023_003DzyzK8swU_003D[i]._0023_003DzSkUy_T8_003D = 32767;
			}
			_0023_003Dzfm85SNO6nZvJ += 10;
		}
		_0023_003DzyzK8swU_003D[num]._0023_003DzSkUy_T8_003D = _0023_003Dzd9ZyL64_003D.Id;
		_0023_003DzyzK8swU_003D[num]._0023_003DzSfQie2M_003D = _0023_003Dz9TGtKzDrO7_0024b.portions.Count;
		return true;
	}

	private static int _0023_003Dz1XOZELaODJu7(Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D4 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		int _0023_003DzS6uYNj8_003D;
		int _0023_003DzgD0ie9M_003D;
		int _0023_003Dz_IEg3Es_003D;
		int num = (_0023_003DzS6uYNj8_003D = (_0023_003DzgD0ie9M_003D = (_0023_003Dz_IEg3Es_003D = 0)));
		int[] _0023_003Dz17c8Zmw_003D = new int[_0023_003Dzd9ZyL64_003D.vertexCount];
		int[] _0023_003Dz6NpAPOI_003D = new int[_0023_003Dzd9ZyL64_003D.contourCount + 1];
		Array.Clear(_0023_003Dzd9ZyL64_003D.user, 0, _0023_003Dzd9ZyL64_003D.user.Length);
		int num2 = 1;
		while (true)
		{
			_0023_003DzQMDBZgRhAZlGLLp1M_0024TykJA_003D(_0023_003Dzd9ZyL64_003D, _0023_003Dz6NpAPOI_003D, _0023_003Dz17c8Zmw_003D, num2, ref _0023_003Dz_IEg3Es_003D, ref _0023_003DzS6uYNj8_003D, ref _0023_003DzgD0ie9M_003D);
			int num5;
			if (_0023_003DzgD0ie9M_003D <= 250 && _0023_003DzS6uYNj8_003D <= 400 && _0023_003Dz_IEg3Es_003D <= 222 && num < 202)
			{
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[num2].FaceLabel);
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3._0023_003DzfUgV2P8_003D = 1;
				_0023_003Dzd9ZyL64_003D.faces[num2].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3);
				num++;
				if (num != 202)
				{
					for (num2 = 1; num2 <= _0023_003Dzd9ZyL64_003D.faceCount; num2++)
					{
						if (_0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[num2].FaceLabel)._0023_003DzfUgV2P8_003D == 0)
						{
							continue;
						}
						int num3 = _0023_003Dzd9ZyL64_003D.faces[num2].FirstContour;
						while (true)
						{
							int firstEdge;
							int num4 = (firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num3].FirstEdge);
							while (true)
							{
								num5 = ((num4 >= 0) ? _0023_003Dzd9ZyL64_003D.edgeDatas[num4].PreviousFace : _0023_003Dzd9ZyL64_003D.edgeDatas[-num4].NextFace);
								if (num5 > 0 && _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[num5].FaceLabel)._0023_003DzfUgV2P8_003D == 0)
								{
									break;
								}
								num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num4, _0023_003Dzd9ZyL64_003D);
								if (num4 != firstEdge)
								{
									continue;
								}
								goto IL_0193;
							}
							break;
							IL_0193:
							num3 = _0023_003Dzd9ZyL64_003D.cycles[num3].NextContour;
							if (num3 > 0)
							{
								continue;
							}
							goto IL_01af;
						}
						goto IL_017e;
						IL_01af:;
					}
					break;
				}
			}
			for (int num4 = 1; num4 <= _0023_003Dzd9ZyL64_003D.edgeCount; num4++)
			{
				int nextFace = _0023_003Dzd9ZyL64_003D.edgeDatas[num4].NextFace;
				int previousFace = _0023_003Dzd9ZyL64_003D.edgeDatas[num4].PreviousFace;
				if (nextFace <= 0 || previousFace <= 0)
				{
					continue;
				}
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[nextFace].FaceLabel);
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D4 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[previousFace].FaceLabel);
				if (_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3._0023_003DzfUgV2P8_003D != _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D4._0023_003DzfUgV2P8_003D)
				{
					float bnd;
					if ((bnd = _0023_003Dz1zs3WXHrvefg(_0023_003Dzd9ZyL64_003D, num4, _0023_003Dzd9ZyL64_003D.planes[nextFace], _0023_003Dzd9ZyL64_003D.planes[previousFace])) == 0f)
					{
						num = 0;
						break;
					}
					_0023_003Dzd9ZyL64_003D.user[num4].bnd = bnd;
					_0023_003Dzd9ZyL64_003D.user[num4].ind = _0023_003Dzd9ZyL64_003D.Id;
				}
			}
			break;
			IL_017e:
			num2 = num5;
		}
		for (int num4 = 1; num4 <= _0023_003Dzd9ZyL64_003D.edgeCount; num4++)
		{
			_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.edgeDatas[num4].Type);
			_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003Dzy3xqLbo_003D = 0;
			_0023_003Dzd9ZyL64_003D.edgeDatas[num4].Type = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
		}
		return num;
	}

	private static void _0023_003DzQMDBZgRhAZlGLLp1M_0024TykJA_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, int[] _0023_003Dz6NpAPOI_003D, int[] _0023_003Dz17c8Zmw_003D, int _0023_003DzHEpjcdg2hk9U, ref int _0023_003Dz_IEg3Es_003D, ref int _0023_003DzS6uYNj8_003D, ref int _0023_003DzgD0ie9M_003D)
	{
		int num = _0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour;
		_0023_003Dz6NpAPOI_003D[num] = 1;
		_0023_003Dz_IEg3Es_003D++;
		do
		{
			if (_0023_003Dz6NpAPOI_003D[num] == 0)
			{
				_0023_003Dz6NpAPOI_003D[num] = 1;
				_0023_003Dz_IEg3Es_003D++;
			}
			int firstEdge;
			int num2 = (firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num].FirstEdge);
			int num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(num2, _0023_003Dzd9ZyL64_003D);
			do
			{
				if (_0023_003Dz17c8Zmw_003D[num3] == 0)
				{
					_0023_003Dz17c8Zmw_003D[num3] = 1;
					_0023_003DzgD0ie9M_003D++;
				}
				int num4 = Math.Abs(num2);
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003Dz1v6oPQk_003D = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.edgeDatas[num4].Type);
				if (_0023_003Dz1v6oPQk_003D._0023_003Dzy3xqLbo_003D == 0)
				{
					_0023_003Dz1v6oPQk_003D._0023_003Dzy3xqLbo_003D = 1;
					_0023_003Dzd9ZyL64_003D.edgeDatas[num4].Type = _0023_003DzFKBkm1YBo_5J(_0023_003Dz1v6oPQk_003D);
					_0023_003DzS6uYNj8_003D++;
				}
				num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num2, _0023_003Dzd9ZyL64_003D);
				num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(num2, _0023_003Dzd9ZyL64_003D);
			}
			while (num2 != firstEdge);
			num = _0023_003Dzd9ZyL64_003D.cycles[num].NextContour;
		}
		while (num > 0);
	}

	private static bool _0023_003DzgQ6Mpwk6rfgy(Solid.Portion _0023_003Dzd9ZyL64_003D, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D _0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = default(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D);
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		int[] array = new int[_0023_003Dzd9ZyL64_003D.MaxNov];
		int[] array2 = new int[_0023_003Dzd9ZyL64_003D.MaxNoc + 1];
		int _0023_003DzgD0ie9M_003D;
		int _0023_003Dz_IEg3Es_003D;
		int _0023_003DzS6uYNj8_003D = (_0023_003DzgD0ie9M_003D = (_0023_003Dz_IEg3Es_003D = 0));
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
		{
			_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel);
			_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D = 0;
			_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
			_0023_003DzQMDBZgRhAZlGLLp1M_0024TykJA_003D(_0023_003Dzd9ZyL64_003D, array2, array, i, ref _0023_003Dz_IEg3Es_003D, ref _0023_003DzS6uYNj8_003D, ref _0023_003DzgD0ie9M_003D);
			if (_0023_003DzgD0ie9M_003D >= 250 || _0023_003DzS6uYNj8_003D > 400 || _0023_003Dz_IEg3Es_003D >= 222)
			{
				if (!_0023_003DzOFnzDkyXYQUJ(_0023_003Dzd9ZyL64_003D, i, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
				{
					for (int j = 1; j <= _0023_003Dzd9ZyL64_003D.edgeCount; j++)
					{
						_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(_0023_003Dzd9ZyL64_003D.edgeDatas[j].Type);
						_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 0;
						_0023_003Dzd9ZyL64_003D.edgeDatas[j].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
					}
					return false;
				}
				i--;
				if (array.Length < _0023_003Dzd9ZyL64_003D.MaxNov)
				{
					array = new int[_0023_003Dzd9ZyL64_003D.MaxNov];
				}
				if (array2.Length < _0023_003Dzd9ZyL64_003D.MaxNoc + 1)
				{
					array2 = new int[_0023_003Dzd9ZyL64_003D.MaxNoc + 1];
				}
			}
			_0023_003DzS6uYNj8_003D = (_0023_003DzgD0ie9M_003D = (_0023_003Dz_IEg3Es_003D = 0));
			Array.Clear(array, 0, array.Length);
			Array.Clear(array2, 0, array2.Length);
		}
		for (int j = 1; j <= _0023_003Dzd9ZyL64_003D.edgeCount; j++)
		{
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2 = _0023_003Dzqy1hGquKIlvn(_0023_003Dzd9ZyL64_003D.edgeDatas[j].Type);
			_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2._0023_003Dzy3xqLbo_003D = 0;
			_0023_003Dzd9ZyL64_003D.edgeDatas[j].Type = _0023_003DzgSdDROLMnqqq(_0023_003DzNs_0024cTGVF1fYJcZM7NgOQW4kk6unsg_0024D6uApn_xo_003D2);
		}
		return true;
	}

	public static bool _0023_003DzOFnzDkyXYQUJ(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzqQtwmz8_003D = new List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D>();
		PlaneEquation _0023_003Dzi4cdUYM_003D = new PlaneEquation();
		_0023_003Dzl_Z5_T5fwvAsVVQbuA_003D_003D(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, _0023_003Dzi4cdUYM_003D);
		if (!_0023_003Dz_50OHyxVtllZD6YWSw_003D_003D(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, _0023_003Dzi4cdUYM_003D, _0023_003DzqQtwmz8_003D, _0023_003DzvuKzWCk_003D, _0023_003DzHC7AYP4_003D))
		{
			return false;
		}
		if (!_0023_003DzZW82RqUIRF_0024t(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U))
		{
			return false;
		}
		return true;
	}

	private static bool _0023_003DzZW82RqUIRF_0024t(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U)
	{
		bool _0023_003DzUxaV_00244M_003D = false;
		_0023_003DznTyE_0024ftDrz_0024SP3mSVbTii3X_coKK[] array = _0023_003Dz0WPnITtCpPBSzKcmKg_003D_003D(null, 0);
		if (array == null)
		{
			return false;
		}
		int faceCount = _0023_003Dzd9ZyL64_003D.faceCount;
		if (!_0023_003DzsdM1YTTecHHx(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, array, _0023_003DzUxaV_00244M_003D))
		{
			return false;
		}
		if (_0023_003Dzd9ZyL64_003D.faceCount > faceCount)
		{
			_0023_003Dzhcy7qUH748_00246(_0023_003Dzd9ZyL64_003D, faceCount);
		}
		return true;
	}

	private static bool _0023_003Dz_50OHyxVtllZD6YWSw_003D_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U, PlaneEquation _0023_003Dzi4cdUYM_003D, List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzqQtwmz8_003D, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		_0023_003DzqQtwmz8_003D.Clear();
		_0023_003Dzd9ZyL64_003D.novTemp = _0023_003Dzd9ZyL64_003D.MaxNov;
		if (!_0023_003DzvbTb47elbjLr(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, _0023_003DzqQtwmz8_003D, _0023_003Dzi4cdUYM_003D, _0023_003DzHC7AYP4_003D))
		{
			return false;
		}
		if (_0023_003DzqQtwmz8_003D.Count == 0)
		{
			return true;
		}
		int _0023_003DzvQElbssTl3_h = _0023_003Dz_0024LYVLiAhnEq9(_0023_003Dzd9ZyL64_003D.planes[_0023_003DzHEpjcdg2hk9U], _0023_003Dzi4cdUYM_003D);
		_0023_003DzCgqNlbtmU44p(_0023_003Dzd9ZyL64_003D._vertices, _0023_003DzqQtwmz8_003D, _0023_003DzvQElbssTl3_h);
		if (!_0023_003Dzu4eOJLs_003D(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, _0023_003DzqQtwmz8_003D, _0023_003DzvuKzWCk_003D))
		{
			return false;
		}
		return true;
	}

	public static bool _0023_003Dzu4eOJLs_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U, List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl, Solid._0023_003DzGl0iL3E_003D _0023_003DzvuKzWCk_003D)
	{
		int _0023_003DzB68dg9Q_003D = -1;
		int _0023_003DzCaPJP54_003D = -1;
		int _0023_003DzMlCq3wk_003D = -1;
		int num = 0;
		int _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D = 0;
		int _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D2 = 0;
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		bool _0023_003Dz44_0024ru0s_003D = false;
		Point3D[] array = new Point3D[_0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl.Count];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl[i]._0023_003Dz77g161c_003D];
		}
		int vertexCount = _0023_003Dzd9ZyL64_003D.vertexCount;
		while (num < _0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl.Count)
		{
			_0023_003Dz611qY1n3rRLa(_0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl[num]._0023_003DzkKfJheA_003D, ref _0023_003DzB68dg9Q_003D, ref _0023_003DzCaPJP54_003D, ref _0023_003DzMlCq3wk_003D, ref _0023_003Dz44_0024ru0s_003D);
			num++;
			if (_0023_003DzB68dg9Q_003D != 1)
			{
				continue;
			}
			int num2;
			if (_0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl[num - 1]._0023_003Dz77g161c_003D >= vertexCount)
			{
				point3D = array[num - 1];
				if ((num2 = _0023_003Dzmdel3ZTIgMDe(ref _0023_003Dzd9ZyL64_003D, point3D, _0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn)) == -1)
				{
					return false;
				}
			}
			else
			{
				num2 = _0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl[num - 1]._0023_003Dz77g161c_003D;
			}
			int num3;
			if (_0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl[num - 1]._0023_003DzkKfJheA_003D == 1 && (num3 = _0023_003DzqXOuYc9ThphL(_0023_003Dzd9ZyL64_003D, _0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl[num - 1]._0023_003DzRpXgovo_003D, num2, _0023_003DzvuKzWCk_003D)) == 0)
			{
				return false;
			}
			int num4;
			if (_0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl[num]._0023_003Dz77g161c_003D >= vertexCount)
			{
				point3D2 = array[num];
				if ((num4 = _0023_003Dzmdel3ZTIgMDe(ref _0023_003Dzd9ZyL64_003D, point3D2, _0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn)) == -1)
				{
					return false;
				}
			}
			else
			{
				num4 = _0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl[num]._0023_003Dz77g161c_003D;
			}
			if (_0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl[num]._0023_003DzkKfJheA_003D == 1 && (num3 = _0023_003DzqXOuYc9ThphL(_0023_003Dzd9ZyL64_003D, _0023_003DzYlpHAvmUyD0mvGwo2Cdv7gQVtBMl[num]._0023_003DzRpXgovo_003D, num4, _0023_003DzvuKzWCk_003D)) == 0)
			{
				return false;
			}
			if ((num3 = _0023_003Dz2bKtHInA2tx2(_0023_003Dzd9ZyL64_003D, num2, num4, _0023_003DzvuKzWCk_003D._0023_003DzjTwYx_xFB7Cw)) == 0)
			{
				return false;
			}
			if (num3 >= 0)
			{
				_0023_003Dzd9ZyL64_003D.edgeDatas[num3].NextFace = (_0023_003Dzd9ZyL64_003D.edgeDatas[num3].PreviousFace = _0023_003DzHEpjcdg2hk9U);
				int num5 = _0023_003DzRt7BPC1zB38_0024(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, num3, ref _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D, _0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn);
				int num6 = _0023_003DzRt7BPC1zB38_0024(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, -num3, ref _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D2, _0023_003DzvuKzWCk_003D._0023_003DzkRSfKls1SLfn);
				_0023_003Dzw_0024hK_0024hYFvRbk(_0023_003Dzd9ZyL64_003D, num3, _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D);
				_0023_003Dzw_0024hK_0024hYFvRbk(_0023_003Dzd9ZyL64_003D, -num3, _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D2);
				if (num5 != 0 && num6 != 0 && !_0023_003DzwYVAK8UGMSQE(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, num5, num6, num3))
				{
					return false;
				}
			}
		}
		return true;
	}

	private static void _0023_003Dzl_Z5_T5fwvAsVVQbuA_003D_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U, PlaneEquation _0023_003Dzi4cdUYM_003D)
	{
		Region3D region3D = new Region3D(Point3D.MaxValue, Point3D.MinValue);
		_0023_003Dzi4cdUYM_003D.X = (_0023_003Dzi4cdUYM_003D.Y = (_0023_003Dzi4cdUYM_003D.Z = 0.0));
		int num = _0023_003Dzd9ZyL64_003D.faces[_0023_003DzHEpjcdg2hk9U].FirstContour;
		do
		{
			int firstEdge = _0023_003Dzd9ZyL64_003D.cycles[num].FirstEdge;
			int num2 = firstEdge;
			do
			{
				int num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(num2, _0023_003Dzd9ZyL64_003D);
				if (region3D.min.X > _0023_003Dzd9ZyL64_003D._vertices[num3].X)
				{
					region3D.min.X = _0023_003Dzd9ZyL64_003D._vertices[num3].X;
				}
				if (region3D.min.Y > _0023_003Dzd9ZyL64_003D._vertices[num3].Y)
				{
					region3D.min.Y = _0023_003Dzd9ZyL64_003D._vertices[num3].Y;
				}
				if (region3D.min.Z > _0023_003Dzd9ZyL64_003D._vertices[num3].Z)
				{
					region3D.min.Z = _0023_003Dzd9ZyL64_003D._vertices[num3].Z;
				}
				if (region3D.max.X < _0023_003Dzd9ZyL64_003D._vertices[num3].X)
				{
					region3D.max.X = _0023_003Dzd9ZyL64_003D._vertices[num3].X;
				}
				if (region3D.max.Y < _0023_003Dzd9ZyL64_003D._vertices[num3].Y)
				{
					region3D.max.Y = _0023_003Dzd9ZyL64_003D._vertices[num3].Y;
				}
				if (region3D.max.Z < _0023_003Dzd9ZyL64_003D._vertices[num3].Z)
				{
					region3D.max.Z = _0023_003Dzd9ZyL64_003D._vertices[num3].Z;
				}
				num2 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num2, _0023_003Dzd9ZyL64_003D);
			}
			while (num2 != firstEdge);
			num = _0023_003Dzd9ZyL64_003D.cycles[num].NextContour;
		}
		while (num != 0);
		double num4 = Math.Abs(region3D.max.X - region3D.min.X);
		double num5 = Math.Abs(region3D.max.Y - region3D.min.Y);
		double num6 = Math.Abs(region3D.max.Z - region3D.min.Z);
		if (num4 > num5)
		{
			if (num4 > num6)
			{
				_0023_003Dzi4cdUYM_003D.X = 1.0;
				_0023_003Dzi4cdUYM_003D.D = 0.0 - (region3D.min.X + num4 / 2.0);
			}
			else
			{
				_0023_003Dzi4cdUYM_003D.Z = 1.0;
				_0023_003Dzi4cdUYM_003D.D = 0.0 - (region3D.min.Z + num6 / 2.0);
			}
		}
		else if (num5 > num6)
		{
			_0023_003Dzi4cdUYM_003D.Y = 1.0;
			_0023_003Dzi4cdUYM_003D.D = 0.0 - (region3D.min.Y + num5 / 2.0);
		}
		else
		{
			_0023_003Dzi4cdUYM_003D.Z = 1.0;
			_0023_003Dzi4cdUYM_003D.D = 0.0 - (region3D.min.Z + num6 / 2.0);
		}
	}

	public static bool _0023_003DzyhwfZUNTBTiB(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzMJ9Rv10_003D)
	{
		int num = _0023_003Dzd9ZyL64_003D.vertexCount + _0023_003DzMJ9Rv10_003D - _0023_003Dzd9ZyL64_003D.MaxNov;
		int num2 = 0;
		if (_0023_003Dzd9ZyL64_003D.edgeCount + _0023_003DzMJ9Rv10_003D > _0023_003Dzd9ZyL64_003D.MaxNoe)
		{
			num2 = _0023_003Dzd9ZyL64_003D.edgeCount + _0023_003DzMJ9Rv10_003D - _0023_003Dzd9ZyL64_003D.MaxNoe;
		}
		int num3 = 0;
		if (_0023_003Dzd9ZyL64_003D.contourCount + _0023_003DzMJ9Rv10_003D > _0023_003Dzd9ZyL64_003D.MaxNoc)
		{
			num3 = _0023_003DzMJ9Rv10_003D;
		}
		_0023_003Dzd9ZyL64_003D.novTemp = _0023_003Dzd9ZyL64_003D.MaxNov;
		if (!_0023_003DzpJYyFPVkVs7b(_0023_003Dzd9ZyL64_003D, _0023_003Dzd9ZyL64_003D.MaxNov + num, _0023_003Dzd9ZyL64_003D.MaxNoe + num2, _0023_003Dzd9ZyL64_003D.MaxNof, _0023_003Dzd9ZyL64_003D.MaxNoc + num3, num))
		{
			return false;
		}
		return true;
	}

	public static void _0023_003Dzm0RN0lGJV9LwEZnPqA_003D_003D(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003Dz06A5WivSSyUp, int _0023_003Dzz0uHmgQx0Kwi)
	{
		int num2;
		int num = (num2 = _0023_003Dzd9ZyL64_003D.edgeCount);
		int num3 = _0023_003Dzz0uHmgQx0Kwi;
		for (int i = 0; i < _0023_003Dz06A5WivSSyUp - 2; i++)
		{
			num3 = (_0023_003Dzd9ZyL64_003D.edgeDatas[++num2].BeginVertex = num3 + 1);
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].EndVertex = num3 + 1;
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].Type = 1;
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].NextEdge = num2 + 1;
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].NextFace = 1;
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].PreviousEdge = 0;
			_0023_003Dzd9ZyL64_003D.edgeDatas[num2].PreviousFace = 0;
		}
		num3 = (_0023_003Dzd9ZyL64_003D.edgeDatas[++num2].BeginVertex = num3 + 1);
		_0023_003Dzd9ZyL64_003D.edgeDatas[num2].EndVertex = _0023_003Dzz0uHmgQx0Kwi + 1;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num2].Type = 1;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num2].NextEdge = num + 1;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num2].NextFace = 1;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num2].PreviousEdge = 0;
		_0023_003Dzd9ZyL64_003D.edgeDatas[num2].PreviousFace = 0;
		_0023_003Dzd9ZyL64_003D.edgeCount = num2;
		if (_0023_003Dzd9ZyL64_003D.faceCount == 0)
		{
			_0023_003Dzd9ZyL64_003D.faces[1].FirstContour = 1;
			if (_0023_003Dzd9ZyL64_003D.planes[1] == null)
			{
				_0023_003Dzd9ZyL64_003D.planes[1] = new PlaneEquation();
			}
		}
		else
		{
			_0023_003Dzd9ZyL64_003D.cycles[_0023_003Dzd9ZyL64_003D.contourCount].NextContour = _0023_003Dzd9ZyL64_003D.contourCount + 1;
		}
		_0023_003Dzd9ZyL64_003D.contourCount++;
		_0023_003Dzd9ZyL64_003D.cycles[_0023_003Dzd9ZyL64_003D.contourCount].FirstEdge = num + 1;
		_0023_003Dzd9ZyL64_003D.cycles[_0023_003Dzd9ZyL64_003D.contourCount].NextContour = 0;
		_0023_003Dzd9ZyL64_003D.faceCount = 1;
	}

	public static bool _0023_003DzPzYRF_0024bpnBG9(Solid _0023_003DzcDEsV8s_003D, Solid.Portion _0023_003Dzd9ZyL64_003D, NpStr _0023_003Dz_0024n2nrac_003D)
	{
		NpStr npStr = new NpStr();
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.edgeCount; i++)
		{
			if (_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace >= 0 && _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousFace >= 0)
			{
				continue;
			}
			int _0023_003DzSkUy_T8_003D = ((_0023_003Dzd9ZyL64_003D.edgeDatas[i].NextFace >= 0) ? _0023_003Dzd9ZyL64_003D.edgeDatas[i].PreviousEdge : _0023_003Dzd9ZyL64_003D.edgeDatas[i].NextEdge);
			if (!_0023_003DzqZtmF1Q1XoHn(_0023_003DzcDEsV8s_003D, _0023_003DzSkUy_T8_003D, npStr, out var _))
			{
				return false;
			}
			if (npStr.ort != 0)
			{
				if (npStr.ort == -1)
				{
					_0023_003Dz_0024n2nrac_003D.ort = -1;
					_0023_003DzG037o6MQFwqV(_0023_003Dzd9ZyL64_003D, (Solid._0023_003Dz1IcEX2Y45sL1)1, _0023_003DzPrQP54igoJQK: true);
				}
				else
				{
					_0023_003Dz_0024n2nrac_003D.ort = 1;
				}
				return true;
			}
		}
		return true;
	}

	public static bool _0023_003DzZcRa5LcVgWN8(Solid.Portion _0023_003Dzd9ZyL64_003D, List<List<Point3D>> _0023_003Dzoq64prs_003D, bool _0023_003DzjMikPdqXh_0024DX, _0023_003DzKMQ5VoB_N20ALErmFTKtSGPpH4t_5FPe0Q_003D_003D _0023_003DzHC7AYP4_003D)
	{
		List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> list = new List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D>();
		PlaneEquation planeEquation = new PlaneEquation();
		int num = 1;
		do
		{
			_0023_003Dzl_Z5_T5fwvAsVVQbuA_003D_003D(_0023_003Dzd9ZyL64_003D, num, planeEquation);
			list.Clear();
			_0023_003Dzd9ZyL64_003D.novTemp = _0023_003Dzd9ZyL64_003D.MaxNov;
			if (!_0023_003DzvbTb47elbjLr(_0023_003Dzd9ZyL64_003D, num, list, planeEquation, _0023_003DzHC7AYP4_003D))
			{
				return false;
			}
			if (list.Count == 0)
			{
				return true;
			}
			int _0023_003DzvQElbssTl3_h = _0023_003Dz_0024LYVLiAhnEq9(_0023_003Dzd9ZyL64_003D.planes[num], planeEquation);
			_0023_003DzCgqNlbtmU44p(_0023_003Dzd9ZyL64_003D._vertices, list, _0023_003DzvQElbssTl3_h);
			if (!_0023_003Dzb_FdwPWerCDP(_0023_003Dzd9ZyL64_003D, num, list, _0023_003Dzoq64prs_003D, _0023_003DzjMikPdqXh_0024DX, _0023_003DzHC7AYP4_003D._0023_003DzkRSfKls1SLfn))
			{
				return false;
			}
			if (!_0023_003DzZW82RqUIRF_0024t(_0023_003Dzd9ZyL64_003D, num))
			{
				return false;
			}
		}
		while ((num = _0023_003DzgJCUQYA_003D(_0023_003Dzd9ZyL64_003D)) != 0);
		return true;
	}

	private static int _0023_003DzgJCUQYA_003D(Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
		{
			int num = _0023_003Dzd9ZyL64_003D.faces[i].FirstContour;
			int num2 = 0;
			do
			{
				int num3 = _0023_003Dzd9ZyL64_003D.cycles[num].FirstEdge;
				int num4 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(num3, _0023_003Dzd9ZyL64_003D);
				do
				{
					num2++;
					num3 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num3, _0023_003Dzd9ZyL64_003D);
				}
				while (num4 != _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(num3, _0023_003Dzd9ZyL64_003D));
				num2++;
				num = _0023_003Dzd9ZyL64_003D.cycles[num].NextContour;
			}
			while (num != 0);
			if (num2 > 250 || num2 > 400)
			{
				return i;
			}
		}
		return 0;
	}

	private static bool _0023_003Dzb_FdwPWerCDP(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzHEpjcdg2hk9U, List<_0023_003Dz0SAPHeu8yLK4CgKo0VjqCwMzaWSA452VZ7sAQ7g_003D> _0023_003DzqQtwmz8_003D, List<List<Point3D>> _0023_003Dzoq64prs_003D, bool _0023_003DzjMikPdqXh_0024DX, double _0023_003DzkRSfKls1SLfn)
	{
		int _0023_003DzB68dg9Q_003D = -1;
		int _0023_003DzCaPJP54_003D = -1;
		int _0023_003DzMlCq3wk_003D = -1;
		int num = 0;
		int _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D = 0;
		int _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D2 = 0;
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		bool _0023_003Dz44_0024ru0s_003D = false;
		while (num < _0023_003DzqQtwmz8_003D.Count)
		{
			_0023_003Dz611qY1n3rRLa(_0023_003DzqQtwmz8_003D[num]._0023_003DzkKfJheA_003D, ref _0023_003DzB68dg9Q_003D, ref _0023_003DzCaPJP54_003D, ref _0023_003DzMlCq3wk_003D, ref _0023_003Dz44_0024ru0s_003D);
			num++;
			if (_0023_003DzB68dg9Q_003D != 1)
			{
				continue;
			}
			int num2;
			if (_0023_003DzqQtwmz8_003D[num - 1]._0023_003Dz77g161c_003D >= _0023_003Dzd9ZyL64_003D.vertexCount)
			{
				point3D = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzqQtwmz8_003D[num - 1]._0023_003Dz77g161c_003D];
				if ((num2 = _0023_003Dzmdel3ZTIgMDe(ref _0023_003Dzd9ZyL64_003D, point3D, _0023_003DzkRSfKls1SLfn)) == -1)
				{
					return false;
				}
			}
			else
			{
				num2 = _0023_003DzqQtwmz8_003D[num - 1]._0023_003Dz77g161c_003D;
			}
			int num3;
			if (_0023_003DzqQtwmz8_003D[num - 1]._0023_003DzkKfJheA_003D == 1)
			{
				List<Point3D> list = new List<Point3D>(3);
				Point3D point3D3 = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(_0023_003DzqQtwmz8_003D[num - 1]._0023_003DzRpXgovo_003D, _0023_003Dzd9ZyL64_003D)];
				point3D3 = new Point3D(point3D3.X, point3D3.Y, point3D3.Z);
				Point3D point3D4 = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(_0023_003DzqQtwmz8_003D[num - 1]._0023_003DzRpXgovo_003D, _0023_003Dzd9ZyL64_003D)];
				point3D4 = new Point3D(point3D4.X, point3D4.Y, point3D4.Z);
				if ((num3 = _0023_003DzrraITPpPUVmn(_0023_003Dzd9ZyL64_003D, _0023_003DzqQtwmz8_003D[num - 1]._0023_003DzRpXgovo_003D, num2, _0023_003DzjMikPdqXh_0024DX)) == 0)
				{
					return false;
				}
				if (num2 == _0023_003Dzd9ZyL64_003D.vertexCount - 1)
				{
					Point3D item = new Point3D(_0023_003Dzd9ZyL64_003D._vertices[num2].X, _0023_003Dzd9ZyL64_003D._vertices[num2].Y, _0023_003Dzd9ZyL64_003D._vertices[num2].Z);
					list.Add(point3D3);
					list.Add(point3D4);
					list.Add(item);
					_0023_003Dzoq64prs_003D.Add(list);
				}
			}
			int num4;
			if (_0023_003DzqQtwmz8_003D[num]._0023_003Dz77g161c_003D >= _0023_003Dzd9ZyL64_003D.vertexCount)
			{
				point3D2 = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzqQtwmz8_003D[num]._0023_003Dz77g161c_003D];
				if ((num4 = _0023_003Dzmdel3ZTIgMDe(ref _0023_003Dzd9ZyL64_003D, point3D2, _0023_003DzkRSfKls1SLfn)) == -1)
				{
					return false;
				}
			}
			else
			{
				num4 = _0023_003DzqQtwmz8_003D[num]._0023_003Dz77g161c_003D;
			}
			if (_0023_003DzqQtwmz8_003D[num]._0023_003DzkKfJheA_003D == 1)
			{
				List<Point3D> list2 = new List<Point3D>(3);
				Point3D point3D5 = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(_0023_003DzqQtwmz8_003D[num]._0023_003DzRpXgovo_003D, _0023_003Dzd9ZyL64_003D)];
				point3D5 = new Point3D(point3D5.X, point3D5.Y, point3D5.Z);
				Point3D point3D6 = _0023_003Dzd9ZyL64_003D._vertices[_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(_0023_003DzqQtwmz8_003D[num]._0023_003DzRpXgovo_003D, _0023_003Dzd9ZyL64_003D)];
				point3D6 = new Point3D(point3D6.X, point3D6.Y, point3D6.Z);
				if ((num3 = _0023_003DzrraITPpPUVmn(_0023_003Dzd9ZyL64_003D, _0023_003DzqQtwmz8_003D[num]._0023_003DzRpXgovo_003D, num4, _0023_003DzjMikPdqXh_0024DX)) == 0)
				{
					return false;
				}
				if (num4 == _0023_003Dzd9ZyL64_003D.vertexCount - 1)
				{
					Point3D item2 = new Point3D(_0023_003Dzd9ZyL64_003D._vertices[num4].X, _0023_003Dzd9ZyL64_003D._vertices[num4].Y, _0023_003Dzd9ZyL64_003D._vertices[num4].Z);
					list2.Add(point3D5);
					list2.Add(point3D6);
					list2.Add(item2);
					_0023_003Dzoq64prs_003D.Add(list2);
				}
			}
			if ((num3 = _0023_003Dz2bKtHInA2tx2(_0023_003Dzd9ZyL64_003D, num2, num4, _0023_003DzjMikPdqXh_0024DX)) == 0)
			{
				return false;
			}
			if (num3 < 0)
			{
				continue;
			}
			_0023_003Dzd9ZyL64_003D.edgeDatas[num3].Type = 8;
			_0023_003Dzd9ZyL64_003D.edgeDatas[num3].NextFace = (_0023_003Dzd9ZyL64_003D.edgeDatas[num3].PreviousFace = _0023_003DzHEpjcdg2hk9U);
			int num5 = _0023_003DzRt7BPC1zB38_0024(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, num3, ref _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D, _0023_003DzkRSfKls1SLfn);
			if (num5 == 0)
			{
				continue;
			}
			int num6 = _0023_003DzRt7BPC1zB38_0024(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, -num3, ref _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D2, _0023_003DzkRSfKls1SLfn);
			if (num6 != 0)
			{
				_0023_003Dzw_0024hK_0024hYFvRbk(_0023_003Dzd9ZyL64_003D, num3, _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D);
				_0023_003Dzw_0024hK_0024hYFvRbk(_0023_003Dzd9ZyL64_003D, -num3, _0023_003DzZl0D_wEGDeCsA_khxA_003D_003D2);
				if (!_0023_003DzwYVAK8UGMSQE(_0023_003Dzd9ZyL64_003D, _0023_003DzHEpjcdg2hk9U, num5, num6, num3))
				{
					return false;
				}
			}
		}
		return true;
	}

	public static bool _0023_003DztYSJ_Y0TdoWQ(Solid _0023_003DzcDEsV8s_003D, ref int _0023_003Dz0m0kUL86w_QH, Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D _0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3 = default(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D);
		while (true)
		{
			if (_0023_003Dzd9ZyL64_003D.faceCount == _0023_003Dz1XOZELaODJu7(_0023_003Dzd9ZyL64_003D))
			{
				for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
				{
					_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel);
					_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3._0023_003DzfUgV2P8_003D = 0;
					_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3._0023_003Dzy3xqLbo_003D = 0;
					_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D3);
				}
				if (!_0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D((Solid.Portion)_0023_003Dzd9ZyL64_003D.Clone(), _0023_003DzcDEsV8s_003D))
				{
					return false;
				}
				return true;
			}
			Solid.Portion _0023_003Dzd9ZyL64_003D2 = (Solid.Portion)_0023_003Dzd9ZyL64_003D.Clone();
			if (!_0023_003Dz_0024EHl48jNZuTb(_0023_003Dzd9ZyL64_003D))
			{
				return false;
			}
			if (!_0023_003DztDdwD3iU3oOP(_0023_003Dzd9ZyL64_003D))
			{
				return false;
			}
			_0023_003Dz_8JqadwXrdJr(_0023_003Dzd9ZyL64_003D);
			_0023_003DzBM2lV10uPp25(_0023_003Dzd9ZyL64_003D);
			if (!_0023_003Dz_3U70nP5K3d1HlgbHw_003D_003D((Solid.Portion)_0023_003Dzd9ZyL64_003D.Clone(), _0023_003DzcDEsV8s_003D))
			{
				return false;
			}
			_0023_003Dzd9ZyL64_003D._0023_003DzDBrp9S8_003D(_0023_003Dzd9ZyL64_003D2);
			_0023_003Dzd9ZyL64_003D.Id = _0023_003Dz0m0kUL86w_QH++;
			for (int i = 1; i <= _0023_003Dzd9ZyL64_003D.faceCount; i++)
			{
				_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2 = _0023_003DzQLKKCNRzQuXx(_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel);
				if (_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D == 1)
				{
					_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D = 0;
				}
				else
				{
					_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2._0023_003DzfUgV2P8_003D = 1;
				}
				_0023_003Dzd9ZyL64_003D.faces[i].FaceLabel = _0023_003DzFKBkm1YBo_5J(_0023_003DzJ8auVjLIROUJ0_th71KLw0CNrzf2fqFvPuQQ0FY_003D2);
			}
			if (!_0023_003Dz_0024EHl48jNZuTb(_0023_003Dzd9ZyL64_003D))
			{
				return false;
			}
			if (!_0023_003DztDdwD3iU3oOP(_0023_003Dzd9ZyL64_003D))
			{
				break;
			}
			_0023_003Dz_8JqadwXrdJr(_0023_003Dzd9ZyL64_003D);
			_0023_003DzBM2lV10uPp25(_0023_003Dzd9ZyL64_003D);
		}
		return false;
	}

	internal static bool _0023_003DzkdnrtE4uzPF8(Point3D _0023_003DzxlSkjtE_003D, Point3D _0023_003DzRjIJn4I_003D, Point3D _0023_003Dz3a47y80_003D, Point3D _0023_003DzLGWu9uI_003D, ref Solid._0023_003DzZhsUDUz3mSgC _0023_003DzqunuPEk_003D)
	{
		if (!Utility.DoOverlapOrTouch(_0023_003DzxlSkjtE_003D, _0023_003DzRjIJn4I_003D, _0023_003Dz3a47y80_003D, _0023_003DzLGWu9uI_003D))
		{
			_0023_003DzqunuPEk_003D = (Solid._0023_003DzZhsUDUz3mSgC)2;
			return false;
		}
		return true;
	}

	internal static bool _0023_003DzcQt9lrVLzd3R(Solid _0023_003Dz2zoRYrk_003D, int _0023_003DzMJ9Rv10_003D, int _0023_003DzTx2aqr8_003D, ref Vector3D _0023_003Dz7hp7a0EFUobk, int _0023_003DzcJpaJQAcgoDn, double _0023_003DzkRSfKls1SLfn)
	{
		Solid.Portion portion = _0023_003Dz2zoRYrk_003D.portions[_0023_003DzMJ9Rv10_003D];
		int id = _0023_003Dz2zoRYrk_003D.portions[_0023_003DzMJ9Rv10_003D].Id;
		int count = _0023_003Dz2zoRYrk_003D.portions.Count;
		Point3D point3D = new Point3D();
		Point3D point3D2 = new Point3D();
		bool result = true;
		int num = 0;
		if (_0023_003DzTx2aqr8_003D > portion.edgeCount)
		{
			return false;
		}
		int num3;
		int num2 = (num3 = portion.Id);
		int num4 = _0023_003DzTx2aqr8_003D;
		int num5 = 0;
		if (_0023_003DzHp7KR2MP9HGJ(portion, _0023_003DzTx2aqr8_003D))
		{
			num5 = 1;
		}
		int id2 = portion.Id;
		_0023_003Dz7hp7a0EFUobk.X = (_0023_003Dz7hp7a0EFUobk.Y = (_0023_003Dz7hp7a0EFUobk.Z = 0.0));
		_0023_003DzP5_hz_0024hPufDR _0023_003DzP5_hz_0024hPufDR2 = _0023_003DzS9fn2m64jj9X;
		int num6 = 0;
		int num7 = -1;
		while (num++ < 200)
		{
			num7 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzmvS45b0roOxZ(_0023_003DzTx2aqr8_003D, portion);
			if (num7 > portion.faceCount)
			{
				break;
			}
			if (num7 > 0)
			{
				if ((portion.faces[num7].FaceLabel & 1) > 0)
				{
					_0023_003Dz7hp7a0EFUobk.X = portion.planes[num7].X;
					_0023_003Dz7hp7a0EFUobk.Y = portion.planes[num7].Y;
					_0023_003Dz7hp7a0EFUobk.Z = portion.planes[num7].Z;
					num6 = 1;
					break;
				}
				_0023_003Dz7hp7a0EFUobk.X += portion.planes[num7].X;
				_0023_003Dz7hp7a0EFUobk.Y += portion.planes[num7].Y;
				_0023_003Dz7hp7a0EFUobk.Z += portion.planes[num7].Z;
				_0023_003DzTx2aqr8_003D = -_0023_003DzP5_hz_0024hPufDR2(_0023_003DzTx2aqr8_003D, portion);
				num6++;
				goto IL_033e;
			}
			num3 = ((_0023_003DzTx2aqr8_003D <= 0) ? portion.edgeDatas[-_0023_003DzTx2aqr8_003D].PreviousEdge : portion.edgeDatas[_0023_003DzTx2aqr8_003D].NextEdge);
			int num8 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzgvbLr0qH7Irg(_0023_003DzTx2aqr8_003D, portion);
			point3D = portion._vertices[num8];
			int num9 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzXT_0024DTGaK6Dv9(_0023_003DzTx2aqr8_003D, portion);
			point3D2 = portion._vertices[num9];
			if (num3 == 0)
			{
				if (num5 != 0)
				{
					break;
				}
				_0023_003DzP5_hz_0024hPufDR2 = _0023_003DzZosIqTPXRnLG;
				_0023_003Dz7hp7a0EFUobk.X = (_0023_003Dz7hp7a0EFUobk.Y = (_0023_003Dz7hp7a0EFUobk.Z = 0.0));
				num6 = 0;
				num5 = 1;
				_0023_003DzTx2aqr8_003D = -_0023_003DzTx2aqr8_003D;
				id2 = portion.Id;
				continue;
			}
			int num10 = num3 - id;
			if (num10 < 0)
			{
				num10 = -num10;
			}
			Solid.Portion portion2;
			if (num10 < count)
			{
				portion2 = _0023_003Dz2zoRYrk_003D.portions[num10];
				if (portion2.Id == num3)
				{
					goto IL_031f;
				}
			}
			int num11 = 0;
			int num12 = count - 1;
			int num13 = 0;
			while (num11 <= num12)
			{
				num13 = (num11 + num12) / 2;
				portion2 = _0023_003Dz2zoRYrk_003D.portions[num13];
				if (portion2.Id != num3)
				{
					if (num3 < portion2.Id)
					{
						num12 = num13 - 1;
					}
					else
					{
						num11 = num13 + 1;
					}
					continue;
				}
				goto IL_031f;
			}
			if (num5 != 0)
			{
				break;
			}
			_0023_003DzP5_hz_0024hPufDR2 = _0023_003DzZosIqTPXRnLG;
			_0023_003Dz7hp7a0EFUobk.X = (_0023_003Dz7hp7a0EFUobk.Y = (_0023_003Dz7hp7a0EFUobk.Z = 0.0));
			num6 = 0;
			num5 = 1;
			_0023_003DzTx2aqr8_003D = -_0023_003DzTx2aqr8_003D;
			id2 = portion.Id;
			continue;
			IL_031f:
			int id3 = portion.Id;
			portion = portion2;
			if ((_0023_003DzTx2aqr8_003D = -_0023_003Dz2qe9pgM9s6mc(portion, point3D, point3D2, id3, _0023_003DzkRSfKls1SLfn)) == 0)
			{
				break;
			}
			goto IL_033e;
			IL_033e:
			if (_0023_003DzHp7KR2MP9HGJ(portion, _0023_003DzTx2aqr8_003D))
			{
				if (num5 != 0)
				{
					break;
				}
				_0023_003DzP5_hz_0024hPufDR2 = _0023_003DzZosIqTPXRnLG;
				_0023_003Dz7hp7a0EFUobk.X = (_0023_003Dz7hp7a0EFUobk.Y = (_0023_003Dz7hp7a0EFUobk.Z = 0.0));
				num6 = 0;
				num5 = 1;
				_0023_003DzTx2aqr8_003D = -_0023_003DzTx2aqr8_003D;
				id2 = portion.Id;
			}
			else if (num5 != 1 && id2 == num3 && _0023_003DzTx2aqr8_003D == num4)
			{
				break;
			}
		}
		if (num3 != num2)
		{
			portion = _0023_003Dz2zoRYrk_003D.portions[_0023_003DzMJ9Rv10_003D];
		}
		Vector3D vector3D = new Vector3D(_0023_003Dz7hp7a0EFUobk.X, _0023_003Dz7hp7a0EFUobk.Y, _0023_003Dz7hp7a0EFUobk.Z);
		if (!vector3D.Normalize())
		{
			_0023_003Dz7hp7a0EFUobk = new Vector3D();
			num7 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzmvS45b0roOxZ(num4, portion);
			if (num7 > portion.faceCount)
			{
				result = false;
				_0023_003Dz7hp7a0EFUobk.X = 0.0;
				_0023_003Dz7hp7a0EFUobk.Y = 0.0;
				_0023_003Dz7hp7a0EFUobk.Z = 1.0;
			}
			else if (num7 > 0)
			{
				_0023_003Dz7hp7a0EFUobk = portion.planes[num7];
			}
			else
			{
				num7 = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzmvS45b0roOxZ(-num4, portion);
				_0023_003Dz7hp7a0EFUobk = portion.planes[num7];
			}
		}
		else
		{
			_0023_003Dz7hp7a0EFUobk.X = vector3D.X;
			_0023_003Dz7hp7a0EFUobk.Y = vector3D.Y;
			_0023_003Dz7hp7a0EFUobk.Z = vector3D.Z;
		}
		return result;
	}

	private static bool _0023_003DzHp7KR2MP9HGJ(Solid.Portion _0023_003Dzd9ZyL64_003D, int _0023_003DzTx2aqr8_003D)
	{
		int num = Math.Abs(_0023_003DzTx2aqr8_003D);
		if ((_0023_003Dzd9ZyL64_003D.edgeDatas[num].Type & 1) > 0)
		{
			return true;
		}
		return false;
	}

	private static int _0023_003DzS9fn2m64jj9X(int _0023_003DzTx2aqr8_003D, Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		if (_0023_003DzTx2aqr8_003D > 0)
		{
			return _0023_003Dzd9ZyL64_003D.edgeDatas[_0023_003DzTx2aqr8_003D].NextEdge;
		}
		return _0023_003Dzd9ZyL64_003D.edgeDatas[-_0023_003DzTx2aqr8_003D].PreviousEdge;
	}

	private static int _0023_003DzZosIqTPXRnLG(int _0023_003DzVSPj6J_0024qA8wK, Solid.Portion _0023_003Dzd9ZyL64_003D)
	{
		int num = _0023_003DzVSPj6J_0024qA8wK;
		int result;
		do
		{
			result = num;
			num = _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003DzX_0024NuZLAtdLNx(num, _0023_003Dzd9ZyL64_003D);
		}
		while (num != _0023_003DzVSPj6J_0024qA8wK);
		return result;
	}

	private static int _0023_003Dz2qe9pgM9s6mc(Solid.Portion _0023_003Dz5Tpjxj5wp_0024R8, Point3D _0023_003DzgYn_0024Ldc_003D, Point3D _0023_003Dzu1Fq9I8_003D, int _0023_003DzSkUy_T8_003D, double _0023_003DzkRSfKls1SLfn)
	{
		for (int i = 1; i <= _0023_003Dz5Tpjxj5wp_0024R8.edgeCount; i++)
		{
			if ((_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].NextFace <= 0 || _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].PreviousFace <= 0) && (_0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].NextEdge == _0023_003DzSkUy_T8_003D || _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].PreviousEdge == _0023_003DzSkUy_T8_003D))
			{
				int beginVertex = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].BeginVertex;
				int endVertex = _0023_003Dz5Tpjxj5wp_0024R8.edgeDatas[i].EndVertex;
				if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dz5Tpjxj5wp_0024R8._vertices[beginVertex], _0023_003DzgYn_0024Ldc_003D, _0023_003DzkRSfKls1SLfn) && _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dz5Tpjxj5wp_0024R8._vertices[endVertex], _0023_003Dzu1Fq9I8_003D, _0023_003DzkRSfKls1SLfn))
				{
					return i;
				}
				if (_0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dz5Tpjxj5wp_0024R8._vertices[endVertex], _0023_003DzgYn_0024Ldc_003D, _0023_003DzkRSfKls1SLfn) && _0023_003DzLDZtKn1wx4hbCAGuLtxl9Pw_003D._0023_003Dz0CVowaLJ_0024Ik4(_0023_003Dz5Tpjxj5wp_0024R8._vertices[beginVertex], _0023_003Dzu1Fq9I8_003D, _0023_003DzkRSfKls1SLfn))
				{
					return -i;
				}
			}
		}
		return 0;
	}
}
