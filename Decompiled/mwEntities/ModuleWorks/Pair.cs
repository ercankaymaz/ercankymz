using System;

namespace ModuleWorks;

[Serializable]
public class Pair<TFirstType, TSecondType>
{
	public TFirstType First { get; set; }

	public TSecondType Second { get; set; }

	public Pair()
	{
		First = default(TFirstType);
		Second = default(TSecondType);
	}

	public Pair(TFirstType first, TSecondType second)
	{
		First = first;
		Second = second;
	}

	public override string ToString()
	{
		return First.ToString() + "; " + Second.ToString();
	}

	public override bool Equals(object obj)
	{
		Pair<TFirstType, TSecondType> rhs = obj as Pair<TFirstType, TSecondType>;
		return Equals(rhs);
	}

	public bool Equals(Pair<TFirstType, TSecondType> rhs)
	{
		if (rhs == null)
		{
			return false;
		}
		if (!First.Equals(rhs.First))
		{
			return false;
		}
		if (!Second.Equals(rhs.Second))
		{
			return false;
		}
		return true;
	}

	public override int GetHashCode()
	{
		return First.GetHashCode() ^ (Second.GetHashCode() << 5);
	}
}
