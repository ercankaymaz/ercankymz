using System;
using System.Collections.Generic;

namespace UglyToad.PdfPig.Geometry.ClipperLibrary;

internal class Clipper : ClipperBase
{
	internal enum NodeType
	{
		ntAny,
		ntOpen,
		ntClosed
	}

	public const int ioReverseSolution = 1;

	public const int ioStrictlySimple = 2;

	public const int ioPreserveCollinear = 4;

	private ClipperClipType m_ClipType;

	private ClipperMaxima m_Maxima;

	private ClipperTEdge m_SortedEdges;

	private readonly List<ClipperIntersectNode> m_IntersectList;

	private readonly IComparer<ClipperIntersectNode> m_IntersectNodeComparer;

	private bool m_ExecuteLocked;

	private ClipperPolyFillType m_ClipFillType;

	private ClipperPolyFillType m_SubjFillType;

	private readonly List<ClipperJoin> m_Joins;

	private readonly List<ClipperJoin> m_GhostJoins;

	private bool m_UsingPolyTree;

	public bool ReverseSolution { get; set; }

	public bool StrictlySimple { get; set; }

	public Clipper(int InitOptions = 0)
	{
		m_Scanbeam = null;
		m_Maxima = null;
		m_ActiveEdges = null;
		m_SortedEdges = null;
		m_IntersectList = new List<ClipperIntersectNode>();
		m_IntersectNodeComparer = new ClipperIntersectNodeSort();
		m_ExecuteLocked = false;
		m_UsingPolyTree = false;
		m_PolyOuts = new List<ClipperOutRec>();
		m_Joins = new List<ClipperJoin>();
		m_GhostJoins = new List<ClipperJoin>();
		ReverseSolution = (1 & InitOptions) != 0;
		StrictlySimple = (2 & InitOptions) != 0;
		base.PreserveCollinear = (4 & InitOptions) != 0;
	}

	private void InsertMaxima(long X)
	{
		ClipperMaxima clipperMaxima = new ClipperMaxima
		{
			X = X
		};
		if (m_Maxima == null)
		{
			m_Maxima = clipperMaxima;
			m_Maxima.Next = null;
			m_Maxima.Previous = null;
			return;
		}
		if (X < m_Maxima.X)
		{
			clipperMaxima.Next = m_Maxima;
			clipperMaxima.Previous = null;
			m_Maxima = clipperMaxima;
			return;
		}
		ClipperMaxima clipperMaxima2 = m_Maxima;
		while (clipperMaxima2.Next != null && X >= clipperMaxima2.Next.X)
		{
			clipperMaxima2 = clipperMaxima2.Next;
		}
		if (X != clipperMaxima2.X)
		{
			clipperMaxima.Next = clipperMaxima2.Next;
			clipperMaxima.Previous = clipperMaxima2;
			if (clipperMaxima2.Next != null)
			{
				clipperMaxima2.Next.Previous = clipperMaxima;
			}
			clipperMaxima2.Next = clipperMaxima;
		}
	}

	public bool Execute(ClipperClipType clipType, List<List<ClipperIntPoint>> solution, ClipperPolyFillType FillType = ClipperPolyFillType.EvenOdd)
	{
		return Execute(clipType, solution, FillType, FillType);
	}

	public bool Execute(ClipperClipType clipType, ClipperPolyTree polytree, ClipperPolyFillType FillType = ClipperPolyFillType.EvenOdd)
	{
		return Execute(clipType, polytree, FillType, FillType);
	}

	public bool Execute(ClipperClipType clipType, List<List<ClipperIntPoint>> solution, ClipperPolyFillType subjFillType, ClipperPolyFillType clipFillType)
	{
		if (m_ExecuteLocked)
		{
			return false;
		}
		if (m_HasOpenPaths)
		{
			throw new ClipperException("Error: PolyTree struct is needed for open path clipping.");
		}
		m_ExecuteLocked = true;
		solution.Clear();
		m_SubjFillType = subjFillType;
		m_ClipFillType = clipFillType;
		m_ClipType = clipType;
		m_UsingPolyTree = false;
		bool flag;
		try
		{
			flag = ExecuteInternal();
			if (flag)
			{
				BuildResult(solution);
			}
		}
		finally
		{
			DisposeAllPolyPts();
			m_ExecuteLocked = false;
		}
		return flag;
	}

	public bool Execute(ClipperClipType clipType, ClipperPolyTree polytree, ClipperPolyFillType subjFillType, ClipperPolyFillType clipFillType)
	{
		if (m_ExecuteLocked)
		{
			return false;
		}
		m_ExecuteLocked = true;
		m_SubjFillType = subjFillType;
		m_ClipFillType = clipFillType;
		m_ClipType = clipType;
		m_UsingPolyTree = true;
		bool flag;
		try
		{
			flag = ExecuteInternal();
			if (flag)
			{
				BuildResult2(polytree);
			}
		}
		finally
		{
			DisposeAllPolyPts();
			m_ExecuteLocked = false;
		}
		return flag;
	}

	internal void FixHoleLinkage(ClipperOutRec outRec)
	{
		if (outRec.FirstLeft != null && (outRec.IsHole == outRec.FirstLeft.IsHole || outRec.FirstLeft.Pts == null))
		{
			ClipperOutRec firstLeft = outRec.FirstLeft;
			while (firstLeft != null && (firstLeft.IsHole == outRec.IsHole || firstLeft.Pts == null))
			{
				firstLeft = firstLeft.FirstLeft;
			}
			outRec.FirstLeft = firstLeft;
		}
	}

	private bool ExecuteInternal()
	{
		try
		{
			Reset();
			m_SortedEdges = null;
			m_Maxima = null;
			if (!PopScanbeam(out var Y))
			{
				return false;
			}
			InsertLocalMinimaIntoAEL(Y);
			long Y2;
			while (PopScanbeam(out Y2) || LocalMinimaPending())
			{
				ProcessHorizontals();
				m_GhostJoins.Clear();
				if (!ProcessIntersections(Y2))
				{
					return false;
				}
				ProcessEdgesAtTopOfScanbeam(Y2);
				Y = Y2;
				InsertLocalMinimaIntoAEL(Y);
			}
			foreach (ClipperOutRec polyOut in m_PolyOuts)
			{
				if (polyOut.Pts != null && !polyOut.IsOpen && (polyOut.IsHole ^ ReverseSolution) == Area(polyOut) > 0.0)
				{
					ReversePolyPtLinks(polyOut.Pts);
				}
			}
			JoinCommonEdges();
			foreach (ClipperOutRec polyOut2 in m_PolyOuts)
			{
				if (polyOut2.Pts != null)
				{
					if (polyOut2.IsOpen)
					{
						FixupOutPolyline(polyOut2);
					}
					else
					{
						FixupOutPolygon(polyOut2);
					}
				}
			}
			if (StrictlySimple)
			{
				DoSimplePolygons();
			}
			return true;
		}
		finally
		{
			m_Joins.Clear();
			m_GhostJoins.Clear();
		}
	}

	private void DisposeAllPolyPts()
	{
		for (int i = 0; i < m_PolyOuts.Count; i++)
		{
			DisposeOutRec(i);
		}
		m_PolyOuts.Clear();
	}

	private void AddJoin(ClipperOutPt Op1, ClipperOutPt Op2, ClipperIntPoint OffPt)
	{
		ClipperJoin item = new ClipperJoin
		{
			OutPt1 = Op1,
			OutPt2 = Op2,
			OffPt = OffPt
		};
		m_Joins.Add(item);
	}

	private void AddGhostJoin(ClipperOutPt Op, ClipperIntPoint OffPt)
	{
		ClipperJoin item = new ClipperJoin
		{
			OutPt1 = Op,
			OffPt = OffPt
		};
		m_GhostJoins.Add(item);
	}

	private void InsertLocalMinimaIntoAEL(long botY)
	{
		ClipperLocalMinima current;
		while (PopLocalMinima(botY, out current))
		{
			ClipperTEdge leftBound = current.LeftBound;
			ClipperTEdge rightBound = current.RightBound;
			ClipperOutPt clipperOutPt = null;
			if (leftBound == null)
			{
				InsertEdgeIntoAEL(rightBound, null);
				SetWindingCount(rightBound);
				if (IsContributing(rightBound))
				{
					clipperOutPt = AddOutPt(rightBound, rightBound.Bot);
				}
			}
			else if (rightBound == null)
			{
				InsertEdgeIntoAEL(leftBound, null);
				SetWindingCount(leftBound);
				if (IsContributing(leftBound))
				{
					clipperOutPt = AddOutPt(leftBound, leftBound.Bot);
				}
				InsertScanbeam(leftBound.Top.Y);
			}
			else
			{
				InsertEdgeIntoAEL(leftBound, null);
				InsertEdgeIntoAEL(rightBound, leftBound);
				SetWindingCount(leftBound);
				rightBound.WindCnt = leftBound.WindCnt;
				rightBound.WindCnt2 = leftBound.WindCnt2;
				if (IsContributing(leftBound))
				{
					clipperOutPt = AddLocalMinPoly(leftBound, rightBound, leftBound.Bot);
				}
				InsertScanbeam(leftBound.Top.Y);
			}
			if (rightBound != null)
			{
				if (ClipperBase.IsHorizontal(rightBound))
				{
					if (rightBound.NextInLML != null)
					{
						InsertScanbeam(rightBound.NextInLML.Top.Y);
					}
					AddEdgeToSEL(rightBound);
				}
				else
				{
					InsertScanbeam(rightBound.Top.Y);
				}
			}
			if (leftBound == null || rightBound == null)
			{
				continue;
			}
			if (clipperOutPt != null && ClipperBase.IsHorizontal(rightBound) && m_GhostJoins.Count > 0 && rightBound.WindDelta != 0)
			{
				for (int i = 0; i < m_GhostJoins.Count; i++)
				{
					ClipperJoin clipperJoin = m_GhostJoins[i];
					if (HorzSegmentsOverlap(clipperJoin.OutPt1.Pt.X, clipperJoin.OffPt.X, rightBound.Bot.X, rightBound.Top.X))
					{
						AddJoin(clipperJoin.OutPt1, clipperOutPt, clipperJoin.OffPt);
					}
				}
			}
			if (leftBound.OutIdx >= 0 && leftBound.PrevInAEL != null && leftBound.PrevInAEL.Curr.X == leftBound.Bot.X && leftBound.PrevInAEL.OutIdx >= 0 && ClipperBase.SlopesEqual(leftBound.PrevInAEL.Curr, leftBound.PrevInAEL.Top, leftBound.Curr, leftBound.Top, m_UseFullRange) && leftBound.WindDelta != 0 && leftBound.PrevInAEL.WindDelta != 0)
			{
				ClipperOutPt op = AddOutPt(leftBound.PrevInAEL, leftBound.Bot);
				AddJoin(clipperOutPt, op, leftBound.Top);
			}
			if (leftBound.NextInAEL == rightBound)
			{
				continue;
			}
			if (rightBound.OutIdx >= 0 && rightBound.PrevInAEL.OutIdx >= 0 && ClipperBase.SlopesEqual(rightBound.PrevInAEL.Curr, rightBound.PrevInAEL.Top, rightBound.Curr, rightBound.Top, m_UseFullRange) && rightBound.WindDelta != 0 && rightBound.PrevInAEL.WindDelta != 0)
			{
				ClipperOutPt op2 = AddOutPt(rightBound.PrevInAEL, rightBound.Bot);
				AddJoin(clipperOutPt, op2, rightBound.Top);
			}
			ClipperTEdge nextInAEL = leftBound.NextInAEL;
			if (nextInAEL != null)
			{
				while (nextInAEL != rightBound)
				{
					IntersectEdges(rightBound, nextInAEL, leftBound.Curr);
					nextInAEL = nextInAEL.NextInAEL;
				}
			}
		}
	}

	private void InsertEdgeIntoAEL(ClipperTEdge edge, ClipperTEdge startEdge)
	{
		if (m_ActiveEdges == null)
		{
			edge.PrevInAEL = null;
			edge.NextInAEL = null;
			m_ActiveEdges = edge;
			return;
		}
		if (startEdge == null && E2InsertsBeforeE1(m_ActiveEdges, edge))
		{
			edge.PrevInAEL = null;
			edge.NextInAEL = m_ActiveEdges;
			m_ActiveEdges.PrevInAEL = edge;
			m_ActiveEdges = edge;
			return;
		}
		if (startEdge == null)
		{
			startEdge = m_ActiveEdges;
		}
		while (startEdge.NextInAEL != null && !E2InsertsBeforeE1(startEdge.NextInAEL, edge))
		{
			startEdge = startEdge.NextInAEL;
		}
		edge.NextInAEL = startEdge.NextInAEL;
		if (startEdge.NextInAEL != null)
		{
			startEdge.NextInAEL.PrevInAEL = edge;
		}
		edge.PrevInAEL = startEdge;
		startEdge.NextInAEL = edge;
	}

	private bool E2InsertsBeforeE1(ClipperTEdge e1, ClipperTEdge e2)
	{
		if (e2.Curr.X == e1.Curr.X)
		{
			if (e2.Top.Y > e1.Top.Y)
			{
				return e2.Top.X < TopX(e1, e2.Top.Y);
			}
			return e1.Top.X > TopX(e2, e1.Top.Y);
		}
		return e2.Curr.X < e1.Curr.X;
	}

