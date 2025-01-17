using System.Collections.Generic;
using System.Threading.Tasks;
// using InsurancePolicy.DTO;
// using InsurancePolicy.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;

// // using InsurancePolicy.Exception;

// // namespace InsurancePolicy.Controller
// // {
//     [Route("api/policies")]
//     [ApiController]
//     public class InsurancePolicyController : ControllerBase
//     {
//         private readonly IInsurancePolicyService _insurancePolicyService;

//         public InsurancePolicyController(IInsurancePolicyService insurancePolicyService)
//         {
//             _insurancePolicyService = insurancePolicyService;
//         }

//         // GET: api/policies
//         [HttpGet]
//         public async Task<ActionResult<List<InsurancePolicyDTO>>> GetAllPolicies()
//         {
//             var policies = await _insurancePolicyService.GetAllPoliciesAsync();
//             return Ok(policies); // Returns HTTP 200 with the list of policies
//         }

//         // GET: api/policies/{id}
//         [HttpGet("{id}")]
//         public async Task<ActionResult<InsurancePolicyDTO>> GetPolicyById(long id)
//         {
//             try
//             {
//                 var policy = await _insurancePolicyService.GetInsurancePolicyByIdAsync(id);
//                 return Ok(policy); // Returns HTTP 200 with the policy
//             }
//             catch (NotFoundException ex)
//             {
//                 return NotFound(new { message = ex.Message }); // Returns HTTP 404 with the error message
//             }
//         }

//         // POST: api/policies
//         [HttpPost]
//         public async Task<ActionResult<InsurancePolicyDTO>> CreatePolicy([FromBody] InsurancePolicyDTO insurancePolicyDTO)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState); // Returns HTTP 400 if model validation fails
//             }

//             var createdPolicy = await _insurancePolicyService.CreateInsurancePolicyAsync(insurancePolicyDTO);
//             return CreatedAtAction(nameof(GetPolicyById), new { id = createdPolicy.PolicyId }, createdPolicy); 
//             // Returns HTTP 201 with the location of the newly created policy
//         }

//         // PUT: api/policies/{id}
//         [HttpPut("{id}")]
//         public async Task<ActionResult<InsurancePolicyDTO>> UpdatePolicy(long id, [FromBody] InsurancePolicyDTO insurancePolicyDTO)
//         {
//             if (!ModelState.IsValid)
//             {
//                 return BadRequest(ModelState); // Returns HTTP 400 if model validation fails
//             }

//             try
//             {
//                 var updatedPolicy = await _insurancePolicyService.UpdateInsurancePolicyAsync(id, insurancePolicyDTO);
//                 return Ok(updatedPolicy); // Returns HTTP 200 with the updated policy
//             }
//             catch (NotFoundException ex)
//             {
//                 return NotFound(new { message = ex.Message }); // Returns HTTP 404 with the error message
//             }
//         }

//         // DELETE: api/policies/{id}
//         [HttpDelete("{id}")]
//         public async Task<IActionResult> DeletePolicy(long id)
//         {
//             try
//             {
//                 await _insurancePolicyService.DeleteInsurancePolicyAsync(id);
//                 return NoContent(); // Returns HTTP 204 (No Content) if the policy is deleted successfully
//             }
//             catch (NotFoundException ex)
//             {
//                 return NotFound(new { message = ex.Message }); // Returns HTTP 404 with the error message
//             }
//         }
//     }

[ApiController]
[Route("api/[controller]")]
public class InsurancePoliciesController : ControllerBase
{
    private readonly IInsurancePolicyService _service;

    public InsurancePoliciesController(IInsurancePolicyService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var policies = await _service.GetAllPoliciesAsync();
        return Ok(policies);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(long id)
    {
        try
        {
            var policy = await _service.GetPolicyByIdAsync(id);
            return Ok(policy);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] InsurancePolicyDTO policy)
    {
        try
        {
            var createdPolicy = await _service.CreatePolicyAsync(policy);
            return CreatedAtAction(nameof(GetById), new { id = createdPolicy.PolicyNumber }, createdPolicy);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(long id, [FromBody] InsurancePolicyDTO policy)
    {
        try
        {
            var updatedPolicy = await _service.UpdatePolicyAsync(id, policy);
            return Ok(updatedPolicy);
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(long id)
    {
        try
        {
            var success = await _service.DeletePolicyAsync(id);
            return NoContent();
        }
        catch (KeyNotFoundException ex)
        {
            return NotFound(ex.Message);
        }
    }
}
