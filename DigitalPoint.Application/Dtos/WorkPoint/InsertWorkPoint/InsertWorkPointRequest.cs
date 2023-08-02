using System.ComponentModel.DataAnnotations;

namespace DigitalPoint.Application.Dtos.WorkPoints.InsertWorkPoint
{
    public class InsertWorkPointRequest
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DepartureTime { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime EntryTime { get; set; }

    }
}
