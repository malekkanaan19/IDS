using AutoMapper;
using meeting.core.Models;
using meeting.services.Interfaces;
using meeting.services.Resources;
using Microsoft.ApplicationInsights.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Web_API.Resources;
using Web_API.Validators;

namespace Web_API.Controllers
{
   {
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;
        private readonly IMapper _mapper;

        public ReservationsController(IReservationService reservationService, IMapper mapper)
        {
            this._mapper = mapper;
            this._reservationService = reservationService;
        }

        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Resources.ReservationResources>>> GetAllReservations()
        {
            var reservations = await _reservationService.GetAllReservations();
            var reservationResources = _mapper.Map<IEnumerable<meeting.core.Models.Reservation>, IEnumerable<Resources.ReservationResources>>(reservations);

            return Ok(reservationResources);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Resources.ReservationResources>> GetReservationById(string id)
        {
            var reservations = await _reservationService.GetReservationById(id);
            var reservationsResource = _mapper.Map<meeting.core.Models.Reservation, Resources.ReservationResources>(reservations);

            return Ok(reservationsResource);
        }

        [HttpPost("")]
        public async Task<ActionResult<Resources.ReservationResources>> CreateReservation([FromBody] Resources.SaveReservationResources saveReservationResource)
        {
            var validator = new SaveReservationResourceValidator();
            var validationResult = await validator.ValidateAsync(saveReservationResource);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var reserToCreate = _mapper.Map<Resources.SaveReservationResources, meeting.core.Models.Reservation>(saveReservationResource);
            var newReser = await _reservationService.CreateReservation(reserToCreate);

            var reservation = await _reservationService.GetReservationById(newReser.Id);
            var reservationResource = _mapper.Map<meeting.core.Models.Reservation, Resources.ReservationResources>(reservation);
            return Ok(reservationResource);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Resources.ReservationResources>> UpdateReservation(string id, [FromBody] Resources.SaveReservationResources saveReservationResource)
        {
            var validator = new SaveReservationResourceValidator();
            var validationResult = await validator.ValidateAsync(saveReservationResource);

            var requestIsInvalid = id == "0" || !validationResult.IsValid;

            if (requestIsInvalid)
                return BadRequest(validationResult.Errors);
            var reserToBeUpdate = await _reservationService.GetReservationById(id);

            if (reserToBeUpdate == null)
                return NotFound();

            var reservation = _mapper.Map<Resources.SaveReservationResources, meeting.core.Models.Reservation>(saveReservationResource);
            await _reservationService.UpdateReservation(reserToBeUpdate, reservation);

            var updatedReser = await _reservationService.GetReservationById(id);
            var updatedReservationResource = _mapper.Map<meeting.core.Models.Reservation, Resources.ReservationResources>(updatedReser);

            return Ok(updatedReservationResource);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(string id)
        {
            if (id == "0")
                return BadRequest();

            var reservation = await _reservationService.GetReservationById(id);

            if (reservation == null)
                return NotFound();

            await _reservationService.DeleteReservation(reservation);

            return NoContent();
        }
    }
}