	private bool IsEvenOddFillType(ClipperTEdge edge)
	{
		if (edge.PolyTyp == ClipperPolyType.Subject)
		{
			return m_SubjFillType == ClipperPolyFillType.EvenOdd;
		}
		return m_ClipFillType == ClipperPolyFillType.EvenOdd;
	}

	private bool IsEvenOddAltFillType(ClipperTEdge edge)
	{
		if (edge.PolyTyp == ClipperPolyType.Subject)
		{
			return m_ClipFillType == ClipperPolyFillType.EvenOdd;
		}
		return m_SubjFillType == ClipperPolyFillType.EvenOdd;
	}

	private bool IsContributing(ClipperTEdge edge)
	{
		ClipperPolyFillType clipperPolyFillType;
		if (edge.PolyTyp == ClipperPolyType.Subject)
		{
			clipperPolyFillType = m_SubjFillType;
			_ = m_ClipFillType;
		}
		else
		{
			clipperPolyFillType = m_ClipFillType;
			_ = m_SubjFillType;
		}
		if (clipperPolyFillType == ClipperPolyFillType.EvenOdd || clipperPolyFillType != ClipperPolyFillType.NonZero)
		{
			if (edge.WindDelta == 0 && edge.WindCnt != 1)
			{
				return false;
			}
		}
		else if (Math.Abs(edge.WindCnt) != 1)
		{
			return false;
		}
		switch (m_ClipType)
		{
		case ClipperClipType.Intersection:
			return edge.WindCnt2 != 0;
		case ClipperClipType.Union:
			return edge.WindCnt2 == 0;
		case ClipperClipType.Difference:
			if (edge.PolyTyp == ClipperPolyType.Subject)
			{
				return edge.WindCnt2 == 0;
			}
			return edge.WindCnt2 != 0;
		case ClipperClipType.Xor:
			if (edge.WindDelta == 0)
			{
				return edge.WindCnt2 == 0;
			}
			return true;
		default:
			return true;
		}
	}

	private void SetWindingCount(ClipperTEdge edge)
	{
		ClipperTEdge prevInAEL = edge.PrevInAEL;
		while (prevInAEL != null && (prevInAEL.PolyTyp != edge.PolyTyp || prevInAEL.WindDelta == 0))
		{
			prevInAEL = prevInAEL.PrevInAEL;
		}
		if (prevInAEL == null)
		{
			if (edge.PolyTyp != ClipperPolyType.Subject)
			{
				_ = m_ClipFillType;
			}
			else
			{
				_ = m_SubjFillType;
			}
			if (edge.WindDelta == 0)
			{
				edge.WindCnt = 1;
			}
			else
			{
				edge.WindCnt = edge.WindDelta;
			}
			edge.WindCnt2 = 0;
			prevInAEL = m_ActiveEdges;
		}
		else if (edge.WindDelta == 0 && m_ClipType != ClipperClipType.Union)
		{
			edge.WindCnt = 1;
			edge.WindCnt2 = prevInAEL.WindCnt2;
			prevInAEL = prevInAEL.NextInAEL;
		}
		else if (IsEvenOddFillType(edge))
		{
			if (edge.WindDelta == 0)
			{
				bool flag = true;
				for (ClipperTEdge prevInAEL2 = prevInAEL.PrevInAEL; prevInAEL2 != null; prevInAEL2 = prevInAEL2.PrevInAEL)
				{
					if (prevInAEL2.PolyTyp == prevInAEL.PolyTyp && prevInAEL2.WindDelta != 0)
					{
						flag = !flag;
					}
				}
				edge.WindCnt = ((!flag) ? 1 : 0);
			}
			else
			{
				edge.WindCnt = edge.WindDelta;
			}
			edge.WindCnt2 = prevInAEL.WindCnt2;
			prevInAEL = prevInAEL.NextInAEL;
		}
		else
		{
			if (prevInAEL.WindCnt * prevInAEL.WindDelta < 0)
			{
				if (Math.Abs(prevInAEL.WindCnt) > 1)
				{
					if (prevInAEL.WindDelta * edge.WindDelta < 0)
					{
						edge.WindCnt = prevInAEL.WindCnt;
					}
					else
					{
						edge.WindCnt = prevInAEL.WindCnt + edge.WindDelta;
					}
				}
				else
				{
					edge.WindCnt = ((edge.WindDelta == 0) ? 1 : edge.WindDelta);
				}
			}
			else if (edge.WindDelta == 0)
			{
				edge.WindCnt = ((prevInAEL.WindCnt < 0) ? (prevInAEL.WindCnt - 1) : (prevInAEL.WindCnt + 1));
			}
			else if (prevInAEL.WindDelta * edge.WindDelta < 0)
			{
				edge.WindCnt = prevInAEL.WindCnt;
			}
			else
			{
				edge.WindCnt = prevInAEL.WindCnt + edge.WindDelta;
			}
			edge.WindCnt2 = prevInAEL.WindCnt2;
			prevInAEL = prevInAEL.NextInAEL;
		}
		if (IsEvenOddAltFillType(edge))
		{
			while (prevInAEL != edge)
			{
				if (prevInAEL.WindDelta != 0)
				{
					edge.WindCnt2 = ((edge.WindCnt2 == 0) ? 1 : 0);
				}
				prevInAEL = prevInAEL.NextInAEL;
			}
		}
		else
		{
			while (prevInAEL != edge)
			{
				edge.WindCnt2 += prevInAEL.WindDelta;
				prevInAEL = prevInAEL.NextInAEL;
			}
		}
	}

	private void AddEdgeToSEL(ClipperTEdge edge)
	{
		if (m_SortedEdges == null)
		{
			m_SortedEdges = edge;
			edge.PrevInSEL = null;
			edge.NextInSEL = null;
		}
		else
		{
			edge.NextInSEL = m_SortedEdges;
			edge.PrevInSEL = null;
			m_SortedEdges.PrevInSEL = edge;
			m_SortedEdges = edge;
		}
	}

	internal bool PopEdgeFromSEL(out ClipperTEdge e)
	{
		e = m_SortedEdges;
		if (e == null)
		{
			return false;
		}
		ClipperTEdge obj = e;
		m_SortedEdges = e.NextInSEL;
		if (m_SortedEdges != null)
		{
			m_SortedEdges.PrevInSEL = null;
		}
		obj.NextInSEL = null;
		obj.PrevInSEL = null;
		return true;
	}

	private void CopyAELToSEL()
	{
		for (ClipperTEdge clipperTEdge = (m_SortedEdges = m_ActiveEdges); clipperTEdge != null; clipperTEdge = clipperTEdge.NextInAEL)
		{
			clipperTEdge.PrevInSEL = clipperTEdge.PrevInAEL;
			clipperTEdge.NextInSEL = clipperTEdge.NextInAEL;
		}
	}

	private void SwapPositionsInSEL(ClipperTEdge edge1, ClipperTEdge edge2)
	{
		if ((edge1.NextInSEL == null && edge1.PrevInSEL == null) || (edge2.NextInSEL == null && edge2.PrevInSEL == null))
		{
			return;
		}
		if (edge1.NextInSEL == edge2)
		{
			ClipperTEdge nextInSEL = edge2.NextInSEL;
			if (nextInSEL != null)
			{
				nextInSEL.PrevInSEL = edge1;
			}
			ClipperTEdge prevInSEL = edge1.PrevInSEL;
			if (prevInSEL != null)
			{
				prevInSEL.NextInSEL = edge2;
			}
			edge2.PrevInSEL = prevInSEL;
			edge2.NextInSEL = edge1;
			edge1.PrevInSEL = edge2;
			edge1.NextInSEL = nextInSEL;
		}
		else if (edge2.NextInSEL == edge1)
		{
			ClipperTEdge nextInSEL2 = edge1.NextInSEL;
			if (nextInSEL2 != null)
			{
				nextInSEL2.PrevInSEL = edge2;
			}
			ClipperTEdge prevInSEL2 = edge2.PrevInSEL;
			if (prevInSEL2 != null)
			{
				prevInSEL2.NextInSEL = edge1;
			}
			edge1.PrevInSEL = prevInSEL2;
			edge1.NextInSEL = edge2;
			edge2.PrevInSEL = edge1;
			edge2.NextInSEL = nextInSEL2;
		}
		else
		{
			ClipperTEdge nextInSEL3 = edge1.NextInSEL;
			ClipperTEdge prevInSEL3 = edge1.PrevInSEL;
			edge1.NextInSEL = edge2.NextInSEL;
			if (edge1.NextInSEL != null)
			{
				edge1.NextInSEL.PrevInSEL = edge1;
			}
			edge1.PrevInSEL = edge2.PrevInSEL;
			if (edge1.PrevInSEL != null)
			{
				edge1.PrevInSEL.NextInSEL = edge1;
			}
			edge2.NextInSEL = nextInSEL3;
			if (edge2.NextInSEL != null)
			{
				edge2.NextInSEL.PrevInSEL = edge2;
			}
			edge2.PrevInSEL = prevInSEL3;
			if (edge2.PrevInSEL != null)
			{
				edge2.PrevInSEL.NextInSEL = edge2;
			}
		}
		if (edge1.PrevInSEL == null)
		{
			m_SortedEdges = edge1;
		}
		else if (edge2.PrevInSEL == null)
		{
			m_SortedEdges = edge2;
		}
	}

	private void AddLocalMaxPoly(ClipperTEdge e1, ClipperTEdge e2, ClipperIntPoint pt)
	{
		AddOutPt(e1, pt);
		if (e2.WindDelta == 0)
		{
			AddOutPt(e2, pt);
		}
		if (e1.OutIdx == e2.OutIdx)
		{
			e1.OutIdx = -1;
			e2.OutIdx = -1;
		}
		else if (e1.OutIdx < e2.OutIdx)
		{
			AppendPolygon(e1, e2);
		}
		else
		{
			AppendPolygon(e2, e1);
		}
	}

	private ClipperOutPt AddLocalMinPoly(ClipperTEdge e1, ClipperTEdge e2, ClipperIntPoint pt)
	{
		ClipperOutPt clipperOutPt;
		ClipperTEdge clipperTEdge;
		ClipperTEdge clipperTEdge2;
		if (ClipperBase.IsHorizontal(e2) || e1.Dx > e2.Dx)
		{
			clipperOutPt = AddOutPt(e1, pt);
			e2.OutIdx = e1.OutIdx;
			e1.Side = ClipperEdgeSide.Left;
			e2.Side = ClipperEdgeSide.Right;
			clipperTEdge = e1;
			clipperTEdge2 = ((clipperTEdge.PrevInAEL != e2) ? clipperTEdge.PrevInAEL : e2.PrevInAEL);
		}
		else
		{
			clipperOutPt = AddOutPt(e2, pt);
			e1.OutIdx = e2.OutIdx;
			e1.Side = ClipperEdgeSide.Right;
			e2.Side = ClipperEdgeSide.Left;
			clipperTEdge = e2;
			clipperTEdge2 = ((clipperTEdge.PrevInAEL != e1) ? clipperTEdge.PrevInAEL : e1.PrevInAEL);
		}
		if (clipperTEdge2 != null && clipperTEdge2.OutIdx >= 0 && clipperTEdge2.Top.Y < pt.Y && clipperTEdge.Top.Y < pt.Y)
		{
			long num = TopX(clipperTEdge2, pt.Y);
			long num2 = TopX(clipperTEdge, pt.Y);
			if (num == num2 && clipperTEdge.WindDelta != 0 && clipperTEdge2.WindDelta != 0 && ClipperBase.SlopesEqual(new ClipperIntPoint(num, pt.Y), clipperTEdge2.Top, new ClipperIntPoint(num2, pt.Y), clipperTEdge.Top, m_UseFullRange))
			{
				ClipperOutPt op = AddOutPt(clipperTEdge2, pt);
				AddJoin(clipperOutPt, op, clipperTEdge.Top);
			}
		}
		return clipperOutPt;
	}

	private ClipperOutPt AddOutPt(ClipperTEdge e, ClipperIntPoint pt)
	{
		if (e.OutIdx < 0)
		{
			ClipperOutRec clipperOutRec = CreateOutRec();
			clipperOutRec.IsOpen = e.WindDelta == 0;
			ClipperOutPt clipperOutPt = (clipperOutRec.Pts = new ClipperOutPt());
			clipperOutPt.Index = clipperOutRec.Idx;
			clipperOutPt.Pt = pt;
			clipperOutPt.Next = clipperOutPt;
			clipperOutPt.Prev = clipperOutPt;
			if (!clipperOutRec.IsOpen)
			{
				SetHoleState(e, clipperOutRec);
			}
			e.OutIdx = clipperOutRec.Idx;
			return clipperOutPt;
		}
		ClipperOutRec clipperOutRec2 = m_PolyOuts[e.OutIdx];
		ClipperOutPt pts = clipperOutRec2.Pts;
		bool flag = e.Side == ClipperEdgeSide.Left;
		if (flag && pt == pts.Pt)
		{
			return pts;
		}
		if (!flag && pt == pts.Prev.Pt)
		{
			return pts.Prev;
		}
		ClipperOutPt clipperOutPt2 = new ClipperOutPt
		{
			Index = clipperOutRec2.Idx,
			Pt = pt,
			Next = pts,
			Prev = pts.Prev
		};
		clipperOutPt2.Prev.Next = clipperOutPt2;
		pts.Prev = clipperOutPt2;
		if (flag)
		{
			clipperOutRec2.Pts = clipperOutPt2;
		}
		return clipperOutPt2;
	}

