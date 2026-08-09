using devDept.Eyeshot.Control;

internal static class _0023_003DzzO4Z6lTYD_0024NCCyyJkZj4H3c6eBTKKjjNIN6Zfo0_003D
{
	public static int _0023_003DzFjSNbw0_003D(this modifierKeys _0023_003DzsLHxXyo_003D)
	{
		return _0023_003DzsLHxXyo_003D switch
		{
			modifierKeys.None => 0, 
			modifierKeys.Ctrl => 10, 
			modifierKeys.Alt => 20, 
			modifierKeys.Shift => 30, 
			modifierKeys.CtrlAlt => 100, 
			modifierKeys.CtrlShift => 110, 
			modifierKeys.ShiftAlt => 120, 
			modifierKeys.CtrlShiftAlt => 200, 
			_ => 0, 
		};
	}
}
