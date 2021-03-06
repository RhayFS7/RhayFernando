﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RhayFernando.Models
{
    public class CategoryListAPIModel : APIModel
    {
        public IQueryable<Category> Result { get; set; }
    }

    public class CategoryAPIModel : APIModel
    {
        public Category Result
        { get; set; }
    }
}