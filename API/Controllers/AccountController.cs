using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Context;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
  /// handling accounts
    public class AccountController : BaseApiController
    {
    private readonly DataContext _context;
    private readonly ITokenService _tokenService;

    public AccountController(DataContext context,ITokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

        // [HttpPost("register")]
        // public async Task<ActionResult<AppUser>> Register(string username,string password)
        // {

        // }
        [HttpPost("login")]
        public async Task<ActionResult<AppUser>> Login(LoginDto loginDto)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());
            if (user == null) return Unauthorized("Invalid User Name");

            return user;
        }
        private async Task<bool> UserExists(string username)
        {
            return await _context.Users.AnyAsync(x=>x.UserName == username.ToLower());
        }
    }
}