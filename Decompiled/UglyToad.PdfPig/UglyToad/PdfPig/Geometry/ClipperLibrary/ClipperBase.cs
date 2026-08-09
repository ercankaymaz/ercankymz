using System.Collections.Generic;

namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal class ClipperBase
{
	internal const double Horizontal = -3.4E+38;

	internal const int Skip = -2;

	internal const int Unassigned = -1;

	internal const double Tolerance = 1E-20;

	public const long loRange = 1073741823L;

	public const long hiRange = 4611686018427387903L;

	internal ClipperLocalMinima m_MinimaList;

	internal ClipperLocalMinima m_CurrentLM;

	internal List<List<ClipperTEdge>> m_edges = new List<List<ClipperTEdge>>();

	internal ClipperScanbeam m_Scanbeam;

	internal List<ClipperOutRec> m_PolyOuts;

	internal ClipperTEdge m_ActiveEdges;

	internal bool m_UseFullRange;

	internal bool m_HasOpenPaths;

	public bool PreserveCollinear { get; set; }

	internal static bool NearZero(double val)
	{
		if (val > -1E-20)
		{
			return val < 1E-20;
		}
		return false;
	}

	public void Swap(ref long val1, ref long val2)
	{
		long num = val1;
		val1 = val2;
		val2 = num;
	}

	internal static bool IsHorizontal(ClipperTEdge e)
	{
		return e.Delta.Y == 0;
	}

	internal bool PointIsVertex(ClipperIntPoint pt, ClipperOutPt pp)
	{
		ClipperOutPt clipperOutPt = pp;
		do
		{
			if (clipperOutPt.Pt == pt)
			{
				return true;
			}
			clipperOutPt = clipperOutPt.Next;
		}
		while (clipperOutPt != pp);
		return false;
	}

	internal bool PointOnLineSegment(ClipperIntPoint pt, ClipperIntPoint linePt1, ClipperIntPoint linePt2, bool UseFullRange)
	{
		if (UseFullRange)
		{
			if ((pt.X != linePt1.X || pt.Y != linePt1.Y) && (pt.X != linePt2.X || pt.Y != linePt2.Y))
			{
				if (pt.X > linePt1.X == pt.X < linePt2.X && pt.Y > linePt1.Y == pt.Y < linePt2.Y)
				{
					return ClipperInt128.Int128Mul(pt.X - linePt1.X, linePt2.Y - linePt1.Y) == ClipperInt128.Int128Mul(linePt2.X - linePt1.X, pt.Y - linePt1.Y);
				}
				return false;
			}
			return true;
		}
		if ((pt.X != linePt1.X || pt.Y != linePt1.Y) && (pt.X != linePt2.X || pt.Y != linePt2.Y))
		{
			if (pt.X > linePt1.X == pt.X < linePt2.X && pt.Y > linePt1.Y == pt.Y < linePt2.Y)
			{
				return (pt.X - linePt1.X) * (linePt2.Y - linePt1.Y) == (linePt2.X - linePt1.X) * (pt.Y - linePt1.Y);
			}
			return false;
		}
		return true;
	}

	internal bool PointOnPolygon(ClipperIntPoint pt, ClipperOutPt pp, bool UseFullRange)
	{
		ClipperOutPt clipperOutPt = pp;
		do
		{
			if (PointOnLineSegment(pt, clipperOutPt.Pt, clipperOutPt.Next.Pt, UseFullRange))
			{
				return true;
			}
			clipperOutPt = clipperOutPt.Next;
		}
		while (clipperOutPt != pp);
		return false;
	}

	internal static bool SlopesEqual(ClipperTEdge e1, ClipperTEdge e2, bool UseFullRange)
	{
		if (UseFullRange)
		{
			return ClipperInt128.Int128Mul(e1.Delta.Y, e2.Delta.X) == ClipperInt128.Int128Mul(e1.Delta.X, e2.Delta.Y);
		}
		return e1.Delta.Y * e2.Delta.X == e1.Delta.X * e2.Delta.Y;
	}

	internal static bool SlopesEqual(ClipperIntPoint pt1, ClipperIntPoint pt2, ClipperIntPoint pt3, bool UseFullRange)
	{
		if (UseFullRange)
		{
			return ClipperInt128.Int128Mul(pt1.Y - pt2.Y, pt2.X - pt3.X) == ClipperInt128.Int128Mul(pt1.X - pt2.X, pt2.Y - pt3.Y);
		}
		return (pt1.Y - pt2.Y) * (pt2.X - pt3.X) - (pt1.X - pt2.X) * (pt2.Y - pt3.Y) == 0;
	}

	internal static bool SlopesEqual(ClipperIntPoint pt1, ClipperIntPoint pt2, ClipperIntPoint pt3, ClipperIntPoint pt4, bool UseFullRange)
	{
		if (UseFullRange)
		{
			return ClipperInt128.Int128Mul(pt1.Y - pt2.Y, pt3.X - pt4.X) == ClipperInt128.Int128Mul(pt1.X - pt2.X, pt3.Y - pt4.Y);
		}
		return (pt1.Y - pt2.Y) * (pt3.X - pt4.X) - (pt1.X - pt2.X) * (pt3.Y - pt4.Y) == 0;
	}

	internal ClipperBase()
	{
		m_MinimaList = null;
		m_CurrentLM = null;
		m_UseFullRange = false;
		m_HasOpenPaths = false;
	}

	public virtual void Clear()
	{
		DisposeLocalMinimaList();
		for (int i = 0; i < m_edges.Count; i++)
		{
			for (int j = 0; j < m_edges[i].Count; j++)
			{
				m_edges[i][j] = null;
			}
			m_edges[i].Clear();
		}
		m_edges.Clear();
		m_UseFullRange = false;
		m_HasOpenPaths = false;
	}

	private void DisposeLocalMinimaList()
	{
		while (m_MinimaList != null)
		{
			ClipperLocalMinima next = m_MinimaList.Next;
			m_MinimaList = null;
			m_MinimaList = next;
		}
		m_CurrentLM = null;
	}

	private void RangeTest(ClipperIntPoint Pt, ref bool useFullRange)
	{
		if (useFullRange)
		{
			if (Pt.X > 4611686018427387903L || Pt.Y > 4611686018427387903L || -Pt.X > 4611686018427387903L || -Pt.Y > 4611686018427387903L)
			{
				throw new ClipperException("Coordinate outside allowed range");
			}
		}
		else if (Pt.X > 1073741823 || Pt.Y > 1073741823 || -Pt.X > 1073741823 || -Pt.Y > 1073741823)
		{
			useFullRange = true;
			RangeTest(Pt, ref useFullRange);
		}
	}

	private void InitEdge(ClipperTEdge e, ClipperTEdge eNext, ClipperTEdge ePrev, ClipperIntPoint pt)
	{
		e.Next = eNext;
		e.Prev = ePrev;
		e.Curr = pt;
		e.OutIdx = -1;
	}

	private void InitEdge2(ClipperTEdge e, ClipperPolyType polyType)
	{
		if (e.Curr.Y >= e.Next.Curr.Y)
		{
			e.Bot = e.Curr;
			e.Top = e.Next.Curr;
		}
		else
		{
			e.Top = e.Curr;
			e.Bot = e.Next.Curr;
		}
		SetDx(e);
		e.PolyTyp = polyType;
	}

	private ClipperTEdge FindNextLocMin(ClipperTEdge E)
	{
		while (true)
		{
			if (E.Bot != E.Prev.Bot || E.Curr == E.Top)
			{
				E = E.Next;
				continue;
			}
			if (E.Dx != -3.4E+38 && E.Prev.Dx != -3.4E+38)
			{
				break;
			}
			while (E.Prev.Dx == -3.4E+38)
			{
				E = E.Prev;
			}
			ClipperTEdge clipperTEdge = E;
			while (E.Dx == -3.4E+38)
			{
				E = E.Next;
			}
			if (E.Top.Y != E.Prev.Bot.Y)
			{
				if (clipperTEdge.Prev.Bot.X < E.Bot.X)
				{
					E = clipperTEdge;
				}
				break;
			}
		}
		return E;
	}

	private ClipperTEdge ProcessBound(ClipperTEdge E, bool LeftBoundIsForward)
	{
		ClipperTEdge clipperTEdge = E;
		if (clipperTEdge.OutIdx == -2)
		{
			E = clipperTEdge;
			if (LeftBoundIsForward)
			{
				while (E.Top.Y == E.Next.Bot.Y)
				{
					E = E.Next;
				}
				while (E != clipperTEdge && E.Dx == -3.4E+38)
				{
					E = E.Prev;
				}
			}
			else
			{
				while (E.Top.Y == E.Prev.Bot.Y)
				{
					E = E.Prev;
				}
				while (E != clipperTEdge && E.Dx == -3.4E+38)
				{
					E = E.Next;
				}
			}
			if (E == clipperTEdge)
			{
				clipperTEdge = ((!LeftBoundIsForward) ? E.Prev : E.Next);
			}
			else
			{
				E = ((!LeftBoundIsForward) ? clipperTEdge.Prev : clipperTEdge.Next);
				ClipperLocalMinima newLm = new ClipperLocalMinima
				{
					Next = null,
					Y = E.Bot.Y,
					LeftBound = null,
					RightBound = E
				};
				E.WindDelta = 0;
				clipperTEdge = ProcessBound(E, LeftBoundIsForward);
				InsertLocalMinima(newLm);
			}
			return clipperTEdge;
		}
		ClipperTEdge clipperTEdge2;
		if (E.Dx == -3.4E+38)
		{
			clipperTEdge2 = ((!LeftBoundIsForward) ? E.Next : E.Prev);
			if (clipperTEdge2.Dx == -3.4E+38)
			{
				if (clipperTEdge2.Bot.X != E.Bot.X && clipperTEdge2.Top.X != E.Bot.X)
				{
					ReverseHorizontal(E);
				}
			}
			else if (clipperTEdge2.Bot.X != E.Bot.X)
			{
				ReverseHorizontal(E);
			}
		}
		clipperTEdge2 = E;
		if (LeftBoundIsForward)
		{
			while (clipperTEdge.Top.Y == clipperTEdge.Next.Bot.Y && clipperTEdge.Next.OutIdx != -2)
			{
				clipperTEdge = clipperTEdge.Next;
			}
			if (clipperTEdge.Dx == -3.4E+38 && clipperTEdge.Next.OutIdx != -2)
			{
				ClipperTEdge clipperTEdge3 = clipperTEdge;
				while (clipperTEdge3.Prev.Dx == -3.4E+38)
				{
					clipperTEdge3 = clipperTEdge3.Prev;
				}
				if (clipperTEdge3.Prev.Top.X > clipperTEdge.Next.Top.X)
				{
					clipperTEdge = clipperTEdge3.Prev;
				}
			}
			while (E != clipperTEdge)
			{
				E.NextInLML = E.Next;
				if (E.Dx == -3.4E+38 && E != clipperTEdge2 && E.Bot.X != E.Prev.Top.X)
				{
					ReverseHorizontal(E);
				}
				E = E.Next;
			}
			if (E.Dx == -3.4E+38 && E != clipperTEdge2 && E.Bot.X != E.Prev.Top.X)
			{
				ReverseHorizontal(E);
			}
			return clipperTEdge.Next;
		}
		while (clipperTEdge.Top.Y == clipperTEdge.Prev.Bot.Y && clipperTEdge.Prev.OutIdx != -2)
		{
			clipperTEdge = clipperTEdge.Prev;
		}
		if (clipperTEdge.Dx == -3.4E+38 && clipperTEdge.Prev.OutIdx != -2)
		{
			ClipperTEdge clipperTEdge3 = clipperTEdge;
			while (clipperTEdge3.Next.Dx == -3.4E+38)
			{
				clipperTEdge3 = clipperTEdge3.Next;
			}
			if (clipperTEdge3.Next.Top.X == clipperTEdge.Prev.Top.X || clipperTEdge3.Next.Top.X > clipperTEdge.Prev.Top.X)
			{
				clipperTEdge = clipperTEdge3.Next;
			}
		}
		while (E != clipperTEdge)
		{
			E.NextInLML = E.Prev;
			if (E.Dx == -3.4E+38 && E != clipperTEdge2 && E.Bot.X != E.Next.Top.X)
			{
				ReverseHorizontal(E);
			}
			E = E.Prev;
		}
		if (E.Dx == -3.4E+38 && E != clipperTEdge2 && E.Bot.X != E.Next.Top.X)
		{
			ReverseHorizontal(E);
		}
		return clipperTEdge.Prev;
	}

	public bool AddPath(List<ClipperIntPoint> pg, ClipperPolyType polyType, bool Closed)
	{
		if (!Closed && polyType == ClipperPolyType.Clip)
		{
			throw new ClipperException("AddPath: Open paths must be subject.");
		}
		int num = pg.Count - 1;
		if (Closed)
		{
			while (num > 0 && pg[num] == pg[0])
			{
				num--;
			}
		}
		while (num > 0 && pg[num] == pg[num - 1])
		{
			num--;
		}
		if ((Closed && num < 2) || (!Closed && num < 1))
		{
			return false;
		}
		List<ClipperTEdge> list = new List<ClipperTEdge>(num + 1);
		for (int i = 0; i <= num; i++)
		{
			list.Add(new ClipperTEdge());
		}
		bool flag = true;
		list[1].Curr = pg[1];
		RangeTest(pg[0], ref m_UseFullRange);
		RangeTest(pg[num], ref m_UseFullRange);
		InitEdge(list[0], list[1], list[num], pg[0]);
		InitEdge(list[num], list[0], list[num - 1], pg[num]);
		for (int num2 = num - 1; num2 >= 1; num2--)
		{
			RangeTest(pg[num2], ref m_UseFullRange);
			InitEdge(list[num2], list[num2 + 1], list[num2 - 1], pg[num2]);
		}
		ClipperTEdge clipperTEdge = list[0];
		ClipperTEdge clipperTEdge2 = clipperTEdge;
		ClipperTEdge clipperTEdge3 = clipperTEdge;
		while (true)
		{
			if (clipperTEdge2.Curr == clipperTEdge2.Next.Curr && (Closed || clipperTEdge2.Next != clipperTEdge))
			{
				if (clipperTEdge2 == clipperTEdge2.Next)
				{
					break;
				}
				if (clipperTEdge2 == clipperTEdge)
				{
					clipperTEdge = clipperTEdge2.Next;
				}
				clipperTEdge2 = RemoveEdge(clipperTEdge2);
				clipperTEdge3 = clipperTEdge2;
				continue;
			}
			if (clipperTEdge2.Prev == clipperTEdge2.Next)
			{
				break;
			}
			if (Closed && SlopesEqual(clipperTEdge2.Prev.Curr, clipperTEdge2.Curr, clipperTEdge2.Next.Curr, m_UseFullRange) && (!PreserveCollinear || !Pt2IsBetweenPt1AndPt3(clipperTEdge2.Prev.Curr, clipperTEdge2.Curr, clipperTEdge2.Next.Curr)))
			{
				if (clipperTEdge2 == clipperTEdge)
				{
					clipperTEdge = clipperTEdge2.Next;
				}
				clipperTEdge2 = RemoveEdge(clipperTEdge2);
				clipperTEdge2 = clipperTEdge2.Prev;
				clipperTEdge3 = clipperTEdge2;
			}
			else
			{
				clipperTEdge2 = clipperTEdge2.Next;
				if (clipperTEdge2 == clipperTEdge3 || (!Closed && clipperTEdge2.Next == clipperTEdge))
				{
					break;
				}
			}
		}
		if ((!Closed && clipperTEdge2 == clipperTEdge2.Next) || (Closed && clipperTEdge2.Prev == clipperTEdge2.Next))
		{
			return false;
		}
		if (!Closed)
		{
			m_HasOpenPaths = true;
			clipperTEdge.Prev.OutIdx = -2;
		}
		clipperTEdge2 = clipperTEdge;
		do
		{
			InitEdge2(clipperTEdge2, polyType);
			clipperTEdge2 = clipperTEdge2.Next;
			if (flag && clipperTEdge2.Curr.Y != clipperTEdge.Curr.Y)
			{
				flag = false;
			}
		}
		while (clipperTEdge2 != clipperTEdge);
		if (flag)
		{
			if (Closed)
			{
				return false;
			}
			clipperTEdge2.Prev.OutIdx = -2;
			ClipperLocalMinima clipperLocalMinima = new ClipperLocalMinima
			{
				Next = null,
				Y = clipperTEdge2.Bot.Y,
				LeftBound = null,
				RightBound = clipperTEdge2
			};
			clipperLocalMinima.RightBound.Side = ClipperEdgeSide.Right;
			clipperLocalMinima.RightBound.WindDelta = 0;
			while (true)
			{
				if (clipperTEdge2.Bot.X != clipperTEdge2.Prev.Top.X)
				{
					ReverseHorizontal(clipperTEdge2);
				}
				if (clipperTEdge2.Next.OutIdx == -2)
				{
					break;
				}
				clipperTEdge2.NextInLML = clipperTEdge2.Next;
				clipperTEdge2 = clipperTEdge2.Next;
			}
			InsertLocalMinima(clipperLocalMinima);
			m_edges.Add(list);
			return true;
		}
		m_edges.Add(list);
		ClipperTEdge clipperTEdge4 = null;
		if (clipperTEdge2.Prev.Bot == clipperTEdge2.Prev.Top)
		{
			clipperTEdge2 = clipperTEdge2.Next;
		}
		while (true)
		{
			clipperTEdge2 = FindNextLocMin(clipperTEdge2);
			if (clipperTEdge2 == clipperTEdge4)
			{
				break;
			}
			if (clipperTEdge4 == null)
			{
				clipperTEdge4 = clipperTEdge2;
			}
			ClipperLocalMinima clipperLocalMinima2 = new ClipperLocalMinima
			{
				Next = null,
				Y = clipperTEdge2.Bot.Y
			};
			bool flag2;
			if (clipperTEdge2.Dx < clipperTEdge2.Prev.Dx)
			{
				clipperLocalMinima2.LeftBound = clipperTEdge2.Prev;
				clipperLocalMinima2.RightBound = clipperTEdge2;
				flag2 = false;
			}
			else
			{
				clipperLocalMinima2.LeftBound = clipperTEdge2;
				clipperLocalMinima2.RightBound = clipperTEdge2.Prev;
				flag2 = true;
			}
			clipperLocalMinima2.LeftBound.Side = ClipperEdgeSide.Left;
			clipperLocalMinima2.RightBound.Side = ClipperEdgeSide.Right;
			if (!Closed)
			{
				clipperLocalMinima2.LeftBound.WindDelta = 0;
			}
			else if (clipperLocalMinima2.LeftBound.Next == clipperLocalMinima2.RightBound)
			{
				clipperLocalMinima2.LeftBound.WindDelta = -1;
			}
			else
			{
				clipperLocalMinima2.LeftBound.WindDelta = 1;
			}
			clipperLocalMinima2.RightBound.WindDelta = -clipperLocalMinima2.LeftBound.WindDelta;
			clipperTEdge2 = ProcessBound(clipperLocalMinima2.LeftBound, flag2);
			if (clipperTEdge2.OutIdx == -2)
			{
				clipperTEdge2 = ProcessBound(clipperTEdge2, flag2);
			}
			ClipperTEdge clipperTEdge5 = ProcessBound(clipperLocalMinima2.RightBound, !flag2);
			if (clipperTEdge5.OutIdx == -2)
			{
				clipperTEdge5 = ProcessBound(clipperTEdge5, !flag2);
			}
			if (clipperLocalMinima2.LeftBound.OutIdx == -2)
			{
				clipperLocalMinima2.LeftBound = null;
			}
			else if (clipperLocalMinima2.RightBound.OutIdx == -2)
			{
				clipperLocalMinima2.RightBound = null;
			}
			InsertLocalMinima(clipperLocalMinima2);
			if (!flag2)
			{
				clipperTEdge2 = clipperTEdge5;
			}
		}
		return true;
	}

	public bool AddPaths(List<List<ClipperIntPoint>> ppg, ClipperPolyType polyType, bool closed)
	{
		bool result = false;
		for (int i = 0; i < ppg.Count; i++)
		{
			if (AddPath(ppg[i], polyType, closed))
			{
				result = true;
			}
		}
		return result;
	}

	internal bool Pt2IsBetweenPt1AndPt3(ClipperIntPoint pt1, ClipperIntPoint pt2, ClipperIntPoint pt3)
	{
		if (pt1 == pt3 || pt1 == pt2 || pt3 == pt2)
		{
			return false;
		}
		if (pt1.X != pt3.X)
		{
			return pt2.X > pt1.X == pt2.X < pt3.X;
		}
		return pt2.Y > pt1.Y == pt2.Y < pt3.Y;
	}

	private ClipperTEdge RemoveEdge(ClipperTEdge e)
	{
		e.Prev.Next = e.Next;
		e.Next.Prev = e.Prev;
		ClipperTEdge next = e.Next;
		e.Prev = null;
		return next;
	}

	private void SetDx(ClipperTEdge e)
	{
		e.Delta.X = e.Top.X - e.Bot.X;
		e.Delta.Y = e.Top.Y - e.Bot.Y;
		if (e.Delta.Y == 0L)
		{
			e.Dx = -3.4E+38;
		}
		else
		{
			e.Dx = (double)e.Delta.X / (double)e.Delta.Y;
		}
	}

	private void InsertLocalMinima(ClipperLocalMinima newLm)
	{
		if (m_MinimaList == null)
		{
			m_MinimaList = newLm;
			return;
		}
		if (newLm.Y >= m_MinimaList.Y)
		{
			newLm.Next = m_MinimaList;
			m_MinimaList = newLm;
			return;
		}
		ClipperLocalMinima clipperLocalMinima = m_MinimaList;
		while (clipperLocalMinima.Next != null && newLm.Y < clipperLocalMinima.Next.Y)
		{
			clipperLocalMinima = clipperLocalMinima.Next;
		}
		newLm.Next = clipperLocalMinima.Next;
		clipperLocalMinima.Next = newLm;
	}

	internal bool PopLocalMinima(long Y, out ClipperLocalMinima current)
	{
		current = m_CurrentLM;
		if (m_CurrentLM != null && m_CurrentLM.Y == Y)
		{
			m_CurrentLM = m_CurrentLM.Next;
			return true;
		}
		return false;
	}

	private void ReverseHorizontal(ClipperTEdge e)
	{
		Swap(ref e.Top.X, ref e.Bot.X);
	}

	internal virtual void Reset()
	{
		m_CurrentLM = m_MinimaList;
		if (m_CurrentLM == null)
		{
			return;
		}
		m_Scanbeam = null;
		for (ClipperLocalMinima clipperLocalMinima = m_MinimaList; clipperLocalMinima != null; clipperLocalMinima = clipperLocalMinima.Next)
		{
			InsertScanbeam(clipperLocalMinima.Y);
			ClipperTEdge leftBound = clipperLocalMinima.LeftBound;
			if (leftBound != null)
			{
				leftBound.Curr = leftBound.Bot;
				leftBound.OutIdx = -1;
			}
			leftBound = clipperLocalMinima.RightBound;
			if (leftBound != null)
			{
				leftBound.Curr = leftBound.Bot;
				leftBound.OutIdx = -1;
			}
		}
		m_ActiveEdges = null;
	}

	public static ClipperIntRect GetBounds(List<List<ClipperIntPoint>> paths)
	{
		int i = 0;
		int count;
		for (count = paths.Count; i < count && paths[i].Count == 0; i++)
		{
		}
		if (i == count)
		{
			return new ClipperIntRect(0L, 0L, 0L, 0L);
		}
		ClipperIntRect result = new ClipperIntRect
		{
			Left = paths[i][0].X
		};
		result.Right = result.Left;
		result.Top = paths[i][0].Y;
		result.Bottom = result.Top;
		for (; i < count; i++)
		{
			for (int j = 0; j < paths[i].Count; j++)
			{
				if (paths[i][j].X < result.Left)
				{
					result.Left = paths[i][j].X;
				}
				else if (paths[i][j].X > result.Right)
				{
					result.Right = paths[i][j].X;
				}
				if (paths[i][j].Y < result.Top)
				{
					result.Top = paths[i][j].Y;
				}
				else if (paths[i][j].Y > result.Bottom)
				{
					result.Bottom = paths[i][j].Y;
				}
			}
		}
		return result;
	}

	internal void InsertScanbeam(long Y)
	{
		if (m_Scanbeam == null)
		{
			m_Scanbeam = new ClipperScanbeam
			{
				Next = null,
				Y = Y
			};
			return;
		}
		if (Y > m_Scanbeam.Y)
		{
			ClipperScanbeam scanbeam = new ClipperScanbeam
			{
				Y = Y,
				Next = m_Scanbeam
			};
			m_Scanbeam = scanbeam;
			return;
		}
		ClipperScanbeam clipperScanbeam = m_Scanbeam;
		while (clipperScanbeam.Next != null && Y <= clipperScanbeam.Next.Y)
		{
			clipperScanbeam = clipperScanbeam.Next;
		}
		if (Y != clipperScanbeam.Y)
		{
			ClipperScanbeam next = new ClipperScanbeam
			{
				Y = Y,
				Next = clipperScanbeam.Next
			};
			clipperScanbeam.Next = next;
		}
	}

	internal bool PopScanbeam(out long Y)
	{
		if (m_Scanbeam == null)
		{
			Y = 0L;
			return false;
		}
		Y = m_Scanbeam.Y;
		m_Scanbeam = m_Scanbeam.Next;
		return true;
	}

	internal bool LocalMinimaPending()
	{
		return m_CurrentLM != null;
	}

	internal ClipperOutRec CreateOutRec()
	{
		ClipperOutRec clipperOutRec = new ClipperOutRec
		{
			Idx = -1,
			IsHole = false,
			IsOpen = false,
			FirstLeft = null,
			Pts = null,
			BottomPt = null,
			PolyNode = null
		};
		m_PolyOuts.Add(clipperOutRec);
		clipperOutRec.Idx = m_PolyOuts.Count - 1;
		return clipperOutRec;
	}

	internal void DisposeOutRec(int index)
	{
		m_PolyOuts[index].Pts = null;
		m_PolyOuts[index] = null;
	}

	internal void UpdateEdgeIntoAEL(ref ClipperTEdge e)
	{
		if (e.NextInLML == null)
		{
			throw new ClipperException("UpdateEdgeIntoAEL: invalid call");
		}
		ClipperTEdge prevInAEL = e.PrevInAEL;
		ClipperTEdge nextInAEL = e.NextInAEL;
		e.NextInLML.OutIdx = e.OutIdx;
		if (prevInAEL != null)
		{
			prevInAEL.NextInAEL = e.NextInLML;
		}
		else
		{
			m_ActiveEdges = e.NextInLML;
		}
		if (nextInAEL != null)
		{
			nextInAEL.PrevInAEL = e.NextInLML;
		}
		e.NextInLML.Side = e.Side;
		e.NextInLML.WindDelta = e.WindDelta;
		e.NextInLML.WindCnt = e.WindCnt;
		e.NextInLML.WindCnt2 = e.WindCnt2;
		e = e.NextInLML;
		e.Curr = e.Bot;
		e.PrevInAEL = prevInAEL;
		e.NextInAEL = nextInAEL;
		if (!IsHorizontal(e))
		{
			InsertScanbeam(e.Top.Y);
		}
	}

	internal void SwapPositionsInAEL(ClipperTEdge edge1, ClipperTEdge edge2)
	{
		if (edge1.NextInAEL == edge1.PrevInAEL || edge2.NextInAEL == edge2.PrevInAEL)
		{
			return;
		}
		if (edge1.NextInAEL == edge2)
		{
			ClipperTEdge nextInAEL = edge2.NextInAEL;
			if (nextInAEL != null)
			{
				nextInAEL.PrevInAEL = edge1;
			}
			ClipperTEdge prevInAEL = edge1.PrevInAEL;
			if (prevInAEL != null)
			{
				prevInAEL.NextInAEL = edge2;
			}
			edge2.PrevInAEL = prevInAEL;
			edge2.NextInAEL = edge1;
			edge1.PrevInAEL = edge2;
			edge1.NextInAEL = nextInAEL;
		}
		else if (edge2.NextInAEL == edge1)
		{
			ClipperTEdge nextInAEL2 = edge1.NextInAEL;
			if (nextInAEL2 != null)
			{
				nextInAEL2.PrevInAEL = edge2;
			}
			ClipperTEdge prevInAEL2 = edge2.PrevInAEL;
			if (prevInAEL2 != null)
			{
				prevInAEL2.NextInAEL = edge1;
			}
			edge1.PrevInAEL = prevInAEL2;
			edge1.NextInAEL = edge2;
			edge2.PrevInAEL = edge1;
			edge2.NextInAEL = nextInAEL2;
		}
		else
		{
			ClipperTEdge nextInAEL3 = edge1.NextInAEL;
			ClipperTEdge prevInAEL3 = edge1.PrevInAEL;
			edge1.NextInAEL = edge2.NextInAEL;
			if (edge1.NextInAEL != null)
			{
				edge1.NextInAEL.PrevInAEL = edge1;
			}
			edge1.PrevInAEL = edge2.PrevInAEL;
			if (edge1.PrevInAEL != null)
			{
				edge1.PrevInAEL.NextInAEL = edge1;
			}
			edge2.NextInAEL = nextInAEL3;
			if (edge2.NextInAEL != null)
			{
				edge2.NextInAEL.PrevInAEL = edge2;
			}
			edge2.PrevInAEL = prevInAEL3;
			if (edge2.PrevInAEL != null)
			{
				edge2.PrevInAEL.NextInAEL = edge2;
			}
		}
		if (edge1.PrevInAEL == null)
		{
			m_ActiveEdges = edge1;
		}
		else if (edge2.PrevInAEL == null)
		{
			m_ActiveEdges = edge2;
		}
	}

	internal void DeleteFromAEL(ClipperTEdge e)
	{
		ClipperTEdge prevInAEL = e.PrevInAEL;
		ClipperTEdge nextInAEL = e.NextInAEL;
		if (prevInAEL != null || nextInAEL != null || e == m_ActiveEdges)
		{
			if (prevInAEL != null)
			{
				prevInAEL.NextInAEL = nextInAEL;
			}
			else
			{
				m_ActiveEdges = nextInAEL;
			}
			if (nextInAEL != null)
			{
				nextInAEL.PrevInAEL = prevInAEL;
			}
			e.NextInAEL = null;
			e.PrevInAEL = null;
		}
	}
}
