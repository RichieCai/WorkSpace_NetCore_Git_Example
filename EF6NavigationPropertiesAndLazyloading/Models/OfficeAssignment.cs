﻿using System;
using System.Collections.Generic;

namespace EFCore6Demo.Models
{
    public partial class OfficeAssignment
    {
        public int InstructorId { get; set; }
        public string? Location { get; set; }

        public virtual Person Instructor { get; set; } = null!;
    }
}
