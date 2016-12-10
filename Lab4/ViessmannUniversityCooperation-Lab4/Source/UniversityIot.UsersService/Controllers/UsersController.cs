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

        public UsersController(IUsersDataService usersDataService)
        {
            this.usersDataService = usersDataService;
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

            UserViewModel userVM = MapUser(user);
            userVM.Password = string.Empty;

            return Ok(userVM);
        }

        [Route("")]
        public async Task<IHttpActionResult> Post(AddUserViewModel userVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedUser = await this.usersDataService.AddUserAsync(MapUser(userVM));

            var addedUserVM = MapUser(addedUser);

            return Ok(addedUserVM);
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

        private static UserViewModel MapUser(User user)
        {
            var userVM = new UserViewModel()
            {
                CustomerNumber = user.CustomerNumber,
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
            };

            foreach (var userGateway in user.UserGateways)
            {
                userVM.UserGateways.Add(new UserGatewayViewModel()
                {
                    GatewaySerial = userGateway.GatewaySerial,
                    Id = userGateway.Id,
                    AccessType = userGateway.AccessType.ToString()
                });
            }

            return userVM;
        }

        private static User MapUser(AddUserViewModel userVM)
        {
            var user = new User()
            {
                CustomerNumber = userVM.CustomerNumber,
                Name = userVM.Name,
                Password = userVM.Password
            };

            return user;
        }
    }
}