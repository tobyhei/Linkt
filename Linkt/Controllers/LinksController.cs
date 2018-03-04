using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Linkt.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Linkt.Controllers
{
    [Route("api/Links")]
    public class LinksController : Controller
    {
        private readonly LinkRepository linkRepository;

        public LinksController(LinkRepository linkRepository)
        {
            this.linkRepository = linkRepository;
        }

        [HttpGet]
        public Task<List<LinkDto>> Get() => linkRepository.GetPage();

        [HttpGet("{id}", Name = "Get")]
        [ProducesResponseType(typeof(LinkDto), 200)]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await linkRepository.Get(id);

            return result.HasValue ? (IActionResult)Ok(result.Value) : NotFound();
        }

        [HttpPost]
        public Task Post([FromBody] LinkDto value) => linkRepository.Save(value);

        [HttpDelete("{id}")]
        public Task Delete(Guid id) => linkRepository.Delete(id);
    }
}
