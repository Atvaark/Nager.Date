﻿using Nager.Date.Contract;
using Nager.Date.Model;
using System.Collections.Generic;
using System.Linq;

namespace Nager.Date.PublicHolidays
{
    /// <summary>
    /// Cyprus
    /// </summary>
    public class CyprusProvider : IPublicHolidayProvider
    {
        private readonly ICatholicProvider _catholicProvider;

        /// <summary>
        /// CyprusProvider
        /// </summary>
        /// <param name="catholicProvider"></param>
        public CyprusProvider(ICatholicProvider catholicProvider)
        {
            this._catholicProvider = catholicProvider;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="year">The year</param>
        /// <returns></returns>
        public IEnumerable<PublicHoliday> Get(int year)
        {
            var countryCode = CountryCode.CY;
            var easterSunday = this._catholicProvider.EasterSunday(year);

            var items = new List<PublicHoliday>();
            items.Add(new PublicHoliday(year, 1, 1, "New Year's Day", "New Year's Day", countryCode));
            items.Add(new PublicHoliday(year, 1, 6, "Θεοφάνεια", "Epiphany", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-48), "Clean Monday", "Clean Monday", countryCode));
            items.Add(new PublicHoliday(year, 3, 25, "Greek Independence Day", "Greek Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 4, 1, "Cyprus National Dayυ", "Cyprus National Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(-2), "Good Friday", "Good Friday", countryCode));
            //Holy Saturday??            
            items.Add(new PublicHoliday(easterSunday.AddDays(1), "Easter Monday", "Easter Monday", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(2), "Easter Tuesday", "Easter Tuesday", countryCode));
            items.Add(new PublicHoliday(year, 5, 1, "Labour Day", "Labour Day", countryCode));
            items.Add(new PublicHoliday(easterSunday.AddDays(49), "Pentecost", "Pentecost", countryCode));
            items.Add(new PublicHoliday(year, 8, 15, "Dormition of the Theotokos", "Dormition of the Theotokos", countryCode));
            items.Add(new PublicHoliday(year, 10, 1, "Cyprus Independence Day", "Cyprus Independence Day", countryCode));
            items.Add(new PublicHoliday(year, 10, 28, "Greek National Day", "Greek National Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 24, "Christmas Eve", "Christmas Eve", countryCode));
            items.Add(new PublicHoliday(year, 12, 25, "Christmas Day", "Christmas Day", countryCode));
            items.Add(new PublicHoliday(year, 12, 26, "St. Stephen's Day", "St. Stephen's Day", countryCode));

            return items.OrderBy(o => o.Date);
        }

        /// <summary>
        /// Get the Holiday Sources
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> GetSources()
        {
            return new string[]
            {
                "https://en.wikipedia.org/wiki/Public_holidays_in_Cyprus",
            };
        }
    }
}
