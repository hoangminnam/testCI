using FAS.BLL.BusinessInterfaces;
using FAS.Model.DTOs;
using FAS.Model.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;

namespace FAS.API.Controllers
{
    [Route("api/v1/award-category/[action]")]
    [ApiController]
    public class AwardCategoryController : ControllerBase
    {
        private readonly IAwardCategoryService _service;
        public AwardCategoryController(IAwardCategoryService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetAwardCategoryPage()
        {
            try
            {
                var result = await _service.GetAwardCategoryPage();

                if (result.IsNullOrEmpty())
                {
                    return BadRequest(new { message = "Không tìm thấy dữ liệu Award Category!" });
                }

                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = "Tham số đầu vào không hợp lệ!", detail = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Lỗi xử lý dữ liệu nội bộ!", detail = ex.Message });
            }
            catch (SqlException ex) // cần thêm using Microsoft.Data.SqlClient;
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    new { message = "Lỗi kết nối cơ sở dữ liệu!", detail = ex.Message });
            }
            catch (Exception ex)
            {
                // log ra file / hệ thống logging (Serilog, NLog, ILogger, ...)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Đã xảy ra lỗi không xác định!", detail = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAwardCategoryFilter(string search)
        {
            try
            {
                var result = await _service.GetAwardCategoryFilter(search);

                if (result.IsNullOrEmpty())
                {
                    return BadRequest(new { message = "Không tìm thấy dữ liệu Award Category!" });
                }

                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = "Tham số đầu vào không hợp lệ!", detail = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Lỗi xử lý dữ liệu nội bộ!", detail = ex.Message });
            }
            catch (SqlException ex) // cần thêm using Microsoft.Data.SqlClient;
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    new { message = "Lỗi kết nối cơ sở dữ liệu!", detail = ex.Message });
            }
            catch (Exception ex)
            {
                // log ra file / hệ thống logging (Serilog, NLog, ILogger, ...)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Đã xảy ra lỗi không xác định!", detail = ex.Message });
            }
        }
       
        [HttpPost]
        public async Task<ActionResult<AwardCategory>> SetAwardCategoryInfo([FromBody] AwardCategoryDto award)
        {
            try
            {
                var result = await _service.SetAwardCategoryInfo(award);

                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = "Tham số đầu vào không hợp lệ!", detail = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Lỗi xử lý dữ liệu nội bộ!", detail = ex.Message });
            }
            catch (SqlException ex) // cần thêm using Microsoft.Data.SqlClient;
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    new { message = "Lỗi kết nối cơ sở dữ liệu!", detail = ex.Message });
            }
            catch (Exception ex)
            {
                // log ra file / hệ thống logging (Serilog, NLog, ILogger, ...)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Đã xảy ra lỗi không xác định!", detail = ex.Message });
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateAwardCategory([FromBody] AwardCategoryDto dto)
        {
            try
            {
                var updatedCategory = await _service.UpdateAwardCategoryInfo(dto);

                if (updatedCategory == null)
                {
                    return NotFound(new { message = "AwardCategory không tồn tại!" });
                }

                return Ok(new
                {
                    message = "Cập nhật thành công!",
                    data = updatedCategory
                });
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = "Tham số đầu vào không hợp lệ!", detail = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Lỗi xử lý dữ liệu nội bộ!", detail = ex.Message });
            }
            catch (SqlException ex) // cần thêm using Microsoft.Data.SqlClient;
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    new { message = "Lỗi kết nối cơ sở dữ liệu!", detail = ex.Message });
            }
            catch (Exception ex)
            {
                // log ra file / hệ thống logging (Serilog, ILogger, ...)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Đã xảy ra lỗi không xác định!", detail = ex.Message });
            }

        }
        [HttpDelete]
        public async Task<IActionResult> DeleteAwardCategory([FromQuery] Guid awardCategoryId)
        {
            try
            {
                var result = await _service.DeleteAwardCategory(awardCategoryId);

                return Ok(result);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(new { message = "Tham số đầu vào không hợp lệ!", detail = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Lỗi xử lý dữ liệu nội bộ!", detail = ex.Message });
            }
            catch (SqlException ex) // cần thêm using Microsoft.Data.SqlClient;
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    new { message = "Lỗi kết nối cơ sở dữ liệu!", detail = ex.Message });
            }
            catch (Exception ex)
            {
                // log ra file / hệ thống logging (Serilog, NLog, ILogger, ...)
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Đã xảy ra lỗi không xác định!", detail = ex.Message });
            }
        }
    }
}