	private ClipperOutPt GetLastOutPt(ClipperTEdge e)
	{
		ClipperOutRec clipperOutRec = m_PolyOuts[e.OutIdx];
		if (e.Side == ClipperEdgeSide.Left)
		{
			return clipperOutRec.Pts;
		}
		return clipperOutRec.Pts.Prev;
	}

	internal void SwapPoints(ref ClipperIntPoint pt1, ref ClipperIntPoint pt2)
	{
		ClipperIntPoint clipperIntPoint = new ClipperIntPoint(pt1);
		pt1 = pt2;
		pt2 = clipperIntPoint;
	}

	private bool HorzSegmentsOverlap(long seg1a, long seg1b, long seg2a, long seg2b)
	{
		if (seg1a > seg1b)
		{
			Swap(ref seg1a, ref seg1b);
		}
		if (seg2a > seg2b)
		{
			Swap(ref seg2a, ref seg2b);
		}
		if (seg1a < seg2b)
		{
			return seg2a < seg1b;
		}
		return false;
	}

	private void SetHoleState(ClipperTEdge e, ClipperOutRec outRec)
	{
		ClipperTEdge prevInAEL = e.PrevInAEL;
		ClipperTEdge clipperTEdge = null;
		while (prevInAEL != null)
		{
			if (prevInAEL.OutIdx >= 0 && prevInAEL.WindDelta != 0)
			{
				if (clipperTEdge == null)
				{
					clipperTEdge = prevInAEL;
				}
				else if (clipperTEdge.OutIdx == prevInAEL.OutIdx)
				{
					clipperTEdge = null;
				}
			}
			prevInAEL = prevInAEL.PrevInAEL;
		}
		if (clipperTEdge == null)
		{
			outRec.FirstLeft = null;
			outRec.IsHole = false;
		}
		else
		{
			outRec.FirstLeft = m_PolyOuts[clipperTEdge.OutIdx];
			outRec.IsHole = !outRec.FirstLeft.IsHole;
		}
	}

	private double GetDx(ClipperIntPoint pt1, ClipperIntPoint pt2)
	{
		if (pt1.Y == pt2.Y)
		{
			return -3.4E+38;
		}
		return (double)(pt2.X - pt1.X) / (double)(pt2.Y - pt1.Y);
	}

	private bool FirstIsBottomPt(ClipperOutPt btmPt1, ClipperOutPt btmPt2)
	{
		ClipperOutPt prev = btmPt1.Prev;
		while (prev.Pt == btmPt1.Pt && prev != btmPt1)
		{
			prev = prev.Prev;
		}
		double num = Math.Abs(GetDx(btmPt1.Pt, prev.Pt));
		prev = btmPt1.Next;
		while (prev.Pt == btmPt1.Pt && prev != btmPt1)
		{
			prev = prev.Next;
		}
		double num2 = Math.Abs(GetDx(btmPt1.Pt, prev.Pt));
		prev = btmPt2.Prev;
		while (prev.Pt == btmPt2.Pt && prev != btmPt2)
		{
			prev = prev.Prev;
		}
		double num3 = Math.Abs(GetDx(btmPt2.Pt, prev.Pt));
		prev = btmPt2.Next;
		while (prev.Pt == btmPt2.Pt && prev != btmPt2)
		{
			prev = prev.Next;
		}
		double num4 = Math.Abs(GetDx(btmPt2.Pt, prev.Pt));
		if (Math.Max(num, num2) == Math.Max(num3, num4) && Math.Min(num, num2) == Math.Min(num3, num4))
		{
			return Area(btmPt1) > 0.0;
		}
		if (!(num >= num3) || !(num >= num4))
		{
			if (num2 >= num3)
			{
				return num2 >= num4;
			}
			return false;
		}
		return true;
	}

	private ClipperOutPt GetBottomPt(ClipperOutPt pp)
	{
		ClipperOutPt clipperOutPt = null;
		ClipperOutPt next;
		for (next = pp.Next; next != pp; next = next.Next)
		{
			if (next.Pt.Y > pp.Pt.Y)
			{
				pp = next;
				clipperOutPt = null;
			}
			else if (next.Pt.Y == pp.Pt.Y && next.Pt.X <= pp.Pt.X)
			{
				if (next.Pt.X < pp.Pt.X)
				{
					clipperOutPt = null;
					pp = next;
				}
				else if (next.Next != pp && next.Prev != pp)
				{
					clipperOutPt = next;
				}
			}
		}
		if (clipperOutPt != null)
		{
			while (clipperOutPt != next)
			{
				if (!FirstIsBottomPt(next, clipperOutPt))
				{
					pp = clipperOutPt;
				}
				clipperOutPt = clipperOutPt.Next;
				while (clipperOutPt.Pt != pp.Pt)
				{
					clipperOutPt = clipperOutPt.Next;
				}
			}
		}
		return pp;
	}

	private ClipperOutRec GetLowermostRec(ClipperOutRec outRec1, ClipperOutRec outRec2)
	{
		if (outRec1.BottomPt == null)
		{
			outRec1.BottomPt = GetBottomPt(outRec1.Pts);
		}
		if (outRec2.BottomPt == null)
		{
			outRec2.BottomPt = GetBottomPt(outRec2.Pts);
		}
		ClipperOutPt bottomPt = outRec1.BottomPt;
		ClipperOutPt bottomPt2 = outRec2.BottomPt;
		if (bottomPt.Pt.Y > bottomPt2.Pt.Y)
		{
			return outRec1;
		}
		if (bottomPt.Pt.Y < bottomPt2.Pt.Y)
		{
			return outRec2;
		}
		if (bottomPt.Pt.X < bottomPt2.Pt.X)
		{
			return outRec1;
		}
		if (bottomPt.Pt.X > bottomPt2.Pt.X)
		{
			return outRec2;
		}
		if (bottomPt.Next == bottomPt)
		{
			return outRec2;
		}
		if (bottomPt2.Next == bottomPt2)
		{
			return outRec1;
		}
		if (FirstIsBottomPt(bottomPt, bottomPt2))
		{
			return outRec1;
		}
		return outRec2;
	}

	private bool OutRec1RightOfOutRec2(ClipperOutRec outRec1, ClipperOutRec outRec2)
	{
		do
		{
			outRec1 = outRec1.FirstLeft;
			if (outRec1 == outRec2)
			{
				return true;
			}
		}
		while (outRec1 != null);
		return false;
	}

	private ClipperOutRec GetOutRec(int idx)
	{
		ClipperOutRec clipperOutRec;
		for (clipperOutRec = m_PolyOuts[idx]; clipperOutRec != m_PolyOuts[clipperOutRec.Idx]; clipperOutRec = m_PolyOuts[clipperOutRec.Idx])
		{
		}
		return clipperOutRec;
	}

	private void AppendPolygon(ClipperTEdge e1, ClipperTEdge e2)
	{
		ClipperOutRec clipperOutRec = m_PolyOuts[e1.OutIdx];
		ClipperOutRec clipperOutRec2 = m_PolyOuts[e2.OutIdx];
		ClipperOutRec clipperOutRec3 = (OutRec1RightOfOutRec2(clipperOutRec, clipperOutRec2) ? clipperOutRec2 : ((!OutRec1RightOfOutRec2(clipperOutRec2, clipperOutRec)) ? GetLowermostRec(clipperOutRec, clipperOutRec2) : clipperOutRec));
		ClipperOutPt pts = clipperOutRec.Pts;
		ClipperOutPt prev = pts.Prev;
		ClipperOutPt pts2 = clipperOutRec2.Pts;
		ClipperOutPt prev2 = pts2.Prev;
		if (e1.Side == ClipperEdgeSide.Left)
		{
			if (e2.Side == ClipperEdgeSide.Left)
			{
				ReversePolyPtLinks(pts2);
				pts2.Next = pts;
				pts.Prev = pts2;
				prev.Next = prev2;
				prev2.Prev = prev;
				clipperOutRec.Pts = prev2;
			}
			else
			{
				prev2.Next = pts;
				pts.Prev = prev2;
				pts2.Prev = prev;
				prev.Next = pts2;
				clipperOutRec.Pts = pts2;
			}
		}
		else if (e2.Side == ClipperEdgeSide.Right)
		{
			ReversePolyPtLinks(pts2);
			prev.Next = prev2;
			prev2.Prev = prev;
			pts2.Next = pts;
			pts.Prev = pts2;
		}
		else
		{
			prev.Next = pts2;
			pts2.Prev = prev;
			pts.Prev = prev2;
			prev2.Next = pts;
		}
		clipperOutRec.BottomPt = null;
		if (clipperOutRec3 == clipperOutRec2)
		{
			if (clipperOutRec2.FirstLeft != clipperOutRec)
			{
				clipperOutRec.FirstLeft = clipperOutRec2.FirstLeft;
			}
			clipperOutRec.IsHole = clipperOutRec2.IsHole;
		}
		clipperOutRec2.Pts = null;
		clipperOutRec2.BottomPt = null;
		clipperOutRec2.FirstLeft = clipperOutRec;
		int outIdx = e1.OutIdx;
		int outIdx2 = e2.OutIdx;
		e1.OutIdx = -1;
		e2.OutIdx = -1;
		for (ClipperTEdge clipperTEdge = m_ActiveEdges; clipperTEdge != null; clipperTEdge = clipperTEdge.NextInAEL)
		{
			if (clipperTEdge.OutIdx == outIdx2)
			{
				clipperTEdge.OutIdx = outIdx;
				clipperTEdge.Side = e1.Side;
				break;
			}
		}
		clipperOutRec2.Idx = clipperOutRec.Idx;
	}

	private void ReversePolyPtLinks(ClipperOutPt pp)
	{
		if (pp != null)
		{
			ClipperOutPt clipperOutPt = pp;
			do
			{
				ClipperOutPt next = clipperOutPt.Next;
				clipperOutPt.Next = clipperOutPt.Prev;
				clipperOutPt.Prev = next;
				clipperOutPt = next;
			}
			while (clipperOutPt != pp);
		}
	}

	private static void SwapSides(ClipperTEdge edge1, ClipperTEdge edge2)
	{
		ClipperEdgeSide side = edge1.Side;
		edge1.Side = edge2.Side;
		edge2.Side = side;
	}

	private static void SwapPolyIndexes(ClipperTEdge edge1, ClipperTEdge edge2)
	{
		int outIdx = edge1.OutIdx;
		edge1.OutIdx = edge2.OutIdx;
		edge2.OutIdx = outIdx;
	}

	private void IntersectEdges(ClipperTEdge e1, ClipperTEdge e2, ClipperIntPoint pt)
	{
		bool flag = e1.OutIdx >= 0;
		bool flag2 = e2.OutIdx >= 0;
		if (e1.WindDelta == 0 || e2.WindDelta == 0)
		{
			if (e1.WindDelta == 0 && e2.WindDelta == 0)
			{
				return;
			}
			if (e1.PolyTyp == e2.PolyTyp && e1.WindDelta != e2.WindDelta && m_ClipType == ClipperClipType.Union)
			{
				if (e1.WindDelta == 0)
				{
					if (flag2)
					{
						AddOutPt(e1, pt);
						if (flag)
						{
							e1.OutIdx = -1;
						}
					}
				}
				else if (flag)
				{
					AddOutPt(e2, pt);
					if (flag2)
					{
						e2.OutIdx = -1;
					}
				}
			}
			else
			{
				if (e1.PolyTyp == e2.PolyTyp)
				{
					return;
				}
				if (e1.WindDelta == 0 && Math.Abs(e2.WindCnt) == 1 && (m_ClipType != ClipperClipType.Union || e2.WindCnt2 == 0))
				{
					AddOutPt(e1, pt);
					if (flag)
					{
						e1.OutIdx = -1;
					}
				}
				else if (e2.WindDelta == 0 && Math.Abs(e1.WindCnt) == 1 && (m_ClipType != ClipperClipType.Union || e1.WindCnt2 == 0))
				{
					AddOutPt(e2, pt);
					if (flag2)
					{
						e2.OutIdx = -1;
					}
				}
			}
			return;
		}
		if (e1.PolyTyp == e2.PolyTyp)
		{
			if (IsEvenOddFillType(e1))
			{
				int windCnt = e1.WindCnt;
				e1.WindCnt = e2.WindCnt;
				e2.WindCnt = windCnt;
			}
			else
			{
				if (e1.WindCnt + e2.WindDelta == 0)
				{
					e1.WindCnt = -e1.WindCnt;
				}
				else
				{
					e1.WindCnt += e2.WindDelta;
				}
				if (e2.WindCnt - e1.WindDelta == 0)
				{
					e2.WindCnt = -e2.WindCnt;
				}
				else
				{
					e2.WindCnt -= e1.WindDelta;
				}
			}
		}
		else
		{
			if (!IsEvenOddFillType(e2))
			{
				e1.WindCnt2 += e2.WindDelta;
			}
			else
			{
				e1.WindCnt2 = ((e1.WindCnt2 == 0) ? 1 : 0);
			}
			if (!IsEvenOddFillType(e1))
			{
				e2.WindCnt2 -= e1.WindDelta;
			}
			else
			{
				e2.WindCnt2 = ((e2.WindCnt2 == 0) ? 1 : 0);
			}
		}
		if (e1.PolyTyp == ClipperPolyType.Subject)
		{
			_ = m_SubjFillType;
			_ = m_ClipFillType;
		}
		else
		{
			_ = m_ClipFillType;
			_ = m_SubjFillType;
		}
		if (e2.PolyTyp == ClipperPolyType.Subject)
		{
			_ = m_SubjFillType;
			_ = m_ClipFillType;
		}
		else
		{
			_ = m_ClipFillType;
			_ = m_SubjFillType;
		}
		int num = Math.Abs(e1.WindCnt);
		int num2 = Math.Abs(e2.WindCnt);
		if (flag && flag2)
		{
			if ((num != 0 && num != 1) || (num2 != 0 && num2 != 1) || (e1.PolyTyp != e2.PolyTyp && m_ClipType != ClipperClipType.Xor))
			{
				AddLocalMaxPoly(e1, e2, pt);
				return;
			}
			AddOutPt(e1, pt);
			AddOutPt(e2, pt);
			SwapSides(e1, e2);
			SwapPolyIndexes(e1, e2);
		}
		else if (flag)
		{
			if (num2 == 0 || num2 == 1)
			{
				AddOutPt(e1, pt);
				SwapSides(e1, e2);
				SwapPolyIndexes(e1, e2);
			}
		}
		else if (flag2)
		{
			if (num == 0 || num == 1)
			{
				AddOutPt(e2, pt);
				SwapSides(e1, e2);
				SwapPolyIndexes(e1, e2);
			}
		}
		else
		{
			if ((num != 0 && num != 1) || (num2 != 0 && num2 != 1))
			{
				return;
			}
			long num3 = Math.Abs(e1.WindCnt2);
			long num4 = Math.Abs(e2.WindCnt2);
			if (e1.PolyTyp != e2.PolyTyp)
			{
				AddLocalMinPoly(e1, e2, pt);
			}
			else if (num == 1 && num2 == 1)
			{
				switch (m_ClipType)
				{
				case ClipperClipType.Intersection:
					if (num3 > 0 && num4 > 0)
					{
						AddLocalMinPoly(e1, e2, pt);
					}
					break;
				case ClipperClipType.Union:
					if (num3 <= 0 && num4 <= 0)
					{
						AddLocalMinPoly(e1, e2, pt);
					}
					break;
				case ClipperClipType.Difference:
					if ((e1.PolyTyp == ClipperPolyType.Clip && num3 > 0 && num4 > 0) || (e1.PolyTyp == ClipperPolyType.Subject && num3 <= 0 && num4 <= 0))
					{
						AddLocalMinPoly(e1, e2, pt);
					}
					break;
				case ClipperClipType.Xor:
					AddLocalMinPoly(e1, e2, pt);
					break;
				}
			}
			else
			{
				SwapSides(e1, e2);
			}
		}
	}

