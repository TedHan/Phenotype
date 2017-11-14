using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phenotype.Models;
using Newtonsoft.Json.Linq;

namespace Phenotype.Controllers
{
    [Route("api/[controller]")]
    public class GenotypesController : Controller
    {
        private readonly DataContext _dataContext;
        public GenotypesController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            if (!ModelState.IsValid)
                return BadRequest(new RequestResult
                {
                    Stat = RequestStatus.FormatInvalid,
                    Message = "params error"
                });

            var existGenotype = await _dataContext.Genotypes
                .FindAsync(id);
            if (null == existGenotype)
                return NotFound(new RequestResult
                {
                    Stat = RequestStatus.NotFound,
                    Message = "this one is not exist",
                    Data = new { id }
                });

            return Ok(new RequestResult
            {
                Stat = RequestStatus.Success,
                Message = "ok",
                Data = existGenotype
            });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Genotype genotype)
        {
            if (!ModelState.IsValid)
                return BadRequest(new RequestResult
                {
                    Stat = RequestStatus.FormatInvalid,
                    Message = "params error"
                });

            genotype.Id = Guid.NewGuid();

            _dataContext.Genotypes.Add(genotype);
            await _dataContext.SaveChangesAsync();

            return Created(genotype.ToString(), new RequestResult
            {
                Stat = RequestStatus.Success,
                Message = "Created",
                Data = genotype
            });
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var list = await _dataContext.Genotypes.GroupBy(g => g.Name).ToListAsync();
            return Ok(new RequestResult
            {
                Stat = RequestStatus.Success,
                Data = list
            });
        }

        // [HttpPost("batch")]
        // public async Task<IActionResult> CreateBatch([FromBody] JObject json)
        // {
        //     var name = json.Value<string>("name");
        //     List<JToken> values = json["values"].ToList();
        //     List<Genotype> listToReturn = new List<Genotype>();
        //     foreach (var item in values)
        //     {
        //         var genotype = new Genotype
        //         {
        //             Id = Guid.NewGuid(),
        //             Name = name,
        //             Value = item.ToString()
        //         };
        //         _dataContext.Add(genotype);
        //         listToReturn.Add(genotype);
        //     }
        //     await _dataContext.SaveChangesAsync();
        //     return Ok(new RequestResult
        //     {
        //         Stat = RequestStatus.Success,
        //         Data = listToReturn
        //     });
        // }
    }
}