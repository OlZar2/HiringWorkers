using Microsoft.AspNetCore.Mvc;

namespace HW.API.Filters.Attributes;

public class CanChangeAccountAttribute : TypeFilterAttribute
{
    public CanChangeAccountAttribute() : base(typeof(CanChangeAccountFilter))
    {
    }
}
