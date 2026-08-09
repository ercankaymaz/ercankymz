using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ComponentFactory.Krypton.Toolkit;

public class ViewContextMenuManager : ViewManager
{
	private class TargetList : List<IContextMenuTarget>
	{
	}

	private IContextMenuTarget _target;

	private IContextMenuTarget _targetSubMenu;

	private Timer _itemDelayTimer;

	public ViewContextMenuManager(Control control, ViewBase root)
		: base(control, root)
	{
		_itemDelayTimer = new Timer();
		_itemDelayTimer.Interval = Math.Max(1, SystemInformation.MenuShowDelay);
		_itemDelayTimer.Tick += OnDelayTimerExpire;
	}

	public override void Dispose()
	{
		if (_itemDelayTimer != null)
		{
			_itemDelayTimer.Stop();
			_itemDelayTimer.Dispose();
			_itemDelayTimer = null;
		}
		if (_targetSubMenu != null)
		{
			_targetSubMenu.ClearSubMenu();
			_targetSubMenu = null;
		}
		if (_target != null)
		{
			_target.ClearTarget();
			_target = null;
		}
		base.Dispose();
	}

	public void SetTarget(IContextMenuTarget target, bool startTimer)
	{
		if (_target == target)
		{
			return;
		}
		if (_target != null)
		{
			_itemDelayTimer.Stop();
			_target.ClearTarget();
			_target = null;
		}
		if (target != null)
		{
			base.ActiveView = target.GetActiveView();
		}
		else
		{
			base.ActiveView = null;
		}
		_target = target;
		if (_target != null)
		{
			_itemDelayTimer.Stop();
			if (startTimer)
			{
				_itemDelayTimer.Start();
			}
			_target.ShowTarget();
		}
	}

	public void SetTargetSubMenu(IContextMenuTarget target)
	{
		if (_itemDelayTimer != null)
		{
			_itemDelayTimer.Stop();
		}
		if (_targetSubMenu != target)
		{
			if (_targetSubMenu != null)
			{
				_targetSubMenu.ClearSubMenu();
				_targetSubMenu = null;
			}
			_targetSubMenu = target;
		}
		if (_target != target)
		{
			_target.ClearTarget();
			_target = null;
		}
		_target = target;
		if (_target != null)
		{
			_target.ShowTarget();
		}
	}

	public void ClearTarget(IContextMenuTarget target)
	{
		if (_target != null)
		{
			_itemDelayTimer.Stop();
			_target.ClearTarget();
			_target = null;
		}
		if (_targetSubMenu != null)
		{
			_target = _targetSubMenu;
			_target.ShowTarget();
		}
	}

	public void ClearTargetSubMenu(IContextMenuTarget target)
	{
		if (_targetSubMenu != null)
		{
			_targetSubMenu.ClearSubMenu();
			_targetSubMenu = null;
		}
	}

	public void KeyUp()
	{
		TargetList targets = ConstructKeyboardTargets(base.Root);
		IContextMenuTarget contextMenuTarget = null;
		contextMenuTarget = ((_target != null) ? FindUpTarget(targets, _target) : FindBottomLeftTarget(targets));
		if (contextMenuTarget != null && contextMenuTarget != _target)
		{
			SetTarget(contextMenuTarget, startTimer: false);
		}
	}

	public void KeyDown()
	{
		TargetList targets = ConstructKeyboardTargets(base.Root);
		IContextMenuTarget contextMenuTarget = null;
		contextMenuTarget = ((_target != null) ? FindDownTarget(targets, _target) : FindTopLeftTarget(targets));
		if (contextMenuTarget != null && contextMenuTarget != _target)
		{
			SetTarget(contextMenuTarget, startTimer: false);
		}
	}

	public bool KeyLeft(bool wrap)
	{
		bool hitEdge = false;
		TargetList targets = ConstructKeyboardTargets(base.Root);
		IContextMenuTarget contextMenuTarget = null;
		contextMenuTarget = ((_target != null) ? FindLeftTarget(targets, _target, wrap, ref hitEdge) : FindTopRightTarget(targets));
		if (contextMenuTarget != null && contextMenuTarget != _target)
		{
			SetTarget(contextMenuTarget, startTimer: false);
		}
		return hitEdge;
	}

