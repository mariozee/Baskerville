﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baskerville.Models.ViewModels
{
    public class EventViewModel
    {
        public int Id { get; set; }

        public string NameBg { get; set; }

        public string NameEn { get; set; }

        public string DescriptionBg { get; set; }

        public string DescriptionEn { get; set; }

        public string ImageUrl { get; set; }

        public DateTime StartDate { get; set; }

        public bool IsPublic { get; set; }
    }
}