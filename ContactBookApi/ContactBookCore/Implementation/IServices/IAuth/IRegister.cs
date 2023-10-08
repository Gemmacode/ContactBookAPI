using ContactBookModel.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ContactBookCore.Implementation.IServices.IAuth
{
    public interface IRegister
    {
        public Task<bool> RegisterUserAsync(RegisterNewUser model, ModelStateDictionary modelState, string role);
    }
}
