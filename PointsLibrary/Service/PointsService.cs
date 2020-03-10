using PointsLibrary.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Linq;

namespace PointsLibrary.Service
{
    public class PointsService
    {
        private List<Points> AllPoints { get; set; }

        public PointsService()
        {
            //first method being invoked when you instantiate a class

            using (var jsonFileReader = File.OpenText(this.JsonFileName))
            {
                this.AllPoints = JsonSerializer.Deserialize<Points[]>
                    (jsonFileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }).ToList();
            }
        }

        private string JsonFileName
        {
            get
            {
                return Path.Combine("./Data/points.json");
            }
        }

        public List<Points> GetAllPoints()
        {
            return this.AllPoints;
        }

        public int GetPointsByStudentNumber(string studentNumber)
        {
            //LINQ - lambda
            return this.AllPoints
                .FirstOrDefault(x => x.StudentNumber == studentNumber)
                .NumberOfPoints;
        }

        public void AddPointsToStudent(string studentNumber, int points)
        {
            var found = this.AllPoints
                            .FirstOrDefault
                            (x => x.StudentNumber == studentNumber);

            if (found != null)
            {
                var newpoints = found.NumberOfPoints + points;
                this.AllPoints.FirstOrDefault
                    (x => x.StudentNumber == studentNumber)
                    .NumberOfPoints = newpoints;
                this.Save();
            }
        }

        private void Save()
        {
            using (var outputStream = File.OpenWrite(JsonFileName))
            {
                JsonSerializer.Serialize<IEnumerable<Points>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    this.AllPoints
                );
            }
        }
    }
}
