// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.ComponentModel.DataAnnotations;

namespace EFCore6Demo.Models
{
    [MetadataType(typeof(CourseMetadata))]
    public partial class Course
    {
    }

    internal class CourseMetadata
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        //[Newtonsoft.Json.JsonIgnore]
        public virtual Department Department { get; set; } = null!;

        //[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Enrollment> Enrollments { get; set; }

        //[Newtonsoft.Json.JsonIgnore]
        public virtual ICollection<Person> Instructors { get; set; }

    }
}
