using AutoMapper;
using meeting.core.Models;
using meeting.services.Interfaces;
using meeting.services.Resources;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Web_API.Resources;
using Web_API.Validators;
using RoomResources = Web_API.Resources.RoomResources;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomController(IRoomService roomService, IMapper mapper)
        {
            this._mapper = mapper;
            this._roomService = roomService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Resources.RoomResources>>> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRooms();
            var roomResources = _mapper.Map<IEnumerable<meeting.core.Models.Room>, IEnumerable<Resources.RoomResources>>(rooms);

            return Ok(roomResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resources.RoomResources>> GetRoomById(string id)
        {
            var room = await _roomService.GetRoomById(id);
            var roomResource = _mapper.Map<meeting.core.Models.Room, Resources.RoomResources>(room);

            return Ok(roomResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<Resources.RoomResources>> CreateRoom([FromBody] Resources.SaveRoomResources saveRoomResource)
        {
            var validator = new SaveRoomResourceValidator();
            var validationResult = await validator.ValidateAsync(saveRoomResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var roomToCreate = _mapper.Map<Resources.SaveRoomResources, meeting.core.Models.Room>(saveRoomResource);

            var newRoom = await _roomService.CreateRoom(roomToCreate);

            var room = await _roomService.GetRoomById(newRoom.Id);

            var roomResource = _mapper.Map<meeting.core.Models.Room, RoomResources>(room);

            return Ok(roomResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<RoomResources>> UpdateRoom(string id, [FromBody] Resources.SaveRoomResources saveRoomResource)
        {
            var validator = new SaveRoomResourceValidator();
            var validationResult = await validator.ValidateAsync(saveRoomResource);

            var requestIsInvalid = id == "0" || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);

            var roomToBeUpdate = await _roomService.GetRoomById(id);

            if (roomToBeUpdate == null)
                return NotFound();

            var room = _mapper.Map<Resources.SaveRoomResources, meeting.core.Models.Room>(saveRoomResource);

            await _roomService.UpdateRoom(roomToBeUpdate, room);

            var updatedRoom = await _roomService.GetRoomById(id);
            var updatedRoomResource = _mapper.Map<meeting.core.Models.Room, RoomResources>(updatedRoom);

            return Ok(updatedRoomResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(string id)
        {
            if (id == "0")
                return BadRequest();

            var room = await _roomService.GetRoomById(id);

            if (room == null)
                return NotFound();

            await _roomService.DeleteRoom(room);

            return NoContent();
        }
    }



}
