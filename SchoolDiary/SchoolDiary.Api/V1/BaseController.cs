namespace SchoolDiary.Api.V1
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.ModelBinding;

    public interface IBaseController
    {
        bool IsValid { get; }
        ModelStateDictionary ModelStateBase { get; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase, IBaseController
    {
        public bool IsValid => ModelState.IsValid;

        public ModelStateDictionary ModelStateBase => base.ModelState;
    }
}