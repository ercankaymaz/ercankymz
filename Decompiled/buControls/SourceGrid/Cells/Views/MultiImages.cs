using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using ns27;

namespace SourceGrid.Cells.Views;

[Serializable]
public class MultiImages : Cell
{
	[CompilerGenerated]
	internal sealed class Class73 : IDisposable, IEnumerable, IEnumerator, IEnumerable<IVisualElement>, IEnumerator<IVisualElement>
	{
		internal int int_0;

		private IVisualElement ivisualElement_0;

		private int int_1;

		public MultiImages multiImages_0;

		internal IEnumerator<IVisualElement> ienumerator_0;

		private IVisualElement ivisualElement_1;

		internal List<IVisualElement>.Enumerator enumerator_0;

		private IVisualElement ivisualElement_2;

		IVisualElement IEnumerator<IVisualElement>.Current => ivisualElement_0;

		object IEnumerator.Current => ivisualElement_0;

		public Class73(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			switch (int_0)
			{
			case -4:
			case 2:
				try
				{
				}
				finally
				{
					Class76.smethod_417(this);
				}
				break;
			case -3:
			case 1:
				try
				{
				}
				finally
				{
					Class76.smethod_199(this);
				}
				break;
			}
			ienumerator_0 = null;
			ivisualElement_1 = null;
			enumerator_0 = default(List<IVisualElement>.Enumerator);
			ivisualElement_2 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				switch (int_0)
				{
				case 2:
					int_0 = -4;
					ivisualElement_2 = null;
					goto IL_002a;
				default:
					return false;
				case 0:
					int_0 = -1;
					ienumerator_0 = multiImages_0.method_0().GetEnumerator();
					int_0 = -3;
					goto IL_0091;
				case 1:
					{
						int_0 = -3;
						ivisualElement_1 = null;
						goto IL_0091;
					}
					IL_0091:
					if (ienumerator_0.MoveNext())
					{
						ivisualElement_1 = ienumerator_0.Current;
						ivisualElement_0 = ivisualElement_1;
						int_0 = 1;
						return true;
					}
					Class76.smethod_199(this);
					ienumerator_0 = null;
					enumerator_0 = multiImages_0.SubImages.GetEnumerator();
					int_0 = -4;
					goto IL_002a;
					IL_002a:
					if (enumerator_0.MoveNext())
					{
						ivisualElement_2 = enumerator_0.Current;
						ivisualElement_0 = ivisualElement_2;
						int_0 = 2;
						return true;
					}
					Class76.smethod_417(this);
					enumerator_0 = default(List<IVisualElement>.Enumerator);
					return false;
				}
			}
			catch
			{
				//try-fault
				((IDisposable)this).Dispose();
				throw;
			}
		}

		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}

		IEnumerator<IVisualElement> IEnumerable<IVisualElement>.GetEnumerator()
		{
			Class73 result;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				result = new Class73(0)
				{
					multiImages_0 = multiImages_0
				};
			}
			else
			{
				int_0 = 0;
				result = this;
			}
			return result;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return ((IEnumerable<IVisualElement>)this).GetEnumerator();
		}
	}

	private VisualElementList mImages = new VisualElementList();

	public VisualElementList SubImages => mImages;

	public MultiImages()
	{
		base.ElementsDrawMode = ElementsDrawMode.Covering;
	}

	public MultiImages(MultiImages other)
		: base(other)
	{
		mImages = (VisualElementList)other.mImages.Clone();
	}

	[IteratorStateMachine(typeof(Class73))]
	protected override IEnumerable<IVisualElement> GetElements()
	{
		//yield-return decompiler failed: Method not found
		return new Class73(-2)
		{
			multiImages_0 = this
		};
	}

	private IEnumerable<IVisualElement> method_0()
	{
		return base.GetElements();
	}

	public override object Clone()
	{
		return new MultiImages(this);
	}
}
