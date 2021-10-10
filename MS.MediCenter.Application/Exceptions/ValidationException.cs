using FluentValidation.Results;
using MS.MediCenter.Application.Wrappers;
using System;
using System.Collections.Generic;

namespace MS.MediCenter.Application.Exceptions
{
    public class ValidationException : Exception
    {
        public List<string> Errors { get;}
        public ValidationException() : base(Msj.M_ERROR_GENERICO_VALIDACION)
        {
            Errors = new List<string>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(failure.ErrorMessage);
            }
        }
    }
}
