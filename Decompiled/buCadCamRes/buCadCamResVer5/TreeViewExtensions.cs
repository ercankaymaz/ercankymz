using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ns8;

namespace buCadCamResVer5;

public static class TreeViewExtensions
{
	[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto, Pack = 8)]
	internal struct Struct7
	{
		public int int_0;

		public IntPtr intptr_0;

		public int int_1;

		public int int_2;

		[MarshalAs(UnmanagedType.LPTStr)]
		public string string_0;

		public int int_3;

		public int int_4;

		public int int_5;

		public int int_6;

		public IntPtr intptr_1;
	}

	public static bool IsCheckBoxVisible(this TreeNode node)
	{
		if (node != null)
		{
			if (node.TreeView != null)
			{
				Struct7 struct7_ = new Struct7
				{
					intptr_0 = node.Handle,
					int_0 = 8
				};
				IntPtr intPtr = Class5.SendMessage_1(node.TreeView.Handle, 4414, node.Handle, ref struct7_);
				if (intPtr == IntPtr.Zero)
				{
					throw new ApplicationException("Error getting TreeNode state.");
				}
				int num = (struct7_.int_1 & 0xF000) >> 12;
				return num != 0;
			}
			throw new InvalidOperationException("The node does not belong to a tree.");
		}
		throw new ArgumentNullException("node");
	}

	public static void SetIsCheckBoxVisible(this TreeNode node, bool value)
	{
		if (node != null)
		{
			if (node.TreeView != null)
			{
				Struct7 struct7_ = new Struct7
				{
					intptr_0 = node.Handle,
					int_0 = 8,
					int_2 = 61440,
					int_1 = (value ? ((!node.Checked) ? 1 : 2) : 0) << 12
				};
				IntPtr intPtr = Class5.SendMessage_1(node.TreeView.Handle, 4415, IntPtr.Zero, ref struct7_);
				if (intPtr == IntPtr.Zero)
				{
					throw new ApplicationException("Error setting TreeNode state.");
				}
				return;
			}
			throw new InvalidOperationException("The node does not belong to a tree.");
		}
		throw new ArgumentNullException("node");
	}
}
