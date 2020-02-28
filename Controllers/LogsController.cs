using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using LogAPI.Models;
using System.Linq;
using System;

namespace LogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly LogAPIContext _context;

        public LogsController(LogAPIContext context) => _context=context;

        [HttpGet]
        public ActionResult<IQueryable<Log>> GetLogs()
        {
                return _context.Logs;
        }

        [HttpPost]
        public ActionResult<IQueryable<Log>> PostLog(Log i)
        {
           
           
            _context.Logs.Add(i);
            _context.SaveChanges();

            return StatusCode(200);
        }
        

        
      /*  [HttpGet]
        public ActionResult<IEnumerable<string>> GetString()
        {

            return new string[] {"test","aga"};
        }*/
    }
}