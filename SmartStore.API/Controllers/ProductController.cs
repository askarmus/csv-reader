using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SmartStore.BusinessServices;
using SmartStore.DataAccess.Entity;
using SmartStore.Model;
using Microsoft.AspNetCore.Authorization;
using SmartStore.Services;
using AutoMapper;

namespace SmartStore.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<ProductController> _logger;
        private readonly IProductsService _productService;
        private readonly IMapper _mapper;

        public ProductController(IMapper mapper , IProductsService productService, UserManager<AppUser> userManager, ILogger<ProductController> logger)
        {
            _logger = logger;
            _productService = productService;
            _userManager = userManager;        
            _mapper = mapper;
        }

        [HttpGet("FetchProduct")]
        public async Task<IActionResult> FetchProduct([FromQuery] Query query)
        {
            var result = await _productService.GetAllProductsAsync(query);
            return Ok(result);
        }
    }
}
