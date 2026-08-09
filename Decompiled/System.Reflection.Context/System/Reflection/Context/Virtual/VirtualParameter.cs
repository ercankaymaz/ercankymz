using System.Diagnostics.CodeAnalysis;

namespace System.Reflection.Context.Virtual;

internal class VirtualParameter : ParameterInfo
{
	public VirtualParameter(MemberInfo member, Type parameterType, string name, int position)
	{
		if ((object)member == null)
		{
			throw new ArgumentNullException("member");
		}
		if ((object)parameterType == null)
		{
			throw new ArgumentNullException("parameterType");
		}
		ClassImpl = parameterType;
		MemberImpl = member;
		NameImpl = name;
		PositionImpl = position;
	}

	internal static ParameterInfo[] CloneParameters(MemberInfo member, ParameterInfo[] parameters, bool skipLastParameter)
	{
		int num = parameters.Length;
		if (skipLastParameter)
		{
			num--;
		}
		ParameterInfo[] array = new ParameterInfo[num];
		for (int i = 0; i < num; i++)
		{
			ParameterInfo parameterInfo = parameters[i];
			array[i] = new VirtualParameter(member, parameterInfo.ParameterType, parameterInfo.Name, parameterInfo.Position);
		}
		return array;
	}

	public override bool Equals([NotNullWhen(true)] object obj)
	{
		if (obj is VirtualParameter virtualParameter && Member == virtualParameter.Member && Position == virtualParameter.Position)
		{
			return ParameterType == virtualParameter.ParameterType;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return Member.GetHashCode() ^ Position.GetHashCode() ^ ParameterType.GetHashCode();
	}
}