	private void ProcessHorizontals()
	{
		ClipperTEdge e;
		while (PopEdgeFromSEL(out e))
		{
			ProcessHorizontal(e);
		}
	}

	private void GetHorzDirection(ClipperTEdge HorzEdge, out ClipperDirection Dir, out long Left, out long Right)
	{
		if (HorzEdge.Bot.X < HorzEdge.Top.X)
		{
			Left = HorzEdge.Bot.X;
			Right = HorzEdge.Top.X;
			Dir = ClipperDirection.LeftToRight;
		}
		else
		{
			Left = HorzEdge.Top.X;
			Right = HorzEdge.Bot.X;
			Dir = ClipperDirection.RightToLeft;
		}
	}

	private void ProcessHorizontal(ClipperTEdge horzEdge)
	{
		bool flag = horzEdge.WindDelta == 0;
		GetHorzDirection(horzEdge, out var Dir, out var Left, out var Right);
		ClipperTEdge clipperTEdge = horzEdge;
		ClipperTEdge clipperTEdge2 = null;
		while (clipperTEdge.NextInLML != null && ClipperBase.IsHorizontal(clipperTEdge.NextInLML))
		{
			clipperTEdge = clipperTEdge.NextInLML;
		}
		if (clipperTEdge.NextInLML == null)
		{
			clipperTEdge2 = GetMaximaPair(clipperTEdge);
		}
		ClipperMaxima clipperMaxima = m_Maxima;
		if (clipperMaxima != null)
		{
			if (Dir == ClipperDirection.LeftToRight)
			{
				while (clipperMaxima != null && clipperMaxima.X <= horzEdge.Bot.X)
				{
					clipperMaxima = clipperMaxima.Next;
				}
				if (clipperMaxima != null && clipperMaxima.X >= clipperTEdge.Top.X)
				{
					clipperMaxima = null;
				}
			}
			else
			{
				while (clipperMaxima.Next != null && clipperMaxima.Next.X < horzEdge.Bot.X)
				{
					clipperMaxima = clipperMaxima.Next;
				}
				if (clipperMaxima.X <= clipperTEdge.Top.X)
				{
					clipperMaxima = null;
				}
			}
		}
		ClipperOutPt clipperOutPt = null;
		while (true)
		{
			bool flag2 = horzEdge == clipperTEdge;
			ClipperTEdge clipperTEdge3 = GetNextInAEL(horzEdge, Dir);
			while (clipperTEdge3 != null)
			{
				if (clipperMaxima != null)
				{
					if (Dir == ClipperDirection.LeftToRight)
					{
						while (clipperMaxima != null && clipperMaxima.X < clipperTEdge3.Curr.X)
						{
							if (horzEdge.OutIdx >= 0 && !flag)
							{
								AddOutPt(horzEdge, new ClipperIntPoint(clipperMaxima.X, horzEdge.Bot.Y));
							}
							clipperMaxima = clipperMaxima.Next;
						}
					}
					else
					{
						while (clipperMaxima != null && clipperMaxima.X > clipperTEdge3.Curr.X)
						{
							if (horzEdge.OutIdx >= 0 && !flag)
							{
								AddOutPt(horzEdge, new ClipperIntPoint(clipperMaxima.X, horzEdge.Bot.Y));
							}
							clipperMaxima = clipperMaxima.Previous;
						}
					}
				}
				if ((Dir == ClipperDirection.LeftToRight && clipperTEdge3.Curr.X > Right) || (Dir == ClipperDirection.RightToLeft && clipperTEdge3.Curr.X < Left) || (clipperTEdge3.Curr.X == horzEdge.Top.X && horzEdge.NextInLML != null && clipperTEdge3.Dx < horzEdge.NextInLML.Dx))
				{
					break;
				}
				if (horzEdge.OutIdx >= 0 && !flag)
				{
					clipperOutPt = AddOutPt(horzEdge, clipperTEdge3.Curr);
					for (ClipperTEdge clipperTEdge4 = m_SortedEdges; clipperTEdge4 != null; clipperTEdge4 = clipperTEdge4.NextInSEL)
					{
						if (clipperTEdge4.OutIdx >= 0 && HorzSegmentsOverlap(horzEdge.Bot.X, horzEdge.Top.X, clipperTEdge4.Bot.X, clipperTEdge4.Top.X))
						{
							ClipperOutPt lastOutPt = GetLastOutPt(clipperTEdge4);
							AddJoin(lastOutPt, clipperOutPt, clipperTEdge4.Top);
						}
					}
					AddGhostJoin(clipperOutPt, horzEdge.Bot);
				}
				if (clipperTEdge3 == clipperTEdge2 && flag2)
				{
					if (horzEdge.OutIdx >= 0)
					{
						AddLocalMaxPoly(horzEdge, clipperTEdge2, horzEdge.Top);
					}
					DeleteFromAEL(horzEdge);
					DeleteFromAEL(clipperTEdge2);
					return;
				}
				if (Dir == ClipperDirection.LeftToRight)
				{
					IntersectEdges(pt: new ClipperIntPoint(clipperTEdge3.Curr.X, horzEdge.Curr.Y), e1: horzEdge, e2: clipperTEdge3);
				}
				else
				{
					IntersectEdges(pt: new ClipperIntPoint(clipperTEdge3.Curr.X, horzEdge.Curr.Y), e1: clipperTEdge3, e2: horzEdge);
				}
				ClipperTEdge nextInAEL = GetNextInAEL(clipperTEdge3, Dir);
				SwapPositionsInAEL(horzEdge, clipperTEdge3);
				clipperTEdge3 = nextInAEL;
			}
			if (horzEdge.NextInLML == null || !ClipperBase.IsHorizontal(horzEdge.NextInLML))
			{
				break;
			}
			UpdateEdgeIntoAEL(ref horzEdge);
			if (horzEdge.OutIdx >= 0)
			{
				AddOutPt(horzEdge, horzEdge.Bot);
			}
			GetHorzDirection(horzEdge, out Dir, out Left, out Right);
		}
		if (horzEdge.OutIdx >= 0 && clipperOutPt == null)
		{
			clipperOutPt = GetLastOutPt(horzEdge);
			for (ClipperTEdge clipperTEdge5 = m_SortedEdges; clipperTEdge5 != null; clipperTEdge5 = clipperTEdge5.NextInSEL)
			{
				if (clipperTEdge5.OutIdx >= 0 && HorzSegmentsOverlap(horzEdge.Bot.X, horzEdge.Top.X, clipperTEdge5.Bot.X, clipperTEdge5.Top.X))
				{
					ClipperOutPt lastOutPt2 = GetLastOutPt(clipperTEdge5);
					AddJoin(lastOutPt2, clipperOutPt, clipperTEdge5.Top);
				}
			}
			AddGhostJoin(clipperOutPt, horzEdge.Top);
		}
		if (horzEdge.NextInLML != null)
		{
			if (horzEdge.OutIdx >= 0)
			{
				clipperOutPt = AddOutPt(horzEdge, horzEdge.Top);
				UpdateEdgeIntoAEL(ref horzEdge);
				if (horzEdge.WindDelta != 0)
				{
					ClipperTEdge prevInAEL = horzEdge.PrevInAEL;
					ClipperTEdge nextInAEL2 = horzEdge.NextInAEL;
					if (prevInAEL != null && prevInAEL.Curr.X == horzEdge.Bot.X && prevInAEL.Curr.Y == horzEdge.Bot.Y && prevInAEL.WindDelta != 0 && prevInAEL.OutIdx >= 0 && prevInAEL.Curr.Y > prevInAEL.Top.Y && ClipperBase.SlopesEqual(horzEdge, prevInAEL, m_UseFullRange))
					{
						ClipperOutPt op = AddOutPt(prevInAEL, horzEdge.Bot);
						AddJoin(clipperOutPt, op, horzEdge.Top);
					}
					else if (nextInAEL2 != null && nextInAEL2.Curr.X == horzEdge.Bot.X && nextInAEL2.Curr.Y == horzEdge.Bot.Y && nextInAEL2.WindDelta != 0 && nextInAEL2.OutIdx >= 0 && nextInAEL2.Curr.Y > nextInAEL2.Top.Y && ClipperBase.SlopesEqual(horzEdge, nextInAEL2, m_UseFullRange))
					{
						ClipperOutPt op2 = AddOutPt(nextInAEL2, horzEdge.Bot);
						AddJoin(clipperOutPt, op2, horzEdge.Top);
					}
				}
			}
			else
			{
				UpdateEdgeIntoAEL(ref horzEdge);
			}
		}
		else
		{
			if (horzEdge.OutIdx >= 0)
			{
				AddOutPt(horzEdge, horzEdge.Top);
			}
			DeleteFromAEL(horzEdge);
		}
	}

	private ClipperTEdge GetNextInAEL(ClipperTEdge e, ClipperDirection Direction)
	{
		if (Direction != ClipperDirection.LeftToRight)
		{
			return e.PrevInAEL;
		}
		return e.NextInAEL;
	}

	private bool IsMaxima(ClipperTEdge e, double Y)
	{
		if (e != null && (double)e.Top.Y == Y)
		{
			return e.NextInLML == null;
		}
		return false;
	}

	private bool IsIntermediate(ClipperTEdge e, double Y)
	{
		if ((double)e.Top.Y == Y)
		{
			return e.NextInLML != null;
		}
		return false;
	}

	internal ClipperTEdge GetMaximaPair(ClipperTEdge e)
	{
		if (e.Next.Top == e.Top && e.Next.NextInLML == null)
		{
			return e.Next;
		}
		if (e.Prev.Top == e.Top && e.Prev.NextInLML == null)
		{
			return e.Prev;
		}
		return null;
	}

	internal ClipperTEdge GetMaximaPairEx(ClipperTEdge e)
	{
		ClipperTEdge maximaPair = GetMaximaPair(e);
		if (maximaPair == null || maximaPair.OutIdx == -2 || (maximaPair.NextInAEL == maximaPair.PrevInAEL && !ClipperBase.IsHorizontal(maximaPair)))
		{
			return null;
		}
		return maximaPair;
	}

	private bool ProcessIntersections(long topY)
	{
		if (m_ActiveEdges == null)
		{
			return true;
		}
		try
		{
			BuildIntersectList(topY);
			if (m_IntersectList.Count == 0)
			{
				return true;
			}
			if (m_IntersectList.Count != 1 && !FixupIntersectionOrder())
			{
				return false;
			}
			ProcessIntersectList();
		}
		catch
		{
			m_SortedEdges = null;
			m_IntersectList.Clear();
			throw new ClipperException("ProcessIntersections error");
		}
		m_SortedEdges = null;
		return true;
	}

