using System;
using Microsoft.AspNetCore.Http;

namespace SOMA.Models
{
  public class UsersTable
{
    public int Id { get; set; }
    public string? Fname { get; set; }
    public string? Lname { get; set; }
    public string? Email { get; set; }
    public string? ConfirmEmail { get; set; }
    public string? PhoneNumber { get; set; }
    public string? ConfirmPhoneNumber { get; set; }
    public string? FourNumber { get; set; }
}

}