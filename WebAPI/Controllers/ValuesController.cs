using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class ValuesController : ControllerBase
    {
        private readonly UserQueriesContext _context;

        public ValuesController (UserQueriesContext context)
        {
            _context = context;
        }

        // GET: api/Values/GetResults/{shimon}
        [HttpGet("GetResults/{query}")]        
        public ActionResult GetResults(string query)
        {
            UserQueries userqueries = new UserQueries();
            userqueries.Query = query;
            userqueries.DateQuery = DateTime.Now;
            _context.UserQueries.Add(userqueries);
            _context.SaveChanges();

            WebClient webClient = new WebClient();
            string url = String.Format("https://api.duckduckgo.com/?q={0}&format=json", query);
            string text = webClient.DownloadString(url);

            var root = (JContainer)JToken.Parse(text);
            var list = root.DescendantsAndSelf().OfType<JProperty>().Where(p => p.Name == "Result").Select(p => p.Value.Value<string>());

            List<ResultsView> listresults = new List<ResultsView>();
            foreach(var item in list)
            {
                ResultsView resultsview = new ResultsView();
                int index1 = item.IndexOf("\">");
                int index2 = item.IndexOf("</a>");
                resultsview.Title = item.Substring(index1 + 2, index2 - index1 - 2);
                resultsview.Link = item.Substring(9, index1 - 9);
                listresults.Add(resultsview);

                Results results = new Results();
                results.Title = resultsview.Title;
                results.Link = resultsview.Link;
                results.UserQueries = userqueries;
                _context.Results.Add(results);
                _context.SaveChanges();
            }

            return Ok(listresults);
        }

        // GET: api/Values/GetResultsFromDate/{"April 9, 2021"}
        [HttpGet("GetResultsFromDate/{date}")]
        public ActionResult GetResultsFromDate(string date)
        {            
            var datetime = DateTime.Parse(date);
            var resultsfromdate = _context.Results.Where(x => x.UserQueries.DateQuery >  datetime)
                .Select(s => new { s.UserQueries.Query, s.Title, s.Link });
            return Ok(resultsfromdate);
        }
    }
}