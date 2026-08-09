using System;
using System.Collections.Generic;
using SmartAssembly.Delegates;
using SmartAssembly.HouseOfCards;
using buClass;

namespace buMotion;

[Serializable]
public static class buMotionLangDefination
{
	private static string sClassName;

	public static buMotionStatusLang langStatus;

	public static buMotionErrorLang langError;

	public static buMotionWarningLang langWarning;

	public static buMotionAxisErrorLang langAxisError;

	public static buMotionAxisWarningLang langAxisWarning;

	public static buMotionMessageLang langMessage;

	[NonSerialized]
	internal static GetString _0082;

	public static void LoadStatus(List<string> SL)
	{
		string text = _0082(107389835);
		try
		{
			int num = SL.Count;
			do
			{
				num = ((num > 0) ? 1 : 0);
			}
			while (false);
			if (num == 0)
			{
			}
		}
		catch (Exception mSException)
		{
			while (true)
			{
				if (true)
				{
					goto IL_0043;
				}
				goto IL_008e;
				IL_008e:
				if (3u != 0)
				{
					buException.throwException(mSException, text, ShowMessageBox: true, _0082(107397262));
					while (true)
					{
						if (4u != 0)
						{
							return;
						}
					}
					continue;
				}
				goto IL_0043;
				IL_0043:
				buLogVer5.addToLog(sClassName, text, _0082(107395584), _0082(107397262), _0082(107397262));
				goto IL_008e;
			}
		}
	}

	public static void LoadError(List<string> SL)
	{
		string text = _0082(107389786);
		try
		{
			int num = SL.Count;
			do
			{
				num = ((num > 0) ? 1 : 0);
			}
			while (false);
			if (num == 0)
			{
			}
		}
		catch (Exception mSException)
		{
			while (true)
			{
				if (true)
				{
					goto IL_0043;
				}
				goto IL_008e;
				IL_008e:
				if (3u != 0)
				{
					buException.throwException(mSException, text, ShowMessageBox: true, _0082(107397262));
					while (true)
					{
						if (4u != 0)
						{
							return;
						}
					}
					continue;
				}
				goto IL_0043;
				IL_0043:
				buLogVer5.addToLog(sClassName, text, _0082(107395584), _0082(107397262), _0082(107397262));
				goto IL_008e;
			}
		}
	}

	public static void LoadWarning(List<string> SL)
	{
		string text = _0082(107389805);
		try
		{
			int num = SL.Count;
			do
			{
				num = ((num > 0) ? 1 : 0);
			}
			while (false);
			if (num == 0)
			{
			}
		}
		catch (Exception mSException)
		{
			while (true)
			{
				if (true)
				{
					goto IL_0043;
				}
				goto IL_008e;
				IL_008e:
				if (3u != 0)
				{
					buException.throwException(mSException, text, ShowMessageBox: true, _0082(107397262));
					while (true)
					{
						if (4u != 0)
						{
							return;
						}
					}
					continue;
				}
				goto IL_0043;
				IL_0043:
				buLogVer5.addToLog(sClassName, text, _0082(107395584), _0082(107397262), _0082(107397262));
				goto IL_008e;
			}
		}
	}

	public static void LoadAxisError(List<string> SL)
	{
		string text = _0082(107389756);
		try
		{
			int num = SL.Count;
			do
			{
				num = ((num > 0) ? 1 : 0);
			}
			while (false);
			if (num == 0)
			{
			}
		}
		catch (Exception mSException)
		{
			while (true)
			{
				if (true)
				{
					goto IL_0043;
				}
				goto IL_008e;
				IL_008e:
				if (3u != 0)
				{
					buException.throwException(mSException, text, ShowMessageBox: true, _0082(107397262));
					while (true)
					{
						if (4u != 0)
						{
							return;
						}
					}
					continue;
				}
				goto IL_0043;
				IL_0043:
				buLogVer5.addToLog(sClassName, text, _0082(107395584), _0082(107397262), _0082(107397262));
				goto IL_008e;
			}
		}
	}

	public static void LoadAxisWarning(List<string> SL)
	{
		string text = _0082(107389767);
		try
		{
			int num = SL.Count;
			do
			{
				num = ((num > 0) ? 1 : 0);
			}
			while (false);
			if (num == 0)
			{
			}
		}
		catch (Exception mSException)
		{
			while (true)
			{
				if (true)
				{
					goto IL_0043;
				}
				goto IL_008e;
				IL_008e:
				if (3u != 0)
				{
					buException.throwException(mSException, text, ShowMessageBox: true, _0082(107397262));
					while (true)
					{
						if (4u != 0)
						{
							return;
						}
					}
					continue;
				}
				goto IL_0043;
				IL_0043:
				buLogVer5.addToLog(sClassName, text, _0082(107395584), _0082(107397262), _0082(107397262));
				goto IL_008e;
			}
		}
	}

	public static void LoadMessage(List<string> SL)
	{
		string text = _0082(107389746);
		try
		{
			int num = SL.Count;
			do
			{
				num = ((num > 0) ? 1 : 0);
			}
			while (false);
			if (num == 0)
			{
			}
		}
		catch (Exception mSException)
		{
			while (true)
			{
				if (true)
				{
					goto IL_0043;
				}
				goto IL_008e;
				IL_008e:
				if (3u != 0)
				{
					buException.throwException(mSException, text, ShowMessageBox: true, _0082(107397262));
					while (true)
					{
						if (4u != 0)
						{
							return;
						}
					}
					continue;
				}
				goto IL_0043;
				IL_0043:
				buLogVer5.addToLog(sClassName, text, _0082(107395584), _0082(107397262), _0082(107397262));
				goto IL_008e;
			}
		}
	}

	static buMotionLangDefination()
	{
		if (0 == 0)
		{
			if (0 == 0)
			{
				Strings.CreateGetStringDelegate(typeof(buMotionLangDefination));
			}
			if (7u != 0)
			{
				sClassName = _0082(107390209);
				langStatus = new buMotionStatusLang();
				langError = new buMotionErrorLang();
				goto IL_0074;
			}
			goto IL_0082;
		}
		goto IL_0089;
		IL_0089:
		langMessage = new buMotionMessageLang();
		if (false)
		{
			goto IL_0074;
		}
		return;
		IL_0082:
		langAxisWarning = new buMotionAxisWarningLang();
		goto IL_0089;
		IL_0074:
		langWarning = new buMotionWarningLang();
		langAxisError = new buMotionAxisErrorLang();
		goto IL_0082;
	}
}
