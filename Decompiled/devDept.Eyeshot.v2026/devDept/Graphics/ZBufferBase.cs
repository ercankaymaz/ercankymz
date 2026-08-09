using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using devDept.Eyeshot;
using devDept.Geometry;

namespace devDept.Graphics;

public class ZBufferBase : IDisposable
{
	public class SelectionImageData
	{
		public int Stride;

		public int Bpp;

		public byte[] Image;

		public bool InsideBlockReference;

		public object IdItemsMap;

		public bool leafSelection;

		public object InnerIdItemsMap;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private byte[] _0023_003DzZN3YBJ5aN3Re_0024JrLbD7cUO4_003D;

		public bool SelectableOnly;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double[] _0023_003DzFkNUqF2Opl3L_TDtKEUS5iH6oNnAe2QsCQ_003D_003D = new double[16];

		public byte[] InnerSelectionImage
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzZN3YBJ5aN3Re_0024JrLbD7cUO4_003D;
			}
			[CompilerGenerated]
			set
			{
				_0023_003DzZN3YBJ5aN3Re_0024JrLbD7cUO4_003D = value;
			}
		}

		public double[] matrixAtCaptureInstant
		{
			[CompilerGenerated]
			get
			{
				return _0023_003DzFkNUqF2Opl3L_TDtKEUS5iH6oNnAe2QsCQ_003D_003D;
			}
		}

		internal void _0023_003DziblmIXg09vCH_0024v6VxuF8qrs_003D(double[] _0023_003DzPzO_0024GUk_003D)
		{
			_0023_003DzFkNUqF2Opl3L_TDtKEUS5iH6oNnAe2QsCQ_003D_003D = _0023_003DzPzO_0024GUk_003D;
		}

		public void Clear()
		{
			Image = null;
			InnerSelectionImage = null;
			for (int i = 0; i < 16; i++)
			{
				matrixAtCaptureInstant[i] = 0.0;
			}
			IdItemsMap = (InnerIdItemsMap = null);
		}

		internal bool _0023_003DzFSZfd_0024c_003D(double[] _0023_003Dze03mumNpWjRj, bool _0023_003DzvgNLS2zOH5H5)
		{
			if (Image == null)
			{
				return true;
			}
			if (leafSelection ^ _0023_003DzvgNLS2zOH5H5)
			{
				return true;
			}
			if (_0023_003DzvgNLS2zOH5H5 && IdItemsMap == null)
			{
				return true;
			}
			double num = Math.Abs(_0023_003Dze03mumNpWjRj[0]);
			foreach (double value in _0023_003Dze03mumNpWjRj)
			{
				if (Math.Abs(value) > num)
				{
					num = Math.Abs(value);
				}
			}
			for (int j = 0; j < _0023_003Dze03mumNpWjRj.Length; j++)
			{
				if (!Utility.AreEqual(_0023_003Dze03mumNpWjRj[j], matrixAtCaptureInstant[j], num))
				{
					return true;
				}
			}
			return false;
		}
	}

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003DzAZT6BTk_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private double _0023_003Dz0Jn_0024JRQ_003D;

	public double[] ModelViewMatrix;

	public double[] ProjectionMatrix;

	public Point3D Location;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003Dz6bce5ivCeGPXorI2hkYJ4Ng_003D;

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private bool _0023_003DzZmqggdE_003D;

	public int LinesReadIncrement;

	[CLSCompliant(false)]
	public const ushort MaxValue = 32767;

	public SelectionImageData SelectionImage = new SelectionImageData();

	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private Size _0023_003DzQZuJCK4_003D;

	public double Min
	{
		get
		{
			return _0023_003DzAZT6BTk_003D;
		}
		set
		{
			_0023_003DzAZT6BTk_003D = value;
		}
	}

	public double Max
	{
		get
		{
			return _0023_003Dz0Jn_0024JRQ_003D;
		}
		set
		{
			_0023_003Dz0Jn_0024JRQ_003D = value;
		}
	}

	public bool IsInvalidRange
	{
		[CompilerGenerated]
		get
		{
			return _0023_003Dz6bce5ivCeGPXorI2hkYJ4Ng_003D;
		}
	}

	public bool Dirty
	{
		get
		{
			return _0023_003DzZmqggdE_003D;
		}
		set
		{
			if (value)
			{
				_0023_003DzUFS4ARhBvr2L(_0023_003DzPzO_0024GUk_003D: true);
			}
			_0023_003DzZmqggdE_003D = value;
		}
	}

	public virtual Size Size
	{
		get
		{
			return _0023_003DzQZuJCK4_003D;
		}
		set
		{
			_0023_003DzQZuJCK4_003D = value;
		}
	}

	public ZBufferBase()
	{
		LinesReadIncrement = 1;
		_0023_003DzUFS4ARhBvr2L(_0023_003DzPzO_0024GUk_003D: true);
	}

	internal void _0023_003DzUFS4ARhBvr2L(bool _0023_003DzPzO_0024GUk_003D)
	{
		_0023_003Dz6bce5ivCeGPXorI2hkYJ4Ng_003D = _0023_003DzPzO_0024GUk_003D;
	}

	public virtual void Dispose()
	{
	}

	public virtual bool ReadZRange(RenderContextBase renderContext, Point centerCameraScreen, int width, int height, ref double zMin, ref double zMax, bool optimizeRead, int layoutWidth, int layoutHeight)
	{
		return false;
	}

	public virtual bool ReadPickBoxZRange(RenderContextBase renderContext, Point cameraScreenPos, int pickBoxSizeInPixels, ref double min, ref double max)
	{
		return false;
	}

	public virtual void ResetBmp()
	{
		SelectionImage.Clear();
		_0023_003DzUFS4ARhBvr2L(_0023_003DzPzO_0024GUk_003D: true);
	}

	public virtual byte[] CaptureBackbuffer(RenderContextBase renderContext, IViewport viewport, int viewportId, string workspaceId, bool keepData, object idItemsMap, bool selectableOnly, double[] modelViewProjectionMatrix, Rectangle rect, bool leafSelection, out int stride, out int bpp, bool innerImage = false)
	{
		throw new NotImplementedException();
	}

	public void ResetCapturedView()
	{
		SelectionImage.Clear();
	}

	public bool ChangedView(double[] modelViewProjectionMatrix, bool leafSelection)
	{
		return SelectionImage._0023_003DzFSZfd_0024c_003D(modelViewProjectionMatrix, leafSelection);
	}
}
