﻿
namespace Kollegeni.Models;
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Language { get; set; }
    public string Avatar { get; set; }

    public virtual ICollection<UserResidence> UserResidences { get; set; }
}