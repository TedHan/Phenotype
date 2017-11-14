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
    public class PhenotypeResultsController : Controller
    {
        private readonly DataContext _dataContext;
        public PhenotypeResultsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost("batch")]
        public async Task<IActionResult> CreateBatch([FromBody] JArray jarr)
        {
            List<PhenotypeResult> listToReturn = new List<PhenotypeResult>();

            foreach (var json in jarr)
            {
                var father = _dataContext.Genotypes.FirstOrDefault(g => g.Value == json.Value<string>("father"));
                var mother = _dataContext.Genotypes.FirstOrDefault(g => g.Value == json.Value<string>("mother"));

                List<JToken> values = json["values"].ToList();

                foreach (var item in values)
                {
                    var tmp = new PhenotypeResult
                    {
                        Id = Guid.NewGuid(),
                        Father = father,
                        Mother = mother,
                        Probability = item.Value<Double>("prob"),
                        Result = item.Value<string>("result")
                    };
                    _dataContext.PhenotypeResults.Add(tmp);
                    listToReturn.Add(tmp);
                }
            }

            await _dataContext.SaveChangesAsync();

            return Ok(new RequestResult
            {
                Stat = RequestStatus.Success,
                Data = listToReturn
            });
        }
    }
}