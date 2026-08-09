#define DEBUG
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewDrawDateTimeText : ViewLeaf
{
	private class FormatHandler
	{
		private bool _hasFocus;

		private bool _rightToLeftLayout;

		private int _activeFragment;

		private FormatFragmentList _fragments;

		private string _inputDigits;

		private DateTime _dt;

		private KryptonDateTimePicker _dateTimePicker;

		private NeedPaintHandler _needPaint;

		private ViewDrawDateTimeText _timeText;

		public bool HasFocus
		{
			get
			{
				return _hasFocus;
			}
			set
			{
				_hasFocus = value;
			}
		}

		public bool RightToLeftLayout
		{
			get
			{
				return _rightToLeftLayout;
			}
			set
			{
				_rightToLeftLayout = value;
			}
		}

		public bool HasActiveFragment => _activeFragment >= 0;

		public string ActiveFragment
		{
			get
			{
				if (!HasActiveFragment)
				{
					return string.Empty;
				}
				return _fragments[_activeFragment].FragFormat;
			}
			set
			{
				_activeFragment = -1;
				for (int i = 0; i < _fragments.Count; i++)
				{
					if (_fragments[i].AllowActive && _fragments[i].FragFormat.Equals(value))
					{
						_activeFragment = i;
						break;
					}
				}
			}
		}

		public DateTime DateTime
		{
			get
			{
				return _dt;
			}
			set
			{
				_dt = value;
			}
		}

		public bool IsInputDigits => _inputDigits != null;

		private bool ImplRightToLeft => RightToLeftLayout && _dateTimePicker.RightToLeft == RightToLeft.Yes;

		public FormatHandler(KryptonDateTimePicker dateTimePicker, ViewDrawDateTimeText timeText, NeedPaintHandler needPaint)
		{
			_dateTimePicker = dateTimePicker;
			_timeText = timeText;
			_needPaint = needPaint;
			_fragments = new FormatFragmentList();
			_activeFragment = -1;
			_inputDigits = null;
			_rightToLeftLayout = false;
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < _fragments.Count; i++)
			{
				stringBuilder.Append(_fragments[i].GetDisplay(_dt));
			}
			return stringBuilder.ToString();
		}

		public void ClearActiveFragment()
		{
			_activeFragment = -1;
		}

		public void MoveFirst()
		{
			if (ImplRightToLeft)
			{
				_activeFragment = -1;
				for (int i = 0; i < _fragments.Count; i++)
				{
					if (_fragments[i].AllowActive)
					{
						_activeFragment = i;
					}
				}
				return;
			}
			_activeFragment = -1;
			for (int j = 0; j < _fragments.Count; j++)
			{
				if (_fragments[j].AllowActive)
				{
					_activeFragment = j;
					break;
				}
			}
		}

		public void MoveLast()
		{
			if (ImplRightToLeft)
			{
				_activeFragment = -1;
				for (int i = 0; i < _fragments.Count; i++)
				{
					if (_fragments[i].AllowActive)
					{
						_activeFragment = i;
						break;
					}
				}
				return;
			}
			_activeFragment = -1;
			for (int j = 0; j < _fragments.Count; j++)
			{
				if (_fragments[j].AllowActive)
				{
					_activeFragment = j;
				}
			}
		}

		public void MoveLeft()
		{
			if (ImplRightToLeft)
			{
				for (int i = _activeFragment + 1; i < _fragments.Count; i++)
				{
					if (_fragments[i].AllowActive)
					{
						_activeFragment = i;
						return;
					}
				}
				_activeFragment = -1;
				return;
			}
			for (int num = _activeFragment - 1; num >= 0; num--)
			{
				if (_fragments[num].AllowActive)
				{
					_activeFragment = num;
					return;
				}
			}
			_activeFragment = -1;
		}

		public void MoveRight()
		{
			if (ImplRightToLeft)
			{
				for (int num = _activeFragment - 1; num >= 0; num--)
				{
					if (_fragments[num].AllowActive)
					{
						_activeFragment = num;
						return;
					}
				}
				_activeFragment = -1;
				return;
			}
			for (int i = _activeFragment + 1; i < _fragments.Count; i++)
			{
				if (_fragments[i].AllowActive)
				{
					_activeFragment = i;
					return;
				}
			}
			_activeFragment = -1;
		}

		public void MoveNext()
		{
			MoveRight();
			if (!HasActiveFragment)
			{
				MoveFirst();
			}
		}

		public void MovePrevious()
		{
			MoveLeft();
			if (!HasActiveFragment)
			{
				MoveLast();
			}
		}

		public void SelectFragment(Point pt)
		{
			if (ImplRightToLeft)
			{
				int num = 0;
				for (int num2 = _fragments.Count - 1; num2 >= 0; num2--)
				{
					num += ((num2 == 0) ? _fragments[num2].TotalWidth : (_fragments[num2].TotalWidth - _fragments[num2 - 1].TotalWidth));
					if (_fragments[num2].AllowActive && pt.X > _timeText.ClientRectangle.Right - num)
					{
						EndInputDigits();
						_activeFragment = num2;
						return;
					}
				}
				MoveLast();
				return;
			}
			pt.X -= _timeText.ClientLocation.X;
			for (int i = 0; i < _fragments.Count; i++)
			{
				if (_fragments[i].AllowActive && pt.X < _fragments[i].TotalWidth)
				{
					EndInputDigits();
					_activeFragment = i;
					return;
				}
			}
			MoveLast();
		}

		public DateTime Increment(bool forward)
		{
			if (_activeFragment >= 0)
			{
				return _fragments[_activeFragment].Increment(_dt, forward);
			}
			return _dt;
		}

		public DateTime AMPM(bool am)
		{
			if (_activeFragment >= 0)
			{
				return _fragments[_activeFragment].AMPM(_dt, am);
			}
			return _dt;
		}

		public void InputDigit(char digit)
		{
			if (_activeFragment == -1 || _fragments[_activeFragment].InputDigits == 0)
			{
				_inputDigits = null;
				return;
			}
			if (_inputDigits == null)
			{
				_inputDigits = "";
			}
			_inputDigits += digit;
			if (_fragments[_activeFragment].FragFormat.Contains("MMM"))
			{
				int num = int.Parse(_inputDigits);
				if (num > 12)
				{
					num -= 10;
				}
				else if (num == 0)
				{
					num = 10;
				}
				DateTime dt = _dt.AddMonths(num - _dt.Month);
				if (!dt.Equals(_dt))
				{
					_dateTimePicker.Value = _timeText.ValidateDate(dt);
					_needPaint(this, new NeedLayoutEventArgs(needLayout: true));
				}
				if (_inputDigits.Length <= 1 && (_inputDigits.Length != 1 || num <= 1 || num >= 10))
				{
					return;
				}
				if (_inputDigits.Length == 2 && _dateTimePicker.AutoShift)
				{
					MoveRight();
					if (!HasActiveFragment)
					{
						CancelEventArgs e = new CancelEventArgs();
						_timeText.OnAutoShiftOverflow(e);
						if (!e.Cancel)
						{
							if (_dateTimePicker.ShowCheckBox)
							{
								_dateTimePicker.InternalViewDrawCheckBox.ForcedTracking = true;
							}
							else
							{
								MoveFirst();
							}
						}
					}
				}
				_inputDigits = null;
			}
			else
			{
				if (_inputDigits.Length != _fragments[_activeFragment].InputDigits)
				{
					return;
				}
				DateTime dt2 = _fragments[_activeFragment].EndDigits(_dt, _inputDigits);
				if (!dt2.Equals(_dt))
				{
					_dateTimePicker.Value = _timeText.ValidateDate(dt2);
					_needPaint(this, new NeedLayoutEventArgs(needLayout: true));
				}
				_inputDigits = null;
				if (!_dateTimePicker.AutoShift)
				{
					return;
				}
				MoveRight();
				if (HasActiveFragment)
				{
					return;
				}
				CancelEventArgs e2 = new CancelEventArgs();
				_timeText.OnAutoShiftOverflow(e2);
				if (!e2.Cancel)
				{
					if (_dateTimePicker.ShowCheckBox)
					{
						_dateTimePicker.InternalViewDrawCheckBox.ForcedTracking = true;
					}
					else
					{
						MoveFirst();
					}
				}
			}
		}

		public void EndInputDigits()
		{
			if (_inputDigits != null && _activeFragment >= 0)
			{
				DateTime dt = _fragments[_activeFragment].EndDigits(_dt, _inputDigits);
				if (!dt.Equals(_dt))
				{
					_dateTimePicker.Value = _timeText.ValidateDate(dt);
					_needPaint(this, new NeedLayoutEventArgs(needLayout: true));
				}
				_inputDigits = null;
			}
		}

		public void ParseFormat(string format, Graphics g, Font font)
		{
			_fragments = ParseFormatToFragments(format);
			if (_fragments.Count > 0)
			{
				MeasureFragments(g, font, _dt);
			}
			ValidateActiveFragment();
		}

		public void Render(RenderContext context, Font font, Rectangle rect, Color textColor, Color backColor, bool enabled)
		{
			if (enabled || string.IsNullOrEmpty(_dateTimePicker.CustomNullText))
			{
				if (_fragments.Count <= 0)
				{
					return;
				}
				if (ImplRightToLeft)
				{
					int totalWidth = _fragments[_fragments.Count - 1].TotalWidth;
					rect.X = rect.Right - totalWidth - 1;
					rect.Width = totalWidth;
				}
				int num = 0;
				for (int i = 0; i < _fragments.Count; i++)
				{
					Color color = textColor;
					int num2 = _fragments[i].TotalWidth;
					if (num2 > rect.Width)
					{
						num2 = rect.Width;
					}
					Rectangle rectangle = new Rectangle(rect.X + num, rect.Y, num2 - num, rect.Height);
					if (rectangle.Width <= 0)
					{
						continue;
					}
					if (HasFocus && _activeFragment == i)
					{
						if (enabled)
						{
							context.Graphics.FillRectangle(SystemBrushes.Highlight, new Rectangle(rectangle.X - 1, rectangle.Y, rectangle.Width + 2, rectangle.Height));
							color = SystemColors.HighlightText;
						}
						else
						{
							using (SolidBrush brush = new SolidBrush(color))
							{
								context.Graphics.FillRectangle(brush, rectangle);
							}
							color = backColor;
						}
					}
					if (!string.IsNullOrEmpty(_inputDigits) && _activeFragment == i && !_fragments[_activeFragment].FragFormat.Contains("MMM"))
					{
						TextRenderer.DrawText(context.Graphics, _inputDigits, font, rectangle, color, _drawLeftFlags);
					}
					else
					{
						TextRenderer.DrawText(context.Graphics, _fragments[i].GetDisplay(_dt), font, rectangle, color, _drawLeftFlags);
					}
					num = num2;
				}
			}
			else
			{
				TextRenderer.DrawText(context.Graphics, _dateTimePicker.CustomNullText, font, rect, textColor, _drawLeftFlags);
			}
		}

		private void ValidateActiveFragment()
		{
			int num = -1;
			for (int i = 0; i < _fragments.Count; i++)
			{
				if (_fragments[i].AllowActive && num == -1)
				{
					num = i;
					break;
				}
			}
			if (_activeFragment >= 0)
			{
				if (_activeFragment >= _fragments.Count)
				{
					EndInputDigits();
					_activeFragment = num;
				}
				else if (!_fragments[_activeFragment].AllowActive)
				{
					EndInputDigits();
					_activeFragment = num;
				}
			}
		}

		private void MeasureFragments(Graphics g, Font font, DateTime dt)
		{
			CharacterRange[] array = new CharacterRange[_fragments.Count];
			Region[] array2 = new Region[_fragments.Count];
			for (int i = 0; i < _fragments.Count; i++)
			{
				array[i] = new CharacterRange(0, _fragments[i].GenerateOutput(dt).Length);
			}
			StringFormat stringFormat = new StringFormat(StringFormatFlags.FitBlackBox);
			stringFormat.SetMeasurableCharacterRanges(array);
			array2 = g.MeasureCharacterRanges(_fragments[_fragments.Count - 1].Output, font, _measureRect, stringFormat);
			for (int j = 0; j < _fragments.Count; j++)
			{
				_fragments[j].TotalWidth = (int)Math.Ceiling(array2[j].GetBounds(g).Width);
			}
		}

		private FormatFragmentList ParseFormatToFragments(string format)
		{
			FormatFragmentList formatFragmentList = new FormatFragmentList();
			int length = format.Length;
			int current = 0;
			int literal = 0;
			while (current < length)
			{
				switch (format[current])
				{
				case 'H':
				case 'd':
				case 'h':
				case 'm':
				case 's':
				case 't':
				case 'y':
					ParseCharacter(format[current], formatFragmentList, ref literal, ref current, ref format);
					break;
				case 'f':
					ParseCharacter('f', 7, formatFragmentList, ref literal, ref current, ref format);
					break;
				case 'F':
					ParseCharacter('F', 7, formatFragmentList, ref literal, ref current, ref format);
					break;
				case 'M':
					ParseCharacter('M', 4, formatFragmentList, ref literal, ref current, ref format);
					break;
				case '\'':
					do
					{
						current++;
						literal++;
					}
					while (current < length && format[current] != '\'');
					if (current < length && format[current] == '\'')
					{
						current++;
						literal++;
					}
					break;
				case '%':
					current++;
					break;
				default:
					current++;
					literal++;
					break;
				}
			}
			if (literal > 0)
			{
				formatFragmentList.Add(new FormatFragment(current, format, format.Substring(current - literal, literal)));
			}
			return formatFragmentList;
		}

		private void ParseCharacter(char charater, FormatFragmentList fragList, ref int literal, ref int current, ref string format)
		{
			ParseCharacter(charater, int.MaxValue, fragList, ref literal, ref current, ref format);
		}

		private void ParseCharacter(char charater, int max, FormatFragmentList fragList, ref int literal, ref int current, ref string format)
		{
			if (literal > 0)
			{
				fragList.Add(new FormatFragment(current, format, format.Substring(current - literal, literal)));
			}
			int count = CountUptoMaxCharacters(charater, max, ref current, ref format);
			fragList.Add(new FormatFragmentChar(current, format, charater, count));
			literal = 0;
		}

		private int CountUptoMaxCharacters(char character, int max, ref int current, ref string format)
		{
			int num = 0;
			int length = format.Length;
			while (current < length && num < max && format[current] == character)
			{
				num++;
				current++;
			}
			return num;
		}
	}

	private class FormatFragment
	{
		private string _fragment;

		private string _fragFormat;

		private string _output;

		private int _totalWidth;

		public string Fragment => _fragment;

		public virtual string FragFormat => _fragFormat;

		public string Output => _output;

		public int TotalWidth
		{
			get
			{
				return _totalWidth;
			}
			set
			{
				_totalWidth = value;
			}
		}

		public virtual bool AllowActive => false;

		public virtual int InputDigits => 0;

		public FormatFragment(int length, string format, string literal)
		{
			_fragFormat = literal;
			if (length == 0)
			{
				_fragment = string.Empty;
			}
			else
			{
				_fragment = format.Substring(0, length);
			}
		}

		public override string ToString()
		{
			return _fragment;
		}

		public string GenerateOutput(DateTime dt)
		{
			_output = dt.ToString(CommonHelper.MakeCustomDateFormat(Fragment));
			return _output;
		}

		public virtual DateTime EndDigits(DateTime dt, string digits)
		{
			return dt;
		}

		public virtual string GetDisplay(DateTime dt)
		{
			if (FragFormat.Length == 1)
			{
				return dt.ToString("\\" + FragFormat);
			}
			return dt.ToString(FragFormat);
		}

		public virtual DateTime Increment(DateTime dt, bool forward)
		{
			Debug.Assert(condition: false);
			return dt;
		}

		public virtual DateTime AMPM(DateTime dt, bool am)
		{
			Debug.Assert(condition: false);
			return dt;
		}
	}

	private class FormatFragmentChar : FormatFragment
	{
		private string _fragFormat;

		public override string FragFormat => _fragFormat;

		public override bool AllowActive
		{
			get
			{
				switch (FragFormat)
				{
				case "d":
				case "dd":
				case "M":
				case "MM":
				case "MMM":
				case "MMMM":
					return true;
				default:
					if (FragFormat.StartsWith("h") || FragFormat.StartsWith("H") || FragFormat.StartsWith("m") || FragFormat.StartsWith("s") || FragFormat.StartsWith("t") || FragFormat.StartsWith("f") || FragFormat.StartsWith("F") || FragFormat.StartsWith("y"))
					{
						return true;
					}
					return false;
				}
			}
		}

		public override int InputDigits
		{
			get
			{
				switch (FragFormat)
				{
				case "f":
				case "F":
					return 1;
				case "d":
				case "dd":
				case "M":
				case "MM":
				case "MMM":
				case "MMMM":
				case "ff":
				case "FF":
					return 2;
				case "fff":
				case "FFF":
					return 3;
				case "ffff":
				case "FFFF":
					return 4;
				case "fffff":
				case "FFFFF":
					return 5;
				case "ffffff":
				case "FFFFFF":
					return 6;
				case "fffffff":
				case "FFFFFFF":
					return 7;
				default:
					if (FragFormat.StartsWith("h") || FragFormat.StartsWith("H") || FragFormat.StartsWith("m") || FragFormat.StartsWith("s"))
					{
						return 2;
					}
					if (FragFormat.StartsWith("y"))
					{
						return 4;
					}
					return base.InputDigits;
				}
			}
		}

		public FormatFragmentChar(int index, string format, char character, int count)
			: base(index, format, string.Empty)
		{
			_fragFormat = new string(character, count);
		}

		public override string ToString()
		{
			return base.ToString() + " (" + _fragFormat + ")";
		}

		public override DateTime EndDigits(DateTime dt, string digits)
		{
			switch (FragFormat)
			{
			case "d":
			case "dd":
			{
				int num2 = int.Parse(digits);
				if (num2 <= LastDayOfMonth(dt).Day && num2 > 0)
				{
					dt = dt.AddDays(num2 - dt.Day);
				}
				break;
			}
			case "M":
			case "MM":
			{
				int num = int.Parse(digits);
				if (num <= 12 && num > 0)
				{
					dt = dt.AddMonths(num - dt.Month);
				}
				break;
			}
			case "f":
			case "F":
			case "ff":
			case "FF":
			case "fff":
			case "FFF":
			case "ffff":
			case "FFFF":
			case "fffff":
			case "FFFFF":
			case "ffffff":
			case "FFFFFF":
			case "fffffff":
			case "FFFFFFF":
				dt = dt.AddMilliseconds(int.Parse(digits) - dt.Millisecond);
				break;
			}
			if (FragFormat.StartsWith("h") || FragFormat.StartsWith("H"))
			{
				int num3 = int.Parse(digits);
				if (num3 < 24 && num3 >= 0)
				{
					dt = dt.AddHours(num3 - dt.Hour);
				}
			}
			else if (FragFormat.StartsWith("m"))
			{
				int num4 = int.Parse(digits);
				if (num4 < 60 && num4 >= 0)
				{
					dt = dt.AddMinutes(num4 - dt.Minute);
				}
			}
			else if (FragFormat.StartsWith("s"))
			{
				int num5 = int.Parse(digits);
				if (num5 < 60 && num5 >= 0)
				{
					dt = dt.AddSeconds(num5 - dt.Second);
				}
			}
			else if (FragFormat.StartsWith("y"))
			{
				int num6 = int.Parse(digits);
				if (num6 != 0)
				{
					if (digits.Length == 2)
					{
						num6 = ((num6 < 30) ? (num6 + 2000) : (num6 + 1900));
						dt = dt.AddYears(num6 - dt.Year);
					}
					else if (digits.Length == 4)
					{
						dt = dt.AddYears(num6 - dt.Year);
					}
				}
			}
			return dt;
		}

		public override string GetDisplay(DateTime dt)
		{
			return dt.ToString(CommonHelper.MakeCustomDateFormat(FragFormat));
		}

		public override DateTime Increment(DateTime dt, bool forward)
		{
			switch (FragFormat)
			{
			case "d":
			case "dd":
			{
				int month = dt.Month;
				dt = ((!forward) ? ((dt.Day != 1) ? dt.AddDays(-1.0) : dt.AddDays(LastDayOfMonth(dt).Day - 1)) : ((dt.Day != LastDayOfMonth(dt).Day) ? dt.AddDays(1.0) : dt.AddDays(-(dt.Day - 1))));
				break;
			}
			case "M":
			case "MM":
			case "MMM":
			case "MMMM":
				dt = ((!forward) ? ((dt.Month != 1) ? dt.AddMonths(-1) : dt.AddMonths(11)) : ((dt.Month != 12) ? dt.AddMonths(1) : dt.AddMonths(-(dt.Month - 1))));
				break;
			}
			if (FragFormat.StartsWith("h") || FragFormat.StartsWith("H"))
			{
				if (forward)
				{
					if (dt.Hour == 23)
					{
						dt = dt.AddHours(1.0);
						dt = dt.AddDays(-1.0);
					}
					else
					{
						dt = dt.AddHours(1.0);
					}
				}
				else if (dt.Hour == 1)
				{
					dt = dt.AddHours(-1.0);
					dt = dt.AddDays(1.0);
				}
				else
				{
					dt = dt.AddHours(-1.0);
				}
			}
			if (FragFormat.StartsWith("m"))
			{
				dt = (forward ? ((dt.Minute != 59) ? dt.AddMinutes(1.0) : dt.AddMinutes(-dt.Minute)) : ((dt.Minute != 0) ? dt.AddMinutes(-1.0) : dt.AddMinutes(59 - dt.Minute)));
			}
			if (FragFormat.StartsWith("s"))
			{
				dt = (forward ? ((dt.Second != 59) ? dt.AddSeconds(1.0) : dt.AddSeconds(-dt.Second)) : ((dt.Second != 0) ? dt.AddSeconds(-1.0) : dt.AddSeconds(59 - dt.Second)));
			}
			if (FragFormat.StartsWith("t"))
			{
				dt = ((dt.Hour <= 11) ? dt.AddHours(12.0) : dt.AddHours(-12.0));
			}
			if (FragFormat.StartsWith("y"))
			{
				dt = ((!forward) ? dt.AddYears(-1) : dt.AddYears(1));
			}
			if (FragFormat.StartsWith("f") || FragFormat.StartsWith("F"))
			{
				int num = Math.Min(FragFormat.Length, 3);
				double num2 = 1000.0;
				for (int i = 0; i < num; i++)
				{
					num2 /= 10.0;
				}
				dt = ((!forward) ? dt.AddMilliseconds(0.0 - num2) : dt.AddMilliseconds(num2));
			}
			return dt;
		}

		public override DateTime AMPM(DateTime dt, bool am)
		{
			if (FragFormat.StartsWith("t"))
			{
				if (dt.Hour > 11 && am)
				{
					dt = dt.AddHours(-12.0);
				}
				else if (dt.Hour < 12 && !am)
				{
					dt = dt.AddHours(12.0);
				}
			}
			return dt;
		}

		private DateTime LastDayOfMonth(DateTime dt)
		{
			dt = dt.AddMonths(1);
			dt = dt.AddDays(-dt.Day);
			return new DateTime(dt.Year, dt.Month, dt.Day);
		}
	}

	private class FormatFragmentList : List<FormatFragment>
	{
	}

	private static readonly RectangleF _measureRect = new RectangleF(0f, 0f, 1000f, 1000f);

	private static readonly TextFormatFlags _measureFlags = TextFormatFlags.TextBoxControl | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding;

	private static readonly TextFormatFlags _drawLeftFlags = TextFormatFlags.TextBoxControl | TextFormatFlags.VerticalCenter | TextFormatFlags.NoPadding;

	private KryptonDateTimePicker _dateTimePicker;

	private FormatHandler _formatHandler;

	private NeedPaintHandler _needPaint;

	public bool RightToLeftLayout
	{
		get
		{
			return _formatHandler.RightToLeftLayout;
		}
		set
		{
			_formatHandler.RightToLeftLayout = value;
		}
	}

	public bool HasFocus
	{
		get
		{
			return _formatHandler.HasFocus;
		}
		set
		{
			_formatHandler.HasFocus = value;
		}
	}

	public bool HasActiveFragment => _formatHandler.HasActiveFragment;

	public string ActiveFragment
	{
		get
		{
			return _formatHandler.ActiveFragment;
		}
		set
		{
			_formatHandler.ActiveFragment = value;
		}
	}

	public ViewDrawDateTimeText(KryptonDateTimePicker dateTimePicker, NeedPaintHandler needPaint)
	{
		_dateTimePicker = dateTimePicker;
		_needPaint = needPaint;
		_formatHandler = new FormatHandler(dateTimePicker, this, needPaint);
	}

	public override string ToString()
	{
		_formatHandler.DateTime = _dateTimePicker.Value;
		return _formatHandler.ToString();
	}

	public void OnAutoShiftOverflow(CancelEventArgs e)
	{
		_dateTimePicker.OnAutoShiftOverflow(e);
	}

	public void ClearActiveFragment()
	{
		if (_formatHandler.IsInputDigits)
		{
			_formatHandler.EndInputDigits();
		}
		_formatHandler.ClearActiveFragment();
	}

	public void EndInputDigits()
	{
		if (_formatHandler.IsInputDigits)
		{
			_formatHandler.EndInputDigits();
		}
	}

	public void MoveFirstFragment()
	{
		if (_formatHandler.IsInputDigits)
		{
			_formatHandler.EndInputDigits();
		}
		_formatHandler.MoveFirst();
	}

	public void MoveNextFragment()
	{
		if (_formatHandler.IsInputDigits)
		{
			_formatHandler.EndInputDigits();
		}
		_formatHandler.MoveNext();
	}

	public void MovePreviousFragment()
	{
		if (_formatHandler.IsInputDigits)
		{
			_formatHandler.EndInputDigits();
		}
		_formatHandler.MovePrevious();
	}

	public void MoveLastFragment()
	{
		if (_formatHandler.IsInputDigits)
		{
			_formatHandler.EndInputDigits();
		}
		_formatHandler.MoveLast();
	}

	public void SelectFragment(Point pt, MouseButtons button)
	{
		_formatHandler.SelectFragment(pt);
		PerformNeedPaint(needLayout: true);
	}

	public void PerformKeyDown(KeyEventArgs e)
	{
		switch (e.KeyCode)
		{
		case Keys.Left:
			if (_formatHandler.IsInputDigits)
			{
				_formatHandler.EndInputDigits();
			}
			if (_dateTimePicker.ShowCheckBox && _dateTimePicker.InternalViewDrawCheckBox.ForcedTracking)
			{
				if (_dateTimePicker.Checked)
				{
					_dateTimePicker.InternalViewDrawCheckBox.ForcedTracking = false;
					_formatHandler.MoveLast();
				}
			}
			else
			{
				_formatHandler.MoveLeft();
				if (!_formatHandler.HasActiveFragment)
				{
					if (_dateTimePicker.ShowCheckBox)
					{
						_dateTimePicker.InternalViewDrawCheckBox.ForcedTracking = true;
					}
					else
					{
						_formatHandler.MoveLast();
					}
				}
			}
			PerformNeedPaint(needLayout: false);
			break;
		case Keys.Right:
		case Keys.Subtract:
		case Keys.Decimal:
		case Keys.Divide:
			if (_formatHandler.IsInputDigits)
			{
				_formatHandler.EndInputDigits();
			}
			if (_dateTimePicker.ShowCheckBox && _dateTimePicker.InternalViewDrawCheckBox.ForcedTracking)
			{
				if (_dateTimePicker.Checked)
				{
					_dateTimePicker.InternalViewDrawCheckBox.ForcedTracking = false;
					_formatHandler.MoveFirst();
				}
			}
			else
			{
				_formatHandler.MoveRight();
				if (!_formatHandler.HasActiveFragment)
				{
					if (_dateTimePicker.ShowCheckBox)
					{
						_dateTimePicker.InternalViewDrawCheckBox.ForcedTracking = true;
					}
					else
					{
						_formatHandler.MoveFirst();
					}
				}
			}
			PerformNeedPaint(needLayout: false);
			break;
		case Keys.Up:
			if (_dateTimePicker.Checked)
			{
				if (_formatHandler.IsInputDigits)
				{
					_formatHandler.EndInputDigits();
				}
				else
				{
					_dateTimePicker.Value = ValidateDate(_formatHandler.Increment(forward: true));
				}
				PerformNeedPaint(needLayout: false);
			}
			break;
		case Keys.Down:
			if (_dateTimePicker.Checked)
			{
				if (_formatHandler.IsInputDigits)
				{
					_formatHandler.EndInputDigits();
				}
				else
				{
					_dateTimePicker.Value = ValidateDate(_formatHandler.Increment(forward: false));
				}
				PerformNeedPaint(needLayout: false);
			}
			break;
		case Keys.A:
		case Keys.P:
			if (_dateTimePicker.Checked)
			{
				_dateTimePicker.Value = ValidateDate(_formatHandler.AMPM(e.KeyCode == Keys.A));
				PerformNeedPaint(needLayout: false);
			}
			break;
		}
	}

	public void PerformKeyPress(KeyPressEventArgs e)
	{
		if (char.IsDigit(e.KeyChar) && _formatHandler.HasActiveFragment)
		{
			_formatHandler.InputDigit(e.KeyChar);
			PerformNeedPaint(needLayout: true);
		}
	}

	public override Size GetPreferredSize(ViewLayoutContext context)
	{
		Debug.Assert(context != null);
		_formatHandler.DateTime = _dateTimePicker.Value;
		Font font = GetFont();
		Size result = TextRenderer.MeasureText(GetFullDisplayText(), font, Size.Empty, _measureFlags);
		result.Height = Math.Max(font.Height, result.Height);
		result.Height += 3;
		return result;
	}

	public override void Layout(ViewLayoutContext context)
	{
		ClientRectangle = context.DisplayRectangle;
		_formatHandler.DateTime = _dateTimePicker.Value;
		_formatHandler.ParseFormat(GetFormat(), context.Graphics, GetFont());
	}

	public override void Render(RenderContext context)
	{
		_formatHandler.DateTime = _dateTimePicker.Value;
		using (new Clipping(context.Graphics, ClientRectangle))
		{
			_formatHandler.Render(context, GetFont(), ClientRectangle, GetTextColor(), GetBackColor(), _dateTimePicker.Checked);
		}
	}

	internal DateTime ValidateDate(DateTime dt)
	{
		if (dt < _dateTimePicker.EffectiveMinDate(_dateTimePicker.MinDate))
		{
			return _dateTimePicker.EffectiveMinDate(_dateTimePicker.MinDate);
		}
		if (dt > _dateTimePicker.EffectiveMaxDate(_dateTimePicker.MaxDate))
		{
			return _dateTimePicker.EffectiveMaxDate(_dateTimePicker.MaxDate);
		}
		return dt;
	}

	private void PerformNeedPaint(bool needLayout)
	{
		_needPaint(this, new NeedLayoutEventArgs(needLayout));
	}

	private Font GetFont()
	{
		if (!Enabled || _dateTimePicker.InternalDateTimeNull())
		{
			return _dateTimePicker.StateDisabled.PaletteContent.GetContentShortTextFont(PaletteState.Disabled);
		}
		if (_dateTimePicker.IsActive)
		{
			return _dateTimePicker.StateActive.PaletteContent.GetContentShortTextFont(PaletteState.Normal);
		}
		return _dateTimePicker.StateNormal.PaletteContent.GetContentShortTextFont(PaletteState.Normal);
	}

	private Color GetTextColor()
	{
		if (!Enabled || _dateTimePicker.InternalDateTimeNull())
		{
			return _dateTimePicker.StateDisabled.PaletteContent.GetContentShortTextColor1(PaletteState.Disabled);
		}
		if (_dateTimePicker.IsActive)
		{
			return _dateTimePicker.StateActive.PaletteContent.GetContentShortTextColor1(PaletteState.Normal);
		}
		return _dateTimePicker.StateNormal.PaletteContent.GetContentShortTextColor1(PaletteState.Normal);
	}

	private Color GetBackColor()
	{
		if (!Enabled || _dateTimePicker.InternalDateTimeNull())
		{
			return _dateTimePicker.StateDisabled.PaletteBack.GetBackColor1(PaletteState.Disabled);
		}
		if (_dateTimePicker.IsActive)
		{
			return _dateTimePicker.StateActive.PaletteBack.GetBackColor1(PaletteState.Normal);
		}
		return _dateTimePicker.StateNormal.PaletteBack.GetBackColor1(PaletteState.Normal);
	}

	private string GetFormat()
	{
		string result = string.Empty;
		switch (_dateTimePicker.Format)
		{
		case DateTimePickerFormat.Long:
			result = CultureInfo.CurrentCulture.DateTimeFormat.LongDatePattern;
			break;
		case DateTimePickerFormat.Short:
			result = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern;
			break;
		case DateTimePickerFormat.Time:
			result = CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;
			break;
		case DateTimePickerFormat.Custom:
			result = CommonHelper.MakeCustomDateFormat(_dateTimePicker.CustomFormat);
			break;
		}
		return result;
	}

	private string GetFullDisplayText()
	{
		try
		{
			return _dateTimePicker.Value.ToString(GetFormat());
		}
		catch
		{
			return string.Empty;
		}
	}
}