	public void KeyRight()
	{
		TargetList targets = ConstructKeyboardTargets(base.Root);
		IContextMenuTarget contextMenuTarget = null;
		contextMenuTarget = ((_target != null) ? FindRightTarget(targets, _target) : FindTopLeftTarget(targets));
		if (contextMenuTarget != null && contextMenuTarget != _target)
		{
			SetTarget(contextMenuTarget, startTimer: false);
		}
	}

	public void KeyTab(bool shift)
	{
		if (shift)
		{
			if (_target == null)
			{
				KeyEnd();
				return;
			}
			TargetList targetList = ConstructKeyboardTargets(base.Root);
			for (int num = targetList.Count - 1; num >= 0; num--)
			{
				if (targetList[num] == _target)
				{
					if (num == 0)
					{
						KeyEnd();
					}
					else
					{
						SetTarget(targetList[num - 1], startTimer: false);
					}
					return;
				}
			}
			KeyEnd();
			return;
		}
		if (_target == null)
		{
			KeyHome();
			return;
		}
		TargetList targetList2 = ConstructKeyboardTargets(base.Root);
		for (int i = 0; i < targetList2.Count; i++)
		{
			if (targetList2[i] == _target)
			{
				if (i == targetList2.Count - 1)
				{
					KeyHome();
				}
				else
				{
					SetTarget(targetList2[i + 1], startTimer: false);
				}
				return;
			}
		}
		KeyHome();
	}

	public void KeyHome()
	{
		TargetList targetList = ConstructKeyboardTargets(base.Root);
		if (targetList.Count > 0)
		{
			SetTarget(targetList[0], startTimer: false);
		}
	}

	public void KeyEnd()
	{
		TargetList targetList = ConstructKeyboardTargets(base.Root);
		if (targetList.Count > 0)
		{
			SetTarget(targetList[targetList.Count - 1], startTimer: false);
		}
	}

	public void KeyMnemonic(char charCode)
	{
		TargetList targetList = ConstructKeyboardTargets(base.Root);
		bool flag = false;
		for (int i = 0; i < targetList.Count; i++)
		{
			if (!flag)
			{
				flag = _target == targetList[i];
			}
			else if (targetList[i].MatchMnemonic(charCode))
			{
				SetTarget(targetList[i], startTimer: false);
				targetList[i].MnemonicActivate();
				return;
			}
		}
		for (int j = 0; j < targetList.Count && _target != targetList[j]; j++)
		{
			if (targetList[j].MatchMnemonic(charCode))
			{
				SetTarget(targetList[j], startTimer: false);
				targetList[j].MnemonicActivate();
				break;
			}
		}
	}

	public bool DoesStackedClientMouseDownBecomeCurrent(Message m, Point pt)
	{
		if (_target != null)
		{
			return _target.DoesStackedClientMouseDownBecomeCurrent(pt);
		}
		return true;
	}

	private TargetList ConstructKeyboardTargets(ViewBase root)
	{
		TargetList targetList = new TargetList();
		FindKeyboardTargets(root, targetList);
		return targetList;
	}

	private void FindKeyboardTargets(ViewBase parent, TargetList targets)
	{
		IContextMenuTarget contextMenuTarget = null;
		if (parent.KeyController != null)
		{
			contextMenuTarget = parent.KeyController as IContextMenuTarget;
		}
		else if (parent.MouseController != null)
		{
			contextMenuTarget = parent.MouseController as IContextMenuTarget;
		}
		if (contextMenuTarget != null)
		{
			targets.Add(contextMenuTarget);
		}
		foreach (ViewBase item in parent)
		{
			FindKeyboardTargets(item, targets);
		}
	}

	private IContextMenuTarget FindTopLeftTarget(TargetList targets)
	{
		IContextMenuTarget contextMenuTarget = null;
		Rectangle rectangle = Rectangle.Empty;
		foreach (IContextMenuTarget target in targets)
		{
			if (contextMenuTarget == null)
			{
				contextMenuTarget = target;
				rectangle = target.ClientRectangle;
				continue;
			}
			Rectangle clientRectangle = target.ClientRectangle;
			if (clientRectangle.Y < rectangle.Y || (clientRectangle.Y == rectangle.Y && clientRectangle.X < rectangle.X))
			{
				contextMenuTarget = target;
				rectangle = clientRectangle;
			}
		}
		return contextMenuTarget;
	}

