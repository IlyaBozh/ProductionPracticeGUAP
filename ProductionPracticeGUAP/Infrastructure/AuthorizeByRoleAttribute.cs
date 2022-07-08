using Microsoft.AspNetCore.Authorization;
using ProductionPracticeGUAP.Data.Enums;

namespace ProductionPracticeGUAP.API.Infrastructure;

public class AuthorizeByRoleAttribute : AuthorizeAttribute
{
    public AuthorizeByRoleAttribute(params RoleEnum[] roles)
    {
        Roles = string.Join(",", roles);
        Roles += $",{RoleEnum.Admin}";
    }
}
