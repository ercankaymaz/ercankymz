using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

internal sealed class _0023_003DziX2DkhrYmE6CUBVIMQh81Hs_003D
{
	internal sealed class _0023_003Dz_0024WkMNd__uiAK
	{
		public bool _0023_003Dz1XcTvJ4AwHv6;

		public bool _0023_003DzAN2F8FQxt9VxK7aTp8LL5BrL_bhvRBOyYw_003D_003D;

		private Point2D _0023_003DzdSyrM_zQJ2di;

		private Point2D _0023_003Dzmxrn0iDQb1i_;

		internal Point2D _0023_003DzZqSqKm8_003D;

		internal Point2D _0023_003DztvD0Jdc_003D;

		public ICurve _0023_003DzjwwTdlk_003D;

		public Plane _0023_003DzXCecWa6CYPEG = Plane.XY;

		private LinkedList<_0023_003DzfmsdmcfcBmDX> _0023_003DzoZVnP_0024vAJ03hqF0giw_003D_003D;

		private _0023_003Dz_0024WkMNd__uiAK(Plane _0023_003Dzrgqz890sj_0024X9, _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D)
		{
			if (_0023_003Dz3QCle2oKDLLPfinI4A_003D_003D != null)
			{
				_0023_003DzdSyrM_zQJ2di = _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D._0023_003DzVQaoDTr7XsmN();
				_0023_003Dzmxrn0iDQb1i_ = _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D._0023_003Dz15VJ9VVI6246();
			}
			_0023_003DzXCecWa6CYPEG = _0023_003Dzrgqz890sj_0024X9;
		}

		public _0023_003Dz_0024WkMNd__uiAK(Plane _0023_003Dzrgqz890sj_0024X9)
			: this(_0023_003Dzrgqz890sj_0024X9, null)
		{
			_0023_003DzadQMJ9f_0024sjU5(new LinkedList<_0023_003DzfmsdmcfcBmDX>());
		}

		public _0023_003Dz_0024WkMNd__uiAK(Plane _0023_003Dzrgqz890sj_0024X9, IList<IList<Point3D>> _0023_003DzM1QFObtq3XNNKeN9CQ_003D_003D, _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D, IList<ICurve> _0023_003DzTj1oJWREOpXS, IntegerGrid _0023_003DzOSo8vaE_003D)
			: this(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D)
		{
			_0023_003DzadQMJ9f_0024sjU5(_0023_003Dz4ufHIJXswC5d(_0023_003DzM1QFObtq3XNNKeN9CQ_003D_003D, _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D._0023_003DzIeMEgGvdP3uT(), _0023_003DzTj1oJWREOpXS, _0023_003DzOSo8vaE_003D));
		}

		public _0023_003Dz_0024WkMNd__uiAK(Plane _0023_003Dzrgqz890sj_0024X9, IList<IList<Point3D>> _0023_003DzM1QFObtq3XNNKeN9CQ_003D_003D, _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D, IList<ICurve> _0023_003DzTj1oJWREOpXS, IntegerGrid _0023_003DzOSo8vaE_003D, bool _0023_003Dz_0024ZWRvrW9NEUw5CyGuw_003D_003D)
			: this(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D)
		{
			if (!_0023_003Dz_0024ZWRvrW9NEUw5CyGuw_003D_003D)
			{
				_0023_003DzadQMJ9f_0024sjU5(_0023_003Dz4ufHIJXswC5d(_0023_003DzM1QFObtq3XNNKeN9CQ_003D_003D, _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D._0023_003DzIeMEgGvdP3uT(), _0023_003DzTj1oJWREOpXS, _0023_003DzOSo8vaE_003D));
			}
			else
			{
				_0023_003DzadQMJ9f_0024sjU5(_0023_003Dz4ufHIJXswC5d(_0023_003DzM1QFObtq3XNNKeN9CQ_003D_003D, _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D?._0023_003DzIeMEgGvdP3uT(), _0023_003DzTj1oJWREOpXS, _0023_003DzOSo8vaE_003D));
			}
		}

		public _0023_003Dz_0024WkMNd__uiAK(IList<Point2D> _0023_003DzCRq4LBU_003D, IntegerGrid _0023_003DzOSo8vaE_003D)
			: this(Plane.XY, new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D(new IList<Point2D>[1] { _0023_003DzCRq4LBU_003D }))
		{
			_0023_003DzadQMJ9f_0024sjU5(_0023_003Dz4ufHIJXswC5d(_0023_003DzCRq4LBU_003D, _0023_003DzOSo8vaE_003D));
		}

		public _0023_003Dz_0024WkMNd__uiAK(IList<Point2D> _0023_003DzCRq4LBU_003D, IntegerGrid _0023_003DzOSo8vaE_003D, bool _0023_003DzHrOH40p4t1Qt)
			: this(Plane.XY, new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D(new IList<Point2D>[1] { _0023_003DzCRq4LBU_003D }))
		{
			if (_0023_003DzHrOH40p4t1Qt)
			{
				_0023_003DzadQMJ9f_0024sjU5(_0023_003Dz4ufHIJXswC5d(_0023_003DzCRq4LBU_003D, _0023_003DzOSo8vaE_003D));
			}
			else
			{
				_0023_003DzadQMJ9f_0024sjU5(_0023_003Dz4ufHIJXswC5d(_0023_003DzCRq4LBU_003D, _0023_003DzOSo8vaE_003D));
			}
		}

		public Point2D _0023_003Dz3v2L_PqDegXs()
		{
			return _0023_003DzdSyrM_zQJ2di;
		}

		public Point2D _0023_003DzZ3fT5KydNWfc()
		{
			return _0023_003Dzmxrn0iDQb1i_;
		}

		public void _0023_003Dzj_00240wWfbMUyOYm3ci0g_003D_003D(IntegerGrid _0023_003DzOSo8vaE_003D)
		{
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzvRAdRPd11xUJ())
			{
				item._0023_003DzEgpGqIM_003D = item._0023_003Dzyk2fsPo_003D;
				item._0023_003Dz4L1sj_w_003D = item._0023_003DzvXOLtKg_003D;
				item._0023_003DzSH3vxKnk5iwK = item._0023_003DzYqBTSeQ_003D;
				item._0023_003DzCj8_mR_aKjyZ = item._0023_003DzWdV9UYA_003D;
				if (item._0023_003DzfoNNk4xzIdOW == null)
				{
					Point2D _0023_003DzfoNNk4xzIdOW = _0023_003DzXCecWa6CYPEG.Project(item._0023_003Dz114WmwtBjoiC);
					item._0023_003DzfoNNk4xzIdOW = _0023_003DzfoNNk4xzIdOW;
				}
				_0023_003DzOSo8vaE_003D.ScaleToGrid(item._0023_003DzfoNNk4xzIdOW.X, item._0023_003DzfoNNk4xzIdOW.Y, out item._0023_003Dzyk2fsPo_003D, out item._0023_003DzvXOLtKg_003D);
			}
		}

