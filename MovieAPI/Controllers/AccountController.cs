using BLL.BLL.Abstract;
using DAL;
using DTOS.DTOS.Authentication;
using DTOS.DTOS.UserDTOS;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MovieAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
      private readonly  IUserService _userService;
        private readonly MyAppDbContext _appDbContext;
        IConfiguration _configuration;
        private int? Id => Convert.ToInt32((User.Identity as ClaimsIdentity)?.FindFirst("Id")?.Value);
        public AccountController(IUserService userService, MyAppDbContext myAppDbContext, IConfiguration configuration)
        {
            _userService = userService;
            _appDbContext = myAppDbContext;

            _configuration = configuration;

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UserToUpdateDTO dto)
        {
            await _userService.UpdateAsync(id, dto);
            return Ok();

        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] UserToAddDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
           await _userService.AddAsync(dto);
            return Ok();
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            LoginResponsoDTO response = new LoginResponsoDTO();
            var user = _appDbContext.ApplicationUsers.SingleOrDefault(x => x.Email == dto.Email);   
            if (user == null)
            {
                return BadRequest("Invalid user");
            }
            response.User = user;
            var tokenhandler = new JwtSecurityTokenHandler();
            var tkey = Encoding.UTF8.GetBytes(_configuration["JWTToken:Key"]);
            var ToeknDescp = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Role, user.Roles.ToString()),
                    new Claim("Id", user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tkey), SecurityAlgorithms.HmacSha256Signature)
            };
            var toekn = tokenhandler.CreateToken(ToeknDescp);
            var stringtoken = tokenhandler.WriteToken(toekn).ToString();
            response.Token = stringtoken;
            return Ok(response);
        }
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id )
        {
            await _userService.DeleteAsync(id);
            return Ok();
        }
     
    }
}