	private IContextMenuTarget FindTopRightTarget(TargetList targets)
	{
		IContextMenuTarget contextMenuTarget = null;
		Rectangle rectangle = Rectangle.Empty;
		foreach (IContextMenuTarget target in targets)
		{
			if (contextMenuTarget == null)
			{
				contextMenuTarget = target;
				rectangle = target.ClientRectangle;
				continue;
			}
			Rectangle clientRectangle = target.ClientRectangle;
			if (clientRectangle.Y < rectangle.Y || (clientRectangle.Y == rectangle.Y && clientRectangle.X > rectangle.X))
			{
				contextMenuTarget = target;
				rectangle = clientRectangle;
			}
		}
		return contextMenuTarget;
	}

	private IContextMenuTarget FindBottomLeftTarget(TargetList targets)
	{
		IContextMenuTarget contextMenuTarget = null;
		Rectangle rectangle = Rectangle.Empty;
		foreach (IContextMenuTarget target in targets)
		{
			if (contextMenuTarget == null)
			{
				contextMenuTarget = target;
				rectangle = target.ClientRectangle;
				continue;
			}
			Rectangle clientRectangle = target.ClientRectangle;
			if (clientRectangle.Bottom > rectangle.Bottom || (clientRectangle.Bottom == rectangle.Bottom && clientRectangle.X < rectangle.X))
			{
				contextMenuTarget = target;
				rectangle = clientRectangle;
			}
		}
		return contextMenuTarget;
	}

	private IContextMenuTarget FindDownTarget(TargetList targets, IContextMenuTarget current)
	{
		IContextMenuTarget contextMenuTarget = FindDownTarget(targets, current.ClientRectangle);
		if (contextMenuTarget == null)
		{
			Rectangle clientRectangle = current.ClientRectangle;
			clientRectangle.Y = 0;
			clientRectangle.Height = 0;
			contextMenuTarget = FindDownTarget(targets, clientRectangle);
		}
		return contextMenuTarget;
	}

