using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge.DTOs;
using ShopBridge.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Controllers
{
    [Route("server/api/gwp")]
    [ApiController]
    public class CountryGwpController : ControllerBase
    {
        private readonly ICountryGwpRepository _countryGwpRepository;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="countryGwpRepository"></param>
        public CountryGwpController(ICountryGwpRepository countryGwpRepository)
        {
            _countryGwpRepository = countryGwpRepository;
        }

        /// <summary>
        /// This will fetch GWP details.
        /// </summary>
        /// <param name="countryGwpDto"></param>
        /// <returns></returns>
        [HttpPost("avg")]
        public async Task<IActionResult> FetchGwpDetails(CountryGwpDto countryGwpDto)
        {
            if (countryGwpDto == null)
                return BadRequest("Failed to fetch records");

            if (countryGwpDto.startYear == 2008 && countryGwpDto.endYear == 2015)
            {
                CountryGwpToReturnDto countryGwpToReturnDto =  _countryGwpRepository.FetchGwpDetails(countryGwpDto);
                
                if (countryGwpToReturnDto == null)
                    return NotFound();

                return Ok(countryGwpToReturnDto);
            }
            return BadRequest("Failed to fetch record");
        }
    }
}
