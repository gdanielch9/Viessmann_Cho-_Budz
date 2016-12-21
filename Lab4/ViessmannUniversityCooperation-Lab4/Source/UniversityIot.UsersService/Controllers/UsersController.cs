using UniversityIot.UsersService.Infrastructure;

namespace UniversityIot.UsersService.Controllers
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Http;
    using UniversityIot.UsersDataAccess.Models;
    using UniversityIot.UsersDataService;
    using UniversityIot.UsersService.Helpers;
    using UniversityIot.UsersService.Models;

    [RoutePrefix("users")]
    public class UsersController : ApiController
    {
        private readonly IUsersDataService usersDataService;
        private readonly IMappingInfrastructure  _mappingInfrastructure;

        public UsersController(IUsersDataService usersDataService, IMappingInfrastructure mappingInfrastructure)
        {
            this.usersDataService = usersDataService;
            _mappingInfrastructure = mappingInfrastructure;
        }

        [Route("")]
        public async Task<IHttpActionResult> Get()
        {
            return Ok("a");
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Get(int id)
        {
            var user = await this.usersDataService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            UserViewModel userViewModel = _mappingInfrastructure.MapUserToUserViewModel(user);
            userViewModel.Password = string.Empty;

            return Ok(userViewModel);
        }

        [Route("")]
        public async Task<IHttpActionResult> Post(AddUserViewModel addUserViewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _mappingInfrastructure.MapAddUserViewModelToUser(addUserViewModel);
            var addedUser = await this.usersDataService.AddUserAsync(user);

            var addedUserViewModel = _mappingInfrastructure.MapUserToUserViewModel(addedUser);

            return Ok(addedUserViewModel);
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            var user = await this.usersDataService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await this.usersDataService.DeleteUserAsync(id);

            return Ok();
        }

        [Route("{id:int}")]
        public async Task<IHttpActionResult> Put(int id, [FromBody]EditUserViewModel userVM)
        {
            if (ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await this.usersDataService.GetUserAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            user.CustomerNumber = user.CustomerNumber;
            await this.usersDataService.UpdateUserAsync(user);
            user.Password = string.Empty;

            return Ok(user);
        }

    }
}