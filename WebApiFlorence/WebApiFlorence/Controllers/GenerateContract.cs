using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFlorence.Data;
using Wkhtmltopdf.NetCore;

namespace WebApiFlorence.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerateContract : ControllerBase
    {
        readonly IGeneratePdf _generatedPdf;
        readonly DataContext dataContext;

        public GenerateContract(DataContext context, IGeneratePdf generatedPdf)
        {
            _generatedPdf= generatedPdf;
            dataContext= context;
        }

        [HttpGet]
        [Route("generateContract")]
        public async Task<IActionResult> getContract()
        {
            var user = new User
            {
                UserId = 40,
                FirstName = "Ramona",
                LastName ="Oana",
                Address="Strada Principala, Numarul 348",
                County="Ilfov",
                Town="Copaceni",
                Phone="0731831884",
                Email="ramonaoana29@gmail.com"
            };
            
            return await _generatedPdf.GetPdf("Views/Contract.cshtml", user);
        }
    }
}
