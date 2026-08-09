using System;
using System.Collections.Generic;
using ODA.Kernel.TD_BrepBuilderFiller;
using ODA.Kernel.TD_RootIntegrated;

internal sealed class _0023_003DzneMGJb_0024OxcpQ
{
	private List<OdBrEdge> _0023_003DzJC0DwAJyXkIG;

	private uint _0023_003DzecaexYThChAn;

	public static void _0023_003DzszL0IoeMVmU70Ao7AkorwJA_003D(BrepBuilderInitialData _0023_003DzelFfqwk_003D)
	{
		BrepBuilderComplexArray complexes = _0023_003DzelFfqwk_003D.complexes;
		_ = _0023_003DzelFfqwk_003D.edges;
		int num = 0;
		foreach (BrepBuilderShellsArray item in complexes)
		{
			Console.WriteLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528212) + num);
			num++;
			int num2 = 0;
			foreach (BrepBuilderInitialSurfaceArray item2 in item)
			{
				Console.WriteLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528307) + num2);
				num2++;
				int num3 = 0;
				foreach (BrepBuilderInitialSurface item3 in item2)
				{
					Console.WriteLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528358) + num3);
					num3++;
					Console.WriteLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528320) + item3.direction);
					Console.WriteLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355528436) + (item3.get_pSurf() == null));
					int num4 = 0;
					foreach (BrepBuilderInitialLoop loop in item3.loops)
					{
						Console.WriteLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526948) + num4);
						num4++;
						int num5 = 0;
						foreach (BrepBuilderInitialCoedge coedge in loop.coedges)
						{
							Console.WriteLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526965) + num5);
							num5++;
							Console.WriteLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355526912) + coedge.GetEdgeIndex());
							Console.WriteLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527022) + (coedge.GetCurve() == null));
							Console.WriteLine(_0023_003DzSy_0024KIFd4r3JhmOzv30zRImcoHkdd._0023_003Dz4A3Alm0_003D(355527032) + coedge.direction);
						}
					}
				}
			}
		}
	}

	public OdResult _0023_003Dznx0nwVk_003D(OdBrBrep _0023_003DzdD9bnvfI32yn, ref BrepBuilderInitialData _0023_003DzelFfqwk_003D)
	{
		_0023_003DzecaexYThChAn = (uint)_0023_003DzelFfqwk_003D.edges.Count;
		_0023_003DzJC0DwAJyXkIG = new List<OdBrEdge>();
		OdBrBrepComplexTraverser odBrBrepComplexTraverser = new OdBrBrepComplexTraverser();
		if (odBrBrepComplexTraverser.setBrep(_0023_003DzdD9bnvfI32yn) != OdBrErrorStatus.odbrOK)
		{
			return OdResult.eInvalidInput;
		}
		while (!odBrBrepComplexTraverser.done())
		{
			OdBrComplex _0023_003DzO0_zYfI_003D = odBrBrepComplexTraverser.getComplex();
			OdResult odResult = _0023_003DzcsazOQTDflae(ref _0023_003DzelFfqwk_003D, ref _0023_003DzO0_zYfI_003D);
			if (odResult != OdResult.eOk)
			{
				return odResult;
			}
			if (odBrBrepComplexTraverser.next() != OdBrErrorStatus.odbrOK)
			{
				return OdResult.eInvalidInput;
			}
		}
		return OdResult.eOk;
	}

	private OdResult _0023_003DzcsazOQTDflae(ref BrepBuilderInitialData _0023_003Dz7GDkdFA_003D, ref OdBrComplex _0023_003DzO0_zYfI_003D)
	{
		OdBrComplexShellTraverser odBrComplexShellTraverser = new OdBrComplexShellTraverser();
		OdBrErrorStatus odBrErrorStatus = odBrComplexShellTraverser.setComplex(_0023_003DzO0_zYfI_003D);
		if (OdBrErrorStatus.odbrUnsuitableTopology == odBrErrorStatus)
		{
			return OdResult.eOk;
		}
		if (odBrErrorStatus != OdBrErrorStatus.odbrOK)
		{
			return OdResult.eInvalidInput;
		}
		BrepBuilderShellsArray _0023_003DzhRZ_r76VcUdd = new BrepBuilderShellsArray();
		while (!odBrComplexShellTraverser.done())
		{
			OdBrShell _0023_003DzvUr4QoM_003D = odBrComplexShellTraverser.getShell();
			OdResult odResult = _0023_003DziIHtcvljF6fE(ref _0023_003Dz7GDkdFA_003D, ref _0023_003DzvUr4QoM_003D, ref _0023_003DzhRZ_r76VcUdd);
			if (odResult != OdResult.eOk)
			{
				return odResult;
			}
			if (odBrComplexShellTraverser.next() != OdBrErrorStatus.odbrOK)
			{
				return OdResult.eInvalidInput;
			}
		}
		GC.SuppressFinalize(_0023_003DzhRZ_r76VcUdd);
		_0023_003Dz7GDkdFA_003D.complexes.Add(_0023_003DzhRZ_r76VcUdd);
		return OdResult.eOk;
	}

	private OdResult _0023_003DziIHtcvljF6fE(ref BrepBuilderInitialData _0023_003Dz7GDkdFA_003D, ref OdBrShell _0023_003DzvUr4QoM_003D, ref BrepBuilderShellsArray _0023_003DzhRZ_r76VcUdd)
	{
		OdBrShellFaceTraverser odBrShellFaceTraverser = new OdBrShellFaceTraverser();
		OdBrErrorStatus odBrErrorStatus = odBrShellFaceTraverser.setShell(_0023_003DzvUr4QoM_003D);
		if (OdBrErrorStatus.odbrUnsuitableTopology == odBrErrorStatus)
		{
			return OdResult.eOk;
		}
		if (odBrErrorStatus != OdBrErrorStatus.odbrOK)
		{
			return OdResult.eInvalidInput;
		}
		BrepBuilderInitialSurfaceArray _0023_003Dz25CzjJSUnmzFeRXwMQ_003D_003D = new BrepBuilderInitialSurfaceArray();
		while (!odBrShellFaceTraverser.done())
		{
			OdBrFace _0023_003DzILwyq_00243CBdkJ = odBrShellFaceTraverser.getFace();
			int count = _0023_003Dz25CzjJSUnmzFeRXwMQ_003D_003D.Count;
			OdResult odResult = _0023_003DzgppNyPrbF_00(ref _0023_003Dz7GDkdFA_003D, ref _0023_003DzILwyq_00243CBdkJ, ref _0023_003Dz25CzjJSUnmzFeRXwMQ_003D_003D);
			if (odResult != OdResult.eOk)
			{
				return odResult;
			}
			count = _0023_003Dz25CzjJSUnmzFeRXwMQ_003D_003D.Count - count;
			if (odBrShellFaceTraverser.next() != OdBrErrorStatus.odbrOK)
			{
				return OdResult.eInvalidInput;
			}
		}
		GC.SuppressFinalize(_0023_003Dz25CzjJSUnmzFeRXwMQ_003D_003D);
		_0023_003DzhRZ_r76VcUdd.Add(_0023_003Dz25CzjJSUnmzFeRXwMQ_003D_003D);
		return OdResult.eOk;
	}

	private OdResult _0023_003DzgppNyPrbF_00(ref BrepBuilderInitialData _0023_003Dz7GDkdFA_003D, ref OdBrFace _0023_003DzILwyq_00243CBdkJ, ref BrepBuilderInitialSurfaceArray _0023_003Dz25CzjJSUnmzFeRXwMQ_003D_003D)
	{
		BrepBuilderInitialSurface _0023_003DzVWsjdJDDnN_ = new BrepBuilderInitialSurface();
		_0023_003DzVWsjdJDDnN_.set_pSurf(_0023_003DzUAGTOkJWmo8i(_0023_003DzILwyq_00243CBdkJ));
		if (_0023_003DzVWsjdJDDnN_.get_pSurf() == null)
		{
			return OdResult.eInvalidInput;
		}
		_0023_003DzVWsjdJDDnN_.direction = ((!_0023_003DzILwyq_00243CBdkJ.getOrientToSurface()) ? OdBrepBuilder_EntityDirection.kReversed : OdBrepBuilder_EntityDirection.kForward);
		OdBrFaceLoopTraverser odBrFaceLoopTraverser = new OdBrFaceLoopTraverser();
		OdBrErrorStatus odBrErrorStatus = odBrFaceLoopTraverser.setFace(_0023_003DzILwyq_00243CBdkJ);
		if (OdBrErrorStatus.odbrUnsuitableTopology == odBrErrorStatus)
		{
			GC.SuppressFinalize(_0023_003DzVWsjdJDDnN_);
			_0023_003Dz25CzjJSUnmzFeRXwMQ_003D_003D.Add(_0023_003DzVWsjdJDDnN_);
			return OdResult.eOk;
		}
		if (odBrErrorStatus != OdBrErrorStatus.odbrOK)
		{
			return OdResult.eInvalidInput;
		}
		while (!odBrFaceLoopTraverser.done())
		{
			OdBrLoop _0023_003Dzg7_002432Ro_003D = odBrFaceLoopTraverser.getLoop();
			OdResult odResult = _0023_003DzKnwpu2PoBpEJ(ref _0023_003Dz7GDkdFA_003D, ref _0023_003Dzg7_002432Ro_003D, ref _0023_003DzVWsjdJDDnN_);
			if (odResult != OdResult.eOk)
			{
				return odResult;
			}
			if (odBrFaceLoopTraverser.next() != OdBrErrorStatus.odbrOK)
			{
				return OdResult.eInvalidInput;
			}
		}
		GC.SuppressFinalize(_0023_003DzVWsjdJDDnN_);
		_0023_003Dz25CzjJSUnmzFeRXwMQ_003D_003D.Add(_0023_003DzVWsjdJDDnN_);
		return OdResult.eOk;
	}

	public static OdGeSurface _0023_003DzUAGTOkJWmo8i(OdBrFace _0023_003DzILwyq_00243CBdkJ)
	{
		OdGeSurface odGeSurface = _0023_003DzILwyq_00243CBdkJ.getSurface();
		if (odGeSurface == null)
		{
			OdGeNurbSurface odGeNurbSurface = new OdGeNurbSurface();
			if (_0023_003DzILwyq_00243CBdkJ.getSurfaceAsNurb(odGeNurbSurface) == OdBrErrorStatus.odbrOK)
			{
				return odGeNurbSurface.copy();
			}
			return null;
		}
		OdGe_EntityId odGe_EntityId = odGeSurface.type();
		if (OdGe_EntityId.kExternalBoundedSurface == odGe_EntityId)
		{
			OdGeSurface baseSurfaceEx = new OdGeExternalBoundedSurface(OdGeSurface.getCPtr(odGeSurface).Handle, cMemoryOwn: false).getBaseSurfaceEx();
			if (baseSurfaceEx != null && baseSurfaceEx.type() != OdGe_EntityId.kExternalSurface)
			{
				odGeSurface = baseSurfaceEx;
			}
			else if (baseSurfaceEx != null && baseSurfaceEx.type() == OdGe_EntityId.kExternalSurface)
			{
				odGeSurface = _0023_003Dzy1iz12rgo8is(baseSurfaceEx, _0023_003DzILwyq_00243CBdkJ);
			}
		}
		else if (OdGe_EntityId.kExternalSurface == odGe_EntityId)
		{
			odGeSurface = _0023_003Dzy1iz12rgo8is(odGeSurface, _0023_003DzILwyq_00243CBdkJ);
		}
		return odGeSurface;
	}

	public static OdGeSurface _0023_003Dzy1iz12rgo8is(OdGeSurface _0023_003DzDTIVWfgbGTGV, OdBrFace _0023_003DzILwyq_00243CBdkJ)
	{
		OdGeExternalSurface odGeExternalSurface = new OdGeExternalSurface(OdGeSurface.getCPtr(_0023_003DzDTIVWfgbGTGV).Handle, cMemoryOwn: false);
		OdGeSurface nativeSurface = null;
		if (odGeExternalSurface.isNativeSurface(out nativeSurface))
		{
			return nativeSurface;
		}
		OdGeNurbSurface odGeNurbSurface = new OdGeNurbSurface();
		GC.SuppressFinalize(odGeNurbSurface);
		if (_0023_003DzILwyq_00243CBdkJ.getSurfaceAsNurb(odGeNurbSurface) != OdBrErrorStatus.odbrOK)
		{
			return null;
		}
		return odGeNurbSurface;
	}

	private OdResult _0023_003DzKnwpu2PoBpEJ(ref BrepBuilderInitialData _0023_003Dz7GDkdFA_003D, ref OdBrLoop _0023_003Dzg7_002432Ro_003D, ref BrepBuilderInitialSurface _0023_003DzVWsjdJDDnN_2)
	{
		OdBrLoopEdgeTraverser odBrLoopEdgeTraverser = new OdBrLoopEdgeTraverser();
		OdBrErrorStatus odBrErrorStatus = odBrLoopEdgeTraverser.setLoop(_0023_003Dzg7_002432Ro_003D);
		if (OdBrErrorStatus.odbrDegenerateTopology == odBrErrorStatus)
		{
			OdGeCurve3d _0023_003DzINDBoqS9DTqw = null;
			OdGeCurve2d _0023_003DzOXU7LOvHOn0J = null;
			OdResult odResult = _0023_003Dz5x6z67LOlTuqBUplIg_003D_003D(ref _0023_003Dzg7_002432Ro_003D, ref _0023_003DzINDBoqS9DTqw, ref _0023_003DzOXU7LOvHOn0J);
			if (odResult == OdResult.eOk)
			{
				BrepBuilderInitialEdge brepBuilderInitialEdge = new BrepBuilderInitialEdge(_0023_003DzINDBoqS9DTqw);
				GC.SuppressFinalize(brepBuilderInitialEdge);
				_0023_003Dz7GDkdFA_003D.edges.Add(brepBuilderInitialEdge);
				OdBrEdge odBrEdge = new OdBrEdge();
				GC.SuppressFinalize(odBrEdge);
				_0023_003DzJC0DwAJyXkIG.Add(odBrEdge);
				uint num = (uint)(_0023_003DzJC0DwAJyXkIG.Count - 1);
				BrepBuilderInitialLoop brepBuilderInitialLoop = new BrepBuilderInitialLoop(_0023_003DzOXU7LOvHOn0J, _0023_003DzecaexYThChAn + num, OdBrepBuilder_EntityDirection.kForward);
				GC.SuppressFinalize(brepBuilderInitialLoop);
				_0023_003DzVWsjdJDDnN_2.loops.Add(brepBuilderInitialLoop);
				return OdResult.eOk;
			}
			return odResult;
		}
		if (odBrErrorStatus != OdBrErrorStatus.odbrOK)
		{
			return OdResult.eInvalidInput;
		}
		BrepBuilderInitialLoop brepBuilderInitialLoop2 = new BrepBuilderInitialLoop();
		while (!odBrLoopEdgeTraverser.done())
		{
			OdBrEdge edge = odBrLoopEdgeTraverser.getEdge();
			BrepBuilderInitialCoedge brepBuilderInitialCoedge = new BrepBuilderInitialCoedge();
			brepBuilderInitialCoedge.SetCurve(null);
			OdGeCurve3d _0023_003DzhQcbyO0_003D = null;
			bool flag = true;
			for (int i = 0; i < _0023_003DzJC0DwAJyXkIG.Count; i++)
			{
				if (_0023_003DzJC0DwAJyXkIG[i].isEqualTo(edge))
				{
					flag = false;
					brepBuilderInitialCoedge.SetEdgeIndex((uint)(_0023_003DzecaexYThChAn + i));
					_0023_003DzhQcbyO0_003D = _0023_003Dz7GDkdFA_003D.edges[(int)brepBuilderInitialCoedge.GetEdgeIndex()].GetCurve();
					break;
				}
			}
			if (flag)
			{
				if (!_0023_003Dz57FG8ezLEaQG(edge, out _0023_003DzhQcbyO0_003D))
				{
					return OdResult.eInvalidInput;
				}
				BrepBuilderInitialEdge brepBuilderInitialEdge2 = new BrepBuilderInitialEdge();
				brepBuilderInitialEdge2.SetCurve(_0023_003DzhQcbyO0_003D);
				_0023_003Dz7GDkdFA_003D.edges.Add(brepBuilderInitialEdge2);
				GC.SuppressFinalize(brepBuilderInitialEdge2);
				_0023_003DzJC0DwAJyXkIG.Add(edge);
				uint num2 = (uint)(_0023_003DzJC0DwAJyXkIG.Count - 1);
				brepBuilderInitialCoedge.SetEdgeIndex(_0023_003DzecaexYThChAn + num2);
			}
			brepBuilderInitialCoedge.direction = ((edge.getOrientToCurve() != odBrLoopEdgeTraverser.getEdgeOrientToLoop()) ? OdBrepBuilder_EntityDirection.kReversed : OdBrepBuilder_EntityDirection.kForward);
			if (odBrLoopEdgeTraverser.next() != OdBrErrorStatus.odbrOK)
			{
				return OdResult.eInvalidInput;
			}
			GC.SuppressFinalize(brepBuilderInitialCoedge);
			brepBuilderInitialLoop2.coedges.Add(brepBuilderInitialCoedge);
		}
		if (brepBuilderInitialLoop2.coedges.Count != 0)
		{
			GC.SuppressFinalize(brepBuilderInitialLoop2);
			_0023_003DzVWsjdJDDnN_2.loops.Add(brepBuilderInitialLoop2);
		}
		return OdResult.eOk;
	}

	private OdResult _0023_003Dz5x6z67LOlTuqBUplIg_003D_003D(ref OdBrLoop _0023_003Dzg7_002432Ro_003D, ref OdGeCurve3d _0023_003DzINDBoqS9DTqw, ref OdGeCurve2d _0023_003DzOXU7LOvHOn0J)
	{
		OdBrLoopVertexTraverser odBrLoopVertexTraverser = new OdBrLoopVertexTraverser();
		if (odBrLoopVertexTraverser.setLoop(_0023_003Dzg7_002432Ro_003D) != OdBrErrorStatus.odbrOK)
		{
			return OdResult.eInvalidInput;
		}
		OdGePoint3d point = odBrLoopVertexTraverser.getVertex().getPoint();
		if (odBrLoopVertexTraverser.next() != OdBrErrorStatus.odbrOK || !odBrLoopVertexTraverser.done())
		{
			return OdResult.eInvalidInput;
		}
		_0023_003DzINDBoqS9DTqw = new OdGeLineSeg3d(point, point);
		GC.SuppressFinalize(_0023_003DzINDBoqS9DTqw);
		_0023_003DzOXU7LOvHOn0J = null;
		return OdResult.eOk;
	}

	private bool _0023_003Dz57FG8ezLEaQG(OdBrEdge _0023_003DzwvfRfrs_003D, out OdGeCurve3d _0023_003DzhQcbyO0_003D)
	{
		_0023_003DzhQcbyO0_003D = _0023_003DzF9CcKUKk5_0024_J(_0023_003DzwvfRfrs_003D);
		if (_0023_003DzhQcbyO0_003D == null)
		{
			return false;
		}
		OdGe_EntityId odGe_EntityId = _0023_003DzhQcbyO0_003D.type();
		if (OdGe_EntityId.kEllipArc3d == odGe_EntityId)
		{
			return _0023_003Dz2hRqpPAVgVnT(ref _0023_003DzhQcbyO0_003D, _0023_003DzwvfRfrs_003D);
		}
		return true;
	}

	private bool _0023_003Dz2hRqpPAVgVnT(ref OdGeCurve3d _0023_003DzhQcbyO0_003D, OdBrEdge _0023_003DzwvfRfrs_003D)
	{
		OdGeEllipArc3d odGeEllipArc3d = new OdGeEllipArc3d(OdGeCurve3d.getCPtr(_0023_003DzhQcbyO0_003D).Handle, cMemoryOwn: false);
		OdBrVertex odBrVertex = new OdBrVertex();
		OdBrVertex odBrVertex2 = new OdBrVertex();
		if (!_0023_003DzwvfRfrs_003D.getVertex1(odBrVertex) || !_0023_003DzwvfRfrs_003D.getVertex2(odBrVertex2))
		{
			return true;
		}
		OdGePoint3d point;
		OdGePoint3d point2;
		if (_0023_003DzwvfRfrs_003D.getOrientToCurve())
		{
			point = odBrVertex.getPoint();
			point2 = odBrVertex2.getPoint();
		}
		else
		{
			point2 = odBrVertex.getPoint();
			point = odBrVertex2.getPoint();
		}
		OdGePoint3d odGePoint3d = new OdGePoint3d();
		OdGePoint3d endPoint = new OdGePoint3d();
		if (!odGeEllipArc3d.hasStartPoint(odGePoint3d) || !odGeEllipArc3d.hasEndPoint(endPoint))
		{
			return false;
		}
		if (point.isEqualTo(odGePoint3d, new OdGeTol(0.001)))
		{
			return true;
		}
		OdGeInterval odGeInterval = new OdGeInterval();
		odGeEllipArc3d.getInterval(odGeInterval);
		if (!odGeEllipArc3d.isCircular() || !point.isEqualTo(point2, new OdGeTol(0.001)))
		{
			double num = odGeEllipArc3d.paramOf(point);
			odGeEllipArc3d.setInterval(new OdGeInterval(num, num + odGeInterval.length()));
			_0023_003DzhQcbyO0_003D = new OdGeNurbCurve3d(odGeEllipArc3d);
			GC.SuppressFinalize(_0023_003DzhQcbyO0_003D);
			return true;
		}
		OdGePoint3d odGePoint3d2 = odGeEllipArc3d.center();
		OdGeVector3d odGeVector3d = odGeEllipArc3d.majorAxis();
		OdGeVector3d odGeVector3d2 = odGeEllipArc3d.normal();
		OdGeVector3d vect = point - odGePoint3d2;
		if (odGeVector3d.isCodirectionalTo(vect))
		{
			if (TD_RootIntegrated_Globals.OdNegative(odGeInterval.lowerBound()))
			{
				odGeEllipArc3d.setInterval(new OdGeInterval(0.0, odGeInterval.length()));
			}
		}
		else
		{
			double num2 = odGeVector3d.angleTo(vect, odGeVector3d2);
			if (!TD_RootIntegrated_Globals.OdZero(num2))
			{
				odGeEllipArc3d.rotateBy(num2, odGeVector3d2, odGePoint3d2);
				if (TD_RootIntegrated_Globals.OdNegative(odGeInterval.lowerBound()))
				{
					odGeEllipArc3d.setInterval(new OdGeInterval(0.0, odGeInterval.length()));
				}
			}
		}
		return true;
	}

	private OdGeCurve3d _0023_003DzF9CcKUKk5_0024_J(OdBrEdge _0023_003DzwvfRfrs_003D)
	{
		OdGeCurve3d odGeCurve3d = _0023_003DzwvfRfrs_003D.getCurve();
		if (odGeCurve3d == null)
		{
			OdGeNurbCurve3d odGeNurbCurve3d = new OdGeNurbCurve3d();
			if (_0023_003DzwvfRfrs_003D.getCurveAsNurb(odGeNurbCurve3d))
			{
				return new OdGeCurve3d(OdGeEntity3d.getCPtr(odGeNurbCurve3d.copy()).Handle, cMemoryOwn: false);
			}
			return null;
		}
		OdGe_EntityId odGe_EntityId = odGeCurve3d.type();
		if (OdGe_EntityId.kExternalCurve3d == odGe_EntityId)
		{
			OdGeCurve3d nativeCurve = null;
			if (new OdGeExternalCurve3d(OdGeCurve3d.getCPtr(odGeCurve3d).Handle, cMemoryOwn: false).isNativeCurve(out nativeCurve))
			{
				OdGeCurve3d odGeCurve3d2 = nativeCurve;
				OdGeInterval odGeInterval = new OdGeInterval();
				OdGeInterval odGeInterval2 = new OdGeInterval();
				odGeCurve3d.getInterval(odGeInterval);
				odGeCurve3d2.getInterval(odGeInterval2);
				if (_0023_003DzNmUOi_tNvjLr(odGeInterval, odGeInterval2) || _0023_003DzSArE_0024m6OxSsm(odGeInterval, odGeInterval2))
				{
					odGeCurve3d = odGeCurve3d2;
				}
			}
		}
		return odGeCurve3d;
	}

	private bool _0023_003DzNmUOi_tNvjLr(OdGeInterval _0023_003DzVF2K_00243FDExPj, OdGeInterval _0023_003DzGnNXoAtKMRvU)
	{
		if (TD_RootIntegrated_Globals.OdLessOrEqual(_0023_003DzVF2K_00243FDExPj.lowerBound(), _0023_003DzGnNXoAtKMRvU.lowerBound(), 1E-09))
		{
			return TD_RootIntegrated_Globals.OdGreaterOrEqual(_0023_003DzVF2K_00243FDExPj.upperBound(), _0023_003DzGnNXoAtKMRvU.upperBound(), 1E-09);
		}
		return false;
	}

	private bool _0023_003DzSArE_0024m6OxSsm(OdGeInterval _0023_003DzVF2K_00243FDExPj, OdGeInterval _0023_003DzGnNXoAtKMRvU)
	{
		if (TD_RootIntegrated_Globals.OdGreaterOrEqual(_0023_003DzVF2K_00243FDExPj.lowerBound() * -1.0, _0023_003DzGnNXoAtKMRvU.upperBound(), 1E-09))
		{
			return TD_RootIntegrated_Globals.OdLessOrEqual(_0023_003DzVF2K_00243FDExPj.upperBound() * -1.0, _0023_003DzGnNXoAtKMRvU.lowerBound(), 1E-09);
		}
		return false;
	}
}
