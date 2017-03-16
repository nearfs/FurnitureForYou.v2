﻿using FFY.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FFY.Models;
using FFY.Data.Contracts;
using Bytes2you.Validation;

namespace FFY.Services
{
    public class CategoriesService : ICategoriesService
    {
        private readonly IFFYData data;

        public CategoriesService(IFFYData data)
        {
            Guard.WhenArgument<IFFYData>(data, "Data cannot be null.")
                .IsNull()
                .Throw();

            this.data = data;
        }


        public void AddCategory(Category category)
        {
            Guard.WhenArgument<Category>(category, "Category cannot be null.")
                .IsNull()
                .Throw();

            this.data.CategoriesRepository.Add(category);
            this.data.SaveChanges();
        }
    }
}
