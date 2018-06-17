using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureSearchDemo
{    
    [SerializePropertyNamesAsCamelCase]
    public class Student
    {
        [Key]
        [IsFilterable, IsRetrievable(true), IsSearchable, IsSortable]
        public string Id { get; set; }
        [IsFilterable, IsRetrievable(true), IsSearchable, IsSortable]
        public string Name { get; set; }
        [IsFilterable, IsRetrievable(true), IsSearchable, IsSortable]
        public string Age { get; set; }
    }
}
