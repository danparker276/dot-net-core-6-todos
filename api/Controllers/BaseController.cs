using dp.business.Models;
using Microsoft.AspNetCore.Mvc;

namespace dp.api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected UserDb GetClaimedUser()
        {
            return (UserDb)HttpContext.Items["UserDb"];

        }
    }
}