using System.Reflection;
using Microsoft.Internal;

namespace System.ComponentModel.Composition;

[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = true)]
public class CatalogReflectionContextAttribute : Attribute
{
	private readonly Type _reflectionContextType;

	public CatalogReflectionContextAttribute(Type reflectionContextType)
	{
		Requires.NotNull(reflectionContextType, "reflectionContextType");
		_reflectionContextType = reflectionContextType;
	}

	public ReflectionContext CreateReflectionContext()
	{
		if (_reflectionContextType == null)
		{
			throw new ArgumentNullException("_reflectionContextType");
		}
		try
		{
			return (ReflectionContext)Activator.CreateInstance(_reflectionContextType);
		}
		catch (InvalidCastException innerException)
		{
			throw new InvalidOperationException(System.SR.ReflectionContext_Type_Required, innerException);
		}
		catch (MissingMethodException inner)
		{
			throw new MissingMethodException(System.SR.ReflectionContext_Requires_DefaultConstructor, inner);
		}
	}
}
