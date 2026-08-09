using System.Windows.Input;

namespace MS.Internal;

internal sealed class KeyboardHelper
{
	internal static ModifierKeys Modifiers
	{
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_000c: Unknown result type (might be due to invalid IL or missing references)
			//IL_000e: Unknown result type (might be due to invalid IL or missing references)
			//IL_000f: Unknown result type (might be due to invalid IL or missing references)
			//IL_001a: Unknown result type (might be due to invalid IL or missing references)
			//IL_001c: Unknown result type (might be due to invalid IL or missing references)
			//IL_001d: Unknown result type (might be due to invalid IL or missing references)
			//IL_002c: Unknown result type (might be due to invalid IL or missing references)
			//IL_0028: Unknown result type (might be due to invalid IL or missing references)
			//IL_002a: Unknown result type (might be due to invalid IL or missing references)
			//IL_002b: Unknown result type (might be due to invalid IL or missing references)
			ModifierKeys val = (ModifierKeys)0;
			if (UnsafeNativeMethods.GetKeyState(16) < 0)
			{
				val = (ModifierKeys)(val | 4);
			}
			if (UnsafeNativeMethods.GetKeyState(17) < 0)
			{
				val = (ModifierKeys)(val | 2);
			}
			if (UnsafeNativeMethods.GetKeyState(18) < 0)
			{
				val = (ModifierKeys)(val | 1);
			}
			return val;
		}
	}

	private KeyboardHelper()
	{
	}
}
