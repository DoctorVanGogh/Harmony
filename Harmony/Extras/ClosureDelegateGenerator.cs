using System;
using System.Reflection;

namespace Harmony.Extras
{
   public class ClosureDelegateGenerator
   {
		public static Delegate CreateDelegate(MethodInfo method, string parameterName, MethodInfo delegateMethod)
		{
			if (method == null || string.IsNullOrEmpty(parameterName))
				return null;

			var parameters = method.GetParameters();
			Type delType = null;
			foreach (var parameter in parameters)
			{
				if (parameter.Name == parameterName)
				{
					delType = parameter.ParameterType;
					break;
				}
			}

			if (delType == null)
				return null;

			return Delegate.CreateDelegate(delType, delegateMethod);
		}
	}
}