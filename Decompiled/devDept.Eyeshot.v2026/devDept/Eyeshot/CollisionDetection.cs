using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace devDept.Eyeshot;

public class CollisionDetection : CollisionDetection2D
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private string _0023_003DzFjSaxwzXoaoLAK3V0ocRE4o_003D = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952815);

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private readonly int _0023_003Dzksi_7aLO0nCh;

	public new string CollisionDetectionWithText
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

	public CollisionDetection(IList<Entity> list1, IList<Entity> list2, BlockKeyedCollection blocksCollection, bool firstOnly = true, collisionCheckType checkMethod = collisionCheckType.OB, int nodeMaxItemCount = 0, int maxEdgeLength = 0)
		: base(list1, list2, blocksCollection, firstOnly, checkMethod, nodeMaxItemCount)
	{
		_0023_003Dzksi_7aLO0nCh = maxEdgeLength;
	}

	public CollisionDetection(IList<Entity> list, BlockKeyedCollection blocksCollection, bool firstOnly = true, collisionCheckType checkMethod = collisionCheckType.OB, int nodeMaxItemCount = 0, int maxEdgeLength = 0)
		: this(list, null, blocksCollection, firstOnly, checkMethod, nodeMaxItemCount, maxEdgeLength)
	{
	}

	private protected override Entity _0023_003DzUYWTE5s4nUkqXvQz_uqfV66U_sSE(Entity _0023_003Dz9j7EUB0_003D)
	{
		if (!(_0023_003Dz9j7EUB0_003D is IFace))
		{
			log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952762) + _0023_003Dz9j7EUB0_003D.GetType()?.ToString() + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952723));
			return null;
		}
		return _0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003DziM1_zFafFij_0024(_0023_003Dz9j7EUB0_003D, _0023_003Dzksi_7aLO0nCh);
	}

	private protected override void _0023_003DzU95qK_0024pPUyVl(Entity _0023_003Dz9j7EUB0_003D, int _0023_003DzH_0024sisJdeTD0e42hJXQ_003D_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		Entity entity = _0023_003DzUYWTE5s4nUkqXvQz_uqfV66U_sSE(_0023_003Dz9j7EUB0_003D);
		if (entity != null)
		{
			if (_0023_003DzH_0024sisJdeTD0e42hJXQ_003D_003D > 0)
			{
				_0023_003Dz9j7EUB0_003D._subdivisionTree = new Octree((Mesh)entity, _0023_003DzH_0024sisJdeTD0e42hJXQ_003D_003D);
			}
			else
			{
				_0023_003Dz9j7EUB0_003D._subdivisionTree = new Octree((Mesh)entity);
			}
			_0023_003Dz9j7EUB0_003D._subdivisionTree.Root.SetBoundingBox((Point3D)_0023_003Dz9j7EUB0_003D.localMin.Clone(), (Point3D)_0023_003Dz9j7EUB0_003D.localMax.Clone());
			_0023_003Dz9j7EUB0_003D._subdivisionTree.DoWork(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
		}
	}

	private protected override bool _0023_003Dz_0024YOtc779hIou(Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, List<CollisionResult> _0023_003DzoSSMMknipXXVNRJrlw_003D_003D, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
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
			Octree octree = (Octree)_0023_003Dzv_7IeQibaTXs._subdivisionTree;
			Octree octree2 = (Octree)_0023_003DzNpfDgu2nb0Hr._subdivisionTree;
			if (octree == null || octree2 == null)
			{
				return false;
			}
			octree.Root.GetBoudingBox(out var boxMin, out var boxMax);
			octree2.Root.GetBoudingBox(out var boxMin2, out var boxMax2);
			OrientedBoundingBox orientedBoundingBox = new OrientedBoundingBox((Point3D)boxMin, (boxMax - boxMin).X, (boxMax - boxMin).Y, ((Point3D)boxMax - (Point3D)boxMin).Z);
			orientedBoundingBox.AccumulateTransformation((_0023_003Dzv_7IeQibaTXs.OrientedBounding != null) ? (_0023_003Dzv_7IeQibaTXs.OrientedBounding.AccumulatedTransformation ?? new Identity()) : new Identity());
			OrientedBoundingRect orientedBoundingRect = new OrientedBoundingBox((Point3D)boxMin2, (boxMax2 - boxMin2).X, (boxMax2 - boxMin2).Y, ((Point3D)boxMax2 - (Point3D)boxMin2).Z);
			orientedBoundingRect.AccumulateTransformation((_0023_003DzNpfDgu2nb0Hr.OrientedBounding != null) ? (_0023_003DzNpfDgu2nb0Hr.OrientedBounding.AccumulatedTransformation ?? new Identity()) : new Identity());
			if (_0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003DzGBcHaJW_L4SQ(new _0023_003DzKK6oYMb6t9Yb4DAayu5MULizQGJ2(orientedBoundingBox, octree.Root, orientedBoundingRect, octree2.Root, _0023_003DzJT8dmgwpN6So, base.CoincidenceAsCollision, this, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D, base.CollisionDetectionText)))
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
						if (base.FirstOnly)
						{
							return true;
						}
					}
					continue;
				}
				if ((base.CheckMethod == collisionCheckType.OBWithSubdivisionTree || base.CheckMethod == collisionCheckType.SubdivisionTree) && entity._subdivisionTree == null)
				{
					return false;
				}
				Entity entity2 = new Ghost();
				Octree octree3 = (Octree)entity._subdivisionTree;
				if (base.CheckMethod == collisionCheckType.Accurate || !transformation.IsScaleFactorUniform())
				{
					entity2 = (Entity)entity.Clone();
					Utility._0023_003DziGAL9VlRTiSaKUoibjs6bFxv0Ao6(entity, entity2);
				}
				if (transformation.HasScaling && !transformation.IsScaleFactorUniform())
				{
					entity2.TransformBy(transformation);
					if (entity2 is Mesh mesh)
					{
						mesh.BuildOctree();
						octree3 = (Octree)entity2._subdivisionTree;
					}
					else if (entity2 is Solid solid)
					{
						octree3 = new Octree(solid.ConvertToMesh());
						octree3.DoWork(_0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
					}
					else
					{
						log.AppendLine(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952958));
					}
				}
				octree3.Root.GetBoudingBox(out var boxMin3, out var boxMax3);
				if (octree3 != null)
				{
					entity2._subdivisionTree = octree3;
					entity2.OrientedBounding = new OrientedBoundingBox((Point3D)boxMin3, (boxMax3 - boxMin3).X, (boxMax3 - boxMin3).Y, ((Point3D)boxMax3 - (Point3D)boxMin3).Z);
					entity2.OrientedBounding.AccumulateTransformation(transformation);
				}
				else
				{
					entity2._subdivisionTree = new Octree((Mesh)_0023_003DzUYWTE5s4nUkqXvQz_uqfV66U_sSE(entity));
					entity2.OrientedBounding = new OrientedBoundingBox((Point3D)boxMin3, (boxMax3 - boxMin3).X, (boxMax3 - boxMin3).Y, ((Point3D)boxMax3 - (Point3D)boxMin3).Z);
					entity2.OrientedBounding.AccumulateTransformation(transformation);
				}
				entity2.EntityData = collisionData;
				if (_0023_003Dz_0024YOtc779hIou(_0023_003DzNpfDgu2nb0Hr, entity2, _0023_003DzoSSMMknipXXVNRJrlw_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					result = true;
					CollisionDetection2D._0023_003DzsZPOPOfxBboSPNgQ09opVwY_003D(_0023_003DzNpfDgu2nb0Hr, entity2, _0023_003DzoSSMMknipXXVNRJrlw_003D_003D, _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D);
					if (base.FirstOnly)
					{
						return true;
					}
				}
			}
			return result;
		}
		return _0023_003Dz_0024YOtc779hIou(_0023_003DzNpfDgu2nb0Hr, _0023_003Dzv_7IeQibaTXs, _0023_003DzoSSMMknipXXVNRJrlw_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D2, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
	}

	private protected override bool _0023_003DzMFMZAWE6RnPS(Entity _0023_003Dzv_7IeQibaTXs, Entity _0023_003DzNpfDgu2nb0Hr, List<CollisionResult> _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, out List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, IProgress<ProgressChangedEventArgs> _0023_003DzmHS7frs_003D, CancellationToken _0023_003Dzjvn7P10_003D)
	{
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		_0023_003DzJT8dmgwpN6So++;
		_0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003DzcvJlnzpoDjQU_0024cSTzg_003D_003D(_0023_003DzJT8dmgwpN6So, ref _0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D);
		if (!UpdateProgressAndCheckCancelled(_0023_003DzJT8dmgwpN6So, _0023_003DzBMPzKpL5YXmokw8R_00246XUD_0024Q_003D, base.CollisionDetectionText, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
		{
			return false;
		}
		bool result = false;
		if (!OrientedBoundingBox.DoOverlap((OrientedBoundingBox)_0023_003Dzv_7IeQibaTXs.OrientedBounding, (OrientedBoundingBox)_0023_003DzNpfDgu2nb0Hr.OrientedBounding) && (!base.CoincidenceAsCollision || !OrientedBoundingBox.DoOverlapOrTouch((OrientedBoundingBox)_0023_003Dzv_7IeQibaTXs.OrientedBounding, (OrientedBoundingBox)_0023_003DzNpfDgu2nb0Hr.OrientedBounding)))
		{
			return false;
		}
		if (!(_0023_003Dzv_7IeQibaTXs is BlockReference) && !(_0023_003DzNpfDgu2nb0Hr is BlockReference))
		{
			bool flag = _0023_003Dzv_7IeQibaTXs.EntityData == null || !(_0023_003Dzv_7IeQibaTXs.EntityData is CollisionData);
			bool flag2 = _0023_003DzNpfDgu2nb0Hr.EntityData == null || !(_0023_003DzNpfDgu2nb0Hr.EntityData is CollisionData);
			if (base.CheckMethod == collisionCheckType.OBWithSubdivisionTree)
			{
				return _0023_003Dz_0024YOtc779hIou(_0023_003Dzv_7IeQibaTXs, _0023_003DzNpfDgu2nb0Hr, _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
			}
			result = true;
			if (base.CheckMethod == collisionCheckType.Accurate)
			{
				Entity _0023_003Dzv_7IeQibaTXs2 = ((_0023_003Dzv_7IeQibaTXs is Bar || _0023_003Dzv_7IeQibaTXs is Joint) ? ((IFace)_0023_003Dzv_7IeQibaTXs).GetTessellation()[0] : ((Entity)_0023_003Dzv_7IeQibaTXs.Clone()));
				Entity _0023_003DzNpfDgu2nb0Hr2 = ((_0023_003DzNpfDgu2nb0Hr is Bar || _0023_003DzNpfDgu2nb0Hr is Joint) ? ((IFace)_0023_003DzNpfDgu2nb0Hr).GetTessellation()[0] : ((Entity)_0023_003DzNpfDgu2nb0Hr.Clone()));
				Entity obj = (flag ? _0023_003Dzv_7IeQibaTXs : ((CollisionData)_0023_003Dzv_7IeQibaTXs.EntityData).Entity);
				Entity entity = (flag2 ? _0023_003DzNpfDgu2nb0Hr : ((CollisionData)_0023_003DzNpfDgu2nb0Hr.EntityData).Entity);
				if (obj is Brep brep)
				{
					brep.Rebuild(0.0, soft: true);
				}
				if (entity is Brep brep2)
				{
					brep2.Rebuild(0.0, soft: true);
				}
				Utility._0023_003DziGAL9VlRTiSaKUoibjs6bFxv0Ao6(obj, _0023_003Dzv_7IeQibaTXs2);
				Utility._0023_003DziGAL9VlRTiSaKUoibjs6bFxv0Ao6(entity, _0023_003DzNpfDgu2nb0Hr2);
				_0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003DzasHTy4iTW7N1doK_WQ_003D_003D(ref _0023_003Dzv_7IeQibaTXs2, ref _0023_003DzNpfDgu2nb0Hr2, _0023_003DzWFJfb_0_003D: false);
				if (!flag && _0023_003Dzv_7IeQibaTXs.OrientedBounding.AccumulatedTransformation != null)
				{
					_0023_003Dzv_7IeQibaTXs2.TransformBy(_0023_003Dzv_7IeQibaTXs.OrientedBounding.AccumulatedTransformation);
				}
				if (!flag2 && _0023_003DzNpfDgu2nb0Hr.OrientedBounding.AccumulatedTransformation != null)
				{
					_0023_003DzNpfDgu2nb0Hr2.TransformBy(_0023_003DzNpfDgu2nb0Hr.OrientedBounding.AccumulatedTransformation);
				}
				result = _0023_003Dz3Hk5M_0024XV64tkw5NJ8Q_003D_003D(_0023_003Dzv_7IeQibaTXs2, _0023_003DzNpfDgu2nb0Hr2, _0023_003DzK4NHfJo_003D: false, base.CoincidenceAsCollision, base.IgnoreComplexSurfaces, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D);
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
				Entity entity2 = entities[i];
				bool flag3 = blockReference.EntityData != null && blockReference.EntityData is CollisionData;
				Stack<BlockReference> stack = (flag3 ? Utility.CloneStack(((CollisionData)blockReference.EntityData).Parents) : new Stack<BlockReference>());
				stack.Push(flag3 ? ((BlockReference)((CollisionData)blockReference.EntityData).Entity) : blockReference);
				CollisionData collisionData = new CollisionData
				{
					Entity = entity2,
					Transformation = transformation,
					ParentName = blockReference.BlockName,
					Parents = stack
				};
				if (entity2 is BlockReference)
				{
					BlockReference blockReference2 = new BlockReference(((BlockReference)entity2).Transformation, ((BlockReference)entity2).BlockName);
					blockReference2.AccumulatedParentsTransform = transformation * blockReference2.GetFullTransformation(_0023_003DzJO1FWlQ_003D);
					blockReference2.OrientedBounding = (OrientedBoundingBox)entity2.OrientedBounding.Clone();
					if (transformation.HasScaling)
					{
						blockReference2.TransformBy(transformation);
						if (blockReference2.OrientedBounding._0023_003DziQOhVy0_003D)
						{
							blockReference2.UpdateOrientedBoundingBox(new TraversalParams(_0023_003DzJO1FWlQ_003D));
						}
					}
					else
					{
						blockReference2.UpdateOrientedBoundingBox(new TraversalParams(_0023_003DzJO1FWlQ_003D, transformation), keepCurrent: true);
					}
					blockReference2.EntityData = collisionData;
					if (_0023_003DzMFMZAWE6RnPS(blockReference2, _0023_003DzNpfDgu2nb0Hr, _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D2, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
					{
						result = true;
						if (base.FirstOnly)
						{
							return true;
						}
					}
					continue;
				}
				Entity entity3 = new Ghost();
				if (base.CheckMethod == collisionCheckType.Accurate || !transformation.IsScaleFactorUniform())
				{
					entity3 = (Entity)entity2.Clone();
					Utility._0023_003DziGAL9VlRTiSaKUoibjs6bFxv0Ao6(entity2, entity3);
				}
				entity3.OrientedBounding = (OrientedBoundingBox)entity2.OrientedBounding.Clone();
				entity3._subdivisionTree = entity2._subdivisionTree;
				if (transformation.HasScaling && !transformation.IsScaleFactorUniform())
				{
					entity3.TransformBy(transformation);
					if (entity3.OrientedBounding._0023_003DziQOhVy0_003D)
					{
						if (entity3 is Mesh)
						{
							entity3.UpdateOrientedBoundingBox(new TraversalParams(_0023_003DzJO1FWlQ_003D));
						}
						else if (entity3 is Solid)
						{
							entity3.UpdateOrientedBoundingBox(new TraversalParams(_0023_003DzJO1FWlQ_003D));
						}
						else
						{
							entity3.UpdateOrientedBoundingBox(new TraversalParams(_0023_003DzJO1FWlQ_003D, transformation), keepCurrent: true);
						}
					}
				}
				else
				{
					entity3.UpdateOrientedBoundingBox(new TraversalParams(_0023_003DzJO1FWlQ_003D, transformation), keepCurrent: true);
				}
				entity3.EntityData = collisionData;
				if (_0023_003DzMFMZAWE6RnPS(_0023_003DzNpfDgu2nb0Hr, entity3, _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D))
				{
					result = true;
					CollisionDetection2D._0023_003DzsZPOPOfxBboSPNgQ09opVwY_003D(_0023_003DzNpfDgu2nb0Hr, entity3, _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D);
					if (base.FirstOnly)
					{
						return true;
					}
				}
			}
			return result;
		}
		return _0023_003DzMFMZAWE6RnPS(_0023_003DzNpfDgu2nb0Hr, _0023_003Dzv_7IeQibaTXs, _0023_003DzruF7xXuTcN1VZfquiQ_003D_003D, out _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D2, _0023_003DzmHS7frs_003D, _0023_003Dzjvn7P10_003D);
	}

	private protected override bool _0023_003DzFkni6LgPtREc2cQDDplKBiw_003D(Entity _0023_003Dzv_7IeQibaTXs, Transformation _0023_003DzsK_Xndk_003D, Entity _0023_003DzNpfDgu2nb0Hr, Transformation _0023_003Dz0ADyCos_003D, ref List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D)
	{
		bool num = _0023_003DzsK_Xndk_003D == null || _0023_003DzsK_Xndk_003D is Identity;
		bool flag = _0023_003Dz0ADyCos_003D == null || _0023_003Dz0ADyCos_003D is Identity;
		Entity _0023_003Dzv_7IeQibaTXs2 = ((_0023_003Dzv_7IeQibaTXs is Bar || _0023_003Dzv_7IeQibaTXs is Joint) ? ((IFace)_0023_003Dzv_7IeQibaTXs).GetTessellation()[0] : ((Entity)_0023_003Dzv_7IeQibaTXs.Clone()));
		Entity _0023_003DzNpfDgu2nb0Hr2 = ((_0023_003DzNpfDgu2nb0Hr is Bar || _0023_003DzNpfDgu2nb0Hr is Joint) ? ((IFace)_0023_003DzNpfDgu2nb0Hr).GetTessellation()[0] : ((Entity)_0023_003DzNpfDgu2nb0Hr.Clone()));
		if (_0023_003Dzv_7IeQibaTXs is Brep brep)
		{
			brep.Rebuild(0.0, soft: true);
		}
		if (_0023_003DzNpfDgu2nb0Hr is Brep brep2)
		{
			brep2.Rebuild(0.0, soft: true);
		}
		Utility._0023_003DziGAL9VlRTiSaKUoibjs6bFxv0Ao6(_0023_003Dzv_7IeQibaTXs, _0023_003Dzv_7IeQibaTXs2);
		Utility._0023_003DziGAL9VlRTiSaKUoibjs6bFxv0Ao6(_0023_003DzNpfDgu2nb0Hr, _0023_003DzNpfDgu2nb0Hr2);
		_0023_003DzDxCPEER1EWPxAm6Ql6QWLzFZ16zZ._0023_003DzasHTy4iTW7N1doK_WQ_003D_003D(ref _0023_003Dzv_7IeQibaTXs2, ref _0023_003DzNpfDgu2nb0Hr2, _0023_003DzWFJfb_0_003D: true);
		if (!num)
		{
			_0023_003Dzv_7IeQibaTXs2.TransformBy(_0023_003DzsK_Xndk_003D);
		}
		if (!flag)
		{
			_0023_003DzNpfDgu2nb0Hr2.TransformBy(_0023_003Dz0ADyCos_003D);
		}
		return _0023_003Dz4rzST9_2EqrS1ekYfZ9cQqTyPWmviVl_6w_003D_003D._0023_003DzFkni6LgPtREc2cQDDplKBiw_003D(_0023_003Dzv_7IeQibaTXs2, _0023_003DzNpfDgu2nb0Hr2, ref _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D);
	}

	private protected override bool _0023_003DzeGW6wbuF6c81fYDzotvcSaPZIVDX(Entity _0023_003Dzv_7IeQibaTXs, Transformation _0023_003DzsK_Xndk_003D, Entity _0023_003DzNpfDgu2nb0Hr, Transformation _0023_003Dz0ADyCos_003D, ref List<Entity> _0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D)
	{
		_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = null;
		if (base.CheckMethod != collisionCheckType.OBWithSubdivisionTree && base.CheckMethod != collisionCheckType.SubdivisionTree)
		{
			throw new EyeshotException(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302952856));
		}
		Octree octree = (Octree)_0023_003Dzv_7IeQibaTXs._subdivisionTree;
		Octree octree2 = (Octree)_0023_003DzNpfDgu2nb0Hr._subdivisionTree;
		if (octree == null || octree2 == null)
		{
			return false;
		}
		Solid solid = ((Mesh)octree.OriginalDataSource).ConvertToSolid();
		if (_0023_003DzsK_Xndk_003D != null)
		{
			solid.TransformBy(_0023_003DzsK_Xndk_003D);
		}
		Solid solid2 = ((Mesh)octree2.OriginalDataSource).ConvertToSolid();
		if (_0023_003Dz0ADyCos_003D != null)
		{
			solid2.TransformBy(_0023_003Dz0ADyCos_003D);
		}
		Solid[] array = Solid.Intersection(solid, solid2);
		if (array != null && array.Length != 0)
		{
			_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(array);
			return true;
		}
		Segment3D[] array2 = Solid.IntersectionLoops(solid, solid2);
		if (array2 != null && array2.Length != 0)
		{
			_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D = new List<Entity>(array2.Length);
			Segment3D[] array3 = array2;
			foreach (Segment3D seg in array3)
			{
				_0023_003DzVMKnVhI9gEfsCymwylxHjbA_003D.Add(new Line(seg));
			}
		}
		return false;
	}
}
