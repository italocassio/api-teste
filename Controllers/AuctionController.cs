using api_auction._Base;
using api_auction._Base.json;
using api_auction.BLL;
using api_auction.Data.Opportunity;
using api_auction.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api_auction.Controllers;

[ApiController]
[Route("[controller]")]
public class AuctionController : ControllerBase
{

    private readonly ILogger<AuctionController> _logger;

    private readonly JaspionDbContext _context;

    private readonly IOpportunityRepository _opportunityRepository;

    public AuctionController(ILogger<AuctionController> logger, JaspionDbContext context, IOpportunityRepository opportunityRepository)
    {
        _logger = logger;
        _context = context;
        _opportunityRepository = opportunityRepository;
    }


    /// <summary>
    /// Retorna uma lista de oportunidades
    /// </summary>
    [HttpGet]
    public async Task<GetOpportunities> Get()
    {
        return await Opportunity.ListAllOportunities(_context, _opportunityRepository);
    }

    /// <summary>
    /// Retorna os itens que a oportunidade está comprando
    /// </summary>
    /// <param name="account">Cliente que recebeu a oportunidade</param>
    /// <param name="buyer_unit">Número da unidade compradora</param>
    /// <param name="auction_number">Número do pregão</param>
    /// <param name="portal">Portal do governo</param>
    [Route("details/{account}")]
    [HttpGet]
    public async Task<ActionResult> GetOpportunityDetails([FromRoute] string account, [FromQuery] string buyer_unit, [FromQuery] string auction_number, [FromQuery] string portal)
    {

        try
        {
            return await Opportunity.GetOpportunityDetails(_context, _opportunityRepository, account, buyer_unit, auction_number, portal);

        }
        catch (DomainException e)
        {
            var result = new ResultReturnErros(e.ErrorMessages);

            return BadRequest(result);
        }
        catch (Exception)
        {
            var result = new ObjectResult(new ResultReturn("Ocorreu um erro ao processar esta operação."));
            result.StatusCode = 500;

            return result;
        }
    }


}
