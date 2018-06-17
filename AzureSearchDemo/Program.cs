using Microsoft.Azure.Search;
using Microsoft.Azure.Search.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AzureSearchDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var searchServiceName =
                "hp007";
            var apiKey =
                "04469D812912F4EF2FC2C4D1CE22AF5B";

            var searchClient =
                new SearchServiceClient(
                    searchServiceName,
                    new SearchCredentials(apiKey));

            //var newIndex = new Index
            //{
            //    Name = "students2",
            //    Fields = FieldBuilder.BuildForType<Student>()
            //};

            //searchClient.Indexes.Create(newIndex);

            //var students = new List<Student>
            //{
            //    new Student
            //    {
            //        Id = "1",
            //        Name = "Juan García",
            //        Age = "38"
            //    },
            //    new Student
            //    {
            //        Id = "2",
            //        Name = "Emma Watson",
            //        Age = "24"
            //    }
            //};

            //var indexClient = searchClient.Indexes.GetClient("students2");
            //var batch = IndexBatch.Upload(students);
            //indexClient.Documents.Index(batch);

            //Creando índices de búsqueda
            //var indexClient = searchClient.Indexes.GetClient("azuresql-index");
            //SearchParameters sp = new SearchParameters
            //{
            //    SearchMode = SearchMode.All
            //};
            //var docs = indexClient.Documents.Search("white", sp);

            //foreach(var doc in docs.Results)
            //{
            //    foreach(var data in doc.Document)
            //    {
            //        Console.WriteLine($"{data.Key}, {data.Value}");
            //    }
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            var synonymMap = new SynonymMap
            {
                Name = "synonymmap",
                Format = "solr",
                Synonyms = "IT, Juan, Emma"
            };

            searchClient.SynonymMaps.CreateOrUpdate(synonymMap);

            Index index = searchClient.Indexes.Get("students");
            index.Fields.First(f => f.Name == "name").SynonymMaps = new[]
            {
                "synonymmap"
            };
            searchClient.Indexes.CreateOrUpdate(index);

            Console.WriteLine("Operación completada");
            Console.ReadLine();

        }
    }
}
