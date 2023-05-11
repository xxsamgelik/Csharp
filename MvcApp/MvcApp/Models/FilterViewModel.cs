﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcApp.Models
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Company> companies, int company, string name)
        {
            // устанавливаем начальный элемент, который позволит выбрать всех
            companies.Insert(0, new Company { Name = "Все", Id = 0 });
            Companies = new SelectList(companies, "Id", "Name", company);
            SelectedCompany = company;
            SelectedName = name;
        }
        public SelectList Companies { get; } // список компаний
        public int SelectedCompany { get; } // выбранная компания
        public string SelectedName { get; } // введенное имя
    }
}