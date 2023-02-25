using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace EmployeeManagement.Utilites
{
	public class ValidEmailDomainAttribute: ValidationAttribute
	{
		private readonly string allowedDomain;

		public ValidEmailDomainAttribute(string allowedDomain)
		{
			this.allowedDomain = allowedDomain;
		}

		public override bool IsValid(object value)
		{
			string[] strings = value.ToString().Split('@');
			return strings[1].ToUpper() == allowedDomain.ToUpper();	
		}

		
	}
}
