namespace $safeprojectname$.Controllers
{
    [Route("api/applications")]
    [ApiController]
    public class ApplicationController : BaseController
    {
        //private readonly CreateEntityUseCase _createEntityUseCase;
        //private readonly UpdateEntityUseCase _updateEntityUseCase;

        public ApplicationController(
            IHttpContextAccessor httpContextAccessor
            // CreateEntityUseCase createEntityUseCase,
            // UpdateEntityUseCase updateEntityUseCase
            )
            : base(httpContextAccessor)
        {
            // _createEntityUseCase = createEntityUseCase;
            // _updateEntityUseCase = updateEntityUseCase;
        }

        /*[HttpPost]
        public async Task<IActionResult> CreateEntity(CreateEntitInput input)
        {
            return OutputConverter(await _entityCreationCreateUseCase.ExecuteAsync(input));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEntity(Guid id, UpdateEntitInput input)
        {
            input.Id = id;

            return OutputConverter(await _applicationUpdateUseCase.ExecuteAsync(input));
        }*/
    }
}