	private void BuildIntersectList(long topY)
	{
		if (m_ActiveEdges == null)
		{
			return;
		}
		for (ClipperTEdge clipperTEdge = (m_SortedEdges = m_ActiveEdges); clipperTEdge != null; clipperTEdge = clipperTEdge.NextInAEL)
		{
			clipperTEdge.PrevInSEL = clipperTEdge.PrevInAEL;
			clipperTEdge.NextInSEL = clipperTEdge.NextInAEL;
			clipperTEdge.Curr.X = TopX(clipperTEdge, topY);
		}
		bool flag = true;
		while (flag && m_SortedEdges != null)
		{
			flag = false;
			ClipperTEdge clipperTEdge = m_SortedEdges;
			while (clipperTEdge.NextInSEL != null)
			{
				ClipperTEdge nextInSEL = clipperTEdge.NextInSEL;
				if (clipperTEdge.Curr.X > nextInSEL.Curr.X)
				{
					IntersectPoint(clipperTEdge, nextInSEL, out var ip);
					if (ip.Y < topY)
					{
						ip = new ClipperIntPoint(TopX(clipperTEdge, topY), topY);
					}
					ClipperIntersectNode item = new ClipperIntersectNode
					{
						Edge1 = clipperTEdge,
						Edge2 = nextInSEL,
						Pt = ip
					};
					m_IntersectList.Add(item);
					SwapPositionsInSEL(clipperTEdge, nextInSEL);
					flag = true;
				}
				else
				{
					clipperTEdge = nextInSEL;
				}
			}
			if (clipperTEdge.PrevInSEL == null)
			{
				break;
			}
			clipperTEdge.PrevInSEL.NextInSEL = null;
		}
		m_SortedEdges = null;
	}

	private bool EdgesAdjacent(ClipperIntersectNode inode)
	{
		if (inode.Edge1.NextInSEL != inode.Edge2)
		{
			return inode.Edge1.PrevInSEL == inode.Edge2;
		}
		return true;
	}

	private bool FixupIntersectionOrder()
	{
		m_IntersectList.Sort(m_IntersectNodeComparer);
		CopyAELToSEL();
		int count = m_IntersectList.Count;
		for (int i = 0; i < count; i++)
		{
			if (!EdgesAdjacent(m_IntersectList[i]))
			{
				int j;
				for (j = i + 1; j < count && !EdgesAdjacent(m_IntersectList[j]); j++)
				{
				}
				if (j == count)
				{
					return false;
				}
				ClipperIntersectNode value = m_IntersectList[i];
				m_IntersectList[i] = m_IntersectList[j];
				m_IntersectList[j] = value;
			}
			SwapPositionsInSEL(m_IntersectList[i].Edge1, m_IntersectList[i].Edge2);
		}
		return true;
	}

	private void ProcessIntersectList()
	{
		for (int i = 0; i < m_IntersectList.Count; i++)
		{
			ClipperIntersectNode clipperIntersectNode = m_IntersectList[i];
			IntersectEdges(clipperIntersectNode.Edge1, clipperIntersectNode.Edge2, clipperIntersectNode.Pt);
			SwapPositionsInAEL(clipperIntersectNode.Edge1, clipperIntersectNode.Edge2);
		}
		m_IntersectList.Clear();
	}

	internal static long Round(double value)
	{
		if (!(value < 0.0))
		{
			return (long)(value + 0.5);
		}
		return (long)(value - 0.5);
	}

	private static long TopX(ClipperTEdge edge, long currentY)
	{
		if (currentY == edge.Top.Y)
		{
			return edge.Top.X;
		}
		return edge.Bot.X + Round(edge.Dx * (double)(currentY - edge.Bot.Y));
	}

	private void IntersectPoint(ClipperTEdge edge1, ClipperTEdge edge2, out ClipperIntPoint ip)
	{
		ip = default(ClipperIntPoint);
		if (edge1.Dx == edge2.Dx)
		{
			ip.Y = edge1.Curr.Y;
			ip.X = TopX(edge1, ip.Y);
			return;
		}
		if (edge1.Delta.X == 0L)
		{
			ip.X = edge1.Bot.X;
			if (ClipperBase.IsHorizontal(edge2))
			{
				ip.Y = edge2.Bot.Y;
			}
			else
			{
				double num = (double)edge2.Bot.Y - (double)edge2.Bot.X / edge2.Dx;
				ip.Y = Round((double)ip.X / edge2.Dx + num);
			}
		}
		else if (edge2.Delta.X == 0L)
		{
			ip.X = edge2.Bot.X;
			if (ClipperBase.IsHorizontal(edge1))
			{
				ip.Y = edge1.Bot.Y;
			}
			else
			{
				double num2 = (double)edge1.Bot.Y - (double)edge1.Bot.X / edge1.Dx;
				ip.Y = Round((double)ip.X / edge1.Dx + num2);
			}
		}
		else
		{
			double num2 = (double)edge1.Bot.X - (double)edge1.Bot.Y * edge1.Dx;
			double num = (double)edge2.Bot.X - (double)edge2.Bot.Y * edge2.Dx;
			double num3 = (num - num2) / (edge1.Dx - edge2.Dx);
			ip.Y = Round(num3);
			if (Math.Abs(edge1.Dx) < Math.Abs(edge2.Dx))
			{
				ip.X = Round(edge1.Dx * num3 + num2);
			}
			else
			{
				ip.X = Round(edge2.Dx * num3 + num);
			}
		}
		if (ip.Y < edge1.Top.Y || ip.Y < edge2.Top.Y)
		{
			if (edge1.Top.Y > edge2.Top.Y)
			{
				ip.Y = edge1.Top.Y;
			}
			else
			{
				ip.Y = edge2.Top.Y;
			}
			if (Math.Abs(edge1.Dx) < Math.Abs(edge2.Dx))
			{
				ip.X = TopX(edge1, ip.Y);
			}
			else
			{
				ip.X = TopX(edge2, ip.Y);
			}
		}
		if (ip.Y > edge1.Curr.Y)
		{
			ip.Y = edge1.Curr.Y;
			if (Math.Abs(edge1.Dx) > Math.Abs(edge2.Dx))
			{
				ip.X = TopX(edge2, ip.Y);
			}
			else
			{
				ip.X = TopX(edge1, ip.Y);
			}
		}
	}

	private void ProcessEdgesAtTopOfScanbeam(long topY)
	{
		ClipperTEdge e = m_ActiveEdges;
		while (e != null)
		{
			bool flag = IsMaxima(e, topY);
			if (flag)
			{
				ClipperTEdge maximaPairEx = GetMaximaPairEx(e);
				flag = maximaPairEx == null || !ClipperBase.IsHorizontal(maximaPairEx);
			}
			if (flag)
			{
				if (StrictlySimple)
				{
					InsertMaxima(e.Top.X);
				}
				ClipperTEdge prevInAEL = e.PrevInAEL;
				DoMaxima(e);
				e = ((prevInAEL != null) ? prevInAEL.NextInAEL : m_ActiveEdges);
				continue;
			}
			if (IsIntermediate(e, topY) && ClipperBase.IsHorizontal(e.NextInLML))
			{
				UpdateEdgeIntoAEL(ref e);
				if (e.OutIdx >= 0)
				{
					AddOutPt(e, e.Bot);
				}
				AddEdgeToSEL(e);
			}
			else
			{
				e.Curr.X = TopX(e, topY);
				e.Curr.Y = topY;
			}
			if (StrictlySimple)
			{
				ClipperTEdge prevInAEL2 = e.PrevInAEL;
				if (e.OutIdx >= 0 && e.WindDelta != 0 && prevInAEL2 != null && prevInAEL2.OutIdx >= 0 && prevInAEL2.Curr.X == e.Curr.X && prevInAEL2.WindDelta != 0)
				{
					ClipperIntPoint clipperIntPoint = new ClipperIntPoint(e.Curr);
					ClipperOutPt op = AddOutPt(prevInAEL2, clipperIntPoint);
					ClipperOutPt op2 = AddOutPt(e, clipperIntPoint);
					AddJoin(op, op2, clipperIntPoint);
				}
			}
			e = e.NextInAEL;
		}
		ProcessHorizontals();
		m_Maxima = null;
		for (e = m_ActiveEdges; e != null; e = e.NextInAEL)
		{
			if (IsIntermediate(e, topY))
			{
				ClipperOutPt clipperOutPt = null;
				if (e.OutIdx >= 0)
				{
					clipperOutPt = AddOutPt(e, e.Top);
				}
				UpdateEdgeIntoAEL(ref e);
				ClipperTEdge prevInAEL3 = e.PrevInAEL;
				ClipperTEdge nextInAEL = e.NextInAEL;
				if (prevInAEL3 != null && prevInAEL3.Curr.X == e.Bot.X && prevInAEL3.Curr.Y == e.Bot.Y && clipperOutPt != null && prevInAEL3.OutIdx >= 0 && prevInAEL3.Curr.Y > prevInAEL3.Top.Y && ClipperBase.SlopesEqual(e.Curr, e.Top, prevInAEL3.Curr, prevInAEL3.Top, m_UseFullRange) && e.WindDelta != 0 && prevInAEL3.WindDelta != 0)
				{
					ClipperOutPt op3 = AddOutPt(prevInAEL3, e.Bot);
					AddJoin(clipperOutPt, op3, e.Top);
				}
				else if (nextInAEL != null && nextInAEL.Curr.X == e.Bot.X && nextInAEL.Curr.Y == e.Bot.Y && clipperOutPt != null && nextInAEL.OutIdx >= 0 && nextInAEL.Curr.Y > nextInAEL.Top.Y && ClipperBase.SlopesEqual(e.Curr, e.Top, nextInAEL.Curr, nextInAEL.Top, m_UseFullRange) && e.WindDelta != 0 && nextInAEL.WindDelta != 0)
				{
					ClipperOutPt op4 = AddOutPt(nextInAEL, e.Bot);
					AddJoin(clipperOutPt, op4, e.Top);
				}
			}
		}
	}

	private void DoMaxima(ClipperTEdge e)
	{
		ClipperTEdge maximaPairEx = GetMaximaPairEx(e);
		if (maximaPairEx == null)
		{
			if (e.OutIdx >= 0)
			{
				AddOutPt(e, e.Top);
			}
			DeleteFromAEL(e);
			return;
		}
		ClipperTEdge nextInAEL = e.NextInAEL;
		while (nextInAEL != null && nextInAEL != maximaPairEx)
		{
			IntersectEdges(e, nextInAEL, e.Top);
			SwapPositionsInAEL(e, nextInAEL);
			nextInAEL = e.NextInAEL;
		}
		if (e.OutIdx == -1 && maximaPairEx.OutIdx == -1)
		{
			DeleteFromAEL(e);
			DeleteFromAEL(maximaPairEx);
			return;
		}
		if (e.OutIdx >= 0 && maximaPairEx.OutIdx >= 0)
		{
			if (e.OutIdx >= 0)
			{
				AddLocalMaxPoly(e, maximaPairEx, e.Top);
			}
			DeleteFromAEL(e);
			DeleteFromAEL(maximaPairEx);
			return;
		}
		if (e.WindDelta == 0)
		{
			if (e.OutIdx >= 0)
			{
				AddOutPt(e, e.Top);
				e.OutIdx = -1;
			}
			DeleteFromAEL(e);
			if (maximaPairEx.OutIdx >= 0)
			{
				AddOutPt(maximaPairEx, e.Top);
				maximaPairEx.OutIdx = -1;
			}
			DeleteFromAEL(maximaPairEx);
			return;
		}
		throw new ClipperException("DoMaxima error");
	}

	public static void ReversePaths(List<List<ClipperIntPoint>> polys)
	{
		foreach (List<ClipperIntPoint> poly in polys)
		{
			poly.Reverse();
		}
	}

	public static bool Orientation(List<ClipperIntPoint> poly)
	{
		return Area(poly) >= 0.0;
	}

	private int PointCount(ClipperOutPt pts)
	{
		if (pts == null)
		{
			return 0;
		}
		int num = 0;
		ClipperOutPt clipperOutPt = pts;
		do
		{
			num++;
			clipperOutPt = clipperOutPt.Next;
		}
		while (clipperOutPt != pts);
		return num;
	}

	private void BuildResult(List<List<ClipperIntPoint>> polyg)
	{
		polyg.Clear();
		polyg.Capacity = m_PolyOuts.Count;
		for (int i = 0; i < m_PolyOuts.Count; i++)
		{
			ClipperOutRec clipperOutRec = m_PolyOuts[i];
			if (clipperOutRec.Pts == null)
			{
				continue;
			}
			ClipperOutPt prev = clipperOutRec.Pts.Prev;
			int num = PointCount(prev);
			if (num >= 2)
			{
				List<ClipperIntPoint> list = new List<ClipperIntPoint>(num);
				for (int j = 0; j < num; j++)
				{
					list.Add(prev.Pt);
					prev = prev.Prev;
				}
				polyg.Add(list);
			}
		}
	}

