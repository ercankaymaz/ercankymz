using System;
using System.Collections.Generic;

namespace ODA.Kernel.TD_RootIntegrated;

public class MemoryTransaction
{
	private List<IDisposable> ObjList;

	public MemoryTransaction()
	{
		ObjList = new List<IDisposable>();
	}

	public void AddObject(IDisposable newObj)
	{
		if (newObj != null)
		{
			ObjList.Add(newObj);
		}
	}

	public bool RemoveObject(IDisposable theObj)
	{
		IntPtr swigCPtr = Helpers.GetSwigCPtr(theObj);
		for (int num = ObjList.Count - 1; num >= 0; num--)
		{
			IDisposable obj = ObjList[num];
			if (swigCPtr == Helpers.GetSwigCPtr(obj))
			{
				Helpers.ChangeSwigMemoryOwn(theObj, newOwnValue: true);
				Helpers.ChangeSwigMemoryOwn(obj, newOwnValue: false);
				ObjList.RemoveAt(num);
				return true;
			}
		}
		return false;
	}

	public bool HasObject(IDisposable objToCheck)
	{
		IntPtr swigCPtr = Helpers.GetSwigCPtr(objToCheck);
		for (int i = 0; i < ObjList.Count; i++)
		{
			IDisposable obj = ObjList[i];
			if (swigCPtr == Helpers.GetSwigCPtr(obj))
			{
				return true;
			}
		}
		return false;
	}

	public void DeleteObjects()
	{
		for (int num = ObjList.Count - 1; num >= 0; num--)
		{
			ObjList[num].Dispose();
		}
		ObjList.Clear();
	}
}
