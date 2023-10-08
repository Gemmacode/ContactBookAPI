using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using ContactBookModel.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace ContactBookApi.Controllers
{
    public class Update_Patch_ImageUrlByIdController : ControllerBase
    {
        private readonly UserManager<User> _userManager;

        public Update_Patch_ImageUrlByIdController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        [Authorize(Roles = "Regular")]
        [HttpPatch("image/{id}")]
        public async Task<IActionResult> UpUserLoadImage(string id, IFormFile image)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound(new { Messsage = "User not found" });
            }
            if (image == null)
            {
                return BadRequest(new { Messsage = "image file is required" });
            }
            if (image.Length <= 0)
            {
                return BadRequest(new { Messsage = "image file is empty" });
            }
            var cloudinary = new Cloudinary(new Account(
              "dhdh2nasp",
              "878911595791875",
              "MlGeqciyl7qvucORmDAbtHBxK3Q"
            ));
            var upLoad = new ImageUploadParams
            {
                File = new FileDescription(image.FileName, image.OpenReadStream())
            };
            var upLoadResult = await cloudinary.UploadAsync(upLoad);

            user.ImageUrl = upLoadResult.SecureUrl.AbsoluteUri;

            var updateResult = await _userManager.UpdateAsync(user);

            if (!updateResult.Succeeded)
            {
                return BadRequest(new { Messsage = "image update failed" });
            }
            return Ok(new { Messsage = "user image updated successfully" });
        }



    }



}