	private void BuildResult2(ClipperPolyTree polytree)
	{
		polytree.Clear();
		polytree.AllPolys.Capacity = m_PolyOuts.Count;
		for (int i = 0; i < m_PolyOuts.Count; i++)
		{
			ClipperOutRec clipperOutRec = m_PolyOuts[i];
			int num = PointCount(clipperOutRec.Pts);
			if ((!clipperOutRec.IsOpen || num >= 2) && (clipperOutRec.IsOpen || num >= 3))
			{
				FixHoleLinkage(clipperOutRec);
				ClipperPolyNode clipperPolyNode = new ClipperPolyNode();
				polytree.AllPolys.Add(clipperPolyNode);
				clipperOutRec.PolyNode = clipperPolyNode;
				clipperPolyNode.Polygon.Capacity = num;
				ClipperOutPt prev = clipperOutRec.Pts.Prev;
				for (int j = 0; j < num; j++)
				{
					clipperPolyNode.Polygon.Add(prev.Pt);
					prev = prev.Prev;
				}
			}
		}
		polytree.Children.Capacity = m_PolyOuts.Count;
		for (int k = 0; k < m_PolyOuts.Count; k++)
		{
			ClipperOutRec clipperOutRec2 = m_PolyOuts[k];
			if (clipperOutRec2.PolyNode != null)
			{
				if (clipperOutRec2.IsOpen)
				{
					clipperOutRec2.PolyNode.IsOpen = true;
					polytree.AddChild(clipperOutRec2.PolyNode);
				}
				else if (clipperOutRec2.FirstLeft != null && clipperOutRec2.FirstLeft.PolyNode != null)
				{
					clipperOutRec2.FirstLeft.PolyNode.AddChild(clipperOutRec2.PolyNode);
				}
				else
				{
					polytree.AddChild(clipperOutRec2.PolyNode);
				}
			}
		}
	}

	private void FixupOutPolyline(ClipperOutRec outrec)
	{
		ClipperOutPt clipperOutPt = outrec.Pts;
		ClipperOutPt prev = clipperOutPt.Prev;
		while (clipperOutPt != prev)
		{
			clipperOutPt = clipperOutPt.Next;
			if (clipperOutPt.Pt == clipperOutPt.Prev.Pt)
			{
				if (clipperOutPt == prev)
				{
					prev = clipperOutPt.Prev;
				}
				ClipperOutPt prev2 = clipperOutPt.Prev;
				prev2.Next = clipperOutPt.Next;
				clipperOutPt.Next.Prev = prev2;
				clipperOutPt = prev2;
			}
		}
		if (clipperOutPt == clipperOutPt.Prev)
		{
			outrec.Pts = null;
		}
	}

	private void FixupOutPolygon(ClipperOutRec outRec)
	{
		ClipperOutPt clipperOutPt = null;
		outRec.BottomPt = null;
		ClipperOutPt clipperOutPt2 = outRec.Pts;
		bool flag = base.PreserveCollinear || StrictlySimple;
		while (true)
		{
			if (clipperOutPt2.Prev == clipperOutPt2 || clipperOutPt2.Prev == clipperOutPt2.Next)
			{
				outRec.Pts = null;
				return;
			}
			if (clipperOutPt2.Pt == clipperOutPt2.Next.Pt || clipperOutPt2.Pt == clipperOutPt2.Prev.Pt || (ClipperBase.SlopesEqual(clipperOutPt2.Prev.Pt, clipperOutPt2.Pt, clipperOutPt2.Next.Pt, m_UseFullRange) && (!flag || !Pt2IsBetweenPt1AndPt3(clipperOutPt2.Prev.Pt, clipperOutPt2.Pt, clipperOutPt2.Next.Pt))))
			{
				clipperOutPt = null;
				clipperOutPt2.Prev.Next = clipperOutPt2.Next;
				clipperOutPt2.Next.Prev = clipperOutPt2.Prev;
				clipperOutPt2 = clipperOutPt2.Prev;
				continue;
			}
			if (clipperOutPt2 == clipperOutPt)
			{
				break;
			}
			if (clipperOutPt == null)
			{
				clipperOutPt = clipperOutPt2;
			}
			clipperOutPt2 = clipperOutPt2.Next;
		}
		outRec.Pts = clipperOutPt2;
	}

	private ClipperOutPt DupOutPt(ClipperOutPt outPt, bool InsertAfter)
	{
		ClipperOutPt clipperOutPt = new ClipperOutPt
		{
			Pt = outPt.Pt,
			Index = outPt.Index
		};
		if (InsertAfter)
		{
			clipperOutPt.Next = outPt.Next;
			clipperOutPt.Prev = outPt;
			outPt.Next.Prev = clipperOutPt;
			outPt.Next = clipperOutPt;
		}
		else
		{
			clipperOutPt.Prev = outPt.Prev;
			clipperOutPt.Next = outPt;
			outPt.Prev.Next = clipperOutPt;
			outPt.Prev = clipperOutPt;
		}
		return clipperOutPt;
	}

	private bool GetOverlap(long a1, long a2, long b1, long b2, out long Left, out long Right)
	{
		if (a1 < a2)
		{
			if (b1 < b2)
			{
				Left = Math.Max(a1, b1);
				Right = Math.Min(a2, b2);
			}
			else
			{
				Left = Math.Max(a1, b2);
				Right = Math.Min(a2, b1);
			}
		}
		else if (b1 < b2)
		{
			Left = Math.Max(a2, b1);
			Right = Math.Min(a1, b2);
		}
		else
		{
			Left = Math.Max(a2, b2);
			Right = Math.Min(a1, b1);
		}
		return Left < Right;
	}

	private bool JoinHorz(ClipperOutPt op1, ClipperOutPt op1b, ClipperOutPt op2, ClipperOutPt op2b, ClipperIntPoint Pt, bool DiscardLeft)
	{
		ClipperDirection clipperDirection = ((op1.Pt.X <= op1b.Pt.X) ? ClipperDirection.LeftToRight : ClipperDirection.RightToLeft);
		ClipperDirection clipperDirection2 = ((op2.Pt.X <= op2b.Pt.X) ? ClipperDirection.LeftToRight : ClipperDirection.RightToLeft);
		if (clipperDirection == clipperDirection2)
		{
			return false;
		}
		if (clipperDirection == ClipperDirection.LeftToRight)
		{
			while (op1.Next.Pt.X <= Pt.X && op1.Next.Pt.X >= op1.Pt.X && op1.Next.Pt.Y == Pt.Y)
			{
				op1 = op1.Next;
			}
			if (DiscardLeft && op1.Pt.X != Pt.X)
			{
				op1 = op1.Next;
			}
			op1b = DupOutPt(op1, !DiscardLeft);
			if (op1b.Pt != Pt)
			{
				op1 = op1b;
				op1.Pt = Pt;
				op1b = DupOutPt(op1, !DiscardLeft);
			}
		}
		else
		{
			while (op1.Next.Pt.X >= Pt.X && op1.Next.Pt.X <= op1.Pt.X && op1.Next.Pt.Y == Pt.Y)
			{
				op1 = op1.Next;
			}
			if (!DiscardLeft && op1.Pt.X != Pt.X)
			{
				op1 = op1.Next;
			}
			op1b = DupOutPt(op1, DiscardLeft);
			if (op1b.Pt != Pt)
			{
				op1 = op1b;
				op1.Pt = Pt;
				op1b = DupOutPt(op1, DiscardLeft);
			}
		}
		if (clipperDirection2 == ClipperDirection.LeftToRight)
		{
			while (op2.Next.Pt.X <= Pt.X && op2.Next.Pt.X >= op2.Pt.X && op2.Next.Pt.Y == Pt.Y)
			{
				op2 = op2.Next;
			}
			if (DiscardLeft && op2.Pt.X != Pt.X)
			{
				op2 = op2.Next;
			}
			op2b = DupOutPt(op2, !DiscardLeft);
			if (op2b.Pt != Pt)
			{
				op2 = op2b;
				op2.Pt = Pt;
				op2b = DupOutPt(op2, !DiscardLeft);
			}
		}
		else
		{
			while (op2.Next.Pt.X >= Pt.X && op2.Next.Pt.X <= op2.Pt.X && op2.Next.Pt.Y == Pt.Y)
			{
				op2 = op2.Next;
			}
			if (!DiscardLeft && op2.Pt.X != Pt.X)
			{
				op2 = op2.Next;
			}
			op2b = DupOutPt(op2, DiscardLeft);
			if (op2b.Pt != Pt)
			{
				op2 = op2b;
				op2.Pt = Pt;
				op2b = DupOutPt(op2, DiscardLeft);
			}
		}
		if (clipperDirection == ClipperDirection.LeftToRight == DiscardLeft)
		{
			op1.Prev = op2;
			op2.Next = op1;
			op1b.Next = op2b;
			op2b.Prev = op1b;
		}
		else
		{
			op1.Next = op2;
			op2.Prev = op1;
			op1b.Prev = op2b;
			op2b.Next = op1b;
		}
		return true;
	}

	private bool JoinPoints(ClipperJoin j, ClipperOutRec outRec1, ClipperOutRec outRec2)
	{
		ClipperOutPt clipperOutPt = j.OutPt1;
		ClipperOutPt clipperOutPt2 = j.OutPt2;
		bool flag = j.OutPt1.Pt.Y == j.OffPt.Y;
		ClipperOutPt next;
		ClipperOutPt next2;
		if (flag && j.OffPt == j.OutPt1.Pt && j.OffPt == j.OutPt2.Pt)
		{
			if (outRec1 != outRec2)
			{
				return false;
			}
			next = j.OutPt1.Next;
			while (next != clipperOutPt && next.Pt == j.OffPt)
			{
				next = next.Next;
			}
			bool flag2 = next.Pt.Y > j.OffPt.Y;
			next2 = j.OutPt2.Next;
			while (next2 != clipperOutPt2 && next2.Pt == j.OffPt)
			{
				next2 = next2.Next;
			}
			bool flag3 = next2.Pt.Y > j.OffPt.Y;
			if (flag2 == flag3)
			{
				return false;
			}
			if (flag2)
			{
				next = DupOutPt(clipperOutPt, InsertAfter: false);
				next2 = DupOutPt(clipperOutPt2, InsertAfter: true);
				clipperOutPt.Prev = clipperOutPt2;
				clipperOutPt2.Next = clipperOutPt;
				next.Next = next2;
				next2.Prev = next;
				j.OutPt1 = clipperOutPt;
				j.OutPt2 = next;
				return true;
			}
			next = DupOutPt(clipperOutPt, InsertAfter: true);
			next2 = DupOutPt(clipperOutPt2, InsertAfter: false);
			clipperOutPt.Next = clipperOutPt2;
			clipperOutPt2.Prev = clipperOutPt;
			next.Prev = next2;
			next2.Next = next;
			j.OutPt1 = clipperOutPt;
			j.OutPt2 = next;
			return true;
		}
		if (flag)
		{
			next = clipperOutPt;
			while (clipperOutPt.Prev.Pt.Y == clipperOutPt.Pt.Y && clipperOutPt.Prev != next && clipperOutPt.Prev != clipperOutPt2)
			{
				clipperOutPt = clipperOutPt.Prev;
			}
			while (next.Next.Pt.Y == next.Pt.Y && next.Next != clipperOutPt && next.Next != clipperOutPt2)
			{
				next = next.Next;
			}
			if (next.Next == clipperOutPt || next.Next == clipperOutPt2)
			{
				return false;
			}
			next2 = clipperOutPt2;
			while (clipperOutPt2.Prev.Pt.Y == clipperOutPt2.Pt.Y && clipperOutPt2.Prev != next2 && clipperOutPt2.Prev != next)
			{
				clipperOutPt2 = clipperOutPt2.Prev;
			}
			while (next2.Next.Pt.Y == next2.Pt.Y && next2.Next != clipperOutPt2 && next2.Next != clipperOutPt)
			{
				next2 = next2.Next;
			}
			if (next2.Next == clipperOutPt2 || next2.Next == clipperOutPt)
			{
				return false;
			}
			if (!GetOverlap(clipperOutPt.Pt.X, next.Pt.X, clipperOutPt2.Pt.X, next2.Pt.X, out var Left, out var Right))
			{
				return false;
			}
			ClipperIntPoint pt;
			bool discardLeft;
			if (clipperOutPt.Pt.X >= Left && clipperOutPt.Pt.X <= Right)
			{
				pt = clipperOutPt.Pt;
				discardLeft = clipperOutPt.Pt.X > next.Pt.X;
			}
			else if (clipperOutPt2.Pt.X >= Left && clipperOutPt2.Pt.X <= Right)
			{
				pt = clipperOutPt2.Pt;
				discardLeft = clipperOutPt2.Pt.X > next2.Pt.X;
			}
			else if (next.Pt.X >= Left && next.Pt.X <= Right)
			{
				pt = next.Pt;
				discardLeft = next.Pt.X > clipperOutPt.Pt.X;
			}
			else
			{
				pt = next2.Pt;
				discardLeft = next2.Pt.X > clipperOutPt2.Pt.X;
			}
			j.OutPt1 = clipperOutPt;
			j.OutPt2 = clipperOutPt2;
			return JoinHorz(clipperOutPt, next, clipperOutPt2, next2, pt, discardLeft);
		}
		next = clipperOutPt.Next;
		while (next.Pt == clipperOutPt.Pt && next != clipperOutPt)
		{
			next = next.Next;
		}
		bool flag4 = next.Pt.Y > clipperOutPt.Pt.Y || !ClipperBase.SlopesEqual(clipperOutPt.Pt, next.Pt, j.OffPt, m_UseFullRange);
		if (flag4)
		{
			next = clipperOutPt.Prev;
			while (next.Pt == clipperOutPt.Pt && next != clipperOutPt)
			{
				next = next.Prev;
			}
			if (next.Pt.Y > clipperOutPt.Pt.Y || !ClipperBase.SlopesEqual(clipperOutPt.Pt, next.Pt, j.OffPt, m_UseFullRange))
			{
				return false;
			}
		}
		next2 = clipperOutPt2.Next;
		while (next2.Pt == clipperOutPt2.Pt && next2 != clipperOutPt2)
		{
			next2 = next2.Next;
		}
		bool flag5 = next2.Pt.Y > clipperOutPt2.Pt.Y || !ClipperBase.SlopesEqual(clipperOutPt2.Pt, next2.Pt, j.OffPt, m_UseFullRange);
		if (flag5)
		{
			next2 = clipperOutPt2.Prev;
			while (next2.Pt == clipperOutPt2.Pt && next2 != clipperOutPt2)
			{
				next2 = next2.Prev;
			}
			if (next2.Pt.Y > clipperOutPt2.Pt.Y || !ClipperBase.SlopesEqual(clipperOutPt2.Pt, next2.Pt, j.OffPt, m_UseFullRange))
			{
				return false;
			}
		}
		if (next == clipperOutPt || next2 == clipperOutPt2 || next == next2 || (outRec1 == outRec2 && flag4 == flag5))
		{
			return false;
		}
		if (flag4)
		{
			next = DupOutPt(clipperOutPt, InsertAfter: false);
			next2 = DupOutPt(clipperOutPt2, InsertAfter: true);
			clipperOutPt.Prev = clipperOutPt2;
			clipperOutPt2.Next = clipperOutPt;
			next.Next = next2;
			next2.Prev = next;
			j.OutPt1 = clipperOutPt;
			j.OutPt2 = next;
			return true;
		}
		next = DupOutPt(clipperOutPt, InsertAfter: true);
		next2 = DupOutPt(clipperOutPt2, InsertAfter: false);
		clipperOutPt.Next = clipperOutPt2;
		clipperOutPt2.Prev = clipperOutPt;
		next.Prev = next2;
		next2.Next = next;
		j.OutPt1 = clipperOutPt;
		j.OutPt2 = next;
		return true;
	}

