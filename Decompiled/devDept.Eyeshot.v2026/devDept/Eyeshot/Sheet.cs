using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Threading;
using devDept.Eyeshot.Entities;
using devDept.Geometry;
using devDept.Serialization;

namespace devDept.Eyeshot;

[Serializable]
public class Sheet : ISerializable, IKeyedCollectionDisposableItem<Sheet>, IKeyedCollectionItem<Sheet>, INotifyKeyChanged, ICloneable, IEquatable<Sheet>, IDisposable
{
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private static readonly double _0023_003DzU2W8bydRbE78 = 1.0;

	internal Point3D BorderInsertionPoint;

	internal double BorderSeparatorsTolerance;

	internal double UnitsConversionFactor;

	private linearUnitsType _units;

	private string _name;

	[NonSerialized]
	[DebuggerBrowsable(DebuggerBrowsableState.Never)]
	private KeyChangedEventHandler _0023_003Dzs0Yhv2U_003D;

	public double Width { get; set; }

	public double Height { get; set; }

	public linearUnitsType Units
	{
		get
		{
			return _units;
		}
		set
		{
			_units = value;
			UnitsConversionFactor = Utility.GetLinearUnitsConversionFactor(linearUnitsType.Millimeters, _units);
			BorderSeparatorsTolerance = _0023_003DzU2W8bydRbE78 * UnitsConversionFactor;
			BorderInsertionPoint = _0023_003DzofVDrs180O5K_0024NScgQ_003D_003D() * UnitsConversionFactor;
		}
	}

	public string Name
	{
		get
		{
			return _name;
		}
		set
		{
			if (!string.Equals(_name, value, StringComparison.OrdinalIgnoreCase))
			{
				OnKeyChanged(value, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
				_name = value;
			}
		}
	}

	public angleProjectionType AngleProjectionMode { get; set; }

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public List<Entity> Entities { get; set; } = new List<Entity>();

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public Camera Camera { get; set; }

	public event KeyChangedEventHandler KeyChanged
	{
		[CompilerGenerated]
		add
		{
			KeyChangedEventHandler keyChangedEventHandler = _0023_003Dzs0Yhv2U_003D;
			KeyChangedEventHandler keyChangedEventHandler2;
			do
			{
				keyChangedEventHandler2 = keyChangedEventHandler;
				KeyChangedEventHandler value2 = (KeyChangedEventHandler)Delegate.Combine(keyChangedEventHandler2, value);
				keyChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dzs0Yhv2U_003D, value2, keyChangedEventHandler2);
			}
			while ((object)keyChangedEventHandler != keyChangedEventHandler2);
		}
		[CompilerGenerated]
		remove
		{
			KeyChangedEventHandler keyChangedEventHandler = _0023_003Dzs0Yhv2U_003D;
			KeyChangedEventHandler keyChangedEventHandler2;
			do
			{
				keyChangedEventHandler2 = keyChangedEventHandler;
				KeyChangedEventHandler value2 = (KeyChangedEventHandler)Delegate.Remove(keyChangedEventHandler2, value);
				keyChangedEventHandler = Interlocked.CompareExchange(ref _0023_003Dzs0Yhv2U_003D, value2, keyChangedEventHandler2);
			}
			while ((object)keyChangedEventHandler != keyChangedEventHandler2);
		}
	}

	public Sheet(linearUnitsType units, double width, double height, string name, angleProjectionType angleProjectionMode)
	{
		Units = units;
		Width = width;
		Height = height;
		Name = name;
		AngleProjectionMode = angleProjectionMode;
	}

	protected Sheet(Sheet another, bool keepTessellation = false)
	{
		_units = another.Units;
		UnitsConversionFactor = another.UnitsConversionFactor;
		BorderSeparatorsTolerance = another.BorderSeparatorsTolerance;
		BorderInsertionPoint = another.BorderInsertionPoint;
		Width = another.Width;
		Height = another.Height;
		Name = another.Name;
		AngleProjectionMode = another.AngleProjectionMode;
		if (another.Camera != null)
		{
			Camera = (Camera)another.Camera.Clone();
		}
		foreach (Entity entity in another.Entities)
		{
			Entity item = (Entity)(keepTessellation ? entity.CloneWithTessellation() : entity.Clone());
			Entities.Add(item);
		}
	}

	protected internal Sheet(SheetSurrogate surrogate)
		: this((linearUnitsType)surrogate.Units, surrogate.Width, surrogate.Height, surrogate.Name, (angleProjectionType)surrogate.AngleProjectionMode)
	{
	}