		public void _0023_003DzrydFTxnvQuoK(IntegerGrid _0023_003DzOSo8vaE_003D)
		{
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzvRAdRPd11xUJ())
			{
				if (item._0023_003DzfoNNk4xzIdOW == null)
				{
					Point2D point2D = (item._0023_003DzfoNNk4xzIdOW = _0023_003DzXCecWa6CYPEG.Project(item._0023_003Dz114WmwtBjoiC));
					_0023_003DzOSo8vaE_003D.ScaleToGrid(point2D.X, point2D.Y, out item._0023_003Dzyk2fsPo_003D, out item._0023_003DzvXOLtKg_003D);
					continue;
				}
				item._0023_003DzYqBTSeQ_003D = item._0023_003DzSH3vxKnk5iwK;
				item._0023_003DzWdV9UYA_003D = item._0023_003DzCj8_mR_aKjyZ;
				item._0023_003Dzyk2fsPo_003D = item._0023_003DzEgpGqIM_003D;
				item._0023_003DzvXOLtKg_003D = item._0023_003Dz4L1sj_w_003D;
			}
		}

		public void _0023_003DzI3Qj44E_003D(_0023_003DzfmsdmcfcBmDX _0023_003DzkEYxO1SuR1Kw, bool _0023_003DzB62SYmA_003D)
		{
			_0023_003DzfmsdmcfcBmDX _0023_003DzfmsdmcfcBmDX2 = (_0023_003DzfmsdmcfcBmDX)_0023_003DzkEYxO1SuR1Kw.Clone();
			_0023_003DzfmsdmcfcBmDX2._0023_003DzB62SYmA_003D = (_0023_003DzB62SYmA_003D ? _0023_003DzfmsdmcfcBmDX2._0023_003DzB62SYmA_003D : (!_0023_003DzfmsdmcfcBmDX2._0023_003DzB62SYmA_003D));
			if (!_0023_003DzfmsdmcfcBmDX2._0023_003Dz9h5MY_A_003D && !_0023_003DzB62SYmA_003D)
			{
				_0023_003DzfmsdmcfcBmDX2._0023_003DzuRCltcmxc7rjJVbEcQ_003D_003D();
			}
			_0023_003DzvRAdRPd11xUJ().AddLast(_0023_003DzfmsdmcfcBmDX2);
		}

		private static void _0023_003DzhVWaaapnO5To(Polygon2D _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D, Point2D _0023_003DzF7v9r2A_003D, Point2D _0023_003Dz8dK2uhU_003D)
		{
			Utility.UpdateMinMax(null, _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D.Points, _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D.VertexCount, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		}

		public static IntegerGrid _0023_003Dz_LrsyseLeNti(int _0023_003Dz2FiWBzOOImKo, IList<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D> _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D, out Point2D _0023_003DzF7v9r2A_003D, out Point2D _0023_003Dz8dK2uhU_003D)
		{
			_0023_003DzF7v9r2A_003D = Point2D.MaxValue;
			_0023_003Dz8dK2uhU_003D = Point2D.MinValue;
			List<Point2D> list = new List<Point2D>();
			foreach (_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D item in _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D)
			{
				list.Add(item._0023_003DzVQaoDTr7XsmN());
				list.Add(item._0023_003Dz15VJ9VVI6246());
			}
			Utility.UpdateMinMax(null, list, list.Count, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
			return new IntegerGrid(524288 * _0023_003Dz2FiWBzOOImKo, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		}

		public static void _0023_003Dzzg08ZSAHPR69(IList<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D> _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D, out Point2D _0023_003DzF7v9r2A_003D, out Point2D _0023_003Dz8dK2uhU_003D)
		{
			_0023_003DzF7v9r2A_003D = Point2D.MaxValue;
			_0023_003Dz8dK2uhU_003D = Point2D.MinValue;
			List<Point2D> list = new List<Point2D>();
			foreach (_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D item in _0023_003DzE276OJcU_0024u6d0TNhXg_003D_003D)
			{
				list.Add(item._0023_003DzVQaoDTr7XsmN());
				list.Add(item._0023_003Dz15VJ9VVI6246());
			}
			Utility.UpdateMinMax(null, list, list.Count, _0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D);
		}

		public LinkedList<_0023_003DzfmsdmcfcBmDX> _0023_003DzvRAdRPd11xUJ()
		{
			return _0023_003DzoZVnP_0024vAJ03hqF0giw_003D_003D;
		}

		public void _0023_003DzadQMJ9f_0024sjU5(LinkedList<_0023_003DzfmsdmcfcBmDX> _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzoZVnP_0024vAJ03hqF0giw_003D_003D = _0023_003DzPzO_0024GUk_003D;
			_0023_003DzNKw2dpKrk09r();
		}

		private static LinkedList<_0023_003DzfmsdmcfcBmDX> _0023_003Dz4ufHIJXswC5d(IList<IList<Point3D>> _0023_003DzM1QFObtq3XNNKeN9CQ_003D_003D, IList<IList<Point2D>> _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D, IList<ICurve> _0023_003DzTj1oJWREOpXS, IntegerGrid _0023_003Dzd8nJFSvWbyyE)
		{
			LinkedList<_0023_003DzfmsdmcfcBmDX> linkedList = new LinkedList<_0023_003DzfmsdmcfcBmDX>();
			int[] array = new int[2];
			int count = _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D.Count;
			for (int i = 0; i < count; i++)
			{
				int count2 = _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D[i].Count;
				for (int j = 0; j < count2; j++)
				{
					if (j == 0 && i > 0)
					{
						linkedList.Last.Value._0023_003DzEemH6ZA_003D = _0023_003DzTj1oJWREOpXS[i];
						continue;
					}
					_0023_003Dzd8nJFSvWbyyE.ScaleToGrid(_0023_003Dz3QCle2oKDLLPfinI4A_003D_003D[i][j].X, _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D[i][j].Y, array);
					Point3D _0023_003DzH_310p2vtnon = _0023_003DzM1QFObtq3XNNKeN9CQ_003D_003D?[i][j];
					linkedList.AddLast(new _0023_003DzfmsdmcfcBmDX(array[0], array[1], _0023_003DzH_310p2vtnon, _0023_003Dz3QCle2oKDLLPfinI4A_003D_003D[i][j], _0023_003DzTj1oJWREOpXS?[i]));
				}
			}
			_0023_003DzfmsdmcfcBmDX value = linkedList.First.Value;
			_0023_003DzfmsdmcfcBmDX value2 = linkedList.Last.Value;
			if (_0023_003DzTj1oJWREOpXS != null && value._0023_003Dzyk2fsPo_003D == value2._0023_003Dzyk2fsPo_003D && value._0023_003DzvXOLtKg_003D == value2._0023_003DzvXOLtKg_003D)
			{
				linkedList.Last.Value._0023_003DzEemH6ZA_003D = _0023_003DzTj1oJWREOpXS[0];
				linkedList.First.Value._0023_003DzEemH6ZA_003D = _0023_003DzTj1oJWREOpXS[0];
				linkedList.First.Value._0023_003Dz4701yxQ2_0024axv = _0023_003DzTj1oJWREOpXS[_0023_003DzTj1oJWREOpXS.Count - 1];
			}
			return linkedList;
		}

		private static LinkedList<_0023_003DzfmsdmcfcBmDX> _0023_003Dz4ufHIJXswC5d(IList<Point2D> _0023_003DzCRq4LBU_003D, IntegerGrid _0023_003Dzd8nJFSvWbyyE)
		{
			LinkedList<_0023_003DzfmsdmcfcBmDX> linkedList = new LinkedList<_0023_003DzfmsdmcfcBmDX>();
			int[] array = new int[2];
			for (int i = 0; i < _0023_003DzCRq4LBU_003D.Count; i++)
			{
				_0023_003Dzd8nJFSvWbyyE.ScaleToGrid(_0023_003DzCRq4LBU_003D[i].X, _0023_003DzCRq4LBU_003D[i].Y, array);
				linkedList.AddLast(new _0023_003DzfmsdmcfcBmDX(array[0], array[1]));
			}
			return linkedList;
		}

		public bool _0023_003DzeQ_NBHN_0024KOGpVqPa4KGB3Zs_003D()
		{
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzvRAdRPd11xUJ())
			{
				if (item._0023_003Dz9h5MY_A_003D || item._0023_003DzY5Z6MBUHWoYl())
				{
					return true;
				}
			}
			return false;
		}

		public bool _0023_003Dz3OUgTc6NJDSeK7PSaSCx3t4_003D()
		{
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzvRAdRPd11xUJ())
			{
				if (item._0023_003Dz9h5MY_A_003D || !item._0023_003DzY5Z6MBUHWoYl())
				{
					return false;
				}
			}
			return true;
		}

		public bool _0023_003DzySfSteI_003D()
		{
			_0023_003DzfmsdmcfcBmDX value = _0023_003DzvRAdRPd11xUJ().First.Value;
			_0023_003DzfmsdmcfcBmDX value2 = _0023_003DzvRAdRPd11xUJ().Last.Value;
			if (value._0023_003Dzyk2fsPo_003D == value2._0023_003Dzyk2fsPo_003D)
			{
				return value._0023_003DzvXOLtKg_003D == value2._0023_003DzvXOLtKg_003D;
			}
			return false;
		}

		public void _0023_003DzE0J67xyfENZSQDOyWQ_003D_003D()
		{
			if (_0023_003DzvRAdRPd11xUJ().First.Value._0023_003Dz9h5MY_A_003D)
			{
				_0023_003DzfmsdmcfcBmDX value = _0023_003DzvRAdRPd11xUJ().First.Value;
				do
				{
					LinkedListNode<_0023_003DzfmsdmcfcBmDX> last = _0023_003DzvRAdRPd11xUJ().Last;
					_0023_003DzvRAdRPd11xUJ().Remove(last);
					_0023_003DzvRAdRPd11xUJ().AddFirst(last);
				}
				while (_0023_003DzvRAdRPd11xUJ().First.Value._0023_003Dz9h5MY_A_003D && _0023_003DzvRAdRPd11xUJ().First.Value != value);
			}
		}

		public void _0023_003DzjLOWNhS1yXjy()
		{
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> first = _0023_003DzvRAdRPd11xUJ().First;
			bool flag = first.Value._0023_003Dz9h5MY_A_003D || !first.Value._0023_003DzY5Z6MBUHWoYl();
			for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = Utility.CircularNext(first); linkedListNode != first; linkedListNode = Utility.CircularNext(linkedListNode))
			{
				if (linkedListNode.Value._0023_003Dz9h5MY_A_003D)
				{
					linkedListNode.Value._0023_003DzQuOBdG0_003D = flag;
					flag = !flag;
				}
				else
				{
					linkedListNode.Value._0023_003Dz_0024a3VthF_8pao(!flag);
				}
			}
		}

		public void _0023_003DzsLgX8rPGMRzTVKXIEQe0XgQ_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzZNSKUSRwljLL, System.Drawing.Point _0023_003Dzwo5LU3bv1PZc)
		{
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> first = _0023_003DzvRAdRPd11xUJ().First;
			for (first = _0023_003DzvRAdRPd11xUJ().First; first != null; first = first.Next)
			{
				if (!first.Value._0023_003Dz9h5MY_A_003D)
				{
					first.Value._0023_003Dz0ejirpp2cjCb(_0023_003Dzwo5LU3bv1PZc, _0023_003DzZNSKUSRwljLL, _0023_003DzxInY1_piQJ1x: false);
				}
			}
		}

		internal void _0023_003Dzflu4SU6X2BDf_0024v5rG9EV_00247A_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzfNcJFckY8UeA, System.Drawing.Point _0023_003Dzwo5LU3bv1PZc, bool _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D)
		{
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzvRAdRPd11xUJ().First;
			while (linkedListNode != null)
			{
				_0023_003DzfmsdmcfcBmDX value = linkedListNode.Value;
				if (value._0023_003DzVuaiNJMDKH2i(_0023_003DzfNcJFckY8UeA))
				{
					value._0023_003DztiahX8OVVxEu(_0023_003DzfNcJFckY8UeA, _0023_003Dzwo5LU3bv1PZc, _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D);
					if (value == _0023_003DzvRAdRPd11xUJ().First.Value)
					{
						_0023_003DzvRAdRPd11xUJ().Last.Value._0023_003Dz93KtgaWGOsqQPtBnSw_003D_003D();
						_0023_003DzvRAdRPd11xUJ().Last.Value._0023_003DzvXOLtKg_003D = value._0023_003DzvXOLtKg_003D;
					}
					else if (value == _0023_003DzvRAdRPd11xUJ().Last.Value)
					{
						_0023_003DzvRAdRPd11xUJ().First.Value._0023_003Dz93KtgaWGOsqQPtBnSw_003D_003D();
						_0023_003DzvRAdRPd11xUJ().First.Value._0023_003DzvXOLtKg_003D = value._0023_003DzvXOLtKg_003D;
					}
					linkedListNode = _0023_003DzvRAdRPd11xUJ().First;
				}
				else
				{
					linkedListNode = linkedListNode.Next;
				}
			}
		}

		public void _0023_003DzwVFSvec_003D(LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzH6gAeE0_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzRVoDPs0_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzDr1MUxo_003D)
		{
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzRVoDPs0_003D;
			while (linkedListNode != _0023_003DzDr1MUxo_003D && linkedListNode.Value._0023_003DzbvIFYko_003D <= _0023_003DzH6gAeE0_003D.Value._0023_003DzbvIFYko_003D)
			{
				linkedListNode = linkedListNode.Next;
			}
			_0023_003DzvRAdRPd11xUJ().AddBefore(linkedListNode, _0023_003DzH6gAeE0_003D);
		}

		public LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzxCk23RO6L16o(IntegerGrid _0023_003DzOSo8vaE_003D, Point3D _0023_003DzMlCq3wk_003D)
		{
			Point2D point2D = _0023_003DzXCecWa6CYPEG.Project(_0023_003DzMlCq3wk_003D);
			_0023_003DzOSo8vaE_003D.ScaleToGrid(point2D.X, point2D.Y, out int gridX, out int gridY);
			return new LinkedListNode<_0023_003DzfmsdmcfcBmDX>(new _0023_003DzfmsdmcfcBmDX(gridX, gridY, _0023_003DzMlCq3wk_003D, _0023_003DzfxRH11yqtER41XYo5w_003D_003D: false, _0023_003Dz2uRRF4k_003D: false, _0023_003Dz4sg0Qp0_003D: false, 0.0));
		}

		public static LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzYsYhGdI_003D(int _0023_003DzBJFJHwk_003D, int _0023_003Dz40R7bAU_003D, Point3D _0023_003DzMlCq3wk_003D, bool _0023_003DzfxRH11yqtER41XYo5w_003D_003D, bool _0023_003Dz2uRRF4k_003D, bool _0023_003Dz4sg0Qp0_003D, double _0023_003DzbvIFYko_003D)
		{
			return new LinkedListNode<_0023_003DzfmsdmcfcBmDX>(new _0023_003DzfmsdmcfcBmDX(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, _0023_003DzMlCq3wk_003D, _0023_003DzfxRH11yqtER41XYo5w_003D_003D, _0023_003Dz2uRRF4k_003D, _0023_003Dz4sg0Qp0_003D, _0023_003DzbvIFYko_003D));
		}

		public static LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzUUw_0024Yv_0024L0rFZ(LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzB68dg9Q_003D)
		{
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzB68dg9Q_003D;
			while (linkedListNode != null && linkedListNode.Value._0023_003Dz9h5MY_A_003D && !linkedListNode.Value._0023_003DzMkXEB4UI_00247qA)
			{
				linkedListNode = linkedListNode.Next;
			}
			return linkedListNode;
		}

		public static LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz0QgarocZvTpt(LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzRXJWLHs_003D, _0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D, bool _0023_003DzRVoDPs0_003D, out bool _0023_003Dzq6gbnEWKa7KL)
		{
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzRXJWLHs_003D;
			_0023_003Dzq6gbnEWKa7KL = false;
			switch (_0023_003DzwY9ClXw_003D)
			{
			case (_0023_003Dz4JAfHNw_003D)1:
				while (linkedListNode != null && (!linkedListNode.Value._0023_003Dz9h5MY_A_003D || linkedListNode.Value._0023_003Dz4sg0Qp0_003D))
				{
					linkedListNode = Utility.CircularNext(linkedListNode);
					if (linkedListNode.Value == _0023_003DzRXJWLHs_003D.Value)
					{
						break;
					}
				}
				_0023_003Dzq6gbnEWKa7KL = !linkedListNode.Value._0023_003DzQuOBdG0_003D;
				break;
			case (_0023_003Dz4JAfHNw_003D)2:
				while (linkedListNode != null && (linkedListNode.Value._0023_003DzY5Z6MBUHWoYl() || linkedListNode.Value._0023_003Dz4sg0Qp0_003D))
				{
					linkedListNode = Utility.CircularNext(linkedListNode);
					if (linkedListNode.Value == _0023_003DzRXJWLHs_003D.Value)
					{
						break;
					}
				}
				break;
			case (_0023_003Dz4JAfHNw_003D)0:
				if (_0023_003DzRVoDPs0_003D)
				{
					while (linkedListNode != null && (linkedListNode.Value._0023_003DzY5Z6MBUHWoYl() || linkedListNode.Value._0023_003Dz9h5MY_A_003D || linkedListNode.Value._0023_003Dz4sg0Qp0_003D))
					{
						linkedListNode = Utility.CircularNext(linkedListNode);
						if (linkedListNode.Value == _0023_003DzRXJWLHs_003D.Value)
						{
							break;
						}
					}
					break;
				}
				while (linkedListNode != null && (linkedListNode.Value._0023_003DzY5Z6MBUHWoYl() || linkedListNode.Value._0023_003Dz4sg0Qp0_003D))
				{
					linkedListNode = Utility.CircularNext(linkedListNode);
					if (linkedListNode.Value == _0023_003DzRXJWLHs_003D.Value)
					{
						break;
					}
				}
				break;
			}
			return linkedListNode;
		}

		private static void _0023_003DzeQOQKfAqtAvt(LinkedList<_0023_003DzfmsdmcfcBmDX> _0023_003DzN57VxTE7ZsCw)
		{
			_0023_003DzN57VxTE7ZsCw.RemoveLast();
			_0023_003DzN57VxTE7ZsCw.AddLast(_0023_003DzN57VxTE7ZsCw.First.Value);
		}

		private IList<Point2D> _0023_003DzhpmPPv2xRsOA(IntegerGrid _0023_003DzOSo8vaE_003D)
		{
			List<Point2D> list = new List<Point2D>();
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzvRAdRPd11xUJ())
			{
				list.Add(item._0023_003Dz6AHwI_o_003D(_0023_003DzOSo8vaE_003D));
			}
			return list;
		}

		internal IList<Point2D> _0023_003Dz6AHwI_o_003D(IntegerGrid _0023_003DzOSo8vaE_003D)
		{
			Point2D[] array = new Point2D[_0023_003DzvRAdRPd11xUJ().Count];
			int num = 0;
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzvRAdRPd11xUJ())
			{
				array[num++] = item._0023_003Dz6AHwI_o_003D(_0023_003DzOSo8vaE_003D);
			}
			return array;
		}

		internal void _0023_003Dz0wcqTpk_003D()
		{
			LinkedList<_0023_003DzfmsdmcfcBmDX> linkedList = new LinkedList<_0023_003DzfmsdmcfcBmDX>();
			for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzvRAdRPd11xUJ().Last; linkedListNode != null; linkedListNode = linkedListNode.Previous)
			{
				linkedList.AddLast(new LinkedListNode<_0023_003DzfmsdmcfcBmDX>(linkedListNode.Value));
				linkedListNode.Value._0023_003DzuRCltcmxc7rjJVbEcQ_003D_003D();
				linkedListNode.Value._0023_003DzB62SYmA_003D = !linkedListNode.Value._0023_003DzB62SYmA_003D;
			}
			_0023_003DzadQMJ9f_0024sjU5(linkedList);
		}

		internal pointStatusType _0023_003DzlgkUJVvf16gK(_0023_003DzfmsdmcfcBmDX _0023_003DzZTe_0024jFG9ebLg, double _0023_003DzxH4ozIo_003D)
		{
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzvRAdRPd11xUJ().First;
			while (linkedListNode != null)
			{
				LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = linkedListNode.Next;
				if (next == null)
				{
					break;
				}
				if (linkedListNode.Value._0023_003Dzyk2fsPo_003D == next.Value._0023_003Dzyk2fsPo_003D && linkedListNode.Value._0023_003DzvXOLtKg_003D == next.Value._0023_003DzvXOLtKg_003D)
				{
					linkedListNode = next;
					continue;
				}
				double num = _0023_003DzxH4ozIo_003D * Utility._0023_003DzxhnLabVjXjPg;
				if (Utility._0023_003DzedEHTyqioyyN(new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(_0023_003DzZTe_0024jFG9ebLg._0023_003Dzyk2fsPo_003D, _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D), new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(linkedListNode.Value._0023_003Dzyk2fsPo_003D, linkedListNode.Value._0023_003DzvXOLtKg_003D), new _0023_003DzpaKV2_00242cE_aeJQ2qiQPbF_M_003D(next.Value._0023_003Dzyk2fsPo_003D, next.Value._0023_003DzvXOLtKg_003D), num * num))
				{
					return pointStatusType.Onto;
				}
				linkedListNode = next;
			}
			int _0023_003Dzi9fncwc_003D = 0;
			linkedListNode = _0023_003DzvRAdRPd11xUJ().First;
			while (linkedListNode != null)
			{
				LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = linkedListNode.Next;
				if (next == null)
				{
					break;
				}
				_0023_003DzjeNLey2jOgdp(_0023_003DzZTe_0024jFG9ebLg, linkedListNode, next, ref _0023_003Dzi9fncwc_003D);
				linkedListNode = next;
			}
			if ((_0023_003Dzi9fncwc_003D & 1) != 0)
			{
				return pointStatusType.Inside;
			}
			return pointStatusType.Outside;
		}

		private static void _0023_003DzjeNLey2jOgdp(_0023_003DzfmsdmcfcBmDX _0023_003DzZTe_0024jFG9ebLg, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz77g161c_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzvmFFjUs_003D, ref int _0023_003Dzi9fncwc_003D)
		{
			if (((_0023_003Dz77g161c_003D.Value._0023_003DzvXOLtKg_003D <= _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D && _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D < _0023_003DzvmFFjUs_003D.Value._0023_003DzvXOLtKg_003D) || (_0023_003DzvmFFjUs_003D.Value._0023_003DzvXOLtKg_003D <= _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D && _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D < _0023_003Dz77g161c_003D.Value._0023_003DzvXOLtKg_003D)) && (double)_0023_003DzZTe_0024jFG9ebLg._0023_003Dzyk2fsPo_003D < (double)(_0023_003DzvmFFjUs_003D.Value._0023_003Dzyk2fsPo_003D - _0023_003Dz77g161c_003D.Value._0023_003Dzyk2fsPo_003D) * (double)(_0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D - _0023_003Dz77g161c_003D.Value._0023_003DzvXOLtKg_003D) / (double)(_0023_003DzvmFFjUs_003D.Value._0023_003DzvXOLtKg_003D - _0023_003Dz77g161c_003D.Value._0023_003DzvXOLtKg_003D) + (double)_0023_003Dz77g161c_003D.Value._0023_003Dzyk2fsPo_003D)
			{
				_0023_003Dzi9fncwc_003D++;
			}
		}

		internal bool _0023_003Dz9h5MY_A_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003Dzl_0024MIsC0_003D)
		{
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003Dzl_0024MIsC0_003D._0023_003DzvRAdRPd11xUJ().First;
			if (!Utility.DoOverlapOrTouch(_0023_003DzZqSqKm8_003D, _0023_003DztvD0Jdc_003D, _0023_003Dzl_0024MIsC0_003D._0023_003DzZqSqKm8_003D, _0023_003Dzl_0024MIsC0_003D._0023_003DztvD0Jdc_003D))
			{
				return false;
			}
			bool flag = true;
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003Dzl_0024MIsC0_003D._0023_003DzvRAdRPd11xUJ())
			{
				if (!_0023_003DzrfhmnHeX0Pzt(item))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return true;
			}
			flag = true;
			foreach (_0023_003DzfmsdmcfcBmDX item2 in _0023_003DzvRAdRPd11xUJ())
			{
				if (!_0023_003Dzl_0024MIsC0_003D._0023_003DzrfhmnHeX0Pzt(item2))
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				return true;
			}
			while (linkedListNode != null)
			{
				LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = linkedListNode.Next;
				if (next == null)
				{
					break;
				}
				Segment2D segment2D = new Segment2D(new Point2D(linkedListNode.Value._0023_003Dzyk2fsPo_003D, linkedListNode.Value._0023_003DzvXOLtKg_003D), new Point2D(next.Value._0023_003Dzyk2fsPo_003D, next.Value._0023_003DzvXOLtKg_003D));
				LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode2 = _0023_003DzvRAdRPd11xUJ().First;
				while (linkedListNode2 != null)
				{
					LinkedListNode<_0023_003DzfmsdmcfcBmDX> next2 = linkedListNode2.Next;
					if (next2 == null)
					{
						break;
					}
					if (((double)linkedListNode2.Value._0023_003Dzyk2fsPo_003D == segment2D.P0.X && (double)linkedListNode2.Value._0023_003DzvXOLtKg_003D == segment2D.P0.Y) || ((double)linkedListNode2.Value._0023_003Dzyk2fsPo_003D == segment2D.P1.X && (double)linkedListNode2.Value._0023_003DzvXOLtKg_003D == segment2D.P1.Y) || ((double)next2.Value._0023_003Dzyk2fsPo_003D == segment2D.P0.X && (double)next2.Value._0023_003DzvXOLtKg_003D == segment2D.P0.Y) || ((double)next2.Value._0023_003Dzyk2fsPo_003D == segment2D.P1.X && (double)next2.Value._0023_003DzvXOLtKg_003D == segment2D.P1.Y))
					{
						return true;
					}
					Segment2D segment2D2 = new Segment2D(new Point2D(linkedListNode2.Value._0023_003Dzyk2fsPo_003D, linkedListNode2.Value._0023_003DzvXOLtKg_003D), new Point2D(next2.Value._0023_003Dzyk2fsPo_003D, next2.Value._0023_003DzvXOLtKg_003D));
					if (Segment2D.Intersection(segment2D, segment2D2, out var _, out var _, Math.Min(segment2D.Length, segment2D2.Length)) != segmentIntersectionType.Disjoint)
					{
						return true;
					}
					linkedListNode2 = next2;
				}
				linkedListNode = next;
			}
			return false;
		}

		internal bool _0023_003Dzxbr8_0024Jk_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003Dzl_0024MIsC0_003D, double _0023_003DzZodlKT3VkP5N)
		{
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003Dzl_0024MIsC0_003D._0023_003DzvRAdRPd11xUJ())
			{
				if (_0023_003DzlgkUJVvf16gK(item, _0023_003DzZodlKT3VkP5N) != pointStatusType.Inside)
				{
					return false;
				}
			}
			return true;
		}

		internal _0023_003DzfmsdmcfcBmDX[] _0023_003DzBQWed6E_003D()
		{
			_0023_003DzfmsdmcfcBmDX[] array = new _0023_003DzfmsdmcfcBmDX[_0023_003DzvRAdRPd11xUJ().Count];
			_0023_003DzvRAdRPd11xUJ().CopyTo(array, 0);
			return array;
		}

		internal void _0023_003DzbXI6NhUSpp0wgx7p2w_003D_003D()
		{
			ICurve _0023_003Dz4701yxQ2_0024axv = _0023_003DzvRAdRPd11xUJ().First.Value._0023_003Dz4701yxQ2_0024axv;
			ICurve _0023_003DzEemH6ZA_003D = _0023_003DzvRAdRPd11xUJ().First.Value._0023_003DzEemH6ZA_003D;
			for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzvRAdRPd11xUJ().First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = linkedListNode.Next;
				if (next != null)
				{
					if (next.Value._0023_003DzEemH6ZA_003D != null)
					{
						linkedListNode.Value._0023_003Dz4701yxQ2_0024axv = next.Value._0023_003DzEemH6ZA_003D;
						linkedListNode.Value._0023_003DzEemH6ZA_003D = next.Value._0023_003Dz4701yxQ2_0024axv;
					}
					else
					{
						linkedListNode.Value._0023_003Dz4701yxQ2_0024axv = next.Value._0023_003Dz4701yxQ2_0024axv;
					}
				}
			}
			if (_0023_003DzEemH6ZA_003D != null)
			{
				_0023_003DzvRAdRPd11xUJ().Last.Value._0023_003Dz4701yxQ2_0024axv = _0023_003DzEemH6ZA_003D;
				_0023_003DzvRAdRPd11xUJ().Last.Value._0023_003DzEemH6ZA_003D = _0023_003Dz4701yxQ2_0024axv;
			}
			else
			{
				_0023_003DzvRAdRPd11xUJ().Last.Value._0023_003Dz4701yxQ2_0024axv = _0023_003Dz4701yxQ2_0024axv;
			}
		}

		[Conditional("DEBUG")]
		public void _0023_003DzUollzlzzprtB()
		{
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzvRAdRPd11xUJ())
			{
				_ = item;
			}
		}

		internal bool _0023_003DzinOQp4_qBUm4opZWpg_003D_003D()
		{
			Point2D[] array = new Point2D[_0023_003DzvRAdRPd11xUJ().Count];
			int num = 0;
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzvRAdRPd11xUJ())
			{
				array[num++] = new Point2D(item._0023_003Dzyk2fsPo_003D, item._0023_003DzvXOLtKg_003D);
			}
			return Utility.IsOrientedClockwise(array);
		}

		internal void _0023_003Dz24j_0024P5iRocZH6WTXsQyiE9gFVerX()
		{
			Point2D[] array = new Point2D[_0023_003DzvRAdRPd11xUJ().Count];
			int num = 0;
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzvRAdRPd11xUJ())
			{
				array[num++] = new Point2D(item._0023_003Dzyk2fsPo_003D, item._0023_003DzvXOLtKg_003D);
			}
			if (Utility.IsOrientedClockwise(array))
			{
				_0023_003Dz0wcqTpk_003D();
			}
		}

		internal void _0023_003Dz3ZCpxVR2dBHU_Kefo_hs0BIVoST0YU85_0024OUeiwk_003D(_0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D)
		{
			for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzvRAdRPd11xUJ().First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = linkedListNode.Next;
				while (next != null && linkedListNode.Value._0023_003Dzyk2fsPo_003D == next.Value._0023_003Dzyk2fsPo_003D && linkedListNode.Value._0023_003DzvXOLtKg_003D == next.Value._0023_003DzvXOLtKg_003D)
				{
					if (linkedListNode.Value._0023_003Dz9h5MY_A_003D && !next.Value._0023_003Dz9h5MY_A_003D)
					{
						_0023_003DzvRAdRPd11xUJ().Remove(next);
						linkedListNode.Value._0023_003DzEemH6ZA_003D = next.Value._0023_003DzEemH6ZA_003D;
					}
					else if (!linkedListNode.Value._0023_003Dz9h5MY_A_003D && next.Value._0023_003Dz9h5MY_A_003D)
					{
						_0023_003DzvRAdRPd11xUJ().Remove(linkedListNode);
						linkedListNode = next;
					}
					next = next.Next;
				}
			}
		}

		internal bool _0023_003DzLh1CFIntBKvS(Point3D _0023_003DzMlCq3wk_003D, out LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz7HSf5qk_003D)
		{
			for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzvRAdRPd11xUJ().First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				Point3D _0023_003Dz114WmwtBjoiC = linkedListNode.Value._0023_003Dz114WmwtBjoiC;
				if (_0023_003Dz114WmwtBjoiC.X == _0023_003DzMlCq3wk_003D.X && _0023_003Dz114WmwtBjoiC.Y == _0023_003DzMlCq3wk_003D.Y && _0023_003Dz114WmwtBjoiC.Z == _0023_003DzMlCq3wk_003D.Z)
				{
					_0023_003Dz7HSf5qk_003D = linkedListNode;
					return true;
				}
			}
			_0023_003Dz7HSf5qk_003D = null;
			return false;
		}

		internal bool _0023_003DzSc8KQg2Kno520Kzg0g_003D_003D(_0023_003DzfmsdmcfcBmDX _0023_003Dz77g161c_003D, out LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz7HSf5qk_003D)
		{
			for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzvRAdRPd11xUJ().First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				if (linkedListNode.Value._0023_003Dzyk2fsPo_003D == _0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D && linkedListNode.Value._0023_003DzvXOLtKg_003D == _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D)
				{
					_0023_003Dz7HSf5qk_003D = linkedListNode;
					return true;
				}
			}
			_0023_003Dz7HSf5qk_003D = null;
			return false;
		}

		public void _0023_003DzOq_CSAk_003D(double _0023_003DzccAR5G0_003D)
		{
			_0023_003DzOq_CSAk_003D(_0023_003DzvRAdRPd11xUJ(), _0023_003DzccAR5G0_003D);
		}

		internal static void _0023_003DzOq_CSAk_003D(LinkedList<_0023_003DzfmsdmcfcBmDX> _0023_003DzN57VxTE7ZsCw, double _0023_003DzccAR5G0_003D)
		{
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzN57VxTE7ZsCw.First;
			while (linkedListNode != null)
			{
				LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = linkedListNode.Next;
				if (next == null)
				{
					break;
				}
				_0023_003DzfmsdmcfcBmDX value = linkedListNode.Value;
				_0023_003DzfmsdmcfcBmDX value2 = next.Value;
				if (_0023_003DzMAxShrbxTEQp(value, value2) || _0023_003DzMAxShrbxTEQp(value._0023_003Dz114WmwtBjoiC, value2._0023_003Dz114WmwtBjoiC, _0023_003DzccAR5G0_003D))
				{
					if (!value._0023_003Dz9h5MY_A_003D || value2._0023_003Dz9h5MY_A_003D)
					{
						if (linkedListNode.Value._0023_003DzEemH6ZA_003D == null)
						{
							_0023_003DzN57VxTE7ZsCw.Remove(linkedListNode);
							linkedListNode = next;
							continue;
						}
					}
					else if (next.Value._0023_003DzEemH6ZA_003D == null)
					{
						linkedListNode.Value._0023_003DzB62SYmA_003D = next.Value._0023_003DzB62SYmA_003D;
						_0023_003DzN57VxTE7ZsCw.Remove(next);
						continue;
					}
				}
				linkedListNode = linkedListNode.Next;
			}
		}

		internal void _0023_003DzmWcpFuZXVQcRMYa6GaIzQhg_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzZNSKUSRwljLL, System.Drawing.Point _0023_003Dzwo5LU3bv1PZc, bool _0023_003Dzx3_8Ey_HzTH_0024, bool _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D)
		{
			for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzvRAdRPd11xUJ().First; linkedListNode != null; linkedListNode = linkedListNode.Next)
			{
				for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode2 = _0023_003DzZNSKUSRwljLL._0023_003DzvRAdRPd11xUJ().First; linkedListNode2 != null; linkedListNode2 = linkedListNode2.Next)
				{
					LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = linkedListNode2.Next;
					if (next != null)
					{
						Segment2D _0023_003DzFDJdA7A_003D = new Segment2D(linkedListNode2.Value._0023_003Dzyk2fsPo_003D, linkedListNode2.Value._0023_003DzvXOLtKg_003D, next.Value._0023_003Dzyk2fsPo_003D, next.Value._0023_003DzvXOLtKg_003D);
						if (linkedListNode.Value._0023_003DzAyiJ0w9kCzId(_0023_003DzFDJdA7A_003D))
						{
							linkedListNode.Value._0023_003Dz0sl12EOIB4N_002401cAIA_003D_003D(_0023_003DzFDJdA7A_003D, _0023_003DzZNSKUSRwljLL, _0023_003Dzwo5LU3bv1PZc, _0023_003Dzx3_8Ey_HzTH_0024, _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D);
						}
					}
				}
			}
		}

		internal void _0023_003DzNKw2dpKrk09r()
		{
			if (_0023_003DzvRAdRPd11xUJ() == null || _0023_003DzvRAdRPd11xUJ().Count <= 0)
			{
				return;
			}
			_0023_003DzZqSqKm8_003D = new Point2D(_0023_003DzvRAdRPd11xUJ().First.Value._0023_003Dzyk2fsPo_003D, _0023_003DzvRAdRPd11xUJ().First.Value._0023_003DzvXOLtKg_003D);
			_0023_003DztvD0Jdc_003D = (Point2D)_0023_003DzZqSqKm8_003D.Clone();
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzvRAdRPd11xUJ())
			{
				Utility.UpdateMinMaxQuick(item._0023_003Dzyk2fsPo_003D, item._0023_003DzvXOLtKg_003D, _0023_003DzZqSqKm8_003D, _0023_003DztvD0Jdc_003D);
			}
		}

		internal void _0023_003DzItnzfA4C7E9K40TmrA_003D_003D()
		{
			List<Point2D> list = new List<Point2D>();
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzvRAdRPd11xUJ())
			{
				if (item._0023_003DzfoNNk4xzIdOW != null)
				{
					list.Add(item._0023_003DzfoNNk4xzIdOW);
				}
			}
			_0023_003DzdSyrM_zQJ2di = Point2D.MaxValue;
			_0023_003Dzmxrn0iDQb1i_ = Point2D.MinValue;
			Utility.UpdateMinMax(null, list, list.Count, _0023_003DzdSyrM_zQJ2di, _0023_003Dzmxrn0iDQb1i_);
		}

		public bool _0023_003DzQbu5T6lKs4Z_0024Qr_0024z_0024Q_003D_003D(_0023_003DzfmsdmcfcBmDX _0023_003DzZTe_0024jFG9ebLg)
		{
			if ((double)_0023_003DzZTe_0024jFG9ebLg._0023_003Dzyk2fsPo_003D > _0023_003DzZqSqKm8_003D.X && (double)_0023_003DzZTe_0024jFG9ebLg._0023_003Dzyk2fsPo_003D < _0023_003DztvD0Jdc_003D.X && (double)_0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D > _0023_003DzZqSqKm8_003D.Y && (double)_0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D < _0023_003DztvD0Jdc_003D.Y)
			{
				return true;
			}
			return false;
		}

		internal bool _0023_003DzrfhmnHeX0Pzt(_0023_003DzfmsdmcfcBmDX _0023_003DzZTe_0024jFG9ebLg)
		{
			if (!_0023_003DzQbu5T6lKs4Z_0024Qr_0024z_0024Q_003D_003D(_0023_003DzZTe_0024jFG9ebLg))
			{
				return false;
			}
			int num = 0;
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzvRAdRPd11xUJ().First;
			for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = linkedListNode.Next; next != null; next = linkedListNode.Next)
			{
				_0023_003DzfmsdmcfcBmDX value = linkedListNode.Value;
				_0023_003DzfmsdmcfcBmDX value2 = next.Value;
				if (((value._0023_003DzvXOLtKg_003D <= _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D && _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D < value2._0023_003DzvXOLtKg_003D) || (value2._0023_003DzvXOLtKg_003D <= _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D && _0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D < value._0023_003DzvXOLtKg_003D)) && (double)_0023_003DzZTe_0024jFG9ebLg._0023_003Dzyk2fsPo_003D < (double)(value2._0023_003Dzyk2fsPo_003D - value._0023_003Dzyk2fsPo_003D) * (double)(_0023_003DzZTe_0024jFG9ebLg._0023_003DzvXOLtKg_003D - value._0023_003DzvXOLtKg_003D) / (double)(value2._0023_003DzvXOLtKg_003D - value._0023_003DzvXOLtKg_003D) + (double)value._0023_003Dzyk2fsPo_003D)
				{
					num++;
				}
				linkedListNode = linkedListNode.Next;
				if (linkedListNode == null)
				{
					break;
				}
			}
			return (num & 1) == 1;
		}
	}

	internal enum _0023_003Dz4JAfHNw_003D
	{

	}

	internal enum _0023_003DzOmuoKv8_003D
	{

	}

	internal enum _0023_003DzRrz47AY_003D
	{

	}

	internal sealed class _0023_003DzfmsdmcfcBmDX : ICloneable, IEquatable<_0023_003DzfmsdmcfcBmDX>
	{
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzMkXEB4UI_00247qA;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal int _0023_003DzEgpGqIM_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal int _0023_003Dz4L1sj_w_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal int _0023_003DzSH3vxKnk5iwK;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		internal int _0023_003DzCj8_mR_aKjyZ;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003Dzyk2fsPo_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzvXOLtKg_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003Dzse5L_LQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ICurve _0023_003Dz4701yxQ2_0024axv;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public ICurve _0023_003DzEemH6ZA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzYqBTSeQ_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public int _0023_003DzWdV9UYA_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzzAvTK7EbICGAsFTsLg_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003Dzm5lnfUazwLWYs0OK3g_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dzg_d2bCm63KSux51d6w_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public _0023_003Dz_0024WkMNd__uiAK _0023_003DzQC2DY_0024geS4zZUaYo9w_003D_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003Dz9h5MY_A_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzQuOBdG0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003Dz4sg0Qp0_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003DzbvIFYko_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public double _0023_003Dz5f_002462i5VihV3;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public bool _0023_003DzB62SYmA_003D = true;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private bool _0023_003DzAzKc5gs_003D;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point3D _0023_003Dz114WmwtBjoiC;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public Point2D _0023_003DzfoNNk4xzIdOW;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static int[] _0023_003DzhTBDVLsjjzaJPkBNFQ_003D_003D = new int[16]
		{
			2, -4, -2, -4, -2, 4, 2, 4, 0, 4,
			0, -4, 2, 0, -2, 0
		};

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private static bool _0023_003Dz1v6oPQk_003D = false;

		public _0023_003DzfmsdmcfcBmDX()
		{
		}

		public _0023_003DzfmsdmcfcBmDX(int _0023_003DzBJFJHwk_003D, int _0023_003Dz40R7bAU_003D)
		{
			_0023_003Dzyk2fsPo_003D = _0023_003DzBJFJHwk_003D;
			_0023_003DzvXOLtKg_003D = _0023_003Dz40R7bAU_003D;
		}

		public _0023_003DzfmsdmcfcBmDX(int _0023_003DzBJFJHwk_003D, int _0023_003Dz40R7bAU_003D, Point3D _0023_003DzH_310p2vtnon, Point2D _0023_003Dz9KfPrzVPEGNp, ICurve _0023_003Dz7Na50TwZ6aP6)
			: this(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D)
		{
			_0023_003Dz4701yxQ2_0024axv = _0023_003Dz7Na50TwZ6aP6;
			_0023_003Dz114WmwtBjoiC = _0023_003DzH_310p2vtnon;
			_0023_003DzfoNNk4xzIdOW = _0023_003Dz9KfPrzVPEGNp;
		}

		public _0023_003DzfmsdmcfcBmDX(int _0023_003DzBJFJHwk_003D, int _0023_003Dz40R7bAU_003D, Point3D _0023_003DzH_310p2vtnon, bool _0023_003DzfxRH11yqtER41XYo5w_003D_003D, bool _0023_003Dz2uRRF4k_003D, bool _0023_003Dz4sg0Qp0_003D, double _0023_003DzbvIFYko_003D)
			: this(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D)
		{
			_0023_003Dz114WmwtBjoiC = _0023_003DzH_310p2vtnon;
			_0023_003Dz9h5MY_A_003D = _0023_003DzfxRH11yqtER41XYo5w_003D_003D;
			_0023_003DzQuOBdG0_003D = _0023_003Dz2uRRF4k_003D;
			this._0023_003Dz4sg0Qp0_003D = _0023_003Dz4sg0Qp0_003D;
			this._0023_003DzbvIFYko_003D = _0023_003DzbvIFYko_003D;
			_0023_003Dz114WmwtBjoiC = _0023_003DzH_310p2vtnon;
		}

		protected _0023_003DzfmsdmcfcBmDX(_0023_003DzfmsdmcfcBmDX _0023_003Dzl_0024MIsC0_003D)
		{
			_0023_003Dzyk2fsPo_003D = _0023_003Dzl_0024MIsC0_003D._0023_003Dzyk2fsPo_003D;
			_0023_003DzvXOLtKg_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzvXOLtKg_003D;
			_0023_003Dz9h5MY_A_003D = _0023_003Dzl_0024MIsC0_003D._0023_003Dz9h5MY_A_003D;
			_0023_003DzQuOBdG0_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzQuOBdG0_003D;
			_0023_003DzAzKc5gs_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzY5Z6MBUHWoYl();
			_0023_003Dz4sg0Qp0_003D = _0023_003Dzl_0024MIsC0_003D._0023_003Dz4sg0Qp0_003D;
			_0023_003DzbvIFYko_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzbvIFYko_003D;
			_0023_003DzYqBTSeQ_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzYqBTSeQ_003D;
			_0023_003DzWdV9UYA_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzWdV9UYA_003D;
			_0023_003DzzAvTK7EbICGAsFTsLg_003D_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzzAvTK7EbICGAsFTsLg_003D_003D;
			_0023_003Dz4701yxQ2_0024axv = _0023_003Dzl_0024MIsC0_003D._0023_003Dz4701yxQ2_0024axv;
			_0023_003DzEemH6ZA_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzEemH6ZA_003D;
			_0023_003Dzg_d2bCm63KSux51d6w_003D_003D = _0023_003Dzl_0024MIsC0_003D._0023_003Dzg_d2bCm63KSux51d6w_003D_003D;
			_0023_003DzQC2DY_0024geS4zZUaYo9w_003D_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzQC2DY_0024geS4zZUaYo9w_003D_003D;
			_0023_003Dz114WmwtBjoiC = _0023_003Dzl_0024MIsC0_003D._0023_003Dz114WmwtBjoiC;
			_0023_003DzfoNNk4xzIdOW = _0023_003Dzl_0024MIsC0_003D._0023_003DzfoNNk4xzIdOW;
			_0023_003DzSH3vxKnk5iwK = _0023_003Dzl_0024MIsC0_003D._0023_003DzSH3vxKnk5iwK;
			_0023_003DzCj8_mR_aKjyZ = _0023_003Dzl_0024MIsC0_003D._0023_003DzCj8_mR_aKjyZ;
			_0023_003DzEgpGqIM_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzEgpGqIM_003D;
			_0023_003Dz4L1sj_w_003D = _0023_003Dzl_0024MIsC0_003D._0023_003Dz4L1sj_w_003D;
			_0023_003DzB62SYmA_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzB62SYmA_003D;
		}

		public bool _0023_003DzY5Z6MBUHWoYl()
		{
			return _0023_003DzAzKc5gs_003D;
		}

		public void _0023_003Dz_0024a3VthF_8pao(bool _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzAzKc5gs_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public void _0023_003Dz93KtgaWGOsqQPtBnSw_003D_003D()
		{
			if (!_0023_003DzzAvTK7EbICGAsFTsLg_003D_003D)
			{
				_0023_003DzYqBTSeQ_003D = _0023_003Dzyk2fsPo_003D;
				_0023_003DzWdV9UYA_003D = _0023_003DzvXOLtKg_003D;
			}
			_0023_003DzzAvTK7EbICGAsFTsLg_003D_003D = true;
		}

		public bool _0023_003DzZ3ksEgvbBuVbWPJIhA_003D_003D()
		{
			bool result = _0023_003DzzAvTK7EbICGAsFTsLg_003D_003D;
			if (_0023_003DzzAvTK7EbICGAsFTsLg_003D_003D)
			{
				_0023_003Dzyk2fsPo_003D = _0023_003DzYqBTSeQ_003D;
				_0023_003DzvXOLtKg_003D = _0023_003DzWdV9UYA_003D;
			}
			_0023_003DzzAvTK7EbICGAsFTsLg_003D_003D = false;
			return result;
		}

		public Point2D _0023_003Dz6AHwI_o_003D(IntegerGrid _0023_003DzOSo8vaE_003D)
		{
			if (_0023_003DzzAvTK7EbICGAsFTsLg_003D_003D)
			{
				return _0023_003Dz6AHwI_o_003D(_0023_003DzYqBTSeQ_003D, _0023_003DzWdV9UYA_003D, _0023_003DzOSo8vaE_003D);
			}
			return _0023_003Dz6AHwI_o_003D(_0023_003Dzyk2fsPo_003D, _0023_003DzvXOLtKg_003D, _0023_003DzOSo8vaE_003D);
		}

		public static Point2D _0023_003Dz6AHwI_o_003D(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, IntegerGrid _0023_003DzOSo8vaE_003D)
		{
			_0023_003DzOSo8vaE_003D.ScaleToWorld((int)_0023_003DzBJFJHwk_003D, (int)_0023_003Dz40R7bAU_003D, out var x, out var y);
			return new Point2D(x, y);
		}

		public bool Equals(_0023_003DzfmsdmcfcBmDX _0023_003Dzl_0024MIsC0_003D)
		{
			if (_0023_003Dzl_0024MIsC0_003D._0023_003Dzyk2fsPo_003D == _0023_003Dzyk2fsPo_003D)
			{
				return _0023_003Dzl_0024MIsC0_003D._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Format(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302977515), _0023_003Dzyk2fsPo_003D, _0023_003DzvXOLtKg_003D);
		}

		public virtual object Clone()
		{
			return new _0023_003DzfmsdmcfcBmDX(this);
		}

		internal void _0023_003DztiahX8OVVxEu(_0023_003Dz_0024WkMNd__uiAK _0023_003DzhKgpEajMn2EQcrVq6A_003D_003D, System.Drawing.Point _0023_003Dzwo5LU3bv1PZc, bool _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D)
		{
			_0023_003Dz93KtgaWGOsqQPtBnSw_003D_003D();
			int num = _0023_003DzvXOLtKg_003D - _0023_003DzWdV9UYA_003D;
			if (num == 0)
			{
				if (_0023_003DzvXOLtKg_003D < 0)
				{
					_0023_003DzvXOLtKg_003D++;
				}
				else
				{
					_0023_003DzvXOLtKg_003D--;
				}
			}
			else
			{
				num += Math.Sign(num);
				_0023_003DzvXOLtKg_003D = _0023_003DzWdV9UYA_003D + num;
			}
			bool _0023_003Dz7R4nzv0_003D;
			bool flag = _0023_003DzHRi2oS0_003D(_0023_003Dzwo5LU3bv1PZc, _0023_003DzhKgpEajMn2EQcrVq6A_003D_003D, _0023_003DzxInY1_piQJ1x: false, out _0023_003Dz7R4nzv0_003D);
			if ((flag && _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D) || (!flag && !_0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D))
			{
				num = _0023_003DzvXOLtKg_003D - _0023_003DzWdV9UYA_003D;
				_0023_003DzvXOLtKg_003D = _0023_003DzWdV9UYA_003D - num;
			}
		}

		internal void _0023_003Dz_0024XzHXc_t9UEOpUYn2g_003D_003D(_0023_003DzfmsdmcfcBmDX _0023_003Dzl_0024MIsC0_003D)
		{
			_0023_003DzYqBTSeQ_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzYqBTSeQ_003D;
			_0023_003DzWdV9UYA_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzWdV9UYA_003D;
			_0023_003DzzAvTK7EbICGAsFTsLg_003D_003D = _0023_003Dzl_0024MIsC0_003D._0023_003DzzAvTK7EbICGAsFTsLg_003D_003D;
		}

		internal void _0023_003DzuRCltcmxc7rjJVbEcQ_003D_003D()
		{
			if (_0023_003DzEemH6ZA_003D != null)
			{
				ICurve curve = _0023_003Dz4701yxQ2_0024axv;
				_0023_003Dz4701yxQ2_0024axv = _0023_003DzEemH6ZA_003D;
				_0023_003DzEemH6ZA_003D = curve;
			}
		}

		internal void _0023_003DzpJBW3GU_003D()
		{
			_0023_003Dz9h5MY_A_003D = false;
			_0023_003DzQuOBdG0_003D = false;
			_0023_003Dz4sg0Qp0_003D = false;
			_0023_003Dzg_d2bCm63KSux51d6w_003D_003D = null;
			_0023_003DzQC2DY_0024geS4zZUaYo9w_003D_003D = null;
			_0023_003DzbvIFYko_003D = 0.0;
		}

		internal bool _0023_003DzHRi2oS0_003D(System.Drawing.Point _0023_003Dzwo5LU3bv1PZc, _0023_003Dz_0024WkMNd__uiAK _0023_003DzZNSKUSRwljLL, bool _0023_003DzxInY1_piQJ1x, out bool _0023_003Dz7R4nzv0_003D)
		{
			int num = 0;
			_0023_003Dz7R4nzv0_003D = false;
			_0023_003DzfmsdmcfcBmDX _0023_003DzcXkiOibhYRCo = new _0023_003DzfmsdmcfcBmDX();
			double _0023_003Dz2HQExmey0Efn = 0.0;
			double _0023_003DzVK4_0024oHG2kIT = 0.0;
			if (_0023_003Dzyk2fsPo_003D < _0023_003Dzwo5LU3bv1PZc.X)
			{
				_0023_003Dzwo5LU3bv1PZc.X = _0023_003Dzyk2fsPo_003D - 5;
			}
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003Dz_0024WkMNd__uiAK._0023_003DzYsYhGdI_003D(_0023_003Dzwo5LU3bv1PZc.X, _0023_003DzvXOLtKg_003D, null, _0023_003DzfxRH11yqtER41XYo5w_003D_003D: false, _0023_003Dz2uRRF4k_003D: false, _0023_003Dz4sg0Qp0_003D: false, 0.0);
			List<_0023_003DzfmsdmcfcBmDX> list = new List<_0023_003DzfmsdmcfcBmDX>();
			List<_0023_003DzfmsdmcfcBmDX> list2 = new List<_0023_003DzfmsdmcfcBmDX>();
			num = 0;
			for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode2 = _0023_003DzZNSKUSRwljLL._0023_003DzvRAdRPd11xUJ().First; linkedListNode2.Next != null; linkedListNode2 = linkedListNode2.Next)
			{
				if (linkedListNode2.Value._0023_003Dz9h5MY_A_003D)
				{
					continue;
				}
				LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode3 = linkedListNode2.Next;
				if ((linkedListNode2.Value._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D && linkedListNode3.Value._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D && ((linkedListNode2.Value._0023_003Dzyk2fsPo_003D <= _0023_003Dzyk2fsPo_003D && linkedListNode3.Value._0023_003Dzyk2fsPo_003D >= _0023_003Dzyk2fsPo_003D) || (linkedListNode3.Value._0023_003Dzyk2fsPo_003D <= _0023_003Dzyk2fsPo_003D && linkedListNode2.Value._0023_003Dzyk2fsPo_003D >= _0023_003Dzyk2fsPo_003D))) || (linkedListNode2.Value._0023_003Dzyk2fsPo_003D == _0023_003Dzyk2fsPo_003D && linkedListNode3.Value._0023_003Dzyk2fsPo_003D == _0023_003Dzyk2fsPo_003D && ((linkedListNode2.Value._0023_003DzvXOLtKg_003D <= _0023_003DzvXOLtKg_003D && linkedListNode3.Value._0023_003DzvXOLtKg_003D >= _0023_003DzvXOLtKg_003D) || (linkedListNode3.Value._0023_003DzvXOLtKg_003D <= _0023_003DzvXOLtKg_003D && linkedListNode2.Value._0023_003DzvXOLtKg_003D >= _0023_003DzvXOLtKg_003D))))
				{
					return false;
				}
				while (linkedListNode3 != null && linkedListNode3.Value._0023_003Dz9h5MY_A_003D)
				{
					linkedListNode3 = linkedListNode3.Next;
				}
				_0023_003DzfmsdmcfcBmDX value = linkedListNode2.Value;
				_0023_003DzfmsdmcfcBmDX value2 = linkedListNode3.Value;
				if ((value._0023_003Dzyk2fsPo_003D <= _0023_003Dzyk2fsPo_003D && value._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D) || (value2._0023_003Dzyk2fsPo_003D <= _0023_003Dzyk2fsPo_003D && value2._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D))
				{
					if (value._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D)
					{
						if (list.Contains(value))
						{
							if (value2._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D && !list.Contains(value2))
							{
								list.Add(value2);
							}
							continue;
						}
						list.Add(value);
					}
					if (value2._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D)
					{
						if (list.Contains(value2))
						{
							if (value._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D && !list.Contains(value))
							{
								list.Add(value);
							}
							continue;
						}
						list.Add(value2);
					}
					LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode4 = linkedListNode2;
					while (linkedListNode4.Value._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D)
					{
						linkedListNode4 = Utility.CircularPrevious(linkedListNode4);
						if (linkedListNode4 == linkedListNode2)
						{
							_0023_003Dz7R4nzv0_003D = true;
							return false;
						}
					}
					if (list2.Contains(linkedListNode4.Value))
					{
						continue;
					}
					list2.Add(linkedListNode4.Value);
					LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode5 = linkedListNode3;
					while (linkedListNode3.Value._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D)
					{
						linkedListNode3 = Utility.CircularNext(linkedListNode3);
						if (linkedListNode3 == linkedListNode5)
						{
							_0023_003Dz7R4nzv0_003D = true;
							return false;
						}
					}
					if (Math.Sign(_0023_003DzvXOLtKg_003D - linkedListNode4.Value._0023_003DzvXOLtKg_003D) != Math.Sign(_0023_003DzvXOLtKg_003D - linkedListNode3.Value._0023_003DzvXOLtKg_003D))
					{
						num++;
					}
				}
				else if (_0023_003DzQ7usAag_003D(linkedListNode.Value, this, value, value2, ref _0023_003Dz2HQExmey0Efn, ref _0023_003DzVK4_0024oHG2kIT, ref _0023_003DzcXkiOibhYRCo))
				{
					num++;
				}
			}
			if (_0023_003DzxInY1_piQJ1x)
			{
				_0023_003DzfmsdmcfcBmDX value3 = _0023_003DzZNSKUSRwljLL._0023_003DzvRAdRPd11xUJ().First.Value;
				_0023_003DzfmsdmcfcBmDX value4 = _0023_003DzZNSKUSRwljLL._0023_003DzvRAdRPd11xUJ().Last.Value;
				if (_0023_003DzQ7usAag_003D(linkedListNode.Value, this, value3, value4, ref _0023_003Dz2HQExmey0Efn, ref _0023_003DzVK4_0024oHG2kIT, ref _0023_003DzcXkiOibhYRCo))
				{
					num++;
				}
			}
			return num % 2 == 1;
		}

		internal void _0023_003Dz0ejirpp2cjCb(System.Drawing.Point _0023_003Dzwo5LU3bv1PZc, _0023_003Dz_0024WkMNd__uiAK _0023_003DzZNSKUSRwljLL, bool _0023_003DzxInY1_piQJ1x)
		{
			_0023_003DzAzKc5gs_003D = _0023_003DzHRi2oS0_003D(_0023_003Dzwo5LU3bv1PZc, _0023_003DzZNSKUSRwljLL, _0023_003DzxInY1_piQJ1x, out var _);
		}

		public bool _0023_003DzVuaiNJMDKH2i(_0023_003Dz_0024WkMNd__uiAK _0023_003DzfNcJFckY8UeA)
		{
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzfNcJFckY8UeA._0023_003DzvRAdRPd11xUJ())
			{
				if (item._0023_003Dzyk2fsPo_003D <= _0023_003Dzyk2fsPo_003D && item._0023_003DzvXOLtKg_003D == _0023_003DzvXOLtKg_003D)
				{
					return true;
				}
			}
			return false;
		}

		public void _0023_003Dz0sl12EOIB4N_002401cAIA_003D_003D(Segment2D _0023_003DzFDJdA7A_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzZNSKUSRwljLL, System.Drawing.Point _0023_003Dzwo5LU3bv1PZc, bool _0023_003Dzx3_8Ey_HzTH_0024, bool _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D)
		{
			int num = _0023_003Dzyk2fsPo_003D;
			int num2 = _0023_003DzvXOLtKg_003D;
			_0023_003Dz93KtgaWGOsqQPtBnSw_003D_003D();
			bool flag = false;
			for (int i = 0; i < 2; i++)
			{
				for (int j = 1; j < 5; j++)
				{
					if (flag)
					{
						break;
					}
					int num3 = 0;
					while (num3 < _0023_003DzhTBDVLsjjzaJPkBNFQ_003D_003D.Length)
					{
						int num4 = num + _0023_003DzhTBDVLsjjzaJPkBNFQ_003D_003D[num3++] * j;
						int num5 = num2 + _0023_003DzhTBDVLsjjzaJPkBNFQ_003D_003D[num3++] * j;
						_0023_003Dzyk2fsPo_003D = num4;
						_0023_003DzvXOLtKg_003D = num5;
						if (_0023_003DzAyiJ0w9kCzId(_0023_003DzFDJdA7A_003D))
						{
							continue;
						}
						if (_0023_003Dzx3_8Ey_HzTH_0024)
						{
							bool _0023_003Dz7R4nzv0_003D;
							bool flag2 = _0023_003DzHRi2oS0_003D(_0023_003Dzwo5LU3bv1PZc, _0023_003DzZNSKUSRwljLL, _0023_003DzxInY1_piQJ1x: false, out _0023_003Dz7R4nzv0_003D);
							if (_0023_003Dz7R4nzv0_003D)
							{
								continue;
							}
							if (_0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D)
							{
								if (!flag2)
								{
									flag = true;
									break;
								}
							}
							else if (flag2)
							{
								flag = true;
								break;
							}
							continue;
						}
						flag = true;
						break;
					}
				}
				if (flag)
				{
					break;
				}
				_0023_003Dzx3_8Ey_HzTH_0024 = false;
			}
			_0023_003DzzAvTK7EbICGAsFTsLg_003D_003D = true;
		}

		internal bool _0023_003DzAyiJ0w9kCzId(Segment2D _0023_003DzFDJdA7A_003D)
		{
			double num = _0023_003DzFDJdA7A_003D.Project(new Point2D(_0023_003Dzyk2fsPo_003D, _0023_003DzvXOLtKg_003D));
			if (num >= 0.0 && num <= 1.0)
			{
				Point2D point2D = _0023_003DzFDJdA7A_003D.PointAt(num);
				if ((_0023_003Dzyk2fsPo_003D == (int)Math.Floor(point2D.X) || _0023_003Dzyk2fsPo_003D == (int)Math.Ceiling(point2D.X)) && (_0023_003DzvXOLtKg_003D == (int)Math.Floor(point2D.Y) || _0023_003DzvXOLtKg_003D == (int)Math.Ceiling(point2D.Y)))
				{
					return true;
				}
			}
			return false;
		}
	}

	private static int _0023_003DzId5C3LA_003D = 10;

	private static double _0023_003DzXMGjKnoZdqec(double _0023_003Dz3YfTAqg_003D, double _0023_003DzpilgH4E_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz8qV981c_003D)
	{
		return Math.Sqrt((_0023_003Dz3YfTAqg_003D - _0023_003DzRFb1SGo_003D) * (_0023_003Dz3YfTAqg_003D - _0023_003DzRFb1SGo_003D) + (_0023_003DzpilgH4E_003D - _0023_003Dz8qV981c_003D) * (_0023_003DzpilgH4E_003D - _0023_003Dz8qV981c_003D));
	}

	private static bool _0023_003DzQ7usAag_003D(_0023_003DzfmsdmcfcBmDX _0023_003DzFj_0024IqDQ_003D, _0023_003DzfmsdmcfcBmDX _0023_003DzjdeMMkk_003D, _0023_003DzfmsdmcfcBmDX _0023_003Dz7ZE84gQ_003D, _0023_003DzfmsdmcfcBmDX _0023_003DzYENOV_Q_003D, ref double _0023_003Dz2HQExmey0Efn, ref double _0023_003DzVK4_0024oHG2kIT8, ref _0023_003DzfmsdmcfcBmDX _0023_003DzcXkiOibhYRCo)
	{
		double num = (double)(_0023_003DzjdeMMkk_003D._0023_003Dzyk2fsPo_003D - _0023_003DzFj_0024IqDQ_003D._0023_003Dzyk2fsPo_003D) * (double)(_0023_003DzYENOV_Q_003D._0023_003DzvXOLtKg_003D - _0023_003Dz7ZE84gQ_003D._0023_003DzvXOLtKg_003D) - (double)(_0023_003DzjdeMMkk_003D._0023_003DzvXOLtKg_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzvXOLtKg_003D) * (double)(_0023_003DzYENOV_Q_003D._0023_003Dzyk2fsPo_003D - _0023_003Dz7ZE84gQ_003D._0023_003Dzyk2fsPo_003D);
		if (num == 0.0)
		{
			return false;
		}
		double num2 = ((double)(_0023_003Dz7ZE84gQ_003D._0023_003Dzyk2fsPo_003D - _0023_003DzFj_0024IqDQ_003D._0023_003Dzyk2fsPo_003D) * (double)(_0023_003DzYENOV_Q_003D._0023_003DzvXOLtKg_003D - _0023_003Dz7ZE84gQ_003D._0023_003DzvXOLtKg_003D) - (double)(_0023_003Dz7ZE84gQ_003D._0023_003DzvXOLtKg_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzvXOLtKg_003D) * (double)(_0023_003DzYENOV_Q_003D._0023_003Dzyk2fsPo_003D - _0023_003Dz7ZE84gQ_003D._0023_003Dzyk2fsPo_003D)) / num;
		double num3 = ((double)(_0023_003DzjdeMMkk_003D._0023_003DzvXOLtKg_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzvXOLtKg_003D) * (double)(_0023_003Dz7ZE84gQ_003D._0023_003Dzyk2fsPo_003D - _0023_003DzFj_0024IqDQ_003D._0023_003Dzyk2fsPo_003D) - (double)(_0023_003DzjdeMMkk_003D._0023_003Dzyk2fsPo_003D - _0023_003DzFj_0024IqDQ_003D._0023_003Dzyk2fsPo_003D) * (double)(_0023_003Dz7ZE84gQ_003D._0023_003DzvXOLtKg_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzvXOLtKg_003D)) / num;
		if (num2 < 0.0 || num2 > 1.0 || num3 < 0.0 || num3 > 1.0)
		{
			return false;
		}
		double num4 = (double)_0023_003DzFj_0024IqDQ_003D._0023_003Dzyk2fsPo_003D + num2 * (double)(_0023_003DzjdeMMkk_003D._0023_003Dzyk2fsPo_003D - _0023_003DzFj_0024IqDQ_003D._0023_003Dzyk2fsPo_003D);
		double num5 = (double)_0023_003DzFj_0024IqDQ_003D._0023_003DzvXOLtKg_003D + num2 * (double)(_0023_003DzjdeMMkk_003D._0023_003DzvXOLtKg_003D - _0023_003DzFj_0024IqDQ_003D._0023_003DzvXOLtKg_003D);
		_0023_003Dz2HQExmey0Efn = _0023_003DzXMGjKnoZdqec(_0023_003DzFj_0024IqDQ_003D._0023_003Dzyk2fsPo_003D, _0023_003DzFj_0024IqDQ_003D._0023_003DzvXOLtKg_003D, num4, num5) / _0023_003DzXMGjKnoZdqec(_0023_003DzFj_0024IqDQ_003D._0023_003Dzyk2fsPo_003D, _0023_003DzFj_0024IqDQ_003D._0023_003DzvXOLtKg_003D, _0023_003DzjdeMMkk_003D._0023_003Dzyk2fsPo_003D, _0023_003DzjdeMMkk_003D._0023_003DzvXOLtKg_003D);
		_0023_003DzVK4_0024oHG2kIT8 = _0023_003DzXMGjKnoZdqec(_0023_003Dz7ZE84gQ_003D._0023_003Dzyk2fsPo_003D, _0023_003Dz7ZE84gQ_003D._0023_003DzvXOLtKg_003D, num4, num5) / _0023_003DzXMGjKnoZdqec(_0023_003Dz7ZE84gQ_003D._0023_003Dzyk2fsPo_003D, _0023_003Dz7ZE84gQ_003D._0023_003DzvXOLtKg_003D, _0023_003DzYENOV_Q_003D._0023_003Dzyk2fsPo_003D, _0023_003DzYENOV_Q_003D._0023_003DzvXOLtKg_003D);
		if (_0023_003Dz2HQExmey0Efn > 1.0 || _0023_003DzVK4_0024oHG2kIT8 > 1.0)
		{
			return false;
		}
		_0023_003DzcXkiOibhYRCo = new _0023_003DzfmsdmcfcBmDX((int)Math.Round(num4), (int)Math.Round(num5));
		return true;
	}

	private static bool _0023_003DzLBqh6huMhq3g(int _0023_003DzjTLb8o0_003D, _0023_003DzfmsdmcfcBmDX _0023_003DzRXJWLHs_003D, LinkedList<_0023_003DzfmsdmcfcBmDX> _0023_003Dzj0L77MsgaAQ0jTCZ3g_003D_003D)
	{
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = new LinkedListNode<_0023_003DzfmsdmcfcBmDX>(new _0023_003DzfmsdmcfcBmDX());
		int num = 0;
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode2 = _0023_003Dz_0024WkMNd__uiAK._0023_003DzYsYhGdI_003D(_0023_003DzjTLb8o0_003D, _0023_003DzRXJWLHs_003D._0023_003DzvXOLtKg_003D, null, _0023_003DzfxRH11yqtER41XYo5w_003D_003D: false, _0023_003Dz2uRRF4k_003D: false, _0023_003Dz4sg0Qp0_003D: false, 0.0);
		_0023_003DzfmsdmcfcBmDX _0023_003DzcXkiOibhYRCo = new _0023_003DzfmsdmcfcBmDX();
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode3 = _0023_003Dzj0L77MsgaAQ0jTCZ3g_003D_003D.First;
		while (linkedListNode3.Next != null)
		{
			if (_0023_003DzQ7usAag_003D(linkedListNode2.Value, _0023_003DzRXJWLHs_003D, linkedListNode3.Value, linkedListNode3.Next.Value, ref linkedListNode.Value._0023_003DzbvIFYko_003D, ref linkedListNode.Value._0023_003DzbvIFYko_003D, ref _0023_003DzcXkiOibhYRCo))
			{
				num++;
			}
			linkedListNode3 = linkedListNode3.Next;
		}
		return num % 2 != 0;
	}

	private static IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzUBL_Skv6O_OA(_0023_003Dz_0024WkMNd__uiAK _0023_003DzqOPTvuc_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzwHi0Ebs_003D, IntegerGrid _0023_003DzOSo8vaE_003D, _0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D, double _0023_003DzccAR5G0_003D, out _0023_003DzRrz47AY_003D _0023_003DzS1hTxrs_003D)
	{
		_0023_003DzqOPTvuc_003D._0023_003Dz24j_0024P5iRocZH6WTXsQyiE9gFVerX();
		_0023_003DzwHi0Ebs_003D._0023_003Dz24j_0024P5iRocZH6WTXsQyiE9gFVerX();
		_0023_003DzfmsdmcfcBmDX[] array = _0023_003DzqOPTvuc_003D._0023_003DzBQWed6E_003D();
		_0023_003DzfmsdmcfcBmDX[] array2 = _0023_003DzwHi0Ebs_003D._0023_003DzBQWed6E_003D();
		IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D = _0023_003Dz8Fgh2f0_003D(_0023_003DzqOPTvuc_003D, _0023_003DzwHi0Ebs_003D, _0023_003DzwY9ClXw_003D, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D, out _0023_003DzS1hTxrs_003D);
		_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D = _0023_003DzpJBW3GU_003D(_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D);
		foreach (_0023_003Dz_0024WkMNd__uiAK item in _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D)
		{
			item._0023_003DzNKw2dpKrk09r();
		}
		for (int i = 0; i < array.Length; i++)
		{
			array[i]._0023_003DzpJBW3GU_003D();
		}
		for (int j = 0; j < array2.Length; j++)
		{
			array2[j]._0023_003DzpJBW3GU_003D();
		}
		_0023_003DzqOPTvuc_003D._0023_003DzadQMJ9f_0024sjU5(new LinkedList<_0023_003DzfmsdmcfcBmDX>(array));
		_0023_003DzwHi0Ebs_003D._0023_003DzadQMJ9f_0024sjU5(new LinkedList<_0023_003DzfmsdmcfcBmDX>(array2));
		return _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D;
	}

	private static IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzpJBW3GU_003D(IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D)
	{
		foreach (_0023_003Dz_0024WkMNd__uiAK item in _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D)
		{
			_0023_003DzpJBW3GU_003D(item);
		}
		return _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D;
	}

	private static void _0023_003DzpJBW3GU_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzYVDIcYzAKAZM)
	{
		for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzYVDIcYzAKAZM._0023_003DzvRAdRPd11xUJ().First; linkedListNode != null; linkedListNode = linkedListNode.Next)
		{
			linkedListNode.Value._0023_003DzpJBW3GU_003D();
		}
	}

	private static bool _0023_003DzwZPdF9ZgnavU(_0023_003Dz_0024WkMNd__uiAK _0023_003DzYVDIcYzAKAZM, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dzl_0024MIsC0_003D, ref LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz77g161c_003D)
	{
		if (_0023_003Dzl_0024MIsC0_003D == null)
		{
			return false;
		}
		if (_0023_003Dzl_0024MIsC0_003D.Value._0023_003Dzyk2fsPo_003D == _0023_003Dz77g161c_003D.Value._0023_003Dzyk2fsPo_003D)
		{
			return _0023_003Dzl_0024MIsC0_003D.Value._0023_003DzvXOLtKg_003D == _0023_003Dz77g161c_003D.Value._0023_003DzvXOLtKg_003D;
		}
		return false;
	}

	internal static IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzoTH8BDg_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzWWM1xAOWHgQ8_0024A_i_0024Q_003D_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzDwIjCLjE396MTT3iUA_003D_003D, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzccAR5G0_003D, out _0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D)
	{
		return _0023_003DzUBL_Skv6O_OA(_0023_003DzWWM1xAOWHgQ8_0024A_i_0024Q_003D_003D, _0023_003DzDwIjCLjE396MTT3iUA_003D_003D, _0023_003DzOSo8vaE_003D, (_0023_003Dz4JAfHNw_003D)2, _0023_003DzccAR5G0_003D, out _0023_003DzOLHnb2M_003D);
	}

	internal static IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzrIsIvtI_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzWWM1xAOWHgQ8_0024A_i_0024Q_003D_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzDwIjCLjE396MTT3iUA_003D_003D, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzccAR5G0_003D, out _0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D)
	{
		return _0023_003DzUBL_Skv6O_OA(_0023_003DzWWM1xAOWHgQ8_0024A_i_0024Q_003D_003D, _0023_003DzDwIjCLjE396MTT3iUA_003D_003D, _0023_003DzOSo8vaE_003D, (_0023_003Dz4JAfHNw_003D)0, _0023_003DzccAR5G0_003D, out _0023_003DzOLHnb2M_003D);
	}

	internal static IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzQ7usAag_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzWWM1xAOWHgQ8_0024A_i_0024Q_003D_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzDwIjCLjE396MTT3iUA_003D_003D, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzccAR5G0_003D)
	{
		_0023_003DzRrz47AY_003D _0023_003DzS1hTxrs_003D;
		return _0023_003DzUBL_Skv6O_OA(_0023_003DzWWM1xAOWHgQ8_0024A_i_0024Q_003D_003D, _0023_003DzDwIjCLjE396MTT3iUA_003D_003D, _0023_003DzOSo8vaE_003D, (_0023_003Dz4JAfHNw_003D)1, _0023_003DzccAR5G0_003D, out _0023_003DzS1hTxrs_003D);
	}

	internal static IList<ICurve> _0023_003DzxIk9oLRZ3P_UYVarSg_003D_003D(IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, Plane _0023_003Dzk536MKmgTmXR, IList<ICurve> _0023_003DzsUBBDcojghFsw5ZlgeXRUHND09DP, _0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D, out bool _0023_003DzMF8k7sk_003D, out _0023_003DzOmuoKv8_003D _0023_003DzOmuoKv8_003D)
	{
		double _0023_003DzccAR5G0_003D;
		List<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D;
		IList<_0023_003Dz_0024WkMNd__uiAK> list = _0023_003DzQEO7lnTvsOTJPFHeyw_003D_003D(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, _0023_003Dzk536MKmgTmXR, _0023_003DzsUBBDcojghFsw5ZlgeXRUHND09DP, _0023_003DzwY9ClXw_003D, out _0023_003DzMF8k7sk_003D, out _0023_003DzccAR5G0_003D, out _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D, out _0023_003DzOmuoKv8_003D);
		List<ICurve> list2 = new List<ICurve>();
		for (int i = 0; i < list.Count; i++)
		{
			ICurve curve = devDept.Eyeshot.Entities.Region._0023_003DzeZ7O7Q63sCoZHyFeRkPgfNPpZ1Jd(_0023_003Dzk536MKmgTmXR, list[i], _0023_003DzccAR5G0_003D);
			if (curve != null)
			{
				list2.Add(curve);
			}
		}
		for (int j = 0; j < _0023_003DzsUBBDcojghFsw5ZlgeXRUHND09DP.Count; j++)
		{
			if (_0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D[j]._0023_003Dz1XcTvJ4AwHv6)
			{
				((Entity)_0023_003DzsUBBDcojghFsw5ZlgeXRUHND09DP[j]).EntityData = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302976430);
			}
		}
		return list2;
	}

	internal static IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzQEO7lnTvsOTJPFHeyw_003D_003D(IList<ICurve> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, Plane _0023_003Dzk536MKmgTmXR, IList<ICurve> _0023_003DzsUBBDcojghFsw5ZlgeXRUHND09DP, _0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D, out bool _0023_003DzMF8k7sk_003D, out double _0023_003DzccAR5G0_003D, out List<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D, out _0023_003DzOmuoKv8_003D _0023_003DzOmuoKv8_003D)
	{
		Transformation transformation = new Identity();
		List<_0023_003Dz_0024WkMNd__uiAK> list = new List<_0023_003Dz_0024WkMNd__uiAK>();
		List<IList<ICurve>> list2 = new List<IList<ICurve>>();
		List<IList<IList<Point3D>>> list3 = new List<IList<IList<Point3D>>>();
		List<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D> list4 = new List<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D>();
		IList<ICurve> _0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D;
		IList<IList<Point3D>> _0023_003DzHXSVUTwh6gQ_0024;
		IList<IList<Point2D>> _0023_003DzYxZZbrD9Me8i;
		foreach (ICurve item in _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D)
		{
			double _0023_003Dzm0CYiiE_003D = Utility._0023_003DzcWsuvoQfLK3L((Entity)item);
			transformation.Rotation(_0023_003Dzk536MKmgTmXR, Plane.XY);
			devDept.Eyeshot.Entities.Region._0023_003Dz0sa9p8vGG_0024_0024N(transformation, item, _0023_003Dzm0CYiiE_003D, out _0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D, out _0023_003DzHXSVUTwh6gQ_0024, out _0023_003DzYxZZbrD9Me8i);
			list3.Add(_0023_003DzHXSVUTwh6gQ_0024);
			list4.Add(new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D(_0023_003DzYxZZbrD9Me8i));
			list2.Add(_0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D);
		}
		List<IList<ICurve>> list5 = new List<IList<ICurve>>();
		List<IList<IList<Point3D>>> list6 = new List<IList<IList<Point3D>>>();
		List<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D> list7 = new List<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D>();
		if (_0023_003DzsUBBDcojghFsw5ZlgeXRUHND09DP != null)
		{
			foreach (ICurve item2 in _0023_003DzsUBBDcojghFsw5ZlgeXRUHND09DP)
			{
				double _0023_003Dzm0CYiiE_003D2 = Utility._0023_003DzcWsuvoQfLK3L((Entity)item2);
				devDept.Eyeshot.Entities.Region._0023_003Dz0sa9p8vGG_0024_0024N(transformation, item2, _0023_003Dzm0CYiiE_003D2, out _0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D, out _0023_003DzHXSVUTwh6gQ_0024, out _0023_003DzYxZZbrD9Me8i);
				list5.Add(_0023_003DzgtVkMPDi8Qsuf5Nxp0JO0rs_003D);
				list6.Add(_0023_003DzHXSVUTwh6gQ_0024);
				list7.Add(new _0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D(_0023_003DzYxZZbrD9Me8i));
			}
		}
		List<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D> list8 = new List<_0023_003DzF8p8XwZtujPhsKu1niQtp3Y_003D>(list4);
		list8.AddRange(list7);
		Point2D _0023_003DzF7v9r2A_003D;
		Point2D _0023_003Dz8dK2uhU_003D;
		IntegerGrid _0023_003DzOSo8vaE_003D = _0023_003Dz_0024WkMNd__uiAK._0023_003Dz_LrsyseLeNti(devDept.Eyeshot.Entities.Region._0023_003Dz_0024cJ7ql_R_22_, list8, out _0023_003DzF7v9r2A_003D, out _0023_003Dz8dK2uhU_003D);
		for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; i++)
		{
			list.Add(new _0023_003Dz_0024WkMNd__uiAK(_0023_003Dzk536MKmgTmXR, list3[i], list4[i], list2[i], _0023_003DzOSo8vaE_003D));
		}
		_0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D = null;
		if (_0023_003DzsUBBDcojghFsw5ZlgeXRUHND09DP != null)
		{
			_0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D = new List<_0023_003Dz_0024WkMNd__uiAK>();
			for (int j = 0; j < _0023_003DzsUBBDcojghFsw5ZlgeXRUHND09DP.Count; j++)
			{
				_0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D.Add(new _0023_003Dz_0024WkMNd__uiAK(_0023_003Dzk536MKmgTmXR, list6[j], list7[j], list5[j], _0023_003DzOSo8vaE_003D));
			}
		}
		_0023_003DzMF8k7sk_003D = true;
		_0023_003DzccAR5G0_003D = new Size2D(_0023_003DzF7v9r2A_003D, _0023_003Dz8dK2uhU_003D).Diagonal;
		_0023_003DzOmuoKv8_003D = (_0023_003DzOmuoKv8_003D)0;
		_0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D;
		if (_0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D != null)
		{
			return _0023_003Dz09XvvvdBxwEZrfrvjQ_003D_003D(list, _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D, out _0023_003DzOLHnb2M_003D, out _0023_003DzMF8k7sk_003D, out _0023_003DzOmuoKv8_003D);
		}
		return _0023_003Dz8Fgh2f0_003D(list[0], list[1], _0023_003DzwY9ClXw_003D, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D, out _0023_003DzOLHnb2M_003D);
	}

	internal static double _0023_003DzcWsuvoQfLK3L(Entity _0023_003Dzs_0024uS8LA_003D)
	{
		Point3D[] array = _0023_003Dzs_0024uS8LA_003D.EstimateBoundingBox(null, null);
		Point3D maxValue = Point3D.MaxValue;
		Point3D minValue = Point3D.MinValue;
		Utility.UpdateMinMax(null, array, array.Length, maxValue, minValue);
		double num = new Size3D(maxValue, minValue).Diagonal * 0.001;
		if (num < 1E-06)
		{
			num = 1E-06;
		}
		return num;
	}

	private static IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003Dz8Fgh2f0_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzH8zaF5A8WC6a, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz2IDzvZDNJh6e, _0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzccAR5G0_003D, out _0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D)
	{
		List<_0023_003Dz_0024WkMNd__uiAK> list = new List<_0023_003Dz_0024WkMNd__uiAK>();
		if (_0023_003Dz1XaDMdch3IyA(_0023_003DzwY9ClXw_003D, _0023_003DzH8zaF5A8WC6a, _0023_003Dz2IDzvZDNJh6e, list, out _0023_003DzOLHnb2M_003D))
		{
			return list;
		}
		_0023_003DzOSo8vaE_003D.GridMin = new System.Drawing.Point(_0023_003DzOSo8vaE_003D.GridMin.X - 1, _0023_003DzOSo8vaE_003D.GridMin.Y - 1);
		bool _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D = _0023_003DzwY9ClXw_003D != (_0023_003Dz4JAfHNw_003D)0;
		bool _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D2 = _0023_003DzwY9ClXw_003D != (_0023_003Dz4JAfHNw_003D)2 && _0023_003DzwY9ClXw_003D != (_0023_003Dz4JAfHNw_003D)0;
		_0023_003Dz2IDzvZDNJh6e._0023_003DzmWcpFuZXVQcRMYa6GaIzQhg_003D(_0023_003DzH8zaF5A8WC6a, _0023_003DzOSo8vaE_003D.GridMin, _0023_003Dzx3_8Ey_HzTH_0024: true, _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D);
		_0023_003DzoirFDeXRPtSZ(_0023_003DzOSo8vaE_003D, _0023_003Dz2IDzvZDNJh6e);
		_0023_003DzH8zaF5A8WC6a._0023_003DzmWcpFuZXVQcRMYa6GaIzQhg_003D(_0023_003Dz2IDzvZDNJh6e, _0023_003DzOSo8vaE_003D.GridMin, _0023_003Dzx3_8Ey_HzTH_0024: true, _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D2);
		_0023_003DzoirFDeXRPtSZ(_0023_003DzOSo8vaE_003D, _0023_003DzH8zaF5A8WC6a);
		_0023_003Dz2IDzvZDNJh6e._0023_003DzmWcpFuZXVQcRMYa6GaIzQhg_003D(_0023_003DzH8zaF5A8WC6a, _0023_003DzOSo8vaE_003D.GridMin, _0023_003Dzx3_8Ey_HzTH_0024: true, _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D);
		_0023_003DzoirFDeXRPtSZ(_0023_003DzOSo8vaE_003D, _0023_003Dz2IDzvZDNJh6e);
		_0023_003DzH8zaF5A8WC6a._0023_003DzsLgX8rPGMRzTVKXIEQe0XgQ_003D(_0023_003Dz2IDzvZDNJh6e, _0023_003DzOSo8vaE_003D.GridMin);
		_0023_003Dz2IDzvZDNJh6e._0023_003DzsLgX8rPGMRzTVKXIEQe0XgQ_003D(_0023_003DzH8zaF5A8WC6a, _0023_003DzOSo8vaE_003D.GridMin);
		_0023_003DzADNPWX_0024bL47ygzDysGPf27s_003D(_0023_003DzOSo8vaE_003D, _0023_003DzH8zaF5A8WC6a, _0023_003Dz2IDzvZDNJh6e, _0023_003DzccAR5G0_003D);
		if (_0023_003DzVK3SyL83IH2S(_0023_003DzwY9ClXw_003D, _0023_003DzH8zaF5A8WC6a, _0023_003Dz2IDzvZDNJh6e, list, out _0023_003DzOLHnb2M_003D))
		{
			return list;
		}
		_0023_003DzH8zaF5A8WC6a._0023_003DzE0J67xyfENZSQDOyWQ_003D_003D();
		_0023_003Dz2IDzvZDNJh6e._0023_003DzE0J67xyfENZSQDOyWQ_003D_003D();
		_0023_003DzH8zaF5A8WC6a._0023_003DzjLOWNhS1yXjy();
		_0023_003Dz2IDzvZDNJh6e._0023_003DzjLOWNhS1yXjy();
		bool _0023_003DzB62SYmA_003D = true;
		bool _0023_003DzRVoDPs0_003D = true;
		while (true)
		{
			bool flag = true;
			bool _0023_003Dzq6gbnEWKa7KL;
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzJHE44z8_003D = _0023_003Dz_0024WkMNd__uiAK._0023_003Dz0QgarocZvTpt(_0023_003DzH8zaF5A8WC6a._0023_003DzvRAdRPd11xUJ().First, _0023_003DzwY9ClXw_003D, _0023_003DzRVoDPs0_003D, out _0023_003Dzq6gbnEWKa7KL);
			_0023_003DzRVoDPs0_003D = false;
			if (_0023_003DzJHE44z8_003D == null || _0023_003DzJHE44z8_003D.Value._0023_003Dz4sg0Qp0_003D)
			{
				break;
			}
			if (_0023_003DzwY9ClXw_003D == (_0023_003Dz4JAfHNw_003D)2 && _0023_003DzJHE44z8_003D.Value._0023_003Dz9h5MY_A_003D)
			{
				_0023_003DzJHE44z8_003D = _0023_003DzPiLzKI3b4WO3NJHc5CAa_002474_003D(_0023_003DzH8zaF5A8WC6a, _0023_003Dz2IDzvZDNJh6e, _0023_003DzOSo8vaE_003D, _0023_003DzJHE44z8_003D);
				if (_0023_003DzJHE44z8_003D.Value._0023_003Dz4sg0Qp0_003D)
				{
					break;
				}
			}
			if (_0023_003DzJHE44z8_003D.Value._0023_003DzY5Z6MBUHWoYl() && _0023_003DzwY9ClXw_003D == (_0023_003Dz4JAfHNw_003D)2)
			{
				break;
			}
			_0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK2 = new _0023_003Dz_0024WkMNd__uiAK(_0023_003DzH8zaF5A8WC6a._0023_003DzXCecWa6CYPEG);
			bool _0023_003Dz5VJJ6NNa2dxh = true;
			while (!_0023_003DzJHE44z8_003D.Value._0023_003Dz4sg0Qp0_003D)
			{
				switch (_0023_003DzwY9ClXw_003D)
				{
				case (_0023_003Dz4JAfHNw_003D)1:
					_0023_003DzijcZBl3z2p5r(_0023_003Dz_0024WkMNd__uiAK2, flag, _0023_003Dz5VJJ6NNa2dxh, ref _0023_003DzJHE44z8_003D, ref _0023_003DzB62SYmA_003D);
					break;
				case (_0023_003Dz4JAfHNw_003D)0:
					_0023_003DzVVAYzBWU9vnc(_0023_003Dz_0024WkMNd__uiAK2, flag, _0023_003Dz5VJJ6NNa2dxh, ref _0023_003DzJHE44z8_003D, ref _0023_003DzB62SYmA_003D);
					break;
				case (_0023_003Dz4JAfHNw_003D)2:
					_0023_003DzN7HUm0e6EQcJ(_0023_003Dz_0024WkMNd__uiAK2, flag, _0023_003Dz5VJJ6NNa2dxh, ref _0023_003DzJHE44z8_003D, ref _0023_003DzB62SYmA_003D);
					break;
				}
				_0023_003Dz5VJJ6NNa2dxh = false;
				_0023_003DzJHE44z8_003D = _0023_003DzJHE44z8_003D.Value._0023_003Dzg_d2bCm63KSux51d6w_003D_003D;
				flag = !flag;
				if (_0023_003DzJHE44z8_003D == null)
				{
					break;
				}
			}
			LinkedList<_0023_003DzfmsdmcfcBmDX> linkedList = _0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ();
			if (linkedList.Count > 0 && linkedList.Count > 2)
			{
				_0023_003DzMiYX984cUkaI3lGBbQ_003D_003D(_0023_003DzwY9ClXw_003D, _0023_003Dz_0024WkMNd__uiAK2, linkedList, _0023_003DzccAR5G0_003D);
				_0023_003Dz_0024WkMNd__uiAK._0023_003DzOq_CSAk_003D(linkedList, _0023_003DzccAR5G0_003D);
				if (_0023_003Dzq6gbnEWKa7KL)
				{
					_0023_003Dz_0024WkMNd__uiAK2._0023_003Dz0wcqTpk_003D();
				}
				if (_0023_003DzwY9ClXw_003D == (_0023_003Dz4JAfHNw_003D)2)
				{
					list.AddRange(_0023_003DzolnrLtt3J7cXXfADmrLKG_Y_003D(_0023_003Dz_0024WkMNd__uiAK2));
				}
				else
				{
					list.Add(_0023_003Dz_0024WkMNd__uiAK2);
				}
			}
		}
		return list;
	}

	private static IntegerGrid _0023_003Dz5A61nMUmhfOaOQP_0024vLZo3NI_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzH8zaF5A8WC6a, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz2IDzvZDNJh6e)
	{
		Point2D maxValue = Point2D.MaxValue;
		Point2D minValue = Point2D.MinValue;
		if (_0023_003DzH8zaF5A8WC6a._0023_003Dz3v2L_PqDegXs() == null)
		{
			_0023_003DzH8zaF5A8WC6a._0023_003DzItnzfA4C7E9K40TmrA_003D_003D();
		}
		if (_0023_003Dz2IDzvZDNJh6e._0023_003Dz3v2L_PqDegXs() == null)
		{
			_0023_003Dz2IDzvZDNJh6e._0023_003DzItnzfA4C7E9K40TmrA_003D_003D();
		}
		Utility.UpdateMinMax(null, new Point2D[4]
		{
			_0023_003DzH8zaF5A8WC6a._0023_003Dz3v2L_PqDegXs(),
			_0023_003DzH8zaF5A8WC6a._0023_003DzZ3fT5KydNWfc(),
			_0023_003Dz2IDzvZDNJh6e._0023_003Dz3v2L_PqDegXs(),
			_0023_003Dz2IDzvZDNJh6e._0023_003DzZ3fT5KydNWfc()
		}, 4, maxValue, minValue);
		IntegerGrid integerGrid = new IntegerGrid(524288, maxValue, minValue);
		_0023_003DzH8zaF5A8WC6a._0023_003Dzj_00240wWfbMUyOYm3ci0g_003D_003D(integerGrid);
		_0023_003Dz2IDzvZDNJh6e._0023_003Dzj_00240wWfbMUyOYm3ci0g_003D_003D(integerGrid);
		return integerGrid;
	}

	private static IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003Dz09XvvvdBxwEZrfrvjQ_003D_003D(IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzjzKQ3qDoHxqU, IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzccAR5G0_003D, out _0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D, out bool _0023_003DzMF8k7sk_003D, out _0023_003DzOmuoKv8_003D _0023_003DzOmuoKv8_003D)
	{
		_0023_003DzsQUfhOyYIEITc349jw_003D_003D(_0023_003DzjzKQ3qDoHxqU, _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D, _0023_003DzOSo8vaE_003D, _0023_003DzccAR5G0_003D);
		for (int i = 0; i < _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D.Count; i++)
		{
			for (int j = 0; j < _0023_003DzjzKQ3qDoHxqU.Count; j++)
			{
				_0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK2 = _0023_003DzjzKQ3qDoHxqU[j];
				_0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D[i]._0023_003DzmWcpFuZXVQcRMYa6GaIzQhg_003D(_0023_003Dz_0024WkMNd__uiAK2, _0023_003DzOSo8vaE_003D.GridMin, _0023_003Dzx3_8Ey_HzTH_0024: true, j == 0);
				_0023_003DzoirFDeXRPtSZ(_0023_003DzOSo8vaE_003D, _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D[i]);
				_0023_003Dz_0024WkMNd__uiAK2._0023_003DzmWcpFuZXVQcRMYa6GaIzQhg_003D(_0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D[i], _0023_003DzOSo8vaE_003D.GridMin, _0023_003Dzx3_8Ey_HzTH_0024: false, _0023_003Dz1n6oQPgDRgS8zAWK1w_003D_003D: false);
				_0023_003DzoirFDeXRPtSZ(_0023_003DzOSo8vaE_003D, _0023_003Dz_0024WkMNd__uiAK2);
			}
		}
		for (int k = 0; k < _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D.Count; k++)
		{
			foreach (_0023_003Dz_0024WkMNd__uiAK item in _0023_003DzjzKQ3qDoHxqU)
			{
				_0023_003DzADNPWX_0024bL47ygzDysGPf27s_003D(_0023_003DzOSo8vaE_003D, item, _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D[k], _0023_003DzccAR5G0_003D);
			}
		}
		List<_0023_003Dz_0024WkMNd__uiAK> list = new List<_0023_003Dz_0024WkMNd__uiAK>();
		bool _0023_003DzB62SYmA_003D = true;
		_0023_003DzMF8k7sk_003D = false;
		int num = 0;
		while (true)
		{
			bool flag = true;
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> first = _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D[num]._0023_003DzvRAdRPd11xUJ().First;
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = first;
			do
			{
				if (linkedListNode.Value._0023_003Dz9h5MY_A_003D && !linkedListNode.Value._0023_003Dz4sg0Qp0_003D)
				{
					LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode2 = Utility.CircularPrevious(linkedListNode);
					LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode3 = Utility.CircularNext(linkedListNode);
					bool flag2 = linkedListNode.Value._0023_003DzQC2DY_0024geS4zZUaYo9w_003D_003D._0023_003DzinOQp4_qBUm4opZWpg_003D_003D();
					if (linkedListNode3.Value._0023_003Dz9h5MY_A_003D)
					{
						if (linkedListNode2.Value._0023_003Dz9h5MY_A_003D && linkedListNode2.Value._0023_003Dz4sg0Qp0_003D)
						{
							break;
						}
						bool flag3 = linkedListNode.Value._0023_003DzQC2DY_0024geS4zZUaYo9w_003D_003D._0023_003DzrfhmnHeX0Pzt(linkedListNode2.Value);
						if ((flag2 && flag3) || (!flag2 && !flag3))
						{
							break;
						}
					}
					bool flag4 = linkedListNode.Value._0023_003DzQC2DY_0024geS4zZUaYo9w_003D_003D._0023_003DzrfhmnHeX0Pzt(linkedListNode3.Value);
					if ((flag2 && !flag4) || (!flag2 && flag4))
					{
						break;
					}
				}
				linkedListNode = Utility.CircularNext(linkedListNode);
				if (linkedListNode.Value == first.Value)
				{
					if (list.Count != 0)
					{
						break;
					}
					num++;
					if (num >= _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D.Count)
					{
						break;
					}
					linkedListNode = (first = _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D[num]._0023_003DzvRAdRPd11xUJ().First);
				}
			}
			while (linkedListNode != null);
			first = linkedListNode;
			if (first == null || first.Value._0023_003Dz4sg0Qp0_003D || !first.Value._0023_003Dz9h5MY_A_003D)
			{
				break;
			}
			_0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK3 = new _0023_003Dz_0024WkMNd__uiAK(_0023_003DzjzKQ3qDoHxqU[0]._0023_003DzXCecWa6CYPEG);
			while (!first.Value._0023_003Dz4sg0Qp0_003D)
			{
				_0023_003Dz7_s6bgYFmH8G(_0023_003Dz_0024WkMNd__uiAK3, ref first, ref _0023_003DzB62SYmA_003D);
				first = first.Value._0023_003Dzg_d2bCm63KSux51d6w_003D_003D;
				flag = !flag;
				if (first == null || (_0023_003DzMAxShrbxTEQp(first.Value, _0023_003Dz_0024WkMNd__uiAK3._0023_003DzvRAdRPd11xUJ().First.Value) && _0023_003Dz_0024WkMNd__uiAK3._0023_003DzvRAdRPd11xUJ().Count > 1))
				{
					break;
				}
			}
			LinkedList<_0023_003DzfmsdmcfcBmDX> linkedList = _0023_003Dz_0024WkMNd__uiAK3._0023_003DzvRAdRPd11xUJ();
			if (linkedList.Count > 0 && linkedList.Count > 2)
			{
				if (first != null && _0023_003DzMAxShrbxTEQp(first.Value, _0023_003Dz_0024WkMNd__uiAK3._0023_003DzvRAdRPd11xUJ().First.Value))
				{
					_0023_003DzMF8k7sk_003D = true;
				}
				_0023_003DzMiYX984cUkaI3lGBbQ_003D_003D((_0023_003Dz4JAfHNw_003D)0, _0023_003Dz_0024WkMNd__uiAK3, linkedList, _0023_003DzccAR5G0_003D);
				_0023_003Dz_0024WkMNd__uiAK._0023_003DzOq_CSAk_003D(linkedList, _0023_003DzccAR5G0_003D);
				list.Add(_0023_003Dz_0024WkMNd__uiAK3);
			}
		}
		foreach (_0023_003Dz_0024WkMNd__uiAK item2 in _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D)
		{
			foreach (_0023_003DzfmsdmcfcBmDX item3 in item2._0023_003DzvRAdRPd11xUJ())
			{
				if (item3._0023_003Dz4sg0Qp0_003D)
				{
					item2._0023_003Dz1XcTvJ4AwHv6 = true;
					_0023_003DzMF8k7sk_003D = true;
					break;
				}
			}
		}
		List<_0023_003Dz_0024WkMNd__uiAK> list2 = new List<_0023_003Dz_0024WkMNd__uiAK>();
		foreach (_0023_003Dz_0024WkMNd__uiAK item4 in _0023_003DzjzKQ3qDoHxqU)
		{
			bool flag5 = false;
			foreach (_0023_003DzfmsdmcfcBmDX item5 in item4._0023_003DzvRAdRPd11xUJ())
			{
				if (item5._0023_003Dz4sg0Qp0_003D)
				{
					flag5 = true;
					break;
				}
			}
			if (!flag5)
			{
				list2.Add(item4);
			}
		}
		_0023_003DzOmuoKv8_003D = _0023_003DzAOB3oM4zGoKXknGw4Qg1Se3wbRywJT_2WQ_003D_003D(list2, list);
		_0023_003DzOLHnb2M_003D = (_0023_003DzRrz47AY_003D)1;
		return list;
	}

	private static void _0023_003DzsQUfhOyYIEITc349jw_003D_003D(IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D, IList<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D, IntegerGrid _0023_003DzOSo8vaE_003D, double _0023_003DzccAR5G0_003D)
	{
		List<ICurve>[] array = new List<ICurve>[_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count];
		for (int i = 0; i < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; i++)
		{
			List<ICurve> list = new List<ICurve>();
			ICurve curve = null;
			foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[i]._0023_003DzvRAdRPd11xUJ())
			{
				if (item._0023_003DzEemH6ZA_003D != null && item._0023_003DzEemH6ZA_003D != curve)
				{
					curve = item._0023_003DzEemH6ZA_003D;
					list.Add(curve);
				}
			}
			if (list.Count > 1)
			{
				list.RemoveAt(list.Count - 1);
			}
			array[i] = list;
		}
		for (int j = 0; j < _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D.Count; j++)
		{
			_0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK2 = _0023_003DzoXyiOxVqwIM_fjiYoqWqPnSZ_0024sJg_0024FLBSg_003D_003D[j];
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> first = _0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().First;
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> last = _0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().Last;
			if (first.Next == null)
			{
				continue;
			}
			for (int k = 0; k < _0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D.Count; k++)
			{
				double _0023_003DzsK_Xndk_003D = 0.0;
				double _0023_003DzsK_Xndk_003D2 = 0.0;
				Point3D _0023_003DzKAo0QsmzKHCn = null;
				Point3D _0023_003DzKAo0QsmzKHCn2 = null;
				double num = double.MaxValue;
				double num2 = double.MaxValue;
				ICurve curve2 = null;
				ICurve curve3 = null;
				bool flag = false;
				bool flag2 = false;
				foreach (ICurve item2 in array[k])
				{
					item2.GetTightBBox(out var boxMin, out var boxMax);
					Point3D point3D = new Point3D(0.0, 0.0, 0.0);
					Point3D point3D2 = new Point3D(0.0, 0.0, 0.0);
					point3D.X = boxMin.X - num;
					point3D.Y = boxMin.Y - num;
					point3D2.X = boxMax.X + num;
					point3D2.Y = boxMax.Y + num;
					if (!flag && Utility.IsPointInsideOrOntoBBox2D(first.Value._0023_003Dz114WmwtBjoiC, point3D, point3D2) && item2.Project(first.Value._0023_003Dz114WmwtBjoiC, out var t) && t >= item2.Domain.Low && t <= item2.Domain.High)
					{
						Point3D point3D3 = item2.PointAt(t);
						double num3 = Point3D.Distance(first.Value._0023_003Dz114WmwtBjoiC, point3D3);
						if (num3 < num)
						{
							if (num3 / _0023_003DzccAR5G0_003D < Utility._0023_003DzheSR8QM7q9ya)
							{
								flag = true;
							}
							num = num3;
							_0023_003DzsK_Xndk_003D = t;
							_0023_003DzKAo0QsmzKHCn = point3D3;
							curve2 = item2;
						}
					}
					Point3D point3D4 = new Point3D(0.0, 0.0, 0.0);
					Point3D point3D5 = new Point3D(0.0, 0.0, 0.0);
					point3D4.X = boxMin.X - num2;
					point3D4.Y = boxMin.Y - num2;
					point3D5.X = boxMax.X + num2;
					point3D5.Y = boxMax.Y + num2;
					if (flag2 || !Utility.IsPointInsideOrOntoBBox2D(last.Value._0023_003Dz114WmwtBjoiC, point3D4, point3D5) || !item2.Project(last.Value._0023_003Dz114WmwtBjoiC, out var t2) || !(t2 >= item2.Domain.Low) || !(t2 <= item2.Domain.High))
					{
						continue;
					}
					Point3D point3D6 = item2.PointAt(t2);
					double num4 = Point3D.Distance(last.Value._0023_003Dz114WmwtBjoiC, point3D6);
					if (num4 < num2)
					{
						if (num4 / _0023_003DzccAR5G0_003D < Utility._0023_003DzheSR8QM7q9ya)
						{
							flag2 = true;
						}
						num2 = num4;
						_0023_003DzsK_Xndk_003D2 = t2;
						_0023_003DzKAo0QsmzKHCn2 = point3D6;
						curve3 = item2;
					}
				}
				if (curve2 != null && _0023_003DzQR5rBiBh0bgVMp8c8g_003D_003D(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[k], _0023_003DzOSo8vaE_003D, curve2, first, first.Next, _0023_003Dz_0024WkMNd__uiAK2, _0023_003DzccAR5G0_003D, _0023_003Dzgz5i0_0024oLM0tB: false, out var _0023_003Dz77g161c_003D, _0023_003DzsK_Xndk_003D, _0023_003DzKAo0QsmzKHCn))
				{
					ICurve curve4 = new Line(_0023_003Dz77g161c_003D._0023_003Dz114WmwtBjoiC, first.Value._0023_003Dz114WmwtBjoiC);
					curve4.EdgeIndex = first.Value._0023_003Dz4701yxQ2_0024axv.EdgeIndex;
					curve4.FromBooleanIntersection = first.Value._0023_003Dz4701yxQ2_0024axv.FromBooleanIntersection;
					if (curve2 is TrimCurve)
					{
						curve4 = curve4.GetNurbsForm()._0023_003DzmGgqdRaHiXdg(curve4);
					}
					_0023_003Dz77g161c_003D._0023_003Dz4701yxQ2_0024axv = curve4;
					first.Value._0023_003DzEemH6ZA_003D = first.Value._0023_003Dz4701yxQ2_0024axv;
					first.Value._0023_003Dz4701yxQ2_0024axv = _0023_003Dz77g161c_003D._0023_003Dz4701yxQ2_0024axv;
					_0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().AddFirst(_0023_003Dz77g161c_003D);
					first = _0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().First;
				}
				if (curve3 != null && _0023_003DzQR5rBiBh0bgVMp8c8g_003D_003D(_0023_003DzLGMvY_0024rw9syHNAZu5g_003D_003D[k], _0023_003DzOSo8vaE_003D, curve3, last, last.Previous, _0023_003Dz_0024WkMNd__uiAK2, _0023_003DzccAR5G0_003D, _0023_003Dzgz5i0_0024oLM0tB: true, out _0023_003Dz77g161c_003D, _0023_003DzsK_Xndk_003D2, _0023_003DzKAo0QsmzKHCn2))
				{
					ICurve curve5 = new Line(last.Value._0023_003Dz114WmwtBjoiC, _0023_003Dz77g161c_003D._0023_003Dz114WmwtBjoiC);
					curve5.EdgeIndex = last.Value._0023_003Dz4701yxQ2_0024axv.EdgeIndex;
					curve5.FromBooleanIntersection = first.Value._0023_003Dz4701yxQ2_0024axv.FromBooleanIntersection;
					if (curve3 is TrimCurve)
					{
						curve5 = curve5.GetNurbsForm()._0023_003DzmGgqdRaHiXdg(curve5);
					}
					_0023_003Dz77g161c_003D._0023_003Dz4701yxQ2_0024axv = curve5;
					last.Value._0023_003DzEemH6ZA_003D = _0023_003Dz77g161c_003D._0023_003Dz4701yxQ2_0024axv;
					_0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().AddLast(_0023_003Dz77g161c_003D);
					last = _0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().Last;
				}
			}
		}
	}

	private static bool _0023_003DzQR5rBiBh0bgVMp8c8g_003D_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzYVDIcYzAKAZM, IntegerGrid _0023_003DzOSo8vaE_003D, ICurve _0023_003Dz8fpRyMu9aKjE, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzakzW1xkeIkc98w_0024rqalIZd3SGSEL, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz62vHQnFzEItYZ9p_0024rFlokYIvjOHE, double _0023_003DzccAR5G0_003D, bool _0023_003Dzgz5i0_0024oLM0tB, out _0023_003DzfmsdmcfcBmDX _0023_003Dz77g161c_003D, double _0023_003DzsK_Xndk_003D, Point3D _0023_003DzKAo0QsmzKHCn)
	{
		_0023_003Dz77g161c_003D = null;
		Point3D[] array = null;
		if (!Point3D.AreEqual(_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dz114WmwtBjoiC, _0023_003DzKAo0QsmzKHCn, _0023_003DzccAR5G0_003D))
		{
			ICurve _0023_003Dz4701yxQ2_0024axv = _0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dz4701yxQ2_0024axv;
			ICurve sub;
			if (_0023_003Dzgz5i0_0024oLM0tB)
			{
				_0023_003Dz4701yxQ2_0024axv.SubCurve(_0023_003DzakzW1xkeIkc98w_0024rqalIZd3SGSEL.Value._0023_003Dz114WmwtBjoiC, _0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dz114WmwtBjoiC, out sub);
			}
			else
			{
				_0023_003Dz4701yxQ2_0024axv.SubCurve(_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dz114WmwtBjoiC, _0023_003DzakzW1xkeIkc98w_0024rqalIZd3SGSEL.Value._0023_003Dz114WmwtBjoiC, out sub);
			}
			if (sub == null)
			{
				return false;
			}
			array = _0023_003Dz8fpRyMu9aKjE.IntersectWith(sub);
			if (array == null || array.Length == 0)
			{
				return false;
			}
		}
		Vector3D vector3D = _0023_003Dz8fpRyMu9aKjE.TangentAt(_0023_003DzsK_Xndk_003D);
		_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dz4701yxQ2_0024axv.Project(_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dz114WmwtBjoiC, out var t);
		Vector3D v = _0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dz4701yxQ2_0024axv.TangentAt(t);
		Segment2D _0023_003DzjFil5kcvDwbAMLVLKUChduZLAZVv = new Segment2D(_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dzyk2fsPo_003D, _0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003DzvXOLtKg_003D, _0023_003DzakzW1xkeIkc98w_0024rqalIZd3SGSEL.Value._0023_003Dzyk2fsPo_003D, _0023_003DzakzW1xkeIkc98w_0024rqalIZd3SGSEL.Value._0023_003DzvXOLtKg_003D);
		List<Point2D> list = new List<Point2D>();
		if (_0023_003DzP_0024jnehg1xBoJ(_0023_003DzYVDIcYzAKAZM, _0023_003Dz8fpRyMu9aKjE, _0023_003DzjFil5kcvDwbAMLVLKUChduZLAZVv))
		{
			return false;
		}
		double num = _0023_003DzOSo8vaE_003D._0023_003Dz_0024cHmBejv4XfE().X + _0023_003DzOSo8vaE_003D._0023_003Dz_0024cHmBejv4XfE().Y;
		Segment2D segment2D;
		Vector2D vector2D;
		if (Vector3D.AreParallel(vector3D, v, 0.1))
		{
			vector2D = new Vector2D(vector3D.Y, 0.0 - vector3D.X);
			vector2D.Normalize();
			vector2D.X *= num;
			vector2D.Y *= num;
			segment2D = new Segment2D(_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dzyk2fsPo_003D, _0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003DzvXOLtKg_003D, (double)_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dzyk2fsPo_003D + vector2D.X, (double)_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003DzvXOLtKg_003D + vector2D.Y);
			_0023_003Dzt54UmuXdOOWM(_0023_003DzYVDIcYzAKAZM, _0023_003Dz8fpRyMu9aKjE, list, segment2D);
			if (list.Count == 0)
			{
				vector2D.Negate();
				segment2D = new Segment2D(_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dzyk2fsPo_003D, _0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003DzvXOLtKg_003D, (double)_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dzyk2fsPo_003D + vector2D.X, (double)_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003DzvXOLtKg_003D + vector2D.Y);
				_0023_003Dzt54UmuXdOOWM(_0023_003DzYVDIcYzAKAZM, _0023_003Dz8fpRyMu9aKjE, list, segment2D);
			}
		}
		else
		{
			vector2D = new Vector2D(_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dzyk2fsPo_003D - _0023_003DzakzW1xkeIkc98w_0024rqalIZd3SGSEL.Value._0023_003Dzyk2fsPo_003D, _0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003DzvXOLtKg_003D - _0023_003DzakzW1xkeIkc98w_0024rqalIZd3SGSEL.Value._0023_003DzvXOLtKg_003D);
			vector2D.Normalize();
			vector2D.X *= num;
			vector2D.Y *= num;
			segment2D = new Segment2D(_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dzyk2fsPo_003D, _0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003DzvXOLtKg_003D, (double)_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dzyk2fsPo_003D + vector2D.X, (double)_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003DzvXOLtKg_003D + vector2D.Y);
			_0023_003Dzt54UmuXdOOWM(_0023_003DzYVDIcYzAKAZM, _0023_003Dz8fpRyMu9aKjE, list, segment2D);
		}
		if (list.Count == 0)
		{
			return false;
		}
		List<double> list2 = new List<double>(list.Count);
		for (int i = 0; i < list.Count; i++)
		{
			list2.Add(segment2D.ClosestPointTo(list[i]));
		}
		list2.Sort();
		double t2 = list2[0];
		Point2D point2D = segment2D.PointAt(t2);
		vector2D = new Vector2D(point2D.X - (double)_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003Dzyk2fsPo_003D, point2D.Y - (double)_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value._0023_003DzvXOLtKg_003D);
		double length = vector2D.Length;
		vector2D.Normalize();
		vector2D *= length + 4.0;
		_0023_003Dz77g161c_003D = (_0023_003DzfmsdmcfcBmDX)_0023_003DzFmCbRKJJYmDUzcfnz0OB4xc0N5GE.Value.Clone();
		_0023_003Dz77g161c_003D._0023_003Dz114WmwtBjoiC = _0023_003DzKAo0QsmzKHCn;
		_0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D += _0023_003DzLokLuarM0I8b8BPmwaJ6INI_003D(vector2D.X);
		_0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D += _0023_003DzLokLuarM0I8b8BPmwaJ6INI_003D(vector2D.Y);
		_0023_003DzOSo8vaE_003D.ScaleToWorld(_0023_003Dz77g161c_003D._0023_003Dzyk2fsPo_003D, _0023_003Dz77g161c_003D._0023_003DzvXOLtKg_003D, out var x, out var y);
		_0023_003Dz77g161c_003D._0023_003Dz114WmwtBjoiC = _0023_003Dz62vHQnFzEItYZ9p_0024rFlokYIvjOHE._0023_003DzXCecWa6CYPEG.PointAt(x, y);
		return true;
	}

	private static bool _0023_003DzP_0024jnehg1xBoJ(_0023_003Dz_0024WkMNd__uiAK _0023_003DzYVDIcYzAKAZM, ICurve _0023_003Dz8fpRyMu9aKjE, Segment2D _0023_003DzjFil5kcvDwbAMLVLKUChduZLAZVv)
	{
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzYVDIcYzAKAZM._0023_003DzvRAdRPd11xUJ().First;
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = linkedListNode.Next;
		while (linkedListNode != null)
		{
			next = linkedListNode.Next;
			if (next == null)
			{
				break;
			}
			if (next.Value._0023_003Dz4701yxQ2_0024axv == _0023_003Dz8fpRyMu9aKjE)
			{
				Segment2D segment2D = new Segment2D(linkedListNode.Value._0023_003Dzyk2fsPo_003D, linkedListNode.Value._0023_003DzvXOLtKg_003D, next.Value._0023_003Dzyk2fsPo_003D, next.Value._0023_003DzvXOLtKg_003D);
				double domainSize = Math.Min(_0023_003DzjFil5kcvDwbAMLVLKUChduZLAZVv.Length, segment2D.Length);
				if (Segment2D.Intersection(_0023_003DzjFil5kcvDwbAMLVLKUChduZLAZVv, segment2D, out var _, out var _, domainSize) != segmentIntersectionType.Disjoint)
				{
					return true;
				}
			}
			linkedListNode = next;
		}
		return false;
	}

	private static void _0023_003Dzt54UmuXdOOWM(_0023_003Dz_0024WkMNd__uiAK _0023_003DzYVDIcYzAKAZM, ICurve _0023_003Dz8fpRyMu9aKjE, List<Point2D> _0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D, Segment2D _0023_003Dz2z6DYNUN18fppA5ZUmYfF2EZiamH)
	{
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzYVDIcYzAKAZM._0023_003DzvRAdRPd11xUJ().First;
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = linkedListNode.Next;
		while (linkedListNode != null)
		{
			next = linkedListNode.Next;
			if (next == null)
			{
				break;
			}
			if (next.Value._0023_003Dz4701yxQ2_0024axv == _0023_003Dz8fpRyMu9aKjE)
			{
				Segment2D segment2D = new Segment2D(linkedListNode.Value._0023_003Dzyk2fsPo_003D, linkedListNode.Value._0023_003DzvXOLtKg_003D, next.Value._0023_003Dzyk2fsPo_003D, next.Value._0023_003DzvXOLtKg_003D);
				double domainSize = Math.Min(_0023_003Dz2z6DYNUN18fppA5ZUmYfF2EZiamH.Length, segment2D.Length);
				if (Segment2D.Intersection(_0023_003Dz2z6DYNUN18fppA5ZUmYfF2EZiamH, segment2D, out var i, out var i2, domainSize) != segmentIntersectionType.Disjoint)
				{
					if (i != null)
					{
						_0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.Add(i);
					}
					if (i2 != null)
					{
						_0023_003DztpWoGxsBaJcVMbHVEEJxs2I_003D.Add(i2);
					}
				}
			}
			linkedListNode = next;
		}
	}

	private static int _0023_003DzLokLuarM0I8b8BPmwaJ6INI_003D(double _0023_003DzXrexKjY_003D)
	{
		if (_0023_003DzXrexKjY_003D > 0.0)
		{
			return (int)Math.Ceiling(_0023_003DzXrexKjY_003D);
		}
		if (_0023_003DzXrexKjY_003D < 0.0)
		{
			return (int)Math.Floor(_0023_003DzXrexKjY_003D);
		}
		return (int)_0023_003DzXrexKjY_003D;
	}

	private static _0023_003DzOmuoKv8_003D _0023_003DzAOB3oM4zGoKXknGw4Qg1Se3wbRywJT_2WQ_003D_003D(List<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzB3b1Am9AnvBbCVlJH7hbNZhSs6fk, List<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzToOfHUjqv__quI_0024B_0024g_003D_003D)
	{
		_0023_003DzOmuoKv8_003D result = (_0023_003DzOmuoKv8_003D)1;
		int count = _0023_003DzToOfHUjqv__quI_0024B_0024g_003D_003D.Count;
		Point2D[][] array = new Point2D[count][];
		Point2D[][] array2 = new Point2D[_0023_003DzB3b1Am9AnvBbCVlJH7hbNZhSs6fk.Count][];
		List<Point2D[]> list = new List<Point2D[]>();
		for (int i = 0; i < _0023_003DzB3b1Am9AnvBbCVlJH7hbNZhSs6fk.Count; i++)
		{
			_0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK2 = _0023_003DzB3b1Am9AnvBbCVlJH7hbNZhSs6fk[i];
			array2[i] = _0023_003Dz31nvEQmX8nQD(_0023_003Dz_0024WkMNd__uiAK2);
			for (int j = 0; j < count; j++)
			{
				if (array[j] == null)
				{
					array[j] = _0023_003Dz31nvEQmX8nQD(_0023_003DzToOfHUjqv__quI_0024B_0024g_003D_003D[j]);
				}
				_0023_003DzfmsdmcfcBmDX value = _0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().First.Value;
				bool flag = _0023_003DzToOfHUjqv__quI_0024B_0024g_003D_003D[j]._0023_003DzinOQp4_qBUm4opZWpg_003D_003D();
				if (Utility.PointInPolygon(new Point2D(value._0023_003Dzyk2fsPo_003D, value._0023_003DzvXOLtKg_003D), array[j]))
				{
					if (!flag)
					{
						_0023_003DzToOfHUjqv__quI_0024B_0024g_003D_003D.Add(_0023_003Dz_0024WkMNd__uiAK2);
						_0023_003DzB3b1Am9AnvBbCVlJH7hbNZhSs6fk.RemoveAt(i);
						list.Add(array2[i]);
						array2[i] = null;
						i--;
						break;
					}
				}
				else if (Utility.PointInPolygon(array[j][0], array2[i]) && flag)
				{
					_0023_003DzToOfHUjqv__quI_0024B_0024g_003D_003D.Add(_0023_003Dz_0024WkMNd__uiAK2);
					_0023_003DzB3b1Am9AnvBbCVlJH7hbNZhSs6fk.RemoveAt(i);
					list.Add(array2[i]);
					array2[i] = null;
					i--;
					result = (_0023_003DzOmuoKv8_003D)2;
					break;
				}
			}
		}
		for (int k = 0; k < _0023_003DzB3b1Am9AnvBbCVlJH7hbNZhSs6fk.Count; k++)
		{
			for (int l = 0; l < list.Count; l++)
			{
				_0023_003DzfmsdmcfcBmDX value2 = _0023_003DzB3b1Am9AnvBbCVlJH7hbNZhSs6fk[k]._0023_003DzvRAdRPd11xUJ().First.Value;
				if (Utility.PointInPolygon(new Point2D(value2._0023_003Dzyk2fsPo_003D, value2._0023_003DzvXOLtKg_003D), list[l]))
				{
					_0023_003DzToOfHUjqv__quI_0024B_0024g_003D_003D.Add(_0023_003DzB3b1Am9AnvBbCVlJH7hbNZhSs6fk[k]);
					_0023_003DzB3b1Am9AnvBbCVlJH7hbNZhSs6fk.RemoveAt(k);
					k--;
					break;
				}
			}
		}
		return result;
	}

	private static Point2D[] _0023_003Dz31nvEQmX8nQD(_0023_003Dz_0024WkMNd__uiAK _0023_003DzYVDIcYzAKAZM)
	{
		int num = 0;
		Point2D[] array = new Point2D[_0023_003DzYVDIcYzAKAZM._0023_003DzvRAdRPd11xUJ().Count];
		foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzYVDIcYzAKAZM._0023_003DzvRAdRPd11xUJ())
		{
			array[num++] = new Point2D(item._0023_003Dzyk2fsPo_003D, item._0023_003DzvXOLtKg_003D);
		}
		return array;
	}

	internal static bool _0023_003DzMAxShrbxTEQp(_0023_003DzfmsdmcfcBmDX _0023_003DzffqPLNQ_003D, _0023_003DzfmsdmcfcBmDX _0023_003Dz5Azd7L8_003D)
	{
		int num;
		int num2;
		if (_0023_003DzffqPLNQ_003D._0023_003DzzAvTK7EbICGAsFTsLg_003D_003D)
		{
			num = _0023_003DzffqPLNQ_003D._0023_003DzYqBTSeQ_003D;
			num2 = _0023_003DzffqPLNQ_003D._0023_003DzWdV9UYA_003D;
		}
		else
		{
			num = _0023_003DzffqPLNQ_003D._0023_003Dzyk2fsPo_003D;
			num2 = _0023_003DzffqPLNQ_003D._0023_003DzvXOLtKg_003D;
		}
		int num3;
		int num4;
		if (_0023_003Dz5Azd7L8_003D._0023_003DzzAvTK7EbICGAsFTsLg_003D_003D)
		{
			num3 = _0023_003Dz5Azd7L8_003D._0023_003DzYqBTSeQ_003D;
			num4 = _0023_003Dz5Azd7L8_003D._0023_003DzWdV9UYA_003D;
		}
		else
		{
			num3 = _0023_003Dz5Azd7L8_003D._0023_003Dzyk2fsPo_003D;
			num4 = _0023_003Dz5Azd7L8_003D._0023_003DzvXOLtKg_003D;
		}
		if (num == num3)
		{
			return num2 == num4;
		}
		return false;
	}

	private static void _0023_003DzADNPWX_0024bL47ygzDysGPf27s_003D(IntegerGrid _0023_003DzOSo8vaE_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzH8zaF5A8WC6a, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz2IDzvZDNJh6e, double _0023_003DzccAR5G0_003D)
	{
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzH8zaF5A8WC6a._0023_003DzvRAdRPd11xUJ().First;
		while (linkedListNode.Next != null)
		{
			if (!linkedListNode.Value._0023_003Dz9h5MY_A_003D)
			{
				ICurve _0023_003Dz8recRnxe9UGp = _0023_003Dz4qecmD8_003D(linkedListNode);
				LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzgzbF5Pk_003D = _0023_003Dz_0024WkMNd__uiAK._0023_003DzUUw_0024Yv_0024L0rFZ(linkedListNode.Next);
				LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode2 = _0023_003Dz2IDzvZDNJh6e._0023_003DzvRAdRPd11xUJ().First;
				while (linkedListNode2.Next != null)
				{
					if (!linkedListNode2.Value._0023_003Dz9h5MY_A_003D)
					{
						LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz_rfvKVg_003D = _0023_003Dz_0024WkMNd__uiAK._0023_003DzUUw_0024Yv_0024L0rFZ(linkedListNode2.Next);
						_0023_003DzOYxPx6FqLIHX(_0023_003DzOSo8vaE_003D, _0023_003DzH8zaF5A8WC6a, _0023_003Dz2IDzvZDNJh6e, linkedListNode, _0023_003DzgzbF5Pk_003D, linkedListNode2, _0023_003Dz_rfvKVg_003D, _0023_003DzccAR5G0_003D, ref _0023_003Dz8recRnxe9UGp);
					}
					linkedListNode2 = linkedListNode2.Next;
				}
			}
			linkedListNode = linkedListNode.Next;
		}
	}

	private static bool _0023_003DzOYxPx6FqLIHX(IntegerGrid _0023_003DzOSo8vaE_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzH8zaF5A8WC6a, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz2IDzvZDNJh6e, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzsmsbDy4_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzgzbF5Pk_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzHdmzMag_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz_rfvKVg_003D, double _0023_003DzccAR5G0_003D, ref ICurve _0023_003Dz8recRnxe9UGp)
	{
		double _0023_003Dz2HQExmey0Efn = 0.0;
		double _0023_003DzVK4_0024oHG2kIT = 0.0;
		_0023_003DzfmsdmcfcBmDX _0023_003DzcXkiOibhYRCo = null;
		if (_0023_003DzQ7usAag_003D(_0023_003DzsmsbDy4_003D.Value, _0023_003DzgzbF5Pk_003D.Value, _0023_003DzHdmzMag_003D.Value, _0023_003Dz_rfvKVg_003D.Value, ref _0023_003Dz2HQExmey0Efn, ref _0023_003DzVK4_0024oHG2kIT, ref _0023_003DzcXkiOibhYRCo))
		{
			return _0023_003DzmNTp8nmVM2W9ThguOQ_003D_003D(_0023_003DzOSo8vaE_003D, _0023_003DzH8zaF5A8WC6a, _0023_003Dz2IDzvZDNJh6e, _0023_003DzsmsbDy4_003D, _0023_003DzgzbF5Pk_003D, _0023_003DzHdmzMag_003D, _0023_003Dz_rfvKVg_003D, _0023_003DzccAR5G0_003D, ref _0023_003Dz8recRnxe9UGp, _0023_003DzcXkiOibhYRCo, _0023_003Dz2HQExmey0Efn, _0023_003DzVK4_0024oHG2kIT, _0023_003Dz9Oh2ogQ_003D: false);
		}
		return false;
	}

	private static bool _0023_003DzmNTp8nmVM2W9ThguOQ_003D_003D(IntegerGrid _0023_003DzOSo8vaE_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzH8zaF5A8WC6a, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz2IDzvZDNJh6e, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzsmsbDy4_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzgzbF5Pk_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzHdmzMag_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz_rfvKVg_003D, double _0023_003DzccAR5G0_003D, ref ICurve _0023_003Dz8recRnxe9UGp, _0023_003DzfmsdmcfcBmDX _0023_003DzcXkiOibhYRCo, double _0023_003DzTLgJ1XNActyw, double _0023_003DzO_zXKB8GLR6U, bool _0023_003Dz9Oh2ogQ_003D)
	{
		bool result = false;
		Point3D _0023_003DzMlCq3wk_003D = null;
		ICurve _0023_003Dz0S6lrCnKpmzi = _0023_003Dz4qecmD8_003D(_0023_003DzHdmzMag_003D);
		if (_0023_003DzsmsbDy4_003D.Value._0023_003Dz4701yxQ2_0024axv != null && _0023_003DzHdmzMag_003D.Value._0023_003Dz4701yxQ2_0024axv != null)
		{
			_0023_003DzMlCq3wk_003D = _0023_003DzpCjS5_B6gDeE(_0023_003DzH8zaF5A8WC6a._0023_003DzXCecWa6CYPEG, _0023_003DzsmsbDy4_003D.Value, _0023_003DzgzbF5Pk_003D.Value, _0023_003DzHdmzMag_003D.Value, _0023_003Dz_rfvKVg_003D.Value, _0023_003Dz8recRnxe9UGp, _0023_003Dz0S6lrCnKpmzi, _0023_003DzccAR5G0_003D, out var _);
			if (_0023_003DzMlCq3wk_003D == null)
			{
				_0023_003DzMlCq3wk_003D = _0023_003DzsmsbDy4_003D.Value._0023_003Dz114WmwtBjoiC;
				if (_0023_003DzVNnz7lw1Hu7b(ref _0023_003DzMlCq3wk_003D, _0023_003Dz0S6lrCnKpmzi, _0023_003DzHdmzMag_003D.Value, _0023_003Dz_rfvKVg_003D.Value, _0023_003DzccAR5G0_003D))
				{
					_0023_003DzcXkiOibhYRCo._0023_003Dzyk2fsPo_003D = _0023_003DzsmsbDy4_003D.Value._0023_003Dzyk2fsPo_003D;
					_0023_003DzcXkiOibhYRCo._0023_003DzvXOLtKg_003D = _0023_003DzsmsbDy4_003D.Value._0023_003DzvXOLtKg_003D;
					_0023_003DzcXkiOibhYRCo._0023_003DzWdV9UYA_003D = _0023_003DzsmsbDy4_003D.Value._0023_003DzWdV9UYA_003D;
					_0023_003DzcXkiOibhYRCo._0023_003DzYqBTSeQ_003D = _0023_003DzsmsbDy4_003D.Value._0023_003DzYqBTSeQ_003D;
					_0023_003DzcXkiOibhYRCo._0023_003DzzAvTK7EbICGAsFTsLg_003D_003D = _0023_003DzsmsbDy4_003D.Value._0023_003DzzAvTK7EbICGAsFTsLg_003D_003D;
				}
				else
				{
					_0023_003DzMlCq3wk_003D = _0023_003DzHdmzMag_003D.Value._0023_003Dz114WmwtBjoiC;
					if (_0023_003DzVNnz7lw1Hu7b(ref _0023_003DzMlCq3wk_003D, _0023_003Dz8recRnxe9UGp, _0023_003DzsmsbDy4_003D.Value, _0023_003DzgzbF5Pk_003D.Value, _0023_003DzccAR5G0_003D))
					{
						_0023_003DzcXkiOibhYRCo._0023_003Dzyk2fsPo_003D = _0023_003DzHdmzMag_003D.Value._0023_003Dzyk2fsPo_003D;
						_0023_003DzcXkiOibhYRCo._0023_003DzvXOLtKg_003D = _0023_003DzHdmzMag_003D.Value._0023_003DzvXOLtKg_003D;
						_0023_003DzcXkiOibhYRCo._0023_003DzWdV9UYA_003D = _0023_003DzHdmzMag_003D.Value._0023_003DzWdV9UYA_003D;
						_0023_003DzcXkiOibhYRCo._0023_003DzYqBTSeQ_003D = _0023_003DzHdmzMag_003D.Value._0023_003DzYqBTSeQ_003D;
						_0023_003DzcXkiOibhYRCo._0023_003DzzAvTK7EbICGAsFTsLg_003D_003D = _0023_003DzHdmzMag_003D.Value._0023_003DzzAvTK7EbICGAsFTsLg_003D_003D;
					}
					else
					{
						_0023_003DzeuwbsHqM6T8PRkqWIg_003D_003D(_0023_003DzOSo8vaE_003D, _0023_003DzH8zaF5A8WC6a, _0023_003Dz2IDzvZDNJh6e, _0023_003DzsmsbDy4_003D, _0023_003DzgzbF5Pk_003D, _0023_003DzHdmzMag_003D, _0023_003Dz_rfvKVg_003D, _0023_003DzcXkiOibhYRCo, ref _0023_003DzMlCq3wk_003D, ref _0023_003Dz8recRnxe9UGp, ref _0023_003Dz0S6lrCnKpmzi);
					}
				}
			}
		}
		if (_0023_003DzMlCq3wk_003D == null)
		{
			return result;
		}
		_0023_003DzcXkiOibhYRCo._0023_003Dz114WmwtBjoiC = _0023_003DzMlCq3wk_003D;
		_0023_003DzJaDV4_0_003D(_0023_003DzcXkiOibhYRCo, _0023_003DzH8zaF5A8WC6a, _0023_003Dz2IDzvZDNJh6e, _0023_003DzsmsbDy4_003D, _0023_003DzgzbF5Pk_003D, _0023_003DzHdmzMag_003D, _0023_003Dz_rfvKVg_003D, _0023_003Dz8recRnxe9UGp, _0023_003Dz0S6lrCnKpmzi, _0023_003DzTLgJ1XNActyw, _0023_003DzO_zXKB8GLR6U);
		return result;
	}

	private static void _0023_003DzeuwbsHqM6T8PRkqWIg_003D_003D(IntegerGrid _0023_003DzOSo8vaE_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzH8zaF5A8WC6a, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz2IDzvZDNJh6e, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzsmsbDy4_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzgzbF5Pk_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzHdmzMag_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz_rfvKVg_003D, _0023_003DzfmsdmcfcBmDX _0023_003DzcXkiOibhYRCo, ref Point3D _0023_003DzMlCq3wk_003D, ref ICurve _0023_003Dz8recRnxe9UGp, ref ICurve _0023_003Dz0S6lrCnKpmzi)
	{
		_0023_003DzOSo8vaE_003D.ScaleToWorld(_0023_003DzcXkiOibhYRCo._0023_003Dzyk2fsPo_003D, _0023_003DzcXkiOibhYRCo._0023_003DzvXOLtKg_003D, out var x, out var y);
		_0023_003DzcXkiOibhYRCo._0023_003DzfoNNk4xzIdOW = new Point2D(x, y);
		bool num = _0023_003Dz8recRnxe9UGp is TrimCurve;
		bool flag = _0023_003Dz0S6lrCnKpmzi is TrimCurve;
		_0023_003Dz8recRnxe9UGp = _0023_003DzAGGsAwXI7GLJ(_0023_003DzsmsbDy4_003D, _0023_003DzgzbF5Pk_003D, _0023_003Dz8recRnxe9UGp);
		_0023_003Dz0S6lrCnKpmzi = _0023_003DzAGGsAwXI7GLJ(_0023_003DzHdmzMag_003D, _0023_003Dz_rfvKVg_003D, _0023_003Dz0S6lrCnKpmzi);
		if (!Utility.IntersectionLineLine(_0023_003Dz8recRnxe9UGp, _0023_003Dz0S6lrCnKpmzi, _0023_003DzH8zaF5A8WC6a._0023_003DzXCecWa6CYPEG, out _0023_003DzMlCq3wk_003D))
		{
			_0023_003DzMlCq3wk_003D = _0023_003DzH8zaF5A8WC6a._0023_003DzXCecWa6CYPEG.PointAt(x, y);
		}
		if (num)
		{
			_0023_003Dz8recRnxe9UGp = _0023_003Dz8recRnxe9UGp.GetNurbsForm()._0023_003DzmGgqdRaHiXdg(((TrimCurve)_0023_003Dz8recRnxe9UGp).Edge);
		}
		if (flag)
		{
			_0023_003Dz0S6lrCnKpmzi = _0023_003Dz0S6lrCnKpmzi.GetNurbsForm()._0023_003DzmGgqdRaHiXdg(((TrimCurve)_0023_003Dz0S6lrCnKpmzi).Edge);
		}
		_0023_003DzcXkiOibhYRCo._0023_003Dz114WmwtBjoiC = _0023_003DzMlCq3wk_003D;
	}

	private static ICurve _0023_003DzAGGsAwXI7GLJ(LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DziUf1xw4_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzvmFFjUs_003D, ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		ICurve curve = ((!_0023_003DziUf1xw4_003D.Value._0023_003DzB62SYmA_003D) ? new Line(_0023_003DzvmFFjUs_003D.Value._0023_003Dz114WmwtBjoiC, _0023_003DziUf1xw4_003D.Value._0023_003Dz114WmwtBjoiC) : new Line(_0023_003DziUf1xw4_003D.Value._0023_003Dz114WmwtBjoiC, _0023_003DzvmFFjUs_003D.Value._0023_003Dz114WmwtBjoiC));
		if (_0023_003Dz8fpRyMu9aKjE is TrimCurve)
		{
			curve = curve.GetNurbsForm()._0023_003DzmGgqdRaHiXdg(((TrimCurve)_0023_003Dz8fpRyMu9aKjE).Edge);
			curve.EdgeIndex = _0023_003Dz8fpRyMu9aKjE.EdgeIndex;
			curve.FromBooleanIntersection = _0023_003Dz8fpRyMu9aKjE.FromBooleanIntersection;
		}
		_0023_003DziUf1xw4_003D.Value._0023_003DzEemH6ZA_003D = curve;
		if (_0023_003DzvmFFjUs_003D.Value._0023_003DzEemH6ZA_003D == null)
		{
			_0023_003DzvmFFjUs_003D.Value._0023_003DzEemH6ZA_003D = _0023_003DzvmFFjUs_003D.Value._0023_003Dz4701yxQ2_0024axv;
		}
		_0023_003DzvmFFjUs_003D.Value._0023_003Dz4701yxQ2_0024axv = curve;
		_0023_003DziGdpfD2cV8jS1YzfxPD9bOA_003D(_0023_003DziUf1xw4_003D, _0023_003DzvmFFjUs_003D, curve);
		return curve;
	}

	private static void _0023_003DziGdpfD2cV8jS1YzfxPD9bOA_003D(LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DziUf1xw4_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzvmFFjUs_003D, ICurve _0023_003Dz8fpRyMu9aKjE)
	{
		for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = _0023_003DziUf1xw4_003D.Next; next != _0023_003DzvmFFjUs_003D; next = next.Next)
		{
			_0023_003Dz8fpRyMu9aKjE.ClosestPointTo(next.Value._0023_003Dz114WmwtBjoiC, out var t);
			next.Value._0023_003Dz114WmwtBjoiC = _0023_003Dz8fpRyMu9aKjE.PointAt(t);
			next.Value._0023_003DzEemH6ZA_003D = _0023_003Dz8fpRyMu9aKjE;
			next.Value._0023_003Dzg_d2bCm63KSux51d6w_003D_003D.Value._0023_003Dz4701yxQ2_0024axv = _0023_003Dz8fpRyMu9aKjE;
		}
	}

	private static _0023_003DzfmsdmcfcBmDX _0023_003DzS2tvchGVYUxovAIC_g_003D_003D(_0023_003DzfmsdmcfcBmDX _0023_003DzcXkiOibhYRCo, _0023_003Dz_0024WkMNd__uiAK _0023_003DzYVDIcYzAKAZM, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DziUf1xw4_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzvmFFjUs_003D, Line _0023_003DzQvaHyao_003D, Line _0023_003DzNyidyKE_003D)
	{
		_0023_003DzfmsdmcfcBmDX obj = (_0023_003DzfmsdmcfcBmDX)_0023_003DzcXkiOibhYRCo.Clone();
		obj._0023_003Dz9h5MY_A_003D = false;
		obj._0023_003Dz4701yxQ2_0024axv = _0023_003DzQvaHyao_003D;
		obj._0023_003DzEemH6ZA_003D = _0023_003DzNyidyKE_003D;
		obj._0023_003DzbvIFYko_003D = 0.0;
		obj._0023_003Dzse5L_LQ_003D = true;
		_0023_003DziUf1xw4_003D.Value._0023_003DzEemH6ZA_003D = _0023_003DzQvaHyao_003D;
		_0023_003DzvmFFjUs_003D.Value._0023_003DzEemH6ZA_003D = _0023_003DzvmFFjUs_003D.Value._0023_003Dz4701yxQ2_0024axv;
		_0023_003DzvmFFjUs_003D.Value._0023_003Dz4701yxQ2_0024axv = _0023_003DzNyidyKE_003D;
		return obj;
	}

	private static void _0023_003DzJaDV4_0_003D(_0023_003DzfmsdmcfcBmDX _0023_003DzcXkiOibhYRCo, _0023_003Dz_0024WkMNd__uiAK _0023_003DzH8zaF5A8WC6a, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz2IDzvZDNJh6e, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzsmsbDy4_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzgzbF5Pk_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzHdmzMag_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz_rfvKVg_003D, ICurve _0023_003Dz8recRnxe9UGp, ICurve _0023_003Dz0S6lrCnKpmzi, double _0023_003DzTLgJ1XNActyw, double _0023_003DzO_zXKB8GLR6U)
	{
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003Dz_0024WkMNd__uiAK._0023_003DzYsYhGdI_003D(_0023_003DzcXkiOibhYRCo._0023_003Dzyk2fsPo_003D, _0023_003DzcXkiOibhYRCo._0023_003DzvXOLtKg_003D, _0023_003DzcXkiOibhYRCo._0023_003Dz114WmwtBjoiC, _0023_003DzfxRH11yqtER41XYo5w_003D_003D: true, _0023_003Dz2uRRF4k_003D: false, _0023_003Dz4sg0Qp0_003D: false, _0023_003DzTLgJ1XNActyw);
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode2 = _0023_003Dz_0024WkMNd__uiAK._0023_003DzYsYhGdI_003D(_0023_003DzcXkiOibhYRCo._0023_003Dzyk2fsPo_003D, _0023_003DzcXkiOibhYRCo._0023_003DzvXOLtKg_003D, _0023_003DzcXkiOibhYRCo._0023_003Dz114WmwtBjoiC, _0023_003DzfxRH11yqtER41XYo5w_003D_003D: true, _0023_003Dz2uRRF4k_003D: false, _0023_003Dz4sg0Qp0_003D: false, _0023_003DzO_zXKB8GLR6U);
		linkedListNode.Value._0023_003Dz_0024XzHXc_t9UEOpUYn2g_003D_003D(_0023_003DzcXkiOibhYRCo);
		linkedListNode2.Value._0023_003Dz_0024XzHXc_t9UEOpUYn2g_003D_003D(_0023_003DzcXkiOibhYRCo);
		linkedListNode.Value._0023_003Dz4701yxQ2_0024axv = _0023_003Dz0S6lrCnKpmzi;
		linkedListNode.Value._0023_003DzEemH6ZA_003D = _0023_003Dz8recRnxe9UGp;
		linkedListNode2.Value._0023_003Dz4701yxQ2_0024axv = _0023_003Dz8recRnxe9UGp;
		linkedListNode2.Value._0023_003DzEemH6ZA_003D = _0023_003Dz0S6lrCnKpmzi;
		linkedListNode.Value._0023_003Dzg_d2bCm63KSux51d6w_003D_003D = linkedListNode2;
		linkedListNode.Value._0023_003DzQC2DY_0024geS4zZUaYo9w_003D_003D = _0023_003Dz2IDzvZDNJh6e;
		linkedListNode2.Value._0023_003Dzg_d2bCm63KSux51d6w_003D_003D = linkedListNode;
		linkedListNode2.Value._0023_003DzQC2DY_0024geS4zZUaYo9w_003D_003D = _0023_003DzH8zaF5A8WC6a;
		linkedListNode.Value._0023_003DzB62SYmA_003D = _0023_003DzsmsbDy4_003D.Value._0023_003DzB62SYmA_003D;
		linkedListNode2.Value._0023_003DzB62SYmA_003D = _0023_003DzHdmzMag_003D.Value._0023_003DzB62SYmA_003D;
		_0023_003DzH8zaF5A8WC6a._0023_003DzwVFSvec_003D(linkedListNode, _0023_003DzsmsbDy4_003D, _0023_003DzgzbF5Pk_003D);
		_0023_003Dz2IDzvZDNJh6e._0023_003DzwVFSvec_003D(linkedListNode2, _0023_003DzHdmzMag_003D, _0023_003Dz_rfvKVg_003D);
	}

	private static bool _0023_003DzawRGo_YtepVl(_0023_003Dz_0024WkMNd__uiAK _0023_003DzH8zaF5A8WC6a, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz2IDzvZDNJh6e, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzsmsbDy4_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzgzbF5Pk_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzHdmzMag_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz_rfvKVg_003D, double _0023_003DzccAR5G0_003D)
	{
		if (_0023_003DzsmsbDy4_003D == null || _0023_003DzgzbF5Pk_003D == null || _0023_003DzHdmzMag_003D == null || _0023_003Dz_rfvKVg_003D == null)
		{
			return false;
		}
		ICurve curve = _0023_003Dz4qecmD8_003D(_0023_003DzsmsbDy4_003D);
		ICurve curve2 = _0023_003Dz4qecmD8_003D(_0023_003DzHdmzMag_003D);
		bool _0023_003DzDpmG2EZ4smAi;
		Point3D _0023_003DzMlCq3wk_003D = _0023_003DzpCjS5_B6gDeE(_0023_003DzH8zaF5A8WC6a._0023_003DzXCecWa6CYPEG, _0023_003DzsmsbDy4_003D.Value, _0023_003DzgzbF5Pk_003D.Value, _0023_003DzHdmzMag_003D.Value, _0023_003Dz_rfvKVg_003D.Value, curve, curve2, _0023_003DzccAR5G0_003D, out _0023_003DzDpmG2EZ4smAi);
		if (_0023_003DzMlCq3wk_003D == null || !_0023_003DzVNnz7lw1Hu7b(ref _0023_003DzMlCq3wk_003D, curve, _0023_003DzsmsbDy4_003D.Value, _0023_003DzgzbF5Pk_003D.Value, _0023_003DzccAR5G0_003D) || !_0023_003DzVNnz7lw1Hu7b(ref _0023_003DzMlCq3wk_003D, curve2, _0023_003DzHdmzMag_003D.Value, _0023_003Dz_rfvKVg_003D.Value, _0023_003DzccAR5G0_003D))
		{
			return false;
		}
		Segment3D segment3D = new Segment3D(_0023_003DzsmsbDy4_003D.Value._0023_003Dz114WmwtBjoiC, _0023_003DzgzbF5Pk_003D.Value._0023_003Dz114WmwtBjoiC);
		Segment3D segment3D2 = new Segment3D(_0023_003DzHdmzMag_003D.Value._0023_003Dz114WmwtBjoiC, _0023_003Dz_rfvKVg_003D.Value._0023_003Dz114WmwtBjoiC);
		double num = segment3D.Project(_0023_003DzMlCq3wk_003D);
		double _0023_003DzO_zXKB8GLR6U = segment3D2.Project(_0023_003DzMlCq3wk_003D);
		Point2D point2D = new Segment2D(_0023_003DzsmsbDy4_003D.Value._0023_003Dzyk2fsPo_003D, _0023_003DzsmsbDy4_003D.Value._0023_003DzvXOLtKg_003D, _0023_003DzgzbF5Pk_003D.Value._0023_003Dzyk2fsPo_003D, _0023_003DzgzbF5Pk_003D.Value._0023_003DzvXOLtKg_003D).PointAt(num);
		_0023_003DzJaDV4_0_003D(new _0023_003DzfmsdmcfcBmDX((int)point2D.X, (int)point2D.Y)
		{
			_0023_003Dz114WmwtBjoiC = _0023_003DzMlCq3wk_003D
		}, _0023_003DzH8zaF5A8WC6a, _0023_003Dz2IDzvZDNJh6e, _0023_003DzsmsbDy4_003D, _0023_003DzgzbF5Pk_003D, _0023_003DzHdmzMag_003D, _0023_003Dz_rfvKVg_003D, curve, curve2, num, _0023_003DzO_zXKB8GLR6U);
		return true;
	}

	private static void _0023_003DzyTTYiNcgJGUIqaXVpg_003D_003D(ref LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzRXJWLHs_003D)
	{
		while (_0023_003DzRXJWLHs_003D != null && _0023_003DzRXJWLHs_003D.Value._0023_003Dz9h5MY_A_003D)
		{
			_0023_003DzRXJWLHs_003D = _0023_003DzRXJWLHs_003D.Next;
		}
	}

	private static void _0023_003DzLLNrSWjqKJtfA46_00243g_003D_003D(ref LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzRXJWLHs_003D)
	{
		while (_0023_003DzRXJWLHs_003D != null && _0023_003DzRXJWLHs_003D.Value._0023_003Dz9h5MY_A_003D)
		{
			_0023_003DzRXJWLHs_003D = _0023_003DzRXJWLHs_003D.Previous;
		}
	}

	private static ICurve _0023_003Dzxx88swO3rjcf(Plane _0023_003Dzrgqz890sj_0024X9, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzAqOpw0w_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dzk64JNOo_003D, Line _0023_003Dz6VDL59FiRjLS, ICurve _0023_003Dz8fpRyMu9aKjE, double _0023_003DzccAR5G0_003D)
	{
		ICurve curve = new Line(_0023_003DzAqOpw0w_003D.Value._0023_003Dz114WmwtBjoiC, _0023_003Dzk64JNOo_003D.Value._0023_003Dz114WmwtBjoiC);
		if (_0023_003Dz8fpRyMu9aKjE is TrimCurve)
		{
			curve = ((TrimCurve)_0023_003Dz8fpRyMu9aKjE).GetNurbsForm().GetTrimCurve();
		}
		double length = new Segment2D(_0023_003DzAqOpw0w_003D.Value._0023_003Dzyk2fsPo_003D, _0023_003DzAqOpw0w_003D.Value._0023_003DzvXOLtKg_003D, _0023_003Dzk64JNOo_003D.Value._0023_003Dzyk2fsPo_003D, _0023_003Dzk64JNOo_003D.Value._0023_003DzvXOLtKg_003D).Length;
		_0023_003DzAqOpw0w_003D.Value._0023_003DzEemH6ZA_003D = curve;
		if (_0023_003Dzk64JNOo_003D.Value._0023_003DzEemH6ZA_003D == null)
		{
			_0023_003Dzk64JNOo_003D.Value._0023_003DzEemH6ZA_003D = _0023_003Dzk64JNOo_003D.Value._0023_003Dz4701yxQ2_0024axv;
		}
		_0023_003Dzk64JNOo_003D.Value._0023_003Dz4701yxQ2_0024axv = curve;
		for (LinkedListNode<_0023_003DzfmsdmcfcBmDX> next = _0023_003DzAqOpw0w_003D.Next; next != _0023_003Dzk64JNOo_003D; next = next.Next)
		{
			Segment2D segment2D = new Segment2D(_0023_003DzAqOpw0w_003D.Value._0023_003Dzyk2fsPo_003D, _0023_003DzAqOpw0w_003D.Value._0023_003DzvXOLtKg_003D, next.Value._0023_003Dzyk2fsPo_003D, next.Value._0023_003DzvXOLtKg_003D);
			next.Value._0023_003DzbvIFYko_003D = segment2D.Length / length;
			next.Value._0023_003DzEemH6ZA_003D = curve;
			next.Value._0023_003Dzg_d2bCm63KSux51d6w_003D_003D.Value._0023_003Dz4701yxQ2_0024axv = curve;
			LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dzg_d2bCm63KSux51d6w_003D_003D = next.Value._0023_003Dzg_d2bCm63KSux51d6w_003D_003D;
			_0023_003DzorGleJ8S2gfTKjq63_mJeDo_003D(_0023_003Dzg_d2bCm63KSux51d6w_003D_003D, out var _0023_003Dz1BPEjBg_003D, out var _0023_003Dz1w6W_Pc_003D);
			next.Value._0023_003Dz114WmwtBjoiC = (_0023_003Dzg_d2bCm63KSux51d6w_003D_003D.Value._0023_003Dz114WmwtBjoiC = _0023_003DzpCjS5_B6gDeE(_0023_003Dzrgqz890sj_0024X9, _0023_003DzAqOpw0w_003D.Value, _0023_003Dzk64JNOo_003D.Value, _0023_003Dz1BPEjBg_003D.Value, _0023_003Dz1w6W_Pc_003D.Value, _0023_003Dz6VDL59FiRjLS, next.Value._0023_003Dz4701yxQ2_0024axv, _0023_003DzccAR5G0_003D, out var _));
		}
		return curve;
	}

	private static void _0023_003DzorGleJ8S2gfTKjq63_mJeDo_003D(LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzRXJWLHs_003D, out LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz1BPEjBg_003D, out LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003Dz1w6W_Pc_003D)
	{
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzRXJWLHs_003D;
		while (linkedListNode.Value._0023_003Dz9h5MY_A_003D)
		{
			linkedListNode = linkedListNode.Previous;
		}
		_0023_003Dz1BPEjBg_003D = linkedListNode;
		linkedListNode = _0023_003DzRXJWLHs_003D;
		while (linkedListNode.Value._0023_003Dz9h5MY_A_003D)
		{
			linkedListNode = linkedListNode.Next;
		}
		_0023_003Dz1w6W_Pc_003D = linkedListNode;
	}

	private static void _0023_003DzoirFDeXRPtSZ(IntegerGrid _0023_003DzOSo8vaE_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzYVDIcYzAKAZM)
	{
		int x = _0023_003DzOSo8vaE_003D.GridMin.X;
		int y = _0023_003DzOSo8vaE_003D.GridMin.Y;
		foreach (_0023_003DzfmsdmcfcBmDX item in _0023_003DzYVDIcYzAKAZM._0023_003DzvRAdRPd11xUJ())
		{
			if (item._0023_003Dzyk2fsPo_003D < _0023_003DzOSo8vaE_003D.GridMin.X)
			{
				x = item._0023_003Dzyk2fsPo_003D - 1;
			}
			if (item._0023_003DzvXOLtKg_003D < _0023_003DzOSo8vaE_003D.GridMin.Y)
			{
				y = item._0023_003DzvXOLtKg_003D - 1;
			}
		}
		_0023_003DzOSo8vaE_003D.GridMin = new System.Drawing.Point(x, y);
	}

	private static bool _0023_003DzVNnz7lw1Hu7b(ref Point3D _0023_003DzMlCq3wk_003D, ICurve _0023_003Dz8fpRyMu9aKjE, _0023_003DzfmsdmcfcBmDX _0023_003DzRXJWLHs_003D, _0023_003DzfmsdmcfcBmDX _0023_003DzvmFFjUs_003D, double _0023_003DzccAR5G0_003D)
	{
		_0023_003DzuF_hKcEcFSTT(_0023_003DzRXJWLHs_003D, _0023_003DzvmFFjUs_003D, _0023_003Dz8fpRyMu9aKjE, out var _0023_003DzSOVRV5I_003D, out var _0023_003Dzjy5MYbs_003D);
		_0023_003Dz8fpRyMu9aKjE.Project(_0023_003DzMlCq3wk_003D, out var t);
		if (!_0023_003DzYnGz5rR67yOP(t, _0023_003DzSOVRV5I_003D, _0023_003Dzjy5MYbs_003D, _0023_003Dz8fpRyMu9aKjE.Domain, _0023_003Dz8fpRyMu9aKjE.IsClosed))
		{
			return false;
		}
		Point3D _0023_003DzW7Zyxfc_003D = _0023_003Dz8fpRyMu9aKjE.PointAt(t);
		return _0023_003DzMAxShrbxTEQp(_0023_003DzMlCq3wk_003D, _0023_003DzW7Zyxfc_003D, _0023_003DzccAR5G0_003D);
	}

	private static bool _0023_003DzMAxShrbxTEQp(Point3D _0023_003DzMEwtr_A_003D, Point3D _0023_003DzW7Zyxfc_003D, double _0023_003DzccAR5G0_003D)
	{
		return Point3D.AreEqual(_0023_003DzMEwtr_A_003D, _0023_003DzW7Zyxfc_003D, _0023_003DzccAR5G0_003D * 1000.0);
	}

	private static IEnumerable<_0023_003Dz_0024WkMNd__uiAK> _0023_003DzolnrLtt3J7cXXfADmrLKG_Y_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzN57VxTE7ZsCw)
	{
		List<_0023_003Dz_0024WkMNd__uiAK> list = new List<_0023_003Dz_0024WkMNd__uiAK>();
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzN57VxTE7ZsCw._0023_003DzvRAdRPd11xUJ().First;
		_0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK2 = new _0023_003Dz_0024WkMNd__uiAK(_0023_003DzN57VxTE7ZsCw._0023_003DzXCecWa6CYPEG);
		while (linkedListNode != null)
		{
			_0023_003DzfmsdmcfcBmDX value = linkedListNode.Value;
			if (_0023_003Dz_0024WkMNd__uiAK2._0023_003DzLh1CFIntBKvS(value._0023_003Dz114WmwtBjoiC, out var _0023_003Dz7HSf5qk_003D) && _0023_003Dz7HSf5qk_003D != _0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().Last)
			{
				if (_0023_003Dz7HSf5qk_003D.Value != _0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().First.Value)
				{
					_0023_003Dz_0024WkMNd__uiAK _0023_003Dz_0024WkMNd__uiAK3 = new _0023_003Dz_0024WkMNd__uiAK(_0023_003DzN57VxTE7ZsCw._0023_003DzXCecWa6CYPEG);
					LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode2 = _0023_003Dz7HSf5qk_003D;
					while (linkedListNode2 != null)
					{
						_0023_003Dz_0024WkMNd__uiAK3._0023_003DzvRAdRPd11xUJ().AddLast(linkedListNode2.Value);
						LinkedListNode<_0023_003DzfmsdmcfcBmDX> node = linkedListNode2;
						linkedListNode2 = linkedListNode2.Next;
						_0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().Remove(node);
					}
					_0023_003Dz_0024WkMNd__uiAK3._0023_003DzvRAdRPd11xUJ().AddLast(value);
					if (_0023_003Dz_0024WkMNd__uiAK3._0023_003DzvRAdRPd11xUJ().Count > 3)
					{
						list.Add(_0023_003Dz_0024WkMNd__uiAK3);
					}
				}
				else
				{
					_0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().AddLast(value);
					if (_0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().Count > 3)
					{
						list.Add(_0023_003Dz_0024WkMNd__uiAK2);
					}
					_0023_003Dz_0024WkMNd__uiAK2 = new _0023_003Dz_0024WkMNd__uiAK(_0023_003DzN57VxTE7ZsCw._0023_003DzXCecWa6CYPEG);
				}
				_0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().AddLast(value);
			}
			else
			{
				_0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().AddLast(value);
			}
			linkedListNode = linkedListNode.Next;
		}
		if (_0023_003Dz_0024WkMNd__uiAK2._0023_003DzvRAdRPd11xUJ().Count > 3)
		{
			if (list.Count > 0)
			{
				if (list[list.Count - 1] != _0023_003Dz_0024WkMNd__uiAK2)
				{
					list.Add(_0023_003Dz_0024WkMNd__uiAK2);
				}
			}
			else
			{
				list.Add(_0023_003Dz_0024WkMNd__uiAK2);
			}
		}
		return list;
	}

	private static LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzPiLzKI3b4WO3NJHc5CAa_002474_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzbeYh0T7auJLy, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz3rH5rdsPb_002452, IntegerGrid _0023_003DzOSo8vaE_003D, LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzJHE44z8_003D)
	{
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = Utility.CircularNext(_0023_003DzJHE44z8_003D);
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode2 = _0023_003DzJHE44z8_003D;
		while (linkedListNode != linkedListNode2)
		{
			if (!_0023_003DzJHE44z8_003D.Value._0023_003Dz4sg0Qp0_003D && _0023_003DzJHE44z8_003D.Value._0023_003Dz9h5MY_A_003D)
			{
				if (!linkedListNode.Value._0023_003Dz9h5MY_A_003D && !linkedListNode.Value._0023_003DzY5Z6MBUHWoYl())
				{
					break;
				}
				ICurve _0023_003DzEemH6ZA_003D = _0023_003DzJHE44z8_003D.Value._0023_003DzEemH6ZA_003D;
				_0023_003DzEemH6ZA_003D.Project(_0023_003DzJHE44z8_003D.Value._0023_003Dz114WmwtBjoiC, out var t);
				_0023_003DzEemH6ZA_003D.Project(linkedListNode.Value._0023_003Dz114WmwtBjoiC, out var t2);
				double t3 = (t + t2) / 2.0;
				Point3D _0023_003DzMlCq3wk_003D = _0023_003DzEemH6ZA_003D.PointAt(t3);
				if (!_0023_003DzbeYh0T7auJLy._0023_003DzxCk23RO6L16o(_0023_003DzOSo8vaE_003D, _0023_003DzMlCq3wk_003D).Value._0023_003DzHRi2oS0_003D(_0023_003DzOSo8vaE_003D.GridMin, _0023_003Dz3rH5rdsPb_002452, _0023_003DzxInY1_piQJ1x: true, out var _))
				{
					break;
				}
			}
			_0023_003DzJHE44z8_003D = linkedListNode;
			linkedListNode = Utility.CircularNext(linkedListNode);
		}
		return _0023_003DzJHE44z8_003D;
	}

	private static void _0023_003DzMiYX984cUkaI3lGBbQ_003D_003D(_0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzN57VxTE7ZsCw, LinkedList<_0023_003DzfmsdmcfcBmDX> _0023_003Dz8CKzGQcGbPCU, double _0023_003DzccAR5G0_003D)
	{
		_0023_003DzfmsdmcfcBmDX value = _0023_003Dz8CKzGQcGbPCU.First.Value;
		_0023_003DzfmsdmcfcBmDX value2 = _0023_003Dz8CKzGQcGbPCU.Last.Value;
		if (!_0023_003DzMAxShrbxTEQp(value._0023_003Dz114WmwtBjoiC, value2._0023_003Dz114WmwtBjoiC, _0023_003DzccAR5G0_003D))
		{
			_0023_003DzN57VxTE7ZsCw._0023_003DzI3Qj44E_003D(value, _0023_003DzB62SYmA_003D: true);
		}
	}

	private static Point3D _0023_003DzpCjS5_B6gDeE(Plane _0023_003Dzrgqz890sj_0024X9, _0023_003DzfmsdmcfcBmDX _0023_003DzsmsbDy4_003D, _0023_003DzfmsdmcfcBmDX _0023_003DzgzbF5Pk_003D, _0023_003DzfmsdmcfcBmDX _0023_003DzHdmzMag_003D, _0023_003DzfmsdmcfcBmDX _0023_003Dz_rfvKVg_003D, ICurve _0023_003Dz8recRnxe9UGp, ICurve _0023_003Dz0S6lrCnKpmzi, double _0023_003DzccAR5G0_003D, out bool _0023_003DzDpmG2EZ4smAi)
	{
		_0023_003DzDpmG2EZ4smAi = false;
		if (!_0023_003Dz4Ea6EUBwStE4(_0023_003Dzrgqz890sj_0024X9, _0023_003Dz8recRnxe9UGp, _0023_003Dz0S6lrCnKpmzi, out var _0023_003DzVxmwB6Y_003D, out var _0023_003DzVS4Yj_A_003D))
		{
			return null;
		}
		Point3D _0023_003DzMlCq3wk_003D = null;
		_0023_003DzDpmG2EZ4smAi = _0023_003DzVxmwB6Y_003D != null || _0023_003DzVS4Yj_A_003D != null;
		if (_0023_003DzVxmwB6Y_003D != null)
		{
			_0023_003DzuF_hKcEcFSTT(_0023_003DzsmsbDy4_003D, _0023_003DzgzbF5Pk_003D, _0023_003Dz8recRnxe9UGp, out var _0023_003DzSOVRV5I_003D, out var _0023_003Dzjy5MYbs_003D);
			_0023_003DzuF_hKcEcFSTT(_0023_003DzHdmzMag_003D, _0023_003Dz_rfvKVg_003D, _0023_003Dz0S6lrCnKpmzi, out var _0023_003DzSOVRV5I_003D2, out var _0023_003Dzjy5MYbs_003D2);
			_0023_003Dz8recRnxe9UGp.ClosestPointTo(_0023_003DzVxmwB6Y_003D, out var t);
			_0023_003Dz0S6lrCnKpmzi.ClosestPointTo(_0023_003DzVxmwB6Y_003D, out var t2);
			if (!_0023_003DzYnGz5rR67yOP(t, _0023_003DzSOVRV5I_003D, _0023_003Dzjy5MYbs_003D, _0023_003Dz8recRnxe9UGp.Domain, _0023_003Dz8recRnxe9UGp.IsClosed) || !_0023_003DzYnGz5rR67yOP(t2, _0023_003DzSOVRV5I_003D2, _0023_003Dzjy5MYbs_003D2, _0023_003Dz0S6lrCnKpmzi.Domain, _0023_003Dz0S6lrCnKpmzi.IsClosed))
			{
				_0023_003DzVxmwB6Y_003D = null;
			}
			_0023_003DzMlCq3wk_003D = _0023_003DzVxmwB6Y_003D;
			if (_0023_003DzVS4Yj_A_003D != null)
			{
				_0023_003Dz8recRnxe9UGp.ClosestPointTo(_0023_003DzVS4Yj_A_003D, out var t3);
				_0023_003Dz0S6lrCnKpmzi.ClosestPointTo(_0023_003DzVS4Yj_A_003D, out var t4);
				if (_0023_003DzYnGz5rR67yOP(t3, _0023_003DzSOVRV5I_003D, _0023_003Dzjy5MYbs_003D, _0023_003Dz8recRnxe9UGp.Domain, _0023_003Dz8recRnxe9UGp.IsClosed) && _0023_003DzYnGz5rR67yOP(t4, _0023_003DzSOVRV5I_003D2, _0023_003Dzjy5MYbs_003D2, _0023_003Dz0S6lrCnKpmzi.Domain, _0023_003Dz0S6lrCnKpmzi.IsClosed))
				{
					if (_0023_003DzVxmwB6Y_003D == null)
					{
						_0023_003DzMlCq3wk_003D = _0023_003DzVS4Yj_A_003D;
					}
					else
					{
						_0023_003Dz8recRnxe9UGp.ClosestPointTo(_0023_003DzVxmwB6Y_003D, out t);
						_0023_003Dz0S6lrCnKpmzi.ClosestPointTo(_0023_003DzVxmwB6Y_003D, out t2);
						Point3D a = _0023_003Dz8recRnxe9UGp.PointAt(t);
						Point3D b = _0023_003Dz0S6lrCnKpmzi.PointAt(t2);
						Point3D a2 = _0023_003Dz8recRnxe9UGp.PointAt(t3);
						Point3D b2 = _0023_003Dz0S6lrCnKpmzi.PointAt(t4);
						double lengthSquared = Vector3D.Subtract(a2, b2).LengthSquared;
						double lengthSquared2 = Vector3D.Subtract(a, b).LengthSquared;
						if (lengthSquared < lengthSquared2)
						{
							_0023_003DzMlCq3wk_003D = _0023_003DzVS4Yj_A_003D;
						}
					}
				}
			}
			if (_0023_003DzMlCq3wk_003D != null && (!_0023_003DzVNnz7lw1Hu7b(ref _0023_003DzMlCq3wk_003D, _0023_003Dz8recRnxe9UGp, _0023_003DzsmsbDy4_003D, _0023_003DzgzbF5Pk_003D, _0023_003DzccAR5G0_003D) || !_0023_003DzVNnz7lw1Hu7b(ref _0023_003DzMlCq3wk_003D, _0023_003Dz0S6lrCnKpmzi, _0023_003DzHdmzMag_003D, _0023_003Dz_rfvKVg_003D, _0023_003DzccAR5G0_003D)))
			{
				return null;
			}
		}
		return _0023_003DzMlCq3wk_003D;
	}

	private static bool _0023_003Dz4Ea6EUBwStE4(Plane _0023_003Dzrgqz890sj_0024X9, ICurve _0023_003Dz8recRnxe9UGp, ICurve _0023_003Dz0S6lrCnKpmzi, out Point3D _0023_003DzVxmwB6Y_003D, out Point3D _0023_003DzVS4Yj_A_003D)
	{
		_0023_003DzVxmwB6Y_003D = null;
		_0023_003DzVS4Yj_A_003D = null;
		if (_0023_003Dz8recRnxe9UGp == _0023_003Dz0S6lrCnKpmzi)
		{
			return false;
		}
		if (_0023_003Dz8recRnxe9UGp is Line)
		{
			Line line = (Line)_0023_003Dz8recRnxe9UGp;
			if (_0023_003Dz0S6lrCnKpmzi is Circle)
			{
				Circle arc = (Circle)_0023_003Dz0S6lrCnKpmzi;
				Utility.IntersectionLineCircle(line, arc, _0023_003Dzrgqz890sj_0024X9, out _0023_003DzVxmwB6Y_003D, out _0023_003DzVS4Yj_A_003D);
			}
			else if (_0023_003Dz0S6lrCnKpmzi is Line)
			{
				Line line2 = (Line)_0023_003Dz0S6lrCnKpmzi;
				Utility.IntersectionLineLine(line, line2, _0023_003Dzrgqz890sj_0024X9, out _0023_003DzVxmwB6Y_003D);
			}
			else
			{
				Curve nurbsForm = _0023_003Dz0S6lrCnKpmzi.GetNurbsForm();
				if (nurbsForm.IsLine)
				{
					Utility.IntersectionLineLine(line, new Line(nurbsForm.StartPoint, nurbsForm.EndPoint), _0023_003Dzrgqz890sj_0024X9, out _0023_003DzVxmwB6Y_003D);
				}
				else
				{
					Point3D[] _0023_003Dzov9kS8rXOl_0024 = Utility.Intersection(_0023_003Dz8recRnxe9UGp, nurbsForm, 0.0);
					_0023_003DzpqHEAlA_003D(ref _0023_003DzVxmwB6Y_003D, ref _0023_003DzVS4Yj_A_003D, _0023_003Dzov9kS8rXOl_0024);
				}
			}
		}
		else if (_0023_003Dz8recRnxe9UGp is Circle)
		{
			Circle circle = (Circle)_0023_003Dz8recRnxe9UGp;
			if (_0023_003Dz0S6lrCnKpmzi is Circle)
			{
				Circle arc2 = (Circle)_0023_003Dz0S6lrCnKpmzi;
				Utility.IntersectionCircleCircle(circle, arc2, _0023_003Dzrgqz890sj_0024X9, out _0023_003DzVxmwB6Y_003D, out _0023_003DzVS4Yj_A_003D);
			}
			else if (_0023_003Dz0S6lrCnKpmzi is Line)
			{
				Utility.IntersectionLineCircle((Line)_0023_003Dz0S6lrCnKpmzi, circle, _0023_003Dzrgqz890sj_0024X9, out _0023_003DzVxmwB6Y_003D, out _0023_003DzVS4Yj_A_003D);
			}
			else
			{
				Curve nurbsForm2 = _0023_003Dz0S6lrCnKpmzi.GetNurbsForm();
				if (nurbsForm2.IsLine)
				{
					Utility.IntersectionLineCircle(new Line(nurbsForm2.StartPoint, nurbsForm2.EndPoint), circle, _0023_003Dzrgqz890sj_0024X9, out _0023_003DzVxmwB6Y_003D, out _0023_003DzVS4Yj_A_003D);
				}
				else
				{
					Point3D[] _0023_003Dzov9kS8rXOl_00242 = Utility.Intersection(_0023_003Dz8recRnxe9UGp, nurbsForm2, 0.0);
					_0023_003DzpqHEAlA_003D(ref _0023_003DzVxmwB6Y_003D, ref _0023_003DzVS4Yj_A_003D, _0023_003Dzov9kS8rXOl_00242);
				}
			}
		}
		else
		{
			Curve nurbsForm3 = _0023_003Dz8recRnxe9UGp.GetNurbsForm();
			if (nurbsForm3.IsLine)
			{
				Line line3 = new Line(nurbsForm3.StartPoint, nurbsForm3.EndPoint);
				if (_0023_003Dz0S6lrCnKpmzi is Circle)
				{
					Circle arc3 = (Circle)_0023_003Dz0S6lrCnKpmzi;
					Utility.IntersectionLineCircle(line3, arc3, _0023_003Dzrgqz890sj_0024X9, out _0023_003DzVxmwB6Y_003D, out _0023_003DzVS4Yj_A_003D);
				}
				else if (_0023_003Dz0S6lrCnKpmzi is Line)
				{
					Line line4 = (Line)_0023_003Dz0S6lrCnKpmzi;
					Utility.IntersectionLineLine(line3, line4, _0023_003Dzrgqz890sj_0024X9, out _0023_003DzVxmwB6Y_003D);
				}
				else
				{
					Curve nurbsForm4 = _0023_003Dz0S6lrCnKpmzi.GetNurbsForm();
					if (nurbsForm4.IsLine)
					{
						Line line5 = new Line(nurbsForm4.StartPoint, nurbsForm4.EndPoint);
						Utility.IntersectionLineLine(line3, line5, _0023_003Dzrgqz890sj_0024X9, out _0023_003DzVxmwB6Y_003D);
					}
					else
					{
						Point3D[] _0023_003Dzov9kS8rXOl_00243 = Utility.Intersection(nurbsForm3, nurbsForm4, 0.0);
						_0023_003DzpqHEAlA_003D(ref _0023_003DzVxmwB6Y_003D, ref _0023_003DzVS4Yj_A_003D, _0023_003Dzov9kS8rXOl_00243);
					}
				}
			}
			else
			{
				Point3D[] _0023_003Dzov9kS8rXOl_00244 = Utility.Intersection(_0023_003Dz8recRnxe9UGp, _0023_003Dz0S6lrCnKpmzi, 0.0);
				_0023_003DzpqHEAlA_003D(ref _0023_003DzVxmwB6Y_003D, ref _0023_003DzVS4Yj_A_003D, _0023_003Dzov9kS8rXOl_00244);
			}
		}
		return true;
	}

	private static void _0023_003DzpqHEAlA_003D(ref Point3D _0023_003DzVxmwB6Y_003D, ref Point3D _0023_003DzVS4Yj_A_003D, Point3D[] _0023_003Dzov9kS8rXOl_00241)
	{
		if (_0023_003Dzov9kS8rXOl_00241 != null)
		{
			if (_0023_003Dzov9kS8rXOl_00241.Length != 0)
			{
				_0023_003DzVxmwB6Y_003D = _0023_003Dzov9kS8rXOl_00241[0];
			}
			if (_0023_003Dzov9kS8rXOl_00241.Length > 1)
			{
				_0023_003DzVS4Yj_A_003D = _0023_003Dzov9kS8rXOl_00241[1];
			}
		}
	}

	private static bool _0023_003DzYnGz5rR67yOP(double _0023_003DzNDQ_E88_003D, double _0023_003DzF7v9r2A_003D, double _0023_003Dz8dK2uhU_003D, Interval _0023_003DzhbkBViI_003D, bool _0023_003DzJILVAq5STJCSZpWRgQ_003D_003D)
	{
		if (_0023_003DzF7v9r2A_003D <= _0023_003Dz8dK2uhU_003D)
		{
			if (_0023_003DzJILVAq5STJCSZpWRgQ_003D_003D)
			{
				if (Math.Abs(_0023_003DzhbkBViI_003D.Max - _0023_003Dz8dK2uhU_003D) < Utility._0023_003DzheSR8QM7q9ya)
				{
					if (!(_0023_003DzNDQ_E88_003D >= _0023_003DzF7v9r2A_003D - Utility._0023_003DzheSR8QM7q9ya) || !(_0023_003DzNDQ_E88_003D <= _0023_003Dz8dK2uhU_003D + Utility._0023_003DzheSR8QM7q9ya))
					{
						return Math.Abs(_0023_003DzhbkBViI_003D.Min - _0023_003DzNDQ_E88_003D) < Utility._0023_003DzheSR8QM7q9ya;
					}
					return true;
				}
				if (Math.Abs(_0023_003DzhbkBViI_003D.Min - _0023_003DzF7v9r2A_003D) < Utility._0023_003DzheSR8QM7q9ya)
				{
					if (!(_0023_003DzNDQ_E88_003D >= _0023_003DzF7v9r2A_003D - Utility._0023_003DzheSR8QM7q9ya) || !(_0023_003DzNDQ_E88_003D <= _0023_003Dz8dK2uhU_003D + Utility._0023_003DzheSR8QM7q9ya))
					{
						return Math.Abs(_0023_003DzhbkBViI_003D.Max - _0023_003DzNDQ_E88_003D) < Utility._0023_003DzheSR8QM7q9ya;
					}
					return true;
				}
			}
			if (_0023_003DzNDQ_E88_003D >= _0023_003DzF7v9r2A_003D - Utility._0023_003DzheSR8QM7q9ya)
			{
				return _0023_003DzNDQ_E88_003D <= _0023_003Dz8dK2uhU_003D + Utility._0023_003DzheSR8QM7q9ya;
			}
			return false;
		}
		if (!(_0023_003DzNDQ_E88_003D >= _0023_003DzF7v9r2A_003D - Utility._0023_003DzheSR8QM7q9ya) || !(_0023_003DzNDQ_E88_003D <= _0023_003DzhbkBViI_003D.Max + Utility._0023_003DzheSR8QM7q9ya))
		{
			if (_0023_003DzNDQ_E88_003D >= _0023_003DzhbkBViI_003D.Min - Utility._0023_003DzheSR8QM7q9ya)
			{
				return _0023_003DzNDQ_E88_003D <= _0023_003Dz8dK2uhU_003D + Utility._0023_003DzheSR8QM7q9ya;
			}
			return false;
		}
		return true;
	}

	private static void _0023_003DzuF_hKcEcFSTT(_0023_003DzfmsdmcfcBmDX _0023_003DziUf1xw4_003D, _0023_003DzfmsdmcfcBmDX _0023_003DzvmFFjUs_003D, ICurve _0023_003Dz8fpRyMu9aKjE, out double _0023_003DzSOVRV5I_003D, out double _0023_003Dzjy5MYbs_003D)
	{
		if (_0023_003DziUf1xw4_003D._0023_003DzB62SYmA_003D)
		{
			_0023_003Dz8fpRyMu9aKjE.Project(_0023_003DziUf1xw4_003D._0023_003Dz114WmwtBjoiC, out _0023_003DzSOVRV5I_003D);
			_0023_003Dz8fpRyMu9aKjE.Project(_0023_003DzvmFFjUs_003D._0023_003Dz114WmwtBjoiC, out _0023_003Dzjy5MYbs_003D);
		}
		else
		{
			_0023_003Dz8fpRyMu9aKjE.Project(_0023_003DzvmFFjUs_003D._0023_003Dz114WmwtBjoiC, out _0023_003DzSOVRV5I_003D);
			_0023_003Dz8fpRyMu9aKjE.Project(_0023_003DziUf1xw4_003D._0023_003Dz114WmwtBjoiC, out _0023_003Dzjy5MYbs_003D);
		}
		if (_0023_003DzSOVRV5I_003D >= _0023_003Dz8fpRyMu9aKjE.Domain.Max - Utility._0023_003DzheSR8QM7q9ya)
		{
			_0023_003DzSOVRV5I_003D -= _0023_003Dz8fpRyMu9aKjE.Domain.Max;
		}
		if (_0023_003Dz8fpRyMu9aKjE.IsClosed && _0023_003Dzjy5MYbs_003D < _0023_003DzSOVRV5I_003D)
		{
			_0023_003Dzjy5MYbs_003D += _0023_003Dz8fpRyMu9aKjE.Domain.Max;
		}
		else if (_0023_003Dzjy5MYbs_003D < _0023_003DzSOVRV5I_003D)
		{
			double num = _0023_003Dzjy5MYbs_003D;
			_0023_003Dzjy5MYbs_003D = _0023_003DzSOVRV5I_003D;
			_0023_003DzSOVRV5I_003D = num;
		}
	}

	[Conditional("DEBUG")]
	private static void _0023_003DzZrgXqjgeFeSakLdIKg_003D_003D(_0023_003Dz_0024WkMNd__uiAK _0023_003DzbeYh0T7auJLy, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz3rH5rdsPb_002452)
	{
	}

	private static ICurve _0023_003Dz4qecmD8_003D(LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzRXJWLHs_003D)
	{
		return _0023_003DzRXJWLHs_003D.Value._0023_003DzEemH6ZA_003D ?? _0023_003DzRXJWLHs_003D.Value._0023_003Dz4701yxQ2_0024axv;
	}

	private static ICurve _0023_003Dz4qecmD8_003D(_0023_003DzfmsdmcfcBmDX _0023_003DzRXJWLHs_003D)
	{
		return _0023_003DzRXJWLHs_003D._0023_003DzEemH6ZA_003D ?? _0023_003DzRXJWLHs_003D._0023_003Dz4701yxQ2_0024axv;
	}

	private static bool _0023_003Dz1XaDMdch3IyA(_0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzbeYh0T7auJLy, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz3rH5rdsPb_002452, List<_0023_003Dz_0024WkMNd__uiAK> _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D, out _0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D)
	{
		_0023_003DzOLHnb2M_003D = (_0023_003DzRrz47AY_003D)0;
		if (_0023_003DzbeYh0T7auJLy._0023_003DzvRAdRPd11xUJ().Count != _0023_003Dz3rH5rdsPb_002452._0023_003DzvRAdRPd11xUJ().Count)
		{
			return false;
		}
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode = _0023_003DzbeYh0T7auJLy._0023_003DzvRAdRPd11xUJ().First;
		LinkedListNode<_0023_003DzfmsdmcfcBmDX> linkedListNode2 = _0023_003Dz3rH5rdsPb_002452._0023_003DzvRAdRPd11xUJ().First;
		bool flag = false;
		while (linkedListNode2 != null)
		{
			if (_0023_003DzMAxShrbxTEQp(linkedListNode2.Value, linkedListNode.Value))
			{
				flag = true;
				break;
			}
			linkedListNode2 = linkedListNode2.Next;
		}
		bool flag2 = false;
		if (flag)
		{
			flag2 = true;
			while (linkedListNode != null)
			{
				linkedListNode = linkedListNode.Next;
				if (linkedListNode == _0023_003DzbeYh0T7auJLy._0023_003DzvRAdRPd11xUJ().Last)
				{
					break;
				}
				linkedListNode2 = linkedListNode2.Next;
				if (linkedListNode2 == null)
				{
					linkedListNode2 = _0023_003Dz3rH5rdsPb_002452._0023_003DzvRAdRPd11xUJ().First.Next;
				}
				if (!_0023_003DzMAxShrbxTEQp(linkedListNode.Value, linkedListNode2.Value))
				{
					flag2 = false;
					break;
				}
			}
		}
		if (flag2)
		{
			switch (_0023_003DzwY9ClXw_003D)
			{
			case (_0023_003Dz4JAfHNw_003D)0:
			case (_0023_003Dz4JAfHNw_003D)1:
				_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Add(_0023_003DzbeYh0T7auJLy);
				_0023_003DzOLHnb2M_003D = (_0023_003DzRrz47AY_003D)1;
				return true;
			case (_0023_003Dz4JAfHNw_003D)2:
				_0023_003DzOLHnb2M_003D = (_0023_003DzRrz47AY_003D)1;
				return true;
			}
		}
		return false;
	}

	private static bool _0023_003DzVK3SyL83IH2S(_0023_003Dz4JAfHNw_003D _0023_003DzwY9ClXw_003D, _0023_003Dz_0024WkMNd__uiAK _0023_003DzbeYh0T7auJLy, _0023_003Dz_0024WkMNd__uiAK _0023_003Dz3rH5rdsPb_002452, List<_0023_003Dz_0024WkMNd__uiAK> _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D, out _0023_003DzRrz47AY_003D _0023_003DzOLHnb2M_003D)
	{
		bool flag = _0023_003DzbeYh0T7auJLy._0023_003Dz3OUgTc6NJDSeK7PSaSCx3t4_003D();
		bool flag2 = _0023_003DzbeYh0T7auJLy._0023_003DzeQ_NBHN_0024KOGpVqPa4KGB3Zs_003D();
		_0023_003DzOLHnb2M_003D = (_0023_003DzRrz47AY_003D)1;
		switch (_0023_003DzwY9ClXw_003D)
		{
		case (_0023_003Dz4JAfHNw_003D)1:
			if (flag)
			{
				_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Add(_0023_003DzbeYh0T7auJLy);
			}
			else if (_0023_003Dz3rH5rdsPb_002452._0023_003Dz3OUgTc6NJDSeK7PSaSCx3t4_003D())
			{
				_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Add(_0023_003Dz3rH5rdsPb_002452);
				_0023_003DzOLHnb2M_003D = (_0023_003DzRrz47AY_003D)2;
			}
			else if (!flag2 && !_0023_003Dz3rH5rdsPb_002452._0023_003DzeQ_NBHN_0024KOGpVqPa4KGB3Zs_003D())
			{
				_0023_003DzOLHnb2M_003D = (_0023_003DzRrz47AY_003D)0;
				return true;
			}
			break;
		case (_0023_003Dz4JAfHNw_003D)0:
			if (flag)
			{
				_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Add(_0023_003Dz3rH5rdsPb_002452);
			}
			else if (_0023_003Dz3rH5rdsPb_002452._0023_003Dz3OUgTc6NJDSeK7PSaSCx3t4_003D())
			{
				_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Add(_0023_003DzbeYh0T7auJLy);
				_0023_003DzOLHnb2M_003D = (_0023_003DzRrz47AY_003D)2;
			}
			else if (!flag2 && !_0023_003Dz3rH5rdsPb_002452._0023_003DzeQ_NBHN_0024KOGpVqPa4KGB3Zs_003D())
			{
				_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Add(_0023_003DzbeYh0T7auJLy);
				_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Add(_0023_003Dz3rH5rdsPb_002452);
				_0023_003DzOLHnb2M_003D = (_0023_003DzRrz47AY_003D)0;
			}
			break;
		case (_0023_003Dz4JAfHNw_003D)2:
			if (flag)
			{
				return true;
			}
			if (_0023_003Dz3rH5rdsPb_002452._0023_003Dz3OUgTc6NJDSeK7PSaSCx3t4_003D())
			{
				_0023_003DzOLHnb2M_003D = (_0023_003DzRrz47AY_003D)2;
				_0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Add(_0023_003DzbeYh0T7auJLy);
			}
			break;
		}
		return _0023_003Dzzh09U4K0Sr5xS0I14A_003D_003D.Count > 0;
	}

	private static void _0023_003Dz7_s6bgYFmH8G(_0023_003Dz_0024WkMNd__uiAK _0023_003DzN57VxTE7ZsCw, ref LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzJHE44z8_003D, ref bool _0023_003DzB62SYmA_003D)
	{
		do
		{
			_0023_003DzfmsdmcfcBmDX value = _0023_003DzJHE44z8_003D.Value;
			if (!value._0023_003Dz4sg0Qp0_003D)
			{
				_0023_003DzN57VxTE7ZsCw._0023_003DzI3Qj44E_003D(value, _0023_003DzB62SYmA_003D);
				continue;
			}
			break;
		}
		while (_0023_003DzzSWftbomQ9qfYkGBAg_003D_003D(ref _0023_003DzJHE44z8_003D, _0023_003DzB62SYmA_003D));
	}

	private static void _0023_003DzVVAYzBWU9vnc(_0023_003Dz_0024WkMNd__uiAK _0023_003DzN57VxTE7ZsCw, bool _0023_003DzMysknNsi_GEDVQOmuA_003D_003D, bool _0023_003Dz5VJJ6NNa2dxh, ref LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzJHE44z8_003D, ref bool _0023_003DzB62SYmA_003D)
	{
		do
		{
			_0023_003DzfmsdmcfcBmDX value = _0023_003DzJHE44z8_003D.Value;
			if (value._0023_003Dz9h5MY_A_003D)
			{
				_0023_003DzB62SYmA_003D = !value._0023_003DzQuOBdG0_003D;
			}
			if (!value._0023_003Dz4sg0Qp0_003D)
			{
				if (value._0023_003Dz9h5MY_A_003D || !value._0023_003DzY5Z6MBUHWoYl())
				{
					_0023_003DzN57VxTE7ZsCw._0023_003DzI3Qj44E_003D(value, _0023_003DzB62SYmA_003D);
				}
				continue;
			}
			break;
		}
		while (_0023_003DzzSWftbomQ9qfYkGBAg_003D_003D(ref _0023_003DzJHE44z8_003D, _0023_003DzB62SYmA_003D));
	}

	private static void _0023_003DzN7HUm0e6EQcJ(_0023_003Dz_0024WkMNd__uiAK _0023_003DzN57VxTE7ZsCw, bool _0023_003DzMysknNsi_GEDVQOmuA_003D_003D, bool _0023_003Dz5VJJ6NNa2dxh, ref LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzJHE44z8_003D, ref bool _0023_003DzB62SYmA_003D)
	{
		do
		{
			_0023_003DzfmsdmcfcBmDX value = _0023_003DzJHE44z8_003D.Value;
			if (_0023_003DzN57VxTE7ZsCw._0023_003DzvRAdRPd11xUJ().First == null)
			{
				_0023_003DzB62SYmA_003D = true;
			}
			else if (value._0023_003Dz9h5MY_A_003D)
			{
				_0023_003DzB62SYmA_003D = !_0023_003DzB62SYmA_003D;
			}
			if (!value._0023_003Dz4sg0Qp0_003D)
			{
				_0023_003DzN57VxTE7ZsCw._0023_003DzI3Qj44E_003D(value, _0023_003DzB62SYmA_003D);
				continue;
			}
			break;
		}
		while (_0023_003DzzSWftbomQ9qfYkGBAg_003D_003D(ref _0023_003DzJHE44z8_003D, _0023_003DzB62SYmA_003D));
	}

	private static void _0023_003DzijcZBl3z2p5r(_0023_003Dz_0024WkMNd__uiAK _0023_003DzN57VxTE7ZsCw, bool _0023_003DzMysknNsi_GEDVQOmuA_003D_003D, bool _0023_003Dz5VJJ6NNa2dxh, ref LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzJHE44z8_003D, ref bool _0023_003DzB62SYmA_003D)
	{
		do
		{
			_0023_003DzfmsdmcfcBmDX value = _0023_003DzJHE44z8_003D.Value;
			if (value._0023_003Dz9h5MY_A_003D)
			{
				_0023_003DzB62SYmA_003D = value._0023_003DzQuOBdG0_003D;
			}
			if (!value._0023_003Dz4sg0Qp0_003D)
			{
				if (value._0023_003Dz9h5MY_A_003D || value._0023_003DzY5Z6MBUHWoYl())
				{
					_0023_003DzN57VxTE7ZsCw._0023_003DzI3Qj44E_003D(value, _0023_003DzB62SYmA_003D);
				}
				continue;
			}
			break;
		}
		while (_0023_003DzzSWftbomQ9qfYkGBAg_003D_003D(ref _0023_003DzJHE44z8_003D, _0023_003DzB62SYmA_003D));
	}

	private static bool _0023_003DzzSWftbomQ9qfYkGBAg_003D_003D(ref LinkedListNode<_0023_003DzfmsdmcfcBmDX> _0023_003DzJHE44z8_003D, bool _0023_003DzB62SYmA_003D)
	{
		_0023_003DzJHE44z8_003D.Value._0023_003Dz4sg0Qp0_003D = true;
		_0023_003DzJHE44z8_003D = (_0023_003DzB62SYmA_003D ? Utility.CircularNext(_0023_003DzJHE44z8_003D) : Utility.CircularPrevious(_0023_003DzJHE44z8_003D));
		if (_0023_003DzJHE44z8_003D.Value._0023_003Dz9h5MY_A_003D)
		{
			_0023_003DzJHE44z8_003D.Value._0023_003Dz4sg0Qp0_003D = true;
			return false;
		}
		return true;
	}
}
