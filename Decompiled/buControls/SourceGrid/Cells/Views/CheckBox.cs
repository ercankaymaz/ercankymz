using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DevAge.Drawing;
using DevAge.Drawing.VisualElements;
using SourceGrid.Cells.Models;
using ns27;

namespace SourceGrid.Cells.Views;

[Serializable]
public class CheckBox : Cell
{
	[CompilerGenerated]
	internal sealed class Class70 : IDisposable, IEnumerable, IEnumerator, IEnumerable<IVisualElement>, IEnumerator<IVisualElement>
	{
		internal int int_0;

		private IVisualElement ivisualElement_0;

		private int int_1;

		public CheckBox checkBox_0;

		internal IEnumerator<IVisualElement> ienumerator_0;

		private IVisualElement ivisualElement_1;

		IVisualElement IEnumerator<IVisualElement>.Current => ivisualElement_0;

		object IEnumerator.Current => ivisualElement_0;

		public Class70(int int_2)
		{
			int_0 = int_2;
			int_1 = Environment.CurrentManagedThreadId;
		}

		void IDisposable.Dispose()
		{
			int num = int_0;
			if (num == -3 || num == 2)
			{
				try
				{
				}
				finally
				{
					Class76.smethod_692(this);
				}
			}
			ienumerator_0 = null;
			ivisualElement_1 = null;
			int_0 = -2;
		}

		bool IEnumerator.MoveNext()
		{
			try
			{
				switch (int_0)
				{
				case 2:
					int_0 = -3;
					ivisualElement_1 = null;
					goto IL_002a;
				default:
					return false;
				case 0:
					int_0 = -1;
					if (checkBox_0.ElementCheckBox != null)
					{
						ivisualElement_0 = checkBox_0.ElementCheckBox;
						int_0 = 1;
						return true;
					}
					goto IL_007d;
				case 1:
					{
						int_0 = -1;
						goto IL_007d;
					}
					IL_007d:
					ienumerator_0 = checkBox_0.method_0().GetEnumerator();
					int_0 = -3;
					goto IL_002a;
					IL_002a:
					if (ienumerator_0.MoveNext())
					{
						ivisualElement_1 = ienumerator_0.Current;
						ivisualElement_0 = ivisualElement_1;
						int_0 = 2;
						return true;
					}
					Class76.smethod_692(this);
					ienumerator_0 = null;
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
			Class70 result;
			if (int_0 != -2 || int_1 != Environment.CurrentManagedThreadId)
			{
				result = new Class70(0)
				{
					checkBox_0 = checkBox_0
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

	public new static readonly CheckBox Default;

	public static readonly CheckBox MiddleLeftAlign;

	private ContentAlignment m_CheckBoxAlignment = ContentAlignment.MiddleCenter;

	private DevAge.Drawing.VisualElements.ICheckBox mElementCheckBox = new CheckBoxThemed();

	public ContentAlignment CheckBoxAlignment
	{
		get
		{
			return m_CheckBoxAlignment;
		}
		set
		{
			m_CheckBoxAlignment = value;
		}
	}

	public DevAge.Drawing.VisualElements.ICheckBox ElementCheckBox
	{
		get
		{
			return mElementCheckBox;
		}
		set
		{
			mElementCheckBox = value;
		}
	}

	static CheckBox()
	{
		Default = new CheckBox();
		MiddleLeftAlign = new CheckBox();
		MiddleLeftAlign.CheckBoxAlignment = ContentAlignment.MiddleLeft;
		MiddleLeftAlign.TextAlignment = ContentAlignment.MiddleLeft;
	}

	public CheckBox()
	{
	}

	public CheckBox(CheckBox p_Source)
		: base(p_Source)
	{
		m_CheckBoxAlignment = p_Source.m_CheckBoxAlignment;
		ElementCheckBox = (DevAge.Drawing.VisualElements.ICheckBox)ElementCheckBox.Clone();
	}

	protected override void PrepareView(CellContext context)
	{
		base.PrepareView(context);
		PrepareVisualElementCheckBox(context);
	}

	[IteratorStateMachine(typeof(Class70))]
	protected override IEnumerable<IVisualElement> GetElements()
	{
		//yield-return decompiler failed: Method not found
		return new Class70(-2)
		{
			checkBox_0 = this
		};
	}

	private IEnumerable<IVisualElement> method_0()
	{
		return base.GetElements();
	}

	protected virtual void PrepareVisualElementCheckBox(CellContext context)
	{
		ElementCheckBox.AnchorArea = new AnchorArea(CheckBoxAlignment, stretch: false);
		SourceGrid.Cells.Models.ICheckBox checkBox = (SourceGrid.Cells.Models.ICheckBox)context.Cell.Model.FindModel(typeof(SourceGrid.Cells.Models.ICheckBox));
		CheckBoxStatus checkBoxStatus = checkBox.GetCheckBoxStatus(context);
		if (!context.CellRange.Contains(context.Grid.MouseCellPosition))
		{
			if (!checkBoxStatus.CheckEnable)
			{
				ElementCheckBox.Style = ControlDrawStyle.Disabled;
			}
			else
			{
				ElementCheckBox.Style = ControlDrawStyle.Normal;
			}
		}
		else if (!checkBoxStatus.CheckEnable)
		{
			ElementCheckBox.Style = ControlDrawStyle.Disabled;
		}
		else
		{
			ElementCheckBox.Style = ControlDrawStyle.Hot;
		}
		ElementCheckBox.CheckBoxState = checkBoxStatus.CheckState;
		base.ElementText.Value = checkBoxStatus.Caption;
	}

	public override object Clone()
	{
		return new CheckBox(this);
	}
}