	protected Sheet(SerializationInfo info, StreamingContext context)
	{
		_units = (linearUnitsType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951311), typeof(linearUnitsType));
		Width = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974266));
		Height = info.GetDouble(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246));
		Name = info.GetString(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333));
		AngleProjectionMode = (angleProjectionType)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997235), typeof(angleProjectionType));
		Camera = (Camera)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982685), typeof(Camera));
		Entities = (List<Entity>)info.GetValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951314), typeof(List<Entity>));
	}

	private static Point3D _0023_003DzofVDrs180O5K_0024NScgQ_003D_003D()
	{
		return new Point3D(20.0, 10.0);
	}

	private Color _0023_003Dz_zEf3ygT0enU(Color? _0023_003Dz1MMYB1g_003D)
	{
		if (_0023_003Dz1MMYB1g_003D.HasValue && !_0023_003Dz1MMYB1g_003D.Value.IsEmpty)
		{
			return _0023_003Dz1MMYB1g_003D.Value;
		}
		return Color.Black;
	}

	private Line _0023_003Dz6HDrHeDG1gYi(double _0023_003Dz3YfTAqg_003D, double _0023_003DzpilgH4E_003D, double _0023_003DzRFb1SGo_003D, double _0023_003Dz8qV981c_003D, Color _0023_003Dz1MMYB1g_003D, float _0023_003DzxOQTW6c4mcu_0024)
	{
		return new Line(_0023_003Dz3YfTAqg_003D, _0023_003DzpilgH4E_003D, _0023_003DzRFb1SGo_003D, _0023_003Dz8qV981c_003D)
		{
			ColorMethod = colorMethodType.byEntity,
			Color = _0023_003Dz1MMYB1g_003D,
			LineWeightMethod = colorMethodType.byEntity,
			LineWeight = _0023_003DzxOQTW6c4mcu_0024
		};
	}

	private Text _0023_003Dz6rEMlFkSSaDG(double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, string _0023_003DzwyYng5o_003D, double _0023_003DzvAxV_0024Ic_003D, Color _0023_003Dz1MMYB1g_003D, float _0023_003DzxOQTW6c4mcu_0024, Text.alignmentType _0023_003DzaS2Tx0o_003D)
	{
		return new Text(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D, 0.0, _0023_003DzwyYng5o_003D, _0023_003DzvAxV_0024Ic_003D, _0023_003DzaS2Tx0o_003D)
		{
			ColorMethod = colorMethodType.byEntity,
			Color = _0023_003Dz1MMYB1g_003D,
			LineWeightMethod = colorMethodType.byEntity,
			LineWeight = _0023_003DzxOQTW6c4mcu_0024,
			Simplify = false
		};
	}

	private Entity[] _0023_003Dzy1JUlvb8GCPy(double _0023_003Dz6tVBpdk_003D, double _0023_003DzvAxV_0024Ic_003D, int _0023_003DzO_0024xvpvo_003D, int _0023_003DzRwzUIoU_003D, bool _0023_003DzGjoNbXc_003D, Color _0023_003Dz1MMYB1g_003D, float _0023_003DzxOQTW6c4mcu_0024, double _0023_003Dzx0bH0r8MZhkE, double _0023_003Dz3vTOKyHgVm2c, bool _0023_003Dz9RHGxtNLkGEi, bool _0023_003DzaSrqFPVMdclt)
	{
		Color _0023_003Dz1MMYB1g_003D2 = _0023_003Dz_zEf3ygT0enU(_0023_003Dz1MMYB1g_003D);
		List<Entity> list = new List<Entity>();
		double num = _0023_003Dz6tVBpdk_003D / (double)_0023_003DzRwzUIoU_003D;
		double num2 = _0023_003DzvAxV_0024Ic_003D / (double)_0023_003DzO_0024xvpvo_003D;
		int _0023_003DzkXQ_IWk_003D = 1;
		char _0023_003DzWb35vecoKe_0024L = 'A';
		if (_0023_003DzGjoNbXc_003D)
		{
			if (_0023_003DzaSrqFPVMdclt)
			{
				for (double num3 = num / 2.0; num3 < _0023_003Dz6tVBpdk_003D; num3 += num)
				{
					string _0023_003DzWM78eKc_003D = _0023_003DzqM3RVDs_jE_D(_0023_003Dz9RHGxtNLkGEi, ref _0023_003DzkXQ_IWk_003D, ref _0023_003DzWb35vecoKe_0024L);
					list.AddRange(_0023_003DzeHvjyyVGmKib(_0023_003DzWM78eKc_003D, num3, _0023_003DzvAxV_0024Ic_003D, _0023_003Dz1MMYB1g_003D2, _0023_003DzxOQTW6c4mcu_0024, _0023_003Dzx0bH0r8MZhkE, _0023_003Dz3vTOKyHgVm2c));
				}
			}
			else
			{
				for (double num4 = _0023_003Dz6tVBpdk_003D - num / 2.0; num4 > 0.0; num4 -= num)
				{
					string _0023_003DzWM78eKc_003D2 = _0023_003DzqM3RVDs_jE_D(_0023_003Dz9RHGxtNLkGEi, ref _0023_003DzkXQ_IWk_003D, ref _0023_003DzWb35vecoKe_0024L);
					list.AddRange(_0023_003DzeHvjyyVGmKib(_0023_003DzWM78eKc_003D2, num4, _0023_003DzvAxV_0024Ic_003D, _0023_003Dz1MMYB1g_003D2, _0023_003DzxOQTW6c4mcu_0024, _0023_003Dzx0bH0r8MZhkE, _0023_003Dz3vTOKyHgVm2c));
				}
			}
		}
		else if (_0023_003DzaSrqFPVMdclt)
		{
			for (double num5 = _0023_003DzvAxV_0024Ic_003D - num2 / 2.0; num5 > 0.0; num5 -= num2)
			{
				string _0023_003DzWM78eKc_003D3 = _0023_003DzqM3RVDs_jE_D(_0023_003Dz9RHGxtNLkGEi, ref _0023_003DzkXQ_IWk_003D, ref _0023_003DzWb35vecoKe_0024L);
				list.AddRange(_0023_003DzbDCO35MNWH7U(_0023_003DzWM78eKc_003D3, _0023_003Dz6tVBpdk_003D, num5, _0023_003Dz1MMYB1g_003D2, _0023_003DzxOQTW6c4mcu_0024, _0023_003Dzx0bH0r8MZhkE, _0023_003Dz3vTOKyHgVm2c));
			}
		}
		else
		{
			for (double num6 = num2 / 2.0; num6 < _0023_003DzvAxV_0024Ic_003D; num6 += num2)
			{
				string _0023_003DzWM78eKc_003D4 = _0023_003DzqM3RVDs_jE_D(_0023_003Dz9RHGxtNLkGEi, ref _0023_003DzkXQ_IWk_003D, ref _0023_003DzWb35vecoKe_0024L);
				list.AddRange(_0023_003DzbDCO35MNWH7U(_0023_003DzWM78eKc_003D4, _0023_003Dz6tVBpdk_003D, num6, _0023_003Dz1MMYB1g_003D2, _0023_003DzxOQTW6c4mcu_0024, _0023_003Dzx0bH0r8MZhkE, _0023_003Dz3vTOKyHgVm2c));
			}
		}
		return list.ToArray();
	}

	private string _0023_003DzqM3RVDs_jE_D(bool _0023_003Dz9RHGxtNLkGEi, ref int _0023_003DzkXQ_IWk_003D, ref char _0023_003DzWb35vecoKe_0024L)
	{
		string text = null;
		if (_0023_003Dz9RHGxtNLkGEi)
		{
			text = _0023_003DzkXQ_IWk_003D.ToString();
			_0023_003DzkXQ_IWk_003D++;
		}
		else
		{
			text = _0023_003DzWb35vecoKe_0024L.ToString();
			_0023_003DzWb35vecoKe_0024L += '\u0001';
			if (_0023_003DzWb35vecoKe_0024L == 'I' || _0023_003DzWb35vecoKe_0024L == 'O')
			{
				_0023_003DzWb35vecoKe_0024L += '\u0001';
			}
		}
		return text;
	}

	private IList<Entity> _0023_003DzeHvjyyVGmKib(string _0023_003DzWM78eKc_003D, double _0023_003DzBJFJHwk_003D, double _0023_003Dz40R7bAU_003D, Color _0023_003Dz1MMYB1g_003D, float _0023_003DzxOQTW6c4mcu_0024, double _0023_003Dzx0bH0r8MZhkE, double _0023_003Dz3vTOKyHgVm2c)
	{
		List<Entity> list = new List<Entity>();
		Text item = _0023_003Dz6rEMlFkSSaDG(_0023_003DzBJFJHwk_003D, (0.0 - _0023_003Dz3vTOKyHgVm2c) / 2.0, _0023_003DzWM78eKc_003D, _0023_003Dzx0bH0r8MZhkE, _0023_003Dz1MMYB1g_003D, _0023_003DzxOQTW6c4mcu_0024, Text.alignmentType.MiddleCenter);
		list.Add(item);
		Text item2 = _0023_003Dz6rEMlFkSSaDG(_0023_003DzBJFJHwk_003D, _0023_003Dz40R7bAU_003D + _0023_003Dz3vTOKyHgVm2c / 2.0, _0023_003DzWM78eKc_003D, _0023_003Dzx0bH0r8MZhkE, _0023_003Dz1MMYB1g_003D, _0023_003DzxOQTW6c4mcu_0024, Text.alignmentType.MiddleCenter);
		list.Add(item2);
		return list;
	}

	private IList<Entity> _0023_003DzbDCO35MNWH7U(string _0023_003DzWM78eKc_003D, double _0023_003Dz6tVBpdk_003D, double _0023_003Dz40R7bAU_003D, Color _0023_003Dz1MMYB1g_003D, float _0023_003DzxOQTW6c4mcu_0024, double _0023_003Dzx0bH0r8MZhkE, double _0023_003Dz3vTOKyHgVm2c)
	{
		List<Entity> list = new List<Entity>();
		Text item = _0023_003Dz6rEMlFkSSaDG((0.0 - _0023_003Dz3vTOKyHgVm2c) / 2.0, _0023_003Dz40R7bAU_003D, _0023_003DzWM78eKc_003D, _0023_003Dzx0bH0r8MZhkE, _0023_003Dz1MMYB1g_003D, _0023_003DzxOQTW6c4mcu_0024, Text.alignmentType.MiddleCenter);
		list.Add(item);
		Text item2 = _0023_003Dz6rEMlFkSSaDG(_0023_003Dz6tVBpdk_003D + _0023_003Dz3vTOKyHgVm2c / 2.0, _0023_003Dz40R7bAU_003D, _0023_003DzWM78eKc_003D, _0023_003Dzx0bH0r8MZhkE, _0023_003Dz1MMYB1g_003D, _0023_003DzxOQTW6c4mcu_0024, Text.alignmentType.MiddleCenter);
		list.Add(item2);
		return list;
	}

	protected virtual Entity[] CreateBorder(double width, double height, int rows, int columns, Color? color = null, float lineWeight = 0.5f, double textHeight = 3.0, double externalBorderGap = 5.0, bool createExternalBorder = true, float externalBorderLineWeight = 0.15f)
	{
		List<Entity> list = new List<Entity>();
		double num = width * UnitsConversionFactor;
		double num2 = height * UnitsConversionFactor;
		double num3 = externalBorderGap * UnitsConversionFactor;
		double textHeight2 = textHeight * UnitsConversionFactor;
		Color color2 = _0023_003Dz_zEf3ygT0enU(color);
		if (createExternalBorder)
		{
			Line item = _0023_003Dz6HDrHeDG1gYi(0.0 - num3, 0.0 - num3, num + num3, 0.0 - num3, color2, externalBorderLineWeight);
			Line item2 = _0023_003Dz6HDrHeDG1gYi(num + num3, 0.0 - num3, num + num3, num2 + num3, color2, externalBorderLineWeight);
			Line item3 = _0023_003Dz6HDrHeDG1gYi(num + num3, num2 + num3, 0.0 - num3, num2 + num3, color2, externalBorderLineWeight);
			Line item4 = _0023_003Dz6HDrHeDG1gYi(0.0 - num3, num2 + num3, 0.0 - num3, 0.0 - num3, color2, externalBorderLineWeight);
			list.AddRange(new List<Entity> { item, item2, item3, item4 });
		}
		Line item5 = _0023_003Dz6HDrHeDG1gYi(0.0, 0.0, num, 0.0, color2, lineWeight);
		Line item6 = _0023_003Dz6HDrHeDG1gYi(num, 0.0, num, num2, color2, lineWeight);
		Line item7 = _0023_003Dz6HDrHeDG1gYi(num, num2, 0.0, num2, color2, lineWeight);
		Line item8 = _0023_003Dz6HDrHeDG1gYi(0.0, num2, 0.0, 0.0, color2, lineWeight);
		list.AddRange(new List<Entity> { item5, item6, item7, item8 });
		list.AddRange(CreateBorderSeparators(num, num2, rows, columns, color2, externalBorderLineWeight, num3));
		list.AddRange(CreateBorderHorizontalTexts(num, num2, rows, columns, color2, externalBorderLineWeight, textHeight2, num3));
		list.AddRange(CreateBorderVerticalTexts(num, num2, rows, columns, color2, externalBorderLineWeight, textHeight2, num3, useNumbers: false));
		return list.ToArray();
	}

	protected virtual Entity[] CreateBorderSeparators(double width, double height, int rows, int columns, Color? color = null, float lineWeight = 0.15f, double externalBorderGap = 5.0)
	{
		List<Entity> list = new List<Entity>();
		Color _0023_003Dz1MMYB1g_003D = _0023_003Dz_zEf3ygT0enU(color);
		double num = width / (double)columns;
		double num2 = height / (double)rows;
		_0023_003Dz6HDrHeDG1gYi(width / 2.0, 0.0 - externalBorderGap, width / 2.0, externalBorderGap, _0023_003Dz1MMYB1g_003D, lineWeight);
		Line item = _0023_003Dz6HDrHeDG1gYi(width + externalBorderGap, height / 2.0, width - externalBorderGap, height / 2.0, _0023_003Dz1MMYB1g_003D, lineWeight);
		Line item2 = _0023_003Dz6HDrHeDG1gYi(width / 2.0, height + externalBorderGap, width / 2.0, height - externalBorderGap, _0023_003Dz1MMYB1g_003D, lineWeight);
		Line item3 = _0023_003Dz6HDrHeDG1gYi(0.0 - externalBorderGap, height / 2.0, externalBorderGap, height / 2.0, _0023_003Dz1MMYB1g_003D, lineWeight);
		List<Line> list2 = new List<Line>();
		for (double num3 = width / 2.0 + num; num3 < width - BorderSeparatorsTolerance; num3 += num)
		{
			Line item4 = _0023_003Dz6HDrHeDG1gYi(num3, 0.0 - externalBorderGap, num3, 0.0, _0023_003Dz1MMYB1g_003D, lineWeight);
			list2.Add(item4);
			Line item5 = _0023_003Dz6HDrHeDG1gYi(num3, height + externalBorderGap, num3, height, _0023_003Dz1MMYB1g_003D, lineWeight);
			list2.Add(item5);
		}
		for (double num4 = width / 2.0 - num; num4 > BorderSeparatorsTolerance; num4 -= num)
		{
			Line item6 = _0023_003Dz6HDrHeDG1gYi(num4, 0.0 - externalBorderGap, num4, 0.0, _0023_003Dz1MMYB1g_003D, lineWeight);
			list2.Add(item6);
			Line item7 = _0023_003Dz6HDrHeDG1gYi(num4, height + externalBorderGap, num4, height, _0023_003Dz1MMYB1g_003D, lineWeight);
			list2.Add(item7);
		}
		for (double num5 = height / 2.0 + num2; num5 < height - BorderSeparatorsTolerance; num5 += num2)
		{
			Line item8 = _0023_003Dz6HDrHeDG1gYi(width + externalBorderGap, num5, width, num5, _0023_003Dz1MMYB1g_003D, lineWeight);
			list2.Add(item8);
			Line item9 = _0023_003Dz6HDrHeDG1gYi(0.0 - externalBorderGap, num5, 0.0, num5, _0023_003Dz1MMYB1g_003D, lineWeight);
			list2.Add(item9);
		}
		for (double num6 = height / 2.0 - num2; num6 > BorderSeparatorsTolerance; num6 -= num2)
		{
			Line item10 = _0023_003Dz6HDrHeDG1gYi(width + externalBorderGap, num6, width, num6, _0023_003Dz1MMYB1g_003D, lineWeight);
			list2.Add(item10);
			Line item11 = _0023_003Dz6HDrHeDG1gYi(0.0 - externalBorderGap, num6, 0.0, num6, _0023_003Dz1MMYB1g_003D, lineWeight);
			list2.Add(item11);
		}
		list.AddRange(new List<Entity> { item, item2, item3 });
		list.AddRange(list2);
		return list.ToArray();
	}

	protected virtual Entity[] CreateBorderHorizontalTexts(double width, double height, int rows, int columns, Color? color = null, float lineWeight = 0.15f, double textHeight = 3.0, double externalBorderGap = 5.0, bool useNumbers = true, bool reverseOrder = false)
	{
		Color _0023_003Dz1MMYB1g_003D = _0023_003Dz_zEf3ygT0enU(color);
		return _0023_003Dzy1JUlvb8GCPy(width, height, rows, columns, _0023_003DzGjoNbXc_003D: true, _0023_003Dz1MMYB1g_003D, lineWeight, textHeight, externalBorderGap, useNumbers, reverseOrder);
	}

	protected virtual Entity[] CreateBorderVerticalTexts(double width, double height, int rows, int columns, Color? color = null, float lineWeight = 0.15f, double textHeight = 3.0, double externalBorderGap = 5.0, bool useNumbers = true, bool reverseOrder = false)
	{
		Color _0023_003Dz1MMYB1g_003D = _0023_003Dz_zEf3ygT0enU(color);
		return _0023_003Dzy1JUlvb8GCPy(width, height, rows, columns, _0023_003DzGjoNbXc_003D: false, _0023_003Dz1MMYB1g_003D, lineWeight, textHeight, externalBorderGap, useNumbers, reverseOrder);
	}

	protected virtual Entity[] CreateTitleBlock(double borderWidth, Color color, float lineWeight = 0.15f)
	{
		List<Entity> list = new List<Entity>();
		Color color2 = _0023_003Dz_zEf3ygT0enU(color);
		double num = borderWidth * UnitsConversionFactor;
		double[] array = new double[11]
		{
			6.38, 10.63, 4.25, 4.25, 4.25, 4.25, 4.25, 4.25, 4.25, 4.25,
			4.25
		};
		double[] array2 = new double[12]
		{
			7.8, 19.19, 6.81, 10.6, 10.2, 10.4, 15.6, 18.2, 44.2, 7.8,
			16.2, 13.0
		};
		for (int i = 0; i < array.Length; i++)
		{
			array[i] *= UnitsConversionFactor;
		}
		for (int j = 0; j < array2.Length; j++)
		{
			array2[j] *= UnitsConversionFactor;
		}
		double num2 = 1.3 * UnitsConversionFactor;
		double height = 3.0 * UnitsConversionFactor;
		Table table = new Table(Plane.XY, 11, 12, array, array2, num2);
		table.HorCellMargin = 0.9 * UnitsConversionFactor;
		table.VerCellMargin = 0.9 * UnitsConversionFactor;
		double num3 = 0.0;
		for (int k = 0; k < array.Length; k++)
		{
			num3 += array[k];
		}
		table.Translate(num - 180.0 * UnitsConversionFactor, num3);
		table.MergeCells(0, 0, 1, 2);
		table.MergeCells(0, 3, 1, 6);
		table.MergeCells(0, 7, 1, 7);
		table.MergeCells(0, 8, 0, 9);
		table.MergeCells(0, 10, 0, 11);
		table.MergeCells(1, 8, 1, 11);
		table.MergeCells(2, 2, 2, 3);
		table.MergeCells(2, 8, 6, 11);
		table.MergeCells(3, 2, 3, 3);
		table.MergeCells(4, 2, 4, 3);
		table.MergeCells(5, 2, 5, 3);
		table.MergeCells(6, 2, 6, 3);
		table.MergeCells(6, 5, 6, 6);
		table.MergeCells(7, 0, 10, 4);
		table.MergeCells(7, 2, 7, 3);
		table.MergeCells(7, 5, 9, 7);
		table.MergeCells(7, 8, 9, 10);
		table.MergeCells(7, 11, 8, 11);
		table.MergeCells(8, 2, 8, 3);
		table.MergeCells(9, 2, 9, 3);
		table.MergeCells(10, 2, 10, 3);
		table.MergeCells(10, 5, 10, 7);
		table.MergeCells(10, 9, 10, 11);
		Table.Cell cell = table.cells[0, 0];
		cell.Alignment = Text.alignmentType.TopLeft;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997229) + Environment.NewLine + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997199) + Units.GetDisplayName().ToUpper() + Environment.NewLine + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997162) + Environment.NewLine + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997152) + Environment.NewLine + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997874) + Environment.NewLine + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997858);
		cell = table.cells[0, 3];
		cell.Alignment = Text.alignmentType.TopLeft;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997841);
		cell = table.cells[0, 7];
		cell.Alignment = Text.alignmentType.TopLeft;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997855);
		cell = table.cells[0, 8];
		cell.Alignment = Text.alignmentType.MiddleCenter;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997793);
		cell = table.cells[0, 10];
		cell.Alignment = Text.alignmentType.MiddleCenter;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997790);
		cell = table.cells[2, 1];
		cell.Alignment = Text.alignmentType.BottomCenter;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997771);
		cell = table.cells[2, 2];
		cell.Alignment = Text.alignmentType.BottomCenter;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302998008);
		cell = table.cells[2, 4];
		cell.Alignment = Text.alignmentType.BottomCenter;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997992);
		cell = table.cells[2, 8];
		cell.Alignment = Text.alignmentType.TopLeft;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997969);
		list.Add(new devDept.Eyeshot.Entities.Attribute(cell._0023_003DzE4mfvVc_003D(), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997984), string.Empty, height)
		{
			Alignment = Text.alignmentType.MiddleCenter,
			LineWeightMethod = colorMethodType.byEntity,
			LineWeight = lineWeight
		});
		cell = table.cells[3, 0];
		cell.Alignment = Text.alignmentType.MiddleCenter;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997964);
		cell = table.cells[4, 0];
		cell.Alignment = Text.alignmentType.MiddleCenter;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997944);
		cell = table.cells[5, 0];
		cell.Alignment = Text.alignmentType.MiddleCenter;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997924);
		cell = table.cells[6, 0];
		cell.Alignment = Text.alignmentType.MiddleCenter;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997935);
		cell = table.cells[7, 0];
		Entity[] logo = GetLogo();
		if (logo != null)
		{
			Entity[] array3 = logo;
			foreach (Entity entity in array3)
			{
				entity.Scale(0.05 * UnitsConversionFactor);
				entity.Translate(cell._0023_003DzE4mfvVc_003D().X - 20.0 * UnitsConversionFactor, cell._0023_003DzE4mfvVc_003D().Y + 15.0 * UnitsConversionFactor);
			}
			list.AddRange(logo);
		}
		cell = table.cells[7, 5];
		cell.Alignment = Text.alignmentType.TopLeft;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997913);
		cell = table.cells[7, 8];
		cell.Alignment = Text.alignmentType.TopLeft;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997897);
		list.Add(new devDept.Eyeshot.Entities.Attribute(cell._0023_003DzE4mfvVc_003D(), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997623), string.Empty, height)
		{
			Alignment = Text.alignmentType.MiddleCenter,
			LineWeightMethod = colorMethodType.byEntity,
			LineWeight = lineWeight
		});
		cell = table.cells[7, 11];
		list.Add(new devDept.Eyeshot.Entities.Attribute(cell._0023_003DzE4mfvVc_003D(), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997603), string.Empty, height)
		{
			Alignment = Text.alignmentType.MiddleCenter,
			LineWeightMethod = colorMethodType.byEntity,
			LineWeight = lineWeight
		});
		cell = table.cells[10, 5];
		cell.Alignment = Text.alignmentType.MiddleLeft;
		cell.TextString = _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997586);
		cell = table.cells[10, 8];
		cell.Alignment = Text.alignmentType.MiddleLeft;
		list.Add(new devDept.Eyeshot.Entities.Attribute(cell.InsertionPoint + cell.Plane.AxisX * table.HorCellMargin, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302956350), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997600), num2)
		{
			Alignment = Text.alignmentType.MiddleLeft,
			LineWeightMethod = colorMethodType.byEntity,
			LineWeight = lineWeight
		});
		cell = table.cells[10, 9];
		cell.Alignment = Text.alignmentType.MiddleLeft;
		list.Add(new devDept.Eyeshot.Entities.Attribute(cell.InsertionPoint + cell.Plane.AxisX * table.HorCellMargin, _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997579), _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997559), num2)
		{
			Alignment = Text.alignmentType.MiddleLeft,
			LineWeightMethod = colorMethodType.byEntity,
			LineWeight = lineWeight
		});
		table.ColorMethod = colorMethodType.byEntity;
		table.Color = color2;
		table.LineWeightMethod = colorMethodType.byEntity;
		table.LineWeight = lineWeight;
		list.Add(table);
		return list.ToArray();
	}

	protected virtual Entity[] GetLogo()
	{
		_0023_003DzspExml1j72mr_FI04NKW780_003D _0023_003DzspExml1j72mr_FI04NKW780_003D2 = new _0023_003DzspExml1j72mr_FI04NKW780_003D();
		try
		{
			List<ICurve> contours = new List<ICurve>(Utility.GetLogo());
			Hatch hatch = new Hatch(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302970485), contours);
			return new Entity[1] { hatch };
		}
		finally
		{
			((IDisposable)_0023_003DzspExml1j72mr_FI04NKW780_003D2).Dispose();
		}
	}

	protected virtual void OnKeyChanged(string newKey, [CallerMemberName] string propertyName = null)
	{
		_0023_003Dzs0Yhv2U_003D?.Invoke(this, new KeyChangedEventArgs(propertyName, newKey));
	}

	public string GetKey()
	{
		return Name;
	}

	public void SetKey(string value)
	{
		Name = value;
	}

	public virtual BlockReference BuildBillOfMaterials(DesignDocument design, Point3D insertionPoint, string itemNumberText, string partNumberText, string descriptionText, string quantityText, out Block block, string blockName = null, bool partsOnly = false, Table.flowDirection flowDirection = Table.flowDirection.Down, int maxLevel = int.MaxValue)
	{
		string text = blockName ?? _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997548);
		block = new Block(text);
		block.Entities.Add(Utility.CreateBOMTable(design.Entities, design.Blocks, itemNumberText, partNumberText, descriptionText, quantityText, partsOnly, flowDirection, maxLevel));
		return new BlockReference(insertionPoint, text, 0.0);
	}

	internal IList<Entity> _0023_003DztHebQ5s_003D(double _0023_003Dz6tVBpdk_003D, double _0023_003DzvAxV_0024Ic_003D, int _0023_003DzO_0024xvpvo_003D, int _0023_003DzRwzUIoU_003D, Color? _0023_003Dz1MMYB1g_003D)
	{
		List<Entity> list = new List<Entity>();
		Color color = _0023_003Dz_zEf3ygT0enU(_0023_003Dz1MMYB1g_003D);
		list.AddRange(CreateBorder(_0023_003Dz6tVBpdk_003D, _0023_003DzvAxV_0024Ic_003D, _0023_003DzO_0024xvpvo_003D, _0023_003DzRwzUIoU_003D, _0023_003Dz1MMYB1g_003D));
		list.AddRange(CreateTitleBlock(_0023_003Dz6tVBpdk_003D, color));
		return list;
	}

	private string _0023_003DzAfiQe1xD7a07(string _0023_003Dz68mvTm0_003D, string _0023_003DznkMU43c_003D)
	{
		return _0023_003DznkMU43c_003D ?? (Name + _0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911382) + _0023_003Dz68mvTm0_003D);
	}

	public BlockReference BuildA0ISO(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(1159.0, 820.0, 16, 24, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997506), blockName), ents, out block);
	}

	public BlockReference BuildA1ISO(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(811.0, 574.0, 12, 16, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997513), blockName), ents, out block);
	}

	public BlockReference BuildA2ISO(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(564.0, 400.0, 8, 12, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997748), blockName), ents, out block);
	}

	public BlockReference BuildA3ISO(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(390.0, 277.0, 6, 8, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997755), blockName), ents, out block);
	}

	public BlockReference BuildA4ISO(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(180.0, 277.0, 6, 4, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997734), blockName), ents, out block);
	}

	public BlockReference BuildA4LANDSCAPEISO(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(267.0, 190.0, 4, 6, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997734), blockName), ents, out block);
	}

	public BlockReference BuildALANDSCAPEANSI(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(249.4, 195.9, 2, 2, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911390), blockName), ents, out block);
	}

	public BlockReference BuildAANSI(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(185.9, 259.4, 2, 2, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911390), blockName), ents, out block);
	}

	public BlockReference BuildBANSI(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(401.8, 259.4, 2, 4, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911084), blockName), ents, out block);
	}

	public BlockReference BuildCANSI(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(528.8, 411.8, 4, 4, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911147), blockName), ents, out block);
	}

	public BlockReference BuildDANSI(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(833.6, 538.8, 4, 8, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302912811), blockName), ents, out block);
	}

	public BlockReference BuildEANSI(out Block block, string blockName = null, Color? color = null)
	{
		IList<Entity> ents = _0023_003DztHebQ5s_003D(1087.6, 843.6, 8, 8, color);
		return BuildFormatBlock(_0023_003DzAfiQe1xD7a07(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302911012), blockName), ents, out block);
	}

	protected BlockReference BuildFormatBlock(string blockName, IList<Entity> ents, out Block block)
	{
		block = new Block(blockName);
		block.Entities.AddRange(ents);
		return new BlockReference(BorderInsertionPoint, blockName, 0.0);
	}

	public bool HasChanged(BlockKeyedCollection blocks = null)
	{
		foreach (Entity entity in Entities)
		{
			if (entity is View { HasChanged: not false })
			{
				return true;
			}
			if (blocks != null && entity is BlockReference blockReference && !blocks.Contains(blockReference.BlockName))
			{
				return true;
			}
		}
		return false;
	}

	public virtual void Dispose()
	{
		foreach (Entity entity in Entities)
		{
			entity.Dispose();
		}
		Entities.Clear();
	}

	public virtual object Clone()
	{
		return new Sheet(this);
	}

	public virtual object CloneWithTessellation()
	{
		return new Sheet(this, keepTessellation: true);
	}

	public bool Equals(Sheet other)
	{
		return Name.Equals(other.Name, StringComparison.OrdinalIgnoreCase);
	}

	public virtual SheetSurrogate ConvertToSurrogate()
	{
		return new SheetSurrogate(this);
	}

	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951311), Units);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974266), Width);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302974246), Height);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951333), Name);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302997235), AngleProjectionMode);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302982685), Camera);
		info.AddValue(_0023_003DzUEQYRfd1JtmmO3VsmaV_0024uUiBTuoh._0023_003DzE8QrneA_003D(-302951314), Entities);
	}
}
