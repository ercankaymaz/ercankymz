using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;
using buControls.Controls;
using buControls.Forms.WinControlForms.Settings;
using buCore;
using buHandler;
using buOpcUA;

namespace buMotion;

public class buMotionCommands
{
	[CompilerGenerated]
	private MotionCommandEventHandler _0001;

	[CompilerGenerated]
	private MotionActionEventHandler _0001;

	private static string _0001;

	private string _0002 = _0090(107389806);

	[NonSerialized]
	internal static GetString _0090;

	public event MotionCommandEventHandler clickAlarmReset
	{
		[CompilerGenerated]
		add
		{
			MotionCommandEventHandler motionCommandEventHandler = this._0001;
			while (true)
			{
				MotionCommandEventHandler motionCommandEventHandler2 = motionCommandEventHandler;
				while (true)
				{
					MotionCommandEventHandler obj = (MotionCommandEventHandler)global::_0001._0001(motionCommandEventHandler2, value);
					MotionCommandEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					motionCommandEventHandler = Interlocked.CompareExchange(ref this._0001, value2, motionCommandEventHandler2);
					if ((object)motionCommandEventHandler != motionCommandEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			MotionCommandEventHandler motionCommandEventHandler = this._0001;
			while (true)
			{
				MotionCommandEventHandler motionCommandEventHandler2 = motionCommandEventHandler;
				while (true)
				{
					MotionCommandEventHandler obj = (MotionCommandEventHandler)global::_0001._0002(motionCommandEventHandler2, value);
					MotionCommandEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					motionCommandEventHandler = Interlocked.CompareExchange(ref this._0001, value2, motionCommandEventHandler2);
					if ((object)motionCommandEventHandler != motionCommandEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public event MotionActionEventHandler MotionCommandEvents
	{
		[CompilerGenerated]
		add
		{
			MotionActionEventHandler motionActionEventHandler = this._0001;
			while (true)
			{
				MotionActionEventHandler motionActionEventHandler2 = motionActionEventHandler;
				while (true)
				{
					MotionActionEventHandler obj = (MotionActionEventHandler)global::_0001._0001(motionActionEventHandler2, value);
					MotionActionEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					motionActionEventHandler = Interlocked.CompareExchange(ref this._0001, value2, motionActionEventHandler2);
					if ((object)motionActionEventHandler != motionActionEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
		[CompilerGenerated]
		remove
		{
			MotionActionEventHandler motionActionEventHandler = this._0001;
			while (true)
			{
				MotionActionEventHandler motionActionEventHandler2 = motionActionEventHandler;
				while (true)
				{
					MotionActionEventHandler obj = (MotionActionEventHandler)global::_0001._0002(motionActionEventHandler2, value);
					MotionActionEventHandler value2;
					if (4u != 0)
					{
						value2 = obj;
					}
					motionActionEventHandler = Interlocked.CompareExchange(ref this._0001, value2, motionActionEventHandler2);
					if ((object)motionActionEventHandler != motionActionEventHandler2)
					{
						break;
					}
					if (0 == 0 && 0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public unsafe void SetAxisEnable(CodesysAxis refAxis, bool Condition)
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				string text = global::_0002._0003(refAxis.Base.baseName, _0090(107397159), refAxis.Base.baseNo.ToString());
				global::_0004._0006(_0090(107397154), global::_0003._0005(_0090(107397105), Condition.ToString()), text);
				writeBOOLVar(CodesysVariableBaseType.Global, Condition, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107397120)));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107397098), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			do
			{
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
			while (-1 == 0);
		}
	}

	public unsafe void SetAxisHomingDone(CodesysAxis refAxis, bool Condition, string VarName = "")
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				string text = global::_0002._0003(refAxis.Base.baseName, _0090(107397159), refAxis.Base.baseNo.ToString());
				global::_0004._0006(_0090(107397064), global::_0003._0005(_0090(107397105), Condition.ToString()), text);
				writeBOOLVar(CodesysVariableBaseType.Global, Condition, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107397011)));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107396986), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			do
			{
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
			while (-1 == 0);
		}
	}

	public unsafe void GoAxisHoming(CodesysAxis refAxis, bool Condition, string VarName = "")
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				string text = global::_0002._0003(refAxis.Base.baseName, _0090(107397159), refAxis.Base.baseNo.ToString());
				global::_0004._0006(_0090(107396993), global::_0003._0005(_0090(107397105), Condition.ToString()), text);
				writeBOOLVar(CodesysVariableBaseType.Global, Condition, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107396460)));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107396407), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			do
			{
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
			while (-1 == 0);
		}
	}

	public unsafe void jogForward(CodesysAxis refAxis, double Velocity, bool Condition)
	{
		if (6 == 0)
		{
			return;
		}
		void* ptr;
		if (0 == 0)
		{
			ptr = stackalloc byte[14];
		}
		try
		{
			if (4u != 0)
			{
				if (0 == 0)
				{
				}
				((sbyte*)ptr)[12] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			}
			sbyte num = ((sbyte*)ptr)[12];
			if (0 == 0)
			{
				if (num != 0)
				{
					return;
				}
				*(double*)ptr = refAxis.Jogs.jogVelocity;
				((sbyte*)ptr)[13] = ((Velocity != 0.0) ? ((sbyte)1) : ((sbyte)0));
				if (7 == 0)
				{
					goto IL_0198;
				}
				num = ((sbyte*)ptr)[13];
			}
			if (num == 0)
			{
				goto IL_0088;
			}
			goto IL_0198;
			IL_0088:
			string text = global::_0002._0003(refAxis.Base.baseName, _0090(107397159), refAxis.Base.baseNo.ToString());
			global::_0004._0006(_0090(107396422), global::_0006._0008(_0090(107396373), ((double*)ptr)->ToString(), _0090(107396392), Condition.ToString()), text);
			writeLREALVar(CodesysVariableBaseType.Global, *(double*)ptr, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107396339)));
			writeBOOLVar(CodesysVariableBaseType.Global, Condition, global::_0003._0005(refAxis.Strings.strRunExe, _0090(107396318)));
			return;
			IL_0198:
			*(double*)ptr = Velocity;
			goto IL_0088;
		}
		catch (Exception ee)
		{
			((int*)ptr)[2] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107396422), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[2], ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void jogBackward(CodesysAxis refAxis, double Velocity, bool Condition)
	{
		if (6 == 0)
		{
			return;
		}
		void* ptr;
		if (0 == 0)
		{
			ptr = stackalloc byte[14];
		}
		try
		{
			if (4u != 0)
			{
				if (0 == 0)
				{
				}
				((sbyte*)ptr)[12] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			}
			sbyte num = ((sbyte*)ptr)[12];
			if (0 == 0)
			{
				if (num != 0)
				{
					return;
				}
				*(double*)ptr = refAxis.Jogs.jogVelocity;
				((sbyte*)ptr)[13] = ((Velocity != 0.0) ? ((sbyte)1) : ((sbyte)0));
				if (7 == 0)
				{
					goto IL_0198;
				}
				num = ((sbyte*)ptr)[13];
			}
			if (num == 0)
			{
				goto IL_0088;
			}
			goto IL_0198;
			IL_0088:
			string text = global::_0002._0003(refAxis.Base.baseName, _0090(107397159), refAxis.Base.baseNo.ToString());
			global::_0004._0006(_0090(107396305), global::_0006._0008(_0090(107396373), ((double*)ptr)->ToString(), _0090(107396392), Condition.ToString()), text);
			writeLREALVar(CodesysVariableBaseType.Global, *(double*)ptr, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107396339)));
			writeBOOLVar(CodesysVariableBaseType.Global, Condition, global::_0003._0005(refAxis.Strings.strRunExe, _0090(107396320)));
			return;
			IL_0198:
			*(double*)ptr = Velocity;
			goto IL_0088;
		}
		catch (Exception ee)
		{
			((int*)ptr)[2] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107396305), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[2], ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void jogStop(CodesysAxis refAxis)
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				writeBOOLVar(CodesysVariableBaseType.Global, Val: false, global::_0003._0005(refAxis.Strings.strRunExe, _0090(107396320)));
				writeBOOLVar(CodesysVariableBaseType.Global, Val: false, global::_0003._0005(refAxis.Strings.strRunExe, _0090(107396318)));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107396275), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void moveAbsolute(CodesysAxis refAxis, double Velocity, double Position, bool Condition)
	{
		void* ptr = stackalloc byte[14];
		try
		{
			((sbyte*)ptr)[12] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[12] == 0)
			{
				*(double*)ptr = refAxis.Moves.moveVelocity;
				((sbyte*)ptr)[13] = ((Velocity != 0.0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[13])
				{
					*(double*)ptr = Velocity;
				}
				string text = global::_0002._0003(refAxis.Base.baseName, _0090(107397159), refAxis.Base.baseNo.ToString());
				global::_0004._0006(_0090(107396294), global::_0007._000E(new string[6]
				{
					_0090(107396245),
					((double*)ptr)->ToString(),
					_0090(107396268),
					Position.ToString(),
					_0090(107396392),
					Condition.ToString()
				}), text);
				writeLREALVar(CodesysVariableBaseType.Global, *(double*)ptr, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107396223)));
				writeLREALVar(CodesysVariableBaseType.Global, Position, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107396226)));
				writeBOOLVar(CodesysVariableBaseType.Global, Val: true, global::_0003._0005(refAxis.Strings.strRunExe, _0090(107396709)));
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[2] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107396294), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[2], ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void moveIncremental(CodesysAxis refAxis, double Velocity, double Distance, double Dir, bool Condition)
	{
		void* ptr = stackalloc byte[14];
		try
		{
			((sbyte*)ptr)[12] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[12] == 0)
			{
				*(double*)ptr = refAxis.Moves.moveVelocity;
				((sbyte*)ptr)[13] = ((Velocity != 0.0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[13])
				{
					*(double*)ptr = Velocity;
				}
				string text = global::_0002._0003(refAxis.Base.baseName, _0090(107397159), refAxis.Base.baseNo.ToString());
				global::_0004._0006(_0090(107396668), global::_0007._000E(new string[6]
				{
					_0090(107396245),
					((double*)ptr)->ToString(),
					_0090(107396679),
					Distance.ToString(),
					_0090(107396392),
					Condition.ToString()
				}), text);
				writeLREALVar(CodesysVariableBaseType.Global, *(double*)ptr, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107396634)));
				writeLREALVar(CodesysVariableBaseType.Global, Distance * Dir, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107396605)));
				global::_0008._000F(500);
				writeBOOLVar(CodesysVariableBaseType.Global, Val: true, global::_0003._0005(refAxis.Strings.strRunExe, _0090(107396608)));
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[2] = 0;
			string message = _0090(107397099);
			while (true)
			{
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107396668), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[2], ee);
				while (true)
				{
					global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
					if (1 == 0)
					{
						break;
					}
					if (0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public unsafe void Stop(CodesysAxis refAxis)
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				string text = global::_0002._0003(refAxis.Base.baseName, _0090(107397159), refAxis.Base.baseNo.ToString());
				if (0 == 0)
				{
					global::_0004._0006(_0090(107396567), _0090(107397099), text);
				}
				writeBOOLVar(CodesysVariableBaseType.Global, Val: true, global::_0003._0005(refAxis.Strings.strRunExe, _0090(107396590)));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107396590), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void AutoTest(CodesysAxis refAxis, double Velocity, double Position1, double Position2, bool Condition)
	{
		void* ptr = stackalloc byte[14];
		try
		{
			((sbyte*)ptr)[12] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[12] == 0)
			{
				*(double*)ptr = refAxis.Moves.moveVelocity;
				((sbyte*)ptr)[13] = ((Velocity != 0.0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[13])
				{
					*(double*)ptr = Velocity;
				}
				string text = global::_0002._0003(refAxis.Base.baseName, _0090(107397159), refAxis.Base.baseNo.ToString());
				global::_0004._0006(_0090(107396581), global::_0007._000E(new string[8]
				{
					_0090(107396245),
					((double*)ptr)->ToString(),
					_0090(107396536),
					Position1.ToString(),
					_0090(107396555),
					Position2.ToString(),
					_0090(107396392),
					Condition.ToString()
				}), text);
				writeLREALVar(CodesysVariableBaseType.Global, *(double*)ptr, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107396223)));
				writeLREALVar(CodesysVariableBaseType.Global, Position1, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107396510)));
				writeLREALVar(CodesysVariableBaseType.Global, Position2, global::_0003._0005(refAxis.Strings.strRuntimeVar, _0090(107396513)));
				writeBOOLVar(CodesysVariableBaseType.Global, Val: true, global::_0003._0005(refAxis.Strings.strRunExe, _0090(107396484)));
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[2] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107396294), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[2], ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void getAxesEnabled(ref CodesysAxesData refData, ref bool Value, string VarName = "")
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			do
			{
				if (((bool*)ptr)[4])
				{
					if (-1 == 0)
					{
					}
					return;
				}
			}
			while (4 == 0);
			readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(StringSystem.strSystemRuntimeVar, _0090(107395951)), ref Value);
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395890), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void getHomingDone(ref CodesysAxesData refData, ref bool Value, string VarName = "")
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			do
			{
				if (((bool*)ptr)[4])
				{
					if (-1 == 0)
					{
					}
					return;
				}
			}
			while (4 == 0);
			readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(StringSystem.strSystemRuntimeVar, _0090(107395865)), ref Value);
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395836), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void getFileLoaded(ref CodesysAxesData refData, ref bool Value, string VarName = "")
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			do
			{
				if (((bool*)ptr)[4])
				{
					if (-1 == 0)
					{
					}
					return;
				}
			}
			while (4 == 0);
			readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(StringSystem.strSystemRuntimeVar, _0090(107395847)), ref Value);
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395818), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void getRun(ref CodesysAxesData refData, ref bool Value, string VarName = "")
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			do
			{
				if (((bool*)ptr)[4])
				{
					if (-1 == 0)
					{
					}
					return;
				}
			}
			while (4 == 0);
			readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(StringSystem.strSystemRuntimeVar, _0090(107395765)), ref Value);
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395776), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void getPaused(ref CodesysAxesData refData, ref bool Value, string VarName = "")
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			do
			{
				if (((bool*)ptr)[4])
				{
					if (-1 == 0)
					{
					}
					return;
				}
			}
			while (4 == 0);
			readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(StringSystem.strSystemRuntimeVar, _0090(107395735)), ref Value);
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395746), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void StartAuto()
	{
		void* ptr = stackalloc byte[5];
		do
		{
			try
			{
				if (8 == 0)
				{
					continue;
				}
				((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[4])
				{
					if (3 == 0)
					{
					}
					continue;
				}
				global::_0004._0006(_0090(107395701), _0090(107397099), _0090(107397099));
				if (0 == 0)
				{
					writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0090(107395720));
				}
			}
			catch (Exception ee)
			{
				*(int*)ptr = 0;
				string message;
				if (0 == 0)
				{
					message = _0090(107397099);
				}
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395701), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
		}
		while (3 == 0);
	}

	public unsafe void Stop()
	{
		void* ptr = stackalloc byte[5];
		do
		{
			try
			{
				if (8 == 0)
				{
					continue;
				}
				((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[4])
				{
					if (3 == 0)
					{
					}
					continue;
				}
				global::_0004._0006(_0090(107396590), _0090(107397099), _0090(107397099));
				if (0 == 0)
				{
					writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0090(107396203));
				}
			}
			catch (Exception ee)
			{
				*(int*)ptr = 0;
				string message;
				if (0 == 0)
				{
					message = _0090(107397099);
				}
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107396590), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
		}
		while (3 == 0);
	}

	public unsafe void PauseAuto(bool Condition)
	{
		void* ptr = stackalloc byte[6];
		try
		{
			do
			{
				((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[4])
				{
					return;
				}
				global::_0004._0006(_0090(107396146), Condition.ToString(), _0090(107397099));
				((sbyte*)ptr)[5] = (Condition ? ((sbyte)1) : ((sbyte)0));
			}
			while (7 == 0);
			if (((bool*)ptr)[5])
			{
				writeBOOLVar(CodesysVariableBaseType.Global, Condition, _0090(107396165));
			}
			else if (0 == 0)
			{
				writeBOOLVar(CodesysVariableBaseType.Global, Condition, _0090(107396136));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107396146), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void SetStateOfCheckBoxControl(Control.ControlCollection Controls, int Index, bool State)
	{
		void* ptr = stackalloc byte[21];
		if (3 == 0)
		{
			return;
		}
		try
		{
			*(int*)ptr = 1;
			while (true)
			{
				((sbyte*)ptr)[20] = ((*(int*)ptr <= global::_0013._007E_001E(Controls) - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[20] == 0)
				{
					break;
				}
				((sbyte*)ptr)[12] = ((global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr)) != null) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[12])
				{
					((sbyte*)ptr)[13] = ((global::_000E._007E_0010(Controls, *(int*)ptr) is buCheckBox) ? ((sbyte)1) : ((sbyte)0));
					sbyte num = ((sbyte*)ptr)[13];
					while (true)
					{
						if (num != 0)
						{
							((int*)ptr)[1] = global::_0011._001A(global::_0010._007E_0012(global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr))));
							((sbyte*)ptr)[14] = 1;
							((sbyte*)ptr)[15] = ((global::_0013._007E_001D(global::_0010._007E_0013(global::_0012._007E_001C((buCheckBox)global::_000E._007E_0010(Controls, *(int*)ptr)))) > 0) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[15])
							{
								((sbyte*)ptr)[14] = 0;
								((sbyte*)ptr)[16] = ((global::_0014._001F(global::_0010._007E_0013(global::_0012._007E_001C((buCheckBox)global::_000E._007E_0010(Controls, *(int*)ptr))), _0090(107396103)) | global::_0014._001F(global::_0010._007E_0013(global::_0012._007E_001C((buCheckBox)global::_000E._007E_0010(Controls, *(int*)ptr))), _0090(107396098))) ? ((sbyte)1) : ((sbyte)0));
								goto IL_0184;
							}
							goto IL_0194;
						}
						((sbyte*)ptr)[18] = ((global::_000E._007E_0010(Controls, *(int*)ptr) is CheckBox) ? ((sbyte)1) : ((sbyte)0));
						num = ((sbyte*)ptr)[18];
						if (false)
						{
							continue;
						}
						if (num != 0)
						{
							((int*)ptr)[2] = global::_0011._001A(global::_0010._007E_0012(global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr))));
							((sbyte*)ptr)[19] = ((((int*)ptr)[2] == Index) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[19])
							{
								global::_0015._007E_0081((CheckBox)global::_000E._007E_0010(Controls, *(int*)ptr), State);
							}
						}
						break;
						IL_0194:
						((sbyte*)ptr)[17] = (sbyte)(((((int*)ptr)[1] == Index) ? 1 : 0) & (int)((sbyte*)ptr)[14]);
						if (((bool*)ptr)[17])
						{
							global::_0015._007E_0080((buCheckBox)global::_000E._007E_0010(Controls, *(int*)ptr), State);
							if (0 == 0)
							{
								break;
							}
							goto IL_0184;
						}
						break;
						IL_0184:
						if (((bool*)ptr)[16])
						{
							((sbyte*)ptr)[14] = 1;
						}
						goto IL_0194;
					}
				}
				(*(int*)ptr)++;
			}
		}
		catch (Exception ex)
		{
			string text;
			do
			{
				text = global::_0006._0008(_0090(107396061), Index.ToString(), _0090(107396048), State.ToString());
				global::_0004._0006(text, _0090(107396031), global::_0010._007E_0014(global::_0016._0082()));
			}
			while (1 == 0);
			global::_0017._0083(ex, global::_0010._007E_0014(global::_0016._0082()), true, text);
		}
	}

	public unsafe void SetStateOfControlAsImage(Control.ControlCollection Controls, int SourceIndex, string Name, Image image)
	{
		void* ptr = stackalloc byte[29];
		try
		{
			*(int*)ptr = 1;
			while (true)
			{
				((sbyte*)ptr)[28] = ((*(int*)ptr <= global::_0013._007E_001E(Controls) - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[28] == 0)
				{
					break;
				}
				((sbyte*)ptr)[16] = ((global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr)) != null) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[16])
				{
					((sbyte*)ptr)[17] = ((global::_000E._007E_0010(Controls, *(int*)ptr) is buControl) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[17])
					{
						((int*)ptr)[1] = global::_0011._001A(global::_0010._007E_0012(global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr))));
						((sbyte*)ptr)[18] = 1;
						((sbyte*)ptr)[19] = ((global::_0013._007E_001D(global::_0010._007E_0013(global::_0012._007E_001C((buControl)global::_000E._007E_0010(Controls, *(int*)ptr)))) > 0) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[19])
						{
							((sbyte*)ptr)[18] = 0;
							((sbyte*)ptr)[20] = ((global::_0014._001F(global::_0010._007E_0013(global::_0012._007E_001C((buControl)global::_000E._007E_0010(Controls, *(int*)ptr))), _0090(107396103)) | global::_0014._001F(global::_0010._007E_0013(global::_0012._007E_001C((buControl)global::_000E._007E_0010(Controls, *(int*)ptr))), _0090(107396098))) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[20])
							{
								((sbyte*)ptr)[18] = 1;
							}
						}
						if (false)
						{
							continue;
						}
						((sbyte*)ptr)[21] = (sbyte)(((((int*)ptr)[1] == SourceIndex) ? 1 : 0) & (int)((sbyte*)ptr)[18]);
						if (((bool*)ptr)[21])
						{
							global::_0018._007E_0084((buControl)global::_000E._007E_0010(Controls, *(int*)ptr), image);
							((sbyte*)ptr)[22] = ((global::_0013._007E_001D(global::_0010._007E_0015(Name)) > 0) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[22])
							{
								global::_0019._007E_0088((buControl)global::_000E._007E_0010(Controls, *(int*)ptr), Name);
							}
						}
					}
					else
					{
						((sbyte*)ptr)[23] = ((global::_000E._007E_0010(Controls, *(int*)ptr) is Button) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[23])
						{
							((int*)ptr)[2] = global::_0011._001A(global::_0010._007E_0012(global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr))));
							((sbyte*)ptr)[24] = ((((int*)ptr)[2] == SourceIndex) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[24])
							{
								global::_0018._007E_0086((Button)global::_000E._007E_0010(Controls, *(int*)ptr), image);
								((sbyte*)ptr)[25] = ((global::_0013._007E_001D(global::_0010._007E_0015(Name)) > 0) ? ((sbyte)1) : ((sbyte)0));
								if (((bool*)ptr)[25])
								{
									global::_0019._007E_0088((Button)global::_000E._007E_0010(Controls, *(int*)ptr), Name);
								}
							}
						}
						else
						{
							((sbyte*)ptr)[26] = ((global::_000E._007E_0010(Controls, *(int*)ptr) is PictureBox) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[26])
							{
								((int*)ptr)[3] = global::_0011._001A(global::_0010._007E_0012(global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr))));
								((sbyte*)ptr)[27] = ((((int*)ptr)[3] == SourceIndex) ? ((sbyte)1) : ((sbyte)0));
								if (((bool*)ptr)[27])
								{
									global::_0018._007E_0087((PictureBox)global::_000E._007E_0010(Controls, *(int*)ptr), image);
								}
							}
						}
					}
				}
				(*(int*)ptr)++;
			}
		}
		catch (Exception ex)
		{
			string text = global::_0003._0005(_0090(107396061), SourceIndex.ToString());
			global::_0004._0006(text, _0090(107396031), global::_0010._007E_0014(global::_0016._0082()));
			global::_0017._0083(ex, global::_0010._007E_0014(global::_0016._0082()), true, text);
		}
	}

	public unsafe void SetStateOfControlAsImage(Control.ControlCollection Controls, int Index, bool State, Image image)
	{
		void* ptr = stackalloc byte[27];
		try
		{
			*(int*)ptr = 1;
			while (true)
			{
				((sbyte*)ptr)[26] = ((*(int*)ptr <= global::_0013._007E_001E(Controls) - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[26] == 0)
				{
					break;
				}
				((sbyte*)ptr)[16] = ((global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr)) != null) ? ((sbyte)1) : ((sbyte)0));
				if (7u != 0)
				{
					if (((bool*)ptr)[16])
					{
						((sbyte*)ptr)[17] = ((global::_000E._007E_0010(Controls, *(int*)ptr) is buControl) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[17])
						{
							((int*)ptr)[1] = global::_0011._001A(global::_0010._007E_0012(global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr))));
							((sbyte*)ptr)[18] = 1;
							((sbyte*)ptr)[19] = ((global::_0013._007E_001D(global::_0010._007E_0013(global::_0012._007E_001C((buControl)global::_000E._007E_0010(Controls, *(int*)ptr)))) > 0) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[19])
							{
								((sbyte*)ptr)[18] = 0;
								((sbyte*)ptr)[20] = ((global::_0014._001F(global::_0010._007E_0013(global::_0012._007E_001C((buControl)global::_000E._007E_0010(Controls, *(int*)ptr))), _0090(107396103)) | global::_0014._001F(global::_0010._007E_0013(global::_0012._007E_001C((buControl)global::_000E._007E_0010(Controls, *(int*)ptr))), _0090(107396098))) ? ((sbyte)1) : ((sbyte)0));
								if (((bool*)ptr)[20])
								{
									((sbyte*)ptr)[18] = 1;
								}
							}
							if (0 == 0)
							{
								((sbyte*)ptr)[21] = (sbyte)(((((int*)ptr)[1] == Index) ? 1 : 0) & (int)((sbyte*)ptr)[18]);
								if (((bool*)ptr)[21])
								{
									global::_0018._007E_0084((buControl)global::_000E._007E_0010(Controls, *(int*)ptr), image);
								}
								goto IL_02eb;
							}
						}
						else
						{
							((sbyte*)ptr)[22] = ((global::_000E._007E_0010(Controls, *(int*)ptr) is Button) ? ((sbyte)1) : ((sbyte)0));
							if (((sbyte*)ptr)[22] == 0)
							{
								((sbyte*)ptr)[24] = ((global::_000E._007E_0010(Controls, *(int*)ptr) is PictureBox) ? ((sbyte)1) : ((sbyte)0));
								if (((sbyte*)ptr)[24] == 0)
								{
									goto IL_02eb;
								}
								goto IL_0284;
							}
						}
						((int*)ptr)[2] = global::_0011._001A(global::_0010._007E_0012(global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr))));
						((sbyte*)ptr)[23] = ((((int*)ptr)[2] == Index) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[23])
						{
							global::_0018._007E_0086((Button)global::_000E._007E_0010(Controls, *(int*)ptr), image);
						}
					}
					goto IL_02eb;
				}
				goto IL_0284;
				IL_02eb:
				(*(int*)ptr)++;
				continue;
				IL_0284:
				((int*)ptr)[3] = global::_0011._001A(global::_0010._007E_0012(global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr))));
				((sbyte*)ptr)[25] = ((((int*)ptr)[3] == Index) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[25])
				{
					global::_0018._007E_0087((PictureBox)global::_000E._007E_0010(Controls, *(int*)ptr), image);
				}
				goto IL_02eb;
			}
		}
		catch (Exception ex)
		{
			string text = global::_0006._0008(_0090(107396061), Index.ToString(), _0090(107396048), State.ToString());
			global::_0004._0006(text, _0090(107396031), global::_0010._007E_0014(global::_0016._0082()));
			global::_0017._0083(ex, global::_0010._007E_0014(global::_0016._0082()), true, text);
			if (-1 == 0)
			{
			}
		}
	}

	public unsafe void SetStateOfControlAsColor(Control.ControlCollection Controls, int Index, bool State, Color onColor, Color offColor)
	{
		void* ptr = stackalloc byte[23];
		try
		{
			*(int*)ptr = 1;
			while (true)
			{
				((sbyte*)ptr)[22] = ((*(int*)ptr <= global::_0013._007E_001E(Controls) - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[22] == 0)
				{
					break;
				}
				((sbyte*)ptr)[12] = ((global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr)) != null) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[12])
				{
					((sbyte*)ptr)[13] = ((global::_000E._007E_0010(Controls, *(int*)ptr) is buControl) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[13])
					{
						((int*)ptr)[1] = global::_0011._001A(global::_0010._007E_0012(global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr))));
						((sbyte*)ptr)[14] = 1;
						((sbyte*)ptr)[15] = ((global::_0013._007E_001D(global::_0010._007E_0013(global::_0012._007E_001C((buControl)global::_000E._007E_0010(Controls, *(int*)ptr)))) > 0) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[15])
						{
							((sbyte*)ptr)[14] = 0;
							((sbyte*)ptr)[16] = ((global::_0014._001F(global::_0010._007E_0013(global::_0012._007E_001C((buControl)global::_000E._007E_0010(Controls, *(int*)ptr))), _0090(107396103)) | global::_0014._001F(global::_0010._007E_0013(global::_0012._007E_001C((buControl)global::_000E._007E_0010(Controls, *(int*)ptr))), _0090(107396098))) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[16])
							{
								((sbyte*)ptr)[14] = 1;
							}
						}
						((sbyte*)ptr)[17] = (sbyte)(((((int*)ptr)[1] == Index) ? 1 : 0) & (int)((sbyte*)ptr)[14]);
						if (((bool*)ptr)[17])
						{
							((sbyte*)ptr)[18] = (State ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[18])
							{
								global::_001B._007E_008C(global::_001A._007E_008B((buControl)global::_000E._007E_0010(Controls, *(int*)ptr)), onColor);
							}
							else
							{
								global::_001B._007E_008C(global::_001A._007E_008B((buControl)global::_000E._007E_0010(Controls, *(int*)ptr)), offColor);
							}
						}
					}
					else
					{
						((sbyte*)ptr)[19] = ((global::_000E._007E_0010(Controls, *(int*)ptr) != null) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[19])
						{
							((int*)ptr)[2] = global::_0011._001A(global::_0010._007E_0012(global::_000F._007E_0011(global::_000E._007E_0010(Controls, *(int*)ptr))));
							((sbyte*)ptr)[20] = ((((int*)ptr)[2] == Index) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[20])
							{
								((sbyte*)ptr)[21] = (State ? ((sbyte)1) : ((sbyte)0));
								if (((bool*)ptr)[21])
								{
									global::_001B._007E_008D(global::_000E._007E_0010(Controls, *(int*)ptr), onColor);
								}
								else
								{
									global::_001B._007E_008D(global::_000E._007E_0010(Controls, *(int*)ptr), offColor);
								}
							}
						}
					}
				}
				(*(int*)ptr)++;
			}
		}
		catch (Exception ex)
		{
			string text = global::_0006._0008(_0090(107396061), Index.ToString(), _0090(107396048), State.ToString());
			global::_0004._0006(text, _0090(107396031), global::_0010._007E_0014(global::_0016._0082()));
			global::_0017._0083(ex, global::_0010._007E_0014(global::_0016._0082()), true, text);
		}
	}

	public unsafe void CreateAxesSettingFile(List<CodesysAxesData> AppAxis, ref string Codes)
	{
		void* ptr = stackalloc byte[5];
		Codes = _0090(107397099);
		while (true)
		{
			if (0 == 0)
			{
				*(int*)ptr = 0;
				goto IL_01b4;
			}
			goto IL_01d9;
			IL_01b4:
			if (false)
			{
				goto IL_018a;
			}
			((sbyte*)ptr)[4] = ((*(int*)ptr <= AppAxis.Count - 1) ? ((sbyte)1) : ((sbyte)0));
			if (false)
			{
				continue;
			}
			if (((sbyte*)ptr)[4] == 0)
			{
				goto IL_01d9;
			}
			goto IL_01fc;
			IL_01d9:
			if (0 == 0)
			{
				break;
			}
			goto IL_00cc;
			IL_00cc:
			Codes = Codes + AppAxis[*(int*)ptr].AxisPar.Homings.ToFileString(1) + Environment.NewLine;
			goto IL_00f2;
			IL_00f2:
			Codes = Codes + AppAxis[*(int*)ptr].AxisPar.Cnc.ToFileString(1) + Environment.NewLine;
			Codes = Codes + AppAxis[*(int*)ptr].AxisPar.Gear.ToFileString(1) + Environment.NewLine;
			Codes = Codes + AppAxis[*(int*)ptr].AxisPar.Base.ToFileString(1) + Environment.NewLine;
			Codes = Codes + AppAxis[*(int*)ptr].AxisPar.Test.ToFileString(1) + Environment.NewLine;
			goto IL_018a;
			IL_018a:
			if (false)
			{
				goto IL_01fc;
			}
			Codes = Codes + _0090(107396045) + Environment.NewLine;
			(*(int*)ptr)++;
			goto IL_01b4;
			IL_01fc:
			Codes = Codes + _0090(107396022) + Environment.NewLine;
			Codes = Codes + AppAxis[*(int*)ptr].AxisPar.Sets.ToFileString(1) + Environment.NewLine;
			Codes = Codes + AppAxis[*(int*)ptr].AxisPar.Jogs.ToFileString(1) + Environment.NewLine;
			if (7u != 0)
			{
				Codes = Codes + AppAxis[*(int*)ptr].AxisPar.Moves.ToFileString(1) + Environment.NewLine;
				goto IL_00cc;
			}
			goto IL_00f2;
		}
	}

	public DialogResult ShowCodesysSettings(ref CodesysMachine cMachine)
	{
		string text = _0090(107396032);
		try
		{
			F_SettingsTreeView f_SettingsTreeView = new F_SettingsTreeView();
			f_SettingsTreeView.CaptionHeader.Clear();
			f_SettingsTreeView.Classes = new List<object>();
			f_SettingsTreeView.Classes.Add(new PlcDeviceData(cMachine.PLCSettings));
			f_SettingsTreeView.Classes.Add(new setMotionProgramVar(cMachine.ProgramSettings));
			f_SettingsTreeView.Classes.Add(new MachineSettings(cMachine.MachineSetting));
			f_SettingsTreeView.Classes.Add(new CodesysSystemSets(cMachine.varSystem));
			f_SettingsTreeView.Classes.Add(new HandWheelSettings(cMachine.varHandWheel));
			f_SettingsTreeView.Classes.Add(new JogSettings(cMachine.varJog));
			global::_001C._007E_008E(f_SettingsTreeView);
			global::_001D._007E_0093(f_SettingsTreeView, FormStartPosition.CenterParent);
			global::_001E._007E_0094(f_SettingsTreeView);
			if (f_SettingsTreeView.Result == DialogResult.OK)
			{
				cMachine.PLCSettings = new PlcDeviceData((PlcDeviceData)f_SettingsTreeView.Classes[0]);
				cMachine.ProgramSettings = new setMotionProgramVar((setMotionProgramVar)f_SettingsTreeView.Classes[1]);
				cMachine.MachineSetting = new MachineSettings((MachineSettings)f_SettingsTreeView.Classes[2]);
				cMachine.varSystem = new CodesysSystemSets((CodesysSystemSets)f_SettingsTreeView.Classes[3]);
				cMachine.varHandWheel = new HandWheelSettings((HandWheelSettings)f_SettingsTreeView.Classes[4]);
				cMachine.varJog = new JogSettings((JogSettings)f_SettingsTreeView.Classes[5]);
				global::_001F._0095(_0001, text, _0090(107396003), _0090(107395966), 0.0, 0.0, true);
			}
			return f_SettingsTreeView.Result;
		}
		catch (Exception ex)
		{
			global::_001F._0095(_0001, text, _0090(107395421), _0090(107397099), 0.0, 0.0, true);
			global::_0017._0083(ex, text, true, _0090(107397099));
			return DialogResult.Cancel;
		}
	}

	public unsafe DialogResult ShowAxesSettings(ref CodesysMachine cMachine)
	{
		void* ptr = stackalloc byte[16];
		string text = _0090(107395412);
		try
		{
			F_SettingsTreeView f_SettingsTreeView = new F_SettingsTreeView();
			f_SettingsTreeView.CaptionHeader.Clear();
			f_SettingsTreeView.Classes = new List<object>();
			*(int*)ptr = 0;
			while (true)
			{
				((sbyte*)ptr)[13] = ((*(int*)ptr <= cMachine.AppAxis.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[13] == 0)
				{
					break;
				}
				string text2 = global::_0010._007E_0015(cMachine.AppAxis[*(int*)ptr].AxisPar.Base.baseName);
				((sbyte*)ptr)[12] = ((global::_0013._007E_001D(text2) <= 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[12])
				{
					((int*)ptr)[1] = *(int*)ptr + 1;
					text2 = global::_0003._0005(((int*)((byte*)ptr + 4))->ToString(), _0090(107395387));
				}
				f_SettingsTreeView.CaptionHeader.Add(global::_0007._000E(new string[5]
				{
					text2,
					_0090(107395382),
					AppLanguage.CadCamDynamic[266],
					_0090(107397159),
					AppLanguage.CadCamDynamic[105]
				}));
				CodesysAxis codesysAxis = new CodesysAxis();
				codesysAxis = new CodesysAxis(cMachine.AppAxis[*(int*)ptr].AxisPar);
				f_SettingsTreeView.Classes.Add(codesysAxis);
				(*(int*)ptr)++;
			}
			f_SettingsTreeView.CaptionHeader.Add(global::_0003._0005(_0090(107395377), AppLanguage.CadCamDynamic[105]));
			f_SettingsTreeView.Classes.Add(new CodesysCNCSets(cMachine.varCNC));
			global::_001C._007E_008E(f_SettingsTreeView);
			global::_001D._007E_0093(f_SettingsTreeView, FormStartPosition.CenterParent);
			global::_001E._007E_0094(f_SettingsTreeView);
			((sbyte*)ptr)[14] = ((f_SettingsTreeView.Result == DialogResult.OK) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[14])
			{
				((int*)ptr)[2] = 0;
				while (true)
				{
					((sbyte*)ptr)[15] = ((((int*)ptr)[2] <= cMachine.AppAxis.Count - 1) ? ((sbyte)1) : ((sbyte)0));
					if (((sbyte*)ptr)[15] == 0)
					{
						break;
					}
					cMachine.AppAxis[((int*)ptr)[2]].AxisPar = new CodesysAxis((CodesysAxis)f_SettingsTreeView.Classes[((int*)ptr)[2]]);
					((int*)ptr)[2]++;
				}
				cMachine.varCNC = new CodesysCNCSets((CodesysCNCSets)f_SettingsTreeView.Classes[f_SettingsTreeView.Classes.Count - 1]);
				global::_001F._0095(_0001, text, _0090(107396003), _0090(107395400), 0.0, 0.0, true);
			}
			return f_SettingsTreeView.Result;
		}
		catch (Exception ex)
		{
			global::_001F._0095(_0001, text, _0090(107395421), _0090(107397099), 0.0, 0.0, true);
			global::_0017._0083(ex, text, true, _0090(107397099));
			return DialogResult.Cancel;
		}
	}

	public unsafe void MarbleSystemBoolConversion(bool[] SystemBoolBlock, ref CodesysMachine Mach)
	{
		void* ptr = stackalloc byte[38];
		((sbyte*)ptr)[4] = ((SystemBoolBlock != null) ? ((sbyte)1) : ((sbyte)0));
		if (((sbyte*)ptr)[4] == 0)
		{
			return;
		}
		*(int*)ptr = 0;
		while (true)
		{
			((sbyte*)ptr)[37] = ((*(int*)ptr <= SystemBoolBlock.Length - 1) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[37])
			{
				((sbyte*)ptr)[5] = ((*(int*)ptr == 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[5])
				{
					Mach.runSystem.Alarm = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[6] = ((*(int*)ptr == 1) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[6])
				{
					Mach.runSystem.Run = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[7] = ((*(int*)ptr == 2) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[7])
				{
					Mach.runSystem.Pause = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[8] = ((*(int*)ptr == 3) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[8])
				{
					Mach.runSystem.HomingDone = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[9] = ((*(int*)ptr == 4) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[9])
				{
					Mach.runSystem.Enabled = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[10] = ((*(int*)ptr == 5) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[10])
				{
					Mach.runSystem.WarningOccured = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[11] = ((*(int*)ptr == 6) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[11])
				{
					Mach.runSystem.GantryOk = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[12] = ((*(int*)ptr == 7) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[12])
				{
					Mach.runSystem.FileLoaded = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[13] = ((*(int*)ptr == 8) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[13])
				{
					Mach.runSystem.Water = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[14] = ((*(int*)ptr == 9) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[14])
				{
					Mach.runSystem.Laser = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[15] = ((*(int*)ptr == 10) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[15])
				{
					Mach.runSystem.Spindle = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[16] = ((*(int*)ptr == 11) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[16])
				{
					Mach.runSystem.Saw = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[17] = ((*(int*)ptr == 12) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[17])
				{
					Mach.runSystem.MAcOk = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[18] = ((*(int*)ptr == 13) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[18])
				{
					Mach.runSystem.InitDone = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[19] = ((*(int*)ptr == 14) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[19])
				{
					Mach.runSystem.Auto = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[20] = ((*(int*)ptr == 15) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[20])
				{
					Mach.runSystem.Manuel = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[21] = ((*(int*)ptr == 16) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[21])
				{
					Mach.runSystem.Pens = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[22] = ((*(int*)ptr == 17) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[22])
				{
					Mach.runSystem.Move = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[23] = ((*(int*)ptr == 18) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[23])
				{
					Mach.runSystem.RtcpActivated = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[24] = ((*(int*)ptr == 19) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[24])
				{
					Mach.runSystem.Calculated = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[25] = ((*(int*)ptr == 20) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[25])
				{
					Mach.runSystem.ToolUpdate = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[26] = ((*(int*)ptr == 21) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[26])
				{
					Mach.runSystem.SawUpdate = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[27] = ((*(int*)ptr == 22) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[27])
				{
					Mach.runSystem.PartZero = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[28] = ((*(int*)ptr == 23) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[28])
				{
					Mach.runSystem.ParameterUpdated = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[29] = ((*(int*)ptr == 24) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[29])
				{
					Mach.runSystem.HandWheelActivated = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[30] = ((*(int*)ptr == 25) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[30])
				{
					Mach.runSystem.Finished = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[31] = ((*(int*)ptr == 26) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[31])
				{
					Mach.runSystem.SimulatedAxes = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[32] = ((*(int*)ptr == 27) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[32])
				{
					Mach.runSystem.SimulatedIO = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[33] = ((*(int*)ptr == 28) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[33])
				{
					Mach.runSystem.CameraReady = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[34] = ((*(int*)ptr == 29) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[34])
				{
					Mach.runSystem.WagonUp = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[35] = ((*(int*)ptr == 30) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[35])
				{
					Mach.runSystem.SemiAuto = SystemBoolBlock[*(int*)ptr];
				}
				((sbyte*)ptr)[36] = ((*(int*)ptr == 31) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[36])
				{
					Mach.runSystem.CruiseControl = SystemBoolBlock[*(int*)ptr];
				}
				(*(int*)ptr)++;
				continue;
			}
			break;
		}
	}

	public unsafe void SetBBB(int Year, int Month, int Day)
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				writeBOOLVar(CodesysVariableBaseType.Persistent, Val: true, _0090(107395371));
				writeDINTVar(CodesysVariableBaseType.Persistent, Year, _0090(107395338));
				writeDINTVar(CodesysVariableBaseType.Persistent, Month, _0090(107395297));
				do
				{
					writeDINTVar(CodesysVariableBaseType.Persistent, Day, _0090(107395224));
					writeDINTVar(CodesysVariableBaseType.Global, 10, _0090(107395187));
				}
				while (false);
				global::_007F._0096(_0090(107395694));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395694), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void ResetBBB()
	{
		byte* num = stackalloc byte[5];
		void* ptr;
		if (4u != 0)
		{
			ptr = num;
		}
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				writeBOOLVar(CodesysVariableBaseType.Persistent, Val: false, _0090(107395371));
				writeDINTVar(CodesysVariableBaseType.Global, 10, _0090(107395187));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395685), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe string CheckBBB()
	{
		void* ptr;
		do
		{
			ptr = stackalloc byte[27];
		}
		while (false);
		try
		{
			*(int*)ptr = 0;
			((int*)ptr)[1] = 0;
			string text;
			string text2;
			string text3;
			while (true)
			{
				((int*)ptr)[2] = 0;
				((int*)ptr)[3] = 0;
				((sbyte*)ptr)[20] = 0;
				((sbyte*)ptr)[21] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
				if (false)
				{
					break;
				}
				if (((bool*)ptr)[21])
				{
					return _0090(107397099);
				}
				while (0 == 0)
				{
					readDINTVar(CodesysVariableBaseType.Persistent, _0090(107395338), ref *(int*)((byte*)ptr + 4));
					readDINTVar(CodesysVariableBaseType.Persistent, _0090(107395297), ref *(int*)((byte*)ptr + 8));
					readDINTVar(CodesysVariableBaseType.Persistent, _0090(107395224), ref *(int*)((byte*)ptr + 12));
					readBOOLVar(CodesysVariableBaseType.Persistent, _0090(107395371), ref *(bool*)((byte*)ptr + 20));
					while (true)
					{
						global::_007F._0096(_0090(107395640));
						(*(int*)ptr)++;
						((sbyte*)ptr)[22] = ((((int*)ptr)[1] <= 1) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[22])
						{
							((sbyte*)ptr)[23] = ((*(int*)ptr <= 3) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[23])
							{
								break;
							}
						}
						((int*)ptr)[1] = ((int*)ptr)[1] - 2000 + 5;
						text = ((int*)((byte*)ptr + 8))->ToString();
						text2 = ((int*)((byte*)ptr + 12))->ToString();
						((sbyte*)ptr)[24] = ((global::_0013._007E_001D(text) == 1) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[24])
						{
							text = global::_0003._0005(_0090(107395659), text);
							if (false)
							{
								continue;
							}
						}
						goto IL_0195;
					}
				}
				continue;
				IL_0195:
				((sbyte*)ptr)[25] = ((global::_0013._007E_001D(text2) == 1) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[25])
				{
					text2 = global::_0003._0005(_0090(107395659), text2);
				}
				text3 = _0090(107395654);
				break;
			}
			((sbyte*)ptr)[26] = ((((sbyte*)ptr)[20] == 0) ? ((sbyte)1) : ((sbyte)0));
			text3 = ((((sbyte*)ptr)[26] == 0) ? _0090(107395649) : _0090(107395654));
			return global::_0007._000E(new string[5]
			{
				_0090(107395612),
				((int*)((byte*)ptr + 4))->ToString(),
				text,
				text2,
				text3
			});
		}
		catch (Exception ee)
		{
			((int*)ptr)[4] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395640), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[4], ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			return _0090(107397099);
		}
	}

	public unsafe string RemainBBB()
	{
		void* ptr = stackalloc byte[9];
		try
		{
			((sbyte*)ptr)[8] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[8] == 0)
			{
				*(int*)ptr = 0;
				readDINTVar(CodesysVariableBaseType.Global, _0090(107395603), ref *(int*)ptr);
				return ((int*)ptr)->ToString();
			}
			string result = _0090(107397099);
			if (true)
			{
				return result;
			}
		}
		catch (Exception ee)
		{
			CalculationErrorEventArg calculationErrorEventArg;
			if (0 == 0)
			{
				((int*)ptr)[1] = 0;
				string message = _0090(107397099);
				calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395598), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[1], ee);
			}
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			return _0090(107397099);
		}
		string result2;
		return result2;
	}

	public unsafe void DebugCommands(string Command, ref string Result)
	{
		void* ptr = stackalloc byte[26];
		try
		{
			((sbyte*)ptr)[20] = (global::_0014._001F(global::_0010._007E_0016(Command), _0090(107395585)) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[20])
			{
				ResetBBB();
				Result = _0090(107396003);
				return;
			}
			((sbyte*)ptr)[21] = (global::_0014._001F(global::_0010._007E_0016(Command), _0090(107395540)) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[21])
			{
				string text = CheckBBB();
				Result = global::_0003._0005(text, _0090(107395559));
				return;
			}
			((sbyte*)ptr)[22] = (global::_0014._001F(global::_0010._007E_0016(Command), _0090(107395518)) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[22])
			{
				string text2 = RemainBBB();
				Result = global::_0003._0005(text2, _0090(107395559));
				return;
			}
			((sbyte*)ptr)[23] = ((global::_0080._007E_0098(global::_0010._007E_0016(Command), _0090(107395505)) >= 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[23])
			{
				string text3 = global::_0002._0004(Command, _0090(107395524), _0090(107395487));
				string[] array = global::_0081._007E_0099(text3, new char[1] { '-' });
				((sbyte*)ptr)[24] = ((array != null) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[24])
				{
					((sbyte*)ptr)[25] = ((array.Length == 3) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[25])
					{
						*(int*)ptr = 2000;
						((int*)ptr)[1] = 1;
						((int*)ptr)[2] = 1;
						global::_0082._009A(array[0], ref *(int*)ptr);
						global::_0082._009A(array[1], ref *(int*)((byte*)ptr + 4));
						global::_0082._009A(array[2], ref *(int*)((byte*)ptr + 8));
						SetBBB(*(int*)ptr, ((int*)ptr)[1], ((int*)ptr)[2]);
						Result = _0090(107396003);
					}
					else
					{
						global::_0003 obj = global::_0003._0005;
						string text4 = _0090(107395482);
						((int*)ptr)[3] = array.Length;
						Result = obj(text4, ((int*)((byte*)ptr + 12))->ToString());
					}
				}
				else
				{
					Result = _0090(107395421);
				}
			}
			else
			{
				Result = _0090(107395421);
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[4] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395493), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[4], ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe string MacGetAddress()
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				string Val = _0090(107397099);
				readSTRINGVar(CodesysVariableBaseType.Global, _0090(107395440), ref Val);
				return Val;
			}
			return _0090(107397099);
		}
		catch (Exception ee)
		{
			string message;
			if (5u != 0)
			{
				*(int*)ptr = 0;
				message = _0090(107397099);
			}
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107394927), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			return _0090(107397099);
		}
	}

	public unsafe void ReadWatchVariables(ref List<WatchItem> WatchList)
	{
		byte* num = stackalloc byte[36];
		void* ptr = default(void*);
		if (0 == 0)
		{
			ptr = num;
		}
		try
		{
			while (true)
			{
				((sbyte*)ptr)[20] = (AppBool.Connected ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[20] == 0)
				{
					break;
				}
				((int*)ptr)[2] = 0;
				while (true)
				{
					((sbyte*)ptr)[35] = ((((int*)ptr)[2] <= WatchList.Count - 1) ? ((sbyte)1) : ((sbyte)0));
					if (((sbyte*)ptr)[35] == 0)
					{
						return;
					}
					((sbyte*)ptr)[21] = (((WatchList[((int*)ptr)[2]].Name.Length > 2) & (WatchList[((int*)ptr)[2]].VarType == VariableType.Bool)) ? ((sbyte)1) : ((sbyte)0));
					if (7u != 0)
					{
						if (((bool*)ptr)[21])
						{
							((sbyte*)ptr)[22] = 0;
							string text = readBOOLVar(CodesysVariableBaseType.None, WatchList[((int*)ptr)[2]].Name, ref *(bool*)((byte*)ptr + 22));
							((sbyte*)ptr)[23] = ((text == _0090(107396003)) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[23])
							{
								WatchList[((int*)ptr)[2]].Status = _0090(107396003);
								WatchList[((int*)ptr)[2]].CommStatus = true;
							}
							else
							{
								WatchList[((int*)ptr)[2]].Status = _0090(107395421);
								WatchList[((int*)ptr)[2]].CommStatus = false;
							}
							((sbyte*)ptr)[24] = ((sbyte*)ptr)[22];
							if (((bool*)ptr)[24])
							{
								WatchList[((int*)ptr)[2]].Value = 1.0;
							}
							else
							{
								WatchList[((int*)ptr)[2]].Value = 0.0;
							}
							((sbyte*)ptr)[25] = ((WatchList[((int*)ptr)[2]].Value > WatchList[((int*)ptr)[2]].MaxValue) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[25])
							{
								WatchList[((int*)ptr)[2]].MaxValue = WatchList[((int*)ptr)[2]].Value;
							}
							((sbyte*)ptr)[26] = ((WatchList[((int*)ptr)[2]].Value < WatchList[((int*)ptr)[2]].MinValue) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[26])
							{
								WatchList[((int*)ptr)[2]].MinValue = WatchList[((int*)ptr)[2]].Value;
							}
							WatchList[((int*)ptr)[2]].ValueString = ((bool*)((byte*)ptr + 22))->ToString();
							if (2 == 0)
							{
								goto IL_03c7;
							}
						}
						((sbyte*)ptr)[27] = (((WatchList[((int*)ptr)[2]].Name.Length > 2) & (WatchList[((int*)ptr)[2]].VarType == VariableType.DINT)) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[27])
						{
							((int*)ptr)[3] = 0;
							string text2 = readDINTVar(CodesysVariableBaseType.None, WatchList[((int*)ptr)[2]].Name, ref *(int*)((byte*)ptr + 12));
							((sbyte*)ptr)[28] = ((text2 == _0090(107396003)) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[28])
							{
								WatchList[((int*)ptr)[2]].Status = _0090(107396003);
								WatchList[((int*)ptr)[2]].CommStatus = true;
							}
							else
							{
								WatchList[((int*)ptr)[2]].Status = _0090(107395421);
								WatchList[((int*)ptr)[2]].CommStatus = false;
							}
							WatchList[((int*)ptr)[2]].ValueString = ((int*)((byte*)ptr + 12))->ToString();
							WatchList[((int*)ptr)[2]].Value = ((int*)ptr)[3];
							((sbyte*)ptr)[29] = (((double)((int*)ptr)[3] > WatchList[((int*)ptr)[2]].MaxValue) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[29])
							{
								WatchList[((int*)ptr)[2]].MaxValue = ((int*)ptr)[3];
							}
							((sbyte*)ptr)[30] = (((double)((int*)ptr)[3] < WatchList[((int*)ptr)[2]].MinValue) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[30])
							{
								WatchList[((int*)ptr)[2]].MinValue = ((int*)ptr)[3];
							}
						}
						goto IL_03c7;
					}
					goto IL_0447;
					IL_03c7:
					((sbyte*)ptr)[31] = (((WatchList[((int*)ptr)[2]].Name.Length > 2) & (WatchList[((int*)ptr)[2]].VarType == VariableType.LREAL)) ? ((sbyte)1) : ((sbyte)0));
					if (((sbyte*)ptr)[31] == 0)
					{
						goto IL_0545;
					}
					*(double*)ptr = 0.0;
					string text3 = readLREALVar(CodesysVariableBaseType.None, WatchList[((int*)ptr)[2]].Name, ref *(double*)ptr);
					if (2 == 0)
					{
						break;
					}
					((sbyte*)ptr)[32] = ((text3 == _0090(107396003)) ? ((sbyte)1) : ((sbyte)0));
					goto IL_0447;
					IL_0447:
					if (((bool*)ptr)[32])
					{
						WatchList[((int*)ptr)[2]].Status = _0090(107396003);
						WatchList[((int*)ptr)[2]].CommStatus = true;
					}
					else
					{
						WatchList[((int*)ptr)[2]].Status = _0090(107395421);
						WatchList[((int*)ptr)[2]].CommStatus = false;
					}
					WatchList[((int*)ptr)[2]].Value = *(double*)ptr;
					WatchList[((int*)ptr)[2]].ValueString = ((double*)ptr)->ToString();
					((sbyte*)ptr)[33] = ((*(double*)ptr > WatchList[((int*)ptr)[2]].MaxValue) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[33])
					{
						WatchList[((int*)ptr)[2]].MaxValue = *(double*)ptr;
					}
					((sbyte*)ptr)[34] = ((*(double*)ptr < WatchList[((int*)ptr)[2]].MinValue) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[34])
					{
						WatchList[((int*)ptr)[2]].MinValue = *(double*)ptr;
					}
					goto IL_0545;
					IL_0545:
					((int*)ptr)[2]++;
				}
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[4] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107394874), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[4], ee);
			buException.throwException(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void AxisCalibration(double SetPosition, double MeasuredPosition, bool isUnit, ref double calcUnit, ref double calcGearBox)
	{
		while (true)
		{
			void* ptr = stackalloc byte[18];
			if (false)
			{
				goto IL_0083;
			}
			((sbyte*)ptr)[16] = ((SetPosition != 0.0 && MeasuredPosition != 0.0) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[16] == 0)
			{
				goto IL_009a;
			}
			goto IL_00bc;
			IL_00bc:
			((sbyte*)ptr)[17] = (isUnit ? ((sbyte)1) : ((sbyte)0));
			if (3 == 0 || ((bool*)ptr)[17])
			{
				*(double*)ptr = SetPosition / MeasuredPosition;
				calcUnit /= *(double*)ptr;
				goto IL_0077;
			}
			goto IL_0083;
			IL_0083:
			((double*)ptr)[1] = MeasuredPosition / SetPosition;
			goto IL_008a;
			IL_008a:
			calcGearBox *= ((double*)ptr)[1];
			goto IL_0096;
			IL_0096:
			if (false)
			{
				goto IL_0077;
			}
			goto IL_009a;
			IL_009a:
			if (true)
			{
				break;
			}
			goto IL_008a;
			IL_0077:
			if (6 == 0)
			{
				goto IL_00bc;
			}
			if (7 == 0)
			{
				continue;
			}
			goto IL_0096;
		}
	}

	public unsafe string WarningDecode(AppWarning warning)
	{
		void* ptr = stackalloc byte[9];
		string text = _0090(107397099);
		*(bool*)ptr = global::_0013._007E_001D(global::_0010._007E_0015(warning.Axis)) > 0;
		if (*(bool*)ptr)
		{
			text = global::_0006._0008(text, _0090(107394881), warning.Axis, _0090(107394844));
		}
		((sbyte*)ptr)[1] = ((global::_0013._007E_001D(global::_0010._007E_0015(warning.Text)) > 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[1])
		{
			((sbyte*)ptr)[2] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			text = ((((sbyte*)ptr)[2] == 0) ? warning.Text : global::_0002._0003(text, _0090(107397159), warning.Text));
		}
		((sbyte*)ptr)[3] = ((warning.ID != 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[3])
		{
			((sbyte*)ptr)[4] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			text = ((((sbyte*)ptr)[4] == 0) ? global::_0003._0005(_0090(107394858), warning.ID.ToString()) : global::_0002._0003(text, _0090(107394839), warning.ID.ToString()));
		}
		((sbyte*)ptr)[5] = ((warning.Option != 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[5])
		{
			((sbyte*)ptr)[6] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			text = ((((sbyte*)ptr)[6] == 0) ? global::_0003._0005(_0090(107394804), global::_0010._007E_0012(warning.Aux)) : global::_0002._0003(text, _0090(107394849), warning.Option.ToString()));
		}
		((sbyte*)ptr)[7] = ((global::_0013._007E_001D(global::_0010._007E_0015(warning.Aux)) > 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[7])
		{
			((sbyte*)ptr)[8] = ((global::_0013._007E_001D(text) > 0) ? ((sbyte)1) : ((sbyte)0));
			text = ((((sbyte*)ptr)[8] == 0) ? global::_0003._0005(_0090(107394782), warning.Aux) : global::_0002._0003(text, _0090(107394827), warning.Aux));
		}
		return text;
	}

	public unsafe string CoordinateReadModeToString(CoordinateShowMode Mode)
	{
		void* ptr = stackalloc byte[6];
		string result = default(string);
		while (true)
		{
			*(bool*)ptr = Mode == CoordinateShowMode.Machine;
			if (0 == 0)
			{
				if (*(bool*)ptr)
				{
					result = buLangTranslate.preDef.Machine;
					break;
				}
				((sbyte*)ptr)[1] = ((Mode == CoordinateShowMode.Part) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[1] == 0)
				{
					((sbyte*)ptr)[2] = ((Mode == CoordinateShowMode.FollowingError) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[2])
					{
						goto IL_0079;
					}
					if (7u != 0)
					{
						((sbyte*)ptr)[3] = ((Mode == CoordinateShowMode.DistanceToGo) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[3] || 2 == 0)
						{
							result = buLangTranslate.preDef.ToGo;
							break;
						}
						((sbyte*)ptr)[4] = ((Mode == CoordinateShowMode.Current) ? ((sbyte)1) : ((sbyte)0));
						goto IL_00b3;
					}
				}
				result = buLangTranslate.preDef.Part;
				break;
			}
			goto IL_00b3;
			IL_0079:
			result = buLangTranslate.preDef.FollowingError;
			break;
			IL_00b3:
			while (uint.MaxValue != 0)
			{
				if (((sbyte*)ptr)[4] == 0)
				{
					((sbyte*)ptr)[5] = ((Mode == CoordinateShowMode.Speed) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[5])
					{
						if (5u != 0)
						{
							result = buLangTranslate.preDef.Speed;
							if (3u != 0)
							{
								break;
							}
							continue;
						}
						goto IL_0079;
					}
					result = buLangTranslate.preDef.Unknown;
					break;
				}
				goto IL_00bc;
			}
			break;
			IL_00bc:
			if (1 == 0)
			{
				continue;
			}
			result = buLangTranslate.preDef.Current;
			break;
		}
		return result;
	}

	public unsafe void ReadAlarmList(ref List<AppAlarm> AlarmList)
	{
		void* ptr = stackalloc byte[13];
		try
		{
			((sbyte*)ptr)[8] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[8])
			{
				return;
			}
			AlarmList.Clear();
			*(int*)ptr = 0;
			AppAlarm appAlarm2 = default(AppAlarm);
			while (true)
			{
				((sbyte*)ptr)[12] = ((*(int*)ptr < 10) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[12] == 0)
				{
					break;
				}
				string Val;
				string Val2;
				do
				{
					AppAlarm appAlarm = new AppAlarm();
					if (0 == 0)
					{
						appAlarm2 = appAlarm;
					}
					Val = _0090(107397099);
					Val2 = _0090(107397099);
					readDINTVar(CodesysVariableBaseType.Global, _0090(107394773) + *(int*)ptr + _0090(107394740), ref appAlarm2.ID);
					readLREALVar(CodesysVariableBaseType.Global, _0090(107394773) + *(int*)ptr + _0090(107394763), ref appAlarm2.Code);
					readBOOLVar(CodesysVariableBaseType.Global, _0090(107394773) + *(int*)ptr + _0090(107394754), ref appAlarm2.Occured);
					readSTRINGVar(CodesysVariableBaseType.Global, _0090(107394773) + *(int*)ptr + _0090(107394709), ref Val2);
					readSTRINGVar(CodesysVariableBaseType.Global, _0090(107394773) + *(int*)ptr + _0090(107394732), ref Val);
				}
				while (7 == 0);
				((sbyte*)ptr)[9] = (appAlarm2.Occured ? ((sbyte)1) : ((sbyte)0));
				string text;
				if (((bool*)ptr)[9])
				{
					text = _0090(107397099);
					((sbyte*)ptr)[10] = (((appAlarm2.ID >= 300) & (appAlarm2.ID < 400)) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[10])
					{
						text = _0090(107394723) + Val2 + _0090(107397159);
						if (true)
						{
							goto IL_023f;
						}
					}
					((sbyte*)ptr)[11] = ((Val2.Length > 0) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[11])
					{
						text = _0090(107394723) + Val2 + _0090(107397159);
					}
					goto IL_023f;
				}
				*(int*)ptr = 100;
				goto IL_02bd;
				IL_023f:
				appAlarm2.Text = text + _0090(107394678) + appAlarm2.ID + _0090(107397159) + Val;
				AppAlarm.AppendLogFile(AppPath.Log + _0090(107394701), appAlarm2);
				AlarmList.Add(appAlarm2);
				goto IL_02bd;
				IL_02bd:
				(*(int*)ptr)++;
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[1] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395160), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[1], ee);
			buException.throwException(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void ReadWarningList(ref List<AppWarning> WarningList)
	{
		void* ptr = stackalloc byte[11];
		try
		{
			((sbyte*)ptr)[8] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[8])
			{
				return;
			}
			WarningList.Clear();
			while (true)
			{
				*(int*)ptr = 0;
				while (true)
				{
					((sbyte*)ptr)[10] = ((*(int*)ptr < 50) ? ((sbyte)1) : ((sbyte)0));
					if (((sbyte*)ptr)[10] == 0)
					{
						return;
					}
					AppWarning appWarning = new AppWarning();
					if (false)
					{
						break;
					}
					string Val = _0090(107397099);
					string Val2 = _0090(107397099);
					readDINTVar(CodesysVariableBaseType.Global, _0090(107395171) + *(int*)ptr + _0090(107394740), ref appWarning.ID);
					readSTRINGVar(CodesysVariableBaseType.Global, _0090(107395171) + *(int*)ptr + _0090(107394732), ref Val);
					readSTRINGVar(CodesysVariableBaseType.Global, _0090(107395171) + *(int*)ptr + _0090(107394709), ref Val2);
					readBOOLVar(CodesysVariableBaseType.Global, _0090(107395171) + *(int*)ptr + _0090(107394754), ref appWarning.Occured);
					((sbyte*)ptr)[9] = (appWarning.Occured ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[9])
					{
						appWarning.Text = _0090(107395098) + Val2 + _0090(107395089) + appWarning.ID + _0090(107397159) + Val;
						WarningList.Add(appWarning);
						AppWarning.AppendLogFile(AppPath.Log + _0090(107395108), appWarning);
					}
					else
					{
						*(int*)ptr = 100;
					}
					(*(int*)ptr)++;
				}
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[1] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107395087), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[1], ee);
			buException.throwException(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void ReadWarningActive(ref AppWarning Warning)
	{
		void* ptr = stackalloc byte[5];
		try
		{
			if (0 == 0)
			{
				((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[4] == 0)
				{
					Warning = new AppWarning();
					readDINTVar(CodesysVariableBaseType.Global, _0090(107395034), ref Warning.ID);
					readSTRINGVar(CodesysVariableBaseType.Global, _0090(107395021), ref Warning.Text);
					readSTRINGVar(CodesysVariableBaseType.Global, _0090(107394940), ref Warning.Axis);
					readBOOLVar(CodesysVariableBaseType.Global, _0090(107394415), ref Warning.Occured);
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107394330), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void ResetWarningActive()
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				writeBOOLVar(CodesysVariableBaseType.Global, Val: false, _0090(107394415));
			}
		}
		catch (Exception ee)
		{
			if (4u != 0)
			{
				*(int*)ptr = 0;
				string message = _0090(107397099);
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107394337), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
		}
	}

	public unsafe void OpenKollmorgenAlarmFile(string FileName, ref List<DeviceAlarmWarningInfo> DeviceAlarms)
	{
		void* ptr;
		do
		{
			ptr = stackalloc byte[12];
		}
		while (5 == 0);
		try
		{
			FileInfo fileInfo = null;
			fileInfo = new FileInfo(FileName);
			ArrayList arrayList = default(ArrayList);
			TextReader textReader = default(TextReader);
			string text = default(string);
			string[] array = default(string[]);
			DeviceAlarmWarningInfo deviceAlarmWarningInfo = default(DeviceAlarmWarningInfo);
			while (true)
			{
				DeviceAlarms.Clear();
				DeviceAlarms = new List<DeviceAlarmWarningInfo>();
				((sbyte*)ptr)[4] = (fileInfo.Exists ? ((sbyte)1) : ((sbyte)0));
				sbyte num = ((sbyte*)ptr)[4];
				if (1 == 0)
				{
					goto IL_0169;
				}
				if (num != 0)
				{
					arrayList = new ArrayList();
					textReader = File.OpenText(fileInfo.FullName);
					text = _0090(107397099);
					goto IL_0225;
				}
				break;
				IL_0225:
				sbyte num2;
				if ((text = textReader.ReadLine()) != null)
				{
					array = text.Split(';');
					((sbyte*)ptr)[5] = ((array != null) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[5])
					{
						if (-1 == 0)
						{
							continue;
						}
						((sbyte*)ptr)[6] = ((array.Length >= 4) ? ((sbyte)1) : ((sbyte)0));
						num2 = ((sbyte*)ptr)[6];
						while (num2 != 0)
						{
							deviceAlarmWarningInfo = new DeviceAlarmWarningInfo();
							deviceAlarmWarningInfo.AlarmNo = Convert.ToInt32(array[0]);
							((sbyte*)ptr)[7] = ((array[1].ToLower() == _0090(107394312)) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[7])
							{
								deviceAlarmWarningInfo.isAlarm = true;
							}
							((sbyte*)ptr)[8] = ((array[1].ToLower() == _0090(107394307)) ? ((sbyte)1) : ((sbyte)0));
							num2 = ((sbyte*)ptr)[8];
							if (false)
							{
								continue;
							}
							goto IL_0133;
						}
					}
					goto IL_021b;
				}
				textReader.Close();
				break;
				IL_021b:
				arrayList.Add(text);
				goto IL_0225;
				IL_0169:
				if (num != 0)
				{
					deviceAlarmWarningInfo.AlarmDecstription = deviceAlarmWarningInfo.AlarmDecstription + _0090(107397159) + array[4];
				}
				((sbyte*)ptr)[10] = ((array.Length >= 6) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[10])
				{
					deviceAlarmWarningInfo.AlarmDecstription = deviceAlarmWarningInfo.AlarmDecstription + _0090(107397159) + array[5];
				}
				((sbyte*)ptr)[11] = ((array.Length >= 7) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[11])
				{
					deviceAlarmWarningInfo.AlarmDecstription = deviceAlarmWarningInfo.AlarmDecstription + _0090(107397159) + array[6];
				}
				DeviceAlarms.Add(deviceAlarmWarningInfo);
				goto IL_021b;
				IL_0133:
				if (num2 != 0)
				{
					deviceAlarmWarningInfo.isAlarm = false;
				}
				deviceAlarmWarningInfo.AlarmName = array[2];
				deviceAlarmWarningInfo.AlarmDecstription = array[3];
				((sbyte*)ptr)[9] = ((array.Length >= 5) ? ((sbyte)1) : ((sbyte)0));
				num = ((sbyte*)ptr)[9];
				goto IL_0169;
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107394270), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			buException.throwException(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void MatchKollmorgenAlarmWithID(double ID, List<DeviceAlarmWarningInfo> DeviceAlarms, ref string AlarmText)
	{
		void* ptr = stackalloc byte[7];
		try
		{
			*(int*)ptr = 0;
			while (true)
			{
				((sbyte*)ptr)[6] = ((*(int*)ptr <= DeviceAlarms.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[6] == 0)
				{
					if (4u != 0)
					{
						break;
					}
				}
				else
				{
					((sbyte*)ptr)[4] = (((double)DeviceAlarms[*(int*)ptr].AlarmNo == ID) ? ((sbyte)1) : ((sbyte)0));
					if (((sbyte*)ptr)[4] == 0)
					{
						goto IL_00f6;
					}
					((sbyte*)ptr)[5] = (DeviceAlarms[*(int*)ptr].isAlarm ? ((sbyte)1) : ((sbyte)0));
				}
				if (((bool*)ptr)[5])
				{
					AlarmText = _0090(107394237) + DeviceAlarms[*(int*)ptr].AlarmNo + _0090(107394248) + DeviceAlarms[*(int*)ptr].AlarmName + _0090(107394243) + DeviceAlarms[*(int*)ptr].AlarmDecstription + _0090(107394206);
				}
				goto IL_00f6;
				IL_00f6:
				(*(int*)ptr)++;
			}
		}
		catch (Exception ee)
		{
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107394201), message, _0090(107397045), _0090(107397099), _0090(107397099), 0, ee);
			do
			{
				buException.throwException(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
			while (false);
		}
	}

	public unsafe void resetAlarms()
	{
		void* ptr = stackalloc byte[6];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			while (((sbyte*)ptr)[4] == 0)
			{
				global::_0004._0006(_0090(107394164), _0090(107397099), _0090(107397099));
				if (0 == 0)
				{
					if (false)
					{
						break;
					}
					((sbyte*)ptr)[5] = ((this._0001 != null) ? ((sbyte)1) : ((sbyte)0));
				}
				if (((bool*)ptr)[5])
				{
					global::_0083._007E_009B(this._0001, null, MotionCommands.AlarmReset, _0090(107394179), null);
				}
				while (true)
				{
					writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0090(107394642));
					writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0090(107394609));
					if (5 == 0)
					{
						break;
					}
					if (0 == 0)
					{
						return;
					}
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107394164), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void resetWarning()
	{
		void* ptr = stackalloc byte[5];
		do
		{
			try
			{
				if (8 == 0)
				{
					continue;
				}
				((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[4])
				{
					if (3 == 0)
					{
					}
					continue;
				}
				global::_0004._0006(_0090(107394604), _0090(107397099), _0090(107397099));
				if (0 == 0)
				{
					writeBOOLVar(CodesysVariableBaseType.Global, Val: true, _0090(107394609));
				}
			}
			catch (Exception ee)
			{
				*(int*)ptr = 0;
				string message;
				if (0 == 0)
				{
					message = _0090(107397099);
				}
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107394604), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
		}
		while (3 == 0);
	}

	public void ShowAlarmPage(List<AppAlarm> AlarmList)
	{
		if (-1 == 0 || 5 == 0)
		{
			return;
		}
		bool num = CodesysMachine.frmAlarm != null;
		do
		{
			bool flag = num;
			num = flag;
		}
		while (false);
		if (num)
		{
			CodesysMachine.frmAlarm.Init(AlarmList);
			CodesysMachine.frmAlarm.Size = new Size(900, 350);
			if (0 == 0)
			{
				CodesysMachine.frmAlarm.lst_alarm.Font = new Font(new FontFamily(_0090(107394555)), 12f, FontStyle.Bold);
				CodesysMachine.frmAlarm.lst_alarm.ItemHeight = 40;
			}
			CodesysMachine.frmAlarm.Show();
		}
	}

	public unsafe void ReadSystemRuntimeVariables(ref SystemRuntime runSystem)
	{
		void* ptr;
		if (0 == 0)
		{
			ptr = stackalloc byte[5];
		}
		try
		{
			if (0 == 0)
			{
				((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			}
			if (((sbyte*)ptr)[4] == 0)
			{
				readBOOLVar(CodesysVariableBaseType.Global, _0090(107394546), ref runSystem.Alarm);
				readBOOLVar(CodesysVariableBaseType.Global, _0090(107394517), ref runSystem.Run);
				readBOOLVar(CodesysVariableBaseType.Global, _0090(107394492), ref runSystem.Move);
				readBOOLVar(CodesysVariableBaseType.Global, _0090(107394463), ref runSystem.Pause);
				readBOOLVar(CodesysVariableBaseType.Global, _0090(107394466), ref runSystem.HomingDone);
				readBOOLVar(CodesysVariableBaseType.Global, _0090(107393885), ref runSystem.FileLoaded);
				readBOOLVar(CodesysVariableBaseType.Global, _0090(107393848), ref runSystem.Enabled);
				readBOOLVar(CodesysVariableBaseType.Global, _0090(107393811), ref runSystem.WarningOccured);
				readBOOLVar(CodesysVariableBaseType.Global, _0090(107393794), ref runSystem.SimulatedAxes);
				readBOOLVar(CodesysVariableBaseType.Global, _0090(107393761), ref runSystem.SimulatedIO);
				readLREALVar(CodesysVariableBaseType.Persistent, _0090(107393732), ref runSystem.FeedOverride);
				if (3u != 0)
				{
					readDINTVar(CodesysVariableBaseType.Global, _0090(107393699), ref runSystem.AlarmCount);
					readDINTVar(CodesysVariableBaseType.Global, _0090(107393666), ref runSystem.WarningCount);
					readDINTVar(CodesysVariableBaseType.Global, _0090(107394105), ref runSystem.Status);
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107394116), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void ReadCNCRuntimeVariables(ref CncRuntime runCNC)
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[4])
			{
				while (false)
				{
				}
				return;
			}
			readBOOLVar(CodesysVariableBaseType.Global, _0090(107394047), ref runCNC.SingleStep);
			readBOOLVar(CodesysVariableBaseType.Global, _0090(107394002), ref runCNC.SingleStep);
			readDINTVar(CodesysVariableBaseType.Global, _0090(107393993), ref runCNC.ActiveLine);
			readDINTVar(CodesysVariableBaseType.Global, _0090(107393952), ref runCNC.ActiveTool);
			readDINTVar(CodesysVariableBaseType.Global, _0090(107393367), ref runCNC.ActiveMCode);
		}
		catch (Exception ee)
		{
			while (7u != 0)
			{
				*(int*)ptr = 0;
				string message = _0090(107397099);
				if (0 == 0)
				{
					CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107393358), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
					global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
					break;
				}
			}
		}
	}

	public unsafe void ReadAxisGroup(ReadAxisDataBits Bits, ref List<CodesysAxesData> AppAxes)
	{
		void* ptr = stackalloc byte[55];
		try
		{
			((sbyte*)ptr)[20] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[20])
			{
				return;
			}
			List<VariableLREALDef> Vars = new List<VariableLREALDef>();
			List<VariableBOOLDef> Vars2 = new List<VariableBOOLDef>();
			*(int*)ptr = 0;
			while (true)
			{
				((sbyte*)ptr)[32] = ((*(int*)ptr <= AppAxes.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				sbyte num;
				if (((bool*)ptr)[32])
				{
					((sbyte*)ptr)[21] = (Bits.Position ? ((sbyte)1) : ((sbyte)0));
					num = ((sbyte*)ptr)[21];
					if (0 == 0)
					{
						if (num != 0)
						{
							Vars.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + AppAxes[*(int*)ptr].AxisPar.Strings.strRuntimeVar + _0090(107393325)));
						}
						((sbyte*)ptr)[22] = ((Bits.OffsetedPosition & !AppAxes[*(int*)ptr].AxisPar.Temps.DontReadOffsetedPosition) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[22])
						{
							Vars.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + AppAxes[*(int*)ptr].AxisPar.Strings.strRuntimeVar + _0090(107393292)));
						}
						((sbyte*)ptr)[23] = (Bits.Velocity ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[23])
						{
							Vars.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + AppAxes[*(int*)ptr].AxisPar.Strings.strRuntimeVar + _0090(107393215)));
						}
						((sbyte*)ptr)[24] = (Bits.Current ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[24])
						{
							Vars.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + AppAxes[*(int*)ptr].AxisPar.Strings.strRuntimeVar + _0090(107393182)));
						}
						((sbyte*)ptr)[25] = (Bits.FollowingError ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[25])
						{
							Vars.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + AppAxes[*(int*)ptr].AxisPar.Strings.strRuntimeVar + _0090(107393149)));
						}
						((sbyte*)ptr)[26] = (Bits.DistanceToGo ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[26])
						{
							Vars.Add(new VariableLREALDef(CodesysMachine.RootGlobalString + AppAxes[*(int*)ptr].AxisPar.Strings.strRuntimeVar + _0090(107393624)));
						}
						((sbyte*)ptr)[27] = (Bits.Enabled ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[27])
						{
							Vars2.Add(new VariableBOOLDef(CodesysMachine.RootGlobalString + AppAxes[*(int*)ptr].AxisPar.Strings.strRuntimeVar + _0090(107393595)));
						}
						((sbyte*)ptr)[28] = (Bits.HomingDone ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[28])
						{
							Vars2.Add(new VariableBOOLDef(CodesysMachine.RootGlobalString + AppAxes[*(int*)ptr].AxisPar.Strings.strRuntimeVar + _0090(107397011)));
						}
						((sbyte*)ptr)[29] = (Bits.StandStill ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[29])
						{
							Vars2.Add(new VariableBOOLDef(CodesysMachine.RootGlobalString + AppAxes[*(int*)ptr].AxisPar.Strings.strRuntimeVar + _0090(107393606)));
						}
						goto IL_034e;
					}
					goto IL_0895;
				}
				((sbyte*)ptr)[33] = ((Vars.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[33])
				{
					((sbyte*)ptr)[34] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[34])
					{
						buPLCHandler.ReadMultiVariableLREAL(ref Vars);
					}
					((sbyte*)ptr)[35] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[35])
					{
						OPCReadWrite.ReadLREALsValueFromVariables(OpcVars.opcClient.Session, ref Vars);
					}
				}
				((sbyte*)ptr)[36] = ((Vars2.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[36])
				{
					((sbyte*)ptr)[37] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[37])
					{
						buPLCHandler.ReadMultiVariableBOOL(ref Vars2);
					}
					goto IL_04a7;
				}
				goto IL_04d0;
				IL_099a:
				((sbyte*)ptr)[53] = ((((int*)ptr)[3] <= Vars2.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				string name;
				if (((bool*)ptr)[53])
				{
					if (false)
					{
						goto IL_04a7;
					}
					name = Vars2[((int*)ptr)[3]].Name;
					((sbyte*)ptr)[47] = ((name.IndexOf(AppAxes[((int*)ptr)[1]].AxisPar.Strings.strRuntimeVar) >= 0) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[47])
					{
						((sbyte*)ptr)[48] = ((name.IndexOf(_0090(107392853)) >= 0) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[48])
						{
							AppAxes[((int*)ptr)[1]].AxisPar.Runtime.Bool.bEnabled = Vars2[((int*)ptr)[3]].Value;
						}
						((sbyte*)ptr)[49] = ((name.IndexOf(_0090(107392872)) >= 0) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[49])
						{
							AppAxes[((int*)ptr)[1]].AxisPar.Runtime.Bool.bHomingDone = Vars2[((int*)ptr)[3]].Value;
						}
						((sbyte*)ptr)[50] = ((name.IndexOf(_0090(107392823)) >= 0) ? ((sbyte)1) : ((sbyte)0));
						num = ((sbyte*)ptr)[50];
						goto IL_0895;
					}
					goto IL_098d;
				}
				((int*)ptr)[1]++;
				goto IL_09c6;
				IL_03f0:
				(*(int*)ptr)++;
				continue;
				IL_0737:
				((int*)ptr)[2]++;
				goto IL_0742;
				IL_0651:
				if (((bool*)ptr)[43])
				{
					AppAxes[((int*)ptr)[1]].AxisPar.Runtime.Actual.actualCurrent = Vars[((int*)ptr)[2]].Value;
				}
				string name2;
				((sbyte*)ptr)[44] = ((name2.IndexOf(_0090(107393407)) >= 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[44])
				{
					AppAxes[((int*)ptr)[1]].AxisPar.Runtime.Actual.actualFollowError = Vars[((int*)ptr)[2]].Value;
				}
				((sbyte*)ptr)[45] = ((name2.IndexOf(_0090(107393414)) >= 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[45])
				{
					AppAxes[((int*)ptr)[1]].AxisPar.Runtime.Actual.distanceToGo = Vars[((int*)ptr)[2]].Value;
				}
				goto IL_0737;
				IL_0895:
				if (num != 0)
				{
					if (false)
					{
						goto IL_03f0;
					}
					AppAxes[((int*)ptr)[1]].AxisPar.Runtime.Bool.bStandstill = Vars2[((int*)ptr)[3]].Value;
				}
				((sbyte*)ptr)[51] = ((name.IndexOf(_0090(107392838)) >= 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[51])
				{
					if (5 == 0)
					{
						goto IL_034e;
					}
					AppAxes[((int*)ptr)[1]].AxisPar.Runtime.Bool.bAxisError = Vars2[((int*)ptr)[3]].Value;
				}
				((sbyte*)ptr)[52] = ((name.IndexOf(_0090(107392789)) >= 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[52])
				{
					if (false)
					{
						goto IL_0651;
					}
					AppAxes[((int*)ptr)[1]].AxisPar.Runtime.Bool.bComOK = Vars2[((int*)ptr)[3]].Value;
				}
				goto IL_098d;
				IL_034e:
				((sbyte*)ptr)[30] = (Bits.AxisError ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[30])
				{
					Vars2.Add(new VariableBOOLDef(CodesysMachine.RootGlobalString + AppAxes[*(int*)ptr].AxisPar.Strings.strRuntimeVar + _0090(107393581)));
				}
				((sbyte*)ptr)[31] = (Bits.CommOk ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[31])
				{
					Vars2.Add(new VariableBOOLDef(CodesysMachine.RootGlobalString + AppAxes[*(int*)ptr].AxisPar.Strings.strRuntimeVar + _0090(107393524)));
				}
				goto IL_03f0;
				IL_098d:
				((int*)ptr)[3]++;
				goto IL_099a;
				IL_04a7:
				((sbyte*)ptr)[38] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[38])
				{
					OPCReadWrite.ReadBOOLsValueFromVariables(OpcVars.opcClient.Session, ref Vars2);
				}
				goto IL_04d0;
				IL_04d0:
				((int*)ptr)[1] = 0;
				goto IL_09c6;
				IL_0742:
				((sbyte*)ptr)[46] = ((((int*)ptr)[2] <= Vars.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[46])
				{
					name2 = Vars[((int*)ptr)[2]].Name;
					((sbyte*)ptr)[39] = ((name2.IndexOf(AppAxes[((int*)ptr)[1]].AxisPar.Strings.strRuntimeVar) >= 0) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[39])
					{
						((sbyte*)ptr)[40] = ((name2.IndexOf(_0090(107393503)) >= 0) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[40])
						{
							AppAxes[((int*)ptr)[1]].AxisPar.Runtime.Actual.actualPosition = Vars[((int*)ptr)[2]].Value;
						}
						((sbyte*)ptr)[41] = ((name2.IndexOf(_0090(107393514)) >= 0) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[41])
						{
							AppAxes[((int*)ptr)[1]].AxisPar.Runtime.Actual.actualOffsetedPosition = Vars[((int*)ptr)[2]].Value;
						}
						((sbyte*)ptr)[42] = ((name2.IndexOf(_0090(107393481)) >= 0) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[42])
						{
							AppAxes[((int*)ptr)[1]].AxisPar.Runtime.Actual.actualVelocity = Vars[((int*)ptr)[2]].Value;
						}
						((sbyte*)ptr)[43] = ((name2.IndexOf(_0090(107393428)) >= 0) ? ((sbyte)1) : ((sbyte)0));
						goto IL_0651;
					}
					goto IL_0737;
				}
				((int*)ptr)[3] = 0;
				goto IL_099a;
				IL_09c6:
				((sbyte*)ptr)[54] = ((((int*)ptr)[1] <= AppAxes.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[54])
				{
					((int*)ptr)[2] = 0;
					goto IL_0742;
				}
				break;
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[4] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392812), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[4], ee);
			buException.throwException(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public void ReadAxis(string AxisString, ReadAxisDataBits Bits, ref CodesysAxis Axis)
	{
		ReadAxisData(AxisString, Bits.Position, Bits.OffsetedPosition, Bits.Velocity, Bits.Current, Bits.FollowingError, ref Axis.Runtime.Actual);
		ReadAxisBoolData(AxisString, Bits.Enabled, Bits.HomingDone, Bits.StandStill, Bits.AxisError, Bits.CommOk, ref Axis.Runtime.Bool);
		ReadAxisInput(AxisString, Bits.InputHoming, Bits.InputPosLimit, Bits.InputNegLimit, Bits.InputCapture, ref Axis.Runtime.Input);
	}

	public unsafe void ReadAxisData(string AxisString, bool Position, bool OffsetedPosition, bool Velocity, bool Current, bool FollowingError, ref CodesysAxRuntimeActive AxisData)
	{
		void* ptr = stackalloc byte[10];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				((sbyte*)ptr)[5] = (Position ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[5])
				{
					readLREALVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107393325)), ref AxisData.actualPosition);
				}
				((sbyte*)ptr)[6] = (OffsetedPosition ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[6])
				{
					readLREALVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107393292)), ref AxisData.actualOffsetedPosition);
				}
				((sbyte*)ptr)[7] = (Velocity ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[7])
				{
					readLREALVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107393215)), ref AxisData.actualVelocity);
				}
				((sbyte*)ptr)[8] = (Current ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[8])
				{
					readLREALVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107393182)), ref AxisData.actualCurrent);
				}
				((sbyte*)ptr)[9] = (FollowingError ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[9])
				{
					readLREALVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107393149)), ref AxisData.actualFollowError);
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			if (0 == 0)
			{
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392812), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
		}
	}

	public unsafe void ReadAxisBoolData(string AxisString, bool Enabled, bool HomingDone, bool Standstill, bool AxisError, bool CommOk, ref CodesysAxRuntimeBool AxisDataBool)
	{
		void* ptr = stackalloc byte[10];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				((sbyte*)ptr)[5] = (Enabled ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[5])
				{
					readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107393595)), ref AxisDataBool.bEnabled);
				}
				((sbyte*)ptr)[6] = (HomingDone ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[6])
				{
					readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107397011)), ref AxisDataBool.bHomingDone);
				}
				((sbyte*)ptr)[7] = (Standstill ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[7])
				{
					readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107393606)), ref AxisDataBool.bStandstill);
				}
				((sbyte*)ptr)[8] = (AxisError ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[8])
				{
					readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107393581)), ref AxisDataBool.bAxisError);
				}
				((sbyte*)ptr)[9] = (CommOk ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[9])
				{
					readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107393524)), ref AxisDataBool.bComOK);
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			if (0 == 0)
			{
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392763), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
		}
	}

	public unsafe void ReadAxisInput(string AxisString, bool eHoming, bool ePosLimit, bool eNegLimit, bool eCapture, ref CodesysAxRuntimeInput AxisDataInput)
	{
		void* ptr = stackalloc byte[9];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				((sbyte*)ptr)[5] = (eHoming ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[5])
				{
					readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107392770)), ref AxisDataInput.eHoming);
				}
				((sbyte*)ptr)[6] = (ePosLimit ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[6])
				{
					readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107392745)), ref AxisDataInput.ePositiveLimit);
				}
				((sbyte*)ptr)[7] = (eNegLimit ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[7])
				{
					readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107392712)), ref AxisDataInput.eNegativeLimit);
				}
				((sbyte*)ptr)[8] = (eCapture ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[8])
				{
					readBOOLVar(CodesysVariableBaseType.Global, global::_0003._0005(AxisString, _0090(107392679)), ref AxisDataInput.eCapture);
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392654), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void ReadIOData(ref CodesysMachine cMachine)
	{
		void* ptr = stackalloc byte[15];
		try
		{
			((sbyte*)ptr)[12] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[12])
			{
				return;
			}
			*(int*)ptr = 0;
			while (true)
			{
				((sbyte*)ptr)[13] = ((*(int*)ptr <= cMachine.Inputs.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[13] == 0)
				{
					break;
				}
				readDINTVar(CodesysVariableBaseType.None, global::_0003._0005(cMachine.Inputs[*(int*)ptr].FullAddress, _0090(107393113)), ref cMachine.Inputs[*(int*)ptr].SourceIndex);
				readBOOLVar(CodesysVariableBaseType.None, global::_0003._0005(cMachine.Inputs[*(int*)ptr].FullAddress, _0090(107393128)), ref cMachine.Inputs[*(int*)ptr].Invert);
				(*(int*)ptr)++;
			}
			((int*)ptr)[1] = 0;
			while (true)
			{
				((sbyte*)ptr)[14] = ((((int*)ptr)[1] <= cMachine.Outputs.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[14])
				{
					readDINTVar(CodesysVariableBaseType.None, global::_0003._0005(cMachine.Outputs[((int*)ptr)[1]].FullAddress, _0090(107393113)), ref cMachine.Outputs[((int*)ptr)[1]].SourceIndex);
					readBOOLVar(CodesysVariableBaseType.None, global::_0003._0005(cMachine.Outputs[((int*)ptr)[1]].FullAddress, _0090(107393128)), ref cMachine.Outputs[((int*)ptr)[1]].Invert);
					((int*)ptr)[1]++;
					continue;
				}
				break;
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[2] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107393083), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[2], ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteAxisData(string AxisString, CodesysAxesData AxisData)
	{
		void* ptr = stackalloc byte[7];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[4])
			{
				return;
			}
			((sbyte*)ptr)[5] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[5])
			{
				global::_0084._009C(AxisData.AxisPar.Sets, global::_0003._0005(AxisString, _0090(107393098)), _0090(107397099));
				global::_0084._009C(AxisData.AxisPar.Base, global::_0003._0005(AxisString, _0090(107393053)), _0090(107397099));
				global::_0084._009C(AxisData.AxisPar.Cnc, global::_0003._0005(AxisString, _0090(107393040)), _0090(107397099));
				global::_0084._009C(AxisData.AxisPar.Gear, global::_0003._0005(AxisString, _0090(107393059)), _0090(107397099));
				global::_0084._009C(AxisData.AxisPar.Homings, global::_0003._0005(AxisString, _0090(107393014)), _0090(107397099));
				int num = global::_0084._009C(AxisData.AxisPar.Jogs, global::_0003._0005(AxisString, _0090(107393029)), _0090(107397099));
				do
				{
					num = global::_0084._009C(AxisData.AxisPar.Moves, global::_0003._0005(AxisString, _0090(107392984)), _0090(107397099));
				}
				while (false);
			}
			while (true)
			{
				((sbyte*)ptr)[6] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[6] == 0)
				{
					break;
				}
				global::_0087._009E(AxisData.AxisPar.Sets, global::_0003._0005(AxisString, _0090(107393098)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				if (2u != 0)
				{
					if (0 == 0)
					{
						global::_0087._009E(AxisData.AxisPar.Base, global::_0003._0005(AxisString, _0090(107393053)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
						global::_0087._009E(AxisData.AxisPar.Cnc, global::_0003._0005(AxisString, _0090(107393040)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
						global::_0087._009E(AxisData.AxisPar.Gear, global::_0003._0005(AxisString, _0090(107393059)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
						global::_0087._009E(AxisData.AxisPar.Homings, global::_0003._0005(AxisString, _0090(107393014)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
						global::_0087._009E(AxisData.AxisPar.Jogs, global::_0003._0005(AxisString, _0090(107393029)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
						global::_0087._009E(AxisData.AxisPar.Moves, global::_0003._0005(AxisString, _0090(107392984)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
					}
					break;
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107393003), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteAxisData(string AxisString, CodesysAxesData AxisData, bool WriteBase, bool WriteCNC, bool WriteGear, bool WriteHoming, bool WriteJog, bool WriteMove, bool WriteMisc)
	{
		if (false)
		{
			return;
		}
		void* ptr = stackalloc byte[31];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[4])
			{
				return;
			}
			string message = _0090(107397099);
			List<string> list = new List<string>();
			((sbyte*)ptr)[5] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
			int num;
			int num2;
			if (((bool*)ptr)[5])
			{
				num = global::_0084._009C(AxisData.AxisPar.Sets, global::_0003._0005(AxisString, _0090(107393098)), _0090(107397099));
				if (0 == 0)
				{
					((sbyte*)ptr)[6] = (WriteBase ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[6])
					{
						num2 = global::_0084._009C(AxisData.AxisPar.Base, global::_0003._0005(AxisString, _0090(107393053)), _0090(107397099));
					}
					goto IL_00fc;
				}
				goto IL_0106;
			}
			goto IL_02e2;
			IL_046c:
			((sbyte*)ptr)[18] = ((OPCReadWrite.ErrorList.Count > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[18])
			{
				list.AddRange(OPCReadWrite.ErrorList);
				OPCReadWrite.ErrorList.Clear();
			}
			goto IL_049f;
			IL_0243:
			((sbyte*)ptr)[11] = (WriteMove ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[11])
			{
				global::_0084._009C(AxisData.AxisPar.Moves, global::_0003._0005(AxisString, _0090(107392984)), _0090(107397099));
			}
			((sbyte*)ptr)[12] = (WriteMisc ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[12])
			{
				global::_0084._009C(AxisData.AxisPar.MiscSet, global::_0003._0005(AxisString, _0090(107392950)), _0090(107397099));
			}
			goto IL_02e2;
			IL_0385:
			int num3;
			if (num3 != 0)
			{
				message = global::_0087._009E(AxisData.AxisPar.Base, global::_0003._0005(AxisString, _0090(107393053)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				((sbyte*)ptr)[16] = ((OPCReadWrite.ErrorList.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[16])
				{
					list.AddRange(OPCReadWrite.ErrorList);
					OPCReadWrite.ErrorList.Clear();
				}
			}
			((sbyte*)ptr)[17] = (WriteCNC ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[17])
			{
				message = global::_0087._009E(AxisData.AxisPar.Cnc, global::_0003._0005(AxisString, _0090(107393040)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				goto IL_046c;
			}
			goto IL_049f;
			IL_02e2:
			((sbyte*)ptr)[13] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
			int num4;
			if (((bool*)ptr)[13])
			{
				message = global::_0087._009E(AxisData.AxisPar.Sets, global::_0003._0005(AxisString, _0090(107393098)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				((sbyte*)ptr)[14] = ((OPCReadWrite.ErrorList.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				num4 = ((sbyte*)ptr)[14];
				goto IL_035f;
			}
			return;
			IL_00fc:
			((sbyte*)ptr)[7] = (WriteCNC ? ((sbyte)1) : ((sbyte)0));
			num = ((sbyte*)ptr)[7];
			goto IL_0106;
			IL_0106:
			if (num != 0)
			{
				global::_0084._009C(AxisData.AxisPar.Cnc, global::_0003._0005(AxisString, _0090(107393040)), _0090(107397099));
			}
			((sbyte*)ptr)[8] = (WriteGear ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[8])
			{
				if (4 == 0)
				{
					goto IL_00fc;
				}
				num3 = global::_0084._009C(AxisData.AxisPar.Gear, global::_0003._0005(AxisString, _0090(107393059)), _0090(107397099));
				if (6 == 0)
				{
					goto IL_0385;
				}
			}
			((sbyte*)ptr)[9] = (WriteHoming ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[9])
			{
				global::_0084._009C(AxisData.AxisPar.Homings, global::_0003._0005(AxisString, _0090(107393014)), _0090(107397099));
			}
			((sbyte*)ptr)[10] = (WriteJog ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[10])
			{
				goto IL_01fc;
			}
			goto IL_0243;
			IL_01fc:
			num4 = global::_0084._009C(AxisData.AxisPar.Jogs, global::_0003._0005(AxisString, _0090(107393029)), _0090(107397099));
			if (6u != 0)
			{
				goto IL_0243;
			}
			goto IL_035f;
			IL_049f:
			((sbyte*)ptr)[19] = (WriteGear ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[19])
			{
				message = global::_0087._009E(AxisData.AxisPar.Gear, global::_0003._0005(AxisString, _0090(107393059)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				((sbyte*)ptr)[20] = ((OPCReadWrite.ErrorList.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[20])
				{
					list.AddRange(OPCReadWrite.ErrorList);
					OPCReadWrite.ErrorList.Clear();
					if (false)
					{
						goto IL_01fc;
					}
				}
			}
			((sbyte*)ptr)[21] = (WriteHoming ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[21])
			{
				message = global::_0087._009E(AxisData.AxisPar.Homings, global::_0003._0005(AxisString, _0090(107393014)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				((sbyte*)ptr)[22] = ((OPCReadWrite.ErrorList.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[22])
				{
					list.AddRange(OPCReadWrite.ErrorList);
					OPCReadWrite.ErrorList.Clear();
				}
			}
			((sbyte*)ptr)[23] = (WriteJog ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[23])
			{
				message = global::_0087._009E(AxisData.AxisPar.Jogs, global::_0003._0005(AxisString, _0090(107393029)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				((sbyte*)ptr)[24] = ((OPCReadWrite.ErrorList.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[24])
				{
					list.AddRange(OPCReadWrite.ErrorList);
					OPCReadWrite.ErrorList.Clear();
				}
			}
			((sbyte*)ptr)[25] = (WriteMove ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[25])
			{
				message = global::_0087._009E(AxisData.AxisPar.Moves, global::_0003._0005(AxisString, _0090(107392984)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				((sbyte*)ptr)[26] = ((OPCReadWrite.ErrorList.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[26])
				{
					list.AddRange(OPCReadWrite.ErrorList);
					if (false)
					{
						goto IL_046c;
					}
					OPCReadWrite.ErrorList.Clear();
				}
			}
			((sbyte*)ptr)[27] = (WriteMisc ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[27])
			{
				message = global::_0087._009E(AxisData.AxisPar.MiscSet, global::_0003._0005(AxisString, _0090(107392950)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				((sbyte*)ptr)[28] = ((OPCReadWrite.ErrorList.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				num2 = ((sbyte*)ptr)[28];
				if (5 == 0)
				{
					goto IL_00fc;
				}
				if (num2 != 0)
				{
					list.AddRange(OPCReadWrite.ErrorList);
					OPCReadWrite.ErrorList.Clear();
				}
			}
			((sbyte*)ptr)[29] = ((list.Count > 0) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[29])
			{
				((sbyte*)ptr)[30] = ((this._0001 != null) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[30])
				{
					MotionCommandEventArg motionCommandEventArg = new MotionCommandEventArg(MotionCommands.ShowWarningList, message, 0.0);
					motionCommandEventArg.ErrorList.AddRange(list);
					global::_0088._007E_009F(this._0001, motionCommandEventArg);
				}
			}
			return;
			IL_035f:
			if (num4 != 0)
			{
				list.AddRange(OPCReadWrite.ErrorList);
				OPCReadWrite.ErrorList.Clear();
			}
			((sbyte*)ptr)[15] = (WriteBase ? ((sbyte)1) : ((sbyte)0));
			num3 = ((sbyte*)ptr)[15];
			goto IL_0385;
		}
		catch (Exception ee)
		{
			string message2;
			do
			{
				*(int*)ptr = 0;
				message2 = _0090(107397099);
			}
			while (6 == 0);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107393003), message2, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteAxisMiscData(string AxisString, CodesysAxesData AxisData)
	{
		void* ptr;
		if (uint.MaxValue != 0)
		{
			ptr = stackalloc byte[9];
		}
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[4])
			{
				return;
			}
			string text = _0090(107397099);
			List<string> list = new List<string>();
			((sbyte*)ptr)[5] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[5])
			{
				global::_0084._009C(AxisData.AxisPar.MiscSet, global::_0003._0005(AxisString, _0090(107392950)), _0090(107397099));
			}
			((sbyte*)ptr)[6] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[6])
			{
				global::_0087._009E(AxisData.AxisPar.MiscSet, global::_0003._0005(AxisString, _0090(107392950)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				text = global::_0087._009E(AxisData.AxisPar.Sets, global::_0003._0005(AxisString, _0090(107393098)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				((sbyte*)ptr)[7] = ((OPCReadWrite.ErrorList.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[7])
				{
					list.AddRange(OPCReadWrite.ErrorList);
					OPCReadWrite.ErrorList.Clear();
				}
				((sbyte*)ptr)[8] = ((list.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[8] && this._0001 != null && global::_0014._007F(text, _0090(107396003)))
				{
					MotionCommandEventArg motionCommandEventArg = new MotionCommandEventArg(MotionCommands.ShowWarningList, text, 0.0);
					motionCommandEventArg.ErrorList.AddRange(list);
					global::_0088._007E_009F(this._0001, motionCommandEventArg);
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392969), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteCNCDataFullSTring(string AxisString, CodesysCNCSets CNCData)
	{
		void* ptr = stackalloc byte[9];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[4])
			{
				return;
			}
			string text = _0090(107397099);
			List<string> list = new List<string>();
			List<string> list2;
			if (3u != 0)
			{
				list2 = list;
			}
			((sbyte*)ptr)[5] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[5])
			{
				global::_0084._009C(CNCData, AxisString, _0090(107397099));
			}
			((sbyte*)ptr)[6] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[6])
			{
				text = global::_0087._009E(CNCData, AxisString, global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				((sbyte*)ptr)[7] = ((OPCReadWrite.ErrorList.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[7])
				{
					list2.AddRange(OPCReadWrite.ErrorList);
					OPCReadWrite.ErrorList.Clear();
				}
				((sbyte*)ptr)[8] = ((list2.Count > 0) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[8] && this._0001 != null && global::_0014._007F(text, _0090(107396003)))
				{
					MotionCommandEventArg motionCommandEventArg = new MotionCommandEventArg(MotionCommands.ShowWarningList, text, 0.0);
					motionCommandEventArg.ErrorList.AddRange(list2);
					global::_0088._007E_009F(this._0001, motionCommandEventArg);
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392912), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteCNCData(string AxisString, CodesysCNCSets CNCData)
	{
		void* ptr = stackalloc byte[7];
		try
		{
			if (0 == 0)
			{
				((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[4])
				{
					return;
				}
				string text = _0090(107397099);
				List<string> list = new List<string>();
				((sbyte*)ptr)[5] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[5])
				{
					global::_0084._009C(CNCData, global::_0003._0005(AxisString, _0090(107392911)), _0090(107397099));
				}
			}
			((sbyte*)ptr)[6] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[6])
			{
				global::_0087._009E(CNCData, global::_0003._0005(AxisString, _0090(107392911)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392346), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteCNCData(string AxisString, string Index, CodesysCNCSets CNCData)
	{
		void* ptr = stackalloc byte[7];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[4])
			{
				return;
			}
			string text = _0090(107397099);
			if (8u != 0)
			{
				string text2 = text;
			}
			List<string> list = new List<string>();
			((sbyte*)ptr)[5] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[5])
			{
				if (false)
				{
					return;
				}
				global::_0084._009C(CNCData, global::_0006._0008(AxisString, _0090(107392361), Index, _0090(107395387)), _0090(107397099));
			}
			((sbyte*)ptr)[6] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[6])
			{
				global::_0087._009E(CNCData, global::_0006._0008(AxisString, _0090(107392361), Index, _0090(107395387)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392346), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteSystemData(string pathtring, CodesysSystemSets SystemData)
	{
		void* ptr = stackalloc byte[7];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				string text = _0090(107397099);
				List<string> list = new List<string>();
				if (8u != 0)
				{
					List<string> list2 = list;
				}
				((sbyte*)ptr)[5] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[5])
				{
					global::_0084._009C(SystemData.Feed, global::_0003._0005(pathtring, _0090(107392312)), _0090(107397099));
					global::_0084._009C(SystemData.Spindle, global::_0003._0005(pathtring, _0090(107392327)), _0090(107397099));
					global::_0084._009C(SystemData.SpindleSaw, global::_0003._0005(pathtring, _0090(107392274)), _0090(107397099));
					global::_0084._009C(SystemData.Times, global::_0003._0005(pathtring, _0090(107392249)), _0090(107397099));
					global::_0084._009C(SystemData.Tool, global::_0003._0005(pathtring, _0090(107392260)), _0090(107397099));
					global::_0084._009C(SystemData.Offset, global::_0003._0005(pathtring, _0090(107392211)), _0090(107397099));
				}
				((sbyte*)ptr)[6] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[6])
				{
					global::_0087._009E(SystemData.Feed, global::_0003._0005(pathtring, _0090(107392312)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
					global::_0087._009E(SystemData.Spindle, global::_0003._0005(pathtring, _0090(107392327)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
					global::_0087._009E(SystemData.SpindleSaw, global::_0003._0005(pathtring, _0090(107392274)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
					global::_0087._009E(SystemData.Times, global::_0003._0005(pathtring, _0090(107392249)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
					global::_0087._009E(SystemData.Tool, global::_0003._0005(pathtring, _0090(107392260)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
					global::_0087._009E(SystemData.Offset, global::_0003._0005(pathtring, _0090(107392211)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				}
				writeDINTVar(CodesysVariableBaseType.None, SystemData.EthercatSyncTime, global::_0003._0005(pathtring, _0090(107392190)));
				writeBOOLVar(CodesysVariableBaseType.None, SystemData.EnableAxesAfterInit, global::_0003._0005(pathtring, _0090(107392157)));
				writeBOOLVar(CodesysVariableBaseType.None, SystemData.FairLoopMode, global::_0003._0005(pathtring, _0090(107392120)));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392603), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteSystemData(string pathtring, CodesysSystemSets SystemData, bool WriteFeed, bool WriteSpindle, bool WriteSpileSaw, bool WriteTime, bool WriteTool)
	{
		void* ptr = stackalloc byte[17];
		try
		{
			do
			{
				((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
				while (true)
				{
					if (((bool*)ptr)[4])
					{
						return;
					}
					string text = _0090(107397099);
					List<string> list = new List<string>();
					((sbyte*)ptr)[5] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[5])
					{
						((sbyte*)ptr)[6] = (WriteFeed ? ((sbyte)1) : ((sbyte)0));
						if (0 == 0)
						{
							if (((bool*)ptr)[6])
							{
								if (false)
								{
									goto IL_01f7;
								}
								global::_0084._009C(SystemData.Feed, global::_0003._0005(pathtring, _0090(107392312)), _0090(107397099));
							}
							((sbyte*)ptr)[7] = (WriteSpindle ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[7])
							{
								global::_0084._009C(SystemData.Spindle, global::_0003._0005(pathtring, _0090(107392327)), _0090(107397099));
							}
							((sbyte*)ptr)[8] = (WriteSpileSaw ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[8])
							{
								global::_0084._009C(SystemData.SpindleSaw, global::_0003._0005(pathtring, _0090(107392274)), _0090(107397099));
							}
							((sbyte*)ptr)[9] = (WriteTime ? ((sbyte)1) : ((sbyte)0));
							if (((sbyte*)ptr)[9] == 0)
							{
								goto IL_0195;
							}
						}
						global::_0084._009C(SystemData.Times, global::_0003._0005(pathtring, _0090(107392249)), _0090(107397099));
						goto IL_0195;
					}
					goto IL_01e0;
					IL_01f7:
					((sbyte*)ptr)[12] = (WriteFeed ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[12])
					{
						global::_0087._009E(SystemData.Feed, global::_0003._0005(pathtring, _0090(107392312)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
					}
					((sbyte*)ptr)[13] = (WriteSpindle ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[13])
					{
						global::_0087._009E(SystemData.Spindle, global::_0003._0005(pathtring, _0090(107392327)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
					}
					((sbyte*)ptr)[14] = (WriteSpileSaw ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[14])
					{
						goto IL_02b8;
					}
					goto IL_0308;
					IL_01e0:
					((sbyte*)ptr)[11] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
					if (((sbyte*)ptr)[11] == 0)
					{
						break;
					}
					goto IL_01f7;
					IL_0308:
					((sbyte*)ptr)[15] = (WriteTime ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[15])
					{
						global::_0087._009E(SystemData.Times, global::_0003._0005(pathtring, _0090(107392249)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
					}
					((sbyte*)ptr)[16] = (WriteTool ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[16])
					{
						global::_0087._009E(SystemData.Tool, global::_0003._0005(pathtring, _0090(107392260)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
					}
					if (0 == 0)
					{
						break;
					}
					goto IL_02b8;
					IL_02b8:
					if (false)
					{
						continue;
					}
					global::_0087._009E(SystemData.SpindleSaw, global::_0003._0005(pathtring, _0090(107392274)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
					goto IL_0308;
					IL_0195:
					((sbyte*)ptr)[10] = (WriteTool ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[10])
					{
						global::_0084._009C(SystemData.Tool, global::_0003._0005(pathtring, _0090(107392260)), _0090(107397099));
					}
					goto IL_01e0;
				}
				writeDINTVar(CodesysVariableBaseType.None, SystemData.EthercatSyncTime, global::_0003._0005(pathtring, _0090(107392190)));
				writeBOOLVar(CodesysVariableBaseType.None, SystemData.EnableAxesAfterInit, global::_0003._0005(pathtring, _0090(107392157)));
			}
			while (false);
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392603), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteHandwheelData(string AxisString, HandWheelSettings HandwheelData)
	{
		void* ptr = stackalloc byte[7];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				((sbyte*)ptr)[5] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[5])
				{
					global::_0084._009C(HandwheelData, global::_0003._0005(AxisString, _0090(107392614)), _0090(107397099));
				}
				((sbyte*)ptr)[6] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[6])
				{
					global::_0087._009E(HandwheelData, global::_0003._0005(AxisString, _0090(107392614)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392561), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteAlarmActionData(string AxisString, AlarmActionSettings AlarmActionData)
	{
		void* ptr = stackalloc byte[7];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				((sbyte*)ptr)[5] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[5])
				{
					global::_0084._009C(AlarmActionData, global::_0003._0005(AxisString, _0090(107392536)), _0090(107392551));
				}
				((sbyte*)ptr)[6] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[6])
				{
					global::_0087._009E(AlarmActionData, global::_0003._0005(AxisString, _0090(107392536)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107392551));
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392510), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteJogData(string AxisString, JogSettings JogData)
	{
		void* ptr = stackalloc byte[7];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				((sbyte*)ptr)[5] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[5])
				{
					global::_0084._009C(JogData, global::_0003._0005(AxisString, _0090(107392513)), _0090(107397099));
				}
				((sbyte*)ptr)[6] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[6])
				{
					global::_0087._009E(JogData, global::_0003._0005(AxisString, _0090(107392513)), global::_0086._007E_009D(OpcVars.opcClient), _0090(107397099));
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392468), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteG54Data(string PathString, int G54Count, Pnt9D[] G54List)
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				WriteG54Data(PathString, G54Count, WriteABC: true, WriteUVW: true, G54List);
			}
		}
		catch (Exception ee)
		{
			if (4u != 0)
			{
				*(int*)ptr = 0;
				string message = _0090(107397099);
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392483), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
		}
	}

	public unsafe void WriteG54Data(string PathString, int G54Count, Pnt9DS[] G54List)
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				WriteG54Data(PathString, G54Count, WriteABC: true, WriteUVW: true, G54List);
			}
		}
		catch (Exception ee)
		{
			if (4u != 0)
			{
				*(int*)ptr = 0;
				string message = _0090(107397099);
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392483), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
		}
	}

	public unsafe void WriteParkData(string PathString, int G54Count, Pnt9DS[] G54List)
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				WriteParkData(PathString, G54Count, WriteABC: true, WriteUVW: true, G54List);
			}
		}
		catch (Exception ee)
		{
			if (4u != 0)
			{
				*(int*)ptr = 0;
				string message = _0090(107397099);
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392483), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
			}
		}
	}

	public unsafe void WriteG54Data(string PathString, int G54Count, bool WriteABC, bool WriteUVW, Pnt9D[] G54List)
	{
		void* ptr = stackalloc byte[13];
		try
		{
			((sbyte*)ptr)[8] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[8])
			{
				return;
			}
			*(int*)ptr = 0;
			while (true)
			{
				((sbyte*)ptr)[12] = ((*(int*)ptr <= G54Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[12] == 0)
				{
					break;
				}
				((sbyte*)ptr)[9] = ((*(int*)ptr <= 9) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[9])
				{
					writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].X, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392409)));
					do
					{
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].Y, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392404)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].Z, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392431)));
						((sbyte*)ptr)[10] = (WriteABC ? ((sbyte)1) : ((sbyte)0));
						if (((sbyte*)ptr)[10] == 0)
						{
							break;
						}
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].A, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392426)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].B, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392421)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].C, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392416)));
					}
					while (-1 == 0);
					((sbyte*)ptr)[11] = (WriteUVW ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[11])
					{
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].U, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392379)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].V, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392374)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].W, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392369)));
					}
				}
				(*(int*)ptr)++;
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[1] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392483), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[1], ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteG54Data(string PathString, int G54Count, bool WriteABC, bool WriteUVW, Pnt9DS[] G54List)
	{
		void* ptr = stackalloc byte[13];
		try
		{
			((sbyte*)ptr)[8] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[8])
			{
				return;
			}
			*(int*)ptr = 0;
			while (true)
			{
				((sbyte*)ptr)[12] = ((*(int*)ptr <= G54Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[12] == 0)
				{
					break;
				}
				((sbyte*)ptr)[9] = ((*(int*)ptr <= 9) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[9])
				{
					writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].X, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392409)));
					do
					{
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].Y, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392404)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].Z, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392431)));
						((sbyte*)ptr)[10] = (WriteABC ? ((sbyte)1) : ((sbyte)0));
						if (((sbyte*)ptr)[10] == 0)
						{
							break;
						}
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].A, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392426)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].B, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392421)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].C, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392416)));
					}
					while (-1 == 0);
					((sbyte*)ptr)[11] = (WriteUVW ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[11])
					{
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].U, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392379)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].V, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392374)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].W, global::_0006._0008(PathString, _0090(107392434), ((int*)ptr)->ToString(), _0090(107392369)));
					}
				}
				(*(int*)ptr)++;
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[1] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392483), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[1], ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteIOData(CodesysMachine cMachine)
	{
		void* ptr = stackalloc byte[15];
		try
		{
			((sbyte*)ptr)[12] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[12])
			{
				return;
			}
			*(int*)ptr = 0;
			while (true)
			{
				((sbyte*)ptr)[13] = ((*(int*)ptr <= cMachine.Inputs.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[13] == 0)
				{
					break;
				}
				writeDINTVar(CodesysVariableBaseType.None, cMachine.Inputs[*(int*)ptr].SourceIndex, global::_0003._0005(cMachine.Inputs[*(int*)ptr].FullAddress, _0090(107393113)));
				writeBOOLVar(CodesysVariableBaseType.None, cMachine.Inputs[*(int*)ptr].Invert, global::_0003._0005(cMachine.Inputs[*(int*)ptr].FullAddress, _0090(107393128)));
				(*(int*)ptr)++;
			}
			((int*)ptr)[1] = 0;
			while (true)
			{
				((sbyte*)ptr)[14] = ((((int*)ptr)[1] <= cMachine.Outputs.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[14])
				{
					writeDINTVar(CodesysVariableBaseType.None, cMachine.Outputs[((int*)ptr)[1]].SourceIndex, global::_0003._0005(cMachine.Outputs[((int*)ptr)[1]].FullAddress, _0090(107393113)));
					writeBOOLVar(CodesysVariableBaseType.None, cMachine.Outputs[((int*)ptr)[1]].Invert, global::_0003._0005(cMachine.Outputs[((int*)ptr)[1]].FullAddress, _0090(107393128)));
					((int*)ptr)[1]++;
					continue;
				}
				break;
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[2] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107392396), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[2], ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteParkData(string PathString, int G54Count, bool WriteABC, bool WriteUVW, Pnt9DS[] G54List)
	{
		void* ptr = stackalloc byte[13];
		try
		{
			((sbyte*)ptr)[8] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[8])
			{
				return;
			}
			*(int*)ptr = 0;
			while (true)
			{
				((sbyte*)ptr)[12] = ((*(int*)ptr <= G54Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[12] == 0)
				{
					break;
				}
				((sbyte*)ptr)[9] = ((*(int*)ptr <= 9) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[9])
				{
					writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].X, global::_0006._0008(PathString, _0090(107391835), ((int*)ptr)->ToString(), _0090(107392409)));
					do
					{
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].Y, global::_0006._0008(PathString, _0090(107391835), ((int*)ptr)->ToString(), _0090(107392404)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].Z, global::_0006._0008(PathString, _0090(107391835), ((int*)ptr)->ToString(), _0090(107392431)));
						((sbyte*)ptr)[10] = (WriteABC ? ((sbyte)1) : ((sbyte)0));
						if (((sbyte*)ptr)[10] == 0)
						{
							break;
						}
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].A, global::_0006._0008(PathString, _0090(107391835), ((int*)ptr)->ToString(), _0090(107392426)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].B, global::_0006._0008(PathString, _0090(107391835), ((int*)ptr)->ToString(), _0090(107392421)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].C, global::_0006._0008(PathString, _0090(107391835), ((int*)ptr)->ToString(), _0090(107392416)));
					}
					while (-1 == 0);
					((sbyte*)ptr)[11] = (WriteUVW ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[11])
					{
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].U, global::_0006._0008(PathString, _0090(107391835), ((int*)ptr)->ToString(), _0090(107392379)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].V, global::_0006._0008(PathString, _0090(107391835), ((int*)ptr)->ToString(), _0090(107392374)));
						writeLREALVar(CodesysVariableBaseType.None, G54List[*(int*)ptr].W, global::_0006._0008(PathString, _0090(107391835), ((int*)ptr)->ToString(), _0090(107392369)));
					}
				}
				(*(int*)ptr)++;
			}
		}
		catch (Exception ee)
		{
			((int*)ptr)[1] = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107391842), message, _0090(107397045), _0090(107397099), _0090(107397099), ((int*)ptr)[1], ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteToolData(string PathString, ToolBase ToolData)
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				do
				{
					WriteToolData(PathString, ToolData, WriteDiameter: true, WriteLenght: true, WriteThickness: true, WriteSpindleSpeed: true, WriteFeed: true, WriteMinLength: true, WriteNo: true, WriteClone: true, WriteBroken: true, WriteAngularPos: true, WritePosition: true, WriteOffset: true, WriteName: true);
				}
				while (false);
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			while (true)
			{
				string message = _0090(107397099);
				CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107391821), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
				global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
				while (8u != 0)
				{
					if (0 == 0)
					{
						return;
					}
				}
			}
		}
	}

	public unsafe void WriteToolData(string PathString, ToolBase ToolData, bool WriteDiameter, bool WriteLenght, bool WriteThickness, bool WriteSpindleSpeed, bool WriteFeed, bool WriteMinLength, bool WriteNo, bool WriteClone, bool WriteBroken, bool WriteAngularPos, bool WritePosition, bool WriteOffset, bool WriteName)
	{
		void* ptr = stackalloc byte[18];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				((sbyte*)ptr)[5] = (WriteDiameter ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[5])
				{
					writeLREALVar(CodesysVariableBaseType.None, ToolData.Geometry.Diameter, global::_0003._0005(PathString, _0090(107391768)));
				}
				((sbyte*)ptr)[6] = (WriteLenght ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[6])
				{
					writeLREALVar(CodesysVariableBaseType.None, ToolData.Geometry.Length, global::_0003._0005(PathString, _0090(107391787)));
				}
				((sbyte*)ptr)[7] = (WriteThickness ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[7])
				{
					writeLREALVar(CodesysVariableBaseType.None, ToolData.Geometry.Thickness, global::_0003._0005(PathString, _0090(107391742)));
				}
				((sbyte*)ptr)[8] = (WriteSpindleSpeed ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[8])
				{
					writeLREALVar(CodesysVariableBaseType.None, ToolData.CamData.SpindleSpeed, global::_0003._0005(PathString, _0090(107391757)));
				}
				((sbyte*)ptr)[9] = (WriteFeed ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[9])
				{
					writeLREALVar(CodesysVariableBaseType.None, ToolData.CamData.FeedSpeed, global::_0003._0005(PathString, _0090(107391704)));
				}
				((sbyte*)ptr)[10] = (WriteMinLength ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[10])
				{
					writeLREALVar(CodesysVariableBaseType.None, ToolData.Geometry.MinLength, global::_0003._0005(PathString, _0090(107391719)));
				}
				((sbyte*)ptr)[11] = (WriteNo ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[11])
				{
					writeDINTVar(CodesysVariableBaseType.None, ToolData.Data.No, global::_0003._0005(PathString, _0090(107391670)));
				}
				((sbyte*)ptr)[12] = (WriteClone ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[12])
				{
					writeBOOLVar(CodesysVariableBaseType.None, ToolData.Data.Clone, global::_0003._0005(PathString, _0090(107391665)));
				}
				((sbyte*)ptr)[13] = (WriteBroken ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[13])
				{
					writeBOOLVar(CodesysVariableBaseType.None, ToolData.Data.Broken, global::_0003._0005(PathString, _0090(107391688)));
				}
				((sbyte*)ptr)[14] = (WriteAngularPos ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[14])
				{
					writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.AngularPosition, global::_0003._0005(PathString, _0090(107391643)));
				}
				((sbyte*)ptr)[15] = (WritePosition ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[15])
				{
					writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Position.X, global::_0003._0005(PathString, _0090(107391650)));
					writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Position.Y, global::_0003._0005(PathString, _0090(107391601)));
					writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Position.Z, global::_0003._0005(PathString, _0090(107391616)));
				}
				((sbyte*)ptr)[16] = (WriteOffset ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[16])
				{
					writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Offset.X, global::_0003._0005(PathString, _0090(107392111)));
					writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Offset.Y, global::_0003._0005(PathString, _0090(107392098)));
					writeLREALVar(CodesysVariableBaseType.None, ToolData.Positions.Offset.Z, global::_0003._0005(PathString, _0090(107392053)));
				}
				((sbyte*)ptr)[17] = (WriteName ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[17])
				{
					writeSTRINGVar(CodesysVariableBaseType.None, ToolData.Data.Name, global::_0003._0005(PathString, _0090(107392072)));
				}
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107391821), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public unsafe void WriteKinematicData(string PathString, KinematicBase Kinematic)
	{
		void* ptr = stackalloc byte[5];
		try
		{
			((sbyte*)ptr)[4] = ((!AppBool.Connected) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[4] == 0)
			{
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetXYZ.X, global::_0003._0005(PathString, _0090(107392031)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetXYZ.Y, global::_0003._0005(PathString, _0090(107392046)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetXYZ.Z, global::_0003._0005(PathString, _0090(107391997)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetABC.A, global::_0003._0005(PathString, _0090(107392012)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetABC.B, global::_0003._0005(PathString, _0090(107391963)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.OffsetABC.C, global::_0003._0005(PathString, _0090(107391978)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfA.X, global::_0003._0005(PathString, _0090(107391929)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfA.Y, global::_0003._0005(PathString, _0090(107391896)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfA.Z, global::_0003._0005(PathString, _0090(107391863)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfB.X, global::_0003._0005(PathString, _0090(107391318)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfB.Y, global::_0003._0005(PathString, _0090(107391285)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfB.Z, global::_0003._0005(PathString, _0090(107391252)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfC.X, global::_0003._0005(PathString, _0090(107391219)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfC.Y, global::_0003._0005(PathString, _0090(107391186)));
				writeLREALVar(CodesysVariableBaseType.None, Kinematic.RotateCenterOffsetOfC.Z, global::_0003._0005(PathString, _0090(107391153)));
			}
		}
		catch (Exception ee)
		{
			*(int*)ptr = 0;
			string message = _0090(107397099);
			CalculationErrorEventArg calculationErrorEventArg = new CalculationErrorEventArg(showmessage: true, _0090(107391120), message, _0090(107397045), _0090(107397099), _0090(107397099), *(int*)ptr, ee);
			global::_0005._0007(calculationErrorEventArg, calculationErrorEventArg.ShowMessageBox);
		}
	}

	public void CreateAxesParFileItems(CodesysAxesData Axis, string AxisTag, ref List<string> AxisList)
	{
		AxisList.Add(_0090(107391095) + AxisTag + _0090(107391090));
		AxisList.Add(_0090(107391117) + Axis.AxisPar.Jogs.jogVelocity + _0090(107391108) + Axis.AxisPar.Jogs.jogAcc + _0090(107391108) + Axis.AxisPar.Jogs.jogDec + _0090(107391108) + Axis.AxisPar.Jogs.jogJerk + _0090(107391108) + Axis.AxisPar.Jogs.jogDynamicVelocityFromFeed + _0090(107391108) + Axis.AxisPar.Jogs.jogWithAbsoluteMove + _0090(107391108) + Axis.AxisPar.Jogs.jogOverrideEnable + _0090(107391108) + Axis.AxisPar.Jogs.jogFirstSpeedPersentage + _0090(107391108) + Axis.AxisPar.Jogs.jogSecondSpeedPersentage + _0090(107391108) + Axis.AxisPar.Jogs.jogFirstSpeedTimeSec + _0090(107391108) + Axis.AxisPar.Jogs.jogSecondSpeedTimeSec);
		AxisList.Add(_0090(107391583) + Axis.AxisPar.Moves.moveVelocity + _0090(107391108) + Axis.AxisPar.Moves.moveAcc + _0090(107391108) + Axis.AxisPar.Moves.moveDec + _0090(107391108) + Axis.AxisPar.Moves.moveJerk + _0090(107391108) + Axis.AxisPar.Moves.moveDynamicVelocityFromFeed + _0090(107391108) + Axis.AxisPar.Moves.moveOverrideEnable);
		AxisList.Add(_0090(107391574) + Axis.AxisPar.Homings.homingFastVelocity + _0090(107391108) + Axis.AxisPar.Homings.homingSlowVelocity + _0090(107391108) + Axis.AxisPar.Homings.homingSetPosition + _0090(107391108) + Axis.AxisPar.Homings.homingOffset + _0090(107391108) + Axis.AxisPar.Homings.homingAcc + _0090(107391108) + Axis.AxisPar.Homings.homingDec + _0090(107391108) + Axis.AxisPar.Homings.homingJerk + _0090(107391108) + Axis.AxisPar.Homings.homingDelay + _0090(107391108) + Axis.AxisPar.Homings.homingTimeoutSec + _0090(107391108) + Axis.AxisPar.Homings.homingMode.ToString() + _0090(107391108) + Axis.AxisPar.Homings.homingMethod.ToString() + _0090(107391108) + Axis.AxisPar.Homings.homingDriveHomeMode + _0090(107391108) + Axis.AxisPar.Homings.homingReverseDir + _0090(107391108) + Axis.AxisPar.Homings.homingSwitchNC + _0090(107391108) + Axis.AxisPar.Homings.homingDisableLimits + _0090(107391108) + Axis.AxisPar.Homings.homingUseSecondSlowSpeed + _0090(107391108) + Axis.AxisPar.Homings.homingAbsoluteHomePosition);
		AxisList.Add(_0090(107391593) + Axis.AxisPar.Sets.setUnit + _0090(107391108) + Axis.AxisPar.Sets.setPulse + _0090(107391108) + Axis.AxisPar.Sets.setGearRatio + _0090(107391108) + Axis.AxisPar.Sets.setReverseDirection + _0090(107391108) + Axis.AxisPar.Sets.setEmergencyDec + _0090(107391108) + Axis.AxisPar.Sets.setMaxVelocity + _0090(107391108) + Axis.AxisPar.Sets.setMaxAcc + _0090(107391108) + Axis.AxisPar.Sets.setMaxDec + _0090(107391108) + Axis.AxisPar.Sets.setMaxJerk + _0090(107391108) + Convert.ToInt32(Axis.AxisPar.Sets.setRampType) + _0090(107391108) + Axis.AxisPar.Sets.setSoftLimitEnable + _0090(107391108) + Axis.AxisPar.Sets.setSoftLimitControlFromPLC + _0090(107391108) + Axis.AxisPar.Sets.setSoftLimitNegative + _0090(107391108) + Axis.AxisPar.Sets.setSoftLimitPositive + _0090(107391108) + Axis.AxisPar.Sets.setSoftLimitErrorDec + _0090(107391108) + Axis.AxisPar.Sets.setSoftLimitErrorDecEnable + _0090(107391108) + Axis.AxisPar.Sets.setSoftLimitErrorMaxDistance + _0090(107391108) + Axis.AxisPar.Sets.setHardLimitEnable + _0090(107391108) + Axis.AxisPar.Sets.setDataLimitNegative + _0090(107391108) + Axis.AxisPar.Sets.setDataLimitPositive + _0090(107391108) + Axis.AxisPar.Sets.setParkPosition + _0090(107391108) + Axis.AxisPar.Sets.setGantryEnable + _0090(107391108) + Axis.AxisPar.Sets.setGantryNumerator + _0090(107391108) + Axis.AxisPar.Sets.setGantryDenumerator + _0090(107391108) + Convert.ToInt32(Axis.AxisPar.Sets.setAxesType));
		AxisList.Add(_0090(107391584) + Axis.AxisPar.Base.baseChar + _0090(107391108) + Axis.AxisPar.Base.baseName + _0090(107391108) + Axis.AxisPar.Base.baseNo + _0090(107391108) + Axis.AxisPar.Base.baseRotaryAxis + _0090(107391108) + Axis.AxisPar.Base.baseUnit);
		AxisList.Add(_0090(107391543) + Axis.AxisPar.Gear.gearNumerator + _0090(107391108) + Axis.AxisPar.Gear.gearDenominator + _0090(107391108) + Axis.AxisPar.Gear.gearAcc + _0090(107391108) + Axis.AxisPar.Gear.gearDec + _0090(107391108) + Axis.AxisPar.Gear.gearJerk);
		AxisList.Add(_0090(107391566) + Axis.AxisPar.Cnc.cncMaxFeed + _0090(107391108) + Axis.AxisPar.Cnc.cncMaxAccDec + _0090(107391108) + Axis.AxisPar.Cnc.cncMaxDifferance + _0090(107391108) + Axis.AxisPar.Cnc.cncIncludePathSettings + _0090(107391108) + Axis.AxisPar.Cnc.cncStrictlyHoldAccDecABC);
		AxisList.Add(_0090(107391557) + Axis.AxisPar.MiscSet.TestPosition1 + _0090(107391108) + Axis.AxisPar.MiscSet.TestPosition2 + _0090(107391108) + Axis.AxisPar.MiscSet.TestReleativePosition + _0090(107391108) + Axis.AxisPar.MiscSet.TestWaitTime);
		AxisList.Add(_0090(107391516) + AxisTag + _0090(107391090));
	}

	public unsafe void CreateCodesysDefaultParameters(List<DefaultParameter> Parameters, string FileName, ref List<string> listParameters)
	{
		void* ptr = stackalloc byte[11];
		listParameters.Clear();
		*(int*)ptr = 0;
		while (true)
		{
			((sbyte*)ptr)[9] = ((*(int*)ptr <= Parameters.Count - 1) ? ((sbyte)1) : ((sbyte)0));
			if (((sbyte*)ptr)[9] == 0)
			{
				((sbyte*)ptr)[10] = ((FileName.Length > 0) ? ((sbyte)1) : ((sbyte)0));
				if (0 == 0)
				{
					break;
				}
			}
			List<VariableDef> getVars = new List<VariableDef>();
			GetClassToVariables(Parameters[*(int*)ptr].Parameter, ref getVars);
			((int*)ptr)[1] = 0;
			while (true)
			{
				((sbyte*)ptr)[8] = ((((int*)ptr)[1] <= getVars.Count - 1) ? ((sbyte)1) : ((sbyte)0));
				if (((sbyte*)ptr)[8] == 0)
				{
					break;
				}
				string item = Parameters[*(int*)ptr].Defination + getVars[((int*)ptr)[1]].Name + _0090(107391511) + getVars[((int*)ptr)[1]].Value.ToString() + _0090(107391108);
				listParameters.Add(item);
				((int*)ptr)[1]++;
			}
			listParameters.Add(_0090(107395382));
			(*(int*)ptr)++;
		}
		if (((bool*)ptr)[10])
		{
			buFile.SaveToFile(listParameters, FileName);
		}
	}

	public unsafe void CreateCodesysDefaultParameters(object Parameters, string FileName, ref List<string> listParameters)
	{
		void* ptr = stackalloc byte[6];
		List<VariableDef> getVars = new List<VariableDef>();
		listParameters.Clear();
		GetClassToVariables(Parameters, ref getVars);
		if (true)
		{
			*(int*)ptr = 0;
			goto IL_0085;
		}
		goto IL_00f9;
		IL_00f9:
		string item = getVars[*(int*)ptr].Name + _0090(107391511) + getVars[*(int*)ptr].Value.ToString();
		listParameters.Add(item);
		while (-1 == 0)
		{
		}
		(*(int*)ptr)++;
		goto IL_0085;
		IL_0085:
		((sbyte*)ptr)[4] = ((*(int*)ptr <= getVars.Count - 1) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[4])
		{
			goto IL_00f9;
		}
		((sbyte*)ptr)[5] = ((FileName.Length > 0) ? ((sbyte)1) : ((sbyte)0));
		if (((bool*)ptr)[5])
		{
			buFile.SaveToFile(listParameters, FileName);
		}
	}

	public unsafe static int GetClassToVariables(object Variable, ref List<VariableDef> getVars)
	{
		int num = 65;
		if (num != 0)
		{
			void* ptr = stackalloc byte[num];
			((int*)ptr)[10] = Environment.TickCount;
			try
			{
				((sbyte*)ptr)[52] = ((Variable == null) ? ((sbyte)1) : ((sbyte)0));
				FieldInfo[] array;
				object obj;
				if (((bool*)ptr)[52])
				{
					if (false)
					{
						goto IL_0263;
					}
					MessageBox.Show(_0090(107391534));
					((int*)ptr)[11] = -1;
				}
				else
				{
					array = null;
					obj = null;
					obj = Variable;
					if (6 == 0)
					{
						goto IL_01a5;
					}
					((sbyte*)ptr)[53] = ((obj != null) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[53])
					{
						goto IL_0087;
					}
					((int*)ptr)[11] = -1;
				}
				goto end_IL_001f;
				IL_030e:
				((sbyte*)ptr)[64] = ((((int*)ptr)[12] <= array.Length - 1) ? ((sbyte)1) : ((sbyte)0));
				string name = default(string);
				object obj2 = default(object);
				sbyte num2;
				if (((bool*)ptr)[64])
				{
					obj2 = null;
					if (3 == 0)
					{
						goto IL_0087;
					}
					FieldInfo fieldInfo = array[((int*)ptr)[12]];
					name = fieldInfo.Name;
					string name2 = fieldInfo.Name;
					((sbyte*)ptr)[55] = ((fieldInfo.FieldType.ToString().IndexOf(_0090(107391493)) < 0) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[55])
					{
						obj2 = fieldInfo.GetValue(obj);
						((sbyte*)ptr)[56] = ((fieldInfo.FieldType.BaseType == typeof(Enum)) ? ((sbyte)1) : ((sbyte)0));
						num2 = ((sbyte*)ptr)[56];
						goto IL_013a;
					}
					goto IL_0301;
				}
				goto IL_0339;
				IL_0087:
				array = obj.GetType().GetFields();
				((sbyte*)ptr)[54] = ((array != null) ? ((sbyte)1) : ((sbyte)0));
				num2 = ((sbyte*)ptr)[54];
				if (false)
				{
					goto IL_013a;
				}
				if (num2 != 0)
				{
					((int*)ptr)[12] = 0;
					goto IL_030e;
				}
				goto IL_0339;
				IL_013a:
				if (num2 != 0)
				{
					*(double*)ptr = Convert.ToInt32(obj2);
					getVars.Add(new VariableDef(name, *(double*)ptr));
				}
				((sbyte*)ptr)[57] = ((obj2.GetType() == typeof(double)) ? ((sbyte)1) : ((sbyte)0));
				sbyte num3 = ((sbyte*)ptr)[57];
				if (7u != 0)
				{
					if (num3 != 0)
					{
						((double*)ptr)[1] = Convert.ToDouble(obj2);
						getVars.Add(new VariableDef(name, ((double*)ptr)[1]));
					}
					goto IL_01a5;
				}
				goto IL_01c4;
				IL_0301:
				((int*)ptr)[12]++;
				goto IL_030e;
				IL_0263:
				getVars.Add(new VariableDef(name, ((double*)ptr)[4]));
				goto IL_027d;
				IL_027d:
				((sbyte*)ptr)[61] = ((obj2.GetType() == typeof(bool)) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[61])
				{
					((sbyte*)ptr)[62] = (Convert.ToBoolean(obj2) ? ((sbyte)1) : ((sbyte)0));
					getVars.Add(new VariableDef(name, ((bool*)ptr)[62]));
				}
				((sbyte*)ptr)[63] = ((obj2.GetType() == typeof(string)) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[63])
				{
					string val = Convert.ToString(obj2);
					getVars.Add(new VariableDef(name, val));
				}
				goto IL_0301;
				IL_0339:
				((int*)ptr)[11] = 1;
				goto end_IL_001f;
				IL_01c4:
				if (num3 != 0)
				{
					((double*)ptr)[2] = Convert.ToSingle(obj2);
					getVars.Add(new VariableDef(name, ((double*)ptr)[2]));
				}
				((sbyte*)ptr)[59] = ((obj2.GetType() == typeof(int)) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[59])
				{
					((double*)ptr)[3] = Convert.ToInt32(obj2);
					getVars.Add(new VariableDef(name, ((double*)ptr)[3]));
				}
				((sbyte*)ptr)[60] = ((obj2.GetType() == typeof(short)) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[60])
				{
					((double*)ptr)[4] = Convert.ToInt16(obj2);
					goto IL_0263;
				}
				goto IL_027d;
				IL_01a5:
				((sbyte*)ptr)[58] = ((obj2.GetType() == typeof(float)) ? ((sbyte)1) : ((sbyte)0));
				num3 = ((sbyte*)ptr)[58];
				goto IL_01c4;
				end_IL_001f:;
			}
			catch (Exception mSException)
			{
				string auxMessage = _0090(107391452) + Variable.ToString();
				buException.throwException(mSException, _0090(107391467), ShowMessageBox: false, auxMessage);
				do
				{
					((int*)ptr)[11] = -1;
				}
				while (-1 == 0);
			}
			num = ((int*)ptr)[11];
		}
		return num;
	}

	public unsafe static void OpenRuntimeMachine(ref setMotionRuntimeVar varRuntime)
	{
		void* ptr = stackalloc byte[4];
		string text = _0090(107391418);
		try
		{
			FileInfo fileInfo = null;
			DirectoryInfo directoryInfo = null;
			fileInfo = new FileInfo(global::_0003._0005(AppPath.Base, _0090(107391425)));
			*(bool*)ptr = global::_0089._007E_0001_0002(fileInfo);
			if (*(bool*)ptr)
			{
				AppBool.Offline = true;
			}
			directoryInfo = new DirectoryInfo(AppPath.Base);
			((sbyte*)ptr)[1] = ((!global::_0089._007E_0001_0002(directoryInfo)) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[1])
			{
				if (false)
				{
					return;
				}
				global::_008A._0003_0002(_0001, text, _0090(107397099), _0090(107391404), _0090(107397099), 0.0, 0.0, false);
				global::_007F._0097(_0090(107391404));
			}
			string fileName = global::_0003._0005(AppPath.Settings, _0090(107391347));
			fileInfo = new FileInfo(fileName);
			((sbyte*)ptr)[2] = (global::_0089._007E_0001_0002(fileInfo) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[2])
			{
				ArrayList arrayList = new ArrayList();
				TextReader textReader = global::_008B._0004_0002(global::_0010._007E_0017(fileInfo));
				string text2 = _0090(107397099);
				while ((text2 = global::_0010._007E_0018(textReader)) != null)
				{
					global::_008C._007E_0005_0002(arrayList, text2);
				}
				global::_001C._007E_008F(textReader);
				global::_008A._0003_0002(_0001, text, _0090(107397099), _0090(107391362), _0090(107397099), 0.0, 0.0, false);
				try
				{
					global::_008D._0006_0002(arrayList, _0090(107397099), SerilizationMode.MultiLine, varRuntime);
					((sbyte*)ptr)[3] = ((varRuntime.MachineID <= 0) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[3])
					{
						goto IL_0233;
					}
					goto IL_024e;
					IL_0233:
					global::_008E._0007_0002(_0090(107390821));
					goto IL_024e;
					IL_024e:
					global::_008A._0003_0002(_0001, text, _0090(107397099), _0090(107390788), _0090(107397099), 0.0, 0.0, false);
					if (3u != 0)
					{
						AppPath.Machine = global::_0002._0003(AppPath.Base, _0090(107390715), varRuntime.MachineID.ToString());
						AppPath.MachineSettings = global::_0003._0005(AppPath.Machine, _0090(107390730));
						AppPath.MachineJob = global::_0003._0005(AppPath.Machine, _0090(107390685));
						AppPath.MachineTool = global::_0003._0005(AppPath.Machine, _0090(107390676));
						AppPath.MachineCounter = global::_0003._0005(AppPath.Machine, _0090(107390699));
						AppPath.MachineBackup = global::_0003._0005(AppPath.Machine, _0090(107390654));
						AppPath.MachineKinematic = global::_0003._0005(AppPath.Machine, _0090(107390641));
						AppPath.MachinePostProcessor = global::_0003._0005(AppPath.Machine, _0090(107390656));
						return;
					}
					goto IL_0233;
				}
				catch (Exception ex)
				{
					global::_008A._0003_0002(_0001, text, _0090(107397099), _0090(107390615), _0090(107397099), 0.0, 0.0, false);
					global::_0017._0083(ex, global::_0010._007E_0014(global::_0016._0082()), true, _0090(107390602));
					return;
				}
			}
			global::_008A._0003_0002(_0001, text, _0090(107397099), _0090(107391061), _0090(107397099), 0.0, 0.0, false);
			global::_007F._0097(_0090(107391032));
		}
		catch (Exception ex2)
		{
			global::_008A._0003_0002(_0001, text, _0090(107395421), _0090(107397099), _0090(107397099), 0.0, 0.0, false);
			global::_0017._0083(ex2, text, true, _0090(107397099));
		}
	}

	public unsafe static void LoadMotionLanguage(int Language, bool DeveloperPCMode)
	{
		byte* num = stackalloc byte[2];
		void* ptr = default(void*);
		if (0 == 0)
		{
			ptr = num;
		}
		string text = _0090(107390971);
		try
		{
			FileInfo fileInfo = null;
			*(bool*)ptr = !DeveloperPCMode;
			fileInfo = ((*(sbyte*)ptr == 0) ? new FileInfo(_0090(107390957)) : new FileInfo(global::_0003._0005(AppPath.Language, _0090(107390978))));
			((sbyte*)ptr)[1] = (global::_0089._007E_0001_0002(fileInfo) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[1])
			{
				List<string> list = new List<string>();
				List<string> list2 = new List<string>();
				List<string> list3 = new List<string>();
				List<string> list4 = new List<string>();
				List<string> list5 = new List<string>();
				List<string> list6 = new List<string>();
				AppLanguage.SystemStatus.Clear();
				AppLanguage.SystemMessages.Clear();
				AppLanguage.SystemError.Clear();
				AppLanguage.SystemWarning.Clear();
				AppLanguage.AxesError.Clear();
				AppLanguage.AxesWarning.Clear();
				List<string> list7 = new List<string>();
				global::_008F._0008_0002(global::_0010._007E_0017(fileInfo), ref list7);
				global::_0091._000F_0002(global::_0090._000E_0002(_0090(107390844), _0090(107390863), list7), Language, ref AppLanguage.SystemMessages);
				global::_0091._000F_0002(global::_0090._000E_0002(_0090(107390302), _0090(107390289), list7), Language, ref AppLanguage.SystemStatus);
				global::_0091._000F_0002(global::_0090._000E_0002(_0090(107390308), _0090(107390263), list7), Language, ref AppLanguage.SystemError);
				global::_0091._000F_0002(global::_0090._000E_0002(_0090(107390282), _0090(107390237), list7), Language, ref AppLanguage.SystemWarning);
				global::_0091._000F_0002(global::_0090._000E_0002(_0090(107390252), _0090(107390203), list7), Language, ref AppLanguage.AxesError);
				global::_0091._000F_0002(global::_0090._000E_0002(_0090(107390218), _0090(107390165), list7), Language, ref AppLanguage.AxesWarning);
				list7.Clear();
				buMotionLangDefination.LoadStatus(AppLanguage.SystemStatus);
				buMotionLangDefination.LoadAxisError(AppLanguage.AxesError);
				buMotionLangDefination.LoadAxisWarning(AppLanguage.AxesWarning);
				if (8u != 0)
				{
					buMotionLangDefination.LoadError(AppLanguage.SystemError);
					buMotionLangDefination.LoadMessage(AppLanguage.SystemMessages);
					buMotionLangDefination.LoadWarning(AppLanguage.SystemWarning);
				}
				global::_008A._0003_0002(_0001, text, _0090(107397099), _0090(107390176), _0090(107397099), 0.0, 0.0, false);
				if (5u != 0)
				{
					return;
				}
			}
			global::_008A._0003_0002(_0001, text, _0090(107397099), _0090(107390111), _0090(107397099), 0.0, 0.0, false);
			global::_007F._0097(_0090(107390070));
		}
		catch (Exception ex)
		{
			if (0 == 0)
			{
				global::_008A._0003_0002(_0001, text, _0090(107395421), _0090(107397099), _0090(107397099), 0.0, 0.0, false);
				global::_0017._0083(ex, text, true, _0090(107397099));
			}
		}
	}

	public unsafe string readVar(CodesysVariableBaseType BaseType, VariableType VarType, string Address, ref object Val)
	{
		void* ptr = stackalloc byte[72];
		string text = _0090(107390573);
		try
		{
			string text2 = global::_0003._0005(_0090(107390524), Address);
			((sbyte*)ptr)[40] = (AppBool.Connected ? ((sbyte)1) : ((sbyte)0));
			if (false)
			{
				goto IL_055b;
			}
			string text3;
			if (((bool*)ptr)[40])
			{
				text3 = _0090(107397099);
				((sbyte*)ptr)[41] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[41])
				{
					((sbyte*)ptr)[42] = ((BaseType == CodesysVariableBaseType.Global) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[42])
					{
						text3 = CodesysMachine.RootGlobalString;
					}
					((sbyte*)ptr)[43] = ((BaseType == CodesysVariableBaseType.Persistent) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[43])
					{
						text3 = CodesysMachine.RootPersistentString;
					}
					((sbyte*)ptr)[44] = ((BaseType == CodesysVariableBaseType.IO) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[44])
					{
						text3 = CodesysMachine.RootIOString;
					}
					((sbyte*)ptr)[45] = ((BaseType == CodesysVariableBaseType.CNC) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[45])
					{
						text3 = CodesysMachine.RootCNCString;
					}
					text3 = global::_0003._0005(text3, Address);
					((int*)ptr)[4] = 1;
					((sbyte*)ptr)[46] = ((global::_0013._007E_001D(text3) > 1) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[46])
					{
						((sbyte*)ptr)[47] = ((VarType == VariableType.DINT) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[47])
						{
							((int*)ptr)[5] = 0;
							((int*)ptr)[4] = global::_0092._0010_0002(text3, ref *(int*)((byte*)ptr + 20));
							Val = ((int*)ptr)[5];
						}
						((sbyte*)ptr)[48] = ((VarType == VariableType.INT) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[48])
						{
							((short*)ptr)[18] = 0;
							((int*)ptr)[4] = global::_0093._0011_0002(text3, ref *(short*)((byte*)ptr + 36));
							Val = ((short*)ptr)[18];
						}
						((sbyte*)ptr)[49] = ((VarType == VariableType.REAL) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[49])
						{
							((float*)ptr)[6] = 0f;
							((int*)ptr)[4] = global::_0094._0012_0002(text3, ref *(float*)((byte*)ptr + 24));
							Val = ((float*)ptr)[6];
						}
						((sbyte*)ptr)[50] = ((VarType == VariableType.LREAL) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[50])
						{
							*(double*)ptr = 0.0;
							((int*)ptr)[4] = global::_0095._0013_0002(text3, ref *(double*)ptr);
							Val = *(double*)ptr;
						}
						((sbyte*)ptr)[51] = ((VarType == VariableType.Bool) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[51])
						{
							((sbyte*)ptr)[52] = 0;
							((int*)ptr)[4] = global::_0096._0014_0002(text3, ref *(bool*)((byte*)ptr + 52));
							Val = ((bool*)ptr)[52];
						}
						((sbyte*)ptr)[53] = ((VarType == VariableType.STRING) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[53])
						{
							string text4 = _0090(107397099);
							((int*)ptr)[4] = global::_0097._0015_0002(text3, ref text4);
							Val = text4;
						}
					}
					((sbyte*)ptr)[54] = ((((int*)ptr)[4] == 0) ? ((sbyte)1) : ((sbyte)0));
					text2 = ((((sbyte*)ptr)[54] == 0) ? global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), text3) : _0090(107396003));
				}
				else
				{
					((sbyte*)ptr)[55] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[55])
					{
						((sbyte*)ptr)[56] = ((BaseType == CodesysVariableBaseType.Global) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[56])
						{
							text3 = OpcVars.pathCodesysGvl;
						}
						((sbyte*)ptr)[57] = ((BaseType == CodesysVariableBaseType.Persistent) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[57])
						{
							text3 = OpcVars.pathCodesysPersistent;
						}
						((sbyte*)ptr)[58] = ((BaseType == CodesysVariableBaseType.IO) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[58])
						{
							text3 = OpcVars.pathCodesysIO;
						}
						((sbyte*)ptr)[59] = ((BaseType == CodesysVariableBaseType.CNC) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[59])
						{
							text3 = OpcVars.pathCodesysCNC;
						}
						text3 = global::_0003._0005(text3, Address);
						((sbyte*)ptr)[60] = ((global::_0013._007E_001D(text3) > 1) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[60])
						{
							((sbyte*)ptr)[61] = ((!global::_0089._007E_0002_0002(OpcVars.opcClient)) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[61])
							{
							}
							((sbyte*)ptr)[62] = ((VarType == VariableType.INT) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[62])
							{
								((short*)ptr)[19] = 0;
								text2 = global::_0098._0016_0002(global::_0086._007E_009D(OpcVars.opcClient), text3, ref *(short*)((byte*)ptr + 38));
								Val = ((short*)ptr)[19];
							}
							((sbyte*)ptr)[63] = ((VarType == VariableType.DINT) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[63])
							{
								((int*)ptr)[7] = 0;
								text2 = global::_0099._0017_0002(global::_0086._007E_009D(OpcVars.opcClient), text3, ref *(int*)((byte*)ptr + 28));
								Val = ((int*)ptr)[7];
							}
							((sbyte*)ptr)[64] = ((VarType == VariableType.REAL) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[64])
							{
								((float*)ptr)[8] = 0f;
								text2 = global::_009A._0018_0002(global::_0086._007E_009D(OpcVars.opcClient), text3, ref *(float*)((byte*)ptr + 32));
								Val = ((float*)ptr)[8];
							}
							((sbyte*)ptr)[65] = ((VarType == VariableType.LREAL) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[65])
							{
								((double*)ptr)[1] = 0.0;
								text2 = global::_009B._0019_0002(global::_0086._007E_009D(OpcVars.opcClient), text3, ref *(double*)((byte*)ptr + 8));
								Val = ((double*)ptr)[1];
							}
							((sbyte*)ptr)[66] = ((VarType == VariableType.Bool) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[66])
							{
								((sbyte*)ptr)[67] = 0;
								text2 = global::_009C._001A_0002(global::_0086._007E_009D(OpcVars.opcClient), text3, ref *(bool*)((byte*)ptr + 67));
								Val = ((bool*)ptr)[67];
							}
							((sbyte*)ptr)[68] = ((VarType == VariableType.STRING) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[68])
							{
								string text5 = _0090(107397099);
								text2 = global::_009D._001B_0002(global::_0086._007E_009D(OpcVars.opcClient), text3, ref text5);
								Val = text5;
							}
							((sbyte*)ptr)[69] = (global::_0014._007F(text2, _0090(107396003)) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[69])
							{
								goto IL_055b;
							}
						}
					}
					else
					{
						text2 = global::_0007._000E(new string[5]
						{
							buLangTranslate.preDef.Error,
							_0090(107390515),
							buLangTranslate.preDef.Unknown,
							_0090(107395382),
							buLangTranslate.preDef.Communication
						});
					}
				}
				goto IL_05da;
			}
			return global::_0007._000E(new string[5]
			{
				buLangTranslate.preDef.Error,
				_0090(107390515),
				buLangTranslate.preDef.Communication,
				_0090(107395382),
				buLangTranslate.preDef.Offline
			});
			IL_05da:
			((sbyte*)ptr)[70] = (global::_0014._007F(text2, _0090(107396003)) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[70])
			{
				((sbyte*)ptr)[71] = ((this._0001 != null) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[71])
				{
					MotionCommandEventArg motionCommandEventArg = new MotionCommandEventArg(MotionCommands.ShowWarning, text2, 0.0);
					global::_0088._007E_009F(this._0001, motionCommandEventArg);
				}
			}
			return text2;
			IL_055b:
			text2 = global::_0002._0003(text2, _0090(107397159), text3);
			goto IL_05da;
		}
		catch (Exception ex)
		{
			global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
			global::_0017._0083(ex, text, true, _0090(107397099));
			return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
		}
	}

	public string readDINTVar(CodesysVariableBaseType VarBaseType, string Address, ref int Val)
	{
		string text = _0090(107390573);
		try
		{
			object Val2 = null;
			string result = readVar(VarBaseType, VariableType.DINT, Address, ref Val2);
			int num = ((Val2 != null && global::_0002_0002._001F_0002(global::_009F._007E_001D_0002(Val2), global::_0001_0002._001E_0002(typeof(int).TypeHandle))) ? 1 : 0);
			do
			{
				bool flag = (byte)num != 0;
				num = (flag ? 1 : 0);
			}
			while (false);
			if (num != 0)
			{
				Val = global::_0003_0002._007F_0002(Val2);
			}
			else
			{
				result = global::_0007._000E(new string[5]
				{
					buLangTranslate.preDef.Type,
					_0090(107395382),
					buLangTranslate.preDef.Mismatch,
					_0090(107394248),
					Address
				});
			}
			return result;
		}
		catch (Exception ex)
		{
			if (2u != 0)
			{
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				global::_0017._0083(ex, text, true, _0090(107397099));
			}
			return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
		}
	}

	public string readINTVar(CodesysVariableBaseType VarBaseType, string Address, ref short Val)
	{
		string text = _0090(107390542);
		try
		{
			object Val2 = null;
			string result = readVar(VarBaseType, VariableType.INT, Address, ref Val2);
			int num = ((Val2 != null && global::_0002_0002._001F_0002(global::_009F._007E_001D_0002(Val2), global::_0001_0002._001E_0002(typeof(short).TypeHandle))) ? 1 : 0);
			do
			{
				bool flag = (byte)num != 0;
				num = (flag ? 1 : 0);
			}
			while (false);
			if (num != 0)
			{
				Val = global::_0004_0002._0080_0002(Val2);
			}
			else
			{
				result = global::_0007._000E(new string[5]
				{
					buLangTranslate.preDef.Type,
					_0090(107395382),
					buLangTranslate.preDef.Mismatch,
					_0090(107394248),
					Address
				});
			}
			return result;
		}
		catch (Exception ex)
		{
			if (2u != 0)
			{
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				global::_0017._0083(ex, text, true, _0090(107397099));
			}
			return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
		}
	}

	public string readREALVar(CodesysVariableBaseType VarBaseType, string Address, ref float Val)
	{
		string text = _0090(107390493);
		try
		{
			object Val2 = null;
			string result = readVar(VarBaseType, VariableType.REAL, Address, ref Val2);
			int num = ((Val2 != null && global::_0002_0002._001F_0002(global::_009F._007E_001D_0002(Val2), global::_0001_0002._001E_0002(typeof(float).TypeHandle))) ? 1 : 0);
			do
			{
				bool flag = (byte)num != 0;
				num = (flag ? 1 : 0);
			}
			while (false);
			if (num != 0)
			{
				Val = global::_0005_0002._0081_0002(Val2);
			}
			else
			{
				result = global::_0007._000E(new string[5]
				{
					buLangTranslate.preDef.Type,
					_0090(107395382),
					buLangTranslate.preDef.Mismatch,
					_0090(107394248),
					Address
				});
			}
			return result;
		}
		catch (Exception ex)
		{
			if (2u != 0)
			{
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				global::_0017._0083(ex, text, true, _0090(107397099));
			}
			return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
		}
	}

	public string readLREALVar(CodesysVariableBaseType VarBaseType, string Address, ref double Val)
	{
		string text = _0090(107390508);
		try
		{
			object Val2 = null;
			string result = readVar(VarBaseType, VariableType.LREAL, Address, ref Val2);
			int num = ((Val2 != null && global::_0002_0002._001F_0002(global::_009F._007E_001D_0002(Val2), global::_0001_0002._001E_0002(typeof(double).TypeHandle))) ? 1 : 0);
			do
			{
				bool flag = (byte)num != 0;
				num = (flag ? 1 : 0);
			}
			while (false);
			if (num != 0)
			{
				Val = global::_0006_0002._0082_0002(Val2);
			}
			else
			{
				result = global::_0007._000E(new string[5]
				{
					buLangTranslate.preDef.Type,
					_0090(107395382),
					buLangTranslate.preDef.Mismatch,
					_0090(107394248),
					Address
				});
			}
			return result;
		}
		catch (Exception ex)
		{
			if (2u != 0)
			{
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				global::_0017._0083(ex, text, true, _0090(107397099));
			}
			return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
		}
	}

	public string readBOOLVar(CodesysVariableBaseType VarBaseType, string Address, ref bool Val)
	{
		string text = _0090(107390459);
		try
		{
			object Val2 = null;
			string result = readVar(VarBaseType, VariableType.Bool, Address, ref Val2);
			int num = ((Val2 != null && global::_0002_0002._001F_0002(global::_009F._007E_001D_0002(Val2), global::_0001_0002._001E_0002(typeof(bool).TypeHandle))) ? 1 : 0);
			do
			{
				bool flag = (byte)num != 0;
				num = (flag ? 1 : 0);
			}
			while (false);
			if (num != 0)
			{
				Val = global::_0007_0002._0083_0002(Val2);
			}
			else
			{
				result = global::_0007._000E(new string[5]
				{
					buLangTranslate.preDef.Type,
					_0090(107395382),
					buLangTranslate.preDef.Mismatch,
					_0090(107394248),
					Address
				});
			}
			return result;
		}
		catch (Exception ex)
		{
			if (2u != 0)
			{
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				global::_0017._0083(ex, text, true, _0090(107397099));
			}
			return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
		}
	}

	public string readSTRINGVar(CodesysVariableBaseType VarBaseType, string Address, ref string Val)
	{
		string text = _0090(107390474);
		try
		{
			object Val2 = null;
			string result = readVar(VarBaseType, VariableType.STRING, Address, ref Val2);
			int num = ((Val2 != null && global::_0002_0002._001F_0002(global::_009F._007E_001D_0002(Val2), global::_0001_0002._001E_0002(typeof(string).TypeHandle))) ? 1 : 0);
			do
			{
				bool flag = (byte)num != 0;
				num = (flag ? 1 : 0);
			}
			while (false);
			if (num != 0)
			{
				Val = global::_0008_0002._0084_0002(Val2);
			}
			else
			{
				result = global::_0007._000E(new string[5]
				{
					buLangTranslate.preDef.Type,
					_0090(107395382),
					buLangTranslate.preDef.Mismatch,
					_0090(107394248),
					Address
				});
			}
			return result;
		}
		catch (Exception ex)
		{
			if (2u != 0)
			{
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				global::_0017._0083(ex, text, true, _0090(107397099));
			}
			return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
		}
	}

	public unsafe string writeVar(CodesysVariableBaseType VarBaseType, VariableType VarType, object Val, string Address)
	{
		void* ptr = stackalloc byte[53];
		string text = _0090(107390421);
		try
		{
			string text2 = global::_0003._0005(_0090(107390524), Address);
			((sbyte*)ptr)[22] = (AppBool.Connected ? ((sbyte)1) : ((sbyte)0));
			string text3;
			if (((bool*)ptr)[22])
			{
				text3 = _0090(107397099);
				((sbyte*)ptr)[23] = ((CodesysMachine.CommType == CommunicationType.PlcHandler) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[23])
				{
					((sbyte*)ptr)[24] = ((VarBaseType == CodesysVariableBaseType.Global) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[24])
					{
						text3 = CodesysMachine.RootGlobalString;
					}
					((sbyte*)ptr)[25] = ((VarBaseType == CodesysVariableBaseType.Persistent) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[25])
					{
						text3 = CodesysMachine.RootPersistentString;
					}
					((sbyte*)ptr)[26] = ((VarBaseType == CodesysVariableBaseType.IO) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[26])
					{
						text3 = CodesysMachine.RootIOString;
					}
					((sbyte*)ptr)[27] = ((VarBaseType == CodesysVariableBaseType.CNC) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[27])
					{
						text3 = CodesysMachine.RootCNCString;
					}
					text3 = global::_0003._0005(text3, Address);
					((int*)ptr)[2] = 1;
					((sbyte*)ptr)[28] = ((global::_0013._007E_001D(text3) > 1) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[28])
					{
						((sbyte*)ptr)[29] = ((VarType == VariableType.Bool) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[29])
						{
							((int*)ptr)[2] = global::_000E_0002._0086_0002(text3, Val);
						}
						((sbyte*)ptr)[30] = ((VarType == VariableType.INT) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[30])
						{
							((int*)ptr)[2] = global::_000E_0002._0087_0002(text3, Val);
						}
						((sbyte*)ptr)[31] = ((VarType == VariableType.DINT) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[31])
						{
							((int*)ptr)[2] = global::_000E_0002._0088_0002(text3, Val);
						}
						((sbyte*)ptr)[32] = ((VarType == VariableType.REAL) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[32])
						{
							((int*)ptr)[2] = global::_000E_0002._0089_0002(text3, Val);
						}
						((sbyte*)ptr)[33] = ((VarType == VariableType.LREAL) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[33])
						{
							((int*)ptr)[2] = global::_000E_0002._008A_0002(text3, Val);
						}
						((sbyte*)ptr)[34] = ((VarType == VariableType.STRING) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[34])
						{
							((int*)ptr)[2] = global::_000E_0002._008B_0002(text3, Val);
						}
					}
					((sbyte*)ptr)[35] = ((((int*)ptr)[2] == 0) ? ((sbyte)1) : ((sbyte)0));
					text2 = ((((sbyte*)ptr)[35] == 0) ? global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), text3) : _0090(107396003));
				}
				else
				{
					((sbyte*)ptr)[36] = ((CodesysMachine.CommType == CommunicationType.OPCUA) ? ((sbyte)1) : ((sbyte)0));
					if (((bool*)ptr)[36])
					{
						((sbyte*)ptr)[37] = ((VarBaseType == CodesysVariableBaseType.Global) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[37])
						{
							text3 = OpcVars.pathCodesysGvl;
						}
						((sbyte*)ptr)[38] = ((VarBaseType == CodesysVariableBaseType.Persistent) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[38])
						{
							text3 = OpcVars.pathCodesysPersistent;
						}
						((sbyte*)ptr)[39] = ((VarBaseType == CodesysVariableBaseType.IO) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[39])
						{
							text3 = OpcVars.pathCodesysIO;
						}
						((sbyte*)ptr)[40] = ((VarBaseType == CodesysVariableBaseType.CNC) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[40])
						{
							text3 = OpcVars.pathCodesysCNC;
						}
						text3 = global::_0003._0005(text3, Address);
						((sbyte*)ptr)[41] = ((global::_0013._007E_001D(text3) > 1) ? ((sbyte)1) : ((sbyte)0));
						if (((bool*)ptr)[41])
						{
							((sbyte*)ptr)[42] = ((!global::_0089._007E_0002_0002(OpcVars.opcClient)) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[42])
							{
							}
							((sbyte*)ptr)[43] = ((VarType == VariableType.DINT) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[43])
							{
								((int*)ptr)[3] = global::_0003_0002._007F_0002(Val);
								text2 = global::_000F_0002._008C_0002(((int*)ptr)[3], text3, global::_0086._007E_009D(OpcVars.opcClient));
							}
							((sbyte*)ptr)[44] = ((VarType == VariableType.INT) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[44])
							{
								((short*)ptr)[10] = global::_0004_0002._0080_0002(Val);
								text2 = global::_0010_0002._008D_0002(((short*)ptr)[10], text3, global::_0086._007E_009D(OpcVars.opcClient));
							}
							((sbyte*)ptr)[45] = ((VarType == VariableType.REAL) ? ((sbyte)1) : ((sbyte)0));
							if (((bool*)ptr)[45])
							{
								goto IL_0392;
							}
							goto IL_03c4;
						}
					}
					else
					{
						text2 = global::_0007._000E(new string[5]
						{
							buLangTranslate.preDef.Error,
							_0090(107390515),
							buLangTranslate.preDef.Unknown,
							_0090(107395382),
							buLangTranslate.preDef.Communication
						});
					}
				}
				goto IL_0558;
			}
			return global::_0007._000E(new string[5]
			{
				buLangTranslate.preDef.Error,
				_0090(107390515),
				buLangTranslate.preDef.Communication,
				_0090(107395382),
				buLangTranslate.preDef.Offline
			});
			IL_0392:
			((float*)ptr)[4] = global::_0005_0002._0081_0002(Val);
			text2 = global::_0011_0002._008E_0002(((float*)ptr)[4], text3, global::_0086._007E_009D(OpcVars.opcClient));
			goto IL_03c4;
			IL_0558:
			((sbyte*)ptr)[51] = (global::_0014._007F(text2, _0090(107396003)) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[51])
			{
				((sbyte*)ptr)[52] = ((this._0001 != null) ? ((sbyte)1) : ((sbyte)0));
				if (((bool*)ptr)[52])
				{
					MotionCommandEventArg motionCommandEventArg = new MotionCommandEventArg(MotionCommands.ShowWarning, text2, 0.0);
					global::_0088._007E_009F(this._0001, motionCommandEventArg);
				}
			}
			return text2;
			IL_03c4:
			((sbyte*)ptr)[46] = ((VarType == VariableType.LREAL) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[46])
			{
				*(double*)ptr = global::_0006_0002._0082_0002(Val);
				text2 = global::_0012_0002._008F_0002(*(double*)ptr, text3, global::_0086._007E_009D(OpcVars.opcClient));
			}
			((sbyte*)ptr)[47] = ((VarType == VariableType.Bool) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[47])
			{
				((sbyte*)ptr)[48] = (global::_0007_0002._0083_0002(Val) ? ((sbyte)1) : ((sbyte)0));
				text2 = global::_0013_0002._0090_0002(((bool*)ptr)[48], text3, global::_0086._007E_009D(OpcVars.opcClient));
			}
			((sbyte*)ptr)[49] = ((VarType == VariableType.STRING) ? ((sbyte)1) : ((sbyte)0));
			if (((bool*)ptr)[49])
			{
				string text4 = global::_0008_0002._0084_0002(Val);
				text2 = global::_0014_0002._0091_0002(text4, text3, global::_0086._007E_009D(OpcVars.opcClient));
			}
			((sbyte*)ptr)[50] = (global::_0014._007F(text2, _0090(107396003)) ? ((sbyte)1) : ((sbyte)0));
			if (1 == 0)
			{
				goto IL_0392;
			}
			if (((bool*)ptr)[50])
			{
				text2 = global::_0007._000E(new string[5]
				{
					buLangTranslate.preDef.Error,
					_0090(107394248),
					text2,
					_0090(107397159),
					text3
				});
			}
			goto IL_0558;
		}
		catch (Exception ex)
		{
			global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
			global::_0017._0083(ex, text, true, _0090(107397099));
			return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
		}
	}

	public string writeDINTVar(CodesysVariableBaseType VarBaseType, int Val, string Address)
	{
		string text = _0090(107390440);
		try
		{
			string result;
			if (7u != 0)
			{
				object obj = Val;
				object val = default(object);
				if (0 == 0)
				{
					val = obj;
				}
				result = writeVar(VarBaseType, VariableType.DINT, val, Address);
			}
			return result;
		}
		catch (Exception ex)
		{
			while (true)
			{
				if (false)
				{
					continue;
				}
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				if (-1 == 0)
				{
					continue;
				}
				if (0 == 0)
				{
					if (-1 == 0)
					{
						continue;
					}
					if (false)
					{
						break;
					}
					global::_0017._0083(ex, text, true, _0090(107397099));
				}
				return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
			}
		}
		string result2;
		return result2;
	}

	public string writeINTVar(CodesysVariableBaseType VarBaseType, short Val, string Address)
	{
		string text = _0090(107390387);
		try
		{
			string result;
			if (7u != 0)
			{
				object obj = Val;
				object val = default(object);
				if (0 == 0)
				{
					val = obj;
				}
				result = writeVar(VarBaseType, VariableType.INT, val, Address);
			}
			return result;
		}
		catch (Exception ex)
		{
			while (true)
			{
				if (false)
				{
					continue;
				}
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				if (-1 == 0)
				{
					continue;
				}
				if (0 == 0)
				{
					if (-1 == 0)
					{
						continue;
					}
					if (false)
					{
						break;
					}
					global::_0017._0083(ex, text, true, _0090(107397099));
				}
				return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
			}
		}
		string result2;
		return result2;
	}

	public string writeREALVar(CodesysVariableBaseType VarBaseType, float Val, string Address)
	{
		string text = _0090(107390402);
		try
		{
			string result;
			if (7u != 0)
			{
				object obj = Val;
				object val = default(object);
				if (0 == 0)
				{
					val = obj;
				}
				result = writeVar(VarBaseType, VariableType.REAL, val, Address);
			}
			return result;
		}
		catch (Exception ex)
		{
			while (true)
			{
				if (false)
				{
					continue;
				}
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				if (-1 == 0)
				{
					continue;
				}
				if (0 == 0)
				{
					if (-1 == 0)
					{
						continue;
					}
					if (false)
					{
						break;
					}
					global::_0017._0083(ex, text, true, _0090(107397099));
				}
				return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
			}
		}
		string result2;
		return result2;
	}

	public string writeLREALVar(CodesysVariableBaseType VarBaseType, double Val, string Address)
	{
		string text = _0090(107390381);
		try
		{
			string result;
			if (7u != 0)
			{
				object obj = Val;
				object val = default(object);
				if (0 == 0)
				{
					val = obj;
				}
				result = writeVar(VarBaseType, VariableType.LREAL, val, Address);
			}
			return result;
		}
		catch (Exception ex)
		{
			while (true)
			{
				if (false)
				{
					continue;
				}
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				if (-1 == 0)
				{
					continue;
				}
				if (0 == 0)
				{
					if (-1 == 0)
					{
						continue;
					}
					if (false)
					{
						break;
					}
					global::_0017._0083(ex, text, true, _0090(107397099));
				}
				return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
			}
		}
		string result2;
		return result2;
	}

	public string writeBOOLVar(CodesysVariableBaseType VarBaseType, bool Val, string Address)
	{
		string text = _0090(107390328);
		try
		{
			string result;
			if (7u != 0)
			{
				object obj = Val;
				object val = default(object);
				if (0 == 0)
				{
					val = obj;
				}
				result = writeVar(VarBaseType, VariableType.Bool, val, Address);
			}
			return result;
		}
		catch (Exception ex)
		{
			while (true)
			{
				if (false)
				{
					continue;
				}
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				if (-1 == 0)
				{
					continue;
				}
				if (0 == 0)
				{
					if (-1 == 0)
					{
						continue;
					}
					if (false)
					{
						break;
					}
					global::_0017._0083(ex, text, true, _0090(107397099));
				}
				return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
			}
		}
		string result2;
		return result2;
	}

	public string writeSTRINGVar(CodesysVariableBaseType VarBaseType, string Val, string Address)
	{
		if (1 == 0 || 2u != 0)
		{
		}
		string text = _0090(107390339);
		try
		{
			string result;
			do
			{
				result = writeVar(VarBaseType, VariableType.STRING, Val, Address);
			}
			while (false);
			return result;
		}
		catch (Exception ex)
		{
			while (true)
			{
				if (0 == 0)
				{
				}
				global::_008A._0003_0002(_0002, text, _0090(107397045), global::_0010._007E_0019(ex), global::_0010._007E_0012(global::_009E._007E_001C_0002(ex)), 0.0, 0.0, true);
				while (7u != 0)
				{
					global::_0017._0083(ex, text, true, _0090(107397099));
					if (0 == 0)
					{
						return global::_0002._0003(buLangTranslate.preDef.Error, _0090(107390515), buLangTranslate.preDef.Exception);
					}
				}
			}
		}
	}

	static buMotionCommands()
	{
		Strings.CreateGetStringDelegate(typeof(buMotionCommands));
		_0001 = _0090(107389806);
	}
}
