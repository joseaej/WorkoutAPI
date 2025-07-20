using Microsoft.AspNetCore.Mvc;
using WorkoutApi.Domain.Models;
using WorkoutApi.Domain.Services;
using WorkoutApi.DTOs.WorkoutApi.Dtos;

namespace WorkoutApi.Controllers
{
    /// <summary>
    /// Controller to manage gym equipment operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class EquipmentController : Controller
    {
        private readonly EquipmentService _equipmentService;

        /// <summary>
        /// Constructor that injects the equipment service.
        /// </summary>
        /// <param name="service">Service to manage equipment data.</param>
        public EquipmentController(EquipmentService service) => _equipmentService = service;

        /// <summary>
        /// Retrieves all available equipment.
        /// </summary>
        /// <remarks>
        /// Returns a list of all equipment items registered in the system.
        /// </remarks>
        /// <returns>
        /// A list of <see cref="EquipmentDto"/> or 404 if none found.
        /// </returns>
        /// <response code="200">Returns the list of equipment</response>
        /// <response code="404">If no equipment is found</response>
        [HttpGet("all_equipment")]
        public async Task<ActionResult<List<EquipmentDto>?>> GetAllItems()
        {
            var result = await _equipmentService.GetAllEquipments();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                List<EquipmentDto> equipments = result.Select(item => new EquipmentDto(item)).ToList();
                return Ok(equipments);
            }
        }

        /// <summary>
        /// Retrieves equipment by its name.
        /// </summary>
        /// <param name="name">The name of the equipment to retrieve.</param>
        /// <returns>
        /// An <see cref="EquipmentDto"/> object with matching name.
        /// </returns>
        /// <response code="200">Returns the matched equipment</response>
        /// <response code="404">If no equipment is found with the given name</response>
        [HttpGet("by_name")]
        public async Task<ActionResult<EquipmentDto>> GetItemByName(string name)
        {
            var result = await _equipmentService.GetByName(name);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(new EquipmentDto(result));
            }
        }

        /// <summary>
        /// Creates a new equipment item.
        /// </summary>
        /// <param name="name">Name of the new equipment.</param>
        /// <param name="description">Description of the new equipment.</param>
        /// <returns>
        /// The newly created <see cref="EquipmentDto"/>.
        /// </returns>
        /// <response code="200">Returns the created equipment</response>
        /// <response code="400">If creation fails</response>
        [HttpPost("create_equipment")]
        public async Task<ActionResult<EquipmentDto>> Create(string name, string description)
        {
            Equipment equipment = new Equipment(name, description);
            var result = await _equipmentService.CreateEquipment(equipment);
            if (result == null)
            {
                return BadRequest("Item not found");
            }
            else
            {
                return Ok(new EquipmentDto(result));
            }
        }



        [HttpPatch("update_name")]
        public async Task<ActionResult<EquipmentDto>> UpdateNameEquipment(string oldName , string newName)
        {
            var result = await _equipmentService.UpdateNameEquipment(oldName, newName);
            if (result ==  null)
            {
                return NotFound();
            }
            return new EquipmentDto(result);
        }

        [HttpPatch("update_description")]
        public async Task<ActionResult<EquipmentDto>> UpdateDescriptionEquipment(string name, string newDescription)
        {
            var result = await _equipmentService.UpdateDescriptionEquipment(name, newDescription);
            if (result == null)
            {
                return NotFound();
            }
            return new EquipmentDto(result);
        }
    }
}
