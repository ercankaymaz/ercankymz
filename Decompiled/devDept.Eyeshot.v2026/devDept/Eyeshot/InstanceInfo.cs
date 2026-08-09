using System.Collections.Generic;
using System.Linq;
using devDept.Eyeshot.Entities;

namespace devDept.Eyeshot;

internal abstract class InstanceInfo
{
	internal Stack<BlockReference> Parents;

	public InstanceInfo()
	{
	}

	public InstanceInfo(Stack<BlockReference> parents)
	{
		Init(parents);
	}

	public void Init(Stack<BlockReference> parents)
	{
		Parents = parents;
	}

	public bool HasParents()
	{
		if (Parents != null)
		{
			return Parents.Count > 0;
		}
		return false;
	}

	public bool Equals(InstanceInfo other)
	{
		if ((HasParents() && !other.HasParents()) || (!HasParents() && other.HasParents()))
		{
			return false;
		}
		return Parents.SequenceEqual(other.Parents);
	}

	internal static bool FindInstanceInfo<T>(Stack<BlockReference> parents, List<T> instanceInfoList, out T instanceInfo) where T : InstanceInfo, new()
	{
		instanceInfo = null;
		if (instanceInfoList == null || parents == null || parents.Count == 0)
		{
			return false;
		}
		T val = new T();
		val.Init(parents);
		foreach (T instanceInfo2 in instanceInfoList)
		{
			if (val.Equals(instanceInfo2))
			{
				instanceInfo = instanceInfo2;
				return true;
			}
		}
		return false;
	}

	internal static T FindInstanceInfoOrCreate<T>(Stack<BlockReference> parents, List<T> instanceInfoList) where T : InstanceInfo, new()
	{
		T val = new T();
		val.Init(parents);
		foreach (T instanceInfo in instanceInfoList)
		{
			if (val.Equals(instanceInfo))
			{
				return instanceInfo;
			}
		}
		instanceInfoList.Add(val);
		return val;
	}

	internal static void RemoveInstanceInfo<T>(Stack<BlockReference> parents, List<T> instanceInfoList) where T : InstanceInfo, new()
	{
		if (instanceInfoList == null || parents == null || parents.Count == 0)
		{
			return;
		}
		T val = new T();
		val.Init(parents);
		for (int i = 0; i < instanceInfoList.Count; i++)
		{
			T other = instanceInfoList[i];
			if (val.Equals(other))
			{
				instanceInfoList.RemoveAt(i);
				break;
			}
		}
	}

	internal static T FindClosestInstanceInfo<T>(Stack<BlockReference> parents, List<T> instanceInfoList) where T : InstanceInfo, new()
	{
		if (instanceInfoList == null || parents == null || parents.Count == 0)
		{
			return null;
		}
		int num = -1;
		T result = null;
		foreach (T instanceInfo in instanceInfoList)
		{
			int count = instanceInfo.Parents.Count;
			if (count > num)
			{
				Stack<BlockReference> parents2 = new Stack<BlockReference>(parents.Take(count).Reverse());
				T val = new T();
				val.Init(parents2);
				if (instanceInfo.Equals(val))
				{
					result = instanceInfo;
					num = count;
				}
			}
		}
		return result;
	}
}
