using Projekt.API.Data.Base;

namespace Projekt.API.Data.Models
{
    public class Faculty : BaseClass
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Dean { get; set; }

        //Define Reference with Student table
        public List<University> Faculties { get; set; }
    }
}
