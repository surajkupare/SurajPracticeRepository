using AutoMapper;
using CsvHelper;
using ShopBridge.DTOs;
using ShopBridge.Interfaces;
using ShopBridge.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ShopBridge.Repositories
{
    public class CountryGwpRepository : ICountryGwpRepository
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor. 
        /// </summary>
        /// <param name="context"></param>
        /// <param name="mapper"></param>
        public CountryGwpRepository(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// This method will fetch and return data from Country Gwp.
        /// </summary>
        /// <param name="countryGwpDto"></param>
        /// <returns></returns>
        public CountryGwpToReturnDto FetchGwpDetails(CountryGwpDto countryGwpDto)
        {
            //TO-DO: For now fetch data from CSV file. But in actual need to call DB server using EF.
            try
            {
                /*var countryGwp = await _context.countryGwps.FirstOrDefault();
                var countryGwpToReturnDto = _mapper.Map<CountryGwpToReturnDto>(countryGwp);
                return countryGwpToReturnDto == null ? null : countryGwpToReturnDto;*/

                CountryGwpToReturnDto countryGwpToReturnDto = new CountryGwpToReturnDto();
                using var streamReader = File.OpenText(@"SampleOutput.csv"); 
                using var csvReader = new CsvReader(streamReader, CultureInfo.CurrentCulture);

                var countryGwpToReturnDtos = csvReader.GetRecords<CountryGwpToReturnDto>();

                using (IEnumerator<CountryGwpToReturnDto> iterator = countryGwpToReturnDtos.GetEnumerator())
                {
                    if (iterator.MoveNext())
                    {
                        countryGwpToReturnDto = iterator.Current;
                    }
                }
                return countryGwpToReturnDto;
            }
            catch (Exception)
            {
                //Return Null here to avoid data leak.
                //Here can log excetions using logger for development.
                return null;
            }
        }
    }
}