	public static int PointInPolygon(ClipperIntPoint pt, List<ClipperIntPoint> path)
	{
		int num = 0;
		int count = path.Count;
		if (count < 3)
		{
			return 0;
		}
		ClipperIntPoint clipperIntPoint = path[0];
		for (int i = 1; i <= count; i++)
		{
			ClipperIntPoint clipperIntPoint2 = ((i == count) ? path[0] : path[i]);
			if (clipperIntPoint2.Y == pt.Y && (clipperIntPoint2.X == pt.X || (clipperIntPoint.Y == pt.Y && clipperIntPoint2.X > pt.X == clipperIntPoint.X < pt.X)))
			{
				return -1;
			}
			if (clipperIntPoint.Y < pt.Y != clipperIntPoint2.Y < pt.Y)
			{
				if (clipperIntPoint.X >= pt.X)
				{
					if (clipperIntPoint2.X > pt.X)
					{
						num = 1 - num;
					}
					else
					{
						double num2 = (double)(clipperIntPoint.X - pt.X) * (double)(clipperIntPoint2.Y - pt.Y) - (double)(clipperIntPoint2.X - pt.X) * (double)(clipperIntPoint.Y - pt.Y);
						if (num2 == 0.0)
						{
							return -1;
						}
						if (num2 > 0.0 == clipperIntPoint2.Y > clipperIntPoint.Y)
						{
							num = 1 - num;
						}
					}
				}
				else if (clipperIntPoint2.X > pt.X)
				{
					double num3 = (double)(clipperIntPoint.X - pt.X) * (double)(clipperIntPoint2.Y - pt.Y) - (double)(clipperIntPoint2.X - pt.X) * (double)(clipperIntPoint.Y - pt.Y);
					if (num3 == 0.0)
					{
						return -1;
					}
					if (num3 > 0.0 == clipperIntPoint2.Y > clipperIntPoint.Y)
					{
						num = 1 - num;
					}
				}
			}
			clipperIntPoint = clipperIntPoint2;
		}
		return num;
	}

	private static int PointInPolygon(ClipperIntPoint pt, ClipperOutPt op)
	{
		int num = 0;
		ClipperOutPt clipperOutPt = op;
		long x = pt.X;
		long y = pt.Y;
		long num2 = op.Pt.X;
		long num3 = op.Pt.Y;
		do
		{
			op = op.Next;
			long x2 = op.Pt.X;
			long y2 = op.Pt.Y;
			if (y2 == y && (x2 == x || (num3 == y && x2 > x == num2 < x)))
			{
				return -1;
			}
			if (num3 < y != y2 < y)
			{
				if (num2 >= x)
				{
					if (x2 > x)
					{
						num = 1 - num;
					}
					else
					{
						double num4 = (double)(num2 - x) * (double)(y2 - y) - (double)(x2 - x) * (double)(num3 - y);
						if (num4 == 0.0)
						{
							return -1;
						}
						if (num4 > 0.0 == y2 > num3)
						{
							num = 1 - num;
						}
					}
				}
				else if (x2 > x)
				{
					double num5 = (double)(num2 - x) * (double)(y2 - y) - (double)(x2 - x) * (double)(num3 - y);
					if (num5 == 0.0)
					{
						return -1;
					}
					if (num5 > 0.0 == y2 > num3)
					{
						num = 1 - num;
					}
				}
			}
			num2 = x2;
			num3 = y2;
		}
		while (clipperOutPt != op);
		return num;
	}

	private static bool Poly2ContainsPoly1(ClipperOutPt outPt1, ClipperOutPt outPt2)
	{
		ClipperOutPt clipperOutPt = outPt1;
		do
		{
			int num = PointInPolygon(clipperOutPt.Pt, outPt2);
			if (num >= 0)
			{
				return num > 0;
			}
			clipperOutPt = clipperOutPt.Next;
		}
		while (clipperOutPt != outPt1);
		return true;
	}

	private void FixupFirstLefts1(ClipperOutRec OldOutRec, ClipperOutRec NewOutRec)
	{
		foreach (ClipperOutRec polyOut in m_PolyOuts)
		{
			ClipperOutRec clipperOutRec = ParseFirstLeft(polyOut.FirstLeft);
			if (polyOut.Pts != null && clipperOutRec == OldOutRec && Poly2ContainsPoly1(polyOut.Pts, NewOutRec.Pts))
			{
				polyOut.FirstLeft = NewOutRec;
			}
		}
	}

	private void FixupFirstLefts2(ClipperOutRec innerOutRec, ClipperOutRec outerOutRec)
	{
		ClipperOutRec firstLeft = outerOutRec.FirstLeft;
		foreach (ClipperOutRec polyOut in m_PolyOuts)
		{
			if (polyOut.Pts == null || polyOut == outerOutRec || polyOut == innerOutRec)
			{
				continue;
			}
			ClipperOutRec clipperOutRec = ParseFirstLeft(polyOut.FirstLeft);
			if (clipperOutRec == firstLeft || clipperOutRec == innerOutRec || clipperOutRec == outerOutRec)
			{
				if (Poly2ContainsPoly1(polyOut.Pts, innerOutRec.Pts))
				{
					polyOut.FirstLeft = innerOutRec;
				}
				else if (Poly2ContainsPoly1(polyOut.Pts, outerOutRec.Pts))
				{
					polyOut.FirstLeft = outerOutRec;
				}
				else if (polyOut.FirstLeft == innerOutRec || polyOut.FirstLeft == outerOutRec)
				{
					polyOut.FirstLeft = firstLeft;
				}
			}
		}
	}

	private void FixupFirstLefts3(ClipperOutRec OldOutRec, ClipperOutRec NewOutRec)
	{
		foreach (ClipperOutRec polyOut in m_PolyOuts)
		{
			ClipperOutRec clipperOutRec = ParseFirstLeft(polyOut.FirstLeft);
			if (polyOut.Pts != null && clipperOutRec == OldOutRec)
			{
				polyOut.FirstLeft = NewOutRec;
			}
		}
	}

	private static ClipperOutRec ParseFirstLeft(ClipperOutRec FirstLeft)
	{
		while (FirstLeft != null && FirstLeft.Pts == null)
		{
			FirstLeft = FirstLeft.FirstLeft;
		}
		return FirstLeft;
	}

	private void JoinCommonEdges()
	{
		for (int i = 0; i < m_Joins.Count; i++)
		{
			ClipperJoin clipperJoin = m_Joins[i];
			ClipperOutRec outRec = GetOutRec(clipperJoin.OutPt1.Index);
			ClipperOutRec outRec2 = GetOutRec(clipperJoin.OutPt2.Index);
			if (outRec.Pts == null || outRec2.Pts == null || outRec.IsOpen || outRec2.IsOpen)
			{
				continue;
			}
			ClipperOutRec clipperOutRec = ((outRec == outRec2) ? outRec : (OutRec1RightOfOutRec2(outRec, outRec2) ? outRec2 : ((!OutRec1RightOfOutRec2(outRec2, outRec)) ? GetLowermostRec(outRec, outRec2) : outRec)));
			if (!JoinPoints(clipperJoin, outRec, outRec2))
			{
				continue;
			}
			if (outRec == outRec2)
			{
				outRec.Pts = clipperJoin.OutPt1;
				outRec.BottomPt = null;
				outRec2 = CreateOutRec();
				outRec2.Pts = clipperJoin.OutPt2;
				UpdateOutPtIdxs(outRec2);
				if (Poly2ContainsPoly1(outRec2.Pts, outRec.Pts))
				{
					outRec2.IsHole = !outRec.IsHole;
					outRec2.FirstLeft = outRec;
					if (m_UsingPolyTree)
					{
						FixupFirstLefts2(outRec2, outRec);
					}
					if ((outRec2.IsHole ^ ReverseSolution) == Area(outRec2) > 0.0)
					{
						ReversePolyPtLinks(outRec2.Pts);
					}
				}
				else if (Poly2ContainsPoly1(outRec.Pts, outRec2.Pts))
				{
					outRec2.IsHole = outRec.IsHole;
					outRec.IsHole = !outRec2.IsHole;
					outRec2.FirstLeft = outRec.FirstLeft;
					outRec.FirstLeft = outRec2;
					if (m_UsingPolyTree)
					{
						FixupFirstLefts2(outRec, outRec2);
					}
					if ((outRec.IsHole ^ ReverseSolution) == Area(outRec) > 0.0)
					{
						ReversePolyPtLinks(outRec.Pts);
					}
				}
				else
				{
					outRec2.IsHole = outRec.IsHole;
					outRec2.FirstLeft = outRec.FirstLeft;
					if (m_UsingPolyTree)
					{
						FixupFirstLefts1(outRec, outRec2);
					}
				}
			}
			else
			{
				outRec2.Pts = null;
				outRec2.BottomPt = null;
				outRec2.Idx = outRec.Idx;
				outRec.IsHole = clipperOutRec.IsHole;
				if (clipperOutRec == outRec2)
				{
					outRec.FirstLeft = outRec2.FirstLeft;
				}
				outRec2.FirstLeft = outRec;
				if (m_UsingPolyTree)
				{
					FixupFirstLefts3(outRec2, outRec);
				}
			}
		}
	}

	private void UpdateOutPtIdxs(ClipperOutRec outrec)
	{
		ClipperOutPt clipperOutPt = outrec.Pts;
		do
		{
			clipperOutPt.Index = outrec.Idx;
			clipperOutPt = clipperOutPt.Prev;
		}
		while (clipperOutPt != outrec.Pts);
	}

	private void DoSimplePolygons()
	{
		int num = 0;
		while (num < m_PolyOuts.Count)
		{
			ClipperOutRec clipperOutRec = m_PolyOuts[num++];
			ClipperOutPt clipperOutPt = clipperOutRec.Pts;
			if (clipperOutPt == null || clipperOutRec.IsOpen)
			{
				continue;
			}
			do
			{
				for (ClipperOutPt clipperOutPt2 = clipperOutPt.Next; clipperOutPt2 != clipperOutRec.Pts; clipperOutPt2 = clipperOutPt2.Next)
				{
					if (clipperOutPt.Pt == clipperOutPt2.Pt && clipperOutPt2.Next != clipperOutPt && clipperOutPt2.Prev != clipperOutPt)
					{
						ClipperOutPt prev = clipperOutPt.Prev;
						(clipperOutPt.Prev = clipperOutPt2.Prev).Next = clipperOutPt;
						clipperOutPt2.Prev = prev;
						prev.Next = clipperOutPt2;
						clipperOutRec.Pts = clipperOutPt;
						ClipperOutRec clipperOutRec2 = CreateOutRec();
						clipperOutRec2.Pts = clipperOutPt2;
						UpdateOutPtIdxs(clipperOutRec2);
						if (Poly2ContainsPoly1(clipperOutRec2.Pts, clipperOutRec.Pts))
						{
							clipperOutRec2.IsHole = !clipperOutRec.IsHole;
							clipperOutRec2.FirstLeft = clipperOutRec;
							if (m_UsingPolyTree)
							{
								FixupFirstLefts2(clipperOutRec2, clipperOutRec);
							}
						}
						else if (Poly2ContainsPoly1(clipperOutRec.Pts, clipperOutRec2.Pts))
						{
							clipperOutRec2.IsHole = clipperOutRec.IsHole;
							clipperOutRec.IsHole = !clipperOutRec2.IsHole;
							clipperOutRec2.FirstLeft = clipperOutRec.FirstLeft;
							clipperOutRec.FirstLeft = clipperOutRec2;
							if (m_UsingPolyTree)
							{
								FixupFirstLefts2(clipperOutRec, clipperOutRec2);
							}
						}
						else
						{
							clipperOutRec2.IsHole = clipperOutRec.IsHole;
							clipperOutRec2.FirstLeft = clipperOutRec.FirstLeft;
							if (m_UsingPolyTree)
							{
								FixupFirstLefts1(clipperOutRec, clipperOutRec2);
							}
						}
						clipperOutPt2 = clipperOutPt;
					}
				}
				clipperOutPt = clipperOutPt.Next;
			}
			while (clipperOutPt != clipperOutRec.Pts);
		}
	}

