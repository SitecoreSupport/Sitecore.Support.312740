using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using Sitecore.Data.Validators;

namespace Sitecore.Support.DataExchange.Local.Validators.FieldValidators
{
  public class ConnectionStringFieldValidator : StandardValidator
  {
    public override string Name => "Connection String";

    public ConnectionStringFieldValidator()
    {
    }

    public ConnectionStringFieldValidator(SerializationInfo info, StreamingContext context)
      : base(info, context)
    {
    }

    protected override ValidatorResult Evaluate()
    {
      string controlValidationValue = base.ControlValidationValue;
      if (!string.IsNullOrWhiteSpace(controlValidationValue) && ConfigurationManager.ConnectionStrings[controlValidationValue] == null)
      {
        base.Text = GetText("No connection string named {0} is defined on the server.", controlValidationValue);
        return base.GetFailedResult(ValidatorResult.Error);
      }
      return ValidatorResult.Valid;
    }

    protected override ValidatorResult GetMaxValidatorResult()
    {
      return base.GetFailedResult(ValidatorResult.Error);
    }
  }
}