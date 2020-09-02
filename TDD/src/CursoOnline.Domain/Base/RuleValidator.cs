using System;
using System.Collections.Generic;
using System.Linq;

namespace CursoOnline.Domain.Base
{
   public class RuleValidator
   {
		private readonly List<string> _errorMessages;

		private RuleValidator()
		{
			_errorMessages = new List<string>();
		}

		public static RuleValidator Build()
		{
			return new RuleValidator();
		}

		public RuleValidator ValidateException(bool temErro, string mensagemDeErro)
		{
			if (temErro)
				_errorMessages.Add(mensagemDeErro);

			return this;
		}

		public void TriggerException()
		{
			if (_errorMessages.Any())
				throw new DomainException(_errorMessages);
		}
	}

	public class DomainException : ArgumentException
	{
		public List<string> ErrorMessages { get; set; }

		public DomainException(List<string> errorMessages)
		{
			ErrorMessages = errorMessages;
		}
	}
}
