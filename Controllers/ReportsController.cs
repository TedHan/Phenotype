using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Phenotype.Models;
using Phenotype.Utils;

namespace Phenotype.Controllers
{
    [Route("api/[controller]")]
    public class ReportsController : Controller
    {
        private readonly DataContext _dataContext;
        public ReportsController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpPost]
        public async Task<IActionResult> GenerateReport(
            [FromBody] ReportParams data)
        {
            var resultList = new List<ResultItem>();
            var init = new ResultItem
            {
                Prob = 1,
                Description = string.Empty
            };
            resultList.Add(init);

            foreach (var item in data.Params)
            {
                var results = await _dataContext.PhenotypeResults
                    .Where(p =>
                        p.FatherId == item.FId
                        && p.MotherId == item.MId)
                    .ToListAsync();

                var temp = new List<ResultItem>(resultList);
                resultList.Clear();
                int a = temp.Count;
                foreach (var tempItem in temp)
                {
                    foreach (var phenotypeItem in results)
                    {
                        var dataTemp = new ResultItem
                        {
                            Prob = tempItem.Prob * phenotypeItem.Probability,
                            Description = tempItem.Description + phenotypeItem.Result
                        };
                        resultList.Add(dataTemp);
                    }
                }
            }

            var listToReturn = resultList
                .Select(i =>
                    new ResultItem
                    {
                        Prob = i.Prob,
                        Description = SpecialRulesHelper.Transform(i.Description)
                    })
                .GroupBy(i => i.Description)
                .Select(i =>
                    new ResultItem
                    {
                        Prob = i.Sum(t => t.Prob),
                        Description = i.First().Description
                    })
                .ToList();

            string str = string.Empty;
            foreach (var item in listToReturn)
            {
                str += (item.Prob * 100).ToString() + "% " + item.Description + "; ";
            }

            return Ok(new RequestResult
            {
                Stat = RequestStatus.Success,
                Data = str
            });
        }
    }
}