	public static double Area(List<ClipperIntPoint> poly)
	{
		int count = poly.Count;
		if (count < 3)
		{
			return 0.0;
		}
		double num = 0.0;
		int i = 0;
		int index = count - 1;
		for (; i < count; i++)
		{
			num += ((double)poly[index].X + (double)poly[i].X) * ((double)poly[index].Y - (double)poly[i].Y);
			index = i;
		}
		return (0.0 - num) * 0.5;
	}

	internal double Area(ClipperOutRec outRec)
	{
		return Area(outRec.Pts);
	}

	internal double Area(ClipperOutPt op)
	{
		ClipperOutPt clipperOutPt = op;
		if (op == null)
		{
			return 0.0;
		}
		double num = 0.0;
		do
		{
			num += (double)(op.Prev.Pt.X + op.Pt.X) * (double)(op.Prev.Pt.Y - op.Pt.Y);
			op = op.Next;
		}
		while (op != clipperOutPt);
		return num * 0.5;
	}

	public static List<List<ClipperIntPoint>> SimplifyPolygon(List<ClipperIntPoint> poly, ClipperPolyFillType fillType = ClipperPolyFillType.EvenOdd)
	{
		List<List<ClipperIntPoint>> list = new List<List<ClipperIntPoint>>();
		Clipper clipper = new Clipper();
		clipper.StrictlySimple = true;
		clipper.AddPath(poly, ClipperPolyType.Subject, Closed: true);
		clipper.Execute(ClipperClipType.Union, list, fillType, fillType);
		return list;
	}

	public static List<List<ClipperIntPoint>> SimplifyPolygons(List<List<ClipperIntPoint>> polys, ClipperPolyFillType fillType = ClipperPolyFillType.EvenOdd)
	{
		List<List<ClipperIntPoint>> list = new List<List<ClipperIntPoint>>();
		Clipper clipper = new Clipper();
		clipper.StrictlySimple = true;
		clipper.AddPaths(polys, ClipperPolyType.Subject, closed: true);
		clipper.Execute(ClipperClipType.Union, list, fillType, fillType);
		return list;
	}

	private static double DistanceFromLineSqrd(ClipperIntPoint pt, ClipperIntPoint ln1, ClipperIntPoint ln2)
	{
		double num = ln1.Y - ln2.Y;
		double num2 = ln2.X - ln1.X;
		double num3 = num * (double)ln1.X + num2 * (double)ln1.Y;
		num3 = num * (double)pt.X + num2 * (double)pt.Y - num3;
		return num3 * num3 / (num * num + num2 * num2);
	}

	private static bool SlopesNearCollinear(ClipperIntPoint pt1, ClipperIntPoint pt2, ClipperIntPoint pt3, double distSqrd)
	{
		if (Math.Abs(pt1.X - pt2.X) > Math.Abs(pt1.Y - pt2.Y))
		{
			if (pt1.X > pt2.X == pt1.X < pt3.X)
			{
				return DistanceFromLineSqrd(pt1, pt2, pt3) < distSqrd;
			}
			if (pt2.X > pt1.X == pt2.X < pt3.X)
			{
				return DistanceFromLineSqrd(pt2, pt1, pt3) < distSqrd;
			}
			return DistanceFromLineSqrd(pt3, pt1, pt2) < distSqrd;
		}
		if (pt1.Y > pt2.Y == pt1.Y < pt3.Y)
		{
			return DistanceFromLineSqrd(pt1, pt2, pt3) < distSqrd;
		}
		if (pt2.Y > pt1.Y == pt2.Y < pt3.Y)
		{
			return DistanceFromLineSqrd(pt2, pt1, pt3) < distSqrd;
		}
		return DistanceFromLineSqrd(pt3, pt1, pt2) < distSqrd;
	}

	private static bool PointsAreClose(ClipperIntPoint pt1, ClipperIntPoint pt2, double distSqrd)
	{
		double num = (double)pt1.X - (double)pt2.X;
		double num2 = (double)pt1.Y - (double)pt2.Y;
		return num * num + num2 * num2 <= distSqrd;
	}

	private static ClipperOutPt ExcludeOp(ClipperOutPt op)
	{
		ClipperOutPt prev = op.Prev;
		prev.Next = op.Next;
		op.Next.Prev = prev;
		prev.Index = 0;
		return prev;
	}

	public static List<ClipperIntPoint> CleanPolygon(List<ClipperIntPoint> path, double distance = 1.415)
	{
		int num = path.Count;
		if (num == 0)
		{
			return new List<ClipperIntPoint>();
		}
		ClipperOutPt[] array = new ClipperOutPt[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = new ClipperOutPt();
		}
		for (int j = 0; j < num; j++)
		{
			array[j].Pt = path[j];
			array[j].Next = array[(j + 1) % num];
			array[j].Next.Prev = array[j];
			array[j].Index = 0;
		}
		double distSqrd = distance * distance;
		ClipperOutPt clipperOutPt = array[0];
		while (clipperOutPt.Index == 0 && clipperOutPt.Next != clipperOutPt.Prev)
		{
			if (PointsAreClose(clipperOutPt.Pt, clipperOutPt.Prev.Pt, distSqrd))
			{
				clipperOutPt = ExcludeOp(clipperOutPt);
				num--;
			}
			else if (PointsAreClose(clipperOutPt.Prev.Pt, clipperOutPt.Next.Pt, distSqrd))
			{
				ExcludeOp(clipperOutPt.Next);
				clipperOutPt = ExcludeOp(clipperOutPt);
				num -= 2;
			}
			else if (SlopesNearCollinear(clipperOutPt.Prev.Pt, clipperOutPt.Pt, clipperOutPt.Next.Pt, distSqrd))
			{
				clipperOutPt = ExcludeOp(clipperOutPt);
				num--;
			}
			else
			{
				clipperOutPt.Index = 1;
				clipperOutPt = clipperOutPt.Next;
			}
		}
		if (num < 3)
		{
			num = 0;
		}
		List<ClipperIntPoint> list = new List<ClipperIntPoint>(num);
		for (int k = 0; k < num; k++)
		{
			list.Add(clipperOutPt.Pt);
			clipperOutPt = clipperOutPt.Next;
		}
		array = null;
		return list;
	}

	public static List<List<ClipperIntPoint>> CleanPolygons(List<List<ClipperIntPoint>> polys, double distance = 1.415)
	{
		List<List<ClipperIntPoint>> list = new List<List<ClipperIntPoint>>(polys.Count);
		for (int i = 0; i < polys.Count; i++)
		{
			list.Add(CleanPolygon(polys[i], distance));
		}
		return list;
	}

	internal static List<List<ClipperIntPoint>> Minkowski(List<ClipperIntPoint> pattern, List<ClipperIntPoint> path, bool IsSum, bool IsClosed)
	{
		int num = (IsClosed ? 1 : 0);
		int count = pattern.Count;
		int count2 = path.Count;
		List<List<ClipperIntPoint>> list = new List<List<ClipperIntPoint>>(count2);
		if (IsSum)
		{
			for (int i = 0; i < count2; i++)
			{
				List<ClipperIntPoint> list2 = new List<ClipperIntPoint>(count);
				foreach (ClipperIntPoint item in pattern)
				{
					list2.Add(new ClipperIntPoint(path[i].X + item.X, path[i].Y + item.Y));
				}
				list.Add(list2);
			}
		}
		else
		{
			for (int j = 0; j < count2; j++)
			{
				List<ClipperIntPoint> list3 = new List<ClipperIntPoint>(count);
				foreach (ClipperIntPoint item2 in pattern)
				{
					list3.Add(new ClipperIntPoint(path[j].X - item2.X, path[j].Y - item2.Y));
				}
				list.Add(list3);
			}
		}
		List<List<ClipperIntPoint>> list4 = new List<List<ClipperIntPoint>>((count2 + num) * (count + 1));
		for (int k = 0; k < count2 - 1 + num; k++)
		{
			for (int l = 0; l < count; l++)
			{
				List<ClipperIntPoint> list5 = new List<ClipperIntPoint>(4)
				{
					list[k % count2][l % count],
					list[(k + 1) % count2][l % count],
					list[(k + 1) % count2][(l + 1) % count],
					list[k % count2][(l + 1) % count]
				};
				if (!Orientation(list5))
				{
					list5.Reverse();
				}
				list4.Add(list5);
			}
		}
		return list4;
	}

	public static List<List<ClipperIntPoint>> MinkowskiSum(List<ClipperIntPoint> pattern, List<ClipperIntPoint> path, bool pathIsClosed)
	{
		List<List<ClipperIntPoint>> list = Minkowski(pattern, path, IsSum: true, pathIsClosed);
		Clipper clipper = new Clipper();
		clipper.AddPaths(list, ClipperPolyType.Subject, closed: true);
		clipper.Execute(ClipperClipType.Union, list, ClipperPolyFillType.NonZero, ClipperPolyFillType.NonZero);
		return list;
	}

	private static List<ClipperIntPoint> TranslatePath(List<ClipperIntPoint> path, ClipperIntPoint delta)
	{
		List<ClipperIntPoint> list = new List<ClipperIntPoint>(path.Count);
		for (int i = 0; i < path.Count; i++)
		{
			list.Add(new ClipperIntPoint(path[i].X + delta.X, path[i].Y + delta.Y));
		}
		return list;
	}

	public static List<List<ClipperIntPoint>> MinkowskiSum(List<ClipperIntPoint> pattern, List<List<ClipperIntPoint>> paths, bool pathIsClosed)
	{
		List<List<ClipperIntPoint>> list = new List<List<ClipperIntPoint>>();
		Clipper clipper = new Clipper();
		for (int i = 0; i < paths.Count; i++)
		{
			List<List<ClipperIntPoint>> ppg = Minkowski(pattern, paths[i], IsSum: true, pathIsClosed);
			clipper.AddPaths(ppg, ClipperPolyType.Subject, closed: true);
			if (pathIsClosed)
			{
				List<ClipperIntPoint> pg = TranslatePath(paths[i], pattern[0]);
				clipper.AddPath(pg, ClipperPolyType.Clip, Closed: true);
			}
		}
		clipper.Execute(ClipperClipType.Union, list, ClipperPolyFillType.NonZero, ClipperPolyFillType.NonZero);
		return list;
	}

	public static List<List<ClipperIntPoint>> MinkowskiDiff(List<ClipperIntPoint> poly1, List<ClipperIntPoint> poly2)
	{
		List<List<ClipperIntPoint>> list = Minkowski(poly1, poly2, IsSum: false, IsClosed: true);
		Clipper clipper = new Clipper();
		clipper.AddPaths(list, ClipperPolyType.Subject, closed: true);
		clipper.Execute(ClipperClipType.Union, list, ClipperPolyFillType.NonZero, ClipperPolyFillType.NonZero);
		return list;
	}

	public static List<List<ClipperIntPoint>> PolyTreeToPaths(ClipperPolyTree polytree)
	{
		List<List<ClipperIntPoint>> list = new List<List<ClipperIntPoint>>
		{
			Capacity = polytree.Total
		};
		AddPolyNodeToPaths(polytree, NodeType.ntAny, list);
		return list;
	}

	internal static void AddPolyNodeToPaths(ClipperPolyNode polynode, NodeType nt, List<List<ClipperIntPoint>> paths)
	{
		bool flag = true;
		switch (nt)
		{
		case NodeType.ntOpen:
			return;
		case NodeType.ntClosed:
			flag = !polynode.IsOpen;
			break;
		}
		if (polynode.Polygon.Count > 0 && flag)
		{
			paths.Add(polynode.Polygon);
		}
		foreach (ClipperPolyNode child in polynode.Children)
		{
			AddPolyNodeToPaths(child, nt, paths);
		}
	}

	public static List<List<ClipperIntPoint>> OpenPathsFromPolyTree(ClipperPolyTree polytree)
	{
		List<List<ClipperIntPoint>> list = new List<List<ClipperIntPoint>>
		{
			Capacity = polytree.ChildCount
		};
		for (int i = 0; i < polytree.ChildCount; i++)
		{
			if (polytree.Children[i].IsOpen)
			{
				list.Add(polytree.Children[i].Polygon);
			}
		}
		return list;
	}

	public static List<List<ClipperIntPoint>> ClosedPathsFromPolyTree(ClipperPolyTree polytree)
	{
		List<List<ClipperIntPoint>> list = new List<List<ClipperIntPoint>>
		{
			Capacity = polytree.Total
		};
		AddPolyNodeToPaths(polytree, NodeType.ntClosed, list);
		return list;
	}
}
