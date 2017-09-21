using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace PmWeb.Core.Extensions
{
    public static class EnumExtensions
	{
		public static string GetDisplayName(this Enum enumValue)
		{
			try
			{
				return enumValue.GetType()
							.GetMember(enumValue.ToString())
							.First()
							.GetCustomAttribute<DisplayAttribute>()
							.GetName();
			}
			catch (Exception ex)
			{
				throw ex;
			}
			
		}
	}
}
