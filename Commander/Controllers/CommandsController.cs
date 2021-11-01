using AutoMapper;
using Command.Dto.Entities;
using Command.Repository.Interfaces;
using Commander.Model.Entities;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Commander.Web.Controllers
{
    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandRepository _commandRepository;
        private readonly IMapper _autoMapper;

        public CommandsController(ICommandRepository commandRepository, IMapper autoMapper)
        {
            _commandRepository = commandRepository;
            _autoMapper = autoMapper;
        }

        // GET api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandsModel = _commandRepository.GetAllCommands();

            var commandsDto = _autoMapper.Map<IEnumerable<CommandReadDto>>(commandsModel);

            return Ok(commandsDto);
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name = "GetCommandById")]
        public ActionResult<CommandModel> GetCommandById(int id)
        {
            var commandModel = _commandRepository.GetCommandById(id);

            if (commandModel == null)
            {
                return NotFound();
            }

            var commandDto = _autoMapper.Map<CommandReadDto>(commandModel);

            return Ok(commandDto);
        }

        // POST api/commands
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _autoMapper.Map<CommandModel>(commandCreateDto);
            _commandRepository.CreateCommand(commandModel);
            _commandRepository.SaveChanges();

            var commandRead = _autoMapper.Map<CommandReadDto>(commandModel);

            return CreatedAtAction(nameof(GetCommandById), new { id = commandRead.Id }, commandRead);
        }

        // PUT api/commands/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto command)
        {
            var commandModelFromDatabase = _commandRepository.GetCommandById(id);

            if (commandModelFromDatabase == null)
                return NotFound();

            _autoMapper.Map(command, commandModelFromDatabase);

            _commandRepository.UpdateCommand(commandModelFromDatabase);
            _commandRepository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartualCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromDatabase = _commandRepository.GetCommandById(id);

            if (commandModelFromDatabase == null)
                return NotFound();

            var commandToPatch = _autoMapper.Map<CommandUpdateDto>(commandModelFromDatabase);

            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _autoMapper.Map(commandToPatch, commandModelFromDatabase);

            _commandRepository.UpdateCommand(commandModelFromDatabase);
            _commandRepository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromDatabase = _commandRepository.GetCommandById(id);

            if (commandModelFromDatabase == null)
                return NotFound();

            _commandRepository.DeleteCommand(commandModelFromDatabase);
            _commandRepository.SaveChanges();

            return NoContent();
        }
    }
}