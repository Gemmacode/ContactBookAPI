using ContactBookModel.Entities;
using ContactBookModel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ContactBookCore.Implementation.IServices
{
    public interface IUserServices
    {
        Task<IActionResult> DeleteUser(string id);

        Task<IActionResult> GetAllUsers(int page, int pageSize);

        Task<IActionResult> GetUserByEmail(string email);

        Task<IActionResult> GetUserById(string Id);

        //Task<IActionResult> AddNewUser(PostNewUser model);

        Task<IActionResult> UpdateUser(string id, PutUser model);

        public  Task<List<User>> SearchUsersAsync(string searchTerm);

    }
}


