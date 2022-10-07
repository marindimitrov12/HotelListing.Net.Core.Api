using HotelListing.Models;

namespace HotelListing.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LogInDTO userDTO);
        Task<string> CreateToken();
    }
}
