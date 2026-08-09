using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ScintillaNET;

public class Lexilla
{
	private static NativeMethods.GetLexerCount getLexerCount;

	private static NativeMethods.GetLexerName getLexerName;

	private static NativeMethods.CreateLexer createLexer;

	private static NativeMethods.LexerNameFromID lexerNameFromId;

	internal Lexilla(nint lexillaHandle)
	{
		string text = "CreateLexer";
		nint procAddress = NativeMethods.GetProcAddress(new HandleRef(this, lexillaHandle), text);
		if (procAddress == IntPtr.Zero)
		{
			throw new Win32Exception($"The Scintilla module has no export for the '{text}' procedure.", new Win32Exception());
		}
		createLexer = (NativeMethods.CreateLexer)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(NativeMethods.CreateLexer));
		text = "GetLexerName";
		nint procAddress2 = NativeMethods.GetProcAddress(new HandleRef(this, lexillaHandle), text);
		if (procAddress2 == IntPtr.Zero)
		{
			throw new Win32Exception($"The Scintilla module has no export for the '{text}' procedure.", new Win32Exception());
		}
		getLexerName = (NativeMethods.GetLexerName)Marshal.GetDelegateForFunctionPointer(procAddress2, typeof(NativeMethods.GetLexerName));
		text = "GetLexerCount";
		nint procAddress3 = NativeMethods.GetProcAddress(new HandleRef(this, lexillaHandle), text);
		if (procAddress3 == IntPtr.Zero)
		{
			throw new Win32Exception($"The Scintilla module has no export for the '{text}' procedure.", new Win32Exception());
		}
		getLexerCount = (NativeMethods.GetLexerCount)Marshal.GetDelegateForFunctionPointer(procAddress3, typeof(NativeMethods.GetLexerCount));
		text = "LexerNameFromID";
		nint procAddress4 = NativeMethods.GetProcAddress(new HandleRef(this, lexillaHandle), text);
		if (procAddress4 == IntPtr.Zero)
		{
			throw new Win32Exception($"The Scintilla module has no export for the '{text}' procedure.", new Win32Exception());
		}
		lexerNameFromId = (NativeMethods.LexerNameFromID)Marshal.GetDelegateForFunctionPointer(procAddress4, typeof(NativeMethods.LexerNameFromID));
	}

	public static int GetLexerCount()
	{
		return (int)getLexerCount();
	}

	public static nint CreateLexer(string lexerName)
	{
		return createLexer(lexerName);
	}

	public static string GetLexerName(int index)
	{
		nint num = Marshal.AllocHGlobal(1024);
		try
		{
			getLexerName((nuint)index, num, new IntPtr(1024));
			return Marshal.PtrToStringAnsi(num);
		}
		finally
		{
			Marshal.FreeHGlobal(num);
		}
	}

	public static string LexerNameFromId(int identifier)
	{
		return lexerNameFromId(new IntPtr(identifier));
	}

	public static IEnumerable<string> GetLexerNames()
	{
		int count = GetLexerCount();
		for (int i = 0; i < count; i++)
		{
			yield return GetLexerName(i);
		}
	}
}
