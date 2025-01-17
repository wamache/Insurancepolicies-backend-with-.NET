// using InsurancePolicy.Exception;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using System;

// // namespace InsurancePolicy.Exception

//     [ApiController]
//     [Route("api/[controller]")]
//     public class RestExceptionHandler : ControllerBase
//     {
//         [HttpGet]
//         [Route("handle-notfound")]
//         public ActionResult<ErrorResponse> HandleResourceNotFoundException(NotFoundException ex)
//         {
//             var errorResponse = new ErrorResponse(StatusCodes.Status404NotFound, ex.Message);
//             return StatusCode(StatusCodes.Status404NotFound, errorResponse);
//         }

//         // Other exception handlers...
//     }

