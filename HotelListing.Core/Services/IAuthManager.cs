using HotelListing.Core.DTOs;

namespace HotelListing.Core.Services
{
    public interface IAuthManager
    {
        Task<bool> ValidateUser(LogInDTO userDTO);
        Task<string> CreateToken();
    }
}
