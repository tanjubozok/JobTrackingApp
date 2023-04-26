﻿using JobTracking.Dtos.Abstract;

namespace JobTracking.Dtos.AppUserDtos;

public class AppUserRegisterDto : IBaseDto
{
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? ComfirmPassword { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? Email { get; set; }
}
