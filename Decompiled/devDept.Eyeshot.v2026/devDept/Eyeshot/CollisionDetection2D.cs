using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class CollisionDetection2D : WorkUnit
{
	private sealed class _0023_003Dz23TtycGRLt_oZQm8Kx5936E_003D
	{
		public CollisionDetection2D _0023_003DzopRx0_MBcTQs;

		public int _0023_003DzVtt8p2TkTnzDyJ8tyw_003D_003D;

		public IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D;

		public CancellationToken _0023_003Dzjvn7P10_003D;

		internal void _0023_003Dz_00248yr9mpjxJHACkdw_0024QXFqAU_003D(Entity _0023_003Dz9j7EUB0_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			_0023_003DzopRx0_MBcTQs._0023_003DzJT8dmgwpN6So++;
			if (_0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelled(_0023_003DzopRx0_MBcTQs._0023_003DzJT8dmgwpN6So, _0023_003DzVtt8p2TkTnzDyJ8tyw_003D_003D, _0023_003DzopRx0_MBcTQs.PreparingDataText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D) && _0023_003Dz9j7EUB0_003D._subdivisionTree == null)
			{
				_0023_003DzopRx0_MBcTQs._0023_003DzU95qK_0024pPUyVl(_0023_003Dz9j7EUB0_003D, _0023_003DzopRx0_MBcTQs._0023_003Dzfm0BcFm5dSRT3T4g4A_003D_003D, null, default(CancellationToken));
			}
		}
	}

	private sealed class _0023_003Dz41g7t0iaSJjVBw8SQum_Xj8_003D
	{
		public Plane _0023_003Dzrgqz890sj_0024X9;

		internal Entity _0023_003DzKHujQbV1KNQCUoxP_0024Bdx5l6RsUbVJ7Oy8w_003D_003D(PolyRegion2D _0023_003DzuwH5j5s_003D)
		{
			return _0023_003DzuwH5j5s_003D.ToRegion(_0023_003Dzrgqz890sj_0024X9);
		}
	}

	private delegate bool _0023_003DzDn0BW3WkS41M(Entity _0023_003Dzv_7IeQibaTXs, Transformation _0023_003DzsK_Xndk_003D, Entity _0023_003DzNpfDgu2nb0Hr, Transformation _0023_003Dz0ADyCos_003D, ref List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D);

	private static class _0023_003DzQm9ltrs_003D
	{
		public static _0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003DzCtLKLJ8KXO5x _0023_003DzNKF7akq7YnMUwG22tQ_003D_003D;

		public static _0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003DzCtLKLJ8KXO5x _0023_003DzXexPHIfGLK_i;
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzM6scCk2x0vgPSxDIOEMQI6TpV_oqFBAFuQ_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected List<Entity> _0023_003DzxQ8PdbzNwMzX;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected List<Entity> _0023_003Dz3jg6DiI6apyw;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected BlockKeyedCollection _0023_003DzJO1FWlQ_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected int _0023_003Dzfm0BcFm5dSRT3T4g4A_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	internal int _0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected int _0023_003DzJT8dmgwpN6So;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private protected bool _0023_003Dz_0024wT4BGLI5J64;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private List<CollisionResult> _0023_003DzLleEUYE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private collisionCheckType _0023_003DzOFgf96fmvfVb_0024Bv7Ng_003D_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzrQSXrVkvdYdvZ19piVi7Q5MosKHoCc8YxQ_003D_003D = true;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzEXGvbDFPQb8ERyzpxVgO9KE_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzFJCdRov_0024Hq2Rk3mjoj49LaY_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952657);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzsBNACGD_vEfqFgkH7BnOB8Q_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952649);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzFjSaxwzXoaoLAK3V0ocRE4o_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952616);

	public bool IgnoreComplexSurfaces
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzM6scCk2x0vgPSxDIOEMQI6TpV_oqFBAFuQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzM6scCk2x0vgPSxDIOEMQI6TpV_oqFBAFuQ_003D_003D = value;
		}
	}

	public CollisionResult[] Result => _0023_003DzLleEUYE_003D.ToArray();

	public collisionCheckType CheckMethod
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzOFgf96fmvfVb_0024Bv7Ng_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzOFgf96fmvfVb_0024Bv7Ng_003D_003D = value;
		}
	}

	public bool CoincidenceAsCollision
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzrQSXrVkvdYdvZ19piVi7Q5MosKHoCc8YxQ_003D_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzrQSXrVkvdYdvZ19piVi7Q5MosKHoCc8YxQ_003D_003D = value;
		}
	}

	public bool FirstOnly
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzEXGvbDFPQb8ERyzpxVgO9KE_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzEXGvbDFPQb8ERyzpxVgO9KE_003D = value;
		}
	}

	public string PreparingDataText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzFJCdRov_0024Hq2Rk3mjoj49LaY_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzFJCdRov_0024Hq2Rk3mjoj49LaY_003D = value;
		}
	}

	public string CollisionDetectionText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzsBNACGD_vEfqFgkH7BnOB8Q_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzsBNACGD_vEfqFgkH7BnOB8Q_003D = value;
		}
	}

	public string CollisionDetectionWithText
	{
		[CompilerGenerated]
		get
		{
			return _0023_003DzFjSaxwzXoaoLAK3V0ocRE4o_003D;
		}
		[CompilerGenerated]
		set
		{
			_0023_003DzFjSaxwzXoaoLAK3V0ocRE4o_003D = value;
		}
	}

	public CollisionDetection2D(IList<Entity> list1, IList<Entity> list2, BlockKeyedCollection blocksCollection, bool firstOnly = true, collisionCheckType checkMethod = collisionCheckType.OB, int nodeMaxItemCount = 0)
	{
		if (list1 != null)
		{
			_0023_003DzxQ8PdbzNwMzX = new List<Entity>();
			_0023_003DzxQ8PdbzNwMzX.AddRange(list1);
		}
		if (list2 != null)
		{
			_0023_003Dz3jg6DiI6apyw = new List<Entity>();
			_0023_003Dz3jg6DiI6apyw.AddRange(list2);
		}
		_0023_003DzJO1FWlQ_003D = blocksCollection;
		CheckMethod = checkMethod;
		_0023_003Dzfm0BcFm5dSRT3T4g4A_003D_003D = nodeMaxItemCount;
		FirstOnly = firstOnly;
		_0023_003DzLleEUYE_003D = null;
		_0023_003Dz_0024wT4BGLI5J64 = list2 == null;
	}

	public CollisionDetection2D(IList<Entity> list, BlockKeyedCollection blocksCollection, bool firstOnly = true, collisionCheckType checkMethod = collisionCheckType.OB, int nodeMaxItemCount = 0)
		: this(list, null, blocksCollection, firstOnly, checkMethod, nodeMaxItemCount)
	{
	}

	public override void DoWork(IProgress<ProgressChangedEventArgs> progress, CancellationToken ct)
	{
		_0023_003DzJT8dmgwpN6So = 0;
		log.Clear();
		if (_0023_003DzLleEUYE_003D != null)
		{
			_0023_003DzLleEUYE_003D.Clear();
		}
		UpdateProgress(_0023_003DzJT8dmgwpN6So, 100.0, PreparingDataText, progress);
		PrepareDataForCollision(progress, ct);
		if (UpdateProgressAndCheckCancelled(100.0, 100.0, PreparingDataText, progress, ct))
		{
			_0023_003DzJT8dmgwpN6So = 0;
			switch (CheckMethod)
			{
			case collisionCheckType.SubdivisionTree:
				_0023_003Dz96TFxvr9cFu9(progress, ct);
				break;
			case collisionCheckType.OB:
			case collisionCheckType.OBWithSubdivisionTree:
			case collisionCheckType.Accurate:
				_0023_003Dz_0024BLqCcvf_tOUbXTlMalHT_A_003D(progress, ct);
				break;
			}
		}
	}

	public void PrepareDataForCollision(IProgress<ProgressChangedEventArgs> progress = null, CancellationToken ct = default(CancellationToken))
	{
		_0023_003DzLleEUYE_003D = new List<CollisionResult>();
		switch (CheckMethod)
		{
		case collisionCheckType.OB:
			_0023_003DzakGWDthaSijR5GbR6HNpjKBnrppQ(progress, ct);
			break;
		case collisionCheckType.SubdivisionTree:
			_0023_003DzxDiAdvCTSZRwlI2k0w_003D_003D(progress, ct);
			break;
		case collisionCheckType.OBWithSubdivisionTree:
			_0023_003DzakGWDthaSijR5GbR6HNpjKBnrppQ(progress, ct);
			_0023_003DzxDiAdvCTSZRwlI2k0w_003D_003D(progress, ct);
			break;
		case collisionCheckType.Accurate:
			_0023_003DzakGWDthaSijR5GbR6HNpjKBnrppQ(progress, ct);
			break;
		}
	}

	public virtual string ComputeIntersectionVolume()
	{
		log.AppendLine();
		string text = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953329);
		if (_0023_003DzLleEUYE_003D == null)
		{
			text += Environment.NewLine;
			text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953301);
			log.Append(Environment.NewLine + text);
			return text;
		}
		text += Environment.NewLine;
		_0023_003DzDn0BW3WkS41M _0023_003DzDn0BW3WkS41M2 = null;
		switch (CheckMethod)
		{
		case collisionCheckType.Accurate:
			_0023_003DzDn0BW3WkS41M2 = _0023_003DzFkni6LgPtREc2cQDDplKBiw_003D;
			break;
		case collisionCheckType.SubdivisionTree:
		case collisionCheckType.OBWithSubdivisionTree:
			_0023_003DzDn0BW3WkS41M2 = _0023_003DzeGW6wbuF6c81fYDzotvcSaPZIVDX;
			break;
		case collisionCheckType.OB:
			text += Environment.NewLine;
			text += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953268);
			break;
		}
		if (_0023_003DzDn0BW3WkS41M2 != null)
		{
			_0023_003DzaECQ_0024SsiginU(_0023_003DzDn0BW3WkS41M2, ref text);
		}
		log.AppendLine();
		log.AppendLine(text);
		return text;
	}

	private void _0023_003DzaECQ_0024SsiginU(_0023_003DzDn0BW3WkS41M _0023_003DzQwYI4jZwwvbi48cl8Q_003D_003D, ref string _0023_003DzuMRnrORYnBlv)
	{
		for (int i = 0; i < _0023_003DzLleEUYE_003D.Count; i++)
		{
			CollisionResult collisionResult = _0023_003DzLleEUYE_003D[i];
			Entity entity = collisionResult.CollidedEntities.Item1.Entity;
			Entity entity2 = collisionResult.CollidedEntities.Item2.Entity;
			List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = ((collisionResult.CollisionItems == null) ? new List<Entity>() : new List<Entity>(collisionResult.CollisionItems));
			if (!_0023_003DzQwYI4jZwwvbi48cl8Q_003D_003D(entity, collisionResult.CollidedEntities.Item1.Transformation, entity2, collisionResult.CollidedEntities.Item2.Transformation, ref _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D))
			{
				_0023_003DzuMRnrORYnBlv += Environment.NewLine;
				_0023_003DzuMRnrORYnBlv += string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953454), i);
				_0023_003DzuMRnrORYnBlv += Environment.NewLine;
				if (_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D != null && _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Count > 0)
				{
					_0023_003DzuMRnrORYnBlv = _0023_003DzuMRnrORYnBlv + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953365) + ((_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D[0] is ICurve) ? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953086) : _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953348)) + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953048);
				}
				else
				{
					_0023_003DzuMRnrORYnBlv += _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302953020);
				}
			}
			_0023_003DzuMRnrORYnBlv += Environment.NewLine;
			_0023_003DzLleEUYE_003D[i] = new CollisionResult
			{
				CollidedEntities = collisionResult.CollidedEntities,
				CollisionItems = _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D?.ToArray()
			};
		}
	}

	private protected virtual bool _0023_003DzFkni6LgPtREc2cQDDplKBiw_003D(Entity _0023_003Dzv_7IeQibaTXs, Transformation _0023_003DzsK_Xndk_003D, Entity _0023_003DzNpfDgu2nb0Hr, Transformation _0023_003Dz0ADyCos_003D, ref List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D)
	{
		if (_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D != null)
		{
			return true;
		}
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		Entity entity = (Entity)_0023_003Dzv_7IeQibaTXs.Clone();
		Entity entity2 = (Entity)_0023_003DzNpfDgu2nb0Hr.Clone();
		Utility._0023_003DziGAL9VlRTiSaKUoibjs6bFxv0Ao6(_0023_003Dzv_7IeQibaTXs, entity);
		Utility._0023_003DziGAL9VlRTiSaKUoibjs6bFxv0Ao6(_0023_003DzNpfDgu2nb0Hr, entity2);
		if (_0023_003DzsK_Xndk_003D != null)
		{
			entity.TransformBy(_0023_003DzsK_Xndk_003D);
		}
		if (_0023_003Dz0ADyCos_003D != null)
		{
			entity2.TransformBy(_0023_003Dz0ADyCos_003D);
		}
		return _0023_003Dz4rzST9_2EqrS1ekYfZ9cQqTyPWmviVl_6w_003D_003D._0023_003Dz9G2giCoGN204cuhAG4_0024LVzE_003D(entity, entity2, ref _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D);
	}

	private protected virtual bool _0023_003DzeGW6wbuF6c81fYDzotvcSaPZIVDX(Entity _0023_003Dzv_7IeQibaTXs, Transformation _0023_003DzsK_Xndk_003D, Entity _0023_003DzNpfDgu2nb0Hr, Transformation _0023_003Dz0ADyCos_003D, ref List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D)
	{
		bool flag = true;
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		Entity entity = (Entity)_0023_003Dzv_7IeQibaTXs.Clone();
		Entity entity2 = (Entity)_0023_003DzNpfDgu2nb0Hr.Clone();
		Utility._0023_003DziGAL9VlRTiSaKUoibjs6bFxv0Ao6(_0023_003Dzv_7IeQibaTXs, entity);
		Utility._0023_003DziGAL9VlRTiSaKUoibjs6bFxv0Ao6(_0023_003DzNpfDgu2nb0Hr, entity2);
		if (_0023_003DzsK_Xndk_003D != null)
		{
			entity.TransformAllVertices(_0023_003DzsK_Xndk_003D);
		}
		if (_0023_003Dz0ADyCos_003D != null)
		{
			entity2.TransformAllVertices(_0023_003Dz0ADyCos_003D);
		}
		ICurve[] array;
		ICurve[] array2;
		if (entity is Region region)
		{
			array = new ICurve[region.Edges.Length];
			for (int i = 0; i < region.Edges.Length; i++)
			{
				array[i] = new Line(region.Vertices[region.Edges[i].V1], region.Vertices[region.Edges[i].V2]);
			}
		}
		else
		{
			array2 = new LinearPath[1]
			{
				new LinearPath(entity.Vertices)
			};
			array = array2;
		}
		ICurve[] array3;
		if (entity2 is Region region2)
		{
			array3 = new ICurve[region2.Edges.Length];
			for (int j = 0; j < region2.Edges.Length; j++)
			{
				array3[j] = new Line(region2.Vertices[region2.Edges[j].V1], region2.Vertices[region2.Edges[j].V2]);
			}
		}
		else
		{
			array2 = new LinearPath[1]
			{
				new LinearPath(entity2.Vertices)
			};
			array3 = array2;
		}
		if (entity2 is Region && entity is Region)
		{
			_0023_003Dz41g7t0iaSJjVBw8SQum_Xj8_003D CS_0024_003C_003E8__locals4 = new _0023_003Dz41g7t0iaSJjVBw8SQum_Xj8_003D();
			CS_0024_003C_003E8__locals4._0023_003Dzrgqz890sj_0024X9 = ((Region)entity).Plane;
			ICurve[] connectedCurves = Utility.GetConnectedCurves(array, entity.BoxSize.Diagonal / 1000.0);
			ICurve[] connectedCurves2 = Utility.GetConnectedCurves(array3, entity.BoxSize.Diagonal / 1000.0);
			List<Point3D>[] array4 = new List<Point3D>[connectedCurves.Length];
			for (int k = 0; k < connectedCurves.Length; k++)
			{
				array4[k] = new List<Point3D>();
				array2 = connectedCurves[k].GetIndividualCurves();
				for (int l = 0; l < array2.Length; l++)
				{
					Line line = (Line)array2[l];
					array4[k].Add(line.StartPoint);
				}
				array4[k].Add(connectedCurves[k].EndPoint);
			}
			List<Point3D>[] array5 = new List<Point3D>[connectedCurves2.Length];
			for (int m = 0; m < connectedCurves2.Length; m++)
			{
				array5[m] = new List<Point3D>();
				array2 = connectedCurves2[m].GetIndividualCurves();
				for (int l = 0; l < array2.Length; l++)
				{
					Line line2 = (Line)array2[l];
					array5[m].Add(line2.StartPoint);
				}
				array5[m].Add(connectedCurves2[m].EndPoint);
			}
			PolyRegion2D a = new PolyRegion2D(CS_0024_003C_003E8__locals4._0023_003Dzrgqz890sj_0024X9, array4);
			PolyRegion2D b = new PolyRegion2D(CS_0024_003C_003E8__locals4._0023_003Dzrgqz890sj_0024X9, array5);
			PolyRegion2D[] array6 = PolyRegion2D.Intersection(a, b);
			_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = (array6?.Select((Func<PolyRegion2D, Entity>)((PolyRegion2D _0023_003DzuwH5j5s_003D) => _0023_003DzuwH5j5s_003D.ToRegion(CS_0024_003C_003E8__locals4._0023_003Dzrgqz890sj_0024X9)))).ToList();
			if (array6 != null && array6.Length != 0)
			{
				return true;
			}
			flag = false;
		}
		List<Point3D> list = new List<Point3D>();
		array2 = array;
		foreach (ICurve curve in array2)
		{
			ICurve[] array7 = array3;
			foreach (ICurve c in array7)
			{
				list.AddRange(curve.IntersectWith(c));
			}
		}
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(list.Count);
		foreach (Point3D item3 in list)
		{
			_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(new Point(item3, 4f));
		}
		if (list.Count == 0)
		{
			if (entity is Region region3 && region3.IsPointInside(array3[0].StartPoint))
			{
				array2 = array3;
				for (int l = 0; l < array2.Length; l++)
				{
					Entity item = (Entity)array2[l];
					_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(item);
				}
			}
			else if (entity2 is Region region4 && region4.IsPointInside(array[0].StartPoint))
			{
				array2 = array;
				for (int l = 0; l < array2.Length; l++)
				{
					Entity item2 = (Entity)array2[l];
					_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(item2);
				}
			}
		}
		if (flag)
		{
			flag = _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Count > 0;
		}
		return flag;
	}

	private protected void _0023_003DzakGWDthaSijR5GbR6HNpjKBnrppQ(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		int num = 0;
		foreach (Entity item in _0023_003DzxQ8PdbzNwMzX)
		{
			if (item is BlockReference || item.OrientedBounding == null || item.OrientedBounding._0023_003DziQOhVy0_003D)
			{
				_0023_003DzJT8dmgwpN6So++;
				if (!UpdateProgressAndCheckCancelled(_0023_003DzJT8dmgwpN6So, 100.0, PreparingDataText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					return;
				}
				item._0023_003DzmKfnhwgr2htOg_AZRTHTOlQ_003D(new TraversalParams(_0023_003DzJO1FWlQ_003D), out var _0023_003DzHhJEwwk_003D, _0023_003DzjZRgeJk_003D: true, GetType() == typeof(CollisionDetection2D));
				num += _0023_003DzHhJEwwk_003D;
			}
		}
		if (!_0023_003Dz_0024wT4BGLI5J64)
		{
			int num2 = 0;
			foreach (Entity item2 in _0023_003Dz3jg6DiI6apyw)
			{
				if (item2 is BlockReference || item2.OrientedBounding == null || item2.OrientedBounding._0023_003DziQOhVy0_003D)
				{
					_0023_003DzJT8dmgwpN6So++;
					if (!UpdateProgressAndCheckCancelled(_0023_003DzJT8dmgwpN6So, 100.0, PreparingDataText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						return;
					}
					item2._0023_003DzmKfnhwgr2htOg_AZRTHTOlQ_003D(new TraversalParams(_0023_003DzJO1FWlQ_003D), out var _0023_003DzHhJEwwk_003D2, _0023_003DzjZRgeJk_003D: true, GetType() == typeof(CollisionDetection2D));
					num2 += _0023_003DzHhJEwwk_003D2;
				}
			}
			if (_0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D <= 0)
			{
				_0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D = num + num2;
			}
		}
		else if (_0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D <= 0)
		{
			_0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D = num + (num - 1);
		}
	}

	private protected virtual void _0023_003DzxDiAdvCTSZRwlI2k0w_003D_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003Dz23TtycGRLt_oZQm8Kx5936E_003D CS_0024_003C_003E8__locals16 = new _0023_003Dz23TtycGRLt_oZQm8Kx5936E_003D();
		CS_0024_003C_003E8__locals16._0023_003DzopRx0_MBcTQs = this;
		CS_0024_003C_003E8__locals16._0023_003DzmHS7frs_003D = _0023_003DzmHS7frs_003D;
		CS_0024_003C_003E8__locals16._0023_003Dzjvn7P10_003D = _0023_003Dzjvn7P10_003D;
		_0023_003DzJT8dmgwpN6So++;
		if (!UpdateProgressAndCheckCancelled(_0023_003DzJT8dmgwpN6So, 100.0, PreparingDataText, CS_0024_003C_003E8__locals16._0023_003DzmHS7frs_003D, CS_0024_003C_003E8__locals16._0023_003Dzjvn7P10_003D))
		{
			return;
		}
		HashSet<Entity> hashSet = new HashSet<Entity>(_0023_003DzxQ8PdbzNwMzX.Count);
		BlockKeyedCollection blockKeyedCollection = ((_0023_003DzJO1FWlQ_003D == null) ? null : _0023_003DzJO1FWlQ_003D);
		hashSet.UnionWith(_0023_003DzrH_a_0024HE_0WaQ(_0023_003DzxQ8PdbzNwMzX, blockKeyedCollection));
		if (!_0023_003Dz_0024wT4BGLI5J64)
		{
			hashSet.UnionWith(_0023_003DzrH_a_0024HE_0WaQ(_0023_003Dz3jg6DiI6apyw, blockKeyedCollection));
			if (_0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D <= 0)
			{
				_0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D = hashSet.Count;
			}
		}
		else if (_0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D <= 0)
		{
			_0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D = hashSet.Count * 2;
		}
		int num = _0023_003DzJT8dmgwpN6So;
		CS_0024_003C_003E8__locals16._0023_003DzVtt8p2TkTnzDyJ8tyw_003D_003D = num + hashSet.Count;
		if (hashSet.Count <= 0)
		{
			return;
		}
		Parallel.ForEach(hashSet, delegate(Entity _0023_003Dz9j7EUB0_003D, ParallelLoopState _0023_003DzLdZiL78_003D)
		{
			CS_0024_003C_003E8__locals16._0023_003DzopRx0_MBcTQs._0023_003DzJT8dmgwpN6So = CS_0024_003C_003E8__locals16._0023_003DzopRx0_MBcTQs._0023_003DzJT8dmgwpN6So + 1;
			if (CS_0024_003C_003E8__locals16._0023_003DzopRx0_MBcTQs.UpdateProgressAndCheckCancelled(CS_0024_003C_003E8__locals16._0023_003DzopRx0_MBcTQs._0023_003DzJT8dmgwpN6So, CS_0024_003C_003E8__locals16._0023_003DzVtt8p2TkTnzDyJ8tyw_003D_003D, CS_0024_003C_003E8__locals16._0023_003DzopRx0_MBcTQs.PreparingDataText, CS_0024_003C_003E8__locals16._0023_003DzmHS7frs_003D, CS_0024_003C_003E8__locals16._0023_003Dzjvn7P10_003D) && _0023_003Dz9j7EUB0_003D._subdivisionTree == null)
			{
				CS_0024_003C_003E8__locals16._0023_003DzopRx0_MBcTQs._0023_003DzU95qK_0024pPUyVl(_0023_003Dz9j7EUB0_003D, CS_0024_003C_003E8__locals16._0023_003DzopRx0_MBcTQs._0023_003Dzfm0BcFm5dSRT3T4g4A_003D_003D, null, default(CancellationToken));
			}
		});
	}

	private protected virtual void _0023_003DzU95qK_0024pPUyVl(Entity _0023_003Dz9j7EUB0_003D, int _0023_003DzUinU_2JPb52b, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		Entity entity = _0023_003DzUYWTE5s4nUkqXvQz_uqfV66U_sSE(_0023_003Dz9j7EUB0_003D);
		if (entity != null)
		{
			if (_0023_003DzUinU_2JPb52b > 0)
			{
				_0023_003Dz9j7EUB0_003D._subdivisionTree = new QuadTree(entity, _0023_003DzUinU_2JPb52b);
			}
			else
			{
				_0023_003Dz9j7EUB0_003D._subdivisionTree = new QuadTree(entity);
			}
			_0023_003Dz9j7EUB0_003D._subdivisionTree.Root.SetBoundingBox((Point3D)_0023_003Dz9j7EUB0_003D.localMin.Clone(), (Point3D)_0023_003Dz9j7EUB0_003D.localMax.Clone());
			_0023_003Dz9j7EUB0_003D._subdivisionTree.DoWork();
		}
	}

	private protected virtual Entity _0023_003DzUYWTE5s4nUkqXvQz_uqfV66U_sSE(Entity _0023_003Dz9j7EUB0_003D)
	{
		if (_0023_003Dz9j7EUB0_003D is IFace)
		{
			return _0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003DziM1_zFafFij_0024(_0023_003Dz9j7EUB0_003D, 0);
		}
		if (_0023_003Dz9j7EUB0_003D is ICurve)
		{
			return new LinearPath(_0023_003Dz9j7EUB0_003D.Vertices);
		}
		log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952762) + _0023_003Dz9j7EUB0_003D.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952990));
		return null;
	}

	private protected static HashSet<Entity> _0023_003DzrH_a_0024HE_0WaQ(IList<Entity> _0023_003Dzv7xH9gk_003D, BlockKeyedCollection _0023_003DzJO1FWlQ_003D)
	{
		HashSet<Entity> hashSet = new HashSet<Entity>();
		Utility._0023_003DzBqhbUYI_0024vLjvzlHorg_003D_003D(_0023_003Dzv7xH9gk_003D, _0023_003DzJO1FWlQ_003D, hashSet);
		foreach (Entity item in hashSet.ToList())
		{
			if (item._subdivisionTree != null)
			{
				hashSet.Remove(item);
			}
		}
		return hashSet;
	}

	private protected virtual bool _0023_003Dz_0024BLqCcvf_tOUbXTlMalHT_A_003D(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		bool result = false;
		List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D;
		if (_0023_003Dz_0024wT4BGLI5J64)
		{
			for (int i = 0; i < _0023_003DzxQ8PdbzNwMzX.Count; i++)
			{
				for (int j = i + 1; j < _0023_003DzxQ8PdbzNwMzX.Count; j++)
				{
					List<CollisionResult> list = new List<CollisionResult>();
					if (_0023_003DzMFMZAWE6RnPS(_0023_003DzxQ8PdbzNwMzX[i], _0023_003DzxQ8PdbzNwMzX[j], list, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						_0023_003DzLleEUYE_003D.AddRange(list);
						result = true;
						if (FirstOnly)
						{
							return true;
						}
					}
					else if (Cancelled(_0023_003Dzjvn7P10_003D))
					{
						return false;
					}
				}
			}
		}
		else
		{
			if (_0023_003DzxQ8PdbzNwMzX.Count < _0023_003Dz3jg6DiI6apyw.Count)
			{
				Utility.Swap(ref _0023_003DzxQ8PdbzNwMzX, ref _0023_003Dz3jg6DiI6apyw);
			}
			foreach (Entity item in _0023_003DzxQ8PdbzNwMzX)
			{
				foreach (Entity item2 in _0023_003Dz3jg6DiI6apyw)
				{
					List<CollisionResult> list2 = new List<CollisionResult>();
					if (_0023_003DzMFMZAWE6RnPS(item, item2, list2, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						_0023_003DzLleEUYE_003D.AddRange(list2);
						result = true;
						if (FirstOnly)
						{
							return true;
						}
					}
					else if (Cancelled(_0023_003Dzjvn7P10_003D))
					{
						return false;
					}
				}
			}
		}
		return result;
	}

	private protected virtual bool _0023_003Dz96TFxvr9cFu9(IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		bool result = false;
		List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D;
		if (_0023_003Dz_0024wT4BGLI5J64)
		{
			for (int i = 0; i < _0023_003DzxQ8PdbzNwMzX.Count; i++)
			{
				for (int j = i + 1; j < _0023_003DzxQ8PdbzNwMzX.Count; j++)
				{
					List<CollisionResult> list = new List<CollisionResult>();
					if (_0023_003Dz_0024YOtc779hIou(_0023_003DzxQ8PdbzNwMzX[i], _0023_003DzxQ8PdbzNwMzX[j], list, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						_0023_003DzLleEUYE_003D.AddRange(list);
						result = true;
						if (FirstOnly)
						{
							return true;
						}
					}
					else if (Cancelled(_0023_003Dzjvn7P10_003D))
					{
						return false;
					}
				}
			}
		}
		else
		{
			if (_0023_003DzxQ8PdbzNwMzX.Count < _0023_003Dz3jg6DiI6apyw.Count)
			{
				Utility.Swap(ref _0023_003DzxQ8PdbzNwMzX, ref _0023_003Dz3jg6DiI6apyw);
			}
			foreach (Entity item in _0023_003DzxQ8PdbzNwMzX)
			{
				foreach (Entity item2 in _0023_003Dz3jg6DiI6apyw)
				{
					List<CollisionResult> list2 = new List<CollisionResult>();
					if (_0023_003Dz_0024YOtc779hIou(item, item2, list2, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						_0023_003DzLleEUYE_003D.AddRange(list2);
						result = true;
						if (FirstOnly)
						{
							return true;
						}
					}
					else if (Cancelled(_0023_003Dzjvn7P10_003D))
					{
						return false;
					}
				}
			}
		}
		return result;
	}

	private protected virtual bool _0023_003Dz_0024YOtc779hIou(Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, List<CollisionResult> _0023_003DzoSSMMknipXXVNRJrlw_003D_003D, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		_0023_003DzJT8dmgwpN6So++;
		_0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003DzcvJlnzpoDjQU_0024cSTzg_003D_003D(_0023_003DzJT8dmgwpN6So, ref _0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D);
		if (!UpdateProgressAndCheckCancelled(_0023_003DzJT8dmgwpN6So, _0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D, CollisionDetectionWithText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
		{
			return false;
		}
		bool result = false;
		if (!(_0023_003Dzv_7IeQibaTXs is BlockReference) && !(_0023_003DzNpfDgu2nb0Hr is BlockReference))
		{
			QuadTree subdivisionTree = _0023_003Dzv_7IeQibaTXs._subdivisionTree;
			QuadTree subdivisionTree2 = _0023_003DzNpfDgu2nb0Hr._subdivisionTree;
			subdivisionTree.Root.GetBoudingBox(out var boxMin, out var boxMax);
			subdivisionTree2.Root.GetBoudingBox(out var boxMin2, out var boxMax2);
			OrientedBoundingRect orientedBoundingRect = new OrientedBoundingRect(boxMin, (boxMax - boxMin).X, (boxMax - boxMin).Y);
			orientedBoundingRect.AccumulateTransformation((_0023_003Dzv_7IeQibaTXs.OrientedBounding != null) ? (_0023_003Dzv_7IeQibaTXs.OrientedBounding.AccumulatedTransformation ?? new Identity()) : new Identity());
			OrientedBoundingRect orientedBoundingRect2 = new OrientedBoundingRect(boxMin2, (boxMax2 - boxMin2).X, (boxMax2 - boxMin2).Y);
			orientedBoundingRect2.AccumulateTransformation((_0023_003DzNpfDgu2nb0Hr.OrientedBounding != null) ? (_0023_003DzNpfDgu2nb0Hr.OrientedBounding.AccumulatedTransformation ?? new Identity()) : new Identity());
			if (_0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003Dz6aWRRHKmoB3YQ1RduA_003D_003D(new _0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2(orientedBoundingRect, subdivisionTree.Root, orientedBoundingRect2, subdivisionTree2.Root, _0023_003DzJT8dmgwpN6So, CoincidenceAsCollision, this, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, CollisionDetectionText)))
			{
				bool num = _0023_003Dzv_7IeQibaTXs.EntityData != null && _0023_003Dzv_7IeQibaTXs.EntityData is CollisionData;
				bool flag = _0023_003DzNpfDgu2nb0Hr.EntityData != null && _0023_003DzNpfDgu2nb0Hr.EntityData is CollisionData;
				if (!num && !flag)
				{
					CollisionData item = new CollisionData
					{
						Entity = _0023_003Dzv_7IeQibaTXs,
						Transformation = null,
						ParentName = string.Empty
					};
					CollisionData item2 = new CollisionData
					{
						Entity = _0023_003DzNpfDgu2nb0Hr,
						Transformation = null,
						ParentName = string.Empty
					};
					_0023_003DzoSSMMknipXXVNRJrlw_003D_003D.Add(new CollisionResult
					{
						CollidedEntities = new Tuple<CollisionData, CollisionData>(item, item2),
						CollisionItems = _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D?.ToArray()
					});
				}
				return true;
			}
			return false;
		}
		List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D2;
		if (_0023_003Dzv_7IeQibaTXs is BlockReference)
		{
			BlockReference blockReference = (BlockReference)_0023_003Dzv_7IeQibaTXs;
			Transformation transformation = blockReference.AccumulatedParentsTransform ?? blockReference.GetFullTransformation(_0023_003DzJO1FWlQ_003D);
			EntityList entities = _0023_003DzJO1FWlQ_003D[blockReference.BlockName].Entities;
			for (int i = 0; i < entities.Count; i++)
			{
				Entity entity = entities[i];
				bool flag2 = blockReference.EntityData != null && blockReference.EntityData is CollisionData;
				Stack<BlockReference> stack = (flag2 ? Utility.CloneStack(((CollisionData)blockReference.EntityData).Parents) : new Stack<BlockReference>());
				stack.Push(flag2 ? ((BlockReference)((CollisionData)blockReference.EntityData).Entity) : blockReference);
				CollisionData collisionData = new CollisionData
				{
					Entity = entity,
					Transformation = transformation,
					ParentName = blockReference.BlockName,
					Parents = stack
				};
				if (entity is BlockReference)
				{
					BlockReference blockReference2 = new BlockReference(((BlockReference)entity).Transformation, ((BlockReference)entity).BlockName);
					blockReference2.AccumulatedParentsTransform = transformation * blockReference2.GetFullTransformation(_0023_003DzJO1FWlQ_003D);
					blockReference2.EntityData = collisionData;
					if (_0023_003Dz_0024YOtc779hIou(blockReference2, _0023_003DzNpfDgu2nb0Hr, _0023_003DzoSSMMknipXXVNRJrlw_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D2, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						result = true;
						if (FirstOnly)
						{
							return true;
						}
					}
					continue;
				}
				Entity entity2 = new Ghost();
				if (CheckMethod == collisionCheckType.Accurate || !transformation.IsScaleFactorUniform())
				{
					entity2 = (Entity)entity.Clone();
				}
				QuadTree quadTree = entity._subdivisionTree;
				if (transformation.HasScaling && !transformation.IsScaleFactorUniform())
				{
					entity2.TransformBy(transformation);
					if (!(entity2 is IFace) && !(entity2 is ICurve))
					{
						log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952958));
						return false;
					}
					Entity entity3 = (Entity)quadTree.OriginalDataSource.Clone();
					entity3.TransformBy(transformation);
					quadTree = ((_0023_003Dzfm0BcFm5dSRT3T4g4A_003D_003D == 0) ? new QuadTree(entity3) : new QuadTree(entity3, _0023_003Dzfm0BcFm5dSRT3T4g4A_003D_003D));
					quadTree.DoWork();
					entity2._subdivisionTree = quadTree;
				}
				quadTree.Root.GetBoudingBox(out var boxMin3, out var boxMax3);
				entity2._subdivisionTree = quadTree;
				entity2.OrientedBounding = new OrientedBoundingRect(boxMin3, (boxMax3 - boxMin3).X, (boxMax3 - boxMin3).Y);
				entity2.OrientedBounding.AccumulateTransformation(transformation);
				entity2.EntityData = collisionData;
				if (_0023_003Dz_0024YOtc779hIou(_0023_003DzNpfDgu2nb0Hr, entity2, _0023_003DzoSSMMknipXXVNRJrlw_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					result = true;
					_0023_003DzsZPOPOfxBboSPNgQ09opVwY_003D(_0023_003DzNpfDgu2nb0Hr, entity2, _0023_003DzoSSMMknipXXVNRJrlw_003D_003D, _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D);
					if (FirstOnly)
					{
						return true;
					}
				}
			}
			return result;
		}
		return _0023_003Dz_0024YOtc779hIou(_0023_003DzNpfDgu2nb0Hr, _0023_003Dzv_7IeQibaTXs, _0023_003DzoSSMMknipXXVNRJrlw_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D2, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
	}

	private protected virtual bool _0023_003DzMFMZAWE6RnPS(Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, List<CollisionResult> _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		_0023_003DzJT8dmgwpN6So++;
		_0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003DzcvJlnzpoDjQU_0024cSTzg_003D_003D(_0023_003DzJT8dmgwpN6So, ref _0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D);
		if (!UpdateProgressAndCheckCancelled(_0023_003DzJT8dmgwpN6So, _0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D, CollisionDetectionText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
		{
			return false;
		}
		bool result = false;
		if (!OrientedBoundingRect.DoOverlap(_0023_003Dzv_7IeQibaTXs.OrientedBounding, _0023_003DzNpfDgu2nb0Hr.OrientedBounding) && (!CoincidenceAsCollision || !OrientedBoundingRect.DoOverlapOrTouch(_0023_003Dzv_7IeQibaTXs.OrientedBounding, _0023_003DzNpfDgu2nb0Hr.OrientedBounding)))
		{
			return false;
		}
		if (!(_0023_003Dzv_7IeQibaTXs is BlockReference) && !(_0023_003DzNpfDgu2nb0Hr is BlockReference))
		{
			bool flag = _0023_003Dzv_7IeQibaTXs.EntityData == null || !(_0023_003Dzv_7IeQibaTXs.EntityData is CollisionData);
			bool flag2 = _0023_003DzNpfDgu2nb0Hr.EntityData == null || !(_0023_003DzNpfDgu2nb0Hr.EntityData is CollisionData);
			if (CheckMethod == collisionCheckType.OBWithSubdivisionTree)
			{
				return _0023_003Dz_0024YOtc779hIou(_0023_003Dzv_7IeQibaTXs, _0023_003DzNpfDgu2nb0Hr, _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			}
			result = true;
			if (CheckMethod == collisionCheckType.Accurate)
			{
				Entity entity = (Entity)_0023_003Dzv_7IeQibaTXs.Clone();
				Entity entity2 = (Entity)_0023_003DzNpfDgu2nb0Hr.Clone();
				if (!flag)
				{
					entity.TransformBy(_0023_003Dzv_7IeQibaTXs.OrientedBounding.AccumulatedTransformation);
				}
				if (!flag2)
				{
					entity2.TransformBy(_0023_003DzNpfDgu2nb0Hr.OrientedBounding.AccumulatedTransformation);
				}
				result = _0023_003Dz3Hk5M_0024XV64tkw5NJ8Q_003D_003D(entity, entity2, _0023_003DzK4NHfJo_003D: true, CoincidenceAsCollision, IgnoreComplexSurfaces, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D);
			}
			if (result && flag && flag2)
			{
				CollisionData item = new CollisionData
				{
					Entity = _0023_003Dzv_7IeQibaTXs,
					Transformation = null,
					ParentName = string.Empty
				};
				CollisionData item2 = new CollisionData
				{
					Entity = _0023_003DzNpfDgu2nb0Hr,
					Transformation = null,
					ParentName = string.Empty
				};
				_0023_003DzruF7xXuTcN1VZfquiQ_003D_003D.Add(new CollisionResult
				{
					CollidedEntities = new Tuple<CollisionData, CollisionData>(item, item2),
					CollisionItems = _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D?.ToArray()
				});
			}
			return result;
		}
		List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D2;
		if (_0023_003Dzv_7IeQibaTXs is BlockReference)
		{
			BlockReference blockReference = (BlockReference)_0023_003Dzv_7IeQibaTXs;
			Transformation transformation = blockReference.AccumulatedParentsTransform ?? blockReference.GetFullTransformation(_0023_003DzJO1FWlQ_003D);
			EntityList entities = _0023_003DzJO1FWlQ_003D[blockReference.BlockName].Entities;
			for (int i = 0; i < entities.Count; i++)
			{
				Entity entity3 = entities[i];
				bool flag3 = blockReference.EntityData != null && blockReference.EntityData is CollisionData;
				Stack<BlockReference> stack = (flag3 ? Utility.CloneStack(((CollisionData)blockReference.EntityData).Parents) : new Stack<BlockReference>());
				stack.Push(flag3 ? ((BlockReference)((CollisionData)blockReference.EntityData).Entity) : blockReference);
				CollisionData collisionData = new CollisionData
				{
					Entity = entity3,
					Transformation = transformation,
					ParentName = blockReference.BlockName,
					Parents = stack
				};
				if (entity3 is BlockReference blockReference2)
				{
					if (_0023_003DzJO1FWlQ_003D[blockReference2.BlockName].Entities.Count == 0)
					{
						continue;
					}
					BlockReference blockReference3 = new BlockReference(blockReference2.Transformation, blockReference2.BlockName);
					blockReference3.AccumulatedParentsTransform = transformation * blockReference3.GetFullTransformation(_0023_003DzJO1FWlQ_003D);
					blockReference3.OrientedBounding = (OrientedBoundingRect)entity3.OrientedBounding.Clone();
					if (transformation.HasScaling)
					{
						blockReference3.TransformBy(transformation);
						if (blockReference3.OrientedBounding._0023_003DziQOhVy0_003D)
						{
							blockReference3.UpdateOrientedBoundingBox(new TraversalParams(_0023_003DzJO1FWlQ_003D));
						}
					}
					else
					{
						blockReference3.UpdateOrientedBoundingBox(new TraversalParams(_0023_003DzJO1FWlQ_003D, transformation), keepCurrent: true);
					}
					blockReference3.EntityData = collisionData;
					if (_0023_003DzMFMZAWE6RnPS(blockReference3, _0023_003DzNpfDgu2nb0Hr, _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D2, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						result = true;
						if (FirstOnly)
						{
							return true;
						}
					}
					continue;
				}
				Entity entity4 = new Ghost();
				if (CheckMethod == collisionCheckType.Accurate || !transformation.IsScaleFactorUniform())
				{
					entity4 = (Entity)entity3.Clone();
				}
				entity4.OrientedBounding = (OrientedBoundingRect)entity3.OrientedBounding.Clone();
				entity4._subdivisionTree = entity3._subdivisionTree;
				if (!transformation.IsScaleFactorUniform())
				{
					entity4.TransformBy(transformation);
					if (entity4.OrientedBounding._0023_003DziQOhVy0_003D)
					{
						if (!(entity4 is Mesh))
						{
							log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952958));
							return false;
						}
						entity4.UpdateOrientedBoundingBox(new TraversalParams(_0023_003DzJO1FWlQ_003D));
					}
				}
				else
				{
					entity4.UpdateOrientedBoundingBox(new TraversalParams(_0023_003DzJO1FWlQ_003D, transformation), keepCurrent: true);
				}
				entity4.EntityData = collisionData;
				if (_0023_003DzMFMZAWE6RnPS(_0023_003DzNpfDgu2nb0Hr, entity4, _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					result = true;
					_0023_003DzsZPOPOfxBboSPNgQ09opVwY_003D(_0023_003DzNpfDgu2nb0Hr, entity4, _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D);
					if (FirstOnly)
					{
						return true;
					}
				}
			}
			return result;
		}
		return _0023_003DzMFMZAWE6RnPS(_0023_003DzNpfDgu2nb0Hr, _0023_003Dzv_7IeQibaTXs, _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D2, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
	}

	private protected virtual bool _0023_003Dz3Hk5M_0024XV64tkw5NJ8Q_003D_003D(Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, bool _0023_003DzK4NHfJo_003D, bool _0023_003DzxyCtj6x0f7ge1h9wLxJ9DEkH1PWP, bool _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D)
	{
		_0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003DzCtLKLJ8KXO5x _0023_003Dzv2_iycXmH4vT8I1ZiUJ9pNo_003D = _0023_003Dz4rzST9_2EqrS1ekYfZ9cQqTyPWmviVl_6w_003D_003D._0023_003Dzaoe8pVvD0ufk;
		if (!_0023_003DzK4NHfJo_003D)
		{
			_0023_003Dzv2_iycXmH4vT8I1ZiUJ9pNo_003D = _0023_003Dz4rzST9_2EqrS1ekYfZ9cQqTyPWmviVl_6w_003D_003D._0023_003Dz9h5MY_A_003D;
		}
		string _0023_003DzqmF8XJ0_003D;
		bool result = _0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003Dz9h5MY_A_003D(_0023_003Dzv2_iycXmH4vT8I1ZiUJ9pNo_003D, _0023_003Dzv_7IeQibaTXs, _0023_003DzNpfDgu2nb0Hr, _0023_003DzxyCtj6x0f7ge1h9wLxJ9DEkH1PWP, _0023_003Dz_iOKpK_00242vv8V56AQQd_Gqfo_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, out _0023_003DzqmF8XJ0_003D);
		log.Append(_0023_003DzqmF8XJ0_003D);
		return result;
	}

	private protected static void _0023_003DzsZPOPOfxBboSPNgQ09opVwY_003D(Entity _0023_003DzNpfDgu2nb0Hr, Entity _0023_003Dz_Gzfs9c_003D, List<CollisionResult> _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D)
	{
		if (_0023_003DzruF7xXuTcN1VZfquiQ_003D_003D != null && !(_0023_003DzNpfDgu2nb0Hr is BlockReference))
		{
			CollisionData item = default(CollisionData);
			if (_0023_003DzNpfDgu2nb0Hr.EntityData == null || !(_0023_003DzNpfDgu2nb0Hr.EntityData is CollisionData))
			{
				item.Entity = _0023_003DzNpfDgu2nb0Hr;
				item.Transformation = ((_0023_003DzNpfDgu2nb0Hr.OrientedBounding != null) ? _0023_003DzNpfDgu2nb0Hr.OrientedBounding.AccumulatedTransformation : null);
				item.ParentName = string.Empty;
			}
			else
			{
				item = (CollisionData)_0023_003DzNpfDgu2nb0Hr.EntityData;
			}
			_0023_003DzruF7xXuTcN1VZfquiQ_003D_003D.Add(new CollisionResult
			{
				CollidedEntities = new Tuple<CollisionData, CollisionData>((CollisionData)_0023_003Dz_Gzfs9c_003D.EntityData, item),
				CollisionItems = _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D?.ToArray()
			});
		}
	}

	public virtual void ClearCache()
	{
		foreach (Entity item in _0023_003DzxQ8PdbzNwMzX)
		{
			item.OrientedBounding = null;
			item._subdivisionTree = null;
		}
		if (_0023_003Dz3jg6DiI6apyw != null)
		{
			foreach (Entity item2 in _0023_003Dz3jg6DiI6apyw)
			{
				item2.OrientedBounding = null;
				item2._subdivisionTree = null;
			}
		}
		if (_0023_003DzJO1FWlQ_003D == null)
		{
			return;
		}
		foreach (Block item3 in _0023_003DzJO1FWlQ_003D)
		{
			foreach (Entity entity in item3.Entities)
			{
				entity.OrientedBounding = null;
				entity._subdivisionTree = null;
			}
		}
	}
}