	private IContextMenuTarget FindDownTarget(TargetList targets, Rectangle currentRect)
	{
		currentRect.Y = currentRect.Bottom;
		currentRect.Height = 0;
		IContextMenuTarget contextMenuTarget = null;
		Rectangle rectangle = Rectangle.Empty;
		foreach (IContextMenuTarget target in targets)
		{
			Rectangle clientRectangle = target.ClientRectangle;
			if (clientRectangle.Top < currentRect.Bottom)
			{
				continue;
			}
			if (contextMenuTarget == null)
			{
				contextMenuTarget = target;
				rectangle = clientRectangle;
				continue;
			}
			double num = CenterDistance(currentRect, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, 0));
			double num2 = CenterDistance(currentRect, new Rectangle(clientRectangle.X, clientRectangle.Y, clientRectangle.Width, 0));
			if (num2 < num)
			{
				contextMenuTarget = target;
				rectangle = clientRectangle;
			}
		}
		return contextMenuTarget;
	}

	private IContextMenuTarget FindUpTarget(TargetList targets, IContextMenuTarget current)
	{
		IContextMenuTarget contextMenuTarget = FindUpTarget(targets, current.ClientRectangle);
		if (contextMenuTarget == null)
		{
			Rectangle clientRectangle = current.ClientRectangle;
			clientRectangle.Y = base.AlignControl.Height + 1;
			clientRectangle.Height = 0;
			contextMenuTarget = FindUpTarget(targets, clientRectangle);
		}
		return contextMenuTarget;
	}

	private IContextMenuTarget FindUpTarget(TargetList targets, Rectangle currentRect)
	{
		currentRect.Height = 0;
		IContextMenuTarget contextMenuTarget = null;
		Rectangle rectangle = Rectangle.Empty;
		foreach (IContextMenuTarget target in targets)
		{
			Rectangle clientRectangle = target.ClientRectangle;
			if (clientRectangle.Bottom > currentRect.Top)
			{
				continue;
			}
			if (contextMenuTarget == null)
			{
				contextMenuTarget = target;
				rectangle = clientRectangle;
				continue;
			}
			double num = CenterDistance(currentRect, new Rectangle(rectangle.X, rectangle.Bottom, rectangle.Width, 0));
			double num2 = CenterDistance(currentRect, new Rectangle(clientRectangle.X, clientRectangle.Bottom, clientRectangle.Width, 0));
			if (num2 < num)
			{
				contextMenuTarget = target;
				rectangle = clientRectangle;
			}
		}
		return contextMenuTarget;
	}

	private IContextMenuTarget FindRightTarget(TargetList targets, IContextMenuTarget current)
	{
		IContextMenuTarget contextMenuTarget = FindRightTarget(targets, current.ClientRectangle);
		if (contextMenuTarget == null)
		{
			Rectangle clientRectangle = current.ClientRectangle;
			clientRectangle.X = 0;
			clientRectangle.Width = 0;
			contextMenuTarget = FindRightTarget(targets, clientRectangle);
		}
		return contextMenuTarget;
	}

	private IContextMenuTarget FindRightTarget(TargetList targets, Rectangle currentRect)
	{
		currentRect.X = currentRect.Right;
		currentRect.Width = 0;
		IContextMenuTarget contextMenuTarget = null;
		Rectangle rectangle = Rectangle.Empty;
		foreach (IContextMenuTarget target in targets)
		{
			Rectangle clientRectangle = target.ClientRectangle;
			if (clientRectangle.Left < currentRect.Right)
			{
				continue;
			}
			if (contextMenuTarget == null)
			{
				contextMenuTarget = target;
				rectangle = clientRectangle;
				continue;
			}
			double num = CenterDistance(currentRect, new Rectangle(rectangle.X, rectangle.Y, 0, rectangle.Height));
			double num2 = CenterDistance(currentRect, new Rectangle(clientRectangle.X, clientRectangle.Y, 0, clientRectangle.Height));
			if (num2 < num)
			{
				contextMenuTarget = target;
				rectangle = clientRectangle;
			}
		}
		return contextMenuTarget;
	}

	private IContextMenuTarget FindLeftTarget(TargetList targets, IContextMenuTarget current, bool wrap, ref bool hitEdge)
	{
		IContextMenuTarget contextMenuTarget = FindLeftTarget(targets, current.ClientRectangle);
		if (contextMenuTarget == null)
		{
			if (wrap)
			{
				Rectangle clientRectangle = current.ClientRectangle;
				clientRectangle.X = base.AlignControl.Width + 1;
				clientRectangle.Width = 0;
				contextMenuTarget = FindLeftTarget(targets, clientRectangle);
			}
			else
			{
				hitEdge = true;
			}
		}
		return contextMenuTarget;
	}

	private IContextMenuTarget FindLeftTarget(TargetList targets, Rectangle currentRect)
	{
		currentRect.Width = 0;
		IContextMenuTarget contextMenuTarget = null;
		Rectangle rectangle = Rectangle.Empty;
		foreach (IContextMenuTarget target in targets)
		{
			Rectangle clientRectangle = target.ClientRectangle;
			if (clientRectangle.Right > currentRect.Left)
			{
				continue;
			}
			if (contextMenuTarget == null)
			{
				contextMenuTarget = target;
				rectangle = clientRectangle;
				continue;
			}
			double num = CenterDistance(currentRect, new Rectangle(rectangle.Right, rectangle.Y, 0, rectangle.Height));
			double num2 = CenterDistance(currentRect, new Rectangle(clientRectangle.Right, clientRectangle.Y, 0, clientRectangle.Height));
			if (num2 < num)
			{
				contextMenuTarget = target;
				rectangle = clientRectangle;
			}
		}
		return contextMenuTarget;
	}

	private double CenterDistance(Rectangle source, Rectangle compare)
	{
		double num = Math.Abs((source.Left + source.Right) / 2 - (compare.Left + compare.Right) / 2);
		double num2 = Math.Abs((source.Top + source.Bottom) / 2 - (compare.Top + compare.Bottom) / 2);
		return Math.Sqrt(num * num + num2 * num2);
	}

	private void OnDelayTimerExpire(object sender, EventArgs e)
	{
		if (_itemDelayTimer == null)
		{
			return;
		}
		_itemDelayTimer.Stop();
		if (_target != _targetSubMenu)
		{
			if (_targetSubMenu != null)
			{
				_targetSubMenu.ClearSubMenu();
				_targetSubMenu = null;
			}
			if (_target != null && _target.HasSubMenu)
			{
				_targetSubMenu = _target;
				_target.ShowSubMenu();
			}
		}
	}
}
